
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
    public partial class FrmSelectDetails : Form {
        string filtersql;
        MetaData Meta;
        DataAccess Conn;
        DataSet DS;
        QueryHelper QHS;
        CQueryHelper QHC;
        public DataRow[] SelectedRows = null;

        public FrmSelectDetails(MetaData Meta, string filtersql, DataSet DS) {
            InitializeComponent();
            this.Meta = Meta;
            this.Conn = Meta.Conn;
            this.filtersql = filtersql;
            this.DS = DS;
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();

            RiempiGrid();
            FormInit();
        }

        public DataRow []GetSelectedRows() {
            return null;
        }

        string CustomTitle;
        void FormInit(){
            CustomTitle = "Creazione Bolla di Ingresso  da Ordini";
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
                MessageBox.Show("Non è stato selezionato alcun dettaglio.");
                return false;
            }
            if (SelectedRows.Length > 1)
                labelMsg.Text = "Saranno aggiunti alla bolla " + SelectedRows.Length.ToString() + " dettagli.";
            else
                labelMsg.Text = "Sarà aggiunto alla bolla un dettaglio.";
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
            filter = QHC.AppAnd(QHC.CmpEq("idmankind", G[index, 0]),
                            QHC.CmpEq("yman", G[index, 2]),
                            QHC.CmpEq("nman", G[index, 3]),
                            QHC.CmpEq("idgroup", G[index, 4]));

            DataRow[] selectresult = MyTable.Select(filter);
            return selectresult[0];
        }

        bool CustomChangeTab(int oldTab, int newTab){
            if ((oldTab == 0) && (newTab == 1)) return ScegliDocs();
            if ((oldTab == 1) && (newTab == 2)) return true;

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

        void RiempiGrid(){
            DataTable MandateDetail =
            Conn.RUN_SELECT("mandatedetail_tostock", "*", "idmankind ASC,yman DESC,nman DESC, idgroup ASC",
            filtersql, null, false);

            Conn.DeleteAllUnselectable(MandateDetail);

            if (MandateDetail.Rows.Count != 0){
                MandateDetail.PrimaryKey = new DataColumn[]{MandateDetail.Columns["idmankind"],
															  MandateDetail.Columns["yman"],
															  MandateDetail.Columns["nman"],
															  MandateDetail.Columns["idgroup"]};
                //Ora ha messo in MandateDetail tutto ciò che da DB risulta 'da inserire nella bolla'.

                //Effettua ora una serie di allineamenti sul DataTable per renderlo più coerente con quello
                // che c'è nel DataSet del form padre.

                //Per ogni riga del DataSet in stato di INSERT/UPDATE effettua una sottrazione ed eventualmente
                // un delete su MandateDetail se la riga corrispondente risulta essere esaurita.
                foreach (DataRow rStock in DS.Tables["stock"].Select()){
                    if (rStock.RowState != DataRowState.Added) continue;
                    if (rStock["idmankind"] == DBNull.Value) continue; //Non è una riga collegata a dettagli ordine
                    string filtermand = QHC.CmpMulti(rStock, "idmankind", "yman", "nman");
                    filtermand = QHC.AppAnd(filtermand, QHC.CmpEq("idgroup", rStock["man_idgroup"]));

                    DataRow[] RM = MandateDetail.Select(filtermand);
                    if ((RM == null) || (RM.Length == 0)) continue;
                    DataRow Detail = RM[0];
                    decimal oldnumber = 0;
                    decimal newnumber = CfgFn.GetNoNullDecimal(rStock["number", DataRowVersion.Current]);
                    decimal oldstocked = CfgFn.GetNoNullDecimal(Detail["stocked"]);
                    decimal newstocked = oldstocked + newnumber - oldnumber;
                    Detail["stocked"] = newstocked;
                }

                foreach (DataRow rStock in DS.Tables["stock"].Select()){
                    if (rStock.RowState != DataRowState.Modified) continue;
                    string filtermand = QHC.CmpMulti(rStock, "idmankind", "yman", "nman");
                    filtermand = QHC.AppAnd(filtermand, QHC.CmpEq("idgroup", rStock["man_idgroup"]));
                    DataRow[] RM = MandateDetail.Select(filtermand);
                    if ((RM == null) || (RM.Length == 0)) continue;
                    DataRow Detail = RM[0];
                    decimal oldnumber;
                    if (rStock["idmankind", DataRowVersion.Original] == DBNull.Value)
                        oldnumber = 0;
                    else
                        oldnumber = CfgFn.GetNoNullDecimal(rStock["number", DataRowVersion.Original]);

                    decimal newnumber;
                    if (rStock["idmankind", DataRowVersion.Current] == DBNull.Value)
                        newnumber = 0;
                    else
                        newnumber = CfgFn.GetNoNullDecimal(rStock["number", DataRowVersion.Current]);


                    decimal oldstocked = CfgFn.GetNoNullDecimal(Detail["stocked"]);
                    decimal newstocked = oldstocked + newnumber - oldnumber;
                    Detail["stocked"] = newstocked;
                }

                //foreach (DataRow rStock in DS.Tables["stock"].Rows){
                //    if (rStock.RowState != DataRowState.Deleted) continue;
                //    if (rStock["idmankind", DataRowVersion.Original] == DBNull.Value) continue;

                //    string filtermand = QHC.CmpMulti(rStock, "idmankind", "yman", "nman");
                //    filtermand = QHC.AppAnd(filtermand, QHC.CmpEq("idgroup", rStock["man_idgroup", DataRowVersion.Original]));

                //    DataRow[] RM = MandateDetail.Select(filtermand);
                //    if ((RM == null) || (RM.Length == 0)) continue;
                //    DataRow Detail = RM[0];
                //    decimal oldnumber = CfgFn.GetNoNullDecimal(rStock["number", DataRowVersion.Original]);
                //    decimal newnumber = 0;
                //    decimal oldstocked = CfgFn.GetNoNullDecimal(Detail["stocked"]);
                //    decimal newstocked = oldstocked + newnumber - oldnumber;
                //    Detail["stocked"] = newstocked;
                //}

                foreach (DataRow rMandatedetail in MandateDetail.Select()){
                    decimal stocked = CfgFn.GetNoNullDecimal(rMandatedetail["stocked"]);
                    decimal ordered = CfgFn.GetNoNullDecimal(rMandatedetail["ordered"]);
                    decimal ntostock = ordered - stocked;
                    rMandatedetail["ntostock"] = ntostock;
                    if (ntostock == 0) rMandatedetail.Delete();
                }

                MandateDetail.AcceptChanges();
                if (MandateDetail.Select().Length > 0){
                    MetaData MAP = Meta.Dispatcher.Get("mandatedetail_tostock");
                    MAP.DescribeColumns(MandateDetail, "default");
                    DataSet D = new DataSet();
                    D.Tables.Add(MandateDetail);
                    HelpForm.SetDataGrid(gridDettagli, MandateDetail);
                    gridDettagli.TableStyles.Clear();
                    HelpForm.SetGridStyle(gridDettagli, MandateDetail);
                    formatgrids format = new formatgrids(gridDettagli);
                    format.AutosizeColumnWidth();
                    HelpForm.SetAllowMultiSelection(MandateDetail, true);
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



    }
}
