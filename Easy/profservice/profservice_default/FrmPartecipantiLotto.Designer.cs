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

﻿namespace profservice_default {
    partial class FrmPartecipantiLotto {
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
            this.chkVediTuttiPartecipanti = new System.Windows.Forms.CheckBox();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLotto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkListPartecipanti = new System.Windows.Forms.ListView();
            this.colhead = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.txtCIG = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // chkVediTuttiPartecipanti
            // 
            this.chkVediTuttiPartecipanti.AutoSize = true;
            this.chkVediTuttiPartecipanti.Checked = true;
            this.chkVediTuttiPartecipanti.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVediTuttiPartecipanti.Location = new System.Drawing.Point(15, 407);
            this.chkVediTuttiPartecipanti.Name = "chkVediTuttiPartecipanti";
            this.chkVediTuttiPartecipanti.Size = new System.Drawing.Size(262, 17);
            this.chkVediTuttiPartecipanti.TabIndex = 20;
            this.chkVediTuttiPartecipanti.Text = "Visualizza anche partecipanti che non concorrono";
            this.chkVediTuttiPartecipanti.UseVisualStyleBackColor = true;
            this.chkVediTuttiPartecipanti.CheckedChanged += new System.EventHandler(this.chkVediTuttiLotti_CheckedChanged);
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(696, 407);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 19;
            this.btnAnnulla.Text = "Annulla";
            this.btnAnnulla.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(550, 407);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 18;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(371, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Partecipanti che concorrono al lotto (capogruppo nel caso di raggruppamenti)";
            // 
            // txtLotto
            // 
            this.txtLotto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLotto.Location = new System.Drawing.Point(15, 27);
            this.txtLotto.Name = "txtLotto";
            this.txtLotto.ReadOnly = true;
            this.txtLotto.Size = new System.Drawing.Size(756, 20);
            this.txtLotto.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Descrizione del lotto";
            // 
            // chkListPartecipanti
            // 
            this.chkListPartecipanti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkListPartecipanti.CheckBoxes = true;
            this.chkListPartecipanti.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colhead});
            this.chkListPartecipanti.FullRowSelect = true;
            this.chkListPartecipanti.GridLines = true;
            this.chkListPartecipanti.Location = new System.Drawing.Point(15, 109);
            this.chkListPartecipanti.Name = "chkListPartecipanti";
            this.chkListPartecipanti.Size = new System.Drawing.Size(756, 292);
            this.chkListPartecipanti.TabIndex = 22;
            this.chkListPartecipanti.UseCompatibleStateImageBehavior = false;
            this.chkListPartecipanti.View = System.Windows.Forms.View.Details;
            // 
            // colhead
            // 
            this.colhead.Text = "Ragione sociale";
            this.colhead.Width = 751;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "CIG";
            // 
            // txtCIG
            // 
            this.txtCIG.Location = new System.Drawing.Point(15, 66);
            this.txtCIG.Name = "txtCIG";
            this.txtCIG.ReadOnly = true;
            this.txtCIG.Size = new System.Drawing.Size(100, 20);
            this.txtCIG.TabIndex = 24;
            // 
            // FrmPartecipantiLotto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 440);
            this.Controls.Add(this.txtCIG);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkListPartecipanti);
            this.Controls.Add(this.chkVediTuttiPartecipanti);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLotto);
            this.Controls.Add(this.label1);
            this.Name = "FrmPartecipantiLotto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Partecipanti ad un lotto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkVediTuttiPartecipanti;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLotto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView chkListPartecipanti;
        private System.Windows.Forms.ColumnHeader colhead;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCIG;
    }
}