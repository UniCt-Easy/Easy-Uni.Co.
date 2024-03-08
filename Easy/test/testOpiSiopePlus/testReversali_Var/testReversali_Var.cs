
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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using metadatalibrary;
using System.Data;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using DBConn;
using q=metadatalibrary.MetaExpression;
using metaeasylibrary;

namespace testReversali_Var {
    [TestClass]
    public class testReversali_Var {

        static DataAccess conn;
        static QueryHelper QHS;
        static int esercizioCorrente;
        static DateTime dataContabileCorrente;

        #region Gestione della Classe (Init + Cleanup)

        [ClassInitialize]
        public static void testInit(TestContext tc) {

            
            esercizioCorrente = DateTime.Now.Year;
            dataContabileCorrente = DateTime.Now;

            //Nino: il nome del DSN deve essrre generico altrimenti diventa fuorviante se poi ognuno collega un db diverso
            conn = DbConn.getEasyAccess(esercizioCorrente,dataContabileCorrente, "test");

            if (conn==null) {
                return;
            }

            QHS = conn.GetQueryHelper();

        }

        [ClassCleanup]
        public static void testEnd() {
            conn.Destroy();
        }

        #endregion

        #region Metodi di test

        /// <summary>
        /// Verifica che le stored procedure di esportazione 
        /// arrivino a termine
        /// </summary>
        [TestMethod]
        public void VerifySP_all() {
            //Le Sp sono prese dalla tabella  exportfunction, campo   procedurename
            DataTable allSp = conn.RUN_SELECT("exportfunction", "procedurename", "procedurename asc",
                QHS.Not(QHS.Like("procedurename", "#%")), null, false);


            foreach (DataRow r in allSp.Rows) {
                string spName = r["procedurename"].ToString(); // Recupera il nome della SP da testare
                
                //Questa SP richiede un linked server
                if (spName == "exp_interscambio_csa_nuoveanagrafiche") continue;
                if (spName == "estrai_valore_token") continue;
                if (spName == "exp_asset_importazione") continue;
                
                Debug.Write("checking " + spName + "..");
                testSingolaSP(spName);
                Debug.WriteLine(" ok");

            }
        }


        #endregion

        #region Funzioni di Servizio

        /// <summary>
        /// Elabora la singola SP verificando che la stessa arrivi a a termine
        /// </summary>
        /// <param name="spName"></param>
        /// <returns></returns>
        public void testSingolaSP(string spName) {
            string spErrMess;

            DataTable tSP = conn.RUN_SELECT("exportfunction", "*", null, QHS.CmpEq("procedurename", spName), null, false);
            DataRow spRow = tSP.Rows[0];
            int spTimeOut;
            if (spRow["timeout"].Equals(System.DBNull.Value))
                spTimeOut = 1;
            else
                spTimeOut = System.Convert.ToInt32(spRow["timeout"]);

            // Act
            // -----------------------------------------------------------------------------------------------------------------
            // Verifica che la congruenza dei parametri della sp con quelli censiti nella tabella exportfunctionparam
            // Se checkParams = true allora c'è congruenza fra i params di SQL e tabella exportfunctionparam
            Boolean checkParams = CheckSpParameter(spName);
            Assert.IsTrue(checkParams, $"SP: {spName}. Il numero dei parametri non è coerente.");

            // Recupera i parametri da passare alla sp
            object[] spParams = GetSpParams(spName);

            // Lancia le sp da testare 
            DataSet retDS = conn.CallSP(spName, spParams, spTimeOut*60, out spErrMess);
            Assert.IsNull(spErrMess, $"SP: {spName}. Errore: {spErrMess}");
            Assert.IsNotNull(retDS, $"SP: {spName}. DataSet di ritorno è null");

        }

