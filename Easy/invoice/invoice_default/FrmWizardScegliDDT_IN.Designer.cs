/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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

namespace invoice_default {
    partial class FrmWizardScegliDDT_IN {
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
            this.tabController = new Crownwood.Magic.Controls.TabControl();
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.lblselezautomaticamente = new System.Windows.Forms.Label();
            this.btnSelezionaTutto = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.gridDettagli = new System.Windows.Forms.DataGrid();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.labelMsg = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabController.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDettagli)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabController
            // 
            this.tabController.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabController.IDEPixelArea = true;
            this.tabController.Location = new System.Drawing.Point(8, 27);
            this.tabController.Name = "tabController";
            this.tabController.SelectedIndex = 0;
            this.tabController.SelectedTab = this.tabPage1;
            this.tabController.Size = new System.Drawing.Size(779, 485);
            this.tabController.TabIndex = 15;
            this.tabController.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2});
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblselezautomaticamente);
            this.tabPage1.Controls.Add(this.btnSelezionaTutto);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.gridDettagli);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(779, 460);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Title = "Pagina 1 di 2";
            // 
            // lblselezautomaticamente
            // 
            this.lblselezautomaticamente.Location = new System.Drawing.Point(8, 40);
            this.lblselezautomaticamente.Name = "lblselezautomaticamente";
            this.lblselezautomaticamente.Size = new System.Drawing.Size(568, 16);
            this.lblselezautomaticamente.TabIndex = 31;
            this.lblselezautomaticamente.Text = "NB: Saranno selezionati automaticamente tutti i dettagli magazzino non associati " +
                "ad alcuna fattura.";
            // 
            // btnSelezionaTutto
            // 
            this.btnSelezionaTutto.Location = new System.Drawing.Point(8, 8);
            this.btnSelezionaTutto.Name = "btnSelezionaTutto";
            this.btnSelezionaTutto.Size = new System.Drawing.Size(88, 23);
            this.btnSelezionaTutto.TabIndex = 30;
            this.btnSelezionaTutto.Text = "Seleziona tutto";
            this.btnSelezionaTutto.Click += new System.EventHandler(this.btnSelezionaTutto_Click);
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(112, 8);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(663, 32);
            this.label16.TabIndex = 29;
            this.label16.Text = "Tenere premuto il tasto CTRL o MAIUSC e contemporaneamente cliccare con il mouse " +
                "per selezionare pi˘ bollette da inserire in fattura";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(8, 56);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(192, 16);
            this.label14.TabIndex = 28;
            this.label14.Text = "Bollette da associare alla fattura";
            // 
            // gridDettagli
            // 
            this.gridDettagli.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDettagli.CaptionVisible = false;
            this.gridDettagli.DataMember = "";
            this.gridDettagli.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridDettagli.Location = new System.Drawing.Point(8, 75);
            this.gridDettagli.Name = "gridDettagli";
            this.gridDettagli.Size = new System.Drawing.Size(763, 370);
            this.gridDettagli.TabIndex = 27;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.labelMsg);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(779, 460);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Title = "Pagina 2 di 2";
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
            this.btnNext.Location = new System.Drawing.Point(604, 531);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(72, 23);
            this.btnNext.TabIndex = 17;
            this.btnNext.Text = "Avanti >";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(524, 531);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(72, 23);
            this.btnBack.TabIndex = 16;
            this.btnBack.Text = "< Indietro";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(708, 531);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Cancel";
            // 
            // FrmWizardScegliDDT_IN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 566);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tabController);
            this.Name = "FrmWizardScegliDDT_IN";
            this.Text = "FrmWizardScegliDDT_IN";
            this.tabController.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDettagli)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Crownwood.Magic.Controls.TabControl tabController;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private System.Windows.Forms.Label lblselezautomaticamente;
        private System.Windows.Forms.Button btnSelezionaTutto;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGrid gridDettagli;
        private Crownwood.Magic.Controls.TabPage tabPage2;
        private System.Windows.Forms.Label labelMsg;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnCancel;
    }
}