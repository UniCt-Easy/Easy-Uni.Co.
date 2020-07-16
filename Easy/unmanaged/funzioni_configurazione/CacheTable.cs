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
using System.Data;
using metadatalibrary;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections;
using System.Data.OleDb;


namespace funzioni_configurazione {
    public class TableCache {
        public Dictionary<string, Dictionary<string, object>> h = new Dictionary<string, Dictionary<string, object>>();
        string keyfield;
        string tablename;
        string[] valuefield;
        DataAccess Conn;
        QueryHelper QHS;
        public string staticfilter;
        public TableCache(DataAccess Conn, string keyfield, string tablename, string[] valuefield, string staticfilter) {
            this.keyfield = keyfield;
            this.tablename = tablename;
            this.valuefield = valuefield;
            this.Conn = Conn;
            QHS = Conn.GetQueryHelper();
            this.staticfilter = staticfilter;
        }
        public Dictionary<string, object> GetRow(object key) {
            return h[getStringKey(key)];
        }

        /// <summary>
        /// Legge in modo ottimizzato tutti  i dati collegati alla tabella T, considerando come chiave esterna  T.Columns[field]
        /// </summary>
        /// <param name="T"></param>
        /// <param name="field"></param>
        public void ReadValuesRelatedTo(object []keys, string field) {
            string valuelist = "";
            foreach (object key in keys) {
                if (key == DBNull.Value) continue;
                string skey = getStringKey(key);
                if (h.ContainsKey(skey)) continue;
                AddEmptyRowToCache(key);
                if (valuelist != "") valuelist += ",";
                valuelist += QHS.quote(key);
                if (valuelist.Length > 1000) {
                    getValuesFromKeyList(valuelist);
                    valuelist = "";
                }
            }
            if (valuelist != "") {
                getValuesFromKeyList(valuelist);
            }
        }
       

        /// <summary>
        /// Legge in modo ottimizzato tutti  i dati collegati alla tabella T, considerando come chiave esterna  T.Columns[field]
        /// </summary>
        /// <param name="T"></param>
        /// <param name="field"></param>
        public void ReadValuesRelatedTo(DataTable T, string field) {
            string valuelist = "";
            foreach (DataRow r in T.Rows) {
                if (r.RowState == DataRowState.Deleted) continue;
                object key = r[field];
                if (key == DBNull.Value) continue;
                string skey = getStringKey(key);
                if (h.ContainsKey(skey)) continue;
                AddEmptyRowToCache(key);
                if (valuelist != "") valuelist += ",";
                valuelist += QHS.quote(key);
                if (valuelist.Length > 1000) {
                    getValuesFromKeyList(valuelist);
                    valuelist = "";
                }
            }
            if (valuelist != "") {
                getValuesFromKeyList(valuelist);
            }
        }
       
        public void ReadValuesRelatedTo(DataRow [] rr, string field) {
            string valuelist = "";
            foreach (DataRow r in rr) {
                if (r.RowState == DataRowState.Deleted) continue;
                object key = r[field];
                if (key == DBNull.Value) continue;
                string skey = getStringKey(key);
                if (h.ContainsKey(skey)) continue;
                AddEmptyRowToCache(key);
                if (valuelist != "") valuelist += ",";
                valuelist += QHS.quote(key);
                if (valuelist.Length > 1000) {
                    getValuesFromKeyList(valuelist);
                    valuelist = "";
                }
            }
            if (valuelist != "") {
                getValuesFromKeyList(valuelist);
            }
        }

        /// <summary>
        /// Calcola i valori temporanei di una tabella, in base alla sua chiave esterna
        /// </summary>
        /// <param name="T">Tabella da calcolare</param>
        /// <param name="extkey">campo chiave esterna nella tabella (di solito uguale alla chiave della tabella di cache)</param>
        /// <param name="tablefield">campo da calcolare nella tabella T</param>
        /// <param name="cachefield">campo da utilizzare nella cache (di solito uguale al precedente)</param>
        public void EvaluateFieldFromKey(DataTable T, string extkey, string tablefield, string cachefield) {
            ReadValuesRelatedTo(T, extkey);
            foreach (DataRow r in T.Rows) {
                if (r.RowState == DataRowState.Deleted) continue;
                r[tablefield] = getField(r[extkey], cachefield);
            }

        }
        private void getValuesFromKeyList(string keylist) {
            string filter = QHS.AppAnd(staticfilter, QHS.FieldInList(keyfield, keylist));
            DataTable t = Conn.RUN_SELECT(tablename, getSelectList(), null, filter, null, false);
            foreach (DataRow r in t.Rows) AddDataRowToCache(r);
        }

