
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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

namespace parasubcontractfamily_contrattodetail {//familiaredettaglio//
	/// <summary>
	/// Summary description for frmfamiliaredettaglio.
	/// </summary>
	public class Frm_parasubcontractfamily_contrattodetail : MetaDataForm {
		public vistaForm DS;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox grpInfoGenerali;
		private System.Windows.Forms.TextBox txtCognome;
		private System.Windows.Forms.TextBox txtNome;
		private System.Windows.Forms.GroupBox grpSesso;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.GroupBox grpGeo;
		private System.Windows.Forms.GroupBox grpEstero;
		private System.Windows.Forms.TextBox txtGeoNazione;
		private System.Windows.Forms.GroupBox grpItaliano;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtProvincia;
		private System.Windows.Forms.TextBox txtLocalitaGeo;
		private System.Windows.Forms.TextBox txtDataNascita;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lblComuneStato;
		private System.Windows.Forms.Button btnAggiornaComune;
		private System.Windows.Forms.Button txtParentela;
		private System.Windows.Forms.ComboBox cmbParentela;
		MetaData Meta;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtInizioDetFiscali;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtFineDetFiscali;
		private System.Windows.Forms.GroupBox grpDetFiscali;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.CheckBox chkEstero;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.TextBox txtCF;
        private TextBox textBox1;
        private GroupBox groupBox1;
        private TextBox textBox4;
        private Label label10;
        private Label lblChiuldAsParent;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_parasubcontractfamily_contrattodetail() {
			InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_parasubcontractfamily_contrattodetail));
            this.DS = new parasubcontractfamily_contrattodetail.vistaForm();
            this.grpInfoGenerali = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txtCF = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbParentela = new System.Windows.Forms.ComboBox();
            this.txtParentela = new System.Windows.Forms.Button();
            this.grpGeo = new System.Windows.Forms.GroupBox();
            this.chkEstero = new System.Windows.Forms.CheckBox();
            this.grpEstero = new System.Windows.Forms.GroupBox();
            this.txtGeoNazione = new System.Windows.Forms.TextBox();
            this.grpItaliano = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtProvincia = new System.Windows.Forms.TextBox();
            this.txtLocalitaGeo = new System.Windows.Forms.TextBox();
            this.txtDataNascita = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblComuneStato = new System.Windows.Forms.Label();
            this.btnAggiornaComune = new System.Windows.Forms.Button();
            this.grpSesso = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCognome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInizioDetFiscali = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFineDetFiscali = new System.Windows.Forms.TextBox();
            this.grpDetFiscali = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblChiuldAsParent = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.grpInfoGenerali.SuspendLayout();
            this.grpGeo.SuspendLayout();
            this.grpEstero.SuspendLayout();
            this.grpItaliano.SuspendLayout();
            this.grpSesso.SuspendLayout();
            this.grpDetFiscali.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // grpInfoGenerali
            // 
            this.grpInfoGenerali.Controls.Add(this.button4);
            this.grpInfoGenerali.Controls.Add(this.button3);
            this.grpInfoGenerali.Controls.Add(this.txtCF);
            this.grpInfoGenerali.Controls.Add(this.label3);
            this.grpInfoGenerali.Controls.Add(this.cmbParentela);
            this.grpInfoGenerali.Controls.Add(this.txtParentela);
            this.grpInfoGenerali.Controls.Add(this.grpGeo);
            this.grpInfoGenerali.Controls.Add(this.grpSesso);
            this.grpInfoGenerali.Controls.Add(this.txtNome);
            this.grpInfoGenerali.Controls.Add(this.label2);
            this.grpInfoGenerali.Controls.Add(this.txtCognome);
            this.grpInfoGenerali.Controls.Add(this.label1);
            this.grpInfoGenerali.Location = new System.Drawing.Point(8, 8);
            this.grpInfoGenerali.Name = "grpInfoGenerali";
            this.grpInfoGenerali.Size = new System.Drawing.Size(568, 256);
            this.grpInfoGenerali.TabIndex = 0;
            this.grpInfoGenerali.TabStop = false;
            this.grpInfoGenerali.Text = "Generalità";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(440, 192);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(120, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "Ricava Info da CF";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(296, 192);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Calcola Codice Fiscale";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtCF
            // 
            this.txtCF.Location = new System.Drawing.Point(112, 192);
            this.txtCF.Name = "txtCF";
            this.txtCF.Size = new System.Drawing.Size(168, 20);
            this.txtCF.TabIndex = 6;
            this.txtCF.Tag = "parasubcontractfamily.cf";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "Codice Fiscale:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbParentela
            // 
            this.cmbParentela.DataSource = this.DS.affinity;
            this.cmbParentela.DisplayMember = "description";
            this.cmbParentela.Location = new System.Drawing.Point(112, 224);
            this.cmbParentela.Name = "cmbParentela";
            this.cmbParentela.Size = new System.Drawing.Size(176, 21);
            this.cmbParentela.TabIndex = 10;
            this.cmbParentela.Tag = "parasubcontractfamily.idaffinity";
            this.cmbParentela.ValueMember = "idaffinity";
            // 
            // txtParentela
            // 
            this.txtParentela.Location = new System.Drawing.Point(32, 224);
            this.txtParentela.Name = "txtParentela";
            this.txtParentela.Size = new System.Drawing.Size(75, 23);
            this.txtParentela.TabIndex = 9;
            this.txtParentela.Tag = "manage.affinity.default";
            this.txtParentela.Text = "Parentela";
            // 
            // grpGeo
            // 
            this.grpGeo.Controls.Add(this.chkEstero);
            this.grpGeo.Controls.Add(this.grpEstero);
            this.grpGeo.Controls.Add(this.grpItaliano);
            this.grpGeo.Controls.Add(this.txtDataNascita);
            this.grpGeo.Controls.Add(this.label7);
            this.grpGeo.Controls.Add(this.lblComuneStato);
            this.grpGeo.Controls.Add(this.btnAggiornaComune);
            this.grpGeo.Location = new System.Drawing.Point(8, 80);
            this.grpGeo.Name = "grpGeo";
            this.grpGeo.Size = new System.Drawing.Size(552, 104);
            this.grpGeo.TabIndex = 5;
            this.grpGeo.TabStop = false;
            this.grpGeo.Tag = "";
            this.grpGeo.Text = "Dati di nascita";
            // 
            // chkEstero
            // 
            this.chkEstero.Location = new System.Drawing.Point(152, 69);
            this.chkEstero.Name = "chkEstero";
            this.chkEstero.Size = new System.Drawing.Size(72, 24);
            this.chkEstero.TabIndex = 3;
            this.chkEstero.Tag = "parasubcontractfamily.flagforeign:S:N";
            this.chkEstero.Text = "Estero";
            this.chkEstero.CheckedChanged += new System.EventHandler(this.chkEstero_CheckedChanged);
            // 
            // grpEstero
            // 
            this.grpEstero.Controls.Add(this.txtGeoNazione);
            this.grpEstero.Location = new System.Drawing.Point(88, 16);
            this.grpEstero.Name = "grpEstero";
            this.grpEstero.Size = new System.Drawing.Size(344, 48);
            this.grpEstero.TabIndex = 1;
            this.grpEstero.TabStop = false;
            this.grpEstero.Tag = "AutoChoose.txtGeoNazione.default";
            // 
            // txtGeoNazione
            // 
            this.txtGeoNazione.Location = new System.Drawing.Point(8, 16);
            this.txtGeoNazione.Name = "txtGeoNazione";
            this.txtGeoNazione.Size = new System.Drawing.Size(328, 20);
            this.txtGeoNazione.TabIndex = 1;
            this.txtGeoNazione.Tag = "geo_nation.title?parasubcontractfamilyview.nation";
            // 
            // grpItaliano
            // 
            this.grpItaliano.Controls.Add(this.label9);
            this.grpItaliano.Controls.Add(this.txtProvincia);
            this.grpItaliano.Controls.Add(this.txtLocalitaGeo);
            this.grpItaliano.Location = new System.Drawing.Point(96, 16);
            this.grpItaliano.Name = "grpItaliano";
            this.grpItaliano.Size = new System.Drawing.Size(448, 48);
            this.grpItaliano.TabIndex = 0;
            this.grpItaliano.TabStop = false;
            this.grpItaliano.Tag = "AutoChoose.txtLocalitaGeo.default";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(344, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 18);
            this.label9.TabIndex = 154;
            this.label9.Text = "Provincia";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProvincia
            // 
            this.txtProvincia.Location = new System.Drawing.Point(400, 15);
            this.txtProvincia.Name = "txtProvincia";
            this.txtProvincia.ReadOnly = true;
            this.txtProvincia.Size = new System.Drawing.Size(40, 20);
            this.txtProvincia.TabIndex = 153;
            this.txtProvincia.TabStop = false;
            this.txtProvincia.Tag = "geo_cityview.provincecode";
            // 
            // txtLocalitaGeo
            // 
            this.txtLocalitaGeo.Location = new System.Drawing.Point(8, 16);
            this.txtLocalitaGeo.Name = "txtLocalitaGeo";
            this.txtLocalitaGeo.Size = new System.Drawing.Size(328, 20);
            this.txtLocalitaGeo.TabIndex = 3;
            this.txtLocalitaGeo.Tag = "geo_cityview.title?parasubcontractfamilyview.city";
            // 
            // txtDataNascita
            // 
            this.txtDataNascita.Location = new System.Drawing.Point(56, 71);
            this.txtDataNascita.Name = "txtDataNascita";
            this.txtDataNascita.Size = new System.Drawing.Size(88, 20);
            this.txtDataNascita.TabIndex = 2;
            this.txtDataNascita.Tag = "parasubcontractfamily.birthdate";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 18);
            this.label7.TabIndex = 148;
            this.label7.Text = "Data";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblComuneStato
            // 
            this.lblComuneStato.Location = new System.Drawing.Point(8, 40);
            this.lblComuneStato.Name = "lblComuneStato";
            this.lblComuneStato.Size = new System.Drawing.Size(80, 16);
            this.lblComuneStato.TabIndex = 146;
            this.lblComuneStato.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAggiornaComune
            // 
            this.btnAggiornaComune.Location = new System.Drawing.Point(416, 72);
            this.btnAggiornaComune.Name = "btnAggiornaComune";
            this.btnAggiornaComune.Size = new System.Drawing.Size(128, 23);
            this.btnAggiornaComune.TabIndex = 4;
            this.btnAggiornaComune.Text = "Aggiorna Stato estero";
            this.btnAggiornaComune.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAggiornaComune.Click += new System.EventHandler(this.btnAggiornaComune_Click);
            // 
            // grpSesso
            // 
            this.grpSesso.Controls.Add(this.radioButton2);
            this.grpSesso.Controls.Add(this.radioButton1);
            this.grpSesso.Location = new System.Drawing.Point(488, 8);
            this.grpSesso.Name = "grpSesso";
            this.grpSesso.Size = new System.Drawing.Size(72, 64);
            this.grpSesso.TabIndex = 4;
            this.grpSesso.TabStop = false;
            this.grpSesso.Text = "Sesso";
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(8, 40);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(56, 16);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Tag = "parasubcontractfamily.gender:F";
            this.radioButton2.Text = "F";
            // 
            // radioButton1
            // 
            this.radioButton1.Location = new System.Drawing.Point(8, 16);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(56, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Tag = "parasubcontractfamily.gender:M";
            this.radioButton1.Text = "M";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(120, 48);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(360, 20);
            this.txtNome.TabIndex = 3;
            this.txtNome.Tag = "parasubcontractfamily.forename";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtCognome
            // 
            this.txtCognome.Location = new System.Drawing.Point(120, 16);
            this.txtCognome.Name = "txtCognome";
            this.txtCognome.Size = new System.Drawing.Size(360, 20);
            this.txtCognome.TabIndex = 1;
            this.txtCognome.Tag = "parasubcontractfamily.surname";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cognome:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "Data Inizio Applicazione:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtInizioDetFiscali
            // 
            this.txtInizioDetFiscali.Location = new System.Drawing.Point(145, 22);
            this.txtInizioDetFiscali.Name = "txtInizioDetFiscali";
            this.txtInizioDetFiscali.Size = new System.Drawing.Size(88, 20);
            this.txtInizioDetFiscali.TabIndex = 21;
            this.txtInizioDetFiscali.Tag = "parasubcontractfamily.startapplication";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(10, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "Data Fine Applicazione:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtFineDetFiscali
            // 
            this.txtFineDetFiscali.Location = new System.Drawing.Point(145, 47);
            this.txtFineDetFiscali.Name = "txtFineDetFiscali";
            this.txtFineDetFiscali.Size = new System.Drawing.Size(88, 20);
            this.txtFineDetFiscali.TabIndex = 23;
            this.txtFineDetFiscali.Tag = "parasubcontractfamily.stopapplication";
            // 
            // grpDetFiscali
            // 
            this.grpDetFiscali.Controls.Add(this.textBox1);
            this.grpDetFiscali.Controls.Add(this.textBox2);
            this.grpDetFiscali.Controls.Add(this.label6);
            this.grpDetFiscali.Controls.Add(this.label4);
            this.grpDetFiscali.Controls.Add(this.txtInizioDetFiscali);
            this.grpDetFiscali.Controls.Add(this.txtFineDetFiscali);
            this.grpDetFiscali.Controls.Add(this.label5);
            this.grpDetFiscali.Location = new System.Drawing.Point(8, 270);
            this.grpDetFiscali.Name = "grpDetFiscali";
            this.grpDetFiscali.Size = new System.Drawing.Size(568, 107);
            this.grpDetFiscali.TabIndex = 1;
            this.grpDetFiscali.TabStop = false;
            this.grpDetFiscali.Text = "Detrazioni Fiscali - Informazioni sulla applicazione delle detrazioni";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(245, 19);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(315, 76);
            this.textBox1.TabIndex = 26;
            this.textBox1.TabStop = false;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(145, 75);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(88, 20);
            this.textBox2.TabIndex = 25;
            this.textBox2.Tag = "parasubcontractfamily.appliancepercentage.fixed.4..%.100";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 16);
            this.label6.TabIndex = 24;
            this.label6.Text = "% di Applicazione:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(5, 383);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 23);
            this.label8.TabIndex = 2;
            this.label8.Tag = "";
            this.label8.Text = "Inizio Portatore Handicap:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(149, 383);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(104, 20);
            this.textBox3.TabIndex = 3;
            this.textBox3.Tag = "parasubcontractfamily.starthandicap";
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(325, 382);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(120, 24);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Tag = "parasubcontractfamily.foreignresident:S:N";
            this.checkBox1.Text = "Residenza Estera";
            // 
            // checkBox2
            // 
            this.checkBox2.Location = new System.Drawing.Point(469, 382);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(104, 24);
            this.checkBox2.TabIndex = 0;
            this.checkBox2.Tag = "parasubcontractfamily.flagdependent:S:N";
            this.checkBox2.Text = "A Carico";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(336, 481);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Annulla";
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.Location = new System.Drawing.Point(168, 481);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Tag = "mainsave";
            this.button2.Text = "Ok";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblChiuldAsParent);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(8, 411);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(568, 53);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detrazione per questo familiare applicata in sede di conguaglio";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(141, 23);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(88, 20);
            this.textBox4.TabIndex = 22;
            this.textBox4.TabStop = false;
            this.textBox4.Tag = "parasubcontractfamily.amount";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(33, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 23);
            this.label10.TabIndex = 0;
            this.label10.Text = "Importo:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblChiuldAsParent
            // 
            this.lblChiuldAsParent.Location = new System.Drawing.Point(256, 23);
            this.lblChiuldAsParent.Name = "lblChiuldAsParent";
            this.lblChiuldAsParent.Size = new System.Drawing.Size(248, 23);
            this.lblChiuldAsParent.TabIndex = 23;
            this.lblChiuldAsParent.Text = "Figlio considerato come coniuge";
            this.lblChiuldAsParent.Visible = false;
            // 
            // Frm_parasubcontractfamily_contrattodetail
            // 
            this.AcceptButton = this.button2;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(584, 514);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.grpDetFiscali);
            this.Controls.Add(this.grpInfoGenerali);
            this.Name = "Frm_parasubcontractfamily_contrattodetail";
            this.Text = "frmfamiliaredettaglio";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.grpInfoGenerali.ResumeLayout(false);
            this.grpInfoGenerali.PerformLayout();
            this.grpGeo.ResumeLayout(false);
            this.grpGeo.PerformLayout();
            this.grpEstero.ResumeLayout(false);
            this.grpEstero.PerformLayout();
            this.grpItaliano.ResumeLayout(false);
            this.grpItaliano.PerformLayout();
            this.grpSesso.ResumeLayout(false);
            this.grpDetFiscali.ResumeLayout(false);
            this.grpDetFiscali.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public void MetaData_AfterLink() {
			Meta=MetaData.GetMetaData(this);
			HelpForm.SetDenyNull(DS.parasubcontractfamily.Columns["flagforeign"], true);
			VisualizzaCampiGeo();
		}

		// Funzione che gestisce la visualizzazione delle informazioni inerenti lo stato estero o il comune di nascita
		private void VisualizzaCampiGeo() {
			if (chkEstero.CheckState==CheckState.Checked) {
				grpItaliano.Visible=false;
				grpEstero.Visible=true;
				lblComuneStato.Text="Stato estero";
			}
			else {
				grpItaliano.Visible=true;
				grpEstero.Visible=false;
				lblComuneStato.Text="Comune";
			}
		}

		private void btnAggiornaComune_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
			if (chkEstero.Checked) {
				aggiornaStatoEstero();
			} 
			else {
				aggiornaComune();
			}
			Meta.FreshForm(true);
		}

		private void aggiornaComune() {
			if (Meta.IsEmpty) return;
			object idcomune = DS.parasubcontractfamily.Rows[0]["idcitybirth"];
			object[] list = new object[] {idcomune, "S"};
			DataSet DSout = Meta.Conn.CallSP("compute_history_city", list, true, -1);
			if (DSout==null || DSout.Tables.Count==0 || DS.Tables[0].Rows.Count==0) return;
			DataTable T = DSout.Tables[0];
			if (T.Rows.Count==1) {
				DS.parasubcontractfamily.Rows[0]["idcitybirth"] = T.Rows[0]["idcity"];
			}
			else {
				string filtro = "(idcity in (" +QueryCreator.ColumnValues(T, null, "idcity", true) + "))";
				MetaData metaComune = MetaData.GetMetaData(this, "geo_cityview");
				metaComune.DS = DS.Copy();
				metaComune.FilterLocked = true;

				DataRow r = metaComune.SelectOne("storia", filtro, null, null);

				if (r != null) {
					DS.parasubcontractfamily.Rows[0]["idcitybirth"] = r["idcity"];
				}
			}
			Meta.FreshForm(true);
		}

		private void aggiornaStatoEstero() {
			object idstatoestero=DS.parasubcontractfamily.Rows[0]["idnation"];
			if (idstatoestero == DBNull.Value) return;
			object[] list=new object[]{idstatoestero,"S"};
			DataSet DSout=Meta.Conn.CallSP("compute_history_nation",list,true,-1);
			if (DSout==null || DSout.Tables.Count==0 || DS.Tables[0].Rows.Count==0) return;
			DataTable T=DSout.Tables[0];
			if (T.Rows.Count==1) {
				DS.parasubcontractfamily.Rows[0]["idnation"]=T.Rows[0]["idnation"];
			}
			else {
				string filtro = "(idnation in (" +QueryCreator.ColumnValues(T, null, "idnazione", true) + "))";
				MetaData metaStatoEstero = MetaData.GetMetaData(this, "geo_nation");
				metaStatoEstero.DS = DS.Copy();
				metaStatoEstero.FilterLocked = true;

				DataRow r = metaStatoEstero.SelectOne("default", filtro, null, null);

				if (r!=null) {
					DS.parasubcontractfamily.Rows[0]["idnation"]=r["idnation"];
				}
			}
		}

		private void chkEstero_CheckedChanged(object sender, System.EventArgs e) {
			ConfiguraCampiGeo();
		}

		private void ConfiguraCampiGeo() {
			VisualizzaCampiGeo();

			if (!Meta.DrawStateIsDone) return;

			if (chkEstero.CheckState==CheckState.Checked) {
				if (!Meta.IsEmpty) {
					Meta.GetFormData(true);
					DS.parasubcontractfamily.Rows[0]["idnation"]=DBNull.Value;
					DS.geo_nation.Rows.Clear();
					Meta.FreshForm(grpEstero.Controls,true,"parasubcontractfamily");
				}
			}
			else {
				if (!Meta.IsEmpty) {
					Meta.GetFormData(true);
					DS.parasubcontractfamily.Rows[0]["idcitybirth"]=DBNull.Value;
					DS.geo_cityview.Rows.Clear();
					Meta.FreshForm(grpItaliano.Controls,true,"parasubcontractfamily");
				}
			}
		}
		/// <summary>
		/// Funzione che controlla se il comune o la nazione passata non siano validi con rispettiva visualizzazione
		/// del bottone "Aggiorna Comune", "Aggiorna Stato Estero"
		/// Il parametro comune_stato può assumere i seguenti valori: C - Comune; S - Stato
		/// </summary>
		/// <param name="codice"></param>
		/// <param name="comune_stato"></param>
		private void VisualizzaBottoneComune(int codice, string comune_stato) {
			bool visible=false;
			// Controllo sul Comune
			if(comune_stato=="C") {
				object val=Meta.Conn.DO_READ_VALUE("geo_cityusable", "idcity="+
					QueryCreator.quotedstrvalue(codice,true), "idcity");
				if (val==null) {
					btnAggiornaComune.Text = "Aggiorna Comune";
					visible = true;
				}
			}
			// Controllo sulla Nazione
			if (comune_stato=="S") {
				object val=Meta.Conn.DO_READ_VALUE("geo_nationusable", "idnation="+
					QueryCreator.quotedstrvalue(codice,true), "idnation");
				if (val==null) {
					btnAggiornaComune.Text = "Aggiorna Stato estero";
					visible = true;
				}
			}
			btnAggiornaComune.Visible=visible;
		}

		public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
			if (T.TableName == "geo_nation" && R!=null) {			
				VisualizzaBottoneComune(Convert.ToInt32(R["idnation"]),"S");
			}

			if ((!Meta.IsEmpty) && (R!=null) && (T.TableName == "geo_city")) {
				VisualizzaBottoneComune(Convert.ToInt32(R["idcity"]),"C");
			}
		}
		
		public void MetaData_AfterFill() {
			int codice;
			btnAggiornaComune.Visible = false;
			if (DS.parasubcontractfamily.Rows[0]["flagforeign"]!=DBNull.Value) {
				
				if(DS.parasubcontractfamily.Rows[0]["flagforeign"].ToString()=="N") {	
					if (DS.parasubcontractfamily.Rows[0]["idcitybirth"]!= DBNull.Value) {
						codice = Convert.ToInt32(DS.parasubcontractfamily.Rows[0]["idcitybirth"]);	
						VisualizzaBottoneComune(codice,"C");
					}
				}
				if(DS.parasubcontractfamily.Rows[0]["flagforeign"].ToString()=="S") {
					if (DS.parasubcontractfamily.Rows[0]["idnation"]!=DBNull.Value) {
						codice = Convert.ToInt32(DS.parasubcontractfamily.Rows[0]["idnation"]);
						VisualizzaBottoneComune(codice,"S");
					}
				}
			}
            if ((Meta.FirstFillForThisRow) && (Meta.EditMode)) {
                DataRow Curr = DS.parasubcontractfamily.Rows[0];
                if (Curr["childasparent"].ToString().ToUpper() == "S") {
                    lblChiuldAsParent.Visible = true;
                }
                else {
                    lblChiuldAsParent.Visible = false;
                }

            }
		}

		public void MetaData_AfterClear() {
			btnAggiornaComune.Visible = false;
		}

		private void button3_Click(object sender, System.EventArgs e) {
			string cognome;
			string nome;
			string sesso;
			DateTime datanascita;
			string codicelocalita;
			string tipogeo;
			bool IsValid;
			string errori;
			string CF;

			Meta.GetFormData(true);

			codicelocalita = "";
			tipogeo = "";
			if (DS.parasubcontractfamily.Rows[0]["surname"]==DBNull.Value) return;
			cognome = DS.parasubcontractfamily.Rows[0]["surname"].ToString();
			if (DS.parasubcontractfamily.Rows[0]["forename"]==DBNull.Value) return;
			nome = DS.parasubcontractfamily.Rows[0]["forename"].ToString();
			if (DS.parasubcontractfamily.Rows[0]["gender"]==DBNull.Value) return;
			sesso = DS.parasubcontractfamily.Rows[0]["gender"].ToString();
			if (DS.parasubcontractfamily.Rows[0]["birthdate"]==DBNull.Value) return;
			datanascita = (DateTime)DS.parasubcontractfamily.Rows[0]["birthdate"];
			if (DS.parasubcontractfamily.Rows[0]["flagforeign"]==DBNull.Value)return;
			if (DS.parasubcontractfamily.Rows[0]["flagforeign"].ToString()=="N") {
				if (DS.parasubcontractfamily.Rows[0]["idcitybirth"]!=DBNull.Value) {
					codicelocalita = DS.parasubcontractfamily.Rows[0]["idcitybirth"].ToString();
					tipogeo = "C";
				}
			}
			if (DS.parasubcontractfamily.Rows[0]["flagforeign"].ToString()=="S") {
				if (DS.parasubcontractfamily.Rows[0]["idnation"]!=DBNull.Value) {
					codicelocalita = DS.parasubcontractfamily.Rows[0]["idnation"].ToString();
					tipogeo = "N";
				}
			}

			CF = CalcolaCodiceFiscale.Make(Meta.Conn,nome,cognome,datanascita,codicelocalita,sesso,tipogeo,out IsValid,out errori);

			if (IsValid) 
				txtCF.Text=CF;
			else
				show("Sono stati riscontrati i seguenti errori "+
					"durante il calcolo del codice fiscale:\r\r"+errori,"Calcolo Codice Fiscale",
					MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
		}

		private void button4_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
			string errori;
			
			string idgeo;
			bool ok = Meta.GetFormData(true);
			CalcolaCodiceFiscale.CheckCF(txtCF.Text,out errori);
			if (errori != "") {
				errori = "Nel codice fiscale inserito compaiono i seguenti errori:\n\r " + errori;
				show(this,errori,"",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				return;
			}

			DataRow R=DS.parasubcontractfamily.Rows[0];
			string codicefiscale=R["cf"].ToString().ToUpper();
			codicefiscale = CalcolaCodiceFiscale.normalizza(codicefiscale);
					
			chkEstero.Checked = (codicefiscale[11] == 'Z');
			string sesso=InfoDaCodiceFiscale.Sesso(codicefiscale);
			object datanascita=InfoDaCodiceFiscale.DataNascita(Meta.Conn, codicefiscale);
			if (sesso!=null) R["gender"]=sesso;
			if (datanascita!=null) R["birthdate"]=datanascita;
			if (!chkEstero.Checked) {
				string idcomune=InfoDaCodiceFiscale.Comune(Meta.Conn, codicefiscale);
				if ((idcomune!=null)&&(idcomune!="")) {
					R["idcitybirth"]=idcomune;
					idgeo = idcomune;
				} 
				else {
					show(this, "Impossibile ricavare il comune dal codice '"+codicefiscale.Substring(11,4)+"'", "Elaborazione del codice fiscale",
						MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				}
			} 
			else {
				string idnazione=InfoDaCodiceFiscale.Nazione(Meta.Conn, codicefiscale);
				if ((idnazione!=null)&&(idnazione!="")) {
					R["idnation"]=idnazione;
					idgeo = idnazione;
				} 
				else {
					show(this, "Impossibile ricavare lo stato estero dal codice '"+codicefiscale.Substring(11,4)+"'", "Elaborazione del codice fiscale",
						MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				}
			}
			Meta.FreshForm(true);
		}
	}
}
