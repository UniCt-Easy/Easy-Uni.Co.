
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using System.Data;
using funzioni_configurazione;
using movimentofunctions;
using System.Globalization;
using System.Linq;
using ep_functions;
using AskInfo;
using gestioneclassificazioni;
using q = metadatalibrary.MetaExpression;

namespace expense_wizardinvoicedetailnomandate {
    public partial class FrmWizardInvoiceDetailNoMandate : MetaDataForm {
        MetaData Meta;
        DataAccess Conn;
        string CustomTitle;
        DataSet DSCopy;
        decimal TotaleDaContabilizzare = 0;
        int fasefattura;
        int choosenParentPhase = 0;
        ArrayList DetailsToUpdate;
        QueryHelper QHS;
        CQueryHelper QHC;
        bool monofase = false;

        public FrmWizardInvoiceDetailNoMandate() {
            InitializeComponent();
            tabController.HideTabsMode =
                Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;
        }

        #region Gestione Tabs

        /// <summary>
        /// Displays tab n. NewTab and updates buttons
        /// </summary>
        /// <param name="newTab"></param>
        void DisplayTabs(int newTab) {
            tabController.SelectedIndex = newTab;
            //Evaluates Buttons Appearance
            btnBack.Visible = (newTab > 0);
            if (newTab == tabController.TabPages.Count - 1)
                btnNext.Text = "Esegui.";
            else
                btnNext.Text = "Avanti >";
            Text = CustomTitle + " (Pagina " + (newTab + 1) + " di " + tabController.TabPages.Count + ")";
        }

        void StandardChangeTab(int step) {
            int oldTab = tabController.SelectedIndex;
            int newTab = oldTab + step;
            if ((newTab < 0) || (newTab > tabController.TabPages.Count)) return;
            if (!CustomChangeTab(oldTab, newTab)) return;
            if (newTab == tabController.TabPages.Count) {
                if (show(this, "Si desidera eseguire ancora la procedura",
                    "Conferma", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    newTab = 0;
                    ResetWizard();
                }
                else {
                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                }
            }
            if ((oldTab == 3) && (newTab == 2)) {
                newTab = 0;
                ResetWizard();
            }
            DisplayTabs(newTab);
        }

        private void btnBack_Click(object sender, System.EventArgs e) {
            StandardChangeTab(-1);
        }


        private void btnNext_Click(object sender, System.EventArgs e) {
            StandardChangeTab(+1);
        }

        bool CustomChangeTab(int oldTab, int newTab) {
            if ((oldTab == 0) && (newTab == 1)) {
                DataRow[] Selected = GetGridSelectedRows(gridDetails);
                if ((Selected == null) || (Selected.Length == 0)) {
                    show("Non è stato selezionato alcun dettaglio.");
                    return false;
                }


                object[] upb = ValoriDiversi(Selected, "idupb");
                object[] upb_iva = ValoriDiversi(Selected, "idupb_iva");
                int causale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);




                if (!verificaSeUPBUniformi(upb, upb_iva, causale)) {
                    show(this,
                        "Attenzione i dettagli selezionati hanno UPB non uniformi non si può andare avanti");
                    return false;
                }
                txtPerc.Text = "100";
                txtDaPagare.Text = txtTotSelezionato.Text;
                return true;
            }
            if ((oldTab == 1) && (newTab == 0)) {
                VisualizzaUPB();
                AggiornaGridDettagliFattura();
                rdbSplittaTutti.Checked = false;
                txtDaPagare.Text = "";
                txtPerc.Text = "";
                return true;
            }
            ;
            if ((oldTab == 1) && (newTab == 2)) {
                RadioCheck_Changed();
                return true;
            }
            if ((oldTab == 2) && (newTab == 3)) {
                if ((radioNewCont.Checked == false) && (radioNewLinkedMov.Checked == false)
                    && (radioAddCont.Checked == false)) {
                    show("Non sarà possibile contabilizzare i dettagli selezionati.");
                    return false;
                }
                if (!CheckInfoFin()) return false;
                if (radioAddCont.Checked == true) {
                    grpInfoOpzionali.Visible = false;
                }
                else {
                    grpInfoOpzionali.Visible = true;
                }
                return true;
            }
            if ((oldTab == 3) && (newTab == 4)) {
                if (!SelezioneMovimentiEffettuata) {
                    show("Non è stato selezionato il movimento.");
                    return false;
                }

                // Vedere se chiamare questo metodo
                RecalcDettagliSelezionati();

                DisplayMessages();
                return doAssocia();
            }
            return true;
        }

        #endregion

        public void MetaData_AfterActivation() {
            CustomTitle = "Wizard Contabilizzazione Dettagli Fattura Acquisto non associati a Contratto Passivo";
            DisplayTabs(0);
        }

        DataRow GetGridRow(DataGrid G, int index) {
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet) G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            string filter;
            DataRow Invoice = DS.invoice.Rows[0];
            filter = QHC.AppAnd(QHC.CmpEq("idinvkind", Invoice["idinvkind"]),
                QHC.CmpEq("yinv", Invoice["yinv"]), QHC.CmpEq("ninv", Invoice["ninv"]), QHC.CmpEq("rownum", G[index, 0]));
            DataRow[] selectresult = MyTable.Select(filter);
            return (selectresult.Length > 0) ? selectresult[0] : null;
        }

