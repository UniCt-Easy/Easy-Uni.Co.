
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

namespace position_lista//qualificalista//
{
	/// <summary>
	/// Summary description for /*Rana:qualificalista.*/
	/// </summary>
	//Modified by Leo, 5/2/2003
	public class Frm_position_lista : MetaDataForm
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
        public vistaForm DS;
		private System.Windows.Forms.ImageList images;
		public System.Windows.Forms.TextBox TxtDescr;
        private CheckBox checkBox1;
        private Label label2;
        private TextBox textBox1;
		private TabControl tabControl;
		private TabPage tabPage1;
		private TabPage tabPage2;
		private Label label15;
		private TextBox textBox14;
		private Label label14;
		private TextBox textBox13;
		private Label label13;
		private TextBox textBox12;
		private Label label12;
		private TextBox textBox11;
		private Label label7;
		private TextBox textBox6;
		private Label label6;
		private TextBox textBox4;
		private Label label16;
		private TextBox textBox15;
		private Label label23;
		private TextBox textBox22;
		private Label label22;
		private TextBox textBox21;
		private Label label21;
		private TextBox textBox20;
		private Label label20;
		private TextBox textBox19;
		private Label label19;
		private TextBox textBox18;
		private Label label18;
		private TextBox textBox17;
		private Label label17;
		private TextBox textBox16;
		private CheckBox checkBox6;
		private CheckBox checkBox5;
		private CheckBox checkBox4;
		private CheckBox checkBox3;
		private CheckBox checkBox2;
		private GroupBox groupBox1;
		private RadioButton radioButton3;
		private RadioButton radioButton2;
		private RadioButton radioButton1;
		private CheckBox checkBox12;
		private CheckBox checkBox9;
		private CheckBox checkBox10;
		private CheckBox checkBox11;
		private Label label10;
		private TextBox textBox9;
		private Label label8;
		private TextBox textBox7;
		private CheckBox checkBox8;
		private CheckBox checkBox7;
		private Label label9;
		private TextBox textBox8;
		private Label label5;
		private TextBox textBox3;
		private Label label11;
		private TextBox textBox10;
		private System.ComponentModel.IContainer components;

		public Frm_position_lista()
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
			bool IsAdmin=false;

