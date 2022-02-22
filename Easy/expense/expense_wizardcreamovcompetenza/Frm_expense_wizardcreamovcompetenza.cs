
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
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using Crownwood.Magic.Controls;
using funzioni_configurazione;
using System.Globalization;
using movimentofunctions;


namespace expense_wizardcreamovcompetenza//wizard_spesacreamovcompetenza//
{
    /// <summary>
    /// Summary description for frmWizardSpesaCreaMovCompetenza.
    /// </summary>
    public class Frm_expense_wizardcreamovcompetenza : MetaDataForm {
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTitolo;
        MetaData Meta;
        int fasebilancio;
        int faseimpegno;
        int oldYear;
        DateTime lastday;
        string CustomTitle;
        private System.Windows.Forms.Button btnIndietro;
        private System.Windows.Forms.Button btnAvanti;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMovimentiSelezionati;
        private System.Windows.Forms.DataGrid dgMovSpesa;
        private System.Windows.Forms.Button btnCrea;
        private System.Windows.Forms.Button btnBilancio;
        public vistaForm DS2;
        public vistaFin DS;
        private System.Windows.Forms.GroupBox grpBilancio;
        private System.Windows.Forms.TextBox txtBilancio;
        private Crownwood.Magic.Controls.TabControl tabControllerMagic;
        private Crownwood.Magic.Controls.TabPage tabPresentazione;
        private Crownwood.Magic.Controls.TabPage tabCreaMov;
        string filterBilancio;
        private System.Windows.Forms.TextBox txtDenominazioneBil;
        private System.Windows.Forms.Panel panel1;
        private GroupBox gboxUPB;
        public TextBox txtUPB;
        private TextBox txtDescrUPB;
        private Button btnUPBCode;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public Frm_expense_wizardcreamovcompetenza() {
            InitializeComponent();
            FormInit();

            //			pagine = new ArrayList();
            // Inserisco manualmente i TAB in quanto nonostante la corretta numerazione vengono visti in ordine differente
            //pagine.Add(tabPresentazione);
            //pagine.Add(tabCreaMov);
            tabControllerMagic.HideTabsMode =
                Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;
            //tabControllerMagic.TabPages.Clear();
            //tabControllerMagic.TabPages.Add((TabPage)pagine[0]);
        }

        void FormInit() {
            CustomTitle = "Wizard Creazione Movimenti di Competenza";
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

        void StandardChangeTab(int step) {
            int oldTab = tabControllerMagic.SelectedIndex;
            int newTab = oldTab + step;
            if ((newTab < 0) || (newTab > tabControllerMagic.TabPages.Count - 1)) return;

            if (newTab == 1) { riempiGrid(); }
            if (newTab == tabControllerMagic.TabPages.Count - 1) {
                btnAvanti.DialogResult = DialogResult.OK;
            }
            else {
                btnAvanti.DialogResult = DialogResult.None;
            }
            DisplayTabs(newTab);
        }

        void DisplayTabs(int newTab) {
            tabControllerMagic.SelectedIndex = newTab;
            btnIndietro.Enabled = (newTab > 0);
            if (newTab == tabControllerMagic.TabPages.Count - 1)
                btnAvanti.Text = "Fine.";
            else
                btnAvanti.Text = "Avanti >";
            Text = CustomTitle + " (Pagina " + (newTab + 1) + " di " + tabControllerMagic.TabPages.Count + ")";
        }

        QueryHelper QHS;
        CQueryHelper QHC;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC= new CQueryHelper();
            QHS= Meta.Conn.GetQueryHelper();

            inizializzaVar();
            visualizzaEtichetta();
            DisplayTabs(0);
            Meta.CanInsert = false;
            Meta.CanSave = false;
            Meta.SearchEnabled = false;
            ClearDataSet.RemoveConstraints(DS2);
            filterBilancio = QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")),
                                        QHS.BitSet("flag", 0)); //finpart=S
            GetData.SetStaticFilter(DS.fin, filterBilancio);
            GetData.SetStaticFilter(DS.finview, filterBilancio);

