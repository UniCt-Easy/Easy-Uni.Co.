/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using funzioni_configurazione;
using HelpWeb;
using metadatalibrary;
using metaeasylibrary;
using AllDataSet;
using EasyWebReport;
using itinerationFunctions;


public partial class itinerationrefund_default_new02 : MetaPage {
    vistaForm_itinerationrefund DS;
    CfgItineration Cfg;
    CQueryHelper QHC;
    QueryHelper QHS;
    DataRow ParentMissione;

    public override DataSet GetDataSet() {
        return DS;
    }
    public override DataSet CreateNewDataSet() {
        return new vistaForm_itinerationrefund();
    }
    public override void SetDataSet(DataSet D) {
        DS = (vistaForm_itinerationrefund)D;
    }


    public override void AfterLink(bool firsttime, bool formToLink) {
        Meta.Name = "Rimborso spese";
        if (formToLink) {
            cmbClassificazione.DataSource = DS.itinerationrefundkind;
            cmbClassificazione.DataValueField = "iditinerationrefundkind";
            cmbClassificazione.DataTextField = "description";

            cmbValuta.DataSource = DS.currency;
            cmbValuta.DataValueField = "idcurrency";
            cmbValuta.DataTextField = "description";

            cmbArea.DataSource = DS.foreigncountry;
            cmbArea.DataValueField = "idforeigncountry";
            cmbArea.DataTextField = "description";
        }
        QHC = new CQueryHelper();
        QHS = Meta.Conn.GetQueryHelper();

        txtImportoEffettivoEUR.wantsID = true;
        txtImportoEffettivoValuta.wantsID = true;
        txtCambio.wantsID = true;
        txtImportoRichiestoValuta.wantsID = true;
        txtImportoRichiestoEUR.wantsID = true;
        txtImportoDocValuta.wantsID = true;
        txtImportoDocEUR.wantsID = true;
        txtLimiteMax.wantsID = true;
        HelpForm.SetFormatForColumn(DS.itinerationrefund.Columns["stoptime"], "g");
        HelpForm.SetFormatForColumn(DS.itinerationrefund.Columns["starttime"], "g");

        string filterKind = "";
        Cfg = (CfgItineration)Meta.ExtraParameter;
        if (Meta.edit_type == "advancenew02") {
            //containerdocumento.Style.Add("display", "none"); //TODO : ho commentato questa istruzione, e sostituita con la successiva
            grpDocCollegato.Style.Add("display", "none");

            //MetaData.SetDefault(DS.itinerationrefund, "flagadvancebalance", "A");
            grpDocCollegato.Visible = false;
            //MakeSpaceFrom(grpDocCollegato); ?? A che serve 
            ParentMissione = Meta.SourceRow.GetParentRow("itinerationitinerationrefund");
            filterKind = QHS.CmpEq("flagadvance", "S");
            //GetData.SetStaticFilter(DS.itinerationrefundkind, QHS.CmpEq("flagadvance","S"));
            //if ((DateTime)Meta.GetSys("datacontabile") >= (DateTime)Meta.SourceRow["stoptime"])

            if (((DateTime)Meta.GetSys("datacontabile") >= (DateTime)Meta.SourceRow["stoptime"]))
                EnableDisableControls(false, true); //? Implementare
        }
        else {
            //containeranticipo.Style.Add("display", "none");//TODO : ho commentato questa istruzione, e sostituita con la successiva
            grpAnticipo.Style.Add("display", "none");
                
            //MetaData.SetDefault(DS.itinerationrefund, "flagadvancebalance", "S");
            grpAnticipo.Visible = false;
            ParentMissione = Meta.SourceRow.GetParentRow("itineration_itinerationrefund_balance");
            filterKind = QHS.CmpEq("flagbalance", "S");
            //GetData.SetStaticFilter(DS.itinerationrefundkind, QHS.CmpEq("flagbalance", "S"));
            // Se stiamo nella fase Saldo, e lo stato è diverso da Bozza o Da correggere, le spese
            // a rendiconto devono essere consultabili
            if ((CfgFn.GetNoNullInt32(ParentMissione["iditinerationstatus"]) != 1) && (CfgFn.GetNoNullInt32(ParentMissione["iditinerationstatus"]) != 3)) {
                EnableDisableControls(false, true);
            }
        }
        grpApplicabilita.Enabled = false;
        if (ParentMissione["idauthmodel"] != DBNull.Value) {
            string filterAuthModel = QHS.FieldInList("iditinerationrefundkind",
                "SELECT iditinerationrefundkind from authmodelitinerationrefundkind where " +
                QHS.CmpEq("idauthmodel", ParentMissione["idauthmodel"]));
            filterKind = QHS.AppAnd(filterKind, filterAuthModel);
        }
        GetData.SetStaticFilter(DS.itinerationrefundkind, filterKind);
        txtCambio.TextChanged += txtCambio_LeaveTextBoxHandler;
        txtCambio.AutoPostBack = true;
        txtDataInizio.TextChanged += txtDataInizio_LeaveTextBoxHandler;
        txtDataInizio.AutoPostBack = true;
        txtDataFine.TextChanged += txtDataFine_LeaveTextBoxHandler;
        txtDataFine.AutoPostBack = true;
        txtImportoDocValuta.TextChanged += txtImportoDocValuta_LeaveTextBoxHandler;
    }


