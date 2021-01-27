
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


namespace report_default {
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
            this.txtParams = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtFormule = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtStoredProc = new System.Windows.Forms.TextBox();
            this.tabParametri = new System.Windows.Forms.TabPage();
            this.gridParams = new System.Windows.Forms.DataGridView();
            this.gridSP = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabParametri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridParams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSP)).BeginInit();
            this.SuspendLayout();
            // 
            // txtParams
            // 
            this.txtParams.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtParams.Location = new System.Drawing.Point(6, 6);
            this.txtParams.Multiline = true;
            this.txtParams.Name = "txtParams";
            this.txtParams.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtParams.Size = new System.Drawing.Size(750, 491);
            this.txtParams.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabParametri);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(770, 529);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtParams);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(762, 503);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Parametri Report";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtFormule);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(762, 503);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Formule";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtFormule
            // 
            this.txtFormule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFormule.Location = new System.Drawing.Point(6, 6);
            this.txtFormule.Multiline = true;
            this.txtFormule.Name = "txtFormule";
            this.txtFormule.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFormule.Size = new System.Drawing.Size(750, 491);
            this.txtFormule.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtStoredProc);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(762, 503);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Stored Procedures";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtStoredProc
            // 
            this.txtStoredProc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStoredProc.Location = new System.Drawing.Point(6, 6);
            this.txtStoredProc.Multiline = true;
            this.txtStoredProc.Name = "txtStoredProc";
            this.txtStoredProc.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtStoredProc.Size = new System.Drawing.Size(750, 491);
            this.txtStoredProc.TabIndex = 2;
            // 
            // tabParametri
            // 
            this.tabParametri.Controls.Add(this.gridParams);
            this.tabParametri.Controls.Add(this.gridSP);
            this.tabParametri.Location = new System.Drawing.Point(4, 22);
            this.tabParametri.Name = "tabParametri";
            this.tabParametri.Size = new System.Drawing.Size(762, 503);
            this.tabParametri.TabIndex = 4;
            this.tabParametri.Text = "Parametri Stored procedure";
            this.tabParametri.UseVisualStyleBackColor = true;
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
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabParametri.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridParams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TextBox txtParams;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.TextBox txtFormule;
        private System.Windows.Forms.TabPage tabPage3;
        public System.Windows.Forms.TextBox txtStoredProc;
        private System.Windows.Forms.TabPage tabParametri;
        private System.Windows.Forms.DataGridView gridParams;
        private System.Windows.Forms.DataGridView gridSP;
    }
}
