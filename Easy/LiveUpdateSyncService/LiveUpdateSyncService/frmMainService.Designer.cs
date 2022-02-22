
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


namespace LiveUpdateSyncService {
    partial class frmMainService {
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
            this.chkDirectory = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDirBrowse = new System.Windows.Forms.Button();
            this.chkLocale = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPwdMaster = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUserMaster = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.grpMaster = new System.Windows.Forms.GroupBox();
            this.chkPasV = new System.Windows.Forms.CheckBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtIndirizzo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSalva = new System.Windows.Forms.Button();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCancelMaster = new System.Windows.Forms.Button();
            this.btnDeleteMaster = new System.Windows.Forms.Button();
            this.btnInsertMaster = new System.Windows.Forms.Button();
            this.txtProgressivo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gridMaster = new System.Windows.Forms.DataGrid();
            this.btnChiudi = new System.Windows.Forms.Button();
            this.btnSync = new System.Windows.Forms.Button();
            this.DS = new LiveUpdateSyncService.vistaform();
            this.groupBox1.SuspendLayout();
            this.grpMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // chkDirectory
            // 
            this.chkDirectory.Location = new System.Drawing.Point(376, 452);
            this.chkDirectory.Name = "chkDirectory";
            this.chkDirectory.Size = new System.Drawing.Size(176, 24);
            this.chkDirectory.TabIndex = 15;
            this.chkDirectory.Text = "Controlla Struttura Directory";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnDirBrowse);
            this.groupBox1.Controls.Add(this.chkLocale);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPwdMaster);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtUserMaster);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtSource);
            this.groupBox1.Location = new System.Drawing.Point(32, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(520, 80);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sito (remoto o locale) da replicare";
            // 
            // btnDirBrowse
            // 
            this.btnDirBrowse.Location = new System.Drawing.Point(488, 23);
            this.btnDirBrowse.Name = "btnDirBrowse";
            this.btnDirBrowse.Size = new System.Drawing.Size(24, 23);
            this.btnDirBrowse.TabIndex = 37;
            this.btnDirBrowse.Text = "...";
            this.btnDirBrowse.Click += new System.EventHandler(this.btnDirBrowse_Click);
            // 
            // chkLocale
            // 
            this.chkLocale.Checked = true;
            this.chkLocale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLocale.Enabled = false;
            this.chkLocale.Location = new System.Drawing.Point(416, 50);
            this.chkLocale.Name = "chkLocale";
            this.chkLocale.Size = new System.Drawing.Size(64, 16);
            this.chkLocale.TabIndex = 36;
            this.chkLocale.Text = "Locale";
            this.chkLocale.CheckedChanged += new System.EventHandler(this.chkLocale_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 35;
            this.label1.Text = "Indirizzo";
            // 
            // txtPwdMaster
            // 
            this.txtPwdMaster.Enabled = false;
            this.txtPwdMaster.Location = new System.Drawing.Point(256, 48);
            this.txtPwdMaster.Name = "txtPwdMaster";
            this.txtPwdMaster.PasswordChar = '*';
            this.txtPwdMaster.Size = new System.Drawing.Size(104, 20);
            this.txtPwdMaster.TabIndex = 34;
            this.txtPwdMaster.TextChanged += new System.EventHandler(this.txtPwdMaster_TextChanged);
            // 
            // label6
            // 
            this.label6.Enabled = false;
            this.label6.Location = new System.Drawing.Point(192, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 33;
            this.label6.Text = "Password";
            // 
            // txtUserMaster
            // 
            this.txtUserMaster.Enabled = false;
            this.txtUserMaster.Location = new System.Drawing.Point(72, 48);
            this.txtUserMaster.Name = "txtUserMaster";
            this.txtUserMaster.Size = new System.Drawing.Size(112, 20);
            this.txtUserMaster.TabIndex = 32;
            this.txtUserMaster.TextChanged += new System.EventHandler(this.txtUserMaster_TextChanged);
            // 
            // label3
            // 
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(16, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 31;
            this.label3.Text = "Utente";
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(72, 24);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(416, 20);
            this.txtSource.TabIndex = 3;
            this.txtSource.TextChanged += new System.EventHandler(this.txtSource_TextChanged);
            // 
            // grpMaster
            // 
            this.grpMaster.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMaster.Controls.Add(this.chkPasV);
            this.grpMaster.Controls.Add(this.txtPort);
            this.grpMaster.Controls.Add(this.label4);
            this.grpMaster.Controls.Add(this.txtPwd);
            this.grpMaster.Controls.Add(this.label7);
            this.grpMaster.Controls.Add(this.txtUser);
            this.grpMaster.Controls.Add(this.label8);
            this.grpMaster.Controls.Add(this.txtIndirizzo);
            this.grpMaster.Controls.Add(this.label2);
            this.grpMaster.Controls.Add(this.btnSalva);
            this.grpMaster.Controls.Add(this.txtDescrizione);
            this.grpMaster.Controls.Add(this.label9);
            this.grpMaster.Controls.Add(this.btnCancelMaster);
            this.grpMaster.Controls.Add(this.btnDeleteMaster);
            this.grpMaster.Controls.Add(this.btnInsertMaster);
            this.grpMaster.Controls.Add(this.txtProgressivo);
            this.grpMaster.Controls.Add(this.label5);
            this.grpMaster.Controls.Add(this.gridMaster);
            this.grpMaster.Location = new System.Drawing.Point(32, 104);
            this.grpMaster.Name = "grpMaster";
            this.grpMaster.Size = new System.Drawing.Size(520, 342);
            this.grpMaster.TabIndex = 9;
            this.grpMaster.TabStop = false;
            this.grpMaster.Text = "Siti da sincronizzare";
            // 
            // chkPasV
            // 
            this.chkPasV.AutoSize = true;
            this.chkPasV.Location = new System.Drawing.Point(416, 300);
            this.chkPasV.Name = "chkPasV";
            this.chkPasV.Size = new System.Drawing.Size(83, 17);
            this.chkPasV.TabIndex = 40;
            this.chkPasV.Text = "PASV mode";
            this.chkPasV.UseVisualStyleBackColor = true;
            this.chkPasV.CheckStateChanged += new System.EventHandler(this.chkPasV_CheckStateChanged);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(432, 264);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(64, 20);
            this.txtPort.TabIndex = 10;
            this.txtPort.TextChanged += new System.EventHandler(this.txtPort_TextChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(392, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 16);
            this.label4.TabIndex = 39;
            this.label4.Text = "Port";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(248, 264);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(96, 20);
            this.txtPwd.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(184, 266);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 37;
            this.label7.Text = "Password";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(80, 264);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(100, 20);
            this.txtUser.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(16, 266);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 16);
            this.label8.TabIndex = 35;
            this.label8.Text = "Utente";
            // 
            // txtIndirizzo
            // 
            this.txtIndirizzo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIndirizzo.Location = new System.Drawing.Point(80, 216);
            this.txtIndirizzo.MaxLength = 2000;
            this.txtIndirizzo.Name = "txtIndirizzo";
            this.txtIndirizzo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtIndirizzo.Size = new System.Drawing.Size(416, 20);
            this.txtIndirizzo.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 26;
            this.label2.Text = "Indirizzo";
            // 
            // btnSalva
            // 
            this.btnSalva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalva.Location = new System.Drawing.Point(424, 161);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(75, 23);
            this.btnSalva.TabIndex = 5;
            this.btnSalva.Text = "Salva";
            this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(80, 240);
            this.txtDescrizione.MaxLength = 2000;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrizione.Size = new System.Drawing.Size(416, 20);
            this.txtDescrizione.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(16, 240);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 16);
            this.label9.TabIndex = 23;
            this.label9.Text = "Descrizione";
            // 
            // btnCancelMaster
            // 
            this.btnCancelMaster.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelMaster.Location = new System.Drawing.Point(424, 85);
            this.btnCancelMaster.Name = "btnCancelMaster";
            this.btnCancelMaster.Size = new System.Drawing.Size(75, 23);
            this.btnCancelMaster.TabIndex = 4;
            this.btnCancelMaster.Text = "Annulla";
            this.btnCancelMaster.Click += new System.EventHandler(this.btnCancelMaster_Click);
            // 
            // btnDeleteMaster
            // 
            this.btnDeleteMaster.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteMaster.Location = new System.Drawing.Point(424, 53);
            this.btnDeleteMaster.Name = "btnDeleteMaster";
            this.btnDeleteMaster.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteMaster.TabIndex = 3;
            this.btnDeleteMaster.Text = "Elimina";
            this.btnDeleteMaster.Click += new System.EventHandler(this.btnDeleteMaster_Click);
            // 
            // btnInsertMaster
            // 
            this.btnInsertMaster.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsertMaster.Location = new System.Drawing.Point(424, 24);
            this.btnInsertMaster.Name = "btnInsertMaster";
            this.btnInsertMaster.Size = new System.Drawing.Size(75, 23);
            this.btnInsertMaster.TabIndex = 1;
            this.btnInsertMaster.Text = "Inserisci";
            this.btnInsertMaster.Click += new System.EventHandler(this.btnInsertMaster_Click);
            // 
            // txtProgressivo
            // 
            this.txtProgressivo.Location = new System.Drawing.Point(80, 192);
            this.txtProgressivo.MaxLength = 10;
            this.txtProgressivo.Name = "txtProgressivo";
            this.txtProgressivo.ReadOnly = true;
            this.txtProgressivo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtProgressivo.Size = new System.Drawing.Size(96, 20);
            this.txtProgressivo.TabIndex = 20;
            this.txtProgressivo.Tag = "";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Progressivo";
            // 
            // gridMaster
            // 
            this.gridMaster.AllowNavigation = false;
            this.gridMaster.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridMaster.CaptionVisible = false;
            this.gridMaster.DataMember = "";
            this.gridMaster.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridMaster.Location = new System.Drawing.Point(19, 19);
            this.gridMaster.Name = "gridMaster";
            this.gridMaster.ReadOnly = true;
            this.gridMaster.Size = new System.Drawing.Size(384, 160);
            this.gridMaster.TabIndex = 0;
            this.gridMaster.Tag = "";
            this.gridMaster.Click += new System.EventHandler(this.gridMaster_Click);
            // 
            // btnChiudi
            // 
            this.btnChiudi.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnChiudi.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChiudi.Location = new System.Drawing.Point(345, 514);
            this.btnChiudi.Name = "btnChiudi";
            this.btnChiudi.Size = new System.Drawing.Size(87, 23);
            this.btnChiudi.TabIndex = 11;
            this.btnChiudi.Text = "Chiudi";
            this.btnChiudi.Click += new System.EventHandler(this.btnChiudi_Click);
            // 
            // btnSync
            // 
            this.btnSync.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSync.Location = new System.Drawing.Point(181, 514);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(83, 23);
            this.btnSync.TabIndex = 10;
            this.btnSync.Text = "Sincronizza";
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaform";
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // frmMainService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 554);
            this.Controls.Add(this.chkDirectory);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpMaster);
            this.Controls.Add(this.btnChiudi);
            this.Controls.Add(this.btnSync);
            this.Name = "frmMainService";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMainService";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMainService_Closing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpMaster.ResumeLayout(false);
            this.grpMaster.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private vistaform DS;
        private System.Windows.Forms.CheckBox chkDirectory;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDirBrowse;
        private System.Windows.Forms.CheckBox chkLocale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPwdMaster;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUserMaster;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.GroupBox grpMaster;
        private System.Windows.Forms.CheckBox chkPasV;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtIndirizzo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSalva;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCancelMaster;
        private System.Windows.Forms.Button btnDeleteMaster;
        private System.Windows.Forms.Button btnInsertMaster;
        private System.Windows.Forms.TextBox txtProgressivo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGrid gridMaster;
        private System.Windows.Forms.Button btnChiudi;
        private System.Windows.Forms.Button btnSync;
    }
}
