/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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
using AskInfo;

namespace expensetaxcorrige_default {
    public partial class FrmExpenseTaxCorrige_Default : Form {
        MetaData Meta;
        bool inChiusura = false;
        CQueryHelper QHC;
        QueryHelper QHS;

        public FrmExpenseTaxCorrige_Default() {
            InitializeComponent();
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            object idSer = DBNull.Value;
            if (Meta.ExtraParameter != null) {
                idSer = Meta.ExtraParameter;
            }
            else {
                MessageBox.Show("E' necessario inserire il tipo prestazione prima di aprire questa maschera.");
            }

            rendiReadOnly();

            string fInc = QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")),
                QHS.CmpEq("nphase", Meta.GetSys("maxincomephase")));
            GetData.SetStaticFilter(DS.incomeview, fInc);

            string fExp = QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")),
                QHS.CmpEq("nphase", Meta.GetSys("maxexpensephase")));
            GetData.SetStaticFilter(DS.expenseview, fExp);
        }

        /// <summary>
        /// Metodo che rende read only gli oggetti non modificabili del form
        /// </summary>
        private void rendiReadOnly() {
            DataRow ExpTaxParent = Meta.SourceRow;

            string solaLettura = (ExpTaxParent.Table.ExtendedProperties["readonly"] != null)
                ? ExpTaxParent.Table.ExtendedProperties["readonly"].ToString().ToUpper()
                : "S";

            if (solaLettura == "S") {
                gBoxGenerale.Enabled = false;
                gBoxDip.Enabled = false;
                gBoxAmm.Enabled = false;
            }
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (T.TableName == "tax") {
                if (!Meta.DrawStateIsDone) return;
                DataRow Curr = DS.expensetaxcorrige.Rows[0];
                if (R == null) {
                    grpCity.Visible = false;
                    grpRegion.Visible = false;
                    Curr["idcity"] = DBNull.Value;
                    Curr["idfiscaltaxregion"] = DBNull.Value;
                }
                else {
                    DataRow[] Tax = DS.tax.Select(QHC.CmpEq("taxcode", R["taxcode"]));
                    if (Tax.Length > 0) {
                        DataRow rTax = Tax[0];
                        string geo = rTax["geoappliance"].ToString().ToUpper();
                        switch (geo) {
                            case "C": {
                                    grpCity.Visible = true;
                                    grpRegion.Visible = false;
                                    Curr["idfiscaltaxregion"] = DBNull.Value;
                                    HelpForm.SetComboBoxValue(cmbRegioneFiscale, -1);
                                    break;
                                }
                            case "R": {
                                    grpCity.Visible = false;
                                    grpRegion.Visible = true;
                                    Curr["idcity"] = DBNull.Value;
                                    txtGeoComune0101.Text = "";
                                    txtProvincia.Text = "";
                                    break;
                                }
                            default: {
                                    grpCity.Visible = false;
                                    grpRegion.Visible = false;
                                    Curr["idcity"] = DBNull.Value;
                                    Curr["idfiscaltaxregion"] = DBNull.Value;
                                    txtGeoComune0101.Text = "";
                                    txtProvincia.Text = "";
                                    HelpForm.SetComboBoxValue(cmbRegioneFiscale, -1);
                                    break;
                                }
                        }
                    }
                }
            }
        }

        public void MetaData_AfterFill() {
            if ((Meta.FirstFillForThisRow) && (DS.expensetaxcorrige.Rows.Count > 0)) {
                DataRow Curr = DS.expensetaxcorrige.Rows[0];
                if (CfgFn.GetNoNullInt32(Curr["taxcode"]) == 0) {
                    grpCity.Visible = false;
                    grpRegion.Visible = false;
                }
                else {
                    DataRow[] Tax = DS.tax.Select(QHC.CmpEq("taxcode", Curr["taxcode"]));
                    if (Tax.Length > 0) {
                        DataRow rTax = Tax[0];
                        string geo = rTax["geoappliance"].ToString().ToUpper();
                        switch (geo) {
                            case "C": {
                                    grpCity.Visible = true;
                                    grpRegion.Visible = false;
                                    break;
                                }
                            case "R": {
                                    grpCity.Visible = false;
                                    grpRegion.Visible = true;
                                    break;
                                }
                            default: {
                                    grpCity.Visible = false;
                                    grpRegion.Visible = false;
                                    break;
                                }
                        }
                    }
                }
            }

            abilitaGrpMovimento(true);
        }

        private void abilitaGrpMovimento(bool dontclear) {
            if (DS.expensetaxcorrige.Rows.Count == 0) return;
            decimal importoDip = CfgFn.GetNoNullDecimal(
                HelpForm.GetObjectFromString(typeof(decimal), txtImportoDip.Text, "expensetaxcorrige.employamount"));
            decimal importoAmm = CfgFn.GetNoNullDecimal(
                HelpForm.GetObjectFromString(typeof(decimal), txtImportoAmm.Text, "expensetaxcorrige.adminamount"));

            object ytaxpay = HelpForm.GetObjectFromString(typeof(short), txtEsercLiq.Text,
                       "expensetaxcorrige.ytaxpay");
            if (ytaxpay != DBNull.Value) dontclear = true;

            // Le condizioni per abilitare disabilitare i groupbox per la movimentazione finanziaria sono le seguenti:
            // 1. Se importoDip > 0 entrata attiva; spesa disattiva
            // in quanto vuol dire che devo chiedere i soldi al percipiente e liquido la correzione positiva con lo strumento liquidazione ritenute
            // 2. Se importoDip < 0 spesa attiva; entrata da valutare
            // in quanto devo versare al percipiente altri soldi
            // 2.bis. se (importoDip + importoAmm) < 0 e il riferimento alla liquidazione Ë NULL entrata attiva
            // in quanto vuol dire che non sono riuscito ancora a compensare in fase di liquidazione e devo collegare ad una
            // entrata il movimento.

            gboxentrata.Enabled = false;
            gboxspesa.Enabled = false;
            decimal importo = importoDip + importoAmm;

            if (importoDip > 0) {
                if (!dontclear) txtNumeroMovimentoS.Text = "";
                if (!dontclear) txtEsercizioMovimentoS.Text = "";
                DataRow Curr = DS.expensetaxcorrige.Rows[0];
                if (!dontclear) Curr["linkedidexp"] = DBNull.Value;

                gboxentrata.Enabled = true;
                gboxspesa.Enabled = false;
            }

            if (importoDip < 0) {
                gboxspesa.Enabled = true;
            }
            if ((importo < 0) && ((ytaxpay == null) || (ytaxpay == DBNull.Value))) {
                gboxentrata.Enabled = true;
            }
            else {
                if (!dontclear) txtNumeroMovimentoE.Text = "";
                if (!dontclear) txtEsercizioMovimentoE.Text = "";
                DataRow Curr = DS.expensetaxcorrige.Rows[0];
                if (!dontclear) Curr["linkedidinc"] = DBNull.Value;

                //gboxentrata.Enabled = false;
            }
        }

        private void btnSelectMovE_Click(object sender, EventArgs e) {
            selezionaMovimento("E");
        }

        private void btnSelectMovS_Click(object sender, EventArgs e) {
            selezionaMovimento("S");
        }

        /// <summary>
        /// Metodo che consente la selezione del movimento finanziario
        /// </summary>
        /// <param name="E_S"></param>
        private void selezionaMovimento(string E_S) {
            if (Meta.IsEmpty) return;
            Meta.GetFormData(true);

            string filterPhase = (E_S == "E")
                ? QHC.CmpEq("nphase", Meta.GetSys("maxincomephase"))
                : QHC.CmpEq("nphase", Meta.GetSys("maxexpensephase"));

            DataRow Curr = DS.expensetaxcorrige.Rows[0];
            decimal importo = (E_S == "E")
                ? -(CfgFn.GetNoNullDecimal(Curr["employamount"]) +
                CfgFn.GetNoNullDecimal(Curr["adminamount"]))
                : CfgFn.GetNoNullDecimal(Curr["employamount"])
                + CfgFn.GetNoNullDecimal(Curr["adminamount"]);

            //DataTable tUpb = DataAccess.RUN_SELECT(Meta.Conn, "upb", "*", null, QHS.CmpEq("idupb", "0001"),
            //    null, null, true);

            //string flag = (E_S == "E") ? QHS.BitClear("flag", 0) : QHS.BitSet("flag", 0);
            //DataTable tFinView = DataAccess.RUN_SELECT(Meta.Conn, "finview", "*", null,
            //    QHS.AppAnd(QHS.CmpEq("idupb", "0001"), QHS.CmpEq("ayear", Meta.GetSys("esercizio")), flag),
            //    null, null, true);

            //FrmAskFase F = new FrmAskFase(E_S, importo, tUpb, tFinView, Meta.Dispatcher, Meta.Conn);
            //if (F.ShowDialog() != DialogResult.OK) return;
            FrmAskInfo fInfo = new FrmAskInfo(Meta, E_S, true)
                .EnableManagerSelection(true)
                .AllowNoManagerSelection(true)
                .EnableFinSelection(true)
                .EnableUPBSelection(true)
                .AllowNoUpbSelection(true)
                .AllowNoFinSelection(true)
                .AllowNoManagerSelection(true)
                .EnableFilterAvailable(importo);
            fInfo.Text = "Impostazione filtro per ricerca movimento";
            fInfo.gboxUPB.Text = "Selezionare l'UPB  (opzionale)";
            fInfo.gboxBilAnnuale.Text = "Selezionare la voce di bilancio (opzionale)";
            if (fInfo.ShowDialog() != DialogResult.OK) return;




            int selectedfase = (E_S == "E")
                ? CfgFn.GetNoNullInt32(Meta.GetSys("maxincomephase"))
                : CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));

            string filter = "";
            string filterUpb = QHS.CmpEq("idupb", "0001");
            string filterFin = "";
            string filterMan = "";

            if (selectedfase > 0) filter = GetData.MergeFilters(filter, QHS.CmpEq("nphase", selectedfase));
            if (fInfo.GetUPB() != DBNull.Value) {
                filterUpb = QHS.CmpEq("idupb", fInfo.GetUPB());
            }
            if (fInfo.GetFin() != DBNull.Value) {
                filterFin = QHS.CmpEq("idfin", fInfo.GetFin());
            }

            if (fInfo.GetManager() != DBNull.Value) {
                filterMan = QHS.CmpEq("idman", fInfo.GetManager());
            }
            
            filter = GetData.MergeFilters(filter, filterUpb);
            if (filterFin != "") {
                filter = GetData.MergeFilters(filter, filterFin);
            }
            if (filterMan != "") {
                filter = GetData.MergeFilters(filter, filterMan);
            }
            if (importo > 0) {
                filter = GetData.MergeFilters(filter, QHS.CmpGe("curramount", importo));
            }
            else {
                filter = GetData.MergeFilters(filter, QHS.CmpGt("curramount", 0));
            }                                    

            string tName = (E_S == "E") ? "income" : "expense";
            MetaData E = Meta.Dispatcher.Get(tName);
            E.FilterLocked = true;
            E.DS = DS.Clone();
            DataRow Choosen = E.SelectOne("default", filter, tName, null);
            if (Choosen == null) {
                return;
            }
            string Linkedfield = (E_S == "E") ? "linkedidinc" : "linkedidexp";
            string SourceField = (E_S == "E") ? "idinc" : "idexp";
            Curr[Linkedfield] = Choosen[SourceField];
            string vName = (E_S == "E") ? "incomeview" : "expenseview";
            DS.Tables[vName].Clear();
            Meta.Conn.RUN_SELECT_INTO_TABLE(DS.Tables[vName], null,
                QHS.AppAnd(QHS.CmpEq(SourceField, Curr[Linkedfield]), QHS.CmpEq("ayear", Meta.GetSys("esercizio"))),
                null, true);
            Meta.FreshForm(false);
        }

        private void txtNumeroMovimentoE_Leave(object sender, EventArgs e) {
            if (inChiusura) return;
            if (txtNumeroMovimentoE.Text.Trim() != "") {
                DoChooseCommand((Control)sender, "E");
                return;
            }
            //if txtNumentrata is empty:
            if (Meta.IsEmpty) return;
            ClearEntrata(false);	
        }

        private void txtNumeroMovimentoS_Leave(object sender, EventArgs e) {
            if (inChiusura) return;
            if (txtNumeroMovimentoS.Text.Trim() != "") {
                DoChooseCommand((Control)sender, "S");
                return;
            }
            //if txtNumentrata is empty:
            if (Meta.IsEmpty) return;
            ClearSpesa(false);	
        }

        private void ClearEntrata(bool ClearEsercizio) {
            txtNumeroMovimentoE.Text = "";
            if (ClearEsercizio) txtEsercizioMovimentoE.Text = "";
            if (Meta.IsEmpty) return;
            DS.expensetaxcorrige.Rows[0]["linkedidinc"] = DBNull.Value;
            DS.incomeview.Clear();
        }

        private void ClearSpesa(bool ClearEsercizio) {
            txtNumeroMovimentoS.Text = "";
            if (ClearEsercizio) txtEsercizioMovimentoS.Text = "";
            if (Meta.IsEmpty) return;
            DS.expensetaxcorrige.Rows[0]["linkedidexp"] = DBNull.Value;
            DS.expenseview.Clear();
        }

        private void DoChooseCommand(Control sender, string E_S) {
            string mycommand = (E_S == "E")
                ? "choose.incomeview.movimentoentrata" : "choose.expenseview.movimentospesa";

            string filter1 = "";
            TextBox txtEserc = (E_S == "E")
                ? txtEsercizioMovimentoE : txtEsercizioMovimentoS;
            if (txtEserc.Text.Trim() != "") {
                filter1 = QHS.CmpEq("ymov", txtEserc.Text);
            }

            TextBox txtNum = (E_S == "E")
                ? txtNumeroMovimentoE : txtNumeroMovimentoS;
            if (txtNum.Text.Trim() != "") {
                filter1 = QHS.AppAnd(filter1, QHS.CmpEq("nmov", txtNum.Text));
            }

            DataRow Curr = DS.expensetaxcorrige.Rows[0];
            // Da cambiare
            decimal importo = (E_S == "E")
                ? -(CfgFn.GetNoNullDecimal(Curr["employamount"]) +
                CfgFn.GetNoNullDecimal(Curr["adminamount"]))
                : CfgFn.GetNoNullDecimal(Curr["employamount"]) +
                CfgFn.GetNoNullDecimal(Curr["adminamount"]);
            string fAmount = "";
            if (importo > 0) {
                fAmount = QHS.CmpGe("curramount", importo);
            }
            else {
                fAmount = QHS.CmpGt("curramount", 0);
            }
            filter1 = QHS.AppAnd(filter1, fAmount);

            object faseMax = (E_S == "E") ? Meta.GetSys("maxincomephase") : Meta.GetSys("maxexpensephase");
            filter1 = QHS.AppAnd(filter1, QHS.CmpEq("nphase", faseMax));

            if (filter1 != "") mycommand += "." + filter1;
            if (!MetaData.Choose(this, mycommand)) {
                if (sender != null) sender.Focus();
            }
        }

        private void txtImportoDip_Leave(object sender, EventArgs e) {
            if (inChiusura) return;
            abilitaGrpMovimento(false);
        }

        private void txtImportoAmm_Leave(object sender, EventArgs e) {
            if (inChiusura) return;
            abilitaGrpMovimento(false);
        }
    }
}