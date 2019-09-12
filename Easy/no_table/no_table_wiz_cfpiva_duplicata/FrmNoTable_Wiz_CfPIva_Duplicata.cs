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

namespace no_table_wiz_cfpiva_duplicata {
    public partial class FrmNoTable_Wiz_CfPIva_Duplicata : Form {
        CQueryHelper QHC;
        QueryHelper QHS;
        //MetaData Meta;
        DataTable TempTable;

        public FrmNoTable_Wiz_CfPIva_Duplicata() {
            InitializeComponent();
        }

        private void btnInizia_Click(object sender, EventArgs e) {
            Cursor = Cursors.WaitCursor;
            FillTempTable();
            CollegaRigheADocumento(true);
            MetaData_AfterFill();
            btnInizia.Enabled = false;
            btnSuccessivo.Enabled = true;
            btnRefresh.Enabled = true;
            grpChoose.Enabled = false;
            grpConferma.Enabled = TempTable.Rows.Count > 0;
            Cursor = null;
        }

        private void btnSuccessivo_Click(object sender, EventArgs e) {
            if (TempTable.Rows.Count > 0){
                DS.registrymainview.AcceptChanges();
                TempTable.Rows.RemoveAt(0);
                TempTable.AcceptChanges();
            }
            CollegaRigheADocumento(false);
            pBar.Increment(1);
            grpConferma.Enabled = TempTable.Rows.Count > 0;
            if (TempTable.Rows.Count == 0) metaNoTable.dontWarnOnInsertCancel = true;
        }

        public void MetaData_AfterActivation() {
            grpConferma.Enabled = false;
            btnSuccessivo.Enabled = false;
            btnRefresh.Enabled = false;
            impostaColoreBottoni();
            if (this.Text.EndsWith("(Ricerca)")) {
                this.Text = this.Text.Substring(0, Text.Length - 10);
            }

            DetailGrid.MouseDown += new MouseEventHandler(GRID_MouseDown);
            DetailGrid.MouseUp += new MouseEventHandler(GRID_MouseUp);
            cmbRegistryClass.DataSource = DS.registryclass;
            cmbRegistryClass.DisplayMember = "description";
            cmbRegistryClass.ValueMember = "idregistryclass";
        }

        private void impostaColoreBottoni() {
            btnInizia.BackColor = formcolors.GridButtonBackColor();
            btnInizia.ForeColor = formcolors.GridButtonForeColor();
            btnSuccessivo.BackColor = formcolors.GridButtonBackColor();
            btnSuccessivo.ForeColor = formcolors.GridButtonForeColor();
            btnChiudi.BackColor = formcolors.GridButtonBackColor();
            btnChiudi.ForeColor = formcolors.GridButtonForeColor();
            btnAttivo.BackColor = formcolors.GridButtonBackColor();
            btnAttivo.ForeColor = formcolors.GridButtonForeColor();
            btnMultiCF.BackColor = formcolors.GridButtonBackColor();
            btnMultiCF.ForeColor = formcolors.GridButtonForeColor();
            btnRefresh.BackColor = formcolors.GridButtonBackColor();
            btnRefresh.ForeColor = formcolors.GridButtonForeColor();
            btnUnifica.BackColor = formcolors.GridButtonBackColor();
            btnUnifica.ForeColor = formcolors.GridButtonForeColor();
        }

        public void MetaData_AfterClear() {
            if (this.Text.Trim().EndsWith("(Ricerca)")) {
                this.Text = this.Text.Substring(0, Text.Length - 10);
            }
        }

        public void MetaData_AfterFill() {
            if (this.Text.Trim().EndsWith("(Ricerca)")) {
                this.Text = this.Text.Substring(0, Text.Length - 10);
            }
        }

        private void btnAttivo_Click(object sender, EventArgs e) {
            string dataMember = DetailGrid.DataMember;
            CurrencyManager cm = DetailGrid.BindingContext[DS, dataMember] as CurrencyManager;
            if (cm == null) return;
            DataView view = cm.List as DataView;
            if (view == null) {
                MessageBox.Show(this, "Selezionare una anagrafica");
                return;
            }

            int numRigheSel;
            numRigheSel = 0;
            for (int i = 0; i < view.Count; i++) {
                if (DetailGrid.IsSelected(i)) {
                    DataRow R = GetGridRow(i);
                    if (R == null) continue;
                    numRigheSel++;
                }
            }

            if (!(numRigheSel == 1)) {
                MessageBox.Show(this, "Selezionare un'anagrafica");
                return;
            }

            for (int i = 0; i < view.Count; i++) {
                object idreg = view[i].Row["idreg"];
                string filter = QHC.CmpEq("idreg", idreg);
                DataRow[] Registry = DS.registrymainview.Select(filter);
                if (Registry.Length == 0) {
                    MessageBox.Show(this, "Errore, griglia e tabella dati disallineate! Contattare il settore assistenza");
                    return;
                }

                DataRow r = Registry[0];
                // N.B. Imposto anche active a S esplicitamente nel caso ci siano ancora anagrafiche con active a NULL
                r["active"] = (DetailGrid.IsSelected(i)) ? "S" : "N";
            }

            if (saveData()) {
                MessageBox.Show(this, "Anagrafiche aggiornate");
                //TempTable.Rows.RemoveAt(0);//questo codice sarà eseguito in btnSuccessivo_Click()
                //TempTable.AcceptChanges();

                //grpConferma.Enabled = false;
                btnSuccessivo.Enabled = true;
                btnSuccessivo_Click(sender, e);
            }
            else {
                grpConferma.Enabled = true;
                btnSuccessivo.Enabled = false;
            }

        }

