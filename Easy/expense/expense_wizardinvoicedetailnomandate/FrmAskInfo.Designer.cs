
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


namespace expense_wizardinvoicedetailnomandate {
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
            this.cmbUPB = new System.Windows.Forms.ComboBox();
            this.gboxBilAnnuale = new System.Windows.Forms.GroupBox();
            this.chkListTitle = new System.Windows.Forms.CheckBox();
            this.chkListManager = new System.Windows.Forms.CheckBox();
            this.chkFilterAvailable = new System.Windows.Forms.CheckBox();
            this.btnBilancio = new System.Windows.Forms.Button();
            this.txtBilancio = new System.Windows.Forms.TextBox();
            this.txtDenominazioneBilancio = new System.Windows.Forms.TextBox();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.SubEntity_txtImportoMovimento = new System.Windows.Forms.TextBox();
            this.gboxManager = new System.Windows.Forms.GroupBox();
            this.cmbResponsabile = new System.Windows.Forms.ComboBox();
            this.BtnAnnulla = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtUPB = new System.Windows.Forms.TextBox();
            this.gboxUPB.SuspendLayout();
            this.gboxBilAnnuale.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.gboxManager.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboxUPB
            // 
            this.gboxUPB.Controls.Add(this.txtUPB);
            this.gboxUPB.Controls.Add(this.cmbUPB);
            this.gboxUPB.Location = new System.Drawing.Point(8, 96);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(405, 80);
            this.gboxUPB.TabIndex = 20;
            this.gboxUPB.TabStop = false;
            this.gboxUPB.Tag = "";
            this.gboxUPB.Text = "UPB da associare ai dettagli ai quali non è stato attribuito";
            // 
            // cmbUPB
            // 
            this.cmbUPB.DisplayMember = "codeupb";
            this.cmbUPB.Location = new System.Drawing.Point(6, 36);
            this.cmbUPB.Name = "cmbUPB";
            this.cmbUPB.Size = new System.Drawing.Size(183, 21);
            this.cmbUPB.TabIndex = 10;
            this.cmbUPB.Tag = "invoicedetail.idupb";
            this.cmbUPB.ValueMember = "idupb";
            this.cmbUPB.SelectedIndexChanged += new System.EventHandler(this.cmbUPB_SelectedIndexChanged);
            this.cmbUPB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_KeyPress);
            this.cmbUPB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb_KeyDown);

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
            this.gboxBilAnnuale.Location = new System.Drawing.Point(8, 178);
            this.gboxBilAnnuale.Name = "gboxBilAnnuale";
            this.gboxBilAnnuale.Size = new System.Drawing.Size(405, 104);
            this.gboxBilAnnuale.TabIndex = 19;
            this.gboxBilAnnuale.TabStop = false;
            this.gboxBilAnnuale.Tag = "AutoManage.txtCodiceBilancio.treesupb.(idupb=\'0001\')";
            // 
            // chkListTitle
            // 
            this.chkListTitle.Location = new System.Drawing.Point(8, 40);
            this.chkListTitle.Name = "chkListTitle";
            this.chkListTitle.Size = new System.Drawing.Size(296, 16);
            this.chkListTitle.TabIndex = 12;
            this.chkListTitle.TabStop = false;
            this.chkListTitle.Text = "Cerca per denominazione";
            // 
            // chkListManager
            // 
            this.chkListManager.Location = new System.Drawing.Point(8, 24);
            this.chkListManager.Name = "chkListManager";
            this.chkListManager.Size = new System.Drawing.Size(288, 16);
            this.chkListManager.TabIndex = 11;
            this.chkListManager.TabStop = false;
            this.chkListManager.Text = "Elenca per responsabile";
            // 
            // chkFilterAvailable
            // 
            this.chkFilterAvailable.Checked = true;
            this.chkFilterAvailable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterAvailable.Location = new System.Drawing.Point(8, 8);
            this.chkFilterAvailable.Name = "chkFilterAvailable";
            this.chkFilterAvailable.Size = new System.Drawing.Size(288, 16);
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
            this.btnBilancio.Location = new System.Drawing.Point(8, 56);
            this.btnBilancio.Name = "btnBilancio";
            this.btnBilancio.Size = new System.Drawing.Size(112, 20);
            this.btnBilancio.TabIndex = 1;
            this.btnBilancio.TabStop = false;
            this.btnBilancio.Tag = "";
            this.btnBilancio.Text = "Bilancio";
            this.btnBilancio.UseVisualStyleBackColor = false;
            this.btnBilancio.Click += new System.EventHandler(this.btnBilancio_Click);
            // 
            // txtBilancio
            // 
            this.txtBilancio.Location = new System.Drawing.Point(8, 80);
            this.txtBilancio.Name = "txtBilancio";
            this.txtBilancio.Size = new System.Drawing.Size(112, 20);
            this.txtBilancio.TabIndex = 2;
            this.txtBilancio.Tag = "finview.codefin?expenseview.codefin";
            this.txtBilancio.Click += new System.EventHandler(this.txtCodiceBilancio_Leave);
            this.txtBilancio.Leave += new System.EventHandler(this.txtCodiceBilancio_Leave);
            // 
            // txtDenominazioneBilancio
            // 
            this.txtDenominazioneBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenominazioneBilancio.Location = new System.Drawing.Point(128, 56);
            this.txtDenominazioneBilancio.Multiline = true;
            this.txtDenominazioneBilancio.Name = "txtDenominazioneBilancio";
            this.txtDenominazioneBilancio.ReadOnly = true;
            this.txtDenominazioneBilancio.Size = new System.Drawing.Size(269, 42);
            this.txtDenominazioneBilancio.TabIndex = 3;
            this.txtDenominazioneBilancio.TabStop = false;
            this.txtDenominazioneBilancio.Tag = "finview.title";
            // 
            // groupBox18
            // 
            this.groupBox18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox18.Controls.Add(this.SubEntity_txtImportoMovimento);
            this.groupBox18.Location = new System.Drawing.Point(8, 8);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(405, 40);
            this.groupBox18.TabIndex = 18;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Importo del movimento che sarà generato";
            // 
            // SubEntity_txtImportoMovimento
            // 
            this.SubEntity_txtImportoMovimento.Location = new System.Drawing.Point(8, 16);
            this.SubEntity_txtImportoMovimento.Name = "SubEntity_txtImportoMovimento";
            this.SubEntity_txtImportoMovimento.ReadOnly = true;
            this.SubEntity_txtImportoMovimento.Size = new System.Drawing.Size(112, 20);
            this.SubEntity_txtImportoMovimento.TabIndex = 1;
            this.SubEntity_txtImportoMovimento.Tag = "expenseyear.amount?expenseview.ayearstartamount";
            // 
            // gboxManager
            // 
            this.gboxManager.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxManager.Controls.Add(this.cmbResponsabile);
            this.gboxManager.Location = new System.Drawing.Point(8, 48);
            this.gboxManager.Name = "gboxManager";
            this.gboxManager.Size = new System.Drawing.Size(405, 40);
            this.gboxManager.TabIndex = 17;
            this.gboxManager.TabStop = false;
            this.gboxManager.Text = "Responsabile";
            // 
            // cmbResponsabile
            // 
            this.cmbResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbResponsabile.DisplayMember = "title";
            this.cmbResponsabile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResponsabile.ItemHeight = 13;
            this.cmbResponsabile.Location = new System.Drawing.Point(8, 14);
            this.cmbResponsabile.Name = "cmbResponsabile";
            this.cmbResponsabile.Size = new System.Drawing.Size(389, 21);
            this.cmbResponsabile.TabIndex = 1;
            this.cmbResponsabile.Tag = "expense.idman";
            this.cmbResponsabile.ValueMember = "idman";
            this.cmbResponsabile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_KeyPress);
            this.cmbResponsabile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb_KeyDown);

            // 
            // BtnAnnulla
            // 
            this.BtnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnAnnulla.Location = new System.Drawing.Point(334, 305);
            this.BtnAnnulla.Name = "BtnAnnulla";
            this.BtnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.BtnAnnulla.TabIndex = 16;
            this.BtnAnnulla.Text = "Annulla";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(244, 305);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 15;
            this.btnOk.Text = "Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtUPB
            // 
            this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUPB.Location = new System.Drawing.Point(195, 19);
            this.txtUPB.Multiline = true;
            this.txtUPB.Name = "txtUPB";
            this.txtUPB.ReadOnly = true;
            this.txtUPB.Size = new System.Drawing.Size(202, 51);
            this.txtUPB.TabIndex = 14;
            this.txtUPB.TabStop = false;
            this.txtUPB.Tag = "";
            // 
            // FrmAskInfo
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 335);
            this.Controls.Add(this.gboxUPB);
            this.Controls.Add(this.gboxBilAnnuale);
            this.Controls.Add(this.groupBox18);
            this.Controls.Add(this.gboxManager);
            this.Controls.Add(this.BtnAnnulla);
            this.Controls.Add(this.btnOk);
            this.Name = "FrmAskInfo";
            this.Text = "FrmAskInfo";
            this.gboxUPB.ResumeLayout(false);
            this.gboxUPB.PerformLayout();
            this.gboxBilAnnuale.ResumeLayout(false);
            this.gboxBilAnnuale.PerformLayout();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.gboxManager.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxUPB;
        private System.Windows.Forms.ComboBox cmbUPB;
        private System.Windows.Forms.GroupBox gboxBilAnnuale;
        private System.Windows.Forms.CheckBox chkListTitle;
        private System.Windows.Forms.CheckBox chkListManager;
        private System.Windows.Forms.CheckBox chkFilterAvailable;
        private System.Windows.Forms.Button btnBilancio;
        private System.Windows.Forms.TextBox txtBilancio;
        private System.Windows.Forms.TextBox txtDenominazioneBilancio;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.TextBox SubEntity_txtImportoMovimento;
        private System.Windows.Forms.GroupBox gboxManager;
        private System.Windows.Forms.ComboBox cmbResponsabile;
        private System.Windows.Forms.Button BtnAnnulla;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtUPB;
    }
}
