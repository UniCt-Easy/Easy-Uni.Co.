
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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


namespace allowancerule_default {
    partial class Frm_allowancerule_default {
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
            this.DS = new allowancerule_default.vistaForm();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnIndElimina = new System.Windows.Forms.Button();
            this.btnIndModifica = new System.Windows.Forms.Button();
            this.btnIndInserisci = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(5, 40);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(615, 357);
            this.dataGrid1.TabIndex = 0;
            this.dataGrid1.Tag = "allowanceruledetail.default";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(35, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(62, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Tag = "allowancerule.idallowancerule";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(165, 12);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(99, 20);
            this.textBox3.TabIndex = 3;
            this.textBox3.Tag = "allowancerule.start";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Id.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(109, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 6;
            this.label3.Tag = "";
            this.label3.Text = "Data inizio";
            // 
            // btnIndElimina
            // 
            this.btnIndElimina.Location = new System.Drawing.Point(216, 12);
            this.btnIndElimina.Name = "btnIndElimina";
            this.btnIndElimina.Size = new System.Drawing.Size(68, 22);
            this.btnIndElimina.TabIndex = 13;
            this.btnIndElimina.Tag = "delete";
            this.btnIndElimina.Text = "Elimina";
            // 
            // btnIndModifica
            // 
            this.btnIndModifica.Location = new System.Drawing.Point(136, 12);
            this.btnIndModifica.Name = "btnIndModifica";
            this.btnIndModifica.Size = new System.Drawing.Size(69, 22);
            this.btnIndModifica.TabIndex = 12;
            this.btnIndModifica.Tag = "edit.single";
            this.btnIndModifica.Text = "Modifica...";
            // 
            // btnIndInserisci
            // 
            this.btnIndInserisci.Location = new System.Drawing.Point(56, 12);
            this.btnIndInserisci.Name = "btnIndInserisci";
            this.btnIndInserisci.Size = new System.Drawing.Size(68, 22);
            this.btnIndInserisci.TabIndex = 11;
            this.btnIndInserisci.Tag = "insert.single";
            this.btnIndInserisci.Text = "Inserisci...";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dataGrid1);
            this.groupBox1.Controls.Add(this.btnIndElimina);
            this.groupBox1.Controls.Add(this.btnIndInserisci);
            this.groupBox1.Controls.Add(this.btnIndModifica);
            this.groupBox1.Location = new System.Drawing.Point(3, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(626, 403);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dettagli";
            // 
            // Frm_allowancerule_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 446);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox1);
            this.Name = "Frm_allowancerule_default";
            this.Text = "Frm_allowancerule_default";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        public vistaForm DS;
        private System.Windows.Forms.Button btnIndElimina;
        private System.Windows.Forms.Button btnIndModifica;
        private System.Windows.Forms.Button btnIndInserisci;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
