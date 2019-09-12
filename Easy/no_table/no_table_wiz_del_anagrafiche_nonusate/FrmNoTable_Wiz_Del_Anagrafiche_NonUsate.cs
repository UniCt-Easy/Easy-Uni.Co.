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
using System.Collections;

namespace no_table_wiz_del_anagrafiche_nonusate {
    public partial class FrmNoTable_Wiz_Del_Anagrafiche_NonUsate : Form {
        CQueryHelper QHC;
        QueryHelper QHS;
        MetaData Meta;
        //ArrayList selectedAnagr;

        public FrmNoTable_Wiz_Del_Anagrafiche_NonUsate() {
            InitializeComponent();
            tabController.HideTabsMode =
                Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this, "registry");
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            QueryCreator.SetTableForPosting(DS.registrymainview, "registry");
        }

        public void MetaData_AfterActivation() {
            dgAnagrafica.MouseDown += new MouseEventHandler(GRID_MouseDown);
            dgAnagrafica.MouseUp += new MouseEventHandler(GRID_MouseUp);

            if (this.Text.EndsWith("(Ricerca)")) {
                this.Text = this.Text.Substring(0, Text.Length - 10);
            }

            DisplayTabs(0);
        }

        void DisplayTabs(int newTab) {
            tabController.SelectedIndex = newTab;
            //Evaluates Buttons Appearance
            btnBack.Visible = (newTab > 0);
            if (newTab == tabController.TabPages.Count - 1)
                btnNext.Text = "Fine";
            else
                btnNext.Text = "Next >";
        }
        bool Do_Delete() {
            pBar.Visible = true;
            this.Cursor = Cursors.WaitCursor;


            foreach (DataTable T in DS.Tables) {
                if ((T.TableName == "registrymainview") || (T.TableName == "no_table")) continue;
                T.Clear();
            }

            string dataMember = dgAnagrafica.DataMember;
            CurrencyManager cm = dgAnagrafica.BindingContext[DS, dataMember] as CurrencyManager;
            if (cm == null) return false ;
            DataView view = cm.List as DataView;
            if (view == null) {
                MessageBox.Show(this, "Selezionare almeno una anagrafica");
                return true;
            }
            int Nselected = 0;
            int max = view.Count - 1;
            for (int i = 0; i <= max; i++) {
                if (dgAnagrafica.IsSelected(i)) Nselected++;
            }
            pBar.Maximum = Nselected;
            pBar.Value = 0;

            string filter = "";
            //int j = 0;
            for (int i = 0; i <= max; i++) {
                if (!dgAnagrafica.IsSelected(i)) continue;
                DataSet D = DS.Clone();
                QueryCreator.SetTableForPosting(D.Tables["registrymainview"], "registry");

                pBar.Increment(1);
                filter = QHS.CmpEq("idreg", view[i]["idreg"]);

                foreach (string tname in new string[]{"registrymainview","registryaddress",
                        "registrycf","registrylegalstatus","registrypaymethod","registrypiva",
                        "registryreference","registrytaxablestatus"}) {
                    DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, D.Tables[tname], null, filter, null, false);
                    foreach (DataRow RD in D.Tables[tname].Rows) RD.Delete();
                }

                PostData P = Meta.Get_PostData();
                P.InitClass(D, Meta.Conn);
                if (!P.DO_POST()) {
                    Aggiorna();
                    pBar.Visible = false; 
                    return false;
                }

            }
            Aggiorna();
            this.Cursor = Cursors.Default;
            pBar.Visible = false;
            return true;
        }

        void StandardChangeTab(int step) {
            int oldTab = tabController.SelectedIndex;
            int newTab = oldTab + step;
            if ((newTab < 0) || (newTab > tabController.TabPages.Count)) return;

            if (newTab == 1) {
                btnNext.Enabled = false;
                popolaTab();
                riempiGrid();
                btnNext.Enabled = true;
            }

            if (newTab == tabController.TabPages.Count) {
                DialogResult = DialogResult.OK;                
                return;
            }
            DisplayTabs(newTab);
        }

        private void btnBack_Click(object sender, System.EventArgs e) {
            StandardChangeTab(-1);
        }


        private void btnNext_Click(object sender, System.EventArgs e) {
            StandardChangeTab(+1);
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


       

        private void popolaTab() {
            string param = "N";
            if (chkNonAttive.Checked) param = "S";
            DataSet Out = DataAccess.CallSP(Meta.Conn, "compute_list_unusable_registry", new object[] {param}, true, 0);
            if ((Out == null) || (Out.Tables.Count == 0)) {
                MessageBox.Show(this, "Errore nella interrogazione dal DB");
                return;
            }
            DS.registrymainview.Merge(Out.Tables[0]);
        }

        private void clearAll() {
            DS.Clear();
        }

        private void clearGrid() {
            dgAnagrafica.DataSource = null;
        }

        /// <summary>
        /// Metodo che riempie il grid delle anagrafiche
        /// </summary>
        private void riempiGrid() {
            foreach (DataColumn C in DS.registrymainview.Columns) {
                string colName = C.ColumnName;
                MetaData.DescribeAColumn(DS.registrymainview, colName, "");
            }

            DS.registrymainview.Columns["idreg"].Caption = "Codice";
            DS.registrymainview.Columns["title"].Caption = "Denominazione";
            DS.registrymainview.Columns["surname"].Caption = "Cognome";
            DS.registrymainview.Columns["forename"].Caption = "Nome";
            DS.registrymainview.Columns["cf"].Caption = "Cod. Fiscale";
            DS.registrymainview.Columns["p_iva"].Caption = "Partita IVA";
            DS.registrymainview.Columns["registryclass"].Caption = "Tipologia";
            DS.registrymainview.Columns["lt"].Caption = "lt";
            DS.registrymainview.Columns["lu"].Caption = "lu";
            DS.registrymainview.Columns["active"].Caption = "attiva";

            HelpForm.SetDataGrid(dgAnagrafica, DS.registrymainview);
        }

        #region Gestione Eventi Grid
        private void dbAnagrafica_DoubleClick(object sender, EventArgs e) {
            int i = dgAnagrafica.CurrentRowIndex;
            if (i < 0) return;

            GridSelectRow(i);
        }

        void GridSelectRow(int I) {
            DataRow R = GetGridRow(I);
            if (R == null) return;
            MetaData Registry = Meta.Dispatcher.Get("registry");

            Registry.ContextFilter = QHS.CmpEq("idreg", R["idreg"]);
            string edittype = "anagrafica";
            if (R["active"].ToString() == "N") edittype = "history";
            Registry.Edit(this.ParentForm, edittype, false);
            string listtype = Registry.DefaultListType;
            DataRow RR = Registry.SelectOne(listtype, QHS.CmpEq("idreg", R["idreg"]), null, null);
            if (RR != null) Registry.SelectRow(RR, listtype);
        }

        DataRow GetGridRow(int index) {
            string TableName = dgAnagrafica.DataMember.ToString();
            DataSet MyDS = (DataSet)dgAnagrafica.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            string filter = QHC.CmpEq("idreg", dgAnagrafica[index, 0]);
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

            DataSet D = dgAnagrafica.DataSource as DataSet;
            if (D == null) return;
            DataTable T = D.Tables[dgAnagrafica.DataMember];
            if (T == null) return;

            System.Windows.Forms.DataGrid.HitTestInfo myHitTest = dgAnagrafica.HitTest(e.X, e.Y);
            if (myHitTest.Type == System.Windows.Forms.DataGrid.HitTestType.Cell) {
                int Row = myHitTest.Row;
                if (!dgAnagrafica.IsSelected(Row)) {
                    SimpleSelect(Row);
                }
                else {
                    dgAnagrafica.UnSelect(Row);
                }
            }
            else {
                int Row = myHitTest.Row;
            }
        }

        void SimpleSelect(int R) {
            try {
                dgAnagrafica.Select(R);
            }
            catch {
            }
        }
        #endregion

        private void btnSelectAll_Click(object sender, EventArgs e) {
            selectUnselect(true);
        }

        private void btnDeselectAll_Click(object sender, EventArgs e) {
            selectUnselect(false);
        }
        void Aggiorna() {
            this.Cursor = Cursors.WaitCursor;
            clearAll();
            clearGrid();
            popolaTab();
            riempiGrid();
            this.Cursor = Cursors.Default;
        }
        private void btnRefresh_Click(object sender, EventArgs e) {
            Aggiorna();
        }

        private void selectUnselect(bool seleziona) {
            string dataMember = dgAnagrafica.DataMember;
            CurrencyManager cm = dgAnagrafica.BindingContext[DS, dataMember] as CurrencyManager;
            if (cm == null) return;
            DataView view = cm.List as DataView;
            if (view == null) {
                MessageBox.Show(this, "Selezionare una anagrafica");
                return;
            }

            for (int i = 0; i < view.Count; i++) {
                if (seleziona) {
                    if (!dgAnagrafica.IsSelected(i)) {
                        dgAnagrafica.Select(i);
                    }
                }
                else {
                    if (dgAnagrafica.IsSelected(i)) {
                        dgAnagrafica.UnSelect(i);
                    }
                }
            }
        }

        private void btnElimina_Click(object sender, EventArgs e) {
            btnElimina.Enabled = false;
            Do_Delete();
            btnElimina.Enabled = true;
        }
    }
}