			MetaData Meta = MetaData.GetMetaData(this);
			if (Meta.GetSys("manage_prestazioni")!=null) 
				IsAdmin=(Meta.GetSys("manage_prestazioni").ToString()=="S");
			Meta.CanSave=IsAdmin;
			Meta.CanInsert=IsAdmin;
			Meta.CanInsertCopy=IsAdmin;
			Meta.CanCancel=IsAdmin;
            HelpForm.SetDenyNull(DS.position.Columns["active"], true);
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_position_lista));
			this.label1 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.TxtDescr = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.images = new System.Windows.Forms.ImageList(this.components);
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.DS = new position_lista.vistaForm();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.textBox11 = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.textBox12 = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.textBox13 = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.textBox14 = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.textBox15 = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.textBox16 = new System.Windows.Forms.TextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.textBox17 = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.textBox18 = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.textBox19 = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.textBox20 = new System.Windows.Forms.TextBox();
			this.label22 = new System.Windows.Forms.Label();
			this.textBox21 = new System.Windows.Forms.TextBox();
			this.label23 = new System.Windows.Forms.Label();
			this.textBox22 = new System.Windows.Forms.TextBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.checkBox5 = new System.Windows.Forms.CheckBox();
			this.checkBox6 = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.checkBox7 = new System.Windows.Forms.CheckBox();
			this.checkBox8 = new System.Windows.Forms.CheckBox();
			this.label8 = new System.Windows.Forms.Label();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.checkBox9 = new System.Windows.Forms.CheckBox();
			this.checkBox10 = new System.Windows.Forms.CheckBox();
			this.checkBox11 = new System.Windows.Forms.CheckBox();
			this.checkBox12 = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.label11 = new System.Windows.Forms.Label();
			this.textBox10 = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.tabControl.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(28, 46);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(84, 13);
			this.label1.TabIndex = 33;
			this.label1.Text = "Codice Qualifica";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(237, 66);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(100, 20);
			this.textBox2.TabIndex = 2;
			this.textBox2.Tag = "position.maxincomeclass";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(31, 66);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(100, 20);
			this.textBox5.TabIndex = 1;
			this.textBox5.Tag = "position.codeposition";
			// 
			// TxtDescr
			// 
			this.TxtDescr.Location = new System.Drawing.Point(31, 140);
			this.TxtDescr.Multiline = true;
			this.TxtDescr.Name = "TxtDescr";
			this.TxtDescr.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TxtDescr.Size = new System.Drawing.Size(766, 93);
			this.TxtDescr.TabIndex = 4;
			this.TxtDescr.Tag = "position.description";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(31, 121);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 16);
			this.label3.TabIndex = 39;
			this.label3.Text = "Descrizione";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(234, 46);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(187, 13);
			this.label4.TabIndex = 40;
			this.label4.Text = "Massima classe stipendiale applicabile";
			this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// images
			// 
			this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
			this.images.TransparentColor = System.Drawing.Color.Transparent;
			this.images.Images.SetKeyName(0, "");
			this.images.Images.SetKeyName(1, "");
			this.images.Images.SetKeyName(2, "");
			this.images.Images.SetKeyName(3, "");
			this.images.Images.SetKeyName(4, "");
			this.images.Images.SetKeyName(5, "");
			this.images.Images.SetKeyName(6, "");
			this.images.Images.SetKeyName(7, "");
			this.images.Images.SetKeyName(8, "");
			this.images.Images.SetKeyName(9, "");
			this.images.Images.SetKeyName(10, "");
			this.images.Images.SetKeyName(11, "");
			this.images.Images.SetKeyName(12, "");
			this.images.Images.SetKeyName(13, "");
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(31, 97);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(229, 13);
			this.label2.TabIndex = 44;
			this.label2.Text = "Classe di appartenenza per le missioni all\'estero";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(284, 94);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(53, 20);
			this.textBox1.TabIndex = 3;
			this.textBox1.Tag = "position.foreignclass";
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(744, 249);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(53, 17);
			this.checkBox1.TabIndex = 42;
			this.checkBox1.Tag = "position.active:S:N";
			this.checkBox1.Text = "Attivo";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPage1);
			this.tabControl.Controls.Add(this.tabPage2);
			this.tabControl.Location = new System.Drawing.Point(13, 13);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(822, 572);
			this.tabControl.TabIndex = 54;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.textBox1);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.checkBox1);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.TxtDescr);
			this.tabPage1.Controls.Add(this.textBox5);
			this.tabPage1.Controls.Add(this.textBox2);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(814, 546);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Principale";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.label11);
			this.tabPage2.Controls.Add(this.textBox10);
			this.tabPage2.Controls.Add(this.groupBox1);
			this.tabPage2.Controls.Add(this.checkBox12);
			this.tabPage2.Controls.Add(this.checkBox9);
			this.tabPage2.Controls.Add(this.checkBox10);
			this.tabPage2.Controls.Add(this.checkBox11);
			this.tabPage2.Controls.Add(this.label10);
			this.tabPage2.Controls.Add(this.textBox9);
			this.tabPage2.Controls.Add(this.label8);
			this.tabPage2.Controls.Add(this.textBox7);
			this.tabPage2.Controls.Add(this.checkBox8);
			this.tabPage2.Controls.Add(this.checkBox7);
			this.tabPage2.Controls.Add(this.label9);
			this.tabPage2.Controls.Add(this.textBox8);
			this.tabPage2.Controls.Add(this.label5);
			this.tabPage2.Controls.Add(this.textBox3);
			this.tabPage2.Controls.Add(this.checkBox6);
			this.tabPage2.Controls.Add(this.checkBox5);
			this.tabPage2.Controls.Add(this.checkBox4);
			this.tabPage2.Controls.Add(this.checkBox3);
			this.tabPage2.Controls.Add(this.checkBox2);
			this.tabPage2.Controls.Add(this.label23);
			this.tabPage2.Controls.Add(this.textBox22);
			this.tabPage2.Controls.Add(this.label22);
			this.tabPage2.Controls.Add(this.textBox21);
			this.tabPage2.Controls.Add(this.label21);
			this.tabPage2.Controls.Add(this.textBox20);
			this.tabPage2.Controls.Add(this.label20);
			this.tabPage2.Controls.Add(this.textBox19);
			this.tabPage2.Controls.Add(this.label19);
			this.tabPage2.Controls.Add(this.textBox18);
			this.tabPage2.Controls.Add(this.label18);
			this.tabPage2.Controls.Add(this.textBox17);
			this.tabPage2.Controls.Add(this.label17);
			this.tabPage2.Controls.Add(this.textBox16);
			this.tabPage2.Controls.Add(this.label16);
			this.tabPage2.Controls.Add(this.textBox15);
			this.tabPage2.Controls.Add(this.label15);
			this.tabPage2.Controls.Add(this.textBox14);
			this.tabPage2.Controls.Add(this.label14);
			this.tabPage2.Controls.Add(this.textBox13);
			this.tabPage2.Controls.Add(this.label13);
			this.tabPage2.Controls.Add(this.textBox12);
			this.tabPage2.Controls.Add(this.label12);
			this.tabPage2.Controls.Add(this.textBox11);
			this.tabPage2.Controls.Add(this.label7);
			this.tabPage2.Controls.Add(this.textBox6);
			this.tabPage2.Controls.Add(this.label6);
			this.tabPage2.Controls.Add(this.textBox4);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(814, 546);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Altri Dati";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(160, 274);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(93, 13);
			this.label6.TabIndex = 3;
			this.label6.Text = "Costo lordo annuo";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(275, 271);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(108, 20);
			this.textBox4.TabIndex = 2;
			this.textBox4.Tag = "position.costolordoannuo";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(539, 274);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(128, 13);
			this.label7.TabIndex = 5;
			this.label7.Text = "Costo lordo annuo e oneri";
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(690, 271);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(108, 20);
			this.textBox6.TabIndex = 4;
			this.textBox6.Tag = "position.costolordoannuooneri";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(423, 95);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(245, 13);
			this.label12.TabIndex = 15;
			this.label12.Text = "Ore massime per i compiti didattici a tempo parziale";
			// 
			// textBox11
			// 
			this.textBox11.Location = new System.Drawing.Point(690, 88);
			this.textBox11.Name = "textBox11";
			this.textBox11.Size = new System.Drawing.Size(108, 20);
			this.textBox11.TabIndex = 14;
			this.textBox11.Tag = "position.oremaxcompitididatempoparziale";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(21, 91);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(235, 13);
			this.label13.TabIndex = 17;
			this.label13.Text = "Ore massime per i compiti didattici a tempo pieno";
			// 
			// textBox12
			// 
			this.textBox12.Location = new System.Drawing.Point(275, 88);
			this.textBox12.Name = "textBox12";
			this.textBox12.Size = new System.Drawing.Size(108, 20);
			this.textBox12.TabIndex = 16;
			this.textBox12.Tag = "position.oremaxcompitididatempopieno";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(422, 164);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(246, 13);
			this.label14.TabIndex = 19;
			this.label14.Text = "Ore massime per didattica frontale a tempo parziale";
			// 
			// textBox13
			// 
			this.textBox13.Location = new System.Drawing.Point(691, 155);
			this.textBox13.Name = "textBox13";
			this.textBox13.Size = new System.Drawing.Size(108, 20);
			this.textBox13.TabIndex = 18;
			this.textBox13.Tag = "position.oremaxdidatempoparziale";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(17, 160);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(236, 13);
			this.label15.TabIndex = 21;
			this.label15.Text = "Ore massime per didattica frontale a tempo pieno";
			// 
			// textBox14
			// 
			this.textBox14.Location = new System.Drawing.Point(275, 157);
			this.textBox14.Name = "textBox14";
			this.textBox14.Size = new System.Drawing.Size(108, 20);
			this.textBox14.TabIndex = 20;
			this.textBox14.Tag = "position.oremaxdidatempopieno";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(516, 232);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(153, 13);
			this.label16.TabIndex = 23;
			this.label16.Text = "Ore massime di lavoro al giorno";
			// 
			// textBox15
			// 
			this.textBox15.Location = new System.Drawing.Point(691, 229);
			this.textBox15.Name = "textBox15";
			this.textBox15.Size = new System.Drawing.Size(108, 20);
			this.textBox15.TabIndex = 22;
			this.textBox15.Tag = "position.oremaxgg";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(521, 24);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(147, 13);
			this.label17.TabIndex = 25;
			this.label17.Text = "Ore massime a tempo parziale";
			// 
			// textBox16
			// 
			this.textBox16.Location = new System.Drawing.Point(691, 21);
			this.textBox16.Name = "textBox16";
			this.textBox16.Size = new System.Drawing.Size(108, 20);
			this.textBox16.TabIndex = 24;
			this.textBox16.Tag = "position.oremaxtempoparziale";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(118, 24);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(137, 13);
			this.label18.TabIndex = 27;
			this.label18.Text = "Ore massime a tempo pieno";
			// 
			// textBox17
			// 
			this.textBox17.Location = new System.Drawing.Point(275, 21);
			this.textBox17.Name = "textBox17";
			this.textBox17.Size = new System.Drawing.Size(108, 20);
			this.textBox17.TabIndex = 26;
			this.textBox17.Tag = "position.oremaxtempopieno";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(431, 119);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(237, 13);
			this.label19.TabIndex = 29;
			this.label19.Text = "Ore minime per i compiti didattici a tempo parziale";
			// 
			// textBox18
			// 
			this.textBox18.Location = new System.Drawing.Point(691, 116);
			this.textBox18.Name = "textBox18";
			this.textBox18.Size = new System.Drawing.Size(108, 20);
			this.textBox18.TabIndex = 28;
			this.textBox18.Tag = "position.oremincompitididatempoparziale";
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(34, 119);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(227, 13);
			this.label20.TabIndex = 31;
			this.label20.Text = "Ore minime per i compiti didattici a tempo pieno";
			// 
			// textBox19
			// 
			this.textBox19.Location = new System.Drawing.Point(275, 113);
			this.textBox19.Name = "textBox19";
			this.textBox19.Size = new System.Drawing.Size(108, 20);
			this.textBox19.TabIndex = 30;
			this.textBox19.Tag = "position.oremincompitididatempopieno";
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(439, 185);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(231, 13);
			this.label21.TabIndex = 33;
			this.label21.Text = "Ore minime di didattica frontale a tempo parziale";
			// 
			// textBox20
			// 
			this.textBox20.Location = new System.Drawing.Point(690, 182);
			this.textBox20.Name = "textBox20";
			this.textBox20.Size = new System.Drawing.Size(108, 20);
			this.textBox20.TabIndex = 32;
			this.textBox20.Tag = "position.oremindidatempoparziale";
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(28, 184);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(221, 13);
			this.label22.TabIndex = 35;
			this.label22.Text = "Ore minime di didattica frontale a tempo pieno";
			// 
			// textBox21
			// 
			this.textBox21.Location = new System.Drawing.Point(275, 182);
			this.textBox21.Name = "textBox21";
			this.textBox21.Size = new System.Drawing.Size(108, 20);
			this.textBox21.TabIndex = 34;
			this.textBox21.Tag = "position.oremindidatempopieno";
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(127, 50);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(129, 13);
			this.label23.TabIndex = 37;
			this.label23.Text = "Ore minime a tempo pieno";
			// 
			// textBox22
			// 
			this.textBox22.Location = new System.Drawing.Point(275, 48);
			this.textBox22.Name = "textBox22";
			this.textBox22.Size = new System.Drawing.Size(108, 20);
			this.textBox22.TabIndex = 36;
			this.textBox22.Tag = "position.oremintempopieno";
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(29, 345);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(159, 17);
			this.checkBox2.TabIndex = 38;
			this.checkBox2.Tag = "position.elementoperequativo:S:N";
			this.checkBox2.Text = "Abilita elemento perequativo";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// checkBox3
			// 
			this.checkBox3.AutoSize = true;
			this.checkBox3.Location = new System.Drawing.Point(295, 342);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(158, 17);
			this.checkBox3.TabIndex = 39;
			this.checkBox3.Tag = "position.indennitadiposizione:S:N";
			this.checkBox3.Text = "Abilita indennità di posizione";
			this.checkBox3.UseVisualStyleBackColor = true;
			// 
			// checkBox4
			// 
			this.checkBox4.AutoSize = true;
			this.checkBox4.Location = new System.Drawing.Point(29, 368);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(147, 17);
			this.checkBox4.TabIndex = 40;
			this.checkBox4.Tag = "position.indennitadiateneo:S:N";
			this.checkBox4.Text = "Abilita indennità di ateneo";
			this.checkBox4.UseVisualStyleBackColor = true;
			// 
			// checkBox5
			// 
			this.checkBox5.AutoSize = true;
			this.checkBox5.Location = new System.Drawing.Point(295, 365);
			this.checkBox5.Name = "checkBox5";
			this.checkBox5.Size = new System.Drawing.Size(174, 17);
			this.checkBox5.TabIndex = 41;
			this.checkBox5.Tag = "position.indvacancacontrattuale:S:N";
			this.checkBox5.Text = "Indennità vacanca contrattuale";
			this.checkBox5.UseVisualStyleBackColor = true;
			// 
			// checkBox6
			// 
			this.checkBox6.AutoSize = true;
			this.checkBox6.Location = new System.Drawing.Point(524, 345);
			this.checkBox6.Name = "checkBox6";
			this.checkBox6.Size = new System.Drawing.Size(149, 17);
			this.checkBox6.TabIndex = 42;
			this.checkBox6.Tag = "position.assegnoaggiuntivo:S:N";
			this.checkBox6.Text = "Abilita assegno aggiuntivo";
			this.checkBox6.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(53, 228);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(203, 13);
			this.label5.TabIndex = 44;
			this.label5.Text = "Ore massime di straordinario rendicontabili";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(275, 225);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(108, 20);
			this.textBox3.TabIndex = 43;
			this.textBox3.Tag = "position.orestraordinariemax";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(26, 431);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(75, 13);
			this.label9.TabIndex = 48;
			this.label9.Text = "Punti organico";
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(121, 428);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(108, 20);
			this.textBox8.TabIndex = 47;
			this.textBox8.Tag = "position.puntiorganico.N";
			// 
			// checkBox7
			// 
			this.checkBox7.AutoSize = true;
			this.checkBox7.Location = new System.Drawing.Point(524, 319);
			this.checkBox7.Name = "checkBox7";
			this.checkBox7.Size = new System.Drawing.Size(127, 17);
			this.checkBox7.TabIndex = 49;
			this.checkBox7.Tag = "position.livello:S:N";
			this.checkBox7.Text = "Abilita scatti stipendio";
			this.checkBox7.UseVisualStyleBackColor = true;
			// 
			// checkBox8
			// 
			this.checkBox8.AutoSize = true;
			this.checkBox8.Location = new System.Drawing.Point(29, 322);
			this.checkBox8.Name = "checkBox8";
			this.checkBox8.Size = new System.Drawing.Size(97, 17);
			this.checkBox8.TabIndex = 50;
			this.checkBox8.Tag = "position.parttime:S:N";
			this.checkBox8.Text = "Abilita part-time";
			this.checkBox8.UseVisualStyleBackColor = true;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(565, 521);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(93, 13);
			this.label8.TabIndex = 52;
			this.label8.Text = "Sigla esportazione";
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(690, 513);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(108, 20);
			this.textBox7.TabIndex = 51;
			this.textBox7.Tag = "position.siglaesportazione";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(28, 520);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(92, 13);
			this.label10.TabIndex = 54;
			this.label10.Text = "Sigla importazione";
			// 
			// textBox9
			// 
			this.textBox9.Location = new System.Drawing.Point(137, 517);
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new System.Drawing.Size(108, 20);
			this.textBox9.TabIndex = 53;
			this.textBox9.Tag = "position.siglaimportazione";
			// 
			// checkBox9
			// 
			this.checkBox9.AutoSize = true;
			this.checkBox9.Location = new System.Drawing.Point(295, 388);
			this.checkBox9.Name = "checkBox9";
			this.checkBox9.Size = new System.Drawing.Size(139, 17);
			this.checkBox9.TabIndex = 57;
			this.checkBox9.Tag = "position.totaletredicesima:S:N";
			this.checkBox9.Text = "Abilita totale tredicesima";
			this.checkBox9.UseVisualStyleBackColor = true;
			// 
			// checkBox10
			// 
			this.checkBox10.AutoSize = true;
			this.checkBox10.Location = new System.Drawing.Point(295, 319);
			this.checkBox10.Name = "checkBox10";
			this.checkBox10.Size = new System.Drawing.Size(171, 17);
			this.checkBox10.TabIndex = 56;
			this.checkBox10.Tag = "position.tempdef:S:N";
			this.checkBox10.Text = "Abilita tempo definito o parziale";
			this.checkBox10.UseVisualStyleBackColor = true;
			// 
			// checkBox11
			// 
			this.checkBox11.AutoSize = true;
			this.checkBox11.Location = new System.Drawing.Point(29, 388);
			this.checkBox11.Name = "checkBox11";
			this.checkBox11.Size = new System.Drawing.Size(250, 17);
			this.checkBox11.TabIndex = 55;
			this.checkBox11.Tag = "position.tredicesimaindennitaintegrativaspeciale:S:N";
			this.checkBox11.Text = "Abilita tredicesima indennità integrativa speciale";
			this.checkBox11.UseVisualStyleBackColor = true;
			// 
			// checkBox12
			// 
			this.checkBox12.AutoSize = true;
			this.checkBox12.Location = new System.Drawing.Point(524, 368);
			this.checkBox12.Name = "checkBox12";
			this.checkBox12.Size = new System.Drawing.Size(103, 17);
			this.checkBox12.TabIndex = 58;
			this.checkBox12.Tag = "position.tipoente:A:U";
			this.checkBox12.Text = "Tipo ente AFAM";
			this.checkBox12.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButton3);
			this.groupBox1.Controls.Add(this.radioButton2);
			this.groupBox1.Controls.Add(this.radioButton1);
			this.groupBox1.Location = new System.Drawing.Point(29, 454);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(415, 53);
			this.groupBox1.TabIndex = 59;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Categoria di personale";
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point(19, 27);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(66, 17);
			this.radioButton1.TabIndex = 0;
			this.radioButton1.TabStop = true;
			this.radioButton1.Tag = "position.tipopersonale:D";
			this.radioButton1.Text = "Docente";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(98, 27);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(179, 17);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.TabStop = true;
			this.radioButton2.Tag = "position.tipopersonale:P";
			this.radioButton2.Text = "Personale tecnico-amministrativo";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new System.Drawing.Point(310, 24);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(80, 17);
			this.radioButton3.TabIndex = 2;
			this.radioButton3.TabStop = true;
			this.radioButton3.Tag = "position.tipopersonale:R";
			this.radioButton3.Text = "Ricercatore";
			this.radioButton3.UseVisualStyleBackColor = true;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(530, 48);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(139, 13);
			this.label11.TabIndex = 61;
			this.label11.Text = "Ore minime a tempo parziale";
			// 
			// textBox10
			// 
			this.textBox10.Location = new System.Drawing.Point(691, 47);
			this.textBox10.Name = "textBox10";
			this.textBox10.Size = new System.Drawing.Size(108, 20);
			this.textBox10.TabIndex = 60;
			this.textBox10.Tag = "position.oremintempoparziale";
			// 
			// Frm_position_lista
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(841, 588);
			this.Controls.Add(this.tabControl);
			this.Name = "Frm_position_lista";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Qualifica";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.tabControl.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion

        private void dataGrid1_Navigate(object sender, NavigateEventArgs ne)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

		

		
	}
}
