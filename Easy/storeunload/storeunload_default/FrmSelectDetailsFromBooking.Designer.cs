
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


namespace storeunload_default {
    partial class FrmSelectDetailsFromBooking {
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
            this.btnBack = new System.Windows.Forms.Button();
            this.labelMsg = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabController = new Crownwood.Magic.Controls.TabControl();
            this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbMagazzino = new System.Windows.Forms.ComboBox();
            this.grpPrenotazione = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbResponsabile = new System.Windows.Forms.ComboBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.label16 = new System.Windows.Forms.Label();
            this.gridDettagli = new System.Windows.Forms.DataGrid();
            this.tabPage2.SuspendLayout();
            this.tabController.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.grpPrenotazione.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDettagli)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(460, 526);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(72, 23);
            this.btnBack.TabIndex = 15;
            this.btnBack.Text = "< Indietro";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // labelMsg
            // 
            this.labelMsg.Location = new System.Drawing.Point(8, 8);
            this.labelMsg.Name = "labelMsg";
            this.labelMsg.Size = new System.Drawing.Size(576, 23);
            this.labelMsg.TabIndex = 0;
            this.labelMsg.Text = "label1";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(540, 526);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(72, 23);
            this.btnNext.TabIndex = 16;
            this.btnNext.Text = "Avanti >";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.labelMsg);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(709, 482);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Title = "Pagina 3 di 3";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(644, 526);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            // 
            // tabController
            // 
            this.tabController.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabController.IDEPixelArea = true;
            this.tabController.Location = new System.Drawing.Point(7, 11);
            this.tabController.Name = "tabController";
            this.tabController.SelectedIndex = 0;
            this.tabController.SelectedTab = this.tabPage3;
            this.tabController.Size = new System.Drawing.Size(709, 507);
            this.tabController.TabIndex = 18;
            this.tabController.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage3,
            this.tabPage1,
            this.tabPage2});
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.cmbMagazzino);
            this.tabPage3.Controls.Add(this.grpPrenotazione);
            this.tabPage3.Location = new System.Drawing.Point(0, 0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(709, 482);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Title = "Pagina 1 di 3";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Magazzino:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbMagazzino
            // 
            this.cmbMagazzino.DisplayMember = "description";
            this.cmbMagazzino.Location = new System.Drawing.Point(17, 29);
            this.cmbMagazzino.Name = "cmbMagazzino";
            this.cmbMagazzino.Size = new System.Drawing.Size(319, 23);
            this.cmbMagazzino.TabIndex = 2;
            this.cmbMagazzino.Tag = "";
            // 
            // grpPrenotazione
            // 
            this.grpPrenotazione.Controls.Add(this.label4);
            this.grpPrenotazione.Controls.Add(this.cmbResponsabile);
            this.grpPrenotazione.Controls.Add(this.txtNumero);
            this.grpPrenotazione.Controls.Add(this.label2);
            this.grpPrenotazione.Controls.Add(this.txtEsercizio);
            this.grpPrenotazione.Controls.Add(this.label1);
            this.grpPrenotazione.Location = new System.Drawing.Point(17, 56);
            this.grpPrenotazione.Name = "grpPrenotazione";
            this.grpPrenotazione.Size = new System.Drawing.Size(419, 96);
            this.grpPrenotazione.TabIndex = 1;
            this.grpPrenotazione.TabStop = false;
            this.grpPrenotazione.Text = "Prenotazione";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Responsabile:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbResponsabile
            // 
            this.cmbResponsabile.DisplayMember = "description";
            this.cmbResponsabile.Location = new System.Drawing.Point(89, 23);
            this.cmbResponsabile.Name = "cmbResponsabile";
            this.cmbResponsabile.Size = new System.Drawing.Size(320, 23);
            this.cmbResponsabile.TabIndex = 0;
            this.cmbResponsabile.Tag = "";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(353, 58);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(56, 23);
            this.txtNumero.TabIndex = 2;
            this.txtNumero.Tag = "";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(293, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Numero:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(227, 58);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.Size = new System.Drawing.Size(56, 23);
            this.txtEsercizio.TabIndex = 1;
            this.txtEsercizio.Tag = "";
            this.txtEsercizio.Leave += new System.EventHandler(this.txtEsercizio_Leave);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(167, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Esercizio:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.gridDettagli);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Selected = false;
            this.tabPage1.Size = new System.Drawing.Size(709, 482);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Title = "Pagina 2 di 3";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(4, 12);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(587, 18);
            this.label16.TabIndex = 29;
            this.label16.Text = "Tutti i  dettagli della prenotazione selezionata saranno aggiunti allo Scarico ma" +
    "gazzino";
            // 
            // gridDettagli
            // 
            this.gridDettagli.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDettagli.CaptionVisible = false;
            this.gridDettagli.DataMember = "";
            this.gridDettagli.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridDettagli.Location = new System.Drawing.Point(8, 33);
            this.gridDettagli.Name = "gridDettagli";
            this.gridDettagli.Size = new System.Drawing.Size(693, 434);
            this.gridDettagli.TabIndex = 27;
            // 
            // FrmSelectDetailsFromBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 560);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tabController);
            this.Name = "FrmSelectDetailsFromBooking";
            this.Text = "FrmSelectDetails";
            this.tabPage2.ResumeLayout(false);
            this.tabController.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.grpPrenotazione.ResumeLayout(false);
            this.grpPrenotazione.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDettagli)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label labelMsg;
        private System.Windows.Forms.Button btnNext;
        private Crownwood.Magic.Controls.TabPage tabPage2;
        private System.Windows.Forms.Button btnCancel;
        private Crownwood.Magic.Controls.TabControl tabController;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private System.Windows.Forms.DataGrid gridDettagli;
        private Crownwood.Magic.Controls.TabPage tabPage3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbMagazzino;
        private System.Windows.Forms.GroupBox grpPrenotazione;
        private System.Windows.Forms.ComboBox cmbResponsabile;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEsercizio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;

    }
}
