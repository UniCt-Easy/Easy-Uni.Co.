
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
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using HelpWeb;
using metadatalibrary;
using metaeasylibrary;
using System.Collections.Generic;

public partial class MetaMasterBootstrap: System.Web.UI.MasterPage, MetaPageMaster {

    public delegate void menuHome();
    public event menuHome MenuHome;

    public delegate void menuIndietro();
    public event menuIndietro MenuIndietro;

    public delegate void menuAvanti();
    public event menuAvanti MenuAvanti;

    public delegate void menuInfo();
    public event menuInfo MenuInfo;




    protected override void OnInit(EventArgs e) {
        base.OnInit(e);
        //if (mainlist == null) return;
        //Controls.Add(mainlist);
        pendingCommand = null;

        //E' necessario che siano qui, prima che possano essere chiamati i metodi isclientconfirm etc, da metapage.onload
        if (Request["__EVENTARGUMENT"] == "accept_message")
            myIsClientConfirm = true;
        if (Request["__EVENTARGUMENT"] == "accept_rules")
            myIsClientIgnoreRules = true;
        if (Request["__EVENTARGUMENT"] == "reject_rules")
            myIsClientRejectRules = true;
    }

    public void Page_Load(object sender, EventArgs e) {
        ReleaseMessages();
        //Carico gli eventi JavaScript che sostituiscono le immagini dei pulsanti del Menu.
        //Questi eventi vengono eseguiti lato client

        //lblNomeUniversita.Text = Session["system_config_nome_universita"] as string;
        //Eventi lato server
        //Gli eventi OnClick degli ImageButton che verranno eseguiti sul server,
        //devono essere aggiunti nel codice ASPX altrimenti non partono.
        //ovvero non posso fare    btnMenuAvanti.Attributes.Add("onclick","btnMenuAvanti_Click");
        //ma nel codice aspx devo aggiungere    onclick="btnMenuAvanti_Click"
        //btnSubmit.Click += btnSubmit_Click;


        lblRuolo.Text = "";

        string tipoUtente = Session["TipoUtente"] as string;

        if (tipoUtente == "utente") {
            lblNomeUtente.Text = Session["utente"].ToString().ToUpper();
            lblRuolo.Text = "utente";
        }
        else {
            if (tipoUtente == "fornitore") {
                lblNomeUtente.Text = Session["Fornitore"].ToString().ToUpper();
                lblRuolo.Text = "fornitore";
            }
            else if (tipoUtente == "responsabile") {
                lblNomeUtente.Text = Session["Responsabile"].ToString().ToUpper();
                lblRuolo.Text = "responsabile";
            }
            else if (tipoUtente == "Utente LDAP") {
                lblNomeUtente.Text = Session["Utente"].ToString();
                lblRuolo.Text = "utente";
            }
            else if (tipoUtente == "Utente SSO") {
                lblNomeUtente.Text = Session["Utente"].ToString();
                lblRuolo.Text = "utente";
            }
        }
        if (Session["SavedFlowChart"] != null)
            lblRuolo.Text = Session["SavedFlowChart"].ToString();

        if ((Session["Dipartimento"] == null) || (Session["Dipartimento"].ToString() == "")) {
            //lblNomeUniversita.Visible = false;
            lblDipartimento.Visible = false;
            CPH_InfoUtente.Visible = false;
            //Dovrei nascondere anche il logo, ma attualmente è un Html Control, dunque non visibile da C#
            //Va sostituito con un controllo ASP, in modo che possa gestirlo da codice, e dunque implementare 
            //il caricamento personalizzato dell'immagine del logo.
        }
        else {
            lblDipartimento.Text = Session["Dipartimento"].ToString();
            CPH_InfoUtente.Visible = true;
        }

        if (Session["nome_universita"] != null) {
            lblNomeUniversita.Text = Session["nome_universita"].ToString();
        }

        //ImageButton5.Attributes.Add("onmouseover", "alert('ciao');");



    }

    public string SavedFocus() {
        object O = null;
        if (IsPostBack)
            O = Page.Request.Form[TxSavedFocus.UniqueID];
        if (O == null)
            O = TxSavedFocus.Text.ToString().ToUpper();
        if (O == null)
            return "";
        return O.ToString();

    }


    public bool IsListVisible() {
        return GetList().Visible;

        //object O = null;
        //if (IsPostBack) O=Page.Request.Form[txt_ListVisible.UniqueID];
        //if (O==null) O= txt_ListVisible.Text.ToUpper();
        //return (O.ToString().ToUpper() == "S");
    }