        private void btnMultiCF_Click(object sender, EventArgs e) {
            foreach(DataRow r in DS.registrymainview.Rows) {
                r["multi_cf"] = "S";
            }

            if (saveData()) {
                MessageBox.Show(this, "Anagrafiche aggiornate");
                //TempTable.Rows.RemoveAt(0);//questo codice sarà eseguito in btnSuccessivo_Click()
                //TempTable.AcceptChanges();

                //grpConferma.Enabled = false;
                btnSuccessivo.Enabled = true;
                btnSuccessivo_Click(sender, e);
            }
            else {
                grpConferma.Enabled = true;
                btnSuccessivo.Enabled = false;
            }
        }

        private bool saveData() {
            IDataAccess conn = this.getInstance<IDataAccess>();
            PostData Post = MetaRegistry.Get_PostData();

            Post.initClass(DS, conn);
            if (!Post.DO_POST()) {
                return false;
            }
            return true;
        }

        private MetaData MetaRegistry;
        IDataAccess conn;
        private IMetaData metaNoTable;
        private IFormController ctrl;
        public void MetaData_AfterLink() {
            MetaRegistry = MetaData.GetMetaData(this, "registry");
            conn = this.getInstance<IDataAccess>();
            metaNoTable = this.getInstance<IMetaData>();
            ctrl = this.getInstance<IFormController>();
            QHC = new CQueryHelper();
            QHS = conn.GetQueryHelper();
            rdoCF.Checked = true;
            QueryCreator.SetTableForPosting(DS.registrymainview, "registry");
            GetData.CacheTable(DS.registryclass, QHS.CmpEq("active", "S"), "idregistryclass", true);
            metaNoTable.searchEnabled = false;
            
        }

        string MyAppend(string source, string toappend) {
            if (source.Trim() == "") return toappend;
            return source + ", " + toappend + " ";
        }

        private void FillTempTable() {
            string ParteSelect, ParteFrom, ParteWhere, ParteGroupBy, ParteOrderBy, ParteHaving;
            string SelectClause, FromClause, WhereClause, GroupByClause, OrderByClause, HavingClause;
            
            ParteWhere = QHS.CmpNe("multi_cf", 'S');
            if (!chkNonAttive.Checked) ParteWhere = QHS.AppAnd(ParteWhere, QHS.NullOrEq("active", 'S'));
            if (cmbRegistryClass.SelectedIndex > 0)
                ParteWhere = QHS.AppAnd(ParteWhere, QHS.CmpEq("idregistryclass", cmbRegistryClass.SelectedValue));
            if (txtCF.Text.Trim() != "") {
                if (rdoCF.Checked) {
                    ParteWhere = QHS.AppAnd(ParteWhere, QHS.Like("cf", txtCF.Text));
                }
                else {
                    ParteWhere = QHS.AppAnd(ParteWhere, QHS.Like("p_iva", txtCF.Text));
                }
            }

            ParteFrom = "registry";
            SelectClause = "SELECT ";
            FromClause = " FROM ";
            WhereClause = " WHERE ";
            GroupByClause = " GROUP BY ";
            OrderByClause = " ORDER BY ";
            HavingClause = " HAVING ";
            ParteSelect = "idregistryclass";
            ParteGroupBy = "idregistryclass";

            if (rdoCF.Checked) {
                ParteSelect = MyAppend(ParteSelect, "cf");
                ParteGroupBy = MyAppend(ParteGroupBy, "cf");
                ParteWhere = QHS.AppAnd(ParteWhere, QHS.IsNotNull("cf"));
                ParteHaving = "COUNT(cf) > 1";
                ParteOrderBy = "cf ASC";
            }
            else {
                ParteSelect = MyAppend(ParteSelect, "p_iva");
                ParteGroupBy = MyAppend(ParteGroupBy, "p_iva");
                ParteWhere = QHS.AppAnd(ParteWhere, QHS.IsNotNull("p_iva"));
                ParteHaving = "COUNT(p_iva) > 1";
                ParteOrderBy = "p_iva ASC";
            }

            ParteOrderBy = MyAppend(ParteOrderBy, "idregistryclass ASC");

            if (ParteGroupBy == "") GroupByClause = "";
            if (ParteOrderBy == "") OrderByClause = "";

            string MyQuery = "";

            if (ParteSelect != "") {
                MyQuery = SelectClause + ParteSelect + FromClause + ParteFrom +
                    WhereClause + ParteWhere + GroupByClause + ParteGroupBy +
                    HavingClause + ParteHaving + OrderByClause + ParteOrderBy;
            }


            if (MyQuery != "") {
                TempTable = conn.SQLRunner(MyQuery);
            }
            else {
                TempTable.Columns.Add("UnicaAnagrafica");
                TempTable.Rows.Add(new object[] { "" });
            }
            pBar.Maximum = TempTable.Rows.Count;
            pBar.Value = 0;
        }

