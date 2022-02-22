
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
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using metadatalibrary;
using funzioni_configurazione;
using HelpWeb;
using AllDataSet;
using System.Data;
using Newtonsoft.Json;
using metaeasylibrary;
using EasyWebReport;
using System.Net;
using System.Collections.Specialized;
using System.Text;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using q = metadatalibrary.MetaExpression;
using System.IO;
using OfficeOpenXml.FormulaParsing.Utilities;

public partial class mandate_default_new02 : MetaPage {
    vistaForm_Mandate DS;
    bool DoSendMail {
        get {
            return (bool)PState.var["doSendMail"];
        }
        set {
            PState.var["doSendMail"] = value;
        }
    }

    bool skip_default {
        get {
            return (bool)PState.var["skip_default"];
        }
        set {
            PState.var["skip_default"] = value;
        }
    }
    public override DataSet GetDataSet() {
        return DS;
    }
    public override DataSet CreateNewDataSet() {
        return new vistaForm_Mandate();
    }
    public override void SetDataSet(DataSet D) {
        DS = (vistaForm_Mandate)D;
    }


    private void btnInserisciCopia_Click(object sender, EventArgs e) {
        if (DS.mandate.Rows.Count == 0)
            return;
        DataRow RC = datagridDettagli.CurrentRow;
        if (RC == null)
            return;


        DataRow Ordine = DS.mandate.Rows[0];

        ApplicationState APS = ApplicationState.GetApplicationState(this);
        MetaData metaDT = APS.Dispatcher.Get("mandatedetail");
        metaDT.SetDefaults(DS.mandatedetail);
        DataRow rDT = metaDT.Get_New_Row(Ordine, DS.mandatedetail);

        foreach (string field in new string[] {
                "detaildescription", "npackage", "number", "flagmixed", "idivakind", "taxrate", "tax", "unabatable",
                "ivanotes", "taxable", "discount", "flagactivity", "idupb", "cupcode", "cigcode",
                "idinv","idlocation", "assetkind", "toinvoice", "idsor1", "idsor2", "idsor3","idcostpartition", "competencystart", "competencystop",
                "idaccmotive", "idreg", "va3type", "idlist", "idunit", "idpackage", "unitsforpackage", "flagto_unload",
                "epkind", "expensekind"
            }) {
            rDT[field] = RC[field];
        }

        PageState pageState = this.AppState.GetPageState(this);
        pageState.EditedRow = rDT;
        pageState.GridToUpdate = datagridDettagli;
        pageState.DoingInsert = false;
        CommFun.EditDataRow(rDT, "defaultnew02");
    }

    protected void Page_Load(object sender, EventArgs e) {

    }

    bool IsManager = false;
    public override void AfterLink(bool firsttime, bool formToLink) {

        if (firsttime){
            DoSendMail = false;
        }
        skip_default = false;
        PState.var["Consip2Disabilitato"] = false;
        PState.var["lastValidConsipExtIndex"] = 0;
         PState.var["lastValidConsipIndex"] = 0;
        Meta.Name = "Prenotazione d'ordine";
        if (formToLink) {
            txtConsipMotive.Attributes.Add("readonly", "readonly");

            idmankind.DataSource = DS.mandatekind;
            idmankind.DataValueField = "idmankind";
            idmankind.DataTextField = "description";

            DrpStatus.DataSource = DS.mandatestatus;
            DrpStatus.DataValueField = "idmandatestatus";
            DrpStatus.DataTextField = "description";

            idcurrency.DataSource = DS.currency;
            idcurrency.DataValueField = "idcurrency";
            idcurrency.DataTextField = "description";

            cmbmagazzino.DataSource = DS.store;
            cmbmagazzino.DataValueField = "idstore";
            cmbmagazzino.DataTextField = "description";

            idexpirationkind.DataSource = DS.expirationkind;
            idexpirationkind.DataValueField = "idexpirationkind";
            idexpirationkind.DataTextField = "description";

            cmbConsip.DataSource = DS.consipkind;
            cmbConsip.DataValueField = "idconsipkind";
            cmbConsip.DataTextField = "shortdescription";

            cmbConsipExt.DataSource = DS.consipkind_ext;
            cmbConsipExt.DataValueField = "idconsipkind";
            cmbConsipExt.DataTextField = "shortdescription";

        }
        MetaData.SetDefault(DS.mandate, "idmandatestatus", 1);
        HelpForm.SetDenyNull(DS.mandate.Columns["requested_doc"], true);

        DS.mandatestatus.ExtendedProperties["sort_by"] = "idmandatestatus";
        //btnStatus.Visible = false; 
        /*
        if (Meta.InsertMode)
        {
            MetaData.SetDefault(DS.mandate, "idenactment", 1);
            ManageStatus();
        }
        if (Meta.EditMode)
        {
            ManageStatus();
        }
        */
        //idmandatestatus.DataSource = DS.mandatestatus;
        //idmandatestatus.DataValueField = "idmandatestatus";
        //idmandatestatus.DataTextField = "description";

        Meta.DefaultListType = "webdefault";
        SearchTable = "mandateview";
        //grid_details.SetDataTable(this, null, DS.Tables["mandatedetail"],false, true);

        HelpForm.SetDenyNull(DS.mandate.Columns["active"], true);
        DataAccess.SetTableForReading(DS.upb_detail, "upb");

        GetData.CacheTable(DS.config, QHS.CmpEq("ayear", Conn.Security.GetSys("esercizio")), null, false);
        HelpForm.SetFormatForColumn(DS.mandatedetail.Columns["number"], "N");
        //GetData.CacheTable(DS.upb, QHS.CmpEq("active", 'S'), null, false);
        GetData.SetSorting(DS.mandatedetail, "idgroup asc, rownum asc");
        GetData.SetSorting(DS.mandateview, "yman desc, nman desc, idmankind asc");
        string flt = QHS.CmpEq("isrequest", "S");
        GetData.SetStaticFilter(DS.mandateview, flt);
        GetData.SetStaticFilter(DS.mandatekind, flt);

        GetData.CacheTable(DS.consipkind, null, "position", true);
        GetData.CacheTable(DS.consipkind_ext, null, "position", true);
        GetData.CacheTable(DS.consipcategory, null, "idconsipcategory", true);



        //HelpForm.SetDenyNull(DS.mandate.Columns["idconsipkind"], true);

        IsManager = (Session["CodiceResponsabile"] != null ? true : false);
        int idmanlocal = 0;
        idmanlocal = CfgFn.GetNoNullInt32(Session["CodiceResponsabile"]);

        if (IsManager) {
            if (Session["CodiceResponsabile"] != null) {
                DS.mandate.Columns["idman"].DefaultValue = idmanlocal;
                //cmbresponsabile.SelectedValue = idman.ToString();
                //EnableDisableControls(cmbresponsabile, true);
            }
        }

        DataAccess.SetTableForReading(DS.sorting1, "sorting");
        DataAccess.SetTableForReading(DS.sorting2, "sorting");
        DataAccess.SetTableForReading(DS.sorting3, "sorting");

        btnAvanzaStato.Enabled = false;
        btnStampaOrdine.Enabled = false;
    }

    void ShowHideExtConsip(bool show) {
        if ((bool)PState.var["Consip2Disabilitato"]) show = false;
        LabelConsipExt.Visible = show;
        cmbConsipExt.Visible = show;
    }

    void VisualizzaNascondiConsip(bool visualizza) {
        if (visualizza) {
            LabelConsip.Visible = true;
            Panel3.Visible = true;
        }
        else {
            LabelConsip.Visible = false;
            Panel3.Visible = false;
        }
    }

    string GetConsipKindText(object id) {
        DataRow[] g = DS.consipkind.Select(QHC.CmpEq("idconsipkind", id));
        if (g == null || g.Length == 0)
            return "";
        return g[0]["description"].ToString();
    }

    void SetConsipLabels() {
        if (DS.consipkind.Select(QHC.CmpEq("flagheader", "S")).Length == 1) {
            DataRow r = DS.consipkind.Select(QHC.CmpEq("flagheader", "S"))[0];
            LabelConsip.Text = r["description"].ToString();
        }
        else {
            LabelConsip.Text = "";
        }
        if ((bool)PState.var["Consip2Disabilitato"]) return;

        if (DS.consipkind_ext.Select(QHC.CmpEq("active", "S")).Length == 0) {
            PState.var["Consip2Disabilitato"] = true;
            return;
        }
        if (DS.consipkind_ext.Select(QHC.CmpEq("flagheader", "S")).Length == 1) {
            DataRow r = DS.consipkind_ext.Select(QHC.CmpEq("flagheader", "S"))[0];
            LabelConsipExt.Text = r["description"].ToString();
        }
        else {
            LabelConsipExt.Text = "";
        }
    }
    void fillConsipLabels() {
        SetConsipLabels();
        DataRow r = DS.mandate.Rows[0];
        int idconsipkind = CfgFn.GetNoNullInt32(r["idconsipkind"]);
        if (idconsipkind != 0) {
            LabelConsip.Text = getHeaderForConsipObject(idconsipkind, DS.consipkind);
        }
        int idconsipkind_ext = CfgFn.GetNoNullInt32(r["idconsipkind_ext"]);
        if (idconsipkind_ext != 0) {
            LabelConsipExt.Text = getHeaderForConsipObject(idconsipkind_ext, DS.consipkind_ext);
        }
    }

