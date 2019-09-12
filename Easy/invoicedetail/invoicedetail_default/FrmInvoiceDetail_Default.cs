/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione; //funzioni_configurazione

namespace invoicedetail_default {
    public partial class FrmInvoiceDetail_Default : Form {
        MetaData Meta;
        public FrmInvoiceDetail_Default() {
            InitializeComponent();
        }
        DataAccess Conn;
        QueryHelper QHS;
        CQueryHelper QHC;
       
        void MakeSpaceFrom(GroupBox G) {
            Form F = G.FindForm();
            int disp = G.Height;
            int y0 = G.Location.Y;
            F.SuspendLayout();
            foreach (Control C in F.Controls) {
                if (C.Location.Y < y0) continue;
                if ((C.Anchor & AnchorStyles.Bottom) == 0)
                    C.Location = new Point(C.Location.X, C.Location.Y - disp);
                else {
                    if ((C.Anchor & AnchorStyles.Top) != 0) {
                        C.Size = new Size(C.Size.Width, C.Size.Height + disp);
                        C.Location = new Point(C.Location.X, C.Location.Y - disp);
                    }
                }
            }
            F.Size = new Size(F.Size.Width, F.Size.Height - disp);
            F.ResumeLayout();

        }
        void HideShowIntrastat(bool Hide) {
            foreach (Control C in tabIntrastat.Controls)
                C.Visible = !Hide;
        }
        

        private void MostraCausalePCC() {
            if (Meta.IsEmpty)
                return;
            DataRow Curr = DS.invoicedetail.Rows[0];
            if (Curr["idpccdebitmotive"] != DBNull.Value) {
                txtCausale.Text = DS.pccdebitmotive.Select(QHC.CmpEq("idpccdebitmotive", Curr["idpccdebitmotive"]))[0]["description"].ToString();
            }
        }

        private void SetLabel()
        {
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.invoicedetail.Rows[0];
            object idpackage = Curr["idpackage"];
            object idunit = Curr["idunit"];

            if (idpackage == null || idpackage == DBNull.Value){
                lblidpackage.Text = "Q.tà";
                //lblImportoUnitario.Text = "Importo unitario";
            }
            else{
                string UnitaAcquisto = Conn.DO_READ_VALUE("package", QHS.CmpEq("idpackage", idpackage), "description").ToString();
                lblidpackage.Text = "N." + UnitaAcquisto;
                //lblImportoUnitario.Text = "Importo (per " + UnitaAcquisto + ")"; 
            }

            if (idunit == null || idunit == DBNull.Value){
                lblidunit.Text = "Totale";
            }
            else{
                string UnitaCarico = Conn.DO_READ_VALUE("unit", QHS.CmpEq("idunit", idunit), "description").ToString();
                lblidunit.Text = "N." + UnitaCarico;
            }
        }


      

        object GetCtrlByName(string Name)
        {
            System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
            if (Ctrl == null) return null;
            return Ctrl.GetValue(this);
        }


