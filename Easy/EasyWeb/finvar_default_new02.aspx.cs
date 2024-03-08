
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
using AllDataSet;
using metadatalibrary;
using funzioni_configurazione;
using EasyWebReport;

public partial class finvar_default_new02 : MetaPage {
    CQueryHelper QHC;
    QueryHelper QHS;
    vistaForm_finvar DS;
    string flagcredit;
    string flagproceeds;
    bool DoSendMail {
        get {
            return (bool)PState.var["doSendMail"];
        }
        set {
            PState.var["doSendMail"] = value;
        }
    }

    public override DataSet GetDataSet() {
        return DS;
    }

    public override DataSet CreateNewDataSet() {
        return new vistaForm_finvar();
    }

    public override void SetDataSet(DataSet D) {
        DS = (vistaForm_finvar)D;
    }


    public override void DoCommand(string command) {
        base.DoCommand(command);
        if (command == "ordinaperstato") {
            CommFun.DoMainCommand("maindosearch.webdefaultstatuses");
            return;
        }
        if (command == "storicovariazioni") {
            string filter;
            filter = QHS.AppAnd(QHS.CmpEq("idfinvarstatus", 5), Meta.StartFilter);
            CommFun.DoMainCommand("maindosearch.webdefaultstatuses." + filter);
            return;
        }
        if (command == "approvati") {
            btnStatus_Click(null, null);
        }

    }



