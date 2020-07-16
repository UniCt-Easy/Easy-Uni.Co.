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
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;

namespace assetloadkind_default//tipobuonocaricoinv//
{
	/// <summary>
	/// Summary description for frmtipobuonocaricoinv.
	/// </summary>
    public class Frm_assetloadkind_default : System.Windows.Forms.Form {
        private System.Windows.Forms.ImageList images;
		public vistaForm DS;
        private System.ComponentModel.IContainer components;
        private TabControl tabAssetloadkind;
        private TabPage tabGenerale;
        private GroupBox groupBox2;
        private ComboBox comboBox1;
        private GroupBox groupBox1;
        private CheckBox checkBox4;
        private TextBox textBox3;
        private Label label3;
        private CheckBox checkBox3;
        private Label label2;
        private TextBox txtCodice;
        private TextBox textBox2;
        private Label label1;
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
        MetaData Meta;

		public Frm_assetloadkind_default()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            HelpForm.SetDenyNull(DS.assetloadkind.Columns["active"], true);

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

        DataAccess Conn = null;
        QueryHelper QHS = null;

        public void MetaData_AfterLink()
        {
            Meta = MetaData.GetMetaData(this);
            Conn = MetaData.GetConnection(this);
            QHS = Conn.GetQueryHelper();
            DataAccess.SetTableForReading(DS.sorting01, "sorting");
            DataAccess.SetTableForReading(DS.sorting02, "sorting");
            DataAccess.SetTableForReading(DS.sorting03, "sorting");
            DataAccess.SetTableForReading(DS.sorting04, "sorting");
            DataAccess.SetTableForReading(DS.sorting05, "sorting");

            DataTable tUniConfig = Conn.RUN_SELECT("uniconfig", "*", null,
              null, null, null, true);
            if ((tUniConfig != null) && (tUniConfig.Rows.Count > 0))
            {
                DataRow r = tUniConfig.Rows[0];
                object idsorkind1 = r["idsorkind01"];
                object idsorkind2 = r["idsorkind02"];
                object idsorkind3 = r["idsorkind03"];
                object idsorkind4 = r["idsorkind04"];
                object idsorkind5 = r["idsorkind05"];
                CfgFn.SetGBoxClass0(this,1, idsorkind1);
                CfgFn.SetGBoxClass0(this, 2, idsorkind2);
                CfgFn.SetGBoxClass0(this, 3, idsorkind3);
                CfgFn.SetGBoxClass0(this, 4, idsorkind4);
                CfgFn.SetGBoxClass0(this, 5, idsorkind5);
                if (idsorkind1 == DBNull.Value && idsorkind2 == DBNull.Value &&
                    idsorkind3 == DBNull.Value && idsorkind4 == DBNull.Value && idsorkind5 == DBNull.Value)
                {
                    tabAssetloadkind.TabPages.Remove(tabAttributi);
                }
            }
        }


