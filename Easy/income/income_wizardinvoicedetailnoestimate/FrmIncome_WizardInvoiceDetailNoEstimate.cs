
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
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
using funzioni_configurazione;
using movimentofunctions;
using System.Globalization;
using ep_functions;
using AskInfo;
using gestioneclassificazioni;
using q = metadatalibrary.MetaExpression;

namespace income_wizardinvoicedetailnoestimate {
    public partial class FrmIncome_WizardInvoiceDetailNoEstimate : MetaDataForm {
        MetaData Meta;
        DataAccess Conn;
        string CustomTitle;
        DataSet DSCopy;
        GestioneClassificazioni ManageClassificazioni;
        decimal TotaleDaContabilizzare = 0;
        int fasefattura;
        int choosenParentPhase = 0;
        ArrayList DetailsToUpdate;
        CQueryHelper QHC;
        QueryHelper QHS;
        bool monofase = false;

        public FrmIncome_WizardInvoiceDetailNoEstimate() {
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

                RecalcDettagliSelezionati();

                DisplayMessages();
                return doAssocia();
            }
            return true;
        }

        #endregion

        public void MetaData_AfterActivation() {
            CustomTitle = "Wizard Contabilizzazione Dettagli Fattura Vendita non associati a Contratto Attivo";
            DisplayTabs(0);
        }

        DataRow GetGridRow(DataGrid G, int index) {
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet) G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            string filter;
            DataRow Invoice = DS.invoice.Rows[0];