        void SetGBoxClass(int num, object sortingkind)
        {
            if (sortingkind == DBNull.Value)
            {
                GroupBox G = (GroupBox)GetCtrlByName("gboxclass" + num.ToString());
                G.Visible = false;
            }
            else
            {
                string filter = QHS.CmpEq("idsorkind", sortingkind);
                GetData.SetStaticFilter(DS.Tables["sorting" + num.ToString()], filter);
                GroupBox gboxclass = (GroupBox)GetCtrlByName("gboxclass" + num.ToString());
                Button btnCodice = (Button)GetCtrlByName("btnCodice" + num.ToString());
                gboxclass.Tag = "AutoManage.txtCodice" + num.ToString() + ".tree." + filter;
                string title = Conn.DO_READ_VALUE("sortingkind", filter, "description").ToString();
                gboxclass.Text = title;
                btnCodice.Tag = "manage.sorting" + num.ToString() + ".tree." + filter;
                DS.Tables["sorting" + num.ToString()].ExtendedProperties[MetaData.ExtraParams] = filter;
            }
        }
        string VeroTipoFatturaAV() {
            if (cmbTipoDocIVA.SelectedIndex <= 0) return "A";
            object idinvkind = cmbTipoDocIVA.SelectedValue;
            DataRow[] invKind = DS.invoicekind.Select(QHS.CmpEq("idinvkind", idinvkind));
            //int flag = CfgFn.GetNoNullInt32(invKind[0]);
            //bool Acquisto = (flag & 1) == 0;

            
            string filterreg = QHS.CmpEq("idinvkind", idinvkind);
            DataRow[] RegisterToLink = DS.invoicekindregisterkind.Select(filterreg);
            bool Acquisto = false;
            foreach (DataRow IReg in RegisterToLink) {
                object idivaregisterkind = IReg["idivaregisterkind"];
                if (DS.ivaregisterkind.Select(QHC.CmpEq("idivaregisterkind", idivaregisterkind)).Length == 0)
                    continue;
                DataRow IvaRegKind = DS.ivaregisterkind.Select(QHC.CmpEq("idivaregisterkind", idivaregisterkind))[0];
                if (IvaRegKind["registerclass"].ToString().ToUpper() == "A") Acquisto = true;
            }
            
            if (Acquisto)
                return "A";
            else
                return "V";

        }
        private void MostraNascondiCigCup() {
            DataRow Curr = DS.invoicedetail.Rows[0];
            if (Curr["idmankind"] == DBNull.Value) {
                grpCupCig.Visible = true;
            }
            else
                grpCupCig.Visible = false;
        }
        private void enableControls(bool abilita) {
            bool readOnly = !abilita;
            chkexception12.Enabled = abilita;
            chkmove12.Enabled = abilita;
            rdbBeniintra12.Enabled = abilita;
            rdbServiziintra12.Enabled = abilita;
            gBoxIvaKind.Enabled = abilita;
            gboxUPB.Enabled = abilita;
            gBoxupbIVA.Enabled = abilita;
            gboxclass1.Enabled = abilita;
            gboxclass2.Enabled = abilita;
            gboxclass3.Enabled = abilita;
            gboxCompetenza.Enabled = abilita;
            grpCausale.Enabled = abilita;
            grpRipartizioneCosti.Enabled = abilita;
            btnDocumentoIva.Enabled = abilita;
            gboxCompetenza.Enabled = abilita;
            grpRiga.Enabled = abilita;
            grpRigaContratto.Enabled = abilita;
            grpLiquidazioneIva.Enabled = abilita;
            gboxIntra.Enabled = abilita;
            grpServizi.Enabled = abilita;
            rdbBeni.Enabled = abilita;
            rdbServizi.Enabled = abilita;
            gboxva3.Enabled = abilita;
            gboxListino.Enabled = abilita;
            chkListDescription.Enabled = abilita;
            btnListino.Enabled = abilita;
            gboxComunicazioni.Enabled = abilita;
            grpCupCig.Enabled = abilita;    
            if (DS.invoicedetail.Rows.Count > 0)
            {
                string filter = Meta.QHC.CmpEq("idinvkind", DS.invoicedetail.Rows[0]["idinvkind"]);
                byte flag = CfgFn.GetNoNullByte(Meta.Conn.DO_READ_VALUE("invoicekind", filter, "flag"));


                if ((flag & 4) != 0) {
                    grpInvMain.Visible = true;
                }
                else
                {
                    grpInvMain.Visible = false;
                }
            }
            grpInvMain.Enabled = abilita;
            txtYinvMain.ReadOnly = readOnly;
            txtNinvMain.ReadOnly = readOnly;
            txtQuantitaConfezioni.ReadOnly = readOnly;
            txtImponibile.ReadOnly = readOnly;
            txtSconto.ReadOnly = readOnly;
            txtDescrizione.ReadOnly = readOnly;
            txtAppunti.ReadOnly = readOnly;
            txtDescrPadre.ReadOnly = readOnly;
            txtWeight.ReadOnly = readOnly;
            txtImpostaEUR.ReadOnly = readOnly;
            txtImpDeducEUR.ReadOnly = readOnly;
            txtListino.ReadOnly = readOnly;
            grpNoleggioLeasing.Enabled = abilita;
            grpDettaglioSpesometro.Enabled = abilita;
            cmbTipocessioneprestazione.Enabled = abilita;
            txtRiferimentoNormativo.ReadOnly = readOnly;
            grpPcc.Enabled = abilita;
            txtEsercizioImpegno.ReadOnly = readOnly;
            txtNumImpegno.ReadOnly = readOnly;
            txtEsercAxBudget.ReadOnly = readOnly;
            txtNumAxBudget.ReadOnly = readOnly;
            chkBollaDoganale.Enabled = abilita;
            chkSpeseAnticipateSpedizioniere.Enabled = abilita;
            txtCodiceBollettinoUnivoco.ReadOnly = readOnly;
            gboxCausaleBilancioEntrata.Enabled = abilita;
            gboxProfessionale.Enabled = abilita;
            grpBoxSiopeEP.Enabled = abilita;
        }

