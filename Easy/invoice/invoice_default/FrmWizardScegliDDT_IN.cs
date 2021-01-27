
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

namespace invoice_default {
    public partial class FrmWizardScegliDDT_IN : Form {
        DataAccess Conn;
        string filter;
        MetaData Meta;
        DataSet DS;
        QueryHelper QHS;
        CQueryHelper QHC;
        public DataRow[] SelectedRows = null;
       
        public FrmWizardScegliDDT_IN(string filter, MetaData Meta, DataSet DS) {
            InitializeComponent();
            this.filter = filter;
            this.Meta = Meta;
            this.Conn = Meta.Conn;
            this.DS= DS;
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            ContextMenu ExcelMenu;
            ExcelMenu = new ContextMenu();
            ExcelMenu.MenuItems.Add("Excel", new EventHandler(Excel_Click));
            gridDettagli.ContextMenu = ExcelMenu;
            RiempiGrid();

            FormInit();

        }

        public DataRow[] GetSelectedRows() {
            return null;
        }
        private void Excel_Click (object menusender, EventArgs e) {
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
        void FormInit () {
            CustomTitle = "Creazione fattura da bolla";
            tabController.HideTabsMode =
                Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;

            //Selects first tab
            DisplayTabs(0);
        }
        void DisplayTabs (int newTab) {
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
        void StandardChangeTab (int step) {
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
        bool CustomChangeTab (int oldTab, int newTab) {
            if ((oldTab == 0) && (newTab == 1)) return ScegliDocs();
            if ((oldTab == 1) && (newTab == 2)) return true;
            return true;
        }


        private void btnBack_Click (object sender, System.EventArgs e) {
            StandardChangeTab(-1);
        }

        private void btnNext_Click (object sender, System.EventArgs e) {
            StandardChangeTab(+1);
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
       
        void SelezionaTutto () {
            object dataSource = gridDettagli.DataSource;
            if (dataSource == null) return;

            CurrencyManager cm = (CurrencyManager)
                gridDettagli.BindingContext[dataSource, gridDettagli.DataMember];

            DataView view = cm.List as DataView;

            if (view != null) {
                for (int i = 0; i < view.Count; i++) {
                    gridDettagli.Select(i);
                }
            }
        }
        private void btnSelezionaTutto_Click (object sender, System.EventArgs e) {
            SelezionaTutto();
        }

        void RiempiGrid () {
            string filterstock = QHS.IsNull("idinvkind");

            string sqlCmd = " SELECT * " +
                " FROM ddt_inview " +
                " WHERE " + filter +
                " AND EXISTS (SELECT * FROM stock WHERE " +
                " ddt_inview.idddt_in = stock.idddt_in AND " + filterstock + " ) " +
                " ORDER BY ddt_inview.idddt_in asc ";

            DataTable ddt_in = Meta.Conn.SQLRunner(sqlCmd);

            if (ddt_in.Rows.Count != 0) {
                ddt_in.PrimaryKey = new DataColumn[] { ddt_in.Columns["idddt_in"] };
                //Ora ha messo in ddt_in tutto ciò che da DB risulta 'da fatturare'.
                if (ddt_in.Select().Length > 0) {
                    MetaData MAP;
                    MAP = Meta.Dispatcher.Get("ddt_inview");
                    MAP.DescribeColumns(ddt_in, "default");
                    DataSet D = new DataSet();
                    D.Tables.Add(ddt_in);
                    HelpForm.SetDataGrid(gridDettagli, ddt_in);
                    gridDettagli.TableStyles.Clear();
                    HelpForm.SetGridStyle(gridDettagli, ddt_in);
                    formatgrids format = new formatgrids(gridDettagli);
                    format.AutosizeColumnWidth();
                    HelpForm.SetAllowMultiSelection(ddt_in, true);
                    SelezionaTutto();
                }
            }
        }

        bool ScegliDocs () {
            SelectedRows = GetGridSelectedRows(gridDettagli);
            if ((SelectedRows == null) || (SelectedRows.Length == 0)) {
                MessageBox.Show("Non è stata selezionata alcuna bolletta.");
                return false;
            }
            if (SelectedRows.Length > 1)
                labelMsg.Text = "Saranno aggiunte alla fattura " + SelectedRows.Length.ToString() + " bollette.";
            else
                labelMsg.Text = "Sarà aggiunta alla fattura una bolletta.";
            return true;
        }
        private DataRow[] GetGridSelectedRows (DataGrid G) {
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

        DataRow GetGridRow (DataGrid G, int index) {
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet)G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            string filter;
            filter = QHC.CmpEq("idddt_in", G[index, 0]);

            DataRow[] selectresult = MyTable.Select(filter);
            return selectresult[0];
        }

       
     }
}
