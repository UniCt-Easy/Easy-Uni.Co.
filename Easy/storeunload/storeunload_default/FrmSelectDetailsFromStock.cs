
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
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;
using AskInfo;

namespace storeunload_default {
    public partial class FrmSelectDetailsFromStock : MetaDataForm {
        string filtersql;
        MetaData Meta;
        MetaDataDispatcher Disp;
        DataAccess Conn;
        DataSet DS;
        QueryHelper QHS;
        DataSet D;
        CQueryHelper QHC;
        MetaData MetaSorting;

        public DataRow RStock;
        public decimal quantita;
        public object idman;
        public DataRow[] SelectedRows = null;
        decimal prev_value = 0;
        decimal curr_value = 0;
        DataTable Sorting1;
        DataTable Sorting2;
        DataTable Sorting3;
        public Class_SelectionManager CSM1;
        public Class_SelectionManager CSM2;
        public Class_SelectionManager CSM3;

        DataSet DD;
        public FrmSelectDetailsFromStock(MetaData Meta, string filtersql, DataSet DS) {
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
            D = new DataSet();
            D.Tables.Add(store);
            Conn.RUN_SELECT_INTO_TABLE(store, "description",filtersql, null, true);
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

            MetaSorting = Disp.Get("sorting");

            FormInit();
            DD = new DataSet("a");
            Sorting1 = Conn.CreateTableByName("sorting","*");
            Sorting1.TableName = "sorting1";
            Sorting2 = Conn.CreateTableByName("sorting", "*");
            Sorting2.TableName = "sorting2";
            Sorting3 = Conn.CreateTableByName("sorting", "*");
            Sorting3.TableName = "sorting3";
            DD.Tables.Add(Sorting1);
            DD.Tables.Add(Sorting2);
            DD.Tables.Add(Sorting3);
            DD.EnforceConstraints = false;

            DataAccess.SetTableForReading(Sorting1, "sorting");
            DataAccess.SetTableForReading(Sorting2, "sorting");
            DataAccess.SetTableForReading(Sorting3, "sorting");

            string filter = "(ayear=" + QueryCreator.quotedstrvalue(Meta.GetSys("esercizio"), true) + ")";
            DataTable tExpSetup = Meta.Conn.RUN_SELECT("config", "*", null,
                  filter, null, null, true);
            if ((tExpSetup != null) && (tExpSetup.Rows.Count > 0)) {
                DataRow R = tExpSetup.Rows[0];
                string idsorkind1 = R["idsortingkind1"].ToString();
                string idsorkind2 = R["idsortingkind2"].ToString();
                string idsorkind3 = R["idsortingkind3"].ToString();
                SetGBoxClass(1, idsorkind1);
                SetGBoxClass(2, idsorkind2);
                SetGBoxClass(3, idsorkind3);

                if (idsorkind3 == "") {
                    grpAnalitico.Size = new System.Drawing.Size(366, 200);
                }
                if (idsorkind2 + idsorkind3 == "") {
                    grpAnalitico.Size = new System.Drawing.Size(366, 100);
                }
                if (idsorkind1 + idsorkind2 + idsorkind3 == "") {
                    grpAnalitico.Visible = false;
                }
                if (idsorkind1 != "") CSM1 = new Class_SelectionManager(Meta, txtCodice1, txtDenom1, R["idsortingkind1"]);
                if (idsorkind2 != "") CSM2 = new Class_SelectionManager(Meta, txtCodice2, txtDenom2, R["idsortingkind2"]);
                if (idsorkind3 != "") CSM3 = new Class_SelectionManager(Meta, txtCodice3, txtDenom3, R["idsortingkind3"]);

            }
        }

