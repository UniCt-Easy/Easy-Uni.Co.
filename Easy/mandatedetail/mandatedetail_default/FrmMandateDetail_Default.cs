
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;

namespace mandatedetail_default {
    public partial class FrmMandateDetail_Default : Form {
        MetaData Meta;
        DataAccess Conn;
        CQueryHelper QHC;
        QueryHelper QHS;

        public FrmMandateDetail_Default() {
            InitializeComponent();
        }

        bool abilitaLotti(object idmankind) {
            DataRow[] r = DS.mandatekind.Select(QHC.CmpEq("idmankind", idmankind));
            if (r.Length == 0) return true;
            int flag = CfgFn.GetNoNullInt32(r[0]["flag"]) & 1;
            if (flag == 0) return true;

            return false;
        }
        bool abilitaConsip(object idmankind) {
            DataRow[] r = DS.mandatekind.Select(QHC.CmpEq("idmankind", idmankind));
            if (r.Length == 0) return true;
            int flag = CfgFn.GetNoNullInt32(r[0]["flag"]) & 2;
            if (flag == 0) return true;

            return false;
        }
        bool abilitaMagazzino(object idmankind) {
            DataRow[] r = DS.mandatekind.Select(QHC.CmpEq("idmankind", idmankind));
            if (r.Length == 0) return true;
            int flag = CfgFn.GetNoNullInt32(r[0]["assetkind"]) & 8;
            if (flag != 0) return true;

            return false;
        }
        bool abilitaFattura(object idmankind) {
            DataRow[] r = DS.mandatekind.Select(QHC.CmpEq("idmankind", idmankind));
            if (r.Length == 0) return true;
            string flag = r[0]["linktoinvoice"].ToString().ToUpper();
            if (flag =="S")  return true;

            return false;
        }


        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();

            GetData.CacheTable(DS.mandatekind, null, "description", true);
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanCancel = false;
            //Meta.CanSave = false;
            DataAccess.SetTableForReading(DS.sorting1, "sorting");
            DataAccess.SetTableForReading(DS.sorting2, "sorting");
            DataAccess.SetTableForReading(DS.sorting3, "sorting");
            DataAccess.SetTableForReading(DS.expense_imponibile, "expense");
            DataAccess.SetTableForReading(DS.expense_iva, "expense");
            DataAccess.SetTableForReading(DS.accmotiveannulment, "accmotive");
            DataAccess.SetTableForReading(DS.upb_iva, "upb");
            //string filterEpOperation = QHS.CmpEq("idepoperation", "fatacq"); 
            //DS.accmotiveapplied.ExtendedProperties[MetaData.ExtraParams] = filterEpOperation; 
            //GetData.SetStaticFilter(DS.accmotiveapplied, filterEpOperation);
            DataTable tExpSetup = Conn.RUN_SELECT("config", "*", null,
                QHS.CmpEq("ayear", Meta.GetSys("esercizio")), null, null, true);
            if ((tExpSetup != null) && (tExpSetup.Rows.Count > 0))
            {
                DataRow r = tExpSetup.Rows[0];
                object idsorkind1 = r["idsortingkind1"];
                object idsorkind2 = r["idsortingkind2"];
                object idsorkind3 = r["idsortingkind3"];
                SetGBoxClass(1, idsorkind1);
                SetGBoxClass(2, idsorkind2);
                SetGBoxClass(3, idsorkind3);
                if (idsorkind1 == DBNull.Value && idsorkind2 == DBNull.Value && idsorkind3 == DBNull.Value) {
                    tabControl1.TabPages.Remove(tabAnalitico);
                }
            }

            int countList = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("list", null, "count(*)"));
            if (countList == 0){
                gboxListino.Visible = false;
                //MakeSpaceFrom(gboxListino);
            }
            else{
                gboxListino.Visible = true;
            }
            DataAccess.SetTableForReading(DS.sorting_siope, "sorting");
            object idsorkind = Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", Meta.GetSys("codesorkind_siopedprds")), "idsorkind");
            GetData.SetStaticFilter(DS.sorting_siope, QHS.CmpEq("idsorkind", idsorkind));