        /// <summary>
        /// Verifica che i parametri della SP censiti su database siano congruenti con quelli censiti su tabella exportfunctionparam
        /// </summary>
        /// <param name="spName">Nome della SP</param>
        /// <returns></returns>
        private Boolean CheckSpParameter(string spName) {
            try {
                object mainschema = conn.readValue("INFORMATION_SCHEMA.ROUTINES",
                    q.ne("SPECIFIC_SCHEMA", "DBO") & q.eq("SPECIFIC_NAME", spName), "ROUTINE_TYPE");
                string selectInfoSchema;
                if (mainschema == null || mainschema == DBNull.Value) {
                    selectInfoSchema = "SELECT PARAMETER_NAME, ORDINAL_POSITION, DATA_TYPE " +
                                       "  FROM INFORMATION_SCHEMA.PARAMETERS " +
                                       $" WHERE {QHS.AppAnd(QHS.CmpEq("SPECIFIC_NAME", spName),QHS.CmpEq("SPECIFIC_SCHEMA","DBO"))}";
                }
                else {
                    // Recupera le info memorizzate su INFORMATION_SCHEMA del DB
                    selectInfoSchema = "SELECT PARAMETER_NAME, ORDINAL_POSITION, DATA_TYPE " +
                                       "  FROM INFORMATION_SCHEMA.PARAMETERS " +
                                       $" WHERE {QHS.AppAnd(QHS.CmpEq("SPECIFIC_NAME", spName),QHS.CmpNe("SPECIFIC_SCHEMA","DBO"))}";
                }

                DataTable tParamSchema = conn.SQLRunner(selectInfoSchema, false);

                // Recupera le info presenti su tabella exportfunctionparam
                int nParamCfg = conn.RUN_SELECT_COUNT("exportfunctionparam",
                    QHS.CmpEq("procedurename", spName), false);


                // Match delle info
                if (tParamSchema.Rows.Count == nParamCfg)
                    return true;
                else
                    return false;

            }
            catch {
                return false;
            }

        }


        /// <summary>
        /// Ritorna la lista dei parametri da passare alla sp
        /// </summary>
        /// <param name="spName">Nome della sp</param>
        /// <returns>Array di parametri da passare alla procedura</returns>
        private object[] GetSpParams(string spName) {

            // Recupera gli elementi memorizzati in exportfunctionparam          
            DataTable tParams = conn.RUN_SELECT("exportfunctionparam", "*", null, QHS.CmpEq("procedurename", spName),
                null, false);

            object[] retObj = new object[tParams.Rows.Count];
                // Definisce l'oggetto che sarà di valore di ritorno del metodo
            int i = 0; // Indice 
            