        void SetGBoxClass(int num, string sortingkind) {
            if (sortingkind == "") {
                GroupBox G = (GroupBox)GetCtrlByName("gboxclass" + num.ToString());
                G.Visible = false;
            }
            else {
                string filter = "(idsorkind=" +
                    QueryCreator.quotedstrvalue(sortingkind, true) + ")";
                GetData.SetStaticFilter(DD.Tables["sorting" + num.ToString()], filter);
                GroupBox gboxclass = (GroupBox)GetCtrlByName("gboxclass" + num.ToString());
                Button btnCodice = (Button)GetCtrlByName("btnCodice" + num.ToString());
                string title = Meta.Conn.DO_READ_VALUE("sortingkind", filter, "description").ToString();
                gboxclass.Text = title;
                gboxclass.Tag = "AutoManage.txtCodice" + num.ToString() + ".tree." + filter;
                btnCodice.Tag = "manage.sorting" + num.ToString() + ".tree." + filter;
                DD.Tables["sorting" + num.ToString()].ExtendedProperties[MetaData.ExtraParams] = filter;
            }
        }

        object GetCtrlByName(string Name) {
            System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
            if (Ctrl == null) return null;
            return Ctrl.GetValue(this);
        }

        public DataRow []GetSelectedRows() {
            return null;
        }

        string CustomTitle;
        void FormInit(){
            CustomTitle = "Creazione Scarico Magazzino da Stock";
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
            labelMsg.Text = "Sarà aggiunto allo scarico magazzino un dettaglio.";
            return true;
        }
        
        bool CustomChangeTab(int oldTab, int newTab){
            if ((oldTab == 0) && (newTab == 1)) {
                if (RStock == null) {
                    show("Selezionare la Merce da Scaricare");
                    return false;
                }
                else {
                    quantita = calcolaQuantita(RStock);
                    //txtQuantita.Text = quantita.ToString();
                    lblMsg2.Text = "Digitare la quantità da scaricare " + " (MAX " + quantita.ToString() + ")";
                }
                return true;
            }
            if ((oldTab == 1) && (newTab == 2)) {
                decimal number = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(decimal), 
                                                        txtQuantita.Text, "x.y"));
                if (number > quantita) {
                    show("Quantità superiore alla disponibilità consentità. Digitare un valore inferiore");
                    return false;
                }
                else {
                    labelMsg.Text = "Sarà scaricata la quantità " + txtQuantita.Text;
                    quantita = number;
                }
                if (cmbResponsabile.SelectedIndex > 0){
                    idman = cmbResponsabile.SelectedValue;
                }
                return true;
            }

