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
using funzioni_configurazione;//funzioni_configurazione

namespace parasubcontract_trasf_contratto//contratto_trasferimento//
{
	/// <summary>
	/// Summary description for frmcontratto_trasferimento.
	/// </summary>
	public class Frm_parasubcontract_trasf_contratto : System.Windows.Forms.Form
	{
		MetaData Meta;
		int esercizio;
		int eserciziosucc;
		string CustomTitle;
		private ArrayList pagine;
		private int selectedIndex;
		public vistaForm DS;
		public dsContratto dsContratto;
		private System.Windows.Forms.TabControl tabController;
		private System.Windows.Forms.TabPage tabIntro;
		private System.Windows.Forms.TabPage tabContrattiNonTrasferibili;
		private System.Windows.Forms.TabPage tabContrattiTrasferibili;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Button btnIndietro;
		private System.Windows.Forms.Button btnAvanti;
		private System.Windows.Forms.Label lblErrore;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGrid dgContrattiNonTrasferibili;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Button btnTrasferisciContratti;
		private System.Windows.Forms.TextBox txtContrattiSelezionati;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox chkFamiliari;
		private System.Windows.Forms.CheckBox chkAltreForme;
		private System.Windows.Forms.CheckBox chkINPS;
		private System.Windows.Forms.CheckBox chkTipoRapporto;
		private System.Windows.Forms.DataGrid dgContrattiTrasferibili;
		private System.Windows.Forms.Label label8;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        CQueryHelper QHC;
        private Label label3;
        QueryHelper QHS;

