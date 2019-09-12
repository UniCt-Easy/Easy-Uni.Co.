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

namespace motive770service_default//cdcausale770prestazione//
{
	/// <summary>
	/// Summary description for FormCdCausale770Prestazione.
	/// </summary>
	public class Frm_motive770service_default : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ImageList images;
		public /*Rana:cdcausale770prestazione.*/vistaForm DS;
        private Label label1;
        private TextBox textBox2;
        private GroupBox groupBox1;
        private TextBox textBox1;
        private ComboBox cmbCausaleEsenzione;
        private Button button1;
        private GroupBox groupBoxCausale770;
        private TextBox textBoxCausale770;
        private ComboBox comboBoxCausale770;
        private Button buttonCdCausale770;
        private GroupBox groupBox2;
        private Label labelEsercizio;
        private ComboBox comboBoxPrestazione;
        private Button buttonPrestazione;
        private TextBox txtEsercizio;
        private System.ComponentModel.IContainer components;
        private GroupBox grpCategoriaPrevidenziale;
        private TextBox textBox3;
        private ComboBox cmbCategoriaPrevidenziale;
        private Button button2;
        MetaData Meta;


        public Frm_motive770service_default()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_motive770service_default));
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.DS = new motive770service_default.vistaForm();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cmbCausaleEsenzione = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBoxCausale770 = new System.Windows.Forms.GroupBox();
            this.textBoxCausale770 = new System.Windows.Forms.TextBox();
            this.comboBoxCausale770 = new System.Windows.Forms.ComboBox();
            this.buttonCdCausale770 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.labelEsercizio = new System.Windows.Forms.Label();
            this.comboBoxPrestazione = new System.Windows.Forms.ComboBox();
            this.buttonPrestazione = new System.Windows.Forms.Button();
            this.grpCategoriaPrevidenziale = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.cmbCategoriaPrevidenziale = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBoxCausale770.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpCategoriaPrevidenziale.SuspendLayout();
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
            this.DS.EnforceConstraints = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 382);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Annotazioni";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(19, 398);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(566, 94);
            this.textBox2.TabIndex = 20;
            this.textBox2.Tag = "motive770service.annotation";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.cmbCausaleEsenzione);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(19, 182);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(569, 95);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(165, 16);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(396, 73);
            this.textBox1.TabIndex = 11;
            this.textBox1.Tag = "mod770_exemptioncode.description";
            // 
            // cmbCausaleEsenzione
            // 
            this.cmbCausaleEsenzione.DataSource = this.DS.mod770_exemptioncode;
            this.cmbCausaleEsenzione.DisplayMember = "exemptioncode";
            this.cmbCausaleEsenzione.Location = new System.Drawing.Point(16, 48);
            this.cmbCausaleEsenzione.Name = "cmbCausaleEsenzione";
            this.cmbCausaleEsenzione.Size = new System.Drawing.Size(143, 21);
            this.cmbCausaleEsenzione.TabIndex = 10;
            this.cmbCausaleEsenzione.Tag = "motive770service.exemptioncode";
            this.cmbCausaleEsenzione.ValueMember = "exemptioncode";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 23);
            this.button1.TabIndex = 9;
            this.button1.Tag = "manage.mod770_exemptioncode.default";
            this.button1.Text = "Codice Esenzione 770";
            // 
            // groupBoxCausale770
            // 
            this.groupBoxCausale770.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCausale770.Controls.Add(this.textBoxCausale770);
            this.groupBoxCausale770.Controls.Add(this.comboBoxCausale770);
            this.groupBoxCausale770.Controls.Add(this.buttonCdCausale770);
            this.groupBoxCausale770.Location = new System.Drawing.Point(16, 82);
            this.groupBoxCausale770.Name = "groupBoxCausale770";
            this.groupBoxCausale770.Size = new System.Drawing.Size(577, 96);
            this.groupBoxCausale770.TabIndex = 18;
            this.groupBoxCausale770.TabStop = false;
            // 
            // textBoxCausale770
            // 
            this.textBoxCausale770.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCausale770.Location = new System.Drawing.Point(165, 16);
            this.textBoxCausale770.Multiline = true;
            this.textBoxCausale770.Name = "textBoxCausale770";
            this.textBoxCausale770.Size = new System.Drawing.Size(404, 74);
            this.textBoxCausale770.TabIndex = 11;
            this.textBoxCausale770.Tag = "motive770.description";
            // 
            // comboBoxCausale770
            // 
            this.comboBoxCausale770.DataSource = this.DS.motive770;
            this.comboBoxCausale770.DisplayMember = "idmot";
            this.comboBoxCausale770.Location = new System.Drawing.Point(16, 48);
            this.comboBoxCausale770.Name = "comboBoxCausale770";
            this.comboBoxCausale770.Size = new System.Drawing.Size(143, 21);
            this.comboBoxCausale770.TabIndex = 10;
            this.comboBoxCausale770.Tag = "motive770service.idmot";
            this.comboBoxCausale770.ValueMember = "idmot";
            // 
            // buttonCdCausale770
            // 
            this.buttonCdCausale770.Location = new System.Drawing.Point(16, 16);
            this.buttonCdCausale770.Name = "buttonCdCausale770";
            this.buttonCdCausale770.Size = new System.Drawing.Size(143, 23);
            this.buttonCdCausale770.TabIndex = 9;
            this.buttonCdCausale770.Tag = "manage.motive770.default";
            this.buttonCdCausale770.Text = "Causale 770";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtEsercizio);
            this.groupBox2.Controls.Add(this.labelEsercizio);
            this.groupBox2.Controls.Add(this.comboBoxPrestazione);
            this.groupBox2.Controls.Add(this.buttonPrestazione);
            this.groupBox2.Location = new System.Drawing.Point(16, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(576, 68);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(9, 31);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.Size = new System.Drawing.Size(56, 20);
            this.txtEsercizio.TabIndex = 22;
            this.txtEsercizio.Tag = "motive770service.ayear.year";
            // 
            // labelEsercizio
            // 
            this.labelEsercizio.AutoSize = true;
            this.labelEsercizio.Location = new System.Drawing.Point(5, 10);
            this.labelEsercizio.Name = "labelEsercizio";
            this.labelEsercizio.Size = new System.Drawing.Size(100, 13);
            this.labelEsercizio.TabIndex = 18;
            this.labelEsercizio.Text = "Anno dichiarazione ";
            // 
            // comboBoxPrestazione
            // 
            this.comboBoxPrestazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxPrestazione.DataSource = this.DS.service;
            this.comboBoxPrestazione.DisplayMember = "description";
            this.comboBoxPrestazione.Location = new System.Drawing.Point(188, 30);
            this.comboBoxPrestazione.Name = "comboBoxPrestazione";
            this.comboBoxPrestazione.Size = new System.Drawing.Size(375, 21);
            this.comboBoxPrestazione.TabIndex = 21;
            this.comboBoxPrestazione.Tag = "motive770service.idser";
            this.comboBoxPrestazione.ValueMember = "idser";
            // 
            // buttonPrestazione
            // 
            this.buttonPrestazione.Location = new System.Drawing.Point(82, 30);
            this.buttonPrestazione.Name = "buttonPrestazione";
            this.buttonPrestazione.Size = new System.Drawing.Size(100, 23);
            this.buttonPrestazione.TabIndex = 20;
            this.buttonPrestazione.Tag = "choose.service.anagrafica";
            this.buttonPrestazione.Text = "Tipo prestazione";
            // 
            // grpCategoriaPrevidenziale
            // 
            this.grpCategoriaPrevidenziale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCategoriaPrevidenziale.Controls.Add(this.textBox3);
            this.grpCategoriaPrevidenziale.Controls.Add(this.cmbCategoriaPrevidenziale);
            this.grpCategoriaPrevidenziale.Controls.Add(this.button2);
            this.grpCategoriaPrevidenziale.Location = new System.Drawing.Point(16, 283);
            this.grpCategoriaPrevidenziale.Name = "grpCategoriaPrevidenziale";
            this.grpCategoriaPrevidenziale.Size = new System.Drawing.Size(569, 95);
            this.grpCategoriaPrevidenziale.TabIndex = 23;
            this.grpCategoriaPrevidenziale.TabStop = false;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(165, 16);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(396, 73);
            this.textBox3.TabIndex = 11;
            this.textBox3.Tag = "mod770_socialsecuritycode.description";
            // 
            // cmbCategoriaPrevidenziale
            // 
            this.cmbCategoriaPrevidenziale.DataSource = this.DS.mod770_socialsecuritycode;
            this.cmbCategoriaPrevidenziale.DisplayMember = "socialseccode";
            this.cmbCategoriaPrevidenziale.Location = new System.Drawing.Point(16, 48);
            this.cmbCategoriaPrevidenziale.Name = "cmbCategoriaPrevidenziale";
            this.cmbCategoriaPrevidenziale.Size = new System.Drawing.Size(143, 21);
            this.cmbCategoriaPrevidenziale.TabIndex = 10;
            this.cmbCategoriaPrevidenziale.Tag = "motive770service.socialseccode";
            this.cmbCategoriaPrevidenziale.ValueMember = "socialseccode";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(16, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 23);
            this.button2.TabIndex = 9;
            this.button2.Tag = "Choose.mod770_socialsecuritycode.default";
            this.button2.Text = "Codice Cat. Previdenziale";
            // 
            // Frm_motive770service_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(601, 504);
            this.Controls.Add(this.grpCategoriaPrevidenziale);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxCausale770);
            this.Name = "Frm_motive770service_default";
            this.Text = "FormCdCausale770Prestazione";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxCausale770.ResumeLayout(false);
            this.groupBoxCausale770.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpCategoriaPrevidenziale.ResumeLayout(false);
            this.grpCategoriaPrevidenziale.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public void MetaData_AfterLink() 
		{
             Meta = MetaData.GetMetaData(this);
            QueryHelper QHS = Meta.Conn.GetQueryHelper();
            string filtro = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.SetStaticFilter(DS.motive770service, filtro);
            GetData.CacheTable(DS.motive770, filtro,"idmot",true);
            GetData.CacheTable(DS.mod770_exemptioncode, filtro, "exemptioncode", true);
            GetData.CacheTable(DS.mod770_socialsecuritycode, filtro, "socialseccode", true);
        }


        public void MetaData_AfterClear() {
            Meta.CanCancel = true;
            txtEsercizio.Text = Meta.GetSys("esercizio").ToString();
            txtEsercizio.ReadOnly = false;
        }

        public void MetaData_AfterFill() {
            txtEsercizio.ReadOnly = true;

        }
        }
}
