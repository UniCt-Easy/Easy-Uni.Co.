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

﻿namespace csa_import_inail {
    partial class frmcsa_import_inail {
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
			this.label9 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.dgrImportazioni = new System.Windows.Forms.DataGrid();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.dgrEntiVersamento = new System.Windows.Forms.DataGrid();
			this.chkAzzeraUltimaFase = new System.Windows.Forms.CheckBox();
			this.btnDelSospesi = new System.Windows.Forms.Button();
			this.lblTask = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.dgrSospesi = new System.Windows.Forms.DataGrid();
			this.btnInputSospesi = new System.Windows.Forms.Button();
			this.gBoxBollettaVersamenti = new System.Windows.Forms.GroupBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.txtNumBollettaVersamenti = new System.Windows.Forms.TextBox();
			this.txtEsercBollettaVersamenti = new System.Windows.Forms.TextBox();
			this.btnBollettaVersamenti = new System.Windows.Forms.Button();
			this.btnVersamenti = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.openInputFileDlg = new System.Windows.Forms.OpenFileDialog();
			this.dsFinancial = new csa_import_inail.dsFinancial();
			this.DS = new csa_import_inail.dsmeta();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrImportazioni)).BeginInit();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrEntiVersamento)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrSospesi)).BeginInit();
			this.gBoxBollettaVersamenti.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dsFinancial)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(17, 243);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(683, 27);
			this.label9.TabIndex = 29;
			this.label9.Tag = "";
			this.label9.Text = "Selezionare la combinazione di Enti e Importazioni per i quali si intende generar" +
    "e la movimentazione finanziaria e cliccare su Elabora versamenti";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.dgrImportazioni);
			this.groupBox2.Location = new System.Drawing.Point(347, 273);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(345, 190);
			this.groupBox2.TabIndex = 27;
			this.groupBox2.TabStop = false;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(9, 12);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(108, 20);
			this.label5.TabIndex = 9;
			this.label5.Tag = "";
			this.label5.Text = "Importazioni:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dgrImportazioni
			// 
			this.dgrImportazioni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrImportazioni.DataMember = "";
			this.dgrImportazioni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrImportazioni.Location = new System.Drawing.Point(11, 31);
			this.dgrImportazioni.Name = "dgrImportazioni";
			this.dgrImportazioni.Size = new System.Drawing.Size(328, 146);
			this.dgrImportazioni.TabIndex = 8;
			this.dgrImportazioni.Tag = "";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.dgrEntiVersamento);
			this.groupBox3.Location = new System.Drawing.Point(11, 272);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(328, 191);
			this.groupBox3.TabIndex = 28;
			this.groupBox3.TabStop = false;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(14, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(108, 20);
			this.label2.TabIndex = 11;
			this.label2.Tag = "";
			this.label2.Text = "Enti:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dgrEntiVersamento
			// 
			this.dgrEntiVersamento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrEntiVersamento.DataMember = "";
			this.dgrEntiVersamento.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrEntiVersamento.Location = new System.Drawing.Point(14, 35);
			this.dgrEntiVersamento.Name = "dgrEntiVersamento";
			this.dgrEntiVersamento.Size = new System.Drawing.Size(302, 143);
			this.dgrEntiVersamento.TabIndex = 10;
			this.dgrEntiVersamento.Tag = "";
			// 
			// chkAzzeraUltimaFase
			// 
			this.chkAzzeraUltimaFase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkAzzeraUltimaFase.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkAzzeraUltimaFase.ForeColor = System.Drawing.Color.Red;
			this.chkAzzeraUltimaFase.Location = new System.Drawing.Point(279, 482);
			this.chkAzzeraUltimaFase.Name = "chkAzzeraUltimaFase";
			this.chkAzzeraUltimaFase.Size = new System.Drawing.Size(413, 23);
			this.chkAzzeraUltimaFase.TabIndex = 26;
			this.chkAzzeraUltimaFase.Tag = " ";
			this.chkAzzeraUltimaFase.Text = "Non generare i pagamenti e gli incassi";
			// 
			// btnDelSospesi
			// 
			this.btnDelSospesi.Location = new System.Drawing.Point(368, 12);
			this.btnDelSospesi.Name = "btnDelSospesi";
			this.btnDelSospesi.Size = new System.Drawing.Size(167, 23);
			this.btnDelSospesi.TabIndex = 25;
			this.btnDelSospesi.Text = "Cancella Importazione Sospesi  ";
			this.btnDelSospesi.Click += new System.EventHandler(this.btnDelSospesi_Click);
			// 
			// lblTask
			// 
			this.lblTask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblTask.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.lblTask.Location = new System.Drawing.Point(366, 44);
			this.lblTask.Name = "lblTask";
			this.lblTask.Size = new System.Drawing.Size(325, 21);
			this.lblTask.TabIndex = 24;
			this.lblTask.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.dgrSospesi);
			this.groupBox1.Location = new System.Drawing.Point(14, 77);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(683, 158);
			this.groupBox1.TabIndex = 23;
			this.groupBox1.TabStop = false;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(11, 12);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(57, 20);
			this.label6.TabIndex = 7;
			this.label6.Tag = "";
			this.label6.Text = "Sospesi:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dgrSospesi
			// 
			this.dgrSospesi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrSospesi.DataMember = "";
			this.dgrSospesi.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrSospesi.Location = new System.Drawing.Point(10, 35);
			this.dgrSospesi.Name = "dgrSospesi";
			this.dgrSospesi.Size = new System.Drawing.Size(667, 115);
			this.dgrSospesi.TabIndex = 4;
			// 
			// btnInputSospesi
			// 
			this.btnInputSospesi.Location = new System.Drawing.Point(541, 12);
			this.btnInputSospesi.Name = "btnInputSospesi";
			this.btnInputSospesi.Size = new System.Drawing.Size(167, 23);
			this.btnInputSospesi.TabIndex = 22;
			this.btnInputSospesi.Text = "Importa Dati da File Sospesi";
			this.btnInputSospesi.Click += new System.EventHandler(this.btnInputSospesi_Click);
			// 
			// gBoxBollettaVersamenti
			// 
			this.gBoxBollettaVersamenti.Controls.Add(this.label8);
			this.gBoxBollettaVersamenti.Controls.Add(this.label7);
			this.gBoxBollettaVersamenti.Controls.Add(this.txtNumBollettaVersamenti);
			this.gBoxBollettaVersamenti.Controls.Add(this.txtEsercBollettaVersamenti);
			this.gBoxBollettaVersamenti.Controls.Add(this.btnBollettaVersamenti);
			this.gBoxBollettaVersamenti.Location = new System.Drawing.Point(16, 12);
			this.gBoxBollettaVersamenti.Name = "gBoxBollettaVersamenti";
			this.gBoxBollettaVersamenti.Size = new System.Drawing.Size(323, 59);
			this.gBoxBollettaVersamenti.TabIndex = 21;
			this.gBoxBollettaVersamenti.TabStop = false;
			this.gBoxBollettaVersamenti.Tag = "AutoChoose.txtNumBollettaVersamenti.spesa.(active=\'S\')";
			this.gBoxBollettaVersamenti.Text = "Versamenti";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(229, 10);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(54, 20);
			this.label8.TabIndex = 4;
			this.label8.Tag = "";
			this.label8.Text = "Numero:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(120, 10);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(57, 20);
			this.label7.TabIndex = 3;
			this.label7.Tag = "";
			this.label7.Text = "Esercizio:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtNumBollettaVersamenti
			// 
			this.txtNumBollettaVersamenti.Location = new System.Drawing.Point(216, 30);
			this.txtNumBollettaVersamenti.Name = "txtNumBollettaVersamenti";
			this.txtNumBollettaVersamenti.Size = new System.Drawing.Size(100, 20);
			this.txtNumBollettaVersamenti.TabIndex = 2;
			this.txtNumBollettaVersamenti.Tag = "bill_versamenti.nbill?billview.nbill";
			// 
			// txtEsercBollettaVersamenti
			// 
			this.txtEsercBollettaVersamenti.Location = new System.Drawing.Point(110, 30);
			this.txtEsercBollettaVersamenti.Name = "txtEsercBollettaVersamenti";
			this.txtEsercBollettaVersamenti.Size = new System.Drawing.Size(100, 20);
			this.txtEsercBollettaVersamenti.TabIndex = 1;
			this.txtEsercBollettaVersamenti.Tag = "bill_versamenti.ybill.year?billview.ybill.year";
			// 
			// btnBollettaVersamenti
			// 
			this.btnBollettaVersamenti.Location = new System.Drawing.Point(14, 30);
			this.btnBollettaVersamenti.Name = "btnBollettaVersamenti";
			this.btnBollettaVersamenti.Size = new System.Drawing.Size(88, 23);
			this.btnBollettaVersamenti.TabIndex = 0;
			this.btnBollettaVersamenti.TabStop = false;
			this.btnBollettaVersamenti.Tag = "";
			this.btnBollettaVersamenti.Text = "N. sospeso";
			this.btnBollettaVersamenti.Click += new System.EventHandler(this.btnBollettaVersamenti_Click);
			// 
			// btnVersamenti
			// 
			this.btnVersamenti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnVersamenti.Location = new System.Drawing.Point(11, 482);
			this.btnVersamenti.Name = "btnVersamenti";
			this.btnVersamenti.Size = new System.Drawing.Size(233, 23);
			this.btnVersamenti.TabIndex = 1;
			this.btnVersamenti.Text = "Elabora Versamenti";
			this.btnVersamenti.UseVisualStyleBackColor = true;
			this.btnVersamenti.Click += new System.EventHandler(this.btnVersamenti_Click);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BackColor = System.Drawing.SystemColors.Control;
			this.panel1.Controls.Add(this.label9);
			this.panel1.Controls.Add(this.groupBox2);
			this.panel1.Controls.Add(this.groupBox3);
			this.panel1.Controls.Add(this.chkAzzeraUltimaFase);
			this.panel1.Controls.Add(this.btnDelSospesi);
			this.panel1.Controls.Add(this.lblTask);
			this.panel1.Controls.Add(this.btnInputSospesi);
			this.panel1.Controls.Add(this.gBoxBollettaVersamenti);
			this.panel1.Controls.Add(this.btnVersamenti);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Location = new System.Drawing.Point(12, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(713, 515);
			this.panel1.TabIndex = 7;
			// 
			// dsFinancial
			// 
			this.dsFinancial.DataSetName = "dsFinancial";
			this.dsFinancial.EnforceConstraints = false;
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(650, 523);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(75, 22);
			this.btnAnnulla.TabIndex = 317;
			this.btnAnnulla.Text = "Annulla";
			this.btnAnnulla.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// frmcsa_import_inail
			// 
			this.ClientSize = new System.Drawing.Size(741, 556);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.panel1);
			this.Name = "frmcsa_import_inail";
			this.Text = "frmcsa_import_inail";
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrImportazioni)).EndInit();
			this.groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrEntiVersamento)).EndInit();
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrSospesi)).EndInit();
			this.gBoxBollettaVersamenti.ResumeLayout(false);
			this.gBoxBollettaVersamenti.PerformLayout();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dsFinancial)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        public csa_import_inail.dsmeta DS;
        private System.Windows.Forms.Button btnVersamenti;
        private System.Windows.Forms.GroupBox gBoxBollettaVersamenti;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNumBollettaVersamenti;
        private System.Windows.Forms.TextBox txtEsercBollettaVersamenti;
        private System.Windows.Forms.Button btnBollettaVersamenti;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DataGrid dgrSospesi;
		private System.Windows.Forms.Button btnInputSospesi;
		private System.Windows.Forms.Label lblTask;
		private System.Windows.Forms.OpenFileDialog openInputFileDlg;
		private System.Windows.Forms.Button btnDelSospesi;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.CheckBox chkAzzeraUltimaFase;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DataGrid dgrImportazioni;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGrid dgrEntiVersamento;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button btnAnnulla;
	}
}

