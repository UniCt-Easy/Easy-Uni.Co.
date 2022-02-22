
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
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using HelpWeb;
using funzioni_configurazione;
using metadatalibrary;
using metaeasylibrary;
using AllDataSet;
using EasyWebReport;
using itinerationFunctions;


public partial class itinerationauth_default_new02 : MetaPage {
    vistaForm_itinerationauth DS;
    QueryHelper QHS;
    CQueryHelper QHC;
    int idauthagency;
    int authagencypriority;
    public override DataSet GetDataSet() {
        return DS;
    }
    public override DataSet CreateNewDataSet() {
        return new vistaForm_itinerationauth();
    }
    public override void SetDataSet(DataSet D) {
        DS = (vistaForm_itinerationauth)D;
    }




    protected void Page_Load(object sender, EventArgs e) {
        if (showlapsexpenses.Text == "N") {
            plcitems.Style.Remove("display");
            plcitems.Style.Add("display", "none");
            plcitems.Style.Remove("z-index");
            showlapsexpenses.Text = "";
        }

        ////if (showcancelbox.Text == "N") { //SARA
        ////    rejectreason.Style.Remove("display");
        ////    rejectreason.Style.Add("display", "none");
        ////    rejectreason.Style.Remove("z-index");
        ////    showcancelbox.Text = "";
        ////}

        ////if (showapprovebox.Text == "N") { //SARA
        ////    confirmapproval.Style.Remove("display");
        ////    confirmapproval.Style.Add("display", "none");
        ////    confirmapproval.Style.Remove("z-index");
        ////    showapprovebox.Text = "";
        ////}

    }

    public void DoCancel() {
        // Imposta lo stato globale su "Annullata" (iditinerationstatus=7),
        // lo stato dell'approvazione su "N"
        // Aggiornare anche il campo "cancelreason" su itineration con il motivo della cancellazione
        ////rejectreason.Style.Remove("display");
        ////rejectreason.Style.Add("display", "none");
        ////rejectreason.Style.Remove("z-index");
        ////rejectreason.Style.Add("z-index", "11000");
        //GetImpersonatedAuthAgency();
        DataRow Curr = DS.itinerationauthview.Rows[0];
        int iditineration = CfgFn.GetNoNullInt32(Curr["iditineration"]);
        DS.AcceptChanges();

        QHS = Conn.GetQueryHelper();

        string filter = "";
        filter = QHS.AppAnd(QHS.CmpEq("idauthagency", idauthagency), QHS.CmpEq("iditineration", iditineration));
        DataTable DTItinerationAuthAgency = Conn.RUN_SELECT("itinerationauthagency", "*", null, filter, null, false);
        if (DTItinerationAuthAgency == null || DTItinerationAuthAgency.Rows.Count == 0)
            return;
        DTItinerationAuthAgency.Rows[0]["flagstatus"] = "N";
        DTItinerationAuthAgency.setSkipSecurity();


        filter = QHS.CmpEq("iditineration", iditineration);
        DataTable DTItineration = Conn.CreateTableByName("itineration", "*");
        DTItineration.setSkipSecurity();
        Conn.RUN_SELECT_INTO_TABLE(DTItineration,null,filter, null, false);

        if (DTItineration == null || DTItineration.Rows.Count == 0)
            return;
        DTItineration.Rows[0]["iditinerationstatus"] = 7;
        if (txtrejectreason.Text != "")
            DTItineration.Rows[0]["webwarn"] = txtrejectreason.Text;
        if (txtAnnotazioniRifiutoApprovazione.Text != "")
            DTItineration.Rows[0]["cancelreason"] = txtAnnotazioniRifiutoApprovazione.Text;
        DataSet DSNew = new DataSet();

        DSNew.Tables.Add(DTItinerationAuthAgency);
        DSNew.Tables.Add(DTItineration);

        Easy_PostData PD = new Easy_PostData();
        PD.initClass(DSNew, Conn);
        ProcedureMessageCollection PMC = PD.DO_POST_SERVICE();
        if (!PMC.CanIgnore) {
            string longMessage = "";
            foreach (ProcedureMessage pm in PMC) {
                longMessage += pm.GetKey() + " " + pm.LongMess + ( pm.CanIgnore ? " warning " : " error")+"\n\r";
            }
            ShowClientMessage("Regole di sicurezza hanno impedito l'aggiornamento del DataBase", "Errore",longMessage);            
        }
        else {
            PD.DO_POST_SERVICE();
        }
        string errormsg = "";
        if (PMC.Count == 0) {
            errormsg = MissFun.WebSendMails(Conn as DataAccess, DTItineration.Rows[0]);
            if (errormsg != "")
                ShowClientMessage(errormsg, "Errore");
        }

        CommFun.FreshPage(false, true);
        CommFun.DoMainCommand("mainsetsearch");
        CommFun.DoMainCommand("maindosearch");


    }

