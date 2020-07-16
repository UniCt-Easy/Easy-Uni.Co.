/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
using funzioni_configurazione;

namespace stocklocation_default{
	public class Frm_stocklocation_default : System.Windows.Forms.Form{
		private System.Windows.Forms.ImageList icons;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.TreeView treeView1;
		public vistaForm DS;
		public System.Windows.Forms.TabControl MetaDataDetail;
        private System.Windows.Forms.TabPage tabGeneralita;
		private System.Windows.Forms.TextBox txtDenominazione;
		private System.Windows.Forms.TextBox txtCodice;
		private System.Windows.Forms.Label lblDenominazione;
		private System.Windows.Forms.Label lblCodice;
		private System.Windows.Forms.Label lblLivello;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ComboBox cmbLivello;
		private System.Windows.Forms.CheckBox chkAttivo;
		private System.Windows.Forms.ImageList imageList1;
        private TabPage tabAttributi;
        public GroupBox gboxclass05;
        public TextBox txtCodice05;
        public Button btnCodice05;
        private TextBox txtDenom05;
        public GroupBox gboxclass04;
        public TextBox txtCodice04;
        public Button btnCodice04;
        private TextBox txtDenom04;
        public GroupBox gboxclass03;
        public TextBox txtCodice03;
        public Button btnCodice03;
        private TextBox txtDenom03;
        public GroupBox gboxclass02;
        public TextBox txtCodice02;
        public Button btnCodice02;
        private TextBox txtDenom02;
        public GroupBox gboxclass01;
        public TextBox txtCodice01;
        public Button btnCodice01;
        private TextBox txtDenom01;
		private MetaData Meta;

