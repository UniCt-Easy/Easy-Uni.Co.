/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
using funzioni_configurazione;
using ep_functions;

namespace payroll_trasf_cedolino {
    public class frmcedolino_trasferimento : MetaDataForm {
        MetaData Meta;
        int esercizio;
        int statoCheckboxRiepilogo = int.MinValue;
        string CustomTitle;
        private ArrayList pagine;
        private int selectedIndex;
        private System.Windows.Forms.TabPage tabIntro;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblErrore;
        private System.Windows.Forms.TabControl tabController;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnIndietro;
        private System.Windows.Forms.Button btnAvanti;
        private System.Windows.Forms.TabPage tabCedNonTrasferibili;
        private System.Windows.Forms.TabPage tabCedTrasferibili;
        private System.Windows.Forms.DataGrid dgCedoliniNonTrasferibili;
        private System.Windows.Forms.DataGrid dgCedoliniTrasferibili;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtCedoliniSelezionati;
        private System.Windows.Forms.TextBox txtSelezionaCedolini;
        private System.Windows.Forms.Button btnSelezionaCedolini;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        public vistaForm DS;
        public dsCedolino dsCedolino;
        private System.ComponentModel.Container components = null;
        QueryHelper QHS;
        private CheckBox chkConguaglioRiepilogativo;
        private Label label2;
        CQueryHelper QHC;
        DataAccess Conn;

        public frmcedolino_trasferimento() {
            InitializeComponent();
            CustomTitle = "Wizard Trasferimento dei Cedolini";
            pagine = new ArrayList();
            pagine.Add(tabIntro);
            pagine.Add(tabCedNonTrasferibili);
            pagine.Add(tabCedTrasferibili);
            tabController.TabPages.Clear();
            tabController.TabPages.Add((TabPage)pagine[0]);
            DataAccess.SetTableForReading(dsCedolino.cedolinonontrasferibile, "payroll");
            DataAccess.SetTableForReading(dsCedolino.cedolinoerogato, "payroll");
            DataAccess.SetTableForReading(dsCedolino.cedolinoannosuccessivo, "payroll");
			DataAccess.SetTableForReading(dsCedolino.upb_cedolinonontrasferibile, "upb");
			DataAccess.SetTableForReading(dsCedolino.upb_cedolinoerogato, "upb");
			DataAccess.SetTableForReading(dsCedolino.upb_cedolinoannosuccessivo, "upb");
			DataAccess.SetTableForReading(dsCedolino.upb_payroll, "upb");
			ContextMenu ExcelMenu;
            ExcelMenu = new ContextMenu();
            ExcelMenu.MenuItems.Add("Excel", new EventHandler(Excel_Click));
            dgCedoliniNonTrasferibili.ContextMenu = ExcelMenu;
            dgCedoliniTrasferibili.ContextMenu = ExcelMenu;
        }

        private void Excel_Click(object menusender, EventArgs e)
        {
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
        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            esercizio = (int)Meta.GetSys("esercizio");
            ClearDataSet.RemoveConstraints(dsCedolino);

            string fService = QHS.CmpEq("module", "COCOCO");
            Meta.Conn.RUN_SELECT_INTO_TABLE(dsCedolino.service, null, fService, null, true);

			Meta.Conn.RUN_SELECT_INTO_TABLE(dsCedolino.upb_cedolinoannosuccessivo, null, null, null, true);
			Meta.Conn.RUN_SELECT_INTO_TABLE(dsCedolino.upb_payroll, null, null, null, true);
			Meta.Conn.RUN_SELECT_INTO_TABLE(dsCedolino.upb_cedolinoerogato, null, null, null, true);
			Meta.Conn.RUN_SELECT_INTO_TABLE(dsCedolino.upb_cedolinonontrasferibile, null, null, null, true);
			riempiTabCedolini();
            visualizzaEtichetta();
            DisplayTabs(0);

            Meta.CanCancel = false;
            Meta.canInsert = false;
            Meta.canSave = false;
            Meta.canInsertCopy = false;
            Meta.searchEnabled = false;


        }

        private void visualizzaEtichetta() {
            lblErrore.Visible = false;
            int eserciziosucc = esercizio + 1;
            string filtro = QHS.CmpEq("ayear", eserciziosucc);
            object esisteNextYear = Meta.Conn.DO_READ_VALUE("accountingyear", filtro, "COUNT(*)");
            if ((esisteNextYear == null) || (esisteNextYear == DBNull.Value) || ((int)esisteNextYear == 0)) {
                lblErrore.Visible = true;
                string messaggio = "Attenzione! Il trasferimento dei cedolini non può essere utilizzato in quanto non esiste l'esercizio " + eserciziosucc + "!"
                    + "\nPer creare l'esercizio " + eserciziosucc + " andare dal menu Configurazione - Chiusura - Fase Corrente e procedere"
                    + " all'apertura dell'esercizio.";
                lblErrore.Text = messaggio;
                AbilitaDisabilita(false);
            }
        }

