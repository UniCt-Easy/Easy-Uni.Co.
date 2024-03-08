
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
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;


namespace payedtaxf24ordview_default//ritenuteapplicate//
{
	/// <summary>
	/// Summary description for frmritenuteapplicate.
	/// </summary>
	public class Frm_payedtaxf24ordview_default : MetaDataForm
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.TextBox textBox11;
		private System.Windows.Forms.TextBox textBox14;
		private System.Windows.Forms.TextBox textBox15;
		private System.Windows.Forms.TextBox textBox16;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		public /*Rana:ritenuteapplicate.*/vistaForm DS;
		private System.Windows.Forms.TextBox txtCreDeb;
		MetaData Meta;
		IDataAccess Conn;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox17;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.TextBox txtEsercMov;
		private System.Windows.Forms.TextBox txtnbracket;
		private System.Windows.Forms.Label labNumscaglione;
		private System.Windows.Forms.TextBox txtDetrazioni;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBox18;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox textBox19;
		private ComboBox cmbMese;
		private Label label18;
		private GroupBox groupBox8;
		private TextBox textBox12;
		private TextBox textBox13;
		private Label label19;
		private Label label20;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_payedtaxf24ordview_default()
		{
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.txtEsercMov = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.DS = new payedtaxf24ordview_default.vistaForm();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.textBox11 = new System.Windows.Forms.TextBox();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.textBox14 = new System.Windows.Forms.TextBox();
			this.textBox15 = new System.Windows.Forms.TextBox();
			this.textBox16 = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.txtCreDeb = new System.Windows.Forms.TextBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.cmbMese = new System.Windows.Forms.ComboBox();
			this.label18 = new System.Windows.Forms.Label();
			this.textBox17 = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.txtnbracket = new System.Windows.Forms.TextBox();
			this.labNumscaglione = new System.Windows.Forms.Label();
			this.txtDetrazioni = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.textBox18 = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.textBox19 = new System.Windows.Forms.TextBox();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.textBox12 = new System.Windows.Forms.TextBox();
			this.textBox13 = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.textBox3);
			this.groupBox1.Controls.Add(this.txtEsercMov);
			this.groupBox1.Location = new System.Drawing.Point(8, 64);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(192, 80);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Movimento";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Esercizio:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Numero:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(72, 48);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(104, 20);
			this.textBox3.TabIndex = 2;
			this.textBox3.Tag = "payedtaxf24ordview.nmov";
			// 
			// txtEsercMov
			// 
			this.txtEsercMov.Location = new System.Drawing.Point(72, 20);
			this.txtEsercMov.Name = "txtEsercMov";
			this.txtEsercMov.Size = new System.Drawing.Size(104, 20);
			this.txtEsercMov.TabIndex = 1;
			this.txtEsercMov.Tag = "payedtaxf24ordview.ymov.year";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.comboBox1);
			this.groupBox2.Location = new System.Drawing.Point(8, 8);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(472, 48);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Ritenuta";
			// 
			// comboBox1
			// 
			this.comboBox1.DataSource = this.DS.tax;
			this.comboBox1.DisplayMember = "description";
			this.comboBox1.Dock = System.Windows.Forms.DockStyle.Right;
			this.comboBox1.Location = new System.Drawing.Point(85, 16);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(384, 21);
			this.comboBox1.TabIndex = 1;
			this.comboBox1.Tag = "payedtaxf24ordview.taxcode";
			this.comboBox1.ValueMember = "taxcode";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.textBox11);
			this.groupBox3.Controls.Add(this.textBox10);
			this.groupBox3.Controls.Add(this.textBox9);
			this.groupBox3.Controls.Add(this.label9);
			this.groupBox3.Controls.Add(this.label8);
			this.groupBox3.Location = new System.Drawing.Point(8, 520);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(224, 80);
			this.groupBox3.TabIndex = 8;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Ritenute c/dipendente";
			// 
			// textBox11
			// 
			this.textBox11.Location = new System.Drawing.Point(136, 48);
			this.textBox11.Name = "textBox11";
			this.textBox11.Size = new System.Drawing.Size(72, 20);
			this.textBox11.TabIndex = 3;
			this.textBox11.Tag = "payedtaxf24ordview.employdenominator";
			// 
			// textBox10
			// 
			this.textBox10.Location = new System.Drawing.Point(136, 24);
			this.textBox10.Name = "textBox10";
			this.textBox10.Size = new System.Drawing.Size(72, 20);
			this.textBox10.TabIndex = 2;
			this.textBox10.Tag = "payedtaxf24ordview.employnumerator";
			// 
			// textBox9
			// 
			this.textBox9.Location = new System.Drawing.Point(8, 32);
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new System.Drawing.Size(80, 20);
			this.textBox9.TabIndex = 1;
			this.textBox9.Tag = "payedtaxf24ordview.employrate.fixed.2..%.100";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(96, 32);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(40, 16);
			this.label9.TabIndex = 1;
			this.label9.Text = "Quota:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(16, 16);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(56, 16);
			this.label8.TabIndex = 0;
			this.label8.Text = "Aliquota:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.textBox14);
			this.groupBox4.Controls.Add(this.textBox15);
			this.groupBox4.Controls.Add(this.textBox16);
			this.groupBox4.Controls.Add(this.label12);
			this.groupBox4.Controls.Add(this.label13);
			this.groupBox4.Location = new System.Drawing.Point(232, 520);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(240, 80);
			this.groupBox4.TabIndex = 9;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Contributi c/amministrazione";
			// 
			// textBox14
			// 
			this.textBox14.Location = new System.Drawing.Point(160, 48);
			this.textBox14.Name = "textBox14";
			this.textBox14.Size = new System.Drawing.Size(80, 20);
			this.textBox14.TabIndex = 3;
			this.textBox14.Tag = "payedtaxf24ordview.admindenominator";
			// 
			// textBox15
			// 
			this.textBox15.Location = new System.Drawing.Point(160, 24);
			this.textBox15.Name = "textBox15";
			this.textBox15.Size = new System.Drawing.Size(80, 20);
			this.textBox15.TabIndex = 2;
			this.textBox15.Tag = "payedtaxf24ordview.adminnumerator";
			// 
			// textBox16
			// 
			this.textBox16.Location = new System.Drawing.Point(8, 32);
			this.textBox16.Name = "textBox16";
			this.textBox16.Size = new System.Drawing.Size(80, 20);
			this.textBox16.TabIndex = 1;
			this.textBox16.Tag = "payedtaxf24ordview.adminrate.fixed.2..%.100";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(104, 32);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(40, 16);
			this.label12.TabIndex = 13;
			this.label12.Text = "Quota:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(8, 16);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(56, 16);
			this.label13.TabIndex = 12;
			this.label13.Text = "Aliquota:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.txtCreDeb);
			this.groupBox5.Location = new System.Drawing.Point(8, 224);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(472, 48);
			this.groupBox5.TabIndex = 4;
			this.groupBox5.TabStop = false;
			this.groupBox5.Tag = "AutoChoose.txtCreDeb.default";
			this.groupBox5.Text = "Percipiente";
			// 
			// txtCreDeb
			// 
			this.txtCreDeb.Location = new System.Drawing.Point(8, 16);
			this.txtCreDeb.Name = "txtCreDeb";
			this.txtCreDeb.Size = new System.Drawing.Size(456, 20);
			this.txtCreDeb.TabIndex = 1;
			this.txtCreDeb.Tag = "registry.title?payedtaxf24ordview.registry";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(112, 376);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(112, 20);
			this.textBox5.TabIndex = 6;
			this.textBox5.Tag = "payedtaxf24ordview.taxablenet";
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(112, 16);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(128, 20);
			this.textBox6.TabIndex = 1;
			this.textBox6.Tag = "payedtaxf24ordview.competencydate";
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(112, 64);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(128, 20);
			this.textBox7.TabIndex = 3;
			this.textBox7.Tag = "payedtaxf24ordview.datetaxpay";
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(112, 40);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(128, 20);
			this.textBox8.TabIndex = 2;
			this.textBox8.Tag = "payedtaxf24ordview.adate";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 280);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 16);
			this.label3.TabIndex = 10;
			this.label3.Text = "Descrizione:";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(88, 280);
			this.textBox4.Multiline = true;
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(392, 56);
			this.textBox4.TabIndex = 5;
			this.textBox4.Tag = "payedtaxf24ordview.expensedescription";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 376);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(88, 24);
			this.label4.TabIndex = 12;
			this.label4.Text = "Imponibile netto:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(32, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 16);
			this.label5.TabIndex = 13;
			this.label5.Text = "Competenza:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(24, 40);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(80, 16);
			this.label6.TabIndex = 14;
			this.label6.Text = "Pagamento:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 64);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(96, 16);
			this.label7.TabIndex = 15;
			this.label7.Text = "Liquidazione:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.cmbMese);
			this.groupBox6.Controls.Add(this.label18);
			this.groupBox6.Controls.Add(this.textBox17);
			this.groupBox6.Controls.Add(this.textBox1);
			this.groupBox6.Controls.Add(this.label17);
			this.groupBox6.Controls.Add(this.label16);
			this.groupBox6.Location = new System.Drawing.Point(9, 146);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(393, 77);
			this.groupBox6.TabIndex = 3;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "F24 Ordinario";
			// 
			// cmbMese
			// 
			this.cmbMese.DataSource = this.DS.monthname;
			this.cmbMese.DisplayMember = "title";
			this.cmbMese.FormattingEnabled = true;
			this.cmbMese.Location = new System.Drawing.Point(70, 46);
			this.cmbMese.Name = "cmbMese";
			this.cmbMese.Size = new System.Drawing.Size(154, 21);
			this.cmbMese.TabIndex = 36;
			this.cmbMese.Tag = "f24ordinario.nmonth?payedtaxf24ordview.nmonth";
			this.cmbMese.ValueMember = "code";
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(8, 47);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(56, 23);
			this.label18.TabIndex = 3;
			this.label18.Text = "Mese";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox17
			// 
			this.textBox17.Location = new System.Drawing.Point(270, 15);
			this.textBox17.Name = "textBox17";
			this.textBox17.Size = new System.Drawing.Size(104, 20);
			this.textBox17.TabIndex = 2;
			this.textBox17.Tag = "f24ordinario.idf24ordinario?payedtaxf24ordview.idf24ordinario";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(72, 16);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(104, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.Tag = "f24ordinario.ayear?payedtaxf24ordview.ayear";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(206, 15);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(56, 23);
			this.label17.TabIndex = 1;
			this.label17.Text = "Numero";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(8, 16);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(56, 23);
			this.label16.TabIndex = 0;
			this.label16.Text = "Esercizio";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.label5);
			this.groupBox7.Controls.Add(this.textBox6);
			this.groupBox7.Controls.Add(this.textBox8);
			this.groupBox7.Controls.Add(this.label6);
			this.groupBox7.Controls.Add(this.textBox7);
			this.groupBox7.Controls.Add(this.label7);
			this.groupBox7.Location = new System.Drawing.Point(232, 336);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(248, 96);
			this.groupBox7.TabIndex = 7;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Date";
			// 
			// txtnbracket
			// 
			this.txtnbracket.Location = new System.Drawing.Point(144, 408);
			this.txtnbracket.Name = "txtnbracket";
			this.txtnbracket.Size = new System.Drawing.Size(80, 20);
			this.txtnbracket.TabIndex = 13;
			this.txtnbracket.Tag = "payedtaxf24ordview.nbracket";
			// 
			// labNumscaglione
			// 
			this.labNumscaglione.Location = new System.Drawing.Point(16, 416);
			this.labNumscaglione.Name = "labNumscaglione";
			this.labNumscaglione.Size = new System.Drawing.Size(104, 16);
			this.labNumscaglione.TabIndex = 14;
			this.labNumscaglione.Text = "Num. Scaglione";
			// 
			// txtDetrazioni
			// 
			this.txtDetrazioni.Location = new System.Drawing.Point(112, 440);
			this.txtDetrazioni.Name = "txtDetrazioni";
			this.txtDetrazioni.Size = new System.Drawing.Size(112, 20);
			this.txtDetrazioni.TabIndex = 15;
			this.txtDetrazioni.Tag = "payedtaxf24ordview.abatements";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(112, 344);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(112, 20);
			this.textBox2.TabIndex = 0;
			this.textBox2.Tag = "payedtaxf24ordview.taxablegross";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(16, 344);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(88, 16);
			this.label14.TabIndex = 16;
			this.label14.Text = "Imponibile lordo";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(16, 448);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(88, 16);
			this.label15.TabIndex = 17;
			this.label15.Text = "Detrazioni";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(16, 480);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(80, 24);
			this.label10.TabIndex = 18;
			this.label10.Text = "Importo c/dip";
			// 
			// textBox18
			// 
			this.textBox18.Location = new System.Drawing.Point(112, 472);
			this.textBox18.Name = "textBox18";
			this.textBox18.Size = new System.Drawing.Size(112, 20);
			this.textBox18.TabIndex = 19;
			this.textBox18.Tag = "payedtaxf24ordview.employtax";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(240, 480);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(96, 24);
			this.label11.TabIndex = 20;
			this.label11.Text = "Importo c/ammin";
			// 
			// textBox19
			// 
			this.textBox19.Location = new System.Drawing.Point(360, 472);
			this.textBox19.Name = "textBox19";
			this.textBox19.Size = new System.Drawing.Size(112, 20);
			this.textBox19.TabIndex = 21;
			this.textBox19.Tag = "payedtaxf24ordview.admintax";
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.textBox12);
			this.groupBox8.Controls.Add(this.textBox13);
			this.groupBox8.Controls.Add(this.label19);
			this.groupBox8.Controls.Add(this.label20);
			this.groupBox8.Location = new System.Drawing.Point(218, 64);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(184, 80);
			this.groupBox8.TabIndex = 22;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Liquidazione Ritenute";
			// 
			// textBox12
			// 
			this.textBox12.Location = new System.Drawing.Point(72, 48);
			this.textBox12.Name = "textBox12";
			this.textBox12.Size = new System.Drawing.Size(104, 20);
			this.textBox12.TabIndex = 2;
			this.textBox12.Tag = "payedtaxf24ordview.ntaxpay";
			// 
			// textBox13
			// 
			this.textBox13.Location = new System.Drawing.Point(72, 16);
			this.textBox13.Name = "textBox13";
			this.textBox13.Size = new System.Drawing.Size(104, 20);
			this.textBox13.TabIndex = 1;
			this.textBox13.Tag = "payedtaxf24ordview.ytaxpay.year";
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(8, 48);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(56, 23);
			this.label19.TabIndex = 1;
			this.label19.Text = "Numero";
			this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(8, 16);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(56, 23);
			this.label20.TabIndex = 0;
			this.label20.Text = "Esercizio";
			this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// Frm_payedtaxf24ordview_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(488, 610);
			this.Controls.Add(this.groupBox8);
			this.Controls.Add(this.textBox19);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.textBox18);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.txtDetrazioni);
			this.Controls.Add(this.labNumscaglione);
			this.Controls.Add(this.txtnbracket);
			this.Controls.Add(this.groupBox7);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox6);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.textBox5);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "Frm_payedtaxf24ordview_default";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmritenuteapplicatef24ord";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			this.groupBox8.ResumeLayout(false);
			this.groupBox8.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	    QueryHelper QHS;
        CQueryHelper QHC;
		public void MetaData_AfterLink()
		{		
			Meta=MetaData.GetMetaData(this);
		    this.Conn = this.getInstance<IDataAccess>();
			Meta.CanInsert = false;
			Meta.CanSave = false;
			Meta.CanCancel = false;
			Meta.CanInsertCopy=false;
			QHS = Conn.GetQueryHelper();
            QHC = new CQueryHelper();

			string filter = QHS.DoPar(QHS.AppAnd(QHS.AppOr(QHS.CmpEq("ymov",Meta.GetSys("esercizio")),QHS.IsNull("ytaxpay"),
					        QHS.CmpEq("ytaxpay",Meta.GetSys("esercizio"))), QHS.IsNotNull("idf24ordinario")));
			GetData.SetStaticFilter(DS.payedtaxf24ordview,filter);

			GetData.MarkToAddBlankRow(DS.monthname);
			GetData.Add_Blank_Row(DS.monthname);
			GetData.CacheTable(DS.monthname);
			GetData.SetSorting(DS.monthname, "code");
		}

		public void MetaData_AfterClear()
		{
			txtEsercMov.Text = Meta.GetSys("esercizio").ToString();
		}

		public void MetaData_AfterFill()
		{
			Text="Ritenute Applicate F24 Ordinario";
		}
	}
}
