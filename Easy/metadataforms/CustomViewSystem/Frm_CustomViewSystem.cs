
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
using System.Drawing.Printing;
using System.Data;
using metadatalibrary;

namespace CustomViewSystem//CustomViewSystem//
{
	/// <summary>
	/// Descrizione di riepilogo per frmCustomView.
	/// </summary>
	public class Frm_CustomViewSystem : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
		private System.Windows.Forms.PrintDialog printDialog1;
		public /*Rana:CustomViewSystem.*/vistaForm DS;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage4;
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
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.CheckBox checkBox4;
		private System.Windows.Forms.CheckBox checkBox5;
		private System.Windows.Forms.CheckBox checkBox6;
		private System.Windows.Forms.CheckBox checkBox7;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.CheckBox checkBox8;
		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBox11;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.CheckBox checkBox9;
		private System.Windows.Forms.CheckBox checkBox10;
		private System.Windows.Forms.TextBox textBox12;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.DataGrid dataGrid3;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Button BtnCancel;
		private System.Windows.Forms.Button BtnOk;
		private System.Windows.Forms.TextBox txtSQLfilter;
		private System.Windows.Forms.Label label13;
		/// <summary>
		/// Variabile di progettazione necessaria.
		/// </summary>
		private System.ComponentModel.Container components = null;
		MetaData Meta;
		DataAccess Conn;

		public Frm_CustomViewSystem()
		{
			//
			// Necessario per il supporto di Progettazione Windows Form
			//
			InitializeComponent();

			//
			// TODO: aggiungere il codice del costruttore dopo la chiamata a InitializeComponent.
			//
		}

