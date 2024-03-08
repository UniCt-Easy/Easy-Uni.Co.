
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
using checkflags;//checkflags
using System.Net;

namespace license_manage//licenzausomanage//
{
	/// <summary>
	/// Summary description for FrmLicenzaUsoManage.
	/// </summary>
	public class Frm_license_manage : MetaDataForm
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.RadioButton radioButton5;
		private System.Windows.Forms.RadioButton radioButton6;
		private System.Windows.Forms.RadioButton radioButton7;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.RadioButton radioButton8;
		private System.Windows.Forms.RadioButton radioButton9;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.RadioButton radioButton10;
		private System.Windows.Forms.RadioButton radioButton11;
		private System.Windows.Forms.RadioButton radioButton12;
		private System.Windows.Forms.RadioButton radioButton13;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.RadioButton radioButton14;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ContextMenu HiddenMenu;
		private System.Windows.Forms.MenuItem MenuEnterPwd;
		bool ManagerEnabled=false;
		public /*Rana:licenzausomanage.*/vistaForm DS;
		private System.Windows.Forms.Button btnRecalc;
		private System.Windows.Forms.TextBox txtCheckLic;
		private System.Windows.Forms.TextBox txtCheckMan;
		private System.Windows.Forms.TextBox txtCheckFlag;
		public MetaData Meta;
		bool CanGoEdit;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnGetFromInternet;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox txtBackup1;
		private System.Windows.Forms.TextBox txtBackup2;
		private System.Windows.Forms.TextBox txtServer2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_license_manage()
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
			this.label2 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtCheckLic = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.radioButton14 = new System.Windows.Forms.RadioButton();
			this.radioButton7 = new System.Windows.Forms.RadioButton();
			this.radioButton6 = new System.Windows.Forms.RadioButton();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.txtCheckMan = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.radioButton10 = new System.Windows.Forms.RadioButton();
			this.radioButton11 = new System.Windows.Forms.RadioButton();
			this.radioButton12 = new System.Windows.Forms.RadioButton();
			this.radioButton13 = new System.Windows.Forms.RadioButton();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.radioButton9 = new System.Windows.Forms.RadioButton();
			this.radioButton8 = new System.Windows.Forms.RadioButton();
			this.btnGetFromInternet = new System.Windows.Forms.Button();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.txtCheckFlag = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.HiddenMenu = new System.Windows.Forms.ContextMenu();
			this.MenuEnterPwd = new System.Windows.Forms.MenuItem();
			this.DS = new /*Rana:licenzausomanage.*/vistaForm();
			this.btnRecalc = new System.Windows.Forms.Button();
			this.label10 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.txtBackup1 = new System.Windows.Forms.TextBox();
			this.txtBackup2 = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.txtServer2 = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Identificativo DB";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(112, 8);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.TabIndex = 1;
			this.textBox1.Tag = "license.iddb";
			this.textBox1.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(184, 32);
			this.label2.Name = "label2";
			this.label2.TabIndex = 2;
			this.label2.Text = "Scadenza licenza";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(184, 56);
			this.textBox2.Name = "textBox2";
			this.textBox2.TabIndex = 3;
			this.textBox2.Tag = "license.expiringlic";
			this.textBox2.Text = "";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtCheckLic);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.groupBox3);
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Controls.Add(this.textBox2);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new System.Drawing.Point(16, 40);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(432, 144);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Informazioni sulla licenza d\'uso";
			// 
			// txtCheckLic
			// 
			this.txtCheckLic.Location = new System.Drawing.Point(16, 112);
			this.txtCheckLic.Name = "txtCheckLic";
			this.txtCheckLic.Size = new System.Drawing.Size(400, 20);
			this.txtCheckLic.TabIndex = 8;
			this.txtCheckLic.Tag = "license.checklic";
			this.txtCheckLic.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 96);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(160, 16);
			this.label3.TabIndex = 7;
			this.label3.Text = "Codice di attivazione LICENZA";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.radioButton14);
			this.groupBox3.Controls.Add(this.radioButton7);
			this.groupBox3.Controls.Add(this.radioButton6);
			this.groupBox3.Controls.Add(this.radioButton5);
			this.groupBox3.Controls.Add(this.radioButton4);
			this.groupBox3.Location = new System.Drawing.Point(296, 8);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(120, 104);
			this.groupBox3.TabIndex = 6;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Stato della licenza";
			// 
			// radioButton14
			// 
			this.radioButton14.Location = new System.Drawing.Point(8, 80);
			this.radioButton14.Name = "radioButton14";
			this.radioButton14.Size = new System.Drawing.Size(88, 16);
			this.radioButton14.TabIndex = 9;
			this.radioButton14.Tag = "license.licstatus:G";
			this.radioButton14.Text = "Giornaliero";
			// 
			// radioButton7
			// 
			this.radioButton7.Location = new System.Drawing.Point(8, 64);
			this.radioButton7.Name = "radioButton7";
			this.radioButton7.Size = new System.Drawing.Size(88, 16);
			this.radioButton7.TabIndex = 8;
			this.radioButton7.Tag = "license.licstatus:N";
			this.radioButton7.Text = "Non ordinata";
			// 
			// radioButton6
			// 
			this.radioButton6.Location = new System.Drawing.Point(8, 48);
			this.radioButton6.Name = "radioButton6";
			this.radioButton6.Size = new System.Drawing.Size(88, 16);
			this.radioButton6.TabIndex = 7;
			this.radioButton6.Tag = "license.licstatus:P";
			this.radioButton6.Text = "Pagata";
			// 
			// radioButton5
			// 
			this.radioButton5.Location = new System.Drawing.Point(8, 32);
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.Size = new System.Drawing.Size(88, 16);
			this.radioButton5.TabIndex = 6;
			this.radioButton5.Tag = "license.licstatus:O";
			this.radioButton5.Text = "Ordinata";
			// 
			// radioButton4
			// 
			this.radioButton4.Location = new System.Drawing.Point(8, 16);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(88, 16);
			this.radioButton4.TabIndex = 5;
			this.radioButton4.Tag = "license.licstatus:B";
			this.radioButton4.Text = "Bloccata";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.radioButton3);
			this.groupBox2.Controls.Add(this.radioButton2);
			this.groupBox2.Controls.Add(this.radioButton1);
			this.groupBox2.Location = new System.Drawing.Point(16, 16);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(160, 72);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Tipo licenza";
			// 
			// radioButton3
			// 
			this.radioButton3.Location = new System.Drawing.Point(8, 48);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(104, 16);
			this.radioButton3.TabIndex = 6;
			this.radioButton3.Tag = "license.lickind:O";
			this.radioButton3.Text = "Non in regola";
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(8, 32);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(104, 16);
			this.radioButton2.TabIndex = 5;
			this.radioButton2.Tag = "license.lickind:L";
			this.radioButton2.Text = "Licenza";
			// 
			// radioButton1
			// 
			this.radioButton1.Location = new System.Drawing.Point(8, 16);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(104, 16);
			this.radioButton1.TabIndex = 4;
			this.radioButton1.Tag = "license.lickind:C";
			this.radioButton1.Text = "Canone annuo";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.txtCheckMan);
			this.groupBox4.Controls.Add(this.label5);
			this.groupBox4.Controls.Add(this.groupBox6);
			this.groupBox4.Controls.Add(this.textBox4);
			this.groupBox4.Controls.Add(this.label4);
			this.groupBox4.Controls.Add(this.groupBox5);
			this.groupBox4.Location = new System.Drawing.Point(16, 192);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(432, 136);
			this.groupBox4.TabIndex = 5;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Informazioni sulla manutenzione del software";
			// 
			// txtCheckMan
			// 
			this.txtCheckMan.Location = new System.Drawing.Point(8, 104);
			this.txtCheckMan.Name = "txtCheckMan";
			this.txtCheckMan.Size = new System.Drawing.Size(400, 20);
			this.txtCheckMan.TabIndex = 10;
			this.txtCheckMan.Tag = "license.checkman";
			this.txtCheckMan.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 88);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(232, 16);
			this.label5.TabIndex = 9;
			this.label5.Text = "Codice di attivazione MANUTENZIONE";
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.radioButton10);
			this.groupBox6.Controls.Add(this.radioButton11);
			this.groupBox6.Controls.Add(this.radioButton12);
			this.groupBox6.Controls.Add(this.radioButton13);
			this.groupBox6.Location = new System.Drawing.Point(248, 8);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(152, 88);
			this.groupBox6.TabIndex = 7;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Stato della manutenzione";
			// 
			// radioButton10
			// 
			this.radioButton10.Location = new System.Drawing.Point(8, 64);
			this.radioButton10.Name = "radioButton10";
			this.radioButton10.Size = new System.Drawing.Size(88, 16);
			this.radioButton10.TabIndex = 8;
			this.radioButton10.Tag = "license.manstatus:N";
			this.radioButton10.Text = "Non ordinata";
			// 
			// radioButton11
			// 
			this.radioButton11.Location = new System.Drawing.Point(8, 48);
			this.radioButton11.Name = "radioButton11";
			this.radioButton11.Size = new System.Drawing.Size(88, 16);
			this.radioButton11.TabIndex = 7;
			this.radioButton11.Tag = "license.manstatus:P";
			this.radioButton11.Text = "Pagata";
			// 
			// radioButton12
			// 
			this.radioButton12.Location = new System.Drawing.Point(8, 32);
			this.radioButton12.Name = "radioButton12";
			this.radioButton12.Size = new System.Drawing.Size(88, 16);
			this.radioButton12.TabIndex = 6;
			this.radioButton12.Tag = "license.manstatus:O";
			this.radioButton12.Text = "Ordinata";
			// 
			// radioButton13
			// 
			this.radioButton13.Location = new System.Drawing.Point(8, 16);
			this.radioButton13.Name = "radioButton13";
			this.radioButton13.Size = new System.Drawing.Size(88, 16);
			this.radioButton13.TabIndex = 5;
			this.radioButton13.Tag = "license.manstatus:B";
			this.radioButton13.Text = "Bloccata";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(136, 56);
			this.textBox4.Name = "textBox4";
			this.textBox4.TabIndex = 5;
			this.textBox4.Tag = "license.expiringman";
			this.textBox4.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(136, 32);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(104, 23);
			this.label4.TabIndex = 4;
			this.label4.Text = "Scadenza manutenzione";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.radioButton9);
			this.groupBox5.Controls.Add(this.radioButton8);
			this.groupBox5.Location = new System.Drawing.Point(8, 16);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(120, 64);
			this.groupBox5.TabIndex = 0;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Tipo manutenzione";
			// 
			// radioButton9
			// 
			this.radioButton9.Location = new System.Drawing.Point(8, 32);
			this.radioButton9.Name = "radioButton9";
			this.radioButton9.Size = new System.Drawing.Size(96, 24);
			this.radioButton9.TabIndex = 1;
			this.radioButton9.Tag = "license.mankind:O";
			this.radioButton9.Text = "Non in regola";
			// 
			// radioButton8
			// 
			this.radioButton8.Location = new System.Drawing.Point(8, 16);
			this.radioButton8.Name = "radioButton8";
			this.radioButton8.Size = new System.Drawing.Size(96, 24);
			this.radioButton8.TabIndex = 0;
			this.radioButton8.Tag = "license.mankind:C";
			this.radioButton8.Text = "Canone annuo";
			// 
			// btnGetFromInternet
			// 
			this.btnGetFromInternet.Location = new System.Drawing.Point(224, 8);
			this.btnGetFromInternet.Name = "btnGetFromInternet";
			this.btnGetFromInternet.Size = new System.Drawing.Size(200, 23);
			this.btnGetFromInternet.TabIndex = 6;
			this.btnGetFromInternet.Text = "Aggiorna le informazioni da internet";
			this.btnGetFromInternet.Click += new System.EventHandler(this.btnGetFromInternet_Click);
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.txtCheckFlag);
			this.groupBox7.Controls.Add(this.label8);
			this.groupBox7.Controls.Add(this.textBox7);
			this.groupBox7.Controls.Add(this.label7);
			this.groupBox7.Controls.Add(this.textBox6);
			this.groupBox7.Controls.Add(this.label6);
			this.groupBox7.Location = new System.Drawing.Point(16, 336);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(432, 112);
			this.groupBox7.TabIndex = 7;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Estensione della licenza";
			// 
			// txtCheckFlag
			// 
			this.txtCheckFlag.Location = new System.Drawing.Point(8, 80);
			this.txtCheckFlag.Name = "txtCheckFlag";
			this.txtCheckFlag.Size = new System.Drawing.Size(400, 20);
			this.txtCheckFlag.TabIndex = 10;
			this.txtCheckFlag.Tag = "license.checkflag";
			this.txtCheckFlag.Text = "";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(8, 64);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(256, 16);
			this.label8.TabIndex = 9;
			this.label8.Text = "Codice di attivazione dell\'estensione";
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(120, 40);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(128, 20);
			this.textBox7.TabIndex = 3;
			this.textBox7.Tag = "license.swmoreflag";
			this.textBox7.Text = "";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 40);
			this.label7.Name = "label7";
			this.label7.TabIndex = 2;
			this.label7.Text = "N.Max Client";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(120, 16);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(128, 20);
			this.textBox6.TabIndex = 1;
			this.textBox6.Tag = "license.swmorecode";
			this.textBox6.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 16);
			this.label6.TabIndex = 0;
			this.label6.Text = "Moduli attivi";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnOk
			// 
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(280, 456);
			this.btnOk.Name = "btnOk";
			this.btnOk.TabIndex = 8;
			this.btnOk.Tag = "mainsave";
			this.btnOk.Text = "Ok";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(368, 456);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 9;
			this.btnCancel.Text = "Annulla";
			// 
			// label9
			// 
			this.label9.ContextMenu = this.HiddenMenu;
			this.label9.Location = new System.Drawing.Point(8, 432);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(8, 8);
			this.label9.TabIndex = 10;
			// 
			// HiddenMenu
			// 
			this.HiddenMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.MenuEnterPwd});
			// 
			// MenuEnterPwd
			// 
			this.MenuEnterPwd.Index = 0;
			this.MenuEnterPwd.Text = "Enter password";
			this.MenuEnterPwd.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// btnRecalc
			// 
			this.btnRecalc.Location = new System.Drawing.Point(16, 456);
			this.btnRecalc.Name = "btnRecalc";
			this.btnRecalc.TabIndex = 11;
			this.btnRecalc.Text = "Recalc";
			this.btnRecalc.Visible = false;
			this.btnRecalc.Click += new System.EventHandler(this.btnRecalc_Click);
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(464, 48);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(152, 16);
			this.label10.TabIndex = 12;
			this.label10.Text = "Server di Backup (1)";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(464, 64);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(152, 20);
			this.textBox3.TabIndex = 13;
			this.textBox3.Tag = "license.serverbackup1";
			this.textBox3.Text = "";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(464, 96);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(160, 16);
			this.label11.TabIndex = 14;
			this.label11.Text = "Codice Attivazione Backup(1)";
			// 
			// txtBackup1
			// 
			this.txtBackup1.Location = new System.Drawing.Point(464, 112);
			this.txtBackup1.Multiline = true;
			this.txtBackup1.Name = "txtBackup1";
			this.txtBackup1.Size = new System.Drawing.Size(152, 48);
			this.txtBackup1.TabIndex = 15;
			this.txtBackup1.Tag = "license.checkbackup1";
			this.txtBackup1.Text = "";
			// 
			// txtBackup2
			// 
			this.txtBackup2.Location = new System.Drawing.Point(456, 264);
			this.txtBackup2.Multiline = true;
			this.txtBackup2.Name = "txtBackup2";
			this.txtBackup2.Size = new System.Drawing.Size(152, 48);
			this.txtBackup2.TabIndex = 19;
			this.txtBackup2.Tag = "license.checkbackup2";
			this.txtBackup2.Text = "";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(456, 248);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(160, 16);
			this.label12.TabIndex = 18;
			this.label12.Text = "Codice Attivazione Backup(2)";
			// 
			// txtServer2
			// 
			this.txtServer2.Location = new System.Drawing.Point(456, 216);
			this.txtServer2.Name = "txtServer2";
			this.txtServer2.Size = new System.Drawing.Size(152, 20);
			this.txtServer2.TabIndex = 17;
			this.txtServer2.Tag = "license.serverbackup2";
			this.txtServer2.Text = "";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(456, 200);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(152, 16);
			this.label13.TabIndex = 16;
			this.label13.Text = "Server di Backup (2)";
			// 
			// FrmLicenzaUsoManage
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(634, 567);
			this.Controls.Add(this.txtBackup2);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.txtServer2);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.txtBackup1);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.btnRecalc);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.groupBox7);
			this.Controls.Add(this.btnGetFromInternet);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FrmLicenzaUsoManage";
			this.Text = "FrmLicenzaUsoManage";
			this.groupBox1.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void menuItem1_Click(object sender, System.EventArgs e) {
			Frm_Password f = new Frm_Password(1);
            createForm(f, null);
            if (f.ShowDialog()!=DialogResult.OK) return;
			ManagerEnabled=true;
			btnRecalc.Visible=true;
			
			
		}
		public void MetaData_AfterLink(){
			Meta= MetaData.GetMetaData(this);
			Meta.CanInsert=false;
			CanGoEdit=true;
		}
		public void MetaData_AfterClear() {
			if (CanGoEdit) {
				CanGoEdit=false;
				MetaData.DoMainCommand(this, "maindosearch.licenzauso");
			}
		}
		

		private void btnRecalc_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
			if (!ManagerEnabled) return;
			Meta.GetFormData(true);

			DataRow R= DS.license.Rows[0];

			// Calcola il codice di attivazione Licenza
			txtCheckLic.Text= CheckFlags.CalcolaCheckLic(R);
			
			// Calcola il codice di attivazione Manutenzione
			txtCheckMan.Text= CheckFlags.CalcolaCheckMan(R);

			// Calcola il codice di attivazione Estensione
			txtCheckFlag.Text= CheckFlags.CalcolaCheckFlag(R);

			txtBackup1.Text= CheckFlags.CalcolaCheckBackup1(R);
			txtBackup2.Text= CheckFlags.CalcolaCheckBackup2(R);

		}

		bool DontSend=false;
		private void btnGetFromInternet_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
			btnGetFromInternet.Enabled=false;
			btnGetFromInternet.Visible=false;
			Meta.GetFormData(true);
			DataRow R= DS.license.Rows[0];
			if (!CheckFlags.GetFromInternet(R,Meta.Conn)) return;
			DontSend=true;
			Meta.SaveFormData();
			DontSend=false;

			
		}


		public void MetaData_AfterPost(){
			if (DS.license.Rows.Count==0) return;
			if (!DontSend) CheckFlags.SendToInternet(Meta.Conn,DS);
			
		
			//MetaFactory.factory.getSingleton<IMessageShower>().Show( CfgFn.GetNoNullInt32(resp).ToString());			


		}
		


	}
}