    public void txtCambio_LeaveTextBoxHandler(object sender, EventArgs e) {
        ConvertiFromValuta(txtImportoRichiestoEUR, txtImportoRichiestoValuta);
        ConvertiFromValuta(txtImportoEffettivoEUR, txtImportoEffettivoValuta);
        ConvertiFromValuta(txtImportoDocEUR, txtImportoDocValuta);

        return;
    }

    void EnableDisableControls(bool enable, bool advance) {
        cmbClassificazione.Enabled = enable;
        btnClassificazione.Enabled = enable;

        grpDatiGenerali.Enabled = enable;
        grpDocCollegato.Enabled = enable;
        if (!advance) {
            txtImportoRichiestoValuta.Enabled = enable;
            txtImportoRichiestoEUR.Enabled = enable;
        }
        else {
            grpImporti.Enabled = enable;
            txtComunicazioni.Enabled = enable;
        }
        grpLimite.Enabled = enable;
        grpLocalita.Enabled = enable;
        grpAnticipo.Enabled = enable;
    }

    public override void AfterActivation(bool firsttime, bool formToLink) {
        string filter = MissFun.GetQualificaClasseFilter(Cfg.idposition, Cfg.incomeclass);

        if (filter == null || filter == "")
            return; // || Meta.InsertMode
        DataRow Curr = DS.itinerationrefund.Rows[0];
        //string MyFilter = "(iditinerationrefundkind="+
        //    QueryCreator.quotedstrvalue(Curr["iditinerationrefundkind"], true)+") AND "+
        //    filter;

        if (firsttime && ParentMissione.RowState != DataRowState.Added && (Meta.edit_type == "advancenew02")) {
            string ff = QHS.AppAnd(QHS.MCmp(Curr, "iditineration"), QHS.CmpNe("movkind", 4));
            int N = Meta.Conn.RUN_SELECT_COUNT("expenseitineration", ff, false);
            ff = QHS.MCmp(Curr, "iditineration");
            N += Meta.Conn.RUN_SELECT_COUNT("pettycashoperationitineration", ff, false);
            if (N > 0)
                ShowClientMessage(
                    "Avendo già contabilizzato l'anticipo di questa missione, le modifiche alle spese " +
                    "non saranno tenute in considerazione ai fini del calcolo dell'anticipo della missione.", "Avviso");
        }
    }

