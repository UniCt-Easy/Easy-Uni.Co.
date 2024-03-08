
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
using metaeasylibrary;
//using MenuUpdate;//MenuUpdate

namespace uniconfig_default
{
	/// <summary>
	/// Summary description for frmfasespesa.
	/// </summary>
    public class Frm_uniconfig_default : MetaDataForm {
        private System.Windows.Forms.ImageList images;
        public vistaForm DS;
        private Button btnAnnulla;
        private Button btnOK;
		private System.ComponentModel.IContainer components;
        bool CanGoEdit;
        bool CanGoInsert;
        private TabControl tabMain;
        private TabPage tabPageFasi;
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
        private TabPage tabPageAttributi;
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
        private TabPage tabPageREA;
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
		private TabPage tabPagePerla;
		private TextBox textBox3;
		private Label label7;
		private TextBox textBox6;
		private Label label10;
		private TextBox textBox5;
		private Label label9;
		private TextBox textBox4;
		private Label label8;
		private TabPage tabPageWeb;
		private TextBox txtWebProt;
		private Label label11;
		private CheckBox checkBox7;
		private TabPage tabPageAllegati;
		private TextBox txtAttachmentMaxSize;
		private Label label12;
        private TabPage tabPagePassword;
        private CheckBox chkRequireUppercase;
        private CheckBox chkRequireLowercase;
        private CheckBox chkRequireNonAlphanumeric;
        private TextBox txtRequiredUniqueChars;
        private TextBox txtRequiredLength;
        private Label lblRequiredUniqueChars;
        private Label lblRequiredLength;
        private CheckBox chkRequireDigit;
		private CheckBox chkTableRegistryCSA;
        private CheckBox chkEnableEmisti;
		private GroupBox grpWebServicePerla;
		private TextBox textBox7;
		private TextBox textBox8;
		private Label label13;
		private Label label14;
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
			this.tabMain = new System.Windows.Forms.TabControl();
			this.tabPageFasi = new System.Windows.Forms.TabPage();
			this.chkEnableEmisti = new System.Windows.Forms.CheckBox();
			this.chkTableRegistryCSA = new System.Windows.Forms.CheckBox();
			this.checkBox7 = new System.Windows.Forms.CheckBox();
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
			this.tabPageAttributi = new System.Windows.Forms.TabPage();
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
			this.tabPageREA = new System.Windows.Forms.TabPage();
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
			this.tabPagePerla = new System.Windows.Forms.TabPage();
			this.grpWebServicePerla = new System.Windows.Forms.GroupBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.tabPageWeb = new System.Windows.Forms.TabPage();
			this.txtWebProt = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.tabPageAllegati = new System.Windows.Forms.TabPage();
			this.txtAttachmentMaxSize = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.tabPagePassword = new System.Windows.Forms.TabPage();
			this.chkRequireDigit = new System.Windows.Forms.CheckBox();
			this.lblRequiredUniqueChars = new System.Windows.Forms.Label();
			this.lblRequiredLength = new System.Windows.Forms.Label();
			this.chkRequireUppercase = new System.Windows.Forms.CheckBox();
			this.chkRequireLowercase = new System.Windows.Forms.CheckBox();
			this.chkRequireNonAlphanumeric = new System.Windows.Forms.CheckBox();
			this.txtRequiredUniqueChars = new System.Windows.Forms.TextBox();
			this.txtRequiredLength = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.tabMain.SuspendLayout();
			this.tabPageFasi.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.researchagency.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.tabPageAttributi.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox25.SuspendLayout();
			this.groupBox26.SuspendLayout();
			this.groupBox27.SuspendLayout();
			this.tabPageREA.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.tabPagePerla.SuspendLayout();
			this.grpWebServicePerla.SuspendLayout();
			this.tabPageWeb.SuspendLayout();
			this.tabPageAllegati.SuspendLayout();
			this.tabPagePassword.SuspendLayout();
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
			this.btnAnnulla.Location = new System.Drawing.Point(602, 587);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(75, 24);
			this.btnAnnulla.TabIndex = 5;
			this.btnAnnulla.Text = "Annulla";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(522, 587);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 24);
			this.btnOK.TabIndex = 4;
			this.btnOK.Tag = "mainsave";
			this.btnOK.Text = "OK";
			// 
			// tabMain
			// 
			this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabMain.Controls.Add(this.tabPageFasi);
			this.tabMain.Controls.Add(this.tabPageAttributi);
			this.tabMain.Controls.Add(this.tabPageREA);
			this.tabMain.Controls.Add(this.tabPagePerla);
			this.tabMain.Controls.Add(this.tabPageWeb);
			this.tabMain.Controls.Add(this.tabPageAllegati);
			this.tabMain.Controls.Add(this.tabPagePassword);
			this.tabMain.Location = new System.Drawing.Point(12, 12);
			this.tabMain.Name = "tabMain";
			this.tabMain.SelectedIndex = 0;
			this.tabMain.Size = new System.Drawing.Size(665, 498);
			this.tabMain.TabIndex = 6;
			this.tabMain.Tag = "";
			// 
			// tabPageFasi
			// 
			this.tabPageFasi.BackColor = System.Drawing.Color.Transparent;
			this.tabPageFasi.Controls.Add(this.chkEnableEmisti);
			this.tabPageFasi.Controls.Add(this.chkTableRegistryCSA);
			this.tabPageFasi.Controls.Add(this.checkBox7);
			this.tabPageFasi.Controls.Add(this.checkBox6);
			this.tabPageFasi.Controls.Add(this.checkBox5);
			this.tabPageFasi.Controls.Add(this.groupBox5);
			this.tabPageFasi.Controls.Add(this.checkBox4);
			this.tabPageFasi.Controls.Add(this.checkBox3);
			this.tabPageFasi.Controls.Add(this.checkBox2);
			this.tabPageFasi.Controls.Add(this.checkBox1);
			this.tabPageFasi.Controls.Add(this.researchagency);
			this.tabPageFasi.Controls.Add(this.groupBox1);
			this.tabPageFasi.Controls.Add(this.groupBox2);
			this.tabPageFasi.Location = new System.Drawing.Point(4, 22);
			this.tabPageFasi.Name = "tabPageFasi";
			this.tabPageFasi.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageFasi.Size = new System.Drawing.Size(657, 472);
			this.tabPageFasi.TabIndex = 0;
			this.tabPageFasi.Text = "Fasi";
			this.tabPageFasi.UseVisualStyleBackColor = true;
			// 
			// chkEnableEmisti
			// 
			this.chkEnableEmisti.AutoSize = true;
			this.chkEnableEmisti.Location = new System.Drawing.Point(15, 443);
			this.chkEnableEmisti.Name = "chkEnableEmisti";
			this.chkEnableEmisti.Size = new System.Drawing.Size(199, 17);
			this.chkEnableEmisti.TabIndex = 17;
			this.chkEnableEmisti.Tag = "uniconfig.flag:6";
			this.chkEnableEmisti.Text = "Abilita importazione da Emisti su CSA";
			this.chkEnableEmisti.UseVisualStyleBackColor = true;
			// 
			// chkTableRegistryCSA
			// 
			this.chkTableRegistryCSA.AutoSize = true;
			this.chkTableRegistryCSA.Location = new System.Drawing.Point(15, 420);
			this.chkTableRegistryCSA.Name = "chkTableRegistryCSA";
			this.chkTableRegistryCSA.Size = new System.Drawing.Size(599, 17);
			this.chkTableRegistryCSA.TabIndex = 16;
			this.chkTableRegistryCSA.Tag = "uniconfig.flag:5";
			this.chkTableRegistryCSA.Text = "Non valorizzare le tabelle: Anagrafica docenti, Anagrafica amministrativi e contr" +
    "atto nella \"Importazione anagrafiche CSA\".";
			this.chkTableRegistryCSA.UseVisualStyleBackColor = true;
			// 
			// checkBox7
			// 
			this.checkBox7.AutoSize = true;
			this.checkBox7.Location = new System.Drawing.Point(15, 397);
			this.checkBox7.Name = "checkBox7";
			this.checkBox7.Size = new System.Drawing.Size(297, 17);
			this.checkBox7.TabIndex = 15;
			this.checkBox7.Tag = "uniconfig.flag:4";
			this.checkBox7.Text = "Obbliga abbinamento accertamenti su impegni in p. di giro";
			this.checkBox7.UseVisualStyleBackColor = true;
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
			this.groupBox1.Size = new System.Drawing.Size(628, 69);
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
			this.cmbExpenseFin.Size = new System.Drawing.Size(420, 21);
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
			this.cmbExpenseRegistry.Size = new System.Drawing.Size(420, 21);
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
			this.groupBox2.Size = new System.Drawing.Size(628, 72);
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
			this.cmbIncomeFin.Size = new System.Drawing.Size(420, 21);
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
			this.cmbIncomeRegistry.Size = new System.Drawing.Size(420, 21);
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
			// tabPageAttributi
			// 
			this.tabPageAttributi.BackColor = System.Drawing.Color.Transparent;
			this.tabPageAttributi.Controls.Add(this.groupBox4);
			this.tabPageAttributi.Controls.Add(this.groupBox3);
			this.tabPageAttributi.Controls.Add(this.groupBox25);
			this.tabPageAttributi.Controls.Add(this.groupBox26);
			this.tabPageAttributi.Controls.Add(this.groupBox27);
			this.tabPageAttributi.Location = new System.Drawing.Point(4, 22);
			this.tabPageAttributi.Name = "tabPageAttributi";
			this.tabPageAttributi.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageAttributi.Size = new System.Drawing.Size(657, 472);
			this.tabPageAttributi.TabIndex = 1;
			this.tabPageAttributi.Text = " Attributi";
			this.tabPageAttributi.UseVisualStyleBackColor = true;
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
			// tabPageREA
			// 
			this.tabPageREA.Controls.Add(this.groupBox7);
			this.tabPageREA.Controls.Add(this.groupBox6);
			this.tabPageREA.Controls.Add(this.textBox2);
			this.tabPageREA.Controls.Add(this.label6);
			this.tabPageREA.Controls.Add(this.textBox1);
			this.tabPageREA.Controls.Add(this.label5);
			this.tabPageREA.Controls.Add(this.txtGiornoScad);
			this.tabPageREA.Controls.Add(this.labDay);
			this.tabPageREA.Location = new System.Drawing.Point(4, 22);
			this.tabPageREA.Name = "tabPageREA";
			this.tabPageREA.Size = new System.Drawing.Size(657, 472);
			this.tabPageREA.TabIndex = 2;
			this.tabPageREA.Text = "REA";
			this.tabPageREA.UseVisualStyleBackColor = true;
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
			// tabPagePerla
			// 
			this.tabPagePerla.Controls.Add(this.grpWebServicePerla);
			this.tabPagePerla.Controls.Add(this.textBox6);
			this.tabPagePerla.Controls.Add(this.label10);
			this.tabPagePerla.Controls.Add(this.textBox5);
			this.tabPagePerla.Controls.Add(this.label9);
			this.tabPagePerla.Controls.Add(this.textBox4);
			this.tabPagePerla.Controls.Add(this.label8);
			this.tabPagePerla.Controls.Add(this.textBox3);
			this.tabPagePerla.Controls.Add(this.label7);
			this.tabPagePerla.Location = new System.Drawing.Point(4, 22);
			this.tabPagePerla.Name = "tabPagePerla";
			this.tabPagePerla.Padding = new System.Windows.Forms.Padding(3);
			this.tabPagePerla.Size = new System.Drawing.Size(657, 472);
			this.tabPagePerla.TabIndex = 3;
			this.tabPagePerla.Text = "Perla";
			this.tabPagePerla.UseVisualStyleBackColor = true;
			// 
			// grpWebServicePerla
			// 
			this.grpWebServicePerla.Controls.Add(this.label13);
			this.grpWebServicePerla.Controls.Add(this.label14);
			this.grpWebServicePerla.Controls.Add(this.textBox7);
			this.grpWebServicePerla.Controls.Add(this.textBox8);
			this.grpWebServicePerla.Location = new System.Drawing.Point(25, 232);
			this.grpWebServicePerla.Name = "grpWebServicePerla";
			this.grpWebServicePerla.Size = new System.Drawing.Size(356, 145);
			this.grpWebServicePerla.TabIndex = 12;
			this.grpWebServicePerla.TabStop = false;
			this.grpWebServicePerla.Text = "WebService PerlaPa";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(6, 84);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(181, 13);
			this.label13.TabIndex = 17;
			this.label13.Text = "Password WS - Secretid per AdP 2.0";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(6, 33);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(153, 13);
			this.label14.TabIndex = 16;
			this.label14.Text = " Login WS - AppId per AdP 2.0";
			// 
			// textBox7
			// 
			this.textBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox7.Location = new System.Drawing.Point(6, 100);
			this.textBox7.Name = "textBox7";
			this.textBox7.PasswordChar = '*';
			this.textBox7.Size = new System.Drawing.Size(344, 20);
			this.textBox7.TabIndex = 15;
			this.textBox7.Tag = "uniconfig.perla_pwd";
			// 
			// textBox8
			// 
			this.textBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox8.Location = new System.Drawing.Point(6, 49);
			this.textBox8.Name = "textBox8";
			this.textBox8.PasswordChar = '*';
			this.textBox8.Size = new System.Drawing.Size(344, 20);
			this.textBox8.TabIndex = 13;
			this.textBox8.Tag = "uniconfig.perla_user";
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(25, 196);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(356, 20);
			this.textBox6.TabIndex = 7;
			this.textBox6.Tag = "uniconfig.perla_codiceuopa";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(22, 180);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(68, 13);
			this.label10.TabIndex = 6;
			this.label10.Text = "codiceUoIpa";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(25, 146);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(356, 20);
			this.textBox5.TabIndex = 5;
			this.textBox5.Tag = "uniconfig.perla_codiceaoopa";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(22, 130);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(73, 13);
			this.label9.TabIndex = 4;
			this.label9.Text = "codiceAooIpa";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(25, 88);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(356, 20);
			this.textBox4.TabIndex = 3;
			this.textBox4.Tag = "uniconfig.perla_codicepaipa";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(22, 72);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(67, 13);
			this.label8.TabIndex = 2;
			this.label8.Text = "codicePaIpa";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(25, 35);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(356, 20);
			this.textBox3.TabIndex = 1;
			this.textBox3.Tag = "uniconfig.perla_codicefiscalepa";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(22, 19);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(85, 13);
			this.label7.TabIndex = 0;
			this.label7.Text = "codiceFiscalePa";
			// 
			// tabPageWeb
			// 
			this.tabPageWeb.Controls.Add(this.txtWebProt);
			this.tabPageWeb.Controls.Add(this.label11);
			this.tabPageWeb.Location = new System.Drawing.Point(4, 22);
			this.tabPageWeb.Name = "tabPageWeb";
			this.tabPageWeb.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageWeb.Size = new System.Drawing.Size(657, 472);
			this.tabPageWeb.TabIndex = 4;
			this.tabPageWeb.Text = "Web";
			this.tabPageWeb.UseVisualStyleBackColor = true;
			// 
			// txtWebProt
			// 
			this.txtWebProt.Location = new System.Drawing.Point(9, 30);
			this.txtWebProt.Name = "txtWebProt";
			this.txtWebProt.Size = new System.Drawing.Size(511, 20);
			this.txtWebProt.TabIndex = 1;
			this.txtWebProt.Tag = "uniconfig.webprotaddress";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(6, 14);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(159, 13);
			this.label11.TabIndex = 0;
			this.label11.Text = "Indirizzo servizio Protocollo Easy";
			// 
			// tabPageAllegati
			// 
			this.tabPageAllegati.Controls.Add(this.txtAttachmentMaxSize);
			this.tabPageAllegati.Controls.Add(this.label12);
			this.tabPageAllegati.Location = new System.Drawing.Point(4, 22);
			this.tabPageAllegati.Name = "tabPageAllegati";
			this.tabPageAllegati.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageAllegati.Size = new System.Drawing.Size(657, 472);
			this.tabPageAllegati.TabIndex = 5;
			this.tabPageAllegati.Text = "Allegati";
			this.tabPageAllegati.UseVisualStyleBackColor = true;
			// 
			// txtAttachmentMaxSize
			// 
			this.txtAttachmentMaxSize.Location = new System.Drawing.Point(242, 17);
			this.txtAttachmentMaxSize.Name = "txtAttachmentMaxSize";
			this.txtAttachmentMaxSize.Size = new System.Drawing.Size(49, 20);
			this.txtAttachmentMaxSize.TabIndex = 1;
			this.txtAttachmentMaxSize.Tag = "uniconfig.attachment_max_size_mb";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(18, 19);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(196, 13);
			this.label12.TabIndex = 0;
			this.label12.Text = "Dimensione massima degli allegati in MB";
			// 
			// tabPagePassword
			// 
			this.tabPagePassword.Controls.Add(this.chkRequireDigit);
			this.tabPagePassword.Controls.Add(this.lblRequiredUniqueChars);
			this.tabPagePassword.Controls.Add(this.lblRequiredLength);
			this.tabPagePassword.Controls.Add(this.chkRequireUppercase);
			this.tabPagePassword.Controls.Add(this.chkRequireLowercase);
			this.tabPagePassword.Controls.Add(this.chkRequireNonAlphanumeric);
			this.tabPagePassword.Controls.Add(this.txtRequiredUniqueChars);
			this.tabPagePassword.Controls.Add(this.txtRequiredLength);
			this.tabPagePassword.Location = new System.Drawing.Point(4, 22);
			this.tabPagePassword.Name = "tabPagePassword";
			this.tabPagePassword.Size = new System.Drawing.Size(657, 472);
			this.tabPagePassword.TabIndex = 6;
			this.tabPagePassword.Text = "Password";
			this.tabPagePassword.UseVisualStyleBackColor = true;
			// 
			// chkRequireDigit
			// 
			this.chkRequireDigit.AutoSize = true;
			this.chkRequireDigit.Location = new System.Drawing.Point(38, 265);
			this.chkRequireDigit.Name = "chkRequireDigit";
			this.chkRequireDigit.Size = new System.Drawing.Size(189, 17);
			this.chkRequireDigit.TabIndex = 7;
			this.chkRequireDigit.Tag = "uniconfig.pwd_requiredigit:S:N";
			this.chkRequireDigit.Text = "Richiedi almeno una cifra (numero)";
			this.chkRequireDigit.UseVisualStyleBackColor = true;
			// 
			// lblRequiredUniqueChars
			// 
			this.lblRequiredUniqueChars.AutoSize = true;
			this.lblRequiredUniqueChars.Location = new System.Drawing.Point(35, 94);
			this.lblRequiredUniqueChars.Name = "lblRequiredUniqueChars";
			this.lblRequiredUniqueChars.Size = new System.Drawing.Size(159, 13);
			this.lblRequiredUniqueChars.TabIndex = 6;
			this.lblRequiredUniqueChars.Text = "Numero di caratteri unici richiesti";
			// 
			// lblRequiredLength
			// 
			this.lblRequiredLength.AutoSize = true;
			this.lblRequiredLength.Location = new System.Drawing.Point(35, 49);
			this.lblRequiredLength.Name = "lblRequiredLength";
			this.lblRequiredLength.Size = new System.Drawing.Size(132, 13);
			this.lblRequiredLength.TabIndex = 5;
			this.lblRequiredLength.Text = "Lunghezza della password";
			// 
			// chkRequireUppercase
			// 
			this.chkRequireUppercase.AutoSize = true;
			this.chkRequireUppercase.Location = new System.Drawing.Point(38, 229);
			this.chkRequireUppercase.Name = "chkRequireUppercase";
			this.chkRequireUppercase.Size = new System.Drawing.Size(172, 17);
			this.chkRequireUppercase.TabIndex = 4;
			this.chkRequireUppercase.Tag = "uniconfig.pwd_requireuppercase:S:N";
			this.chkRequireUppercase.Text = "Richiedi almeno una maiuscola";
			this.chkRequireUppercase.UseVisualStyleBackColor = true;
			// 
			// chkRequireLowercase
			// 
			this.chkRequireLowercase.AutoSize = true;
			this.chkRequireLowercase.Location = new System.Drawing.Point(38, 193);
			this.chkRequireLowercase.Name = "chkRequireLowercase";
			this.chkRequireLowercase.Size = new System.Drawing.Size(172, 17);
			this.chkRequireLowercase.TabIndex = 3;
			this.chkRequireLowercase.Tag = "uniconfig.pwd_requirelowercase:S:N";
			this.chkRequireLowercase.Text = "Richiedi almeno una minuscola";
			this.chkRequireLowercase.UseVisualStyleBackColor = true;
			// 
			// chkRequireNonAlphanumeric
			// 
			this.chkRequireNonAlphanumeric.AutoSize = true;
			this.chkRequireNonAlphanumeric.Location = new System.Drawing.Point(38, 158);
			this.chkRequireNonAlphanumeric.Name = "chkRequireNonAlphanumeric";
			this.chkRequireNonAlphanumeric.Size = new System.Drawing.Size(392, 17);
			this.chkRequireNonAlphanumeric.TabIndex = 2;
			this.chkRequireNonAlphanumeric.Tag = "uniconfig.pwd_requirenonalphanumeric:S:N";
			this.chkRequireNonAlphanumeric.Text = "Richiedi caratteri non alfanumerici (caratteri speciali - per esempio !, \", £, $," +
    " ...)";
			this.chkRequireNonAlphanumeric.UseVisualStyleBackColor = true;
			// 
			// txtRequiredUniqueChars
			// 
			this.txtRequiredUniqueChars.Location = new System.Drawing.Point(200, 91);
			this.txtRequiredUniqueChars.Name = "txtRequiredUniqueChars";
			this.txtRequiredUniqueChars.Size = new System.Drawing.Size(100, 20);
			this.txtRequiredUniqueChars.TabIndex = 1;
			this.txtRequiredUniqueChars.Tag = "uniconfig.pwd_requireduniquechars";
			// 
			// txtRequiredLength
			// 
			this.txtRequiredLength.Location = new System.Drawing.Point(200, 46);
			this.txtRequiredLength.Name = "txtRequiredLength";
			this.txtRequiredLength.Size = new System.Drawing.Size(100, 20);
			this.txtRequiredLength.TabIndex = 0;
			this.txtRequiredLength.Tag = "uniconfig.pwd_requiredlength";
			// 
			// Frm_uniconfig_default
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnAnnulla;
			this.ClientSize = new System.Drawing.Size(689, 622);
			this.Controls.Add(this.tabMain);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "Frm_uniconfig_default";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmuniconfigfasi";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.tabMain.ResumeLayout(false);
			this.tabPageFasi.ResumeLayout(false);
			this.tabPageFasi.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.researchagency.ResumeLayout(false);
			this.researchagency.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.tabPageAttributi.ResumeLayout(false);
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
			this.tabPageREA.ResumeLayout(false);
			this.tabPageREA.PerformLayout();
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.tabPagePerla.ResumeLayout(false);
			this.tabPagePerla.PerformLayout();
			this.grpWebServicePerla.ResumeLayout(false);
			this.grpWebServicePerla.PerformLayout();
			this.tabPageWeb.ResumeLayout(false);
			this.tabPageWeb.PerformLayout();
			this.tabPageAllegati.ResumeLayout(false);
			this.tabPageAllegati.PerformLayout();
			this.tabPagePassword.ResumeLayout(false);
			this.tabPagePassword.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion

         
        public void MetaData_AfterLink () {

            Meta = MetaData.GetMetaData(this);

            if (Meta.editType == "pwd_config")
                foreach(TabPage tp in tabMain.TabPages)
                    if (tp.Name != "tabPagePassword") tabMain.TabPages.Remove(tp);

            if (Meta.editType == "default")
                foreach (TabPage tp in tabMain.TabPages)
                    if (tp.Name == "tabPagePassword") tabMain.TabPages.Remove(tp);

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

            HelpForm.SetDenyNull(DS.uniconfig.Columns["pwd_requiredlength"], true);
            HelpForm.SetDenyNull(DS.uniconfig.Columns["pwd_requireduniquechars"], true);
            HelpForm.SetDenyNull(DS.uniconfig.Columns["pwd_requirenonalphanumeric"], true);
            HelpForm.SetDenyNull(DS.uniconfig.Columns["pwd_requirelowercase"], true);
            HelpForm.SetDenyNull(DS.uniconfig.Columns["pwd_requireuppercase"], true);
            HelpForm.SetDenyNull(DS.uniconfig.Columns["pwd_requiredigit"], true);

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
