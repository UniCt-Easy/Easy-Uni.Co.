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
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;
using System.Collections;

namespace ap_functions {
    public class AP_fun {
        DataAccess Conn;
		DataRow rConfig;
		MetaData MetaServiceRegistry;
		public bool attivo;
		public DataSet D;
		int esercizio;
        CQueryHelper QHC;
        QueryHelper QHS;
        
        public AP_fun(MetaDataDispatcher Disp)
		{
            this.Conn = Disp.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();

            attivo = false;
            esercizio = CfgFn.GetNoNullInt32(Conn.GetSys("esercizio"));
            string filter = QHS.CmpEq("ayear", esercizio);
            DataTable t = Conn.RUN_SELECT("config", "*", null, filter, null, null, true);
            if (t == null) return;
            if (t.Rows.Count == 0) return;
            rConfig = t.Rows[0];
            MetaServiceRegistry = Disp.Get("serviceregistry");
            attivo = true;
            D = new DataSet();
        }

        static string ComposeObjects(object[] o) {
            if (o == null) return null;
            if (o.Length == 0) return null;
            string res = "";
            foreach (object oo in o) {
                if (res != "") res += "§";
                res += oo.ToString();
            }
            return res;
        }

        static string[] DecomposeObjects(string S) {
            if (S == null) return null;
            if (S.Length == 0) return null;
            return S.Split('§');
        }


        static object[] DecodeID(string idrelated) {
            string[] arr1 = DecomposeObjects(idrelated);
            if (arr1 == null) return null;
            object[] obj1 = new object[arr1.Length];
            string pref = arr1[0];
            //if (pref == "inv") {
            //    obj1[0] = "invoice";
            //    obj1[1] = arr1[1];
            //    obj1[2] = Convert.ToInt32(arr1[2]);
            //    obj1[3] = Convert.ToInt32(arr1[3]);
            //}

            if (pref == "cascon") {
                obj1[0] = "casualcontract";
                obj1[1] = Convert.ToInt32(arr1[1]);
                obj1[2] = Convert.ToInt32(arr1[2]);
            }
            if (pref == "payroll") {
                obj1[0] = "payroll";
                obj1[1] = Convert.ToInt32(arr1[1]);
                obj1[2] = Convert.ToInt32(arr1[2]);
                obj1[3] = Convert.ToInt32(arr1[3]);
            }
            if (pref == "wageadd") {
                obj1[0] = "wageaddition";
                obj1[1] = Convert.ToInt32(arr1[1]);
                obj1[2] = Convert.ToInt32(arr1[2]);
            }
            if (pref == "itineration") {
                obj1[0] = "itineration";
                obj1[1] = Convert.ToInt32(arr1[1]);
                obj1[2] = Convert.ToInt32(arr1[2]);
            }
            if (pref == "itineration")
            {
                obj1[0] = "profservice";
                obj1[1] = Convert.ToInt32(arr1[1]);
                obj1[2] = Convert.ToInt32(arr1[2]);
            }
            //if (pref == "pettycashoperation") {
            //    obj1[0] = "pettycashoperation";
            //    obj1[1] = arr1[1];
            //    obj1[2] = Convert.ToInt32(arr1[2]);
            //    obj1[3] = Convert.ToInt32(arr1[3]);
            //}
            //if (pref == "estim") {
            //    obj1[0] = "estimate";
            //    obj1[1] = arr1[1];
            //    obj1[2] = Convert.ToInt32(arr1[2]);
            //    obj1[3] = Convert.ToInt32(arr1[3]);
            //}
            //if (pref == "man") {
            //    obj1[0] = "mandate";
            //    obj1[1] = arr1[1];
            //    obj1[2] = Convert.ToInt32(arr1[2]);
            //    obj1[3] = Convert.ToInt32(arr1[3]);
            //}