		public Frm_stocklocation_default()	{
			InitializeComponent();
			HelpForm.SetDenyNull(DS.stocklocation.Columns["active"],true);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_stocklocation_default));
            this.icons = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.DS = new stocklocation_default.vistaForm();
            this.MetaDataDetail = new System.Windows.Forms.TabControl();
            this.tabGeneralita = new System.Windows.Forms.TabPage();
            this.chkAttivo = new System.Windows.Forms.CheckBox();
            this.cmbLivello = new System.Windows.Forms.ComboBox();
            this.txtDenominazione = new System.Windows.Forms.TextBox();
            this.txtCodice = new System.Windows.Forms.TextBox();
            this.lblDenominazione = new System.Windows.Forms.Label();
            this.lblCodice = new System.Windows.Forms.Label();
            this.lblLivello = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabAttributi = new System.Windows.Forms.TabPage();
            this.gboxclass05 = new System.Windows.Forms.GroupBox();
            this.txtCodice05 = new System.Windows.Forms.TextBox();
            this.btnCodice05 = new System.Windows.Forms.Button();
            this.txtDenom05 = new System.Windows.Forms.TextBox();
            this.gboxclass04 = new System.Windows.Forms.GroupBox();
            this.txtCodice04 = new System.Windows.Forms.TextBox();
            this.btnCodice04 = new System.Windows.Forms.Button();
            this.txtDenom04 = new System.Windows.Forms.TextBox();
            this.gboxclass03 = new System.Windows.Forms.GroupBox();
            this.txtCodice03 = new System.Windows.Forms.TextBox();
            this.btnCodice03 = new System.Windows.Forms.Button();
            this.txtDenom03 = new System.Windows.Forms.TextBox();
            this.gboxclass02 = new System.Windows.Forms.GroupBox();
            this.txtCodice02 = new System.Windows.Forms.TextBox();
            this.btnCodice02 = new System.Windows.Forms.Button();
            this.txtDenom02 = new System.Windows.Forms.TextBox();
            this.gboxclass01 = new System.Windows.Forms.GroupBox();
            this.txtCodice01 = new System.Windows.Forms.TextBox();
            this.btnCodice01 = new System.Windows.Forms.Button();
            this.txtDenom01 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.MetaDataDetail.SuspendLayout();
            this.tabGeneralita.SuspendLayout();
            this.tabAttributi.SuspendLayout();
            this.gboxclass05.SuspendLayout();
            this.gboxclass04.SuspendLayout();
            this.gboxclass03.SuspendLayout();
            this.gboxclass02.SuspendLayout();
            this.gboxclass01.SuspendLayout();
            this.SuspendLayout();
            // 
            // icons
            // 
            this.icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icons.ImageStream")));
            this.icons.TransparentColor = System.Drawing.Color.Transparent;
            this.icons.Images.SetKeyName(0, "");
            this.icons.Images.SetKeyName(1, "");
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.HideSelection = false;
            this.treeView1.ImageIndex = 1;
            this.treeView1.ImageList = this.icons;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.ShowPlusMinus = false;
            this.treeView1.Size = new System.Drawing.Size(208, 399);
            this.treeView1.TabIndex = 4;
            this.treeView1.Tag = "stocklocation.default";
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // MetaDataDetail
            // 
            this.MetaDataDetail.Controls.Add(this.tabGeneralita);
            this.MetaDataDetail.Controls.Add(this.tabAttributi);
            this.MetaDataDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MetaDataDetail.ImageList = this.imageList1;
            this.MetaDataDetail.Location = new System.Drawing.Point(208, 0);
            this.MetaDataDetail.Name = "MetaDataDetail";
            this.MetaDataDetail.SelectedIndex = 0;
            this.MetaDataDetail.Size = new System.Drawing.Size(517, 399);
            this.MetaDataDetail.TabIndex = 44;
            // 
            // tabGeneralita
            // 
            this.tabGeneralita.Controls.Add(this.chkAttivo);
            this.tabGeneralita.Controls.Add(this.cmbLivello);
            this.tabGeneralita.Controls.Add(this.txtDenominazione);
            this.tabGeneralita.Controls.Add(this.txtCodice);
            this.tabGeneralita.Controls.Add(this.lblDenominazione);
            this.tabGeneralita.Controls.Add(this.lblCodice);
            this.tabGeneralita.Controls.Add(this.lblLivello);
            this.tabGeneralita.Location = new System.Drawing.Point(4, 23);
            this.tabGeneralita.Name = "tabGeneralita";
            this.tabGeneralita.Size = new System.Drawing.Size(509, 372);
            this.tabGeneralita.TabIndex = 0;
            this.tabGeneralita.Text = "Principale";
            this.tabGeneralita.UseVisualStyleBackColor = true;
            // 
            // chkAttivo
            // 
            this.chkAttivo.Location = new System.Drawing.Point(328, 16);
            this.chkAttivo.Name = "chkAttivo";
            this.chkAttivo.Size = new System.Drawing.Size(56, 24);
            this.chkAttivo.TabIndex = 53;
            this.chkAttivo.Tag = "stocklocation.active:S:N";
            this.chkAttivo.Text = "Attivo";
            // 
            // cmbLivello
            // 
            this.cmbLivello.DataSource = this.DS.stocklocationlevel;
            this.cmbLivello.DisplayMember = "description";
            this.cmbLivello.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLivello.Location = new System.Drawing.Point(16, 48);
            this.cmbLivello.Name = "cmbLivello";
            this.cmbLivello.Size = new System.Drawing.Size(168, 21);
            this.cmbLivello.TabIndex = 52;
            this.cmbLivello.Tag = "stocklocation.nlevel";
            this.cmbLivello.ValueMember = "nlevel";
            // 
            // txtDenominazione
            // 
            this.txtDenominazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenominazione.Location = new System.Drawing.Point(16, 104);
            this.txtDenominazione.Multiline = true;
            this.txtDenominazione.Name = "txtDenominazione";
            this.txtDenominazione.Size = new System.Drawing.Size(477, 56);
            this.txtDenominazione.TabIndex = 46;
            this.txtDenominazione.Tag = "stocklocation.description";
            // 
            // txtCodice
            // 
            this.txtCodice.Location = new System.Drawing.Point(216, 48);
            this.txtCodice.Name = "txtCodice";
            this.txtCodice.Size = new System.Drawing.Size(168, 20);
            this.txtCodice.TabIndex = 45;
            this.txtCodice.Tag = "stocklocation.stocklocationcode";
            // 
            // lblDenominazione
            // 
            this.lblDenominazione.Location = new System.Drawing.Point(16, 88);
            this.lblDenominazione.Name = "lblDenominazione";
            this.lblDenominazione.Size = new System.Drawing.Size(84, 13);
            this.lblDenominazione.TabIndex = 49;
            this.lblDenominazione.Text = "Denominazione:";
            this.lblDenominazione.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCodice
            // 
            this.lblCodice.Location = new System.Drawing.Point(213, 32);
            this.lblCodice.Name = "lblCodice";
            this.lblCodice.Size = new System.Drawing.Size(60, 16);
            this.lblCodice.TabIndex = 48;
            this.lblCodice.Text = "Codice:";
            this.lblCodice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLivello
            // 
            this.lblLivello.Location = new System.Drawing.Point(16, 32);
            this.lblLivello.Name = "lblLivello";
            this.lblLivello.Size = new System.Drawing.Size(104, 14);
            this.lblLivello.TabIndex = 47;
            this.lblLivello.Text = "Livello gerarchico:";
            this.lblLivello.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // tabAttributi
            // 
            this.tabAttributi.Controls.Add(this.gboxclass05);
            this.tabAttributi.Controls.Add(this.gboxclass04);
            this.tabAttributi.Controls.Add(this.gboxclass03);
            this.tabAttributi.Controls.Add(this.gboxclass02);
            this.tabAttributi.Controls.Add(this.gboxclass01);
            this.tabAttributi.Location = new System.Drawing.Point(4, 23);
            this.tabAttributi.Name = "tabAttributi";
            this.tabAttributi.Size = new System.Drawing.Size(509, 372);
            this.tabAttributi.TabIndex = 1;
            this.tabAttributi.Text = "Attributi";
            this.tabAttributi.UseVisualStyleBackColor = true;
            // 
            // gboxclass05
            // 
            this.gboxclass05.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxclass05.Controls.Add(this.txtCodice05);
            this.gboxclass05.Controls.Add(this.btnCodice05);
            this.gboxclass05.Controls.Add(this.txtDenom05);
            this.gboxclass05.Location = new System.Drawing.Point(12, 293);
            this.gboxclass05.Name = "gboxclass05";
            this.gboxclass05.Size = new System.Drawing.Size(489, 64);
            this.gboxclass05.TabIndex = 23;
            this.gboxclass05.TabStop = false;
            this.gboxclass05.Tag = "";
            this.gboxclass05.Text = "Classificazione 5";
            // 
            // txtCodice05
            // 
            this.txtCodice05.Location = new System.Drawing.Point(9, 38);
            this.txtCodice05.Name = "txtCodice05";
            this.txtCodice05.Size = new System.Drawing.Size(254, 20);
            this.txtCodice05.TabIndex = 6;
            // 
            // btnCodice05
            // 
            this.btnCodice05.Location = new System.Drawing.Point(8, 16);
            this.btnCodice05.Name = "btnCodice05";
            this.btnCodice05.Size = new System.Drawing.Size(88, 23);
            this.btnCodice05.TabIndex = 4;
            this.btnCodice05.Tag = "manage.sorting05.tree";
            this.btnCodice05.Text = "Codice";
            this.btnCodice05.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom05
            // 
            this.txtDenom05.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom05.Location = new System.Drawing.Point(267, 8);
            this.txtDenom05.Multiline = true;
            this.txtDenom05.Name = "txtDenom05";
            this.txtDenom05.ReadOnly = true;
            this.txtDenom05.Size = new System.Drawing.Size(214, 52);
            this.txtDenom05.TabIndex = 3;
            this.txtDenom05.TabStop = false;
            this.txtDenom05.Tag = "sorting05.description";
            // 
            // gboxclass04
            // 
            this.gboxclass04.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxclass04.Controls.Add(this.txtCodice04);
            this.gboxclass04.Controls.Add(this.btnCodice04);
            this.gboxclass04.Controls.Add(this.txtDenom04);
            this.gboxclass04.Location = new System.Drawing.Point(12, 223);
            this.gboxclass04.Name = "gboxclass04";
            this.gboxclass04.Size = new System.Drawing.Size(489, 64);
            this.gboxclass04.TabIndex = 22;
            this.gboxclass04.TabStop = false;
            this.gboxclass04.Tag = "";
            this.gboxclass04.Text = "Classificazione 4";
            // 
            // txtCodice04
            // 
            this.txtCodice04.Location = new System.Drawing.Point(9, 38);
            this.txtCodice04.Name = "txtCodice04";
            this.txtCodice04.Size = new System.Drawing.Size(254, 20);
            this.txtCodice04.TabIndex = 6;
            // 
            // btnCodice04
            // 
            this.btnCodice04.Location = new System.Drawing.Point(8, 16);
            this.btnCodice04.Name = "btnCodice04";
            this.btnCodice04.Size = new System.Drawing.Size(88, 23);
            this.btnCodice04.TabIndex = 4;
            this.btnCodice04.Tag = "manage.sorting04.tree";
            this.btnCodice04.Text = "Codice";
            this.btnCodice04.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom04
            // 
            this.txtDenom04.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom04.Location = new System.Drawing.Point(267, 8);
            this.txtDenom04.Multiline = true;
            this.txtDenom04.Name = "txtDenom04";
            this.txtDenom04.ReadOnly = true;
            this.txtDenom04.Size = new System.Drawing.Size(214, 52);
            this.txtDenom04.TabIndex = 3;
            this.txtDenom04.TabStop = false;
            this.txtDenom04.Tag = "sorting04.description";
            // 
            // gboxclass03
            // 
            this.gboxclass03.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxclass03.Controls.Add(this.txtCodice03);
            this.gboxclass03.Controls.Add(this.btnCodice03);
            this.gboxclass03.Controls.Add(this.txtDenom03);
            this.gboxclass03.Location = new System.Drawing.Point(13, 153);
            this.gboxclass03.Name = "gboxclass03";
            this.gboxclass03.Size = new System.Drawing.Size(489, 64);
            this.gboxclass03.TabIndex = 20;
            this.gboxclass03.TabStop = false;
            this.gboxclass03.Tag = "";
            this.gboxclass03.Text = "Classificazione 3";
            // 
            // txtCodice03
            // 
            this.txtCodice03.Location = new System.Drawing.Point(8, 38);
            this.txtCodice03.Name = "txtCodice03";
            this.txtCodice03.Size = new System.Drawing.Size(254, 20);
            this.txtCodice03.TabIndex = 6;
            // 
            // btnCodice03
            // 
            this.btnCodice03.Location = new System.Drawing.Point(8, 16);
            this.btnCodice03.Name = "btnCodice03";
            this.btnCodice03.Size = new System.Drawing.Size(88, 23);
            this.btnCodice03.TabIndex = 4;
            this.btnCodice03.Tag = "manage.sorting03.tree";
            this.btnCodice03.Text = "Codice";
            this.btnCodice03.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom03
            // 
            this.txtDenom03.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom03.Location = new System.Drawing.Point(267, 8);
            this.txtDenom03.Multiline = true;
            this.txtDenom03.Name = "txtDenom03";
            this.txtDenom03.ReadOnly = true;
            this.txtDenom03.Size = new System.Drawing.Size(214, 52);
            this.txtDenom03.TabIndex = 3;
            this.txtDenom03.TabStop = false;
            this.txtDenom03.Tag = "sorting03.description";
            // 
            // gboxclass02
            // 
            this.gboxclass02.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxclass02.Controls.Add(this.txtCodice02);
            this.gboxclass02.Controls.Add(this.btnCodice02);
            this.gboxclass02.Controls.Add(this.txtDenom02);
            this.gboxclass02.Location = new System.Drawing.Point(13, 83);
            this.gboxclass02.Name = "gboxclass02";
            this.gboxclass02.Size = new System.Drawing.Size(488, 64);
            this.gboxclass02.TabIndex = 21;
            this.gboxclass02.TabStop = false;
            this.gboxclass02.Tag = "";
            this.gboxclass02.Text = "Classificazione 2";
            // 
            // txtCodice02
            // 
            this.txtCodice02.Location = new System.Drawing.Point(8, 38);
            this.txtCodice02.Name = "txtCodice02";
            this.txtCodice02.Size = new System.Drawing.Size(254, 20);
            this.txtCodice02.TabIndex = 6;
            // 
            // btnCodice02
            // 
            this.btnCodice02.Location = new System.Drawing.Point(8, 16);
            this.btnCodice02.Name = "btnCodice02";
            this.btnCodice02.Size = new System.Drawing.Size(88, 23);
            this.btnCodice02.TabIndex = 4;
            this.btnCodice02.Tag = "manage.sorting02.tree";
            this.btnCodice02.Text = "Codice";
            this.btnCodice02.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom02
            // 
            this.txtDenom02.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom02.Location = new System.Drawing.Point(267, 8);
            this.txtDenom02.Multiline = true;
            this.txtDenom02.Name = "txtDenom02";
            this.txtDenom02.ReadOnly = true;
            this.txtDenom02.Size = new System.Drawing.Size(213, 52);
            this.txtDenom02.TabIndex = 3;
            this.txtDenom02.TabStop = false;
            this.txtDenom02.Tag = "sorting02.description";
            // 
            // gboxclass01
            // 
            this.gboxclass01.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxclass01.Controls.Add(this.txtCodice01);
            this.gboxclass01.Controls.Add(this.btnCodice01);
            this.gboxclass01.Controls.Add(this.txtDenom01);
            this.gboxclass01.Location = new System.Drawing.Point(13, 13);
            this.gboxclass01.Name = "gboxclass01";
            this.gboxclass01.Size = new System.Drawing.Size(488, 64);
            this.gboxclass01.TabIndex = 19;
            this.gboxclass01.TabStop = false;
            this.gboxclass01.Tag = "";
            this.gboxclass01.Text = "Classificazione 1";
            // 
            // txtCodice01
            // 
            this.txtCodice01.Location = new System.Drawing.Point(7, 40);
            this.txtCodice01.Name = "txtCodice01";
            this.txtCodice01.Size = new System.Drawing.Size(254, 20);
            this.txtCodice01.TabIndex = 5;
            // 
            // btnCodice01
            // 
            this.btnCodice01.Location = new System.Drawing.Point(8, 16);
            this.btnCodice01.Name = "btnCodice01";
            this.btnCodice01.Size = new System.Drawing.Size(88, 23);
            this.btnCodice01.TabIndex = 4;
            this.btnCodice01.Tag = "manage.sorting01.tree";
            this.btnCodice01.Text = "Codice";
            this.btnCodice01.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom01
            // 
            this.txtDenom01.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom01.Location = new System.Drawing.Point(267, 8);
            this.txtDenom01.Multiline = true;
            this.txtDenom01.Name = "txtDenom01";
            this.txtDenom01.ReadOnly = true;
            this.txtDenom01.Size = new System.Drawing.Size(213, 52);
            this.txtDenom01.TabIndex = 3;
            this.txtDenom01.TabStop = false;
            this.txtDenom01.Tag = "sorting01.description";
            // 
            // Frm_stocklocation_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(725, 399);
            this.Controls.Add(this.MetaDataDetail);
            this.Controls.Add(this.treeView1);
            this.Name = "Frm_stocklocation_default";
            this.Text = "frmubicazione";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.MetaDataDetail.ResumeLayout(false);
            this.tabGeneralita.ResumeLayout(false);
            this.tabGeneralita.PerformLayout();
            this.tabAttributi.ResumeLayout(false);
            this.gboxclass05.ResumeLayout(false);
            this.gboxclass05.PerformLayout();
            this.gboxclass04.ResumeLayout(false);
            this.gboxclass04.PerformLayout();
            this.gboxclass03.ResumeLayout(false);
            this.gboxclass03.PerformLayout();
            this.gboxclass02.ResumeLayout(false);
            this.gboxclass02.PerformLayout();
            this.gboxclass01.ResumeLayout(false);
            this.gboxclass01.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
			GetData.CacheTable(DS.stocklocationlevel,null,null,true);
            DataAccess.SetTableForReading(DS.sorting01, "sorting");
            DataAccess.SetTableForReading(DS.sorting02, "sorting");
            DataAccess.SetTableForReading(DS.sorting03, "sorting");
            DataAccess.SetTableForReading(DS.sorting04, "sorting");
            DataAccess.SetTableForReading(DS.sorting05, "sorting");
		    HelpForm.SetDenyNull(DS.stocklocation.Columns["active"], true);