    string getHeaderForConsipObject(object idconsip, DataTable T) {
        if (idconsip == null || idconsip==DBNull.Value || CfgFn.GetNoNullInt32(idconsip)==0) return "";
        DataRow c = T.Select(QHC.CmpEq("idconsipkind", idconsip))[0];
        return getHeaderForConsipRow(c);
    }

    string getHeaderForConsipRow(DataRow consip) {
        if (consip == null) return "";
        DataTable T = consip.Table;
        DataRow[] header = T.Select(QHC.AppAnd(QHC.CmpEq("flagheader", "S"), QHC.CmpLt("position", consip["position"])), "position desc");
        if (header.Length == 0) return "";
        return header[0]["description"].ToString();
    }

    public override void AfterActivation(bool firsttime, bool formToLink) {

        SetConsipLabels();
    }

    public override void DoCommand(string command) {
        base.DoCommand(command);
        if (command == "approvati") {
            B2_Click(null, null);
        }
        if (command == "copiadettaglio") {
            btnInserisciCopia_Click(null, null);
        }
        if(command.StartsWith("scelta")){
            object rigaselezionata = command.Substring(7,1);
            btnAvanzaStato_Click(rigaselezionata);
        }
		if (command == "stampaordine") {
			HwButton0_Click();
		}
	}

	private string ReportName = "buono_ordine";

    protected void HwButton0_Click() {
        DataRow curr = DS.mandate.First();
        if (curr == null) {
            return;
        }

        int nman = CfgFn.GetNoNullInt32(curr["nman"]);
        int yman = CfgFn.GetNoNullInt32(curr["yman"]);
        string idmankind = curr["idmankind"].ToString();

        string pdfFileName, errmess;
        bool res = stampaCarrello(idmankind, nman, yman, out pdfFileName, out errmess);
        if (!res) {
            ShowClientMessage(errmess, "Attenzione", System.Windows.Forms.MessageBoxButtons.OK);
            return;
        }

        var f = "window.open('" + pdfFileName + "');";
        if (!Page.ClientScript.IsClientScriptBlockRegistered(typeof(Page), "openwin"))
            Page.ClientScript.RegisterClientScriptBlock(
                typeof(Page), "openwin", f, true);

    }

    private bool stampaCarrello(string idmankind, int nman, int yman, out string pdfFileName, out string errmess) {
        errmess = "";
        pdfFileName = "";

        DataTable myPrymaryTable = createStampaCarrelloTable();
        myPrymaryTable.Rows[0]["reportname"] = ReportName;
        myPrymaryTable.Rows[0]["ayear"] = yman;
        myPrymaryTable.Rows[0]["printkind"] = "i";
        myPrymaryTable.Rows[0]["mandatekind"] = idmankind;
        myPrymaryTable.Rows[0]["startnman"] = nman;
        myPrymaryTable.Rows[0]["stopnman"] = nman;
        myPrymaryTable.Rows[0]["idman"] = DBNull.Value;
        myPrymaryTable.Rows[0]["official"] = DBNull.Value;
        myPrymaryTable.Rows[0]["includevariation"] = DBNull.Value;
        myPrymaryTable.Rows[0]["variationdate"] = DBNull.Value;
        myPrymaryTable.Rows[0]["labelinenglish"] = DBNull.Value;
        myPrymaryTable.Rows[0]["idsor01"] = DBNull.Value;
        myPrymaryTable.Rows[0]["idsor02"] = DBNull.Value;
        myPrymaryTable.Rows[0]["idsor03"] = DBNull.Value;
        myPrymaryTable.Rows[0]["idsor04"] = DBNull.Value;
        myPrymaryTable.Rows[0]["idsor05"] = DBNull.Value;

        string filter = QHS.CmpEq("reportname", ReportName);

        DataTable Report = Conn.RUN_SELECT("report", "*", null, filter, null, false);

        if (Report == null) {
            errmess = "Report: '" + ReportName + "' non trovato.";
            return false;
        }

        var rep = Report._First();
        var par = myPrymaryTable.Rows[0];

        ReportDocument myRptDoc = Easy_DataAccess.GetReport(Conn as Easy_DataAccess, rep, par, out errmess);
        if (myRptDoc == null) {
            if (errmess == null || errmess == "") errmess = "Impossibile trovare il report";
            return false;
        }

        string FilePath = MapPath("ReportPDF");
        if (!FilePath.EndsWith("\\")) FilePath += "\\";

        var tempfilename = "buono-ordine-" + Guid.NewGuid() + ".pdf";
        pdfFileName = @"ReportPDF/" + tempfilename;
        string error;
        bool retExp = exportToPdf(myRptDoc, tempfilename, FilePath, out error);
        if (!retExp) errmess = "Impossibile esportare in pdf: " + tempfilename + " in " + FilePath + " (" + error + ")";
        return retExp;
    }


    DataTable createStampaCarrelloTable() {
        var myPrimaryTable = new DataTable("export_mandate");
        //Create a dummy primary key
        var dcpk = new DataColumn("DummyPrimaryKeyField", typeof(int)) { DefaultValue = 1 };
        myPrimaryTable.Columns.Add(dcpk);
        myPrimaryTable.PrimaryKey = new[] { dcpk };

        DataColumn column;
        myPrimaryTable.Columns.Add(new DataColumn("reportname",     typeof(string)));
        myPrimaryTable.Columns.Add(new DataColumn("ayear",          typeof(int)));
        myPrimaryTable.Columns.Add(new DataColumn("printkind",      typeof(string)));
        myPrimaryTable.Columns.Add(new DataColumn("mandatekind",    typeof(string)));
        myPrimaryTable.Columns.Add(new DataColumn("startnman",      typeof(int))); 
        myPrimaryTable.Columns.Add(new DataColumn("stopnman",       typeof(int)));

        column = new DataColumn("idman", typeof(int));
        column.AllowDBNull = true;
        myPrimaryTable.Columns.Add(column);

        column = new DataColumn("official", typeof(string));
        column.AllowDBNull = true;
        myPrimaryTable.Columns.Add(column);

        column = new DataColumn("includevariation", typeof(string));
        column.AllowDBNull = true;
        myPrimaryTable.Columns.Add(column);

        column = new DataColumn("variationdate", typeof(DateTime));
        column.AllowDBNull = true;
        myPrimaryTable.Columns.Add(column);

        column = new DataColumn("labelinenglish", typeof(int));
        column.AllowDBNull = true;
        myPrimaryTable.Columns.Add(column);

        column = new DataColumn("idsor01", typeof(int));
        column.AllowDBNull = true;
        myPrimaryTable.Columns.Add(column);

        column = new DataColumn("idsor02", typeof(int));
        column.AllowDBNull = true;
        myPrimaryTable.Columns.Add(column);

        column = new DataColumn("idsor03", typeof(int));
        column.AllowDBNull = true;
        myPrimaryTable.Columns.Add(column);

        column = new DataColumn("idsor04", typeof(int));
        column.AllowDBNull = true;
        myPrimaryTable.Columns.Add(column);

        column = new DataColumn("idsor05", typeof(int));
        column.AllowDBNull = true;
        myPrimaryTable.Columns.Add(column);

        var r = myPrimaryTable.NewRow();
        myPrimaryTable.Rows.Add(r);
        return myPrimaryTable;
    }

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

        DiskFileDestinationOptions diskOpts = new DiskFileDestinationOptions { DiskFileName = tempfilename };
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

