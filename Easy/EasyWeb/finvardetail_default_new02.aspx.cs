
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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

public partial class finvardetail_default_new02 : MetaPage {
    vistaForm_finvardetail DS;
    string filteresercizio;
    bool rdbEntrataPreviousStatus;
    bool rdbSpesaPreviousStatus;
    public override DataSet GetDataSet() {
        return DS;
    }

    public override DataSet CreateNewDataSet() {
        return new vistaForm_finvardetail();
    }

    public override void SetDataSet(DataSet D) {
        DS = (vistaForm_finvardetail)D;
    }
    bool parentisapproved = false;

    int varkind = 0;
    bool isprev_iniziale() {
        return (varkind == 5);
    }

    private bool mustshowmovimento = false;
    public override void AfterLink(bool firsttime, bool formToLink) {
        parentisapproved = false;
        Meta.Name = "Dettaglio richiesta variazione";

        //PanelBilancio.Tag="AutoChoose.txtCodiceBilancio.default.(" + filteresercizio + ")";
       
        GetData.SetSorting(DS.finview, "codefin asc, title asc");
        SetFilterFinView();
        txtCodiceBilancio.LeaveTextBoxHandler += txtCodiceBilancio_LeaveTextBoxHandler;

        DataRow rFinvardetail = Meta.SourceRow;
        DataRow rFinvar = rFinvardetail.Table.DataSet.Tables["finvar"].Rows[0];
        int CurrentStatus = CfgFn.GetNoNullInt32(rFinvar["idfinvarstatus"]);
        if (CurrentStatus == 5)
            parentisapproved = true;
        if (rFinvar.RowState == DataRowState.Modified) {
            int OriginalStatus = CfgFn.GetNoNullInt32(rFinvar["idfinvarstatus", DataRowVersion.Original]);
            if (OriginalStatus == 5)
                parentisapproved = true;
        }
        DataRow DR = Meta.SourceRow;
        
        ImpostaTageFiltriUPB( DR["idupb"]);

        varkind = CfgFn.GetNoNullInt32(rFinvar["variationkind"]);
        mustshowmovimento = false;
        if (isprev_iniziale()) {
            Meta.Name = "Richiesta previsione iniziale";
            divPrevisioni.Visible = true;
            panelImporto.Visible = false;
            PnlVariazione.Tag = "";
            TipoVar1.Tag = "";
            TipoVar2.Tag = "";
            txtImporto.Tag = "";

            int anno = CfgFn.GetNoNullInt32(Conn.GetSys("esercizio"));
            int anno2 = anno + 1;
            int anno3 = anno + 2;
            txtAnno1.Text = anno.ToString();
            txtAnno2.Text = anno2.ToString();
            txtAnno3.Text = anno3.ToString();

            object fase1 = Conn.DO_READ_VALUE("expensephase", "nphase=1", "description").ToString();
            HwChkCreaExpense.Text = "Richiedi " + fase1.ToString();
            HelpForm.SetDenyNull(DS.finvardetail.Columns["createexpense"], true);
            mustshowmovimento = true;

            if (rFinvardetail["idexp"].ToString() == "") {
                labMovimento.Visible = false;
                HwChkCreaExpense.Visible = true;

            }
            else {
                HwChkCreaExpense.Visible = false;
                labMovimento.Visible = true;
            }



        }
        else {
            divPrevisioni.Visible = false;
            HwTextAnno1.Tag = "";
            HwTextAnno2.Tag = "";
            HwTextAnno3.Tag = "";
            HwChkCreaExpense.Visible = false;
            labMovimento.Visible = false;
        }
    }


    public override void AfterClear() {
        SetFilterFinView();
    }

    protected override void OnPreRender(EventArgs e) {

        base.OnPreRender(e);
    }

    public override void AfterRowSelect(DataTable T, DataRow R) {
        /*
        if (T.TableName == "upb")
        {
            object idupb = "0001";
            if (R != null)
                idupb = R["idupb"];
            commonfun.WebAutoInfo AI;
            AI = this.CommFun.GetAutoInfo(txtCodiceBilancio.ID);
            string filter = QHS.CmpEq("idupb", idupb);
            if (AI != null) AI.startfilter = filter;
            DS.finview.ExtendedProperties[MetaData.ExtraParams] = filter;
        }
        */
        SetFilterFinView();

    }

