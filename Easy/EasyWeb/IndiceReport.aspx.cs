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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using metadatalibrary;
using metaeasylibrary;
using HelpWeb;
using funzioni_configurazione;

namespace EasyWebReport {
    //menu - menulink - sub e le foglie: topline (primo figlio) , niente le altre
    public class MyMenuClass {
        string text = null;
        string classfun = null;
        List <MyMenuClass> submenu = new List<MyMenuClass>() ; 
        string tag = null;
        bool canskip = false;
        public MyMenuClass(string text, string classfun, string tag, bool canskip) {
            this.text = text;
            this.classfun = classfun;
            this.tag = tag;
            this.canskip = canskip;
        }
        public MyMenuClass(string text, bool canskip) {
            this.text = text;
            this.canskip = canskip;
        }
        public MyMenuClass(string text) {
            this.text = text;
        }

        public MyMenuClass(string text, string classfun, string tag) {
            this.text = text;
            this.classfun = classfun;
            this.tag = tag;
        }

        public static void RegisterScript(Page P, Button B) {
            string ScriptString = "";
            ScriptString += "function dMF(classfun,tag){";
            ScriptString += "__doPostBack('_ctl0:CHP_PC:HwMenuButton',classfun+':'+tag);\r\n";
            //ScriptString += "   " + P.ClientScript.GetPostBackEventReference(B, "classfun+':'+tag") + ";\r\n";
            ScriptString += "return true;\r\n";

            ScriptString += "}\r\n";

            string ScriptID = "dMF()";

            if (!P.ClientScript.IsClientScriptBlockRegistered(typeof(Page), ScriptID))
                P.ClientScript.RegisterClientScriptBlock(typeof(Page), ScriptID, ScriptString, true);
        }

        public void AddChild(MyMenuClass MenuItem) {
            submenu.Add(MenuItem);
        }
        public HtmlGenericControl GetControl() {
            return GetControl(0, true);
        }

        public void Optimize() {
            foreach (MyMenuClass C in submenu) C.Optimize();

            if (submenu.Count != 1) return;
            if (!((MyMenuClass)submenu[0]).canskip) return;

            submenu = ((MyMenuClass)submenu[0]).submenu;

        }

        HtmlGenericControl GetControl(int level, bool first) {
            HtmlGenericControl curr = GetCurr(level, first);
            HtmlGenericControl childs = GetChildren(level);
            if (curr == null) return childs;
            if (childs == null) return curr;
            curr.Controls.Add(childs);
            return curr;
        }

        HtmlGenericControl GetChildren(int level) {
            if (submenu.Count == 0) return null;
            HtmlGenericControl container = new HtmlGenericControl("ul");
            if (level == 0) {
                container.Attributes["class"] = "sm sm-blue";
                container.ID = "main-menu";
            }
            bool first = true;
            HtmlGenericControl last = null;
            foreach (MyMenuClass child in submenu) {
                HtmlGenericControl c = child.GetControl(level + 1, first);
                first = false;
                container.Controls.Add(c);
                last = c;
            }
            //if (last!=null) last.Attributes["class"] = "last";

            if (level == 0) {
                //HtmlGenericControl maindiv = new HtmlGenericControl("div");
                //maindiv.ID = "main-menu";
                //maindiv.Attributes["class"] = "sm sm-blue"; //
                //maindiv.Controls.Add(container);
                //return maindiv;
            }
            return container;
        }

        //menu - menulink - sub e le foglie: topline (primo figlio) , niente le altre
        HtmlGenericControl GetCurr(int level, bool first) {
            if (text == null) return null;
            HtmlGenericControl c = new HtmlGenericControl("li");

            HtmlGenericControl a = new HtmlGenericControl("a");
            //HtmlGenericControl span = new HtmlGenericControl("span");
            //a.Controls.Add(span);
            c.Controls.Add(a);
            a.Attributes["href"] = "#";
            a.InnerText = text;
            if (classfun != null && tag != null)
                a.Attributes["onclick"] = "return dMF(\"" + classfun + "\",\"" + tag + "\");";

            //if (first && level > 1) {
            //    c.Attributes["class"] = "topline";
            //}
            //if (level <= 1) {
            //    a.Attributes["class"] = "menulink";
            //    return c;
            //}
            if (submenu.Count > 0) {
                //a.Attributes["class"] = "has-sub";
                return c;
            }
            return c;
        }
    }

