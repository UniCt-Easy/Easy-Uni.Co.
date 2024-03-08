
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


namespace assetconsignee_lista//consegnatarioinventario_lista//
{
	/// <summary>
	/// Summary description for frmConsegnatarioInventarioLista.
	/// </summary>
	public class Frm_assetconsignee_lista : MetaDataForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.Windows.Forms.ImageList images;
		public vistaForm DS;
		private MetaData Meta;
		private ComboBox cmbEnte;
		private CheckBox checkBox3;
		private TextBox textBox1;
		private TextBox textBox3;
		private TextBox textBox2;
		private Label label4;
		private Label label3;
		private Label label2;
		private Label label1;
		private System.ComponentModel.IContainer components;

		public Frm_assetconsignee_lista()
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
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
			HelpForm.SetDenyNull(DS.assetconsignee.Columns["active"], true);
			GetData.CacheTable(DS.inventoryagency, null, "description", true);
		}

		 
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_assetconsignee_lista));
			this.images = new System.Windows.Forms.ImageList(this.components);
			this.DS = new assetconsignee_lista.vistaForm();
			this.cmbEnte = new System.Windows.Forms.ComboBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
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
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// cmbEnte
			// 
			this.cmbEnte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbEnte.DataSource = this.DS.inventoryagency;
			this.cmbEnte.DisplayMember = "description";
			this.cmbEnte.Location = new System.Drawing.Point(111, 39);
			this.cmbEnte.Name = "cmbEnte";
			this.cmbEnte.Size = new System.Drawing.Size(384, 21);
			this.cmbEnte.TabIndex = 31;
			this.cmbEnte.Tag = "assetconsignee.idinventoryagency";
			this.cmbEnte.ValueMember = "idinventoryagency";
			// 
			// checkBox3
			// 
			this.checkBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox3.AutoSize = true;
			this.checkBox3.Location = new System.Drawing.Point(442, 67);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(53, 17);
			this.checkBox3.TabIndex = 30;
			this.checkBox3.Tag = "assetconsignee.active:S:N";
			this.checkBox3.Text = "Attivo";
			this.checkBox3.UseVisualStyleBackColor = true;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(111, 65);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(88, 20);
			this.textBox1.TabIndex = 23;
			this.textBox1.Tag = "assetconsignee.start";
			// 
			// textBox3
			// 
			this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox3.Location = new System.Drawing.Point(111, 86);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(384, 20);
			this.textBox3.TabIndex = 24;
			this.textBox3.Tag = "assetconsignee.qualification";
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.Location = new System.Drawing.Point(111, 110);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox2.Size = new System.Drawing.Size(384, 64);
			this.textBox2.TabIndex = 25;
			this.textBox2.Tag = "assetconsignee.title";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(32, 88);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(75, 16);
			this.label4.TabIndex = 29;
			this.label4.Text = "Titolo:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(32, 110);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(75, 16);
			this.label3.TabIndex = 28;
			this.label3.Text = "Nome:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(32, 61);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 23);
			this.label2.TabIndex = 27;
			this.label2.Text = "Data inizio:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(71, 37);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 23);
			this.label1.TabIndex = 26;
			this.label1.Text = "Ente:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// Frm_assetconsignee_lista
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(526, 210);
			this.Controls.Add(this.cmbEnte);
			this.Controls.Add(this.checkBox3);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "Frm_assetconsignee_lista";
			this.Text = "frmConsegnatarioInventarioLista";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}
