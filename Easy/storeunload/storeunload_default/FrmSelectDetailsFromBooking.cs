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

namespace storeunload_default {
    public partial class FrmSelectDetailsFromBooking : Form {
        string filtersql;
        MetaData Meta;
        MetaDataDispatcher Disp;
        DataAccess Conn;
        vistaForm DS;
        QueryHelper QHS;
        CQueryHelper QHC;
        //private string Filtro = "";
        //DataRow RBooking;
        public DataRow[] SelectedRows = null;

        public FrmSelectDetailsFromBooking(MetaData Meta, string filtersql, vistaForm DS) {
            InitializeComponent();
            this.Meta = Meta;
            this.Conn = Meta.Conn;
            this.Disp = Meta.Dispatcher;
            this.filtersql = filtersql;
            this.DS = DS;
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();

            // Magazzino
            DataTable store = Conn.CreateTableByName("store", "*", false);
            DataSet D = new DataSet();
            D.Tables.Add(store);
            Conn.RUN_SELECT_INTO_TABLE(store, "description", filtersql, null, true);
            cmbMagazzino.DataSource = store;
            cmbMagazzino.ValueMember = "idstore";
            cmbMagazzino.DisplayMember = "description";
            HelpForm.SetComboBoxValue(cmbMagazzino, store.Rows[0]["idstore"]);
            cmbMagazzino.Enabled = false;
          
            // Responsabile
            DataTable manager = Conn.CreateTableByName("manager", "*", false);
            D.Tables.Add(manager);
            GetData.MarkToAddBlankRow(manager);
            GetData.Add_Blank_Row(manager);
            Conn.RUN_SELECT_INTO_TABLE(manager, "title", null, null, true);
            cmbResponsabile.DataSource = manager;
            cmbResponsabile.ValueMember = "idman";
            cmbResponsabile.DisplayMember = "title";

            Conn.DeleteAllUnselectable(manager); 
            //RiempiGrid();
            FormInit();
        }

        public DataRow []GetSelectedRows() {
            return null;
        }

        string CustomTitle;
        void FormInit(){
            CustomTitle = "Creazione Scarico Magazzino da Prenotazione";
            tabController.HideTabsMode =
            Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;

            //Selects first tab
            DisplayTabs(0);
        }

        void StandardChangeTab(int step){
            int oldTab = tabController.SelectedIndex;
            int newTab = oldTab + step;
            if ((newTab < 0) || (newTab > tabController.TabPages.Count)) return;
            if (!CustomChangeTab(oldTab, newTab)) return;
            if (newTab == tabController.TabPages.Count)
            {
                DialogResult = DialogResult.OK;
                return;
            }
            DisplayTabs(newTab);
        }

        void DisplayTabs(int newTab){
            tabController.SelectedIndex = newTab;
            //Evaluates Buttons Appearance
            btnBack.Visible = (newTab > 0);
            if (newTab == tabController.TabPages.Count - 1)
                btnNext.Text = "Fine.";
            else
                btnNext.Text = "Avanti >";
            Text = CustomTitle + " (Pagina " + (newTab + 1) + " di " + tabController.TabPages.Count + ")";
        }

        bool ScegliDocs(){
            SelectedRows = GetGridSelectedRows(gridDettagli);
            if ((SelectedRows == null) || (SelectedRows.Length == 0))
            {
                MessageBox.Show("Non Ë stato selezionato alcun dettaglio.");
                return false;
            }
            if (SelectedRows.Length > 1)
                labelMsg.Text = "Saranno aggiunti allo scarico magazzino " + SelectedRows.Length.ToString() + " dettagli.";
            else
                labelMsg.Text = "Sar‡ aggiunto allo scarico magazzino un dettaglio.";
            return true;
        }

        
        private DataRow[] GetGridSelectedRows(DataGrid G){
            if (G.DataMember == null) return null;
            if (G.DataSource == null) return null;
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet)G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            int numrighetemp = MyTable.Rows.Count;
            int numrighe = 0;
            int i;
            for (i = 0; i < numrighetemp; i++){
                if (G.IsSelected(i)){
                    numrighe++;
                }
            }

            DataRow[] Res = new DataRow[numrighe];
            int count = 0;
            for (i = 0; i < numrighetemp; i++){
                if (G.IsSelected(i)){
                    Res[count++] = GetGridRow(G, i);
                }
            }
            return Res;
        }

        DataRow GetGridRow(DataGrid G, int index){
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet)G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            string filter;
            filter = QHC.AppAnd(QHC.CmpEq("idbooking", G[index, 0]),QHC.CmpEq("idlist", G[index, 1]),
                                QHC.CmpEq("idstore", G[index, 2]));

