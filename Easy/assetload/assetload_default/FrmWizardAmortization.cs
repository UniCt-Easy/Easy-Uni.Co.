
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
using funzioni_configurazione;
using metadatalibrary;

namespace assetload_default {
    public partial class FrmWizardAmortization : Form {
        MetaData Meta;
        DataAccess Conn;
        ContextMenu ExcelMenu;
        public DataTable AssetAmortization;
        public object CodInv;
        CQueryHelper QHC;
        QueryHelper QHS;

        public FrmWizardAmortization(MetaData Meta, object CodiceInventario) {
            InitializeComponent();

            this.Meta = Meta;
            QHC = new CQueryHelper();
            QHS = this.Meta.Conn.GetQueryHelper();
            CodInv = CodiceInventario;
            Conn = Meta.Conn;
            ExcelMenu = new ContextMenu();
            ExcelMenu.MenuItems.Add("Excel", new EventHandler(Excel_Click));
            gridBeni.ContextMenu = ExcelMenu;
            FormInit();
        }
        private void Excel_Click(object menusender, EventArgs e) {
            if (menusender == null) return;
            if (!(typeof(MenuItem).IsAssignableFrom(menusender.GetType()))) return;
            object sender = ((MenuItem)menusender).Parent.GetContextMenu().SourceControl;
            if (!(typeof(DataGrid).IsAssignableFrom(sender.GetType()))) return;
            DataGrid G = (DataGrid)sender;
            object DDS = G.DataSource;
            if (DDS == null) return;
            if (!typeof(DataSet).IsAssignableFrom(DDS.GetType())) return;
            string DDT = G.DataMember;
            if (DDT == null) return;
            DataTable T = ((DataSet)DDS).Tables[DDT];
            if (T == null) return;
            exportclass.DataTableToExcel(T, true);
        }

        string CustomTitle;
        void FormInit() {
            CustomTitle = "Rivalutazioni Cespiti";
            tabController.HideTabsMode =
                Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;

            DataTable Manager = Conn.CreateTableByName("manager", "*");
            GetData.MarkToAddBlankRow(Manager);
            GetData.Add_Blank_Row(Manager);
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, Manager, "title asc", null, null, true);
            cboResponsabile.DataSource = Manager;
            cboResponsabile.DisplayMember = "title";
            cboResponsabile.ValueMember = "idman";