    /// <summary>
    /// Summary description for IndiceReport.
    /// </summary>
    public partial class IndiceReport : System.Web.UI.Page {

        bool Atto = true;
        bool AttoBudget = true;
        bool BuonoOrdine = true;
        bool VarPrev = true;
        bool ViterboVarPrev = true;
        bool VarIniziale = true;
        bool VarPrevBudget = true;
        bool VarInizialeBudget = true;
        bool Vetrina = true;
        bool Prenota = true;
        bool PrenotaMyTeam = true;
        bool PrenotaWait = true;
        bool canChangeRole = true;
        bool Missioni = true;
        bool CataniaMissioni = true;
        bool MissioniAuth = true;
        bool MissioniMyTeam = true;
        bool CanChangePassword = true;
        bool RicaricaCard = true;
        bool GestisciCard = true;
        bool Upb = true;
        bool Finanziamento = true;
        bool IngressoMagazzino = true;

        DataTable ModRepWeb = null;
        DataTable ExportWeb = null;
        private string myReportName = "";
        private string myExportName = "";
        Button HiddenBtn;

        string ButtonTag = null;
        protected void HwMenuButton_Click(object sender, EventArgs e) {
            if (ButtonTag == null) return;
            string tipo = ButtonTag.Substring(0, 1).ToLower();
            string tag = ButtonTag.Substring(2);
            if (tipo == "f") DoFunction(tag);
            if (tipo == "e") DoExport(tag);
            if (tipo == "r") DoReport(tag);
            if (tipo == "s") {
                if (tag == "disconnect") Disconnect();
                if (tag == "changerole") ChangeRole();
                if (tag == "changepwd") ChangePwd();
                if (tag == "ingressomagazzino") StampaCheckIn();
            }

        }

        //attenzione
        void DoFunction(string tag) {
            string[] parts = tag.Split('.');
            if (parts.Length < 2) return;
            string meta = parts[0];
            string edittye = parts[1];
            ApplicationState APS = ApplicationState.GetApplicationState(this);
            if (APS == null) {
                MetaPage.SessionTimeOut(this);
                return;
            }
            MetaData M = APS.Dispatcher.Get(meta);
            M.edit_type = edittye;
            APS.CallPage(this, M, false);
        }

        void DoExport(string tag) {
            ApplicationState APS = ApplicationState.GetApplicationState(this);
            if (APS == null) return;
            MetaData M = APS.Dispatcher.Get("export");
            M.edit_type = "default";
            M.ExtraParameter = tag;
            APS.CallPage(this, M, false);
        }

        void DoReport(string tag) {
            ApplicationState APS = ApplicationState.GetApplicationState(this);
            MetaData M = APS.Dispatcher.Get("resultparameter");
            M.edit_type = "default";
            M.ExtraParameter = tag;
            APS.CallPage(this, M, false);
        }


