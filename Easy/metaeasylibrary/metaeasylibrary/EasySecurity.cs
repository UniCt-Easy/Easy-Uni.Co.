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

using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Windows.Forms;
using metadatalibrary;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Collections;
using System.Text;
using System.IO;
using System.Xml;
using System.Security;
using System.Security.Cryptography;
using System.Net;
using System.Threading;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Linq;
#pragma warning disable IDE1006 // Naming Styles


namespace metaeasylibrary {
    public class SecurityConditions {
        Dictionary<string, List<allowdeny>> conditions = new Dictionary<string, List<allowdeny>>();

        private string getKey(string table, string op) {
            return table.ToLower() + "/" + op.ToLower();
        }


        public void Add(string table, string op, allowdeny AD) {
            string key = getKey(table, op);
            List<allowdeny> L;
            if (conditions.ContainsKey(key)) {
                L = conditions[key];
            }
            else {
                L = new List<allowdeny>();
                conditions[key] = L;
            }
            L.Add(AD);

        }


        public List<allowdeny> Get(string table, string op) {
            string key = getKey(table, op);
            if (!conditions.ContainsKey(key)) return new List<allowdeny>();
            return conditions[key];
        }
    }

    public class EasySecurity : DefaultSecurity {
        private QueryHelper qhs;
        private CQueryHelper qhc;
        
        public EasySecurity(IEasyDataAccess conn) : base(conn) {
            qhs = conn.GetQueryHelper();
            qhc = new CQueryHelper();
        }


        public override bool CantUnconditionallyPost(DataTable T, string opKind) {
            bool readOnly = ((IEasyDataAccess) Conn).readOnly;
            if (readOnly && (
                    (opKind.ToUpper() == "U") || (opKind.ToUpper() == "I") || (opKind.ToUpper() == "D")
                )) return true;
            List<allowdeny> Cond = GetCustomGroupOperation(T, opKind);
            if (Cond == null) return false;
            if (Cond.Count == 0) return false;
            foreach (allowdeny C in Cond) {
                if (!C.defaultisdeny) return false;
                if (C.allow.Trim() != "") return false;
            }

            return true;
        }

        public override bool CanPrint(DataRow R) {
            if (R.Table.Columns["reportname"] == null) return true;
            string reportname = R["reportname"].ToString();
            List<allowdeny> CustomGroupOperations = GetCustomGroupOperation(reportname, "P");
            if (CustomGroupOperations.Count > 0)
                return CheckCustomOperation(CustomGroupOperations, R);
            else
                return true;

        }

        /// <summary>
        /// Calcola l'elenco dei gruppi di sicurezza di cui l'utente fa parte. Il risultato è messo in sys["usergrouplist"]
        /// </summary>
        public virtual void CalculateGroupList() {
            if (GetSys("usergrouplist") != null) return;

            string filteruser = qhs.CmpEq("username", GetSys("user"));
            var TBUsers = Conn.RowObject_Select("customuser", "*", filteruser, null, null);

            if ((TBUsers == null) || (TBUsers.Count == 0)) {
                SetSys("usergrouplist", "");
                return;
            }

            object userid = TBUsers[0]["idcustomuser"];
            SetSys("idcustomuser", userid);
            string filtergroups = qhs.CmpEq("idcustomuser", userid);

            var groups = Conn.RowObject_Select("customusergroup", "*", filtergroups, null, null);
            string group = qhs.DistinctVal((from g in groups select g["idcustomgroup"]).ToArray());
            SetSys("usergrouplist", group);
        }

        private static string CustomOperationFilter(List<allowdeny> CustomGroupOperations) {
            if (CustomGroupOperations == null) return null;
            if (CustomGroupOperations.Count == 0) return null;
            CQueryHelper QHC = new CQueryHelper();
            string allowCondition = "";
            bool therewascondition = false;

            foreach (allowdeny GOp in CustomGroupOperations) {
                string allow = GOp.allow;
                string deny = GOp.deny;
                if ((allow != "" || deny != "")) therewascondition = true;


                if (allow.StartsWith("AND(")) allow = allow.Substring(3);
                if (deny.StartsWith("AND(")) deny = deny.Substring(3);

                if (allow.Contains("AND(1=1)")) allow = allow.Replace("AND(1=1)", "");
                if (deny.Contains("AND(1=1)")) deny = deny.Replace("AND(1=1)", "");

                if (allow.Contains("(1=1)AND")) allow = allow.Replace("(1=1)AND", "");
                if (deny.Contains("(1=1)AND")) deny = deny.Replace("(1=1)AND", "");

                bool currdefaultisdeny = GOp.defaultisdeny;

                allowCondition = QHC.AppOr(allowCondition, combineclause(currdefaultisdeny, allow, deny, QHC));

            }

            if ((allowCondition == "") && (therewascondition == true)) {
                return "(1=0)";
            }

            if (allowCondition == "") return null; //true
            return allowCondition;

        }

