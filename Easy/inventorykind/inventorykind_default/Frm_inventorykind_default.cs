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

namespace inventorykind_default//tipoinventario//
{
	/// <summary>
	/// Summary description for frmtipoinventario.
	/// </summary>
	public class Frm_inventorykind_default : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ImageList images;
		public System.Windows.Forms.Panel MetaDataDetail;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtCodice;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label1;
		public vistaForm DS;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.ComponentModel.IContainer components;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private GroupBox groupBox2;
        private Button button1;
        private Button btnClassif;
        private TextBox txtIdClassif_Deny;
        private TextBox txtIdClassif_Allow;
        private TextBox txtDescClassif;
        private TextBox textBox3;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        MetaData Meta;
		

		public Frm_inventorykind_default()
		{
			InitializeComponent();
            HelpForm.SetDenyNull(DS.inventorykind.Columns["active"], true);
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
            DataAccess.SetTableForReading(DS.inventorytreeview_allow, "inventorytreeview");
            DataAccess.SetTableForReading(DS.inventorytreeview_deny, "inventorytreeview");
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_inventorykind_default));
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.MetaDataDetail = new System.Windows.Forms.Panel();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodice = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtIdClassif_Deny = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDescClassif = new System.Windows.Forms.TextBox();
            this.txtIdClassif_Allow = new System.Windows.Forms.TextBox();
            this.btnClassif = new System.Windows.Forms.Button();
            this.DS = new inventorykind_default.vistaForm();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.MetaDataDetail.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.MetaDataDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MetaDataDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MetaDataDetail.Controls.Add(this.checkBox4);
            this.MetaDataDetail.Controls.Add(this.checkBox3);
            this.MetaDataDetail.Controls.Add(this.checkBox2);
            this.MetaDataDetail.Controls.Add(this.checkBox1);
            this.MetaDataDetail.Controls.Add(this.label2);
            this.MetaDataDetail.Controls.Add(this.txtCodice);
            this.MetaDataDetail.Controls.Add(this.textBox2);
            this.MetaDataDetail.Controls.Add(this.label1);
            this.MetaDataDetail.Location = new System.Drawing.Point(12, 12);
            this.MetaDataDetail.Name = "MetaDataDetail";
            this.MetaDataDetail.Size = new System.Drawing.Size(708, 135);
            this.MetaDataDetail.TabIndex = 1;
            // 
            // checkBox3
            // 
            this.checkBox3.Location = new System.Drawing.Point(16, 81);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(642, 19);
            this.checkBox3.TabIndex = 18;
            this.checkBox3.Tag = "inventorykind.flag:1";
            this.checkBox3.Text = "L\'inventario non compare nelle situazioni patrimoniali ente e totale";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(298, 9);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(53, 17);
            this.checkBox2.TabIndex = 17;
            this.checkBox2.Tag = "inventorykind.active:S:N";
            this.checkBox2.Text = "Attivo";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(16, 56);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(642, 19);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Tag = "inventorykind.flag:0";
            this.checkBox1.Text = "Considera lo sconto ai fini della determinazione del valore del cespite";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Descrizione:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCodice
            // 
            this.txtCodice.Location = new System.Drawing.Point(104, 8);
            this.txtCodice.Name = "txtCodice";
            this.txtCodice.Size = new System.Drawing.Size(100, 20);
            this.txtCodice.TabIndex = 0;
            this.txtCodice.Tag = "inventorykind.codeinventorykind";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(104, 32);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(403, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.Tag = "inventorykind.description";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Codice:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 153);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(708, 147);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Classificazione Inventariale";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox3);
            this.groupBox3.Controls.Add(this.txtIdClassif_Deny);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(383, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(309, 122);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Tag = "AutoManage.txtIdClassif_Deny.treeall";
            this.groupBox3.Text = "Vietato";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(7, 74);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3.Size = new System.Drawing.Size(297, 42);
            this.textBox3.TabIndex = 21;
            this.textBox3.TabStop = false;
            this.textBox3.Tag = "inventorytreeview_deny.description";
            // 
            // txtIdClassif_Deny
            // 
            this.txtIdClassif_Deny.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIdClassif_Deny.Location = new System.Drawing.Point(6, 48);
            this.txtIdClassif_Deny.Name = "txtIdClassif_Deny";
            this.txtIdClassif_Deny.Size = new System.Drawing.Size(259, 20);
            this.txtIdClassif_Deny.TabIndex = 19;
            this.txtIdClassif_Deny.Tag = "inventorytreeview_deny.codeinv?inventorykindview.codeinv_deny";
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(6, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 23);
            this.button1.TabIndex = 18;
            this.button1.TabStop = false;
            this.button1.Tag = "manage.inventorytreeview_deny.treeall";
            this.button1.Text = "Classificazione";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDescClassif);
            this.groupBox2.Controls.Add(this.txtIdClassif_Allow);
            this.groupBox2.Controls.Add(this.btnClassif);
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(288, 122);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "AutoManage.txtIdClassif_Allow.treeall";
            this.groupBox2.Text = "Consentito";
            // 
            // txtDescClassif
            // 
            this.txtDescClassif.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescClassif.Location = new System.Drawing.Point(6, 74);
            this.txtDescClassif.Multiline = true;
            this.txtDescClassif.Name = "txtDescClassif";
            this.txtDescClassif.ReadOnly = true;
            this.txtDescClassif.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescClassif.Size = new System.Drawing.Size(276, 42);
            this.txtDescClassif.TabIndex = 20;
            this.txtDescClassif.TabStop = false;
            this.txtDescClassif.Tag = "inventorytreeview_allow.description";
            // 
            // txtIdClassif_Allow
            // 
            this.txtIdClassif_Allow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIdClassif_Allow.Location = new System.Drawing.Point(6, 48);
            this.txtIdClassif_Allow.Name = "txtIdClassif_Allow";
            this.txtIdClassif_Allow.Size = new System.Drawing.Size(238, 20);
            this.txtIdClassif_Allow.TabIndex = 19;
            this.txtIdClassif_Allow.Tag = "inventorytreeview_allow.codeinv?inventorykindview.codeinv_allow";
            // 
            // btnClassif
            // 
            this.btnClassif.Image = ((System.Drawing.Image)(resources.GetObject("btnClassif.Image")));
            this.btnClassif.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClassif.Location = new System.Drawing.Point(6, 19);
            this.btnClassif.Name = "btnClassif";
            this.btnClassif.Size = new System.Drawing.Size(120, 23);
            this.btnClassif.TabIndex = 18;
            this.btnClassif.TabStop = false;
            this.btnClassif.Tag = "manage.inventorytreeview_allow.treeall";
            this.btnClassif.Text = "Classificazione";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // checkBox4
            // 
            this.checkBox4.Location = new System.Drawing.Point(16, 106);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(491, 19);
            this.checkBox4.TabIndex = 19;
            this.checkBox4.Tag = "inventorykind.flag:2";
            this.checkBox4.Text = "Inventario associato a beni di tipo Libri";
            // 
            // Frm_inventorykind_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(732, 312);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.MetaDataDetail);
            this.Name = "Frm_inventorykind_default";
            this.Text = "frmtipoinventario";
            this.MetaDataDetail.ResumeLayout(false);
            this.MetaDataDetail.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
	}
}
