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
namespace no_table_dumpdocanagrafica {
    partial class Frm_dumpdocanagrafica {
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
            this.DS = new no_table_dumpdocanagrafica.vistaForm();
            this.gboxInfo = new System.Windows.Forms.GroupBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.gboxExcel = new System.Windows.Forms.GroupBox();
            this.btnSelezionaExcel = new System.Windows.Forms.Button();
            this.txtExcelFile = new System.Windows.Forms.TextBox();
            this.gboxFolder = new System.Windows.Forms.GroupBox();
            this.btnSelezionaZip = new System.Windows.Forms.Button();
            this.txtZipFile = new System.Windows.Forms.TextBox();
            this.gboxTabelle = new System.Windows.Forms.GroupBox();
            this.chkCv = new System.Windows.Forms.CheckBox();
            this.chkAllegati = new System.Windows.Forms.CheckBox();
            this.chkVisure = new System.Windows.Forms.CheckBox();
            this.chkCasellarioGiud = new System.Windows.Forms.CheckBox();
            this.chkCasellarioAmm = new System.Windows.Forms.CheckBox();
            this.chkOttemperanza = new System.Windows.Forms.CheckBox();
            this.chkRegolaritaFiscale = new System.Windows.Forms.CheckBox();
            this.chkVerificaAnac = new System.Windows.Forms.CheckBox();
            this.chkPattoIntegrita = new System.Windows.Forms.CheckBox();
            this.chkDurc = new System.Windows.Forms.CheckBox();
            this.chkPayMethod = new System.Windows.Forms.CheckBox();
            this.chkPayMethodAttach = new System.Windows.Forms.CheckBox();
            this.btnSelezionaTutto = new System.Windows.Forms.Button();
            this.btnDeselezionaTutto = new System.Windows.Forms.Button();
            this.gboxStruttura = new System.Windows.Forms.GroupBox();
            this.rbStructRegistry = new System.Windows.Forms.RadioButton();
            this.rbStructType = new System.Windows.Forms.RadioButton();
            this.btnEseguiDownload = new System.Windows.Forms.Button();
            this.btnInterrompi = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this._saveZipDlg = new System.Windows.Forms.SaveFileDialog();
            this._openExcelDlg = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.gboxInfo.SuspendLayout();
            this.gboxExcel.SuspendLayout();
            this.gboxFolder.SuspendLayout();
            this.gboxTabelle.SuspendLayout();
            this.gboxStruttura.SuspendLayout();
            this.SuspendLayout();
            //
            // DS
            //
            this.DS.DataSetName = "vistaForm";
            //
            // gboxInfo
            //
            this.gboxInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxInfo.Controls.Add(this.lblInfo);
            this.gboxInfo.Location = new System.Drawing.Point(12, 12);
            this.gboxInfo.Name = "gboxInfo";
            this.gboxInfo.Size = new System.Drawing.Size(696, 70);
            this.gboxInfo.TabIndex = 0;
            this.gboxInfo.TabStop = false;
            //
            // lblInfo
            //
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.Location = new System.Drawing.Point(15, 17);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(672, 45);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "La procedura legge un file Excel con le colonne \"Denominazione\" e \"Codice\" (il c" +
                "ampo Codice contiene l\'idreg dell\'anagrafica) e salva in un singolo archivio ZIP" +
                " tutti gli allegati delle tabelle figlie dell\'anagrafica.";
            //
            // gboxExcel
            //
            this.gboxExcel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxExcel.Controls.Add(this.btnSelezionaExcel);
            this.gboxExcel.Controls.Add(this.txtExcelFile);
            this.gboxExcel.Location = new System.Drawing.Point(12, 90);
            this.gboxExcel.Name = "gboxExcel";
            this.gboxExcel.Size = new System.Drawing.Size(696, 90);
            this.gboxExcel.TabIndex = 1;
            this.gboxExcel.TabStop = false;
            this.gboxExcel.Text = "File Excel anagrafiche (colonne: Denominazione, Codice)";
            //
            // btnSelezionaExcel
            //
            this.btnSelezionaExcel.Location = new System.Drawing.Point(15, 22);
            this.btnSelezionaExcel.Name = "btnSelezionaExcel";
            this.btnSelezionaExcel.Size = new System.Drawing.Size(140, 23);
            this.btnSelezionaExcel.TabIndex = 0;
            this.btnSelezionaExcel.Text = "Seleziona file Excel";
            this.btnSelezionaExcel.UseVisualStyleBackColor = true;
            this.btnSelezionaExcel.Click += new System.EventHandler(this.btnSelezionaExcel_Click);
            //
            // txtExcelFile
            //
            this.txtExcelFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExcelFile.Location = new System.Drawing.Point(15, 55);
            this.txtExcelFile.Name = "txtExcelFile";
            this.txtExcelFile.ReadOnly = true;
            this.txtExcelFile.Size = new System.Drawing.Size(665, 20);
            this.txtExcelFile.TabIndex = 1;
            //
            // gboxFolder
            //
            this.gboxFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxFolder.Controls.Add(this.btnSelezionaZip);
            this.gboxFolder.Controls.Add(this.txtZipFile);
            this.gboxFolder.Location = new System.Drawing.Point(12, 190);
            this.gboxFolder.Name = "gboxFolder";
            this.gboxFolder.Size = new System.Drawing.Size(696, 90);
            this.gboxFolder.TabIndex = 2;
            this.gboxFolder.TabStop = false;
            this.gboxFolder.Text = "Archivio ZIP di destinazione";
            //
            // btnSelezionaZip
            //
            this.btnSelezionaZip.Location = new System.Drawing.Point(15, 22);
            this.btnSelezionaZip.Name = "btnSelezionaZip";
            this.btnSelezionaZip.Size = new System.Drawing.Size(140, 23);
            this.btnSelezionaZip.TabIndex = 0;
            this.btnSelezionaZip.Text = "Seleziona archivio ZIP";
            this.btnSelezionaZip.UseVisualStyleBackColor = true;
            this.btnSelezionaZip.Click += new System.EventHandler(this.btnSelezionaZip_Click);
            //
            // txtZipFile
            //
            this.txtZipFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.txtZipFile.Location = new System.Drawing.Point(15, 55);
            this.txtZipFile.Name = "txtZipFile";
            this.txtZipFile.Size = new System.Drawing.Size(665, 20);
            this.txtZipFile.TabIndex = 1;
            //
            // gboxTabelle
            //
            this.gboxTabelle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxTabelle.Controls.Add(this.chkCv);
            this.gboxTabelle.Controls.Add(this.chkAllegati);
            this.gboxTabelle.Controls.Add(this.chkVisure);
            this.gboxTabelle.Controls.Add(this.chkCasellarioGiud);
            this.gboxTabelle.Controls.Add(this.chkCasellarioAmm);
            this.gboxTabelle.Controls.Add(this.chkOttemperanza);
            this.gboxTabelle.Controls.Add(this.chkRegolaritaFiscale);
            this.gboxTabelle.Controls.Add(this.chkVerificaAnac);
            this.gboxTabelle.Controls.Add(this.chkPattoIntegrita);
            this.gboxTabelle.Controls.Add(this.chkDurc);
            this.gboxTabelle.Controls.Add(this.chkPayMethod);
            this.gboxTabelle.Controls.Add(this.chkPayMethodAttach);
            this.gboxTabelle.Controls.Add(this.btnSelezionaTutto);
            this.gboxTabelle.Controls.Add(this.btnDeselezionaTutto);
            this.gboxTabelle.Location = new System.Drawing.Point(12, 290);
            this.gboxTabelle.Name = "gboxTabelle";
            this.gboxTabelle.Size = new System.Drawing.Size(696, 185);
            this.gboxTabelle.TabIndex = 3;
            this.gboxTabelle.TabStop = false;
            this.gboxTabelle.Text = "Tabelle da includere";
            //
            // chkCv
            //
            this.chkCv.ThreeState = false;
            this.chkCv.Location = new System.Drawing.Point(15, 22);
            this.chkCv.Name = "chkCv";
            this.chkCv.Size = new System.Drawing.Size(300, 17);
            this.chkCv.TabIndex = 0;
            this.chkCv.Tag = "";
            this.chkCv.Text = "CV";
            this.chkCv.UseVisualStyleBackColor = true;
            //
            // chkAllegati
            //
            this.chkAllegati.ThreeState = false;
            this.chkAllegati.Location = new System.Drawing.Point(15, 44);
            this.chkAllegati.Name = "chkAllegati";
            this.chkAllegati.Size = new System.Drawing.Size(300, 17);
            this.chkAllegati.TabIndex = 1;
            this.chkAllegati.Tag = "";
            this.chkAllegati.Text = "Allegati";
            this.chkAllegati.UseVisualStyleBackColor = true;
            //
            // chkVisure
            //
            this.chkVisure.ThreeState = false;
            this.chkVisure.Location = new System.Drawing.Point(15, 66);
            this.chkVisure.Name = "chkVisure";
            this.chkVisure.Size = new System.Drawing.Size(300, 17);
            this.chkVisure.TabIndex = 2;
            this.chkVisure.Tag = "";
            this.chkVisure.Text = "Visure";
            this.chkVisure.UseVisualStyleBackColor = true;
            //
            // chkCasellarioGiud
            //
            this.chkCasellarioGiud.ThreeState = false;
            this.chkCasellarioGiud.Location = new System.Drawing.Point(15, 88);
            this.chkCasellarioGiud.Name = "chkCasellarioGiud";
            this.chkCasellarioGiud.Size = new System.Drawing.Size(300, 17);
            this.chkCasellarioGiud.TabIndex = 3;
            this.chkCasellarioGiud.Tag = "";
            this.chkCasellarioGiud.Text = "Casellario Giudiziale";
            this.chkCasellarioGiud.UseVisualStyleBackColor = true;
            //
            // chkCasellarioAmm
            //
            this.chkCasellarioAmm.ThreeState = false;
            this.chkCasellarioAmm.Location = new System.Drawing.Point(15, 110);
            this.chkCasellarioAmm.Name = "chkCasellarioAmm";
            this.chkCasellarioAmm.Size = new System.Drawing.Size(300, 17);
            this.chkCasellarioAmm.TabIndex = 4;
            this.chkCasellarioAmm.Tag = "";
            this.chkCasellarioAmm.Text = "Casellario Amministrativo";
            this.chkCasellarioAmm.UseVisualStyleBackColor = true;
            //
            // chkOttemperanza
            //
            this.chkOttemperanza.ThreeState = false;
            this.chkOttemperanza.Location = new System.Drawing.Point(15, 132);
            this.chkOttemperanza.Name = "chkOttemperanza";
            this.chkOttemperanza.Size = new System.Drawing.Size(300, 17);
            this.chkOttemperanza.TabIndex = 5;
            this.chkOttemperanza.Tag = "";
            this.chkOttemperanza.Text = "Ottemperanza L.68/99";
            this.chkOttemperanza.UseVisualStyleBackColor = true;
            //
            // chkRegolaritaFiscale
            //
            this.chkRegolaritaFiscale.ThreeState = false;
            this.chkRegolaritaFiscale.Location = new System.Drawing.Point(330,22);
            this.chkRegolaritaFiscale.Name = "chkRegolaritaFiscale";
            this.chkRegolaritaFiscale.Size = new System.Drawing.Size(356, 17);
            this.chkRegolaritaFiscale.TabIndex = 6;
            this.chkRegolaritaFiscale.Tag = "";
            this.chkRegolaritaFiscale.Text = "Regolarità Fiscale";
            this.chkRegolaritaFiscale.UseVisualStyleBackColor = true;
            //
            // chkVerificaAnac
            //
            this.chkVerificaAnac.ThreeState = false;
            this.chkVerificaAnac.Location = new System.Drawing.Point(330,44);
            this.chkVerificaAnac.Name = "chkVerificaAnac";
            this.chkVerificaAnac.Size = new System.Drawing.Size(356, 17);
            this.chkVerificaAnac.TabIndex = 7;
            this.chkVerificaAnac.Tag = "";
            this.chkVerificaAnac.Text = "Verifica ANAC";
            this.chkVerificaAnac.UseVisualStyleBackColor = true;
            //
            // chkPattoIntegrita
            //
            this.chkPattoIntegrita.ThreeState = false;
            this.chkPattoIntegrita.Location = new System.Drawing.Point(330,66);
            this.chkPattoIntegrita.Name = "chkPattoIntegrita";
            this.chkPattoIntegrita.Size = new System.Drawing.Size(356, 17);
            this.chkPattoIntegrita.TabIndex = 8;
            this.chkPattoIntegrita.Tag = "";
            this.chkPattoIntegrita.Text = "Patto Integrità";
            this.chkPattoIntegrita.UseVisualStyleBackColor = true;
            //
            // chkDurc
            //
            this.chkDurc.ThreeState = false;
            this.chkDurc.Location = new System.Drawing.Point(330,88);
            this.chkDurc.Name = "chkDurc";
            this.chkDurc.Size = new System.Drawing.Size(356, 17);
            this.chkDurc.TabIndex = 9;
            this.chkDurc.Tag = "";
            this.chkDurc.Text = "DURC (certificato + autocertificazione)";
            this.chkDurc.UseVisualStyleBackColor = true;
            //
            // chkPayMethod
            //
            this.chkPayMethod.ThreeState = false;
            this.chkPayMethod.Location = new System.Drawing.Point(330,110);
            this.chkPayMethod.Name = "chkPayMethod";
            this.chkPayMethod.Size = new System.Drawing.Size(356, 17);
            this.chkPayMethod.TabIndex = 10;
            this.chkPayMethod.Tag = "";
            this.chkPayMethod.Text = "Modalità Pagamento (c/c dedicato + doc. identità)";
            this.chkPayMethod.UseVisualStyleBackColor = true;
            //
            // chkPayMethodAttach
            //
            this.chkPayMethodAttach.ThreeState = false;
            this.chkPayMethodAttach.Location = new System.Drawing.Point(330,132);
            this.chkPayMethodAttach.Name = "chkPayMethodAttach";
            this.chkPayMethodAttach.Size = new System.Drawing.Size(356, 17);
            this.chkPayMethodAttach.TabIndex = 11;
            this.chkPayMethodAttach.Tag = "";
            this.chkPayMethodAttach.Text = "Modalità Pagamento - Allegati";
            this.chkPayMethodAttach.UseVisualStyleBackColor = true;
            //
            // btnSelezionaTutto
            //
            this.btnSelezionaTutto.Location = new System.Drawing.Point(15, 152);
            this.btnSelezionaTutto.Name = "btnSelezionaTutto";
            this.btnSelezionaTutto.Size = new System.Drawing.Size(120, 23);
            this.btnSelezionaTutto.TabIndex = 12;
            this.btnSelezionaTutto.Text = "Seleziona tutto";
            this.btnSelezionaTutto.UseVisualStyleBackColor = true;
            this.btnSelezionaTutto.Click += new System.EventHandler(this.btnSelezionaTutto_Click);
            //
            // btnDeselezionaTutto
            //
            this.btnDeselezionaTutto.Location = new System.Drawing.Point(145, 152);
            this.btnDeselezionaTutto.Name = "btnDeselezionaTutto";
            this.btnDeselezionaTutto.Size = new System.Drawing.Size(120, 23);
            this.btnDeselezionaTutto.TabIndex = 13;
            this.btnDeselezionaTutto.Text = "Deseleziona tutto";
            this.btnDeselezionaTutto.UseVisualStyleBackColor = true;
            this.btnDeselezionaTutto.Click += new System.EventHandler(this.btnDeselezionaTutto_Click);
            //
            // gboxStruttura
            //
            this.gboxStruttura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxStruttura.Controls.Add(this.rbStructRegistry);
            this.gboxStruttura.Controls.Add(this.rbStructType);
            this.gboxStruttura.Location = new System.Drawing.Point(12, 481);
            this.gboxStruttura.Name = "gboxStruttura";
            this.gboxStruttura.Size = new System.Drawing.Size(696, 52);
            this.gboxStruttura.TabIndex = 4;
            this.gboxStruttura.TabStop = false;
            this.gboxStruttura.Text = "Struttura delle cartelle nell\'archivio";
            //
            // rbStructRegistry
            //
            this.rbStructRegistry.Checked = true;
            this.rbStructRegistry.Location = new System.Drawing.Point(15, 22);
            this.rbStructRegistry.Name = "rbStructRegistry";
            this.rbStructRegistry.Size = new System.Drawing.Size(330, 17);
            this.rbStructRegistry.TabIndex = 0;
            this.rbStructRegistry.TabStop = true;
            this.rbStructRegistry.Tag = "";
            this.rbStructRegistry.Text = "Anagrafica → Tipo di allegato (predefinito)";
            this.rbStructRegistry.UseVisualStyleBackColor = true;
            //
            // rbStructType
            //
            this.rbStructType.Location = new System.Drawing.Point(360, 22);
            this.rbStructType.Name = "rbStructType";
            this.rbStructType.Size = new System.Drawing.Size(320, 17);
            this.rbStructType.TabIndex = 1;
            this.rbStructType.Tag = "";
            this.rbStructType.Text = "Tipo di allegato → Anagrafica";
            this.rbStructType.UseVisualStyleBackColor = true;
            //
            // btnEseguiDownload
            //
            this.btnEseguiDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEseguiDownload.Location = new System.Drawing.Point(568, 545);
            this.btnEseguiDownload.Name = "btnEseguiDownload";
            this.btnEseguiDownload.Size = new System.Drawing.Size(140, 30);
            this.btnEseguiDownload.TabIndex = 5;
            this.btnEseguiDownload.Text = "Esegui download";
            this.btnEseguiDownload.UseVisualStyleBackColor = true;
            this.btnEseguiDownload.Click += new System.EventHandler(this.btnEseguiDownload_Click);
            //
            // btnInterrompi
            //
            this.btnInterrompi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInterrompi.Location = new System.Drawing.Point(422, 545);
            this.btnInterrompi.Name = "btnInterrompi";
            this.btnInterrompi.Size = new System.Drawing.Size(140, 30);
            this.btnInterrompi.TabIndex = 6;
            this.btnInterrompi.Text = "Interrompi";
            this.btnInterrompi.UseVisualStyleBackColor = true;
            this.btnInterrompi.Visible = false;
            this.btnInterrompi.Click += new System.EventHandler(this.btnInterrompi_Click);
            //
            // lblStatus
            //
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Location = new System.Drawing.Point(12, 595);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(696, 18);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "";
            this.lblStatus.Visible = false;
            //
            // progressBar1
            //
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 620);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(696, 18);
            this.progressBar1.TabIndex = 8;
            this.progressBar1.Visible = false;
            //
            // btnAnnulla
            //
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.Location = new System.Drawing.Point(633, 655);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 9;
            this.btnAnnulla.Text = "Annulla";
            this.btnAnnulla.UseVisualStyleBackColor = true;
            this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
            //
            // _saveZipDlg
            //
            this._saveZipDlg.DefaultExt = "zip";
            this._saveZipDlg.Filter = "Archivio ZIP (*.zip)|*.zip|Tutti i file (*.*)|*.*";
            this._saveZipDlg.Title = "Selezionare l\'archivio ZIP di destinazione";
            //
            // _openExcelDlg
            //
            this._openExcelDlg.Filter = "File Excel (*.xlsx;*.xls)|*.xlsx;*.xls|Tutti i file (*.*)|*.*";
            this._openExcelDlg.Title = "Seleziona il file Excel con le anagrafiche";
            //
            // Frm_dumpdocanagrafica
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 690);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnInterrompi);
            this.Controls.Add(this.btnEseguiDownload);
            this.Controls.Add(this.gboxStruttura);
            this.Controls.Add(this.gboxTabelle);
            this.Controls.Add(this.gboxFolder);
            this.Controls.Add(this.gboxExcel);
            this.Controls.Add(this.gboxInfo);
            this.Name = "Frm_dumpdocanagrafica";
            this.Text = "Scarica allegati anagrafiche da file Excel";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.gboxInfo.ResumeLayout(false);
            this.gboxExcel.ResumeLayout(false);
            this.gboxExcel.PerformLayout();
            this.gboxFolder.ResumeLayout(false);
            this.gboxFolder.PerformLayout();
            this.gboxTabelle.ResumeLayout(false);
            this.gboxTabelle.PerformLayout();
            this.gboxStruttura.ResumeLayout(false);
            this.gboxStruttura.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.GroupBox gboxInfo;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.GroupBox gboxExcel;
        private System.Windows.Forms.Button btnSelezionaExcel;
        private System.Windows.Forms.TextBox txtExcelFile;
        private System.Windows.Forms.GroupBox gboxFolder;
        private System.Windows.Forms.Button btnSelezionaZip;
        private System.Windows.Forms.TextBox txtZipFile;
        private System.Windows.Forms.GroupBox gboxTabelle;
        private System.Windows.Forms.CheckBox chkCv;
        private System.Windows.Forms.CheckBox chkAllegati;
        private System.Windows.Forms.CheckBox chkVisure;
        private System.Windows.Forms.CheckBox chkCasellarioGiud;
        private System.Windows.Forms.CheckBox chkCasellarioAmm;
        private System.Windows.Forms.CheckBox chkOttemperanza;
        private System.Windows.Forms.CheckBox chkRegolaritaFiscale;
        private System.Windows.Forms.CheckBox chkVerificaAnac;
        private System.Windows.Forms.CheckBox chkPattoIntegrita;
        private System.Windows.Forms.CheckBox chkDurc;
        private System.Windows.Forms.CheckBox chkPayMethod;
        private System.Windows.Forms.CheckBox chkPayMethodAttach;
        private System.Windows.Forms.Button btnSelezionaTutto;
        private System.Windows.Forms.Button btnDeselezionaTutto;
        private System.Windows.Forms.GroupBox gboxStruttura;
        private System.Windows.Forms.RadioButton rbStructRegistry;
        private System.Windows.Forms.RadioButton rbStructType;
        private System.Windows.Forms.Button btnEseguiDownload;
        private System.Windows.Forms.Button btnInterrompi;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.SaveFileDialog _saveZipDlg;
        private System.Windows.Forms.OpenFileDialog _openExcelDlg;
    }
}
