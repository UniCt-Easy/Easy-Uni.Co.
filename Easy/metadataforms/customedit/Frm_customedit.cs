
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
using System.Data;
using metadatalibrary;

namespace customedit//customedit//
{
	/// <summary>
	/// Summary description for frmCustomEdit.
	/// </summary>
	public class Frm_customedit : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.OpenFileDialog DLLDialog;
		public /*Rana:customedit.*/vistaForm DS;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.CheckBox chkLIST;
		private System.Windows.Forms.CheckBox chkSTARTEMPTY;
		MetaData Meta;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button OkButton;
		private System.Windows.Forms.Button CancButton;
		private System.Windows.Forms.TextBox txtDLL;
		private System.Windows.Forms.CheckBox chkTREE;
		private System.Windows.Forms.CheckBox chkSearchEnabled;
		private System.Windows.Forms.ComboBox cmbListType;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_customedit()
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.DLLDialog = new System.Windows.Forms.OpenFileDialog();
			this.txtDLL = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.DS = new /*Rana:customedit.*/vistaForm();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.chkLIST = new System.Windows.Forms.CheckBox();
			this.chkSTARTEMPTY = new System.Windows.Forms.CheckBox();
			this.chkTREE = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cmbListType = new System.Windows.Forms.ComboBox();
			this.chkSearchEnabled = new System.Windows.Forms.CheckBox();
			this.OkButton = new System.Windows.Forms.Button();
			this.CancButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Object name = Table Name";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(168, 24);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(216, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.Tag = "customedit.objectname";
			this.textBox1.Text = "";
			this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(168, 48);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(216, 20);
			this.textBox2.TabIndex = 3;
			this.textBox2.Tag = "customedit.edittype";
			this.textBox2.Text = "";
			this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(144, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Edit Type";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 96);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(136, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "DLL";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// DLLDialog
			// 
			this.DLLDialog.Filter = "Dll files (*.dll)|";
			this.DLLDialog.Title = "Select DLL form file";
			// 
			// txtDLL
			// 
			this.txtDLL.Location = new System.Drawing.Point(168, 96);
			this.txtDLL.Name = "txtDLL";
			this.txtDLL.ReadOnly = true;
			this.txtDLL.Size = new System.Drawing.Size(216, 20);
			this.txtDLL.TabIndex = 5;
			this.txtDLL.Tag = "customedit.dllname";
			this.txtDLL.Text = "";
			this.txtDLL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(392, 96);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 24);
			this.button1.TabIndex = 6;
			this.button1.Text = "Select...";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			this.DS.Namespace = "http://tempuri.org/vistaForm.xsd";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(64, 136);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 16);
			this.label4.TabIndex = 7;
			this.label4.Text = "Form Title";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(168, 136);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(216, 20);
			this.textBox4.TabIndex = 8;
			this.textBox4.Tag = "customedit.caption";
			this.textBox4.Text = "";
			this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// chkLIST
			// 
			this.chkLIST.Location = new System.Drawing.Point(168, 160);
			this.chkLIST.Name = "chkLIST";
			this.chkLIST.Size = new System.Drawing.Size(216, 24);
			this.chkLIST.TabIndex = 9;
			this.chkLIST.Tag = "customedit.list:S:N";
			this.chkLIST.Text = "Is a LIST Form";
			this.chkLIST.CheckStateChanged += new System.EventHandler(this.chkLIST_CheckStateChanged);
			// 
			// chkSTARTEMPTY
			// 
			this.chkSTARTEMPTY.Location = new System.Drawing.Point(168, 184);
			this.chkSTARTEMPTY.Name = "chkSTARTEMPTY";
			this.chkSTARTEMPTY.Size = new System.Drawing.Size(216, 24);
			this.chkSTARTEMPTY.TabIndex = 10;
			this.chkSTARTEMPTY.Tag = "customedit.startempty:S:N";
			this.chkSTARTEMPTY.Text = "Don\'t fill at start";
			// 
			// chkTREE
			// 
			this.chkTREE.Location = new System.Drawing.Point(168, 208);
			this.chkTREE.Name = "chkTREE";
			this.chkTREE.Size = new System.Drawing.Size(216, 24);
			this.chkTREE.TabIndex = 11;
			this.chkTREE.Tag = "customedit.tree:S:N";
			this.chkTREE.Text = "Is a TREE Form";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(24, 240);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(136, 23);
			this.label5.TabIndex = 13;
			this.label5.Text = "Listing Type for searches";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbListType
			// 
			this.cmbListType.DataSource = this.DS.customview;
			this.cmbListType.DisplayMember = "viewname";
			this.cmbListType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbListType.Location = new System.Drawing.Point(160, 240);
			this.cmbListType.Name = "cmbListType";
			this.cmbListType.Size = new System.Drawing.Size(224, 21);
			this.cmbListType.TabIndex = 14;
			this.cmbListType.Tag = "customedit.defaultlisttype";
			this.cmbListType.ValueMember = "viewname";
			// 
			// chkSearchEnabled
			// 
			this.chkSearchEnabled.Location = new System.Drawing.Point(168, 272);
			this.chkSearchEnabled.Name = "chkSearchEnabled";
			this.chkSearchEnabled.Size = new System.Drawing.Size(216, 16);
			this.chkSearchEnabled.TabIndex = 15;
			this.chkSearchEnabled.Tag = "customedit.searchenabled:S:N";
			this.chkSearchEnabled.Text = "Search Enabled";
			this.chkSearchEnabled.CheckStateChanged += new System.EventHandler(this.chkSearchEnabled_CheckStateChanged);
			// 
			// OkButton
			// 
			this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OkButton.Location = new System.Drawing.Point(264, 312);
			this.OkButton.Name = "OkButton";
			this.OkButton.TabIndex = 16;
			this.OkButton.Tag = "mainsave";
			this.OkButton.Text = "Ok";
			// 
			// CancButton
			// 
			this.CancButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancButton.Location = new System.Drawing.Point(128, 312);
			this.CancButton.Name = "CancButton";
			this.CancButton.TabIndex = 17;
			this.CancButton.Text = "Cancel";
			// 
			// frmCustomEdit
			// 
			this.AcceptButton = this.OkButton;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.CancButton;
			this.ClientSize = new System.Drawing.Size(480, 357);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.CancButton,
																		  this.OkButton,
																		  this.chkSearchEnabled,
																		  this.cmbListType,
																		  this.label5,
																		  this.chkTREE,
																		  this.chkSTARTEMPTY,
																		  this.chkLIST,
																		  this.textBox4,
																		  this.label4,
																		  this.button1,
																		  this.txtDLL,
																		  this.label3,
																		  this.textBox2,
																		  this.label2,
																		  this.textBox1,
																		  this.label1});
			this.Name = "frmCustomEdit";
			this.Text = "frmCustomEdit";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion


		public void MetaData_AfterLink(){
			Meta= MetaData.GetMetaData(this);
			DataRow Curr = Meta.SourceRow;
			string filter = "(objectname='"+Curr["objectname"].ToString()+"')";
			GetData.CacheTable(DS.customview, filter,null, true);
		}

		private void button1_Click(object sender, System.EventArgs e) {
			DialogResult RES=  DLLDialog.ShowDialog(this);
			if (RES!= DialogResult.OK) return;
			DataRow Curr = DS.customedit.Rows[0];
			string fname= DLLDialog.FileName;
			int posslash = fname.LastIndexOf("\\");
			int posdot = fname.LastIndexOf(".");

			txtDLL.Text= fname.Substring(posslash+1, posdot-posslash-1);

		}

		void CalcListRelatedControls(){
			bool islist= (chkLIST.CheckState== CheckState.Checked);
			if (!islist){
				chkSTARTEMPTY.CheckState= CheckState.Unchecked;
				chkTREE.CheckState= CheckState.Unchecked;
			}
			chkTREE.Enabled=islist;
			chkSTARTEMPTY.Enabled=islist;
		}

		private void chkLIST_CheckStateChanged(object sender, System.EventArgs e) {
			CalcListRelatedControls();
		}

		public void MetaData_AfterFill(){
			CalcListRelatedControls();
			CalcSearchCombo();
		}
		void CalcSearchCombo(){
			bool cansearch= (chkSearchEnabled.CheckState== CheckState.Checked);
			cmbListType.Enabled= cansearch;		
		}

		private void chkSearchEnabled_CheckStateChanged(object sender, System.EventArgs e) {
			CalcSearchCombo();
		}
	}
}