        public static bool CheckCustomOperation(List<allowdeny> CustomGroupOperations,
            DataRow R) {
            if (CustomGroupOperations == null) return true;
            if (CustomGroupOperations.Count == 0) return true;
            var QHC = new CQueryHelper();
            string pre_allowcondition = "";
            string post_allowcondition = "";
            bool do_precheck;
            bool do_postcheck;

            switch (R.RowState) {
                case DataRowState.Modified:
                    do_precheck = true;
                    do_postcheck = true;
                    break;
                case DataRowState.Deleted:
                    do_precheck = true;
                    do_postcheck = false;
                    break;
                case DataRowState.Added:
                    do_precheck = false;
                    do_postcheck = true;
                    break;
                default:
                    do_precheck = true;
                    do_postcheck = false;
                    break;

            }


            bool defaultisdeny = true; //general default
            bool therewascondition = false;
            foreach (allowdeny GOp in CustomGroupOperations) {
                string allow = GOp.allow;
                string deny = GOp.deny;
                if ((allow != "" || deny != "")) therewascondition = true;
                ;

                string pre_allow = allow;
                string post_allow = allow;
                string pre_deny = deny;
                string post_deny = deny;
                if (allow.StartsWith("&")) {
                    pre_allow = allow.Substring(1);
                    if (do_precheck)
                        post_allow = "";
                    else
                        post_allow = pre_allow;
                }

                if (allow.StartsWith("%")) {
                    post_allow = allow.Substring(1);
                    if (do_postcheck)
                        pre_allow = "";
                    else
                        pre_allow = post_allow;
                }

                if (deny.StartsWith("&")) {
                    pre_deny = deny.Substring(1);
                    if (do_precheck)
                        post_deny = "";
                    else
                        post_deny = pre_deny;
                }

                if (deny.StartsWith("%")) {
                    post_deny = deny.Substring(1);
                    if (do_postcheck)
                        pre_deny = "";
                    else
                        pre_deny = post_deny;
                }

                if (pre_deny.StartsWith("AND(")) pre_deny = pre_deny.Substring(3);
                if (post_deny.StartsWith("AND(")) post_deny = post_deny.Substring(3);
                if (pre_allow.StartsWith("AND(")) pre_allow = pre_allow.Substring(3);
                if (post_allow.StartsWith("AND(")) post_allow = post_allow.Substring(3);

                if (pre_deny.Contains("AND(1=1)")) pre_deny = pre_deny.Replace("AND(1=1)", "");
                if (post_deny.Contains("AND(1=1)")) post_deny = post_deny.Replace("AND(1=1)", "");
                if (pre_allow.Contains("AND(1=1)")) pre_allow = pre_allow.Replace("AND(1=1)", "");
                if (post_allow.Contains("AND(1=1)")) post_allow = post_allow.Replace("AND(1=1)", "");

                if (pre_deny.Contains("(1=1)AND")) pre_deny = pre_deny.Replace("(1=1)AND", "");
                if (post_deny.Contains("(1=1)AND")) post_deny = post_deny.Replace("(1=1)AND", "");
                if (pre_allow.Contains("(1=1)AND")) pre_allow = pre_allow.Replace("(1=1)AND", "");
                if (post_allow.Contains("(1=1)AND")) post_allow = post_allow.Replace("(1=1)AND", "");

                //if (pre_allow == "(1=1)") pre_allow = "";
                //if (pre_deny == "(1=1)") pre_deny = "";
                //if (post_allow == "(1=1)") post_allow = "";
                //if (post_deny == "(1=1)") post_deny = "";

                bool currdefaultisdeny = GOp.defaultisdeny;
                //if  ((currdefaultisdeny ==false) && (deny=="")) defaultisdeny=false;

                if (do_precheck)
                    pre_allowcondition = QHC.AppOr(pre_allowcondition,
                        combineclause(currdefaultisdeny, pre_allow, pre_deny, QHC));

                if (do_postcheck)
                    post_allowcondition = QHC.AppOr(post_allowcondition,
                        combineclause(currdefaultisdeny, post_allow, post_deny, QHC));

            }

            if ((pre_allowcondition == "") && (post_allowcondition == "") && (therewascondition == true)
                && defaultisdeny
            ) {
                return true;
            }

            string currFilter = pre_allowcondition;
            try {
                DataRow[] foundPRE = null;
                DataRow[] foundPOST = null;
                bool okPRE = !do_precheck;
                bool okPOST = !do_postcheck;
                
                switch (R.RowState) {
                    case DataRowState.Modified:
                        foundPRE = R.Table.Select(pre_allowcondition, null, DataViewRowState.ModifiedOriginal);
                        pre_allowcondition = post_allowcondition;
                        foundPOST = R.Table.Select(post_allowcondition, null, DataViewRowState.ModifiedCurrent);
                        break;
                    case DataRowState.Deleted:
                        foundPRE = R.Table.Select(pre_allowcondition, null, DataViewRowState.OriginalRows);
                        break;
                    case DataRowState.Added:
                        pre_allowcondition = post_allowcondition;
                        foundPOST = R.Table.Select(post_allowcondition, null, DataViewRowState.CurrentRows);
                        okPRE = true;
                        break;
                    default:
                        foundPRE = R.Table.Select(pre_allowcondition);
                        okPOST = true;
                        break;

                }

                if (!okPRE) {
                    foreach (DataRow fr in foundPRE) {
                        if (fr == R) okPRE = true;
                    }
                }

                if (!okPOST) {
                    foreach (DataRow fr in foundPOST) {
                        if (fr == R) okPOST = true;
                    }
                }

                return okPOST && okPRE;

            }
            catch (Exception E) {

                ErrorLogger.Logger.logException($"Checking row from table {R.Table.TableName} with filter{currFilter}",E);
            }

            return false;

        }

