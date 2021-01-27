
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
using metadatalibrary;
using System.Data;

namespace customviewcolumn//customviewcolumn//
{
	/// <summary>
	/// Summary description for frmCustomViewColumn.
	/// </summary>
	public class Frm_customviewcolumn : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label3;
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
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.CheckBox checkBox4;
		private System.Windows.Forms.CheckBox checkBox5;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBox11;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Button BtnOk;
		private System.Windows.Forms.Button BtnCancel;
		public /*Rana:customviewcolumn.*/vistaForm DS;
		private System.Windows.Forms.CheckBox chkIsVisible;
		private System.Windows.Forms.CheckBox chkIsReal;
		private System.Windows.Forms.ComboBox cmbColumnName;
		private System.Windows.Forms.TextBox txtExtraName;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox txtSystemType;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_customviewcolumn()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public void MetaData_AfterLink(){
			DataRow Curr =MetaData.GetMetaData(this).SourceRow;
			GetData.SetStaticFilter(DS.columntypes,
				"(tablename='"+Curr["objectname"].ToString()+"')");
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

		public void MetaData_AfterFill(){
			SetColumnNameControls();
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
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.chkIsVisible = new System.Windows.Forms.CheckBox();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.checkBox5 = new System.Windows.Forms.CheckBox();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.chkIsReal = new System.Windows.Forms.CheckBox();
			this.textBox11 = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.BtnOk = new System.Windows.Forms.Button();
			this.BtnCancel = new System.Windows.Forms.Button();
			this.DS = new /*Rana:customviewcolumn.*/vistaForm();
			this.cmbColumnName = new System.Windows.Forms.ComboBox();
			this.txtExtraName = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.txtSystemType = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			this.label1.Text = "Object Name";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(128, 24);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(176, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.Tag = "customviewcolumn.objectname";
			this.textBox1.Text = "";
			this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(128, 48);
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(176, 20);
			this.textBox2.TabIndex = 3;
			this.textBox2.Tag = "customviewcolumn.viewname";
			this.textBox2.Text = "";
			this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 48);
			this.label2.Name = "label2";
			this.label2.TabIndex = 2;
			this.label2.Text = "View Name";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(128, 72);
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(72, 20);
			this.textBox3.TabIndex = 5;
			this.textBox3.Tag = "customviewcolumn.colnumber";
			this.textBox3.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 72);
			this.label3.Name = "label3";
			this.label3.TabIndex = 4;
			this.label3.Text = "Col number";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 96);
			this.label4.Name = "label4";
			this.label4.TabIndex = 6;
			this.label4.Text = "Column Name";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(128, 184);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(176, 20);
			this.textBox5.TabIndex = 9;
			this.textBox5.Tag = "customviewcolumn.heading";
			this.textBox5.Text = "";
			this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 184);
			this.label5.Name = "label5";
			this.label5.TabIndex = 8;
			this.label5.Text = "Heading";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(128, 416);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(72, 20);
			this.textBox6.TabIndex = 11;
			this.textBox6.Tag = "customviewcolumn.colwidth";
			this.textBox6.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(16, 416);
			this.label6.Name = "label6";
			this.label6.TabIndex = 10;
			this.label6.Text = "Col Width";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// chkIsVisible
			// 
			this.chkIsVisible.Location = new System.Drawing.Point(16, 208);
			this.chkIsVisible.Name = "chkIsVisible";
			this.chkIsVisible.Size = new System.Drawing.Size(128, 24);
			this.chkIsVisible.TabIndex = 12;
			this.chkIsVisible.Tag = "customviewcolumn.visible:1:0";
			this.chkIsVisible.Text = "Visible";
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(128, 344);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(128, 20);
			this.textBox7.TabIndex = 14;
			this.textBox7.Tag = "customviewcolumn.fontname";
			this.textBox7.Text = "";
			this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(16, 344);
			this.label7.Name = "label7";
			this.label7.TabIndex = 13;
			this.label7.Text = "Font Name";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(128, 368);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(128, 20);
			this.textBox8.TabIndex = 16;
			this.textBox8.Tag = "customviewcolumn.fontsize";
			this.textBox8.Text = "";
			this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(16, 368);
			this.label8.Name = "label8";
			this.label8.TabIndex = 15;
			this.label8.Text = "Font Size";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// checkBox2
			// 
			this.checkBox2.Location = new System.Drawing.Point(272, 344);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(128, 24);
			this.checkBox2.TabIndex = 17;
			this.checkBox2.Tag = "customviewcolumn.bold:1:0";
			this.checkBox2.Text = "Bold";
			// 
			// checkBox3
			// 
			this.checkBox3.Location = new System.Drawing.Point(272, 368);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(128, 24);
			this.checkBox3.TabIndex = 18;
			this.checkBox3.Tag = "customviewcolumn.italic:1:0";
			this.checkBox3.Text = "Italic";
			// 
			// checkBox4
			// 
			this.checkBox4.Location = new System.Drawing.Point(272, 392);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(128, 24);
			this.checkBox4.TabIndex = 19;
			this.checkBox4.Tag = "customviewcolumn.underline:1:0";
			this.checkBox4.Text = "Underline";
			// 
			// checkBox5
			// 
			this.checkBox5.Location = new System.Drawing.Point(272, 416);
			this.checkBox5.Name = "checkBox5";
			this.checkBox5.Size = new System.Drawing.Size(128, 24);
			this.checkBox5.TabIndex = 20;
			this.checkBox5.Tag = "customviewcolumn.strikeout:1:0";
			this.checkBox5.Text = "Strike Out";
			// 
			// textBox9
			// 
			this.textBox9.Location = new System.Drawing.Point(128, 392);
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new System.Drawing.Size(128, 20);
			this.textBox9.TabIndex = 22;
			this.textBox9.Tag = "customviewcolumn.color";
			this.textBox9.Text = "";
			this.textBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(16, 392);
			this.label9.Name = "label9";
			this.label9.TabIndex = 21;
			this.label9.Text = "Color";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox10
			// 
			this.textBox10.Location = new System.Drawing.Point(16, 256);
			this.textBox10.Name = "textBox10";
			this.textBox10.Size = new System.Drawing.Size(392, 20);
			this.textBox10.TabIndex = 24;
			this.textBox10.Tag = "customviewcolumn.format";
			this.textBox10.Text = "";
			this.textBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(16, 240);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(100, 16);
			this.label10.TabIndex = 23;
			this.label10.Text = "Format";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// chkIsReal
			// 
			this.chkIsReal.Location = new System.Drawing.Point(176, 208);
			this.chkIsReal.Name = "chkIsReal";
			this.chkIsReal.TabIndex = 25;
			this.chkIsReal.Tag = "customviewcolumn.isreal:S:N";
			this.chkIsReal.Text = "Is Real";
			this.chkIsReal.CheckStateChanged += new System.EventHandler(this.chkIsReal_CheckStateChanged);
			// 
			// textBox11
			// 
			this.textBox11.Location = new System.Drawing.Point(16, 296);
			this.textBox11.Multiline = true;
			this.textBox11.Name = "textBox11";
			this.textBox11.Size = new System.Drawing.Size(392, 32);
			this.textBox11.TabIndex = 27;
			this.textBox11.Tag = "customviewcolumn.expression";
			this.textBox11.Text = "";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(16, 280);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(100, 16);
			this.label11.TabIndex = 26;
			this.label11.Text = "Expression";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// BtnOk
			// 
			this.BtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.BtnOk.Location = new System.Drawing.Point(224, 448);
			this.BtnOk.Name = "BtnOk";
			this.BtnOk.Size = new System.Drawing.Size(88, 24);
			this.BtnOk.TabIndex = 28;
			this.BtnOk.Tag = "mainsave";
			this.BtnOk.Text = "Ok";
			// 
			// BtnCancel
			// 
			this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.BtnCancel.Location = new System.Drawing.Point(112, 448);
			this.BtnCancel.Name = "BtnCancel";
			this.BtnCancel.TabIndex = 29;
			this.BtnCancel.Text = "Cancel";
			// 
			// DS
			// 
			this.DS.DataSetName = "DS";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// cmbColumnName
			// 
			this.cmbColumnName.DataSource = this.DS.columntypes;
			this.cmbColumnName.DisplayMember = "field";
			this.cmbColumnName.Location = new System.Drawing.Point(128, 96);
			this.cmbColumnName.Name = "cmbColumnName";
			this.cmbColumnName.Size = new System.Drawing.Size(176, 21);
			this.cmbColumnName.TabIndex = 30;
			this.cmbColumnName.Tag = "customviewcolumn.colname";
			this.cmbColumnName.ValueMember = "field";
			// 
			// txtExtraName
			// 
			this.txtExtraName.Location = new System.Drawing.Point(128, 128);
			this.txtExtraName.Name = "txtExtraName";
			this.txtExtraName.Size = new System.Drawing.Size(176, 20);
			this.txtExtraName.TabIndex = 31;
			this.txtExtraName.Tag = "customviewcolumn.colname";
			this.txtExtraName.Text = "";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(8, 128);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(112, 23);
			this.label12.TabIndex = 32;
			this.label12.Text = "Extra Column Name";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(8, 160);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(112, 23);
			this.label13.TabIndex = 34;
			this.label13.Text = "System Type";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtSystemType
			// 
			this.txtSystemType.Location = new System.Drawing.Point(128, 160);
			this.txtSystemType.Name = "txtSystemType";
			this.txtSystemType.Size = new System.Drawing.Size(176, 20);
			this.txtSystemType.TabIndex = 33;
			this.txtSystemType.Tag = "customviewcolumn.systemtype";
			this.txtSystemType.Text = "";
			// 
			// frmCustomViewColumn
			// 
			this.AcceptButton = this.BtnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.BtnCancel;
			this.ClientSize = new System.Drawing.Size(424, 493);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.txtSystemType);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.txtExtraName);
			this.Controls.Add(this.cmbColumnName);
			this.Controls.Add(this.BtnCancel);
			this.Controls.Add(this.BtnOk);
			this.Controls.Add(this.textBox11);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.chkIsReal);
			this.Controls.Add(this.textBox10);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.textBox9);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.checkBox5);
			this.Controls.Add(this.checkBox4);
			this.Controls.Add(this.checkBox3);
			this.Controls.Add(this.checkBox2);
			this.Controls.Add(this.textBox8);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.textBox7);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.chkIsVisible);
			this.Controls.Add(this.textBox6);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.textBox5);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Name = "frmCustomViewColumn";
			this.Tag = "customviewcolumn.colname";
			this.Text = "frmCustomViewColumn";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		void SetColumnNameControls(){
			if (chkIsReal.Checked){
				txtExtraName.Visible=false;
				txtExtraName.Tag="";
				txtExtraName.Text="";
				cmbColumnName.Visible=true;
				cmbColumnName.Tag="customviewcolumn.colname";
				txtSystemType.Visible=false;
				txtSystemType.Tag="";
				txtSystemType.Text="";
			}
			else {
				txtExtraName.Visible=true;
				txtExtraName.Tag="customviewcolumn.colname";
				txtSystemType.Visible=true;
				txtSystemType.Tag="customviewcolumn.systemtype";
				cmbColumnName.Visible=false;
				cmbColumnName.Tag="";
			}
		}
		private void chkIsReal_CheckStateChanged(object sender, System.EventArgs e) {
			SetColumnNameControls();
		}
	}
}
