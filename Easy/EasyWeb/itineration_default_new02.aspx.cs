
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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;

public partial class itineration_default_new02 : MetaPage {
    vistaForm_itineration DS;
    bool DoSendMail {
        get {
            return (bool)PState.var["doSendMail"];
        }
        set {
            PState.var["doSendMail"] = value;
        }
    }
    bool DirectAuth {
        get {
            return (bool)PState.var["DirectAuth"];
        }
        set {
            PState.var["DirectAuth"] = value;
        }

    }

    QueryHelper QHS;
    CQueryHelper QHC;
    bool flagweb = false;
    DataTable RitenuteCalcolate;
    bool AnticipoIsReadOnly;
    string LastFilterPosGiuridica;
    CfgItineration MyCfg = new CfgItineration();
    string lastcalcolaritenuteparams = null;
    DataSet LastOutCalcolaRitenute = null;
    string btnInsertTappaTag, btnEditTappaTag, dgrTappeTag;
    bool IsManager = false;
    DateTime dataoggi;

    public void setdataoggi() {
        object oggi = Conn.DO_SYS_CMD("select getdate()");
        if (oggi == DBNull.Value)
            dataoggi = DateTime.Now;
        else
            dataoggi = (DateTime)oggi;
    }

    protected override void OnInit(EventArgs e) {

        base.OnInit(e);
    }

    public override DataSet GetDataSet() {
        return DS;
    }
    public override DataSet CreateNewDataSet() {
        return new vistaForm_itineration();
    }
    public override void SetDataSet(DataSet D) {
        DS = (vistaForm_itineration)D;
    }

    public void btnitinerationhistory_Click(object sender, EventArgs e) {
        CommFun.DoMainCommand("mainsetsearch");
        if (PState.IsEmpty) {
            CommFun.DoMainCommand("maindosearch.weblista.(iditinerationstatus='6')");
        }
    }

    void LockUnLockControls(bool Lock) {
        MetaPageMaster MP = Master as MetaPageMaster;

        Control ContentDiv = MP.GetContentDiv();
        EnableDisableControls(ContentDiv, Lock);
        return;
    }

    public override void AfterClear() {
        MetaData.SetDefault(DS.itineration, "iditinerationstatus", 1);
        ClearPosGiuridica();
        ImpostaTageFiltriUPB(DBNull.Value);
        cmbStatus.Enabled = true;

        txtCompartoCSA.Text = "";
        txtInquadrcsa.Text = "";
        txtRuoloCSA.Text = "";
        txtQualifica.Text = "";
        txtMatricola.Text = "";
        txtGruppoEstero.Text = "";
        txtDecorrClassStip.Text = "";
        txtClassStip.Text = "";
        chkWeb.Enabled = true;
        txtEsercmissione.Text = Conn.GetSys("esercizio").ToString();
        txtNummissione.ReadOnly = false;
        btnCambiaRuolo.Visible = false;
        DataColumn C = DS.itineration.Columns["nitineration"];
        RowChange.ClearAutoIncrement(C);
        RowChange.ClearCustomAutoIncrement(C);
        txtEsercmissione.ReadOnly = false;
        txtNummissione.HiddenContent = false;
        LockUnLockControls(false);
        btnStatus.Visible = false;
        EnableDisableControls(txtEsercmissione, false);
        EnableDisableControls(txtNummissione, false);
        EnableDisableControls(txtCompartoCSA, true);
        EnableDisableControls(txtInquadrcsa, true);
        EnableDisableControls(txtRuoloCSA, true);
        EnableDisableControls(txtQualifica, true);
        EnableDisableControls(txtMatricola, true);
        EnableDisableControls(txtGruppoEstero, true);
        EnableDisableControls(txtDecorrClassStip, true);
        EnableDisableControls(txtClassStip, true);

        EnableDisableControls(txtEurTotAPiedi, true);
        EnableDisableControls(txtEurTotMezzoProprio, true);
        EnableDisableControls(txtformulakm, true);

        EnableDisableControls(txtsaldoaccordato, true);
        EnableDisableControls(txtsaldorichiesto, true);
        EnableDisableControls(txtanticipoaccordato, true);
        EnableDisableControls(txtanticiporichiesto, true);
        EnableDisableControls(txtwebwarn, true);
        EnableDisableControls(btnitinerationhistory, false);

        EnableDisableControls(txtAnticipoErogato, true);
        EnableDisableControls(txtResiduoDaErogare, true);
        EnableDisableControls(txtTotaleErogato, true);

        EnableDisableControls(txtapplierannotation, false);

        cmbAuthModel.Enabled = true;

        AggiornaTotaliErogati();

        if (PState.var["idreg"] != null && Meta.edit_type != "myteamnew02") {
            txtIncaricato.ReadOnly = true;
            grpIncaricato.Tag = "";
            txtIncaricato.Text = PState.var["title"].ToString();
        }
        if (Meta.edit_type == "myteamnew02") {
            grpResponsabile.Enabled = false;
        }

        if (Meta.edit_type == "autolistnew02" && PState.var["listed"] == null) {
            PState.var["listed"] = "S";
            CommFun.DoMainCommand("maindosearch.weblista");

        }

        if (Meta.edit_type == "autoinsertnew02" && PState.var["inserted"] == null) {
            PState.var["inserted"] = "S";
            CommFun.DoMainCommand("maininsert");

        }
        dgrSpeseSaldo.Visible = true;
        GetData.CacheTable(DS.authmodel);
        btnStampaMissione.Enabled = false;
    }

    public override void BeforePost() {
        if (DS.itineration.Rows.Count == 0)
            return;

        DataRow CurrRow = DS.itineration.Rows[0];
        if (CurrRow.RowState == DataRowState.Deleted){
            foreach (var A in DS.itinerationattachment.Select()){
                if (A.RowState != DataRowState.Deleted)
                    A.Delete();
            }
        }

        if (CurrRow.RowState != DataRowState.Deleted) {
            int CurrentStatus = CfgFn.GetNoNullInt32(CurrRow["iditinerationstatus"]);
            int OriginalStatus;
            if (!PState.InsertMode)
                OriginalStatus = CfgFn.GetNoNullInt32(CurrRow["iditinerationstatus", DataRowVersion.Original]);
            else
                OriginalStatus = CurrentStatus;


            if (CurrentStatus != OriginalStatus && CurrentStatus == 2)
                DoSendMail = true;
            else
                DoSendMail = false;
        }
    }

