
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
using funzioni_configurazione;


namespace incomevar_detail//variazioneentratadettaglio//
{
	/// <summary>
	/// Summary description for FrmVariazioneEntrataDettaglio.
	/// </summary>
	public class Frm_incomevar_detail : MetaDataForm
	{
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.GroupBox grpImporto;
		private System.Windows.Forms.RadioButton rdbAumento;
		private System.Windows.Forms.RadioButton rdbDiminuzione;
		private System.Windows.Forms.TextBox txtImporto;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtDataDocumento;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtDocumento;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox grpVariazione;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtNumVariazione;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtEsercVariazione;
		private System.Windows.Forms.GroupBox grpMovimento;
		private System.Windows.Forms.ComboBox cmbFase;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtNumSpesa;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtEsercSpesa;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtDataContabile;
		private System.Windows.Forms.Label label7;
		MetaData Meta;
		public  vistaForm DS;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton radAnnPar;
		private System.Windows.Forms.RadioButton radAnnullo;
		private System.Windows.Forms.RadioButton radNormale;
        private RadioButton radEdit;
        private GroupBox groupBox6;
        private Label label14;
        private TextBox textBox2;
        private Label label15;
        private TextBox textBox3;
        private bool maxphase = false;
		private RadioButton radCsa;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_incomevar_detail()
		{
			InitializeComponent();
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
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.grpImporto = new System.Windows.Forms.GroupBox();
			this.rdbAumento = new System.Windows.Forms.RadioButton();
			this.rdbDiminuzione = new System.Windows.Forms.RadioButton();
			this.txtImporto = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtDataDocumento = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtDocumento = new System.Windows.Forms.TextBox();
			this.txtDescrizione = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.grpVariazione = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtNumVariazione = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtEsercVariazione = new System.Windows.Forms.TextBox();
			this.grpMovimento = new System.Windows.Forms.GroupBox();
			this.cmbFase = new System.Windows.Forms.ComboBox();
			this.DS = new incomevar_detail.vistaForm();
			this.label3 = new System.Windows.Forms.Label();
			this.txtNumSpesa = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtEsercSpesa = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtDataContabile = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.radEdit = new System.Windows.Forms.RadioButton();
			this.radAnnPar = new System.Windows.Forms.RadioButton();
			this.radAnnullo = new System.Windows.Forms.RadioButton();
			this.radNormale = new System.Windows.Forms.RadioButton();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.label14 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.radCsa = new System.Windows.Forms.RadioButton();
			this.grpImporto.SuspendLayout();
			this.grpVariazione.SuspendLayout();
			this.grpMovimento.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(429, 380);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 12;
			this.btnOk.Tag = "mainsave";
			this.btnOk.Text = "Ok";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(301, 380);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 11;
			this.btnCancel.Text = "Cancel";
			// 
			// grpImporto
			// 
			this.grpImporto.Controls.Add(this.rdbAumento);
			this.grpImporto.Controls.Add(this.rdbDiminuzione);
			this.grpImporto.Controls.Add(this.txtImporto);
			this.grpImporto.Location = new System.Drawing.Point(225, 187);
			this.grpImporto.Name = "grpImporto";
			this.grpImporto.Size = new System.Drawing.Size(272, 64);
			this.grpImporto.TabIndex = 5;
			this.grpImporto.TabStop = false;
			this.grpImporto.Tag = "incomevar.amount.valuesigned";
			this.grpImporto.Text = "Importo";
			// 
			// rdbAumento
			// 
			this.rdbAumento.Location = new System.Drawing.Point(152, 16);
			this.rdbAumento.Name = "rdbAumento";
			this.rdbAumento.Size = new System.Drawing.Size(104, 16);
			this.rdbAumento.TabIndex = 2;
			this.rdbAumento.Tag = "+";
			this.rdbAumento.Text = "Aumento";
			// 
			// rdbDiminuzione
			// 
			this.rdbDiminuzione.Location = new System.Drawing.Point(152, 40);
			this.rdbDiminuzione.Name = "rdbDiminuzione";
			this.rdbDiminuzione.Size = new System.Drawing.Size(104, 16);
			this.rdbDiminuzione.TabIndex = 3;
			this.rdbDiminuzione.Tag = "-";
			this.rdbDiminuzione.Text = "Diminuzione";
			// 
			// txtImporto
			// 
			this.txtImporto.Location = new System.Drawing.Point(16, 24);
			this.txtImporto.Name = "txtImporto";
			this.txtImporto.Size = new System.Drawing.Size(120, 20);
			this.txtImporto.TabIndex = 1;
			this.txtImporto.Tag = "incomevar.amount";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(512, 226);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(150, 24);
			this.label8.TabIndex = 124;
			this.label8.Text = "Data documento";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDataDocumento
			// 
			this.txtDataDocumento.Location = new System.Drawing.Point(515, 253);
			this.txtDataDocumento.Name = "txtDataDocumento";
			this.txtDataDocumento.Size = new System.Drawing.Size(116, 20);
			this.txtDataDocumento.TabIndex = 7;
			this.txtDataDocumento.Tag = "incomevar.docdate";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(512, 187);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(96, 20);
			this.label9.TabIndex = 122;
			this.label9.Text = "Documento";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDocumento
			// 
			this.txtDocumento.Location = new System.Drawing.Point(515, 203);
			this.txtDocumento.Name = "txtDocumento";
			this.txtDocumento.Size = new System.Drawing.Size(221, 20);
			this.txtDocumento.TabIndex = 6;
			this.txtDocumento.Tag = "incomevar.doc";
			// 
			// txtDescrizione
			// 
			this.txtDescrizione.Location = new System.Drawing.Point(235, 118);
			this.txtDescrizione.Multiline = true;
			this.txtDescrizione.Name = "txtDescrizione";
			this.txtDescrizione.Size = new System.Drawing.Size(386, 66);
			this.txtDescrizione.TabIndex = 3;
			this.txtDescrizione.Tag = "incomevar.description";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(232, 91);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 24);
			this.label5.TabIndex = 117;
			this.label5.Text = "Descrizione";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// grpVariazione
			// 
			this.grpVariazione.Controls.Add(this.label1);
			this.grpVariazione.Controls.Add(this.txtNumVariazione);
			this.grpVariazione.Controls.Add(this.label2);
			this.grpVariazione.Controls.Add(this.txtEsercVariazione);
			this.grpVariazione.Location = new System.Drawing.Point(8, 96);
			this.grpVariazione.Name = "grpVariazione";
			this.grpVariazione.Size = new System.Drawing.Size(211, 85);
			this.grpVariazione.TabIndex = 2;
			this.grpVariazione.TabStop = false;
			this.grpVariazione.Text = "Variazione";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(10, 50);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 24);
			this.label1.TabIndex = 11;
			this.label1.Text = "Numero:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtNumVariazione
			// 
			this.txtNumVariazione.Location = new System.Drawing.Point(74, 50);
			this.txtNumVariazione.Name = "txtNumVariazione";
			this.txtNumVariazione.ReadOnly = true;
			this.txtNumVariazione.Size = new System.Drawing.Size(96, 20);
			this.txtNumVariazione.TabIndex = 10;
			this.txtNumVariazione.TabStop = false;
			this.txtNumVariazione.Tag = "incomevar.nvar";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(10, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 24);
			this.label2.TabIndex = 9;
			this.label2.Text = "Esercizio:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtEsercVariazione
			// 
			this.txtEsercVariazione.Location = new System.Drawing.Point(74, 16);
			this.txtEsercVariazione.Name = "txtEsercVariazione";
			this.txtEsercVariazione.ReadOnly = true;
			this.txtEsercVariazione.Size = new System.Drawing.Size(56, 20);
			this.txtEsercVariazione.TabIndex = 8;
			this.txtEsercVariazione.TabStop = false;
			this.txtEsercVariazione.Tag = "incomevar.yvar";
			// 
			// grpMovimento
			// 
			this.grpMovimento.Controls.Add(this.cmbFase);
			this.grpMovimento.Controls.Add(this.label3);
			this.grpMovimento.Controls.Add(this.txtNumSpesa);
			this.grpMovimento.Controls.Add(this.label4);
			this.grpMovimento.Controls.Add(this.txtEsercSpesa);
			this.grpMovimento.Controls.Add(this.label10);
			this.grpMovimento.Location = new System.Drawing.Point(8, 8);
			this.grpMovimento.Name = "grpMovimento";
			this.grpMovimento.Size = new System.Drawing.Size(480, 80);
			this.grpMovimento.TabIndex = 1;
			this.grpMovimento.TabStop = false;
			this.grpMovimento.Tag = "";
			this.grpMovimento.Text = "Movimento";
			// 
			// cmbFase
			// 
			this.cmbFase.DataSource = this.DS.incomephase;
			this.cmbFase.DisplayMember = "description";
			this.cmbFase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbFase.Enabled = false;
			this.cmbFase.ItemHeight = 13;
			this.cmbFase.Location = new System.Drawing.Point(104, 16);
			this.cmbFase.Name = "cmbFase";
			this.cmbFase.Size = new System.Drawing.Size(264, 21);
			this.cmbFase.TabIndex = 1;
			this.cmbFase.Tag = "";
			this.cmbFase.ValueMember = "nphase";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(200, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 24);
			this.label3.TabIndex = 7;
			this.label3.Text = "Numero:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtNumSpesa
			// 
			this.txtNumSpesa.Location = new System.Drawing.Point(264, 48);
			this.txtNumSpesa.Name = "txtNumSpesa";
			this.txtNumSpesa.ReadOnly = true;
			this.txtNumSpesa.Size = new System.Drawing.Size(96, 20);
			this.txtNumSpesa.TabIndex = 6;
			this.txtNumSpesa.TabStop = false;
			this.txtNumSpesa.Tag = "";
			this.txtNumSpesa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(40, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 24);
			this.label4.TabIndex = 5;
			this.label4.Text = "Esercizio:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtEsercSpesa
			// 
			this.txtEsercSpesa.Location = new System.Drawing.Point(104, 48);
			this.txtEsercSpesa.Name = "txtEsercSpesa";
			this.txtEsercSpesa.ReadOnly = true;
			this.txtEsercSpesa.Size = new System.Drawing.Size(56, 20);
			this.txtEsercSpesa.TabIndex = 4;
			this.txtEsercSpesa.TabStop = false;
			this.txtEsercSpesa.Tag = "";
			this.txtEsercSpesa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(24, 16);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(72, 24);
			this.label10.TabIndex = 90;
			this.label10.Text = "Fase:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDataContabile
			// 
			this.txtDataContabile.Location = new System.Drawing.Point(376, 264);
			this.txtDataContabile.Name = "txtDataContabile";
			this.txtDataContabile.Size = new System.Drawing.Size(116, 20);
			this.txtDataContabile.TabIndex = 9;
			this.txtDataContabile.Tag = "incomevar.adate";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(296, 264);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(80, 24);
			this.label7.TabIndex = 120;
			this.label7.Text = "Data cont.:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButton3);
			this.groupBox1.Controls.Add(this.radioButton1);
			this.groupBox1.Location = new System.Drawing.Point(8, 329);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(207, 43);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Tag = "";
			this.groupBox1.Text = "Tipo trasferimento";
			// 
			// radioButton3
			// 
			this.radioButton3.Location = new System.Drawing.Point(119, 18);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(80, 16);
			this.radioButton3.TabIndex = 2;
			this.radioButton3.Tag = "incomevar.transferkind:A";
			this.radioButton3.Text = "Altro";
			// 
			// radioButton1
			// 
			this.radioButton1.Location = new System.Drawing.Point(15, 18);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(80, 16);
			this.radioButton1.TabIndex = 1;
			this.radioButton1.Tag = "incomevar.transferkind:I";
			this.radioButton1.Text = "Interno";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.radCsa);
			this.groupBox2.Controls.Add(this.radEdit);
			this.groupBox2.Controls.Add(this.radAnnPar);
			this.groupBox2.Controls.Add(this.radAnnullo);
			this.groupBox2.Controls.Add(this.radNormale);
			this.groupBox2.Location = new System.Drawing.Point(8, 187);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(211, 126);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Tipo variazione";
			// 
			// radEdit
			// 
			this.radEdit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.radEdit.Location = new System.Drawing.Point(16, 74);
			this.radEdit.Name = "radEdit";
			this.radEdit.Size = new System.Drawing.Size(189, 31);
			this.radEdit.TabIndex = 8;
			this.radEdit.Text = "Modifica Dati di Incassi Trasmessi";
			// 
			// radAnnPar
			// 
			this.radAnnPar.Location = new System.Drawing.Point(16, 57);
			this.radAnnPar.Name = "radAnnPar";
			this.radAnnPar.Size = new System.Drawing.Size(152, 16);
			this.radAnnPar.TabIndex = 2;
			this.radAnnPar.Text = "Annullamento parziale";
			// 
			// radAnnullo
			// 
			this.radAnnullo.Enabled = false;
			this.radAnnullo.Location = new System.Drawing.Point(16, 37);
			this.radAnnullo.Name = "radAnnullo";
			this.radAnnullo.Size = new System.Drawing.Size(152, 16);
			this.radAnnullo.TabIndex = 1;
			this.radAnnullo.Text = "Annullamento reversale";
			// 
			// radNormale
			// 
			this.radNormale.Location = new System.Drawing.Point(16, 16);
			this.radNormale.Name = "radNormale";
			this.radNormale.Size = new System.Drawing.Size(104, 16);
			this.radNormale.TabIndex = 0;
			this.radNormale.Text = "Normale";
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.label14);
			this.groupBox6.Controls.Add(this.textBox2);
			this.groupBox6.Controls.Add(this.label15);
			this.groupBox6.Controls.Add(this.textBox3);
			this.groupBox6.Location = new System.Drawing.Point(235, 330);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(427, 44);
			this.groupBox6.TabIndex = 10;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Distinta di trasmissione ";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(216, 20);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(72, 16);
			this.label14.TabIndex = 86;
			this.label14.Text = "Data trasm.:";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(294, 19);
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(96, 20);
			this.textBox2.TabIndex = 12;
			this.textBox2.TabStop = false;
			this.textBox2.Tag = "proceedstransmission.transmissiondate";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(24, 19);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(72, 16);
			this.label15.TabIndex = 84;
			this.label15.Text = "Numero:";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(104, 19);
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(96, 20);
			this.textBox3.TabIndex = 11;
			this.textBox3.TabStop = false;
			this.textBox3.Tag = "proceedstransmission.nproceedstransmission";
			// 
			// radCsa
			// 
			this.radCsa.Enabled = false;
			this.radCsa.Location = new System.Drawing.Point(15, 101);
			this.radCsa.Name = "radCsa";
			this.radCsa.Size = new System.Drawing.Size(190, 19);
			this.radCsa.TabIndex = 9;
			this.radCsa.Text = "Azzeramento Versamenti CSA";
			// 
			// Frm_incomevar_detail
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(758, 425);
			this.Controls.Add(this.groupBox6);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.grpImporto);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.txtDataDocumento);
			this.Controls.Add(this.txtDocumento);
			this.Controls.Add(this.txtDescrizione);
			this.Controls.Add(this.txtDataContabile);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.grpVariazione);
			this.Controls.Add(this.grpMovimento);
			this.Controls.Add(this.label7);
			this.Name = "Frm_incomevar_detail";
			this.Text = "FrmVariazioneEntrataDettaglio";
			this.Load += new System.EventHandler(this.Frm_incomevar_detail_Load);
			this.grpImporto.ResumeLayout(false);
			this.grpImporto.PerformLayout();
			this.grpVariazione.ResumeLayout(false);
			this.grpVariazione.PerformLayout();
			this.grpMovimento.ResumeLayout(false);
			this.grpMovimento.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
			GetData.CacheTable(DS.incomephase,null,null,true);
		}
        
		public void MetaData_AfterActivation(){
			//Fill GroupBox "Movimento"
			DataRow ParentEntrata = Meta.SourceRow.Table.DataSet.Tables["income"].Rows[0];
			cmbFase.SelectedValue= ParentEntrata["nphase"];
            int faseentratamax = CfgFn.GetNoNullInt32(Meta.GetSys("maxincomephase"));
            if (CfgFn.GetNoNullInt32(ParentEntrata["nphase"]) == faseentratamax){
                maxphase = true;
            }
            else{
                maxphase = false;
            }
            radEdit.Enabled = maxphase;
			txtEsercSpesa.Text= ParentEntrata["ymov"].ToString();
			txtNumSpesa.Text= ParentEntrata["nmov"].ToString();
		}

		public void MetaData_AfterFill()
		{
			EnableDisableCheckAnnullo();
			FillAnnullo();

			DataRow R = Meta.SourceRow.GetParentRow("incomeincomevar");
			txtEsercSpesa.Text= R["ymov"].ToString();
			if (R.RowState==DataRowState.Added)
				txtNumSpesa.Text="";
			else
				txtNumSpesa.Text=R["nmov"].ToString();
			DataRow fase = R.GetParentRow("incomeincomephase");
			if (fase!=null) grpMovimento.Text= fase["description"].ToString();

		}

		void EnableDisableCheckAnnullo()
		{
			if (Meta.IsEmpty) 
			{
				radNormale.Enabled=false;
				radAnnPar.Enabled=false;
				return;
			}
			DataRow R= DS.incomevar.Rows[0];
            int currauto = CfgFn.GetNoNullInt32(R["autokind"]);
            if ((currauto == 0) || (currauto == 10) || (currauto == 22))
            { //ANPAR
                radNormale.Enabled = true;
                radAnnPar.Enabled = true;
                radEdit.Enabled = maxphase;
            }
            else
            {
                radNormale.Enabled = false;
                radAnnPar.Enabled = false;
                radEdit.Enabled = false;
            }
        }

		void FillAnnullo()
		{
			if (Meta.IsEmpty) 
			{
				return;
			}
			DataRow R= DS.incomevar.Rows[0];
            int currauto = CfgFn.GetNoNullInt32(R["autokind"]);
            if (currauto == 11) //ANNULL
                radAnnullo.Checked = true;
            else
                radAnnullo.Checked = false;
            if (currauto == 10) //ANPAR
                radAnnPar.Checked = true;
            else
                radAnnPar.Checked = false;
            if (currauto == 22)  //EDIT
                radEdit.Checked = true;
            else
                radEdit.Checked = false;
			if (currauto == 32)  //AZZERACSA
				radCsa.Checked = true;
			else
				radCsa.Checked = false;
			if (currauto == 0)
                radNormale.Checked = true;
            else
                radNormale.Checked = false;
        }

		void GetAnnullo()
		{
			if (Meta.IsEmpty) return;
			if (radAnnPar.Enabled==false) return;
			if (radNormale.Enabled==false) return;
			DataRow R= DS.incomevar.Rows[0];
            int currauto = CfgFn.GetNoNullInt32(R["autokind"]);
            if (radNormale.Checked) {
                if (currauto != 0) R["autokind"] = 0;
            }
            if (radEdit.Checked)
            {
                if (currauto != 22) R["autokind"] = 22;  //EDIT
            }
            if (radAnnPar.Checked) {
                if (currauto != 10) R["autokind"] = 10;  //ANPAR
            }
			if (radCsa.Checked) {
				if (currauto != 32) R["autokind"] = 32;  //AZZERACSA
			}
		}

		public void MetaData_AfterGetFormData()
		{
			GetAnnullo();
		}

        private void Frm_incomevar_detail_Load(object sender, EventArgs e) {

        }

	}
}
