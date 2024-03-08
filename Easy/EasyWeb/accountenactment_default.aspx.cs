
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
using metadatalibrary;
using HelpWeb;
using AllDataSet;
using funzioni_configurazione;

public partial class accountenactment_default :MetaPage {
    CQueryHelper QHC;
    QueryHelper QHS;
    vistaForm_accountenactment DS;

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
        return new vistaForm_accountenactment();
    }

    public override void SetDataSet(DataSet D) {
        DS = (vistaForm_accountenactment)D;
    }



    protected void Page_Load(object sender, EventArgs e) {

    }

    public override void AfterLink(bool firsttime, bool formToLink) {
        Meta.DefaultListType = "default";
        Meta.Name = "Atto amministrativo di Budget";
        SearchTable = "accountenactment";
        QueryCreator.SetTableForPosting(DS.accountvarview, "accountvar");
        QHS = Conn.GetQueryHelper();
        QHC = new CQueryHelper();
        GetData.SetStaticFilter(DS.accountenactment, QHS.CmpEq("yenactment", Conn.Security.GetSys("esercizio")));
        GetData.SetStaticFilter(DS.accountvarview, QHS.CmpEq("yvar", Conn.Security.GetSys("esercizio")));
        if (firsttime)
            DoSendMail = false;

    }

    public override void AfterActivation(bool firsttime, bool formToLink) {
    }

    public override void AfterClear() {
        gboxStato.Disabled = false;
        btnAnnulla.Visible = false;
        btnApprova.Visible = false;
        btnWait.Visible = false;

        txtEsercizioDocumento.Text = Conn.Security.GetSys("esercizio").ToString();
        btnCollega.Enabled = false;
        btnScollega.Enabled = false;
        btnModifica.Enabled = false;

        txtNumeroDocumento.ReadOnly = false;
        DS.accountvarview.Clear();

    }
    public override void AfterFill() {

        bool ModoInsert = PState.InsertMode;
        bool ModoEdit = PState.EditMode;
        DataRow Curr = DS.accountenactment.Rows[0];
        string filtraAtto = QHS.CmpKey(Curr);
        AbilitaVariazioni(true);

        btnApprova.Enabled = true;
        btnAnnulla.Enabled = true;

        if (ModoEdit) {
            txtNumeroDocumento.ReadOnly = true;
        }
        gboxStato.Disabled = true;

        btnWait.Visible = !rdbInAttesa.Checked;
        btnApprova.Visible = rdbInAttesa.Checked;
        btnAnnulla.Visible = rdbInAttesa.Checked;

        if (rdbInAttesa.Checked) {
            AbilitaVariazioni(true);
        }
        else {
            AbilitaVariazioni(false);
        }

    }


    string CalculateFilterForLinking(bool SQL) {
        QueryHelper qh = SQL ? QHS : QHC;
        string MyFilter = "";
        int currentyear = (int)Conn.Security.GetSys("esercizio");
        //Aggiunge solo le var. di tipo "inserito"
        MyFilter = qh.IsNull("idenactment");
        // in inserimento solo variazioni ufficiali
        if (SQL) {
            MyFilter = qh.AppAnd(MyFilter,
                qh.CmpGe("idaccountvarstatus", 4), qh.CmpEq("yvar", currentyear));
        }

        return MyFilter;
    }

    public override void DoCommand(string command) {
        base.DoCommand(command);
        if (command == "collega") {
            btnCollega_Click(null, null);
        }
        if (command == "modifica") {
            btnModifica_Click(null, null);
        }

        if (command == "do_approva")
            btnApprova_Click(null, null);
        if (command == "do_wait")
            btnWait_Click(null, null);
        if (command == "do_annulla")
            btnAnnulla_Click(null, null);



    }



    protected void btnCollega_Click(object sender, System.EventArgs e) {

        if (PState.IsEmpty)
            return;
        CommFun.GetFormData(true);
        string MyFilter = CalculateFilterForLinking(true);
        string command = "choose.accountvarview.documentocollegato." + MyFilter;


        CommFun.DoMainCommand(command);

    }

    protected void btnModifica_Click(object sender, System.EventArgs e) {
        if (CommFun.IsEmpty)
            return;
        CommFun.GetFormData(true);
        string MyFilter = CalculateFilterForLinking(false);
        string MyFilterSQL = CalculateFilterForLinking(true);

        // Qui va fatta la chiamata vera e propria a "MultipleSelection"
        MetaDataDispatcher MDD = new MetaDataDispatcher(Conn);
        MetaData MD = new MetaData(Conn, MDD, MDD.security, "sys_accountenactment_multi");
        MD.Name = "multiselect";
        MD.edit_type = "default";
        Hashtable HTParms = new Hashtable();
        HTParms["FormTitle"] = "Composizione documento";
        HTParms["LabelAdded"] = "Movimenti inclusi nel documento selezionato";
        HTParms["LabelToAdd"] = "Movimenti non inclusi in alcun documento";
        HTParms["NotEntityChildTable"] = DS.accountvarview;
        HTParms["Filter"] = MyFilter;
        HTParms["FilterSQL"] = MyFilterSQL;
        HTParms["ListingType"] = "documentocollegato";
        HTParms["RealMeta"] = Meta;
        MD.ExtraParameter = HTParms;
        Session["MetaToPass"] = MD;
        AppState.CallPage(Page, MD, false);

    }




    protected void btnApprova_Click(object sender, EventArgs e) {
        DataRow Curr = DS.accountenactment.Rows[0];
        if (Curr["adate"] == DBNull.Value) {
            ShowClientMessage("E' necessario, prima di approvare l'atto, inserirne la data di approvazione", "Attenzione", System.Windows.Forms.MessageBoxButtons.OK);
            txtDataContabile.Focus();
            return;
        }

        SetRunningCommand("do_approva");
        bool do_update = ShowClientMessage("Approvando l'atto " +
                "e tutte le variazioni di budget in esso contenute che attualmente " +
                "sono nello stato di 'Inserita' passeranno allo stato di " +
                " 'Approvata' ", "Attenzione", System.Windows.Forms.MessageBoxButtons.OKCancel);
        if (!do_update)
            return;

        foreach (DataRow RR in DS.accountvarview.Select()) {
            if (RR["idaccountvarstatus"].ToString() == "4")
                RR["idaccountvarstatus"] = 5;
            CommFun.CheckEntityChildRowAdditions(RR, null);

        }
        Curr["idenactmentstatus"] = 2;

        ClearRunningCommand();
        CommFun.DoMainCommand("mainsave");
    }

    protected void btnWait_Click(object sender, EventArgs e) {
        SetRunningCommand("do_wait");

        bool do_update = ShowClientMessage("Attenzione, l'atto sarà rimesso nello stato di 'In attesa di approvazione' " +
                            "e tutte le variazioni contenute che attualmente " +
                            "sono nello stato di 'approvata' retrocederanno nuovamente allo stato " +
                            " 'Inserita' ", "Conferma", System.Windows.Forms.MessageBoxButtons.OKCancel);

        if (!do_update)
            return;

        foreach (DataRow RR in DS.accountvarview.Select()) {
            if (RR["idaccountvarstatus"].ToString() == "5")
                RR["idaccountvarstatus"] = 4;
            CommFun.CheckEntityChildRowAdditions(RR, null);
        }
        DataRow Curr = DS.accountenactment.Rows[0];
        Curr["idenactmentstatus"] = 1;

        ClearRunningCommand();
        CommFun.DoMainCommand("mainsave");

    }

    void SendMails() {

        DataRow Curr = DS.accountenactment.Rows[0];
        foreach (DataRow V in DS.accountvarview.Rows) {
            SendMailVar(V);
        }


    }

    public override void AfterPost() {
        if (DoSendMail) {
            SendMails();
            DoSendMail = false;

        }
    }


    void SendMailVar(DataRow Var) {
        if (Var["idman"] == DBNull.Value)
            return;
        int idman = CfgFn.GetNoNullInt32(Var["idman"]);
        string filter = QHS.CmpEq("idman", idman);

        DataTable T = Conn.RUN_SELECT("manager", "*", null, filter, null, false);
        if (T.Rows[0]["wantswarn"].ToString().ToUpper() != "S")
            return;

        string mailto = T.Rows[0]["email"].ToString();
        if (mailto == "")
            return;

        int CurrentStatus = CfgFn.GetNoNullInt32(Var["idaccountvarstatus"]);
        string currstatustext = "";
        switch (CurrentStatus) {
        case 3:
            currstatustext = "Da Correggere";
            break;
        case 4:
            currstatustext = "Inserita";
            break;
        case 5:
            currstatustext = "Approvato";
            break;
        case 6:
            currstatustext = "Annullato";
            break;
        }



        SendMail SM = new SendMail();
        SM.UseSMTPLoginAsFromField = true;
        SM.Conn = Conn as DataAccess;

        SM.To = mailto;
        string MsgBody = "";
        MsgBody = "La variazione di budget numero " + Var["nvar"] + " relativa all'esercizio " + Var["yvar"] + "\r\n";
        MsgBody += "E' passata nello stato '" + currstatustext + "'.\r\n";

        MsgBody += " Dettagli:\r\n";

        DataTable Accountvar = Conn.RUN_SELECT("accountvar", "*", null, QHS.CmpKey(Var), null, false);
        DataRow V = Accountvar.Rows[0];

        if (Var["description"].ToString() != "")
            MsgBody += Var["description"].ToString() + "\r\n";
        if (V["annotation"].ToString() != "")
            MsgBody += V["annotation"].ToString() + "\r\n";
        MsgBody += "\r\n\r\n";
        DataTable Accountvardetailview = Conn.RUN_SELECT("accountvardetailview", "*", null, QHS.CmpKey(Var), null, false);
        foreach (DataRow RD in Accountvardetailview.Rows) {
            MsgBody += GetTextForAccountVarDetail(RD);
            if (RD["description"].ToString() != "")
                MsgBody += RD["description"].ToString() + "\r\n";
            if (RD["annotation"].ToString() != "")
                MsgBody += RD["annotation"].ToString() + "\r\n";
        }
        MsgBody += "\r\n";


        SM.Subject = "Notifica cambiamento di stato variazione di budget";
        SM.MessageBody = MsgBody;
        SM.Conn = Conn as DataAccess;

        if (!SM.Send()) {
            if (SM.ErrorMessage.Trim() != "")
                ShowClientMessage(SM.ErrorMessage, "Errore");
        }



    }

    public override void BeforePost() {
        if (DS.accountenactment.Rows.Count == 0)
            return;

        DataRow CurrRow = DS.accountenactment.Rows[0];
        if (CurrRow.RowState != DataRowState.Deleted) {
            int CurrentStatus = CfgFn.GetNoNullInt32(CurrRow["idenactmentstatus"]);
            int OriginalStatus;
            if (!PState.InsertMode)
                OriginalStatus = CfgFn.GetNoNullInt32(CurrRow["idenactmentstatus", DataRowVersion.Original]);
            else
                OriginalStatus = CurrentStatus;


            if (CurrentStatus != OriginalStatus && CurrentStatus != 1)
                DoSendMail = true;
            else
                DoSendMail = false;
        }
    }


    string GetTextForAccountVarDetail(DataRow R) {
        string S = "";
        S += "Voce Budget " + R["codeacc"].ToString() + " - " + R["account"].ToString() + "\r\n";
        S += "UPB " + R["codeupb"].ToString() + " - " + R["upb"].ToString() + "\r\n";
        S += "Importo variazione:" + CfgFn.GetNoNullDecimal(R["amount"]).ToString("c") + "\r\n";
        ;
        return S;
    }



    protected void btnAnnulla_Click(object sender, EventArgs e) {
        SetRunningCommand("do_annulla");
        bool do_update = ShowClientMessage("Attenzione l'atto sarà annullato " +
                            "e tutte le variazioni in esso contenute attualmente nello stato di 'Inserita'" +
                            "passeranno allo stato " +
                            " 'Annullata' ", "Conferma", System.Windows.Forms.MessageBoxButtons.OKCancel);

        if (!do_update)
            return;
        foreach (DataRow RR in DS.accountvarview.Select()) {
            if (RR["idaccountvarstatus"].ToString() == "4")
                RR["idaccountvarstatus"] = 6;
            CommFun.CheckEntityChildRowAdditions(RR, null);
        }
        DataRow Curr = DS.accountenactment.Rows[0];
        Curr["idenactmentstatus"] = 3;

        ClearRunningCommand();
        CommFun.DoMainCommand("mainsave");

    }

    void AbilitaVariazioni(bool enable) {
        btnCollega.Enabled = enable;
        btnScollega.Enabled = enable;
        btnModifica.Enabled = enable;
    }


}
