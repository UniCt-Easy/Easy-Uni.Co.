
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


namespace csa_import_inail {
    partial class formtest
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

            this.dgrUngrouped = new System.Windows.Forms.DataGrid();
            this.dgrGrouped = new System.Windows.Forms.DataGrid();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancButton = new System.Windows.Forms.Button();
            this.txtRaggruppate = new System.Windows.Forms.Label();
            this.txtNonRaggruppate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgrUngrouped)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrGrouped)).BeginInit();
            this.SuspendLayout();
            // 
            // dgrUngrouped
            // 
            this.dgrUngrouped.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrUngrouped.CaptionVisible = false;
            this.dgrUngrouped.DataMember = "";
            this.dgrUngrouped.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrUngrouped.Location = new System.Drawing.Point(12, 35);
            this.dgrUngrouped.Name = "dgrUngrouped";
            this.dgrUngrouped.ReadOnly = true;
            this.dgrUngrouped.Size = new System.Drawing.Size(531, 251);
            this.dgrUngrouped.TabIndex = 1;
            this.dgrUngrouped.Tag = "";
            // 
            // dgrGrouped
            // 
            this.dgrGrouped.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrGrouped.CaptionVisible = false;
            this.dgrGrouped.DataMember = "";
            this.dgrGrouped.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrGrouped.Location = new System.Drawing.Point(12, 333);
            this.dgrGrouped.Name = "dgrGrouped";
            this.dgrGrouped.ReadOnly = true;
            this.dgrGrouped.Size = new System.Drawing.Size(531, 267);
            this.dgrGrouped.TabIndex = 2;
            this.dgrGrouped.Tag = "";
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(371, 606);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 6;
            this.OkButton.Tag = "mainsave";
            this.OkButton.Text = "Ok";
            // 
            // CancButton
            // 
            this.CancButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancButton.Location = new System.Drawing.Point(458, 606);
            this.CancButton.Name = "CancButton";
            this.CancButton.Size = new System.Drawing.Size(75, 23);
            this.CancButton.TabIndex = 7;
            this.CancButton.Text = "Annulla";
            // 
            // txtRaggruppate
            // 
            this.txtRaggruppate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRaggruppate.Location = new System.Drawing.Point(12, 314);
            this.txtRaggruppate.Name = "txtRaggruppate";
            this.txtRaggruppate.Size = new System.Drawing.Size(261, 16);
            this.txtRaggruppate.TabIndex = 8;
            this.txtRaggruppate.Text = "Raggruppate";
            this.txtRaggruppate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNonRaggruppate
            // 
            this.txtNonRaggruppate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNonRaggruppate.Location = new System.Drawing.Point(12, 16);
            this.txtNonRaggruppate.Name = "txtNonRaggruppate";
            this.txtNonRaggruppate.Size = new System.Drawing.Size(261, 16);
            this.txtNonRaggruppate.TabIndex = 9;
            this.txtNonRaggruppate.Text = "Non Raggruppate";
            this.txtNonRaggruppate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // formtest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 651);
            this.Controls.Add(this.txtNonRaggruppate);
            this.Controls.Add(this.txtRaggruppate);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.CancButton);
            this.Controls.Add(this.dgrGrouped);
            this.Controls.Add(this.dgrUngrouped);
            this.Name = "formtest";
            this.Text = "formtest";
            ((System.ComponentModel.ISupportInitialize)(this.dgrUngrouped)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrGrouped)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGrid dgrUngrouped;
        public System.Windows.Forms.DataGrid dgrGrouped;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancButton;
        private System.Windows.Forms.Label txtRaggruppate;
        private System.Windows.Forms.Label txtNonRaggruppate;

    }
}
