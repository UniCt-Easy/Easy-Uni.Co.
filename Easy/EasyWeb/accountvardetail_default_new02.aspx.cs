
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

public partial class accountvardetail_default_new02 : MetaPage {
    vistaForm_accountvardetail DS;
    string filteresercizio;
    bool rdbEntrataPreviousStatus;
    bool rdbSpesaPreviousStatus;
    public override DataSet GetDataSet() {
        return DS;
    }

    public override DataSet CreateNewDataSet() {
        return new vistaForm_accountvardetail();
    }

    public override void SetDataSet(DataSet D) {
        DS = (vistaForm_accountvardetail)D;
    }
    bool parentisapproved = false;

    int varkind = 0;
    bool isprev_iniziale() {
        return (varkind == 5);
    }

    public void HwTextAnno_LeaveTextBoxHandler(object sender, EventArgs e) {
        CalcolaTotale(CommFun.DrawStateIsDone);
    }
    
     public override void AfterLink(bool firsttime, bool formToLink) {
        parentisapproved = false;
        Meta.Name = "Dettaglio richiesta variazione";
        HwTextAnno1.LeaveTextBoxHandler += HwTextAnno_LeaveTextBoxHandler;
        HwTextAnno2.LeaveTextBoxHandler += HwTextAnno_LeaveTextBoxHandler;
        HwTextAnno3.LeaveTextBoxHandler += HwTextAnno_LeaveTextBoxHandler;
        HwTextAnno4.LeaveTextBoxHandler += HwTextAnno_LeaveTextBoxHandler;
        HwTextAnno5.LeaveTextBoxHandler += HwTextAnno_LeaveTextBoxHandler;
        DataRow DR = Meta.SourceRow;
        ImpostaTageFiltriUPB(DR["idupb"]);
        
        DS.accountminusable.setStaticFilter(QHS.NullOrEq("flagenablebudgetprev","S"));
        GetData.SetSorting(DS.accountminusable, "codeacc asc, title asc");
        SetFilteraccountView();
        txtCodiceConto.LeaveTextBoxHandler += txtCodiceConto_LeaveTextBoxHandler;

        DataRow raccountvardetail = Meta.SourceRow;
        DataRow raccountvar = raccountvardetail.Table.DataSet.Tables["accountvar"].Rows[0];
        int CurrentStatus = CfgFn.GetNoNullInt32(raccountvar["idaccountvarstatus"]);
        if (CurrentStatus == 5)
            parentisapproved = true;
        if (raccountvar.RowState == DataRowState.Modified) {
            int OriginalStatus = CfgFn.GetNoNullInt32(raccountvar["idaccountvarstatus", DataRowVersion.Original]);
            if (OriginalStatus == 5)
                parentisapproved = true;
        }
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

        varkind = CfgFn.GetNoNullInt32(raccountvar["variationkind"]);
        if (isprev_iniziale()) {
            HwLabelCassa.Visible = true;
            hwTextcassa.Visible = true;

        }
        else {
            HwLabelCassa.Visible = false;
            hwTextcassa.Visible = false;

        }

       
        if (formToLink) {
	        DataAccess.SetTableForReading(DS.sorting1, "sorting");
	        DataAccess.SetTableForReading(DS.sorting2, "sorting");
	        DataAccess.SetTableForReading(DS.sorting3, "sorting");
	        DataTable tConfig = Conn.RUN_SELECT("config", "*", null,
		        QHS.CmpEq("ayear", Meta.GetSys("esercizio")), null, null, true);

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
            cmbFinanziamento.DataSource = DS.tipomovimento;
            cmbFinanziamento.DataTextField = "descrizione";
            cmbFinanziamento.DataValueField = "idtipo";
            cmbFinanziamento.DataBind();
            cmbFinanziamento.SelectedIndex = 0;
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

        bool hasdefault = (DS.accountvardetail.Columns["idsor" + num.ToString()].DefaultValue != DBNull.Value);

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
            if (!hasdefault) {
                gbox.Tag = "AutoManage.txtCodice" + nums + ".tree." + filter;
                btncodice.Tag = "manage.sorting" + nums + ".tree." + filter;
            }
            else {
                txt.ReadOnly = true;
            }
        }
       

    }

    void EnableTipoMovimento(string IDtipo, string descrtipo) {
        DataRow R = DS.tipomovimento.NewRow();
        R["idtipo"] = IDtipo;
        R["descrizione"] = descrtipo;
        DS.tipomovimento.Rows.Add(R);
        DS.tipomovimento.AcceptChanges();
    }

