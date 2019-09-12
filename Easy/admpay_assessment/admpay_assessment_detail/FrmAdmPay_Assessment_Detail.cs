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
using AskInfo;
using metadatalibrary;
using funzioni_configurazione;

namespace admpay_assessment_detail {
    public partial class FrmAdmPay_Assessment_Detail : Form {
        bool InChiusura = false;
        MetaData Meta;
        string lastUpbFin = "";
        object lastIdInc = DBNull.Value;
        decimal importoResiduo;
        DataTable tAdmPayIncome;
        string filterOnReg;
        public FrmAdmPay_Assessment_Detail() {
            InitializeComponent();
        }
        CQueryHelper QHC;
        QueryHelper QHS;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            string filterEsercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            string filter = QHS.AppAnd(filterEsercizio, QHS.BitClear("flag", 0));
            GetData.SetStaticFilter(DS.incomeview, filterEsercizio);
            GetData.SetStaticFilter(DS.finview, filter);
            GetData.CacheTable(DS.incomephase, null, "nphase", true);
            grpBilancio.Tag += "." + filter;
            btnBilancio.Tag += "." + filter;

            tAdmPayIncome = DataAccess.CreateTableByName(Meta.Conn, "admpay_income", "*");
            GetData.SetSorting(DS.incomephase, "nphase");
            if (Meta.EditMode) {
                DataRow CurrRow = Meta.SourceRow;
                string f = QHS.CmpKey(CurrRow);
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tAdmPayIncome, null, f, null, true);
                string f_incphase = calcolaFiltroSuIncomePhase();
                if (f_incphase != null) {
                    GetData.SetStaticFilter(DS.incomephase, f_incphase);
                }
            }
        }



        public void MetaData_AfterActivation() {
            if (DS.admpay_assessment.Rows.Count == 0) return;
            impostaFilterOnReg();
            manageSezMovimento();

            DataRow CurrRow = DS.admpay_assessment.Rows[0];
            importoResiduo = CfgFn.GetNoNullDecimal(CurrRow["amount"]);
            lastUpbFin = CurrRow["idupb"].ToString() + "§" + CurrRow["idfin"].ToString();
            lastIdInc = CurrRow["idinc"];
        }

        /// <summary>
        /// Metodo che riempie la tabella INCOMEPHASE in base ai meta movimenti associati alla impegnativa
        /// </summary>
        private string calcolaFiltroSuIncomePhase() {
            // Nel caso in cui la tabella dei meta movimenti sia nulla o vuota o abbia un solo meta movimento
            // allora vengono prese tutte le fasi di spesa
            if ((tAdmPayIncome == null) || (tAdmPayIncome.Rows.Count <= 1)) {
                return null;
            }

            int nAnagrafica = 0;
            int currAnagrafica = 0;
            int prevAnagrafica = 0;
            foreach (DataRow r in tAdmPayIncome.Select(null, "idreg")) {
                currAnagrafica = CfgFn.GetNoNullInt32(r["idreg"]);
                if (currAnagrafica != prevAnagrafica) nAnagrafica++;
                prevAnagrafica = currAnagrafica;
            }
            int faseMax = 0;
            // Se i movimenti associati all'impegnativa hanno anagrafiche differenti, potrò avere solamente fasi
            // di entrata senza anagrafica
            if (nAnagrafica <= 1) return null;
            faseMax = CfgFn.GetNoNullInt32(Meta.GetSys("incomeregphase")) - 1;
            return QHS.CmpLe("nphase", faseMax);
        }

        private void impostaFilterOnReg() {
            if (tAdmPayIncome.Rows.Count == 1) {
                object idreg = tAdmPayIncome.Rows[0]["idreg"];
                filterOnReg = QHS.NullOrEq("idreg", idreg);
                return;
            }
            if (tAdmPayIncome.Rows.Count > 1) {
                int nAnagrafica = 0;
                int currAnagrafica = 0;
                int prevAnagrafica = 0;
                object firstNotNullIdreg = null;
                foreach (DataRow r in tAdmPayIncome.Select(null, "idreg")) {
                    currAnagrafica = CfgFn.GetNoNullInt32(r["idreg"]);
                    if (currAnagrafica != prevAnagrafica) {
                        if (currAnagrafica != 0) firstNotNullIdreg = r["idreg"];
                        nAnagrafica++;
                    }
                    prevAnagrafica = currAnagrafica;

                }

                if ((nAnagrafica == 1) && (firstNotNullIdreg != null)) {
                    filterOnReg = QHS.NullOrEq("idreg", firstNotNullIdreg);
                }
            }
        }

        private void manageSezMovimento() {
            if (DS.incomephase.Rows.Count <= 1) {
                EnableDisableParteEntrata(false);
                lblWarning.Visible = true;
                chkEntrata.Enabled = false;
            }
            else {
                EnableDisableParteEntrata(true);
                lblWarning.Visible = false;
                chkEntrata.Enabled = true;
            }
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (Meta.IsEmpty) return;
            if (T.TableName == "upb") {
                object idupb = "0001";
                if (R != null) {
                    idupb = R["idupb"];
                }
                MetaData.AutoInfo AI;
                AI = Meta.GetAutoInfo(txtCodiceBilancio.Name);
                string filter = QHS.CmpEq("idupb", idupb);
                if (AI != null) AI.startfilter = filter;
                DS.finview.ExtendedProperties[MetaData.ExtraParams] = filter;
            }
            if (T.TableName == "finview") {
                DataRow Curr = DS.admpay_assessment.Rows[0];
                if (R != null) {
                    object currUpb = Curr["idupb"];
                    object currFin = R["idfin"];
                    string currUpbFin = currUpb + "§" + currFin;
                    if (lastUpbFin != currUpbFin) {
                        ricalcolaImporto(R["availableprevision"]);
                    }
                    lastUpbFin = currUpbFin;
                }
                else {
                    lastUpbFin = Curr["idupb"].ToString() + "§";
                }
            }
            if (T.TableName == "incomeview") {
                if (R != null) {
                    ricalcolaImporto(R["available"]);
                }
            }
        }

        public void MetaData_AfterFill() {
            if (Meta.FirstFillForThisRow) {
                fillFinGroupWithoutUPB();
                ImpostaCheckEntrata();
            }
        }

        private void fillFinGroupWithoutUPB() {
            if (DS.admpay_assessment.Rows.Count == 0) return;
            DataRow Curr = DS.admpay_assessment.Rows[0];
            if (Curr["idupb"] != DBNull.Value) return;
            if (Curr["idfin"] == DBNull.Value) return;
            object idupb = "0001";
            string f = QHC.AppAnd(QHC.CmpEq("idupb", idupb), QHC.CmpEq("idfin", Curr["idfin"]));
            DataRow[] Bil = DS.finview.Select(f);
            if (Bil.Length == 0) {
                Meta.Conn.RUN_SELECT_INTO_TABLE(DS.finview, null, f, null, true);
                Bil = DS.finview.Select(f);
                if (Bil.Length == 0) return;
            }
            
            txtCodiceBilancio.Text = Bil[0]["codefin"].ToString();
            txtDenominazioneBilancio.Text = Bil[0]["title"].ToString();
        }

        /// <summary>
        /// Metodo che assegna all'importo dell'accertamento o la previsione principale disponibile della coppia UPB-Bilancio
        /// scelto o il disponibile del movimento di entrata scelto
        /// </summary>
        /// <param name="disponibile">Importo disponibile da assegnare all'accertamento</param>
        private void ricalcolaImporto(object disponibile) {
            if (Meta.IsEmpty) return;
            if (DS.admpay_assessment.Rows.Count == 0) return;

            decimal importo = CfgFn.GetNoNullDecimal(disponibile);
            // Se l'importo che viene suggerito è superiore al residuo del pagamento stipendi allora inserisco
            // proprio il residuo del pagamento stipendi
            if (importo > importoResiduo) importo = importoResiduo;
            decimal importoAccertamento = CfgFn.GetNoNullDecimal(
                HelpForm.GetObjectFromString(typeof(decimal), txtImporto.Text, txtImporto.Tag.ToString()));
            if ((Meta.EditMode) && (importoAccertamento != importo)) {
                DialogResult dr = MessageBox.Show(this, "Attenzione! Procedo a cambiare l'importo dell'accertamento?", "Attenzione!",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (dr != DialogResult.Yes) return;
            }
            txtImporto.Text = importo.ToString("c");
            DataRow Curr = DS.admpay_assessment.Rows[0];
            Curr["amount"] = importo;
        }

        private void btnEntrata_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            Meta.GetFormData(true);
            DataTable Fasi2 = DS.incomephase.Copy();

            string filterPhase = QHC.AppOr(QHC.CmpEq("nphase", Meta.GetSys("maxincomephase")),
                QHC.CmpLt("nphase", Meta.GetSys("incomefinphase")));
            foreach (DataRow ToDel in Fasi2.Select(filterPhase)) {
                ToDel.Delete();
            }
            Fasi2.AcceptChanges();

            DataRow Curr = DS.admpay_assessment.Rows[0];
            decimal importo = CfgFn.GetNoNullDecimal(Curr["amount"]);
            var f = new FrmAskInfo(Meta, "E", true).SetUPB("0001").EnableManagerSelection(false);
            if (importo > 0) f.EnableFilterAvailable(importo);

            f.allowSelectPhase("Seleziona la fase del movimento a cui collegare il pagamento degli stipendi");            
            if (f.ShowDialog(this) != DialogResult.OK) return;
            var selectedfase = Convert.ToInt32(f.GetFaseMovimento());
            string filter = "";
            string filterUpb = QHS.CmpEq("idupb", "0001");
            string filterFin = "";
            if (selectedfase > 0) filter = GetData.MergeFilters(filter, QHS.CmpEq("nphase", selectedfase));
            // Aggiunta filtro dell'UPB e del Bilancio
            if (f.GetUPB()!= DBNull.Value) {
                filterUpb = QHS.CmpEq("idupb", f.GetUPB());
                
                if (f.GetFin() != DBNull.Value) {
                    filterFin = QHS.CmpEq("idfin", f.GetFin());
                }
            }
            filter = GetData.MergeFilters(filter, filterUpb);
            if (filterFin != "") {
                filter = GetData.MergeFilters(filter, filterFin);
            }

            filter = GetData.MergeFilters(filter, importo > 0 ? QHS.CmpGe("available", importo) : QHS.CmpGt("available", 0));

            int faseScelta = CfgFn.GetNoNullInt32(f.GetFaseMovimento());
            int faseRegistry = CfgFn.GetNoNullInt32(Meta.GetSys("expenseregphase"));
            if (faseScelta >= faseRegistry) {
                filter = QHS.AppAnd(filter, filterOnReg);
            }

            MetaData E = Meta.Dispatcher.Get("income");
            E.FilterLocked = true;
            E.DS = DS.Clone();
            DataRow Choosen = E.SelectOne("default", filter, "income", null);
            if (Choosen == null) {
                lastIdInc = DBNull.Value;
                return;
            }
            Curr["idinc"] = Choosen["idinc"];
            if (!lastIdInc.Equals(Choosen["idinc"])) {
                ricalcolaImporto(Choosen["available"]);
            }
            lastIdInc = Choosen["idinc"];
            DS.incomeview.Clear();
            Meta.Conn.RUN_SELECT_INTO_TABLE(DS.incomeview, null,
                QHS.AppAnd(QHS.CmpEq("idinc", Curr["idinc"]), QHS.CmpEq("ayear", Meta.GetSys("esercizio"))),
                null, true);
            Meta.FreshForm(false);
        }

        private void btnBilancio_Click(object sender, System.EventArgs e) {
            string filter;

            int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            string filteridfin = QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.BitClear("flag", 0));
            object idupb =  Meta.GetAutoField(txtUPB);
            //Il filtro sull'UPB c'è sempre
            if (idupb!=DBNull.Value && idupb!=null) {
                filter = QHS.CmpEq("idupb", idupb);
            }
            else {
                filter = QHS.CmpEq("idupb", "0001");
            }
            filter = QHS.AppAnd(filteridfin, filter);

            //Aggiunge eventualmente il filtro sul disponibile
            if (chkFilterAvailable.Checked) {
                decimal currval = 0;

                if (txtImporto.Text.Trim() != "") {
                    currval = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(
                        typeof(decimal), txtImporto.Text, "x.y.c"));
                }

                filter = GetData.MergeFilters(filter, QHS.CmpGe("availableprevision", currval));
            }

            string filteroperativo = "(idfin in (SELECT idfin from finusable where " +
                QHS.CmpEq("ayear", Meta.GetSys("esercizio")) + "))";
            if (chkListTitle.Checked) {
                FrmAskDescr FR = new FrmAskDescr(0);
                DialogResult D = FR.ShowDialog(this);
                if (D != DialogResult.OK) return;
                filter = GetData.MergeFilters(filter, QHS.Like("title", "%" + FR.txtDescrizione.Text + "%"));
                filter = GetData.MergeFilters(filter, filteroperativo);
                MetaData.DoMainCommand(this, "choose.finview.default." + filter);
                return;
            }
            DS.finview.ExtendedProperties[MetaData.ExtraParams] = filter;
            MetaData.DoMainCommand(this, "manage.finview.treeeupb");
        }

        private void chkEntrata_CheckedChanged(object sender, EventArgs e) {
            if (chkEntrata.Checked) {
                EnableDisable(false);
                if (Meta.IsEmpty) return;
                DataRow R = DS.admpay_assessment.Rows[0];
                if ((R["idfin"] != DBNull.Value) ||
                    (R["idupb"] != DBNull.Value)) {
                    if (MessageBox.Show("Per abilitare la selezione del movimento di entrata è necessario annullare le altre " +
                        "attribuzioni su questo pagamento stipendi. Proseguo?", "Conferma",
                        MessageBoxButtons.OKCancel) != DialogResult.OK) {
                        chkEntrata.Checked = false;
                        return;
                    }
                    lastUpbFin = "";
                    R["idfin"] = DBNull.Value;
                    R["idupb"] = DBNull.Value;
                    DS.finview.Clear();
                    txtCodiceBilancio.Text = "";
                    txtDenominazioneBilancio.Text = "";
                    Meta.SetAutoField(DBNull.Value, txtUPB);                    
                    return;
                }
                lastUpbFin = "";
                return;
            }
            if (Meta.IsEmpty) return;

            EnableDisable(true);

            DataRow RR = DS.admpay_assessment.Rows[0];

            if (RR["idinc"] != DBNull.Value) {
                if (MessageBox.Show("Per abilitare la selezione delle attribuzioni normali su questa operazione è necessario annullare il collegamento al movimento di entrata " +
                    ". Proseguo?", "Conferma",
                    MessageBoxButtons.OKCancel) != DialogResult.OK) {
                    chkEntrata.Checked = true;
                    return;
                }
                lastIdInc = DBNull.Value;
                RR["idinc"] = DBNull.Value;
                DS.incomeview.Clear();
                cmbFaseEntrata.SelectedIndex = 0;
                txtEserc.Text = "";
                txtNum.Text = "";
            }
            lastIdInc = DBNull.Value;
        }

        void DisableAll() {
            EnableDisableParteNormale(false);
            EnableDisableParteEntrata(false);
        }

        void EnableDisableParteEntrata(bool enable) {
            txtEserc.ReadOnly = !enable;
            txtNum.ReadOnly = !enable;
            cmbFaseEntrata.Enabled = enable;
            btnEntrata.Enabled = enable;

        }
        void EnableDisableParteNormale(bool enable) {
            btnBilancio.Enabled = enable;
            btnUPB.Enabled = enable;
            txtUPB.Enabled = enable;
            txtCodiceBilancio.ReadOnly = !enable;
        }

        void EnableDisable(bool parteNormale) {
            EnableDisableParteNormale(parteNormale);
            EnableDisableParteEntrata(!parteNormale);
        }

        /// <summary>
        /// Abilita/disabilita il checkbox Entrata e la parte di attribuzione bilancio/idinc
        /// </summary>
        void ImpostaCheckEntrata() {
            if (Meta.IsEmpty) {
                EnableDisable(true);
                gboxNormale.Visible = true;
                gboxEntrata.Visible = false;
                chkEntrata.Visible = false;
                return;
            }
            chkEntrata.Visible = true;
            gboxNormale.Visible = true;
            gboxEntrata.Visible = true;
            chkEntrata.Visible = true;

            chkEntrata.Visible = true;

            DataRow R = DS.admpay_assessment.Rows[0];
            if (R["idinc"] != DBNull.Value)
                chkEntrata.Checked = true;
            else
                chkEntrata.Checked = false;
            chkEntrata_CheckedChanged(null, null);
        }

        private void txtEserc_Leave(object sender, EventArgs e) {
            if (InChiusura) return;

            string esercentrata = txtEserc.Text.Trim();
            if (esercentrata == "") {
                MetaData.Choose(this, "choose.expenseview.unknown.clear");
                return;
            }

            //if txtEserc is not Empty:
            if (Meta.IsEmpty) return;

            if (DS.incomeview.Rows.Count > 0) {
                if (esercentrata == DS.incomeview.Rows[0]["ymov"].ToString())
                    return;
                else {
                    ClearEntrata(false);
                    return;
                }
            }	
        }

        private void txtNum_Leave(object sender, EventArgs e) {
            if (InChiusura) return;
            if (txtNum.Text.Trim() != "") {
                DoChooseCommand((Control)sender);
                return;
            }
            //if txtNumentrata is empty:
            if (Meta.IsEmpty) return;
            ClearEntrata(false);	
        }

        private void ClearEntrata(bool ClearEsercizio) {
            txtNum.Text = "";
            if (ClearEsercizio) txtEserc.Text = "";
            if (Meta.IsEmpty) return;
            DS.admpay_assessment.Rows[0]["idinc"] = 0;
            DS.incomeview.Clear();
        }

        private void DoChooseCommand(Control sender) {
            string mycommand = "choose.incomeview.movimentoentrata";
            string filter1 = Meta.myHelpForm.GetSpecificCondition(gboxEntrata.Controls, "incomeview");
            DataRow Curr = DS.admpay_assessment.Rows[0];
            decimal importo = CfgFn.GetNoNullDecimal(Curr["amount"]);
            string fAmount = "";
            if (importo > 0) {
                fAmount = QHS.CmpGe("available", importo);
            }
            else {
                fAmount = QHS.CmpGt("available", 0);
            }
            filter1 = QHS.AppAnd(filter1, fAmount);

            filter1 = QHS.AppAnd(filter1, fAmount);

            if (cmbFaseEntrata.SelectedIndex > 0) {
                int faseScelta = CfgFn.GetNoNullInt32(cmbFaseEntrata.SelectedValue);
                int faseRegistry = CfgFn.GetNoNullInt32(Meta.GetSys("incomeregphase"));
                if (faseScelta >= faseRegistry) {
                    filter1 = QHS.AppAnd(filter1, filterOnReg);
                }
            }

            if (filter1 != "") mycommand += "." + filter1;
            if (!MetaData.Choose(this, mycommand)) {
                if (sender != null) sender.Focus();
            }
        }
    }
}