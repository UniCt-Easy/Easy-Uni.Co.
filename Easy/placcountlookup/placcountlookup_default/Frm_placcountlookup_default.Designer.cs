
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


namespace placcountlookup_default
{
    partial class Frm_placcountlookup_default
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
            this.txtNewDescrizione = new System.Windows.Forms.TextBox();
            this.grpContoEconSucc = new System.Windows.Forms.GroupBox();
            this.txtNewContoEcon = new System.Windows.Forms.TextBox();
            this.rdbRicavoSucc = new System.Windows.Forms.RadioButton();
            this.rdbCostoSucc = new System.Windows.Forms.RadioButton();
            this.btnNewContoEcon = new System.Windows.Forms.Button();
            this.grpAnnoCorrente = new System.Windows.Forms.GroupBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.grpContoEconCorr = new System.Windows.Forms.GroupBox();
            this.txtContoEcon = new System.Windows.Forms.TextBox();
            this.btnContoEcon = new System.Windows.Forms.Button();
            this.rdbPassivitaCorr = new System.Windows.Forms.RadioButton();
            this.rdbCostoCorr = new System.Windows.Forms.RadioButton();
            this.DS = new placcountlookup_default.vistaForm();
            this.grpAnnoSuccessivo.SuspendLayout();
            this.grpContoEconSucc.SuspendLayout();
            this.grpAnnoCorrente.SuspendLayout();
            this.grpContoEconCorr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // grpAnnoSuccessivo
            // 
            this.grpAnnoSuccessivo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAnnoSuccessivo.Controls.Add(this.txtNewDescrizione);
            this.grpAnnoSuccessivo.Controls.Add(this.grpContoEconSucc);
            this.grpAnnoSuccessivo.Location = new System.Drawing.Point(13, 114);
            this.grpAnnoSuccessivo.Name = "grpAnnoSuccessivo";
            this.grpAnnoSuccessivo.Size = new System.Drawing.Size(473, 100);
            this.grpAnnoSuccessivo.TabIndex = 3;
            this.grpAnnoSuccessivo.TabStop = false;
            this.grpAnnoSuccessivo.Text = "Anno Successivo";
            // 
            // txtNewDescrizione
            // 
            this.txtNewDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewDescrizione.Location = new System.Drawing.Point(260, 24);
            this.txtNewDescrizione.Multiline = true;
            this.txtNewDescrizione.Name = "txtNewDescrizione";
            this.txtNewDescrizione.ReadOnly = true;
            this.txtNewDescrizione.Size = new System.Drawing.Size(200, 64);
            this.txtNewDescrizione.TabIndex = 1;
            this.txtNewDescrizione.TabStop = false;
            this.txtNewDescrizione.Tag = "placcount1.title?placcountlookupview.newtitle";
            // 
            // grpContoEconSucc
            // 
            this.grpContoEconSucc.Controls.Add(this.txtNewContoEcon);
            this.grpContoEconSucc.Controls.Add(this.rdbRicavoSucc);
            this.grpContoEconSucc.Controls.Add(this.rdbCostoSucc);
            this.grpContoEconSucc.Controls.Add(this.btnNewContoEcon);
            this.grpContoEconSucc.Location = new System.Drawing.Point(8, 16);
            this.grpContoEconSucc.Name = "grpContoEconSucc";
            this.grpContoEconSucc.Size = new System.Drawing.Size(246, 72);
            this.grpContoEconSucc.TabIndex = 0;
            this.grpContoEconSucc.TabStop = false;
            this.grpContoEconSucc.Tag = "";
            this.grpContoEconSucc.Text = "Nuovo Codice Conto Economico";
            // 
            // txtNewContoEcon
            // 
            this.txtNewContoEcon.Location = new System.Drawing.Point(133, 40);
            this.txtNewContoEcon.Name = "txtNewContoEcon";
            this.txtNewContoEcon.Size = new System.Drawing.Size(100, 20);
            this.txtNewContoEcon.TabIndex = 2;
            this.txtNewContoEcon.Tag = "placcount1.codeplaccount?placcountlookupview.newcodeplaccount";
            // 
            // rdbRicavoSucc
            // 
            this.rdbRicavoSucc.Enabled = false;
            this.rdbRicavoSucc.Location = new System.Drawing.Point(96, 16);
            this.rdbRicavoSucc.Name = "rdbRicavoSucc";
            this.rdbRicavoSucc.Size = new System.Drawing.Size(81, 16);
            this.rdbRicavoSucc.TabIndex = 1;
            this.rdbRicavoSucc.Tag = "placcount1.placcpart:R?placcountlookupview.newplaccpart:R";
            this.rdbRicavoSucc.Text = "Ricavi";
            this.rdbRicavoSucc.CheckedChanged += new System.EventHandler(this.rdbRicavoSucc_CheckedChanged);
            // 
            // rdbCostoSucc
            // 
            this.rdbCostoSucc.Checked = true;
            this.rdbCostoSucc.Enabled = false;
            this.rdbCostoSucc.Location = new System.Drawing.Point(8, 16);
            this.rdbCostoSucc.Name = "rdbCostoSucc";
            this.rdbCostoSucc.Size = new System.Drawing.Size(64, 16);
            this.rdbCostoSucc.TabIndex = 0;
            this.rdbCostoSucc.TabStop = true;
            this.rdbCostoSucc.Tag = "placcount1.placcpart:C?placcountlookupview.newplaccpart:C";
            this.rdbCostoSucc.Text = "Costi";
            this.rdbCostoSucc.CheckedChanged += new System.EventHandler(this.rdbCostoSucc_CheckedChanged);
            // 
            // btnNewContoEcon
            // 
            this.btnNewContoEcon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewContoEcon.ImageIndex = 0;
            this.btnNewContoEcon.Location = new System.Drawing.Point(8, 40);
            this.btnNewContoEcon.Name = "btnNewContoEcon";
            this.btnNewContoEcon.Size = new System.Drawing.Size(119, 23);
            this.btnNewContoEcon.TabIndex = 1;
            this.btnNewContoEcon.TabStop = false;
            this.btnNewContoEcon.Tag = "";
            this.btnNewContoEcon.Text = "Conto Economico";
            this.btnNewContoEcon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpAnnoCorrente
            // 
            this.grpAnnoCorrente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAnnoCorrente.Controls.Add(this.txtDescrizione);
            this.grpAnnoCorrente.Controls.Add(this.grpContoEconCorr);
            this.grpAnnoCorrente.Location = new System.Drawing.Point(13, 10);
            this.grpAnnoCorrente.Name = "grpAnnoCorrente";
            this.grpAnnoCorrente.Size = new System.Drawing.Size(473, 100);
            this.grpAnnoCorrente.TabIndex = 2;
            this.grpAnnoCorrente.TabStop = false;
            this.grpAnnoCorrente.Text = "Anno Corrente";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(260, 24);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.ReadOnly = true;
            this.txtDescrizione.Size = new System.Drawing.Size(200, 64);
            this.txtDescrizione.TabIndex = 1;
            this.txtDescrizione.TabStop = false;
            this.txtDescrizione.Tag = "placcount.title?placcountlookupview.oldtitle";
            // 
            // grpContoEconCorr
            // 
            this.grpContoEconCorr.Controls.Add(this.txtContoEcon);
            this.grpContoEconCorr.Controls.Add(this.btnContoEcon);
            this.grpContoEconCorr.Controls.Add(this.rdbPassivitaCorr);
            this.grpContoEconCorr.Controls.Add(this.rdbCostoCorr);
            this.grpContoEconCorr.Location = new System.Drawing.Point(8, 16);
            this.grpContoEconCorr.Name = "grpContoEconCorr";
            this.grpContoEconCorr.Size = new System.Drawing.Size(246, 72);
            this.grpContoEconCorr.TabIndex = 0;
            this.grpContoEconCorr.TabStop = false;
            this.grpContoEconCorr.Tag = "";
            this.grpContoEconCorr.Text = "Codice Conto Economico Attuale";
            // 
            // txtContoEcon
            // 
            this.txtContoEcon.Location = new System.Drawing.Point(133, 32);
            this.txtContoEcon.Name = "txtContoEcon";
            this.txtContoEcon.Size = new System.Drawing.Size(100, 20);
            this.txtContoEcon.TabIndex = 3;
            this.txtContoEcon.Tag = "placcount.codeplaccount?placcountlookupview.oldcodeplaccount";
            // 
            // btnContoEcon
            // 
            this.btnContoEcon.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnContoEcon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnContoEcon.ImageIndex = 0;
            this.btnContoEcon.Location = new System.Drawing.Point(8, 32);
            this.btnContoEcon.Name = "btnContoEcon";
            this.btnContoEcon.Size = new System.Drawing.Size(119, 23);
            this.btnContoEcon.TabIndex = 2;
            this.btnContoEcon.Tag = "";
            this.btnContoEcon.Text = "Conto Economico";
            this.btnContoEcon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rdbPassivitaCorr
            // 
            this.rdbPassivitaCorr.Location = new System.Drawing.Point(96, 16);
            this.rdbPassivitaCorr.Name = "rdbPassivitaCorr";
            this.rdbPassivitaCorr.Size = new System.Drawing.Size(81, 16);
            this.rdbPassivitaCorr.TabIndex = 1;
            this.rdbPassivitaCorr.Tag = "placcount.placcpart:R?placcountlookupview.oldplaccpart:R";
            this.rdbPassivitaCorr.Text = "Ricavi";
            this.rdbPassivitaCorr.CheckedChanged += new System.EventHandler(this.rdbRicavoCorr_CheckedChanged);
            // 
            // rdbCostoCorr
            // 
            this.rdbCostoCorr.Checked = true;
            this.rdbCostoCorr.Location = new System.Drawing.Point(8, 16);
            this.rdbCostoCorr.Name = "rdbCostoCorr";
            this.rdbCostoCorr.Size = new System.Drawing.Size(64, 16);
            this.rdbCostoCorr.TabIndex = 0;
            this.rdbCostoCorr.TabStop = true;
            this.rdbCostoCorr.Tag = "placcount.placcpart:C?placcountlookupview.oldplaccpart:C";
            this.rdbCostoCorr.Text = "Costi";
            this.rdbCostoCorr.CheckedChanged += new System.EventHandler(this.rdbCostoCorr_CheckedChanged);
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // Frm_placcountlookup_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 227);
            this.Controls.Add(this.grpAnnoSuccessivo);
            this.Controls.Add(this.grpAnnoCorrente);
            this.Name = "Frm_placcountlookup_default";
            this.Text = "Form1";
            this.grpAnnoSuccessivo.ResumeLayout(false);
            this.grpAnnoSuccessivo.PerformLayout();
            this.grpContoEconSucc.ResumeLayout(false);
            this.grpContoEconSucc.PerformLayout();
            this.grpAnnoCorrente.ResumeLayout(false);
            this.grpAnnoCorrente.PerformLayout();
            this.grpContoEconCorr.ResumeLayout(false);
            this.grpContoEconCorr.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAnnoSuccessivo;
        private System.Windows.Forms.TextBox txtNewDescrizione;
        private System.Windows.Forms.GroupBox grpContoEconSucc;
        private System.Windows.Forms.TextBox txtNewContoEcon;
        private System.Windows.Forms.RadioButton rdbRicavoSucc;
        private System.Windows.Forms.RadioButton rdbCostoSucc;
        private System.Windows.Forms.Button btnNewContoEcon;
        private System.Windows.Forms.GroupBox grpAnnoCorrente;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.GroupBox grpContoEconCorr;
        private System.Windows.Forms.TextBox txtContoEcon;
        private System.Windows.Forms.Button btnContoEcon;
        private System.Windows.Forms.RadioButton rdbPassivitaCorr;
        private System.Windows.Forms.RadioButton rdbCostoCorr;
        public vistaForm DS;
    }
}
