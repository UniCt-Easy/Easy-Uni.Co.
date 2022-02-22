
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

namespace wageimportsetup_default {
	/// <summary>
	/// Summary description for FrmWageImportSetup_Default.
	/// </summary>
	public class FrmWageImportSetup_Default : MetaDataForm {
		MetaData Meta;
        public wageimportsetup_default.vistaForm DS;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.ComboBox comboBox5;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.ComboBox comboBox4;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.ComboBox comboBox3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.ComboBox comboBox6;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.ComboBox comboBox7;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.ComboBox comboBox8;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.ComboBox comboBox9;
		private System.Windows.Forms.GroupBox groupBox10;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.ComboBox comboBox10;
		private System.Windows.Forms.GroupBox groupBox11;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.ComboBox comboBox11;
		private System.Windows.Forms.GroupBox groupBox12;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.ComboBox comboBox12;
		private System.Windows.Forms.GroupBox groupBox13;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.ComboBox comboBox13;
		private System.Windows.Forms.GroupBox groupBox14;
		private System.Windows.Forms.Button button14;
		private System.Windows.Forms.ComboBox comboBox14;
		private System.Windows.Forms.GroupBox groupBox15;
		private System.Windows.Forms.Button button15;
		private System.Windows.Forms.ComboBox comboBox15;
		private System.Windows.Forms.GroupBox groupBox16;
		private System.Windows.Forms.Button button16;
		private System.Windows.Forms.ComboBox comboBox16;
        private GroupBox gboxTask;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private RadioButton radioButton3;
        private Crownwood.Magic.Controls.TabControl tabControl1;
        private Crownwood.Magic.Controls.TabPage tabFinanziario;
        private Crownwood.Magic.Controls.TabPage tabClassificazione;
        private Crownwood.Magic.Controls.TabPage tabEP;
        private GroupBox groupBox17;
        private Button button17;
        private ComboBox comboBox17;
        private GroupBox groupBox18;
        private Button button18;
        private ComboBox comboBox18;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmWageImportSetup_Default() {
			InitializeComponent();
			DataAccess.SetTableForReading(DS.Tables["sortingkind_fin"], "sortingkind");
			DataAccess.SetTableForReading(DS.Tables["sortingkind_upb"], "sortingkind");
			DataAccess.SetTableForReading(DS.Tables["sortingkind_registry"], "sortingkind");
			DataAccess.SetTableForReading(DS.Tables["sortingkind_tax"], "sortingkind");
			DataAccess.SetTableForReading(DS.Tables["sortingkind_clawback"], "sortingkind");
			DataAccess.SetTableForReading(DS.Tables["sortingkind_service"], "sortingkind");
			DataAccess.SetTableForReading(DS.Tables["sortingkind_sortingmaster1"], "sortingkind");
			DataAccess.SetTableForReading(DS.Tables["sortingkind_sortingmaster2"], "sortingkind");
			DataAccess.SetTableForReading(DS.Tables["sortingkind_sortingmaster3"], "sortingkind");
			DataAccess.SetTableForReading(DS.Tables["sortingkind_sortingmaster4"], "sortingkind");
			DataAccess.SetTableForReading(DS.Tables["sortingkind_sortingmaster5"], "sortingkind");
			DataAccess.SetTableForReading(DS.Tables["sortingkind_sortingchild1"], "sortingkind");
			DataAccess.SetTableForReading(DS.Tables["sortingkind_sortingchild2"], "sortingkind");
			DataAccess.SetTableForReading(DS.Tables["sortingkind_sortingchild3"], "sortingkind");
			DataAccess.SetTableForReading(DS.Tables["sortingkind_sortingchild4"], "sortingkind");
			DataAccess.SetTableForReading(DS.Tables["sortingkind_sortingchild5"], "sortingkind");
            DataAccess.SetTableForReading(DS.Tables["sortingkind_accmotivegroup1"], "sortingkind");
            DataAccess.SetTableForReading(DS.Tables["sortingkind_accmotivegroup2"], "sortingkind");
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if(components != null) {
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
		private void InitializeComponent() {
            this.DS = new wageimportsetup_default.vistaForm();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.button8 = new System.Windows.Forms.Button();
            this.comboBox8 = new System.Windows.Forms.ComboBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.button9 = new System.Windows.Forms.Button();
            this.comboBox9 = new System.Windows.Forms.ComboBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.button10 = new System.Windows.Forms.Button();
            this.comboBox10 = new System.Windows.Forms.ComboBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.button11 = new System.Windows.Forms.Button();
            this.comboBox11 = new System.Windows.Forms.ComboBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.button12 = new System.Windows.Forms.Button();
            this.comboBox12 = new System.Windows.Forms.ComboBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.button13 = new System.Windows.Forms.Button();
            this.comboBox13 = new System.Windows.Forms.ComboBox();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.button14 = new System.Windows.Forms.Button();
            this.comboBox14 = new System.Windows.Forms.ComboBox();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.button15 = new System.Windows.Forms.Button();
            this.comboBox15 = new System.Windows.Forms.ComboBox();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.button16 = new System.Windows.Forms.Button();
            this.comboBox16 = new System.Windows.Forms.ComboBox();
            this.gboxTask = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new Crownwood.Magic.Controls.TabControl();
            this.tabFinanziario = new Crownwood.Magic.Controls.TabPage();
            this.tabClassificazione = new Crownwood.Magic.Controls.TabPage();
            this.tabEP = new Crownwood.Magic.Controls.TabPage();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.button17 = new System.Windows.Forms.Button();
            this.comboBox17 = new System.Windows.Forms.ComboBox();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.button18 = new System.Windows.Forms.Button();
            this.comboBox18 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.gboxTask.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabFinanziario.SuspendLayout();
            this.tabClassificazione.SuspendLayout();
            this.tabEP.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button5);
            this.groupBox5.Controls.Add(this.comboBox5);
            this.groupBox5.Location = new System.Drawing.Point(8, 127);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(416, 56);
            this.groupBox5.TabIndex = 22;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Tipo di Classificazione associata alle Ritenute";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(8, 24);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 2;
            this.button5.TabStop = false;
            this.button5.Tag = "choose.sortingkind_tax.default";
            this.button5.Text = "Tipo";
            // 
            // comboBox5
            // 
            this.comboBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox5.DataSource = this.DS.sortingkind_tax;
            this.comboBox5.DisplayMember = "description";
            this.comboBox5.Location = new System.Drawing.Point(96, 24);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(312, 21);
            this.comboBox5.TabIndex = 1;
            this.comboBox5.Tag = "wageimportsetup.idsorkind_tax";
            this.comboBox5.ValueMember = "idsorkind";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Controls.Add(this.comboBox4);
            this.groupBox4.Location = new System.Drawing.Point(8, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(416, 56);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tipo di Classificazione associata alla Classificazione Padre 1";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(8, 24);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 2;
            this.button4.TabStop = false;
            this.button4.Tag = "choose.sortingkind_sortingmaster1.default";
            this.button4.Text = "Tipo";
            // 
            // comboBox4
            // 
            this.comboBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox4.DataSource = this.DS.sortingkind_sortingmaster1;
            this.comboBox4.DisplayMember = "description";
            this.comboBox4.Location = new System.Drawing.Point(96, 24);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(312, 21);
            this.comboBox4.TabIndex = 1;
            this.comboBox4.Tag = "wageimportsetup.idsorkind_sortingmaster1";
            this.comboBox4.ValueMember = "idsorkind";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.comboBox3);
            this.groupBox3.Location = new System.Drawing.Point(8, 65);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(416, 56);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tipo di Classificazione associata all\'Anagrafica";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(8, 24);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.TabStop = false;
            this.button3.Tag = "choose.sortingkind_registry.default";
            this.button3.Text = "Tipo";
            // 
            // comboBox3
            // 
            this.comboBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox3.DataSource = this.DS.sortingkind_registry;
            this.comboBox3.DisplayMember = "description";
            this.comboBox3.Location = new System.Drawing.Point(96, 24);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(312, 21);
            this.comboBox3.TabIndex = 1;
            this.comboBox3.Tag = "wageimportsetup.idsorkind_registry";
            this.comboBox3.ValueMember = "idsorkind";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Location = new System.Drawing.Point(428, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(416, 56);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo di Classificazione associata all\'U.P.B.";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 24);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.TabStop = false;
            this.button2.Tag = "choose.sortingkind_upb.default";
            this.button2.Text = "Tipo";
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox2.DataSource = this.DS.sortingkind_upb;
            this.comboBox2.DisplayMember = "description";
            this.comboBox2.Location = new System.Drawing.Point(96, 24);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(312, 21);
            this.comboBox2.TabIndex = 1;
            this.comboBox2.Tag = "wageimportsetup.idsorkind_upb";
            this.comboBox2.ValueMember = "idsorkind";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(8, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 56);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo di Classificazione associata al Bilancio";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.TabStop = false;
            this.button1.Tag = "choose.sortingkind_fin.default";
            this.button1.Text = "Tipo";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DataSource = this.DS.sortingkind_fin;
            this.comboBox1.DisplayMember = "description";
            this.comboBox1.Location = new System.Drawing.Point(96, 24);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(312, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Tag = "wageimportsetup.idsorkind_fin";
            this.comboBox1.ValueMember = "idsorkind";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.button6);
            this.groupBox6.Controls.Add(this.comboBox6);
            this.groupBox6.Location = new System.Drawing.Point(432, 65);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(416, 56);
            this.groupBox6.TabIndex = 25;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Tipo di Classificazione associata alle Prestazioni";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(8, 24);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 2;
            this.button6.TabStop = false;
            this.button6.Tag = "choose.sortingkind_service.default";
            this.button6.Text = "Tipo";
            // 
            // comboBox6
            // 
            this.comboBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox6.DataSource = this.DS.sortingkind_service;
            this.comboBox6.DisplayMember = "description";
            this.comboBox6.Location = new System.Drawing.Point(96, 24);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(312, 21);
            this.comboBox6.TabIndex = 1;
            this.comboBox6.Tag = "wageimportsetup.idsorkind_service";
            this.comboBox6.ValueMember = "idsorkind";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 387);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(592, 32);
            this.label1.TabIndex = 26;
            this.label1.Text = "Elenco dei campi per ulteriore raggruppamento: (Ogni campo deve essere separato d" +
                "a virgola)";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 419);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(592, 20);
            this.textBox1.TabIndex = 27;
            this.textBox1.Tag = "wageimportsetup.listfield";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.button7);
            this.groupBox7.Controls.Add(this.comboBox7);
            this.groupBox7.Location = new System.Drawing.Point(8, 66);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(416, 56);
            this.groupBox7.TabIndex = 28;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Tipo di Classificazione associata alla Classificazione Padre 2";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(8, 24);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 2;
            this.button7.TabStop = false;
            this.button7.Tag = "choose.sortingkind_sortingmaster2.default";
            this.button7.Text = "Tipo";
            // 
            // comboBox7
            // 
            this.comboBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox7.DataSource = this.DS.sortingkind_sortingmaster2;
            this.comboBox7.DisplayMember = "description";
            this.comboBox7.Location = new System.Drawing.Point(96, 24);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(312, 21);
            this.comboBox7.TabIndex = 1;
            this.comboBox7.Tag = "wageimportsetup.idsorkind_sortingmaster2";
            this.comboBox7.ValueMember = "idsorkind";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.button8);
            this.groupBox8.Controls.Add(this.comboBox8);
            this.groupBox8.Location = new System.Drawing.Point(2, 128);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(416, 56);
            this.groupBox8.TabIndex = 29;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Tipo di Classificazione associata alla Classificazione Padre 3";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(8, 24);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 2;
            this.button8.TabStop = false;
            this.button8.Tag = "choose.sortingkind_sortingmaster3.default";
            this.button8.Text = "Tipo";
            // 
            // comboBox8
            // 
            this.comboBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox8.DataSource = this.DS.sortingkind_sortingmaster3;
            this.comboBox8.DisplayMember = "description";
            this.comboBox8.Location = new System.Drawing.Point(96, 24);
            this.comboBox8.Name = "comboBox8";
            this.comboBox8.Size = new System.Drawing.Size(312, 21);
            this.comboBox8.TabIndex = 1;
            this.comboBox8.Tag = "wageimportsetup.idsorkind_sortingmaster3";
            this.comboBox8.ValueMember = "idsorkind";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.button9);
            this.groupBox9.Controls.Add(this.comboBox9);
            this.groupBox9.Location = new System.Drawing.Point(2, 190);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(416, 56);
            this.groupBox9.TabIndex = 30;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Tipo di Classificazione associata alla Classificazione Padre 4";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(8, 24);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 2;
            this.button9.TabStop = false;
            this.button9.Tag = "choose.sortingkind_sortingmaster4.default";
            this.button9.Text = "Tipo";
            // 
            // comboBox9
            // 
            this.comboBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox9.DataSource = this.DS.sortingkind_sortingmaster4;
            this.comboBox9.DisplayMember = "description";
            this.comboBox9.Location = new System.Drawing.Point(96, 24);
            this.comboBox9.Name = "comboBox9";
            this.comboBox9.Size = new System.Drawing.Size(312, 21);
            this.comboBox9.TabIndex = 1;
            this.comboBox9.Tag = "wageimportsetup.idsorkind_sortingmaster4";
            this.comboBox9.ValueMember = "idsorkind";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.button10);
            this.groupBox10.Controls.Add(this.comboBox10);
            this.groupBox10.Location = new System.Drawing.Point(2, 252);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(416, 56);
            this.groupBox10.TabIndex = 31;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Tipo di Classificazione associata alla Classificazione Padre 5";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(8, 24);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 2;
            this.button10.TabStop = false;
            this.button10.Tag = "choose.sortingkind_sortingmaster5.default";
            this.button10.Text = "Tipo";
            // 
            // comboBox10
            // 
            this.comboBox10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox10.DataSource = this.DS.sortingkind_sortingmaster5;
            this.comboBox10.DisplayMember = "description";
            this.comboBox10.Location = new System.Drawing.Point(96, 24);
            this.comboBox10.Name = "comboBox10";
            this.comboBox10.Size = new System.Drawing.Size(312, 21);
            this.comboBox10.TabIndex = 1;
            this.comboBox10.Tag = "wageimportsetup.idsorkind_sortingmaster5";
            this.comboBox10.ValueMember = "idsorkind";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.button11);
            this.groupBox11.Controls.Add(this.comboBox11);
            this.groupBox11.Location = new System.Drawing.Point(426, 252);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(416, 56);
            this.groupBox11.TabIndex = 36;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Tipo di Classificazione associata alla Classificazione Figlia 5";
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(8, 24);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 23);
            this.button11.TabIndex = 2;
            this.button11.TabStop = false;
            this.button11.Tag = "choose.sortingkind_sortingchild5.default";
            this.button11.Text = "Tipo";
            // 
            // comboBox11
            // 
            this.comboBox11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox11.DataSource = this.DS.sortingkind_sortingchild5;
            this.comboBox11.DisplayMember = "description";
            this.comboBox11.Location = new System.Drawing.Point(96, 24);
            this.comboBox11.Name = "comboBox11";
            this.comboBox11.Size = new System.Drawing.Size(312, 21);
            this.comboBox11.TabIndex = 1;
            this.comboBox11.Tag = "wageimportsetup.idsorkind_sortingchild5";
            this.comboBox11.ValueMember = "idsorkind";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.button12);
            this.groupBox12.Controls.Add(this.comboBox12);
            this.groupBox12.Location = new System.Drawing.Point(426, 190);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(416, 56);
            this.groupBox12.TabIndex = 35;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Tipo di Classificazione associata alla Classificazione Figlia 4";
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(8, 24);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 23);
            this.button12.TabIndex = 2;
            this.button12.TabStop = false;
            this.button12.Tag = "choose.sortingkind_sortingchild4.default";
            this.button12.Text = "Tipo";
            // 
            // comboBox12
            // 
            this.comboBox12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox12.DataSource = this.DS.sortingkind_sortingchild4;
            this.comboBox12.DisplayMember = "description";
            this.comboBox12.Location = new System.Drawing.Point(96, 24);
            this.comboBox12.Name = "comboBox12";
            this.comboBox12.Size = new System.Drawing.Size(312, 21);
            this.comboBox12.TabIndex = 1;
            this.comboBox12.Tag = "wageimportsetup.idsorkind_sortingchild4";
            this.comboBox12.ValueMember = "idsorkind";
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.button13);
            this.groupBox13.Controls.Add(this.comboBox13);
            this.groupBox13.Location = new System.Drawing.Point(426, 128);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(416, 56);
            this.groupBox13.TabIndex = 34;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Tipo di Classificazione associata alla Classificazione Figlia 3";
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(8, 24);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(75, 23);
            this.button13.TabIndex = 2;
            this.button13.TabStop = false;
            this.button13.Tag = "choose.sortingkind_sortingchild3.default";
            this.button13.Text = "Tipo";
            // 
            // comboBox13
            // 
            this.comboBox13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox13.DataSource = this.DS.sortingkind_sortingchild3;
            this.comboBox13.DisplayMember = "description";
            this.comboBox13.Location = new System.Drawing.Point(96, 24);
            this.comboBox13.Name = "comboBox13";
            this.comboBox13.Size = new System.Drawing.Size(312, 21);
            this.comboBox13.TabIndex = 1;
            this.comboBox13.Tag = "wageimportsetup.idsorkind_sortingchild3";
            this.comboBox13.ValueMember = "idsorkind";
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.button14);
            this.groupBox14.Controls.Add(this.comboBox14);
            this.groupBox14.Location = new System.Drawing.Point(428, 66);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(416, 56);
            this.groupBox14.TabIndex = 33;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Tipo di Classificazione associata alla Classificazione Figlia 2";
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(8, 24);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(75, 23);
            this.button14.TabIndex = 2;
            this.button14.TabStop = false;
            this.button14.Tag = "choose.sortingkind_sortingchild2.default";
            this.button14.Text = "Tipo";
            // 
            // comboBox14
            // 
            this.comboBox14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox14.DataSource = this.DS.sortingkind_sortingchild2;
            this.comboBox14.DisplayMember = "description";
            this.comboBox14.Location = new System.Drawing.Point(96, 24);
            this.comboBox14.Name = "comboBox14";
            this.comboBox14.Size = new System.Drawing.Size(312, 21);
            this.comboBox14.TabIndex = 1;
            this.comboBox14.Tag = "wageimportsetup.idsorkind_sortingchild2";
            this.comboBox14.ValueMember = "idsorkind";
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.button15);
            this.groupBox15.Controls.Add(this.comboBox15);
            this.groupBox15.Location = new System.Drawing.Point(428, 8);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(416, 56);
            this.groupBox15.TabIndex = 32;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Tipo di Classificazione associata alla Classificazione Figlia 1";
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(8, 24);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(75, 23);
            this.button15.TabIndex = 2;
            this.button15.TabStop = false;
            this.button15.Tag = "choose.sortingkind_sortingchild1.default";
            this.button15.Text = "Tipo";
            // 
            // comboBox15
            // 
            this.comboBox15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox15.DataSource = this.DS.sortingkind_sortingchild1;
            this.comboBox15.DisplayMember = "description";
            this.comboBox15.Location = new System.Drawing.Point(96, 24);
            this.comboBox15.Name = "comboBox15";
            this.comboBox15.Size = new System.Drawing.Size(312, 21);
            this.comboBox15.TabIndex = 1;
            this.comboBox15.Tag = "wageimportsetup.idsorkind_sortingchild1";
            this.comboBox15.ValueMember = "idsorkind";
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.button16);
            this.groupBox16.Controls.Add(this.comboBox16);
            this.groupBox16.Location = new System.Drawing.Point(432, 127);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(416, 56);
            this.groupBox16.TabIndex = 37;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Tipo di Classificazione associata ai Recuperi";
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(8, 24);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(75, 23);
            this.button16.TabIndex = 2;
            this.button16.TabStop = false;
            this.button16.Tag = "choose.sortingkind_clawback.default";
            this.button16.Text = "Tipo";
            // 
            // comboBox16
            // 
            this.comboBox16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox16.DataSource = this.DS.sortingkind_clawback;
            this.comboBox16.DisplayMember = "description";
            this.comboBox16.Location = new System.Drawing.Point(96, 24);
            this.comboBox16.Name = "comboBox16";
            this.comboBox16.Size = new System.Drawing.Size(312, 21);
            this.comboBox16.TabIndex = 1;
            this.comboBox16.Tag = "wageimportsetup.idsorkind_clawback";
            this.comboBox16.ValueMember = "idsorkind";
            // 
            // gboxTask
            // 
            this.gboxTask.Controls.Add(this.radioButton3);
            this.gboxTask.Controls.Add(this.radioButton2);
            this.gboxTask.Controls.Add(this.radioButton1);
            this.gboxTask.Location = new System.Drawing.Point(675, 361);
            this.gboxTask.Name = "gboxTask";
            this.gboxTask.Size = new System.Drawing.Size(174, 78);
            this.gboxTask.TabIndex = 38;
            this.gboxTask.TabStop = false;
            this.gboxTask.Text = "Tipo di compito";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 55);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(77, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Tag = "wageimportsetup.kind:V";
            this.radioButton3.Text = "Versamenti";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(48, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Tag = "wageimportsetup.kind:L";
            this.radioButton2.Text = "Lordi";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 36);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(69, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Tag = "wageimportsetup.kind:R";
            this.radioButton1.Text = "Reversali";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.IDEPixelArea = true;
            this.tabControl1.Location = new System.Drawing.Point(4, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 2;
            this.tabControl1.SelectedTab = this.tabEP;
            this.tabControl1.Size = new System.Drawing.Size(851, 353);
            this.tabControl1.TabIndex = 39;
            this.tabControl1.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabFinanziario,
            this.tabClassificazione,
            this.tabEP});
            // 
            // tabFinanziario
            // 
            this.tabFinanziario.Controls.Add(this.groupBox1);
            this.tabFinanziario.Controls.Add(this.groupBox2);
            this.tabFinanziario.Controls.Add(this.groupBox16);
            this.tabFinanziario.Controls.Add(this.groupBox3);
            this.tabFinanziario.Controls.Add(this.groupBox6);
            this.tabFinanziario.Controls.Add(this.groupBox5);
            this.tabFinanziario.Location = new System.Drawing.Point(0, 0);
            this.tabFinanziario.Name = "tabFinanziario";
            this.tabFinanziario.Selected = false;
            this.tabFinanziario.Size = new System.Drawing.Size(851, 328);
            this.tabFinanziario.TabIndex = 3;
            this.tabFinanziario.Title = "Finanziario";
            // 
            // tabClassificazione
            // 
            this.tabClassificazione.Controls.Add(this.groupBox4);
            this.tabClassificazione.Controls.Add(this.groupBox15);
            this.tabClassificazione.Controls.Add(this.groupBox7);
            this.tabClassificazione.Controls.Add(this.groupBox11);
            this.tabClassificazione.Controls.Add(this.groupBox14);
            this.tabClassificazione.Controls.Add(this.groupBox10);
            this.tabClassificazione.Controls.Add(this.groupBox12);
            this.tabClassificazione.Controls.Add(this.groupBox8);
            this.tabClassificazione.Controls.Add(this.groupBox13);
            this.tabClassificazione.Controls.Add(this.groupBox9);
            this.tabClassificazione.Location = new System.Drawing.Point(0, 0);
            this.tabClassificazione.Name = "tabClassificazione";
            this.tabClassificazione.Size = new System.Drawing.Size(851, 328);
            this.tabClassificazione.TabIndex = 4;
            this.tabClassificazione.Title = "Classificazione";
            // 
            // tabEP
            // 
            this.tabEP.Controls.Add(this.groupBox17);
            this.tabEP.Controls.Add(this.groupBox18);
            this.tabEP.Location = new System.Drawing.Point(0, 0);
            this.tabEP.Name = "tabEP";
            this.tabEP.Size = new System.Drawing.Size(851, 328);
            this.tabEP.TabIndex = 5;
            this.tabEP.Title = "E/P";
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.button17);
            this.groupBox17.Controls.Add(this.comboBox17);
            this.groupBox17.Location = new System.Drawing.Point(8, 10);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(416, 56);
            this.groupBox17.TabIndex = 29;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Tipo di Classificazione associata alla causale - Gruppo 1";
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(8, 24);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(75, 23);
            this.button17.TabIndex = 2;
            this.button17.TabStop = false;
            this.button17.Tag = "choose.sortingkind_accmotivegroup1.default";
            this.button17.Text = "Tipo";
            // 
            // comboBox17
            // 
            this.comboBox17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox17.DataSource = this.DS.sortingkind_accmotivegroup1;
            this.comboBox17.DisplayMember = "description";
            this.comboBox17.Location = new System.Drawing.Point(96, 24);
            this.comboBox17.Name = "comboBox17";
            this.comboBox17.Size = new System.Drawing.Size(312, 21);
            this.comboBox17.TabIndex = 1;
            this.comboBox17.Tag = "wageimportsetup.idsorkind_accmotivegroup1";
            this.comboBox17.ValueMember = "idsorkind";
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.button18);
            this.groupBox18.Controls.Add(this.comboBox18);
            this.groupBox18.Location = new System.Drawing.Point(428, 10);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(416, 56);
            this.groupBox18.TabIndex = 30;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Tipo di Classificazione associata alla causale - Gruppo 2";
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(8, 24);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(75, 23);
            this.button18.TabIndex = 2;
            this.button18.TabStop = false;
            this.button18.Tag = "choose.sortingkind_accmotivegroup2.default";
            this.button18.Text = "Tipo";
            // 
            // comboBox18
            // 
            this.comboBox18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox18.DataSource = this.DS.sortingkind_accmotivegroup2;
            this.comboBox18.DisplayMember = "description";
            this.comboBox18.Location = new System.Drawing.Point(96, 24);
            this.comboBox18.Name = "comboBox18";
            this.comboBox18.Size = new System.Drawing.Size(312, 21);
            this.comboBox18.TabIndex = 1;
            this.comboBox18.Tag = "wageimportsetup.idsorkind_accmotivegroup2";
            this.comboBox18.ValueMember = "idsorkind";
            // 
            // FrmWageImportSetup_Default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(862, 451);
            this.Controls.Add(this.gboxTask);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "FrmWageImportSetup_Default";
            this.Text = "FrmWageImportSetup_Default";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            this.groupBox16.ResumeLayout(false);
            this.gboxTask.ResumeLayout(false);
            this.gboxTask.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabFinanziario.ResumeLayout(false);
            this.tabClassificazione.ResumeLayout(false);
            this.tabEP.ResumeLayout(false);
            this.groupBox17.ResumeLayout(false);
            this.groupBox18.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public void MetaData_AfterClear() {
		}

		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);

            bool IsAdmin = false;

            if (Meta.GetSys("manage_prestazioni") != null) {
                IsAdmin = (Meta.GetSys("manage_prestazioni").ToString().ToUpper() == "S");
            }
            Meta.CanInsert = IsAdmin;
            Meta.CanInsertCopy = IsAdmin;
            Meta.CanCancel = IsAdmin;
            gboxTask.Enabled = IsAdmin;
		}
	}
}
