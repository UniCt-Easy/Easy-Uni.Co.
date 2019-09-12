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
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
//using MenuUpdate;//MenuUpdate

namespace uniconfig_default
{
	/// <summary>
	/// Summary description for frmfasespesa.
	/// </summary>
    public class Frm_uniconfig_default : System.Windows.Forms.Form {
        private System.Windows.Forms.ImageList images;
        public vistaForm DS;
        private Button btnAnnulla;
        private Button btnOK;
		private System.ComponentModel.IContainer components;
        bool CanGoEdit;
        bool CanGoInsert;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private GroupBox researchagency;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private GroupBox groupBox1;
        private ComboBox cmbExpenseFin;
        private Label label1;
        private ComboBox cmbExpenseRegistry;
        private Label label2;
        private GroupBox groupBox2;
        private ComboBox cmbIncomeFin;
        private Label label3;
        private ComboBox cmbIncomeRegistry;
        private Label label4;
        private TabPage tabPage2;
        private GroupBox groupBox4;
        private Label lblSorting5;
        private ComboBox comboBox2;
        private GroupBox groupBox3;
        private Label lblSorting4;
        private ComboBox comboBox1;
        private GroupBox groupBox25;
        private Label lblSorting2;
        private ComboBox cmbClass3;
        private GroupBox groupBox26;
        private ComboBox cmbClass2;
        private Label lblSorting1;
        private GroupBox groupBox27;
        private ComboBox cmbClass1;
        private Label lblSorting;
        public MetaData Meta;
        CQueryHelper QHC;
        private CheckBox chkClass5;
        private CheckBox chkClass4;
        private CheckBox chkClass3;
        private CheckBox chkClass2;
        private CheckBox chkClass1;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private GroupBox groupBox5;
        private RadioButton radioButton3;
        private RadioButton radioButton4;
        private CheckBox checkBox5;
        private CheckBox checkBox6;
        private TabPage tabPage3;
        private TextBox textBox2;
        private Label label6;
        private TextBox textBox1;
        private Label label5;
        private TextBox txtGiornoScad;
        private Label labDay;
        private RadioButton radioButton6;
        private RadioButton radioButton5;
        private RadioButton rdbBeniintra12;
        private GroupBox groupBox7;
        private RadioButton radioButton7;
        private RadioButton radioButton9;
        private GroupBox groupBox6;
        QueryHelper QHS;
		public Frm_uniconfig_default()
		{
			InitializeComponent();
            CanGoEdit = true;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_uniconfig_default));
            this.DS = new uniconfig_default.vistaForm();
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.researchagency = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbExpenseFin = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbExpenseRegistry = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbIncomeFin = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbIncomeRegistry = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkClass5 = new System.Windows.Forms.CheckBox();
            this.lblSorting5 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkClass4 = new System.Windows.Forms.CheckBox();
            this.lblSorting4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.chkClass3 = new System.Windows.Forms.CheckBox();
            this.lblSorting2 = new System.Windows.Forms.Label();
            this.cmbClass3 = new System.Windows.Forms.ComboBox();
            this.groupBox26 = new System.Windows.Forms.GroupBox();
            this.chkClass2 = new System.Windows.Forms.CheckBox();
            this.cmbClass2 = new System.Windows.Forms.ComboBox();
            this.lblSorting1 = new System.Windows.Forms.Label();
            this.groupBox27 = new System.Windows.Forms.GroupBox();
            this.chkClass1 = new System.Windows.Forms.CheckBox();
            this.cmbClass1 = new System.Windows.Forms.ComboBox();
            this.lblSorting = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.rdbBeniintra12 = new System.Windows.Forms.RadioButton();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGiornoScad = new System.Windows.Forms.TextBox();
            this.labDay = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.researchagency.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox25.SuspendLayout();
            this.groupBox26.SuspendLayout();
            this.groupBox27.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
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
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(492, 448);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 5;
            this.btnAnnulla.Text = "Annulla";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(411, 448);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Tag = "mainsave";
            this.btnOK.Text = "OK";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(555, 430);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.checkBox6);
            this.tabPage1.Controls.Add(this.checkBox5);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.checkBox4);
            this.tabPage1.Controls.Add(this.checkBox3);
            this.tabPage1.Controls.Add(this.checkBox2);
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.researchagency);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(547, 404);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Fasi";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(15, 374);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(327, 17);
            this.checkBox6.TabIndex = 14;
            this.checkBox6.Tag = "uniconfig.flag:3";
            this.checkBox6.Text = "Vieta stampa contratti passivi non collegati ad impegni di budget";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(15, 351);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(361, 17);
            this.checkBox5.TabIndex = 13;
            this.checkBox5.Tag = "uniconfig.flag:2";
            this.checkBox5.Text = "Vieta stampa contratti passivi non contabilizzati con impegno finanziario";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radioButton3);
            this.groupBox5.Controls.Add(this.radioButton4);
            this.groupBox5.Location = new System.Drawing.Point(212, 176);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(191, 68);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Tipo Università";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(18, 42);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(127, 17);
            this.radioButton3.TabIndex = 1;
            this.radioButton3.TabStop = true;
            this.radioButton3.Tag = "uniconfig.publicagency:N";
            this.radioButton3.Text = "Università non statale";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(18, 19);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(106, 17);
            this.radioButton4.TabIndex = 0;
            this.radioButton4.TabStop = true;
            this.radioButton4.Tag = "uniconfig.publicagency:S";
            this.radioButton4.Text = "Università statale";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(15, 328);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(106, 17);
            this.checkBox4.TabIndex = 11;
            this.checkBox4.Tag = "uniconfig.flag:1";
            this.checkBox4.Text = "Usa servizio FTP";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(15, 305);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(277, 17);
            this.checkBox3.TabIndex = 10;
            this.checkBox3.Tag = "uniconfig.ep360days:S:N";
            this.checkBox3.Text = "Considera l\'anno commerciale negli impegni di budget";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(15, 282);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(320, 17);
            this.checkBox2.TabIndex = 9;
            this.checkBox2.Tag = "uniconfig.flag:0";
            this.checkBox2.Text = "Non consentire l\'esitazione di bollette non associate a cassiere";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(15, 259);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(296, 17);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Tag = "uniconfig.tree_upb_withdescr:S:N";
            this.checkBox1.Text = "Visualizza albero delle UPB con Codice e Denominazione";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // researchagency
            // 
            this.researchagency.Controls.Add(this.radioButton2);
            this.researchagency.Controls.Add(this.radioButton1);
            this.researchagency.Location = new System.Drawing.Point(15, 176);
            this.researchagency.Name = "researchagency";
            this.researchagency.Size = new System.Drawing.Size(147, 68);
            this.researchagency.TabIndex = 7;
            this.researchagency.TabStop = false;
            this.researchagency.Text = "Tipo Ente";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(18, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(116, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Tag = "uniconfig.flagresearchagency:N";
            this.radioButton2.Text = "Ente Non di ricerca";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(18, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(93, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Tag = "uniconfig.flagresearchagency:S";
            this.radioButton1.Text = "Ente di ricerca";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cmbExpenseFin);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbExpenseRegistry);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(517, 69);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Spesa";
            // 
            // cmbExpenseFin
            // 
            this.cmbExpenseFin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbExpenseFin.DataSource = this.DS.expensephase_fin;
            this.cmbExpenseFin.DisplayMember = "description";
            this.cmbExpenseFin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExpenseFin.Location = new System.Drawing.Point(200, 40);
            this.cmbExpenseFin.Name = "cmbExpenseFin";
            this.cmbExpenseFin.Size = new System.Drawing.Size(309, 21);
            this.cmbExpenseFin.TabIndex = 2;
            this.cmbExpenseFin.Tag = "uniconfig.expensefinphase";
            this.cmbExpenseFin.ValueMember = "nphase";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fase Percipiente:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbExpenseRegistry
            // 
            this.cmbExpenseRegistry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbExpenseRegistry.DataSource = this.DS.expensephase_registry;
            this.cmbExpenseRegistry.DisplayMember = "description";
            this.cmbExpenseRegistry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExpenseRegistry.Location = new System.Drawing.Point(200, 16);
            this.cmbExpenseRegistry.Name = "cmbExpenseRegistry";
            this.cmbExpenseRegistry.Size = new System.Drawing.Size(309, 21);
            this.cmbExpenseRegistry.TabIndex = 1;
            this.cmbExpenseRegistry.Tag = "uniconfig.expenseregphase";
            this.cmbExpenseRegistry.ValueMember = "nphase";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Fase Bilancio Annuale:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cmbIncomeFin);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cmbIncomeRegistry);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(517, 72);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Entrata";
            // 
            // cmbIncomeFin
            // 
            this.cmbIncomeFin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbIncomeFin.DataSource = this.DS.incomephase_fin;
            this.cmbIncomeFin.DisplayMember = "description";
            this.cmbIncomeFin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIncomeFin.Location = new System.Drawing.Point(200, 40);
            this.cmbIncomeFin.Name = "cmbIncomeFin";
            this.cmbIncomeFin.Size = new System.Drawing.Size(309, 21);
            this.cmbIncomeFin.TabIndex = 2;
            this.cmbIncomeFin.Tag = "uniconfig.incomefinphase";
            this.cmbIncomeFin.ValueMember = "nphase";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "Fase Versante";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbIncomeRegistry
            // 
            this.cmbIncomeRegistry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbIncomeRegistry.DataSource = this.DS.incomephase_registry;
            this.cmbIncomeRegistry.DisplayMember = "description";
            this.cmbIncomeRegistry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIncomeRegistry.Location = new System.Drawing.Point(200, 16);
            this.cmbIncomeRegistry.Name = "cmbIncomeRegistry";
            this.cmbIncomeRegistry.Size = new System.Drawing.Size(309, 21);
            this.cmbIncomeRegistry.TabIndex = 1;
            this.cmbIncomeRegistry.Tag = "uniconfig.incomeregphase";
            this.cmbIncomeRegistry.ValueMember = "nphase";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Fase Bilancio Annuale:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox25);
            this.tabPage2.Controls.Add(this.groupBox26);
            this.tabPage2.Controls.Add(this.groupBox27);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(547, 404);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = " Attributi";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkClass5);
            this.groupBox4.Controls.Add(this.lblSorting5);
            this.groupBox4.Controls.Add(this.comboBox2);
            this.groupBox4.Location = new System.Drawing.Point(8, 261);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(526, 64);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            // 
            // chkClass5
            // 
            this.chkClass5.AutoSize = true;
            this.chkClass5.Location = new System.Drawing.Point(421, 26);
            this.chkClass5.Name = "chkClass5";
            this.chkClass5.Size = new System.Drawing.Size(95, 17);
            this.chkClass5.TabIndex = 6;
            this.chkClass5.Tag = "uniconfig.sorkind05asfilter:S:N";
            this.chkClass5.Text = "Filtro sicurezza";
            this.chkClass5.UseVisualStyleBackColor = true;
            // 
            // lblSorting5
            // 
            this.lblSorting5.Location = new System.Drawing.Point(8, 24);
            this.lblSorting5.Name = "lblSorting5";
            this.lblSorting5.Size = new System.Drawing.Size(100, 23);
            this.lblSorting5.TabIndex = 2;
            this.lblSorting5.Text = "Classificazione5:";
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox2.DataSource = this.DS.sortingkind4;
            this.comboBox2.DisplayMember = "description";
            this.comboBox2.Location = new System.Drawing.Point(143, 24);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(273, 21);
            this.comboBox2.TabIndex = 5;
            this.comboBox2.Tag = "uniconfig.idsorkind05";
            this.comboBox2.ValueMember = "idsorkind";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkClass4);
            this.groupBox3.Controls.Add(this.lblSorting4);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Location = new System.Drawing.Point(9, 194);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(526, 64);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            // 
            // chkClass4
            // 
            this.chkClass4.AutoSize = true;
            this.chkClass4.Location = new System.Drawing.Point(420, 28);
            this.chkClass4.Name = "chkClass4";
            this.chkClass4.Size = new System.Drawing.Size(95, 17);
            this.chkClass4.TabIndex = 6;
            this.chkClass4.Tag = "uniconfig.sorkind04asfilter:S:N";
            this.chkClass4.Text = "Filtro sicurezza";
            this.chkClass4.UseVisualStyleBackColor = true;
            // 
            // lblSorting4
            // 
            this.lblSorting4.Location = new System.Drawing.Point(8, 24);
            this.lblSorting4.Name = "lblSorting4";
            this.lblSorting4.Size = new System.Drawing.Size(100, 23);
            this.lblSorting4.TabIndex = 2;
            this.lblSorting4.Text = "Classificazione 4:";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DataSource = this.DS.sortingkind3;
            this.comboBox1.DisplayMember = "description";
            this.comboBox1.Location = new System.Drawing.Point(143, 24);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(273, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.Tag = "uniconfig.idsorkind04";
            this.comboBox1.ValueMember = "idsorkind";
            // 
            // groupBox25
            // 
            this.groupBox25.Controls.Add(this.chkClass3);
            this.groupBox25.Controls.Add(this.lblSorting2);
            this.groupBox25.Controls.Add(this.cmbClass3);
            this.groupBox25.Location = new System.Drawing.Point(8, 129);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(526, 64);
            this.groupBox25.TabIndex = 14;
            this.groupBox25.TabStop = false;
            // 
            // chkClass3
            // 
            this.chkClass3.AutoSize = true;
            this.chkClass3.Location = new System.Drawing.Point(421, 30);
            this.chkClass3.Name = "chkClass3";
            this.chkClass3.Size = new System.Drawing.Size(95, 17);
            this.chkClass3.TabIndex = 6;
            this.chkClass3.Tag = "uniconfig.sorkind03asfilter:S:N";
            this.chkClass3.Text = "Filtro sicurezza";
            this.chkClass3.UseVisualStyleBackColor = true;
            // 
            // lblSorting2
            // 
            this.lblSorting2.Location = new System.Drawing.Point(8, 24);
            this.lblSorting2.Name = "lblSorting2";
            this.lblSorting2.Size = new System.Drawing.Size(100, 23);
            this.lblSorting2.TabIndex = 2;
            this.lblSorting2.Text = "Classificazione 3:";
            // 
            // cmbClass3
            // 
            this.cmbClass3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbClass3.DataSource = this.DS.sortingkind2;
            this.cmbClass3.DisplayMember = "description";
            this.cmbClass3.Location = new System.Drawing.Point(143, 24);
            this.cmbClass3.Name = "cmbClass3";
            this.cmbClass3.Size = new System.Drawing.Size(273, 21);
            this.cmbClass3.TabIndex = 5;
            this.cmbClass3.Tag = "uniconfig.idsorkind03";
            this.cmbClass3.ValueMember = "idsorkind";
            // 
            // groupBox26
            // 
            this.groupBox26.Controls.Add(this.chkClass2);
            this.groupBox26.Controls.Add(this.cmbClass2);
            this.groupBox26.Controls.Add(this.lblSorting1);
            this.groupBox26.Location = new System.Drawing.Point(8, 68);
            this.groupBox26.Name = "groupBox26";
            this.groupBox26.Size = new System.Drawing.Size(526, 56);
            this.groupBox26.TabIndex = 13;
            this.groupBox26.TabStop = false;
            // 
            // chkClass2
            // 
            this.chkClass2.AutoSize = true;
            this.chkClass2.Location = new System.Drawing.Point(421, 28);
            this.chkClass2.Name = "chkClass2";
            this.chkClass2.Size = new System.Drawing.Size(95, 17);
            this.chkClass2.TabIndex = 5;
            this.chkClass2.Tag = "uniconfig.sorkind02asfilter:S:N";
            this.chkClass2.Text = "Filtro sicurezza";
            this.chkClass2.UseVisualStyleBackColor = true;
            // 
            // cmbClass2
            // 
            this.cmbClass2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbClass2.DataSource = this.DS.sortingkind1;
            this.cmbClass2.DisplayMember = "description";
            this.cmbClass2.Location = new System.Drawing.Point(143, 24);
            this.cmbClass2.Name = "cmbClass2";
            this.cmbClass2.Size = new System.Drawing.Size(273, 21);
            this.cmbClass2.TabIndex = 4;
            this.cmbClass2.Tag = "uniconfig.idsorkind02";
            this.cmbClass2.ValueMember = "idsorkind";
            // 
            // lblSorting1
            // 
            this.lblSorting1.Location = new System.Drawing.Point(8, 24);
            this.lblSorting1.Name = "lblSorting1";
            this.lblSorting1.Size = new System.Drawing.Size(100, 23);
            this.lblSorting1.TabIndex = 1;
            this.lblSorting1.Text = "Classificazione 2:";
            // 
            // groupBox27
            // 
            this.groupBox27.Controls.Add(this.chkClass1);
            this.groupBox27.Controls.Add(this.cmbClass1);
            this.groupBox27.Controls.Add(this.lblSorting);
            this.groupBox27.Location = new System.Drawing.Point(8, 9);
            this.groupBox27.Name = "groupBox27";
            this.groupBox27.Size = new System.Drawing.Size(526, 56);
            this.groupBox27.TabIndex = 12;
            this.groupBox27.TabStop = false;
            // 
            // chkClass1
            // 
            this.chkClass1.AutoSize = true;
            this.chkClass1.Location = new System.Drawing.Point(421, 26);
            this.chkClass1.Name = "chkClass1";
            this.chkClass1.Size = new System.Drawing.Size(95, 17);
            this.chkClass1.TabIndex = 4;
            this.chkClass1.Tag = "uniconfig.sorkind01asfilter:S:N";
            this.chkClass1.Text = "Filtro sicurezza";
            this.chkClass1.UseVisualStyleBackColor = true;
            // 
            // cmbClass1
            // 
            this.cmbClass1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbClass1.DataSource = this.DS.sortingkind;
            this.cmbClass1.DisplayMember = "description";
            this.cmbClass1.Location = new System.Drawing.Point(143, 24);
            this.cmbClass1.Name = "cmbClass1";
            this.cmbClass1.Size = new System.Drawing.Size(273, 21);
            this.cmbClass1.TabIndex = 3;
            this.cmbClass1.Tag = "uniconfig.idsorkind01";
            this.cmbClass1.ValueMember = "idsorkind";
            // 
            // lblSorting
            // 
            this.lblSorting.Location = new System.Drawing.Point(8, 24);
            this.lblSorting.Name = "lblSorting";
            this.lblSorting.Size = new System.Drawing.Size(100, 23);
            this.lblSorting.TabIndex = 0;
            this.lblSorting.Text = "Classificazione 1:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox7);
            this.tabPage3.Controls.Add(this.groupBox6);
            this.tabPage3.Controls.Add(this.textBox2);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.textBox1);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.txtGiornoScad);
            this.tabPage3.Controls.Add(this.labDay);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(547, 404);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "REA";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.radioButton7);
            this.groupBox7.Controls.Add(this.radioButton9);
            this.groupBox7.Location = new System.Drawing.Point(19, 178);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(318, 50);
            this.groupBox7.TabIndex = 52;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Stato liquidazione";
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(159, 19);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(134, 17);
            this.radioButton7.TabIndex = 49;
            this.radioButton7.Tag = "uniconfig.rea_closingstatus:LN";
            this.radioButton7.Text = "Non in liquidazione(LN)";
            this.radioButton7.UseVisualStyleBackColor = true;
            // 
            // radioButton9
            // 
            this.radioButton9.AutoSize = true;
            this.radioButton9.Location = new System.Drawing.Point(6, 19);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(116, 17);
            this.radioButton9.TabIndex = 47;
            this.radioButton9.Tag = "uniconfig.rea_closingstatus:LS";
            this.radioButton9.Text = "Iin liquidazione (LS)";
            this.radioButton9.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.radioButton5);
            this.groupBox6.Controls.Add(this.radioButton6);
            this.groupBox6.Controls.Add(this.rdbBeniintra12);
            this.groupBox6.Location = new System.Drawing.Point(19, 122);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(318, 50);
            this.groupBox6.TabIndex = 51;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Socio Unico";
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(96, 19);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(107, 17);
            this.radioButton5.TabIndex = 49;
            this.radioButton5.Tag = "uniconfig.rea_partner:SU";
            this.radioButton5.Text = "Socio Unico (SU)";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(209, 19);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(99, 17);
            this.radioButton6.TabIndex = 50;
            this.radioButton6.Tag = "uniconfig.rea_partner:X";
            this.radioButton6.Text = "Non specificato";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // rdbBeniintra12
            // 
            this.rdbBeniintra12.AutoSize = true;
            this.rdbBeniintra12.Location = new System.Drawing.Point(6, 19);
            this.rdbBeniintra12.Name = "rdbBeniintra12";
            this.rdbBeniintra12.Size = new System.Drawing.Size(84, 17);
            this.rdbBeniintra12.TabIndex = 47;
            this.rdbBeniintra12.Tag = "uniconfig.rea_partner:SM";
            this.rdbBeniintra12.Text = "Più soci(SM)";
            this.rdbBeniintra12.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(136, 96);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(127, 20);
            this.textBox2.TabIndex = 7;
            this.textBox2.Tag = "uniconfig.rea_socialcapital";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(20, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 16);
            this.label6.TabIndex = 8;
            this.label6.Tag = "n";
            this.label6.Text = "Capitale Sociale";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(136, 71);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(127, 20);
            this.textBox1.TabIndex = 5;
            this.textBox1.Tag = "uniconfig.rea_number";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(20, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 16);
            this.label5.TabIndex = 6;
            this.label5.Tag = "n";
            this.label5.Text = "Numero REA:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGiornoScad
            // 
            this.txtGiornoScad.Location = new System.Drawing.Point(136, 46);
            this.txtGiornoScad.Name = "txtGiornoScad";
            this.txtGiornoScad.Size = new System.Drawing.Size(48, 20);
            this.txtGiornoScad.TabIndex = 3;
            this.txtGiornoScad.Tag = "uniconfig.rea_provinceoffice";
            // 
            // labDay
            // 
            this.labDay.Location = new System.Drawing.Point(20, 46);
            this.labDay.Name = "labDay";
            this.labDay.Size = new System.Drawing.Size(96, 16);
            this.labDay.TabIndex = 4;
            this.labDay.Text = "Ufficio (provincia):";
            this.labDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Frm_uniconfig_default
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnAnnulla;
            this.ClientSize = new System.Drawing.Size(578, 482);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Frm_uniconfig_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmuniconfigfasi";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.researchagency.ResumeLayout(false);
            this.researchagency.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox25.ResumeLayout(false);
            this.groupBox25.PerformLayout();
            this.groupBox26.ResumeLayout(false);
            this.groupBox26.PerformLayout();
            this.groupBox27.ResumeLayout(false);
            this.groupBox27.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

         
        public void MetaData_AfterLink () {

            Meta = MetaData.GetMetaData(this);
            int numrighe = Meta.Conn.RUN_SELECT_COUNT("uniconfig", null, true);
            if (numrighe == 1) {
                CanGoInsert = false;
                CanGoEdit = true;
            }
            else {
                CanGoInsert = true;
                CanGoEdit = false;
            }
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            //string filterCT = QHS.CmpEq("tablename", "upb");
     
            //GetData.CacheTable(DS.sortingapplicabilityview, filterCT, null, true);

            DataAccess.SetTableForReading(DS.incomephase_fin, "incomephase");
            DataAccess.SetTableForReading(DS.incomephase_registry, "incomephase");
            DataAccess.SetTableForReading(DS.expensephase_fin, "expensephase");
            DataAccess.SetTableForReading(DS.expensephase_registry, "expensephase");

            //DEFAULT FUNZIONI OBIETTIVO
            DataAccess.SetTableForReading(DS.sortingkind1, "sortingkind");
            DataAccess.SetTableForReading(DS.sortingkind2, "sortingkind");
            DataAccess.SetTableForReading(DS.sortingkind3, "sortingkind");
            DataAccess.SetTableForReading(DS.sortingkind4, "sortingkind");
            DataAccess.SetTableForReading(DS.sortingkind5, "sortingkind");

         
            HelpForm.SetDenyNull(DS.uniconfig.Columns["sorkind01asfilter"], true);
            HelpForm.SetDenyNull(DS.uniconfig.Columns["sorkind02asfilter"], true);
            HelpForm.SetDenyNull(DS.uniconfig.Columns["sorkind03asfilter"], true);
            HelpForm.SetDenyNull(DS.uniconfig.Columns["sorkind04asfilter"], true);
            HelpForm.SetDenyNull(DS.uniconfig.Columns["sorkind05asfilter"], true);

            HelpForm.SetDenyNull(DS.uniconfig.Columns["tree_upb_withdescr"], true);

            DS.incomephase_fin.ExtendedProperties["sort_by"] = "nphase";
            DS.incomephase_registry.ExtendedProperties["sort_by"] = "nphase";
            DS.expensephase_fin.ExtendedProperties["sort_by"] = "nphase";
            DS.expensephase_registry.ExtendedProperties["sort_by"] = "nphase";
                
            Meta.SearchEnabled = false;
            Meta.CanInsertCopy = false;
            Meta.CanInsert = false;
            Meta.CanCancel = false;
        }

        public void MetaData_AfterClear () {
            if (CanGoInsert) {
                CanGoInsert = false;
                MetaData.DoMainCommand(this, "maininsert");
            }
            if (CanGoEdit) {
                CanGoEdit = false;
                MetaData.DoMainCommand(this, "maindosearch.default"); //edyttype associato
            }


        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e) {

        }
    }
}