        protected override void RaisePostBackEvent(IPostBackEventHandler sourceControl, string eventArgument) {
            if (sourceControl == HwMenuButton) ButtonTag = eventArgument;
            base.RaisePostBackEvent(sourceControl, eventArgument);
        }
        //HtmlGenericControl StartVoceMenu(HtmlGenericControl parent, string testo,string classfun, string buttontag, EventHandler handler) {
        //    HtmlGenericControl LI = new HtmlGenericControl("li");
        //    LI.InnerText = testo;
        //    parent.Controls.Add(LI);
        //    LI.Attributes["onClick"] = "doMenuFunction(\"" + classfun + "\",\"" + buttontag + "\"); return true;";
        //    Page.ClientScript.GetCallbackEventReference(HwMenuButton.ID, buttontag, null, null, null, true);
        //    return LI;
        //}
        //LiteralControl StopVoceMenu(LiteralControl parent) {
        //}
        protected void Page_Load(object sender, System.EventArgs e) {
            /////////////////
            WebLog.Log(this, "Visualizza IndiceReport.aspx");
            ////////////////
            MyMenuClass.RegisterScript(this, HwMenuButton);

            MetaMasterBootstrap master = Page.Master as MetaMasterBootstrap;
            master?.setUniversita(Session["system_config_nome_universita"] as string);

            bool IsManager = (Session["CodiceResponsabile"] != null ? true : false);

            if (!IsManager) {
                PrenotaWait = false;
                PrenotaMyTeam = false;
                RicaricaCard = false;
                GestisciCard = false;
                IngressoMagazzino = false;

            }






            //btnRegistroRichiesteBuonoOrdine.Attributes.Add("onclick", "aprifin();");
            if (Session["Cart"] != null) {
                ApplicationState APS = ApplicationState.GetApplicationState(this);
                MetaData M = APS.Dispatcher.Get("booking");
                M.edit_type = "defaultnew02";
                APS.CallPage(this, M, false);
            }

            if (Session["UserPar"] != null) {
                if (Session["ModuleReportRow"] != null) {
                    // Report
                    string F = "window.open('WebPDFView.aspx');";

                    if (!Page.ClientScript.IsClientScriptBlockRegistered(typeof(Page), "openwin"))
                         Page.ClientScript.RegisterClientScriptBlock(
                                typeof(Page), "openwin", F, true);
                    //if (Session["PageToCameBack"] != null) {
                    //    string url = Session["PageToCameBack"].ToString();
                    //    Session["PageToCameBack"] = null;
                    //    Response.Redirect(url);
                    //    return;
                    //}
                }
                else {
                    // Export
                    string F = "window.open('ExportView.aspx');";
                    if (!Page.ClientScript.IsClientScriptBlockRegistered(typeof(Page), "openwin"))
                        Page.ClientScript.RegisterClientScriptBlock(
                                typeof(Page), "openwin", F, true);

                }
                //ApplicationState APS = ApplicationState.GetApplicationState(this);
                //MetaData M = APS.Dispatcher.Get("webpdf");
                //M.edit_type = "view";
                //APS.CallPage(this, M, false);
            }
            DataAccess UsrConn = GetVars.GetUserConn(this);
            if (((UsrConn == null) || (UsrConn.Open() == false))) return;
            string tipoutente = Session["TipoUtente"] as string;

            //if (tipoutente != "utente" && tipoutente != "Utente LDAP") {
            if (UsrConn.GetUsr("HasVirtualUser") == null && tipoutente != "utente") {
                Atto = false;
                AttoBudget = false;
                BuonoOrdine = false;
                VarPrev = false;
                ViterboVarPrev = false;
                VarIniziale = false;
                VarPrevBudget = false;
                VarInizialeBudget = false;
                Vetrina = false;
                Prenota = false;
                IngressoMagazzino = false;
                PrenotaMyTeam = false;
                PrenotaWait = false;
                Missioni = false;
                CataniaMissioni = false;
                MissioniAuth = false;
                MissioniMyTeam = false;
                canChangeRole = false;
                RicaricaCard = false;
                GestisciCard = false;
                Upb = false;
                Finanziamento = false;
            }

            if (tipoutente == "Utente LDAP" || tipoutente == "Utente SSO") {
                CanChangePassword = false;
            }

            if (RicaricaCard && UsrConn.RUN_SELECT_COUNT("lcard", null, false) == 0) {
                RicaricaCard = false;
            }
            //if (GestisciCard && UsrConn.RUN_SELECT_COUNT("lcard", null, false) == 0) {
            //    GestisciCard = false;
            //}


            MyMenuClass myMenu = new MyMenuClass(null);

            CheckSecurityOnMenuButtons(myMenu);



            string filter = UsrConn.GetSys("filterrule") as string;
            filter = GetData.MergeFilters(filter, "(webvisible='S')");
            if (tipoutente == "responsabile") {
                filter = filter + "AND" +
                    "(reportname in (select reportname from reportparameter where datasource='manager'))";
            }
            if (tipoutente == "fornitore") {
                filter = filter + "AND" +
                    "(reportname in (select reportname from reportparameter where datasource='registryreference'))";
            }
            ModRepWeb = UsrConn.RUN_SELECT("report", "*", "modulename,groupname", filter, null, true);

            UsrConn.Security.DeleteAllUnselectable(ModRepWeb);
            QueryHelper QHS = UsrConn.GetQueryHelper();
            CQueryHelper QHC = new CQueryHelper();
            object idflowchart = UsrConn.GetSys("idflowchart");
            if (idflowchart != null && idflowchart != DBNull.Value) {
                //Applica filtro su stampe in base a flowchart
                DataTable MyMod = UsrConn.RUN_SELECT("flowchartmodulegroup", "*", null,
                        QHS.CmpEq("idflowchart", idflowchart), null, false);
                if (MyMod != null && MyMod.Columns.Count > 0) {
                    MyMod.CaseSensitive = false;
                    foreach (DataRow RM in ModRepWeb.Select()) {
                        if (RM["modulename"].ToString() == "" || RM["groupname"].ToString() == "") continue;
                        string existfilter = QHC.AppAnd(QHC.CmpEq("modulename", RM["modulename"]),
                                        QHC.CmpEq("groupname", RM["groupname"]));
                        if (MyMod.Select(existfilter).Length > 0) continue;
                        RM.Delete();
                    }
                }
            }
            ModRepWeb.AcceptChanges();

            string lastmodule = "";
            string lastgroupname = "";

            //Visualizza l'elenco dei report disponibili
            if (ModRepWeb != null && ModRepWeb.Rows.Count > 0) {
                MyMenuClass menuReport = new MyMenuClass("Report");
                myMenu.AddChild(menuReport);
                MyMenuClass menuModule = null;
                MyMenuClass menuGruppo = null;
                foreach (DataRow DrReport in ModRepWeb.Rows) {
                    if (DrReport["modulename"].ToString().ToLower() != lastmodule) {
                        menuModule = new MyMenuClass(DrReport["modulename"].ToString());
                        menuReport.AddChild(menuModule);
                        lastmodule = DrReport["modulename"].ToString().ToLower();

                        menuGruppo = new MyMenuClass(DrReport["groupname"].ToString(), true);
                        menuModule.AddChild(menuGruppo);
                        lastgroupname = DrReport["groupname"].ToString().ToLower();
                    }

                    if (DrReport["groupname"].ToString().ToLower() != lastgroupname) {
                        menuGruppo = new MyMenuClass(DrReport["groupname"].ToString(), true);
                        menuModule.AddChild(menuGruppo);
                        lastgroupname = DrReport["groupname"].ToString().ToLower();
                    }


                    MyMenuClass voce = new MyMenuClass(DrReport["Description"].ToString(), "r",
                        DrReport["ModuleName"].ToString() + "." + DrReport["ReportName"].ToString());
                    menuGruppo.AddChild(voce);

                }
            }

            string filterexpresp = "(webvisible='S') ";
            if (Session["CodiceResponsabile"] != null) {
                filterexpresp = filterexpresp + " AND" +
                    "(procedurename in (select procedurename from exportfunctionparam where datasource='manager'))";
            }
            if (Session["CodiceFornitore"] != null) {
                filterexpresp = filterexpresp + " AND" +
                    "(procedurename in (select procedurename from exportfunctionparam where datasource='registryreference'))";
            }
            ExportWeb = UsrConn.RUN_SELECT("exportfunction", "*", "modulename", filterexpresp, null, true);

            UsrConn.Security.DeleteAllUnselectable(ExportWeb);
            if (idflowchart != null && idflowchart != DBNull.Value) {
                //Applica filtro su stampe in base a flowchart
                DataTable MyMod = UsrConn.RUN_SELECT("flowchartexportmodule", "*", null,
                        QHS.CmpEq("idflowchart", idflowchart), null, false);
                if (MyMod != null && MyMod.Columns.Count > 0) {
                    MyMod.CaseSensitive = false;
                    foreach (DataRow RM in ExportWeb.Select()) {
                        if (RM["modulename"].ToString() == "") continue;
                        string existfilter = QHC.CmpEq("modulename", RM["modulename"]);
                        if (MyMod.Select(existfilter).Length > 0) continue;
                        RM.Delete();
                    }
                }
            }
            ExportWeb.AcceptChanges();

            lastmodule = "";

            //Visualizza l'elenco delle esportazioni disponibili
            if (ExportWeb != null && ExportWeb.Rows.Count > 0) {
                MyMenuClass menuExport = new MyMenuClass("Esportazioni");
                myMenu.AddChild(menuExport);
                MyMenuClass menuExpModule = null;
                //MyMenuClass menuExpGruppo;


                foreach (DataRow DrExport in ExportWeb.Rows) {
                    if (DrExport["modulename"].ToString().ToLower() != lastmodule) {
                        menuExpModule = new MyMenuClass(DrExport["modulename"].ToString(), null, null);
                        menuExport.AddChild(menuExpModule);
                        lastmodule = DrExport["modulename"].ToString().ToLower();
                    }

                    MyMenuClass voce = new MyMenuClass(DrExport["Description"].ToString(), "e",
                               DrExport["procedurename"].ToString() + "." + DrExport["Description"].ToString());
                    menuExpModule.AddChild(voce);

                }
            }

            /*
            MyMenuClass sys = new MyMenuClass("Sistema");
            myMenu.AddChild(sys);
            sys.AddChild(new MyMenuClass("Disconnetti", "s", "disconnect"));
            if (canChangeRole) sys.AddChild(new MyMenuClass("Cambio Ruolo", "s", "changerole"));
            if (CanChangePassword) sys.AddChild(new MyMenuClass("Cambio Password", "s", "changepwd"));
            */


            myMenu.AddChild(new MyMenuClass("Disconnetti", "s", "disconnect"));
            if (canChangeRole) myMenu.AddChild(new MyMenuClass("Cambio Ruolo", "s", "changerole"));
            if (CanChangePassword) myMenu.AddChild(new MyMenuClass("Cambio Password", "s", "changepwd"));


            myMenu.Optimize();

            MenuPanel.Controls.Add(myMenu.GetControl());
            UsrConn.Close();
            //WebLog.Log(this,"Visualizza Elenco Report disponibili (" + ModRepWeb.Rows.Count.ToString() + ")");

        }


