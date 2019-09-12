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

namespace exportfunctionparam_single//expstoredprocedureparam//
{
	/// <summary>
	/// Summary description for frmexpstoredprocedureparam.
	/// </summary>
	public class Frm_exportfunctionparam_single : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rdbAltro;
		private System.Windows.Forms.RadioButton rdbEsercCorr;
		private System.Windows.Forms.RadioButton rdbDataCont;
		private System.Windows.Forms.RadioButton rdbUltimoGMese;
		private System.Windows.Forms.RadioButton rdbPrimoGMese;
		private System.Windows.Forms.RadioButton rdbUltimoGAnno;
		private System.Windows.Forms.RadioButton rdbPrimoGAnno;
		private System.Windows.Forms.RadioButton rdbNoValue;
		private System.Windows.Forms.TextBox txtDefValue;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox ckbFlagNoSelection;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.ComboBox cmbComboCodeField;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ComboBox cmbComboDescField;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox cmbComboTable;
		private System.Windows.Forms.CheckBox ckbFlagCombo;
        private System.Windows.Forms.TextBox txtNumber;
		private System.Windows.Forms.TextBox txtHelp;
		private System.Windows.Forms.TextBox txtFilter;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cmbTipo;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtNomePar;
		private System.Windows.Forms.Label label2;
		MetaData Meta;
		public /*Rana:expstoredprocedureparam.*/vistaForm DS;
        private Label label7;
        private TextBox textBox1;
        private Label label13;
        private GroupBox grpAbilitaCustom;
        private GroupBox grpRadio;
        private Button btnRadio;
        private TextBox txtRadio;
        private GroupBox grpCustom;
        private ComboBox cboCustom;
        private RadioButton rdoCustom;
        private GroupBox grpCostant;
        private CheckBox chkHidden;
        private RadioButton rdoCheck;
        private RadioButton rdoRadio;
        private RadioButton rdoCostant;
        private CheckBox chkAbilitaCustom;
        private GroupBox grpCheck;
        private Button btnCheck;
        private TextBox txtCheck;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_exportfunctionparam_single()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			DataAccess.SetTableForReading(DS.columntypescombodescfield, "columntypes");

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ckbFlagNoSelection = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbComboCodeField = new System.Windows.Forms.ComboBox();
            this.DS = new exportfunctionparam_single.vistaForm();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbComboDescField = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbComboTable = new System.Windows.Forms.ComboBox();
            this.ckbFlagCombo = new System.Windows.Forms.CheckBox();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.txtHelp = new System.Windows.Forms.TextBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNomePar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
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
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.grpAbilitaCustom.SuspendLayout();
            this.grpRadio.SuspendLayout();
            this.grpCustom.SuspendLayout();
            this.grpCostant.SuspendLayout();
            this.grpCheck.SuspendLayout();
            this.SuspendLayout();
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
            this.groupBox1.Location = new System.Drawing.Point(12, 174);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(168, 192);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Valore predefinito";
            // 
            // rdbAltro
            // 
            this.rdbAltro.Location = new System.Drawing.Point(8, 128);
            this.rdbAltro.Name = "rdbAltro";
            this.rdbAltro.Size = new System.Drawing.Size(152, 16);
            this.rdbAltro.TabIndex = 7;
            this.rdbAltro.Tag = "exportfunctionparam.hintkind:STRING";
            this.rdbAltro.Text = "Altro";
            this.rdbAltro.CheckedChanged += new System.EventHandler(this.rdbAltro_CheckedChanged);
            // 
            // rdbEsercCorr
            // 
            this.rdbEsercCorr.Location = new System.Drawing.Point(8, 112);
            this.rdbEsercCorr.Name = "rdbEsercCorr";
            this.rdbEsercCorr.Size = new System.Drawing.Size(152, 16);
            this.rdbEsercCorr.TabIndex = 6;
            this.rdbEsercCorr.Tag = "exportfunctionparam.hintkind:ACCOUNTYEAR";
            this.rdbEsercCorr.Text = "Esercizio corrente";
            // 
            // rdbDataCont
            // 
            this.rdbDataCont.Location = new System.Drawing.Point(8, 96);
            this.rdbDataCont.Name = "rdbDataCont";
            this.rdbDataCont.Size = new System.Drawing.Size(152, 16);
            this.rdbDataCont.TabIndex = 5;
            this.rdbDataCont.Tag = "exportfunctionparam.hintkind:ACCOUNTDATE";
            this.rdbDataCont.Text = "Data contabile";
            // 
            // rdbUltimoGMese
            // 
            this.rdbUltimoGMese.Location = new System.Drawing.Point(8, 80);
            this.rdbUltimoGMese.Name = "rdbUltimoGMese";
            this.rdbUltimoGMese.Size = new System.Drawing.Size(152, 16);
            this.rdbUltimoGMese.TabIndex = 4;
            this.rdbUltimoGMese.Tag = "exportfunctionparam.LASTDAY/CURRM";
            this.rdbUltimoGMese.Text = "Ultimo giorno del mese";
            // 
            // rdbPrimoGMese
            // 
            this.rdbPrimoGMese.Location = new System.Drawing.Point(8, 48);
            this.rdbPrimoGMese.Name = "rdbPrimoGMese";
            this.rdbPrimoGMese.Size = new System.Drawing.Size(152, 16);
            this.rdbPrimoGMese.TabIndex = 2;
            this.rdbPrimoGMese.Tag = "exportfunctionparam.hintkind:1/CURRM";
            this.rdbPrimoGMese.Text = "Primo giorno del mese";
            // 
            // rdbUltimoGAnno
            // 
            this.rdbUltimoGAnno.Location = new System.Drawing.Point(8, 64);
            this.rdbUltimoGAnno.Name = "rdbUltimoGAnno";
            this.rdbUltimoGAnno.Size = new System.Drawing.Size(152, 16);
            this.rdbUltimoGAnno.TabIndex = 3;
            this.rdbUltimoGAnno.Tag = "exportfunctionparam.hintkind:31/12";
            this.rdbUltimoGAnno.Text = "Ultimo giorno dell\'anno";
            // 
            // rdbPrimoGAnno
            // 
            this.rdbPrimoGAnno.Location = new System.Drawing.Point(8, 32);
            this.rdbPrimoGAnno.Name = "rdbPrimoGAnno";
            this.rdbPrimoGAnno.Size = new System.Drawing.Size(152, 16);
            this.rdbPrimoGAnno.TabIndex = 1;
            this.rdbPrimoGAnno.Tag = "exportfunctionparam.hintkind:1/1";
            this.rdbPrimoGAnno.Text = "Primo giorno dell\'anno";
            // 
            // rdbNoValue
            // 
            this.rdbNoValue.Location = new System.Drawing.Point(8, 16);
            this.rdbNoValue.Name = "rdbNoValue";
            this.rdbNoValue.Size = new System.Drawing.Size(152, 16);
            this.rdbNoValue.TabIndex = 0;
            this.rdbNoValue.Tag = "exportfunctionparam.hintkind:NOHINT";
            this.rdbNoValue.Text = "Nessun valore predefinito";
            // 
            // txtDefValue
            // 
            this.txtDefValue.Location = new System.Drawing.Point(8, 160);
            this.txtDefValue.Name = "txtDefValue";
            this.txtDefValue.Size = new System.Drawing.Size(152, 20);
            this.txtDefValue.TabIndex = 26;
            this.txtDefValue.Tag = "exportfunctionparam.hint";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(8, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 24);
            this.label9.TabIndex = 44;
            this.label9.Text = "Guida:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.groupBox2.Location = new System.Drawing.Point(186, 174);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(304, 192);
            this.groupBox2.TabIndex = 47;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Casella combinata";
            // 
            // ckbFlagNoSelection
            // 
            this.ckbFlagNoSelection.Location = new System.Drawing.Point(8, 162);
            this.ckbFlagNoSelection.Name = "ckbFlagNoSelection";
            this.ckbFlagNoSelection.Size = new System.Drawing.Size(288, 22);
            this.ckbFlagNoSelection.TabIndex = 29;
            this.ckbFlagNoSelection.Tag = "exportfunctionparam.noselectionforall:S:N";
            this.ckbFlagNoSelection.Text = "Usa % per nessuna selezione";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(8, 79);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(288, 16);
            this.label12.TabIndex = 23;
            this.label12.Text = "Nome campo codice:";
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
            this.cmbComboCodeField.Tag = "exportfunctionparam.valuemember";
            this.cmbComboCodeField.ValueMember = "field";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(8, 119);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(288, 16);
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
            this.cmbComboDescField.Tag = "exportfunctionparam.displaymember";
            this.cmbComboDescField.ValueMember = "field";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(8, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(288, 16);
            this.label10.TabIndex = 19;
            this.label10.Text = "Nome tabella:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbComboTable
            // 
            this.cmbComboTable.DataSource = this.DS.customobject;
            this.cmbComboTable.DisplayMember = "objectname";
            this.cmbComboTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComboTable.Location = new System.Drawing.Point(8, 55);
            this.cmbComboTable.Name = "cmbComboTable";
            this.cmbComboTable.Size = new System.Drawing.Size(288, 21);
            this.cmbComboTable.TabIndex = 18;
            this.cmbComboTable.Tag = "exportfunctionparam.datasource";
            this.cmbComboTable.ValueMember = "objectname";
            // 
            // ckbFlagCombo
            // 
            this.ckbFlagCombo.Location = new System.Drawing.Point(8, 16);
            this.ckbFlagCombo.Name = "ckbFlagCombo";
            this.ckbFlagCombo.Size = new System.Drawing.Size(288, 16);
            this.ckbFlagCombo.TabIndex = 28;
            this.ckbFlagCombo.Tag = "exportfunctionparam.iscombobox:S:N";
            this.ckbFlagCombo.Text = "Utilizza casella combinata";
            this.ckbFlagCombo.CheckedChanged += new System.EventHandler(this.ckbFlagCombo_CheckedChanged);
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(80, 56);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(48, 20);
            this.txtNumber.TabIndex = 49;
            this.txtNumber.Tag = "exportfunctionparam.number";
            // 
            // txtHelp
            // 
            this.txtHelp.Location = new System.Drawing.Point(80, 112);
            this.txtHelp.Multiline = true;
            this.txtHelp.Name = "txtHelp";
            this.txtHelp.Size = new System.Drawing.Size(592, 56);
            this.txtHelp.TabIndex = 45;
            this.txtHelp.Tag = "exportfunctionparam.help";
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(80, 80);
            this.txtFilter.Multiline = true;
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(592, 24);
            this.txtFilter.TabIndex = 43;
            this.txtFilter.Tag = "exportfunctionparam.filter";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 24);
            this.label8.TabIndex = 42;
            this.label8.Text = "Filtro:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(597, 572);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 41;
            this.btnAnnulla.Text = "Annulla";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(597, 540);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 40;
            this.btnOK.Tag = "mainsave";
            this.btnOK.Text = "OK";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(24, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 24);
            this.label6.TabIndex = 37;
            this.label6.Text = "Numero:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(368, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 24);
            this.label4.TabIndex = 33;
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
            this.cmbTipo.TabIndex = 32;
            this.cmbTipo.Tag = "";
            this.cmbTipo.ValueMember = "codice";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(80, 32);
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(280, 20);
            this.txtDescrizione.TabIndex = 31;
            this.txtDescrizione.Tag = "exportfunctionparam.description";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 24);
            this.label3.TabIndex = 30;
            this.label3.Text = "Descrizione:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNomePar
            // 
            this.txtNomePar.Location = new System.Drawing.Point(80, 8);
            this.txtNomePar.Name = "txtNomePar";
            this.txtNomePar.Size = new System.Drawing.Size(280, 20);
            this.txtNomePar.TabIndex = 29;
            this.txtNomePar.Tag = "exportfunctionparam.paramname";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 24);
            this.label2.TabIndex = 28;
            this.label2.Text = "Nome:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(368, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 24);
            this.label7.TabIndex = 50;
            this.label7.Text = "Tag:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(424, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 20);
            this.textBox1.TabIndex = 51;
            this.textBox1.Tag = "exportfunctionparam.tag";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(552, 40);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(120, 16);
            this.label13.TabIndex = 52;
            this.label13.Text = "usare year per gli anni";
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
            this.grpAbilitaCustom.Location = new System.Drawing.Point(12, 372);
            this.grpAbilitaCustom.Name = "grpAbilitaCustom";
            this.grpAbilitaCustom.Size = new System.Drawing.Size(480, 232);
            this.grpAbilitaCustom.TabIndex = 53;
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
            this.rdoCheck.Size = new System.Drawing.Size(104, 24);
            this.rdoCheck.TabIndex = 3;
            this.rdoCheck.Text = "Check box";
            this.rdoCheck.CheckedChanged += new System.EventHandler(this.rdoCheck_CheckedChanged);
            // 
            // rdoRadio
            // 
            this.rdoRadio.Location = new System.Drawing.Point(24, 136);
            this.rdoRadio.Name = "rdoRadio";
            this.rdoRadio.Size = new System.Drawing.Size(104, 24);
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
            // 
            // Frm_exportfunctionparam_single
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(680, 605);
            this.Controls.Add(this.grpAbilitaCustom);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.txtHelp);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.txtDescrizione);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNomePar);
            this.Controls.Add(this.label2);
            this.Name = "Frm_exportfunctionparam_single";
            this.Text = "frmexpstoredprocedureparam";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.grpAbilitaCustom.ResumeLayout(false);
            this.grpRadio.ResumeLayout(false);
            this.grpRadio.PerformLayout();
            this.grpCustom.ResumeLayout(false);
            this.grpCostant.ResumeLayout(false);
            this.grpCheck.ResumeLayout(false);
            this.grpCheck.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public void MetaData_AfterLink() {
			Meta=MetaData.GetMetaData(this);
			GetData.SetStaticFilter(DS.customobject, "isreal='S'");
            GetData.CacheTable(DS.customselection, null, null, true);

			FillTipoTmpTable();
		}

		void FillTipoTmpTable() {
            DS.tmp_tipo.Rows.Add(new object[] { "DateTime", "Data" });
            DS.tmp_tipo.Rows.Add(new object[] { "String", "Stringa" });
            DS.tmp_tipo.Rows.Add(new object[] { "Byte", "Byte" });
            DS.tmp_tipo.Rows.Add(new object[] { "Int16", "SmallInt" });
            DS.tmp_tipo.Rows.Add(new object[] { "Int32", "Intero" });
            DS.tmp_tipo.Rows.Add(new object[] { "Double", "Float" });
            DS.tmp_tipo.Rows.Add(new object[] { "Decimal", "Decimal" });
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
			DataRow R = HelpForm.GetLastSelected(DS.exportfunctionparam);
			cmbTipo.SelectedValue=R["systype"];
		}
	
		public void MetaData_AfterGetFormData() {
			DataRow CurrentRow = DS.exportfunctionparam.Rows[0];
            if (cmbTipo.SelectedValue != null)
                CurrentRow["systype"] = cmbTipo.SelectedValue;
            else
                CurrentRow["systype"] = DBNull.Value;

            //Build del controllo custom
            if (chkAbilitaCustom.Checked)
                BuildCustomField(CurrentRow);
            else
                SetCustomValue(CurrentRow, DBNull.Value);
		}

        private void BuildCustomField(DataRow R) {
            if (rdoCostant.Checked) {
                string valore = chkHidden.Checked ? "hidden" : "visible";
                SetCustomValue(R, "costant." + valore);
                return;
            }
            if (rdoCheck.Checked && txtCheck.Text.Trim() != "") {
                SetCustomValue(R, "check." + txtCheck.Text.Trim());
                return;
            }
            if (rdoRadio.Checked && txtRadio.Text.Trim() != "") {
                SetCustomValue(R, "radio." + txtRadio.Text.Trim());
                return;
            }
            if (rdoCustom.Checked && cboCustom.SelectedValue.ToString() != "") {
                SetCustomValue(R, "custom." + cboCustom.SelectedValue.ToString());
                return;
            }
        }

        private void SetCustomValue(DataRow R, object valore) {
            R["selectioncode"] = valore;
        }

        private void CheckControlliCustom() {
            DataRow R = DS.exportfunctionparam.Rows[0];
            string selectioncode = R["selectioncode"].ToString();
            chkAbilitaCustom.Checked = (selectioncode != "");
            AbilitaDisabilitaControlliCustom(chkAbilitaCustom.Checked);
            ValorizzaControlloCustom(selectioncode);
        }

        private void ValorizzaControlloCustom(string tag) {
            if (tag == "") return;
            int dotpos = tag.IndexOf(".");
            string tipo = tag.Substring(0, dotpos);
            string valore = HelpForm.GetLastField(tag, 1);
            switch (tipo.ToLower()) {
                case "costant":
                    rdoCostant.Checked = true;
                    chkHidden.Checked = (valore == "hidden" ? true : false);
                    break;
                case "check":
                    rdoCheck.Checked = true;
                    txtCheck.Text = valore;
                    break;
                case "radio":
                    rdoRadio.Checked = true;
                    txtRadio.Text = valore;
                    break;
                case "custom":
                    rdoCustom.Checked = true;
                    HelpForm.SetComboBoxValue(cboCustom, valore);
                    break;
            }
        }

        private void AbilitaDisabilitaControlliCustom(bool enable) {
            foreach (Control ctrl in grpAbilitaCustom.Controls) {
                if (ctrl.GetType() == typeof(CheckBox) && ctrl.Name == "chkAbilitaCustom") continue;
                if (ctrl.GetType() == typeof(Label)) continue;
                if (enable) {
                    //quando il parametro è true abilito solo i radioButton
                    if (enable && ctrl.Name.StartsWith("rdo"))
                        ctrl.Enabled = true;
                    else
                        ctrl.Enabled = false;
                }
                else
                    ctrl.Enabled = false;
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
			Meta.GetFormData(true);
            //DS.exportfunctionparam.Rows[0]["datasource"]=DBNull.Value;
            //DS.exportfunctionparam.Rows[0]["valuemember"]=DBNull.Value;
            //DS.exportfunctionparam.Rows[0]["displaymember"]=DBNull.Value;
            //DS.exportfunctionparam.Rows[0]["noselectionforall"]="N";
			AbilitaDisabilitaControlliCombo();
            //Meta.FreshForm();

		}

		private void rdbAltro_CheckedChanged(object sender, System.EventArgs e) {
			if (!Meta.DrawStateIsDone) return;
			Meta.GetFormData(true);
			DS.exportfunctionparam.Rows[0]["hint"]=DBNull.Value;
			AbilitaDisabilitaRadioBtnAltro();
			Meta.FreshForm();
		}

        private void rdoCostant_CheckedChanged(object sender, System.EventArgs e) {
            grpCostant.Enabled = true;
            grpCheck.Enabled = false;
            grpRadio.Enabled = false;
            grpCustom.Enabled = false;
        }

        private void rdoCheck_CheckedChanged(object sender, System.EventArgs e) {
            grpCostant.Enabled = false;
            grpCheck.Enabled = true;
            grpRadio.Enabled = false;
            grpCustom.Enabled = false;
        }

        private void rdoRadio_CheckedChanged(object sender, System.EventArgs e) {
            grpCostant.Enabled = false;
            grpCheck.Enabled = false;
            grpRadio.Enabled = true;
            grpCustom.Enabled = false;
        }

        private void rdoCustom_CheckedChanged(object sender, System.EventArgs e) {
            grpCostant.Enabled = false;
            grpCheck.Enabled = false;
            grpRadio.Enabled = false;
            grpCustom.Enabled = true;
        }

        private void chkAbilitaCustom_CheckedChanged(object sender, System.EventArgs e) {
            AbilitaDisabilitaControlliCustom(chkAbilitaCustom.Checked);
        }

        private void btnCheck_Click(object sender, System.EventArgs e) {
            frmCheck F = new frmCheck(txtCheck.Text);
            if (F.ShowDialog() != DialogResult.OK) return;
            txtCheck.Text = F.GetValue;
        }

        private void btnRadio_Click(object sender, System.EventArgs e) {
            frmRadio F = new frmRadio(txtRadio.Text);
            if (F.ShowDialog() != DialogResult.OK) return;
            txtRadio.Text = F.GetValue;
        }
	}
}