            filter = QHC.AppAnd(QHC.CmpEq("idinvkind", Invoice["idinvkind"]), QHC.CmpEq("yinv", Invoice["yinv"]),
                QHC.CmpEq("ninv", Invoice["ninv"]), QHC.CmpEq("rownum", G[index, 0]));
            DataRow[] selectresult = MyTable.Select(filter);
            return (selectresult.Length > 0) ? selectresult[0] : null;
        }

        private DataRow[] GetGridSelectedRows(DataGrid G) {
            if (G.DataMember == null) return null;
            if (G.DataSource == null) return null;
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet) G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            int numrighetemp = MyTable.Rows.Count;
            int numrighe = 0;
            int i;
            for (i = 0; i < numrighetemp; i++) {
                if (G.IsSelected(i)) {
                    DataRow R = GetGridRow(G, i);
                    if (R == null) continue;
                    numrighe++;
                }
            }

            DataRow[] Res = new DataRow[numrighe];
            int count = 0;
            for (i = 0; i < numrighetemp; i++) {
                if (G.IsSelected(i)) {
                    DataRow R = GetGridRow(G, i);
                    if (R == null) continue;
                    Res[count++] = R;
                }
            }
            return Res;
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            GetData.CacheTable(DS.incomephase);
            string filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            fasefattura = CfgFn.GetNoNullInt32(Meta.GetSys("maxincomephase"));
            string filterInvoice = QHS.AppAnd(QHS.BitSet("flag", 0), QHS.BitClear("flag", 2));
            GetData.CacheTable(DS.invoicekind, filterInvoice, "description", true);
            GetData.CacheTable(DS.ivakind);
            GetData.CacheTable(DS.config, filteresercizio, null, false);
            string billfilter = QHS.AppAnd(QHS.NullOrEq("active", "S"), QHS.CmpEq("billkind", 'C'),
                QHS.CmpEq("ybill", Meta.GetSys("esercizio")));
            GetData.SetStaticFilter(DS.bill, billfilter);
            GetData.SetStaticFilter(DS.billview, billfilter);
            DetailsToUpdate = new ArrayList();
            Meta.CanCancel = false;
            Meta.SearchEnabled = false;
            Meta.CanSave = false;
            monofase = (Conn.RUN_SELECT_COUNT("incomephase", null, true) == 1) ? true : false;
        }

        public void MetaData_AfterClear() {
            DisplayTabs(tabController.SelectedIndex);
        }

        // J.T.R. CONTINUARE DA QUI 04.09.2007
        private void btnDocumento_Click(object sender, EventArgs e) {
            string filter = "";
            int esercizio = (int) Meta.GetSys("esercizio");
            int esercText = CfgFn.GetNoNullInt32(txtEsercDoc.Text);
            if (esercText != 0)
                filter = GetData.MergeFilters(filter, QHS.CmpEq("yinv", esercText));

            if ((!sender.Equals(btnDocumento)) && txtNumDoc.Text.Trim() != "") {
                int ndoc = CfgFn.GetNoNullInt32(txtNumDoc.Text);
                if (ndoc > 0) filter = GetData.MergeFilters(filter, QHS.CmpEq("ninv", ndoc));
            }
            if (cmbTipoFattura.SelectedIndex > 0) {
                filter = GetData.MergeFilters(filter, QHS.CmpEq("idinvkind", cmbTipoFattura.SelectedValue));
            }

            filter = GetData.MergeFilters(filter, QHS.CmpGt("residual", 0));
            filter = QHS.AppAnd(filter, QHS.NullOrEq("active", "S"));
            MetaData Invoice = MetaData.GetMetaData(this, "invoiceincavailable");
            Invoice.FilterLocked = true;
            Invoice.DS = new DataSet();
            DataRow M = Invoice.SelectOne("default", filter, null, null);
            if (M == null) return;
            HelpForm.SetComboBoxValue(cmbTipoFattura, M["idinvkind"]);
            txtEsercDoc.Text = M["yinv"].ToString();
            txtNumDoc.Text = M["ninv"].ToString();
            txtFornitore.Text = M["registry"].ToString();
            txtDescrFattura.Text = M["description"].ToString();

            DS.invoicedetail.Clear();
            DetailsToUpdate.Clear();
            DS.invoice.Clear();

            string filterinvoice = QHS.AppAnd(QHS.CmpEq("idinvkind", M["idinvkind"]),
                QHS.CmpEq("yinv", M["yinv"]), QHS.CmpEq("ninv", M["ninv"]));
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.invoice, null, filterinvoice, null, false);
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
            //bool intracom = false;//Per i C.A. e Fatture intracom., l'università incassa anche l'iva, per cui deve essere possibile contabilizzarla.Vedi 8524
            bool EnableImpon = true;
            bool EnableImpos = true;
            bool EnableDocum = true;

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
                    //if (Dett["flagintracom"].ToString().ToUpper() != "N") intracom = true;
                }
            }
            ClearComboCausale();
            //if (intracom) {
            //    EnableDocum = false;
            //    EnableImpos = false;
            //}

            string filter_idupbivaset = QHS.AppAnd(filterfattura, QHS.IsNotNull("idupb_iva"));
            int n_idupbivaset = Conn.RUN_SELECT_COUNT("invoicedetail", filter_idupbivaset, false);

            if (n_idupbivaset > 0) {
                EnableDocum = false;
            }

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
            string filtercausale = QHS.CmpEq("idtipo", causale);
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
                // --> basta un filtro su idinc_iva is null
                filterinvoicedetail = GetData.MergeFilters(filterinvoicedetail,
                    QHS.AppAnd(QHS.IsNull("idinc_iva"), QHS.IsNull("idinc_taxable")));
            }
            if (causale == 3) {
                // Se è abilitato IMPON significa che non ci sono contabilizzazioni ORDIN attivate,
                // ossia tutti i dettagli sono contabilizzati con imponibile + iva
                // --> basta un filtro su idinc_taxable is null
                filterinvoicedetail = GetData.MergeFilters(filterinvoicedetail, QHS.IsNull("idinc_taxable"));
            }
            if (causale == 2) {
                // Se è abilitato IMPOS significa che non ci sono contabilizzazioni diverse da ORDIN attivate,
                // ossia tutti i dettagli sono o contabilizzati con imponibile + iva
                // --> basta un filtro su idinc_iva is null
                filterinvoicedetail = GetData.MergeFilters(filterinvoicedetail, QHS.IsNull("idinc_iva"));
            }

            DSCopy = DS.Copy();
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DSCopy.Tables["invoicedetail"], null, filterinvoicedetail, null,
                false);
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

        private void txtEsercDoc_Leave(object sender, EventArgs e) {
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
                btnDocumento_Click(sender, e);
                return;
            }
        }

        private void txtNumDoc_Leave(object sender, EventArgs e) {
            int NInv = CfgFn.GetNoNullInt32(txtNumDoc.Text);
            if (NInv <= 0) {
                ClearFattura();
                return;
            }
            btnDocumento_Click(sender, e);
            return;
        }

        private void btnSelectAllDetail_Click(object sender, EventArgs e) {
            if (gridDetails.DataSource == null) return;
            if (DSCopy != null) {
                for (int i = 0; i < DSCopy.Tables["invoicedetail"].Rows.Count; i++) gridDetails.Select(i);
            }
        }

        void RecalcTotalDetails() {
            txtDaPagare.Text = "";
            txtPerc.Text = "";
            DataRow[] Selected = GetGridSelectedRows(gridDetails);
            if ((Selected == null) || (Selected.Length == 0)) {
                txtTotGenerale.Text = "";
                txtTotImponibile.Text = "";
                txtTotIva.Text = "";
                TotaleDaContabilizzare = 0;
                return;
            }
            if (DS.invoice.Rows.Count == 0) return;
            DataRow Invoice = DS.invoice.Rows[0];
            double tassocambio = CfgFn.GetNoNullDouble(Invoice["exchangerate"]);

            if (tassocambio == 0) tassocambio = 1;
            double totiva = 0;
            double totimpo = 0;
            double total = 0;
            int causale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
            foreach (DataRow Curr in Selected) {
                DataRow[] IvaKind =
                    DS.ivakind.Select("(idivakind = " + QueryCreator.quotedstrvalue(Curr["idivakind"], false) + ")");
                if (IvaKind.Length == 0) {
                    show(this, "Non esiste la riga nell'anagrafica dei tipi IVA", "Errore");
                    return;
                }
                double imponibile = CfgFn.GetNoNullDouble(Curr["taxable"]);
                double quantitaConfezioni = CfgFn.GetNoNullDouble(Curr["npackage"]);
                double aliquota = CfgFn.GetNoNullDouble(IvaKind[0]["rate"]);
                double sconto = CfgFn.GetNoNullDouble(Curr["discount"]);
                double imponibileEUR = (imponibile*quantitaConfezioni*(1 - sconto))*tassocambio;
                double ivaEUR = CfgFn.GetNoNullDouble(Curr["tax"])*tassocambio;

                imponibileEUR = CfgFn.RoundValuta(imponibileEUR);
                ivaEUR = CfgFn.RoundValuta(ivaEUR);
                if (causale == 3) {
                    totimpo += imponibileEUR;
                }
                if (causale == 2) {
                    totiva += ivaEUR;
                }
                if (causale == 1) {
                    totimpo += imponibileEUR;
                    totiva += ivaEUR;
                }
                total = totimpo + totiva;

            }
            if (causale == 3) {
                txtTotGenerale.Text = total.ToString("c");
                txtTotImponibile.Text = totimpo.ToString("c");
                txtTotIva.Text = "";
                TotaleDaContabilizzare = CfgFn.GetNoNullDecimal(totimpo);
                txtTotSelezionato.Text = totimpo.ToString("C");
            }
            if (causale == 2) {
                txtTotGenerale.Text = total.ToString("c");
                txtTotImponibile.Text = "";
                txtTotIva.Text = totiva.ToString("c");
                TotaleDaContabilizzare = CfgFn.GetNoNullDecimal(totiva);
                txtTotSelezionato.Text = totiva.ToString("C");
            }
            if (causale == 1) {
                txtTotGenerale.Text = total.ToString("c");
                txtTotImponibile.Text = totimpo.ToString("c");
                txtTotIva.Text = totiva.ToString("c");
                TotaleDaContabilizzare = CfgFn.GetNoNullDecimal(total);
                txtTotSelezionato.Text = total.ToString("C");
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
            double ivaEUR = CfgFn.GetNoNullDouble(Curr["tax"])*tassocambio;

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

        object[] ValoriDiversi(DataRow[] Rows, string field) {
            object[] DIV = new object[Rows.Length];
            int N = 0;
            foreach (DataRow R in Rows) {
                object currval = R[field];
                int j = 0;
                for (j = 0; j < N; j++) {
                    if (DIV[j].Equals(currval)) {
                        break;
                    }
                }
                if (j == N) {
                    DIV[N++] = currval;
                }
            }
            object[] result = new object[N];
            for (int i = 0; i < N; i++) result[i] = DIV[i];
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
        

        string idinc_selected;

        void FillMovimento(DataRow Income) {
            idinc_selected = Income["idinc"].ToString();
            txtNumeroMovimento.Text = Income["nmov"].ToString();
            txtEsercizioMovimento.Text = Income["ymov"].ToString();
            txtDescrizione.Text = Income["description"].ToString();
            SubEntity_txtImportoMovimento.Text = CfgFn.GetNoNullDecimal(Income["amount"]).ToString("c");
            txtDataCont.Text = ((DateTime) Income["adate"]).ToShortDateString();
            txtCodiceBilancio.Text = Income["codefin"].ToString();
            txtDenominazioneBilancio.Text = Income["finance"].ToString();
            txtUPB.Text = Income["codeupb"].ToString();
            txtDescrUPB.Text = Income["upb"].ToString();
            txtImportoCorrente.Text = CfgFn.GetNoNullDecimal(Income["curramount"]).ToString("c");
            txtImportoDisponibile.Text = CfgFn.GetNoNullDecimal(Income["available"]).ToString("c");

            DataTable incomeestimateview = DataAccess.CreateTableByName(Meta.Conn, "incomeestimateview", "*");

            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, incomeestimateview, null,
                "(idinc = '" + idinc_selected + "')", null, true);

            if ((incomeestimateview != null) && (incomeestimateview.Rows.Count != 0)) {
                DataRow IE = incomeestimateview.Rows[0];
                string msg = "Il movimento " + Income["ymov"].ToString() + "/" + Income["nmov"].ToString()
                             + " contabilizza il contratto attiivo " + IE["estimkind"].ToString() + " " +
                             IE["yestim"].ToString()
                             + "/" + IE["nestim"].ToString();

                lblWarningMandate.Text = msg;
                lblWarningMandate.Visible = true;
            }
            else {

                lblWarningMandate.Visible = false;
            }
        }

        void ClearMovimento() {
            idinc_selected = null;
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
            string filter = QHS.CmpEq("ayear", esercizio);
            filter = GetData.MergeFilters(filter, filterMovimento);

            int esercText = CfgFn.GetNoNullInt32(txtEsercizioMovimento.Text);
            if (esercText > 0) {
                filter = GetData.MergeFilters(filter, QHS.CmpEq("ymov", esercText));
            }

            if ((!sender.Equals(btnSelectMov)) && txtNumeroMovimento.Text.Trim() != "") {
                int nmov = CfgFn.GetNoNullInt32(txtNumeroMovimento.Text);
                if (nmov > 0) filter = GetData.MergeFilters(filter, QHS.CmpEq("nmov", nmov));
            }
            int phase;
            if (radioAddCont.Checked)
                phase = fasefattura;
            else
                phase = choosenParentPhase;

            filter = GetData.MergeFilters(filter, QHS.CmpEq("nphase", phase));
            MetaData IncomeToConsider;
            IncomeToConsider = MetaData.GetMetaData(this, "income");
            IncomeToConsider.FilterLocked = true;
            IncomeToConsider.DS = new DataSet();
            DataRow M = IncomeToConsider.SelectOne("default", filter, null, null);
            if (M == null) return;
            FillMovimento(M);
            idinc_selected = M["idinc"].ToString();
            SelezioneMovimentiEffettuata = true;
        }

        private void radioAddCont_CheckedChanged(object sender, EventArgs e) {
            if (radioAddCont.Checked) SetAddCont();
            labelAddCont.Visible = radioAddCont.Checked;
        }

        private void radioNewCont_CheckedChanged(object sender, EventArgs e) {
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
            /*if (FiltraRows(Selected, QHS.IsNotNull("idupb")).Length > 0) {
                DataRow rUpb = FiltraRows(Selected, QHS.IsNotNull("idupb"))[0];
                filterupb = QHS.CmpEq("idupb", rUpb["idupb"]);
            }*/

            DataRow Invoice = DS.invoice.Rows[0];
            string filteridreg = QHS.CmpEq("idreg", Invoice["idreg"]);

            string filtercont = "";
            filtercont = GetData.MergeFilters(filtercont,
                "(NOT idinc in (SELECT idinc from incomeinvoice))");

            filtercont = GetData.MergeFilters(filtercont, filterupb);

            string esercizio = Meta.GetSys("esercizio").ToString();
            filtercont = GetData.MergeFilters(filtercont, filteridreg);
            filtercont = GetData.MergeFilters(filtercont, QHS.CmpEq("ayear", esercizio));
            filtercont = GetData.MergeFilters(filtercont, QHS.CmpEq("nphase", fasefattura));
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
            descfasefattura = Conn.DO_READ_VALUE("incomephase", filterfase, "description").ToString();
            if (descfasefattura != "") {
                gboxMovimento.Text = descfasefattura;
            }
            gboxSelMov.Enabled = true;

        }

        void SetNewMov() {
            ClearMovimento();
            AbilitaDisabilitaSelezioneMovimento(false);
            SelezioneMovimentiEffettuata = true; //!!
            int primafaseentrata = 1;
            string filterfase = QHS.CmpEq("nphase", primafaseentrata);
            string descfase = "";
            descfase = Conn.DO_READ_VALUE("incomephase", filterfase, "description").ToString();
            if (descfase != "") {
                gboxMovimento.Text = descfase;
            }

        }

        void SetNewLinkedMov() {
            if (DS.invoice.Rows.Count == 0) return;
            DataRow Inv = DS.invoice.Rows[0];
            DataRow[] Selected = GetGridSelectedRows(gridDetails);
            string filterregistry = "(idreg=" + QueryCreator.quotedstrvalue(Inv["idreg"], true) + ")";

            int fasecred = CfgFn.GetNoNullInt32(Meta.GetSys("incomeregphase"));
            int fasebilancio = CfgFn.GetNoNullInt32(Meta.GetSys("incomefinphase"));

            DataTable tempFase = DataAccess.CreateTableByName(Meta.Conn, "incomephase", "*");
            foreach (DataRow rFase in DS.incomephase.Rows) {
                if (CfgFn.GetNoNullInt32(rFase["nphase"]) >= fasefattura) continue;
                DataRow r = tempFase.NewRow();
                foreach (DataColumn c in DS.incomephase.Columns) {
                    r[c.ColumnName] = rFase[c.ColumnName];
                }
                tempFase.Rows.Add(r);
            }

            FrmAskFase faf = new FrmAskFase(tempFase);
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
                filterMovimento = GetData.MergeFilters(filterregistry, filterMovimento);
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
            int faseContabCompensi = CfgFn.GetNoNullInt32(Meta.GetSys("estimatephase"));

            ClearMovimento();
            AbilitaDisabilitaSelezioneMovimento(true);
            SelezioneMovimentiEffettuata = false;
            labMsgTODO1.Text = "Sarà creato un nuovo movimento di entrata";


            if (fasefattura > 1) {
                string filterfase = QHS.CmpEq("nphase", choosenParentPhase);
                string descfaseprecedente = "";
                descfaseprecedente = Conn.DO_READ_VALUE("incomephase", filterfase, "description").ToString();
                if (descfaseprecedente != "") {
                    gboxMovimento.Text = descfaseprecedente;
                }
            }
        }

        void RadioCheck_Changed() {
            if (radioAddCont.Checked) SetAddCont();
            if (radioNewCont.Checked) SetNewMov();
            if (radioNewLinkedMov.Checked) SetNewLinkedMov();
        }

        private void txtEsercizioMovimento_Leave(object sender, EventArgs e) {
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
                int fasebilancio = CfgFn.GetNoNullInt32(Meta.GetSys("incomefinphase"));
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

            object idman_start = DBNull.Value;
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
            if (FiltraRows(Selected, QHS.IsNotNull("idupb")).Count > 0 || idupb != DBNull.Value) {
                upbToSelect = false;
            }

            object idfin = DBNull.Value;
            int count = CfgFn.GetNoNullInt32(Conn.count("finusable", q.bitClear("flag", 1) & q.bitClear("flag", 0) & q.eq("ayear", Meta.GetSys("esercizio"))));
            if (monofase && count == 1) {
                idfin = Conn.readValue("finusable", q.bitClear("flag", 1) & q.bitClear("flag", 0) & q.eq("ayear", Meta.GetSys("esercizio")), "idfin");
			}

            FrmAskInfo F = new FrmAskInfo(Meta, "E", upbToSelect)
                .SetManager(idman_start)
                .SetUPB(idupb)
                .SetFin(idfin)
                .EnableManagerSelection(idman_start != DBNull.Value)
                .EnableFilterAvailable(amount)
                .EnableUPBSelection(upbToSelect);
                
            if (manager_in_details)
                F.EnableManagerSelection(false);
            else
                F.AllowNoManagerSelection(true);

            //"E", filterupb, Meta.Dispatcher, idman_start, amount, upbToSelect);
            if (F.ShowDialog(this) != DialogResult.OK) return false;

            if (idman_start == DBNull.Value)
                idmanagerSelected = DBNull.Value;
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
                DS.income.Clear();
                DS.incomeyear.Clear();
                DS.incomelast.Clear();
                DS.incomeinvoice.Clear();
                return doSaveNewIncome(null);
            }
            if (radioNewLinkedMov.Checked) {
                DS.income.Clear();
                DS.incomeyear.Clear();
                DS.incomelast.Clear();
                DS.incomeinvoice.Clear();
                return doSaveNewIncome(idinc_selected);
            }
            if (radioAddCont.Checked) {
                DS.incomeinvoice.Clear();
                DS.incomeyear.Clear();
                DS.incomelast.Clear();
                DS.income.Clear();
                return doAddConta();
            }
            return false;
        }

        bool doAssociaSoloDettagli() {
            int esercizio = Convert.ToInt32(Meta.GetSys("esercizio"));
            Conn.RUN_SELECT_INTO_TABLE(DS.income, null, QHS.CmpEq("idinc", idinc_selected), null, false);
            Conn.RUN_SELECT_INTO_TABLE(DS.incomeyear, null,
                QHS.AppAnd(QHS.CmpEq("idinc", idinc_selected), QHS.CmpEq("ayear", esercizio)), null, false);

            if (DS.income.Rows.Count > 0) {
                DataRow Inv = DS.invoice.Rows[0];
                DataRow CurrInc = DS.income.Rows[0];
                object NuovoDocumento = Inv["doc"];
                object NuovoDataDocumento = Inv["docdate"];
                if (show(this, "Aggiorno i campi documento e data documento del movimento di entrata " +
                                          "in base al documento selezionato?", "Conferma", MessageBoxButtons.OKCancel) ==
                    DialogResult.OK) {
                    if ((NuovoDocumento != null) && (NuovoDocumento != DBNull.Value))
                        CurrInc["doc"] = NuovoDocumento;
                    if (NuovoDataDocumento != null) CurrInc["docdate"] = NuovoDataDocumento;
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
                        R["idinc_taxable"] = idinc_selected;
                        R["idinc_iva"] = idinc_selected;
                        break;
                    case 3:
                        R["idinc_taxable"] = idinc_selected;
                        break;
                    case 2:
                        R["idinc_iva"] = idinc_selected;
                        break;
                }
            }

            AggiornaUPBDettagli(Selected, currcausale);

            if (DS.incomeyear.Rows[0]["idupb"] != DBNull.Value) idUPBSelected = DS.incomeyear.Rows[0]["idupb"];

            return doSave();
        }

        bool doSave() {
            DataSet DSP = DS.Copy();
            int faseentratamax = CfgFn.GetNoNullInt32(Meta.GetSys("maxincomephase"));
            GestioneAutomatismi ga = new GestioneAutomatismi(this, Meta.Conn, Meta.Dispatcher,
                DS, fasefattura, faseentratamax, "income", true);
            string newcomputesorting = Meta.Conn.DO_READ_VALUE("siopekind", QHC.CmpEq("codesorkind_siopeentrate", Meta.GetSys("codesorkind_siopeentrate")), "newcomputesorting").ToString();
            if (newcomputesorting == "S" && !radioAddCont.Checked) {
                ManageClassificazioni = new GestioneClassificazioni(Meta, null, null, null, null, null, null, null, null);
                ManageClassificazioni.ClassificaTramiteClassDocumento(ga.DSP, DS);
				ManageClassificazioni.completaClassificazioniSiope(DS.incomesorted, ga.DSP);
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
            DS.incomeinvoice.Clear();
            DS.invoicedetail.Clear();
            DS.income.Clear();
            DS.incomeyear.Clear();
            DS.incomelast.Clear();
            DS.registry.Clear();
            return true;
        }

        void ViewAutomatismi(DataSet DS) {
            string entrata = null;
            if (DS.Tables["income"] != null) {
                DataTable Var = DS.Tables["income"];
                if (DS.Tables["income"].Select().Length == 0) return;
                entrata = QHS.FieldIn("idinc", Var.Select(), "idinc");
            }

            Form F = ShowAutomatismi.Show(Meta, null, entrata, null, null);
            F.ShowDialog(this);
        }

        bool doAddConta() {
            //Crea la riga in incomeinvoice
            //Non solo deve associare i dettagli, ma deve anche creare la righe in incomeinvoice
            MetaData IncInv = MetaData.GetMetaData(this, "incomeinvoice");
            DataRow Inv = DS.invoice.Rows[0];
            MetaData.SetDefault(DS.incomeinvoice, "idinc", idinc_selected);
            IncInv.SetDefaults(DS.incomeinvoice);
            DataRow M = IncInv.Get_New_Row(Inv, DS.incomeinvoice);
            M["movkind"] = cmbCausale.SelectedValue;
            return doAssociaSoloDettagli();
        }

        /// <summary>
        /// Riempie i dati di una riga di entata o spesa prendendoli dall'automatismo e dall'
        ///  IDmovimento in ingresso
        /// </summary>
        /// <param name="E_S"></param>
        /// <param name="Auto"></param>
        /// <param name="CurrSpesa"></param>
        void FillMovimento(DataRow E_S, decimal amount, object idman, int idreg,
            string description) {
            int esercizio = Convert.ToInt32(Meta.GetSys("esercizio"));
            DateTime DataCont = Convert.ToDateTime(Meta.GetSys("datacontabile"));
            E_S.BeginEdit();
            E_S["ymov"] = esercizio;
            E_S["adate"] = DataCont;
            E_S["idman"] = idman;
            E_S["idreg"] = idreg;
            E_S["description"] = description;
            E_S.EndEdit();
        }


        void FillImputazioneMovimento(DataRow ImpMov, decimal amount, object idfin, object idupb) {
            ImpMov["amount"] = amount;
            ImpMov["idfin"] = idfin;
            ImpMov["idupb"] = idupb;
        }

        void ImpostaModalitaRiscossione(DataRow R, bool mustUpdateValues, DataRow Rexpenselast) {
            //if (currphase < faseentratamax) {
            //    grpModRiscossione.Visible = false;
            //    SubEntity_chkCassa.Enabled = false;
            //    SubEntity_chkPrelievodaCCP.Enabled = false;
            //    SubEntity_chkAccreditoTPS.Enabled = false;
            //    return;
            //}
            //else {
            //    if (R == null) {
            //        grpModRiscossione.Visible = true;
            //        SubEntity_chkCassa.Enabled = true;
            //        SubEntity_chkPrelievodaCCP.Enabled = true;
            //        SubEntity_chkAccreditoTPS.Enabled = true;
            //        return;
            //    }
            //}

            if ((R != null)/* && (currphase == faseentratamax)*/) {
                //grpModRiscossione.Visible = true;
                //SubEntity_chkCassa.Enabled = true;
                //SubEntity_chkPrelievodaCCP.Enabled = true;
                //SubEntity_chkAccreditoTPS.Enabled = true;

                object ccp = R["ccp"];
                object flagbankitaliaproceeds = R["flagbankitaliaproceeds"];

                if ((mustUpdateValues) && (ccp.ToString() == "") &&
                    ((flagbankitaliaproceeds == DBNull.Value) ||
                     (flagbankitaliaproceeds.ToString() != "S"))) {
                    //SubEntity_chkCassa.Checked = true;
                    Rexpenselast["flag"] = (byte)((CfgFn.GetNoNullByte(Rexpenselast["flag"])) | 2); //Imposta il bit
                }

                if (ccp.ToString() != "") {
                    //SubEntity_chkPrelievodaCCP.Enabled = true;
                    if (mustUpdateValues) {
                        //SubEntity_chkPrelievodaCCP.Checked = true;
                        Rexpenselast["flag"] = (byte)((CfgFn.GetNoNullByte(Rexpenselast["flag"])) | 4); //Imposta il bit
                    }
                }
                else {
                    //SubEntity_chkPrelievodaCCP.Enabled = false;
                }

                if ((flagbankitaliaproceeds != DBNull.Value) &&
                    (flagbankitaliaproceeds.ToString() == "S"))
                    if (mustUpdateValues) {
                        //SubEntity_chkAccreditoTPS.Checked = true;
                        Rexpenselast["flag"] = (byte)((CfgFn.GetNoNullByte(Rexpenselast["flag"])) | 8); //Imposta il bit
                    }
            }
        }



        bool doSaveNewIncome(string idparent) {
            int fasecred = CfgFn.GetNoNullInt32(Meta.GetSys("incomeregphase"));
            int fasebilancio = CfgFn.GetNoNullInt32(Meta.GetSys("incomefinphase"));
            int faseentratamax = CfgFn.GetNoNullInt32(Meta.GetSys("maxincomephase"));
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

            MetaData Inc = MetaData.GetMetaData(this, "income");
            MetaData IncY = MetaData.GetMetaData(this, "incomeyear");
            MetaData IncL = MetaData.GetMetaData(this, "incomelast");
            MetaData IncInvoice = MetaData.GetMetaData(this, "incomeinvoice");
            MetaData InvoiceDetail = MetaData.GetMetaData(this, "invoicedetail");
            Inc.SetDefaults(DS.income);
            IncY.SetDefaults(DS.incomeyear);
            IncL.SetDefaults(DS.incomelast);
            IncInvoice.SetDefaults(DS.incomeinvoice);
            InvoiceDetail.SetDefaults(DS.invoicedetail);


            if (idparent != null) MetaData.SetDefault(DS.income, "parentidinc", idparent);
            else MetaData.SetDefault(DS.income, "parentidinc", DBNull.Value);

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
                if (upbiva.Length > 1 || upbiva[0] != DBNull.Value) {
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

            DataTable Mov = DS.income;
            DataTable ImpMov = DS.incomeyear;
            DataTable LastMov = DS.incomelast;
            DataRow Invoice = DS.invoice.Rows[0];

            ////int currcausale = CfgFn.GetNoNullInt32( cmbCausale.SelectedValue);
            int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));

            MetaData.SetDefault(DS.incomeyear, "ayear", esercizio);
            if (idparent != null) {
                MetaData.SetDefault(DS.income, "parentidinc", idparent);
                DataTable IncomeYear = Conn.RUN_SELECT("incomeyear", "*", null,
                    QHS.AppAnd(QHS.CmpEq("idinc", idparent), QHS.CmpEq("ayear", esercizio)),
                    null, null, false);
                DataRow ParIncY = IncomeYear.Rows[0];
                if (ParIncY["idfin"] != DBNull.Value) idfinSelected = ParIncY["idfin"];
                if (ParIncY["idupb"] != DBNull.Value) idUPBSelected = ParIncY["idupb"];
            }

            //if (!verificaSeUPBUniformi(upb)) {
            //    show("Attenzione! I dettagli devono avere tutti lo stesso UPB!.\n\rL'operazione sarà interrotta");
            //    return false;
            //}

            object idupb = upb[0];
            string filterupboriginal = "";
            string filterupbnew = "";
            string filterinvdetoriginal = "";
            if (idupb == DBNull.Value) {
                filterupboriginal = QHS.IsNull("idupb");
                filterupbnew = QHC.CmpEq("idupb", idUPBSelected);
                filterinvdetoriginal = QHS.IsNull(field_upb);
            }
            else {
                filterupboriginal = QHC.CmpEq("idupb", idupb);
                filterinvdetoriginal = QHS.CmpEq(field_upb, idupb);
            }

            object idmanagerupb = DBNull.Value;
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

            if (((curridmanager == null) || (curridmanager == DBNull.Value)) && (idparent != "")) {
                object idmanParent = Meta.Conn.DO_READ_VALUE("income",
                    "(idinc = " + QueryCreator.quotedstrvalue(idparent, true) + ")",
                    "idman");
                if ((idmanParent != null) && (idmanParent != DBNull.Value)) {
                    curridmanager = idmanParent;
                }
            }
            object idreg = Invoice["idreg"];

            int codicereg = CfgFn.GetNoNullInt32(idreg);
            string filterregistry = QHS.CmpEq("idreg", idreg);

            DS.registry.Clear();
            Conn.RUN_SELECT_INTO_TABLE(DS.registry, null, filterregistry, null, true);
            string title = DS.registry.Rows[0]["title"].ToString();

            string filterdetail = filterinvdetoriginal;

            decimal amount = CalcTotCausale(FiltraRows(SelectedRows, filterdetail).ToArray(), currcausale);

            DataRow ParentR = null;
            DataRow IncomeToLink = null;

            for (int faseCorrente = faseinizio; faseCorrente <= fasefine; faseCorrente++) {
                Mov.Columns["nphase"].DefaultValue = faseCorrente;

                DataRow NewEntrataRow = Inc.Get_New_Row(ParentR, Mov);
                if (faseCorrente == fasefattura) IncomeToLink = NewEntrataRow;
                ParentR = NewEntrataRow;

                FillMovimento(NewEntrataRow, amount, curridmanager, codicereg, Invoice["description"].ToString());


                NewEntrataRow["doc"] = "Fatt." +
                                       Invoice["idinvkind"].ToString() + "/" +
                                       Invoice["yinv"].ToString().Substring(2, 2) + "/" +
                                       Invoice["ninv"].ToString().PadLeft(6, '0');
                NewEntrataRow["docdate"] = Invoice["adate"];

                NewEntrataRow["nphase"] = faseCorrente;

                if (faseCorrente < fasecred) {
                    NewEntrataRow["idreg"] = DBNull.Value;
                }
                else {
                    NewEntrataRow["idreg"] = codicereg;
                }

                DataRow NewImpMov = ImpMov.NewRow();

                if (idupb != DBNull.Value) {
                    FillImputazioneMovimento(NewImpMov, amount, idfinSelected, idupb);
                }
                else {
                    FillImputazioneMovimento(NewImpMov, amount, idfinSelected, idUPBSelected);
                }
                NewImpMov["idinc"] = NewEntrataRow["idinc"];
                NewImpMov["ayear"] = esercizio;

                if (faseCorrente < fasebilancio) {
                    NewImpMov["idfin"] = DBNull.Value;
                    NewImpMov["idupb"] = DBNull.Value;
                }
                ImpMov.Rows.Add(NewImpMov);

                if (faseCorrente == faseentratamax) {
                    DataRow NewLastMov = IncL.Get_New_Row(NewEntrataRow, LastMov);
                    // aggiunge le informazioni sul numero bolletta se sono state digitate dall'utente
                    int nBill = CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int),
                        txtBolletta.Text.ToString(), "x"));
                    if (nBill > 0) {
                        NewLastMov["nbill"] = nBill;
                        int flag = CfgFn.GetNoNullInt32(NewLastMov["flag"]);
                        flag = flag | 1;
                        NewLastMov["flag"] = flag;
                    }
                    ImpostaModalitaRiscossione(DS.registry.Rows[0], true, NewLastMov);
                    EP_functions EP = new EP_functions(Meta.Dispatcher);

                    object idaccmotive = DBNull.Value;
                    object idacc = DBNull.Value;

                    idaccmotive = Invoice["idaccmotivedebit_crg"];
                    if (idaccmotive == DBNull.Value) idaccmotive = Invoice["idaccmotivedebit"];

                    if (EP.attivo) {
                        idacc = EP.GetCustomerAccountForRegistry(idaccmotive, NewEntrataRow["idreg"]);
                    }
                    if (idacc != DBNull.Value) {
                        if (DS.account.Select(QHC.CmpEq("idacc", idacc)).Length == 0) {
                            DS.account.Clear();
                            Meta.Conn.RUN_SELECT_INTO_TABLE(DS.account, null, QHS.CmpEq("idacc", idacc), null, false);
                            if (DS.account.Rows.Count > 0) {
                                DataRow Acc = DS.account.Rows[0];
                            }
                        }
                        NewLastMov["idacccredit"] = idacc;
                    }

                }
            }

            //Aggiunge la riga in incomeinvoice
            DataRow IncInvRow = IncInvoice.Get_New_Row(IncomeToLink, DS.incomeinvoice);
            IncInvRow["movkind"] = currcausale;
            IncInvRow["idinvkind"] = Invoice["idinvkind"];
            IncInvRow["yinv"] = Invoice["yinv"];
            IncInvRow["ninv"] = Invoice["ninv"];

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
                        RD["idinc_taxable"] = IncomeToLink["idinc"];
                        RD["idinc_iva"] = IncomeToLink["idinc"];
                        break;
                    case 3:
                        RD["idinc_taxable"] = IncomeToLink["idinc"];
                        break;
                    case 2:
                        RD["idinc_iva"] = IncomeToLink["idinc"];
                        break;
                }
            }

            // Associa l'UPB ai dettagli sui quali non era stato impostato
            /*DataRow[] DetailsUPBNull = FiltraRows(Details, "(idupb is null)");
            foreach (DataRow RD1 in DetailsUPBNull) {
                RD1["idupb"] = idUPBSelected;
            }*/

            //Effettua il post

            return doSave();
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
            string causale = cmbCausale.SelectedValue.ToString();

            DataRow[] Selected = GetGridSelectedRows(gridDetails);

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
            decimal PercentualeDigitata = CfgFn.GetNoNullDecimal(
                HelpForm.GetObjectFromString(typeof(decimal),
                    txtPerc.Text, "x.y.c"));

            if (ImportoDaPagare > ImportoMax) {
                show("L'importo da pagare è superiore al totale dei dettagli selezionati");
                txtDaPagare.Text = "";
                ImportoDaPagare = 0;
                return;
            }
            decimal percentuale = 100;
            if (ImportoMax != 0) percentuale = ImportoDaPagare/ImportoMax*100;
            decimal rounded = Math.Round(percentuale, 4);
            // calcola la percentuale in base all'importo
            txtPerc.Text = HelpForm.StringValue(rounded, "x.y.fixed.4...1");
            string operazioni = "";
            operazioni = QueryCreator.GetPrintable(operazioni);

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
                decimal tax = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Row1["tax"]));
                decimal taxtotal = CfgFn.RoundValuta(tax*tassocambio1);
                decimal tax_recalc = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Row1["tax"])*proporzione);
                decimal tax_recalctotal = CfgFn.RoundValuta(tax_recalc*tassocambio1);
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
                    decimal tax = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Row["tax"]));
                    decimal taxtotal = CfgFn.RoundValuta(tax*tassocambio);
                    decimal tax_recalc = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Row["tax"])*proporzione);
                    tax_recalc = CfgFn.RoundValuta(tax_recalc*tassocambio);
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
            MetaData metaDT = MetaData.GetMetaData(this, "invoicedetail");
            metaDT.SetDefaults(DS.invoicedetail);
            decimal taxableResiduo = CfgFn.GetNoNullDecimal(Row["taxable"]) - taxable;
            decimal taxResiduo = CfgFn.GetNoNullDecimal(Row["tax"]) - tax;
            decimal unabatableResiduo = CfgFn.RoundValuta(taxResiduo*percindeduc);
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
            rDT["idestimkind"] = Row["idestimkind"];
            rDT["estimrownum"] = Row["estimrownum"];
            rDT["nestim"] = Row["nestim"];
            rDT["yestim"] = Row["yestim"];
            rDT["idinc_taxable"] = Row["idinc_taxable"]; // contabilizzaione imponibile già effettuata
            rDT["idinc_iva"] = Row["idinc_iva"]; // contabilizzaione iva già effettuata
            rDT["idaccmotive"] = Row["idaccmotive"];
            rDT["idsor1"] = Row["idsor1"];
            rDT["idsor2"] = Row["idsor2"];
            rDT["idsor3"] = Row["idsor3"];
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
            rDT["rounding"] = Row["rounding"];
            rDT["idfinmotive"] = Row["idfinmotive"];
            rDT["iduniqueformcode"] = Row["iduniqueformcode"];
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
            DataRow Invoice = DS.invoice.Rows[0];
            decimal tassocambio = CfgFn.GetNoNullDecimal(Invoice["exchangerate"]);
            ClearOperationsToDo();
            // Rilegge i dettagli con l'importo originale nel dataset
            foreach (DataRow Det in Selected) {
                string filterinvoicedetail = QueryCreator.WHERE_COLNAME_CLAUSE(
                    Det, new string[] {"idinvkind", "yinv", "ninv", "rownum"}, DataRowVersion.Default, true);
                DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.Tables["invoicedetail"], null, filterinvoicedetail, null,
                    false);
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
                    foreach (DataRow Row in DS.invoicedetail.Select(null, "rownum"))
                        // Solo le righe selezionate ordinate per importo crescente
                    {
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
                    foreach (DataRow Row in Info.Select(null, "total asc"))
                        // Solo le righe selezionate ordinate per importo crescente 
                    {

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
            DS.incomeinvoice.Clear();
            DS.incomeyear.Clear();
            DS.incomelast.Clear();
            DS.income.Clear();
            DS.invoicedetail.Clear();
            DS.invoicedetaildeferred.Clear();
            DetailsToUpdate.Clear();
        }

        private void txtDaPagare_Leave(object sender, EventArgs e) {
            RecalcOperationsToDo();
        }

        private void tabController_SelectionChanged(object sender, EventArgs e) {

        }
    }

}