    bool DoApprove( DataRow rItinerationauthview) {
 
		PostData.RemoveFalseUpdates(DS);
		
		if (DS.HasChanges())
		{
			ShowClientMessage("Ci sono modifiche da salvare prima di procedere con l'approvazione", "Errore");
			return false;
		}
		string errormsg = "";
        bool ChangeGlobalItinerationStatus = false; //se true è necessario cambiare lo stato della missione (itineration)
        int iditineration = CfgFn.GetNoNullInt32(rItinerationauthview["iditineration"]);
        string filter = "";
        filter = QHS.AppAnd(QHS.CmpEq("iditineration", iditineration), QHS.CmpNe("idauthagency", idauthagency),
               QHS.DoPar(QHS.AppOr(QHS.CmpEq("flagstatus", "D"), QHS.CmpEq("flagstatus", "N"))));

        int pendingauthcount = Conn.RUN_SELECT_COUNT("itinerationauthagency", filter, false);
        if (pendingauthcount == 0) {//Non ci sono altre autorizzazioni pendenti
	        ChangeGlobalItinerationStatus = true;//Bisogna cambiare lo stato complessivo della missione
        }

        filter = "";

        filter = QHS.AppAnd(QHS.CmpEq("iditineration", iditineration), QHS.CmpEq("idauthagency", idauthagency));

        DataSet DSNew = new DataSet();

        //Imposta i campi di itinerationauthagency e aggiunge la tabella 
        DataTable DTItinerationAuthAgency = Conn.RUN_SELECT("itinerationauthagency", "*", null, filter, null, false);
        DTItinerationAuthAgency.setSkipSecurity();

        if (DTItinerationAuthAgency == null || DTItinerationAuthAgency.Rows.Count == 0) return true;
        DTItinerationAuthAgency.Rows[0]["flagstatus"] = "S";

        if (txtAnnotazioniRifiutoApprovazione.Text != "") {
	        DTItinerationAuthAgency.Rows[0]["annotationsrejectapproval"] = txtAnnotazioniRifiutoApprovazione.Text;
        }

        DSNew.Tables.Add(DTItinerationAuthAgency);


        DataTable DTItineration = Conn.CreateTableByName("itineration", "*");
        DTItineration.setSkipSecurity();
        filter = QHS.CmpEq("iditineration", iditineration);
        Conn.RUN_SELECT_INTO_TABLE(DTItineration, null, filter, null, false);
        if (DTItineration.Rows.Count == 0) {
            ShowClientMessage($"Non si dispone delle autorizzazioni sufficienti (filtro applicato:{filter})", "Errore");
            return false;
        }
        if (ChangeGlobalItinerationStatus) {
            DTItineration.Rows[0]["iditinerationstatus"] = 6;
            DTItineration.Rows[0]["authorizationdate"] = DateTime.Now;
        }
		//DataRow rItinerationauthview = DS.itinerationauthview.Rows[0];
		//ShowClientMessage(rItinerationauthview["idupb"].ToString(), "Errore");
		bool upbaggiornato = false;
        if (rItinerationauthview["idupb"] != DBNull.Value) {
            DTItineration.Rows[0]["idupb"] = rItinerationauthview["idupb"];//Valorizza l'UPB
            upbaggiornato = true;
        }

        if (ChangeGlobalItinerationStatus || upbaggiornato) {
            DSNew.Tables.Add(DTItineration);
        }

        Easy_PostData PD = new Easy_PostData();
        PD.initClass(DSNew, Conn);
        ProcedureMessageCollection PMC = PD.DO_POST_SERVICE();

        if (!PMC.CanIgnore) {
            string longMessage = "";
            foreach (ProcedureMessage pm in PMC) {
                longMessage += pm.GetKey() + " " + /*pm.LongMess +*/ (pm.CanIgnore ? ". Warning. " : ". Error. ");// + "\n\r";
            }
            
            ShowClientMessage("Regole non ignorabili hanno impedito il salvataggio. Espandere il messaggio per leggere il dettaglio.", "Errore",longMessage);
            return false;
        }

        if (PMC.Count > 0) {
	        PD.DO_POST_SERVICE();
        }
        errormsg = MissFun.WebSendMails(Conn as DataAccess, DTItineration.Rows[0]);
        if (errormsg != "") {
              ShowClientMessage(errormsg, "Errore");
              return false;
        }
        
        return true;
    }