        public void MetaData_AfterClear() {
            txtCodice.ReadOnly = false;
        }
        public void MetaData_AfterFill() {
            if (Meta.InsertMode) {
                txtCodice.ReadOnly = false;
            }
            else {
                txtCodice.ReadOnly = true;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_assetloadkind_default));
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.DS = new assetloadkind_default.vistaForm();
            this.tabAssetloadkind = new System.Windows.Forms.TabControl();
            this.tabGenerale = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodice = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.tabAssetloadkind.SuspendLayout();
            this.tabGenerale.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabAttributi.SuspendLayout();
            this.gboxclass05.SuspendLayout();
            this.gboxclass04.SuspendLayout();
            this.gboxclass03.SuspendLayout();
            this.gboxclass02.SuspendLayout();
            this.gboxclass01.SuspendLayout();
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
            // tabAssetloadkind
            // 
            this.tabAssetloadkind.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabAssetloadkind.Controls.Add(this.tabGenerale);
            this.tabAssetloadkind.Controls.Add(this.tabAttributi);
            this.tabAssetloadkind.Location = new System.Drawing.Point(12, 12);
            this.tabAssetloadkind.Name = "tabAssetloadkind";
            this.tabAssetloadkind.SelectedIndex = 0;
            this.tabAssetloadkind.Size = new System.Drawing.Size(611, 400);
            this.tabAssetloadkind.TabIndex = 2;
            // 
            // tabGenerale
            // 
            this.tabGenerale.Controls.Add(this.groupBox2);
            this.tabGenerale.Controls.Add(this.groupBox1);
            this.tabGenerale.Controls.Add(this.checkBox3);
            this.tabGenerale.Controls.Add(this.label2);
            this.tabGenerale.Controls.Add(this.txtCodice);
            this.tabGenerale.Controls.Add(this.textBox2);
            this.tabGenerale.Controls.Add(this.label1);
            this.tabGenerale.Location = new System.Drawing.Point(4, 22);
            this.tabGenerale.Name = "tabGenerale";
            this.tabGenerale.Padding = new System.Windows.Forms.Padding(3);
            this.tabGenerale.Size = new System.Drawing.Size(603, 374);
            this.tabGenerale.TabIndex = 0;
            this.tabGenerale.Text = "Generale";
            this.tabGenerale.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Location = new System.Drawing.Point(1, 141);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(596, 49);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Inventario associato al buono di carico";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DataSource = this.DS.inventory;
            this.comboBox1.DisplayMember = "description";
            this.comboBox1.Location = new System.Drawing.Point(8, 16);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(582, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Tag = "assetloadkind.idinventory.(active=\'S\')";
            this.comboBox1.ValueMember = "idinventory";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(6, 205);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(591, 50);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Numerazione del buono di carico";
            // 
            // checkBox4
            // 
            this.checkBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox4.Location = new System.Drawing.Point(361, 26);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox4.Size = new System.Drawing.Size(224, 16);
            this.checkBox4.TabIndex = 1;
            this.checkBox4.Tag = "assetloadkind.flag:0";
            this.checkBox4.Text = "Assoluta, non tiene conto dell\'esercizio";
            this.checkBox4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(96, 22);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(56, 20);
            this.textBox3.TabIndex = 0;
            this.textBox3.Tag = "assetloadkind.startnumber";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 28;
            this.label3.Text = "Numero iniziale:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(341, 21);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(53, 17);
            this.checkBox3.TabIndex = 27;
            this.checkBox3.Tag = "assetloadkind.active:S:N";
            this.checkBox3.Text = "Attivo";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 26;
            this.label2.Text = "Descrizione:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCodice
            // 
            this.txtCodice.Location = new System.Drawing.Point(134, 20);
            this.txtCodice.Name = "txtCodice";
            this.txtCodice.Size = new System.Drawing.Size(105, 20);
            this.txtCodice.TabIndex = 23;
            this.txtCodice.Tag = "assetloadkind.codeassetloadkind";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(7, 85);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(580, 20);
            this.textBox2.TabIndex = 24;
            this.textBox2.Tag = "assetloadkind.description";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 16);
            this.label1.TabIndex = 25;
            this.label1.Text = "Codice del tipo buono:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabAttributi
            // 
            this.tabAttributi.Controls.Add(this.gboxclass05);
            this.tabAttributi.Controls.Add(this.gboxclass04);
            this.tabAttributi.Controls.Add(this.gboxclass03);
            this.tabAttributi.Controls.Add(this.gboxclass02);
            this.tabAttributi.Controls.Add(this.gboxclass01);
            this.tabAttributi.Location = new System.Drawing.Point(4, 22);
            this.tabAttributi.Name = "tabAttributi";
            this.tabAttributi.Padding = new System.Windows.Forms.Padding(3);
            this.tabAttributi.Size = new System.Drawing.Size(603, 374);
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
            this.gboxclass05.Location = new System.Drawing.Point(4, 285);
            this.gboxclass05.Name = "gboxclass05";
            this.gboxclass05.Size = new System.Drawing.Size(594, 64);
            this.gboxclass05.TabIndex = 38;
            this.gboxclass05.TabStop = false;
            this.gboxclass05.Tag = "";
            this.gboxclass05.Text = "Classificazione 5";
            // 
            // txtCodice05
            // 
            this.txtCodice05.Location = new System.Drawing.Point(9, 38);
            this.txtCodice05.Name = "txtCodice05";
            this.txtCodice05.Size = new System.Drawing.Size(219, 20);
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
            this.txtDenom05.Location = new System.Drawing.Point(234, 8);
            this.txtDenom05.Multiline = true;
            this.txtDenom05.Name = "txtDenom05";
            this.txtDenom05.ReadOnly = true;
            this.txtDenom05.Size = new System.Drawing.Size(352, 52);
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
            this.gboxclass04.Location = new System.Drawing.Point(4, 215);
            this.gboxclass04.Name = "gboxclass04";
            this.gboxclass04.Size = new System.Drawing.Size(594, 64);
            this.gboxclass04.TabIndex = 37;
            this.gboxclass04.TabStop = false;
            this.gboxclass04.Tag = "";
            this.gboxclass04.Text = "Classificazione 4";
            // 
            // txtCodice04
            // 
            this.txtCodice04.Location = new System.Drawing.Point(9, 38);
            this.txtCodice04.Name = "txtCodice04";
            this.txtCodice04.Size = new System.Drawing.Size(219, 20);
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
            this.txtDenom04.Location = new System.Drawing.Point(234, 12);
            this.txtDenom04.Multiline = true;
            this.txtDenom04.Name = "txtDenom04";
            this.txtDenom04.ReadOnly = true;
            this.txtDenom04.Size = new System.Drawing.Size(352, 46);
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
            this.gboxclass03.Location = new System.Drawing.Point(4, 145);
            this.gboxclass03.Name = "gboxclass03";
            this.gboxclass03.Size = new System.Drawing.Size(594, 64);
            this.gboxclass03.TabIndex = 35;
            this.gboxclass03.TabStop = false;
            this.gboxclass03.Tag = "";
            this.gboxclass03.Text = "Classificazione 3";
            // 
            // txtCodice03
            // 
            this.txtCodice03.Location = new System.Drawing.Point(8, 38);
            this.txtCodice03.Name = "txtCodice03";
            this.txtCodice03.Size = new System.Drawing.Size(219, 20);
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
            this.txtDenom03.Location = new System.Drawing.Point(233, 8);
            this.txtDenom03.Multiline = true;
            this.txtDenom03.Name = "txtDenom03";
            this.txtDenom03.ReadOnly = true;
            this.txtDenom03.Size = new System.Drawing.Size(353, 52);
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
            this.gboxclass02.Location = new System.Drawing.Point(4, 75);
            this.gboxclass02.Name = "gboxclass02";
            this.gboxclass02.Size = new System.Drawing.Size(594, 64);
            this.gboxclass02.TabIndex = 36;
            this.gboxclass02.TabStop = false;
            this.gboxclass02.Tag = "";
            this.gboxclass02.Text = "Classificazione 2";
            // 
            // txtCodice02
            // 
            this.txtCodice02.Location = new System.Drawing.Point(8, 38);
            this.txtCodice02.Name = "txtCodice02";
            this.txtCodice02.Size = new System.Drawing.Size(219, 20);
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
            this.txtDenom02.Location = new System.Drawing.Point(233, 8);
            this.txtDenom02.Multiline = true;
            this.txtDenom02.Name = "txtDenom02";
            this.txtDenom02.ReadOnly = true;
            this.txtDenom02.Size = new System.Drawing.Size(353, 52);
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
            this.gboxclass01.Location = new System.Drawing.Point(4, 5);
            this.gboxclass01.Name = "gboxclass01";
            this.gboxclass01.Size = new System.Drawing.Size(594, 64);
            this.gboxclass01.TabIndex = 34;
            this.gboxclass01.TabStop = false;
            this.gboxclass01.Tag = "";
            this.gboxclass01.Text = "Classificazione 1";
            // 
            // txtCodice01
            // 
            this.txtCodice01.Location = new System.Drawing.Point(7, 40);
            this.txtCodice01.Name = "txtCodice01";
            this.txtCodice01.Size = new System.Drawing.Size(220, 20);
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
            this.txtDenom01.Location = new System.Drawing.Point(233, 8);
            this.txtDenom01.Multiline = true;
            this.txtDenom01.Name = "txtDenom01";
            this.txtDenom01.ReadOnly = true;
            this.txtDenom01.Size = new System.Drawing.Size(353, 52);
            this.txtDenom01.TabIndex = 3;
            this.txtDenom01.TabStop = false;
            this.txtDenom01.Tag = "sorting01.description";
            // 
            // Frm_assetloadkind_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(638, 436);
            this.Controls.Add(this.tabAssetloadkind);
            this.Name = "Frm_assetloadkind_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmtipobuonocaricoinv";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.tabAssetloadkind.ResumeLayout(false);
            this.tabGenerale.ResumeLayout(false);
            this.tabGenerale.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
	}
}