        private void CalcolaImponibileValuta()
        {
            //if (LeggiDati) Meta.GetFormData(true);
            DataRow Curr = DS.invoicedetail.Rows[0];

            try
            {
                double imponibile = CfgFn.GetNoNullDouble(Curr["taxable"]);
                double quantita = CfgFn.GetNoNullDouble(Curr["number"]);
                //double aliquota  = CfgFn.GetNoNullDouble(aliquota);
                double sconto = CfgFn.GetNoNullDouble(Curr["discount"]);
                double imponibiletot = CfgFn.RoundValuta((imponibile * quantita * (1 - sconto)));
                txtImponibileValuta.Text = imponibiletot.ToString("n");
            }
            catch
            {
                txtImponibileValuta.Text = "";
            }
        }

        private void CalcolaImportiEUR()
        {
           
            DataRow Curr = DS.invoicedetail.Rows[0];

            try
            {
                double tassocambio = CfgFn.GetNoNullDouble(Curr.GetParentRow("invoice_invoicedetail")["exchangerate"]);
                double imponibile   = CfgFn.GetNoNullDouble(Curr["taxable"]);
                double quantita     = CfgFn.GetNoNullDouble(Curr["number"]);
                //double aliquota   = CfgFn.GetNoNullDouble(aliquota);
                double sconto = CfgFn.GetNoNullDouble(Curr["discount"]);
                double imponibiletot = CfgFn.RoundValuta((imponibile * quantita * (1 - sconto)));
                double imponibiletotEUR = CfgFn.RoundValuta(imponibiletot * tassocambio);
                //double iva = CfgFn.GetNoNullDouble(Curr["tax"]);
                //double ivaEUR = CfgFn.RoundValuta(iva * tassocambio);
                //double impindeduc = CfgFn.GetNoNullDouble(Curr["unabatable"]);
                //double impindeducEUR = CfgFn.RoundValuta(impindeduc * tassocambio);

                txtImponibileEUR.Text = imponibiletotEUR.ToString("n");
                //txtImpostaEUR.Text = ivaEUR.ToString("n");
                //txtImpDeducEUR.Text = impindeducEUR.ToString("n");

            }
            catch
            {
                txtImponibileEUR.Text = "";
                //txtImpostaEUR.Text = "";
                //txtImpDeducEUR.Text = "";
            }

        }


        private void riempiOggetti(DataRow listRow)
        {
            txtListino.Text = (listRow != null) ? listRow["intcode"].ToString() : "";
            txtDescrizioneListino.Text = (listRow != null) ? listRow["description"].ToString() : "";
            txtCoeffConversione.Text = (listRow != null) ? listRow["unitsforpackage"].ToString() : "";

            HelpForm.SetComboBoxValue(cmbUnitaMisuraCS, listRow["idunit"]);
            HelpForm.SetComboBoxValue(cmbUnitaMisuraAcquisto, listRow["idpackage"]);
        }

        private void btnListino_Click(object sender, EventArgs e) {
            string filter = QHS.DoPar(QHS.AppOr(QHS.IsNull("validitystop"), QHS.CmpGe("validitystop", Meta.GetSys("datacontabile"))));
            MetaData Mlistino = MetaData.GetMetaData(this, "listview");
            Mlistino.FilterLocked = true;
            Mlistino.DS = DS.Clone();
            if (chkListDescription.Checked){
                FrmAskDescr FR = new FrmAskDescr(Meta.Dispatcher);
                DialogResult D = FR.ShowDialog(this);
                if (D != DialogResult.OK) return;
                if (FR.Selected != null){
                    object idlistclass = FR.Selected["idlistclass"];
                    filter = QHC.AppAnd(filter, QHC.CmpEq("idlistclass", FR.Selected["idlistclass"]));
                }
                if (FR.txtDescrizione.Text != ""){
                    string Description = FR.txtDescrizione.Text;
                    if (!Description.EndsWith("%")) Description += "%";
                    if (!Description.StartsWith("%")) Description = "%" + Description;
                    filter = QHC.AppAnd(filter, QHC.Like("description", Description));
                }
            }
            if (VeroTipoFatturaAV() == "A") {
                filter = QHS.AppAnd(filter, QHS.BitSet("flagvisiblekind", 1)); //bit 1: visibile nei c. passivi. BitSet confronta con <> 0
            }
            else {
                filter = QHS.AppAnd(filter, QHS.BitSet("flagvisiblekind", 2)); //bit 2: visibile nei c. attivi
            }
            DataRow Choosen = Mlistino.SelectOne("default", filter, "listview", null);
            if (Choosen == null) return;
            riempiOggetti(Choosen);

            return;
        }