    public override void AfterActivation(bool firsttime, bool formToLink) {
        if (formToLink) {
            DirectAuth = Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", Conn.GetSys("esercizio")),
                    "itineration_directauth").ToString().ToUpper() == "S";
        }
        //Conn.DeleteAllUnselectable(DS.authmodel);
    }
    public override void AfterPost() {
        if (DS.itineration.Rows.Count == 0)
            return;
        DataRow CurrRow = DS.itineration.Rows[0];
        string errormsg = "";
        if (DoSendMail) {
            errormsg = MissFun.WebSendMails(Conn as DataAccess, CurrRow);
            if (errormsg.Trim() != "")
                ShowClientMessage(errormsg, "Errore");
            DoSendMail = false;
        }
    }


    void ManageStatus() {
        // Status is:
        // 1:Bozza - 2:Richiesta - 3:Da Correggere - 4:Inserito - 5,8:In fase di autorizzazione - 6:Approvato - 7:Annullato
        DataRow CurrentRow = DS.itineration.Rows[0];

        int status = CfgFn.GetNoNullInt32(CurrentRow["iditinerationstatus"]);
        int authmodel = CfgFn.GetNoNullInt32(CurrentRow["idauthmodel"]);
        /*
        if (status >= 4)
        {
            Meta.CanSave = false;
            Meta.CanCancel = false;
        }
        else
        {
            Meta.CanSave = true;
            Meta.CanCancel = true;
        }
        */
        EnableDisableControls(btnitinerationhistory, true);
        switch (status) {
            case 1: //bozza. Da bozza può diventare una richiesta (attesa di autorizzazione se direct_auth)
                Meta.CanSave = true;
                if (!PState.InsertMode) {
                    if (DirectAuth) {
                        btnStatus.Text = "Ufficializza";
                    }
                    else {
                        btnStatus.Text = "Invia Richiesta";
                    }
                    btnStatus.Visible = true;
                    LockUnLockControls(false);
                    EnableDisableControls(txtEsercmissione, true);
                    EnableDisableControls(txtNummissione, true);
                    EnableDisableControls(txtCompartoCSA, true);
                    EnableDisableControls(txtInquadrcsa, true);
                    EnableDisableControls(txtRuoloCSA, true);
                    EnableDisableControls(txtQualifica, true);
                    EnableDisableControls(txtMatricola, true);
                    EnableDisableControls(txtGruppoEstero, true);
                    EnableDisableControls(txtDecorrClassStip, true);
                    EnableDisableControls(txtClassStip, true);

                    EnableDisableControls(txtEurTotAPiedi, true);
                    EnableDisableControls(txtEurTotMezzoProprio, true);
                    EnableDisableControls(txtformulakm, true);

                    EnableDisableControls(txtsaldoaccordato, true);
                    EnableDisableControls(txtsaldorichiesto, true);
                    EnableDisableControls(txtanticipoaccordato, true);
                    EnableDisableControls(txtanticiporichiesto, true);
                    EnableDisableControls(cmbStatus, true);
                    EnableDisableControls(txtwebwarn, true);
                    EnableDisableControls(chkWeb, true);
                    EnableDisableControls(btnitinerationhistory, true);
                    Meta.CanCancel = true;
                    btnStampaMissione.Visible = true;
                }

                break;
            case 2: //richiesta, può essere riportata a bozza 
                btnStatus.Text = "Modifica";
                LockUnLockControls(true);
                btnStampaMissione.Visible = true;
                btnStatus.Enabled = true;
                EnableDisableControls(btnEditAtt, false);
                //EnableDisableControls(btnitinerationhistory, false);
                btnStampaMissione.Enabled = true;
                btnStatus.Enabled = true;
                Meta.CanSave = false;// In fase di RICHIESTA non devo poter modificare nulla da Web
                Meta.CanCancel = true;

                break;
            case 3://da correggere, può passare a richiesta o Autorizzazione
                btnStatus.Visible = true;
                if (DirectAuth) {
                    btnStatus.Text = "Ufficializza";
                }
                else {
                    btnStatus.Text = "Invia Richiesta";
                }
                LockUnLockControls(false);
                btnStampaMissione.Visible = true;
                btnStampaMissione.Enabled = true;
                EnableDisableControls(txtEsercmissione, true);
                EnableDisableControls(txtNummissione, true);
                EnableDisableControls(txtCompartoCSA, true);
                EnableDisableControls(txtInquadrcsa, true);
                EnableDisableControls(txtRuoloCSA, true);
                EnableDisableControls(txtQualifica, true);
                EnableDisableControls(txtMatricola, true);
                EnableDisableControls(txtGruppoEstero, true);
                EnableDisableControls(txtDecorrClassStip, true);
                EnableDisableControls(txtClassStip, true);

                EnableDisableControls(txtEurTotAPiedi, true);
                EnableDisableControls(txtEurTotMezzoProprio, true);
                EnableDisableControls(txtformulakm, true);

                EnableDisableControls(txtsaldoaccordato, true);
                EnableDisableControls(txtsaldorichiesto, true);
                EnableDisableControls(txtanticipoaccordato, true);
                EnableDisableControls(txtanticiporichiesto, true);
                EnableDisableControls(cmbStatus, true);
                EnableDisableControls(txtwebwarn, true);
                EnableDisableControls(chkWeb, true);
                EnableDisableControls(btnitinerationhistory, true);

                btnStatus.Enabled = true;
                Meta.CanSave = true;
                Meta.CanCancel = true;
                break;
            case 5: //Da autorizzazione può passare a bozza solo se DirectAuth
            case 8:
                LockUnLockControls(true);
                btnStampaMissione.Visible = true;
                btnStampaMissione.Enabled = true;
                EnableDisableControls(btnStatus, false);
                EnableDisableControls(btnEditAtt, false);
                EnableDisableControls(txtadditionalannotation, true); //task 9451
                EnableDisableControls(HwTextBox2, true);
                EnableDisableControls(HwCheckClause, true);
                EnableDisableControls(txtMotivazione, true);
            Meta.CanSave = false;
                Meta.CanCancel = false;

                if (DirectAuth) {
                    btnStatus.Text = "Riconsidera";
                    btnStatus.Enabled = true;
                }
                else {
                    btnStatus.Visible = false;
                }

                break;

            case 4: //Inserita , è tutto bloccato 
                // Blocca tutto
                btnStatus.Visible = false;
                LockUnLockControls(true);
                btnStampaMissione.Visible = true;
                btnStampaMissione.Enabled = true;
                //btnStatus.Enabled = true;
                EnableDisableControls(btnStatus, false);
                EnableDisableControls(btnInsertTappa, true);
                EnableDisableControls(btnDelTappa, true);
                EnableDisableControls(btnEditTappa, false);
                EnableDisableControls(btnInsertSpesa, true);
                EnableDisableControls(btnEditSpesa, false);
                EnableDisableControls(btnInsertSpesaSaldo, true);
                EnableDisableControls(btnEditSpesaSaldo, false);
                EnableDisableControls(btnDeleteSpesaSaldo, true);
                EnableDisableControls(chkWeb, true);
                EnableDisableControls(btnEditAtt, false);
                //EnableDisableControls(btnitinerationhistory, false);

                btnStatus.Visible = false;
                Meta.CanSave = false;
                Meta.CanCancel = false;

                break;

            case 6: //approvata
                // Attenzione! In questo caso, oltre ad essere tutto bloccato
                btnStatus.Visible = false;
                LockUnLockControls(true);
                btnStampaMissione.Visible = true;
                btnStampaMissione.Enabled = true;
                //btnStatus.Enabled = true;
                EnableDisableControls(btnStatus, false);
                EnableDisableControls(btnEditAtt, false);
                //EnableDisableControls(btnitinerationhistory, false);

                Meta.CanSave = false;
                Meta.CanCancel = false;
                if (CheckSpeseConsuntivo()) {
                    btnStatus.Visible = true;
                    btnStatus.Text = "Rendiconta Spese";
                }
                else {
                    btnStatus.Visible = false;
                }
                break;

            default: //annullata o in fase di autorizzazione
                // Blocca tutto
                btnStatus.Visible = false;
                LockUnLockControls(true);
                btnStampaMissione.Visible = true;
                btnStampaMissione.Enabled = true;
                //btnStatus.Enabled = true;
                EnableDisableControls(btnStatus, false);
                EnableDisableControls(btnEditAtt, false);
                //EnableDisableControls(btnitinerationhistory, false);

                Meta.CanSave = false;
                Meta.CanCancel = false;
                btnStatus.Visible = false;
                break;
        }
        if (Meta.edit_type == "myteamnew02") {
            EnableDisableControls(txtapplierannotation, false);
        }
    }




    void EnableDisableControls(Control C, bool Lock) {

        if (typeof(WebControl).IsAssignableFrom(C.GetType())) {
            WebControl CC = C as WebControl;
            if (CC.ClientID == HwTextBox2.ClientID)
                return;
            if (// typeof(hwButton).IsAssignableFrom(CC.GetType()) || //typeof(hwTextBox).IsAssignableFrom(CC.GetType())||
                typeof(hwRadioButton).IsAssignableFrom(CC.GetType()) || typeof(hwDropDownList).IsAssignableFrom(CC.GetType())
                || typeof(hwCheckBox).IsAssignableFrom(CC.GetType()))
                CC.Enabled = !Lock;
            if (typeof(hwButton).IsAssignableFrom(CC.GetType()))
                ((hwButton)CC).Visible = !Lock;


            if (typeof(hwTextBox).IsAssignableFrom(CC.GetType()))
                ((hwTextBox)CC).ReadOnly = Lock;
        }
        if (C.HasControls()) {
            foreach (Control child in C.Controls)
                EnableDisableControls(child, Lock);
        }

    }


    public bool CheckSpeseConsuntivo() {
        DataRow Curr = DS.itineration.Rows[0];
        if (Curr == null)
            return false;

        // cambia il criterio per serverdate
        //DateTime ServerDate = DateTime.Now;

        DateTime EndDate = (DateTime)Curr["stop"];
        bool IsWeb = (Curr["flagweb"].ToString().ToLower() == "s") ? true : false;
        int numSpeseConsuntivo = DS.itinerationrefund_balance.Rows.Count;



        if (dataoggi >= EndDate && numSpeseConsuntivo == 0 && IsWeb)
            return true;
        else
            return false;

    }


    public override void AfterRowSelect(DataTable T, DataRow R) {
        if (T.TableName == "registry") {
            ImpostaPosGiuridica(false); // ClearPosGiuridica();
        }
        if (T.TableName == "manager") {
            ImpostaTageFiltriUPB(DBNull.Value);
        }

        if (T.TableName == "legalstatuscontract") {
            DataTable SelClass;
            QHS = Conn.GetQueryHelper();
            DataRow Curr = DS.itineration.Rows[0];

            object datainizio = Curr[MissFun.CampoDataPerPosGiuridica];
            object datafine = Curr["stop"];
            object codicecreddeb = Curr["idreg"];

            DataRow RcurrPosGiuridica = R;
            SelClass = Conn.RUN_SELECT("legalstatuscontract",
                        "idposition, incomeclass, incomeclassvalidity, maxincomeclass,idregistrylegalstatus,csa_compartment,csa_role, csa_class",
                        null, QHS.AppAnd(QHS.CmpEq("idreg", codicecreddeb), QHS.CmpEq("idregistrylegalstatus", RcurrPosGiuridica["idregistrylegalstatus"])), null, false);

            DataRow RowClass = SelClass.Rows[0];

            txtRuoloCSA.Text = RowClass["csa_role"].ToString();
            txtCompartoCSA.Text = RowClass["csa_compartment"].ToString();
            txtInquadrcsa.Text = RowClass["csa_class"].ToString();
            Curr["idregistrylegalstatus"] = RowClass["idregistrylegalstatus"];

            object matricula = Meta.Conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg", codicecreddeb), "extmatricula");

            int incomeclass = CfgFn.GetNoNullInt32(RowClass["incomeclass"]);
            //////txtClassStip.Text = incomeclass.ToString();
            setPosizioneGiuridica(RowClass["idposition"]);
            //            MyCfg.idposition = RowClass["idposition"];
            MyCfg.matricula = matricula;
            MyCfg.incomeclass = incomeclass;
            MyCfg.incomeclassvalidity = RowClass["incomeclassvalidity"];

            object codicequalifica = RowClass["idposition"];

            DataRow[] Q = DS.position.Select(QHC.CmpEq("idposition", codicequalifica));
            if (Q.Length > 0) {
                txtQualifica.Text = Q[0]["description"].ToString();
            }


            txtDecorrClassStip.Text = HelpForm.StringValue(MyCfg.incomeclassvalidity, "x.y.d");
            txtMatricola.Text = MyCfg.matricula.ToString();

            //Classe attuale
            int classe, maxclassestip;
            classe = CfgFn.GetNoNullInt32(RowClass["incomeclass"]);
            maxclassestip = CfgFn.GetNoNullInt32(RowClass["maxincomeclass"]);
            if (classe <= maxclassestip) {
                txtClassStip.Text = classe.ToString();
                MyCfg.incomeclass = classe;
            }
            else {
                txtClassStip.Text = maxclassestip.ToString();
                MyCfg.incomeclass = maxclassestip;
            }


            object idforeigngrouprule = Conn.DO_READ_VALUE("foreigngrouprule",
                QHS.CmpLe("start", Curr[MissFun.CampoDataPerGruppoEstero]),
                "max(idforeigngrouprule)");
            //imposta il gruppo estero
            string filterGE;
            filterGE = QHS.AppAnd(QHS.CmpEq("idforeigngrouprule", idforeigngrouprule),
                            QHS.CmpEq("idposition", MyCfg.idposition),
                            "(" + QHS.quote(MyCfg.incomeclass) + " between minincomeclass and maxincomeclass)");


            DataTable DettGruppoEstero = Conn.RUN_SELECT("foreigngroupruledetail", "foreigngroupnumber",
                null, filterGE, "1", false);
            if (DettGruppoEstero.Rows.Count == 0) {
                MyCfg.foreigngroupnumber = DBNull.Value;
                txtGruppoEstero.Text = "";
                ShowClientMessage("I dati relativi al gruppo estero sono incompleti o mancanti", "Avviso");
                SetExtraParameterForDetails();
                return;
            }
            MyCfg.foreigngroupnumber = CfgFn.GetNoNullInt32(DettGruppoEstero.Rows[0]["foreigngroupnumber"]);
            txtGruppoEstero.Text = MyCfg.foreigngroupnumber.ToString();
            SetExtraParameterForDetails();

            return;
        }

        /*
        if (T.TableName == "registry")
        {
            ImpostaPosGiuridica(true);

        }
        */

        if (T.TableName == "authmodel") {
            if (PState.IsEmpty)
                return;
            if (!CommFun.DrawStateIsDone)
                return;
            //DataRow DR = DS.itineration.Rows[0];            
            int idauthmodel = 0;
            if (R != null)
                idauthmodel = CfgFn.GetNoNullInt32(R["idauthmodel"]);
            if (CanChangeAuthModel())
                ChangeItinerationAuthAgency(idauthmodel);
        }

    }


    public void ChangeItinerationAuthAgency(int idauthmodel) {

        if (DS.itineration.Rows.Count == 0)
            return;
        if (idauthmodel == 0) {
            DS.itinerationauthagency.RejectChanges();
            foreach (DataRow Existing in DS.itinerationauthagency.Select()) {
                Existing.Delete();
            }
            return;
        }
        QHS = Conn.GetQueryHelper();

        string query = " select AA.idauthagency as idauthagency, ";
        query += " A.title as title, A.description as description, A.priority as priority " +
                    " from authmodelauthagency AA inner join authagency A";
        query += " on (AA.idauthagency=A.idauthagency) ";
        query += " where " + QHS.CmpEq("AA.idauthmodel", idauthmodel) + " order by A.priority asc ";


        DataTable AuthAgencies = Conn.SQLRunner(query);

        Meta.SetDefaults(DS.itineration);
        DataRow ParentRow = DS.itineration.Rows[0];
        MetaData MD = appState.Dispatcher.Get("itinerationauthagengy");

        DS.itinerationauthagency.RejectChanges();

        foreach (DataRow Existing in DS.itinerationauthagency.Select()) {
            object codiceold = Existing["idauthagency"];
            if (AuthAgencies == null || AuthAgencies.Select(QHC.CmpEq("idauthagency", codiceold)).Length == 0) {
                Existing.Delete();
            }
        }
        if (AuthAgencies == null || AuthAgencies.Rows.Count == 0)
            return;

        foreach (DataRow Row in AuthAgencies.Rows) {
            DataRow[] Found = DS.itinerationauthagency.Select(QHC.CmpEq("idauthagency", Row["idauthagency"]));
            DataRow MissAut;
            if (Found.Length == 0) {
                MD.SetDefaults(DS.itinerationauthagency);
                DS.itinerationauthagency.Columns["idauthagency"].DefaultValue = Row["idauthagency"];
                MissAut = MD.Get_New_Row(ParentRow, DS.itinerationauthagency);
                DS.itinerationauthagency.Columns["idauthagency"].DefaultValue = DBNull.Value;
                //MissAut = MD.Get_New_Row(ParentRow, DS.itinerationauthagency);
                //MissAut["idauthagency"] = Row["idauthagency"];
            }
            else {
                MissAut = Found[0];
            }
            MissAut["flagstatus"] = "D";
            MissAut["!status"] = "Da Definire";
            MissAut["!title"] = Row["title"];
            MissAut["!priority"] = Row["priority"];
            MissAut["!description"] = Row["description"];
        }

    }

    public bool CanChangeAuthModel() {
        bool CanChange = true;
        foreach (DataRow DR in DS.itinerationauthagency.Rows) {
            if (DR.RowState != DataRowState.Deleted && (DR["flagstatus"].ToString().Trim() == "S" || DR["flagstatus"].ToString().Trim() == "N")) {
                CanChange = false;
                break;
            }
        }
        return CanChange;
    }

    public void Register_Client_Events() {
        string km_visibili = configManager.getCfg("km_visibili");
        if (km_visibili == "N") return;
        txtEurTotAPiedi.FunctionName = "CalcTotAPiedi();";
        txtEurTotAPiedi.DependsOn(txtEurKmAPiedi);
        txtEurTotAPiedi.DependsOn(txtKmAPiedi);
        txtEurTotMezzoProprio.FunctionName = "CalcTotMezzoProprio();";
        txtEurTotMezzoProprio.DependsOn(txtEurKmMezzoProprio);
        txtEurTotMezzoProprio.DependsOn(txtKmMezzoProprio);
    }

    public void txtDataInizio_LeaveTextBoxHandler(object sender, EventArgs e) {
        if (txtDataFine.Text != "") {
            //forza l'immissione di una data valida
            DateTime datafine;
            try {
                datafine = Convert.ToDateTime(txtDataFine.Text);
            }
            catch {
                ShowClientMessage("La data inserita non era valida", "Avviso");
                txtDataFine.Focus();
                return;
            }

        }
        GeneraSelect(sender);

        setDateInizioFineSpesa();
        CheckAnticipiReadOnly();
        EnableDisableRefund();

        return;
    }

    void EnableDisableRefund() {
        if (PState.IsEmpty)
            return;
        DataRow Curr = DS.itineration.Rows[0];
        int currentstatus = CfgFn.GetNoNullInt32(Curr["iditinerationstatus"]);
        //Gestione spese anticipo

        bool faseanticipo = getFaseAnticipoMissione();
        bool dativalidi = DataMissioneValida() && cmbAuthModel.SelectedIndex > 0;

        //in bozza ed in "da rivedere" è possibile inserire le spese (rendiconto o anticipo a seconda dello stato)
        if (currentstatus == 1 || currentstatus == 3) {
            btnInsertSpesa.Visible = faseanticipo && dativalidi;
            btnEditSpesa.Visible = dativalidi;
            btnDelSpesa.Visible = faseanticipo && dativalidi;

            btnInsertSpesaSaldo.Visible = (!faseanticipo) && dativalidi;
            btnEditSpesaSaldo.Visible = (!faseanticipo) && dativalidi;
            btnDeleteSpesaSaldo.Visible = (!faseanticipo) && dativalidi;
            dgrSpeseSaldo.Visible = (!faseanticipo) && dativalidi;
        }
        else {
            btnInsertSpesa.Visible = false;
            btnEditSpesa.Visible = dativalidi;
            btnDelSpesa.Visible = false;

            btnInsertSpesaSaldo.Visible = false;
            btnEditSpesaSaldo.Visible = (!faseanticipo) && dativalidi;
            btnEditSpesaSaldo.Enabled = (!faseanticipo) && dativalidi;
            btnDeleteSpesaSaldo.Visible = false;
            dgrSpeseSaldo.Visible = (!faseanticipo) && dativalidi;
        }
        if (faseanticipo || (dativalidi == false)) {
            DisableSpeseSaldo();
        }


    }


    public void txtDataFine_LeaveTextBoxHandler(object sender, EventArgs e) {

        if (txtDataFine.Text != "") {
            //forza l'immissione di una data valida
            DateTime datafine;
            try {
                datafine = Convert.ToDateTime(txtDataFine.Text);
            }
            catch {
                ShowClientMessage("La data inserita non era valida", "Avviso");
                txtDataFine.Focus();
                return;
            }

        }
        GeneraSelect(sender);


        setDateInizioFineSpesa();
        CheckAnticipiReadOnly();
        EnableDisableRefund();
        return;
    }



    public override void AfterLink(bool firsttime, bool formToLink) {

        Meta.Name = "Missione";
        if (firsttime)
            DoSendMail = false;

        if (formToLink) {
            cmbStatus.DataSource = DS.itinerationstatus;
            cmbStatus.DataTextField = "description";
            cmbStatus.DataValueField = "iditinerationstatus";

            cmbAuthModel.DataSource = DS.authmodel;
            cmbAuthModel.DataTextField = "title";
            cmbAuthModel.DataValueField = "idauthmodel";
        }

        txtDataInizio.LeaveTextBoxHandler += txtDataInizio_LeaveTextBoxHandler;
        txtDataFine.LeaveTextBoxHandler += txtDataFine_LeaveTextBoxHandler;

        // ricordarsi di avvalorare idser

        Meta.CanInsertCopy = false;

        Meta.DefaultListType = "weblista";
        SearchTable = "itinerationview";

        Register_Client_Events();
        if (PState.InsertMode || PState.EditMode)
            AggiornaSoloInformazioni();


        GetData.CacheTable(DS.position);

        QHC = new CQueryHelper();
        QHS = Conn.GetQueryHelper();

        GetData.CacheTable(DS.tax);

        HelpForm.SetDenyNull(DS.itineration.Columns["active"], true);
        HelpForm.SetDenyNull(DS.itineration.Columns["completed"], true);

        HelpForm.SetFormatForColumn(DS.itinerationlap.Columns["stoptime"], "g");
        HelpForm.SetFormatForColumn(DS.itinerationlap.Columns["starttime"], "g");
        string currsymbol = System.Globalization.NumberFormatInfo.CurrentInfo.CurrencySymbol;

        string filteresercizio = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
        GetData.CacheTable(DS.config, filteresercizio, null, false);

        string filterEpOperationSF = QHS.CmpEq("idepoperation", "missioni");
        string filterEpOperationEP = QHS.CmpEq("idepoperation", "missioni");

        DS.accmotiveapplied.ExtendedProperties[ExtraParams] = filterEpOperationEP;
        GetData.SetStaticFilter(DS.accmotiveapplied, filterEpOperationSF);
        PanelEP.Visible = false;
         /*
         string filterweb = QHS.CmpEq("flagweb", "S");
         GetData.SetStaticFilter(DS.itinerationview, filterweb);
         */

         string filterEpOperationDeb = QHS.CmpEq("idepoperation", "missioni_deb");

        SetMainVisibility();

        DS.accmotiveapplied_debit.ExtendedProperties[ExtraParams] = filterEpOperationDeb;
        DS.accmotiveapplied_crg.ExtendedProperties[ExtraParams] = filterEpOperationDeb;
        GetData.SetStaticFilter(DS.accmotiveapplied_debit, filterEpOperationDeb);
        GetData.SetStaticFilter(DS.accmotiveapplied_crg, filterEpOperationDeb);
        DataAccess.SetTableForReading(DS.accmotiveapplied_crg, "accmotiveapplied");
        DataAccess.SetTableForReading(DS.accmotiveapplied_debit, "accmotiveapplied");


        DataAccess.SetTableForReading(DS.sorting1, "sorting");
        DataAccess.SetTableForReading(DS.sorting2, "sorting");
        DataAccess.SetTableForReading(DS.sorting3, "sorting");

        DataTable tExpSetup = Conn.RUN_SELECT("config", "*", null, filteresercizio, null, null, true);
        if ((tExpSetup != null) && (tExpSetup.Rows.Count > 0)) {
            DataRow R = tExpSetup.Rows[0];
            object idsorkind1 = R["idsortingkind1"];
            object idsorkind2 = R["idsortingkind2"];
            object idsorkind3 = R["idsortingkind3"];
            SetGBoxClass(1, idsorkind1);
            SetGBoxClass(2, idsorkind2);
            SetGBoxClass(3, idsorkind3);
            if (idsorkind1 == DBNull.Value && idsorkind2 == DBNull.Value && idsorkind3 == DBNull.Value) {
                PanelAnalitico.Visible = false;// tabControl2.TabPages.Remove(tabAnalitico);
            }
        }
        
        DateTime defaultauthdate = DateTime.Now;

        DataTable webconfig = Conn.RUN_SELECT("web_config", "*", null, null, null, false);
        DataRow rwebconf = webconfig.Rows[0];
        bool showitinerationlap = (rwebconf["showitinerationlap"].ToString().ToUpper() == "S");
        bool showinerationep = (rwebconf["showinerationep"].ToString().ToUpper() == "S");
        bool askitinerationclause = (rwebconf["askitinerationclause"].ToString().ToUpper() == "S");
        string itinerationclause = (rwebconf["itinerationclause"].ToString());

        if (showitinerationlap == false) { 
            //DisableTappe();

        }

        if (showinerationep == false) {
            DisableEP();
        }

        if (askitinerationclause == false) {
            HideReqClause();
            PanelClausola.Visible = false;
            HwTextBox2.Visible = false;
            HwCheckClause.Visible = false;
        }
        else {
            HwTextBox2.Text = itinerationclause;
        }


        MetaData.SetDefault(DS.itineration, "iditinerationstatus", 1);
        MetaData.SetDefault(DS.itineration, "completed", "N");
        MetaData.SetDefault(DS.itineration, "flagweb", "S");
        MetaData.SetDefault(DS.itineration, "authorizationdate", defaultauthdate);
        DS.itinerationstatus.ExtendedProperties["sort_by"] = "iditinerationstatus";
        string filterWeb = QHS.CmpEq("flagweb", "S");
        int count = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("itineration", filterWeb, "count(*)"));
        if (count == 0) {
            //gboxAction.Visible = false;
            //MakeSpaceFrom(gboxAction);
        }
        else
            flagweb = true;

        DataAccess.SetTableForReading(DS.itinerationrefund_advance, "itinerationrefund");
        DataAccess.SetTableForReading(DS.itinerationrefund_balance, "itinerationrefund");
        DataAccess.SetTableForReading(DS.itinerationrefundkind_advance, "itinerationrefundkind");
        DataAccess.SetTableForReading(DS.itinerationrefundkind_balance, "itinerationrefundkind");
        QueryCreator.SetTableForPosting(DS.itinerationrefund_advance, "itinerationrefund");
        QueryCreator.SetTableForPosting(DS.itinerationrefund_balance, "itinerationrefund");
        GetData.SetStaticFilter(DS.itinerationrefund_advance, QHS.CmpEq("flagadvancebalance", "A"));
        GetData.SetStaticFilter(DS.itinerationrefund_balance, QHS.CmpEq("flagadvancebalance", "S"));

        setdataoggi();
        object idreg = PState.var["idreg"];
        string cf = CF_User();
        if (cf != null && idreg == null) {
            DataTable T = Conn.RUN_SELECT("registry", "*", null,
                QHS.AppAnd(new string[]{QHS.CmpEq("cf", cf), QHS.CmpEq("active","S"), //QHS.CmpEq("human","S"),
                      " (idreg IN(SELECT idreg FROM registrylegalstatus WHERE idposition IS NOT NULL))  " }),
                null, true);
            if (T.Rows.Count == 1) {
                PState.var["idreg"] = idreg = T.Rows[0]["idreg"];
                PState.var["title"] = T.Rows[0]["title"];
                MetaData.SetDefault(DS.itineration, "idreg", idreg);
            }

        }

        object hidecsa = PState.var["hidecsa"];
        if (hidecsa == null) {
            int ncsa = Conn.RUN_SELECT_COUNT("legalstatuscontract", QHS.IsNotNull("csa_role"), false);
            hidecsa = (ncsa == 0) ? "S" : "N";
            PState.var["hidecsa"] = hidecsa;
        }
        if (hidecsa.ToString() == "S") {
            PanelCSA.Visible = false;
            //groupBox6.Visible = false;//sostituito il grp col panel
            HideCsa(); 
        }

        IsManager = (Session["CodiceResponsabile"] != null ? true : false);
        int idman = 0;
        idman = CfgFn.GetNoNullInt32(Session["CodiceResponsabile"]);

        if (IsManager) {
            if (Session["CodiceResponsabile"] != null) {
                DS.itineration.Columns["idman"].DefaultValue = idman;
                //cmbresponsabile.SelectedValue = idman.ToString();
                //EnableDisableControls(cmbresponsabile, true);
            }
        }
        HelpForm.SetDenyNull(DS.itineration.Columns["clause_accepted"], true);
        HelpForm.SetDenyNull(DS.itineration.Columns["clause_accepted"], true);

        GetData.MarkSkipSecurity(DS.manager);
        btnStampaMissione.Enabled = false;
        btnStatus.Tag = "do_command.chstatus";
    }

    public override void DoCommand(string command) {
        if (command == "chstatus")
            DoChangeStatus();
        if (command == "history") {
            btnitinerationhistory_Click(null, null);
        }
        if (command == "stampamissione"){
            HwButtonStampaMissione_Click();
        }
    }
    private string ReportName = "missione_prospetto_calcolo";

    protected void HwButtonStampaMissione_Click(){
        DataRow curr = DS.itineration.First();
        if (curr == null){
            return;
        }
        int yitineration = CfgFn.GetNoNullInt32(curr["yitineration"]);
        int numberbegin = CfgFn.GetNoNullInt32(curr["nitineration"]);
        int numberend = CfgFn.GetNoNullInt32(curr["nitineration"]);
        string pdfFileName, errmess;
        bool res = stampaMissione(yitineration, numberbegin, numberend, out pdfFileName, out errmess);
        if (!res){
            ShowClientMessage(errmess, "Attenzione", System.Windows.Forms.MessageBoxButtons.OK);
            return;
        }

        var f = "window.open('" + pdfFileName + "');";
        if (!Page.ClientScript.IsClientScriptBlockRegistered(typeof(Page), "openwin"))
            Page.ClientScript.RegisterClientScriptBlock(
                typeof(Page), "openwin", f, true);
    }

    private bool stampaMissione(int yitineration, int numberbegin, int numberend, out string pdfFileName, out string errmess){
        errmess = "";
        pdfFileName = "";

        DataTable myPrymaryTable = createStampaMissioneTable();
        myPrymaryTable.Rows[0]["reportname"] = ReportName;
        myPrymaryTable.Rows[0]["ayear"] = Conn.GetSys("esercizio");
        myPrymaryTable.Rows[0]["yitineration"] = yitineration;
        myPrymaryTable.Rows[0]["numberbegin"] = numberbegin;
        myPrymaryTable.Rows[0]["numberend"] = numberend;
        myPrymaryTable.Rows[0]["idsor01"] = DBNull.Value;
        myPrymaryTable.Rows[0]["idsor02"] = DBNull.Value;
        myPrymaryTable.Rows[0]["idsor03"] = DBNull.Value;
        myPrymaryTable.Rows[0]["idsor04"] = DBNull.Value;
        myPrymaryTable.Rows[0]["idsor05"] = DBNull.Value;

        string filter = QHS.CmpEq("reportname", ReportName);

        DataTable Report = Conn.RUN_SELECT("report", "*", null, filter, null, false);

        if (Report == null)
        {
            errmess = "Report: '" + ReportName + "' non trovato.";
            return false;
        }

        var rep = Report._First();
        var par = myPrymaryTable.Rows[0];

        ReportDocument myRptDoc = Easy_DataAccess.GetReport(Conn as Easy_DataAccess, rep, par, out errmess);
        if (myRptDoc == null)
        {
            if (errmess == null || errmess == "") errmess = "Impossibile trovare il report";
            return false;
        }

        string FilePath = MapPath("ReportPDF");
        if (!FilePath.EndsWith("\\")) FilePath += "\\";

        var tempfilename = "missione-" + Guid.NewGuid() + ".pdf";
        pdfFileName = @"ReportPDF/" + tempfilename;
        string error;
        bool retExp = exportToPdf(myRptDoc, tempfilename, FilePath, out error);
        if (!retExp) errmess = "Impossibile esportare in pdf: " + tempfilename + " in " + FilePath + " (" + error + ")";
        return retExp;
    }

    private bool exportToPdf(ReportDocument rd, string fileName, string relativePath, out string error){
        error = "";
        var tempfilename = relativePath + fileName;

        rd.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
        rd.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;

        DiskFileDestinationOptions diskOpts = new DiskFileDestinationOptions { DiskFileName = tempfilename };
        rd.ExportOptions.DestinationOptions = diskOpts;

        // Export the report
        try{
            rd.Export();
            bool existfile = File.Exists(tempfilename);
            if (!existfile) error = "export fallito";
            return existfile;
        }
        catch (Exception e){
            if (!e.ToString().Contains("0x8000030E")){
                error =
                    "E' necessario disinstallare l'aggiornamento di windows KB3102429 per poter effettuare la stampa. - " +
                    e.Message;
                return false;
            }
            error = e.Message;
            return false;
        }
    }

    DataTable createStampaMissioneTable() {
        var myPrimaryTable = new DataTable("export_itineration");
        //Create a dummy primary key
        var dcpk = new DataColumn("DummyPrimaryKeyField", typeof(int)) { DefaultValue = 1 };
        myPrimaryTable.Columns.Add(dcpk);
        myPrimaryTable.PrimaryKey = new[] { dcpk };

        DataColumn column;
        myPrimaryTable.Columns.Add(new DataColumn("reportname", typeof(string)));
        myPrimaryTable.Columns.Add(new DataColumn("ayear", typeof(int)));
        myPrimaryTable.Columns.Add(new DataColumn("yitineration", typeof(int)));
        myPrimaryTable.Columns.Add(new DataColumn("numberbegin", typeof(int)));
        myPrimaryTable.Columns.Add(new DataColumn("numberend", typeof(int)));

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
    void HideCsa() {
        string script = "$(function(){\r\n" +
          "$(\".csahid\").each(function(index){\r\n" +
          "    $(this).css(\"display\",\"none\");\r\n" +
          " });\r\n" +

          "}\r\n" +
          ");\r\n";
        metaMaster.RegisterScript("HideCsaCtrls", script, false);

    }

    void DisableEP() {

        string script = "$(function(){\r\n" +
          "$(\".ephid\").each(function(index){\r\n" +
          "    $(this).css(\"display\",\"none\");\r\n" +
          " });\r\n" +

          "}\r\n" +
          ");\r\n";
           
        metaMaster.RegisterScript("DisableEP", script, false);


    }
    void DisableSpeseSaldo() {

        string script = "$(function(){\r\n" +
            //"$('#Tab1Folder7').attr('display','none');\r\n" +
            "$(\".hid2\").each(function(index){\r\n" +
            "    $(this).css(\"display\",\"none\");\r\n" +
            " });\r\n" +

            "}\r\n" +
            ");\r\n";
        metaMaster.RegisterScript("DisableSpeseSaldo", script, false);

    }

    void HideReqClause() {
        string script = "$(function(){\r\n" +
            //"$('#Tab1Folder7').attr('display','none');\r\n" +
            "$(\".hid3\").each(function(index){\r\n" +
            "    $(this).css(\"display\",\"none\");\r\n" +
            " });\r\n" +

            "}\r\n" +
            ");\r\n";
        metaMaster.RegisterScript("HideReqClause", script, false);

    }

    void DisableTappe() {
        //btnInsertTappa.Visible = false;
        //btnDelTappa.Visible = false;
        //btnEditTappa.Visible = false;
        //dgrTappe.Visible = false;
        PanelTappe.Visible = false;      //gboxlblgrpTappe.Visible = false;
        string script = "$(function(){\r\n" +
            "$('#titleTappe').html('Dettaglio Spese');\r\n" +
            //"$(\".sup1\").each(function(index){\r\n" +
            //"    mytop= $(this).position().top-170;\r\n" +
            //"    myleft= $(this).position().left;\r\n" +
            //"    $(this).css({left: myleft,top:mytop});\r\n" +
            //" });\r\n" +

            //"$(\".sup2\").each(function(index){\r\n" +
            //"    mytop= $(this).position().top+170;\r\n" +
            //"    myleft= $(this).position().left;\r\n" +
            //"    $(this).css({left: myleft,top:mytop});\r\n" +
            //" });\r\n" +

            //"$(\".he1\").each(function(index){\r\n" +
            //"    myheight= $(this).height()+170;\r\n" +
            //"    $(this).height(myheight);\r\n" +
            //" });\r\n" +


            "$(\".hid1\").each(function(index){\r\n" +
            "    $(this).css(\"display\",\"none\");\r\n" +
            " });\r\n" +


            "}\r\n" +
            ");\r\n";
        metaMaster.RegisterScript("DisableTappe", script, false);



        //Tab1Folder2
    }

    string CF_User() {
        object hasVirtual = Conn.GetUsr("HasVirtualUser");
        if (hasVirtual == null)
            return null;
        if (hasVirtual.ToString().ToUpper() != "S")
            return null;
        object CF = Conn.GetUsr("cf");
        if (CF == DBNull.Value)
            return null;
        return CF.ToString();
    }


    private void ImpostaPosGiuridica(bool changerole) {
        if (PState.IsEmpty)
            return;
        DataRow Curr = DS.itineration.Rows[0];

        string filter;
        //string sorting;

        object datainizio = Curr[MissFun.CampoDataPerPosGiuridica];
        object datafine = Curr["stop"];
        object codicecreddeb = Curr["idreg"];

        if ((datainizio == DBNull.Value) || (((DateTime)datainizio) == QueryCreator.EmptyDate())) {
            ClearPosGiuridica();
            return;
        }
        if ((datafine == DBNull.Value) || (((DateTime)datafine) == QueryCreator.EmptyDate())) {
            ClearPosGiuridica();
            return;
        }

        if ((codicecreddeb == DBNull.Value) || (((int)codicecreddeb) <= 0)) {
            ClearPosGiuridica();
            return;
        }


        string strdate = QueryCreator.quotedstrvalue((DateTime)datainizio, true);
        string strdatefine = QueryCreator.quotedstrvalue((DateTime)datafine, true);

        filter = QHS.AppAnd(QHS.CmpEq("idreg", codicecreddeb), QHS.CmpLe("start", datainizio), QHS.NullOrGe("stop", datafine));

        if ((LastFilterPosGiuridica == filter) && (!changerole))
            return;

        //sorting = "start DESC";

        //DataTable SelClass = Meta.Conn.RUN_SELECT("legalstatuscontract", 
        //    "idposition, incomeclass, incomeclassvalidity, maxincomeclass,idregistrylegalstatus", // , idwor
        //    sorting, filter, "1", false);

        int NposGiuridiche = Conn.RUN_SELECT_COUNT("legalstatuscontract", filter, false);

        if (NposGiuridiche == 0) {
            ClearPosGiuridica();
            LastFilterPosGiuridica = filter;
            //btnCambiaRuolo.Visible = false;
            btnCambiaRuolo.Visible = false;
            if (LastFilterPosGiuridica != filter) {
                //MessageBox.Show("I dati relativi alla posizione giuridica dell'incaricato sono incompleti o mancanti.", "Avviso");
                ShowClientMessage("I dati relativi alla posizione giuridica dell'incaricato sono incompleti o mancanti.", "Avviso");
            }
            return;
        }
        LastFilterPosGiuridica = filter;

        DataRow RcurrPosGiuridica = null;
        object CurrPosGiuridica = null;
        DataTable SelClass = null;
        if (NposGiuridiche > 1) {

            btnCambiaRuolo.Visible = true;
            CommFun.DoMainCommand("choose.legalstatuscontract.anagrafica." + filter);
            return;
        }


        if (NposGiuridiche == 1) {
            SelClass = Conn.RUN_SELECT("legalstatuscontract",
                        "idposition, incomeclass, incomeclassvalidity, maxincomeclass,idregistrylegalstatus,csa_compartment,csa_role, csa_class",
                        null, filter, null, false);
            btnCambiaRuolo.Visible = false;
        }
        DataRow RowClass = SelClass.Rows[0];

        txtRuoloCSA.Text = RowClass["csa_role"].ToString();
        txtCompartoCSA.Text = RowClass["csa_compartment"].ToString();
        txtInquadrcsa.Text = RowClass["csa_class"].ToString();
        Curr["idregistrylegalstatus"] = RowClass["idregistrylegalstatus"];


        //Aboliamo virtualmente il flagquotaesente mettendolo sempre a S
        object currflagquotaesente = "S";



        //FiltraComboPrestazioneInBaseANiente(false);
        object matricula = Conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg", codicecreddeb), "extmatricula");

        int incomeclass = CfgFn.GetNoNullInt32(RowClass["incomeclass"]);
        txtClassStip.Text = incomeclass.ToString();
        setPosizioneGiuridica(RowClass["idposition"]);
        //            MyCfg.idposition = RowClass["idposition"];
        MyCfg.matricula = matricula;
        MyCfg.incomeclass = incomeclass;
        MyCfg.incomeclassvalidity = RowClass["incomeclassvalidity"];

        object codicequalifica = RowClass["idposition"];

        DataRow[] Q = DS.position.Select(QHC.CmpEq("idposition", codicequalifica));
        if (Q.Length > 0) {
            txtQualifica.Text = Q[0]["description"].ToString();
        }


        txtDecorrClassStip.Text = HelpForm.StringValue(MyCfg.incomeclassvalidity, "x.y.d");
        txtMatricola.Text = MyCfg.matricula.ToString();

        //Classe attuale
        int classe, maxclassestip;
        classe = CfgFn.GetNoNullInt32(RowClass["incomeclass"]);
        maxclassestip = CfgFn.GetNoNullInt32(RowClass["maxincomeclass"]);
        if (classe <= maxclassestip) {
            txtClassStip.Text = classe.ToString();
            MyCfg.incomeclass = classe;
        }
        else {
            txtClassStip.Text = maxclassestip.ToString();
            MyCfg.incomeclass = maxclassestip;
        }


        object idforeigngrouprule = Conn.DO_READ_VALUE("foreigngrouprule",
            QHS.CmpLe("start", Curr[MissFun.CampoDataPerGruppoEstero]),
            "max(idforeigngrouprule)");
        //imposta il gruppo estero
        string filterGE;
        filterGE = QHS.AppAnd(QHS.CmpEq("idforeigngrouprule", idforeigngrouprule),
                        QHS.CmpEq("idposition", MyCfg.idposition),
                        "(" + QHS.quote(MyCfg.incomeclass) + " between minincomeclass and maxincomeclass)");


        DataTable DettGruppoEstero = Conn.RUN_SELECT("foreigngroupruledetail", "foreigngroupnumber",
            null, filterGE, "1", false);
        if (DettGruppoEstero.Rows.Count == 0) {
            MyCfg.foreigngroupnumber = DBNull.Value;
            txtGruppoEstero.Text = "";
            ShowClientMessage("I dati relativi al gruppo estero sono incompleti o mancanti", "Avviso");
            SetExtraParameterForDetails();
            return;
        }
        MyCfg.foreigngroupnumber = CfgFn.GetNoNullInt32(DettGruppoEstero.Rows[0]["foreigngroupnumber"]);
        txtGruppoEstero.Text = MyCfg.foreigngroupnumber.ToString();
        SetExtraParameterForDetails();
    }

    void resetPosizioneGiuridica() {
        MyCfg.idposition = DBNull.Value;
        MyCfg.foreignclass = "";
        //grpTappe.Enabled = false;
        EnableDisableControls(btnInsertTappa, true);
        EnableDisableControls(btnEditTappa, true);
        EnableDisableControls(btnDelTappa, true);
        if (PState.IsEmpty)
            return;
        DataRow Curr = DS.itineration.Rows[0];
        Curr["idregistrylegalstatus"] = DBNull.Value;
    }



    void setPosizioneGiuridica(object idposition) {
        MyCfg.idposition = idposition;
        if (DS.position.Select(QHC.CmpEq("idposition", idposition)).Length > 0) {
            MyCfg.foreignclass = DS.position.Select(QHC.CmpEq("idposition", idposition))[0]["foreignclass"].ToString().ToUpper();
        }
        else {
            MyCfg.foreignclass = "";
        }
        //grpTappe.Enabled = true;
        EnableDisableControls(btnInsertTappa, false);
        EnableDisableControls(btnEditTappa, false);
        EnableDisableControls(btnDelTappa, false);
    }



    public void btnCambiaRuolo_Click(object sender, EventArgs e) {
        ImpostaPosGiuridica(true);

    }


    void SetExtraParameterForDetails() {
        DS.Tables["itinerationlap"].ExtendedProperties[ExtraParams] = MyCfg;
        DS.Tables["itinerationrefund_advance"].ExtendedProperties[ExtraParams] = MyCfg;
        DS.Tables["itinerationrefund_balance"].ExtendedProperties[ExtraParams] = MyCfg;
        DS.itineration.ExtendedProperties["MyCfgItineration"] = MyCfg;
    }

    void SetGBoxClass(int num, object sortingkind) {
        string nums = num.ToString();
        hwPanel gbox = new hwPanel();
        hwButton btncodice = new hwButton();
        //HtmlGenericControl gboxlabel = new HtmlGenericControl();

        switch (num) {
            case 1:
                gbox = gboxclass1;
                btncodice = btnCodice1;
                //gboxlabel = gboxlblgboxclass1;
                break;
            case 2:
                gbox = gboxclass2;
                btncodice = btnCodice2;
                //gboxlabel = gboxlblgboxclass2;
                break;
            case 3:
                gbox = gboxclass3;
                btncodice = btnCodice3;
                //gboxlabel = gboxlblgboxclass3;
                break;
        }


        if (sortingkind == DBNull.Value) {
            gbox.Enabled = false;
        }
        else {
            string filter = QHS.CmpEq("idsorkind", sortingkind);
            GetData.SetStaticFilter(DS.Tables["sorting" + nums], filter);

            string title = Conn.DO_READ_VALUE("sortingkind", filter, "description").ToString();
            //gboxlabel.InnerText = title;
            gbox.GroupingText = title;
            gbox.Tag = "AutoManage.txtCodice" + nums + ".tree." + filter;
            btncodice.Tag = "manage.sorting" + nums + ".tree." + filter;
            DS.Tables["sorting" + nums].ExtendedProperties[ExtraParams] = filter;

        }
    }

    private void GeneraSelect(object sender) {

        if (PState.IsEmpty)
            return;
        CommFun.GetFormData(true);

        if (((hwTextBox)sender) == txtIncaricato) {
            ImpostaPosGiuridica(false);
        }

        if ((MissFun.CampoDataPerPosGiuridica == "start") && (((hwTextBox)sender) == txtDataInizio)) {
            ImpostaPosGiuridica(false);
        }
        if (((hwTextBox)sender) == txtDataFine) {
            ImpostaPosGiuridica(false);
        }

    }






    void ClearPosGiuridica() {
        LastFilterPosGiuridica = "";
        txtClassStip.Text = "";
        txtQualifica.Text = "";
        txtDecorrClassStip.Text = "";
        txtMatricola.Text = "";
        txtRuoloCSA.Text = "";
        txtCompartoCSA.Text = "";
        txtInquadrcsa.Text = "";
        txtGruppoEstero.Text = "";
        //btnCambiaRuolo.Visible = false;
        //			if (PState.IsEmpty) return;
        MyCfg.incomeclass = DBNull.Value;
        resetPosizioneGiuridica();
        //            MyCfg.idposition = DBNull.Value;
        MyCfg.foreignclass = "";
        MyCfg.idwor = DBNull.Value;
        MyCfg.incomeclassvalidity = DBNull.Value;
        MyCfg.matricula = DBNull.Value;
        SetExtraParameterForDetails();

    }

    public override void BeforeFill() {
        DataRow Curr = DS.itineration.Rows[0];
        if (Curr == null)
            return;

        if (PState.EditMode && PState.runningcommand == null) {
            if (!managingstatus) {

                if (Curr["iditinerationstatus", DataRowVersion.Original].ToString() != Curr["iditinerationstatus", DataRowVersion.Current].ToString()) {
                    Curr["iditinerationstatus"] = Curr["iditinerationstatus", DataRowVersion.Original];
                }
            }
        }


    }

    /*

    void SetExtraParameterForDetails()
    {
        DS.Tables["itinerationlap"].ExtendedProperties[MetaData.ExtraParams] = MyCfg;
        DS.Tables["itinerationrefund_advance"].ExtendedProperties[MetaData.ExtraParams] = MyCfg;
        DS.Tables["itinerationrefund_balance"].ExtendedProperties[MetaData.ExtraParams] = MyCfg;
        DS.itineration.ExtendedProperties["MyCfgItineration"] = MyCfg;
    }
    */

    public void SetMainVisibility() {
        QHC = new CQueryHelper();
        if (Meta.edit_type == "myteamnew02") {
            // Posso guardare solo le prenotazioni delle quali io sono responsabile
            // Escluse le mie
            IsManager = (Session["CodiceResponsabile"] != null ? true : false);
            int idman = 0;
            idman = CfgFn.GetNoNullInt32(Session["CodiceResponsabile"]);
            string filter = QHC.CmpEq("idman", idman);
            GetData.SetStaticFilter(DS.itinerationview, filter);
            grpResponsabile.Enabled = false;
        }
        string km_visibili = configManager.getCfg("km_visibili");
        if (km_visibili == "N") {
            km_panel.Visible = false;
        }
    }


    public override void AfterFill() {
        EnableDisableControls(btnitinerationhistory, true);
        IsManager = (Session["CodiceResponsabile"] != null ? true : false);
        int idman = 0;
        idman = CfgFn.GetNoNullInt32(Session["CodiceResponsabile"]);
        cmbAuthModel.Enabled = true;
        ImpostaTageFiltriUPB(DBNull.Value);
        if (PState.EditMode)
            if (!CanChangeAuthModel())
                cmbAuthModel.Enabled = false;

        cmbStatus.Enabled = false;
        chkWeb.Enabled = false;
        if ((!PState.IsEmpty) && (PState.EditMode)) {
            btnStampaMissione.Enabled = true;
        }
        else {
            btnStampaMissione.Enabled = false;
        }
        if (PState.EditMode) {
            ManageStatus();
        }

        if (DS.itinerationrefund_advance.Rows.Count > 0 || DS.itinerationrefund_balance.Rows.Count > 0) {
            cmbAuthModel.Enabled = false;
        }

        VisualizzaBtnCambiaRuolo();


        DataRow Curr = DS.itineration.Rows[0];
        txtsaldoaccordato.ReadOnly = true;
        txtsaldorichiesto.ReadOnly = true;
        txtanticipoaccordato.ReadOnly = true;

        EnableDisableControls(txtAnticipoErogato, true);
        EnableDisableControls(txtResiduoDaErogare, true);
        EnableDisableControls(txtTotaleErogato, true);

        if (PState.InsertMode) {
            Meta.CanCancel = true;
            Meta.CanSave = true;
            EnableDisableControls(txtEsercmissione, true);
            EnableDisableControls(txtNummissione, true);
            EnableDisableControls(txtCompartoCSA, true);
            EnableDisableControls(txtInquadrcsa, true);
            EnableDisableControls(txtRuoloCSA, true);
            EnableDisableControls(txtQualifica, true);
            EnableDisableControls(txtMatricola, true);
            EnableDisableControls(txtGruppoEstero, true);
            EnableDisableControls(txtDecorrClassStip, true);
            EnableDisableControls(txtClassStip, true);
            EnableDisableControls(btnStatus, true);
            EnableDisableControls(txtsaldoaccordato, true);
            EnableDisableControls(txtsaldorichiesto, true);
            EnableDisableControls(txtanticipoaccordato, true);
            EnableDisableControls(txtapplierannotation, false);

            // disabilito l'inserimento delle tappe

            if (PState.IsFirstFillForThisRow) {
                EnableDisableControls(btnInsertTappa, true);
                EnableDisableControls(btnEditTappa, true);
                EnableDisableControls(btnDelTappa, true);
            }

            if (IsManager) {
                //if (Session["CodiceResponsabile"] != null) {
                //    Curr["idman"] = idman;
                //    cmbresponsabile.SelectedValue = idman.ToString();
                //    //EnableDisableControls(cmbresponsabile, true);
                //}
            }

            QHS = Conn.GetQueryHelper();
            string filter;
            filter = QHS.AppAnd(QHS.CmpEq("webdefault", "S"), QHS.CmpEq("itinerationvisible", "S"), QHS.CmpEq("active", "S"));

            DataTable DT = Conn.RUN_SELECT("service", "*", null, filter, null, false);
            if (DT != null && DT.Rows.Count != 0)
                Curr["idser"] = DT.Rows[0]["idser"];
            btnStampaMissione.Visible = false;
        }
        if (PState.EditMode && PState.IsFirstFillForThisRow) {
            AggiornaSoloInformazioni();
        }
        if (PState.EditMode) {
            AggiornaTotaliErogati();
        }
        //PostData.MarkAsTemporaryTable((DataTable)cmbPrestazione.DataSource,false);
        setDateInizioFineSpesa();
        CheckAnticipiReadOnly();
        EnableDisableRefund();

        SetMainVisibility();
        //if (Meta.FirstFillForThisRow) VisualizzaBtnCambiaRuolo();

        //btnDelTappa.Enabled = true;
        //if (Meta.FirstFillForThisRow && Meta.EditMode) DetectPosGiuridica();

        calcolatotaliriepilogo();

        RicalcolaRimborsiKilometrici();
        CalcolaTotAnticipo();
        //RicalcolaTotaliRitenute();



        if ((!PState.IsEmpty) && (PState.IsFirstFillForThisRow)) {
            grpIncaricato.Tag = "AutoChoose.txtIncaricato.default.((active = 'S')  AND " +
                                " (idreg IN (SELECT idreg FROM registrylegalstatus)) AND " +
                //" (idreg IN (SELECT idreg FROM registrytaxablestatus)) AND " +
                                " (human = 'S'))";


        }
        if (PState.var["idreg"] != null && Meta.edit_type != "myteamnew02") {
            txtIncaricato.ReadOnly = true;
            grpIncaricato.Tag = "";
            txtIncaricato.Text = PState.var["title"].ToString();
        }
        if (Meta.edit_type== "myteamnew02"){
            grpResponsabile.Enabled = false; 
        }
        Meta.metaModel.MarkTableAsNotEntityChild(DS.itineration, DS.itinerationrefundattachment);
    }

    void CalcolaTotAnticipo() {
        DataRow Curr = DS.itineration.Rows[0];
        if (DS.HasChanges()) {
            if (!AnticipoIsReadOnly) {
                decimal nuovototanticipo = CfgFn.RoundValuta(MissFun.GetTotAnticipoMissione(DS.itinerationlap,
                        DS.itinerationrefund_advance));
                Curr["totadvance"] = nuovototanticipo;
            }
            //totanticipoconcesso NON USATO
        }


    }


    void setDateInizioFineSpesa() {
        if (PState.IsEmpty)
            return;

        object datainizio;
        object datafine;
        if (DataValida(txtDataInizio.Text.ToString())) {
            datainizio = HelpForm.GetObjectFromString(typeof(DateTime), txtDataInizio.Text, txtDataInizio.Tag.ToString());
        }
        else
            return;

        if (DataValida(txtDataFine.Text.ToString())) {
            datafine = HelpForm.GetObjectFromString(typeof(DateTime), txtDataFine.Text, txtDataFine.Tag.ToString());
        }
        else
            return;
        MetaData.SetDefault(DS.itinerationrefund_advance, "starttime", datainizio);
        MetaData.SetDefault(DS.itinerationrefund_advance, "stoptime", datafine);
        MetaData.SetDefault(DS.itinerationrefund_advance, "flagadvancebalance", "A");
        MetaData.SetDefault(DS.itinerationrefund_balance, "starttime", datainizio);
        MetaData.SetDefault(DS.itinerationrefund_balance, "stoptime", datafine);
        MetaData.SetDefault(DS.itinerationrefund_balance, "flagadvancebalance", "S");
    }

    void RicalcolaRimborsiKilometrici() {
        if (PState.IsEmpty)
            return;
        //CommFun.GetFormData(true);
        DataRow Curr = DS.itineration.Rows[0];
        double KmProprio = CfgFn.GetNoNullDouble(Curr["owncarkm"]);
        double KmAmm = CfgFn.GetNoNullDouble(Curr["admincarkm"]);
        double KmPiedi = CfgFn.GetNoNullDouble(Curr["footkm"]);
        decimal ImpProprio = CfgFn.GetNoNullDecimal(Curr["owncarkmcost"]);
        decimal ImpAmm = CfgFn.GetNoNullDecimal(Curr["admincarkmcost"]);
        decimal ImpPiedi = CfgFn.GetNoNullDecimal(Curr["footkmcost"]);

        decimal TotAmm = Convert.ToDecimal(KmAmm) * ImpAmm;
        decimal TotProprio = Convert.ToDecimal(KmProprio) * ImpProprio;
        decimal TotPiedi = Convert.ToDecimal(KmPiedi) * ImpPiedi;

        txtEurTotAPiedi.Text = ((decimal)CfgFn.RoundValuta(TotPiedi)).ToString("C");
        txtEurTotMezzoProprio.Text = ((decimal)CfgFn.RoundValuta(TotProprio)).ToString("C");

    }

    bool DataValida(string date) {
        try {
            DateTime TT = (DateTime)HelpForm.GetObjectFromString(typeof(DateTime),date, "x.y");
            return true;
        }
        catch {
            return false;
        }
    }
    bool DataMissioneValida() {
        if (PState.IsEmpty) return false;
        if (txtDataInizio.ToString().Trim() == "") return false;
        return DataValida(txtDataInizio.Text.ToString());

    }

    bool getFaseAnticipoMissione() {
        if (PState.IsEmpty) return false;
        bool phase = false;

        // non più data contabile ma data di sistema
        //DateTime datacontabile = (DateTime)Meta.GetSys("datacontabile");

        object datainizio;
        if (DataValida(txtDataInizio.Text.ToString())) {
            datainizio = HelpForm.GetObjectFromString(typeof(DateTime), txtDataInizio.Text, txtDataInizio.Tag.ToString());
        }
        else {
            return false;
        }

        if (dataoggi < (DateTime)datainizio) phase = true;
        return phase;
    }


    void CheckAnticipiReadOnly() {
        if (PState.IsEmpty)
            return;
        AnticipoIsReadOnly = false;
        if (PState.EditMode) {
            DataRow Curr = DS.itineration.Rows[0];
            string filter = QHS.AppAnd(QHS.CmpMulti(Curr, "iditineration"),
                                    QHS.CmpNe("movkind", 4));
            int N = Conn.RUN_SELECT_COUNT("expenseitineration", filter, false);
            filter = QHS.CmpMulti(Curr, "iditineration");
            N += Conn.RUN_SELECT_COUNT("pettycashoperationitineration", filter, false);
            if (N > 0) AnticipoIsReadOnly = true;
        }
        if (!getFaseAnticipoMissione()) AnticipoIsReadOnly = true;
    }

    void AggiornaTotaliErogati() {
        if (PState.IsEmpty) {
            txtAnticipoErogato.Text = "";
            txtResiduoDaErogare.Text = "";
            txtTotaleErogato.Text = "";
            return;
        }

        DataRow Curr = DS.itineration.Rows[0];
        DataTable T = Conn.RUN_SELECT("itinerationresidual", "*", null, QHS.CmpKey(Curr), null, true);
        if (T == null || T.Rows.Count == 0)
            return;
        DataRow R = T.Rows[0];
        decimal linkedangir = CfgFn.GetNoNullDecimal(R["linkedangir"]);
        decimal linkedanpag = CfgFn.GetNoNullDecimal(R["linkedanpag"]);
        decimal linkedsaldo = CfgFn.GetNoNullDecimal(R["linkedsaldo"]);

        decimal totale = CfgFn.GetNoNullDecimal(Curr["totalgross"]);
        decimal anticipo = linkedanpag + linkedangir;
        decimal pagato = linkedsaldo > 0 ? linkedsaldo + linkedanpag : linkedanpag + linkedangir;
        decimal residuo = totale - pagato;

        txtAnticipoErogato.Text = anticipo.ToString("c");
        txtResiduoDaErogare.Text = residuo.ToString("c");
        txtTotaleErogato.Text = pagato.ToString("c");


    }


    void AggiornaSoloInformazioni() {
        if (PState.IsEmpty)
            return;
        DataRow Curr = DS.itineration.Rows[0];

        string filter;
        string sorting;
        object datainizio = Curr[MissFun.CampoDataPerPosGiuridica];
        object datafine = Curr["stop"];
        object codicecreddeb = Curr["idreg"];
        QHS = Conn.GetQueryHelper();
        QHC = new CQueryHelper();
        if ((datainizio == DBNull.Value) || (((DateTime)datainizio) == QueryCreator.EmptyDate())) {
            ClearPosGiuridica();
            return;
        }
        if ((datafine == DBNull.Value) || (((DateTime)datafine) == QueryCreator.EmptyDate())) {
            ClearPosGiuridica();
            return;
        }

        if ((codicecreddeb == DBNull.Value) || (((int)codicecreddeb) <= 0)) {
            ClearPosGiuridica();
            return;
        }


        string strdate = QueryCreator.quotedstrvalue((DateTime)datainizio, true);
        string strdatefine = QueryCreator.quotedstrvalue((DateTime)datafine, true);

        filter = QHS.AppAnd(QHS.CmpEq("idreg", codicecreddeb),
                            QHS.CmpLe("start", datainizio));

        if (LastFilterPosGiuridica == filter)
            return;

        //string currcodicerapporto = null;

        //sorting = "start DESC";

        //DataTable SelClass = Meta.Conn.RUN_SELECT("legalstatuscontract",
        //    "idposition, incomeclass, incomeclassvalidity, maxincomeclass", 
        //    sorting, filter, "1", false);

        string filtroInquadramento = QHS.AppAnd(QHS.CmpEq("idreg", codicecreddeb), QHS.CmpEq("idregistrylegalstatus", Curr["idregistrylegalstatus"]));
        DataTable SelClass = Conn.RUN_SELECT("legalstatuscontract",
                    "idposition, incomeclass, incomeclassvalidity, maxincomeclass,idregistrylegalstatus,csa_compartment,csa_role, csa_class",
                    null, filtroInquadramento, null, false);

        if (SelClass.Rows.Count == 0) {
            if (LastFilterPosGiuridica != filter) {
                //MessageBox.Show("I dati relativi alla posizione giuridica dell'incaricato sono incompleti o mancanti.", "Avviso");
            }
            //ClearInformazioni();
            LastFilterPosGiuridica = filter;
            return;
        }
        LastFilterPosGiuridica = filter;

        DataRow RowClass = SelClass.Rows[0];
        txtRuoloCSA.Text = RowClass["csa_role"].ToString();
        txtCompartoCSA.Text = RowClass["csa_compartment"].ToString();
        txtInquadrcsa.Text = RowClass["csa_class"].ToString();

        //Aboliamo virtualmente il flagquotaesente mettendolo sempre a S
        object currflagquotaesente = "S";



        //FiltraComboPrestazioneInBaseANiente(false);
        object matricula = Conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg", codicecreddeb), "extmatricula");
        int incomeclass = CfgFn.GetNoNullInt32(RowClass["incomeclass"]);
        txtClassStip.Text = incomeclass.ToString();
        setPosizioneGiuridica(RowClass["idposition"]);
        MyCfg.matricula = matricula;
        MyCfg.incomeclass = incomeclass;
        MyCfg.incomeclassvalidity = RowClass["incomeclassvalidity"];

        object codicequalifica = RowClass["idposition"];
        //string codicerapporto = currcodicerapporto;

        DataRow[] Q = DS.position.Select(QHC.CmpEq("idposition", codicequalifica));
        if (Q.Length > 0) {
            txtQualifica.Text = Q[0]["description"].ToString();
        }


        txtDecorrClassStip.Text = HelpForm.StringValue(MyCfg.incomeclassvalidity, "x.y.d");
        txtMatricola.Text = MyCfg.matricula.ToString();

        //Classe attuale
        int classe, maxclassestip;
        classe = CfgFn.GetNoNullInt32(incomeclass);
        maxclassestip = CfgFn.GetNoNullInt32(RowClass["maxincomeclass"]);
        if (classe <= maxclassestip) {
            txtClassStip.Text = classe.ToString();
            MyCfg.incomeclass = classe;
        }
        else {
            txtClassStip.Text = maxclassestip.ToString();
            MyCfg.incomeclass = maxclassestip;
        }
        bool AzzeraImportoEsente;
        if (currflagquotaesente.ToString().ToUpper() == "S")
            AzzeraImportoEsente = false;
        else
            AzzeraImportoEsente = true;

        //labQuotaEsente.Visible = AzzeraImportoEsente;

        datainizio = Curr[MissFun.CampoDataPerGeneralita];


        filter = QHS.CmpLe("start", datainizio);

        sorting = "start DESC";
        DataTable Generalita = Conn.RUN_SELECT("itinerationparameter",
            "start, italianexemption,foreignexemption",
            sorting, filter, "1", false);
        if (Generalita.Rows.Count == 0) {
            //MessageBox.Show("In Generalità Missioni non è stata trovata alcuna informazione", "Avviso");
            MyCfg.italianexemption = 0;
            MyCfg.foreignexemption = 0;
            MyCfg.foreignhours = 0;

        }
        else {
            DataRow RowGen = Generalita.Rows[0];
            MyCfg.italianexemption = CfgFn.GetNoNullDecimal(RowGen["italianexemption"]);
            //txtImpEsenteItalia.Text = HelpForm.StringValue(
            //    MyCfg.italianexemption, txtImpEsenteItalia.Tag.ToString());
            txtImpEsenteItalia.Text = HelpForm.StringValue(
                MyCfg.italianexemption, "");

            MyCfg.foreignexemption = CfgFn.GetNoNullDecimal(RowGen["foreignexemption"]);
            if (AzzeraImportoEsente)
                MyCfg.foreignexemption = 0;
            //txtImpEsenteEstero.Text = HelpForm.StringValue(
            //    MyCfg.foreignexemption, txtImpEsenteEstero.Tag.ToString());
            txtImpEsenteEstero.Text = HelpForm.StringValue(
                MyCfg.foreignexemption, "");

            if (DS.config.Rows.Count > 0) {
                DataRow CurrSetup = DS.config.Rows[0];
                MyCfg.foreignhours = CfgFn.GetNoNullDecimal(CurrSetup["foreignhours"]);
            }
        }




        object idforeigngrouprule = Conn.DO_READ_VALUE("foreigngrouprule",
            QHS.CmpLe("start", Curr[MissFun.CampoDataPerGruppoEstero]),
            "max(idforeigngrouprule)");
        //imposta il gruppo estero
        string filterGE;
        filterGE = QHS.AppAnd(
            QHS.CmpEq("idforeigngrouprule", idforeigngrouprule),
            QHS.CmpEq("idposition", MyCfg.idposition),
            "(" + QHS.quote(MyCfg.incomeclass) + " between minincomeclass and maxincomeclass)");

        DataTable DettGruppoEstero = Conn.RUN_SELECT("foreigngroupruledetail", "foreigngroupnumber",
            null, filterGE, "1", false);
        if (DettGruppoEstero.Rows.Count == 0) {
            MyCfg.foreigngroupnumber = DBNull.Value;
            txtGruppoEstero.Text = "";
            //MessageBox.Show("I dati relativi al gruppo estero sono incompleti o mancanti", "Avviso");
        }
        else {
            MyCfg.foreigngroupnumber = CfgFn.GetNoNullInt32(DettGruppoEstero.Rows[0]["foreigngroupnumber"]);
            txtGruppoEstero.Text = MyCfg.foreigngroupnumber.ToString();
        }
        SetExtraParameterForDetails();

    }

    private void ImpostaImpEsente(bool AzzeraImportoEsente) {
        if (PState.IsEmpty)
            return;

        //labQuotaEsente.Visible = AzzeraImportoEsente;

        CommFun.GetFormData(true);
        DataRow Curr = DS.itineration.Rows[0];
        string filter, sorting;
        object datainizio = Curr[MissFun.CampoDataPerGeneralita];
        if ((datainizio == DBNull.Value) || (((DateTime)datainizio) == QueryCreator.EmptyDate())) {
            ClearImpEsente(false);
            return;
        }

        filter = QHS.CmpLe("start", datainizio);
        //if (filter == LastImpEsenteFilter)
        //    return;
        //LastImpEsenteFilter = filter;

        sorting = "start DESC";
        DataTable Generalita = Conn.RUN_SELECT("itinerationparameter",
            "start, italianexemption,foreignexemption",
            sorting, filter, "1", false);
        if (Generalita.Rows.Count == 0) {
            //MessageBox.Show("In Generalità Missioni non è stata trovata alcuna informazione", "Avviso");
            return;
        }
        DataRow RowGen = Generalita.Rows[0];

        ///TODO: Assegnare impkm vari - solo la prima volta in fase di insert
        ///

        //txtEurKmAPiedi.Text = HelpForm.StringValue( 
        //    CfgFn.GetNoNullDecimal(RowGen["footkmcost"]), txtEurKmAPiedi.Tag.ToString());
        //txtEurKmMezzoAmm.Text = HelpForm.StringValue(
        //    CfgFn.GetNoNullDecimal( RowGen["admincarkmcost"]),txtEurKmMezzoAmm.Tag.ToString());
        //txtEurKmMezzoProprio.Text = HelpForm.StringValue(
        //    CfgFn.GetNoNullDecimal(RowGen["owncarkmcost"]),txtEurKmMezzoProprio.Tag.ToString());

        //Curr["owncarkmcost"]= RowGen["owncarkmcost"];
        //Curr["admincarkmcost"]= RowGen["admincarkmcost"];
        //Curr["footkmcost"]= RowGen["footkmcost"];

        MyCfg.italianexemption = CfgFn.GetNoNullDecimal(RowGen["italianexemption"]);
        if (AzzeraImportoEsente)
            MyCfg.italianexemption = 0;
        //txtImpEsenteItalia.Text = HelpForm.StringValue(
        //    MyCfg.italianexemption, txtImpEsenteItalia.Tag.ToString());
        txtImpEsenteItalia.Text = HelpForm.StringValue(
            MyCfg.italianexemption, "");

        MyCfg.foreignexemption = CfgFn.GetNoNullDecimal(RowGen["foreignexemption"]);
        if (AzzeraImportoEsente)
            MyCfg.foreignexemption = 0;
        //txtImpEsenteEstero.Text = HelpForm.StringValue(
        //    MyCfg.foreignexemption, txtImpEsenteEstero.Tag.ToString());
        txtImpEsenteEstero.Text = HelpForm.StringValue(
            MyCfg.foreignexemption, "");

        //if (DS.config.Rows.Count > 0) {
        //    DataRow CurrSetup = DS.config.Rows[0];
        //    MyCfg.foreignhours = CfgFn.GetNoNullDecimal(CurrSetup["foreignhours"]);
        //}
        //CalcolaRitenute(true);
        //SetExtraParameterForDetails();
    }

    void ClearImpEsente(bool _readonly) {
        //LastImpEsenteFilter = "";
        txtImpEsenteItalia.Text = "";
        txtImpEsenteEstero.Text = "";
        //labQuotaEsente.Visible = false;
        //if (PState.IsEmpty)
        //    return;
        //if (!_readonly)
        //    CalcolaRitenute(true);
    }

    public void calcolatotaliriepilogo() {
        DataRow Curr = DS.itineration.Rows[0];
        if (Curr == null)
            return;

        decimal advancerequiredamount = CfgFn.GetNoNullDecimal(MetaData.SumColumn(DS.itinerationrefund_advance, "requiredamount"));
        decimal advanceamount = CfgFn.GetNoNullDecimal(MetaData.SumColumn(DS.itinerationrefund_advance, "amount"));
        decimal balancerequiredamount = CfgFn.GetNoNullDecimal(MetaData.SumColumn(DS.itinerationrefund_balance, "requiredamount"));
        decimal balanceamount = CfgFn.GetNoNullDecimal(MetaData.SumColumn(DS.itinerationrefund_balance, "amount"));

        txtanticiporichiesto.Text = advancerequiredamount.ToString("c");
        txtanticipoaccordato.Text = advanceamount.ToString("c");

        txtsaldorichiesto.Text = balancerequiredamount.ToString("c");
        txtsaldoaccordato.Text = balanceamount.ToString("c");



    }


    protected void Page_Load(object sender, EventArgs e) {
        btnInsertTappaTag = btnInsertTappa.Tag.ToString();
        btnEditTappaTag = btnInsertTappa.Tag.ToString();
        dgrTappeTag = dgrTappe.Tag.ToString();
    }
    bool managingstatus = false;

    public void DoChangeStatus() {
        if (PState.EditMode) {
            DataRow CurrentRow = DS.itineration.Rows[0];
            int status = CfgFn.GetNoNullInt32(CurrentRow["iditinerationstatus"]);

            switch (status) {
                case 1://se è in bozza o da correggere passa in richiesta o stato di autorizzazione a seconda del tipo di gestione
                case 3:
                    if (DirectAuth) {
                        PoniInAutorizzazione();
                    }
                    else {
                        CurrentRow["iditinerationstatus"] = 2;
                        managingstatus = true;
                        CommFun.FreshPage(false, false);
                        managingstatus = false;
                        CommFun.DoMainCommand("mainsave");
                    }
                    break;
                case 2:// se è in richiesta passa in bozza
                    CurrentRow["iditinerationstatus"] = 1;
                    managingstatus = true;
                    CommFun.FreshPage(false, false);
                    managingstatus = false;
                    CommFun.DoMainCommand("mainsave");
                    break;
                case 6:// se è approvata passa in bozza
                    CurrentRow["iditinerationstatus"] = 1;
                    managingstatus = true;
                    CommFun.FreshPage(false, false);
                    managingstatus = false;
                    CommFun.DoMainCommand("mainsave");
                    break;

                case 5:
                case 8:
                    if (DirectAuth) {
                        Riconsidera();
                    }
                    break;
            }

            if (PState.EditMode && PState.runningcommand == null) {
                if (CurrentRow["iditinerationstatus", DataRowVersion.Original].ToString() != CurrentRow["iditinerationstatus", DataRowVersion.Current].ToString()) {
                    CurrentRow["iditinerationstatus"] = CurrentRow["iditinerationstatus", DataRowVersion.Original];
                    CommFun.FreshPage(false, false);
                }
            }


        }

    }
    public void VisualizzaBtnCambiaRuolo() {
        if (PState.IsEmpty)
            return;
        DataRow Curr = DS.itineration.Rows[0];

        string filter;
        btnCambiaRuolo.Visible = false;

        object datainizio = Curr[MissFun.CampoDataPerPosGiuridica];
        object datafine = Curr["stop"];
        object codicecreddeb = Curr["idreg"];

        if ((datainizio == DBNull.Value) || (((DateTime)datainizio) == QueryCreator.EmptyDate())) {
            return;
        }
        if ((datafine == DBNull.Value) || (((DateTime)datafine) == QueryCreator.EmptyDate())) {
            return;
        }

        if ((codicecreddeb == DBNull.Value) || (((int)codicecreddeb) <= 0)) {
            return;
        }

        string strdate = QueryCreator.quotedstrvalue((DateTime)datainizio, true);
        string strdatefine = QueryCreator.quotedstrvalue((DateTime)datafine, true);

        filter = QHS.AppAnd(QHS.CmpEq("idreg", codicecreddeb), QHS.CmpLe("start", datainizio), QHS.NullOrGe("stop", datafine));

        int NposGiuridiche = Conn.RUN_SELECT_COUNT("legalstatuscontract", filter, false);
        if (NposGiuridiche > 1)
            btnCambiaRuolo.Visible = true;
        else
            btnCambiaRuolo.Visible = false;

    }

    decimal CalcolaSpeseSostenute() {
        decimal SUM = 0;
        if (PState.IsEmpty)
            return SUM;

        if (getFaseAnticipoMissione()) {
            foreach (DataRow R in DS.itinerationrefund_advance.Rows) {
                if (R.RowState == DataRowState.Deleted)
                    continue;
                SUM += MissFun.SpesaSostenuta(R);
            }
        }
        else {
            foreach (DataRow R in DS.itinerationrefund_balance.Rows) {
                if (R.RowState == DataRowState.Deleted)
                    continue;
                SUM += MissFun.SpesaSostenuta(R);
            }
        }
        return SUM;
    }

    decimal CalcolaSpeseAnticipo() {
        decimal SUM = 0;
        if (PState.IsEmpty)
            return SUM;

        foreach (DataRow R in DS.itinerationrefund_advance.Rows) {
            if (R.RowState == DataRowState.Deleted)
                continue;
            SUM += MissFun.SpesaSostenuta(R);
        }

        return SUM;
    }

    decimal CalcolaSpeseSaldo() {
        decimal SUM = 0;
        if (PState.IsEmpty)
            return SUM;

        foreach (DataRow R in DS.itinerationrefund_balance.Rows) {
            if (R.RowState == DataRowState.Deleted)
                continue;
            SUM += MissFun.SpesaSostenuta(R);
        }

        return SUM;
    }
    /// <summary>
    /// Ind. suppl. EURO
    /// </summary>
    /// <returns></returns>
    decimal CalcolaIndennitaSupplementari() {
        decimal SUM = 0;
        if (getFaseAnticipoMissione()) {
            foreach (DataRow R in DS.itinerationrefund_advance.Rows) {
                if (R.RowState == DataRowState.Deleted)
                    continue;
                SUM += MissFun.IndennitaSupplementare(R);
            }
        }
        else {
            foreach (DataRow R in DS.itinerationrefund_balance.Rows) {
                if (R.RowState == DataRowState.Deleted)
                    continue;
                SUM += MissFun.IndennitaSupplementare(R);
            }
        }
        return CfgFn.RoundValuta(SUM);
    }

    decimal CalcolaIndennitaChilometrica() {
        DataRow Curr = DS.itineration.Rows[0];
        return MissFun.IndennitaChilometrica(Curr);
    }
    decimal CalcolaIndLordaTrafertaItalia() {
        decimal SUM = 0;
        DataRow Missione = DS.itineration.Rows[0];
        foreach (DataRow Tappa in DS.itinerationlap.Select(QHC.CmpEq("flagitalian", "S"))) {
            if (Tappa.RowState == DataRowState.Deleted)
                continue;
            SUM += MissFun.IndennitaLordaTappa(Missione, Tappa, MyCfg);
        }
        return SUM;
    }

    decimal CalcolaIndLordaTrafertaEstero() {
        decimal SUM = 0;
        DataRow Missione = DS.itineration.Rows[0];
        foreach (DataRow Tappa in DS.itinerationlap.Select(QHC.CmpEq("flagitalian", "N"))) {
            if (Tappa.RowState == DataRowState.Deleted)
                continue;
            SUM += MissFun.IndennitaLordaTappa(Missione, Tappa, MyCfg);
        }
        return SUM;
    }
    decimal AdminTax() {
        return MetaData.SumColumn(DS.itinerationtax, "admintax");
    }
    decimal EmployTax() {
        return MetaData.SumColumn(DS.itinerationtax, "employtax");
    }

    void CalcolaTotali() {
        DataRow curr = DS.itineration.Rows[0];
        //Set accorded refund = required refund
        foreach (DataRow S in DS.itinerationrefund_advance.Select()) {
            S["amount"] = S["requiredamount"];
        }
        foreach (DataRow S in DS.itinerationrefund_balance.Select()) {
            S["amount"] = S["requiredamount"];
        }

        //recalc totals
        decimal totalrefund = 0;
        decimal totalrefundadv = 0;
        decimal totalrefundbal = 0;
        decimal kmrefund = 0;
        decimal extraallowance = 0;
        decimal italiangrossallowance = 0;
        decimal foreigngrossallowance = 0;

        totalrefund = CfgFn.RoundValuta(CalcolaSpeseSostenute());
        totalrefundadv = CfgFn.RoundValuta(CalcolaSpeseAnticipo());
        totalrefundbal = CfgFn.RoundValuta(CalcolaSpeseSaldo());

        extraallowance = CfgFn.RoundValuta(CalcolaIndennitaSupplementari());
        kmrefund = CfgFn.RoundValuta(CalcolaIndennitaChilometrica());
        italiangrossallowance = CfgFn.RoundValuta(CalcolaIndLordaTrafertaItalia());
        foreigngrossallowance = CfgFn.RoundValuta(CalcolaIndLordaTrafertaEstero());



        decimal totalgross = CfgFn.RoundValuta(CalcolaImportoLordoMissione());
        curr["totalgross"] = totalgross;
        decimal total = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(curr["totalgross"]) +
            CfgFn.GetNoNullDecimal(AdminTax()));
        curr["total"] = total;

        decimal nuovototanticipo = CfgFn.GetNoNullDecimal(curr["totadvance"]);
        if (!AnticipoIsReadOnly) {
            nuovototanticipo = CfgFn.RoundValuta(MissFun.GetTotAnticipoMissione(DS.itinerationlap,
                    DS.itinerationrefund_advance));
            curr["totadvance"] = nuovototanticipo;
        }



    }
    decimal CalcolaImportoLordoMissione() {
        return CalcolaSpeseSostenute() +
            CalcolaIndennitaSupplementari() +
            CalcolaIndennitaChilometrica() +
            CalcolaIndLordaTrafertaItalia() + //lordo 
            CalcolaIndLordaTrafertaEstero(); //lordo

    }



    void RicalcolaTotaliRitenute() {
        decimal TotDip = 0;
        decimal TotAmm = 0;
        decimal AssicurativeDip = 0;
        decimal AssicurativeEnte = 0;
        decimal AssistenzialiDip = 0;
        decimal AssistenzialiEnte = 0;
        decimal FiscaliDip = 0;
        decimal FiscaliEnte = 0;
        decimal PrevidenzialiDip = 0;
        decimal PrevidenzialiEnte = 0;
        decimal AltreDip = 0;
        decimal AltreEnte = 0;

        DataRow Curr = DS.itineration.Rows[0];
        decimal MyImporto;
        decimal totalgross = CfgFn.RoundValuta(CalcolaImportoLordoMissione());
        Curr["totalgross"] = totalgross;
        MyImporto = totalgross;
        //CfgFn.RoundValuta(CalcolaImportoLordoMissione()); //GetImportoPerClassificazione();

        foreach (DataRow DR in DS.itinerationtax.Rows) {
            if (DR.RowState == DataRowState.Deleted)
                continue;

            decimal DecDip = CfgFn.GetNoNullDecimal(DR["employtax"]);
            decimal DecAmm = CfgFn.GetNoNullDecimal(DR["admintax"]);
            TotDip += DecDip;
            TotAmm += DecAmm;

            string MyFilter = QHC.CmpEq("taxcode", DR["taxcode"]);
            DataRow[] DRTipo = DS.Tables["tax"].Select(MyFilter);

            //In base al tipo di ritenuta:
            switch (DRTipo[0]["taxkind"].ToString()) {
                case "2":
                    AssistenzialiDip += DecDip;
                    AssistenzialiEnte += DecAmm;
                    break;
                case "1":
                    FiscaliDip += DecDip;
                    FiscaliEnte += DecAmm;
                    break;
                case "3":
                    PrevidenzialiDip += DecDip;
                    PrevidenzialiEnte += DecAmm;
                    break;
                case "6":
                    AltreDip += DecDip;
                    AltreEnte += DecAmm;
                    break;
                case "4":
                    AssicurativeDip += DecDip;
                    AssicurativeEnte += DecAmm;
                    break;
            }


        }//fine foreach
        TotDip = CfgFn.RoundValuta(TotDip);
        TotAmm = CfgFn.RoundValuta(TotAmm);

        CfgFn.AssignNotEquals(Curr, "netfee", MyImporto - TotDip);
        CfgFn.AssignNotEquals(Curr, "total", MyImporto + TotAmm);
    }

    public void PoniInAutorizzazione() {
        DataRow curr = DS.itineration.Rows[0];
        object idoldstatus = curr["iditinerationstatus"];
        object oldlt = curr["lt"];
        object oldlu = curr["lu"];
        curr["iditinerationstatus"] = getFaseAnticipoMissione() ? 5 : 8;


        if (DS.itinerationauthagency.Select().Length == 0 ||
            DS.itinerationauthagency.Select(QHC.CmpNe("flagstatus", "S")).Length > 0)
            GeneraAutorizzazioni();

        if ((DS.itinerationauthagency.Select().Length == 0) ||  //non ci sono agenti autorizzativi
            (DS.itinerationauthagency.Select(QHC.CmpNe("flagstatus", "S")).Length == 0)) { // missione già approvata devo inserire il saldo
            curr["iditinerationstatus"] = 6;
            if (getFaseAnticipoMissione() == false)
                curr["completed"] = "S";
            curr["lu"] = oldlu;
            curr["lt"] = oldlt;
        }
        CheckAnticipiReadOnly();
        CalcolaTotali();
        RicalcolaTotaliRitenute();

        managingstatus = true;
        CommFun.FreshPage(false, false);
        managingstatus = false;
        CommFun.DoMainCommand("mainsave");
        if (DS.HasChanges()) {
            DS.itinerationauthagency.RejectChanges();
            curr["iditinerationstatus"] = idoldstatus;
            curr["lu"] = oldlu;
            curr["lt"] = oldlt;
            managingstatus = true;
            CommFun.FreshPage(false, false);
            managingstatus = false;
        }
        else {
            MissFun.SendMails(Conn as DataAccess, curr);
        }
    }
    void GeneraAutorizzazioni() {
        if (PState.IsEmpty)
            return;
        DataRow Curr = DS.itineration.Rows[0];
        //Aggiorna / Crea le righe nella Tabella Autorizzazioni in base al Modello Autorizzativo selezionato
        MetaData MetaAutorizzazione = ApplicationState.GetApplicationState(this).Dispatcher.Get("itinerationauthagency");
        MetaAutorizzazione.SetDefaults(DS.itinerationauthagency);

        DataTable authModelAuthAgency = Conn.RUN_SELECT("authmodelauthagency", null, null,
                        QHS.CmpEq("idauthmodel", Curr["idauthmodel"]), null, true);
        //Elimina dalla tabella Autorizzazioni le righe che non saranno utilizzate
        DS.itinerationauthagency.RejectChanges();
        foreach (DataRow Existing in DS.itinerationauthagency.Select()) {
            if (Existing.RowState == DataRowState.Deleted)
                continue;
            object codiceold = Existing["idauthagency"];
            if (authModelAuthAgency == null || authModelAuthAgency.Select(QHC.CmpEq("idauthagency", codiceold)).Length == 0) {
                Existing.Delete();
            }
        }

        foreach (DataRow Row in authModelAuthAgency.Rows) {
            DataRow[] Found = DS.itinerationauthagency.Select(QHC.CmpEq("idauthagency", Row["idauthagency"]));
            DataRow MissAut;
            if (Found.Length == 0) {
                MetaAutorizzazione.SetDefaults(DS.itinerationauthagency);
                DS.itinerationauthagency.Columns["idauthagency"].DefaultValue = Row["idauthagency"];
                MissAut = MetaAutorizzazione.Get_New_Row(Curr, DS.itinerationauthagency);
                DS.itinerationauthagency.Columns["idauthagency"].DefaultValue = DBNull.Value;

                //MissAut = MetaAutorizzazione.Get_New_Row(Curr, DS.itinerationauthagency);
                //MissAut["idauthagency"] = Row["idauthagency"];
            }
            else {
                MissAut = Found[0];
            }
            MissAut["flagstatus"] = "D";
        }
    }


    void Riconsidera() {
        if (DS.itinerationauthagency.Select(QHC.CmpNe("flagstatus", "S")).Length > 0) {
            bool asked = false;
            foreach (DataRow R in DS.itinerationauthagency.Select()) {
                if (R["flagstatus"].ToString().ToUpper() != "S")
                    continue;
                R["flagstatus"] = "D";
            }
        }

        DataRow curr = DS.itineration.Rows[0];
        object idoldstatus = curr["iditinerationstatus"];
        object oldlt = curr["lt"];
        object oldlu = curr["lu"];
        curr["iditinerationstatus"] = 3;  // ritorna nello stato "Da correggere"
        managingstatus = true;
        CommFun.FreshPage(false, false);
        managingstatus = false;
        CommFun.DoMainCommand("mainsave");
        if (DS.HasChanges()) {
            curr["iditinerationstatus"] = idoldstatus;
            curr["lu"] = oldlu;
            curr["lt"] = oldlt;
            DS.itinerationauthagency.RejectChanges();
            managingstatus = true;
            CommFun.FreshPage(false, false);
            managingstatus = false;
        }
        else {
            MissFun.SendMails(Conn as DataAccess, curr);
        }
    }

    private string CalcolaFiltroUPB() {
        if (CommFun.IsEmpty) return "";
        DataRow r = DS.itineration.Rows[0];
        string filter_upb = "";
        object idman = r["idman"];
        if (idman != null && idman != DBNull.Value) {
            filter_upb = QHS.AppAnd(filter_upb, QHS.NullOrEq("idman", idman));
        }
        return filter_upb;
    }

    private void ImpostaTageFiltriUPB(object idupbToinclude) {
        string upbfilter = CalcolaFiltroUPB();
        string filteradd = upbfilter;
        string filteractive = QHS.AppAnd(upbfilter, QHS.CmpEq("active", "S"));

        if (idupbToinclude != DBNull.Value && upbfilter != "") {
            filteradd = QHS.DoPar(QHS.AppOr(QHS.CmpEq("idupb", idupbToinclude), QHS.DoPar(upbfilter)));
        }

        GetData.SetStaticFilter(DS.upb, filteradd);

        if (upbfilter != "") {
            //btnUPB.Tag = "choose.upb.default." + filteractive;
            btnUPB.Tag = "choose.upb.missioni." + filteractive;
        }
        else {
            btnUPB.Tag = "manage.upb.tree";
        }

        if (PanelUpb.Tag != null)
            PanelUpb.Tag = "AutoChoose.txtUPB.default." + filteractive;
        CommFun.SetAutoMode(PanelUpb);

    }

    public override void BeforeClosing() {

    }
}
