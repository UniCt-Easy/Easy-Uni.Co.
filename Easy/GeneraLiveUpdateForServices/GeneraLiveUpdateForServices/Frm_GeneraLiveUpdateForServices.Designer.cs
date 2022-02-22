
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


namespace GeneraLiveUpdateForServices {
    partial class Frm_GeneraLiveUpdateForServices {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        //private System.ComponentModel.IContainer components = null;

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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_GeneraLiveUpdateForServices));
			this.openFile = new System.Windows.Forms.OpenFileDialog();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuDescrizione = new System.Windows.Forms.ToolStripMenuItem();
			this.menuRinomina = new System.Windows.Forms.ToolStripMenuItem();
			this.menuElimina = new System.Windows.Forms.ToolStripMenuItem();
			this.icons = new System.Windows.Forms.ImageList(this.components);
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.cmbTipoAggiornamento = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtDirUff_main = new System.Windows.Forms.TextBox();
			this.txtWeb_main = new System.Windows.Forms.TextBox();
			this.btnDirUff_main = new System.Windows.Forms.Button();
			this.label17 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.txtDirDiff = new System.Windows.Forms.TextBox();
			this.btnDirTemp = new System.Windows.Forms.Button();
			this.lblFileXML = new System.Windows.Forms.Label();
			this.txtNThread = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.chkFiltraGiornalieri = new System.Windows.Forms.CheckBox();
			this.btnSync = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.btnCalcolaNuova = new System.Windows.Forms.Button();
			this.labNewVerSw = new System.Windows.Forms.Label();
			this.btnVersioni = new System.Windows.Forms.Button();
			this.txtVerSWNew = new System.Windows.Forms.TextBox();
			this.txtVerSWOld = new System.Windows.Forms.TextBox();
			this.labVersioneSW = new System.Windows.Forms.Label();
			this.btnCopia = new System.Windows.Forms.Button();
			this.btnDiff = new System.Windows.Forms.Button();
			this.chkSP = new System.Windows.Forms.CheckBox();
			this.btnXMLFile = new System.Windows.Forms.Button();
			this.lblNumero = new System.Windows.Forms.Label();
			this.btnDeselAll = new System.Windows.Forms.Button();
			this.btnSelAll = new System.Windows.Forms.Button();
			this.checkList = new System.Windows.Forms.CheckedListBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.nonaggiornati = new System.Windows.Forms.CheckedListBox();
			this.DS = new GeneraLiveUpdateForServices.genconfig();
			this.contextMenuStrip1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.tabPage3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// openFile
			// 
			this.openFile.DefaultExt = "sql";
			this.openFile.Filter = "File SQL|*.sql";
			this.openFile.Multiselect = true;
			this.openFile.Title = "Seleziona i file da inserire nel live update";
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDescrizione,
            this.menuRinomina,
            this.menuElimina});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(190, 70);
			// 
			// menuDescrizione
			// 
			this.menuDescrizione.Name = "menuDescrizione";
			this.menuDescrizione.Size = new System.Drawing.Size(189, 22);
			this.menuDescrizione.Text = "Cambia la descrizione";
			// 
			// menuRinomina
			// 
			this.menuRinomina.Name = "menuRinomina";
			this.menuRinomina.Size = new System.Drawing.Size(189, 22);
			this.menuRinomina.Text = "Rinomina";
			// 
			// menuElimina
			// 
			this.menuElimina.Name = "menuElimina";
			this.menuElimina.Size = new System.Drawing.Size(189, 22);
			this.menuElimina.Text = "Elimina";
			// 
			// icons
			// 
			this.icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icons.ImageStream")));
			this.icons.TransparentColor = System.Drawing.Color.Transparent;
			this.icons.Images.SetKeyName(0, "");
			this.icons.Images.SetKeyName(1, "");
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1254, 797);
			this.tabControl1.TabIndex = 42;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.cmbTipoAggiornamento);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.txtDirUff_main);
			this.tabPage1.Controls.Add(this.txtWeb_main);
			this.tabPage1.Controls.Add(this.btnDirUff_main);
			this.tabPage1.Controls.Add(this.label17);
			this.tabPage1.Controls.Add(this.label18);
			this.tabPage1.Controls.Add(this.txtDirDiff);
			this.tabPage1.Controls.Add(this.btnDirTemp);
			this.tabPage1.Controls.Add(this.lblFileXML);
			this.tabPage1.Controls.Add(this.txtNThread);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.chkFiltraGiornalieri);
			this.tabPage1.Controls.Add(this.btnSync);
			this.tabPage1.Controls.Add(this.groupBox3);
			this.tabPage1.Controls.Add(this.btnCopia);
			this.tabPage1.Controls.Add(this.btnDiff);
			this.tabPage1.Controls.Add(this.chkSP);
			this.tabPage1.Controls.Add(this.btnXMLFile);
			this.tabPage1.Controls.Add(this.lblNumero);
			this.tabPage1.Controls.Add(this.btnDeselAll);
			this.tabPage1.Controls.Add(this.btnSelAll);
			this.tabPage1.Controls.Add(this.checkList);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(1246, 771);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "DLL/Report";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// cmbTipoAggiornamento
			// 
			this.cmbTipoAggiornamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTipoAggiornamento.FormattingEnabled = true;
			this.cmbTipoAggiornamento.Location = new System.Drawing.Point(13, 32);
			this.cmbTipoAggiornamento.Name = "cmbTipoAggiornamento";
			this.cmbTipoAggiornamento.Size = new System.Drawing.Size(499, 21);
			this.cmbTipoAggiornamento.TabIndex = 54;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 13);
			this.label1.TabIndex = 53;
			this.label1.Text = "Tipo di aggiornamento";
			// 
			// txtDirUff_main
			// 
			this.txtDirUff_main.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDirUff_main.Location = new System.Drawing.Point(120, 120);
			this.txtDirUff_main.Name = "txtDirUff_main";
			this.txtDirUff_main.ReadOnly = true;
			this.txtDirUff_main.Size = new System.Drawing.Size(393, 20);
			this.txtDirUff_main.TabIndex = 51;
			// 
			// txtWeb_main
			// 
			this.txtWeb_main.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtWeb_main.Location = new System.Drawing.Point(120, 94);
			this.txtWeb_main.Name = "txtWeb_main";
			this.txtWeb_main.Size = new System.Drawing.Size(393, 20);
			this.txtWeb_main.TabIndex = 49;
			// 
			// btnDirUff_main
			// 
			this.btnDirUff_main.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDirUff_main.Location = new System.Drawing.Point(519, 119);
			this.btnDirUff_main.Name = "btnDirUff_main";
			this.btnDirUff_main.Size = new System.Drawing.Size(24, 23);
			this.btnDirUff_main.TabIndex = 52;
			this.btnDirUff_main.Text = "...";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(8, 121);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(106, 19);
			this.label17.TabIndex = 50;
			this.label17.Text = "Cartella ufficiale";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(11, 95);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(106, 19);
			this.label18.TabIndex = 48;
			this.label18.Text = "Indirizzo web";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDirDiff
			// 
			this.txtDirDiff.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDirDiff.Location = new System.Drawing.Point(120, 65);
			this.txtDirDiff.Name = "txtDirDiff";
			this.txtDirDiff.ReadOnly = true;
			this.txtDirDiff.Size = new System.Drawing.Size(393, 20);
			this.txtDirDiff.TabIndex = 34;
			// 
			// btnDirTemp
			// 
			this.btnDirTemp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDirTemp.Location = new System.Drawing.Point(521, 65);
			this.btnDirTemp.Name = "btnDirTemp";
			this.btnDirTemp.Size = new System.Drawing.Size(24, 23);
			this.btnDirTemp.TabIndex = 35;
			this.btnDirTemp.Text = "...";
			this.btnDirTemp.Click += new System.EventHandler(this.btnDirTemp_Click);
			// 
			// lblFileXML
			// 
			this.lblFileXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblFileXML.Location = new System.Drawing.Point(389, 657);
			this.lblFileXML.Name = "lblFileXML";
			this.lblFileXML.Size = new System.Drawing.Size(320, 12);
			this.lblFileXML.TabIndex = 42;
			// 
			// txtNThread
			// 
			this.txtNThread.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtNThread.Location = new System.Drawing.Point(1120, 627);
			this.txtNThread.Name = "txtNThread";
			this.txtNThread.ReadOnly = true;
			this.txtNThread.Size = new System.Drawing.Size(100, 20);
			this.txtNThread.TabIndex = 41;
			this.txtNThread.Visible = false;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(10, 65);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(107, 15);
			this.label2.TabIndex = 9;
			this.label2.Text = "Cartella temporanea";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// chkFiltraGiornalieri
			// 
			this.chkFiltraGiornalieri.AutoSize = true;
			this.chkFiltraGiornalieri.Location = new System.Drawing.Point(126, 166);
			this.chkFiltraGiornalieri.Name = "chkFiltraGiornalieri";
			this.chkFiltraGiornalieri.Size = new System.Drawing.Size(98, 17);
			this.chkFiltraGiornalieri.TabIndex = 40;
			this.chkFiltraGiornalieri.Text = "Filtra file di oggi";
			this.chkFiltraGiornalieri.UseVisualStyleBackColor = true;
			this.chkFiltraGiornalieri.Visible = false;
			// 
			// btnSync
			// 
			this.btnSync.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSync.Location = new System.Drawing.Point(1120, 719);
			this.btnSync.Name = "btnSync";
			this.btnSync.Size = new System.Drawing.Size(120, 24);
			this.btnSync.TabIndex = 38;
			this.btnSync.Text = "Lancia SYNC Tool";
			this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.btnCalcolaNuova);
			this.groupBox3.Controls.Add(this.labNewVerSw);
			this.groupBox3.Controls.Add(this.btnVersioni);
			this.groupBox3.Controls.Add(this.txtVerSWNew);
			this.groupBox3.Controls.Add(this.txtVerSWOld);
			this.groupBox3.Controls.Add(this.labVersioneSW);
			this.groupBox3.Location = new System.Drawing.Point(4, 683);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(1106, 80);
			this.groupBox3.TabIndex = 39;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Aggiornamento versioni";
			// 
			// btnCalcolaNuova
			// 
			this.btnCalcolaNuova.Location = new System.Drawing.Point(398, 19);
			this.btnCalcolaNuova.Name = "btnCalcolaNuova";
			this.btnCalcolaNuova.Size = new System.Drawing.Size(135, 23);
			this.btnCalcolaNuova.TabIndex = 9;
			this.btnCalcolaNuova.Text = "Calcola Nuova versione";
			this.btnCalcolaNuova.Visible = false;
			this.btnCalcolaNuova.Click += new System.EventHandler(this.btnCalcolaNuova_Click);
			// 
			// labNewVerSw
			// 
			this.labNewVerSw.Location = new System.Drawing.Point(254, 24);
			this.labNewVerSw.Name = "labNewVerSw";
			this.labNewVerSw.Size = new System.Drawing.Size(44, 16);
			this.labNewVerSw.TabIndex = 7;
			this.labNewVerSw.Text = "Nuova";
			this.labNewVerSw.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnVersioni
			// 
			this.btnVersioni.Location = new System.Drawing.Point(398, 44);
			this.btnVersioni.Name = "btnVersioni";
			this.btnVersioni.Size = new System.Drawing.Size(135, 23);
			this.btnVersioni.TabIndex = 6;
			this.btnVersioni.Text = "Aggiorna versioni";
			this.btnVersioni.Visible = false;
			this.btnVersioni.Click += new System.EventHandler(this.btnVersioni_Click);
			// 
			// txtVerSWNew
			// 
			this.txtVerSWNew.Location = new System.Drawing.Point(304, 22);
			this.txtVerSWNew.Name = "txtVerSWNew";
			this.txtVerSWNew.ReadOnly = true;
			this.txtVerSWNew.Size = new System.Drawing.Size(64, 20);
			this.txtVerSWNew.TabIndex = 2;
			this.txtVerSWNew.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtVerSWOld
			// 
			this.txtVerSWOld.Location = new System.Drawing.Point(168, 22);
			this.txtVerSWOld.Name = "txtVerSWOld";
			this.txtVerSWOld.ReadOnly = true;
			this.txtVerSWOld.Size = new System.Drawing.Size(64, 20);
			this.txtVerSWOld.TabIndex = 1;
			this.txtVerSWOld.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// labVersioneSW
			// 
			this.labVersioneSW.Location = new System.Drawing.Point(24, 24);
			this.labVersioneSW.Name = "labVersioneSW";
			this.labVersioneSW.Size = new System.Drawing.Size(138, 16);
			this.labVersioneSW.TabIndex = 0;
			this.labVersioneSW.Text = "Versione corrente Servizio";
			this.labVersioneSW.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnCopia
			// 
			this.btnCopia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCopia.ForeColor = System.Drawing.Color.Red;
			this.btnCopia.Location = new System.Drawing.Point(1120, 687);
			this.btnCopia.Name = "btnCopia";
			this.btnCopia.Size = new System.Drawing.Size(120, 24);
			this.btnCopia.TabIndex = 36;
			this.btnCopia.Text = "Copia i File generati";
			this.btnCopia.Visible = false;
			this.btnCopia.Click += new System.EventHandler(this.btnCopia_Click);
			// 
			// btnDiff
			// 
			this.btnDiff.Location = new System.Drawing.Point(13, 159);
			this.btnDiff.Name = "btnDiff";
			this.btnDiff.Size = new System.Drawing.Size(104, 24);
			this.btnDiff.TabIndex = 20;
			this.btnDiff.Text = "Genera differenze";
			this.btnDiff.Click += new System.EventHandler(this.btnDiff_Click);
			// 
			// chkSP
			// 
			this.chkSP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chkSP.Location = new System.Drawing.Point(111, 658);
			this.chkSP.Name = "chkSP";
			this.chkSP.Size = new System.Drawing.Size(320, 16);
			this.chkSP.TabIndex = 29;
			this.chkSP.Text = "Includi generazione index stored procedure dei report";
			this.chkSP.Visible = false;
			// 
			// btnXMLFile
			// 
			this.btnXMLFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnXMLFile.Location = new System.Drawing.Point(6, 651);
			this.btnXMLFile.Name = "btnXMLFile";
			this.btnXMLFile.Size = new System.Drawing.Size(96, 24);
			this.btnXMLFile.TabIndex = 21;
			this.btnXMLFile.Text = "Genera file XML";
			this.btnXMLFile.Visible = false;
			this.btnXMLFile.Click += new System.EventHandler(this.btnXMLFile_Click);
			// 
			// lblNumero
			// 
			this.lblNumero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblNumero.Location = new System.Drawing.Point(1120, 498);
			this.lblNumero.Name = "lblNumero";
			this.lblNumero.Size = new System.Drawing.Size(88, 56);
			this.lblNumero.TabIndex = 27;
			// 
			// btnDeselAll
			// 
			this.btnDeselAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDeselAll.Location = new System.Drawing.Point(1120, 463);
			this.btnDeselAll.Name = "btnDeselAll";
			this.btnDeselAll.Size = new System.Drawing.Size(112, 32);
			this.btnDeselAll.TabIndex = 26;
			this.btnDeselAll.Text = "Deseleziona tutto";
			this.btnDeselAll.Click += new System.EventHandler(this.btnDeselAll_Click);
			// 
			// btnSelAll
			// 
			this.btnSelAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSelAll.Location = new System.Drawing.Point(1120, 421);
			this.btnSelAll.Name = "btnSelAll";
			this.btnSelAll.Size = new System.Drawing.Size(112, 32);
			this.btnSelAll.TabIndex = 25;
			this.btnSelAll.Text = "Seleziona tutto";
			this.btnSelAll.Click += new System.EventHandler(this.btnSelAll_Click);
			// 
			// checkList
			// 
			this.checkList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.checkList.CheckOnClick = true;
			this.checkList.Location = new System.Drawing.Point(9, 196);
			this.checkList.Name = "checkList";
			this.checkList.Size = new System.Drawing.Size(1105, 424);
			this.checkList.Sorted = true;
			this.checkList.TabIndex = 24;
			this.checkList.ThreeDCheckBoxes = true;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.nonaggiornati);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(1246, 771);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Meno aggiornati del sito";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// nonaggiornati
			// 
			this.nonaggiornati.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.nonaggiornati.CheckOnClick = true;
			this.nonaggiornati.Location = new System.Drawing.Point(8, 24);
			this.nonaggiornati.Name = "nonaggiornati";
			this.nonaggiornati.Size = new System.Drawing.Size(538, 484);
			this.nonaggiornati.Sorted = true;
			this.nonaggiornati.TabIndex = 25;
			this.nonaggiornati.ThreeDCheckBoxes = true;
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaform";
			// 
			// Frm_GeneraLiveUpdateForServices
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1254, 797);
			this.Controls.Add(this.tabControl1);
			this.Name = "Frm_GeneraLiveUpdateForServices";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Live Update for Services- Generazione ";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmGeneraLiveUpdateForService_Closing);
			this.contextMenuStrip1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private genconfig DS;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuDescrizione;
        private System.Windows.Forms.ToolStripMenuItem menuRinomina;
        private System.Windows.Forms.ToolStripMenuItem menuElimina;
        private System.Windows.Forms.ImageList icons;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox chkFiltraGiornalieri;
        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCalcolaNuova;
        private System.Windows.Forms.Label labNewVerSw;
        private System.Windows.Forms.Button btnVersioni;
        private System.Windows.Forms.TextBox txtVerSWNew;
        private System.Windows.Forms.TextBox txtVerSWOld;
        private System.Windows.Forms.Label labVersioneSW;
        private System.Windows.Forms.Button btnCopia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDiff;
        private System.Windows.Forms.CheckBox chkSP;
        private System.Windows.Forms.Button btnXMLFile;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Button btnDeselAll;
        private System.Windows.Forms.Button btnDirTemp;
        private System.Windows.Forms.Button btnSelAll;
        private System.Windows.Forms.CheckedListBox checkList;
        private System.Windows.Forms.TextBox txtDirDiff;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckedListBox nonaggiornati;
        private System.Windows.Forms.TextBox txtNThread;
        private System.Windows.Forms.Label lblFileXML;
        private System.Windows.Forms.TextBox txtDirUff_main;
        private System.Windows.Forms.TextBox txtWeb_main;
        private System.Windows.Forms.Button btnDirUff_main;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
		private System.Windows.Forms.ComboBox cmbTipoAggiornamento;
		private System.Windows.Forms.Label label1;
	}
}
