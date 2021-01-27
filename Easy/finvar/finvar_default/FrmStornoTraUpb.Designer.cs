
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


namespace finvar_default {
    partial class FrmStornoTraUpb {
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
            inChiusura = true;
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.gboxBilAnnuale = new System.Windows.Forms.GroupBox();
            this.chkListTitle = new System.Windows.Forms.CheckBox();
            this.btnBilancio = new System.Windows.Forms.Button();
            this.txtCodiceBilancio = new System.Windows.Forms.TextBox();
            this.txtDenominazioneBilancio = new System.Windows.Forms.TextBox();
            this.rdbEntrata = new System.Windows.Forms.RadioButton();
            this.rdbSpesa = new System.Windows.Forms.RadioButton();
            this.gboxUPBSource = new System.Windows.Forms.GroupBox();
            this.txtUPBSource = new System.Windows.Forms.TextBox();
            this.txtDescrUPBSource = new System.Windows.Forms.TextBox();
            this.btnUPBSource = new System.Windows.Forms.Button();
            this.DS = new finvar_default.vistaSubForm();
            this.label1 = new System.Windows.Forms.Label();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.gboxUPBDest = new System.Windows.Forms.GroupBox();
            this.txtUPBDest = new System.Windows.Forms.TextBox();
            this.txtDescrUPBDest = new System.Windows.Forms.TextBox();
            this.btnUPBDest = new System.Windows.Forms.Button();
            this.btnFinanziamento = new System.Windows.Forms.Button();
            this.txtUnderwriting = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.gboxBilAnnuale.SuspendLayout();
            this.gboxUPBSource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.gboxUPBDest.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboxBilAnnuale
            // 
            this.gboxBilAnnuale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxBilAnnuale.Controls.Add(this.chkListTitle);
            this.gboxBilAnnuale.Controls.Add(this.btnBilancio);
            this.gboxBilAnnuale.Controls.Add(this.txtCodiceBilancio);
            this.gboxBilAnnuale.Controls.Add(this.txtDenominazioneBilancio);
            this.gboxBilAnnuale.Controls.Add(this.rdbEntrata);
            this.gboxBilAnnuale.Controls.Add(this.rdbSpesa);
            this.gboxBilAnnuale.Location = new System.Drawing.Point(517, 12);
            this.gboxBilAnnuale.Name = "gboxBilAnnuale";
            this.gboxBilAnnuale.Size = new System.Drawing.Size(419, 114);
            this.gboxBilAnnuale.TabIndex = 3;
            this.gboxBilAnnuale.TabStop = false;
            this.gboxBilAnnuale.Tag = "";
            this.gboxBilAnnuale.Text = "Voce di bilancio";
            // 
            // chkListTitle
            // 
            this.chkListTitle.AutoSize = true;
            this.chkListTitle.Location = new System.Drawing.Point(8, 38);
            this.chkListTitle.Name = "chkListTitle";
            this.chkListTitle.Size = new System.Drawing.Size(146, 17);
            this.chkListTitle.TabIndex = 4;
            this.chkListTitle.TabStop = false;
            this.chkListTitle.Text = "Cerca per denominazione";
            // 
            // btnBilancio
            // 
            this.btnBilancio.BackColor = System.Drawing.SystemColors.Control;
            this.btnBilancio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBilancio.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBilancio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilancio.ImageIndex = 0;
            this.btnBilancio.Location = new System.Drawing.Point(10, 61);
            this.btnBilancio.Name = "btnBilancio";
            this.btnBilancio.Size = new System.Drawing.Size(112, 20);
            this.btnBilancio.TabIndex = 1;
            this.btnBilancio.TabStop = false;
            this.btnBilancio.Tag = "";
            this.btnBilancio.Text = "Bilancio";
            this.btnBilancio.UseVisualStyleBackColor = false;
            this.btnBilancio.Click += new System.EventHandler(this.btnBilancio_Click);
            // 
            // txtCodiceBilancio
            // 
            this.txtCodiceBilancio.Location = new System.Drawing.Point(10, 85);
            this.txtCodiceBilancio.Name = "txtCodiceBilancio";
            this.txtCodiceBilancio.Size = new System.Drawing.Size(391, 20);
            this.txtCodiceBilancio.TabIndex = 5;
            this.txtCodiceBilancio.Tag = "finview.codefin?x";
            this.txtCodiceBilancio.Leave += new System.EventHandler(this.txtCodiceBilancio_Leave);
            // 
            // txtDenominazioneBilancio
            // 
            this.txtDenominazioneBilancio.Location = new System.Drawing.Point(160, 13);
            this.txtDenominazioneBilancio.Multiline = true;
            this.txtDenominazioneBilancio.Name = "txtDenominazioneBilancio";
            this.txtDenominazioneBilancio.ReadOnly = true;
            this.txtDenominazioneBilancio.Size = new System.Drawing.Size(241, 68);
            this.txtDenominazioneBilancio.TabIndex = 3;
            this.txtDenominazioneBilancio.TabStop = false;
            this.txtDenominazioneBilancio.Tag = "finview.title";
            // 
            // rdbEntrata
            // 
            this.rdbEntrata.Checked = true;
            this.rdbEntrata.Location = new System.Drawing.Point(8, 16);
            this.rdbEntrata.Name = "rdbEntrata";
            this.rdbEntrata.Size = new System.Drawing.Size(64, 16);
            this.rdbEntrata.TabIndex = 2;
            this.rdbEntrata.TabStop = true;
            this.rdbEntrata.Tag = "finview.finpart:E?x";
            this.rdbEntrata.Text = "Entrata";
            // 
            // rdbSpesa
            // 
            this.rdbSpesa.Location = new System.Drawing.Point(80, 16);
            this.rdbSpesa.Name = "rdbSpesa";
            this.rdbSpesa.Size = new System.Drawing.Size(64, 16);
            this.rdbSpesa.TabIndex = 3;
            this.rdbSpesa.Tag = "finview.finpart:S?x";
            this.rdbSpesa.Text = "Spesa";
            this.rdbSpesa.CheckedChanged += new System.EventHandler(this.rdbSpesa_CheckedChanged);
            // 
            // gboxUPBSource
            // 
            this.gboxUPBSource.Controls.Add(this.txtUPBSource);
            this.gboxUPBSource.Controls.Add(this.txtDescrUPBSource);
            this.gboxUPBSource.Controls.Add(this.btnUPBSource);
            this.gboxUPBSource.Location = new System.Drawing.Point(8, 12);
            this.gboxUPBSource.Name = "gboxUPBSource";
            this.gboxUPBSource.Size = new System.Drawing.Size(503, 114);
            this.gboxUPBSource.TabIndex = 1;
            this.gboxUPBSource.TabStop = false;
            this.gboxUPBSource.Tag = "";
            this.gboxUPBSource.Text = "Upb da cui stornare";
            // 
            // txtUPBSource
            // 
            this.txtUPBSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUPBSource.Location = new System.Drawing.Point(8, 85);
            this.txtUPBSource.Name = "txtUPBSource";
            this.txtUPBSource.Size = new System.Drawing.Size(487, 20);
            this.txtUPBSource.TabIndex = 14;
            this.txtUPBSource.Tag = "finview.codefin?incomeview.codefin";
            // 
            // txtDescrUPBSource
            // 
            this.txtDescrUPBSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrUPBSource.Location = new System.Drawing.Point(175, 16);
            this.txtDescrUPBSource.Multiline = true;
            this.txtDescrUPBSource.Name = "txtDescrUPBSource";
            this.txtDescrUPBSource.ReadOnly = true;
            this.txtDescrUPBSource.Size = new System.Drawing.Size(320, 60);
            this.txtDescrUPBSource.TabIndex = 4;
            this.txtDescrUPBSource.TabStop = false;
            this.txtDescrUPBSource.Tag = "upb.title";
            // 
            // btnUPBSource
            // 
            this.btnUPBSource.BackColor = System.Drawing.SystemColors.Control;
            this.btnUPBSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUPBSource.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUPBSource.Location = new System.Drawing.Point(8, 56);
            this.btnUPBSource.Name = "btnUPBSource";
            this.btnUPBSource.Size = new System.Drawing.Size(120, 20);
            this.btnUPBSource.TabIndex = 2;
            this.btnUPBSource.TabStop = false;
            this.btnUPBSource.Tag = "manage.upb.tree";
            this.btnUPBSource.Text = "U.P.B.";
            this.btnUPBSource.UseVisualStyleBackColor = false;
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaSubForm";
            this.DS.EnforceConstraints = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(756, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Importo";
            // 
            // txtImporto
            // 
            this.txtImporto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImporto.Location = new System.Drawing.Point(804, 142);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.Size = new System.Drawing.Size(128, 20);
            this.txtImporto.TabIndex = 21;
            this.txtImporto.Tag = "finvardetail.amount";
            this.txtImporto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImporto.Leave += new System.EventHandler(this.txtImporto_Leave);
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(325, 443);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 23;
            this.btnAnnulla.Text = "Annulla";
            this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(221, 443);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 22;
            this.btnOK.Tag = "mainsave";
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // gboxUPBDest
            // 
            this.gboxUPBDest.Controls.Add(this.txtUPBDest);
            this.gboxUPBDest.Controls.Add(this.txtDescrUPBDest);
            this.gboxUPBDest.Controls.Add(this.btnUPBDest);
            this.gboxUPBDest.Location = new System.Drawing.Point(8, 130);
            this.gboxUPBDest.Name = "gboxUPBDest";
            this.gboxUPBDest.Size = new System.Drawing.Size(503, 103);
            this.gboxUPBDest.TabIndex = 2;
            this.gboxUPBDest.TabStop = false;
            this.gboxUPBDest.Tag = "";
            this.gboxUPBDest.Text = "Upb in cui si storna";
            // 
            // txtUPBDest
            // 
            this.txtUPBDest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUPBDest.Location = new System.Drawing.Point(6, 77);
            this.txtUPBDest.Name = "txtUPBDest";
            this.txtUPBDest.Size = new System.Drawing.Size(487, 20);
            this.txtUPBDest.TabIndex = 15;
            this.txtUPBDest.Tag = "finview.codefin?incomeview.codefin";
            // 
            // txtDescrUPBDest
            // 
            this.txtDescrUPBDest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrUPBDest.Location = new System.Drawing.Point(175, 16);
            this.txtDescrUPBDest.Multiline = true;
            this.txtDescrUPBDest.Name = "txtDescrUPBDest";
            this.txtDescrUPBDest.ReadOnly = true;
            this.txtDescrUPBDest.Size = new System.Drawing.Size(320, 54);
            this.txtDescrUPBDest.TabIndex = 4;
            this.txtDescrUPBDest.TabStop = false;
            this.txtDescrUPBDest.Tag = "upb.title";
            // 
            // btnUPBDest
            // 
            this.btnUPBDest.BackColor = System.Drawing.SystemColors.Control;
            this.btnUPBDest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUPBDest.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUPBDest.Location = new System.Drawing.Point(8, 50);
            this.btnUPBDest.Name = "btnUPBDest";
            this.btnUPBDest.Size = new System.Drawing.Size(120, 20);
            this.btnUPBDest.TabIndex = 2;
            this.btnUPBDest.TabStop = false;
            this.btnUPBDest.Tag = "manage.upb.tree";
            this.btnUPBDest.Text = "U.P.B.";
            this.btnUPBDest.UseVisualStyleBackColor = false;
            // 
            // btnFinanziamento
            // 
            this.btnFinanziamento.Location = new System.Drawing.Point(6, 19);
            this.btnFinanziamento.Name = "btnFinanziamento";
            this.btnFinanziamento.Size = new System.Drawing.Size(128, 23);
            this.btnFinanziamento.TabIndex = 24;
            this.btnFinanziamento.Tag = "";
            this.btnFinanziamento.Text = "Finanziamento";
            this.btnFinanziamento.UseVisualStyleBackColor = true;
            this.btnFinanziamento.Click += new System.EventHandler(this.btnFinanziamento_Click);
            // 
            // txtUnderwriting
            // 
            this.txtUnderwriting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUnderwriting.Location = new System.Drawing.Point(140, 22);
            this.txtUnderwriting.Name = "txtUnderwriting";
            this.txtUnderwriting.ReadOnly = true;
            this.txtUnderwriting.Size = new System.Drawing.Size(783, 20);
            this.txtUnderwriting.TabIndex = 25;
            this.txtUnderwriting.Tag = "underwriting.title";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnFinanziamento);
            this.groupBox1.Controls.Add(this.txtUnderwriting);
            this.groupBox1.Location = new System.Drawing.Point(8, 239);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(929, 56);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 307);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Descrizione";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(16, 332);
            this.txtDescrizione.MaxLength = 150;
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(918, 44);
            this.txtDescrizione.TabIndex = 5;
            // 
            // FrmStornoTraUpb
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAnnulla;
            this.ClientSize = new System.Drawing.Size(946, 478);
            this.Controls.Add(this.txtDescrizione);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtImporto);
            this.Controls.Add(this.gboxUPBDest);
            this.Controls.Add(this.gboxBilAnnuale);
            this.Controls.Add(this.gboxUPBSource);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOK);
            this.Name = "FrmStornoTraUpb";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inserisci storno tra Upb";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmStornoTraUpb_FormClosing);
            this.gboxBilAnnuale.ResumeLayout(false);
            this.gboxBilAnnuale.PerformLayout();
            this.gboxUPBSource.ResumeLayout(false);
            this.gboxUPBSource.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.gboxUPBDest.ResumeLayout(false);
            this.gboxUPBDest.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxBilAnnuale;
        private System.Windows.Forms.CheckBox chkListTitle;
        private System.Windows.Forms.Button btnBilancio;
        private System.Windows.Forms.TextBox txtCodiceBilancio;
        private System.Windows.Forms.TextBox txtDenominazioneBilancio;
        public System.Windows.Forms.RadioButton rdbEntrata;
        public System.Windows.Forms.RadioButton rdbSpesa;
        private System.Windows.Forms.GroupBox gboxUPBSource;
        private System.Windows.Forms.TextBox txtDescrUPBSource;
        private System.Windows.Forms.Button btnUPBSource;
        private System.Windows.Forms.TextBox txtImporto;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox gboxUPBDest;
        private System.Windows.Forms.TextBox txtDescrUPBDest;
        private System.Windows.Forms.Button btnUPBDest;
        private System.Windows.Forms.Label label1;
        private vistaSubForm DS;
        private System.Windows.Forms.Button btnFinanziamento;
        private System.Windows.Forms.TextBox txtUnderwriting;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtUPBSource;
        private System.Windows.Forms.TextBox txtUPBDest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescrizione;
    }
}
