
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
using funzioni_configurazione;

namespace invoicekind_default {//tipodocumentoiva//
	/// <summary>
	/// Summary description for frmtipodocumentoiva.
	/// </summary>
    public class Frm_invoicekind_default : MetaDataForm {
        private System.Windows.Forms.ImageList images;
		public vistaForm DS;
        private System.ComponentModel.IContainer components;
        private TabControl tabControl1;
        private TabPage tabGenerale;
        private ListView listView1;
        private GroupBox groupBox20;
        private RadioButton radioButton3;
        private RadioButton radioButton4;
        private GroupBox groupBox1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private CheckBox checkBox1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private TabPage tabEP;
        private GroupBox groupBox2;
        private GroupBox groupBox7;
        private TextBox textBox11;
        private TextBox txtCodiceContoUnabatableIntra;
        private Button button7;
        private GroupBox groupBox4;
        private TextBox textBox5;
        private TextBox txtContoUnabatable;
        private Button button4;
        private GroupBox groupBox5;
        private TextBox textBox6;
        private TextBox txtCodiceContodiffIntra;
        private Button button5;
        private GroupBox groupBox6;
        private TextBox textBox8;
        private TextBox txtCodiceContoIntra;
        private Button button6;
        private GroupBox groupBox3;
        private TextBox textBox4;
        private TextBox txtCodiceContoDiscount;
        private Button button3;
        private GroupBox groupBox9;
        private TextBox textBox3;
        private TextBox txtCodiceContodiff;
        private Button button2;
        private GroupBox gboxConto;
        private TextBox txtDenominazioneConto;
        private TextBox txtCodiceConto;
        private Button button1;
        private GroupBox groupBox10;
        private RadioButton radioButton15;
        private RadioButton radioButton16;
        private RadioButton radioButton13;
        private RadioButton radioButton14;
        private RadioButton radioButton11;
        private RadioButton radioButton12;
        private RadioButton radioButton10;
        private RadioButton radioButton9;
        private RadioButton radioButton8;
        private RadioButton radioButton7;
        private RadioButton radioButton6;
        private RadioButton radioButton5;
        private Label label3;
        private Button btnCopyAll;
        private CheckBox checkBox3;
        private Label label4;
        private ComboBox cboTipo_Auto;
        private TabPage tabStampa;
        private TabPage tabAttributi;
        private GroupBox MetaDataDetail1;
        private TextBox textBox7;
        private Label label5;
        private TabControl tabControlReport;
        private TabPage tabPage4;
        private TextBox textBox9;
        private TabPage tabPage5;
        private TextBox textBox10;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TextBox textBox13;
        private TextBox textBox12;
        private TextBox textBox14;
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
        private Label label6;
        private CheckBox chkAutofattura;
        private RichTextBox richTextBox1;
        private ComboBox cmbipa;
        private CheckBox chkSoloPA;
        private CheckBox chkNoPA;
        private Label label47;
        private TextBox txtRiferimentoAmministrazione;
        private TabControl tabControl2;
        private TabPage tabPage6;
        private TabPage tabPage7;
        private TabPage tabPage8;
        private GroupBox groupBox8;
        private TextBox textBox15;
        private TextBox txtCodiceContoSplit;
        private Button button8;
        private GroupBox groupBox11;
        private TextBox textBox17;
        private TextBox txtCodiceContoUnabatableSplit;
        private Button button9;
        private GroupBox groupBox12;
        private TextBox textBox19;
        private TextBox txtCodiceContodiffSplit;
        private Button button10;
        private CheckBox checkBox2;
        private Label label7;
        private CheckBox chkPromiscuo;
		private CheckBox chkProtocollaRU;
		private CheckBox chkFatturaElettronicaEstera;
		MetaData Meta;
		