            return obj1;

        }
        /// <summary>
        /// Gives an external id for a DataRow. It's necessary R has been SAVED, 
        /// i.e R.DataRowState != Added
        /// </summary>
        /// <param name="R"></param>
        /// <returns>idrelated to put into 'entry' table</returns>
        public static string GetIdForDocument(DataRow R) {
            if (R == null) return null;
            DataRowVersion toConsider = DataRowVersion.Current;
            if (R.RowState == DataRowState.Deleted) toConsider = DataRowVersion.Original;
            string table = R.Table.TableName.ToLower();
            switch (table) {
                //case "invoice":
                //    return ComposeObjects(
                //        new object[]{	"inv",
                //                        R["idinvkind", toConsider],
                //                        R["yinv", toConsider],
                //                        R["ninv", toConsider]
                //                    });
                case "casualcontract":
                    return ComposeObjects(
                        new object[]{	"cascon",
										R["ycon", toConsider],
										R["ncon", toConsider]
									});
                case "payroll":
                    return ComposeObjects(
                        new object[] { "payroll",
										 R["idpayroll", toConsider],
										 R["fiscalyear", toConsider],
										 R["npayroll", toConsider]
									 });
                case "wageaddition":
                    return ComposeObjects(
                        new object[] { "wageadd",
										 R["ycon", toConsider],
										 R["ncon", toConsider]
									 });
                case "itineration":
                    return ComposeObjects(
                        new object[] { "itineration",
										 R["yitineration", toConsider],
										 R["nitineration", toConsider]
									 });
                case "profservice":
                    return ComposeObjects(
                        new object[] { "profservice",
										 R["ycon", toConsider],
										 R["ncon", toConsider]
									 });
                case "parasubcontract":
                    return ComposeObjects(
                        new object[] { "parasubcontract",
										 R["idcon", toConsider]
									 });
            }
            return null;
        }

        string CreateFilter(QueryHelper Q, object[] O, params string[] field) {
            string filter = "";
            for (int i = 0; i < field.Length; i++) {
                string fieldname = field[i];
                filter = Q.AppAnd(filter, Q.CmpEq(fieldname, O[i + 1]));
            }
            return filter;
        }

        public string GetFilterForDocument(string idrelated, out string tablename) {
            tablename = null;
            if (idrelated == null) return null;
            object[] obj1 = DecodeID(idrelated);
            if (obj1 == null) return null;
            if (obj1[0] == null) return null;

            tablename = obj1[0].ToString();
            switch (tablename) {
                //case "invoice": return CreateFilter(QHS, obj1, "idinvkind", "yinv", "ninv");
                case "casualcontract": return CreateFilter(QHS, obj1, "ycon", "ncon");
                case "payroll": return CreateFilter(QHS, obj1, "idpayroll", "fiscalyear", "npayroll");
                case "wageaddition": return CreateFilter(QHS, obj1, "ycon", "ncon");
                case "itineration": return CreateFilter(QHS, obj1, "yitineration", "nitineration");
                case "profservice": return CreateFilter(QHS, obj1, "ycon", "ncon");
                case "parasubcontract": return CreateFilter(QHS, obj1, "idcon");
                //case "pettycashoperation": return CreateFilter(QHS, obj1, "idpettycash", "yoperation", "noperation");
                //case "estimate": return CreateFilter(QHS, obj1, "idestimkind", "yestim", "nestim");
                //case "mandate": return CreateFilter(QHS, obj1, "idmankind", "yman", "nman");
            }
            return null;
        }

        public void EditRelatedDocument(MetaData Meta, DataRow R) {
            try {
                if (R == null) return;
                string idrelated = R["idrelated"].ToString();
                string table;
                string filter = GetFilterForDocument(idrelated, out table);
                if (filter == null) return;
                MetaData Doc = Meta.Dispatcher.Get(table);
                Doc.ContextFilter = filter;
                Form F = null;
                if (Meta.LinkedForm != null) F = Meta.LinkedForm.ParentForm;
                bool result = Doc.Edit(F, "default", false);
                string listtype = Doc.DefaultListType;
                DataRow RR = Doc.SelectOne(listtype, filter, null, null);
                if (RR != null) Doc.SelectRow(RR, listtype);
            }
            catch { }
        }