	private DataTable OutGetNextOffice() {
        DataRow Current = DS.mandate.Rows[0];
        object idcustomuser = Conn.Security.GetSys("idcustomuser");
        object idflowchart = Conn.Security.GetSys("idflowchart");
        object k_yman = Current["yman"];
        object k_nman = Current["nman"];
        object k_idmankind = Current["idmankind"];
        object[] parametri = new object[] { idcustomuser, idflowchart, k_idmankind, k_yman, k_nman };

        DataSet DNextOffice = Conn.CallSP("getNextOffice", parametri, true, 3000);
        if (DNextOffice == null || DNextOffice.Tables.Count == 0) {
            WebLog.Log(this, "Errore nel contattare il dipartimento o codice errato.");
            return null;
        }

        DataTable TNextOffice = DNextOffice.Tables[0];
        return TNextOffice;
    }
    private void btnAvanzaStato_Click(object rigaselezionata) {
        // Avanza di stato
        DataRow Current = DS.mandate.Rows[0];
        object idcustomuser = Conn.Security.GetSys("idcustomuser");
        object idflowchart = Conn.Security.GetSys("idflowchart");
        object k_yman = Current["yman"];
        object k_nman = Current["nman"];
        object k_idmankind = Current["idmankind"];
        object[] parametri = new object[] { idcustomuser, idflowchart, k_idmankind, k_yman, k_nman };

        DataSet DNextOffice = Conn.CallSP("getNextOffice", parametri, true, 3000);
        if (DNextOffice == null || DNextOffice.Tables.Count == 0) {
            WebLog.Log(this, "Errore nel contattare il dipartimento o codice errato.");
            return;
        }

        DataTable TNextOffice = DNextOffice.Tables[0];
        if (TNextOffice.Rows.Count == 0) {
            WebLog.Log(this, "Nessuno Stato selezionabile.");
            return;
        }
        int i = CfgFn.GetNoNullInt32(rigaselezionata);
        DataRow R = TNextOffice.Rows[i];
        object new_idmandatestatus = R["new_idmandatestatus"];
        Current["idmandatestatus"] = new_idmandatestatus;

        object idoffice = R["idoffice"];
        Current["idoffice"] = idoffice;
        skip_default= (R["skip_default"].ToString()=="S");
        SetRunningCommand("mainsave");
        CommFun.SaveFormData();
        PState.var["notifyStatusChangeParams"] = null;
        if (!DS.HasChanges()) {
            ClearRunningCommand();
            DataSet DStatusChange = Conn.CallSP("notifyStatusChange", parametri, true, 3000);
        }
        else {
            PState.var["notifyStatusChangeParams"] = parametri;
        }
        // Invia la mail al Ricevente, usando l'output della sp
        string email_ricevente = null;
        email_ricevente = R["email_ricevente"].ToString();
        if (email_ricevente != "") {
            SendMail SM = new SendMail();
            SM.UseSMTPLoginAsFromField = true;
            SM.To = email_ricevente;
            SM.Subject = R["oggetto_mail_ricevente"].ToString();
            SM.MessageBody = R["testo_mail_ricevente"].ToString(); 
            SM.Conn = Conn as DataAccess;
            DoSendMail = false;
            if (!SM.Send()) {
                if (SM.ErrorMessage.Trim() != "")
                    ShowClientMessage(SM.ErrorMessage, "Errore");
            }
        }
        // Invia la mail al Richiedente, usando l'output della sp
        string email_richiedente = null;
        email_richiedente = R["email_richiedente"].ToString();
        if (email_richiedente != "") {
            SendMail SM2 = new SendMail();
            SM2.UseSMTPLoginAsFromField = true;
            SM2.To = email_richiedente;
            SM2.Subject = R["oggetto_mail_richiedente"].ToString();
            SM2.MessageBody = R["testo_mail_richiedente"].ToString();
            SM2.Conn = Conn as DataAccess;
            DoSendMail = false;
            if (!SM2.Send()) {
                if (SM2.ErrorMessage.Trim() != "")
                    ShowClientMessage(SM2.ErrorMessage, "Errore");
            }
        }

    }


    bool abilitaConsip(object idmankind) {
        DataRow[] r = DS.mandatekind.Select(QHC.CmpEq("idmankind", idmankind));
        if (r.Length == 0)
            return true;
        int flag = CfgFn.GetNoNullInt32(r[0]["flag"]) & 2;
        if (flag == 0)
            return true;

        return false;
    }

    protected void B1_Click(object sender, EventArgs e) {
        //CommFun.DoMainCommand("mainsetsearch");
        CommFun.DoMainCommand("");

        return;
    }


    protected void B2_Click(object sender, EventArgs e) {

        //CommFun.DoMainCommand("mainsetsearch");
        string filter;
        filter = QHS.CmpEq("idmandatestatus", 5);
        CommFun.DoMainCommand("maindosearch.webdefaultstatuses." + filter);
        return;

    }

    public override void AfterGetFormData() {
        DataRow Curr = DS.mandate.Rows[0];
        if (PState.InsertMode) {
            
            foreach (DataRow Child in DS.mandatedetail.Select()) {
                Child["yman"] = Curr["yman"];
                Child["nman"] = Curr["nman"];
                Child["idmankind"] = Curr["idmankind"];
            }
            foreach (DataRow Child in DS.mandateattachment.Select()) {
                Child["yman"] = Curr["yman"];
                Child["nman"] = Curr["nman"];
                Child["idmankind"] = Curr["idmankind"];
            }
        }
        if (txtConsipMotive.Text != "") {
            Curr["consipmotive"] = txtConsipMotive.Text;
        }
        else {
            Curr["consipmotive"] = DBNull.Value;
        }

        ImpostaTxtValuta();

    }
    void ImpostaTxtValuta() {
        if (PState.IsEmpty)
            return;
        object codicevaluta = DS.mandate.Rows[0]["idcurrency"];
        if (codicevaluta == DBNull.Value) {
            ImpostaTxtValuta(null);
        }
        else {
            if (DS.currency.Select(QHC.CmpEq("idcurrency", codicevaluta)).Length == 0) {
                ShowClientMessage(
                    "La modalità di pagamento standard del percipiente è associata ad una valuta non valida.",
                    "Avviso", System.Windows.Forms.MessageBoxButtons.OK);
            }
            else {
                DataRow CurrValuta = DS.currency.Select(QHC.CmpEq("idcurrency", codicevaluta))[0];
                ImpostaTxtValuta(CurrValuta);
            }
        }
    }
    void ImpostaTxtValuta(DataRow ValutaRow) {
        if (ValutaRow == null) {
            exchangerate.ReadOnly = false;
            //txtCambio.Text="";		
            if (idcurrency.SelectedIndex != -1) idcurrency.SelectedIndex = 0;
            SetChildParameter(null);
            return;
        }

        if (//(ValutaRow["flageuro"].ToString().ToUpper()=="S")||
            (ValutaRow["codecurrency"].ToString().ToUpper() == "EUR")
            ) {
            //				txtCambio.ReadOnly=true;
            //				double tasso= CfgFn.GetNoNullDouble(ValutaRow["paritaeuro"]);
            //				if (tasso==0) tasso=1;
            //				tasso=1/tasso;
            double tasso = 1;
            exchangerate.Text = HelpForm.StringValue(tasso, exchangerate.Tag.ToString()); //tasso.ToString("n");
        }
        else {
            exchangerate.ReadOnly = false;
            //txtCambio.Text="";
        }
        exchangerate.ReadOnly = false;
        HelpMetaWeb.SetComboBoxValue(idcurrency, ValutaRow["idcurrency"]);
        SetChildParameter(ValutaRow);
    }

    void SetChildParameter(DataRow ValutaRow) {
        if (PState.IsEmpty)
            return;
        if (ValutaRow == null) {
            DS.mandatedetail.ExtendedProperties[ExtraParams] = null;
            return;
        }
        Hashtable Params = new Hashtable();
        Params["nomevaluta"] = ValutaRow["description"];
        Params["codicevaluta"] = ValutaRow["idcurrency"];
        try {
            Params["cambio"] = Double.Parse(exchangerate.Text,
                System.Globalization.NumberStyles.Number);
        }
        catch {
            Params["cambio"] = 0;
        }

        object curr_idman = PState.CurrentRow["idman"];
        Params["codiceresponsabile"] = curr_idman;

        DS.mandatedetail.ExtendedProperties[ExtraParams] = Params;

    }

    private decimal RoundDecimal6(decimal valuta) {
        decimal truncated = Decimal.Truncate(valuta * 10000000);
        if (truncated > 0) {
            if ((truncated % 10) >= 5)
                truncated += 5;
        }
        else {
            if (((-truncated) % 10) >= 5)
                truncated -= 5;
        }
        truncated = truncated / 10;
        truncated = Decimal.Truncate(truncated);
        return truncated / 1000000;
        //			SqlDecimal SQLV = new SqlDecimal(valuta);
        //			return SqlDecimal.Round(SQLV,NCifreDecimaliPerRisultatiValuta).Value;
    }