    public void DoApprove() {
        string errormsg = "";
        // Determinare anche se sono l'ultimo ad approvare. Se si, 
        // Tutta la missione passa nello stato di approvato
        // Cioè se questa select count dà come risultato 0
        //select count(*) from itinerationauthagency where iditineration=159 
        // and idauthagency<>9 and (flagstatus='D' or flagstatus='N')
        // Modificare inoltre la data di autorizzazione oltre a quello globale
        bool ChangeGlobalItinerationStatus = false;
        DS.AcceptChanges();
        //GetImpersonatedAuthAgency();
        DataRow Curr = DS.itinerationauthview.Rows[0];
        int iditineration = CfgFn.GetNoNullInt32(Curr["iditineration"]);
        bool res = DoApprove(Curr);
        if (!res)
            return;

        CommFun.DoMainCommand("mainsetsearch");
        CommFun.DoMainCommand("maindosearch");

    }

    public void doApproveAll() {
        DataTable T = Conn.RUN_SELECT("itinerationauthview", "*", null, mainfilter, null, false);
        foreach (DataRow R in T.Rows) {
            bool res = DoApprove(R);
            if (!res)
                return;
        }

        CommFun.DoMainCommand("mainsetsearch");
        CommFun.DoMainCommand("maindosearch");

    }

    string mainfilter = "";
    public override void AfterLink(bool firsttime, bool formToLink) {
        GetImpersonatedAuthAgency();
        Meta.CanInsert = false;
        //Meta.CanSave = false;
        Meta.CanCancel = false;


        bool IsManager = (Session["CodiceResponsabile"] != null ? true : false);
        int idman = 0;
        idman = CfgFn.GetNoNullInt32(Session["CodiceResponsabile"]);
        string filteresercizio = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
        GetData.SetStaticFilter(DS.upbitinerationavailable, QHS.AppAnd(filteresercizio, QHS.CmpEq("active", "S")));
        Meta.DefaultListType = "default";
        SearchTable = "itinerationauthview";
        QHC = new CQueryHelper();
        string filter;
        string subfilter = "";
        subfilter = "(select count(*) from itinerationauthagency IA join authagency A on (IA.idauthagency=A.idauthagency) ";
        subfilter += " where IA.iditineration=itinerationauthview.iditineration ";
        subfilter += " and IA.idauthagency<> itinerationauthview.idauthagency ";
        subfilter += " and (flagstatus='N' or flagstatus='D') ";
        subfilter += " and A.priority<= itinerationauthview.priority ";
        subfilter += " )=0";
        filter = QHS.AppAnd(subfilter, QHS.CmpEq("idauthagency",idauthagency), QHS.CmpEq("flagstatus", "D"),
                        QHS.FieldInList("iditinerationstatus", QHS.List(5, 8)));

        //filter = QHS.AppAnd(filter, QHC.CmpEq("ayear", Meta.GetSys("esercizio") ));
        if (IsManager) {
            filter = QHS.AppAnd(filter, QHS.DoPar(QHS.AppOr(QHS.CmpEq("ismanager", "N"), QHS.CmpEq("idman", idman))));
        }
        else {
            filter = QHS.AppAnd(filter, QHS.CmpEq("ismanager", "N"));
        }

        mainfilter = filter;
        
        GetData.SetStaticFilter(DS.itinerationauthview, filter);
         
        object viewtappe = Conn.DO_READ_VALUE("web_config", null, "showitinerationlap");
        if (viewtappe == null)
            viewtappe = DBNull.Value;
        if (viewtappe.ToString().ToUpper() == "N") {
            lbltappe.Visible = false;
            txtntappe.Visible = false;
        }
        txtMotivo.ReadOnly = true;

    }
    public override void DoCommand(string command) {
        if (PState.IsEmpty)
            return;
        if (command == "approva") {
            DoApprove();
        }
        if (command == "approvatutto") {
            doApproveAll();
        }
        if (command == "negaAutorizzazione") {
            DoCancel();
        }
        if (command == "nonNegare") {
            panelAutorizzazioni.Visible = false;
        }
        if (command == "tappe") {
            ShowTappe();
        }
        if (command == "spesepreviste") {
            ShowSpese();
        }
        if (command == "respingi") {
            panelAutorizzazioni.Visible = true;
        }
    }