        private DataRow[] GetGridSelectedRows(DataGrid G) {
            if (G.DataMember == null) return null;
            if (G.DataSource == null) return null;
            string TableName = G.DataMember;
            DataSet MyDS = (DataSet) G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            int numrighetemp = MyTable.Rows.Count;
            int numrighe = 0;
            int i;
            for (i = 0; i < numrighetemp; i++) {
                if (G.IsSelected(i)) {
                    numrighe++;
                }
            }

            DataRow[] Res = new DataRow[numrighe];
            int count = 0;
            for (i = 0; i < numrighetemp; i++) {
                if (G.IsSelected(i)) {
                    Res[count++] = GetGridRow(G, i);
                }
            }
            return Res;
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHS = Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            GetData.CacheTable(DS.expensephase);
            string filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            fasefattura = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));
            GetData.CacheTable(DS.invoicekind, QHS.AppAnd(QHS.BitClear("flag", 0), QHS.BitClear("flag", 2)),
                "description", true);
            GetData.CacheTable(DS.ivakind);
            GetData.CacheTable(DS.clawback);
            GetData.CacheTable(DS.config, filteresercizio, null, false);
            string billfilter = QHS.AppAnd(QHS.NullOrEq("active", "S"), QHS.CmpEq("billkind", 'D'),
                QHS.CmpEq("ybill", Meta.GetSys("esercizio")));
            GetData.SetStaticFilter(DS.bill, billfilter);
            GetData.SetStaticFilter(DS.billview, billfilter);
            DetailsToUpdate = new ArrayList();
            Meta.CanInsert = false;
            Meta.CanSave = false;
            Meta.SearchEnabled = false;
            monofase = (Conn.RUN_SELECT_COUNT("expensephase", null, true) == 1) ? true : false;
        }

        public void MetaData_AfterClear() {
            DisplayTabs(tabController.SelectedIndex);
        }

        private void btnDocumento_Click(object sender, EventArgs e) {
            string filter = "";
            int esercizio = (int) Meta.GetSys("esercizio");
            int esercText = CfgFn.GetNoNullInt32(txtEsercDoc.Text);
            if (esercText != 0)
                filter = QHS.AppAnd(filter, QHS.CmpEq("yinv", esercText));

            if ((!sender.Equals(btnDocumento)) && txtNumDoc.Text.Trim() != "") {
                int ndoc = CfgFn.GetNoNullInt32(txtNumDoc.Text);
                if (ndoc > 0) filter = QHS.AppAnd(filter, QHS.CmpEq("ninv", ndoc));
            }
            if (cmbTipoFattura.SelectedIndex > 0) {
                filter = filter = QHS.AppAnd(filter, QHS.CmpEq("idinvkind", cmbTipoFattura.SelectedValue));
            }

            filter = QHS.AppAnd(filter, QHS.CmpGt("residual", 0));
            filter = QHS.AppAnd(filter, QHS.NullOrEq("active", "S"));
            MetaData Invoice = MetaData.GetMetaData(this, "invoiceexpavailable");
            Invoice.FilterLocked = true;
            Invoice.DS = new DataSet();
            DataRow M = Invoice.SelectOne("default", filter, null, null);
            if (M == null) return;
            HelpForm.SetComboBoxValue(cmbTipoFattura, M["idinvkind"]);
            txtEsercDoc.Text = M["yinv"].ToString();
            txtNumDoc.Text = M["ninv"].ToString();
            txtFornitore.Text = M["registry"].ToString();
            txtDescrFattura.Text = M["description"].ToString();
            if (M["flag_enable_split_payment"].ToString() == "S")
                chk_Enable_Split_Payment.Checked = true;
            else
                chk_Enable_Split_Payment.Checked = false;
            DS.invoicedetail.Clear();
            DetailsToUpdate.Clear();
            DS.invoice.Clear();

            string filterinvoice = QHS.AppAnd(QHS.CmpEq("idinvkind", M["idinvkind"]),
                QHS.CmpEq("yinv", M["yinv"]), QHS.CmpEq("ninv", M["ninv"]));

            //Parlando con Emilia, il filtro sta bene cosi e va lasciato (task 12287)
            filterinvoice += " AND not exists (select * from profservice where " + filterinvoice + "  )  ";

            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.invoice, null, filterinvoice, null, false);
            //Conn.DeleteAllUnselectable(DS.invoice);
            SetComboCausaleFattura(M);
            AggiornaGridDettagliFattura();
        }

        void ResetWizard() {
            if (DS.invoice.Rows.Count > 0)
                SetComboCausaleFattura(DS.invoice.Rows[0]);
            gridDetails.DataSource = null;
            radioAddCont.Checked = false;
            radioNewLinkedMov.Checked = false;
            radioNewCont.Checked = false;
            choosenParentPhase = 0;
            AggiornaGridDettagliFattura();
            ClearOperationsToDo();
            ClearMovimento();
        }

        void ClearComboCausale() {
            DataTable TCombo = DS.tipomovimento;
            TCombo.Clear();
            lblCausale.Text = "";
        }

        void EnableTipoMovimento(int IDtipo, string descrtipo) {
            DataRow R = DS.tipomovimento.NewRow();
            R["idtipo"] = IDtipo;
            R["descrizione"] = descrtipo;
            DS.tipomovimento.Rows.Add(R);
            DS.tipomovimento.AcceptChanges();
        }

        /// <summary>
        /// Riempie il combobox causale con i valori ammessi, senza impostarvi alcun valore
        /// </summary>
        /// <param name="Ordine"></param>
        void SetComboCausaleFattura(DataRow Fattura) {
            decimal totimponibile = 0;
            decimal totiva = 0;
            decimal assigned_imponibile = 0;
            decimal assigned_iva = 0;
            decimal assigned_gen = 0;
            bool EnableImpon = true;
            bool EnableImpos = true;
            bool EnableDocum = true;
            bool intracom = false;
            bool recuperoIvaEstera = false;

            string filterfattura = QHS.AppAnd(QHS.CmpEq("idinvkind", Fattura["idinvkind"]),
                QHS.CmpEq("yinv", Fattura["yinv"]), QHS.CmpEq("ninv", Fattura["ninv"]));
            DataTable T = Conn.RUN_SELECT("invoiceresidual", "*", null, filterfattura, null, true);
            if ((T != null) && (T.Rows.Count > 0)) {
                foreach (DataRow Dett in T.Rows) {
                    totimponibile += CfgFn.GetNoNullDecimal(Dett["taxabletotal"]);
                    totiva += CfgFn.GetNoNullDecimal(Dett["ivatotal"]);
                    assigned_imponibile += CfgFn.GetNoNullDecimal(Dett["linkedimpon"]);
                    assigned_iva += CfgFn.GetNoNullDecimal(Dett["linkedimpos"]);
                    assigned_gen += CfgFn.GetNoNullDecimal(Dett["linkeddocum"]);
                    if (Dett["flagintracom"].ToString().ToUpper() != "N") intracom = true;
                    int flag = CfgFn.GetNoNullInt32(Dett["flagbit"]);
                    if ((flag & 64) != 0) {
                        recuperoIvaEstera = true;
                    }
                }
            }
            ClearComboCausale();
            if ((intracom) && (!recuperoIvaEstera)) {
                EnableDocum = false;
                EnableImpos = false;
            }

            object currIdInvKind = Fattura["idinvkind"];
            int nVen = CfgFn.GetNoNullInt32(Conn.DO_SYS_CMD(
                "select count(*) from invoicekindregisterkind IIRK " +
                " join ivaregisterkind IRK on IRK.idivaregisterkind = IIRK.idivaregisterkind " +
                " where " +
                QHS.AppAnd(QHS.CmpEq("IIRK.idinvkind", currIdInvKind), QHS.CmpEq("registerclass", "V")
                  )));

            int nAcq = CfgFn.GetNoNullInt32(Conn.DO_SYS_CMD(
             "select count(*) from invoicekindregisterkind IIRK " +
             " join ivaregisterkind IRK on IRK.idivaregisterkind = IIRK.idivaregisterkind " +
             " where " +
             QHS.AppAnd(QHS.CmpEq("IIRK.idinvkind", currIdInvKind), QHS.CmpEq("registerclass", "A")
               )));

            // Nota di credito liquidata  Split Payment, può essere contabilizzato solo imponibile
            if ((Fattura["flag_enable_split_payment"].ToString() == "S") && (nVen > 0) && (nAcq == 0)) {
                EnableDocum = false;
                EnableImpos = false;
            }
            

            //DataRow[] sel = GetGridSelectedRows(gridDetails);
            //if (sel == null) return;
            //object[] upb = ValoriDiversi(sel, "idupb");
            //object[] upb_iva = ValoriDiversi(sel, "idupb_iva");
            //bool upbiva_set = true;
            //if (upb_iva.Length == 1 && upb_iva[0] == DBNull.Value) upbiva_set = false;

            //if (upbiva_set) EnableDocum = false;
            //if (upb.Length > 1) {
            //    if (upb.Length == 2 && upb[0] != DBNull.Value && upb[1] != DBNull.Value) {
            //        EnableImpon = false;
            //        EnableDocum = false;
            //        if (!upbiva_set) EnableImpos = false;
            //    }
            //    if (upb.Length > 2) {
            //        EnableImpon = false;
            //        EnableDocum = false;
            //        if (!upbiva_set) EnableImpos = false;
            //    }
            //}
            //if (upb_iva.Length > 1) {
            //    if (upb_iva.Length == 2 && upb_iva[0] != DBNull.Value && upb_iva[1] != DBNull.Value) {
            //        EnableImpos = false;
            //    }
            //    if (upb_iva.Length > 2) {
            //        EnableImpos = false;
            //    }
            //}

            //string filter_idupbivaset = QHS.AppAnd(filterfattura, QHS.IsNotNull("idupb_iva"));
            //int n_idupbivaset = Conn.RUN_SELECT_COUNT("invoicedetail", filter_idupbivaset, false);

            //if (n_idupbivaset > 0) {
            //    EnableDocum = false;
            //}

            if (EnableDocum &&
                ((assigned_imponibile + assigned_iva) == 0) &&
                (assigned_gen < (totimponibile + totiva))
                ) {
                EnableTipoMovimento(1, "Contabilizzazione Totale Fattura");
            }

            if (EnableImpon &&
                ((assigned_gen == 0) && (assigned_imponibile < totimponibile))
                ) {
                EnableTipoMovimento(3, "Contabilizzazione Imponibile Fattura");
            }

            if (EnableImpos &&
                ((assigned_gen == 0) && (assigned_iva < totiva))
                ) {
                EnableTipoMovimento(2, "Contabilizzazione Iva Fattura");
            }
        }

        void AggiornaGridDettagliFattura() {
            DS.invoicedetail.Clear();
            DetailsToUpdate.Clear();
            if (cmbCausale.SelectedIndex < 0) return;
            int causale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
            if (causale == 0) return;
            string filtercausale = QHC.CmpEq("idtipo", causale);
            lblCausale.Text = "Sulla Causale: " +
                              DS.tipomovimento.Select(filtercausale, null)[0]["descrizione"].ToString();
            if (DS.invoice.Rows.Count == 0) return;

            DataRow M = DS.invoice.Rows[0];
            string filterinvoice = QHS.AppAnd(QHS.CmpEq("idinvkind", M["idinvkind"]), QHS.CmpEq("yinv", M["yinv"]),
                QHS.CmpEq("ninv", M["ninv"]));

            string filterinvoicedetail = filterinvoice;
            if (causale == 1) {
                // Se è abilitato DOCUM significa che non ci sono contabilizzazioni diverse da ORDIN attivate,
                // ossia tutti i dettagli sono o contabilizzati del tutto o per niente
                // --> basta un filtro su idexp_iva is null
                filterinvoicedetail = QHS.AppAnd(filterinvoicedetail, QHS.IsNull("idexp_iva"),
                    QHS.IsNull("idexp_taxable"));
            }
            if (causale == 3) {
                // Se è abilitato IMPON significa che non ci sono contabilizzazioni ORDIN attivate,
                // ossia tutti i dettagli sono contabilizzati con imponibile + iva
                // --> basta un filtro su idexp_taxable is null
                filterinvoicedetail = QHS.AppAnd(filterinvoicedetail, QHS.IsNull("idexp_taxable"));
            }
            if (causale == 2) {
                // Se è abilitato IMPOS significa che non ci sono contabilizzazioni diverse da ORDIN attivate,
                // ossia tutti i dettagli sono o contabilizzati con imponibile + iva
                // --> basta un filtro su idexp_iva is null
                filterinvoicedetail = QHS.AppAnd(filterinvoicedetail, QHS.IsNull("idexp_iva"));
            }

            filterinvoicedetail = QHS.AppAnd(filterinvoicedetail, QHS.CmpNe("idpccdebitstatus", "NOLIQ"));

            DSCopy = DS.Copy();
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DSCopy.Tables["invoicedetail"], null, filterinvoicedetail, null,
                false);
            Conn.DeleteAllUnselectable(DSCopy.Tables["invoicedetail"]);

            MetaData MD = MetaData.GetMetaData(this, "invoicedetail");
            MD.DS = DSCopy;
            MD.DescribeColumns(DSCopy.Tables["invoicedetail"], "wizardiva");
            GetData GD = new GetData();
            GD.InitClass(DSCopy, Conn, "invoicedetail");
            GD.GetTemporaryValues(DSCopy.Tables["invoicedetail"]);
            gridDetails.DataSource = null;
            HelpForm.SetDataGrid(gridDetails, DSCopy.Tables["invoicedetail"]);
            btnSelectAllDetail_Click(null, null);
            VisualizzaUPB();
            RecalcTotalDetails();
        }

        private void cmbCausale_SelectedIndexChanged(object sender, EventArgs e) {
            AggiornaGridDettagliFattura();
        }

        void ClearFattura() {
            txtNumDoc.Text = "";
            txtDescrFattura.Text = "";
            txtFornitore.Text = "";
            DS.invoice.Clear();
            if (DSCopy != null) {
                DSCopy.Tables["invoicedetail"].Clear();
            }
            DS.invoicedetail.Clear();
            DetailsToUpdate.Clear();
            RecalcTotalDetails();
        }
        bool insideLeave = false;

        private void txtEsercDoc_Leave(object sender, EventArgs e) {
            if (inChiusura) return;
            if (insideLeave) return;
            int YInv = CfgFn.GetNoNullInt32(txtEsercDoc.Text);
            if (YInv <= 0) {
                ClearFattura();
                return;
            }
            if (YInv < 1000) {
                YInv += 2000;
                txtEsercDoc.Text = YInv.ToString();
            }
            if (txtNumDoc.Text.Trim() != "") {
                insideLeave = true;
                btnDocumento_Click(sender, e);
                insideLeave = false;
                return;
            }
        }

        private void txtNumDoc_Leave(object sender, EventArgs e) {
            if (inChiusura) return;
            if (insideLeave) return;
            int NInv = CfgFn.GetNoNullInt32(txtNumDoc.Text);
            if (NInv <= 0) {
                ClearFattura();
                return;
            }
            insideLeave = true;
            btnDocumento_Click(sender, e);
            insideLeave = false;
            return;
        }

        private void btnSelectAllDetail_Click(object sender, EventArgs e) {
            if (gridDetails.DataSource == null) return;
            if (DSCopy != null) {
                for (int i = 0; i < DSCopy.Tables["invoicedetail"].Rows.Count; i++) gridDetails.Select(i);
            }
        }

        void RecalcTotalDetails() {
            if (Meta == null) return;
            txtDaPagare.Text = "";
            txtPerc.Text = "";
            var selected = GetGridSelectedRows(gridDetails);
            if (selected == null || selected.Length == 0) {
                txtTotGenerale.Text = "";
                txtTotImponibile.Text = "";
                txtTotIva.Text = "";
                TotaleDaContabilizzare = 0;
                return;
            }
            if (DS.invoice.Rows.Count == 0) return;
            var invoice = DS.invoice[0];
            var tassocambio = CfgFn.GetNoNullDouble(invoice.exchangerate);

            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (tassocambio == 0) tassocambio = 1;
            double totiva = 0;
            double totimpo = 0;
            double total = 0;
            var causale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
            foreach (var curr in selected) {
                var ivaKind = DS.ivakind.f_Eq("idivakind", curr["idivakind"]).ToList();
                if (ivaKind==null || ivaKind.Count == 0) {
                    show(this, "Non esiste la riga nell'anagrafica dei tipi IVA", "Errore");
                    return;
                }
                var imponibile = CfgFn.GetNoNullDouble(curr["taxable"]);
                var quantitaConfezioni = CfgFn.GetNoNullDouble(curr["npackage"]);
                //var aliquota = CfgFn.GetNoNullDouble(ivaKind[0]["rate"]);
                var sconto = CfgFn.GetNoNullDouble(curr["discount"]);
                var imponibileEur = (imponibile*quantitaConfezioni*(1 - sconto))*tassocambio;
                var ivaEur = CfgFn.GetNoNullDouble(curr["tax"]); // *tassocambio;

                imponibileEur = CfgFn.RoundValuta(imponibileEur);
                ivaEur = CfgFn.RoundValuta(ivaEur);
                switch (causale) {
                    case 3:
                        totimpo += imponibileEur;
                        break;
                    case 2:
                        totiva += ivaEur;
                        break;
                    case 1:
                        totimpo += imponibileEur;
                        totiva += ivaEur;
                        break;
                }

                total = totimpo + totiva;

            }
            switch (causale) {
                case 3:
                    txtTotGenerale.Text = total.ToString("c");
                    txtTotImponibile.Text = totimpo.ToString("c");
                    txtTotIva.Text = "";
                    TotaleDaContabilizzare = CfgFn.GetNoNullDecimal(totimpo);
                    txtTotSelezionato.Text = totimpo.ToString("C");
                    break;
                case 2:
                    txtTotGenerale.Text = total.ToString("c");
                    txtTotImponibile.Text = "";
                    txtTotIva.Text = totiva.ToString("c");
                    TotaleDaContabilizzare = CfgFn.GetNoNullDecimal(totiva);
                    txtTotSelezionato.Text = totiva.ToString("C");
                    break;
                case 1:
                    txtTotGenerale.Text = total.ToString("c");
                    txtTotImponibile.Text = totimpo.ToString("c");
                    txtTotIva.Text = totiva.ToString("c");
                    TotaleDaContabilizzare = CfgFn.GetNoNullDecimal(total);
                    txtTotSelezionato.Text = total.ToString("C");
                    break;
            }
        }

        void VisualizzaUPB() {
            DataTable Details = DSCopy.Tables["invoicedetail"];
            object idupb;
            string filterupb;
            object codeupb;
            if (Details.Rows.Count == 0) return;
            foreach (DataRow Curr in Details.Rows) {
                idupb = Curr["idupb"];
                if (idupb != DBNull.Value) {
                    filterupb = QHS.CmpEq("idupb", idupb);
                    codeupb = Conn.DO_READ_VALUE("upb", filterupb, "codeupb");
                    Curr["!codeupb"] = codeupb;
                }
                idupb = Curr["idupb_iva"];
                if (idupb != DBNull.Value) {
                    filterupb = QHS.CmpEq("idupb", idupb);
                    codeupb = Conn.DO_READ_VALUE("upb", filterupb, "codeupb");
                    Curr["!codeupb_iva"] = codeupb;
                }
            }
        }


        private void gridDetails_Paint(object sender, PaintEventArgs e) {
            RecalcTotalDetails();
        }

        private decimal CalcolaTotCausale(DataRow InvoiceDetail, int causale) {
            double tassocambio = CfgFn.GetNoNullDouble(DS.invoice.Rows[0]["exchangerate"]);
            if (tassocambio == 0) tassocambio = 1;
            DataRow Curr = InvoiceDetail;
            DataRow[] IvaKind = DS.ivakind.Select(QHC.CmpEq("idivakind", Curr["idivakind"]));
            if (IvaKind.Length == 0) {
                show(this, "Non esiste la riga nell'anagrafica dei tipi IVA", "Errore");
                return -1;
            }

            double imponibile = CfgFn.GetNoNullDouble(Curr["taxable"]);
            double quantitaConfezioni = CfgFn.GetNoNullDouble(Curr["npackage"]);
            double aliquota = CfgFn.GetNoNullDouble(IvaKind[0]["rate"]);
            double sconto = CfgFn.GetNoNullDouble(Curr["discount"]);
            double imponibileEUR = (imponibile*quantitaConfezioni*(1 - sconto))*tassocambio;
            double ivaEUR = CfgFn.GetNoNullDouble(Curr["tax"]); // *tassocambio;

            imponibileEUR = CfgFn.RoundValuta(imponibileEUR);
            ivaEUR = CfgFn.RoundValuta(ivaEUR);
            if (causale == 1) return CfgFn.GetNoNullDecimal(ivaEUR + imponibileEUR);
            if (causale == 3) return CfgFn.GetNoNullDecimal(imponibileEUR);
            return CfgFn.GetNoNullDecimal(ivaEUR);
        }

        decimal CalcTotCausale(DataRow[] InvoiceDetail, int causale) {
            decimal sum = 0;
            foreach (DataRow R in InvoiceDetail) sum += CalcolaTotCausale(R, causale);
            // verifica se l'importo è diverso da quello digitato dall'utente

            decimal importototale = CfgFn.GetNoNullDecimal(
                HelpForm.GetObjectFromString(typeof(decimal),
                    txtDaPagare.Text, "x.y.c"));
            if (importototale != 0 && importototale != sum) sum = importototale;
            return sum;
        }

        bool SelezioneMovimentiEffettuata = false;

        string FilterAddCont = null;

        object[] ValoriDiversi(DataRow[] rows, string field) {
            if (rows == null) {
                return new object[0];
            }
            var div = new object[rows.Length];
            var n = 0;
            foreach (var r in rows) {
                var currval = r[field];
                int j;
                for (j = 0; j < n; j++) {
                    if (div[j].Equals(currval)) {
                        break;
                    }
                }
                if (j == n) {
                    div[n++] = currval;
                }
            }
            var result = new object[n];
            for (var i = 0; i < n; i++) result[i] = div[i];
            return result;
        }

        List<DataRow> FiltraRows(DataRow[] Rows, string filter) {
            List<DataRow> RR = new List<DataRow>();
            if (Rows.Length == 0) {
                return RR;
            }            
            //DataTable T = DS.invoicedetail;
            DataTable T = DS.invoicedetail;
            DataRow[] found = T.Select(filter);
            var rowFound = new Dictionary<string, bool>();
            foreach (DataRow r in found) {
                string sk = $"{r["idinvkind"]}#{r["yinv"]}#{r["ninv"]}#{r["rownum"]}";
                rowFound.Add(sk,true);
            }
            foreach (DataRow r in Rows) {
                if (r.RowState == DataRowState.Deleted) continue;
                string sk = $"{r["idinvkind"]}#{r["yinv"]}#{r["ninv"]}#{r["rownum"]}";
                if (rowFound.ContainsKey(sk))RR.Add(r);
            }
            
            return RR;
        }

        

        //DataRow AutoSelectedMov = null;

        object idexp_selected=DBNull.Value;

        void FillMovimento(DataRow Expense) {
            idexp_selected = Expense["idexp"];
            txtNumeroMovimento.Text = Expense["nmov"].ToString();
            txtEsercizioMovimento.Text = Expense["ymov"].ToString();
            txtDescrizione.Text = Expense["description"].ToString();
            SubEntity_txtImportoMovimento.Text = CfgFn.GetNoNullDecimal(Expense["amount"]).ToString("c");
            txtDataCont.Text = ((DateTime) Expense["adate"]).ToShortDateString();
            txtCodiceBilancio.Text = Expense["codefin"].ToString();
            txtDenominazioneBilancio.Text = Expense["finance"].ToString();
            txtUPB.Text = Expense["codeupb"].ToString();
            txtDescrUPB.Text = Expense["upb"].ToString();
            txtImportoCorrente.Text = CfgFn.GetNoNullDecimal(Expense["curramount"]).ToString("c");
            txtImportoDisponibile.Text = CfgFn.GetNoNullDecimal(Expense["available"]).ToString("c");

            DataTable expensemandateview = DataAccess.CreateTableByName(Meta.Conn, "expensemandateview", "*");

            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, expensemandateview, null,
                QHS.CmpEq("idexp", idexp_selected), null, true);
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.expenseclawback, null,
                QHS.CmpEq("idexp", idexp_selected), null, true);
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.expensesorted, null,
                QHS.CmpEq("idexp", idexp_selected), null, true);

            if ((expensemandateview != null) && (expensemandateview.Rows.Count != 0)) {
                DataRow EM = expensemandateview.Rows[0];
                string msg = "Il movimento " + Expense["ymov"].ToString() + "/" + Expense["nmov"].ToString()
                             + " contabilizza il contratto passivo " + EM["mankind"].ToString() + " " +
                             EM["yman"].ToString()
                             + "/" + EM["nman"].ToString();

                lblWarningMandate.Text = msg;
                lblWarningMandate.Visible = true;
            }
            else {

                lblWarningMandate.Visible = false;
            }
        }

        void ClearMovimento() {
            idexp_selected = DBNull.Value;
            txtNumeroMovimento.Text = "";
            txtEsercizioMovimento.Text = "";
            txtDescrizione.Text = "";
            SubEntity_txtImportoMovimento.Text = "";
            txtDataCont.Text = "";
            txtCodiceBilancio.Text = "";
            txtDenominazioneBilancio.Text = "";
            txtUPB.Text = "";
            txtDescrUPB.Text = "";
            txtImportoCorrente.Text = "";
            txtImportoDisponibile.Text = "";
            lblWarningMandate.Text = "";
            lblWarningMandate.Visible = false;
        }


        string filterMovimento;

        void AbilitaDisabilitaSelezioneMovimento(bool enable) {
            gboxMovimento.Enabled = enable;
        }

        private void btnSelectMov_Click(object sender, EventArgs e) {
            //se true, deve visualizzare le contabilizzazioni disponibili
            bool allInvoice = radioAddCont.Checked;
            int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            string filter = "(ayear='" + esercizio.ToString() + "')";
            filter = GetData.MergeFilters(filter, filterMovimento);

            int esercText = CfgFn.GetNoNullInt32(txtEsercizioMovimento.Text);
            if (esercText > 0) {
                filter = QHS.AppAnd(filter, QHS.CmpEq("ymov", esercText));
            }

            if ((!sender.Equals(btnSelectMov)) && txtNumeroMovimento.Text.Trim() != "") {
                int nmov = CfgFn.GetNoNullInt32(txtNumeroMovimento.Text);
                if (nmov > 0)
                    filter =
                        filter = QHS.AppAnd(filter, QHS.CmpEq("nmov", nmov));
            }
            int phase;
            if (radioAddCont.Checked)
                phase = fasefattura;
            else
                phase = choosenParentPhase;

            filter = QHS.AppAnd(filter, QHS.CmpEq("nphase", phase));
            MetaData ExpenseToConsider;
            ExpenseToConsider = MetaData.GetMetaData(this, "expense");
            ExpenseToConsider.FilterLocked = true;
            ExpenseToConsider.DS = new DataSet();
            DataRow M = ExpenseToConsider.SelectOne("default", filter, null, null);
            if (M == null) return;
            FillMovimento(M);
            idexp_selected = M["idexp"];
            SelezioneMovimentiEffettuata = true;
        }

        private void radioAddCont_CheckedChanged(object sender, EventArgs e) {
            if (inChiusura) return;
            if (radioAddCont.Checked) SetAddCont();
            //labelAddCont.Visible = radioAddCont.Checked;
        }

        private void radioNewCont_CheckedChanged(object sender, EventArgs e) {
            if (inChiusura) return;
            if (radioNewCont.Checked) SetNewMov();
        }

        private bool verificaSeUPBUniformi(object[] upb, object[] upb_iva, int causale) {
            object[] upb_to_consider = upb;
            if (causale == 2) {
                if (upb_iva.Length > 1) upb_to_consider = upb_iva;
                if (upb_iva.Length == 1 && upb_iva[0] != DBNull.Value) upb_to_consider = upb_iva;
            }

            // non ci sono righe nell'array di oggetti o se è una sola OK
            if ((upb_to_consider.Length == 0) || (upb_to_consider.Length == 1)) return true;
            // Se esistono più di 2 righe sicuramente ci sono UPB differenti
            if (upb_to_consider.Length > 2) return false;
            // Se ci sono 2 righe allora bisogna vedere se una delle due è NULL, se si ok altrimenti no
            if (upb_to_consider.Length == 2) {
                if ((upb_to_consider[0] == DBNull.Value) || (upb_to_consider[1] == DBNull.Value)) return true;
            }
            return false;
        }

        private string GetFilterUpb(object[] upb, object[] upb_iva, int causale, QueryHelper QH) {
            object[] upb_to_consider = upb;
            string field_to_consider = "idupb";
            if (causale == 2) {
                if (upb_iva.Length > 1) {
                    upb_to_consider = upb_iva;
                    //field_to_consider = "idupb_iva";
                }
                if (upb_iva.Length == 1 && upb_iva[0] != DBNull.Value) {
                    upb_to_consider = upb_iva;
                    //field_to_consider = "idupb_iva";
                }
            }

            // non ci sono righe nell'array di oggetti o se è una sola OK
            if (upb_to_consider.Length == 0) return "";
            if (upb_to_consider.Length == 1) {
                if (upb_to_consider[0] == DBNull.Value) return "";
                return QH.CmpEq(field_to_consider, upb_to_consider[0]);
            }
            // Se esistono più di 2 righe sicuramente ci sono UPB differenti
            if (upb_to_consider.Length > 2) return "";
            // Se ci sono 2 righe allora bisogna vedere se una delle due è NULL, se si ok altrimenti no
            if (upb_to_consider.Length == 2) {
                if (upb_to_consider[0] == DBNull.Value) return QH.CmpEq(field_to_consider, upb_to_consider[1]);
                if (upb_to_consider[1] == DBNull.Value) return QH.CmpEq(field_to_consider, upb_to_consider[0]);
            }
            return "";
        }



        private string calcolaFilterAddCont() {
            int causale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);

            DataRow[] Selected = GetGridSelectedRows(gridDetails);
            if ((Selected == null) || (Selected.Length == 0)) {
                return null;
            }
            object[] upb_ = ValoriDiversi(Selected, "idupb");
            object[] upb_iva = ValoriDiversi(Selected, "idupb_iva");
            if (!verificaSeUPBUniformi(upb_, upb_iva, causale)) {
                return null;
            }
            if (DS.invoice.Rows.Count == 0) return null;
            string filterupb = GetFilterUpb(upb_, upb_iva, causale, QHS);

            /*if (FiltraRows(Selected, QHC.IsNotNull("idupb")).Length > 0) {
               DataRow rUpb = FiltraRows(Selected, QHC.IsNotNull("idupb"))[0];
               filterupb = QHS.CmpEq("idupb", rUpb["idupb"]);
           }*/

            DataRow Invoice = DS.invoice.Rows[0];
            string filteridreg = QHS.CmpEq("idreg", Invoice["idreg"]);

            decimal importoupb = CalcTotCausale(FiltraRows(Selected, filterupb).ToArray(), causale);

            string filtercont = "";
            int lenCont = 8*CfgFn.GetNoNullInt32(Meta.GetSys("mandatephase"));
            //filtercont = GetData.MergeFilters(filtercont,
            //    "(NOT SUBSTRING(idexp,1," + lenCont + ") in (SELECT idexp from expensemandate))");
            filtercont = QHS.AppAnd(filtercont,
                "(NOT idexp in (select idchild from expenselink join expenseitineration on " +
                "expenselink.idparent=expenseitineration.idexp) )");
            filtercont = QHS.AppAnd(filtercont,
                "(NOT idexp in (select idchild from expenselink join expensecasualcontract on " +
                "expenselink.idparent=expensecasualcontract.idexp) )");
            //filtercont = QHS.AppAnd(filtercont,
            //    "(NOT idexp in (select idchild from expenselink join expenseprofservice on " +
            //    "expenselink.idparent=expenseprofservice.idexp) )");
            filtercont = QHS.AppAnd(filtercont,
                "(NOT idexp in (select idchild from expenselink join expensepayroll on " +
                "expenselink.idparent=expensepayroll.idexp) )");
            filtercont = QHS.AppAnd(filtercont,
                "(NOT idexp in (select idchild from expenselink join expensewageaddition on " +
                "expenselink.idparent=expensewageaddition.idexp) )");



            filtercont = QHS.AppAnd(filtercont, "(NOT idexp in (SELECT idexp from expenseinvoice))");

            filtercont = GetData.MergeFilters(filtercont, filterupb);

            string esercizio = Meta.GetSys("esercizio").ToString();
            filtercont = QHS.AppAnd(filtercont, filteridreg);
            filtercont = GetData.MergeFilters(filtercont, QHS.CmpEq("curramount", importoupb));
            filtercont = QHS.AppAnd(filtercont, QHS.CmpEq("ayear", esercizio));
            filtercont = QHS.AppAnd(filtercont, QHS.CmpEq("nphase", fasefattura));
            return filtercont;
        }

        void SetAddCont() {
            FilterAddCont = calcolaFilterAddCont();
            if (FilterAddCont != null) {
                AbilitaDisabilitaSelezioneMovimento(true);
                filterMovimento = FilterAddCont;
                SelezioneMovimentiEffettuata = false;
                labMsgTODO1.Text = "I dettagli selezionati saranno aggiunti al movimento selezionato";
                labMsgTODO2.Text = "";
                btnSelectMov_Click(btnSelectMov, null);
            }
            else {
                AbilitaDisabilitaSelezioneMovimento(false);
                filterMovimento = null;
                SelezioneMovimentiEffettuata = true;
                labMsgTODO1.Text = "I dettagli selezionati saranno aggiunti al movimento selezionato automaticamente";
                labMsgTODO2.Text = "";
            }
            string filterfase = QHS.CmpEq("nphase", fasefattura);
            string descfasefattura = "";
            descfasefattura = Conn.DO_READ_VALUE("expensephase", filterfase, "description").ToString();
            if (descfasefattura != "") {
                gboxMovimento.Text = descfasefattura;
            }
            gboxSelMov.Enabled = true;

        }

        void SetNewMov() {
            ClearMovimento();
            AbilitaDisabilitaSelezioneMovimento(false);
            SelezioneMovimentiEffettuata = true; //!!
            int primafasespesa = 1;
            string filterfase = QHS.CmpEq("nphase", primafasespesa);
            object descfase = Conn.DO_READ_VALUE("expensephase", filterfase, "description");
            if (descfase != null) {
                gboxMovimento.Text = descfase.ToString();
            }

        }

        void SetNewLinkedMov() {
            if (inChiusura) return;
            if (DS.invoice.Rows.Count == 0) return;
            DataRow Inv = DS.invoice.Rows[0];
            DataRow[] Selected = GetGridSelectedRows(gridDetails);
            string filterregistry = QHS.CmpEq("idreg", Inv["idreg"]);

            int fasecred = CfgFn.GetNoNullInt32(Meta.GetSys("expenseregphase"));
            int fasebilancio = CfgFn.GetNoNullInt32(Meta.GetSys("expensefinphase"));

            DataTable tempFase = DataAccess.CreateTableByName(Meta.Conn, "expensephase", "*");
            foreach (DataRow rFase in DS.expensephase.Rows) {
                if (CfgFn.GetNoNullInt32(rFase["nphase"]) >= fasefattura) continue;
                DataRow r = tempFase.NewRow();
                foreach (DataColumn c in DS.expensephase.Columns) {
                    r[c.ColumnName] = rFase[c.ColumnName];
                }
                tempFase.Rows.Add(r);
            }

            FrmAskFase faf = new FrmAskFase(tempFase);
            createForm(faf, null);
            DialogResult dr = faf.ShowDialog();
            if (dr != DialogResult.OK) return;
            choosenParentPhase = CfgFn.GetNoNullInt32(faf.cmbFasi.SelectedValue);

            int currcausale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
            if (currcausale == 1) {
                decimal importototale = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal),
                    txtTotGenerale.Text, "x.y.c"));
                //if (importototale != TotaleDaContabilizzare) TotaleDaContabilizzare = importototale;
            }
            if (currcausale == 3) {
                decimal importoimponibile = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal),
                    txtTotImponibile.Text, "x.y.c"));
                //if (importoimponibile != TotaleDaContabilizzare) TotaleDaContabilizzare = importoimponibile;
            }
            if (currcausale == 2) {
                decimal importoiva = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal),
                    txtTotIva.Text, "x.y.c"));
                //if (importoiva != TotaleDaContabilizzare) TotaleDaContabilizzare = importoiva;
            }

            decimal ImportoDaPagare = CfgFn.GetNoNullDecimal(
                HelpForm.GetObjectFromString(typeof(decimal),
                    txtDaPagare.Text, "x.y.c"));

            if ((ImportoDaPagare != 0) && (ImportoDaPagare < TotaleDaContabilizzare)) {
                filterMovimento = QHS.CmpGe("available", ImportoDaPagare);
            }
            else {
                filterMovimento = QHS.CmpGe("available", TotaleDaContabilizzare);
            }

            filterMovimento = GetData.MergeFilters(filterMovimento, QHS.CmpEq("nphase", choosenParentPhase));
            if (fasecred <= choosenParentPhase) {
                filterMovimento = QHS.AppAnd(filterregistry, filterMovimento);
            }
            if (fasebilancio <= choosenParentPhase) {
                if ((Selected != null) && (Selected.Length != 0)) {
                    DataRow InvDett = Selected[0];
                    //if (InvDett["idupb"] != DBNull.Value) {
                    //    filterMovimento = QHS.AppAnd(filterMovimento, QHS.CmpEq("idupb", InvDett["idupb"]));
                    //}
                    object[] upb = ValoriDiversi(Selected, "idupb");
                    object[] upb_iva = ValoriDiversi(Selected, "idupb_iva");
                    string field = "idupb";
                    int causale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
                    if (causale == 2) {
                        if (upb_iva.Length > 1 || upb_iva[0] != DBNull.Value) {
                            upb = upb_iva;
                            field = "idupb_iva";
                        }
                    }
                    if (InvDett[field] != DBNull.Value) {
                        filterMovimento = QHS.AppAnd(filterMovimento, QHS.CmpEq("idupb", InvDett[field]));
                    }
                }
            }

            int faseContabCompensi = CfgFn.GetNoNullInt32(Meta.GetSys("mandatephase"));
            string filterCont = "";
            if (choosenParentPhase == faseContabCompensi) {
                filterCont = "(idexp not in (select idexp from expensecasualcontract)) " +
                             " AND (idexp not in (select idexp from expenseitineration)) " +
                             " AND (idexp not in (select idexp from expensewageaddition)) " +
                             " AND (idexp not in (select idexp from expensepayroll)) " +
                             " AND (idexp not in (select idexp from expenseprofservice))";
            }
            filterMovimento = GetData.MergeFilters(filterMovimento, filterCont);
            ClearMovimento();
            AbilitaDisabilitaSelezioneMovimento(true);
            SelezioneMovimentiEffettuata = false;
            labMsgTODO1.Text = "Sarà creato un nuovo movimento di spesa";


            if (fasefattura > 1) {
                string filterfase = QHS.CmpEq("nphase", choosenParentPhase);
                object  descfaseprecedente =  Conn.DO_READ_VALUE("expensephase", filterfase, "description");
                if (descfaseprecedente != null ) {
                    gboxMovimento.Text = descfaseprecedente.ToString();
                }
            }
        }

        void RadioCheck_Changed() {
            if (inChiusura) return;
            if (radioAddCont.Checked) SetAddCont();
            if (radioNewCont.Checked) SetNewMov();
            if (radioNewLinkedMov.Checked) SetNewLinkedMov();
        }

        private void txtEsercizioMovimento_Leave(object sender, EventArgs e) {
            if (inChiusura) return;
            if (txtEsercizioMovimento.ReadOnly == true) return;
            int Ymov = CfgFn.GetNoNullInt32(txtEsercizioMovimento.Text);
            if (Ymov <= 0) {
                ClearMovimento();
                SelezioneMovimentiEffettuata = false;
                return;
            }
            if (Ymov < 1000) {
                Ymov += 2000;
                txtEsercizioMovimento.Text = Ymov.ToString();
            }
            if (txtNumeroMovimento.Text.Trim() != "") {
                btnSelectMov_Click(sender, e);
                return;
            }
        }

        private void txtNumeroMovimento_Leave(object sender, EventArgs e) {
            if (inChiusura) return;
            int NMov = CfgFn.GetNoNullInt32(txtNumeroMovimento.Text);
            if (NMov <= 0) {
                ClearMovimento();
                return;
            }
            if (txtEsercizioMovimento.Text.Trim() != "") {
                btnSelectMov_Click(sender, e);
                return;
            }
        }

        private void radioNewLinkedMov_CheckedChanged(object sender, EventArgs e) {
            if (inChiusura) return;
            if (radioNewLinkedMov.Checked) {
                SetNewLinkedMov();
            }
        }

        object idmanagerSelected;
        object idUPBSelected;
        object idfinSelected;

        bool CheckInfoFin() {
            idUPBSelected = null;
            if (radioAddCont.Checked) {
                gboxBilToCreate.Visible = false;
                return true; //movimento esistente!
            }
            if (radioNewLinkedMov.Checked) {
                //Prende il creditore ed il responsabile dall'ordine, quindi non ha bisogno di nulla!!
                int fasebilancio = CfgFn.GetNoNullInt32(Meta.GetSys("expensefinphase"));
                //				int faseordine= CfgFn.GetNoNullInt32( Meta.GetSys("mandatephase"));
                if (choosenParentPhase >= fasebilancio) {
                    gboxBilToCreate.Visible = false;
                    return true;
                }
                //Se passa di qui deve creare un nuovo mov. di spesa, agganciandolo ad una fase s
                // in cui non è prevista l'informazione del bilancio
            }
            decimal amount = 0;
            decimal ImportoDaPagare = CfgFn.GetNoNullDecimal(
                HelpForm.GetObjectFromString(typeof(decimal),
                    txtDaPagare.Text, "x.y.c"));
            if ((ImportoDaPagare != 0) && (ImportoDaPagare < TotaleDaContabilizzare)) {
                amount = ImportoDaPagare;
            }
            else {
                amount = TotaleDaContabilizzare;
            }

            DataRow[] Selected = GetGridSelectedRows(gridDetails);
      
            object idupb = DBNull.Value;
            object[] upb = ValoriDiversi(Selected, "idupb");
            object[] upb_iva = ValoriDiversi(Selected, "idupb_iva");
            string field = "idupb";
            int causale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
            if (causale == 2) {
                if (upb_iva.Length > 1 || (upb_iva.Length > 0 && upb_iva[0] != DBNull.Value)) {
                    upb = upb_iva;
                    field = "idupb_iva";
                }
            }

            string filter = QHC.IsNull(field);
            if ((FiltraRows(Selected, filter).Count > 0) && (upb.Length == 2)) {
                object idupbtoassign = DBNull.Value;
                var Details = FiltraRows(Selected, QHC.IsNotNull(field));
                if (Details.Count > 0) idupbtoassign = Details[0][field];
                upb = new object[] { idupbtoassign };
            }

            object idman_start = null;
            bool manager_in_details = false;
            if (upb.Length == 1) {
                if (upb[0].ToString() != "") idupb = upb[0];
            }
            else {
                foreach (object myidupb in upb) {
                    string filtermyupb = QHC.CmpEq("idupb", myidupb);
                    object idman_mydetail = Conn.DO_READ_VALUE("upb", filtermyupb, "idman");
                    if (idman_mydetail != DBNull.Value) manager_in_details = true;
                }
                if (manager_in_details) idman_start = DBNull.Value; //idman_start=null significa idman BLOCCATO 
            }
            string filterupb = null;
            if (idupb.ToString() == "") idupb = DBNull.Value;
            if (idupb != DBNull.Value) {
                filterupb = QHC.CmpEq("idupb", idupb);
                object idman_detail = Conn.DO_READ_VALUE("upb", filterupb, "idman");
                if (idman_detail != DBNull.Value) idman_start = idman_detail;
            }
            bool upbToSelect = true;
            if (FiltraRows(Selected, QHC.IsNotNull("idupb")).Count > 0 || idupb != DBNull.Value) {
                upbToSelect = false;
            }

            object idfin = DBNull.Value;
            int count = CfgFn.GetNoNullInt32(Conn.count("finusable", q.bitClear("flag", 1) & q.bitSet("flag", 0) & q.eq("ayear", Meta.GetSys("esercizio"))));
            if (monofase && count == 1) {
                idfin = Conn.readValue("finusable", q.bitClear("flag", 1) & q.bitSet("flag", 0) & q.eq("ayear", Meta.GetSys("esercizio")), "idfin");
			}

            FrmAskInfo F = new FrmAskInfo(Meta, "S", upbToSelect)
                .SetManager(idman_start)
                .SetUPB(idupb)
                .SetFin(idfin)
                .EnableFilterAvailable(amount)
                .EnableUPBSelection(upbToSelect);

            F.Text = "Selezione Upb e Bilancio";
            if (manager_in_details)
                F.EnableManagerSelection(false);
            else
                F.AllowNoManagerSelection(true);

            //S", filterupb, Meta.Dispatcher, idman_start, amount, upbToSelect);
            createForm(F, this);
            if (F.ShowDialog(this) != DialogResult.OK) return false;

            if (idman_start == null)
                idmanagerSelected = null;
            else
                idmanagerSelected = F.GetManager();

            idUPBSelected = F.GetUPB();
            idfinSelected = F.GetFin();

            F.Destroy();
            if (idfinSelected != DBNull.Value) {
                DataTable T = Conn.RUN_SELECT("fin", "*", null, QHS.CmpEq("idfin", idfinSelected), null, false);
                if (T != null && T.Rows.Count > 0) {
                    DataRow RB = T.Rows[0];
                    txtCodeBilSelected.Text = RB["codefin"].ToString();
                    txtDenomBilSelected.Text = RB["title"].ToString();
                    gboxBilToCreate.Visible = true;
                }
            }
           
            return true;
        }

        bool doAssocia() {
            if (radioNewCont.Checked) {
                DS.expense.Clear();
                DS.expenseyear.Clear();
                DS.expenseclawback.Clear();
                DS.expensesorted.Clear();
                DS.expenselast.Clear();
                DS.expenseinvoice.Clear();
                return doSaveNewExpense(null);
            }
            if (radioNewLinkedMov.Checked) {
                DS.expense.Clear();
                DS.expenseyear.Clear();
                DS.expenseclawback.Clear();
                DS.expensesorted.Clear();
                DS.expenselast.Clear();
                DS.expenseinvoice.Clear();
                return doSaveNewExpense(idexp_selected);
            }
            if (radioAddCont.Checked) {
                DS.expenseinvoice.Clear();
                DS.expenseclawback.Clear();
                DS.expensesorted.Clear();
                DS.expenseyear.Clear();
                DS.expenselast.Clear();
                DS.expense.Clear();
                return doAddConta();
            }
            return false;
        }

        bool doAssociaSoloDettagli() {
            int esercizio = Convert.ToInt32(Meta.GetSys("esercizio"));
            string filter = QHS.CmpEq("idexp", idexp_selected);
            Conn.RUN_SELECT_INTO_TABLE(DS.expense, null, filter, null, false);
            Conn.RUN_SELECT_INTO_TABLE(DS.expenseyear, null, QHS.AppAnd(filter, QHS.CmpEq("ayear", esercizio)) , null, false);
            Conn.RUN_SELECT_INTO_TABLE(DS.expenseclawback, null, filter, null, false);
            Conn.RUN_SELECT_INTO_TABLE(DS.expenselast, null, filter, null, false);
            Conn.RUN_SELECT_INTO_TABLE(DS.expensesorted, null, filter, null, false);
            if (DS.expense.Rows.Count > 0) {
                DataRow Inv = DS.invoice.Rows[0];
                DataRow CurrExp = DS.expense.Rows[0];
                object NuovoDocumento = Inv["doc"];
                object NuovoDataDocumento = Inv["docdate"];
                if (show(this, "Aggiorno i campi documento e data documento del movimento di spesa " +
                                          "in base al documento selezionato?", "Conferma", MessageBoxButtons.OKCancel) ==
                    DialogResult.OK) {
                    if ((NuovoDocumento != null) && (NuovoDocumento != DBNull.Value))
                        CurrExp["doc"] = NuovoDocumento;
                    if (NuovoDataDocumento != null) CurrExp["docdate"] = NuovoDataDocumento;
                }
            }
            int currcausale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
            DataRow[] Selected = GetGridSelectedRows(gridDetails);
            string listRownum = "(";
            foreach (int rownum in DetailsToUpdate) {
                listRownum += rownum.ToString() + ",";
            }
            listRownum = listRownum.Substring(0, listRownum.Length - 1) + ")";
            string filterDetails = null;
            if (listRownum != "") filterDetails = "(rownum in " + listRownum + ")";
            DataRow[] Details = DS.invoicedetail.Select(filterDetails);
            foreach (DataRow R in Details) {
                switch (currcausale) {
                    case 1:
                        R["idexp_taxable"] = idexp_selected;
                        R["idexp_iva"] = idexp_selected;
                        break;
                    case 3:
                        R["idexp_taxable"] = idexp_selected;
                        break;
                    case 2:
                        R["idexp_iva"] = idexp_selected;
                        break;
                }
            }

            AggiornaUPBDettagli(Selected, currcausale);

            if (DS.expenseyear.Rows[0]["idupb"] != DBNull.Value) idUPBSelected = DS.expenseyear.Rows[0]["idupb"];

            decimal ImportoDaRecuperare = GetIVADettagliFattura(Details);
            GeneraOAzzeraRecuperoSplitPayment(DS.expense.Rows[0], ImportoDaRecuperare);
            GeneraOAzzeraRecuperoIvaEstera(DS.expense.Rows[0], ImportoDaRecuperare);
            DataRow NewLastMov = DS.expenselast.Rows[0];
            if (chkAutomRecuperi.Checked) {
                int flag = CfgFn.GetNoNullInt32(NewLastMov["flag"]);
                flag = flag | 4;
                NewLastMov["flag"] = flag;
            }
            return doSave();
        }

        bool doSave() {

            DataSet DSP = DS.Copy();
            int fasespesamax = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));
            GestioneAutomatismi ga = new GestioneAutomatismi(this, Meta.Conn, Meta.Dispatcher,
                DS, fasefattura, fasespesamax, "expense", true);
            string newcomputesorting = Meta.Conn.DO_READ_VALUE("siopekind",
                QHS.AppAnd(QHS.CmpEq("codesorkind_siopespese", Meta.GetSys("codesorkind_siopespese")),
                            QHS.CmpEq("ayear", CfgFn.GetNoNullInt32(Meta.GetSys("esercizio")))
                    ),
                "newcomputesorting")?.ToString();
            if (newcomputesorting == "S" && ! radioAddCont.Checked)  {         
                 GestioneClassificazioni ManageClassificazioni = new GestioneClassificazioni(Meta, null, null, null, null, null, null, null, null);
                 ManageClassificazioni.ClassificaTramiteClassDocumento(ga.DSP, DS);
				 ManageClassificazioni.completaClassificazioniSiope(DS.expensesorted, ga.DSP);
				 //Meta.FreshForm();

			}

			ga.GeneraClassificazioniAutomatiche(ga.DSP, true);
            bool res = ga.GeneraAutomatismiAfterPost(true);
            if (!res) {
                show(this,
                    "Si è verificato un errore o si è deciso di non salvare! L'operazione sarà terminata");
                return false;
            }
            res = ga.doPost(Meta.Dispatcher);
            if (res) ViewAutomatismi(ga.DSP);

            if (!res) {
                return false;
            }
            DS.AcceptChanges();
            DS.expenseinvoice.Clear();
            DS.invoicedetail.Clear();
            DS.expense.Clear();
            DS.expenseyear.Clear();
            DS.expenseclawback.Clear();
            DS.expensesorted.Clear();
            DS.expenselast.Clear();
            DS.registry.Clear();
            return true;
        }


        //-----------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------
        void GeneraRigaRecuperoSplitPayment_o_IvaEstera(DataRow Parent, object codice, decimal importo) {
            DataRow[] found =
                DS.expenseclawback.Select(QHC.AppAnd(QHC.CmpEq("idclawback", codice),
                    QHC.CmpEq("idexp", Parent["idexp"])));
            DataRow Recupero;
            if (found.Length > 0) {

                Recupero = found[0];
                if (Recupero.RowState != DataRowState.Added) return;
                if (CfgFn.GetNoNullDecimal(Recupero["amount"]) == importo) return;
            }
            else {
                MetaData MetaRec = MetaData.GetMetaData(this, "expenseclawback");
                MetaRec.SetDefaults(DS.expenseclawback);
                DS.expenseclawback.Columns["idclawback"].DefaultValue = codice;
                Recupero = MetaRec.Get_New_Row(Parent, DS.expenseclawback);
                DS.expenseclawback.Columns["idclawback"].DefaultValue = DBNull.Value;
            }

            Recupero["amount"] = importo;
            Recupero["!clawbackref"] = DS.clawback.Compute("MIN(clawbackref)",
                QHC.CmpEq("idclawback", Recupero["idclawback"]));
        }

        void GeneraOAzzeraRecuperoSplitPayment(DataRow Parent, decimal ImportoDaRecuperare) {
            if (DS.clawback.Rows.Count == 0) return;
            if (DS.invoice.Rows.Count == 0)
                return;
            DataRow Fattura = DS.invoice.Rows[0];
            bool intracom = false;
            if (Fattura["flagintracom"].ToString().ToUpper() != "N") intracom = true;
            int flag = CfgFn.GetNoNullInt32(Fattura["flagbit"]);
            if (intracom && (flag & 64) != 0) //Verrà generato il Recupero IVA Intra ed Extra-UE 
                return;
            object currIdInvKind = Fattura["idinvkind"];
            int nAcq = CfgFn.GetNoNullInt32(Conn.DO_SYS_CMD(
                "select count(*) from invoicekindregisterkind IIRK " +
                " join ivaregisterkind IRK on IRK.idivaregisterkind = IIRK.idivaregisterkind " +
                " where " +
                QHS.AppAnd(QHS.CmpEq("IIRK.idinvkind", currIdInvKind), QHS.CmpEq("registerclass", "A"),
                    QHS.CmpNe("flagactivity", 1))));

            bool isAcquistoCommerciale = nAcq > 0;
            string codeClawBack = isAcquistoCommerciale ? "16_SPLIT_PAYMENT_C" : "15_SPLIT_PAYMENT";

            DataRow[] RSplitPayment = DS.clawback.Select(QHC.CmpEq("clawbackref", codeClawBack));
            if (RSplitPayment.Length == 0) return;

            if (Fattura["flag_enable_split_payment"].ToString() == "N") return;

            object codicerecupero = RSplitPayment[0]["idclawback"];
            if (codicerecupero == DBNull.Value) return;


            // Calcolo importo IVA da contabilizzare
            if (ImportoDaRecuperare == 0) {
                AzzeraRigaRecupero(Parent, codicerecupero);
                return;
            }
            GeneraRigaRecuperoSplitPayment_o_IvaEstera(Parent, codicerecupero, ImportoDaRecuperare);

        }

        void GeneraOAzzeraRecuperoIvaEstera(DataRow Parent, decimal ImportoDaRecuperare) {
            if (DS.clawback.Rows.Count == 0) return;
            if (DS.invoice.Rows.Count == 0)
                return;
            DataRow Fattura = DS.invoice.Rows[0];
            bool intracom = false;
            if (Fattura["flagintracom"].ToString().ToUpper() != "N") intracom = true;
            if (!intracom) return;

            int flag = CfgFn.GetNoNullInt32(Fattura["flagbit"]);
            if ((flag & 64) == 0) //Recupero IVA Intra ed Extra-UE = N
                return;
            object currIdInvKind = Fattura["idinvkind"];
            int nAcq = CfgFn.GetNoNullInt32(Conn.DO_SYS_CMD(
                "select count(*) from invoicekindregisterkind IIRK " +
                " join ivaregisterkind IRK on IRK.idivaregisterkind = IIRK.idivaregisterkind " +
                " where " +
                QHS.AppAnd(QHS.CmpEq("IIRK.idinvkind", currIdInvKind), QHS.CmpEq("registerclass", "A"),
                    QHS.FieldIn("flagactivity", new object[] { 2, 3, 4 }))));//Comm. Promoscuo o qualsiasi

            bool isAcquistoCommerciale = nAcq > 0;
            int nIst = CfgFn.GetNoNullInt32(Conn.DO_SYS_CMD(
                "select count(*) from invoicekindregisterkind IIRK " +
                " join ivaregisterkind IRK on IRK.idivaregisterkind = IIRK.idivaregisterkind " +
                " where " +
                QHS.AppAnd(QHS.CmpEq("IIRK.idinvkind", currIdInvKind), QHS.CmpEq("registerclass", "A"),
                    QHS.CmpEq("flagactivity", 1))));//Ist.
            
            bool isAcquistoIstituzionale = nIst > 0;
            string codeClawBack = isAcquistoCommerciale ? "IVAESTERA_COMM" : "IVAESTERA_IST";

            DataRow[] RSplitPayment = DS.clawback.Select(QHC.CmpEq("clawbackref", codeClawBack));
            if (RSplitPayment.Length == 0) return;

            object codicerecupero = RSplitPayment[0]["idclawback"];
            if (codicerecupero == DBNull.Value) return;


            // Calcolo importo IVA da contabilizzare
            if (ImportoDaRecuperare == 0) {
                AzzeraRigaRecupero(Parent, codicerecupero);
                return;
            }
            GeneraRigaRecuperoSplitPayment_o_IvaEstera(Parent, codicerecupero, ImportoDaRecuperare);

        }


        decimal GetIVADettagliFattura(DataRow[] SelectedRows) {
            if (DS.invoice.Rows.Count == 0)
                return 0;

            DataRow Fattura = DS.invoice.Rows[0];
             
            decimal imposta = 0;
            DataRow[] ToConsider = new DataRow[0];
            int CurrCausaleIva = GetCausaleIva();

            if (CurrCausaleIva == 3) return 0;

            foreach (DataRow R in SelectedRows) {
                if (R.RowState == DataRowState.Deleted) continue;
                decimal R_imposta = CfgFn.GetNoNullDecimal(R["tax"]);
                imposta += CfgFn.RoundValuta(R_imposta);
            }

            return imposta;

        }

        int GetCausaleIva() {
            int CurrCausaleIva = 0;
            CurrCausaleIva = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
            return CurrCausaleIva;

        }

        void AzzeraRigaRecupero(DataRow Parent, object codice) {
            DataRow[] found =
                DS.expenseclawback.Select(QHC.AppAnd(QHC.CmpEq("idclawback", codice),
                    QHC.CmpEq("idexp", Parent["idexp"])));

            if (found.Length == 0) return;
            found[0].Delete();
        }

        //-----------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------


        void ViewAutomatismi(DataSet DS) {
            string spesa = null;
            string entrata = null;
            if (DS.Tables["expense"] != null) {
                DataTable Var = DS.Tables["expense"];
                spesa = QHS.FieldIn("idexp", Var.Select(), "idexp");
                entrata = QHS.FieldIn("idpayment", Var.Select(), "idexp");
            }

            Form F = ShowAutomatismi.Show(Meta, spesa, entrata, null, null);
            createForm(F, this);
            F.ShowDialog(this);
        }

        bool doAddConta() {
            //Crea la riga in expensemandate
            //Non solo deve associare i dettagli, ma deve anche creare la righe in expensemandate
            MetaData ExpInv = MetaData.GetMetaData(this, "expenseinvoice");
            DataRow Inv = DS.invoice.Rows[0];
            MetaData.SetDefault(DS.expenseinvoice, "idexp", idexp_selected);
            ExpInv.SetDefaults(DS.expenseinvoice);
            DataRow M = ExpInv.Get_New_Row(Inv, DS.expenseinvoice);
            M["movkind"] = cmbCausale.SelectedValue.ToString().ToUpper();
            return doAssociaSoloDettagli();
        }

        /// <summary>
        /// Riempie i dati di una riga di entata o spesa prendendoli dall'automatismo e dall'
        ///  IDmovimento in ingresso
        /// </summary>
        /// <param name="E_S"></param>
        /// <param name="Auto"></param>
        /// <param name="CurrSpesa"></param>
        void FillMovimento(DataRow E_S, decimal amount, object idman, object idreg,
            string description) {
            int esercizio = Convert.ToInt32(Meta.GetSys("esercizio"));
            DateTime DataCont = Convert.ToDateTime(Meta.GetSys("datacontabile"));
            E_S.BeginEdit();
            E_S["ymov"] = esercizio;
            E_S["adate"] = DataCont;
            //E_S["fulfilled"] = "N";
            //E_S["autotaxflag"] = "N";
            //E_S["autoclawbackflag"] = "N";
            E_S["idman"] = idman;
            E_S["idreg"] = idreg;
            E_S["description"] = description;
            //E_S["amount"] = CfgFn.RoundValuta(amount);
            E_S.EndEdit();
        }


        void FillImputazioneMovimento(DataRow ImpMov, decimal amount, object idfin, object idupb) {
            ImpMov["amount"] = amount;
            ImpMov["idfin"] = idfin;
            ImpMov["idupb"] = idupb;
        }

        bool doSaveNewExpense(object idparent) {
            int fasecred = CfgFn.GetNoNullInt32(Meta.GetSys("expenseregphase"));
            int fasebilancio = CfgFn.GetNoNullInt32(Meta.GetSys("expensefinphase"));
            int fasespesamax = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));
            int faseinizio;
            int fasefine;
            if (idparent == null) {
                faseinizio = 1;
                fasefine = fasefattura;
            }
            else {
                faseinizio = (choosenParentPhase + 1);
                fasefine = fasefattura;
            }

            MetaData Exp = MetaData.GetMetaData(this, "expense");
            MetaData ExpY = MetaData.GetMetaData(this, "expenseyear");
            MetaData ExpL = MetaData.GetMetaData(this, "expenselast");
            MetaData ExpInvoice = MetaData.GetMetaData(this, "expenseinvoice");
            MetaData InvoiceDetail = MetaData.GetMetaData(this, "invoicedetail");
            Exp.SetDefaults(DS.expense);
            ExpY.SetDefaults(DS.expenseyear);
            ExpL.SetDefaults(DS.expenselast);
            ExpInvoice.SetDefaults(DS.expenseinvoice);
            InvoiceDetail.SetDefaults(DS.invoicedetail);


            if (idparent != null)
                MetaData.SetDefault(DS.expense, "parentidexp", idparent);
            else
                MetaData.SetDefault(DS.expense, "parentidexp", DBNull.Value);

            DataRow[] SelectedRows = GetGridSelectedRows(gridDetails);
            int currcausale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
            AggiornaUPBDettagli(SelectedRows, currcausale);
            object[] upbiva = ValoriDiversi(SelectedRows, "idupb_iva");
            object[] upb = ValoriDiversi(SelectedRows, "idupb");

            if (!verificaSeUPBUniformi(upb, upbiva, currcausale)) {
                show(
                    "Attenzione! I dettagli devono avere tutti lo stesso UPB!.\n\rL'operazione sarà interrotta");
                return false;
            }

            string field_upb = "idupb";

            if (currcausale == 2) {
                if (upbiva.Length > 1 || (upbiva.Length==1 && upbiva[0] != DBNull.Value)) {
                    upb = upbiva;
                    field_upb = "idupb_iva";
                }
            }

            if (upb.Length == 2) {
                object idupb1 = upb[0];
                object idupb2 = upb[1];
                if (idupb1 != DBNull.Value && idupb2 == DBNull.Value) {
                    object[] result = new object[1];
                    result[0] = idupb1;
                    upb = result;
                }
                else if (idupb1 == DBNull.Value && idupb2 != DBNull.Value) {
                    object[] result = new object[1];
                    result[0] = idupb2;
                    upb = result;
                }
            }

            DataTable Mov = DS.expense;
            DataTable ImpMov = DS.expenseyear;
            DataTable LastMov = DS.expenselast;

            DataRow Invoice = DS.invoice.Rows[0];


            int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));

            MetaData.SetDefault(DS.expenseyear, "ayear", esercizio);
            if (idparent != null) {
                MetaData.SetDefault(DS.expense, "parentidexp", idparent);
                DataTable ExpenseYear = Conn.RUN_SELECT("expenseyear", "*", null,
                    QHS.AppAnd(QHS.CmpEq("idexp", idparent), QHS.CmpEq("ayear", esercizio)),
                    null, null, false);
                DataRow ParExpY = ExpenseYear.Rows[0];
                if (ParExpY["idfin"] != DBNull.Value) idfinSelected = ParExpY["idfin"];
                if (ParExpY["idupb"] != DBNull.Value) idUPBSelected = ParExpY["idupb"];
            }


            object idupb = upb[0];
            string filterupboriginal = "";
            string filterupbnew = "";
            string filterinvdetoriginal = "";
            if (idupb == DBNull.Value) {
                filterupboriginal = QHS.IsNull("idupb");
                filterupbnew = QHS.CmpEq("idupb", idUPBSelected);
                filterinvdetoriginal = QHS.IsNull(field_upb);
            }
            else {
                filterupboriginal = QHS.CmpEq("idupb", idupb);
                filterinvdetoriginal = QHS.CmpEq(field_upb, idupb);
            }

            object idmanagerupb = null;
            //DataRow UPB = DS.upb.Select(filterupb)[0];
            //idmanagerupb= UPB["idman"].ToString();
            if (idupb == DBNull.Value) {
                idmanagerupb = Conn.DO_READ_VALUE("upb", filterupbnew, "idman");
            }
            else {
                idmanagerupb = Conn.DO_READ_VALUE("upb", filterupboriginal, "idman");
            }
            object curridmanager = idmanagerSelected;
            if (curridmanager == null) curridmanager = idmanagerupb;

            if (((curridmanager == null) || (curridmanager == DBNull.Value)) && (idparent != DBNull.Value)) {
                object idmanParent = Meta.Conn.DO_READ_VALUE("expense",
                    QHS.CmpEq("idexp", idparent), "idman");
                if ((idmanParent != null) && (idmanParent != DBNull.Value)) {
                    curridmanager = idmanParent;
                }
            }
            object idreg = Invoice["idreg"];
            
            bool avvisoDelegatoMostrato = false;

            string filterregistry = QHS.CmpEq("idreg", idreg);

            DS.registry.Clear();
            Conn.RUN_SELECT_INTO_TABLE(DS.registry, null, filterregistry, null, true);
            string title = DS.registry.Rows[0]["title"].ToString();

            string filterdetail = filterinvdetoriginal;

            decimal amount = CalcTotCausale(FiltraRows(SelectedRows, filterdetail).ToArray(), currcausale);

            DataRow ParentR = null;
            DataRow ExpenseToLink = null;

            for (int faseCorrente = faseinizio; faseCorrente <= fasefine; faseCorrente++) {
                Mov.Columns["nphase"].DefaultValue = faseCorrente;

                DataRow NewSpesaRow = Exp.Get_New_Row(ParentR, Mov);
                if (faseCorrente == fasefattura) ExpenseToLink = NewSpesaRow;
                ParentR = NewSpesaRow;

                FillMovimento(NewSpesaRow, amount, curridmanager, idreg, Invoice["description"].ToString());


                NewSpesaRow["doc"] = Invoice["doc"];
                //"Fatt." +
                //Invoice["idinvkind"].ToString() + "/" +
                //Invoice["yinv"].ToString().Substring(2, 2) + "/" +
                //Invoice["ninv"].ToString().PadLeft(6, '0');
                NewSpesaRow["docdate"] = Invoice["docdate"];

                NewSpesaRow["nphase"] = faseCorrente;

                if (faseCorrente < fasecred) {
                    NewSpesaRow["idreg"] = DBNull.Value;
                }
                else {
                    NewSpesaRow["idreg"] = idreg;
                }


                if (faseCorrente == fasespesamax) {
                    DataRow ModPagam = CfgFn.ModalitaPagamentoDefault(Meta.Conn, NewSpesaRow["idreg"]);
                    if (ModPagam == null) {
                        show(
                            "E' necessario che sia definita almeno una modalità di pagamento per il percipiente " +
                            "\"" + title + "\"\n\n" +
                            "Dati non salvati", "Errore", MessageBoxButtons.OK);
                        return false;
                    }
                    DataRow NewLastMov = ExpL.Get_New_Row(NewSpesaRow, LastMov);
                    //aggiungere le informazioni della modalità di pagamento
                    NewLastMov["idregistrypaymethod"] = ModPagam["idregistrypaymethod"];
                    NewLastMov["idpaymethod"] = ModPagam["idpaymethod"];
                    NewLastMov["cin"] = ModPagam["cin"];
                    NewLastMov["idbank"] = ModPagam["idbank"];
                    NewLastMov["idcab"] = ModPagam["idcab"];
                    NewLastMov["cc"] = ModPagam["cc"];
                    NewLastMov["iban"] = ModPagam["iban"];
                    NewLastMov["paymentdescr"] = ModPagam["paymentdescr"];
                    NewLastMov["iddeputy"] = ModPagam["iddeputy"];
                    NewLastMov["refexternaldoc"] = ModPagam["refexternaldoc"];
                    NewLastMov["biccode"] = ModPagam["biccode"];
                    NewLastMov["extracode"] = ModPagam["extracode"];
                    NewLastMov["idchargehandling"] = ModPagam["idchargehandling"];
                    if (LeggiFlagEsenteBancaPredefinita()) {
                        int flag = CfgFn.GetNoNullInt32(NewLastMov["flag"]);
                        int flag_exemption = (CfgFn.GetNoNullInt32(NewLastMov["flag"]) & 0xF7) |
                                             ((CfgFn.GetNoNullInt32(ModPagam["flag"]) & 1) << 3);
                        NewLastMov["flag"] = flag_exemption;
                    }
                    object idpaymethod = ModPagam["idpaymethod"];
                    string filterpaymethod = QHS.CmpEq("idpaymethod", idpaymethod);

                    DataTable TPaymethod = Conn.RUN_SELECT("paymethod", "*", null, filterpaymethod, null, true);

                    if ((TPaymethod != null) && (TPaymethod.Rows.Count > 0)) {
                        object paymethod_allowdeputy = TPaymethod.Rows[0]["allowdeputy"];
                        NewLastMov["paymethod_allowdeputy"] = paymethod_allowdeputy;

                        int paymethod_flag = CfgFn.GetNoNullInt32(TPaymethod.Rows[0]["flag"]);
                        int flag = CfgFn.GetNoNullInt32(Invoice["requested_doc"]) & 255;
                        // lo spostiamo di 15 posizioni a sinistra
                        flag = flag << 15;
                        NewLastMov["paymethod_flag"] = flag | (paymethod_flag & ~0x7F8000);
                    }
                    if (NewLastMov["iddeputy"] != DBNull.Value && !avvisoDelegatoMostrato) {
                        avvisoDelegatoMostrato = true;
                        string titleDelegato = Conn.readValue("registry", q.eq("idreg", NewLastMov["iddeputy"]), "title")?.ToString()??"";
                        show(
                            "Attenzione, l'anagrafica considerata è associata ad un delegato come modalità di pagamento. Il pagamento sarà pertanto effettuato al delegato "
                            +titleDelegato+" sull'iban "+NewLastMov["iban"].ToString(),
                            "Avviso");
                    }


                    // aggiunge le informazioni sul numero bolletta se sono state digitate dall'utente
                    int nBill = CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int),
                        txtBolletta.Text.ToString(), "x"));
                    if (nBill > 0) {
                        NewLastMov["nbill"] = nBill;
                        int flag = CfgFn.GetNoNullInt32(NewLastMov["flag"]);
                        flag = flag | 1;
                        NewLastMov["flag"] = flag;
                    }

                    if (chkAutomRecuperi.Checked) {

                        int flag = CfgFn.GetNoNullInt32(NewLastMov["flag"]);
                        flag = flag | 4;
                        NewLastMov["flag"] = flag;

                    }

                    EP_functions EP = new EP_functions(Meta.Dispatcher);

                    object idaccmotive = DBNull.Value;
                    object idacc = DBNull.Value;

                    idaccmotive = Invoice["idaccmotivedebit_crg"];
                    if (idaccmotive == DBNull.Value) idaccmotive = Invoice["idaccmotivedebit"];

                    if (EP.attivo) {
                        idacc = EP.GetSupplierAccountForRegistry(idaccmotive, NewSpesaRow["idreg"]);
                    }
                    if (idacc != DBNull.Value) {
                        if (DS.account.Select(QHC.CmpEq("idacc", idacc)).Length == 0) {
                            DS.account.Clear();
                            Meta.Conn.RUN_SELECT_INTO_TABLE(DS.account, null, QHS.CmpEq("idacc", idacc), null, false);
                            if (DS.account.Rows.Count > 0) {
                                DataRow Acc = DS.account.Rows[0];
                            }
                        }
                        NewLastMov["idaccdebit"] = idacc;
                    }


                }

                DataRow NewImpMov = ImpMov.NewRow();

                if (idupb != DBNull.Value) {
                    FillImputazioneMovimento(NewImpMov, amount, idfinSelected, idupb);
                }
                else {
                    FillImputazioneMovimento(NewImpMov, amount, idfinSelected, idUPBSelected);
                }
                //NewImpMov["nphase"] = faseCorrente;
                NewImpMov["idexp"] = NewSpesaRow["idexp"];
                NewImpMov["ayear"] = esercizio;

                if (faseCorrente < fasebilancio) {
                    NewImpMov["idfin"] = DBNull.Value;
                    NewImpMov["idupb"] = DBNull.Value;
                }
                ImpMov.Rows.Add(NewImpMov);
            }

            //Aggiunge la riga in expenseinvoice
            DataRow ExpInvRow = ExpInvoice.Get_New_Row(ExpenseToLink, DS.expenseinvoice);
            ExpInvRow["movkind"] = currcausale;
            ExpInvRow["idinvkind"] = Invoice["idinvkind"];
            ExpInvRow["yinv"] = Invoice["yinv"];
            ExpInvRow["ninv"] = Invoice["ninv"];

            //Effettua i collegamenti con i dettagli
            string listRownum = "(";
            foreach (int rownum in DetailsToUpdate) {
                listRownum += rownum.ToString() + ",";
            }
            listRownum = listRownum.Substring(0, listRownum.Length - 1) + ")";
            string filterToUpdate = null;
            if (listRownum != "") filterToUpdate = "(rownum in " + listRownum + ")";
            DataRow[] RowsToUpdate = DS.invoicedetail.Select(filterToUpdate);
            var Details = FiltraRows(RowsToUpdate, filterdetail);

            foreach (DataRow RD in Details) {
                switch (currcausale) {
                    case 1:
                        RD["idexp_taxable"] = ExpenseToLink["idexp"];
                        RD["idexp_iva"] = ExpenseToLink["idexp"];
                        break;
                    case 3:
                        RD["idexp_taxable"] = ExpenseToLink["idexp"];
                        break;
                    case 2:
                        RD["idexp_iva"] = ExpenseToLink["idexp"];
                        break;
                }
            }

            decimal ImportoDaRecuperare = GetIVADettagliFattura(Details.ToArray());
            GeneraOAzzeraRecuperoSplitPayment(ExpenseToLink, ImportoDaRecuperare);
            GeneraOAzzeraRecuperoIvaEstera(ExpenseToLink, ImportoDaRecuperare);

            // Associa l'UPB ai dettagli sui quali non era stato impostato
            /*DataRow[] DetailsUPBNull = FiltraRows(Details, "(idupb is null)");
           foreach (DataRow RD1 in DetailsUPBNull) {
               RD1["idupb"] = idUPBSelected;
           }*/

            //Effettua il post

            return doSave();
        }

        private bool LeggiFlagEsenteBancaPredefinita() {
            DataTable tTreasurer = Meta.Conn.RUN_SELECT("treasurer", "*", null,
                QHS.AppAnd(QHS.CmpEq("flagdefault", "S"), QHS.BitSet("flag", 1)), null, false);
            if (tTreasurer.Rows.Count == 0) return false;
            else
                return true;
        }

        void DisplayMessages() {
        }

        private void cmbTipoFattura_SelectedIndexChanged(object sender, System.EventArgs e) {
            if (Meta == null) return;
            if (!Meta.DrawStateIsDone) return;
            ClearFattura();
            return;

        }

        void AggiornaUPBDettagli(DataRow[] SelectedRows, int causale) {
            object[] upb = ValoriDiversi(SelectedRows, "idupb");
            object[] upb_iva = ValoriDiversi(SelectedRows, "idupb_iva");
            string field = "idupb";
            if (causale == 2) {
                if (upb_iva.Length > 1 || upb_iva[0] != DBNull.Value) {
                    upb = upb_iva;
                    field = "idupb_iva";
                }
            }

            string filterupbnull = QHC.IsNull(field);
            if ((FiltraRows(SelectedRows, filterupbnull).Count > 0) && (upb.Length == 2)) {
                object idupbtoassign = "";
                var Details = FiltraRows(SelectedRows, QHC.IsNotNull(field));
                if (Details.Count > 0) idupbtoassign = Details[0][field];
                foreach (DataRow Curr in FiltraRows(SelectedRows, filterupbnull)) {
                    Curr[field] = idupbtoassign;
                }
            }
        }

        void AggiornaTotSelezione(object sender) {
            TextBox T = (TextBox) sender;
            if (!T.Modified) return;
            decimal valore = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal),
                T.Text, "x.y.c"));
            if (valore < 0) {
                show("Valore non valido");
                T.Focus();
                return;
            }
            decimal importoimponibile = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal),
                txtTotImponibile.Text, "x.y.c"));
            decimal importoiva = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal),
                txtTotIva.Text, "x.y.c"));
            T.Text = valore.ToString("c");
            txtTotGenerale.Text = (importoimponibile + importoiva).ToString("c");
        }

        void RecalcOperationsToDo() {
           
            decimal ImportoMax = CfgFn.GetNoNullDecimal(
                HelpForm.GetObjectFromString(typeof(decimal),
                    txtTotSelezionato.Text, "x.y.c"));

            decimal ImportoDaPagare = CfgFn.GetNoNullDecimal(
                HelpForm.GetObjectFromString(typeof(decimal),
                    txtDaPagare.Text, "x.y.c"));
            if (ImportoDaPagare == 0) {
                ImportoDaPagare = ImportoMax;
            }
            txtDaPagare.Text = ImportoDaPagare.ToString("c");
            //decimal PercentualeDigitata = CfgFn.GetNoNullDecimal(
            //    HelpForm.GetObjectFromString(typeof(decimal),
            //        txtPerc.Text, "x.y.c"));

            if (ImportoDaPagare > ImportoMax) {
                show("L'importo da pagare è superiore al totale dei dettagli selezionati");
                txtDaPagare.Text = "";                
                return;
            }
            decimal percentuale = 100;
            if (ImportoMax != 0) percentuale = ImportoDaPagare/ImportoMax*100;
            decimal rounded = Math.Round(percentuale, 4);
            // calcola la percentuale in base all'importo
            txtPerc.Text = HelpForm.StringValue(rounded, "x.y.fixed.4...1");
            //string operazioni = "";
            //operazioni = QueryCreator.GetPrintable(operazioni);

        }

        decimal CalcolaCoefficiente(decimal importoDaPagare, decimal importoMax, DataRow rowToSplit) {
            decimal epsilon = 0;
            if ((importoDaPagare != 0) && (importoMax != 0)) epsilon = importoDaPagare/importoMax;
            if (epsilon >= 1) return epsilon;

            int maxIter = 100;
            int niter = 1;
            decimal epsilon_min = epsilon - 0.01M;
            decimal epsilon_max = epsilon + 0.01M;
            decimal epsilon_med = (epsilon_min + epsilon_max)/2;
            decimal importoRicalcolato = RicalcolaTotaleDaContabilizzare(epsilon_med, rowToSplit);
            while (niter < maxIter && importoRicalcolato != importoDaPagare) {
                if (importoDaPagare - importoRicalcolato > 0) {
                    epsilon_min = epsilon_med;
                }
                else {
                    epsilon_max = epsilon_med;
                }
                epsilon_med = (epsilon_min + epsilon_max)/2;
                importoRicalcolato = RicalcolaTotaleDaContabilizzare(epsilon_med, rowToSplit);
                if (importoRicalcolato != importoDaPagare) {
                    decimal totale_min = RicalcolaTotaleDaContabilizzare(epsilon_min, rowToSplit);
                    decimal totale_max = RicalcolaTotaleDaContabilizzare(epsilon_max, rowToSplit);
                    if (totale_min == totale_max) {
                        epsilon = epsilon_med;
                        niter = 100;
                    }
                }
                niter += 1;
            }
            return epsilon_med;
        }

        decimal GetImponibileNear(decimal imponibiletest, decimal taxable, decimal number, decimal discount,
            decimal exchangerate) {
            decimal TotaleImponibile = CfgFn.RoundValuta(taxable*number*(1 - discount)*exchangerate);
            decimal imponibilecomplementare = taxable - imponibiletest;
            decimal totale1 = CfgFn.RoundValuta(imponibiletest*number*(1 - discount)*exchangerate);
            decimal totale2 = CfgFn.RoundValuta(imponibilecomplementare*number*(1 - discount)*exchangerate);
            if (totale1 + totale2 == TotaleImponibile) return imponibiletest;
            decimal x = number*(1 - discount)*exchangerate;
            decimal passo = 0;
            if (x <= 10) passo = 0.001M;
            if ((x > 10) && (x <= 100)) passo = 0.0001M;
            if ((x > 100) && (x <= 1000)) passo = 0.00001M;
            if (x > 1000) passo = 0.00001M;
            decimal cent = passo;
            while (cent <= 0.1M) {
                decimal imponibile_try = imponibiletest + cent;
                decimal imponibilecomplementare_try = taxable - imponibile_try;
                totale1 = CfgFn.RoundValuta(imponibile_try*number*(1 - discount)*exchangerate);
                totale2 = CfgFn.RoundValuta(imponibilecomplementare_try*number*(1 - discount)*exchangerate);
                if (totale1 + totale2 == TotaleImponibile) {
                    return imponibile_try;
                }
                imponibile_try = imponibiletest - cent;
                imponibilecomplementare_try = taxable - imponibile_try;
                totale1 = CfgFn.RoundValuta(imponibile_try*number*(1 - discount)*exchangerate);
                totale2 = CfgFn.RoundValuta(imponibilecomplementare_try*number*(1 - discount)*exchangerate);
                if (totale1 + totale2 == TotaleImponibile) {
                    return imponibile_try;
                }
                cent += passo;
            }
            return imponibiletest;
        }

        DataTable AggiungiOSottraiCentADettagli(decimal proporzione, decimal importoDaPagare, decimal cents) {
            DataRow[] Selected = GetGridSelectedRows(gridDetails);
            DataTable Info = new DataTable();

            Info.Columns.Add("rownum", typeof(int));
            Info.Columns.Add("difference", typeof(decimal));
            Info.Columns.Add("cents", typeof(decimal)); // Centesimi da sommare/sottrarre all'iva totale
            bool success = false;

            foreach (DataRow Row1 in Selected) {
                DataRow[] IvaKind1 = DS.ivakind.Select(QHC.CmpEq("idivakind", Row1["idivakind"]));
                if (IvaKind1.Length == 0) {
                    show(this,
                        "Attenzione nell'anagrafica dei tipi IVA è assente il tipo IVA selezionato nel dettaglio",
                        "Errore");
                    return null;
                }
                decimal imponibile1 = CfgFn.GetNoNullDecimal(Row1["taxable"]);
                decimal quantitaConfezioni1 = CfgFn.GetNoNullDecimal(Row1["npackage"]);
                decimal aliquota1 = CfgFn.GetNoNullDecimal(IvaKind1[0]["rate"]);
                decimal sconto1 = CfgFn.GetNoNullDecimal(Row1["discount"]);
                DataRow Invoice1 = DS.invoice.Rows[0];
                decimal tassocambio1 = CfgFn.GetNoNullDecimal(Invoice1["exchangerate"]);
                decimal taxable = CfgFn.Round(CfgFn.GetNoNullDecimal(Row1["taxable"]), 5);
                decimal taxabletotal = CfgFn.RoundValuta((taxable*quantitaConfezioni1*(1 - sconto1)*tassocambio1));
                // Ricalcolo l'imponibile unitario
                decimal taxable1 = CfgFn.Round(CfgFn.GetNoNullDecimal(Row1["taxable"])*proporzione, 5);
                decimal taxable_recalc = GetImponibileNear(taxable1, imponibile1, quantitaConfezioni1, sconto1,
                    tassocambio1);
                // Ricalcolo l'iva
                decimal taxtotal = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Row1["tax"]));
                decimal tax_recalctotal = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Row1["tax"])*proporzione);
                decimal taxable_recalctotal =
                    CfgFn.RoundValuta((taxable_recalc*quantitaConfezioni1*(1 - sconto1)*tassocambio1));
                DataRow rInfo = Info.NewRow();
                decimal difference;
                if ((taxable_recalctotal != 0) && (taxabletotal != 0)) {
                    difference = tax_recalctotal/taxable_recalctotal - taxtotal/taxabletotal;
                }
                else {
                    difference = -1000;
                }
                rInfo["rownum"] = Row1["rownum"];
                rInfo["difference"] = difference;
                rInfo["cents"] = 0;
                Info.Rows.Add(rInfo);
            }
            DataRow[] Details;
            bool aggiungi;
            if (cents < 0) {
                aggiungi = true;
                cents = -cents;
            }
            else aggiungi = false;

            decimal cent = 0.01M;
            if (cmbCausale.SelectedValue == null) return null;
            int causale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
            if (causale == 3) return null;
            while (cent <= cents) {
                decimal totiva = 0;
                decimal totimpo = 0;
                decimal total = 0;
                DataRow Det;
                // Ordino in base a difference in ordine decrescente o crescente
                if (aggiungi) {
                    Details = Info.Select(null, "difference ASC");
                }
                else {
                    Details = Info.Select(null, "difference DESC");
                }
                Det = Details[0];
                foreach (DataRow Row in Selected) {
                    DataRow[] IvaKind = DS.ivakind.Select(QHC.CmpEq("idivakind", Row["idivakind"]));
                    if (IvaKind.Length == 0) {
                        show(this,
                            "Attenzione nell'anagrafica dei tipi IVA è assente il tipo IVA selezionato nel dettaglio",
                            "Errore");
                        return null;
                    }
                    string filterrow = QHC.CmpEq("rownum", Row["rownum"]);
                    DataRow RowAdjust = Info.Select(filterrow, null)[0];
                    decimal imponibile = CfgFn.GetNoNullDecimal(Row["taxable"]);
                    decimal iva = CfgFn.GetNoNullDecimal(Row["tax"]);
                    decimal quantitaConfezioni = CfgFn.GetNoNullDecimal(Row["npackage"]);
                    decimal aliquota = CfgFn.GetNoNullDecimal(IvaKind[0]["rate"]);
                    decimal sconto = CfgFn.GetNoNullDecimal(Row["discount"]);
                    DataRow Invoice = DS.invoice.Rows[0];
                    decimal tassocambio = CfgFn.GetNoNullDecimal(Invoice["exchangerate"]);
                    decimal taxable = CfgFn.Round(CfgFn.GetNoNullDecimal(Row["taxable"]), 5);
                    // Ricalcolo l'imponibile unitario
                    decimal taxable_recalc = CfgFn.Round(CfgFn.GetNoNullDecimal(Row["taxable"])*proporzione, 5);
                    taxable_recalc = GetImponibileNear(taxable_recalc, imponibile, quantitaConfezioni, sconto,
                        tassocambio);
                    // Uso l'imponibile unitario per  calcolare l'iva totale e l'iva indetraibile
                    decimal taxabletotal = CfgFn.RoundValuta((taxable*quantitaConfezioni*(1 - sconto)*tassocambio));
                    decimal taxtotal = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Row["tax"]));
                    decimal tax_recalc = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Row["tax"])*proporzione);
                    decimal taxabletot_recalc =
                        CfgFn.RoundValuta((taxable_recalc*quantitaConfezioni*(1 - sconto)*tassocambio));
                    // aggiungi o sottrai centesimi all'iva del dettaglio
                    if (Det["rownum"].Equals(Row["rownum"])) {
                        if (aggiungi) {
                            tax_recalc = tax_recalc + CfgFn.GetNoNullDecimal(Det["cents"]) + 0.01M;
                            Det["cents"] = CfgFn.GetNoNullDecimal(Det["cents"]) + 0.01M;
                        }
                        if (!aggiungi) {
                            tax_recalc = tax_recalc + (CfgFn.GetNoNullDecimal(Det["cents"])) - 0.01M;
                            Det["cents"] = CfgFn.GetNoNullDecimal(Det["cents"]) - 0.01M;
                        }
                        decimal difference;
                        if ((taxable_recalc != 0) && (taxable != 0)) {
                            difference = tax_recalc/taxabletot_recalc - taxtotal/taxabletotal;
                        }
                        else {
                            difference = -1000;
                        }
                        Det["difference"] = difference;
                    }
                    else {
                        decimal aggiustamento = CfgFn.GetNoNullDecimal(RowAdjust["cents"]);
                        tax_recalc += aggiustamento;
                    }
                    //decimal unabatable = CfgFn.RoundValuta(tax * percindeduc);

                    if (causale == 3) {
                        totimpo += taxabletot_recalc;
                    }
                    if (causale == 2) {
                        totiva += tax_recalc;
                    }
                    if (causale == 1) {
                        totimpo += taxabletot_recalc;
                        totiva += tax_recalc;
                    }
                    total = totimpo + totiva;
                }
                decimal TotaleDaContabilizzare = 0;
                if (causale == 3) {
                    TotaleDaContabilizzare = CfgFn.GetNoNullDecimal(totimpo);
                }
                if (causale == 2) {
                    TotaleDaContabilizzare = CfgFn.GetNoNullDecimal(totiva);
                }
                if (causale == 1) {
                    TotaleDaContabilizzare = CfgFn.GetNoNullDecimal(total);
                }

                if (TotaleDaContabilizzare == importoDaPagare) {
                    cent = cents;
                    success = true;
                    break;
                }
                if (TotaleDaContabilizzare < importoDaPagare) aggiungi = true;
                if (TotaleDaContabilizzare > importoDaPagare) aggiungi = false;
                cent += 0.01M;
            }

            if (success) return Info;
            else return null;
        }

        decimal RicalcolaTotaleDaContabilizzare(decimal proporzione, DataRow rowToSplit) {
            if (cmbCausale.SelectedValue == null) return 0;
            int causale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
            decimal totiva = 0;
            decimal totimpo = 0;
            decimal total = 0;
            DataRow Invoice = DS.invoice.Rows[0];
            decimal tassocambio = CfgFn.GetNoNullDecimal(Invoice["exchangerate"]);
            if (rowToSplit == null) {
                DataRow[] Selected = GetGridSelectedRows(gridDetails);

                foreach (DataRow Row in Selected) {
                    DataRow[] IvaKind = DS.ivakind.Select(QHC.CmpEq("idivakind", Row["idivakind"]));
                    if (IvaKind.Length == 0) {
                        show(this,
                            "Attenzione nell'anagrafica dei tipi IVA è assente il tipo IVA selezionato nel dettaglio",
                            "Errore");
                        return 0;
                    }
                    decimal imponibile = CfgFn.GetNoNullDecimal(Row["taxable"]);
                    decimal iva = CfgFn.GetNoNullDecimal(Row["tax"]);
                    decimal quantitaConfezioni = CfgFn.GetNoNullDecimal(Row["npackage"]);
                    decimal aliquota = CfgFn.GetNoNullDecimal(IvaKind[0]["rate"]);
                    decimal sconto = CfgFn.GetNoNullDecimal(Row["discount"]);
                    // Ricalcolo l'imponibile unitario
                    decimal taxable = CfgFn.Round(CfgFn.GetNoNullDecimal(Row["taxable"])*proporzione, 5);
                    taxable = GetImponibileNear(taxable, imponibile, quantitaConfezioni, sconto, tassocambio);
                    // Uso l'imponibile unitario per  calcolare l'iva totale e l'iva indetraibile
                    decimal taxabletot = CfgFn.RoundValuta((taxable*quantitaConfezioni*(1 - sconto)*tassocambio));
                    decimal tax = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Row["tax"])*proporzione);

                    if (causale == 3) {
                        totimpo += taxabletot;
                    }
                    if (causale == 2) {
                        totiva += tax;
                    }
                    if (causale == 1) {
                        totimpo += taxabletot;
                        totiva += tax;
                    }
                    total = totimpo + totiva;
                }
                if (causale == 3) {
                    TotaleDaContabilizzare = CfgFn.GetNoNullDecimal(totimpo);
                }
                if (causale == 2) {
                    TotaleDaContabilizzare = CfgFn.GetNoNullDecimal(totiva);
                }
                if (causale == 1) {
                    TotaleDaContabilizzare = CfgFn.GetNoNullDecimal(total);
                }
                return TotaleDaContabilizzare;
            }
            else {
                DataRow[] IvaKindSplit = DS.ivakind.Select(QHC.CmpEq("idivakind", rowToSplit["idivakind"]));
                if (IvaKindSplit.Length == 0) {
                    show(this,
                        "Attenzione nell'anagrafica dei tipi IVA è assente il tipo IVA selezionato nel dettaglio",
                        "Errore");
                    return 0;
                }
                decimal imponibile = CfgFn.GetNoNullDecimal(rowToSplit["taxable"]);
                decimal iva = CfgFn.GetNoNullDecimal(rowToSplit["tax"]);
                decimal quantitaConfezioni = CfgFn.GetNoNullDecimal(rowToSplit["npackage"]);
                decimal aliquota = CfgFn.GetNoNullDecimal(IvaKindSplit[0]["rate"]);
                decimal sconto = CfgFn.GetNoNullDecimal(rowToSplit["discount"]);

                // Ricalcolo l'imponibile unitario
                decimal taxable = CfgFn.Round(CfgFn.GetNoNullDecimal(rowToSplit["taxable"])*proporzione, 5);
                taxable = GetImponibileNear(taxable, imponibile, quantitaConfezioni, sconto, tassocambio);
                // Uso l'imponibile unitario per  calcolare l'iva totale e l'iva indetraibile
                decimal taxabletot = CfgFn.RoundValuta((taxable*quantitaConfezioni*(1 - sconto)*tassocambio));
                decimal tax = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(rowToSplit["tax"])*proporzione);
                decimal importoRicalcolato = 0;
                if (causale == 3) {
                    importoRicalcolato = CfgFn.GetNoNullDecimal(taxabletot);
                }
                if (causale == 2) {
                    importoRicalcolato = CfgFn.GetNoNullDecimal(tax);
                }
                if (causale == 1) {
                    importoRicalcolato = CfgFn.GetNoNullDecimal(taxabletot + tax);
                }
                return importoRicalcolato;

            }

        }

        private bool checkPercentuale(object sender) {
            TextBox T = (TextBox) sender;
            bool OK = false;
            if (T.Text == "") return false;
            decimal percentmax = 100;
            string errmsg = "Il valore percentuale dovrebbe essere un numero compreso \r" +
                            "tra 0 e " + percentmax.ToString("n");
            try {
                decimal percent = Decimal.Parse(T.Text,
                    NumberStyles.Number,
                    NumberFormatInfo.CurrentInfo);
                if ((percent < 0) || (percent > percentmax)) {
                    show(errmsg, "Avviso");
                    T.Focus();
                    OK = false;
                }
                else {
                    OK = true;
                }
            }
            catch {
                show("E' necessario digitare un numero", "Avviso", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Exclamation);
                return false;
            }
            return OK;
        }

        private void txtPerc_Leave(object sender, System.EventArgs e) {
            if (inChiusura) return;
            if (checkPercentuale(sender)) {
                decimal ImportoMax = CfgFn.GetNoNullDecimal(
                    HelpForm.GetObjectFromString(typeof(decimal),
                        txtTotSelezionato.Text, "x.y.c"));
                // calcola l'importo in base alla percentuale
                decimal perc =
                    CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal), txtPerc.Text, "x.y.c"));
                decimal importoDaPagare = CfgFn.Round(ImportoMax*perc/100, 2);
                //RicalcolaTotaleDaContabilizzare(perc/100);
                txtDaPagare.Text = importoDaPagare.ToString("c");
                txtPerc.Text = HelpForm.StringValue(perc, "x.y.fixed.4...1");

                txtDaPagare_Leave(txtDaPagare, null);
            }
        }

        void InsertNewDetail(DataRow Row, decimal taxable, decimal tax, decimal percindeduc) {
            // Creo una nuova riga con gli importi residui (vedere gli arrotondamenti)
            decimal taxableResiduo = CfgFn.GetNoNullDecimal(Row["taxable"]) - taxable;
            decimal taxResiduo = CfgFn.GetNoNullDecimal(Row["tax"]) - tax;
            decimal unabatableResiduo = CfgFn.RoundValuta(taxResiduo*percindeduc);
            MetaData metaDT = MetaData.GetMetaData(this, "invoicedetail");
            metaDT.SetDefaults(DS.invoicedetail);
            // Creazione di un nuovo dettaglio
            DataRow rDT = metaDT.Get_New_Row(DS.invoice.Rows[0], DS.invoicedetail);
            rDT["idgroup"] = Row["idgroup"];
            rDT["idivakind"] = Row["idivakind"];
            rDT["taxable"] = taxableResiduo;
            rDT["tax"] = taxResiduo;
            rDT["unabatable"] = unabatableResiduo;
            rDT["idupb"] = Row["idupb"];
            rDT["number"] = CfgFn.GetNoNullDecimal(Row["number"]);
            rDT["npackage"] = CfgFn.GetNoNullDecimal(Row["npackage"]);
            rDT["idlist"] = Row["idlist"];
            rDT["idunit"] = Row["idunit"];
            rDT["idpackage"] = Row["idpackage"];
            rDT["unitsforpackage"] = Row["unitsforpackage"];
            rDT["detaildescription"] = Row["detaildescription"].ToString();
            rDT["competencystart"] = Row["competencystart"];
            rDT["competencystop"] = Row["competencystop"];
            rDT["annotations"] = Row["annotations"];
            rDT["discount"] = Row["discount"];
            rDT["idmankind"] = Row["idmankind"];
            rDT["manrownum"] = Row["manrownum"];
            rDT["nman"] = Row["nman"];
            rDT["yman"] = Row["yman"];
            rDT["idexp_taxable"] = Row["idexp_taxable"]; // contabilizzaione imponibile già effettuata
            rDT["idexp_iva"] = Row["idexp_iva"]; // contabilizzaione iva già effettuata
            rDT["idaccmotive"] = Row["idaccmotive"];
            rDT["idsor1"] = Row["idsor1"];
            rDT["idsor2"] = Row["idsor2"];
            rDT["idsor3"] = Row["idsor3"];
            rDT["idcostpartition"] = Row["idcostpartition"];
            rDT["idpccdebitstatus"] = Row["idpccdebitstatus"];
            rDT["idpccdebitmotive"] = Row["idpccdebitmotive"];


            rDT["idintrastatcode"] = Row["idintrastatcode"];
            rDT["idintrastatmeasure"] = Row["idintrastatmeasure"];
            rDT["weight"] = Row["weight"];
            rDT["va3type"] = Row["va3type"];
            rDT["flag"] = Row["flag"];
            rDT["intrastatoperationkind"] = Row["intrastatoperationkind"];
            rDT["intra12operationkind"] = Row["intra12operationkind"];
            rDT["exception12"] = Row["exception12"];
            rDT["move12"] = Row["move12"];
            rDT["idupb_iva"] = Row["idupb_iva"];
            rDT["idintrastatservice"] = Row["idintrastatservice"];
            rDT["idintrastatsupplymethod"] = Row["idintrastatsupplymethod"];
            rDT["expensekind"] = Row["expensekind"];
            rDT["rounding"] = Row["rounding"];
            rDT["idepexp"] = Row["idepexp"];
            rDT["idepacc"] = Row["idepacc"];
            rDT["idsor_siope"] = Row["idsor_siope"];



            Conn.RUN_SELECT_INTO_TABLE(DS.invoicedetaildeferred, null,
                QHS.MCmp(Row, "idinvkind", "yinv", "ninv", "rownum"), null, false);
            DataRow[] def = DS.invoicedetaildeferred.Select(QHC.MCmp(Row, "idinvkind", "yinv", "ninv", "rownum"));
            foreach (DataRow rDef in def) {
                DataRow newDef = DS.invoicedetaildeferred.NewRow();
                foreach (DataColumn c in DS.invoicedetaildeferred.Columns) {
                    newDef[c] = rDef[c];
                }
                newDef["rownum"] = rDT["rownum"];
                newDef["ivatotalpayed"] = rDT["tax"];
                newDef["taxable"] = rDT["taxable"];

                rDef["ivatotalpayed"] = tax;
                rDef["taxable"] = taxable;

                DS.invoicedetaildeferred.Rows.Add(newDef);
            }



        }

        void RecalcDettagliSelezionati() {
            DataRow[] Selected = GetGridSelectedRows(gridDetails);
            int causale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
            decimal ImportoMax = CfgFn.GetNoNullDecimal(
                HelpForm.GetObjectFromString(typeof(decimal),
                    txtTotSelezionato.Text, "x.y.c"));
            decimal ImportoDaPagare = CfgFn.GetNoNullDecimal(
                HelpForm.GetObjectFromString(typeof(decimal),
                    txtDaPagare.Text, "x.y.c"));
            if (ImportoDaPagare == 0) {
                ImportoDaPagare = ImportoMax;
            }
            DataRow Mandate = DS.invoice.Rows[0];
            decimal tassocambio = CfgFn.GetNoNullDecimal(Mandate["exchangerate"]);
            ClearOperationsToDo();
            // Rilegge i dettagli con l'importo originale nel dataset
            foreach (DataRow Det in Selected) {
                string filterinvoicedetail = QueryCreator.WHERE_COLNAME_CLAUSE(
                    Det, new string[] {"idinvkind", "yinv", "ninv", "rownum"}, DataRowVersion.Default, true);
                DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.Tables["invoicedetail"], null, filterinvoicedetail, null,
                    false);
                Conn.DeleteAllUnselectable(DS.Tables["invoicedetail"]);
            }

            if (ImportoMax == 0) return;

            if (ImportoDaPagare < ImportoMax) {
                if (rdbSplittaTutti.Checked) {
                    // Distribuisce la quota parziale da contabilizzare su tutti i dettagli
                    DataTable T = null;
                    decimal epsilon = CalcolaCoefficiente(ImportoDaPagare, ImportoMax, null);
                    if (RicalcolaTotaleDaContabilizzare(epsilon, null) != ImportoDaPagare) {
                        decimal cents = (RicalcolaTotaleDaContabilizzare(epsilon, null) - ImportoDaPagare);
                        T = AggiungiOSottraiCentADettagli(epsilon, ImportoDaPagare, cents);
                    }
                    foreach (DataRow Row in DS.invoicedetail.Select()) {
                        // Solo le righe selezionate
                        if (!DetailsToUpdate.Contains(Row["rownum"])) {
                            DetailsToUpdate.Add(Row["rownum"]);
                        }
                        DataRow[] IvaKind = DS.ivakind.Select(QHC.CmpEq("idivakind", Row["idivakind"]));
                        if (IvaKind.Length == 0) {
                            show(this, "Non esiste la riga nell'anagrafica dei tipi IVA", "Errore");
                            return;
                        }
                        decimal imponibile = CfgFn.GetNoNullDecimal(Row["taxable"]);
                        decimal iva = CfgFn.GetNoNullDecimal(Row["tax"]);
                        decimal quantitaConfezioni = CfgFn.GetNoNullDecimal(Row["npackage"]);
                        decimal aliquota = CfgFn.GetNoNullDecimal(IvaKind[0]["rate"]);
                        decimal sconto = CfgFn.GetNoNullDecimal(Row["discount"]);
                        // Ricalcolo l'imponibile unitario
                        decimal taxable = CfgFn.Round(CfgFn.GetNoNullDecimal(Row["taxable"])*epsilon, 5);
                        taxable = GetImponibileNear(taxable, imponibile, quantitaConfezioni, sconto, tassocambio);
                        // Uso l'imponibile unitario per  calcolare l'iva totale
                        decimal tax = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Row["tax"])*epsilon);
                        decimal unabatabilitypercentage = CfgFn.GetNoNullDecimal(IvaKind[0]["unabatabilitypercentage"]);
                        decimal unabatable = CfgFn.RoundValuta(tax*unabatabilitypercentage);
                        string filterdetail = QHC.CmpEq("rownum", Row["rownum"]);
                        if (T != null) {
                            DataRow[] Det = T.Select(filterdetail);
                            if (Det.Length != 0) {
                                decimal cents = CfgFn.GetNoNullDecimal(Det[0]["cents"]);
                                tax += cents;
                            }
                        }
                        InsertNewDetail(Row, taxable, tax, unabatabilitypercentage);
                        //Aggiorno la riga originale con i valori ricalcolati
                        Row["taxable"] = taxable;
                        Row["tax"] = tax;
                        Row["unabatable"] = unabatable;
                    }
                }
                else {
                    //La quota parziale da contabilizzare viene raggiunta sommando i dettagli, e splittando l'ultimo
                    DataTable Info = new DataTable();
                    Info.Columns.Add("rownum", typeof(int));
                    Info.Columns.Add("total", typeof(decimal));
                    // Ciclo per riempire il datatable Info con il totale da contabilizzare su ogni dettaglio

                    // Solo le righe selezionate ordinate per importo crescente
                    foreach (DataRow Row in DS.invoicedetail.Select(null, "rownum")) {
                        // Calcolo il totale sulla causale per quel dettaglio
                        DataRow rInfo = Info.NewRow();
                        rInfo["rownum"] = Row["rownum"];
                        rInfo["total"] = CalcolaTotCausale(Row, causale);
                        Info.Rows.Add(rInfo);

                    }
                    decimal sum = ImportoDaPagare;
                    decimal oldsum = 0;
                    string filterrow = null;
                    // Ciclo per calcolare la somma da contabilizzare
                    foreach (DataRow Row in Info.Select(null, "total asc")) {
                        // Solo le righe selezionate ordinate per importo crescente 

                        if (!DetailsToUpdate.Contains(Row["rownum"])) {
                            DetailsToUpdate.Add(Row["rownum"]);
                        }
                        oldsum = sum;
                        sum -= CfgFn.GetNoNullDecimal(Row["total"]);

                        if (sum == 0) {
                            break;
                        }

                        if (sum > 0) {
                            continue;
                        }
                        else {
                            filterrow = QHC.CmpEq("rownum", Row["rownum"]);
                            DataRow R = DS.invoicedetail.Select(filterrow, null)[0];
                            DataRow[] IvaKind1 = DS.ivakind.Select(QHC.CmpEq("idivakind", R["idivakind"]));
                            if (IvaKind1.Length == 0) {
                                show(this, "Non esiste la riga nell'anagrafica dei tipi IVA", "Errore");
                                return;
                            }
                            decimal imponibile = CfgFn.GetNoNullDecimal(R["taxable"]);
                            decimal iva = CfgFn.GetNoNullDecimal(R["tax"]);
                            decimal quantitaConfezioni = CfgFn.GetNoNullDecimal(R["npackage"]);
                            decimal aliquota = CfgFn.GetNoNullDecimal(IvaKind1[0]["rate"]);
                            decimal sconto = CfgFn.GetNoNullDecimal(R["discount"]);
                            // Splitto il dettaglio corrente in due, uno risulterà contabilizzato,l'altro no

                            decimal epsilon1 = CalcolaCoefficiente(oldsum, CfgFn.GetNoNullDecimal(Row["total"]), R);
                            // Ricalcolo l'imponibile unitario
                            decimal taxable = CfgFn.Round(CfgFn.GetNoNullDecimal(R["taxable"])*epsilon1, 5);
                            taxable = GetImponibileNear(taxable, imponibile, quantitaConfezioni, sconto, tassocambio);
                            // Uso l'imponibile unitario per  calcolare l'iva totale
                            decimal tax = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(R["tax"])*epsilon1);
                            decimal unabatabilitypercentage =
                                CfgFn.GetNoNullDecimal(IvaKind1[0]["unabatabilitypercentage"]);
                            decimal unabatable = CfgFn.RoundValuta(tax*unabatabilitypercentage);
                            // Creo una nuova riga con gli importi residui (vedere gli arrotondamenti)
                            InsertNewDetail(R, taxable, tax, unabatabilitypercentage);
                            //Aggiorno la riga originale con i valori ricalcolati
                            R["taxable"] = taxable;
                            R["tax"] = tax;
                            R["unabatable"] = unabatable;
                            break;
                        }
                    }

                }

            }
            else {
                foreach (DataRow Row in DS.invoicedetail.Select()) {
                    // Solo le righe selezionate
                    if (!DetailsToUpdate.Contains(Row["rownum"])) {
                        DetailsToUpdate.Add(Row["rownum"]);
                    }
                }
            }
        }

        void ClearOperationsToDo() {
            DS.expenseinvoice.Clear();
            DS.expenseyear.Clear();
            DS.expense.Clear();
            DS.expenselast.Clear();
            DS.expenseclawback.Clear();
            DS.expensesorted.Clear();
            DS.invoicedetail.Clear();
            DS.invoicedetaildeferred.Clear();
            DetailsToUpdate.Clear();
        }

        private void txtDaPagare_Leave(object sender, EventArgs e) {
            RecalcOperationsToDo();
        }

        private void labelAddCont_Click(object sender, EventArgs e) {

        }

        private void tabController_SelectionChanged(object sender, EventArgs e) {

        }

        bool inChiusura = false;
        private void FrmWizardInvoiceDetailNoMandate_FormClosing(object sender, FormClosingEventArgs e) {
            inChiusura = true;
        }
    }

}
