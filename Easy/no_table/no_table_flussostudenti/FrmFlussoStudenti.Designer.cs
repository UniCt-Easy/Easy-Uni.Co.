
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


namespace no_table_flussostudenti {
    partial class Frmflussostudenti {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
			this.DS = new no_table_flussostudenti.dsmeta();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.openInputFileDlg = new System.Windows.Forms.OpenFileDialog();
			this.saveOutputFileDlg = new System.Windows.Forms.SaveFileDialog();
			this.tabGrid = new System.Windows.Forms.TabControl();
			this.tabPageCreditiImportati = new System.Windows.Forms.TabPage();
			this.dgrCrediti = new System.Windows.Forms.DataGrid();
			this.tabPageIncassiImportati = new System.Windows.Forms.TabPage();
			this.dgrIncassi = new System.Windows.Forms.DataGrid();
			this.tabPageDettContratti = new System.Windows.Forms.TabPage();
			this.dgrDettContrattiAttivi = new System.Windows.Forms.DataGrid();
			this.tabPageFattureCreate = new System.Windows.Forms.TabPage();
			this.dgrFattureElaborate = new System.Windows.Forms.DataGrid();
			this.CMenu = new System.Windows.Forms.ContextMenu();
			this.MenuEnterPwd = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.tabFunzioni = new System.Windows.Forms.TabControl();
			this.tabPageImportaFlussi = new System.Windows.Forms.TabPage();
			this.btnSospesiRFSRFB = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnImportaFlussoIncassi = new System.Windows.Forms.Button();
			this.txtInputFile = new System.Windows.Forms.TextBox();
			this.btnImportaFlussoCrediti = new System.Windows.Forms.Button();
			this.tabPageElaboraCrediti = new System.Windows.Forms.TabPage();
			this.grpElaborazioneCrediti = new System.Windows.Forms.GroupBox();
			this.txtStopFlusso = new System.Windows.Forms.TextBox();
			this.txtStartFlusso = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnelaboraFlussoCrediti = new System.Windows.Forms.Button();
			this.btnElaboraContabilizzazioni = new System.Windows.Forms.Button();
			this.btnCercaContrattiDaContabilizzare = new System.Windows.Forms.Button();
			this.tabPageElaboraIncassi = new System.Windows.Forms.TabPage();
			this.grpElaborazioneIncassi = new System.Windows.Forms.GroupBox();
			this.labNFlussoIncassi = new System.Windows.Forms.Label();
			this.txtNumFlussoIncassi = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnCreaIncassiFatture = new System.Windows.Forms.Button();
			this.chkAncheSenzaSospesi = new System.Windows.Forms.CheckBox();
			this.btnIncassiContrattiAttivi = new System.Windows.Forms.Button();
			this.btnElaboraIncassi = new System.Windows.Forms.Button();
			this.pBar = new System.Windows.Forms.ProgressBar();
			this.labPBar = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.tabGrid.SuspendLayout();
			this.tabPageCreditiImportati.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrCrediti)).BeginInit();
			this.tabPageIncassiImportati.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrIncassi)).BeginInit();
			this.tabPageDettContratti.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrDettContrattiAttivi)).BeginInit();
			this.tabPageFattureCreate.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrFattureElaborate)).BeginInit();
			this.tabFunzioni.SuspendLayout();
			this.tabPageImportaFlussi.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.tabPageElaboraCrediti.SuspendLayout();
			this.grpElaborazioneCrediti.SuspendLayout();
			this.tabPageElaboraIncassi.SuspendLayout();
			this.grpElaborazioneIncassi.SuspendLayout();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			// 
			// saveOutputFileDlg
			// 
			this.saveOutputFileDlg.DefaultExt = "T24";
			// 
			// tabGrid
			// 
			this.tabGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabGrid.Controls.Add(this.tabPageCreditiImportati);
			this.tabGrid.Controls.Add(this.tabPageIncassiImportati);
			this.tabGrid.Controls.Add(this.tabPageDettContratti);
			this.tabGrid.Controls.Add(this.tabPageFattureCreate);
			this.tabGrid.Location = new System.Drawing.Point(12, 245);
			this.tabGrid.Name = "tabGrid";
			this.tabGrid.SelectedIndex = 0;
			this.tabGrid.Size = new System.Drawing.Size(921, 328);
			this.tabGrid.TabIndex = 11;
			// 
			// tabPageCreditiImportati
			// 
			this.tabPageCreditiImportati.Controls.Add(this.dgrCrediti);
			this.tabPageCreditiImportati.Location = new System.Drawing.Point(4, 22);
			this.tabPageCreditiImportati.Name = "tabPageCreditiImportati";
			this.tabPageCreditiImportati.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageCreditiImportati.Size = new System.Drawing.Size(913, 302);
			this.tabPageCreditiImportati.TabIndex = 1;
			this.tabPageCreditiImportati.Text = "Crediti importati";
			this.tabPageCreditiImportati.UseVisualStyleBackColor = true;
			// 
			// dgrCrediti
			// 
			this.dgrCrediti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrCrediti.DataMember = "";
			this.dgrCrediti.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrCrediti.Location = new System.Drawing.Point(6, 6);
			this.dgrCrediti.Name = "dgrCrediti";
			this.dgrCrediti.Size = new System.Drawing.Size(901, 290);
			this.dgrCrediti.TabIndex = 6;
			// 
			// tabPageIncassiImportati
			// 
			this.tabPageIncassiImportati.Controls.Add(this.dgrIncassi);
			this.tabPageIncassiImportati.Location = new System.Drawing.Point(4, 22);
			this.tabPageIncassiImportati.Name = "tabPageIncassiImportati";
			this.tabPageIncassiImportati.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageIncassiImportati.Size = new System.Drawing.Size(913, 302);
			this.tabPageIncassiImportati.TabIndex = 3;
			this.tabPageIncassiImportati.Text = "Incassi importati";
			this.tabPageIncassiImportati.UseVisualStyleBackColor = true;
			// 
			// dgrIncassi
			// 
			this.dgrIncassi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrIncassi.DataMember = "";
			this.dgrIncassi.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrIncassi.Location = new System.Drawing.Point(6, 6);
			this.dgrIncassi.Name = "dgrIncassi";
			this.dgrIncassi.Size = new System.Drawing.Size(897, 290);
			this.dgrIncassi.TabIndex = 6;
			// 
			// tabPageDettContratti
			// 
			this.tabPageDettContratti.Controls.Add(this.dgrDettContrattiAttivi);
			this.tabPageDettContratti.Location = new System.Drawing.Point(4, 22);
			this.tabPageDettContratti.Name = "tabPageDettContratti";
			this.tabPageDettContratti.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageDettContratti.Size = new System.Drawing.Size(913, 302);
			this.tabPageDettContratti.TabIndex = 4;
			this.tabPageDettContratti.Text = "Dett. Contratti Attivi da Contabilizzare";
			this.tabPageDettContratti.UseVisualStyleBackColor = true;
			// 
			// dgrDettContrattiAttivi
			// 
			this.dgrDettContrattiAttivi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrDettContrattiAttivi.DataMember = "";
			this.dgrDettContrattiAttivi.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrDettContrattiAttivi.Location = new System.Drawing.Point(6, 6);
			this.dgrDettContrattiAttivi.Name = "dgrDettContrattiAttivi";
			this.dgrDettContrattiAttivi.Size = new System.Drawing.Size(901, 293);
			this.dgrDettContrattiAttivi.TabIndex = 7;
			this.dgrDettContrattiAttivi.Tag = "estimatedetail.contabilizza";
			this.dgrDettContrattiAttivi.DoubleClick += new System.EventHandler(this.datagrid_DoubleClick);
			// 
			// tabPageFattureCreate
			// 
			this.tabPageFattureCreate.Controls.Add(this.dgrFattureElaborate);
			this.tabPageFattureCreate.Location = new System.Drawing.Point(4, 22);
			this.tabPageFattureCreate.Name = "tabPageFattureCreate";
			this.tabPageFattureCreate.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageFattureCreate.Size = new System.Drawing.Size(913, 302);
			this.tabPageFattureCreate.TabIndex = 5;
			this.tabPageFattureCreate.Text = "Fatture Elaborate";
			this.tabPageFattureCreate.UseVisualStyleBackColor = true;
			// 
			// dgrFattureElaborate
			// 
			this.dgrFattureElaborate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrFattureElaborate.DataMember = "";
			this.dgrFattureElaborate.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrFattureElaborate.Location = new System.Drawing.Point(6, 6);
			this.dgrFattureElaborate.Name = "dgrFattureElaborate";
			this.dgrFattureElaborate.Size = new System.Drawing.Size(901, 290);
			this.dgrFattureElaborate.TabIndex = 8;
			this.dgrFattureElaborate.Tag = "invoice.elaboraincassi";
			this.dgrFattureElaborate.DoubleClick += new System.EventHandler(this.datagrid_DoubleClick);
			// 
			// CMenu
			// 
			this.CMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuEnterPwd,
            this.menuItem1});
			// 
			// MenuEnterPwd
			// 
			this.MenuEnterPwd.Index = 0;
			this.MenuEnterPwd.Text = "Visualizza tracciato";
			this.MenuEnterPwd.Click += new System.EventHandler(this.menuEnterPwd_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 1;
			this.menuItem1.Text = "Test 1 record";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// tabFunzioni
			// 
			this.tabFunzioni.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabFunzioni.Controls.Add(this.tabPageImportaFlussi);
			this.tabFunzioni.Controls.Add(this.tabPageElaboraCrediti);
			this.tabFunzioni.Controls.Add(this.tabPageElaboraIncassi);
			this.tabFunzioni.Location = new System.Drawing.Point(12, 12);
			this.tabFunzioni.Name = "tabFunzioni";
			this.tabFunzioni.SelectedIndex = 0;
			this.tabFunzioni.Size = new System.Drawing.Size(911, 171);
			this.tabFunzioni.TabIndex = 131;
			// 
			// tabPageImportaFlussi
			// 
			this.tabPageImportaFlussi.AutoScroll = true;
			this.tabPageImportaFlussi.Controls.Add(this.btnSospesiRFSRFB);
			this.tabPageImportaFlussi.Controls.Add(this.groupBox2);
			this.tabPageImportaFlussi.Location = new System.Drawing.Point(4, 22);
			this.tabPageImportaFlussi.Name = "tabPageImportaFlussi";
			this.tabPageImportaFlussi.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageImportaFlussi.Size = new System.Drawing.Size(903, 145);
			this.tabPageImportaFlussi.TabIndex = 0;
			this.tabPageImportaFlussi.Text = "Importa Flusso crediti e incassi da File Excel";
			this.tabPageImportaFlussi.UseVisualStyleBackColor = true;
			// 
			// btnSospesiRFSRFB
			// 
			this.btnSospesiRFSRFB.Location = new System.Drawing.Point(632, 36);
			this.btnSospesiRFSRFB.Name = "btnSospesiRFSRFB";
			this.btnSospesiRFSRFB.Size = new System.Drawing.Size(223, 23);
			this.btnSospesiRFSRFB.TabIndex = 3;
			this.btnSospesiRFSRFB.Text = "3 - Importa Flusso Incassi da sospesi ";
			this.btnSospesiRFSRFB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnSospesiRFSRFB.Click += new System.EventHandler(this.btnSospesiRFSRFB_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnImportaFlussoIncassi);
			this.groupBox2.Controls.Add(this.txtInputFile);
			this.groupBox2.Controls.Add(this.btnImportaFlussoCrediti);
			this.groupBox2.Location = new System.Drawing.Point(10, 19);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(605, 81);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Input";
			// 
			// btnImportaFlussoIncassi
			// 
			this.btnImportaFlussoIncassi.Location = new System.Drawing.Point(310, 17);
			this.btnImportaFlussoIncassi.Name = "btnImportaFlussoIncassi";
			this.btnImportaFlussoIncassi.Size = new System.Drawing.Size(223, 23);
			this.btnImportaFlussoIncassi.TabIndex = 2;
			this.btnImportaFlussoIncassi.Text = "2 - Importa Flusso Incassi da File Excel";
			this.btnImportaFlussoIncassi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnImportaFlussoIncassi.Click += new System.EventHandler(this.btnIncassi_Click);
			// 
			// txtInputFile
			// 
			this.txtInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtInputFile.Location = new System.Drawing.Point(6, 46);
			this.txtInputFile.Name = "txtInputFile";
			this.txtInputFile.ReadOnly = true;
			this.txtInputFile.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
			this.txtInputFile.Size = new System.Drawing.Size(589, 20);
			this.txtInputFile.TabIndex = 0;
			// 
			// btnImportaFlussoCrediti
			// 
			this.btnImportaFlussoCrediti.Location = new System.Drawing.Point(6, 17);
			this.btnImportaFlussoCrediti.Name = "btnImportaFlussoCrediti";
			this.btnImportaFlussoCrediti.Size = new System.Drawing.Size(221, 23);
			this.btnImportaFlussoCrediti.TabIndex = 1;
			this.btnImportaFlussoCrediti.Text = "1 - Importa Flusso Crediti da File Excel";
			this.btnImportaFlussoCrediti.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnImportaFlussoCrediti.Click += new System.EventHandler(this.btnFileInput_Click);
			// 
			// tabPageElaboraCrediti
			// 
			this.tabPageElaboraCrediti.Controls.Add(this.grpElaborazioneCrediti);
			this.tabPageElaboraCrediti.Location = new System.Drawing.Point(4, 22);
			this.tabPageElaboraCrediti.Name = "tabPageElaboraCrediti";
			this.tabPageElaboraCrediti.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageElaboraCrediti.Size = new System.Drawing.Size(903, 145);
			this.tabPageElaboraCrediti.TabIndex = 1;
			this.tabPageElaboraCrediti.Text = "Elaborazione Crediti ";
			this.tabPageElaboraCrediti.UseVisualStyleBackColor = true;
			// 
			// grpElaborazioneCrediti
			// 
			this.grpElaborazioneCrediti.Controls.Add(this.txtStopFlusso);
			this.grpElaborazioneCrediti.Controls.Add(this.txtStartFlusso);
			this.grpElaborazioneCrediti.Controls.Add(this.label3);
			this.grpElaborazioneCrediti.Controls.Add(this.label1);
			this.grpElaborazioneCrediti.Controls.Add(this.btnelaboraFlussoCrediti);
			this.grpElaborazioneCrediti.Controls.Add(this.btnElaboraContabilizzazioni);
			this.grpElaborazioneCrediti.Controls.Add(this.btnCercaContrattiDaContabilizzare);
			this.grpElaborazioneCrediti.Location = new System.Drawing.Point(16, 6);
			this.grpElaborazioneCrediti.Name = "grpElaborazioneCrediti";
			this.grpElaborazioneCrediti.Size = new System.Drawing.Size(869, 126);
			this.grpElaborazioneCrediti.TabIndex = 134;
			this.grpElaborazioneCrediti.TabStop = false;
			// 
			// txtStopFlusso
			// 
			this.txtStopFlusso.Location = new System.Drawing.Point(747, 20);
			this.txtStopFlusso.Name = "txtStopFlusso";
			this.txtStopFlusso.Size = new System.Drawing.Size(96, 20);
			this.txtStopFlusso.TabIndex = 136;
			// 
			// txtStartFlusso
			// 
			this.txtStartFlusso.Location = new System.Drawing.Point(573, 20);
			this.txtStartFlusso.Name = "txtStartFlusso";
			this.txtStartFlusso.Size = new System.Drawing.Size(96, 20);
			this.txtStartFlusso.TabIndex = 135;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(675, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(55, 13);
			this.label3.TabIndex = 134;
			this.label3.Text = "a n. flusso";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(499, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 13);
			this.label1.TabIndex = 133;
			this.label1.Text = "da n.flusso";
			// 
			// btnelaboraFlussoCrediti
			// 
			this.btnelaboraFlussoCrediti.Location = new System.Drawing.Point(112, 19);
			this.btnelaboraFlussoCrediti.Name = "btnelaboraFlussoCrediti";
			this.btnelaboraFlussoCrediti.Size = new System.Drawing.Size(364, 23);
			this.btnelaboraFlussoCrediti.TabIndex = 130;
			this.btnelaboraFlussoCrediti.Text = "1 - Crea/Annulla Contratto Attivo da Flusso Crediti";
			this.btnelaboraFlussoCrediti.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnelaboraFlussoCrediti.Click += new System.EventHandler(this.btnElaboraFlussoCrediti_Click);
			// 
			// btnElaboraContabilizzazioni
			// 
			this.btnElaboraContabilizzazioni.Location = new System.Drawing.Point(112, 87);
			this.btnElaboraContabilizzazioni.Name = "btnElaboraContabilizzazioni";
			this.btnElaboraContabilizzazioni.Size = new System.Drawing.Size(364, 23);
			this.btnElaboraContabilizzazioni.TabIndex = 131;
			this.btnElaboraContabilizzazioni.Text = "3 - Crea accertamenti contratti attivi";
			this.btnElaboraContabilizzazioni.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnElaboraContabilizzazioni.Click += new System.EventHandler(this.btnElaboraContabilizzazioni_Click);
			// 
			// btnCercaContrattiDaContabilizzare
			// 
			this.btnCercaContrattiDaContabilizzare.Location = new System.Drawing.Point(112, 53);
			this.btnCercaContrattiDaContabilizzare.Name = "btnCercaContrattiDaContabilizzare";
			this.btnCercaContrattiDaContabilizzare.Size = new System.Drawing.Size(364, 23);
			this.btnCercaContrattiDaContabilizzare.TabIndex = 132;
			this.btnCercaContrattiDaContabilizzare.Text = "2 - Cerca Contratti Attivi da Flusso Crediti non collegati a Mov. Finanziari";
			this.btnCercaContrattiDaContabilizzare.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCercaContrattiDaContabilizzare.Click += new System.EventHandler(this.btnCercaContrattiDaContabilizzare_Click);
			// 
			// tabPageElaboraIncassi
			// 
			this.tabPageElaboraIncassi.Controls.Add(this.grpElaborazioneIncassi);
			this.tabPageElaboraIncassi.Location = new System.Drawing.Point(4, 22);
			this.tabPageElaboraIncassi.Name = "tabPageElaboraIncassi";
			this.tabPageElaboraIncassi.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageElaboraIncassi.Size = new System.Drawing.Size(903, 145);
			this.tabPageElaboraIncassi.TabIndex = 2;
			this.tabPageElaboraIncassi.Text = "Elaborazione Incassi ";
			this.tabPageElaboraIncassi.UseVisualStyleBackColor = true;
			// 
			// grpElaborazioneIncassi
			// 
			this.grpElaborazioneIncassi.Controls.Add(this.labNFlussoIncassi);
			this.grpElaborazioneIncassi.Controls.Add(this.txtNumFlussoIncassi);
			this.grpElaborazioneIncassi.Controls.Add(this.label2);
			this.grpElaborazioneIncassi.Controls.Add(this.btnCreaIncassiFatture);
			this.grpElaborazioneIncassi.Controls.Add(this.chkAncheSenzaSospesi);
			this.grpElaborazioneIncassi.Controls.Add(this.btnIncassiContrattiAttivi);
			this.grpElaborazioneIncassi.Controls.Add(this.btnElaboraIncassi);
			this.grpElaborazioneIncassi.Location = new System.Drawing.Point(16, 6);
			this.grpElaborazioneIncassi.Name = "grpElaborazioneIncassi";
			this.grpElaborazioneIncassi.Size = new System.Drawing.Size(718, 126);
			this.grpElaborazioneIncassi.TabIndex = 133;
			this.grpElaborazioneIncassi.TabStop = false;
			// 
			// labNFlussoIncassi
			// 
			this.labNFlussoIncassi.AutoSize = true;
			this.labNFlussoIncassi.Location = new System.Drawing.Point(264, 64);
			this.labNFlussoIncassi.Name = "labNFlussoIncassi";
			this.labNFlussoIncassi.Size = new System.Drawing.Size(345, 13);
			this.labNFlussoIncassi.TabIndex = 137;
			this.labNFlussoIncassi.Text = "N. Flusso incassi - se specificato l\'elaborazione è limitata a questo flusso";
			// 
			// txtNumFlussoIncassi
			// 
			this.txtNumFlussoIncassi.Location = new System.Drawing.Point(267, 80);
			this.txtNumFlussoIncassi.Name = "txtNumFlussoIncassi";
			this.txtNumFlussoIncassi.Size = new System.Drawing.Size(100, 20);
			this.txtNumFlussoIncassi.TabIndex = 136;
			// 
			// label2
			// 
			this.label2.Enabled = false;
			this.label2.Location = new System.Drawing.Point(434, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(272, 39);
			this.label2.TabIndex = 135;
			this.label2.Text = "Nota: questa funzione implica l\'associazione manuale degli incassi ai sospesi att" +
    "ivi, normalmente non dovrebbe essere usata ";
			// 
			// btnCreaIncassiFatture
			// 
			this.btnCreaIncassiFatture.Location = new System.Drawing.Point(28, 77);
			this.btnCreaIncassiFatture.Name = "btnCreaIncassiFatture";
			this.btnCreaIncassiFatture.Size = new System.Drawing.Size(221, 23);
			this.btnCreaIncassiFatture.TabIndex = 134;
			this.btnCreaIncassiFatture.Text = "3 - Crea accertamenti e  incassi fatture";
			this.btnCreaIncassiFatture.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCreaIncassiFatture.Click += new System.EventHandler(this.btnCreaIncassiFatture_Click);
			// 
			// chkAncheSenzaSospesi
			// 
			this.chkAncheSenzaSospesi.AutoSize = true;
			this.chkAncheSenzaSospesi.Enabled = false;
			this.chkAncheSenzaSospesi.Location = new System.Drawing.Point(267, 23);
			this.chkAncheSenzaSospesi.Name = "chkAncheSenzaSospesi";
			this.chkAncheSenzaSospesi.Size = new System.Drawing.Size(161, 17);
			this.chkAncheSenzaSospesi.TabIndex = 133;
			this.chkAncheSenzaSospesi.Text = "Anche incassi senza sospesi";
			this.chkAncheSenzaSospesi.UseVisualStyleBackColor = true;
			// 
			// btnIncassiContrattiAttivi
			// 
			this.btnIncassiContrattiAttivi.Location = new System.Drawing.Point(28, 19);
			this.btnIncassiContrattiAttivi.Name = "btnIncassiContrattiAttivi";
			this.btnIncassiContrattiAttivi.Size = new System.Drawing.Size(221, 23);
			this.btnIncassiContrattiAttivi.TabIndex = 132;
			this.btnIncassiContrattiAttivi.Text = "1 - Crea Incassi  per i contratti attivi";
			this.btnIncassiContrattiAttivi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnIncassiContrattiAttivi.Click += new System.EventHandler(this.btnIncassiContrattiAttivi_Click);
			// 
			// btnElaboraIncassi
			// 
			this.btnElaboraIncassi.Location = new System.Drawing.Point(28, 48);
			this.btnElaboraIncassi.Name = "btnElaboraIncassi";
			this.btnElaboraIncassi.Size = new System.Drawing.Size(221, 23);
			this.btnElaboraIncassi.TabIndex = 131;
			this.btnElaboraIncassi.Text = "2 - Crea Fatture da incassi";
			this.btnElaboraIncassi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnElaboraIncassi.Click += new System.EventHandler(this.btnElaboraFattureDaIncassi_Click);
			// 
			// pBar
			// 
			this.pBar.Location = new System.Drawing.Point(16, 216);
			this.pBar.Name = "pBar";
			this.pBar.Size = new System.Drawing.Size(903, 23);
			this.pBar.TabIndex = 132;
			this.pBar.Visible = false;
			// 
			// labPBar
			// 
			this.labPBar.AutoSize = true;
			this.labPBar.Location = new System.Drawing.Point(19, 200);
			this.labPBar.Name = "labPBar";
			this.labPBar.Size = new System.Drawing.Size(0, 13);
			this.labPBar.TabIndex = 133;
			// 
			// Frmflussostudenti
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(942, 576);
			this.Controls.Add(this.labPBar);
			this.Controls.Add(this.pBar);
			this.Controls.Add(this.tabFunzioni);
			this.Controls.Add(this.tabGrid);
			this.Name = "Frmflussostudenti";
			this.Text = "Frmflussostudenti";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.tabGrid.ResumeLayout(false);
			this.tabPageCreditiImportati.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrCrediti)).EndInit();
			this.tabPageIncassiImportati.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrIncassi)).EndInit();
			this.tabPageDettContratti.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrDettContrattiAttivi)).EndInit();
			this.tabPageFattureCreate.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrFattureElaborate)).EndInit();
			this.tabFunzioni.ResumeLayout(false);
			this.tabPageImportaFlussi.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.tabPageElaboraCrediti.ResumeLayout(false);
			this.grpElaborazioneCrediti.ResumeLayout(false);
			this.grpElaborazioneCrediti.PerformLayout();
			this.tabPageElaboraIncassi.ResumeLayout(false);
			this.grpElaborazioneIncassi.ResumeLayout(false);
			this.grpElaborazioneIncassi.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        public dsmeta DS;
        string fileName;
        //System.Data.DataTable mData = new System.Data.DataTable();
        //System.Data.DataTable mData_essetre = new System.Data.DataTable();
        //System.Data.DataTable mData1 = new System.Data.DataTable();
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openInputFileDlg;
        private System.Windows.Forms.SaveFileDialog saveOutputFileDlg;
        private System.Windows.Forms.TabControl tabGrid;
        private System.Windows.Forms.TabPage tabPageCreditiImportati;
        private System.Windows.Forms.DataGrid dgrCrediti;
        private System.Windows.Forms.TabPage tabPageIncassiImportati;
        private System.Windows.Forms.DataGrid dgrIncassi;
        private System.Windows.Forms.TabPage tabPageDettContratti;
        private System.Windows.Forms.DataGrid dgrDettContrattiAttivi;
        private System.Windows.Forms.ContextMenu CMenu;
        private System.Windows.Forms.MenuItem MenuEnterPwd;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.TabControl tabFunzioni;
        private System.Windows.Forms.TabPage tabPageImportaFlussi;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnImportaFlussoIncassi;
        private System.Windows.Forms.TextBox txtInputFile;
        private System.Windows.Forms.Button btnImportaFlussoCrediti;
        private System.Windows.Forms.TabPage tabPageElaboraCrediti;
        private System.Windows.Forms.Button btnCercaContrattiDaContabilizzare;
        private System.Windows.Forms.Button btnElaboraContabilizzazioni;
        private System.Windows.Forms.Button btnelaboraFlussoCrediti;
        private System.Windows.Forms.TabPage tabPageElaboraIncassi;
        private System.Windows.Forms.Button btnElaboraIncassi;
        private System.Windows.Forms.GroupBox grpElaborazioneCrediti;
        private System.Windows.Forms.GroupBox grpElaborazioneIncassi;
        private System.Windows.Forms.TabPage tabPageFattureCreate;
        private System.Windows.Forms.DataGrid dgrFattureElaborate;
        private System.Windows.Forms.Button btnIncassiContrattiAttivi;
        private System.Windows.Forms.CheckBox chkAncheSenzaSospesi;
        private System.Windows.Forms.Button btnCreaIncassiFatture;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labNFlussoIncassi;
        private System.Windows.Forms.TextBox txtNumFlussoIncassi;
        private System.Windows.Forms.Button btnSospesiRFSRFB;
        private System.Windows.Forms.TextBox txtStopFlusso;
        private System.Windows.Forms.TextBox txtStartFlusso;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar pBar;
		private System.Windows.Forms.Label labPBar;
	}
}
