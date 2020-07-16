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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;

namespace estimatedetail_default {
    public partial class FrmEstimateDetail_Default : Form {
        MetaData Meta;
        DataAccess Conn;
        public FrmEstimateDetail_Default() {
            InitializeComponent();
        }
        
        CQueryHelper QHC;
        QueryHelper QHS;

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;

            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();

            GetData.CacheTable(DS.estimatekind, null, "description", true);
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanCancel = false;
            Meta.CanSave = false;
            DataAccess.SetTableForReading(DS.finmotive_income, "finmotive");
            DataAccess.SetTableForReading(DS.sorting1, "sorting");
            DataAccess.SetTableForReading(DS.sorting2, "sorting");
            DataAccess.SetTableForReading(DS.sorting3, "sorting");
            DataAccess.SetTableForReading(DS.income_imponibile, "income");
            DataAccess.SetTableForReading(DS.income_iva, "income");
            DataAccess.SetTableForReading(DS.accmotiveannulment, "accmotive");
            DataAccess.SetTableForReading(DS.upb_iva, "upb");
            //string filterEpOperation = QHS.CmpEq("idepoperation", "fatven");
            //DS.accmotiveapplied.ExtendedProperties[MetaData.ExtraParams] = filterEpOperation;
            //GetData.SetStaticFilter(DS.accmotiveapplied, filterEpOperation);
            DataTable tExpSetup = Conn.RUN_SELECT("config", "*", null,
                QHS.CmpEq("ayear", Meta.GetSys("esercizio")), null, null, true);
            if ((tExpSetup != null) && (tExpSetup.Rows.Count > 0))
            {
                DataRow R = tExpSetup.Rows[0];
                object idsorkind1 = R["idsortingkind1"];
                object idsorkind2 = R["idsortingkind2"];
                object idsorkind3 = R["idsortingkind3"];
                SetGBoxClass(1, idsorkind1);
                SetGBoxClass(2, idsorkind2);
                SetGBoxClass(3, idsorkind3);
                if (idsorkind1 == DBNull.Value && idsorkind2 == DBNull.Value && idsorkind3 == DBNull.Value) {
                    tabControl1.TabPages.Remove(tabAnalitico);
                }

                bool removeIvaTab = true;
                foreach (string COL in new string[] {"agencycode", "deferredexpensephase", "deferredincomephase",
                "flagpayment", "flagrefund", "idfinivapayment", "idfinivarefund", "idivapayperiodicity", "minpayment",
                "minrefund", "paymentagency", "refundagency"}) {
                    if (R[COL] == DBNull.Value) continue;
                    removeIvaTab = false;
                    break;
                }

                if (removeIvaTab) {
                    tabControl1.TabPages.Remove(tabFatturazione);
                }

            }
            DataAccess.SetTableForReading(DS.sorting_siope, "sorting");
            object idsorkind = Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", Meta.GetSys("codesorkind_siopeentrate")), "idsorkind");
            GetData.SetStaticFilter(DS.sorting_siope, QHS.CmpEq("idsorkind", idsorkind));

            SiopeObj = new siope_helper(this, txtCodSiope, txtDescSiope, btnSiope, grpBoxSiopeEP, false, DS.sorting_siope);
        }

        siope_helper SiopeObj;

        public void MetaData_AfterFill() {
            enableControls(false);
            CalcolaImponibileValuta();
            CalcolaImportiEUR();
            CalcolaResiduo(false);
        }

        public void MetaData_AfterClear() {
            enableControls(true);
            txtEsercizio.Text = Meta.GetSys("esercizio").ToString();
            TxtImponibileValutaTot.Text = "";
            TxtIvaValutaTot.Text = "";
            //txtTaxRate.Text = "";
            txtImponibileEUR.Text = "";
            txtIvaEUR.Text = "";
        }