    public void SetTitle(string myTitle) {
        this.Page.Title = myTitle;
    }




    protected void btnMenuHome_Click(object sender, EventArgs e) {
        if (MenuHome != null)
            MenuHome();
    }


    protected void btnMenuInfo_Click(object sender, ImageClickEventArgs e) {
        if (MenuInfo != null)
            MenuInfo();
    }

    private bool myIsClientConfirm = false;
    public bool IsAClientConfirm() {
        return myIsClientConfirm;
    }
    private bool myIsClientRejectRules=false;
    private bool myIsClientIgnoreRules = false;
    public bool IsAClientIgnoreRules() {
        return myIsClientIgnoreRules;
    }
    public bool IsAClientRejectRules() {
        return myIsClientRejectRules;
    }
    public void ClearConfirmSequence() {
        myIsClientConfirm = false;
        myIsClientIgnoreRules = false;
        //ClientMessagePanel.Visible = false;
        //ClientMessageTitle.Visible = false;
        //DetailMessagePanel.Visible = false;

        //CHP_CM_DIV.Style["display"] = "none";

    }

    // ex btn__ConfermaClient_Click
    public string pendingCommand = null;
    public void btnAllSubmit_Click(Object sender, EventArgs e) {
        MetaPage mp = this.Page as MetaPage;
        if (mp == null)
            return;


        pendingCommand = mp.RunningCommand();

        //mp.CommFun.DoMainCommand(xx);      
    }



    public Panel GetToolBar() {
        return PanToolBar;
    }

    public ContentPlaceHolder GetList() {
        return CHP_List;
    }

    public ContentPlaceHolder GetRules() {
        return CHP_BR;
    }
    public ContentPlaceHolder GetContent() {
        return CHP_PC;
    }

    public Control GetToolBarDiv() {
        return ToolBar_Div;
    }

    public Control GetContentDiv() {
        return CHP_PC_DIV;
    }

    public Control GetListDiv() {
        return Div_CHPList;
    }

    void RegisterHideControl() {
        //string F = "function hide(x) { document.getElementById(x).style.display='none';return false; }\r\n";
        //RegisterScript("hide(x)", F);      

    }
    void RegisterShowControl() {
        //string F = "function show(x) { document.getElementById(x).style.display='';return false; }\r\n";
        //RegisterScript("show(x)", F);
    }







    ///// <summary>
    ///// Disabilita tutti i textbox presenti in un contenitore e aggiunge quelli già disabilitati a List
    ///// </summary>
    ///// <param name="Parent">Container control</param>
    ///// <param name="List">List of controls which were already disabled</param>
    //public void DisableAllTextBox(Control Parent, ArrayList List) {
    //    foreach (Control C in Parent.Controls) {
    //        TextBox T = C as TextBox;
    //        if (T != null) {
    //            if (!T.Enabled)
    //                List.Add(T);
    //            else
    //                T.Enabled = false;
    //        }
    //        if (C.HasControls()) DisableAllTextBox(C, List);
    //    }
    //}
    string RefToControl(Control C) {
        return "document.getElementById(\"" + C.ClientID + "\")";
    }
    public void ShowClientMessage(string message, string title, System.Windows.Forms.MessageBoxButtons Btns) {
        ShowClientMessage(message, title, Btns, null);
    }
    class suspended_message {
        public string message;
        public string title;
        public System.Windows.Forms.MessageBoxButtons Btns;
        public string longmess;
    };
    suspended_message Suspended = null;

    void SuspendMessage(string message, string title, System.Windows.Forms.MessageBoxButtons Btns,
                string longmess) {
        Suspended = new suspended_message();
        Suspended.message = message;
        Suspended.title = title;
        Suspended.Btns = Btns;
        Suspended.longmess = longmess;
    }

    void ReleaseMessages() {
        if (Suspended == null)
            return;
        ShowClientMessage(Suspended.message, Suspended.title, Suspended.Btns, Suspended.longmess);
    }