            DataTable tUniConfig = Meta.Conn.RUN_SELECT("uniconfig", "*", null, null, null, null, true);
            if ((tUniConfig != null) && (tUniConfig.Rows.Count > 0)) {
                DataRow r = tUniConfig.Rows[0];
                object idsorkind1 = r["idsorkind01"];
                object idsorkind2 = r["idsorkind02"];
                object idsorkind3 = r["idsorkind03"];
                object idsorkind4 = r["idsorkind04"];
                object idsorkind5 = r["idsorkind05"];
                CfgFn.SetGBoxClass0(this, 1, idsorkind1);
                CfgFn.SetGBoxClass0(this, 2, idsorkind2);
                CfgFn.SetGBoxClass0(this, 3, idsorkind3);
                CfgFn.SetGBoxClass0(this, 4, idsorkind4);
                CfgFn.SetGBoxClass0(this, 5, idsorkind5);
                if (idsorkind1 == DBNull.Value && idsorkind2 == DBNull.Value &&
                    idsorkind3 == DBNull.Value && idsorkind4 == DBNull.Value && idsorkind5 == DBNull.Value) {
                    MetaDataDetail.TabPages.Remove(tabAttributi);
                }
            }
            AbilitaAttributi(false);
		}

		public void MetaData_AfterClear(){
			cmbLivello.Enabled=true;
			txtCodice.ReadOnly=false;
			txtDenominazione.ReadOnly=false;
            Meta.CanInsert = false;
            AbilitaAttributi(true);
		}

        public void AbilitaAttributi (bool enable){
            gboxclass01.Enabled = enable;
            gboxclass02.Enabled = enable;
            gboxclass03.Enabled = enable;
            gboxclass04.Enabled = enable;
            gboxclass05.Enabled = enable;
        }

		public void MetaData_AfterFill(){
            if (!Meta.CanInsert) {
                Meta.CanInsert = true;
                Meta.FreshToolBar();
            }
			//abilita/disabilita i controlli
			bool ModoInsert= Meta.InsertMode;
			cmbLivello.Enabled=false;
            if (ModoInsert) {
                DataRow R = HelpForm.GetLastSelected(DS.stocklocation);
                if (R == null)
                    return;
                string livello = R["nlevel"].ToString();
                txtCodice.ReadOnly = TipoNumerico(livello);
            }
		}

		public void MetaData_AfterRowSelect(DataTable T, DataRow R){
			if (T.TableName != "stocklocation") return;
			cmbLivello.Enabled=false;
			bool ModoInsert=Meta.InsertMode;
			if (Operativo(R)){
				object livello = R["nlevel"].ToString();
				txtCodice.ReadOnly=!(ModoInsert && !TipoNumerico(livello));
			}
			else{
				txtCodice.ReadOnly=true;
			}
            if (R != null) {
                AbilitaAttributi(true);
                Meta.FreshForm();
            }
            else {
                AbilitaAttributi(false);
            }
		}

		private bool Operativo(DataRow R){
			if (R==null) return false;
			object livellorow=R["nlevel"];
			DataRow[] Res = DS.stocklocationlevel.Select("(nlevel="+
				QueryCreator.quotedstrvalue(livellorow,true)+")");
			if (Res.Length!=1) return false;
            int flag = CfgFn.GetNoNullInt32(Res[0]["flag"]);
            bool usable = ((flag & 2) != 0);
			return usable;
		}

		private bool TipoNumerico(object codicelivello){
			DataRow[] Res = DS.stocklocationlevel.Select("(nlevel="+
				QueryCreator.quotedstrvalue(codicelivello,true)+")");
			if (Res.Length!=1) return false;
            int flag = CfgFn.GetNoNullInt32(Res[0]["flag"]);
            bool numerico = ((flag & 1) == 0);
			return numerico;
		}

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e) {
            if ((!Meta.IsEmpty) && (!Meta.CanInsert)) {
                Meta.CanInsert = true;
                Meta.FreshToolBar();
            }
        }

	}
}