		public Frm_invoicekind_default() {
			InitializeComponent();
			GetData.CacheTable(DS.ivaregisterkind,null,"description",false);
            HelpForm.SetDenyNull(DS.invoicekind.Columns["flag_autodocnumbering"], true);
            HelpForm.SetDenyNull(DS.invoicekind.Columns["active"], true);
            HelpForm.SetDenyNull(DS.invoicekind.Columns["enable_fe"], true);
			HelpForm.SetDenyNull(DS.invoicekind.Columns["enable_fe_estera"], true);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if(components != null) {
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
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_invoicekind_default));
			this.images = new System.Windows.Forms.ImageList(this.components);
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabGenerale = new System.Windows.Forms.TabPage();
			this.chkFatturaElettronicaEstera = new System.Windows.Forms.CheckBox();
			this.chkProtocollaRU = new System.Windows.Forms.CheckBox();
			this.chkPromiscuo = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.label47 = new System.Windows.Forms.Label();
			this.txtRiferimentoAmministrazione = new System.Windows.Forms.TextBox();
			this.chkNoPA = new System.Windows.Forms.CheckBox();
			this.chkSoloPA = new System.Windows.Forms.CheckBox();
			this.cmbipa = new System.Windows.Forms.ComboBox();
			this.DS = new invoicekind_default.vistaForm();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.chkAutofattura = new System.Windows.Forms.CheckBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.cboTipo_Auto = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.groupBox10 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.radioButton15 = new System.Windows.Forms.RadioButton();
			this.radioButton16 = new System.Windows.Forms.RadioButton();
			this.radioButton13 = new System.Windows.Forms.RadioButton();
			this.radioButton14 = new System.Windows.Forms.RadioButton();
			this.radioButton11 = new System.Windows.Forms.RadioButton();
			this.radioButton12 = new System.Windows.Forms.RadioButton();
			this.radioButton10 = new System.Windows.Forms.RadioButton();
			this.radioButton9 = new System.Windows.Forms.RadioButton();
			this.radioButton8 = new System.Windows.Forms.RadioButton();
			this.radioButton7 = new System.Windows.Forms.RadioButton();
			this.radioButton6 = new System.Windows.Forms.RadioButton();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.listView1 = new System.Windows.Forms.ListView();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox20 = new System.Windows.Forms.GroupBox();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.tabEP = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.tabControl2 = new System.Windows.Forms.TabControl();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.txtCodiceContoDiscount = new System.Windows.Forms.TextBox();
			this.button3 = new System.Windows.Forms.Button();
			this.gboxConto = new System.Windows.Forms.GroupBox();
			this.txtDenominazioneConto = new System.Windows.Forms.TextBox();
			this.txtCodiceConto = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.txtContoUnabatable = new System.Windows.Forms.TextBox();
			this.button4 = new System.Windows.Forms.Button();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.txtCodiceContodiff = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.tabPage7 = new System.Windows.Forms.TabPage();
			this.label7 = new System.Windows.Forms.Label();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.txtCodiceContoIntra = new System.Windows.Forms.TextBox();
			this.button6 = new System.Windows.Forms.Button();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.textBox11 = new System.Windows.Forms.TextBox();
			this.txtCodiceContoUnabatableIntra = new System.Windows.Forms.TextBox();
			this.button7 = new System.Windows.Forms.Button();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.txtCodiceContodiffIntra = new System.Windows.Forms.TextBox();
			this.button5 = new System.Windows.Forms.Button();
			this.tabPage8 = new System.Windows.Forms.TabPage();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.textBox15 = new System.Windows.Forms.TextBox();
			this.txtCodiceContoSplit = new System.Windows.Forms.TextBox();
			this.button8 = new System.Windows.Forms.Button();
			this.groupBox11 = new System.Windows.Forms.GroupBox();
			this.textBox17 = new System.Windows.Forms.TextBox();
			this.txtCodiceContoUnabatableSplit = new System.Windows.Forms.TextBox();
			this.button9 = new System.Windows.Forms.Button();
			this.groupBox12 = new System.Windows.Forms.GroupBox();
			this.textBox19 = new System.Windows.Forms.TextBox();
			this.txtCodiceContodiffSplit = new System.Windows.Forms.TextBox();
			this.button10 = new System.Windows.Forms.Button();
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
			this.tabStampa = new System.Windows.Forms.TabPage();
			this.MetaDataDetail1 = new System.Windows.Forms.GroupBox();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tabControlReport = new System.Windows.Forms.TabControl();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.textBox14 = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.textBox12 = new System.Windows.Forms.TextBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.textBox13 = new System.Windows.Forms.TextBox();
			this.btnCopyAll = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tabGenerale.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox10.SuspendLayout();
			this.groupBox20.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabEP.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.tabControl2.SuspendLayout();
			this.tabPage6.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.gboxConto.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.tabPage7.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.tabPage8.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.groupBox11.SuspendLayout();
			this.groupBox12.SuspendLayout();
			this.tabAttributi.SuspendLayout();
			this.gboxclass05.SuspendLayout();
			this.gboxclass04.SuspendLayout();
			this.gboxclass03.SuspendLayout();
			this.gboxclass02.SuspendLayout();
			this.gboxclass01.SuspendLayout();
			this.tabStampa.SuspendLayout();
			this.MetaDataDetail1.SuspendLayout();
			this.tabControlReport.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
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
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabGenerale);
			this.tabControl1.Controls.Add(this.tabEP);
			this.tabControl1.Controls.Add(this.tabAttributi);
			this.tabControl1.Controls.Add(this.tabStampa);
			this.tabControl1.Location = new System.Drawing.Point(1, 6);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(952, 531);
			this.tabControl1.TabIndex = 0;
			// 
			// tabGenerale
			// 
			this.tabGenerale.Controls.Add(this.chkFatturaElettronicaEstera);
			this.tabGenerale.Controls.Add(this.chkProtocollaRU);
			this.tabGenerale.Controls.Add(this.chkPromiscuo);
			this.tabGenerale.Controls.Add(this.checkBox2);
			this.tabGenerale.Controls.Add(this.label47);
			this.tabGenerale.Controls.Add(this.txtRiferimentoAmministrazione);
			this.tabGenerale.Controls.Add(this.chkNoPA);
			this.tabGenerale.Controls.Add(this.chkSoloPA);
			this.tabGenerale.Controls.Add(this.cmbipa);
			this.tabGenerale.Controls.Add(this.richTextBox1);
			this.tabGenerale.Controls.Add(this.chkAutofattura);
			this.tabGenerale.Controls.Add(this.label6);
			this.tabGenerale.Controls.Add(this.label4);
			this.tabGenerale.Controls.Add(this.cboTipo_Auto);
			this.tabGenerale.Controls.Add(this.label1);
			this.tabGenerale.Controls.Add(this.checkBox3);
			this.tabGenerale.Controls.Add(this.textBox2);
			this.tabGenerale.Controls.Add(this.groupBox10);
			this.tabGenerale.Controls.Add(this.textBox1);
			this.tabGenerale.Controls.Add(this.listView1);
			this.tabGenerale.Controls.Add(this.label2);
			this.tabGenerale.Controls.Add(this.groupBox20);
			this.tabGenerale.Controls.Add(this.checkBox1);
			this.tabGenerale.Controls.Add(this.groupBox1);
			this.tabGenerale.Location = new System.Drawing.Point(4, 22);
			this.tabGenerale.Name = "tabGenerale";
			this.tabGenerale.Padding = new System.Windows.Forms.Padding(3);
			this.tabGenerale.Size = new System.Drawing.Size(944, 505);
			this.tabGenerale.TabIndex = 0;
			this.tabGenerale.Text = "Generale";
			this.tabGenerale.UseVisualStyleBackColor = true;
			// 
			// chkFatturaElettronicaEstera
			// 
			this.chkFatturaElettronicaEstera.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkFatturaElettronicaEstera.AutoSize = true;
			this.chkFatturaElettronicaEstera.Location = new System.Drawing.Point(547, 383);
			this.chkFatturaElettronicaEstera.Name = "chkFatturaElettronicaEstera";
			this.chkFatturaElettronicaEstera.Size = new System.Drawing.Size(242, 17);
			this.chkFatturaElettronicaEstera.TabIndex = 71;
			this.chkFatturaElettronicaEstera.Tag = "invoicekind.enable_fe_estera:S:N";
			this.chkFatturaElettronicaEstera.Text = "Trasmetti fattura acquisto e Autofattura  a SDI";
			this.chkFatturaElettronicaEstera.UseVisualStyleBackColor = true;
			// 
			// chkProtocollaRU
			// 
			this.chkProtocollaRU.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkProtocollaRU.AutoSize = true;
			this.chkProtocollaRU.Location = new System.Drawing.Point(547, 336);
			this.chkProtocollaRU.Name = "chkProtocollaRU";
			this.chkProtocollaRU.Size = new System.Drawing.Size(163, 17);
			this.chkProtocollaRU.TabIndex = 70;
			this.chkProtocollaRU.Tag = "invoicekind.flag:6";
			this.chkProtocollaRU.Text = "Protocolla nel Registro Unico";
			this.chkProtocollaRU.UseVisualStyleBackColor = true;
			// 
			// chkPromiscuo
			// 
			this.chkPromiscuo.AutoSize = true;
			this.chkPromiscuo.Location = new System.Drawing.Point(188, 44);
			this.chkPromiscuo.Name = "chkPromiscuo";
			this.chkPromiscuo.Size = new System.Drawing.Size(75, 17);
			this.chkPromiscuo.TabIndex = 69;
			this.chkPromiscuo.Tag = "invoicekind.flag:1";
			this.chkPromiscuo.Text = "Promiscuo";
			this.chkPromiscuo.UseVisualStyleBackColor = true;
			// 
			// checkBox2
			// 
			this.checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox2.Location = new System.Drawing.Point(547, 353);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(269, 28);
			this.checkBox2.TabIndex = 68;
			this.checkBox2.Tag = "invoicekind.enable_fe:S:N";
			this.checkBox2.Text = "Utilizzabile nella Fattura Elettronica di Acquisto";
			// 
			// label47
			// 
			this.label47.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label47.Location = new System.Drawing.Point(606, 467);
			this.label47.Name = "label47";
			this.label47.Size = new System.Drawing.Size(150, 18);
			this.label47.TabIndex = 66;
			this.label47.Text = "Riferimento amministrazione";
			this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtRiferimentoAmministrazione
			// 
			this.txtRiferimentoAmministrazione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.txtRiferimentoAmministrazione.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtRiferimentoAmministrazione.Location = new System.Drawing.Point(762, 467);
			this.txtRiferimentoAmministrazione.Name = "txtRiferimentoAmministrazione";
			this.txtRiferimentoAmministrazione.Size = new System.Drawing.Size(161, 20);
			this.txtRiferimentoAmministrazione.TabIndex = 65;
			this.txtRiferimentoAmministrazione.Tag = "invoicekind.riferimento_amministrazione";
			// 
			// chkNoPA
			// 
			this.chkNoPA.Location = new System.Drawing.Point(755, 44);
			this.chkNoPA.Name = "chkNoPA";
			this.chkNoPA.Size = new System.Drawing.Size(166, 18);
			this.chkNoPA.TabIndex = 8;
			this.chkNoPA.Tag = "invoicekind.flag:5";
			this.chkNoPA.Text = "escludi anagrafiche con IPA";
			// 
			// chkSoloPA
			// 
			this.chkSoloPA.Location = new System.Drawing.Point(755, 26);
			this.chkSoloPA.Name = "chkSoloPA";
			this.chkSoloPA.Size = new System.Drawing.Size(166, 18);
			this.chkSoloPA.TabIndex = 7;
			this.chkSoloPA.Tag = "invoicekind.flag:4";
			this.chkSoloPA.Text = "solo anagrafiche con IPA";
			// 
			// cmbipa
			// 
			this.cmbipa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbipa.DataSource = this.DS.ipa;
			this.cmbipa.DisplayMember = "officename";
			this.cmbipa.Location = new System.Drawing.Point(548, 440);
			this.cmbipa.Name = "cmbipa";
			this.cmbipa.Size = new System.Drawing.Size(374, 21);
			this.cmbipa.TabIndex = 13;
			this.cmbipa.Tag = "invoicekind.ipa_fe";
			this.cmbipa.ValueMember = "ipa_fe";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// richTextBox1
			// 
			this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBox1.Location = new System.Drawing.Point(544, 408);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(396, 28);
			this.richTextBox1.TabIndex = 64;
			this.richTextBox1.Text = "Codice Univoco Ufficio di PCC o Codice Univoco Ufficio di IPA, prelevato dal sito" +
    " www.indicepa.gov.it.";
			this.richTextBox1.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox1_LinkClicked);
			// 
			// chkAutofattura
			// 
			this.chkAutofattura.Location = new System.Drawing.Point(755, 3);
			this.chkAutofattura.Name = "chkAutofattura";
			this.chkAutofattura.Size = new System.Drawing.Size(166, 24);
			this.chkAutofattura.TabIndex = 6;
			this.chkAutofattura.Tag = "invoicekind.flag:3";
			this.chkAutofattura.Text = "Autofattura";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 114);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(86, 13);
			this.label6.TabIndex = 44;
			this.label6.Text = "Registri associati";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(549, 67);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(134, 13);
			this.label4.TabIndex = 43;
			this.label4.Text = "Tipo autofattura collegata :";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label4.Click += new System.EventHandler(this.label4_Click);
			// 
			// cboTipo_Auto
			// 
			this.cboTipo_Auto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cboTipo_Auto.DataSource = this.DS.invoicekind_auto;
			this.cboTipo_Auto.DisplayMember = "description";
			this.cboTipo_Auto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboTipo_Auto.Location = new System.Drawing.Point(549, 86);
			this.cboTipo_Auto.Name = "cboTipo_Auto";
			this.cboTipo_Auto.Size = new System.Drawing.Size(365, 21);
			this.cboTipo_Auto.TabIndex = 10;
			this.cboTipo_Auto.Tag = "invoicekind.idinvkind_auto";
			this.cboTipo_Auto.ValueMember = "idinvkind";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 18);
			this.label1.TabIndex = 39;
			this.label1.Text = "Codice:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// checkBox3
			// 
			this.checkBox3.Location = new System.Drawing.Point(307, 18);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(71, 24);
			this.checkBox3.TabIndex = 3;
			this.checkBox3.Tag = "invoicekind.active:S:N";
			this.checkBox3.Text = "Attivo";
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.Location = new System.Drawing.Point(6, 68);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(531, 39);
			this.textBox2.TabIndex = 9;
			this.textBox2.Tag = "invoicekind.description";
			// 
			// groupBox10
			// 
			this.groupBox10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox10.Controls.Add(this.label3);
			this.groupBox10.Controls.Add(this.radioButton15);
			this.groupBox10.Controls.Add(this.radioButton16);
			this.groupBox10.Controls.Add(this.radioButton13);
			this.groupBox10.Controls.Add(this.radioButton14);
			this.groupBox10.Controls.Add(this.radioButton11);
			this.groupBox10.Controls.Add(this.radioButton12);
			this.groupBox10.Controls.Add(this.radioButton10);
			this.groupBox10.Controls.Add(this.radioButton9);
			this.groupBox10.Controls.Add(this.radioButton8);
			this.groupBox10.Controls.Add(this.radioButton7);
			this.groupBox10.Controls.Add(this.radioButton6);
			this.groupBox10.Controls.Add(this.radioButton5);
			this.groupBox10.Location = new System.Drawing.Point(547, 124);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new System.Drawing.Size(376, 208);
			this.groupBox10.TabIndex = 12;
			this.groupBox10.TabStop = false;
			this.groupBox10.Tag = "";
			this.groupBox10.Text = "Formato numerazione automatica per fatture di vendita";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(16, 21);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(323, 52);
			this.label3.TabIndex = 12;
			this.label3.Text = "Scegliere se l\'anno deve essere a due o quattro cifre, la posizione di anno e  nu" +
    "mero, la lunghezza minima del numero (quattro, cinque o sei cifre: se necessario" +
    " saranno anteposti degli zeri)";
			// 
			// radioButton15
			// 
			this.radioButton15.AutoSize = true;
			this.radioButton15.Location = new System.Drawing.Point(247, 183);
			this.radioButton15.Name = "radioButton15";
			this.radioButton15.Size = new System.Drawing.Size(90, 17);
			this.radioButton15.TabIndex = 11;
			this.radioButton15.TabStop = true;
			this.radioButton15.Tag = "invoicekind.formatstring:{1:d6}/{0:yyyy}";
			this.radioButton15.Text = "nnnnnn/aaaa";
			this.radioButton15.UseVisualStyleBackColor = true;
			// 
			// radioButton16
			// 
			this.radioButton16.AutoSize = true;
			this.radioButton16.Location = new System.Drawing.Point(247, 159);
			this.radioButton16.Name = "radioButton16";
			this.radioButton16.Size = new System.Drawing.Size(84, 17);
			this.radioButton16.TabIndex = 10;
			this.radioButton16.TabStop = true;
			this.radioButton16.Tag = "invoicekind.formatstring:{1:d5}/{0:yyyy}";
			this.radioButton16.Text = "nnnnn/aaaa";
			this.radioButton16.UseVisualStyleBackColor = true;
			// 
			// radioButton13
			// 
			this.radioButton13.AutoSize = true;
			this.radioButton13.Location = new System.Drawing.Point(247, 129);
			this.radioButton13.Name = "radioButton13";
			this.radioButton13.Size = new System.Drawing.Size(78, 17);
			this.radioButton13.TabIndex = 9;
			this.radioButton13.TabStop = true;
			this.radioButton13.Tag = "invoicekind.formatstring:{1:d4}/{0:yyyy}";
			this.radioButton13.Text = "nnnn/aaaa";
			this.radioButton13.UseVisualStyleBackColor = true;
			// 
			// radioButton14
			// 
			this.radioButton14.AutoSize = true;
			this.radioButton14.Location = new System.Drawing.Point(247, 103);
			this.radioButton14.Name = "radioButton14";
			this.radioButton14.Size = new System.Drawing.Size(90, 17);
			this.radioButton14.TabIndex = 8;
			this.radioButton14.TabStop = true;
			this.radioButton14.Tag = "invoicekind.formatstring:{0:yyyy}/{1:d6}";
			this.radioButton14.Text = "aaaa/nnnnnn";
			this.radioButton14.UseVisualStyleBackColor = true;
			// 
			// radioButton11
			// 
			this.radioButton11.AutoSize = true;
			this.radioButton11.Location = new System.Drawing.Point(128, 181);
			this.radioButton11.Name = "radioButton11";
			this.radioButton11.Size = new System.Drawing.Size(84, 17);
			this.radioButton11.TabIndex = 7;
			this.radioButton11.TabStop = true;
			this.radioButton11.Tag = "invoicekind.formatstring:{0:yyyy}/{1:d5}";
			this.radioButton11.Text = "aaaa/nnnnn";
			this.radioButton11.UseVisualStyleBackColor = true;
			// 
			// radioButton12
			// 
			this.radioButton12.AutoSize = true;
			this.radioButton12.Location = new System.Drawing.Point(128, 153);
			this.radioButton12.Name = "radioButton12";
			this.radioButton12.Size = new System.Drawing.Size(78, 17);
			this.radioButton12.TabIndex = 6;
			this.radioButton12.TabStop = true;
			this.radioButton12.Tag = "invoicekind.formatstring:{0:yyyy}/{1:d4}";
			this.radioButton12.Text = "aaaa/nnnn";
			this.radioButton12.UseVisualStyleBackColor = true;
			// 
			// radioButton10
			// 
			this.radioButton10.AutoSize = true;
			this.radioButton10.Location = new System.Drawing.Point(128, 127);
			this.radioButton10.Name = "radioButton10";
			this.radioButton10.Size = new System.Drawing.Size(78, 17);
			this.radioButton10.TabIndex = 5;
			this.radioButton10.TabStop = true;
			this.radioButton10.Tag = "invoicekind.formatstring:{1:d6}/{0:yy}";
			this.radioButton10.Text = "nnnnnn/aa";
			this.radioButton10.UseVisualStyleBackColor = true;
			// 
			// radioButton9
			// 
			this.radioButton9.AutoSize = true;
			this.radioButton9.Location = new System.Drawing.Point(128, 101);
			this.radioButton9.Name = "radioButton9";
			this.radioButton9.Size = new System.Drawing.Size(72, 17);
			this.radioButton9.TabIndex = 4;
			this.radioButton9.TabStop = true;
			this.radioButton9.Tag = "invoicekind.formatstring:{1:d5}/{0:yy}";
			this.radioButton9.Text = "nnnnn/aa";
			this.radioButton9.UseVisualStyleBackColor = true;
			// 
			// radioButton8
			// 
			this.radioButton8.AutoSize = true;
			this.radioButton8.Location = new System.Drawing.Point(6, 181);
			this.radioButton8.Name = "radioButton8";
			this.radioButton8.Size = new System.Drawing.Size(66, 17);
			this.radioButton8.TabIndex = 3;
			this.radioButton8.TabStop = true;
			this.radioButton8.Tag = "invoicekind.formatstring:{1:d4}/{0:yy}";
			this.radioButton8.Text = "nnnn/aa";
			this.radioButton8.UseVisualStyleBackColor = true;
			// 
			// radioButton7
			// 
			this.radioButton7.AutoSize = true;
			this.radioButton7.Location = new System.Drawing.Point(6, 101);
			this.radioButton7.Name = "radioButton7";
			this.radioButton7.Size = new System.Drawing.Size(66, 17);
			this.radioButton7.TabIndex = 2;
			this.radioButton7.TabStop = true;
			this.radioButton7.Tag = "invoicekind.formatstring:{0:yy}/{1:d4}";
			this.radioButton7.Text = "aa/nnnn";
			this.radioButton7.UseVisualStyleBackColor = true;
			// 
			// radioButton6
			// 
			this.radioButton6.AutoSize = true;
			this.radioButton6.Location = new System.Drawing.Point(6, 157);
			this.radioButton6.Name = "radioButton6";
			this.radioButton6.Size = new System.Drawing.Size(78, 17);
			this.radioButton6.TabIndex = 1;
			this.radioButton6.TabStop = true;
			this.radioButton6.Tag = "invoicekind.formatstring:{0:yy}/{1:d6}";
			this.radioButton6.Text = "aa/nnnnnn";
			this.radioButton6.UseVisualStyleBackColor = true;
			// 
			// radioButton5
			// 
			this.radioButton5.AutoSize = true;
			this.radioButton5.Location = new System.Drawing.Point(6, 127);
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.Size = new System.Drawing.Size(72, 17);
			this.radioButton5.TabIndex = 0;
			this.radioButton5.TabStop = true;
			this.radioButton5.Tag = "invoicekind.formatstring:{0:yy}/{1:d5}";
			this.radioButton5.Text = "aa/nnnnn";
			this.radioButton5.UseVisualStyleBackColor = true;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(7, 24);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(160, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.Tag = "invoicekind.codeinvkind";
			// 
			// listView1
			// 
			this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(7, 130);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(529, 357);
			this.listView1.TabIndex = 11;
			this.listView1.Tag = "ivaregisterkind.default";
			this.listView1.UseCompatibleStateImageBehavior = false;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(7, 47);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 17);
			this.label2.TabIndex = 6;
			this.label2.Text = "Descrizione:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox20
			// 
			this.groupBox20.Controls.Add(this.radioButton3);
			this.groupBox20.Controls.Add(this.radioButton4);
			this.groupBox20.Location = new System.Drawing.Point(565, 8);
			this.groupBox20.Name = "groupBox20";
			this.groupBox20.Size = new System.Drawing.Size(184, 53);
			this.groupBox20.TabIndex = 5;
			this.groupBox20.TabStop = false;
			this.groupBox20.Text = "Numerazione dei documenti ";
			// 
			// radioButton3
			// 
			this.radioButton3.Location = new System.Drawing.Point(8, 14);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(96, 16);
			this.radioButton3.TabIndex = 1;
			this.radioButton3.Tag = "invoicekind.flag_autodocnumbering:N";
			this.radioButton3.Text = "Manuale";
			// 
			// radioButton4
			// 
			this.radioButton4.Location = new System.Drawing.Point(8, 32);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(96, 16);
			this.radioButton4.TabIndex = 2;
			this.radioButton4.Tag = "invoicekind.flag_autodocnumbering:S";
			this.radioButton4.Text = "Automatica";
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(188, 16);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(113, 28);
			this.checkBox1.TabIndex = 2;
			this.checkBox1.Tag = "invoicekind.flag:2";
			this.checkBox1.Text = "Nota di variazione";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButton1);
			this.groupBox1.Controls.Add(this.radioButton2);
			this.groupBox1.Location = new System.Drawing.Point(384, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(160, 56);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Contabilizzazione";
			// 
			// radioButton1
			// 
			this.radioButton1.Location = new System.Drawing.Point(7, 15);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(144, 16);
			this.radioButton1.TabIndex = 1;
			this.radioButton1.TabStop = true;
			this.radioButton1.Tag = "invoicekind.flag::0";
			this.radioButton1.Text = "Movimenti di Entrata";
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(8, 32);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(144, 16);
			this.radioButton2.TabIndex = 2;
			this.radioButton2.TabStop = true;
			this.radioButton2.Tag = "invoicekind.flag::#0";
			this.radioButton2.Text = "Movimenti di Spesa";
			// 
			// tabEP
			// 
			this.tabEP.Controls.Add(this.groupBox2);
			this.tabEP.Location = new System.Drawing.Point(4, 22);
			this.tabEP.Name = "tabEP";
			this.tabEP.Padding = new System.Windows.Forms.Padding(3);
			this.tabEP.Size = new System.Drawing.Size(944, 505);
			this.tabEP.TabIndex = 1;
			this.tabEP.Text = "EP";
			this.tabEP.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.tabControl2);
			this.groupBox2.Location = new System.Drawing.Point(6, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(932, 499);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			// 
			// tabControl2
			// 
			this.tabControl2.Controls.Add(this.tabPage6);
			this.tabControl2.Controls.Add(this.tabPage7);
			this.tabControl2.Controls.Add(this.tabPage8);
			this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl2.Location = new System.Drawing.Point(3, 16);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new System.Drawing.Size(926, 480);
			this.tabControl2.TabIndex = 7;
			// 
			// tabPage6
			// 
			this.tabPage6.Controls.Add(this.groupBox3);
			this.tabPage6.Controls.Add(this.gboxConto);
			this.tabPage6.Controls.Add(this.groupBox4);
			this.tabPage6.Controls.Add(this.groupBox9);
			this.tabPage6.Location = new System.Drawing.Point(4, 22);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage6.Size = new System.Drawing.Size(918, 454);
			this.tabPage6.TabIndex = 0;
			this.tabPage6.Text = "Fatture normali";
			this.tabPage6.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.textBox4);
			this.groupBox3.Controls.Add(this.txtCodiceContoDiscount);
			this.groupBox3.Controls.Add(this.button3);
			this.groupBox3.Location = new System.Drawing.Point(6, 6);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(419, 108);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			this.groupBox3.Tag = "AutoManage.txtCodiceContoDiscount.tree";
			this.groupBox3.Text = "Conto E/P per sconto";
			// 
			// textBox4
			// 
			this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox4.Location = new System.Drawing.Point(134, 19);
			this.textBox4.Multiline = true;
			this.textBox4.Name = "textBox4";
			this.textBox4.ReadOnly = true;
			this.textBox4.Size = new System.Drawing.Size(275, 64);
			this.textBox4.TabIndex = 2;
			this.textBox4.TabStop = false;
			this.textBox4.Tag = "accountdiscount.title";
			// 
			// txtCodiceContoDiscount
			// 
			this.txtCodiceContoDiscount.Location = new System.Drawing.Point(6, 85);
			this.txtCodiceContoDiscount.Name = "txtCodiceContoDiscount";
			this.txtCodiceContoDiscount.Size = new System.Drawing.Size(403, 20);
			this.txtCodiceContoDiscount.TabIndex = 1;
			this.txtCodiceContoDiscount.Tag = "accountdiscount.codeacc?x";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(8, 56);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(120, 23);
			this.button3.TabIndex = 0;
			this.button3.TabStop = false;
			this.button3.Tag = "manage.accountdiscount.tree";
			this.button3.Text = "Conto";
			// 
			// gboxConto
			// 
			this.gboxConto.Controls.Add(this.txtDenominazioneConto);
			this.gboxConto.Controls.Add(this.txtCodiceConto);
			this.gboxConto.Controls.Add(this.button1);
			this.gboxConto.Location = new System.Drawing.Point(6, 114);
			this.gboxConto.Name = "gboxConto";
			this.gboxConto.Size = new System.Drawing.Size(419, 108);
			this.gboxConto.TabIndex = 2;
			this.gboxConto.TabStop = false;
			this.gboxConto.Tag = "AutoManage.txtCodiceConto.tree";
			this.gboxConto.Text = "Conto E/P per iva immediata";
			// 
			// txtDenominazioneConto
			// 
			this.txtDenominazioneConto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenominazioneConto.Location = new System.Drawing.Point(136, 16);
			this.txtDenominazioneConto.Multiline = true;
			this.txtDenominazioneConto.Name = "txtDenominazioneConto";
			this.txtDenominazioneConto.ReadOnly = true;
			this.txtDenominazioneConto.Size = new System.Drawing.Size(273, 60);
			this.txtDenominazioneConto.TabIndex = 2;
			this.txtDenominazioneConto.TabStop = false;
			this.txtDenominazioneConto.Tag = "account.title";
			// 
			// txtCodiceConto
			// 
			this.txtCodiceConto.Location = new System.Drawing.Point(8, 82);
			this.txtCodiceConto.Name = "txtCodiceConto";
			this.txtCodiceConto.Size = new System.Drawing.Size(401, 20);
			this.txtCodiceConto.TabIndex = 1;
			this.txtCodiceConto.Tag = "account.codeacc?x";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(10, 53);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(120, 23);
			this.button1.TabIndex = 0;
			this.button1.TabStop = false;
			this.button1.Tag = "manage.account.tree";
			this.button1.Text = "Conto";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.textBox5);
			this.groupBox4.Controls.Add(this.txtContoUnabatable);
			this.groupBox4.Controls.Add(this.button4);
			this.groupBox4.Location = new System.Drawing.Point(6, 339);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(419, 108);
			this.groupBox4.TabIndex = 4;
			this.groupBox4.TabStop = false;
			this.groupBox4.Tag = "AutoManage.txtContoUnabatable.tree";
			this.groupBox4.Text = "Conto E/P per iva indetraibile";
			// 
			// textBox5
			// 
			this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox5.Location = new System.Drawing.Point(136, 16);
			this.textBox5.Multiline = true;
			this.textBox5.Name = "textBox5";
			this.textBox5.ReadOnly = true;
			this.textBox5.Size = new System.Drawing.Size(275, 52);
			this.textBox5.TabIndex = 2;
			this.textBox5.TabStop = false;
			this.textBox5.Tag = "accountunabatable.title";
			// 
			// txtContoUnabatable
			// 
			this.txtContoUnabatable.Location = new System.Drawing.Point(8, 76);
			this.txtContoUnabatable.Name = "txtContoUnabatable";
			this.txtContoUnabatable.Size = new System.Drawing.Size(403, 20);
			this.txtContoUnabatable.TabIndex = 1;
			this.txtContoUnabatable.Tag = "accountunabatable.codeacc?x";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(6, 45);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(120, 23);
			this.button4.TabIndex = 0;
			this.button4.TabStop = false;
			this.button4.Tag = "manage.accountunabatable.tree";
			this.button4.Text = "Conto";
			// 
			// groupBox9
			// 
			this.groupBox9.Controls.Add(this.textBox3);
			this.groupBox9.Controls.Add(this.txtCodiceContodiff);
			this.groupBox9.Controls.Add(this.button2);
			this.groupBox9.Location = new System.Drawing.Point(6, 226);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(419, 108);
			this.groupBox9.TabIndex = 3;
			this.groupBox9.TabStop = false;
			this.groupBox9.Tag = "AutoManage.txtCodiceContodiff.tree";
			this.groupBox9.Text = "Conto E/P per iva differita";
			// 
			// textBox3
			// 
			this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox3.Location = new System.Drawing.Point(136, 16);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(276, 60);
			this.textBox3.TabIndex = 2;
			this.textBox3.TabStop = false;
			this.textBox3.Tag = "accountdiff.title";
			// 
			// txtCodiceContodiff
			// 
			this.txtCodiceContodiff.Location = new System.Drawing.Point(8, 85);
			this.txtCodiceContodiff.Name = "txtCodiceContodiff";
			this.txtCodiceContodiff.Size = new System.Drawing.Size(405, 20);
			this.txtCodiceContodiff.TabIndex = 1;
			this.txtCodiceContodiff.Tag = "accountdiff.codeacc?x";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(10, 53);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(120, 23);
			this.button2.TabIndex = 0;
			this.button2.TabStop = false;
			this.button2.Tag = "manage.accountdiff.tree";
			this.button2.Text = "Conto";
			// 
			// tabPage7
			// 
			this.tabPage7.Controls.Add(this.label7);
			this.tabPage7.Controls.Add(this.groupBox6);
			this.tabPage7.Controls.Add(this.groupBox7);
			this.tabPage7.Controls.Add(this.groupBox5);
			this.tabPage7.Location = new System.Drawing.Point(4, 22);
			this.tabPage7.Name = "tabPage7";
			this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage7.Size = new System.Drawing.Size(918, 454);
			this.tabPage7.TabIndex = 1;
			this.tabPage7.Text = "Fatture intra-UE ed extra-UE";
			this.tabPage7.UseVisualStyleBackColor = true;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(12, 21);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(497, 20);
			this.label7.TabIndex = 7;
			this.label7.Text = "Sezione da riempire solo per fatture commerciali e promiscue";
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.textBox8);
			this.groupBox6.Controls.Add(this.txtCodiceContoIntra);
			this.groupBox6.Controls.Add(this.button6);
			this.groupBox6.Location = new System.Drawing.Point(14, 44);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(419, 108);
			this.groupBox6.TabIndex = 5;
			this.groupBox6.TabStop = false;
			this.groupBox6.Tag = "AutoManage.txtCodiceContoIntra.tree";
			this.groupBox6.Text = "Conto E/P per iva immediata per la scrittura di segno opposto";
			// 
			// textBox8
			// 
			this.textBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox8.Location = new System.Drawing.Point(134, 16);
			this.textBox8.Multiline = true;
			this.textBox8.Name = "textBox8";
			this.textBox8.ReadOnly = true;
			this.textBox8.Size = new System.Drawing.Size(279, 60);
			this.textBox8.TabIndex = 2;
			this.textBox8.TabStop = false;
			this.textBox8.Tag = "account_intra.title";
			// 
			// txtCodiceContoIntra
			// 
			this.txtCodiceContoIntra.Location = new System.Drawing.Point(8, 82);
			this.txtCodiceContoIntra.Name = "txtCodiceContoIntra";
			this.txtCodiceContoIntra.Size = new System.Drawing.Size(403, 20);
			this.txtCodiceContoIntra.TabIndex = 1;
			this.txtCodiceContoIntra.Tag = "account_intra.codeacc?x";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(8, 53);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(120, 23);
			this.button6.TabIndex = 0;
			this.button6.TabStop = false;
			this.button6.Tag = "manage.account_intra.tree";
			this.button6.Text = "Conto";
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.textBox11);
			this.groupBox7.Controls.Add(this.txtCodiceContoUnabatableIntra);
			this.groupBox7.Controls.Add(this.button7);
			this.groupBox7.Location = new System.Drawing.Point(14, 326);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(419, 108);
			this.groupBox7.TabIndex = 6;
			this.groupBox7.TabStop = false;
			this.groupBox7.Tag = "AutoManage.txtCodiceContoUnabatableIntra.tree";
			this.groupBox7.Text = "Conto E/P per iva indetraibile ";
			// 
			// textBox11
			// 
			this.textBox11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox11.Location = new System.Drawing.Point(136, 16);
			this.textBox11.Multiline = true;
			this.textBox11.Name = "textBox11";
			this.textBox11.ReadOnly = true;
			this.textBox11.Size = new System.Drawing.Size(275, 54);
			this.textBox11.TabIndex = 2;
			this.textBox11.TabStop = false;
			this.textBox11.Tag = "accountunabatable_intra.title";
			// 
			// txtCodiceContoUnabatableIntra
			// 
			this.txtCodiceContoUnabatableIntra.Location = new System.Drawing.Point(8, 76);
			this.txtCodiceContoUnabatableIntra.Name = "txtCodiceContoUnabatableIntra";
			this.txtCodiceContoUnabatableIntra.Size = new System.Drawing.Size(405, 20);
			this.txtCodiceContoUnabatableIntra.TabIndex = 1;
			this.txtCodiceContoUnabatableIntra.Tag = "accountunabatable_intra.codeacc?x";
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(10, 47);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(120, 23);
			this.button7.TabIndex = 0;
			this.button7.TabStop = false;
			this.button7.Tag = "manage.accountunabatable_intra.tree";
			this.button7.Text = "Conto";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.textBox6);
			this.groupBox5.Controls.Add(this.txtCodiceContodiffIntra);
			this.groupBox5.Controls.Add(this.button5);
			this.groupBox5.Location = new System.Drawing.Point(14, 158);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(419, 108);
			this.groupBox5.TabIndex = 6;
			this.groupBox5.TabStop = false;
			this.groupBox5.Tag = "AutoManage.txtCodiceContodiffIntra.tree";
			this.groupBox5.Text = "Conto E/P per iva differita per la scrittura di segno opposto";
			// 
			// textBox6
			// 
			this.textBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox6.Location = new System.Drawing.Point(136, 16);
			this.textBox6.Multiline = true;
			this.textBox6.Name = "textBox6";
			this.textBox6.ReadOnly = true;
			this.textBox6.Size = new System.Drawing.Size(275, 60);
			this.textBox6.TabIndex = 2;
			this.textBox6.TabStop = false;
			this.textBox6.Tag = "accountdiff_intra.title";
			// 
			// txtCodiceContodiffIntra
			// 
			this.txtCodiceContodiffIntra.Location = new System.Drawing.Point(6, 82);
			this.txtCodiceContodiffIntra.Name = "txtCodiceContodiffIntra";
			this.txtCodiceContodiffIntra.Size = new System.Drawing.Size(407, 20);
			this.txtCodiceContodiffIntra.TabIndex = 1;
			this.txtCodiceContodiffIntra.Tag = "accountdiff_intra.codeacc?x";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(10, 53);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(120, 23);
			this.button5.TabIndex = 0;
			this.button5.TabStop = false;
			this.button5.Tag = "manage.accountdiff_intra.tree";
			this.button5.Text = "Conto";
			// 
			// tabPage8
			// 
			this.tabPage8.Controls.Add(this.groupBox8);
			this.tabPage8.Controls.Add(this.groupBox11);
			this.tabPage8.Controls.Add(this.groupBox12);
			this.tabPage8.Location = new System.Drawing.Point(4, 22);
			this.tabPage8.Name = "tabPage8";
			this.tabPage8.Size = new System.Drawing.Size(918, 454);
			this.tabPage8.TabIndex = 2;
			this.tabPage8.Text = "Acquisti commerciali split-payment";
			this.tabPage8.UseVisualStyleBackColor = true;
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.textBox15);
			this.groupBox8.Controls.Add(this.txtCodiceContoSplit);
			this.groupBox8.Controls.Add(this.button8);
			this.groupBox8.Location = new System.Drawing.Point(13, 110);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(419, 108);
			this.groupBox8.TabIndex = 7;
			this.groupBox8.TabStop = false;
			this.groupBox8.Tag = "AutoManage.txtCodiceContoSplit.tree";
			this.groupBox8.Text = "Conto E/P per iva immediata per la scrittura di segno opposto";
			// 
			// textBox15
			// 
			this.textBox15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox15.Location = new System.Drawing.Point(134, 16);
			this.textBox15.Multiline = true;
			this.textBox15.Name = "textBox15";
			this.textBox15.ReadOnly = true;
			this.textBox15.Size = new System.Drawing.Size(279, 60);
			this.textBox15.TabIndex = 2;
			this.textBox15.TabStop = false;
			this.textBox15.Tag = "account_split.title";
			// 
			// txtCodiceContoSplit
			// 
			this.txtCodiceContoSplit.Location = new System.Drawing.Point(8, 82);
			this.txtCodiceContoSplit.Name = "txtCodiceContoSplit";
			this.txtCodiceContoSplit.Size = new System.Drawing.Size(403, 20);
			this.txtCodiceContoSplit.TabIndex = 1;
			this.txtCodiceContoSplit.Tag = "account_split.codeacc?x";
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(8, 53);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(120, 23);
			this.button8.TabIndex = 0;
			this.button8.TabStop = false;
			this.button8.Tag = "manage.account_split.tree";
			this.button8.Text = "Conto";
			// 
			// groupBox11
			// 
			this.groupBox11.Controls.Add(this.textBox17);
			this.groupBox11.Controls.Add(this.txtCodiceContoUnabatableSplit);
			this.groupBox11.Controls.Add(this.button9);
			this.groupBox11.Location = new System.Drawing.Point(13, 338);
			this.groupBox11.Name = "groupBox11";
			this.groupBox11.Size = new System.Drawing.Size(419, 108);
			this.groupBox11.TabIndex = 8;
			this.groupBox11.TabStop = false;
			this.groupBox11.Tag = "AutoManage.txtCodiceContoUnabatableSplit.tree";
			this.groupBox11.Text = "Conto E/P per iva indetraibile ";
			// 
			// textBox17
			// 
			this.textBox17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox17.Location = new System.Drawing.Point(136, 16);
			this.textBox17.Multiline = true;
			this.textBox17.Name = "textBox17";
			this.textBox17.ReadOnly = true;
			this.textBox17.Size = new System.Drawing.Size(275, 54);
			this.textBox17.TabIndex = 2;
			this.textBox17.TabStop = false;
			this.textBox17.Tag = "accountunabatable_split.title";
			// 
			// txtCodiceContoUnabatableSplit
			// 
			this.txtCodiceContoUnabatableSplit.Location = new System.Drawing.Point(8, 76);
			this.txtCodiceContoUnabatableSplit.Name = "txtCodiceContoUnabatableSplit";
			this.txtCodiceContoUnabatableSplit.Size = new System.Drawing.Size(405, 20);
			this.txtCodiceContoUnabatableSplit.TabIndex = 1;
			this.txtCodiceContoUnabatableSplit.Tag = "accountunabatable_split.codeacc?x";
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(10, 47);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(120, 23);
			this.button9.TabIndex = 0;
			this.button9.TabStop = false;
			this.button9.Tag = "manage.accountunabatable_split.tree";
			this.button9.Text = "Conto";
			// 
			// groupBox12
			// 
			this.groupBox12.Controls.Add(this.textBox19);
			this.groupBox12.Controls.Add(this.txtCodiceContodiffSplit);
			this.groupBox12.Controls.Add(this.button10);
			this.groupBox12.Location = new System.Drawing.Point(13, 224);
			this.groupBox12.Name = "groupBox12";
			this.groupBox12.Size = new System.Drawing.Size(419, 108);
			this.groupBox12.TabIndex = 9;
			this.groupBox12.TabStop = false;
			this.groupBox12.Tag = "AutoManage.txtCodiceContodiffSplit.tree";
			this.groupBox12.Text = "Conto E/P per iva differita per la scrittura di segno opposto";
			// 
			// textBox19
			// 
			this.textBox19.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox19.Location = new System.Drawing.Point(136, 16);
			this.textBox19.Multiline = true;
			this.textBox19.Name = "textBox19";
			this.textBox19.ReadOnly = true;
			this.textBox19.Size = new System.Drawing.Size(275, 60);
			this.textBox19.TabIndex = 2;
			this.textBox19.TabStop = false;
			this.textBox19.Tag = "accountdiff_split.title";
			// 
			// txtCodiceContodiffSplit
			// 
			this.txtCodiceContodiffSplit.Location = new System.Drawing.Point(6, 82);
			this.txtCodiceContodiffSplit.Name = "txtCodiceContodiffSplit";
			this.txtCodiceContodiffSplit.Size = new System.Drawing.Size(407, 20);
			this.txtCodiceContodiffSplit.TabIndex = 1;
			this.txtCodiceContodiffSplit.Tag = "accountdiff_split.codeacc?x";
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(10, 53);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(120, 23);
			this.button10.TabIndex = 0;
			this.button10.TabStop = false;
			this.button10.Tag = "manage.accountdiff_split.tree";
			this.button10.Text = "Conto";
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
			this.tabAttributi.Size = new System.Drawing.Size(944, 505);
			this.tabAttributi.TabIndex = 3;
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
			this.gboxclass05.Location = new System.Drawing.Point(6, 286);
			this.gboxclass05.Name = "gboxclass05";
			this.gboxclass05.Size = new System.Drawing.Size(579, 64);
			this.gboxclass05.TabIndex = 33;
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
			this.txtDenom05.Size = new System.Drawing.Size(337, 52);
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
			this.gboxclass04.Location = new System.Drawing.Point(6, 216);
			this.gboxclass04.Name = "gboxclass04";
			this.gboxclass04.Size = new System.Drawing.Size(579, 64);
			this.gboxclass04.TabIndex = 32;
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
			this.txtDenom04.Size = new System.Drawing.Size(337, 46);
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
			this.gboxclass03.Location = new System.Drawing.Point(6, 146);
			this.gboxclass03.Name = "gboxclass03";
			this.gboxclass03.Size = new System.Drawing.Size(579, 64);
			this.gboxclass03.TabIndex = 30;
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
			this.txtDenom03.Size = new System.Drawing.Size(338, 52);
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
			this.gboxclass02.Location = new System.Drawing.Point(6, 76);
			this.gboxclass02.Name = "gboxclass02";
			this.gboxclass02.Size = new System.Drawing.Size(579, 64);
			this.gboxclass02.TabIndex = 31;
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
			this.txtDenom02.Size = new System.Drawing.Size(338, 52);
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
			this.gboxclass01.Location = new System.Drawing.Point(6, 6);
			this.gboxclass01.Name = "gboxclass01";
			this.gboxclass01.Size = new System.Drawing.Size(579, 64);
			this.gboxclass01.TabIndex = 29;
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
			this.txtDenom01.Size = new System.Drawing.Size(338, 52);
			this.txtDenom01.TabIndex = 3;
			this.txtDenom01.TabStop = false;
			this.txtDenom01.Tag = "sorting01.description";
			// 
			// tabStampa
			// 
			this.tabStampa.Controls.Add(this.MetaDataDetail1);
			this.tabStampa.Location = new System.Drawing.Point(4, 22);
			this.tabStampa.Name = "tabStampa";
			this.tabStampa.Padding = new System.Windows.Forms.Padding(3);
			this.tabStampa.Size = new System.Drawing.Size(944, 505);
			this.tabStampa.TabIndex = 2;
			this.tabStampa.Text = "Stampa";
			this.tabStampa.UseVisualStyleBackColor = true;
			// 
			// MetaDataDetail1
			// 
			this.MetaDataDetail1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.MetaDataDetail1.Controls.Add(this.textBox7);
			this.MetaDataDetail1.Controls.Add(this.label5);
			this.MetaDataDetail1.Controls.Add(this.tabControlReport);
			this.MetaDataDetail1.Location = new System.Drawing.Point(17, 20);
			this.MetaDataDetail1.Name = "MetaDataDetail1";
			this.MetaDataDetail1.Size = new System.Drawing.Size(911, 463);
			this.MetaDataDetail1.TabIndex = 63;
			this.MetaDataDetail1.TabStop = false;
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(6, 36);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(161, 20);
			this.textBox7.TabIndex = 64;
			this.textBox7.Tag = "invoicekind.printingcode";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(6, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(121, 21);
			this.label5.TabIndex = 65;
			this.label5.Text = "Codice Stampa:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tabControlReport
			// 
			this.tabControlReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControlReport.Controls.Add(this.tabPage4);
			this.tabControlReport.Controls.Add(this.tabPage5);
			this.tabControlReport.Controls.Add(this.tabPage1);
			this.tabControlReport.Controls.Add(this.tabPage2);
			this.tabControlReport.Controls.Add(this.tabPage3);
			this.tabControlReport.Location = new System.Drawing.Point(9, 62);
			this.tabControlReport.Name = "tabControlReport";
			this.tabControlReport.SelectedIndex = 0;
			this.tabControlReport.Size = new System.Drawing.Size(413, 176);
			this.tabControlReport.TabIndex = 63;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.textBox9);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(405, 150);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Intestazione Report";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// textBox9
			// 
			this.textBox9.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox9.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox9.Location = new System.Drawing.Point(3, 3);
			this.textBox9.Multiline = true;
			this.textBox9.Name = "textBox9";
			this.textBox9.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox9.Size = new System.Drawing.Size(399, 144);
			this.textBox9.TabIndex = 39;
			this.textBox9.Tag = "invoicekind.header";
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.textBox10);
			this.tabPage5.Location = new System.Drawing.Point(4, 22);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage5.Size = new System.Drawing.Size(405, 150);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "Indirizzo";
			this.tabPage5.UseVisualStyleBackColor = true;
			// 
			// textBox10
			// 
			this.textBox10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox10.Location = new System.Drawing.Point(20, 11);
			this.textBox10.Multiline = true;
			this.textBox10.Name = "textBox10";
			this.textBox10.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox10.Size = new System.Drawing.Size(848, 342);
			this.textBox10.TabIndex = 39;
			this.textBox10.Tag = "invoicekind.address";
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.textBox14);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(405, 150);
			this.tabPage1.TabIndex = 5;
			this.tabPage1.Text = "Annotazioni 1";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// textBox14
			// 
			this.textBox14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox14.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox14.Location = new System.Drawing.Point(20, 11);
			this.textBox14.Multiline = true;
			this.textBox14.Name = "textBox14";
			this.textBox14.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox14.Size = new System.Drawing.Size(379, 136);
			this.textBox14.TabIndex = 38;
			this.textBox14.Tag = "invoicekind.notes1";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.textBox12);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(405, 150);
			this.tabPage2.TabIndex = 6;
			this.tabPage2.Text = "Annotazioni 2";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// textBox12
			// 
			this.textBox12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox12.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox12.Location = new System.Drawing.Point(20, 11);
			this.textBox12.Multiline = true;
			this.textBox12.Name = "textBox12";
			this.textBox12.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox12.Size = new System.Drawing.Size(379, 133);
			this.textBox12.TabIndex = 38;
			this.textBox12.Tag = "invoicekind.notes2";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.textBox13);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(405, 150);
			this.tabPage3.TabIndex = 7;
			this.tabPage3.Text = "Annotazioni 3";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// textBox13
			// 
			this.textBox13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox13.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox13.Location = new System.Drawing.Point(20, 11);
			this.textBox13.Multiline = true;
			this.textBox13.Name = "textBox13";
			this.textBox13.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox13.Size = new System.Drawing.Size(379, 133);
			this.textBox13.TabIndex = 37;
			this.textBox13.Tag = "invoicekind.notes3";
			// 
			// btnCopyAll
			// 
			this.btnCopyAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCopyAll.Location = new System.Drawing.Point(697, 543);
			this.btnCopyAll.Name = "btnCopyAll";
			this.btnCopyAll.Size = new System.Drawing.Size(256, 23);
			this.btnCopyAll.TabIndex = 20;
			this.btnCopyAll.Text = "Copia il Tipo Documento su tutti gli altri Dipartimenti";
			this.btnCopyAll.UseVisualStyleBackColor = true;
			this.btnCopyAll.Click += new System.EventHandler(this.btnCopyAll_Click);
			// 
			// Frm_invoicekind_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(965, 573);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.btnCopyAll);
			this.Name = "Frm_invoicekind_default";
			this.Text = "frmtipodocumentoiva";
			this.tabControl1.ResumeLayout(false);
			this.tabGenerale.ResumeLayout(false);
			this.tabGenerale.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox10.ResumeLayout(false);
			this.groupBox10.PerformLayout();
			this.groupBox20.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tabEP.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.tabControl2.ResumeLayout(false);
			this.tabPage6.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.gboxConto.ResumeLayout(false);
			this.gboxConto.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox9.ResumeLayout(false);
			this.groupBox9.PerformLayout();
			this.tabPage7.ResumeLayout(false);
			this.tabPage7.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.tabPage8.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			this.groupBox8.PerformLayout();
			this.groupBox11.ResumeLayout(false);
			this.groupBox11.PerformLayout();
			this.groupBox12.ResumeLayout(false);
			this.groupBox12.PerformLayout();
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
			this.tabStampa.ResumeLayout(false);
			this.MetaDataDetail1.ResumeLayout(false);
			this.MetaDataDetail1.PerformLayout();
			this.tabControlReport.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.tabPage4.PerformLayout();
			this.tabPage5.ResumeLayout(false);
			this.tabPage5.PerformLayout();
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion
        DataAccess Conn;
        QueryHelper QHS;

		public void MetaData_AfterLink(){
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHS = Conn.GetQueryHelper();
            bool IsAdmin = false;

            if (Meta.GetUsr("consolidamento") != null)
                IsAdmin = (Meta.GetUsr("consolidamento").ToString() == "S");
            if (Meta.GetSys("IsSystemAdmin") != null)
              IsAdmin = IsAdmin ||  (bool)Meta.GetSys("IsSystemAdmin");

            if (!IsAdmin) btnCopyAll.Visible = false;
          DataAccess.SetTableForReading(DS.account_intra, "account");
          DataAccess.SetTableForReading(DS.account_split, "account");
          DataAccess.SetTableForReading(DS.accountdiff, "account");
          DataAccess.SetTableForReading(DS.accountdiff_intra, "account");
          DataAccess.SetTableForReading(DS.accountdiff_split, "account");
          DataAccess.SetTableForReading(DS.accountdiscount, "account");
          DataAccess.SetTableForReading(DS.accountunabatable, "account");
          DataAccess.SetTableForReading(DS.accountunabatable_intra, "account");
          DataAccess.SetTableForReading(DS.accountunabatable_split, "account");
          DataAccess.SetTableForReading(DS.invoicekind_auto, "invoicekind");
          string filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));

          GetData.SetStaticFilter(DS.account_intra, filteresercizio);
          GetData.SetStaticFilter(DS.account_split, filteresercizio);
          GetData.SetStaticFilter(DS.accountdiff, filteresercizio);
          GetData.SetStaticFilter(DS.accountdiff_intra, filteresercizio);
          GetData.SetStaticFilter(DS.accountdiff_split, filteresercizio);
          GetData.SetStaticFilter(DS.accountdiscount, filteresercizio);
          GetData.SetStaticFilter(DS.accountunabatable, filteresercizio);
          GetData.SetStaticFilter(DS.accountunabatable_intra, filteresercizio);
          GetData.SetStaticFilter(DS.accountunabatable_split, filteresercizio);
          GetData.SetStaticFilter(DS.account, filteresercizio);
          //Meta.CanInsertCopy = false;


          GetData.SetStaticFilter(DS.invoicekindyear, filteresercizio);

          DataAccess.SetTableForReading(DS.sorting01, "sorting");
          DataAccess.SetTableForReading(DS.sorting02, "sorting");
          DataAccess.SetTableForReading(DS.sorting03, "sorting");
          DataAccess.SetTableForReading(DS.sorting04, "sorting");
          DataAccess.SetTableForReading(DS.sorting05, "sorting");

          DataTable tUniConfig = Conn.RUN_SELECT("uniconfig", "*", null,
            null, null, null, true);
          if ((tUniConfig != null) && (tUniConfig.Rows.Count > 0)) {
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
                  idsorkind3 == DBNull.Value && idsorkind4 == DBNull.Value && idsorkind5 == DBNull.Value) {
                  tabControl1.TabPages.Remove(tabAttributi);
              }
          }
        }
        
		void CheckInvoiceKindYearExistent(){
			DataRow Curr= HelpForm.GetLastSelected(DS.invoicekind);
			if (Curr==null) return;
			if (DS.invoicekindyear.Rows.Count==0){
				MetaData InvKind= MetaData.GetMetaData(this,"invoicekindyear");
				InvKind.SetDefaults(DS.invoicekindyear);
				DataRow RInvYear = InvKind.Get_New_Row(Curr,DS.invoicekindyear);
			}
			else {
				DataRow RInvYear= DS.invoicekindyear.Rows[0];
				RInvYear["idinvkind"]=Curr["idinvkind"];
			}
		}

		void AlignInvoicekindregisterkind(){
			if (!Meta.InsertMode)return;
			DataRow Curr= HelpForm.GetLastSelected(DS.invoicekind);
			if (Curr==null) return;
			foreach(DataRow R in DS.invoicekindregisterkind.Rows) R["idinvkind"]=Curr["idinvkind"];
		}
		public void MetaData_BeforeFill(){
			CheckInvoiceKindYearExistent();
			Meta.myHelpForm.addExtraEntity("invoicekindyear");
		}

        public void MetaData_AfterGetFormData(){
			CheckInvoiceKindYearExistent();
			AlignInvoicekindregisterkind();

		}

        private void btnCopyAll_Click(object sender, EventArgs e)
        {
            if (Meta.IsEmpty) return;
            Meta.SaveFormData();
            PostData.RemoveFalseUpdates(DS);
            if (DS.HasChanges()) return;
            DataRow R = HelpForm.GetLastSelected(DS.invoicekind);

            if (show("Copiare tutte le informazioni del tipo documento di codice " +
                    R["codeinvkind"].ToString() + " su tutti i dipartimenti?", "Attenzione", MessageBoxButtons.YesNo) !=
                    DialogResult.Yes) return;

            Meta.Conn.CallSP("copyrow_invoicekind", new object[1] { R["idinvkind"] });
        }

        private void label4_Click(object sender, EventArgs e) {

        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e) {
            runProcess(e.LinkText, true);
        }

 
	}
}