        public void EditRelatedServiceRegistry(MetaData Meta, DataRow R) {
            EditRelatedServiceRegistry(Meta, GetIdForDocument(R));
        }


        /// <summary>
        /// Opens an entry given the idrelated field. 
        /// </summary>
        /// <param name="Meta"></param>
        /// <param name="idrelated"></param>
        public void EditRelatedServiceRegistry(MetaData Meta, string idrelated) {
            if (idrelated == null) return;
            MetaData ToMeta = Meta.Dispatcher.Get("serviceregistry");
            if (ToMeta == null) return;
            string checkfilter = QHS.CmpEq("idrelated", idrelated);
            ToMeta.ContextFilter = checkfilter;
            Form F = null;
            if (Meta.LinkedForm != null) F = Meta.LinkedForm.ParentForm;
            bool result = ToMeta.Edit(F, "default", false);
            string listtype = ToMeta.DefaultListType;
            DataRow R = ToMeta.SelectOne(listtype, checkfilter, null, null);
            if (R != null) ToMeta.SelectRow(R, listtype);
        }

        /// <summary>
        /// Metodo che visualizza la scrittura tramite la chiamata alla chiave di entry (yservreg, nservreg)
        /// </summary>
        /// <param name="Meta"></param>
        /// <param name="idrelated"></param>
        public void EditRelatedServiceRegistryByKey(MetaData Meta, DataRow rSrvReg) {
            if (rSrvReg == null) return;
            int ysrvreg = CfgFn.GetNoNullInt32(rSrvReg["yservreg"]);
            int nsrvreg = CfgFn.GetNoNullInt32(rSrvReg["nservreg"]);
            if ((ysrvreg == 0) || (nsrvreg == 0)) return;
            MetaData ToMeta = Meta.Dispatcher.Get("serviceregistry");
            if (ToMeta == null) return;
            string checkfilter = QHS.AppAnd(QHS.CmpEq("yservreg", ysrvreg), QHS.CmpEq("nservreg", nsrvreg));
            ToMeta.ContextFilter = checkfilter;
            Form F = null;
            if (Meta.LinkedForm != null) F = Meta.LinkedForm.ParentForm;
            bool result = ToMeta.Edit(F, "default", false);
            string listtype = ToMeta.DefaultListType;
            DataRow R = ToMeta.SelectOne(listtype, checkfilter, null, null);
            if (R != null) ToMeta.SelectRow(R, listtype);
        }

        /// <summary>
        /// Restituisce le scritture associate ad un documento
        /// </summary>
        /// <param name="Conn"></param>
        /// <param name="R"></param>
        /// <returns></returns>
        public void GetEntryForDocument(DataRow R) {
            GetEntryForDocument(GetIdForDocument(R));
        }

        public void GetEntryForDocument(string idrelated) {
            D = new DataSet();
            string filterrelated = QHS.CmpEq("idrelated", idrelated);
            DataTable T = Conn.RUN_SELECT("serviceregistry", "*", null, filterrelated, null, true);
            D.Tables.Add(T);
        }

