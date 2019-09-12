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

ï»¿namespace mandate_default {
    partial class frmLottiPartecipati {
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
            this.chkVediTuttiLotti = new System.Windows.Forms.CheckBox();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPartecipante = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkListaLotti = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colhead1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // chkVediTuttiLotti
            // 
            this.chkVediTuttiLotti.AutoSize = true;
            this.chkVediTuttiLotti.Checked = true;
            this.chkVediTuttiLotti.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVediTuttiLotti.Location = new System.Drawing.Point(15, 407);
            this.chkVediTuttiLotti.Name = "chkVediTuttiLotti";
            this.chkVediTuttiLotti.Size = new System.Drawing.Size(216, 17);
            this.chkVediTuttiLotti.TabIndex = 13;
            this.chkVediTuttiLotti.Text = "Visualizza anche lotti a cui non concorre";
            this.chkVediTuttiLotti.UseVisualStyleBackColor = true;
            this.chkVediTuttiLotti.CheckedChanged += new System.EventHandler(this.chkVediTuttiLotti_CheckedChanged);
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(696, 407);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 12;
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
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(298, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Lotti a cui concorre il partecipante (singolo o raggruppamento)";
            // 
            // txtPartecipante
            // 
            this.txtPartecipante.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPartecipante.Location = new System.Drawing.Point(15, 27);
            this.txtPartecipante.Name = "txtPartecipante";
            this.txtPartecipante.ReadOnly = true;
            this.txtPartecipante.Size = new System.Drawing.Size(756, 20);
            this.txtPartecipante.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Partecipante alla gara (capogruppo in caso di raggruppamento):";
            // 
            // chkListaLotti
            // 
            this.chkListaLotti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkListaLotti.CheckBoxes = true;
            this.chkListaLotti.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.colhead1});
            this.chkListaLotti.FullRowSelect = true;
            this.chkListaLotti.GridLines = true;
            this.chkListaLotti.Location = new System.Drawing.Point(15, 87);
            this.chkListaLotti.Name = "chkListaLotti";
            this.chkListaLotti.Size = new System.Drawing.Size(756, 314);
            this.chkListaLotti.TabIndex = 23;
            this.chkListaLotti.UseCompatibleStateImageBehavior = false;
            this.chkListaLotti.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "CIG";
            this.columnHeader1.Width = 86;
            // 
            // colhead1
            // 
            this.colhead1.Text = "Descrizione del lotto";
            this.colhead1.Width = 751;
            // 
            // frmLottiPartecipati
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 440);
            this.Controls.Add(this.chkListaLotti);
            this.Controls.Add(this.chkVediTuttiLotti);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPartecipante);
            this.Controls.Add(this.label1);
            this.Name = "frmLottiPartecipati";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lotti a cui concorre un partecipante alla gara";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkVediTuttiLotti;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPartecipante;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView chkListaLotti;
        private System.Windows.Forms.ColumnHeader colhead1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}