            DataRow[] selectresult = MyTable.Select(filter);
            return selectresult[0];
        }
        
        bool CustomChangeTab(int oldTab, int newTab){
            if ((oldTab == 0) && (newTab == 1)) {
                string filtro= GetFiltro();
                RiempiGrid(filtro);
                return true;
            }
            if ((oldTab == 1) && (newTab == 2)) {
                return ScegliDocs();
            }

            return true;
        }

        private void btnBack_Click(object sender, EventArgs e){
            StandardChangeTab(-1);
        }

        private void btnNext_Click(object sender, EventArgs e){
            StandardChangeTab(+1);
        }

        private void btnSelezionaTutto_Click(object sender, EventArgs e){
            object dataSource = gridDettagli.DataSource;
            if (dataSource == null) return;

            CurrencyManager cm = (CurrencyManager)
                gridDettagli.BindingContext[dataSource, gridDettagli.DataMember];

            DataView view = cm.List as DataView;

            if (view != null){
                for (int i = 0; i < view.Count; i++){
                    gridDettagli.Select(i);
                }
            }
        }

        private string GetFiltro () {
            string Filtro = "";

            if (CfgFn.GetNoNullInt32(cmbMagazzino.SelectedValue) > 0) {
                Filtro = QHS.AppAnd(Filtro,QHS.CmpEq("idstore", cmbMagazzino.SelectedValue));
            }

            if (cmbResponsabile.SelectedIndex > 0) {
                Filtro = QHS.AppAnd(Filtro,QHS.CmpEq("idman", cmbResponsabile.SelectedValue));
            }

            if (txtEsercizio.Text.Trim() != "") {
                int N1 = CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int), txtEsercizio.Text, "x.year"));
                if (N1 > 0) {
                    Filtro = QHS.AppAnd(Filtro, QHS.CmpEq("ybooking", N1));
                }
            }

            if (txtNumero.Text.Trim() != "") {
                int N2 = CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int), txtNumero.Text, "x.y"));
                if (N2 > 0) {
                    Filtro = QHS.AppAnd(Filtro, QHS.CmpEq("nbooking", N2));
                }
            }
           
           Filtro = QHS.AppAnd(Filtro, QHS.CmpGt("allocated", 0));
           return Filtro;

        }
        object GetIDStore(object idstock) {
            return Conn.DO_READ_VALUE("stock", QHS.CmpEq("idstock", idstock), "idstore");
        }
        object GetIDList(object idstock) {
            return Conn.DO_READ_VALUE("stock", QHS.CmpEq("idstock", idstock), "idlist");
        }

        void RiempiGrid(string Filtro){
            //if (RBooking == null) return;
            //string keyfilter = QHS.CmpEq("idbooking", RBooking["idbooking"]);
            //string lista = "";
            foreach (DataRow rDetail in DS.storeunloaddetail.Rows) {
                if ((rDetail.RowState == DataRowState.Deleted)||(rDetail.RowState == DataRowState.Modified)) {
                    if (rDetail["idbooking", DataRowVersion.Original] != DBNull.Value)
                        Filtro = QHS.AppOr(QHS.DoPar(Filtro), 
                                 QHS.DoPar(QHS.CmpEq("idbooking", rDetail["idbooking", DataRowVersion.Original])));
                }
            }

            //Details contiene la vista delle righe interessate dalle prenotazioni associate allo scarico
            // ed in pi˘ quelle selezionate in base ai filtri
            DataTable Details = Conn.RUN_SELECT("booktotalview", "*", null, Filtro, null, false);
            
             if (Details.Rows.Count != 0) {
                 Details.PrimaryKey = new DataColumn[] { Details.Columns["idbooking"], Details.Columns["idlist"], Details.Columns["idstore"] };
                // Ora ha messo in Detail tutto ciÚ che da DB risulta 'da inserire nello scarico'.

                // Effettua ora una serie di allineamenti sul DataTable per renderlo pi˘ coerente con quello
                // che c'Ë nel DataSet del form padre.

                // Per ogni riga del DataSet in stato di INSERT/UPDATE effettua una sottrazione ed eventualmente
                // un delete su Detail se la riga corrispondente risulta essere esaurita.

                 //Esamina le righe cancellate da DS
                foreach (DataRow rDetail in DS.Tables["storeunloaddetail"].Rows) {
                    if (rDetail.RowState != DataRowState.Deleted) continue;
                    if (rDetail["idbooking", DataRowVersion.Original] == DBNull.Value) continue; 
                    decimal oldnumber = CfgFn.GetNoNullDecimal(rDetail["number", DataRowVersion.Original]);
                    string filter = 
                        QHC.AppAnd(
                          QHC.CmpEq("idstore",GetIDStore(rDetail["idstock",DataRowVersion.Original])),
                          QHC.CmpEq("idlist",GetIDList(rDetail["idstock",DataRowVersion.Original])),
                          QHC.CmpEq("idbooking", rDetail["idbooking",DataRowVersion.Original])
                          );
                    DataRow[] RM = Details.Select(filter);
                    if ((RM == null) || (RM.Length == 0)) continue;
                    DataRow Detail = RM[0];
                    decimal newnumber = 0;
                    decimal oldbooknumber = CfgFn.GetNoNullDecimal(Detail["number"]);

                    decimal oldallocated = CfgFn.GetNoNullDecimal(Detail["allocated"]);
                    decimal newallocated = oldallocated - newnumber + oldnumber;

                    decimal newbooknumber = oldbooknumber - newnumber + oldnumber;
                    Detail["number"] = newbooknumber;
                    Detail["allocated"] = newallocated;
                }

             //Esamina le righe aggiunte al DS
             foreach (DataRow rDetail in DS.Tables["storeunloaddetail"].Select()){
                    if (rDetail.RowState != DataRowState.Added) continue;
                    if (rDetail["idbooking"] == DBNull.Value) continue; 

                    //Non Ë una riga collegata a dettagli ordine
                    string filter =
                        QHC.AppAnd(
                          QHC.CmpEq("idstore", GetIDStore(rDetail["idstock"])),
                          QHC.CmpEq("idlist", GetIDList(rDetail["idstock"])),
                          QHC.CmpEq("idbooking", rDetail["idbooking"])
                          );

                    DataRow[] RM = Details.Select(filter);
                    if ((RM == null) || (RM.Length == 0)) continue;
                    DataRow Detail = RM[0];
                    decimal oldnumber = 0;
                    decimal newnumber = CfgFn.GetNoNullDecimal(rDetail["number", DataRowVersion.Current]);
                    decimal oldbooknumber = CfgFn.GetNoNullDecimal(Detail["number"]);

                    decimal oldallocated = CfgFn.GetNoNullDecimal(Detail["allocated"]);
                    decimal newallocated = oldallocated - newnumber + oldnumber;

                    decimal newbooknumber = oldbooknumber + newnumber - oldnumber;
                    Detail["number"] = newbooknumber;
                    Detail["allocated"] = newallocated;
                }

                foreach (DataRow rDetail in DS.Tables["storeunloaddetail"].Select()) {
                    if (rDetail.RowState != DataRowState.Modified) continue;
                    //Non Ë una riga collegata a dettagli ordine
                    string filter =
                        QHC.AppAnd(
                          QHC.CmpEq("idstore", GetIDStore(rDetail["idstock"])),
                          QHC.CmpEq("idlist", GetIDList(rDetail["idstock"])),
                          QHC.CmpEq("idbooking", rDetail["idbooking"])
                          );

                    DataRow[] RM = Details.Select(filter);
                    if ((RM == null) || (RM.Length == 0)) continue;
                    DataRow Detail = RM[0];
                    decimal oldnumber;
                    if (rDetail["idbooking", DataRowVersion.Original] == DBNull.Value)
                        oldnumber = 0;
                    else
                        oldnumber = CfgFn.GetNoNullDecimal(rDetail["number", DataRowVersion.Original]);

                    decimal newnumber;
                    if (rDetail["idbooking", DataRowVersion.Current] == DBNull.Value)
                        newnumber = 0;
                    else
                        newnumber = CfgFn.GetNoNullDecimal(rDetail["number", DataRowVersion.Current]);

                    decimal oldbooknumber = CfgFn.GetNoNullDecimal(Detail["number"]);
                    decimal newbooknumber = oldbooknumber - newnumber + oldnumber;

                    decimal oldallocated = CfgFn.GetNoNullDecimal(Detail["allocated"]);
                    decimal newallocated = oldallocated - newnumber + oldnumber;

                    Detail["number"] = newbooknumber;
                    Detail["allocated"] = newallocated;
                }

                foreach (DataRow rDetail in Details.Select()){
                    if (CfgFn.GetNoNullDecimal(rDetail["allocated"]) == 0) rDetail.Delete();
                }

                Details.AcceptChanges();
                if (Details.Select().Length > 0) {
                    MetaData MAP = Meta.Dispatcher.Get("booktotalview");
                    MAP.DescribeColumns(Details, "default");
                    DataSet D = new DataSet();
                    D.Tables.Add(Details);
                    HelpForm.SetDataGrid(gridDettagli, Details);
                    gridDettagli.TableStyles.Clear();
                    HelpForm.SetGridStyle(gridDettagli, Details);
                    formatgrids format = new formatgrids(gridDettagli);
                    format.AutosizeColumnWidth();
                    HelpForm.SetAllowMultiSelection(Details, true);
                    SelezionaTutto();
                }
            }
        }

        void SelezionaTutto(){
            object dataSource = gridDettagli.DataSource;
            if (dataSource == null) return;

            CurrencyManager cm = (CurrencyManager)
                gridDettagli.BindingContext[dataSource, gridDettagli.DataMember];

            DataView view = cm.List as DataView;

            if (view != null)
            {
                for (int i = 0; i < view.Count; i++)
                {
                    gridDettagli.Select(i);
                }
            }
        }

        private void txtEsercizio_Leave (object sender, System.EventArgs e) {
            HelpForm.FormatLikeYear(txtEsercizio);
        }

        private void btnSeleziona_Click (object sender, EventArgs e) {
            /*
            RBooking = null;
            if (!GetFiltro()) return;
            RBooking = GetPrenotazione("default", Filtro);
            SelectBooking();*/
        }
		
    }
}