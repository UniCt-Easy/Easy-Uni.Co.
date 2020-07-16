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
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
using funzioni_configurazione;
using System.Collections;

namespace EasyInstall {
    class Missione {

        /// <summary>
        /// Metodo da chiamare se il checkBox della missione Ë checked.
        /// Migra tutte le tabelle inerenti la gestione delle Missioni, di configurazione e non.
        /// </summary>
        /// <param name="form"></param>
        /// <param name="sourceConn"></param>
        /// <param name="destConn"></param>
        /// <param name="tTableName"></param>
        /// <param name="tColName"></param>
        public static bool migraMissione(Form form, DataAccess sourceConn, DataAccess destConn,
            DataTable tTableName, DataTable tColName) {

            if (!migraSpeciali(form, sourceConn, destConn, tColName)) return false;

            return true;
        }

        public static bool migraSpeciali(Form form, DataAccess sourceConn, DataAccess destConn,
            DataTable tColName) {
            //classmissione -> sortingkind e figlie + itinerationsorting
            if (!migraClassMissione(form, sourceConn, destConn)) return false;

            // persmissione -> itinerationsetup
            if (!migraItinerationSetup(form, sourceConn, destConn, tColName)) return false;

            // misionetappa -> itinerationlap
            if (!migraItinerationLap(form, sourceConn, destConn, tColName)) return false;

            // missionespesa -> itinerationrefund
            if (!migraItinerationRefund(form, sourceConn, destConn)) return false;
            return true;
            
        }

        public static bool migraClassMissione(Form form, DataAccess sourceConn, DataAccess destConn) {
            // Passo 1. da CLASSMISSIONE devo popolare SORTINGKIND - SORTINGLEVEL - SORTINGAPPLICABILITY - SORTING
            int nRow = sourceConn.RUN_SELECT_COUNT("classmissione", null, true);
            if (nRow == 0) return true;

            return popolaSortingKindEFigli(form, sourceConn, destConn);
        }

        private static bool popolaSortingKindEFigli(Form form, DataAccess sourceConn, DataAccess destConn) {

            // Popolamento di SORTINGKIND
            DataTable tSortingKind = DataAccess.CreateTableByName(destConn, "sortingkind", "*");
            DataRow rSortingKind = tSortingKind.NewRow();
            rSortingKind["idsorkind"] = "_CLASSMISSIONE";
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
            rSortingLevel["idsorkind"] = "_CLASSMISSIONE";
            rSortingLevel["nlevel"] = "1";
            rSortingLevel["codekind"] = "A";
            rSortingLevel["codelen"] = 10;
            rSortingLevel["description"] = "Voce";
            rSortingLevel["flagrestart"] = "S";
            rSortingLevel["flagusable"] = "S";
            rSortingLevel["ct"] = DateTime.Now;
            rSortingLevel["cu"] = "Software And More";
            rSortingLevel["lt"] = DateTime.Now;
            rSortingLevel["lu"] = "Software And More";
            tSortingLevel.Rows.Add(rSortingLevel);

            // Popolamento di SORTINGAPPLICABILITY
            DataTable tSortingApplicability = DataAccess.CreateTableByName(destConn, "sortingapplicability", "*");
            DataRow rSortingApplicability = tSortingApplicability.NewRow();
            rSortingApplicability["idsorkind"] = "_CLASSMISSIONE";
            rSortingApplicability["tablename"] = "itineration";
            rSortingApplicability["ct"] = DateTime.Now;
            rSortingApplicability["cu"] = "Software And More";
            rSortingApplicability["lt"] = DateTime.Now;
            rSortingApplicability["lu"] = "Software And More";

            tSortingApplicability.Rows.Add(rSortingApplicability);

            // Popolamento di SORTING
            Hashtable htCodiciClass;
            DataTable tSorting = popolaSorting(form, sourceConn, destConn, out htCodiciClass);
            if (tSorting == null) {
                MessageBox.Show(form, "Errore nel riempimento della tabella SORTING", "Errore");
                return false;
            }
            DataTable tItinerationSorting = popolaItinerationSorting(form, sourceConn, destConn, htCodiciClass);

            DataSet ds = new DataSet();
            ds.Tables.Add(tSortingKind);
            ds.Tables.Add(tSortingLevel);
            ds.Tables.Add(tSortingApplicability);
            ds.Tables.Add(tSorting);
            ds.Tables.Add(tItinerationSorting);

            return Migrazione.lanciaScript(form, destConn, ds, "classmissione -> struttura di sortingkind e figli + itinerationsorting");
        }

