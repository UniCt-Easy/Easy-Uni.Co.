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

namespace columntypes//columntypes//
{
	/// <summary>
	/// Summary description for frmColumnTypes.
	/// </summary>
	public class Frm_columntypes : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Button CancButton;
		private System.Windows.Forms.Button OkButton;
		public /*Rana:columntypes.*/vistaForm DS;
		private System.Windows.Forms.CheckBox checkBox3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_columntypes()
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
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.CancButton = new System.Windows.Forms.Button();
			this.OkButton = new System.Windows.Forms.Button();
			this.DS = new /*Rana:columntypes.*/vistaForm();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 16);
			this.label1.TabIndex = 0;
			this.label1.Tag = "";
			this.label1.Text = "tablename";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(112, 24);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(168, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.Tag = "columntypes.tablename";
			this.textBox1.Text = "";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(112, 48);
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(168, 20);
			this.textBox2.TabIndex = 3;
			this.textBox2.Tag = "columntypes.field";
			this.textBox2.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(32, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 2;
			this.label2.Tag = "";
			this.label2.Text = "field";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// checkBox1
			// 
			this.checkBox1.Enabled = false;
			this.checkBox1.Location = new System.Drawing.Point(112, 72);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(168, 24);
			this.checkBox1.TabIndex = 4;
			this.checkBox1.Tag = "columntypes.iskey:S:N";
			this.checkBox1.Text = "Primary Key";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(32, 104);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "Sql Type";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(112, 104);
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(168, 20);
			this.textBox3.TabIndex = 6;
			this.textBox3.Tag = "columntypes.sqltype";
			this.textBox3.Text = "";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(112, 128);
			this.textBox4.Name = "textBox4";
			this.textBox4.ReadOnly = true;
			this.textBox4.Size = new System.Drawing.Size(56, 20);
			this.textBox4.TabIndex = 8;
			this.textBox4.Tag = "columntypes.col_len";
			this.textBox4.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(32, 128);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 16);
			this.label4.TabIndex = 7;
			this.label4.Text = "Col size";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(112, 152);
			this.textBox5.Name = "textBox5";
			this.textBox5.ReadOnly = true;
			this.textBox5.Size = new System.Drawing.Size(56, 20);
			this.textBox5.TabIndex = 10;
			this.textBox5.Tag = "columntypes.col_precision";
			this.textBox5.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(32, 152);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 16);
			this.label5.TabIndex = 9;
			this.label5.Text = "Col precision";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(112, 176);
			this.textBox6.Name = "textBox6";
			this.textBox6.ReadOnly = true;
			this.textBox6.Size = new System.Drawing.Size(56, 20);
			this.textBox6.TabIndex = 12;
			this.textBox6.Tag = "columntypes.col_scale";
			this.textBox6.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(32, 176);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(72, 16);
			this.label6.TabIndex = 11;
			this.label6.Text = "Col scale";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(112, 208);
			this.textBox7.Name = "textBox7";
			this.textBox7.ReadOnly = true;
			this.textBox7.Size = new System.Drawing.Size(168, 20);
			this.textBox7.TabIndex = 14;
			this.textBox7.Tag = "columntypes.systemtype";
			this.textBox7.Text = "";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(32, 208);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(72, 16);
			this.label7.TabIndex = 13;
			this.label7.Text = "System Type";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(112, 232);
			this.textBox8.Name = "textBox8";
			this.textBox8.ReadOnly = true;
			this.textBox8.Size = new System.Drawing.Size(168, 20);
			this.textBox8.TabIndex = 16;
			this.textBox8.Tag = "columntypes.sqldeclaration";
			this.textBox8.Text = "";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(16, 232);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(88, 16);
			this.label8.TabIndex = 15;
			this.label8.Text = "SQL Declaration";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// checkBox2
			// 
			this.checkBox2.Enabled = false;
			this.checkBox2.Location = new System.Drawing.Point(112, 256);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(168, 24);
			this.checkBox2.TabIndex = 17;
			this.checkBox2.Tag = "columntypes.allownull:S:N";
			this.checkBox2.Text = "Allow Null";
			// 
			// textBox9
			// 
			this.textBox9.Location = new System.Drawing.Point(112, 280);
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new System.Drawing.Size(168, 20);
			this.textBox9.TabIndex = 19;
			this.textBox9.Tag = "columntypes.defaultvalue";
			this.textBox9.Text = "";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(32, 280);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(72, 16);
			this.label9.TabIndex = 18;
			this.label9.Text = "Default value";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox10
			// 
			this.textBox10.Location = new System.Drawing.Point(112, 304);
			this.textBox10.Name = "textBox10";
			this.textBox10.Size = new System.Drawing.Size(168, 20);
			this.textBox10.TabIndex = 21;
			this.textBox10.Tag = "columntypes.format";
			this.textBox10.Text = "";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(32, 304);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(72, 16);
			this.label10.TabIndex = 20;
			this.label10.Text = "Format";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// CancButton
			// 
			this.CancButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancButton.Location = new System.Drawing.Point(64, 376);
			this.CancButton.Name = "CancButton";
			this.CancButton.TabIndex = 23;
			this.CancButton.Text = "Cancel";
			// 
			// OkButton
			// 
			this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OkButton.Location = new System.Drawing.Point(176, 376);
			this.OkButton.Name = "OkButton";
			this.OkButton.TabIndex = 22;
			this.OkButton.Tag = "mainsave";
			this.OkButton.Text = "Ok";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			this.DS.Namespace = "http://tempuri.org/vistaForm.xsd";
			// 
			// checkBox3
			// 
			this.checkBox3.Location = new System.Drawing.Point(112, 336);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(168, 24);
			this.checkBox3.TabIndex = 24;
			this.checkBox3.Tag = "columntypes.denynull:S:N";
			this.checkBox3.Text = "Deny Null";
			// 
			// frmColumnTypes
			// 
			this.AcceptButton = this.OkButton;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.CancButton;
			this.ClientSize = new System.Drawing.Size(320, 421);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.checkBox3,
																		  this.CancButton,
																		  this.OkButton,
																		  this.textBox10,
																		  this.label10,
																		  this.textBox9,
																		  this.label9,
																		  this.checkBox2,
																		  this.textBox8,
																		  this.label8,
																		  this.textBox7,
																		  this.label7,
																		  this.textBox6,
																		  this.label6,
																		  this.textBox5,
																		  this.label5,
																		  this.textBox4,
																		  this.label4,
																		  this.textBox3,
																		  this.label3,
																		  this.checkBox1,
																		  this.textBox2,
																		  this.label2,
																		  this.textBox1,
																		  this.label1});
			this.Name = "frmColumnTypes";
			this.Tag = "";
			this.Text = "frmColumnTypes";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
	}
}
