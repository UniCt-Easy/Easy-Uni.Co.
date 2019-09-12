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

﻿namespace profservicecig_detail {
    partial class Frm_profservicecig_detail {
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
            this.btnAutoInsDati = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.cmbAggiudicatario = new System.Windows.Forms.ComboBox();
            this.labAggiudicatario = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.cmbProceduradiScelta = new System.Windows.Forms.ComboBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblcig = new System.Windows.Forms.Label();
            this.txtcig = new System.Windows.Forms.TextBox();
            this.DS = new profservicecig_detail.vistaForm();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAutoInsDati
            // 
            this.btnAutoInsDati.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAutoInsDati.Location = new System.Drawing.Point(589, 11);
            this.btnAutoInsDati.Name = "btnAutoInsDati";
            this.btnAutoInsDati.Size = new System.Drawing.Size(112, 23);
            this.btnAutoInsDati.TabIndex = 187;
            this.btnAutoInsDati.TabStop = false;
            this.btnAutoInsDati.Text = "Inserisci dati";
            this.btnAutoInsDati.Click += new System.EventHandler(this.btnAutoInsDati_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(626, 355);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 179;
            this.btnCancel.Text = "Annulla";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(484, 355);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 178;
            this.btnOk.Tag = "mainsave";
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // cmbAggiudicatario
            // 
            this.cmbAggiudicatario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAggiudicatario.DisplayMember = "title";
            this.cmbAggiudicatario.Location = new System.Drawing.Point(19, 276);
            this.cmbAggiudicatario.Name = "cmbAggiudicatario";
            this.cmbAggiudicatario.Size = new System.Drawing.Size(540, 21);
            this.cmbAggiudicatario.TabIndex = 177;
            this.cmbAggiudicatario.Tag = "profservicecig.idavcp";
            this.cmbAggiudicatario.ValueMember = "idavcp";
            // 
            // labAggiudicatario
            // 
            this.labAggiudicatario.AutoSize = true;
            this.labAggiudicatario.Location = new System.Drawing.Point(18, 260);
            this.labAggiudicatario.Name = "labAggiudicatario";
            this.labAggiudicatario.Size = new System.Drawing.Size(74, 13);
            this.labAggiudicatario.TabIndex = 186;
            this.labAggiudicatario.Text = "Aggiudicatario";
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(16, 201);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(182, 23);
            this.label24.TabIndex = 185;
            this.label24.Text = "Procedura di scelta del contraente";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbProceduradiScelta
            // 
            this.cmbProceduradiScelta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbProceduradiScelta.DisplayMember = "description";
            this.cmbProceduradiScelta.Location = new System.Drawing.Point(19, 227);
            this.cmbProceduradiScelta.Name = "cmbProceduradiScelta";
            this.cmbProceduradiScelta.Size = new System.Drawing.Size(399, 21);
            this.cmbProceduradiScelta.TabIndex = 176;
            this.cmbProceduradiScelta.Tag = "profservicecig.idavcp_choice";
            this.cmbProceduradiScelta.ValueMember = "idavcp_choice";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(16, 112);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(88, 20);
            this.textBox5.TabIndex = 173;
            this.textBox5.Tag = "profservicecig.contractamount";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(13, 86);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(655, 23);
            this.label15.TabIndex = 184;
            this.label15.Text = "Importo di aggiudicazione al lordo degli oneri di sicurezza e delle ritenute da o" +
    "perare per legge e al netto dell’IVA";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(215, 37);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox4.Size = new System.Drawing.Size(490, 46);
            this.textBox4.TabIndex = 172;
            this.textBox4.Tag = "profservicecig.description";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(212, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(379, 14);
            this.label14.TabIndex = 183;
            this.label14.Text = "Oggetto del lotto identificato dal CIG";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(353, 163);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(137, 20);
            this.textBox1.TabIndex = 175;
            this.textBox1.Tag = "profservicecig.stop_contract";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(350, 147);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(283, 13);
            this.label11.TabIndex = 182;
            this.label11.Text = "Data di ultimazione lavori, servizi o forniture";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(16, 163);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(137, 20);
            this.textBox3.TabIndex = 174;
            this.textBox3.Tag = "profservicecig.start_contract";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(16, 147);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(266, 13);
            this.label12.TabIndex = 181;
            this.label12.Text = "Data di effettivo inizio lavori, servizi o forniture";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblcig
            // 
            this.lblcig.Location = new System.Drawing.Point(16, 15);
            this.lblcig.Name = "lblcig";
            this.lblcig.Size = new System.Drawing.Size(173, 19);
            this.lblcig.TabIndex = 180;
            this.lblcig.Tag = "";
            this.lblcig.Text = "Codice Identificativo di Gara(CIG)";
            this.lblcig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtcig
            // 
            this.txtcig.Location = new System.Drawing.Point(16, 37);
            this.txtcig.Name = "txtcig";
            this.txtcig.Size = new System.Drawing.Size(153, 20);
            this.txtcig.TabIndex = 171;
            this.txtcig.Tag = "profservicecig.cigcode";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // Frm_profservicecig_detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 389);
            this.Controls.Add(this.btnAutoInsDati);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cmbAggiudicatario);
            this.Controls.Add(this.labAggiudicatario);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.cmbProceduradiScelta);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblcig);
            this.Controls.Add(this.txtcig);
            this.Name = "Frm_profservicecig_detail";
            this.Text = "Frm_profservicecig_detail";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAutoInsDati;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ComboBox cmbAggiudicatario;
        private System.Windows.Forms.Label labAggiudicatario;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox cmbProceduradiScelta;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblcig;
        private System.Windows.Forms.TextBox txtcig;
        public vistaForm DS;
    }
}