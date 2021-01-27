
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


namespace expense_wizardexpensefinvardetail {
    partial class Frm_expense_wizardexpensefinvardetail {
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
            this.tabControllerMagic = new Crownwood.Magic.Controls.TabControl();
            this.tabCreaMov = new Crownwood.Magic.Controls.TabPage();
            this.btnCrea = new System.Windows.Forms.Button();
            this.dgMovSpesa = new System.Windows.Forms.DataGrid();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPresentazione = new Crownwood.Magic.Controls.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitolo = new System.Windows.Forms.Label();
            this.btnAvanti = new System.Windows.Forms.Button();
            this.btnIndietro = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.DS = new expense_wizardexpensefinvardetail.vistaVar();
            this.DS2 = new expense_wizardexpensefinvardetail.vistaForm();
            this.tabControllerMagic.SuspendLayout();
            this.tabCreaMov.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMovSpesa)).BeginInit();
            this.tabPresentazione.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControllerMagic
            // 
            this.tabControllerMagic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControllerMagic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabControllerMagic.IDEPixelArea = true;
            this.tabControllerMagic.Location = new System.Drawing.Point(1, 8);
            this.tabControllerMagic.Name = "tabControllerMagic";
            this.tabControllerMagic.SelectedIndex = 1;
            this.tabControllerMagic.SelectedTab = this.tabCreaMov;
            this.tabControllerMagic.Size = new System.Drawing.Size(734, 513);
            this.tabControllerMagic.TabIndex = 5;
            this.tabControllerMagic.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPresentazione,
            this.tabCreaMov});
            // 
            // tabCreaMov
            // 
            this.tabCreaMov.Controls.Add(this.btnCrea);
            this.tabCreaMov.Controls.Add(this.dgMovSpesa);
            this.tabCreaMov.Controls.Add(this.label4);
            this.tabCreaMov.Location = new System.Drawing.Point(0, 0);
            this.tabCreaMov.Name = "tabCreaMov";
            this.tabCreaMov.Size = new System.Drawing.Size(734, 488);
            this.tabCreaMov.TabIndex = 4;
            this.tabCreaMov.Title = "Pagina 2 di 2";
            // 
            // btnCrea
            // 
            this.btnCrea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCrea.Location = new System.Drawing.Point(280, 458);
            this.btnCrea.Name = "btnCrea";
            this.btnCrea.Size = new System.Drawing.Size(75, 23);
            this.btnCrea.TabIndex = 4;
            this.btnCrea.Text = "Crea";
            this.btnCrea.Click += new System.EventHandler(this.btnCrea_Click);
            // 
            // dgMovSpesa
            // 
            this.dgMovSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgMovSpesa.DataMember = "";
            this.dgMovSpesa.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMovSpesa.Location = new System.Drawing.Point(8, 32);
            this.dgMovSpesa.Name = "dgMovSpesa";
            this.dgMovSpesa.Size = new System.Drawing.Size(718, 420);
            this.dgMovSpesa.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(3, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(710, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tenere premuto il tasto CTRL o MAIUSC e contemporaneamente cliccare con il mouse " +
                "per selezionare più richieste";
            // 
            // tabPresentazione
            // 
            this.tabPresentazione.Controls.Add(this.label1);
            this.tabPresentazione.Controls.Add(this.label2);
            this.tabPresentazione.Controls.Add(this.lblTitolo);
            this.tabPresentazione.Location = new System.Drawing.Point(0, 0);
            this.tabPresentazione.Name = "tabPresentazione";
            this.tabPresentazione.Selected = false;
            this.tabPresentazione.Size = new System.Drawing.Size(734, 488);
            this.tabPresentazione.TabIndex = 3;
            this.tabPresentazione.Title = "Pagina 1 di 2";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(718, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "PROCEDURA";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(8, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(718, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "DI";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitolo
            // 
            this.lblTitolo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitolo.Location = new System.Drawing.Point(8, 64);
            this.lblTitolo.Name = "lblTitolo";
            this.lblTitolo.Size = new System.Drawing.Size(718, 23);
            this.lblTitolo.TabIndex = 2;
            this.lblTitolo.Text = "CREAZIONE DELLE PRENOTAZIONI DALLE RICHIESTE DI PREVISIONE";
            this.lblTitolo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAvanti
            // 
            this.btnAvanti.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAvanti.Location = new System.Drawing.Point(289, 540);
            this.btnAvanti.Name = "btnAvanti";
            this.btnAvanti.Size = new System.Drawing.Size(75, 23);
            this.btnAvanti.TabIndex = 7;
            this.btnAvanti.Text = "Avanti >";
            this.btnAvanti.Click += new System.EventHandler(this.btnAvanti_Click);
            // 
            // btnIndietro
            // 
            this.btnIndietro.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnIndietro.Location = new System.Drawing.Point(185, 540);
            this.btnIndietro.Name = "btnIndietro";
            this.btnIndietro.Size = new System.Drawing.Size(75, 23);
            this.btnIndietro.TabIndex = 6;
            this.btnIndietro.Text = "< Indietro";
            this.btnIndietro.Click += new System.EventHandler(this.btnIndietro_Click);
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(489, 540);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 8;
            this.btnAnnulla.Text = "Annulla";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaVar";
            this.DS.EnforceConstraints = false;
            // 
            // DS2
            // 
            this.DS2.DataSetName = "vistaForm";
            this.DS2.EnforceConstraints = false;
            // 
            // Frm_expense_wizardexpensefinvardetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 575);
            this.Controls.Add(this.btnAvanti);
            this.Controls.Add(this.btnIndietro);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.tabControllerMagic);
            this.Name = "Frm_expense_wizardexpensefinvardetail";
            this.Text = "Frm_expense_wizardexpensefinvardetail";
            this.tabControllerMagic.ResumeLayout(false);
            this.tabCreaMov.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgMovSpesa)).EndInit();
            this.tabPresentazione.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Crownwood.Magic.Controls.TabControl tabControllerMagic;
        private Crownwood.Magic.Controls.TabPage tabCreaMov;
        private System.Windows.Forms.Button btnCrea;
        private System.Windows.Forms.DataGrid dgMovSpesa;
        private System.Windows.Forms.Label label4;
        private Crownwood.Magic.Controls.TabPage tabPresentazione;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTitolo;
        private System.Windows.Forms.Button btnAvanti;
        private System.Windows.Forms.Button btnIndietro;
        private System.Windows.Forms.Button btnAnnulla;
        public vistaForm DS2;
        public vistaVar DS;
    }
}
