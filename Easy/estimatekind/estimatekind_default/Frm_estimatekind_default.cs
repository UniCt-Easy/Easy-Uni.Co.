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
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;




namespace estimatekind_default
{
	/// <summary>
	/// Summary description for Frm_estimatekind_default.
	/// </summary>
	public class Frm_estimatekind_default : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.ComboBox cmbUPB;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.GroupBox groupBox1;
		public estimatekind_default.vistaForm DS;
		private System.Windows.Forms.ToolBarButton seleziona;
		private System.Windows.Forms.ToolBarButton impostaricerca;
		private System.Windows.Forms.ToolBarButton effettuaricerca;
		private System.Windows.Forms.ToolBarButton modifica;
		private System.Windows.Forms.ToolBarButton inserisci;
		private System.Windows.Forms.ToolBarButton inseriscicopia;
		private System.Windows.Forms.ToolBarButton elimina;
		private System.Windows.Forms.ToolBarButton Salva;
		private System.Windows.Forms.ToolBarButton aggiorna;
		private System.Windows.Forms.ToolBarButton btnGotoPrev;
		private System.Windows.Forms.ToolBarButton btnGotoNext;
		private System.Windows.Forms.ToolBarButton btnAffianca;
        private System.Windows.Forms.ToolBarButton btnEditNotes;
        private System.Windows.Forms.ImageList images;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.TextBox textBox11;
		private System.Windows.Forms.TextBox textBox12;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBox13;
		private System.Windows.Forms.TextBox textBox14;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.TextBox txtDeltaPerc;
		private System.Windows.Forms.TextBox txDeltaAmount;
        private GroupBox groupBox20;
        private RadioButton radioButton3;
        private RadioButton radioButton4;
        private TabControl tabControl1;
        private TabPage tabGenerale;
        private TabPage tabAttributi;
        private CheckBox checkBox3;
        private TabPage tabPage1;
        private TabControl tabControlReport;
        private TabPage tabPage4;
        private TextBox textBox16;
        private TabPage tabPage5;
        private TextBox textBox17;
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
        private GroupBox gboxUPB;
        public TextBox txtUPB;
        private TextBox txtDescrUPB;
        private Button btnUPBCode;
        private TabPage tabPage2;
        private GroupBox gBoxIvaKind;
        private Button btnTipo;
        private ComboBox cmbTipoIVA;
        private TextBox txtIva;
        private Label label13;
        private Label lblPercIndeduc;
        private TextBox txtPercIndeduc;
        private CheckBox chkFlag;
        private CheckBox checkBox4;
        private CheckBox checkBox5;
        private System.ComponentModel.IContainer components;