        private void svuotaOggetti()
        {
            txtDescrizioneListino.Text = "";
            txtCoeffConversione.Text = "";

            if (cmbUnitaMisuraCS.SelectedIndex > 0)
            {
                cmbUnitaMisuraCS.SelectedIndex = -1;
            }
            if (cmbUnitaMisuraAcquisto.SelectedIndex > 0)
            {
                cmbUnitaMisuraAcquisto.SelectedIndex = -1;
            }

        }

       

        private void txtQuantita_Leave(object sender, EventArgs e)
        {
        }

        private void txtCoeffConversione_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtListino_TextChanged(object sender, EventArgs e) {
           

            return;
        }

        private void btnCasuale_Click(object sender, EventArgs e) {
            object idpccdebitstatus = DBNull.Value;
            string filter = "";
            if (cmbStatodelDebito.SelectedIndex > 0)
                idpccdebitstatus = cmbStatodelDebito.SelectedValue;
            if (idpccdebitstatus != DBNull.Value) {
                int maskorder = CfgFn.GetNoNullInt32(DS.pccdebitstatus.Select(QHC.CmpEq("idpccdebitstatus", idpccdebitstatus))[0]["flag"]);
                filter = "( flagstatus & " + QueryCreator.unquotedstrvalue(maskorder, true) + " <>0 )";
            }

            MetaData MCausali = MetaData.GetMetaData(this, "pccdebitmotive");
            MCausali.FilterLocked = true;
            MCausali.DS = DS.Clone();

            DataRow Choosen = MCausali.SelectOne("default", filter, "pccdebitmotive", null);
            if (Choosen == null)
                return;
            txtCodiceCasualePcc.Text = Choosen["idpccdebitmotive"].ToString();
            txtCausale.Text = Choosen["description"].ToString();
        }

        private void txtCodiceCasualePcc_Leave(object sender, EventArgs e) {
            if (txtCodiceCasualePcc.Text == "") {
                txtCausale.Text = "";
                return;
            }

            object idpccdebitstatus = DBNull.Value;
            string filter = "";
            if (cmbStatodelDebito.SelectedIndex > 0)
                idpccdebitstatus = cmbStatodelDebito.SelectedValue;
            if (idpccdebitstatus != DBNull.Value) {
                int maskorder = CfgFn.GetNoNullInt32(DS.pccdebitstatus.Select(QHC.CmpEq("idpccdebitstatus", idpccdebitstatus))[0]["flag"]);
                filter = "( flagstatus & " + QueryCreator.unquotedstrvalue(maskorder, true) + " <>0 )";
            }
            string idpccdebitmotive = txtCodiceCasualePcc.Text;
            if (!idpccdebitmotive.EndsWith("%"))
                idpccdebitmotive += "%";
            filter = GetData.MergeFilters(filter, QHS.Like("idpccdebitmotive", idpccdebitmotive));

            MetaData MCausali = MetaData.GetMetaData(this, "pccdebitmotive");
            MCausali.FilterLocked = true;
            MCausali.DS = DS.Clone();

            DataRow Choosen = MCausali.SelectOne("default", filter, "pccdebitmotive", null);
            if (Choosen == null)
                return;
            txtCodiceCasualePcc.Text = Choosen["idpccdebitmotive"].ToString();
            txtCausale.Text = Choosen["description"].ToString();
        }