    void nascondiSezioni(int flagVisible) {
        //valuta
        grpCambio.Visible = (flagVisible & 32) == 0;

        if (!grpCambio.Visible) {
            txtImportoRichiestoValuta.Visible = false;
            //txtImportoRichiestoEUR.ReadOnly = false;
            txtImportoRichiestoEUR.Attributes.Remove("readonly");
        }
        else {
            txtImportoRichiestoValuta.Visible = true;
            //txtImportoRichiestoEUR.ReadOnly = true;
            txtImportoRichiestoEUR.Attributes.Remove("readonly");
            txtImportoRichiestoEUR.Attributes.Add("readonly", "readonly");
        }
        
        //sezione documento
        grpDocCollegato.Visible=(flagVisible & 1) == 0;
        if (grpDocCollegato.Visible) {
            grpEtichetteDescrValuta.Visible = grpCambio.Visible;
            if (!grpCambio.Visible) {
                txtImportoDocValuta.Visible = false;
                //txtImportoDocEUR.ReadOnly = false;
                txtImportoDocEUR.Attributes.Remove("readonly");
            }
            else {
                txtImportoDocValuta.Visible = true;
                //txtImportoDocEUR.ReadOnly = true;
                txtImportoDocEUR.Attributes.Remove("readonly");
                txtImportoDocEUR.Attributes.Add("readonly", "readonly");
            }
        }
    
        grpAnticipo.Visible=(flagVisible & 256) == 0 && (Meta.edit_type=="advancenew02");

        //inizio e fine
        grpDataInizioFine.Visible=(flagVisible & 2) == 0;

        //località
        grpLocalita.Visible = (flagVisible & 4) == 0;

        // importo non rendicontabile
        PanelImportoNonRendicontabile.Visible = (flagVisible & 8) == 0;

        //importo accordato
        grpImportoAccordato.Visible=(flagVisible & 16) == 0;
        etichetteDescrizioneImporto.Visible = grpCambio.Visible;

        //limiti di spesa
        grpLimite.Visible = (flagVisible & 64) == 0;
        
        grpResponsabile.Visible = (flagVisible & 128) == 0;
    }

    public override void AfterRowSelect(DataTable T, DataRow R) {
        DataRow Curr = DS.itinerationrefund.Rows[0];

        if (T.TableName == "currency") {
            AggiornaValuta(R);
        }

        if (T.TableName == "itinerationrefundkind") {
            if (CommFun.DrawStateIsDone)
                CommFun.GetFormData(true);
            AggiornaPerc(R);
            AggiornaLimite(R);
            AbilitadisabilitaArea(R);
            AggiornaRimborsoForfettario();
            //txtImportoEffettivoValuta.ReadOnly = IsRimborsoForfettario();
            if (!IsRimborsoForfettario() && !IsRimborsoPerVitto()) {
                grpLocalita.Enabled = true;
            }

            if (R != null) {
                nascondiSezioni(CfgFn.GetNoNullInt32(R["flagvisible"]));
            }
        }

        if (T.TableName == "foreigncountry" && CommFun.DrawStateIsDone) {
            AbilitaDisabilitaGrpLocalita(Curr, R);
            AggiornaRimborsoForfettario();
        }
    }

    public override void AfterFill() {
        DataRow Curr = DS.itinerationrefund.Rows[0];
        AggiornaLimite(Curr);
        RicalcolaAnticipo();
        RicalcolaImportoEffettivoValuta();
        if (grpCambio.Visible) {
            txtImportoRichiestoEUR.Attributes.Add("readonly", "readonly");
            txtImportoEffettivoEUR.Attributes.Add("readonly", "readonly");
            txtImportoDocEUR.Attributes.Add("readonly", "readonly");
        }

        if (PState.EditMode && PState.IsFirstFillForThisRow)
            AbilitadisabilitaArea(Curr);
        //txtImportoEffettivoValuta.ReadOnly = IsRimborsoForfettario();

        object idforeigncountry = Curr["idforeigncountry"];
        if (idforeigncountry == DBNull.Value) {
            return;
        }
        else {
            DataRow[] fc = DS.foreigncountry.Select(QHC.CmpEq("idforeigncountry", idforeigncountry));
            AbilitaDisabilitaGrpLocalita(Curr, fc[0]);
        }

    }

    void AbilitaDisabilitaGrpLocalita(DataRow Ritinerationrefund, DataRow Rforeigncountry) {
        if (Rforeigncountry == null) {
            grpLocalita.Enabled = true;
            rdoItaly.Checked = true;
        }
        else {
            Ritinerationrefund["flag_geo"] = Rforeigncountry["flag_ue"];
            if (Rforeigncountry["flag_ue"].ToString() == "U") {
                rdoExtraUe.Checked = false;
                rdoUe.Checked = true;
                rdoItaly.Checked = false;
            }
            else {
                rdoUe.Checked = false;
                rdoItaly.Checked = false;
                rdoExtraUe.Checked = true;
            }
            grpLocalita.Enabled = false;
        }
    }

