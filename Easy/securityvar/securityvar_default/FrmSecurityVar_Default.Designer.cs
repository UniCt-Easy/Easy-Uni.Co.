
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


namespace securityvar_default {
    partial class FrmSecurityVar_Default {
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
            this.txtActualValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpTipo = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.txtValore = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVarName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DS = new securityvar_default.vistaForm();
            this.grpTipo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // txtActualValue
            // 
            this.txtActualValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtActualValue.Location = new System.Drawing.Point(12, 309);
            this.txtActualValue.Multiline = true;
            this.txtActualValue.Name = "txtActualValue";
            this.txtActualValue.ReadOnly = true;
            this.txtActualValue.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtActualValue.Size = new System.Drawing.Size(512, 64);
            this.txtActualValue.TabIndex = 19;
            this.txtActualValue.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(12, 293);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 23);
            this.label1.TabIndex = 18;
            this.label1.Text = "Valore attuale, calcolato al momento della connessione";
            // 
            // grpTipo
            // 
            this.grpTipo.Controls.Add(this.radioButton3);
            this.grpTipo.Controls.Add(this.radioButton2);
            this.grpTipo.Controls.Add(this.radioButton1);
            this.grpTipo.Location = new System.Drawing.Point(324, 6);
            this.grpTipo.Name = "grpTipo";
            this.grpTipo.Size = new System.Drawing.Size(200, 72);
            this.grpTipo.TabIndex = 4;
            this.grpTipo.TabStop = false;
            this.grpTipo.Text = "Tipo";
            // 
            // radioButton3
            // 
            this.radioButton3.Location = new System.Drawing.Point(8, 48);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(184, 16);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Tag = "securityvar.kind:S";
            this.radioButton3.Text = "Lista da Stored Procedure";
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(8, 32);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(184, 16);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Tag = "securityvar.kind:C";
            this.radioButton2.Text = "Lista da comando SQL";
            // 
            // radioButton1
            // 
            this.radioButton1.Location = new System.Drawing.Point(8, 16);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(184, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Tag = "securityvar.kind:K";
            this.radioButton1.Text = "Costante";
            // 
            // txtValore
            // 
            this.txtValore.AcceptsReturn = true;
            this.txtValore.AcceptsTab = true;
            this.txtValore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValore.Location = new System.Drawing.Point(12, 158);
            this.txtValore.Multiline = true;
            this.txtValore.Name = "txtValore";
            this.txtValore.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtValore.Size = new System.Drawing.Size(512, 111);
            this.txtValore.TabIndex = 5;
            this.txtValore.Tag = "securityvar.value";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 23);
            this.label3.TabIndex = 14;
            this.label3.Text = "Valore variabile:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVarName
            // 
            this.txtVarName.Location = new System.Drawing.Point(108, 45);
            this.txtVarName.Name = "txtVarName";
            this.txtVarName.Size = new System.Drawing.Size(200, 20);
            this.txtVarName.TabIndex = 2;
            this.txtVarName.Tag = "securityvar.variablename";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 12;
            this.label2.Text = "Nome variabile:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "ID Variabile:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(108, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Tag = "securityvar.idsecurityvar";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(107, 82);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(417, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.Tag = "securityvar.description";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 22;
            this.label5.Text = "Descrizione:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // FrmSecurityVar_Default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 405);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtActualValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grpTipo);
            this.Controls.Add(this.txtValore);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtVarName);
            this.Controls.Add(this.label2);
            this.Name = "FrmSecurityVar_Default";
            this.Text = "FrmSecurityVar_Default";
            this.grpTipo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.TextBox txtActualValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpTipo;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox txtValore;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVarName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;

    }
}