        private string getSelectList() {
            string s = keyfield;
            foreach (string f in valuefield) s += "," + f;
            return s;
        }
        /// <summary>
        /// Ottiene il valore del campo field collegato alla cache per la riga di chiave key. Accede al db se non la trova in memoria.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public object getField(object key, string field) {
            if (key == DBNull.Value || key == null) return DBNull.Value;
            return ReadValuesFor(key)[field];

        }
        private string getStringKey(object key) {
            return key.ToString();
        }

        private Dictionary<string, object> AddDataRowToCache(DataRow r) {
            Dictionary<string, object> d = new Dictionary<string, object>();
            foreach (string field in valuefield) {
                d[field] = r[field];
            }
            d["!!hasvalue!!"] = "S";
            h[getStringKey(r[keyfield])] = d;
            return d;
        }

        private Dictionary<string, object> AddEmptyRowToCache(object key) {
            Dictionary<string, object> d = new Dictionary<string, object>();
            foreach (string field in valuefield) {
                d[field] = DBNull.Value;
            }
            d["!!hasvalue!!"] = "N";
            h[getStringKey(key)] = d;
            return d;
        }
        public bool HasValueFor(object key) {
            if (key == null || key == DBNull.Value) return false;
            string skey = getStringKey(key);
            if (!h.ContainsKey(skey)) return false;
            Dictionary<string, object> d = h[skey];
            if (d["!!hasvalue!!"].ToString() == "S") return true;
            return false;
        }

