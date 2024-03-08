
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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



namespace no_table_emisti {
    partial class Frm_no_table_emisti {
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
            this.DS = new no_table_emisti.vistaForm();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.grpDescription = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnInput = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.dgvErrors = new System.Windows.Forms.DataGridView();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.grpInput.SuspendLayout();
            this.grpDescription.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrors)).BeginInit();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(883, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Salva";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(674, 200);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(343, 535);
            this.txtLog.TabIndex = 8;
            // 
            // grpInput
            // 
            this.grpInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpInput.Controls.Add(this.grpDescription);
            this.grpInput.Controls.Add(this.btnSave);
            this.grpInput.Controls.Add(this.btnImport);
            this.grpInput.Controls.Add(this.btnInput);
            this.grpInput.Controls.Add(this.txtInput);
            this.grpInput.Location = new System.Drawing.Point(12, 12);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(1005, 124);
            this.grpInput.TabIndex = 6;
            this.grpInput.TabStop = false;
            this.grpInput.Text = "Input";
            // 
            // grpDescription
            // 
            this.grpDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDescription.Controls.Add(this.txtDescription);
            this.grpDescription.Location = new System.Drawing.Point(6, 44);
            this.grpDescription.Name = "grpDescription";
            this.grpDescription.Size = new System.Drawing.Size(993, 73);
            this.grpDescription.TabIndex = 12;
            this.grpDescription.TabStop = false;
            this.grpDescription.Text = "Descrizione";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(6, 19);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(981, 48);
            this.txtDescription.TabIndex = 11;
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Location = new System.Drawing.Point(767, 15);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(110, 23);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "Importa";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnInput
            // 
            this.btnInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInput.Location = new System.Drawing.Point(651, 15);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(110, 23);
            this.btnInput.TabIndex = 2;
            this.btnInput.Text = "Seleziona file";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.Location = new System.Drawing.Point(6, 17);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(639, 20);
            this.txtInput.TabIndex = 0;
            // 
            // dgvErrors
            // 
            this.dgvErrors.AllowUserToAddRows = false;
            this.dgvErrors.AllowUserToDeleteRows = false;
            this.dgvErrors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvErrors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvErrors.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvErrors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvErrors.Location = new System.Drawing.Point(12, 142);
            this.dgvErrors.Name = "dgvErrors";
            this.dgvErrors.ReadOnly = true;
            this.dgvErrors.Size = new System.Drawing.Size(656, 593);
            this.dgvErrors.TabIndex = 10;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(674, 142);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(343, 23);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Reset";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(674, 171);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(343, 23);
            this.btnExport.TabIndex = 12;
            this.btnExport.Text = "Esporta";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // Frm_no_table_emisti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 747);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.dgvErrors);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.grpInput);
            this.Name = "Frm_no_table_emisti";
            this.Text = "Frm_no_table_emisti";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            this.grpDescription.ResumeLayout(false);
            this.grpDescription.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.DataGridView dgvErrors;
        private System.Windows.Forms.GroupBox grpDescription;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnExport;
    }
}
