
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

namespace menu_default//MenuMaker//
{
	/// <summary>
	/// Summary description for frmImpostaMenu.
	/// </summary>
	public class Frm_menu_default : System.Windows.Forms.Form
	{
		public /*Rana:MenuMaker.*/vistaForm DS;
		private System.Windows.Forms.ContextMenu contextMenu1;
        private Label label9;
        private TextBox textBox9;
        private Label label8;
        private TextBox textBox8;
        private Label label7;
        private TextBox textBox7;
        private Label label3;
        private TextBox textBox6;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label2;
        private Label label1;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private System.Windows.Forms.MenuItem menuItem1;
		//private System.ComponentModel.IContainer components;

		public Frm_menu_default()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			DS.Tables["menu"].ExtendedProperties["sort_by"] = "paridmenu,ordernumber";
			
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
//				if(components != null)
//				{
//					components.Dispose();
//				}
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
            this.DS = new menu_default.vistaForm();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "Filtra SubMenu";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(324, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 16);
            this.label9.TabIndex = 59;
            this.label9.Text = "MenuCode";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(324, 25);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(120, 20);
            this.textBox9.TabIndex = 45;
            this.textBox9.Tag = "menu.menucode";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(220, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 16);
            this.label8.TabIndex = 58;
            this.label8.Text = "Order Number";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(220, 25);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(96, 20);
            this.textBox8.TabIndex = 44;
            this.textBox8.Tag = "menu.ordernumber";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(116, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 16);
            this.label7.TabIndex = 57;
            this.label7.Text = "SupID";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(116, 25);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(96, 20);
            this.textBox7.TabIndex = 43;
            this.textBox7.Tag = "menu.paridmenu";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 56;
            this.label3.Text = "ID Menu";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(12, 25);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(96, 20);
            this.textBox6.TabIndex = 42;
            this.textBox6.Tag = "menu.idmenu";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(492, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 55;
            this.label6.Text = "Parametro";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(356, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 16);
            this.label5.TabIndex = 54;
            this.label5.Text = "EditType";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(452, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 53;
            this.label4.Text = "Modale (S/N)";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(220, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 52;
            this.label2.Text = "Metadata";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 51;
            this.label1.Text = "Testo voce di menu";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(492, 73);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(224, 20);
            this.textBox5.TabIndex = 50;
            this.textBox5.Tag = "menu.parameter";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(452, 25);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(72, 20);
            this.textBox4.TabIndex = 46;
            this.textBox4.Tag = "menu.modal";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(356, 73);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(128, 20);
            this.textBox3.TabIndex = 49;
            this.textBox3.Tag = "menu.edittype";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(220, 73);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(128, 20);
            this.textBox2.TabIndex = 48;
            this.textBox2.Tag = "menu.metadata";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 73);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 20);
            this.textBox1.TabIndex = 47;
            this.textBox1.Tag = "menu.title";
            // 
            // Frm_menu_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(743, 132);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Frm_menu_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imposta Main Menu";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


		private void menuItem1_Click(object sender, System.EventArgs e) {
//			DataRow R = HelpForm.GetLastSelected(DS.menu);
//			if (R==null) return;
//			string idmenu= R["idmenu"].ToString();
//			string filter = "(id_menu='"+idmenu+"')OR(supid='"+
		}

		
	}
}
