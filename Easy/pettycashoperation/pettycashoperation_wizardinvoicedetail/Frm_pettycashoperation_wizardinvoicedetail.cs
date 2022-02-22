
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
using metaeasylibrary;
using funzioni_configurazione;
using movimentofunctions;
using System.Globalization;
using ep_functions;
using System.Collections;


namespace pettycashoperation_wizardinvoicedetail{
    public partial class Frm_pettycashoperation_wizardinvoicedetail : MetaDataForm {
        MetaData Meta;
        DataAccess Conn;
        string CustomTitle;
        DataSet DSCopy;

        int fasefattura;
        //int choosenParentPhase = 0;
        ArrayList DetailsToUpdate;
        QueryHelper QHS;
        CQueryHelper QHC;
        DataTable Info = new DataTable();
        DataTable Tpettycashoperation;
        public Frm_pettycashoperation_wizardinvoicedetail()        {
            InitializeComponent();
            tabController.HideTabsMode = Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;
            Info.TableName = "Info";

            Info.Columns.Add("idupb", typeof(string));   
            Info.Columns["idupb"].Caption = ".";
            Info.Columns.Add("codeupb", typeof(string));

            Info.Columns["codeupb"].Caption = "UPB";
            Info.Columns.Add("idman", typeof(int));         
            Info.Columns["idman"].Caption = ".";
            Info.Columns.Add("manager", typeof(string));
            Info.Columns["manager"].Caption = "Responsabile";

            Info.Columns.Add("idfin", typeof(int));
            Info.Columns["idfin"].Caption = ".";
            Info.Columns.Add("codefin", typeof(string));
            Info.Columns["codefin"].Caption = "Bilancio";

            Info.Columns.Add("idexp", typeof(int));
            Info.Columns["idexp"].Caption = ".";

            Info.Columns.Add("nmov", typeof(string));
            Info.Columns["nmov"].Caption = "N.Mov";

            Info.Columns.Add("ymov", typeof(string));
            Info.Columns["ymov"].Caption = "Eserc.Mov";

            Info.Columns.Add("amount", typeof(decimal));
            Info.Columns["amount"].Caption = "Importo";

            DS.Tables.Add(Info); 
        }

        public void MetaData_AfterActivation(){
            CustomTitle = "Wizard Contabilizzazione Dettagli Fattura Acquisto con Fondo Economale";
            DisplayTabs(0);
        }

        void DisplayTabs(int newTab){
            tabController.SelectedIndex = newTab;
            //Evaluates Buttons Appearance
            btnBack.Visible = (newTab > 0);
            if (newTab == tabController.TabPages.Count - 1)
                btnNext.Text = "Esegui.";
            else
                btnNext.Text = "Next >";
            Text = CustomTitle + " (Pagina " + (newTab + 1) + " di " + tabController.TabPages.Count + ")";
        }

        void StandardChangeTab(int step){
            int oldTab = tabController.SelectedIndex;
            int newTab = oldTab + step;
            if ((newTab < 0) || (newTab > tabController.TabPages.Count)) return;
            if (!CustomChangeTab(oldTab, newTab)) return;
            if (newTab == tabController.TabPages.Count){
                btnNext.Visible = false;
                btnBack.Visible = false;
                btnCancel.Text = "Chiudi";
                return;
            }
            if ((oldTab == 4) && (newTab == 3))
            {
                newTab = 1;
                ResetWizard();
            }
            DisplayTabs(newTab);
        }

        object[] ValoriDiversi(DataRow[] Rows, string field){
            object[] DIV = new object[Rows.Length];
            int N = 0;
            foreach (DataRow R in Rows)
            {
                object currval = R[field];
                int j = 0;
                for (j = 0; j < N; j++)
                {
                    if (DIV[j].Equals(currval))
                    {
                        break;
                    }
                }
                if (j == N)
                {
                    DIV[N++] = currval;
                }
            }
            object[] result = new object[N];
            for (int i = 0; i < N; i++) result[i] = DIV[i];
            return result;
        }

        bool CustomChangeTab(int oldTab, int newTab){
            if (oldTab == 0){
                return true; // 0->1: nothing to do
            }
            if ((oldTab == 1) && (newTab == 0)){
                DS.pettycashoperationview.Clear();
                return true; //1->0:nothing to do!
            }
            if ((oldTab == 1) && (newTab == 2)) // 1->2
            {
                DataRow[] Selected = GetGridAllSelectedRows(gridDetails);
                // Sono sempre tutti selezionati
                if ((Selected == null) || (Selected.Length == 0))
                {
                    show("Selezionare la fattura da elaborare.");
                    return false;
                }
                SetGridAndInfo();
                
                return true;
            }
            if ((oldTab == 2) && (newTab == 1))// 1->2 torna indietro
            {
                VisualizzaUPB();
                AggiornaGridDettagliFattura();
                return true;
            }
            if ((oldTab == 2) && (newTab == 3)) // 2->3
            {
                if (!InfoComplete()) return false;
                return GeneraOperazioni();
            }
            if ((oldTab == 3) && (newTab == 4))//3->4
            {
                return true;
            }
             
            return true;
        }

