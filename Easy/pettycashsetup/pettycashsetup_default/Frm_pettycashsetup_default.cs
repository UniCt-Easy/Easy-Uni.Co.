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
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;

namespace pettycashsetup_default {//perspiccolespese//
	/// <summary>
	/// Summary description for frmperspiccolespese.
	/// </summary>
	public class Frm_pettycashsetup_default : System.Windows.Forms.Form {
		private System.Windows.Forms.Button btnSpesaAcc;
		private System.Windows.Forms.Button btnBilancioEntrata;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.Label label1;
		public vistaForm DS;
		private System.Windows.Forms.TextBox txtCredDeb;
		private System.Windows.Forms.GroupBox groupCredDeb;
		public MetaData Meta;
		private System.Windows.Forms.TextBox txtBoxEntrata;
		private System.Windows.Forms.TextBox txtBoxSpesa;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.GroupBox gboxConto;
		private System.Windows.Forms.TextBox txtDenominazioneConto;
		private System.Windows.Forms.TextBox txtCodiceConto;
		private System.Windows.Forms.Button button2;
        private CheckBox chkFlag;
        public GroupBox grpCentroSpesa;
        private TextBox txtDescrizioneUpb;
        private Button btnUpb;
        public TextBox txtUPB;
        private GroupBox grpBoxSiopeEPspese;
        private Button btnSiopeSpese;
        private TextBox txtDescSiopeSpese;
        private TextBox txtCodSiopeSpese;
        private GroupBox grpBoxSiopeEPentrate;
        private Button btnSiopeEntrate;
        private TextBox txtDescSiopeEntrate;
        private TextBox txtCodSiopeEntrate;
        private System.ComponentModel.IContainer components;

