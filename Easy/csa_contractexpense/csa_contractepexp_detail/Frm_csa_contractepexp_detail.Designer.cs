
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


namespace csa_contractepexp_detail
{
    partial class Frm_csa_contractepexp_detail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOk = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.txtQuota = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DS = new csa_contractepexp_detail.vistaForm();
            this.gboxImponibile = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFaseImpBudget = new System.Windows.Forms.ComboBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.btnLinkEpExp = new System.Windows.Forms.Button();
            this.btnRemoveEpExp = new System.Windows.Forms.Button();
            this.txtNumImpegno = new System.Windows.Forms.TextBox();
            this.txtEsercizioImpegno = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.gboxImponibile.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(314, 153);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Tag = "mainsave";
            this.btnOk.Text = "Ok";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(410, 153);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 7;
            this.btnAnnulla.Text = "Annulla";
            // 
            // txtQuota
            // 
            this.txtQuota.Location = new System.Drawing.Point(72, 17);
            this.txtQuota.Name = "txtQuota";
            this.txtQuota.Size = new System.Drawing.Size(72, 20);
            this.txtQuota.TabIndex = 11;
            this.txtQuota.Tag = "csa_contractepexp.quota.fixed.4..%.100";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Quota:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // gboxImponibile
            // 
            this.gboxImponibile.Controls.Add(this.label1);
            this.gboxImponibile.Controls.Add(this.cmbFaseImpBudget);
            this.gboxImponibile.Controls.Add(this.label34);
            this.gboxImponibile.Controls.Add(this.label33);
            this.gboxImponibile.Controls.Add(this.btnLinkEpExp);
            this.gboxImponibile.Controls.Add(this.btnRemoveEpExp);
            this.gboxImponibile.Controls.Add(this.txtNumImpegno);
            this.gboxImponibile.Controls.Add(this.txtEsercizioImpegno);
            this.gboxImponibile.Location = new System.Drawing.Point(16, 49);
            this.gboxImponibile.Name = "gboxImponibile";
            this.gboxImponibile.Size = new System.Drawing.Size(477, 90);
            this.gboxImponibile.TabIndex = 46;
            this.gboxImponibile.TabStop = false;
            this.gboxImponibile.Text = "Impegno di Budget a cui collegare il Lordo";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Fase";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbFaseImpBudget
            // 
            this.cmbFaseImpBudget.DataSource = this.DS.fase_epexp;
            this.cmbFaseImpBudget.DisplayMember = "descrizione";
            this.cmbFaseImpBudget.Location = new System.Drawing.Point(63, 19);
            this.cmbFaseImpBudget.Name = "cmbFaseImpBudget";
            this.cmbFaseImpBudget.Size = new System.Drawing.Size(189, 21);
            this.cmbFaseImpBudget.TabIndex = 11;
            this.cmbFaseImpBudget.Tag = "";
            this.cmbFaseImpBudget.ValueMember = "nphase";
            this.cmbFaseImpBudget.SelectedIndexChanged += new System.EventHandler(this.cmbFaseImpBudget_SelectedIndexChanged);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(116, 57);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(44, 13);
            this.label34.TabIndex = 7;
            this.label34.Text = "Numero";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(9, 58);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(49, 13);
            this.label33.TabIndex = 6;
            this.label33.Text = "Esercizio";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnLinkEpExp
            // 
            this.btnLinkEpExp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLinkEpExp.Location = new System.Drawing.Point(239, 51);
            this.btnLinkEpExp.Name = "btnLinkEpExp";
            this.btnLinkEpExp.Size = new System.Drawing.Size(111, 23);
            this.btnLinkEpExp.TabIndex = 5;
            this.btnLinkEpExp.TabStop = false;
            this.btnLinkEpExp.Text = "Collega";
            this.btnLinkEpExp.Click += new System.EventHandler(this.btnLinkEpExp_Click);
            // 
            // btnRemoveEpExp
            // 
            this.btnRemoveEpExp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveEpExp.Location = new System.Drawing.Point(362, 52);
            this.btnRemoveEpExp.Name = "btnRemoveEpExp";
            this.btnRemoveEpExp.Size = new System.Drawing.Size(109, 23);
            this.btnRemoveEpExp.TabIndex = 4;
            this.btnRemoveEpExp.TabStop = false;
            this.btnRemoveEpExp.Text = "Scollega";
            this.btnRemoveEpExp.Click += new System.EventHandler(this.btnRemoveEpExp_Click);
            // 
            // txtNumImpegno
            // 
            this.txtNumImpegno.Location = new System.Drawing.Point(166, 53);
            this.txtNumImpegno.Name = "txtNumImpegno";
            this.txtNumImpegno.Size = new System.Drawing.Size(64, 20);
            this.txtNumImpegno.TabIndex = 3;
            this.txtNumImpegno.TabStop = false;
            this.txtNumImpegno.Tag = "";
            this.txtNumImpegno.Leave += new System.EventHandler(this.txtNumImpegno_Leave);
            // 
            // txtEsercizioImpegno
            // 
            this.txtEsercizioImpegno.Location = new System.Drawing.Point(63, 54);
            this.txtEsercizioImpegno.Name = "txtEsercizioImpegno";
            this.txtEsercizioImpegno.Size = new System.Drawing.Size(40, 20);
            this.txtEsercizioImpegno.TabIndex = 2;
            this.txtEsercizioImpegno.TabStop = false;
            this.txtEsercizioImpegno.Tag = "";
            this.txtEsercizioImpegno.Leave += new System.EventHandler(this.txtEsercizioImpegno_Leave);
            // 
            // Frm_csa_contractepexp_detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 198);
            this.Controls.Add(this.gboxImponibile);
            this.Controls.Add(this.txtQuota);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnAnnulla);
            this.Name = "Frm_csa_contractepexp_detail";
            this.Text = "Frm_csa_contractepexp_detail";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.gboxImponibile.ResumeLayout(false);
            this.gboxImponibile.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.TextBox txtQuota;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gboxImponibile;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Button btnLinkEpExp;
        private System.Windows.Forms.Button btnRemoveEpExp;
        private System.Windows.Forms.TextBox txtNumImpegno;
        private System.Windows.Forms.TextBox txtEsercizioImpegno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFaseImpBudget;

    }
}
