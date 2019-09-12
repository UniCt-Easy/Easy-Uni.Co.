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

ï»¿namespace customdirectrelcol_single {
    partial class frmcustomdirectrelcol_single {
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
            this.ToTable = new System.Windows.Forms.GroupBox();
            this.txtToTable = new System.Windows.Forms.TextBox();
            this.FromTable = new System.Windows.Forms.GroupBox();
            this.txtFromTable = new System.Windows.Forms.TextBox();
            this.DS = new customdirectrelcol_single.dsmeta();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.ToTable.SuspendLayout();
            this.FromTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // ToTable
            // 
            this.ToTable.Controls.Add(this.txtToTable);
            this.ToTable.Location = new System.Drawing.Point(22, 93);
            this.ToTable.Name = "ToTable";
            this.ToTable.Size = new System.Drawing.Size(407, 40);
            this.ToTable.TabIndex = 9;
            this.ToTable.TabStop = false;
            this.ToTable.Tag = "AutoChoose.txtToTable.default";
            this.ToTable.Text = "Colonna di arrivo";
            // 
            // txtToTable
            // 
            this.txtToTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToTable.Location = new System.Drawing.Point(6, 16);
            this.txtToTable.Name = "txtToTable";
            this.txtToTable.Size = new System.Drawing.Size(395, 20);
            this.txtToTable.TabIndex = 6;
            this.txtToTable.Tag = "columntypes1.field?customdirectrel.tofield";
            // 
            // FromTable
            // 
            this.FromTable.Controls.Add(this.txtFromTable);
            this.FromTable.Location = new System.Drawing.Point(22, 34);
            this.FromTable.Name = "FromTable";
            this.FromTable.Size = new System.Drawing.Size(413, 40);
            this.FromTable.TabIndex = 8;
            this.FromTable.TabStop = false;
            this.FromTable.Tag = "AutoChoose.txtFromTable.default";
            this.FromTable.Text = "Colonna di partenza";
            // 
            // txtFromTable
            // 
            this.txtFromTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFromTable.Location = new System.Drawing.Point(6, 16);
            this.txtFromTable.Name = "txtFromTable";
            this.txtFromTable.Size = new System.Drawing.Size(401, 20);
            this.txtFromTable.TabIndex = 6;
            this.txtFromTable.Tag = "columntypes.field?customdirectrelcol.fromfield";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(224, 170);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(69, 23);
            this.btnAnnulla.TabIndex = 11;
            this.btnAnnulla.Text = "Annulla";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(140, 170);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(69, 23);
            this.btnOk.TabIndex = 10;
            this.btnOk.Tag = "mainsave";
            this.btnOk.Text = "Ok";
            // 
            // frmcustomdirectrelcol_single
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(465, 220);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.ToTable);
            this.Controls.Add(this.FromTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmcustomdirectrelcol_single";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "customdirectrelcol_single";
            this.ToTable.ResumeLayout(false);
            this.ToTable.PerformLayout();
            this.FromTable.ResumeLayout(false);
            this.FromTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public customdirectrelcol_single.dsmeta DS;
        private System.Windows.Forms.GroupBox ToTable;
        private System.Windows.Forms.TextBox txtToTable;
        private System.Windows.Forms.GroupBox FromTable;
        private System.Windows.Forms.TextBox txtFromTable;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnOk;
    }
}