        public void MetaData_AfterFill() {
            enableControls(false);
            MostraNascondiCigCup();
            CalcolaImponibileValuta();
            CalcolaImportiEUR();
            DataRow Curr = DS.invoicedetail.Rows[0];
            DataRow Invoice = Curr.GetParentRow("invoice_invoicedetail");
            if (Invoice["flagintracom"].ToString().ToUpper() == "N") {
                HideShowIntrastat(true);
            }
            else {
                HideShowIntrastat(false);
            }
            SetLabel();
            MostraCausalePCC();
            /* if (CfgFn.GetNoNullInt32(Invoice["flag"]) != 0) {
                 tabControl1.TabPages.Remove(tabComunicazioni);
             }*/
            string filterLx = QHS.AppAnd(QHS.CmpEq("idinvkind", Curr["idinvkind"]), QHS.CmpEq("yinv", Curr["yinv"]), QHS.CmpEq("ninv", Curr["ninv"]), QHS.CmpEq("rownum", Curr["rownum"]));
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.invoicedetaildeferred, null, filterLx, null, true);
        }
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            GetData.CacheTable(DS.mandatekind, null, "description", true);
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanCancel = false;
            Meta.CanSave = false;
            cmbInvKindMain.DataSource = DS.invoicekind1;
            cmbInvKindMain.DisplayMember = "description";
            cmbInvKindMain.ValueMember = "idinvkind";
            DataAccess.SetTableForReading(DS.invoicekind1, "invoicekind");


            DataAccess.SetTableForReading(DS.sorting1, "sorting");
            DataAccess.SetTableForReading(DS.sorting2, "sorting");
            DataAccess.SetTableForReading(DS.sorting3, "sorting");
            DataAccess.SetTableForReading(DS.expense_taxable, "expense");
            DataAccess.SetTableForReading(DS.expense_iva, "expense");
            DataAccess.SetTableForReading(DS.income_taxable, "income");
            DataAccess.SetTableForReading(DS.income_iva, "income");
			DataAccess.SetTableForReading(DS.upb_iva, "upb");
			DataAccess.SetTableForReading(DS.finmotive_income, "finmotive");
            GetData.CacheTable(DS.invoicekindregisterkind);
            GetData.CacheTable(DS.ivaregisterkind);

            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            string filterEsercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            DataTable tExpSetup = Conn.RUN_SELECT("config", "*", null,
                filterEsercizio, null, null, true);
            GetData.SetStaticFilter(DS.intrastatcode, filterEsercizio);

            gboxIntra.Tag = gboxIntra.Tag + "." + filterEsercizio;
            btnIntra.Tag = btnIntra.Tag + "." + filterEsercizio;