    public string SecureString(string S) {
        string dS = Uri.EscapeDataString(S).Replace("'", @"\'").Replace(@"""", @"\""");
        string res = "decodeURIComponent(\"" + dS + "\")";
        return res;
    }

    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        Page.RegisterOnSubmitStatement("DisablePage", " DisablePageOnSubmit();");

    }


    public void ShowClientMessage(string message, string title, System.Windows.Forms.MessageBoxButtons Btns,
                                  string longmess) {
        ShowClientMessage(message, title, Btns, longmess, null);
    }

    public void ShowClientMessage(string message, string title, System.Windows.Forms.MessageBoxButtons Btns,
                                  string longmess, string idToFocus) {
        MetaPage MP = this.Page as MetaPage;
        if (!MP.isLoaded) {
            SuspendMessage(message, title, Btns, longmess);
            return;
        }
        const string crLf = "\r\n";
        //Scrivo il js che crea la finestra di dialogo e la mette in jsMsg
        //Crea la div con il titolo opportuno
        string Js = "var jsMsg = $('<div id=\"id_cl_msgdlg\" title=" + SecureString(title) + "></div>');" + crLf;



        //Aggiunge il testo del messaggio
        Js += "$(jsMsg).append(document.createTextNode(" + SecureString(message) + "));" + crLf;

        //Crea l'eventuale div di dettaglio errore
        if (!String.IsNullOrEmpty(longmess)) {
            Js += "var jsMsgChkBox=$('<br><input id=\"id_chkdetmsg\" type=\"checkbox\" /> Dettaglio<br>');" + crLf;
            Js += "$(jsMsg).append(jsMsgChkBox);" + crLf;
            Js += "var jsDetMsg= $('<div id=\"id_cl_detmsg\" style=\"display:none;\"></div>')" +
                    ".append(document.createTextNode(" + SecureString(longmess) + "));" + crLf;
            Js += "$(jsMsg).append(jsDetMsg);" + crLf;
        }
        myIsClientConfirm = false;
        Js += "var showmsg_optbts = [];" + crLf;

        string jsconfirmfunction = ",click:function(){" + crLf +
            //"$( this ).dialog( \"close\" );" + crLf +
            //"$(\"#"+btnSubmit.ClientID+"\").click();"+crLf+
            //RefToControl(btnSubmit)+".Click();"+crLf+
                                   Page.ClientScript.GetPostBackEventReference(btnAllSubmit, "accept_message") + ";" + crLf +
            //"__doPostBack('"+ btnSubmit.ID +"', 'onClick');" + crLf +
                                    "return true;" + crLf +
                                   "}" + crLf;
        string closestr = "$( this ).dialog( \"close\" );";
        string onclose = "";
        if (!String.IsNullOrEmpty(idToFocus)) {
            closestr += crLf + "SetFocusTo( document.getElementById('" + idToFocus + "'));" + crLf;
            onclose = ", onclose: function(){SetFocusTo( document.getElementById('" + idToFocus + "'));}";
        }

        if (Btns == System.Windows.Forms.MessageBoxButtons.OKCancel) {
            Js += "showmsg_optbts.push({text:\"Ok\",class :\"masterbtn\"" + jsconfirmfunction + "});" + crLf;    //ex  btn__ConfermaClient.Text
            Js += "showmsg_optbts.push({text:\"Cancel\",class :\"masterbtn\",click: function() {" + closestr + "}});" + crLf; //ex btn__AnnullaClient.Text
        }
        else {
            if (Btns == System.Windows.Forms.MessageBoxButtons.YesNo) {
                Js += "showmsg_optbts.push({text:\"Si\",class :\"masterbtn\"" + jsconfirmfunction + "});" + crLf; //ex  btn__ConfermaClient.Text
                Js += "showmsg_optbts.push({text:\"No\",class :\"masterbtn\",click: function() {" + closestr + "}});" + crLf; //ex btn__AnnullaClient.Text
            }
            else {
                Js += "showmsg_optbts.push({text:\"Ok\",class :\"masterbtn\",click: function() {" + closestr + "}});" + crLf;    //ex btn__AnnullaClient.Text               
            }
        }
        Js += "var showmsg_opts= {resizable:true, heigth:'auto', modal:true, autoOpen:true, dialogClass: \"no-close\", " +
            "position: ['center', 'center'],  width:'auto', " +
            "closeOnEscape: false, buttons:showmsg_optbts," +
                " title:" + SecureString(title) + onclose + "};" + crLf;

        Js += "$(\"#" + CHP_PC_DIV.ClientID + "\").append(jsMsg);" + crLf;

        if (!String.IsNullOrEmpty(longmess)) {
            Js += "$(\"#id_chkdetmsg\").change(function(){$(\"#id_cl_detmsg\").slideToggle();" +
                 "$(\"#id_cl_msgdlg\").dialog(\"option\",\"heigth\",\"auto\");" + crLf +
                  "$(\"#id_cl_msgdlg\").dialog(\"option\",\"width\",\"auto\");" + crLf +
                 "$(\"#id_cl_msgdlg\").dialog(\"option\",\"position\",\"center\");" + crLf +
                     "});" + crLf;
        }
        Js += "$(jsMsg ).dialog(showmsg_opts);" + crLf;
        Js += "$('button.ui-dialog-titlebar-close').hide();" + crLf;

        RegisterScript("ConfirmClientMessage", Js, true);

        //btn__ConfermaClient.Attributes.Add("onClick", "if (ConfirmClientMessage())");
    }
    public string GetPreviousValue() {
        return PreviousValue.Text;
    }
    string ConvertCarriages(string S) {
        S = S.Replace("\r", "\n");
        S = S.Replace("\n\n", "\n");
        S = S.Replace("\n", "\r\n");
        return S;
    }

    /// <summary>
    /// Riempie il grid G con le regole PMC
    /// </summary>
    /// <param name="G"></param>
    /// <param name="PMC"></param>
    void FillGridWithRules(hwDataGridWeb G, ProcedureMessageCollection PMC) {
        DataSet D = new DataSet("Nino");
        DataTable T = new DataTable("errori");
        T.Columns.Add("flagsystem", typeof(string));
        T.Columns["flagsystem"].Caption = "Note";
        T.Columns.Add("msg", typeof(string));
        T.Columns["msg"].Caption = "Messaggio di errore";
        T.Columns.Add("kind", typeof(string));
        T.Columns["kind"].Caption = "Gravità";
        T.Columns.Add("codice", typeof(string));
        T.Columns["codice"].Caption = "Codice";
        //T.Columns.Add("table", typeof(string));
        //T.Columns["table"].Caption = "Tabella";
        //T.Columns.Add("operation", typeof(string));
        //T.Columns["operation"].Caption = "Op.";
        T.Columns.Add("id", typeof(string));
        T.Columns["id"].Caption = "#";
        D.Tables.Add(T);
        Dictionary<string, bool> allm = new Dictionary<string, bool>();

        foreach (EasyProcedureMessage CM in PMC) {
            System.Data.DataRow R = T.NewRow();
            if (CM.flagsystem) {
                R["flagsystem"] = "S";
            }
            else {
                R["flagsystem"] = "Regola NON di SISTEMA";
            }
            string m = ConvertCarriages(CM.LongMess);
            R["msg"] = m;
            
            if (CM.ErrorType != null)
                R["kind"] = CM.ErrorType;
            if (CM.AuditID != null)
                R["codice"] = CM.AuditID;
            if (allm.ContainsKey(m + R["codice"].ToString()))
                continue;
            allm[m + R["codice"].ToString()] = true;
            string pre_post = CM.PostMsgs ? "post" : "pre";
            if (CM.TableName == null || CM.Operation == null || CM.EnforcementNumber == null) {
                R["id"] = "dberror";
            }
            else {
                R["id"] = pre_post + "/" + CM.TableName + "/" + CM.Operation.Substring(0, 1) + "/" + CM.EnforcementNumber.ToString();
            }
            T.Rows.Add(R);
        }



        G.GridTable = T;
        G.DoPostBackOnClick = false;
    }

    hwDataGridWeb myRuleGrid;
    public void ShowRules(ProcedureMessageCollection PMC) {
        ContentPlaceHolder ListPlace = GetRules();
        ListPlace.Visible = true;


        string message = "Elenco errori ed avvertimenti";
        //if (PMC.PostMsgs)
        //    message = "Controlli dopo il salvataggio";
        //else
        //    message = "Controlli prima del salvataggio";


        //Aggiunge una div con un testo descrittivo (controlli prima o dopo il salvataggio) all'area delle regole
        //HtmlGenericControl C = new HtmlGenericControl("div");
        //C.InnerText = message;
        //C.Attributes.Add("class", "RulesHeader");
        //ListPlace.Controls.AddAt(0, C);


        myIsClientIgnoreRules = false;
        string crLf = "\r\n";

        hwDataGridWeb G = new hwDataGridWeb();
        G.CssClass = "normalwrap";
        ListPlace.Controls.Add(G);
        FillGridWithRules(G, PMC);
        //Table T=G.FindControl("TableDati") as Table;
        //T.Attributes.Add("width", "100%");
        //T.Attributes.Add("style", "font-size: 14px");
        CHP_BR_DIV.Visible = true;


        myRuleGrid = G;
        //string Js = "var jsMsg = $('<div id=\"id_cl_msgdlg\" title=" + SecureString(title) + "></div>');" + crLf;
        ////Aggiunge il testo del messaggio
        //document.getElementById(\""+C.ClientID+"\")";
        string Js = "var jsRuleMsg = document.getElementById('" + CHP_BR_DIV.ClientID + "');" + crLf;
        Js += "var showrulemsg_optbts = [];" + crLf;

        if (PMC.CanIgnore) {
            string jsconfirmfunction = ",click:function(){" + crLf +
                //"$( this ).dialog( \"close\" );" + crLf +
                                   Page.ClientScript.GetPostBackEventReference(btnAllSubmit, "accept_rules") + ";" + crLf +
                                    "return true;" + crLf +
                                   "}" + crLf;
            Js += "showrulemsg_optbts.push({text:\"Ignora\",class :\"masterbtn\"" + jsconfirmfunction + "});" + crLf;    //ex  btn__ConfermaClient.Text
        }


        string jsrejectfunction = ",click:function(){" + crLf +
            //"$( this ).dialog( \"close\" );" + crLf +
                                   Page.ClientScript.GetPostBackEventReference(btnAllSubmit, "reject_rules") + ";" + crLf +
                                    "return true;" + crLf +
                                   "}" + crLf;
        Js += "showrulemsg_optbts.push({text:\"Annulla\",class :\"masterbtn\"" + jsrejectfunction + "});" + crLf;   

        //Js += "showrulemsg_optbts.push({text:\"Annulla\",class :\"masterbtn\",click: function() {$( this ).dialog( \"close\" );}});" + crLf; //ex btn__AnnullaClient.Text


        Js += "var showrulemsg_opts= {resizable:true, modal:true, autoOpen:true,width: '90%', dialogClass: \"no-close\", closeOnEscape: false, buttons:showrulemsg_optbts," +
                " title:" + SecureString(message) + "};" + crLf;


        //Js += "$(\"#" + CHP_PC_DIV.ClientID + "\").append(jsMsg);" + crLf;
        Js += "$( jsRuleMsg ).dialog(showrulemsg_opts);" + crLf;


        RegisterScript("ConfirmClientRules", Js, true);

    }

    public void RegisterScript(string key, string block, bool AfterAllScripts) {
        if (Page.ClientScript.IsStartupScriptRegistered(typeof(MetaPageMaster), key))
            return;
        ContentPlaceHolder P = AfterAllScripts ? JScriptAfterLibs : JScriptBeforeLibs;
        HtmlGenericControl h = new HtmlGenericControl("script");
        //h.Attributes.Add("type", "text/javascript");
        h.InnerHtml = "\n\r" + block;
        P.Controls.Add(h);
        this.Page.ClientScript.RegisterStartupScript(typeof(MetaPageMaster), key, "", false);
    }






    hwDataGridWeb myGridWeb;
    bool AlreadyShowed = false;
    public void ShowMainList(DataTable T, EventHandler OnClick) {
        if (AlreadyShowed)
            return;
        if (T == null)
            return;
        AlreadyShowed = true;
        ContentPlaceHolder ListPlace = GetList();
        Div_CHPList.Attributes["class"] = "centerdiv";
        ListPlace.Controls.Clear();

        hwDataGridWeb G = new hwDataGridWeb();
        G.SelectRow += OnClick;
        foreach (Control C in ListPlace.Controls) {
            hwDataGridWeb GG = C as hwDataGridWeb;
            if (GG == null)
                continue;
            ListPlace.Controls.Remove(GG);
        }
        ListPlace.Controls.Add(G);
        G.GridTable = T;
        G.gridtype = "to_pgrid";
        G.DoPostBackOnClick = true;
        G.ForceSelectRow = false;

        hwButton btnClose = new hwButton();
        btnClose.Text = "Chiudi elenco";
        HelpMetaWeb.SetData(btnClose, "maincmd", "hideList");
        ListPlace.Controls.Add(btnClose);

        //G.Height = 550;
        ListPlace.Visible = true;
        //txt_ListVisible.Text = "S";
        Div_CHPList.Visible = true;
        ToolBar_Div.Visible = false;
        CHP_PC_DIV.Visible = false;
        myGridWeb = G;
    }
    public void HideMainList() {
        AlreadyShowed = false;
        ContentPlaceHolder ListPlace = GetList();
        Div_CHPList.Attributes["class"] = null;
        ListPlace.Controls.Clear();
        if (ListPlace != null)
            ListPlace.Visible = false;
        Div_CHPList.Visible = false;
        ToolBar_Div.Visible = true;
        CHP_PC_DIV.Visible = true;
        myGridWeb = null;

    }

    public void AddControl(Control C) {
        CHP_TB.Controls.Add(C);
    }

    public Control GetControl(string ControlName) {
        return (Control)CHP_TB.FindControl(ControlName);

    }


}
