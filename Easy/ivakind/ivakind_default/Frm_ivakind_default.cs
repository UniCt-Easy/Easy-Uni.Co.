/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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
using System.Data;

namespace ivakind_default//tipoiva//
{
	/// <summary>
	/// Summary description for frmtipoiva.
	/// </summary>
	public class Frm_ivakind_default : System.Windows.Forms.Form
	{
		public vistaForm DS;
		private System.Windows.Forms.ImageList images;
		private System.ComponentModel.IContainer components;
        private TabControl MetaDataDetail;
        private TabPage tabPrincipale;
        private GroupBox groupBox5;
        private CheckBox checkBox7;
        private CheckBox checkBox8;
        private CheckBox checkBox9;
        private GroupBox groupBox4;
        private ComboBox cmbNatura;
        private GroupBox groupBox3;
        private CheckBox checkBox6;
        private CheckBox checkBox5;
        private Label label5;
        private TextBox textBox1;
        private Button btnCopyAll;
        private GroupBox groupBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private CheckBox checkBox2;
        private GroupBox groupBox1;
        private ComboBox cmbTipoImposizione;
        private CheckBox checkBox1;
        private TextBox textBox4;
        private TextBox textBox3;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtCodice;
        private TextBox textBox2;
        private Label label1;
        private TabPage tabClassificazioni;
        private DataGrid dGridClassSup;
        private Button btnElimina;
        private Button btnModifica;
        private Button btnInserisci;
        private CheckBox checkBox10;
        MetaData Meta;

		public Frm_ivakind_default()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			HelpForm.SetDenyNull(DS.ivakind.Columns["active"],true);
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

            bool IsAdmin = false;

            if (Meta.GetUsr("consolidamento") != null)
                IsAdmin = (Meta.GetUsr("consolidamento").ToString() == "S");
            if (Meta.GetSys("IsSystemAdmin") != null)
              IsAdmin = IsAdmin || (bool)Meta.GetSys("IsSystemAdmin");
            HelpForm.SetDenyNull(DS.ivakind.Columns["codeivakind"],true);