    private void CalcolaImporto() {
        decimal imponibile = 0;
        decimal imposta = 0;
        decimal totale = 0;
        decimal tassocambio = 1;
        if (PState.IsEmpty)
            return;
        DataRow Curr = PState.CurrentRow;
        tassocambio = CfgFn.GetNoNullDecimal(Curr["exchangerate"]);
        tassocambio = RoundDecimal6(tassocambio);
        int prevgroup = -1;
        decimal totimponibile_currgroup = 0;
        decimal lastexpr = 0;
        foreach (DataRow R in DS.mandatedetail.Select(null, "idgroup")) {
            //if (R.RowState== DataRowState.Deleted) continue;
            if (R["stop"] != DBNull.Value)
                continue;
            int currgroup = CfgFn.GetNoNullInt32(R["idgroup"]);
            if (currgroup != prevgroup) {
                imponibile += lastexpr;
                totimponibile_currgroup = 0;
                prevgroup = currgroup;
            }

            decimal R_imponibile = CfgFn.GetNoNullDecimal(R["taxable"]);
            decimal R_quantita = CfgFn.GetNoNullDecimal(R["number"]);
            //decimal R_imposta  = RoundDecimal6(CfgFn.GetNoNullDecimal(R["taxrate"]));
            decimal R_imposta = CfgFn.GetNoNullDecimal(R["tax"]);
            decimal R_sconto = RoundDecimal6(CfgFn.GetNoNullDecimal(R["discount"]));
            imposta += CfgFn.RoundValuta(R_imposta * tassocambio);
            totimponibile_currgroup += R_imponibile;
            lastexpr = CfgFn.RoundValuta((totimponibile_currgroup * R_quantita * (1 - R_sconto)) * tassocambio);
        }
        imponibile += lastexpr;
        totale = imponibile + imposta;
        decimal imponibileEUR = CfgFn.RoundValuta(imponibile);
        decimal impostaEUR = CfgFn.RoundValuta(imposta);
        decimal totaleEUR = CfgFn.RoundValuta(totale);
        //imponibile=MetaData.SumColumn(MyTable, "imponibile");
        txtimponibile.Text = imponibileEUR.ToString("c");
        txtiva.Text = impostaEUR.ToString("c");
        txttotale.Text = totaleEUR.ToString("c");
    }

    public override void BeforeFill() {
        if (PState.EditMode) {
            int oldStatus = CfgFn.GetNoNullInt32(DS.mandate.Rows[0]["idmandatestatus", DataRowVersion.Original]);
            int newStatus = CfgFn.GetNoNullInt32(DS.mandate.Rows[0]["idmandatestatus"]);
            if (oldStatus != 2 && newStatus == 2 && RunningCommand()!="mainsave") {
                //c'è stato un errore nell'invio della richiesta
                //durante un save però non deve agire altrimenti se ci sono regole ignorabili annulla le modifiche precedenti
                DS.mandate.Rows[0]["idmandatestatus"] = oldStatus;
            }
        }
        DataRow Current = DS.mandate.Rows[0];
        int idconsipkind = CfgFn.GetNoNullInt32(Current["idconsipkind"]);
        VisualizzaBottoneConsip(idconsipkind, true);
        AbilitaDisabilitaConsip_Ext(idconsipkind, true);

    }


    public override void AfterFill() {
        fillConsipLabels();
        PState.var["lastValidConsipExtIndex"] = cmbConsipExt.SelectedIndex;
        PState.var["lastValidConsipIndex"] = cmbConsip.SelectedIndex;
        //Solo se c'è da chiamare la SP ed il salvataggio è andato a buon fine
        if (PState.var["notifyStatusChangeParams"] != null && !DS.HasChanges()) {
            object[] parametri = (object[])PState.var["notifyStatusChangeParams"];
            Conn.CallSP("notifyStatusChange", parametri, true, 3000);
            PState.var["notifyStatusChangeParams"] = null;
        }

            
    
        

        B1.Visible = false;
        B2.Visible = false;
        DataRow Current = DS.mandate.Rows[0];

        if (PState.InsertMode) {
            LockUnLockControls(false);
            Meta.CanCancel = true;
            Meta.CanSave = true;
            btnAvanzaStato.Visible = false;
            btnStampaOrdine.Visible = false;
            //ManageStatus();
        }

        CalcolaImporto();
        ImpostaTxtValuta();
        if (PState.EditMode) {
            ManageStatus();
        }
        yman.ReadOnly = true;

        if (PState.InsertMode || PState.EditMode)
            DrpStatus.Enabled = false;

        object curridmankind = (idmankind.SelectedValue != null) ? idmankind.SelectedValue : null;
        VisualizzaNascondiConsip(abilitaConsip(curridmankind));

        DataRow row_mandatekind = null;
        if (curridmankind != null && curridmankind.ToString() != "") {
            row_mandatekind = DS.mandatekind.Select(QHC.CmpEq("idmankind", curridmankind))[0];
        }

        if (!PState.IsEmpty) {
            if (row_mandatekind != null) {
                MetaData.SetDefault(DS.mandatedetail, "flagactivity", 4);
                MetaData.SetDefault(DS.mandatedetail, "flagmixed", "N");

                int act = CfgFn.GetNoNullInt32(row_mandatekind["flagactivity"]);
                if (act == 4) {
                    //Nessun default
                    MetaData.SetDefault(DS.mandatedetail, "flagactivity", 4);
                    MetaData.SetDefault(DS.mandatedetail, "flagmixed", "N");
                }
                if (act == 1) {
                    //istituz.
                    MetaData.SetDefault(DS.mandatedetail, "flagactivity", 1);
                    MetaData.SetDefault(DS.mandatedetail, "flagmixed", "N");
                }
                if (act == 2) {
                    //comm.
                    MetaData.SetDefault(DS.mandatedetail, "flagactivity", 2);
                    MetaData.SetDefault(DS.mandatedetail, "flagmixed", "N");
                }
                if (act == 3) {
                    //promiscuo.
                    MetaData.SetDefault(DS.mandatedetail, "flagactivity", 3);
                    MetaData.SetDefault(DS.mandatedetail, "flagmixed", "S");
                }
            }
        }
        if ((PState.InsertMode) || (PState.InsertMode)) {

            if (DS.mandatedetail.Rows.Count == 0) {
                AzzeraDefaultDettagli();
                object idupb_selected = (row_mandatekind == null ? "" : row_mandatekind["idupb"]);
                MetaData.SetDefault(DS.mandatedetail, "idupb", idupb_selected);
            }
            else {
                int maxdetail = CfgFn.GetNoNullInt32(DS.mandatedetail.Compute("max(rownum)", null));
                if (maxdetail > 0) {
                    DataRow row_mandatedetail = DS.mandatedetail.Select(QHC.CmpEq("rownum", maxdetail))[0];
                    if (row_mandatedetail != null && row_mandatedetail.RowState == DataRowState.Added) {
                        object idupb_selected = row_mandatedetail["idupb"];
                        MetaData.SetDefault(DS.mandatedetail, "idupb", idupb_selected);

                        object cupcode = row_mandatedetail["cupcode"];
                        MetaData.SetDefault(DS.mandatedetail, "cupcode", cupcode);

                        object flagactivity = row_mandatedetail["flagactivity"];
                        MetaData.SetDefault(DS.mandatedetail, "flagactivity", flagactivity);

                        object idSor1 = (row_mandatedetail["idsor1"] != DBNull.Value)
                            ? row_mandatedetail["idsor1"] : null;
                        if (idSor1 != null) {
                            MetaData.SetDefault(DS.mandatedetail, "idsor1", idSor1);
                        }

                        object idSor2 = (row_mandatedetail["idsor2"] != DBNull.Value)
                            ? row_mandatedetail["idsor2"] : null;
                        if (idSor2 != null) {
                            MetaData.SetDefault(DS.mandatedetail, "idsor2", idSor2);
                        }

                        object idSor3 = (row_mandatedetail["idsor3"] != DBNull.Value)
                            ? row_mandatedetail["idsor3"] : null;
                        if (idSor3 != null) {
                            MetaData.SetDefault(DS.mandatedetail, "idsor3", idSor3);
                        }
                    }
                    else {
                        AzzeraDefaultDettagli();

                    }
                }
                else {
                    AzzeraDefaultDettagli();

                }
            }

        }
        if (PState.EditMode) {
            EnableDisableRegistry();
        }

        string flagmultireg_selected = (row_mandatekind == null ? "" : row_mandatekind["multireg"].ToString().ToUpper());
        //if (flagmultireg_selected == "S") {
        //    groupBox2.Visible = false;
        //}
        //else {
        //    groupBox2.Visible = true;
        //}

        if (PState.IsFirstFillForThisRow && PState.InsertMode && idmankind.SelectedIndex > 0) {
            if (row_mandatekind != null) {
                SetNumContratto(row_mandatekind);
            }
        }
        if (PState.InsertMode) {
            if (idmankind.SelectedIndex > 0) {
                string tiponumerazione = row_mandatekind["flag_autodocnumbering"].ToString();
                if (tiponumerazione == "S") {
                    nman.ReadOnly = true;
                    nman.HiddenContent = true;
                }
                else {
                    nman.ReadOnly = false;
                    nman.HiddenContent = false;
                }
            }
            else {
                nman.ReadOnly = false;
                nman.HiddenContent = true;
            }
        }
        if(PState.InsertMode){
            officecode.Enabled= false;
            officedescription.Enabled=false;
        }
        else {
               if (PState.EditMode) {
                    ValorizzaUfficio();
                    }
        }
        if ((!PState.IsEmpty) && (PState.EditMode)) {
            btnAvanzaStato.Enabled = true;
            btnStampaOrdine.Enabled = true;
        }
        else {
            btnAvanzaStato.Enabled = false;
            btnStampaOrdine.Enabled = false;
        }

        InjectJsonVariables();
        string idcustomuser = (Conn.Security.GetSys("idcustomuser")).ToString();
        string idflowchart = (Conn.Security.GetSys("idflowchart")).ToString();
        int k_yman = CfgFn.GetNoNullInt32(Current["yman"]);
        int k_nman = CfgFn.GetNoNullInt32(Current["nman"]);
        string k_idmankind = Current["idmankind"] .ToString();
        btnAvanzaStato.OnClientClick = "javascript:avanzastato(" + "'" + HttpUtility.HtmlEncode(idcustomuser) + "',"
                                                                    + "'" + HttpUtility.HtmlEncode(idflowchart) + "',"
                                                                    + "'" + HttpUtility.HtmlEncode(k_idmankind) + "'," + k_yman + "," + k_nman + ");return false; ";

        }
    void ValorizzaUfficio(){
        if(DS.office.Rows.Count>0){
            officecode.Text = DS.office.Rows[0]["code"].ToString();
            officedescription.Text = DS.office.Rows[0]["description"].ToString();
        }
    }

