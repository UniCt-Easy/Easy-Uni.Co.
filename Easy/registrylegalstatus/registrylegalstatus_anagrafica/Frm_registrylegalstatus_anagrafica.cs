/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

namespace registrylegalstatus_anagrafica {//posgiuridica_anagrafica//
	/// <summary>
	/// Summary description for frmposgiuridicaanagrafica.
	/// </summary>
	public class Frm_registrylegalstatus_anagrafica : MetaDataForm {
		private System.Windows.Forms.GroupBox groupCredDeb;
		private System.Windows.Forms.TextBox txtCreDeb;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button btnQualifica;
		public vistaForm DS;
        private System.Windows.Forms.CheckBox checkBox1;
		//private System.ComponentModel.IContainer components;
		private System.Windows.Forms.TextBox txtClasseStip;
        private GroupBox groupBox6;
        private TextBox txtCompartoCSA;
        private TextBox txtInquadrcsa;
        private Label label14;
        private Label label13;
        private Label lblRuoloCSA;
        private TextBox txtRuoloCSA;
        private Label label2;
        private TextBox textBox2;
        private GroupBox groupBox1;
        private ComboBox cmb_dalia_position;
        private Label label6;
        private TextBox textBox4;
		private ComboBox cmbInquadramento;
		private Label label7;
		private Label label8;
		private TextBox textBox5;
		private CheckBox checkBox2;
		private GroupBox groupBox2;
		private DataGrid dataGridAllegati;
		private Button btnDelAtt;
		private Button btnEditAtt;
		private Button btnInsAtt;
		private GroupBox gboxConcorsuale;
		private TextBox txtClasseconcorsuale;
		private Button BancaButton;
		private TextBox txtDescrConcorsuale;
		private Label label9;
		private ComboBox cmbTipologiaRuolo;
		private Label label10;
		private TextBox txtExtMatricula;
		MetaData Meta;