            // Ordina e scorre la dt riempiendo retObj
            foreach (DataRow r in tParams.Select(null, "number ASC")) {

                if (r["paramname"].ToString().ToLower() == "idinventoryagency") {
                    retObj[i] = 1;
                    i++;
                    continue;
                }
                if (r["paramname"].ToString().ToLower() == "idinventory") {
                    retObj[i] = 1;
                    i++;
                    continue;
                }
                if (r["paramname"].ToString().ToLower() == "idinventoryamortization") {
                    retObj[i] = 1;
                    i++;
                    continue;
                }
                // Euristica: Viene verificato che il campo selectioncode sia valorizzato
                object selectionCode = r["selectioncode"];
                if (selectionCode != DBNull.Value && selectionCode.ToString().ToLowerInvariant() != "costant.hidden") {
                    retObj[i] = GetValueFromSelectionCode(r["selectioncode"].ToString(), r["hint"].ToString());
                    i++;
                    continue;
                }

                if (r["hintkind"] != DBNull.Value &&  r["hintkind"].ToString().ToUpper() != "NOHINT") {

                   

                    if (r["hintkind"].ToString().ToUpper() == "ACCOUNTYEAR") {
                        retObj[i] = conn.GetEsercizio();
                        i++;
                        continue;
                    }
                    if (r["hintkind"].ToString().ToUpper() == "ACCOUNTDATE") {
                        retObj[i] = conn.GetDataContabile();
                        i++;
                        continue;
                    }
                    if (r["hintkind"].ToString().ToUpper() == "1/1") {
                        retObj[i] = new DateTime(conn.GetEsercizio(),1,1);
                        i++;
                        continue;
                    }
                    if (r["hintkind"].ToString().ToUpper() == "31/12") {
                        retObj[i] = new DateTime(conn.GetEsercizio(),12,31);
                        i++;
                        continue;
                    }


                    if (r["hintkind"].ToString().ToUpper() == "STRING") {
                        // Euristica: Viene verificato il campo hint, se il suo valore è diverso da null si assegna tale valore
                        if (
                            (!(r["hint"].Equals(System.DBNull.Value)))
                            &&
                            (!(r["hint"].Equals("%")))
                        ) {
                            retObj[i] = r["hint"];
                            i++;
                            continue;
                        }
                    }

                }

                // Euristica: Viene verificata se il campo datasoruce è valorizzato, in quel caso si recupera 
                //            un valore dalla tabella relativamente al campo valuemenber
                if (!(r["datasource"].Equals(System.DBNull.Value))) {
                    retObj[i] = GetValueFromTable(r["datasource"].ToString(), r["valuemember"].ToString());
                    i++;
                    continue;
                }
                else {
                    // Euristica 4: Viene utilizzata la funzione DefaultForParameter
                    retObj[i] = DefaultForParameter(r, esercizioCorrente, dataContabileCorrente);
                    i++;
                }
            }

            return retObj;
        }

        /// <summary>
        /// Ricava il valore di default per i parametri da utilizzare 
        /// </summary>
        /// <param name="Param">Riga dei parametri derivata dalla tabella</param>
        /// <param name="esercizio">Esercizio corrente</param>
        /// <param name="dataContabile">Data contabile</param>
        /// <returns></returns>
        private object DefaultForParameter(DataRow Param, int esercizio, DateTime dataContabile) {
            string TipoDef = Param["hintkind"].ToString().ToUpper();
            DateTime DC = dataContabile;
            switch (TipoDef) {
                case "STRING": //Other
                    return Param["hint"].ToString();
                case "1/CURRM": //Primo giorno del mese
                    return new DateTime(DC.Year, DC.Month, 1);
                case "LASTDAY/CURRM": //Ultimo giorno del mese
                    return new DateTime(DC.Year, DC.Month,
                        DateTime.DaysInMonth(DC.Year, DC.Month));
                case "ACCOUNTYEAR": //esercizio corrente
                    return esercizio;
                case "NOHINT": //nessun valore predef.
                    return DBNull.Value;
                case "1/1": //Primo giorno dell'anno
                    return new DateTime(DC.Year, 1, 1);
                case "31/12": //Ultimo giorno dell'anno
                    return new DateTime(DC.Year, 12, 31);
                case "ACCOUNTDATE": //Data Contabile
                    return DC;
                default:
                    return DBNull.Value;

            }
        }