		public Frm_parasubcontract_trasf_contratto()
		{
			InitializeComponent();
			CustomTitle = "Wizard Trasferimento dei Contratti";
			pagine = new ArrayList();
			// Inserisco manualmente i TAB in quanto nonostante la corretta numerazione vengono visti in ordine differente
			pagine.Add(tabIntro);
			pagine.Add(tabContrattiNonTrasferibili);
			pagine.Add(tabContrattiTrasferibili);
			tabController.TabPages.Clear();
			tabController.TabPages.Add((TabPage)pagine[0]);
			DataAccess.SetTableForReading(dsContratto.contrattonontrasferibile,"parasubcontract");
            ContextMenu ExcelMenu;
            ExcelMenu = new ContextMenu();
            ExcelMenu.MenuItems.Add("Excel", new EventHandler(Excel_Click));
            dgContrattiNonTrasferibili.ContextMenu = ExcelMenu;
            dgContrattiTrasferibili.ContextMenu = ExcelMenu;
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
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
			esercizio = (int)Meta.GetSys("esercizio");
			eserciziosucc = esercizio + 1;
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
			HelpForm.SetAllowMultiSelection(dsContratto.parasubcontract, true);
			ClearDataSet.RemoveConstraints(dsContratto);
			riempiTabContratti();
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
			string filtro = QHS.CmpEq("ayear",eserciziosucc);
			object esisteNextYear = Meta.Conn.DO_READ_VALUE("accountingyear", filtro, "COUNT(*)");
			if ((esisteNextYear == null) || (esisteNextYear == DBNull.Value) || ((int)esisteNextYear == 0)) {
				lblErrore.Visible = true;
				string messaggio = "Attenzione! Il trasferimento dei contratti non può essere utilizzato in quanto non esiste l'esercizio " + eserciziosucc + "!"
					+ "\nPer creare l'esercizio " + eserciziosucc + " andare dal menu Configurazione - Chiusura - Fase Corrente e procedere"
					+ " all'apertura dell'esercizio.";
				lblErrore.Text = messaggio;
				AbilitaDisabilita(false);
			}
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_parasubcontract_trasf_contratto));
            this.dsContratto = new parasubcontract_trasf_contratto.dsContratto();
            this.DS = new parasubcontract_trasf_contratto.vistaForm();
            this.tabController = new System.Windows.Forms.TabControl();
            this.tabIntro = new System.Windows.Forms.TabPage();
            this.lblErrore = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabContrattiNonTrasferibili = new System.Windows.Forms.TabPage();
            this.dgContrattiNonTrasferibili = new System.Windows.Forms.DataGrid();
            this.label2 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.tabContrattiTrasferibili = new System.Windows.Forms.TabPage();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.btnTrasferisciContratti = new System.Windows.Forms.Button();
            this.txtContrattiSelezionati = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkFamiliari = new System.Windows.Forms.CheckBox();
            this.chkAltreForme = new System.Windows.Forms.CheckBox();
            this.chkINPS = new System.Windows.Forms.CheckBox();
            this.chkTipoRapporto = new System.Windows.Forms.CheckBox();
            this.dgContrattiTrasferibili = new System.Windows.Forms.DataGrid();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnIndietro = new System.Windows.Forms.Button();
            this.btnAvanti = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dsContratto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.tabController.SuspendLayout();
            this.tabIntro.SuspendLayout();
            this.tabContrattiNonTrasferibili.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgContrattiNonTrasferibili)).BeginInit();
            this.tabContrattiTrasferibili.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgContrattiTrasferibili)).BeginInit();
            this.SuspendLayout();
            // 
            // dsContratto
            // 
            this.dsContratto.DataSetName = "dsContratto";
            this.dsContratto.EnforceConstraints = false;
            this.dsContratto.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // tabController
            // 
            this.tabController.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabController.Controls.Add(this.tabIntro);
            this.tabController.Controls.Add(this.tabContrattiNonTrasferibili);
            this.tabController.Controls.Add(this.tabContrattiTrasferibili);
            this.tabController.Location = new System.Drawing.Point(8, 8);
            this.tabController.Name = "tabController";
            this.tabController.SelectedIndex = 0;
            this.tabController.Size = new System.Drawing.Size(768, 424);
            this.tabController.TabIndex = 0;
            // 
            // tabIntro
            // 
            this.tabIntro.Controls.Add(this.label3);
            this.tabIntro.Controls.Add(this.lblErrore);
            this.tabIntro.Controls.Add(this.label16);
            this.tabIntro.Controls.Add(this.label6);
            this.tabIntro.Controls.Add(this.label5);
            this.tabIntro.Controls.Add(this.label4);
            this.tabIntro.Controls.Add(this.label1);
            this.tabIntro.Location = new System.Drawing.Point(4, 22);
            this.tabIntro.Name = "tabIntro";
            this.tabIntro.Size = new System.Drawing.Size(760, 398);
            this.tabIntro.TabIndex = 0;
            this.tabIntro.Text = "Pagina 1 di 3";
            // 
            // lblErrore
            // 
            this.lblErrore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblErrore.Location = new System.Drawing.Point(16, 224);
            this.lblErrore.Name = "lblErrore";
            this.lblErrore.Size = new System.Drawing.Size(712, 88);
            this.lblErrore.TabIndex = 26;
            this.lblErrore.Text = "Visualizza Errore";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.Location = new System.Drawing.Point(24, 80);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(704, 23);
            this.label16.TabIndex = 25;
            this.label16.Text = "Vengono mostrati tutti i contratti non trasferibili con la causa della sua non tr" +
                "asferibilità";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Location = new System.Drawing.Point(24, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(704, 24);
            this.label6.TabIndex = 24;
            this.label6.Text = "Vengono mostrati tutti i contratti trasferibili. L\'utente sceglierà quali trasfer" +
                "ire nell\'esercizio successivo";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(264, 16);
            this.label5.TabIndex = 23;
            this.label5.Text = "FASE 1: Griglia dei Contratti Non Trasferibili";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(264, 16);
            this.label4.TabIndex = 22;
            this.label4.Text = "FASE 2: Griglia dei contratti Trasferibili";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(745, 24);
            this.label1.TabIndex = 21;
            this.label1.Text = "La procedura di trasferimento dei contratti consente di trasferire i contratti da" +
                "ll\'anno fiscale corrente all\'anno fiscale successivo.";
            // 
            // tabContrattiNonTrasferibili
            // 
            this.tabContrattiNonTrasferibili.Controls.Add(this.dgContrattiNonTrasferibili);
            this.tabContrattiNonTrasferibili.Controls.Add(this.label2);
            this.tabContrattiNonTrasferibili.Controls.Add(this.label25);
            this.tabContrattiNonTrasferibili.Location = new System.Drawing.Point(4, 22);
            this.tabContrattiNonTrasferibili.Name = "tabContrattiNonTrasferibili";
            this.tabContrattiNonTrasferibili.Size = new System.Drawing.Size(760, 398);
            this.tabContrattiNonTrasferibili.TabIndex = 1;
            this.tabContrattiNonTrasferibili.Text = "Pagina 2 di 3";
            // 
            // dgContrattiNonTrasferibili
            // 
            this.dgContrattiNonTrasferibili.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgContrattiNonTrasferibili.CaptionVisible = false;
            this.dgContrattiNonTrasferibili.DataMember = "";
            this.dgContrattiNonTrasferibili.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgContrattiNonTrasferibili.Location = new System.Drawing.Point(7, 48);
            this.dgContrattiNonTrasferibili.Name = "dgContrattiNonTrasferibili";
            this.dgContrattiNonTrasferibili.Size = new System.Drawing.Size(744, 320);
            this.dgContrattiNonTrasferibili.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(7, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(744, 23);
            this.label2.TabIndex = 11;
            this.label2.Text = "PER TRASFERIRE UNO DI QUESTI CONTRATTI OCCORRE PRIMA EROGARE IL CEDOLINO DI CONGU" +
                "AGLIO PER QUEST\'ANNO";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label25.Location = new System.Drawing.Point(7, 8);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(747, 24);
            this.label25.TabIndex = 10;
            this.label25.Text = "FASE 1: Viene mostrato l\'elenco dei contratti non trasferibili";
            this.label25.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tabContrattiTrasferibili
            // 
            this.tabContrattiTrasferibili.Controls.Add(this.label27);
            this.tabContrattiTrasferibili.Controls.Add(this.label26);
            this.tabContrattiTrasferibili.Controls.Add(this.btnTrasferisciContratti);
            this.tabContrattiTrasferibili.Controls.Add(this.txtContrattiSelezionati);
            this.tabContrattiTrasferibili.Controls.Add(this.groupBox1);
            this.tabContrattiTrasferibili.Controls.Add(this.dgContrattiTrasferibili);
            this.tabContrattiTrasferibili.Controls.Add(this.label8);
            this.tabContrattiTrasferibili.Location = new System.Drawing.Point(4, 22);
            this.tabContrattiTrasferibili.Name = "tabContrattiTrasferibili";
            this.tabContrattiTrasferibili.Size = new System.Drawing.Size(760, 398);
            this.tabContrattiTrasferibili.TabIndex = 2;
            this.tabContrattiTrasferibili.Text = "Pagina 3 di 3";
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(5, 32);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(752, 16);
            this.label27.TabIndex = 17;
            this.label27.Text = "Tenere premuto il tasto CTRL o MAIUSC e contemporaneamente cliccare con il mouse " +
                "per selezionare più contratti";
            // 
            // label26
            // 
            this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label26.Location = new System.Drawing.Point(9, 8);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(744, 16);
            this.label26.TabIndex = 16;
            this.label26.Text = "FASE 2: Scelta dei contratti da trasferire nell\'esercizio successivo";
            this.label26.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnTrasferisciContratti
            // 
            this.btnTrasferisciContratti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTrasferisciContratti.Location = new System.Drawing.Point(673, 328);
            this.btnTrasferisciContratti.Name = "btnTrasferisciContratti";
            this.btnTrasferisciContratti.Size = new System.Drawing.Size(80, 23);
            this.btnTrasferisciContratti.TabIndex = 15;
            this.btnTrasferisciContratti.Text = "Trasferisci";
            this.btnTrasferisciContratti.Click += new System.EventHandler(this.btnTrasferisciContratti_Click);
            // 
            // txtContrattiSelezionati
            // 
            this.txtContrattiSelezionati.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContrattiSelezionati.Location = new System.Drawing.Point(113, 368);
            this.txtContrattiSelezionati.Name = "txtContrattiSelezionati";
            this.txtContrattiSelezionati.ReadOnly = true;
            this.txtContrattiSelezionati.Size = new System.Drawing.Size(640, 20);
            this.txtContrattiSelezionati.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkFamiliari);
            this.groupBox1.Controls.Add(this.chkAltreForme);
            this.groupBox1.Controls.Add(this.chkINPS);
            this.groupBox1.Controls.Add(this.chkTipoRapporto);
            this.groupBox1.Location = new System.Drawing.Point(9, 320);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(656, 40);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dati da Trasferire";
            // 
            // chkFamiliari
            // 
            this.chkFamiliari.Location = new System.Drawing.Point(536, 16);
            this.chkFamiliari.Name = "chkFamiliari";
            this.chkFamiliari.Size = new System.Drawing.Size(112, 16);
            this.chkFamiliari.TabIndex = 3;
            this.chkFamiliari.Text = "Familiari a carico";
            // 
            // chkAltreForme
            // 
            this.chkAltreForme.Location = new System.Drawing.Point(352, 16);
            this.chkAltreForme.Name = "chkAltreForme";
            this.chkAltreForme.Size = new System.Drawing.Size(168, 16);
            this.chkAltreForme.TabIndex = 2;
            this.chkAltreForme.Text = "Altre Forme Assicurative";
            // 
            // chkINPS
            // 
            this.chkINPS.Location = new System.Drawing.Point(168, 16);
            this.chkINPS.Name = "chkINPS";
            this.chkINPS.Size = new System.Drawing.Size(160, 16);
            this.chkINPS.TabIndex = 1;
            this.chkINPS.Text = "Attività Previdenziali INPS";
            // 
            // chkTipoRapporto
            // 
            this.chkTipoRapporto.Location = new System.Drawing.Point(8, 16);
            this.chkTipoRapporto.Name = "chkTipoRapporto";
            this.chkTipoRapporto.Size = new System.Drawing.Size(144, 16);
            this.chkTipoRapporto.TabIndex = 4;
            this.chkTipoRapporto.Text = "Tipo Rapporto E-Mens";
            // 
            // dgContrattiTrasferibili
            // 
            this.dgContrattiTrasferibili.AllowNavigation = false;
            this.dgContrattiTrasferibili.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgContrattiTrasferibili.CaptionVisible = false;
            this.dgContrattiTrasferibili.DataMember = "";
            this.dgContrattiTrasferibili.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgContrattiTrasferibili.Location = new System.Drawing.Point(9, 48);
            this.dgContrattiTrasferibili.Name = "dgContrattiTrasferibili";
            this.dgContrattiTrasferibili.Size = new System.Drawing.Size(744, 264);
            this.dgContrattiTrasferibili.TabIndex = 11;
            this.dgContrattiTrasferibili.Tag = "";
            this.dgContrattiTrasferibili.Paint += new System.Windows.Forms.PaintEventHandler(this.dgContrattiTrasferibili_Paint);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.Location = new System.Drawing.Point(3, 368);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 23);
            this.label8.TabIndex = 13;
            this.label8.Text = "Contratti Selezionati";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(696, 440);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 10;
            this.btnAnnulla.Text = "Annulla";
            // 
            // btnIndietro
            // 
            this.btnIndietro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnIndietro.Location = new System.Drawing.Point(496, 440);
            this.btnIndietro.Name = "btnIndietro";
            this.btnIndietro.Size = new System.Drawing.Size(75, 23);
            this.btnIndietro.TabIndex = 8;
            this.btnIndietro.Text = "< Indietro";
            this.btnIndietro.Click += new System.EventHandler(this.btnIndietro_Click);
            // 
            // btnAvanti
            // 
            this.btnAvanti.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAvanti.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAvanti.Location = new System.Drawing.Point(584, 440);
            this.btnAvanti.Name = "btnAvanti";
            this.btnAvanti.Size = new System.Drawing.Size(75, 23);
            this.btnAvanti.TabIndex = 9;
            this.btnAvanti.Text = "Avanti >";
            this.btnAvanti.Click += new System.EventHandler(this.btnAvanti_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(716, 30);
            this.label3.TabIndex = 27;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // Frm_parasubcontract_trasf_contratto
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(784, 470);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnIndietro);
            this.Controls.Add(this.btnAvanti);
            this.Controls.Add(this.tabController);
            this.Name = "Frm_parasubcontract_trasf_contratto";
            this.Text = "frmcontratto_trasferimento";
            ((System.ComponentModel.ISupportInitialize)(this.dsContratto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.tabController.ResumeLayout(false);
            this.tabIntro.ResumeLayout(false);
            this.tabContrattiNonTrasferibili.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgContrattiNonTrasferibili)).EndInit();
            this.tabContrattiTrasferibili.ResumeLayout(false);
            this.tabContrattiTrasferibili.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgContrattiTrasferibili)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Riempimento e Gestione delle tabelle CONTRATTO del DataSet dsContratto
		/// <summary>
		/// Metodo che riempie la tabella CONTRATTO
		/// </summary>
		private void riempiContratto() {
			string sortContratti = "idcon";
			DateTime ultimoGiornoAnno = new DateTime(esercizio,12,31);
			string filtraContrattiTrasferibili = "(ycon <= " + QHS.quote(esercizio) + ")" +
				" AND EXISTS(SELECT * FROM parasubcontractyear WHERE (ayear = " + QHS.quote(esercizio) +
				") AND (parasubcontract.idcon = parasubcontractyear.idcon))" +
				" AND NOT EXISTS(SELECT * FROM parasubcontractyear WHERE (ayear = " + QHS.quote(eserciziosucc) +
				") AND (parasubcontract.idcon = parasubcontractyear.idcon))" +
				" AND (((SELECT COUNT(*) FROM payroll " +
				" WHERE (fiscalyear = " + QHS.quote(esercizio) +
				") AND (parasubcontract.idcon = payroll.idcon)) = 0) " +
				" OR ((SELECT COUNT(*) FROM payroll " +
				" WHERE (fiscalyear = " + esercizio + ")" +
				" AND (disbursementdate IS NOT NULL) AND (flagbalance = 'S')" +
				" AND (parasubcontract.idcon = payroll.idcon)) > 0 " +
				" AND (SELECT COUNT(*) FROM payroll " +
				" WHERE (fiscalyear = "+ QHS.quote(eserciziosucc) + ")" +
				" AND (parasubcontract.idcon = payroll.idcon)) > 0)" +
                " OR ((stop > " + QHS.quote(ultimoGiornoAnno) + ")" +
                " AND ((SELECT COUNT(*) FROM payroll WHERE fiscalyear = " + QHS.quote(esercizio) + 
                " AND disbursementdate IS NULL AND payroll.idcon = parasubcontract.idcon) = 0)))";

			DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn,dsContratto.parasubcontract,sortContratti,filtraContrattiTrasferibili,null,false);
			
			riempiAltreTabelleNelDataSet();
		}

		/// <summary>
		/// Metodo che riempie le altre tabelle presenti nel dataset solo se ci sono contratti da trasferire
		/// </summary>
		private void riempiAltreTabelleNelDataSet() {
			if (dsContratto.parasubcontract.Rows.Count == 0) return;
            string filtroFigliContratto = QHS.AppAnd(QHS.CmpEq("ayear", esercizio),
                QHS.FieldIn("idcon", dsContratto.parasubcontract.Select()));

			DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn,dsContratto.parasubcontractyear,null,filtroFigliContratto,null,true);
			DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn,dsContratto.parasubcontractfamily,null,filtroFigliContratto,null,true);

            string filteresercizi = QHS.FieldIn("ayear", new object[] { esercizio, eserciziosucc });
			DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn,dsContratto.otherinsurance,null,filteresercizi,null,true);
			DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn,dsContratto.inpsactivity,null,filteresercizi,null,true);
			DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn,dsContratto.emenscontractkind,null,filteresercizi,null,true);

            string filtroCedoliniAnniSuccessivi = QHS.AppAnd(QHS.CmpEq("fiscalyear", eserciziosucc),
                QHS.FieldIn("idcon", dsContratto.parasubcontract.Select()));
			DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn,dsContratto.payroll,null,filtroCedoliniAnniSuccessivi,null,true);
		}
		/// <summary>
		/// Metodo che riempie la tabella CONTRATTONONTRASFERIBILE
		/// </summary>
		private void riempiContrattoNonTrasferibile() {
			string sortContratti = "idcon";
			string filtraContrattiNT = "(ycon <= " + QHS.quote(esercizio) + 
				") AND NOT EXISTS(SELECT * FROM parasubcontractyear WHERE (ayear = " +
				QHS.quote(eserciziosucc) + " ) AND (parasubcontract.idcon = parasubcontractyear.idcon)) " +
				" AND ((SELECT COUNT(*) FROM payroll WHERE (fiscalyear = " + QHS.quote(esercizio) +
				") AND (disbursementdate IS NULL) AND (flagbalance = 'S')" +
				" AND (parasubcontract.idcon = payroll.idcon)) > 0)";
			DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn,dsContratto.contrattonontrasferibile,sortContratti,filtraContrattiNT,null,false);
		}

		/// <summary>
		/// Metodo che riempie le tabelle contratto e contrattonontrasferibile
		/// </summary>
		void riempiTabContratti() {
			riempiContratto();
			impostaCampiCalcolatiContratto();
			assegnaCaptionTabContratto(dsContratto.parasubcontract);
			riempiContrattoNonTrasferibile();
			impostaCampiCalcolatiContrattoNonTrasferibile();
			assegnaCaptionTabContratto(dsContratto.contrattonontrasferibile);
		}

		/// <summary>
		/// Metodo che restituisce la denominazione del percipiente
		/// </summary>
		/// <param name="codicecreddeb">Codice del percipiente</param>
		/// <returns></returns>
		string selezionaCollaboratore(object codicecreddeb) {
			string filtroCreditore = QHS.CmpEq("idreg",codicecreddeb);
			object creditore = Meta.Conn.DO_READ_VALUE("registry", filtroCreditore, "title");
			return creditore as string;
		}

		/// <summary>
		/// Metodo che assegna le caption ai campi di contratto
		/// </summary>
		/// <param name="dt">Tabella da processare</param>
		void assegnaCaptionTabContratto(DataTable dt) {
			foreach(DataColumn C in dt.Columns) {
				C.Caption = "";
			}
			dt.Columns["ycon"].Caption = "Eserc. Contratto";
			dt.Columns["ncon"].Caption = "Num. Contratto";
			dt.Columns["!denominazione"].Caption = "Percipiente";
			dt.Columns["!causa"].Caption = "Causa";
			dt.Columns["start"].Caption = "Data Inizio";
			dt.Columns["stop"].Caption = "Data Fine";
		}

		/// <summary>
		/// Metodo che imposta i campi calcolati di CONTRATTONONTRASFERIBILE
		/// </summary>
		void impostaCampiCalcolatiContrattoNonTrasferibile() {
			foreach(DataRow contrattoRow in dsContratto.contrattonontrasferibile.Rows) {
				string causa = "Cedolino di Conguaglio non Erogato";
				contrattoRow["!denominazione"] = selezionaCollaboratore(contrattoRow["idreg"]);
				contrattoRow["!causa"] = causa;
			}
		}

		/// <summary>
		/// Metodo che imposta i campi calcolati di CONTRATTO
		/// </summary>
		void impostaCampiCalcolatiContratto() {
			foreach(DataRow contrattoRow in dsContratto.parasubcontract.Rows) {
				contrattoRow["!denominazione"] = selezionaCollaboratore(contrattoRow["idreg"]);
			}
		}
		#endregion
	
		#region Riempimento dei grid presenti nel WIZARD
		// Passo 1 del WIZARD - Elenco dei contratti non trasferibili:
		void riempidgContrattiNonTrasferibili() {	
			if (dgContrattiNonTrasferibili.DataSource == null) {
				HelpForm.SetDataGrid(dgContrattiNonTrasferibili,dsContratto.contrattonontrasferibile);
				new formatgrids(dgContrattiNonTrasferibili).AutosizeColumnWidth();
			}
		}

		// Passo 2 del WIZARD - Elenco dei contratti trasferibili
		void riempidgContrattiTrasferibili() {
			if (dgContrattiTrasferibili.DataSource == null) {
				HelpForm.SetDataGrid(dgContrattiTrasferibili, dsContratto.parasubcontract);
				new formatgrids(dgContrattiTrasferibili).AutosizeColumnWidth();
			}
		}
		#endregion

		#region Gestione Bottoni del Wizard (ad esempio Avanti - Indietro etc.)
		/// <summary>
		/// Metodo che visualizza il Tab corrente
		/// </summary>
		/// <param name="newTab">Indice del Tab da visualizzare</param>
		void DisplayTabs(int newTab) {
			if (newTab < pagine.Count) {
				tabController.TabPages.Clear();
				tabController.TabPages.Add((TabPage)pagine[newTab]);
				selectedIndex = newTab;

				if (newTab == pagine.Count-1) {
					btnAvanti.Text = "Fine.";
					btnAvanti.DialogResult = DialogResult.Cancel;
				} 
				else {
					btnAvanti.Text = "Avanti >";
					btnAvanti.DialogResult = DialogResult.None;
				}

				Text = CustomTitle+ " (Pagina "+(newTab+1)+" di "+pagine.Count+")";
			}
		}

		/// <summary>
		/// Metodo che imposta i controlli presenti nel tab che sta per essere visualizzato
		/// </summary>
		/// <param name="step">Numero di Tab da saltare</param>
		void StandardChangeTab(int step) {
			int oldTab= selectedIndex;
			int newTab= oldTab+step;
			if ((newTab<0)||(newTab>pagine.Count))return;

			switch(newTab) {
				case 1: {
					riempidgContrattiNonTrasferibili();
					break;
				}
				case 2: {
					impostaStatoCheck();
					riempidgContrattiTrasferibili();
					break;
				}
			}
			DisplayTabs(newTab);
		}

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
			btnIndietro.Enabled = disponibile && (selectedIndex>0);
			btnAnnulla.Enabled = disponibile && (selectedIndex < pagine.Count-1);
		}
		#endregion
	
		#region Gestione selezione CONTRATTI DA TRASFERIRE

		/// <summary>
		/// Metodo che imposta lo stato dei check box presenti nel tab del trasferimento dei contratti a TRUE
		/// </summary>
		void impostaStatoCheck() {
			chkAltreForme.Checked = true;
			chkFamiliari.Checked = true;
			chkINPS.Checked = true;
			chkTipoRapporto.Checked = true;
		}

		/// <summary>
		/// Metodo che fornisce la prima riga selezionata tra i contratti da trasferire
		/// </summary>
		/// <param name="view">DataView associato al DataGrid</param>
		/// <returns>Indice della riga sleezionata</returns>
		private int getPrimaRigaSelezionataContratti(DataView view) {
			for (int i=0; i<view.Count; i++) {
				if (dgContrattiTrasferibili.IsSelected(i)) {
					return i;
				}
			}
			return -1;
		}

		/// <summary>
		/// Metodo che aggiorna il text box dei contratti selezionati in base al cambio della selezione dei contratti
		/// </summary>
		private void selezioneRigheCambiataContratti() {
			string dataMember = dgContrattiTrasferibili.DataMember;
			CurrencyManager cm = dgContrattiTrasferibili.BindingContext[dsContratto, dataMember] as CurrencyManager;
			if (cm == null) return;
			DataView view = cm.List as DataView;
			if (view != null) {
				int primaRigaSelezionata = getPrimaRigaSelezionataContratti(view);
				if (primaRigaSelezionata == -1) {
					txtContrattiSelezionati.Text = null;
				} 
				else {
					txtContrattiSelezionati.Text = view[primaRigaSelezionata]["ncon"] + "/" + view[primaRigaSelezionata]["ycon"];
					for (int i=primaRigaSelezionata+1; i<view.Count; i++) {
						if (dgContrattiTrasferibili.IsSelected(i)) {
							txtContrattiSelezionati.Text += "," + view[i]["ncon"] + "/" + view[i]["ycon"];
						}
					}
				}		
			}
		}

		/// <summary>
		/// Metodo che aggiorna il dataGrid dei contratti trasferibili
		/// </summary>
		private void aggiornaDataGrid() {
			riempidgContrattiTrasferibili();
		}

		private void btnTrasferisciContratti_Click(object sender, System.EventArgs e) {
			string dataMember = dgContrattiTrasferibili.DataMember;
			CurrencyManager cm = dgContrattiTrasferibili.BindingContext[dsContratto, dataMember] as CurrencyManager;
			if (cm == null) return;
			DataView view = cm.List as DataView;
			if (view == null) {
				MessageBox.Show(this, "Lista vuota!");
				return;
			}
			
			MetaData MetaContratto = MetaData.GetMetaData(this,"parasubcontract");
			ArrayList contratti = new ArrayList();
			//string filtroContratti = "";

			for (int i=0; i<view.Count; i++) {
				if (dgContrattiTrasferibili.IsSelected(i)) {
					object idContratto = view[i]["idcon"];
					if (contratti.IndexOf(idContratto) == -1) {
						contratti.Add(idContratto);
						//filtroContratti += ", "+QHS.quote(idContratto)+"";
					}
				}
			}

			if (contratti.Count == 0) {
				MessageBox.Show(this, "Nessun contratto selezionato!");
				return;
			}

			foreach(object idContratto in contratti) {
				if (chkFamiliari.Checked) {
					trasferisciFamiliare(idContratto);	
				}
				trasferisciImputazioneContratto(idContratto);
			}

			PostData pd = MetaContratto.Get_PostData();
			pd.InitClass(dsContratto,MetaContratto.Conn);
			
			if (!pd.DO_POST()) {
				MessageBox.Show("I Contratti non sono stati trasferiti - Problemi durante il salvataggio");
			}
			else {
				foreach(string idContratto in contratti) {
					rimuoviContrattiTrasferiti(idContratto);
				}
			}
			aggiornaDataGrid();
		}

		/// <summary>
		/// Metodo che rimuove dal DataSet i contratti trasferiti
		/// </summary>
		/// <param name="idContratto">ID del contratto da rimuovere</param>
		void rimuoviContrattiTrasferiti(object idContratto) {
            string filtroContratto = QHC.CmpEq("idcon", idContratto);
			DataRow [] contrattoRow = dsContratto.parasubcontract.Select(filtroContratto);
			if (contrattoRow == null) return;
			if (contrattoRow.Length == 0) return;
			contrattoRow[0].Delete();
			
			DataRow [] imputazionecontrattoRow = dsContratto.parasubcontractyear.Select(filtroContratto);
			if (imputazionecontrattoRow == null) return;
			if (imputazionecontrattoRow.Length == 0) return;
			for(int i = 0; i < imputazionecontrattoRow.Length; i++) {
				imputazionecontrattoRow[i].Delete();
			}

			DataRow [] familiareRow = dsContratto.parasubcontractfamily.Select(filtroContratto);
			if ((familiareRow != null) && (familiareRow.Length > 0)) {
				for(int i = 0; i < familiareRow.Length; i++) {
					familiareRow[i].Delete();
				}
			}
			dsContratto.AcceptChanges();
		}

		/// <summary>
		/// Metodo che trasferisce i familiari legati al contratto
		/// </summary>
		/// <param name="idContratto">ID del contratto per cui trasferire i familiari</param>
		void trasferisciFamiliare(object  idContratto) {
			DateTime lastdayNextYear = new DateTime(eserciziosucc,12,31);
			
			DataRow drContratto = infoContratto(idContratto,dsContratto.parasubcontract);
			if (drContratto == null) return;

            string filtroFamiliare = QHC.AppAnd(QHC.CmpEq("idcon", idContratto), QHC.CmpEq("ayear", esercizio));
			DataRow [] R = dsContratto.parasubcontractfamily.Select(filtroFamiliare);
			if (R == null) return;
			if (R.Length == 0) return;

			for(int i = 0; i<R.Length; i++) {
				MetaData metaFamiliare = MetaData.GetMetaData(this,"parasubcontractfamily");
				metaFamiliare.SetDefaults(dsContratto.parasubcontractfamily);
				MetaData.SetDefault(dsContratto.parasubcontractfamily,"ayear",eserciziosucc);
                MetaData.SetDefault(dsContratto.parasubcontractfamily, "idcon", idContratto);
				DataRow DRF = metaFamiliare.Get_New_Row(drContratto,dsContratto.parasubcontractfamily);
				foreach(DataColumn C in dsContratto.parasubcontractfamily.Columns) {
                    if ((C.ColumnName == "ayear") || (C.ColumnName == "idfamily")) continue;
					DRF[C.ColumnName] = R[i][C];
				}
					
				if (!(R[i]["stopapplication"] == null)) {
					DRF["stopapplication"] = (((DateTime)drContratto["stop"]).Year > eserciziosucc) 
						? lastdayNextYear 
						: drContratto["stop"];
				}
			}
		}

		private void calcolaDateCompetenza(DataRow rImputazioneContratto, out DateTime dataInizioCompetenza, 
            out DateTime dataFineCompetenza) {
            string filtroBase = QHC.MCmp(rImputazioneContratto, "idcon");
			dataInizioCompetenza = QueryCreator.EmptyDate();
			dataFineCompetenza = QueryCreator.EmptyDate();
			// Calcolo della data inizio competenza
			// La data di fine competenza è NULL solo se sono stati trasfertiti tutti i cedolini nell'anno succesivo
			// e non ce ne sono più nell'attuale.
			if (rImputazioneContratto["stopcompetency"] != DBNull.Value) {
				dataInizioCompetenza = ((DateTime)rImputazioneContratto["stopcompetency"]).AddDays(1);
			}
			else {
				DataRow [] rCedoliniAnniSucc = dsContratto.payroll.Select(filtroBase, "fiscalyear, npayroll");
				dataInizioCompetenza = (DateTime)rCedoliniAnniSucc[0]["start"];
			}
			DataRow drContratto = dsContratto.parasubcontract.Select(filtroBase)[0];
			// Calcolo della data fine competenza
			dataFineCompetenza = ((DateTime)drContratto["stop"]).Year > eserciziosucc 
				? new DateTime(eserciziosucc, 12, 31) 
				: (DateTime)drContratto["stop"];
		}

		/// <summary>
		/// Metodo che trasferisce l'imputazione contratto legata al contratto
		/// </summary>
		/// <param name="idContratto">ID del contratto per cui trasferire l'imputazione</param>
		void trasferisciImputazioneContratto(object idContratto) {
			DataRow drContratto = infoContratto(idContratto,dsContratto.parasubcontract);
			if (drContratto == null) return;

            string filtroContratto = QHC.AppAnd(QHC.CmpEq("idcon", idContratto), QHC.CmpEq("ayear", esercizio));
			DataRow [] drImputazione = dsContratto.parasubcontractyear.Select(filtroContratto);
			if (drImputazione.Length == 0) return;

			MetaData metaImpuC = MetaData.GetMetaData(this,"parasubcontractyear");
			metaImpuC.SetDefaults(dsContratto.parasubcontractyear);
			MetaData.SetDefault(dsContratto.parasubcontractyear,"ayear",eserciziosucc);
			DataRow DRImpuC = metaImpuC.Get_New_Row(drContratto,dsContratto.parasubcontractyear);

			DRImpuC["idresidence"] = drImputazione[0]["idresidence"];
			DRImpuC["notaxappliance"] = drImputazione[0]["notaxappliance"];
            DRImpuC["flagbonusappliance"] = drImputazione[0]["flagbonusappliance"];

			// Trasferimento del tipo rapporto E-Mens
			// Viene trasferito solo se esiste un codice analogo nell'esercizio successivo
			if (chkTipoRapporto.Checked) {
                string filtroTipoRapportoEMENS = QHC.AppAnd(QHC.CmpEq("ayear", eserciziosucc),
                    QHC.MCmp(drImputazione[0], "idemenscontractkind"));
				DataRow [] tipoRapportoEmens = dsContratto.emenscontractkind.Select(filtroTipoRapportoEMENS);
				if (tipoRapportoEmens.Length != 0) {
					DRImpuC["idemenscontractkind"] = drImputazione[0]["idemenscontractkind"];
				}
				else {
					DRImpuC["idemenscontractkind"] = DBNull.Value;
				}
			}
			if (!chkTipoRapporto.Checked){
				DRImpuC["idemenscontractkind"] = DBNull.Value;
			}

			// Trasferimento dell'attività previdenziale INPS
			// Viene trasferita solo se esiste un codice analogo nell'esercizio successivo
			if (chkINPS.Checked) {
                string filtroINPS = QHC.AppAnd(QHC.CmpEq("ayear", eserciziosucc),
                    QHC.MCmp(drImputazione[0], "activitycode"));
				DataRow [] inps = dsContratto.inpsactivity.Select(filtroINPS);
				if (inps.Length != 0) {
					DRImpuC["activitycode"] = drImputazione[0]["activitycode"];
				}
				else {
					DRImpuC["activitycode"] = DBNull.Value;
				}
			}

			if (!chkINPS.Checked) {
				DRImpuC["activitycode"] = DBNull.Value;
			}

			// Trasferimento dell'altra forma assicurativa
			// Viene trasferita solo se esiste un codice analogo nell'esercizio successivo
			if (chkAltreForme.Checked) {
                string filtroForma = QHC.AppAnd(QHC.CmpEq("ayear", eserciziosucc),
                    QHC.MCmp(drImputazione[0], "idotherinsurance"));
				DataRow [] forma = dsContratto.otherinsurance.Select(filtroForma);
				if (forma.Length != 0) {
					DRImpuC["idotherinsurance"] = drImputazione[0]["idotherinsurance"];
				}
				else {
                    DRImpuC["idotherinsurance"] = DBNull.Value;
				}
			}
			if (!chkAltreForme.Checked) {
				DRImpuC["idotherinsurance"] = DBNull.Value;
			}

			DRImpuC["applybrackets"] = drImputazione[0]["applybrackets"];

			
			DateTime dataInizioCompetenza;
			DateTime dataFineCompetenza;
			calcolaDateCompetenza(drImputazione[0], out dataInizioCompetenza, out dataFineCompetenza);
			DRImpuC["startcompetency"] = dataInizioCompetenza;
			DRImpuC["stopcompetency"] = dataFineCompetenza;

            decimal imponibileContrattoAnnoCorrente = calcolaImponibileContratto(idContratto, esercizio);
            drImputazione[0]["taxablepension"] = imponibileContrattoAnnoCorrente;
            drImputazione[0]["taxablecontract"] = imponibileContrattoAnnoCorrente;

            decimal imponibileContrattoResiduo = calcolaResiduoImponibileContratto(idContratto);

            DRImpuC["taxablepension"] = imponibileContrattoResiduo;
            DRImpuC["taxablecontract"] = imponibileContrattoResiduo;

			// Commento Rusciano Giuseppe 04.01.2005
			// Questa parte è stata commentantata in attesa delle decisioni su come gestire l'aliquota marginale
			// eventualmente può essere riutilizzata.
			/*
			// Calcolo dell'aliquota marginale
			DRImpuC["applicascaglioni"] = drImputazione[0]["applicascaglioni"];
			if (drImputazione[0]["applicascaglioni"]== "S") return;
			// Nel caso sia uguale ad S bisogna scegliere la nuova aliquota marginale
			// Per scegliere l'aliquota marginale bisogna calcolare il compenso di competenza del nuovo esercizio
			// e poi scegliere l'aliquota opportuna.
			string filterCedoliniTrasferiti = "(idcontratto = " + QueryCreator.quotedstrvalue(idContratto,true) + 
			") AND (annoriferimento <= " + esercizio + ") AND (annofiscale = " + eserciziosucc + 
			") AND (flagconguaglio = 'N')";
			int contaCedoliniTrasferiti = (int)Meta.Conn.DO_READ_VALUE("cedolino",filterCedoliniTrasferiti,"COUNT(*)");
			
			string orderby = "annoriferimento asc, meseriferimento asc";
			
			DateTime dataInizioCed = (DateTime)Meta.Conn.DO_READ_VALUE("cedolino",filterCedoliniTrasferiti,"TOP 1 datainizio",orderby);

			DateTime PrimoMeseDaErogare = (contaCedoliniTrasferiti > 0) ? dataInizioCed.AddDays(1 - dataInizioCed.Day) : new DateTime(eserciziosucc,1,1);	

			string filterCedoliniErogati = "(idcontratto = " + QueryCreator.quotedstrvalue(idContratto,true) + 
			") AND (annoriferimento <= " + esercizio + ") AND (annofiscale = " + Meta.GetSys("esercizio") + 
			") AND (flagconguaglio = 'N') AND (dataerogazione IS NOT NULL)";
			decimal compensoErogato = (decimal)Meta.Conn.DO_READ_VALUE("cedolino",filterCedoliniErogati,"SUM(compensolordo)");
			
			DateTime dataFine = (DateTime)drContratto[0]["datafine"];
			DateTime ultimoGiornoMese = new DateTime(1900,1,1);
			GregorianCalendar gc = new GregorianCalendar();
			// Caso 1: (dataFine.Year < eserciziosucc)
			decimal compensoNextYear = (decimal)drContratto[0]["importolordo"] - compensoErogato;

			// Caso 2: (dataFine.Year = eserciziosucc)
			if (dataFine.Year == eserciziosucc)
			{
				ultimoGiornoMese = ultimoGiornoMese.AddYears(dataFine.Year - ultimoGiornoMese.Year);
				ultimoGiornoMese = ultimoGiornoMese.AddMonths(dataFine.Month - 1);
				ultimoGiornoMese = ultimoGiornoMese.AddDays(gc.GetDaysInMonth(dataFine.Year,dataFine.Month)-1);
			}

			// Caso 3: (dataFine.Year > eserciziosucc)
			if (dataFine.Year > eserciziosucc)
			{
				ultimoGiornoMese = ultimoGiornoMese.AddYears(eserciziosucc - ultimoGiornoMese.Year);
				ultimoGiornoMese = ultimoGiornoMese.AddMonths(11);
				ultimoGiornoMese = ultimoGiornoMese.AddDays(30);
				int nGiorniRimanenti = (ultimoGiornoMese - dataFine).Days;
				int nGiorniNextYear = (ultimoGiornoMese - ultimoGiornoMese).Days;
				compensoNextYear = (compensoNextYear / nGiorniRimanenti) * nGiorniNextYear;
			}
			string filterAliquota =
			" SELECT TOP 1(aliquotaritenuta.aliquotadipendente) FROM aliquotaritenuta " +
			" JOIN scaglionealiquote ON (aliquotaritenuta.codiceritenuta = scaglionealiquote.codiceritenuta) " +
			" AND (aliquotaritenuta.datainiziostruttura = scaglionealiquote.datainiziostruttura) " +
			" AND (aliquotaritenuta.numeroscaglione = scaglionealiquote.numeroscaglione) " +
			" WHERE (aliquotaritenuta.codiceritenuta = " +
				" (SELECT tiporitenuta.codiceritenuta FROM tiporitenuta " +
				" JOIN ritenutaprestazione ON (tiporitenuta.codiceritenuta = ritenutaprestazione.codiceritenuta) " +
				" WHERE (tiporitenuta.tiporitenuta = 'F') AND (tiporitenuta.tipoapplicazionegeografica IS NULL) " +
				" AND (ritenutaprestazione.codiceprestazione = " +
					" (SELECT codiceprestazione FROM contratto " +
					" WHERE (idcontratto = " + QueryCreator.quotedstrvalue(idContratto,true) + "))" +
				"))" +
			") AND (aliquotaritenuta.datainiziostruttura <= " + QueryCreator.quotedstrvalue(ultimoGiornoMese,true) + ")" +
			" AND (aliquotaritenuta.datainizioaliquota <= " + QueryCreator.quotedstrvalue(ultimoGiornoMese,true) + ")" +
			" AND ((scaglionealiquote.importominimo IS NULL) OR (" + QueryCreator.unquotedstrvalue(compensoNextYear,true) + 
			" > scaglionealiquote.importominimo) OR (" + QueryCreator.unquotedstrvalue(compensoNextYear,true) + 
			" = 0) AND (scaglionealiquote.importominimo = 0)) " +
			" AND ((scaglionealiquote.importomassimo IS NULL) OR (" + QueryCreator.unquotedstrvalue(compensoNextYear,true) +
			" <= scaglionealiquote.importomassimo)) " +
			" ORDER BY aliquotaritenuta.datainiziostruttura DESC, aliquotaritenuta.datainizioaliquota DESC";
			DataTable t = DataAccess.SQLRunner(Meta.Conn,filterAliquota);
			DRImpuC["maggioreritenuta"] = t.Rows[0][0];
			*/
		}

		/// <summary>
		/// Metodo che restituisce un DataRow della tabella contratto
		/// </summary>
		/// <param name="idContratto">ID del contratto su cui si desiderano le indormazioni</param>
		/// <param name="dt">Tabella in cui il contratto è presente</param>
		/// <returns>DataRow di contratto</returns>
		DataRow infoContratto(object idContratto,DataTable dt) {
            string filter = QHC.CmpEq("idcon", idContratto);
			DataRow [] drContratto = dt.Select(filter);
			if (drContratto == null) return null;
			if (drContratto.Length == 0) return null;
			return drContratto[0];
		}

		private void dgContrattiTrasferibili_Paint(object sender, System.Windows.Forms.PaintEventArgs e) {
			selezioneRigheCambiataContratti();		
		}

        /// <summary>
        /// Metodo che calcola l'imponibile del contratto per un determinato esercizio
        /// </summary>
        /// <param name="idContratto"></param>
        /// <param name="esercizio"></param>
        /// <returns></returns>
        private decimal calcolaImponibileContratto(object idContratto, int esercizio) {
            string filter = QHS.AppAnd(QHS.CmpEq("idcon", idContratto), 
                QHS.CmpEq("fiscalyear", esercizio),
                QHS.CmpEq("flagbalance", "S"));

            decimal imponibile = CfgFn.GetNoNullDecimal(Meta.Conn.DO_READ_VALUE("payroll", filter, "feegross"));

            return imponibile;
        }

        /// <summary>
        /// Metodo che calcola l'imponibile residuo del contratto
        /// </summary>
        /// <param name="idContratto"></param>
        /// <returns></returns>
        private decimal calcolaResiduoImponibileContratto(object idContratto) {
            string filter = QHS.AppAnd(QHS.CmpEq("idcon", idContratto),
                QHS.CmpLe("fiscalyear", esercizio),
                QHS.CmpEq("flagbalance", "S"));

            decimal totConguagliato = CfgFn.GetNoNullDecimal(Meta.Conn.DO_READ_VALUE("payroll", filter, "feegross"));

            DataRow rContratto = dsContratto.parasubcontract.Select(QHC.CmpEq("idcon", idContratto))[0];
            decimal importoContratto = CfgFn.GetNoNullDecimal(rContratto["grossamount"]);

            return (importoContratto - totConguagliato);
        }

		#endregion Gestione selezione CONTRATTI DA TRASFERIRE
	}
}
