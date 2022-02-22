
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
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;


namespace expensetaxofficialview_default//ritenuteapplicate//
{
	/// <summary>
	/// Summary description for frmritenuteapplicate.
	/// </summary>
	public class Frm_expensetaxofficialview_default : MetaDataForm
	{
		private System.Windows.Forms.GroupBox gboxMovimento;
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
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
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
        private GroupBox grpRegion;
        private ComboBox cmbRegioneFiscale;
        private GroupBox grpCity;
        private Label label20;
        private TextBox txtProvincia;
        private TextBox txtGeoComune0101;
        private Label label7;
        private TextBox textBox1;
        private TextBox textBox7;
        private Label label16;
        CQueryHelper QHC;
        QueryHelper QHS;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_expensetaxofficialview_default()
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
            this.gboxMovimento = new System.Windows.Forms.GroupBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtEsercMov = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.DS = new expensetaxofficialview_default.vistaForm();
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
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
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
            this.grpRegion = new System.Windows.Forms.GroupBox();
            this.cmbRegioneFiscale = new System.Windows.Forms.ComboBox();
            this.grpCity = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtProvincia = new System.Windows.Forms.TextBox();
            this.txtGeoComune0101 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.gboxMovimento.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.grpRegion.SuspendLayout();
            this.grpCity.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboxMovimento
            // 
            this.gboxMovimento.Controls.Add(this.textBox7);
            this.gboxMovimento.Controls.Add(this.label16);
            this.gboxMovimento.Controls.Add(this.label2);
            this.gboxMovimento.Controls.Add(this.label1);
            this.gboxMovimento.Controls.Add(this.textBox3);
            this.gboxMovimento.Controls.Add(this.txtEsercMov);
            this.gboxMovimento.Location = new System.Drawing.Point(8, 106);
            this.gboxMovimento.Name = "gboxMovimento";
            this.gboxMovimento.Size = new System.Drawing.Size(472, 50);
            this.gboxMovimento.TabIndex = 2;
            this.gboxMovimento.TabStop = false;
            this.gboxMovimento.Text = "Movimento";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(355, 22);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(108, 20);
            this.textBox7.TabIndex = 15;
            this.textBox7.Tag = "expensetaxofficialview.adate";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(271, 15);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(82, 31);
            this.label16.TabIndex = 16;
            this.label16.Text = "Data Contabile:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.label1.Location = new System.Drawing.Point(137, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Numero:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(191, 20);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(74, 20);
            this.textBox3.TabIndex = 2;
            this.textBox3.Tag = "expensetaxofficialview.nmov";
            // 
            // txtEsercMov
            // 
            this.txtEsercMov.Location = new System.Drawing.Point(68, 20);
            this.txtEsercMov.Name = "txtEsercMov";
            this.txtEsercMov.ReadOnly = true;
            this.txtEsercMov.Size = new System.Drawing.Size(65, 20);
            this.txtEsercMov.TabIndex = 1;
            this.txtEsercMov.Tag = "expensetaxofficialview.ymov.year";
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
            this.comboBox1.Location = new System.Drawing.Point(12, 16);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(440, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Tag = "expensetaxofficialview.taxcode";
            this.comboBox1.ValueMember = "taxcode";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox11);
            this.groupBox3.Controls.Add(this.textBox10);
            this.groupBox3.Controls.Add(this.textBox9);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(9, 461);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(224, 80);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ritenute c/dipendente";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(143, 48);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(72, 20);
            this.textBox11.TabIndex = 3;
            this.textBox11.Tag = "expensetaxofficialview.employdenominator";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(143, 24);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(72, 20);
            this.textBox10.TabIndex = 2;
            this.textBox10.Tag = "expensetaxofficialview.employnumerator";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(8, 32);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(80, 20);
            this.textBox9.TabIndex = 1;
            this.textBox9.Tag = "expensetaxofficialview.employrate.fixed.2..%.100";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(103, 32);
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
            this.groupBox4.Location = new System.Drawing.Point(233, 461);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(240, 80);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Contributi c/amministrazione";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(151, 48);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(80, 20);
            this.textBox14.TabIndex = 3;
            this.textBox14.Tag = "expensetaxofficialview.admindenominator";
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(151, 24);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(80, 20);
            this.textBox15.TabIndex = 2;
            this.textBox15.Tag = "expensetaxofficialview.adminnumerator";
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(8, 32);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(80, 20);
            this.textBox16.TabIndex = 1;
            this.textBox16.Tag = "expensetaxofficialview.adminrate.fixed.2..%.100";
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
            this.groupBox5.Location = new System.Drawing.Point(8, 161);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(472, 48);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Tag = "AutoChoose.txtCreDeb.default";
            this.groupBox5.Text = "Percipiente";
            // 
            // txtCreDeb
            // 
            this.txtCreDeb.Location = new System.Drawing.Point(13, 16);
            this.txtCreDeb.Name = "txtCreDeb";
            this.txtCreDeb.Size = new System.Drawing.Size(451, 20);
            this.txtCreDeb.TabIndex = 1;
            this.txtCreDeb.Tag = "registry.title?expensetaxofficialview.registry";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(113, 313);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(112, 20);
            this.textBox5.TabIndex = 6;
            this.textBox5.Tag = "expensetaxofficialview.taxablenet";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(128, 16);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(112, 20);
            this.textBox6.TabIndex = 1;
            this.textBox6.Tag = "expensetaxofficialview.start";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(128, 40);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(112, 20);
            this.textBox8.TabIndex = 2;
            this.textBox8.Tag = "expensetaxofficialview.stop";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Descrizione:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(88, 216);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(392, 56);
            this.textBox4.TabIndex = 5;
            this.textBox4.Tag = "expensetaxofficialview.expensedescription";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(17, 313);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 24);
            this.label4.TabIndex = 12;
            this.label4.Text = "Imponibile netto:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(51, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Inizio validità:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(43, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "Fine validità:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Controls.Add(this.textBox6);
            this.groupBox7.Controls.Add(this.textBox8);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Location = new System.Drawing.Point(233, 273);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(248, 78);
            this.groupBox7.TabIndex = 7;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Date";
            // 
            // txtnbracket
            // 
            this.txtnbracket.Location = new System.Drawing.Point(145, 345);
            this.txtnbracket.Name = "txtnbracket";
            this.txtnbracket.Size = new System.Drawing.Size(80, 20);
            this.txtnbracket.TabIndex = 13;
            this.txtnbracket.Tag = "expensetaxofficialview.nbracket";
            // 
            // labNumscaglione
            // 
            this.labNumscaglione.Location = new System.Drawing.Point(17, 353);
            this.labNumscaglione.Name = "labNumscaglione";
            this.labNumscaglione.Size = new System.Drawing.Size(104, 16);
            this.labNumscaglione.TabIndex = 14;
            this.labNumscaglione.Text = "Num. Scaglione";
            // 
            // txtDetrazioni
            // 
            this.txtDetrazioni.Location = new System.Drawing.Point(113, 377);
            this.txtDetrazioni.Name = "txtDetrazioni";
            this.txtDetrazioni.Size = new System.Drawing.Size(112, 20);
            this.txtDetrazioni.TabIndex = 15;
            this.txtDetrazioni.Tag = "expensetaxofficialview.abatements";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(113, 281);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(112, 20);
            this.textBox2.TabIndex = 0;
            this.textBox2.Tag = "expensetaxofficialview.taxablegross";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(17, 281);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 16);
            this.label14.TabIndex = 16;
            this.label14.Text = "Imponibile lordo";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(17, 385);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 16);
            this.label15.TabIndex = 17;
            this.label15.Text = "Detrazioni";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(17, 417);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 24);
            this.label10.TabIndex = 18;
            this.label10.Text = "Importo c/dip";
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(113, 409);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(112, 20);
            this.textBox18.TabIndex = 19;
            this.textBox18.Tag = "expensetaxofficialview.employtax";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(241, 417);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 24);
            this.label11.TabIndex = 20;
            this.label11.Text = "Importo c/ammin";
            // 
            // textBox19
            // 
            this.textBox19.Location = new System.Drawing.Point(361, 409);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(112, 20);
            this.textBox19.TabIndex = 21;
            this.textBox19.Tag = "expensetaxofficialview.admintax";
            // 
            // grpRegion
            // 
            this.grpRegion.Controls.Add(this.cmbRegioneFiscale);
            this.grpRegion.Location = new System.Drawing.Point(7, 60);
            this.grpRegion.Name = "grpRegion";
            this.grpRegion.Size = new System.Drawing.Size(473, 43);
            this.grpRegion.TabIndex = 23;
            this.grpRegion.TabStop = false;
            this.grpRegion.Text = "Regione Fiscale:";
            // 
            // cmbRegioneFiscale
            // 
            this.cmbRegioneFiscale.DataSource = this.DS.fiscaltaxregion;
            this.cmbRegioneFiscale.DisplayMember = "title";
            this.cmbRegioneFiscale.FormattingEnabled = true;
            this.cmbRegioneFiscale.Location = new System.Drawing.Point(14, 16);
            this.cmbRegioneFiscale.Name = "cmbRegioneFiscale";
            this.cmbRegioneFiscale.Size = new System.Drawing.Size(241, 21);
            this.cmbRegioneFiscale.TabIndex = 0;
            this.cmbRegioneFiscale.Tag = "expensetaxofficialview.idfiscaltaxregion";
            this.cmbRegioneFiscale.ValueMember = "idfiscaltaxregion";
            // 
            // grpCity
            // 
            this.grpCity.Controls.Add(this.label20);
            this.grpCity.Controls.Add(this.txtProvincia);
            this.grpCity.Controls.Add(this.txtGeoComune0101);
            this.grpCity.Location = new System.Drawing.Point(8, 60);
            this.grpCity.Name = "grpCity";
            this.grpCity.Size = new System.Drawing.Size(473, 41);
            this.grpCity.TabIndex = 22;
            this.grpCity.TabStop = false;
            this.grpCity.Tag = "AutoChoose.txtGeoComune0101.default";
            this.grpCity.Text = "Comune:";
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(300, 16);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(41, 18);
            this.label20.TabIndex = 154;
            this.label20.Text = "Prov.";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProvincia
            // 
            this.txtProvincia.Location = new System.Drawing.Point(344, 15);
            this.txtProvincia.Name = "txtProvincia";
            this.txtProvincia.ReadOnly = true;
            this.txtProvincia.Size = new System.Drawing.Size(25, 20);
            this.txtProvincia.TabIndex = 153;
            this.txtProvincia.TabStop = false;
            this.txtProvincia.Tag = "geo_cityview.provincecode";
            // 
            // txtGeoComune0101
            // 
            this.txtGeoComune0101.Location = new System.Drawing.Point(8, 16);
            this.txtGeoComune0101.Name = "txtGeoComune0101";
            this.txtGeoComune0101.Size = new System.Drawing.Size(286, 20);
            this.txtGeoComune0101.TabIndex = 3;
            this.txtGeoComune0101.Tag = "geo_cityview.title?expensetaxofficialview.city";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(228, 354);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 34);
            this.label7.TabIndex = 25;
            this.label7.Text = "Anno Competenza Liquidazione:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(363, 363);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(109, 20);
            this.textBox1.TabIndex = 24;
            this.textBox1.Tag = "expensetaxofficialview.ayear.year";
            // 
            // Frm_expensetaxofficialview_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(488, 558);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox1);
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
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gboxMovimento);
            this.Controls.Add(this.grpRegion);
            this.Controls.Add(this.grpCity);
            this.Name = "Frm_expensetaxofficialview_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmritenuteapplicateofficial";
            this.gboxMovimento.ResumeLayout(false);
            this.gboxMovimento.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.grpRegion.ResumeLayout(false);
            this.grpCity.ResumeLayout(false);
            this.grpCity.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

      	public void MetaData_AfterLink()
		{		
				Meta=MetaData.GetMetaData(this);
				Meta.CanInsert = false;
				Meta.CanSave = false;
				Meta.CanCancel = false;
				Meta.CanInsertCopy=false;

                QHC = new CQueryHelper();
                QHS = Meta.Conn.GetQueryHelper();

				string filter = QHC.AppAnd(QHC.CmpEq("ymov", Meta.GetSys("esercizio")), QHC.IsNull("stop"));
				GetData.SetStaticFilter(DS.expensetaxofficialview,filter);
                /*int fasemax = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));
                string filterfase = QHS.CmpEq("nphase", fasemax);
                string descfase = "";
                descfase = Meta.Conn.DO_READ_VALUE("expensephase", filterfase, "description").ToString();
                if (descfase != "") {
                    gboxMovimento.Text = descfase;
                }*/
		}

		public void MetaData_AfterClear()
		{
			txtEsercMov.Text = Meta.GetSys("esercizio").ToString();
            grpCity.Visible = false;
            grpRegion.Visible = false;
		}
        public void MetaData_AfterRowSelect (DataTable T, DataRow R) {
            if (T.TableName == "tax") {
                if (!Meta.DrawStateIsDone) return;
                //if (Meta.IsEmpty) return;
                //DataRow Curr = DS.expensetaxofficialview.Rows[0];
                if (R == null) {
                    grpCity.Visible = false;
                    grpRegion.Visible = false;
                    //Curr["idcity"] = DBNull.Value;
                    //Curr["idfiscaltaxregion"] = DBNull.Value;
                }
                else {
                    DataRow[] Tax = DS.tax.Select(QHC.CmpEq("taxcode", R["taxcode"]));
                    if (Tax.Length > 0) {
                        DataRow rTax = Tax[0];
                        string geo = rTax["geoappliance"].ToString().ToUpper();
                        switch (geo) {
                            case "C": {
                                grpCity.Visible = true;
                                grpRegion.Visible = false;
                                //Curr["idfiscaltaxregion"] = DBNull.Value;
                                HelpForm.SetComboBoxValue(cmbRegioneFiscale, -1);
                                break;
                            }
                            case "R": {
                                grpCity.Visible = false;
                                grpRegion.Visible = true;
                                //Curr["idcity"] = DBNull.Value;
                                txtGeoComune0101.Text = "";
                                txtProvincia.Text = "";
                                break;
                            }
                            default: {
                                grpCity.Visible = false;
                                grpRegion.Visible = false;
                                //Curr["idcity"] = DBNull.Value;
                                //Curr["idfiscaltaxregion"] = DBNull.Value;
                                txtGeoComune0101.Text = "";
                                txtProvincia.Text = "";
                                HelpForm.SetComboBoxValue(cmbRegioneFiscale, -1);
                                break;
                            }
                        }
                    }
                }
            }
        }

		public void MetaData_AfterFill()
		{
			Text="Riepilogo Storico Ritenute Applicate";
           
            if ((Meta.FirstFillForThisRow) && (DS.expensetaxofficialview.Rows.Count > 0)){
                DataRow Curr = DS.expensetaxofficialview.Rows[0];
                if (CfgFn.GetNoNullInt32(Curr["taxcode"]) == 0) {
                    grpCity.Visible = false;
                    grpRegion.Visible = false;
                }
                else {
                    DataRow [] Tax = DS.tax.Select(QHC.CmpEq("taxcode", Curr["taxcode"]));
                    if (Tax.Length > 0) {
                        DataRow rTax = Tax[0];
                        string geo = rTax["geoappliance"].ToString().ToUpper();
                        switch (geo) {
                            case "C": {
                                    grpCity.Visible = true;
                                    grpRegion.Visible = false;
                                    break;
                                }
                            case "R": {
                                    grpCity.Visible = false;
                                    grpRegion.Visible = true;
                                    break;
                                }
                            default: {
                                    grpCity.Visible = false;
                                    grpRegion.Visible = false;
                                    break;
                                }
                        }
                    }
                }
            }
		}
		}
}
