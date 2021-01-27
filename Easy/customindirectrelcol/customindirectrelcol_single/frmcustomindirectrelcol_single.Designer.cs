
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


namespace customindirectrelcol_single {
    partial class frmcustomindirectrelcol_single {
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
            this.ParentTable = new System.Windows.Forms.GroupBox();
            this.txtToTable = new System.Windows.Forms.TextBox();
            this.MiddleTable = new System.Windows.Forms.GroupBox();
            this.txtFromTable = new System.Windows.Forms.TextBox();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.padre1 = new System.Windows.Forms.RadioButton();
            this.padre2 = new System.Windows.Forms.RadioButton();
            this.DS = new customindirectrelcol_single.dsmeta();
            this.ParentTable.SuspendLayout();
            this.MiddleTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // ParentTable
            // 
            this.ParentTable.Controls.Add(this.txtToTable);
            this.ParentTable.Location = new System.Drawing.Point(22, 86);
            this.ParentTable.Name = "ParentTable";
            this.ParentTable.Size = new System.Drawing.Size(413, 40);
            this.ParentTable.TabIndex = 13;
            this.ParentTable.TabStop = false;
            this.ParentTable.Tag = "AutoChoose.txtToTable.default";
            this.ParentTable.Text = "Colonna padre";
            // 
            // txtToTable
            // 
            this.txtToTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToTable.Location = new System.Drawing.Point(6, 16);
            this.txtToTable.Name = "txtToTable";
            this.txtToTable.Size = new System.Drawing.Size(401, 20);
            this.txtToTable.TabIndex = 6;
            this.txtToTable.Tag = "columntypes_parent.field?customindirectrel.parentfield";
            // 
            // MiddleTable
            // 
            this.MiddleTable.Controls.Add(this.txtFromTable);
            this.MiddleTable.Location = new System.Drawing.Point(22, 27);
            this.MiddleTable.Name = "MiddleTable";
            this.MiddleTable.Size = new System.Drawing.Size(413, 40);
            this.MiddleTable.TabIndex = 12;
            this.MiddleTable.TabStop = false;
            this.MiddleTable.Tag = "AutoChoose.txtFromTable.default";
            this.MiddleTable.Text = "Colonna centrale";
            // 
            // txtFromTable
            // 
            this.txtFromTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFromTable.Location = new System.Drawing.Point(6, 16);
            this.txtFromTable.Name = "txtFromTable";
            this.txtFromTable.Size = new System.Drawing.Size(401, 20);
            this.txtFromTable.TabIndex = 6;
            this.txtFromTable.Tag = "columntypes_middle.field?customindirectrelcol.middlefield";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(360, 144);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(69, 23);
            this.btnAnnulla.TabIndex = 17;
            this.btnAnnulla.Text = "Annulla";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(276, 144);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(69, 23);
            this.btnOk.TabIndex = 16;
            this.btnOk.Tag = "mainsave";
            this.btnOk.Text = "Ok";
            // 
            // padre1
            // 
            this.padre1.AutoSize = true;
            this.padre1.Checked = true;
            this.padre1.Location = new System.Drawing.Point(28, 144);
            this.padre1.Name = "padre1";
            this.padre1.Size = new System.Drawing.Size(59, 17);
            this.padre1.TabIndex = 26;
            this.padre1.TabStop = true;
            this.padre1.Tag = "customindirectrelcol.parentnumber:1";
            this.padre1.Text = "Padre1";
            this.padre1.UseVisualStyleBackColor = true;
            this.padre1.CheckedChanged += new System.EventHandler(this.padre_CheckedChanged);
            // 
            // padre2
            // 
            this.padre2.AutoSize = true;
            this.padre2.Location = new System.Drawing.Point(93, 144);
            this.padre2.Name = "padre2";
            this.padre2.Size = new System.Drawing.Size(59, 17);
            this.padre2.TabIndex = 27;
            this.padre2.Tag = "customindirectrelcol.parentnumber:2";
            this.padre2.Text = "Padre2";
            this.padre2.UseVisualStyleBackColor = true;
            this.padre2.CheckedChanged += new System.EventHandler(this.padre_CheckedChanged);
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // frmcustomindirectrelcol_single
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(455, 194);
            this.Controls.Add(this.padre2);
            this.Controls.Add(this.padre1);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.ParentTable);
            this.Controls.Add(this.MiddleTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmcustomindirectrelcol_single";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "customindirectrelcol_single";
            this.ParentTable.ResumeLayout(false);
            this.ParentTable.PerformLayout();
            this.MiddleTable.ResumeLayout(false);
            this.MiddleTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        public customindirectrelcol_single.dsmeta DS;
        private System.Windows.Forms.GroupBox ParentTable;
        private System.Windows.Forms.TextBox txtToTable;
        private System.Windows.Forms.GroupBox MiddleTable;
        private System.Windows.Forms.TextBox txtFromTable;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.RadioButton padre1;
        private System.Windows.Forms.RadioButton padre2;



    }
}