        private static DataTable popolaSorting(Form form, DataAccess sourceConn, DataAccess destConn, out Hashtable htCodiciClass) {
            htCodiciClass = new Hashtable();
            DataTable tClassMissione = DataAccess.CreateTableByName(sourceConn, "classmissione", "codiceclass, descrizione");
            DataAccess.RUN_SELECT_INTO_TABLE(sourceConn, tClassMissione, "codiceclass", null, null, true);
            if (tClassMissione == null) return null;

            DataTable tSorting = DataAccess.CreateTableByName(destConn, "sorting", "*");
            int nProg = 1;
            string pad = "0000";
            foreach(DataRow rClassMissione in tClassMissione.Rows) {
                DataRow rSorting = tSorting.NewRow();
                rSorting["idsorkind"] = "_CLASSMISSIONE";
                int nZeri = pad.Length - nProg.ToString().Length;
                rSorting["idsor"] = pad.Substring(0, nZeri) + nProg.ToString();
                rSorting["description"] = rClassMissione["descrizione"];
                rSorting["nlevel"] = "1";
                rSorting["printingorder"] = "";
                rSorting["sortcode"] = rClassMissione["codiceclass"];
                rSorting["ct"] = DateTime.Now;
                rSorting["cu"] = "Software And More";
                rSorting["lt"] = DateTime.Now;
                rSorting["lu"] = "Software And More";
                tSorting.Rows.Add(rSorting);
                nProg++;
                htCodiciClass[rSorting["sortcode"]] = rSorting["idsor"];
            }
            return tSorting;
        }

        private static DataTable popolaItinerationSorting(Form form, DataAccess sourceConn, DataAccess destConn, Hashtable htCodiciClass) {
            DataTable tItinerationSorting = DataAccess.CreateTableByName(destConn, "itinerationsorting", "*");
            DataTable tMissione = DataAccess.CreateTableByName(sourceConn, "missione", "esercmissione, nummissione, codiceclass");
            sourceConn.RUN_SELECT_INTO_TABLE(tMissione, "esercmissione, nummissione", "(codiceclass is not null)", null, true);
            if (tMissione == null) {
                MessageBox.Show(form, "Errore nell'estrazione dei dati della classificazione diretta della missione", "Errore");
                return null;
            }
            foreach (DataRow rMissione in tMissione.Rows) {
                DataRow rItinerationSorting = tItinerationSorting.NewRow();
                rItinerationSorting["idsorkind"] = "_CLASSMISSIONE";
                rItinerationSorting["idsor"] = htCodiciClass[rMissione["codiceclass"]];
                rItinerationSorting["nitineration"] = rMissione["esercmissione"];
                rItinerationSorting["yitineration"] = rMissione["nummissione"];
                rItinerationSorting["quota"] = 1;
                rItinerationSorting["ct"] = DateTime.Now;
                rItinerationSorting["cu"] = "Software And More";
                rItinerationSorting["lt"] = DateTime.Now;
                rItinerationSorting["lu"] = "Software And More";

                tItinerationSorting.Rows.Add(rItinerationSorting);
            }

            return tItinerationSorting;
        }

        private static bool migraItinerationSetup(Form form, DataAccess sourceConn, DataAccess destConn,
            DataTable tColName) {
            DataTable tItinerationSetup = Migrazione.leggiETraduciTabella("persmissione", 
				sourceConn, tColName, form,	null, "foreignhours = null");
            if (tItinerationSetup == null) {
                MessageBox.Show(form, "Errore nella migrazione di itinerationsetup", "Errore");
                return false;
            }

            DataTable tGeneralitaMissioni = DataAccess.CreateTableByName(sourceConn, "generalitamissioni", "datainizio, oreestero");
            DataAccess.RUN_SELECT_INTO_TABLE(sourceConn, tGeneralitaMissioni, "datainizio", null, null, true);
            if (tGeneralitaMissioni == null) {
                MessageBox.Show(form, "Errore nell'estrazione dei dati di generalitamissioni", "Errore");
                return false;
            }

            foreach(DataRow rItinerationSetup in tItinerationSetup.Rows) {
                int ayear = CfgFn.GetNoNullInt32(rItinerationSetup["ayear"]);
                DateTime fineAnno = new DateTime(ayear, 12, 31);
                string filter = "(datainizio <= " + QueryCreator.quotedstrvalue(fineAnno, false) + ")";
                DataRow [] GenMiss = tGeneralitaMissioni.Select(filter, "datainizio desc");
                if (GenMiss.Length == 0) continue;

                DataRow rGenMiss = GenMiss[0];
                if (rGenMiss["oreestero"] == DBNull.Value) continue;
                rItinerationSetup["foreignhours"] = rGenMiss["oreestero"];
            }

            tItinerationSetup.TableName = "itinerationsetup";
            return Migrazione.lanciaScript(form, destConn, tItinerationSetup, "persmissione -> itinerationsetup");
        }

