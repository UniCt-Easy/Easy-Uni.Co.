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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
using System.Collections.Generic;
using funzioni_configurazione;
using System.Globalization;
using movimentofunctions;

namespace expense_wizardazzerariporti//wizard_spesaazzerariporti//
{
    /// <summary>
    /// Summary description for frmWizardSpesaAzzeraRiporti.
    /// </summary>
    public class Frm_expense_wizardazzerariporti : System.Windows.Forms.Form {
        private System.Windows.Forms.TabPage tabPresentazione;
        private System.Windows.Forms.TabPage tabAzzeraMov;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGrid dgMovSpesa;
        private System.Windows.Forms.Button btnIndietro;
        private System.Windows.Forms.Button btnAvanti;
        private System.Windows.Forms.TextBox txtMovimentiSelezionati;
        MetaData Meta;
        int fasebilancio;
        int faseimpegno;
        int nextYear;
        DateTime lastday;
        object esisteNextYear;
        string CustomTitle;
        private ArrayList pagine;
        private int selectedIndex;
        private System.Windows.Forms.TabControl tabController;
        private System.Windows.Forms.Button btnAzzera;
        private System.Windows.Forms.Button btnAnnulla;
        public vistaForm DS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTitolo;
        private System.Windows.Forms.Label lblCommento;
        CQueryHelper QHC;
        QueryHelper QHS;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public Frm_expense_wizardazzerariporti() {
            InitializeComponent();
            FormInit();
        }

