
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
using AllDataSet;
using metadatalibrary;
using funzioni_configurazione;
using EasyWebReport;

public partial class accountvar_default_new02 : MetaPage {
    CQueryHelper QHC;
    QueryHelper QHS;
    vistaForm_accountvar DS;
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
        return new vistaForm_accountvar();
    }

    public override void SetDataSet(DataSet D) {
        DS = (vistaForm_accountvar)D;
    }


    public override void AfterLink(bool firsttime, bool formToLink) {
        QHC = new CQueryHelper();
        QHS = Meta.Conn.GetQueryHelper();
        if (firsttime)
            DoSendMail = false;

        if (IsFormVarInizale()) {
            Meta.Name = "Richiesta previsione iniziale";
            Meta.StartFilter = QHS.CmpEq("variationkind", 5);
            MetaData.SetDefault(DS.accountvar, "variationkind", 5);
            groupTipoPrevisione.Visible = false;
        }
        else {
            Meta.Name = "Richiesta variazione budget";
            Meta.StartFilter = QHS.CmpNe("variationkind", 5);
            MetaData.SetDefault(DS.accountvar, "variationkind", 1);
        }
        Meta.DefaultListType = "webdefault";
        SearchTable = "accountvarview";

        DataAccess.SetTableForReading(DS.sorting1, "sorting");
        DataAccess.SetTableForReading(DS.sorting2, "sorting");
        DataAccess.SetTableForReading(DS.sorting3, "sorting");
        //MetaData.SetDefault(DS.accountvar, "idaccountvarstatus", "5");//Impostiamo per default lo stato in Approvata 
        MetaData.SetDefault(DS.accountvar, "idaccountvarstatus", "1");//Impostiamo per default lo stato in Bozza
        if (formToLink) {
            idaccountvarstatus.DataSource = DS.accountvarstatus;
            idaccountvarstatus.DataValueField = "idaccountvarstatus";
            idaccountvarstatus.DataTextField = "description";

            //idmanager.DataSource = DS.manager;
            //idmanager.DataValueField = "idman";
            //idmanager.DataTextField = "title";
        }

        DS.accountvardetail.ExtendedProperties["ViewTable"] = DS.accountvardetailview;
        DS.accountvardetailview.ExtendedProperties["RealTable"] = DS.accountvardetail;
        DS.account.ExtendedProperties["ViewTable"] = DS.accountvardetailview;
        DS.upb.ExtendedProperties["ViewTable"] = DS.accountvardetailview;
        DS.costpartition.ExtendedProperties["ViewTable"] = DS.accountvardetailview;

        DS.accountvardetailview.Columns["yvar"].ExtendedProperties["ViewSource"] = "accountvardetail.yvar";
        DS.accountvardetailview.Columns["nvar"].ExtendedProperties["ViewSource"] = "accountvardetail.nvar";
        DS.accountvardetailview.Columns["rownum"].ExtendedProperties["ViewSource"] = "accountvardetail.rownum";
        DS.accountvardetailview.Columns["idacc"].ExtendedProperties["ViewSource"] = "accountvardetail.idacc";
        DS.accountvardetailview.Columns["idupb"].ExtendedProperties["ViewSource"] = "accountvardetail.idupb";
        DS.accountvardetailview.Columns["amount"].ExtendedProperties["ViewSource"] = "accountvardetail.amount";
        DS.accountvardetailview.Columns["description"].ExtendedProperties["ViewSource"] = "accountvardetail.description";

        DS.accountvardetailview.Columns["cu"].ExtendedProperties["ViewSource"] = "accountvardetail.cu";
        DS.accountvardetailview.Columns["ct"].ExtendedProperties["ViewSource"] = "accountvardetail.ct";
        DS.accountvardetailview.Columns["lu"].ExtendedProperties["ViewSource"] = "accountvardetail.lu";
        DS.accountvardetailview.Columns["lt"].ExtendedProperties["ViewSource"] = "accountvardetail.lt";

        DS.accountvardetailview.Columns["ayear"].ExtendedProperties["ViewSource"] = "account.ayear";
        DS.accountvardetailview.Columns["codeupb"].ExtendedProperties["ViewSource"] = "upb.codeupb";
        DS.accountvardetailview.Columns["upb"].ExtendedProperties["ViewSource"] = "upb.title";
        DS.accountvardetailview.Columns["codeacc"].ExtendedProperties["ViewSource"] = "account.codeacc";
        DS.accountvardetailview.Columns["account"].ExtendedProperties["ViewSource"] = "account.title";
        DS.accountvardetailview.Columns["flagaccountusage"].ExtendedProperties["ViewSource"] = "account.flagaccountusage";

        DS.accountvardetailview.Columns["amount2"].ExtendedProperties["ViewSource"] = "accountvardetail.amount2";
        DS.accountvardetailview.Columns["amount3"].ExtendedProperties["ViewSource"] = "accountvardetail.amount3";
        DS.accountvardetailview.Columns["amount4"].ExtendedProperties["ViewSource"] = "accountvardetail.amount4";
        DS.accountvardetailview.Columns["amount5"].ExtendedProperties["ViewSource"] = "accountvardetail.amount5";
        DS.accountvardetailview.Columns["annotation"].ExtendedProperties["ViewSource"] = "accountvardetail.annotation";
        DS.accountvardetailview.Columns["idsor1"].ExtendedProperties["ViewSource"] = "accountvardetail.idsor1";
        DS.accountvardetailview.Columns["idsor2"].ExtendedProperties["ViewSource"] = "accountvardetail.idsor2";
        DS.accountvardetailview.Columns["idsor3"].ExtendedProperties["ViewSource"] = "accountvardetail.idsor3";
        DS.accountvardetailview.Columns["sortcode1"].ExtendedProperties["ViewSource"] = "sorting1.sortcode";
        DS.accountvardetailview.Columns["sortcode2"].ExtendedProperties["ViewSource"] = "sorting2.sortcode";
        DS.accountvardetailview.Columns["sortcode3"].ExtendedProperties["ViewSource"] = "sorting3.sortcode";
        DS.accountvardetailview.Columns["costpartitioncode"].ExtendedProperties["ViewSource"] = "costpartition.costpartitioncode";
        DS.accountvardetailview.Columns["idcostpartition"].ExtendedProperties["ViewSource"] = "accountvardetail.idcostpartition";
        DS.accountvardetailview.Columns["prevcassa"].ExtendedProperties["ViewSource"] = "accountvardetail.prevcassa";
        bool IsManager = (Session["CodiceResponsabile"] != null ? true : false);
        int idman = 0;
        idman = CfgFn.GetNoNullInt32(Session["CodiceResponsabile"]);

        if (IsManager) {
            if (Session["CodiceResponsabile"] != null) {
                DS.accountvar.Columns["idman"].DefaultValue = idman;
            }
        }
        return;
    }

    public override void BeforePost() {
        if (DS.accountvar.Rows.Count == 0)
            return;

        DataRow CurrRow = DS.accountvar.Rows[0];
        if (CurrRow.RowState != DataRowState.Deleted) {
            int CurrentStatus = CfgFn.GetNoNullInt32(CurrRow["idaccountvarstatus"]);
            int OriginalStatus;
            if (!PState.InsertMode)
                OriginalStatus = CfgFn.GetNoNullInt32(CurrRow["idaccountvarstatus", DataRowVersion.Original]);
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
            DataRow CurrentRow = DS.accountvar.Rows[0];
            string warnmail = null;

            if (CurrentRow["idman"] == DBNull.Value) return;
            int idman = CfgFn.GetNoNullInt32(CurrentRow["idman"]);
            string filter = QHS.CmpEq("idman", idman);

            DataTable T = Meta.Conn.RUN_SELECT("manager", "*", null, filter, null, false);
            if (T.Rows[0]["wantswarn"].ToString().ToUpper() != "S") return;

            warnmail = T.Rows[0]["email"].ToString();
            if (warnmail != null && warnmail != "") {
                MsgBody = "La variazione di budget numero " + CurrentRow["nvar"] + " relativa all'esercizio " + CurrentRow["yvar"] + "\r\n";
                MsgBody += "E' passata nello stato 'Richiesta'.\r\n";

                MsgBody += " Dettagli:\r\n";
                if (CurrentRow["description"].ToString() != "")
                    MsgBody += CurrentRow["description"].ToString() + "\r\n";
                if (CurrentRow["annotation"].ToString() != "")
                    MsgBody += CurrentRow["annotation"].ToString() + "\r\n";
                MsgBody += "\r\n\r\n";
                foreach (DataRow RD in DS.accountvardetail.Select()) {
                    MsgBody += GetTextForAccountVarDetail(RD);
                    if (RD["description"].ToString() != "")
                        MsgBody += RD["description"].ToString() + "\r\n";
                    if (RD["annotation"].ToString() != "")
                        MsgBody += RD["annotation"].ToString() + "\r\n";
                }
                MsgBody += "\r\n";

                SendMail SM = new SendMail();
                SM.UseSMTPLoginAsFromField = true;
                SM.To = warnmail;
                SM.Subject = "Notifica cambiamento di stato variazione di budget";
                SM.MessageBody = MsgBody;
                SM.Conn = Conn as DataAccess;
                DoSendMail = false;
                if (!SM.Send()) {
                    if (SM.ErrorMessage.Trim() != "")
                        ShowClientMessage(SM.ErrorMessage, "Errore");
                }
            }
        }

    }


    string GetTextForAccountVarDetail(DataRow R) {
        string S = "";
        object idacc = R["idacc"];
        DataRow Account = DS.account.Select(QHC.CmpEq("idacc", idacc))[0];
        S += "Conto " + Account["codeacc"].ToString() + " - " + Account["title"].ToString() + "\r\n";
        object idupb = R["idupb"];
        DataRow Upb = DS.upb.Select(QHC.CmpEq("idupb", idupb))[0];
        S += "UPB " + Upb["codeupb"].ToString() + " - " + Upb["title"].ToString() + "\r\n";
        S += "Importo variazione:" + CfgFn.GetNoNullDecimal(R["amount"]).ToString("c") + "\r\n";
        ;
        return S;

    }

    public decimal saldoCostiRicavi() {
        object flagObj = null;
        decimal costi = 0;
        decimal ricavi = 0;
        decimal immobilizzazioni = 0;
        if (DS.accountvar.Rows.Count == 0) return 0;

        foreach (DataRow rDettaglio in DS.accountvardetail.Rows) {
            if (rDettaglio.RowState == DataRowState.Deleted) continue;

            string filterAccount = QHC.CmpEq("idacc", rDettaglio["idacc"]);

            DataRow rAccount = DS.account.First(filterAccount);
            flagObj = rAccount["flagaccountusage"];


            if (flagObj != DBNull.Value) {
                int flag = Convert.ToInt32(flagObj);
                bool costo = (flag & 64) != 0;
                bool ricavo = (flag & 128) != 0;
                bool immobilizzazione = (flag & 256) != 0;

                decimal somma_amount_quinquennnio = CfgFn.GetNoNullDecimal(rDettaglio["amount"]) +
                                                    CfgFn.GetNoNullDecimal(rDettaglio["amount2"]) +
                                                    CfgFn.GetNoNullDecimal(rDettaglio["amount3"]) +
                                                    CfgFn.GetNoNullDecimal(rDettaglio["amount4"]) +
                                                    CfgFn.GetNoNullDecimal(rDettaglio["amount5"]);
                if (costo) costi += somma_amount_quinquennnio;
                if (ricavo) ricavi += somma_amount_quinquennnio;
                if (immobilizzazione) immobilizzazioni += somma_amount_quinquennnio;

            }


        }

        return ricavi - costi - immobilizzazioni;

    }
    public override void AfterGetFormData() {
        return;
    }

    public override void AfterFill() {
        Saldo.ReadOnly = true;
		esercizio.ReadOnly = true;
		if (PState.InsertMode) {
            LockUnLockControls(false);
            btnStatus.Visible = false;
        }
        if (PState.EditMode) {
            ManageStatus();
        }

        if (PState.EditMode || PState.InsertMode)
            idaccountvarstatus.Enabled = false;

        Saldo.Text = saldoCostiRicavi().ToString("c");

        EnableDisableVariationKind();
        return;
    }

    public override void AfterClear() {
        Saldo.ReadOnly = true;
        esercizio.Text = Meta.Conn.GetEsercizio().ToString();
        Saldo.Text = "";
        groupTipoPrevisione.Enabled = true;
        btnStatus.Visible = false;
        Meta.CanSave = true;
        Meta.CanCancel = true;
        LockUnLockControls(false);
        esercizio.ReadOnly = true;
        EnableDisableVariationKind();
        return;
    }

    private void EnableDisableVariationKind() {
        if ((PState.IsEmpty) || (PState.InsertMode)) {
            variationtime1.Enabled = true;//Tipo Normale
            //variationtime5.Enabled = true; Questa parte resta commentata, perchè in realtà questo check non è presente nel codice .aspx, esiste ma è commentato. Per le Var. di tipo Iniziale 
            //c'è una voce di menu apposita che richiama questa pagina, e il gruppo Tipo Variazione viene completamente nascoso
        }
        if (PState.EditMode) {
            DataRow Curr = DS.accountvar.Rows[0];
            int variationkind = CfgFn.GetNoNullInt32(Curr["variationkind"]);
            if (variationkind == 5) // tipo variazione iniziale
                {
                variationtime1.Enabled = false;
                variationtime5.Enabled = true; //leggi sopra
            }
            else {
                variationtime1.Enabled = true;
                variationtime5.Enabled = false; //leggi sopra
            }
        }
    }

    void ManageStatus() {
        // Status is:
        // 1:Bozza - 2:Richiesta - 3:Da Correggere - 4:Inserito - 5:Approvato - 6:Annullato
        DataRow CurrentRow = DS.accountvar.Rows[0];

        int status = CfgFn.GetNoNullInt32(CurrentRow["idaccountvarstatus"]);
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
    public override void DoCommand(string command) {
        base.DoCommand(command);

        if (command == "approvati") {
            btnStatus_Click(null, null);
        }

    }

    protected void btnStatus_Click(object sender, EventArgs e) {

        if (PState.EditMode) {
            DataRow CurrentRow = DS.accountvar.Rows[0];
            int status = CfgFn.GetNoNullInt32(CurrentRow["idaccountvarstatus"]);

            switch (status) {
                case 1:
                    CurrentRow["idaccountvarstatus"] = 2;
                    //managingstatus = true;
                    CommFun.FreshPage(false, false);
                    //managingstatus = false;
                    CommFun.DoMainCommand("mainsave");
                    break;
                case 3:
                    CurrentRow["idaccountvarstatus"] = 2;
                    //managingstatus = true;
                    CommFun.FreshPage(false, false);
                    //managingstatus = false;
                    CommFun.DoMainCommand("mainsave");
                    break;
                case 2:
                    CurrentRow["idaccountvarstatus"] = 3;
                    //managingstatus = true;
                    CommFun.FreshPage(false, false);
                    //managingstatus = false;
                    CommFun.DoMainCommand("mainsave");
                    break;
            }

        }
    }



}