        bool  GeneraOperazioni(){
            // Riempie il DataTable con le operazioni da generare e le mostra del Grid
            int esercizio = Convert.ToInt32(Meta.GetSys("esercizio"));
            object idpettycash = cmbFondoPS.SelectedValue;

            PostData.MarkAsTemporaryTable(DS.Tables["Info"], false);

            DataTable pettycashOpInserting = DS.Tables["Info"].Copy();
            if (pettycashOpInserting.Rows.Count == 0) return false;

            pettycashOpInserting.Columns.Add("idpettycash", typeof(string));
            pettycashOpInserting.Columns.Add("noperation", typeof(int));
            pettycashOpInserting.Columns.Add("yoperation", typeof(int));
            
            pettycashOpInserting.Columns.Add("description", typeof(string));
            pettycashOpInserting.Columns.Add("doc", typeof(string));
            pettycashOpInserting.Columns.Add("docdate", typeof(DateTime));

            pettycashOpInserting.Columns.Add("pettycode", typeof(string));
            pettycashOpInserting.Columns.Add("pettycash", typeof(string));
            pettycashOpInserting.Columns.Add("finance", typeof(string));
            pettycashOpInserting.Columns.Add("upb", typeof(string));

            foreach (DataRow R in pettycashOpInserting.Select()) {
                R["description"] = txtDescrizione.Text;
                R["doc"] = txtDocumento.Text;
                R["idpettycash"] = idpettycash;
                R["yoperation"] = Meta.GetSys("esercizio");
                if (txtDataDoc.Text != ""){
                    R["docdate"] = Convert.ToDateTime(txtDataDoc.Text);
                }
                else{
                    R["docdate"] = DBNull.Value;
                }
                R["pettycode"] = DS.pettycash.Select(QHC.CmpEq("idpettycash",idpettycash))[0]["pettycode"];
                R["pettycash"] = DS.pettycash.Select(QHC.CmpEq("idpettycash", idpettycash))[0]["description"];
                R["finance"] = Conn.DO_READ_VALUE("fin", QHC.CmpEq("idfin", R["idfin"]), "title");
                R["upb"] = Conn.DO_READ_VALUE("upb", QHC.CmpEq("idupb", R["idupb"]), "title");

            }
            FillTables(pettycashOpInserting);

            Tpettycashoperation = pettycashOpInserting.Copy();

            return true;
        }

        void FillTables(DataTable pettycashOpInserting){
            MetaDataDispatcher Disp;
            Disp = Meta.Dispatcher;

            DS.pettycashoperationview.Clear();
            for (int i = 0; i < pettycashOpInserting.Rows.Count; i++){
                DataRow R = pettycashOpInserting.Rows[i];
                AddRowToTable(R, DS.pettycashoperationview, i);
            }
            MetaData Mpettycashoperationview = Disp.Get("pettycashoperationview");// DA RIVEDERE 
            Mpettycashoperationview.DescribeColumns(DS.pettycashoperationview, "wizardinvoicedetail");// <-- DA RIVEDERE!

            HelpForm.SetDataGrid(gridMovSpesa, DS.pettycashoperationview);

            //RicalcolaCampiCalcolati();
        }

        void AddRowToTable(DataRow R, DataTable T, int i){
            DataRow NewR = T.NewRow();
            foreach (DataColumn C in R.Table.Columns) {
                if(C.ColumnName =="nmov")
                    NewR["!nmov"] = R["nmov"];
                if (C.ColumnName == "ymov")
                    NewR["!ymov"] = R["ymov"];

                if ((C.ColumnName == "idexp")&& (R["idexp"]!=DBNull.Value)){
                    int nfase = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("expense", QHS.CmpEq("idexp", R["idexp"]), "nphase"));
                    object phase = Conn.DO_READ_VALUE("expensephase", QHS.CmpEq("nphase", nfase), "description");
                    NewR["!phase"] = phase;
                }

                if (!T.Columns.Contains(C.ColumnName)) continue;
                NewR[C.ColumnName] = R[C.ColumnName];
                
            }
            T.Rows.Add(NewR);
        }


        void ResetWizard(){
            if (DS.invoice.Rows.Count > 0)
                SetComboCausaleFattura();
            gridDetails.DataSource = null;
            //choosenParentPhase = 0;
            AggiornaGridDettagliFattura();
            ClearOperationsToDo();
        }

        void ClearOperationsToDo(){
            DS.pettycashoperationinvoice.Clear();
            DS.pettycashoperation.Clear();
            DS.invoicedetail.Clear();
            DetailsToUpdate.Clear();
        }


