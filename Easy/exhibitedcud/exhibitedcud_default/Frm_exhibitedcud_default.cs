
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
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using calcolocedolino;

namespace exhibitedcud_default {//cudpresentato//
	/// <summary>
	/// Summary description for frmcudpresentato.
	/// </summary>
	public class Frm_exhibitedcud_default : System.Windows.Forms.Form {
		public vistaForm DS;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtDataInizio;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtDataFine;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtDurataMesi;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.CheckBox checkBox1;
		MetaData Meta;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox textBox12;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox textBox13;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox txtDurataGiorni;
		private System.Windows.Forms.TextBox txtCF;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button btnCF;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.ComboBox cmbContrattoPrecedente;
        protected TextBox textBox11;
        public Label label19;
        private GroupBox grpCity;
        private Label label20;
        private TextBox txtProvincia;
        private TextBox txtGeoComune0101;
        private GroupBox grpIrpef;
        private GroupBox grpComunale;
        private GroupBox grpRegionale;
        private GroupBox groupBox5;
        private ComboBox cmbRegioneFiscale;
        DataTable tParasList;
        private Label label21;
        private TextBox textBox14;
        private Label label23;
        private TextBox textBox16;
        private Label label22;
        private TextBox textBox15;
        private GroupBox groupBox6;
        private Label label25;
        private TextBox textBox18;
        private Label label24;
        private TextBox textBox17;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
		private Label label27;
		private TextBox textBox20;
		private Label label26;
		private TextBox textBox19;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_exhibitedcud_default() {
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
			this.DS = new exhibitedcud_default.vistaForm();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtDurataGiorni = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtDurataMesi = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtDataFine = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtDataInizio = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.grpComunale = new System.Windows.Forms.GroupBox();
			this.label11 = new System.Windows.Forms.Label();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.grpCity = new System.Windows.Forms.GroupBox();
			this.label20 = new System.Windows.Forms.Label();
			this.txtProvincia = new System.Windows.Forms.TextBox();
			this.txtGeoComune0101 = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.textBox11 = new System.Windows.Forms.TextBox();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.grpRegionale = new System.Windows.Forms.GroupBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.cmbRegioneFiscale = new System.Windows.Forms.ComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.grpIrpef = new System.Windows.Forms.GroupBox();
			this.label27 = new System.Windows.Forms.Label();
			this.textBox20 = new System.Windows.Forms.TextBox();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.label26 = new System.Windows.Forms.Label();
			this.textBox19 = new System.Windows.Forms.TextBox();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.label25 = new System.Windows.Forms.Label();
			this.textBox18 = new System.Windows.Forms.TextBox();
			this.label24 = new System.Windows.Forms.Label();
			this.textBox17 = new System.Windows.Forms.TextBox();
			this.label23 = new System.Windows.Forms.Label();
			this.textBox16 = new System.Windows.Forms.TextBox();
			this.label22 = new System.Windows.Forms.Label();
			this.textBox15 = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.textBox14 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.textBox13 = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.textBox12 = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.label13 = new System.Windows.Forms.Label();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.txtCF = new System.Windows.Forms.TextBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.btnCF = new System.Windows.Forms.Button();
			this.label18 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.cmbContrattoPrecedente = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.grpComunale.SuspendLayout();
			this.grpCity.SuspendLayout();
			this.grpRegionale.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.grpIrpef.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.txtDurataGiorni);
			this.groupBox1.Controls.Add(this.label17);
			this.groupBox1.Controls.Add(this.textBox2);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.txtDurataMesi);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtDataFine);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtDataInizio);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(8, 40);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(915, 80);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Date CUD";
			// 
			// txtDurataGiorni
			// 
			this.txtDurataGiorni.Location = new System.Drawing.Point(536, 48);
			this.txtDurataGiorni.Name = "txtDurataGiorni";
			this.txtDurataGiorni.ReadOnly = true;
			this.txtDurataGiorni.Size = new System.Drawing.Size(100, 20);
			this.txtDurataGiorni.TabIndex = 8;
			this.txtDurataGiorni.Tag = "exhibitedcud.ndays";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(440, 46);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(80, 23);
			this.label17.TabIndex = 7;
			this.label17.Text = "Durata (giorni)";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(224, 48);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(100, 20);
			this.textBox2.TabIndex = 5;
			this.textBox2.Tag = "exhibitedcud.fiscalyear.year";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(136, 46);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 20);
			this.label4.TabIndex = 6;
			this.label4.Text = "Anno Fiscale:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDurataMesi
			// 
			this.txtDurataMesi.Location = new System.Drawing.Point(536, 16);
			this.txtDurataMesi.Name = "txtDurataMesi";
			this.txtDurataMesi.ReadOnly = true;
			this.txtDurataMesi.Size = new System.Drawing.Size(100, 20);
			this.txtDurataMesi.TabIndex = 5;
			this.txtDurataMesi.TabStop = false;
			this.txtDurataMesi.Tag = "exhibitedcud.nmonths";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(443, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "Durata (Mesi):";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDataFine
			// 
			this.txtDataFine.Location = new System.Drawing.Point(224, 16);
			this.txtDataFine.Name = "txtDataFine";
			this.txtDataFine.Size = new System.Drawing.Size(100, 20);
			this.txtDataFine.TabIndex = 3;
			this.txtDataFine.Tag = "exhibitedcud.stop";
			this.txtDataFine.TextChanged += new System.EventHandler(this.txtDataFine_TextChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(184, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Fine:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtDataInizio
			// 
			this.txtDataInizio.Location = new System.Drawing.Point(64, 16);
			this.txtDataInizio.Name = "txtDataInizio";
			this.txtDataInizio.Size = new System.Drawing.Size(100, 20);
			this.txtDataInizio.TabIndex = 1;
			this.txtDataInizio.Tag = "exhibitedcud.start";
			this.txtDataInizio.TextChanged += new System.EventHandler(this.txtDataInizio_TextChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Inizio:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.grpComunale);
			this.groupBox2.Controls.Add(this.grpRegionale);
			this.groupBox2.Controls.Add(this.grpIrpef);
			this.groupBox2.Controls.Add(this.button2);
			this.groupBox2.Controls.Add(this.textBox13);
			this.groupBox2.Controls.Add(this.label16);
			this.groupBox2.Controls.Add(this.textBox12);
			this.groupBox2.Controls.Add(this.label15);
			this.groupBox2.Controls.Add(this.textBox3);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.textBox1);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Location = new System.Drawing.Point(8, 235);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(915, 398);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Previdenziale / Fiscale";
			// 
			// grpComunale
			// 
			this.grpComunale.Controls.Add(this.label11);
			this.grpComunale.Controls.Add(this.textBox8);
			this.grpComunale.Controls.Add(this.grpCity);
			this.grpComunale.Controls.Add(this.label12);
			this.grpComunale.Controls.Add(this.textBox11);
			this.grpComunale.Controls.Add(this.textBox9);
			this.grpComunale.Controls.Add(this.label19);
			this.grpComunale.Location = new System.Drawing.Point(3, 200);
			this.grpComunale.Name = "grpComunale";
			this.grpComunale.Size = new System.Drawing.Size(835, 89);
			this.grpComunale.TabIndex = 6;
			this.grpComunale.TabStop = false;
			this.grpComunale.Text = "Addizionale Comunale";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(449, 16);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(65, 23);
			this.label11.TabIndex = 16;
			this.label11.Text = "Applicata:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(521, 16);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(100, 20);
			this.textBox8.TabIndex = 2;
			this.textBox8.Tag = "exhibitedcud.citytaxapplied";
			// 
			// grpCity
			// 
			this.grpCity.Controls.Add(this.label20);
			this.grpCity.Controls.Add(this.txtProvincia);
			this.grpCity.Controls.Add(this.txtGeoComune0101);
			this.grpCity.Location = new System.Drawing.Point(6, 19);
			this.grpCity.Name = "grpCity";
			this.grpCity.Size = new System.Drawing.Size(376, 48);
			this.grpCity.TabIndex = 1;
			this.grpCity.TabStop = false;
			this.grpCity.Tag = "AutoChoose.txtGeoComune0101.default";
			this.grpCity.Text = "Comune all\'1/1:";
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
			this.txtGeoComune0101.Tag = "geo_cityview.title?exhibitedcudview.city0101";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(455, 40);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(61, 16);
			this.label12.TabIndex = 18;
			this.label12.Text = "Sospesa:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox11
			// 
			this.textBox11.Location = new System.Drawing.Point(521, 62);
			this.textBox11.Name = "textBox11";
			this.textBox11.Size = new System.Drawing.Size(100, 20);
			this.textBox11.TabIndex = 4;
			this.textBox11.Tag = "exhibitedcud.citytax_account";
			// 
			// textBox9
			// 
			this.textBox9.Location = new System.Drawing.Point(521, 39);
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new System.Drawing.Size(100, 20);
			this.textBox9.TabIndex = 3;
			this.textBox9.Tag = "exhibitedcud.suspendedcitytax";
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(455, 62);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(60, 16);
			this.label19.TabIndex = 20;
			this.label19.Text = "Acconto:";
			this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// grpRegionale
			// 
			this.grpRegionale.Controls.Add(this.groupBox5);
			this.grpRegionale.Controls.Add(this.label9);
			this.grpRegionale.Controls.Add(this.textBox6);
			this.grpRegionale.Controls.Add(this.label10);
			this.grpRegionale.Controls.Add(this.textBox7);
			this.grpRegionale.Location = new System.Drawing.Point(3, 295);
			this.grpRegionale.Name = "grpRegionale";
			this.grpRegionale.Size = new System.Drawing.Size(835, 68);
			this.grpRegionale.TabIndex = 7;
			this.grpRegionale.TabStop = false;
			this.grpRegionale.Text = "Addizionale Regionale";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.cmbRegioneFiscale);
			this.groupBox5.Location = new System.Drawing.Point(6, 19);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(376, 43);
			this.groupBox5.TabIndex = 15;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Regione Fiscale";
			// 
			// cmbRegioneFiscale
			// 
			this.cmbRegioneFiscale.DataSource = this.DS.fiscaltaxregion;
			this.cmbRegioneFiscale.DisplayMember = "title";
			this.cmbRegioneFiscale.FormattingEnabled = true;
			this.cmbRegioneFiscale.Location = new System.Drawing.Point(6, 16);
			this.cmbRegioneFiscale.Name = "cmbRegioneFiscale";
			this.cmbRegioneFiscale.Size = new System.Drawing.Size(363, 21);
			this.cmbRegioneFiscale.TabIndex = 0;
			this.cmbRegioneFiscale.Tag = "exhibitedcud.idfiscaltaxregion";
			this.cmbRegioneFiscale.ValueMember = "idfiscaltaxregion";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(442, 16);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(75, 23);
			this.label9.TabIndex = 12;
			this.label9.Text = "Applicata:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(523, 16);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(100, 20);
			this.textBox6.TabIndex = 2;
			this.textBox6.Tag = "exhibitedcud.regionaltaxapplied";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(442, 39);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(75, 23);
			this.label10.TabIndex = 14;
			this.label10.Text = "Sospesa:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(523, 39);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(100, 20);
			this.textBox7.TabIndex = 3;
			this.textBox7.Tag = "exhibitedcud.suspendedregionaltax";
			// 
			// grpIrpef
			// 
			this.grpIrpef.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpIrpef.Controls.Add(this.label27);
			this.grpIrpef.Controls.Add(this.textBox20);
			this.grpIrpef.Controls.Add(this.groupBox6);
			this.grpIrpef.Controls.Add(this.label23);
			this.grpIrpef.Controls.Add(this.textBox16);
			this.grpIrpef.Controls.Add(this.label22);
			this.grpIrpef.Controls.Add(this.textBox15);
			this.grpIrpef.Controls.Add(this.label21);
			this.grpIrpef.Controls.Add(this.textBox14);
			this.grpIrpef.Controls.Add(this.label7);
			this.grpIrpef.Controls.Add(this.textBox4);
			this.grpIrpef.Controls.Add(this.label8);
			this.grpIrpef.Controls.Add(this.textBox5);
			this.grpIrpef.Location = new System.Drawing.Point(7, 59);
			this.grpIrpef.Name = "grpIrpef";
			this.grpIrpef.Size = new System.Drawing.Size(893, 135);
			this.grpIrpef.TabIndex = 5;
			this.grpIrpef.TabStop = false;
			this.grpIrpef.Text = "Ritenuta IRPEF";
			// 
			// label27
			// 
			this.label27.Location = new System.Drawing.Point(204, 83);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(167, 23);
			this.label27.TabIndex = 23;
			this.label27.Text = "Detr. per Reddito da 1/7/2020:";
			this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox20
			// 
			this.textBox20.Location = new System.Drawing.Point(388, 86);
			this.textBox20.Name = "textBox20";
			this.textBox20.Size = new System.Drawing.Size(100, 20);
			this.textBox20.TabIndex = 6;
			this.textBox20.Tag = "exhibitedcud.earnings_based_abatements2020";
			// 
			// groupBox6
			// 
			this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox6.Controls.Add(this.label26);
			this.groupBox6.Controls.Add(this.textBox19);
			this.groupBox6.Controls.Add(this.radioButton2);
			this.groupBox6.Controls.Add(this.radioButton1);
			this.groupBox6.Controls.Add(this.label25);
			this.groupBox6.Controls.Add(this.textBox18);
			this.groupBox6.Controls.Add(this.label24);
			this.groupBox6.Controls.Add(this.textBox17);
			this.groupBox6.Location = new System.Drawing.Point(537, 19);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(350, 103);
			this.groupBox6.TabIndex = 7;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Applicazione Bonus";
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(42, 72);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(173, 23);
			this.label26.TabIndex = 28;
			this.label26.Text = "Importo Erogato da 1/7/2020:";
			this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox19
			// 
			this.textBox19.Location = new System.Drawing.Point(221, 75);
			this.textBox19.Name = "textBox19";
			this.textBox19.Size = new System.Drawing.Size(100, 20);
			this.textBox19.TabIndex = 5;
			this.textBox19.Tag = "exhibitedcud.fiscalbonusapplied2020";
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(6, 41);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(87, 17);
			this.radioButton2.TabIndex = 2;
			this.radioButton2.TabStop = true;
			this.radioButton2.Tag = "exhibitedcud.flagbonusaccredited:1";
			this.radioButton2.Text = "Riconosciuto";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point(6, 19);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(105, 17);
			this.radioButton1.TabIndex = 1;
			this.radioButton1.TabStop = true;
			this.radioButton1.Tag = "exhibitedcud.flagbonusaccredited:2";
			this.radioButton1.Text = "Non riconosciuto";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// label25
			// 
			this.label25.Location = new System.Drawing.Point(134, 40);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(84, 18);
			this.label25.TabIndex = 24;
			this.label25.Text = "Non  erogato";
			this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox18
			// 
			this.textBox18.Location = new System.Drawing.Point(221, 41);
			this.textBox18.Name = "textBox18";
			this.textBox18.Size = new System.Drawing.Size(100, 20);
			this.textBox18.TabIndex = 4;
			this.textBox18.Tag = "exhibitedcud.fiscalbonusnotapplied";
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(121, 14);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(94, 23);
			this.label24.TabIndex = 22;
			this.label24.Text = "Importo Erogato:";
			this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox17
			// 
			this.textBox17.Location = new System.Drawing.Point(221, 17);
			this.textBox17.Name = "textBox17";
			this.textBox17.Size = new System.Drawing.Size(100, 20);
			this.textBox17.TabIndex = 3;
			this.textBox17.Tag = "exhibitedcud.fiscalbonusapplied";
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(288, 50);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(94, 20);
			this.label23.TabIndex = 16;
			this.label23.Text = "Tot. Detrazioni:";
			this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox16
			// 
			this.textBox16.Location = new System.Drawing.Point(388, 51);
			this.textBox16.Name = "textBox16";
			this.textBox16.Size = new System.Drawing.Size(100, 20);
			this.textBox16.TabIndex = 5;
			this.textBox16.Tag = "exhibitedcud.totabatements";
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(7, 49);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(99, 23);
			this.label22.TabIndex = 14;
			this.label22.Text = "Detr. per Reddito:";
			this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox15
			// 
			this.textBox15.Location = new System.Drawing.Point(112, 49);
			this.textBox15.Name = "textBox15";
			this.textBox15.Size = new System.Drawing.Size(100, 20);
			this.textBox15.TabIndex = 4;
			this.textBox15.Tag = "exhibitedcud.earnings_based_abatements";
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(349, 16);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(39, 22);
			this.label21.TabIndex = 12;
			this.label21.Text = "Lorda:";
			this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox14
			// 
			this.textBox14.Location = new System.Drawing.Point(388, 18);
			this.textBox14.Name = "textBox14";
			this.textBox14.Size = new System.Drawing.Size(100, 20);
			this.textBox14.TabIndex = 3;
			this.textBox14.Tag = "exhibitedcud.irpefgross";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(1, 19);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(57, 23);
			this.label7.TabIndex = 8;
			this.label7.Text = "Applicata:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(75, 18);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(100, 20);
			this.textBox4.TabIndex = 1;
			this.textBox4.Tag = "exhibitedcud.irpefapplied";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(181, 15);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(57, 24);
			this.label8.TabIndex = 10;
			this.label8.Text = "Sospesa:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(243, 18);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(100, 20);
			this.textBox5.TabIndex = 2;
			this.textBox5.Tag = "exhibitedcud.irpefsuspended";
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button2.Location = new System.Drawing.Point(395, 369);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 8;
			this.button2.Tag = "mainsave";
			this.button2.Text = "Ok";
			// 
			// textBox13
			// 
			this.textBox13.Location = new System.Drawing.Point(532, 39);
			this.textBox13.Name = "textBox13";
			this.textBox13.Size = new System.Drawing.Size(100, 20);
			this.textBox13.TabIndex = 4;
			this.textBox13.Tag = "exhibitedcud.inpsretained";
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(420, 37);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(100, 23);
			this.label16.TabIndex = 4;
			this.label16.Text = "Contributi trattenuti";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox12
			// 
			this.textBox12.Location = new System.Drawing.Point(144, 39);
			this.textBox12.Name = "textBox12";
			this.textBox12.Size = new System.Drawing.Size(100, 20);
			this.textBox12.TabIndex = 3;
			this.textBox12.Tag = "exhibitedcud.inpsowed";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(32, 39);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(100, 23);
			this.label15.TabIndex = 2;
			this.label15.Text = "Contributi dovuti";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(532, 14);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(100, 20);
			this.textBox3.TabIndex = 2;
			this.textBox3.Tag = "exhibitedcud.taxablegross";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(392, 14);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(128, 23);
			this.label6.TabIndex = 6;
			this.label6.Text = "Imponibile Fiscale Lordo";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(144, 16);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(100, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.Tag = "exhibitedcud.taxablepension";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(128, 23);
			this.label5.TabIndex = 0;
			this.label5.Text = "Imponibile Previdenziale";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button1.Location = new System.Drawing.Point(529, 566);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 9;
			this.button1.Text = "Annulla";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(16, 16);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(100, 23);
			this.label13.TabIndex = 2;
			this.label13.Text = "Causa Passaggio";
			// 
			// textBox10
			// 
			this.textBox10.Location = new System.Drawing.Point(15, 29);
			this.textBox10.Name = "textBox10";
			this.textBox10.Size = new System.Drawing.Size(156, 20);
			this.textBox10.TabIndex = 3;
			this.textBox10.Tag = "exhibitedcud.transfermotive";
			// 
			// txtCF
			// 
			this.txtCF.Location = new System.Drawing.Point(8, 16);
			this.txtCF.Name = "txtCF";
			this.txtCF.Size = new System.Drawing.Size(142, 20);
			this.txtCF.TabIndex = 5;
			this.txtCF.Tag = "exhibitedcud.cfotherdeputy";
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(16, 78);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(144, 18);
			this.checkBox1.TabIndex = 6;
			this.checkBox1.Tag = "exhibitedcud.flagignoreprevcud:S:N";
			this.checkBox1.Text = "Ignora CUD Precedenti";
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.groupBox4);
			this.groupBox3.Controls.Add(this.textBox10);
			this.groupBox3.Controls.Add(this.label13);
			this.groupBox3.Controls.Add(this.checkBox1);
			this.groupBox3.Location = new System.Drawing.Point(8, 128);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(915, 104);
			this.groupBox3.TabIndex = 6;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Altre Informazioni";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.btnCF);
			this.groupBox4.Controls.Add(this.label18);
			this.groupBox4.Controls.Add(this.txtCF);
			this.groupBox4.Location = new System.Drawing.Point(187, 16);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(442, 80);
			this.groupBox4.TabIndex = 10;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Codice Fiscale Sostituto";
			// 
			// btnCF
			// 
			this.btnCF.Location = new System.Drawing.Point(8, 48);
			this.btnCF.Name = "btnCF";
			this.btnCF.Size = new System.Drawing.Size(142, 23);
			this.btnCF.TabIndex = 7;
			this.btnCF.TabStop = false;
			this.btnCF.Text = "C.F. Amministrazione";
			this.btnCF.Click += new System.EventHandler(this.btnCF_Click);
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(164, 16);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(272, 56);
			this.label18.TabIndex = 8;
			this.label18.Text = "Se il CUD è riferito ad un contratto svolto con la stessa amministrazione inserir" +
    "e il C.F. dell\'ateneo cliccando sul bottone \"C.F. Amministrazione\"";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(8, 8);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(224, 21);
			this.label14.TabIndex = 10;
			this.label14.Text = "Contratto precedente a cui si riferisce il CUD:";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbContrattoPrecedente
			// 
			this.cmbContrattoPrecedente.Location = new System.Drawing.Point(238, 8);
			this.cmbContrattoPrecedente.Name = "cmbContrattoPrecedente";
			this.cmbContrattoPrecedente.Size = new System.Drawing.Size(229, 21);
			this.cmbContrattoPrecedente.TabIndex = 11;
			this.cmbContrattoPrecedente.Tag = "";
			this.cmbContrattoPrecedente.SelectedIndexChanged += new System.EventHandler(this.cmbContrattoPrecedente_SelectedIndexChanged);
			// 
			// Frm_exhibitedcud_default
			// 
			this.AcceptButton = this.button2;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.button1;
			this.ClientSize = new System.Drawing.Size(931, 678);
			this.Controls.Add(this.cmbContrattoPrecedente);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button1);
			this.Name = "Frm_exhibitedcud_default";
			this.Text = "frmcudpresentato";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.grpComunale.ResumeLayout(false);
			this.grpComunale.PerformLayout();
			this.grpCity.ResumeLayout(false);
			this.grpCity.PerformLayout();
			this.grpRegionale.ResumeLayout(false);
			this.grpRegionale.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.grpIrpef.ResumeLayout(false);
			this.grpIrpef.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion

		bool contrattoGiaConguagliato;        
        CQueryHelper QHC;
        QueryHelper QHS;
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
			DataRow rContratto = Meta.SourceRow.Table.DataSet.Tables["parasubcontract"].Rows[0];

            contrattoGiaConguagliato = false;
            if (Meta.SourceRow.RowState == DataRowState.Added) return;
            // Verifico che il cedolino di conguaglio sia stato pagato solo se non sono in InsertMode del contratto
            // altrimenti non ha senso
			string fCedCong = QHS.AppAnd(QHS.CmpEq("fiscalyear", Meta.GetSys("esercizio")),
                QHS.CmpEq("flagbalance", 'S'), QHS.CmpEq("idcon", Meta.SourceRow["idcon"]));
			DataTable tCedolinoConguaglio = DataAccess.RUN_SELECT(Meta.Conn, "payroll", null, null,
				fCedCong, null, null, true);
			contrattoGiaConguagliato = (tCedolinoConguaglio.Rows.Count>0) && !(tCedolinoConguaglio.Rows[0]["disbursementdate"] is DBNull);
			if (contrattoGiaConguagliato) {
				groupBox1.Enabled = false;
				groupBox3.Enabled = false;
				groupBox2.Enabled = false;
			}
		}

        public void MetaData_AfterActivation() {
            DataRow rContratto = Meta.SourceRow.Table.DataSet.Tables["parasubcontract"].Rows[0];
            DataRow rService = rContratto.GetParentRow("serviceparasubcontract");
            if (rService["certificatekind"].ToString().ToUpper() == "U") {
                fillTabellaContratti();
                popolaComboContrattoPrecedente();
            }
            else {
                cmbContrattoPrecedente.Enabled = false;
            }
        }

        public void MetaData_AfterFill() {
            if (DS.exhibitedcud.Rows.Count == 0) return;
            DataRow Curr = DS.exhibitedcud.Rows[0];
            object descr = "";
            if (Curr["idlinkedcon"] != DBNull.Value) {
                descr = Curr["idlinkeddbdepartment"].ToString() + " - " + Curr["idlinkedcon"].ToString();
            }

            HelpForm.SetComboBoxValue(cmbContrattoPrecedente, descr);
            
            groupBox1.Enabled = (!contrattoGiaConguagliato) && (Curr["idlinkedcon"] == DBNull.Value);
            groupBox3.Enabled = (!contrattoGiaConguagliato) && (Curr["idlinkedcon"] == DBNull.Value);
            groupBox2.Enabled = (!contrattoGiaConguagliato) && (Curr["idlinkedcon"] == DBNull.Value);
        }

        public void MetaData_AfterGetFormData() {
            if (DS.exhibitedcud.Rows.Count == 0) return;
            DataRow Curr = DS.exhibitedcud.Rows[0];
            object selValue = cmbContrattoPrecedente.SelectedValue;
            if ((selValue == null) || (selValue == DBNull.Value)) {
                Curr["idlinkedcon"] = DBNull.Value;
                Curr["idlinkeddbdepartment"] = DBNull.Value;
            }
            else {
                string filter = QHC.CmpEq("!value", selValue);
                DataRow[] List = tParasList.Select(filter);

                if (List.Length != 0) {
                    DataRow rList = List[0];
                    Curr["idlinkedcon"] = rList["idcon"];
                    Curr["idlinkeddbdepartment"] = rList["iddbdepartment"];
                }

            }
        }

        private void fillTabellaContratti() {
            DataRow rContratto = Meta.SourceRow.Table.DataSet.Tables["parasubcontract"].Rows[0];

            tParasList = DataAccess.CreateTableByName(Meta.Conn, "parasubcontractlistview",
                "idcon, iddbdepartment, idreg, balanced");

            tParasList.Columns["idcon"].AllowDBNull = true;
            tParasList.Columns["iddbdepartment"].AllowDBNull = true;

            DataRow rEmpty = tParasList.NewRow();
            rEmpty["idcon"] = DBNull.Value;
            rEmpty["iddbdepartment"] = DBNull.Value;
            rEmpty["balanced"] = "x";
            rEmpty["idreg"] = 0;
            tParasList.Rows.Add(rEmpty);

            string filter = QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")), 
            QHS.CmpEq("transmittedbalance", "S"),
            QHS.CmpEq("linked", 'N'), QHS.CmpEq("balanced", 'S'),
            QHS.CmpEq("idreg", rContratto["idreg"]), 
            QHS.DoPar(QHS.AppOr(
            QHS.CmpNe("idcon", Meta.SourceRow["idcon"]),
            QHS.CmpNe("iddbdepartment", Meta.GetSys("userdb"))
            )));

            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tParasList, null, filter, null, true);

            tParasList.Columns.Add("!description");
            tParasList.Columns.Add("!value");
            tParasList.Columns.Add("!ycon");
            tParasList.Columns.Add("!ncon");

            if (Meta.SourceRow["idlinkedcon"] != DBNull.Value) {
                if (tParasList.Select(QHC.AppAnd(QHC.CmpEq("idcon", Meta.SourceRow["idlinkedcon"]),
                    QHC.CmpEq("iddbdepartment", Meta.SourceRow["idlinkeddbdepartment"]))).Length == 0) {

                    DataRow rParas = tParasList.NewRow();

                    rParas["idcon"] = Meta.SourceRow["idlinkedcon"];
                    rParas["iddbdepartment"] = Meta.SourceRow["idlinkeddbdepartment"];
                    rParas["idreg"] = rContratto["idreg"];

                    object balanced = Meta.Conn.DO_READ_VALUE("parasubcontractlist", QHS.AppAnd(
                        QHS.CmpEq("idcon", Meta.SourceRow["idlinkedcon"]),
                        QHS.CmpEq("iddbdepartment", Meta.SourceRow["idlinkeddbdepartment"]),
                        QHS.CmpEq("ayear", Meta.GetSys("esercizio"))), "balanced");

                    rParas["balanced"] = ((balanced == null) || (balanced == DBNull.Value))
                        ? "N" : balanced.ToString().ToUpper();

                    tParasList.Rows.Add(rParas);
                }
            }

            foreach (DataRow r in tParasList.Rows) {
                if (r["idcon"] == DBNull.Value) {
                    r["!value"] = "";
                    r["!description"] = "";
                    continue;
                }
                string tName = r["iddbdepartment"].ToString() + ".parasubcontract";
                object yCon = Meta.Conn.DO_READ_VALUE(tName, QHS.CmpEq("idcon", r["idcon"]), "ycon");
                object nCon = Meta.Conn.DO_READ_VALUE(tName, QHS.CmpEq("idcon", r["idcon"]), "ncon");
                object idser = Meta.Conn.DO_READ_VALUE(tName, QHS.CmpEq("idcon", r["idcon"]), "idser");
                object certificatekind = Meta.Conn.DO_READ_VALUE("service", QHS.CmpEq("idser", idser), "certificatekind");
                if (certificatekind.ToString().ToUpper() != "U") {
                    continue;
                }

                r["!ycon"] = (yCon == null) ? DBNull.Value : yCon;
                r["!ncon"] = (nCon == null) ? DBNull.Value : nCon;
                r["!value"] = r["iddbdepartment"].ToString() + " - "
                    + r["idcon"].ToString();
                r["!description"] = r["iddbdepartment"].ToString() + " - "
                    + r["!ncon"].ToString() + "/" + r["!ycon"].ToString();
            }

            tParasList.AcceptChanges();
        }

        private void popolaComboContrattoPrecedente() {
            object currVal = "";
            if (Meta.SourceRow["idlinkedcon"] != DBNull.Value) {
                currVal = Meta.SourceRow["idlinkeddbdepartment"].ToString() + " - "
                    + Meta.SourceRow["idlinkedcon"].ToString();
            }

            cmbContrattoPrecedente.DataSource = tParasList;
            cmbContrattoPrecedente.DisplayMember = "!description";
            cmbContrattoPrecedente.ValueMember = "!value";
            HelpForm.SetComboBoxValue(cmbContrattoPrecedente, currVal);
            Meta.myHelpForm.FilteredPreFillCombo(cmbContrattoPrecedente, null, true);
        }

        private string ricavaDenominazioneComune(object idcity) {
            object nomeCitta = Meta.Conn.DO_READ_VALUE("geo_city", QHS.CmpEq("idcity", idcity), "title");
            return nomeCitta == null ? "" : nomeCitta.ToString();
        }

        private string ricavaDenominazioneRegioneFiscale(object idFiscalTaxRegion) {
            object nomeRegione = Meta.Conn.DO_READ_VALUE("fiscaltaxregion",
                QHS.CmpEq("idfiscaltaxregion", idFiscalTaxRegion), "title");
            return nomeRegione == null ? "" : nomeRegione.ToString();
        }

		private void txtDataInizio_TextChanged(object sender, System.EventArgs e) {
			if (!Meta.DrawStateIsDone)return;
			RicalcolaDurataMesi();
		}

		private void txtDataFine_TextChanged(object sender, System.EventArgs e) {
			if (!Meta.DrawStateIsDone)return;
			RicalcolaDurataMesi();
		}

		private void RicalcolaDurataMesi() {
			if ((Meta.InsertMode)||(Meta.EditMode)) {
				object inizio = HelpForm.GetObjectFromString(typeof(DateTime), txtDataInizio.Text, txtDataInizio.Tag.ToString());
				object fine = HelpForm.GetObjectFromString(typeof(DateTime), txtDataFine.Text, txtDataFine.Tag.ToString());

				if ((inizio is DateTime) && (fine is DateTime)) {
					DateTime dataInizio = (DateTime) inizio;
					DateTime dataFine = (DateTime) fine;
						
					int ngiorni = 1 + (dataFine - dataInizio).Days;
					int	nmesi = (dataFine.Year - dataInizio.Year)*12 +
						dataFine.Month - dataInizio.Month + 1;
					txtDurataMesi.Text = nmesi.ToString();
					txtDurataGiorni.Text = ngiorni.ToString();
				}
			}
		}

		private void btnCF_Click(object sender, System.EventArgs e) {
			object cf = Meta.Conn.DO_READ_VALUE("license", null, "cf");
			if (cf != null) {
				txtCF.Text = cf.ToString();
				DS.exhibitedcud.Rows[0]["cfotherdeputy"] = cf;
			}
		}

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if ((T.TableName == "parasubcontractlist")||(T.TableName == "parasubcontractlistview")) {
                if (!Meta.DrawStateIsDone) return;
                if (DS.exhibitedcud.Rows.Count == 0) return;
                DataRow Curr = DS.exhibitedcud.Rows[0];

                if (cmbContrattoPrecedente.SelectedIndex <= 0) {
                    if (!contrattoGiaConguagliato) {
                        groupBox1.Enabled = true;
                        groupBox3.Enabled = true;
                        groupBox2.Enabled = true;
                    }
                    Curr["idlinkedcon"] = DBNull.Value;
                    Curr["idlinkeddbdepartment"] = DBNull.Value;
                }
                else {
                    if (!contrattoGiaConguagliato) {
                        groupBox1.Enabled = true;
                        groupBox3.Enabled = true;
                        groupBox2.Enabled = true;
                    }

                    DataRow rContrattoContenitore = Meta.SourceRow.Table.DataSet.Tables["parasubcontract"].Rows[0];
                    DataRow r = tParasList.Select(QHC.CmpEq("!value", cmbContrattoPrecedente.SelectedValue))[0];

                    CalcoliCococo.cudContratto cud = CalcoliCococo.getInfoCudFromContratto(
                        Meta.Conn,
                        rContrattoContenitore,
                        r);
                    if (cud == null) {
                        MetaFactory.factory.getSingleton<IMessageShower>().Show("Il contratto selezionato non è di tipologia cud", "Avviso");
                        return;
                    }
                    string comune0101 = ricavaDenominazioneComune(cud.idCity);
                    string regionefiscale = ricavaDenominazioneRegioneFiscale(cud.idFiscalTaxRegion);

                    string errori = "";
                    string s = HelpForm.StringValue(cud.dataInizioCompetenza, txtDataInizio.Tag.ToString());
                    if (txtDataInizio.Text != s) {
                        errori += "\nData inizio competenza: " + s + " e non " + txtDataInizio.Text;
                    }
                    s = HelpForm.StringValue(cud.dataFineCompetenza, txtDataFine.Tag.ToString());
                    if (txtDataFine.Text != s) {
                        errori += "\nData fine competenza: " + s + " e non " + txtDataFine.Text;
                    }
                    bool b = cud.flagignoracudprecedenti.ToString() == "S";
                    if (checkBox1.Checked != b) {
                        errori += "\nIgnora cud precedenti: " + b + " e non " + checkBox1.Checked;
                    }
                    s = HelpForm.StringValue(cud.codicefiscalealtrosostituto, txtCF.Tag.ToString());
                    if (txtCF.Text != s) {
                        errori += "\nCodice fiscale altro sostituto: " + s + " e non " + txtCF.Text;
                    }
                    s = HelpForm.StringValue(cud.numeroGiorni, txtDurataGiorni.Tag.ToString());
                    if (txtDurataGiorni.Text != s) {
                        errori += "\nNumero giorni: " + s + " e non " + txtDurataGiorni.Text;
                    }
                    s = HelpForm.StringValue(cud.numeroMesi, txtDurataMesi.Tag.ToString());
                    if (txtDurataMesi.Text != s) {
                        errori += "\nNumero mesi: " + s + " e non " + txtDurataMesi.Text;
                    }
                    s = HelpForm.StringValue(cud.imponibilePrevidenziale, textBox1.Tag.ToString());
                    if (textBox1.Text != s) {
                        errori += "\nImponibile previdenziale: " + s + " e non " + textBox1.Text;
                    }
                    s = HelpForm.StringValue(cud.imponibilefiscalelordo, textBox3.Tag.ToString());
                    if (textBox3.Text != s) {
                        errori += "\nImponibile fiscale lordo: " + s + " e non " + textBox3.Text;
                    }
                    s = HelpForm.StringValue(cud.addComApplicata, textBox8.Tag.ToString());
                    if (textBox8.Text != s) {
                        errori += "\nAdd. com. applicata: " + s + " e non " + textBox8.Text;
                    }
                    s = HelpForm.StringValue(cud.addRegApplicata, textBox6.Tag.ToString());
                    if (textBox6.Text != s) {
                        errori += "\nAdd. reg. applicata: " + s + " e non " + textBox6.Text;
                    }
                    s = HelpForm.StringValue(cud.irpefApplicata, textBox4.Tag.ToString());
                    if (textBox4.Text != s) {
                        errori += "\nIrpef applicata: " + s + " e non " + textBox4.Text;
                    }
                    s = HelpForm.StringValue(cud.irpefGross, textBox14.Tag.ToString());
                    if (textBox14.Text != s)
                    {
                        errori += "\nIrpef Lorda: " + s + " e non " + textBox14.Text;
                    }
                    s = HelpForm.StringValue(cud.earnings_based_abatements, textBox15.Tag.ToString());
                    if (textBox15.Text != s)
                    {
                        errori += "\nDetrazioni per Reddito: " + s + " e non " + textBox15.Text;
                    }
                    s = HelpForm.StringValue(cud.totabatements, textBox16.Tag.ToString());
                    if (textBox16.Text != s)
                    {
                        errori += "\nTotale Detrazioni: " + s + " e non " + textBox16.Text;
                    }
                    s = HelpForm.StringValue(cud.fiscalBonusApplied, textBox17.Tag.ToString());
                    if (textBox17.Text != s)
                    {
                        errori += "\nBonus Applicato: " + s + " e non " + textBox17.Text;
                    }
                    s = HelpForm.StringValue(cud.contributiTrattenuti, textBox13.Tag.ToString());
                    if (textBox13.Text != s) {
                        errori += "\nContributi trattenuti: " + s + " e non " + textBox13.Text;
                    }
                    s = HelpForm.StringValue(cud.contributiDovuti, textBox12.Tag.ToString());
                    if (textBox12.Text != s) {
                        errori += "\nContributi dovuti: " + s + " e non " + textBox12.Text;
                    }
                    s = comune0101;
                    if (txtGeoComune0101.Text != s) {
                        errori += "\nComune all'1/1: " + s + " e non " + txtGeoComune0101.Text;
                    }

                    DataRow [] FR = DS.fiscaltaxregion.Select(
                        QHC.CmpEq("idfiscaltaxregion", cmbRegioneFiscale.SelectedValue));
                    string nomeRegioneCombo = (FR.Length > 0) ? FR[0]["title"].ToString() : "";
                    s = regionefiscale;
                    if (nomeRegioneCombo != s) {
                        errori += "\nRegione fiscale: "
                            + s + " e non " + nomeRegioneCombo;
                    }

                    txtCF.Text = HelpForm.StringValue(cud.codicefiscalealtrosostituto, txtCF.Tag.ToString());
                    if (contrattoGiaConguagliato) {
                        if (errori != "") {
                            MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Ci sono le seguenti incoerenze tra il contratto scelto e le informazioni contenute nel cud:"
                                + errori);
                        }
                    }
                    else {
                        if (errori != "" ) {
                            if (Meta.EditMode) {
                                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Ci sono le seguenti incoerenze tra il contratto scelto e le informazioni contenute nel cud:" + errori,
                                    "Modifica del cud", MessageBoxButtons.OK);
                            }
                            txtDataInizio.Text = HelpForm.StringValue(cud.dataInizioCompetenza, txtDataInizio.Tag.ToString());
                            txtDataFine.Text = HelpForm.StringValue(cud.dataFineCompetenza, txtDataFine.Tag.ToString());
                            checkBox1.Checked = cud.flagignoracudprecedenti.ToString() == "S";
                            txtCF.Text = HelpForm.StringValue(cud.codicefiscalealtrosostituto, txtCF.Tag.ToString());
                            txtDurataGiorni.Text = HelpForm.StringValue(cud.numeroGiorni, txtDurataGiorni.Tag.ToString());
                            txtDurataMesi.Text = HelpForm.StringValue(cud.numeroMesi, txtDurataMesi.Tag.ToString());
                            textBox1.Text = HelpForm.StringValue(cud.imponibilePrevidenziale, textBox1.Tag.ToString());
                            textBox3.Text = HelpForm.StringValue(cud.imponibilefiscalelordo, textBox3.Tag.ToString());
                            textBox8.Text = HelpForm.StringValue(cud.addComApplicata, textBox8.Tag.ToString());
                            textBox6.Text = HelpForm.StringValue(cud.addRegApplicata, textBox6.Tag.ToString());
                            textBox4.Text = HelpForm.StringValue(cud.irpefApplicata, textBox4.Tag.ToString());
                            textBox14.Text = HelpForm.StringValue(cud.irpefGross, textBox14.Tag.ToString());
                            textBox15.Text = HelpForm.StringValue(cud.earnings_based_abatements, textBox15.Tag.ToString());
                            textBox16.Text = HelpForm.StringValue(cud.totabatements, textBox16.Tag.ToString());
                            textBox17.Text = HelpForm.StringValue(cud.fiscalBonusApplied, textBox17.Tag.ToString());
                            textBox13.Text = HelpForm.StringValue(cud.contributiTrattenuti, textBox13.Tag.ToString());
                            textBox12.Text = HelpForm.StringValue(cud.contributiDovuti, textBox12.Tag.ToString());
                            textBox11.Text = HelpForm.StringValue(cud.accontoAddComunale, textBox11.Tag.ToString());
                            DataRow rCud = DS.exhibitedcud.Rows[0];
                            rCud["idcity"] = cud.idCity;
                            rCud["idfiscaltaxregion"] = cud.idFiscalTaxRegion;
                            txtGeoComune0101.Text = comune0101;
                            HelpForm.SetComboBoxValue(cmbRegioneFiscale, cud.idFiscalTaxRegion);
                        }
                    }

                    Curr["idlinkedcon"] = r["idcon"];
                    Curr["idlinkeddbdepartment"] = r["iddbdepartment"];
                }
            }
        }

        private void cmbContrattoPrecedente_SelectedIndexChanged(object sender, EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            if (DS.exhibitedcud.Rows.Count == 0) return;
            
            DataRow r = tParasList.Select(QHC.CmpEq("!value", cmbContrattoPrecedente.SelectedValue))[0];
            MetaData_AfterRowSelect(tParasList, r);
        }
	}
}
