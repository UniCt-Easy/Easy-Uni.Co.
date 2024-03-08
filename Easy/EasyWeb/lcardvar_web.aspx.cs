
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
using metadatalibrary;
using metaeasylibrary;
using AllDataSet;
using funzioni_configurazione;
using lcardmail;

public partial class lcardvar_web : MetaPage {
    bool DoSendMail = false;
    CQueryHelper QHC;
    QueryHelper QHS;
    vistaForm_lcardvar_web DS;

    public override DataSet GetDataSet() {
        return DS;
    }

    public override DataSet CreateNewDataSet() {
        return new vistaForm_lcardvar_web();
    }

    public override void SetDataSet(DataSet D) {
        DS = (vistaForm_lcardvar_web)D;
    }


    protected void Page_Load(object sender, EventArgs e) {

    }

    public override void AfterLink(bool firsttime, bool formToLink) {
        
        QHC = new CQueryHelper();
        QHS = Conn.GetQueryHelper();

        Meta.DefaultListType = "default";
        SearchTable = "lcardvarview";
    
        GetData.SetStaticFilter(DS.lcardvar,QHS.CmpEq("ylvar",Conn.GetSys("esercizio")));

        GetData.SetStaticFilter(DS.lcardvarview, QHS.CmpEq("ylvar", Conn.GetSys("esercizio")));

        if (formToLink) {
            cmblcard.DataSource = DS.lcard;
            cmblcard.DataValueField = "idlcard";
            cmblcard.DataTextField = "title";
            //cmblcard.DataBind();
        }
            string filterLcard = QHS.CmpEq("active", "S"); // card attive

            bool IsManager = (Session["CodiceResponsabile"] != null ? true : false);
            int idman = 0;
            idman = CfgFn.GetNoNullInt32(Session["CodiceResponsabile"]);

            if (IsManager)
            {
                filterLcard = QHS.AppAnd(filterLcard, QHS.CmpEq("idman", idman));
            }
            DataTable LCard = Meta.Conn.RUN_SELECT("lcard", "*", null, filterLcard, null, true);

            string filterId = QHC.FieldIn("idlcard", LCard.Select());
            GetData.SetStaticFilter(DS.lcard, filterId);
            string tag = btnCard.Tag;
            tag = tag + "." + filterId;
            btnCard.Tag = tag;
            if (formToLink) {
                cmbBilancio.DataSource = DS.finview;
                cmbBilancio.DataValueField = "idfin";
                cmbBilancio.DataTextField = "codefin";
                //cmbBilancio.DataBind();

                cmbUPB.DataSource = DS.upb;
                cmbUPB.DataValueField = "idupb";
                cmbUPB.DataTextField = "codeupb";
            }
            //cmbUPB.DataBind();
            //if (!IsPostBack) {
            //    SetFilterFinView(DBNull.Value);
            //}
            //else {
            //    SetFilterFinView(cmbUPB.SelectedValue);
            //}
            GetData.SetSorting(DS.finview, "codeupb asc, printingorder asc");
            GetData.SetSorting(DS.upb, "printingorder asc");
            GetData.SetSorting(DS.upbview, "printingorder asc");

        
    }

    public override void AfterClear() {
        base.AfterClear();
        txtNlvar.ReadOnly = false;
        SelectUPB(cmbUPB.SelectedValue,true);
        EnableDisableCard();
    }

    public override void AfterPost(){
        if (DS.lcardvar.Rows.Count == 0) return;
        DataRow CurrRow = DS.lcardvar.Rows[0];
        string errormsg = "";
		try
		{
            errormsg = lcardSendMail.WebSendMails(Conn as DataAccess, CurrRow);
            if (errormsg != "")
                ShowClientMessage(errormsg, "Errore");
        }
		catch
		{
            ShowClientMessage("Errore di invio mail", "Errore");
        }
        

    }

    string GetPrevFilter() {
        int esercizio = Conn.Security.GetEsercizio();
        string filteroperativo= "(idfin in (SELECT idfin from finusable where ayear='"+
				esercizio+"'))";
        if (this.PState.IsEmpty || this.PState.EditMode)
            return filteroperativo;
        return QHS.AppAnd(filteroperativo, QHS.CmpGt("availableprevision", 0));
    }