            return true;
        }

        private void btnBack_Click(object sender, EventArgs e){
            StandardChangeTab(-1);
        }

        private void btnNext_Click(object sender, EventArgs e){
            StandardChangeTab(+1);
        }

        private string GetFiltroStock () {
            string Filtro = "";

            if (cmbMagazzino.SelectedIndex >= 0) {
                Filtro = QHS.CmpEq("idstore", cmbMagazzino.SelectedValue);
            }
            Filtro = QHS.AppAnd(Filtro, QHS.CmpGt("isnull(number,0) - isnull(booked,0)", 0));
            return Filtro;
        }

        private void btnListino_Click (object sender, EventArgs e) {
            RStock = null;
            string Filtro = GetFilterListino(false);
            string FiltroStock = GetFiltroStock();
            RStock = GetStock("default", QHS.AppAnd(Filtro, FiltroStock));
            if (RStock != null) {
                riempiControlliMagazzino(RStock);
            }
        }

        private string GetFilterListino(bool getCodeList) {
            string filter = "";
            int nFilter = 0;
            string field = "list";
            if (getCodeList) field = "description";

            //Filtro sulla classificazione merceologica
            if (chkFilterClass.Checked) {
                nFilter = 1;
            }

            //Filtro sulla descrizione
            if (chkListDescription.Checked) {
                nFilter = nFilter + 2;
            }
            
            if (nFilter > 0) {
                FrmAskDescr FR = new FrmAskDescr(Meta.Dispatcher, nFilter);
                DialogResult D = FR.ShowDialog(this);
                if (D == DialogResult.OK) {
                    if (FR.Selected != null) {
                        object idlistclass = FR.Selected["idlistclass"];
                        filter = GetData.MergeFilters(filter,
                                "(idlistclass =  " +
                                QueryCreator.quotedstrvalue(FR.Selected["idlistclass"], true) + ")");
                    }
                    filter = GetData.MergeFilters(filter,
                         "(" + field + " like "
                         + QueryCreator.quotedstrvalue("%" + FR.txtDescrizione.Text + "%", true) + ")");
                }
                }

            if ((txtCodListino.Text.Trim() != "") && (getCodeList)){
                string intcode = txtCodListino.Text.Trim();
                filter = QHS.AppAnd(filter, QHS.CmpEq("intcode", intcode));
            }
            
            return filter;
        }

        private string GetListino (bool getCodeList) {
            string filter = GetFilterListino(getCodeList);
            MetaData Mlistino = Disp.Get("listview");
            Mlistino.FilterLocked = true;
            Mlistino.DS = DS.Clone();
            
            DataRow Choosen = Mlistino.SelectOne("default", filter, "listview", null);
            if (Choosen == null) return filter;
            riempiOggetti(Choosen);
            return filter;
        }

        private decimal calcolaQuantita(DataRow RStock) {
             object idstore =RStock["idstore"];
             object idlist  = RStock["idlist"]; 
             string keyfilter = QHS.AppAnd(QHS.CmpEq("idstore", idstore),
                                           QHS.CmpEq("idlist", idlist));

             decimal number = CfgFn.GetNoNullDecimal(RStock["number"]) - 
                              CfgFn.GetNoNullDecimal(RStock["booked"]);

            prev_value = 0;
            curr_value = 0;

             foreach (DataRow rDetail in DS.Tables["storeunloaddetail"].Rows) {
                 if (rDetail.RowState != DataRowState.Deleted) continue;

                 if (rDetail["idbooking",DataRowVersion.Original] != DBNull.Value) continue;

                 object idstock = rDetail["idstock", DataRowVersion.Original];
                 // verifico se lo stock è collegato alla coppia voce listino - magazzino
                 int rowsfound = Conn.RUN_SELECT_COUNT("stock",
                                 QHS.AppAnd(keyfilter,QHS.CmpEq("idstock", idstock)), true);
                 if (rowsfound == 0) continue;
                 prev_value  += CfgFn.GetNoNullDecimal(rDetail["number", DataRowVersion.Original]);
             }

             foreach (DataRow rDetail in DS.Tables["storeunloaddetail"].Select()) {
                 if (rDetail.RowState != DataRowState.Modified) 
                     continue;
                 if (rDetail["idbooking"] != DBNull.Value) continue;

                    object idstock = rDetail["idstock"];
                    // verifico se lo stock è collegato alla coppia voce listino - magazzino
                    int rowsfound = Conn.RUN_SELECT_COUNT("stock",
                                    QHS.AppAnd(keyfilter, QHS.CmpEq("idstock", idstock)), true);
                    if (rowsfound == 0) continue;
                    prev_value += CfgFn.GetNoNullDecimal(rDetail["number", DataRowVersion.Original]);
                    curr_value += CfgFn.GetNoNullDecimal(rDetail["number", DataRowVersion.Current]);
             }

             foreach (DataRow rDetail in DS.Tables["storeunloaddetail"].Select()) {
                    if (rDetail.RowState != DataRowState.Added) continue;
                    if (rDetail["idbooking"] != DBNull.Value) continue;

                    object idstock = rDetail["idstock"];
                    // verifico se lo stock è collegato alla coppia voce listino - magazzino
                    int rowsfound = Conn.RUN_SELECT_COUNT("stock",
                                    QHS.AppAnd(keyfilter, QHS.CmpEq("idstock", idstock)), true);
                    if (rowsfound == 0) continue;
                    curr_value += CfgFn.GetNoNullDecimal(rDetail["number", DataRowVersion.Current]);
             }
             quantita = number + prev_value - curr_value;
             return quantita;
        }

    
        private void riempiOggetti (DataRow listRow) {
            txtCodListino.Text = (listRow != null) ? listRow["intcode"].ToString() : "";
            txtDescrizione.Text = (listRow != null) ? listRow["description"].ToString() : "";
        }

        private void riempiControlliMagazzino (DataRow R) {
        
            if(R==null) return;
            txtCodListino.Text = R["intcode"].ToString();
            txtDescrizione.Text = R["list"].ToString();
            txtCodListino2.Text = R["intcode"].ToString();
            txtDescListino2.Text = R["list"].ToString();
            txtClassificazione.Text = R["listclass"].ToString();
            decimal number = CfgFn.GetNoNullDecimal(R["number"]);
            decimal booked = CfgFn.GetNoNullDecimal(R["booked"]);
            txtNumber.Text = number.ToString();
            decimal ordered =  CfgFn.GetNoNullDecimal(R["ordered"]);
            decimal  number_got = CfgFn.GetNoNullDecimal( Conn.DO_READ_VALUE("stock",
                        QHS.AppAnd(QHS.CmpEq("idlist",R["idlist"]),QHS.CmpEq("idstore",R["idstore"]),
                                  QHS.IsNotNull("idmankind")  
                            ),
                                "SUM(number)"));
            decimal ordered_toget = ordered - number_got;
            txtOrdered.Text = ordered_toget.ToString("n");

            txtBooked.Text = booked.ToString();
            if ((number - booked) > 0) {
                decimal available = calcolaQuantita(R);
                txtDisponibile.Text = available.ToString();
            }
            else {
                txtDisponibile.Text = "";
            }
        }

        private DataRow GetStock (string listType, string filter) {
            MetaData MElenco = Disp.Get("stocktotalview");

            int rowsfound = Conn.RUN_SELECT_COUNT("stocktotalview", filter, true);
            if (rowsfound == 0) {
                show("Nessun elemento trovato");
                return null;
            }

            if (MElenco == null) return null;
            MElenco.FilterLocked = true;
            MElenco.DS = DS;
            DataRow R = MElenco.SelectOne("default", filter, null, null);
            return R;
        }


        private void ClearControlli () {
            txtDescrizione.Text = "";
            txtDisponibile.Text = "";
            txtNumber.Text = "";
            txtOrdered.Text = "";
            txtQuantita.Text = "";
            txtCodListino2.Text = "";
            txtDescListino2.Text = "";
            txtBooked.Text = "";
        }

        private void txtCodListino_Leave (object sender, EventArgs e) {
            if (txtCodListino.Text.Trim() == "") {
                ClearControlli();
                RStock = null;
            }
            else {
                string Filtro = GetListino(true);
                string FiltroStock = GetFiltroStock();
                RStock = GetStock("default", QHS.AppAnd(Filtro, FiltroStock));
                if (RStock != null) {
                    riempiControlliMagazzino(RStock);
                }
            }
        }

        private void cmbResponsabile_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chiamaFormClass(string filtro, Class_SelectionManager CSM) {
            MetaSorting.FilterLocked = true;
            MetaSorting.SearchEnabled = false;
            MetaSorting.MainSelectionEnabled = true;
            MetaSorting.StartFilter = filtro;
            MetaSorting.ExtraParameter = filtro;
            //if ((currfilter_upb == null) || (currfilter_upb == "")) return;
            string edittype = "tree";

            bool res = MetaSorting.Edit(this, edittype, true);
            if (!res) return;
            DataRow Selected = MetaSorting.LastSelectedRow;
            CSM.SelectRow(Selected);
        }

        private void btnCodice_Click(Class_SelectionManager CSM) {
            string filterAll = QHS.CmpEq("idsorkind",CSM.idsorkind);

            chiamaFormClass(filterAll,CSM);
        }

        private void btnCodice1_Click(object sender, EventArgs e) {
            btnCodice_Click(CSM1);
        }

        private void btnCodice2_Click(object sender, EventArgs e) {
            btnCodice_Click(CSM2);
        }

        private void btnCodice3_Click(object sender, EventArgs e) {
            btnCodice_Click(CSM3);
        }
       
    }
     public class Class_SelectionManager : Generic_SelectionManager {
            TextBox TTitle;
            public object idsorkind;
            public Class_SelectionManager(MetaData Meta, TextBox TxtCode, TextBox TxtTitle,object idsorkind)
                :
                        base(Meta, TxtCode, "sortcode", "idsor", "sorting") {
                this.TTitle = TxtTitle;
                this.idsorkind= idsorkind;
                SetFilter(QHS.CmpEq("idsorkind",idsorkind));
            }
            protected override void refillControls(DataRow R) {
                base.refillControls(R);
                if (TTitle != null) TTitle.Text = R["description"].ToString();
            }
            protected override void clearControls() {
                base.clearControls();
                if (TTitle != null) TTitle.Text = "";
            }
        }
}
