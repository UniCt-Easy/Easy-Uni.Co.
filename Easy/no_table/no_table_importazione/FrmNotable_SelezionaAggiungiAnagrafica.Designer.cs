
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


namespace notable_importazione
{
    partial class FrmNotable_SelezionaAggiungiAnagrafica
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
            this.btnSeleziona = new System.Windows.Forms.Button();
            this.btnCrea = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.txtCognome = new System.Windows.Forms.TextBox();
            this.txtDenominazione = new System.Windows.Forms.TextBox();
            this.txtPIva = new System.Windows.Forms.TextBox();
            this.txtCFExt = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtCF = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.rdbM = new System.Windows.Forms.RadioButton();
            this.rdbF = new System.Windows.Forms.RadioButton();
            this.lblCognome = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblDenominazione = new System.Windows.Forms.Label();
            this.lblSesso = new System.Windows.Forms.Label();
            this.lblPIva = new System.Windows.Forms.Label();
            this.lblCF = new System.Windows.Forms.Label();
            this.lblCFExt = new System.Windows.Forms.Label();
            this.txtLocalita = new System.Windows.Forms.TextBox();
            this.txtDataNascita = new System.Windows.Forms.TextBox();
            this.lblDataNascita = new System.Windows.Forms.Label();
            this.lblLocalitaNascita = new System.Windows.Forms.Label();
            this.lblGridAction = new System.Windows.Forms.Label();
            this.DetailGrid = new System.Windows.Forms.DataGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.DetailGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSeleziona
            // 
            this.btnSeleziona.Location = new System.Drawing.Point(22, 543);
            this.btnSeleziona.Name = "btnSeleziona";
            this.btnSeleziona.Size = new System.Drawing.Size(81, 23);
            this.btnSeleziona.TabIndex = 0;
            this.btnSeleziona.Text = "Seleziona";
            this.btnSeleziona.UseVisualStyleBackColor = true;
            this.btnSeleziona.Click += new System.EventHandler(this.btnSeleziona_Click);
            // 
            // btnCrea
            // 
            this.btnCrea.Location = new System.Drawing.Point(109, 543);
            this.btnCrea.Name = "btnCrea";
            this.btnCrea.Size = new System.Drawing.Size(69, 23);
            this.btnCrea.TabIndex = 1;
            this.btnCrea.Text = "Crea";
            this.btnCrea.UseVisualStyleBackColor = true;
            this.btnCrea.Click += new System.EventHandler(this.btnCrea_Click);
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Location = new System.Drawing.Point(601, 543);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(79, 23);
            this.btnAnnulla.TabIndex = 2;
            this.btnAnnulla.Text = "Annulla";
            this.btnAnnulla.UseVisualStyleBackColor = true;
            this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
            // 
            // txtCognome
            // 
            this.txtCognome.Location = new System.Drawing.Point(147, 86);
            this.txtCognome.Name = "txtCognome";
            this.txtCognome.Size = new System.Drawing.Size(191, 20);
            this.txtCognome.TabIndex = 4;
            // 
            // txtDenominazione
            // 
            this.txtDenominazione.Location = new System.Drawing.Point(147, 112);
            this.txtDenominazione.Name = "txtDenominazione";
            this.txtDenominazione.Size = new System.Drawing.Size(191, 20);
            this.txtDenominazione.TabIndex = 5;
            // 
            // txtPIva
            // 
            this.txtPIva.Location = new System.Drawing.Point(147, 138);
            this.txtPIva.Name = "txtPIva";
            this.txtPIva.Size = new System.Drawing.Size(115, 20);
            this.txtPIva.TabIndex = 6;
            // 
            // txtCFExt
            // 
            this.txtCFExt.Location = new System.Drawing.Point(147, 164);
            this.txtCFExt.Name = "txtCFExt";
            this.txtCFExt.Size = new System.Drawing.Size(115, 20);
            this.txtCFExt.TabIndex = 7;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(463, 86);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(195, 20);
            this.txtNome.TabIndex = 8;
            // 
            // txtCF
            // 
            this.txtCF.Location = new System.Drawing.Point(463, 138);
            this.txtCF.Name = "txtCF";
            this.txtCF.Size = new System.Drawing.Size(109, 20);
            this.txtCF.TabIndex = 9;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(66, 15);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 13);
            this.lblMessage.TabIndex = 10;
            // 
            // rdbM
            // 
            this.rdbM.AutoSize = true;
            this.rdbM.Location = new System.Drawing.Point(463, 112);
            this.rdbM.Name = "rdbM";
            this.rdbM.Size = new System.Drawing.Size(34, 17);
            this.rdbM.TabIndex = 11;
            this.rdbM.TabStop = true;
            this.rdbM.Text = "M";
            this.rdbM.UseVisualStyleBackColor = true;
            // 
            // rdbF
            // 
            this.rdbF.AutoSize = true;
            this.rdbF.Location = new System.Drawing.Point(503, 112);
            this.rdbF.Name = "rdbF";
            this.rdbF.Size = new System.Drawing.Size(31, 17);
            this.rdbF.TabIndex = 12;
            this.rdbF.TabStop = true;
            this.rdbF.Text = "F";
            this.rdbF.UseVisualStyleBackColor = true;
            // 
            // lblCognome
            // 
            this.lblCognome.AutoSize = true;
            this.lblCognome.Location = new System.Drawing.Point(89, 86);
            this.lblCognome.Name = "lblCognome";
            this.lblCognome.Size = new System.Drawing.Size(52, 13);
            this.lblCognome.TabIndex = 13;
            this.lblCognome.Text = "Cognome";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(422, 86);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(35, 13);
            this.lblNome.TabIndex = 14;
            this.lblNome.Text = "Nome";
            // 
            // lblDenominazione
            // 
            this.lblDenominazione.AutoSize = true;
            this.lblDenominazione.Location = new System.Drawing.Point(61, 114);
            this.lblDenominazione.Name = "lblDenominazione";
            this.lblDenominazione.Size = new System.Drawing.Size(80, 13);
            this.lblDenominazione.TabIndex = 15;
            this.lblDenominazione.Text = "Denominazione";
            // 
            // lblSesso
            // 
            this.lblSesso.AutoSize = true;
            this.lblSesso.Location = new System.Drawing.Point(422, 112);
            this.lblSesso.Name = "lblSesso";
            this.lblSesso.Size = new System.Drawing.Size(36, 13);
            this.lblSesso.TabIndex = 16;
            this.lblSesso.Text = "Sesso";
            // 
            // lblPIva
            // 
            this.lblPIva.AutoSize = true;
            this.lblPIva.Location = new System.Drawing.Point(84, 138);
            this.lblPIva.Name = "lblPIva";
            this.lblPIva.Size = new System.Drawing.Size(57, 13);
            this.lblPIva.TabIndex = 17;
            this.lblPIva.Text = "Partita IVA";
            // 
            // lblCF
            // 
            this.lblCF.AutoSize = true;
            this.lblCF.Location = new System.Drawing.Point(382, 141);
            this.lblCF.Name = "lblCF";
            this.lblCF.Size = new System.Drawing.Size(76, 13);
            this.lblCF.TabIndex = 18;
            this.lblCF.Text = "Codice Fiscale";
            // 
            // lblCFExt
            // 
            this.lblCFExt.AutoSize = true;
            this.lblCFExt.Location = new System.Drawing.Point(32, 167);
            this.lblCFExt.Name = "lblCFExt";
            this.lblCFExt.Size = new System.Drawing.Size(109, 13);
            this.lblCFExt.TabIndex = 19;
            this.lblCFExt.Text = "Codice Fiscale Estero";
            // 
            // txtLocalita
            // 
            this.txtLocalita.Location = new System.Drawing.Point(147, 190);
            this.txtLocalita.Name = "txtLocalita";
            this.txtLocalita.Size = new System.Drawing.Size(115, 20);
            this.txtLocalita.TabIndex = 20;
            // 
            // txtDataNascita
            // 
            this.txtDataNascita.Location = new System.Drawing.Point(463, 167);
            this.txtDataNascita.Name = "txtDataNascita";
            this.txtDataNascita.Size = new System.Drawing.Size(109, 20);
            this.txtDataNascita.TabIndex = 21;
            // 
            // lblDataNascita
            // 
            this.lblDataNascita.AutoSize = true;
            this.lblDataNascita.Location = new System.Drawing.Point(376, 167);
            this.lblDataNascita.Name = "lblDataNascita";
            this.lblDataNascita.Size = new System.Drawing.Size(82, 13);
            this.lblDataNascita.TabIndex = 22;
            this.lblDataNascita.Text = "Data Di Nascita";
            // 
            // lblLocalitaNascita
            // 
            this.lblLocalitaNascita.AutoSize = true;
            this.lblLocalitaNascita.Location = new System.Drawing.Point(47, 193);
            this.lblLocalitaNascita.Name = "lblLocalitaNascita";
            this.lblLocalitaNascita.Size = new System.Drawing.Size(94, 13);
            this.lblLocalitaNascita.TabIndex = 23;
            this.lblLocalitaNascita.Text = "Località di Nascita";
            // 
            // lblGridAction
            // 
            this.lblGridAction.AutoSize = true;
            this.lblGridAction.Location = new System.Drawing.Point(32, 217);
            this.lblGridAction.Name = "lblGridAction";
            this.lblGridAction.Size = new System.Drawing.Size(0, 13);
            this.lblGridAction.TabIndex = 24;
            // 
            // DetailGrid
            // 
            this.DetailGrid.AllowNavigation = false;
            this.DetailGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DetailGrid.DataMember = "";
            this.DetailGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.DetailGrid.Location = new System.Drawing.Point(9, 10);
            this.DetailGrid.Name = "DetailGrid";
            this.DetailGrid.ReadOnly = true;
            this.DetailGrid.Size = new System.Drawing.Size(658, 270);
            this.DetailGrid.TabIndex = 67;
            this.DetailGrid.Tag = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DetailGrid);
            this.groupBox1.Location = new System.Drawing.Point(13, 244);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(676, 288);
            this.groupBox1.TabIndex = 68;
            this.groupBox1.TabStop = false;
            // 
            // FrmNotable_SelezionaAggiungiAnagrafica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 577);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblGridAction);
            this.Controls.Add(this.lblLocalitaNascita);
            this.Controls.Add(this.lblDataNascita);
            this.Controls.Add(this.txtDataNascita);
            this.Controls.Add(this.txtLocalita);
            this.Controls.Add(this.lblCFExt);
            this.Controls.Add(this.lblCF);
            this.Controls.Add(this.lblPIva);
            this.Controls.Add(this.lblSesso);
            this.Controls.Add(this.lblDenominazione);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblCognome);
            this.Controls.Add(this.rdbF);
            this.Controls.Add(this.rdbM);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.txtCF);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtCFExt);
            this.Controls.Add(this.txtPIva);
            this.Controls.Add(this.txtDenominazione);
            this.Controls.Add(this.txtCognome);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnCrea);
            this.Controls.Add(this.btnSeleziona);
            this.Name = "FrmNotable_SelezionaAggiungiAnagrafica";
            this.Text = "Gestione Collisioni Anagrafiche";
            ((System.ComponentModel.ISupportInitialize)(this.DetailGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSeleziona;
        private System.Windows.Forms.Button btnCrea;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.TextBox txtCognome;
        private System.Windows.Forms.TextBox txtDenominazione;
        private System.Windows.Forms.TextBox txtPIva;
        private System.Windows.Forms.TextBox txtCFExt;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtCF;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.RadioButton rdbM;
        private System.Windows.Forms.RadioButton rdbF;
        private System.Windows.Forms.Label lblCognome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblDenominazione;
        private System.Windows.Forms.Label lblSesso;
        private System.Windows.Forms.Label lblPIva;
        private System.Windows.Forms.Label lblCF;
        private System.Windows.Forms.Label lblCFExt;
        private System.Windows.Forms.TextBox txtLocalita;
        private System.Windows.Forms.TextBox txtDataNascita;
        private System.Windows.Forms.Label lblDataNascita;
        private System.Windows.Forms.Label lblLocalitaNascita;
        private System.Windows.Forms.Label lblGridAction;
        private System.Windows.Forms.DataGrid DetailGrid;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