            string filtersercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS2.sortingkind, null, null, null, true);
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS2.config, null, filtersercizio, null, true); 
        }

        public void MetaData_AfterClear() {
            DisplayTabs(tabControllerMagic.SelectedIndex);
        }

        void inizializzaVar() {
            string filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            object app = Meta.GetSys("expensefinphase");
            fasebilancio = Convert.ToInt32(app);
            app = Meta.GetSys("appropriationphase");
            faseimpegno = Convert.ToInt32(app);
            oldYear = (int)Meta.GetSys("esercizio") - 1;
            lastday = new DateTime((int)Meta.GetSys("esercizio"), 12, 31);
        }

        void visualizzaEtichetta() {
            object nomefase = Meta.Conn.DO_READ_VALUE("expensephase", 
                            QHS.CmpEq("nphase",Meta.GetSys("expensefinphase")), "description");
            lblTitolo.Text = "CREAZIONE DEI MOVIMENTI DI SPESA DELLA FASE: " + nomefase.ToString().ToUpper();
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.DS2 = new expense_wizardcreamovcompetenza.vistaForm();
            this.lblTitolo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpBilancio = new System.Windows.Forms.GroupBox();
            this.txtDenominazioneBil = new System.Windows.Forms.TextBox();
            this.txtBilancio = new System.Windows.Forms.TextBox();
            this.btnBilancio = new System.Windows.Forms.Button();
            this.btnCrea = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMovimentiSelezionati = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgMovSpesa = new System.Windows.Forms.DataGrid();
            this.btnIndietro = new System.Windows.Forms.Button();
            this.btnAvanti = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.DS = new expense_wizardcreamovcompetenza.vistaFin();
            this.tabControllerMagic = new Crownwood.Magic.Controls.TabControl();
            this.tabCreaMov = new Crownwood.Magic.Controls.TabPage();
            this.gboxUPB = new System.Windows.Forms.GroupBox();
            this.txtUPB = new System.Windows.Forms.TextBox();
            this.txtDescrUPB = new System.Windows.Forms.TextBox();
            this.btnUPBCode = new System.Windows.Forms.Button();
            this.tabPresentazione = new Crownwood.Magic.Controls.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.DS2)).BeginInit();
            this.grpBilancio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMovSpesa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.tabControllerMagic.SuspendLayout();
            this.tabCreaMov.SuspendLayout();
            this.gboxUPB.SuspendLayout();
            this.tabPresentazione.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS2
            // 
            this.DS2.DataSetName = "VistaWizardSpesaCreaMovCompetenza";
            this.DS2.EnforceConstraints = false;
            this.DS2.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // lblTitolo
            // 
            this.lblTitolo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitolo.Location = new System.Drawing.Point(8, 64);
            this.lblTitolo.Name = "lblTitolo";
            this.lblTitolo.Size = new System.Drawing.Size(844, 23);
            this.lblTitolo.TabIndex = 2;
            this.lblTitolo.Text = "CREAZIONE DEI MOVIMENTI DI SPESA DELLA FASE:";
            this.lblTitolo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(8, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(844, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "DI";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(844, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "PROCEDURA";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpBilancio
            // 
            this.grpBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpBilancio.Controls.Add(this.txtDenominazioneBil);
            this.grpBilancio.Controls.Add(this.txtBilancio);
            this.grpBilancio.Controls.Add(this.btnBilancio);
            this.grpBilancio.Location = new System.Drawing.Point(384, 388);
            this.grpBilancio.Name = "grpBilancio";
            this.grpBilancio.Size = new System.Drawing.Size(359, 106);
            this.grpBilancio.TabIndex = 7;
            this.grpBilancio.TabStop = false;
            this.grpBilancio.Tag = "AutoManage.txtBilancio.treesupb.(idupb=\'0001\')";
            this.grpBilancio.Text = "Bilancio";
            // 
            // txtDenominazioneBil
            // 
            this.txtDenominazioneBil.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenominazioneBil.Location = new System.Drawing.Point(128, 12);
            this.txtDenominazioneBil.Multiline = true;
            this.txtDenominazioneBil.Name = "txtDenominazioneBil";
            this.txtDenominazioneBil.ReadOnly = true;
            this.txtDenominazioneBil.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDenominazioneBil.Size = new System.Drawing.Size(223, 57);
            this.txtDenominazioneBil.TabIndex = 7;
            this.txtDenominazioneBil.Tag = "finview.title";
            // 
            // txtBilancio
            // 
            this.txtBilancio.Location = new System.Drawing.Point(6, 78);
            this.txtBilancio.Name = "txtBilancio";
            this.txtBilancio.Size = new System.Drawing.Size(347, 23);
            this.txtBilancio.TabIndex = 5;
            this.txtBilancio.Tag = "finview.codefin";
            // 
            // btnBilancio
            // 
            this.btnBilancio.Location = new System.Drawing.Point(6, 49);
            this.btnBilancio.Name = "btnBilancio";
            this.btnBilancio.Size = new System.Drawing.Size(104, 23);
            this.btnBilancio.TabIndex = 6;
            this.btnBilancio.Tag = "manage.finview.treesupb.(idupb=\'0001\')";
            this.btnBilancio.Text = "Codice";
            // 
            // btnCrea
            // 
            this.btnCrea.Location = new System.Drawing.Point(751, 427);
            this.btnCrea.Name = "btnCrea";
            this.btnCrea.Size = new System.Drawing.Size(75, 23);
            this.btnCrea.TabIndex = 4;
            this.btnCrea.Text = "Crea";
            this.btnCrea.Click += new System.EventHandler(this.btnCrea_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(16, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(836, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tenere premuto il tasto CTRL o MAIUSC e contemporaneamente cliccare con il mouse " +
    "per selezionare più movimenti di spesa";
            // 
            // txtMovimentiSelezionati
            // 
            this.txtMovimentiSelezionati.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMovimentiSelezionati.Location = new System.Drawing.Point(130, 361);
            this.txtMovimentiSelezionati.Name = "txtMovimentiSelezionati";
            this.txtMovimentiSelezionati.ReadOnly = true;
            this.txtMovimentiSelezionati.Size = new System.Drawing.Size(716, 23);
            this.txtMovimentiSelezionati.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Location = new System.Drawing.Point(2, 361);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Movimenti Selezionati:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgMovSpesa
            // 
            this.dgMovSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgMovSpesa.DataMember = "";
            this.dgMovSpesa.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMovSpesa.Location = new System.Drawing.Point(8, 32);
            this.dgMovSpesa.Name = "dgMovSpesa";
            this.dgMovSpesa.Size = new System.Drawing.Size(844, 323);
            this.dgMovSpesa.TabIndex = 0;
            this.dgMovSpesa.Paint += new System.Windows.Forms.PaintEventHandler(this.dgMovSpesa_Paint);
            // 
            // btnIndietro
            // 
            this.btnIndietro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnIndietro.Location = new System.Drawing.Point(184, 546);
            this.btnIndietro.Name = "btnIndietro";
            this.btnIndietro.Size = new System.Drawing.Size(75, 23);
            this.btnIndietro.TabIndex = 1;
            this.btnIndietro.Text = "< Indietro";
            this.btnIndietro.Click += new System.EventHandler(this.btnIndietro_Click);
            // 
            // btnAvanti
            // 
            this.btnAvanti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAvanti.Location = new System.Drawing.Point(288, 546);
            this.btnAvanti.Name = "btnAvanti";
            this.btnAvanti.Size = new System.Drawing.Size(75, 23);
            this.btnAvanti.TabIndex = 2;
            this.btnAvanti.Text = "Avanti >";
            this.btnAvanti.Click += new System.EventHandler(this.btnAvanti_Click);
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(716, 546);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 3;
            this.btnAnnulla.Text = "Annulla";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // tabControllerMagic
            // 
            this.tabControllerMagic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabControllerMagic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControllerMagic.IDEPixelArea = true;
            this.tabControllerMagic.Location = new System.Drawing.Point(0, 0);
            this.tabControllerMagic.Name = "tabControllerMagic";
            this.tabControllerMagic.SelectedIndex = 1;
            this.tabControllerMagic.SelectedTab = this.tabCreaMov;
            this.tabControllerMagic.Size = new System.Drawing.Size(860, 530);
            this.tabControllerMagic.TabIndex = 4;
            this.tabControllerMagic.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPresentazione,
            this.tabCreaMov});
            // 
            // tabCreaMov
            // 
            this.tabCreaMov.Controls.Add(this.gboxUPB);
            this.tabCreaMov.Controls.Add(this.btnCrea);
            this.tabCreaMov.Controls.Add(this.grpBilancio);
            this.tabCreaMov.Controls.Add(this.txtMovimentiSelezionati);
            this.tabCreaMov.Controls.Add(this.label3);
            this.tabCreaMov.Controls.Add(this.dgMovSpesa);
            this.tabCreaMov.Controls.Add(this.label4);
            this.tabCreaMov.Location = new System.Drawing.Point(0, 0);
            this.tabCreaMov.Name = "tabCreaMov";
            this.tabCreaMov.Size = new System.Drawing.Size(860, 505);
            this.tabCreaMov.TabIndex = 4;
            this.tabCreaMov.Title = "Pagina 2 di 2";
            // 
            // gboxUPB
            // 
            this.gboxUPB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gboxUPB.Controls.Add(this.txtUPB);
            this.gboxUPB.Controls.Add(this.txtDescrUPB);
            this.gboxUPB.Controls.Add(this.btnUPBCode);
            this.gboxUPB.Location = new System.Drawing.Point(4, 388);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(376, 104);
            this.gboxUPB.TabIndex = 8;
            this.gboxUPB.TabStop = false;
            this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
            // 
            // txtUPB
            // 
            this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUPB.Location = new System.Drawing.Point(8, 77);
            this.txtUPB.Name = "txtUPB";
            this.txtUPB.Size = new System.Drawing.Size(359, 23);
            this.txtUPB.TabIndex = 5;
            this.txtUPB.Tag = "upb.codeupb?x";
            // 
            // txtDescrUPB
            // 
            this.txtDescrUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrUPB.Location = new System.Drawing.Point(152, 9);
            this.txtDescrUPB.Multiline = true;
            this.txtDescrUPB.Name = "txtDescrUPB";
            this.txtDescrUPB.ReadOnly = true;
            this.txtDescrUPB.Size = new System.Drawing.Size(215, 62);
            this.txtDescrUPB.TabIndex = 4;
            this.txtDescrUPB.TabStop = false;
            this.txtDescrUPB.Tag = "upb.title";
            // 
            // btnUPBCode
            // 
            this.btnUPBCode.BackColor = System.Drawing.SystemColors.Control;
            this.btnUPBCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUPBCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUPBCode.Location = new System.Drawing.Point(8, 51);
            this.btnUPBCode.Name = "btnUPBCode";
            this.btnUPBCode.Size = new System.Drawing.Size(112, 20);
            this.btnUPBCode.TabIndex = 2;
            this.btnUPBCode.TabStop = false;
            this.btnUPBCode.Tag = "manage.upb.tree";
            this.btnUPBCode.Text = "UPB";
            this.btnUPBCode.UseVisualStyleBackColor = false;
            // 
            // tabPresentazione
            // 
            this.tabPresentazione.Controls.Add(this.label1);
            this.tabPresentazione.Controls.Add(this.label2);
            this.tabPresentazione.Controls.Add(this.lblTitolo);
            this.tabPresentazione.Location = new System.Drawing.Point(0, 0);
            this.tabPresentazione.Name = "tabPresentazione";
            this.tabPresentazione.Selected = false;
            this.tabPresentazione.Size = new System.Drawing.Size(860, 505);
            this.tabPresentazione.TabIndex = 3;
            this.tabPresentazione.Title = "Pagina 1 di 2";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.tabControllerMagic);
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(860, 530);
            this.panel1.TabIndex = 5;
            // 
            // Frm_expense_wizardcreamovcompetenza
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(876, 576);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnAvanti);
            this.Controls.Add(this.btnIndietro);
            this.Controls.Add(this.btnAnnulla);
            this.Name = "Frm_expense_wizardcreamovcompetenza";
            this.Text = "frmWizardSpesaCreaMovCompetenza";
            ((System.ComponentModel.ISupportInitialize)(this.DS2)).EndInit();
            this.grpBilancio.ResumeLayout(false);
            this.grpBilancio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMovSpesa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.tabControllerMagic.ResumeLayout(false);
            this.tabCreaMov.ResumeLayout(false);
            this.tabCreaMov.PerformLayout();
            this.gboxUPB.ResumeLayout(false);
            this.gboxUPB.PerformLayout();
            this.tabPresentazione.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private void btnIndietro_Click(object sender, System.EventArgs e) {
            AbilitaDisabilita(false);
            StandardChangeTab(-1);
            AbilitaDisabilita(true);
        }

        private void btnAvanti_Click(object sender, System.EventArgs e) {
            AbilitaDisabilita(false);
            StandardChangeTab(+1);
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

        void riempiGrid() {
            //DS2.Clear();    
  
            // CONTROLLARE CHE IL Clear() DI QUESTE TABELLE SIA CORRETTO !!!! (Sara)
            DS2.expense.Clear();
            DS2.expenseyear.Clear();
            DS2.expensetotal.Clear();
            DS2.expensesorted.Clear();
            DS2.expenseview.Clear(); DS2.lessexpenseview.Clear();
            // Filtro tutti i mov. di spesa che hanno una variazione 
            // con tipoautomatismo ECONO e che non sono presenti in alcun idparent

            string filterRiporti = QHS.AppAnd(QHS.CmpEq("ayear", oldYear), QHS.IsNull("idchild"));

            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS2.lessexpenseview, null, filterRiporti, null, true);
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS2.expensephase, null, null, null, true);
            foreach (DataColumn C in DS2.lessexpenseview.Columns) {
                C.Caption = "";
            }
            DS2.lessexpenseview.Columns["phase"].Caption = "Fase";
            DS2.lessexpenseview.Columns["nmov"].Caption = "Num. Mov.";
            DS2.lessexpenseview.Columns["ymov"].Caption = "Eserc. Mov.";
            DS2.lessexpenseview.Columns["codefin"].Caption = "Bilancio Eserc. Prec.";
            DS2.lessexpenseview.Columns["upb"].Caption = "UPB";
            DS2.lessexpenseview.Columns["underwriting"].Caption = "Finanziamento";
            DS2.lessexpenseview.Columns["registry"].Caption = "Creditore";
            DS2.lessexpenseview.Columns["amount"].Caption = "Importo";
            DS2.lessexpenseview.Columns["variationamount"].Caption = "Importo Variato";
            DS2.lessexpenseview.Columns["curramount"].Caption = "Importo Corrente";
            DS2.lessexpenseview.Columns["available"].Caption = "Disponibile";

            if (dgMovSpesa.DataSource == null) {
                HelpForm.SetDataGrid(dgMovSpesa, DS2.lessexpenseview);
                new formatgrids(dgMovSpesa).AutosizeColumnWidth();
            }
        }

        private void dgMovSpesa_Paint(object sender, System.Windows.Forms.PaintEventArgs e) {
            selezioneRigheCambiata();
        }

        private void selezioneRigheCambiata() {
            string dataMember = dgMovSpesa.DataMember;
            CurrencyManager cm = (CurrencyManager)dgMovSpesa.BindingContext[DS2, dataMember];
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

        private void aggiornaDataGrid() {
            DS.Clear();
            riempiGrid();
        }

        void ViewAutomatismi(DataSet DS){
            string spesa = null;
            if (DS.Tables["expense"] != null)
            {
                DataTable Var = DS.Tables["expense"];
                spesa = QHS.FieldIn("idexp", Var.Select(), "idexp");
            }

            Form F = ShowAutomatismi.Show(Meta, spesa, null, null, null);
            F.ShowDialog(this);
        }

        private void btnCrea_Click(object sender, System.EventArgs e) {
            string dataMember = dgMovSpesa.DataMember;
            CurrencyManager cm = (CurrencyManager)dgMovSpesa.BindingContext[DS2, dataMember];
            DataView view = cm.List as DataView;
            if (view == null) {
                MessageBox.Show(this, "Lista vuota!");
                return;
            }
            ArrayList movimenti = new ArrayList();
            string filtroMovimenti = "";
            
            MovimentiElaborati = new Hashtable();

            for (int i = 0; i < view.Count; i++) {
                if (dgMovSpesa.IsSelected(i)) {
                    object idSpesa = view[i]["idexp"];
                    if (movimenti.IndexOf(idSpesa) == -1) {
                        movimenti.Add(idSpesa);
                        filtroMovimenti += ", " + QHS.quote(idSpesa) + "";
                    }
                }
            }

            if (movimenti.Count == 0) {
                MessageBox.Show(this, "Nessun movimento di spesa selezionato!");
                return;
            }

            if (filtroMovimenti != "")
            {
                filtroMovimenti = filtroMovimenti.Substring(1);
            }

            foreach (object idSpesa in movimenti) {
                creaMovSpesa(idSpesa);
            }


            int fasespesamax = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));



            GestioneAutomatismi ga = new GestioneAutomatismi(this, Meta.Conn, Meta.Dispatcher, DS2.Copy(),
                         fasespesamax, fasespesamax, "expense", true);
            ga.GeneraClassificazioniAutomatiche(ga.DSP, true);
            
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
            // CONTROLLARE CHE IL Clear() DI QUESTE TABELLE SIA CORRETTO !!!! (Sara)
            DS2.expense.Clear();
            DS2.expenseyear.Clear();
            DS2.expensetotal.Clear();
            DS2.expensesorted.Clear();
            DS2.expenseview.Clear();

            DS2.AcceptChanges();
            dgMovSpesa.DataSource = null;
            aggiornaDataGrid();
        }

        Hashtable MovimentiElaborati = new Hashtable();
        void creaMovSpesa(object idSpesa) {
            if (MovimentiElaborati[idSpesa.ToString()] != null)
                return;
            
            MovimentiElaborati[idSpesa.ToString()] = "S";

            int esercizio = (int)Meta.GetSys("esercizio");
            
            //DataRow[] drMovimento = DS2.lessexpenseview.Select("(idexp = " + idSpesa + ") ");
            DataRow[] drMovimento = DS2.lessexpenseview.Select(QHC.CmpEq("idexp",idSpesa));

            //Ci possono essere più righe
                              
            if (drMovimento.Length == 0) return;
            DataRow Mov = drMovimento[0];

            object newidbilancio;
            object newidupb;

            if (txtBilancio.Text != "") {
                string filterVoce = QHS.AppAnd(
                    QHS.CmpEq("ayear", esercizio), QHS.BitSet("flag", 0),
                    QHS.CmpEq("codefin", txtBilancio.Text));
                newidbilancio = Meta.Conn.DO_READ_VALUE("fin", filterVoce, "idfin");
                
            }
            else {
                object app = Meta.Conn.DO_READ_VALUE("finlookup", QHS.CmpEq("oldidfin",Mov["idfin"]),"newidfin");
                if (app != null) {
                    newidbilancio = app;
                }
                else {
                    newidbilancio = DBNull.Value;
                }
            }


            if (txtUPB.Text !="") {
                newidupb = Meta.GetAutoField(txtUPB);
            }
            else {
                newidupb = Mov["idupb"];
            }

            MetaData metaSpesa = MetaData.GetMetaData(this, "expense");
            MetaData metaImpuSpesa = MetaData.GetMetaData(this, "expenseyear");
            MetaData metaUnderwritingAppropriation = MetaData.GetMetaData(this, "underwritingappropriation");
            metaSpesa.SetDefaults(DS2.expense);
            metaImpuSpesa.SetDefaults(DS2.expenseyear);
            metaUnderwritingAppropriation.SetDefaults(DS2.underwritingappropriation);

            MetaData.SetDefault(DS2.expenseyear, "ayear", esercizio);

            MetaData.SetDefault(DS2.expense, "parentidexp", Mov["parentidexp"]);
            DataRow DRSpesa = metaSpesa.Get_New_Row(null, DS2.expense);

            //DRSpesa["amount"] = -(decimal)Mov["variationamount"];
            DRSpesa["idformerexpense"] = Mov["idexp"];
            DRSpesa["idreg"] = Mov["idreg"];
            DRSpesa["autokind"] = 5;
            DRSpesa["description"] = Mov["expensedescription"];
            DRSpesa["idman"] = Mov["idman"];
            DRSpesa["doc"] = Mov["doc"];
            DRSpesa["docdate"] = Mov["docdate"];
            AddVociCollegate(DRSpesa, newidbilancio);

            decimal mov_amount = 0;
            foreach (DataRow rr in drMovimento) {
                mov_amount += CfgFn.GetNoNullDecimal(rr["variationamount"]);
            }

            DataRow DRImpuSpesa = metaImpuSpesa.Get_New_Row(DRSpesa, DS2.expenseyear);
            //DRImpuSpesa["nphase"] = DRSpesa["nphase"];
            DRImpuSpesa["idfin"] = newidbilancio;
            DRImpuSpesa["idupb"] = newidupb;
            DRImpuSpesa["amount"] = -mov_amount;
            AddVociCollegate(DRImpuSpesa, newidbilancio);

            foreach (DataRow RR in drMovimento) {
                if (RR["idunderwriting"] == DBNull.Value)
                    continue;
                DataRow DrUnderwritingAppropriation = metaUnderwritingAppropriation.Get_New_Row(DRSpesa, DS2.underwritingappropriation);
                DrUnderwritingAppropriation["idunderwriting"] = RR["idunderwriting"];
                DrUnderwritingAppropriation["amount"] = -CfgFn.GetNoNullDecimal( RR["variationamount"]);
            }
           
 
        }


        void AddVoceBilancio(object ID) {
            if (ID == DBNull.Value) return;
            if (DS2.Tables["fin"] == null) return;
            if (DS2.Tables["fin"].Select(QHC.CmpEq("idfin",ID)).Length > 0) return;
            object codefin = Meta.Conn.DO_READ_VALUE("fin", QHS.CmpEq("idfin", ID), "codefin");
            DataRow NewBil = DS2.Tables["fin"].NewRow();
            NewBil["idfin"] = ID;
            NewBil["codefin"] = codefin;
            DS2.Tables["fin"].Rows.Add(NewBil);
            NewBil.AcceptChanges();
        }


        void AddVoceUPB(object ID, object codupb) {
            if (ID == DBNull.Value) return;
            if (DS2.Tables["upb"] == null) return;
            if (DS2.Tables["upb"].Select(QHC.CmpEq("idupb", ID)).Length > 0) return;
            DataRow NewUPB = DS2.Tables["upb"].NewRow();
            NewUPB["idupb"] = ID;
            NewUPB["codeupb"] = codupb;
            DS2.Tables["upb"].Rows.Add(NewUPB);
            NewUPB.AcceptChanges();
        }

        void AddVoceFase(object codice, object descr) {
            if (codice == DBNull.Value) return;
            if (DS2.Tables["expensephase"] == null) return;
            if (DS2.Tables["expensephase"].Select(QHC.CmpEq("nphase",codice)).Length > 0) return;
            DataRow NewFase = DS2.Tables["expensephase"].NewRow();
            NewFase["nphase"] = codice;
            NewFase["description"] = descr;
            DS2.Tables["expensephase"].Rows.Add(NewFase);
            NewFase.AcceptChanges();
        }


        void AddVoceCreditore(object codice, object denominazione) {
            if (codice == DBNull.Value) return;
            if (DS2.Tables["registry"] == null) return;
            if (DS2.Tables["registry"].Select(QHC.CmpEq("idreg",codice)).Length > 0) return;
            DataRow NewCred = DS2.Tables["registry"].NewRow();
            NewCred["idreg"] = codice;
            NewCred["title"] = denominazione;
            DS2.Tables["registry"].Rows.Add(NewCred);
            NewCred.AcceptChanges();
        }

        void AddVoceResponsabile(object codice, object descr) {
            if (codice == DBNull.Value) return;
            if (DS2.Tables["manager"] == null) return;
            if (DS2.Tables["manager"].Select(QHC.CmpEq("idman",codice)).Length > 0) return;
            DataRow NewResp = DS2.Tables["manager"].NewRow();
            NewResp["idman"] = codice;
            NewResp["title"] = descr;
            DS2.Tables["manager"].Rows.Add(NewResp);
            NewResp.AcceptChanges();
        }


        void AddVociCollegate(DataRow SP_Row, object newidbilancio) {
            if ((SP_Row.Table.Columns["nphase"] != null) &&
                (SP_Row.Table.Columns["description"] != null)) {
                AddVoceFase(SP_Row["nphase"], SP_Row["description"]);
            }

            if (newidbilancio != null) {
                AddVoceBilancio(newidbilancio);
            }

            if ((SP_Row.Table.Columns["idupb"] != null) &&
                (SP_Row.Table.Columns["codeupb"] != null)) {
                AddVoceUPB(SP_Row["idupb"], SP_Row["codeupb"]);
            }

            if ((SP_Row.Table.Columns["idreg"] != null) &&
                (SP_Row.Table.Columns["title"] != null)) {
                AddVoceCreditore(SP_Row["idreg"], SP_Row["title"]);
            }
            if ((SP_Row.Table.Columns["idman"] != null) &&
                (SP_Row.Table.Columns["manager"] != null)) {
                AddVoceResponsabile(SP_Row["idman"], SP_Row["manager"]);
            }

        }

    }
}