        /// InheritDoc
        public string GetGroupList() {
            if (GetSys("usergrouplist") == null) return null;
            return GetSys("usergrouplist").ToString();

        }

        public SecurityConditions groupOperations {
			get => GroupOperations;

			set => GroupOperations = value;
		}

		SecurityConditions GroupOperations;

        public override string postingCondition(DataTable t, string opkind_IUDSP) {
            if (((IEasyDataAccess) Conn).readOnly) return "(1=0)";
            List<allowdeny> CustomGroupOperations = GetCustomGroupOperation(t, opkind_IUDSP);
            return CustomOperationFilter(CustomGroupOperations);
        }

        public override bool CanPost(DataRow r) {
            if (model.isSkipSecurity(r.Table)) return true;
            if (((IEasyDataAccess) Conn).readOnly) return false;
            string opkind;
            switch (r.RowState) {
                case DataRowState.Added:
                    opkind = RowChange.short_insert_descr;
                    break;
                case DataRowState.Deleted:
                    opkind = RowChange.short_delete_descr;
                    break;
                default:
                    opkind = RowChange.short_update_descr;
                    break;
            }

            List<allowdeny> CustomGroupOperations = GetCustomGroupOperation(r.Table, opkind);
            if (CustomGroupOperations.Count > 0) {
                if (CheckCustomOperation(CustomGroupOperations, r)) return true;
                return false;

            }

            return true;
        }

        List<allowdeny> GetCustomGroupOperation(DataTable T, string OpCode) {
            if (GroupOperations == null) return new List<allowdeny>();
            string realtable = T.tableForPosting();
            if (OpCode.ToUpper() == "S") realtable = T.TableName;
            return GroupOperations.Get(realtable, OpCode);
            //GetCustomGroupOperation(realtable, OpCode);
        }


        List<allowdeny> GetCustomGroupOperation(string tablename, string OpCode) {
            if (GroupOperations == null) return new List<allowdeny>();

            int handle = metaprofiler.StartTimer("GetCustomGroupOperation");
            try {
                return GroupOperations.Get(tablename, OpCode);
            }
            finally {
                metaprofiler.StopTimer(handle);
            }

            //try {
            //    string grouplist = GetGroupList();
            //    if (string.IsNullOrEmpty(grouplist)) return null;


            //    if (GroupOperations != null) {
            //        string filterC = QHC.AppAnd(QHC.CmpEq("tablename", tablename),
            //        QHC.CmpEq("operation", OpCode),
            //        QHC.FieldInList("idgroup", grouplist));
            //        try {
            //            return GroupOperations.Select(filterC);
            //        }
            //        catch {
            //        }
            //        return null;
            //    }

            //    string filter = QHS.AppAnd(QHS.CmpEq("tablename", tablename),
            //        QHS.CmpEq("operation", OpCode),
            //        QHS.FieldInList("idgroup", grouplist));

            //    DataTable CustomGroupOperation = null;
            //    try {
            //        CustomGroupOperation = RUN_SELECT(
            //            "customgroupoperation", "*", null,
            //            filter,
            //            null, null, true);
            //    }
            //    catch {
            //    }
            //    if (CustomGroupOperation == null) return null;
            //    return CustomGroupOperation.Select();
            //}
            //finally {
            //    metaprofiler.StopTimer(handle);
            //}
        }

        /// <summary>
        /// Must return false if the given row can be selected with "mainselect" in the
        ///  form named edit_type. Should also display to user the reason for which 
        ///  row can't be selected.
        /// </summary>
        /// <param name="R"></param>
        /// <returns></returns>
        override public bool CanSelect(DataRow R) {
            if (R == null) return true;
            List<allowdeny> CustomGroupOperations = GetCustomGroupOperation(R.Table, "S");
            if (CustomGroupOperations.Count > 0)
                return CheckCustomOperation(CustomGroupOperations, R);
            else
                return true;

        }

