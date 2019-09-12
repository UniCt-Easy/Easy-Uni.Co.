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

ï»¿namespace GeneraLiveUpdateForServices {
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
            this.gboxTipoAggiornamento = new System.Windows.Forms.GroupBox();
            this.radMultiSdi = new System.Windows.Forms.RadioButton();
            this.radio_Dummy = new System.Windows.Forms.RadioButton();
            this.radio_Payment = new System.Windows.Forms.RadioButton();
            this.radio_Portale = new System.Windows.Forms.RadioButton();
            this.radio_WebProt = new System.Windows.Forms.RadioButton();
            this.radio_EasyWeb = new System.Windows.Forms.RadioButton();
            this.radio_ReportingServices = new System.Windows.Forms.RadioButton();
            this.radio_sdi = new System.Windows.Forms.RadioButton();
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
            this.gboxCartelle = new System.Windows.Forms.GroupBox();
            this.btnDirMultiSdi = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLocal_MultiSDI = new System.Windows.Forms.TextBox();
            this.btnDirPayment = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLocal_Payment = new System.Windows.Forms.TextBox();
            this.btnDirPortale = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.txtLocal_Portale = new System.Windows.Forms.TextBox();
            this.btnDirWebProt = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txtLocal_WebProt = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnDirDLL_Easyweb = new System.Windows.Forms.Button();
            this.txtLocal_Easyweb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDirReport = new System.Windows.Forms.Button();
            this.txtLocal_RS = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDirDLL_sdi = new System.Windows.Forms.Button();
            this.txtLocal_sdi = new System.Windows.Forms.TextBox();
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
            this.gboxTipoAggiornamento.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gboxCartelle.SuspendLayout();
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
            this.tabPage1.Controls.Add(this.gboxTipoAggiornamento);
            this.tabPage1.Controls.Add(this.btnSync);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.btnCopia);
            this.tabPage1.Controls.Add(this.btnDiff);
            this.tabPage1.Controls.Add(this.gboxCartelle);
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
            // txtDirUff_main
            // 
            this.txtDirUff_main.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirUff_main.Location = new System.Drawing.Point(119, 188);
            this.txtDirUff_main.Name = "txtDirUff_main";
            this.txtDirUff_main.ReadOnly = true;
            this.txtDirUff_main.Size = new System.Drawing.Size(393, 20);
            this.txtDirUff_main.TabIndex = 51;
            // 
            // txtWeb_main
            // 
            this.txtWeb_main.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWeb_main.Location = new System.Drawing.Point(119, 162);
            this.txtWeb_main.Name = "txtWeb_main";
            this.txtWeb_main.Size = new System.Drawing.Size(393, 20);
            this.txtWeb_main.TabIndex = 49;
            // 
            // btnDirUff_main
            // 
            this.btnDirUff_main.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDirUff_main.Location = new System.Drawing.Point(518, 187);
            this.btnDirUff_main.Name = "btnDirUff_main";
            this.btnDirUff_main.Size = new System.Drawing.Size(24, 23);
            this.btnDirUff_main.TabIndex = 52;
            this.btnDirUff_main.Text = "...";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(7, 189);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(106, 19);
            this.label17.TabIndex = 50;
            this.label17.Text = "Cartella ufficiale";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(10, 163);
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
            this.txtDirDiff.Location = new System.Drawing.Point(119, 133);
            this.txtDirDiff.Name = "txtDirDiff";
            this.txtDirDiff.ReadOnly = true;
            this.txtDirDiff.Size = new System.Drawing.Size(393, 20);
            this.txtDirDiff.TabIndex = 34;
            // 
            // btnDirTemp
            // 
            this.btnDirTemp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDirTemp.Location = new System.Drawing.Point(520, 133);
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
            this.label2.Location = new System.Drawing.Point(9, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Cartella temporanea";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkFiltraGiornalieri
            // 
            this.chkFiltraGiornalieri.AutoSize = true;
            this.chkFiltraGiornalieri.Location = new System.Drawing.Point(119, 249);
            this.chkFiltraGiornalieri.Name = "chkFiltraGiornalieri";
            this.chkFiltraGiornalieri.Size = new System.Drawing.Size(98, 17);
            this.chkFiltraGiornalieri.TabIndex = 40;
            this.chkFiltraGiornalieri.Text = "Filtra file di oggi";
            this.chkFiltraGiornalieri.UseVisualStyleBackColor = true;
            this.chkFiltraGiornalieri.Visible = false;
            // 
            // gboxTipoAggiornamento
            // 
            this.gboxTipoAggiornamento.Controls.Add(this.radMultiSdi);
            this.gboxTipoAggiornamento.Controls.Add(this.radio_Dummy);
            this.gboxTipoAggiornamento.Controls.Add(this.radio_Payment);
            this.gboxTipoAggiornamento.Controls.Add(this.radio_Portale);
            this.gboxTipoAggiornamento.Controls.Add(this.radio_WebProt);
            this.gboxTipoAggiornamento.Controls.Add(this.radio_EasyWeb);
            this.gboxTipoAggiornamento.Controls.Add(this.radio_ReportingServices);
            this.gboxTipoAggiornamento.Controls.Add(this.radio_sdi);
            this.gboxTipoAggiornamento.Location = new System.Drawing.Point(6, 6);
            this.gboxTipoAggiornamento.Name = "gboxTipoAggiornamento";
            this.gboxTipoAggiornamento.Size = new System.Drawing.Size(538, 104);
            this.gboxTipoAggiornamento.TabIndex = 16;
            this.gboxTipoAggiornamento.TabStop = false;
            this.gboxTipoAggiornamento.Text = "Tipo di aggiornamento";
            // 
            // radMultiSdi
            // 
            this.radMultiSdi.Location = new System.Drawing.Point(361, 21);
            this.radMultiSdi.Name = "radMultiSdi";
            this.radMultiSdi.Size = new System.Drawing.Size(145, 23);
            this.radMultiSdi.TabIndex = 7;
            this.radMultiSdi.Tag = "multisdi";
            this.radMultiSdi.Text = "MultiSdi";
            // 
            // radio_Dummy
            // 
            this.radio_Dummy.Checked = true;
            this.radio_Dummy.Location = new System.Drawing.Point(361, 69);
            this.radio_Dummy.Name = "radio_Dummy";
            this.radio_Dummy.Size = new System.Drawing.Size(145, 23);
            this.radio_Dummy.TabIndex = 6;
            this.radio_Dummy.TabStop = true;
            this.radio_Dummy.Text = "dummy";
            // 
            // radio_Payment
            // 
            this.radio_Payment.Location = new System.Drawing.Point(180, 73);
            this.radio_Payment.Name = "radio_Payment";
            this.radio_Payment.Size = new System.Drawing.Size(155, 19);
            this.radio_Payment.TabIndex = 5;
            this.radio_Payment.Tag = "payment";
            this.radio_Payment.Text = "Servizio Pagamenti";
            // 
            // radio_Portale
            // 
            this.radio_Portale.Location = new System.Drawing.Point(180, 44);
            this.radio_Portale.Name = "radio_Portale";
            this.radio_Portale.Size = new System.Drawing.Size(160, 19);
            this.radio_Portale.TabIndex = 4;
            this.radio_Portale.Tag = "portale";
            this.radio_Portale.Text = "Portale";
            // 
            // radio_WebProt
            // 
            this.radio_WebProt.Location = new System.Drawing.Point(180, 18);
            this.radio_WebProt.Name = "radio_WebProt";
            this.radio_WebProt.Size = new System.Drawing.Size(145, 23);
            this.radio_WebProt.TabIndex = 3;
            this.radio_WebProt.Tag = "webprot";
            this.radio_WebProt.Text = "WebProt";
            // 
            // radio_EasyWeb
            // 
            this.radio_EasyWeb.Location = new System.Drawing.Point(6, 47);
            this.radio_EasyWeb.Name = "radio_EasyWeb";
            this.radio_EasyWeb.Size = new System.Drawing.Size(145, 19);
            this.radio_EasyWeb.TabIndex = 2;
            this.radio_EasyWeb.Tag = "easyweb";
            this.radio_EasyWeb.Text = "Easy WEB";
            // 
            // radio_ReportingServices
            // 
            this.radio_ReportingServices.Location = new System.Drawing.Point(6, 72);
            this.radio_ReportingServices.Name = "radio_ReportingServices";
            this.radio_ReportingServices.Size = new System.Drawing.Size(154, 24);
            this.radio_ReportingServices.TabIndex = 1;
            this.radio_ReportingServices.Tag = "reportingservices";
            this.radio_ReportingServices.Text = "Reporting Services (RDL)";
            // 
            // radio_sdi
            // 
            this.radio_sdi.Location = new System.Drawing.Point(6, 21);
            this.radio_sdi.Name = "radio_sdi";
            this.radio_sdi.Size = new System.Drawing.Size(145, 23);
            this.radio_sdi.TabIndex = 0;
            this.radio_sdi.Tag = "sdi";
            this.radio_sdi.Text = "SDI";
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
            this.btnDiff.Location = new System.Drawing.Point(6, 242);
            this.btnDiff.Name = "btnDiff";
            this.btnDiff.Size = new System.Drawing.Size(104, 24);
            this.btnDiff.TabIndex = 20;
            this.btnDiff.Text = "Genera differenze";
            this.btnDiff.Click += new System.EventHandler(this.btnDiff_Click);
            // 
            // gboxCartelle
            // 
            this.gboxCartelle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxCartelle.Controls.Add(this.btnDirMultiSdi);
            this.gboxCartelle.Controls.Add(this.label3);
            this.gboxCartelle.Controls.Add(this.txtLocal_MultiSDI);
            this.gboxCartelle.Controls.Add(this.btnDirPayment);
            this.gboxCartelle.Controls.Add(this.label1);
            this.gboxCartelle.Controls.Add(this.txtLocal_Payment);
            this.gboxCartelle.Controls.Add(this.btnDirPortale);
            this.gboxCartelle.Controls.Add(this.label16);
            this.gboxCartelle.Controls.Add(this.txtLocal_Portale);
            this.gboxCartelle.Controls.Add(this.btnDirWebProt);
            this.gboxCartelle.Controls.Add(this.label15);
            this.gboxCartelle.Controls.Add(this.txtLocal_WebProt);
            this.gboxCartelle.Controls.Add(this.label12);
            this.gboxCartelle.Controls.Add(this.btnDirDLL_Easyweb);
            this.gboxCartelle.Controls.Add(this.txtLocal_Easyweb);
            this.gboxCartelle.Controls.Add(this.label5);
            this.gboxCartelle.Controls.Add(this.btnDirReport);
            this.gboxCartelle.Controls.Add(this.txtLocal_RS);
            this.gboxCartelle.Controls.Add(this.label4);
            this.gboxCartelle.Controls.Add(this.btnDirDLL_sdi);
            this.gboxCartelle.Controls.Add(this.txtLocal_sdi);
            this.gboxCartelle.Location = new System.Drawing.Point(570, 6);
            this.gboxCartelle.Name = "gboxCartelle";
            this.gboxCartelle.Size = new System.Drawing.Size(670, 233);
            this.gboxCartelle.TabIndex = 37;
            this.gboxCartelle.TabStop = false;
            this.gboxCartelle.Text = "Cartelle di riferimento";
            // 
            // btnDirMultiSdi
            // 
            this.btnDirMultiSdi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDirMultiSdi.Location = new System.Drawing.Point(638, 183);
            this.btnDirMultiSdi.Name = "btnDirMultiSdi";
            this.btnDirMultiSdi.Size = new System.Drawing.Size(24, 23);
            this.btnDirMultiSdi.TabIndex = 40;
            this.btnDirMultiSdi.Tag = "multisdi";
            this.btnDirMultiSdi.Text = "...";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 18);
            this.label3.TabIndex = 39;
            this.label3.Text = "Servizio MultiSdi";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLocal_MultiSDI
            // 
            this.txtLocal_MultiSDI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocal_MultiSDI.Location = new System.Drawing.Point(100, 186);
            this.txtLocal_MultiSDI.Name = "txtLocal_MultiSDI";
            this.txtLocal_MultiSDI.ReadOnly = true;
            this.txtLocal_MultiSDI.Size = new System.Drawing.Size(537, 20);
            this.txtLocal_MultiSDI.TabIndex = 38;
            this.txtLocal_MultiSDI.Tag = "multisdi";
            // 
            // btnDirPayment
            // 
            this.btnDirPayment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDirPayment.Location = new System.Drawing.Point(638, 155);
            this.btnDirPayment.Name = "btnDirPayment";
            this.btnDirPayment.Size = new System.Drawing.Size(24, 23);
            this.btnDirPayment.TabIndex = 37;
            this.btnDirPayment.Tag = "payment";
            this.btnDirPayment.Text = "...";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(19, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 18);
            this.label1.TabIndex = 36;
            this.label1.Text = "Servizio Pag.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLocal_Payment
            // 
            this.txtLocal_Payment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocal_Payment.Location = new System.Drawing.Point(100, 158);
            this.txtLocal_Payment.Name = "txtLocal_Payment";
            this.txtLocal_Payment.ReadOnly = true;
            this.txtLocal_Payment.Size = new System.Drawing.Size(537, 20);
            this.txtLocal_Payment.TabIndex = 35;
            this.txtLocal_Payment.Tag = "payment";
            // 
            // btnDirPortale
            // 
            this.btnDirPortale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDirPortale.Location = new System.Drawing.Point(638, 126);
            this.btnDirPortale.Name = "btnDirPortale";
            this.btnDirPortale.Size = new System.Drawing.Size(24, 23);
            this.btnDirPortale.TabIndex = 34;
            this.btnDirPortale.Tag = "portale";
            this.btnDirPortale.Text = "...";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(35, 129);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 18);
            this.label16.TabIndex = 33;
            this.label16.Text = "Portale";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLocal_Portale
            // 
            this.txtLocal_Portale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocal_Portale.Location = new System.Drawing.Point(100, 129);
            this.txtLocal_Portale.Name = "txtLocal_Portale";
            this.txtLocal_Portale.ReadOnly = true;
            this.txtLocal_Portale.Size = new System.Drawing.Size(537, 20);
            this.txtLocal_Portale.TabIndex = 32;
            this.txtLocal_Portale.Tag = "portale";
            // 
            // btnDirWebProt
            // 
            this.btnDirWebProt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDirWebProt.Location = new System.Drawing.Point(638, 97);
            this.btnDirWebProt.Name = "btnDirWebProt";
            this.btnDirWebProt.Size = new System.Drawing.Size(24, 23);
            this.btnDirWebProt.TabIndex = 31;
            this.btnDirWebProt.Tag = "webprot";
            this.btnDirWebProt.Text = "...";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(35, 100);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 18);
            this.label15.TabIndex = 30;
            this.label15.Text = "WebProt";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLocal_WebProt
            // 
            this.txtLocal_WebProt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocal_WebProt.Location = new System.Drawing.Point(100, 100);
            this.txtLocal_WebProt.Name = "txtLocal_WebProt";
            this.txtLocal_WebProt.ReadOnly = true;
            this.txtLocal_WebProt.Size = new System.Drawing.Size(537, 20);
            this.txtLocal_WebProt.TabIndex = 29;
            this.txtLocal_WebProt.Tag = "webprot";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(35, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 18);
            this.label12.TabIndex = 28;
            this.label12.Text = "EasyWeb";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnDirDLL_Easyweb
            // 
            this.btnDirDLL_Easyweb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDirDLL_Easyweb.Location = new System.Drawing.Point(638, 45);
            this.btnDirDLL_Easyweb.Name = "btnDirDLL_Easyweb";
            this.btnDirDLL_Easyweb.Size = new System.Drawing.Size(24, 23);
            this.btnDirDLL_Easyweb.TabIndex = 27;
            this.btnDirDLL_Easyweb.Tag = "easyweb";
            this.btnDirDLL_Easyweb.Text = "...";
            // 
            // txtLocal_Easyweb
            // 
            this.txtLocal_Easyweb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocal_Easyweb.Location = new System.Drawing.Point(101, 46);
            this.txtLocal_Easyweb.Name = "txtLocal_Easyweb";
            this.txtLocal_Easyweb.ReadOnly = true;
            this.txtLocal_Easyweb.Size = new System.Drawing.Size(537, 20);
            this.txtLocal_Easyweb.TabIndex = 26;
            this.txtLocal_Easyweb.Tag = "easyweb";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(19, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 18);
            this.label5.TabIndex = 25;
            this.label5.Text = "Reporting S.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnDirReport
            // 
            this.btnDirReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDirReport.Location = new System.Drawing.Point(638, 70);
            this.btnDirReport.Name = "btnDirReport";
            this.btnDirReport.Size = new System.Drawing.Size(24, 23);
            this.btnDirReport.TabIndex = 24;
            this.btnDirReport.Tag = "reportingservices";
            this.btnDirReport.Text = "...";
            // 
            // txtLocal_RS
            // 
            this.txtLocal_RS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocal_RS.Location = new System.Drawing.Point(100, 72);
            this.txtLocal_RS.Name = "txtLocal_RS";
            this.txtLocal_RS.ReadOnly = true;
            this.txtLocal_RS.Size = new System.Drawing.Size(537, 20);
            this.txtLocal_RS.TabIndex = 23;
            this.txtLocal_RS.Tag = "reportingservices";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(35, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 18);
            this.label4.TabIndex = 22;
            this.label4.Text = "SDI";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnDirDLL_sdi
            // 
            this.btnDirDLL_sdi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDirDLL_sdi.Location = new System.Drawing.Point(638, 21);
            this.btnDirDLL_sdi.Name = "btnDirDLL_sdi";
            this.btnDirDLL_sdi.Size = new System.Drawing.Size(24, 23);
            this.btnDirDLL_sdi.TabIndex = 21;
            this.btnDirDLL_sdi.Tag = "sdi";
            this.btnDirDLL_sdi.Text = "...";
            // 
            // txtLocal_sdi
            // 
            this.txtLocal_sdi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocal_sdi.Location = new System.Drawing.Point(101, 22);
            this.txtLocal_sdi.Name = "txtLocal_sdi";
            this.txtLocal_sdi.ReadOnly = true;
            this.txtLocal_sdi.Size = new System.Drawing.Size(537, 20);
            this.txtLocal_sdi.TabIndex = 20;
            this.txtLocal_sdi.Tag = "sdi";
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
            this.checkList.Location = new System.Drawing.Point(9, 271);
            this.checkList.Name = "checkList";
            this.checkList.Size = new System.Drawing.Size(1105, 349);
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
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.gboxTipoAggiornamento.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gboxCartelle.ResumeLayout(false);
            this.gboxCartelle.PerformLayout();
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
        private System.Windows.Forms.GroupBox gboxTipoAggiornamento;
        private System.Windows.Forms.RadioButton radio_ReportingServices;
        private System.Windows.Forms.RadioButton radio_sdi;
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
        private System.Windows.Forms.GroupBox gboxCartelle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDirReport;
        private System.Windows.Forms.TextBox txtLocal_RS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDirDLL_sdi;
        private System.Windows.Forms.TextBox txtLocal_sdi;
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
        private System.Windows.Forms.RadioButton radio_EasyWeb;
        private System.Windows.Forms.Label lblFileXML;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnDirDLL_Easyweb;
        private System.Windows.Forms.TextBox txtLocal_Easyweb;
        private System.Windows.Forms.Button btnDirPortale;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtLocal_Portale;
        private System.Windows.Forms.Button btnDirWebProt;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtLocal_WebProt;
        private System.Windows.Forms.RadioButton radio_Portale;
        private System.Windows.Forms.RadioButton radio_WebProt;
        private System.Windows.Forms.TextBox txtDirUff_main;
        private System.Windows.Forms.TextBox txtWeb_main;
        private System.Windows.Forms.Button btnDirUff_main;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnDirPayment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLocal_Payment;
        private System.Windows.Forms.RadioButton radio_Payment;
        private System.Windows.Forms.RadioButton radio_Dummy;
        private System.Windows.Forms.Button btnDirMultiSdi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLocal_MultiSDI;
        private System.Windows.Forms.RadioButton radMultiSdi;
    }
}