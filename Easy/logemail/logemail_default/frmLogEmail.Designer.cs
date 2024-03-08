
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



namespace logemail_default {
	partial class frmLogEmail {
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
			this.txtSender = new System.Windows.Forms.TextBox();
			this.txtReceiver = new System.Windows.Forms.TextBox();
			this.txtSent = new System.Windows.Forms.TextBox();
			this.txtSubject = new System.Windows.Forms.TextBox();
			this.txtErrorMess = new System.Windows.Forms.TextBox();
			this.txtAllegato = new System.Windows.Forms.TextBox();
			this.labelSender = new System.Windows.Forms.Label();
			this.txtCc = new System.Windows.Forms.TextBox();
			this.labelReceiver = new System.Windows.Forms.Label();
			this.labelSent = new System.Windows.Forms.Label();
			this.labelAllegato = new System.Windows.Forms.Label();
			this.labelCc = new System.Windows.Forms.Label();
			this.labelSubject = new System.Windows.Forms.Label();
			this.labelErrorMess = new System.Windows.Forms.Label();
			this.txtMessage = new System.Windows.Forms.TextBox();
			this.labelMessage = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.labelBcc = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtId = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.label1 = new System.Windows.Forms.Label();
			this.txtModuleContext = new System.Windows.Forms.TextBox();
			this.DS = new logemail_default.vistaForm();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// txtSender
			// 
			this.txtSender.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSender.Location = new System.Drawing.Point(6, 71);
			this.txtSender.Name = "txtSender";
			this.txtSender.Size = new System.Drawing.Size(619, 20);
			this.txtSender.TabIndex = 0;
			this.txtSender.Tag = "logemail.sender";
			// 
			// txtReceiver
			// 
			this.txtReceiver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtReceiver.Location = new System.Drawing.Point(6, 118);
			this.txtReceiver.Multiline = true;
			this.txtReceiver.Name = "txtReceiver";
			this.txtReceiver.Size = new System.Drawing.Size(619, 60);
			this.txtReceiver.TabIndex = 1;
			this.txtReceiver.Tag = "logemail.receiver";
			// 
			// txtSent
			// 
			this.txtSent.Location = new System.Drawing.Point(7, 28);
			this.txtSent.Name = "txtSent";
			this.txtSent.Size = new System.Drawing.Size(58, 20);
			this.txtSent.TabIndex = 2;
			this.txtSent.Tag = "logemail.sent";
			// 
			// txtSubject
			// 
			this.txtSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSubject.Location = new System.Drawing.Point(6, 379);
			this.txtSubject.Name = "txtSubject";
			this.txtSubject.Size = new System.Drawing.Size(618, 20);
			this.txtSubject.TabIndex = 3;
			this.txtSubject.Tag = "logemail.subject";
			// 
			// txtErrorMess
			// 
			this.txtErrorMess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtErrorMess.Location = new System.Drawing.Point(7, 706);
			this.txtErrorMess.Multiline = true;
			this.txtErrorMess.Name = "txtErrorMess";
			this.txtErrorMess.Size = new System.Drawing.Size(618, 44);
			this.txtErrorMess.TabIndex = 5;
			this.txtErrorMess.Tag = "logemail.errorMessage";
			// 
			// txtAllegato
			// 
			this.txtAllegato.Location = new System.Drawing.Point(111, 28);
			this.txtAllegato.Name = "txtAllegato";
			this.txtAllegato.Size = new System.Drawing.Size(58, 20);
			this.txtAllegato.TabIndex = 6;
			this.txtAllegato.Tag = "logemail.allegato";
			// 
			// labelSender
			// 
			this.labelSender.AutoSize = true;
			this.labelSender.Location = new System.Drawing.Point(4, 57);
			this.labelSender.Name = "labelSender";
			this.labelSender.Size = new System.Drawing.Size(45, 13);
			this.labelSender.TabIndex = 7;
			this.labelSender.Text = "Mittente";
			// 
			// txtCc
			// 
			this.txtCc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCc.Location = new System.Drawing.Point(6, 203);
			this.txtCc.Multiline = true;
			this.txtCc.Name = "txtCc";
			this.txtCc.Size = new System.Drawing.Size(618, 60);
			this.txtCc.TabIndex = 8;
			this.txtCc.Tag = "logemail.cc";
			// 
			// labelReceiver
			// 
			this.labelReceiver.AutoSize = true;
			this.labelReceiver.Location = new System.Drawing.Point(3, 104);
			this.labelReceiver.Name = "labelReceiver";
			this.labelReceiver.Size = new System.Drawing.Size(63, 13);
			this.labelReceiver.TabIndex = 9;
			this.labelReceiver.Text = "Destinatario";
			// 
			// labelSent
			// 
			this.labelSent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelSent.AutoSize = true;
			this.labelSent.Location = new System.Drawing.Point(4, 15);
			this.labelSent.Name = "labelSent";
			this.labelSent.Size = new System.Drawing.Size(39, 13);
			this.labelSent.TabIndex = 10;
			this.labelSent.Text = "Inviato";
			// 
			// labelAllegato
			// 
			this.labelAllegato.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelAllegato.AutoSize = true;
			this.labelAllegato.Location = new System.Drawing.Point(108, 15);
			this.labelAllegato.Name = "labelAllegato";
			this.labelAllegato.Size = new System.Drawing.Size(52, 13);
			this.labelAllegato.TabIndex = 11;
			this.labelAllegato.Text = "Allegato/i";
			// 
			// labelCc
			// 
			this.labelCc.AutoSize = true;
			this.labelCc.Location = new System.Drawing.Point(4, 189);
			this.labelCc.Name = "labelCc";
			this.labelCc.Size = new System.Drawing.Size(20, 13);
			this.labelCc.TabIndex = 12;
			this.labelCc.Text = "Cc";
			// 
			// labelSubject
			// 
			this.labelSubject.AutoSize = true;
			this.labelSubject.Location = new System.Drawing.Point(4, 364);
			this.labelSubject.Name = "labelSubject";
			this.labelSubject.Size = new System.Drawing.Size(45, 13);
			this.labelSubject.TabIndex = 13;
			this.labelSubject.Text = "Oggetto";
			// 
			// labelErrorMess
			// 
			this.labelErrorMess.AutoSize = true;
			this.labelErrorMess.Location = new System.Drawing.Point(5, 690);
			this.labelErrorMess.Name = "labelErrorMess";
			this.labelErrorMess.Size = new System.Drawing.Size(99, 13);
			this.labelErrorMess.TabIndex = 14;
			this.labelErrorMess.Text = "Messaggio di errore";
			// 
			// txtMessage
			// 
			this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtMessage.Location = new System.Drawing.Point(6, 430);
			this.txtMessage.Multiline = true;
			this.txtMessage.Name = "txtMessage";
			this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
			this.txtMessage.Size = new System.Drawing.Size(618, 247);
			this.txtMessage.TabIndex = 15;
			this.txtMessage.Tag = "logemail.message";
			// 
			// labelMessage
			// 
			this.labelMessage.AutoSize = true;
			this.labelMessage.Location = new System.Drawing.Point(4, 415);
			this.labelMessage.Name = "labelMessage";
			this.labelMessage.Size = new System.Drawing.Size(58, 13);
			this.labelMessage.TabIndex = 16;
			this.labelMessage.Tag = "";
			this.labelMessage.Text = "Messaggio";
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(12, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(639, 791);
			this.tabControl1.TabIndex = 17;
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.Color.Transparent;
			this.tabPage1.Controls.Add(this.labelBcc);
			this.tabPage1.Controls.Add(this.textBox1);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.txtId);
			this.tabPage1.Controls.Add(this.txtSender);
			this.tabPage1.Controls.Add(this.labelMessage);
			this.tabPage1.Controls.Add(this.labelSender);
			this.tabPage1.Controls.Add(this.txtMessage);
			this.tabPage1.Controls.Add(this.labelErrorMess);
			this.tabPage1.Controls.Add(this.txtReceiver);
			this.tabPage1.Controls.Add(this.txtErrorMess);
			this.tabPage1.Controls.Add(this.txtSubject);
			this.tabPage1.Controls.Add(this.labelAllegato);
			this.tabPage1.Controls.Add(this.labelSubject);
			this.tabPage1.Controls.Add(this.labelSent);
			this.tabPage1.Controls.Add(this.txtCc);
			this.tabPage1.Controls.Add(this.txtAllegato);
			this.tabPage1.Controls.Add(this.labelCc);
			this.tabPage1.Controls.Add(this.txtSent);
			this.tabPage1.Controls.Add(this.labelReceiver);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(631, 765);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Informazioni principali";
			// 
			// labelBcc
			// 
			this.labelBcc.AutoSize = true;
			this.labelBcc.Location = new System.Drawing.Point(4, 276);
			this.labelBcc.Name = "labelBcc";
			this.labelBcc.Size = new System.Drawing.Size(26, 13);
			this.labelBcc.TabIndex = 20;
			this.labelBcc.Text = "Bcc";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(6, 290);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(619, 60);
			this.textBox1.TabIndex = 19;
			this.textBox1.Tag = "logemail.bcc";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(571, 15);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(23, 13);
			this.label2.TabIndex = 18;
			this.label2.Text = "#Id";
			// 
			// txtId
			// 
			this.txtId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtId.Location = new System.Drawing.Point(573, 28);
			this.txtId.Name = "txtId";
			this.txtId.ReadOnly = true;
			this.txtId.Size = new System.Drawing.Size(52, 20);
			this.txtId.TabIndex = 17;
			this.txtId.Tag = "logemail.id";
			// 
			// tabPage2
			// 
			this.tabPage2.BackColor = System.Drawing.Color.Transparent;
			this.tabPage2.Controls.Add(this.label1);
			this.tabPage2.Controls.Add(this.txtModuleContext);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(631, 765);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Altro";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(246, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Modulo che ha richiamato la funzione di invio email";
			// 
			// txtModuleContext
			// 
			this.txtModuleContext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtModuleContext.Location = new System.Drawing.Point(6, 31);
			this.txtModuleContext.Multiline = true;
			this.txtModuleContext.Name = "txtModuleContext";
			this.txtModuleContext.ReadOnly = true;
			this.txtModuleContext.Size = new System.Drawing.Size(618, 102);
			this.txtModuleContext.TabIndex = 0;
			this.txtModuleContext.Tag = "logemail.moduleContext";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			// 
			// frmLogEmail
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(659, 810);
			this.Controls.Add(this.tabControl1);
			this.Name = "frmLogEmail";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Visualizza Log Email";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox txtSender;
		private System.Windows.Forms.TextBox txtReceiver;
		private System.Windows.Forms.TextBox txtSent;
		private System.Windows.Forms.TextBox txtSubject;
		private System.Windows.Forms.TextBox txtErrorMess;
		private System.Windows.Forms.TextBox txtAllegato;
		private System.Windows.Forms.Label labelSender;
		private System.Windows.Forms.TextBox txtCc;
		private System.Windows.Forms.Label labelReceiver;
		private System.Windows.Forms.Label labelSent;
		private System.Windows.Forms.Label labelAllegato;
		private System.Windows.Forms.Label labelCc;
		private System.Windows.Forms.Label labelSubject;
		private System.Windows.Forms.Label labelErrorMess;
		public vistaForm DS;
		private System.Windows.Forms.TextBox txtMessage;
		private System.Windows.Forms.Label labelMessage;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtModuleContext;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtId;
		private System.Windows.Forms.Label labelBcc;
		private System.Windows.Forms.TextBox textBox1;
	}
}
