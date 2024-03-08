
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


using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;

namespace mainform//CompEc//
{
	/// <summary>
	/// Summary description for frmWait.
	/// </summary>
	public class frmWait : MetaDataForm
	{
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.TextBox txtDetail;
		private PictureBox pictureBox1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmWait()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.txtDetail = new System.Windows.Forms.TextBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(85, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(268, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Attendere, aggiornamento Database in corso";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDetail
			// 
			this.txtDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDetail.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.txtDetail.Location = new System.Drawing.Point(85, 30);
			this.txtDetail.Multiline = true;
			this.txtDetail.Name = "txtDetail";
			this.txtDetail.ReadOnly = true;
			this.txtDetail.Size = new System.Drawing.Size(259, 49);
			this.txtDetail.TabIndex = 2;
			this.txtDetail.TabStop = false;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::mainform.Properties.Resources.logo_64x64;
			this.pictureBox1.Location = new System.Drawing.Point(12, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(67, 67);
			this.pictureBox1.TabIndex = 3;
			this.pictureBox1.TabStop = false;
			// 
			// frmWait
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.ClientSize = new System.Drawing.Size(356, 99);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.txtDetail);
			this.Controls.Add(this.label1);
			this.ControlBox = true; // deve essere true
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.Name = "frmWait";
			this.ShowInTaskbar = true;
			this.MaximizeBox = false;
			this.MinimizeBox = true;
			this.TopMost = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private void pictureBox1_Click(object sender, EventArgs e) {

		}
	}
}