        public void MetaData_AfterLink(){
            btnInserisciClassificazioni.Visible = false;
            Meta = MetaData.GetMetaData(this);
            Meta.CanCancel = false;
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanSave = false;
            Meta.SearchEnabled = false;
            Conn = Meta.Conn;
            QHS = Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            GetData.CacheTable(DS.expensephase);
            string filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            fasefattura = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));
            GetData.CacheTable(DS.invoicekind, QHS.AppAnd(QHS.BitClear("flag", 0), QHS.BitClear("flag", 2)),
                "description", true);
            GetData.CacheTable(DS.ivakind);
            GetData.CacheTable(DS.pettycash);
            GetData.CacheTable(DS.pettycashsetup, filteresercizio, null, false);
            GetData.CacheTable(DS.config, filteresercizio, null, false);
            DetailsToUpdate = new ArrayList();
        }

        public void MetaData_AfterClear(){
            DisplayTabs(tabController.SelectedIndex);
        }

        private void btnDocumento_Click(object sender, EventArgs e){
            int esercizio = Convert.ToInt32(Meta.GetSys("esercizio"));
            string FilterIva = "(yinv<='" + esercizio.ToString() + "')";
            if (txtEsercDoc.Text != ""){
                int esercdocumento = CfgFn.GetNoNullInt32(txtEsercDoc.Text);
                try{
                    if (esercdocumento <= esercizio)
                        FilterIva = "(yinv='" + esercdocumento.ToString() + "')";
                    else
                        FilterIva = GetData.MergeFilters(FilterIva,
                            "(yinv='" + esercdocumento.ToString() + "')");
                }
                catch
                {
                }
            }
            int numdocumento = CfgFn.GetNoNullInt32(txtNumDoc.Text);
            if (txtNumDoc.Text != ""){
                FilterIva = GetData.MergeFilters(FilterIva,
                    "(ninv='" + numdocumento.ToString() + "')");
            }

            string filtertipodoc;
            if (cmbTipoFattura.SelectedIndex <= 0){
                filtertipodoc = QHS.AppAnd(QHS.BitClear("flag", 0), QHS.BitClear("flag", 2));
            }
            else{
                filtertipodoc = "(idinvkind=" +
                QueryCreator.quotedstrvalue(cmbTipoFattura.SelectedValue, true) + ")";
            }
            FilterIva = GetData.MergeFilters(FilterIva, filtertipodoc);

            FilterIva += "AND(residual= (taxabletotal + ivatotal) )AND(linkedimpos='0')and(linkedimpon='0')" +
                    "AND((active is null)OR(active='S'))AND(ycon is null)AND(flag_enable_split_payment='N')";


            MetaData Invoice = MetaData.GetMetaData(this, "invoiceresidual");
            Invoice.FilterLocked = true;
            Invoice.DS = new DataSet();
            DataRow M = Invoice.SelectOne("default", FilterIva, null, null);
            if (M == null) return;
            HelpForm.SetComboBoxValue(cmbTipoFattura, M["idinvkind"]);
            txtEsercDoc.Text = M["yinv"].ToString();
            txtNumDoc.Text = M["ninv"].ToString();
            txtFornitore.Text = M["registry"].ToString();
            txtDescrFattura.Text = M["description"].ToString();

            DS.invoicedetail.Clear();
            DetailsToUpdate.Clear();
            DS.invoice.Clear();

            string filterinvoice = QHS.AppAnd(QHS.CmpEq("idinvkind", M["idinvkind"]),
                 QHS.CmpEq("yinv", M["yinv"]), QHS.CmpEq("ninv", M["ninv"]));

            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.invoice, null, filterinvoice, null, false);
            SetComboCausaleFattura();
            AggiornaGridDettagliFattura();
        }

        void AggiornaGridDettagliFattura(){
            DS.invoicedetail.Clear();
            DetailsToUpdate.Clear();
            if (cmbCausale.SelectedIndex < 0) return;
            int causale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
            if (causale == 0) return;
            string filtercausale = QHC.CmpEq("idtipo", causale);

            if (DS.invoice.Rows.Count == 0) return;

            DataRow M = DS.invoice.Rows[0];
            string filterinvoice = QHS.AppAnd(QHS.CmpEq("idinvkind", M["idinvkind"]), QHS.CmpEq("yinv", M["yinv"]),
                   QHS.CmpEq("ninv", M["ninv"]));

            string filterinvoicedetail = filterinvoice;
            filterinvoicedetail = QHS.AppAnd(filterinvoicedetail, QHS.IsNull("idexp_iva"),QHS.IsNull("idexp_taxable"));

            DSCopy = DS.Copy();
            
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DSCopy.Tables["invoicedetail"], null, filterinvoicedetail, null, false);
            Conn.DeleteAllUnselectable(DSCopy.Tables["invoicedetail"]);

            MetaData MD = MetaData.GetMetaData(this, "invoicedetail");
            MD.DS = DSCopy;
            MD.DescribeColumns(DSCopy.Tables["invoicedetail"], "wizardiva");
            GetData GD = new GetData();
            GD.InitClass(DSCopy, Conn, "invoicedetail");
            GD.GetTemporaryValues(DSCopy.Tables["invoicedetail"]);
            gridDetails.DataSource = null;
            HelpForm.SetDataGrid(gridDetails, DSCopy.Tables["invoicedetail"]);
            btnSelectAllDetail_Click(null, null);

            VisualizzaUPB();
            RecalcTotalDetails();
        }

        void VisualizzaUPB(){
            DataTable Details = DSCopy.Tables["invoicedetail"];
            object idupb;
            string filterupb;
            object codeupb;
            if (Details.Rows.Count == 0) return;
            foreach (DataRow Curr in Details.Rows){
                idupb = Curr["idupb"];
                if (idupb != DBNull.Value){
                    filterupb = QHS.CmpEq("idupb", idupb);
                    codeupb = Conn.DO_READ_VALUE("upb", filterupb, "codeupb");
                    Curr["!codeupb"] = codeupb;
                }
            }
        }

        void SetComboCausaleFattura(){
            ClearComboCausale();
            EnableTipoMovimento(1, "Contabilizzazione importo totale documento");
            int currtipo = 1; 
            HelpForm.SetComboBoxValue(cmbCausale, currtipo);
        }

        void EnableTipoMovimento(int IDtipo, string descrtipo){
            DataRow R = DS.tipomovimento.NewRow();
            R["idtipo"] = IDtipo;
            R["descrizione"] = descrtipo;
            DS.tipomovimento.Rows.Add(R);
            DS.tipomovimento.AcceptChanges();
        }

        void ClearComboCausale(){
            DataTable TCombo = DS.tipomovimento;
            TCombo.Clear();
        }

        private void cmbTipoFattura_SelectedIndexChanged(object sender, EventArgs e){
            if (Meta == null) return;
            if (!Meta.DrawStateIsDone) return;
            ClearFattura();
            return;
        }

        void RecalcTotalDetails(){
            //txtDaPagare.Text = "";
            //txtPerc.Text = "";
            // Marca tutti i dettagli come selezionati. E' praticamente il Seleziona tutto.
            if (DSCopy != null){
                for (int i = 0; i < DSCopy.Tables["invoicedetail"].Rows.Count; i++) gridDetails.Select(i);
            }

            DataRow[] Selected = GetGridAllSelectedRows(gridDetails);
            if ((Selected == null) || (Selected.Length == 0)){
                txtTotGenerale.Text = "";
                txtTotaleFattura.Text = "";
                txtRimasto.Text = "";
                txtTotImponibile.Text = "";
                txtTotIva.Text = "";
                return;
            }
            if (DS.invoice.Rows.Count == 0) return;
            DataRow Invoice = DS.invoice.Rows[0];
            double tassocambio = CfgFn.GetNoNullDouble(Invoice["exchangerate"]);

            if (tassocambio == 0) tassocambio = 1;
            double totiva = 0;
            double totimpo = 0;
            double total = 0;
            int causale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
            foreach (DataRow Curr in Selected){
                DataRow[] IvaKind = DS.ivakind.Select(QHC.CmpEq("idivakind", Curr["idivakind"]));
                if (IvaKind.Length == 0)
                {
                    show(this, "Non esiste la riga nell'anagrafica dei tipi IVA", "Errore");
                    return;
                }
                double imponibile = CfgFn.GetNoNullDouble(Curr["taxable"]);
                double quantita = CfgFn.GetNoNullDouble(Curr["number"]);
                double aliquota = CfgFn.GetNoNullDouble(IvaKind[0]["rate"]);
                double sconto = CfgFn.GetNoNullDouble(Curr["discount"]);
                double imponibileEUR = (imponibile * quantita * (1 - sconto)) * tassocambio;
                double ivaEUR = CfgFn.GetNoNullDouble(Curr["tax"]);

                imponibileEUR = CfgFn.RoundValuta(imponibileEUR);
                ivaEUR = CfgFn.RoundValuta(ivaEUR);

                if (causale == 1)  {
                    totimpo += imponibileEUR;
                    totiva += ivaEUR;
                }
                total = totimpo + totiva;

            }
            if (causale == 1)  {
                txtTotGenerale.Text = total.ToString("c");
                txtTotaleFattura.Text = total.ToString("c");
                decimal importoRimasto = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal), txtRimasto.Text, "x.y.c"));
                if (DS.Tables["Info"].Rows.Count==0){
                    txtRimasto.Text = total.ToString("c");
                }
                txtTotImponibile.Text = totimpo.ToString("c");
                txtTotIva.Text = totiva.ToString("c");
            }
        }

        private DataRow GetGridSelectedRow(DataGrid G){
            DataSet DSV = (DataSet)G.DataSource;
            if (DSV == null) return null;
            DataTable TV = DSV.Tables[G.DataMember];
            if (TV == null) return null;

            if (TV.Rows.Count == 0) return null;
            DataRowView DV = null;
            try
            {
                DV = (DataRowView)G.BindingContext[DSV, TV.TableName].Current;
            }
            catch
            {
                DV = null;
            }
            if (DV == null) return null;

            DataRow R = DV.Row;
            return R;
        }

        private DataRow[] GetGridAllSelectedRows(DataGrid G){
            if (G.DataMember == null) return null;
            if (G.DataSource == null) return null;
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet)G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];

            int numrighe = MyTable.Rows.Count;
            DataRow[] Res = new DataRow[numrighe];
            int count = 0;
            int i;
            for (i = 0; i < numrighe; i++){
                Res[count++] = GetGridRow(G, i);
            }
            return Res;
        }

        // Sostituito da GetGridAllSelectedRows()
        //private DataRow[] GetGridSelectedRows(DataGrid G){
        //    if (G.DataMember == null) return null;
        //    if (G.DataSource == null) return null;
        //    string TableName = G.DataMember.ToString();
        //    DataSet MyDS = (DataSet)G.DataSource;
        //    DataTable MyTable = MyDS.Tables[TableName];
        //    int numrighetemp = MyTable.Rows.Count;
        //    int numrighe = 0;
        //    int i;
        //    for (i = 0; i < numrighetemp; i++)
        //    {
        //        if (G.IsSelected(i))
        //        {
        //            numrighe++;
        //        }
        //    }

        //    DataRow[] Res = new DataRow[numrighe];
        //    int count = 0;
        //    for (i = 0; i < numrighetemp; i++)
        //    {
        //        if (G.IsSelected(i))
        //        {
        //            Res[count++] = GetGridRow(G, i);
        //        }
        //    }
        //    return Res;
        //}

        DataRow GetGridRow(DataGrid G, int index){
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet)G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            string filter;
            DataRow Invoice = DS.invoice.Rows[0];
            filter = QHC.AppAnd(QHC.CmpEq("idinvkind", Invoice["idinvkind"]),
                QHC.CmpEq("yinv", Invoice["yinv"]), QHC.CmpEq("ninv", Invoice["ninv"]), QHC.CmpEq("rownum", G[index, 0]));
            DataRow[] selectresult = MyTable.Select(filter);
            return (selectresult.Length > 0) ? selectresult[0] : null;
        }

        private void txtEsercDoc_Leave(object sender, EventArgs e){
            int YInv = CfgFn.GetNoNullInt32(txtEsercDoc.Text);
            if (YInv <= 0)
            {
                ClearFattura();
                return;
            }
            if (YInv < 1000){
                YInv += 2000;
                txtEsercDoc.Text = YInv.ToString();
            }
            if (txtNumDoc.Text.Trim() != ""){
                btnDocumento_Click(sender, e);
                return;
            }
        }

        void ClearFattura(){
            txtNumDoc.Text = "";
            txtDescrFattura.Text = "";
            txtFornitore.Text = "";
            DS.invoice.Clear();
            if (DSCopy != null){
                DSCopy.Tables["invoicedetail"].Clear();
                DS.Tables["Info"].Clear();
            }
            DS.invoicedetail.Clear();
            DetailsToUpdate.Clear();
            RecalcTotalDetails();
        }

        private void txtNumDoc_Leave(object sender, EventArgs e){
            int NInv = CfgFn.GetNoNullInt32(txtNumDoc.Text);
            if (NInv <= 0){
                ClearFattura();
                return;
            }
            btnDocumento_Click(sender, e);
            return;
        }

        private void btnSelectAllDetail_Click(object sender, EventArgs e){
            if (DSCopy != null)
            {
                for (int i = 0; i < DSCopy.Tables["invoicedetail"].Rows.Count; i++) gridDetails.Select(i);
            }
        }

        private void gridDetails_Paint(object sender, PaintEventArgs e){
            //RecalcTotalDetails(); Li seleziona sempre tutti.
        }

        private void btnBack_Click(object sender, EventArgs e){
            StandardChangeTab(-1);
        }

        private void btnNext_Click(object sender, EventArgs e){
            if (tabController.SelectedIndex == tabController.TabPages.Count - 1) {
                if (!SaveData()){
                    btnInserisciClassificazioni.Visible = false;
                }
                else{
                    show(this, "Procedere con l'inserimento delle Classificazioni.","Avviso");
                    btnInserisciClassificazioni.Visible = true ;
                }
            }

            StandardChangeTab(+1);
        }
        
        bool SaveData(){
            DataRow I = DS.invoice.Rows[0];

            PostData.MarkAsTemporaryTable(DS.Tables["pettycashoperationview"], false);
            DS.pettycashoperation.Clear();
            DS.pettycashoperationinvoice.Clear();

            MetaData MetaPettycashoperation = Meta.Dispatcher.Get("pettycashoperation");
            MetaPettycashoperation.SetDefaults(DS.pettycashoperation);

            MetaData MetaPettycashoperationinvoice = Meta.Dispatcher.Get("pettycashoperationinvoice");
            MetaPettycashoperationinvoice.SetDefaults(DS.pettycashoperationinvoice);

            DS.pettycashoperation.Columns["idaccmotive_debit"].DefaultValue = I["idaccmotivedebit"];

            DS.pettycashoperationinvoice.Columns["idinvkind"].DefaultValue = I["idinvkind"];
            DS.pettycashoperationinvoice.Columns["ninv"].DefaultValue = I["ninv"];
            DS.pettycashoperationinvoice.Columns["yinv"].DefaultValue = I["yinv"];
            
            int esercizio = Convert.ToInt32(Meta.GetSys("esercizio"));

         
            foreach (DataRow R in Tpettycashoperation.Select())  {
                DataRow NewOp = MetaPettycashoperation.Get_New_Row(null, DS.pettycashoperation);

                NewOp["idpettycash"] = R["idpettycash"];
                NewOp["description"] = R["description"];
                NewOp["idfin"] = R["idfin"];
                NewOp["idupb"] = R["idupb"];
                NewOp["idman"] = R["idman"];
                if (chkDocumentata.Checked){
                   int flag = CfgFn.GetNoNullInt32(DS.pettycashoperation.Columns["flag"].DefaultValue);
                   NewOp["flag"] = flag;
                }
                else {
                    int flag = CfgFn.GetNoNullInt32(DS.pettycashoperation.Columns["flag"].DefaultValue);
                    flag = flag & 0x10; //  Azzero il bit di pos.4 = Spese Documentate
                    flag = flag & 0x08; //  Azzero il bit di pos.3 = Tipo Operazione 'Spesa'
                    flag = flag | 0x08; //  Imposto il bit di pos.3 = Tipo Operazione 'Spesa'
                    NewOp["flag"] = flag;
                }
                
                NewOp["amount"] = R["amount"];
                NewOp["doc"] = R["doc"];
                NewOp["docdate"] = R["docdate"];
                NewOp["idexp"] = R["idexp"];

                DataRow NewOpInvoice = MetaPettycashoperationinvoice.Get_New_Row(NewOp, DS.pettycashoperationinvoice);

                NewOpInvoice["yoperation"] = Meta.GetSys("esercizio");
                NewOpInvoice["noperation"] = NewOp["noperation"];
                NewOpInvoice["idpettycash"] = R["idpettycash"];
               
            }

            PostData Post = Meta.Get_PostData();

            Post.InitClass(DS, Meta.Conn);
            if (!Post.DO_POST()){
                show(this, "Si è verificato un errore o si è deciso di non salvare! L'operazione sarà terminata");
                return false;
            }
            else{
                GeneraScritture();
            }

            //new FrmDettaglioRisultati(DS.pettycashoperation).ShowDialog(this);

            return true;

        }

        void GeneraScritture(){
            if (DS.pettycashoperation.Rows.Count == 0) return; //It was an insert-cancel

            DataRow rPettycashoperation = DS.pettycashoperation.Rows[0];
            // Prendo la Rows[0] perchè alcune info sono in comune alle n-pettycashoperation, quindi evito di mostrare i messaggi all'utente n volte.
            object idpettycash = rPettycashoperation["idpettycash"];
                string filterpcash = "(idpettycash=" + QueryCreator.quotedstrvalue(idpettycash, false) + ")";
                DataRow[] PettyCash = DS.pettycashsetup.Select(filterpcash);
                if (PettyCash.Length == 0){
                    show("Non è stata inserita la configuraz. del fondo economale per quest'anno");
                    return;
                }
                DataRow rPettyCash = PettyCash[0];
                object idacc_pettycash = rPettyCash["idacc"];

                object idreg = rPettycashoperation["idreg"];
                object idpettycashreg = rPettyCash["registrymanager"];

                EP_functions EP = new EP_functions(Meta.Dispatcher);
                if (!EP.attivo) return;

                object idaccmot_debit = rPettycashoperation["idaccmotive_debit"];
                object idacc_registry = EP.GetSupplierAccountForRegistry(null, idreg);

                if (idacc_registry == null || idacc_registry.ToString() == ""){
                    show("Non è stato configurato il conto di debito/credito opportuno");
                    return;
                }

                if (idaccmot_debit == DBNull.Value){
                    show("Non è stata impostata la causale di debito. Sarà usata una causale di debito standard.");
                }

                foreach (DataRow Curr in DS.pettycashoperation.Rows){
                    EP.GetEntryForDocument(Curr);

                    object doc = "Op. Fondo Econ. " +
                        Curr["idpettycash"].ToString() + "/" +
                        Curr["yoperation"].ToString().Substring(2, 2) + "/" +
                        Curr["noperation"].ToString().PadLeft(6, '0');

                    EP.SetEntry(Curr["description"], Curr["adate"],
                        doc, Curr["adate"], EP_functions.GetIdForDocument(Curr));

                    EP.ClearDetails();

                    string idepcontext_debito = "PSPESED";
                    decimal importo = CfgFn.GetNoNullDecimal(Curr["amount"]);

                    //Scrittura :  DEBITO	A	F.ECONOMALE	contesto PSPESED (P.SPESE DEBITO)
                    object idacc_debit = idacc_registry;
                    if (idaccmot_debit != DBNull.Value){
                        DataRow[] ContiDebito = EP.GetAccMotiveDetails(idaccmot_debit.ToString());
                        if (ContiDebito.Length > 0) idacc_debit = ContiDebito[0]["idacc"];
                    }
                    EP.EffettuaScrittura(idepcontext_debito, importo,
                        idacc_debit.ToString(),
                        idreg, Curr["idupb"], Curr["start"], Curr["stop"], Curr, idaccmot_debit);
                    EP.EffettuaScrittura(idepcontext_debito, importo,
                        idacc_pettycash.ToString(),
                        idpettycashreg, Curr["idupb"], Curr["start"], Curr["stop"], Curr, idaccmot_debit);

                    EP.RemoveEmptyDetails();

                    MetaData MetaEntry = MetaData.GetMetaData(this, "entry");
                    PostData Post = MetaEntry.Get_PostData();

                    Post.InitClass(EP.D, Meta.Conn);
                    if (Post.DO_POST()){
                        EditEntry(Curr);
                    }
                    else {
                        EP.viewDetails(Meta);
                    }
                }

        }

        void EditEntry(DataRow Curr){
            if (DS.pettycashoperation.Rows.Count == 0) return;
            EP_functions EP = new EP_functions(Meta.Dispatcher);
            EP.EditRelatedEntry(Meta, Curr);
        }

         private void btnModificaInfo_Click(object sender, EventArgs e){
            DataRow RigaSelezionata = GetGridSelectedRow(gridInfo);
            if (RigaSelezionata == null) {
                show("Selezionare un dettaglio.");
                return;
            }

            object idpettycash = cmbFondoPS.SelectedValue;

            if (idpettycash == null) {
                show("Selezionare il fondo");
                return;
            }
            decimal importo = CfgFn.GetNoNullDecimal(RigaSelezionata["amount"]);

            object idupb = RigaSelezionata["idupb"];
            object idman = RigaSelezionata["idman"];
            object idfin = RigaSelezionata["idfin"];
            object idexp = RigaSelezionata["idexp"];

            string filterupb = null;

            decimal importoRimasto = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal), txtRimasto.Text, "x.y.c"));
            FrmAskInfo F = new FrmAskInfo(filterupb, Meta.Dispatcher, idupb, idman, idfin, importo, importoRimasto, idexp, idpettycash,true, "EditMode");
            if (F.ShowDialog(this) != DialogResult.OK) return ;
            if (F.Dati == null)  return;
            DataRow rDati = F.Dati.Rows[0];
            object idfinSelected = rDati["idfin"];
            RigaSelezionata["idfin"] = idfinSelected;

            object codefinSelected = rDati["codefin"];
            RigaSelezionata["codefin"] = codefinSelected;

            object idupbSelected = rDati["idupb"];
            RigaSelezionata["idupb"] = idupbSelected;

            object codeupbSelected = rDati["codeupb"];
            RigaSelezionata["codeupb"] = codeupbSelected;

            object idmanSelected = rDati["idman"];
            RigaSelezionata["idman"] = idmanSelected;

            object manSelected = rDati["manager"];
            RigaSelezionata["manager"] = manSelected;

            object amountSelected = rDati["amount"];
            RigaSelezionata["amount"] = amountSelected;

            object idexpSelected = rDati["idexp"];
            RigaSelezionata["idexp"] = idexpSelected;

            object nMovSelected = Conn.DO_READ_VALUE("expense", QHS.CmpEq("idexp", idexpSelected), "nmov");
            RigaSelezionata["nmov"] = nMovSelected;

            object yMovSelected = Conn.DO_READ_VALUE("expense", QHS.CmpEq("idexp", idexpSelected), "ymov");
            RigaSelezionata["ymov"] = yMovSelected;

            AggiornaRimastodaAssegnare();

        }

        void SetGridAndInfo(){
            EnableDisableDocumenti(IsChecked);
            chkDocumentata.Checked = IsChecked;

            if (cmbFondoPS.SelectedIndex <= 0){
                cmbFondoPS.SelectedIndex = -1;
            }
            
            gridDetails.DataSource = null;
            HelpForm.SetDataGrid(gridInfo, DS.Tables["Info"]);

            DataRow I = DS.invoice.Rows[0];
            txtDescrizione.Text = I["description"].ToString();
            if (IsChecked){
                txtDocumento.Text = I["doc"].ToString();
                txtDataDoc.Text = HelpForm.StringValue(I["docdate"], txtDataDoc.Tag.ToString());
            }
        }

        private void btnAggiungi_Click(object sender, EventArgs e){
            if (LimiteImportoRaggiunto()) 
                return;

            object idpettycash = cmbFondoPS.SelectedValue;
            if (idpettycash == null) {
                show("Selezionare il fondo");
                return;
            }
            decimal importoRimasto = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal), txtRimasto.Text, "x.y.c"));
            decimal TotaleFattura = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal), txtTotaleFattura.Text, "x.y.c"));

            FrmAskInfo F = new FrmAskInfo(null, Meta.Dispatcher, DBNull.Value, DBNull.Value, DBNull.Value, importoRimasto, importoRimasto, DBNull.Value, idpettycash, true, "InsertMode");
            if (F.ShowDialog(this) != DialogResult.OK) return;
            if (F.Dati == null) return;
            DataRow rDati = F.Dati.Rows[0];
            DataRow RigaSelezionata = DS.Tables["Info"].NewRow();

            object idfinSelected = rDati["idfin"];
            RigaSelezionata["idfin"] = idfinSelected;

            object codefinSelected = rDati["codefin"];
            RigaSelezionata["codefin"] = codefinSelected;

            object idupbSelected = rDati["idupb"];
            RigaSelezionata["idupb"] = idupbSelected;

            object codeupbSelected = rDati["codeupb"];
            RigaSelezionata["codeupb"] = codeupbSelected;

            object idmanSelected = rDati["idman"];
            RigaSelezionata["idman"] = idmanSelected;

            object manSelected = rDati["manager"];
            RigaSelezionata["manager"] = manSelected;

            object amountSelected = rDati["amount"];
            RigaSelezionata["amount"] = amountSelected;

            object idexpSelected = rDati["idexp"];
            RigaSelezionata["idexp"] = idexpSelected;

            object nMovSelected = Conn.DO_READ_VALUE("expense", QHS.CmpEq("idexp", idexpSelected), "nmov");
            RigaSelezionata["nmov"] = nMovSelected;

            object yMovSelected = Conn.DO_READ_VALUE("expense", QHS.CmpEq("idexp", idexpSelected), "ymov");
            RigaSelezionata["ymov"] = yMovSelected;

            DS.Tables["Info"].Rows.Add(RigaSelezionata);
            AggiornaRimastodaAssegnare();
        }

        private void btnCancella_Click(object sender, EventArgs e){
            DataRow RigaSelezionata = GetGridSelectedRow(gridInfo);
            
            if (RigaSelezionata == null)     {
                show("Selezionare un dettaglio.");
                return;
            }
            RigaSelezionata.Delete();
            AggiornaRimastodaAssegnare();
        }

        bool InfoComplete(){
            if (cmbFondoPS.SelectedIndex < 0){
                show(this, "Scegliere un Fondo Economale", "Errore");
                return false;
            }
            if (txtDescrizione.Text.Trim() == ""){
                show(this, "Inserire una Descrizione", "Errore");
                return false;
            }

            decimal importoRimasto = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal), txtRimasto.Text, "x.y.c"));
            if (importoRimasto > 0){
                show(this, "L'importo della fattura non è stato completamente attribuito. E' presente un importo residuo.", "Errore");
                return false;
            }

            return true;
        }

        private void AggiornaRimastodaAssegnare(){
            decimal importo = 0;
            foreach (DataRow Curr in DS.Tables["Info"].Select())   {
                importo += CfgFn.GetNoNullDecimal(Curr["amount"]);
            }

            decimal totaleFattura = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal), txtTotaleFattura.Text, "x.y.c"));
            decimal rimasto = (totaleFattura - importo);
            txtRimasto.Text = rimasto.ToString("c"); ;
        }

        bool LimiteImportoRaggiunto() {
            decimal rimasto = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal), txtRimasto.Text, "x.y.c"));
            if (rimasto == 0){
                show("Non è possibile aggiungere ulteriori dettagli. La somma dei dettagli inseriti è pari al Totale Fattura");
                return true;
            }
            return false;
        }
        bool IsChecked = true ;
        private void chkDocumentata_CheckedChanged(object sender, EventArgs e){
            EnableDisableDocumenti(chkDocumentata.Checked);
            IsChecked = chkDocumentata.Checked;
        }

        /// <summary>
        /// Abilito/disabilito i textbox Documento e DataDocumento
        /// </summary>
        /// <param name="enable"></param>
        void EnableDisableDocumenti(bool enable){
            txtDocumento.ReadOnly = !enable;
            txtDataDoc.ReadOnly = !enable;
            if (!enable) txtDocumento.Text = "";
            if (!enable) txtDataDoc.Text = "";
        }

        private void tabController_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void btnInserisciClassificazioni_Click(object sender, EventArgs e)
        {
            btnInserisciClassificazioni.Enabled = false;
            Meta.CanCancel = true;
            Meta.CanInsert = true;
            Meta.CanInsertCopy = true;
            Meta.CanSave = true;
            Meta.SearchEnabled = true;

            object idpettycash = cmbFondoPS.SelectedValue;
            int esercizio = Convert.ToInt32(Meta.GetSys("esercizio"));
            string ListNoperation = QHC.DistinctVal(DS.pettycashoperation.Select(), "noperation");
            string filter = QHC.AppAnd( QHC.CmpEq("idpettycash",idpettycash),QHC.CmpEq("yoperation", esercizio),
                QHC.FieldInList("noperation", ListNoperation));

            MetaData Mpettycashoperation = Meta.Dispatcher.Get("pettycashoperation");
            Mpettycashoperation.ContextFilter = filter;
            Form F = null;
            if (Meta.linkedForm != null) F = Meta.linkedForm.ParentForm;
            bool result = Mpettycashoperation.Edit(F, "default", false);
            string listtype = Mpettycashoperation.DefaultListType;
            DataRow RR = Mpettycashoperation.SelectOne(listtype, filter, null, null);
            if (RR != null) Mpettycashoperation.SelectRow(RR, listtype);

            this.Close();
            this.Dispose();
        }

        private void Frm_pettycashoperation_wizardinvoicedetail_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e){

        }

        private void btnCancel_Click_1(object sender, EventArgs e){
            this.Close();
            this.Dispose();
        }
    }

}
