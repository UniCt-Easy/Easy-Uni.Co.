/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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
using funzioni_configurazione;//funzioni_configurazione

namespace payrolltax_default {//cedolinoritenuta//
	/// <summary>
	/// Summary description for frmcedolinoritenuta.
	/// </summary>
	public class Frm_payrolltax_default : System.Windows.Forms.Form {
		private MetaData meta;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		public vistaForm DS;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox textBox11;
		private System.Windows.Forms.TextBox textBox12;
		private System.Windows.Forms.TextBox textBox13;
		private System.Windows.Forms.TextBox textBox14;
		private System.Windows.Forms.TextBox textBox15;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox textBox16;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox textBox18;
		private System.Windows.Forms.TextBox textBox26;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox textBox17;
		private System.Windows.Forms.GroupBox grpConguaglio;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox txtTipoImponibile;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.RadioButton rdoConguaglio;
		private System.Windows.Forms.RadioButton rdoRata;
        private TextBox txtEnte;
        private Label lblEnte;
        private TextBox textBox19;
        private Label label17;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_payrolltax_default() {
			InitializeComponent();
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
            this.DS = new payrolltax_default.vistaForm();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoConguaglio = new System.Windows.Forms.RadioButton();
            this.rdoRata = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.textBox26 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.grpConguaglio = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTipoImponibile = new System.Windows.Forms.TextBox();
            this.txtEnte = new System.Windows.Forms.TextBox();
            this.lblEnte = new System.Windows.Forms.Label();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.grpConguaglio.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Num. Cedolino:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(104, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(72, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Tag = "payrolltax.idpayroll";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(184, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Num. Dettaglio:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(280, 8);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(56, 20);
            this.textBox2.TabIndex = 2;
            this.textBox2.Tag = "payrolltax.idpayrolltax";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 23);
            this.button1.TabIndex = 3;
            this.button1.Tag = "manage.tax.default";
            this.button1.Text = "Tipo Ritenuta";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DataSource = this.DS.tax;
            this.comboBox1.DisplayMember = "description";
            this.comboBox1.Location = new System.Drawing.Point(104, 40);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(504, 21);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.Tag = "payrolltax.taxcode";
            this.comboBox1.ValueMember = "taxcode";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Imponibile lordo";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(104, 72);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(90, 20);
            this.textBox3.TabIndex = 5;
            this.textBox3.Tag = "payrolltax.taxablegross";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(40, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "Deduzioni";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(104, 104);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(90, 20);
            this.textBox4.TabIndex = 6;
            this.textBox4.Tag = "payrolltax.deduction";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(104, 200);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(90, 20);
            this.textBox6.TabIndex = 8;
            this.textBox6.Tag = "payrolltax.abatements";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(40, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 23);
            this.label6.TabIndex = 13;
            this.label6.Text = "Detrazioni";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoConguaglio);
            this.groupBox1.Controls.Add(this.rdoRata);
            this.groupBox1.Location = new System.Drawing.Point(209, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(85, 80);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Natura";
            // 
            // rdoConguaglio
            // 
            this.rdoConguaglio.Location = new System.Drawing.Point(3, 48);
            this.rdoConguaglio.Name = "rdoConguaglio";
            this.rdoConguaglio.Size = new System.Drawing.Size(80, 24);
            this.rdoConguaglio.TabIndex = 2;
            this.rdoConguaglio.Tag = "";
            this.rdoConguaglio.Text = "Conguaglio";
            // 
            // rdoRata
            // 
            this.rdoRata.Location = new System.Drawing.Point(3, 16);
            this.rdoRata.Name = "rdoRata";
            this.rdoRata.Size = new System.Drawing.Size(64, 24);
            this.rdoRata.TabIndex = 1;
            this.rdoRata.Tag = "";
            this.rdoRata.Text = "Rata";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(352, 506);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Annulla";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(192, 506);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 16;
            this.btnOk.Tag = "mainsave";
            this.btnOk.Text = "Ok";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox8);
            this.groupBox2.Controls.Add(this.textBox9);
            this.groupBox2.Controls.Add(this.textBox10);
            this.groupBox2.Controls.Add(this.panel5);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(409, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 80);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ritenute c/Amministrazione";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(136, 48);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(56, 20);
            this.textBox8.TabIndex = 2;
            this.textBox8.Tag = "payrolltax.admindenominator.n";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(136, 16);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(56, 20);
            this.textBox9.TabIndex = 1;
            this.textBox9.Tag = "payrolltax.adminnumerator.n";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(8, 40);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(80, 20);
            this.textBox10.TabIndex = 0;
            this.textBox10.Tag = "payrolltax.adminrate.fixed.4..%.100";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Location = new System.Drawing.Point(128, 40);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(72, 2);
            this.panel5.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(88, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 22);
            this.label8.TabIndex = 30;
            this.label8.Text = "Quota:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(24, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 22);
            this.label9.TabIndex = 28;
            this.label9.Text = "Aliquota:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel3);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.textBox11);
            this.groupBox3.Controls.Add(this.textBox12);
            this.groupBox3.Controls.Add(this.textBox13);
            this.groupBox3.Location = new System.Drawing.Point(409, 72);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 80);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ritenute c/Dipendente";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(128, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(72, 2);
            this.panel3.TabIndex = 31;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(88, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 22);
            this.label10.TabIndex = 30;
            this.label10.Text = "Quota:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(24, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 22);
            this.label11.TabIndex = 28;
            this.label11.Text = "Aliquota:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(8, 40);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(80, 20);
            this.textBox11.TabIndex = 0;
            this.textBox11.Tag = "payrolltax.employrate.fixed.4..%.100";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(136, 48);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(56, 20);
            this.textBox12.TabIndex = 2;
            this.textBox12.Tag = "payrolltax.employdenominator.n";
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(136, 16);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(56, 20);
            this.textBox13.TabIndex = 1;
            this.textBox13.Tag = "payrolltax.employnumerator.n";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(24, 56);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(56, 20);
            this.textBox14.TabIndex = 11;
            this.textBox14.Tag = "payrolltax.taxabledenominator.n";
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(24, 24);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(56, 20);
            this.textBox15.TabIndex = 10;
            this.textBox15.Tag = "payrolltax.taxablenumerator.n";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(16, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(72, 2);
            this.panel2.TabIndex = 28;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(16, 232);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 23);
            this.label7.TabIndex = 34;
            this.label7.Text = "Ritenuta c/dip";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(104, 232);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(90, 20);
            this.textBox7.TabIndex = 14;
            this.textBox7.Tag = "payrolltax.employtax";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(8, 264);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 23);
            this.label13.TabIndex = 36;
            this.label13.Text = "Ritenuta c/Ammin";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(104, 264);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(90, 20);
            this.textBox16.TabIndex = 15;
            this.textBox16.Tag = "payrolltax.admintax";
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(16, 338);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(592, 161);
            this.dataGrid1.TabIndex = 37;
            this.dataGrid1.Tag = "payrolltaxbracket";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox14);
            this.groupBox4.Controls.Add(this.textBox15);
            this.groupBox4.Controls.Add(this.panel2);
            this.groupBox4.Location = new System.Drawing.Point(297, 72);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(108, 80);
            this.groupBox4.TabIndex = 38;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Quota imponibile:";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(262, 312);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 23);
            this.label12.TabIndex = 40;
            this.label12.Text = "Dettaglio scaglioni";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 23);
            this.label5.TabIndex = 41;
            this.label5.Text = "Imponibile netto";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(104, 136);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(90, 20);
            this.textBox5.TabIndex = 42;
            this.textBox5.Tag = "payrolltax.taxablenet";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(8, 168);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(100, 23);
            this.label16.TabIndex = 48;
            this.label16.Text = "Ritenuta lorda dip.";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(104, 168);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(90, 20);
            this.textBox18.TabIndex = 49;
            this.textBox18.Tag = "payrolltax.employtaxgross";
            // 
            // textBox26
            // 
            this.textBox26.Location = new System.Drawing.Point(88, 58);
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new System.Drawing.Size(90, 20);
            this.textBox26.TabIndex = 66;
            this.textBox26.Tag = "payrolltax.annualpayedemploytax";
            this.textBox26.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(8, 55);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 29);
            this.label15.TabIndex = 68;
            this.label15.Text = "Ritenuta gi‡ versata";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(1, 18);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(87, 30);
            this.label18.TabIndex = 68;
            this.label18.Text = "Imponibile annuo contratto";
            this.label18.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(88, 18);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(90, 20);
            this.textBox17.TabIndex = 69;
            this.textBox17.Tag = "payrolltax.annualtaxabletotal";
            // 
            // grpConguaglio
            // 
            this.grpConguaglio.Controls.Add(this.textBox19);
            this.grpConguaglio.Controls.Add(this.label17);
            this.grpConguaglio.Controls.Add(this.textBox26);
            this.grpConguaglio.Controls.Add(this.label15);
            this.grpConguaglio.Controls.Add(this.textBox17);
            this.grpConguaglio.Controls.Add(this.label18);
            this.grpConguaglio.Location = new System.Drawing.Point(209, 157);
            this.grpConguaglio.Name = "grpConguaglio";
            this.grpConguaglio.Size = new System.Drawing.Size(192, 114);
            this.grpConguaglio.TabIndex = 70;
            this.grpConguaglio.TabStop = false;
            this.grpConguaglio.Text = "Conguaglio";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(344, 8);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 23);
            this.label14.TabIndex = 71;
            this.label14.Text = "Imponibile:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTipoImponibile
            // 
            this.txtTipoImponibile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTipoImponibile.Location = new System.Drawing.Point(408, 8);
            this.txtTipoImponibile.Name = "txtTipoImponibile";
            this.txtTipoImponibile.ReadOnly = true;
            this.txtTipoImponibile.Size = new System.Drawing.Size(200, 20);
            this.txtTipoImponibile.TabIndex = 72;
            this.txtTipoImponibile.TabStop = false;
            // 
            // txtEnte
            // 
            this.txtEnte.Location = new System.Drawing.Point(296, 289);
            this.txtEnte.Name = "txtEnte";
            this.txtEnte.ReadOnly = true;
            this.txtEnte.Size = new System.Drawing.Size(312, 20);
            this.txtEnte.TabIndex = 73;
            this.txtEnte.Tag = "";
            // 
            // lblEnte
            // 
            this.lblEnte.Location = new System.Drawing.Point(208, 287);
            this.lblEnte.Name = "lblEnte";
            this.lblEnte.Size = new System.Drawing.Size(83, 23);
            this.lblEnte.TabIndex = 74;
            this.lblEnte.Text = "Ente Locale:";
            this.lblEnte.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox19
            // 
            this.textBox19.Location = new System.Drawing.Point(88, 88);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(90, 20);
            this.textBox19.TabIndex = 70;
            this.textBox19.Tag = "payrolltax.annualcreditapplied";
            this.textBox19.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(8, 85);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(72, 29);
            this.label17.TabIndex = 71;
            this.label17.Text = "Credito gi‡ applicato";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Frm_payrolltax_default
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(624, 541);
            this.Controls.Add(this.txtEnte);
            this.Controls.Add(this.lblEnte);
            this.Controls.Add(this.txtTipoImponibile);
            this.Controls.Add(this.textBox18);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox16);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.grpConguaglio);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label13);
            this.Name = "Frm_payrolltax_default";
            this.Text = "frmcedolinoritenuta";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.grpConguaglio.ResumeLayout(false);
            this.grpConguaglio.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void rendiDiSolaLettura(Control control) {
			foreach (Control c in control.Controls) {
				if (c.HasChildren) {
					rendiDiSolaLettura(c);
				} 
				else {
					TextBox t = c as TextBox;
					if (t != null) {
						t.ReadOnly = true;
					}

					RadioButton rb = c as RadioButton;
					if (rb != null) {
						rb.Enabled = false;
					}

					ComboBox cb = c as ComboBox;
					if (cb != null) {
						cb.Enabled = false;
					}

					Button b = c as Button;
					if ((b != null) && (b != btnOk) && (b != btnCancel)) {
						b.Enabled = false;
					}
				}
			}
		}
        CQueryHelper QHC;
        QueryHelper QHS;
		public void MetaData_AfterLink() {
			meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = meta.Conn.GetQueryHelper();
			if (meta.edit_type=="readonly") {
				meta.CanSave = false;
				rendiDiSolaLettura(this);
			}
		}

		public void MetaData_BeforeFill() {
			if (DS.payrolltax.Rows.Count == 0) return;
            DataRow Curr = DS.payrolltax.Rows[0];
			DataRow parentRowCedolino = Curr.GetParentRow("payrollpayrolltax");
            if (parentRowCedolino == null) return;

			DataRow parentRow = DS.payrolltax.Rows[0].GetParentRow("taxpayrolltax");
            if ((parentRow != null) && (parentRowCedolino != null)) {
                string natura = parentRowCedolino["flagbalance"].ToString().ToUpper() == "S"
                    ? "C" : "R";
                int tiporitenuta = CfgFn.GetNoNullInt32(parentRow["taxkind"]);
                grpConguaglio.Visible = (natura == "C") && (tiporitenuta == 1);
                string filterImponibile = QHS.AppAnd(QHS.CmpEq("taxablecode", parentRow["taxablecode"]), QHS.CmpEq("ayear", meta.GetSys("esercizio")));
                object imponibile = meta.Conn.DO_READ_VALUE("taxablekind", filterImponibile, "description");
                if (imponibile != null) {
                    txtTipoImponibile.Text = imponibile.ToString();
                }

                string geoAppliance = parentRow["geoappliance"].ToString().ToUpper();

                object idCity = Curr["idcity"];
                object idFiscalTaxRegion = Curr["idfiscaltaxregion"];

                string nome = "";

                if (idCity != DBNull.Value) {
                    nome = meta.Conn.DO_READ_VALUE("geo_city",
                        QHS.CmpEq("idcity", idCity), "title").ToString();
                    txtEnte.Text = nome;
                }
                else {
                    if (idFiscalTaxRegion != DBNull.Value) {
                        nome = meta.Conn.DO_READ_VALUE("fiscaltaxregion",
                            QHS.CmpEq("idfiscaltaxregion", idFiscalTaxRegion), "title").ToString();
                        txtEnte.Text = nome;
                    }
                    else {
                        lblEnte.Visible = false;
                        txtEnte.Visible = false;
                    }
                }
            }
		}

		public void MetaData_AfterActivation() {
			DataRow parentRowCedolino = DS.payrolltax.Rows[0].GetParentRow("payrollpayrolltax");
			if (parentRowCedolino == null) return;

			string isConguaglio = parentRowCedolino["flagbalance"].ToString().ToUpper();
			if (isConguaglio == "S") {
				rdoConguaglio.Checked = true;
				rdoRata.Checked = false;
			}
			else {
				rdoConguaglio.Checked = false;
				rdoRata.Checked = true;
			}
		}
	}
}