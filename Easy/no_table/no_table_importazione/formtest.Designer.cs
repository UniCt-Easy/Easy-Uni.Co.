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

namespace notable_importazione
{
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
            this.dgrT1 = new System.Windows.Forms.DataGrid();
            this.dgrT2 = new System.Windows.Forms.DataGrid();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancButton = new System.Windows.Forms.Button();
            this.labelT2 = new System.Windows.Forms.Label();
            this.labelT1 = new System.Windows.Forms.Label();
            this.labelT3 = new System.Windows.Forms.Label();
            this.dgrT3 = new System.Windows.Forms.DataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.dgrT1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrT2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrT3)).BeginInit();
            this.SuspendLayout();
            // 
            // dgrT1
            // 
            this.dgrT1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrT1.CaptionVisible = false;
            this.dgrT1.DataMember = "";
            this.dgrT1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrT1.Location = new System.Drawing.Point(12, 35);
            this.dgrT1.Name = "dgrT1";
            this.dgrT1.ReadOnly = true;
            this.dgrT1.Size = new System.Drawing.Size(531, 156);
            this.dgrT1.TabIndex = 1;
            this.dgrT1.Tag = "";
            // 
            // dgrT2
            // 
            this.dgrT2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrT2.CaptionVisible = false;
            this.dgrT2.DataMember = "";
            this.dgrT2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrT2.Location = new System.Drawing.Point(12, 210);
            this.dgrT2.Name = "dgrT2";
            this.dgrT2.ReadOnly = true;
            this.dgrT2.Size = new System.Drawing.Size(531, 160);
            this.dgrT2.TabIndex = 2;
            this.dgrT2.Tag = "";
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
            // labelT2
            // 
            this.labelT2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelT2.Location = new System.Drawing.Point(12, 191);
            this.labelT2.Name = "labelT2";
            this.labelT2.Size = new System.Drawing.Size(261, 16);
            this.labelT2.TabIndex = 8;
            this.labelT2.Text = "T2";
            this.labelT2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelT1
            // 
            this.labelT1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelT1.Location = new System.Drawing.Point(12, 16);
            this.labelT1.Name = "labelT1";
            this.labelT1.Size = new System.Drawing.Size(261, 16);
            this.labelT1.TabIndex = 9;
            this.labelT1.Text = "T1";
            this.labelT1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelT3
            // 
            this.labelT3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelT3.Location = new System.Drawing.Point(12, 371);
            this.labelT3.Name = "labelT3";
            this.labelT3.Size = new System.Drawing.Size(261, 16);
            this.labelT3.TabIndex = 11;
            this.labelT3.Text = "T3";
            this.labelT3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgrT3
            // 
            this.dgrT3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrT3.CaptionVisible = false;
            this.dgrT3.DataMember = "";
            this.dgrT3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrT3.Location = new System.Drawing.Point(12, 390);
            this.dgrT3.Name = "dgrT3";
            this.dgrT3.ReadOnly = true;
            this.dgrT3.Size = new System.Drawing.Size(531, 160);
            this.dgrT3.TabIndex = 10;
            this.dgrT3.Tag = "";
            // 
            // formtest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 651);
            this.Controls.Add(this.labelT3);
            this.Controls.Add(this.dgrT3);
            this.Controls.Add(this.labelT1);
            this.Controls.Add(this.labelT2);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.CancButton);
            this.Controls.Add(this.dgrT2);
            this.Controls.Add(this.dgrT1);
            this.Name = "formtest";
            this.Text = "formtest";
            ((System.ComponentModel.ISupportInitialize)(this.dgrT1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrT2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrT3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGrid dgrT1;
        public System.Windows.Forms.DataGrid dgrT2;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancButton;
        private System.Windows.Forms.Label labelT2;
        private System.Windows.Forms.Label labelT1;
        private System.Windows.Forms.Label labelT3;
        public System.Windows.Forms.DataGrid dgrT3;

    }
}