    void AbilitadisabilitaArea(DataRow R) {
        if (R == null) {
            return;
        }
        string filter = QHC.CmpEq("iditinerationrefundkind", R["iditinerationrefundkind"]);
        DataRow[] RefundKind = DS.itinerationrefundkind.Select(filter);
        if (RefundKind.Length == 0) {
            return;
        }

        DataRow rRefundKind = RefundKind[0];
        //Se è una spesa di tipo rimborso forfettario oppure
        //Se è una spesa di tipo Vitto in località Ue oExtraUe verrà abilitato il combo delle località
        if ((CfgFn.GetNoNullInt32(rRefundKind["iditinerationrefundkindgroup"]) == 5)
        || ((CfgFn.GetNoNullInt32(rRefundKind["iditinerationrefundkindgroup"]) == 1) && (!(rdoItaly.Checked)))) {
            cmbArea.Visible = true;
            btnArea.Visible = true;
        }
        else {
            cmbArea.SelectedIndex = -1;
            DS.itinerationrefund.Rows[0]["idforeigncountry"] = DBNull.Value;
            cmbArea.Visible = false;
            btnArea.Visible = false;
        }

    }


    void RicalcolaImportoEffettivoValuta() {
        if (DS.itinerationrefund.Rows.Count == 0)
            return;
        DataRow Curr = DS.itinerationrefund.Rows[0];
        double importoEuro = CfgFn.GetNoNullDouble(Curr["amount"]);
        double importoDocEuro = CfgFn.GetNoNullDouble(Curr["docamount"]);
        double importoRichiestoEuro = CfgFn.GetNoNullDouble(Curr["requiredamount"]);
        double exchangeRate = CfgFn.GetNoNullDouble(Curr["exchangerate"]);
        double importoValuta = 0;
        double importoDocValuta = 0;
        double importoRichiestoValuta = 0;
        if (exchangeRate != 0) {
            importoValuta = importoEuro / exchangeRate;
            importoDocValuta = importoDocEuro / exchangeRate;
            importoRichiestoValuta = importoRichiestoEuro / exchangeRate;
        }
        double x = CfgFn.Round(Convert.ToDouble(importoValuta), 2);
        double x1 = CfgFn.Round(Convert.ToDouble(importoDocValuta), 2);
        double x2 = CfgFn.Round(Convert.ToDouble(importoRichiestoValuta), 2);
        txtImportoEffettivoValuta.Text = HelpForm.StringValue(x, "x.y.fixed.8...1");
        txtImportoDocValuta.Text = HelpForm.StringValue(x1, "x.y.fixed.8...1");
        txtImportoRichiestoValuta.Text = HelpForm.StringValue(x2, "x.y.fixed.8...1");
    }

    void ClearPerc() {
        DataRow Curr = DS.itinerationrefund.Rows[0];
        Curr["advancepercentage"] = 0;
        txtPercAnticipoItaliaEstero.Text = HelpForm.StringValue(
            Curr["advancepercentage"], txtPercAnticipoItaliaEstero.Tag.ToString());
    }

    private int calcolaOre(object dataInizio, object dataFine) {
        DateTime inizio;
        try {
            inizio = (DateTime)dataInizio;
        }
        catch {
            return -1;
        }

        DateTime fine;
        try {
            fine = (DateTime)dataFine;
        }
        catch {
            return -1;
        }

        double dinizio = 0;
        double dfine = 0;

        try {
            dinizio = inizio.ToOADate();
            dfine = fine.ToOADate();
        }
        catch {
            return -1;
        }


        int ngiorniinteri = Convert.ToInt32(Math.Floor(dfine - dinizio));
        int nore = Convert.ToInt32(
            Math.Floor(
            (dfine - dinizio - Math.Floor(dfine - dinizio)) * 24.0 + 0.5
            ));
        nore += (ngiorniinteri * 24);
        return nore;
    }

    private string calcolaFiltroApplicazioneGeo() {
        if (DS.itinerationrefund.Rows.Count == 0)
            return "";
        DataRow Curr = DS.itinerationrefund.Rows[0];
        if (Curr["flag_geo"] == DBNull.Value)
            return "";
        string flaggeo = Curr["flag_geo"].ToString().ToUpper();
        string filter = "";
        if (rdoItaly.Checked)
            filter = QHS.CmpEq("flag_italy", 'S');
        if (rdoUe.Checked)
            filter = QHS.CmpEq("flag_eu", 'S');
        if (rdoExtraUe.Checked)
            filter = QHS.CmpEq("flag_extraeu", 'S');
        return filter;
    }
    bool msgattr = false;
    void AggiornaLimite(DataRow R) {
        if (R == null) {
            txtLimiteMax.Text = "";
            return;
        }

        if (IsRimborsoForfettario() && rdoItaly.Checked) {
            txtLimiteMax.Text = "";
            return;
        }

        bool esisteConf;
        DataRow AttribRow = ottieniRigaRegolamentoSpesa(out esisteConf);
        if (AttribRow == null) {
            txtLimiteMax.Text = "";
            if (!esisteConf && !msgattr) {
                msgattr = true;
                ShowClientMessage("Le informazioni relative agli attributi " +
                    "di classificazione delle spese sono incomplete o mancanti.",
                    "Avviso");
            }
            return;
        }
        txtLimiteMax.Text = CfgFn.GetNoNullDecimal(AttribRow["limit"]).ToString();
    }

