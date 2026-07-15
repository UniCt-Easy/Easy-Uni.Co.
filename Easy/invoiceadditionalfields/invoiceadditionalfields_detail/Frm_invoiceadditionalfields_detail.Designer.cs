/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.grpTabName1 = new System.Windows.Forms.GroupBox();
			this.grpString31 = new System.Windows.Forms.GroupBox();
			this.txtLabelforString31 = new System.Windows.Forms.TextBox();
			this.txtFieldString3 = new System.Windows.Forms.TextBox();
			this.grpString21 = new System.Windows.Forms.GroupBox();
			this.txtLabelforString21 = new System.Windows.Forms.TextBox();
			this.txtFieldString2 = new System.Windows.Forms.TextBox();
			this.grpString11 = new System.Windows.Forms.GroupBox();
			this.txtLabelforString11 = new System.Windows.Forms.TextBox();
			this.txtFieldString1 = new System.Windows.Forms.TextBox();
			this.grpDate11 = new System.Windows.Forms.GroupBox();
			this.txtLabelforDate11 = new System.Windows.Forms.TextBox();
			this.txtFieldDate1 = new System.Windows.Forms.TextBox();
			this.grpInt11 = new System.Windows.Forms.GroupBox();
			this.txtFieldInt1 = new System.Windows.Forms.TextBox();
			this.txtLabelforInt11 = new System.Windows.Forms.TextBox();
			this.tabControlCampi = new System.Windows.Forms.TabControl();
			this.grpTabName = new System.Windows.Forms.GroupBox();
			this.rdbTabname4 = new System.Windows.Forms.RadioButton();
			this.rdbTabname3 = new System.Windows.Forms.RadioButton();
			this.rdbTabname2 = new System.Windows.Forms.RadioButton();
			this.rdbTabname1 = new System.Windows.Forms.RadioButton();
			this.DS = new invoiceadditionalfields_detail.vistaForm();
			this.pictureBoxString21 = new System.Windows.Forms.PictureBox();
			this.pictureBoxString11 = new System.Windows.Forms.PictureBox();
			this.pictureBoxDate11 = new System.Windows.Forms.PictureBox();
			this.pictureBoxInt11 = new System.Windows.Forms.PictureBox();
			this.pictureBoxString31 = new System.Windows.Forms.PictureBox();
			this.tabPage1.SuspendLayout();
			this.grpTabName1.SuspendLayout();
			this.grpString31.SuspendLayout();
			this.grpString21.SuspendLayout();
			this.grpString11.SuspendLayout();
			this.grpDate11.SuspendLayout();
			this.grpInt11.SuspendLayout();
			this.tabControlCampi.SuspendLayout();
			this.grpTabName.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxString21)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxString11)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDate11)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxInt11)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxString31)).BeginInit();
			this.SuspendLayout();
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(502, 464);
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
			this.btnOK.Location = new System.Drawing.Point(408, 464);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 13;
			this.btnOK.TabStop = false;
			this.btnOK.Tag = "mainsave";
			this.btnOK.Text = "OK";
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.grpTabName1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(595, 360);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Campi della Sezione";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// grpTabName1
			// 
			this.grpTabName1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpTabName1.Controls.Add(this.grpString31);
			this.grpTabName1.Controls.Add(this.grpString21);
			this.grpTabName1.Controls.Add(this.grpString11);
			this.grpTabName1.Controls.Add(this.grpDate11);
			this.grpTabName1.Controls.Add(this.grpInt11);
			this.grpTabName1.Location = new System.Drawing.Point(5, 14);
			this.grpTabName1.Name = "grpTabName1";
			this.grpTabName1.Size = new System.Drawing.Size(584, 329);
			this.grpTabName1.TabIndex = 2;
			this.grpTabName1.TabStop = false;
			this.grpTabName1.Text = "grpTabName1";
			// 
			// grpString31
			// 
			this.grpString31.Controls.Add(this.pictureBoxString31);
			this.grpString31.Controls.Add(this.txtLabelforString31);
			this.grpString31.Controls.Add(this.txtFieldString3);
			this.grpString31.Location = new System.Drawing.Point(12, 248);
			this.grpString31.Name = "grpString31";
			this.grpString31.Size = new System.Drawing.Size(556, 52);
			this.grpString31.TabIndex = 21;
			this.grpString31.TabStop = false;
			this.grpString31.Text = "grpString31";
			// 
			// txtLabelforString31
			// 
			this.txtLabelforString31.BackColor = System.Drawing.SystemColors.Window;
			this.txtLabelforString31.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtLabelforString31.Location = new System.Drawing.Point(15, 21);
			this.txtLabelforString31.Name = "txtLabelforString31";
			this.txtLabelforString31.ReadOnly = true;
			this.txtLabelforString31.Size = new System.Drawing.Size(240, 13);
			this.txtLabelforString31.TabIndex = 14;
			this.txtLabelforString31.TabStop = false;
			this.txtLabelforString31.Tag = "invoiceadditionalfields.labelfield3str";
			this.txtLabelforString31.Text = "LabelforString31";
			this.txtLabelforString31.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtFieldString3
			// 
			this.txtFieldString3.Location = new System.Drawing.Point(261, 18);
			this.txtFieldString3.Multiline = true;
			this.txtFieldString3.Name = "txtFieldString3";
			this.txtFieldString3.Size = new System.Drawing.Size(255, 22);
			this.txtFieldString3.TabIndex = 5;
			this.txtFieldString3.Tag = "invoiceadditionalfields.valuefield3str";
			// 
			// grpString21
			// 
			this.grpString21.Controls.Add(this.pictureBoxString21);
			this.grpString21.Controls.Add(this.txtLabelforString21);
			this.grpString21.Controls.Add(this.txtFieldString2);
			this.grpString21.Location = new System.Drawing.Point(12, 184);
			this.grpString21.Name = "grpString21";
			this.grpString21.Size = new System.Drawing.Size(484, 51);
			this.grpString21.TabIndex = 20;
			this.grpString21.TabStop = false;
			this.grpString21.Text = "grpString21";
			// 
			// txtLabelforString21
			// 
			this.txtLabelforString21.BackColor = System.Drawing.SystemColors.Window;
			this.txtLabelforString21.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtLabelforString21.Location = new System.Drawing.Point(12, 26);
			this.txtLabelforString21.Name = "txtLabelforString21";
			this.txtLabelforString21.ReadOnly = true;
			this.txtLabelforString21.Size = new System.Drawing.Size(243, 13);
			this.txtLabelforString21.TabIndex = 13;
			this.txtLabelforString21.TabStop = false;
			this.txtLabelforString21.Tag = "invoiceadditionalfields.labelfield2str";
			this.txtLabelforString21.Text = "LabelforString21";
			this.txtLabelforString21.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtFieldString2
			// 
			this.txtFieldString2.Location = new System.Drawing.Point(265, 23);
			this.txtFieldString2.Name = "txtFieldString2";
			this.txtFieldString2.Size = new System.Drawing.Size(185, 20);
			this.txtFieldString2.TabIndex = 4;
			this.txtFieldString2.Tag = "invoiceadditionalfields.valuefield2str";
			// 
			// grpString11
			// 
			this.grpString11.Controls.Add(this.pictureBoxString11);
			this.grpString11.Controls.Add(this.txtLabelforString11);
			this.grpString11.Controls.Add(this.txtFieldString1);
			this.grpString11.Location = new System.Drawing.Point(9, 73);
			this.grpString11.Name = "grpString11";
			this.grpString11.Size = new System.Drawing.Size(487, 56);
			this.grpString11.TabIndex = 18;
			this.grpString11.TabStop = false;
			this.grpString11.Text = "grpString11";
			// 
			// txtLabelforString11
			// 
			this.txtLabelforString11.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.txtLabelforString11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtLabelforString11.Location = new System.Drawing.Point(9, 25);
			this.txtLabelforString11.Name = "txtLabelforString11";
			this.txtLabelforString11.ReadOnly = true;
			this.txtLabelforString11.Size = new System.Drawing.Size(248, 13);
			this.txtLabelforString11.TabIndex = 16;
			this.txtLabelforString11.TabStop = false;
			this.txtLabelforString11.Tag = "invoiceadditionalfields.labelfield1str";
			this.txtLabelforString11.Text = "LabelforString11";
			this.txtLabelforString11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtFieldString1
			// 
			this.txtFieldString1.Location = new System.Drawing.Point(267, 19);
			this.txtFieldString1.Name = "txtFieldString1";
			this.txtFieldString1.Size = new System.Drawing.Size(186, 20);
			this.txtFieldString1.TabIndex = 2;
			this.txtFieldString1.Tag = "invoiceadditionalfields.valuefield1str";
			// 
			// grpDate11
			// 
			this.grpDate11.Controls.Add(this.pictureBoxDate11);
			this.grpDate11.Controls.Add(this.txtLabelforDate11);
			this.grpDate11.Controls.Add(this.txtFieldDate1);
			this.grpDate11.Location = new System.Drawing.Point(11, 135);
			this.grpDate11.Name = "grpDate11";
			this.grpDate11.Size = new System.Drawing.Size(485, 43);
			this.grpDate11.TabIndex = 19;
			this.grpDate11.TabStop = false;
			this.grpDate11.Text = "grpDate11";
			// 
			// txtLabelforDate11
			// 
			this.txtLabelforDate11.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.txtLabelforDate11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtLabelforDate11.Location = new System.Drawing.Point(21, 15);
			this.txtLabelforDate11.Name = "txtLabelforDate11";
			this.txtLabelforDate11.ReadOnly = true;
			this.txtLabelforDate11.Size = new System.Drawing.Size(234, 13);
			this.txtLabelforDate11.TabIndex = 12;
			this.txtLabelforDate11.TabStop = false;
			this.txtLabelforDate11.Tag = "invoiceadditionalfields.labelfield1date";
			this.txtLabelforDate11.Text = "LabelforDate11";
			this.txtLabelforDate11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtFieldDate1
			// 
			this.txtFieldDate1.Location = new System.Drawing.Point(265, 12);
			this.txtFieldDate1.Name = "txtFieldDate1";
			this.txtFieldDate1.Size = new System.Drawing.Size(186, 20);
			this.txtFieldDate1.TabIndex = 3;
			this.txtFieldDate1.Tag = "invoiceadditionalfields.valuefield1date";
			// 
			// grpInt11
			// 
			this.grpInt11.Controls.Add(this.pictureBoxInt11);
			this.grpInt11.Controls.Add(this.txtFieldInt1);
			this.grpInt11.Controls.Add(this.txtLabelforInt11);
			this.grpInt11.Location = new System.Drawing.Point(11, 20);
			this.grpInt11.Name = "grpInt11";
			this.grpInt11.Size = new System.Drawing.Size(485, 47);
			this.grpInt11.TabIndex = 17;
			this.grpInt11.TabStop = false;
			this.grpInt11.Text = "grpInt11";
			// 
			// txtFieldInt1
			// 
			this.txtFieldInt1.Location = new System.Drawing.Point(265, 19);
			this.txtFieldInt1.Name = "txtFieldInt1";
			this.txtFieldInt1.Size = new System.Drawing.Size(186, 20);
			this.txtFieldInt1.TabIndex = 1;
			this.txtFieldInt1.Tag = "invoiceadditionalfields.valuefield1int";
			// 
			// txtLabelforInt11
			// 
			this.txtLabelforInt11.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.txtLabelforInt11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtLabelforInt11.Location = new System.Drawing.Point(8, 23);
			this.txtLabelforInt11.Name = "txtLabelforInt11";
			this.txtLabelforInt11.ReadOnly = true;
			this.txtLabelforInt11.Size = new System.Drawing.Size(247, 13);
			this.txtLabelforInt11.TabIndex = 0;
			this.txtLabelforInt11.TabStop = false;
			this.txtLabelforInt11.Tag = "invoiceadditionalfields.labelfield1int";
			this.txtLabelforInt11.Text = "LabelforInt11";
			this.txtLabelforInt11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tabControlCampi
			// 
			this.tabControlCampi.Controls.Add(this.tabPage1);
			this.tabControlCampi.Location = new System.Drawing.Point(12, 58);
			this.tabControlCampi.Name = "tabControlCampi";
			this.tabControlCampi.SelectedIndex = 0;
			this.tabControlCampi.ShowToolTips = true;
			this.tabControlCampi.Size = new System.Drawing.Size(603, 386);
			this.tabControlCampi.TabIndex = 15;
			this.tabControlCampi.TabStop = false;
			// 
			// grpTabName
			// 
			this.grpTabName.Controls.Add(this.rdbTabname4);
			this.grpTabName.Controls.Add(this.rdbTabname3);
			this.grpTabName.Controls.Add(this.rdbTabname2);
			this.grpTabName.Controls.Add(this.rdbTabname1);
			this.grpTabName.Location = new System.Drawing.Point(16, 12);
			this.grpTabName.Name = "grpTabName";
			this.grpTabName.Size = new System.Drawing.Size(595, 40);
			this.grpTabName.TabIndex = 16;
			this.grpTabName.TabStop = false;
			this.grpTabName.Text = "Sezione";
			// 
			// rdbTabname4
			// 
			this.rdbTabname4.AutoSize = true;
			this.rdbTabname4.Location = new System.Drawing.Point(401, 17);
			this.rdbTabname4.Name = "rdbTabname4";
			this.rdbTabname4.Size = new System.Drawing.Size(91, 17);
			this.rdbTabname4.TabIndex = 3;
			this.rdbTabname4.Text = "rdbTabname4";
			this.rdbTabname4.UseVisualStyleBackColor = true;
			// 
			// rdbTabname3
			// 
			this.rdbTabname3.AutoSize = true;
			this.rdbTabname3.Location = new System.Drawing.Point(271, 17);
			this.rdbTabname3.Name = "rdbTabname3";
			this.rdbTabname3.Size = new System.Drawing.Size(91, 17);
			this.rdbTabname3.TabIndex = 2;
			this.rdbTabname3.Text = "rdbTabname3";
			this.rdbTabname3.UseVisualStyleBackColor = true;
			// 
			// rdbTabname2
			// 
			this.rdbTabname2.AutoSize = true;
			this.rdbTabname2.Location = new System.Drawing.Point(145, 17);
			this.rdbTabname2.Name = "rdbTabname2";
			this.rdbTabname2.Size = new System.Drawing.Size(91, 17);
			this.rdbTabname2.TabIndex = 1;
			this.rdbTabname2.Text = "rdbTabname2";
			this.rdbTabname2.UseVisualStyleBackColor = true;
			this.rdbTabname2.CheckedChanged += new System.EventHandler(this.rdbTabname2_CheckedChanged);
			// 
			// rdbTabname1
			// 
			this.rdbTabname1.AutoSize = true;
			this.rdbTabname1.Checked = true;
			this.rdbTabname1.Location = new System.Drawing.Point(18, 17);
			this.rdbTabname1.Name = "rdbTabname1";
			this.rdbTabname1.Size = new System.Drawing.Size(91, 17);
			this.rdbTabname1.TabIndex = 0;
			this.rdbTabname1.TabStop = true;
			this.rdbTabname1.Text = "rdbTabname1";
			this.rdbTabname1.UseVisualStyleBackColor = true;
			this.rdbTabname1.CheckedChanged += new System.EventHandler(this.rdbTabname1_CheckedChanged);
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			// 
			// pictureBoxString21
			// 
			this.pictureBoxString21.Image = global::invoiceadditionalfields_detail.Resources.icons8_help_16;
			this.pictureBoxString21.Location = new System.Drawing.Point(460, 24);
			this.pictureBoxString21.Name = "pictureBoxString21";
			this.pictureBoxString21.Size = new System.Drawing.Size(18, 17);
			this.pictureBoxString21.TabIndex = 23;
			this.pictureBoxString21.TabStop = false;
			this.pictureBoxString21.Visible = false;
			// 
			// pictureBoxString11
			// 
			this.pictureBoxString11.Image = global::invoiceadditionalfields_detail.Resources.icons8_help_16;
			this.pictureBoxString11.Location = new System.Drawing.Point(463, 22);
			this.pictureBoxString11.Name = "pictureBoxString11";
			this.pictureBoxString11.Size = new System.Drawing.Size(18, 17);
			this.pictureBoxString11.TabIndex = 23;
			this.pictureBoxString11.TabStop = false;
			this.pictureBoxString11.Visible = false;
			// 
			// pictureBoxDate11
			// 
			this.pictureBoxDate11.Image = global::invoiceadditionalfields_detail.Resources.icons8_help_16;
			this.pictureBoxDate11.Location = new System.Drawing.Point(461, 15);
			this.pictureBoxDate11.Name = "pictureBoxDate11";
			this.pictureBoxDate11.Size = new System.Drawing.Size(18, 17);
			this.pictureBoxDate11.TabIndex = 23;
			this.pictureBoxDate11.TabStop = false;
			this.pictureBoxDate11.Visible = false;
			// 
			// pictureBoxInt11
			// 
			this.pictureBoxInt11.Image = global::invoiceadditionalfields_detail.Resources.icons8_help_16;
			this.pictureBoxInt11.Location = new System.Drawing.Point(461, 19);
			this.pictureBoxInt11.Name = "pictureBoxInt11";
			this.pictureBoxInt11.Size = new System.Drawing.Size(18, 17);
			this.pictureBoxInt11.TabIndex = 22;
			this.pictureBoxInt11.TabStop = false;
			this.pictureBoxInt11.Visible = false;
			// 
			// pictureBoxString31
			// 
			this.pictureBoxString31.Image = global::invoiceadditionalfields_detail.Resources.icons8_help_16;
			this.pictureBoxString31.Location = new System.Drawing.Point(528, 21);
			this.pictureBoxString31.Name = "pictureBoxString31";
			this.pictureBoxString31.Size = new System.Drawing.Size(18, 17);
			this.pictureBoxString31.TabIndex = 24;
			this.pictureBoxString31.TabStop = false;
			this.pictureBoxString31.Visible = false;
			// 
			// Frm_invoiceadditionalfields_detail
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(627, 501);
			this.Controls.Add(this.grpTabName);
			this.Controls.Add(this.tabControlCampi);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnOK);
			this.Name = "Frm_invoiceadditionalfields_detail";
			this.Text = "Frm_invoiceadditionalfields_detail";
			this.tabPage1.ResumeLayout(false);
			this.grpTabName1.ResumeLayout(false);
			this.grpString31.ResumeLayout(false);
			this.grpString31.PerformLayout();
			this.grpString21.ResumeLayout(false);
			this.grpString21.PerformLayout();
			this.grpString11.ResumeLayout(false);
			this.grpString11.PerformLayout();
			this.grpDate11.ResumeLayout(false);
			this.grpDate11.PerformLayout();
			this.grpInt11.ResumeLayout(false);
			this.grpInt11.PerformLayout();
			this.tabControlCampi.ResumeLayout(false);
			this.grpTabName.ResumeLayout(false);
			this.grpTabName.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxString21)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxString11)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDate11)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxInt11)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxString31)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		public vistaForm DS;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.GroupBox grpTabName1;
		private System.Windows.Forms.GroupBox grpString31;
		private System.Windows.Forms.TextBox txtLabelforString31;
		private System.Windows.Forms.TextBox txtFieldString3;
		private System.Windows.Forms.GroupBox grpString21;
		private System.Windows.Forms.TextBox txtLabelforString21;
		private System.Windows.Forms.TextBox txtFieldString2;
		private System.Windows.Forms.GroupBox grpDate11;
		private System.Windows.Forms.TextBox txtLabelforDate11;
		private System.Windows.Forms.TextBox txtFieldDate1;
		private System.Windows.Forms.GroupBox grpInt11;
		private System.Windows.Forms.TextBox txtFieldInt1;
		private System.Windows.Forms.TextBox txtLabelforInt11;
		private System.Windows.Forms.TabControl tabControlCampi;
		private System.Windows.Forms.GroupBox grpTabName;
		private System.Windows.Forms.RadioButton rdbTabname4;
		private System.Windows.Forms.RadioButton rdbTabname3;
		private System.Windows.Forms.RadioButton rdbTabname2;
		private System.Windows.Forms.RadioButton rdbTabname1;
		private System.Windows.Forms.GroupBox grpString11;
		private System.Windows.Forms.TextBox txtLabelforString11;
		private System.Windows.Forms.TextBox txtFieldString1;
		private System.Windows.Forms.PictureBox pictureBoxInt11;
		private System.Windows.Forms.PictureBox pictureBoxString21;
		private System.Windows.Forms.PictureBox pictureBoxString11;
		private System.Windows.Forms.PictureBox pictureBoxDate11;
		private System.Windows.Forms.PictureBox pictureBoxString31;
	}
}