    public override void AfterFill() {
        if (PState.InsertMode && TipoVar1.Checked == false && TipoVar2.Checked == false) {
            TipoVar1.Checked = true;
        }

        //if (parentisapproved)
        //{
        //    btnUpb.Enabled = false;
        //    btnBilancio.Enabled = false;
        //    btnFinanziamento.Enabled = false;
        //}
        //else
        //{
        //    btnUpb.Enabled = true;
        //    btnBilancio.Enabled = true;
        //    btnFinanziamento.Enabled = true;
        //}

        if (DS.finview.Rows.Count == 0) {
            rdbEntrata.Checked = rdbEntrataPreviousStatus;
            rdbSpesa.Checked = rdbSpesaPreviousStatus;
        }

        DataRow Curr = DS.finvardetail.Rows[0];
        if (Curr != null) {
            Decimal amount;
            Decimal limit;

            //img_Semaphore.Visible = true;

            if (Curr["limit"] != DBNull.Value) {
                amount = CfgFn.GetNoNullDecimal(Curr["amount"]);
                limit = CfgFn.GetNoNullDecimal(Curr["limit"]);
                if (amount > limit) {
                    img_Red.Visible = true;
                    img_Green.Visible = false;
                    LimSuperato.Visible = true;
                }
                else {
                    img_Red.Visible = false;
                    img_Green.Visible = true;
                    LimSuperato.Visible = false;
                }
            }
            else {
                img_Green.Visible = true;
                LimSuperato.Visible = false;
            }

        }

        if (DS.expenseview.Rows.Count > 0) {
            DataRow eRow = DS.expenseview.Rows[0];
            string mov = eRow["phase"].ToString() + " n." + eRow["nmov"].ToString();
            labMovimento.Text = "Creato " + mov;
            labMovimento.Visible = true;
        }
        else {
            labMovimento.Visible = false;
        }

        if (mustshowmovimento && rdbSpesa.Checked) {
            HwChkCreaExpense.Visible = true;
        }
        else {
            HwChkCreaExpense.Visible = false;
            HwChkCreaExpense.Checked = false;
        }
        SetFilterFinView();
    }


    protected void Page_Load(object sender, EventArgs e) {
        //txtCodiceBilancio.LeaveTextBoxHandler+=new EventHandler(txtCodiceBilancio_LeaveTextBoxHandler);
        //rdbEntrata.CheckedChanged += new EventHandler(rdbEntrata_CheckedChanged);
        //rdbSpesa.CheckedChanged += new EventHandler(rdbSpesa_CheckedChanged);
        rdbEntrataPreviousStatus = rdbEntrata.Checked;
        rdbSpesaPreviousStatus = rdbSpesa.Checked;
        SetFilterFinView();

    }


    public void txtCodiceBilancio_LeaveTextBoxHandler(object sender, EventArgs e) {
        //SetFilterFinView();
        DataRow Curr = null;
        if (DS.finvardetail.Rows.Count > 0)
            Curr = DS.finvardetail.Rows[0];
        if (txtCodiceBilancio.Text.Trim() == "") {
            //SvuotaFinView();
            if (Curr != null)
                Curr["idfin"] = 0;
            return;
        }

        string finpart = "";
        if (rdbSpesa.Checked) {
            finpart = "S";
        }
        if (rdbEntrata.Checked) {
            finpart = "E";
        }
        if (finpart == "")
            return;

        string filterUpb = "";
        object idupb = DBNull.Value;
        if (Curr != null) {
            idupb = Curr["idupb"];
        }
        if (idupb != DBNull.Value) {
            filterUpb = QHS.CmpEq("idupb", idupb);
        }
        else {
            filterUpb = QHS.CmpEq("idupb", "0001");
        }

        string filtro = QHS.AppAnd(filteresercizio, QHS.CmpEq("finpart", finpart), filterUpb);

        CommFun.Manage("manage.finview.tree" + finpart.ToLower() + "upb." + filtro, "codefin", txtCodiceBilancio.Text.Trim(), null);
        //CommFun.DoMainCommand("manage.finview.tree"+finpart.ToLower()+"upb."+filtro);
        return;
    }