        public void LinkExistingDocument(MetaData Meta, DataRow MainObject,object idreg) {
            if (MainObject == null) return;
            string idrelated = GetIdForDocument(MainObject);
            if (idrelated == null) return;


            string filter= Meta.Conn.SelectCondition("serviceregistry",true);
             if (MainObject.Table.TableName == "casualcontract") {
                 filter = QHS.AppAnd(filter,QHS.CmpEq("idapcontractkind",1));
                 filter = QHS.AppAnd(filter, QHS.DoPar(QHS.AppOr(QHS.CmpEq("employkind", "C"),  QHS.CmpEq("employkind", "A"))));
            }
                
            if (MainObject.Table.Columns.Contains("ycon")){
                //filter = QHS.AppAnd(filter,QHS.CmpEq("yservreg",MainObject["ycon"]));
            }

            if (MainObject.Table.Columns.Contains("yitineration")) {
                filter = QHS.AppAnd(filter, QHS.CmpEq("yservreg", MainObject["yitineration"]));
            }


            filter = QHS.AppAnd(filter,QHS.CmpEq("idreg",idreg),QHS.IsNull("idrelated"));
            MetaServiceRegistry.FilterLocked = true;
            DataRow R = MetaServiceRegistry.SelectOne("default",filter,null,null);
            if (R == null) return;

            MetaData ToMeta = Meta.Dispatcher.Get("serviceregistry");
            if (ToMeta == null) return;
            string checkfilter = QHS.MCmp(R, new string[] { "yservreg", "nservreg" });
            ToMeta.ContextFilter = checkfilter;
            Form F = null;
            if (Meta.LinkedForm != null) F = Meta.LinkedForm.ParentForm;
            bool result = ToMeta.Edit(F, "default", false);
            string listtype = ToMeta.DefaultListType;
            DataRow RR = ToMeta.SelectOne(listtype, checkfilter, null, null);
            if (RR != null) ToMeta.SelectRow(RR, listtype);
            ToMeta.DS.Tables["serviceregistry"].Rows[0]["idrelated"] = idrelated;






        }

        /// <summary>
        /// Imposta i dati principali della scrittura
        /// </summary>
        /// <param name="description"></param>
        /// <param name="adate"></param>
        /// <param name="Doc"></param>
        /// <param name="DocDate"></param>
        /// <param name="idrelated"></param>
        /// <returns></returns>
        public bool SetSrvRegDefault(MetaData ToMeta, DataRow MainObject, object idreg, object idrelated) {
            DataTable SrvReg = D.Tables["serviceregistry"];
            DataRow R;
            if (SrvReg.Rows.Count == 0) {
                MetaServiceRegistry.SetDefaults(SrvReg);
                R = MetaServiceRegistry.Get_New_Row(null, SrvReg);
            }
            else {
                R = SrvReg.Rows[0];
            }

            DataTable tRegistry = DataAccess.CreateTableByName(Conn, "registry", "surname, forename, birthdate, " +
                "gender, cf, p_iva, title");
            Conn.RUN_SELECT_INTO_TABLE(tRegistry, null, QHS.CmpEq("idreg", idreg), null, true);
            if ((tRegistry == null) || (tRegistry.Rows.Count == 0)) {
                return false;
            }

            string tName = MainObject.Table.TableName;
            string fieldAmount = GetFieldAmountName(tName);
            if (fieldAmount == "") return false;
            string fieldDescription = GetFieldDescriptionName(tName);
            if (fieldDescription == "") return false;

            DataRow currreg = tRegistry.Rows[0];
            ToMeta.PrimaryDataTable.Columns["idreg"].DefaultValue = idreg;
            //Se siamo in una prestazione occasionale impostiamo Consulente e Tipo Rapporto = 2 - PRESTAZIONE OCCASIONALE
            if (MainObject.Table.TableName == "casualcontract") {
                ToMeta.PrimaryDataTable.Columns["idapcontractkind"].DefaultValue = "1";
                ToMeta.PrimaryDataTable.Columns["employkind"].DefaultValue = "C";
            }
            if ((MainObject.Table.TableName == "casualcontract")||(MainObject.Table.TableName == "profservice")) {    
                ToMeta.PrimaryDataTable.Columns["flaghuman"].DefaultValue = "S";
            }
            if (MainObject.Table.Columns.Contains("ycon")){
                ToMeta.PrimaryDataTable.Columns["yservreg"].DefaultValue = MainObject["ycon"];
            }
            else{
                if (MainObject.Table.Columns.Contains("yitineration")){
                    ToMeta.PrimaryDataTable.Columns["yservreg"].DefaultValue = MainObject["yitineration"];
                }
            }

            ToMeta.PrimaryDataTable.Columns["description"].DefaultValue = MainObject[fieldDescription];
            ToMeta.PrimaryDataTable.Columns["start"].DefaultValue = MainObject["start"];
            ToMeta.PrimaryDataTable.Columns["stop"].DefaultValue = MainObject["stop"];
            ToMeta.PrimaryDataTable.Columns["expectedamount"].DefaultValue = MainObject[fieldAmount];
            ToMeta.PrimaryDataTable.Columns["surname"].DefaultValue = currreg["surname"];
            ToMeta.PrimaryDataTable.Columns["forename"].DefaultValue = currreg["forename"];
            ToMeta.PrimaryDataTable.Columns["birthdate"].DefaultValue = currreg["birthdate"];
            ToMeta.PrimaryDataTable.Columns["gender"].DefaultValue = currreg["gender"];
            ToMeta.PrimaryDataTable.Columns["cf"].DefaultValue = currreg["cf"];
            ToMeta.PrimaryDataTable.Columns["p_iva"].DefaultValue = currreg["p_iva"];
            ToMeta.PrimaryDataTable.Columns["idrelated"].DefaultValue = idrelated;
            ToMeta.PrimaryDataTable.Columns["title"].DefaultValue = currreg["title"];
            DateTime dataInizio = (DateTime)MainObject["start"];
            int mese = dataInizio.Month;
            if (mese <= 6){
                ToMeta.PrimaryDataTable.Columns["referencesemester"].DefaultValue = "1";
            }
            else{
                ToMeta.PrimaryDataTable.Columns["referencesemester"].DefaultValue = "2";
            }

            return true;

        }

