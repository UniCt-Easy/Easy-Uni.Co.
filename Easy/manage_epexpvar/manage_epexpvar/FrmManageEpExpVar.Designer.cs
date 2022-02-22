
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


namespace manage_epexpvar
{
    partial class FrmManageEpExpVar
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
            this.grpVar = new System.Windows.Forms.GroupBox();
            this.dgVar = new System.Windows.Forms.DataGrid();
            this.grpClass = new System.Windows.Forms.GroupBox();
            this.btnDeleteClass = new System.Windows.Forms.Button();
            this.btnUpdateClass = new System.Windows.Forms.Button();
            this.btnInsertClass = new System.Windows.Forms.Button();
            this.dgClass = new System.Windows.Forms.DataGrid();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.dsMov = new manage_epexpvar.dsMov();
            this.grpVar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVar)).BeginInit();
            this.grpClass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMov)).BeginInit();
            this.SuspendLayout();
            // 
            // grpVar
            // 
            this.grpVar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpVar.Controls.Add(this.dgVar);
            this.grpVar.Location = new System.Drawing.Point(12, 12);
            this.grpVar.Name = "grpVar";
            this.grpVar.Size = new System.Drawing.Size(623, 218);
            this.grpVar.TabIndex = 5;
            this.grpVar.TabStop = false;
            this.grpVar.Text = "Variazioni";
            // 
            // dgVar
            // 
            this.dgVar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgVar.DataMember = "";
            this.dgVar.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgVar.Location = new System.Drawing.Point(6, 19);
            this.dgVar.Name = "dgVar";
            this.dgVar.Size = new System.Drawing.Size(611, 193);
            this.dgVar.TabIndex = 0;
            this.dgVar.CurrentCellChanged += new System.EventHandler(this.dgVar_CurrentCellChanged);
            this.dgVar.DoubleClick += new System.EventHandler(this.dgVar_DoubleClick);
            // 
            // grpClass
            // 
            this.grpClass.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpClass.Controls.Add(this.btnDeleteClass);
            this.grpClass.Controls.Add(this.btnUpdateClass);
            this.grpClass.Controls.Add(this.btnInsertClass);
            this.grpClass.Controls.Add(this.dgClass);
            this.grpClass.Location = new System.Drawing.Point(12, 236);
            this.grpClass.Name = "grpClass";
            this.grpClass.Size = new System.Drawing.Size(623, 253);
            this.grpClass.TabIndex = 6;
            this.grpClass.TabStop = false;
            this.grpClass.Text = "Classificazioni";
            // 
            // btnDeleteClass
            // 
            this.btnDeleteClass.Location = new System.Drawing.Point(198, 19);
            this.btnDeleteClass.Name = "btnDeleteClass";
            this.btnDeleteClass.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteClass.TabIndex = 11;
            this.btnDeleteClass.Text = "Cancella";
            this.btnDeleteClass.Click += new System.EventHandler(this.btnDeleteClass_Click);
            // 
            // btnUpdateClass
            // 
            this.btnUpdateClass.Location = new System.Drawing.Point(102, 19);
            this.btnUpdateClass.Name = "btnUpdateClass";
            this.btnUpdateClass.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateClass.TabIndex = 10;
            this.btnUpdateClass.Text = "Correggi";
            this.btnUpdateClass.Click += new System.EventHandler(this.btnUpdateClass_Click);
            // 
            // btnInsertClass
            // 
            this.btnInsertClass.Location = new System.Drawing.Point(6, 19);
            this.btnInsertClass.Name = "btnInsertClass";
            this.btnInsertClass.Size = new System.Drawing.Size(75, 23);
            this.btnInsertClass.TabIndex = 9;
            this.btnInsertClass.Text = "Inserisci";
            this.btnInsertClass.Click += new System.EventHandler(this.btnInsertClass_Click);
            // 
            // dgClass
            // 
            this.dgClass.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgClass.DataMember = "";
            this.dgClass.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgClass.Location = new System.Drawing.Point(6, 48);
            this.dgClass.Name = "dgClass";
            this.dgClass.Size = new System.Drawing.Size(611, 199);
            this.dgClass.TabIndex = 0;
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(562, 495);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 8;
            this.btnAnnulla.Text = "Annulla";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(466, 495);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "Ok";
            // 
            // dsMov
            // 
            this.dsMov.DataSetName = "dsMov";
            this.dsMov.EnforceConstraints = false;
            // 
            // FrmManageEpExpVar
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAnnulla;
            this.ClientSize = new System.Drawing.Size(647, 530);
            this.Controls.Add(this.grpVar);
            this.Controls.Add(this.grpClass);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOk);
            this.Name = "FrmManageEpExpVar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Variazioni di budget automatiche";
            this.grpVar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgVar)).EndInit();
            this.grpClass.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMov)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpVar;
        private System.Windows.Forms.DataGrid dgVar;
        private System.Windows.Forms.GroupBox grpClass;
        private System.Windows.Forms.Button btnDeleteClass;
        private System.Windows.Forms.Button btnUpdateClass;
        private System.Windows.Forms.Button btnInsertClass;
        private System.Windows.Forms.DataGrid dgClass;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnOk;
        private dsMov dsMov;
    }
}