		public Frm_registrylegalstatus_anagrafica() {
			InitializeComponent();
			HelpForm.SetDenyNull(DS.registrylegalstatus.Columns["active"], true);
			HelpForm.SetDenyNull(DS.registrylegalstatus.Columns["flagdefault"], true);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.groupCredDeb = new System.Windows.Forms.GroupBox();
			this.txtCreDeb = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.DS = new registrylegalstatus_anagrafica.vistaForm();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.txtClasseStip = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.btnQualifica = new System.Windows.Forms.Button();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.txtCompartoCSA = new System.Windows.Forms.TextBox();
			this.txtInquadrcsa = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.lblRuoloCSA = new System.Windows.Forms.Label();
			this.txtRuoloCSA = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.cmb_dalia_position = new System.Windows.Forms.ComboBox();
			this.cmbInquadramento = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.dataGridAllegati = new System.Windows.Forms.DataGrid();
			this.btnDelAtt = new System.Windows.Forms.Button();
			this.btnEditAtt = new System.Windows.Forms.Button();
			this.btnInsAtt = new System.Windows.Forms.Button();
			this.gboxConcorsuale = new System.Windows.Forms.GroupBox();
			this.txtClasseconcorsuale = new System.Windows.Forms.TextBox();
			this.BancaButton = new System.Windows.Forms.Button();
			this.txtDescrConcorsuale = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.cmbTipologiaRuolo = new System.Windows.Forms.ComboBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtExtMatricula = new System.Windows.Forms.TextBox();
			this.groupCredDeb.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox6.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridAllegati)).BeginInit();
			this.gboxConcorsuale.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupCredDeb
			// 
			this.groupCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupCredDeb.Controls.Add(this.txtCreDeb);
			this.groupCredDeb.Controls.Add(this.label5);
			this.groupCredDeb.Location = new System.Drawing.Point(16, 8);
			this.groupCredDeb.Name = "groupCredDeb";
			this.groupCredDeb.Size = new System.Drawing.Size(614, 48);
			this.groupCredDeb.TabIndex = 1;
			this.groupCredDeb.TabStop = false;
			this.groupCredDeb.Tag = "AutoChoose.txtCreDeb.anagrafica.(active<>\'N\')";
			this.groupCredDeb.Text = "Anagrafica";
			// 
			// txtCreDeb
			// 
			this.txtCreDeb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCreDeb.Location = new System.Drawing.Point(120, 16);
			this.txtCreDeb.Name = "txtCreDeb";
			this.txtCreDeb.Size = new System.Drawing.Size(486, 20);
			this.txtCreDeb.TabIndex = 1;
			this.txtCreDeb.Tag = "registry.title?registrylegalstatusregview.registry";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(104, 16);
			this.label5.TabIndex = 1;
			this.label5.Text = "Denominazione:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 133);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(112, 16);
			this.label4.TabIndex = 5;
			this.label4.Text = "Classe stipendiale:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(228, 133);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(96, 16);
			this.label3.TabIndex = 44;
			this.label3.Text = "Data decorrenza:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 62);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 42;
			this.label1.Text = "Data delibera:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// comboBox1
			// 
			this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBox1.DataSource = this.DS.position;
			this.comboBox1.DisplayMember = "description";
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.Location = new System.Drawing.Point(120, 96);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(313, 21);
			this.comboBox1.TabIndex = 4;
			this.comboBox1.Tag = "registrylegalstatus.idposition";
			this.comboBox1.ValueMember = "idposition";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(329, 133);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(104, 20);
			this.textBox3.TabIndex = 6;
			this.textBox3.Tag = "registrylegalstatus.incomeclassvalidity";
			// 
			// txtClasseStip
			// 
			this.txtClasseStip.Location = new System.Drawing.Point(120, 133);
			this.txtClasseStip.Name = "txtClasseStip";
			this.txtClasseStip.Size = new System.Drawing.Size(104, 20);
			this.txtClasseStip.TabIndex = 5;
			this.txtClasseStip.Tag = "registrylegalstatus.incomeclass";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(120, 60);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(104, 20);
			this.textBox1.TabIndex = 2;
			this.textBox1.Tag = "registrylegalstatus.start";
			// 
			// btnQualifica
			// 
			this.btnQualifica.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnQualifica.Location = new System.Drawing.Point(16, 96);
			this.btnQualifica.Name = "btnQualifica";
			this.btnQualifica.Size = new System.Drawing.Size(98, 23);
			this.btnQualifica.TabIndex = 3;
			this.btnQualifica.TabStop = false;
			this.btnQualifica.Tag = "choose.position.default.(active=\'S\')";
			this.btnQualifica.Text = "Qualifica";
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(570, 137);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(64, 16);
			this.checkBox1.TabIndex = 3;
			this.checkBox1.Tag = "registrylegalstatus.active:S:N";
			this.checkBox1.Text = "Attivo";
			// 
			// groupBox6
			// 
			this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox6.Controls.Add(this.txtCompartoCSA);
			this.groupBox6.Controls.Add(this.txtInquadrcsa);
			this.groupBox6.Controls.Add(this.label14);
			this.groupBox6.Controls.Add(this.label13);
			this.groupBox6.Controls.Add(this.lblRuoloCSA);
			this.groupBox6.Controls.Add(this.txtRuoloCSA);
			this.groupBox6.Location = new System.Drawing.Point(16, 213);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(614, 42);
			this.groupBox6.TabIndex = 105;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Dati CSA";
			// 
			// txtCompartoCSA
			// 
			this.txtCompartoCSA.Location = new System.Drawing.Point(79, 17);
			this.txtCompartoCSA.Name = "txtCompartoCSA";
			this.txtCompartoCSA.ReadOnly = true;
			this.txtCompartoCSA.Size = new System.Drawing.Size(52, 20);
			this.txtCompartoCSA.TabIndex = 108;
			this.txtCompartoCSA.Tag = "registrylegalstatus.csa_compartment";
			// 
			// txtInquadrcsa
			// 
			this.txtInquadrcsa.Location = new System.Drawing.Point(326, 17);
			this.txtInquadrcsa.Name = "txtInquadrcsa";
			this.txtInquadrcsa.ReadOnly = true;
			this.txtInquadrcsa.Size = new System.Drawing.Size(78, 20);
			this.txtInquadrcsa.TabIndex = 107;
			this.txtInquadrcsa.Tag = "registrylegalstatus.csa_class";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(18, 17);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(52, 13);
			this.label14.TabIndex = 106;
			this.label14.Text = "Comparto";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(244, 20);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(78, 13);
			this.label13.TabIndex = 105;
			this.label13.Text = "Inquadramento";
			// 
			// lblRuoloCSA
			// 
			this.lblRuoloCSA.AutoSize = true;
			this.lblRuoloCSA.Location = new System.Drawing.Point(138, 17);
			this.lblRuoloCSA.Name = "lblRuoloCSA";
			this.lblRuoloCSA.Size = new System.Drawing.Size(35, 13);
			this.lblRuoloCSA.TabIndex = 104;
			this.lblRuoloCSA.Text = "Ruolo";
			// 
			// txtRuoloCSA
			// 
			this.txtRuoloCSA.Location = new System.Drawing.Point(175, 17);
			this.txtRuoloCSA.Name = "txtRuoloCSA";
			this.txtRuoloCSA.ReadOnly = true;
			this.txtRuoloCSA.Size = new System.Drawing.Size(59, 20);
			this.txtRuoloCSA.TabIndex = 103;
			this.txtRuoloCSA.Tag = "registrylegalstatus.csa_role";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(272, 161);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 13);
			this.label2.TabIndex = 106;
			this.label2.Text = "Termine:";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(329, 160);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(104, 20);
			this.textBox2.TabIndex = 107;
			this.textBox2.Tag = "registrylegalstatus.stop";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.textBox4);
			this.groupBox1.Controls.Add(this.cmb_dalia_position);
			this.groupBox1.Location = new System.Drawing.Point(18, 347);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(616, 69);
			this.groupBox1.TabIndex = 108;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Banca Dati DALIA";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 24);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(74, 13);
			this.label6.TabIndex = 110;
			this.label6.Text = "Codice DALIA";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(6, 40);
			this.textBox4.Name = "textBox4";
			this.textBox4.ReadOnly = true;
			this.textBox4.Size = new System.Drawing.Size(90, 20);
			this.textBox4.TabIndex = 109;
			this.textBox4.Tag = "dalia_position.codedaliaposition";
			// 
			// cmb_dalia_position
			// 
			this.cmb_dalia_position.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmb_dalia_position.DataSource = this.DS.dalia_position;
			this.cmb_dalia_position.DisplayMember = "description";
			this.cmb_dalia_position.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb_dalia_position.Location = new System.Drawing.Point(102, 40);
			this.cmb_dalia_position.Name = "cmb_dalia_position";
			this.cmb_dalia_position.Size = new System.Drawing.Size(502, 21);
			this.cmb_dalia_position.TabIndex = 6;
			this.cmb_dalia_position.Tag = "registrylegalstatus.iddaliaposition";
			this.cmb_dalia_position.ValueMember = "iddaliaposition";
			// 
			// cmbInquadramento
			// 
			this.cmbInquadramento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbInquadramento.DataSource = this.DS.inquadramento;
			this.cmbInquadramento.DisplayMember = "title";
			this.cmbInquadramento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbInquadramento.Location = new System.Drawing.Point(105, 187);
			this.cmbInquadramento.Name = "cmbInquadramento";
			this.cmbInquadramento.Size = new System.Drawing.Size(525, 21);
			this.cmbInquadramento.TabIndex = 116;
			this.cmbInquadramento.Tag = "registrylegalstatus.idinquadramento";
			this.cmbInquadramento.ValueMember = "idinquadramento";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(20, 190);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(81, 13);
			this.label7.TabIndex = 115;
			this.label7.Text = "Inquadramento:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(439, 99);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(84, 13);
			this.label8.TabIndex = 118;
			this.label8.Text = "Livello (o scatto)";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(529, 95);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(105, 20);
			this.textBox5.TabIndex = 117;
			this.textBox5.Tag = "registrylegalstatus.livello";
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(15, 421);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(306, 17);
			this.checkBox2.TabIndex = 119;
			this.checkBox2.Tag = "registrylegalstatus.flagdefault:S:N";
			this.checkBox2.Text = "Predefinito (ai fini del calcolo dei costi nei progetti di ricerca)";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.dataGridAllegati);
			this.groupBox2.Controls.Add(this.btnDelAtt);
			this.groupBox2.Controls.Add(this.btnEditAtt);
			this.groupBox2.Controls.Add(this.btnInsAtt);
			this.groupBox2.Location = new System.Drawing.Point(16, 448);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(618, 203);
			this.groupBox2.TabIndex = 120;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Allegati";
			// 
			// dataGridAllegati
			// 
			this.dataGridAllegati.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridAllegati.DataMember = "";
			this.dataGridAllegati.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridAllegati.Location = new System.Drawing.Point(11, 63);
			this.dataGridAllegati.Name = "dataGridAllegati";
			this.dataGridAllegati.ReadOnly = true;
			this.dataGridAllegati.Size = new System.Drawing.Size(595, 126);
			this.dataGridAllegati.TabIndex = 27;
			this.dataGridAllegati.Tag = "registrylegalstatusattachment.lista.detail";
			// 
			// btnDelAtt
			// 
			this.btnDelAtt.Location = new System.Drawing.Point(202, 28);
			this.btnDelAtt.Name = "btnDelAtt";
			this.btnDelAtt.Size = new System.Drawing.Size(82, 28);
			this.btnDelAtt.TabIndex = 26;
			this.btnDelAtt.Tag = "delete";
			this.btnDelAtt.Text = "Elimina";
			// 
			// btnEditAtt
			// 
			this.btnEditAtt.Location = new System.Drawing.Point(106, 28);
			this.btnEditAtt.Name = "btnEditAtt";
			this.btnEditAtt.Size = new System.Drawing.Size(83, 28);
			this.btnEditAtt.TabIndex = 25;
			this.btnEditAtt.Tag = "edit.detail";
			this.btnEditAtt.Text = "Modifica...";
			// 
			// btnInsAtt
			// 
			this.btnInsAtt.Location = new System.Drawing.Point(11, 28);
			this.btnInsAtt.Name = "btnInsAtt";
			this.btnInsAtt.Size = new System.Drawing.Size(81, 28);
			this.btnInsAtt.TabIndex = 24;
			this.btnInsAtt.Tag = "insert.detail";
			this.btnInsAtt.Text = "Inserisci...";
			// 
			// gboxConcorsuale
			// 
			this.gboxConcorsuale.Controls.Add(this.txtClasseconcorsuale);
			this.gboxConcorsuale.Controls.Add(this.BancaButton);
			this.gboxConcorsuale.Controls.Add(this.txtDescrConcorsuale);
			this.gboxConcorsuale.Location = new System.Drawing.Point(16, 261);
			this.gboxConcorsuale.Name = "gboxConcorsuale";
			this.gboxConcorsuale.Size = new System.Drawing.Size(304, 64);
			this.gboxConcorsuale.TabIndex = 121;
			this.gboxConcorsuale.TabStop = false;
			this.gboxConcorsuale.Tag = "AutoChoose.txtClasseconcorsuale.default.(active=\'S\')";
			this.gboxConcorsuale.Text = "Classi di concorso MIUR";
			// 
			// txtClasseconcorsuale
			// 
			this.txtClasseconcorsuale.Location = new System.Drawing.Point(9, 38);
			this.txtClasseconcorsuale.Name = "txtClasseconcorsuale";
			this.txtClasseconcorsuale.Size = new System.Drawing.Size(123, 20);
			this.txtClasseconcorsuale.TabIndex = 3;
			this.txtClasseconcorsuale.Tag = "classconsorsuale.title?registrylegalstatusview.classconsorsualetitle";
			// 
			// BancaButton
			// 
			this.BancaButton.Location = new System.Drawing.Point(8, 14);
			this.BancaButton.Name = "BancaButton";
			this.BancaButton.Size = new System.Drawing.Size(124, 23);
			this.BancaButton.TabIndex = 2;
			this.BancaButton.Tag = "choose.classconsorsuale.default.(active=\'S\')";
			this.BancaButton.Text = "Classe";
			// 
			// txtDescrConcorsuale
			// 
			this.txtDescrConcorsuale.Location = new System.Drawing.Point(142, 9);
			this.txtDescrConcorsuale.Multiline = true;
			this.txtDescrConcorsuale.Name = "txtDescrConcorsuale";
			this.txtDescrConcorsuale.ReadOnly = true;
			this.txtDescrConcorsuale.Size = new System.Drawing.Size(156, 49);
			this.txtDescrConcorsuale.TabIndex = 2;
			this.txtDescrConcorsuale.TabStop = false;
			this.txtDescrConcorsuale.Tag = "classconsorsuale.description";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(323, 269);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(100, 21);
			this.label9.TabIndex = 123;
			this.label9.Text = "Tipologia Servizio";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbTipologiaRuolo
			// 
			this.cmbTipologiaRuolo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbTipologiaRuolo.DataSource = this.DS.tipologiaruolo;
			this.cmbTipologiaRuolo.DisplayMember = "description";
			this.cmbTipologiaRuolo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTipologiaRuolo.Location = new System.Drawing.Point(429, 270);
			this.cmbTipologiaRuolo.Name = "cmbTipologiaRuolo";
			this.cmbTipologiaRuolo.Size = new System.Drawing.Size(201, 21);
			this.cmbTipologiaRuolo.TabIndex = 122;
			this.cmbTipologiaRuolo.Tag = "registrylegalstatus.idtipologiaruolo";
			this.cmbTipologiaRuolo.ValueMember = "idtipologiaruolo";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(473, 65);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(50, 13);
			this.label10.TabIndex = 125;
			this.label10.Text = "Matricola";
			// 
			// txtExtMatricula
			// 
			this.txtExtMatricula.Location = new System.Drawing.Point(529, 62);
			this.txtExtMatricula.Name = "txtExtMatricula";
			this.txtExtMatricula.Size = new System.Drawing.Size(105, 20);
			this.txtExtMatricula.TabIndex = 124;
			this.txtExtMatricula.Tag = "registry.extmatricula?registrylegalstatusregview.extmatricula";
			// 
			// Frm_registrylegalstatus_anagrafica
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(646, 665);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.txtExtMatricula);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.cmbTipologiaRuolo);
			this.Controls.Add(this.gboxConcorsuale);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.checkBox2);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.textBox5);
			this.Controls.Add(this.cmbInquadramento);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.groupBox6);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.groupCredDeb);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.txtClasseStip);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.btnQualifica);
			this.Name = "Frm_registrylegalstatus_anagrafica";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmposgiuridicaanagrafica";
			this.groupCredDeb.ResumeLayout(false);
			this.groupCredDeb.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridAllegati)).EndInit();
			this.gboxConcorsuale.ResumeLayout(false);
			this.gboxConcorsuale.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
			QHC = new CQueryHelper();
			QHS = Meta.Conn.GetQueryHelper();

			// ===============================================================================
			// La InsertCopy non deve copiare le tabelle degli allegati
			// ===============================================================================
			QueryCreator.setSkipInsertCopy(DS.registrylegalstatusattachment, true);
		}
		public void MetaData_AfterFill() {
			ValorizzaComboInquadramento();
		}

		public void ValorizzaComboInquadramento() {
			if (Meta.IsEmpty) {
				return;
			}
			DataRow Curr = DS.registrylegalstatus.Rows[0];
			if (Curr["idposition"] != DBNull.Value) {
				setAutoInquadramento(Curr["idposition"]);
			}
		}

		CQueryHelper QHC;
		QueryHelper QHS;

		void clearInq() {
			DS.inquadramento.Clear();
			if (!isEmpty) {
				currentRow["idinquadramento"] = DBNull.Value;
			}
			if (cmbInquadramento.SelectedIndex > 0) {
				cmbInquadramento.SelectedIndex = -1;
			}
		}
		void setAutoInquadramento(object CurrIdposition) {

			DS.inquadramento.Clear();
			cmbInquadramento.DataSource = null;
			string filtrocmb = QHS.CmpEq("idposition", CurrIdposition);
			GetData.Add_Blank_Row(DS.inquadramento);
			DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.inquadramento, null, filtrocmb, null, true);
			cmbInquadramento.DataSource = DS.inquadramento;
			cmbInquadramento.DisplayMember = "title";
			cmbInquadramento.ValueMember = "idinquadramento";
			Meta.myHelpForm.PreFillControlsTable(cmbInquadramento, null);
			if (DS.registrylegalstatus.Rows.Count > 0) {
				HelpForm.SetComboBoxValue(cmbInquadramento, DS.registrylegalstatus.Rows[0]["idinquadramento"]);
			}

		}
		public void MetaData_AfterRowSelect(DataTable T, DataRow R){
			if (!Meta.DrawStateIsDone) return;
			if (Meta.IsEmpty) return;
			if ((T.TableName == "position")&&(R!=null)){
				if (R["maxincomeclass"].ToString()=="0"){
					txtClasseStip.Text="0";
				}
			}
			if (T.TableName == "position") {
				if (R == null) {
					setAutoInquadramento(DBNull.Value);
				}
				else {
					setAutoInquadramento(R["idposition"]);
				}
				clearInq();
			}
		}
	}
}