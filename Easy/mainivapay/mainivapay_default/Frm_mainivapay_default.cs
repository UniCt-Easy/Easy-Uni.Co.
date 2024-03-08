
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
using funzioni_configurazione;//funzioni_configurazione
using ep_functions;
using SituazioneViewer;//SituazioneViewer

namespace mainivapay_default{
    public partial class Frm_mainivapay_default : MetaDataForm {
        public Frm_mainivapay_default(){
            InitializeComponent();
            GetData.SetSorting(DS.mainivapay, "ymainivapay DESC");
            DataAccess.SetTableForReading   (DS.dettliquidazioneivaview_debito, "mainivapaydetailview");
            QueryCreator.SetTableForPosting(DS.dettliquidazioneivaview_debito, "mainivapaydetail");

            QueryCreator.SetTableForPosting(DS.mainivapaydetailview, "mainivapaydetail");

            QueryCreator.SetTableForPosting(DS.mainivapayincomeview, "mainivapayincome");
            QueryCreator.SetTableForPosting(DS.mainivapayexpenseview, "mainivapayexpense");
            GetData.CacheTable(DS.incomephase);
            GetData.CacheTable(DS.expensephase);
        }
        MetaData Meta;
        DataAccess Conn;
        QueryHelper QHS;
        CQueryHelper QHC;
        public void MetaData_AfterLink(){
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHS = Meta.Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            GetData.CacheTable(DS.config, QHS.CmpEq("ayear", Meta.GetSys("esercizio")),null, false);
            GetData.SetStaticFilter(DS.mainivapayexpenseview, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
            GetData.SetStaticFilter(DS.mainivapayincomeview, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
        }

        decimal startivabalance;
        decimal startivabalance12;
        public void MetaData_AfterActivation(){
            DataRow CfgRow = DS.config.Rows[0];
            startivabalance = CfgFn.GetNoNullDecimal(CfgRow["mainstartivabalance"]);
            startivabalance12 = CfgFn.GetNoNullDecimal(CfgRow["mainstartivabalance12"]);

            if (MovimentiFinanziariConfigurati()) {
                gboxmanuale.Visible = false;
            }
            else {
                gboxmovimenti.Visible = false;
            }

            if (MovimentiFinanziariConfigurati12()) {
                gboxmanuale12.Visible = false;
            }
            else {
                gboxmovimenti12.Visible = false;
            }
        }

        public void MetaData_AfterClear(){
            DisabilitaCampi(false);
            SvuotaCampi();
            txtEsercizio.Text = Meta.GetSys("esercizio").ToString();
            VisualizzaEtichetteEP();
            VisualizzaRiepilogo();
        }

        public void MetaData_BeforeFill(){
            if (Meta.FirstFillForThisRow){
                calcolaIVACredito();
                calcolaIVACredito12();
            }
        }

        public void MetaData_AfterFill(){
            DisabilitaCampi(true);
            CalcolaTotali();
            if (Meta.FirstFillForThisRow && Meta.EditMode){
                VisualizzaEtichetteEP();
            }
            VisualizzaRiepilogo();
        }

        void VisualizzaRiepilogo(){
            if (DS.mainivapay.Rows.Count == 0 || DS.config.Rows.Count == 0){
                btnRiepilogo.Enabled = false;
                return;
            }

            DataRow CfgRow = DS.config.Rows[0];
            if (CfgRow["flagivapaybyrow"].ToString().ToUpper() == "S"){
                btnRiepilogo.Visible = true;
            }
            else{
                btnRiepilogo.Visible = false;
            }

            btnRiepilogo.Enabled = (!Meta.IsEmpty);
            return;

        }
        void VisualizzaEtichetteEP(){
            if (Meta.InsertMode || DS.mainivapay.Rows.Count == 0 || DS.config.Rows.Count == 0){
                labEPnongenerato.Visible = false;
                labEPgenerato.Visible = false;
                btnVisualizzaEP.Visible = false;
                return;
            }

            string idrelated = EP_functions.GetIdForDocument(DS.mainivapay.Rows[0]);
            if (Meta.Conn.RUN_SELECT_COUNT("entry", QHS.CmpEq("idrelated", idrelated), true) == 0){
                labEPnongenerato.Visible = true;
                labEPgenerato.Visible = false;
                btnVisualizzaEP.Visible = false;
            }
            else{
                labEPnongenerato.Visible = false;
                labEPgenerato.Visible = true;
                btnVisualizzaEP.Visible = true;
            }
        }

        private void calcolaIVACredito(){
            object idivaregisterkind;
            object flagactivity;
            // Elabora i registri NON Istituzionali
            foreach (DataRow rDettaglio in DS.mainivapaydetailview.Select(QHC.CmpEq("registerclass", "A"))){
                idivaregisterkind = rDettaglio["idivaregisterkind"];
                flagactivity = Meta.Conn.DO_READ_VALUE("ivaregisterkind", QHS.CmpEq("idivaregisterkind", idivaregisterkind), "flagactivity");
                if (flagactivity.ToString() == "1") continue;

                decimal ivaNetta = CfgFn.GetNoNullDecimal(rDettaglio["ivanet"]);
                decimal ivaNettaDiff = CfgFn.GetNoNullDecimal(rDettaglio["ivanetdeferred"]);
                rDettaglio["!ivacredit"] = ivaNetta + ivaNettaDiff;
            }
        }

        private void calcolaIVACredito12(){
            object idivaregisterkind;
            object flagactivity;
            // Elabora i registri Istituzionali
            foreach (DataRow rDettaglio in DS.mainivapaydetailview.Select(QHC.CmpEq("registerclass", "A"))){
                idivaregisterkind = rDettaglio["idivaregisterkind"];
                flagactivity = Meta.Conn.DO_READ_VALUE("ivaregisterkind", QHS.CmpEq("idivaregisterkind", idivaregisterkind), "flagactivity");
                if (flagactivity.ToString() != "1") continue;

                decimal ivaNetta = CfgFn.GetNoNullDecimal(rDettaglio["iva"]);
                decimal ivaNettaDiff = CfgFn.GetNoNullDecimal(rDettaglio["ivadeferred"]);
                rDettaglio["!ivacredit"] = ivaNetta + ivaNettaDiff;
            }
        }


        string idrelated = "";
        bool fromDelete = false;

        public void MetaData_BeforePost(){
            fromDelete = false;
            DS.dettliquidazioneivaview_debito.AcceptChanges();
            if (DS.mainivapay.Rows[0].RowState == DataRowState.Deleted){
                idrelated = EP_functions.GetIdForDocument(DS.mainivapay.Rows[0]);
                fromDelete = true;
            }
        }

        bool MovimentiFinanziariConfigurati(){
            DataRow rConfIVA = DS.config.Rows[0];
            if (rConfIVA["mainflagpayment"].ToString().ToUpper() == "S") return true;
            if (rConfIVA["mainflagrefund"].ToString().ToUpper() == "S") return true;
            return false;
        }

        bool MovimentiFinanziariConfigurati12(){
            DataRow rConfIVA = DS.config.Rows[0];
            if (rConfIVA["mainflagpayment12"].ToString().ToUpper() == "S") return true;
            if (rConfIVA["mainflagrefund12"].ToString().ToUpper() == "S") return true;
            return false;
        }

        public void MetaData_AfterPost(){
            if (fromDelete){
                cancellaScritture();
                idrelated = "";
                fromDelete = false;
            }
        }

        private void cancellaScritture(){
            EP_functions EP = new EP_functions(Meta.Dispatcher);
            if (!EP.attivo) return;
            EP.GetEntryForDocument(idrelated);

            foreach (DataRow rEntry in EP.D.Tables["entry"].Rows){
                rEntry.Delete();
            }

            foreach (DataRow rEntryDetail in EP.D.Tables["entrydetail"].Rows){
                rEntryDetail.Delete();
            }

            MetaData MetaEntry = MetaData.GetMetaData(this, "entry");
            PostData Post = MetaEntry.Get_PostData();

            Post.InitClass(EP.D, Meta.Conn);
            if (!Post.DO_POST()){
                show(this, "Errore durante la cancellazione delle scritture in PD");
            }
        }

        private void DisabilitaCampi(bool disable){
            rdoPeriodica.Enabled = !disable;
            rdoAcconto.Enabled = !disable;
            chkCommerciale.Enabled = !disable;
            chkIstituzionale.Enabled = !disable;
        }

        private void SvuotaCampi(){
            txtSaldoPrec.Text = "";
            txtSaldoPrec12.Text = "";
            lblcredito1.Text = "";
            lblcredito1_12.Text = "";

            txtIvaPeriodo.Text = "";
            txtIvaPeriodo12.Text = "";
            lblcredito2.Text = "";
            lblcredito2_12.Text = "";

            txtTotaleIva.Text = "";
            txtTotaleIva12.Text = "";
            labCredito3.Text = "";
            lblcredito3_12.Text = "";

            txtLiquidMese.Text = "";
            txtLiquidMese12.Text = "";
            labCredito3.Text = "";
            lblcredito4_12.Text = "";

            txtNuovoSaldo.Text = "";
            txtNuovoSaldo12.Text = "";
            lblcredito5_12.Text = "";

            txtMese.Text = "";
        }


        private bool CiSonoInserimentiManuali() {
            object esercizio = Meta.GetSys("esercizio");
            int n_man = Conn.RUN_SELECT_COUNT("ivapay",
                    QHS.AppAnd(QHS.CmpEq("yivapay", esercizio),
                                    QHS.Not(QHS.NullOrEq("paymentamount", 0)),
                                    QHS.Not(QHS.NullOrEq("refundamount", 0))
                            ), false);
            return (n_man == 0);
        }
        private bool CiSonoInserimentiManuali12() {
            object esercizio = Meta.GetSys("esercizio");
            int n_man = Conn.RUN_SELECT_COUNT("ivapay",
                    QHS.AppAnd(QHS.CmpEq("yivapay", esercizio),
                                    QHS.Not(QHS.NullOrEq("paymentamount12", 0)),
                                    QHS.Not(QHS.NullOrEq("refundamount12", 0))
                            ), false);
            return (n_man == 0);
        }



        private decimal GetSaldoPrecedente(){
            DataRow R = DS.mainivapay.Rows[0];

            object esercizio = Meta.GetSys("esercizio");

            string sql = "SELECT SUM(paymentamount) AS paymentamount, "
                + "SUM(refundamount) AS refundamount, "
                + "SUM(totaldebit) AS totaldebit, "
                + "SUM(totalcredit) AS totalcredit "
                + "FROM mainivapay ";
            string filter = " WHERE " + QHS.AppAnd(
                QHS.CmpEq("ymainivapay", R["ymainivapay"]), QHS.CmpLt("nmainivapay", R["nmainivapay"]));
            DataTable T = Conn.SQLRunner(sql + filter, false);


            decimal saldo_precedente = -startivabalance;
            if (T != null && T.Rows.Count > 0){
                DataRow RR = T.Rows[0];
                saldo_precedente = saldo_precedente
                                   + CfgFn.GetNoNullDecimal(RR["totaldebit"])
                                   - CfgFn.GetNoNullDecimal(RR["paymentamount"])

                                   - CfgFn.GetNoNullDecimal(RR["totalcredit"])
                                   + CfgFn.GetNoNullDecimal(RR["refundamount"]);

            }
            return saldo_precedente;
        }

        private decimal GetSaldoPrecedente12(){
            DataRow R = DS.mainivapay.Rows[0];

            object esercizio = Meta.GetSys("esercizio");

            string sql = "SELECT SUM(paymentamount12) as paymentamount12,"
                + " SUM(refundamount12) as refundamount12, "
                + " SUM(totaldebit12) as totaldebit12,"
                + " SUM(totalcredit12) as totalcredit12 "
                + "FROM mainivapay ";
            string filter = " WHERE " + QHS.AppAnd(
                QHS.CmpEq("ymainivapay", R["ymainivapay"]), QHS.CmpLt("nmainivapay", R["nmainivapay"]));
            DataTable T = Conn.SQLRunner(sql + filter, false);

            decimal saldo_precedente12 = -startivabalance12;
            if (T != null && T.Rows.Count > 0)
            {
                DataRow RR = T.Rows[0];
                saldo_precedente12 = saldo_precedente12
                                   + CfgFn.GetNoNullDecimal(R["totaldebit12"])
                                   - CfgFn.GetNoNullDecimal(R["paymentamount12"])

                                   - CfgFn.GetNoNullDecimal(R["totalcredit12"])
                                   + CfgFn.GetNoNullDecimal(R["refundamount12"]);
            }
            return saldo_precedente12;
        }

        private void ImpostaLabel(decimal importo, Label lbl){
            if (importo > 0)
                lbl.Text = "a debito";
            else
            {
                if (importo < 0)
                    lbl.Text = "a credito";
                else
                    lbl.Text = "";
            }
        }


        private void CalcolaTotali(){
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.mainivapay.Rows[0];

            decimal ivadelperiodo = CfgFn.GetNoNullDecimal(Curr["totaldebit"])
                                    - CfgFn.GetNoNullDecimal(Curr["totalcredit"]);

            decimal ivadelperiodo12 = CfgFn.GetNoNullDecimal(Curr["totaldebit12"])
                        - CfgFn.GetNoNullDecimal(Curr["totalcredit12"]);

            txtIvaPeriodo.Text = Math.Abs(ivadelperiodo).ToString("c");
            txtIvaPeriodo12.Text = Math.Abs(ivadelperiodo12).ToString("c");

            ImpostaLabel(ivadelperiodo, lblcredito2);
            ImpostaLabel(ivadelperiodo12, lblcredito2_12);
            
            object mese = Meta.Conn.DO_READ_VALUE("monthname", QHS.CmpEq("code", Curr["nmonth"]), "title");
            txtMese.Text = mese.ToString();

            bool movfinanziariConfig = false;
            if (movfinanziariConfig || CiSonoInserimentiManuali()) {
                movfinanziariConfig = false;
            }
            else{
                movfinanziariConfig = true;
            }

            bool movfinanziariConfig12 = false;
            if (movfinanziariConfig12 || CiSonoInserimentiManuali12()) {
                movfinanziariConfig12 = false;
            }
            else{
                movfinanziariConfig12 = true;
            }

            decimal liquidazionecorrente = CfgFn.GetNoNullDecimal(Curr["paymentamount"]) - CfgFn.GetNoNullDecimal(Curr["refundamount"]);
            txtLiquidMese.Text = Math.Abs(liquidazionecorrente).ToString("c");
            if (movfinanziariConfig)
                ImpostaLabel(liquidazionecorrente, labCredito4);

            decimal liquidazionecorrente12 = CfgFn.GetNoNullDecimal(Curr["paymentamount12"]) - CfgFn.GetNoNullDecimal(Curr["refundamount12"]);
            txtLiquidMese12.Text = Math.Abs(liquidazionecorrente12).ToString("c");
            if (movfinanziariConfig12)
                ImpostaLabel(liquidazionecorrente12, lblcredito4_12);

            decimal saldo_precedente = GetSaldoPrecedente();
            decimal saldo_precedente12 = GetSaldoPrecedente12();

            decimal totaleiva = saldo_precedente + ivadelperiodo;
            decimal totaleiva12 = saldo_precedente12 + ivadelperiodo12;

            decimal nuovosaldo = totaleiva - liquidazionecorrente;
            decimal nuovosaldo12 = totaleiva12 - liquidazionecorrente12;

            if (movfinanziariConfig){
                txtSaldoPrec.Text = Math.Abs(saldo_precedente).ToString("c");
                ImpostaLabel(saldo_precedente, lblcredito1);
                txtTotaleIva.Text = Math.Abs(totaleiva).ToString("c");
                ImpostaLabel(totaleiva, labCredito3);
                txtNuovoSaldo.Text = Math.Abs(nuovosaldo).ToString("c");
                ImpostaLabel(nuovosaldo, lblcredito5);
            }

            if (movfinanziariConfig12){
                txtSaldoPrec12.Text = Math.Abs(saldo_precedente12).ToString("c");
                ImpostaLabel(saldo_precedente12, lblcredito1_12);
                txtTotaleIva12.Text = Math.Abs(totaleiva12).ToString("c");
                ImpostaLabel(totaleiva12, lblcredito3_12);
                txtNuovoSaldo12.Text = Math.Abs(nuovosaldo12).ToString("c");
                ImpostaLabel(nuovosaldo12, lblcredito5_12);
            }

            decimal totalemovent = 0, totalemovent12 = 0;
            decimal totalemovspe = 0, totalemovspe12 = 0;
            object fasespesamax = Meta.GetSys("maxexpensephase");
            string filterspesamax = QHS.CmpEq("nphase", fasespesamax);

            object faseentratamax = CfgFn.GetNoNullInt32(Meta.GetSys("maxincomephase"));
            string filterentratamax = QHS.CmpEq("nphase", faseentratamax);

            string filter = " where " + QHS.AppAnd(
                        QHS.CmpEq("ymainivapay", DS.mainivapay.Rows[0]["ymainivapay"]),
                        QHS.CmpEq("nmainivapay", DS.mainivapay.Rows[0]["nmainivapay"])) + " ";

            //  15	-	Liquidazione IVA consolidata interna
            //  16	-	Liquidazione IVA consolidata esterna
            //  18	-	Liquidazione IVA intra consolidata interna
            //  19	-	Liquidazione IVA intra consolidata esterna
            string filterAutokind = QHS.FieldInList("autokind", QHS.List(15, 16));
            string filterAutokind12 = QHS.FieldInList("autokind", QHS.List(18, 19));

            string filterMov = GetData.MergeFilters(filter, filterAutokind);
            string cmd = "select sum(amount) from mainivapayincomeview " + filter +
                " group by ymainivapay,nmainivapay,nphase " +
                "having " + filterentratamax;
            DataTable T = Meta.Conn.SQLRunner(cmd, true, -1);
            if (T != null && T.Rows.Count > 0) totalemovent = CfgFn.GetNoNullDecimal(T.Rows[0][0]);

            cmd = "select sum(amount) from mainivapayexpenseview " + filterMov +
                "group by ymainivapay,nmainivapay,nphase " +
                "having " + filterspesamax;
            T = Meta.Conn.SQLRunner(cmd, true, -1);
            if (T != null && T.Rows.Count > 0) totalemovspe = CfgFn.GetNoNullDecimal(T.Rows[0][0]);

            // INTRA
            string filterMov12 = GetData.MergeFilters(filter, filterAutokind12);
            cmd = "select sum(amount) from mainivapayincomeview " + filterMov12 +
                " group by ymainivapay,nmainivapay,nphase " +
                "having " + filterentratamax;
            DataTable T12 = Meta.Conn.SQLRunner(cmd, true, -1);
            if (T12 != null && T12.Rows.Count > 0) totalemovent12 = CfgFn.GetNoNullDecimal(T12.Rows[0][0]);

            cmd = "select sum(amount) from mainivapayexpenseview " + filterMov12 +
                "group by ymainivapay,nmainivapay,nphase " +
                "having " + filterspesamax;
            T12 = Meta.Conn.SQLRunner(cmd, true, -1);
            if (T12 != null && T12.Rows.Count > 0) totalemovspe12 = CfgFn.GetNoNullDecimal(T12.Rows[0][0]);

            if (movfinanziariConfig){
                txtTotaleMovEnt.Text = totalemovent.ToString("c");
                txtTotaleMovSpe.Text = totalemovspe.ToString("c");
            }

            if (movfinanziariConfig12){
                txtTotaleMovEnt12.Text = totalemovent12.ToString("c");
                txtTotaleMovSpe12.Text = totalemovspe12.ToString("c");
            }

        }
        void EditEntry(){
            if (DS.mainivapay.Rows.Count == 0) return;
            EP_functions EP = new EP_functions(Meta.Dispatcher);
            EP.EditRelatedEntry(Meta, DS.mainivapay.Rows[0]);
        }

        private void btnRiepilogo_Click(object sender, EventArgs e){
            object ymainivapay = DBNull.Value;
            object nmainivapay = DBNull.Value;
            DataRow MyRow = HelpForm.GetLastSelected(DS.mainivapay);

            if (MyRow != null){
                ymainivapay = MyRow["ymainivapay"];
                nmainivapay = MyRow["nmainivapay"];
                DataSet Out = Conn.CallSP("show_mainivapay", new Object[2] { ymainivapay, nmainivapay });
                if (Out == null) return;
                Out.Tables[0].TableName = "Situazione liquidazione";
                frmSituazioneViewer view = new frmSituazioneViewer(Out);
                createForm(view, null);
                view.Show();
            }

        }

        private void btnVisualizzaEP_Click(object sender, EventArgs e){
            EditEntry();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) {

        }
    }
}
