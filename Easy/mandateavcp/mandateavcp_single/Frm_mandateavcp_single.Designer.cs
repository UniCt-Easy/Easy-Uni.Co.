
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


namespace mandateavcp_single {
    partial class Frm_mandateavcp_single {
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
            this.DS = new mandateavcp_single.vistaForm();
            this.txtCF = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.grpBoxManuale = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtCFEstero = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.chkSingolo = new System.Windows.Forms.CheckBox();
            this.label24 = new System.Windows.Forms.Label();
            this.cmbRuolo = new System.Windows.Forms.ComboBox();
            this.gboxGruppo = new System.Windows.Forms.GroupBox();
            this.cmbCapogruppo = new System.Windows.Forms.ComboBox();
            this.labelCapo = new System.Windows.Forms.Label();
            this.txtRagSociale = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.grpBoxManuale.SuspendLayout();
            this.gboxGruppo.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // txtCF
            // 
            this.txtCF.Location = new System.Drawing.Point(159, 95);
            this.txtCF.Name = "txtCF";
            this.txtCF.Size = new System.Drawing.Size(249, 20);
            this.txtCF.TabIndex = 3;
            this.txtCF.Tag = "mandateavcp.cf";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(147, 19);
            this.label7.TabIndex = 159;
            this.label7.Text = "Codice Fiscale / Partita IVA";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpBoxManuale
            // 
            this.grpBoxManuale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxManuale.Controls.Add(this.label17);
            this.grpBoxManuale.Controls.Add(this.txtTitle);
            this.grpBoxManuale.Location = new System.Drawing.Point(12, 12);
            this.grpBoxManuale.Name = "grpBoxManuale";
            this.grpBoxManuale.Size = new System.Drawing.Size(612, 46);
            this.grpBoxManuale.TabIndex = 2;
            this.grpBoxManuale.TabStop = false;
            this.grpBoxManuale.Tag = "AutoChoose.txtTitle.lista.(active=\'S\')";
            this.grpBoxManuale.Text = "Partecipante (scelta dall\'anagrafica)";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(2, 20);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 13);
            this.label17.TabIndex = 3;
            this.label17.Text = "Denominazione";
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(88, 17);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(507, 20);
            this.txtTitle.TabIndex = 2;
            this.txtTitle.Tag = "registry.title?x";
            // 
            // txtCFEstero
            // 
            this.txtCFEstero.Location = new System.Drawing.Point(159, 130);
            this.txtCFEstero.Name = "txtCFEstero";
            this.txtCFEstero.Size = new System.Drawing.Size(249, 20);
            this.txtCFEstero.TabIndex = 4;
            this.txtCFEstero.Tag = "mandateavcp.foreigncf";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 19);
            this.label1.TabIndex = 161;
            this.label1.Text = "Identificativo Fiscale Estero";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(541, 260);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 163;
            this.btnAnnulla.TabStop = false;
            this.btnAnnulla.Text = "Annulla";
            this.btnAnnulla.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(443, 260);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 162;
            this.btnOk.TabStop = false;
            this.btnOk.Tag = "mainsave";
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // chkSingolo
            // 
            this.chkSingolo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSingolo.Location = new System.Drawing.Point(7, 155);
            this.chkSingolo.Name = "chkSingolo";
            this.chkSingolo.Size = new System.Drawing.Size(203, 21);
            this.chkSingolo.TabIndex = 5;
            this.chkSingolo.Tag = "mandateavcp.flagcontractor:S:N";
            this.chkSingolo.Text = "Partecipante singolo";
            this.chkSingolo.CheckedChanged += new System.EventHandler(this.chkSingolo_CheckedChanged);
            // 
            // label24
            // 
            this.label24.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label24.Location = new System.Drawing.Point(6, 16);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(78, 23);
            this.label24.TabIndex = 165;
            this.label24.Text = "Ruolo";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbRuolo
            // 
            this.cmbRuolo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRuolo.DataSource = this.DS.avcprole;
            this.cmbRuolo.DisplayMember = "description";
            this.cmbRuolo.Location = new System.Drawing.Point(90, 18);
            this.cmbRuolo.Name = "cmbRuolo";
            this.cmbRuolo.Size = new System.Drawing.Size(263, 21);
            this.cmbRuolo.TabIndex = 164;
            this.cmbRuolo.Tag = "mandateavcp.idavcp_role";
            this.cmbRuolo.ValueMember = "idavcp_role";
            // 
            // gboxGruppo
            // 
            this.gboxGruppo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxGruppo.Controls.Add(this.cmbCapogruppo);
            this.gboxGruppo.Controls.Add(this.labelCapo);
            this.gboxGruppo.Controls.Add(this.cmbRuolo);
            this.gboxGruppo.Controls.Add(this.label24);
            this.gboxGruppo.Location = new System.Drawing.Point(6, 182);
            this.gboxGruppo.Name = "gboxGruppo";
            this.gboxGruppo.Size = new System.Drawing.Size(612, 69);
            this.gboxGruppo.TabIndex = 166;
            this.gboxGruppo.TabStop = false;
            this.gboxGruppo.Text = "Partecipazione in associazione con altri soggetti";
            // 
            // cmbCapogruppo
            // 
            this.cmbCapogruppo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCapogruppo.DataSource = this.DS.capogruppo;
            this.cmbCapogruppo.DisplayMember = "title";
            this.cmbCapogruppo.Location = new System.Drawing.Point(88, 45);
            this.cmbCapogruppo.Name = "cmbCapogruppo";
            this.cmbCapogruppo.Size = new System.Drawing.Size(501, 21);
            this.cmbCapogruppo.TabIndex = 167;
            this.cmbCapogruppo.Tag = "mandateavcp.idmain_avcp";
            this.cmbCapogruppo.ValueMember = "idavcp";
            // 
            // labelCapo
            // 
            this.labelCapo.AutoSize = true;
            this.labelCapo.Location = new System.Drawing.Point(17, 48);
            this.labelCapo.Name = "labelCapo";
            this.labelCapo.Size = new System.Drawing.Size(65, 13);
            this.labelCapo.TabIndex = 166;
            this.labelCapo.Text = "Capogruppo";
            this.labelCapo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRagSociale
            // 
            this.txtRagSociale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRagSociale.Location = new System.Drawing.Point(159, 70);
            this.txtRagSociale.Name = "txtRagSociale";
            this.txtRagSociale.Size = new System.Drawing.Size(461, 20);
            this.txtRagSociale.TabIndex = 167;
            this.txtRagSociale.Tag = "mandateavcp.title";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(56, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 19);
            this.label2.TabIndex = 168;
            this.label2.Text = "Ragione sociale";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.Location = new System.Drawing.Point(159, 155);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(203, 21);
            this.checkBox1.TabIndex = 169;
            this.checkBox1.Tag = "mandateavcp.flagnonparticipating:S:N";
            this.checkBox1.Text = "Invitato (Non Partecipante alla Gara)";
            // 
            // Frm_mandateavcp_single
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 295);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRagSociale);
            this.Controls.Add(this.gboxGruppo);
            this.Controls.Add(this.chkSingolo);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtCFEstero);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCF);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.grpBoxManuale);
            this.Name = "Frm_mandateavcp_single";
            this.Text = "Frm_mandateavcp_single";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.grpBoxManuale.ResumeLayout(false);
            this.grpBoxManuale.PerformLayout();
            this.gboxGruppo.ResumeLayout(false);
            this.gboxGruppo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.TextBox txtCF;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox grpBoxManuale;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtCFEstero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.CheckBox chkSingolo;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox cmbRuolo;
        private System.Windows.Forms.GroupBox gboxGruppo;
        private System.Windows.Forms.ComboBox cmbCapogruppo;
        private System.Windows.Forms.Label labelCapo;
        private System.Windows.Forms.TextBox txtRagSociale;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
