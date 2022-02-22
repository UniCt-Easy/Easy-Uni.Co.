
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
using metaeasylibrary;

namespace reportparameter_single//reportparametersingle//
{
	/// <summary>
	/// Summary description for frmreportparametersingle.
	/// </summary>
	public class Frm_reportparameter_single : MetaDataForm {
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox txtNomePar;
		private System.Windows.Forms.ComboBox cmbTipo;
		private System.Windows.Forms.TextBox txtFilter;
		private System.Windows.Forms.TextBox txtHelp;
		private System.Windows.Forms.RadioButton rdbNoValue;
		private System.Windows.Forms.RadioButton rdbPrimoGAnno;
		private System.Windows.Forms.RadioButton rdbUltimoGAnno;
		private System.Windows.Forms.RadioButton rdbPrimoGMese;
		private System.Windows.Forms.TextBox txtNumber;
		private System.Windows.Forms.RadioButton rdbUltimoGMese;
		private System.Windows.Forms.RadioButton rdbAltro;
		private System.Windows.Forms.RadioButton rdbEsercCorr;
		private System.Windows.Forms.RadioButton rdbDataCont;
		private System.Windows.Forms.TextBox txtDefValue;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.ComboBox cmbComboTable;
		private System.Windows.Forms.ComboBox cmbComboDescField;
		private System.Windows.Forms.ComboBox cmbComboCodeField;
		private System.Windows.Forms.CheckBox ckbFlagNoSelection;
		private System.Windows.Forms.CheckBox ckbFlagCombo;
		MetaData Meta;
		public vistaForm DS;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.RadioButton rdoCheck;
		private System.Windows.Forms.RadioButton rdoRadio;
		private System.Windows.Forms.RadioButton rdoCostant;
		private System.Windows.Forms.RadioButton rdoCustom;
		private System.Windows.Forms.CheckBox chkHidden;
		private System.Windows.Forms.TextBox txtCheck;
		private System.Windows.Forms.TextBox txtRadio;
		private System.Windows.Forms.GroupBox grpCostant;
		private System.Windows.Forms.GroupBox grpCheck;
		private System.Windows.Forms.GroupBox grpCustom;
		private System.Windows.Forms.GroupBox grpRadio;
		private System.Windows.Forms.ComboBox cboCustom;
		private System.Windows.Forms.GroupBox grpAbilitaCustom;
		private System.Windows.Forms.CheckBox chkAbilitaCustom;
		private System.Windows.Forms.Button btnCheck;
		private System.Windows.Forms.Button btnRadio;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label5;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_reportparameter_single() {
			InitializeComponent();
			HelpForm.SetDenyNull(DS.reportparameter.Columns["iscombobox"], true);
			DataAccess.SetTableForReading(DS.columntypescombodescfield, "columntypes");
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
			this.txtDescrizione = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtNomePar = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.cmbTipo = new System.Windows.Forms.ComboBox();
			this.DS = new reportparameter_single.vistaForm();
			this.label1 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.txtFilter = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtHelp = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rdbAltro = new System.Windows.Forms.RadioButton();
			this.rdbEsercCorr = new System.Windows.Forms.RadioButton();
			this.rdbDataCont = new System.Windows.Forms.RadioButton();
			this.rdbUltimoGMese = new System.Windows.Forms.RadioButton();
			this.rdbPrimoGMese = new System.Windows.Forms.RadioButton();
			this.rdbUltimoGAnno = new System.Windows.Forms.RadioButton();
			this.rdbPrimoGAnno = new System.Windows.Forms.RadioButton();
			this.rdbNoValue = new System.Windows.Forms.RadioButton();
			this.txtDefValue = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.ckbFlagNoSelection = new System.Windows.Forms.CheckBox();
			this.label12 = new System.Windows.Forms.Label();
			this.cmbComboCodeField = new System.Windows.Forms.ComboBox();
			this.label11 = new System.Windows.Forms.Label();
			this.cmbComboDescField = new System.Windows.Forms.ComboBox();
			this.label10 = new System.Windows.Forms.Label();
			this.cmbComboTable = new System.Windows.Forms.ComboBox();
			this.ckbFlagCombo = new System.Windows.Forms.CheckBox();
			this.txtNumber = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.grpAbilitaCustom = new System.Windows.Forms.GroupBox();
			this.grpRadio = new System.Windows.Forms.GroupBox();
			this.btnRadio = new System.Windows.Forms.Button();
			this.txtRadio = new System.Windows.Forms.TextBox();
			this.grpCustom = new System.Windows.Forms.GroupBox();
			this.cboCustom = new System.Windows.Forms.ComboBox();
			this.rdoCustom = new System.Windows.Forms.RadioButton();
			this.grpCostant = new System.Windows.Forms.GroupBox();
			this.chkHidden = new System.Windows.Forms.CheckBox();
			this.rdoCheck = new System.Windows.Forms.RadioButton();
			this.rdoRadio = new System.Windows.Forms.RadioButton();
			this.rdoCostant = new System.Windows.Forms.RadioButton();
			this.chkAbilitaCustom = new System.Windows.Forms.CheckBox();
			this.grpCheck = new System.Windows.Forms.GroupBox();
			this.btnCheck = new System.Windows.Forms.Button();
			this.txtCheck = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.grpAbilitaCustom.SuspendLayout();
			this.grpRadio.SuspendLayout();
			this.grpCustom.SuspendLayout();
			this.grpCostant.SuspendLayout();
			this.grpCheck.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtDescrizione
			// 
			this.txtDescrizione.Location = new System.Drawing.Point(80, 32);
			this.txtDescrizione.Name = "txtDescrizione";
			this.txtDescrizione.Size = new System.Drawing.Size(280, 20);
			this.txtDescrizione.TabIndex = 7;
			this.txtDescrizione.Tag = "reportparameter.description";
			this.txtDescrizione.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 32);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 24);
			this.label3.TabIndex = 6;
			this.label3.Text = "Descrizione:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtNomePar
			// 
			this.txtNomePar.Location = new System.Drawing.Point(80, 8);
			this.txtNomePar.Name = "txtNomePar";
			this.txtNomePar.Size = new System.Drawing.Size(280, 20);
			this.txtNomePar.TabIndex = 5;
			this.txtNomePar.Tag = "reportparameter.paramname";
			this.txtNomePar.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 24);
			this.label2.TabIndex = 4;
			this.label2.Text = "Nome:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(368, 8);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 24);
			this.label4.TabIndex = 9;
			this.label4.Text = "Tipo:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbTipo
			// 
			this.cmbTipo.DataSource = this.DS.tmp_tipo;
			this.cmbTipo.DisplayMember = "tipo";
			this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTipo.Location = new System.Drawing.Point(424, 8);
			this.cmbTipo.Name = "cmbTipo";
			this.cmbTipo.Size = new System.Drawing.Size(248, 21);
			this.cmbTipo.TabIndex = 8;
			this.cmbTipo.Tag = "";
			this.cmbTipo.ValueMember = "codice";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(368, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 24);
			this.label1.TabIndex = 11;
			this.label1.Text = "Tag:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(24, 56);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 24);
			this.label6.TabIndex = 15;
			this.label6.Text = "Numero:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(592, 512);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 18;
			this.btnOK.Tag = "mainsave";
			this.btnOK.Text = "OK";
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(592, 552);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.TabIndex = 19;
			this.btnAnnulla.Text = "Annulla";
			// 
			// txtFilter
			// 
			this.txtFilter.Location = new System.Drawing.Point(80, 80);
			this.txtFilter.Multiline = true;
			this.txtFilter.Name = "txtFilter";
			this.txtFilter.Size = new System.Drawing.Size(592, 24);
			this.txtFilter.TabIndex = 21;
			this.txtFilter.Tag = "reportparameter.filter";
			this.txtFilter.Text = "";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(8, 80);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(72, 24);
			this.label8.TabIndex = 20;
			this.label8.Text = "Filtro:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtHelp
			// 
			this.txtHelp.Location = new System.Drawing.Point(80, 112);
			this.txtHelp.Multiline = true;
			this.txtHelp.Name = "txtHelp";
			this.txtHelp.Size = new System.Drawing.Size(240, 56);
			this.txtHelp.TabIndex = 23;
			this.txtHelp.Tag = "reportparameter.help";
			this.txtHelp.Text = "";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(8, 112);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(72, 24);
			this.label9.TabIndex = 22;
			this.label9.Text = "Guida Web:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rdbAltro);
			this.groupBox1.Controls.Add(this.rdbEsercCorr);
			this.groupBox1.Controls.Add(this.rdbDataCont);
			this.groupBox1.Controls.Add(this.rdbUltimoGMese);
			this.groupBox1.Controls.Add(this.rdbPrimoGMese);
			this.groupBox1.Controls.Add(this.rdbUltimoGAnno);
			this.groupBox1.Controls.Add(this.rdbPrimoGAnno);
			this.groupBox1.Controls.Add(this.rdbNoValue);
			this.groupBox1.Controls.Add(this.txtDefValue);
			this.groupBox1.Location = new System.Drawing.Point(8, 176);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(168, 184);
			this.groupBox1.TabIndex = 24;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Valore predefinito";
			// 
			// rdbAltro
			// 
			this.rdbAltro.Location = new System.Drawing.Point(8, 128);
			this.rdbAltro.Name = "rdbAltro";
			this.rdbAltro.Size = new System.Drawing.Size(152, 16);
			this.rdbAltro.TabIndex = 7;
			this.rdbAltro.Tag = "reportparameter.hintkind:STRING";
			this.rdbAltro.Text = "Altro";
			this.rdbAltro.CheckedChanged += new System.EventHandler(this.rdbAltro_CheckedChanged);
			// 
			// rdbEsercCorr
			// 
			this.rdbEsercCorr.Location = new System.Drawing.Point(8, 112);
			this.rdbEsercCorr.Name = "rdbEsercCorr";
			this.rdbEsercCorr.Size = new System.Drawing.Size(152, 16);
			this.rdbEsercCorr.TabIndex = 6;
			this.rdbEsercCorr.Tag = "reportparameter.hintkind:ACCOUNTYEAR";
			this.rdbEsercCorr.Text = "Esercizio corrente";
			// 
			// rdbDataCont
			// 
			this.rdbDataCont.Location = new System.Drawing.Point(8, 96);
			this.rdbDataCont.Name = "rdbDataCont";
			this.rdbDataCont.Size = new System.Drawing.Size(152, 16);
			this.rdbDataCont.TabIndex = 5;
			this.rdbDataCont.Tag = "reportparameter.hintkind:ACCOUNTDATE";
			this.rdbDataCont.Text = "Data contabile";
			// 
			// rdbUltimoGMese
			// 
			this.rdbUltimoGMese.Location = new System.Drawing.Point(8, 80);
			this.rdbUltimoGMese.Name = "rdbUltimoGMese";
			this.rdbUltimoGMese.Size = new System.Drawing.Size(152, 16);
			this.rdbUltimoGMese.TabIndex = 4;
			this.rdbUltimoGMese.Tag = "reportparameter.hintkind:LASTDAY/CURRM";
			this.rdbUltimoGMese.Text = "Ultimo giorno del mese";
			// 
			// rdbPrimoGMese
			// 
			this.rdbPrimoGMese.Location = new System.Drawing.Point(8, 48);
			this.rdbPrimoGMese.Name = "rdbPrimoGMese";
			this.rdbPrimoGMese.Size = new System.Drawing.Size(152, 16);
			this.rdbPrimoGMese.TabIndex = 2;
			this.rdbPrimoGMese.Tag = "reportparameter.hintkind:1/CURRM";
			this.rdbPrimoGMese.Text = "Primo giorno del mese";
			// 
			// rdbUltimoGAnno
			// 
			this.rdbUltimoGAnno.Location = new System.Drawing.Point(8, 64);
			this.rdbUltimoGAnno.Name = "rdbUltimoGAnno";
			this.rdbUltimoGAnno.Size = new System.Drawing.Size(152, 16);
			this.rdbUltimoGAnno.TabIndex = 3;
			this.rdbUltimoGAnno.Tag = "reportparameter.hintkind:31/12";
			this.rdbUltimoGAnno.Text = "Ultimo giorno dell\'anno";
			// 
			// rdbPrimoGAnno
			// 
			this.rdbPrimoGAnno.Location = new System.Drawing.Point(8, 32);
			this.rdbPrimoGAnno.Name = "rdbPrimoGAnno";
			this.rdbPrimoGAnno.Size = new System.Drawing.Size(152, 16);
			this.rdbPrimoGAnno.TabIndex = 1;
			this.rdbPrimoGAnno.Tag = "reportparameter.hintkind:1/1";
			this.rdbPrimoGAnno.Text = "Primo giorno dell\'anno";
			// 
			// rdbNoValue
			// 
			this.rdbNoValue.Location = new System.Drawing.Point(8, 16);
			this.rdbNoValue.Name = "rdbNoValue";
			this.rdbNoValue.Size = new System.Drawing.Size(152, 16);
			this.rdbNoValue.TabIndex = 0;
			this.rdbNoValue.Tag = "reportparameter.hintkind:NOHINT";
			this.rdbNoValue.Text = "Nessun valore predefinito";
			// 
			// txtDefValue
			// 
			this.txtDefValue.Location = new System.Drawing.Point(8, 152);
			this.txtDefValue.Name = "txtDefValue";
			this.txtDefValue.Size = new System.Drawing.Size(152, 20);
			this.txtDefValue.TabIndex = 26;
			this.txtDefValue.Tag = "reportparameter.hint";
			this.txtDefValue.Text = "";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.ckbFlagNoSelection);
			this.groupBox2.Controls.Add(this.label12);
			this.groupBox2.Controls.Add(this.cmbComboCodeField);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.cmbComboDescField);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.cmbComboTable);
			this.groupBox2.Controls.Add(this.ckbFlagCombo);
			this.groupBox2.Location = new System.Drawing.Point(184, 176);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(304, 184);
			this.groupBox2.TabIndex = 25;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Combo box";
			// 
			// ckbFlagNoSelection
			// 
			this.ckbFlagNoSelection.Location = new System.Drawing.Point(8, 160);
			this.ckbFlagNoSelection.Name = "ckbFlagNoSelection";
			this.ckbFlagNoSelection.Size = new System.Drawing.Size(288, 16);
			this.ckbFlagNoSelection.TabIndex = 29;
			this.ckbFlagNoSelection.Tag = "reportparameter.noselectionforall:S:N";
			this.ckbFlagNoSelection.Text = "Usa % per nessuna selezione";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(8, 72);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(288, 16);
			this.label12.TabIndex = 23;
			this.label12.Text = "Codice:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cmbComboCodeField
			// 
			this.cmbComboCodeField.DataSource = this.DS.columntypes;
			this.cmbComboCodeField.DisplayMember = "field";
			this.cmbComboCodeField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbComboCodeField.Location = new System.Drawing.Point(8, 95);
			this.cmbComboCodeField.Name = "cmbComboCodeField";
			this.cmbComboCodeField.Size = new System.Drawing.Size(288, 21);
			this.cmbComboCodeField.TabIndex = 22;
			this.cmbComboCodeField.Tag = "reportparameter.valuemember";
			this.cmbComboCodeField.ValueMember = "field";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(16, 119);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(280, 16);
			this.label11.TabIndex = 21;
			this.label11.Text = "Nome campo descrizione:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cmbComboDescField
			// 
			this.cmbComboDescField.DataSource = this.DS.columntypescombodescfield;
			this.cmbComboDescField.DisplayMember = "field";
			this.cmbComboDescField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbComboDescField.Location = new System.Drawing.Point(8, 135);
			this.cmbComboDescField.Name = "cmbComboDescField";
			this.cmbComboDescField.Size = new System.Drawing.Size(288, 21);
			this.cmbComboDescField.TabIndex = 20;
			this.cmbComboDescField.Tag = "reportparameter.displaymember";
			this.cmbComboDescField.ValueMember = "field";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(8, 32);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(288, 16);
			this.label10.TabIndex = 19;
			this.label10.Text = "Tabella:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cmbComboTable
			// 
			this.cmbComboTable.DataSource = this.DS.customobject;
			this.cmbComboTable.DisplayMember = "objectname";
			this.cmbComboTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbComboTable.Location = new System.Drawing.Point(8, 48);
			this.cmbComboTable.Name = "cmbComboTable";
			this.cmbComboTable.Size = new System.Drawing.Size(288, 21);
			this.cmbComboTable.TabIndex = 18;
			this.cmbComboTable.Tag = "reportparameter.datasource";
			this.cmbComboTable.ValueMember = "objectname";
			// 
			// ckbFlagCombo
			// 
			this.ckbFlagCombo.Location = new System.Drawing.Point(8, 16);
			this.ckbFlagCombo.Name = "ckbFlagCombo";
			this.ckbFlagCombo.Size = new System.Drawing.Size(288, 16);
			this.ckbFlagCombo.TabIndex = 28;
			this.ckbFlagCombo.Tag = "reportparameter.iscombobox:S:N";
			this.ckbFlagCombo.Text = "Utilizza combobox";
			this.ckbFlagCombo.CheckedChanged += new System.EventHandler(this.ckbFlagCombo_CheckedChanged);
			// 
			// txtNumber
			// 
			this.txtNumber.Location = new System.Drawing.Point(80, 56);
			this.txtNumber.Name = "txtNumber";
			this.txtNumber.Size = new System.Drawing.Size(48, 20);
			this.txtNumber.TabIndex = 27;
			this.txtNumber.Tag = "reportparameter.number";
			this.txtNumber.Text = "";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(424, 112);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(248, 56);
			this.textBox1.TabIndex = 29;
			this.textBox1.Tag = "reportparameter.help2";
			this.textBox1.Text = "";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(352, 112);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(64, 24);
			this.label13.TabIndex = 28;
			this.label13.Text = "Guida Windows:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// grpAbilitaCustom
			// 
			this.grpAbilitaCustom.Controls.Add(this.grpRadio);
			this.grpAbilitaCustom.Controls.Add(this.grpCustom);
			this.grpAbilitaCustom.Controls.Add(this.rdoCustom);
			this.grpAbilitaCustom.Controls.Add(this.grpCostant);
			this.grpAbilitaCustom.Controls.Add(this.rdoCheck);
			this.grpAbilitaCustom.Controls.Add(this.rdoRadio);
			this.grpAbilitaCustom.Controls.Add(this.rdoCostant);
			this.grpAbilitaCustom.Controls.Add(this.chkAbilitaCustom);
			this.grpAbilitaCustom.Controls.Add(this.grpCheck);
			this.grpAbilitaCustom.Location = new System.Drawing.Point(8, 368);
			this.grpAbilitaCustom.Name = "grpAbilitaCustom";
			this.grpAbilitaCustom.Size = new System.Drawing.Size(480, 232);
			this.grpAbilitaCustom.TabIndex = 31;
			this.grpAbilitaCustom.TabStop = false;
			this.grpAbilitaCustom.Text = "Controllo personalizzato";
			// 
			// grpRadio
			// 
			this.grpRadio.Controls.Add(this.btnRadio);
			this.grpRadio.Controls.Add(this.txtRadio);
			this.grpRadio.Location = new System.Drawing.Point(128, 120);
			this.grpRadio.Name = "grpRadio";
			this.grpRadio.Size = new System.Drawing.Size(344, 48);
			this.grpRadio.TabIndex = 9;
			this.grpRadio.TabStop = false;
			// 
			// btnRadio
			// 
			this.btnRadio.Location = new System.Drawing.Point(312, 13);
			this.btnRadio.Name = "btnRadio";
			this.btnRadio.Size = new System.Drawing.Size(24, 23);
			this.btnRadio.TabIndex = 2;
			this.btnRadio.Text = "...";
			this.btnRadio.Click += new System.EventHandler(this.btnRadio_Click);
			// 
			// txtRadio
			// 
			this.txtRadio.Location = new System.Drawing.Point(8, 16);
			this.txtRadio.Name = "txtRadio";
			this.txtRadio.ReadOnly = true;
			this.txtRadio.Size = new System.Drawing.Size(304, 20);
			this.txtRadio.TabIndex = 1;
			this.txtRadio.Text = "";
			// 
			// grpCustom
			// 
			this.grpCustom.Controls.Add(this.cboCustom);
			this.grpCustom.Location = new System.Drawing.Point(128, 168);
			this.grpCustom.Name = "grpCustom";
			this.grpCustom.Size = new System.Drawing.Size(344, 48);
			this.grpCustom.TabIndex = 8;
			this.grpCustom.TabStop = false;
			// 
			// cboCustom
			// 
			this.cboCustom.DataSource = this.DS.customselection;
			this.cboCustom.DisplayMember = "selectionname";
			this.cboCustom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCustom.Location = new System.Drawing.Point(8, 16);
			this.cboCustom.Name = "cboCustom";
			this.cboCustom.Size = new System.Drawing.Size(328, 21);
			this.cboCustom.TabIndex = 0;
			this.cboCustom.ValueMember = "selectioncode";
			// 
			// rdoCustom
			// 
			this.rdoCustom.Location = new System.Drawing.Point(24, 184);
			this.rdoCustom.Name = "rdoCustom";
			this.rdoCustom.Size = new System.Drawing.Size(80, 24);
			this.rdoCustom.TabIndex = 7;
			this.rdoCustom.Text = "Gestito";
			this.rdoCustom.CheckedChanged += new System.EventHandler(this.rdoCustom_CheckedChanged);
			// 
			// grpCostant
			// 
			this.grpCostant.Controls.Add(this.chkHidden);
			this.grpCostant.Location = new System.Drawing.Point(128, 32);
			this.grpCostant.Name = "grpCostant";
			this.grpCostant.Size = new System.Drawing.Size(344, 40);
			this.grpCostant.TabIndex = 4;
			this.grpCostant.TabStop = false;
			// 
			// chkHidden
			// 
			this.chkHidden.Location = new System.Drawing.Point(8, 16);
			this.chkHidden.Name = "chkHidden";
			this.chkHidden.Size = new System.Drawing.Size(216, 16);
			this.chkHidden.TabIndex = 0;
			this.chkHidden.Text = "Parametro non visibile";
			// 
			// rdoCheck
			// 
			this.rdoCheck.Location = new System.Drawing.Point(24, 88);
			this.rdoCheck.Name = "rdoCheck";
			this.rdoCheck.TabIndex = 3;
			this.rdoCheck.Text = "Check box";
			this.rdoCheck.CheckedChanged += new System.EventHandler(this.rdoCheck_CheckedChanged);
			// 
			// rdoRadio
			// 
			this.rdoRadio.Location = new System.Drawing.Point(24, 136);
			this.rdoRadio.Name = "rdoRadio";
			this.rdoRadio.TabIndex = 2;
			this.rdoRadio.Text = "Radio button";
			this.rdoRadio.CheckedChanged += new System.EventHandler(this.rdoRadio_CheckedChanged);
			// 
			// rdoCostant
			// 
			this.rdoCostant.Location = new System.Drawing.Point(24, 48);
			this.rdoCostant.Name = "rdoCostant";
			this.rdoCostant.Size = new System.Drawing.Size(104, 16);
			this.rdoCostant.TabIndex = 1;
			this.rdoCostant.Text = "Costante";
			this.rdoCostant.CheckedChanged += new System.EventHandler(this.rdoCostant_CheckedChanged);
			// 
			// chkAbilitaCustom
			// 
			this.chkAbilitaCustom.Location = new System.Drawing.Point(8, 16);
			this.chkAbilitaCustom.Name = "chkAbilitaCustom";
			this.chkAbilitaCustom.Size = new System.Drawing.Size(200, 24);
			this.chkAbilitaCustom.TabIndex = 0;
			this.chkAbilitaCustom.Text = "Utilizza controllo personalizzato";
			this.chkAbilitaCustom.CheckedChanged += new System.EventHandler(this.chkAbilitaCustom_CheckedChanged);
			// 
			// grpCheck
			// 
			this.grpCheck.Controls.Add(this.btnCheck);
			this.grpCheck.Controls.Add(this.txtCheck);
			this.grpCheck.Location = new System.Drawing.Point(128, 72);
			this.grpCheck.Name = "grpCheck";
			this.grpCheck.Size = new System.Drawing.Size(344, 48);
			this.grpCheck.TabIndex = 5;
			this.grpCheck.TabStop = false;
			// 
			// btnCheck
			// 
			this.btnCheck.Location = new System.Drawing.Point(312, 16);
			this.btnCheck.Name = "btnCheck";
			this.btnCheck.Size = new System.Drawing.Size(24, 23);
			this.btnCheck.TabIndex = 1;
			this.btnCheck.Text = "...";
			this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
			// 
			// txtCheck
			// 
			this.txtCheck.Location = new System.Drawing.Point(8, 16);
			this.txtCheck.Name = "txtCheck";
			this.txtCheck.ReadOnly = true;
			this.txtCheck.Size = new System.Drawing.Size(304, 20);
			this.txtCheck.TabIndex = 0;
			this.txtCheck.Text = "";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(424, 32);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(120, 20);
			this.textBox2.TabIndex = 32;
			this.textBox2.Tag = "reportparameter.tag";
			this.textBox2.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(552, 40);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(120, 16);
			this.label5.TabIndex = 33;
			this.label5.Text = "usare year per gli anni";
			// 
			// Frm_reportparameter_single
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnAnnulla;
			this.ClientSize = new System.Drawing.Size(680, 605);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.txtNumber);
			this.Controls.Add(this.txtHelp);
			this.Controls.Add(this.txtFilter);
			this.Controls.Add(this.txtDescrizione);
			this.Controls.Add(this.txtNomePar);
			this.Controls.Add(this.grpAbilitaCustom);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.cmbTipo);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.MaximizeBox = false;
			this.Name = "Frm_reportparameter_single";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmreportparametersingle";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.grpAbilitaCustom.ResumeLayout(false);
			this.grpRadio.ResumeLayout(false);
			this.grpCustom.ResumeLayout(false);
			this.grpCostant.ResumeLayout(false);
			this.grpCheck.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

	    private DataAccess conn;
		public void MetaData_AfterLink() {
			Meta=MetaData.GetMetaData(this);
			GetData.SetStaticFilter(DS.customobject, "isreal='S'");
			GetData.CacheTable(DS.customselection,null,null,true);

			FillTipoTmpTable();
		    conn = Meta.Conn;
		}

	    public void MetaData_AfterActivation() {
	        foreach (DataRow r in DS.customselection.Rows) {
	            r["selectionname"] = conn.compile(r["selectionname"]);
	        }
            DS.customselection.AcceptChanges();
	    }


		void FillTipoTmpTable() {
			DS.tmp_tipo.Rows.Add(new object[]{"DateTime", "Data"});
			DS.tmp_tipo.Rows.Add(new object[]{"String", "Stringa"});
			DS.tmp_tipo.Rows.Add(new object[]{"Byte", "Byte"});
            DS.tmp_tipo.Rows.Add(new object[] { "Int16", "SmallInt" });
            DS.tmp_tipo.Rows.Add(new object[] { "Int32", "Intero" });
            DS.tmp_tipo.Rows.Add(new object[] { "Double", "Float" });
			DS.tmp_tipo.Rows.Add(new object[]{"Decimal", "Decimal"});
			PostData.MarkAsTemporaryTable(DS.tmp_tipo, false);
			DS.tmp_tipo.AcceptChanges();
		}

		public void AbilitaDisabilitaRadioBtnAltro() {
			if (rdbAltro.Checked)
				txtDefValue.ReadOnly=false;
			else
				txtDefValue.ReadOnly=true;
		}

		public void MetaData_AfterFill() {
			AbilitaDisabilitaControlliCombo();
			AbilitaDisabilitaRadioBtnAltro();
			CheckControlliCustom();
			
			//riempie i combo senza tag
			DataRow R = HelpForm.GetLastSelected(DS.reportparameter);
			cmbTipo.SelectedValue=R["systype"];
		}
	
		public void MetaData_AfterGetFormData() {
			DataRow CurrentRow = DS.reportparameter.Rows[0];
			if (cmbTipo.SelectedValue!=null)
				CurrentRow["systype"]=cmbTipo.SelectedValue;
			else 
				CurrentRow["systype"]=DBNull.Value;


			//Build del controllo custom
			if (chkAbilitaCustom.Checked) 
				BuildCustomField(CurrentRow);
			else 
				SetCustomValue(CurrentRow, DBNull.Value);
		}

		private void BuildCustomField(DataRow R) {
			if (rdoCostant.Checked) {	
				string valore=chkHidden.Checked?"hidden":"visible";
				SetCustomValue(R, "costant."+valore);
				return;
			}
			if (rdoCheck.Checked && txtCheck.Text.Trim()!="") {
				SetCustomValue(R, "check."+txtCheck.Text.Trim());
				return;
			}
			if (rdoRadio.Checked && txtRadio.Text.Trim()!="") {
				SetCustomValue(R, "radio."+txtRadio.Text.Trim());
				return;
			}
			if (rdoCustom.Checked && cboCustom.SelectedValue.ToString()!="") {
				SetCustomValue(R, "custom."+cboCustom.SelectedValue.ToString());
				return;
			}
		}

		private void SetCustomValue(DataRow R, object valore) {
			R["selectioncode"]=valore;
		}

		private void CheckControlliCustom() {
			DataRow R = DS.reportparameter.Rows[0];
			string selectioncode=R["selectioncode"].ToString();
			chkAbilitaCustom.Checked=(selectioncode!="");
			AbilitaDisabilitaControlliCustom(chkAbilitaCustom.Checked);
			ValorizzaControlloCustom(selectioncode);
		}

		private void ValorizzaControlloCustom(string tag) {
			if (tag=="") return;
			int dotpos=tag.IndexOf(".");
			string tipo=tag.Substring(0, dotpos);
			string valore = HelpForm.GetLastField(tag,1);
			switch(tipo.ToLower()) {
				case "costant":
					rdoCostant.Checked=true;
					chkHidden.Checked=(valore=="hidden"?true:false);
					break;
				case "check":
					rdoCheck.Checked=true;
					txtCheck.Text=valore;
					break;
				case "radio":
					rdoRadio.Checked=true;
					txtRadio.Text=valore;
					break;
				case "custom":
					rdoCustom.Checked=true;
					HelpForm.SetComboBoxValue(cboCustom,valore);
					break;
			}
		}

		private void AbilitaDisabilitaControlliCustom(bool enable) {
			foreach (Control ctrl in grpAbilitaCustom.Controls) {
				if (ctrl.GetType()==typeof(CheckBox) && ctrl.Name=="chkAbilitaCustom") continue;
				if (ctrl.GetType()==typeof(Label)) continue;
				if (enable) {
					//quando il parametro è true abilito solo i radioButton
					if (enable && ctrl.Name.StartsWith("rdo"))
						ctrl.Enabled=true;
					else
						ctrl.Enabled=false;
				}
				else
					ctrl.Enabled=false;
			}
		}

		private void AbilitaDisabilitaControlliCombo() {
			if (ckbFlagCombo.CheckState==CheckState.Unchecked) {
				cmbComboTable.Enabled=false;
				cmbComboCodeField.Enabled=false;
				cmbComboDescField.Enabled=false;
				ckbFlagNoSelection.Enabled=false;
			}
			else {
				cmbComboTable.Enabled=true;
				cmbComboCodeField.Enabled=true;
				cmbComboDescField.Enabled=true;
				ckbFlagNoSelection.Enabled=true;
			}
		}

		private void ckbFlagCombo_CheckedChanged(object sender, System.EventArgs e) {
			if (!Meta.DrawStateIsDone) return;
			//Meta.GetFormData(true);
			//DS.reportparameter.Rows[0]["datasource"]=DBNull.Value;
			//DS.reportparameter.Rows[0]["valuemember"]=DBNull.Value;
			//DS.reportparameter.Rows[0]["displaymember"]=DBNull.Value;
			//DS.reportparameter.Rows[0]["noselectionforall"]="N";
			AbilitaDisabilitaControlliCombo();
			//Meta.FreshForm();
		}

		private void rdbAltro_CheckedChanged(object sender, System.EventArgs e) {
			if (!Meta.DrawStateIsDone) return;
			Meta.GetFormData(true);
			DS.reportparameter.Rows[0]["hint"]=DBNull.Value;
			AbilitaDisabilitaRadioBtnAltro();
			Meta.FreshForm();
		}

		private void rdoCostant_CheckedChanged(object sender, System.EventArgs e) {
			grpCostant.Enabled=true;
			grpCheck.Enabled=false;
			grpRadio.Enabled=false;
			grpCustom.Enabled=false;
		}

		private void rdoCheck_CheckedChanged(object sender, System.EventArgs e) {
			grpCostant.Enabled=false;
			grpCheck.Enabled=true;
			grpRadio.Enabled=false;
			grpCustom.Enabled=false;
		}

		private void rdoRadio_CheckedChanged(object sender, System.EventArgs e) {
			grpCostant.Enabled=false;
			grpCheck.Enabled=false;
			grpRadio.Enabled=true;
			grpCustom.Enabled=false;
		}

		private void rdoCustom_CheckedChanged(object sender, System.EventArgs e) {
			grpCostant.Enabled=false;
			grpCheck.Enabled=false;
			grpRadio.Enabled=false;
			grpCustom.Enabled=true;
		}

		private void chkAbilitaCustom_CheckedChanged(object sender, System.EventArgs e) {
			AbilitaDisabilitaControlliCustom(chkAbilitaCustom.Checked);
		}

		private void btnCheck_Click(object sender, System.EventArgs e) {
			frmCheck F = new frmCheck(txtCheck.Text);
			if (F.ShowDialog()!=DialogResult.OK) return;
			txtCheck.Text=F.GetValue;
		}

		private void btnRadio_Click(object sender, System.EventArgs e) {
			frmRadio F = new frmRadio(txtRadio.Text);
			if (F.ShowDialog()!=DialogResult.OK) return;
			txtRadio.Text=F.GetValue;
		}
	}
}
