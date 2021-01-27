
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
using System.Data;
using metadatalibrary;
using metaeasylibrary;

namespace serviceagency_default
{
	/// <summary>
	/// Summary description for Frm_serviceagency_default.
	/// </summary>
	public class Frm_serviceagency_default : System.Windows.Forms.Form
	{
		public serviceagency_default.vistaForm DS;
		//bool CanGoEdit;
		//bool CanGoInsert;
        MetaData Meta;
        private TabControl tabControl1;
        private TabPage tabPrincipale;
        private TextBox textBox10;
        private TextBox textBox8;
        private TextBox textBox1;
        private Label label9;
        private Label label7;
        private Label label1;
        private TabPage tabAttributi;
        public GroupBox gboxclass05;
        public ComboBox cmbCodice05;
        public Button btnCodice05;
        private TextBox txtDenom05;
        public GroupBox gboxclass04;
        public ComboBox cmbCodice04;
        public Button btnCodice04;
        private TextBox txtDenom04;
        public GroupBox gboxclass03;
        public ComboBox cmbCodice03;
        public Button btnCodice03;
        private TextBox txtDenom03;
        public GroupBox gboxclass02;
        public ComboBox cmbCodice02;
        public Button btnCodice02;
        private TextBox txtDenom02;
        public GroupBox gboxclass01;
        public ComboBox cmbCodice01;
        public Button btnCodice01;
        private TextBox txtDenom01;
		private TextBox txtCodicePaIpa;
		private Label label40;
		private TextBox txtUOIpa;
		private Label label39;
		private TextBox txtAOOIpa;
		private Label label38;
		private Label label2;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_serviceagency_default()
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPrincipale = new System.Windows.Forms.TabPage();
			this.label2 = new System.Windows.Forms.Label();
			this.txtCodicePaIpa = new System.Windows.Forms.TextBox();
			this.label40 = new System.Windows.Forms.Label();
			this.txtUOIpa = new System.Windows.Forms.TextBox();
			this.label39 = new System.Windows.Forms.Label();
			this.txtAOOIpa = new System.Windows.Forms.TextBox();
			this.label38 = new System.Windows.Forms.Label();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tabAttributi = new System.Windows.Forms.TabPage();
			this.gboxclass05 = new System.Windows.Forms.GroupBox();
			this.cmbCodice05 = new System.Windows.Forms.ComboBox();
			this.DS = new serviceagency_default.vistaForm();
			this.btnCodice05 = new System.Windows.Forms.Button();
			this.txtDenom05 = new System.Windows.Forms.TextBox();
			this.gboxclass04 = new System.Windows.Forms.GroupBox();
			this.cmbCodice04 = new System.Windows.Forms.ComboBox();
			this.btnCodice04 = new System.Windows.Forms.Button();
			this.txtDenom04 = new System.Windows.Forms.TextBox();
			this.gboxclass03 = new System.Windows.Forms.GroupBox();
			this.cmbCodice03 = new System.Windows.Forms.ComboBox();
			this.btnCodice03 = new System.Windows.Forms.Button();
			this.txtDenom03 = new System.Windows.Forms.TextBox();
			this.gboxclass02 = new System.Windows.Forms.GroupBox();
			this.cmbCodice02 = new System.Windows.Forms.ComboBox();
			this.btnCodice02 = new System.Windows.Forms.Button();
			this.txtDenom02 = new System.Windows.Forms.TextBox();
			this.gboxclass01 = new System.Windows.Forms.GroupBox();
			this.cmbCodice01 = new System.Windows.Forms.ComboBox();
			this.btnCodice01 = new System.Windows.Forms.Button();
			this.txtDenom01 = new System.Windows.Forms.TextBox();
			this.tabControl1.SuspendLayout();
			this.tabPrincipale.SuspendLayout();
			this.tabAttributi.SuspendLayout();
			this.gboxclass05.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.gboxclass04.SuspendLayout();
			this.gboxclass03.SuspendLayout();
			this.gboxclass02.SuspendLayout();
			this.gboxclass01.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPrincipale);
			this.tabControl1.Controls.Add(this.tabAttributi);
			this.tabControl1.Location = new System.Drawing.Point(12, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(470, 396);
			this.tabControl1.TabIndex = 55;
			// 
			// tabPrincipale
			// 
			this.tabPrincipale.Controls.Add(this.label2);
			this.tabPrincipale.Controls.Add(this.txtCodicePaIpa);
			this.tabPrincipale.Controls.Add(this.label40);
			this.tabPrincipale.Controls.Add(this.txtUOIpa);
			this.tabPrincipale.Controls.Add(this.label39);
			this.tabPrincipale.Controls.Add(this.txtAOOIpa);
			this.tabPrincipale.Controls.Add(this.label38);
			this.tabPrincipale.Controls.Add(this.textBox10);
			this.tabPrincipale.Controls.Add(this.textBox8);
			this.tabPrincipale.Controls.Add(this.textBox1);
			this.tabPrincipale.Controls.Add(this.label9);
			this.tabPrincipale.Controls.Add(this.label7);
			this.tabPrincipale.Controls.Add(this.label1);
			this.tabPrincipale.Location = new System.Drawing.Point(4, 22);
			this.tabPrincipale.Name = "tabPrincipale";
			this.tabPrincipale.Padding = new System.Windows.Forms.Padding(3);
			this.tabPrincipale.Size = new System.Drawing.Size(462, 370);
			this.tabPrincipale.TabIndex = 0;
			this.tabPrincipale.Text = "Principale";
			this.tabPrincipale.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(82, 313);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(325, 26);
			this.label2.TabIndex = 83;
			this.label2.Text = "Nota: AOO e UO vanno valorizzati in modo mutualmente esclusivo. \r\nOve inseriti en" +
    "trambi sarà considerato solo AOO";
			// 
			// txtCodicePaIpa
			// 
			this.txtCodicePaIpa.Location = new System.Drawing.Point(85, 219);
			this.txtCodicePaIpa.Name = "txtCodicePaIpa";
			this.txtCodicePaIpa.Size = new System.Drawing.Size(158, 20);
			this.txtCodicePaIpa.TabIndex = 82;
			this.txtCodicePaIpa.Tag = "serviceagency.codicepaipa";
			// 
			// label40
			// 
			this.label40.AutoSize = true;
			this.label40.Location = new System.Drawing.Point(17, 222);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(57, 13);
			this.label40.TabIndex = 81;
			this.label40.Text = "Codice PA";
			// 
			// txtUOIpa
			// 
			this.txtUOIpa.Location = new System.Drawing.Point(85, 278);
			this.txtUOIpa.Name = "txtUOIpa";
			this.txtUOIpa.Size = new System.Drawing.Size(279, 20);
			this.txtUOIpa.TabIndex = 80;
			this.txtUOIpa.Tag = "serviceagency.codiceuoipa";
			// 
			// label39
			// 
			this.label39.AutoSize = true;
			this.label39.Location = new System.Drawing.Point(44, 281);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(23, 13);
			this.label39.TabIndex = 79;
			this.label39.Text = "UO";
			// 
			// txtAOOIpa
			// 
			this.txtAOOIpa.Location = new System.Drawing.Point(85, 252);
			this.txtAOOIpa.Name = "txtAOOIpa";
			this.txtAOOIpa.Size = new System.Drawing.Size(279, 20);
			this.txtAOOIpa.TabIndex = 78;
			this.txtAOOIpa.Tag = "serviceagency.codiceaooipa";
			// 
			// label38
			// 
			this.label38.AutoSize = true;
			this.label38.Location = new System.Drawing.Point(44, 255);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(30, 13);
			this.label38.TabIndex = 77;
			this.label38.Text = "AOO";
			// 
			// textBox10
			// 
			this.textBox10.Location = new System.Drawing.Point(15, 65);
			this.textBox10.Name = "textBox10";
			this.textBox10.Size = new System.Drawing.Size(230, 20);
			this.textBox10.TabIndex = 55;
			this.textBox10.Tag = "serviceagency.pa_code";
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(15, 114);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(150, 20);
			this.textBox8.TabIndex = 56;
			this.textBox8.Tag = "serviceagency.pa_cf";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(14, 169);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(439, 32);
			this.textBox1.TabIndex = 57;
			this.textBox1.Tag = "serviceagency.pa_title";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(17, 44);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(110, 23);
			this.label9.TabIndex = 60;
			this.label9.Text = "Codice";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(12, 93);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(126, 23);
			this.label7.TabIndex = 59;
			this.label7.Text = "Codice fiscale:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(14, 149);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(238, 23);
			this.label1.TabIndex = 58;
			this.label1.Text = "Nome Dipartimento o Amministrazione:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tabAttributi
			// 
			this.tabAttributi.Controls.Add(this.gboxclass05);
			this.tabAttributi.Controls.Add(this.gboxclass04);
			this.tabAttributi.Controls.Add(this.gboxclass03);
			this.tabAttributi.Controls.Add(this.gboxclass02);
			this.tabAttributi.Controls.Add(this.gboxclass01);
			this.tabAttributi.Location = new System.Drawing.Point(4, 22);
			this.tabAttributi.Name = "tabAttributi";
			this.tabAttributi.Padding = new System.Windows.Forms.Padding(3);
			this.tabAttributi.Size = new System.Drawing.Size(462, 370);
			this.tabAttributi.TabIndex = 1;
			this.tabAttributi.Text = "Attributi";
			this.tabAttributi.UseVisualStyleBackColor = true;
			// 
			// gboxclass05
			// 
			this.gboxclass05.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxclass05.Controls.Add(this.cmbCodice05);
			this.gboxclass05.Controls.Add(this.btnCodice05);
			this.gboxclass05.Controls.Add(this.txtDenom05);
			this.gboxclass05.Location = new System.Drawing.Point(18, 286);
			this.gboxclass05.Name = "gboxclass05";
			this.gboxclass05.Size = new System.Drawing.Size(427, 64);
			this.gboxclass05.TabIndex = 28;
			this.gboxclass05.TabStop = false;
			this.gboxclass05.Tag = "";
			this.gboxclass05.Text = "Classificazione 5";
			// 
			// cmbCodice05
			// 
			this.cmbCodice05.DataSource = this.DS.sorting05;
			this.cmbCodice05.DisplayMember = "sortcode";
			this.cmbCodice05.FormattingEnabled = true;
			this.cmbCodice05.Location = new System.Drawing.Point(9, 40);
			this.cmbCodice05.Name = "cmbCodice05";
			this.cmbCodice05.Size = new System.Drawing.Size(205, 21);
			this.cmbCodice05.TabIndex = 13;
			this.cmbCodice05.Tag = "serviceagency.idsor05";
			this.cmbCodice05.ValueMember = "idsor";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// btnCodice05
			// 
			this.btnCodice05.Location = new System.Drawing.Point(8, 16);
			this.btnCodice05.Name = "btnCodice05";
			this.btnCodice05.Size = new System.Drawing.Size(88, 23);
			this.btnCodice05.TabIndex = 4;
			this.btnCodice05.Tag = "manage.sorting05.tree";
			this.btnCodice05.Text = "Codice";
			this.btnCodice05.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtDenom05
			// 
			this.txtDenom05.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenom05.Location = new System.Drawing.Point(220, 8);
			this.txtDenom05.Multiline = true;
			this.txtDenom05.Name = "txtDenom05";
			this.txtDenom05.ReadOnly = true;
			this.txtDenom05.Size = new System.Drawing.Size(199, 52);
			this.txtDenom05.TabIndex = 3;
			this.txtDenom05.TabStop = false;
			this.txtDenom05.Tag = "sorting05.description";
			// 
			// gboxclass04
			// 
			this.gboxclass04.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxclass04.Controls.Add(this.cmbCodice04);
			this.gboxclass04.Controls.Add(this.btnCodice04);
			this.gboxclass04.Controls.Add(this.txtDenom04);
			this.gboxclass04.Location = new System.Drawing.Point(18, 216);
			this.gboxclass04.Name = "gboxclass04";
			this.gboxclass04.Size = new System.Drawing.Size(427, 64);
			this.gboxclass04.TabIndex = 27;
			this.gboxclass04.TabStop = false;
			this.gboxclass04.Tag = "";
			this.gboxclass04.Text = "Classificazione 4";
			// 
			// cmbCodice04
			// 
			this.cmbCodice04.DataSource = this.DS.sorting04;
			this.cmbCodice04.DisplayMember = "sortcode";
			this.cmbCodice04.FormattingEnabled = true;
			this.cmbCodice04.Location = new System.Drawing.Point(10, 40);
			this.cmbCodice04.Name = "cmbCodice04";
			this.cmbCodice04.Size = new System.Drawing.Size(205, 21);
			this.cmbCodice04.TabIndex = 13;
			this.cmbCodice04.Tag = "serviceagency.idsor04";
			this.cmbCodice04.ValueMember = "idsor";
			// 
			// btnCodice04
			// 
			this.btnCodice04.Location = new System.Drawing.Point(8, 16);
			this.btnCodice04.Name = "btnCodice04";
			this.btnCodice04.Size = new System.Drawing.Size(88, 23);
			this.btnCodice04.TabIndex = 4;
			this.btnCodice04.Tag = "manage.sorting04.tree";
			this.btnCodice04.Text = "Codice";
			this.btnCodice04.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtDenom04
			// 
			this.txtDenom04.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenom04.Location = new System.Drawing.Point(220, 8);
			this.txtDenom04.Multiline = true;
			this.txtDenom04.Name = "txtDenom04";
			this.txtDenom04.ReadOnly = true;
			this.txtDenom04.Size = new System.Drawing.Size(199, 52);
			this.txtDenom04.TabIndex = 3;
			this.txtDenom04.TabStop = false;
			this.txtDenom04.Tag = "sorting04.description";
			// 
			// gboxclass03
			// 
			this.gboxclass03.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxclass03.Controls.Add(this.cmbCodice03);
			this.gboxclass03.Controls.Add(this.btnCodice03);
			this.gboxclass03.Controls.Add(this.txtDenom03);
			this.gboxclass03.Location = new System.Drawing.Point(19, 146);
			this.gboxclass03.Name = "gboxclass03";
			this.gboxclass03.Size = new System.Drawing.Size(427, 64);
			this.gboxclass03.TabIndex = 25;
			this.gboxclass03.TabStop = false;
			this.gboxclass03.Tag = "";
			this.gboxclass03.Text = "Classificazione 3";
			// 
			// cmbCodice03
			// 
			this.cmbCodice03.DataSource = this.DS.sorting03;
			this.cmbCodice03.DisplayMember = "sortcode";
			this.cmbCodice03.FormattingEnabled = true;
			this.cmbCodice03.Location = new System.Drawing.Point(9, 40);
			this.cmbCodice03.Name = "cmbCodice03";
			this.cmbCodice03.Size = new System.Drawing.Size(205, 21);
			this.cmbCodice03.TabIndex = 12;
			this.cmbCodice03.Tag = "serviceagency.idsor03";
			this.cmbCodice03.ValueMember = "idsor";
			// 
			// btnCodice03
			// 
			this.btnCodice03.Location = new System.Drawing.Point(8, 16);
			this.btnCodice03.Name = "btnCodice03";
			this.btnCodice03.Size = new System.Drawing.Size(88, 23);
			this.btnCodice03.TabIndex = 4;
			this.btnCodice03.Tag = "manage.sorting03.tree";
			this.btnCodice03.Text = "Codice";
			this.btnCodice03.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtDenom03
			// 
			this.txtDenom03.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenom03.Location = new System.Drawing.Point(220, 8);
			this.txtDenom03.Multiline = true;
			this.txtDenom03.Name = "txtDenom03";
			this.txtDenom03.ReadOnly = true;
			this.txtDenom03.Size = new System.Drawing.Size(199, 52);
			this.txtDenom03.TabIndex = 3;
			this.txtDenom03.TabStop = false;
			this.txtDenom03.Tag = "sorting03.description";
			// 
			// gboxclass02
			// 
			this.gboxclass02.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxclass02.Controls.Add(this.cmbCodice02);
			this.gboxclass02.Controls.Add(this.btnCodice02);
			this.gboxclass02.Controls.Add(this.txtDenom02);
			this.gboxclass02.Location = new System.Drawing.Point(19, 76);
			this.gboxclass02.Name = "gboxclass02";
			this.gboxclass02.Size = new System.Drawing.Size(426, 64);
			this.gboxclass02.TabIndex = 26;
			this.gboxclass02.TabStop = false;
			this.gboxclass02.Tag = "";
			this.gboxclass02.Text = "Classificazione 2";
			// 
			// cmbCodice02
			// 
			this.cmbCodice02.DataSource = this.DS.sorting02;
			this.cmbCodice02.DisplayMember = "sortcode";
			this.cmbCodice02.FormattingEnabled = true;
			this.cmbCodice02.Location = new System.Drawing.Point(8, 39);
			this.cmbCodice02.Name = "cmbCodice02";
			this.cmbCodice02.Size = new System.Drawing.Size(205, 21);
			this.cmbCodice02.TabIndex = 11;
			this.cmbCodice02.Tag = "serviceagency.idsor02";
			this.cmbCodice02.ValueMember = "idsor";
			// 
			// btnCodice02
			// 
			this.btnCodice02.Location = new System.Drawing.Point(8, 16);
			this.btnCodice02.Name = "btnCodice02";
			this.btnCodice02.Size = new System.Drawing.Size(88, 23);
			this.btnCodice02.TabIndex = 4;
			this.btnCodice02.Tag = "manage.sorting02.tree";
			this.btnCodice02.Text = "Codice";
			this.btnCodice02.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtDenom02
			// 
			this.txtDenom02.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenom02.Location = new System.Drawing.Point(220, 8);
			this.txtDenom02.Multiline = true;
			this.txtDenom02.Name = "txtDenom02";
			this.txtDenom02.ReadOnly = true;
			this.txtDenom02.Size = new System.Drawing.Size(198, 52);
			this.txtDenom02.TabIndex = 3;
			this.txtDenom02.TabStop = false;
			this.txtDenom02.Tag = "sorting02.description";
			// 
			// gboxclass01
			// 
			this.gboxclass01.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxclass01.Controls.Add(this.cmbCodice01);
			this.gboxclass01.Controls.Add(this.btnCodice01);
			this.gboxclass01.Controls.Add(this.txtDenom01);
			this.gboxclass01.Location = new System.Drawing.Point(19, 6);
			this.gboxclass01.Name = "gboxclass01";
			this.gboxclass01.Size = new System.Drawing.Size(426, 64);
			this.gboxclass01.TabIndex = 24;
			this.gboxclass01.TabStop = false;
			this.gboxclass01.Tag = "";
			this.gboxclass01.Text = "Classificazione 1";
			// 
			// cmbCodice01
			// 
			this.cmbCodice01.DataSource = this.DS.sorting01;
			this.cmbCodice01.DisplayMember = "sortcode";
			this.cmbCodice01.FormattingEnabled = true;
			this.cmbCodice01.Location = new System.Drawing.Point(9, 39);
			this.cmbCodice01.Name = "cmbCodice01";
			this.cmbCodice01.Size = new System.Drawing.Size(205, 21);
			this.cmbCodice01.TabIndex = 10;
			this.cmbCodice01.Tag = "serviceagency.idsor01";
			this.cmbCodice01.ValueMember = "idsor";
			// 
			// btnCodice01
			// 
			this.btnCodice01.Location = new System.Drawing.Point(8, 16);
			this.btnCodice01.Name = "btnCodice01";
			this.btnCodice01.Size = new System.Drawing.Size(88, 23);
			this.btnCodice01.TabIndex = 4;
			this.btnCodice01.Tag = "manage.sorting01.tree";
			this.btnCodice01.Text = "Codice";
			this.btnCodice01.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtDenom01
			// 
			this.txtDenom01.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenom01.Location = new System.Drawing.Point(220, 8);
			this.txtDenom01.Multiline = true;
			this.txtDenom01.Name = "txtDenom01";
			this.txtDenom01.ReadOnly = true;
			this.txtDenom01.Size = new System.Drawing.Size(198, 52);
			this.txtDenom01.TabIndex = 3;
			this.txtDenom01.TabStop = false;
			this.txtDenom01.Tag = "sorting01.description";
			// 
			// Frm_serviceagency_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(488, 418);
			this.Controls.Add(this.tabControl1);
			this.Name = "Frm_serviceagency_default";
			this.Text = "Frm_serviceagency_default";
			this.tabControl1.ResumeLayout(false);
			this.tabPrincipale.ResumeLayout(false);
			this.tabPrincipale.PerformLayout();
			this.tabAttributi.ResumeLayout(false);
			this.gboxclass05.ResumeLayout(false);
			this.gboxclass05.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.gboxclass04.ResumeLayout(false);
			this.gboxclass04.PerformLayout();
			this.gboxclass03.ResumeLayout(false);
			this.gboxclass03.PerformLayout();
			this.gboxclass02.ResumeLayout(false);
			this.gboxclass02.PerformLayout();
			this.gboxclass01.ResumeLayout(false);
			this.gboxclass01.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion

        CQueryHelper QHC;
        QueryHelper QHS;
		public void MetaData_AfterLink() 
		{
			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
			 

            DataAccess.SetTableForReading(DS.sorting01, "sorting");
            DataAccess.SetTableForReading(DS.sorting02, "sorting");
            DataAccess.SetTableForReading(DS.sorting03, "sorting");
            DataAccess.SetTableForReading(DS.sorting04, "sorting");
            DataAccess.SetTableForReading(DS.sorting05, "sorting");

            DataTable tUniConfig = Meta.Conn.RUN_SELECT("uniconfig", "*", null,
              null, null, null, true);
            if ((tUniConfig != null) && (tUniConfig.Rows.Count > 0))
            {
                DataRow r = tUniConfig.Rows[0];
                object idsorkind1 = r["idsorkind01"];
                object idsorkind2 = r["idsorkind02"];
                object idsorkind3 = r["idsorkind03"];
                object idsorkind4 = r["idsorkind04"];
                object idsorkind5 = r["idsorkind05"];
                SetGBoxClass0(1, idsorkind1);
                SetGBoxClass0(2, idsorkind2);
                SetGBoxClass0(3, idsorkind3);
                SetGBoxClass0(4, idsorkind4);
                SetGBoxClass0(5, idsorkind5);
                if (idsorkind1 == DBNull.Value && idsorkind2 == DBNull.Value &&
                    idsorkind3 == DBNull.Value && idsorkind4 == DBNull.Value && idsorkind5 == DBNull.Value)
                {
                    tabControl1.TabPages.Remove(tabAttributi);
                }
            }
        }

             object GetCtrlByName(string Name)
        {
            System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
            if (Ctrl == null) return null;
            return Ctrl.GetValue(this);
        }

        void SetGBoxClass0(int num, object sortingkind)
        {
            string nums = num.ToString();
            if (sortingkind == DBNull.Value)
            {
                GroupBox G = (GroupBox)GetCtrlByName("gboxclass0" + nums);
                G.Visible = false;
                ComboBox C = (ComboBox)GetCtrlByName("cmbCodice0" + nums);
                C.Tag = null;
                C.DataSource = null;
            }
            else
            {
                string filter = QHS.CmpEq("idsorkind", sortingkind);
                GetData.SetStaticFilter(DS.Tables["sorting0" + nums], filter);
                GroupBox gboxclass = (GroupBox)GetCtrlByName("gboxclass0" + nums);
                Button btnCodice = (Button)GetCtrlByName("btnCodice0" + nums);
                //gboxclass.Tag = "AutoManage.txtCodice0" + nums + ".tree." + filter;
                string title = Meta.Conn.DO_READ_VALUE("sortingkind", filter, "description").ToString();
                gboxclass.Text = title;
                btnCodice.Tag = "manage.sorting0" + nums + ".tree." + filter;
                DS.Tables["sorting0" + nums].ExtendedProperties[MetaData.ExtraParams] = filter;
            }
        }
		

		public void MetaData_AfterClear()
		{
			 

		}

		private void richTextBox1_LinkClicked(object sender, System.Windows.Forms.LinkClickedEventArgs e)
		{
				System.Diagnostics.Process.Start(e.LinkText);
		}



	}
}