        public override string SelectCondition(string tablename, bool SQL) {
            List<allowdeny> CustomGroupOperations = GetCustomGroupOperation(tablename, "S");
            if (CustomGroupOperations == null) return null;
            if (CustomGroupOperations.Count == 0) return null;

            QueryHelper QH;
            if (SQL) {
                QH = Conn.GetQueryHelper();
            }
            else {
                QH = new CQueryHelper();
            }

            string pre_allowcondition = "";
            bool do_precheck = true;

            //bool defaultisdeny = true;//general default
            foreach (allowdeny GOp in CustomGroupOperations) {
                string allow = GOp.allow;
                string deny = GOp.deny;

                string pre_allow = allow;
                string pre_deny = deny;

                if (allow.StartsWith("&")) {
                    pre_allow = allow.Substring(1);
                }

                if (allow.StartsWith("%")) {
                    pre_allow = allow.Substring(1);
                }

                if (deny.StartsWith("&")) {
                    pre_deny = deny.Substring(1);
                }

                if (deny.StartsWith("%")) {
                    pre_deny = deny.Substring(1);
                }

                if (pre_deny.StartsWith("AND(")) pre_deny = pre_deny.Substring(3);
                if (pre_allow.StartsWith("AND(")) pre_allow = pre_allow.Substring(3);

                while (pre_deny.Contains("AND(1=1)")) pre_deny = pre_deny.Replace("AND(1=1)", "");
                while (pre_allow.Contains("AND(1=1)")) pre_allow = pre_allow.Replace("AND(1=1)", "");
                while (pre_deny.Contains("(1=1)AND")) pre_deny = pre_deny.Replace("(1=1)AND", "");
                while (pre_allow.Contains("(1=1)AND")) pre_allow = pre_allow.Replace("(1=1)AND", "");


                bool currdefaultisdeny = GOp.defaultisdeny;
                //if ((currdefaultisdeny == false) && (deny == "")) defaultisdeny = false;

                if (do_precheck)
                    pre_allowcondition = QH.AppOr(pre_allowcondition,
                        combineclause(currdefaultisdeny, pre_allow, pre_deny, QH));

            }

            if (pre_allowcondition == "") {
                return null;
            }

            if (SQL) {
                pre_allowcondition = pre_allowcondition.Replace("&", " AND ");
                pre_allowcondition = pre_allowcondition.Replace("|", " OR ");
                pre_allowcondition = pre_allowcondition.Replace("!", " NOT ");
            }

            return pre_allowcondition;
        }


        static string combineclause(bool defaultisdeny, string allow, string deny, QueryHelper QH) {
            //if (defaultisdeny){
            //    if (allow==""){
            //        defaultisdeny=false;
            //    }				
            //}
            //else {
            //    if (deny==""){
            //        defaultisdeny=true;
            //    }
            //}
            if (defaultisdeny) {
                ///Current operation default is DENY (VIETA)
                if (allow != "") {
                    if (allow == "(1=1)") return "";
                    string currclause = QH.DoPar(allow);
                    if (deny != "") currclause = QH.AppAnd(allow, QH.Not(deny));
                    return currclause;
                    //DEFAULT VIETA --> PERMETTI AD  (ALLOW AND (NOT DENY))		
                }

                return "(1=0)";
                //else currclause is a "always-false"
            }
            else {
                ///Current operation default is ALLOW
                if (allow == "(1=1)") return "";
                if (deny != "") {
                    string currclause = QH.Not(deny);
                    if (allow != "") currclause = QH.DoPar(QH.AppOr(currclause, allow));
                    return currclause;
                    //DEFAULT CONSENTI -> PERMETTI A (NOT DENY) OR ALLOW
                }
            }

            return "";


        }

        public override void DeleteAllUnselectable(DataTable T) {

            string condition = SelectCondition(DataAccess.GetTableForReading(T), false);
            if (condition == null) return;


            try {
                DataRow[] foundNotPRE = null;
                foundNotPRE = T.Select("NOT(" + condition + ")");


                foreach (DataRow fr in foundNotPRE) {
                    fr.Delete();
                }

                T.AcceptChanges();

            }
            catch (Exception E) {
                QueryCreator.MarkEvent(E.Message);
            }
        }

        //fasespesamax	-->maxexpensephase
        //faseentratamax-->maxincomephase
        //fasemissione	-->itinerationphase
        //esercizio		-->ayear
        //faseordine	-->mandatephase
        //fasebilanciospesa-->expensefinphase
        //fasecreditoredebitorespesa -->expenseregphase
        //fasefondoricercaspesa	-->expenseresfundphase
        //fasebilpluriennalespesa	--> expensemultiphase
        //fasebilancioentrata-->incomefinphase
        //fasecreditoredebitoreentrata -->incomeregphase
        //fasefondoricercaentrata -->incomeresfundphase
        //fasebilpluriennaleentrata	--> incomemultiphase
        public virtual void RecalcUserEnvironment() {
            int SS = metaprofiler.StartTimer("RecalcUserEnvironment");
            RecalcUserEnvironment(DBNull.Value, DBNull.Value);
            metaprofiler.StopTimer(SS);
        }

        bool getEnvironmentFromSP(object idflowchart, object ndetail) {
            if (GetSys("idcustomuser") == null) SetSys("idcustomuser", DBNull.Value);
            DataSet d = Conn.CallSP("compute_environment",
                new object[] {GetEsercizio(), GetSys("idcustomuser"), idflowchart, ndetail}, true, -1);
            if (d == null) {
                string err = Conn.LastError;
                return false;
            }

            DataTable tSys = d.Tables[0];
            DataRow rSys = tSys.Rows[0];
            foreach (DataColumn c in tSys.Columns) {
                SetSys(c.ColumnName, rSys[c.ColumnName]);
            }

            DataTable tUsr = d.Tables[1];
            foreach (DataRow rUsr in tUsr.Rows) {
                if (rUsr["mustquote"].ToString() == "S") {
                    SetUsr(rUsr["variablename"].ToString(), qhc.quote(rUsr["value"]));
                }
                else {
                    SetUsr(rUsr["variablename"].ToString(), rUsr["value"]);
                }

            }

            string[] syskeys = EnumSysKeys();
            foreach (object o in syskeys) {
                object val = GetSys(o.ToString());
                if (val == null) continue;
                if (val.GetType() != typeof(string)) continue;
                SetSys(o.ToString(), Compile(val as string, true));
                //sys2[o] = sys[o];
            }

            string[] usrkeys = EnumUsrKeys();
            foreach (object o in usrkeys) {
                object val = GetUsr(o.ToString());
                if (val == null) continue;
                if (val.GetType() != typeof(string)) continue;
                SetUsr(o.ToString(), Compile(val as string, true));
                //usr2[o] = usr[o];
            }

            return true;
        }



