/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

namespace no_table_flowchart_massive {
    partial class Frm_flowchartmassive {
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
            this.DS = new no_table_flowchart_massive.vistaForm();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDatabaseWeb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtServerWeb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPasswordWeb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserWeb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTestServerWeb = new System.Windows.Forms.Button();
            this.btnImportaUtenti = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.myOpenFile = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDatabaseWeb);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtServerWeb);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPasswordWeb);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtUserWeb);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnTestServerWeb);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(770, 133);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connessione al db del sistema web";
            // 
            // txtDatabaseWeb
            // 
            this.txtDatabaseWeb.Location = new System.Drawing.Point(289, 87);
            this.txtDatabaseWeb.Name = "txtDatabaseWeb";
            this.txtDatabaseWeb.Size = new System.Drawing.Size(225, 20);
            this.txtDatabaseWeb.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(286, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Database";
            // 
            // txtServerWeb
            // 
            this.txtServerWeb.Location = new System.Drawing.Point(15, 87);
            this.txtServerWeb.Name = "txtServerWeb";
            this.txtServerWeb.Size = new System.Drawing.Size(253, 20);
            this.txtServerWeb.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Server";
            // 
            // txtPasswordWeb
            // 
            this.txtPasswordWeb.Location = new System.Drawing.Point(177, 37);
            this.txtPasswordWeb.Name = "txtPasswordWeb";
            this.txtPasswordWeb.PasswordChar = '*';
            this.txtPasswordWeb.Size = new System.Drawing.Size(147, 20);
            this.txtPasswordWeb.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // txtUserWeb
            // 
            this.txtUserWeb.Location = new System.Drawing.Point(15, 37);
            this.txtUserWeb.Name = "txtUserWeb";
            this.txtUserWeb.Size = new System.Drawing.Size(147, 20);
            this.txtUserWeb.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "User";
            // 
            // btnTestServerWeb
            // 
            this.btnTestServerWeb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestServerWeb.Location = new System.Drawing.Point(574, 84);
            this.btnTestServerWeb.Name = "btnTestServerWeb";
            this.btnTestServerWeb.Size = new System.Drawing.Size(177, 23);
            this.btnTestServerWeb.TabIndex = 0;
            this.btnTestServerWeb.Text = "Verifica connessione";
            this.btnTestServerWeb.UseVisualStyleBackColor = true;
            this.btnTestServerWeb.Click += new System.EventHandler(this.btnTestServerWeb_Click);
            // 
            // btnImportaUtenti
            // 
            this.btnImportaUtenti.Location = new System.Drawing.Point(318, 161);
            this.btnImportaUtenti.Name = "btnImportaUtenti";
            this.btnImportaUtenti.Size = new System.Drawing.Size(161, 23);
            this.btnImportaUtenti.TabIndex = 1;
            this.btnImportaUtenti.Text = "Importa utenti";
            this.btnImportaUtenti.UseVisualStyleBackColor = true;
            this.btnImportaUtenti.Click += new System.EventHandler(this.btnImportaUtenti_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(12, 190);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(770, 289);
            this.txtResult.TabIndex = 2;
            // 
            // myOpenFile
            // 
            this.myOpenFile.FileName = "openFileDialog1";
            this.myOpenFile.Title = "Selezionare il file da importare";
            // 
            // Frm_flowchartmassive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(794, 521);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnImportaUtenti);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_flowchartmassive";
            this.Text = "Frm_flowchartmassive";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTestServerWeb;
        private System.Windows.Forms.TextBox txtDatabaseWeb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtServerWeb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPasswordWeb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserWeb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnImportaUtenti;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.OpenFileDialog myOpenFile;
    }
}