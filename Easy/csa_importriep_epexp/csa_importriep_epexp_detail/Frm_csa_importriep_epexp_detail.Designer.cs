
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


namespace csa_importriep_epexp_detail {
    partial class Frm_csa_importriep_epexp_detail {
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
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gboxSpesa = new System.Windows.Forms.GroupBox();
            this.btnLinkEpExp = new System.Windows.Forms.Button();
            this.btnRemoveEpExp = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNumImpegno = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtEsercImpegno = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbFaseImpBudget = new System.Windows.Forms.ComboBox();
            this.DS = new csa_importriep_epexp_detail.vistaForm();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtNumRiep = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtQuotaAmm1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.gboxSpesa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(411, 204);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 27;
            this.btnAnnulla.Text = "Annulla";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(331, 203);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 26;
            this.btnOK.Tag = "mainsave";
            this.btnOK.Text = "OK";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(167, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(144, 46);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "";
            this.groupBox1.Text = "Dettaglio";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(82, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(56, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Tag = "csa_importriep_epexp.ndetail";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(18, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numero:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gboxSpesa
            // 
            this.gboxSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxSpesa.Controls.Add(this.btnLinkEpExp);
            this.gboxSpesa.Controls.Add(this.btnRemoveEpExp);
            this.gboxSpesa.Controls.Add(this.label7);
            this.gboxSpesa.Controls.Add(this.txtNumImpegno);
            this.gboxSpesa.Controls.Add(this.label13);
            this.gboxSpesa.Controls.Add(this.txtEsercImpegno);
            this.gboxSpesa.Controls.Add(this.label12);
            this.gboxSpesa.Controls.Add(this.cmbFaseImpBudget);
            this.gboxSpesa.Location = new System.Drawing.Point(12, 109);
            this.gboxSpesa.Name = "gboxSpesa";
            this.gboxSpesa.Size = new System.Drawing.Size(481, 87);
            this.gboxSpesa.TabIndex = 24;
            this.gboxSpesa.TabStop = false;
            this.gboxSpesa.Text = "Movimento di Budget a cui collegare il contributo";
            // 
            // btnLinkEpExp
            // 
            this.btnLinkEpExp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLinkEpExp.Location = new System.Drawing.Point(272, 44);
            this.btnLinkEpExp.Name = "btnLinkEpExp";
            this.btnLinkEpExp.Size = new System.Drawing.Size(93, 23);
            this.btnLinkEpExp.TabIndex = 7;
            this.btnLinkEpExp.TabStop = false;
            this.btnLinkEpExp.Text = "Collega";
            this.btnLinkEpExp.Click += new System.EventHandler(this.btnLinkEpExp_Click);
            // 
            // btnRemoveEpExp
            // 
            this.btnRemoveEpExp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveEpExp.Location = new System.Drawing.Point(374, 44);
            this.btnRemoveEpExp.Name = "btnRemoveEpExp";
            this.btnRemoveEpExp.Size = new System.Drawing.Size(100, 23);
            this.btnRemoveEpExp.TabIndex = 6;
            this.btnRemoveEpExp.TabStop = false;
            this.btnRemoveEpExp.Text = "Scollega";
            this.btnRemoveEpExp.Click += new System.EventHandler(this.btnRemoveEpExp_Click);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(15, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Fase";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumImpegno
            // 
            this.txtNumImpegno.Location = new System.Drawing.Point(176, 47);
            this.txtNumImpegno.Name = "txtNumImpegno";
            this.txtNumImpegno.ReadOnly = true;
            this.txtNumImpegno.Size = new System.Drawing.Size(64, 20);
            this.txtNumImpegno.TabIndex = 4;
            this.txtNumImpegno.Tag = "";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(116, 47);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 16);
            this.label13.TabIndex = 0;
            this.label13.Text = "Numero:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercImpegno
            // 
            this.txtEsercImpegno.Location = new System.Drawing.Point(64, 46);
            this.txtEsercImpegno.Name = "txtEsercImpegno";
            this.txtEsercImpegno.ReadOnly = true;
            this.txtEsercImpegno.Size = new System.Drawing.Size(40, 20);
            this.txtEsercImpegno.TabIndex = 3;
            this.txtEsercImpegno.Tag = "";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(3, 47);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 16);
            this.label12.TabIndex = 0;
            this.label12.Text = "Esercizio:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbFaseImpBudget
            // 
            this.cmbFaseImpBudget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFaseImpBudget.DataSource = this.DS.fase_epexp;
            this.cmbFaseImpBudget.DisplayMember = "descrizione";
            this.cmbFaseImpBudget.Location = new System.Drawing.Point(64, 19);
            this.cmbFaseImpBudget.Name = "cmbFaseImpBudget";
            this.cmbFaseImpBudget.Size = new System.Drawing.Size(274, 21);
            this.cmbFaseImpBudget.TabIndex = 2;
            this.cmbFaseImpBudget.Tag = "";
            this.cmbFaseImpBudget.ValueMember = "nphase";
            this.cmbFaseImpBudget.SelectedIndexChanged += new System.EventHandler(this.cmbFaseImpBudget_SelectedIndexChanged);
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtNumRiep);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(144, 46);
            this.groupBox4.TabIndex = 23;
            this.groupBox4.TabStop = false;
            this.groupBox4.Tag = "";
            this.groupBox4.Text = "Riepilogo";
            // 
            // txtNumRiep
            // 
            this.txtNumRiep.Location = new System.Drawing.Point(82, 18);
            this.txtNumRiep.Name = "txtNumRiep";
            this.txtNumRiep.Size = new System.Drawing.Size(56, 20);
            this.txtNumRiep.TabIndex = 3;
            this.txtNumRiep.Tag = "csa_importriep_epexp.idriep";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(18, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Numero:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtQuotaAmm1);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Location = new System.Drawing.Point(12, 67);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(144, 38);
            this.groupBox6.TabIndex = 22;
            this.groupBox6.TabStop = false;
            // 
            // txtQuotaAmm1
            // 
            this.txtQuotaAmm1.Location = new System.Drawing.Point(82, 12);
            this.txtQuotaAmm1.Name = "txtQuotaAmm1";
            this.txtQuotaAmm1.Size = new System.Drawing.Size(59, 20);
            this.txtQuotaAmm1.TabIndex = 17;
            this.txtQuotaAmm1.Tag = "csa_importriep_epexp.quota.fixed.4..%.100";
            this.txtQuotaAmm1.TextChanged += new System.EventHandler(this.txtQuotaAmm1_TextChanged);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(15, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 16);
            this.label9.TabIndex = 18;
            this.label9.Text = "Quota:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Frm_csa_importriep_epexp_detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 233);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gboxSpesa);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox6);
            this.Name = "Frm_csa_importriep_epexp_detail";
            this.Text = "Frm_csa_importriep_epexp_detail";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gboxSpesa.ResumeLayout(false);
            this.gboxSpesa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

            }

        #endregion
        public vistaForm DS;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gboxSpesa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNumImpegno;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtEsercImpegno;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbFaseImpBudget;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtNumRiep;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtQuotaAmm1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnLinkEpExp;
        private System.Windows.Forms.Button btnRemoveEpExp;
        }
    }