    public override void AfterLink(bool firsttime, bool formToLink) {
        QHC = new CQueryHelper();
        QHS = Conn.GetQueryHelper();
        if (firsttime)
            DoSendMail = false;

        string filteresercizio = QHS.CmpEq("ayear", Conn.Security.GetSys("esercizio"));
        string filteresercvar = QHS.CmpEq("yvar", Conn.Security.GetSys("esercizio"));
        GetData.SetStaticFilter(DS.finvar, filteresercvar);
        GetData.SetStaticFilter(DS.finvardetail, filteresercvar);
        esercizio.Text = Conn.Security.GetSys("esercizio").ToString();
        esercizio.ReadOnly = true;

        if (IsFormVarInizale()) {
            Meta.Name = "Richiesta previsione iniziale NEW02";
            Meta.StartFilter = QHS.CmpEq("variationkind", 5);
            MetaData.SetDefault(DS.finvar, "variationkind", 5);
            if (CfgFn.NomePrevisioneSecondaria(Conn as DataAccess) == null)
                MetaData.SetDefault(DS.finvar, "flagprevision", "S");
            groupTipoPrevisione.Visible = false;
            //grpPrevisione.Visible = false;
            //chkPrevPrincipale.Tag = "";
            //ChkPrevSecondaria.Tag = "";

        }
        else {
            Meta.Name = "Richiesta variazione bilancio";
            Meta.StartFilter = QHS.CmpNe("variationkind", 5);
        }
        Meta.DefaultListType = "webdefault";
        SearchTable = "finvarview";

        MetaData.SetDefault(DS.finvar, "idfinvarstatus", 1);
        if (formToLink) {
            idfinvarstatus.DataSource = DS.finvarstatus;
            idfinvarstatus.DataValueField = "idfinvarstatus";
            idfinvarstatus.DataTextField = "description";

        }


        DS.finvardetail.ExtendedProperties["ViewTable"] = DS.finvardetailview;
        DS.finvardetailview.ExtendedProperties["RealTable"] = DS.finvardetail;

        DS.finvardetailview.Columns["yvar"].ExtendedProperties["ViewSource"] = "finvardetail.yvar";
        DS.finvardetailview.Columns["nvar"].ExtendedProperties["ViewSource"] = "finvardetail.nvar";
        DS.finvardetailview.Columns["rownum"].ExtendedProperties["ViewSource"] = "finvardetail.rownum";//<--
        DS.finvardetailview.Columns["idfin"].ExtendedProperties["ViewSource"] = "finvardetail.idfin";
        DS.finvardetailview.Columns["idupb"].ExtendedProperties["ViewSource"] = "finvardetail.idupb";//<--
        DS.finvardetailview.Columns["amount"].ExtendedProperties["ViewSource"] = "finvardetail.amount";
        DS.finvardetailview.Columns["description"].ExtendedProperties["ViewSource"] = "finvardetail.description";
        DS.finvardetailview.Columns["limit"].ExtendedProperties["ViewSource"] = "finvardetail.limit";
        DS.finvardetailview.Columns["annotation"].ExtendedProperties["ViewSource"] = "finvardetail.annotation";
        DS.finvardetailview.Columns["idexp"].ExtendedProperties["ViewSource"] = "finvardetail.idexp";
        DS.finvardetailview.Columns["createexpense"].ExtendedProperties["ViewSource"] = "finvardetail.createexpense";

        DS.finvardetailview.Columns["idunderwriting"].ExtendedProperties["ViewSource"] = "finvardetail.idunderwriting";
        DS.finvardetailview.Columns["underwriting"].ExtendedProperties["ViewSource"] = "underwriting.title";

        DS.finvardetailview.Columns["cu"].ExtendedProperties["ViewSource"] = "finvardetail.cu";
        DS.finvardetailview.Columns["ct"].ExtendedProperties["ViewSource"] = "finvardetail.ct";
        DS.finvardetailview.Columns["lu"].ExtendedProperties["ViewSource"] = "finvardetail.lu";
        DS.finvardetailview.Columns["lt"].ExtendedProperties["ViewSource"] = "finvardetail.lt";

        DS.finvardetailview.Columns["ayear"].ExtendedProperties["ViewSource"] = "fin.ayear";
        DS.finvardetailview.Columns["finpart"].ExtendedProperties["ViewSource"] = "fin.flag";
        DS.finvardetailview.Columns["codefin"].ExtendedProperties["ViewSource"] = "fin.codefin";
        DS.finvardetailview.Columns["finance"].ExtendedProperties["ViewSource"] = "fin.title";

        DS.finvardetailview.Columns["codeupb"].ExtendedProperties["ViewSource"] = "upb.codeupb";
        DS.finvardetailview.Columns["upb"].ExtendedProperties["ViewSource"] = "upb.title";

        DS.finvardetailview.Columns["prevision2"].ExtendedProperties["ViewSource"] = "finvardetail.prevision2";
        DS.finvardetailview.Columns["prevision3"].ExtendedProperties["ViewSource"] = "finvardetail.prevision3";

        HelpForm.SetDenyNull(DS.Tables["finvar"].Columns["official"], true);


        bool IsManager = (Session["CodiceResponsabile"] != null ? true : false);
        int idman = 0;
        idman = CfgFn.GetNoNullInt32(Session["CodiceResponsabile"]);

        if (IsManager) {
            if (Session["CodiceResponsabile"] != null) {
                DS.finvar.Columns["idman"].DefaultValue = idman;
                //this.Meta.StartFilter=QHS.CmpEq("idman",idman);
                //GetData.SetStaticFilter(DS.finvar, QHS.CmpEq("idman", idman));
                //idmanager.SelectedValue = idman.ToString();
                //EnableDisableControls(idmanager, true);
            }
        }



        //idfinvarstatus.DataSource = DS.finvarstatus;
        //idfinvarstatus.DataValueField = "idfinvarstatus";
        //idfinvarstatus.DataTextField = "description";
        //chkPrevPrincipale.CheckState = commonconst.CheckState.Indeterminate;

        return;
    }

    public override void AfterGetFormData() {
        return;
    }

    public override void AfterFill() {
        esercizio.ReadOnly = true;
        Saldo.ReadOnly = true;
        Limit.ReadOnly = true;

        B1.Visible = false;
        B2.Visible = false;
        if (PState.InsertMode) {
            LockUnLockControls(false);
            btnStatus.Visible = false;
            //ManageStatus();
        }
        if (PState.EditMode) {
            ManageStatus();
        }

        if (PState.EditMode || PState.InsertMode)
            idfinvarstatus.Enabled = false;

        decimal somma_entrate = MetaData.SumColumn(DS.finvardetail, "!entrata");
        decimal somma_spese = MetaData.SumColumn(DS.finvardetail, "!spesa");
        decimal saldo = somma_entrate - somma_spese;
        Saldo.Text = saldo.ToString("c");
        //btnStorno.Enabled = true;
        //NumUfficiale.ReadOnly = true;

        if (CheckLimit()) {
            img_Red.Visible = true;
            img_Green.Visible = false;
            LimSuperato.Visible = true;
        }
        else {
            img_Red.Visible = false;
            img_Green.Visible = true;
            LimSuperato.Visible = false;
        }

        valorizzaTxtNumUfficiale();

        EnableDisableVariationKind();
        return;
    }


