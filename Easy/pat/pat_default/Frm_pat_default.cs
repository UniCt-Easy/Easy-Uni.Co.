
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

namespace pat_default {//patlista//
	/// <summary>
	/// Summary description for frmpatlista.
	/// </summary>
	public class Frm_pat_default : MetaDataForm {
		public vistaForm DS;
		private System.Windows.Forms.ImageList images;
		public System.Windows.Forms.GroupBox MetaDataDetail;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.TextBox textBox11;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBox12;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private TextBox textBoxCC;
		private Label labelCC;
		private Label labelCodiceSede;
		private TextBox textBoxCodiceSede;
		private GroupBox groupBox4;
		private System.ComponentModel.IContainer components;

		public Frm_pat_default() {
			InitializeComponent();
			HelpForm.SetDenyNull(DS.pat.Columns["active"], true);
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_pat_default));
			this.images = new System.Windows.Forms.ImageList(this.components);
			this.MetaDataDetail = new System.Windows.Forms.GroupBox();
			this.textBoxCodiceSede = new System.Windows.Forms.TextBox();
			this.labelCodiceSede = new System.Windows.Forms.Label();
			this.textBoxCC = new System.Windows.Forms.TextBox();
			this.labelCC = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.panel5 = new System.Windows.Forms.Panel();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.panel4 = new System.Windows.Forms.Panel();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.textBox11 = new System.Windows.Forms.TextBox();
			this.panel6 = new System.Windows.Forms.Panel();
			this.textBox12 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.DS = new pat_default.vistaForm();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.MetaDataDetail.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
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
			// MetaDataDetail
			// 
			this.MetaDataDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.MetaDataDetail.Controls.Add(this.groupBox4);
			this.MetaDataDetail.Controls.Add(this.textBoxCC);
			this.MetaDataDetail.Controls.Add(this.labelCC);
			this.MetaDataDetail.Controls.Add(this.groupBox3);
			this.MetaDataDetail.Controls.Add(this.groupBox2);
			this.MetaDataDetail.Controls.Add(this.groupBox1);
			this.MetaDataDetail.Controls.Add(this.textBox12);
			this.MetaDataDetail.Controls.Add(this.label9);
			this.MetaDataDetail.Controls.Add(this.textBox5);
			this.MetaDataDetail.Controls.Add(this.label5);
			this.MetaDataDetail.Controls.Add(this.checkBox1);
			this.MetaDataDetail.Controls.Add(this.textBox4);
			this.MetaDataDetail.Controls.Add(this.label4);
			this.MetaDataDetail.Controls.Add(this.textBox3);
			this.MetaDataDetail.Controls.Add(this.label3);
			this.MetaDataDetail.Controls.Add(this.textBox2);
			this.MetaDataDetail.Controls.Add(this.label2);
			this.MetaDataDetail.Controls.Add(this.textBox1);
			this.MetaDataDetail.Controls.Add(this.label1);
			this.MetaDataDetail.Location = new System.Drawing.Point(8, 6);
			this.MetaDataDetail.Name = "MetaDataDetail";
			this.MetaDataDetail.Size = new System.Drawing.Size(520, 297);
			this.MetaDataDetail.TabIndex = 45;
			this.MetaDataDetail.TabStop = false;
			this.MetaDataDetail.Tag = "";
			this.MetaDataDetail.Text = "Dettagli";
			// 
			// textBoxCodiceSede
			// 
			this.textBoxCodiceSede.Location = new System.Drawing.Point(87, 13);
			this.textBoxCodiceSede.Name = "textBoxCodiceSede";
			this.textBoxCodiceSede.Size = new System.Drawing.Size(100, 20);
			this.textBoxCodiceSede.TabIndex = 27;
			this.textBoxCodiceSede.Tag = "f24sediinail.codicesede?pat.codicesede";
			// 
			// labelCodiceSede
			// 
			this.labelCodiceSede.AutoSize = true;
			this.labelCodiceSede.Location = new System.Drawing.Point(13, 16);
			this.labelCodiceSede.Name = "labelCodiceSede";
			this.labelCodiceSede.Size = new System.Drawing.Size(68, 13);
			this.labelCodiceSede.TabIndex = 26;
			this.labelCodiceSede.Text = "Codice Sede";
			// 
			// textBoxCC
			// 
			this.textBoxCC.Location = new System.Drawing.Point(248, 27);
			this.textBoxCC.Name = "textBoxCC";
			this.textBoxCC.Size = new System.Drawing.Size(46, 20);
			this.textBoxCC.TabIndex = 25;
			this.textBoxCC.Tag = "pat.cc";
			// 
			// labelCC
			// 
			this.labelCC.AutoSize = true;
			this.labelCC.Location = new System.Drawing.Point(215, 30);
			this.labelCC.Name = "labelCC";
			this.labelCC.Size = new System.Drawing.Size(27, 13);
			this.labelCC.TabIndex = 24;
			this.labelCC.Text = "C.C.";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.panel5);
			this.groupBox3.Controls.Add(this.textBox6);
			this.groupBox3.Controls.Add(this.textBox7);
			this.groupBox3.Location = new System.Drawing.Point(48, 175);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(120, 80);
			this.groupBox3.TabIndex = 20;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Quota imponibile";
			// 
			// panel5
			// 
			this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel5.Location = new System.Drawing.Point(16, 40);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(82, 2);
			this.panel5.TabIndex = 32;
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(8, 16);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(100, 20);
			this.textBox6.TabIndex = 14;
			this.textBox6.Tag = "pat.taxablenumerator.n";
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(8, 48);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(100, 20);
			this.textBox7.TabIndex = 15;
			this.textBox7.Tag = "pat.taxabledenominator.n";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.panel4);
			this.groupBox2.Controls.Add(this.textBox8);
			this.groupBox2.Controls.Add(this.textBox9);
			this.groupBox2.Location = new System.Drawing.Point(200, 175);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(120, 80);
			this.groupBox2.TabIndex = 21;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Quota amministraz.";
			// 
			// panel4
			// 
			this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel4.Location = new System.Drawing.Point(16, 40);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(82, 2);
			this.panel4.TabIndex = 32;
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(8, 16);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(100, 20);
			this.textBox8.TabIndex = 18;
			this.textBox8.Tag = "pat.adminnumerator.n";
			// 
			// textBox9
			// 
			this.textBox9.Location = new System.Drawing.Point(8, 48);
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new System.Drawing.Size(100, 20);
			this.textBox9.TabIndex = 19;
			this.textBox9.Tag = "pat.admindenominator.n";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.textBox10);
			this.groupBox1.Controls.Add(this.textBox11);
			this.groupBox1.Controls.Add(this.panel6);
			this.groupBox1.Location = new System.Drawing.Point(352, 175);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(120, 80);
			this.groupBox1.TabIndex = 22;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Quota dipendente";
			// 
			// textBox10
			// 
			this.textBox10.Location = new System.Drawing.Point(8, 16);
			this.textBox10.Name = "textBox10";
			this.textBox10.Size = new System.Drawing.Size(100, 20);
			this.textBox10.TabIndex = 1;
			this.textBox10.Tag = "pat.employnumerator.n";
			// 
			// textBox11
			// 
			this.textBox11.Location = new System.Drawing.Point(8, 48);
			this.textBox11.Name = "textBox11";
			this.textBox11.Size = new System.Drawing.Size(100, 20);
			this.textBox11.TabIndex = 2;
			this.textBox11.Tag = "pat.employdenominator.n";
			// 
			// panel6
			// 
			this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel6.Location = new System.Drawing.Point(16, 40);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(82, 2);
			this.panel6.TabIndex = 32;
			// 
			// textBox12
			// 
			this.textBox12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox12.Location = new System.Drawing.Point(432, 103);
			this.textBox12.Name = "textBox12";
			this.textBox12.Size = new System.Drawing.Size(80, 20);
			this.textBox12.TabIndex = 11;
			this.textBox12.Tag = "pat.employrate.fixed.4..%.100";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(336, 103);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(104, 23);
			this.label9.TabIndex = 23;
			this.label9.Text = "Aliquota amministr.";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox5
			// 
			this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox5.Location = new System.Drawing.Point(432, 135);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(80, 20);
			this.textBox5.TabIndex = 12;
			this.textBox5.Tag = "pat.adminrate.fixed.4..%.100";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(328, 135);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(104, 23);
			this.label5.TabIndex = 13;
			this.label5.Text = "Aliquota dipendente";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(408, 266);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(104, 24);
			this.checkBox1.TabIndex = 2;
			this.checkBox1.Tag = "pat.active:S:N";
			this.checkBox1.Text = "Attivo";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(240, 103);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(80, 20);
			this.textBox4.TabIndex = 7;
			this.textBox4.Tag = "pat.validitystop";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(176, 103);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 23);
			this.label4.TabIndex = 6;
			this.label4.Text = "Data Fine";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(96, 103);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(80, 20);
			this.textBox3.TabIndex = 5;
			this.textBox3.Tag = "pat.validitystart";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 103);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "Data Inizio";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.Location = new System.Drawing.Point(96, 68);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(416, 20);
			this.textBox2.TabIndex = 3;
			this.textBox2.Tag = "pat.description";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 68);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Descrizione";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(129, 27);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(80, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.Tag = "pat.patcode";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(9, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(114, 36);
			this.label1.TabIndex = 0;
			this.label1.Text = "Codice Pos. Ass. Terr. / Codice Ditta";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.textBoxCodiceSede);
			this.groupBox4.Controls.Add(this.labelCodiceSede);
			this.groupBox4.Location = new System.Drawing.Point(302, 14);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(210, 40);
			this.groupBox4.TabIndex = 28;
			this.groupBox4.TabStop = false;
			this.groupBox4.Tag = "AutoChoose.textBoxCodiceSede.default";
			// 
			// Frm_pat_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(536, 315);
			this.Controls.Add(this.MetaDataDetail);
			this.Name = "Frm_pat_default";
			this.Text = "frmpatlista";
			this.MetaDataDetail.ResumeLayout(false);
			this.MetaDataDetail.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion
		
		public void MetaData_AfterLink() {
			MetaData Meta= MetaData.GetMetaData(this);
			HelpForm.SetFormatForColumn(DS.pat.Columns["adminrate"], "p");
			HelpForm.SetFormatForColumn(DS.pat.Columns["employrate"], "p");
		}
	}
}