    public override void AfterFill() {
        txtdatainizio.ReadOnly = true;
        txtdtafine.ReadOnly = true;
        txtpercipiente.ReadOnly = true;
        txtresponsabile.ReadOnly = true;
        txtadate.ReadOnly = true;
        btnapprova.Enabled = true;
        btnresp.Enabled = true;
        btnApproveAll.Enabled = true;
        btnspese.Enabled = true;
        btntappe.Enabled = true;
        txtesercizio.ReadOnly = true;
        txtnumero.ReadOnly = true;
        txtdescr.ReadOnly = true;
        txtntappe.ReadOnly = true;
        txtLocation.ReadOnly = true;
        txtapplierannotation.ReadOnly = true;
        txtMotivazione.ReadOnly = true;
        txtInfoVeicolo.ReadOnly = true;
        txtadditionalannotation.ReadOnly = true;
        //lblauthagency.Visible = true;
        ImpostaTageFiltriUPB(DBNull.Value);
        AbilitaUPB();
    }
    public void AbilitaUPB() {
       if (CommFun.IsEmpty) {
            PanelUpb.Enabled = false;
            return;
        }
        DataRow Curr = DS.itinerationauthview.Rows[0];
        int iditineration = CfgFn.GetNoNullInt32(Curr["iditineration"]);
        string flagownfunds = Conn.DO_READ_VALUE("itineration", QHS.CmpEq("iditineration", iditineration), "flagownfunds").ToString();
        if( (Curr["idupb", DataRowVersion.Original])!= DBNull.Value) {
            PanelUpb.Enabled = false;
            return;
        }

        if (flagownfunds == "N") {
            //Fondi di altri è l'agente che deve indicare l'UPB
            PanelUpb.Enabled = true;
        }
        else {
            //Se non valorizzato o Fondi propri
            PanelUpb.Enabled = false;
        }

    }
    public override void AfterClear() {
        txtdatainizio.ReadOnly = false;
        txtdtafine.ReadOnly = false;
        txtpercipiente.ReadOnly = false;
        txtresponsabile.ReadOnly = false;
        txtadate.ReadOnly = false;

        btnapprova.Enabled = false;
        btnresp.Enabled = false;
        btnApproveAll.Enabled = false;

        btnspese.Enabled = false;
        btntappe.Enabled = false;
        txtdescr.ReadOnly = false;
        txtntappe.ReadOnly = false;
        txtLocation.ReadOnly = false;
        txtapplierannotation.ReadOnly = false;
        txtMotivazione.ReadOnly = false;
        txtInfoVeicolo.ReadOnly = false;
        panelAutorizzazioni.Visible = false;
        //lblauthagency.Visible = false;
        ImpostaTageFiltriUPB(DBNull.Value);
        PanelUpb.Enabled = true;
    }

    private string CalcolaFiltroUPB() {
        if (CommFun.IsEmpty) return "";
        DataRow r = DS.itinerationauthview.Rows[0];
        string filter_upb = "";
        object idman = r["idman"];
        if (idman != DBNull.Value) {
            filter_upb = QHS.AppAnd(filter_upb, QHS.NullOrEq("idman", idman));
        }
        return filter_upb;
    }

