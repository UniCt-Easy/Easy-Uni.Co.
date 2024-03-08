
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
using System.Data;

namespace customviewwhere//customviewwhere//
{
	/// <summary>
	/// Summary description for FrmCustomViewWhere.
	/// </summary>
	public class Frm_customviewwhere : System.Windows.Forms.Form
	{
		public /*Rana:customviewwhere.*/vistaForm DS;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox comboBox3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button BtnCancel;
		private System.Windows.Forms.Button BtnOk;
		private System.Windows.Forms.TextBox txtOperand;
		private System.Windows.Forms.CheckBox chkAsk;
		private System.Windows.Forms.Label labOperand;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_customviewwhere()
		{
			InitializeComponent();
			DS.connector.ExtendedProperties["sort_by"]= "idconnector";

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
			this.DS = new /*Rana:customviewwhere.*/vistaForm();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtOperand = new System.Windows.Forms.TextBox();
			this.labOperand = new System.Windows.Forms.Label();
			this.chkAsk = new System.Windows.Forms.CheckBox();
			this.BtnCancel = new System.Windows.Forms.Button();
			this.BtnOk = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			this.DS.Namespace = "http://tempuri.org/vistaForm.xsd";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			this.label1.Text = "Object Name";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(120, 16);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(152, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.Tag = "customviewwhere.objectname";
			this.textBox1.Text = "";
			this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 40);
			this.label2.Name = "label2";
			this.label2.TabIndex = 2;
			this.label2.Text = "ViewName";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(120, 40);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(152, 20);
			this.textBox2.TabIndex = 3;
			this.textBox2.Tag = "customviewwhere.viewname";
			this.textBox2.Text = "";
			this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(120, 64);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(152, 20);
			this.textBox3.TabIndex = 5;
			this.textBox3.Tag = "customviewwhere.periodnumber";
			this.textBox3.Text = "";
			this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 64);
			this.label3.Name = "label3";
			this.label3.TabIndex = 4;
			this.label3.Text = "Period number";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 88);
			this.label4.Name = "label4";
			this.label4.TabIndex = 6;
			this.label4.Text = "Connector";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// comboBox1
			// 
			this.comboBox1.DataSource = this.DS.connector;
			this.comboBox1.DisplayMember = "name";
			this.comboBox1.Location = new System.Drawing.Point(120, 88);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(152, 21);
			this.comboBox1.TabIndex = 7;
			this.comboBox1.Tag = "customviewwhere.connector";
			this.comboBox1.ValueMember = "idconnector";
			// 
			// comboBox2
			// 
			this.comboBox2.DataSource = this.DS.columntypes;
			this.comboBox2.DisplayMember = "field";
			this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox2.Location = new System.Drawing.Point(120, 112);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(152, 21);
			this.comboBox2.TabIndex = 9;
			this.comboBox2.Tag = "customviewwhere.columnname";
			this.comboBox2.ValueMember = "field";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 112);
			this.label5.Name = "label5";
			this.label5.TabIndex = 8;
			this.label5.Text = "Column Name";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// comboBox3
			// 
			this.comboBox3.DataSource = this.DS.customoperator;
			this.comboBox3.DisplayMember = "name";
			this.comboBox3.Location = new System.Drawing.Point(120, 136);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(152, 21);
			this.comboBox3.TabIndex = 11;
			this.comboBox3.Tag = "customviewwhere.operator";
			this.comboBox3.ValueMember = "idoperator";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 136);
			this.label6.Name = "label6";
			this.label6.TabIndex = 10;
			this.label6.Text = "Operator";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtOperand
			// 
			this.txtOperand.Location = new System.Drawing.Point(16, 208);
			this.txtOperand.Multiline = true;
			this.txtOperand.Name = "txtOperand";
			this.txtOperand.Size = new System.Drawing.Size(328, 40);
			this.txtOperand.TabIndex = 13;
			this.txtOperand.Tag = "customviewwhere.value";
			this.txtOperand.Text = "";
			this.txtOperand.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// labOperand
			// 
			this.labOperand.Location = new System.Drawing.Point(16, 192);
			this.labOperand.Name = "labOperand";
			this.labOperand.Size = new System.Drawing.Size(100, 16);
			this.labOperand.TabIndex = 12;
			this.labOperand.Text = "Operand";
			this.labOperand.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// chkAsk
			// 
			this.chkAsk.Location = new System.Drawing.Point(120, 168);
			this.chkAsk.Name = "chkAsk";
			this.chkAsk.Size = new System.Drawing.Size(152, 24);
			this.chkAsk.TabIndex = 14;
			this.chkAsk.Tag = "customviewwhere.runtime:1:0";
			this.chkAsk.Text = "Ask at run-time";
			this.chkAsk.CheckStateChanged += new System.EventHandler(this.chkAsk_CheckStateChanged);
			// 
			// BtnCancel
			// 
			this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.BtnCancel.Location = new System.Drawing.Point(72, 264);
			this.BtnCancel.Name = "BtnCancel";
			this.BtnCancel.TabIndex = 31;
			this.BtnCancel.Text = "Cancel";
			// 
			// BtnOk
			// 
			this.BtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.BtnOk.Location = new System.Drawing.Point(192, 264);
			this.BtnOk.Name = "BtnOk";
			this.BtnOk.Size = new System.Drawing.Size(88, 24);
			this.BtnOk.TabIndex = 30;
			this.BtnOk.Tag = "mainsave";
			this.BtnOk.Text = "Ok";
			// 
			// FrmCustomViewWhere
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(368, 317);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.BtnCancel,
																		  this.BtnOk,
																		  this.chkAsk,
																		  this.txtOperand,
																		  this.labOperand,
																		  this.comboBox3,
																		  this.label6,
																		  this.comboBox2,
																		  this.label5,
																		  this.comboBox1,
																		  this.label4,
																		  this.textBox3,
																		  this.label3,
																		  this.textBox2,
																		  this.label2,
																		  this.textBox1,
																		  this.label1});
			this.Name = "FrmCustomViewWhere";
			this.Text = "FrmCustomViewWhere";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		void ManageAskParam(){
			labOperand.Visible= !chkAsk.Checked;
			txtOperand.Visible= !chkAsk.Checked;
		}
		private void chkAsk_CheckStateChanged(object sender, System.EventArgs e) {
			ManageAskParam();
		}

		public void MetaData_AfterFill(){
			ManageAskParam();
		}
	}
}
