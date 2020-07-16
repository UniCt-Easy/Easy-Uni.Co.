/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

﻿namespace import_flow_default {
    partial class FrmImportFlow_default {
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
            this.tabController = new Crownwood.Magic.Controls.TabControl();
            this.tabpage1 = new Crownwood.Magic.Controls.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.labScritture = new System.Windows.Forms.Label();
            this.btnImportDetail = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.labincassi = new System.Windows.Forms.Label();
            this.labpagamenti = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.gridProblemi = new System.Windows.Forms.DataGrid();
            this.lblMessaggi = new System.Windows.Forms.Label();
            this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
            this.dataGridVarBilancio = new System.Windows.Forms.DataGrid();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage4 = new Crownwood.Magic.Controls.TabPage();
            this.chkRaggruppa = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.gridSpesa = new System.Windows.Forms.DataGrid();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.gridEntrata = new System.Windows.Forms.DataGrid();
            this.tabPage8 = new Crownwood.Magic.Controls.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.dgridScritture = new System.Windows.Forms.DataGrid();
            this.tabPage5 = new Crownwood.Magic.Controls.TabPage();
            this.labFinalMsg = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.openInputFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.DS = new import_flow_default.vistaForm();
            this.tabPage9 = new Crownwood.Magic.Controls.TabPage();
            this.gridstorni = new System.Windows.Forms.DataGrid();
            this.label10 = new System.Windows.Forms.Label();
            this.tabController.SuspendLayout();
            this.tabpage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProblemi)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVarBilancio)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSpesa)).BeginInit();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEntrata)).BeginInit();
            this.tabPage8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgridScritture)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.tabPage9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridstorni)).BeginInit();
            this.SuspendLayout();
            // 
            // tabController
            // 
            this.tabController.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabController.IDEPixelArea = true;
            this.tabController.Location = new System.Drawing.Point(8, 9);
            this.tabController.Name = "tabController";
            this.tabController.SelectedIndex = 0;
            this.tabController.SelectedTab = this.tabpage1;
            this.tabController.Size = new System.Drawing.Size(791, 336);
            this.tabController.TabIndex = 14;
            this.tabController.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabpage1,
            this.tabPage2,
            this.tabPage3,
            this.tabPage4,
            this.tabPage8,
            this.tabPage9,
            this.tabPage5});
            // 
            // tabpage1
            // 
            this.tabpage1.Controls.Add(this.label9);
            this.tabpage1.Controls.Add(this.labScritture);
            this.tabpage1.Controls.Add(this.btnImportDetail);
            this.tabpage1.Controls.Add(this.btnImport);
            this.tabpage1.Controls.Add(this.labincassi);
            this.tabpage1.Controls.Add(this.labpagamenti);
            this.tabpage1.Controls.Add(this.label4);
            this.tabpage1.Controls.Add(this.label3);
            this.tabpage1.Controls.Add(this.label2);
            this.tabpage1.Controls.Add(this.label1);
            this.tabpage1.Controls.Add(this.label5);
            this.tabpage1.Location = new System.Drawing.Point(0, 0);
            this.tabpage1.Name = "tabpage1";
            this.tabpage1.Size = new System.Drawing.Size(791, 311);
            this.tabpage1.TabIndex = 0;
            this.tabpage1.Title = "Lettura dati";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(99, 193);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(141, 15);
            this.label9.TabIndex = 85;
            this.label9.Text = "Scritture in partita doppia";
            // 
            // labScritture
            // 
            this.labScritture.Location = new System.Drawing.Point(29, 193);
            this.labScritture.Name = "labScritture";
            this.labScritture.Size = new System.Drawing.Size(64, 15);
            this.labScritture.TabIndex = 84;
            this.labScritture.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnImportDetail
            // 
            this.btnImportDetail.Location = new System.Drawing.Point(629, 64);
            this.btnImportDetail.Name = "btnImportDetail";
            this.btnImportDetail.Size = new System.Drawing.Size(153, 24);
            this.btnImportDetail.TabIndex = 83;
            this.btnImportDetail.Text = "Importa dati (dettagli)";
            this.btnImportDetail.UseVisualStyleBackColor = true;
            this.btnImportDetail.Click += new System.EventHandler(this.btnImportDetail_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(666, 23);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(116, 24);
            this.btnImport.TabIndex = 82;
            this.btnImport.Text = "Importa dati";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // labincassi
            // 
            this.labincassi.Location = new System.Drawing.Point(27, 158);
            this.labincassi.Name = "labincassi";
            this.labincassi.Size = new System.Drawing.Size(64, 15);
            this.labincassi.TabIndex = 81;
            this.labincassi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labpagamenti
            // 
            this.labpagamenti.Location = new System.Drawing.Point(29, 129);
            this.labpagamenti.Name = "labpagamenti";
            this.labpagamenti.Size = new System.Drawing.Size(64, 15);
            this.labpagamenti.TabIndex = 80;
            this.labpagamenti.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(100, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 15);
            this.label4.TabIndex = 79;
            this.label4.Text = "incassi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 15);
            this.label3.TabIndex = 78;
            this.label3.Text = "pagamenti";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 15);
            this.label2.TabIndex = 77;
            this.label2.Text = "Risultano da creare: ";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(611, 22);
            this.label1.TabIndex = 76;
            this.label1.Text = "Saranno creati i movimenti finanziari e variazioni bilancio richiesti per l\'eserc" +
    "izio corrente";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(568, 23);
            this.label5.TabIndex = 7;
            this.label5.Text = "Procedura guidata di importazione flusso movimenti finanziari.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage2
            // 
            this.tabPage2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPage2.Controls.Add(this.gridProblemi);
            this.tabPage2.Controls.Add(this.lblMessaggi);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(791, 311);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Title = "Analisi";
            this.tabPage2.Visible = false;
            // 
            // gridProblemi
            // 
            this.gridProblemi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridProblemi.DataMember = "";
            this.gridProblemi.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridProblemi.Location = new System.Drawing.Point(16, 51);
            this.gridProblemi.Name = "gridProblemi";
            this.gridProblemi.Size = new System.Drawing.Size(759, 240);
            this.gridProblemi.TabIndex = 1;
            // 
            // lblMessaggi
            // 
            this.lblMessaggi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessaggi.Location = new System.Drawing.Point(16, 13);
            this.lblMessaggi.Name = "lblMessaggi";
            this.lblMessaggi.Size = new System.Drawing.Size(759, 32);
            this.lblMessaggi.TabIndex = 0;
            this.lblMessaggi.Text = "Messaggi";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridVarBilancio);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Location = new System.Drawing.Point(0, 0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Selected = false;
            this.tabPage3.Size = new System.Drawing.Size(791, 311);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Title = "Calcolo variazione";
            // 
            // dataGridVarBilancio
            // 
            this.dataGridVarBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridVarBilancio.DataMember = "";
            this.dataGridVarBilancio.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridVarBilancio.Location = new System.Drawing.Point(16, 50);
            this.dataGridVarBilancio.Name = "dataGridVarBilancio";
            this.dataGridVarBilancio.Size = new System.Drawing.Size(759, 244);
            this.dataGridVarBilancio.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(19, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(756, 21);
            this.label6.TabIndex = 0;
            this.label6.Text = "Variazioni di bilancio che saranno create:";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.chkRaggruppa);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Controls.Add(this.tabControl1);
            this.tabPage4.Location = new System.Drawing.Point(0, 0);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Selected = false;
            this.tabPage4.Size = new System.Drawing.Size(791, 311);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Title = "Calcolo movimenti";
            // 
            // chkRaggruppa
            // 
            this.chkRaggruppa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRaggruppa.AutoSize = true;
            this.chkRaggruppa.Location = new System.Drawing.Point(592, 6);
            this.chkRaggruppa.Name = "chkRaggruppa";
            this.chkRaggruppa.Size = new System.Drawing.Size(186, 19);
            this.chkRaggruppa.TabIndex = 2;
            this.chkRaggruppa.Text = "Raggruppa mandati e reversali";
            this.chkRaggruppa.UseVisualStyleBackColor = true;
            this.chkRaggruppa.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(265, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "Saranno generati i seguenti movimenti finanziari.";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Location = new System.Drawing.Point(4, 31);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(778, 267);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.gridSpesa);
            this.tabPage6.Location = new System.Drawing.Point(4, 24);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(770, 239);
            this.tabPage6.TabIndex = 0;
            this.tabPage6.Text = "Movimenti di spesa";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // gridSpesa
            // 
            this.gridSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSpesa.DataMember = "";
            this.gridSpesa.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridSpesa.Location = new System.Drawing.Point(3, 6);
            this.gridSpesa.Name = "gridSpesa";
            this.gridSpesa.Size = new System.Drawing.Size(761, 222);
            this.gridSpesa.TabIndex = 3;
            this.gridSpesa.Tag = "";
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.gridEntrata);
            this.tabPage7.Location = new System.Drawing.Point(4, 24);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(770, 239);
            this.tabPage7.TabIndex = 1;
            this.tabPage7.Text = "Movimenti di entrata";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // gridEntrata
            // 
            this.gridEntrata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridEntrata.DataMember = "";
            this.gridEntrata.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridEntrata.Location = new System.Drawing.Point(4, 4);
            this.gridEntrata.Name = "gridEntrata";
            this.gridEntrata.Size = new System.Drawing.Size(761, 230);
            this.gridEntrata.TabIndex = 4;
            this.gridEntrata.Tag = "";
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.label8);
            this.tabPage8.Controls.Add(this.dgridScritture);
            this.tabPage8.Location = new System.Drawing.Point(0, 0);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Selected = false;
            this.tabPage8.Size = new System.Drawing.Size(791, 311);
            this.tabPage8.TabIndex = 6;
            this.tabPage8.Title = "Calcolo scritture";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(13, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(756, 21);
            this.label8.TabIndex = 4;
            this.label8.Text = "Scritture in partita doppia che saranno create:";
            // 
            // dgridScritture
            // 
            this.dgridScritture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgridScritture.DataMember = "";
            this.dgridScritture.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgridScritture.Location = new System.Drawing.Point(16, 33);
            this.dgridScritture.Name = "dgridScritture";
            this.dgridScritture.Size = new System.Drawing.Size(759, 262);
            this.dgridScritture.TabIndex = 3;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.labFinalMsg);
            this.tabPage5.Location = new System.Drawing.Point(0, 0);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Selected = false;
            this.tabPage5.Size = new System.Drawing.Size(791, 311);
            this.tabPage5.TabIndex = 5;
            this.tabPage5.Title = "Salvataggio";
            // 
            // labFinalMsg
            // 
            this.labFinalMsg.Location = new System.Drawing.Point(14, 14);
            this.labFinalMsg.Name = "labFinalMsg";
            this.labFinalMsg.Size = new System.Drawing.Size(705, 34);
            this.labFinalMsg.TabIndex = 0;
            this.labFinalMsg.Text = "label8";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(618, 353);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(72, 23);
            this.btnNext.TabIndex = 18;
            this.btnNext.Text = "Avanti >";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(538, 353);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(72, 23);
            this.btnBack.TabIndex = 17;
            this.btnBack.Text = "< Indietro";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.gridstorni);
            this.tabPage9.Controls.Add(this.label10);
            this.tabPage9.Location = new System.Drawing.Point(0, 0);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Selected = false;
            this.tabPage9.Size = new System.Drawing.Size(791, 311);
            this.tabPage9.TabIndex = 7;
            this.tabPage9.Title = "Calcolo Storni";
            // 
            // gridstorni
            // 
            this.gridstorni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridstorni.DataMember = "";
            this.gridstorni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridstorni.Location = new System.Drawing.Point(18, 47);
            this.gridstorni.Name = "gridstorni";
            this.gridstorni.Size = new System.Drawing.Size(764, 261);
            this.gridstorni.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(15, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(756, 21);
            this.label10.TabIndex = 1;
            this.label10.Text = "Storni che saranno creati:";
            // 
            // FrmImportFlow_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 398);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.tabController);
            this.Name = "FrmImportFlow_default";
            this.Text = "FrmImportFlow_default";
            this.tabController.ResumeLayout(false);
            this.tabpage1.ResumeLayout(false);
            this.tabpage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridProblemi)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVarBilancio)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSpesa)).EndInit();
            this.tabPage7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEntrata)).EndInit();
            this.tabPage8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgridScritture)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.tabPage9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridstorni)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public vistaForm DS;
        private Crownwood.Magic.Controls.TabControl tabController;
        private Crownwood.Magic.Controls.TabPage tabpage1;
        private System.Windows.Forms.Label labincassi;
        private System.Windows.Forms.Label labpagamenti;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private Crownwood.Magic.Controls.TabPage tabPage2;
        private System.Windows.Forms.DataGrid gridProblemi;
        private System.Windows.Forms.Label lblMessaggi;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private Crownwood.Magic.Controls.TabPage tabPage3;
        private System.Windows.Forms.Label label6;
        private Crownwood.Magic.Controls.TabPage tabPage4;
        private Crownwood.Magic.Controls.TabPage tabPage5;
        private System.Windows.Forms.DataGrid dataGridVarBilancio;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.DataGrid gridSpesa;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.DataGrid gridEntrata;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labFinalMsg;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.OpenFileDialog openInputFileDlg;
        private System.Windows.Forms.CheckBox chkRaggruppa;
        private Crownwood.Magic.Controls.TabPage tabPage8;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGrid dgridScritture;
        private System.Windows.Forms.Button btnImportDetail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labScritture;
        private Crownwood.Magic.Controls.TabPage tabPage9;
        private System.Windows.Forms.DataGrid gridstorni;
        private System.Windows.Forms.Label label10;
    }
}