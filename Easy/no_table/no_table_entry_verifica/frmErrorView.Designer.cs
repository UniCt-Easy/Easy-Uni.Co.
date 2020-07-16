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

﻿namespace no_table_entry_verifica {
    partial class frmErrorView {
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
            this.labTitolo = new System.Windows.Forms.Label();
            this.dgDettaglio = new System.Windows.Forms.DataGrid();
            this.labNRighe = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgDettaglio)).BeginInit();
            this.SuspendLayout();
            // 
            // labTitolo
            // 
            this.labTitolo.AutoSize = true;
            this.labTitolo.Location = new System.Drawing.Point(12, 9);
            this.labTitolo.Name = "labTitolo";
            this.labTitolo.Size = new System.Drawing.Size(33, 13);
            this.labTitolo.TabIndex = 0;
            this.labTitolo.Text = "Titolo";
            // 
            // dgDettaglio
            // 
            this.dgDettaglio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgDettaglio.DataMember = "";
            this.dgDettaglio.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgDettaglio.Location = new System.Drawing.Point(12, 43);
            this.dgDettaglio.Name = "dgDettaglio";
            this.dgDettaglio.Size = new System.Drawing.Size(682, 339);
            this.dgDettaglio.TabIndex = 1;
            this.dgDettaglio.DoubleClick += new System.EventHandler(this.dgDettaglio_DoubleClick);
            // 
            // labNRighe
            // 
            this.labNRighe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labNRighe.Location = new System.Drawing.Point(493, 385);
            this.labNRighe.Name = "labNRighe";
            this.labNRighe.Size = new System.Drawing.Size(201, 23);
            this.labNRighe.TabIndex = 2;
            this.labNRighe.Text = "label1";
            this.labNRighe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmErrorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 415);
            this.Controls.Add(this.labNRighe);
            this.Controls.Add(this.dgDettaglio);
            this.Controls.Add(this.labTitolo);
            this.Name = "frmErrorView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Elenco problemi";
            ((System.ComponentModel.ISupportInitialize)(this.dgDettaglio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labTitolo;
        private System.Windows.Forms.DataGrid dgDettaglio;
        private System.Windows.Forms.Label labNRighe;
    }
}