        void FormInit() {
            CustomTitle = "Wizard Azzeramento Riporti";
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tabController = new System.Windows.Forms.TabControl();
            this.tabPresentazione = new System.Windows.Forms.TabPage();
            this.lblCommento = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTitolo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabAzzeraMov = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAzzera = new System.Windows.Forms.Button();
            this.txtMovimentiSelezionati = new System.Windows.Forms.TextBox();
            this.dgMovSpesa = new System.Windows.Forms.DataGrid();
            this.btnIndietro = new System.Windows.Forms.Button();
            this.btnAvanti = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.DS = new vistaForm();
            this.tabController.SuspendLayout();
            this.tabPresentazione.SuspendLayout();
            this.tabAzzeraMov.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMovSpesa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // tabController
            // 
            this.tabController.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.tabController.Controls.Add(this.tabPresentazione);
            this.tabController.Controls.Add(this.tabAzzeraMov);
            this.tabController.Location = new System.Drawing.Point(8, 8);
            this.tabController.Name = "tabController";
            this.tabController.SelectedIndex = 0;
            this.tabController.Size = new System.Drawing.Size(592, 384);
            this.tabController.TabIndex = 0;
            // 
            // tabPresentazione
            // 
            this.tabPresentazione.Controls.Add(this.lblCommento);
            this.tabPresentazione.Controls.Add(this.label5);
            this.tabPresentazione.Controls.Add(this.lblTitolo);
            this.tabPresentazione.Controls.Add(this.label1);
            this.tabPresentazione.Location = new System.Drawing.Point(4, 22);
            this.tabPresentazione.Name = "tabPresentazione";
            this.tabPresentazione.Size = new System.Drawing.Size(584, 358);
            this.tabPresentazione.TabIndex = 0;
            this.tabPresentazione.Text = "Pagina 1 di 2";
            // 
            // lblCommento
            // 
            this.lblCommento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCommento.Location = new System.Drawing.Point(8, 128);
            this.lblCommento.Name = "lblCommento";
            this.lblCommento.Size = new System.Drawing.Size(568, 40);
            this.lblCommento.TabIndex = 4;
            this.lblCommento.Text = "Se la fase sopra descritta coincide con la fase associata all\'impegno (Configurat" +
                "a da Configurazioni - Bilancio - Configurazione), la procedura proporrà la creaz" +
                "ione di una variazione di dotazione crediti nell\'esercizio successivo";
            this.lblCommento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(8, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(568, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "DI";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitolo
            // 
            this.lblTitolo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.lblTitolo.Location = new System.Drawing.Point(8, 64);
            this.lblTitolo.Name = "lblTitolo";
            this.lblTitolo.Size = new System.Drawing.Size(568, 24);
            this.lblTitolo.TabIndex = 1;
            this.lblTitolo.Text = "AZZERAMENTO DEI MOVIMENTI DI SPESA DELLA FASE:";
            this.lblTitolo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(568, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "PROCEDURA";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabAzzeraMov
            // 
            this.tabAzzeraMov.Controls.Add(this.label3);
            this.tabAzzeraMov.Controls.Add(this.label2);
            this.tabAzzeraMov.Controls.Add(this.btnAzzera);
            this.tabAzzeraMov.Controls.Add(this.txtMovimentiSelezionati);
            this.tabAzzeraMov.Controls.Add(this.dgMovSpesa);
            this.tabAzzeraMov.Location = new System.Drawing.Point(4, 22);
            this.tabAzzeraMov.Name = "tabAzzeraMov";
            this.tabAzzeraMov.Size = new System.Drawing.Size(584, 358);
            this.tabAzzeraMov.TabIndex = 1;
            this.tabAzzeraMov.Text = "Pagina 2 di 2";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Location = new System.Drawing.Point(8, 304);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Movimenti Selezionati:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(568, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tenere premuto il tasto CTRL o MAIUSC e contemporaneamente cliccare con il mouse " +
                "per selezionare più movimenti di spesa";
            // 
            // btnAzzera
            // 
            this.btnAzzera.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAzzera.Location = new System.Drawing.Point(504, 328);
            this.btnAzzera.Name = "btnAzzera";
            this.btnAzzera.TabIndex = 4;
            this.btnAzzera.Text = "Azzera";
            this.btnAzzera.Click += new System.EventHandler(this.btnAzzera_Click);
            // 
            // txtMovimentiSelezionati
            // 
            this.txtMovimentiSelezionati.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMovimentiSelezionati.Location = new System.Drawing.Point(128, 304);
            this.txtMovimentiSelezionati.Name = "txtMovimentiSelezionati";
            this.txtMovimentiSelezionati.ReadOnly = true;
            this.txtMovimentiSelezionati.Size = new System.Drawing.Size(448, 20);
            this.txtMovimentiSelezionati.TabIndex = 3;
            this.txtMovimentiSelezionati.Text = "";
            // 
            // dgMovSpesa
            // 
            this.dgMovSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.dgMovSpesa.DataMember = "";
            this.dgMovSpesa.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMovSpesa.Location = new System.Drawing.Point(8, 40);
            this.dgMovSpesa.Name = "dgMovSpesa";
            this.dgMovSpesa.Size = new System.Drawing.Size(568, 248);
            this.dgMovSpesa.TabIndex = 0;
            this.dgMovSpesa.Paint += new System.Windows.Forms.PaintEventHandler(this.dgMovSpesa_Paint);
            // 
            // btnIndietro
            // 
            this.btnIndietro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnIndietro.Location = new System.Drawing.Point(312, 400);
            this.btnIndietro.Name = "btnIndietro";
            this.btnIndietro.TabIndex = 2;
            this.btnIndietro.Text = "< Indietro";
            this.btnIndietro.Click += new System.EventHandler(this.btnIndietro_Click);
            // 
            // btnAvanti
            // 
            this.btnAvanti.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAvanti.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAvanti.Location = new System.Drawing.Point(412, 400);
            this.btnAvanti.Name = "btnAvanti";
            this.btnAvanti.TabIndex = 3;
            this.btnAvanti.Text = "Avanti >";
            this.btnAvanti.Click += new System.EventHandler(this.btnAvanti_Click);
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(520, 400);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.TabIndex = 4;
            this.btnAnnulla.Text = "Annulla";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // frmWizardSpesaAzzeraRiporti
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(608, 430);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.tabController);
            this.Controls.Add(this.btnIndietro);
            this.Controls.Add(this.btnAvanti);
            this.Name = "frmWizardSpesaAzzeraRiporti";
            this.Text = "frmWizardSpesaAzzeraRiporti";
            this.tabController.ResumeLayout(false);
            this.tabPresentazione.ResumeLayout(false);
            this.tabAzzeraMov.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgMovSpesa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private void btnAvanti_Click(object sender, System.EventArgs e) {
            AbilitaDisabilita(false);
            StandardChangeTab(+1);
            AbilitaDisabilita(true);
        }
        
        private void btnIndietro_Click(object sender, System.EventArgs e) {
            AbilitaDisabilita(false);
            StandardChangeTab(-1);
            AbilitaDisabilita(true);
        }

        void AbilitaDisabilita(bool disponibile) {
            if (disponibile) {
                Cursor.Current = Cursors.Default;
            }
            else {
                Cursor.Current = Cursors.WaitCursor;
            }

            btnAvanti.Enabled = disponibile;
            btnIndietro.Enabled = disponibile;
            btnAnnulla.Enabled = disponibile;
        }

        void StandardChangeTab(int step) {
            int oldTab = selectedIndex;
            int newTab = oldTab + step;
            if ((newTab < 0) || (newTab > pagine.Count)) return;

            switch (newTab) {
                case 1:
                    riempiGrid();
                    break;
            }
            DisplayTabs(newTab);
        }

        void DisplayTabs(int newTab) {
            if (newTab < pagine.Count) {
                tabController.TabPages.Clear();
                tabController.TabPages.Add((TabPage)pagine[newTab]);
                selectedIndex = newTab;

                btnAvanti.Text = newTab == pagine.Count - 1 ? "Fine." : "Avanti >";

                btnIndietro.Enabled = (newTab > 0);

                btnAvanti.DialogResult = (newTab == pagine.Count - 1) ? DialogResult.Cancel : DialogResult.None;

                Text = CustomTitle + " (Pagina " + (newTab + 1) + " di " + pagine.Count + ")";
            }
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            inizializzaVar();
            visualizzaEtichetta();
            GetData.CacheTable(DS.sortingkind, null, null, false);
            string filtersercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.CacheTable(DS.config, filtersercizio,null, false);
            
        }

        public void MetaData_AfterClear() {
            DisplayTabs(tabController.SelectedIndex);
        }

        public void MetaData_AfterActivation() {
            pagine = new ArrayList();
            // Inserisco manualmente i TAB in quanto nonostante la corretta numerazione vengono visti in ordine differente
            pagine.Add(tabPresentazione);
            pagine.Add(tabAzzeraMov);
            tabController.TabPages.Clear();
            tabController.TabPages.Add((TabPage)pagine[0]);
            DisplayTabs(0);
        }
        void inizializzaVar() {
            string filtersercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            object app = Meta.GetSys("expensefinphase");
            //Meta.Conn.DO_READ_VALUE("expensephase", "flagfinance = 'S'", "nphase");
            fasebilancio = Convert.ToInt32(app);
            app = Meta.GetSys("appropriationphase");
            //Meta.Conn.DO_READ_VALUE("finsetup", filteresercizio, "appropriationphasecode");
            faseimpegno = Convert.ToInt32(app);
            nextYear = (int)Meta.GetSys("esercizio") + 1;
            lastday = new DateTime((int)Meta.GetSys("esercizio"), 12, 31);
        }

        void visualizzaEtichetta() {
            object nomefase = Meta.Conn.DO_READ_VALUE("expensephase", 
                QHS.CmpEq("nphase",fasebilancio), "description");
            lblTitolo.Text = "AZZERAMENTO DEI MOVIMENTI DI SPESA DELLA FASE: " + nomefase.ToString().ToUpper();
            lblCommento.Visible = false;
            int flag = CfgFn.GetNoNullInt32( Meta.Conn.DO_READ_VALUE("accountingyear",
                QHS.CmpEq("ayear",nextYear),"flag"));
            bool flagfincopy = (flag & 0x0f) == 2;
            if (flagfincopy) {
                esisteNextYear = "S";
                if (fasebilancio == faseimpegno) {
                    lblCommento.Visible = true;
                }
                lblCommento.Text = "La procedura proporrà la creazione di una dotazione crediti nell'esercizio successivo";
            }
            else {
                esisteNextYear = "N";
            }
        }

        void riempiGrid() {
            //DS.Clear();
            DS.expensevar.Clear();
            DS.finvar.Clear();
            DS.finvardetail.Clear();
            DS.expensesorted.Clear();
            DS.expenseview.Clear();

            string filterRiporti = QHS.AppAnd(QHS.CmpGt("available", 0), QHS.CmpEq("ayear",  
                                              Meta.GetSys("esercizio")), QHS.CmpEq("nphase", fasebilancio));
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.expenseview, null, filterRiporti, null, true);

            calcolaDisponibileEffettivo();
          

            foreach (DataColumn C in DS.expenseview.Columns) {
                C.Caption = "";
            }
           
            DS.expenseview.Columns["phase"].Caption = "Fase";
            DS.expenseview.Columns["nmov"].Caption = "Num. Mov.";
            DS.expenseview.Columns["ymov"].Caption = "Eserc. Mov.";
            DS.expenseview.Columns["codefin"].Caption = "Bilancio";
            DS.expenseview.Columns["codeupb"].Caption = "UPB";
            DS.expenseview.Columns["registry"].Caption = "Den. Creditore";
            DS.expenseview.Columns["amount"].Caption = "Importo";
            DS.expenseview.Columns["curramount"].Caption = "Importo Corrente";
            DS.expenseview.Columns["available"].Caption = "Disponibile";
            DS.expenseview.Columns["!realavailable"].Caption = "Disp. Effettivo Eserc." + (CfgFn.GetNoNullInt32(Meta.GetSys("esercizio")) + 1).ToString();
            if (dgMovSpesa.DataSource == null) {
                HelpForm.SetDataGrid(dgMovSpesa, DS.expenseview);
                new formatgrids(dgMovSpesa).AutosizeColumnWidth();
            }
        }

        private void selezioneRigheCambiata() {
            string dataMember = dgMovSpesa.DataMember;
            CurrencyManager cm = (CurrencyManager)dgMovSpesa.BindingContext[DS, dataMember];
            DataView view = cm.List as DataView;
            if (view != null) {
                int primaRigaSelezionata = getPrimaRigaSelezionata(view);
                if (primaRigaSelezionata == -1) {
                    txtMovimentiSelezionati.Text = null;
                }
                else {
                    txtMovimentiSelezionati.Text = view[primaRigaSelezionata]["nmov"].ToString() + "/" +
                        view[primaRigaSelezionata]["ymov"].ToString();

                    for (int i = primaRigaSelezionata + 1; i < view.Count; i++) {
                        if (dgMovSpesa.IsSelected(i)) {
                            txtMovimentiSelezionati.Text += "," + view[i]["nmov"].ToString() + "/" +
                                view[i]["ymov"].ToString();
                        }
                    }
                }
            }
        }

        private int getPrimaRigaSelezionata(DataView view) {
            for (int i = 0; i < view.Count; i++) {
                if (dgMovSpesa.IsSelected(i)) {
                    return i;
                }
            }
            return -1;
        }

        private void dgMovSpesa_Paint(object sender, System.Windows.Forms.PaintEventArgs e) {
            selezioneRigheCambiata();
        }

        void calcolaDisponibileEffettivo()
        {

            foreach (DataRow R in DS.expenseview.Rows)
            {
                object idSpesa = R["idexp"];
         
                DataRow[] drMovimentoView = DS.expenseview.Select(QHC.CmpEq("idexp", idSpesa));
          
                decimal valore_da_azzerare = (decimal)drMovimentoView[0]["available"];

                DataTable TNextYear = Meta.Conn.RUN_SELECT("expenseview", "idexp,available", null,
                            QHS.AppAnd(QHS.CmpEq("idexp", idSpesa), QHS.CmpEq("ayear", CfgFn.GetNoNullInt32(Meta.GetSys("esercizio")) + 1)), null, false);
                if (TNextYear != null && TNextYear.Rows.Count > 0)
                {
                    decimal nextyear_available = (decimal)TNextYear.Rows[0]["available"];
                    valore_da_azzerare = nextyear_available; // il disponibile residuo effettivo da azzerare è quello dell'esercizio successivo e non quello al 31/12
                }
                drMovimentoView[0]["!realavailable"] = valore_da_azzerare;
            }
        }

        void azzeraRiporto(object idSpesa, DataRow rFinvar) {
            DataRow[] drMovimento = DS.expense.Select(QHC.CmpEq("idexp", idSpesa));
            DataRow[] drMovimentoView = DS.expenseview.Select(QHC.CmpEq("idexp", idSpesa));
            object idfin = drMovimentoView[0]["idfin"];
            object idupb = drMovimentoView[0]["idupb"];

            MetaData metaVarSpesa = MetaData.GetMetaData(this, "expensevar");
            metaVarSpesa.SetDefaults(DS.expensevar);
            MetaData.SetDefault(DS.expensevar, "adate", lastday);
            MetaData.SetDefault(DS.expensevar, "autokind", 9);
            decimal valore_da_azzerare = (decimal)drMovimentoView[0]["available"];

           
            DataTable TNextYear = Meta.Conn.RUN_SELECT("expenseview", "idexp,available", null,
                        QHS.AppAnd(QHS.CmpEq("idexp", idSpesa), QHS.CmpEq("ayear",CfgFn.GetNoNullInt32(Meta.GetSys("esercizio")) +1)), null, false);
            
            if (TNextYear != null && TNextYear.Rows.Count > 0)
            {
                decimal nextyear_available = (decimal)TNextYear.Rows[0]["available"];
                valore_da_azzerare = nextyear_available; // il disponibile residuo effettivo da azzerare è quello dell'esercizio successivo e non quello al 31/12
            }
           
           
            DataTable Tresidui = Meta.Conn.RUN_SELECT("expensecreditproceedsview", "idexp,topay,idunderwriting", null,
                           QHS.AppAnd(QHS.CmpEq("idexp", idSpesa), QHS.CmpGt("topay", 0)), null, false);
            decimal tot_to_pay = MetaData.SumColumn(Tresidui, "topay");
            decimal valore_da_azzerare_nofinanziamento = valore_da_azzerare - tot_to_pay;

            decimal rimasto_da_azzerare = valore_da_azzerare;
 

            //Crea le variazioni di spesa
            DataRow DRVarSpesa;
            if (valore_da_azzerare_nofinanziamento > 0) {
                DRVarSpesa = metaVarSpesa.Get_New_Row(drMovimento[0], DS.expensevar);
                DRVarSpesa["amount"] = -valore_da_azzerare_nofinanziamento;
                DRVarSpesa["idexp"] = idSpesa;
                DRVarSpesa["description"] = "Variazione di Azzeramento del Riporto";
                rimasto_da_azzerare -= valore_da_azzerare_nofinanziamento;
            }


            if (Tresidui != null && rimasto_da_azzerare > 0) {
                foreach (DataRow Rtopay in Tresidui.Select(null, "topay desc")) {
                    DRVarSpesa = metaVarSpesa.Get_New_Row(drMovimento[0], DS.expensevar);
                    decimal topay = CfgFn.GetNoNullDecimal(Rtopay["topay"]);
                    if (topay > rimasto_da_azzerare) topay = rimasto_da_azzerare;
                    DRVarSpesa["amount"] = -topay;
                    DRVarSpesa["idunderwriting"] = Rtopay["idunderwriting"];
                    DRVarSpesa["idexp"] = idSpesa;
                    DRVarSpesa["description"] = "Variazione di Azzeramento del Riporto";
                    rimasto_da_azzerare -= topay;
                    if (rimasto_da_azzerare == 0) break;
                }
            }

            // Aggiorna l'importo delle classificazioni 
            string filterMov = QHC.CmpEq("idexp", idSpesa);
            DataRow[] Rexpensesorted = DS.expensesorted.Select(filterMov);

            foreach (DataRow R in Rexpensesorted) {// se la classificazione class. interamente il mov lo azzera
                if ((decimal)R["amount"] == (decimal)drMovimentoView[0]["curramount"])
                    R["amount"] = (decimal)R["amount"] - valore_da_azzerare;
            }

            rimasto_da_azzerare = valore_da_azzerare;
            if (rFinvar != null) {
                //Crea le variazioni crediti
                if (rimasto_da_azzerare > 0) {
                    if (valore_da_azzerare_nofinanziamento > 0) {
                        AggiungiVarCrediti(idfin, idupb, DBNull.Value, valore_da_azzerare_nofinanziamento, rFinvar);
                        rimasto_da_azzerare -= valore_da_azzerare_nofinanziamento;
                    }
                    if (Tresidui != null && rimasto_da_azzerare > 0) {
                        foreach (DataRow R in Tresidui.Select(null, "topay desc")) {
                            decimal topay = CfgFn.GetNoNullDecimal(R["topay"]);
                            if (topay > rimasto_da_azzerare) topay = rimasto_da_azzerare;

                            AggiungiVarCrediti(idfin, idupb, R["idunderwriting"], topay, rFinvar);
                            rimasto_da_azzerare -= topay;
                            if (rimasto_da_azzerare == 0) break;
                        }
                    }
                }
            }
        }

        Hashtable H = new Hashtable();
        void AggiungiVarCrediti(object idfin, object idupb, object idunderwriting, decimal var_amount,DataRow rFinvar) {
            MetaData MetaDettVarBilancio = Meta.Dispatcher.Get("finvardetail");
            MetaDettVarBilancio.SetDefaults(DS.Tables["finvardetail"]);

            object idbilancioNY = null;
            if (H[idfin.ToString()] == null) {
                idbilancioNY= Meta.Conn.DO_READ_VALUE("finlookup",QHS.CmpEq("oldidfin", idfin), "newidfin");
                H[idfin.ToString()] = idbilancioNY;
            }
            else {
                idbilancioNY = H[idfin.ToString()];
            }

            object idUPB = idupb;

            string filterDettaglio = QHC.AppAnd(QHC.CmpEq("yvar", rFinvar["yvar"]),
                                                QHC.CmpEq("nvar", rFinvar["nvar"]),
                                                QHC.CmpEq("idfin", idbilancioNY),
                                                QHC.CmpEq("idunderwriting",idunderwriting));
            DataRow[] dettVarBilancioUpd = DS.finvardetail.Select(filterDettaglio);

            if (dettVarBilancioUpd.Length == 0) {
                DataRow NewDettVarBilancioRow = MetaDettVarBilancio.Get_New_Row(rFinvar, DS.Tables["finvardetail"]);
                NewDettVarBilancioRow["amount"] = var_amount;
                NewDettVarBilancioRow["idfin"] = idbilancioNY;
                NewDettVarBilancioRow["idupb"] = idUPB;
                NewDettVarBilancioRow["idunderwriting"] = idunderwriting;
                NewDettVarBilancioRow["description"] = "Variazione per Azzeramento Riporti Esercizio Precedente";
            }
            else {
                dettVarBilancioUpd[0]["amount"] = (decimal)dettVarBilancioUpd[0]["amount"] + var_amount;                                    
            }

        }


        DataRow salvaVarCrediti() {
            DateTime firstday = lastday;

            MetaData MetaVarBilancio = Meta.Dispatcher.Get("finvar");
            MetaVarBilancio.SetDefaults(DS.Tables["finvar"]);
            MetaData.SetDefault(DS.finvar, "yvar", nextYear);

            //Creo la variazione Crediti principale e poi aggiungo i dettagli
            DataRow NewVarBilancioRow = MetaVarBilancio.Get_New_Row(null, DS.Tables["finvar"]);
            NewVarBilancioRow["description"] = "Variazione per Azzeramento Riporti";
            NewVarBilancioRow["variationkind"] = 1;
            NewVarBilancioRow["flagcredit"] = "S";
            NewVarBilancioRow["adate"] = firstday.AddDays(1);
            return NewVarBilancioRow;
        }

        private void aggiornaDataGrid() {
            riempiGrid();
        }
          

        void ViewAutomatismi(DataSet DS)
        {
            string spesa = null;
            if (DS.Tables["expense"] != null)
            {
                DataTable Var = DS.Tables["expense"];
                spesa = QHS.FieldIn("idexp", Var.Select(), "idexp");
            }

            Form F = ShowAutomatismi.Show(Meta, spesa, null, null, null);
            F.ShowDialog(this);
        }

        private void btnAzzera_Click(object sender, System.EventArgs e) {
            bool creaVarCrediti = false;
            string filterAssestamento = QHS.AppAnd(QHC.CmpEq("variationkind", 3), QHS.CmpEq("yvar", nextYear));
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.finvar, null, filterAssestamento, null, true);

            if ((fasebilancio == faseimpegno) && (DS.finvar.Rows.Count == 0) && (esisteNextYear.ToString().ToUpper() == "S")) {
                if (MessageBox.Show("Attenzione la FASE BILANCIO e la FASE IMPEGNO sono coincidenti." +
                    "Si desidera effettuare una variazione di dotazione crediti contestualmente all'azzeramento della disponibilità dei movimenti?",
                    "Conferma", MessageBoxButtons.OKCancel) == DialogResult.OK) creaVarCrediti = true;
            }

            if ((fasebilancio == faseimpegno) && (DS.finvar.Rows.Count > 0) && (esisteNextYear.ToString().ToUpper() == "S")) {
                if (MessageBox.Show("Attenzione la FASE BILANCIO e la FASE IMPEGNO sono coincidenti ed esiste una variazione di assestamento dei crediti nell'esercizio successivo." +
                    " Si desidera effettuare una variazione di dotazione crediti contestualmente all'azzeramento della disponibilità dei movimenti?",
                    "Conferma", MessageBoxButtons.OKCancel) == DialogResult.OK) creaVarCrediti = true;
            }
            DataRow DR = null;
            if (creaVarCrediti) {
                DR = salvaVarCrediti();
            }

            string dataMember = dgMovSpesa.DataMember;
            CurrencyManager cm = (CurrencyManager)dgMovSpesa.BindingContext[DS, dataMember];
            DataView view = cm.List as DataView;
            if (view == null) {
                MessageBox.Show(this, "Lista vuota!");
                return;
            }
            ArrayList movimenti = new ArrayList();
            string filtroMovimenti = "";

            for (int i = 0; i < view.Count; i++) {
                if (dgMovSpesa.IsSelected(i)) {
                    object idSpesa = view[i]["idexp"];
                    if (movimenti.IndexOf(QHS.quote(idSpesa)) == -1) {
                        movimenti.Add(idSpesa);
                        filtroMovimenti += ", " + QHS.quote(idSpesa);
                    }
                }
            }

            if (movimenti.Count == 0) {
                MessageBox.Show(this, "Nessun movimento di spesa selezionato!");
                return;
            }

            filtroMovimenti = filtroMovimenti.Substring(1);

            string filtraexpense = QHS.FieldInList("idexp",filtroMovimenti);
            string filtroMovClass = QHS.AppAnd(filtraexpense, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.expensesorted, null, filtroMovClass, null, true);
            int fasespesamax = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));
            string filterimputazione = QHS.AppAnd(filtroMovClass, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.expense, null, filtraexpense, null, true);
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.expenseyear, null, filterimputazione, null, true);
             
            
            foreach (object idSpesa in movimenti) {
                azzeraRiporto(idSpesa, DR);
            }

                       
            GestioneAutomatismi ga = new GestioneAutomatismi(this, Meta.Conn, Meta.Dispatcher, DS.Copy(),
                    fasespesamax, fasespesamax, "expense", true);


            bool res = ga.GeneraAutomatismiAfterPost(true);
            if (!res)
            {
                MessageBox.Show(this, "Si è verificato un errore o si è deciso di non salvare! L'operazione sarà terminata");
                Resetta();
                return;
            }
            
            res = ga.doPost(Meta.Dispatcher);
            if (res) ViewAutomatismi(ga.DSP);
            Resetta();

        }
        void Resetta() {
            DS.expensevar.Clear();
            DS.finvar.Clear();
            DS.finvardetail.Clear();
            DS.expensesorted.Clear();
            DS.expenseview.Clear();
            DS.AcceptChanges();
            DS.expense.Clear();
            DS.expenseyear.Clear();

            dgMovSpesa.DataSource = null;
            aggiornaDataGrid();

        }
    }
}