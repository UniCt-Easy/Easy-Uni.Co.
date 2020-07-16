/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
using funzioni_configurazione;

namespace unifiedivapay_default
{
	/// <summary>
	/// Summary description for Frm_UnifiedIvaPay_Default.
	/// </summary>
	public class Frm_UnifiedIvaPay_Default : System.Windows.Forms.Form
	{
		MetaData Meta;
		public unifiedivapay_default.vistaForm DS;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPrincipale;
		private System.Windows.Forms.TabPage tabDettagli;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox textBox16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.TextBox textBox13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox textBox11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox textBox12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.TextBox txtSaldoCorrente;
		private System.Windows.Forms.TextBox txtLiquidCorrente;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtSaldoPrec;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton rdoAcconto;
		private System.Windows.Forms.RadioButton rdoPeriodica;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtNumero;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtEsercizio;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.ComboBox comboBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_UnifiedIvaPay_Default()
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
			this.DS = new unifiedivapay_default.vistaForm();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPrincipale = new System.Windows.Forms.TabPage();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.button4 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.textBox16 = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.textBox13 = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.textBox11 = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.textBox12 = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.txtSaldoCorrente = new System.Windows.Forms.TextBox();
			this.txtLiquidCorrente = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.txtSaldoPrec = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.label22 = new System.Windows.Forms.Label();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.rdoAcconto = new System.Windows.Forms.RadioButton();
			this.rdoPeriodica = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtNumero = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtEsercizio = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabDettagli = new System.Windows.Forms.TabPage();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPrincipale.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabDettagli.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPrincipale);
			this.tabControl1.Controls.Add(this.tabDettagli);
			this.tabControl1.Location = new System.Drawing.Point(8, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(560, 488);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPrincipale
			// 
			this.tabPrincipale.Controls.Add(this.comboBox1);
			this.tabPrincipale.Controls.Add(this.button4);
			this.tabPrincipale.Controls.Add(this.textBox1);
			this.tabPrincipale.Controls.Add(this.label20);
			this.tabPrincipale.Controls.Add(this.textBox16);
			this.tabPrincipale.Controls.Add(this.label17);
			this.tabPrincipale.Controls.Add(this.groupBox8);
			this.tabPrincipale.Controls.Add(this.groupBox5);
			this.tabPrincipale.Controls.Add(this.groupBox4);
			this.tabPrincipale.Controls.Add(this.groupBox3);
			this.tabPrincipale.Controls.Add(this.groupBox2);
			this.tabPrincipale.Controls.Add(this.groupBox1);
			this.tabPrincipale.Location = new System.Drawing.Point(4, 22);
			this.tabPrincipale.Name = "tabPrincipale";
			this.tabPrincipale.Size = new System.Drawing.Size(552, 462);
			this.tabPrincipale.TabIndex = 0;
			this.tabPrincipale.Text = "Principale";
			// 
			// comboBox1
			// 
			this.comboBox1.DataSource = this.DS.department;
			this.comboBox1.DisplayMember = "description";
			this.comboBox1.Location = new System.Drawing.Point(120, 16);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(424, 21);
			this.comboBox1.TabIndex = 32;
			this.comboBox1.Tag = "unifiedivapay.iddepartment";
			this.comboBox1.ValueMember = "iddepartment";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(8, 16);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(104, 23);
			this.button4.TabIndex = 31;
			this.button4.Tag = "manage.department.default";
			this.button4.Text = "Dipartimento";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(384, 344);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(64, 20);
			this.textBox1.TabIndex = 29;
			this.textBox1.TabStop = false;
			this.textBox1.Tag = "unifiedivapay.mixed.fixed.2..%.100";
			this.textBox1.Text = "";
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(288, 344);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(88, 16);
			this.label20.TabIndex = 30;
			this.label20.Text = "% di Promiscuo";
			this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox16
			// 
			this.textBox16.Location = new System.Drawing.Point(384, 312);
			this.textBox16.Name = "textBox16";
			this.textBox16.Size = new System.Drawing.Size(64, 20);
			this.textBox16.TabIndex = 27;
			this.textBox16.TabStop = false;
			this.textBox16.Tag = "unifiedivapay.prorata.fixed.2..%.100";
			this.textBox16.Text = "";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(288, 312);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(88, 16);
			this.label17.TabIndex = 28;
			this.label17.Text = "% di Prorata";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.textBox2);
			this.groupBox8.Controls.Add(this.label3);
			this.groupBox8.Controls.Add(this.textBox3);
			this.groupBox8.Controls.Add(this.label4);
			this.groupBox8.Location = new System.Drawing.Point(388, 64);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(160, 80);
			this.groupBox8.TabIndex = 22;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Periodo della liquidazione";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(56, 46);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(74, 20);
			this.textBox2.TabIndex = 4;
			this.textBox2.TabStop = false;
			this.textBox2.Tag = "unifiedivapay.stop";
			this.textBox2.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 16);
			this.label3.TabIndex = 3;
			this.label3.Text = "Al";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(56, 22);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(74, 20);
			this.textBox3.TabIndex = 2;
			this.textBox3.TabStop = false;
			this.textBox3.Tag = "unifiedivapay.start";
			this.textBox3.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(32, 16);
			this.label4.TabIndex = 0;
			this.label4.Text = "Dal";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.textBox13);
			this.groupBox5.Controls.Add(this.label14);
			this.groupBox5.Controls.Add(this.textBox10);
			this.groupBox5.Controls.Add(this.label11);
			this.groupBox5.Controls.Add(this.textBox11);
			this.groupBox5.Controls.Add(this.label12);
			this.groupBox5.Controls.Add(this.textBox12);
			this.groupBox5.Controls.Add(this.label13);
			this.groupBox5.Location = new System.Drawing.Point(4, 304);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(272, 152);
			this.groupBox5.TabIndex = 24;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Regolamento";
			// 
			// textBox13
			// 
			this.textBox13.Location = new System.Drawing.Point(16, 104);
			this.textBox13.Multiline = true;
			this.textBox13.Name = "textBox13";
			this.textBox13.Size = new System.Drawing.Size(248, 40);
			this.textBox13.TabIndex = 18;
			this.textBox13.Tag = "unifiedivapay.paymentdetails";
			this.textBox13.Text = "";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(16, 88);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(128, 16);
			this.label14.TabIndex = 17;
			this.label14.Text = "Estremi del versamento";
			// 
			// textBox10
			// 
			this.textBox10.Location = new System.Drawing.Point(184, 64);
			this.textBox10.Name = "textBox10";
			this.textBox10.Size = new System.Drawing.Size(80, 20);
			this.textBox10.TabIndex = 16;
			this.textBox10.Tag = "unifiedivapay.assesmentdate";
			this.textBox10.Text = "";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(80, 64);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(88, 16);
			this.label11.TabIndex = 15;
			this.label11.Text = "Data";
			this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBox11
			// 
			this.textBox11.Location = new System.Drawing.Point(184, 40);
			this.textBox11.Name = "textBox11";
			this.textBox11.Size = new System.Drawing.Size(80, 20);
			this.textBox11.TabIndex = 14;
			this.textBox11.Tag = "unifiedivapay.paymentamount";
			this.textBox11.Text = "";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(56, 40);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(112, 16);
			this.label12.TabIndex = 13;
			this.label12.Text = "Importo versamento";
			this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBox12
			// 
			this.textBox12.Location = new System.Drawing.Point(184, 16);
			this.textBox12.Name = "textBox12";
			this.textBox12.Size = new System.Drawing.Size(80, 20);
			this.textBox12.TabIndex = 12;
			this.textBox12.Tag = "unifiedivapay.refundamount";
			this.textBox12.Text = "";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(72, 16);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(96, 16);
			this.label13.TabIndex = 11;
			this.label13.Text = "Importo rimborso";
			this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.txtSaldoCorrente);
			this.groupBox4.Controls.Add(this.txtLiquidCorrente);
			this.groupBox4.Controls.Add(this.label10);
			this.groupBox4.Controls.Add(this.label9);
			this.groupBox4.Controls.Add(this.txtSaldoPrec);
			this.groupBox4.Controls.Add(this.label8);
			this.groupBox4.Location = new System.Drawing.Point(284, 160);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(264, 104);
			this.groupBox4.TabIndex = 25;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Saldo";
			// 
			// txtSaldoCorrente
			// 
			this.txtSaldoCorrente.Location = new System.Drawing.Point(160, 70);
			this.txtSaldoCorrente.Name = "txtSaldoCorrente";
			this.txtSaldoCorrente.ReadOnly = true;
			this.txtSaldoCorrente.Size = new System.Drawing.Size(96, 20);
			this.txtSaldoCorrente.TabIndex = 12;
			this.txtSaldoCorrente.TabStop = false;
			this.txtSaldoCorrente.Tag = "unifiedivapay.importocorrente";
			this.txtSaldoCorrente.Text = "";
			this.txtSaldoCorrente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtLiquidCorrente
			// 
			this.txtLiquidCorrente.Location = new System.Drawing.Point(160, 46);
			this.txtLiquidCorrente.Name = "txtLiquidCorrente";
			this.txtLiquidCorrente.ReadOnly = true;
			this.txtLiquidCorrente.Size = new System.Drawing.Size(96, 20);
			this.txtLiquidCorrente.TabIndex = 11;
			this.txtLiquidCorrente.TabStop = false;
			this.txtLiquidCorrente.Tag = "unifiedivapay.importocorrente";
			this.txtLiquidCorrente.Text = "";
			this.txtLiquidCorrente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(32, 72);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(120, 16);
			this.label10.TabIndex = 10;
			this.label10.Text = "Saldo corrente";
			this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(24, 48);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(128, 16);
			this.label9.TabIndex = 9;
			this.label9.Text = "Liquidazione corrente";
			this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// txtSaldoPrec
			// 
			this.txtSaldoPrec.Location = new System.Drawing.Point(160, 22);
			this.txtSaldoPrec.Name = "txtSaldoPrec";
			this.txtSaldoPrec.ReadOnly = true;
			this.txtSaldoPrec.Size = new System.Drawing.Size(96, 20);
			this.txtSaldoPrec.TabIndex = 8;
			this.txtSaldoPrec.TabStop = false;
			this.txtSaldoPrec.Tag = "unifiedivapay.importocorrente";
			this.txtSaldoPrec.Text = "";
			this.txtSaldoPrec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(32, 24);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(120, 16);
			this.label8.TabIndex = 7;
			this.label8.Text = "Saldo precedente";
			this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.textBox8);
			this.groupBox3.Controls.Add(this.label22);
			this.groupBox3.Controls.Add(this.textBox7);
			this.groupBox3.Controls.Add(this.label21);
			this.groupBox3.Controls.Add(this.textBox6);
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Controls.Add(this.textBox5);
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Controls.Add(this.textBox4);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Location = new System.Drawing.Point(4, 152);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(272, 152);
			this.groupBox3.TabIndex = 23;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Liquidazione corrente";
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(184, 96);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(80, 20);
			this.textBox8.TabIndex = 4;
			this.textBox8.Tag = "unifiedivapay.debitamountdeferred";
			this.textBox8.Text = "";
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(16, 96);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(152, 16);
			this.label22.TabIndex = 13;
			this.label22.Text = "Importo a debito Differito";
			this.label22.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(184, 48);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(80, 20);
			this.textBox7.TabIndex = 2;
			this.textBox7.Tag = "unifiedivapay.creditamountdeferred";
			this.textBox7.Text = "";
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(16, 48);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(152, 16);
			this.label21.TabIndex = 11;
			this.label21.Text = "Importo a credito Differito";
			this.label21.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(184, 120);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(80, 20);
			this.textBox6.TabIndex = 5;
			this.textBox6.Tag = "unifiedivapay.dateivapay";
			this.textBox6.Text = "";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(16, 120);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(152, 16);
			this.label7.TabIndex = 9;
			this.label7.Text = "Data";
			this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(184, 72);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(80, 20);
			this.textBox5.TabIndex = 3;
			this.textBox5.Tag = "unifiedivapay.debitamount";
			this.textBox5.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(16, 72);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(152, 16);
			this.label6.TabIndex = 7;
			this.label6.Text = "Importo a debito Immediato";
			this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(184, 22);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(80, 20);
			this.textBox4.TabIndex = 1;
			this.textBox4.Tag = "unifiedivapay.creditamount";
			this.textBox4.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(152, 16);
			this.label5.TabIndex = 5;
			this.label5.Text = "Importo a credito Immediato";
			this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.rdoAcconto);
			this.groupBox2.Controls.Add(this.rdoPeriodica);
			this.groupBox2.Location = new System.Drawing.Point(188, 64);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(184, 80);
			this.groupBox2.TabIndex = 21;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Tipo di liquidazione";
			// 
			// rdoAcconto
			// 
			this.rdoAcconto.Location = new System.Drawing.Point(16, 48);
			this.rdoAcconto.Name = "rdoAcconto";
			this.rdoAcconto.TabIndex = 1;
			this.rdoAcconto.Tag = "unifiedivapay.paymentkind:A";
			this.rdoAcconto.Text = "Acconto";
			// 
			// rdoPeriodica
			// 
			this.rdoPeriodica.Location = new System.Drawing.Point(16, 24);
			this.rdoPeriodica.Name = "rdoPeriodica";
			this.rdoPeriodica.Size = new System.Drawing.Size(136, 24);
			this.rdoPeriodica.TabIndex = 0;
			this.rdoPeriodica.Tag = "unifiedivapay.paymentkind:C";
			this.rdoPeriodica.Text = "Liquidazione periodica";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtNumero);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtEsercizio);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(4, 64);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(168, 80);
			this.groupBox1.TabIndex = 20;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Liquidazione";
			// 
			// txtNumero
			// 
			this.txtNumero.Location = new System.Drawing.Point(78, 48);
			this.txtNumero.Name = "txtNumero";
			this.txtNumero.Size = new System.Drawing.Size(74, 20);
			this.txtNumero.TabIndex = 4;
			this.txtNumero.Tag = "unifiedivapay.nunifiedivapay";
			this.txtNumero.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Numero";
			// 
			// txtEsercizio
			// 
			this.txtEsercizio.Location = new System.Drawing.Point(78, 22);
			this.txtEsercizio.Name = "txtEsercizio";
			this.txtEsercizio.ReadOnly = true;
			this.txtEsercizio.Size = new System.Drawing.Size(74, 20);
			this.txtEsercizio.TabIndex = 2;
			this.txtEsercizio.TabStop = false;
			this.txtEsercizio.Tag = "unifiedivapay.yunifiedivapay.year";
			this.txtEsercizio.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Esercizio";
			// 
			// tabDettagli
			// 
			this.tabDettagli.Controls.Add(this.dataGrid1);
			this.tabDettagli.Controls.Add(this.button3);
			this.tabDettagli.Controls.Add(this.button2);
			this.tabDettagli.Controls.Add(this.button1);
			this.tabDettagli.Location = new System.Drawing.Point(4, 22);
			this.tabDettagli.Name = "tabDettagli";
			this.tabDettagli.Size = new System.Drawing.Size(552, 462);
			this.tabDettagli.TabIndex = 1;
			this.tabDettagli.Text = "Dettagli";
			// 
			// dataGrid1
			// 
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(8, 40);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(536, 416);
			this.dataGrid1.TabIndex = 3;
			this.dataGrid1.Tag = "unifiedivapaydetail.default";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(184, 8);
			this.button3.Name = "button3";
			this.button3.TabIndex = 2;
			this.button3.Tag = "delete";
			this.button3.Text = "Cancella";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(96, 8);
			this.button2.Name = "button2";
			this.button2.TabIndex = 1;
			this.button2.Tag = "edit.default";
			this.button2.Text = "Correggi";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(8, 8);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Tag = "insert.default";
			this.button1.Text = "Aggiungi";
			// 
			// Frm_UnifiedIvaPay_Default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(576, 494);
			this.Controls.Add(this.tabControl1);
			this.Name = "Frm_UnifiedIvaPay_Default";
			this.Text = "Frm_UnifiedIvaPay_Default";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPrincipale.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tabDettagli.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
	
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
			string filteresercizio = "(yunifiedivapay = '" + Meta.GetSys("esercizio") + "')";
			GetData.SetStaticFilter(DS.unifiedivapay, filteresercizio);
		}

		public void MetaData_AfterClear() {
			DisabilitaCampi(false);
			SvuotaCampi();
			txtEsercizio.Text = Meta.GetSys("esercizio").ToString();
		}

		public void MetaData_BeforeFill() {
			if (Meta.FirstFillForThisRow) {
				calcolaIVACredito();
			}		
		}

		public void MetaData_AfterFill() {
			DisabilitaCampi(true);
			CalcolaTotali();
		}

		private void calcolaIVACredito() {
			foreach(DataRow rDettaglio in DS.unifiedivapaydetail.Select("(!registerclass='A')")) {
				decimal ivaNetta = CfgFn.GetNoNullDecimal(rDettaglio["ivanet"]);
				decimal ivaNettaDiff = CfgFn.GetNoNullDecimal(rDettaglio["ivanetdeferred"]);
				rDettaglio["!ivacredit"] = ivaNetta + ivaNettaDiff;
			}
		}

		private void DisabilitaCampi(bool disable) {
			rdoPeriodica.Enabled=!disable;
			rdoAcconto.Enabled=!disable;
		}

		private void SvuotaCampi() {
			txtSaldoPrec.Text="";
			txtLiquidCorrente.Text="";
			txtSaldoCorrente.Text="";
		}

		private DataTable SommaImportiPrec() {
			DataRow R=DS.unifiedivapay.Rows[0];
			string esercizio=QueryCreator.unquotedstrvalue(R["yunifiedivapay"],true);
			string numero=QueryCreator.unquotedstrvalue(R["nunifiedivapay"],true);
			string sql="SELECT SUM(ISNULL(creditamount,0)) + SUM(ISNULL(creditamountdeferred,0)) AS totcreditamount, "+
				"SUM(ISNULL(debitamount,0)) + SUM(ISNULL(debitamountdeferred,0)) AS totdebitamount, "+
				"SUM(ISNULL(refundamount,0)) AS refundamount, "+
				"SUM(ISNULL(paymentamount,0)) AS paymentamount " +
				"FROM unifiedivapay ";

			string filter="WHERE (yunifiedivapay = "+esercizio+" AND nunifiedivapay < "+numero+")"
				+ " AND (iddepartment = " + R["iddepartment"] + ")";
			return Meta.Conn.SQLRunner(sql+filter,true,-1);
		}

		private void CalcolaTotali() {
			if (Meta.IsEmpty) return;
			decimal saldoprec=0;
			decimal liquidcorrente=0;
			decimal saldocorrente=0;
			
			DataTable T=SommaImportiPrec();
			if (T!=null && T.Rows.Count>0) {
				saldoprec=CfgFn.GetNoNullDecimal(T.Rows[0]["totcreditamount"]) -
					CfgFn.GetNoNullDecimal(T.Rows[0]["totdebitamount"]) -
					CfgFn.GetNoNullDecimal(T.Rows[0]["refundamount"]) +
					CfgFn.GetNoNullDecimal(T.Rows[0]["paymentamount"]);
			}
			
			liquidcorrente = CfgFn.GetNoNullDecimal(DS.unifiedivapay.Rows[0]["creditamount"])
				+ CfgFn.GetNoNullDecimal(DS.unifiedivapay.Rows[0]["creditamountdeferred"])
				- CfgFn.GetNoNullDecimal(DS.unifiedivapay.Rows[0]["debitamount"])
				- CfgFn.GetNoNullDecimal(DS.unifiedivapay.Rows[0]["debitamountdeferred"]);
			
			saldocorrente=saldoprec+liquidcorrente;
			
			string filter="where yunifiedivapay="+
				QueryCreator.quotedstrvalue(DS.unifiedivapay.Rows[0]["yunifiedivapay"],true)+ " AND "+
				"nunifiedivapay="+
				QueryCreator.quotedstrvalue(DS.unifiedivapay.Rows[0]["nunifiedivapay"],true)+ " ";

			txtSaldoPrec.Text=saldoprec.ToString("c");
			txtLiquidCorrente.Text=liquidcorrente.ToString("c");
			txtSaldoCorrente.Text=saldocorrente.ToString("c");
		}
	}
}
