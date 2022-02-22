
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using metaeasylibrary;
using q = metadatalibrary.MetaExpression;

namespace ep_functions {
    /// <summary>
    /// Summary description for budgetfunction.
    /// </summary>
    public class BudgetFunction {
        DataAccess Conn;
        MetaData MetaEpExp;
        MetaData MetaEpExpVar;
        MetaData MetaEpExpYear;
        MetaData MetaEpExpSorting;
        MetaData MetaEpAcc;
        MetaData MetaEpAccVar;
        MetaData MetaEpAccYear;
        MetaData MetaEpAccSorting;
        DataTable Account;
        DataTable AccMotiveDetail;
        public bool attivo;
        public DataSet D;
        int esercizio;
        decimal epannualthreeshold;
        QueryHelper QHS;
        CQueryHelper QHC;
        bool AnnoCommerciale = false;
        MetaDataDispatcher Disp;

        public BudgetFunction(MetaDataDispatcher Disp) {
            this.Conn = Disp.Conn;
            this.Disp = Disp;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();

            attivo = false;
            esercizio = CfgFn.GetNoNullInt32(Conn.GetSys("esercizio"));
            string filter = QHS.CmpEq("ayear", esercizio);
            DataTable t = Conn.RUN_SELECT("config", "*", null, filter, null, null, true);
            DataTable u = Conn.RUN_SELECT("uniconfig", "*", null, null, null, null, true);
            if (t == null) return;
            if (t.Rows.Count == 0) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Non esiste la configurazione dell'anno in corso");
                return;
            }

            if (u == null)
                return;
            if (u.Rows.Count == 0) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Non esiste la configurazione consolidata dell'anno in corso");
                return;
            }

            DataRow rConfig = t.Rows[0];
            DataRow uConfig = u.Rows[0];
            if (u.Columns.Contains("ep360days")) {
                if (uConfig["ep360days"].ToString().ToUpper() == "S")
                    AnnoCommerciale = true;
            }