		public Frm_estimatekind_default()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			HelpForm.SetDenyNull(DS.estimatekind.Columns["linktoinvoice"], true);
			HelpForm.SetDenyNull(DS.estimatekind.Columns["multireg"], true);
            HelpForm.SetDenyNull(DS.estimatekind.Columns["flag_autodocnumbering"], true);
            HelpForm.SetDenyNull(DS.estimatekind.Columns["flag"], true);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_estimatekind_default));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbUPB = new System.Windows.Forms.ComboBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.seleziona = new System.Windows.Forms.ToolBarButton();
            this.impostaricerca = new System.Windows.Forms.ToolBarButton();
            this.effettuaricerca = new System.Windows.Forms.ToolBarButton();
            this.modifica = new System.Windows.Forms.ToolBarButton();
            this.inserisci = new System.Windows.Forms.ToolBarButton();
            this.inseriscicopia = new System.Windows.Forms.ToolBarButton();
            this.elimina = new System.Windows.Forms.ToolBarButton();
            this.Salva = new System.Windows.Forms.ToolBarButton();
            this.aggiorna = new System.Windows.Forms.ToolBarButton();
            this.btnGotoPrev = new System.Windows.Forms.ToolBarButton();
            this.btnGotoNext = new System.Windows.Forms.ToolBarButton();
            this.btnAffianca = new System.Windows.Forms.ToolBarButton();
            this.btnEditNotes = new System.Windows.Forms.ToolBarButton();
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGenerale = new System.Windows.Forms.TabPage();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.chkFlag = new System.Windows.Forms.CheckBox();
            this.gboxUPB = new System.Windows.Forms.GroupBox();
            this.txtUPB = new System.Windows.Forms.TextBox();
            this.txtDescrUPB = new System.Windows.Forms.TextBox();
            this.btnUPBCode = new System.Windows.Forms.Button();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.txtDeltaPerc = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txDeltaAmount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControlReport = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gBoxIvaKind = new System.Windows.Forms.GroupBox();
            this.btnTipo = new System.Windows.Forms.Button();
            this.cmbTipoIVA = new System.Windows.Forms.ComboBox();
            this.DS = new estimatekind_default.vistaForm();
            this.txtIva = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lblPercIndeduc = new System.Windows.Forms.Label();
            this.txtPercIndeduc = new System.Windows.Forms.TextBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabGenerale.SuspendLayout();
            this.gboxUPB.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.tabAttributi.SuspendLayout();
            this.gboxclass05.SuspendLayout();
            this.gboxclass04.SuspendLayout();
            this.gboxclass03.SuspendLayout();
            this.gboxclass02.SuspendLayout();
            this.gboxclass01.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControlReport.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.gBoxIvaKind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(0, 0);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            // 
            // cmbUPB
            // 
            this.cmbUPB.Location = new System.Drawing.Point(0, 0);
            this.cmbUPB.Name = "cmbUPB";
            this.cmbUPB.Size = new System.Drawing.Size(121, 21);
            this.cmbUPB.TabIndex = 0;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(0, 0);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 0;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(0, 0);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 20);
            this.textBox7.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 0;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(0, 0);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 20);
            this.textBox6.TabIndex = 0;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(0, 0);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 0;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(0, 0);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 0;
            // 
            // seleziona
            // 
            this.seleziona.Name = "seleziona";
            // 
            // impostaricerca
            // 
            this.impostaricerca.Name = "impostaricerca";
            // 
            // effettuaricerca
            // 
            this.effettuaricerca.Name = "effettuaricerca";
            // 
            // modifica
            // 
            this.modifica.Name = "modifica";
            // 
            // inserisci
            // 
            this.inserisci.Name = "inserisci";
            // 
            // inseriscicopia
            // 
            this.inseriscicopia.Name = "inseriscicopia";
            // 
            // elimina
            // 
            this.elimina.Name = "elimina";
            // 
            // Salva
            // 
            this.Salva.Name = "Salva";
            // 
            // aggiorna
            // 
            this.aggiorna.Name = "aggiorna";
            // 
            // btnGotoPrev
            // 
            this.btnGotoPrev.Name = "btnGotoPrev";
            // 
            // btnGotoNext
            // 
            this.btnGotoNext.Name = "btnGotoNext";
            // 
            // btnAffianca
            // 
            this.btnAffianca.Name = "btnAffianca";
            // 
            // btnEditNotes
            // 
            this.btnEditNotes.Name = "btnEditNotes";
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
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabGenerale);
            this.tabControl1.Controls.Add(this.tabAttributi);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(624, 502);
            this.tabControl1.TabIndex = 36;
            // 
            // tabGenerale
            // 
            this.tabGenerale.Controls.Add(this.checkBox5);
            this.tabGenerale.Controls.Add(this.checkBox4);
            this.tabGenerale.Controls.Add(this.chkFlag);
            this.tabGenerale.Controls.Add(this.gboxUPB);
            this.tabGenerale.Controls.Add(this.checkBox3);
            this.tabGenerale.Controls.Add(this.label12);
            this.tabGenerale.Controls.Add(this.groupBox20);
            this.tabGenerale.Controls.Add(this.label11);
            this.tabGenerale.Controls.Add(this.label23);
            this.tabGenerale.Controls.Add(this.textBox14);
            this.tabGenerale.Controls.Add(this.label22);
            this.tabGenerale.Controls.Add(this.textBox13);
            this.tabGenerale.Controls.Add(this.txtDeltaPerc);
            this.tabGenerale.Controls.Add(this.label10);
            this.tabGenerale.Controls.Add(this.txDeltaAmount);
            this.tabGenerale.Controls.Add(this.label9);
            this.tabGenerale.Controls.Add(this.checkBox2);
            this.tabGenerale.Controls.Add(this.label8);
            this.tabGenerale.Controls.Add(this.checkBox1);
            this.tabGenerale.Controls.Add(this.textBox12);
            this.tabGenerale.Controls.Add(this.textBox11);
            this.tabGenerale.Controls.Add(this.textBox9);
            this.tabGenerale.Controls.Add(this.textBox10);
            this.tabGenerale.Controls.Add(this.label7);
            this.tabGenerale.Location = new System.Drawing.Point(4, 22);
            this.tabGenerale.Name = "tabGenerale";
            this.tabGenerale.Padding = new System.Windows.Forms.Padding(3);
            this.tabGenerale.Size = new System.Drawing.Size(616, 476);
            this.tabGenerale.TabIndex = 0;
            this.tabGenerale.Text = "Generale";
            this.tabGenerale.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.Location = new System.Drawing.Point(328, 242);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(280, 28);
            this.checkBox4.TabIndex = 37;
            this.checkBox4.Tag = "estimatekind.flag:1";
            this.checkBox4.Text = "Rimborso Prestazione";
            // 
            // chkFlag
            // 
            this.chkFlag.Location = new System.Drawing.Point(328, 208);
            this.chkFlag.Name = "chkFlag";
            this.chkFlag.Size = new System.Drawing.Size(280, 28);
            this.chkFlag.TabIndex = 36;
            this.chkFlag.Tag = "estimatekind.flag:0";
            this.chkFlag.Text = "Accertamenti differiti nella fase incasso";
            // 
            // gboxUPB
            // 
            this.gboxUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxUPB.Controls.Add(this.txtUPB);
            this.gboxUPB.Controls.Add(this.txtDescrUPB);
            this.gboxUPB.Controls.Add(this.btnUPBCode);
            this.gboxUPB.Location = new System.Drawing.Point(10, 93);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(598, 109);
            this.gboxUPB.TabIndex = 35;
            this.gboxUPB.TabStop = false;
            this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
            // 
            // txtUPB
            // 
            this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUPB.Location = new System.Drawing.Point(3, 83);
            this.txtUPB.Name = "txtUPB";
            this.txtUPB.Size = new System.Drawing.Size(586, 20);
            this.txtUPB.TabIndex = 6;
            this.txtUPB.Tag = "upb.codeupb?x";
            // 
            // txtDescrUPB
            // 
            this.txtDescrUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrUPB.Location = new System.Drawing.Point(140, 10);
            this.txtDescrUPB.Multiline = true;
            this.txtDescrUPB.Name = "txtDescrUPB";
            this.txtDescrUPB.ReadOnly = true;
            this.txtDescrUPB.Size = new System.Drawing.Size(449, 67);
            this.txtDescrUPB.TabIndex = 4;
            this.txtDescrUPB.TabStop = false;
            this.txtDescrUPB.Tag = "upb.title";
            // 
            // btnUPBCode
            // 
            this.btnUPBCode.BackColor = System.Drawing.SystemColors.Control;
            this.btnUPBCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUPBCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUPBCode.Location = new System.Drawing.Point(6, 57);
            this.btnUPBCode.Name = "btnUPBCode";
            this.btnUPBCode.Size = new System.Drawing.Size(112, 20);
            this.btnUPBCode.TabIndex = 2;
            this.btnUPBCode.TabStop = false;
            this.btnUPBCode.Tag = " manage.upb.tree";
            this.btnUPBCode.Text = "UPB:";
            this.btnUPBCode.UseVisualStyleBackColor = false;
            // 
            // checkBox3
            // 
            this.checkBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox3.Location = new System.Drawing.Point(294, 7);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(97, 26);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Tag = "estimatekind.active:S:N";
            this.checkBox3.Text = "Attivo";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(23, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 16);
            this.label12.TabIndex = 15;
            this.label12.Text = "Codice:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.radioButton3);
            this.groupBox20.Controls.Add(this.radioButton4);
            this.groupBox20.Location = new System.Drawing.Point(9, 282);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(296, 56);
            this.groupBox20.TabIndex = 9;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "Numerazione dei contratti attivi";
            // 
            // radioButton3
            // 
            this.radioButton3.Location = new System.Drawing.Point(8, 16);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(96, 16);
            this.radioButton3.TabIndex = 1;
            this.radioButton3.Tag = "estimatekind.flag_autodocnumbering:N";
            this.radioButton3.Text = "Manuale";
            // 
            // radioButton4
            // 
            this.radioButton4.Location = new System.Drawing.Point(8, 32);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(96, 16);
            this.radioButton4.TabIndex = 2;
            this.radioButton4.Tag = "estimatekind.flag_autodocnumbering:S";
            this.radioButton4.Text = "Automatica";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(7, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Descrizione";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(197, 240);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(112, 16);
            this.label23.TabIndex = 34;
            this.label23.Text = "Importo Scostamento";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox14
            // 
            this.textBox14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox14.Location = new System.Drawing.Point(92, 39);
            this.textBox14.Multiline = true;
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(516, 48);
            this.textBox14.TabIndex = 3;
            this.textBox14.Tag = "estimatekind.description";
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(205, 200);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(96, 16);
            this.label22.TabIndex = 0;
            this.label22.Text = "% Scostamento";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(92, 9);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(181, 20);
            this.textBox13.TabIndex = 1;
            this.textBox13.Tag = "estimatekind.idestimkind";
            // 
            // txtDeltaPerc
            // 
            this.txtDeltaPerc.Location = new System.Drawing.Point(229, 216);
            this.txtDeltaPerc.Name = "txtDeltaPerc";
            this.txtDeltaPerc.Size = new System.Drawing.Size(72, 20);
            this.txtDeltaPerc.TabIndex = 7;
            this.txtDeltaPerc.Tag = "estimatekind.deltapercentage.fixed.4..%.100";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(10, 341);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 16);
            this.label10.TabIndex = 20;
            this.label10.Text = "Ufficio Emittente:";
            // 
            // txDeltaAmount
            // 
            this.txDeltaAmount.Location = new System.Drawing.Point(197, 256);
            this.txDeltaAmount.Name = "txDeltaAmount";
            this.txDeltaAmount.Size = new System.Drawing.Size(104, 20);
            this.txDeltaAmount.TabIndex = 8;
            this.txDeltaAmount.Tag = "estimatekind.deltaamount";
            this.txDeltaAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(10, 381);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 16);
            this.label9.TabIndex = 21;
            this.label9.Text = "Telefono:";
            // 
            // checkBox2
            // 
            this.checkBox2.Location = new System.Drawing.Point(13, 240);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(144, 29);
            this.checkBox2.TabIndex = 6;
            this.checkBox2.Tag = "estimatekind.multireg:S:N";
            this.checkBox2.Text = "Anagrafe nel dettaglio";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(173, 386);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 16);
            this.label8.TabIndex = 22;
            this.label8.Text = "Fax:";
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(13, 208);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(128, 26);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Tag = "estimatekind.linktoinvoice:S:N";
            this.checkBox1.Text = "Collegabile a fattura";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(10, 357);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(296, 20);
            this.textBox12.TabIndex = 10;
            this.textBox12.Tag = "estimatekind.office";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(10, 397);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(128, 20);
            this.textBox11.TabIndex = 11;
            this.textBox11.Tag = "estimatekind.phonenumber";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(10, 437);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(296, 20);
            this.textBox9.TabIndex = 13;
            this.textBox9.Tag = "estimatekind.email";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(173, 402);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(128, 20);
            this.textBox10.TabIndex = 12;
            this.textBox10.Tag = "estimatekind.faxnumber";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(10, 421);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 16);
            this.label7.TabIndex = 26;
            this.label7.Text = "Email:";
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
            this.tabAttributi.Size = new System.Drawing.Size(616, 476);
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
            this.gboxclass05.Location = new System.Drawing.Point(8, 286);
            this.gboxclass05.Name = "gboxclass05";
            this.gboxclass05.Size = new System.Drawing.Size(594, 64);
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
            this.gboxclass04.Location = new System.Drawing.Point(8, 216);
            this.gboxclass04.Name = "gboxclass04";
            this.gboxclass04.Size = new System.Drawing.Size(594, 64);
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
            this.gboxclass03.Location = new System.Drawing.Point(8, 146);
            this.gboxclass03.Name = "gboxclass03";
            this.gboxclass03.Size = new System.Drawing.Size(594, 64);
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
            this.gboxclass02.Location = new System.Drawing.Point(8, 76);
            this.gboxclass02.Name = "gboxclass02";
            this.gboxclass02.Size = new System.Drawing.Size(594, 64);
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
            this.gboxclass01.Location = new System.Drawing.Point(8, 6);
            this.gboxclass01.Name = "gboxclass01";
            this.gboxclass01.Size = new System.Drawing.Size(594, 64);
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
            this.txtDenom01.Size = new System.Drawing.Size(353, 52);
            this.txtDenom01.TabIndex = 3;
            this.txtDenom01.TabStop = false;
            this.txtDenom01.Tag = "sorting01.description";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tabControlReport);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(616, 476);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Stampa";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControlReport
            // 
            this.tabControlReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlReport.Controls.Add(this.tabPage4);
            this.tabControlReport.Controls.Add(this.tabPage5);
            this.tabControlReport.Location = new System.Drawing.Point(8, 6);
            this.tabControlReport.Name = "tabControlReport";
            this.tabControlReport.SelectedIndex = 0;
            this.tabControlReport.Size = new System.Drawing.Size(600, 146);
            this.tabControlReport.TabIndex = 63;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.textBox16);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(592, 120);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Intestazione Report";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // textBox16
            // 
            this.textBox16.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox16.Location = new System.Drawing.Point(3, 3);
            this.textBox16.Multiline = true;
            this.textBox16.Name = "textBox16";
            this.textBox16.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox16.Size = new System.Drawing.Size(586, 114);
            this.textBox16.TabIndex = 39;
            this.textBox16.Tag = "estimatekind.header";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.textBox17);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(592, 120);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Indirizzo";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // textBox17
            // 
            this.textBox17.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox17.Location = new System.Drawing.Point(3, 3);
            this.textBox17.Multiline = true;
            this.textBox17.Name = "textBox17";
            this.textBox17.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox17.Size = new System.Drawing.Size(586, 114);
            this.textBox17.TabIndex = 39;
            this.textBox17.Tag = "estimatekind.address";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gBoxIvaKind);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(616, 476);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "Iva";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gBoxIvaKind
            // 
            this.gBoxIvaKind.Controls.Add(this.btnTipo);
            this.gBoxIvaKind.Controls.Add(this.cmbTipoIVA);
            this.gBoxIvaKind.Controls.Add(this.txtIva);
            this.gBoxIvaKind.Controls.Add(this.label13);
            this.gBoxIvaKind.Controls.Add(this.lblPercIndeduc);
            this.gBoxIvaKind.Controls.Add(this.txtPercIndeduc);
            this.gBoxIvaKind.Location = new System.Drawing.Point(6, 19);
            this.gBoxIvaKind.Name = "gBoxIvaKind";
            this.gBoxIvaKind.Size = new System.Drawing.Size(431, 50);
            this.gBoxIvaKind.TabIndex = 11;
            this.gBoxIvaKind.TabStop = false;
            this.gBoxIvaKind.Text = "Forza Tipo IVA";
            // 
            // btnTipo
            // 
            this.btnTipo.Location = new System.Drawing.Point(8, 23);
            this.btnTipo.Name = "btnTipo";
            this.btnTipo.Size = new System.Drawing.Size(64, 23);
            this.btnTipo.TabIndex = 7;
            this.btnTipo.TabStop = false;
            this.btnTipo.Tag = "choose.ivakind.default";
            this.btnTipo.Text = "Tipo IVA";
            // 
            // cmbTipoIVA
            // 
            this.cmbTipoIVA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipoIVA.DataSource = this.DS.ivakind;
            this.cmbTipoIVA.DisplayMember = "description";
            this.cmbTipoIVA.Location = new System.Drawing.Point(80, 23);
            this.cmbTipoIVA.Name = "cmbTipoIVA";
            this.cmbTipoIVA.Size = new System.Drawing.Size(151, 21);
            this.cmbTipoIVA.TabIndex = 1;
            this.cmbTipoIVA.Tag = "estimatekind.idivakind_forced";
            this.cmbTipoIVA.ValueMember = "idivakind";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // txtIva
            // 
            this.txtIva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIva.Location = new System.Drawing.Point(239, 24);
            this.txtIva.Name = "txtIva";
            this.txtIva.ReadOnly = true;
            this.txtIva.Size = new System.Drawing.Size(72, 20);
            this.txtIva.TabIndex = 2;
            this.txtIva.TabStop = false;
            this.txtIva.Tag = "ivakind.rate.fixed.4..%.100";
            this.txtIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.Location = new System.Drawing.Point(239, 8);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 16);
            this.label13.TabIndex = 35;
            this.label13.Text = "Aliquota";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPercIndeduc
            // 
            this.lblPercIndeduc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPercIndeduc.Location = new System.Drawing.Point(327, 8);
            this.lblPercIndeduc.Name = "lblPercIndeduc";
            this.lblPercIndeduc.Size = new System.Drawing.Size(88, 16);
            this.lblPercIndeduc.TabIndex = 39;
            this.lblPercIndeduc.Text = "% Indetraibilità";
            this.lblPercIndeduc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPercIndeduc
            // 
            this.txtPercIndeduc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPercIndeduc.Location = new System.Drawing.Point(327, 24);
            this.txtPercIndeduc.Name = "txtPercIndeduc";
            this.txtPercIndeduc.ReadOnly = true;
            this.txtPercIndeduc.Size = new System.Drawing.Size(88, 20);
            this.txtPercIndeduc.TabIndex = 3;
            this.txtPercIndeduc.TabStop = false;
            this.txtPercIndeduc.Tag = "ivakind.unabatabilitypercentage.fixed.4..%.100";
            this.txtPercIndeduc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // checkBox5
            // 
            this.checkBox5.Location = new System.Drawing.Point(328, 276);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(280, 28);
            this.checkBox5.TabIndex = 38;
            this.checkBox5.Tag = "estimatekind.flag:2";
            this.checkBox5.Text = "La reversale generata non filtra per anagrafica";
            // 
            // Frm_estimatekind_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(624, 502);
            this.Controls.Add(this.tabControl1);
            this.Name = "Frm_estimatekind_default";
            this.Text = "Frm_estimatekind_default";
            this.tabControl1.ResumeLayout(false);
            this.tabGenerale.ResumeLayout(false);
            this.tabGenerale.PerformLayout();
            this.gboxUPB.ResumeLayout(false);
            this.gboxUPB.PerformLayout();
            this.groupBox20.ResumeLayout(false);
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
            this.tabPage1.ResumeLayout(false);
            this.tabControlReport.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.gBoxIvaKind.ResumeLayout(false);
            this.gBoxIvaKind.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        DataAccess Conn;
        QueryHelper QHS;

        public void MetaData_AfterLink() {
            Conn = MetaData.GetConnection(this);
            QHS = Conn.GetQueryHelper();
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
      
	}
}