    void ClearComboFonteFinanziamento() {
        DataTable TCombo = DS.tipomovimento;
        TCombo.Clear();
    }

    

    public override void AfterClear() {
        SetFilteraccountView();
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
            AI = this.CommFun.GetAutoInfo(txtCodiceConto.ID);
            string filter = QHS.CmpEq("idupb", idupb);
            if (AI != null) AI.startfilter = filter;
            DS.accountview.ExtendedProperties[MetaData.ExtraParams] = filter;
        }
        */
        SetFilteraccountView();

    }

    public override void AfterFill() {
        if (PState.InsertMode && TipoVar1.Checked == false && TipoVar2.Checked == false) {
            TipoVar1.Checked = true;
        }

        //if (parentisapproved)
        //{
        //    btnUpb.Enabled = false;
        //    btnBilancio.Enabled = false;
        //    btnaccountanziamento.Enabled = false;
        //}
        //else
        //{
        //    btnUpb.Enabled = true;
        //    btnBilancio.Enabled = true;
        //    btnaccountanziamento.Enabled = true;
        //}

        //if (DS.accountview.Rows.Count == 0) {
        //    rdbEntrata.Checked = rdbEntrataPreviousStatus;
        //    rdbSpesa.Checked = rdbSpesaPreviousStatus;
        //}

        SetFilteraccountView();
        CalcolaTotale(false);
    }


    protected void Page_Load(object sender, EventArgs e) {
        SetFilteraccountView();
    }

    public void txtCodiceConto_LeaveTextBoxHandler(object sender, EventArgs e) {
        //SetFilteraccountView();
        DataRow Curr = null;
        if (DS.accountvardetail.Rows.Count > 0)
            Curr = DS.accountvardetail.Rows[0];
        if (txtCodiceConto.Text.Trim() == "") {
            //SvuotaaccountView();
            if (Curr != null)
                Curr["idacc"] = 0;
            return;
        }

        //string filterUpb = "";
        //if (idupb.SelectedIndex > 0) {
        //    filterUpb = QHS.CmpEq("idupb", idupb.SelectedValue);
        //}
        //else {
        //    filterUpb = QHS.CmpEq("idupb", "0001");
        //}

        //string filtro = QHS.AppAnd(filteresercizio, filterUpb);
        //DA RIVEDERE, SARA, perchè c'è accountpart.
        //CommFun.Manage("manage.account.tree", "codeaccount", txtCodiceConto.Text.Trim(), null);
        //CommFun.DoMainCommand("manage.accountview.tree"+accountpart.ToLower()+"upb."+filtro);
        return;
    }

    private void SetFilteraccountView() {
        //string filter;
        int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));

        filteresercizio = QHS.CmpEq("ayear", esercizio);

        //if (idupb.SelectedIndex > 0) {
        //    filter = QHS.CmpEq("idupb", idupb.SelectedValue);
        //}
        //else {
        //    filter = QHS.CmpEq("idupb", "0001");
        //}

        //string mergedFilter = QHS.AppAnd(filter, filteresercizio);
        GetData.SetStaticFilter(DS.accountminusable, filteresercizio);
    }


    public void rdb_CheckedChanged(object sender, EventArgs e) {
        DS.accountminusable.Clear();
        DS.accountvardetail.Rows[0]["idacc"] = 0;
        SetFilteraccountView();

    }
    //public override void DoCommand(string command) {
    //    if (command == "scegliconto") {
    //        ScegliConto();
    //        return;
    //    }
    //}

    //protected void ScegliConto() {
    //    string filter;
    //    int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
    //    string filteridaccount = "";

    //    //Il filtro sull'UPB c'è sempre
    //    if (idupb.SelectedIndex > 0) {
    //        filter = QHS.CmpEq("idupb", idupb.SelectedValue);
    //    }
    //    else {
    //        filter = QHS.CmpEq("idupb", "0001");
    //    }
    //    filter = QHS.AppAnd(filteridaccount, filter);
    //    // Versione con DoMainCommand
    //    DS.accountview.ExtendedProperties[MetaData.ExtraParams] = filter;
    //}

    void CalcolaTotale(bool read) {
        if (PState.IsEmpty)
            return;
        if (DS.accountvardetail.Rows.Count == 0)
            return;
        //if (read)
        //    Meta.GetFormData(true);
        DataRow R = DS.accountvardetail.Rows[0];
        decimal totale = CfgFn.GetNoNullDecimal(R["amount"]);
        for (int i = 2; i <= 5; i++) {
            totale += CfgFn.GetNoNullDecimal(R["amount" + i.ToString()]);
        }
        txtTotale.Text = totale.ToString("c");
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
