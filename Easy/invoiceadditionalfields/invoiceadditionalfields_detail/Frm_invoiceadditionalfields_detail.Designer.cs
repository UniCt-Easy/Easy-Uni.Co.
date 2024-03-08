
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



namespace invoiceadditionalfields_detail {
	partial class Frm_invoiceadditionalfields_detail {
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
			this.grpBox1 = new System.Windows.Forms.GroupBox();
			this.txtLabelforString1 = new System.Windows.Forms.TextBox();
			this.txtLabelforString3 = new System.Windows.Forms.TextBox();
			this.txtLabelforString2 = new System.Windows.Forms.TextBox();
			this.txtLabelforDate1 = new System.Windows.Forms.TextBox();
			this.textFieldString3 = new System.Windows.Forms.TextBox();
			this.textFieldInt1 = new System.Windows.Forms.TextBox();
			this.textFieldString1 = new System.Windows.Forms.TextBox();
			this.textFieldDate1 = new System.Windows.Forms.TextBox();
			this.textFieldString2 = new System.Windows.Forms.TextBox();
			this.txtLabelforInt1 = new System.Windows.Forms.TextBox();
			this.DS = new invoiceadditionalfields_detail.vistaForm();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.grpInt1 = new System.Windows.Forms.GroupBox();
			this.grpString1 = new System.Windows.Forms.GroupBox();
			this.grpDate1 = new System.Windows.Forms.GroupBox();
			this.grpString2 = new System.Windows.Forms.GroupBox();
			this.grpString3 = new System.Windows.Forms.GroupBox();
			this.grpBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.grpInt1.SuspendLayout();
			this.grpString1.SuspendLayout();
			this.grpDate1.SuspendLayout();
			this.grpString2.SuspendLayout();
			this.grpString3.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpBox1
			// 
			this.grpBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpBox1.Controls.Add(this.grpString3);
			this.grpBox1.Controls.Add(this.grpString2);
			this.grpBox1.Controls.Add(this.grpDate1);
			this.grpBox1.Controls.Add(this.grpString1);
			this.grpBox1.Controls.Add(this.grpInt1);
			this.grpBox1.Location = new System.Drawing.Point(12, 16);
			this.grpBox1.Name = "grpBox1";
			this.grpBox1.Size = new System.Drawing.Size(557, 316);
			this.grpBox1.TabIndex = 0;
			this.grpBox1.TabStop = false;
			this.grpBox1.Text = "grpTabName1";
			this.grpBox1.Enter += new System.EventHandler(this.grpBox1_Enter);
			// 
			// txtLabelforString1
			// 
			this.txtLabelforString1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.txtLabelforString1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtLabelforString1.Location = new System.Drawing.Point(9, 25);
			this.txtLabelforString1.Name = "txtLabelforString1";
			this.txtLabelforString1.ReadOnly = true;
			this.txtLabelforString1.Size = new System.Drawing.Size(193, 13);
			this.txtLabelforString1.TabIndex = 16;
			this.txtLabelforString1.TabStop = false;
			this.txtLabelforString1.Tag = "invoiceadditionalfields.labelfield1str";
			this.txtLabelforString1.Text = "LabelforString1";
			this.txtLabelforString1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtLabelforString3
			// 
			this.txtLabelforString3.BackColor = System.Drawing.SystemColors.Window;
			this.txtLabelforString3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtLabelforString3.Location = new System.Drawing.Point(15, 21);
			this.txtLabelforString3.Name = "txtLabelforString3";
			this.txtLabelforString3.ReadOnly = true;
			this.txtLabelforString3.Size = new System.Drawing.Size(188, 13);
			this.txtLabelforString3.TabIndex = 14;
			this.txtLabelforString3.TabStop = false;
			this.txtLabelforString3.Tag = "invoiceadditionalfields.labelfield3str";
			this.txtLabelforString3.Text = "LabelforString3";
			this.txtLabelforString3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtLabelforString3.TextChanged += new System.EventHandler(this.txtLabelforString3_TextChanged);
			// 
			// txtLabelforString2
			// 
			this.txtLabelforString2.BackColor = System.Drawing.SystemColors.Window;
			this.txtLabelforString2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtLabelforString2.Location = new System.Drawing.Point(12, 26);
			this.txtLabelforString2.Name = "txtLabelforString2";
			this.txtLabelforString2.ReadOnly = true;
			this.txtLabelforString2.Size = new System.Drawing.Size(188, 13);
			this.txtLabelforString2.TabIndex = 13;
			this.txtLabelforString2.TabStop = false;
			this.txtLabelforString2.Tag = "invoiceadditionalfields.labelfield2str";
			this.txtLabelforString2.Text = "LabelforString2";
			this.txtLabelforString2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtLabelforString2.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
			// 
			// txtLabelforDate1
			// 
			this.txtLabelforDate1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.txtLabelforDate1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtLabelforDate1.Location = new System.Drawing.Point(21, 15);
			this.txtLabelforDate1.Name = "txtLabelforDate1";
			this.txtLabelforDate1.ReadOnly = true;
			this.txtLabelforDate1.Size = new System.Drawing.Size(179, 13);
			this.txtLabelforDate1.TabIndex = 12;
			this.txtLabelforDate1.TabStop = false;
			this.txtLabelforDate1.Tag = "invoiceadditionalfields.labelfield1date";
			this.txtLabelforDate1.Text = "LabelforDate1";
			this.txtLabelforDate1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// textFieldString3
			// 
			this.textFieldString3.Location = new System.Drawing.Point(220, 15);
			this.textFieldString3.Multiline = true;
			this.textFieldString3.Name = "textFieldString3";
			this.textFieldString3.Size = new System.Drawing.Size(301, 22);
			this.textFieldString3.TabIndex = 5;
			this.textFieldString3.Tag = "invoiceadditionalfields.valuefield3str";
			this.textFieldString3.TextChanged += new System.EventHandler(this.textFieldString3_TextChanged);
			// 
			// textFieldInt1
			// 
			this.textFieldInt1.Location = new System.Drawing.Point(217, 19);
			this.textFieldInt1.Name = "textFieldInt1";
			this.textFieldInt1.Size = new System.Drawing.Size(55, 20);
			this.textFieldInt1.TabIndex = 1;
			this.textFieldInt1.Tag = "invoiceadditionalfields.valuefield1int";
			// 
			// textFieldString1
			// 
			this.textFieldString1.Location = new System.Drawing.Point(219, 19);
			this.textFieldString1.Name = "textFieldString1";
			this.textFieldString1.Size = new System.Drawing.Size(55, 20);
			this.textFieldString1.TabIndex = 2;
			this.textFieldString1.Tag = "invoiceadditionalfields.valuefield1str";
			// 
			// textFieldDate1
			// 
			this.textFieldDate1.Location = new System.Drawing.Point(217, 12);
			this.textFieldDate1.Name = "textFieldDate1";
			this.textFieldDate1.Size = new System.Drawing.Size(80, 20);
			this.textFieldDate1.TabIndex = 3;
			this.textFieldDate1.Tag = "invoiceadditionalfields.valuefield1date";
			// 
			// textFieldString2
			// 
			this.textFieldString2.Location = new System.Drawing.Point(217, 23);
			this.textFieldString2.Name = "textFieldString2";
			this.textFieldString2.Size = new System.Drawing.Size(55, 20);
			this.textFieldString2.TabIndex = 4;
			this.textFieldString2.Tag = "invoiceadditionalfields.valuefield2str";
			this.textFieldString2.TextChanged += new System.EventHandler(this.textFieldString2_TextChanged);
			// 
			// txtLabelforInt1
			// 
			this.txtLabelforInt1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.txtLabelforInt1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtLabelforInt1.Location = new System.Drawing.Point(8, 23);
			this.txtLabelforInt1.Name = "txtLabelforInt1";
			this.txtLabelforInt1.ReadOnly = true;
			this.txtLabelforInt1.Size = new System.Drawing.Size(192, 13);
			this.txtLabelforInt1.TabIndex = 0;
			this.txtLabelforInt1.TabStop = false;
			this.txtLabelforInt1.Tag = "invoiceadditionalfields.labelfield1int";
			this.txtLabelforInt1.Text = "LabelforInt1";
			this.txtLabelforInt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(493, 351);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
			this.btnAnnulla.TabIndex = 14;
			this.btnAnnulla.TabStop = false;
			this.btnAnnulla.Text = "Annulla";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(399, 351);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 13;
			this.btnOK.TabStop = false;
			this.btnOK.Tag = "mainsave";
			this.btnOK.Text = "OK";
			// 
			// grpInt1
			// 
			this.grpInt1.Controls.Add(this.textFieldInt1);
			this.grpInt1.Controls.Add(this.txtLabelforInt1);
			this.grpInt1.Location = new System.Drawing.Point(13, 20);
			this.grpInt1.Name = "grpInt1";
			this.grpInt1.Size = new System.Drawing.Size(346, 47);
			this.grpInt1.TabIndex = 17;
			this.grpInt1.TabStop = false;
			this.grpInt1.Text = "grpInt1";
			// 
			// grpString1
			// 
			this.grpString1.Controls.Add(this.txtLabelforString1);
			this.grpString1.Controls.Add(this.textFieldString1);
			this.grpString1.Location = new System.Drawing.Point(11, 73);
			this.grpString1.Name = "grpString1";
			this.grpString1.Size = new System.Drawing.Size(348, 56);
			this.grpString1.TabIndex = 18;
			this.grpString1.TabStop = false;
			this.grpString1.Text = "grpString1";
			// 
			// grpDate1
			// 
			this.grpDate1.Controls.Add(this.txtLabelforDate1);
			this.grpDate1.Controls.Add(this.textFieldDate1);
			this.grpDate1.Location = new System.Drawing.Point(13, 135);
			this.grpDate1.Name = "grpDate1";
			this.grpDate1.Size = new System.Drawing.Size(346, 43);
			this.grpDate1.TabIndex = 19;
			this.grpDate1.TabStop = false;
			this.grpDate1.Text = "grpDate1";
			// 
			// grpString2
			// 
			this.grpString2.Controls.Add(this.txtLabelforString2);
			this.grpString2.Controls.Add(this.textFieldString2);
			this.grpString2.Location = new System.Drawing.Point(13, 182);
			this.grpString2.Name = "grpString2";
			this.grpString2.Size = new System.Drawing.Size(346, 51);
			this.grpString2.TabIndex = 20;
			this.grpString2.TabStop = false;
			this.grpString2.Text = "grpString2";
			// 
			// grpString3
			// 
			this.grpString3.Controls.Add(this.txtLabelforString3);
			this.grpString3.Controls.Add(this.textFieldString3);
			this.grpString3.Location = new System.Drawing.Point(10, 251);
			this.grpString3.Name = "grpString3";
			this.grpString3.Size = new System.Drawing.Size(535, 52);
			this.grpString3.TabIndex = 21;
			this.grpString3.TabStop = false;
			this.grpString3.Text = "grpString3";
			// 
			// Frm_invoiceadditionalfields_detail
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(581, 379);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.grpBox1);
			this.Name = "Frm_invoiceadditionalfields_detail";
			this.Text = "Frm_invoiceadditionalfields_detail";
			this.grpBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.grpInt1.ResumeLayout(false);
			this.grpInt1.PerformLayout();
			this.grpString1.ResumeLayout(false);
			this.grpString1.PerformLayout();
			this.grpDate1.ResumeLayout(false);
			this.grpDate1.PerformLayout();
			this.grpString2.ResumeLayout(false);
			this.grpString2.PerformLayout();
			this.grpString3.ResumeLayout(false);
			this.grpString3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		public vistaForm DS;
		private System.Windows.Forms.GroupBox grpBox1;
		private System.Windows.Forms.TextBox textFieldString3;
		private System.Windows.Forms.TextBox textFieldInt1;
		private System.Windows.Forms.TextBox textFieldString1;
		private System.Windows.Forms.TextBox textFieldDate1;
		private System.Windows.Forms.TextBox textFieldString2;
		private System.Windows.Forms.TextBox txtLabelforString2;
		private System.Windows.Forms.TextBox txtLabelforDate1;
		private System.Windows.Forms.TextBox txtLabelforInt1;
		private System.Windows.Forms.TextBox txtLabelforString1;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.TextBox txtLabelforString3;
		private System.Windows.Forms.GroupBox grpString3;
		private System.Windows.Forms.GroupBox grpString2;
		private System.Windows.Forms.GroupBox grpDate1;
		private System.Windows.Forms.GroupBox grpString1;
		private System.Windows.Forms.GroupBox grpInt1;
	}
}