            DataTable Inventory = Conn.CreateTableByName("inventory", "*");
            GetData.MarkToAddBlankRow(Inventory);
            GetData.Add_Blank_Row(Inventory);
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, Inventory, "description asc", "(active='S')", null, true);
            cmbInventario.DataSource = Inventory;
            cmbInventario.DisplayMember = "description";
            cmbInventario.ValueMember = "idinventory";
            if (CodInv != null && CodInv != DBNull.Value) {
                cmbInventario.SelectedValue = CodInv;
                cmbInventario.Enabled = false;
            }
            //Selects first tab
            DisplayTabs(0);
        }

        void DisplayTabs(int newTab) {
            tabController.SelectedIndex = newTab;
            //Evaluates Buttons Appearance
            btnBack.Visible = (newTab > 0);
            if (newTab == tabController.TabPages.Count - 1)
                btnNext.Text = "Fine.";
            else
                btnNext.Text = "Avanti >";
            Text = CustomTitle + " (Pagina " + (newTab + 1) + " di " + tabController.TabPages.Count + ")";
        }
        /// <summary>
        /// Changes tab backward/forward
        /// </summary>
        /// <param name="step"></param>
        void StandardChangeTab(int step) {
            int oldTab = tabController.SelectedIndex;
            int newTab = oldTab + step;
            if ((newTab < 0) || (newTab > tabController.TabPages.Count)) return;
            if (!CustomChangeTab(oldTab, newTab)) return;
            if (newTab == tabController.TabPages.Count) {
                DialogResult = DialogResult.OK;
                return;
            }
            DisplayTabs(newTab);
        }
        /// <summary>
        /// Must return true if operation is possible, and do any
        ///  operation related to change from tab oldTab to newTab
        /// </summary>
        /// <param name="oldTab"></param>
        /// <param name="newTab"></param>
        /// <returns></returns>
        bool CustomChangeTab(int oldTab, int newTab) {
            if ((oldTab == 0) && (newTab == 1)) return GetFiltro();
            return true;
        }

        private void btnBack_Click(object sender, System.EventArgs e) {
            StandardChangeTab(-1);
        }

        private void btnNext_Click(object sender, System.EventArgs e) {
            if (tabController.SelectedIndex == tabController.TabPages.Count - 1)

                SaveData();

            StandardChangeTab(+1);
        }
        bool GetFiltro() {
            string Filtro = "";

            if (txtIDUbicazione.Text != "") {
                Filtro = QHS.CmpEq("idcurrlocation", txtIDUbicazione.Text);
            }
            if (cboResponsabile.SelectedIndex > 0) {
                Filtro = QHS.AppAnd(Filtro, QHS.CmpEq("idcurrman", cboResponsabile.SelectedValue));
            }

            if (txt_idbene_da.Text.Trim() != "") {
                int N1 = CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int), txt_idbene_da.Text, "x.y"));
                if (N1 > 0) {
                    Filtro = QHS.AppAnd(Filtro, QHS.CmpGe("idasset", N1));
                }
            }
            if (txt_idbene_a.Text.Trim() != "") {
                int N2 = CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int), txt_idbene_a.Text, "x.y"));
                if (N2 > 0) {
                    Filtro = QHS.AppAnd(Filtro, QHS.CmpLe("idasset", N2));
                }
            }
            if (txt_numcarico_da.Text.Trim() != "") {
                int N3 = CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int), txt_numcarico_da.Text, "x.y"));
                if (N3 > 0) {
                    Filtro = QHS.AppAnd(Filtro, QHS.CmpGe("nassetacquire", N3));
                }
            }
            if (txt_numcarico_a.Text.Trim() != "") {
                int N4 = CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int), txt_numcarico_a.Text, "x.y"));
                if (N4 > 0) {
                    Filtro = QHS.AppAnd(Filtro, QHS.CmpLe("nassetacquire", N4));
                }
            }

            if (txt_numinv_da.Text.Trim() != "") {
                int N5 = CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int), txt_numinv_da.Text, "x.y"));
                if (N5 > 0) {
                    Filtro = QHS.AppAnd(Filtro, QHS.CmpGe("ninventory", N5));
                }
            }
            if (txt_numinv_a.Text.Trim() != "") {
                int N6 = CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int), txt_numinv_a.Text, "x.y"));
                if (N6 > 0) {
                    Filtro = QHS.AppAnd(Filtro, QHS.CmpLe("ninventory", N6));
                }
            }
            if (cmbInventario.SelectedIndex > 0) {
                Filtro = QHS.AppAnd(Filtro,
                    "(namortization in (SELECT namortization from assetamortization " +
                    " WHERE " + GetInventoryFilter(QHS, cmbInventario.SelectedValue) +
                    //QHS.CmpEq("idinventory", cmbInventario.SelectedValue) +
                    "))");

            }
            if (txtDescrizione.Text.Trim() != "") {
                string descr = txtDescrizione.Text.Trim();
                if (!descr.StartsWith("%")) descr = "%" + descr;
                if (!descr.EndsWith("%")) descr = descr + "%";
                Filtro = QHS.AppAnd(Filtro, QHS.Like("description", descr + "%"));
            }
            if (Filtro == "") {
                if (MessageBox.Show("Non è stato selezionato alcun filtro. Conferma?",
                    "Conferma", MessageBoxButtons.OKCancel) != DialogResult.OK) return false;
            }
            if (!chkIncludiAsset.Checked && chkIncludiAumenti.Checked) {
                Filtro = QHS.AppAnd(Filtro, QHS.CmpGt("idpiece", 1));
            }
            if (chkIncludiAsset.Checked && !chkIncludiAumenti.Checked) {
                Filtro = QHS.AppAnd(Filtro, QHS.CmpEq("idpiece", 1));
            }
            Filtro = QHS.AppAnd(Filtro, QHS.IsNull("idassetload"),
                                        QHS.IsNull("idassetunload"),
                                        QHS.CmpEq("flagunload", 'S'),
                                        QHS.CmpGt("amortizationquota", 0)
                                );

            AssetAmortization = Conn.RUN_SELECT("assetamortizationunloadview", "*", "idinventory asc,ninventory asc",
                Filtro, null, false);

            MetaData MAP = Meta.Dispatcher.Get("assetamortizationunloadview");
            MAP.DescribeColumns(AssetAmortization, "default");
            DataSet D = new DataSet();
            D.Tables.Add(AssetAmortization);
            gridBeni.DataSource = null;
            HelpForm.SetDataGrid(gridBeni, AssetAmortization);
            HelpForm.SetAllowMultiSelection(AssetAmortization, true);
            SelezionaTuttiICespiti();
            return true;
        }

        private string GetInventoryFilter(QueryHelper QH, object codInventario) {
            string filter = "";
            string filterInv = QH.CmpEq("idinventory", codInventario);
            string SQLfilterInv = QHS.CmpEq("idinventory", codInventario);

            int flag = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("inventory", SQLfilterInv, "flag"));
            bool flagMixed = ((flag & 2) != 0);

            if (flagMixed) {

                // Se il flag vale S, non devo filtrare i carichi sull'inventario ma solo sull'ente Inventariale
                object inventoryAgency = Meta.Conn.DO_READ_VALUE("inventory", SQLfilterInv, "idinventoryagency");
                string filterEnte = QHS.CmpEq("idinventoryagency", inventoryAgency);
                DataTable ListInvEnte = Meta.Conn.RUN_SELECT("inventory", "*", null, filterEnte, null, false);
                if (ListInvEnte.Rows.Count > 0) {
                    if (ListInvEnte.Rows.Count != 0) {
                        filter = QH.FieldIn("idinventory", ListInvEnte.Select());
                    }
                    else {
                        filter = filterInv;
                    }
                }
                else {
                    filter = filterInv;
                }
            }
            else {

                filter = filterInv;
            }
            return filter;
        }


        private DataRow[] GetGridSelectedRows(DataGrid G) {
            if (G.DataMember == null) return null;
            if (G.DataSource == null) return null;
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet)G.DataSource;
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

        DataRow GetGridRow(DataGrid G, int index) {
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet)G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            string filter = ""; ;
            filter = QHC.CmpEq("namortization", G[index, 0]);
            DataRow[] selectresult = MyTable.Select(filter);
            return selectresult[0];
        }
        void SaveData() {
            if (gridBeni.DataSource == null) return;
            string T = gridBeni.DataMember.ToString();
            DataSet DS = (DataSet)gridBeni.DataSource;
            DataTable DgrTable = DS.Tables[T];
            DataTable MyTable = DgrTable.Copy();
            DataColumn idColumn = new DataColumn();
            idColumn.DataType = System.Type.GetType("System.String");
            idColumn.ColumnName = "flagsel";
            MyTable.Columns.Add("flagsel");
            int numrighe = MyTable.Rows.Count;
            int i;

            for (i = 0; i < numrighe; i++) {
                MyTable.Rows[i]["flagsel"] = "N";
            }

            DataRow[] RigheSelezionate = GetGridSelectedRows(gridBeni);
            if (RigheSelezionate.Length > 0) {

                foreach (DataRow R in RigheSelezionate) {
                    for (i = 0; i < numrighe; i++) {
                        if (MyTable.Rows[i]["namortization"].ToString() == R["namortization"].ToString()) {
                            MyTable.Rows[i]["flagsel"] = "S";
                        }
                    }
                }

                //for (i = 0; i < numrighe; i++)
                //{

                //    if (MyTable.Rows[i]["flagsel"].ToString() == "S" && MyTable.Rows[i]["idpiece"].ToString() == "1")
                //    {
                //        int j;
                //        for (j = 0; j < numrighe; j++)
                //        {
                //            if (MyTable.Rows[j]["idasset"].ToString() == MyTable.Rows[i]["idasset"].ToString() && (MyTable.Rows[j]["idpiece"].ToString() != "1") && MyTable.Rows[j]["flagsel"].ToString() == "N")
                //            {
                //                MyTable.Rows[j]["flagsel"] = "S";
                //            }
                //        }

                //    }
                //}
            }

            for (i = 0; i < numrighe; i++) {
                if (MyTable.Rows[i]["flagsel"].ToString() == "N")
                    DgrTable.Rows[i].Delete();
            }

            DgrTable.AcceptChanges();
        }

        private void tabIntro_PropertyChanged(Crownwood.Magic.Controls.TabPage page, Crownwood.Magic.Controls.TabPage.Property prop, object oldValue) {

        }

        private void txtUbicazione_Leave(object sender, System.EventArgs e) {
            if (txtUbicazione.Text.Trim() == "") {
                txtIDUbicazione.Text = "";
                txtUbicazione.Text = "";
                txtDescUbicazione.Text = "";
                return;
            }
            DoManage(true);

        }

        private void btnUbicazione_Click(object sender, System.EventArgs e) {
            DoManage(false);
        }

        void DoManage(bool StartFieldWanted) {
            MetaData M = Meta.Dispatcher.Get("locationview");
            M.FilterLocked = true;
            M.SearchEnabled = false;
            M.MainSelectionEnabled = true;
            M.StartFilter = null;
            if (StartFieldWanted) {
                M.startFieldWanted = "locationcode";
                M.startValueWanted = txtUbicazione.Text.Trim();
            }
            M.ExtraParameter = null;
            M.edit_type = "tree";
            M.DS = Meta.DS.Clone();

            bool res = M.Edit(null, "tree", true);
            if (!res) { //user canceled the operation
                return;
            }
            DataRow Selected = M.LastSelectedRow;
            if (Selected == null) return;
            txtIDUbicazione.Text = Selected["idlocation"].ToString();
            txtUbicazione.Text = Selected["locationcode"].ToString();
            txtDescUbicazione.Text = Selected["description"].ToString();

        }
        private void SelezionaTuttiICespiti() {
            object dataSource = gridBeni.DataSource;
            if (dataSource == null) return;

            CurrencyManager cm = (CurrencyManager)
                gridBeni.BindingContext[dataSource, gridBeni.DataMember];

            DataView view = cm.List as DataView;

            if (view != null) {
                for (int i = 0; i < view.Count; i++) {
                    gridBeni.Select(i);
                }
            }
        }

        private void btnSelezionaTutto_Click(object sender, System.EventArgs e) {
            SelezionaTuttiICespiti();
        }

       

    }
}