    class consipKindData {
        public string key;
        public string val; 
    }
    void InjectJsonVariables() {
        List<string> lCategory = new List<string>();
        foreach(DataRow r in DS.consipcategory.Select()) {
            //if (r["idconsipcategory"].ToString() == "" || r["idconsipcategory"].ToString() == "0") continue;
            lCategory.Add(r["description"].ToString());
        }
        string script = "var ConsipCategoryList = " + JsonConvert.SerializeObject(lCategory, Formatting.Indented) + ";\r\n";
        List<consipKindData> lConsip = new List<consipKindData>();

        foreach (DataRow r in DS.consipkind.Select()) {
            //if (r["idconsipkind"].ToString() == "" || r["idconsipkind"].ToString() == "0") continue;
            consipKindData c = new consipKindData();
            c.key = r["idconsipkind"].ToString();
            c.val = r["description"].ToString();
            lConsip.Add(c);
        }
        script += "var ConsipList = " + JsonConvert.SerializeObject(lConsip, Formatting.Indented) + ";\r\n";

        metaMaster.RegisterScript("jsonDataConsip", script,true);

    }

    void AzzeraDefaultDettagli() {
        MetaData.SetDefault(DS.mandatedetail, "idupb", DBNull.Value);
        //MetaData.SetDefault(DS.mandatedetail, "flagactivity", DBNull.Value);
        MetaData.SetDefault(DS.mandatedetail, "idsor1", DBNull.Value);
        MetaData.SetDefault(DS.mandatedetail, "idsor2", DBNull.Value);
        MetaData.SetDefault(DS.mandatedetail, "idsor3", DBNull.Value);
        MetaData.SetDefault(DS.mandatedetail, "cupcode", DBNull.Value);
    }