        private void RigaClick(object sender, EventArgs e) {
        }


        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e) {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {

        }
        #endregion


        private void CheckSecurityOnMenuButtons(MyMenuClass myMenu) {
            string filter = "";
            DataAccess UsrConn = GetVars.GetUserConn(this);
            if (((UsrConn == null) || (UsrConn.Open() == false))) return;

            CQueryHelper QHC = new CQueryHelper();
            QueryHelper QHS = UsrConn.GetQueryHelper();

            string fitermenu = QHS.FieldInList("metadata",
                QHS.List("upb", "underwriting", "mandate", "finvar", "accountvar", "enactment", "accountenactment", "itineration"));
            DataTable DT = UsrConn.RUN_SELECT("menu", "*", "ordernumber,paridmenu", fitermenu, null, false);


            UsrConn.Security.DeleteAllUnselectable(DT);

            DataTable webconfig = UsrConn.RUN_SELECT("web_config", "*", null, null, null, false);
            DataRow rwebconf = webconfig.Rows[0];
            bool menuitinerationlist = (rwebconf["menuitinerationlist"].ToString().ToUpper() == "S");
            bool menuitinerationinsert = (rwebconf["menuitinerationinsert"].ToString().ToUpper() == "S");

            // UPB
            filter = QHC.CmpEq("metadata", "upb");
            var DR = DT.Select(filter);
            if (DR.Length == 0) {
                Upb = false;
            }


            //Finanziamento
            filter = QHC.CmpEq("metadata", "underwriting");
            DR = DT.Select(filter);
            if (DR.Length == 0) {
                Finanziamento = false;
            }


            // Buono D'ordine
            filter = QHC.CmpEq("metadata", "mandate");
            DR = DT.Select(filter);
            if (DR.Length == 0) {
                BuonoOrdine = false;
            }

            // Variazioni di Bilancio
            filter = QHC.CmpEq("metadata", "finvar");
            DR = DT.Select(filter);
            if (DR.Length == 0) {
                VarPrev = false;
                VarIniziale = false;
            }

            // TODO: Verificare l'utilit‡ di questa condizione!
            // Variazioni di Bilancio per Viterbo
            //Filter = QHC.CmpEq("metadata", "viterbo_finvar");
            //DR = DT.Select(Filter);
            //if (DR.Length == 0) {
            //    VarPrev = false;
            //    VarIniziale = false;
            //}

            // Variazioni di Budget
            filter = QHC.CmpEq("metadata", "accountvar");
            DR = DT.Select(filter);
            if (DR.Length == 0) {
                VarPrevBudget = false;
                VarInizialeBudget = false;
            }
            // Atto Amministrativo
            filter = QHC.CmpEq("metadata", "enactment");
            DR = DT.Select(filter);
            if (DR.Length == 0) {
                Atto = false;
            }
            // Atto Amministrativo di Budget
            filter = QHC.CmpEq("metadata", "accountenactment");
            DR = DT.Select(filter);
            if (DR.Length == 0) {
                AttoBudget = false;
            }
            ////Ricarica cards
            //Filter = QHC.CmpEq("metadata", "lcardvar");
            //DR = DT.Select(Filter);
            //if (DR.Length == 0) RicaricaCard = false;

            MyMenuClass bil = null;
            if (Upb ||  Finanziamento) {
                bil = new MyMenuClass("Bilancio", null, null);

                if (Finanziamento) {
                    MyMenuClass m = new MyMenuClass("Finanziamento", "f", "underwriting.defaultnew02");
                    bil.AddChild(m);
                }
                if (Upb) {
                    MyMenuClass m = new MyMenuClass("UPB", "f", "upb.defaultnew02");
                    bil.AddChild(m);
                }

                
            }

            MyMenuClass ep = null;
            if (VarPrevBudget || VarInizialeBudget || AttoBudget) {

                ep = new MyMenuClass("E/P", null, null);
                if (VarInizialeBudget) {
                    MyMenuClass m = new MyMenuClass("Previsioni iniziali di Budget", "f", "accountvar.inizialenew02");
                    ep.AddChild(m);
                }

                if (VarPrevBudget) {
                    MyMenuClass m = new MyMenuClass("Variazione previsioni di Budget", "f", "accountvar.defaultnew02");
                    ep.AddChild(m);
                }
                if (AttoBudget) {
                    MyMenuClass m = new MyMenuClass("Atto Amministrativo di Budget", "f", "accountenactment.default");
                    ep.AddChild(m);
                }

            }

            MyMenuClass fin = null;
            //if (BuonoOrdine || VarPrev || Atto || RicaricaCard || GestisciCard || VarIniziale) {
            if (BuonoOrdine || VarPrev || ViterboVarPrev  || Atto || RicaricaCard || GestisciCard || VarIniziale) {
                fin = new MyMenuClass("Finanziario", null, null);
                if (BuonoOrdine) {
                    MyMenuClass m = new MyMenuClass("Richiesta buono d'ordine", "f", "mandate.defaultnew02");
                    fin.AddChild(m);
                }
                if (VarIniziale) {
                    MyMenuClass m = new MyMenuClass("Previsioni iniziali", "f", "finvar.inizialenew02");
                    fin.AddChild(m);
                }

                if (VarPrev) {
                    MyMenuClass m = new MyMenuClass("Variazione previsioni", "f", "finvar.defaultnew02");
                    fin.AddChild(m);
                }

                // Inserita per Viterbo
                if (ViterboVarPrev  && Session["system_config_previsioni_viterbo"] as string =="S") {
                    MyMenuClass m = new MyMenuClass("Viterbo - Variazione previsioni", "f", "viterbo_finvar.default");

                    // MyMenuClass m = new MyMenuClass("Viterbo - Variazione previsioni", "f", "viterbo_finvar_default");
                    //MyMenuClass m = new MyMenuClass("Viterbo - Variazione previsioni", "f", "viterbofinvar.default");
                    fin.AddChild(m);
                }

                if (Atto) {
                    MyMenuClass m = new MyMenuClass("Atto Amministrativo", "f", "enactment.defaultnew02");
                    fin.AddChild(m);
                }

                if (RicaricaCard) {
                    MyMenuClass m = new MyMenuClass("Ricarica card", "f", "lcardvar.default");
                    fin.AddChild(m);
                }
                if (GestisciCard) {
                    MyMenuClass m = new MyMenuClass("Gestisci card", "f", "lcard.default");
                    fin.AddChild(m);
                }
            }


            //Vetrina
            //Filter = QHC.CmpEq("metadata", "booking");
            string allowbooking = "'S'";
            if (UsrConn.GetUsr("ric_magazzino") != null) {
                allowbooking = UsrConn.GetUsr("ric_magazzino").ToString().ToUpper();
            }
            if (allowbooking != "'S'") {
                Prenota = false;
                PrenotaMyTeam = false;
                PrenotaWait = false;
                Vetrina = false;
                IngressoMagazzino = false;
            }


            //if (UsrConn.GetUsr("missioni") != null) {
            //    string managecompensi = UsrConn.GetUsr("missioni").ToString();
            //}
            // Missioni
            filter = QHC.CmpEq("metadata", "itineration");
            DR = DT.Select(filter);
            if (DR.Length == 0) {
                Missioni = false;
                MissioniAuth = false;
                MissioniMyTeam = false;
                CataniaMissioni = false;
            }
            else {
                if (Session["CodiceResponsabile"] == null) MissioniMyTeam = false;
                int idauthagency = GetImpersonatedAuthAgency(UsrConn);
                if (idauthagency == 0) {
                    MissioniAuth = false;
                }
            }

            MyMenuClass mag = null;
            if (Prenota || PrenotaMyTeam || PrenotaWait || Vetrina || IngressoMagazzino) {
                mag = new MyMenuClass("Magazzino");

                if (Vetrina) {
                    MyMenuClass m = new MyMenuClass("Vetrina", "f", "showcase.defaultnew02");
                    mag.AddChild(m);
                }
                if (Prenota) {
                    MyMenuClass m = new MyMenuClass("Mie Prenotazioni", "f", "booking.defaultnew02");
                    mag.AddChild(m);
                }
                if (PrenotaMyTeam) {
                    MyMenuClass m = new MyMenuClass("Prenotazioni del mio Team", "f", "booking.myteamnew02");
                    mag.AddChild(m);
                }
                if (PrenotaWait) {
                    MyMenuClass m = new MyMenuClass("Prenotazioni da autorizzare", "f", "bookingdetail.defaultnew02");
                    mag.AddChild(m);
                }
                if (IngressoMagazzino) {
                    MyMenuClass m = new MyMenuClass("Stampa Check In magazzino", "s", "ingressomagazzino");
                    mag.AddChild(m);
                }


            }

            MyMenuClass mis = null;
            if (MissioniMyTeam || MissioniAuth ||  Missioni  || CataniaMissioni) {
                mis = new MyMenuClass("Missioni");
                if (Missioni) {
                    if (true || menuitinerationinsert) {
                        MyMenuClass m1 = new MyMenuClass("Richiesta Missione", "f", "itineration.autoinsertnew02");
                        mis.AddChild(m1);
                    }
                    if (true || menuitinerationlist) {
                        MyMenuClass m2 = new MyMenuClass("Elenco Missioni", "f", "itineration.autolistnew02");
                        mis.AddChild(m2);
                    }

                    MyMenuClass m = new MyMenuClass("Missioni", "f", "itineration.defaultnew02");
                    mis.AddChild(m);
                }

                if (MissioniMyTeam) {
                    MyMenuClass m = new MyMenuClass("Missioni sui miei fondi", "f", "itineration.myteamnew02");
                    mis.AddChild(m);
                }
                if (MissioniAuth) {
                    MyMenuClass m = new MyMenuClass("Autorizza Missioni", "f", "itinerationauthview.defaultnew02");
                    mis.AddChild(m);
                }
                if (CataniaMissioni) {
                    MyMenuClass m = new MyMenuClass("Missioni(Catania)", "f", "itineration.ct_default");
                    mis.AddChild(m);
                }
            }

            if (bil != null || fin != null || ep != null || mag != null || mis != null) {
                MyMenuClass funz = new MyMenuClass("Funzioni");
                myMenu.AddChild(funz);

                if (bil != null) funz.AddChild(bil);
                if (fin != null) funz.AddChild(fin);
                if (mag != null) funz.AddChild(mag);
                if (mis != null) funz.AddChild(mis);
                if (ep != null)  funz.AddChild(ep);
            }
            // Vanno aggiunti i filtri per la vetrina e la prenotazione
            UsrConn.Close();
            return;
        }


        public int GetImpersonatedAuthAgency(DataAccess Conn) {
            QueryHelper QHS;
            string idflowchart;
            if (Conn.GetSys("idflowchart") == null && Conn.GetSys("idflowchart").ToString() == "") return 0;

            // lookup idauthagency from idflowchart
            idflowchart = Conn.GetSys("idflowchart").ToString();
            QHS = Conn.GetQueryHelper();
            string filter;
            filter = QHS.CmpEq("idflowchart", idflowchart);
            DataTable DT = Conn.RUN_SELECT("flowchartauthagency", "*", null, filter, null, false);

            if (DT == null || DT.Rows.Count == 0) return 0;

            return CfgFn.GetNoNullInt32(DT.Rows[0]["idauthagency"]);
        }


        protected void ChangeRole() {
            Response.Redirect("CambioRuolo.aspx");
        }

        protected void ChangePwd() {
            Response.Redirect("CambioPassword.aspx");
        }
        void Disconnect() {
            ApplicationState Ap = ApplicationState.GetApplicationState(this);
            Ap.Conn.Close();
            Ap.Conn.Destroy();

            ApplicationState.ClearApplicationState(this);

            Response.Redirect(Session["SavedHomePage"].ToString());


        }

        

        void StampaCheckIn() {
            DataAccess Conn = GetVars.GetUserConn(this);
            if (((Conn == null) || (Conn.Open() == false))) return;       
                 
            if (Conn.GetUsr("cf") == null) {
                Conn.Close();
                return;
            }

            string cf=Conn.GetUsr("cf").ToString();
            //Crea un datatable con i parametri per la stampa
            
            DataTable T = new DataTable("tabella");
            T.Columns.Add("cf", typeof(string));
            DataRow R = T.NewRow();
            R["cf"] = cf;
            T.Rows.Add(R);
            QueryHelper QHS = Conn.GetQueryHelper();
            DataTable Modulereport = Conn.RUN_SELECT("report", "*", null, QHS.CmpEq("reportname", "rpt_ingressomagazzino"), null, true);

            Conn.Close();
            Session["UserPar"] = T;
            Session["ModuleReportRow"] = Modulereport.Rows[0];
            //Session["PageToCameBack"] = this.Request.Url;

            string F = "window.open('WebPDFView.aspx');";
            if (!Page.ClientScript.IsClientScriptBlockRegistered(typeof(Page), "openwin"))
                 Page.ClientScript.RegisterClientScriptBlock(
                        typeof(Page), "openwin", F, true);            

        }
    }
}
