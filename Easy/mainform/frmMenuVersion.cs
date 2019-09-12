/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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

namespace mainform//CompEc//
{
	/// <summary>
	/// Summary description for frmMenuVersion.
	/// </summary>
	public class frmMenuVersion : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtOldVersion;
		private System.Windows.Forms.TextBox txtNewVersion;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnAnnulla;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private string m_NewVersion = null;
		private string m_OldVersion = null;

		public frmMenuVersion(string oldversion)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			m_OldVersion = oldversion;
			txtOldVersion.Text=oldversion;
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
			this.label2 = new System.Windows.Forms.Label();
			this.txtOldVersion = new System.Windows.Forms.TextBox();
			this.txtNewVersion = new System.Windows.Forms.TextBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(35, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Versione corrente";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(35, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(120, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Nuova versione";
			// 
			// txtOldVersion
			// 
			this.txtOldVersion.Location = new System.Drawing.Point(163, 24);
			this.txtOldVersion.Name = "txtOldVersion";
			this.txtOldVersion.ReadOnly = true;
			this.txtOldVersion.TabIndex = 2;
			this.txtOldVersion.Text = "";
			// 
			// txtNewVersion
			// 
			this.txtNewVersion.Location = new System.Drawing.Point(163, 56);
			this.txtNewVersion.Name = "txtNewVersion";
			this.txtNewVersion.TabIndex = 3;
			this.txtNewVersion.Text = "";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(68, 104);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(156, 104);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.TabIndex = 5;
			this.btnAnnulla.Text = "Annulla";
			// 
			// frmMenuVersion
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnAnnulla;
			this.ClientSize = new System.Drawing.Size(298, 151);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.txtNewVersion);
			this.Controls.Add(this.txtOldVersion);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmMenuVersion";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Aggiornamento Versione Menu";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e) {
			if (txtNewVersion.Text.Trim()=="") {
				MessageBox.Show("Inserire la nuova versione", "Attenzione",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if (txtOldVersion.Text.CompareTo(txtNewVersion.Text)>0) {
				MessageBox.Show("La nuova versione deve essere maggiore di quella corrente", "Attenzione",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if (txtOldVersion.Text.Trim()==txtNewVersion.Text.Trim()) {
				if (MessageBox.Show("Vuoi mantenere la stessa versione?", "Versione",
					MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)!=DialogResult.Yes)
				return;
			}
			m_NewVersion=txtNewVersion.Text.Trim();
			this.DialogResult=DialogResult.OK;
		}

		public string NewVersion {
			get {
				return m_NewVersion; 
			}
		}
	}
}