    public override void AfterClear() {
        B1.Visible = true;
        B2.Visible = true;
        //Saldo.ReadOnly = false;
        Limit.ReadOnly = false;

        esercizio.Text = Conn.Security.GetEsercizio().ToString();
        esercizio.ReadOnly = true;

        Saldo.Text = "";

        //groupTipoPrevisione.Disabled = false;
        groupTipoPrevisione.Enabled = true;

        //chkPrevPrincipale.Checked = true;
        //ChkPrevSecondaria.Checked = true;



        // SearchMode?
        img_Green.Visible = false;
        img_Red.Visible = false;
        LimSuperato.Visible = false;
        btnStatus.Visible = false;



        //Official.CheckState = CheckState.Indeterminate;

        //NumUfficiale.ReadOnly = false;


        //btnStorno.Enabled = false;
        LockUnLockControls(false);
        NumUfficiale.Visible = true;
        NumUfficiale.ReadOnly = false;
        esercizio.ReadOnly = true;

        EnableDisableVariationKind();
        return;
    }

    private void EnableDisableVariationKind() {
        if ((PState.IsEmpty) || (PState.InsertMode)) {
            variationtime1.Enabled = true;
            variationtime2.Enabled = true;
            variationtime3.Enabled = true;
            variationtime4.Enabled = true;

            //variationtime5.Enabled = true; Questa parte resta commentata, perchè in realtà questo check non è presente nel codice .aspx, esiste ma è commentato. Per le Var. di tipo Iniziale 
            //c'è una voce di menu apposita che richiama questa pagina, e il gruppo Tipo Variazione viene completamente nascoso
        }
        if (PState.EditMode) {
            DataRow Curr = DS.finvar.Rows[0];
            int variationkind = CfgFn.GetNoNullInt32(Curr["variationkind"]);
            if (variationkind == 5) // tipo variazione iniziale
                {
                variationtime1.Enabled = false;
                variationtime2.Enabled = false;
                variationtime3.Enabled = false;
                variationtime4.Enabled = false;

                //riationtime5.Enabled = true; //leggi sopra
            }
            else {
                variationtime1.Enabled = true;
                variationtime2.Enabled = true;
                variationtime3.Enabled = true;
                variationtime4.Enabled = true;

                //variationtime5.Enabled = false; //leggi sopra
            }
        }


    }

    void ManageStatus() {
        // Status is:
        // 1:Bozza - 2:Richiesta - 3:Da Correggere - 4:Inserito - 5:Approvato - 6:Annullato
        DataRow CurrentRow = DS.finvar.Rows[0];

        int status = CfgFn.GetNoNullInt32(CurrentRow["idfinvarstatus"]);
        if (status >= 4) {
            Meta.CanSave = false;
            Meta.CanCancel = false;
        }
        else {
            Meta.CanSave = true;
            Meta.CanCancel = true;
        }
        switch (status) {
            case 1:
                if (!PState.InsertMode) {
                    btnStatus.Text = "Invia Richiesta";
                    btnStatus.Visible = true;
                    LockUnLockControls(false);
                }
                break;
            case 2:
                btnStatus.Text = "Modifica";
                btnStatus.Visible = true;
                LockUnLockControls(true);
                btnStatus.Enabled = true;
                EnableDisableControls(HwEditAllegato, false);

                break;
            case 3:
                btnStatus.Visible = true;
                btnStatus.Text = "Invia Richiesta";
                LockUnLockControls(false);
                btnStatus.Enabled = true;
                break;
            default:
                // Blocca tutto
                btnStatus.Visible = false;
                LockUnLockControls(true);
                //btnStatus.Enabled = true;
                EnableDisableControls(btnStatus, false);
                EnableDisableControls(HwEditAllegato, false);

                btnStatus.Visible = false;
                break;
        }
        return;
    }