    private void ImpostaTageFiltriUPB(object idupbToinclude) {
        if (CommFun.IsEmpty) return;

        string upbfilter = CalcolaFiltroUPB();
        string filteradd = upbfilter;
        object importoPresuntoObj = null;
        decimal importoPresunto = 0;

        
        DataRow Curr = DS.itinerationauthview.Rows[0];
        int iditineration = CfgFn.GetNoNullInt32(Curr["iditineration"]);
        
        DataTable tItineration = Conn.CreateTableByName("itineration", "*");
        tItineration.setSkipSecurity();
        Conn.RUN_SELECT_INTO_TABLE(tItineration, null, QHS.CmpEq("iditineration", iditineration), null, true);
        if (tItineration.Rows.Count == 0) {
            ShowClientMessage($"Non si dispone delle autorizzazioni sufficienti", "Errore");
            return;
        }
        DataRow R = tItineration.Rows[0];
        string advanceapplied = R["advanceapplied"].ToString();
        //Importo presunto (Anticipo No)
        if (advanceapplied=="N") {
            importoPresunto = CfgFn.GetNoNullDecimal(R["supposedamount"]);
        }
        //Importo presunto (Anticipo Si)
        if (advanceapplied=="S") {
            importoPresunto = CfgFn.GetNoNullDecimal(R["supposedfood"])
                + CfgFn.GetNoNullDecimal(R["supposedliving"])
                + CfgFn.GetNoNullDecimal(R["supposedtravel"]);
        }
        string filteractive = QHS.AppAnd(upbfilter, QHS.CmpEq("active", "S"),
            QHS.CmpGt("differenzadisponibilita", 0),
            QHS.CmpGe("differenzadisponibilita", importoPresunto), QHS.CmpEq("ayear", Conn.GetSys("esercizio")));
        if (idupbToinclude != DBNull.Value && upbfilter != "") {
            filteradd = QHS.DoPar(QHS.AppOr(QHS.CmpEq("idupb", idupbToinclude), QHS.DoPar(upbfilter)));
        }

        GetData.SetStaticFilter(DS.upb, filteradd);

        //if (upbfilter != "") {
            btnUpbDisponibile.Tag = "choose.upbitinerationavailable.default." + filteractive;
        //}
        //else {
        //    btnUpbDisponibile.Tag = "manage.upb.tree";
        //}

        if (PanelUpb.Tag != null)
            PanelUpb.Tag = "AutoChoose.txtCodiceUPB.missioni." + filteractive;//"AutoChoose.txtCodiceUPB.default." + filteractive;
        CommFun.SetAutoMode(PanelUpb);

    }
    public void GetImpersonatedAuthAgency() {
        string idflowchart;
        if (Meta.GetSys("idflowchart") == null && Meta.GetSys("idflowchart").ToString() == "")
            return;

        // lookup idauthagency from idflowchart
        idflowchart = Meta.GetSys("idflowchart").ToString();
        QHS = Conn.GetQueryHelper();
        string filter;
        filter = QHS.CmpEq("idflowchart", idflowchart);
        DataTable DT = Conn.RUN_SELECT("flowchartauthagency", "*", null, filter, null, false);

        if (DT == null || DT.Rows.Count == 0)
            return;

        idauthagency = CfgFn.GetNoNullInt32(DT.Rows[0]["idauthagency"]);
        if (idauthagency == 0)
            return;

        filter = "";
        filter = QHS.CmpEq("idauthagency", idauthagency);

        DT = Conn.RUN_SELECT("authagency", "*", null, filter, null, false);
        if (DT == null || DT.Rows.Count == 0)
            return;

        string authagencytitle;
        authagencytitle = DT.Rows[0]["title"].ToString();
        authagencypriority = CfgFn.GetNoNullInt32(DT.Rows[0]["priority"]);
        lblauthagency.Text = "";
        lblauthagency.Text = "Ente Autorizzatore: <b>" + authagencytitle + "</b>";

        return;
    }



    public void ShowTappe() {
        QHS = Conn.GetQueryHelper();

        DataRow Curr = DS.itinerationauthview.Rows[0];
        int iditineration = CfgFn.GetNoNullInt32(Curr["iditineration"]);

        string Query = "";

        Query += "select (case when itinerationlap.flagitalian='S' then 'Italia' when itinerationlap.flagitalian='N' then 'Estero' End) as italiaestero, ";
        Query += " itinerationlap.starttime as inizio,itinerationlap.stoptime as fine, itinerationlap.days as giorni, itinerationlap.hours as ore, itinerationlap.description as description, ";
        Query += " foreigncountry.description as foreigncountrydes from ";
        Query += " itinerationlap left outer join foreigncountry on (itinerationlap.idforeigncountry=foreigncountry.idforeigncountry) ";
        Query += " where iditineration='" + iditineration.ToString() + "'";


        DataTable DT = Conn.SQLRunner(Query);

        DT.Columns["italiaestero"].Caption = "Italia/Estero";
        DT.Columns["inizio"].Caption = "Data/Ora Inizio";
        DT.Columns["fine"].Caption = "Data/Ora Fine";
        DT.Columns["giorni"].Caption = "Giorni";
        DT.Columns["ore"].Caption = "Ore";
        DT.Columns["description"].Caption = "Descrizione";
        DT.Columns["foreigncountrydes"].Caption = "Località Estera";
        ShowFormattedResults(DT, "Tappe Missione");
        return;

    }

