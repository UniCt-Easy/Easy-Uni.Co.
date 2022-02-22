
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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

namespace MetaDataPanel//MetaDataPanel//
{
	/// <summary>
	/// Summary description for frmMetaDataPanel.
	/// </summary>
	public class Frm_MetaDataPanel : System.Windows.Forms.Form
	{
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.TabControl tabs;
		private System.Windows.Forms.TabPage tab_dbcolumns;
		private System.Windows.Forms.TabPage tab_viewstructure;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.TabPage tab_autoincrement;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DataGrid dataGrid3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TabPage tab_forms;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.DataGrid dataGrid4;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.DataGrid dataGrid5;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.DataGrid dataGrid6;
		private System.Windows.Forms.TabPage tab_redirections;
		private System.Windows.Forms.TabPage tab_views;
		public metadatalibrary.vistaForm DS;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Button button14;
		private System.Windows.Forms.Button button15;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Button btnlastmoduser;
		private System.Windows.Forms.Button btnlastmodtime;
		private System.Windows.Forms.Button btncreateuser;
		private System.Windows.Forms.Button btncreatetime;
		private System.Windows.Forms.Button BtnNoUpdate;
		private System.Windows.Forms.Button btnNoDelete;
		MetaData Meta;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtBoxMainTable;
		private System.Windows.Forms.Label labMainTable;
		private System.Windows.Forms.CheckBox chkIsRealTable;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_MetaDataPanel()
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
			this.tabs = new System.Windows.Forms.TabControl();
			this.tab_dbcolumns = new System.Windows.Forms.TabPage();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.tab_redirections = new System.Windows.Forms.TabPage();
			this.button7 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.dataGrid5 = new System.Windows.Forms.DataGrid();
			this.tab_autoincrement = new System.Windows.Forms.TabPage();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.dataGrid3 = new System.Windows.Forms.DataGrid();
			this.label5 = new System.Windows.Forms.Label();
			this.tab_viewstructure = new System.Windows.Forms.TabPage();
			this.button13 = new System.Windows.Forms.Button();
			this.button14 = new System.Windows.Forms.Button();
			this.button15 = new System.Windows.Forms.Button();
			this.dataGrid2 = new System.Windows.Forms.DataGrid();
			this.tab_forms = new System.Windows.Forms.TabPage();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.dataGrid4 = new System.Windows.Forms.DataGrid();
			this.tab_views = new System.Windows.Forms.TabPage();
			this.button10 = new System.Windows.Forms.Button();
			this.button11 = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.dataGrid6 = new System.Windows.Forms.DataGrid();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.btnNoDelete = new System.Windows.Forms.Button();
			this.BtnNoUpdate = new System.Windows.Forms.Button();
			this.btncreatetime = new System.Windows.Forms.Button();
			this.btncreateuser = new System.Windows.Forms.Button();
			this.btnlastmodtime = new System.Windows.Forms.Button();
			this.btnlastmoduser = new System.Windows.Forms.Button();
			this.DS = new metadatalibrary.vistaForm();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtBoxMainTable = new System.Windows.Forms.TextBox();
			this.labMainTable = new System.Windows.Forms.Label();
			this.chkIsRealTable = new System.Windows.Forms.CheckBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabs.SuspendLayout();
			this.tab_dbcolumns.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.tab_redirections.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid5)).BeginInit();
			this.tab_autoincrement.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
			this.tab_viewstructure.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
			this.tab_forms.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).BeginInit();
			this.tab_views.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid6)).BeginInit();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabs
			// 
			this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tabs.Controls.Add(this.tab_dbcolumns);
			this.tabs.Controls.Add(this.tab_redirections);
			this.tabs.Controls.Add(this.tab_autoincrement);
			this.tabs.Controls.Add(this.tab_viewstructure);
			this.tabs.Controls.Add(this.tab_forms);
			this.tabs.Controls.Add(this.tab_views);
			this.tabs.Controls.Add(this.tabPage1);
			this.tabs.Location = new System.Drawing.Point(0, 93);
			this.tabs.Name = "tabs";
			this.tabs.SelectedIndex = 0;
			this.tabs.Size = new System.Drawing.Size(624, 320);
			this.tabs.TabIndex = 7;
			// 
			// tab_dbcolumns
			// 
			this.tab_dbcolumns.Controls.Add(this.dataGrid1);
			this.tab_dbcolumns.Location = new System.Drawing.Point(4, 22);
			this.tab_dbcolumns.Name = "tab_dbcolumns";
			this.tab_dbcolumns.Size = new System.Drawing.Size(616, 294);
			this.tab_dbcolumns.TabIndex = 0;
			this.tab_dbcolumns.Text = "DB columns";
			// 
			// dataGrid1
			// 
			this.dataGrid1.AllowNavigation = false;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(0, -2);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(616, 296);
			this.dataGrid1.TabIndex = 0;
			this.dataGrid1.Tag = "columntypes.default.default";
			// 
			// tab_redirections
			// 
			this.tab_redirections.Controls.Add(this.button7);
			this.tab_redirections.Controls.Add(this.button8);
			this.tab_redirections.Controls.Add(this.button9);
			this.tab_redirections.Controls.Add(this.dataGrid5);
			this.tab_redirections.Location = new System.Drawing.Point(4, 22);
			this.tab_redirections.Name = "tab_redirections";
			this.tab_redirections.Size = new System.Drawing.Size(616, 294);
			this.tab_redirections.TabIndex = 4;
			this.tab_redirections.Text = "Redirections";
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(168, 8);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(72, 23);
			this.button7.TabIndex = 12;
			this.button7.Tag = "delete";
			this.button7.Text = "Delete";
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(88, 8);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(72, 24);
			this.button8.TabIndex = 11;
			this.button8.Tag = "edit.default";
			this.button8.Text = "Edit";
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(16, 8);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(64, 24);
			this.button9.TabIndex = 10;
			this.button9.Tag = "insert.default";
			this.button9.Text = "New";
			// 
			// dataGrid5
			// 
			this.dataGrid5.AllowNavigation = false;
			this.dataGrid5.DataMember = "";
			this.dataGrid5.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.dataGrid5.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid5.Location = new System.Drawing.Point(0, 38);
			this.dataGrid5.Name = "dataGrid5";
			this.dataGrid5.Size = new System.Drawing.Size(616, 256);
			this.dataGrid5.TabIndex = 9;
			this.dataGrid5.Tag = "customredirect.default.default";
			// 
			// tab_autoincrement
			// 
			this.tab_autoincrement.Controls.Add(this.button3);
			this.tab_autoincrement.Controls.Add(this.button2);
			this.tab_autoincrement.Controls.Add(this.button1);
			this.tab_autoincrement.Controls.Add(this.dataGrid3);
			this.tab_autoincrement.Controls.Add(this.label5);
			this.tab_autoincrement.Location = new System.Drawing.Point(4, 22);
			this.tab_autoincrement.Name = "tab_autoincrement";
			this.tab_autoincrement.Size = new System.Drawing.Size(616, 294);
			this.tab_autoincrement.TabIndex = 2;
			this.tab_autoincrement.Text = "Autoincrement";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(168, 24);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(72, 23);
			this.button3.TabIndex = 4;
			this.button3.Tag = "delete";
			this.button3.Text = "Delete";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(80, 24);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 24);
			this.button2.TabIndex = 3;
			this.button2.Tag = "edit.default";
			this.button2.Text = "Edit";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(8, 24);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(64, 24);
			this.button1.TabIndex = 2;
			this.button1.Tag = "insert.default";
			this.button1.Text = "New";
			// 
			// dataGrid3
			// 
			this.dataGrid3.AllowNavigation = false;
			this.dataGrid3.DataMember = "";
			this.dataGrid3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.dataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid3.Location = new System.Drawing.Point(0, 62);
			this.dataGrid3.Name = "dataGrid3";
			this.dataGrid3.Size = new System.Drawing.Size(616, 232);
			this.dataGrid3.TabIndex = 1;
			this.dataGrid3.Tag = "customtablestructure.default.default";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(272, 16);
			this.label5.TabIndex = 0;
			this.label5.Text = "Structure of autoincrements fields and selectors";
			// 
			// tab_viewstructure
			// 
			this.tab_viewstructure.Controls.Add(this.button13);
			this.tab_viewstructure.Controls.Add(this.button14);
			this.tab_viewstructure.Controls.Add(this.button15);
			this.tab_viewstructure.Controls.Add(this.dataGrid2);
			this.tab_viewstructure.Location = new System.Drawing.Point(4, 22);
			this.tab_viewstructure.Name = "tab_viewstructure";
			this.tab_viewstructure.Size = new System.Drawing.Size(616, 294);
			this.tab_viewstructure.TabIndex = 1;
			this.tab_viewstructure.Text = "View Structure";
			// 
			// button13
			// 
			this.button13.Location = new System.Drawing.Point(168, 8);
			this.button13.Name = "button13";
			this.button13.Size = new System.Drawing.Size(72, 23);
			this.button13.TabIndex = 15;
			this.button13.Tag = "delete";
			this.button13.Text = "Delete";
			// 
			// button14
			// 
			this.button14.Location = new System.Drawing.Point(88, 8);
			this.button14.Name = "button14";
			this.button14.Size = new System.Drawing.Size(72, 24);
			this.button14.TabIndex = 14;
			this.button14.Tag = "edit.default";
			this.button14.Text = "Edit";
			// 
			// button15
			// 
			this.button15.Location = new System.Drawing.Point(16, 8);
			this.button15.Name = "button15";
			this.button15.Size = new System.Drawing.Size(64, 24);
			this.button15.TabIndex = 13;
			this.button15.Tag = "insert.default";
			this.button15.Text = "New";
			// 
			// dataGrid2
			// 
			this.dataGrid2.AllowNavigation = false;
			this.dataGrid2.DataMember = "";
			this.dataGrid2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid2.Location = new System.Drawing.Point(0, 38);
			this.dataGrid2.Name = "dataGrid2";
			this.dataGrid2.Size = new System.Drawing.Size(616, 256);
			this.dataGrid2.TabIndex = 0;
			this.dataGrid2.Tag = "viewcolumn.default.default";
			// 
			// tab_forms
			// 
			this.tab_forms.Controls.Add(this.button4);
			this.tab_forms.Controls.Add(this.button5);
			this.tab_forms.Controls.Add(this.button6);
			this.tab_forms.Controls.Add(this.dataGrid4);
			this.tab_forms.Location = new System.Drawing.Point(4, 22);
			this.tab_forms.Name = "tab_forms";
			this.tab_forms.Size = new System.Drawing.Size(616, 294);
			this.tab_forms.TabIndex = 3;
			this.tab_forms.Text = "Forms";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(176, 8);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(72, 23);
			this.button4.TabIndex = 8;
			this.button4.Tag = "delete";
			this.button4.Text = "Delete";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(88, 8);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(72, 24);
			this.button5.TabIndex = 7;
			this.button5.Tag = "edit.default";
			this.button5.Text = "Edit";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(16, 8);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(64, 24);
			this.button6.TabIndex = 6;
			this.button6.Tag = "insert.default";
			this.button6.Text = "New";
			// 
			// dataGrid4
			// 
			this.dataGrid4.AllowNavigation = false;
			this.dataGrid4.DataMember = "";
			this.dataGrid4.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.dataGrid4.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid4.Location = new System.Drawing.Point(0, 38);
			this.dataGrid4.Name = "dataGrid4";
			this.dataGrid4.Size = new System.Drawing.Size(616, 256);
			this.dataGrid4.TabIndex = 5;
			this.dataGrid4.Tag = "customedit.default.default";
			// 
			// tab_views
			// 
			this.tab_views.Controls.Add(this.button10);
			this.tab_views.Controls.Add(this.button11);
			this.tab_views.Controls.Add(this.button12);
			this.tab_views.Controls.Add(this.dataGrid6);
			this.tab_views.Location = new System.Drawing.Point(4, 22);
			this.tab_views.Name = "tab_views";
			this.tab_views.Size = new System.Drawing.Size(616, 294);
			this.tab_views.TabIndex = 5;
			this.tab_views.Text = "Views (Listing types)";
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(176, 8);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(72, 23);
			this.button10.TabIndex = 16;
			this.button10.Tag = "delete";
			this.button10.Text = "Delete";
			// 
			// button11
			// 
			this.button11.Location = new System.Drawing.Point(88, 8);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(72, 24);
			this.button11.TabIndex = 15;
			this.button11.Tag = "edit.default";
			this.button11.Text = "Edit";
			// 
			// button12
			// 
			this.button12.Location = new System.Drawing.Point(16, 8);
			this.button12.Name = "button12";
			this.button12.Size = new System.Drawing.Size(64, 24);
			this.button12.TabIndex = 14;
			this.button12.Tag = "insert.default";
			this.button12.Text = "New";
			// 
			// dataGrid6
			// 
			this.dataGrid6.AllowNavigation = false;
			this.dataGrid6.DataMember = "";
			this.dataGrid6.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.dataGrid6.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid6.Location = new System.Drawing.Point(0, 38);
			this.dataGrid6.Name = "dataGrid6";
			this.dataGrid6.Size = new System.Drawing.Size(616, 256);
			this.dataGrid6.TabIndex = 13;
			this.dataGrid6.Tag = "customview.default.default";
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.btnNoDelete);
			this.tabPage1.Controls.Add(this.BtnNoUpdate);
			this.tabPage1.Controls.Add(this.btncreatetime);
			this.tabPage1.Controls.Add(this.btncreateuser);
			this.tabPage1.Controls.Add(this.btnlastmodtime);
			this.tabPage1.Controls.Add(this.btnlastmoduser);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(616, 294);
			this.tabPage1.TabIndex = 6;
			this.tabPage1.Tag = "";
			this.tabPage1.Text = "Utilities";
			// 
			// btnNoDelete
			// 
			this.btnNoDelete.Location = new System.Drawing.Point(24, 176);
			this.btnNoDelete.Name = "btnNoDelete";
			this.btnNoDelete.Size = new System.Drawing.Size(152, 23);
			this.btnNoDelete.TabIndex = 5;
			this.btnNoDelete.Text = "Add nodelete field";
			this.btnNoDelete.Click += new System.EventHandler(this.btnNoDelete_Click);
			// 
			// BtnNoUpdate
			// 
			this.BtnNoUpdate.Location = new System.Drawing.Point(24, 144);
			this.BtnNoUpdate.Name = "BtnNoUpdate";
			this.BtnNoUpdate.Size = new System.Drawing.Size(152, 23);
			this.BtnNoUpdate.TabIndex = 4;
			this.BtnNoUpdate.Text = "Add noupdate field";
			this.BtnNoUpdate.Click += new System.EventHandler(this.BtnNoUpdate_Click);
			// 
			// btncreatetime
			// 
			this.btncreatetime.Location = new System.Drawing.Point(24, 112);
			this.btncreatetime.Name = "btncreatetime";
			this.btncreatetime.Size = new System.Drawing.Size(152, 23);
			this.btncreatetime.TabIndex = 3;
			this.btncreatetime.Text = "Add createtimestamp field";
			this.btncreatetime.Click += new System.EventHandler(this.btncreatetime_Click);
			// 
			// btncreateuser
			// 
			this.btncreateuser.Location = new System.Drawing.Point(24, 80);
			this.btncreateuser.Name = "btncreateuser";
			this.btncreateuser.Size = new System.Drawing.Size(152, 23);
			this.btncreateuser.TabIndex = 2;
			this.btncreateuser.Text = "Add createuser field";
			this.btncreateuser.Click += new System.EventHandler(this.btncreateuser_Click);
			// 
			// btnlastmodtime
			// 
			this.btnlastmodtime.Location = new System.Drawing.Point(24, 48);
			this.btnlastmodtime.Name = "btnlastmodtime";
			this.btnlastmodtime.Size = new System.Drawing.Size(152, 23);
			this.btnlastmodtime.TabIndex = 1;
			this.btnlastmodtime.Text = "Add lastmodtimestamp field";
			this.btnlastmodtime.Click += new System.EventHandler(this.btnlastmodtime_Click);
			// 
			// btnlastmoduser
			// 
			this.btnlastmoduser.Location = new System.Drawing.Point(24, 16);
			this.btnlastmoduser.Name = "btnlastmoduser";
			this.btnlastmoduser.Size = new System.Drawing.Size(152, 23);
			this.btnlastmoduser.TabIndex = 0;
			this.btnlastmoduser.Text = "Add lastmoduser field";
			this.btnlastmoduser.Click += new System.EventHandler(this.btnlastmoduser_Click);
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtBoxMainTable);
			this.groupBox1.Controls.Add(this.labMainTable);
			this.groupBox1.Controls.Add(this.chkIsRealTable);
			this.groupBox1.Controls.Add(this.textBox2);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(624, 72);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "General";
			// 
			// txtBoxMainTable
			// 
			this.txtBoxMainTable.Location = new System.Drawing.Point(440, 41);
			this.txtBoxMainTable.Name = "txtBoxMainTable";
			this.txtBoxMainTable.Size = new System.Drawing.Size(168, 20);
			this.txtBoxMainTable.TabIndex = 13;
			this.txtBoxMainTable.Tag = "customobject.realtable";
			this.txtBoxMainTable.Text = "";
			// 
			// labMainTable
			// 
			this.labMainTable.Location = new System.Drawing.Point(336, 41);
			this.labMainTable.Name = "labMainTable";
			this.labMainTable.Size = new System.Drawing.Size(104, 23);
			this.labMainTable.TabIndex = 12;
			this.labMainTable.Text = "Main Table of View";
			this.labMainTable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// chkIsRealTable
			// 
			this.chkIsRealTable.Location = new System.Drawing.Point(344, 17);
			this.chkIsRealTable.Name = "chkIsRealTable";
			this.chkIsRealTable.Size = new System.Drawing.Size(168, 24);
			this.chkIsRealTable.TabIndex = 11;
			this.chkIsRealTable.Tag = "customobject.isreal:S:N";
			this.chkIsRealTable.Text = "Real Table (Not a View)";
			this.chkIsRealTable.CheckedChanged += new System.EventHandler(this.chkIsRealTable_CheckedChanged);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(120, 41);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(200, 20);
			this.textBox2.TabIndex = 10;
			this.textBox2.Tag = "customobject.description";
			this.textBox2.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 23);
			this.label2.TabIndex = 9;
			this.label2.Text = "Description";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(120, 17);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(200, 20);
			this.textBox1.TabIndex = 8;
			this.textBox1.Tag = "customobject.objectname";
			this.textBox1.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 16);
			this.label1.TabIndex = 7;
			this.label1.Text = "DB Table Name";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// frmMetaDataPanel
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(624, 413);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.tabs);
			this.Name = "frmMetaDataPanel";
			this.Tag = "customobject.objectname";
			this.Text = "frmMetaDataPanel";
			this.tabs.ResumeLayout(false);
			this.tab_dbcolumns.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.tab_redirections.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid5)).EndInit();
			this.tab_autoincrement.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
			this.tab_viewstructure.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
			this.tab_forms.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).EndInit();
			this.tab_views.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid6)).EndInit();
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		void EnableDisableButton(string fieldname, Button Btn){
			if (Meta.IsEmpty) {
				Btn.Enabled=false;
				return;
			}
			string filterfield= "(field='"+fieldname+"')";
			if (DS.columntypes.Select(filterfield).Length==0)
				Btn.Enabled=true;
			else
				Btn.Enabled=false;
		}

		void EnableDisableUtils(){
			EnableDisableButton("createtimestamp",btncreatetime);
			EnableDisableButton("createuser",btncreateuser);
			EnableDisableButton("lastmodtimestamp",btnlastmodtime);
			EnableDisableButton("lastmoduser",btnlastmoduser);
			EnableDisableButton("noupdate",BtnNoUpdate);
			EnableDisableButton("nodelete",btnNoDelete);
		}

		public void MetaData_AfterFill(){
			EnableDisableUtils();
			chkIsRealTable.Enabled=false;
			ManageChkIsReal();
		}

		public void MetaData_AfterClear(){
			chkIsRealTable.Enabled=true;
			btncreatetime.Visible=true;
			btncreateuser.Visible=true;
			btnlastmodtime.Visible=true;
			btnlastmoduser.Visible=true;
			btnNoDelete.Visible=true;
			BtnNoUpdate.Visible=true;
			EnableDisableUtils();
		}

		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
		}

		void AddField(string fieldname, string SQLdeclaration){
			string tablename = DS.customobject.Rows[0]["objectname"].ToString();
			string [,]fields = new String[,] { {
				fieldname,SQLdeclaration,"NULL"}};
			dbanalyzer.AddColumns(tablename, fields, Meta.Conn);
			Meta.Conn.RefreshStructure(tablename);
			Meta.Conn.SaveStructure();
		}

		private void btnlastmoduser_Click(object sender, System.EventArgs e) {
			AddField("lastmoduser","varchar(30)");
			btnlastmoduser.Visible=false;			
		}

		private void btnlastmodtime_Click(object sender, System.EventArgs e) {
			AddField("lastmodtimestamp","datetime");
			btnlastmodtime.Visible=false;					
		}

		private void btncreateuser_Click(object sender, System.EventArgs e) {
			AddField("createuser","varchar(30)");
			btncreateuser.Visible=false;							
		}

		private void btncreatetime_Click(object sender, System.EventArgs e) {
			AddField("createtimestamp","datetime");
			btncreatetime.Visible=false;							
		
		}

		private void BtnNoUpdate_Click(object sender, System.EventArgs e) {
			AddField("noupdate","smallint");
			BtnNoUpdate.Visible=false;
		}

		private void btnNoDelete_Click(object sender, System.EventArgs e) {
			AddField("nodelete","smallint");
			btnNoDelete.Visible=false;		
		}

		void ManageChkIsReal(){
			labMainTable.Visible= !chkIsRealTable.Checked;
			txtBoxMainTable.Visible= !chkIsRealTable.Checked;
			
			if (chkIsRealTable.CheckState== CheckState.Unchecked){
				if (tabs.TabPages.IndexOf(tab_autoincrement)!=-1) 
					tabs.TabPages.Remove(tab_autoincrement);
			}
			else {
				if (tabs.TabPages.IndexOf(tab_autoincrement)==-1) 
					tabs.TabPages.Add(tab_autoincrement);
			}
		}

		private void chkIsRealTable_CheckedChanged(object sender, System.EventArgs e) {
			ManageChkIsReal();
		}

	}
}
