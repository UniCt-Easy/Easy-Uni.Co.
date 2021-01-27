
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

public partial class viterbo_finvardetail_default :MetaPage {

    vistaForm_viterbo_finvardetail DS;
    string filteresercizio;
    bool rdbEntrataPreviousStatus;
    bool rdbSpesaPreviousStatus;
    public override DataSet GetDataSet() {
        return DS;
    }

    public override DataSet CreateNewDataSet() {
        return new vistaForm_viterbo_finvardetail();
    }

    public override void SetDataSet(DataSet D) {
        DS = (vistaForm_viterbo_finvardetail)D;
    }
    bool parentisapproved = false;

    int varkind = 0;
    bool isprev_iniziale() {
        return (varkind == 5);
    }

    private bool mustshowmovimento = false;


    void CalcolaTotale(bool read) {
        if (PState.IsEmpty)
            return;
        if (DS.viterbo_finvardetail.Rows.Count == 0)
            return;
        //if (read)
        //    Meta.GetFormData(true);
        DataRow R = DS.viterbo_finvardetail.Rows[0];
        decimal totale = CfgFn.GetNoNullDecimal(R["amount"]);
        for (int i = 2; i <= 5; i++) {
            totale += CfgFn.GetNoNullDecimal(R["prevision" + i.ToString()]);
        }
        txtTotale.Text = totale.ToString("c");
    }

    public void HwTextAnno_LeaveTextBoxHandler(object sender, EventArgs e) {
        CalcolaTotale(CommFun.DrawStateIsDone);
    }
    void EnableTipoMovimento(string IDtipo, string descrtipo) {
        DataRow R = DS.tipomovimento.NewRow();
        R["idtipo"] = IDtipo;
        R["descrizione"] = descrtipo;
        DS.tipomovimento.Rows.Add(R);
        DS.tipomovimento.AcceptChanges();
    }
    public override void AfterLink(bool firsttime, bool formToLink) {
        parentisapproved = false;
        Meta.Name = "Dettaglio richiesta variazione";
        HwTextAnno1.LeaveTextBoxHandler += HwTextAnno_LeaveTextBoxHandler;
        HwTextAnno2.LeaveTextBoxHandler += HwTextAnno_LeaveTextBoxHandler;
        HwTextAnno3.LeaveTextBoxHandler += HwTextAnno_LeaveTextBoxHandler;
        HwTextAnno4.LeaveTextBoxHandler += HwTextAnno_LeaveTextBoxHandler;
        HwTextAnno5.LeaveTextBoxHandler += HwTextAnno_LeaveTextBoxHandler;

        GetData.SetSorting(DS.accountminusable, "codeacc asc, title asc");
        SetFilteraccountView();
        txtCodiceConto.LeaveTextBoxHandler += txtCodiceConto_LeaveTextBoxHandler;

        GetData.SetSorting(DS.finview, "codefin asc, title asc");
        SetFilterFinView();
        txtCodiceBilancio.LeaveTextBoxHandler += txtCodiceBilancio_LeaveTextBoxHandler;
        DataAccess.SetTableForReading(DS.upb_procedureman, "upb");
        GetData.MarkSkipSecurity(DS.upb_procedureman);
        DataRow rFinvardetail = Meta.SourceRow;
        DataRow rFinvar = rFinvardetail.Table.DataSet.Tables["viterbo_finvar"].Rows[0];
        int CurrentStatus = CfgFn.GetNoNullInt32(rFinvar["idfinvarstatus"]);
        if (CurrentStatus == 5)
            parentisapproved = true;
        if (rFinvar.RowState == DataRowState.Modified) {
            int OriginalStatus = CfgFn.GetNoNullInt32(rFinvar["idfinvarstatus", DataRowVersion.Original]);
            if (OriginalStatus == 5)
                parentisapproved = true;
        }
        DataRow DR = Meta.SourceRow;

        ImpostaTageFiltriUPB(DR["idupb"]);
        ImpostaTageFiltriUPB_Procedureman(DR["idupb_procedureman"]);
        DS.costpartition.setSorting("title asc");
        DS.underwriting.setSorting("title asc");

        

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
            grpImporto1.GroupingText = "Importo Var." + anno.ToString();

            int anno2 = anno + 1;
            grpImporto2.GroupingText = "Importo Var." + anno2.ToString();

            int anno3 = anno + 2;
            grpImporto3.GroupingText = "Importo Var." + anno3.ToString();

            int anno4 = anno + 3;
            grpImporto4.GroupingText = "Importo Var." + anno4.ToString();

            int anno5 = anno + 4;
            grpImporto5.GroupingText = "Importo Var." + anno5.ToString();



            object fase1 = Conn.DO_READ_VALUE("expensephase", "nphase=1", "description").ToString();
            HwChkCreaExpense.Text = "Richiedi " + fase1.ToString();
            HelpForm.SetDenyNull(DS.viterbo_finvardetail.Columns["createexpense"], true);
            mustshowmovimento = true;

            if (rFinvardetail["idexp"].ToString() == "") {
                labMovimento.Visible = false;
                HwChkCreaExpense.Visible = true;

            }
            else {
                HwChkCreaExpense.Visible = false;
                labMovimento.Visible = true;
            }

            HwLabelCassa.Visible = true;
            hwTextcassa.Visible = true;

        }
        else {
            divPrevisioni.Visible = false;
            HwTextAnno1.Tag = "";
            HwTextAnno2.Tag = "";
            HwTextAnno3.Tag = "";
            HwTextAnno4.Text = "";
            HwTextAnno5.Text = "";
            HwChkCreaExpense.Visible = false;
            labMovimento.Visible = false;
            HwLabelCassa.Visible = false;
            hwTextcassa.Visible = false;
        }

