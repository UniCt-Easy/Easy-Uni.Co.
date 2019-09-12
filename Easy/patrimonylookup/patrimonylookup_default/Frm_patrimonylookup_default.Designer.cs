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

namespace patrimonylookup_default
{
    partial class Frm_patrimonylookup_default
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
            this.grpAnnoSuccessivo = new System.Windows.Forms.GroupBox();
            this.txtNewDescrizioe = new System.Windows.Forms.TextBox();
            this.grpStatoPatrimSucc = new System.Windows.Forms.GroupBox();
            this.txtNewStatoPatrim = new System.Windows.Forms.TextBox();
            this.rdbPassivitaSucc = new System.Windows.Forms.RadioButton();
            this.rdbAttivitaSucc = new System.Windows.Forms.RadioButton();
            this.btnNewStatoPatrim = new System.Windows.Forms.Button();
            this.grpAnnoCorrente = new System.Windows.Forms.GroupBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.grpStatoPatrimCorr = new System.Windows.Forms.GroupBox();
            this.txtStatoPatrim = new System.Windows.Forms.TextBox();
            this.btnStatoPatrim = new System.Windows.Forms.Button();
            this.rdbPassivitaCorr = new System.Windows.Forms.RadioButton();
            this.rdbAttivitaCorr = new System.Windows.Forms.RadioButton();
            this.DS = new patrimonylookup_default.vistaForm();
            this.grpAnnoSuccessivo.SuspendLayout();
            this.grpStatoPatrimSucc.SuspendLayout();
            this.grpAnnoCorrente.SuspendLayout();
            this.grpStatoPatrimCorr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // grpAnnoSuccessivo
            // 
            this.grpAnnoSuccessivo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAnnoSuccessivo.Controls.Add(this.txtNewDescrizioe);
            this.grpAnnoSuccessivo.Controls.Add(this.grpStatoPatrimSucc);
            this.grpAnnoSuccessivo.Location = new System.Drawing.Point(13, 114);
            this.grpAnnoSuccessivo.Name = "grpAnnoSuccessivo";
            this.grpAnnoSuccessivo.Size = new System.Drawing.Size(462, 100);
            this.grpAnnoSuccessivo.TabIndex = 3;
            this.grpAnnoSuccessivo.TabStop = false;
            this.grpAnnoSuccessivo.Text = "Anno Successivo";
            // 
            // txtNewDescrizioe
            // 
            this.txtNewDescrizioe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewDescrizioe.Location = new System.Drawing.Point(253, 24);
            this.txtNewDescrizioe.Multiline = true;
            this.txtNewDescrizioe.Name = "txtNewDescrizioe";
            this.txtNewDescrizioe.ReadOnly = true;
            this.txtNewDescrizioe.Size = new System.Drawing.Size(200, 64);
            this.txtNewDescrizioe.TabIndex = 1;
            this.txtNewDescrizioe.TabStop = false;
            this.txtNewDescrizioe.Tag = "patrimony1.title?patrimonylookupview.newtitle";
            // 
            // grpStatoPatrimSucc
            // 
            this.grpStatoPatrimSucc.Controls.Add(this.txtNewStatoPatrim);
            this.grpStatoPatrimSucc.Controls.Add(this.rdbPassivitaSucc);
            this.grpStatoPatrimSucc.Controls.Add(this.rdbAttivitaSucc);
            this.grpStatoPatrimSucc.Controls.Add(this.btnNewStatoPatrim);
            this.grpStatoPatrimSucc.Location = new System.Drawing.Point(8, 16);
            this.grpStatoPatrimSucc.Name = "grpStatoPatrimSucc";
            this.grpStatoPatrimSucc.Size = new System.Drawing.Size(239, 72);
            this.grpStatoPatrimSucc.TabIndex = 0;
            this.grpStatoPatrimSucc.TabStop = false;
            this.grpStatoPatrimSucc.Tag = "";
            this.grpStatoPatrimSucc.Text = "Nuovo Codice Stato Patrimoniale";
            // 
            // txtNewStatoPatrim
            // 
            this.txtNewStatoPatrim.Location = new System.Drawing.Point(125, 40);
            this.txtNewStatoPatrim.Name = "txtNewStatoPatrim";
            this.txtNewStatoPatrim.Size = new System.Drawing.Size(100, 20);
            this.txtNewStatoPatrim.TabIndex = 2;
            this.txtNewStatoPatrim.Tag = "patrimony1.codepatrimony?patrimonylookupview.newcodepatrimony";
            // 
            // rdbPassivitaSucc
            // 
            this.rdbPassivitaSucc.Enabled = false;
            this.rdbPassivitaSucc.Location = new System.Drawing.Point(96, 16);
            this.rdbPassivitaSucc.Name = "rdbPassivitaSucc";
            this.rdbPassivitaSucc.Size = new System.Drawing.Size(74, 16);
            this.rdbPassivitaSucc.TabIndex = 1;
            this.rdbPassivitaSucc.Tag = "patrimony1.patpart:P?patrimonylookupview.newpatpart:P";
            this.rdbPassivitaSucc.Text = "Passività";
            this.rdbPassivitaSucc.CheckedChanged += new System.EventHandler(this.rdbPassivitaSucc_CheckedChanged);
            // 
            // rdbAttivitaSucc
            // 
            this.rdbAttivitaSucc.Checked = true;
            this.rdbAttivitaSucc.Enabled = false;
            this.rdbAttivitaSucc.Location = new System.Drawing.Point(8, 16);
            this.rdbAttivitaSucc.Name = "rdbAttivitaSucc";
            this.rdbAttivitaSucc.Size = new System.Drawing.Size(64, 16);
            this.rdbAttivitaSucc.TabIndex = 0;
            this.rdbAttivitaSucc.TabStop = true;
            this.rdbAttivitaSucc.Tag = "patrimony1.patpart:A?patrimonylookupview.newpatpart:A";
            this.rdbAttivitaSucc.Text = "Attività";
            this.rdbAttivitaSucc.CheckedChanged += new System.EventHandler(this.rdbAttivitaSucc_CheckedChanged);
            // 
            // btnNewStatoPatrim
            // 
            this.btnNewStatoPatrim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewStatoPatrim.ImageIndex = 0;
            this.btnNewStatoPatrim.Location = new System.Drawing.Point(8, 40);
            this.btnNewStatoPatrim.Name = "btnNewStatoPatrim";
            this.btnNewStatoPatrim.Size = new System.Drawing.Size(111, 23);
            this.btnNewStatoPatrim.TabIndex = 1;
            this.btnNewStatoPatrim.TabStop = false;
            this.btnNewStatoPatrim.Tag = "";
            this.btnNewStatoPatrim.Text = "Stato Patrimoniale";
            this.btnNewStatoPatrim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpAnnoCorrente
            // 
            this.grpAnnoCorrente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAnnoCorrente.Controls.Add(this.txtDescrizione);
            this.grpAnnoCorrente.Controls.Add(this.grpStatoPatrimCorr);
            this.grpAnnoCorrente.Location = new System.Drawing.Point(13, 10);
            this.grpAnnoCorrente.Name = "grpAnnoCorrente";
            this.grpAnnoCorrente.Size = new System.Drawing.Size(462, 100);
            this.grpAnnoCorrente.TabIndex = 2;
            this.grpAnnoCorrente.TabStop = false;
            this.grpAnnoCorrente.Text = "Anno Corrente";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(253, 24);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.ReadOnly = true;
            this.txtDescrizione.Size = new System.Drawing.Size(200, 64);
            this.txtDescrizione.TabIndex = 1;
            this.txtDescrizione.TabStop = false;
            this.txtDescrizione.Tag = "patrimony.title?patrimonylookupview.oldtitle";
            // 
            // grpStatoPatrimCorr
            // 
            this.grpStatoPatrimCorr.Controls.Add(this.txtStatoPatrim);
            this.grpStatoPatrimCorr.Controls.Add(this.btnStatoPatrim);
            this.grpStatoPatrimCorr.Controls.Add(this.rdbPassivitaCorr);
            this.grpStatoPatrimCorr.Controls.Add(this.rdbAttivitaCorr);
            this.grpStatoPatrimCorr.Location = new System.Drawing.Point(8, 16);
            this.grpStatoPatrimCorr.Name = "grpStatoPatrimCorr";
            this.grpStatoPatrimCorr.Size = new System.Drawing.Size(239, 72);
            this.grpStatoPatrimCorr.TabIndex = 0;
            this.grpStatoPatrimCorr.TabStop = false;
            this.grpStatoPatrimCorr.Tag = "";
            this.grpStatoPatrimCorr.Text = "Codice  Stato Patrimoniale Attuale";
            // 
            // txtStatoPatrim
            // 
            this.txtStatoPatrim.Location = new System.Drawing.Point(128, 40);
            this.txtStatoPatrim.Name = "txtStatoPatrim";
            this.txtStatoPatrim.Size = new System.Drawing.Size(100, 20);
            this.txtStatoPatrim.TabIndex = 3;
            this.txtStatoPatrim.Tag = "patrimony.codepatrimony?patrimonylookupview.oldcodepatrimony";
            // 
            // btnStatoPatrim
            // 
            this.btnStatoPatrim.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnStatoPatrim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStatoPatrim.ImageIndex = 0;
            this.btnStatoPatrim.Location = new System.Drawing.Point(8, 40);
            this.btnStatoPatrim.Name = "btnStatoPatrim";
            this.btnStatoPatrim.Size = new System.Drawing.Size(111, 23);
            this.btnStatoPatrim.TabIndex = 2;
            this.btnStatoPatrim.Tag = "";
            this.btnStatoPatrim.Text = "Stato Patrimoniale";
            this.btnStatoPatrim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rdbPassivitaCorr
            // 
            this.rdbPassivitaCorr.Location = new System.Drawing.Point(96, 16);
            this.rdbPassivitaCorr.Name = "rdbPassivitaCorr";
            this.rdbPassivitaCorr.Size = new System.Drawing.Size(74, 16);
            this.rdbPassivitaCorr.TabIndex = 1;
            this.rdbPassivitaCorr.Tag = "patrimony.patpart:P?patrimonylookupview.oldpatpart:P";
            this.rdbPassivitaCorr.Text = "Passività";
            this.rdbPassivitaCorr.CheckedChanged += new System.EventHandler(this.rdbPassivitaCorr_CheckedChanged);
            // 
            // rdbAttivitaCorr
            // 
            this.rdbAttivitaCorr.Checked = true;
            this.rdbAttivitaCorr.Location = new System.Drawing.Point(8, 16);
            this.rdbAttivitaCorr.Name = "rdbAttivitaCorr";
            this.rdbAttivitaCorr.Size = new System.Drawing.Size(64, 16);
            this.rdbAttivitaCorr.TabIndex = 0;
            this.rdbAttivitaCorr.TabStop = true;
            this.rdbAttivitaCorr.Tag = "patrimony.patpart:A?patrimonylookupview.oldpatpart:A";
            this.rdbAttivitaCorr.Text = "Attività";
            this.rdbAttivitaCorr.CheckedChanged += new System.EventHandler(this.rdbAttivitaCorr_CheckedChanged);
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // Frm_patrimonylookup_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 227);
            this.Controls.Add(this.grpAnnoSuccessivo);
            this.Controls.Add(this.grpAnnoCorrente);
            this.Name = "Frm_patrimonylookup_default";
            this.Text = "Form1";
            this.grpAnnoSuccessivo.ResumeLayout(false);
            this.grpAnnoSuccessivo.PerformLayout();
            this.grpStatoPatrimSucc.ResumeLayout(false);
            this.grpStatoPatrimSucc.PerformLayout();
            this.grpAnnoCorrente.ResumeLayout(false);
            this.grpAnnoCorrente.PerformLayout();
            this.grpStatoPatrimCorr.ResumeLayout(false);
            this.grpStatoPatrimCorr.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAnnoSuccessivo;
        private System.Windows.Forms.TextBox txtNewDescrizioe;
        private System.Windows.Forms.GroupBox grpStatoPatrimSucc;
        private System.Windows.Forms.TextBox txtNewStatoPatrim;
        private System.Windows.Forms.RadioButton rdbPassivitaSucc;
        private System.Windows.Forms.RadioButton rdbAttivitaSucc;
        private System.Windows.Forms.Button btnNewStatoPatrim;
        private System.Windows.Forms.GroupBox grpAnnoCorrente;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.GroupBox grpStatoPatrimCorr;
        private System.Windows.Forms.TextBox txtStatoPatrim;
        private System.Windows.Forms.Button btnStatoPatrim;
        private System.Windows.Forms.RadioButton rdbPassivitaCorr;
        private System.Windows.Forms.RadioButton rdbAttivitaCorr;
        public vistaForm DS;
    }
}