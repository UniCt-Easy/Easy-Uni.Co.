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
    partial class frmLottiAppaltati {
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtPartecipante = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.chkVediTuttiLotti = new System.Windows.Forms.CheckBox();
            this.chkListaLotti = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Partecipante alla gara (capogruppo in caso di raggruppamento):";
            // 
            // txtPartecipante
            // 
            this.txtPartecipante.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPartecipante.Location = new System.Drawing.Point(13, 25);
            this.txtPartecipante.Name = "txtPartecipante";
            this.txtPartecipante.ReadOnly = true;
            this.txtPartecipante.Size = new System.Drawing.Size(756, 20);
            this.txtPartecipante.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(291, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Lotti aggiudicati dal partecipante (singolo o raggruppamento)";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(550, 405);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(696, 405);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 5;
            this.btnAnnulla.Text = "Annulla";
            this.btnAnnulla.UseVisualStyleBackColor = true;
            // 
            // chkVediTuttiLotti
            // 
            this.chkVediTuttiLotti.AutoSize = true;
            this.chkVediTuttiLotti.Location = new System.Drawing.Point(15, 405);
            this.chkVediTuttiLotti.Name = "chkVediTuttiLotti";
            this.chkVediTuttiLotti.Size = new System.Drawing.Size(235, 17);
            this.chkVediTuttiLotti.TabIndex = 6;
            this.chkVediTuttiLotti.Text = "Visualizza anche lotti non ancora aggiudicati";
            this.chkVediTuttiLotti.UseVisualStyleBackColor = true;
            this.chkVediTuttiLotti.CheckedChanged += new System.EventHandler(this.chkVediTuttiLotti_CheckedChanged);
            // 
            // chkListaLotti
            // 
            this.chkListaLotti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkListaLotti.CheckBoxes = true;
            this.chkListaLotti.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader1});
            this.chkListaLotti.FullRowSelect = true;
            this.chkListaLotti.GridLines = true;
            this.chkListaLotti.Location = new System.Drawing.Point(15, 85);
            this.chkListaLotti.Name = "chkListaLotti";
            this.chkListaLotti.Size = new System.Drawing.Size(756, 314);
            this.chkListaLotti.TabIndex = 23;
            this.chkListaLotti.UseCompatibleStateImageBehavior = false;
            this.chkListaLotti.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "CIG";
            this.columnHeader2.Width = 85;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Descrizione del lotto";
            this.columnHeader1.Width = 752;
            // 
            // frmLottiAppaltati
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAnnulla;
            this.ClientSize = new System.Drawing.Size(783, 440);
            this.Controls.Add(this.chkListaLotti);
            this.Controls.Add(this.chkVediTuttiLotti);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPartecipante);
            this.Controls.Add(this.label1);
            this.Name = "frmLottiAppaltati";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lotti aggiudicati";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPartecipante;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.CheckBox chkVediTuttiLotti;
        private System.Windows.Forms.ListView chkListaLotti;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}