        /// <summary>
        /// Ricalcola le var. di ambiente per l'utente corrente  sys["idcustomuser"] 
        /// </summary>
        /// <param name="idflowchart">voce dell'organigramma</param>
        /// <param name="ndetail">n. dettaglio dell'associazione flowchartuser</param>
        public void RecalcUserEnvironment(object idflowchart, object ndetail) {
            if (getEnvironmentFromSP(idflowchart, ndetail)) return;
            try {
                if (GetSys("idcustomuser") == null) SetSys("idcustomuser", DBNull.Value);

                SetSys("maxexpensephase", Conn.DO_READ_VALUE("expensephase", null, "MAX(nphase)"));
                if (idflowchart == null || idflowchart == DBNull.Value) {
                    //Se non è stato specificato un ruolo, prende quello di default per l'utente
                    try {
                        //int N = RUN_SELECT_COUNT("sysobjects", QHS.CmpEq("name", "flowchartuser"), false);
                        //Se esiste la tabella flowchartuser - direi che ormai questo controllo non serve più
                        //if (N > 0) {
                        //Cerca una voce di organigramma valida alla data
                        object currdate = Conn.DO_SYS_CMD("select getdate()"); //sys["datacontabile"];
                        string f1 = qhs.AppAnd(qhs.CmpEq("FU.idcustomuser", GetSys("idcustomuser")),
                            qhs.NullOrLe("FU.start", currdate), qhs.NullOrGe("FU.stop", currdate));
                        f1 = qhs.AppAnd(f1, qhs.CmpEq("F.ayear", GetSys("esercizio")));

                        DataTable TT = Conn.SQLRunner(
                            "SELECT F.idflowchart,FU.flagdefault,FU.ndetail from " +
                            "flowchart F join flowchartuser FU ON F.idflowchart=FU.idflowchart " +
                            "WHERE " + f1 ); //+ " ORDER BY FU.flagdefault DESC"

                        if ((TT != null) && (TT.Rows.Count > 0)) {
                            var ordered = TT.Select(null, "flagdefault desc");
                            idflowchart = ordered[0]["idflowchart"];
                            ndetail = ordered[0]["ndetail"];
                        }
                        //}


                    }
                    catch (Exception e) {
                        Conn.MarkException("RecalcUserEnvironment(1)", e);
                    }
                }

                SetSys("idflowchart", idflowchart);
                SetSys("ndetail", ndetail);
                string filtereserc = qhs.CmpEq("ayear", GetSys("esercizio"));

                if (idflowchart != null && idflowchart != DBNull.Value) {
                    SetSys("codeflowchart",
                        Conn.DO_READ_VALUE("flowchart", qhs.CmpEq("idflowchart", idflowchart), "codeflowchart")
                            .ToString());
                }
                else {
                    SetSys("codeflowchart", null);
                }

                //int NN = RUN_SELECT_COUNT("sysobjects", QHS.CmpEq("name", "config"), false);
                //if (NN > 0) {
                DataTable T = Conn.RUN_SELECT("config", "*", null, filtereserc, null, null, true);
                string filterrule = "";
                string Cfilterrule = "";
                if (T != null && T.Rows.Count > 0) {
                    DataRow S = T.Rows[0];
                    if (T.Columns.Contains("previsionkind")) { //Ramo morto
                        if (S["previsionkind"].ToString().ToUpper() == "S") {
                            filterrule = qhs.CmpEq("flag_cash", "S");
                            Cfilterrule = qhc.CmpEq("flag_cash", "S");
                            SetSys("fin_kind", 2);
                        }
                        else {
                            if (S["secprevisionkind"].ToString().ToUpper() == "S") {
                                filterrule = qhs.CmpEq("flag_both", "S");
                                Cfilterrule = qhc.CmpEq("flag_both", "S");
                                SetSys("fin_kind", 3);
                            }
                            else {
                                filterrule = qhs.CmpEq("flag_comp", "S");
                                Cfilterrule = qhc.CmpEq("flag_comp", "S");
                                SetSys("fin_kind", 1);
                            }
                        }
                    }
                    else {
                        object flag = S["fin_kind"];
                        int iflag = 0;
                        if (flag != DBNull.Value) iflag = Convert.ToInt32(flag);
                        SetSys("fin_kind", iflag);
                        if (iflag == 2) {
                            filterrule = qhs.CmpEq("flag_cash", "S");
                            Cfilterrule = qhc.CmpEq("flag_cash", "S");
                        }
                        else {
                            if (iflag == 3) {
                                filterrule = qhs.CmpEq("flag_both", "S");
                                Cfilterrule = qhc.CmpEq("flag_both", "S");
                            }
                            else {
                                //flag==1
                                filterrule = qhs.CmpEq("flag_comp", "S");
                                Cfilterrule = qhc.CmpEq("flag_comp", "S");
                            }
                        }

                    }

                    SetSys("flagcredit", "S");
                    if (T.Columns.Contains("flagcredit")) {
                        if (S["flagcredit"].ToString().ToUpper() == "N") {
                            filterrule = qhs.AppAnd(filterrule, qhs.CmpEq("flag_credit", "N"));
                            Cfilterrule = qhc.AppAnd(Cfilterrule, qhc.CmpEq("flag_credit", "N"));
                            SetSys("flagcredit", "N");
                        }
                    }

                    SetSys("flagproceeds", "S");
                    if (T.Columns.Contains("flagproceeds")) {
                        if (S["flagproceeds"].ToString().ToUpper() == "N") {
                            filterrule = qhs.AppAnd(filterrule, qhs.CmpEq("flag_proceeds", "N"));
                            Cfilterrule = qhc.AppAnd(Cfilterrule, qhc.CmpEq("flag_proceeds", "N"));
                            SetSys("flagproceeds", "N");
                        }
                    }

                    SetSys("filterrule", filterrule);
                    SetSys("Cfilterrule", Cfilterrule);
                    SetSys("incomephase", S["incomephase"]);
                    SetSys("itinerationphase", S["expensephase"]);
                    SetSys("deferredexpensephase", S["deferredexpensephase"]);
                    SetSys("deferredincomephase", S["deferredincomephase"]);
                    SetSys("appropriationphase", S["appropriationphasecode"]);
                    SetSys("assessmentphase", S["assessmentphasecode"]);

                    object IDSOR = S["idsortingkind1"];
                    SetSys("idsortingkind1", IDSOR);
                    object TITLESOR;
                    if (IDSOR != null && IDSOR != DBNull.Value && IDSOR.ToString().ToLower()!="null") {
                        TITLESOR = Conn.DO_READ_VALUE("sortingkind", qhs.CmpEq("idsorkind", IDSOR), "description");
                        SetSys("titlesortingkind1", TITLESOR);
                    }
                    else {
                        SetSys("titlesortingkind1", "");
                    }

                    IDSOR = S["idsortingkind2"];
                    SetSys("idsortingkind2", IDSOR);
                    if (IDSOR != null && IDSOR != DBNull.Value && IDSOR.ToString().ToLower()!="null") {
                        TITLESOR = Conn.DO_READ_VALUE("sortingkind", qhs.CmpEq("idsorkind", IDSOR), "description");
                        SetSys("titlesortingkind2", TITLESOR);
                    }
                    else {
                        SetSys("titlesortingkind2", "");
                    }

                    IDSOR = S["idsortingkind3"];
                    SetSys("idsortingkind3", IDSOR);
                    if (IDSOR != null && IDSOR != DBNull.Value && IDSOR.ToString().ToLower()!="null") {
                        TITLESOR = Conn.DO_READ_VALUE("sortingkind", qhs.CmpEq("idsorkind", IDSOR), "description");
                        SetSys("titlesortingkind3", TITLESOR);
                    }
                    else {
                        SetSys("titlesortingkind3", "");
                    }

                }
                else {
                    ResetConfig();
                }

                DataTable L = Conn.RUN_SELECT("license", "*", null, null, null, null, true);

                if (L != null && L.Rows.Count > 0) {
                    DataRow RowLic = L.Rows[0];
                    SetSys("cfagency", RowLic["cf"]);
                    SetSys("p_ivaagency", RowLic["p_iva"]);
                    SetSys("agency", RowLic["agency"]);
                }

                else {
                    ResetConfig();
                }

                SetSys("maxincomephase", Conn.DO_READ_VALUE("incomephase", null, "MAX(nphase)"));
                try {
                    //NN = RUN_SELECT_COUNT("customobject", QHS.CmpEq("objectname", "uniconfig"), false);
                    //if (NN > 0) {
                    DataTable TT = Conn.RUN_SELECT("uniconfig", "*", null, null, null, null, true);
                    if (TT != null && T.Rows.Count > 0) {
                        DataRow U = TT.Rows[0];
                        SetSys("expensefinphase", U["expensefinphase"]);
                        SetSys("expenseregphase", U["expenseregphase"]);
                        SetSys("incomefinphase", U["incomefinphase"]);
                        SetSys("incomeregphase", U["incomeregphase"]);
                        SetSys("finusablelevel",
                            Conn.DO_READ_VALUE("finlevel", filtereserc + "and(flag & 2)<>0", "min(nlevel)"));
                        SetSys("accountusablelevel",
                            Conn.DO_READ_VALUE("accountlevel", filtereserc + "and (flagusable='S')", "min(nlevel)"));
                        if (T.Columns.Contains("tree_upb_withdescr")) {
                            SetSys("upb_with_description", U["tree_upb_withdescr"].ToString().ToUpper());
                        }

                        if (T.Columns.Contains("tree_fin_withdescr")) {
                            SetSys("fin_with_description", U["tree_fin_withdescr"].ToString().ToUpper());
                        }

                        if (T.Columns.Contains("tree_account_withdescr")) {
                            SetSys("account_with_description", U["tree_account_withdescr"].ToString().ToUpper());
                        }

                        if (T.Columns.Contains("tree_inv_withdescr")) {
                            SetSys("inv_with_description", U["tree_inv_withdescr"].ToString().ToUpper());
                        }

                        SetSys("idsortingkind01", U["idsorkind01"]);
                        SetSys("idsortingkind02", U["idsorkind02"]);
                        SetSys("idsortingkind03", U["idsorkind03"]);
                        SetSys("idsortingkind04", U["idsorkind04"]);
                        SetSys("idsortingkind05", U["idsorkind05"]);

                        foreach (string suffix in new string[] {"01", "02", "03", "04", "05"}) {
                            object IDSORKIND = GetSys("idsortingkind" + suffix);
                            string titlefield = "titlesortingkind" + suffix;
                            if (IDSORKIND != null && IDSORKIND != DBNull.Value) {
                                SetSys(titlefield,
                                    Conn.DO_READ_VALUE("sortingkind", qhs.CmpEq("idsorkind", IDSORKIND),
                                        "description"));
                            }
                            else {
                                SetSys(titlefield, "");
                            }
                        }

                        if (U.Table.Columns.Contains("attachment_max_size_mb")) {
                            if (U["attachment_max_size_mb"] == DBNull.Value) {
                                SetSys("attachment_max_size_mb", 1);
                            } 
							else {
                                SetSys("attachment_max_size_mb", U["attachment_max_size_mb"]);
                            }
                        } 
						else {
                            SetSys("attachment_max_size_mb", 1);
                        }
                    }

                }
                catch (Exception e) {
                    Conn.MarkException("RecalcUserEnvironment(2)", e);
                }

                SetSys("mandatephase", GetSys("itinerationphase"));
                SetSys("estimatephase", GetSys("incomephase"));
                SetSys("invoiceexpensephase", GetSys("maxexpensephase"));
                SetSys("invoiceincomephase", GetSys("maxincomephase"));

                if (GetSys("idcustomuser") != DBNull.Value) {
                    DataTable FU = Conn.RUN_SELECT("flowchartuser", "*", null,
                        qhs.AppAnd(qhs.CmpEq("idflowchart", idflowchart),
                            qhs.CmpEq("ndetail", ndetail),
                            qhs.CmpEq("idcustomuser", GetSys("idcustomuser"))), null, false);
                    if (FU != null && FU.Rows.Count > 0 && FU.Columns.Contains("idsor01")) {
                        DataRow RFU = FU.Rows[0];
                        for (int i = 1; i <= 5; i++) {
                            string fname = "idsor0" + i;
                            if (RFU[fname] == DBNull.Value) {
                                SetSys(fname, 0);
                            }
                            else {
                                SetSys(fname, Convert.ToInt32(RFU[fname]));
                            }
                        }

                    }
                }
                else {
                    SetSys("idsor01", 0);
                    SetSys("idsor02", 0);
                    SetSys("idsor03", 0);
                    SetSys("idsor04", 0);
                    SetSys("idsor05", 0);
                }

                string sql_depmail =
                    "select coalesce(  (select email from sorting where idsor = <%sys[idsor01]%>), " +
                    "  (select email from sorting where idsor = <%sys[idsor02]%>), " +
                    "  (select email from sorting where idsor = <%sys[idsor03]%>), " +
                    "  (select email from sorting where idsor = <%sys[idsor04]%>), " +
                    "  (select email from sorting where idsor = <%sys[idsor05]%>) " +
                    " )";
                for (int nattr = 1; nattr <= 5; nattr++) {
                    object idsorN = GetSys("idsor0" + nattr);
                    if (idsorN == null) idsorN = DBNull.Value;
                    sql_depmail = sql_depmail.Replace("<%sys[idsor0" + nattr + "]%>", qhs.quote(idsorN));
                }

                object emailDefault = Conn.DO_SYS_CMD(sql_depmail, true);
                if (emailDefault == null) emailDefault = DBNull.Value;
                SetSys("defaultdepmail", emailDefault);



                DataTable envVar = Conn.RUN_SELECT("userenvironment", "*", null,
                    qhs.CmpEq("idcustomuser", GetSys("idcustomuser")),
                    null, true);
                foreach (DataRow Var in envVar.Select(qhc.CmpEq("kind", "K"))) {
                    string varname = Var["variablename"].ToString();
                    string valore = Var["value"].ToString();
                    SetUsr(varname, valore);
                    //QueryCreator.MarkEvent("usr[" + varname + "]=" + valore);
                }

                object idcustomuser = GetSys("idcustomuser");

				
                foreach (DataRow Var in envVar.Select(qhc.CmpEq("kind", "S"))) {
                    string opkind = Var["kind"].ToString().ToUpper();
                    string varname = Var["variablename"].ToString();
                    string valore = Var["value"].ToString();
                    string result = null;
                    string error = null;
                    

                    string spname = Compile(valore, true);
                    DataSet dres;
                    if (spname.EndsWith("_withndet")) {
                        dres = Conn.CallSP(spname,
                            new object[] {GetEsercizio(), idcustomuser, idflowchart, ndetail, varname}, -1, out error);
                    }
                    else {
                        dres = Conn.CallSP(spname, new object[] {GetEsercizio(), idcustomuser, idflowchart, varname},
                            -1, out error);
                    }

                    if (error != null) {
                        Conn.openError = true;
                    }

                    if (dres?.Tables.Count > 0) {
                        DataTable tres = dres.Tables[0];
                        string colname = tres.Columns[0].ColumnName;
                        if (tres.Columns.Count > 1 && tres.Rows.Count == 1) {
                            string mustquote = tres.Columns[1].ColumnName;
                            if (tres.Rows[0][mustquote].ToString().ToUpper() == "S") {
                                result = QueryCreator.ColumnValues(tres, null, colname, false);
                            }
                            else {
                                result = tres.Rows[0][colname].ToString();
                            }
                        }
                        else {
                            result = QueryCreator.ColumnValues(tres, null, colname, false);
                        }
                    }

                    if (result != null) {
                        SetUsr(varname, result);
                        //QueryCreator.MarkEvent("usr[" + varname + "]=" + result);
                    }
                }

                foreach (DataRow Var in envVar.Select(qhc.CmpEq("kind", "C"))) {
                    string opkind = Var["kind"].ToString().ToUpper();
                    string varname = Var["variablename"].ToString();
                    string valore = Var["value"].ToString();
                    string result = null;
                    if (idflowchart == DBNull.Value && valore.Contains("sys[idflowchart]")) {
	                    Conn.openError = true;
	                    continue;
                    }
                    string cmd = Compile(valore, true);
                    DataTable RES = Conn.SQLRunner(cmd);
                    if (RES != null) {
                        string colname = RES.Columns[0].ColumnName;
                        result = QueryCreator.ColumnValues(RES, null, colname, false);
                    }

                    if (result != null) {
                        SetUsr(varname, result);
                        //QueryCreator.MarkEvent("usr[" + varname + "]=" + result);
                    }
                }


            }
            catch (Exception EE) {
                Conn.MarkException("RecalcUserEnvironment(3)", EE);
            }

            string[] syskeys = EnumSysKeys();
            foreach (object o in syskeys) {
                object k = GetSys(o.ToString());
                if (k == null) continue;
                if (k.GetType() != typeof(string)) continue;
                SetSys(o.ToString(), Compile(k as string, true));
                //if (!sys[o].Equals(sys2[o])) {
                //    QueryCreator.MarkEvent($"sys[{o}]={sys[o]} sys2[{o}]={sys2[o]}");
                //}
            }

            string[] usrkeys = EnumUsrKeys();
            foreach (object o in usrkeys) {
                object k = GetUsr(o.ToString());
                if (k == null) continue;
                if (k.GetType() != typeof(string)) continue;
                SetUsr(o.ToString(), Compile(k as string, true));
                //if (!usr[o].Equals(usr2[o])) {
                //    QueryCreator.MarkEvent($"usr[{o}]={usr[o]} usr2[{o}]={usr2[o]}");
                //}
            }

        }

