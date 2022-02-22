
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;

namespace mod770_socialsecuritycode_default//cdcausale770//
{
	/// <summary>
	/// Summary description for FormCdCausale770.
	/// </summary>
	public class Frm_mod770_socialsecuritycode_default : MetaDataForm
	{
		private System.Windows.Forms.ImageList images;
		private MetaData meta;
		public  vistaForm DS;
        private GroupBox grpEnte;
        private Label label2;
        private TextBox textBox3;
        private Label label1;
        private TextBox textBox2;
        private GroupBox grpCodiceCategoria;
        private Label labelDescrizione;
        private Label labelCodiceCausale;
        private TextBox textBox1;
        private TextBox textBoxCodiceCausale;
        private Label labelEsercizio;
        private TextBox textBoxEsercizio;
        private System.ComponentModel.IContainer components;

		public Frm_mod770_socialsecuritycode_default()
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_mod770_socialsecuritycode_default));
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.DS = new mod770_socialsecuritycode_default.vistaForm();
            this.grpEnte = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.grpCodiceCategoria = new System.Windows.Forms.GroupBox();
            this.labelDescrizione = new System.Windows.Forms.Label();
            this.labelCodiceCausale = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBoxCodiceCausale = new System.Windows.Forms.TextBox();
            this.labelEsercizio = new System.Windows.Forms.Label();
            this.textBoxEsercizio = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.grpEnte.SuspendLayout();
            this.grpCodiceCategoria.SuspendLayout();
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
            this.images.Images.SetKeyName(14, "");
            this.images.Images.SetKeyName(15, "");
            this.images.Images.SetKeyName(16, "");
            this.images.Images.SetKeyName(17, "");
            this.images.Images.SetKeyName(18, "");
            this.images.Images.SetKeyName(19, "");
            this.images.Images.SetKeyName(20, "");
            this.images.Images.SetKeyName(21, "");
            this.images.Images.SetKeyName(22, "");
            this.images.Images.SetKeyName(23, "");
            this.images.Images.SetKeyName(24, "");
            this.images.Images.SetKeyName(25, "");
            this.images.Images.SetKeyName(26, "");
            this.images.Images.SetKeyName(27, "");
            this.images.Images.SetKeyName(28, "");
            this.images.Images.SetKeyName(29, "");
            this.images.Images.SetKeyName(30, "");
            this.images.Images.SetKeyName(31, "");
            this.images.Images.SetKeyName(32, "");
            this.images.Images.SetKeyName(33, "");
            this.images.Images.SetKeyName(34, "");
            this.images.Images.SetKeyName(35, "");
            this.images.Images.SetKeyName(36, "");
            this.images.Images.SetKeyName(37, "");
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // grpEnte
            // 
            this.grpEnte.Controls.Add(this.label2);
            this.grpEnte.Controls.Add(this.textBox3);
            this.grpEnte.Controls.Add(this.label1);
            this.grpEnte.Controls.Add(this.textBox2);
            this.grpEnte.Location = new System.Drawing.Point(15, 224);
            this.grpEnte.Name = "grpEnte";
            this.grpEnte.Size = new System.Drawing.Size(486, 131);
            this.grpEnte.TabIndex = 0;
            this.grpEnte.TabStop = false;
            this.grpEnte.Text = "Ente Previdenziale";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(14, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 23);
            this.label2.TabIndex = 2;
            this.label2.Tag = "";
            this.label2.Text = "Codice Fiscale";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(102, 22);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(192, 20);
            this.textBox3.TabIndex = 3;
            this.textBox3.Tag = "mod770_socialsecuritycode.cfagency";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Denominazione";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(9, 78);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(471, 39);
            this.textBox2.TabIndex = 1;
            this.textBox2.Tag = "mod770_socialsecuritycode.titleagency";
            // 
            // grpCodiceCategoria
            // 
            this.grpCodiceCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCodiceCategoria.Controls.Add(this.labelDescrizione);
            this.grpCodiceCategoria.Controls.Add(this.labelCodiceCausale);
            this.grpCodiceCategoria.Controls.Add(this.textBox1);
            this.grpCodiceCategoria.Controls.Add(this.textBoxCodiceCausale);
            this.grpCodiceCategoria.Controls.Add(this.labelEsercizio);
            this.grpCodiceCategoria.Controls.Add(this.textBoxEsercizio);
            this.grpCodiceCategoria.Location = new System.Drawing.Point(15, 12);
            this.grpCodiceCategoria.Name = "grpCodiceCategoria";
            this.grpCodiceCategoria.Size = new System.Drawing.Size(486, 206);
            this.grpCodiceCategoria.TabIndex = 1;
            this.grpCodiceCategoria.TabStop = false;
            // 
            // labelDescrizione
            // 
            this.labelDescrizione.Location = new System.Drawing.Point(6, 116);
            this.labelDescrizione.Name = "labelDescrizione";
            this.labelDescrizione.Size = new System.Drawing.Size(85, 15);
            this.labelDescrizione.TabIndex = 4;
            this.labelDescrizione.Text = "Descrizione";
            // 
            // labelCodiceCausale
            // 
            this.labelCodiceCausale.Location = new System.Drawing.Point(3, 52);
            this.labelCodiceCausale.Name = "labelCodiceCausale";
            this.labelCodiceCausale.Size = new System.Drawing.Size(166, 23);
            this.labelCodiceCausale.TabIndex = 2;
            this.labelCodiceCausale.Tag = "";
            this.labelCodiceCausale.Text = "Codice Categoria Previdenziale";
            this.labelCodiceCausale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(6, 134);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(474, 56);
            this.textBox1.TabIndex = 5;
            this.textBox1.Tag = "mod770_socialsecuritycode.description";
            // 
            // textBoxCodiceCausale
            // 
            this.textBoxCodiceCausale.Location = new System.Drawing.Point(6, 78);
            this.textBoxCodiceCausale.Name = "textBoxCodiceCausale";
            this.textBoxCodiceCausale.Size = new System.Drawing.Size(100, 20);
            this.textBoxCodiceCausale.TabIndex = 3;
            this.textBoxCodiceCausale.Tag = "mod770_socialsecuritycode.socialseccode";
            this.textBoxCodiceCausale.TextChanged += new System.EventHandler(this.textBoxCodiceCausale_TextChanged);
            // 
            // labelEsercizio
            // 
            this.labelEsercizio.Location = new System.Drawing.Point(10, 16);
            this.labelEsercizio.Name = "labelEsercizio";
            this.labelEsercizio.Size = new System.Drawing.Size(56, 23);
            this.labelEsercizio.TabIndex = 0;
            this.labelEsercizio.Text = "Esercizio";
            this.labelEsercizio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxEsercizio
            // 
            this.textBoxEsercizio.Location = new System.Drawing.Point(73, 16);
            this.textBoxEsercizio.Name = "textBoxEsercizio";
            this.textBoxEsercizio.Size = new System.Drawing.Size(65, 20);
            this.textBoxEsercizio.TabIndex = 1;
            this.textBoxEsercizio.Tag = "mod770_socialsecuritycode.ayear.year";
            // 
            // Frm_mod770_socialsecuritycode_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(513, 384);
            this.Controls.Add(this.grpCodiceCategoria);
            this.Controls.Add(this.grpEnte);
            this.Name = "Frm_mod770_socialsecuritycode_default";
            this.Text = "FrmSocialSecurityCode";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.grpEnte.ResumeLayout(false);
            this.grpEnte.PerformLayout();
            this.grpCodiceCategoria.ResumeLayout(false);
            this.grpCodiceCategoria.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		public void MetaData_AfterLink() 
		{
			meta = MetaData.GetMetaData(this);
			 
			int numrighe = meta.Conn.RUN_SELECT_COUNT("mod770_socialsecuritycode",null, true);


			int esercizio = (int) meta.Conn.GetEsercizio();
			GetData.SetStaticFilter(DS.mod770_socialsecuritycode, "(ayear=" + esercizio + ")");
            HelpForm.SetDenyNull(DS.mod770_socialsecuritycode.Columns["description"],true);
		}

        private void textBoxCodiceCausale_TextChanged(object sender, EventArgs e) {

        }
    }
}
