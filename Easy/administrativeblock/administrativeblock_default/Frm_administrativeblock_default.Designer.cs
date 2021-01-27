
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


namespace administrativeblock_default {
    partial class Frm_administrativeblock_default {
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
            this.DS = new administrativeblock_default.vistaForm();
            this.lblPartitaIVA = new System.Windows.Forms.Label();
            this.txtPartitaIva = new System.Windows.Forms.TextBox();
            this.lblCodiceFiscale = new System.Windows.Forms.Label();
            this.txtCodiceFiscale = new System.Windows.Forms.TextBox();
            this.lblDenominazione = new System.Windows.Forms.Label();
            this.txtDenominazione = new System.Windows.Forms.TextBox();
            this.txtProvvedimento = new System.Windows.Forms.TextBox();
            this.txtDataProvv = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // lblPartitaIVA
            // 
            this.lblPartitaIVA.Location = new System.Drawing.Point(36, 118);
            this.lblPartitaIVA.Name = "lblPartitaIVA";
            this.lblPartitaIVA.Size = new System.Drawing.Size(64, 19);
            this.lblPartitaIVA.TabIndex = 178;
            this.lblPartitaIVA.Text = "Partita IVA";
            this.lblPartitaIVA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPartitaIva
            // 
            this.txtPartitaIva.Location = new System.Drawing.Point(108, 118);
            this.txtPartitaIva.Name = "txtPartitaIva";
            this.txtPartitaIva.Size = new System.Drawing.Size(224, 20);
            this.txtPartitaIva.TabIndex = 3;
            this.txtPartitaIva.Tag = "administrativeblock.p_iva";
            // 
            // lblCodiceFiscale
            // 
            this.lblCodiceFiscale.Location = new System.Drawing.Point(12, 86);
            this.lblCodiceFiscale.Name = "lblCodiceFiscale";
            this.lblCodiceFiscale.Size = new System.Drawing.Size(88, 19);
            this.lblCodiceFiscale.TabIndex = 177;
            this.lblCodiceFiscale.Text = "Codice Fiscale";
            this.lblCodiceFiscale.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCodiceFiscale
            // 
            this.txtCodiceFiscale.Location = new System.Drawing.Point(108, 86);
            this.txtCodiceFiscale.Name = "txtCodiceFiscale";
            this.txtCodiceFiscale.Size = new System.Drawing.Size(224, 20);
            this.txtCodiceFiscale.TabIndex = 2;
            this.txtCodiceFiscale.Tag = "administrativeblock.cf";
            // 
            // lblDenominazione
            // 
            this.lblDenominazione.Location = new System.Drawing.Point(12, 48);
            this.lblDenominazione.Name = "lblDenominazione";
            this.lblDenominazione.Size = new System.Drawing.Size(88, 18);
            this.lblDenominazione.TabIndex = 176;
            this.lblDenominazione.Text = "Denominazione";
            this.lblDenominazione.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDenominazione
            // 
            this.txtDenominazione.Location = new System.Drawing.Point(108, 48);
            this.txtDenominazione.Name = "txtDenominazione";
            this.txtDenominazione.Size = new System.Drawing.Size(568, 20);
            this.txtDenominazione.TabIndex = 1;
            this.txtDenominazione.Tag = "administrativeblock.title";
            // 
            // txtProvvedimento
            // 
            this.txtProvvedimento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProvvedimento.Location = new System.Drawing.Point(113, 27);
            this.txtProvvedimento.Multiline = true;
            this.txtProvvedimento.Name = "txtProvvedimento";
            this.txtProvvedimento.Size = new System.Drawing.Size(540, 44);
            this.txtProvvedimento.TabIndex = 2;
            this.txtProvvedimento.Tag = "administrativeblock.enactmentstart";
            // 
            // txtDataProvv
            // 
            this.txtDataProvv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataProvv.Location = new System.Drawing.Point(6, 51);
            this.txtDataProvv.Name = "txtDataProvv";
            this.txtDataProvv.Size = new System.Drawing.Size(88, 20);
            this.txtDataProvv.TabIndex = 1;
            this.txtDataProvv.Tag = "administrativeblock.start";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Location = new System.Drawing.Point(6, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 181;
            this.label6.Text = "Data";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(112, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 182;
            this.label1.Text = "Provvedimento";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(110, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 186;
            this.label2.Text = "Provvedimento";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(113, 32);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(540, 45);
            this.textBox1.TabIndex = 2;
            this.textBox1.Tag = "administrativeblock.enactmentstop";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(6, 57);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(85, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.Tag = "administrativeblock.stop";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(7, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 18);
            this.label3.TabIndex = 185;
            this.label3.Text = "Data";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtDataProvv);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtProvvedimento);
            this.groupBox1.Location = new System.Drawing.Point(11, 144);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(659, 79);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inizio Fermo";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(11, 229);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(659, 83);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fine Fermo";
            // 
            // Frm_administrativeblock_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 324);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblPartitaIVA);
            this.Controls.Add(this.txtPartitaIva);
            this.Controls.Add(this.lblCodiceFiscale);
            this.Controls.Add(this.txtCodiceFiscale);
            this.Controls.Add(this.lblDenominazione);
            this.Controls.Add(this.txtDenominazione);
            this.Name = "Frm_administrativeblock_default";
            this.Text = "Frm_administrativeblock_default";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.Label lblPartitaIVA;
        private System.Windows.Forms.TextBox txtPartitaIva;
        private System.Windows.Forms.Label lblCodiceFiscale;
        private System.Windows.Forms.TextBox txtCodiceFiscale;
        private System.Windows.Forms.Label lblDenominazione;
        private System.Windows.Forms.TextBox txtDenominazione;
        private System.Windows.Forms.TextBox txtProvvedimento;
        private System.Windows.Forms.TextBox txtDataProvv;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;

    }
}
