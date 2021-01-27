
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


namespace AskInfo {
    partial class FrmAskInfo {
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
            this.gboxUPB = new System.Windows.Forms.GroupBox();
            this.btnUPB = new System.Windows.Forms.Button();
            this.txtUPB = new System.Windows.Forms.TextBox();
            this.txtDescrUPB = new System.Windows.Forms.TextBox();
            this.gboxBilAnnuale = new System.Windows.Forms.GroupBox();
            this.chkListTitle = new System.Windows.Forms.CheckBox();
            this.chkListManager = new System.Windows.Forms.CheckBox();
            this.chkFilterAvailable = new System.Windows.Forms.CheckBox();
            this.btnBilancio = new System.Windows.Forms.Button();
            this.txtBilancio = new System.Windows.Forms.TextBox();
            this.txtDenominazioneBilancio = new System.Windows.Forms.TextBox();
            this.gboxImporto = new System.Windows.Forms.GroupBox();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.gboxManager = new System.Windows.Forms.GroupBox();
            this.txtResponsabile = new System.Windows.Forms.TextBox();
            this.BtnAnnulla = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.cmbFasi = new System.Windows.Forms.ComboBox();
            this.gboxFasi = new System.Windows.Forms.GroupBox();
            this.gboxUPB.SuspendLayout();
            this.gboxBilAnnuale.SuspendLayout();
            this.gboxImporto.SuspendLayout();
            this.gboxManager.SuspendLayout();
            this.gboxFasi.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboxUPB
            // 
            this.gboxUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxUPB.Controls.Add(this.btnUPB);
            this.gboxUPB.Controls.Add(this.txtUPB);
            this.gboxUPB.Controls.Add(this.txtDescrUPB);
            this.gboxUPB.Location = new System.Drawing.Point(10, 93);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(460, 111);
            this.gboxUPB.TabIndex = 3;
            this.gboxUPB.TabStop = false;
            this.gboxUPB.Tag = "";
            this.gboxUPB.Text = "UPB da associare ai dettagli ai quali non è stato attribuito";
            // 
            // btnUPB
            // 
            this.btnUPB.Location = new System.Drawing.Point(8, 56);
            this.btnUPB.Name = "btnUPB";
            this.btnUPB.Size = new System.Drawing.Size(75, 23);
            this.btnUPB.TabIndex = 14;
            this.btnUPB.Text = "UPB";
            this.btnUPB.UseVisualStyleBackColor = true;
            // 
            // txtUPB
            // 
            this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUPB.Location = new System.Drawing.Point(6, 85);
            this.txtUPB.Name = "txtUPB";
            this.txtUPB.Size = new System.Drawing.Size(444, 20);
            this.txtUPB.TabIndex = 13;
            this.txtUPB.Tag = "finview.codefin?incomeview.codefin";
            // 
            // txtDescrUPB
            // 
            this.txtDescrUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrUPB.Location = new System.Drawing.Point(226, 16);
            this.txtDescrUPB.Multiline = true;
            this.txtDescrUPB.Name = "txtDescrUPB";
            this.txtDescrUPB.ReadOnly = true;
            this.txtDescrUPB.Size = new System.Drawing.Size(226, 63);
            this.txtDescrUPB.TabIndex = 12;
            this.txtDescrUPB.TabStop = false;
            this.txtDescrUPB.Tag = "";
            // 
            // gboxBilAnnuale
            // 
            this.gboxBilAnnuale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxBilAnnuale.Controls.Add(this.chkListTitle);
            this.gboxBilAnnuale.Controls.Add(this.chkListManager);
            this.gboxBilAnnuale.Controls.Add(this.chkFilterAvailable);
            this.gboxBilAnnuale.Controls.Add(this.btnBilancio);
            this.gboxBilAnnuale.Controls.Add(this.txtBilancio);
            this.gboxBilAnnuale.Controls.Add(this.txtDenominazioneBilancio);
            this.gboxBilAnnuale.Location = new System.Drawing.Point(6, 210);
            this.gboxBilAnnuale.Name = "gboxBilAnnuale";
            this.gboxBilAnnuale.Size = new System.Drawing.Size(461, 124);
            this.gboxBilAnnuale.TabIndex = 4;
            this.gboxBilAnnuale.TabStop = false;
            this.gboxBilAnnuale.Tag = "";
            // 
            // chkListTitle
            // 
            this.chkListTitle.Location = new System.Drawing.Point(10, 53);
            this.chkListTitle.Name = "chkListTitle";
            this.chkListTitle.Size = new System.Drawing.Size(182, 16);
            this.chkListTitle.TabIndex = 12;
            this.chkListTitle.TabStop = false;
            this.chkListTitle.Text = "Cerca per denominazione";
            // 
            // chkListManager
            // 
            this.chkListManager.Location = new System.Drawing.Point(10, 37);
            this.chkListManager.Name = "chkListManager";
            this.chkListManager.Size = new System.Drawing.Size(182, 16);
            this.chkListManager.TabIndex = 11;
            this.chkListManager.TabStop = false;
            this.chkListManager.Text = "Elenca per responsabile";
            // 
            // chkFilterAvailable
            // 
            this.chkFilterAvailable.Checked = true;
            this.chkFilterAvailable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterAvailable.Location = new System.Drawing.Point(10, 21);
            this.chkFilterAvailable.Name = "chkFilterAvailable";
            this.chkFilterAvailable.Size = new System.Drawing.Size(216, 16);
            this.chkFilterAvailable.TabIndex = 10;
            this.chkFilterAvailable.TabStop = false;
            this.chkFilterAvailable.Text = "Filtra per disponibilità sufficiente";
            // 
            // btnBilancio
            // 
            this.btnBilancio.BackColor = System.Drawing.SystemColors.Control;
            this.btnBilancio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBilancio.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBilancio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilancio.ImageIndex = 0;
            this.btnBilancio.Location = new System.Drawing.Point(10, 69);
            this.btnBilancio.Name = "btnBilancio";
            this.btnBilancio.Size = new System.Drawing.Size(112, 20);
            this.btnBilancio.TabIndex = 1;
            this.btnBilancio.TabStop = false;
            this.btnBilancio.Tag = "";
            this.btnBilancio.Text = "Bilancio";
            this.btnBilancio.UseVisualStyleBackColor = false;
            // 
            // txtBilancio
            // 
            this.txtBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBilancio.Location = new System.Drawing.Point(10, 93);
            this.txtBilancio.Name = "txtBilancio";
            this.txtBilancio.Size = new System.Drawing.Size(447, 20);
            this.txtBilancio.TabIndex = 2;
            this.txtBilancio.Tag = "finview.codefin?incomeview.codefin";
            // 
            // txtDenominazioneBilancio
            // 
            this.txtDenominazioneBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenominazioneBilancio.Location = new System.Drawing.Point(232, 27);
            this.txtDenominazioneBilancio.Multiline = true;
            this.txtDenominazioneBilancio.Name = "txtDenominazioneBilancio";
            this.txtDenominazioneBilancio.ReadOnly = true;
            this.txtDenominazioneBilancio.Size = new System.Drawing.Size(225, 60);
            this.txtDenominazioneBilancio.TabIndex = 3;
            this.txtDenominazioneBilancio.TabStop = false;
            this.txtDenominazioneBilancio.Tag = "finview.title";
            // 
            // gboxImporto
            // 
            this.gboxImporto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxImporto.Controls.Add(this.txtImporto);
            this.gboxImporto.Location = new System.Drawing.Point(10, 6);
            this.gboxImporto.Name = "gboxImporto";
            this.gboxImporto.Size = new System.Drawing.Size(461, 40);
            this.gboxImporto.TabIndex = 1;
            this.gboxImporto.TabStop = false;
            this.gboxImporto.Text = "Importo del movimento che sarà generato";
            this.gboxImporto.Visible = false;
            // 
            // txtImporto
            // 
            this.txtImporto.Location = new System.Drawing.Point(8, 16);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.ReadOnly = true;
            this.txtImporto.Size = new System.Drawing.Size(112, 20);
            this.txtImporto.TabIndex = 1;
            this.txtImporto.TabStop = false;
            this.txtImporto.Tag = "incomeyear.amount?incomeview.ayearstartamount";
            this.txtImporto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gboxManager
            // 
            this.gboxManager.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxManager.Controls.Add(this.txtResponsabile);
            this.gboxManager.Location = new System.Drawing.Point(10, 46);
            this.gboxManager.Name = "gboxManager";
            this.gboxManager.Size = new System.Drawing.Size(461, 40);
            this.gboxManager.TabIndex = 2;
            this.gboxManager.TabStop = false;
            this.gboxManager.Text = "Responsabile";
            // 
            // txtResponsabile
            // 
            this.txtResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResponsabile.Location = new System.Drawing.Point(6, 14);
            this.txtResponsabile.Name = "txtResponsabile";
            this.txtResponsabile.Size = new System.Drawing.Size(441, 20);
            this.txtResponsabile.TabIndex = 3;
            this.txtResponsabile.Tag = "finview.codefin?incomeview.codefin";
            // 
            // BtnAnnulla
            // 
            this.BtnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnAnnulla.Location = new System.Drawing.Point(387, 407);
            this.BtnAnnulla.Name = "BtnAnnulla";
            this.BtnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.BtnAnnulla.TabIndex = 17;
            this.BtnAnnulla.Text = "Annulla";
            this.BtnAnnulla.Click += new System.EventHandler(this.BtnAnnulla_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(275, 407);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 16;
            this.btnOk.Text = "Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // cmbFasi
            // 
            this.cmbFasi.Location = new System.Drawing.Point(12, 19);
            this.cmbFasi.Name = "cmbFasi";
            this.cmbFasi.Size = new System.Drawing.Size(306, 21);
            this.cmbFasi.TabIndex = 26;
            // 
            // gboxFasi
            // 
            this.gboxFasi.Controls.Add(this.cmbFasi);
            this.gboxFasi.Location = new System.Drawing.Point(6, 340);
            this.gboxFasi.Name = "gboxFasi";
            this.gboxFasi.Size = new System.Drawing.Size(461, 47);
            this.gboxFasi.TabIndex = 27;
            this.gboxFasi.TabStop = false;
            this.gboxFasi.Text = "Seleziona la fase del movimento da collegare";
            // 
            // FrmAskInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 436);
            this.Controls.Add(this.gboxFasi);
            this.Controls.Add(this.gboxUPB);
            this.Controls.Add(this.gboxBilAnnuale);
            this.Controls.Add(this.gboxImporto);
            this.Controls.Add(this.gboxManager);
            this.Controls.Add(this.BtnAnnulla);
            this.Controls.Add(this.btnOk);
            this.Name = "FrmAskInfo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "m";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAskInfo_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmAskInfo_FormClosed);
            this.gboxUPB.ResumeLayout(false);
            this.gboxUPB.PerformLayout();
            this.gboxBilAnnuale.ResumeLayout(false);
            this.gboxBilAnnuale.PerformLayout();
            this.gboxImporto.ResumeLayout(false);
            this.gboxImporto.PerformLayout();
            this.gboxManager.ResumeLayout(false);
            this.gboxManager.PerformLayout();
            this.gboxFasi.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnUPB;
        private System.Windows.Forms.TextBox txtUPB;
        private System.Windows.Forms.TextBox txtDescrUPB;
        private System.Windows.Forms.CheckBox chkListTitle;
        private System.Windows.Forms.CheckBox chkListManager;
        private System.Windows.Forms.CheckBox chkFilterAvailable;
        private System.Windows.Forms.Button btnBilancio;
        private System.Windows.Forms.TextBox txtBilancio;
        private System.Windows.Forms.TextBox txtDenominazioneBilancio;
        private System.Windows.Forms.GroupBox gboxImporto;
        private System.Windows.Forms.TextBox txtImporto;
        private System.Windows.Forms.TextBox txtResponsabile;
        private System.Windows.Forms.Button BtnAnnulla;
        private System.Windows.Forms.Button btnOk;
        public System.Windows.Forms.GroupBox gboxUPB;
        public System.Windows.Forms.GroupBox gboxBilAnnuale;
        public System.Windows.Forms.GroupBox gboxManager;
        public System.Windows.Forms.ComboBox cmbFasi;
        private System.Windows.Forms.GroupBox gboxFasi;
    }
}