		/// <summary>
		/// Pulire le risorse in uso.
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

		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
			Conn = Meta.Conn;
		}
		public void MetaData_AfterFill(){	
			string filter = GetData.GetFilterFromCustomViewWhere(Conn,null, 
				DS.customviewwhere.Select(), false);
			txtSQLfilter.Text= filter;			
		}
		#region Windows Form Designer generated code
		/// <summary>
		/// Metodo necessario per il supporto della finestra di progettazione. Non modificare
		/// il contenuto del metodo con l'editor di codice.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmCustomView));
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
			this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
			this.printDialog1 = new System.Windows.Forms.PrintDialog();
			this.DS = new /*Rana:CustomViewSystem.*/vistaForm();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.textBox11 = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.checkBox8 = new System.Windows.Forms.CheckBox();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.checkBox7 = new System.Windows.Forms.CheckBox();
			this.checkBox6 = new System.Windows.Forms.CheckBox();
			this.checkBox5 = new System.Windows.Forms.CheckBox();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.txtSQLfilter = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.dataGrid2 = new System.Windows.Forms.DataGrid();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.dataGrid3 = new System.Windows.Forms.DataGrid();
			this.button7 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.checkBox9 = new System.Windows.Forms.CheckBox();
			this.checkBox10 = new System.Windows.Forms.CheckBox();
			this.textBox12 = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.BtnCancel = new System.Windows.Forms.Button();
			this.BtnOk = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.tabPage3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
			this.tabPage4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Object Name";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(8, 24);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(168, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.Tag = "customview.objectname";
			this.textBox1.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(200, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Listing Type";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(200, 24);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(200, 20);
			this.textBox2.TabIndex = 3;
			this.textBox2.Tag = "customview.viewname";
			this.textBox2.Text = "";
			this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// printPreviewDialog1
			// 
			this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
			this.printPreviewDialog1.Enabled = true;
			this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
			this.printPreviewDialog1.Location = new System.Drawing.Point(160, 19);
			this.printPreviewDialog1.MaximumSize = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.Name = "printPreviewDialog1";
			this.printPreviewDialog1.Opacity = 1;
			this.printPreviewDialog1.TransparencyKey = System.Drawing.Color.Empty;
			this.printPreviewDialog1.Visible = false;
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			this.DS.Namespace = "http://tempuri.org/vistaForm.xsd";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.tabPage1,
																					  this.tabPage2,
																					  this.tabPage3,
																					  this.tabPage4});
			this.tabControl1.Location = new System.Drawing.Point(8, 104);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(680, 368);
			this.tabControl1.TabIndex = 4;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.textBox11,
																				   this.label11,
																				   this.textBox10,
																				   this.label10,
																				   this.checkBox8,
																				   this.textBox9,
																				   this.label9,
																				   this.checkBox7,
																				   this.checkBox6,
																				   this.checkBox5,
																				   this.checkBox4,
																				   this.checkBox3,
																				   this.checkBox2,
																				   this.checkBox1,
																				   this.groupBox1,
																				   this.textBox4,
																				   this.label4,
																				   this.textBox3,
																				   this.label3});
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(672, 342);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Main settings";
			// 
			// textBox11
			// 
			this.textBox11.Location = new System.Drawing.Point(88, 272);
			this.textBox11.Name = "textBox11";
			this.textBox11.TabIndex = 32;
			this.textBox11.Tag = "customview.vpages";
			this.textBox11.Text = "";
			this.textBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(16, 272);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(64, 23);
			this.label11.TabIndex = 31;
			this.label11.Text = "V Pages";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox10
			// 
			this.textBox10.Location = new System.Drawing.Point(88, 248);
			this.textBox10.Name = "textBox10";
			this.textBox10.TabIndex = 30;
			this.textBox10.Tag = "customview.hpages";
			this.textBox10.Text = "";
			this.textBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(16, 248);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(64, 23);
			this.label10.TabIndex = 29;
			this.label10.Text = "H pages";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// checkBox8
			// 
			this.checkBox8.Location = new System.Drawing.Point(88, 224);
			this.checkBox8.Name = "checkBox8";
			this.checkBox8.Size = new System.Drawing.Size(120, 24);
			this.checkBox8.TabIndex = 28;
			this.checkBox8.Tag = "customview.fittopage:1:0";
			this.checkBox8.Text = "Fit to page";
			// 
			// textBox9
			// 
			this.textBox9.Location = new System.Drawing.Point(88, 200);
			this.textBox9.Name = "textBox9";
			this.textBox9.TabIndex = 27;
			this.textBox9.Tag = "customview.scale";
			this.textBox9.Text = "";
			this.textBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(16, 200);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(64, 23);
			this.label9.TabIndex = 26;
			this.label9.Text = "Scale";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// checkBox7
			// 
			this.checkBox7.Location = new System.Drawing.Point(248, 224);
			this.checkBox7.Name = "checkBox7";
			this.checkBox7.Size = new System.Drawing.Size(120, 24);
			this.checkBox7.TabIndex = 25;
			this.checkBox7.Tag = "customview.rowheading:1:0";
			this.checkBox7.Text = "Row Heading";
			// 
			// checkBox6
			// 
			this.checkBox6.Location = new System.Drawing.Point(248, 200);
			this.checkBox6.Name = "checkBox6";
			this.checkBox6.Size = new System.Drawing.Size(120, 24);
			this.checkBox6.TabIndex = 24;
			this.checkBox6.Tag = "customview.landscape:1:0";
			this.checkBox6.Text = "Landscape";
			// 
			// checkBox5
			// 
			this.checkBox5.Location = new System.Drawing.Point(248, 176);
			this.checkBox5.Name = "checkBox5";
			this.checkBox5.Size = new System.Drawing.Size(120, 24);
			this.checkBox5.TabIndex = 23;
			this.checkBox5.Tag = "customview.colheading:1:0";
			this.checkBox5.Text = "Column Heading";
			// 
			// checkBox4
			// 
			this.checkBox4.Location = new System.Drawing.Point(248, 152);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(120, 24);
			this.checkBox4.TabIndex = 22;
			this.checkBox4.Tag = "customview.rowheading:1:0";
			this.checkBox4.Text = "Row Heading";
			// 
			// checkBox3
			// 
			this.checkBox3.Location = new System.Drawing.Point(248, 128);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(120, 24);
			this.checkBox3.TabIndex = 21;
			this.checkBox3.Tag = "customview.vcenter:1:0";
			this.checkBox3.Text = "Vertical Center";
			// 
			// checkBox2
			// 
			this.checkBox2.Location = new System.Drawing.Point(248, 104);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(120, 24);
			this.checkBox2.TabIndex = 20;
			this.checkBox2.Tag = "customview.hcenter:1:0";
			this.checkBox2.Text = "Horizontal Center";
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(248, 80);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.TabIndex = 19;
			this.checkBox1.Tag = "customview.lefttoright:1:0";
			this.checkBox1.Text = "Left To Right";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.textBox5,
																					this.label7,
																					this.label5,
																					this.label6,
																					this.textBox8,
																					this.textBox7,
																					this.textBox6,
																					this.label8});
			this.groupBox1.Location = new System.Drawing.Point(16, 72);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(216, 120);
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Margins";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(96, 16);
			this.textBox5.Name = "textBox5";
			this.textBox5.TabIndex = 5;
			this.textBox5.Tag = "customview.topmargin";
			this.textBox5.Text = "";
			this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 64);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(80, 23);
			this.label7.TabIndex = 8;
			this.label7.Text = "Right Margin";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(24, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 23);
			this.label5.TabIndex = 4;
			this.label5.Text = "Top Margin";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 40);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(80, 23);
			this.label6.TabIndex = 6;
			this.label6.Text = "Bottom Margin";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(96, 88);
			this.textBox8.Name = "textBox8";
			this.textBox8.TabIndex = 11;
			this.textBox8.Tag = "customview.leftmargin";
			this.textBox8.Text = "";
			this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(96, 64);
			this.textBox7.Name = "textBox7";
			this.textBox7.TabIndex = 9;
			this.textBox7.Tag = "customview.rightmargin";
			this.textBox7.Text = "";
			this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(96, 40);
			this.textBox6.Name = "textBox6";
			this.textBox6.TabIndex = 7;
			this.textBox6.Tag = "customview.bottommargin";
			this.textBox6.Text = "";
			this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(24, 88);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(64, 23);
			this.label8.TabIndex = 10;
			this.label8.Text = "Left Margin";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(96, 40);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(288, 20);
			this.textBox4.TabIndex = 3;
			this.textBox4.Tag = "customview.footer";
			this.textBox4.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(24, 40);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 23);
			this.label4.TabIndex = 2;
			this.label4.Text = "Footer";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(96, 16);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(288, 20);
			this.textBox3.TabIndex = 1;
			this.textBox3.Tag = "customview.header";
			this.textBox3.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(24, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 23);
			this.label3.TabIndex = 0;
			this.label3.Text = "Header";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.dataGrid1,
																				   this.button3,
																				   this.button2,
																				   this.button1});
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(672, 342);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Columns";
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(16, 48);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(648, 288);
			this.dataGrid1.TabIndex = 3;
			this.dataGrid1.Tag = "customviewcolumn.default.default";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(192, 16);
			this.button3.Name = "button3";
			this.button3.TabIndex = 2;
			this.button3.Tag = "delete";
			this.button3.Text = "Delete";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(104, 16);
			this.button2.Name = "button2";
			this.button2.TabIndex = 1;
			this.button2.Tag = "edit.default";
			this.button2.Text = "Edit";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(16, 16);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Tag = "insert.default";
			this.button1.Text = "New";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.txtSQLfilter,
																				   this.label13,
																				   this.dataGrid2,
																				   this.button4,
																				   this.button5,
																				   this.button6});
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(672, 342);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Filter";
			// 
			// txtSQLfilter
			// 
			this.txtSQLfilter.Location = new System.Drawing.Point(16, 24);
			this.txtSQLfilter.Multiline = true;
			this.txtSQLfilter.Name = "txtSQLfilter";
			this.txtSQLfilter.ReadOnly = true;
			this.txtSQLfilter.Size = new System.Drawing.Size(648, 40);
			this.txtSQLfilter.TabIndex = 11;
			this.txtSQLfilter.Text = "";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(16, 8);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(100, 16);
			this.label13.TabIndex = 10;
			this.label13.Text = "Sql Filter";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dataGrid2
			// 
			this.dataGrid2.DataMember = "";
			this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid2.Location = new System.Drawing.Point(12, 104);
			this.dataGrid2.Name = "dataGrid2";
			this.dataGrid2.Size = new System.Drawing.Size(648, 224);
			this.dataGrid2.TabIndex = 7;
			this.dataGrid2.Tag = "customviewwhere.default.default";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(192, 72);
			this.button4.Name = "button4";
			this.button4.TabIndex = 6;
			this.button4.Tag = "delete";
			this.button4.Text = "Delete";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(104, 72);
			this.button5.Name = "button5";
			this.button5.TabIndex = 5;
			this.button5.Tag = "edit.default";
			this.button5.Text = "Edit";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(16, 72);
			this.button6.Name = "button6";
			this.button6.TabIndex = 4;
			this.button6.Tag = "insert.default";
			this.button6.Text = "New";
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.dataGrid3,
																				   this.button7,
																				   this.button8,
																				   this.button9});
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(672, 342);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Sort";
			// 
			// dataGrid3
			// 
			this.dataGrid3.DataMember = "";
			this.dataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid3.Location = new System.Drawing.Point(16, 48);
			this.dataGrid3.Name = "dataGrid3";
			this.dataGrid3.Size = new System.Drawing.Size(648, 272);
			this.dataGrid3.TabIndex = 7;
			this.dataGrid3.Tag = "customvieworderby.default.default";
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(192, 8);
			this.button7.Name = "button7";
			this.button7.TabIndex = 6;
			this.button7.Tag = "delete";
			this.button7.Text = "Delete";
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(104, 8);
			this.button8.Name = "button8";
			this.button8.TabIndex = 5;
			this.button8.Tag = "edit.default";
			this.button8.Text = "Edit";
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(16, 8);
			this.button9.Name = "button9";
			this.button9.TabIndex = 4;
			this.button9.Tag = "insert.default";
			this.button9.Text = "New";
			// 
			// checkBox9
			// 
			this.checkBox9.Location = new System.Drawing.Point(416, 24);
			this.checkBox9.Name = "checkBox9";
			this.checkBox9.Size = new System.Drawing.Size(48, 24);
			this.checkBox9.TabIndex = 20;
			this.checkBox9.Tag = "customview.isreal:S:N";
			this.checkBox9.Text = "Real";
			// 
			// checkBox10
			// 
			this.checkBox10.Location = new System.Drawing.Point(480, 24);
			this.checkBox10.Name = "checkBox10";
			this.checkBox10.Size = new System.Drawing.Size(72, 24);
			this.checkBox10.TabIndex = 21;
			this.checkBox10.Tag = "customview.issystem:S:N";
			this.checkBox10.Text = "System";
			// 
			// textBox12
			// 
			this.textBox12.Location = new System.Drawing.Point(16, 72);
			this.textBox12.Name = "textBox12";
			this.textBox12.Size = new System.Drawing.Size(512, 20);
			this.textBox12.TabIndex = 23;
			this.textBox12.Tag = "customview.staticfilter";
			this.textBox12.Text = "";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(16, 56);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(100, 16);
			this.label12.TabIndex = 22;
			this.label12.Text = "Static filter";
			// 
			// BtnCancel
			// 
			this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.BtnCancel.Location = new System.Drawing.Point(224, 480);
			this.BtnCancel.Name = "BtnCancel";
			this.BtnCancel.TabIndex = 31;
			this.BtnCancel.Text = "Cancel";
			// 
			// BtnOk
			// 
			this.BtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.BtnOk.Location = new System.Drawing.Point(368, 480);
			this.BtnOk.Name = "BtnOk";
			this.BtnOk.Size = new System.Drawing.Size(80, 24);
			this.BtnOk.TabIndex = 30;
			this.BtnOk.Tag = "mainsave";
			this.BtnOk.Text = "Ok";
			// 
			// frmCustomView
			// 
			this.AcceptButton = this.BtnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.BtnCancel;
			this.ClientSize = new System.Drawing.Size(696, 517);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.BtnCancel,
																		  this.BtnOk,
																		  this.textBox12,
																		  this.label12,
																		  this.checkBox10,
																		  this.checkBox9,
																		  this.tabControl1,
																		  this.textBox2,
																		  this.label2,
																		  this.textBox1,
																		  this.label1});
			this.Name = "frmCustomView";
			this.Text = "frmCustomView";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.tabPage3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
			this.tabPage4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion



	
	}
}
