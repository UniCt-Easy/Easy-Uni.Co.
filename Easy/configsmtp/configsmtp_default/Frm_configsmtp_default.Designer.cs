
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


namespace configsmtp_default
{
    partial class Frm_configsmtp_default
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
			this.checkFlagsend = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textEmailPerCc = new System.Windows.Forms.TextBox();
			this.emailPerCc = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.textBox11 = new System.Windows.Forms.TextBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.DS = new configsmtp_default.vistaForm();
			this.textBox12 = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// checkFlagsend
			// 
			this.checkFlagsend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkFlagsend.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkFlagsend.Location = new System.Drawing.Point(810, 24);
			this.checkFlagsend.Name = "checkFlagsend";
			this.checkFlagsend.Size = new System.Drawing.Size(111, 24);
			this.checkFlagsend.TabIndex = 7;
			this.checkFlagsend.TabStop = false;
			this.checkFlagsend.Tag = "configsmtp.flagsend:S:N";
			this.checkFlagsend.Text = "Invia Notifiche";
			this.checkFlagsend.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.textEmailPerCc);
			this.groupBox1.Controls.Add(this.emailPerCc);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.textBox11);
			this.groupBox1.Controls.Add(this.textBox5);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.textBox4);
			this.groupBox1.Controls.Add(this.checkFlagsend);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.textBox2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.textBox3);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Location = new System.Drawing.Point(11, 38);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(927, 211);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Notifiche predefinite";
			// 
			// textEmailPerCc
			// 
			this.textEmailPerCc.Location = new System.Drawing.Point(123, 180);
			this.textEmailPerCc.Name = "textEmailPerCc";
			this.textEmailPerCc.Size = new System.Drawing.Size(231, 20);
			this.textEmailPerCc.TabIndex = 22;
			this.textEmailPerCc.Tag = "configsmtp.email_cc";
			// 
			// emailPerCc
			// 
			this.emailPerCc.AutoSize = true;
			this.emailPerCc.Location = new System.Drawing.Point(47, 184);
			this.emailPerCc.Name = "emailPerCc";
			this.emailPerCc.Size = new System.Drawing.Size(67, 13);
			this.emailPerCc.TabIndex = 21;
			this.emailPerCc.Text = "Email per CC";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(610, 55);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(186, 13);
			this.label11.TabIndex = 20;
			this.label11.Text = "Testo da accodare alle notifiche email";
			// 
			// textBox11
			// 
			this.textBox11.Location = new System.Drawing.Point(614, 70);
			this.textBox11.Multiline = true;
			this.textBox11.Name = "textBox11";
			this.textBox11.Size = new System.Drawing.Size(308, 64);
			this.textBox11.TabIndex = 19;
			this.textBox11.Tag = "configsmtp.signature";
			// 
			// textBox5
			// 
			this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox5.Location = new System.Drawing.Point(122, 148);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(799, 20);
			this.textBox5.TabIndex = 17;
			this.textBox5.Tag = "configsmtp.sqlattachmentspath";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(18, 148);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(96, 16);
			this.label3.TabIndex = 18;
			this.label3.Text = "Folder per mail Sql";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(122, 81);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(232, 20);
			this.textBox4.TabIndex = 5;
			this.textBox4.Tag = "configsmtp.port";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(58, 81);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 16;
			this.label2.Text = "Porta";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(122, 27);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(232, 20);
			this.textBox2.TabIndex = 2;
			this.textBox2.Tag = "configsmtp.server";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(58, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 14;
			this.label1.Text = "Server";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox3
			// 
			this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox3.Location = new System.Drawing.Point(123, 114);
			this.textBox3.Name = "textBox3";
			this.textBox3.PasswordChar = '*';
			this.textBox3.Size = new System.Drawing.Size(271, 20);
			this.textBox3.TabIndex = 4;
			this.textBox3.Tag = "configsmtp.password";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(42, 114);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(72, 16);
			this.label6.TabIndex = 12;
			this.label6.Text = "Password";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(122, 55);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(232, 20);
			this.textBox1.TabIndex = 3;
			this.textBox1.Tag = "configsmtp.login";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(58, 55);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 16);
			this.label5.TabIndex = 4;
			this.label5.Text = "Login";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(850, 546);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 11;
			this.btnCancel.Text = "Annulla";
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(738, 546);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 10;
			this.btnOk.Tag = "mainsave";
			this.btnOk.Text = "Ok";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.label12);
			this.groupBox2.Controls.Add(this.textBox12);
			this.groupBox2.Controls.Add(this.checkBox1);
			this.groupBox2.Controls.Add(this.textBox6);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.textBox7);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.textBox8);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.textBox9);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.textBox10);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Location = new System.Drawing.Point(12, 265);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(927, 189);
			this.groupBox2.TabIndex = 12;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Notifiche per Certificazione Unica";
			// 
			// checkBox1
			// 
			this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBox1.Location = new System.Drawing.Point(818, 19);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(103, 24);
			this.checkBox1.TabIndex = 19;
			this.checkBox1.TabStop = false;
			this.checkBox1.Tag = "configsmtp.flagsend_cu:S:N";
			this.checkBox1.Text = "Invia Notifiche";
			this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox6
			// 
			this.textBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox6.Location = new System.Drawing.Point(122, 148);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(799, 20);
			this.textBox6.TabIndex = 17;
			this.textBox6.Tag = "configsmtp.sqlattachmentspath_cu";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(18, 148);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(96, 16);
			this.label4.TabIndex = 18;
			this.label4.Text = "Folder per mail Sql";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(122, 84);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(232, 20);
			this.textBox7.TabIndex = 5;
			this.textBox7.Tag = "configsmtp.port_cu";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(58, 83);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(56, 16);
			this.label7.TabIndex = 16;
			this.label7.Text = "Porta";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(122, 27);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(232, 20);
			this.textBox8.TabIndex = 2;
			this.textBox8.Tag = "configsmtp.server_cu";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(58, 27);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(56, 16);
			this.label8.TabIndex = 14;
			this.label8.Text = "Server";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox9
			// 
			this.textBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox9.Location = new System.Drawing.Point(122, 113);
			this.textBox9.Name = "textBox9";
			this.textBox9.PasswordChar = '*';
			this.textBox9.Size = new System.Drawing.Size(274, 20);
			this.textBox9.TabIndex = 4;
			this.textBox9.Tag = "configsmtp.password_cu";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(42, 114);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(72, 16);
			this.label9.TabIndex = 12;
			this.label9.Text = "Password";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox10
			// 
			this.textBox10.Location = new System.Drawing.Point(122, 55);
			this.textBox10.Name = "textBox10";
			this.textBox10.Size = new System.Drawing.Size(232, 20);
			this.textBox10.TabIndex = 3;
			this.textBox10.Tag = "configsmtp.login_cu";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(58, 55);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(56, 16);
			this.label10.TabIndex = 4;
			this.label10.Text = "Login";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			// 
			// textBox12
			// 
			this.textBox12.Location = new System.Drawing.Point(542, 114);
			this.textBox12.Name = "textBox12";
			this.textBox12.Size = new System.Drawing.Size(379, 20);
			this.textBox12.TabIndex = 20;
			this.textBox12.Tag = "configsmtp.responsabile_cu";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(539, 100);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(161, 13);
			this.label12.TabIndex = 21;
			this.label12.Text = "Indirizzo email per resoconto invii";
			// 
			// Frm_configsmtp_default
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(950, 591);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.groupBox1);
			this.Name = "Frm_configsmtp_default";
			this.Text = "Frm_configsmtp_default";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.CheckBox checkFlagsend;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox textBox11;
		private System.Windows.Forms.TextBox textEmailPerCc;
		private System.Windows.Forms.Label emailPerCc;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox textBox12;
	}
}