		public Frm_pettycashsetup_default() {
			InitializeComponent();
			DataAccess.SetTableForReading(DS.bilancioentrata,"finview");
			DataAccess.SetTableForReading(DS.bilanciospesa,"finview");
			HelpForm.SetDenyNull(DS.pettycashsetup.Columns["autoclassify"], true);
            HelpForm.SetDenyNull(DS.pettycashsetup.Columns["flag"], true);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_pettycashsetup_default));
            this.btnSpesaAcc = new System.Windows.Forms.Button();
            this.btnBilancioEntrata = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.DS = new pettycashsetup_default.vistaForm();
            this.groupCredDeb = new System.Windows.Forms.GroupBox();
            this.txtCredDeb = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtBoxEntrata = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.txtBoxSpesa = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.gboxConto = new System.Windows.Forms.GroupBox();
            this.txtDenominazioneConto = new System.Windows.Forms.TextBox();
            this.txtCodiceConto = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.chkFlag = new System.Windows.Forms.CheckBox();
            this.grpCentroSpesa = new System.Windows.Forms.GroupBox();
            this.txtUPB = new System.Windows.Forms.TextBox();
            this.txtDescrizioneUpb = new System.Windows.Forms.TextBox();
            this.btnUpb = new System.Windows.Forms.Button();
            this.grpBoxSiopeEPspese = new System.Windows.Forms.GroupBox();
            this.btnSiopeSpese = new System.Windows.Forms.Button();
            this.txtDescSiopeSpese = new System.Windows.Forms.TextBox();
            this.txtCodSiopeSpese = new System.Windows.Forms.TextBox();
            this.grpBoxSiopeEPentrate = new System.Windows.Forms.GroupBox();
            this.btnSiopeEntrate = new System.Windows.Forms.Button();
            this.txtDescSiopeEntrate = new System.Windows.Forms.TextBox();
            this.txtCodSiopeEntrate = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupCredDeb.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gboxConto.SuspendLayout();
            this.grpCentroSpesa.SuspendLayout();
            this.grpBoxSiopeEPspese.SuspendLayout();
            this.grpBoxSiopeEPentrate.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSpesaAcc
            // 
            this.btnSpesaAcc.BackColor = System.Drawing.SystemColors.Control;
            this.btnSpesaAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnSpesaAcc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSpesaAcc.Location = new System.Drawing.Point(8, 24);
            this.btnSpesaAcc.Name = "btnSpesaAcc";
            this.btnSpesaAcc.Size = new System.Drawing.Size(80, 23);
            this.btnSpesaAcc.TabIndex = 75;
            this.btnSpesaAcc.TabStop = false;
            this.btnSpesaAcc.Tag = "manage.pettycash.default";
            this.btnSpesaAcc.Text = "Fondo:";
            this.btnSpesaAcc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSpesaAcc.UseVisualStyleBackColor = false;
            // 
            // btnBilancioEntrata
            // 
            this.btnBilancioEntrata.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilancioEntrata.ImageIndex = 0;
            this.btnBilancioEntrata.ImageList = this.imageList1;
            this.btnBilancioEntrata.Location = new System.Drawing.Point(8, 24);
            this.btnBilancioEntrata.Name = "btnBilancioEntrata";
            this.btnBilancioEntrata.Size = new System.Drawing.Size(120, 24);
            this.btnBilancioEntrata.TabIndex = 76;
            this.btnBilancioEntrata.TabStop = false;
            this.btnBilancioEntrata.Tag = "";
            this.btnBilancioEntrata.Text = "Bilancio:";
            this.btnBilancioEntrata.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBilancioEntrata.Click += new System.EventHandler(this.btnBilancioEntrata_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DataSource = this.DS.pettycash;
            this.comboBox1.DisplayMember = "description";
            this.comboBox1.Location = new System.Drawing.Point(104, 24);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(515, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Tag = "pettycashsetup.idpettycash";
            this.comboBox1.ValueMember = "idpettycash";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // groupCredDeb
            // 
            this.groupCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupCredDeb.Controls.Add(this.txtCredDeb);
            this.groupCredDeb.Location = new System.Drawing.Point(8, 64);
            this.groupCredDeb.Name = "groupCredDeb";
            this.groupCredDeb.Size = new System.Drawing.Size(627, 56);
            this.groupCredDeb.TabIndex = 4;
            this.groupCredDeb.TabStop = false;
            this.groupCredDeb.Tag = "AutoChoose.txtCredDeb.lista";
            this.groupCredDeb.Text = "Percipiente / Versante per i movimenti di apertura, chiusura e reintegro";
            // 
            // txtCredDeb
            // 
            this.txtCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCredDeb.Location = new System.Drawing.Point(8, 24);
            this.txtCredDeb.Name = "txtCredDeb";
            this.txtCredDeb.Size = new System.Drawing.Size(611, 20);
            this.txtCredDeb.TabIndex = 0;
            this.txtCredDeb.Tag = "registry.title?pettycashsetupview.manager";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.txtBoxEntrata);
            this.groupBox2.Controls.Add(this.btnBilancioEntrata);
            this.groupBox2.Location = new System.Drawing.Point(8, 354);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(311, 88);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "AutoManage.txtBoxEntrata.treeupb";
            this.groupBox2.Text = "Capitolo per il movimento di CHIUSURA del fondo";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(134, 24);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3.Size = new System.Drawing.Size(169, 56);
            this.textBox3.TabIndex = 78;
            this.textBox3.TabStop = false;
            this.textBox3.Tag = "bilancioentrata.title";
            // 
            // txtBoxEntrata
            // 
            this.txtBoxEntrata.Location = new System.Drawing.Point(8, 56);
            this.txtBoxEntrata.Name = "txtBoxEntrata";
            this.txtBoxEntrata.Size = new System.Drawing.Size(120, 20);
            this.txtBoxEntrata.TabIndex = 1;
            this.txtBoxEntrata.Tag = "bilancioentrata.codefin?pettycashsetupview.finincomecode";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.textBox4);
            this.groupBox3.Controls.Add(this.txtBoxSpesa);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(8, 260);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(311, 88);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Tag = "AutoManage.txtBoxSpesa.treeupb";
            this.groupBox3.Text = "Capitolo per il movimento di APERTURA del fondo";
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(134, 24);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox4.Size = new System.Drawing.Size(169, 56);
            this.textBox4.TabIndex = 78;
            this.textBox4.TabStop = false;
            this.textBox4.Tag = "bilanciospesa.title";
            // 
            // txtBoxSpesa
            // 
            this.txtBoxSpesa.Location = new System.Drawing.Point(8, 56);
            this.txtBoxSpesa.Name = "txtBoxSpesa";
            this.txtBoxSpesa.Size = new System.Drawing.Size(120, 20);
            this.txtBoxSpesa.TabIndex = 1;
            this.txtBoxSpesa.Tag = "bilanciospesa.codefin?pettycashsetupview.finexpensecode";
            // 
            // button1
            // 
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.ImageIndex = 0;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(8, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 24);
            this.button1.TabIndex = 76;
            this.button1.TabStop = false;
            this.button1.Tag = "";
            this.button1.Text = "Bilancio:";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(198, 124);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(112, 20);
            this.textBox6.TabIndex = 5;
            this.textBox6.Tag = "pettycashsetup.amount";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 16);
            this.label1.TabIndex = 82;
            this.label1.Text = "Importo del movimento di apertura:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnSpesaAcc);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(627, 56);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fondo Economale";
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(16, 542);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(448, 24);
            this.checkBox1.TabIndex = 83;
            this.checkBox1.Tag = "pettycashsetup.autoclassify:S:N";
            this.checkBox1.Text = "Genera Classificazioni Automatiche invece di usare quelle inserite manualmente";
            // 
            // gboxConto
            // 
            this.gboxConto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxConto.Controls.Add(this.txtDenominazioneConto);
            this.gboxConto.Controls.Add(this.txtCodiceConto);
            this.gboxConto.Controls.Add(this.button2);
            this.gboxConto.Location = new System.Drawing.Point(8, 448);
            this.gboxConto.Name = "gboxConto";
            this.gboxConto.Size = new System.Drawing.Size(635, 88);
            this.gboxConto.TabIndex = 84;
            this.gboxConto.TabStop = false;
            this.gboxConto.Tag = "AutoManage.txtCodiceConto.tree";
            this.gboxConto.Text = "Conto E/P ";
            // 
            // txtDenominazioneConto
            // 
            this.txtDenominazioneConto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenominazioneConto.Location = new System.Drawing.Point(161, 16);
            this.txtDenominazioneConto.Multiline = true;
            this.txtDenominazioneConto.Name = "txtDenominazioneConto";
            this.txtDenominazioneConto.ReadOnly = true;
            this.txtDenominazioneConto.Size = new System.Drawing.Size(466, 52);
            this.txtDenominazioneConto.TabIndex = 2;
            this.txtDenominazioneConto.TabStop = false;
            this.txtDenominazioneConto.Tag = "account.title";
            // 
            // txtCodiceConto
            // 
            this.txtCodiceConto.Location = new System.Drawing.Point(8, 48);
            this.txtCodiceConto.Name = "txtCodiceConto";
            this.txtCodiceConto.Size = new System.Drawing.Size(148, 20);
            this.txtCodiceConto.TabIndex = 1;
            this.txtCodiceConto.Tag = "account.codeacc?x";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 23);
            this.button2.TabIndex = 0;
            this.button2.TabStop = false;
            this.button2.Tag = "manage.account.tree";
            this.button2.Text = "Conto";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkFlag
            // 
            this.chkFlag.AutoSize = true;
            this.chkFlag.Location = new System.Drawing.Point(16, 572);
            this.chkFlag.Name = "chkFlag";
            this.chkFlag.Size = new System.Drawing.Size(332, 17);
            this.chkFlag.TabIndex = 85;
            this.chkFlag.Tag = "pettycashsetup.flag:0";
            this.chkFlag.Text = "Non generare movimenti finanziari per Apertura e Chiusura fondo.";
            this.chkFlag.UseVisualStyleBackColor = true;
            // 
            // grpCentroSpesa
            // 
            this.grpCentroSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCentroSpesa.Controls.Add(this.txtUPB);
            this.grpCentroSpesa.Controls.Add(this.txtDescrizioneUpb);
            this.grpCentroSpesa.Controls.Add(this.btnUpb);
            this.grpCentroSpesa.Location = new System.Drawing.Point(8, 147);
            this.grpCentroSpesa.Name = "grpCentroSpesa";
            this.grpCentroSpesa.Size = new System.Drawing.Size(627, 107);
            this.grpCentroSpesa.TabIndex = 86;
            this.grpCentroSpesa.TabStop = false;
            this.grpCentroSpesa.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
            // 
            // txtUPB
            // 
            this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUPB.Location = new System.Drawing.Point(4, 81);
            this.txtUPB.Name = "txtUPB";
            this.txtUPB.Size = new System.Drawing.Size(615, 20);
            this.txtUPB.TabIndex = 6;
            this.txtUPB.Tag = "upb.codeupb?x";
            // 
            // txtDescrizioneUpb
            // 
            this.txtDescrizioneUpb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizioneUpb.Location = new System.Drawing.Point(144, 16);
            this.txtDescrizioneUpb.Multiline = true;
            this.txtDescrizioneUpb.Name = "txtDescrizioneUpb";
            this.txtDescrizioneUpb.ReadOnly = true;
            this.txtDescrizioneUpb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrizioneUpb.Size = new System.Drawing.Size(475, 59);
            this.txtDescrizioneUpb.TabIndex = 3;
            this.txtDescrizioneUpb.TabStop = false;
            this.txtDescrizioneUpb.Tag = "upb.title";
            // 
            // btnUpb
            // 
            this.btnUpb.BackColor = System.Drawing.SystemColors.Control;
            this.btnUpb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpb.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUpb.Location = new System.Drawing.Point(4, 52);
            this.btnUpb.Name = "btnUpb";
            this.btnUpb.Size = new System.Drawing.Size(120, 23);
            this.btnUpb.TabIndex = 1;
            this.btnUpb.TabStop = false;
            this.btnUpb.Tag = "manage.upb.tree";
            this.btnUpb.Text = "UPB:";
            this.btnUpb.UseVisualStyleBackColor = false;
            // 
            // grpBoxSiopeEPspese
            // 
            this.grpBoxSiopeEPspese.Controls.Add(this.btnSiopeSpese);
            this.grpBoxSiopeEPspese.Controls.Add(this.txtDescSiopeSpese);
            this.grpBoxSiopeEPspese.Controls.Add(this.txtCodSiopeSpese);
            this.grpBoxSiopeEPspese.Location = new System.Drawing.Point(325, 260);
            this.grpBoxSiopeEPspese.Name = "grpBoxSiopeEPspese";
            this.grpBoxSiopeEPspese.Size = new System.Drawing.Size(310, 88);
            this.grpBoxSiopeEPspese.TabIndex = 87;
            this.grpBoxSiopeEPspese.TabStop = false;
            this.grpBoxSiopeEPspese.Tag = "AutoChoose.txtCodSiopeSpese.tree";
            this.grpBoxSiopeEPspese.Text = "Class.SIOPE spese";
            // 
            // btnSiopeSpese
            // 
            this.btnSiopeSpese.Location = new System.Drawing.Point(5, 31);
            this.btnSiopeSpese.Name = "btnSiopeSpese";
            this.btnSiopeSpese.Size = new System.Drawing.Size(120, 24);
            this.btnSiopeSpese.TabIndex = 10;
            this.btnSiopeSpese.Tag = "manage.sorting_siopespese.tree";
            this.btnSiopeSpese.Text = "Codice";
            this.btnSiopeSpese.UseVisualStyleBackColor = true;
            // 
            // txtDescSiopeSpese
            // 
            this.txtDescSiopeSpese.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescSiopeSpese.Location = new System.Drawing.Point(126, 19);
            this.txtDescSiopeSpese.Multiline = true;
            this.txtDescSiopeSpese.Name = "txtDescSiopeSpese";
            this.txtDescSiopeSpese.ReadOnly = true;
            this.txtDescSiopeSpese.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescSiopeSpese.Size = new System.Drawing.Size(178, 61);
            this.txtDescSiopeSpese.TabIndex = 2;
            this.txtDescSiopeSpese.Tag = "sorting_siopespese.description";
            // 
            // txtCodSiopeSpese
            // 
            this.txtCodSiopeSpese.Location = new System.Drawing.Point(5, 60);
            this.txtCodSiopeSpese.Name = "txtCodSiopeSpese";
            this.txtCodSiopeSpese.Size = new System.Drawing.Size(118, 20);
            this.txtCodSiopeSpese.TabIndex = 9;
            this.txtCodSiopeSpese.Tag = "sorting_siopespese.sortcode?x";
            // 
            // grpBoxSiopeEPentrate
            // 
            this.grpBoxSiopeEPentrate.Controls.Add(this.btnSiopeEntrate);
            this.grpBoxSiopeEPentrate.Controls.Add(this.txtDescSiopeEntrate);
            this.grpBoxSiopeEPentrate.Controls.Add(this.txtCodSiopeEntrate);
            this.grpBoxSiopeEPentrate.Location = new System.Drawing.Point(325, 354);
            this.grpBoxSiopeEPentrate.Name = "grpBoxSiopeEPentrate";
            this.grpBoxSiopeEPentrate.Size = new System.Drawing.Size(310, 88);
            this.grpBoxSiopeEPentrate.TabIndex = 88;
            this.grpBoxSiopeEPentrate.TabStop = false;
            this.grpBoxSiopeEPentrate.Tag = "AutoChoose.txtCodSiopeEntrate.tree";
            this.grpBoxSiopeEPentrate.Text = "Class.SIOPE entrate";
            // 
            // btnSiopeEntrate
            // 
            this.btnSiopeEntrate.Location = new System.Drawing.Point(5, 31);
            this.btnSiopeEntrate.Name = "btnSiopeEntrate";
            this.btnSiopeEntrate.Size = new System.Drawing.Size(120, 24);
            this.btnSiopeEntrate.TabIndex = 10;
            this.btnSiopeEntrate.Tag = "manage.sorting_siopeentrate.tree";
            this.btnSiopeEntrate.Text = "Codice";
            this.btnSiopeEntrate.UseVisualStyleBackColor = true;
            // 
            // txtDescSiopeEntrate
            // 
            this.txtDescSiopeEntrate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescSiopeEntrate.Location = new System.Drawing.Point(126, 19);
            this.txtDescSiopeEntrate.Multiline = true;
            this.txtDescSiopeEntrate.Name = "txtDescSiopeEntrate";
            this.txtDescSiopeEntrate.ReadOnly = true;
            this.txtDescSiopeEntrate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescSiopeEntrate.Size = new System.Drawing.Size(178, 61);
            this.txtDescSiopeEntrate.TabIndex = 2;
            this.txtDescSiopeEntrate.Tag = "sorting_siopeentrate.description";
            // 
            // txtCodSiopeEntrate
            // 
            this.txtCodSiopeEntrate.Location = new System.Drawing.Point(5, 60);
            this.txtCodSiopeEntrate.Name = "txtCodSiopeEntrate";
            this.txtCodSiopeEntrate.Size = new System.Drawing.Size(118, 20);
            this.txtCodSiopeEntrate.TabIndex = 9;
            this.txtCodSiopeEntrate.Tag = "sorting_siopeentrate.sortcode?x";
            // 
            // Frm_pettycashsetup_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(643, 606);
            this.Controls.Add(this.grpBoxSiopeEPentrate);
            this.Controls.Add(this.grpBoxSiopeEPspese);
            this.Controls.Add(this.grpCentroSpesa);
            this.Controls.Add(this.chkFlag);
            this.Controls.Add(this.gboxConto);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupCredDeb);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.textBox6);
            this.Name = "Frm_pettycashsetup_default";
            this.Text = "Frm_pettycashsetup_default";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupCredDeb.ResumeLayout(false);
            this.groupCredDeb.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.gboxConto.ResumeLayout(false);
            this.gboxConto.PerformLayout();
            this.grpCentroSpesa.ResumeLayout(false);
            this.grpCentroSpesa.PerformLayout();
            this.grpBoxSiopeEPspese.ResumeLayout(false);
            this.grpBoxSiopeEPspese.PerformLayout();
            this.grpBoxSiopeEPentrate.ResumeLayout(false);
            this.grpBoxSiopeEPentrate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        CQueryHelper QHC;
        QueryHelper QHS;

		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
		    QHC = new CQueryHelper();
	        QHS = Meta.Conn.GetQueryHelper();
			string filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));

			GetData.SetStaticFilter(DS.bilancioentrata,
				QHS.AppAnd(filter, QHS.CmpEq("finpart", 'E'), QHS.CmpEq("idupb", "0001")));
			GetData.SetStaticFilter(DS.bilanciospesa,
                QHS.AppAnd(filter, QHS.CmpEq("finpart", 'S'), QHS.CmpEq("idupb", "0001")));
			GetData.SetStaticFilter(DS.account, filter);
            int esercizio = CfgFn.GetNoNullInt32(Meta.Conn.GetSys("esercizio"));
            if (esercizio >= 2018) {
                DataAccess.SetTableForReading(DS.sorting_siopeentrate, "sorting");
                DataAccess.SetTableForReading(DS.sorting_siopespese, "sorting");
                object idsorkindS = Meta.Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", Meta.GetSys("codesorkind_siopespese")), "idsorkind");
                object idsorkindE = Meta.Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", Meta.GetSys("codesorkind_siopeentrate")), "idsorkind");
                GetData.SetStaticFilter(DS.sorting_siopeentrate, QHS.CmpEq("idsorkind", idsorkindE));
                GetData.SetStaticFilter(DS.sorting_siopespese, QHS.CmpEq("idsorkind", idsorkindS));
            }
            else {
                grpBoxSiopeEPentrate.Visible = false;
                grpBoxSiopeEPspese.Visible = false;
            }
        }

		private void btnBilancioEntrata_Click(object sender, System.EventArgs e) {
			string filter = QHS.AppAnd(QHS.CmpEq("idupb", "0001"), QHS.CmpEq("finpart", 'E'),
                QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
			DS.bilancioentrata.ExtendedProperties[MetaData.ExtraParams]=filter;
			MetaData.DoMainCommand(this,"manage.bilancioentrata.treeeupb");
		}

		private void button1_Click(object sender, System.EventArgs e) {
            string filter = QHS.AppAnd(QHS.CmpEq("idupb", "0001"), QHS.CmpEq("finpart", 'S'),
                QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
			DS.bilanciospesa.ExtendedProperties[MetaData.ExtraParams]=filter;
			MetaData.DoMainCommand(this,"manage.bilanciospesa.treesupb");
		}
	}
}