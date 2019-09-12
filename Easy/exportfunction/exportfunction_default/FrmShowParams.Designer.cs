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

ï»¿namespace report_default {
    partial class FrmShowParams {
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabParametri = new System.Windows.Forms.TabPage();
            this.gridSP = new System.Windows.Forms.DataGridView();
            this.gridParams = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabParametri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridParams)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabParametri);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(770, 529);
            this.tabControl1.TabIndex = 1;
            // 
            // tabParametri
            // 
            this.tabParametri.Controls.Add(this.gridParams);
            this.tabParametri.Controls.Add(this.gridSP);
            this.tabParametri.Location = new System.Drawing.Point(4, 22);
            this.tabParametri.Name = "tabParametri";
            this.tabParametri.Size = new System.Drawing.Size(762, 503);
            this.tabParametri.TabIndex = 3;
            this.tabParametri.Text = "Parametri";
            this.tabParametri.UseVisualStyleBackColor = true;
            // 
            // gridSP
            // 
            this.gridSP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSP.Location = new System.Drawing.Point(8, 17);
            this.gridSP.Name = "gridSP";
            this.gridSP.ReadOnly = true;
            this.gridSP.Size = new System.Drawing.Size(746, 150);
            this.gridSP.TabIndex = 0;
            // 
            // gridParams
            // 
            this.gridParams.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridParams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridParams.Location = new System.Drawing.Point(8, 192);
            this.gridParams.Name = "gridParams";
            this.gridParams.ReadOnly = true;
            this.gridParams.Size = new System.Drawing.Size(746, 287);
            this.gridParams.TabIndex = 1;
            // 
            // FrmShowParams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 529);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmShowParams";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parametri Report";
            this.tabControl1.ResumeLayout(false);
            this.tabParametri.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridParams)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabParametri;
        private System.Windows.Forms.DataGridView gridParams;
        private System.Windows.Forms.DataGridView gridSP;
    }
}