    private void SetFilterFinView() {
        string filter;
        int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));

        //string filteroperativo = "(idfin in (SELECT idfin from finusable where ayear='" +
        //  esercizio + "'))";
        //GetData.SetStaticFilter(DS.finview, filteroperativo);

        filteresercizio = QHS.CmpEq("ayear", esercizio);

        object idupb = DBNull.Value;
        if (DS.finvardetail.Rows.Count > 0) {
            DataRow r = DS.finvardetail.Rows[0];
            idupb = r["idupb"];
        }
        if (idupb != DBNull.Value) {
            filter = QHS.CmpEq("idupb", idupb);
        }
        else {
            filter = QHS.CmpEq("idupb", "0001");
        }

        //string mergedFilter = QHS.AppAnd(filteroperativo, filter, filteresercizio);
        string mergedFilter = QHS.AppAnd(filter, filteresercizio);
        GetData.SetStaticFilter(DS.finview, mergedFilter);
    }


    public void rdb_CheckedChanged(object sender, EventArgs e) {
        DS.finview.Clear();
        DS.finvardetail.Rows[0]["idfin"] = 0;
        SetFilterFinView();

        if (mustshowmovimento && rdbSpesa.Checked) {
            HwChkCreaExpense.Visible = true;
        }
        else {
            HwChkCreaExpense.Visible = false;
            HwChkCreaExpense.Checked = false;
        }
    }
    public override void DoCommand(string command) {
        if (command == "sceglibilancio") {
            ScegliBilancio();
            return;
        }
    }

    protected void ScegliBilancio() {
        string filter;
        int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
        string filteridfin = "";
        if (rdbSpesa.Checked)
            filteridfin = QHS.AppAnd(filteresercizio, QHS.CmpEq("finpart", 'S'));
        if (rdbEntrata.Checked)
            filteridfin = QHS.AppAnd(filteresercizio, QHS.CmpEq("finpart", 'E'));

        //Il filtro sull'UPB c'è sempre
        object idupb = DBNull.Value;
        if (DS.finvardetail.Rows.Count > 0) {
            DataRow r = DS.finvardetail.Rows[0];
            idupb = r["idupb"];
        }
        if (idupb != DBNull.Value) {
            filter = QHS.CmpEq("idupb", idupb);
        }
        else {
            filter = QHS.CmpEq("idupb", "0001");
        }

        filter = QHS.AppAnd(filteridfin, filter);


        //string filteroperativo = "(idfin in (SELECT idfin from finusable where ayear='" +
        //    esercizio + "'))";


        // Versione con DoMainCommand
        DS.finview.ExtendedProperties[MetaData.ExtraParams] = filter;

        if (rdbSpesa.Checked)
            CommFun.DoMainCommand("manage.finview.treesupb");
        if (rdbEntrata.Checked)
            CommFun.DoMainCommand("manage.finview.treeeupb");


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
            btnUpb.Tag = "choose.upb.default." + filteractive;
        }
        else {
            btnUpb.Tag = "manage.upb.tree";
        }
        if (PanelUpb.Tag != null)
            PanelUpb.Tag = "AutoChoose.txtCodiceUPB.default." + filteractive;
        CommFun.SetAutoMode(PanelUpb);
    }

    private string CalcolaFiltroUPB() {
        string filter_upb = "";
        object codiceresponsabile = Session["CodiceResponsabile"];
        if (codiceresponsabile == null) codiceresponsabile = DBNull.Value;        
        if (codiceresponsabile != DBNull.Value) {
            filter_upb = QHS.AppAnd(filter_upb, QHS.NullOrEq("idman", codiceresponsabile));
        }
        return filter_upb;
    }
}