            SiopeObj = new siope_helper(this, txtCodSiope, txtDescSiope, btnSiope, grpBoxSiopeEP, true, DS.sorting_siope);
        }
        siope_helper SiopeObj;
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
        void VisualizzaNascondiMagazzino(bool visualizza) {
            if (visualizza) {
                if (!tabControl1.TabPages.Contains(tabMagazzino)) {
                    tabControl1.TabPages.Insert(6, tabMagazzino);

                }
            }
            else {
                if (tabControl1.TabPages.Contains(tabMagazzino)) {
                    tabControl1.TabPages.Remove(tabMagazzino);

                }
            }
        }
        void VisualizzaNascondiLotti(bool visualizza) {
            lblcig.Visible = visualizza;
            txtcig.Visible = visualizza;
        }
        public void MetaData_BeforeFill() {
            if (Meta.FirstFillForThisRow) {
                VisualizzaNascondiMagazzino(abilitaMagazzino(DS.mandatedetail.Rows[0]["idmankind"]));
                VisualizzaNascondiLotti(abilitaLotti(DS.mandatedetail.Rows[0]["idmankind"]));
                VisualizzaNascondiFattura(abilitaFattura(DS.mandatedetail.Rows[0]["idmankind"]));
            }
        }
        public void MetaData_AfterFill() {
            
            enableControls(false);
            SetLabel();
            CalcolaImponibileValuta();
            CalcolaImportiEUR();
            CalcolaResiduo(false);
            MostraCausalePCC();
        }

        private void MostraCausalePCC() {
            if (Meta.IsEmpty)
                return;
            DataRow Curr = DS.mandatedetail.Rows[0];

            if (Curr["idpccdebitmotive"] != DBNull.Value) {
                txtCausale.Text = DS.pccdebitmotive.Select(QHC.CmpEq("idpccdebitmotive", Curr["idpccdebitmotive"]))[0]["description"].ToString();
            }
        }

        decimal NInvoiced;
        bool NInvoicedEvalued = false;
        void CalcolaResiduo(bool LeggiDati) {
        if (Meta.InsertMode) {
            txtResiduo.Text = "";
        return;
        }
        if (LeggiDati) Meta.GetFormData(true);
        DataRow Curr = DS.mandatedetail.Rows[0];
        decimal Npackage = CfgFn.GetNoNullDecimal(Curr["npackage"]);
        if (!NInvoicedEvalued) {
        string filter = QueryCreator.WHERE_KEY_CLAUSE(Curr, DataRowVersion.Default, true);
        NInvoiced = CfgFn.GetNoNullDecimal(
            Conn.DO_READ_VALUE("mandatedetailtoinvoice", filter, "invoiced"));
        }
        decimal INVOICED = NInvoiced;
        decimal residual = Npackage - INVOICED;

        if (NInvoiced >= 0) {
            txtNInvoiced.Text = NInvoiced.ToString("n");
        }
        else {
            txtNInvoiced.Text = "";
        }

        if (residual >= 0) {
            txtResiduo.Text = residual.ToString("n");
        }
        else {
            txtResiduo.Text = "";
        }
        }

        void VisualizzaNascondiFattura(bool visualizza) {
            if (visualizza) {
                if (!tabControl1.TabPages.Contains(tabFatturazione)) {
                    tabControl1.TabPages.Insert(3, tabFatturazione);

                }
            }
            else {
                if (tabControl1.TabPages.Contains(tabFatturazione)) {
                    tabControl1.TabPages.Remove(tabFatturazione);

                }
            }
        }

        void ForzaTipoIvaDaTipoContratto(bool forzaTipoIva)
        {
            if (forzaTipoIva)
            {
                gBoxIvaKind.Enabled = false;
            }
            else
            {
                gBoxIvaKind.Enabled = true; ;
            }
        }

        public void MetaData_AfterClear() {
            VisualizzaNascondiMagazzino(true);
            VisualizzaNascondiLotti(true);
            VisualizzaNascondiFattura(true);
            ForzaTipoIvaDaTipoContratto(true);
            enableControls(true);
            txtEsercizio.Text = Meta.GetSys("esercizio").ToString();
            txtImponibileEUR.Text = "";
            txtIvaEUR.Text = "";
            txtImpDeducEUR.Text = "";
            TxtImponibileValutaTot.Text = "";
            txtCausale.Text = "";
        }

        private void enableControls(bool abilita) {
            bool readOnly = !abilita;

            gBoxIvaKind.Enabled = abilita;
            chkPromiscuo.Enabled = abilita;
            //gboxUPB.Enabled = abilita;
            btnUPB.Enabled = abilita;
            txtUPB.ReadOnly = !abilita;
            buttonupbIVA.Enabled = abilita;
            txtUPBiva.ReadOnly = !abilita;
            gboxclass1.Enabled = abilita;
            gboxclass2.Enabled = abilita;
            gboxclass3.Enabled = abilita;
            grpRipartizioneCosti.Enabled = abilita;
            checkBox1.Enabled = abilita;
            grpTipoBene.Enabled = abilita;
            grpInventario.Enabled = abilita;
            gboxCompetenza.Enabled = abilita;
            grpCausale.Enabled = abilita;
            grpBoxSiopeEP.Enabled = abilita;
            grpCausaleAnnullamento.Enabled = abilita;
            btnContrattoPassivo.Enabled = abilita;
            gboxAttivita.Enabled = abilita;
            gboxva3.Enabled = abilita;
            gboxListino.Enabled = abilita;
            chkListDescription.Enabled = abilita;
            gBoxMagazzino.Enabled = abilita;
            btnListino.Enabled = abilita;

            txtRowNum.ReadOnly = readOnly;
            txtIDGroup.ReadOnly = readOnly;
            txtCredDeb.ReadOnly = readOnly;
            txtQuantitaConfezioni.ReadOnly = readOnly;
            txtImponibile.ReadOnly = readOnly;
            txtSconto.ReadOnly = readOnly;
            txtDescrizione.ReadOnly = readOnly;
            txtAppunti.ReadOnly = readOnly;
            txtStart.ReadOnly = readOnly;
            txtStop.ReadOnly = readOnly;
            txtDescrPadre.ReadOnly = readOnly;
            txtIvaEUR.ReadOnly = readOnly;
            txtImpDeducEUR.ReadOnly = readOnly;
            txtApplierAnnotations.ReadOnly = readOnly;
            txtListino.ReadOnly = readOnly;
            txtCupCode.ReadOnly = readOnly;
            txtcig.ReadOnly = readOnly;
            chkunload.Enabled = abilita;
            txtStore.ReadOnly = readOnly;
            grpPcc.Enabled = abilita;
            txtEsercIxBudget.ReadOnly = readOnly;
            txtNumIxBudget.ReadOnly = readOnly;
        }
        void SetGBoxClass(int num, object sortingkind)
        {
            string nums = num.ToString();
            if (sortingkind == DBNull.Value)
            {
                GroupBox G = (GroupBox)GetCtrlByName("gboxclass" + nums);
                G.Visible = false;
            }
            else
            {
                string filter = QHS.CmpEq("idsorkind", sortingkind);
                GetData.SetStaticFilter(DS.Tables["sorting" + nums], filter);
                GroupBox gboxclass = (GroupBox)GetCtrlByName("gboxclass" + nums);
                Button btnCodice = (Button)GetCtrlByName("btnCodice" + nums);
                string title = Conn.DO_READ_VALUE("sortingkind", filter, "description").ToString();
                gboxclass.Text = title;
                gboxclass.Tag = "AutoManage.txtCodice" + nums + ".tree." + filter;
                btnCodice.Tag = "manage.sorting" + nums + ".tree." + filter;
                DS.Tables["sorting" + nums].ExtendedProperties[MetaData.ExtraParams] = filter;
            }
        }
        object GetCtrlByName(string Name)
        {
            System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
            if (Ctrl == null) return null;
            //if (!typeof(Label).IsAssignableFrom(Ctrl.FieldType)) return null;                         
            //Label L =  (Label) Ctrl.GetValue(this);                        
            //return L;
            return Ctrl.GetValue(this);
        }

        private void CalcolaImportiEUR() {
            DataRow Curr = DS.mandatedetail.Rows[0];
            DataRow rMandate = Curr.GetParentRow("mandate_mandatedetail");
            double tassocambio = 0;
            if (rMandate == null) {
                MessageBox.Show("L'utente non ha i diritti di accesso al contratto passivo", "Errore");
                tassocambio = CfgFn.GetNoNullDouble(Conn.DO_READ_VALUE("mandate",
                    QHS.MCmp(Curr, new string[] { "yman", "nman" }), "exchangerate"));

            }
            else {
                tassocambio = CfgFn.GetNoNullDouble(rMandate["exchangerate"]);
            }
			try
			{
				double imponibile= CfgFn.GetNoNullDouble(Curr["taxable"]);
				double quantita  = CfgFn.GetNoNullDouble(Curr["npackage"]);
				//double aliquota  = CfgFn.GetNoNullDouble(Curr["taxrate"]);
				double sconto    = CfgFn.GetNoNullDouble(Curr["discount"]);
				double imponibiletot = CfgFn.RoundValuta((imponibile*quantita*(1-sconto)));
				double imponibiletotEUR = CfgFn.RoundValuta(imponibiletot*tassocambio);			
                //double iva        = CfgFn.GetNoNullDouble(Curr["tax"]);
                //double ivaEUR     = CfgFn.RoundValuta(iva*tassocambio);
                //double impindeduc=	CfgFn.GetNoNullDouble(Curr["unabatable"]);
                //double impindeducEUR=	CfgFn.RoundValuta(impindeduc*tassocambio);

                txtImponibileEUR.Text = HelpForm.StringValue(imponibiletotEUR,
                    "x.y.fixed.2...1");
                    //imponibiletotEUR.ToString("n");
                    //txtIvaEUR.Text = HelpForm.StringValue(ivaEUR,
                    //    "x.y.fixed.2...1"); //                .ToString("n");
                    //txtImpDeducEUR.Text = HelpForm.StringValue(impindeducEUR,
                    //    "x.y.fixed.2...1");//                .ToString("n");
			}
			catch
			{
				txtImponibileEUR.Text="";
                //txtIvaEUR.Text ="";	
                //txtImpDeducEUR.Text="";
			}			


        }

        private void CalcolaImponibileValuta() {
            DataRow Curr = DS.mandatedetail.Rows[0];

            try {
                double imponibile = CfgFn.GetNoNullDouble(Curr["taxable"]);
                double quantita = CfgFn.GetNoNullDouble(Curr["npackage"]);
                //double aliquota  = CfgFn.GetNoNullDouble(Curr["taxrate"]);
                double sconto = CfgFn.GetNoNullDouble(Curr["discount"]);
                double imponibiletot = CfgFn.RoundValuta((imponibile * quantita * (1 - sconto)));
                TxtImponibileValutaTot.Text = HelpForm.StringValue(imponibiletot, "x.y.fixed.2...1");//         imponibiletot.ToString("n");
            }
            catch {
                TxtImponibileValutaTot.Text = "";
            }
        }

        private void SetLabel () {
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.mandatedetail.Rows[0];
            object idpackage = Curr["idpackage"];
            object idunit = Curr["idunit"];

            if (idpackage == null || idpackage == DBNull.Value) {
                lblidpackage.Text = "Q.tà";
                //lblImportoUnitario.Text = "Importo unitario";
            }
            else {
                object UnitaAcquisto = Conn.DO_READ_VALUE("package", QHS.CmpEq("idpackage", idpackage), "description");
                if (UnitaAcquisto == null) UnitaAcquisto = DBNull.Value;
                lblidpackage.Text = UnitaAcquisto.ToString();//                "N." + UnitaAcquisto;
                //lblImportoUnitario.Text = "Importo (per " + UnitaAcquisto + ")";
            }

            if (idunit == null || idunit == DBNull.Value){
                lblidunit.Text = "Totale quantità Ordinata";
            }
            else{
                string UnitaCarico = Conn.DO_READ_VALUE("unit", QHS.CmpEq("idunit", idunit), "description").ToString();
                lblidunit.Text = UnitaCarico;//                "N." + UnitaCarico;
            }

        }

        private void btnListino_Click (object sender, EventArgs e) {
            string filter = "";
            MetaData Mlistino = MetaData.GetMetaData(this, "listview");
            Mlistino.FilterLocked = true;
            Mlistino.DS = DS.Clone();
            if (chkListDescription.Checked)
            {
                FrmAskDescr FR = new FrmAskDescr(Meta.Dispatcher);
                DialogResult D = FR.ShowDialog(this);
                if (D != DialogResult.OK) return;
                if (FR.Selected != null)
                {
                    object idlistclass = FR.Selected["idlistclass"];
                    filter = QHC.AppAnd(filter, QHC.CmpEq("idlistclass", FR.Selected["idlistclass"]));
                }

                if (FR.txtDescrizione.Text != "")
                {
                    string Description = FR.txtDescrizione.Text;
                    if (!Description.EndsWith("%")) Description += "%";
                    if (!Description.StartsWith("%")) Description = "%" + Description;
                    filter = QHC.AppAnd(filter, QHC.Like("description", Description));
                }
            }
            filter = QHS.AppAnd(filter, QHS.NullOrEq("active", "S"));
            filter = QHS.AppAnd(filter, QHS.BitSet("flagvisiblekind", 1)); //bit 1: visibile nei c. passivi. BitSet confronta con <> 0
            DataRow Choosen = Mlistino.SelectOne("default", filter, "listview", null);
            if (Choosen == null) return;
            riempiOggetti(Choosen);

            return;
        }

        private void riempiOggetti (DataRow listRow) {
            txtListino.Text = (listRow != null) ? listRow["intcode"].ToString() : "";
            txtDescrizioneListino.Text = (listRow != null) ? listRow["description"].ToString() : "";
            txtCoeffConversione.Text = (listRow != null) ? listRow["unitsforpackage"].ToString() : "";
            txtPrezzounitarioListino.Text = (listRow != null) ? listRow["price"].ToString() : "";
            HelpForm.SetComboBoxValue(cmbUnitaMisuraCS, listRow["idunit"]);
            HelpForm.SetComboBoxValue(cmbUnitaMisuraAcquisto, listRow["idpackage"]);
        }


        private void svuotaOggetti () {
            txtDescrizioneListino.Text = "";
            txtCoeffConversione.Text = "";
            txtPrezzounitarioListino.Text = "";
            if (cmbUnitaMisuraCS.SelectedIndex > 0) {
                cmbUnitaMisuraCS.SelectedIndex = -1;
            }
            if (cmbUnitaMisuraAcquisto.SelectedIndex > 0) {
                cmbUnitaMisuraAcquisto.SelectedIndex = -1;
            }

        }
        private string lastCodice;
        private void txtListino_Enter(object sender, EventArgs e) {
            lastCodice = txtListino.Text;
        }

        private void txtListino_Leave (object sender, EventArgs e) {
            if (Meta == null) return;
            if (!Meta.DrawStateIsDone) return;
            if (txtListino.Text == "") {
                svuotaOggetti();
                return;
            }
            if (txtListino.Text == lastCodice) return;

            //if (DS.mandatedetail.Rows.Count == 0) return;
            //if (!Meta.DrawStateIsDone) return;

            //string filter = QHS.DoPar(QHS.AppOr(QHS.IsNull("validitystop"), QHS.CmpGe("validitystop", Meta.GetSys("datacontabile"))));
            string filter = "";
            string IntCode = txtListino.Text;
            if (!IntCode.EndsWith("%")) IntCode += "%";
            filter = GetData.MergeFilters(filter, QHS.Like("intcode", IntCode));
            filter = QHS.AppAnd(filter, QHS.NullOrEq("active", "S"));
            filter = QHS.AppAnd(filter, QHS.BitSet("flagvisiblekind", 1)); //bit 1: visibile nei c. passivi. BitSet confronta con <> 0
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

        private void txtNumConfezioni_Leave (object sender, EventArgs e) {
            if (txtQuantitaConfezioni.Text == "") {
                txtQuantita.Text = "";
                return;
            }

            double npackage = CfgFn.GetNoNullDouble(txtQuantitaConfezioni.Text);
            int unitsforpackage = CfgFn.GetNoNullInt32(txtCoeffConversione.Text);
            if (unitsforpackage == 0)
                unitsforpackage = 1;
            double number = npackage * unitsforpackage;
            if (number > 0)
                txtQuantita.Text = HelpForm.StringValue(number, "x.y");
            else txtQuantita.Text = "";
        }

        private void txtCoeffConversione_TextChanged (object sender, EventArgs e) {
            if (txtCoeffConversione.Text == "") {
                // Se cancello il Coeff. di Conversione, la q.tà totale sarà uguale alla q.tà per l'imballo.
                double npackage = CfgFn.GetNoNullDouble(txtQuantitaConfezioni.Text);
                if (npackage > 0)
                    txtQuantita.Text = HelpForm.StringValue(npackage, "x.y");
                else txtQuantita.Text = "";
                return;
            }
            else {
                double npackage = CfgFn.GetNoNullDouble(txtQuantitaConfezioni.Text);
                int unitsforpackage = CfgFn.GetNoNullInt32(txtCoeffConversione.Text);
                double number = npackage * unitsforpackage;
                if (number > 0)
                    txtQuantita.Text = HelpForm.StringValue(number, "x.y");
                else txtQuantita.Text = "";
            }
        }

        private void txtListino_TextChanged (object sender, EventArgs e) {
          

            return;

        }

        private void lblidpackage_Click (object sender, EventArgs e) {

        }

        private void txtQuantitaConfezioni_TextChanged (object sender, EventArgs e) {

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

        
    }
}