    public void ShowSpese() {
        QHS = Conn.GetQueryHelper();

        DataRow Curr = DS.itinerationauthview.Rows[0];
        int iditineration = CfgFn.GetNoNullInt32(Curr["iditineration"]);
        
        string Query = " select itinerationrefundkind.description as refunddes, itinerationrefund.amount as amount";
        Query += " from itinerationrefund join itinerationrefundkind on itinerationrefund.iditinerationrefundkind=itinerationrefundkind.iditinerationrefundkind ";
        Query += " where iditineration='" + iditineration.ToString() + "' and flagadvancebalance='A'";

        DataTable DT = Conn.SQLRunner(Query);


        DataTable Titineration = Conn.CreateTableByName("itineration", "*");
        Titineration.setSkipSecurity();
        Conn.RUN_SELECT_INTO_TABLE(Titineration, null, QHS.CmpEq("iditineration", iditineration), null, false);
        if (Titineration.Rows.Count == 0) {
            ShowClientMessage($"Non si dispone delle autorizzazioni sufficienti", "Errore");
            return;
        }

        DataRow Ritineration = Titineration.Rows[0];
        if ((DT.Rows.Count == 1) && CfgFn.GetNoNullDecimal(Ritineration["supposedamount"])>0){
            Query = " select 'Importo presunto della missione' as refunddes, supposedamount as amount";
            Query += " from itineration ";
            Query += " where iditineration='" + iditineration.ToString()+"'";
            DT = Conn.SQLRunner(Query);
        }
        DT.Columns["amount"].Caption = "Importo (EURO)";
        DT.Columns["refunddes"].Caption = "Classificazione";
        ShowFormattedResults(DT, "Spese Previste");
        return;
    }

    public void ShowEmptyMessage(string TableName) {
        string OutHTML = "";
        OutHTML += "<div class=\"row\">";
        OutHTML += "<div class=\"col-md-12\">";
        OutHTML += "<fieldset style=\"background-color: #eeeeee; font-size: 14px; \">";
        OutHTML += "<legend style=\"text-align :center\">" + TableName + "</legend>";
        

        OutHTML += "<div class=\"row\">";
        OutHTML += "<div class=\"col-md-1\"></div>";
        OutHTML += "<div class=\"col-md-10\">";
        OutHTML += "<label>Nessuna Riga Presente.</label>";
        OutHTML += "</div>";
        OutHTML += "<div class=\"col-md-1\"></div>";
        OutHTML += "</div>";//chiude la rows

        OutHTML += "<div class=\"row\">";//apre la rows del btnOK
        OutHTML += "<div class=\"col-md-5\"></div>";
        OutHTML += "<div class=\"col-md-2\">";
        OutHTML += "<input type=\"button\" id=\"btnok\" value=\"Ok\" onclick=\"javascript:closelist();\"></center><br/>";
        OutHTML += "</div>";
        OutHTML += "<div class=\"col-md-5\"></div>";
        OutHTML += "</div>";//chiude rows del btnOK

        OutHTML += "</fieldset>";
        OutHTML += "</div>";
        OutHTML += "</div>";
        plcitems.InnerHtml = OutHTML;
        plcitems.Style.Remove("display");
        plcitems.Style.Add("display", "block");
        plcitems.Style.Remove("z-index");
        plcitems.Style.Add("z-index", "11000");
        plcitems.Style.Remove("overflow");
        plcitems.Style.Remove("max-height");
        plcitems.Style.Add("max-height", "auto");
        plcitems.Style.Remove("width");
        plcitems.Style.Add("width", "auto");


        return;
    }