    void AggiornaPerc(DataRow R) {
        if (R == null) {
            ClearPerc();
            return;
        }
        if (IsRimborsoForfettario() && rdoItaly.Checked) {
            ClearPerc();
            return;
        }

        bool esisteConf;
        DataRow AttribRow = ottieniRigaRegolamentoSpesa(out esisteConf);

        if (AttribRow == null) {
            ClearPerc();
            if (!esisteConf && !msgattr) {
                msgattr = true;
                ShowClientMessage("Le informazioni relative agli attributi " +
                    "di classificazione delle spese sono incomplete o mancanti.",
                    "Avviso");
            }
            return;
        }

        DataRow Curr = DS.itinerationrefund.Rows[0];
        Curr["advancepercentage"] = CfgFn.GetNoNullDouble(AttribRow["advancepercentage"]);
        txtPercAnticipoItaliaEstero.Text = HelpForm.StringValue(
            Curr["advancepercentage"], txtPercAnticipoItaliaEstero.Tag.ToString());
    }

    private DataRow ottieniRigaRegolamentoSpesa(out bool esisteConf) {
        esisteConf = true;

        DataRow Curr = DS.itinerationrefund.Rows[0];
        object dataInizio = Curr["starttime"];
        object dataFine = Curr["stoptime"];

        int nOre = calcolaOre(dataInizio, dataFine);

        if (nOre == -1) {
            return null;
        }

        string fSuApplicazioneGeo = calcolaFiltroApplicazioneGeo();
        if (fSuApplicazioneGeo == "") {
            return null;
        }

        string f = QHC.CmpEq("iditinerationrefundkind", Curr["iditinerationrefundkind"]);
        DataRow[] RefundKind = DS.itinerationrefundkind.Select(f);
        if (RefundKind.Length == 0) {
            return null;
        }

        DataTable tRule = DataAccess.CreateTableByName(Meta.Conn, "itinerationrefundrule", "*");
        string fRule = QHS.CmpLe("start", dataInizio);
        DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tRule, "start desc", fRule, null, true);
        if (tRule.Rows.Count == 0) {
            return null;
        }

        DataRow rRule = tRule.Rows[0];
        string fRuleDetail = QueryCreator.WHERE_KEY_CLAUSE(rRule, DataRowVersion.Current, false);
        string fPos = MissFun.GetQualificaClasseFilter(Cfg.idposition, Cfg.incomeclass);
        fRuleDetail = GetData.MergeFilters(fRuleDetail, fPos);

        DataRow rRefundKind = RefundKind[0];
        string fRefundKind = QHS.CmpEq("iditinerationrefundkindgroup", rRefundKind["iditinerationrefundkindgroup"]);
        fRuleDetail = GetData.MergeFilters(fRuleDetail, fRefundKind);

        string fHour = QHS.AppAnd(QHS.NullOrLt("nhour_min", nOre), QHS.NullOrGt("nhour_max", nOre));
        fRuleDetail = GetData.MergeFilters(fRuleDetail, fHour);
        fRuleDetail = GetData.MergeFilters(fRuleDetail, fSuApplicazioneGeo);

        DataTable tRuleDetail = DataAccess.CreateTableByName(Meta.Conn, "itinerationrefundruledetail", "*");

        DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tRuleDetail, "iddetail",
            fRuleDetail, null, false);

        if (tRuleDetail.Rows.Count == 0) {
            esisteConf = false;
            return null;
        }
        return tRuleDetail.Rows[0];
    }

    void AggiornaValuta(DataRow ValutaRow) {
        if (ValutaRow == null) {
            txtCambio.Text = "";
            txtCambio.ReadOnly = false;
            return;
        }
        double xx = 1;
        txtCambio.Text = HelpForm.StringValue(xx, txtCambio.Tag.ToString());

    }

    bool inConverti = false;

    void ConvertiIntoValuta(hwTextBox Eur, hwTextBox Val) {
        if (inConverti)
            return;
        inConverti = true;
        object Ocambio = HelpForm.GetObjectFromString(typeof(double),
            txtCambio.Text, txtCambio.Tag.ToString());
        if ((Ocambio == null) || (Ocambio == DBNull.Value)) {
            Val.Text = "";
            inConverti = false;
            return;
        }
        double cambio = CfgFn.GetNoNullDouble(Ocambio);
        object eur = HelpForm.GetObjectFromString(typeof(decimal),
            Eur.Text, Eur.Tag.ToString());
        if ((eur == null) || (eur == DBNull.Value)) {
            Val.Text = "";
        }
        else {
            if (cambio == 0) {
                Val.Text = "";
            }
            else {
                double x = Convert.ToDouble(eur) / cambio;
                x = CfgFn.RoundValuta(x);
                Val.Text = HelpForm.StringValue(x, "x.y.fixed.8...1");
            }
        }
        inConverti = false;
    }


    void ConvertiFromValuta(hwTextBox Eur, hwTextBox Val) {
        if (inConverti)
            return;
        inConverti = true;
        object Ocambio = HelpForm.GetObjectFromString(typeof(double),
            txtCambio.Text, txtCambio.Tag.ToString());
        if ((Ocambio == null) || (Ocambio == DBNull.Value)) {
            Eur.Text = "";
            inConverti = false;
            return;
        }
        double cambio = CfgFn.GetNoNullDouble(Ocambio);
        object x = HelpForm.GetObjectFromString(typeof(double),
            Val.Text, "x.y.fixed.8...1");
        if ((x == null) || (x == DBNull.Value)) {
            Eur.Text = "";
        }
        else {
            decimal eur = Convert.ToDecimal(Convert.ToDouble(x) * cambio);
            eur = CfgFn.RoundValuta(eur);
            Eur.Text = eur.ToString("c");
        }
        inConverti = false;
    }

    bool CalculatingAnticipo = false;

    void RicalcolaAnticipo() {
        if (Meta.edit_type == "balancenew02") {
            ClearPerc();
            return;
        }
        if (CalculatingAnticipo)
            return;
        CalculatingAnticipo = true;
        if (CommFun.DrawStateIsDone)
            CommFun.GetFormData(true);
        DataRow Curr = DS.itinerationrefund.Rows[0];
        decimal anticipo = MissFun.GetAnticipoSpesa(Curr);
        txtAnticipo.Text = anticipo.ToString("c");
        CalculatingAnticipo = false;
    }

    void RicalcolaPercentualeAnticipo() {
        if (CalculatingAnticipo)
            return;
        CalculatingAnticipo = true;
        if (CommFun.DrawStateIsDone)
            CommFun.GetFormData(true);
        object vanticipo = HelpForm.GetObjectFromString(typeof(decimal),
            txtAnticipo.Text, "x.y.c");
        DataRow Curr = DS.itinerationrefund.Rows[0];
        decimal importo = MissFun.GetBasePerAnticipoSpesa(Curr);
        decimal anticipo = CfgFn.GetNoNullDecimal(vanticipo);
        if (anticipo == 0)
            return;
        decimal percanticipo = importo / anticipo;
        txtPercAnticipoItaliaEstero.Text = HelpForm.StringValue(percanticipo,
            txtPercAnticipoItaliaEstero.Tag.ToString());

        CalculatingAnticipo = false;
    }

    /*
    private void txtImportoValuta_TextChanged(object sender, System.EventArgs e)
    {
        if (!Meta.DrawStateIsDone) return;
        TextBox T = (TextBox)sender;
        string prefix = T.Name.Substring(0, T.Name.Length - 6);
        TextBox T1 = GetTxtByName(prefix + "EUR");
        ConvertiFromValuta(T1, T);
    }

        /*

    private void txtImportoEffettivoEUR_TextChanged(object sender, System.EventArgs e)
    {
        if (!Meta.DrawStateIsDone) return;
        RicalcolaAnticipo();
    }

    private void txtPercAnticipoItaliaEstero_TextChanged(object sender, System.EventArgs e)
    {
        if (!Meta.DrawStateIsDone) return;
        RicalcolaAnticipo();
    }

    private void txtImportoValuta_Enter(object sender, System.EventArgs e)
    { 
        TextBox T = (TextBox)sender;
        HelpForm.ExtEnterNumTextBox(T, "x.y.fixed.8...1");
    }

    private void txtImportoValuta_Leave(object sender, System.EventArgs e)
    {
        TextBox T = (TextBox)sender;
        HelpForm.ExtLeaveNumTextBox(T, "x.y.fixed.8...1");
    }

    private void txtDataInizio_Leave(object sender, EventArgs e)
    {
        if (DS.itinerationrefund.Rows.Count == 0) return;
        object d = HelpForm.GetObjectFromString(typeof(DateTime), txtDataInizio.Text, txtDataInizio.Tag.ToString());
        if (d == null) return;
        DataRow Curr = DS.itinerationrefund.Rows[0];
        AggiornaPerc(Curr);
        AggiornaLimite(Curr);
    }

    private void txtDataFine_Leave(object sender, EventArgs e)
    {
        if (DS.itinerationrefund.Rows.Count == 0) return;
        object d = HelpForm.GetObjectFromString(typeof(DateTime), txtDataFine.Text, txtDataFine.Tag.ToString());
        if (d == null) return;
        DataRow Curr = DS.itinerationrefund.Rows[0];
        AggiornaPerc(Curr);
        AggiornaLimite(Curr);
    }
    */
    public void rdoItaly_CheckedChanged(object sender, EventArgs e) {
        if (DS.itinerationrefund.Rows.Count == 0)
            return;
        DataRow Curr = DS.itinerationrefund.Rows[0];
        AggiornaPerc(Curr);
        AggiornaLimite(Curr);
    }

    public void rdoUe_CheckedChanged(object sender, EventArgs e) {
        if (DS.itinerationrefund.Rows.Count == 0)
            return;
        DataRow Curr = DS.itinerationrefund.Rows[0];
        AggiornaPerc(Curr);
        AggiornaLimite(Curr);
        AbilitadisabilitaArea(Curr);
    }

    public void rdoExtraUe_CheckedChanged(object sender, EventArgs e) {
        if (DS.itinerationrefund.Rows.Count == 0)
            return;
        DataRow Curr = DS.itinerationrefund.Rows[0];
        AggiornaPerc(Curr);
        AggiornaLimite(Curr);
        AbilitadisabilitaArea(Curr);
    }

    public void txtDataInizio_LeaveTextBoxHandler(object sender, EventArgs e) {
        if (DS.itinerationrefund.Rows.Count == 0)
            return;
        object d = HelpForm.GetObjectFromString(typeof(DateTime), txtDataInizio.Text, txtDataInizio.Tag.ToString());
        if (d == null)
            return;
        DataRow Curr = DS.itinerationrefund.Rows[0];
        AggiornaPerc(Curr);
        AggiornaLimite(Curr);
        AggiornaRimborsoForfettario();
    }


    public void txtDataFine_LeaveTextBoxHandler(object sender, EventArgs e) {
        if (DS.itinerationrefund.Rows.Count == 0)
            return;
        object d = HelpForm.GetObjectFromString(typeof(DateTime), txtDataFine.Text, txtDataFine.Tag.ToString());
        if (d == null)
            return;
        DataRow Curr = DS.itinerationrefund.Rows[0];
        AggiornaPerc(Curr);
        AggiornaLimite(Curr);
        AggiornaRimborsoForfettario();
    }

    public void txtImportoDocValuta_LeaveTextBoxHandler(object sender, EventArgs e) {
    }

    public void txtCambio_TextChanged(object sender, EventArgs e) {
        ConvertiFromValuta(txtImportoRichiestoEUR, txtImportoRichiestoValuta);
        ConvertiFromValuta(txtImportoEffettivoEUR, txtImportoEffettivoValuta);
        ConvertiFromValuta(txtImportoDocEUR, txtImportoDocValuta);
    }
    void AzzeraRimborso() {
        DataRow Curr = DS.itinerationrefund.Rows[0];
        Curr["amount"] = 0;
        CommFun.FreshForm(false, false);
    }

    bool IsRimborsoPerVitto() {
        if (PState.IsEmpty)
            return false;
        object O = cmbClassificazione.SelectedValue;
        if (O == null || O == DBNull.Value)
            return false;

        string filter = QHC.CmpEq("iditinerationrefundkind", O);
        DataRow[] RefundKind = DS.itinerationrefundkind.Select(filter);
        if (RefundKind.Length == 0) {
            return false;
        }

        DataRow rRefundKind = RefundKind[0];
        if (CfgFn.GetNoNullInt32(rRefundKind["iditinerationrefundkindgroup"]) == 1) {
            return true;
        }

        return false;
    }

    bool IsRimborsoForfettario() {
        if (PState.IsEmpty)
            return false;
        object O = cmbClassificazione.SelectedValue;
        if (O == null || O == DBNull.Value || O.ToString()=="")
            return false;

        string filter = QHC.CmpEq("iditinerationrefundkind", O);
        DataRow[] RefundKind = DS.itinerationrefundkind.Select(filter);
        if (RefundKind.Length == 0) {
            return false;
        }

        DataRow rRefundKind = RefundKind[0];
        if (CfgFn.GetNoNullInt32(rRefundKind["iditinerationrefundkindgroup"]) == 5) {
            return true;
        }

        return false;
    }

    void AggiornaRimborsoForfettario() {
        if (!IsRimborsoForfettario())
            return;
        if (Cfg.foreignclass == "")
            return;
        if (CommFun.DrawStateIsDone)
            CommFun.GetFormData(true);
        DataRow Curr = DS.itinerationrefund.Rows[0];
        DateTime Start;
        DateTime Stop;
        if (Curr["starttime"] == DBNull.Value || (Curr["stoptime"] == DBNull.Value)) {
            AzzeraRimborso();
            return;
        }

        Start = (DateTime)Curr["starttime"];
        Stop = (DateTime)Curr["stoptime"];

        double frazfgiorni = MissFun.IF_CalcolaFrazGiorni(Start, Stop);

        //classe estera per il rimborso forfettario
        string IF_class = Cfg.foreignclass;
        object idforeigncountry = Curr["idforeigncountry"];
        if (idforeigncountry == DBNull.Value) {
            AzzeraRimborso();
            return;
        }
        DataRow[] fc = DS.foreigncountry.Select(QHC.CmpEq("idforeigncountry", idforeigncountry));
        if (fc.Length == 0) {
            AzzeraRimborso();
            return;
        }
        object idmacroarea = fc[0]["idmacroarea"];
        if (idmacroarea == DBNull.Value) {
            AzzeraRimborso();
            return;
        }
        string filter = QHS.AppAnd(QHS.CmpEq("idmacroarea", idmacroarea),
                                    QHS.CmpLe("start", ParentMissione[MissFun.CampoDataPerPosGiuridica]),
                                    QHS.NullOrLt("stop", ParentMissione[MissFun.CampoDataPerPosGiuridica]));
        string field = "amount_" + IF_class.ToLower();
        decimal amount = CfgFn.GetNoNullDecimal(Conn.DO_READ_VALUE("macroarea", filter, field));
        if (amount == 0) {
            AzzeraRimborso();
            return;
        }
        amount = amount * Convert.ToDecimal(frazfgiorni);

        Curr["amount"] = amount;
        Curr["requiredamount"] = amount;
        txtImportoRichiestoEUR.Text = HelpForm.StringValue(amount, txtImportoRichiestoEUR.Tag.ToString());
        txtImportoEffettivoEUR.Text = HelpForm.StringValue(amount, txtImportoEffettivoEUR.Tag.ToString());

        string filterTipoRimborso = QHC.CmpEq("iditinerationrefundkind", Curr["iditinerationrefundkind"]);
        DataRow[] RefundKind = DS.itinerationrefundkind.Select(filterTipoRimborso);
        if (RefundKind.Length == 0) {
            AggiornaPerc(null);
        }
        else {
            AggiornaPerc(RefundKind[0]);
        }
        RicalcolaAnticipo();//Chiamato implicitamente da AggiornaPerc(). Se non cambia la % può cambiare l'importo 
        RicalcolaImportoEffettivoValuta();
        //CheckLimiteAnticipo();



        //RicalcolaImportoEffettivoValuta();
        //RicalcolaPercentualeAnticipo();




    }

    protected void Page_Load(object sender, EventArgs e) {

    }
    protected void txtDataInizio_TextChanged(object sender, EventArgs e) {
        AggiornaRimborsoForfettario();
    }
    protected void txtDataFine_TextChanged(object sender, EventArgs e) {
        AggiornaRimborsoForfettario();
    }
}