        DataAccess.SetTableForReading(DS.sorting1, "sorting");
        DataAccess.SetTableForReading(DS.sorting2, "sorting");
        DataAccess.SetTableForReading(DS.sorting3, "sorting");

        DataTable tConfig = Conn.RUN_SELECT("config", "*", null, QHS.CmpEq("ayear", Meta.GetSys("esercizio")), null, null, true);

        if ((tConfig != null) && (tConfig.Rows.Count > 0)) {
            DataRow R = tConfig.Rows[0];
            object idsorkind1 = R["idsortingkind1"];
            object idsorkind2 = R["idsortingkind2"];
            object idsorkind3 = R["idsortingkind3"];
            SetGBoxClass(1, idsorkind1);
            SetGBoxClass(2, idsorkind2);
            SetGBoxClass(3, idsorkind3);
            if (idsorkind1 == DBNull.Value) {
                gboxclass1.Enabled = false;

            }
            if (idsorkind2 == DBNull.Value) {
                gboxclass2.Enabled = false;

            }
            if (idsorkind3 == DBNull.Value) {
                gboxclass3.Enabled = false;

            }
           
        }
        if (formToLink) {
        

            PostData.MarkAsTemporaryTable(DS.tipomovimento, false);
            GetData.DenyClear(DS.tipomovimento);
            GetData.LockRead(DS.tipomovimento);
            if (firsttime) {
                GetData.MarkToAddBlankRow(DS.tipomovimento);
                GetData.Add_Blank_Row(DS.tipomovimento);
                EnableTipoMovimento("C", "Contributi da Terzi");
                EnableTipoMovimento("I", "Risorse da indebitamento");
                EnableTipoMovimento("P", "Risorse Proprie");
            }
            cmbCausale.DataSource = DS.tipomovimento;
            cmbCausale.DataValueField = "idtipo";
            cmbCausale.DataTextField = "descrizione";
            cmbCausale.DataBind();
            cmbCausale.SelectedIndex = 0;

        }
      
    }

    void SetGBoxClass(int num, object sortingkind) {
        string nums = num.ToString();
        hwPanel gbox = new hwPanel();
        hwButton btncodice = new hwButton();
        //HtmlGenericControl gboxlabel = new HtmlGenericControl();
        hwTextBox txt = new hwTextBox();
        hwTextBox denom = new hwTextBox();
        switch (num) {
        case 1:
            gbox = gboxclass1;
            btncodice = btnCodice1;
            //gboxlabel = gboxlabel1;
            txt = txtCodice1;
            denom = txtDenom1;
            break;
        case 2:
            gbox = gboxclass2;
            btncodice = btnCodice2;
            //gboxlabel = gboxlabel2;
            txt = txtCodice2;
            denom = txtDenom2;
            break;
        case 3:
            gbox = gboxclass3;
            btncodice = btnCodice3;
            //gboxlabel = gboxlabel3;
            txt = txtCodice3;
            denom = txtDenom3;

            break;
        }

        bool hasdefault = (DS.viterbo_finvardetail.Columns["idsor" + num.ToString()].DefaultValue != DBNull.Value);

        if (sortingkind == DBNull.Value) {
            gbox.Enabled = false;
            btncodice.Enabled = false;
            txt.Enabled = false;
            txt.Visible = false;
            btncodice.Visible = false;
            denom.Visible = false;
            gbox.Visible = false;
            gbox.GroupingText = "";
        }
        else {
	        string filter = QHS.AppAnd(QHS.CmpEq("idsorkind", sortingkind),
		        QHS.NullOrLt("start", Conn.Security.GetEsercizio()),
		        QHS.NullOrGe("stop", Conn.Security.GetEsercizio()));
	        GetData.SetStaticFilter(DS.Tables["sorting" + nums], filter);
	        DS.Tables["sorting" + nums].ExtendedProperties[MetaData.ExtraParams] = filter;
            string title = Conn.DO_READ_VALUE("sortingkind", filter, "description").ToString();
            gbox.GroupingText = title;
            string idflowchart = Conn.GetSys("idflowchart").ToString();
            string filterSec = QHS.CmpEq("idflowchart", idflowchart);

            if (!hasdefault) {
                if (filterSec != null) {
                    btncodice.Tag = "choose.sorting" + nums + ".treeusable." + filter;
                }
                else {
                    btncodice.Tag = "manage.sorting" + nums + ".tree." + filter;
                }
                gbox.Tag = "AutoChoose.txtCodice" + nums + ".treeusable." + filter;

            }
            else {
                txt.ReadOnly = true;
            }
            DS.Tables["sorting" + nums].ExtendedProperties[MetaData.ExtraParams] = filter;
        }
    }

    public override void AfterClear() {
        SetFilterFinView();
    }

    protected override void OnPreRender(EventArgs e) {
        base.OnPreRender(e);
    }

    public override void AfterRowSelect(DataTable T, DataRow R) {
        SetFilterFinView();
    }

    public override void AfterFill() {
        if (PState.InsertMode && TipoVar1.Checked == false && TipoVar2.Checked == false) {
            TipoVar1.Checked = true;
        }

        if (DS.finview.Rows.Count == 0) {
            rdbEntrata.Checked = rdbEntrataPreviousStatus;
            rdbSpesa.Checked = rdbSpesaPreviousStatus;
        }

        DataRow Curr = DS.viterbo_finvardetail.Rows[0];
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
        rdbEntrataPreviousStatus = rdbEntrata.Checked;
        rdbSpesaPreviousStatus = rdbSpesa.Checked;
        SetFilterFinView();

    }

    public void txtCodiceBilancio_LeaveTextBoxHandler(object sender, EventArgs e) {
        DataRow Curr = null;
        if (DS.viterbo_finvardetail.Rows.Count > 0)
            Curr = DS.viterbo_finvardetail.Rows[0];
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
        return;
    }

    private void SetFilterFinView() {
        string filter;
        int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));

        filteresercizio = QHS.CmpEq("ayear", esercizio);

        object idupb = DBNull.Value;
        if (DS.viterbo_finvardetail.Rows.Count > 0) {
            DataRow r = DS.viterbo_finvardetail.Rows[0];
            idupb = r["idupb"];
        }
        if (idupb != DBNull.Value) {
            filter = QHS.CmpEq("idupb", idupb);
        }
        else {
            filter = QHS.CmpEq("idupb", "0001");
        }

        string mergedFilter = QHS.AppAnd(filter, filteresercizio);
        GetData.SetStaticFilter(DS.finview, mergedFilter);
    }

    public void rdb_CheckedChanged(object sender, EventArgs e) {
        DS.finview.Clear();
        DS.viterbo_finvardetail.Rows[0]["idfin"] = 0;
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
        //if (command == "scegliconto") {
        //    btnConti_Click();
        //    return;
        //}
        
    }

    private void SetFilteraccountView() {
        int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
        filteresercizio = QHS.CmpEq("ayear", esercizio);
        GetData.SetStaticFilter(DS.accountminusable, filteresercizio);
    }
    public void txtCodiceConto_LeaveTextBoxHandler(object sender, EventArgs e) {
        //SetFilteraccountView();
        DataRow Curr = null;
        if (DS.viterbo_finvardetail.Rows.Count > 0)
            Curr = DS.viterbo_finvardetail.Rows[0];
        if (txtCodiceConto.Text.Trim() == "") {
            //SvuotaaccountView();
            if (Curr != null)
                Curr["idacc"] = 0;
            return;
        }

        return;
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
        if (DS.viterbo_finvardetail.Rows.Count > 0) {
            DataRow r = DS.viterbo_finvardetail.Rows[0];
            idupb = r["idupb"];
        }
        if (idupb != DBNull.Value) {
            filter = QHS.CmpEq("idupb", idupb);
        }
        else {
            filter = QHS.CmpEq("idupb", "0001");
        }

        filter = QHS.AppAnd(filteridfin, filter);

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

    private void ImpostaTageFiltriUPB_Procedureman(object idupbToinclude) {
        string upbfilter = "";// CalcolaFiltroUPB();
        string filteradd = upbfilter;
        string filteractive = QHS.AppAnd(upbfilter, QHS.CmpEq("active", "S"));

        if (idupbToinclude != DBNull.Value && upbfilter != "") {
            filteradd = QHS.DoPar(QHS.AppOr(QHS.CmpEq("idupb_procedureman", idupbToinclude), QHS.DoPar(upbfilter)));
        }

        GetData.SetStaticFilter(DS.upb_procedureman, filteradd);

        if (upbfilter != "") {
            btnUpb_RespProcedimento.Tag = "choose.upb_procedureman.default." + filteractive;
        }
        else {
            btnUpb_RespProcedimento.Tag = "manage.upb_procedureman.treenosec";
        }
        if (PanelUpb_RespProcedimento.Tag != null)
            PanelUpb_RespProcedimento.Tag = "AutoChoose.txtCodiceUPB_RespProcedimento.default." + filteractive;
        CommFun.SetAutoMode(PanelUpb_RespProcedimento);
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