    public void ShowFormattedResults(DataTable T, String TableName) {

        string OutHTML;

        if (T.Rows.Count == 0 || T == null) {
            ShowEmptyMessage(TableName);
            return;
        }


        OutHTML = "";
        OutHTML += "<div class=\"row\">";// row
        OutHTML += "<div class=\"col-md-12\">"; // col

        OutHTML += "<fieldset style=\"background-color: #eeeeee; font-size: 14px; \">";
        OutHTML += "<legend style=\"text-align :center\">" + TableName + "</legend>";

        OutHTML += "<div class=\"row\">";
        OutHTML += "<div class=\"col-md-12\">";
        OutHTML += "<table class=\"table table-striped\";>";
        OutHTML += "<thead><tr style=\"background-color:#ffffff;color:#000000;\">";
        
        for (int indexcolumn = 0; indexcolumn < T.Columns.Count; indexcolumn++) {
            DataColumn C = T.Columns[indexcolumn];
            OutHTML += "<th><center>" + C.Caption + "</center></th>";
        }

        OutHTML += "</thead>";//chiude la composizione delle intestazioni di colonna
        OutHTML += "<tbody>";

        int rowcount = T.Rows.Count;

        for (int rowindex = 0; rowindex < rowcount; rowindex++) {
            DataRow DR = T.Rows[rowindex];

           string bgcolor;
            if (rowindex % 2 == 0)
                bgcolor = "#d9edf7;";
            else
                bgcolor = "#c4e3f3;";

            OutHTML += "<tr style='background-color:" + bgcolor + "'>";
            for (int columnindex = 0; columnindex < T.Columns.Count; columnindex++) {
                DataColumn C = T.Columns[columnindex];

                System.Windows.Forms.HorizontalAlignment HA = HelpForm.GetAlignForColumn(C);
                string OutputValue = GetValoreFormattato(DR, C.ColumnName);

                if (HA == System.Windows.Forms.HorizontalAlignment.Right)
                    OutHTML += "<td align=\"right\">" + OutputValue + "</td>";
                else
                    OutHTML += "<td align=\"left\">" + OutputValue + "</td>";

            }
        }
        OutHTML += "</tbody></table>";
        
        OutHTML += "</div>";// chiude class col-md-12
        OutHTML += "</div>";//chiude la rows

        OutHTML += "<div class=\"row\">";//apre la rows del btnOK
            OutHTML += "<div class=\"col-md-5\"></div>";
            OutHTML += "<div class=\"col-md-2\">";
        OutHTML += "<input type=\"button\" id=\"btnok\" value=\"Ok\" onclick=\"javascript:closelist();\"></center><br/>";
            OutHTML += "</div>";
            OutHTML += "<div class=\"col-md-5\"></div>";
            OutHTML += "</div>";//chiude rows del btnOK
            OutHTML += "</fieldset>";
        OutHTML += "</div>";//chiude la colonna - new
        OutHTML += "</div>";//chiude la riga - new
        plcitems.InnerHtml = OutHTML;
        plcitems.Style.Remove("display");
        plcitems.Style.Add("display", "block");
        plcitems.Style.Remove("z-index");
        plcitems.Style.Add("z-index", "11000");
        plcitems.Style.Remove("overflow");
        plcitems.Style.Remove("max-height");
        plcitems.Style.Add("max-height","auto");
        plcitems.Style.Remove("width");
        plcitems.Style.Add("width", "auto");

    }

    public string GetValoreFormattato(DataRow R, string field) {
        string tag = HelpForm.CompleteTag(null, R.Table.Columns[field]);
        return HelpForm.StringValue(R[field], tag);
    }


    public int[] GetOrderedColumns(DataTable T) {

        int[] allcol = new int[T.Columns.Count];
        for (int i = 0; i < allcol.Length; i++)
            allcol[i] = -1;
        int nassigned = 0;
        if ((T.Columns.Count == 0) || (T.Columns[0].ExtendedProperties["ListColPos"] == null)) {
            for (int i = 0; i < T.Columns.Count; i++)
                allcol[i] = i;
            return allcol;
        }
        for (int i = 0; i < T.Columns.Count; i++) {
            try {
                DataColumn C = T.Columns[i];
                if (C.Caption == "")
                    continue;
                if (C.Caption.StartsWith("."))
                    C.Caption = " ";

                int col_pos = Convert.ToInt32(C.ExtendedProperties["ListColPos"]);
                if (col_pos != -1) {
                    allcol[col_pos] = i;
                    nassigned++;
                }
            }
            catch {
            }
        }
        int[] cols = new int[nassigned];
        int actualpos = 0;
        for (int i = 0; i < T.Columns.Count; i++) {
            if (allcol[i] >= 0) {
                cols[actualpos] = allcol[i];
                actualpos++;
            }
        }


        return cols;
    }

 
 
    

}