        private static bool migraItinerationLap(Form form, DataAccess sourceConn, DataAccess destConn, DataTable tColName) {
            DataTable tItinerationLap = Migrazione.leggiETraduciTabella("missionetappa", 
				sourceConn, tColName, form,	"'allowance'", "allowance = round(indennitacorrisposta * isnull(tassocambio,1),2)");
            if (tItinerationLap == null) {
                MessageBox.Show(form, "Errore nella migrazione di itinerationlap", "Errore");
                return false;
            }
            tItinerationLap.TableName = "itinerationlap";

            return Migrazione.lanciaScript(form, destConn, tItinerationLap, "missionetappa -> itinerationlap");
        }

        private static bool migraItinerationRefund(Form form, DataAccess sourceConn, DataAccess destConn) {
            string query = "SELECT ct = S.createtimestamp, cu = S.createuser, lt = S.lastmodtimestamp, lu = S.lastmoduser, " +
                " yitineration = S.esercmissione, nitineration = S.nummissione, " +
                " starttime = T.dataorainizio, stoptime = T.dataorafine, exchangerate = ISNULL(S.tassocambio,1)," +
                " description = S.descrizione, idcurrency = S.codicevaluta, iditinerationrefundkind = S.codiceclass, " +
                " amount = S.importoeffettivo, extraallowance = ROUND(S.importonominale * S.percindennsuppl, 2), " +
                " advancepercentage = CASE WHEN isnull(T.italiaestero,'I') = 'I' THEN S.percanticipoitalia ELSE S.percanticipoestero END, " +
                " flag_geo = CASE WHEN isnull(T.italiaestero,'I') = 'I' THEN 'I' ELSE NULL END, idforeigncountry = T.codicelocalita, " +
                " nrefund = (SELECT COUNT(*) FROM missionespesa S2 WHERE S2.esercmissione =	S.esercmissione AND " +
                " S2.nummissione = S.nummissione AND ( (S2.numtappa < S.numtappa) OR " +
	            " ((S2.numtappa = S.numtappa) AND (S2.numspesa <= S.numspesa))))" +
	            " FROM missionespesa S JOIN missionetappa T " +
                " ON T.esercmissione = S.esercmissione AND T.nummissione = S.nummissione AND T.numtappa = S.numtappa";

            DataTable tItinerationRefund = DataAccess.SQLRunner(sourceConn, query);

            DataTable tForeignCountry = DataAccess.CreateTableByName(destConn, "foreigncountry", "idforeigncountry, flag_ue");
            DataAccess.RUN_SELECT_INTO_TABLE(destConn, tForeignCountry, "idforeigncountry", null, null, true);

            if (tForeignCountry == null) {
                MessageBox.Show(form, "Errore nell'estrazione dei dati da foreigncountry", "Errore");
                return false;
            }
            Hashtable htFC = new Hashtable();
            foreach (DataRow rItinerationRefund in tItinerationRefund.Rows) {
                if (rItinerationRefund["idforeigncountry"] == DBNull.Value) continue;
                string idFC = rItinerationRefund["idforeigncountry"].ToString();
                if (htFC[idFC] == null) {
                    string filter = "(idforeigncountry = " + QueryCreator.quotedstrvalue(idFC, false) + ")";
                    DataRow [] FC = tForeignCountry.Select(filter);
                    if (FC.Length == 0) continue;
                    htFC[idFC] = FC[0]["flag_ue"];
                }
                rItinerationRefund["flag_geo"] = htFC[idFC];
            }

            tItinerationRefund.Columns.Remove("idforeigncountry");
            tItinerationRefund.TableName = "itinerationrefund";

            return Migrazione.lanciaScript(form, destConn, tItinerationRefund, "missionespesa -> itinerationrefund");
        }
        
    }
}