    private void SetFilterFinView(object idupb) {
        string filter;
        int esercizio = CfgFn.GetNoNullInt32(Conn.Security.GetSys("esercizio"));

        
        string filteresercizio = QHS.CmpEq("ayear", esercizio);

        if (idupb != DBNull.Value) {
            filter = QHS.CmpEq("idupb", idupb);
        }
        else {
            filter = QHS.CmpEq("idupb", "0001");
        }
        filter = QHS.AppAnd(filter, QHS.CmpEq("finpart", 'S'),GetPrevFilter());

        //string mergedFilter = QHS.AppAnd(filteroperativo, filter, filteresercizio);
        string mergedFilter = QHS.AppAnd(filter, filteresercizio);
        DS.finview.Clear();
        GetData.SetStaticFilter(DS.finview, mergedFilter);
        GetData.MarkedToAddBlankRow(DS.finview);
        Conn.RUN_SELECT_INTO_TABLE(DS.finview, GetData.GetSorting(DS.finview,null),
                    QHS.AppAnd(mergedFilter,GetPrevFilter()), null, true);
        Conn.Security.DeleteAllUnselectable(DS.finview);
    }
    public override void AfterFill() {
        SelectUPB(DS.lcardvar.Rows[0]["idupb"], false);
        txtNlvar.ReadOnly = true;
        if (PState.IsFirstFillForThisRow && PState.EditMode) {
            CommFun.HMW.SetCombo(cmbBilancio, DS.finview, "idfin", DS.lcardvar.Rows[0]["idfin", DataRowVersion.Original]);
        }
        EnableDisableCard();
    }

    void EnableDisableCard(){
        if (PState.EditMode){
            btnCard.Enabled = false;
            cmblcard.Enabled = false;
        }
        else{
            btnCard.Enabled = true;
            cmblcard.Enabled = true;
        }
    }

    public override void AfterGetFormData() {
        base.AfterGetFormData();
        bool linked = false;
        if (DS.lcardvar.Rows[0]["yvar"] != DBNull.Value) linked = true;
        Meta.CanSave = (linked == false);

    }
    void SelectUPB(object oidupb, bool freshvalue) {
        int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
        string fintag = "choose.finview.default.";
        string idupb="0001";
        if (oidupb != null && oidupb != "" && oidupb!=DBNull.Value) idupb = oidupb.ToString();
        string filter = QHS.AppAnd(QHS.CmpEq("idupb", idupb), QHS.CmpEq("finpart", 'S'),
                QHS.CmpEq("ayear", esercizio), GetPrevFilter());
        fintag +=  filter;
        btnBilancio.Tag = fintag;

        SetFilterFinView(idupb);
        //occorre azzerare la selezione in combo fin e rileggerne il datatable relativo
        CommFun.HMW.FilteredPreFillCombo(cmbBilancio, filter, freshvalue);
        if (cmbBilancio.Items.Count == 2) {
            cmbBilancio.SelectedIndex = 1;
        }

    }
    void AggiornaFinTitle(bool setRow) {
        if (cmbBilancio.SelectedValue != null && cmbBilancio.SelectedValue != "0") {
            if (DS.finview.Select().Length > 0) {
                txtfintitle.Text = DS.finview.Select(QHC.CmpEq("idfin", cmbBilancio.SelectedValue))[0]["title"].ToString();
            }
            if (setRow && !this.PState.IsEmpty && CommFun.DrawStateIsDone) DS.lcardvar.Rows[0]["idfin"] = cmbBilancio.SelectedValue;
        }
        if (cmbBilancio.SelectedValue == "0") {
            if (setRow && PState.InsertMode && !PState.IsFirstFillForThisRow && CommFun.DrawStateIsDone) DS.lcardvar.Rows[0]["idfin"] = 0;
        }
    }

    public override void AfterRowSelect(DataTable T, DataRow R) {

        if (T.TableName == "upb") {
            if (R != null) {
                if ((!PState.IsEmpty && CommFun.DrawStateIsDone) || (PState.InsertMode && PState.IsFirstFillForThisRow)) {
                    DS.lcardvar.Rows[0]["idupb"] = R["idupb"];
                }
                txtUpbTitle.Text = R["title"].ToString();
                SelectUPB(R["idupb"], false);
            }
            else {
                if (!PState.IsEmpty && CommFun.DrawStateIsDone) {
                    DS.lcardvar.Rows[0]["idupb"] = "0";
                }
                txtUpbTitle.Text = "";
            }
            AggiornaFinTitle(false);

        }
        if (T.TableName == "finview") {
            if (R != null) {
                if ((!PState.IsEmpty && CommFun.DrawStateIsDone) || (PState.InsertMode && PState.IsFirstFillForThisRow)) {
                    DS.lcardvar.Rows[0]["idfin"] = R["idfin"];
                }
                txtfintitle.Text = R["title"].ToString();
            }
            else {
                if (!PState.IsEmpty && CommFun.DrawStateIsDone) {
                    DS.lcardvar.Rows[0]["idfin"] = "0";
                }
                txtfintitle.Text = "";
            }
        }
    }
}
