
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


namespace finyearview_previsionfin
{
    partial class Frm_finyearview_previsionfin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing){
            inChiusura = true;
            if (disposing && (components != null)){
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_finyearview_previsionfin));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.txtPrevisionePrincipalePrecUpb = new System.Windows.Forms.TextBox();
            this.txtPrevisioneSecondariaPrecUpb = new System.Windows.Forms.TextBox();
            this.txtPrevisionePrincipaleCorrUpb = new System.Windows.Forms.TextBox();
            this.txtPrevisioneSecondariaCorrUpb = new System.Windows.Forms.TextBox();
            this.grpPrevSec = new System.Windows.Forms.GroupBox();
            this.lblEsCorrSeconda = new System.Windows.Forms.Label();
            this.lblEsPrecSeconda = new System.Windows.Forms.Label();
            this.lblEsPrecPrima = new System.Windows.Forms.Label();
            this.MetaDataDetail = new System.Windows.Forms.TabControl();
            this.tabPrincipale = new System.Windows.Forms.TabPage();
            this.grpPrevisione = new System.Windows.Forms.GroupBox();
            this.gboxPrimaPrevisione = new System.Windows.Forms.GroupBox();
            this.lblEsCorrentePrima = new System.Windows.Forms.Label();
            this.gboxRipartizione = new System.Windows.Forms.GroupBox();
            this.txtResiduiPrecUpb = new System.Windows.Forms.TextBox();
            this.txtResiduiCorrUpb = new System.Windows.Forms.TextBox();
            this.lblRipCorrente = new System.Windows.Forms.Label();
            this.lblRipPrecedente = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtPrevisione5Upb = new System.Windows.Forms.TextBox();
            this.txtPrevisione4Upb = new System.Windows.Forms.TextBox();
            this.txtPrevisione3Upb = new System.Windows.Forms.TextBox();
            this.txtPrevisione2Upb = new System.Windows.Forms.TextBox();
            this.lblPrevisione5 = new System.Windows.Forms.Label();
            this.lblPrevisione4 = new System.Windows.Forms.Label();
            this.lblPrevisione2 = new System.Windows.Forms.Label();
            this.lblPrevisione3 = new System.Windows.Forms.Label();
            this.DS = new finyearview_previsionfin.vistaForm();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.gboxBilAnnuale = new System.Windows.Forms.GroupBox();
            this.btnBilancio = new System.Windows.Forms.Button();
            this.txtCodiceBilancio = new System.Windows.Forms.TextBox();
            this.txtDenominazioneBilancio = new System.Windows.Forms.TextBox();
            this.rdbEntrata = new System.Windows.Forms.RadioButton();
            this.rdbSpesa = new System.Windows.Forms.RadioButton();
            this.grpPrevSec.SuspendLayout();
            this.MetaDataDetail.SuspendLayout();
            this.tabPrincipale.SuspendLayout();
            this.grpPrevisione.SuspendLayout();
            this.gboxPrimaPrevisione.SuspendLayout();
            this.gboxRipartizione.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.gboxBilAnnuale.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(187, 415);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 17;
            this.btnOK.Tag = "mainsave";
            this.btnOK.Text = "OK";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(291, 415);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 18;
            this.btnAnnulla.Text = "Annulla";
            // 
            // txtPrevisionePrincipalePrecUpb
            // 
            this.txtPrevisionePrincipalePrecUpb.Location = new System.Drawing.Point(400, 22);
            this.txtPrevisionePrincipalePrecUpb.Name = "txtPrevisionePrincipalePrecUpb";
            this.txtPrevisionePrincipalePrecUpb.Size = new System.Drawing.Size(100, 20);
            this.txtPrevisionePrincipalePrecUpb.TabIndex = 9;
            this.txtPrevisionePrincipalePrecUpb.Tag = "finyearview.previousprevision";
            // 
            // txtPrevisioneSecondariaPrecUpb
            // 
            this.txtPrevisioneSecondariaPrecUpb.Location = new System.Drawing.Point(400, 22);
            this.txtPrevisioneSecondariaPrecUpb.Name = "txtPrevisioneSecondariaPrecUpb";
            this.txtPrevisioneSecondariaPrecUpb.Size = new System.Drawing.Size(100, 20);
            this.txtPrevisioneSecondariaPrecUpb.TabIndex = 10;
            this.txtPrevisioneSecondariaPrecUpb.Tag = "finyearview.previoussecondaryprev";
            // 
            // txtPrevisionePrincipaleCorrUpb
            // 
            this.txtPrevisionePrincipaleCorrUpb.Location = new System.Drawing.Point(120, 22);
            this.txtPrevisionePrincipaleCorrUpb.Name = "txtPrevisionePrincipaleCorrUpb";
            this.txtPrevisionePrincipaleCorrUpb.Size = new System.Drawing.Size(100, 20);
            this.txtPrevisionePrincipaleCorrUpb.TabIndex = 8;
            this.txtPrevisionePrincipaleCorrUpb.Tag = "finyearview.prevision";
            // 
            // txtPrevisioneSecondariaCorrUpb
            // 
            this.txtPrevisioneSecondariaCorrUpb.Location = new System.Drawing.Point(120, 22);
            this.txtPrevisioneSecondariaCorrUpb.Name = "txtPrevisioneSecondariaCorrUpb";
            this.txtPrevisioneSecondariaCorrUpb.Size = new System.Drawing.Size(100, 20);
            this.txtPrevisioneSecondariaCorrUpb.TabIndex = 9;
            this.txtPrevisioneSecondariaCorrUpb.Tag = "finyearview.secondaryprev";
            // 
            // grpPrevSec
            // 
            this.grpPrevSec.Controls.Add(this.txtPrevisioneSecondariaPrecUpb);
            this.grpPrevSec.Controls.Add(this.txtPrevisioneSecondariaCorrUpb);
            this.grpPrevSec.Controls.Add(this.lblEsCorrSeconda);
            this.grpPrevSec.Controls.Add(this.lblEsPrecSeconda);
            this.grpPrevSec.Location = new System.Drawing.Point(8, 64);
            this.grpPrevSec.Name = "grpPrevSec";
            this.grpPrevSec.Size = new System.Drawing.Size(512, 48);
            this.grpPrevSec.TabIndex = 16;
            this.grpPrevSec.TabStop = false;
            this.grpPrevSec.Text = "Previsione Secondaria";
            // 
            // lblEsCorrSeconda
            // 
            this.lblEsCorrSeconda.Location = new System.Drawing.Point(8, 24);
            this.lblEsCorrSeconda.Name = "lblEsCorrSeconda";
            this.lblEsCorrSeconda.Size = new System.Drawing.Size(100, 16);
            this.lblEsCorrSeconda.TabIndex = 6;
            this.lblEsCorrSeconda.Text = "Prev. Corr.";
            this.lblEsCorrSeconda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEsPrecSeconda
            // 
            this.lblEsPrecSeconda.Location = new System.Drawing.Point(288, 24);
            this.lblEsPrecSeconda.Name = "lblEsPrecSeconda";
            this.lblEsPrecSeconda.Size = new System.Drawing.Size(100, 16);
            this.lblEsPrecSeconda.TabIndex = 8;
            this.lblEsPrecSeconda.Text = "Prev. Prec.";
            this.lblEsPrecSeconda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEsPrecPrima
            // 
            this.lblEsPrecPrima.Location = new System.Drawing.Point(288, 24);
            this.lblEsPrecPrima.Name = "lblEsPrecPrima";
            this.lblEsPrecPrima.Size = new System.Drawing.Size(100, 16);
            this.lblEsPrecPrima.TabIndex = 7;
            this.lblEsPrecPrima.Text = "Prev. Prec.";
            this.lblEsPrecPrima.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MetaDataDetail
            // 
            this.MetaDataDetail.Controls.Add(this.tabPrincipale);
            this.MetaDataDetail.Location = new System.Drawing.Point(4, 91);
            this.MetaDataDetail.Name = "MetaDataDetail";
            this.MetaDataDetail.SelectedIndex = 0;
            this.MetaDataDetail.Size = new System.Drawing.Size(552, 314);
            this.MetaDataDetail.TabIndex = 16;
            // 
            // tabPrincipale
            // 
            this.tabPrincipale.Controls.Add(this.grpPrevisione);
            this.tabPrincipale.Location = new System.Drawing.Point(4, 22);
            this.tabPrincipale.Name = "tabPrincipale";
            this.tabPrincipale.Size = new System.Drawing.Size(544, 288);
            this.tabPrincipale.TabIndex = 0;
            this.tabPrincipale.Text = "Principale";
            this.tabPrincipale.UseVisualStyleBackColor = true;
            // 
            // grpPrevisione
            // 
            this.grpPrevisione.Controls.Add(this.gboxPrimaPrevisione);
            this.grpPrevisione.Controls.Add(this.grpPrevSec);
            this.grpPrevisione.Controls.Add(this.gboxRipartizione);
            this.grpPrevisione.Controls.Add(this.groupBox7);
            this.grpPrevisione.Location = new System.Drawing.Point(8, 8);
            this.grpPrevisione.Name = "grpPrevisione";
            this.grpPrevisione.Size = new System.Drawing.Size(528, 256);
            this.grpPrevisione.TabIndex = 5;
            this.grpPrevisione.TabStop = false;
            this.grpPrevisione.Text = "Bilancio di Previsione";
            // 
            // gboxPrimaPrevisione
            // 
            this.gboxPrimaPrevisione.Controls.Add(this.txtPrevisionePrincipalePrecUpb);
            this.gboxPrimaPrevisione.Controls.Add(this.txtPrevisionePrincipaleCorrUpb);
            this.gboxPrimaPrevisione.Controls.Add(this.lblEsCorrentePrima);
            this.gboxPrimaPrevisione.Controls.Add(this.lblEsPrecPrima);
            this.gboxPrimaPrevisione.Location = new System.Drawing.Point(8, 16);
            this.gboxPrimaPrevisione.Name = "gboxPrimaPrevisione";
            this.gboxPrimaPrevisione.Size = new System.Drawing.Size(512, 48);
            this.gboxPrimaPrevisione.TabIndex = 15;
            this.gboxPrimaPrevisione.TabStop = false;
            this.gboxPrimaPrevisione.Text = "Previsione Principale";
            // 
            // lblEsCorrentePrima
            // 
            this.lblEsCorrentePrima.Location = new System.Drawing.Point(8, 24);
            this.lblEsCorrentePrima.Name = "lblEsCorrentePrima";
            this.lblEsCorrentePrima.Size = new System.Drawing.Size(100, 16);
            this.lblEsCorrentePrima.TabIndex = 5;
            this.lblEsCorrentePrima.Text = "Prev. Corr.";
            this.lblEsCorrentePrima.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gboxRipartizione
            // 
            this.gboxRipartizione.Controls.Add(this.txtResiduiPrecUpb);
            this.gboxRipartizione.Controls.Add(this.txtResiduiCorrUpb);
            this.gboxRipartizione.Controls.Add(this.lblRipCorrente);
            this.gboxRipartizione.Controls.Add(this.lblRipPrecedente);
            this.gboxRipartizione.Location = new System.Drawing.Point(8, 112);
            this.gboxRipartizione.Name = "gboxRipartizione";
            this.gboxRipartizione.Size = new System.Drawing.Size(512, 48);
            this.gboxRipartizione.TabIndex = 17;
            this.gboxRipartizione.TabStop = false;
            this.gboxRipartizione.Text = "Residui anno precedente";
            // 
            // txtResiduiPrecUpb
            // 
            this.txtResiduiPrecUpb.Location = new System.Drawing.Point(400, 22);
            this.txtResiduiPrecUpb.Name = "txtResiduiPrecUpb";
            this.txtResiduiPrecUpb.Size = new System.Drawing.Size(100, 20);
            this.txtResiduiPrecUpb.TabIndex = 12;
            this.txtResiduiPrecUpb.Tag = "finyearview.previousarrears";
            // 
            // txtResiduiCorrUpb
            // 
            this.txtResiduiCorrUpb.Location = new System.Drawing.Point(120, 22);
            this.txtResiduiCorrUpb.Name = "txtResiduiCorrUpb";
            this.txtResiduiCorrUpb.Size = new System.Drawing.Size(100, 20);
            this.txtResiduiCorrUpb.TabIndex = 11;
            this.txtResiduiCorrUpb.Tag = "finyearview.currentarrears";
            // 
            // lblRipCorrente
            // 
            this.lblRipCorrente.Location = new System.Drawing.Point(8, 24);
            this.lblRipCorrente.Name = "lblRipCorrente";
            this.lblRipCorrente.Size = new System.Drawing.Size(100, 16);
            this.lblRipCorrente.TabIndex = 9;
            this.lblRipCorrente.Text = "Presunti del 2005";
            this.lblRipCorrente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRipPrecedente
            // 
            this.lblRipPrecedente.Location = new System.Drawing.Point(288, 24);
            this.lblRipPrecedente.Name = "lblRipPrecedente";
            this.lblRipPrecedente.Size = new System.Drawing.Size(100, 16);
            this.lblRipPrecedente.TabIndex = 10;
            this.lblRipPrecedente.Text = "Presunti del 2004";
            this.lblRipPrecedente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtPrevisione5Upb);
            this.groupBox7.Controls.Add(this.txtPrevisione4Upb);
            this.groupBox7.Controls.Add(this.txtPrevisione3Upb);
            this.groupBox7.Controls.Add(this.txtPrevisione2Upb);
            this.groupBox7.Controls.Add(this.lblPrevisione5);
            this.groupBox7.Controls.Add(this.lblPrevisione4);
            this.groupBox7.Controls.Add(this.lblPrevisione2);
            this.groupBox7.Controls.Add(this.lblPrevisione3);
            this.groupBox7.Location = new System.Drawing.Point(8, 160);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(512, 88);
            this.groupBox7.TabIndex = 18;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Previsione esercizi futuri";
            // 
            // txtPrevisione5Upb
            // 
            this.txtPrevisione5Upb.Location = new System.Drawing.Point(400, 58);
            this.txtPrevisione5Upb.Name = "txtPrevisione5Upb";
            this.txtPrevisione5Upb.Size = new System.Drawing.Size(100, 20);
            this.txtPrevisione5Upb.TabIndex = 18;
            this.txtPrevisione5Upb.Tag = "finyearview.prevision5";
            // 
            // txtPrevisione4Upb
            // 
            this.txtPrevisione4Upb.Location = new System.Drawing.Point(120, 56);
            this.txtPrevisione4Upb.Name = "txtPrevisione4Upb";
            this.txtPrevisione4Upb.Size = new System.Drawing.Size(100, 20);
            this.txtPrevisione4Upb.TabIndex = 17;
            this.txtPrevisione4Upb.Tag = "finyearview.prevision4";
            // 
            // txtPrevisione3Upb
            // 
            this.txtPrevisione3Upb.Location = new System.Drawing.Point(400, 16);
            this.txtPrevisione3Upb.Name = "txtPrevisione3Upb";
            this.txtPrevisione3Upb.Size = new System.Drawing.Size(100, 20);
            this.txtPrevisione3Upb.TabIndex = 16;
            this.txtPrevisione3Upb.Tag = "finyearview.prevision3";
            // 
            // txtPrevisione2Upb
            // 
            this.txtPrevisione2Upb.Location = new System.Drawing.Point(120, 22);
            this.txtPrevisione2Upb.Name = "txtPrevisione2Upb";
            this.txtPrevisione2Upb.Size = new System.Drawing.Size(100, 20);
            this.txtPrevisione2Upb.TabIndex = 15;
            this.txtPrevisione2Upb.Tag = "finyearview.prevision2";
            // 
            // lblPrevisione5
            // 
            this.lblPrevisione5.Location = new System.Drawing.Point(288, 64);
            this.lblPrevisione5.Name = "lblPrevisione5";
            this.lblPrevisione5.Size = new System.Drawing.Size(100, 16);
            this.lblPrevisione5.TabIndex = 14;
            this.lblPrevisione5.Text = "n+4";
            this.lblPrevisione5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPrevisione4
            // 
            this.lblPrevisione4.Location = new System.Drawing.Point(8, 56);
            this.lblPrevisione4.Name = "lblPrevisione4";
            this.lblPrevisione4.Size = new System.Drawing.Size(100, 16);
            this.lblPrevisione4.TabIndex = 13;
            this.lblPrevisione4.Text = "n+3";
            this.lblPrevisione4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPrevisione2
            // 
            this.lblPrevisione2.Location = new System.Drawing.Point(8, 24);
            this.lblPrevisione2.Name = "lblPrevisione2";
            this.lblPrevisione2.Size = new System.Drawing.Size(100, 16);
            this.lblPrevisione2.TabIndex = 11;
            this.lblPrevisione2.Text = "n+1";
            this.lblPrevisione2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPrevisione3
            // 
            this.lblPrevisione3.Location = new System.Drawing.Point(288, 24);
            this.lblPrevisione3.Name = "lblPrevisione3";
            this.lblPrevisione3.Size = new System.Drawing.Size(100, 16);
            this.lblPrevisione3.TabIndex = 12;
            this.lblPrevisione3.Text = "n+2";
            this.lblPrevisione3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // gboxBilAnnuale
            // 
            this.gboxBilAnnuale.Controls.Add(this.btnBilancio);
            this.gboxBilAnnuale.Controls.Add(this.txtCodiceBilancio);
            this.gboxBilAnnuale.Controls.Add(this.txtDenominazioneBilancio);
            this.gboxBilAnnuale.Controls.Add(this.rdbEntrata);
            this.gboxBilAnnuale.Controls.Add(this.rdbSpesa);
            this.gboxBilAnnuale.Location = new System.Drawing.Point(4, 3);
            this.gboxBilAnnuale.Name = "gboxBilAnnuale";
            this.gboxBilAnnuale.Size = new System.Drawing.Size(374, 82);
            this.gboxBilAnnuale.TabIndex = 19;
            this.gboxBilAnnuale.TabStop = false;
            this.gboxBilAnnuale.Tag = "";
            // 
            // btnBilancio
            // 
            this.btnBilancio.BackColor = System.Drawing.SystemColors.Control;
            this.btnBilancio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBilancio.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBilancio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilancio.ImageIndex = 0;
            this.btnBilancio.ImageList = this.imageList1;
            this.btnBilancio.Location = new System.Drawing.Point(78, 19);
            this.btnBilancio.Name = "btnBilancio";
            this.btnBilancio.Size = new System.Drawing.Size(112, 20);
            this.btnBilancio.TabIndex = 1;
            this.btnBilancio.TabStop = false;
            this.btnBilancio.Tag = "";
            this.btnBilancio.Text = "Bilancio";
            this.btnBilancio.UseVisualStyleBackColor = false;
            this.btnBilancio.Click += new System.EventHandler(this.btnBilancio_Click);
            // 
            // txtCodiceBilancio
            // 
            this.txtCodiceBilancio.Location = new System.Drawing.Point(78, 44);
            this.txtCodiceBilancio.Name = "txtCodiceBilancio";
            this.txtCodiceBilancio.Size = new System.Drawing.Size(112, 20);
            this.txtCodiceBilancio.TabIndex = 5;
            this.txtCodiceBilancio.Tag = "finview.codefin?x";
            this.txtCodiceBilancio.Leave += new System.EventHandler(this.txtCodiceBilancio_Leave);
            // 
            // txtDenominazioneBilancio
            // 
            this.txtDenominazioneBilancio.Location = new System.Drawing.Point(202, 20);
            this.txtDenominazioneBilancio.Multiline = true;
            this.txtDenominazioneBilancio.Name = "txtDenominazioneBilancio";
            this.txtDenominazioneBilancio.ReadOnly = true;
            this.txtDenominazioneBilancio.Size = new System.Drawing.Size(160, 42);
            this.txtDenominazioneBilancio.TabIndex = 3;
            this.txtDenominazioneBilancio.TabStop = false;
            this.txtDenominazioneBilancio.Tag = "finview.title";
            // 
            // rdbEntrata
            // 
            this.rdbEntrata.Location = new System.Drawing.Point(8, 16);
            this.rdbEntrata.Name = "rdbEntrata";
            this.rdbEntrata.Size = new System.Drawing.Size(64, 16);
            this.rdbEntrata.TabIndex = 2;
            this.rdbEntrata.Tag = "finview.finpart:E?x";
            this.rdbEntrata.Text = "Entrata";
            // 
            // rdbSpesa
            // 
            this.rdbSpesa.Checked = true;
            this.rdbSpesa.Location = new System.Drawing.Point(8, 45);
            this.rdbSpesa.Name = "rdbSpesa";
            this.rdbSpesa.Size = new System.Drawing.Size(64, 16);
            this.rdbSpesa.TabIndex = 3;
            this.rdbSpesa.TabStop = true;
            this.rdbSpesa.Tag = "finview.finpart:S?x";
            this.rdbSpesa.Text = "Spesa";
            // 
            // Frm_finyearview_previsionfin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 451);
            this.Controls.Add(this.gboxBilAnnuale);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.MetaDataDetail);
            this.Name = "Frm_finyearview_previsionfin";
            this.Text = "Frm_finyearview_previsionfin";
            this.grpPrevSec.ResumeLayout(false);
            this.grpPrevSec.PerformLayout();
            this.MetaDataDetail.ResumeLayout(false);
            this.tabPrincipale.ResumeLayout(false);
            this.grpPrevisione.ResumeLayout(false);
            this.gboxPrimaPrevisione.ResumeLayout(false);
            this.gboxPrimaPrevisione.PerformLayout();
            this.gboxRipartizione.ResumeLayout(false);
            this.gboxRipartizione.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.gboxBilAnnuale.ResumeLayout(false);
            this.gboxBilAnnuale.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public vistaForm DS;
        
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.TextBox txtPrevisionePrincipalePrecUpb;
        private System.Windows.Forms.TextBox txtPrevisioneSecondariaPrecUpb;
        private System.Windows.Forms.TextBox txtPrevisionePrincipaleCorrUpb;
        private System.Windows.Forms.TextBox txtPrevisioneSecondariaCorrUpb;
        private System.Windows.Forms.GroupBox grpPrevSec;
        private System.Windows.Forms.Label lblEsCorrSeconda;
        private System.Windows.Forms.Label lblEsPrecSeconda;
        private System.Windows.Forms.Label lblEsPrecPrima;
        public System.Windows.Forms.TabControl MetaDataDetail;
        private System.Windows.Forms.TabPage tabPrincipale;
        private System.Windows.Forms.GroupBox grpPrevisione;
        private System.Windows.Forms.GroupBox gboxPrimaPrevisione;
        private System.Windows.Forms.Label lblEsCorrentePrima;
        private System.Windows.Forms.GroupBox gboxRipartizione;
        private System.Windows.Forms.TextBox txtResiduiPrecUpb;
        private System.Windows.Forms.TextBox txtResiduiCorrUpb;
        private System.Windows.Forms.Label lblRipCorrente;
        private System.Windows.Forms.Label lblRipPrecedente;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txtPrevisione5Upb;
        private System.Windows.Forms.TextBox txtPrevisione4Upb;
        private System.Windows.Forms.TextBox txtPrevisione3Upb;
        private System.Windows.Forms.TextBox txtPrevisione2Upb;
        private System.Windows.Forms.Label lblPrevisione5;
        private System.Windows.Forms.Label lblPrevisione4;
        private System.Windows.Forms.Label lblPrevisione2;
        private System.Windows.Forms.Label lblPrevisione3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox gboxBilAnnuale;
        private System.Windows.Forms.Button btnBilancio;
        private System.Windows.Forms.TextBox txtCodiceBilancio;
        private System.Windows.Forms.TextBox txtDenominazioneBilancio;
        public System.Windows.Forms.RadioButton rdbEntrata;
        public System.Windows.Forms.RadioButton rdbSpesa;
    }
}