        public Dictionary<string, object> ReadValuesFor(object key) {
            string skey = getStringKey(key);
            if (h.ContainsKey(skey)) return h[skey];
            string filter = QHS.AppAnd(staticfilter, QHS.CmpEq(keyfield, key));
            DataTable t = Conn.RUN_SELECT(tablename, getSelectList(), null, filter, null, false);
            if (t.Rows.Count == 0) {
                return AddEmptyRowToCache(key);
            }
            else {
                return AddDataRowToCache(t.Rows[0]);
            }
        }
    }


    public class AutoTablesCache {
        public TableCache fin;
        public TableCache upb;
        public TableCache registry;
        public TableCache manager;
        public TableCache underwriting;
        public TableCache expensephase;
        public TableCache incomephase;
        public TableCache tax;
        public TableCache sorting;
        public TableCache sortingkind;
        private TableCache taxsetup;
        public TableCache config;
        public TableCache clawbacksetup;
        public TableCache clawback;
        public TableCache paymethod;

        public AutoTablesCache(DataAccess Conn) {
            QueryHelper QHS = Conn.GetQueryHelper();
            int esercizio = CfgFn.GetNoNullInt32(Conn.GetSys("esercizio"));
            fin = new TableCache(Conn, "idfin", "fin", new string[] { "codefin", "title" }, null);
            upb = new TableCache(Conn, "idupb", "upb", new string[] { "codeupb", "title" }, null);
            registry = new TableCache(Conn, "idreg", "registry", new string[] { "title" }, null);
            manager = new TableCache(Conn, "idman", "manager", new string[] { "title" }, null);
            underwriting = new TableCache(Conn, "idunderwriting", "underwriting", new string[] { "codeunderwriting","title" }, null);
            expensephase = new TableCache(Conn, "nphase", "expensephase", new string[] { "description" }, null);
            incomephase = new TableCache(Conn, "nphase", "incomephase", new string[] { "description" }, null);
            tax = new TableCache(Conn, "taxcode", "tax", new string[] { "taxablecode", "description" }, null);
            sorting = new TableCache(Conn, "idsor", "sorting", new string[] { "idsorkind", "sortcode", "description" }, null);
            sortingkind = new TableCache(Conn, "idsorkind", "sortingkind", 
                        new string[] { "codesorkind", "description", "nphaseincome","nphaseexpense" }, null);
            taxsetup = new TableCache(Conn, "taxcode", "taxsetup",
                        new string[] { "idfinincomecontra", "idfinincomeemploy", "idfinadmintax", "idfinexpensecontra", "idfinexpenseemploy" },
                                        QHS.CmpEq("ayear", esercizio));
            config = new TableCache(Conn, "ayear", "config", new string[] { "automanagekind", "idregauto",
                            "flagautopayment","flagpcashautopayment","flagautoproceeds","flagpcashautoproceeds"}, null);
            config.ReadValuesFor(esercizio);

            clawbacksetup = new TableCache(Conn, "idclawback", "clawbacksetup", new string[] { "clawbackfinance" },
                                                QHS.CmpEq("ayear", esercizio));

            clawback = new TableCache(Conn, "idclawback", "clawback", new string[] { "description" }, null);

            paymethod = new TableCache(Conn, "idpaymethod", "paymethod", new string[] { "allowdeputy", "flag" }, null);

            TableCache finmotDetail = new TableCache(Conn, "idfinmotive", "finmotivedetail", new string[] {"idfin"},
                QHS.CmpEq("ayear", esercizio));

          

            /** Crea il dizionario taxServiceConfig */
            DataTable t = Conn.RUN_SELECT("taxfinmotive", "*", null, null, null,
                false);
            foreach (DataRow  r in t.Rows) {
                int idser = CfgFn.GetNoNullInt32(r["idser"]);
                int taxcode = CfgFn.GetNoNullInt32(r["taxcode"]);
                if (!taxServiceConfig.ContainsKey(taxcode)) {
                    taxServiceConfig[taxcode] = new Dictionary<int, Dictionary<string, object>>();
                   
                }
                Dictionary<int, Dictionary<string, object>> serviceConfig = taxServiceConfig[taxcode];

                serviceConfig[idser] = new Dictionary<string, object>();
                object idfin= finmotDetail.getField(r["idmotincomeintra"], "idfin");
                if (idfin == DBNull.Value && serviceConfig.ContainsKey(0)) idfin = serviceConfig[0]["idfinincomecontra"];
                serviceConfig[idser]["idfinincomecontra"] = idfin;

                idfin = finmotDetail.getField(r["idmotincomeemploy"], "idfin");
                if (idfin==DBNull.Value && serviceConfig.ContainsKey(0)) idfin = serviceConfig[0]["idfinincomeemploy"];
                serviceConfig[idser]["idfinincomeemploy"] = idfin;

                idfin = finmotDetail.getField(r["idmotadmintax"], "idfin");
                if (idfin == DBNull.Value && serviceConfig.ContainsKey(0)) idfin = serviceConfig[0]["idfinadmintax"];
                serviceConfig[idser]["idfinadmintax"] = idfin;

                idfin = finmotDetail.getField(r["idmotexpenseemploy"], "idfin");
                if (idfin == DBNull.Value && serviceConfig.ContainsKey(0)) idfin = serviceConfig[0]["idfinexpenseemploy"];
                serviceConfig[idser]["idfinexpenseemploy"] = idfin;

                idfin = finmotDetail.getField(r["idmotexpensecontra"], "idfin");
                if (idfin == DBNull.Value && serviceConfig.ContainsKey(0)) idfin = serviceConfig[0]["idfinexpensecontra"];
                serviceConfig[idser]["idfinexpensecontra"] = idfin;
                
            }

            

        }

        // taxcode - idser - fieldname tra idfinincomeintra idfinincomeemploy idfinadmintax idfinexpenseemploy idfinexpensecontra
        private Dictionary<int, Dictionary<int, Dictionary<string, object>>> taxServiceConfig =
            new Dictionary<int, Dictionary<int, Dictionary<string, object>>>();

        
        public bool hasValueForTaxConfig(object idservice, object taxcode) {
            if (taxcode == DBNull.Value) {
                return false;
            }
            int iTaxCode = CfgFn.GetNoNullInt32(taxcode);
            int iService = CfgFn.GetNoNullInt32(idservice);

            if (!taxServiceConfig.ContainsKey(iTaxCode)) {                
                Dictionary<string, object> r = taxsetup.ReadValuesFor(iTaxCode);                
                taxServiceConfig[iTaxCode] = new Dictionary<int, Dictionary<string, object>>();                
                taxServiceConfig[iTaxCode][0] = r;
            }
            
            if (!taxServiceConfig.ContainsKey(iTaxCode)) return false;
            Dictionary<int, Dictionary<string, object>> serviceConfig = taxServiceConfig[iTaxCode];
            if (serviceConfig.ContainsKey(iService)) {
                return true;
            }

            if (serviceConfig.ContainsKey(0)) {
                return true;
            }

            taxsetup.ReadValuesFor(taxcode);
            if (taxsetup.HasValueFor(taxcode)) {
                serviceConfig[0] = taxsetup.GetRow(taxcode);
                return true;
            }
            

            return false;
        }

        public Dictionary<string, object> getTaxConfig(object idservice, object taxcode) {
            if (taxcode == DBNull.Value) return null;
            int iTaxCode = CfgFn.GetNoNullInt32(taxcode);
            int iService = CfgFn.GetNoNullInt32(idservice);
            

            //ricerca prima per idservice e taxcode simultaneamente
            if (!taxServiceConfig.ContainsKey(iTaxCode)) return null;
            Dictionary<int, Dictionary<string, object>> serviceConfig = taxServiceConfig[iTaxCode];
            if (serviceConfig.ContainsKey(iService)) {
                Dictionary<string, object> baseRow = null;
                string []fields = new string[]
                {"idfinincomecontra", "idfinincomeemploy", "idfinadmintax", "idfinexpensecontra", "idfinexpenseemploy"};
                if (serviceConfig.ContainsKey(0)) {
                    baseRow = serviceConfig[0];
                }
                else {
                    taxsetup.ReadValuesFor(taxcode);
                    if (taxsetup.HasValueFor(taxcode)) {
                        serviceConfig[0] = taxsetup.GetRow(taxcode);
                        baseRow = serviceConfig[0];
                    }
                }
                Dictionary<string, object> choosen = serviceConfig[iService];
                foreach (string f in fields) {
                    if ((choosen.ContainsKey(f)==false) ||choosen[f] == DBNull.Value) {
                        if (baseRow != null && baseRow.ContainsKey(f) && baseRow[f] != DBNull.Value) {
                            choosen[f] = baseRow[f];
                        }
                        else {
                            choosen[f] = DBNull.Value;
                        }
                    }
                }
                return choosen;
            }
            if (serviceConfig.ContainsKey(0)) {
                return serviceConfig[0];
            }
            return null;
        }



        DataTable cacheExpense = null;
        DataTable cacheIncome = null;
        Dictionary<int, int> phaseofIdexp = new Dictionary<int, int>();
        Dictionary<int, int> phaseofIdinc = new Dictionary<int, int>();

        public int GetCachedExpensePhase(DataAccess Conn, DataTable Expense, int idexp) {
            QueryHelper QHC = new CQueryHelper();
            QueryHelper QHS = Conn.GetQueryHelper();
            DataRow[] found = Expense.Select(QHC.CmpEq("idexp", idexp));
            if (found.Length == 0) {
                if (phaseofIdexp.ContainsKey(idexp)) return phaseofIdexp[idexp];
                //Non è in memoria---> deve essere sul db
                //Può fare la select direttamente.
                string filtermain = QHS.CmpEq("idexp", idexp);
                //DataTable MainImp = Conn.RUN_SELECT("expensesorted", "*", null, filtermain, null, true);
                object nphase = Conn.DO_READ_VALUE("expense", filtermain, "nphase");
                int phase = CfgFn.GetNoNullInt32(nphase);
                phaseofIdexp[idexp] = phase;
                return phase;
            }
            else {
                return CfgFn.GetNoNullInt32(found[0]["nphase"]);
            }
        }
        public int GetCachedIncomePhase(DataAccess Conn, DataTable Income, int idinc) {
            QueryHelper QHC = new CQueryHelper();
            QueryHelper QHS = Conn.GetQueryHelper();
            DataRow[] found = Income.Select(QHC.CmpEq("idinc", idinc));
            if (found.Length == 0) {
                if (phaseofIdinc.ContainsKey(idinc)) return phaseofIdinc[idinc];
                //Non è in memoria---> deve essere sul db
                //Può fare la select direttamente.
                string filtermain = QHS.CmpEq("idinc", idinc);
                //DataTable MainImp = Conn.RUN_SELECT("expensesorted", "*", null, filtermain, null, true);
                object nphase = Conn.DO_READ_VALUE("income", filtermain, "nphase");
                int phase = CfgFn.GetNoNullInt32(nphase);
                phaseofIdinc[idinc] = phase;
                return phase;
            }
            else {
                return CfgFn.GetNoNullInt32(found[0]["nphase"]);
            }
        }

        public DataRow cachedGetRowPhase(DataTable Mov, object idMov, int nphase, DataAccess Conn) {
            CQueryHelper QHC = new CQueryHelper();
            QueryHelper QHS = Conn.GetQueryHelper();
            string filter = "";
            string field = "";
            DataTable cachedTable;
            if (Mov.TableName == "expense") {
                field = "idexp";
                if (cacheExpense == null) cacheExpense = Conn.CreateTableByName("expense", "*");
                cachedTable = cacheExpense;
            }
            else {
                field = "idinc";
                if (cacheIncome == null) cacheExpense = Conn.CreateTableByName("income", "*");
                cachedTable = cacheExpense;
            }
            string parentField = "parent" + field;

            filter = QHC.CmpEq(field, idMov);

            DataRow[] R = Mov.Select(filter);
            if (R.Length == 0) {
                R = cachedTable.Select(filter);
            }
            if (R.Length == 0) {
                filter = QHS.CmpEq(field, idMov);
                Conn.RUN_SELECT_INTO_TABLE(cachedTable, null, filter, null, true);
                R = cachedTable.Select(QHC.CmpEq(field, idMov));
                if (Mov.TableName == "expense") {
                    phaseofIdexp[CfgFn.GetNoNullInt32(idMov)] = CfgFn.GetNoNullInt32(R[0]["nphase"]);
                }
            }
            if (CfgFn.GetNoNullInt32(R[0]["nphase"]) == nphase) return R[0];

            if (R[0][parentField] == DBNull.Value) return null;
            return cachedGetRowPhase(Mov, R[0][parentField], nphase, Conn);
        }
    }


}
