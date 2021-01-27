
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using funzioni_configurazione;//funzioni_configurazione

namespace treasurer_default {//istitutocassiere//
	/// <summary>
	/// Summary description for frmistitutocassiere.
	/// </summary>
    public class Frm_treasurer_default : MetaDataForm
    {
        public dsmeta DS;
		string lastCIN = "";
		object lastABI = DBNull.Value;
		object lastCAB = DBNull.Value;
		string lastCC = "";
        bool inChiusura = false;
        private TabPage tabAttributi;
        public GroupBox gboxclass05;
        public Button btnCodice05;
        private TextBox txtDenom05;
        public GroupBox gboxclass04;
        public Button btnCodice04;
        private TextBox txtDenom04;
        public GroupBox gboxclass03;
        public Button btnCodice03;
        private TextBox txtDenom03;
        public GroupBox gboxclass02;
        public Button btnCodice02;
        private TextBox txtDenom02;
        public GroupBox gboxclass01;
        public Button btnCodice01;
        private TextBox txtDenom01;
        private TabPage tabCBI;
        private TextBox txtreccbi;
        private TextBox txtreccbikind;
        private TextBox txtSIA;
        private Label lblreccbikind;
        private Label label26;
        private Label label24;
        private GroupBox grpBoxCBI;
        private GroupBox grpCABcbi;
        private Button btnCABcbi;
        private TextBox txtCABcbi;
        private TextBox txtDescrCABcbi;
        private GroupBox grpabicbi;
        private TextBox txtABIcbi;
        private Button btnABIcbi;
        private TextBox txtDescriABIcbi;
        private Button btnIBANcbi;
        private TextBox txtIBANcbi;
        private Label label25;
        private Label label27;
        private Label label29;
        private TextBox txtcincbi;
        private Label label30;
        private TextBox txtCCcbi;
        private TabPage tabEP;
        private GroupBox groupBox5;
        private TextBox textBox4;
        private TextBox txtCodiceCausalePay;
        private Button button1;
        private GroupBox groupBox4;
        private TextBox textBox5;
        private TextBox txtCodiceCausalePro;
        private Button button2;
        private TabPage tabTrasmEl;
        private TextBox textBox3;
        private Label label34;
        private GroupBox groupBox11;
        private TextBox textBox2;
        private GroupBox groupBox10;
        private TextBox txtLunghezzaCausale;
        private TextBox txtSeparatoreCausale;
        private TextBox txtPrefissoCausale;
        private Label label31;
        private Label label32;
        private Label label33;
        private GroupBox groupBox7;
        private GroupBox groupBox9;
        private CheckBox chkRaggPayCupCig;
        private CheckBox chkRaggPaymentmodalita;
        private CheckBox chkRaggPaymentCausale;
        private CheckBox chkNonRaggPayment;
        private GroupBox groupBox8;
        private CheckBox chkRaggProceedCausale;
        private CheckBox chkRaggIncCup;
        private CheckBox chkRaggruppaIncassiVersante;
        private CheckBox chkNonRaggruppIncassi;
        private GroupBox groupBox6;
        private CheckBox checkBox5;
        private CheckBox checkBox4;
        private CheckBox chkDigitalPayment;
        private TextBox textBox8;
        private Label label21;
        private TextBox textBox6;
        private CheckBox checkBox1;
        private Label label19;
        private TextBox textBox7;
        private Label label20;
        private GroupBox groupBox3;
        private TextBox txtTrasmCode;
        private Label label28;
        private TextBox txtcodicesportelloexp;
        private TextBox txtcodiceistitutoexp;
        private TextBox txtcodiceenteexp;
        private Label label13;
        private Label label12;
        private Label label11;
        private TabPage tabPrincipale;
        private TextBox textBox10;
        private TextBox txtDescrizione;
        private TextBox txtCodIstituto;
        private Label label35;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
        private Label label4;
        private Label label1;
        private CheckBox ckbCassierePredefinito;
        private GroupBox groupBox1;
        private GroupBox gboxSportello;
        private Button btnCab;
        public TextBox txtCab;
        private TextBox txtCabDescr;
        private GroupBox gboxBanca;
        public TextBox txtBanca;
        private Button BancaButton;
        private TextBox txtDescrBanca;
        private TextBox textBox9;
        private Label label23;
        private Button btnIBAN;
        private TextBox txtIBAN;
        private Label label22;
        private Button btnBBAN;
        private Label label18;
        private TextBox txtBBAN;
        private Label label16;
        private Label label17;
        private Label label5;
        private TextBox txtCin;
        private Label label3;
        private TextBox txtNumConto;
        private GroupBox groupBox2;
        private PictureBox pictureBox1;
        private Label label15;
        private Label label14;
        private TextBox txtFaxNumero;
        private TextBox txtFaxPrefisso;
        private Label label10;
        private TextBox txtTelNumero;
        private TextBox txtTelPrefisso;
        private Label label9;
        private TextBox txtProvincia;
        private Label label8;
        private TextBox txtComune;
        private Label label7;
        private TextBox txtCAP;
        private Label label6;
        private TextBox txtIndirizzo;
        private Label label2;
        private TabControl tabControl1;
        private Label label36;
        private Button btnChooseDir;
        private TextBox txtDir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private GroupBox groupBox12;
        private TextBox textBox1;
        private Label label37;
        private CheckBox checkBox6;
        public TextBox txtCodice05;
        public TextBox txtCodice04;
        public TextBox txtCodice03;
        public TextBox txtCodice02;
        public TextBox txtCodice01;
        private TextBox textBox11;
        private Label label38;
        private TabPage tabPage1;
        private TextBox textBox16;
        private Label label43;
        private TextBox textBox15;
        private Label label42;
        private TextBox textBox14;
        private Label label41;
        private TextBox textBox13;
        private Label label40;
        private TextBox textBox12;
        private Label label39;
        private TextBox textBox17;
        private Label label44;
        private GroupBox groupBox13;
        private TextBox textBox20;
        private Label label47;
        private TextBox textBox19;
        private Label label46;
        private TextBox textBox18;
        private Label label45;
        private GroupBox groupBox14;
        private RadioButton rdbAlfanumerico;
        private RadioButton rdbNumerico;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

