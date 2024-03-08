
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

namespace customtablestructure//customtablestructure//
{
	/// <summary>
	/// Summary description for frmtablestructure.
	/// </summary>
	public class Frm_customtablestructure : System.Windows.Forms.Form
	{
		public /*Rana:customtablestructure.*/vistaForm DS;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button CancButton;
		private System.Windows.Forms.Button OkButton;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox gboxAutoInc;
		private System.Windows.Forms.TextBox txtBoxStep;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton chkSelector;
		private System.Windows.Forms.RadioButton chkAutoIncrement;
		private System.Windows.Forms.CheckBox chkInvisibleSelector;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_customtablestructure()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		void EnableDisableAutoIncFields(){
			gboxAutoInc.Enabled= chkAutoIncrement.Checked;
		}

		public void MetaData_AfterLink(){
			MetaData Meta = MetaData.GetMetaData(this);
			DataRow Curr = Meta.SourceRow;
			string filter= "(tablename='"+Curr["objectname"].ToString()+"')";
			GetData.CacheTable(DS.columntypes, filter,null,true);
		}

		public void MetaData_AfterFill(){
			EnableDisableAutoIncFields();
			chkSelector.Checked= !chkAutoIncrement.Checked;
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
			this.DS = new /*Rana:customtablestructure.*/vistaForm();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.CancButton = new System.Windows.Forms.Button();
			this.OkButton = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.gboxAutoInc = new System.Windows.Forms.GroupBox();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtBoxStep = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.chkAutoIncrement = new System.Windows.Forms.RadioButton();
			this.chkSelector = new System.Windows.Forms.RadioButton();
			this.chkInvisibleSelector = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.gboxAutoInc.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Object Name";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(16, 32);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(168, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.Tag = "customtablestructure.objectname";
			this.textBox1.Text = "";
			this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Column Name";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// CancButton
			// 
			this.CancButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancButton.Location = new System.Drawing.Point(216, 208);
			this.CancButton.Name = "CancButton";
			this.CancButton.TabIndex = 19;
			this.CancButton.Text = "Cancel";
			// 
			// OkButton
			// 
			this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OkButton.Location = new System.Drawing.Point(312, 208);
			this.OkButton.Name = "OkButton";
			this.OkButton.TabIndex = 18;
			this.OkButton.Tag = "mainsave";
			this.OkButton.Text = "Ok";
			// 
			// comboBox1
			// 
			this.comboBox1.DataSource = this.DS.columntypes;
			this.comboBox1.DisplayMember = "field";
			this.comboBox1.Location = new System.Drawing.Point(16, 80);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(168, 21);
			this.comboBox1.TabIndex = 20;
			this.comboBox1.Tag = "customtablestructure.colname";
			this.comboBox1.ValueMember = "field";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.comboBox1);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(208, 112);
			this.groupBox1.TabIndex = 22;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "DB Column";
			// 
			// gboxAutoInc
			// 
			this.gboxAutoInc.Controls.Add(this.comboBox2);
			this.gboxAutoInc.Controls.Add(this.checkBox2);
			this.gboxAutoInc.Controls.Add(this.textBox5);
			this.gboxAutoInc.Controls.Add(this.label6);
			this.gboxAutoInc.Controls.Add(this.textBox4);
			this.gboxAutoInc.Controls.Add(this.label5);
			this.gboxAutoInc.Controls.Add(this.label4);
			this.gboxAutoInc.Controls.Add(this.txtBoxStep);
			this.gboxAutoInc.Controls.Add(this.label3);
			this.gboxAutoInc.Location = new System.Drawing.Point(232, 16);
			this.gboxAutoInc.Name = "gboxAutoInc";
			this.gboxAutoInc.Size = new System.Drawing.Size(336, 176);
			this.gboxAutoInc.TabIndex = 23;
			this.gboxAutoInc.TabStop = false;
			this.gboxAutoInc.Text = "Auto Increment Properties";
			// 
			// comboBox2
			// 
			this.comboBox2.DataSource = this.DS.columntypes;
			this.comboBox2.DisplayMember = "field";
			this.comboBox2.Location = new System.Drawing.Point(152, 48);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(168, 21);
			this.comboBox2.TabIndex = 32;
			this.comboBox2.Tag = "customtablestructure.prefixfieldname";
			this.comboBox2.ValueMember = "field";
			// 
			// checkBox2
			// 
			this.checkBox2.Location = new System.Drawing.Point(152, 144);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(168, 24);
			this.checkBox2.TabIndex = 30;
			this.checkBox2.Tag = "customtablestructure.linear:S:N";
			this.checkBox2.Text = "Linear";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(152, 120);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(168, 20);
			this.textBox5.TabIndex = 29;
			this.textBox5.Tag = "customtablestructure.length";
			this.textBox5.Text = "";
			this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(24, 120);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(120, 23);
			this.label6.TabIndex = 28;
			this.label6.Text = "Field characters length";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(152, 88);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(168, 20);
			this.textBox4.TabIndex = 27;
			this.textBox4.Tag = "customtablestructure.middleconst";
			this.textBox4.Text = "";
			this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(48, 88);
			this.label5.Name = "label5";
			this.label5.TabIndex = 26;
			this.label5.Text = "Middle Constant";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(48, 48);
			this.label4.Name = "label4";
			this.label4.TabIndex = 25;
			this.label4.Text = "Prefix Field";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtBoxStep
			// 
			this.txtBoxStep.Location = new System.Drawing.Point(152, 16);
			this.txtBoxStep.Name = "txtBoxStep";
			this.txtBoxStep.Size = new System.Drawing.Size(168, 20);
			this.txtBoxStep.TabIndex = 24;
			this.txtBoxStep.Tag = "customtablestructure.step";
			this.txtBoxStep.Text = "";
			this.txtBoxStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(48, 16);
			this.label3.Name = "label3";
			this.label3.TabIndex = 23;
			this.label3.Text = "Step";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.chkAutoIncrement);
			this.groupBox2.Controls.Add(this.chkSelector);
			this.groupBox2.Location = new System.Drawing.Point(8, 128);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(208, 64);
			this.groupBox2.TabIndex = 32;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Field Type";
			// 
			// chkAutoIncrement
			// 
			this.chkAutoIncrement.Location = new System.Drawing.Point(8, 16);
			this.chkAutoIncrement.Name = "chkAutoIncrement";
			this.chkAutoIncrement.Size = new System.Drawing.Size(176, 16);
			this.chkAutoIncrement.TabIndex = 24;
			this.chkAutoIncrement.Tag = "customtablestructure.autoincrement:S";
			this.chkAutoIncrement.Text = "Auto Increment";
			this.chkAutoIncrement.CheckedChanged += new System.EventHandler(this.chkAutoIncrement_CheckedChanged);
			// 
			// chkSelector
			// 
			this.chkSelector.Location = new System.Drawing.Point(8, 40);
			this.chkSelector.Name = "chkSelector";
			this.chkSelector.Size = new System.Drawing.Size(176, 16);
			this.chkSelector.TabIndex = 23;
			this.chkSelector.Tag = "customtablestructure.autoincrement:N";
			this.chkSelector.Text = "Selector";
			// 
			// chkInvisibleSelector
			// 
			this.chkInvisibleSelector.Location = new System.Drawing.Point(16, 200);
			this.chkInvisibleSelector.Name = "chkInvisibleSelector";
			this.chkInvisibleSelector.Size = new System.Drawing.Size(168, 24);
			this.chkInvisibleSelector.TabIndex = 33;
			this.chkInvisibleSelector.Tag = "customtablestructure.selector:S:N";
			this.chkInvisibleSelector.Text = "(Invisible) Selector";
			this.chkInvisibleSelector.Visible = false;
			// 
			// frmtablestructure
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(584, 245);
			this.Controls.Add(this.chkInvisibleSelector);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.gboxAutoInc);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.CancButton);
			this.Controls.Add(this.OkButton);
			this.Name = "frmtablestructure";
			this.Tag = "customtablestructure.linear:S:N";
			this.Text = "Table Structure";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.gboxAutoInc.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		
		private void chkAutoIncrement_CheckedChanged(object sender, System.EventArgs e) {			
			chkSelector.Checked= !chkAutoIncrement.Checked;
			chkInvisibleSelector.Checked = chkSelector.Checked;
			EnableDisableAutoIncFields();
		}
	}
}
