
/*
Easy
Copyright (C) 2023 Universita' degli Studi di Catania (www.unict.it)
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
using System.Collections;
using HelpWeb;
using EasyPagamentiDataSet;
using metadatalibrary;
using funzioni_configurazione;
using stockmail;
using EasyPagamenti;
using metaeasylibrary;
using pagoPaService;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web;
using q = metadatalibrary.MetaExpression;
using System.Globalization;
using meta_invoice;
using meta_registry;
using System.IO;
using meta_webpaymentdetail;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class webpayment_default : MetaPage {
    CQueryHelper QHC;
    QueryHelper QHS;
    dsmeta_webpayment DS;
    string createdBy = "createby_webpayment";

    public override DataSet GetDataSet() {
        return DS;
    }

    public override DataSet CreateNewDataSet() {
        return new dsmeta_webpayment();
    }

    public override void SetDataSet(DataSet D) {
        DS = (dsmeta_webpayment) D;
    }

    public void SetChildParameter(int idman) {
        var ht = new Hashtable {["idman"] = idman};


        DS.webpayment.ExtendedProperties[MetaData.ExtraParams] = ht;

    }

    public override void AfterRowSelect(DataTable T, DataRow R) {
    }

    private void disabilitaInfoAnagrafica(bool enable) {
        txtPartitaIva.Enabled = enable;
        txtnwebpayment.Enabled = enable;
        txtnwebpayment.Enabled = enable;
        txtNome.Enabled = enable;
        txtCognome.Enabled = enable;
        txtDenominazione.Enabled = enable;
        txtCodiceFiscale.Enabled = enable;
        txtEmail.Enabled = !enable;
    }

    private void visualizzaInfo(bool visible) {
        lblPartitaIva.Visible = visible;
        txtPartitaIva.Visible = visible;
        lblNome.Visible = visible;
        txtNome.Visible = visible;
        lblCognome.Visible = visible;
        txtCognome.Visible = visible;
        lblDenominazione.Visible = visible;
        txtDenominazione.Visible = visible;
        lblCodiceFiscale.Visible = visible;
        txtCodiceFiscale.Visible = visible;
        lblMail.Visible = visible;
        txtEmail.Visible = visible;
    }

    public override void AfterFill() {
        DrpStatus.Enabled = false;
        btnvetrina.Visible = true;
        txtprezzototale.Enabled = false;
        txtquantita_totale.Enabled = false;
        //ShowClientMessage("AfterFill", "Avviso", System.Windows.Forms.MessageBoxButtons.OK);
        string nomeUtente = Session["Utente"].ToString();
        //ShowClientMessage("AfterFill NomeUtente:" + nomeUtente, "Avviso", System.Windows.Forms.MessageBoxButtons.OK);

        int idreg = CfgFn.GetNoNullInt32(Session["CodiceUtente"]);
        //if ((PState.InsertMode))
        //    ShowClientMessage("AfterFill PState: insert", "Avviso", System.Windows.Forms.MessageBoxButtons.OK);
        //if ((PState.EditMode))
        //    ShowClientMessage("AfterFill PState: EditMode", "Avviso", System.Windows.Forms.MessageBoxButtons.OK);
        if ((PState.InsertMode) || (PState.EditMode)) {
            DataTable tContatto = Conn.RUN_SELECT("registryreferenceview", "*", null, QHS.CmpEq("userweb", nomeUtente),
                null, false);
            if (tContatto.Rows.Count == 1) {
                DataRow rRegref = tContatto.Rows[0];
                DataTable tRegistry = Conn.RUN_SELECT("registry", "*", null, QHS.CmpEq("idreg", idreg), null, false);
                DataRow rRegistry = tRegistry.Rows[0];
                DS.webpayment.Rows[0]["idcustomuser"] = rRegref["userweb"];
                DS.webpayment.Rows[0]["idreg"] = rRegistry["idreg"];
                txtNome.Text = rRegistry["forename"].ToString();
                txtCognome.Text = rRegistry["surname"].ToString();
                txtDenominazione.Text = rRegistry["title"].ToString();

                txtCodiceFiscale.Text = rRegistry["cf"].ToString();
                txtEmail.Text = rRegref["email"].ToString();
            }
        }

        calcolaTotale();
        disabilitaInfoAnagrafica(false);
        visualizzaInfo(false); //Questo metodo è stato creto in seguito alla richiesta di nascondere le info. Tuttavia, la gestione esistente è stata lasciata.
        var curr = DS.webpayment.First();
        var idStatus = CfgFn.GetNoNullInt32(curr["idwebpaymentstatus"]);
        //ShowClientMessage("AfterFill idStatus:" + idStatus.ToString(), "Avviso", System.Windows.Forms.MessageBoxButtons.OK);

        /*Bozza o Credito Generato*/
        if (PState.InsertMode) {
            ProcediPagamento.Visible = false;
            SalvaBozza.Visible = true;
        }
        else {
            SalvaBozza.Visible = false;
            if ((idStatus == 1) || (idStatus == 2)) {
                ProcediPagamento.Visible = true;
            }
            else {
                ProcediPagamento.Visible = false;
            }
        }

        if (idStatus > 1) {
            btndelete.Enabled = false;
            Meta.CanSave = false;
        }
        else {
            btndelete.Enabled = true;
            Meta.CanSave = true;
        }

        if (idStatus >= 3) {
            Scaricapdf.Visible = true;
            ProcediPagamentoOnLine.Visible = PagoPaService.isAttivaCreditoSupported(Conn as DataAccess);
        }
        else {
            Scaricapdf.Visible = false;
            ProcediPagamentoOnLine.Visible = false;
        }

        ScaricaFatture.Visible = hasFatture();

        if (idStatus > 1) {
            StampaCarrello.Visible = true;
        }
        if (idStatus >= 3) {
            VisualizzaBtnstampaRicevutaTelematica(); 
        }

        //1   Bozza
        //2   Credito generato
        //3   Credito inviato alla banca
        //4   IUV ricevuto
        //Se è stato già trasmesso il credito e generato lo IUV allora i seguenti pulsanti devono essere nascosti :
        //Imposta Ricerca, Inserisci, Inserisci Copia, Salva, Info, Elimina, Cancella(dett), Correggi(dett) e Cataloghi(dett)
        if (idStatus >= 3) {
            Meta.searchEnabled = true;
            //Meta.CanInsert = false;       //è già false nell'AfterLink
            //Meta.CanInsertCopy = false;   //è già false nell'AfterLink
            Meta.CanSave = false;
            //nascondere anche il button Info

            Meta.CanCancel = false;

            btndelete.Visible = false;
            btnedit.Visible = false;
            btnvetrina.Visible = false;
        }

        //Se non è stato trasmesso il credito allora i seguenti pulsanti devono essere nascosti: 
        //Imposta Ricerca, Inserisci, Inserisci Copia, Salva, Info.
        //Restano attivi i pulsanti Chiudi , Elimina, Cancella(dett), Correggi(dett) e Cataloghi(dett)
        if (idStatus == 2) {
            Meta.searchEnabled = true;
            //Meta.CanInsert = false;       //è già false nell'AfterLink
            //Meta.CanInsertCopy = false;   //è già false nell'AfterLink
            Meta.CanSave = true; // Se posto a false, anche elimina viene nascosto
            //nascondere anche il button Info
            Meta.CanCancel = true;

            btndelete.Visible = true;
            btnedit.Visible = true;
            btnvetrina.Visible = true;
        }


        // DA FARE
        //if(Curr["attachment"]!=null && Curr["attachment"] != DBNull.Value) {
        //    Scaricapdf.Enabled = true;
        //}
        //else {
        //    Scaricapdf.Enabled = false;
        //}
    }
     public void VisualizzaBtnstampaRicevutaTelematica() {
        DataRow curr = DS.webpayment.First();
        if (curr == null) {
            StampaRicevutaTelematica.Visible = false;
            return;
        }
        var iuv = "";
        int n = 0;
        if (DS.flussocreditidetail != null && DS.flussocreditidetail.Rows.Count > 0) {
            var rFlussocreditidetail = DS.flussocreditidetail.First();
            iuv = rFlussocreditidetail["iuv"].ToString();
            n = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("flussoincassidetail", QHS.AppAnd(QHS.IsNotNull("iuv"), QHS.CmpEq("iuv", iuv)), "count(*)"));
        }
        if (n>0) {
            StampaRicevutaTelematica.Visible = true;
            return;
        }

        StampaRicevutaTelematica.Visible = false; 
    }
    public override bool CommandEnabled(string tag) {
        DataRow curr = DS.webpayment.First();
        if (curr == null) {
            return true;
        }

        var idStatus = CfgFn.GetNoNullInt32(curr["idwebpaymentstatus"]);
        return (tag != "showlast") || (idStatus <= 1);
    }


    //Può verificarsi che il credito venga inviato da Easy per cui deve aggiornare lo stato senza riprovare.
    private bool checkIfCreditoInviatoByEasy(DataRow curr) {
        string istransmitted = DS.flussocrediti.Rows[0]["istransmitted"].ToString().ToUpper();
        if (istransmitted == "S") {
            curr["idwebpaymentstatus"] = 3;

            var postData = new Easy_PostData_NoBL();
            postData.initClass(DS, Conn);
            var pmc = postData.DO_POST_SERVICE();
            if (pmc.Count > 0) {
                var errore = "Errore del server dati";
                ShowClientMessage(errore, "Attenzione", System.Windows.Forms.MessageBoxButtons.OK);
            }

            return false;
        }

        return true;
    }

    public override void DoCommand(string command) {
        //ShowClientMessage(command, "Avviso", System.Windows.Forms.MessageBoxButtons.OK);
        if (command == "vetrina") {
            btnvetrina_Click(null, null);
        }

        DataRow curr = DS.webpayment.First();
        if (curr == null) return;
        var idStatus = CfgFn.GetNoNullInt32(curr["idwebpaymentstatus"]);
        //ShowClientMessage("2: " + command, "Avviso", System.Windows.Forms.MessageBoxButtons.OK);
        if (command == "SalvaBozza") {
            btnSalvaBozza_Click();
            SalvaBozza.Visible = false;
        }

        if (command == "ProcediPagamento") {
            /*Bozza*/
            if (idStatus == 1) {
                generacredito();
                inviacredito();
            }

            /*Credito generato*/
            if (idStatus == 2) {
                bool chk = checkIfCreditoInviatoByEasy(curr);
                if (chk) {
                    inviacredito();
                }
                else {
                    ProcediPagamento.Visible = false;
                    ShowClientMessage("Acquisto già effettuato", "Attenzione",
                        System.Windows.Forms.MessageBoxButtons.OK);
                }

            }

            return;
        }

        //if (command == "Generacredito") {
        //    btnGeneracredito_Click();
        //    return;
        //}
        //if (command == "Inviacredito") {
        //    btnInviacredito_Click();
        //    return;
        //}
        if (command == "Scaricapdf") {
            btnScaricaPDF_Click();
        }

        if (command == "ProcediPagamentoOnLine") {
            btnProcediPagamentoOnLine_Click();

        }

        if (command == "ScaricaFatture") {
            btnScaricaFatture_Click();
        }

        if (command == "StampaCarrello") {
            btnStampaCarrello_Click();
        }
        if (command == "StampaRicevutaTelematica") {
            btnStampaRicevutaTelematica_Click();
        }
       
    }

    private void btnSalvaBozza_Click() {
        CommFun.DoMainCommand("mainsave");
    }

    //Bisogna costruire un url da passare al webservice di attiva credito
    // Questo deve contenere in se un parametro (loginParam) che loginServizi interrogherà
    //   e dovrà contenere le seguenti componenti
    //     user password dep  expiringDate (Now+ 15 minuti) + idwebpayment + x (random) 
    // QUesto loginParam lo si passa alla funzione di Security
    //  che calcola un codice
    // Questo codice a sua volta va dato come parametro a loginServizi
    //  l'url sarà del tipo loginServizi... ?logParam="....loginParam" & code="..codice"
    //login servizi prenderà questi due parametri e li verificherà e se tutto è ok
    // effettuerà il login in automatico, e imposterà una var. di sessione ( Session["..."] , che
    //  indicereport quando attivata leggerà,
    //  e ove impostata provvederà a richiamare automaticamente la pagina aperta, alla riga desiderata
    private void btnProcediPagamentoOnLine_Click() {
        string username = Session["Utente"].ToString();
        string dip = Session["Dipartimento"].ToString();
        string expiringdate = DateTime.Now.AddMinutes(15).ToString("dd/MM/yyyy HH.mm.ss.ffffff");

        var curr = DS.webpayment.First();
        string currIdwebpayment = curr["idwebpayment"].ToString();
        //"?logParam=username|dipartimento|expiringdate|curr_idwebpayment|";
        var logParam = username + '|' + dip + '|' + expiringdate + '|' + currIdwebpayment + '|';
        var b = DataAccess.CryptString(logParam);
        var logparamCript = QueryCreator.ByteArrayToString(b);
        var codicepercontrollo = configManager.getCfg("codicepercontrollo");
        var codice = PagoPaService.SecurityCode(logparamCript, codicepercontrollo);

        var paramsforcallabck = $"?logParam={logparamCript}|&code={codice}";

        var strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery;
        var strUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/");
        string urlForCallback =
            $"{strUrl}LoginServizi.aspx{paramsforcallabck}"; //http://localhost:2826/LoginServizi.aspx?... 52850

        //Response.Redirect(urlForCallback);//Solo per TEST sara
        // Attiva la Richiesta di Pagamento Telematico RPT solo se si è in possesso dello IUV
        var iuv = "";
        if (DS.flussocreditidetail != null && DS.flussocreditidetail.Rows.Count > 0) {
            var rFlussocreditidetail = DS.flussocreditidetail.First();
            iuv = rFlussocreditidetail["iuv"].ToString();
        }

        string url;
        var errore = PagoPaService.AttivaCredito(Conn as DataAccess, iuv, urlForCallback, out url);
        if (url == null) {
            url = PagoPaService.getUrlSitoIstituzionale(Conn as DataAccess);
        }

        if (errore != null && errore != "") {
            ShowClientMessage(errore, "Attenzione", System.Windows.Forms.MessageBoxButtons.OK);
        }

        //Server.Transfer(url);
        if ((url != null) && (url != "")) {
            Response.Redirect(url, false);
        }
    }


    private DataRow getAttributiTipoContrattoAttivo(object idestimkind, out string errore) {
        errore = "";
        if (idestimkind == null || idestimkind == DBNull.Value) {
            errore = "Il tipo di contratto attivo dev'essere specificato.";
            return null;
        }

        var QHS = Conn.GetQueryHelper();
        string filter = QHS.CmpEq("idestimkind", idestimkind);

        DataTable dt = Conn.RUN_SELECT("estimatekind", "idsor01, idsor02, idsor03, idsor04, idsor05", null, filter,
            null, false);
        if (dt == null || dt.Rows.Count == 0) {
            errore = $"Il tipo contratto attivo '{idestimkind}' non è stato trovato.";
            return null;
        }

        return dt.Rows[0];
    }

    private DataRow getAttributiTipoFattura(object idinvkind, out string errore) {
        errore = "";
        if (idinvkind == null || idinvkind == DBNull.Value) {
            errore = "Il tipo di fattura dev'essere specificato.";
            return null;
        }

        var QHS = Conn.GetQueryHelper();
        string filter = QHS.CmpEq("idinvkind", idinvkind);

        DataTable dt = Conn.RUN_SELECT("invoicekind", "idsor01, idsor02, idsor03, idsor04, idsor05", null, filter,
            null, false);
        if (dt == null || dt.Rows.Count == 0) {
            errore = $"Il tipo fatturao '{idinvkind}' non è stato trovato.";
            return null;
        }

        return dt.Rows[0];
    }

    private void MostraErrori(List<string> listaErrori, string from) {
        var msgBody = "";
        msgBody = from + " L'invio dei crediti ha riscontrato i seguenti problemi:" + "'\r\n";

        foreach (var e in listaErrori) {
            msgBody += e;
            msgBody += "\r\n";
        }

        ShowClientMessage(msgBody, "Avviso", System.Windows.Forms.MessageBoxButtons.OK);
    }

    void do_ScaricaPdf() {

        var listaErrori = new List<string>();
        //Reperimento degli avvisi di pagamento dal partner tecnologico
        var cert = new Dictionary<string, AvvisoPagamento>();
        foreach (DataRow r in DS.flussocreditidetail.Select()) {
            if (cert.ContainsKey(r["iuv"].ToString())) continue;
            string result;
            cert[r["iuv"].ToString()] =
                PagoPaService.ottieniAvvisoPagamento(Conn as DataAccess, r["iuv"].ToString(), out result);
            if (result != null) {
                string err = "(ScaricaPdf .ottieniAvvisoPagamento) " + result;
                err += "- idflusso=" + r["idflusso"] + " iddetail=" + r["iddetail"];
                err += " - IUV=" + r["iuv"].ToString() + " - ";


                listaErrori.Add(err);
                }
            }

        string error;
        byte[] allegatoPdf = null;
        //Scarica il pdf
        InformazioniEnteGenerico ente = PagoPaService.getInformazioniEnte(Conn as DataAccess, out error);
        if (error != null) {
            listaErrori.Add("(getInformazioniEnte)" + error);
            }
        else {
            foreach (var avviso in cert.Keys) {
                var avvPag = cert[avviso];
                if (avvPag == null) continue;
                //error = PagoPaService.InviaAvvisoPagamento(avvPag.ente, avvPag.debitore, avvPag.email, avvPag.pdf, Conn);
                allegatoPdf = avvPag.pdf;
                //if (error != null) listaErrori.Add(error);
                }
            }

        if (listaErrori.Count > 0) {
            MostraErrori(listaErrori, "(ScaricaPdf)");
            }
        else {
            //  ShowClientMessage("Flusso correttamente inviato", "Avviso", System.Windows.Forms.MessageBoxButtons.OK);
            //Session["AttachmentCommand"] = "select attachment from webpayment where " + fkey;
            //Session["AttachmentFileName"] = "select filename from webpayment where " + fkey;

            Session["document"] = allegatoPdf;

            var f = "window.open('AttachmentView.aspx');";
            if (!Page.ClientScript.IsClientScriptBlockRegistered(typeof(Page), "openwin"))
                Page.ClientScript.RegisterClientScriptBlock(
                    typeof(Page), "openwin", f, true);
            }

        }

    private void btnScaricaPDF_Click() {
        do_ScaricaPdf();
    }

    private void btnStampaRicevutaTelematica_Click() {
        DataRow curr = DS.webpayment.First();
        if (curr == null) {
            return;
        }
        var iuv = "";
        if (DS.flussocreditidetail != null && DS.flussocreditidetail.Rows.Count > 0) {
            var rFlussocreditidetail = DS.flussocreditidetail.First();
            iuv = rFlussocreditidetail["iuv"].ToString();
        }

        if (iuv == "") {
            ShowClientMessage("IUV assente. Ricevuta Telematica non disponibile.", "Attenzione", System.Windows.Forms.MessageBoxButtons.OK);
        }
        string pdfFileName, errmess;
        bool res = stampaRicevutaTelematica(iuv, out pdfFileName, out errmess);
        if (!res) {
            ShowClientMessage(errmess, "Attenzione", System.Windows.Forms.MessageBoxButtons.OK);
            return;
        }

        var f = "window.open('AttachmentView.aspx?doc=" + HttpUtility.UrlEncode(pdfFileName) + "');";
        if (!Page.ClientScript.IsClientScriptBlockRegistered(typeof(Page), "openwin"))
            Page.ClientScript.RegisterClientScriptBlock(
                typeof(Page), "openwin", f, true);
    }
    private void btnStampaCarrello_Click() {
        DataRow curr = DS.webpayment.First();
        if (curr == null) {
            return;
        }

        var nwebpayment = CfgFn.GetNoNullInt32(curr["nwebpayment"]);
        var ywebpayment = CfgFn.GetNoNullInt32(curr["ywebpayment"]);
        string pdfFileName, errmess;
        bool res = stampaCarrello(nwebpayment, ywebpayment, out pdfFileName, out errmess);
        if (!res) {
            ShowClientMessage(errmess, "Attenzione", System.Windows.Forms.MessageBoxButtons.OK);
            return;
        }

        var f = "window.open('AttachmentView.aspx?doc=" + HttpUtility.UrlEncode(pdfFileName) + "');";
        if (!Page.ClientScript.IsClientScriptBlockRegistered(typeof(Page), "openwin"))
            Page.ClientScript.RegisterClientScriptBlock(
                typeof(Page), "openwin", f, true);

    }
   
    private bool stampaCarrello(int nwebpayment, int ywebpayment, out string pdfFileName, out string errmess) {
        errmess = "";
        pdfFileName = "";
        var nomeReport = "carrello";

        DataTable myPrymaryTable = createStampaCarrelloTable();
        myPrymaryTable.Rows[0]["reportname"] = nomeReport;
        myPrymaryTable.Rows[0]["nwebpayment"] = nwebpayment;
        myPrymaryTable.Rows[0]["ywebpayment"] = ywebpayment;

        var modulereport = DS.report.getDetachedRowsFromDb(Conn, q.eq("reportname", nomeReport));

        if (modulereport == null) {
            errmess = "Report: '" + nomeReport + "' non trovato.";
            return false;
        }

        ;
        var rep = modulereport._First();
        var par = myPrymaryTable.Rows[0];

        var myRptDoc = Easy_DataAccess.GetReport(Conn as Easy_DataAccess, rep, par, out errmess);
        if (myRptDoc == null) {
            if (errmess == null || errmess == "") errmess = "Impossibile trovare il report";
            return false;
        }

        string FilePath = MapPath("ReportPDF");
        if (!FilePath.EndsWith("\\")) FilePath += "\\";

        var tempfilename = Guid.NewGuid() + ".pdf";
        pdfFileName = FilePath + tempfilename;
        string error;
        bool retExp = exportToPdf(myRptDoc, tempfilename, FilePath, out error);
        if (!retExp) errmess = "Impossibile esportare in pdf: " + tempfilename + " in " + FilePath + " (" + error + ")";
        return retExp;
    }

    DataTable createStampaCarrelloTable() {
        var myPrimaryTable = new DataTable("export_carrello");
        //Create a dummy primary key
        var dcpk = new DataColumn("DummyPrimaryKeyField", typeof(int)) {DefaultValue = 1};
        myPrimaryTable.Columns.Add(dcpk);
        myPrimaryTable.PrimaryKey = new[] {dcpk};

        myPrimaryTable.Columns.Add(new DataColumn("reportname", typeof(string)));
        myPrimaryTable.Columns.Add(new DataColumn("nwebpayment", typeof(int)));
        myPrimaryTable.Columns.Add(new DataColumn("ywebpayment", typeof(Int16)));
        
        var r = myPrimaryTable.NewRow();
        myPrimaryTable.Rows.Add(r);
        return myPrimaryTable;
    }

    private bool stampaRicevutaTelematica(object iuv, out string pdfFileName, out string errmess) {
        errmess = "";
        pdfFileName = "";
        var nomeReport = "ricevutatelematica";

        DataTable myPrymaryTable = createStampaRicevutaTelematicaTable();
        myPrymaryTable.Rows[0]["reportname"] = nomeReport;
        myPrymaryTable.Rows[0]["iuv"] = iuv;

        var modulereport = DS.report.getDetachedRowsFromDb(Conn, q.eq("reportname", nomeReport));

        if (modulereport == null) {
            errmess = "Report: '" + nomeReport + "' non trovato.";
            return false;
        }
    
        var rep = modulereport._First();
        var par = myPrymaryTable.Rows[0];

        var myRptDoc = Easy_DataAccess.GetReport(Conn as Easy_DataAccess, rep, par, out errmess);
        if (myRptDoc == null) {
            if (errmess == null || errmess == "") errmess = "Impossibile trovare il report";
            return false;
        }

        string FilePath = MapPath("ReportPDF");
        if (!FilePath.EndsWith("\\")) FilePath += "\\";

        var tempfilename = Guid.NewGuid() + ".pdf";
        pdfFileName = FilePath + tempfilename;
        string error;
        bool retExp = exportToPdf(myRptDoc, tempfilename, FilePath, out error);
        if (!retExp) errmess = "Impossibile esportare in pdf: " + tempfilename + " in " + FilePath + " (" + error + ")";
        return retExp;
    }

    DataTable createStampaRicevutaTelematicaTable() {
        var myPrimaryTable = new DataTable("export_ricevutatelematica");
        //Create a dummy primary key
        var dcpk = new DataColumn("DummyPrimaryKeyField", typeof(int)) { DefaultValue = 1 };
        myPrimaryTable.Columns.Add(dcpk);
        myPrimaryTable.PrimaryKey = new[] { dcpk };

        myPrimaryTable.Columns.Add(new DataColumn("reportname", typeof(string)));
        myPrimaryTable.Columns.Add(new DataColumn("iuv", typeof(string)));

        var r = myPrimaryTable.NewRow();
        myPrimaryTable.Rows.Add(r);
        return myPrimaryTable;
    }

    private void btnScaricaFatture_Click() {
        do_ScaricaFatture();
    }

    private bool hasFatture() {
        var idreg = Session["CodiceUtente"];
        if (idreg == null) {
            SessionTimeOut(this);
            return false;
        }

        if (Session["CodiceUtente_fat"] != null && Session["CodiceUtente_fat"] == idreg)
            return (bool) Session["hasfat"];

        foreach (DataRow rflussocreditidetail in DS.flussocreditidetail.Select()) {
            DS.invoice.Clear();
            DS.invoice.getFromDb(Conn, q.eq("idreg", idreg) & q.eq("ninv", rflussocreditidetail["ninv"]) &
                                       q.eq("yinv", rflussocreditidetail["yinv"]) & q.eq("idinvkind",
                                           rflussocreditidetail["idinvkind"]));

            if (DS.invoice.Select()._HasRows()) {
                Session["CodiceUtente_fat"] = idreg;
                Session["hasfat"] = true;
                return true;
            }

        }

        Session["CodiceUtente_fat"] = idreg;
        Session["hasfat"] = false;
        return false;
    }


    void do_ScaricaFatture() {
        var idreg = Session["CodiceUtente"];

        if (idreg == null) {
            SessionTimeOut(this);
            return;
        }

        string errmess;
        string pdfFileName;

        List<string> FilesFatture = new List<string>();
        List<List<int>> Fatture = new List<List<int>>();

        foreach (DataRow rflussocreditidetail in DS.flussocreditidetail.Select()) {
            DS.invoice.Clear();
            DS.invoice.getFromDb(Conn, q.eq("idreg", idreg) & q.eq("active", "S") &
                                       q.eq("ninv", rflussocreditidetail["ninv"]) &
                                       q.eq("yinv", rflussocreditidetail["yinv"]) & q.eq("idinvkind",
                                           rflussocreditidetail["idinvkind"]));

            foreach (invoiceRow rinvoice in DS.invoice.Select()) {

                bool esiste = false;
                foreach (var a in Fatture) {
                    if (a[0] == rinvoice.ninv && a[1] == rinvoice.yinv && a[2] == rinvoice.idinvkind) {
                        esiste = true;
                        break;
                    }
                }

                if (!esiste) {
                    bool res = stampaFattura(rinvoice, out errmess, out pdfFileName);
                    if (res) {
                        List<int> fat = new List<int>();
                        fat.Add(CfgFn.GetNoNullInt32(rinvoice.ninv));
                        fat.Add(CfgFn.GetNoNullInt32(rinvoice.yinv));
                        fat.Add(CfgFn.GetNoNullInt32(rinvoice.idinvkind));
                        Fatture.Add(fat);
                        FilesFatture.Add(pdfFileName);
                    }
                    else {
                        ShowClientMessage(errmess, "Attenzione", System.Windows.Forms.MessageBoxButtons.OK);
                    }
                }
            }
        }

        int i = 0;
        foreach (var fileName in FilesFatture) {
            var f = "window.open('AttachmentView.aspx?doc=" + HttpUtility.UrlEncode(fileName) + "');";
            if (!Page.ClientScript.IsClientScriptBlockRegistered(typeof(Page), "openwin" + i.ToString()))
                Page.ClientScript.RegisterClientScriptBlock(
                    typeof(Page), "openwin" + i++.ToString(), f, true);
        }
    }

    private bool stampaFattura(invoiceRow invoice, out string errmess, out string pdfFileName) {
        pdfFileName = "";
        registryRow registryrow;
        var nomeReport = "fatturavendita";
        var drReg = DS.registry.getDetachedRowsFromDb(Conn, q.eq("idreg", invoice.idreg) & q.eq("active", "S"));
        if (drReg == null) {
            errmess = $"Registry non trovato: \'{invoice.idreg}\'";
            return false;
        }

        registryrow = drReg._First();

        DataTable myPrymaryTable = createPrimaryTable();
        myPrymaryTable.Rows[0]["ayear"] = invoice.yinv;
        myPrymaryTable.Rows[0]["printkind"] = "I";
        myPrymaryTable.Rows[0]["reportname"] = nomeReport;
        myPrymaryTable.Rows[0]["idinvkind"] = invoice.idinvkind;
        myPrymaryTable.Rows[0]["ninv_start"] = invoice.ninv;
        myPrymaryTable.Rows[0]["ninv_stop"] = invoice.ninv;
        if (registryrow.p_iva == null)
            myPrymaryTable.Rows[0]["showcfpiva"] = "C";
        else
            myPrymaryTable.Rows[0]["showcfpiva"] = "P";

        var modulereport = DS.report.getDetachedRowsFromDb(Conn, q.eq("reportname", nomeReport));

        if (modulereport == null) {
            errmess = "Report: '" + nomeReport + "' non trovato.";
            return false;
        }

        ;
        var rep = modulereport._First();
        var par = myPrymaryTable.Rows[0];

        var myRptDoc = Easy_DataAccess.GetReport(Conn as Easy_DataAccess, rep, par, out errmess);
        if (myRptDoc == null) {
            return false;
        }

        string FilePath = MapPath("ReportPDF");
        if (!FilePath.EndsWith("\\")) FilePath += "\\";

        var tempfilename = Guid.NewGuid() + ".pdf";
        pdfFileName = FilePath + tempfilename;
        string error;
        bool retExp = exportToPdf(myRptDoc, tempfilename, FilePath, out error);
        if (!retExp) errmess = "Impossibile esportare in pdf: " + tempfilename + " in " + FilePath + " (" + error + ")";
        return retExp;
    }

    /// <summary>
    /// Restituisce il percorso del report in formato PDF a cui puntare con Response.Redirect
    /// </summary>
    /// <param name="rd"></param>
    /// <param name="fileName"></param>
    /// <param name="relativePath"></param>
    /// <returns></returns>
    private bool exportToPdf(ReportDocument rd, string fileName, string relativePath, out string error) {
        error = "";
        var tempfilename = relativePath + fileName;
        // Declare variables and get the export options.
        //ExportOptions exportOpts = new ExportOptions();
        //PdfRtfWordFormatOptions pdfRtfWordOpts = new PdfRtfWordFormatOptions ();

        // Set the export format.
        //pdfRtfWordOpts.FirstPageNumber = 1;
        //pdfRtfWordOpts.LastPageNumber = 2;
        //pdfRtfWordOpts.UsePageRange = true;
        //RD.ExportOptions.FormatOptions = pdfRtfWordOpts;
        rd.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
        rd.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;

        DiskFileDestinationOptions diskOpts = new DiskFileDestinationOptions {DiskFileName = tempfilename};
        rd.ExportOptions.DestinationOptions = diskOpts;

        // Export the report
        try {
            rd.Export();
            bool existfile = File.Exists(tempfilename);
            if (!existfile) error = "export fallito";
            return existfile;
        }
        catch (Exception e) {
            if (!e.ToString().Contains("0x8000030E")) {
                error =
                    "E' necessario disinstallare l'aggiornamento di windows KB3102429 per poter effettuare la stampa. - " +
                    e.Message;
                return false;
            }

            //MessageBox.Show(this,
            //	"E' necessario disinstallare l'aggiornamento di windows KB3102429 per poter effettuare la stampa.\nSeguono istruzioni su come procedere.",
            //	"Avviso");
            //System.Diagnostics.Process.Start("disinstalla_kb3102429.pdf");
            error = e.Message;
            return false;
        }
    }

    DataTable createPrimaryTable() {
        var myPrimaryTable = new DataTable("export");
        //Create a dummy primary key
        var dcpk = new DataColumn("DummyPrimaryKeyField", typeof(int)) {DefaultValue = 1};
        myPrimaryTable.Columns.Add(dcpk);
        myPrimaryTable.PrimaryKey = new[] {dcpk};

        myPrimaryTable.Columns.Add(new DataColumn("reportname", typeof(string)));
        myPrimaryTable.Columns.Add(new DataColumn("ayear", typeof(int))); // { DefaultValue = esercizio });
        myPrimaryTable.Columns.Add(new DataColumn("printkind", typeof(string)) {DefaultValue = "I"});
        myPrimaryTable.Columns.Add(new DataColumn("idinvkind", typeof(int)));
        myPrimaryTable.Columns.Add(new DataColumn("ninv_start", typeof(int)));
        myPrimaryTable.Columns.Add(new DataColumn("ninv_stop", typeof(int)));
        myPrimaryTable.Columns.Add(new DataColumn("official", typeof(string)) {DefaultValue = "N"});
        myPrimaryTable.Columns.Add(new DataColumn("showcfpiva", typeof(string)) {DefaultValue = "C"});
        myPrimaryTable.Columns.Add(new DataColumn("autoinvoice", typeof(string)) {DefaultValue = "N"});

        var r = myPrimaryTable.NewRow();
        myPrimaryTable.Rows.Add(r);
        return myPrimaryTable;
    }

    private void AllineaTassonomia() {
        DataRow[] Righe = DS.flussocreditidetail.Select(QHC.IsNotNull("codicetassonomia"), "importoversamento desc");
      
        if (Righe.Length > 0) {
            object codiceTassonomiaPreval = Righe[0]["codicetassonomia"];
            foreach (var r in DS.flussocreditidetail.Select()) {
                r["codicetassonomia"] = codiceTassonomiaPreval;
            }
        }
 
    }

    private void inviacredito() {

        DataRow curr = DS.webpayment.First();
        ProcediPagamento.Visible = false;
        AllineaTassonomia();
        var listaErrori = PagoPaService.InviaCrediti(Conn as DataAccess, DS);

        if (listaErrori != null && listaErrori.Count > 0) {
            MostraErrori(listaErrori, "(.InviaCrediti)");
            ProcediPagamento.Enabled = true;
            return;
            }

        curr["idwebpaymentstatus"] = 3; /*Credito inviato alla banca*/
        // new
        var postData = new Easy_PostData_NoBL();
        postData.initClass(DS, Conn);
        var pmc = postData.DO_POST_SERVICE();
        if (pmc.Count > 0) {
            var errore = "Errore del server dati";
            ShowClientMessage(errore, "Attenzione", System.Windows.Forms.MessageBoxButtons.OK);
            //PulisciCampi();
            return;
            }

        listaErrori = new List<string>();

        //Reperimento degli avvisi di pagamento dal partner tecnologico
        var cert = new Dictionary<string, AvvisoPagamento>();
        foreach (DataRow r in DS.flussocreditidetail.Select()) {
            if (cert.ContainsKey(r["iuv"].ToString())) continue;
            string result;
            cert[r["iuv"].ToString()] =
                PagoPaService.ottieniAvvisoPagamento(Conn as DataAccess, r["iuv"].ToString(), out result);
            if (result != null) {
                string err = "(inviacredito .ottieniAvvisoPagamento) " + result;
                err += "- idflusso=" + r["idflusso"] + " iddetail=" + r["iddetail"];
                err += " - IUV=" + r["iuv"].ToString() + " - ";


                listaErrori.Add(err);
                }
            }

        if (listaErrori.Count > 0) {
            MostraErrori(listaErrori, ".ottieniAvvisoPagamento");
            }

        }

    private void generacredito() {
        if (PState.InsertMode) {
            ShowClientMessage("E' necessario salvare, prima di Procedere.", "Attenzione",
                System.Windows.Forms.MessageBoxButtons.OK);
            return;
        }

        if (DS.flussocrediti.Rows.Count > 0) {
            return;
        }

        //if (DS.flussocrediti.Rows.Count > 0 || DS.flussocreditidetail.Rows.Count>0) {
        //    ShowClientMessage("I crediti sono stati già creati.", "Attenzione",
        //        System.Windows.Forms.MessageBoxButtons.OK);
        //    return;
        //}
        var curr = DS.webpayment.First();

        if (curr.RowState==DataRowState.Added) {
            ShowClientMessage("E' necessario salvare, prima di Procedere.", "Attenzione",
                System.Windows.Forms.MessageBoxButtons.OK);
            return;
        }

        var firstDetail = DS.webpaymentdetail.First();
        object idestimkind = firstDetail["idestimkind"];
        object idinvkindFirst = firstDetail["idinvkind"];
        if (idestimkind == DBNull.Value && idinvkindFirst == DBNull.Value)
            idestimkind = configManager.getCfg("tipocontrattoattivo").ToString();

        // Valorizza Flussocrediti e flussocreditidetail

        string errore = "";
        DataRow attrs = null;
        if (idestimkind != null && idestimkind != DBNull.Value) {
            attrs = getAttributiTipoContrattoAttivo(idestimkind, out errore);
        }
        else {
            if (idinvkindFirst != null) {
                attrs = getAttributiTipoFattura(idinvkindFirst, out errore);
            }
        }

        var dispatcher = new Meta_EasyDispatcher(Conn as DataAccess);
        var metaFlussoCrediti = dispatcher.Get("flussocrediti");
        metaFlussoCrediti.SetDefaults(DS.flussocrediti);

        //DS.flussocreditidetail.Clear();
        //serviva se esiste relazione tra flussocreditidetail e list che carica crediti durante il salvataggio della prenotazione "mainsave"

        var rFlussoCrediti = metaFlussoCrediti.Get_New_Row(null, DS.flussocrediti);

        rFlussoCrediti["flusso"] = DBNull.Value;
        rFlussoCrediti["istransmitted"] = "N";
        rFlussoCrediti["filename"] = "Portale dei pagamenti Easy";//"Creato da webpayment";
        rFlussoCrediti["docdate"] = DateTime.Now;
        ;
        rFlussoCrediti["idestimkind"] = idestimkind;
        if (attrs == null) {
            ShowClientMessage(errore, "Attenzione", System.Windows.Forms.MessageBoxButtons.OK);

            rFlussoCrediti["idsor01"] = DBNull.Value;
            rFlussoCrediti["idsor02"] = DBNull.Value;
            rFlussoCrediti["idsor03"] = DBNull.Value;
            rFlussoCrediti["idsor04"] = DBNull.Value;
            rFlussoCrediti["idsor05"] = DBNull.Value;
        }
        else {
            rFlussoCrediti["idsor01"] = attrs["idsor01"];
            rFlussoCrediti["idsor02"] = attrs["idsor02"];
            rFlussoCrediti["idsor03"] = attrs["idsor03"];
            rFlussoCrediti["idsor04"] = attrs["idsor04"];
            rFlussoCrediti["idsor05"] = attrs["idsor05"];
        }

        rFlussoCrediti["ct"] = DateTime.Now;
        rFlussoCrediti["cu"] = createdBy;
        rFlussoCrediti["lt"] = DateTime.Now;
        rFlussoCrediti["lu"] = createdBy;
        curr["idflussocrediti"] = rFlussoCrediti["idflusso"];

        foreach (var r in DS.webpaymentdetail.Select()) {
            //ShowClientMessage(DS.webpaymentdetail.Select().Length.ToString(), "INFORMAZIONE TEST", System.Windows.Forms.MessageBoxButtons.OK);

            //string filterShowcasedetail = QHC.CmpEq("idlist", r["idlist"]);
            //var showcasedetail = DS.showcasedetail.Select(filterShowcasedetail)._First();
            var idestimkindDetail = r["idestimkind"];
            var idinvkind = r["idinvkind"];
            
            string filterList = QHC.CmpEq("idlist", r["idlist"]);
            var list = DS.list.Select(filterList)._First();
            var accmot = Conn.readObject("listclass", q.eq("idlistclass", list["idlistclass"]),
                "idaccmotive,idfinmotive,idfinmotive_iva,idaccmotivecredit");
            object idaccmotive = accmot["idaccmotive"];
            object idfinmotive = accmot["idfinmotive"];
            object idfinmotive_iva = accmot["idfinmotive_iva"];
            object idaccmotivecredit = accmot["idaccmotivecredit"];
            var filterStore = QHC.CmpEq("idstore", r["idstore"]);
            var idupb = Conn.DO_READ_VALUE("store", filterStore, "idupb"); //?? non da showcasedetail ??
            var metaFlussoCreditiDetail = dispatcher.Get("flussocreditidetail");
            metaFlussoCreditiDetail.SetDefaults(DS.flussocreditidetail);
            var rFlussoCreditiDetail = metaFlussoCreditiDetail.Get_New_Row(rFlussoCrediti, DS.flussocreditidetail);

            if (idinvkind != DBNull.Value) {
                rFlussoCreditiDetail["idinvkind"] = idinvkind;
            }
            else {
                rFlussoCreditiDetail["idestimkind"] = idestimkindDetail;
            }

            //if (showcasedetail["competencystart"] == DBNull.Value) {
            //	rFlussoCreditiDetail["competencystart"] = DateTime.Now.Date;
            //} else {
            rFlussoCreditiDetail["competencystart"] = r["competencystart"];
            //}
            //if (showcasedetail["competencystop"] == DBNull.Value) {
            //	rFlussoCreditiDetail["competencystop"] = DateTime.Now.Date;
            //} else {
            rFlussoCreditiDetail["competencystop"] = r["competencystop"];
            //}


            rFlussoCreditiDetail["idupb_iva"] = r["idupb_iva"];

            rFlussoCreditiDetail["annotations"] = r["annotations"];

            //rFlussoCreditiDetail["idflusso"] = rFlussoCrediti["idflusso"];
            rFlussoCreditiDetail["idlist"] = r["idlist"];
            if (r["idlist"] != DBNull.Value) {
	            var idtassonomia = Conn.readValue("list",q.eq("idlist",r["idlist"]),"idtassonomia");
	            if (idtassonomia != DBNull.Value) {
		            rFlussoCreditiDetail["codicetassonomia"] = Conn.readValue("tassonomia_pagopa",
			            q.eq("idtassonomia", idtassonomia), "causale");
	            }
            }
            
            //rFlussoCreditiDetail["iddetail"] = iddetail;
            rFlussoCreditiDetail["importoversamento"] =
                CfgFn.GetNoNullDecimal(r["price"]) * CfgFn.GetNoNullDecimal(r["number"]);
            rFlussoCreditiDetail["tax"] = CfgFn.GetNoNullDecimal(r["tax"]);
            var idivakind = CfgFn.GetNoNullInt32(r["idivakind"]);
            rFlussoCreditiDetail["idivakind"] = idivakind == 0 ? DBNull.Value : (object) idivakind;
            var idsor1 = CfgFn.GetNoNullInt32(r["idsor1"]);
            rFlussoCreditiDetail["idsor1"] = idsor1 == 0 ? DBNull.Value : (object)idsor1;
            var idsor2 = CfgFn.GetNoNullInt32(r["idsor2"]);
            rFlussoCreditiDetail["idsor2"] = idsor2 == 0 ? DBNull.Value : (object)idsor2;
            var idsor3 = CfgFn.GetNoNullInt32(r["idsor3"]);
            rFlussoCreditiDetail["idsor3"] = idsor3 == 0 ? DBNull.Value : (object)idsor3;

            rFlussoCreditiDetail["number"] = CfgFn.GetNoNullInt32(r["number"]);

            var cf = Conn.readValue("registry", q.eq("idreg", curr["idreg"]), "cf");
            var pIva = Conn.readValue("registry", q.eq("idreg", curr["idreg"]), "p_iva");
            rFlussoCreditiDetail["cf"] = cf;
            rFlussoCreditiDetail["p_iva"] = pIva;

            rFlussoCreditiDetail["iduniqueformcode"] = $"easyboll_{curr["idwebpayment"]}";
            //if (request.IUV != null) rFlussoCreditiDetail["iuv"] = request.IUV;     
            rFlussoCreditiDetail["nform"] = DBNull.Value;
            rFlussoCreditiDetail["idfinmotive"] = idfinmotive;
            rFlussoCreditiDetail["idfinmotive_iva"] = idfinmotive_iva;
            rFlussoCreditiDetail["idaccmotiverevenue"] = idaccmotive;
            if ((idaccmotivecredit != DBNull.Value) && (idaccmotivecredit != null)) {
                rFlussoCreditiDetail["idaccmotivecredit"] = idaccmotivecredit;
            }
            else {
                var causaleCredito = configManager.getCfg("CausaleCredito");
                rFlussoCreditiDetail["idaccmotivecredit"] = causaleCredito;
            }

            rFlussoCreditiDetail["idaccmotiveundotax"] = DBNull.Value;

            rFlussoCreditiDetail["idaccmotiveundotaxpost"] = DBNull.Value;
            rFlussoCreditiDetail["stop"] = DBNull.Value;


            if ((r["paymentexpiring"] != DBNull.Value) && (r["paymentexpiring"] != null)) {
                rFlussoCreditiDetail["expirationdate"] =
                    DateTime.Now.AddDays(CfgFn.GetNoNullInt32(r["paymentexpiring"]));
            }
            else {
                DateTime oggi = DateTime.Now;
                int ngiorni = 30;
                rFlussoCreditiDetail["expirationdate"] = oggi.AddDays(ngiorni);
            }

            rFlussoCreditiDetail["description"] = list["description"];
            rFlussoCreditiDetail["idreg"] = curr["idreg"];
            if (r["idupb"] == DBNull.Value) {
                rFlussoCreditiDetail["idupb"] = idupb;// letto da store
            }
            else {
                rFlussoCreditiDetail["idupb"] = r["idupb"];//è stato letto da showcasedetail
            }

            rFlussoCreditiDetail["flag_showcase"] = r["flag_showcase"];
            rFlussoCreditiDetail["ct"] = DateTime.Now;
            rFlussoCreditiDetail["cu"] = "import_flussostudenti";
            rFlussoCreditiDetail["lt"] = DateTime.Now;
            rFlussoCreditiDetail["lu"] = "import_flussostudenti";

            //DS.flussocreditidetail.Rows.Add(rFlussoCreditiDetail);

        }

        curr["idwebpaymentstatus"] = 2; // -->Credito generato
        var postData = new Easy_PostData_NoBL();
        postData.initClass(DS, Conn);

        var pmc = postData.DO_POST_SERVICE();
        if (pmc.Count > 0) {
            errore = "Errore del server dati";
            ShowClientMessage(errore, "Attenzione", System.Windows.Forms.MessageBoxButtons.OK);
            DS.flussocreditidetail.Clear();
            DS.flussocrediti.Clear();
            //PulisciCampi();
            return;
        }

    }

    public override void AfterLink(bool firsttime, bool formToLink) {

        QHC = new CQueryHelper();
        QHS = Conn.GetQueryHelper();
        Meta.CanInsert = false;
        Meta.CanInsertCopy = false;
        //Meta.CanCancel = false;
        //Meta.CanSave = false;
        //Meta.SearchEnabled = false;

        if (Meta.edit_type.ToLower() == "defaultpagamenti") {
            Meta.Name = "Prenotazione";
        }

        if (Meta.edit_type.ToLower() == "defaultpagamentibozze") {
            Meta.Name = "Prenotazione(Bozza)";
        }

        if (Meta.edit_type.ToLower() == "defaultpagamentipagati") {
            Meta.Name = "Prenotazione(Pagata)";
        }

        int idreg = CfgFn.GetNoNullInt32(Session["CodiceUtente"]);
        string filterUtente = QHC.CmpEq("idreg", idreg);

        GetData.SetSorting(DS.webpaymentview, "ywebpayment desc,nwebpayment desc");
        GetData.SetStaticFilter(DS.webpaymentview, filterUtente);

        if (formToLink) {
            DrpStatus.DataSource = DS.webpaymentstatus;
            DrpStatus.DataValueField = "idwebpaymentstatus";
            DrpStatus.DataTextField = "description";
        }

        Meta.DefaultListType = "list";
        SearchTable = "webpaymentview";
        HelpForm.SetFormatForColumn(DS.webpaymentdetail.Columns["number"], "N");
        if (Session["comebackpaymentrow"] != null) {
            object idwebpayment = Session["comebackpaymentrow"];
            MetaData.SetDefault(DS.webpayment, "idwebpayment", idwebpayment);
        }

        }


    public bool HasUnauthorizedDetails() {
        return true;
    }

    public bool HasPendingAuthDetails() {
        return true;
    }


    public override void AfterClear() {
        DrpStatus.Enabled = true;
        disabilitaInfoAnagrafica(true);
        //txtywebpayment.ReadOnly = false;
        //txtnbooking.ReadOnly = false;
        fillDsWithSessionValues();
        btnvetrina.Visible = false;

        Scaricapdf.Visible = false;
        ScaricaFatture.Visible = false;
        StampaCarrello.Visible = false;
        StampaRicevutaTelematica.Visible = false;
        ProcediPagamento.Visible = false;
        ProcediPagamentoOnLine.Visible = false;
        SalvaBozza.Visible = false;

        if (Session["comebackpaymentrow"] != null) {
            var idwebpayment = Session["comebackpaymentrow"];
            Session["comebackpaymentrow"] = null;
            var filter = QHS.AppAnd(QHS.CmpEq("idwebpayment", idwebpayment), Meta.StartFilter);
            CommFun.DoMainCommand("maindosearch.list." + filter);
        }

        if (Meta.edit_type == "defaultpagamentibozze" && PState.var["listed"] == null) {
            PState.var["listed"] = "S";
            var filter = QHS.CmpEq("idwebpaymentstatus", 1);
            CommFun.DoMainCommand("maindosearch.list." + filter);
        }

        if (Meta.edit_type == "defaultpagamentipagati" && PState.var["listed"] == null) {
            PState.var["listed"] = "S";
            var filter = QHS.CmpGe("idwebpaymentstatus", 3);
            CommFun.DoMainCommand("maindosearch.list." + filter);
        }

        //La pagina si apre sempre in ricerca
        if (Meta.edit_type == "defaultpagamenti" && PState.var["listed"] == null) {
            //PState.var["listed"] = "S";
            //CommFun.DoMainCommand("maindosearch.list");
        }

    }

    protected void btnvetrina_Click(object sender, EventArgs e) {
        rebuildSessionFromDs();
        ApplicationState aps = ApplicationState.GetApplicationState(this);
        var m = aps.Dispatcher.Get("showcase");
        m.Name = "Sezioni";
        m.edit_type = "defaultpagamenti";
        aps.CallPage(this, m, false);
    }

    public void rebuildSessionFromDs() {
        var ar = new ArrayList();
        if (DS.webpaymentdetail.Rows.Count == 0)
            return;
        foreach (DataRow dr in DS.webpaymentdetail.Rows) {
            if (dr.RowState != DataRowState.Added)
                continue;
            if (DS.webpayment.Rows.Count == 0) return;
                var webpaymentRow = DS.webpayment.Rows[0];
            Dictionary<int, int> dicflag = (Dictionary<int, int>) Session["dic_showcase"];
            int iddetail = CfgFn.GetNoNullInt32(dr["iddetail"]);
            var ci = new cartitem {
                idlist = CfgFn.GetNoNullInt32(dr["idlist"]),
                idstore = CfgFn.GetNoNullInt32(dr["idstore"]),
                quantity = CfgFn.GetNoNullInt32(dr["number"]),
                price = CfgFn.GetNoNullDecimal(dr["price"]),
                idupb = dr["idupb"].ToString(),
                idestimkind = dr["idestimkind"].ToString(),
                paymentexpiring = CfgFn.GetNoNullInt32(dr["paymentexpiring"]),
                idivakind = CfgFn.GetNoNullInt32(dr["idivakind"]),
                annotations = dr["annotations"].ToString(),
                iva = CfgFn.GetNoNullDecimal(dr["tax"]),
                idinvkind = dr["idinvkind"].ToString(),
                competencystart = dr["competencystart"].ToString(),
                competencystop = dr["competencystop"].ToString(),
                idsor1 = CfgFn.GetNoNullInt32(dr["idsor1"]),
                idsor2 = CfgFn.GetNoNullInt32(dr["idsor2"]),
                idsor3 = CfgFn.GetNoNullInt32(dr["idsor3"]),
                idupb_iva = dr["idupb_iva"].ToString(),
                idshowcase = dicflag[iddetail]
                };
            ar.Add(ci);
        }

        if (ar.Count > 0)
            Session["Cart"] = ar;
    }

    public override void BeforeFill() {
        if (Session["Cart"] == null)
            return;
        alignDsWithSession();
    }

    /// <summary>
    /// Viene chiamata dal BeforeFill quando la vetrina è aperta a partire da QUESTA pagina
    /// </summary>
    public void alignDsWithSession() {

        if (Session["Cart"] == null)
            return;
        var ar = (ArrayList) Session["Cart"];
        DataRow parentRow = DS.webpayment.Rows[0];
        QHC = new CQueryHelper();
        QHS = Conn.GetQueryHelper();

        MetaData md = appState.Dispatcher.Get("webpaymentdetail");
        string ErrMsg = "Alcune Voci selezionate sono state scartate perché già presenti nella prenotazione";
        bool dispmessage = false;
        foreach (var t in ar) {
            var ci = (cartitem) t;
            string filternoStock = QHC.AppAnd(QHC.CmpEq("idlist", ci.idlist), QHC.CmpEq("idstore", ci.idstore));
            DataRow[] dr = DS.webpaymentdetail.Select(filternoStock);
            if (dr.Length != 0) {
                //if (DR[0]["idstock"].ToString() != CI.idstock.ToString()) {
                dispmessage = true;
                //}
                //else {
                dr[0]["number"] = ci.quantity;
                //}
            }
            else {
                DataRow drNew = md.Get_New_Row(parentRow, DS.webpaymentdetail);

                var T = Conn.RUN_SELECT("listview", "idlist,description,authrequired", null,
                    QHS.CmpEq("idlist", ci.idlist),
                    null, false);
                var rList = T.Rows[0];

                drNew["!list"] = rList["description"];
                drNew["idlist"] = ci.idlist;
                drNew["annotations"] = ci.annotations;

                var filter = QHS.CmpEq("idstore", ci.idstore);
                var tStore = Conn.RUN_SELECT("store", "*", null, filter, null, false);
                var rStore = tStore.Rows[0];
                drNew["idstore"] = ci.idstore;
                drNew["idsor1"] = ci.idsor1;
                drNew["idsor2"] = ci.idsor2;
                drNew["idsor3"] = ci.idsor3;

                drNew["!store"] = rStore["description"];
                drNew["number"] = ci.quantity;
                //drNew["idivakind"] = ci.idivakind==0? DBNull.Value:(object)0; ???
                drNew["idivakind"] = ci.idivakind == 0 ? DBNull.Value : (object) ci.idivakind;
                if (CfgFn.GetNoNullInt32(ci.idivakind) != 0) {
                    var ivakind = Conn.readObject("ivakind", q.eq("idivakind", ci.idivakind), "rate");
                    double rate = CfgFn.GetNoNullDouble(ivakind["rate"]);
                    double iva = CfgFn.RoundValuta(CfgFn.GetNoNullDouble(ci.price) * rate * ci.quantity);
                    drNew["tax"] = iva;
                }

                if (ci.paymentexpiring != 0)
                    drNew["paymentexpiring"] = ci.paymentexpiring;
                if (ci.price != 0)
                    drNew["price"] = ci.price;

                if (ci.idupb != "") {
                    drNew["idupb"] = ci.idupb;
                }
                else {
                    drNew["idupb"] = rStore["idupb"];
                }
                if (ci.idupb_iva != "") {
                    drNew["idupb_iva"] = ci.idupb_iva;
                }
                drNew["flag_showcase"] = ValorizzaFlag_showcase(ci.idshowcase);
                if (ci.idestimkind != "") {
                    drNew["idestimkind"] = ci.idestimkind;
                }
                else {
                    drNew["idestimkind"] = rStore["idestimkind"];
                }

            }

            if (dispmessage)
                ShowClientMessage(ErrMsg, "Attenzione", System.Windows.Forms.MessageBoxButtons.OK);
        }

        Session["Cart"] = null;
    }

    public ulong ValorizzaFlag_showcase( int idshowcase) {
        if (Session["ldap_maschera"] == DBNull.Value)
            return 0;

        var showcase = Conn.readObject("showcase", q.eq("idshowcase", idshowcase), "flagldapvisibility");
        var mascheraServizi = (ulong)CfgFn.GetNoNullInt32(Session["ldap_maschera"]);
        var flagldapvisibility = (ulong)CfgFn.GetNoNullInt32(showcase["flagldapvisibility"]);
        var flag_showcase = (flagldapvisibility &  mascheraServizi);
        return flag_showcase;
    }
    public void SetSortingDefaults(DataRow BookDtl) {
    }

    public void calcolaTotale() {
        if (PState.IsEmpty)
            return;
        var curr = PState.CurrentRow;
        decimal prezzoTot = 0;
        decimal quantitaTot = 0;
        foreach (DataRow R in DS.webpaymentdetail.Select()) {
            decimal quantita = CfgFn.GetNoNullDecimal(R["number"]);
            prezzoTot += (CfgFn.GetNoNullDecimal(R["price"]) * quantita) + CfgFn.GetNoNullDecimal(R["tax"]);
            quantitaTot += quantita;
        }

        txtprezzototale.Text = prezzoTot.ToString("c");
        txtquantita_totale.Text = quantitaTot.ToString("n");
    }

    public void fillDsWithSessionValues() {
        if (Session["Cart"] == null)
            return;
        var ar = (ArrayList) Session["Cart"];
        Session["Cart"] = null;
        CommFun.DoMainCommand("maininsert");
        Meta.SetDefaults(DS.webpayment);
        var webpaymentRow = DS.webpayment.Rows[0];
        webpaymentRow["ywebpayment"] = Conn.Security.GetEsercizio();
        QHS = Conn.GetQueryHelper();
        var MD = appState.Dispatcher.Get("webpaymentdetail");
        string message = "Alcuni articoli prenotati sono stati scartati perché già presenti nella prenotazione";
        bool dispmessage = false;

        foreach (var t in ar) {
            cartitem ci = (cartitem) t;
            string filter = QHC.CmpEq("idlist", ci.idlist);
            var details = DS.webpaymentdetail.Select(filter);
            if ((details.Length) > 0) {
                dispmessage = true;
                continue;
            }

            MD.SetDefaults(DS.webpaymentdetail);

            webpaymentdetailRow webpaymentdetailrow =
                MD.Get_New_Row(webpaymentRow, DS.webpaymentdetail) as webpaymentdetailRow;

            webpaymentdetailrow["idlist"] = ci.idlist;
            //string filterlist = QHS.CmpEq("idlist", ci.idlist);
            DataTable tList = Conn.RUN_SELECT("list", "*", null, filter, null, false);
            DataRow rList = tList.Rows[0];
            webpaymentdetailrow["!list"] = rList["description"];
            webpaymentdetailrow["idstore"] = ci.idstore;
            if (ci.price != 0) {
                webpaymentdetailrow["price"] = ci.price;
            }

            filter = QHS.CmpEq("idstore", ci.idstore);
            DataTable tStore = Conn.RUN_SELECT("store", "*", null, filter, null, false);
            DataRow rStore = tStore.Rows[0];
            if (ci.idupb != "") {
                webpaymentdetailrow["idupb"] = ci.idupb;
            }
            else {
                webpaymentdetailrow["idupb"] = rStore["idupb"];
            }

            webpaymentdetailrow["annotations"] = ci.annotations;

            if (ci.idestimkind != "") {
                webpaymentdetailrow["idestimkind"] = ci.idestimkind;
            }
            else {
                webpaymentdetailrow["idestimkind"] = rStore["idestimkind"];
            }

            if (!string.IsNullOrEmpty(ci.idinvkind))
                webpaymentdetailrow["idinvkind"] = ci.idinvkind;

            if (!string.IsNullOrEmpty(ci.competencystart)) {
                DateTime dcompetencystart =
                    DateTime.ParseExact(ci.competencystart, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                webpaymentdetailrow["competencystart"] = dcompetencystart;
            }
            webpaymentdetailrow["idsor1"] = ci.idsor1 == 0 ? DBNull.Value : (object)ci.idsor1;
            webpaymentdetailrow["idsor2"] = ci.idsor2 == 0 ? DBNull.Value : (object)ci.idsor2;
            webpaymentdetailrow["idsor3"] = ci.idsor3 == 0 ? DBNull.Value : (object)ci.idsor3;

            if (!string.IsNullOrEmpty(ci.competencystop)) {
                DateTime dcompetencystop =
                    DateTime.ParseExact(ci.competencystop, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                webpaymentdetailrow["competencystop"] = dcompetencystop;
            }
            webpaymentdetailrow["flag_showcase"] = ValorizzaFlag_showcase(ci.idshowcase);

            Dictionary<int, int> dicflag = (Dictionary<int, int>)Session["dic_showcase"];
            if (dicflag == null) {
                dicflag = new Dictionary<int, int>();
            }
            int _idetail = CfgFn.GetNoNullInt32(webpaymentdetailrow["iddetail"]);
            if (!(dicflag.ContainsKey(_idetail))) {
                dicflag.Add(CfgFn.GetNoNullInt32(webpaymentdetailrow["iddetail"]), ci.idshowcase);
                Session["dic_showcase"] = dicflag;
            }
            if (!string.IsNullOrEmpty(ci.idupb_iva))
                webpaymentdetailrow["idupb_iva"] = ci.idupb_iva;

            webpaymentdetailrow["!store"] = rStore["description"];
            webpaymentdetailrow["number"] = ci.quantity;
            webpaymentdetailrow["paymentexpiring"] = ci.paymentexpiring;
            //webpaymentdetailrow["idivakind"] = ci.idivakind==0? DBNull.Value:(object)0; ?????
            webpaymentdetailrow["idivakind"] = ci.idivakind == 0 ? DBNull.Value : (object) ci.idivakind;
            if (CfgFn.GetNoNullInt32(ci.idivakind) != 0) {
                var ivakind = Conn.readObject("ivakind", q.eq("idivakind", ci.idivakind), "rate");
                var rate = CfgFn.GetNoNullDouble(ivakind["rate"]);
                var iva = CfgFn.RoundValuta(CfgFn.GetNoNullDouble(ci.price) * rate * ci.quantity);
                webpaymentdetailrow["tax"] = iva;
            }
        }

        if (dispmessage)
            ShowClientMessage(message, "Attenzione", System.Windows.Forms.MessageBoxButtons.OK);

        Session["Cart"] = null;
    }

    public override void BeforePost() {
        PState.var["BSM"] = null;
        if (DS.webpayment.Select().Length > 0) {
            var bsm = new BookingSendMail(Conn as DataAccess);
            bsm.PrepareMailToSend(DS);
            PState.var["BSM"] = bsm;
        }
    }

    public override void AfterPost() {
        var bsm = PState.var["BSM"] as BookingSendMail;
        if (bsm != null) {
            bsm.SendMail();
            PState.var["BSM"] = null;
        }

    }

}
