
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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

namespace inventoryagency_default//enteinventario//
{
	/// <summary>
	/// Summary description for frmenteinventario.
	/// </summary>
	public class Frm_inventoryagency_default : MetaDataForm
	{
		public vistaForm DS;
		private System.Windows.Forms.ImageList images;
        private System.ComponentModel.IContainer components;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private CheckBox checkBox1;
        private Label label2;
        private TextBox txtCodice;
        private TextBox textBox2;
        private Label label1;
        private TabPage tabPage2;
        private Label label11;
        private TextBox textBox14;
        private Label label14;
        private TextBox textBox8;
        private Label label15;
        private Label label13;
        private TextBox textBox15;
        private TextBox textBox16;
        private Label label10;
        private Label label9;
        private TextBox textBox10;
        private TextBox textBox9;
        MetaData Meta;

		public Frm_inventoryagency_default()
		{
			InitializeComponent();
            HelpForm.SetDenyNull(DS.inventoryagency.Columns["active"], true);		
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

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
        }

        public void MetaData_AfterFill() {

        }

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_inventoryagency_default));
			this.images = new System.Windows.Forms.ImageList(this.components);
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtCodice = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.label11 = new System.Windows.Forms.Label();
			this.textBox14 = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.textBox15 = new System.Windows.Forms.TextBox();
			this.textBox16 = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.DS = new inventoryagency_default.vistaForm();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
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
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(453, 420);
			this.tabControl1.TabIndex = 17;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.checkBox1);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.txtCodice);
			this.tabPage1.Controls.Add(this.textBox2);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(445, 394);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Principale";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(307, 33);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(53, 17);
			this.checkBox1.TabIndex = 21;
			this.checkBox1.Tag = "inventoryagency.active:S:N";
			this.checkBox1.Text = "Attivo";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(-1, 88);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 20;
			this.label2.Text = "Descrizione:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtCodice
			// 
			this.txtCodice.Location = new System.Drawing.Point(7, 30);
			this.txtCodice.Name = "txtCodice";
			this.txtCodice.Size = new System.Drawing.Size(175, 20);
			this.txtCodice.TabIndex = 17;
			this.txtCodice.Tag = "inventoryagency.codeinventoryagency";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(7, 107);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(430, 68);
			this.textBox2.TabIndex = 18;
			this.textBox2.Tag = "inventoryagency.description";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(2, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 17);
			this.label1.TabIndex = 19;
			this.label1.Text = "Codice:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.label11);
			this.tabPage2.Controls.Add(this.textBox14);
			this.tabPage2.Controls.Add(this.label14);
			this.tabPage2.Controls.Add(this.textBox8);
			this.tabPage2.Controls.Add(this.label15);
			this.tabPage2.Controls.Add(this.label13);
			this.tabPage2.Controls.Add(this.textBox15);
			this.tabPage2.Controls.Add(this.textBox16);
			this.tabPage2.Controls.Add(this.label10);
			this.tabPage2.Controls.Add(this.label9);
			this.tabPage2.Controls.Add(this.textBox10);
			this.tabPage2.Controls.Add(this.textBox9);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(445, 394);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Stampa";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(6, 209);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(122, 15);
			this.label11.TabIndex = 67;
			this.label11.Text = "Titolo Firma Destra:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox14
			// 
			this.textBox14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox14.Location = new System.Drawing.Point(6, 274);
			this.textBox14.Multiline = true;
			this.textBox14.Name = "textBox14";
			this.textBox14.Size = new System.Drawing.Size(433, 26);
			this.textBox14.TabIndex = 64;
			this.textBox14.Tag = "inventoryagency.name_r";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(6, 8);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(122, 15);
			this.label14.TabIndex = 71;
			this.label14.Text = "Titolo Firma Sinistra:";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox8
			// 
			this.textBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox8.Location = new System.Drawing.Point(6, 227);
			this.textBox8.Multiline = true;
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(433, 26);
			this.textBox8.TabIndex = 65;
			this.textBox8.Tag = "inventoryagency.title_r";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(6, 61);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(122, 15);
			this.label15.TabIndex = 70;
			this.label15.Text = "Nome Firma Sinistra:";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(6, 256);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(122, 15);
			this.label13.TabIndex = 66;
			this.label13.Text = "Nome Firma Destra:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox15
			// 
			this.textBox15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox15.Location = new System.Drawing.Point(6, 28);
			this.textBox15.Multiline = true;
			this.textBox15.Name = "textBox15";
			this.textBox15.Size = new System.Drawing.Size(433, 26);
			this.textBox15.TabIndex = 69;
			this.textBox15.Tag = "inventoryagency.title_l";
			// 
			// textBox16
			// 
			this.textBox16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox16.Location = new System.Drawing.Point(6, 79);
			this.textBox16.Multiline = true;
			this.textBox16.Name = "textBox16";
			this.textBox16.Size = new System.Drawing.Size(433, 26);
			this.textBox16.TabIndex = 68;
			this.textBox16.Tag = "inventoryagency.name_l";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(6, 106);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(122, 15);
			this.label10.TabIndex = 63;
			this.label10.Text = "Titolo Firma Centro:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(3, 162);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(122, 15);
			this.label9.TabIndex = 62;
			this.label9.Text = "Nome Firma Centro:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox10
			// 
			this.textBox10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox10.Location = new System.Drawing.Point(6, 133);
			this.textBox10.Multiline = true;
			this.textBox10.Name = "textBox10";
			this.textBox10.Size = new System.Drawing.Size(433, 26);
			this.textBox10.TabIndex = 61;
			this.textBox10.Tag = "inventoryagency.title_c";
			// 
			// textBox9
			// 
			this.textBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox9.Location = new System.Drawing.Point(6, 180);
			this.textBox9.Multiline = true;
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new System.Drawing.Size(433, 26);
			this.textBox9.TabIndex = 60;
			this.textBox9.Tag = "inventoryagency.name_c";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// Frm_inventoryagency_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(453, 420);
			this.Controls.Add(this.tabControl1);
			this.Name = "Frm_inventoryagency_default";
			this.Text = "frmenteinventario";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
	}
}
