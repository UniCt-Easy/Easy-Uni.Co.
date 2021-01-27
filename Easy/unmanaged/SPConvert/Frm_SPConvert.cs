
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using dbbridge;//dbbridge
using metadatalibrary;

namespace SPConvert//SPConvert//
{
	/// <summary>
	/// Summary description for frmSPConvert.
	/// </summary>
	public class frmSPConvert : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnConverti;
		DataAccess Conn;
		public System.Windows.Forms.TextBox txtToConvert;
		public System.Windows.Forms.TextBox txtConverted;
		private System.Windows.Forms.CheckBox chkRuleEnforcement;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSPConvert(DataAccess Conn)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.Conn= Conn;
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
			this.txtToConvert = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtConverted = new System.Windows.Forms.TextBox();
			this.btnConverti = new System.Windows.Forms.Button();
			this.chkRuleEnforcement = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// txtToConvert
			// 
			this.txtToConvert.AcceptsReturn = true;
			this.txtToConvert.AcceptsTab = true;
			this.txtToConvert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.txtToConvert.Location = new System.Drawing.Point(25, 41);
			this.txtToConvert.Multiline = true;
			this.txtToConvert.Name = "txtToConvert";
			this.txtToConvert.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtToConvert.Size = new System.Drawing.Size(427, 541);
			this.txtToConvert.TabIndex = 0;
			this.txtToConvert.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(27, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(273, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "SP DA CONVERTIRE";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(472, 17);
			this.label2.Name = "label2";
			this.label2.TabIndex = 2;
			this.label2.Text = "SP convertita";
			// 
			// txtConverted
			// 
			this.txtConverted.AcceptsReturn = true;
			this.txtConverted.AcceptsTab = true;
			this.txtConverted.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtConverted.Location = new System.Drawing.Point(472, 42);
			this.txtConverted.Multiline = true;
			this.txtConverted.Name = "txtConverted";
			this.txtConverted.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtConverted.Size = new System.Drawing.Size(426, 541);
			this.txtConverted.TabIndex = 3;
			this.txtConverted.Text = "";
			// 
			// btnConverti
			// 
			this.btnConverti.Location = new System.Drawing.Point(363, 11);
			this.btnConverti.Name = "btnConverti";
			this.btnConverti.TabIndex = 4;
			this.btnConverti.Text = "Converti";
			this.btnConverti.Click += new System.EventHandler(this.btnConverti_Click);
			// 
			// chkRuleEnforcement
			// 
			this.chkRuleEnforcement.Location = new System.Drawing.Point(589, 6);
			this.chkRuleEnforcement.Name = "chkRuleEnforcement";
			this.chkRuleEnforcement.Size = new System.Drawing.Size(167, 24);
			this.chkRuleEnforcement.TabIndex = 5;
			this.chkRuleEnforcement.Text = "Converti RuleEnforcement";
			// 
			// frmSPConvert
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(910, 618);
			this.Controls.Add(this.chkRuleEnforcement);
			this.Controls.Add(this.btnConverti);
			this.Controls.Add(this.txtConverted);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtToConvert);
			this.Name = "frmSPConvert";
			this.Text = "frmSPConvert";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnConverti_Click(object sender, System.EventArgs e) {
			DBBridge DBB = new DBBridge(Conn);
			DBB.Init(txtToConvert.Text);
			try {
				if (!chkRuleEnforcement.Checked)
					txtConverted.Text= DBBridge.Compile(Conn, txtToConvert.Text,null);
				else 
					txtConverted.Text= RuleBridge.CompileRuleEnforcement(Conn, txtToConvert.Text);
			}
			catch (Exception E){
				QueryCreator.ShowException(E);
			}
		}

	}
}