		public Frm_treasurer_default() {
			InitializeComponent();
		
        }

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			inChiusura = true;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_treasurer_default));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
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
            this.tabCBI = new System.Windows.Forms.TabPage();
            this.txtreccbi = new System.Windows.Forms.TextBox();
            this.txtreccbikind = new System.Windows.Forms.TextBox();
            this.txtSIA = new System.Windows.Forms.TextBox();
            this.lblreccbikind = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.grpBoxCBI = new System.Windows.Forms.GroupBox();
            this.grpCABcbi = new System.Windows.Forms.GroupBox();
            this.btnCABcbi = new System.Windows.Forms.Button();
            this.txtCABcbi = new System.Windows.Forms.TextBox();
            this.txtDescrCABcbi = new System.Windows.Forms.TextBox();
            this.grpabicbi = new System.Windows.Forms.GroupBox();
            this.txtABIcbi = new System.Windows.Forms.TextBox();
            this.btnABIcbi = new System.Windows.Forms.Button();
            this.txtDescriABIcbi = new System.Windows.Forms.TextBox();
            this.btnIBANcbi = new System.Windows.Forms.Button();
            this.txtIBANcbi = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.txtcincbi = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtCCcbi = new System.Windows.Forms.TextBox();
            this.tabEP = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.txtCodiceCausalePay = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.txtCodiceCausalePro = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tabTrasmEl = new System.Windows.Forms.TabPage();
            this.label36 = new System.Windows.Forms.Label();
            this.btnChooseDir = new System.Windows.Forms.Button();
            this.txtDir = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.txtLunghezzaCausale = new System.Windows.Forms.TextBox();
            this.txtSeparatoreCausale = new System.Windows.Forms.TextBox();
            this.txtPrefissoCausale = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.chkRaggPayCupCig = new System.Windows.Forms.CheckBox();
            this.chkRaggPaymentmodalita = new System.Windows.Forms.CheckBox();
            this.chkRaggPaymentCausale = new System.Windows.Forms.CheckBox();
            this.chkNonRaggPayment = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.chkRaggProceedCausale = new System.Windows.Forms.CheckBox();
            this.chkRaggIncCup = new System.Windows.Forms.CheckBox();
            this.chkRaggruppaIncassiVersante = new System.Windows.Forms.CheckBox();
            this.chkNonRaggruppIncassi = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.chkDigitalPayment = new System.Windows.Forms.CheckBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.txtTrasmCode = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txtcodicesportelloexp = new System.Windows.Forms.TextBox();
            this.txtcodiceistitutoexp = new System.Windows.Forms.TextBox();
            this.txtcodiceenteexp = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPrincipale = new System.Windows.Forms.TabPage();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.txtCodIstituto = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ckbCassierePredefinito = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gboxSportello = new System.Windows.Forms.GroupBox();
            this.btnCab = new System.Windows.Forms.Button();
            this.txtCab = new System.Windows.Forms.TextBox();
            this.txtCabDescr = new System.Windows.Forms.TextBox();
            this.gboxBanca = new System.Windows.Forms.GroupBox();
            this.txtBanca = new System.Windows.Forms.TextBox();
            this.BancaButton = new System.Windows.Forms.Button();
            this.txtDescrBanca = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.btnIBAN = new System.Windows.Forms.Button();
            this.txtIBAN = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.btnBBAN = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.txtBBAN = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumConto = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtFaxNumero = new System.Windows.Forms.TextBox();
            this.txtFaxPrefisso = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.txtTelNumero = new System.Windows.Forms.TextBox();
            this.txtTelPrefisso = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtProvincia = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtComune = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCAP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIndirizzo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.DS = new treasurer_default.dsmeta();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.rdbAlfanumerico = new System.Windows.Forms.RadioButton();
            this.rdbNumerico = new System.Windows.Forms.RadioButton();
            this.tabAttributi.SuspendLayout();
            this.gboxclass05.SuspendLayout();
            this.gboxclass04.SuspendLayout();
            this.gboxclass03.SuspendLayout();
            this.gboxclass02.SuspendLayout();
            this.gboxclass01.SuspendLayout();
            this.tabCBI.SuspendLayout();
            this.grpBoxCBI.SuspendLayout();
            this.grpCABcbi.SuspendLayout();
            this.grpabicbi.SuspendLayout();
            this.tabEP.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabTrasmEl.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.tabPrincipale.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gboxSportello.SuspendLayout();
            this.gboxBanca.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox14.SuspendLayout();
            this.SuspendLayout();
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
            this.tabAttributi.Size = new System.Drawing.Size(675, 736);
            this.tabAttributi.TabIndex = 4;
            this.tabAttributi.Text = "Attributi";
            this.tabAttributi.UseVisualStyleBackColor = true;
            // 
            // gboxclass05
            // 
            this.gboxclass05.Controls.Add(this.txtCodice05);
            this.gboxclass05.Controls.Add(this.btnCodice05);
            this.gboxclass05.Controls.Add(this.txtDenom05);
            this.gboxclass05.Location = new System.Drawing.Point(16, 382);
            this.gboxclass05.Name = "gboxclass05";
            this.gboxclass05.Size = new System.Drawing.Size(435, 74);
            this.gboxclass05.TabIndex = 23;
            this.gboxclass05.TabStop = false;
            this.gboxclass05.Tag = "";
            this.gboxclass05.Text = "Classificazione 5";
            // 
            // txtCodice05
            // 
            this.txtCodice05.Location = new System.Drawing.Point(8, 48);
            this.txtCodice05.Name = "txtCodice05";
            this.txtCodice05.Size = new System.Drawing.Size(205, 20);
            this.txtCodice05.TabIndex = 7;
            // 
            // btnCodice05
            // 
            this.btnCodice05.Location = new System.Drawing.Point(9, 19);
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
            this.txtDenom05.Location = new System.Drawing.Point(220, 8);
            this.txtDenom05.Multiline = true;
            this.txtDenom05.Name = "txtDenom05";
            this.txtDenom05.ReadOnly = true;
            this.txtDenom05.Size = new System.Drawing.Size(207, 62);
            this.txtDenom05.TabIndex = 3;
            this.txtDenom05.TabStop = false;
            this.txtDenom05.Tag = "sorting05.description";
            // 
            // gboxclass04
            // 
            this.gboxclass04.Controls.Add(this.txtCodice04);
            this.gboxclass04.Controls.Add(this.btnCodice04);
            this.gboxclass04.Controls.Add(this.txtDenom04);
            this.gboxclass04.Location = new System.Drawing.Point(17, 302);
            this.gboxclass04.Name = "gboxclass04";
            this.gboxclass04.Size = new System.Drawing.Size(435, 74);
            this.gboxclass04.TabIndex = 22;
            this.gboxclass04.TabStop = false;
            this.gboxclass04.Tag = "";
            this.gboxclass04.Text = "Classificazione 4";
            // 
            // txtCodice04
            // 
            this.txtCodice04.Location = new System.Drawing.Point(8, 45);
            this.txtCodice04.Name = "txtCodice04";
            this.txtCodice04.Size = new System.Drawing.Size(205, 20);
            this.txtCodice04.TabIndex = 7;
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
            this.txtDenom04.Location = new System.Drawing.Point(220, 8);
            this.txtDenom04.Multiline = true;
            this.txtDenom04.Name = "txtDenom04";
            this.txtDenom04.ReadOnly = true;
            this.txtDenom04.Size = new System.Drawing.Size(207, 62);
            this.txtDenom04.TabIndex = 3;
            this.txtDenom04.TabStop = false;
            this.txtDenom04.Tag = "sorting04.description";
            // 
            // gboxclass03
            // 
            this.gboxclass03.Controls.Add(this.txtCodice03);
            this.gboxclass03.Controls.Add(this.btnCodice03);
            this.gboxclass03.Controls.Add(this.txtDenom03);
            this.gboxclass03.Location = new System.Drawing.Point(17, 208);
            this.gboxclass03.Name = "gboxclass03";
            this.gboxclass03.Size = new System.Drawing.Size(435, 76);
            this.gboxclass03.TabIndex = 20;
            this.gboxclass03.TabStop = false;
            this.gboxclass03.Tag = "";
            this.gboxclass03.Text = "Classificazione 3";
            // 
            // txtCodice03
            // 
            this.txtCodice03.Location = new System.Drawing.Point(8, 50);
            this.txtCodice03.Name = "txtCodice03";
            this.txtCodice03.Size = new System.Drawing.Size(205, 20);
            this.txtCodice03.TabIndex = 7;
            // 
            // btnCodice03
            // 
            this.btnCodice03.Location = new System.Drawing.Point(8, 21);
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
            this.txtDenom03.Location = new System.Drawing.Point(220, 8);
            this.txtDenom03.Multiline = true;
            this.txtDenom03.Name = "txtDenom03";
            this.txtDenom03.ReadOnly = true;
            this.txtDenom03.Size = new System.Drawing.Size(207, 64);
            this.txtDenom03.TabIndex = 3;
            this.txtDenom03.TabStop = false;
            this.txtDenom03.Tag = "sorting03.description";
            // 
            // gboxclass02
            // 
            this.gboxclass02.Controls.Add(this.txtCodice02);
            this.gboxclass02.Controls.Add(this.btnCodice02);
            this.gboxclass02.Controls.Add(this.txtDenom02);
            this.gboxclass02.Location = new System.Drawing.Point(16, 115);
            this.gboxclass02.Name = "gboxclass02";
            this.gboxclass02.Size = new System.Drawing.Size(434, 76);
            this.gboxclass02.TabIndex = 21;
            this.gboxclass02.TabStop = false;
            this.gboxclass02.Tag = "";
            this.gboxclass02.Text = "Classificazione 2";
            // 
            // txtCodice02
            // 
            this.txtCodice02.Location = new System.Drawing.Point(8, 45);
            this.txtCodice02.Name = "txtCodice02";
            this.txtCodice02.Size = new System.Drawing.Size(205, 20);
            this.txtCodice02.TabIndex = 7;
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
            this.txtDenom02.Location = new System.Drawing.Point(220, 8);
            this.txtDenom02.Multiline = true;
            this.txtDenom02.Name = "txtDenom02";
            this.txtDenom02.ReadOnly = true;
            this.txtDenom02.Size = new System.Drawing.Size(206, 64);
            this.txtDenom02.TabIndex = 3;
            this.txtDenom02.TabStop = false;
            this.txtDenom02.Tag = "sorting02.description";
            // 
            // gboxclass01
            // 
            this.gboxclass01.Controls.Add(this.txtCodice01);
            this.gboxclass01.Controls.Add(this.btnCodice01);
            this.gboxclass01.Controls.Add(this.txtDenom01);
            this.gboxclass01.Location = new System.Drawing.Point(17, 19);
            this.gboxclass01.Name = "gboxclass01";
            this.gboxclass01.Size = new System.Drawing.Size(434, 76);
            this.gboxclass01.TabIndex = 19;
            this.gboxclass01.TabStop = false;
            this.gboxclass01.Tag = "";
            this.gboxclass01.Text = "Classificazione 1";
            // 
            // txtCodice01
            // 
            this.txtCodice01.Location = new System.Drawing.Point(6, 50);
            this.txtCodice01.Name = "txtCodice01";
            this.txtCodice01.Size = new System.Drawing.Size(206, 20);
            this.txtCodice01.TabIndex = 6;
            // 
            // btnCodice01
            // 
            this.btnCodice01.Location = new System.Drawing.Point(8, 21);
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
            this.txtDenom01.Location = new System.Drawing.Point(220, 8);
            this.txtDenom01.Multiline = true;
            this.txtDenom01.Name = "txtDenom01";
            this.txtDenom01.ReadOnly = true;
            this.txtDenom01.Size = new System.Drawing.Size(206, 64);
            this.txtDenom01.TabIndex = 3;
            this.txtDenom01.TabStop = false;
            this.txtDenom01.Tag = "sorting01.description";
            // 
            // tabCBI
            // 
            this.tabCBI.Controls.Add(this.txtreccbi);
            this.tabCBI.Controls.Add(this.txtreccbikind);
            this.tabCBI.Controls.Add(this.txtSIA);
            this.tabCBI.Controls.Add(this.lblreccbikind);
            this.tabCBI.Controls.Add(this.label26);
            this.tabCBI.Controls.Add(this.label24);
            this.tabCBI.Controls.Add(this.grpBoxCBI);
            this.tabCBI.Location = new System.Drawing.Point(4, 22);
            this.tabCBI.Name = "tabCBI";
            this.tabCBI.Size = new System.Drawing.Size(675, 736);
            this.tabCBI.TabIndex = 3;
            this.tabCBI.Text = "Trasm.CBI";
            this.tabCBI.UseVisualStyleBackColor = true;
            // 
            // txtreccbi
            // 
            this.txtreccbi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtreccbi.Location = new System.Drawing.Point(137, 314);
            this.txtreccbi.Multiline = true;
            this.txtreccbi.Name = "txtreccbi";
            this.txtreccbi.ReadOnly = true;
            this.txtreccbi.Size = new System.Drawing.Size(525, 71);
            this.txtreccbi.TabIndex = 27;
            this.txtreccbi.TabStop = false;
            this.txtreccbi.Text = resources.GetString("txtreccbi.Text");
            // 
            // txtreccbikind
            // 
            this.txtreccbikind.Location = new System.Drawing.Point(91, 314);
            this.txtreccbikind.Name = "txtreccbikind";
            this.txtreccbikind.Size = new System.Drawing.Size(40, 20);
            this.txtreccbikind.TabIndex = 9;
            this.txtreccbikind.Tag = "treasurer.reccbikind";
            // 
            // txtSIA
            // 
            this.txtSIA.Location = new System.Drawing.Point(67, 284);
            this.txtSIA.Name = "txtSIA";
            this.txtSIA.Size = new System.Drawing.Size(91, 20);
            this.txtSIA.TabIndex = 7;
            this.txtSIA.Tag = "treasurer.siacodecbi";
            // 
            // lblreccbikind
            // 
            this.lblreccbikind.AutoSize = true;
            this.lblreccbikind.Location = new System.Drawing.Point(4, 317);
            this.lblreccbikind.Name = "lblreccbikind";
            this.lblreccbikind.Size = new System.Drawing.Size(86, 13);
            this.lblreccbikind.TabIndex = 8;
            this.lblreccbikind.Text = "Tipo Record CBI";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(6, 289);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(60, 13);
            this.label26.TabIndex = 6;
            this.label26.Text = "Codice SIA";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(10, 27);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(366, 13);
            this.label24.TabIndex = 5;
            this.label24.Text = "Coordinate per la trasmissione del beneficiario CBI di diposizioni PER CASSA";
            // 
            // grpBoxCBI
            // 
            this.grpBoxCBI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxCBI.Controls.Add(this.grpCABcbi);
            this.grpBoxCBI.Controls.Add(this.grpabicbi);
            this.grpBoxCBI.Controls.Add(this.btnIBANcbi);
            this.grpBoxCBI.Controls.Add(this.txtIBANcbi);
            this.grpBoxCBI.Controls.Add(this.label25);
            this.grpBoxCBI.Controls.Add(this.label27);
            this.grpBoxCBI.Controls.Add(this.label29);
            this.grpBoxCBI.Controls.Add(this.txtcincbi);
            this.grpBoxCBI.Controls.Add(this.label30);
            this.grpBoxCBI.Controls.Add(this.txtCCcbi);
            this.grpBoxCBI.Location = new System.Drawing.Point(3, 47);
            this.grpBoxCBI.Name = "grpBoxCBI";
            this.grpBoxCBI.Size = new System.Drawing.Size(659, 215);
            this.grpBoxCBI.TabIndex = 4;
            this.grpBoxCBI.TabStop = false;
            this.grpBoxCBI.Text = "Coordinate Bancarie";
            // 
            // grpCABcbi
            // 
            this.grpCABcbi.Controls.Add(this.btnCABcbi);
            this.grpCABcbi.Controls.Add(this.txtCABcbi);
            this.grpCABcbi.Controls.Add(this.txtDescrCABcbi);
            this.grpCABcbi.Location = new System.Drawing.Point(324, 51);
            this.grpCABcbi.Name = "grpCABcbi";
            this.grpCABcbi.Size = new System.Drawing.Size(329, 73);
            this.grpCABcbi.TabIndex = 3;
            this.grpCABcbi.TabStop = false;
            this.grpCABcbi.Tag = "AutoChoose.txtCABcbi.default.(flagusable<>\'N\')";
            // 
            // btnCABcbi
            // 
            this.btnCABcbi.Location = new System.Drawing.Point(6, 10);
            this.btnCABcbi.Name = "btnCABcbi";
            this.btnCABcbi.Size = new System.Drawing.Size(125, 23);
            this.btnCABcbi.TabIndex = 4;
            this.btnCABcbi.Tag = "choose.cabcbi.default";
            this.btnCABcbi.Text = "CAB";
            // 
            // txtCABcbi
            // 
            this.txtCABcbi.Location = new System.Drawing.Point(6, 43);
            this.txtCABcbi.Name = "txtCABcbi";
            this.txtCABcbi.Size = new System.Drawing.Size(125, 20);
            this.txtCABcbi.TabIndex = 29;
            this.txtCABcbi.Tag = "cabcbi.idcab?treasurer.idcabcbi";
            // 
            // txtDescrCABcbi
            // 
            this.txtDescrCABcbi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrCABcbi.Location = new System.Drawing.Point(137, 10);
            this.txtDescrCABcbi.Multiline = true;
            this.txtDescrCABcbi.Name = "txtDescrCABcbi";
            this.txtDescrCABcbi.ReadOnly = true;
            this.txtDescrCABcbi.Size = new System.Drawing.Size(186, 58);
            this.txtDescrCABcbi.TabIndex = 1;
            this.txtDescrCABcbi.TabStop = false;
            this.txtDescrCABcbi.Tag = "cabcbi.description";
            // 
            // grpabicbi
            // 
            this.grpabicbi.Controls.Add(this.txtABIcbi);
            this.grpabicbi.Controls.Add(this.btnABIcbi);
            this.grpabicbi.Controls.Add(this.txtDescriABIcbi);
            this.grpabicbi.Location = new System.Drawing.Point(10, 51);
            this.grpabicbi.Name = "grpabicbi";
            this.grpabicbi.Size = new System.Drawing.Size(308, 73);
            this.grpabicbi.TabIndex = 2;
            this.grpabicbi.TabStop = false;
            this.grpabicbi.Tag = "AutoChoose.txtABIcbi.default.(flagusable<>\'N\')";
            // 
            // txtABIcbi
            // 
            this.txtABIcbi.Location = new System.Drawing.Point(9, 43);
            this.txtABIcbi.Name = "txtABIcbi";
            this.txtABIcbi.Size = new System.Drawing.Size(114, 20);
            this.txtABIcbi.TabIndex = 3;
            this.txtABIcbi.Tag = "bankcbi.idbank?treasurer.idbankcbi";
            // 
            // btnABIcbi
            // 
            this.btnABIcbi.Location = new System.Drawing.Point(8, 14);
            this.btnABIcbi.Name = "btnABIcbi";
            this.btnABIcbi.Size = new System.Drawing.Size(115, 23);
            this.btnABIcbi.TabIndex = 2;
            this.btnABIcbi.Tag = "choose.bankcbi.default.(flagusable<>\'N\')";
            this.btnABIcbi.Text = "ABI";
            // 
            // txtDescriABIcbi
            // 
            this.txtDescriABIcbi.Location = new System.Drawing.Point(129, 10);
            this.txtDescriABIcbi.Multiline = true;
            this.txtDescriABIcbi.Name = "txtDescriABIcbi";
            this.txtDescriABIcbi.ReadOnly = true;
            this.txtDescriABIcbi.Size = new System.Drawing.Size(173, 58);
            this.txtDescriABIcbi.TabIndex = 2;
            this.txtDescriABIcbi.TabStop = false;
            this.txtDescriABIcbi.Tag = "bankcbi.description";
            // 
            // btnIBANcbi
            // 
            this.btnIBANcbi.Location = new System.Drawing.Point(312, 170);
            this.btnIBANcbi.Name = "btnIBANcbi";
            this.btnIBANcbi.Size = new System.Drawing.Size(176, 22);
            this.btnIBANcbi.TabIndex = 33;
            this.btnIBANcbi.TabStop = false;
            this.btnIBANcbi.Text = "Inserisci direttamente l\'IBAN";
            this.btnIBANcbi.UseVisualStyleBackColor = true;
            this.btnIBANcbi.Click += new System.EventHandler(this.btnIBANcbi_Click);
            // 
            // txtIBANcbi
            // 
            this.txtIBANcbi.Location = new System.Drawing.Point(96, 171);
            this.txtIBANcbi.Name = "txtIBANcbi";
            this.txtIBANcbi.ReadOnly = true;
            this.txtIBANcbi.Size = new System.Drawing.Size(208, 20);
            this.txtIBANcbi.TabIndex = 32;
            this.txtIBANcbi.TabStop = false;
            this.txtIBANcbi.Tag = "treasurer.ibancbi";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(55, 173);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(32, 13);
            this.label25.TabIndex = 31;
            this.label25.Text = "IBAN";
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(232, 145);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(248, 16);
            this.label27.TabIndex = 22;
            this.label27.Text = "Nota bene: il C/C deve essere di 12 cifre.";
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(16, 147);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(72, 16);
            this.label29.TabIndex = 16;
            this.label29.Text = "C/C:";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtcincbi
            // 
            this.txtcincbi.Location = new System.Drawing.Point(96, 24);
            this.txtcincbi.Name = "txtcincbi";
            this.txtcincbi.Size = new System.Drawing.Size(64, 20);
            this.txtcincbi.TabIndex = 1;
            this.txtcincbi.Tag = "treasurer.cincbi";
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(16, 24);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(72, 24);
            this.label30.TabIndex = 5;
            this.label30.Text = "CIN:";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCCcbi
            // 
            this.txtCCcbi.Location = new System.Drawing.Point(96, 144);
            this.txtCCcbi.Name = "txtCCcbi";
            this.txtCCcbi.Size = new System.Drawing.Size(120, 20);
            this.txtCCcbi.TabIndex = 10;
            this.txtCCcbi.Tag = "treasurer.cccbi";
            // 
            // tabEP
            // 
            this.tabEP.Controls.Add(this.groupBox5);
            this.tabEP.Controls.Add(this.groupBox4);
            this.tabEP.Location = new System.Drawing.Point(4, 22);
            this.tabEP.Name = "tabEP";
            this.tabEP.Size = new System.Drawing.Size(675, 736);
            this.tabEP.TabIndex = 2;
            this.tabEP.Text = "E/P";
            this.tabEP.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.textBox4);
            this.groupBox5.Controls.Add(this.txtCodiceCausalePay);
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Location = new System.Drawing.Point(8, 96);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(491, 80);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Tag = "AutoManage.txtCodiceCausalePay.tree";
            this.groupBox5.Text = "Causale Banca (pagamenti)";
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(120, 16);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(363, 56);
            this.textBox4.TabIndex = 2;
            this.textBox4.TabStop = false;
            this.textBox4.Tag = "accmotive1.title";
            // 
            // txtCodiceCausalePay
            // 
            this.txtCodiceCausalePay.Location = new System.Drawing.Point(8, 48);
            this.txtCodiceCausalePay.Name = "txtCodiceCausalePay";
            this.txtCodiceCausalePay.Size = new System.Drawing.Size(104, 20);
            this.txtCodiceCausalePay.TabIndex = 1;
            this.txtCodiceCausalePay.Tag = "accmotive1.codemotive?x";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 23);
            this.button1.TabIndex = 0;
            this.button1.TabStop = false;
            this.button1.Tag = "manage.accmotive1.tree";
            this.button1.Text = "Causale";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.textBox5);
            this.groupBox4.Controls.Add(this.txtCodiceCausalePro);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Location = new System.Drawing.Point(8, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(491, 80);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Tag = "AutoManage.txtCodiceCausalePro.tree";
            this.groupBox4.Text = "Causale Banca (incassi)";
            // 
            // textBox5
            // 
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox5.Location = new System.Drawing.Point(120, 16);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(363, 56);
            this.textBox5.TabIndex = 2;
            this.textBox5.TabStop = false;
            this.textBox5.Tag = "accmotive.title";
            // 
            // txtCodiceCausalePro
            // 
            this.txtCodiceCausalePro.Location = new System.Drawing.Point(8, 48);
            this.txtCodiceCausalePro.Name = "txtCodiceCausalePro";
            this.txtCodiceCausalePro.Size = new System.Drawing.Size(104, 20);
            this.txtCodiceCausalePro.TabIndex = 1;
            this.txtCodiceCausalePro.Tag = "accmotive.codemotive?x";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 23);
            this.button2.TabIndex = 0;
            this.button2.TabStop = false;
            this.button2.Tag = "manage.accmotive.tree";
            this.button2.Text = "Causale";
            // 
            // tabTrasmEl
            // 
            this.tabTrasmEl.Controls.Add(this.label36);
            this.tabTrasmEl.Controls.Add(this.btnChooseDir);
            this.tabTrasmEl.Controls.Add(this.txtDir);
            this.tabTrasmEl.Controls.Add(this.textBox3);
            this.tabTrasmEl.Controls.Add(this.label34);
            this.tabTrasmEl.Controls.Add(this.groupBox11);
            this.tabTrasmEl.Controls.Add(this.groupBox10);
            this.tabTrasmEl.Controls.Add(this.groupBox7);
            this.tabTrasmEl.Controls.Add(this.groupBox6);
            this.tabTrasmEl.Controls.Add(this.groupBox3);
            this.tabTrasmEl.Location = new System.Drawing.Point(4, 22);
            this.tabTrasmEl.Name = "tabTrasmEl";
            this.tabTrasmEl.Size = new System.Drawing.Size(675, 736);
            this.tabTrasmEl.TabIndex = 1;
            this.tabTrasmEl.Text = "Trasm. Elettronica";
            this.tabTrasmEl.UseVisualStyleBackColor = true;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(8, 12);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(143, 13);
            this.label36.TabIndex = 39;
            this.label36.Text = "Cartella di salvataggio dei file";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnChooseDir
            // 
            this.btnChooseDir.Location = new System.Drawing.Point(398, 30);
            this.btnChooseDir.Name = "btnChooseDir";
            this.btnChooseDir.Size = new System.Drawing.Size(24, 20);
            this.btnChooseDir.TabIndex = 38;
            this.btnChooseDir.Text = "...";
            this.btnChooseDir.Click += new System.EventHandler(this.btnChooseDir_Click);
            // 
            // txtDir
            // 
            this.txtDir.Location = new System.Drawing.Point(8, 31);
            this.txtDir.MaxLength = 255;
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(384, 20);
            this.txtDir.TabIndex = 37;
            this.txtDir.Tag = "treasurer.savepath";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(97, 703);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(341, 20);
            this.textBox3.TabIndex = 36;
            this.textBox3.Tag = "treasurer.billcode";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(10, 706);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(81, 13);
            this.label34.TabIndex = 35;
            this.label34.Text = "Codice struttura";
            // 
            // groupBox11
            // 
            this.groupBox11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox11.Controls.Add(this.textBox2);
            this.groupBox11.Location = new System.Drawing.Point(376, 391);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(291, 252);
            this.groupBox11.TabIndex = 34;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Annotazioni per Avviso di pagamento E-Mail";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(6, 19);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(279, 227);
            this.textBox2.TabIndex = 2;
            this.textBox2.Tag = "treasurer.annotations";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.txtLunghezzaCausale);
            this.groupBox10.Controls.Add(this.txtSeparatoreCausale);
            this.groupBox10.Controls.Add(this.txtPrefissoCausale);
            this.groupBox10.Controls.Add(this.label31);
            this.groupBox10.Controls.Add(this.label32);
            this.groupBox10.Controls.Add(this.label33);
            this.groupBox10.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.groupBox10.Location = new System.Drawing.Point(8, 648);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(488, 49);
            this.groupBox10.TabIndex = 33;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Costruzione Causale Pagamenti";
            // 
            // txtLunghezzaCausale
            // 
            this.txtLunghezzaCausale.Location = new System.Drawing.Point(388, 17);
            this.txtLunghezzaCausale.Name = "txtLunghezzaCausale";
            this.txtLunghezzaCausale.Size = new System.Drawing.Size(70, 21);
            this.txtLunghezzaCausale.TabIndex = 36;
            this.txtLunghezzaCausale.Tag = "treasurer.motivelen";
            // 
            // txtSeparatoreCausale
            // 
            this.txtSeparatoreCausale.Location = new System.Drawing.Point(231, 17);
            this.txtSeparatoreCausale.Name = "txtSeparatoreCausale";
            this.txtSeparatoreCausale.Size = new System.Drawing.Size(58, 21);
            this.txtSeparatoreCausale.TabIndex = 35;
            this.txtSeparatoreCausale.Tag = "treasurer.motiveseparator";
            // 
            // txtPrefissoCausale
            // 
            this.txtPrefissoCausale.Location = new System.Drawing.Point(65, 19);
            this.txtPrefissoCausale.Name = "txtPrefissoCausale";
            this.txtPrefissoCausale.Size = new System.Drawing.Size(75, 21);
            this.txtPrefissoCausale.TabIndex = 34;
            this.txtPrefissoCausale.Tag = "treasurer.motiveprefix";
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(318, 15);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(64, 23);
            this.label31.TabIndex = 33;
            this.label31.Text = "Lunghezza:";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label32
            // 
            this.label32.Location = new System.Drawing.Point(157, 15);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(66, 23);
            this.label32.TabIndex = 32;
            this.label32.Text = "Separatore:";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label33
            // 
            this.label33.Location = new System.Drawing.Point(9, 17);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(50, 23);
            this.label33.TabIndex = 31;
            this.label33.Text = "Prefisso:";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.groupBox9);
            this.groupBox7.Controls.Add(this.groupBox8);
            this.groupBox7.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.groupBox7.Location = new System.Drawing.Point(8, 390);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(362, 253);
            this.groupBox7.TabIndex = 16;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Gestione dei Movimenti Bancari (Raggruppamento dei mov. finanziari)";
            this.groupBox7.Visible = false;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.chkRaggPayCupCig);
            this.groupBox9.Controls.Add(this.chkRaggPaymentmodalita);
            this.groupBox9.Controls.Add(this.chkRaggPaymentCausale);
            this.groupBox9.Controls.Add(this.chkNonRaggPayment);
            this.groupBox9.Location = new System.Drawing.Point(12, 130);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(344, 112);
            this.groupBox9.TabIndex = 1;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Pagamenti";
            // 
            // chkRaggPayCupCig
            // 
            this.chkRaggPayCupCig.AutoSize = true;
            this.chkRaggPayCupCig.Location = new System.Drawing.Point(10, 80);
            this.chkRaggPayCupCig.Name = "chkRaggPayCupCig";
            this.chkRaggPayCupCig.Size = new System.Drawing.Size(151, 17);
            this.chkRaggPayCupCig.TabIndex = 13;
            this.chkRaggPayCupCig.Tag = "treasurer.flagbank_grouping:3";
            this.chkRaggPayCupCig.Text = "Raggruppa per CUP e CIG";
            this.chkRaggPayCupCig.UseVisualStyleBackColor = true;
            // 
            // chkRaggPaymentmodalita
            // 
            this.chkRaggPaymentmodalita.AutoSize = true;
            this.chkRaggPaymentmodalita.Location = new System.Drawing.Point(10, 60);
            this.chkRaggPaymentmodalita.Name = "chkRaggPaymentmodalita";
            this.chkRaggPaymentmodalita.Size = new System.Drawing.Size(201, 17);
            this.chkRaggPaymentmodalita.TabIndex = 12;
            this.chkRaggPaymentmodalita.Tag = "treasurer.flagbank_grouping:2";
            this.chkRaggPaymentmodalita.Text = "Raggruppa per modalità  pagamento";
            this.chkRaggPaymentmodalita.UseVisualStyleBackColor = true;
            this.chkRaggPaymentmodalita.CheckStateChanged += new System.EventHandler(this.chkRaggPaymentmodalita_CheckStateChanged);
            // 
            // chkRaggPaymentCausale
            // 
            this.chkRaggPaymentCausale.AutoSize = true;
            this.chkRaggPaymentCausale.Location = new System.Drawing.Point(10, 40);
            this.chkRaggPaymentCausale.Name = "chkRaggPaymentCausale";
            this.chkRaggPaymentCausale.Size = new System.Drawing.Size(194, 17);
            this.chkRaggPaymentCausale.TabIndex = 11;
            this.chkRaggPaymentCausale.Tag = "treasurer.flagbank_grouping:1";
            this.chkRaggPaymentCausale.Text = "Raggruppa per causale pagamento";
            this.chkRaggPaymentCausale.UseVisualStyleBackColor = true;
            this.chkRaggPaymentCausale.CheckStateChanged += new System.EventHandler(this.chkRaggPaymentCausale_CheckStateChanged);
            // 
            // chkNonRaggPayment
            // 
            this.chkNonRaggPayment.AutoSize = true;
            this.chkNonRaggPayment.Location = new System.Drawing.Point(10, 20);
            this.chkNonRaggPayment.Name = "chkNonRaggPayment";
            this.chkNonRaggPayment.Size = new System.Drawing.Size(108, 17);
            this.chkNonRaggPayment.TabIndex = 10;
            this.chkNonRaggPayment.Tag = "treasurer.flagbank_grouping:0";
            this.chkNonRaggPayment.Text = "Non raggruppare";
            this.chkNonRaggPayment.UseVisualStyleBackColor = true;
            this.chkNonRaggPayment.CheckStateChanged += new System.EventHandler(this.chkNonRaggPayment_CheckStateChanged);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.chkRaggProceedCausale);
            this.groupBox8.Controls.Add(this.chkRaggIncCup);
            this.groupBox8.Controls.Add(this.chkRaggruppaIncassiVersante);
            this.groupBox8.Controls.Add(this.chkNonRaggruppIncassi);
            this.groupBox8.Location = new System.Drawing.Point(12, 20);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(344, 104);
            this.groupBox8.TabIndex = 0;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Incassi";
            // 
            // chkRaggProceedCausale
            // 
            this.chkRaggProceedCausale.AutoSize = true;
            this.chkRaggProceedCausale.Location = new System.Drawing.Point(9, 77);
            this.chkRaggProceedCausale.Name = "chkRaggProceedCausale";
            this.chkRaggProceedCausale.Size = new System.Drawing.Size(177, 17);
            this.chkRaggProceedCausale.TabIndex = 9;
            this.chkRaggProceedCausale.Tag = "treasurer.flagbank_grouping:7";
            this.chkRaggProceedCausale.Text = "Raggruppa per causale Incasso";
            this.chkRaggProceedCausale.UseVisualStyleBackColor = true;
            this.chkRaggProceedCausale.CheckedChanged += new System.EventHandler(this.chkRaggProceedCausale_CheckStateChanged);
            // 
            // chkRaggIncCup
            // 
            this.chkRaggIncCup.AutoSize = true;
            this.chkRaggIncCup.Location = new System.Drawing.Point(10, 57);
            this.chkRaggIncCup.Name = "chkRaggIncCup";
            this.chkRaggIncCup.Size = new System.Drawing.Size(121, 17);
            this.chkRaggIncCup.TabIndex = 8;
            this.chkRaggIncCup.Tag = "treasurer.flagbank_grouping:6";
            this.chkRaggIncCup.Text = "Raggruppa per CUP";
            this.chkRaggIncCup.UseVisualStyleBackColor = true;
            // 
            // chkRaggruppaIncassiVersante
            // 
            this.chkRaggruppaIncassiVersante.AutoSize = true;
            this.chkRaggruppaIncassiVersante.Location = new System.Drawing.Point(10, 38);
            this.chkRaggruppaIncassiVersante.Name = "chkRaggruppaIncassiVersante";
            this.chkRaggruppaIncassiVersante.Size = new System.Drawing.Size(144, 17);
            this.chkRaggruppaIncassiVersante.TabIndex = 7;
            this.chkRaggruppaIncassiVersante.Tag = "treasurer.flagbank_grouping:5";
            this.chkRaggruppaIncassiVersante.Text = "Raggruppa per versante";
            this.chkRaggruppaIncassiVersante.UseVisualStyleBackColor = true;
            this.chkRaggruppaIncassiVersante.CheckStateChanged += new System.EventHandler(this.chkRaggruppaIncassiVersante_CheckStateChanged);
            // 
            // chkNonRaggruppIncassi
            // 
            this.chkNonRaggruppIncassi.AutoSize = true;
            this.chkNonRaggruppIncassi.Location = new System.Drawing.Point(10, 19);
            this.chkNonRaggruppIncassi.Name = "chkNonRaggruppIncassi";
            this.chkNonRaggruppIncassi.Size = new System.Drawing.Size(108, 17);
            this.chkNonRaggruppIncassi.TabIndex = 6;
            this.chkNonRaggruppIncassi.Tag = "treasurer.flagbank_grouping:4";
            this.chkNonRaggruppIncassi.Text = "Non raggruppare";
            this.chkNonRaggruppIncassi.UseVisualStyleBackColor = true;
            this.chkNonRaggruppIncassi.CheckStateChanged += new System.EventHandler(this.chkNonRaggruppIncassi_CheckStateChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.checkBox5);
            this.groupBox6.Controls.Add(this.checkBox4);
            this.groupBox6.Controls.Add(this.chkDigitalPayment);
            this.groupBox6.Controls.Add(this.textBox8);
            this.groupBox6.Controls.Add(this.label21);
            this.groupBox6.Controls.Add(this.textBox6);
            this.groupBox6.Controls.Add(this.checkBox1);
            this.groupBox6.Controls.Add(this.label19);
            this.groupBox6.Controls.Add(this.textBox7);
            this.groupBox6.Controls.Add(this.label20);
            this.groupBox6.Location = new System.Drawing.Point(8, 271);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(659, 119);
            this.groupBox6.TabIndex = 32;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Configurazione della trasmissione";
            this.groupBox6.Enter += new System.EventHandler(this.groupBox6_Enter);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(459, 93);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(187, 17);
            this.checkBox5.TabIndex = 35;
            this.checkBox5.Tag = "treasurer.flag:1";
            this.checkBox5.Text = "Abilita Pagamenti Esenti da Spese";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(405, 70);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(248, 17);
            this.checkBox4.TabIndex = 34;
            this.checkBox4.Tag = "treasurer.flag:0";
            this.checkBox4.Text = "Non associare a provvisori nell\'importazioni esiti";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // chkDigitalPayment
            // 
            this.chkDigitalPayment.AutoSize = true;
            this.chkDigitalPayment.Location = new System.Drawing.Point(111, 93);
            this.chkDigitalPayment.Name = "chkDigitalPayment";
            this.chkDigitalPayment.Size = new System.Drawing.Size(300, 17);
            this.chkDigitalPayment.TabIndex = 33;
            this.chkDigitalPayment.Tag = "treasurer.flagedisp:S:N";
            this.chkDigitalPayment.Text = "Gestione Ordinativo Informativo (Annullamenti e Variazioni)";
            this.chkDigitalPayment.UseVisualStyleBackColor = true;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(7, 41);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(311, 20);
            this.textBox8.TabIndex = 2;
            this.textBox8.Tag = "treasurer.spexportinc";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(4, 25);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(107, 13);
            this.label21.TabIndex = 32;
            this.label21.Text = "SP Esporta Reversali";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(346, 41);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(308, 20);
            this.textBox6.TabIndex = 1;
            this.textBox6.Tag = "treasurer.spexportexp";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(111, 70);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(228, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Tag = "treasurer.flagmultiexp:S:N";
            this.checkBox1.Text = "Trasmissione contemporanea di più distinte";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(343, 25);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(101, 13);
            this.label19.TabIndex = 27;
            this.label19.Text = "SP Esporta Mandati";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(9, 82);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(89, 20);
            this.textBox7.TabIndex = 3;
            this.textBox7.Tag = "treasurer.fileextension";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 66);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(92, 13);
            this.label20.TabIndex = 29;
            this.label20.Text = "Estensione del file";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.groupBox14);
            this.groupBox3.Controls.Add(this.groupBox13);
            this.groupBox3.Controls.Add(this.textBox11);
            this.groupBox3.Controls.Add(this.label38);
            this.groupBox3.Controls.Add(this.txtTrasmCode);
            this.groupBox3.Controls.Add(this.label28);
            this.groupBox3.Controls.Add(this.txtcodicesportelloexp);
            this.groupBox3.Controls.Add(this.txtcodiceistitutoexp);
            this.groupBox3.Controls.Add(this.txtcodiceenteexp);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(3, 57);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(659, 208);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dati Esportazione Elettronica";
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.textBox20);
            this.groupBox13.Controls.Add(this.label47);
            this.groupBox13.Controls.Add(this.textBox19);
            this.groupBox13.Controls.Add(this.label46);
            this.groupBox13.Controls.Add(this.textBox18);
            this.groupBox13.Controls.Add(this.label45);
            this.groupBox13.Location = new System.Drawing.Point(6, 144);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(651, 60);
            this.groupBox13.TabIndex = 43;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "SIOPE+";
            // 
            // textBox20
            // 
            this.textBox20.Location = new System.Drawing.Point(486, 16);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(152, 20);
            this.textBox20.TabIndex = 47;
            this.textBox20.Tag = "treasurer.agency_istat_code";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(373, 18);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(98, 13);
            this.label47.TabIndex = 48;
            this.label47.Text = "Codice ISTAT ente";
            // 
            // textBox19
            // 
            this.textBox19.Location = new System.Drawing.Point(192, 37);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(152, 20);
            this.textBox19.TabIndex = 45;
            this.textBox19.Tag = "treasurer.tramite_bt_code";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(7, 37);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(159, 13);
            this.label46.TabIndex = 46;
            this.label46.Text = "Codice Tramite Banca Tesoriera";
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(192, 13);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(152, 20);
            this.textBox18.TabIndex = 43;
            this.textBox18.Tag = "treasurer.tramite_agency_code";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(8, 16);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(99, 13);
            this.label45.TabIndex = 44;
            this.label45.Text = "Codice tramite Ente";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(432, 124);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(89, 20);
            this.textBox11.TabIndex = 37;
            this.textBox11.Tag = "treasurer.flussocrediticode";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(8, 127);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(413, 13);
            this.label38.TabIndex = 38;
            this.label38.Text = "Codice Tipo Flusso censito ed associato al servizio d’incasso sulla Piattaforma I" +
    "ncassi:";
            // 
            // txtTrasmCode
            // 
            this.txtTrasmCode.Location = new System.Drawing.Point(133, 95);
            this.txtTrasmCode.Name = "txtTrasmCode";
            this.txtTrasmCode.Size = new System.Drawing.Size(89, 20);
            this.txtTrasmCode.TabIndex = 35;
            this.txtTrasmCode.Tag = "treasurer.trasmcode";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(9, 99);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(121, 13);
            this.label28.TabIndex = 36;
            this.label28.Text = "Codice Conto Tesoreria:";
            // 
            // txtcodicesportelloexp
            // 
            this.txtcodicesportelloexp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtcodicesportelloexp.Location = new System.Drawing.Point(96, 67);
            this.txtcodicesportelloexp.Name = "txtcodicesportelloexp";
            this.txtcodicesportelloexp.Size = new System.Drawing.Size(555, 20);
            this.txtcodicesportelloexp.TabIndex = 5;
            this.txtcodicesportelloexp.Tag = "treasurer.cabcodefortransmission";
            // 
            // txtcodiceistitutoexp
            // 
            this.txtcodiceistitutoexp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtcodiceistitutoexp.Location = new System.Drawing.Point(96, 43);
            this.txtcodiceistitutoexp.Name = "txtcodiceistitutoexp";
            this.txtcodiceistitutoexp.Size = new System.Drawing.Size(555, 20);
            this.txtcodiceistitutoexp.TabIndex = 4;
            this.txtcodiceistitutoexp.Tag = "treasurer.depcodefortransmission";
            // 
            // txtcodiceenteexp
            // 
            this.txtcodiceenteexp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtcodiceenteexp.Location = new System.Drawing.Point(96, 19);
            this.txtcodiceenteexp.Name = "txtcodiceenteexp";
            this.txtcodiceenteexp.Size = new System.Drawing.Size(555, 20);
            this.txtcodiceenteexp.TabIndex = 3;
            this.txtcodiceenteexp.Tag = "treasurer.agencycodefortransmission";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(8, 67);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 16);
            this.label13.TabIndex = 2;
            this.label13.Text = "Codice Filiale:";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(8, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 16);
            this.label12.TabIndex = 1;
            this.label12.Text = "Codice Istituto:";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(8, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "Codice Ente:";
            // 
            // tabPrincipale
            // 
            this.tabPrincipale.Controls.Add(this.checkBox6);
            this.tabPrincipale.Controls.Add(this.groupBox12);
            this.tabPrincipale.Controls.Add(this.textBox10);
            this.tabPrincipale.Controls.Add(this.txtDescrizione);
            this.tabPrincipale.Controls.Add(this.txtCodIstituto);
            this.tabPrincipale.Controls.Add(this.label35);
            this.tabPrincipale.Controls.Add(this.checkBox2);
            this.tabPrincipale.Controls.Add(this.label4);
            this.tabPrincipale.Controls.Add(this.label1);
            this.tabPrincipale.Controls.Add(this.ckbCassierePredefinito);
            this.tabPrincipale.Controls.Add(this.groupBox1);
            this.tabPrincipale.Controls.Add(this.groupBox2);
            this.tabPrincipale.Location = new System.Drawing.Point(4, 22);
            this.tabPrincipale.Name = "tabPrincipale";
            this.tabPrincipale.Size = new System.Drawing.Size(675, 736);
            this.tabPrincipale.TabIndex = 0;
            this.tabPrincipale.Text = "Principale";
            this.tabPrincipale.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(13, 682);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(251, 17);
            this.checkBox6.TabIndex = 36;
            this.checkBox6.Tag = "treasurer.enable_ndoc_treasurer:S:N";
            this.checkBox6.Text = "Abilita Numerazione dei Documenti per Cassiere";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.textBox1);
            this.groupBox12.Controls.Add(this.label37);
            this.groupBox12.Location = new System.Drawing.Point(8, 127);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(658, 65);
            this.groupBox12.TabIndex = 24;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Fattura Elettronica";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(646, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Tag = "treasurer.departmentname_fe";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(10, 20);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(411, 13);
            this.label37.TabIndex = 0;
            this.label37.Text = "Denominazione del Dipartimento o Amministrazione da inserire nella Fattura Elettr" +
    "onica";
            // 
            // textBox10
            // 
            this.textBox10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox10.Location = new System.Drawing.Point(11, 95);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(656, 20);
            this.textBox10.TabIndex = 22;
            this.textBox10.Tag = "treasurer.header";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(104, 24);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(563, 40);
            this.txtDescrizione.TabIndex = 1;
            this.txtDescrizione.Tag = "treasurer.description";
            // 
            // txtCodIstituto
            // 
            this.txtCodIstituto.Location = new System.Drawing.Point(8, 24);
            this.txtCodIstituto.Name = "txtCodIstituto";
            this.txtCodIstituto.Size = new System.Drawing.Size(88, 20);
            this.txtCodIstituto.TabIndex = 0;
            this.txtCodIstituto.Tag = "treasurer.codetreasurer";
            // 
            // label35
            // 
            this.label35.Location = new System.Drawing.Point(13, 76);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(182, 16);
            this.label35.TabIndex = 23;
            this.label35.Text = "Intestazione Stampe:";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBox2
            // 
            this.checkBox2.Location = new System.Drawing.Point(11, 640);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(491, 36);
            this.checkBox2.TabIndex = 5;
            this.checkBox2.Tag = "treasurer.flagfruitful:F:I";
            this.checkBox2.Text = "Il conto è fruttifero (valore predefinito per le reversali)";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "Codice:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(104, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "Descrizione:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ckbCassierePredefinito
            // 
            this.ckbCassierePredefinito.Location = new System.Drawing.Point(8, 48);
            this.ckbCassierePredefinito.Name = "ckbCassierePredefinito";
            this.ckbCassierePredefinito.Size = new System.Drawing.Size(80, 24);
            this.ckbCassierePredefinito.TabIndex = 2;
            this.ckbCassierePredefinito.Tag = "treasurer.flagdefault:S:N";
            this.ckbCassierePredefinito.Text = "Predefinito";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.gboxSportello);
            this.groupBox1.Controls.Add(this.gboxBanca);
            this.groupBox1.Controls.Add(this.textBox9);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.btnIBAN);
            this.groupBox1.Controls.Add(this.txtIBAN);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.btnBBAN);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.txtBBAN);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtCin);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtNumConto);
            this.groupBox1.Location = new System.Drawing.Point(7, 224);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(659, 243);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Coordinate Bancarie";
            // 
            // gboxSportello
            // 
            this.gboxSportello.Controls.Add(this.btnCab);
            this.gboxSportello.Controls.Add(this.txtCab);
            this.gboxSportello.Controls.Add(this.txtCabDescr);
            this.gboxSportello.Location = new System.Drawing.Point(324, 51);
            this.gboxSportello.Name = "gboxSportello";
            this.gboxSportello.Size = new System.Drawing.Size(328, 73);
            this.gboxSportello.TabIndex = 3;
            this.gboxSportello.TabStop = false;
            this.gboxSportello.Tag = "AutoChoose.txtCab.default.(flagusable<>\'N\')";
            // 
            // btnCab
            // 
            this.btnCab.Location = new System.Drawing.Point(6, 14);
            this.btnCab.Name = "btnCab";
            this.btnCab.Size = new System.Drawing.Size(100, 23);
            this.btnCab.TabIndex = 4;
            this.btnCab.Tag = "choose.cab.default";
            this.btnCab.Text = "CAB";
            // 
            // txtCab
            // 
            this.txtCab.Location = new System.Drawing.Point(6, 47);
            this.txtCab.Name = "txtCab";
            this.txtCab.Size = new System.Drawing.Size(100, 20);
            this.txtCab.TabIndex = 29;
            this.txtCab.Tag = "cab.idcab?treasurer.idcab";
            // 
            // txtCabDescr
            // 
            this.txtCabDescr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCabDescr.Location = new System.Drawing.Point(112, 10);
            this.txtCabDescr.Multiline = true;
            this.txtCabDescr.Name = "txtCabDescr";
            this.txtCabDescr.ReadOnly = true;
            this.txtCabDescr.Size = new System.Drawing.Size(210, 58);
            this.txtCabDescr.TabIndex = 1;
            this.txtCabDescr.TabStop = false;
            this.txtCabDescr.Tag = "cab.description";
            // 
            // gboxBanca
            // 
            this.gboxBanca.Controls.Add(this.txtBanca);
            this.gboxBanca.Controls.Add(this.BancaButton);
            this.gboxBanca.Controls.Add(this.txtDescrBanca);
            this.gboxBanca.Location = new System.Drawing.Point(19, 51);
            this.gboxBanca.Name = "gboxBanca";
            this.gboxBanca.Size = new System.Drawing.Size(299, 73);
            this.gboxBanca.TabIndex = 2;
            this.gboxBanca.TabStop = false;
            this.gboxBanca.Tag = "AutoChoose.txtBanca.default.(flagusable<>\'N\')";
            // 
            // txtBanca
            // 
            this.txtBanca.Location = new System.Drawing.Point(9, 48);
            this.txtBanca.Name = "txtBanca";
            this.txtBanca.Size = new System.Drawing.Size(114, 20);
            this.txtBanca.TabIndex = 3;
            this.txtBanca.Tag = "bank.idbank?treasurer.idbank";
            // 
            // BancaButton
            // 
            this.BancaButton.Location = new System.Drawing.Point(9, 14);
            this.BancaButton.Name = "BancaButton";
            this.BancaButton.Size = new System.Drawing.Size(114, 23);
            this.BancaButton.TabIndex = 2;
            this.BancaButton.Tag = "choose.bank.default.(flagusable<>\'N\')";
            this.BancaButton.Text = "ABI";
            // 
            // txtDescrBanca
            // 
            this.txtDescrBanca.Location = new System.Drawing.Point(129, 10);
            this.txtDescrBanca.Multiline = true;
            this.txtDescrBanca.Name = "txtDescrBanca";
            this.txtDescrBanca.ReadOnly = true;
            this.txtDescrBanca.Size = new System.Drawing.Size(164, 58);
            this.txtDescrBanca.TabIndex = 2;
            this.txtDescrBanca.TabStop = false;
            this.txtDescrBanca.Tag = "bank.description";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(95, 219);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(209, 20);
            this.textBox9.TabIndex = 35;
            this.textBox9.Tag = "treasurer.bic";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(61, 222);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(24, 13);
            this.label23.TabIndex = 34;
            this.label23.Text = "BIC";
            // 
            // btnIBAN
            // 
            this.btnIBAN.Location = new System.Drawing.Point(312, 193);
            this.btnIBAN.Name = "btnIBAN";
            this.btnIBAN.Size = new System.Drawing.Size(176, 22);
            this.btnIBAN.TabIndex = 33;
            this.btnIBAN.TabStop = false;
            this.btnIBAN.Text = "Inserisci direttamente l\'IBAN";
            this.btnIBAN.UseVisualStyleBackColor = true;
            this.btnIBAN.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtIBAN
            // 
            this.txtIBAN.Location = new System.Drawing.Point(96, 194);
            this.txtIBAN.Name = "txtIBAN";
            this.txtIBAN.ReadOnly = true;
            this.txtIBAN.Size = new System.Drawing.Size(208, 20);
            this.txtIBAN.TabIndex = 32;
            this.txtIBAN.TabStop = false;
            this.txtIBAN.Tag = "treasurer.iban";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(55, 196);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(32, 13);
            this.label22.TabIndex = 31;
            this.label22.Text = "IBAN";
            // 
            // btnBBAN
            // 
            this.btnBBAN.Location = new System.Drawing.Point(312, 168);
            this.btnBBAN.Name = "btnBBAN";
            this.btnBBAN.Size = new System.Drawing.Size(176, 23);
            this.btnBBAN.TabIndex = 30;
            this.btnBBAN.TabStop = false;
            this.btnBBAN.Text = "Inserisci direttamente il BBAN";
            this.btnBBAN.Click += new System.EventHandler(this.btnBBAN_Click);
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(48, 169);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(40, 23);
            this.label18.TabIndex = 29;
            this.label18.Text = "BBAN";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBBAN
            // 
            this.txtBBAN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBBAN.Location = new System.Drawing.Point(96, 170);
            this.txtBBAN.Name = "txtBBAN";
            this.txtBBAN.ReadOnly = true;
            this.txtBBAN.Size = new System.Drawing.Size(208, 20);
            this.txtBBAN.TabIndex = 28;
            this.txtBBAN.TabStop = false;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(232, 145);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(248, 16);
            this.label16.TabIndex = 22;
            this.label16.Text = "Nota bene: il C/C deve essere di 12 cifre.";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(168, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(320, 32);
            this.label17.TabIndex = 21;
            this.label17.Text = "Nota: solo inserendo correttamente tutti i dati sarà visualizzato, nelle stampe, " +
    "il BBAN come da regolamento bancario";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "C/C:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCin
            // 
            this.txtCin.Location = new System.Drawing.Point(96, 24);
            this.txtCin.Name = "txtCin";
            this.txtCin.Size = new System.Drawing.Size(64, 20);
            this.txtCin.TabIndex = 1;
            this.txtCin.Tag = "treasurer.cin";
            this.txtCin.Leave += new System.EventHandler(this.txtCin_Leave);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "CIN:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumConto
            // 
            this.txtNumConto.Location = new System.Drawing.Point(96, 144);
            this.txtNumConto.Name = "txtNumConto";
            this.txtNumConto.Size = new System.Drawing.Size(120, 20);
            this.txtNumConto.TabIndex = 10;
            this.txtNumConto.Tag = "treasurer.cc";
            this.txtNumConto.Leave += new System.EventHandler(this.txtNumConto_Leave);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtFaxNumero);
            this.groupBox2.Controls.Add(this.txtFaxPrefisso);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.checkBox3);
            this.groupBox2.Controls.Add(this.txtTelNumero);
            this.groupBox2.Controls.Add(this.txtTelPrefisso);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtProvincia);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtComune);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtCAP);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtIndirizzo);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(8, 473);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(659, 159);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Recapito";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(509, 77);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(136, 77);
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(168, 137);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(16, 16);
            this.label15.TabIndex = 37;
            this.label15.Text = "/";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(168, 107);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(16, 16);
            this.label14.TabIndex = 36;
            this.label14.Text = "/";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtFaxNumero
            // 
            this.txtFaxNumero.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFaxNumero.Location = new System.Drawing.Point(192, 135);
            this.txtFaxNumero.Name = "txtFaxNumero";
            this.txtFaxNumero.Size = new System.Drawing.Size(299, 20);
            this.txtFaxNumero.TabIndex = 8;
            this.txtFaxNumero.Tag = "treasurer.faxnumber";
            // 
            // txtFaxPrefisso
            // 
            this.txtFaxPrefisso.Location = new System.Drawing.Point(96, 135);
            this.txtFaxPrefisso.Name = "txtFaxPrefisso";
            this.txtFaxPrefisso.Size = new System.Drawing.Size(64, 20);
            this.txtFaxPrefisso.TabIndex = 7;
            this.txtFaxPrefisso.Tag = "treasurer.faxprefix";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(8, 134);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 23);
            this.label10.TabIndex = 4;
            this.label10.Text = "Fax:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkBox3
            // 
            this.checkBox3.Location = new System.Drawing.Point(414, 46);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(80, 24);
            this.checkBox3.TabIndex = 21;
            this.checkBox3.Tag = "treasurer.active:S:N";
            this.checkBox3.Text = "Attivo";
            // 
            // txtTelNumero
            // 
            this.txtTelNumero.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTelNumero.Location = new System.Drawing.Point(192, 107);
            this.txtTelNumero.Name = "txtTelNumero";
            this.txtTelNumero.Size = new System.Drawing.Size(299, 20);
            this.txtTelNumero.TabIndex = 6;
            this.txtTelNumero.Tag = "treasurer.phonenumber";
            // 
            // txtTelPrefisso
            // 
            this.txtTelPrefisso.Location = new System.Drawing.Point(96, 107);
            this.txtTelPrefisso.Name = "txtTelPrefisso";
            this.txtTelPrefisso.Size = new System.Drawing.Size(64, 20);
            this.txtTelPrefisso.TabIndex = 5;
            this.txtTelPrefisso.Tag = "treasurer.phoneprefix";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(8, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 23);
            this.label9.TabIndex = 30;
            this.label9.Text = "Telefono:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProvincia
            // 
            this.txtProvincia.Location = new System.Drawing.Point(561, 48);
            this.txtProvincia.Name = "txtProvincia";
            this.txtProvincia.Size = new System.Drawing.Size(84, 20);
            this.txtProvincia.TabIndex = 3;
            this.txtProvincia.Tag = "treasurer.country";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(491, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 23);
            this.label8.TabIndex = 28;
            this.label8.Text = "Provincia";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtComune
            // 
            this.txtComune.Location = new System.Drawing.Point(96, 48);
            this.txtComune.Name = "txtComune";
            this.txtComune.Size = new System.Drawing.Size(303, 20);
            this.txtComune.TabIndex = 2;
            this.txtComune.Tag = "treasurer.city";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(40, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 23);
            this.label7.TabIndex = 26;
            this.label7.Text = "Comune:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCAP
            // 
            this.txtCAP.Location = new System.Drawing.Point(96, 78);
            this.txtCAP.Name = "txtCAP";
            this.txtCAP.Size = new System.Drawing.Size(96, 20);
            this.txtCAP.TabIndex = 4;
            this.txtCAP.Tag = "treasurer.cap";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 23);
            this.label6.TabIndex = 24;
            this.label6.Text = "CAP:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtIndirizzo
            // 
            this.txtIndirizzo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIndirizzo.Location = new System.Drawing.Point(96, 19);
            this.txtIndirizzo.Name = "txtIndirizzo";
            this.txtIndirizzo.Size = new System.Drawing.Size(555, 20);
            this.txtIndirizzo.TabIndex = 1;
            this.txtIndirizzo.Tag = "treasurer.address";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 23);
            this.label2.TabIndex = 22;
            this.label2.Text = "Indirizzo:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPrincipale);
            this.tabControl1.Controls.Add(this.tabTrasmEl);
            this.tabControl1.Controls.Add(this.tabEP);
            this.tabControl1.Controls.Add(this.tabCBI);
            this.tabControl1.Controls.Add(this.tabAttributi);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(8, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(683, 762);
            this.tabControl1.TabIndex = 26;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox17);
            this.tabPage1.Controls.Add(this.label44);
            this.tabPage1.Controls.Add(this.textBox16);
            this.tabPage1.Controls.Add(this.label43);
            this.tabPage1.Controls.Add(this.textBox15);
            this.tabPage1.Controls.Add(this.label42);
            this.tabPage1.Controls.Add(this.textBox14);
            this.tabPage1.Controls.Add(this.label41);
            this.tabPage1.Controls.Add(this.textBox13);
            this.tabPage1.Controls.Add(this.label40);
            this.tabPage1.Controls.Add(this.textBox12);
            this.tabPage1.Controls.Add(this.label39);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(675, 736);
            this.tabPage1.TabIndex = 5;
            this.tabPage1.Text = "Cartella ftp associata";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(19, 82);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(394, 20);
            this.textBox17.TabIndex = 11;
            this.textBox17.Tag = "treasurer.ftpdir";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(16, 66);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(57, 13);
            this.label44.TabIndex = 10;
            this.label44.Text = "Cartella ftp";
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(201, 240);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(81, 20);
            this.textBox16.TabIndex = 9;
            this.textBox16.Tag = "treasurer.pasvmode";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(198, 224);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(87, 13);
            this.label43.TabIndex = 8;
            this.label43.Text = "PASV mode S/N";
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(19, 240);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(81, 20);
            this.textBox15.TabIndex = 7;
            this.textBox15.Tag = "treasurer.ftpport";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(16, 224);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(47, 13);
            this.label42.TabIndex = 6;
            this.label42.Text = "Porta ftp";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(19, 187);
            this.textBox14.Name = "textBox14";
            this.textBox14.PasswordChar = '*';
            this.textBox14.Size = new System.Drawing.Size(394, 20);
            this.textBox14.TabIndex = 5;
            this.textBox14.Tag = "treasurer.ftppassword";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(16, 171);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(68, 13);
            this.label41.TabIndex = 4;
            this.label41.Text = "Password ftp";
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(19, 135);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(394, 20);
            this.textBox13.TabIndex = 3;
            this.textBox13.Tag = "treasurer.ftpuser";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(16, 119);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(54, 13);
            this.label40.TabIndex = 2;
            this.label40.Text = "Utente ftp";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(19, 32);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(394, 20);
            this.textBox12.TabIndex = 1;
            this.textBox12.Tag = "treasurer.ftpaddress";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(16, 16);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(60, 13);
            this.label39.TabIndex = 0;
            this.label39.Text = "Indirizzo ftp";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.rdbAlfanumerico);
            this.groupBox14.Controls.Add(this.rdbNumerico);
            this.groupBox14.Location = new System.Drawing.Point(236, 90);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(241, 28);
            this.groupBox14.TabIndex = 40;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Destinazione";
            // 
            // rdbAlfanumerico
            // 
            this.rdbAlfanumerico.Location = new System.Drawing.Point(149, 7);
            this.rdbAlfanumerico.Name = "rdbAlfanumerico";
            this.rdbAlfanumerico.Size = new System.Drawing.Size(84, 16);
            this.rdbAlfanumerico.TabIndex = 1;
            this.rdbAlfanumerico.Tag = "treasurer.flag::2";
            this.rdbAlfanumerico.Text = "Vincolata";
            // 
            // rdbNumerico
            // 
            this.rdbNumerico.Location = new System.Drawing.Point(70, 8);
            this.rdbNumerico.Name = "rdbNumerico";
            this.rdbNumerico.Size = new System.Drawing.Size(84, 16);
            this.rdbNumerico.TabIndex = 0;
            this.rdbNumerico.Tag = "treasurer.flag::#2";
            this.rdbNumerico.Text = "Libera";
            // 
            // Frm_treasurer_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(693, 767);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Frm_treasurer_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmistitutocassiere";
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
            this.tabCBI.ResumeLayout(false);
            this.tabCBI.PerformLayout();
            this.grpBoxCBI.ResumeLayout(false);
            this.grpBoxCBI.PerformLayout();
            this.grpCABcbi.ResumeLayout(false);
            this.grpCABcbi.PerformLayout();
            this.grpabicbi.ResumeLayout(false);
            this.grpabicbi.PerformLayout();
            this.tabEP.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabTrasmEl.ResumeLayout(false);
            this.tabTrasmEl.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.tabPrincipale.ResumeLayout(false);
            this.tabPrincipale.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gboxSportello.ResumeLayout(false);
            this.gboxSportello.PerformLayout();
            this.gboxBanca.ResumeLayout(false);
            this.gboxBanca.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox14.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void btnBBAN_Click(object sender, System.EventArgs e) {
			inserisciBBAN();
		}

        public void metaData_AfterLink() {
            DS.treasurer.Columns["flagfruitful"].SetDenyNull();
            DS.treasurer.Columns["flagedisp"].SetDenyNull();
            DS.treasurer.Columns["enable_ndoc_treasurer"].SetDenyNull();
            DS.treasurer.Columns["active"].SetDenyNull();
            DS.treasurer.Columns["flag"].SetDenyNull();

            var tUniConfig = getTable("uniconfig");
            if ((tUniConfig != null) && (tUniConfig.Rows.Count > 0)) {
                var r = tUniConfig.Rows[0];
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
                    tabControl1.TabPages.Remove(tabAttributi);
                }
            }
        }

        private void chkNonRaggruppIncassi_CheckStateChanged(object sender, EventArgs e) {
            if (chkNonRaggruppIncassi.CheckState == CheckState.Checked){
                   chkRaggruppaIncassiVersante.Checked = false;
                   chkRaggProceedCausale.Checked = false;
                   chkRaggIncCup.Checked = false;
                }
            }

        private void chkRaggruppaIncassiVersante_CheckStateChanged(object sender, EventArgs e) {
            if (chkRaggruppaIncassiVersante.CheckState == CheckState.Checked) {
                chkNonRaggruppIncassi.Checked = false;
                chkRaggProceedCausale.Checked = false;
            }
        }

        private void chkRaggProceedCausale_CheckStateChanged(object sender, EventArgs e) {
            if (chkRaggProceedCausale.CheckState == CheckState.Checked) {
                chkNonRaggruppIncassi.Checked = false;
                chkRaggruppaIncassiVersante.Checked = false;

            }
        }


        private void chkNonRaggPayment_CheckStateChanged(object sender, EventArgs e) {
            if (chkNonRaggPayment.CheckState == CheckState.Checked) {
                chkRaggPaymentCausale.Checked = false;
                chkRaggPaymentmodalita.Checked = false;
                chkRaggPayCupCig.Checked = false;
            }
        }

        private void chkRaggPaymentCausale_CheckStateChanged(object sender, EventArgs e) {
            if (chkRaggPaymentCausale.CheckState == CheckState.Checked) {
                chkNonRaggPayment.Checked = false;
                chkRaggPaymentmodalita.Checked = false;
            }
        }

        private void chkRaggPaymentmodalita_CheckStateChanged(object sender, EventArgs e) {
            if (chkRaggPaymentmodalita.CheckState == CheckState.Checked) {
                chkNonRaggPayment.Checked = false;
                chkRaggPaymentCausale.Checked = false;
            }

        }


        private void chkRaggIncCupCig_CheckStateChanged(object sender, EventArgs e) {
            if (chkRaggIncCup.CheckState == CheckState.Checked)
                chkNonRaggruppIncassi.Checked = false;
        }

        private void chkRaggPayCupCig_CheckStateChanged(object sender, EventArgs e) {
            if (chkRaggPayCupCig.CheckState == CheckState.Checked)
                chkNonRaggPayment.Checked = false;
        }

		
        void clearCab() {
            DS.cab.Clear();
            txtCab.Text = "";
            txtCabDescr.Text = "";
            if (!isEmpty) {
                currentRow["idcab"] = DBNull.Value;
            }

        }

		public void metaData_AfterClear() {
			txtBBAN.Text = "";
			azzeraVarDiConfronto();
            setAutoCab(DBNull.Value);
        }


		public void metaData_AfterFill() {
            if (firstFillForThisRow) {
                setAutoCab(currentRow["idbank"]);
            }

			if (firstFillForThisRow && editMode) {
				assegnaVarDiConfronto();
				calcolaBBAN();
			}
		}

		public void assegnaVarDiConfronto() {
			azzeraVarDiConfronto();

			if (isEmpty) return;
			var curr = currentRow;

			lastCIN = (curr["cin"] == DBNull.Value) ? "" : curr["cin"].ToString().ToUpper();
			lastABI = curr["idbank"];
            lastCAB = curr["idcab"];
			lastCC = (curr["cc"] == DBNull.Value) ? "" : curr["cc"].ToString();
		}

		public void azzeraVarDiConfronto() {
			string empty = "";
			lastCIN = empty;
			lastABI = DBNull.Value;
			lastCAB = DBNull.Value;
			lastCC = empty;
		}

		private void inserisciBBAN() {
			var BBAN = new frmaskbban(0);
			if (BBAN.ShowDialog()!=DialogResult.OK) return;
			if (BBAN.insertedBBAN == "") return;

            bool inserisciDati = controllaBanca(BBAN.insertedBBAN); 
			if (!inserisciDati) return;
			string CIN = BBAN.insertedBBAN.Substring(0,1).ToUpper();
			string ABI = BBAN.insertedBBAN.Substring(1,5);
			string CAB = BBAN.insertedBBAN.Substring(6,5);
			string CC = BBAN.insertedBBAN.Substring(11,12);
            string iban = CfgFn.calcolaIBAN("IT", BBAN.insertedBBAN);
            var curr = currentRow;
			if (insertMode || editMode) {
                curr["cin"] = CIN;
                curr["idbank"] = ABI;
                curr["idcab"] = CAB;
                curr["cc"] = CC;
                curr["iban"] = iban;
				freshForm();
			}
			else {
                txtBanca.Text = ABI;
                txtCab.Text = CAB;
                txtCin.Text = CIN;
				txtNumConto.Text = CC;
			}
			txtBBAN.Text = BBAN.insertedBBAN;
            txtIBAN.Text = iban;
		}

        private bool controllaBanca(string insertedBBAN) {
            string ABI = insertedBBAN.Substring(1, 5);
			var filtroBanca = eq("idbank", ABI);
			object codiceABI = readValue("bank", filtroBanca, "idbank");
			if (codiceABI == null) {
                showError("La banca inserita nell'IBAN non esiste in Easy. Deve essere inserito in Anagrafiche - ABI (Banche)");
				return false;
			}
            string CAB = insertedBBAN.Substring(6, 5);
			object codiceCAB = readValue("cab", filtroBanca & eq("idcab", CAB), "idcab");
			if (codiceCAB == null) {
				showError("Lo sportello inserito nell'IBAN non esiste in Easy. Deve essere inserito in Anagrafiche - CAB (Filiali)");
				return false;
			}
			return true;
		}

		private void txtCin_Leave(object sender, System.EventArgs e) {
			if (inChiusura) return;
			if (isEmpty) return;
			if (txtCin.Text == "") {
				txtBBAN.Text = "";
				lastCIN = "";
				return;
			}
			if (lastCIN == txtCin.Text.ToUpper()) return;
			lastCIN = txtCin.Text.ToUpper();
			calcolaBBAN();
		}

		private void txtNumConto_Leave(object sender, System.EventArgs e) {
			if (inChiusura) return;
			if (isEmpty) return;
			if (txtNumConto.Text == "") {
				txtBBAN.Text = "";
				lastCC = "";
				return;
			}
			if (lastCC == txtNumConto.Text) return;
			lastCC = txtNumConto.Text;
			calcolaBBAN();
		}
        void setAutoCab(object idbank) {
            string Autochoose = "AutoChoose.txtCab.default.";
            string Choose = "Choose.cab.default.";
            MetaExpression filter;
            if (idbank != DBNull.Value) {
                //Imposta il filtro sulla banca nello sportello
                filter = mCmp(new {idbank, flagusable = "S"}); //(qhs.CmpEq("idbank", idbank), qhs.CmpNe("flagusable", "N"));
            }
            else {
                //Rimuove il filtro sulla banca nello sportello
                filter = eq("flagusable", "S");
            }

            gboxSportello.Tag = Autochoose + toString(filter);
            btnCab.Tag = Choose + toString(filter);

            controller.SetAutoMode(gboxSportello);
        }

		public void metaData_AfterRowSelect(DataTable T, DataRow R) {
            if (T.TableName == "bank" && drawStateIsDone) {
                if (R == null) {
                    setAutoCab(DBNull.Value);
                }
                else {
                    setAutoCab(R["idbank"]);
                }
                clearCab();
             }

			if (isEmpty) return;
			switch(T.TableName) {
				case "bank": {

					if (R == null) {
						lastABI = DBNull.Value;
						txtBBAN.Text = "";
						return;
					}
					if (lastABI.Equals(R["idbank"])) return;
					lastABI = R["idbank"];
					//calcolaBBAN();
					break;
				}
				case "cab": {
                    if (R != null && drawStateIsDone && txtBanca.Text == "") {
                        DS.bank.Clear();
                        var r = DS.bank.get(conn, mCmp(R, "idbank"));// anche mCmp(new {idbank}) eq("idbank",R["idbank"])
                        selectIntoTable(DS.bank, mCmp(R, "idbank"));
                        if (DS.bank.Rows.Count > 0) {
                            var B = DS.bank.First();
                            txtBanca.Text = B["idbank"].ToString();
                            txtDescrBanca.Text = B["description"].ToString();
                        }
                        setAutoCab(R["idbank"]);
                    }

					if (R == null) {
						lastCAB = DBNull.Value;
						txtBBAN.Text = "";
						return;
					}
					if (lastCAB.Equals(R["idcab"])) return;
					lastCAB = R["idcab"];
					calcolaBBAN();
					break;
				}
			}
		}

		private void calcolaBBAN() {
			if (isEmpty) return;
			if (drawStateIsDone) getFormData();
			var curr = DS.treasurer.First();
			bool puoiCalcolare =
				((curr["cin"] != DBNull.Value) &&
				(curr["idbank"] != DBNull.Value) &&
				(curr["idcab"] != DBNull.Value) &&
				(curr["cc"] != DBNull.Value) &&
				(curr["cin"].ToString() != "") &&
				(curr["idbank"].ToString() != "") &&
				(curr["idcab"].ToString() != "") &&
				(curr["cc"].ToString() != ""));
			if (!puoiCalcolare) {
				txtBBAN.Text = "";
				return;
			}
            curr["cin"] = curr["cin"].ToString().ToUpper();
			bool cinCorretto = CfgFn.CheckCIN(curr["cin"].ToString(),curr["idcab"].ToString(),curr["idbank"].ToString(),curr["cc"].ToString());
			if (cinCorretto) {
				txtBBAN.Text = curr["cin"].ToString() + curr["idbank"].ToString() + curr["idcab"].ToString() + curr["cc"].ToString();
                txtIBAN.Text = CfgFn.calcolaIBAN("IT", txtBBAN.Text);
                curr["iban"] = txtIBAN.Text;
			}
			else {
				txtBBAN.Text = "CIN non corretto!";
                txtIBAN.Text = null;
			}
        }

        private void button3_Click(object sender, EventArgs e) {
            var frm = new FrmAskIban(txtIBAN.Text);
            if (frm.ShowDialog(this) != DialogResult.OK) return;
            if (frm.insertedIBAN == "") {
                txtIBAN.Text = frm.insertedIBAN;
                return;
            }

            if (!frm.insertedIBAN.StartsWith("IT")) {
                if (insertMode || editMode) {
                    var curr = DS.treasurer.First();
                    curr["iban"] = frm.insertedIBAN;
                    curr["cin"] = DBNull.Value;
                    curr["idbank"] = DBNull.Value;
                    curr["idcab"] = DBNull.Value;
                    curr["cc"] = DBNull.Value;
                    freshForm();
                }

                return;
            }

            if (!controllaBanca(frm.insertedIBAN.Substring(4))) return;

            string bban = frm.insertedIBAN.Substring(4);
            string CIN = bban.Substring(0, 1).ToUpper();
            string ABI = bban.Substring(1, 5);
            string CAB = bban.Substring(6, 5);
            string CC = bban.Substring(11, 12);
            if (insertMode || editMode) {
                var curr = DS.treasurer.First();
                curr.cin= CIN;
                curr.idbank = ABI;
                curr.idcab = CAB;
                curr.cc = CC;
                curr.iban = frm.insertedIBAN;
                freshForm();
            }
            else {
                txtBanca.Text = ABI;
                txtCab.Text = CAB;
                txtCin.Text = CIN;
                txtNumConto.Text = CC;
            }

            txtBBAN.Text = frm.insertedIBAN.Substring(4);
            txtIBAN.Text = frm.insertedIBAN;
        }

        private void btnIBANcbi_Click(object sender, EventArgs e) {
            var frm = new FrmAskIban(txtIBANcbi.Text);
            if (frm.ShowDialog(this) != DialogResult.OK) return;
            if (frm.insertedIBAN == "") {
                txtIBANcbi.Text = frm.insertedIBAN;
                return;
            }

            if (!frm.insertedIBAN.StartsWith("IT")) {
                if (insertMode || editMode) {
                    var curr = DS.treasurer.First();
                    curr["ibancbi"] = frm.insertedIBAN;
                    curr["cincbi"] = DBNull.Value;
                    curr["idbankcbi"] = DBNull.Value;
                    curr["idcabcbi"] = DBNull.Value;
                    curr["cccbi"] = DBNull.Value;
                    freshForm();
                }

                return;
            }

            bool inserisciDati = controllaBanca(frm.insertedIBAN.Substring(4));
            if (!inserisciDati) return;

            string bban = frm.insertedIBAN.Substring(4);
            string CINcbi = bban.Substring(0, 1).ToUpper();
            string ABIcbi = bban.Substring(1, 5);
            string CABcbi = bban.Substring(6, 5);
            string CCcbi = bban.Substring(11, 12);
            if (insertMode || editMode) {
                var curr = DS.treasurer.First();
                curr["cincbi"] = CINcbi;
                curr["idbankcbi"] = ABIcbi;
                curr["idcabcbi"] = CABcbi;
                curr["cccbi"] = CCcbi;
                curr["ibancbi"] = frm.insertedIBAN;
                freshForm();
            }
            else {
                txtABIcbi.Text = ABIcbi;
                txtCABcbi.Text = CABcbi;
                txtcincbi.Text = CINcbi;
                txtCCcbi.Text = CCcbi;
            }

            txtIBANcbi.Text = frm.insertedIBAN;


        }

        private void btnChooseDir_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = txtDir.Text;
            var res = folderBrowserDialog1.ShowDialog(this);
            if (res != DialogResult.OK) return;
            txtDir.Text = folderBrowserDialog1.SelectedPath;
        }

        private void groupBox6_Enter(object sender, EventArgs e) {

        }
    }
}
