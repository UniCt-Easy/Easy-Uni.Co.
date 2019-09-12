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

ï»¿namespace incomebill_default {
    partial class Frm_incomebill_default {
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
            this.DS = new incomebill_default.vistaForm();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBolletta = new System.Windows.Forms.TextBox();
            this.btnBolletta = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(263, 139);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(88, 23);
            this.btnAnnulla.TabIndex = 34;
            this.btnAnnulla.TabStop = false;
            this.btnAnnulla.Text = "Annulla";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(135, 139);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(88, 23);
            this.btnOK.TabIndex = 33;
            this.btnOK.Tag = "mainsave";
            this.btnOK.Text = "OK";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Importo";
            // 
            // txtImporto
            // 
            this.txtImporto.Location = new System.Drawing.Point(99, 98);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.Size = new System.Drawing.Size(113, 20);
            this.txtImporto.TabIndex = 31;
            this.txtImporto.Tag = "incomebill.amount";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Esercizio";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(69, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(82, 20);
            this.textBox1.TabIndex = 29;
            this.textBox1.Tag = "incomebill.ybill.year";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtBolletta);
            this.groupBox2.Controls.Add(this.btnBolletta);
            this.groupBox2.Location = new System.Drawing.Point(12, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(215, 43);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "AutoChoose.txtBolletta.default.(active = \'S\')";
            // 
            // txtBolletta
            // 
            this.txtBolletta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBolletta.Location = new System.Drawing.Point(121, 16);
            this.txtBolletta.Name = "txtBolletta";
            this.txtBolletta.Size = new System.Drawing.Size(79, 20);
            this.txtBolletta.TabIndex = 2;
            this.txtBolletta.Tag = "bill.nbill?incomebill.nbill";
            // 
            // btnBolletta
            // 
            this.btnBolletta.Location = new System.Drawing.Point(9, 14);
            this.btnBolletta.Name = "btnBolletta";
            this.btnBolletta.Size = new System.Drawing.Size(104, 23);
            this.btnBolletta.TabIndex = 0;
            this.btnBolletta.TabStop = false;
            this.btnBolletta.Tag = "choose.bill.default.((active= \'S\') AND (isnull(total,0)-isnull(reduction,0)>covered) AND (ISNULL(toregularize,0)>0))" +
    "";
            this.btnBolletta.Text = "N.Bolletta";
            this.btnBolletta.UseVisualStyleBackColor = true;
            // 
            // Frm_incomebill_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 173);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtImporto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "Frm_incomebill_default";
            this.Text = "Frm_incomebill_default";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtImporto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtBolletta;
        private System.Windows.Forms.Button btnBolletta;

    }
}