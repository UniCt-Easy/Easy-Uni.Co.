
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;

namespace chargehandling_default//trattamentobollo//
{
	/// <summary>
	/// Summary description for frmtrattamentobollo.
	/// </summary>
	//Modified by Leo, 5/2/2003
	public class Frm_chargehandling_default : MetaDataForm
    {
        public vistaForm DS;
        private System.Windows.Forms.ImageList images;
        private CheckBox chkEsente;
        private Label label3;
        private TextBox textBox3;
        private CheckBox chkAttivo;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private TextBox txtDescrizione;
        private TextBox textBox4;
        private Label label4;
        private Label label5;
        private CheckBox chkPredefinito;
		private CheckBox checkBox1;
		private System.ComponentModel.IContainer components;

		public Frm_chargehandling_default()
		{
			InitializeComponent();
			HelpForm.SetDenyNull(DS.chargehandling.Columns["flag"], true);
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
		public void MetaData_BeforePost() {

		}
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_chargehandling_default));
			this.images = new System.Windows.Forms.ImageList(this.components);
			this.DS = new chargehandling_default.vistaForm();
			this.chkEsente = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.chkAttivo = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtDescrizione = new System.Windows.Forms.TextBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.chkPredefinito = new System.Windows.Forms.CheckBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
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
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// chkEsente
			// 
			this.chkEsente.Location = new System.Drawing.Point(25, 169);
			this.chkEsente.Name = "chkEsente";
			this.chkEsente.Size = new System.Drawing.Size(113, 16);
			this.chkEsente.TabIndex = 19;
			this.chkEsente.Tag = "chargehandling.flag:0";
			this.chkEsente.Text = "Esente";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(22, 98);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(333, 16);
			this.label3.TabIndex = 18;
			this.label3.Text = "Codice Trattamento Banca";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(24, 118);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(378, 20);
			this.textBox3.TabIndex = 16;
			this.textBox3.Tag = "chargehandling.handlingbankcode";
			// 
			// chkAttivo
			// 
			this.chkAttivo.Location = new System.Drawing.Point(25, 144);
			this.chkAttivo.Name = "chkAttivo";
			this.chkAttivo.Size = new System.Drawing.Size(55, 16);
			this.chkAttivo.TabIndex = 15;
			this.chkAttivo.Tag = "chargehandling.active:S:N";
			this.chkAttivo.Text = "Attivo";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 17;
			this.label2.Text = "Descrizione:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(104, 24);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(100, 20);
			this.textBox1.TabIndex = 11;
			this.textBox1.Tag = "chargehandling.idchargehandling";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(104, 56);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(298, 20);
			this.textBox2.TabIndex = 12;
			this.textBox2.Tag = "chargehandling.description";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(40, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 14;
			this.label1.Text = "Codice:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDescrizione
			// 
			this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrizione.Location = new System.Drawing.Point(423, 39);
			this.txtDescrizione.Multiline = true;
			this.txtDescrizione.Name = "txtDescrizione";
			this.txtDescrizione.Size = new System.Drawing.Size(200, 64);
			this.txtDescrizione.TabIndex = 20;
			this.txtDescrizione.TabStop = false;
			this.txtDescrizione.Tag = "chargehandling.payment_kind";
			// 
			// textBox4
			// 
			this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox4.Location = new System.Drawing.Point(423, 155);
			this.textBox4.Multiline = true;
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(200, 73);
			this.textBox4.TabIndex = 21;
			this.textBox4.TabStop = false;
			this.textBox4.Tag = "chargehandling.motive";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(420, 20);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(160, 16);
			this.label4.TabIndex = 22;
			this.label4.Text = "Natura del Pagamento:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(420, 136);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(160, 16);
			this.label5.TabIndex = 23;
			this.label5.Text = "Causale Esenzione Spese:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// chkPredefinito
			// 
			this.chkPredefinito.Location = new System.Drawing.Point(25, 192);
			this.chkPredefinito.Name = "chkPredefinito";
			this.chkPredefinito.Size = new System.Drawing.Size(222, 16);
			this.chkPredefinito.TabIndex = 24;
			this.chkPredefinito.Tag = "chargehandling.flag:1";
			this.chkPredefinito.Text = "Trattamento delle Spese Predefinito";
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(25, 218);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(222, 16);
			this.checkBox1.TabIndex = 25;
			this.checkBox1.Tag = "chargehandling.flag:2";
			this.checkBox1.Text = "Per mandati multipli";
			// 
			// Frm_chargehandling_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(649, 257);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.chkPredefinito);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.txtDescrizione);
			this.Controls.Add(this.chkEsente);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.chkAttivo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label1);
			this.Name = "Frm_chargehandling_default";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}