            if (!IsAdmin) btnCopyAll.Visible = false;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ivakind_default));
            this.DS = new ivakind_default.vistaForm();
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.MetaDataDetail = new System.Windows.Forms.TabControl();
            this.tabPrincipale = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmbNatura = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnCopyAll = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbTipoImposizione = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodice = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabClassificazioni = new System.Windows.Forms.TabPage();
            this.dGridClassSup = new System.Windows.Forms.DataGrid();
            this.btnElimina = new System.Windows.Forms.Button();
            this.btnModifica = new System.Windows.Forms.Button();
            this.btnInserisci = new System.Windows.Forms.Button();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.MetaDataDetail.SuspendLayout();
            this.tabPrincipale.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabClassificazioni.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridClassSup)).BeginInit();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
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
            this.MetaDataDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MetaDataDetail.Controls.Add(this.tabPrincipale);
            this.MetaDataDetail.Controls.Add(this.tabClassificazioni);
            this.MetaDataDetail.Location = new System.Drawing.Point(6, 12);
            this.MetaDataDetail.Name = "MetaDataDetail";
            this.MetaDataDetail.SelectedIndex = 0;
            this.MetaDataDetail.Size = new System.Drawing.Size(784, 350);
            this.MetaDataDetail.TabIndex = 25;
            // 
            // tabPrincipale
            // 
            this.tabPrincipale.BackColor = System.Drawing.Color.Transparent;
            this.tabPrincipale.Controls.Add(this.checkBox10);
            this.tabPrincipale.Controls.Add(this.groupBox5);
            this.tabPrincipale.Controls.Add(this.groupBox4);
            this.tabPrincipale.Controls.Add(this.groupBox3);
            this.tabPrincipale.Controls.Add(this.label5);
            this.tabPrincipale.Controls.Add(this.textBox1);
            this.tabPrincipale.Controls.Add(this.btnCopyAll);
            this.tabPrincipale.Controls.Add(this.groupBox2);
            this.tabPrincipale.Controls.Add(this.groupBox1);
            this.tabPrincipale.Controls.Add(this.checkBox1);
            this.tabPrincipale.Controls.Add(this.textBox4);
            this.tabPrincipale.Controls.Add(this.textBox3);
            this.tabPrincipale.Controls.Add(this.label4);
            this.tabPrincipale.Controls.Add(this.label3);
            this.tabPrincipale.Controls.Add(this.label2);
            this.tabPrincipale.Controls.Add(this.txtCodice);
            this.tabPrincipale.Controls.Add(this.textBox2);
            this.tabPrincipale.Controls.Add(this.label1);
            this.tabPrincipale.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPrincipale.Location = new System.Drawing.Point(4, 22);
            this.tabPrincipale.Name = "tabPrincipale";
            this.tabPrincipale.Padding = new System.Windows.Forms.Padding(3);
            this.tabPrincipale.Size = new System.Drawing.Size(776, 324);
            this.tabPrincipale.TabIndex = 0;
            this.tabPrincipale.Text = "Principale";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkBox7);
            this.groupBox5.Controls.Add(this.checkBox8);
            this.groupBox5.Controls.Add(this.checkBox9);
            this.groupBox5.Location = new System.Drawing.Point(571, 64);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(191, 100);
            this.groupBox5.TabIndex = 40;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Applicabilit‡ in Fatture";
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(19, 44);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(65, 17);
            this.checkBox7.TabIndex = 2;
            this.checkBox7.Tag = "ivakind.flag:7";
            this.checkBox7.Text = "Intra-UE";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(19, 67);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(68, 17);
            this.checkBox8.TabIndex = 3;
            this.checkBox8.Tag = "ivakind.flag:8";
            this.checkBox8.Text = "Extra-UE";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(19, 21);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(48, 17);
            this.checkBox9.TabIndex = 1;
            this.checkBox9.Tag = "ivakind.flag:6";
            this.checkBox9.Text = "Italia";
            this.checkBox9.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.cmbNatura);
            this.groupBox4.Location = new System.Drawing.Point(351, 165);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(422, 48);
            this.groupBox4.TabIndex = 39;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Natura dell\'esenzione";
            // 
            // cmbNatura
            // 
            this.cmbNatura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbNatura.DataSource = this.DS.fenature;
            this.cmbNatura.DisplayMember = "description";
            this.cmbNatura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNatura.Location = new System.Drawing.Point(19, 19);
            this.cmbNatura.Name = "cmbNatura";
            this.cmbNatura.Size = new System.Drawing.Size(397, 21);
            this.cmbNatura.TabIndex = 0;
            this.cmbNatura.Tag = "ivakind.idfenature";
            this.cmbNatura.ValueMember = "idfenature";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox6);
            this.groupBox3.Controls.Add(this.checkBox5);
            this.groupBox3.Location = new System.Drawing.Point(1, 184);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(254, 72);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Calcolo prorata";
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(19, 42);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(160, 17);
            this.checkBox6.TabIndex = 3;
            this.checkBox6.Tag = "ivakind.flag:4";
            this.checkBox6.Text = "Applicabilit‡ al denominatore";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(19, 19);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(149, 17);
            this.checkBox5.TabIndex = 2;
            this.checkBox5.Tag = "ivakind.flag:3";
            this.checkBox5.Text = "Applicabilit‡ al numeratore";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(1, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 38;
            this.label5.Text = "Annotazioni";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(5, 277);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(327, 44);
            this.textBox1.TabIndex = 32;
            this.textBox1.Tag = "ivakind.annotations";
            // 
            // btnCopyAll
            // 
            this.btnCopyAll.Location = new System.Drawing.Point(351, 277);
            this.btnCopyAll.Name = "btnCopyAll";
            this.btnCopyAll.Size = new System.Drawing.Size(198, 23);
            this.btnCopyAll.TabIndex = 37;
            this.btnCopyAll.Text = "Copia l\'aliquota su tutti gli altri dipartimenti";
            this.btnCopyAll.UseVisualStyleBackColor = true;
            this.btnCopyAll.Click += new System.EventHandler(this.btnCopyAll_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox3);
            this.groupBox2.Controls.Add(this.checkBox4);
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Location = new System.Drawing.Point(351, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(179, 100);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo di attivit‡ a cui Ë applicabile";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(19, 44);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(86, 17);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Tag = "ivakind.flag:1";
            this.checkBox3.Text = "Commerciale";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(19, 67);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(101, 17);
            this.checkBox4.TabIndex = 3;
            this.checkBox4.Tag = "ivakind.flag:2";
            this.checkBox4.Text = "Promiscua/Altro";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(19, 21);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(81, 17);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Tag = "ivakind.flag:0";
            this.checkBox2.Text = "Istituzionale";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cmbTipoImposizione);
            this.groupBox1.Location = new System.Drawing.Point(97, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(682, 50);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo Imposizione";
            // 
            // cmbTipoImposizione
            // 
            this.cmbTipoImposizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipoImposizione.DataSource = this.DS.ivataxablekind;
            this.cmbTipoImposizione.DisplayMember = "description";
            this.cmbTipoImposizione.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoImposizione.Location = new System.Drawing.Point(6, 19);
            this.cmbTipoImposizione.Name = "cmbTipoImposizione";
            this.cmbTipoImposizione.Size = new System.Drawing.Size(670, 21);
            this.cmbTipoImposizione.TabIndex = 0;
            this.cmbTipoImposizione.Tag = "ivakind.idivataxablekind";
            this.cmbTipoImposizione.ValueMember = "idivataxablekind";
            // 
            // checkBox1
            // 
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.Location = new System.Drawing.Point(225, 143);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(67, 24);
            this.checkBox1.TabIndex = 29;
            this.checkBox1.Tag = "ivakind.active:S:N";
            this.checkBox1.Text = "Attivo";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(112, 144);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(104, 20);
            this.textBox4.TabIndex = 28;
            this.textBox4.Tag = "ivakind.unabatabilitypercentage.fixed.2..%.100";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(112, 120);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(104, 20);
            this.textBox3.TabIndex = 27;
            this.textBox3.Tag = "ivakind.rate.fixed.2..%.100";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 36;
            this.label4.Text = "% Indetraibilit‡";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(32, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 35;
            this.label3.Text = "Aliquota";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(1, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 34;
            this.label2.Text = "Descrizione";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCodice
            // 
            this.txtCodice.Location = new System.Drawing.Point(1, 28);
            this.txtCodice.Name = "txtCodice";
            this.txtCodice.Size = new System.Drawing.Size(88, 20);
            this.txtCodice.TabIndex = 24;
            this.txtCodice.Tag = "ivakind.codeivakind";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1, 71);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(324, 43);
            this.textBox2.TabIndex = 26;
            this.textBox2.Tag = "ivakind.description";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(1, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 33;
            this.label1.Text = "Codice";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabClassificazioni
            // 
            this.tabClassificazioni.Controls.Add(this.dGridClassSup);
            this.tabClassificazioni.Controls.Add(this.btnElimina);
            this.tabClassificazioni.Controls.Add(this.btnModifica);
            this.tabClassificazioni.Controls.Add(this.btnInserisci);
            this.tabClassificazioni.Location = new System.Drawing.Point(4, 22);
            this.tabClassificazioni.Name = "tabClassificazioni";
            this.tabClassificazioni.Padding = new System.Windows.Forms.Padding(3);
            this.tabClassificazioni.Size = new System.Drawing.Size(776, 324);
            this.tabClassificazioni.TabIndex = 1;
            this.tabClassificazioni.Text = "Classificazioni";
            // 
            // dGridClassSup
            // 
            this.dGridClassSup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGridClassSup.DataMember = "";
            this.dGridClassSup.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dGridClassSup.Location = new System.Drawing.Point(85, 15);
            this.dGridClassSup.Name = "dGridClassSup";
            this.dGridClassSup.Size = new System.Drawing.Size(670, 292);
            this.dGridClassSup.TabIndex = 24;
            this.dGridClassSup.Tag = "ivakindsorting.default.default";
            // 
            // btnElimina
            // 
            this.btnElimina.Location = new System.Drawing.Point(7, 79);
            this.btnElimina.Name = "btnElimina";
            this.btnElimina.Size = new System.Drawing.Size(72, 24);
            this.btnElimina.TabIndex = 23;
            this.btnElimina.Tag = "delete";
            this.btnElimina.Text = "Elimina";
            // 
            // btnModifica
            // 
            this.btnModifica.Location = new System.Drawing.Point(7, 47);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(72, 24);
            this.btnModifica.TabIndex = 22;
            this.btnModifica.Tag = "edit.single";
            this.btnModifica.Text = "Modifica";
            // 
            // btnInserisci
            // 
            this.btnInserisci.Location = new System.Drawing.Point(7, 15);
            this.btnInserisci.Name = "btnInserisci";
            this.btnInserisci.Size = new System.Drawing.Size(72, 24);
            this.btnInserisci.TabIndex = 21;
            this.btnInserisci.Tag = "insert.single";
            this.btnInserisci.Text = "Inserisci";
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Location = new System.Drawing.Point(553, 226);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(214, 17);
            this.checkBox10.TabIndex = 41;
            this.checkBox10.Tag = "ivakind.flag:9";
            this.checkBox10.Text = "Aliquota iva art74 iva assolta dall\'editore";
            this.checkBox10.UseVisualStyleBackColor = true;
            // 
            // Frm_ivakind_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(796, 377);
            this.Controls.Add(this.MetaDataDetail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Frm_ivakind_default";
            this.Text = "frmtipoiva";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.MetaDataDetail.ResumeLayout(false);
            this.tabPrincipale.ResumeLayout(false);
            this.tabPrincipale.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabClassificazioni.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGridClassSup)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        private void btnCopyAll_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            Meta.SaveFormData();
            if (DS.HasChanges()) return;
            DataRow R= HelpForm.GetLastSelected(DS.ivakind);

            if (MessageBox.Show("Copiare tutte le informazioni dell'aliquota di codice " +
                    R["codeivakind"].ToString() + " su tutti i dipartimenti?", "Attenzione", MessageBoxButtons.YesNo) !=
                    DialogResult.Yes) return;

            Meta.Conn.CallSP("copyrow_ivapay", new object[1] { R["idivakind"] });

        }
	}
}