            epannualthreeshold = CfgFn.GetNoNullDecimal(rConfig["epannualthreeshold"]);
            //if ((rConfig["idsortingkind1"] == DBNull.Value) &&
            //    (rConfig["idsortingkind2"] == DBNull.Value) &&
            //    (rConfig["idsortingkind3"] == DBNull.Value)) return;
            AccMotiveDetail = Conn.CreateTableByName("accmotivedetail", "*");
            Account = Conn.CreateTableByName("account", "*");
            D = CreateDataset(Conn);
            if (rConfig["flagepexp"].ToString() != "S") return;
            MetaEpExp = Disp.Get("epexp");
            MetaEpExpVar = Disp.Get("epexpvar");
            MetaEpExpYear = Disp.Get("epexpyear");
            MetaEpExpSorting = Disp.Get("epexpsorting");
            MetaEpAcc = Disp.Get("epacc");
            MetaEpAccVar = Disp.Get("epaccvar");
            MetaEpAccYear = Disp.Get("epaccyear");
            MetaEpAccSorting = Disp.Get("epaccsorting");
            attivo = true;
        }

        public static string ComposeObjects(object[] o) {
            if (o == null) return null;
            if (o.Length == 0) return null;
            string res = "";
            foreach (object oo in o) {
                if (res != "") res += "§";
                res += oo.ToString();
            }

            return res;
        }

        /// <summary>
        /// Gives an external id for a DataRow. It's necessary R has been SAVED, 
        /// i.e R.DataRowState != Added
        /// </summary>
        /// <param name="R"></param>
        /// <returns>idrelated to put into 'entry' table</returns>
        public static string GetIdForDocument(DataRow R) {
            if (R == null) return null;
            DataRowVersion toConsider = DataRowVersion.Default;
            if (R.RowState == DataRowState.Deleted) toConsider = DataRowVersion.Original;
            string table = R.Table.TableName.ToLower();
            switch (table) {
                case "upbcommessa":
                    return ComposeObjects(
                        new object[] {
                            "upbcommessa",
                            R["idupb", toConsider],
                            R["ayear", toConsider]
                        });
                case "asset":
                case "assetpieceview":
                case "assetview":
                    return ComposeObjects(
                        new object[] {
                            "asset",
                            R["idasset", toConsider],
                            R["idpiece", toConsider]
                        });
                case "assetacquire":
                case "assetacquireview":
                    object idassLoad = R["idassetload", toConsider];
                    if (idassLoad == DBNull.Value) idassLoad = R["idassetload", DataRowVersion.Original];
                    return ComposeObjects(
                        new object[] {
                            "assetload",
                            idassLoad,
                            R["nassetacquire", toConsider]
                        });
                case "assetamortization":
                case "assetamortizationunloadview":
                    object idassUnload = R["idassetunload", toConsider];
                    if (idassUnload == DBNull.Value) {
                        idassUnload = R["idassetunload", DataRowVersion.Original];
                    }

                    return ComposeObjects(
                        new object[] {
                            "assetunload",
                            idassUnload,
                            R["namortization", toConsider]
                        });
                case "casualcontract":
                    return ComposeObjects(
                        new[] {
                            "cascon",
                            R["ycon", toConsider],
                            R["ncon", toConsider]
                        });
                case "grantload":
                    return ComposeObjects(
                        new object[] {
                            "grant",
                            R["yload", toConsider],
                            R["kind", toConsider]

                        });
                case "assetgrant":
                    object ygrant = R["ygrant", toConsider];
                    if (ygrant == DBNull.Value) ygrant = R["ygrant", DataRowVersion.Original];
                    return ComposeObjects(
                        new object[] {
                            "grant",
                            ygrant,
                            "D",
                            R["idasset", toConsider],
                            R["idpiece", toConsider]
                        });
                case "assetload":
                    return ComposeObjects(
                        new object[] {
                            "assetload",
                            R["idassetload", toConsider]
                        });
                case "assetunload":
                    return ComposeObjects(
                        new object[] {
                            "assetunload",
                            R["idassetunload", toConsider]
                        });
                case "assetgrantdetail":
                    return ComposeObjects(
                        new object[] {
                            "grant",
                            R["ydetail", toConsider],
                            "U",
                            R["idasset", toConsider],
                            R["idpiece", toConsider]
                        });
                case "casualcontracttaxbracket":
                    return ComposeObjects(
                        new[] {
                            "cascon",
                            R["ycon", toConsider],
                            R["ncon", toConsider],
                            "RITEN",
                            R["taxcode", toConsider]
                        });
                case "casualcontractrefund":
                    return ComposeObjects(
                        new[] {
                            "cascon",
                            R["ycon", toConsider],
                            R["ncon", toConsider],
                            "SPESA",
                            R["idlinkedrefund", toConsider]
                        });
                case "invoice":
                    return ComposeObjects(
                        new[] {
                            "inv",
                            R["idinvkind", toConsider],
                            R["yinv", toConsider],
                            R["ninv", toConsider]
                        });
                case "invoicedetail":
                    return ComposeObjects(
                        new[] {
                            "inv",
                            R["idinvkind", toConsider],
                            R["yinv", toConsider],
                            R["ninv", toConsider],
                            R["rownum", toConsider]
                        });
                case "itineration":
                    return ComposeObjects(
                        new[] {
                            "itineration",
                            R["iditineration", toConsider]
                        });
                case "itinerationrefund":
                    return ComposeObjects(
                        new[] {
                            "itineration",
                            R["iditineration", toConsider],
                            R["nrefund", toConsider]
                        });
                case "itinerationrefund_balance":
                    return ComposeObjects(
                        new[] {
                            "itineration",
                            R["iditineration", toConsider],
                            R["nrefund", toConsider]
                        });
                case "itinerationrefund_advance":
                    return ComposeObjects(
                        new[] {
                            "itineration",
                            R["iditineration", toConsider],
                            R["nrefund", toConsider]
                        });
                case "itinerationtax":
                    return ComposeObjects(
                        new[] {
                            "itineration",
                            R["iditineration", toConsider],
                            "RITEN",
                            R["taxcode", toConsider]
                        });
                case "estimate":
                    return ComposeObjects(
                        new[] {
                            "estim",
                            R["idestimkind", toConsider],
                            R["yestim", toConsider],
                            R["nestim", toConsider]
                        });
                case "estimatedetail":
                    return ComposeObjects(
                        new[] {
                            "estim",
                            R["idestimkind", toConsider],
                            R["yestim", toConsider],
                            R["nestim", toConsider],
                            R["rownum", toConsider]
                        });
                case "mandate":
                    return ComposeObjects(
                        new[] {
                            "man",
                            R["idmankind", toConsider],
                            R["yman", toConsider],
                            R["nman", toConsider]
                        });
                case "mandatedetail":
                    return ComposeObjects(
                        new[] {
                            "man",
                            R["idmankind", toConsider],
                            R["yman", toConsider],
                            R["nman", toConsider],
                            R["rownum", toConsider]
                        });
                case "payroll":
                    return ComposeObjects(
                        new[] {
                            "payroll",
                            R["idpayroll", toConsider]
                        });
                case "payrolltax":
                    return ComposeObjects(
                        new[] {
                            "payroll",
                            R["idpayroll", toConsider],
                            "RITEN",
                            R["taxcode", toConsider]
                        });
                case "profservice":
                    return ComposeObjects(
                        new[] {
                            "profservice",
                            R["ycon", toConsider],
                            R["ncon", toConsider]
                        });
                case "profservicetax":
                    return ComposeObjects(
                        new[] {
                            "profservice",
                            R["ycon", toConsider],
                            R["ncon", toConsider],
                            "RITEN",
                            R["taxcode", toConsider]
                        });
                case "profservicerefund":
                    return ComposeObjects(
                        new[] {
                            "profservice",
                            R["ycon", toConsider],
                            R["ncon", toConsider],
                            "SPESA",
                            R["idlinkedrefund", toConsider]
                        });
                case "wageaddition":
                    return ComposeObjects(
                        new[] {
                            "wageadd",
                            R["ycon", toConsider],
                            R["ncon", toConsider]
                        });
                case "wageadditiontax":
                    return ComposeObjects(
                        new[] {
                            "wageadd",
                            R["ycon", toConsider],
                            R["ncon", toConsider],
                            "RITEN",
                            R["taxcode", toConsider]
                        });
                case "pettycashoperation":
                    return ComposeObjects(
                        new[] {
                            "pettycashoperation",
                            R["idpettycash", toConsider],
                            R["yoperation", toConsider],
                            R["noperation", toConsider]
                        });
                case "csa_import":
                    return ComposeObjects(
                        new[] {
                            "csaimport",
                            R["idcsa_import", toConsider]
                        });
                case "csa_importriep":
                    return ComposeObjects(
                        new[] {
                            "csaimport",
                            R["idcsa_import", toConsider],
                            "RIEP",
                            R["idriep", toConsider]
                        });
                case "csa_importriep_partition":
                case "csa_importriep_partitionview":
                    return ComposeObjects(
                        new[] {
                            "csaimport",
                            R["idcsa_import", toConsider],
                            "RIEP",
                            R["idriep", toConsider],
                            R["ndetail", toConsider]
                        });
                case "csa_importver":
                    return ComposeObjects(
                        new[] {
                            "csaimport",
                            R["idcsa_import", toConsider],
                            "VER",
                            R["idver", toConsider]
                        });
                case "csa_importver_partition":
                case "csa_importver_partitionview":
                    return ComposeObjects(
                        new[] {
                            "csaimport",
                            R["idcsa_import", toConsider],
                            "VER",
                            R["idver", toConsider],
                            R["ndetail", toConsider]
                        });
                case "provision":
                    return ComposeObjects(new[] {"provision", R["idprovision", toConsider]});
                case "provisiondetail":
                    return ComposeObjects(new[] {"provision", R["idprovision"], R["rownum"]});
                case "ivapay":
                    return ComposeObjects(
                        new[] {
                            "ivapay",
                            R["yivapay", toConsider],
                            R["nivapay", toConsider]
                        });
            }

            return null;
        }

        public void EditRelatedEpExpLike(MetaData Meta, string idrelated) {
            EditRelatedEpExpLike(Meta, idrelated, 0);
        }

        public void EditRelatedEpExpLike(MetaData Meta, string idrelated, int nphase) {
            EditRelatedEpMovLike("epexp", Meta, idrelated, nphase);
        }

        public void EditRelatedEpMovLike(string table, MetaData Meta, string idrelated, int nphase) {
            EditRelatedEpMovLike(table, Meta, idrelated, nphase, false);
        }

        /// <summary>
        /// Visualizza un elenco ove necessario e permette l'editing degli impegni di budget collegati ad un documento
        /// </summary>
        /// <param name="Meta"></param>
        /// <param name="idrelated"></param>
        /// <param name="nphase"></param>
        public bool EditRelatedEpMovLike(string table, MetaData Meta, string idrelated, int nphase, bool silent) {
            //string prefix = (!idrelated.EndsWith("%")) ? idrelated + "%" : idrelated;
            string filter = getDocChildCondition(QHS, idrelated);
            if (nphase != 0) filter = QHS.AppAnd(filter, QHS.CmpEq("nphase", nphase),QHS.CmpEq("ayear",esercizio));
            // QHS.AppAnd(QHS.CmpEq("nphase", nphase), QHS.Like("idrelated", prefix));
            int rowsfound = Conn.RUN_SELECT_COUNT(table+"view", filter, true);
            if (rowsfound == 0) {
                if (!silent) {
                    if (table == "epexp") {
                        QueryCreator.ShowError(null, "Nessun impegno di budget trovato", "Filtro applicato: " + filter);
                    }
                    else {
                        QueryCreator.ShowError(null, "Nessun accertamento di budget trovato","Filtro applicato: " + filter);
                    }
                }
                return false;
            }

            MetaData ToMeta = Meta.Dispatcher.Get(table);
            if (ToMeta == null) return false;
            ToMeta.ContextFilter = filter;
            bool result = ToMeta.Edit(Meta.linkedForm.ParentForm, "default", false);
            string listtype = "default";
            DataRow R = ToMeta.SelectOne(listtype, filter, null, null);
            if (R != null) {
                ToMeta.SelectRow(R, listtype);
            }

            return true;
        }


        public void EditRelatedEpExp(MetaData Meta, DataRow R, int nphase) {
            EditRelatedEpExp(Meta, GetIdForDocument(R), nphase);
        }

        public void EditRelatedEpExp(MetaData Meta, DataRow R) {
            EditRelatedEpExp(Meta, GetIdForDocument(R), 2);
        }

        public void EditRelatedEpExp(MetaData Meta, string idrelated) {
            EditRelatedEpExp(Meta, idrelated, 2);
        }

        static string CreateFilter(QueryHelper Q, object[] O, params string[] field) {
            string filter = "";
            for (int i = 0; i < field.Length; i++) {
                string fieldname = field[i];
                filter = Q.AppAnd(filter, Q.CmpEq(fieldname, O[i + 1]));
            }

            return filter;
        }

        static string[] DecomposeObjects(string S) {
            if (S == null) return null;
            return S.Length == 0 ? null : S.Split('§');
        }

        public static object[] decodeID(string idrelated) {
            string[] arr1 = DecomposeObjects(idrelated);
            if (arr1 == null) return null;
            object[] obj1 = new object[arr1.Length];
            string pref = arr1[0];
            if (pref == "assetunload" && arr1.Length == 4) {
                obj1[0] = "assetunload";
                obj1[1] = arr1[1]; //idassetunloadkind  
                obj1[2] = Convert.ToInt32(arr1[2]); //yassetunload
                obj1[3] = Convert.ToInt32(arr1[3]); //nassetunload
            }

            if (pref == "assetunload" && arr1.Length == 2) {
                obj1[0] = "assetunload";
                obj1[1] = arr1[1]; //idassetunload 
            }

            if (pref == "assetunload" && arr1.Length == 3) {
                obj1[0] = "assetamortization";
                obj1[1] = arr1[2]; //namortization 
            }

            if (pref == "assetload" && arr1.Length == 3) {
                obj1[0] = "assetacquire";
                obj1[1] = Convert.ToInt32(arr1[2]); //idassetload                
            }

            if (pref == "assetload" && arr1.Length != 3) {
                obj1[0] = "assetload";
                obj1[1] = Convert.ToInt32(arr1[1]); //idassetload               
            }

            if (pref == "grant" && arr1.Length == 3) {
                obj1[0] = "grantload";
                obj1[1] = Convert.ToInt32(arr1[1]); //yload
                obj1[2] = arr1[2]; //kind
            }

            if (pref == "upbcommessa" && arr1.Length >= 3) {
                obj1[0] = "upbcommessa";
                obj1[1] = arr1[1]; //idupb
                obj1[2] = Convert.ToInt32(arr1[2]); //anno
            }

            if (pref == "grant" && arr1.Length == 5 && arr1[2].ToString() == "D") {
                obj1[0] = "assetgrant";
                obj1[1] = Convert.ToInt32(arr1[1]); //ygrant
                obj1[2] = Convert.ToInt32(arr1[3]); //idasset
                obj1[3] = Convert.ToInt32(arr1[4]); //idpiece
            }

            if (pref == "grant" && arr1.Length == 5 && arr1[2].ToString() == "U") {
                obj1[0] = "assetgrantdetail";
                obj1[1] = Convert.ToInt32(arr1[1]); //ygrant
                obj1[2] = Convert.ToInt32(arr1[3]); //idasset
                obj1[3] = Convert.ToInt32(arr1[4]); //idpiece
            }

            if (pref == "cascon") {
                obj1[0] = "casualcontract";
                obj1[1] = Convert.ToInt32(arr1[1]);
                obj1[2] = Convert.ToInt32(arr1[2]);
            }

            if (pref == "inv" && arr1.Length == 4) {
                obj1[0] = "invoice";
                obj1[1] = arr1[1];
                obj1[2] = Convert.ToInt32(arr1[2]);
                obj1[3] = Convert.ToInt32(arr1[3]);
            }

            if (pref == "invdetail" || (pref == "inv" && arr1.Length == 5)) {
                obj1[0] = "invoicedetail";
                obj1[1] = arr1[1];
                obj1[2] = Convert.ToInt32(arr1[2]);
                obj1[3] = Convert.ToInt32(arr1[3]);
                obj1[4] = Convert.ToInt32(arr1[4]);
            }

            if (pref == "itineration") {
                obj1[0] = "itineration";
                obj1[1] = Convert.ToInt32(arr1[1]);
            }

            if (pref == "estim" && arr1.Length == 4) {
                obj1[0] = "estimate";
                obj1[1] = arr1[1];
                obj1[2] = Convert.ToInt32(arr1[2]);
                obj1[3] = Convert.ToInt32(arr1[3]);
            }

            if (pref == "estimdet" || (pref == "estim" && arr1.Length == 5)) {
                obj1[0] = "estimatedetail";
                obj1[1] = arr1[1];
                obj1[2] = Convert.ToInt32(arr1[2]);
                obj1[3] = Convert.ToInt32(arr1[3]);
                obj1[4] = Convert.ToInt32(arr1[4]);
            }

            if ((pref == "mandatedetail" || pref == "man") && arr1.Length == 4) {
                obj1[0] = "mandate";
                obj1[1] = arr1[1];
                obj1[2] = Convert.ToInt32(arr1[2]);
                obj1[3] = Convert.ToInt32(arr1[3]);
            }

            if (pref == "mandatedetail" || (pref == "man" && arr1.Length == 5)) {
                obj1[0] = "mandatedetail";
                obj1[1] = arr1[1];
                obj1[2] = Convert.ToInt32(arr1[2]);
                obj1[3] = Convert.ToInt32(arr1[3]);
                obj1[4] = Convert.ToInt32(arr1[4]);
            }

            if (pref == "payroll") {
                obj1[0] = "payroll";
                obj1[1] = Convert.ToInt32(arr1[1]);
            }

            if (pref == "profservice") {
                obj1[0] = "profservice";
                obj1[1] = Convert.ToInt32(arr1[1]);
                obj1[2] = Convert.ToInt32(arr1[2]);
            }

            if (pref == "wageadd") {
                obj1[0] = "wageaddition";
                obj1[1] = Convert.ToInt32(arr1[1]);
                obj1[2] = Convert.ToInt32(arr1[2]);
            }

            if (pref == "pettycashoperation") {
                obj1[0] = "pettycashoperation";
                obj1[1] = arr1[1];
                obj1[2] = Convert.ToInt32(arr1[2]);
                obj1[3] = Convert.ToInt32(arr1[3]);
            }

            if (pref == "csaimport") {
                obj1[0] = "csa_import";
                obj1[1] = Convert.ToInt32(arr1[1]);
            }

            return obj1;
        }

        public static string GetFilterForDocument(QueryHelper QHS, string idrelated, out string tablename) {
            tablename = null;
            if (idrelated == null) return null;
            object[] obj1 = decodeID(idrelated);
            if (obj1 == null) return null;
            if (obj1[0] == null) return null;
            tablename = obj1[0].ToString();
            string myTable = tablename;
            if (tablename == "csa_import.debit") {
                tablename = "csa_import";
            }

            switch (myTable) {
                case "grantload":
                    return CreateFilter(QHS, obj1, "yload", "kind");
                case "assetgrant":
                    return CreateFilter(QHS, obj1, "ygrant", "idasset", "idpiece");
                case "assetacquire":
                    return CreateFilter(QHS, obj1, "nassetacquire");
                case "upbcommessa":
                    return CreateFilter(QHS, obj1, "idupb", "ayear");

                case "assetunload":
                    return CreateFilter(QHS, obj1, "idassetunload");
                case "assetamortization":
                    return CreateFilter(QHS, obj1, "namortization");
                case "assetload":
                    return CreateFilter(QHS, obj1, "idassetload");
                case "assetgrantdetail":
                    return CreateFilter(QHS, obj1, "ydetail", "idasset", "idpiece");
                case "invoice":
                    return CreateFilter(QHS, obj1, "idinvkind", "yinv", "ninv");
                case "invoicedetail":
                    return CreateFilter(QHS, obj1, "idinvkind", "yinv", "ninv", "rownum");
                case "casualcontract":
                    return CreateFilter(QHS, obj1, "ycon", "ncon");
                case "payroll":
                    return CreateFilter(QHS, obj1, "idpayroll");
                case "wageaddition":
                    return CreateFilter(QHS, obj1, "ycon", "ncon");
                case "itineration":
                    return CreateFilter(QHS, obj1, "iditineration");
                case "profservice":
                    return CreateFilter(QHS, obj1, "ycon", "ncon");
                case "pettycashoperation":
                    return CreateFilter(QHS, obj1, "idpettycash", "yoperation", "noperation");
                case "estimate":
                    return CreateFilter(QHS, obj1, "idestimkind", "yestim", "nestim");
                case "estimatedetail":
                    return CreateFilter(QHS, obj1, "idestimkind", "yestim", "nestim", "rownum");
                case "mandate":
                    return CreateFilter(QHS, obj1, "idmankind", "yman", "nman");
                case "mandatedetail":
                    return CreateFilter(QHS, obj1, "idmankind", "yman", "nman", "rownum");
                case "csa_import":
                    return CreateFilter(QHS, obj1, "idcsa_import");
                case "csa_import.debit":
                    return CreateFilter(QHS, obj1, "idcsa_import");
            }

            return null;
        }

        public static void EditRelatedDocument(MetaData meta, DataRow R) {
            try {
                if (R == null) return;
                QueryHelper QHS = meta.Conn.GetQueryHelper();
                string idrelated = R["idrelated"].ToString();
                string table;
                string filter = GetFilterForDocument(QHS, idrelated, out table);
                if (filter == null) return;
                MetaData Doc = meta.Dispatcher.Get(table);
                Doc.ContextFilter = filter;
                Form F = null;
                if (meta.linkedForm != null) F = meta.linkedForm.ParentForm;
                bool result = Doc.Edit(F, "default", false);
                string listtype = Doc.DefaultListType;
                DataRow RR = Doc.SelectOne(listtype, filter, null, null);
                if (RR != null) Doc.SelectRow(RR, listtype);
            }
            catch (Exception e) {
            }
        }



        public static string getDocChildCondition(QueryHelper q, string idrelated) {
            return q.DoPar(q.AppOr(q.Like("idrelated", idrelated + "§%"), q.CmpEq("idrelated", idrelated)));
            //"((idrelated LIKE " + q.quote(idrelated + "§%") + ")" + " OR(idrelated = " + q.quote(idrelated) + "))";
        }

        public static string getDocChildCondition(string fieldBase, QueryHelper q, string idrelated) {
            return q.DoPar(q.AppOr(q.Like(fieldBase, idrelated + "§%"), q.CmpEq(fieldBase, idrelated)));
            //"((idrelated LIKE " + q.quote(idrelated + "§%") + ")" + " OR(idrelated = " + q.quote(idrelated) + "))";
        }

        /// <summary>
        /// Opens an entry given the idrelated field. 
        /// </summary>
        /// <param name="Meta"></param>
        /// <param name="idrelated"></param>
        /// <param name="nphase"></param>
        public void EditRelatedEpExp(MetaData Meta, string idrelated, int nphase) {
            EditRelatedEp("epexp", Meta, idrelated, nphase);
        }


        public void EditRelatedEp(string kind, MetaData Meta, string idrelated, int nphase) {
            if (idrelated == null) return;
            MetaData ToMeta = Meta.Dispatcher.Get(kind);
            if (ToMeta == null) return;
            string filterRelated = getDocChildCondition(QHS, idrelated);

            string checkfilter = QHS.AppAnd(filterRelated, QHS.CmpEq("nphase", nphase));
            ToMeta.ContextFilter = checkfilter;
            Form F = null;
            if (Meta.linkedForm != null) F = Meta.linkedForm.ParentForm;
            bool result = ToMeta.Edit(F, "default", false);
            string listtype = ToMeta.DefaultListType;
            DataRow R = ToMeta.SelectOne(listtype, checkfilter, null, null);
            if (R != null) ToMeta.SelectRow(R, listtype);
        }


        /// <summary>
        /// Legge nel Dataset D le righe di epexp,epexpyear ed epexpsorting correlate all'idrelated,usato a fini della modifica automatica
        /// </summary>
        /// <param name="Conn"></param>
        /// <param name="R"></param>
        /// <returns></returns>
        public void GetEpExpForDocument(DataRow R) {
            GetEpExpForDocument(GetIdForDocument(R));
        }



        /// <summary>
        ///  Legge nel Dataset D le righe di epexp,epexpyear ed epexpsorting correlate all'idrelated,usato a fini della modifica automatica
        /// </summary>
        /// <param name="R"></param>
        /// <param name="nphase"></param>
        public void GetEpExpForDocument(DataRow R, int nphase) {
            GetEpExpForDocument(GetIdForDocument(R), nphase);
        }

        /// <summary>
        ///  Legge nel Dataset D le righe di epexp,epexpyear ed epexpsorting correlate all'idrelated,usato a fini della modifica automatica
        /// </summary>
        /// <param name="idrelated"></param>
        public void GetEpExpForDocument(string idrelated) {
            GetEpExpForDocument(idrelated, 0);
        }

        public bool DeleteAll(ep_poster posting) {

            foreach (DataRow rEpExpSorting in D.Tables["epexpsorting"].Rows) {
                rEpExpSorting.Delete();
            }

            foreach (DataRow rEpExpYear in D.Tables["epexpyear"].Rows) {
                rEpExpYear.Delete();
            }

            foreach (DataRow rEpExpVar in D.Tables["epexpvar"].Rows) {
                rEpExpVar.Delete();
            }

            foreach (DataRow rEpExp in D.Tables["epexp"].Rows) {
                rEpExp.Delete();
            }

            foreach (DataRow rEpExpSorting in D.Tables["epaccsorting"].Rows) {
                rEpExpSorting.Delete();
            }

            foreach (DataRow rEpExpYear in D.Tables["epaccyear"].Rows) {
                rEpExpYear.Delete();
            }

            foreach (DataRow rEpExpVar in D.Tables["epaccvar"].Rows) {
                rEpExpVar.Delete();
            }

            foreach (DataRow rEpExp in D.Tables["epacc"].Rows) {
                rEpExp.Delete();
            }
            
            ///TODO:  usare classe innerPosting
            
            if (posting != null) {
                MetaData MetaEpExp = Disp.Get(metaNameForPosting);
                var post = MetaEpExp.Get_PostData();
                post.autoIgnore = autoIgnore;
                return posting.saveData(D, post);
            }
            else {
                MetaData MetaEpExp = Disp.Get(metaNameForPosting);
                PostData Post = MetaEpExp.Get_PostData();
                Post.autoIgnore = autoIgnore;
                Post.InitClass(D, Conn);
                if (silent) {
                    var res = Post.DO_POST_SERVICE();
                    return res.Count == 0;
                }
                else {
                    if (!Post.DO_POST()) {
                        MetaFactory.factory.getSingleton<IMessageShower>().Show("Errore durante la cancellazione degli impegni di budget", "Errore");
                        return false;
                    }
                }
            }



            
          

            return true;
        }

        public bool silent = false;
        public bool autoIgnore = false;
        public string metaNameForPosting = "epexp";

        public static DataSet CreateDataset(IDataAccess Conn) {
            DataSet D = new DataSet();
            DataTable TEpExp = Conn.CreateTableByName("epexp", "*");
            D.Tables.Add(TEpExp);
            D.Relations.Add("epexpepexp", TEpExp.Columns["idepexp"], TEpExp.Columns["paridepexp"], false);
            DataTable TT2 = Conn.CreateTableByName("epexpsorting", "*");
            DataTable TT3 = Conn.CreateTableByName("epexpyear", "*");
            DataTable TT4 = Conn.CreateTableByName("epexpvar", "*");
            D.Tables.Add(TT2);
            D.Tables.Add(TT3);
            D.Tables.Add(TT4);


            DataTable TEpAcc = Conn.CreateTableByName("epacc", "*");
            D.Tables.Add(TEpAcc);
            D.Relations.Add("epaccepacc", TEpAcc.Columns["idepacc"], TEpAcc.Columns["paridepacc"], false);
            DataTable TT2a = Conn.CreateTableByName("epaccsorting", "*");
            DataTable TT3a = Conn.CreateTableByName("epaccyear", "*");
            DataTable TT4a = Conn.CreateTableByName("epaccvar", "*");
            D.Tables.Add(TT2a);
            D.Tables.Add(TT3a);
            D.Tables.Add(TT4a);


            D.Relations.Add("epexpepexpsorting",
                new DataColumn[] {TEpExp.Columns["idepexp"]},
                new DataColumn[] {TT2.Columns["idepexp"]}, false);
            D.Relations.Add("epexpepexpyear",
                new DataColumn[] {TEpExp.Columns["idepexp"]},
                new DataColumn[] {TT3.Columns["idepexp"]}, false);
            D.Relations.Add("epexpepexpvar",
                new DataColumn[] {TEpExp.Columns["idepexp"]},
                new DataColumn[] {TT4.Columns["idepexp"]}, false);


            D.Relations.Add("epaccepaccsorting",
                new DataColumn[] {TEpAcc.Columns["idepacc"]},
                new DataColumn[] {TT2a.Columns["idepacc"]}, false);
            D.Relations.Add("epaccepaccyear",
                new DataColumn[] {TEpAcc.Columns["idepacc"]},
                new DataColumn[] {TT3a.Columns["idepacc"]}, false);
            D.Relations.Add("epaccepaccvar",
                new DataColumn[] {TEpAcc.Columns["idepacc"]},
                new DataColumn[] {TT4a.Columns["idepacc"]}, false);

            DataTable tEntry = Conn.CreateTableByName("entry", "*");
            DataTable tEntryDetail = Conn.CreateTableByName("entrydetail", "*");
            D.Tables.Add(tEntry);
            D.Tables.Add(tEntryDetail);

            D.Relations.Add("entryentrydetail",
                new DataColumn[] {tEntry.Columns["yentry"], tEntry.Columns["nentry"]},
                new DataColumn[] {tEntryDetail.Columns["yentry"], tEntryDetail.Columns["nentry"]}, false
            );
            D.Relations.Add("epexpentrydetail",
                new DataColumn[] {TEpExp.Columns["idepexp"]},
                new DataColumn[] {tEntryDetail.Columns["idepexp"]}, false
            );
            D.Relations.Add("epaccentrydetail",
                new DataColumn[] {TEpAcc.Columns["idepacc"]},
                new DataColumn[] {tEntryDetail.Columns["idepacc"]}, false
            );
            DataTable accruals = Conn.CreateTableByName("entrydetailaccrual", "*");
            D.Tables.Add(accruals);
            D.Relations.Add("entrydetailentrydetailaccrual",
                new DataColumn[]
                    {tEntryDetail.Columns["yentry"], tEntryDetail.Columns["nentry"], tEntryDetail.Columns["ndetail"]},
                new DataColumn[] {accruals.Columns["yentry"], accruals.Columns["nentry"], accruals.Columns["ndetail"]},
                false);


            foreach (DataTable T in D.Tables) {
                RowChange.SetOptimized(T, true);
            }

            return D;

        }

        /// <summary>
        /// Legge nel Dataset D le righe dal DB di epexp,epexpyear ed epexpsorting correlate all'idrelated, usato a fini della modifica automatica
        /// </summary>
        /// <param name="idrelated"></param>
        /// <param name="nPhase">fase degli impegni da caricare</param>
        public void GetEpExpForDocument(string idrelated, int nPhase) {
            getEpMovForDocument("epexp", idrelated, nPhase);
        }

        /// <summary>
        /// Returns true if something has been found
        /// </summary>
        /// <param name="table"></param>
        /// <param name="idrelated"></param>
        /// <param name="nPhase"></param>
        /// <returns></returns>
        public bool getEpMovForDocument(string table, string idrelated, int nPhase) {

	        if (string.IsNullOrEmpty(idrelated)) return false;

            string filterOriginal = getDocChildCondition(QHS, idrelated);

            string filterrelated = filterOriginal;
            //"((idrelated LIKE " + QHS.quote(idrelated + "§%") + ")"+ " OR(idrelated = " + QHS.quote(idrelated) + "))";
            filterrelated = QHS.AppAnd(filterrelated, QHS.CmpEq("ayear", esercizio));
            if (nPhase > 0) filterrelated = QHS.AppAnd(filterrelated, QHS.CmpEq("nphase", nPhase));
            DataTable t0 = Conn.RUN_SELECT(table + "view", "*", null, filterrelated, null, true);
            string idmov = "id" + table;
            if (t0.Rows.Count > 0) {
                if (t0.Rows.Count > 1) {
                    Conn.RUN_SELECT_INTO_TABLE(D.Tables[table], null,
                        $"( {idmov} in (select {idmov} from {table + "view"} where {filterrelated}))", null, false);
                }
                else {
                    foreach (DataRow r in t0.Rows) {
                        Conn.RUN_SELECT_INTO_TABLE(D.Tables[table], null, QHS.CmpEq(idmov, r[idmov]), null, false);
                    }
                }

            }

            if (t0.Rows.Count == 0) {
                return false;
            }

            DataTable tsort = D.Tables[table + "sorting"];
            DataTable tyear = D.Tables[table + "year"];
            DataTable tvar = D.Tables[table + "var"];
            DataTable tEntryDetail = D.Tables["entrydetail"];

            string filterAlias = getDocChildCondition(table + ".idrelated", QHS, idrelated);
            string filterAliasPhase =
                nPhase > 0 ? QHS.AppAnd(filterAlias, QHS.CmpEq(table + ".nphase", nPhase)) : filterAlias;

            string querySortColumns = DataTools.aliasColumns(tsort, tsort.TableName);
            string querySort = "select " + querySortColumns +
                               " from " + table +
                               " join " + tsort.TableName + " on " + tsort.TableName + "." + idmov + " = " + table +
                               "." + idmov +
                               " and " + tsort.TableName + ".ayear = " + QHS.quote(esercizio) +
                               " and " + filterAliasPhase;
            DataTools.MergeRows(Conn, tsort, querySort);


            string queryVarColumns = DataTools.aliasColumns(tvar, tvar.TableName);
            string queryVar = "select " + queryVarColumns +
                              " from " + table +
                              " join " + tvar.TableName + " on " + tvar.TableName + "." + idmov + " = " +
                              table + "." + idmov +
                              " and " + tvar.TableName + ".yvar = " + QHS.quote(esercizio) +
                              " and " + filterAliasPhase;
            DataTools.MergeRows(Conn, tvar, queryVar);
            //string filtervar = QHS.AppAnd(QHS.CmpEq(idmov, epExp[idmov]), QHS.CmpEq("yvar", esercizio));
            //Conn.RUN_SELECT_INTO_TABLE(tvar, null, filtervar, null, false);
            string queryYearColumns = DataTools.aliasColumns(tyear, tyear.TableName);
            string queryYear = "select " + queryYearColumns +
                               " from " + table +
                               " join " + tyear.TableName + " on " + tyear.TableName + "." + idmov + " = " +
                               table + "." + idmov +
                               " and " + tyear.TableName + ".ayear = " + QHS.quote(esercizio) +
                               " and " + filterAliasPhase;
            DataTools.MergeRows(Conn, tyear, queryYear);
            //Conn.RUN_SELECT_INTO_TABLE(tyear, null, filter, null, false);

            //lastread = tyear.Select(QHC.CmpEq(idmov, epExp[idmov]));
            foreach (DataRow rr2 in tyear.Rows) {
                rr2["amount"] = 0;
                rr2["amount2"] = 0;
                rr2["amount3"] = 0;
                rr2["amount4"] = 0;
                rr2["amount5"] = 0;
            }

            string queryEntryDetailsColumns = DataTools.aliasColumns(tEntryDetail, tEntryDetail.TableName);
            string queryEntryDetails = "select " + queryEntryDetailsColumns +
                                       " from " + table +
                                       " join " + tEntryDetail.TableName + " on " + tEntryDetail.TableName + "." +
                                       idmov + " = " +
                                       table + "." + idmov +
                                       " and " + tEntryDetail.TableName + ".yentry = " + QHS.quote(esercizio) +
                                       " and " + filterAlias;
            ;
            DataTools.MergeRows(Conn, tEntryDetail, queryEntryDetails);

            //string filterEntry = QHS.AppAnd(QHS.CmpEq(idmov, epExp[idmov]), QHS.CmpEq("yentry", esercizio));
            //Conn.RUN_SELECT_INTO_TABLE(tEntryDetail, null, filterEntry, null, false);
            //lastread = tvar.Select(QHC.CmpEq("idepexp", epExp["idepexp"]));
            //foreach (DataRow rr2 in lastread) {
            //    rr2["amount"] = 0;                    
            //}
            //}


            foreach (DataRow rr2 in tsort.Rows) {
                rr2["amount"] = 0;
            }

            if (table == "epexp") {
                epexpyearList = new Dictionary<int, DataRow>();

                foreach (DataRow r in D.Tables["epexpyear"].Rows) {
                    epexpyearList[CfgFn.GetNoNullInt32(r[idmov])] = r;
                }

                foreach (DataRow r in D.Tables["epexp"].Rows) {
                    string k = r["idrelated"].ToString() + "*" + r["nphase"];
                    EpExpByIdRelated[k] = r;
                }
            }
            else {
                epaccyearList = new Dictionary<int, DataRow>();
                foreach (DataRow r in D.Tables["epaccyear"].Rows) {
                    epaccyearList[CfgFn.GetNoNullInt32(r[idmov])] = r;
                }

                foreach (DataRow r in D.Tables["epacc"].Rows) {
                    string k = r["idrelated"].ToString() + "*" + r["nphase"];
                    EpAccByIdRelated[k] = r;
                }
            }

            return true;
        }

        public void clearHashes() {
            epexpyearList.Clear();
            epaccyearList.Clear();
            EpExpByIdRelated.Clear();
            EpAccByIdRelated.Clear();
        }

        public Dictionary<int, DataRow> epexpyearList = new Dictionary<int, DataRow>();
        public Dictionary<int, DataRow> epaccyearList = new Dictionary<int, DataRow>();

        /// <summary>
        /// Returns the array of idsor existent in a DataRow
        /// </summary>
        /// <param name="R"></param>
        /// <returns></returns>
        public static object[] GetIDSor(DataRow R) {
            if (R == null) return null;
            int n = 1;
            while (R.Table.Columns["idsor" + n.ToString()] != null) n++;
            n--;
            object[] res = new object[n];

            for (int i = 1; i <= n; i++) {
                res[i - 1] = R["idsor" + i.ToString()];
            }

            return res;
        }

        public DataRow SetEpExp(object idreg, decimal amount, object description, object adate, object idacc,
            object idrelated, object doc, object docdate) {
            DataRow R;
            R = SetEpExp(idreg, DBNull.Value, amount, description, adate, idacc, "0001",
                idrelated, doc, docdate, DBNull.Value, DBNull.Value, 2, DBNull.Value);
            return R;
        }

        /// <summary>
        /// Imposta i valori di un impegno di budget
        /// </summary>
        /// <param name="idreg"></param>
        /// <param name="amount"></param>
        /// <param name="description"></param>
        /// <param name="adate"></param>
        /// <param name="idacc"></param>
        /// <param name="idupb"></param>
        /// <param name="idrelated"></param>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        /// <returns></returns>
        public DataRow SetEpExp(object idreg, decimal amount, object description, object adate, object idacc,
            object idupb,
            object idrelated, object start, object stop) {
            DataRow R;
            R = SetEpExp(idreg, DBNull.Value, amount, description, adate, idacc, idupb,
                idrelated, DBNull.Value, DBNull.Value, start, stop, 2, DBNull.Value);
            return R;
        }

        public DataRow SetEpExp(object idreg, decimal amount, object description, object adate, object idacc,
            object idupb,
            object idrelated, object start, object stop, int nphase, object parentidrelated) {
            DataRow R;
            R = SetEpExp(idreg, DBNull.Value, amount, description, adate, idacc, idupb,
                idrelated, DBNull.Value, DBNull.Value, start, stop, nphase, parentidrelated);
            return R;
        }


        public static int ngiorniCommerciali(DateTime inizio, DateTime fine) {
            int giorni_primomese = inizio.Day > 30 ? 0 : 31 - inizio.Day;
            int giorni_ultimomese = fine.Day == 31 ? 30 : fine.Day;
            int n_anni_inmezzo = 0;
            if (fine.Year - inizio.Year > 1)
                n_anni_inmezzo = (fine.Year - inizio.Year) - 1;
            int n_mesi_inmezzo = 0;
            if (fine.Year > inizio.Year) {
                n_mesi_inmezzo = (12 - inizio.Month) + (fine.Month - 1);
            }
            else {
                if (fine.Month - inizio.Month > 1) {
                    n_mesi_inmezzo = fine.Month - inizio.Month - 1;
                }
            }

            return giorni_primomese + n_anni_inmezzo * 360 + n_mesi_inmezzo * 30 + giorni_ultimomese;
        }

        public static int NgiorniTotali(DateTime inizio, DateTime Fine, bool commerciale) {
            if (commerciale) {
                return ngiorniCommerciali(inizio, Fine);
            }
            else {
                return 1 + (Fine - inizio).Days;
            }

        }

        public static DateTime DataInizioRateoDaConsiderare(DateTime inizioCompetenza, int currAyear) {
            if (inizioCompetenza.Year < currAyear) {
                //Se la data inizio precede l'anno corrente, considera il primo dell'anno
                return new DateTime(currAyear, 1, 1);
            }
            else
                return inizioCompetenza;
        }

        public static DateTime DataFineRateoDaConsiderare(DateTime fineCompetenza, int currAyear) {
            if (fineCompetenza.Year > currAyear) {
                return new DateTime(currAyear, 12, 31);
            }
            else
                return fineCompetenza;
        }


        public static int NGiorniInAnno(DateTime Inizio, DateTime Fine, int currAyear, bool commerciale) {
            DateTime InizioRateo = DataInizioRateoDaConsiderare(Inizio, currAyear);
            DateTime FineRateo = DataFineRateoDaConsiderare(Fine, currAyear);

            if (commerciale) {
                return ngiorniCommerciali(InizioRateo, FineRateo);
            }
            else {
                DateTime dec31 = new DateTime(currAyear, 12, 31);
                return (FineRateo - InizioRateo).Days + 1;
            }
        }

        public decimal[] GetAmounts(decimal amount, DateTime start, DateTime stop) {
            decimal[] am = new decimal[5];
            if (amount <= epannualthreeshold) {
                am[0] = amount;
                for (int i = 1; i < 5; i++) {
                    am[i] = 0;
                }

                return am;
            }

            int tot_giorni = NgiorniTotali(start, stop, AnnoCommerciale);
            decimal attribuito = 0;
            for (int y = start.Year; y <= stop.Year; y++) {
                int indice = y - esercizio;
                if (indice > 4) indice = 4;
                int indice_ge_0 = indice < 0 ? 0 : indice;
                if (indice == 4 || y == stop.Year) {
                    am[indice_ge_0] += (amount - attribuito);
                    break;
                }

                int giorni_anno = NGiorniInAnno(start, stop, y, AnnoCommerciale);
                decimal quota_anno = CfgFn.Round((amount / tot_giorni) * giorni_anno, 2);
                am[indice_ge_0] += quota_anno;
                attribuito += quota_anno;
            }


            return am;
        }

        Dictionary<string, bool> upbSpecial = new Dictionary<string, bool>();

        bool isUPBSpecial(object idupb) {
            if (idupb == null || idupb == DBNull.Value)
                return false;
            if (upbSpecial.ContainsKey(idupb.ToString()))
                return upbSpecial[idupb.ToString()];
            bool isspecial =
                CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("upb", QHS.CmpEq("idupb", idupb), "(flagkind&4)")) != 0;
            upbSpecial.Add(idupb.ToString(), isspecial);
            return isspecial;
        }

        Dictionary<string, string> idaccspecial = new Dictionary<string, string>();

        string getSpecialAcc(string idacc) {
            if (idaccspecial.ContainsKey(idacc))
                return idaccspecial[idacc];
            object spec = Conn.DO_READ_VALUE("account", QHS.CmpEq("idacc", idacc), "idacc_special");
            if (spec == null || spec == DBNull.Value || spec.ToString() == "")
                spec = idacc;
            idaccspecial[idacc] = spec.ToString();
            return spec.ToString();
        }

        string GetRightIdAcc(string idacc, object idupb) {
            if (isUPBSpecial(idupb))
                return getSpecialAcc(idacc);
            return idacc;
        }


        /// <summary>
        /// Imposta i dati principali dell'impegno di budget, crea le righe se non esistono. La ricerca è fatta sulla base di idrelated
        /// </summary>
        /// <param name="description"></param>
        /// <param name="adate"></param>
        /// <param name="Doc"></param>
        /// <param name="DocDate"></param>
        /// <param name="idrelated"></param>
        /// <param name="parent_idrelated">idrelated of parent epexp when present</param>
        /// <returns></returns>
        public DataRow SetEpExp(object idreg, object idman, decimal amount, object description, object adate,
            object idacc, object idupb,
            object idrelated, object doc, object docdate, object start, object stop, int nphase,
            object parent_idrelated) {
            DataTable EpExp = D.Tables["epexp"];
            DataTable EpExpYear = D.Tables["epexpyear"];
            string k = idrelated.ToString() + "*" + nphase;
            DataRow[] rEpExp;
            if (EpExpByIdRelated.ContainsKey(k)) {
                rEpExp = new DataRow[] {EpExpByIdRelated[k]};
            }
            else {
                rEpExp = EpExp.Select(QHC.AppAnd(QHC.CmpEq("nphase", nphase), QHC.CmpEq("idrelated", idrelated)));
            }

            DataRow R;
            DataRow Ry;
            amount = CfgFn.Round(amount, 2);

            //if (EpExp.Rows.Count==0){
            if (rEpExp.Length == 0) {
                MetaEpExp.SetDefaults(EpExp);
                R = MetaEpExp.Get_New_Row(null, EpExp);
                MetaEpExpYear.SetDefaults(EpExpYear);
                Ry = MetaEpExpYear.Get_New_Row(R, EpExpYear);
            }
            else {
                R = rEpExp[0];
                Ry = epexpyearList[CfgFn.GetNoNullInt32(R["idepexp"])];
            }

            decimal[] am;
            if (start == DBNull.Value || stop == DBNull.Value) {
                am = new decimal[5] {amount, 0, 0, 0, 0};
            }
            else {
                am = GetAmounts(amount, (DateTime) start, (DateTime) stop);
            }

            object parentidepexp = R["paridepexp"];
            //Non cambia gli idparent quando già presenti nella riga
            if (nphase == 2 && parentidepexp == DBNull.Value) {
                if (parent_idrelated != DBNull.Value && parent_idrelated != null) {
                    parentidepexp = getidepexp_from_idrelated(parent_idrelated.ToString(), 1);
                }

                R["paridepexp"] = parentidepexp;
            }

            R["idreg"] = idreg;
            Ry["amount"] = CfgFn.GetNoNullDecimal(Ry["amount"]) + am[0];
            Ry["amount2"] = CfgFn.GetNoNullDecimal(Ry["amount2"]) + am[1];
            Ry["amount3"] = CfgFn.GetNoNullDecimal(Ry["amount3"]) + am[2];
            Ry["amount4"] = CfgFn.GetNoNullDecimal(Ry["amount4"]) + am[3];
            Ry["amount5"] = CfgFn.GetNoNullDecimal(Ry["amount5"]) + am[4];
            R["description"] = description;
            R["idrelated"] = idrelated;
            if (doc != DBNull.Value)
                if (start != DBNull.Value)
                    R["start"] = start;
            if (stop != DBNull.Value) R["stop"] = stop;
            if (idman != DBNull.Value) R["idman"] = idman;
            Ry["idacc"] = GetRightIdAcc(idacc.ToString(), idupb); //operare la traslazione in base all'upb
            if (idupb != DBNull.Value) Ry["idupb"] = idupb;
            if (adate != DBNull.Value) R["adate"] = adate;
            if (doc != DBNull.Value) R["doc"] = doc;
            if (docdate != DBNull.Value) R["docdate"] = docdate;
            R["nphase"] = nphase;
            return R;
        }

        public DataRow addEpExpVar(object idepexp, object description, object adate, decimal[] amount) {
            string filterVar = QHC.AppAnd(QHC.CmpEq("idepexp", idepexp), QHC.CmpEq("description", description),
                QHC.CmpEq("adate", adate));
            DataRow[] arrVarEsistente = D.Tables["epexpvar"].Select(filterVar);
            DataRow currVar;
            //Vede se esiste già la variazione
            if (arrVarEsistente.Length > 0) {
                currVar = arrVarEsistente[0];
            }
            else {
                MetaEpExpVar.SetDefaults(D.Tables["epexpvar"]);
                MetaData.SetDefault(D.Tables["epexpvar"], "idepexp", idepexp);
                currVar = MetaEpExpVar.Get_New_Row(null, D.Tables["epexpvar"]);
                currVar["idepexp"] = idepexp;
                currVar["description"] = description;
                currVar["adate"] = adate;
            }

            currVar["amount"] = CfgFn.GetNoNullDecimal(currVar["amount"]) + amount[0];
            currVar["amount2"] = CfgFn.GetNoNullDecimal(currVar["amount2"]) + amount[1];
            currVar["amount3"] = CfgFn.GetNoNullDecimal(currVar["amount3"]) + amount[2];
            currVar["amount4"] = CfgFn.GetNoNullDecimal(currVar["amount4"]) + amount[3];
            currVar["amount5"] = CfgFn.GetNoNullDecimal(currVar["amount5"]) + amount[4];

            return currVar;
        }

        public DataRow addEpAccVar(object idepacc, object description, object adate, decimal[] amount) {
            string filterVar = QHC.AppAnd(QHC.CmpEq("idepacc", idepacc), QHC.CmpEq("description", description),
                QHC.CmpEq("adate", adate));
            DataRow[] arrVarEsistente = D.Tables["epaccvar"].Select(filterVar);
            DataRow currVar;
            //Vede se esiste già la variazione
            if (arrVarEsistente.Length > 0) {
                currVar = arrVarEsistente[0];
            }
            else {
                MetaEpAccVar.SetDefaults(D.Tables["epaccvar"]);
                MetaData.SetDefault(D.Tables["epaccvar"], "idepacc", idepacc);
                currVar = MetaEpAccVar.Get_New_Row(null, D.Tables["epaccvar"]);
                currVar["idepacc"] = idepacc;
                currVar["description"] = description;
                currVar["adate"] = adate;
            }

            currVar["amount"] = CfgFn.GetNoNullDecimal(currVar["amount"]) + amount[0];
            currVar["amount2"] = CfgFn.GetNoNullDecimal(currVar["amount2"]) + amount[1];
            currVar["amount3"] = CfgFn.GetNoNullDecimal(currVar["amount3"]) + amount[2];
            currVar["amount4"] = CfgFn.GetNoNullDecimal(currVar["amount4"]) + amount[3];
            currVar["amount5"] = CfgFn.GetNoNullDecimal(currVar["amount5"]) + amount[4];

            return currVar;
        }

        private Dictionary<string, DataRow> EpExpByIdRelated = new Dictionary<string, DataRow>();
        private Dictionary<string, DataRow> EpAccByIdRelated = new Dictionary<string, DataRow>();

        public void setEpExpRow(string idrelated, int nPhase, DataRow r) {
            string k = idrelated.ToString() + "*" + nPhase;
            if (r == null ) {
	            if (EpExpByIdRelated.ContainsKey(k)) EpExpByIdRelated.Remove(k);
            }
            else {
	            EpExpByIdRelated[k] = r;
            }
        }

        public void setEpAccRow(string idrelated, int nPhase, DataRow r) {
            string k = idrelated.ToString() + "*" + nPhase;
            if (r == null) {
	            if (EpAccByIdRelated.ContainsKey(k)) EpAccByIdRelated.Remove(k);
            }
            else {
	            EpAccByIdRelated[k] = r;
            }
        }

		

        public DataRow getEpExpRowLike(object idrelated, int nphase) {
	        foreach (var existing in EpExpByIdRelated.Keys) {
				var parts = existing.Split('*');
				if (parts[1].ToString()!=nphase.ToString())continue;
				if (parts[0] == idrelated.ToString()) return EpExpByIdRelated[existing];
				if (parts[0].StartsWith(idrelated.ToString()+"§")) return EpExpByIdRelated[existing];
	        }

	        return null;
        }

        public DataRow getEpExpRow(object idrelated, int nphase) {
            string k = idrelated.ToString() + "*" + nphase;
            if (EpExpByIdRelated.ContainsKey(k)) {
                DataRow r = EpExpByIdRelated[k];
                if (r.RowState != DataRowState.Detached) return r;
            }
            return null;
            //DataTable EpExp = D.Tables["epexp"];
            //DataRow[] rEpExpArr = EpExp.Select(QHC.AppAnd(QHC.CmpEq("nphase", nphase), QHC.CmpEq("idrelated", idrelated)));

            //DataRow rEpExp = null;
            //if (rEpExpArr.Length > 0) {
            //    rEpExp = rEpExpArr[0];
            //}
            //return rEpExp;
        }

        public DataRow addEpExp(object idreg, object idman, decimal amount, object description, object adate,
            object idacc, object idupb,
            string idrelated, object doc, object docdate, object start, object stop, int nphase, object parIdEpExp,
            object idaccmotive) {
            DataTable EpExp = D.Tables["epexp"];
            DataTable EpExpYear = D.Tables["epexpyear"];

            DataRow rEpExp = getEpExpRow(idrelated, nphase);

            DataRow R;
            DataRow Ry;
            amount = CfgFn.Round(amount, 2);

            //if (EpExp.Rows.Count==0){
            if (rEpExp == null) {
                MetaEpExp.SetDefaults(EpExp);
                R = MetaEpExp.Get_New_Row(null, EpExp);
                if (nphase == 2) {
                    R["paridepexp"] = parIdEpExp;
                }

                R["nphase"] = nphase;
                MetaEpExpYear.SetDefaults(EpExpYear);
                Ry = MetaEpExpYear.Get_New_Row(R, EpExpYear);
                epexpyearList[CfgFn.GetNoNullInt32(R["idepexp"])] = Ry;
                if (adate != DBNull.Value) R["adate"] = adate; //solo in questo ramo assegno la data
                setEpExpRow(idrelated, nphase, R);
            }
            else {
                R = rEpExp;
                Ry = getEpExpYearById(CfgFn.GetNoNullInt32(R["idepexp"]));

                if (Ry == null) {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show(
                        "L'impegno di budget " + R["yepexp"] + "/" + R["nepexp"] + " non esiste nell'esercizio " +
                        Conn.GetEsercizio(),
                        "Errore");
                    MetaEpExpYear.SetDefaults(EpExpYear);
                    Ry = MetaEpExpYear.Get_New_Row(R, EpExpYear);
                }
            }

            R["idaccmotive"] = idaccmotive;
            if (nphase == 2) {
                R["idreg"] = idreg;
            }
            else {
                R["idreg"] = DBNull.Value;
            }

            R["description"] = description;
            R["idrelated"] = idrelated;
            if (start != DBNull.Value) R["start"] = start;
            if (stop != DBNull.Value) R["stop"] = stop;
            if (idman != DBNull.Value && idman != null) R["idman"] = idman;

            if (doc != DBNull.Value) R["doc"] = doc;
            if (docdate != DBNull.Value) R["docdate"] = docdate;
            Ry["idacc"] = GetRightIdAcc(idacc.ToString(), idupb); //operare la traslazione in base all'upb

            if (idupb != DBNull.Value && idupb != null) Ry["idupb"] = idupb;


            decimal[] am;
            if (start == DBNull.Value || stop == DBNull.Value) {
                am = new decimal[5] {amount, 0, 0, 0, 0};
            }
            else {
                am = GetAmounts(amount, (DateTime) start, (DateTime) stop);
            }

            Ry["amount"] = CfgFn.GetNoNullDecimal(Ry["amount"]) + am[0];
            Ry["amount2"] = CfgFn.GetNoNullDecimal(Ry["amount2"]) + am[1];
            Ry["amount3"] = CfgFn.GetNoNullDecimal(Ry["amount3"]) + am[2];
            Ry["amount4"] = CfgFn.GetNoNullDecimal(Ry["amount4"]) + am[3];
            Ry["amount5"] = CfgFn.GetNoNullDecimal(Ry["amount5"]) + am[4];

            return R;
        }

        public DataRow getEpAccRow(object idrelated, int nphase) {
            string k = idrelated.ToString() + "*" + nphase;
            if (EpAccByIdRelated.ContainsKey(k)) {
                DataRow r=EpAccByIdRelated[k];
                if (r.RowState != DataRowState.Detached) return r;

            }
            return null;
            //DataTable EpAcc = D.Tables["epacc"];
            //DataRow[] rEpAccArr = EpAcc.Select(QHC.AppAnd(QHC.CmpEq("nphase", nphase), QHC.CmpEq("idrelated", idrelated)));

            //DataRow rEpAcc = null;
            //if (rEpAccArr.Length > 0) {
            //    rEpAcc = rEpAccArr[0];
            //}
            //return rEpAcc;
        }

        public DataRow getEpAccYearById(object idepacc) {
            if (idepacc == null || idepacc == DBNull.Value) return null;
            int id = CfgFn.GetNoNullInt32(idepacc);
            if (epaccyearList.ContainsKey(id)) return epaccyearList[id];
            DataRow[] epAccYear = D.Tables["epaccyear"].Select(QHC.CmpEq("idepacc", id));

            if (epAccYear.Length > 0) {
                var r = epAccYear[0];
                epaccyearList[CfgFn.GetNoNullInt32(r["idepacc"])] = r;
                return r;
            }

            return null;
        }

        public DataRow getEpAccById(object idepacc) {
	        if (idepacc == null || idepacc == DBNull.Value) return null;
	        DataRow[] epAcc = D.Tables["epacc"].Select(QHC.CmpEq("idepacc", idepacc));
	        if (epAcc.Length > 0) {
		        return epAcc[0];
	        }
	        return null;
        }
        public DataRow getEpExpById(object idepexp) {
	        if (idepexp == null || idepexp == DBNull.Value) return null;
	        DataRow[] epExp = D.Tables["epexp"].Select(QHC.CmpEq("idepexp", idepexp));
	        if (epExp.Length > 0) {
		        return epExp[0];
	        }
	        return null;
        }

        public DataRow getEpExpYearById(object idepexp) {
            if (idepexp == null || idepexp == DBNull.Value) return null;
            int id = CfgFn.GetNoNullInt32(idepexp);
            if (epexpyearList.ContainsKey(id)) return epexpyearList[id];
            DataRow[] epExpYear = D.Tables["epexpyear"].Select(QHC.CmpEq("idepexp", id));

            if (epExpYear.Length > 0) {
                var r = epExpYear[0];
                epexpyearList[CfgFn.GetNoNullInt32(r["idepexp"])] = r;
                return r;
            }
            return null;
        }

        public DataRow addEpAcc(object idreg, object idman, decimal amount, object description, object adate,
            object idacc, object idupb,
            string idrelated, object doc, object docdate, object start, object stop, int nphase, object parIdEpAcc,
            object idaccmotive) {
            DataTable epAcc = D.Tables["epacc"];
            DataTable epAccYear = D.Tables["epaccyear"];

            DataRow rEpAcc = getEpAccRow(idrelated, nphase);

            DataRow R;
            DataRow Ry;
            amount = CfgFn.Round(amount, 2);

            //if (EpExp.Rows.Count==0){
            if (rEpAcc == null) {
                MetaEpAcc.SetDefaults(epAcc);
                R = MetaEpAcc.Get_New_Row(null, epAcc);
                if (nphase == 2) {
                    R["paridepacc"] = parIdEpAcc;
                }

                R["nphase"] = nphase;
                MetaEpAccYear.SetDefaults(epAccYear);
                Ry = MetaEpAccYear.Get_New_Row(R, epAccYear);
                epaccyearList[CfgFn.GetNoNullInt32(R["idepacc"])] = Ry;
                setEpAccRow(idrelated, nphase, R);
                if (adate != DBNull.Value) R["adate"] = adate; //solo in questo ramo assegno la data
            }
            else {
                R = rEpAcc;
                Ry = getEpAccYearById(CfgFn.GetNoNullInt32(R["idepacc"]));
                if (Ry == null) {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show(
                        "L'accertamento di budget " + R["yepacc"] + "/" + R["nepacc"] +
                        " non esiste nell'esercizio. " +
                        Conn.GetEsercizio(),
                        "Avviso");
                    MetaEpAccYear.SetDefaults(epAccYear);
                    Ry = MetaEpAccYear.Get_New_Row(R, epAccYear);
                }                
            }

            R["idreg"] = idreg;
            R["idaccmotive"] = idaccmotive;
            if (nphase == 2) {

            }
            else {
                R["idreg"] = DBNull.Value;
            }

            R["description"] = description;
            R["idrelated"] = idrelated;
             R["start"] = start; //if (start != DBNull.Value)
              R["stop"] = stop; //if (stop != DBNull.Value)
             R["idman"] = idman; //if (idman != DBNull.Value)

             R["doc"] = doc;  //if (doc != DBNull.Value)
             R["docdate"] = docdate; //if (docdate != DBNull.Value)
            Ry["idacc"] = GetRightIdAcc(idacc.ToString(), idupb); //operare la traslazione in base all'upb

            Ry["idupb"] = idupb; //if (idupb != DBNull.Value)


            decimal[] am;
            if (start == DBNull.Value || stop == DBNull.Value) {
                am = new decimal[5] {amount, 0, 0, 0, 0};
            }
            else {
                am = GetAmounts(amount, (DateTime) start, (DateTime) stop);
            }

            Ry["amount"] = CfgFn.GetNoNullDecimal(Ry["amount"]) + am[0]; //in rigenerazione il vecchio valore già c'è...
            Ry["amount2"] = CfgFn.GetNoNullDecimal(Ry["amount2"]) + am[1];// quindi viene aumentato ancora
            Ry["amount3"] = CfgFn.GetNoNullDecimal(Ry["amount3"]) + am[2];
            Ry["amount4"] = CfgFn.GetNoNullDecimal(Ry["amount4"]) + am[3];
            Ry["amount5"] = CfgFn.GetNoNullDecimal(Ry["amount5"]) + am[4];

            return R;
        }

        Dictionary<string, object> idepexp_idrelated = new Dictionary<string, object>();

        object getidepexp_from_idrelated(string idrelated, int nphase) {
            string mykey = idrelated + "-" + nphase;
            if (idepexp_idrelated.ContainsKey(mykey))
                return idepexp_idrelated[mykey];

            object id = Conn.DO_READ_VALUE("epexp",
                QHS.AppAnd(QHS.CmpEq("idrelated", idrelated), QHS.CmpEq("nphase", nphase)), "idepexp");
            if (id == null) {
                id = DBNull.Value;
            }

            idepexp_idrelated[mykey] = id;
            return id;
        }


        DataTable _tConfig = null;

        private DataRow getConfig() {
            if (_tConfig != null) {
                if (_tConfig.Rows.Count == 0)
                    return null;
                return _tConfig.Rows[0];
            }

            _tConfig = DataAccess.RUN_SELECT(Conn, "config", "*",
                null, QHS.CmpEq("ayear", esercizio), null, null, true);
            if (_tConfig == null) return null;
            if (_tConfig.Rows.Count == 0)
                return null;
            return _tConfig.Rows[0];

        }

        /// <summary>
        /// Adds an amount to a specified entry, creating a new one if it not exists
        /// </summary>
        /// <param name="D"></param>
        /// <param name="idacc"></param>
        /// <param name="amount"></param>
        /// <param name="idsor"></param>
        /// <returns></returns>
        public void AddEpExpSorting(decimal amount,
            object[] idsor, DataRow rEpExp) {

            string filter = QueryCreator.WHERE_KEY_CLAUSE(rEpExp, DataRowVersion.Current, false);

            DataTable EpExpSorting = D.Tables["epexpsorting"];

            DataRow rConfig = getConfig();
            if (rConfig == null)
                return;
            int nCiclo = 1;
            foreach (object currIdSor in idsor) {
                if (currIdSor == DBNull.Value) {
                    nCiclo++;
                    continue;
                }

                object currIdSorKind = rConfig["idsortingkind" + nCiclo];
                if (currIdSorKind == DBNull.Value) {
                    nCiclo++;
                    continue;
                }

                string currFilter = QHC.CmpEq("idsor", currIdSor);
                string filterSor = QHC.AppAnd(filter, currFilter);

                DataRow[] rr = EpExpSorting.Select(filterSor);
                DataRow R = null;
                if (rr.Length > 0) {
                    R = rr[0];
                }

                if (R == null) {
                    MetaEpExpSorting.SetDefaults(EpExpSorting);
                    R = MetaEpExpSorting.Get_New_Row(rEpExp, EpExpSorting);
                    R["idsor"] = currIdSor;
                    R["amount"] = amount;
                }
                else {
                    R["amount"] = CfgFn.GetNoNullDecimal(R["amount"]) + amount;
                }

                R["adate"] = rEpExp["adate"];
                nCiclo++;
            }
        }

        /// <summary>
        /// Cancella le righe che hanno importo zero
        /// </summary>
        public void RemoveEmptyEpexp() {
            DataTable EpExp = D.Tables["epexp"];
            DataTable EpExpYear = D.Tables["epexpyear"];
            foreach (DataRow R in EpExpYear.Select()) {
                bool todelete = true;
                foreach (string f in new string[] {"amount", "amount2", "amount3", "amount4", "amount5"}) {
                    if (CfgFn.GetNoNullDecimal(R[f]) != 0) {
                        todelete = false;
                        break;
                    }
                }

                if (!todelete) continue;
                DataRow[] epexpvars = D.Tables["epexpvar"].Select(QHC.CmpEq("idepexp", R["idepexp"]));
                if (epexpvars.Length > 0) continue;

                DataRow rexp = EpExp.Select(QHC.CmpEq("idepexp", R["idepexp"]))[0];
                foreach (DataRow rsor in D.Tables["epexpsorting"].Select(QHC.CmpEq("idepexp", R["idepexp"]))) {
                    rsor.Delete();
                }

                foreach (DataRow rvar in D.Tables["epexpvar"].Select(QHC.CmpEq("idepexp", R["idepexp"]))) {
                    rvar.Delete();
                }

                R.Delete();
                if (rexp.RowState != DataRowState.Deleted)
                    rexp.Delete();
            }
        }

        public void RemoveEmptyEpacc() {
            DataTable epAcc = D.Tables["epacc"];
            DataTable epAccYear = D.Tables["epaccyear"];
            foreach (DataRow R in epAccYear.Select()) {
                bool todelete = true;
                foreach (string f in new string[] {"amount", "amount2", "amount3", "amount4", "amount5"}) {
                    if (CfgFn.GetNoNullDecimal(R[f]) != 0) {
                        todelete = false;
                        break;
                    }
                }

                if (!todelete) continue;
                DataRow[] epaccvars = D.Tables["epaccvar"].Select(QHC.CmpEq("idepacc", R["idepacc"]));
                if (epaccvars.Length > 0) continue;

                DataRow rexp = epAcc.Select(QHC.CmpEq("idepacc", R["idepacc"]))[0];
                foreach (DataRow rsor in D.Tables["epaccsorting"].Select(QHC.CmpEq("idepacc", R["idepacc"]))) {
                    rsor.Delete();
                }

                foreach (DataRow rvar in D.Tables["epaccvar"].Select(QHC.CmpEq("idepacc", R["idepacc"]))) {
                    rvar.Delete();
                }

                R.Delete();
                if (rexp.RowState != DataRowState.Deleted)
                    rexp.Delete();
            }
        }

        public void RemoveEmptyDetails() {
            DataTable Det;
            Det = D.Tables["epexpsorting"];

            foreach (DataRow R in Det.Select()) {
                if (CfgFn.GetNoNullDecimal(R["amount"]) == 0) R.Delete();
            }

            Det = D.Tables["epexpvar"];
            foreach (DataRow R in Det.Select()) {
                if (!someValue(amountsFromRow(R))) R.Delete();
            }

            Det = D.Tables["epaccsorting"];
            foreach (DataRow R in Det.Select()) {
                if (CfgFn.GetNoNullDecimal(R["amount"]) == 0) R.Delete();
            }

            Det = D.Tables["epaccvar"];
            foreach (DataRow R in Det.Select()) {
                if (!someValue(amountsFromRow(R))) R.Delete();
            }

        }

        public void clearAll() {
            ClearEpExp();
            //ClearDetails();
        }

        /// <summary>
        /// Effettua un reject changes sulle modifiche effettuate sull'impegno considerato, in modo che alla fine non saranno azzerati o intaccati
        /// </summary>
        /// <param name="idepexp"></param>
        public void RemoveEpExp(object idepexp) {
            if (idepexp == DBNull.Value) return;
            var epExpCached = getEpExpYearById(idepexp);
            if (epExpCached != null) {
                epExpCached.RejectChanges();
                return;
            }

            DataTable tEpExpYear = D.Tables["epexpyear"];
            string filter = QHC.CmpEq("idepexp", idepexp);
            foreach (DataRow R in tEpExpYear.Select(filter)) {
                R.RejectChanges();
            }
        }

        /// <summary>
        /// Effettua un reject changes sulle modifiche effettuate sull'accertamento considerato, in modo che alla fine non saranno azzerati o intaccati
        /// </summary>
        /// <param name="idepacc"></param>
        public void RemoveEpAcc(object idepacc) {
            if (idepacc == DBNull.Value) return;
            var epAccCached = getEpAccYearById(idepacc);
            if (epAccCached != null) {
                epAccCached.RejectChanges();
                return;
            }
            DataTable tEpAccYear = D.Tables["epaccyear"];
            string filter = QHC.CmpEq("idepacc", idepacc);
            foreach (DataRow R in tEpAccYear.Select(filter)) {
                R.RejectChanges();
            }
        }

        public void ClearEpExp() {
            DataTable tEpExpYear = D.Tables["epexpyear"];
            foreach (DataRow R in tEpExpYear.Select()) {
                R["amount"] = 0;
                R["amount2"] = 0;
                R["amount3"] = 0;
                R["amount4"] = 0;
                R["amount5"] = 0;
            }

            DataTable tEpAccYear = D.Tables["epaccyear"];
            foreach (DataRow R in tEpAccYear.Select()) {
                R["amount"] = 0;
                R["amount2"] = 0;
                R["amount3"] = 0;
                R["amount4"] = 0;
                R["amount5"] = 0;
            }
        }

        /// <summary>
        /// Azzera le classificazioni
        /// </summary>
        public void ClearDetails() {
            //DataTable Det = D.Tables["epexpsorting"];
            //foreach(DataRow R in Det.Select()){
            //	R["amount"] = 0;
            //}
            //Det = D.Tables["epexpvar"];
            //foreach (DataRow R in Det.Select()) {
            //    R["amount"] = 0;
            //}
        }

        public bool MainEpExpExists() {
            if (D.Tables["epexp"].Rows.Count > 0) return true;
            if (D.Tables["epacc"].Rows.Count > 0) return true;
            return false;
        }

        public DataRow[] GetAccMotiveDetails(object idaccmotive) {
            string filteraccmotive_C = QHC.AppAnd(QHC.CmpEq("idaccmotive", idaccmotive), QHC.CmpEq("ayear", esercizio));
            string filteraccmotive = QHS.AppAnd(QHS.CmpEq("idaccmotive", idaccmotive), QHS.CmpEq("ayear", esercizio));
            if (AccMotiveDetail.Select(filteraccmotive_C).Length == 0) {
                Conn.RUN_SELECT_INTO_TABLE(AccMotiveDetail, null, filteraccmotive, null, true);
            }

            return AccMotiveDetail.Select(filteraccmotive_C);
        }

        /// <summary>
        /// DUMMY OBSOLETO - NON USARE
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="idacc"></param>
        /// <param name="idreg"></param>
        /// <param name="RowForIDSOR"></param>
        /// <param name="dummy"></param>
        public void EffettuaScritturaImpegno(
            decimal amount, object idacc, object idreg,
            DataRow RowForIDSOR, string dummy) {

        }
        decimal[] amountsFromDict(Dictionary<string,object> r) {
	        decimal[] res = new decimal[5];
	        res[0] = CfgFn.GetNoNullDecimal(r["amount"]);
	        res[1] = CfgFn.GetNoNullDecimal(r["amount2"]);
	        res[2] = CfgFn.GetNoNullDecimal(r["amount3"]);
	        res[3] = CfgFn.GetNoNullDecimal(r["amount4"]);
	        res[4] = CfgFn.GetNoNullDecimal(r["amount5"]);
	        return res;
        }

        decimal[] amountsFromRow(DataRow r, DataRowVersion rv = DataRowVersion.Current) {
            decimal[] res = new decimal[5];
            res[0] = CfgFn.GetNoNullDecimal(r["amount", rv]);
            res[1] = CfgFn.GetNoNullDecimal(r["amount2", rv]);
            res[2] = CfgFn.GetNoNullDecimal(r["amount3", rv]);
            res[3] = CfgFn.GetNoNullDecimal(r["amount4", rv]);
            res[4] = CfgFn.GetNoNullDecimal(r["amount5", rv]);
            return res;
        }

        /// <summary>
        /// Restituisce true o false a seconda che i due array siano uguali
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        bool IsEqual(decimal[] a, decimal[] b) {
            bool res = true;
            for (int i = 0; i <= 4; i++) {
                if (a[i] != b[i])
                    return false;
            }
            return res;
        }

        /// <summary>
        /// Restituisce un array che dato da a - b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        decimal[] decDiff(decimal[] a, decimal[] b) {
            decimal[] res = new decimal[5];
            for (int i = 0; i <= 4; i++) res[i] = a[i] - b[i];
            return res;
        }

        decimal[] decAdd(decimal[] a, decimal[] b) {
            decimal[] res = new decimal[5];
            for (int i = 0; i <= 4; i++) res[i] = a[i] + b[i];
            return res;
        }

        bool someValue(decimal[] a) {
            for (int i = 0; i < a.Length; i++) {
                if (a[i] != 0) return true;
            }

            return false;
        }

        static string nameSuffix(int n) {
            if (n == 0) return "";
            return (n + 1).ToString();
        }

        //Bisogna tenere in conto solo l'importo iniziale e le variazioni di tutti gli anni, non solo l'importo dell'anno
        /// <summary>
        /// Crea delle modifiche (epexpvar) al posto di cannibalizzare l'importo dell'impegno
        /// </summary>
        public void updateAmounts(bool attivo) {
            string table = attivo ? "epacc" : "epexp";
            string id = "id" + table;
            MetaData metaExpVar = Disp.Get(table + "var");
            metaExpVar.SetDefaults(D.Tables[table + "var"]);

            Dictionary<int, List<DataRow>> epexpVarList = new Dictionary<int, List<DataRow>>();
            foreach (DataRow r in D.Tables[table + "var"].Rows) {
                int id1 = CfgFn.GetNoNullInt32(r[id]);
                if (!epexpVarList.ContainsKey(id1)) {
                    epexpVarList[id1] = new List<DataRow>();
                }

                epexpVarList[id1].Add(r);
            }

            Dictionary<int, DataRow> epmovyear = new Dictionary<int, DataRow>();
            foreach (DataRow r in D.Tables[table + "year"].Rows) {
                int id1 = CfgFn.GetNoNullInt32(r[id]);
                epmovyear[id1] = r;
            }
            
            foreach (DataRow e in D.Tables[table].Rows) {
                if (e.RowState == DataRowState.Added) continue;
                DataRow ey = null;
                if (!epmovyear.ContainsKey(CfgFn.GetNoNullInt32(e[id]))) {
                    Conn.RUN_SELECT_INTO_TABLE(D.Tables[table + "year"], null,
                        QHS.AppAnd(QHS.CmpEq(id, e[id]), QHS.CmpEq("ayear", Conn.GetEsercizio())), null, false);
                    DataRow[] found = D.Tables[table + "year"].Select(QHC.CmpEq(id, e[id]));
                    if (found.Length > 0) {
                        ey = found[0];
                    }
                    else {
                        throw new Exception("Non ho trovato una riga in " + table + "year avente chiave " + e[id]);
                    }
                }
                else {
                    ey = epmovyear[CfgFn.GetNoNullInt32(e[id])];
                }
                if (e.RowState == DataRowState.Unchanged && ey.RowState == DataRowState.Unchanged) continue;

                int yepexp = CfgFn.GetNoNullInt32(e["y" + table]);
                //importi anno iniziale del movimento di budget
                
                decimal[] currAmount = amountsFromRow(ey); //E' l'importo come impostato dall'operazione attuale, importo attuale che trova è 0

                decimal[] importoPrecedente = amountsFromRow(ey, DataRowVersion.Original); //è uguale a yearAmount dell'anno, in questo caso 799
                
                decimal[] pagatoAnniPrecedenti = new decimal[] {0, 0, 0, 0, 0};
                //calcola il pagato anni precedenti come yearAmount e quello iniziale alla creazione del movimento

                if (yepexp < esercizio) {
	                pagatoAnniPrecedenti = getPagatoAnniPrecedenti(attivo, e, ey);
                    //currAmount = decAdd(currAmount, pagatoAnniPrecedenti);
                    //currAmount = decAdd(importoRicalcolato, pagatoAnniPrecedenti);  //l'importo a partire dall'anno corrente deve incorporare i pag. anni prec per essere paragonabile a quello totale
                    //importoPrecedente = importoRicalcolato;                         //da 799 diventa 2000, perchè? comunque 2000 è l'importo iniziale non quello precedente, che sarebbe invece quello di inizio anno
								// a 2000 andrebbe sottratto il pagato dell'anno scorso. Ma alla fine a che serve, non possiamo prendere l'importo precedente uguale a quello originale iniziale e basta ossia 
                                // lasciarlo invariato??
                    
                }
                //Abbiamo:
                // pagato anni precedenti = 1200
                // importo precedente = importo iniziale anno = 799
                // importo corrente = 0 (include teoricamente il pagato anni precedenti, ossia potrebbe essere 2000 se non fosse che stiamo annullando)
                // importo variazioni anno corrente = -799 
                // vogliamo confrontare l'importo corrente con quello iniziale annuo (importo precedente) per capire quale variazione vada creata
                //  l'ideale sarebbe fare  importo corrente   - importo precedente  e ottenere il valore della variazione
                //  ma se ripetiamo il procedimento otterremmo sempre nuove variazioni quindi dobbiamo tenere conto delle variazioni già create 
                //   quindi facciamo (importo corrente - variazioni)  - importo precedente 
                // l'importo corrente inoltre non tiene conto del pagato anni precedenti quindi ad esso va sommato tale valore
                // quindi  (importo  corrente - pagato anni precedenti - variazioni) - importo precedente 
                //     = ( 0 (importo corrente)  - 1201 (pagato anni prec) + 799  (-variazioni)) - 799 =   1201 ma dovrebbe uscire 0
                // direi di fare importo precedente (799) + pagato anni precedenti
                

                //curramount è 50  ma dobbiamo sottrarre le variazioni dell'anno ossia +300
                //aggiunge a currAmount anche le var. di quest'anno
                if (epexpVarList.ContainsKey(CfgFn.GetNoNullInt32(e[id]))) {
                    foreach (DataRow v in epexpVarList[CfgFn.GetNoNullInt32(e[id])]) {
                        //aggiorna currAmount aggiungendovi le variazioni nuove
                        currAmount = decDiff(currAmount, amountsFromRow(v)); //curramount inizialmente vale 50, con le variazioni va in negativo a -250 che sono le variazioni presenti
                        //importoPrecedente = decAdd(importoPrecedente, amountsFromRow(v));
                    }
                }
                //currAmount era 50 ora è -250  (-250, 0, 0, 0 , 0)
                
             

                //yearAmount lo vogliamo lasciare unchanged
                //la differenza tra l'importo desiderato  e quello attuale la deve mettere in una variazione

                currAmount = decDiff(currAmount, pagatoAnniPrecedenti); //importo precedente passa da 1200 a 2000 perchè sommiamo il pagato di 899
                //riarmonizza l'importo corrente se trova dei negativi
                //Se currAmount = importoPrecedente non riarmonizza currAmount
                if (!IsEqual(currAmount, importoPrecedente)) {
                    riarmonizza(currAmount);
                }
                decimal[] importoVariazione = decDiff(currAmount, importoPrecedente); //ottiene la nuova variazione 

                //e.RejectChanges();
                foreach (string fieldToRestore in new string[]
                    {"amount", "amount2", "amount3", "amount4", "amount5"}) {
                    ey[fieldToRestore] = ey[fieldToRestore, DataRowVersion.Original];
                }

                if (someValue(importoVariazione)) {
                    DataRow rExpVar = metaExpVar.Get_New_Row(e, D.Tables[table + "var"]);
                    rExpVar["amount"] = importoVariazione[0];
                    rExpVar["amount2"] = importoVariazione[1];
                    rExpVar["amount3"] = importoVariazione[2];
                    rExpVar["amount4"] = importoVariazione[3];
                    rExpVar["amount5"] = importoVariazione[4];
                    rExpVar["description"] = "Variazione automatica generata per modifica documento collegato";
                }


            }
        }

        /// <summary>
        /// Cerchiamo di eliminare i negativi dagli importi, mantenendo il totale invariato
        /// Deve funzionare sia che la negatività sia seguita che preceduta da positività
        /// </summary>
        /// <param name="num"></param>
        void riarmonizza(decimal[] num) {
            // 2020 2021 2022 2023 2024         >>> risultato desiderato dalla funzione
            // 100, -40,  100                   >>> 100, 0 , 60           OK            60, 0, 100 ???
            // 100, -40,  0                     >>> 100, 0, 0 , 0 , -40   NOT OK
            // -40, 100,  0                     >>> 0, 60                 OK


	        decimal diff = 0;   //"debito" da colonne precedenti, da spalmare nelle successive
            for (int i = 0; i <= num.Length-1 ; i++) {
                decimal curr = num[i];
                if (curr > 0) {
                    if (diff < 0) {//spalma quello che può sulla colonna corrente
                        if (curr + diff >= 0) {
                            curr += diff;
                            diff = 0;
                        }
                        else {
                            diff += curr;
                            curr = 0;
                        }
                    }
                }
                else {//il debito aumenta
                    diff += curr;
                    curr = 0;
                }

                num[i] = curr;
            }
            num[num.Length-1] += diff;

            diff = 0;   //"debito" da colonne precedenti, da spalmare nelle successive

            for (int i = num.Length-1; i >=0 ; i--) {
                decimal curr = num[i];
                if (curr > 0) {
                    if (diff < 0) {//spalma quello che può sulla colonna corrente
                        if (curr + diff >= 0) {
                            curr += diff;
                            diff = 0;
                        }
                        else {
                            diff += curr;
                            curr = 0;
                        }
                    }
                }
                else {//il debito aumenta
                    diff += curr;
                    curr = 0;
                }

                num[i] = curr;
            }
            num[0] += diff;

        }

        public decimal[] getPagatoAnniPrecedenti(bool attivo, DataRow mov, DataRow movYear) {
	        string table = attivo ? "epacc" : "epexp";
	        string id = "id" + table;

	        decimal[] importoPrecedente =
		        amountsFromRow(movYear, DataRowVersion.Original); //è uguale a yearAmount dell'anno, in questo caso 799


	        DataTable tYearStart = Conn.RUN_SELECT(table + "year",
		        "id" + table + ",amount,amount2,amount3,amount4,amount5,ayear", null,
		        QHS.AppAnd(QHS.CmpEq(id, mov[id]), QHS.CmpEq("ayear", mov["y" + table])), null,
		        false); //Importo iniziale
	        DataTable tVar = Conn.RUN_SELECT(table + "var",
		        "id" + table + ",amount,amount2,amount3,amount4,amount5,nvar,yvar", null,
		        QHS.AppAnd(QHS.CmpEq(id, mov[id]), QHS.CmpLt("yvar", esercizio)), null, false);

	        if (tYearStart.Rows.Count == 0) {
		        return new decimal[] {0, 0, 0, 0, 0};
	        }



	        DataRow rI = tYearStart.Rows[0];
	        decimal[] importoInizialeSfasato = amountsFromRow(rI);
	        decimal[] importoRicalcolato = new decimal[5];
	        for (int i = 0; i <= 4; i++) {
		        importoRicalcolato[i] = 0;
	        }

	        int annoOriginaleImpegno = CfgFn.GetNoNullInt32(rI["ayear"]);
	        for (int i = 0; i <= 4; i++) {
		        int annoImporto = annoOriginaleImpegno + i;
		        int indice = annoImporto - esercizio;
		        int indiceGood = indice;
		        if (indiceGood < 0) indiceGood = 0;
		        if (indiceGood > 4) indiceGood = 4;
		        importoRicalcolato[indiceGood] += importoInizialeSfasato[i]; //è 2000,0,0,0,0
	        }

	        if (tVar != null) { //variazioni di anni precedenti, non considera quelle dell'anno però
		        foreach (DataRow var in tVar.Select()) {
			        int annoVariazione = CfgFn.GetNoNullInt32(var["yvar"]);
			        for (int i = 0; i <= 4; i++) {
				        decimal importoVarAnno = CfgFn.GetNoNullDecimal(var["amount" + nameSuffix(i)]);
				        if (importoVarAnno == 0) continue;
				        int indice = annoVariazione + i - esercizio;
				        int indiceGood = indice;
				        if (indiceGood < 0) indiceGood = 0;
				        if (indiceGood > 4) indiceGood = 4;
				        importoRicalcolato[indiceGood] += importoVarAnno;
			        }
		        }
	        }

	        //importo ricalcolato = 2000
	        return decDiff(importoRicalcolato, importoPrecedente);

        }

        bool changedCol(DataRow r, string col) {
            if (r.RowState == DataRowState.Added || r.RowState == DataRowState.Deleted) return true;
            return r[col, DataRowVersion.Current].ToString() != r[col, DataRowVersion.Original].ToString();
        }

        bool someChangedCol(DataRow r, params string[] col) {
            foreach (string c in col) {
                if (changedCol(r, c)) return true;
            }

            return false;
        }

        bool unchangedCol(DataRow r, params string[] col) {
            return !someChangedCol(r, col);
        }

        bool relevantChanges(DataRow rEpExp, DataRow rEpExpYear) {
            if (someChangedCol(rEpExp, "idreg", "start", "stop")) return true;
            if (someChangedCol(rEpExpYear, "idacc", "idupb")) return true;
            return false;
        }

        public void updateEntryDetails() {
            foreach (DataRow entryDetail in D.Tables["entrydetail"].Select()) {
                //vede se è cambiato il conto di costo dell'impegno collegato
                DataRow e = D.Tables["epexp"].Select(QHC.CmpEq("idepexp", entryDetail["idepexp"]))[0];
                DataRow ey = D.Tables["epexpyear"].Select(QHC.CmpEq("idepexp", entryDetail["idepexp"]))[0];
                if (!relevantChanges(e, ey)) continue;

                //attua le modifiche effettuate in e-ey alla riga entry
                entryDetail["idupb"] = ey["idupb"];
                entryDetail["idacc"] = ey["idacc"];

                entryDetail["idreg"] = e["idreg"];
                entryDetail["start"] = e["start"];
                entryDetail["stop"] = e["stop"];
            }
        }

        void doAutomaticLink() {
            foreach (var r in D.Tables["epexp"].Select(QHC.AppAnd(QHC.CmpEq("nphase", 2), QHC.IsNull("paridepexp")))) {
                var rPar = getEpExpRow(r["idrelated"], 1);
                if (rPar != null) {
                    r["paridepexp"] = rPar["idepexp"];
                }

                //var parExp = Conn.RUN_SELECT("epexp", "idepexp", null,
                //    QHS.AppAnd(QHS.CmpEq("idrelated", r["idrelated"]), QHS.CmpEq("nphase", 1)), null, false);
                //if (parExp.Rows.Count == 1) {
                //    r["paridepexp"] = parExp.Rows[0]["idepexp"];
                //}
            }

            foreach (var r in D.Tables["epacc"].Select(QHC.AppAnd(QHC.CmpEq("nphase", 2), QHC.IsNull("paridepacc")))) {
                var rPar = getEpAccRow(r["idrelated"], 1);
                if (rPar != null) {
                    r["paridepacc"] = rPar["idepacc"];
                }

                //var parExp = Conn.RUN_SELECT("epacc", "idepacc", null,
                //    QHS.AppAnd(QHS.CmpEq("idrelated", r["idrelated"]), QHS.CmpEq("nphase", 1)), null, false);
                //if (parExp.Rows.Count == 1) {
                //    r["paridepacc"] = parExp.Rows[0]["idepacc"];
                //}
            }
        }

        public bool SaveAll(ep_poster poster) {
            return SaveAll(false,true,poster);
        }

        internal void cancellaParentConFigliInMemoria() {
            foreach (var r in D.Tables["epexp"].Select(QHC.CmpEq("nphase", 1))) {
                if (r.RowState != DataRowState.Added) continue;
                var child = D.Tables["epexp"].Select(QHC.CmpEq("paridepexp", r["idepexp"]));
                if (child.Length == 0) continue;
                if (child.All(x => x.RowState == DataRowState.Added)) {
                    deleteEpBlock(r);
                }
            }

            foreach (var r in D.Tables["epacc"].Select(QHC.CmpEq("nphase", 1))) {
                if (r.RowState != DataRowState.Added) continue;
                var child = D.Tables["epacc"].Select(QHC.CmpEq("paridepacc", r["idepacc"]));
                if (child.Length == 0) continue;
                if (child.All(x => x.RowState == DataRowState.Added)) {
                    deleteEpBlock(r);
                }
            }
        }

        /// <summary>
        /// Delete an ep mov with al children
        /// </summary>
        /// <param name="r"></param>
        void deleteEpBlock(DataRow r) {
            //Cancella la riga  e pure epexpyear  e simili
            string table = r.Table.TableName;
            string idfield = "id" + table;
            object id = r[idfield];
            if (CfgFn.GetNoNullInt32(r["nphase"]) == 1) {
                foreach (DataRow rChild in D.Tables[table].Select(QHC.CmpEq("par" + idfield, id))) {
                    rChild["par" + idfield] = DBNull.Value;
                }
            }

            foreach (var ry in D.Tables[table + "year"].Select(QHC.CmpEq(idfield, id))) {
                ry.Delete();
            }

            foreach (var rv in D.Tables[table + "var"].Select(QHC.CmpEq(idfield, id))) {
                rv.Delete();
            }

            foreach (var rs in D.Tables[table + "sorting"].Select(QHC.CmpEq(idfield, id))) {
                rs.Delete();
            }

            r.Delete();
        }

        //Cancella le fasi parent (in stato added) di cui esiste già la fase figlia collegata ad un altro preimpegno
        internal void cancellaParentConFigliAssegnati() {
            foreach (var r in D.Tables["epexp"].Select(QHC.CmpEq("nphase", 1))) {
                if (r.RowState != DataRowState.Added) continue;
                if (r["idrelated"] == DBNull.Value) continue;

                var nfigliAssegnati = Conn.RUN_SELECT_COUNT("epexp",
                    QHS.AppAnd(QHS.CmpEq("idrelated", r["idrelated"]), QHS.CmpEq("nphase", 2)), false);

                if (nfigliAssegnati == 0) continue;
                deleteEpBlock(r);
            }

            foreach (var r2 in D.Tables["epacc"].Select(QHC.CmpEq("nphase", 1))) {
                if (r2.RowState != DataRowState.Added) continue;
                if (r2["idrelated"] == DBNull.Value) continue;
                var nfigliAssegnati = Conn.RUN_SELECT_COUNT("epacc",
                    QHS.AppAnd(QHS.CmpEq("idrelated", r2["idrelated"]), QHS.CmpEq("nphase", 2)), false);

                if (nfigliAssegnati == 0) continue;
                deleteEpBlock(r2);
            }

        }

        /// <summary>
        /// Cancella le fasi parent (in stato added) cui non corrisponde una fase figlia in memoria
        /// </summary>
        public void cancellaParentSenzaFigli() {
            foreach (DataRow r in D.Tables["epexp"].Select(QHC.CmpEq("nphase", 1))) {
                if (r.RowState != DataRowState.Added) continue;
                if (D.Tables["epexp"].Select(QHC.CmpEq("paridepexp", r["idepexp"])).Length == 0) {
                    deleteEpBlock(r);
                }
            }

            foreach (DataRow r2 in D.Tables["epacc"].Select(QHC.CmpEq("nphase", 1))) {
                if (r2.RowState != DataRowState.Added) continue;
                if (D.Tables["epacc"].Select(QHC.CmpEq("paridepacc", r2["idepacc"])).Length == 0) {
                    deleteEpBlock(r2);
                }
            }
        }

        /// <summary>
        /// Valorizza EPRules ove silent
        /// </summary>
        /// <param name="silent"></param>
        /// <param name="chiediMovimentiParent"></param>
        /// <param name="posting"></param>
        /// <returns></returns>
        internal bool SaveAll(bool silent, bool chiediMovimentiParent, ep_poster posting) {

            //CopiaInfoParent(); //non c'è più questa


            RemoveEmptyDetails();
            //RemoveEmptyEpexp();  task 8317 d'accordo con Emilia
            //RemoveEmptyEpacc();

            //10434 lo commento perchè se no non genera le scritture nelle fatture collegate  a contratti passivi o attivi
            //if (D.Tables["epexp"].Rows.Count == 0 && D.Tables["epacc"].Rows.Count==0) {
            //    MetaFactory.factory.getSingleton<IMessageShower>().Show("Nessun movimento di budget da generare", "Avviso");
            //    return false;
            //}
            cancellaParentConFigliInMemoria();
            doAutomaticLink();
            cancellaParentConFigliAssegnati();

            bool someToLink = false;
            foreach (DataRow r in D.Tables["epexp"].Select(QHC.CmpEq("nphase", 2))) {
                if (r.RowState != DataRowState.Added) continue;
                if (r["paridepexp"] == DBNull.Value) {
                    someToLink = true;
                    continue;
                }

                int parid = CfgFn.GetNoNullInt32(r["paridepexp"]);
                //int minTemp = r.Table.getMinimumTempValue("idepexp");
                DataRow[] found = D.Tables["epexp"].Select(QHC.CmpEq("idepexp", parid));
                if (found.Length == 0) continue;
                if (found[0].RowState == DataRowState.Added) {
                    someToLink = true;
                }
            }

            foreach (DataRow r in D.Tables["epacc"].Select(QHC.CmpEq("nphase", 2))) {
                if (r.RowState != DataRowState.Added) continue;
                if (r["paridepacc"] == DBNull.Value) {
                    someToLink = true;
                    continue;
                }

                int parid = CfgFn.GetNoNullInt32(r["paridepacc"]);
                DataRow[] found = D.Tables["epacc"].Select(QHC.CmpEq("idepacc", parid));
                if (found.Length == 0) continue;
                if (found[0].RowState == DataRowState.Added) {
                    someToLink = true;
                }
            }

            if (someToLink && !silent && chiediMovimentiParent) {//attenzione che mi sta bloccando la transazione qui
                if (!associaMovimentiParent()) {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show("Salvataggio annullato dall'utente.", "Avviso");
                    return false;
                }
            }

            creaMovimentiParent();


            ///TODO: usare classe innerPosting

            PostData.SetPostingOrder(D.Tables["epexp"], "nphase asc");
            PostData.SetPostingOrder(D.Tables["epacc"], "nphase asc");
            PostData Post = Disp.Get(metaNameForPosting).Get_PostData();
            Post.autoIgnore = autoIgnore;
            if (posting != null) {
                
                //Post.innerPosting = true;
                //Post.addMessagesToIgnore(posting.hashMessagesToIgnore());
                //Post.InitClass(D, Conn);                
                //var listaMsg = Post.DO_POST_SERVICE();
                //if (listaMsg.Count>0) {
                //    string what = listaMsg.CanIgnore ? "Avvertimenti" : "Errori";
                //    posting.mergeMessages(listaMsg);
                //    string error = $"{what} nel salvataggio dei movimenti di budget";
                //    if (D.Tables["epexp"].Rows.Count == 0 && D.Tables["epacc"].Rows.Count == 0) {
                //        error = $"{what} nel salvataggio delle scritture";
                //    }
                //    EasyProcedureMessageCollection lm = new EasyProcedureMessageCollection();
                //    if (listaMsg.CanIgnore) {
                //        lm.AddWarning(error);
                //    }
                //    else {
                //        lm.AddDBSystemError(error);
                //    }
                //    posting.mergeMessages(lm);
                //    return listaMsg.CanIgnore;
                //}
                
                var res=  posting.saveData(D, Post);
                EPRules = posting.EPResult;
                return res;
            }
            else {                

                Post.InitClass(D, Conn);
                if (silent) {
	                EPRules = Post.DO_POST_SERVICE();
                    return (EPRules.Count == 0);
                }
                else {
                    if (!Post.DO_POST()) {
	                    string error = "Errore nel salvataggio dei movimenti di budget";
                        if (D.Tables["epexp"].Rows.Count == 0 && D.Tables["epacc"].Rows.Count == 0) {
                            error = "Errore nel salvataggio delle scritture";
                        }                        
                        MetaFactory.factory.getSingleton<IMessageShower>().Show(error, "Errore");
                        return false;
                    }
                }
            }

            return true;
        }

        public ProcedureMessageCollection EPRules;

        /// <summary>
        /// Visualizza le informazioni in fase di salvataggio e permette di agganciare i parent prima di salvare
        /// </summary>
        internal bool associaMovimentiParent() {
            if (D.Tables["epexp"].Rows.Count > 0) {
                FrmImpegniBudget fbudg = new FrmImpegniBudget(Disp, D, false);
                DialogResult res = fbudg.ShowDialog();
                if (res != DialogResult.OK)
                    return false;
                foreach (DataRow r in fbudg.Automatismi.Rows) {
                    object idepexp = r["idepexp"];
                    if (r["livsupid"] == DBNull.Value)
                        continue;
                    DataRow myR = D.Tables["epexp"].Select(QHC.CmpEq("idepexp", idepexp))[0];
                    myR["paridepexp"] = r["livsupid"];
                }
            }

            if (D.Tables["epacc"].Rows.Count > 0) {
                FrmImpegniBudget fbudg = new FrmImpegniBudget(Disp, D, true);
                DialogResult res = fbudg.ShowDialog();
                if (res != DialogResult.OK)
                    return false;
                foreach (DataRow r in fbudg.Automatismi.Rows) {
                    object idepexp = r["idepacc"];
                    if (r["livsupid"] == DBNull.Value)
                        continue;
                    DataRow myR = D.Tables["epacc"].Select(QHC.CmpEq("idepacc", idepexp))[0];
                    myR["paridepacc"] = r["livsupid"];
                }
            }

            return true;
        }


        /// <summary>
        /// Crea dei parent (epexp+epexpyear) per i movimenti che ne dovessero necessitare, ossia quelli di fase 2 con paridepexp null
        /// </summary>
        private void creaMovimentiParent() {
            var epExp = D.Tables["epexp"];
            var epExpYear = D.Tables["epexpyear"];

            var epExpVar = D.Tables["epexpvar"];

            Dictionary<int, DataRow> epyByIdExp = new Dictionary<int, DataRow>();
            foreach (DataRow rr in epExpYear.Rows) {
                if (rr.RowState == DataRowState.Deleted) continue;
                epyByIdExp[(int) rr["idepexp"]] = rr;
            }

            Dictionary<int, List<DataRow>> epVarByIdExp = new Dictionary<int, List<DataRow>>();
            foreach (DataRow rr in epExpVar.Rows) {
                if (rr.RowState == DataRowState.Deleted) continue;
                int idepexp = (int) rr["idepexp"];
                List<DataRow> l = null;
                if (!epVarByIdExp.TryGetValue(idepexp, out l)) {
                    l = new List<DataRow>();
                    epVarByIdExp[idepexp] = l;
                }

                l.Add(rr);
            }

            foreach (var childRow in D.Tables["epexp"]
                .Select(QHC.AppAnd(QHC.CmpEq("nphase", 2), QHC.IsNull("paridepexp")))) {

                var rImpYear = epyByIdExp[(int) childRow["idepexp"]];

                MetaEpExp.SetDefaults(epExp);
                var parentRow = MetaEpExp.Get_New_Row(null, epExp);

                foreach (var field in new[]
                    {"description", "idrelated", "adate", "doc", "docdate", "flagvariation", "idaccmotive"}) {
                    parentRow[field] = childRow[field];
                }

                MetaEpExpYear.SetDefaults(epExpYear);
                var ry = MetaEpExpYear.Get_New_Row(parentRow, epExpYear);
                foreach (var field in new[] {"idacc", "idupb", "amount", "amount2", "amount3", "amount4", "amount5"}) {
                    ry[field] = rImpYear[field];
                }

                MetaEpExpVar.SetDefaults(epExpVar);
                List<DataRow> lVar;
                if (epVarByIdExp.TryGetValue((int) childRow["idepexp"], out lVar)) {
                    foreach (var existingVar in lVar) {
                        var rvy = MetaEpExpVar.Get_New_Row(parentRow, epExpVar);
                        foreach (var field in new[] {
                            "adate", "amount", "amount", "amount2", "amount3", "amount4", "amount5", "description",
                            "nvar",
                            "yvar"
                        }) {
                            rvy[field] = existingVar[field];
                        }
                    }
                }



                parentRow["idreg"] = DBNull.Value;
                parentRow["nphase"] = 1;

                childRow["paridepexp"] = parentRow["idepexp"];
            }

            var epAcc = D.Tables["epacc"];
            var epAccYear = D.Tables["epaccyear"];
            var epEpAccVar = D.Tables["epaccvar"];

            Dictionary<int, DataRow> epyByIdAcc = new Dictionary<int, DataRow>();
            foreach (DataRow rr in epAccYear.Rows) {
                if (rr.RowState == DataRowState.Deleted) continue;
                epyByIdAcc[(int) rr["idepacc"]] = rr;
            }

            Dictionary<int, List<DataRow>> epVarByIdAcc = new Dictionary<int, List<DataRow>>();
            foreach (DataRow rr in epEpAccVar.Rows) {
                if (rr.RowState == DataRowState.Deleted) continue;
                int idepacc = (int) rr["idepacc"];
                List<DataRow> l = null;
                if (!epVarByIdAcc.TryGetValue(idepacc, out l)) {
                    l = new List<DataRow>();
                    epVarByIdAcc[idepacc] = l;
                }

                l.Add(rr);
            }

            foreach (var childRow in D.Tables["epacc"]
                .Select(QHC.AppAnd(QHC.CmpEq("nphase", 2), QHC.IsNull("paridepacc")))) {
                var rImpYear = epyByIdAcc[(int) childRow["idepacc"]];
                MetaEpAcc.SetDefaults(epAcc);
                var parentRow = MetaEpAcc.Get_New_Row(null, epAcc);

                foreach (var field in new[]
                    {"description", "idrelated", "adate", "doc", "docdate", "flagvariation", "idaccmotive"}) {
                    parentRow[field] = childRow[field];
                }

                MetaEpAccYear.SetDefaults(epAccYear);
                var ry = MetaEpAccYear.Get_New_Row(parentRow, epAccYear);
                foreach (var field in new[] {"idacc", "idupb", "amount", "amount2", "amount3", "amount4", "amount5"}) {
                    ry[field] = rImpYear[field];
                }

                MetaEpAccVar.SetDefaults(epEpAccVar);
                List<DataRow> lVar;
                if (epVarByIdAcc.TryGetValue((int) childRow["idepacc"], out lVar)) {

                    foreach (var existingVar in lVar) {
                        var rvy = MetaEpAccVar.Get_New_Row(parentRow, epEpAccVar);
                        foreach (var field in new[] {
                            "adate", "amount", "amount", "amount2", "amount3", "amount4", "amount5", "description",
                            "nvar",
                            "yvar"
                        }) {
                            rvy[field] = existingVar[field];
                        }
                    }
                }

                parentRow["idreg"] = DBNull.Value;
                parentRow["nphase"] = 1;
                childRow["paridepacc"] = parentRow["idepacc"];
            }
        }


        public void EffettuaClassificazioniImpegno(
            decimal amount, DataRow RowForIDSOR, DataRow rEpExp) {
            //AddEpExpSorting(amount, BudgetFunction.GetIDSor(RowForIDSOR), rEpExp);			
        }


    }
}
