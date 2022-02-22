
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;
using admpay_assessment_choose;

namespace admpay_income_default {
    public partial class FrmAdmPay_Income_Default : MetaDataForm {
        MetaData Meta;
        public FrmAdmPay_Income_Default() {
            InitializeComponent();
            DS.admpay_incomesorted.ExtendedProperties["gridmaster"] = "sortingkind";
        }

        CQueryHelper QHC;
        QueryHelper QHS;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            string filterYAdmPay = QHS.CmpEq("yadmpay", Meta.GetSys("esercizio"));
            GetData.SetStaticFilter(DS.admpay_income, filterYAdmPay);
            string filterEsercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.SetStaticFilter(DS.finview, filterEsercizio);
            GetData.SetStaticFilter(DS.incomeview, filterEsercizio);
            GetData.SetSorting(DS.sortingkind, "description");
            GetData.CacheTable(DS.sortingkind, QHS.IsNotNull("nphaseincome"), "description", false);
            PostData.MarkAsTemporaryTable(DS.admpay_assessmentview, false);
            GetData.DenyClear(DS.admpay_assessmentview);
        }

        public void DisplayMember_Accertamento(string filter)
        {
            if (Meta.IsEmpty) return;
            DS.admpay_assessmentview.Clear();
            GetData.MarkToAddBlankRow(DS.admpay_assessmentview);
            GetData.Add_Blank_Row(DS.admpay_assessmentview);
            cmbAccertamento.DataSource = null;

            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.admpay_assessmentview, null, filter, null, true);// da commentare
            cmbAccertamento.DataSource = DS.admpay_assessmentview;
            cmbAccertamento.DisplayMember = "!nassessment_description";
            cmbAccertamento.ValueMember = "nassessment";
            cmbAccertamento.SelectedIndex = -1;
            foreach (DataRow R in DS.admpay_assessmentview.Rows)
            {
                if (CfgFn.GetNoNullInt32(R["nassessment"]) == 0)
                {
                    R["!nassessment_description"] = DBNull.Value;

                }
                else
                {
                    R["!nassessment_description"] = R["nassessment"].ToString() + " - " + R["description"].ToString();
                }
            }
            DS.admpay_assessmentview.AcceptChanges();
        }
        public void MetaData_AfterActivation() {
            btnInsertClass.BackColor = formcolors.GridButtonBackColor();
            btnInsertClass.ForeColor = formcolors.GridButtonForeColor();
            btnEditClass.BackColor = formcolors.GridButtonBackColor();
            btnEditClass.ForeColor = formcolors.GridButtonForeColor();
            btnDelClass.BackColor = formcolors.GridButtonBackColor();
            btnDelClass.ForeColor = formcolors.GridButtonForeColor();
        }

        public void MetaData_BeforeFill() {
            PostData.MarkAsTemporaryTable((DataTable)cmbAccertamento.DataSource, false);

            if (DS.admpay_income.Rows.Count == 0) return;
            CalcolaTotaliClassificazioni();

            DataRow Curr = DS.admpay_income.Rows[0];
            if (Meta.FirstFillForThisRow) {
                string filter = QHS.MCmp(Curr, new string[] { "yadmpay", "nadmpay" });
                DisplayMember_Accertamento(filter);
            }
        }

        public void MetaData_AfterFill() {
            if (Meta.FirstFillForThisRow) {
                btnAccertamento.Enabled = true;
            }

            DataRow CurrSorKind = HelpForm.GetLastSelected(DS.sortingkind);
            if (CurrSorKind != null) {
                string f = QHC.CmpEq("!idsorkind", CurrSorKind["idsorkind"]);
                DS.admpay_incomesorted.ExtendedProperties["CustomParentRelation"] = f;
            }
        }

        public void MetaData_AfterClear() {
            btnAccertamento.Enabled = false;
            ((DataTable)(cmbAccertamento.DataSource)).Clear();
        }

        public void MetaData_BeforeRowSelect(DataTable T, DataRow R) {
            if (Meta.DrawStateIsDone && T.TableName == "sortingkind") {
                if (R != null) {
                    string f = QHC.CmpEq("!idsorkind", R["idsorkind"]);
                    DS.admpay_incomesorted.ExtendedProperties["CustomParentRelation"] = f;
                }
            }
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if ((T.TableName == "sortingkind") && Meta.DrawStateIsDone) {
                ManageTipoClassMovimentiRowChanged(
                    GetImportoPerClassificazione(), R);
                return;
            }
            if (T.TableName == "admpay" && Meta.DrawStateIsDone)
            {
                if (R != null) {
                    string filter = QHS.MCmp(R, new string [] {"yadmpay", "nadmpay"});
                    if (Meta.InsertMode) {
                        filter = QHS.AppAnd(filter, QHS.CmpGt("available", 0));
                    }
                    DisplayMember_Accertamento(filter); 
                }
                else {
                    ((DataTable)(cmbAccertamento.DataSource)).Clear();
                }
            }
        }

        //restituisce una stringa da un decimal
        private string Str(decimal D) {
            if (D == 0) return "";
            return D.ToString("c");
        }

        #region Classificazioni

        decimal GetImportoPerClassificazione() {
            if (DS.admpay_income.Rows.Count == 0) return 0;
            DataRow R = DS.admpay_income.Rows[0];
            decimal importo = CfgFn.GetNoNullDecimal(R["amount"]);
            return importo;
        }

        public void ManageTipoClassMovimentiRowChanged(decimal ImportoPerClassificazione,
            DataRow Curr) {
            if (Curr == null) {
                btnEditClass.Enabled = false;
                btnInsertClass.Enabled = false;
                btnDelClass.Enabled = false;
                return;
            }
            btnEditClass.Enabled = true;
            btnInsertClass.Enabled = true;
            btnDelClass.Enabled = true;

            CalcImpClassMovHeaders(ImportoPerClassificazione);
        }

        /// <summary>
        /// Calcs column names of admpay_incomesorted grid and freshes grid
        /// </summary>
        void CalcImpClassMovHeaders(decimal importoperclassificazione) {
            DataTable T;
            DataRow Curr;

            bool res = Meta.myHelpForm.GetCurrentRow(DGridClassificazioni, out T, out Curr);
            if (Curr == null) return;

            RefillDettagliClassificazioni(importoperclassificazione);
        }

        /// <summary>
        /// redraws grid
        /// </summary>
        /// <param name="importoperclassificazione"></param>
        public void RefillDettagliClassificazioni(decimal importoperclassificazione) {
            if (Meta.IsEmpty) return;
            DS.admpay_incomesorted.ExtendedProperties["TotaleImporto"] = importoperclassificazione;
            GetData.CalculateTable(DS.admpay_incomesorted);
            DGridDettagliClassificazioni.TableStyles.Clear();
            HelpForm.SetGridStyle(DGridDettagliClassificazioni, DS.admpay_incomesorted);
            if (DGridDettagliClassificazioni.DataSource == null) return;
            formatgrids format = new formatgrids(DGridDettagliClassificazioni);
            format.AutosizeColumnWidth();
            HelpForm.SetDataGrid(DGridDettagliClassificazioni, DS.admpay_incomesorted);
        }

        private void btnInsertClass_Click(object sender, System.EventArgs e) {
            if (Meta.IsEmpty) return;
            if (DS.admpay_income.Rows.Count == 0) return;
            Meta.GetFormData(true);
            DataRow Curr = DS.admpay_income.Rows[0];
            decimal importo = CfgFn.GetNoNullDecimal(Curr["amount"]);

            CalcImpClassMovDefaults(importo);

            DataTable T;
            DataRow CurrTipoClass;
            bool res = Meta.myHelpForm.GetCurrentRow(DGridClassificazioni, out T, out CurrTipoClass);
            if (!res) return;
            if (CurrTipoClass == null) return;
            string filter = QHS.CmpEq("idsorkind", CurrTipoClass["idsorkind"]);
            DataTable ClassMovAllowed = DS.sorting.Clone();
            ClassMovAllowed.Clear();
            Meta.Conn.RUN_SELECT_INTO_TABLE(ClassMovAllowed, null, filter, null, true);
            if (ClassMovAllowed.Rows.Count == 0) return;

            DS.admpay_incomesorted.ExtendedProperties[MetaData.ExtraParams] = ClassMovAllowed;
            DS.admpay_incomesorted.ExtendedProperties["importoresiduo"] = Convert.ToDecimal(0);

            DataRow Added = MetaData.Insert_Grid(DGridDettagliClassificazioni, "detail");
            if (Added == null) return;

            Meta.FreshForm(true);
        }

        private void btnEditClass_Click(object sender, System.EventArgs e) {
            if (Meta.IsEmpty) return;
            if (DS.admpay_income.Rows.Count == 0) return;
            Meta.GetFormData(true);
            DataRow Curr = DS.admpay_income.Rows[0];
            decimal importo = CfgFn.GetNoNullDecimal(Curr["amount"]);
            CalcImpClassMovDefaults(importo);

            DataTable T;
            DataRow CurrTipoClass;
            bool res = Meta.myHelpForm.GetCurrentRow(DGridClassificazioni, out T, out CurrTipoClass);
            if (!res) return;
            if (CurrTipoClass == null) return;
            DataTable SourceTable;
            DataRow CurrDR;
            res = Meta.myHelpForm.GetCurrentRow(DGridDettagliClassificazioni, out SourceTable, out CurrDR);
            if (!res) return;
            if (CurrDR == null) return;

            string filter = QHS.CmpEq("idsorkind", CurrTipoClass["idsorkind"]);
            DataTable ClassMovAllowed = DS.sorting.Clone();
            ClassMovAllowed.Clear();
            Meta.Conn.RUN_SELECT_INTO_TABLE(ClassMovAllowed, null, filter, null, true);
            if (ClassMovAllowed.Rows.Count == 0) return;
            DS.admpay_incomesorted.ExtendedProperties[MetaData.ExtraParams] = ClassMovAllowed;
            DataRow Modified = MetaData.Edit_Grid(DGridDettagliClassificazioni, "detail");
            if (Modified == null) return;

            Meta.FreshForm(true);
        }

        private void btnDelClass_Click(object sender, System.EventArgs e) {
            if (Meta.IsEmpty) return;
            if (DS.admpay_income.Rows.Count == 0) return;
            Meta.GetFormData(true);
            DataRow Curr = DS.admpay_income.Rows[0];

            DataTable SourceTable;
            DataRow CurrDR;

            bool res = Meta.myHelpForm.GetCurrentRow(DGridDettagliClassificazioni,
                out SourceTable, out CurrDR);
            if (!res) return;
            if (CurrDR == null) return;


            if (show(
                "Cancello la classificazione selezionata?",
                "Richiesta di conferma",
                MessageBoxButtons.YesNo) != DialogResult.Yes) return;


            DeleteImpClassMov(CurrDR);

            HelpForm.SetLastSelected(SourceTable, null);
            Meta.myHelpForm.SetDataRowRelated(DGridClassificazioni.FindForm(), SourceTable, null);
            Meta.myHelpForm.ControlChanged(DGridClassificazioni, null);
            Meta.FreshForm();
        }

        void AbilitaSubMovimenti() {
            RowChange.MarkAsAutoincrement(
                DS.admpay_incomesorted.Columns["idsubclass"],
                null,
                null,
                7,
                false);
            //RowChange.SetSelector(DS.admpay_incomesorted, "idsorkind");
            RowChange.SetSelector(DS.admpay_incomesorted, "idsor");
            RowChange.SetSelector(DS.admpay_incomesorted, "nadmpay");
            RowChange.SetSelector(DS.admpay_incomesorted, "yadmpay");
            RowChange.SetSelector(DS.admpay_incomesorted, "nincome");
        }

        public void CalcImpClassMovDefaults(decimal ImportoPerClassificazione) {
            DataTable T;
            DataRow Curr;
            bool res = Meta.myHelpForm.GetCurrentRow(DGridClassificazioni,
                out T, out Curr);
            if (Curr == null) return;

            //DS.admpay_incomesorted.Columns["idsorkind"].DefaultValue = Curr["idsorkind"];

            AbilitaSubMovimenti();
            DataRow CurrMov = DS.admpay_income.Rows[0];
            string f = QHC.CmpEq("idsorkind", Curr["idsorkind"]);

            decimal importoclassificato = CfgFn.GetNoNullDecimal(DS.admpay_incomesorted.Compute("SUM(amount)",
                QHC.FieldIn("idsor", DS.sorting.Select(f))));

            decimal importototale = ImportoPerClassificazione;
            decimal importoresiduo = importototale - importoclassificato;

            if (Curr["totalexpression"].ToString() == "")
                DS.admpay_incomesorted.Columns["amount"].DefaultValue = importoresiduo;
            else
                DS.admpay_incomesorted.Columns["amount"].DefaultValue = 0;

            DS.admpay_incomesorted.ExtendedProperties["importoresiduo"] = importoresiduo;
            DS.admpay_incomesorted.ExtendedProperties["importototale"] = importototale;
            btnEditClass.Enabled = true;
            btnInsertClass.Enabled = true;
            btnDelClass.Enabled = true;
        }

        /// <summary>
        /// Deletes epexp with all sub-autoclasses
        /// </summary>
        /// <param name="R"></param>
        void DeleteImpClassMov(DataRow R) {
            R.Delete();
        }

        public void CalcolaTotaliClassificazioni() {
            foreach (DataRow TR in DS.sortingkind.Rows) {
                decimal importo = 0;
                string filter = QHC.CmpEq("idsorkind", TR["idsorkind"]);
                string expression = TR["totalexpression"].ToString();
                if (expression == "") expression = "SUM(amount)";
                string filterMovSor = QHC.FieldIn("idsor", DS.sorting.Select(filter));
                object importoo = null;
                try {
                    importoo = DS.admpay_incomesorted.Compute(expression, filterMovSor);
                }
                catch {
                }
                importo = CfgFn.GetNoNullDecimal(importoo);
                TR["!importo"] = importo;
                TR.AcceptChanges();
            }

        }

        public void SelectTipoClassMovimenti() {
            DataTable T;
            DataRow CurrTipoClass;
            bool res = Meta.myHelpForm.GetCurrentRow(DGridClassificazioni,
                out T, out CurrTipoClass);
            if (!res) {
                return;
            }
            if (CurrTipoClass != null) {
                if (DGridDettagliClassificazioni.DataSource == null)
                    Meta.myHelpForm.ControlChanged(DGridClassificazioni, null);
                return;
            }
            if (T.Rows.Count == 0) {
                return;
            }
            DGridDettagliClassificazioni.CurrentRowIndex = 0;
            Meta.myHelpForm.ControlChanged(DGridClassificazioni, null);
            res = Meta.myHelpForm.GetCurrentRow(DGridClassificazioni,
                out T, out CurrTipoClass);
        }

        public void EnterTabClassificazioni() {
            if (Meta.IsEmpty) return;
            CalcolaTotaliClassificazioni();
            SelectTipoClassMovimenti();

        }
        #endregion

        private void tabClassSup_Enter(object sender, EventArgs e) {
            if (Meta == null) return;
            if (!Meta.DrawStateIsDone) return;
            if (tabControl1.SelectedTab == tabClassSup) {
                EnterTabClassificazioni();
            }
        }

        private void btnAccertamento_Click(object sender, EventArgs e) {
            // Passo 1. Ottengo tutte gli accertamenti in base alla chiave specificata
            if (DS.admpay_income.Rows.Count == 0) return;
            DataRow Curr = DS.admpay_income.Rows[0];
            string filter = QHS.MCmp(Curr, new string [] {"yadmpay", "nadmpay"});

            DataTable admpay_assessmentview_temp = Meta.Conn.RUN_SELECT("admpay_assessmentview", null, "nassessment", filter, null, true);
            if (admpay_assessmentview_temp.Rows.Count == 0) return;

            // Passo 2. Correggo il disponibile degli accertamenti
            // Caso 1: InsertMode - devo sottrarre tutti i contributi dell'entrata corrente
            // Caso 2: EditMode - devo sommarre l'importo originale dell'entrata; devo sommare tutti gli importi originali
            // dei contributi e devo sottrarre quelli correnti
            if (Meta.EditMode) {
                aggiornaDisponibileAccertamento(Curr, DataRowVersion.Original, admpay_assessmentview_temp);
            }

            // Passo 3. Passo il DataTable al form degli accertamenti
            DataSet D = new DataSet();
            D.Tables.Add(admpay_assessmentview_temp);

            Frm_AdmPay_Assessment_Choose f = new Frm_AdmPay_Assessment_Choose(admpay_assessmentview_temp, Meta);
            f.ShowDialog(this);
            if (f.DialogResult != DialogResult.OK) return;
            if (f.Choosen == null) return;
            DataRow rImpSel = f.Choosen;
            int nAssessment = CfgFn.GetNoNullInt32(rImpSel["nassessment"]);
            cmbAccertamento.SelectedValue = nAssessment;
            // Passo 4. Dopo aver chiamato il form seleziono l'accertamento scelto dal combo box
        }

        /// <summary>
        /// /// Metodo che aggiorna il disponibile dell'accertamento
        /// </summary>
        /// <param name="Curr">Riga da interrogare per determinare l'accertamento associato</param>
        /// <param name="toConsider">Versione della riga da considerare</param>
        private void aggiornaDisponibileAccertamento(DataRow Curr, DataRowVersion toConsider, DataTable AdmPay_Asses)
        {
            decimal importo = CfgFn.GetNoNullDecimal(Curr["amount", toConsider]);
            importo = (toConsider == DataRowVersion.Original) ? importo : -importo;
            string filtro = QHC.AppAnd(QHC.CmpEq("yadmpay", Curr["yadmpay", toConsider]),
                QHC.CmpEq("nadmpay", Curr["nadmpay", toConsider]),
                QHC.CmpEq("nassessment", Curr["nassessment", toConsider]));

            DataRow[] rAccertamento = AdmPay_Asses.Select(filtro);
            if (rAccertamento.Length != 0) {
                DataRow currAccertamento = rAccertamento[0];
                currAccertamento["available"] = CfgFn.GetNoNullDecimal(currAccertamento["available"])
                    + importo;
            }
        }

    }
}