        #region Windows Form Designer generated code
        private void InitializeComponent() {
			this.DS = new payroll_trasf_cedolino.vistaForm();
			this.tabController = new System.Windows.Forms.TabControl();
			this.tabIntro = new System.Windows.Forms.TabPage();
			this.lblErrore = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tabCedNonTrasferibili = new System.Windows.Forms.TabPage();
			this.label17 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.dgCedoliniNonTrasferibili = new System.Windows.Forms.DataGrid();
			this.tabCedTrasferibili = new System.Windows.Forms.TabPage();
			this.label2 = new System.Windows.Forms.Label();
			this.chkConguaglioRiepilogativo = new System.Windows.Forms.CheckBox();
			this.txtCedoliniSelezionati = new System.Windows.Forms.TextBox();
			this.txtSelezionaCedolini = new System.Windows.Forms.TextBox();
			this.btnSelezionaCedolini = new System.Windows.Forms.Button();
			this.label19 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.dgCedoliniTrasferibili = new System.Windows.Forms.DataGrid();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.btnIndietro = new System.Windows.Forms.Button();
			this.btnAvanti = new System.Windows.Forms.Button();
			this.dsCedolino = new payroll_trasf_cedolino.dsCedolino();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.tabController.SuspendLayout();
			this.tabIntro.SuspendLayout();
			this.tabCedNonTrasferibili.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgCedoliniNonTrasferibili)).BeginInit();
			this.tabCedTrasferibili.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgCedoliniTrasferibili)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCedolino)).BeginInit();
			this.SuspendLayout();
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			this.tabController.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabController.Controls.Add(this.tabIntro);
			this.tabController.Controls.Add(this.tabCedNonTrasferibili);
			this.tabController.Controls.Add(this.tabCedTrasferibili);
			this.tabController.Location = new System.Drawing.Point(8, 8);
			this.tabController.Name = "tabController";
			this.tabController.SelectedIndex = 0;
			this.tabController.Size = new System.Drawing.Size(766, 477);
			this.tabController.TabIndex = 0;
			this.tabIntro.Controls.Add(this.lblErrore);
			this.tabIntro.Controls.Add(this.label16);
			this.tabIntro.Controls.Add(this.label6);
			this.tabIntro.Controls.Add(this.label5);
			this.tabIntro.Controls.Add(this.label4);
			this.tabIntro.Controls.Add(this.label1);
			this.tabIntro.Location = new System.Drawing.Point(4, 22);
			this.tabIntro.Name = "tabIntro";
			this.tabIntro.Size = new System.Drawing.Size(758, 451);
			this.tabIntro.TabIndex = 0;
			this.tabIntro.Text = "Pagina 1 di 3";
			this.lblErrore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblErrore.Location = new System.Drawing.Point(16, 245);
			this.lblErrore.Name = "lblErrore";
			this.lblErrore.Size = new System.Drawing.Size(712, 88);
			this.lblErrore.TabIndex = 20;
			this.lblErrore.Text = "Visualizza Errore";
			this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label16.Location = new System.Drawing.Point(24, 80);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(702, 23);
			this.label16.TabIndex = 19;
			this.label16.Text = "Vengono mostrati tutti i cedolini non trasferibili con la causa della loro non tr" +
    "asferibilità";
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.Location = new System.Drawing.Point(24, 144);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(702, 24);
			this.label6.TabIndex = 17;
			this.label6.Text = "Vengono mostrati tutti i cedolini trasferibili. L\'utente sceglierà quali trasferi" +
    "re nell\'esercizio successivo";
			this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(8, 56);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(264, 16);
			this.label5.TabIndex = 16;
			this.label5.Text = "FASE 1: Griglia dei Cedolini Non Trasferibili";
			this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(8, 112);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(264, 16);
			this.label4.TabIndex = 15;
			this.label4.Text = "FASE 2: Griglia dei cedolini trasferibili";
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(743, 24);
			this.label1.TabIndex = 14;
			this.label1.Text = "La procedura di trasferimento dei cedolini consente di trasferire i cedolini dall" +
    "\'anno fiscale corrente all\'anno fiscale successivo.";
			this.tabCedNonTrasferibili.Controls.Add(this.label17);
			this.tabCedNonTrasferibili.Controls.Add(this.label24);
			this.tabCedNonTrasferibili.Controls.Add(this.dgCedoliniNonTrasferibili);
			this.tabCedNonTrasferibili.Location = new System.Drawing.Point(4, 22);
			this.tabCedNonTrasferibili.Name = "tabCedNonTrasferibili";
			this.tabCedNonTrasferibili.Size = new System.Drawing.Size(758, 451);
			this.tabCedNonTrasferibili.TabIndex = 1;
			this.tabCedNonTrasferibili.Text = "Pagina 2 di 3";
			this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label17.Location = new System.Drawing.Point(8, 32);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(742, 16);
			this.label17.TabIndex = 18;
			this.label17.Text = "TUTTI I CEDOLINI ELENCATI DEVONO ESSERE EROGATI IN QUESTO ANNO";
			this.label17.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label24.Location = new System.Drawing.Point(8, 8);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(742, 23);
			this.label24.TabIndex = 19;
			this.label24.Text = "FASE 1: viene mostrato l\'elenco dei cedolini non trasferibili";
			this.label24.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.dgCedoliniNonTrasferibili.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgCedoliniNonTrasferibili.DataMember = "";
			this.dgCedoliniNonTrasferibili.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgCedoliniNonTrasferibili.Location = new System.Drawing.Point(8, 48);
			this.dgCedoliniNonTrasferibili.Name = "dgCedoliniNonTrasferibili";
			this.dgCedoliniNonTrasferibili.Size = new System.Drawing.Size(742, 389);
			this.dgCedoliniNonTrasferibili.TabIndex = 0;
			this.tabCedTrasferibili.Controls.Add(this.label2);
			this.tabCedTrasferibili.Controls.Add(this.chkConguaglioRiepilogativo);
			this.tabCedTrasferibili.Controls.Add(this.txtCedoliniSelezionati);
			this.tabCedTrasferibili.Controls.Add(this.txtSelezionaCedolini);
			this.tabCedTrasferibili.Controls.Add(this.btnSelezionaCedolini);
			this.tabCedTrasferibili.Controls.Add(this.label19);
			this.tabCedTrasferibili.Controls.Add(this.label20);
			this.tabCedTrasferibili.Controls.Add(this.label23);
			this.tabCedTrasferibili.Controls.Add(this.label18);
			this.tabCedTrasferibili.Controls.Add(this.dgCedoliniTrasferibili);
			this.tabCedTrasferibili.Location = new System.Drawing.Point(4, 22);
			this.tabCedTrasferibili.Name = "tabCedTrasferibili";
			this.tabCedTrasferibili.Size = new System.Drawing.Size(758, 451);
			this.tabCedTrasferibili.TabIndex = 2;
			this.tabCedTrasferibili.Text = "Pagina 3 di 3";
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(8, 428);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(653, 13);
			this.label2.TabIndex = 18;
			this.label2.Text = "N.B.:Si sconsiglia di effettuare tale operazione in quanto il conguaglio fiscale " +
    "è un obbligo del sostituto d\'imposta.";
			this.chkConguaglioRiepilogativo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chkConguaglioRiepilogativo.AutoSize = true;
			this.chkConguaglioRiepilogativo.Location = new System.Drawing.Point(11, 406);
			this.chkConguaglioRiepilogativo.Name = "chkConguaglioRiepilogativo";
			this.chkConguaglioRiepilogativo.Size = new System.Drawing.Size(676, 17);
			this.chkConguaglioRiepilogativo.TabIndex = 17;
			this.chkConguaglioRiepilogativo.Text = "Per i cedolini selezionati, NON calcolare un CONGUAGLIO  FISCALE ma solo un Cedol" +
    "ino di Riepilogo di quanto già erogato nell\'esercizio.";
			this.chkConguaglioRiepilogativo.UseVisualStyleBackColor = true;
			this.txtCedoliniSelezionati.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCedoliniSelezionati.Location = new System.Drawing.Point(112, 372);
			this.txtCedoliniSelezionati.Name = "txtCedoliniSelezionati";
			this.txtCedoliniSelezionati.ReadOnly = true;
			this.txtCedoliniSelezionati.Size = new System.Drawing.Size(638, 20);
			this.txtCedoliniSelezionati.TabIndex = 16;
			this.txtSelezionaCedolini.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSelezionaCedolini.Location = new System.Drawing.Point(88, 340);
			this.txtSelezionaCedolini.Name = "txtSelezionaCedolini";
			this.txtSelezionaCedolini.Size = new System.Drawing.Size(662, 20);
			this.txtSelezionaCedolini.TabIndex = 15;
			this.btnSelezionaCedolini.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnSelezionaCedolini.Location = new System.Drawing.Point(8, 340);
			this.btnSelezionaCedolini.Name = "btnSelezionaCedolini";
			this.btnSelezionaCedolini.Size = new System.Drawing.Size(75, 23);
			this.btnSelezionaCedolini.TabIndex = 13;
			this.btnSelezionaCedolini.Text = "Seleziona";
			this.btnSelezionaCedolini.Click += new System.EventHandler(this.btnSelezionaCedolini_Click);
			this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label19.Location = new System.Drawing.Point(8, 316);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(744, 23);
			this.label19.TabIndex = 12;
			this.label19.Text = "Immettere i numeri e/o gli intervalli di cedolini separati da virgole. Es.: per s" +
    "elezionare i cedolini 1,4,6,7,8 scrivere 1,4,6-8 e premi Seleziona.";
			this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label20.Location = new System.Drawing.Point(8, 372);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(104, 24);
			this.label20.TabIndex = 14;
			this.label20.Text = "Cedolini Selezionati";
			this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label23.Location = new System.Drawing.Point(8, 8);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(742, 16);
			this.label23.TabIndex = 10;
			this.label23.Text = "FASE 2: Scelta dei cedolini da trasferire nell\'esercizio successivo";
			this.label23.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.label18.Location = new System.Drawing.Point(8, 32);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(744, 16);
			this.label18.TabIndex = 9;
			this.label18.Text = "Tenere premuto il tasto CTRL o MAIUSC e contemporaneamente cliccare con il mouse " +
    "per selezionare più cedolini";
			this.dgCedoliniTrasferibili.AllowNavigation = false;
			this.dgCedoliniTrasferibili.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgCedoliniTrasferibili.DataMember = "";
			this.dgCedoliniTrasferibili.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgCedoliniTrasferibili.Location = new System.Drawing.Point(8, 48);
			this.dgCedoliniTrasferibili.Name = "dgCedoliniTrasferibili";
			this.dgCedoliniTrasferibili.Size = new System.Drawing.Size(742, 265);
			this.dgCedoliniTrasferibili.TabIndex = 2;
			this.dgCedoliniTrasferibili.CurrentCellChanged += new System.EventHandler(this.dgCedoliniTrasferibili_CurrentCellChanged);
			this.dgCedoliniTrasferibili.Paint += new System.Windows.Forms.PaintEventHandler(this.dgCedoliniTrasferibili_Paint);
			this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(694, 493);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
			this.btnAnnulla.TabIndex = 7;
			this.btnAnnulla.Text = "Annulla";
			this.btnIndietro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnIndietro.Location = new System.Drawing.Point(496, 493);
			this.btnIndietro.Name = "btnIndietro";
			this.btnIndietro.Size = new System.Drawing.Size(75, 23);
			this.btnIndietro.TabIndex = 5;
			this.btnIndietro.Text = "< Indietro";
			this.btnIndietro.Click += new System.EventHandler(this.btnIndietro_Click);
			this.btnAvanti.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnAvanti.Cursor = System.Windows.Forms.Cursors.Default;
			this.btnAvanti.Location = new System.Drawing.Point(587, 493);
			this.btnAvanti.Name = "btnAvanti";
			this.btnAvanti.Size = new System.Drawing.Size(75, 23);
			this.btnAvanti.TabIndex = 6;
			this.btnAvanti.Text = "Avanti >";
			this.btnAvanti.Click += new System.EventHandler(this.btnAvanti_Click);
			this.dsCedolino.DataSetName = "dsCedolino";
			this.dsCedolino.EnforceConstraints = false;
			this.dsCedolino.Locale = new System.Globalization.CultureInfo("en-US");
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(782, 523);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnIndietro);
			this.Controls.Add(this.btnAvanti);
			this.Controls.Add(this.tabController);
			this.Name = "frmcedolino_trasferimento";
			this.Text = "frmcedolino_trasferimento";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.tabController.ResumeLayout(false);
			this.tabIntro.ResumeLayout(false);
			this.tabCedNonTrasferibili.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgCedoliniNonTrasferibili)).EndInit();
			this.tabCedTrasferibili.ResumeLayout(false);
			this.tabCedTrasferibili.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgCedoliniTrasferibili)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCedolino)).EndInit();
			this.ResumeLayout(false);

        }
        #endregion

        #region Riempimento e Gestione delle tabelle payroll del DataSet dsCedolino
        private void riempiCedolino() {
            string fCedoliniTrasferibili = QHS.AppAnd(QHS.CmpEq("fiscalyear", esercizio),
                QHS.CmpEq("flagbalance", "N"), QHS.IsNull("disbursementdate"));
            if (dsCedolino.cedolinonontrasferibile.Rows.Count > 0) {
                fCedoliniTrasferibili = QHS.AppAnd(fCedoliniTrasferibili,
                    QHS.FieldNotIn("idpayroll", dsCedolino.cedolinonontrasferibile.Select()));
            }
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsCedolino.payroll, "idcon", fCedoliniTrasferibili, null, true);

            if (dsCedolino.payroll.Rows.Count > 0) {
                string filtroSuContratti = QHS.FieldIn("idcon", dsCedolino.payroll.Select());
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsCedolino.parasubcontract, null, filtroSuContratti, null, true);
                string filtroSuImputazioneContratto = QHS.AppAnd(filtroSuContratti, QHS.CmpEq("ayear", esercizio));
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsCedolino.parasubcontractyear, null, filtroSuImputazioneContratto, null, true);
                riempiCedolinoAnnoSuccessivo(filtroSuContratti);
            }
        }


        private void riempiCedolinoNonTrasferibile() {
            string filtroCedolini = "";

            string queryContrattiSenzaConguaglio = "SELECT DISTINCT payroll.idcon"
                + " FROM payroll "
                + " WHERE (payroll.fiscalyear = " + QHS.quote(esercizio) + ") "
                + " AND NOT EXISTS "
                + " (SELECT * FROM payroll c "
                + " WHERE (c.fiscalyear = " + QHS.quote(esercizio) + ") "
                + " AND (c.idcon = payroll.idcon) "
                + " AND (c.flagbalance = " + QHS.quote("S") + ")) "
                + " AND EXISTS "
                + " (SELECT * FROM parasubcontractyear "
                + " WHERE (parasubcontractyear.idcon = payroll.idcon) "
                + " AND (parasubcontractyear.ayear = " + QHS.quote(esercizio) + "))";

            DataTable tContrattiSenzaConguaglio = Meta.Conn.SQLRunner(queryContrattiSenzaConguaglio);
            if (tContrattiSenzaConguaglio!=null && tContrattiSenzaConguaglio.Rows.Count > 0) {
                string filtroCedoliniSenzaConguaglio = QHS.AppAnd(
                    QHS.FieldIn("idcon", tContrattiSenzaConguaglio.Select()),
                    QHS.CmpEq("fiscalyear", esercizio));
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsCedolino.cedolinonontrasferibile,
                    null, filtroCedoliniSenzaConguaglio, null, true);
            }
            foreach (DataRow r in dsCedolino.cedolinonontrasferibile.Rows) {
                if (r["!causa"] == DBNull.Value) r["!causa"] = "Contratto senza cedolino di conguaglio";
            }

            string filtraCedoliniConguaglio = QHS.AppAnd(QHS.CmpEq("fiscalyear", esercizio),
                    QHS.IsNull("disbursementdate"), QHS.CmpEq("flagbalance", "S"));
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsCedolino.cedolinonontrasferibile,
                null, filtraCedoliniConguaglio, null, true);
            foreach (DataRow r in dsCedolino.cedolinonontrasferibile.Rows) {
                if (r["!causa"] == DBNull.Value) r["!causa"] = "Cedolino di Conguaglio";
            }


            string queryContrattiSenzaImputazione = "SELECT DISTINCT payroll.idcon"
              + " FROM payroll "
              + " WHERE (payroll.fiscalyear = " + QHS.quote(esercizio) + ") "
              + " AND payroll.disbursementdate is null AND payroll.flagbalance='N' "
              + " AND NOT EXISTS " 
              + " (SELECT * FROM parasubcontractyear "
              + " WHERE (parasubcontractyear.idcon = payroll.idcon) "
              + " AND (parasubcontractyear.ayear = " + QHS.quote(esercizio) + ")) ";

            DataTable tContrattiSenzaSenzaImputazione = Meta.Conn.SQLRunner(queryContrattiSenzaImputazione);
            if (tContrattiSenzaSenzaImputazione != null && tContrattiSenzaSenzaImputazione.Rows.Count > 0) {
                string filtraCedoliniSenzaImputazioneContratto = QHS.AppAnd(QHC.FieldIn("idcon", tContrattiSenzaSenzaImputazione.Select()),
                    QHS.CmpEq("fiscalyear", esercizio),QHS.IsNull("disbursementdate"), QHS.CmpEq("flagbalance", "N"));
                
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsCedolino.cedolinonontrasferibile,
                null, filtraCedoliniSenzaImputazioneContratto, null, true);                
            }
            foreach (DataRow r in dsCedolino.cedolinonontrasferibile.Rows) {
                if (r["!causa"] == DBNull.Value) r["!causa"] = "Cedolini con contratto senza imputazione nell'esercizio " + esercizio.ToString();
            }

            string queryCedoliniSenzaContratto = "SELECT DISTINCT payroll.idcon"
              + " FROM payroll "
              + " WHERE (payroll.fiscalyear = " + QHS.quote(esercizio) + ") "
              + " AND payroll.disbursementdate is null AND payroll.flagbalance='N' "
              + " AND NOT EXISTS "
              + " (SELECT * FROM parasubcontract "
              + " WHERE (parasubcontract.idcon = payroll.idcon)) ";

            DataTable tCedoliniSenzaContratto = Meta.Conn.SQLRunner(queryCedoliniSenzaContratto);
            if (tCedoliniSenzaContratto != null && tCedoliniSenzaContratto.Rows.Count > 0) {
                string filtraCedoliniSenzaContratto = QHS.AppAnd(QHC.FieldIn("idcon", tCedoliniSenzaContratto.Select()),
                    QHS.CmpEq("fiscalyear", esercizio), QHS.IsNull("disbursementdate"), QHS.CmpEq("flagbalance", "N"));

                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsCedolino.cedolinonontrasferibile,
                null, filtraCedoliniSenzaContratto, null, true);
            }
            foreach (DataRow r in dsCedolino.cedolinonontrasferibile.Rows) {
                if (r["!causa"] == DBNull.Value) r["!causa"] = "Cedolini senza contratto corrispondente ";
            }







            string queryCedoliniNonErogaticonCUDcollegato = "SELECT DISTINCT payroll.idcon"
              + " FROM payroll "
              + " WHERE (payroll.fiscalyear = " + QHS.quote(esercizio) + ") "
              + " AND payroll.disbursementdate is null AND payroll.flagbalance='N' "
              + " AND (select count(*) FROM exhibitedcud "
              + "   WHERE exhibitedcud.idcon = payroll.idcon AND exhibitedcud.fiscalyear = " + QHS.quote(esercizio) + " )> 0"

              + " AND (select count(*) FROM payroll P2 "
              + "   WHERE P2.idcon = payroll.idcon AND year(P2.disbursementdate) = " + QHS.quote(esercizio) + " )= 0";

            DataTable tCedoliniNonErogaticonCUDcollegato = Meta.Conn.SQLRunner(queryCedoliniNonErogaticonCUDcollegato);
            if (tCedoliniNonErogaticonCUDcollegato != null && tCedoliniNonErogaticonCUDcollegato.Rows.Count > 0) {
                string filtraCedoliniNonErogaticonCUDcollegato = QHS.AppAnd(QHC.FieldIn("idcon", tCedoliniNonErogaticonCUDcollegato.Select()),
                    QHS.CmpEq("fiscalyear", esercizio), QHS.IsNull("disbursementdate"), QHS.CmpEq("flagbalance", "N"));

                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsCedolino.cedolinonontrasferibile,
                null, filtraCedoliniNonErogaticonCUDcollegato, null, true);
            }
            foreach (DataRow r in dsCedolino.cedolinonontrasferibile.Rows) {
                if (r["!causa"] == DBNull.Value) r["!causa"] = "Cedolini il cui contratto ha un CUD collegato ma non vi è alcun cedolino erogato nell'anno in corso.Scollegare CUD.";
            }

        }

        private void riempiCedolinoAnnoSuccessivo(string filtro) {
            string filtroSuCedolino = QHS.AppAnd(filtro, QHS.CmpEq("fiscalyear", esercizio + 1));
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsCedolino.cedolinoannosuccessivo, null, filtroSuCedolino, null, true);
        }

        private void riempiCedolinoErogato() {
            string fCedoliniErogati = QHS.AppAnd(QHS.CmpEq("fiscalyear", esercizio), QHS.IsNotNull("disbursementdate"));
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsCedolino.cedolinoerogato, null, fCedoliniErogati, null, true);
            dsCedolino.cedolinoerogato.AcceptChanges();
        }

        private void riempiFigliCedolino() {
            string fChildCedolino = "";
            if (dsCedolino.payroll.Rows.Count > 0) {
                fChildCedolino = QHS.FieldIn("idpayroll", dsCedolino.payroll.Select());
            }

            if (dsCedolino.cedolinonontrasferibile.Rows.Count > 0) {
                fChildCedolino = QHS.AppOr(fChildCedolino,
                        QHS.FieldIn("idpayroll", dsCedolino.cedolinonontrasferibile.Select()));
            }

            if (fChildCedolino == "") return;
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsCedolino.payrolltax, null, fChildCedolino, null, true);
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsCedolino.payrolltaxbracket, null, fChildCedolino, null, true);
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsCedolino.payrolldeduction, null, fChildCedolino, null, true);
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsCedolino.payrollabatement, null, fChildCedolino, null, true);
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsCedolino.payrolltaxcorrige, null, fChildCedolino, null, true);
        }

        void riempiTabCedolini() {

            riempiCedolinoNonTrasferibile();
            assegnaCaptionTabCedolino(dsCedolino.cedolinonontrasferibile);
            impostaCampiCalcolatiCedolinoNonTrasferibile();

            riempiCedolino();
            assegnaCaptionTabCedolino(dsCedolino.payroll);
            impostaCampiCalcolatiCedolino();

            riempiFigliCedolino();

            riempiCedolinoErogato();
        }

        void assegnaCaptionTabCedolino(DataTable dt) {
            foreach (DataColumn C in dt.Columns) {
               C.Caption = "";
            }
            dt.Columns["idpayroll"].Caption = "Num. Cedolino";
            dt.Columns["!eserccontratto"].Caption = "Eserc. Contratto";
            dt.Columns["!numcontratto"].Caption = "Num. Contratto";
            dt.Columns["npayroll"].Caption = "Mese Rif.";
            dt.Columns["fiscalyear"].Caption = "Anno Fiscale";
            dt.Columns["!denominazione"].Caption = "Percipiente";
            dt.Columns["!causa"].Caption = "Causa";
            dt.Columns["feegross"].Caption = "Importo Lordo";
            dt.Columns["netfee"].Caption = "Importo Netto";
            dt.Columns["start"].Caption = "Data Inizio";
            dt.Columns["stop"].Caption = "Data Fine";

            if (dt.Columns.Contains("!service")) {
                dt.Columns["!service"].Caption = "Prestazione";
            }

            if (dt.Columns.Contains("!flagneedbalance")) {
                dt.Columns["!flagneedbalance"].Caption = "Cong. Obblig.";
            }

            if (dt.Columns.Contains("!primocedolinononerogato")) {
                dt.Columns["!primocedolinononerogato"].Caption = "Primo Non Erog.";
            }

			if (dt.Columns.Contains("!codeupb")) {
				dt.Columns["!codeupb"].Caption = "Cod. UPB";
			}
		}

        void impostaCampiCalcolatiCedolinoNonTrasferibile() {
            foreach (DataRow cedolinoRow in dsCedolino.cedolinonontrasferibile.Rows) {
                DataRow rContratto = selezionaInfoContratto(cedolinoRow["idcon"].ToString());
                if (rContratto == null) continue;
                cedolinoRow["!eserccontratto"] = rContratto["ycon"];
                cedolinoRow["!numcontratto"] = rContratto["ncon"];
                cedolinoRow["!denominazione"] = rContratto["registry"];

				DataRow rUPB= cedolinoRow.GetParentRow("upb_cedolinonontrasferibile_cedolinonontrasferibile");
				if (rUPB == null) {
					continue;
				}
				cedolinoRow["!codeupb"] = rUPB["codeupb"];
			}
        }

        void impostaCampiCalcolatiCedolino() {
            foreach (DataRow r in dsCedolino.payroll.Rows) {
                DataRow rContratto = r.GetParentRow("parasubcontractpayroll");
                if (rContratto == null) {
                   show(this,"Contratto di chiave " + r["idcon"] + " non trovato.", "Avviso");
                    MetaData.mainLogError(Meta, Meta.Conn,
                        "Errore in impostaCampiCalcolatiCedolino\r\n"+
                        "Contratto "+ r["idcon"]+" non trovato per riga " + r["idpayroll"], null);
                    continue;
                }
                DataRow rService = rContratto.GetParentRow("service_parasubcontract");
                if (rService == null) {
                   show(this,"Prestazione " + rContratto["idser"] + " non trovata per riga " + r["idpayroll"], "Avviso");
                    MetaData.mainLogError(Meta, Meta.Conn,
                        "Errore in impostaCampiCalcolatiCedolino\r\n" +
                        "Prestazione "+ rContratto["idser"]+" non trovata per riga " + r["idpayroll"], null);
                    continue;
                }

                r["!service"] = rService["description"];
                r["!flagneedbalance"] = rService["flagneedbalance"];

                DataRow rContrattoView = selezionaInfoContratto(r["idcon"]);
                if (rContrattoView == null) continue;
                r["!eserccontratto"] = rContrattoView["ycon"];
                r["!numcontratto"] = rContrattoView["ncon"];
                r["!denominazione"] = rContrattoView["registry"];

				DataRow rUPB= r.GetParentRow("upb_payroll_payroll");
				if (rUPB == null) {
					 	continue;
				}
				r["!codeupb"] = rUPB["codeupb"];

			}

			ArrayList contrattiConCedolinoDiConguaglio = new ArrayList();
            foreach (DataRow r in dsCedolino.cedolinonontrasferibile.Rows) {

                int pos = contrattiConCedolinoDiConguaglio.BinarySearch(r["idcon"]);                
                
                if (pos < 0) {
                    int newPos = -pos - 1;
                    if (newPos < 0) newPos = 0;
                    if (newPos > contrattiConCedolinoDiConguaglio.Count) newPos = contrattiConCedolinoDiConguaglio.Count;
                    contrattiConCedolinoDiConguaglio.Insert(newPos, r["idcon"]);
                    string filtroCedoliniErogati = QHS.AppAnd(QHS.CmpEq("idcon", r["idcon"]),
                        QHS.CmpEq("flagbalance", "N"), QHS.CmpEq("fiscalyear", esercizio), QHS.IsNotNull("disbursementdate"));
                    int nCedoliniErogatiNellAnno = Meta.Conn.RUN_SELECT_COUNT("payroll", filtroCedoliniErogati, true);
                    if (nCedoliniErogatiNellAnno == 0) continue;
                    string filter = QHS.AppAnd(QHS.CmpEq("idcon", r["idcon"]), QHS.CmpEq("flagbalance", "N"),
                        QHS.CmpEq("fiscalyear", esercizio), QHS.IsNull("disbursementdate"));
                    string orderby = "fiscalyear ASC,npayroll ASC";
                    object nPrimoCedolino = Meta.Conn.DO_READ_VALUE("payroll", filter, "TOP 1 npayroll", orderby);
                    if (nPrimoCedolino != null && nPrimoCedolino != DBNull.Value) {
                        DataRow[] rCedolino = dsCedolino.payroll.Select(QHC.AppAnd(
                            QHC.CmpEq("idcon", r["idcon"]),
                            QHC.CmpEq("npayroll", nPrimoCedolino),
                            QHC.CmpEq("flagbalance", 'N')));
                        if (rCedolino.Length > 0) {
                            if (rCedolino[0]["!flagneedbalance"].ToString().ToUpper() == "S") {
                                rCedolino[0]["!primocedolinononerogato"] = "S";
                            }
                        }
                    }
                }
            }
        }

        private DataRow selezionaInfoContratto(object idContratto) {
            string filtroContratto = QHS.AppAnd(QHS.CmpEq("idcon", idContratto),
                    QHS.CmpEq("ayear", esercizio));
            DataTable temp = DataAccess.RUN_SELECT(Meta.Conn, "parasubcontractview", "ycon,ncon,registry",
                        null, filtroContratto, null, null, true);
            return ((temp != null) && (temp.Rows.Count > 0)) ? temp.Rows[0] : null;
        }

        string selezionaCollaboratore(object codicecreddeb) {
            string filtroCreditore = QHS.CmpEq("idreg", codicecreddeb);
            object creditore = Meta.Conn.DO_READ_VALUE("registry", filtroCreditore, "title");
            return creditore.ToString();
        }
        #endregion

        #region Riempimento dei grid presenti nel WIZARD
        void riempidgCedoliniNonTrasferibili() {
            if (dgCedoliniNonTrasferibili.DataSource == null) {
                HelpForm.SetDataGrid(dgCedoliniNonTrasferibili, dsCedolino.cedolinonontrasferibile);
                new formatgrids(dgCedoliniNonTrasferibili).AutosizeColumnWidth();
            }
        }

        void riempidgCedoliniTrasferibili() {
            if (dgCedoliniTrasferibili.DataSource == null) {
                HelpForm.SetDataGrid(dgCedoliniTrasferibili, dsCedolino.payroll);
                new formatgrids(dgCedoliniTrasferibili).AutosizeColumnWidth();
            }
        }
        #endregion

        #region Gestione Bottoni del Wizard (ad esempio Avanti - Indietro etc.)
        void DisplayTabs(int newTab) {
            if (newTab < pagine.Count) {
                tabController.TabPages.Clear();
                tabController.TabPages.Add((TabPage)pagine[newTab]);
                selectedIndex = newTab;

                if (newTab == pagine.Count - 1) {
                    btnAvanti.Text = "Trasferisci";
                    btnAnnulla.Text = "Fine.";
                }
                else {
                    btnAvanti.Text = "Avanti >";
                    btnAnnulla.Text = "Annulla";
                }

                Text = CustomTitle + " (Pagina " + (newTab + 1) + " di " + pagine.Count + ")";
            }
        }

        void StandardChangeTab(int step) {
            int oldTab = selectedIndex;
            int newTab = oldTab + step;
            if ((newTab < 0) || (newTab > pagine.Count)) return;

            switch (newTab) {
                case 1: {
                        riempidgCedoliniNonTrasferibili();
                        break;
                    }
                case 2: {
                        riempidgCedoliniTrasferibili();

                        GestisciCheckboxRiepilogo();
                        break;
                    }
            }
            DisplayTabs(newTab);
        }

        private void btnAvanti_Click(object sender, System.EventArgs e) {
            if (btnAvanti.Text == "Trasferisci") {
                btnTrasferisciCedolini();
                return;
            }
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
            btnIndietro.Enabled = disponibile && (selectedIndex > 0);
            btnAnnulla.Enabled = disponibile;
        }
        #endregion

        #region Gestione selezione CEDOLINI DA TRASFERIRE

        private void aggiornaDataGrid() {
            riempidgCedoliniTrasferibili();
        }

        private void btnTrasferisciCedolini() {
            if (VerificaContrattiNonConguagliati() && !chkConguaglioRiepilogativo.Checked)
            {
                string messaggio = "Operazione non consentita!\n\n" +
                    "Sono stati selezionati cedolini di contratti non conguagliati.\n" +
                    "Per questi contratti è OBBLIGATORIO il flag 'NON calcolare un CONGUAGLIO FISCALE " +
                    "ma solo un Cedolino di Riepilogo'.\n\n" +
                    "Se si desidera escludere questi cedolini dalla CU, utilizzare l'apposito flag di esclusione, " +
                    "non la mancanza del cedolino di riepilogo.";

                show(messaggio, "Trasferimento non consentito", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string dataMember = dgCedoliniTrasferibili.DataMember;
            CurrencyManager cm = dgCedoliniTrasferibili.BindingContext[dsCedolino, dataMember] as CurrencyManager;
            if (cm == null) return;
            DataView view = cm.List as DataView;
            if (view == null) {
               show(this, "Lista vuota!");
                return;
            }

            ArrayList cedolini = new ArrayList();
            ArrayList contratti = new ArrayList();
            string filtroContratti = "";
            string filtroContrattiSQL = "";

            for (int i = 0; i < view.Count; i++) {
                if (dgCedoliniTrasferibili.IsSelected(i)) {
                    object idContratto = view[i]["idcon"];
                    object idCedolino = view[i]["idpayroll"];
                    if (contratti.IndexOf(idContratto) == -1) {
                        contratti.Add(idContratto);
                        filtroContrattiSQL += ", " + QHS.quote(idContratto) + "";
                        filtroContratti += ", " + QHS.quote(idContratto) + "";
                    }
                    cedolini.Add(idCedolino);
                }
            }

            string f = QHC.AppAnd(QHC.CmpEq("!primocedolinononerogato", "S"),
                QHC.FieldIn("idpayroll", cedolini.ToArray()));
            DataRow[] rPrimiCedNonErog = dsCedolino.payroll.Select(f);
            string cudCheAndrebberoCancellati = QHS.AppAnd(
                QHS.CmpEq("fiscalyear", Meta.GetSys("esercizio")), 
                QHS.FieldIn("idcon", rPrimiCedNonErog));
            DataTable tCudCheAndrebberoCancellati = Meta.Conn.RUN_SELECT("exhibitedcud", null, null, null, null, true);

            string primiCedoliniNonErogati = "";
            foreach (DataRow rCed in rPrimiCedNonErog) {
                DataRow[] rContr = dsCedolino.parasubcontract.Select(QHC.CmpEq("idcon", rCed["idcon"]));
                primiCedoliniNonErogati += "cedolino " + rCed["idpayroll"] + " del contratto "
                    + rContr[0]["ycon"] + "/" + rContr[0]["ncon"] + "\n";
            }

            if (primiCedoliniNonErogati.Length > 0) {
                string messaggio = "Attenzione! si stanno trasferendo alcuni cedolini che sono i primi non erogati in contratti non ancora conguagliati!";
                if(!chkConguaglioRiepilogativo.Checked){
                    messaggio = messaggio + "\nPer i contratti coinvolti verrà generato un cedolino di importo pari a 0  "
                                + "per il pagamento del conguaglio fiscale. ";
                }
                messaggio = messaggio + "\nSe si è ancora in tempo (entro il 12 gennaio "
                + (esercizio + 1)
                + ") si consiglia vivamente di trasmettere in banca i pagamenti di tali cedolini e di NON TRASFERIRLI."
                + "\nI cedolini interessati sono i seguenti:\n\n"
                + primiCedoliniNonErogati
                + "\nSi intende ugualmente trasferirli?";
                DialogResult dr =show(this, messaggio, "Trasferimento di cedolini di conguaglio",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr != DialogResult.Yes) {
                    return;
                }
            }

            string filterCedImportoZero = f = QHC.AppAnd(QHC.CmpEq("feegross", 0),
                    QHC.FieldIn("idpayroll", cedolini.ToArray()),QHC.CmpEq("start",QHC.Field("stop")));
            DataRow[] rCedoliniImportoZero = dsCedolino.payroll.Select(filterCedImportoZero);
            if (rCedoliniImportoZero.Length > 0) {
                string avviso = "Attenzione! I cedolini che hanno importo lordo pari a zero, non sono da trasferire " +
                "\nma devono essere contabilizzati nell'anno " + esercizio + ", " +
                "pagati nell'anno " + (esercizio + 1) + " possibilmente entro il 12 gennaio e " +
                "\ninseriti in un mandato insieme al pagamento del primo cedolino effettuato nel nuovo anno.";

                if (chkConguaglioRiepilogativo.Checked) {
                    avviso = avviso + "\nAvendo scelto di calcolare un Cedolino di Riepilogo, il tarsferimento sarà comunque eseguito.";
                   show(this, avviso, "Cedolini a importo lordo pari a 0");
                }
                else{
                   show(this, avviso, "Cedolini a importo lordo pari a 0");                   
                    return;
                }
            }
            
            if (cedolini.Count == 0) {
               show(this, "Nessun cedolino selezionato!");
                return;
            }

            
            filtroContrattiSQL = filtroContrattiSQL.Substring(1);
            string orderby = "fiscalyear, npayroll DESC";

            string filtroCedolini = QHS.AppAnd(QHS.CmpEq("fiscalyear", esercizio), QHS.CmpEq("flagbalance", "N"),
                        QHS.IsNull("disbursementdate"), QHS.FieldInList("idcon", filtroContrattiSQL));


            DataTable tempCed = Meta.Conn.RUN_SELECT("payroll", "idcon, idpayroll, fiscalyear, npayroll", orderby, filtroCedolini, null, true);
            tempCed.Columns.Add("flagselezionato");
            foreach (object idCedolino in cedolini) {
                DataRow[] rCedSel = tempCed.Select(QHC.CmpEq("idpayroll", idCedolino));
                rCedSel[0]["flagselezionato"] = "S";
            }
            string errori = "";
            bool occorreAggiornare = false;

            bool scrivisuDB = false;
            bool selezionaContratto = false;
            ArrayList elencoContratti = new ArrayList();

            foreach (object idContratto in contratti) {
                int count = 0;
                string precedenti = null;
                DataRow[] rCed = tempCed.Select(QHC.CmpEq("idcon", idContratto), orderby);
                string filtroCedAnniSucc = QHC.AppAnd(QHC.CmpEq("idcon", idContratto), QHC.CmpEq("fiscalyear", esercizio + 1));
                DataRow[] rCedoliniAnniSucc = dsCedolino.cedolinoannosuccessivo.Select(filtroCedAnniSucc, "fiscalyear desc,npayroll desc");
                ArrayList cedoliniDaTrasferire = new ArrayList(rCedoliniAnniSucc);

                foreach (DataRow rCedol in rCed) {
                    if (rCedol["flagselezionato"] == DBNull.Value) {
                        if (count == 0) {
                            precedenti = rCedol["idpayroll"].ToString();
                        }
                        else {
                            precedenti += ", " + rCedol["idpayroll"];
                        }
                        count++;
                    }
                    else {
                        if (count != 0) {
                            errori += "\nn° " + rCedol["idpayroll"] + "  (prima trasferire ";
                            errori += (count == 1) ? "il cedolino n° " : "i cedolini n° ";
                            errori += precedenti + ")";
                        }
                        else {
                            string filtroCud = QHC.AppAnd(QHC.CmpEq("idcon", rCedol["idcon"]), QHC.CmpEq("fiscalyear", Meta.GetSys("esercizio")) );
                            string filtroPCNE = QHC.AppAnd(
                                QHC.CmpEq("idpayroll", rCedol["idpayroll"]),
                                QHC.CmpEq("!primocedolinononerogato", "S"));
                            DataRow[] rPCNE = dsCedolino.payroll.Select(filtroPCNE);
                            DataRow[] rCudCheAndrebberoCancellati = tCudCheAndrebberoCancellati.Select(filtroCud);
                            if ((rPCNE.Length > 0) && (rCudCheAndrebberoCancellati.Length > 0)) {
                                errori += "\nn° " + rCedol["idpayroll"] + "  (prima cancellare i cud presenti nel contratto)";
                            }
                            else {
                                string cedolino = QHC.CmpEq("idpayroll", rCedol["idpayroll"]);
                                DataRow rCedolino = dsCedolino.payroll.Select(cedolino)[0];
                                cedoliniDaTrasferire.Add(rCedolino);
                            }
                        }
                    }
                }
                if (rCedoliniAnniSucc.Length != cedoliniDaTrasferire.Count) {
                    cedoliniDaTrasferire.Reverse();

                    int meseRif = 1;
                    foreach (DataRow rCedolino in cedoliniDaTrasferire) {
                        if (rCedolino["flagcomputed"].ToString().ToUpper() == "S") {
                            cancellaFigli((int)rCedolino["idpayroll"]);
                            rCedolino["flagcomputed"] = "N";
                            rCedolino["netfee"] = DBNull.Value;
                        }
                        int eserciziosucc = esercizio + 1;
                        if ((int)rCedolino["fiscalyear"] != eserciziosucc) {
                            string related = ottieniIdRelatedCedolino(rCedolino);
                            if (related != null) elencoRelatedCedolini.Add(related);
                            string relatedBudget = ottieniIdRelatedBudgetCedolino(rCedolino);
                            if (relatedBudget != null) elencoRelatedBudgetCedolini.Add(relatedBudget);
                            rCedolino["fiscalyear"] = eserciziosucc;
                        }
                        rCedolino["npayroll"] = meseRif++;

                        scrivisuDB = true;
                        selezionaContratto = true;
                    }
                }
                if ((selezionaContratto) && (!elencoContratti.Contains(idContratto))) {
                    elencoContratti.Add(idContratto);
                }
            }

            if (scrivisuDB) {
                eseguiOperazioniPostTrasferimento(elencoContratti);
                PostData pd = Meta.Get_PostData();
                pd.InitClass(dsCedolino, Meta.Conn);
                if (!pd.DO_POST()) {
                   show("Il cedolino non è stato trasferito - Problemi durante il salvataggio");
                }
                else {
                    eseguiOperazioniPostSalvataggio();
                    occorreAggiornare = true;
                }
            }
            if (errori != "") {
               show(this, "I seguenti cedolini non sono stati trasferiti:\n" + errori);
            }
            if (occorreAggiornare) {
                aggiornaDataGrid();
            }
        }

        private bool VerificaContrattiNonConguagliati()
        {
            bool riepilogoObbligatorio, riepilogoNonAmmesso;
            ValutaContrattiNonConguagliati(out riepilogoObbligatorio, out riepilogoNonAmmesso);
            return riepilogoObbligatorio;
        }

        private void ValutaContrattiNonConguagliati(out bool riepilogoObbligatorio, out bool riepilogoNonAmmesso)
        {
            riepilogoObbligatorio = false;
            riepilogoNonAmmesso = false;

            if (dgCedoliniTrasferibili == null || dgCedoliniTrasferibili.DataSource == null)
                return;

            string dataMember = dgCedoliniTrasferibili.DataMember;
            if (string.IsNullOrEmpty(dataMember))
                return;

            CurrencyManager cm = null;
            try
            {
                if (dgCedoliniTrasferibili.BindingContext != null && dsCedolino != null)
                {
                    cm = dgCedoliniTrasferibili.BindingContext[dsCedolino, dataMember] as CurrencyManager;
                }
            }
            catch
            {
                return;
            }

            if (cm == null)
                return;

            DataView view = cm.List as DataView;
            if (view == null || view.Count == 0)
                return;

            Hashtable selezionatiPerContratto = new Hashtable();
            for (int i = 0; i < view.Count; i++)
            {
                if (!dgCedoliniTrasferibili.IsSelected(i))
                    continue;
                object idContratto = view[i]["idcon"];
                if (idContratto == null || idContratto == DBNull.Value)
                    continue;
                string chiave = idContratto.ToString();
                selezionatiPerContratto[chiave] = Conteggio(selezionatiPerContratto, chiave) + 1;
            }
            if (selezionatiPerContratto.Count == 0)
                return;

            Hashtable contrattiConErogati = new Hashtable();
            foreach (DataRow r in dsCedolino.cedolinoerogato.Rows)
            {
                if (!CedolinoRataDellAnno(r))
                    continue;
                string chiave = r["idcon"].ToString();
                if (selezionatiPerContratto.ContainsKey(chiave))
                    contrattiConErogati[chiave] = true;
            }
            if (contrattiConErogati.Count == 0)
                return;

            Hashtable nonErogatiPerContratto = new Hashtable();
            ContaCedoliniNonErogati(dsCedolino.payroll, contrattiConErogati, nonErogatiPerContratto);
            ContaCedoliniNonErogati(dsCedolino.cedolinonontrasferibile, contrattiConErogati, nonErogatiPerContratto);

            foreach (string chiave in contrattiConErogati.Keys)
            {
                if (Conteggio(selezionatiPerContratto, chiave) >= Conteggio(nonErogatiPerContratto, chiave))
                    riepilogoObbligatorio = true;
                else
                    riepilogoNonAmmesso = true;
            }
        }

        private bool CedolinoRataDellAnno(DataRow r)
        {
            if (r.RowState == DataRowState.Deleted || r.RowState == DataRowState.Detached)
                return false;
            return r["flagbalance"].ToString().ToUpper() == "N"
                && CfgFn.GetNoNullInt32(r["fiscalyear"]) == esercizio;
        }

        private void ContaCedoliniNonErogati(DataTable t, Hashtable contratti, Hashtable conteggi)
        {
            foreach (DataRow r in t.Rows)
            {
                if (!CedolinoRataDellAnno(r))
                    continue;
                if (r["disbursementdate"] != DBNull.Value)
                    continue;
                string chiave = r["idcon"].ToString();
                if (contratti.ContainsKey(chiave))
                    conteggi[chiave] = Conteggio(conteggi, chiave) + 1;
            }
        }

        private static int Conteggio(Hashtable conteggi, string chiave)
        {
            object n = conteggi[chiave];
            return (n == null) ? 0 : (int)n;
        }

        private void GestisciCheckboxRiepilogo()
        {
            bool riepilogoObbligatorio, riepilogoNonAmmesso;
            ValutaContrattiNonConguagliati(out riepilogoObbligatorio, out riepilogoNonAmmesso);

            int stato = riepilogoObbligatorio ? 1 : (riepilogoNonAmmesso ? -1 : 0);
            if (stato == statoCheckboxRiepilogo)
                return;
            statoCheckboxRiepilogo = stato;

            if (riepilogoObbligatorio)
            {
                chkConguaglioRiepilogativo.Checked = true;
                chkConguaglioRiepilogativo.Enabled = false;
            }
            else if (riepilogoNonAmmesso)
            {
                chkConguaglioRiepilogativo.Checked = false;
                chkConguaglioRiepilogativo.Enabled = false;
            }
            else
            {
                chkConguaglioRiepilogativo.Enabled = true;
                chkConguaglioRiepilogativo.Checked = false;
            }
        }

        private void eseguiOperazioniPostTrasferimento(ArrayList elencoContratti) {
            foreach (string idContratto in elencoContratti) {
                rendiCedolinoNonCalcolato(idContratto);
                bool conguaglioDaCancellare = !controllaEsistenzaAltriCedoliniRataNellAnno(idContratto);
                if (conguaglioDaCancellare) {
                    cancellaConguaglio(idContratto);
                }
                else {
                    ricalcolaCampiConguaglio(idContratto);
                }
                cambiaFineCompetenzaDelContratto(idContratto);
            }
        }

        private void eseguiOperazioniPostSalvataggio() {
            rimuoviCedoliniTrasferiti();
            AzzeraCancellaScritture();
            AzzeraCancellaImpegni();
        }

        private void AzzeraCancellaScritture() {
            EP_functions EP = new EP_functions(Meta.Dispatcher);
            if (!EP.attivo) return;

            string filtroCedolini = QHC.AppAnd(QHC.CmpEq("flagcomputed", "N"),
                        QHC.CmpEq("flagbalance", "N"), QHC.CmpEq("fiscalyear", esercizio));
            foreach (DataRow rCedolino in dsCedolino.payroll.Select(filtroCedolini)) {

                string idrelated = EP_functions.GetIdForDocument(rCedolino);
                if (idrelated == "") continue;
                EP.GetEntryForDocument(idrelated);
                if (EP.D.Tables["entry"].Rows.Count == 0) continue;

                if (elencoRelatedCedolini.Contains(idrelated)) {
                    EP.ClearDetails();
                    EP.RemoveEmptyDetails();
                    MetaData MetaEntry = MetaData.GetMetaData(this, "entry");
                    PostData Post = MetaEntry.Get_PostData();

                    Post.InitClass(EP.D, Meta.Conn);
                    if (!Post.DO_POST()) {
                       show(this, "Errore nel salvataggio delle scritture in PD");
                        return;
                    }
                    elencoRelatedCedolini.Remove(idrelated);
                }
            }

            foreach (DataRow rCedolino in dsCedolino.cedolinonontrasferibile.Select(filtroCedolini)) {

                string idrelated = EP_functions.GetIdForDocument(rCedolino);
                if (idrelated == "") continue;

                if (elencoRelatedCedolini.Contains(idrelated)) {
                    EP.GetEntryForDocument(idrelated);
                    EP.ClearDetails();
                    EP.RemoveEmptyDetails();
                    MetaData MetaEntry = MetaData.GetMetaData(this, "entry");
                    PostData Post = MetaEntry.Get_PostData();

                    Post.InitClass(EP.D, Meta.Conn);
                    if (!Post.DO_POST()) {
                       show(this, "Errore nel salvataggio delle scritture in PD");
                        return;
                    }
                    elencoRelatedCedolini.Remove(idrelated);
                }
            }

            if (elencoRelatedCedolini.Count == 0) return;
            string filtroRelated = "";
            foreach (string idRelated in elencoRelatedCedolini) {
                if (filtroRelated != "") {
                    filtroRelated += ",";
                }
                filtroRelated += QHC.quote(idRelated);
            }
            filtroRelated = QHC.FieldInList("idrelated", filtroRelated);
            elencoRelatedCedolini.Clear();

            DataTable Entry = DataAccess.CreateTableByName(Meta.Conn, "entry", "*");
            DataTable EntryDetail = DataAccess.CreateTableByName(Meta.Conn, "entrydetail", "*");

            DataSet dsApp = new DataSet();
            dsApp.Tables.Add(Entry);
            dsApp.Tables.Add(EntryDetail);

            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsApp.Tables["entry"], null, filtroRelated, null, true);

            string filtroEntryDetail = "";
            foreach (DataRow rEntry in dsApp.Tables["entry"].Select()) {
                filtroEntryDetail = QHS.AppOr(filtroEntryDetail,
                    QHS.DoPar(QHS.MCmp(rEntry, "yentry", "nentry")));
            }
            if (filtroEntryDetail != "") {
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsApp.Tables["entrydetail"], null, filtroEntryDetail, null, true);
            }

            foreach (DataRow rEntryDetail in dsApp.Tables["entrydetail"].Select()) {
                rEntryDetail.Delete();
            }

            foreach (DataRow rEntry in dsApp.Tables["entry"].Select()) {
                rEntry.Delete();
            }

            MetaData MetaEntry2 = MetaData.GetMetaData(this, "entry");
            PostData Post2 = MetaEntry2.Get_PostData();

            Post2.InitClass(dsApp, Meta.Conn);
            if (!Post2.DO_POST()) {
               show(this, "Errore nella cancellazione delle scritture in PD");
            }
        }


        private void AzzeraCancellaImpegni() {
          
            

            string filtroCedolini = QHC.AppAnd(QHC.CmpEq("flagcomputed", "N"), QHC.CmpEq("flagbalance", "N"),
                    QHC.CmpEq("fiscalyear", esercizio));
            foreach (DataRow rCedolino in dsCedolino.payroll.Select(filtroCedolini)) {
	            BudgetFunction BF = new BudgetFunction(Meta.Dispatcher);
	            if (!BF.attivo) continue;
                string idrelated = BudgetFunction.GetIdForDocument(rCedolino);
                if (idrelated == "") continue;

                if (elencoRelatedBudgetCedolini.Contains(idrelated)) {
                    BF.GetEpExpForDocument(idrelated);
                    if (BF.D.Tables["epexp"].Rows.Count == 0) {
                        elencoRelatedBudgetCedolini.Remove(idrelated);
                        continue;
                    }
                    BF.ClearDetails();
                    BF.RemoveEmptyDetails();
                    BF.ClearEpExp();
                    MetaData MetaEpExp = MetaData.GetMetaData(this, "epexp");
                    PostData Post = MetaEpExp.Get_PostData();

                    Post.InitClass(BF.D, Meta.Conn);
                    if (!Post.DO_POST()) {
                       show(this, "Errore nel salvataggio degli impegni di budget");
                        return;
                    }
                    elencoRelatedBudgetCedolini.Remove(idrelated);
                }
            }

            foreach (DataRow rCedolino in dsCedolino.cedolinonontrasferibile.Select(filtroCedolini)) {
	            BudgetFunction BF = new BudgetFunction(Meta.Dispatcher);
	            if (!BF.attivo) continue;

                string idrelated = BudgetFunction.GetIdForDocument(rCedolino);
                if (idrelated == "") continue;

                if (elencoRelatedBudgetCedolini.Contains(idrelated)) {
                    BF.GetEpExpForDocument(idrelated);
                    if (BF.D.Tables["epexp"].Rows.Count == 0) {
                        elencoRelatedBudgetCedolini.Remove(idrelated);
                        continue;
                    }

                    BF.ClearDetails();
                    BF.RemoveEmptyDetails();
                    BF.ClearEpExp();
                    MetaData MetaEpExp = MetaData.GetMetaData(this, "epexp");
                    PostData Post = MetaEpExp.Get_PostData();

                    Post.InitClass(BF.D, Meta.Conn);
                    if (!Post.DO_POST()) {
                       show(this, "Errore nel salvataggio degli impegni di budget");
                        return;
                    }
                    elencoRelatedBudgetCedolini.Remove(idrelated);
                }
            }

            if (elencoRelatedBudgetCedolini.Count == 0) return;
            foreach (string idRelated in elencoRelatedBudgetCedolini) {
	            BudgetFunction BF = new BudgetFunction(Meta.Dispatcher);
	            if (!BF.attivo) continue;


                BF.GetEpExpForDocument(idRelated);
                BF.ClearDetails();
                BF.RemoveEmptyDetails();
                BF.ClearEpExp();
                BF.RemoveEmptyEpexp();

                MetaData MetaEpExp2 = MetaData.GetMetaData(this, "epexp");
                PostData Post2 = MetaEpExp2.Get_PostData();

                Post2.InitClass(BF.D, Meta.Conn);
                if (!Post2.DO_POST()) {
                   show(this, "Errore nella cancellazione degli impegni di budget");
                }
            }
            elencoRelatedBudgetCedolini.Clear();
        }

        private bool controllaEsistenzaAltriCedoliniRataNellAnno(object idContratto) {
            string filtro = QHC.AppAnd(QHC.CmpEq("idcon", idContratto), QHC.CmpEq("fiscalyear", esercizio),
                        QHC.CmpEq("flagbalance", "N"));
            DataRow[] rCed = dsCedolino.payroll.Select(filtro);
            DataRow[] rCedNT = dsCedolino.cedolinonontrasferibile.Select(filtro);
            DataRow[] rCedErog = dsCedolino.cedolinoerogato.Select(filtro);
            int numeroCedolini = rCed.Length + rCedNT.Length + rCedErog.Length;
            return (numeroCedolini > 0) ? true : false;
        }

        private void cancellaConguaglio(object idContratto) {
            string filtro = QHC.AppAnd(QHC.CmpEq("idcon", idContratto), QHC.CmpEq("fiscalyear", esercizio),
                        QHC.CmpEq("flagbalance", "S"));
            DataRow[] rCedConguaglio = dsCedolino.cedolinonontrasferibile.Select(filtro);
            if (rCedConguaglio.Length > 0) {
                cancellaFigli(rCedConguaglio[0]["idpayroll"]);
                rCedConguaglio[0].Delete();
            }
            return;
        }

        private void cambiaFineCompetenzaDelContratto(object idContratto) {
            string filtroContratto = QHC.CmpEq("idcon", idContratto);
            DataRow[] imputazioneRow = dsCedolino.parasubcontractyear.Select(filtroContratto);
            if (imputazioneRow.Length == 0) return;

            string filtroCedoliniRata = QHC.AppAnd(filtroContratto, QHC.CmpEq("flagbalance", "N"),
                    QHC.CmpEq("fiscalyear", esercizio));
            string orderby = "fiscalyear desc, npayroll desc";
            DataRow[] cedTrasf = dsCedolino.payroll.Select(filtroCedoliniRata, orderby);
            if (cedTrasf.Length != 0) {
                imputazioneRow[0]["stopcompetency"] = cedTrasf[0]["stop"];
                return;
            }
            DataRow[] cedNoTrasf = dsCedolino.cedolinonontrasferibile.Select(filtroCedoliniRata, orderby);
            if (cedNoTrasf.Length != 0) {
                imputazioneRow[0]["stopcompetency"] = cedNoTrasf[0]["stop"];
                return;
            }
            int nCedoliniAnnoRimasti = Conn.RUN_SELECT_COUNT("payroll",
                QHS.AppAnd(QHS.CmpEq("idcon", idContratto), QHS.CmpEq("flagbalance", "N"),QHS.IsNotNull("disbursementdate"),
                    QHS.CmpEq("fiscalyear", esercizio))
                , false);
            if (nCedoliniAnnoRimasti > 0) return;
            imputazioneRow[0]["startcompetency"] = DBNull.Value;
            imputazioneRow[0]["stopcompetency"] = DBNull.Value;
        }

        void ricalcolaCampiConguaglio(object idContratto) {
            string filtraCedoliniRata = QHC.AppAnd(QHC.CmpEq("idcon", idContratto), QHC.CmpEq("flagbalance", "N"),
                    QHC.CmpEq("fiscalyear", esercizio));
            decimal compensoLordo = 0;
            int giorniLavorati = 0;
            int meseRiferimento = 0;
            DateTime dataFine = new DateTime();
            string orderby = "fiscalyear ASC,npayroll ASC";

            DataRow[] cedErogatoRow = dsCedolino.cedolinoerogato.Select(filtraCedoliniRata,orderby);
            for (int i = 0; i < cedErogatoRow.Length; i++) {
                compensoLordo += CfgFn.GetNoNullDecimal(cedErogatoRow[i]["feegross"]);
                giorniLavorati += CfgFn.GetNoNullInt32(cedErogatoRow[i]["workingdays"]);
                meseRiferimento = (int)cedErogatoRow[i]["npayroll"];
                dataFine = (DateTime)cedErogatoRow[i]["stop"];
            }

            
            bool datiperConguaglioRicavati = false;
            DataRow[] cedTrasferibileRow = dsCedolino.payroll.Select(filtraCedoliniRata, orderby);
            for (int i = 0; i < cedTrasferibileRow.Length; i++) {
                compensoLordo += CfgFn.GetNoNullDecimal(cedTrasferibileRow[i]["feegross"]);
                giorniLavorati += CfgFn.GetNoNullInt32(cedTrasferibileRow[i]["workingdays"]);
                if (i == cedTrasferibileRow.Length - 1) {
                    dataFine = (DateTime)cedTrasferibileRow[i]["stop"];
                    meseRiferimento = (int)cedTrasferibileRow[i]["npayroll"];
                    datiperConguaglioRicavati = true;
                }
            }

            DataRow[] cedNonTrasferibileRow = dsCedolino.cedolinonontrasferibile.Select(filtraCedoliniRata, orderby);
            for (int i = 0; i < cedNonTrasferibileRow.Length; i++) {
                compensoLordo += CfgFn.GetNoNullDecimal(cedNonTrasferibileRow[i]["feegross"]);
                giorniLavorati += CfgFn.GetNoNullInt32(cedNonTrasferibileRow[i]["workingdays"]);
                if ((!datiperConguaglioRicavati) && (i == cedNonTrasferibileRow.Length - 1)) {
                    dataFine = (DateTime)cedNonTrasferibileRow[i]["stop"];
                    meseRiferimento = (int)cedNonTrasferibileRow[i]["npayroll"];
                }
            }

            string filtraConguaglio = QHC.AppAnd(QHC.CmpEq("idcon", idContratto), QHC.CmpEq("flagbalance", "S"),
                    QHC.CmpEq("fiscalyear", esercizio));
            DataRow[] cedConguaglioRow = dsCedolino.cedolinonontrasferibile.Select(filtraConguaglio);
            if (cedConguaglioRow.Length > 0) {
                DataRow rowConguaglio = cedConguaglioRow[0];
                if (rowConguaglio["flagcomputed"].ToString().ToUpper() == "S") {
                    cancellaFigli(CfgFn.GetNoNullInt32(cedConguaglioRow[0]["idpayroll"]));
                    rowConguaglio["flagcomputed"] = "N";
                    rowConguaglio["netfee"] = DBNull.Value;
                }
                rowConguaglio["feegross"] = compensoLordo;
                rowConguaglio["stop"] = dataFine;
                rowConguaglio["npayroll"] = meseRiferimento;
                rowConguaglio["workingdays"] = giorniLavorati;

                DataRow rContratto = rowConguaglio.GetParentRow("parasubcontract_cedolinonontrasferibile");
                DataRow rService = rContratto.GetParentRow("service_parasubcontract");
                object flagNeedBalance = rService["flagneedbalance"];
                if (chkConguaglioRiepilogativo.Checked) {
                    flagNeedBalance = "N";
                }
                string filtraUltimoCedolinoRata = QHC.AppAnd(QHC.CmpEq("idcon", idContratto),
                    QHC.CmpEq("flagbalance", "N"), QHC.CmpEq("fiscalyear", esercizio),
                    QHC.CmpEq("npayroll", rowConguaglio["npayroll"]));

                DataRow[] rUltimoCedolinoRata = dsCedolino.cedolinoerogato.Select(filtraUltimoCedolinoRata);
                if (rUltimoCedolinoRata.Length > 0) {
                    if (flagNeedBalance.ToString().ToUpper() == "S") {
                        DateTime dataNuovoCedolino = ((DateTime)rUltimoCedolinoRata[0]["stop"]).AddDays(1);
                        string fNext = QHC.AppAnd(QHC.CmpEq("idcon", idContratto),
                            QHC.CmpEq("flagbalance", "N"), QHC.CmpEq("fiscalyear", esercizio + 1),
                            QHC.CmpEq("npayroll", rowConguaglio["npayroll"]));

                        DataRow [] CedolinoNext = dsCedolino.cedolinoannosuccessivo.Select(fNext, "npayroll asc");
                        if (CedolinoNext.Length > 0) {
                            DataRow rCedolinoNext = CedolinoNext[0];
                            rCedolinoNext["start"] = dataNuovoCedolino.AddDays(1);
                            rCedolinoNext["workingdays"] = CfgFn.GetNoNullInt32(rCedolinoNext["workingdays"]) > 0
                                ? CfgFn.GetNoNullInt32(rCedolinoNext["workingdays"]) - 1 : 0;
                        }
                        object idResidence = rowConguaglio["idresidence"];
                        DataRow nuovoCedolinoRata = creaUnCedolino(idContratto, meseRiferimento, dataNuovoCedolino, idResidence);
                        nuovoCedolinoRata["idupb"] = rowConguaglio["idupb"];
                        rowConguaglio["npayroll"] = meseRiferimento + 1;

                    }
                    else {
                        rowConguaglio["disbursementdate"] = rUltimoCedolinoRata[0]["disbursementdate"];

                        rowConguaglio["flagcomputed"] = "S";
                        if (chkConguaglioRiepilogativo.Checked) {
                            rowConguaglio["flagsummarybalance"] = "S";
                            }
                        rowConguaglio["feegross"] = dsCedolino.cedolinoerogato.Compute("sum(feegross)",
                            QHC.AppAnd(QHC.CmpEq("flagbalance", "N"), QHC.CmpEq("idcon", idContratto)));

                        string filtroIdPayrollCedoliniRata = QHS.FieldIn("idpayroll", cedErogatoRow);
                        aggiungiRitenuteSulCedolinoDiConguaglio(rowConguaglio, filtroIdPayrollCedoliniRata);

                        rowConguaglio["netfee"] = dsCedolino.cedolinoerogato.Compute("sum(netfee)", filtraCedoliniRata);
                    }
                }
            }
        }

        private DataRow creaUnCedolino(object idContratto, int meseRiferimentoPrec, DateTime data,
            object idResidence) {
            MetaData MetaCedolino = MetaData.GetMetaData(this, "payroll");
            MetaCedolino.SetDefaults(dsCedolino.payroll);
            DataRow rPayroll = Meta.Get_New_Row(null, dsCedolino.payroll);
            rPayroll["idcon"] = idContratto;
            rPayroll["flagcomputed"] = "N";
            rPayroll["flagbalance"] = "N";
            rPayroll["fiscalyear"] = esercizio;
            rPayroll["feegross"] = 0;
            rPayroll["start"] = data;
            rPayroll["stop"] = data;
            rPayroll["workingdays"] = 1;
            rPayroll["npayroll"] = meseRiferimentoPrec + 1;
            rPayroll["enabletaxrelief"] = "S";
            rPayroll["idresidence"] = idResidence;
            return rPayroll;
        }

        void aggiungiRitenuteSulCedolinoDiConguaglio(DataRow cedConguaglioRow, string filtroCedoliniRata) {
            DataTable tPayrollTax = Meta.Conn.RUN_SELECT("payrolltax", null, null,
                filtroCedoliniRata, null, true);
            DataTable tPayrollTaxBracket = Meta.Conn.RUN_SELECT("payrolltaxbracket", null, null,
                filtroCedoliniRata, null, true);

            MetaData metaPayrollTax = MetaData.GetMetaData(this, "payrolltax");

            foreach (DataRow rPayroll in dsCedolino.cedolinoerogato.Select(filtroCedoliniRata)) {
                string fCedolinoRata = QHC.CmpEq("idpayroll", rPayroll["idpayroll"]);

                foreach (DataRow rPayrollTaxRata in tPayrollTax.Select(fCedolinoRata)) {
                    string fTaxCode = QHC.AppAnd(QHC.CmpEq("taxcode", rPayrollTaxRata["taxcode"]),
                        QHC.CmpEq("idpayroll", cedConguaglioRow["idpayroll"]));

                    DataRow[] PayrollTaxConguaglio = dsCedolino.payrolltax.Select(fTaxCode);

                    DataRow rPayrollTaxConguaglio;
                    if (PayrollTaxConguaglio.Length > 0) {
                        rPayrollTaxConguaglio = PayrollTaxConguaglio[0];
                        foreach (string col in new string[] {"admintax", "employtax",
																"employtaxgross", "deduction",
																"abatements", "taxablegross",
																"taxablenet", "annualtaxabletotal"}) {
                            rPayrollTaxConguaglio[col] = CfgFn.GetNoNullDecimal(rPayrollTaxConguaglio[col]) +
                                CfgFn.GetNoNullDecimal(rPayrollTaxRata[col]);
                        }
                        rPayrollTaxConguaglio["annualpayedemploytax"] =
                            CfgFn.GetNoNullDecimal(rPayrollTaxConguaglio["annualpayedemploytax"])
                            + CfgFn.GetNoNullDecimal(rPayrollTaxRata["employtax"]);
                    }
                    else {
                        metaPayrollTax.SetDefaults(dsCedolino.payrolltax);
                        rPayrollTaxConguaglio = metaPayrollTax.Get_New_Row(cedConguaglioRow, dsCedolino.payrolltax);

                        foreach (string c in new string[] { "admindenominator", "adminnumerator", "adminrate", 
                        "employdenominator", "employnumerator", "employrate", "taxabledenominator", 
                        "taxablenumerator", "taxcode", "admintax", "employtax", "employtaxgross", "deduction",
                        "abatements", "taxablegross", "taxablenet", "annualtaxabletotal", "idcity", "idfiscaltaxregion"}) {
                            rPayrollTaxConguaglio[c] = rPayrollTaxRata[c];
                        }
                    }
                    aggiungiScaglioniCedolinoConguaglio(tPayrollTaxBracket, rPayrollTaxRata, rPayrollTaxConguaglio);
                }
                aggiungiDeduzioniAlCedolinoDiConguaglio(cedConguaglioRow, fCedolinoRata);
                aggiungiDetrazioniAlCedolinoDiConguaglio(cedConguaglioRow, fCedolinoRata);
                aggiungiStorniAlCedolinoDiConguaglio(cedConguaglioRow, fCedolinoRata);
            }

        }

        private void aggiungiScaglioniCedolinoConguaglio(DataTable tPayrollTaxBracket, DataRow cedolinoRitenutaRata,
            DataRow parentConguaglio) {
            MetaData metaPayrollTaxBracket = MetaData.GetMetaData(this, "payrolltaxbracket");
            string filtroCedolinoRata = QHC.CmpEq("idpayroll", cedolinoRitenutaRata["idpayroll"]);
            string filtroCedolinoCong = QHC.CmpEq("idpayroll", parentConguaglio["idpayroll"]);
            string filtroScagl = QHC.AppAnd(filtroCedolinoRata, QHC.CmpEq("idpayrolltax", cedolinoRitenutaRata["idpayrolltax"]));
            DataRow[] rPayRollTaxBracket = tPayrollTaxBracket.Select(filtroScagl);
            foreach (DataRow rScagl in rPayRollTaxBracket) {
                string filtroCedRitScagl = QHC.AppAnd(filtroCedolinoCong, QHC.CmpEq("idpayrolltax", parentConguaglio["idpayrolltax"]));
                DataRow[] rBracket = dsCedolino.payrolltaxbracket.Select(filtroCedRitScagl);
                if (rBracket.Length > 0) {
                    foreach (string col in new string[] { "taxable", "employtax", "admintax" })
                        rBracket[0][col] = CfgFn.GetNoNullDecimal(rBracket[0][col]) +
                            CfgFn.GetNoNullDecimal(rScagl[col]);
                }
                else {
                    DataRow newCedConguaglioRitScagl = metaPayrollTaxBracket.Get_New_Row(parentConguaglio,
                        dsCedolino.payrolltaxbracket);
                    foreach (DataColumn C in dsCedolino.payrolltaxbracket.Columns) {
                        if ((C.ColumnName == "idpayroll") || (C.ColumnName == "idpayrolltax")
                            || (C.ColumnName == "nbracket")) continue;
                        newCedConguaglioRitScagl[C.ColumnName] = rScagl[C.ColumnName];
                    }
                }
            }
        }

        void aggiungiDeduzioniAlCedolinoDiConguaglio(DataRow cedConguaglioRow, string filtroCedoliniRata) {
            DataTable tPayrollDeduction = Meta.Conn.RUN_SELECT("payrolldeduction", null, null, 
                filtroCedoliniRata, null, true);
            MetaData metaPayrollDeduction = MetaData.GetMetaData(this, "payrolldeduction");
            foreach (DataRow rPD in tPayrollDeduction.Rows) {
                DataRow[] rDedCong = dsCedolino.payrolldeduction.Select(QHC.AppAnd(
                    QHC.CmpEq("idpayroll", cedConguaglioRow["idpayroll"]),
                    QHC.CmpEq("iddeduction", rPD["iddeduction"])));
                if (rDedCong.Length == 0) {
                    DataRow rpd = metaPayrollDeduction.Get_New_Row(cedConguaglioRow, dsCedolino.payrolldeduction);
                    rpd["idpayroll"] = cedConguaglioRow["idpayroll"];
                    foreach (DataColumn c in dsCedolino.payrolldeduction.Columns) {
                        if (c.ColumnName != "idpayroll") {
                            rpd[c] = rPD[c.ColumnName];
                        }
                    }
                }
                else {
                    rDedCong[0]["annualamount"] = CfgFn.GetNoNullDecimal(rDedCong[0]["annualamount"]) 
                        + CfgFn.GetNoNullDecimal(rPD["annualamount"]);
                    rDedCong[0]["curramount"] = CfgFn.GetNoNullDecimal(rDedCong[0]["curramount"]) 
                        + CfgFn.GetNoNullDecimal(rPD["curramount"]);
                }
            }
        }

        void aggiungiDetrazioniAlCedolinoDiConguaglio(DataRow cedConguaglioRow, string filtroCedoliniRata) {
            DataTable tPayrollAbatement = Meta.Conn.RUN_SELECT("payrollabatement", null, null, 
                filtroCedoliniRata, null, true);
            MetaData metaPayrollAbatement = MetaData.GetMetaData(this, "payrollabatement");
            foreach (DataRow rPA in tPayrollAbatement.Rows) {
                DataRow[] rDetrCong = dsCedolino.payrollabatement.Select(QHC.AppAnd(
                    QHC.CmpEq("idpayroll", cedConguaglioRow["idpayroll"]),
                    QHC.CmpEq("idabatement", rPA["idabatement"])));
                if (rDetrCong.Length == 0) {
                    DataRow rpa = metaPayrollAbatement.Get_New_Row(cedConguaglioRow, dsCedolino.payrollabatement);
                    rpa["idpayroll"] = cedConguaglioRow["idpayroll"];
                    foreach (DataColumn c in dsCedolino.payrollabatement.Columns) {
                        if (c.ColumnName != "idpayroll") {
                            rpa[c] = rPA[c.ColumnName];
                        }
                    }
                }
                else {
                    rDetrCong[0]["annualamount"] = CfgFn.GetNoNullDecimal(rDetrCong[0]["annualamount"]) 
                        + CfgFn.GetNoNullDecimal(rPA["annualamount"]);
                    rDetrCong[0]["curramount"] = CfgFn.GetNoNullDecimal(rDetrCong[0]["curramount"]) 
                        + CfgFn.GetNoNullDecimal(rPA["curramount"]);
                }
            }
        }

        void aggiungiStorniAlCedolinoDiConguaglio(DataRow cedConguaglioRow, string filtroCedoliniRata) {
            DataTable tPayrollTaxCorrige = Meta.Conn.RUN_SELECT("payrolltaxcorrige", null, null, filtroCedoliniRata, null, true);

            MetaData metaPayrollTaxCorrige = MetaData.GetMetaData(this, "payrolltaxcorrige");
            metaPayrollTaxCorrige.SetDefaults(dsCedolino.payrolltaxcorrige);
            foreach (DataRow rPTC in tPayrollTaxCorrige.Rows) {
                DataRow[] rStornoCong = dsCedolino.payrolltaxcorrige.Select(QHC.AppAnd(
                    QHC.CmpEq("idpayroll", cedConguaglioRow["idpayroll"]),
                    QHC.CmpEq("taxcode", rPTC["taxcode"]), QHC.CmpEq("idcity", rPTC["idcity"])));
                if (rStornoCong.Length == 0) {
                    MetaData.SetDefault(dsCedolino.payrolltaxcorrige, "idpayroll", cedConguaglioRow["idpayroll"]);
                    DataRow rptcCon = metaPayrollTaxCorrige.Get_New_Row(cedConguaglioRow, dsCedolino.payrolltaxcorrige);
                    foreach (DataColumn c in dsCedolino.payrolltaxcorrige.Columns) {

                        if ((c.ColumnName != "idpayroll") && (c.ColumnName != "idpayrolltaxcorrige")){
                            rptcCon[c] = rPTC[c.ColumnName];
                        }
                    }
                }
                else {
                    rStornoCong[0]["employamount"] = CfgFn.GetNoNullDecimal(rStornoCong[0]["employamount"])
                        + CfgFn.GetNoNullDecimal(rPTC["employamount"]);
                    rStornoCong[0]["adminamount"] = CfgFn.GetNoNullDecimal(rStornoCong[0]["adminamount"])
                        + CfgFn.GetNoNullDecimal(rPTC["adminamount"]);
                }
            }
        }

        void rimuoviCedoliniTrasferiti() {
            string filtraCedoliniTrasferiti = QHC.CmpGt("fiscalyear", esercizio);
            DataRow[] cedTrasferitiRow = dsCedolino.payroll.Select(filtraCedoliniTrasferiti);
            for (int i = 0; i < cedTrasferitiRow.Length; i++) {
                aggiungiCedolinoInTabellaCedolinoAnniSuccessivi(cedTrasferitiRow[i]);
                cedTrasferitiRow[i].Delete();
            } 
            string filtraCedoliniRataZero = QHC.AppAnd(QHC.CmpEq("feegross", 0),QHC.CmpEq("fiscalyear", esercizio), 
                   QHC.CmpEq("flagbalance", "N"), QHC.CmpEq("flagcomputed", "N"));
            DataRow[] cedNuoviCedoliniRata = dsCedolino.payroll.Select(filtraCedoliniRataZero);
            for (int i = 0; i < cedNuoviCedoliniRata.Length; i++) {
                cedNuoviCedoliniRata[i].Delete();
            }
            dsCedolino.payroll.AcceptChanges();
        }

        private void aggiungiCedolinoInTabellaCedolinoAnniSuccessivi(DataRow rCedolino) {
            DataRow rCedolinoAnnoSucc = dsCedolino.cedolinoannosuccessivo.NewRow();
            foreach (DataColumn C in rCedolino.Table.Columns) {
                if (rCedolinoAnnoSucc.Table.Columns.Contains(C.ColumnName)) {
                    rCedolinoAnnoSucc[C.ColumnName] = rCedolino[C];
                }
            }
            dsCedolino.cedolinoannosuccessivo.Rows.Add(rCedolinoAnnoSucc);
            dsCedolino.cedolinoannosuccessivo.AcceptChanges();
        }

        ArrayList elencoRelatedCedolini = new ArrayList();
        ArrayList elencoRelatedBudgetCedolini = new ArrayList();
        void rendiCedolinoNonCalcolato(string idContratto) {
            string filtroContratto = QHC.AppAnd(QHC.CmpEq("idcon", idContratto), QHC.CmpEq("flagbalance", "N"),
                        QHC.CmpEq("fiscalyear", esercizio));
            string orderby = "fiscalyear DESC,npayroll DESC";
            DataRow[] cedTrasf = dsCedolino.payroll.Select(filtroContratto, orderby);
            DataRow[] cedNoTrasf = dsCedolino.cedolinonontrasferibile.Select(filtroContratto, orderby);
            if ((cedTrasf.Length == 0) && (cedNoTrasf.Length == 0)) return;
            string related = null;
            string relatedBudget = null;
            if (cedTrasf.Length != 0) {
                string cedNonCalc = QHC.AppAnd(filtroContratto, QHC.CmpEq("flagcomputed", "N"));
                if (dsCedolino.payroll.Select(cedNonCalc).Length != 0) return;
                cancellaFigli(cedTrasf[0]["idpayroll"]);
                cedTrasf[0]["flagcomputed"] = "N";
                cedTrasf[0]["netfee"] = DBNull.Value;
                related = ottieniIdRelatedCedolino(cedTrasf[0]);
                if (related != null) elencoRelatedCedolini.Add(related);
                relatedBudget = ottieniIdRelatedBudgetCedolino(cedTrasf[0]);
                if (relatedBudget != null) elencoRelatedBudgetCedolini.Add(relatedBudget);
            }
            else {
                if (cedNoTrasf.Length != 0) {
                    cancellaFigli(cedNoTrasf[0]["idpayroll"]);
                    cedNoTrasf[0]["flagcomputed"] = "N";
                    cedNoTrasf[0]["netfee"] = DBNull.Value;
                    related = ottieniIdRelatedCedolino(cedNoTrasf[0]);
                    if (related != null) elencoRelatedCedolini.Add(related);
                    relatedBudget = ottieniIdRelatedBudgetCedolino(cedNoTrasf[0]);
                    if (relatedBudget != null) elencoRelatedBudgetCedolini.Add(relatedBudget);
                }
            }
        }

        void cancellaFigli(object idpayroll) {
            string filter = QHC.CmpEq("idpayroll", idpayroll);

            DataRow[] R1 = dsCedolino.payrolltax.Select(filter);
            for (int i = 0; i < R1.Length; i++) {
                R1[i].Delete();
            }

            DataRow[] R2 = dsCedolino.payrolltaxbracket.Select(filter);
            for (int i = 0; i < R2.Length; i++) {
                R2[i].Delete();
            }

            DataRow[] R3 = dsCedolino.payrolldeduction.Select(filter);
            for (int i = 0; i < R3.Length; i++) {
                R3[i].Delete();
            }

            DataRow[] R4 = dsCedolino.payrollabatement.Select(filter);
            for (int i = 0; i < R4.Length; i++) {
                R4[i].Delete();
            }

            DataRow[] R5 = dsCedolino.payrolltaxcorrige.Select(filter);
            for (int i = 0; i < R5.Length; i++) {
                R5[i].Delete();
            }
        }

        private string ottieniIdRelatedCedolino(DataRow rCedolino) {
            EP_functions EP = new EP_functions(Meta.Dispatcher);
            if (!EP.attivo) return null;
            return EP_functions.GetIdForDocument(rCedolino);
        }

        private string ottieniIdRelatedBudgetCedolino(DataRow rCedolino) {
            BudgetFunction BF = new BudgetFunction(Meta.Dispatcher);
            if (!BF.attivo) return null;
            return BudgetFunction.GetIdForDocument(rCedolino);
        }

        private void btnSelezionaCedolini_Click(object sender, System.EventArgs e) {
            string dataMember = dgCedoliniTrasferibili.DataMember;
            CurrencyManager cm = (CurrencyManager)dgCedoliniTrasferibili.BindingContext[dsCedolino, dataMember];
            DataView view = (DataView)cm.List;
            if (txtSelezionaCedolini.Text == "") {
                txtCedoliniSelezionati.Text = null;
                for (int i = 0; i < cm.Count; i++) {
                    dgCedoliniTrasferibili.UnSelect(i);
                }
                return;
            }
            int max = int.MinValue;
            int min = int.MaxValue;
            foreach (DataRowView r in view) {
                int numDoc = Convert.ToInt32(r["idpayroll"]);
                if (numDoc < min) {
                    min = numDoc;
                }
                if (numDoc > max) {
                    max = numDoc;
                }
            }

            ArrayList al = new ArrayList();
            string[] valori = txtSelezionaCedolini.Text.Split(new char[] { ',' });
            foreach (string valore in valori) {
                int pos = valore.IndexOf('-');
                try {
                    if (pos == -1) {
                        int numDoc = Convert.ToInt32(valore);
                        al.Add(numDoc);
                    }
                    else {
                        string valore1 = valore.Substring(0, pos);
                        string valore2 = valore.Substring(pos + 1);
                        int doc1 = (valore1 == "") ? min : Convert.ToInt32(valore1);
                        int doc2 = (valore2 == "") ? max : Convert.ToInt32(valore2);
                        if (doc1 > doc2) {
                            int h = doc1;
                            doc1 = doc2;
                            doc2 = h;
                        }
                        for (int i = doc1; i <= doc2; i++) {
                            al.Add(i);
                        }
                    }
                }
                catch (FormatException) {
                   show(this, "Errore nella selezione desiderata: " + valore + "\nImmettere i numeri di cedolino e/o gli intervalli di cedolino separati da virgole.");
                    return;
                }
            }
            for (int i = 0; i < cm.Count; i++) {
                int numDoc = Convert.ToInt32(view[i]["idpayroll"]);
                int pos = al.IndexOf(numDoc);
                if (pos != -1) {
                    dgCedoliniTrasferibili.Select(i);
                }
                else {
                    dgCedoliniTrasferibili.UnSelect(i);
                }
            }
            selezioneRigheCambiata();
        }

        private void dgCedoliniTrasferibili_Paint(object sender, System.Windows.Forms.PaintEventArgs e) {
            selezioneRigheCambiata();
			MetaFactory.factory.getSingleton<IFormCreationListener>().refresh();
        }

        private void selezioneRigheCambiata() {
            string dataMember = dgCedoliniTrasferibili.DataMember;
            CurrencyManager cm = dgCedoliniTrasferibili.BindingContext[dsCedolino, dataMember] as CurrencyManager;
            if (cm == null) return;
            DataView view = cm.List as DataView;
            if (view != null) {
                int primaRigaSelezionata = getPrimaRigaSelezionataCedolini(view);
                if (primaRigaSelezionata == -1) {
                    txtCedoliniSelezionati.Text = null;
                }
                else {
                    txtCedoliniSelezionati.Text = view[primaRigaSelezionata]["idpayroll"].ToString();

                    for (int i = primaRigaSelezionata + 1; i < view.Count; i++) {
                        if (dgCedoliniTrasferibili.IsSelected(i)) {
                            txtCedoliniSelezionati.Text += "," + view[i]["idpayroll"];
                        }
                    }
                }
            }

            GestisciCheckboxRiepilogo();
        }

        private int getPrimaRigaSelezionataCedolini(DataView view) {
            for (int i = 0; i < view.Count; i++) {
                if (dgCedoliniTrasferibili.IsSelected(i)) {
                    return i;
                }
            }
            return -1;
        }
		#endregion Gestione selezione CEDOLINI DA TRASFERIRE

		private void dgCedoliniTrasferibili_CurrentCellChanged(object sender, EventArgs e)
		{
            dgCedoliniTrasferibili.Select(dgCedoliniTrasferibili.CurrentCell.RowNumber);
		}
	}
}