        /// <summary>
        /// Crea una nuova riga e legge le righe del raggruppamento corrente in spesaview
        /// </summary>
        private void CollegaRigheADocumento(bool quiet) {
            if (TempTable==null || TempTable.Rows.Count == 0) {
                if (!quiet) MessageBox.Show("Non ci sono anagrafiche da processare");
                btnSuccessivo.Enabled = false;
                grpConferma.Enabled = false;
                return;
            }

            DataRow CurrRow = TempTable.Rows[0];

            DS.registrymainview.Clear();
            ctrl.GetFormData(true);

            string field = (rdoCF.Checked) ? "cf" : "p_iva";
            string filter = QHS.AppAnd(QHS.MCmp(CurrRow, new string [] {"idregistryclass", field}),
                           QHS.CmpNe("multi_cf", 'S'));
            if (!chkNonAttive.Checked) filter = QHS.AppAnd(filter, QHS.NullOrEq("active", 'S'));
            if (cmbRegistryClass.SelectedIndex > 0)
                filter = QHS.AppAnd(filter, QHS.CmpEq("idregistryclass", cmbRegistryClass.SelectedValue));

            DataAccess.RUN_SELECT_INTO_TABLE(conn as DataAccess, DS.registrymainview,
                "title ASC," + field + " ASC", 
                filter,
                null, false);

            MetaData.FreshForm(this, false);

            // Seleziono solo la prima riga (in previsione che l'utente voglia cliccare sul bottone Attiva una sola anagrafica
            if (DS.registrymainview.Rows.Count == 0) return;

            btnMultiCF.Enabled = (DS.registrymainview.Select(QHC.CmpEq("idregistryclass", "22")).Length == 0);
            
            DetailGrid.Select(0);
        }

        private void btnRefresh_Click(object sender, EventArgs e) {
            AggiornaSelezione();
        }

        private void AggiornaSelezione() {
            CollegaRigheADocumento(false);
            if (DS.registrymainview.Rows.Count == 0) {
                if (TempTable.Rows.Count > 0) {
                    TempTable.Rows.RemoveAt(0);
                    TempTable.AcceptChanges();
                }
                btnSuccessivo_Click(null, null);
            }
        }

        private void DetailGrid_DoubleClick(object sender, EventArgs e) {
            int i = DetailGrid.CurrentRowIndex;
            if (i < 0) return;

            GridSelectRow(i);
        }

        void GridSelectRow(int I) {
            DataRow R = GetGridRow(I);
            if (R == null) return;
            var dispacher = this.getInstance<IMetaDataDispatcher>();
            MetaData Registry = dispacher.Get("registry");

            Registry.ContextFilter = QHS.CmpEq("idreg", R["idreg"]);
            Registry.Edit(this.ParentForm, "history", false);
            string listtype = Registry.DefaultListType;
            DataRow RR = Registry.SelectOne(listtype, QHS.CmpEq("idreg", R["idreg"]), null, null);
            if (RR != null) Registry.SelectRow(RR, listtype);
        }

        DataRow GetGridRow(int index) {
            string TableName = DetailGrid.DataMember.ToString();
            DataSet MyDS = (DataSet)DetailGrid.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            string filter = QHC.CmpEq("idreg", DetailGrid[index, 0]);
            DataRow[] selectresult = MyTable.Select(filter);
            return selectresult[0];
        }

        DateTime LastGridClick;
        private void GRID_MouseDown(object sender, MouseEventArgs e) {
            if (sender == null) return;
            if (!typeof(DataGrid).IsAssignableFrom(sender.GetType())) return;
            LastGridClick = DateTime.Now;

        }

