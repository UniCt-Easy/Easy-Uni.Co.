/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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

﻿namespace registryvisura_anagraficadetail {
    partial class Frm_registryvisura_anagraficadetail {
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
            this.DS = new registryvisura_anagraficadetail.vistaForm();
            this.txtDataIniziovalidita = new System.Windows.Forms.TextBox();
            this.txtscadenza = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labDurcFileName = new System.Windows.Forms.Label();
            this.btnVisualizzaVisura = new System.Windows.Forms.Button();
            this.btnRimuoviVisura = new System.Windows.Forms.Button();
            this.btnAllegaVisura = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.opendlg = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // txtDataIniziovalidita
            // 
            this.txtDataIniziovalidita.Location = new System.Drawing.Point(116, 42);
            this.txtDataIniziovalidita.Name = "txtDataIniziovalidita";
            this.txtDataIniziovalidita.Size = new System.Drawing.Size(120, 20);
            this.txtDataIniziovalidita.TabIndex = 67;
            this.txtDataIniziovalidita.Tag = "registryvisura.start";
            this.txtDataIniziovalidita.Leave += new System.EventHandler(this.txtDataIniziovalidita_Leave);
            // 
            // txtscadenza
            // 
            this.txtscadenza.Location = new System.Drawing.Point(327, 42);
            this.txtscadenza.Name = "txtscadenza";
            this.txtscadenza.Size = new System.Drawing.Size(120, 20);
            this.txtscadenza.TabIndex = 68;
            this.txtscadenza.Tag = "registryvisura.stop";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(234, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 23);
            this.label10.TabIndex = 70;
            this.label10.Text = "Data scadenza";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(7, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 30);
            this.label4.TabIndex = 69;
            this.label4.Text = "Data inizio validità";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labDurcFileName);
            this.groupBox3.Controls.Add(this.btnVisualizzaVisura);
            this.groupBox3.Controls.Add(this.btnRimuoviVisura);
            this.groupBox3.Controls.Add(this.btnAllegaVisura);
            this.groupBox3.Location = new System.Drawing.Point(15, 90);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(432, 79);
            this.groupBox3.TabIndex = 185;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Allegato Visura Camerale";
            // 
            // labDurcFileName
            // 
            this.labDurcFileName.Location = new System.Drawing.Point(10, 16);
            this.labDurcFileName.Name = "labDurcFileName";
            this.labDurcFileName.Size = new System.Drawing.Size(406, 18);
            this.labDurcFileName.TabIndex = 75;
            // 
            // btnVisualizzaVisura
            // 
            this.btnVisualizzaVisura.Location = new System.Drawing.Point(333, 41);
            this.btnVisualizzaVisura.Name = "btnVisualizzaVisura";
            this.btnVisualizzaVisura.Size = new System.Drawing.Size(79, 24);
            this.btnVisualizzaVisura.TabIndex = 2;
            this.btnVisualizzaVisura.Text = "Visualizza";
            this.btnVisualizzaVisura.UseVisualStyleBackColor = true;
            this.btnVisualizzaVisura.Click += new System.EventHandler(this.btnVisualizzaDurc_Click);
            // 
            // btnRimuoviVisura
            // 
            this.btnRimuoviVisura.Location = new System.Drawing.Point(214, 41);
            this.btnRimuoviVisura.Name = "btnRimuoviVisura";
            this.btnRimuoviVisura.Size = new System.Drawing.Size(99, 24);
            this.btnRimuoviVisura.TabIndex = 1;
            this.btnRimuoviVisura.Text = "Rimuovi Allegato";
            this.btnRimuoviVisura.UseVisualStyleBackColor = true;
            this.btnRimuoviVisura.Click += new System.EventHandler(this.btnRimuoviDurc_Click);
            // 
            // btnAllegaVisura
            // 
            this.btnAllegaVisura.Location = new System.Drawing.Point(117, 41);
            this.btnAllegaVisura.Name = "btnAllegaVisura";
            this.btnAllegaVisura.Size = new System.Drawing.Size(79, 24);
            this.btnAllegaVisura.TabIndex = 0;
            this.btnAllegaVisura.Text = "Allega";
            this.btnAllegaVisura.UseVisualStyleBackColor = true;
            this.btnAllegaVisura.Click += new System.EventHandler(this.btnAllegaDurc_Click);
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(372, 214);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(72, 24);
            this.btnAnnulla.TabIndex = 187;
            this.btnAnnulla.Text = "Annulla";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(274, 214);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(72, 24);
            this.btnOk.TabIndex = 186;
            this.btnOk.Tag = "mainsave";
            this.btnOk.Text = "OK";
            // 
            // opendlg
            // 
            this.opendlg.Title = "Scegli il file da allegare";
            // 
            // Frm_registryvisura_anagraficadetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 274);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtDataIniziovalidita);
            this.Controls.Add(this.txtscadenza);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Name = "Frm_registryvisura_anagraficadetail";
            this.Text = "Frm_registryvisura_anagraficadetail";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtDataIniziovalidita;
        private System.Windows.Forms.TextBox txtscadenza;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labDurcFileName;
        private System.Windows.Forms.Button btnVisualizzaVisura;
        private System.Windows.Forms.Button btnRimuoviVisura;
        private System.Windows.Forms.Button btnAllegaVisura;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.OpenFileDialog opendlg;
        public vistaForm DS;
    }
}