    void LockUnLockControls(bool Lock) {
        MetaPageMaster MP = Master as MetaPageMaster;

        Control ContentDiv = MP.GetContentDiv();
        EnableDisableControls(ContentDiv, Lock);
        esercizio.ReadOnly = true;
        Saldo.ReadOnly = true;
        Limit.ReadOnly = true;
        return;
    }

    void EnableDisableControls(Control C, bool Lock) {
        if (C == Saldo)
            return;

        if (typeof(WebControl).IsAssignableFrom(C.GetType())) {
            WebControl CC = C as WebControl;
            if (typeof(hwButton).IsAssignableFrom(CC.GetType()) ||// typeof(hwTextBox).IsAssignableFrom(CC.GetType()) ||
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

    bool IsFormVarInizale() {
        if (Meta.edit_type.ToLower() == "inizialenew02")
            return true;
        return false;
    }
    public override void BeforeFill() {
        if (DS.finvar.Rows.Count == 0)
            return;
        if (DS.Tables["config"].Rows.Count == 0)
            return;
        DataRow curr = DS.finvar.Rows[0];
        string ufficiale = curr["official"].ToString().ToUpper();
        bool disabilita = (ufficiale == "S") && PState.InsertMode;
        DisabilitaUfficiale(disabilita);
        if (flagcredit == "N") {
            if (curr["flagcredit"].ToString().ToUpper() == "S") {
                //chkCrediti.Visible = true;
            }
            else {
                //chkCrediti.Visible = false;
            }
        }
        if (flagproceeds == "N") {
            if (curr["flagproceeds"].ToString().ToUpper() == "S") {
                //chkCassa.Visible = true;
            }
            else {
                //chkCassa.Visible = false;
            }
        }
    }


    public override void AfterActivation(bool firsttime, bool formToLink) {
        //sets labels for RadioButtons, reading them from persbilancio

        string SqlFilter = QHS.CmpEq("ayear", Conn.Security.GetSys("esercizio"));
        GetData.CacheTable(DS.config, SqlFilter, null, false);
        CommFun.ReadCached();
        if (DS.Tables["config"].Rows.Count == 0)
            return;
        DataRow R = DS.Tables["config"].Rows[0];
        flagcredit = Conn.Security.GetSys("flagcredit").ToString().ToUpper();
        flagproceeds = Conn.Security.GetSys("flagproceeds").ToString().ToUpper();
        string nomeprevsecondaria = CfgFn.NomePrevisioneSecondaria(Conn as DataAccess);
        if (nomeprevsecondaria == null) {
            ChkPrevSecondaria.Tag = "";
            chkPrevPrincipale.Checked = true;
            ChkPrevSecondaria.Visible = false;
        }
        else {

            ChkPrevSecondaria.Text = nomeprevsecondaria;
        }

        chkPrevPrincipale.Text = CfgFn.NomePrevisionePrincipale(Conn as DataAccess);
        //btnStorno.BackColor = formcolors.GridButtonBackColor();
        //btnStorno.ForeColor = formcolors.GridButtonForeColor();
    }

    public override void BeforePost() {
        if (DS.finvar.Rows.Count == 0)
            return;

        DataRow CurrRow = DS.finvar.Rows[0];
        if (CurrRow.RowState != DataRowState.Deleted) {
            int CurrentStatus = CfgFn.GetNoNullInt32(CurrRow["idfinvarstatus"]);
            int OriginalStatus;
            if (!PState.InsertMode)
                OriginalStatus = CfgFn.GetNoNullInt32(CurrRow["idfinvarstatus", DataRowVersion.Original]);
            else
                OriginalStatus = CurrentStatus;


            if (CurrentStatus != OriginalStatus && CurrentStatus == 2)
                DoSendMail = true;
            else
                DoSendMail = false;
        }
    }

    public override void AfterPost() {
        if (DoSendMail) {
            string MsgBody = "";
            DataRow CurrentRow = DS.finvar.Rows[0];
            string warnmail = null;
            DataRow[] ConfigRow = DS.config.Select(QHS.CmpEq("ayear", Conn.Security.GetSys("esercizio")));
            if (ConfigRow[0] == null)
                return;
            warnmail = ConfigRow[0]["finvar_warnmail"].ToString();
            if (warnmail == "") {
                if (Conn.Security.GetSys("defaultdepmail") != null && Conn.Security.GetSys("defaultdepmail").ToString() != "") {
                    warnmail = Conn.Security.GetSys("defaultdepmail").ToString();
                }
            }


            if ( warnmail != "") {
                MsgBody = "La variazione di bilancio numero " + CurrentRow["nvar"] + " relativa all'esercizio " + CurrentRow["yvar"] + "\r\n";
                MsgBody += "E' passata nello stato 'Richiesta'.\r\n";

                MsgBody += " Dettagli:\r\n";
                if (CurrentRow["description"].ToString() != "")
                    MsgBody += CurrentRow["description"].ToString() + "\r\n";
                if (CurrentRow["annotation"].ToString() != "")
                    MsgBody += CurrentRow["annotation"].ToString() + "\r\n";
                MsgBody += "\r\n\r\n";
                foreach (DataRow RD in DS.finvardetail.Select()) {
                    MsgBody += GetTextForFinVarDetail(RD);
                    if (RD["description"].ToString() != "")
                        MsgBody += RD["description"].ToString() + "\r\n";
                    if (RD["annotation"].ToString() != "")
                        MsgBody += RD["annotation"].ToString() + "\r\n";
                }
                MsgBody += "\r\n";

                SendMail SM = new SendMail {
                    UseSMTPLoginAsFromField = true,
                    To = warnmail,
                    Subject = "Notifica cambiamento di stato variazione di bilancio",
                    MessageBody = MsgBody,
                    Conn = Conn as DataAccess
                };
                DoSendMail = false;
                if (!SM.Send()) {
                    if (SM.ErrorMessage.Trim() != "")
                        ShowClientMessage(SM.ErrorMessage, "Errore");
                }
            }
        }

    }


    string GetTextForFinVarDetail(DataRow R) {
        string S = "";
        object idfin = R["idfin"];
        DataRow Fin = DS.fin.Select(QHC.CmpEq("idfin", idfin))[0];
        S += "Voce Bilancio " + Fin["codefin"].ToString() + " - " + Fin["title"].ToString() + "\r\n";
        object idupb = R["idupb"];
        DataRow Upb = DS.upb.Select(QHC.CmpEq("idupb", idupb))[0];
        S += "UPB " + Upb["codeupb"].ToString() + " - " + Upb["title"].ToString() + "\r\n";
        S += "Importo variazione:" + CfgFn.GetNoNullDecimal(R["amount"]).ToString("c") + "\r\n";
        ;
        return S;

    }


    public bool CheckLimitDetail() {
        bool OverLimit = false;
        foreach (DataRow DR in DS.finvardetail.Rows) {
            decimal LimitDetail = CfgFn.GetNoNullDecimal(DR["limit"]);
            decimal Amount = CfgFn.GetNoNullDecimal(DR["amount"]);
            if (LimitDetail != 0)
                if (Amount > LimitDetail)
                    OverLimit = true;

        }
        return OverLimit;
    }
    public bool CheckLimit() {
        decimal somma_entrate = MetaData.SumColumn(DS.finvardetail, "!entrata");
        decimal somma_spese = MetaData.SumColumn(DS.finvardetail, "!spesa");
        decimal saldo = somma_entrate - somma_spese;

        DataRow Curr = DS.finvar.Rows[0];
        if (Curr != null) {

            if (Curr["limit"] != DBNull.Value) {
                if (saldo > CfgFn.GetNoNullDecimal(Curr["limit"]))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        else
            return false;

    }

    protected void btnStatus_Click(object sender, EventArgs e) {

        if (PState.EditMode) {
            DataRow currentRow = DS.finvar.Rows[0];
            int status = CfgFn.GetNoNullInt32(currentRow["idfinvarstatus"]);

            switch (status) {
                case 1:
                    currentRow["idfinvarstatus"] = 2;
                    //managingstatus = true;
                    CommFun.FreshPage(false, false);
                    //managingstatus = false;
                    CommFun.DoMainCommand("mainsave");
                    break;
                case 3:
                    if (CheckLimit())
                        ShowClientMessage("Non è possibile avanzare la richiesta " +
                            "in quanto il limite totale della variazione è stato superato.", "Attenzione",
                            System.Windows.Forms.MessageBoxButtons.OK);
                    else
                        if (CheckLimitDetail())
                            ShowClientMessage("Non è possibile avanzare la richiesta " +
                                "in quanto il limite di un dettaglio di variazione è stato superato.", "Attenzione",
                                System.Windows.Forms.MessageBoxButtons.OK);
                        else {
                            currentRow["idfinvarstatus"] = 2;
                            //managingstatus = true;
                            CommFun.FreshPage(false, false);
                            //managingstatus = false;
                            CommFun.DoMainCommand("mainsave");
                        }
                    break;
                case 2:
                    currentRow["idfinvarstatus"] = 3;
                    //managingstatus = true;
                    CommFun.FreshPage(false, false);
                    //managingstatus = false;
                    CommFun.DoMainCommand("mainsave");
                    break;
            }

        }
    }


    private object CalcID(DataRow R, DataColumn C, IDataAccess Conn) {
        // I selettori del campo NOFFICIAL sono YVAR e OFFICIAL
        int yvar = CfgFn.GetNoNullInt32(R["yvar"]);
        string official = R["official"].ToString().ToUpper();
        // Se la variazione non è ufficiale non calcolo il campo
        if (official != "S") {
            return null;
        }

        string filter = QHS.AppAnd(QHS.CmpEq("yvar", yvar), QHS.CmpEq("official", 'S'));
        object nOff = Conn.DO_READ_VALUE("finvar", filter, "MAX(nofficial)");
        if (nOff == null)
            return null;

        int nOfficial = 1 + CfgFn.GetNoNullInt32(nOff);

        return nOfficial;
    }

    private void valorizzaTxtNumUfficiale() {
        if (DS.finvar.Rows.Count == 0)
            return;
        if (!PState.EditMode)
            return;

        DataRow Curr = DS.finvar.Rows[0];
        string ufficiale = (Official.Checked) ? "S" : "N";

        if (ufficiale == "S") {
            if (Curr["nofficial", DataRowVersion.Original] != DBNull.Value) {
                int oldValue = CfgFn.GetNoNullInt32(Curr["nofficial", DataRowVersion.Original]);
                NumUfficiale.HiddenContent = false;
                NumUfficiale.Text = oldValue.ToString();
            }
        }
        else {
            NumUfficiale.HiddenContent = true;
            NumUfficiale.Text = "";
        }
    }

    private void DisabilitaUfficiale(bool disable) {
        if (disable || PState.InsertMode) {
            NumUfficiale.HiddenContent = true; // = ' ';
        }
        else {
            NumUfficiale.HiddenContent = false;
        }
        NumUfficiale.ReadOnly = disable || PState.InsertMode;
        if (disable) {
            RowChange.MarkAsAutoincrement(DS.Tables["finvar"].Columns["nofficial"], null, null, 7);
            RowChange.markAsCustomAutoincrement(DS.Tables["finvar"].Columns["nofficial"], CalcID);
        }
        else {
            RowChange.ClearAutoIncrement(DS.Tables["finvar"].Columns["nofficial"]);
            RowChange.ClearCustomAutoIncrement(DS.Tables["finvar"].Columns["nofficial"]);
        }

        if (PState.InsertMode) {
            /*
            if (disable) {
            }
            else {
                txtNumUfficiale.PasswordChar = Convert.ToChar(0);
            }*/
            NumUfficiale.Text = "";
        }
    }


}