        private void enableControls(bool abilita) {
            bool readOnly = !abilita;

            gBoxIvaKind.Enabled = abilita;
            gBoxValuta.Enabled = abilita;
            //gboxUPB.Enabled = abilita;
            btnUPB.Enabled = abilita;
            buttonupbIVA.Enabled = abilita;
            txtUPB.ReadOnly = !abilita;
            txtUPBiva.ReadOnly = !abilita;
            gboxclass1.Enabled = abilita;
            gboxclass2.Enabled = abilita;
            gboxclass3.Enabled = abilita;
            checkBox1.Enabled = abilita;
            grpCausale.Enabled = abilita;
            grpBoxSiopeEP.Enabled = abilita;
            grpCausaleAnnullamento.Enabled = abilita;
            btnContrattoAttivo.Enabled = abilita;

            txtRowNum.ReadOnly = readOnly;
            txtIDGroup.ReadOnly = readOnly;
            txtCredDeb.ReadOnly = readOnly;
            txtQuantita.ReadOnly = readOnly;
            txtImponibile.ReadOnly = readOnly;
            txtSconto.ReadOnly = readOnly;
            txtDescrizione.ReadOnly = readOnly;
            txtAppunti.ReadOnly = readOnly;
            txtDescrPadre.ReadOnly = readOnly;
            gboxCompetenza.Enabled = abilita;
            grpRipartizioneRicavi.Enabled = abilita;
            txtEsercIxBudget.ReadOnly = readOnly;
            txtNumIxBudget.ReadOnly = readOnly;
            gboxListino.Enabled = abilita;
            txtCodiceBollettino.ReadOnly = readOnly;
            txtNumBollettino.ReadOnly = readOnly;
            txtScadenza.ReadOnly = readOnly;
            gboxCausaleBilancioEntrata.Enabled = abilita;
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

        decimal NInvoiced;
        bool NInvoicedEvalued = false;
        void CalcolaResiduo(bool LeggiDati) {
        if (Meta.InsertMode) {
        txtResiduo.Text = "";
        return;
        }
        if (LeggiDati) Meta.GetFormData(true);
        DataRow Curr = DS.estimatedetail.Rows[0];
        decimal N = CfgFn.GetNoNullDecimal(Curr["number"]);
        if (!NInvoicedEvalued) {
        string filter = QueryCreator.WHERE_KEY_CLAUSE(Curr, DataRowVersion.Default, true);
        NInvoiced = CfgFn.GetNoNullDecimal(
            Conn.DO_READ_VALUE("estimatedetailtoinvoice", filter, "invoiced"));
        }
        decimal INVOICED = NInvoiced;
        decimal residual = N - INVOICED;

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

        private void CalcolaImponibileValuta() {
            DataRow Curr = DS.estimatedetail.Rows[0];

            try {
                double imponibile = CfgFn.GetNoNullDouble(Curr["taxable"]);
                double quantita = CfgFn.GetNoNullDouble(Curr["number"]);
                double sconto = CfgFn.GetNoNullDouble(Curr["discount"]);
                double imponibiletot = CfgFn.RoundValuta((imponibile * quantita * (1 - sconto)));
                TxtImponibileValutaTot.Text = HelpForm.StringValue(imponibiletot, "x.y.fixed.2...1");//         imponibiletot.ToString("n");
            }
            catch {
                TxtImponibileValutaTot.Text = "";
            }
        }

        private void CalcolaImportiEUR() {
            DataRow Curr = DS.estimatedetail.Rows[0];
            DataRow rEstimate = Curr.GetParentRow("estimate_estimatedetail");
            DataRow rIvaKind = Curr.GetParentRow("ivakindestimatedetail");
            if (rIvaKind == null || rEstimate == null) {
                txtImponibileEUR.Text = "";
                txtIvaEUR.Text = "";
                return;
            }

            try {
                double tassocambio = CfgFn.GetNoNullDouble(rEstimate["exchangerate"]);
                double aliquota = CfgFn.GetNoNullDouble(rIvaKind["rate"]);
                double imponibile = CfgFn.GetNoNullDouble(Curr["taxable"]);
                double quantita = CfgFn.GetNoNullDouble(Curr["number"]);
                double sconto = CfgFn.GetNoNullDouble(Curr["discount"]);
                double imponibiletot = CfgFn.RoundValuta((imponibile * quantita * (1 - sconto)));
                double imponibiletotEUR = CfgFn.RoundValuta(imponibiletot * tassocambio);
                double iva = CfgFn.GetNoNullDouble(Curr["tax"]);
                double ivaEUR = CfgFn.RoundValuta(iva * tassocambio);

                txtImponibileEUR.Text = HelpForm.StringValue(imponibiletotEUR,
                   "x.y.fixed.2...1");
                //imponibiletotEUR.ToString("n");
                txtIvaEUR.Text = HelpForm.StringValue(ivaEUR,
                    "x.y.fixed.2...1"); //                .ToString("n");
            }
            catch {
                txtImponibileEUR.Text = "";
                txtIvaEUR.Text = "";
            }

        }

        private void riempiOggetti(DataRow listRow) {
            txtListino.Text = (listRow != null) ? listRow["intcode"].ToString() : "";
            txtDescrizioneListino.Text = (listRow != null) ? listRow["description"].ToString() : "";
        }

        private void svuotaOggetti() {
            txtDescrizioneListino.Text = "";
        }

        private void txtListino_TextChanged(object sender, EventArgs e) {
            

            return;
        }

        private void btnListino_Click(object sender, EventArgs e) {
            string filter = "";
            MetaData Mlistino = MetaData.GetMetaData(this, "listview");
            if (!Meta.IsEmpty) {
                Meta.GetFormData(true);
            }
            Mlistino.FilterLocked = true;
            Mlistino.DS = DS.Clone();
            if (chkListDescription.Checked) {
                FrmAskDescr FR = new FrmAskDescr(Meta.Dispatcher);
                DialogResult D = FR.ShowDialog(this);
                if (D != DialogResult.OK)
                    return;
                if (FR.Selected != null) {
                    object idlistclass = FR.Selected["idlistclass"];
                    filter = QHC.AppAnd(filter, QHC.CmpEq("idlistclass", FR.Selected["idlistclass"]));
                }

                if (FR.txtDescrizione.Text != "") {
                    string Description = FR.txtDescrizione.Text;
                    if (!Description.EndsWith("%"))
                        Description += "%";
                    if (!Description.StartsWith("%"))
                        Description = "%" + Description;
                    filter = QHC.AppAnd(filter, QHC.Like("description", Description));
                }
            }
            filter = QHS.AppAnd(filter, QHS.BitSet("flagvisiblekind", 2)); 
            DataRow Choosen = Mlistino.SelectOne("default", filter, "listview", null);
            if (Choosen == null)
                return;
            riempiOggetti(Choosen);

            return;
        }

        private void txtListino_Leave(object sender, EventArgs e) {
            if (txtListino.Text == "") {
                svuotaOggetti();
                return;
            }
            if (txtListino.Text == lastCodice) return;
            if (!Meta.IsEmpty) {
                Meta.GetFormData(true);
            }
            string filter = "";
            string IntCode = txtListino.Text;
            if (!IntCode.EndsWith("%"))
                IntCode += "%";
            filter = GetData.MergeFilters(filter, QHS.Like("intcode", IntCode));
            filter = QHS.AppAnd(filter, QHS.BitSet("flagvisiblekind", 2)); //bit 2: visibile nei c. attivi
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