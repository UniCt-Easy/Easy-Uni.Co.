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
using metadatalibrary;


namespace inventoryamortization_default//tiporivalinventario//
{
	/// <summary>
	/// Summary description for frmtiporivalinventario.
	/// </summary>
	public class Frm_inventoryamortization_default : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ImageList images;
		public System.Windows.Forms.Panel MetaDataDetail;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtCodice;
		private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
		public vistaForm DS;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private GroupBox groupBox2;
        private RadioButton radioButton3;
        private RadioButton radioButton4;
		private System.ComponentModel.IContainer components;
        private CheckBox checkBox3;
        private TextBox textBox5;
        private Label label6;
        private TextBox textBox4;
        private Label label5;
        private TextBox textBox1;
        private Label label4;
        MetaData Meta;

		public Frm_inventoryamortization_default()
		{
			InitializeComponent();
            HelpForm.SetDenyNull(DS.inventoryamortization.Columns["active"], true);
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

		public void MetaData_AfterLink()
		{
			Meta = MetaData.GetMetaData(this);
		}

        public void MetaData_AfterFill() {
            if (Meta.EditMode) {
                txtCodice.ReadOnly = true;
            }
            else {
                txtCodice.ReadOnly = false;
            }
        }
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_inventoryamortization_default));
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.MetaDataDetail = new System.Windows.Forms.Panel();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodice = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DS = new inventoryamortization_default.vistaForm();
            this.MetaDataDetail.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            // MetaDataDetail
            // 
            this.MetaDataDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MetaDataDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MetaDataDetail.Controls.Add(this.textBox5);
            this.MetaDataDetail.Controls.Add(this.label6);
            this.MetaDataDetail.Controls.Add(this.textBox4);
            this.MetaDataDetail.Controls.Add(this.label5);
            this.MetaDataDetail.Controls.Add(this.textBox1);
            this.MetaDataDetail.Controls.Add(this.label4);
            this.MetaDataDetail.Controls.Add(this.checkBox3);
            this.MetaDataDetail.Controls.Add(this.groupBox2);
            this.MetaDataDetail.Controls.Add(this.groupBox1);
            this.MetaDataDetail.Controls.Add(this.textBox3);
            this.MetaDataDetail.Controls.Add(this.label3);
            this.MetaDataDetail.Controls.Add(this.checkBox2);
            this.MetaDataDetail.Controls.Add(this.label2);
            this.MetaDataDetail.Controls.Add(this.txtCodice);
            this.MetaDataDetail.Controls.Add(this.textBox2);
            this.MetaDataDetail.Controls.Add(this.label1);
            this.MetaDataDetail.Location = new System.Drawing.Point(12, 11);
            this.MetaDataDetail.Name = "MetaDataDetail";
            this.MetaDataDetail.Size = new System.Drawing.Size(498, 200);
            this.MetaDataDetail.TabIndex = 1;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(396, 10);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(88, 20);
            this.textBox5.TabIndex = 2;
            this.textBox5.Tag = "inventoryamortization.agemax";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(335, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 16);
            this.label6.TabIndex = 24;
            this.label6.Text = "Età max:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(269, 35);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(110, 20);
            this.textBox4.TabIndex = 4;
            this.textBox4.Tag = "inventoryamortization.valuemax";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(192, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "Valore max:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(71, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(104, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Tag = "inventoryamortization.valuemin";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "Valore min:";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(416, 156);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(53, 17);
            this.checkBox3.TabIndex = 10;
            this.checkBox3.Tag = "inventoryamortization.active:S:N";
            this.checkBox3.Text = "Attivo";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Controls.Add(this.radioButton4);
            this.groupBox2.Location = new System.Drawing.Point(244, 105);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(225, 40);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ammortamento o Svalutazione";
            // 
            // radioButton3
            // 
            this.radioButton3.Location = new System.Drawing.Point(111, 19);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(96, 16);
            this.radioButton3.TabIndex = 1;
            this.radioButton3.Tag = "inventoryamortization.flag::#3";
            this.radioButton3.Text = "Svalutazione";
            // 
            // radioButton4
            // 
            this.radioButton4.Location = new System.Drawing.Point(8, 19);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(104, 16);
            this.radioButton4.TabIndex = 0;
            this.radioButton4.Tag = "inventoryamortization.flag::3";
            this.radioButton4.Text = "Ammortamento";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(8, 105);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 40);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo Calcolo";
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(110, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(84, 16);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Tag = "inventoryamortization.flag::#0";
            this.radioButton2.Text = "Annuale";
            // 
            // radioButton1
            // 
            this.radioButton1.Location = new System.Drawing.Point(8, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(104, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Tag = "inventoryamortization.flag::0";
            this.radioButton1.Text = "Mensile";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(231, 8);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(88, 20);
            this.textBox3.TabIndex = 1;
            this.textBox3.Tag = "inventoryamortization.age";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(178, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Età min:";
            // 
            // checkBox2
            // 
            this.checkBox2.Location = new System.Drawing.Point(301, 156);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(75, 16);
            this.checkBox2.TabIndex = 9;
            this.checkBox2.Tag = "inventoryamortization.flag:1";
            this.checkBox2.Text = "Ufficiale";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Descrizione:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCodice
            // 
            this.txtCodice.Location = new System.Drawing.Point(71, 8);
            this.txtCodice.Name = "txtCodice";
            this.txtCodice.Size = new System.Drawing.Size(100, 20);
            this.txtCodice.TabIndex = 0;
            this.txtCodice.Tag = "inventoryamortization.codeinventoryamortization";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(96, 75);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(374, 20);
            this.textBox2.TabIndex = 5;
            this.textBox2.Tag = "inventoryamortization.description";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Codice:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // Frm_inventoryamortization_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(514, 223);
            this.Controls.Add(this.MetaDataDetail);
            this.Name = "Frm_inventoryamortization_default";
            this.Text = "frmtiporivalinventario";
            this.MetaDataDetail.ResumeLayout(false);
            this.MetaDataDetail.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
	}
}