        /// <summary>
        /// Utilizzato derivare un valore per i campi selectioncode valorizzati per tipo radio e check
        /// </summary>
        /// <param name="selCode"></param>
        /// <returns></returns>
        private object GetValueFromSelectionCode(string selCode, string hint) {
            try {

                string stringToSearch; // Stringa da ricercare (radio o check)
                int pos, len; // Posizione e lunghezza della stringa da ricercare
                int firstPipePos; // Posizione delle prima pipe (|) per la ricerca

                // Caso 1: il contenuto del campo sarà del tipo "radio.S|Sì|N|No|I|Non importa"
                stringToSearch = "radio.";
                pos = selCode.IndexOf(stringToSearch);
                len = stringToSearch.Length;
                if (pos >= 0) {
                    // Ritorna il primo valore compreso fra il punto ed il primo pipe (|)
                    firstPipePos = selCode.IndexOf("|");
                    return selCode.Substring(pos + len, firstPipePos - pos - len);
                }

                // Caso 2: il contenuto del campo sarà del tipo "check.S|N|Sopprimi voci inutilizzate"
                stringToSearch = "check.";
                pos = selCode.IndexOf(stringToSearch);
                len = stringToSearch.Length;
                if (pos >= 0) {
                    // Ritorna il primo valore compreso fra il punto ed il primo pipe (|)
                    firstPipePos = selCode.IndexOf("|");
                    return selCode.Substring(pos + len, firstPipePos - pos - len);
                }

                // Caso 3: il contenuto del campo è del tipo custom.IDSOR0X dove X = 1..5
                stringToSearch = "custom.IDSOR";
                pos = selCode.IndexOf(stringToSearch);
                if (pos >= 0) {
                    // Ritorna il valore nullo
                    return System.DBNull.Value;
                }

                // Caso 4: il contenuto del campo è del tipo custom.
                stringToSearch = "custom.";
                pos = selCode.IndexOf(stringToSearch);
                len = stringToSearch.Length;
                if (pos >= 0) {
                    // Recupera il nome della tabella di riferimento
                    string tableName = selCode.Substring(stringToSearch.Length);

                    // Accede alla tabella per recuperare le info relative ai campi relationfield, filter, tablename
                    // NB. il campo selectioncode è chiave primaria in tabella, quindi la DataTable restituita potrebbe
                    //     avere una sola riga, o al massimo, nessuna riga. 
                    DataTable tCustomSel = conn.RUN_SELECT("customselection", "relationfield, filter, tablename", null,
                        QHS.CmpEq("selectioncode", tableName), null, false);
                    if (tCustomSel.Rows.Count == 1) {

                        // Valorizza il filtro
                        string filterWithValue = conn.Compile(tCustomSel.Rows[0]["filter"].ToString(), true);

                        // Che succede se il filtro non è valorizzato?
                        string tableNameFilter;
                        string tableFieldFilter;

                        if (filterWithValue.Length > 0) {
                            // Recupera nome tabella e nome campo
                            tableNameFilter = tCustomSel.Rows[0]["tablename"].ToString();
                            tableFieldFilter = tCustomSel.Rows[0]["relationfield"].ToString();

                            DataTable tRetFromFilter = conn.RUN_SELECT(tableNameFilter, tableFieldFilter, null,
                                filterWithValue, null, false);

                            if (tRetFromFilter.Rows.Count > 0)
                                return tRetFromFilter.Rows[0][tableFieldFilter];
                            else
                                return System.DBNull.Value;
                        }
                        else
                            return System.DBNull.Value;
                    }

                }
                else {
                    if (selCode.Equals("costant.hidden"))
                        return hint;
                    else
                        return System.DBNull.Value;
                }

                // Ritorna il valore nullo se non l'input selCode non rientra nei casi precedenti
                return System.DBNull.Value;
            }
            catch {
                return System.DBNull.Value;
            }
        }

        /// <summary>
        /// Ritorna un valore di fieldName estratto dalla tabella tableName
        /// </summary>
        /// <param name="tableName">Nome della tabella</param>
        /// <param name="fieldName">Nome del campo</param>
        /// <returns>Il valore "TOP 1" del campo estratto dalla tabella tableName per il campo fieldName</returns>
        private object GetValueFromTable(string tableName, string fieldName) {
            try {

                string select = "SELECT TOP 1 " + fieldName + " FROM " + tableName;
                DataTable t = conn.SQLRunner(select, false);

                // Verifica la cardinalità della dt
                if (t.Rows.Count == 0)
                    return System.DBNull.Value;
                else
                    return t.Rows[0][0]; // Ritorna il primo valore della tabella

            }
            catch {
                return System.DBNull.Value;
            }

        }

        #endregion
    }
}