            if ((tExpSetup != null) && (tExpSetup.Rows.Count > 0)) {
                DataRow R = tExpSetup.Rows[0];
                object idsorkind1 = R["idsortingkind1"];
                object idsorkind2 = R["idsortingkind2"];
                object idsorkind3 = R["idsortingkind3"];
                CfgFn.SetGBoxClass(this, 1, idsorkind1);
                CfgFn.SetGBoxClass(this, 2, idsorkind2);
                CfgFn.SetGBoxClass(this, 3, idsorkind3);
                if (idsorkind1 == DBNull.Value && idsorkind2 == DBNull.Value && idsorkind3 == DBNull.Value) {
                    tabControl1.TabPages.Remove(tabAnalitico);
                }
            }
            int countList = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("list", null, "count(*)"));
            if (countList == 0) {
                gboxListino.Visible = false;
                //MakeSpaceFrom(gboxListino);
            }
            else {
                gboxListino.Visible = true;
            }

            DataAccess.SetTableForReading(DS.sorting_siopee, "sorting");
            DataAccess.SetTableForReading(DS.sorting_siopes, "sorting");
            object idsorkindS = Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", Meta.GetSys("codesorkind_siopespese")), "idsorkind");
            object idsorkindE = Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", Meta.GetSys("codesorkind_siopeentrate")), "idsorkind");
            GetData.SetStaticFilter(DS.sorting_siopee, QHS.CmpEq("idsorkind", idsorkindE));
            GetData.SetStaticFilter(DS.sorting_siopes, QHS.CmpEq("idsorkind", idsorkindS));
            
    }


        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (T == null)
                return;
            if (T.TableName == "intrastatcode" && Meta.DrawStateIsDone) {
                if (R != null && !Meta.IsEmpty) {
                    DataRow Curr = DS.invoicedetail.Rows[0];
                    HelpForm.SetComboBoxValue(cmbmeasure, R["idintrastatmeasure"]);
                    Curr["idintrastatmeasure"] = R["idintrastatmeasure"];
                }
            }
            if (T.TableName == "invoicekind") {

                if ((R == null) || (R["flag"] == DBNull.Value)) {
                    grpRiga.Visible = true;
                    grpRigaContratto.Visible = true;
                    return;
                }

                string AoV = VeroTipoFatturaAV();
                string AVAR = (CfgFn.GetNoNullByte(R["flag"]) & 4) != 0 ? "S" : "N";
                if (AVAR == "S") {
                    grpInvMain.Visible = true;
                }
                else {
                    grpInvMain.Visible = false;
                }


                if (AoV == "A") {
                    grpRiga.Visible = true;
                    grpRigaContratto.Visible = false;

                    txtEsercizioIva.Tag = "expense_iva.ymov";
                    txtNumeroIva.Tag = "expense_iva.nmov";
                    txtEsercizioImponibile.Tag = "expense_taxable.ymov";
                    txtNumImponibile.Tag = "expense_taxable.nmov";

                    lblPercIndeduc.Visible = true;
                    txtPercIndeduc.Visible = true;
                    lblIvaIndedEUR.Visible = true;
                    txtImpDeducEUR.Visible = true;
                }

                if (AoV == "V") {
                    grpRiga.Visible = false;
                    grpRigaContratto.Visible = true;

                    txtEsercizioIva.Tag = "income_iva.ymov";
                    txtNumeroIva.Tag = "income_iva.nmov";
                    txtEsercizioImponibile.Tag = "income_taxable.ymov";
                    txtNumImponibile.Tag = "income_taxable.nmov";

                    lblPercIndeduc.Visible = false;
                    txtPercIndeduc.Visible = false;
                    lblIvaIndedEUR.Visible = false;
                    txtImpDeducEUR.Visible = false;
                }
               ImpostaControlliSiope(AoV);
            }
        }

        public void ImpostaControlliSiope(string AoV) {
            if (AoV == "A") {
                txtCodSiope.Tag = "sorting_siopes.sortcode?x";
                txtDescSiope.Tag = "sorting_siopes.description";
                btnSiope.Tag = "manage.sorting_siopes.tree";
            }
            else {
                txtCodSiope.Tag = "sorting_siopee.sortcode?x";
                txtDescSiope.Tag = "sorting_siopee.description";
                btnSiope.Tag = "manage.sorting_siopee.tree";
            }

        }
        public void MetaData_AfterClear() {
            enableControls(true);
            txtEsercizio.Text = Meta.GetSys("esercizio").ToString();
            txtImponibileValuta.Text = "";
            txtImponibileEUR.Text = "";
            txtImpostaEUR.Text = "";
            txtImpDeducEUR.Text = "";
            grpInvMain.Visible = true;
            txtYinvMain.Text = "";
            txtNinvMain.Text = "";
            HideShowIntrastat(false);
            txtCausale.Text = "";
            DS.invoicedetaildeferred.Clear();
        }

        private void txtListino_Leave(object sender, EventArgs e) {
            if (Meta == null) return;
            if (!Meta.DrawStateIsDone) return;

            if (txtListino.Text == "") {
                svuotaOggetti();
                return;
            }
            if (txtListino.Text == lastCodice) return;


            string filter = QHS.DoPar(QHS.AppOr(QHS.IsNull("validitystop"), QHS.CmpGe("validitystop", Meta.GetSys("datacontabile"))));
            string IntCode = txtListino.Text;
            if (!IntCode.EndsWith("%")) IntCode += "%";
            filter = GetData.MergeFilters(filter, QHS.Like("intcode", IntCode));
            filter = QHS.AppAnd(filter, QHS.NullOrEq("active", "S"));
            if (VeroTipoFatturaAV() == "A") {
                filter = QHS.AppAnd(filter, QHS.BitSet("flagvisiblekind", 1)); //bit 1: visibile nei c. passivi. BitSet confronta con <> 0
            }
            else {
                filter = QHS.AppAnd(filter, QHS.BitSet("flagvisiblekind", 2)); //bit 2: visibile nei c. attivi
            }

            MetaData Mlistino = MetaData.GetMetaData(this, "listview");
            Mlistino.FilterLocked = true;
            Mlistino.DS = DS.Clone();

            DataRow Choosen = Mlistino.SelectOne("default", filter, "listview", null);
            if (Choosen == null) {
                txtListino.Focus();
                lastCodice = null;
                return;
            }

            riempiOggetti(Choosen);
        }

        private string lastCodice;
        private void txtListino_Enter(object sender, EventArgs e) {
            lastCodice = txtListino.Text;
        }

    }
}
