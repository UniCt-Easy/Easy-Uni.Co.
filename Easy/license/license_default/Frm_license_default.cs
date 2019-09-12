/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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

namespace license_default//licenzauso//
{
	/// <summary>
	/// Summary description for frmlicenzauso.
	/// </summary>
	public class Frm_license_default : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Button btnOK;
		public /*Rana:licenzauso.*/vistaForm DS;
		bool CanGoEdit;
		MetaData Meta;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.TextBox txtCredDeb;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBox11;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtLocalitaGeo;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox textBoxCap;
		private System.Windows.Forms.TextBox txtSiglaProv;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_license_default()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Frm_license_default));
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxCap = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtSiglaProv = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.DS = new license_default.vistaForm();
			this.label9 = new System.Windows.Forms.Label();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.txtCredDeb = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label10 = new System.Windows.Forms.Label();
			this.textBox11 = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtLocalitaGeo = new System.Windows.Forms.TextBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label12 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(8, 32);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(312, 32);
			this.textBox1.TabIndex = 0;
			this.textBox1.Tag = "license.departmentname";
			this.textBox1.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(-16, 64);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(112, 23);
			this.label6.TabIndex = 27;
			this.label6.Text = "Nome Università:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(208, 23);
			this.label1.TabIndex = 29;
			this.label1.Text = "Nome Dipartimento o Amministrazione:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(8, 88);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(312, 32);
			this.textBox2.TabIndex = 1;
			this.textBox2.Tag = "license.agencyname";
			this.textBox2.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(104, 104);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 20);
			this.label3.TabIndex = 9;
			this.label3.Text = "Località:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(152, 104);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(280, 20);
			this.textBox5.TabIndex = 10;
			this.textBox5.Tag = "license.location";
			this.textBox5.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 104);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(32, 20);
			this.label4.TabIndex = 7;
			this.label4.Text = "CAP:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBoxCap
			// 
			this.textBoxCap.Location = new System.Drawing.Point(48, 104);
			this.textBoxCap.Name = "textBoxCap";
			this.textBoxCap.Size = new System.Drawing.Size(56, 20);
			this.textBoxCap.TabIndex = 8;
			this.textBoxCap.Tag = "license.cap";
			this.textBoxCap.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(304, 72);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(88, 20);
			this.label5.TabIndex = 5;
			this.label5.Text = "Sigla Provincia:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtSiglaProv
			// 
			this.txtSiglaProv.Location = new System.Drawing.Point(392, 72);
			this.txtSiglaProv.Name = "txtSiglaProv";
			this.txtSiglaProv.Size = new System.Drawing.Size(40, 20);
			this.txtSiglaProv.TabIndex = 6;
			this.txtSiglaProv.Tag = "license.country";
			this.txtSiglaProv.Text = "";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 264);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(112, 23);
			this.label7.TabIndex = 40;
			this.label7.Text = "Codice fiscale:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(120, 264);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(120, 20);
			this.textBox8.TabIndex = 7;
			this.textBox8.Tag = "license.cf";
			this.textBox8.Text = "";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(248, 264);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(64, 23);
			this.label8.TabIndex = 42;
			this.label8.Text = "Partita IVA:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox9
			// 
			this.textBox9.Location = new System.Drawing.Point(320, 264);
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new System.Drawing.Size(120, 20);
			this.textBox9.TabIndex = 8;
			this.textBox9.Tag = "license.p_iva";
			this.textBox9.Text = "";
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(368, 417);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.TabIndex = 13;
			this.btnAnnulla.Text = "Annulla";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(280, 417);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 12;
			this.btnOK.Tag = "mainsave";
			this.btnOK.Text = "OK";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(8, 296);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(112, 23);
			this.label9.TabIndex = 45;
			this.label9.Text = "Codice Ente:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox10
			// 
			this.textBox10.Location = new System.Drawing.Point(120, 296);
			this.textBox10.Name = "textBox10";
			this.textBox10.Size = new System.Drawing.Size(320, 20);
			this.textBox10.TabIndex = 9;
			this.textBox10.Tag = "license.agencycode";
			this.textBox10.Text = "";
			// 
			// txtCredDeb
			// 
			this.txtCredDeb.Location = new System.Drawing.Point(8, 16);
			this.txtCredDeb.Name = "txtCredDeb";
			this.txtCredDeb.Size = new System.Drawing.Size(416, 20);
			this.txtCredDeb.TabIndex = 47;
			this.txtCredDeb.Tag = "registry.title?x";
			this.txtCredDeb.Text = "";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtCredDeb);
			this.groupBox1.Location = new System.Drawing.Point(8, 368);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(432, 40);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Tag = "AutoChoose.txtCredDeb.lista";
			this.groupBox1.Text = "Creditore Debitore per consolidati";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(8, 328);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(112, 23);
			this.label10.TabIndex = 49;
			this.label10.Text = "Codice Dipartimento:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox11
			// 
			this.textBox11.Location = new System.Drawing.Point(120, 328);
			this.textBox11.Name = "textBox11";
			this.textBox11.TabIndex = 10;
			this.textBox11.Tag = "license.departmentcode";
			this.textBox11.Text = "";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.txtLocalitaGeo);
			this.groupBox2.Controls.Add(this.textBox4);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.textBox3);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.textBoxCap);
			this.groupBox2.Controls.Add(this.txtSiglaProv);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.textBox5);
			this.groupBox2.Controls.Add(this.label12);
			this.groupBox2.Location = new System.Drawing.Point(8, 120);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(440, 136);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Tag = "AutoChoose.txtLocalitaGeo.default";
			this.groupBox2.Text = "Sede";
			// 
			// txtLocalitaGeo
			// 
			this.txtLocalitaGeo.Location = new System.Drawing.Point(48, 72);
			this.txtLocalitaGeo.Name = "txtLocalitaGeo";
			this.txtLocalitaGeo.Size = new System.Drawing.Size(264, 20);
			this.txtLocalitaGeo.TabIndex = 4;
			this.txtLocalitaGeo.Tag = "geo_city.title?x";
			this.txtLocalitaGeo.Text = "";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(8, 40);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(424, 20);
			this.textBox4.TabIndex = 2;
			this.textBox4.Tag = "license.address2";
			this.textBox4.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 24);
			this.label2.TabIndex = 0;
			this.label2.Text = "Indirizzo:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(104, 16);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(328, 20);
			this.textBox3.TabIndex = 1;
			this.textBox3.Tag = "license.address1";
			this.textBox3.Text = "";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(0, 0);
			this.label11.Name = "label11";
			this.label11.TabIndex = 0;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(328, 32);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(112, 88);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 52;
			this.pictureBox1.TabStop = false;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(4, 72);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(48, 20);
			this.label12.TabIndex = 53;
			this.label12.Text = "Comune";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Frm_license_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(458, 448);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.textBox11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.textBox10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.textBox9);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.textBox8);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.textBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "Frm_license_default";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmlicenzauso";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public void MetaData_AfterLink()
		{
			Meta = MetaData.GetMetaData(this);
			int numrighelicenzauso = Meta.Conn.RUN_SELECT_COUNT("license",null, true);
			if (numrighelicenzauso==1)
			{
				CanGoEdit=true;
			}
			else
			{
				CanGoEdit=false;
			}
			Meta.CanInsert=false;
		}

		public void MetaData_AfterClear()
		{
			if (CanGoEdit)
			{
				CanGoEdit=false;
				MetaData.DoMainCommand(this, "maindosearch.license");
			}
		}
		public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
			if (!Meta.IsEmpty && (T.TableName=="geo_city") && (R!=null)) {
				aggiornaCap(R["idcity"], R["idcountry"]);
			}
		}

		private void aggiornaCap(object idComune, object idprovincia) {
			object capPrincipale = Meta.Conn.DO_READ_VALUE("geo_city_agency", "(idagency=3) and (idcode=1) and (idcity=" + idComune + ")", "value");
			if (capPrincipale != null) {
				string cap = textBoxCap.Text;
				if (cap == "") {
					textBoxCap.Text = capPrincipale.ToString();
				} 
				else {
					string query = "select value from geo_city_agency where (idagency=3) and (idcity=" 
						+ idComune + ") and (value = "+QueryCreator.quotedstrvalue(cap, true) + ")";
					DataTable t = Meta.Conn.SQLRunner(query);
					if ((cap != capPrincipale.ToString()) && (t.Rows.Count == 0)) {
						DialogResult dr = MessageBox.Show(this, "Il C.A.P. non è coerente con il comune scelto. Si desidera aggiornarlo?", "Avviso", MessageBoxButtons.YesNo);
						if (dr==DialogResult.Yes) {
							textBoxCap.Text = capPrincipale.ToString();
						}
					}
				}
			}
			object provDB = Meta.Conn.DO_READ_VALUE("geo_country", "idcountry="+idprovincia, "province");
			if (!txtSiglaProv.Text.Equals(provDB)) {
				DialogResult dr = MessageBox.Show(this, "La sigla della provincia non è coerente con il comune scelto. Si desidera aggiornarla?", "Avviso", MessageBoxButtons.YesNo);
				if (dr==DialogResult.Yes) {
					txtSiglaProv.Text = provDB.ToString();
				}
			}
		}
	}
}