        private void GRID_MouseUp(object sender, MouseEventArgs e) {
            if (sender == null) return;
            if (!typeof(DataGrid).IsAssignableFrom(sender.GetType())) return;

            DataSet D = DetailGrid.DataSource as DataSet;
            if (D == null) return;
            DataTable T = D.Tables[DetailGrid.DataMember];
            if (T == null) return;

            System.Windows.Forms.DataGrid.HitTestInfo myHitTest = DetailGrid.HitTest(e.X, e.Y);
            if (myHitTest.Type == System.Windows.Forms.DataGrid.HitTestType.Cell) {
                int Row = myHitTest.Row;
                if (!DetailGrid.IsSelected(Row)) {
                    SimpleSelect(Row);
                }
                else {
                    DetailGrid.UnSelect(Row);
                }
            }
            else {
                int Row = myHitTest.Row;
            }
        }

        void SimpleSelect(int R) {
            try {
                DetailGrid.Select(R);
            }
            catch {
            }
        }

        private void btnChiudi_Click(object sender, EventArgs e) {
            this.Close();
        }
        private void btnUnifica_Click (object sender, EventArgs e) {
            unifica(true);
        }

        void unifica(bool stepForward){
            string dataMember = DetailGrid.DataMember;
            CurrencyManager cm = DetailGrid.BindingContext[DS, dataMember] as CurrencyManager;
            if (cm == null) return;
            DataView view = cm.List as DataView;
            if (view == null) {
                MessageBox.Show(this, "Selezionare una anagrafica");
                return;
            }
            int numRigheSel;
            DataRow RowSelected;
            RowSelected = null;
            object idregSelected;
            idregSelected = DBNull.Value;
            numRigheSel = 0;
            for (int i = 0; i < view.Count; i++) {
                if (DetailGrid.IsSelected(i)) {
                    DataRow R = GetGridRow(i);
                    if (R == null) continue;
                    numRigheSel++;
                    RowSelected = R;
                }
            }

            if (!(numRigheSel == 1)) {
                MessageBox.Show(this, "Selezionare un'anagrafica");
                return;
            }

            if (!(RowSelected == null)) {
                idregSelected = RowSelected["idreg"];
            }

            for (int i = 0; i < view.Count; i++) {
                object idreg = view[i].Row["idreg"];
                string filter = QHC.CmpEq("idreg", idreg);
                DataRow[] Registry = DS.registrymainview.Select(filter);
                if (Registry.Length == 0) {
                    MessageBox.Show(this, "Errore, griglia e tabella dati disallineate! Contattare il settore assistenza");
                    return;
                }
                DataRow r = Registry[0];
                // N.B. Imposto toredirect a idreg esplicitamente nel caso ci siano ancora anagrafiche non attivate
                if (!(DetailGrid.IsSelected(i))) {
                    r["active"] = "N";
                    r["toredirect"] = idregSelected;
                }
            }

            if (saveData()) {
                MessageBox.Show(this, "Anagrafiche aggiornate");
                btnSuccessivo.Enabled = true;
                if (stepForward) btnSuccessivo_Click(null, null);
            }
            else {
                grpConferma.Enabled = true;
                btnSuccessivo.Enabled = false;
            }
        }

        private void btnSpecialAction_Click(object sender, EventArgs e) {
            if (DetailGrid.DataMember == null) return;
            if (DetailGrid.DataSource == null) return;
            string TableName = DetailGrid.DataMember.ToString();
            DataSet MyDS = (DataSet)DetailGrid.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            int Num = MyTable.Rows.Count;
            object []idregs= new object[Num];
            for (int i = 0; i < Num; i++) idregs[i] = Convert.ToInt32( DetailGrid[i, 0]);

            string dataMember = DetailGrid.DataMember;
            CurrencyManager cm = DetailGrid.BindingContext[DS, dataMember] as CurrencyManager;
            if (cm == null) return;
            DataView view = cm.List as DataView;
            if (view == null) {
                MessageBox.Show(this, "Selezionare una anagrafica");
                return;
            }
            DataRow RowSelected = null;
            object idregSelected;
            idregSelected = DBNull.Value;
            int numRigheSel = 0;
            for (int i = 0; i < view.Count; i++) {
                if (DetailGrid.IsSelected(i)) {
                    DataRow R = GetGridRow(i);
                    if (R == null) continue;
                    numRigheSel++;
                    RowSelected = R;
                }
            }

            if (!(numRigheSel == 1)) {
                MessageBox.Show(this, "Selezionare un'anagrafica");
                return;
            }

            if (!(RowSelected == null)) {
                idregSelected = RowSelected["idreg"];
            }
            frmUnisciInformazioni F = new frmUnisciInformazioni(Convert.ToInt32(idregSelected),
                            idregs, conn as DataAccess, this.getInstance<IMetaDataDispatcher>() as MetaDataDispatcher);
            DialogResult Res= F.ShowDialog();
            if (Res == DialogResult.OK) {
                unifica(false);
                AggiornaSelezione();
            }
            return;

 
        }

    }
}