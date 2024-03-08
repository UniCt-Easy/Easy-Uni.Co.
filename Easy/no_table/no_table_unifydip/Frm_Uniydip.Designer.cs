
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


namespace no_table_unifydip {
    partial class Frm_Uniydip {
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
            this.chkSuffix = new System.Windows.Forms.CheckBox();
            this.btnFaiTutto = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSuperUser = new System.Windows.Forms.TextBox();
            this.txtSuperPwd = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFattore = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtDestUser = new System.Windows.Forms.TextBox();
            this.txtDestPwd = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtDipDestinazione = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSourceServer = new System.Windows.Forms.TextBox();
            this.txtSourceDataBase = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSourceDip = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.txtSourceUser = new System.Windows.Forms.TextBox();
            this.txtSourcePwd = new System.Windows.Forms.TextBox();
            this.tabIntro = new Crownwood.Magic.Controls.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.labCurrTable = new System.Windows.Forms.Label();
            this.pBarCurrTab = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSituazione = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.DS = new no_table_unifydip.vistaForm();
            this.btnCopia = new System.Windows.Forms.Button();
            this.tabController.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabIntro.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // tabController
            // 
            this.tabController.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabController.IDEPixelArea = true;
            this.tabController.Location = new System.Drawing.Point(12, 23);
            this.tabController.Name = "tabController";
            this.tabController.SelectedIndex = 1;
            this.tabController.SelectedTab = this.tabPage1;
            this.tabController.Size = new System.Drawing.Size(984, 552);
            this.tabController.TabIndex = 2;
            this.tabController.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabIntro,
            this.tabPage1,
            this.tabPage2});
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkSuffix);
            this.tabPage1.Controls.Add(this.btnFaiTutto);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.txtSuperUser);
            this.tabPage1.Controls.Add(this.txtSuperPwd);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtFattore);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(984, 527);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Title = "Selezione dipartimento";
            // 
            // chkSuffix
            // 
            this.chkSuffix.AutoSize = true;
            this.chkSuffix.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSuffix.Checked = true;
            this.chkSuffix.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSuffix.Location = new System.Drawing.Point(26, 428);
            this.chkSuffix.Name = "chkSuffix";
            this.chkSuffix.Size = new System.Drawing.Size(184, 17);
            this.chkSuffix.TabIndex = 32;
            this.chkSuffix.Text = "Appendi suffissi su alcune tabelle";
            this.chkSuffix.UseVisualStyleBackColor = true;
            // 
            // btnFaiTutto
            // 
            this.btnFaiTutto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFaiTutto.Location = new System.Drawing.Point(770, 95);
            this.btnFaiTutto.Name = "btnFaiTutto";
            this.btnFaiTutto.Size = new System.Drawing.Size(88, 23);
            this.btnFaiTutto.TabIndex = 27;
            this.btnFaiTutto.Text = "Fai tutto";
            this.btnFaiTutto.Click += new System.EventHandler(this.btnFaiTutto_Click);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(495, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(176, 23);
            this.label8.TabIndex = 28;
            this.label8.Text = "Superuser";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(565, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 23);
            this.label9.TabIndex = 29;
            this.label9.Text = "Password";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSuperUser
            // 
            this.txtSuperUser.Location = new System.Drawing.Point(671, 44);
            this.txtSuperUser.Name = "txtSuperUser";
            this.txtSuperUser.Size = new System.Drawing.Size(200, 21);
            this.txtSuperUser.TabIndex = 30;
            this.txtSuperUser.Text = "mluisas";
            // 
            // txtSuperPwd
            // 
            this.txtSuperPwd.Location = new System.Drawing.Point(671, 68);
            this.txtSuperPwd.Name = "txtSuperPwd";
            this.txtSuperPwd.PasswordChar = '*';
            this.txtSuperPwd.Size = new System.Drawing.Size(200, 21);
            this.txtSuperPwd.TabIndex = 31;
            this.txtSuperPwd.Text = "mluisas";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(289, 404);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(396, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Es. se si mette 1 i mandati saranno renumerati di 10000, se si mette 2 20000 etc." +
                "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 404);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Fattore da usare per l\'offset";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFattore
            // 
            this.txtFattore.Location = new System.Drawing.Point(172, 401);
            this.txtFattore.Name = "txtFattore";
            this.txtFattore.Size = new System.Drawing.Size(100, 21);
            this.txtFattore.TabIndex = 25;
            this.txtFattore.Text = "2";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.txtDestUser);
            this.groupBox2.Controls.Add(this.txtDestPwd);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txtDipDestinazione);
            this.groupBox2.Location = new System.Drawing.Point(17, 257);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(408, 124);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dipartimento destinazione  IN CUI importare i dati";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(6, 27);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(176, 23);
            this.label17.TabIndex = 24;
            this.label17.Text = "Nome utente per connettersi";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(76, 51);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(100, 23);
            this.label18.TabIndex = 25;
            this.label18.Text = "Password";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDestUser
            // 
            this.txtDestUser.Location = new System.Drawing.Point(182, 27);
            this.txtDestUser.Name = "txtDestUser";
            this.txtDestUser.Size = new System.Drawing.Size(200, 21);
            this.txtDestUser.TabIndex = 1;
            this.txtDestUser.Text = "mluisas";
            // 
            // txtDestPwd
            // 
            this.txtDestPwd.Location = new System.Drawing.Point(182, 51);
            this.txtDestPwd.Name = "txtDestPwd";
            this.txtDestPwd.PasswordChar = '*';
            this.txtDestPwd.Size = new System.Drawing.Size(200, 21);
            this.txtDestPwd.TabIndex = 2;
            this.txtDestPwd.Text = "mluisas";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(12, 79);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(168, 23);
            this.label16.TabIndex = 22;
            this.label16.Text = " Dipartimento";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDipDestinazione
            // 
            this.txtDipDestinazione.Location = new System.Drawing.Point(184, 81);
            this.txtDipDestinazione.Name = "txtDipDestinazione";
            this.txtDipDestinazione.Size = new System.Drawing.Size(200, 21);
            this.txtDipDestinazione.TabIndex = 3;
            this.txtDipDestinazione.Text = "amministrazione";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSourceServer);
            this.groupBox1.Controls.Add(this.txtSourceDataBase);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSourceDip);
            this.groupBox1.Controls.Add(this.label30);
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Controls.Add(this.txtSourceUser);
            this.groupBox1.Controls.Add(this.txtSourcePwd);
            this.groupBox1.Location = new System.Drawing.Point(17, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(408, 227);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dipartimento origine  da cui ESPORTARE i dati";
            // 
            // txtSourceServer
            // 
            this.txtSourceServer.Location = new System.Drawing.Point(188, 20);
            this.txtSourceServer.Name = "txtSourceServer";
            this.txtSourceServer.Size = new System.Drawing.Size(200, 21);
            this.txtSourceServer.TabIndex = 24;
            this.txtSourceServer.Text = "SERVER\\sql2008,1435";
            // 
            // txtSourceDataBase
            // 
            this.txtSourceDataBase.Location = new System.Drawing.Point(188, 44);
            this.txtSourceDataBase.Name = "txtSourceDataBase";
            this.txtSourceDataBase.Size = new System.Drawing.Size(200, 21);
            this.txtSourceDataBase.TabIndex = 25;
            this.txtSourceDataBase.Text = "easypo";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(6, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(176, 23);
            this.label10.TabIndex = 22;
            this.label10.Text = "Server";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(76, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 23);
            this.label11.TabIndex = 23;
            this.label11.Text = "Database";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 23);
            this.label1.TabIndex = 20;
            this.label1.Text = "Dipartimento";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSourceDip
            // 
            this.txtSourceDip.Location = new System.Drawing.Point(182, 184);
            this.txtSourceDip.Name = "txtSourceDip";
            this.txtSourceDip.Size = new System.Drawing.Size(200, 21);
            this.txtSourceDip.TabIndex = 21;
            this.txtSourceDip.Text = "dimet";
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(6, 137);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(176, 23);
            this.label30.TabIndex = 13;
            this.label30.Text = "Nome utente per connettersi";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(76, 161);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(100, 23);
            this.label29.TabIndex = 14;
            this.label29.Text = "Password";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSourceUser
            // 
            this.txtSourceUser.Location = new System.Drawing.Point(182, 137);
            this.txtSourceUser.Name = "txtSourceUser";
            this.txtSourceUser.Size = new System.Drawing.Size(200, 21);
            this.txtSourceUser.TabIndex = 18;
            this.txtSourceUser.Text = "mluisas";
            // 
            // txtSourcePwd
            // 
            this.txtSourcePwd.Location = new System.Drawing.Point(182, 161);
            this.txtSourcePwd.Name = "txtSourcePwd";
            this.txtSourcePwd.PasswordChar = '*';
            this.txtSourcePwd.Size = new System.Drawing.Size(200, 21);
            this.txtSourcePwd.TabIndex = 19;
            this.txtSourcePwd.Text = "mluisas";
            // 
            // tabIntro
            // 
            this.tabIntro.Controls.Add(this.label4);
            this.tabIntro.Controls.Add(this.label3);
            this.tabIntro.Controls.Add(this.label2);
            this.tabIntro.Location = new System.Drawing.Point(0, 0);
            this.tabIntro.Name = "tabIntro";
            this.tabIntro.Selected = false;
            this.tabIntro.Size = new System.Drawing.Size(984, 527);
            this.tabIntro.TabIndex = 3;
            this.tabIntro.Title = "Introduzione";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(462, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Non eseguire la procedura prima di aver opportunamente configurato il dipartiment" +
                "o di origine. ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(529, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Questa procedura importerà la maggior parte dei dati presenti in un altro diparti" +
                "mento dello stesso database.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.label2.Location = new System.Drawing.Point(21, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Importazione dati da altro dipartimento";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.labCurrTable);
            this.tabPage2.Controls.Add(this.pBarCurrTab);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.txtSituazione);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(984, 527);
            this.tabPage2.TabIndex = 5;
            this.tabPage2.Title = "Calcolo offset";
            // 
            // labCurrTable
            // 
            this.labCurrTable.AutoSize = true;
            this.labCurrTable.Location = new System.Drawing.Point(17, 469);
            this.labCurrTable.Name = "labCurrTable";
            this.labCurrTable.Size = new System.Drawing.Size(216, 13);
            this.labCurrTable.TabIndex = 10;
            this.labCurrTable.Text = "Stato di avanzamento della tabella corrente";
            // 
            // pBarCurrTab
            // 
            this.pBarCurrTab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pBarCurrTab.Location = new System.Drawing.Point(20, 485);
            this.pBarCurrTab.Name = "pBarCurrTab";
            this.pBarCurrTab.Size = new System.Drawing.Size(943, 26);
            this.pBarCurrTab.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Situazione generale";
            // 
            // txtSituazione
            // 
            this.txtSituazione.AcceptsTab = true;
            this.txtSituazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSituazione.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSituazione.Location = new System.Drawing.Point(17, 34);
            this.txtSituazione.Multiline = true;
            this.txtSituazione.Name = "txtSituazione";
            this.txtSituazione.ReadOnly = true;
            this.txtSituazione.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSituazione.Size = new System.Drawing.Size(946, 419);
            this.txtSituazione.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(921, 597);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Tag = "maincancel";
            this.btnCancel.Text = "Cancel";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(801, 597);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(88, 23);
            this.btnNext.TabIndex = 24;
            this.btnNext.Text = "Avanti >";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(713, 597);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 23);
            this.btnBack.TabIndex = 23;
            this.btnBack.Text = "< Indietro";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // btnCopia
            // 
            this.btnCopia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopia.Location = new System.Drawing.Point(466, 597);
            this.btnCopia.Name = "btnCopia";
            this.btnCopia.Size = new System.Drawing.Size(88, 23);
            this.btnCopia.TabIndex = 26;
            this.btnCopia.Text = "Copia";
            this.btnCopia.Visible = false;
            this.btnCopia.Click += new System.EventHandler(this.btnCopia_Click);
            // 
            // Frm_Uniydip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 644);
            this.Controls.Add(this.btnCopia);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.tabController);
            this.Name = "Frm_Uniydip";
            this.Text = "Frm_Uniydip";
            this.tabController.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabIntro.ResumeLayout(false);
            this.tabIntro.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Crownwood.Magic.Controls.TabControl tabController;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private Crownwood.Magic.Controls.TabPage tabIntro;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtSourceUser;
        private System.Windows.Forms.TextBox txtSourcePwd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Crownwood.Magic.Controls.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtDestUser;
        private System.Windows.Forms.TextBox txtDestPwd;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtDipDestinazione;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSituazione;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFattore;
        private System.Windows.Forms.Label labCurrTable;
        private System.Windows.Forms.ProgressBar pBarCurrTab;
        public vistaForm DS;
        private System.Windows.Forms.Button btnCopia;
        private System.Windows.Forms.Button btnFaiTutto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSuperUser;
        private System.Windows.Forms.TextBox txtSuperPwd;
        private System.Windows.Forms.CheckBox chkSuffix;
        private System.Windows.Forms.TextBox txtSourceServer;
        private System.Windows.Forms.TextBox txtSourceDataBase;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSourceDip;

    }
}