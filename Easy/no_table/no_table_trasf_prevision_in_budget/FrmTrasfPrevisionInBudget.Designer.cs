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

namespace no_table_trasf_prevision_in_budget {
    partial class FrmTrasfPrevisionInBudget {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing) {
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
        private void InitializeComponent () {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkSovrascrivi = new System.Windows.Forms.CheckBox();
            this.btnTrasferisciVariazioni = new System.Windows.Forms.Button();
            this.btnTrasferisciPrevisioni = new System.Windows.Forms.Button();
            this.DS = new no_table_trasf_prevision_in_budget.vistaForm();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkSovrascrivi);
            this.groupBox1.Controls.Add(this.btnTrasferisciVariazioni);
            this.groupBox1.Controls.Add(this.btnTrasferisciPrevisioni);
            this.groupBox1.Location = new System.Drawing.Point(12, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 125);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // chkSovrascrivi
            // 
            this.chkSovrascrivi.AutoSize = true;
            this.chkSovrascrivi.Location = new System.Drawing.Point(213, 85);
            this.chkSovrascrivi.Name = "chkSovrascrivi";
            this.chkSovrascrivi.Size = new System.Drawing.Size(177, 17);
            this.chkSovrascrivi.TabIndex = 11;
            this.chkSovrascrivi.Text = "Sovrascrivi Variazioni già Create";
            this.chkSovrascrivi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkSovrascrivi.UseVisualStyleBackColor = true;
            // 
            // btnTrasferisciVariazioni
            // 
            this.btnTrasferisciVariazioni.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnTrasferisciVariazioni.Location = new System.Drawing.Point(6, 70);
            this.btnTrasferisciVariazioni.Name = "btnTrasferisciVariazioni";
            this.btnTrasferisciVariazioni.Size = new System.Drawing.Size(194, 45);
            this.btnTrasferisciVariazioni.TabIndex = 10;
            this.btnTrasferisciVariazioni.Text = "Trasferisci Variazioni di Bilancio";
            this.btnTrasferisciVariazioni.UseVisualStyleBackColor = true;
            this.btnTrasferisciVariazioni.Click += new System.EventHandler(this.btnTrasferisciVariazioni_Click);
            // 
            // btnTrasferisciPrevisioni
            // 
            this.btnTrasferisciPrevisioni.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnTrasferisciPrevisioni.Location = new System.Drawing.Point(6, 20);
            this.btnTrasferisciPrevisioni.Name = "btnTrasferisciPrevisioni";
            this.btnTrasferisciPrevisioni.Size = new System.Drawing.Size(194, 45);
            this.btnTrasferisciPrevisioni.TabIndex = 1;
            this.btnTrasferisciPrevisioni.Text = "Trasferisci Previsioni di Bilancio";
            this.btnTrasferisciPrevisioni.UseVisualStyleBackColor = true;
            this.btnTrasferisciPrevisioni.Click += new System.EventHandler(this.btnTrasferisciPrevisioni_Click);
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(364, 216);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Tag = "";
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(427, 49);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(22, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(393, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "La procedura consente di trasferire le previsioni e le variazioni di bilancio in " +
    "previsioni e variazioni budget";
            // 
            // FrmTrasfPrevisionInBudget
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnTrasferisciPrevisioni;
            this.ClientSize = new System.Drawing.Size(451, 251);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmTrasfPrevisionInBudget";
            this.Text = "Trasferimento ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTrasferisciPrevisioni;
        public vistaForm DS;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTrasferisciVariazioni;
        private System.Windows.Forms.CheckBox chkSovrascrivi;

    }
}