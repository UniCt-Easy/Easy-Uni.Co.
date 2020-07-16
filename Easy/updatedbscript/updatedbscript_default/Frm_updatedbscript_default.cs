/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

namespace updatedbscript_default//updatedbscript//
{
	/// <summary>
	/// Summary description for frmUpdatedbscript.
	/// </summary>
	public class Frm_updatedbscript_default : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtScriptname;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.TextBox txtTestoscript;
		private System.Windows.Forms.TextBox txtVersione;
		private System.Windows.Forms.Button btnAnnulla;
		public /*Rana:updatedbscript.*/vistaForm DS;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private MetaData Meta;

		public Frm_updatedbscript_default()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtScriptname = new System.Windows.Forms.TextBox();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.txtTestoscript = new System.Windows.Forms.TextBox();
			this.txtVersione = new System.Windows.Forms.TextBox();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.DS = new /*Rana:updatedbscript.*/vistaForm();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(104, 18);
			this.label5.TabIndex = 18;
			this.label5.Text = "Versione Database";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(264, 25);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(104, 16);
			this.label4.TabIndex = 17;
			this.label4.Text = "Nome dello script";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 296);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 16);
			this.label3.TabIndex = 16;
			this.label3.Text = "Risultato";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 16);
			this.label1.TabIndex = 15;
			this.label1.Text = "Testo script";
			// 
			// txtScriptname
			// 
			this.txtScriptname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtScriptname.Location = new System.Drawing.Point(376, 23);
			this.txtScriptname.Name = "txtScriptname";
			this.txtScriptname.ReadOnly = true;
			this.txtScriptname.Size = new System.Drawing.Size(344, 20);
			this.txtScriptname.TabIndex = 2;
			this.txtScriptname.Tag = "updatedbscript.scriptname";
			this.txtScriptname.Text = "";
			// 
			// txtDescription
			// 
			this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescription.Location = new System.Drawing.Point(120, 296);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.ReadOnly = true;
			this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDescription.Size = new System.Drawing.Size(600, 192);
			this.txtDescription.TabIndex = 4;
			this.txtDescription.Tag = "updatedbscript.result";
			this.txtDescription.Text = "";
			// 
			// txtTestoscript
			// 
			this.txtTestoscript.AcceptsReturn = true;
			this.txtTestoscript.AcceptsTab = true;
			this.txtTestoscript.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtTestoscript.Location = new System.Drawing.Point(120, 48);
			this.txtTestoscript.Multiline = true;
			this.txtTestoscript.Name = "txtTestoscript";
			this.txtTestoscript.ReadOnly = true;
			this.txtTestoscript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtTestoscript.Size = new System.Drawing.Size(600, 232);
			this.txtTestoscript.TabIndex = 3;
			this.txtTestoscript.Tag = "";
			this.txtTestoscript.Text = "";
			// 
			// txtVersione
			// 
			this.txtVersione.Location = new System.Drawing.Point(120, 23);
			this.txtVersione.Name = "txtVersione";
			this.txtVersione.ReadOnly = true;
			this.txtVersione.TabIndex = 1;
			this.txtVersione.Tag = "updatedbscript.versionname";
			this.txtVersione.Text = "";
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(600, 504);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(88, 24);
			this.btnAnnulla.TabIndex = 6;
			this.btnAnnulla.Text = "Chiudi";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// frmUpdatedbscript
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnAnnulla;
			this.ClientSize = new System.Drawing.Size(730, 551);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtScriptname);
			this.Controls.Add(this.txtDescription);
			this.Controls.Add(this.txtTestoscript);
			this.Controls.Add(this.txtVersione);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "frmUpdatedbscript";
			this.Text = "frmUpdatedbscript";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public void MetaData_AfterLink() {
			Meta=MetaData.GetMetaData(this);
		}
		public void MetaData_AfterFill() {
			if (Meta.IsEmpty) return;
			txtTestoscript.Text=QueryCreator.GetPrintable(DS.updatedbscript.Rows[0]["sql"].ToString());
		}
	}
}