    void SetNumContratto(DataRow R) {
        string tiponumerazione = R["flag_autodocnumbering"].ToString();
        DataRow Curr = DS.mandate.Rows[0];
        if (tiponumerazione == "S") {
            RowChange.MarkAsAutoincrement(DS.mandate.Columns["nman"], null, null, 6);
            MetaData.SetDefault(DS.mandate, "nman", -10);
            nman.ReadOnly = true;
            nman.Text = "";
            int N = MetaData.MaxFromColumn(DS.mandate, "nman");
            if (N < 99990000)
                N = 99990000;
            else
                N = N + 1;
            Curr["nman"] = N;
            nman.Text = N.ToString();
            nman.HiddenContent = true;
            foreach (DataRow Dett in DS.mandatedetail.Rows) {
                Dett["nman"] = N;
            }
            foreach (DataRow Dett in DS.mandatesorting.Rows) {
                Dett["nman"] = N;
            }

        }
        else {
            DataColumn C = DS.mandate.Columns["nman"];
            RowChange.ClearAutoIncrement(C);
            RowChange.ClearCustomAutoIncrement(C);
            int nmax = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("mandate",
                QHS.AppAnd(QHS.CmpEq("yman", Conn.Security.GetSys("esercizio")),
                QHS.CmpEq("idmankind", R["idmankind"])), "MAX(nman)")) + 1;
            MetaData.SetDefault(DS.mandate, "nman", nmax);
            Curr["nman"] = nmax;
            nman.Text = nmax.ToString();
            nman.ReadOnly = false;
            nman.HiddenContent = false;
            foreach (DataRow Dett in DS.mandatedetail.Rows) {
                Dett["nman"] = nmax;
            }
            foreach (DataRow Dett in DS.mandatesorting.Rows) {
                Dett["nman"] = nmax;
            }

        }
    }


    public override void AfterClear() {
        B1.Visible = true;
        B2.Visible = true;
        exchangerate.ReadOnly = false;
        MetaData.SetDefault(DS.mandate, "idmandatestatus", 1);
        PState.var["lastValidConsipExtIndex"] = cmbConsipExt.SelectedIndex;
        PState.var["lastValidConsipIndex"] = cmbConsip.SelectedIndex;
        PState.var["notifyStatusChangeParams"] = null;

        VisualizzaBottoneConsip(0, true);
        AbilitaDisabilitaConsip_Ext(0, true);
        

        VisualizzaNascondiConsip(true);

        yman.Text = Conn.Security.GetSys("esercizio").ToString();
        yman.ReadOnly = false;
        //txtCredDeb.ReadOnly = false;
        //groupBox2.Visible = true;
        DataColumn C = DS.mandate.Columns["nman"];
        RowChange.ClearAutoIncrement(C);
        RowChange.ClearCustomAutoIncrement(C);
        nman.ReadOnly = false;
        nman.HiddenContent = false;
        txtimponibile.Text = "";
        txtiva.Text = "";
        txttotale.Text = "";
        LockUnLockControls(false);
        
        AzzeraDefaultDettagli();

        ShowHideExtConsip(true);
        SetConsipLabels();
        officecode.Enabled = true;
        officecode.Text = "";
        officedescription.Enabled = true;
        officedescription.Text = "";
        btnAvanzaStato.Enabled = false;
        btnStampaOrdine.Enabled = false;
    }

    void EnableDisableRegistry() {
        //string filter_invoice =
        //    QHC.AppAnd(QHC.CmpEq("idmankind", Current["idmankind"]),
        //    QHC.CmpEq("yman", Current["yman"]), QHC.CmpEq("nman", Current["nman"]));
        //int LinkedDet = DS.invoicedetail.Select(filter_invoice).Length;
        //if (LinkedDet == 0)
        //    txtCredDeb.ReadOnly = false;
        //else
        //    txtCredDeb.ReadOnly = true;
    }

    //void VisualizzaNascondiConsip(bool visualizza) {
    //    if (visualizza) {
    //        LabelConsip.Visible = true;
    //        Panel3.Visible = true;
    //    }
    //    else {
    //        LabelConsip.Visible = false;
    //        Panel3.Visible = false;
    //    }
    //}

    public override void AfterRowSelect(DataTable T, DataRow R) {

        if (T.TableName == "store" && CommFun.DrawStateIsDone) {
            if (R == null) {
                Hwdeliveryaddress.Text = "";
                return;
            }
            else {
                string deliveryaddress = R["deliveryaddress"].ToString();
                Hwdeliveryaddress.Text = deliveryaddress;
            }
        }

        if (T.TableName == "currency") {
            ImpostaTxtValuta(R);
            return;
        }

        
        if (T.TableName == "mandatekind") {
            if (PState.InsertMode) {
                object idupb_selected = (R == null ? "" : R["idupb"]);
                MetaData.SetDefault(DS.mandatedetail, "idupb", idupb_selected);
            }
            bool viewConsip = false;
            if (R != null) {
                VisualizzaNascondiConsip(abilitaConsip(R["idmankind"]));
                DataRow[] r = DS.mandatekind.Select(QHC.CmpEq("idmankind", R["idmankind"]));
                if (r.Length == 0) viewConsip = true;
                int flag = CfgFn.GetNoNullInt32(r[0]["flag"]) & 2;
                if (flag == 0) viewConsip = true;
            }

            if (viewConsip) {
                liconsip.Visible = true;
                tabconsip.Visible = true;
            }
            else {
                liconsip.Visible = false;
                tabconsip.Visible = false;
            }
        }


        if (T.TableName == "mandatekind") {
            if (R == null)
                return;
            if (PState.InsertMode) {
                //aggiorno il codice tipo contratto. dei dettagli
                object codicetipodoc = (R == null ? "" : R["idmankind"]);
                DataRow Curr = DS.mandate.Rows[0];
                Curr["idmankind"] = codicetipodoc;

                if (R != null) {
                    SetNumContratto(R);
                    foreach (DataRow Dett in DS.mandatedetail.Rows) {
                        if (!Dett["idmankind"].Equals(codicetipodoc))
                            Dett["idmankind"] = codicetipodoc;
                    }
                    foreach (DataRow Dett in DS.mandatesorting.Rows) {
                        if (!Dett["idmankind"].Equals(codicetipodoc))
                            Dett["idmankind"] = codicetipodoc;
                    }
                }

            }
            //if (R["multireg"] == DBNull.Value) return;
            string multiReg = R["multireg"].ToString();
            if (multiReg == "S") {
                if (DS.mandate.Rows.Count > 0) {
                    DataRow CurrRow = DS.mandate.Rows[0];
                    CurrRow["idreg"] = DBNull.Value;
                    //txtCredDeb.Text = "";
                }
                //groupBox2.Visible = false;
            }
            else {
                //groupBox2.Visible = true;
            }

            if (PState.IsEmpty)
                return;
            //if (R["idupb"] == DBNull.Value) return;
            if (R["idupb"] != DBNull.Value && CommFun.DrawStateIsDone) {
                DataRow[] RRR = DS.upb.Select(QHC.CmpEq("idupb", R["idupb"]));
                if (RRR.Length > 0) {
                    DataRow RR = RRR[0];
                    if (RR["idman"] != DBNull.Value) {
                        if (idmankind.SelectedIndex > 0) {
                            if (idmankind.SelectedValue.ToString() == RR["idman"].ToString())
                                return;
                            ShowClientMessage("Il responsabile dell'ordine è stato reimpostato come da UPB", "Avviso");
                        }
                        CommFun.HMW.SetCombo(idmankind, DS.mandatekind, "idmankind", RR["idman"]);
                    }
                }
            }
            if (R != null) {
                MetaData.SetDefault(DS.mandatedetail, "flagactivity", 4);
                MetaData.SetDefault(DS.mandatedetail, "flagmixed", "N");

                int act = CfgFn.GetNoNullInt32(R["flagactivity"]);
                if (act == 4) {
                    //Nessun default
                    MetaData.SetDefault(DS.mandatedetail, "flagactivity", 4);
                    MetaData.SetDefault(DS.mandatedetail, "flagmixed", "N");
                }
                if (act == 1) {
                    //istituz.
                    MetaData.SetDefault(DS.mandatedetail, "flagactivity", 1);
                    MetaData.SetDefault(DS.mandatedetail, "flagmixed", "N");
                }
                if (act == 2) {
                    //istituz.
                    MetaData.SetDefault(DS.mandatedetail, "flagactivity", 2);
                    MetaData.SetDefault(DS.mandatedetail, "flagmixed", "N");
                }
                if (act == 3) {
                    //istituz.
                    MetaData.SetDefault(DS.mandatedetail, "flagactivity", 3);
                    MetaData.SetDefault(DS.mandatedetail, "flagmixed", "S");
                }
            }
        }



        if (T.TableName == "registrymainview") {
            ImpostaCredDeb(R);
            return;
        }
    }

    void ManageStatus() {
        // Status is:
        // 1:Bozza - 2:Richiesta - 3:Da Correggere - 4:Inserito - 5:Approvato - 6:Annullato
        DataRow CurrentRow = DS.mandate.Rows[0];

        int status = CfgFn.GetNoNullInt32(CurrentRow["idmandatestatus"]);
        if (status >= 4) {
            Meta.CanSave = false;
            Meta.CanCancel = false;
        }
        else {
            Meta.CanSave = true;
            Meta.CanCancel = true;
        }
        // SOSTITUITO btnStatus con btnAvanzaStato
        switch (status) {
            case 1:
                if (!PState.InsertMode) {
                    btnAvanzaStato.Text = "Invia Richiesta";
                    btnAvanzaStato.Visible = true;
                    btnStampaOrdine.Visible = true;
                    LockUnLockControls(false);
                    EnableDisableControls(yman, true);
                    EnableDisableControls(nman, true);
                    EnableDisableControls(idmankind, true);
                    EnableDisableControls(idmankind, true);
                }

                break;
            case 2:
                btnAvanzaStato.Text = "Modifica";
                btnAvanzaStato.Visible = true;
                btnStampaOrdine.Visible = true;
                LockUnLockControls(true);
                btnAvanzaStato.Enabled = true;
                btnStampaOrdine.Enabled = true;
                EnableDisableControls(HwEditAllegato, false);

                break;
            case 3:
                btnAvanzaStato.Visible = true;
                btnStampaOrdine.Visible = true;
                btnAvanzaStato.Text = "Invia Richiesta";
                LockUnLockControls(false);
                EnableDisableControls(yman, true);
                EnableDisableControls(nman, true);
                EnableDisableControls(idmankind, true);

                btnAvanzaStato.Enabled = true;
                btnStampaOrdine.Enabled = true;
                break;
            default:
                // Chiama la SP se restituisce zero righe, assume il comportamento attuale, cioè blocca tutto,
                // Se restituisce 1 riga, mette come label del buttun Nome dello stato e tra parentesi l'ufficio
                //Se restuisce n righe, con n>1, ci sarà il comportamento di "Avanza Stato"
                DataTable Tsp = OutGetNextOffice();
                if (Tsp == null || Tsp.Rows.Count == 0) {
                    // Blocca tutto
                    btnAvanzaStato.Visible = false;
                    btnStampaOrdine.Visible = true;
                    LockUnLockControls(true);
                    EnableDisableControls(btnAvanzaStato, false);
                    EnableDisableControls(HwEditAllegato, false);
                    skip_default = false;
                }
                else {
                    if (Tsp.Rows.Count == 1) {
                        DataRow Rsp = Tsp.Rows[0];
                        btnAvanzaStato.Text = leggiStato(Rsp) + "(" + leggiUfficio(Rsp) + ")";
                        btnAvanzaStato.Visible = true;
                        btnStampaOrdine.Visible = true;
                        skip_default = (Rsp["skip_default"].ToString() == "S");
                    }
                    if (Tsp.Rows.Count > 1) {
                        btnAvanzaStato.Text = "Avanza Stato";
                        btnAvanzaStato.Visible = true;
                        btnStampaOrdine.Visible = true;
                    }
                }
                //btnAvanzaStato.Visible = false;
                break;
        }
        return;
    }

    string leggiUfficio(DataRow R) {
        // legge l'ufficio
        string idoffice = R["idoffice"].ToString();
        string filter = QHS.CmpEq("idoffice", R["idoffice"]);
        string office = "";
        DataTable Toffice;
        Toffice = Conn.RUN_SELECT("office", "description", null, filter, null, false);
        if (Toffice.Rows.Count > 0) {
            office = Toffice.Rows[0]["description"].ToString();
        }
        else {
            office = "Ufficio non esistente";
        }
        return office;
    }

    string leggiStato(DataRow R) {
        // legge lo stato
        string idmandatestatus = R["new_idmandatestatus"].ToString();
        string filter = QHS.CmpEq("idmandatestatus", R["new_idmandatestatus"]);
        string mandatestatus = "";
        DataTable T;
        T = Conn.RUN_SELECT("mandatestatus", "description", null, filter, null, false);
        if (T.Rows.Count > 0) {
            mandatestatus = T.Rows[0]["description"].ToString();
        }
        else {
            mandatestatus = "Stato non trovato";
        }
        return mandatestatus;
    }
    void LockUnLockControls(bool Lock) {
        MetaPageMaster MP = Master as MetaPageMaster;

        Control ContentDiv = MP.GetContentDiv();
        EnableDisableControls(ContentDiv, Lock);
        txttotale.ReadOnly = true;
        txtiva.ReadOnly = true;
        txtimponibile.ReadOnly = true;
    }

    void EnableDisableControls(Control C, bool Lock) {

        if (typeof(WebControl).IsAssignableFrom(C.GetType())) {
            WebControl CC = C as WebControl;
            if (typeof(hwButton).IsAssignableFrom(CC.GetType()) || //typeof(hwTextBox).IsAssignableFrom(CC.GetType())||
                typeof(hwRadioButton).IsAssignableFrom(CC.GetType()) || typeof(hwDropDownList).IsAssignableFrom(CC.GetType())
                || typeof(hwCheckBox).IsAssignableFrom(CC.GetType()))
                CC.Enabled = !Lock;
            if (typeof(hwTextBox).IsAssignableFrom(CC.GetType()))
                ((hwTextBox)CC).ReadOnly = Lock;
        }
        if (C.HasControls()) {
            foreach (Control child in C.Controls)
                EnableDisableControls(child, Lock);
        }

    }

    void ImpostaCredDeb(DataRow R) {
        if (PState.InsertMode && R != null)
            ImpostaIntracom(R["residence"]);
    }

    /// <summary>
    /// true per abilitare Tab intracomunitaria
    /// </summary>
    /// <param name="R"></param>
    private void ImpostaIntracom(object idresidence) {
        if (PState.IsEmpty) return;

        object Ocoderesidence = Conn.DO_READ_VALUE("residence", QHS.CmpEq("idresidence", idresidence),
            "coderesidence");
        if (Ocoderesidence == null || Ocoderesidence == DBNull.Value)
            return;
        string coderesidence = Ocoderesidence.ToString().ToUpper();
        DataRow Curr = DS.mandate.Rows[0];
        object oldvalue = Curr["flagintracom"];
        object newval = DBNull.Value;
        if (coderesidence == "I") {
            newval = "N";
        }
        if (coderesidence == "J") {
            newval = "S";
        }
        if (coderesidence == "X") {
            newval = "X";
        }

        Curr["flagintracom"] = newval;

    }

    public override void BeforePost() {
        if (DS.mandate.Rows.Count == 0)
            return;

        DataRow CurrRow = DS.mandate.Rows[0];
        if (CurrRow.RowState != DataRowState.Deleted) {
            int CurrentStatus = CfgFn.GetNoNullInt32(CurrRow["idmandatestatus"]);
            int OriginalStatus;
            if (!PState.InsertMode)
                OriginalStatus = CfgFn.GetNoNullInt32(CurrRow["idmandatestatus", DataRowVersion.Original]);
            else
                OriginalStatus = CurrentStatus;


            if (CurrentStatus != OriginalStatus && CurrentStatus == 2)
                DoSendMail = true;
            else
                DoSendMail = false;
        }
    }

    public override void AfterPost() {
        if ((DoSendMail) && (!skip_default)){
            string ManKindDesc = "";
            string MsgBody = "";
            DataRow CurrentRow = DS.mandate.Rows[0];
            string CurrentIdMandateKind = CurrentRow["idmankind"].ToString();
            string warnmail = null;
            DataRow[] RowsManKind = DS.mandatekind.Select(QHC.CmpEq("idmankind", CurrentIdMandateKind));

            if (RowsManKind.Length == 0)
                return;
            warnmail = RowsManKind[0]["warnmail"].ToString();
            if (warnmail == "") {
                if (Conn.Security.GetSys("defaultdepmail") != null && Conn.Security.GetSys("defaultdepmail").ToString() != "") {
                    warnmail = Conn.Security.GetSys("defaultdepmail").ToString();
                }
            }

            ManKindDesc = RowsManKind[0]["description"].ToString();
            // Indirizzo e-mail a cui si intende inviare la notifica della richiesta ordine di materiale pericoloso
            string mailto_danger = RowsManKind[0]["dangermail"].ToString();

            MsgBody = "Il contratto passivo numero " + CurrentRow["nman"] + " relativo all'esercizio " + CurrentRow["yman"] + " di tipo '" + ManKindDesc + "'\r\n";
            MsgBody += "E' passato nello stato 'Richiesta'.\r\n";

            MsgBody += "Descrizione:\r\n";
            MsgBody += CurrentRow["description"].ToString() + "\r\n";

            MsgBody += "Dettagli:\r\n";
            foreach (DataRow R in DS.mandatedetail.Select()) {
                MsgBody += GetDetailDescription(CurrentRow, R);
                MsgBody += "\r\n";
            }

            if (warnmail != "") {
                SendMail SM = new SendMail();
                SM.UseSMTPLoginAsFromField = true;
                SM.To = warnmail;
                SM.Subject = "Notifica cambiamento di stato contratto passivo";
                SM.MessageBody = MsgBody;
                SM.Conn = Conn as DataAccess;
                DoSendMail = false;
                if (!SM.Send()) {
                    if (SM.ErrorMessage.Trim() != "")
                        ShowClientMessage(SM.ErrorMessage, "Errore");
                }
            }
            int CurrentStatus = CfgFn.GetNoNullInt32(CurrentRow["idmandatestatus"]);

            if ((CurrentStatus == 5) && (CurrentRow["flagdanger"].ToString() == "S") && mailto_danger != "") {

                SendMail SM_danger = new SendMail();
                SM_danger.UseSMTPLoginAsFromField = true;
                SM_danger.To = mailto_danger;
                SM_danger.Subject = "Avviso di ordine con materiale pericoloso o radioattivo";
                SM_danger.MessageBody = MsgBody;
                SM_danger.Conn = Conn as DataAccess; ;
                DoSendMail = false;
                if (!SM_danger.Send()) {
                    if (SM_danger.ErrorMessage.Trim() != "")
                        ShowClientMessage(SM_danger.ErrorMessage, "Errore");
                }

            }
        }

    }
    string GetDetailDescription(DataRow Main, DataRow R) {
        double tassocambio = CfgFn.GetNoNullDouble(Main["exchangerate"]);
        double imponibile = CfgFn.GetNoNullDouble(R["taxable"]);
        double quantita = CfgFn.GetNoNullDouble(R["npackage"]);
        //double aliquota  = CfgFn.GetNoNullDouble(Curr["taxrate"]);
        double sconto = CfgFn.GetNoNullDouble(R["discount"]);
        double imponibiletot = CfgFn.RoundValuta((imponibile * quantita * (1 - sconto)));
        double imponibiletotEUR = CfgFn.RoundValuta(imponibiletot * tassocambio);



        string S = "";
        S += "Descrizione: " + R["detaildescription"].ToString() + "\r\n";
        S += "Quantità: " + quantita.ToString() + "\r\n";
        S += "Imponibile unitario: " + imponibile.ToString("n") + "\r\n";
        if (tassocambio != 1) {
            S += "Imponibile totale: " + imponibiletot.ToString("n") + "\r\n";
            S += "Imponibile totale euro: " + imponibiletotEUR.ToString("c") + "\r\n";
        }
        else {
            S += "Imponibile totale: " + imponibiletot.ToString("c") + "\r\n";
        }


        return S;
    }


    //protected void btnStatus_Click(object sender, EventArgs e) {
    //    // Va rimosso. DA CONTROLLARE.
    //    if (PState.EditMode) {
    //        DataRow CurrentRow = DS.mandate.Rows[0];
    //        int status = CfgFn.GetNoNullInt32(CurrentRow["idmandatestatus"]);

    //        switch (status) {
    //            case 1:
    //                CurrentRow["idmandatestatus"] = 2;
    //                break;
    //            case 3:
    //                CurrentRow["idmandatestatus"] = 2;
    //                break;
    //            case 2:
    //                CurrentRow["idmandatestatus"] = 1;
    //                break;
    //        }
    //        CommFun.SaveFormData();
    //    }

    //}

    int calcNewValidIndex(int oldValidIndex, int newIndex, int tableSize) {
        if (oldValidIndex < newIndex) {
            //direction:forward
            if (newIndex < tableSize - 1) {
                return newIndex + 1;
            }
            else {
                return oldValidIndex;
            }
        }
        else {
            //direction: backward
            if (newIndex > 0) {
                return newIndex - 1;
            }
            else {
                return oldValidIndex;
            }
        }
    }


    protected void cmbConsipExt_SelectedIndexChanged(object sender, EventArgs e) {
        //if (PState.IsEmpty) return;
        int idconsipkind = CfgFn.GetNoNullInt32(cmbConsipExt.SelectedValue);
        if (idconsipkind != 0) {
            DataRow rSelected = DS.consipkind_ext.Select(QHC.CmpEq("idconsipkind", idconsipkind))[0];
            LabelConsipExt.Text = getHeaderForConsipRow(rSelected);
            bool isHeader = (rSelected["flagheader"].ToString().ToUpper() == "S");
            if (isHeader) {
                cmbConsipExt.SelectedIndex = calcNewValidIndex(CfgFn.GetNoNullInt32(PState.var["lastValidConsipExtIndex"]),
                    cmbConsipExt.SelectedIndex, DS.consipkind_ext.Rows.Count);
                if (!PState.IsEmpty)  DS.mandate.Rows[0]["idconsipkind_ext"] = CfgFn.GetNoNullInt32( cmbConsipExt.SelectedValue);
                cmbConsipExt_SelectedIndexChanged(sender, e);
                return;
            }
        }
        PState.var["lastValidConsipExtIndex"] = cmbConsipExt.SelectedIndex;
    }

    
    protected void cmbConsip_SelectedIndexChanged(object sender, EventArgs e) {
        int idconsipkind = CfgFn.GetNoNullInt32(cmbConsip.SelectedValue);
        if (idconsipkind != 0) {
            DataRow rSelected = DS.consipkind.Select(QHC.CmpEq("idconsipkind", idconsipkind))[0];
            LabelConsip.Text = getHeaderForConsipRow(rSelected);
            bool isHeader = (rSelected["flagheader"].ToString() == "S");
            if (isHeader) {
                cmbConsip.SelectedIndex = calcNewValidIndex(CfgFn.GetNoNullInt32(PState.var["lastValidConsipIndex"]), cmbConsip.SelectedIndex, DS.consipkind.Rows.Count);
                if (!PState.IsEmpty) DS.mandate.Rows[0]["idconsipkind"] = CfgFn.GetNoNullInt32(cmbConsip.SelectedValue);
                cmbConsip_SelectedIndexChanged(sender, e);
                return;
            }
            txtConsipMotive.Text = rSelected["description"].ToString();
        }
        else {
            txtConsipMotive.Text = "";
        }
        PState.var["lastValidConsipIndex"] = cmbConsip.SelectedIndex;
        VisualizzaBottoneConsip(idconsipkind, true);
        AbilitaDisabilitaConsip_Ext(idconsipkind, true);
    }

    private void VisualizzaBottoneConsip(int idconsipkind, bool forced) {
        if (!forced) return;
        string filter = QHC.CmpEq("idconsipkind", idconsipkind);

        DataRow[] Rows = DS.consipkind.Select(filter);
        if (Rows.Length > 0) {
            DataRow R1 = Rows[0];

            if (R1["active"].ToString() == "N") {
                txtConsipMotive.Visible = false;
                btnConsip.Visible = false;
                return;
            }

            string flagdinamic = R1["flagdynamictext"].ToString().ToUpper();
            if (flagdinamic == "S") {
                btnConsip.Visible = true;
                txtConsipMotive.Visible = true;
            }
            else {
                btnConsip.Visible = false;
                txtConsipMotive.Visible = false;
            }
        }
        else {
            btnConsip.Visible = false;
            txtConsipMotive.Visible = false;
        }
    }

    private void AbilitaDisabilitaConsip_Ext(int idconsipkind, bool forced) {
        if (!forced ) return;
        if (PState.IsEmpty) return;
        string filter = QHC.CmpEq("idconsipkind", idconsipkind);

        if (idconsipkind == 0) {
            ShowHideExtConsip(false);
            return;
        }
        DataRow[] Rows = DS.consipkind.Select(filter);
        if (Rows.Length > 0) {
            DataRow R1 = Rows[0];

            string flagpurchaseperformed = R1["flagpurchaseperformed"].ToString().ToUpper();
            if (flagpurchaseperformed == "") flagpurchaseperformed = "S";
            string flagactive = R1["active"].ToString().ToUpper();

            if (flagpurchaseperformed == "N") {
                ShowHideExtConsip(true);
            }
            else {
                cmbConsipExt.SelectedIndex = 0;
                ShowHideExtConsip(false);
            }
        }
        else {
            cmbConsipExt.SelectedIndex = 0;
            ShowHideExtConsip(false);
        }
    }

    public class GestioneClass {
        public static bool UsesAttribues(IDataAccess Conn) {
            foreach (string s in new string[] { "idsortingkind01", "idsortingkind02", "idsortingkind03",
                            "idsortingkind04", "idsortingkind05" }) {
                if (Conn.Security.GetSys(s) != DBNull.Value) return true;
            }
            return false;
        }

        public static GestioneClass GetGestioneClassForField(string field, DataAccess Conn, string parenttable) {
            if (!UsesAttribues(Conn)) return null;
            string f = field.ToLower().Trim();
            if (f == "idsor01") return new GestioneClass(Conn, 1, parenttable);
            if (f == "idsor02") return new GestioneClass(Conn, 2, parenttable);
            if (f == "idsor03") return new GestioneClass(Conn, 3, parenttable);
            if (f == "idsor04") return new GestioneClass(Conn, 4, parenttable);
            if (f == "idsor05") return new GestioneClass(Conn, 5, parenttable);
            return null;
        }

        bool allowSelection = false;
        public bool AllowSelection() {
            return allowSelection;
        }

        bool allowNull = false;
        public bool AllowNull() {
            return allowNull;
        }

        object defaultValue = DBNull.Value;
        public object DefaultValue() {
            return defaultValue;
        }



        string filterkind = "";
        object filter_sec = null;
        QueryHelper QHS;


        public string GetFilterAutoChoose() {
            string filtercomplete = filterkind;
            if (filter_sec != null) filtercomplete = QHS.AppAnd(filtercomplete, filter_sec.ToString());
            return filtercomplete;
        }

        string btnTag = "";
        public string BtnTag() {
            return btnTag;
        }

        string GetManageTag(string parenttable) {
            return "manage." + parenttable + ".tree";
        }
        string GetChooseTag(string parenttable) {
            string filtercomplete = filterkind;
            if (filter_sec != null) filtercomplete = QHS.AppAnd(filtercomplete, filter_sec.ToString());
            return "choose." + parenttable + ".tree." + filtercomplete;
        }


        public GestioneClass(DataAccess Conn, int N, string parenttable) {
            QHS = Conn.GetQueryHelper();

            object ayear = Conn.GetSys("esercizio");
            string NtoS = N.ToString().PadLeft(2, '0'); //01 02 03 04 05
            string field_getsys_sortkind = "idsortingkind" + NtoS;
            object idsorkind = Conn.GetSys(field_getsys_sortkind);

            if (idsorkind == null || idsorkind == DBNull.Value) {
                allowSelection = false;
                allowNull = true;
                defaultValue = DBNull.Value;
                return;
            }

            filterkind = QHS.CmpEq("idsorkind", idsorkind);


            object idflowchart = Conn.GetSys("idflowchart");
            object ndetail = Conn.GetSys("ndetail");
            object idcustomuser = Conn.GetSys("idcustomuser");

            if (idflowchart == null || idflowchart == DBNull.Value) {
                allowSelection = true;
                allowNull = true;
                defaultValue = DBNull.Value;
                btnTag = GetManageTag(parenttable);
                return;
            }


            object as_filter = Conn.DO_READ_VALUE("uniconfig", null, "sorkind" + NtoS + "asfilter");
            if (as_filter == null || as_filter == DBNull.Value) as_filter = "N";
            object all_value = "S";
            object withchilds = "N";
            if (as_filter.ToString().ToUpper() == "S") {
                all_value = Conn.DO_READ_VALUE("flowchartuser",
                                QHS.AppAnd(QHS.CmpEq("idcustomuser", idcustomuser),
                                            QHS.CmpEq("idflowchart", idflowchart),
                                            QHS.CmpEq("ndetail", ndetail)),
                                " isnull(all_sorkind" + NtoS + ",'S')");
                if (all_value == null || all_value == DBNull.Value) {
                    all_value = "S";
                }
                if (all_value.ToString().ToUpper() == "N") {
                    withchilds = Conn.DO_READ_VALUE("flowchartuser",
                                QHS.AppAnd(QHS.CmpEq("idcustomuser", idcustomuser),
                                            QHS.CmpEq("idflowchart", idflowchart),
                                            QHS.CmpEq("ndetail", ndetail)),
                                " isnull(sorkind" + NtoS + "_withchilds,'N')");
                    if (withchilds == null || withchilds == DBNull.Value) {
                        withchilds = "N";
                    }
                }
            }

            if (all_value.ToString().ToUpper() == "S") {
                allowSelection = true;
                allowNull = true;
                defaultValue = DBNull.Value;
                btnTag = GetManageTag(parenttable);
                return;
            }

            object idsor = Conn.GetSys("idsor" + NtoS);
            if (withchilds.ToString().ToUpper() != "S") {
                allowSelection = false;
                allowNull = false;
                defaultValue = idsor;
                return;
            }
            filter_sec = Conn.GetUsr("cond_sor" + NtoS);
            if (filter_sec != null) {
                string f = filter_sec.ToString().Trim();
                if (f.StartsWith("AND(")) {
                    f = f.Substring(3);
                    filter_sec = f;
                }

                if (f == "(1=1") {
                    f = "";
                    filter_sec = null;
                }

                if (f != "") {
                    f = f.Replace("idsor" + NtoS, "idsor");
                    filter_sec = f;
                }
            }

            btnTag = GetChooseTag(parenttable);
            allowSelection = true;
            allowNull = false;
            defaultValue = idsor;



        }
    }
}
