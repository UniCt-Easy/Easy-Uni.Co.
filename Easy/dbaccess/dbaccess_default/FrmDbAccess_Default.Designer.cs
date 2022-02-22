
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


namespace dbaccess_default {
    partial class Frmdbaccess_default {
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
            this.lblLogin = new System.Windows.Forms.Label();
            this.btnApplica = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.cmbLogin = new System.Windows.Forms.ComboBox();
            this.DS = new dbaccess_default.vistaForm();
            this.txtPwdMaxAge = new System.Windows.Forms.TextBox();
            this.lblPwdMaxAge = new System.Windows.Forms.Label();
            this.txtPwdWarning = new System.Windows.Forms.TextBox();
            this.lblPwdWarning = new System.Windows.Forms.Label();
            this.chkEveryone = new System.Windows.Forms.CheckBox();
            this.lblPwdLastMod = new System.Windows.Forms.Label();
            this.txtPwdLastMod = new System.Windows.Forms.TextBox();
            this.grpUtente = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.grpUtente.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLogin
            // 
            this.lblLogin.Location = new System.Drawing.Point(23, 26);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(38, 16);
            this.lblLogin.TabIndex = 1;
            this.lblLogin.Text = "Login:";
            this.lblLogin.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnApplica
            // 
            this.btnApplica.Location = new System.Drawing.Point(79, 225);
            this.btnApplica.Name = "btnApplica";
            this.btnApplica.Size = new System.Drawing.Size(75, 23);
            this.btnApplica.TabIndex = 5;
            this.btnApplica.Text = "Applica";
            this.btnApplica.UseVisualStyleBackColor = true;
            this.btnApplica.Click += new System.EventHandler(this.btnApplica_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(15, 266);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(358, 35);
            this.textBox3.TabIndex = 6;
            this.textBox3.Text = "Le modifiche saranno operative solamente se l\'utente ha effettuato almeno un camb" +
    "io di password";
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // cmbLogin
            // 
            this.cmbLogin.DataSource = this.DS.combo_dbaccess;
            this.cmbLogin.DisplayMember = "login";
            this.cmbLogin.FormattingEnabled = true;
            this.cmbLogin.Location = new System.Drawing.Point(67, 23);
            this.cmbLogin.Name = "cmbLogin";
            this.cmbLogin.Size = new System.Drawing.Size(269, 21);
            this.cmbLogin.TabIndex = 7;
            this.cmbLogin.Tag = "dbaccess.login";
            this.cmbLogin.ValueMember = "login";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            // 
            // txtPwdMaxAge
            // 
            this.txtPwdMaxAge.Location = new System.Drawing.Point(300, 130);
            this.txtPwdMaxAge.Name = "txtPwdMaxAge";
            this.txtPwdMaxAge.Size = new System.Drawing.Size(78, 20);
            this.txtPwdMaxAge.TabIndex = 8;
            this.txtPwdMaxAge.Tag = "dbaccess.pwdmaxage";
            // 
            // lblPwdMaxAge
            // 
            this.lblPwdMaxAge.AutoSize = true;
            this.lblPwdMaxAge.Location = new System.Drawing.Point(12, 133);
            this.lblPwdMaxAge.Name = "lblPwdMaxAge";
            this.lblPwdMaxAge.Size = new System.Drawing.Size(156, 13);
            this.lblPwdMaxAge.TabIndex = 9;
            this.lblPwdMaxAge.Text = "Validità della password in giorni:";
            // 
            // txtPwdWarning
            // 
            this.txtPwdWarning.Location = new System.Drawing.Point(300, 170);
            this.txtPwdWarning.Name = "txtPwdWarning";
            this.txtPwdWarning.Size = new System.Drawing.Size(78, 20);
            this.txtPwdWarning.TabIndex = 10;
            this.txtPwdWarning.Tag = "dbaccess.pwdwarning";
            // 
            // lblPwdWarning
            // 
            this.lblPwdWarning.AutoSize = true;
            this.lblPwdWarning.Location = new System.Drawing.Point(12, 173);
            this.lblPwdWarning.Name = "lblPwdWarning";
            this.lblPwdWarning.Size = new System.Drawing.Size(229, 13);
            this.lblPwdWarning.TabIndex = 11;
            this.lblPwdWarning.Text = "Preavviso di scadenza della password in giorni:";
            // 
            // chkEveryone
            // 
            this.chkEveryone.AutoSize = true;
            this.chkEveryone.Location = new System.Drawing.Point(160, 229);
            this.chkEveryone.Name = "chkEveryone";
            this.chkEveryone.Size = new System.Drawing.Size(143, 17);
            this.chkEveryone.TabIndex = 12;
            this.chkEveryone.Text = "Imposta per tutti gli utenti";
            this.chkEveryone.UseVisualStyleBackColor = true;
            this.chkEveryone.CheckStateChanged += new System.EventHandler(this.chkEveryone_CheckStateChanged);
            // 
            // lblPwdLastMod
            // 
            this.lblPwdLastMod.AutoSize = true;
            this.lblPwdLastMod.Location = new System.Drawing.Point(23, 58);
            this.lblPwdLastMod.Name = "lblPwdLastMod";
            this.lblPwdLastMod.Size = new System.Drawing.Size(154, 13);
            this.lblPwdLastMod.TabIndex = 13;
            this.lblPwdLastMod.Text = "Ultima modifica della password:";
            // 
            // txtPwdLastMod
            // 
            this.txtPwdLastMod.Location = new System.Drawing.Point(193, 55);
            this.txtPwdLastMod.Name = "txtPwdLastMod";
            this.txtPwdLastMod.ReadOnly = true;
            this.txtPwdLastMod.Size = new System.Drawing.Size(143, 20);
            this.txtPwdLastMod.TabIndex = 14;
            this.txtPwdLastMod.Tag = "dbaccess.pwdlastmod";
            // 
            // grpUtente
            // 
            this.grpUtente.Controls.Add(this.cmbLogin);
            this.grpUtente.Controls.Add(this.txtPwdLastMod);
            this.grpUtente.Controls.Add(this.lblPwdLastMod);
            this.grpUtente.Controls.Add(this.lblLogin);
            this.grpUtente.Location = new System.Drawing.Point(12, 12);
            this.grpUtente.Name = "grpUtente";
            this.grpUtente.Size = new System.Drawing.Size(366, 92);
            this.grpUtente.TabIndex = 15;
            this.grpUtente.TabStop = false;
            this.grpUtente.Text = "Utente";
            // 
            // Frmdbaccess_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 317);
            this.Controls.Add(this.grpUtente);
            this.Controls.Add(this.chkEveryone);
            this.Controls.Add(this.lblPwdWarning);
            this.Controls.Add(this.txtPwdWarning);
            this.Controls.Add(this.lblPwdMaxAge);
            this.Controls.Add(this.txtPwdMaxAge);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.btnApplica);
            this.Name = "Frmdbaccess_default";
            this.Text = "Frmdbaccess_default";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.grpUtente.ResumeLayout(false);
            this.grpUtente.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Button btnApplica;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox cmbLogin;
        private System.Windows.Forms.TextBox txtPwdMaxAge;
        private System.Windows.Forms.Label lblPwdMaxAge;
        private System.Windows.Forms.TextBox txtPwdWarning;
        private System.Windows.Forms.Label lblPwdWarning;
        public vistaForm DS;
        private System.Windows.Forms.CheckBox chkEveryone;
        private System.Windows.Forms.Label lblPwdLastMod;
        private System.Windows.Forms.TextBox txtPwdLastMod;
        private System.Windows.Forms.GroupBox grpUtente;
    }
}