        public string GetFieldAmountName(string tName) {
            switch (tName) {
                case "wageaddition": {
                        return "feegross";
                    }
                case "profservice": {
                        return "totalcost";
                    }
                case "parasubcontract": {
                        return "grossamount";
                    }
                case "casualcontract": {
                        return "feegross";
                    }
                case "itineration": {
                        return "totalgross";
                    }
                default: {
                        return "";
                    }
            }

        }

        public string GetFieldDescriptionName(string tName) {
            switch (tName) {
                case "wageaddition": {
                        return "description";
                    }
                case "profservice": {
                        return "description";
                    }
                case "parasubcontract": {
                        return "duty";
                    }
                case "casualcontract": {
                        return "description";
                    }
                case "itineration": {
                        return "description";
                    }
                default: {
                        return "";
                    }
            }
        }

        public bool MainSrvRegExists() {
            if (D.Tables["serviceregistry"].Rows.Count == 0) return false;
            return true;
        }

        public void EffettuaScrittura(
            string idepcontext,
            //EP_functions EP, DataSet D, DataTable Account,
            decimal amount, string idacc, object idreg, object idupb,
            DataRow RowForIDSOR) {
            EffettuaScrittura(idepcontext, amount, idacc, idreg, idupb, RowForIDSOR, DBNull.Value);
        }

        public void EffettuaScrittura(
            string idepcontext,
            //EP_functions EP, DataSet D, DataTable Account,
            decimal amount, string idacc, object idreg, object idupb,
                DataRow RowForIDSOR, object idaccmotive) {
            EffettuaScrittura(idepcontext, amount, idacc, idreg, idupb,
                        DBNull.Value, DBNull.Value,
                        RowForIDSOR, idaccmotive);
        }

        public void EffettuaScrittura(
            string idepcontext,
            //EP_functions EP, DataSet D, DataTable Account,
            decimal amount, string idacc, object idreg, object idupb, object start, object stop,
                        DataRow RowForIDSOR, object idaccmotive) {
            if (idreg == null) idreg = DBNull.Value;
            if (idupb == null) idupb = DBNull.Value;
            if (start == null) start = DBNull.Value;
            if (stop == null) stop = DBNull.Value;

            string filteraccount_C = QHC.CmpEq("idacc", idaccmotive);
            string filteraccount = QHS.CmpEq("idacc", idaccmotive);
        }

    }
}