        void ResetConfig() {
            SetSys("filterrule", "");
            SetSys("Cfilterrule", "");
            SetSys("incomephase", 0);
            SetSys("itinerationphase", 0);
            SetSys("deferredexpensephase", 0);
            SetSys("deferredincomephase", 0);
            SetSys("appropriationphase", 0);
            SetSys("assessmentphase", 0);
            SetSys("idsortingkind1", "");
            SetSys("idsortingkind2", "");
            SetSys("idsortingkind3", "");
            SetSys("idsor01", "");
            SetSys("idsor02", "");
            SetSys("idsor03", "");
            SetSys("idsor04", "");
            SetSys("idsor05", "");
            SetSys("cfagency", "");
            SetSys("p_ivaagency", "");
            SetSys("agency", "");
        }

        public virtual void ReadAllGroupOperations() {
            int handler = metaprofiler.StartTimer("ReadAllGroupOperations()");
            try {
                string grouplist = GetGroupList();
                string filterGroups = (grouplist == null) || (grouplist == "")
                    ? qhs.IsNull("idgroup")
                    : qhs.FieldInList("idgroup", grouplist);
                var groups = Conn.RUN_SELECT("customgroupoperation", "*", null, filterGroups, null, false);
                GroupOperations = new SecurityConditions();
                foreach (DataRow R in groups.Rows) {
                    string allow = EasyAudits.NormalizeExpression(Compile(R["allowcondition"].ToString(), false));
                    string deny = EasyAudits.NormalizeExpression(Compile(R["denycondition"].ToString(), false));
                    bool defaultisdeny = R["defaultisdeny"].ToString().ToUpper() == "S";
                    GroupOperations.Add(R["tablename"].ToString(), R["operation"].ToString(),
                        new allowdeny(allow, deny, defaultisdeny));
                }
            }
            catch (Exception e) {
                Conn.MarkException("ReadAllGroupOperations()", e);
                metaprofiler.StopTimer(handler);
                return;
            }
            metaprofiler.StopTimer(handler);

        }
    }
}
