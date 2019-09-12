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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Data;
using metadatalibrary;
using System.Text;

namespace generaSQL//GeneraSQL//
{
	/// <summary>
	/// Summary description for frmScriptByTable.
	/// </summary>
	public class frmScriptByTable : System.Windows.Forms.Form
	{
        CQueryHelper QHC;
        QueryHelper QHS;
		private System.Windows.Forms.Button btnGenera;
		private System.Windows.Forms.TextBox txtOutputFile;
		private System.Windows.Forms.Label label2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.RadioButton radioView;
		private System.Windows.Forms.RadioButton radioTable;
		private System.Windows.Forms.ComboBox cboTable;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox chkDati;
		private System.Windows.Forms.CheckBox chkSoloDati;
		private System.Windows.Forms.CheckBox chkCRLF;
		private System.Windows.Forms.TextBox txtFiltro;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox grpObject;
		private System.Windows.Forms.GroupBox grpDati;
		private System.Windows.Forms.GroupBox groupBoxTipoAggiornamento;
		private System.Windows.Forms.RadioButton radioButtonInsertAndUpdate;
		private System.Windows.Forms.RadioButton radioButtonOnlyInsert;
		private System.Windows.Forms.RadioButton radioButtonOnlyUpdate;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtColonne;
		private System.Windows.Forms.RadioButton radioButBulkInsert;
		private System.Windows.Forms.Button btnCambiaChiave;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Button btnScriptSp;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private GroupBox groupBox1;
        private Button btnTaxRate;
        private Button btnClassificazioni;
        private Button btnInvTree;
        private Button btnAbiCab;
        private Button btnPrestazioni;
        private Button btnTraduceClass;
        private Button btnCurrency;
        private Button btnBilancio;
        private Button btnAliqRegionali;
        private Button btnClassificazioniBilancio;
        private Button btnAliquotaRitenuta;
        private Button btnAudit;
        private TextBox txtSelMultiplaTabelle;
        private Button btnSelMultipla;
        private Button btnScegliFile;
        private CheckBox chkAppend;
        private Button btnDizionarioDati;
        private Button btnAnalizzaStruttura;
        private DataAccess Conn;

		public frmScriptByTable(DataAccess Conn)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.Conn = Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
			BindCombo();
			chkDati_CheckedChanged(null,null);
            MetaData.SetColor(this, true);
            addEvents(cboTable);
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
            this.btnGenera = new System.Windows.Forms.Button();
            this.txtOutputFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpObject = new System.Windows.Forms.GroupBox();
            this.txtSelMultiplaTabelle = new System.Windows.Forms.TextBox();
            this.btnSelMultipla = new System.Windows.Forms.Button();
            this.radioView = new System.Windows.Forms.RadioButton();
            this.radioTable = new System.Windows.Forms.RadioButton();
            this.cboTable = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpDati = new System.Windows.Forms.GroupBox();
            this.txtColonne = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxTipoAggiornamento = new System.Windows.Forms.GroupBox();
            this.radioButBulkInsert = new System.Windows.Forms.RadioButton();
            this.radioButtonOnlyUpdate = new System.Windows.Forms.RadioButton();
            this.radioButtonOnlyInsert = new System.Windows.Forms.RadioButton();
            this.radioButtonInsertAndUpdate = new System.Windows.Forms.RadioButton();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkCRLF = new System.Windows.Forms.CheckBox();
            this.chkSoloDati = new System.Windows.Forms.CheckBox();
            this.chkDati = new System.Windows.Forms.CheckBox();
            this.btnCambiaChiave = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnScriptSp = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDizionarioDati = new System.Windows.Forms.Button();
            this.btnAudit = new System.Windows.Forms.Button();
            this.btnAliquotaRitenuta = new System.Windows.Forms.Button();
            this.btnClassificazioniBilancio = new System.Windows.Forms.Button();
            this.btnAliqRegionali = new System.Windows.Forms.Button();
            this.btnBilancio = new System.Windows.Forms.Button();
            this.btnCurrency = new System.Windows.Forms.Button();
            this.btnTraduceClass = new System.Windows.Forms.Button();
            this.btnPrestazioni = new System.Windows.Forms.Button();
            this.btnAbiCab = new System.Windows.Forms.Button();
            this.btnInvTree = new System.Windows.Forms.Button();
            this.btnClassificazioni = new System.Windows.Forms.Button();
            this.btnTaxRate = new System.Windows.Forms.Button();
            this.btnScegliFile = new System.Windows.Forms.Button();
            this.chkAppend = new System.Windows.Forms.CheckBox();
            this.btnAnalizzaStruttura = new System.Windows.Forms.Button();
            this.grpObject.SuspendLayout();
            this.grpDati.SuspendLayout();
            this.groupBoxTipoAggiornamento.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGenera
            // 
            this.btnGenera.Location = new System.Drawing.Point(187, 385);
            this.btnGenera.Name = "btnGenera";
            this.btnGenera.Size = new System.Drawing.Size(75, 23);
            this.btnGenera.TabIndex = 38;
            this.btnGenera.Text = "Genera";
            this.btnGenera.Click += new System.EventHandler(this.btnGenera_Click);
            // 
            // txtOutputFile
            // 
            this.txtOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputFile.Location = new System.Drawing.Point(137, 359);
            this.txtOutputFile.Name = "txtOutputFile";
            this.txtOutputFile.Size = new System.Drawing.Size(751, 20);
            this.txtOutputFile.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 335);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 16);
            this.label2.TabIndex = 26;
            this.label2.Text = "Inserisci il nome del file che verrà generato";
            // 
            // grpObject
            // 
            this.grpObject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpObject.Controls.Add(this.btnAnalizzaStruttura);
            this.grpObject.Controls.Add(this.txtSelMultiplaTabelle);
            this.grpObject.Controls.Add(this.btnSelMultipla);
            this.grpObject.Controls.Add(this.radioView);
            this.grpObject.Controls.Add(this.radioTable);
            this.grpObject.Controls.Add(this.cboTable);
            this.grpObject.Controls.Add(this.label1);
            this.grpObject.Location = new System.Drawing.Point(16, 8);
            this.grpObject.Name = "grpObject";
            this.grpObject.Size = new System.Drawing.Size(875, 96);
            this.grpObject.TabIndex = 34;
            this.grpObject.TabStop = false;
            this.grpObject.Text = "Tipo di oggetto";
            // 
            // txtSelMultiplaTabelle
            // 
            this.txtSelMultiplaTabelle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSelMultiplaTabelle.Location = new System.Drawing.Point(219, 60);
            this.txtSelMultiplaTabelle.Name = "txtSelMultiplaTabelle";
            this.txtSelMultiplaTabelle.Size = new System.Drawing.Size(617, 20);
            this.txtSelMultiplaTabelle.TabIndex = 39;
            // 
            // btnSelMultipla
            // 
            this.btnSelMultipla.Location = new System.Drawing.Point(105, 57);
            this.btnSelMultipla.Name = "btnSelMultipla";
            this.btnSelMultipla.Size = new System.Drawing.Size(111, 23);
            this.btnSelMultipla.TabIndex = 38;
            this.btnSelMultipla.Text = "Selezione multipla";
            this.btnSelMultipla.UseVisualStyleBackColor = true;
            this.btnSelMultipla.Click += new System.EventHandler(this.btnSelMultipla_Click);
            // 
            // radioView
            // 
            this.radioView.Location = new System.Drawing.Point(24, 56);
            this.radioView.Name = "radioView";
            this.radioView.Size = new System.Drawing.Size(104, 24);
            this.radioView.TabIndex = 37;
            this.radioView.Text = "Viste";
            this.radioView.CheckedChanged += new System.EventHandler(this.radioView_CheckedChanged);
            // 
            // radioTable
            // 
            this.radioTable.Checked = true;
            this.radioTable.Location = new System.Drawing.Point(24, 24);
            this.radioTable.Name = "radioTable";
            this.radioTable.Size = new System.Drawing.Size(75, 24);
            this.radioTable.TabIndex = 36;
            this.radioTable.TabStop = true;
            this.radioTable.Text = "Tabelle";
            this.radioTable.CheckedChanged += new System.EventHandler(this.radioTable_CheckedChanged);
            // 
            // cboTable
            // 
            this.cboTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTable.ItemHeight = 13;
            this.cboTable.Location = new System.Drawing.Point(105, 29);
            this.cboTable.MaxDropDownItems = 40;
            this.cboTable.Name = "cboTable";
            this.cboTable.Size = new System.Drawing.Size(393, 21);
            this.cboTable.TabIndex = 35;
            this.cboTable.SelectedValueChanged += new System.EventHandler(this.cboTable_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(102, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 16);
            this.label1.TabIndex = 34;
            this.label1.Text = "Seleziona la tabella / vista";
            // 
            // grpDati
            // 
            this.grpDati.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDati.Controls.Add(this.txtColonne);
            this.grpDati.Controls.Add(this.label4);
            this.grpDati.Controls.Add(this.groupBoxTipoAggiornamento);
            this.grpDati.Controls.Add(this.txtFiltro);
            this.grpDati.Controls.Add(this.label3);
            this.grpDati.Controls.Add(this.chkCRLF);
            this.grpDati.Controls.Add(this.chkSoloDati);
            this.grpDati.Controls.Add(this.chkDati);
            this.grpDati.Location = new System.Drawing.Point(16, 112);
            this.grpDati.Name = "grpDati";
            this.grpDati.Size = new System.Drawing.Size(875, 216);
            this.grpDati.TabIndex = 35;
            this.grpDati.TabStop = false;
            this.grpDati.Text = "Generazione Dati";
            // 
            // txtColonne
            // 
            this.txtColonne.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtColonne.Location = new System.Drawing.Point(16, 176);
            this.txtColonne.Name = "txtColonne";
            this.txtColonne.ReadOnly = true;
            this.txtColonne.Size = new System.Drawing.Size(851, 20);
            this.txtColonne.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 16);
            this.label4.TabIndex = 39;
            this.label4.Text = "Colonne da selezionare";
            // 
            // groupBoxTipoAggiornamento
            // 
            this.groupBoxTipoAggiornamento.Controls.Add(this.radioButBulkInsert);
            this.groupBoxTipoAggiornamento.Controls.Add(this.radioButtonOnlyUpdate);
            this.groupBoxTipoAggiornamento.Controls.Add(this.radioButtonOnlyInsert);
            this.groupBoxTipoAggiornamento.Controls.Add(this.radioButtonInsertAndUpdate);
            this.groupBoxTipoAggiornamento.Location = new System.Drawing.Point(192, 8);
            this.groupBoxTipoAggiornamento.Name = "groupBoxTipoAggiornamento";
            this.groupBoxTipoAggiornamento.Size = new System.Drawing.Size(216, 104);
            this.groupBoxTipoAggiornamento.TabIndex = 38;
            this.groupBoxTipoAggiornamento.TabStop = false;
            this.groupBoxTipoAggiornamento.Text = "Tipo modifica";
            // 
            // radioButBulkInsert
            // 
            this.radioButBulkInsert.Location = new System.Drawing.Point(8, 64);
            this.radioButBulkInsert.Name = "radioButBulkInsert";
            this.radioButBulkInsert.Size = new System.Drawing.Size(200, 24);
            this.radioButBulkInsert.TabIndex = 3;
            this.radioButBulkInsert.Text = "Bulk Insert (solo su tabelle vuote)";
            // 
            // radioButtonOnlyUpdate
            // 
            this.radioButtonOnlyUpdate.Location = new System.Drawing.Point(8, 48);
            this.radioButtonOnlyUpdate.Name = "radioButtonOnlyUpdate";
            this.radioButtonOnlyUpdate.Size = new System.Drawing.Size(200, 16);
            this.radioButtonOnlyUpdate.TabIndex = 2;
            this.radioButtonOnlyUpdate.Text = "Solo Aggiornamento righe esistenti";
            // 
            // radioButtonOnlyInsert
            // 
            this.radioButtonOnlyInsert.Location = new System.Drawing.Point(8, 32);
            this.radioButtonOnlyInsert.Name = "radioButtonOnlyInsert";
            this.radioButtonOnlyInsert.Size = new System.Drawing.Size(200, 16);
            this.radioButtonOnlyInsert.TabIndex = 1;
            this.radioButtonOnlyInsert.Text = "Solo Inserimento nuove righe";
            // 
            // radioButtonInsertAndUpdate
            // 
            this.radioButtonInsertAndUpdate.Checked = true;
            this.radioButtonInsertAndUpdate.Location = new System.Drawing.Point(8, 16);
            this.radioButtonInsertAndUpdate.Name = "radioButtonInsertAndUpdate";
            this.radioButtonInsertAndUpdate.Size = new System.Drawing.Size(176, 16);
            this.radioButtonInsertAndUpdate.TabIndex = 0;
            this.radioButtonInsertAndUpdate.TabStop = true;
            this.radioButtonInsertAndUpdate.Text = "Inserimento e Aggiornamento";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFiltro.Location = new System.Drawing.Point(16, 120);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(851, 20);
            this.txtFiltro.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 37;
            this.label3.Text = "Filtro dati";
            // 
            // chkCRLF
            // 
            this.chkCRLF.Location = new System.Drawing.Point(16, 64);
            this.chkCRLF.Name = "chkCRLF";
            this.chkCRLF.Size = new System.Drawing.Size(192, 24);
            this.chkCRLF.TabIndex = 35;
            this.chkCRLF.Text = "Converti CR LF";
            // 
            // chkSoloDati
            // 
            this.chkSoloDati.Location = new System.Drawing.Point(16, 40);
            this.chkSoloDati.Name = "chkSoloDati";
            this.chkSoloDati.Size = new System.Drawing.Size(192, 24);
            this.chkSoloDati.TabIndex = 34;
            this.chkSoloDati.Text = "Solo dati";
            this.chkSoloDati.CheckedChanged += new System.EventHandler(this.chkSoloDati_CheckedChanged);
            this.chkSoloDati.EnabledChanged += new System.EventHandler(this.chkSoloDati_CheckedChanged);
            // 
            // chkDati
            // 
            this.chkDati.Location = new System.Drawing.Point(16, 16);
            this.chkDati.Name = "chkDati";
            this.chkDati.Size = new System.Drawing.Size(96, 24);
            this.chkDati.TabIndex = 33;
            this.chkDati.Text = "Abilita";
            this.chkDati.CheckedChanged += new System.EventHandler(this.chkDati_CheckedChanged);
            // 
            // btnCambiaChiave
            // 
            this.btnCambiaChiave.Location = new System.Drawing.Point(436, 383);
            this.btnCambiaChiave.Name = "btnCambiaChiave";
            this.btnCambiaChiave.Size = new System.Drawing.Size(88, 23);
            this.btnCambiaChiave.TabIndex = 39;
            this.btnCambiaChiave.Text = "cambia chiave";
            this.btnCambiaChiave.Visible = false;
            this.btnCambiaChiave.Click += new System.EventHandler(this.btnCambiaChiave_Click);
            // 
            // btnScriptSp
            // 
            this.btnScriptSp.Location = new System.Drawing.Point(35, 385);
            this.btnScriptSp.Name = "btnScriptSp";
            this.btnScriptSp.Size = new System.Drawing.Size(75, 23);
            this.btnScriptSp.TabIndex = 37;
            this.btnScriptSp.Text = "script sp";
            this.btnScriptSp.Click += new System.EventHandler(this.btnScriptSp_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDizionarioDati);
            this.groupBox1.Controls.Add(this.btnAudit);
            this.groupBox1.Controls.Add(this.btnAliquotaRitenuta);
            this.groupBox1.Controls.Add(this.btnClassificazioniBilancio);
            this.groupBox1.Controls.Add(this.btnAliqRegionali);
            this.groupBox1.Controls.Add(this.btnBilancio);
            this.groupBox1.Controls.Add(this.btnCurrency);
            this.groupBox1.Controls.Add(this.btnTraduceClass);
            this.groupBox1.Controls.Add(this.btnPrestazioni);
            this.groupBox1.Controls.Add(this.btnAbiCab);
            this.groupBox1.Controls.Add(this.btnInvTree);
            this.groupBox1.Controls.Add(this.btnClassificazioni);
            this.groupBox1.Controls.Add(this.btnTaxRate);
            this.groupBox1.Location = new System.Drawing.Point(3, 414);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(532, 118);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Script per tabelle specifiche";
            // 
            // btnDizionarioDati
            // 
            this.btnDizionarioDati.Location = new System.Drawing.Point(415, 83);
            this.btnDizionarioDati.Name = "btnDizionarioDati";
            this.btnDizionarioDati.Size = new System.Drawing.Size(95, 23);
            this.btnDizionarioDati.TabIndex = 12;
            this.btnDizionarioDati.Text = "Dizionario dati";
            this.btnDizionarioDati.UseVisualStyleBackColor = true;
            this.btnDizionarioDati.Click += new System.EventHandler(this.btnDizionarioDati_Click);
            // 
            // btnAudit
            // 
            this.btnAudit.Location = new System.Drawing.Point(265, 83);
            this.btnAudit.Name = "btnAudit";
            this.btnAudit.Size = new System.Drawing.Size(95, 23);
            this.btnAudit.TabIndex = 11;
            this.btnAudit.Text = "Audit";
            this.btnAudit.UseVisualStyleBackColor = true;
            this.btnAudit.Click += new System.EventHandler(this.btnAudit_Click);
            // 
            // btnAliquotaRitenuta
            // 
            this.btnAliquotaRitenuta.Location = new System.Drawing.Point(281, 19);
            this.btnAliquotaRitenuta.Name = "btnAliquotaRitenuta";
            this.btnAliquotaRitenuta.Size = new System.Drawing.Size(132, 23);
            this.btnAliquotaRitenuta.TabIndex = 10;
            this.btnAliquotaRitenuta.Text = "Aliquote Ritenuta";
            this.btnAliquotaRitenuta.UseVisualStyleBackColor = true;
            this.btnAliquotaRitenuta.Click += new System.EventHandler(this.btnAliquotaRitenuta_Click);
            // 
            // btnClassificazioniBilancio
            // 
            this.btnClassificazioniBilancio.Location = new System.Drawing.Point(10, 83);
            this.btnClassificazioniBilancio.Name = "btnClassificazioniBilancio";
            this.btnClassificazioniBilancio.Size = new System.Drawing.Size(140, 23);
            this.btnClassificazioniBilancio.TabIndex = 9;
            this.btnClassificazioniBilancio.Text = "Classificazioni Bilancio";
            this.btnClassificazioniBilancio.UseVisualStyleBackColor = true;
            this.btnClassificazioniBilancio.Click += new System.EventHandler(this.btnClassificazioniBilancio_Click);
            // 
            // btnAliqRegionali
            // 
            this.btnAliqRegionali.Location = new System.Drawing.Point(160, 19);
            this.btnAliqRegionali.Name = "btnAliqRegionali";
            this.btnAliqRegionali.Size = new System.Drawing.Size(115, 23);
            this.btnAliqRegionali.TabIndex = 8;
            this.btnAliqRegionali.Text = "Aliquote regionali";
            this.btnAliqRegionali.UseVisualStyleBackColor = true;
            this.btnAliqRegionali.Click += new System.EventHandler(this.btnAliqRegionali_Click);
            // 
            // btnBilancio
            // 
            this.btnBilancio.Location = new System.Drawing.Point(415, 19);
            this.btnBilancio.Name = "btnBilancio";
            this.btnBilancio.Size = new System.Drawing.Size(95, 23);
            this.btnBilancio.TabIndex = 7;
            this.btnBilancio.Text = "Bilancio";
            this.btnBilancio.UseVisualStyleBackColor = true;
            this.btnBilancio.Click += new System.EventHandler(this.btnBilancio_Click);
            // 
            // btnCurrency
            // 
            this.btnCurrency.Location = new System.Drawing.Point(312, 54);
            this.btnCurrency.Name = "btnCurrency";
            this.btnCurrency.Size = new System.Drawing.Size(95, 23);
            this.btnCurrency.TabIndex = 6;
            this.btnCurrency.Text = "Currency";
            this.btnCurrency.UseVisualStyleBackColor = true;
            this.btnCurrency.Click += new System.EventHandler(this.btnCurrencyClick);
            // 
            // btnTraduceClass
            // 
            this.btnTraduceClass.Location = new System.Drawing.Point(205, 54);
            this.btnTraduceClass.Name = "btnTraduceClass";
            this.btnTraduceClass.Size = new System.Drawing.Size(94, 23);
            this.btnTraduceClass.TabIndex = 5;
            this.btnTraduceClass.Text = "Traduce Class.";
            this.btnTraduceClass.UseVisualStyleBackColor = true;
            this.btnTraduceClass.Click += new System.EventHandler(this.btnTraduceClass_Click);
            // 
            // btnPrestazioni
            // 
            this.btnPrestazioni.Location = new System.Drawing.Point(106, 54);
            this.btnPrestazioni.Name = "btnPrestazioni";
            this.btnPrestazioni.Size = new System.Drawing.Size(92, 23);
            this.btnPrestazioni.TabIndex = 4;
            this.btnPrestazioni.Text = "Prestazioni";
            this.btnPrestazioni.UseVisualStyleBackColor = true;
            this.btnPrestazioni.Click += new System.EventHandler(this.btnPrestazioni_Click);
            // 
            // btnAbiCab
            // 
            this.btnAbiCab.Location = new System.Drawing.Point(10, 54);
            this.btnAbiCab.Name = "btnAbiCab";
            this.btnAbiCab.Size = new System.Drawing.Size(81, 23);
            this.btnAbiCab.TabIndex = 3;
            this.btnAbiCab.Text = "ABI/CAB";
            this.btnAbiCab.UseVisualStyleBackColor = true;
            this.btnAbiCab.Click += new System.EventHandler(this.btnAbiCab_Click);
            // 
            // btnInvTree
            // 
            this.btnInvTree.Location = new System.Drawing.Point(164, 83);
            this.btnInvTree.Name = "btnInvTree";
            this.btnInvTree.Size = new System.Drawing.Size(95, 23);
            this.btnInvTree.TabIndex = 2;
            this.btnInvTree.Text = "InventoryTree";
            this.btnInvTree.UseVisualStyleBackColor = true;
            this.btnInvTree.Click += new System.EventHandler(this.btnInvTree_Click);
            // 
            // btnClassificazioni
            // 
            this.btnClassificazioni.Location = new System.Drawing.Point(415, 54);
            this.btnClassificazioni.Name = "btnClassificazioni";
            this.btnClassificazioni.Size = new System.Drawing.Size(95, 23);
            this.btnClassificazioni.TabIndex = 1;
            this.btnClassificazioni.Text = "Classificazioni";
            this.btnClassificazioni.UseVisualStyleBackColor = true;
            this.btnClassificazioni.Click += new System.EventHandler(this.btnClassificazioni_Click);
            // 
            // btnTaxRate
            // 
            this.btnTaxRate.Location = new System.Drawing.Point(9, 19);
            this.btnTaxRate.Name = "btnTaxRate";
            this.btnTaxRate.Size = new System.Drawing.Size(132, 23);
            this.btnTaxRate.TabIndex = 0;
            this.btnTaxRate.Text = "Aliquote comunali";
            this.btnTaxRate.UseVisualStyleBackColor = true;
            this.btnTaxRate.Click += new System.EventHandler(this.btnTaxRate_Click);
            // 
            // btnScegliFile
            // 
            this.btnScegliFile.Location = new System.Drawing.Point(16, 356);
            this.btnScegliFile.Name = "btnScegliFile";
            this.btnScegliFile.Size = new System.Drawing.Size(103, 23);
            this.btnScegliFile.TabIndex = 41;
            this.btnScegliFile.Text = "Scegli file";
            this.btnScegliFile.UseVisualStyleBackColor = true;
            this.btnScegliFile.Click += new System.EventHandler(this.buttonbtnScegliFile_Click);
            // 
            // chkAppend
            // 
            this.chkAppend.AutoSize = true;
            this.chkAppend.Location = new System.Drawing.Point(284, 389);
            this.chkAppend.Name = "chkAppend";
            this.chkAppend.Size = new System.Drawing.Size(106, 17);
            this.chkAppend.TabIndex = 42;
            this.chkAppend.Text = "Modalità Append";
            this.chkAppend.UseVisualStyleBackColor = true;
            // 
            // btnAnalizzaStruttura
            // 
            this.btnAnalizzaStruttura.Location = new System.Drawing.Point(668, 27);
            this.btnAnalizzaStruttura.Name = "btnAnalizzaStruttura";
            this.btnAnalizzaStruttura.Size = new System.Drawing.Size(168, 23);
            this.btnAnalizzaStruttura.TabIndex = 40;
            this.btnAnalizzaStruttura.Text = "Analizza struttura";
            this.btnAnalizzaStruttura.UseVisualStyleBackColor = true;
            this.btnAnalizzaStruttura.Click += new System.EventHandler(this.btnAnalizzaStruttura_Click);
            // 
            // frmScriptByTable
            // 
            this.AcceptButton = this.btnGenera;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(905, 544);
            this.Controls.Add(this.chkAppend);
            this.Controls.Add(this.btnScegliFile);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnScriptSp);
            this.Controls.Add(this.btnCambiaChiave);
            this.Controls.Add(this.grpDati);
            this.Controls.Add(this.grpObject);
            this.Controls.Add(this.btnGenera);
            this.Controls.Add(this.txtOutputFile);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmScriptByTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generazione script SQL per singola tabella";
            this.grpObject.ResumeLayout(false);
            this.grpObject.PerformLayout();
            this.grpDati.ResumeLayout(false);
            this.grpDati.PerformLayout();
            this.groupBoxTipoAggiornamento.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void BindCombo() {
			string filter = CalcolaFiltro();
			DataTable t = Conn.RUN_SELECT("customobject","objectname","objectname ASC",filter, null, false);
            if (radioTable.Checked) {
                DataRow R;
                if (t.Select(QHC.CmpEq("objectname", "columntypes")).Length == 0) {
                    R = t.NewRow();
                    R["objectname"] = "columntypes";
                    t.Rows.Add(R);
                }
                if (t.Select(QHC.CmpEq("objectname", "customobject")).Length == 0) {
                    R = t.NewRow();
                    R["objectname"] = "customobject";
                    t.Rows.Add(R);
                }               
            }
            cboTable.DataSource = t;
			cboTable.DisplayMember = "objectname";
			cboTable.ValueMember = "objectname";
		}

		private string CalcolaFiltro() {
			if (radioTable.Checked)
				return "isreal = 'S'";
			else
				return "isreal = 'N'";
		}

		private bool Validazioni() {
			if (cboTable.Text.Trim() == "") {
				MessageBox.Show("Selezionare il nome della tabella / vista", "Attenzione",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			if (txtOutputFile.Text.Trim() == "") {
				MessageBox.Show("Inserire il nome del file che verrà generato", "Attenzione",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			if (File.Exists(txtOutputFile.Text.Trim())) {
				DialogResult res = MessageBox.Show("Il file esiste, sovrascriverlo?", "Attenzione",
					MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
				if (res != DialogResult.Yes) return false;
			}
		    if (cboTable.Text.ToLower() == "audit" && radioButtonOnlyInsert.Checked == false) {
		        MessageBox.Show("Non è ammesso creare degli script sulla tabella audit in update", "Errore");
                return false;
		    }
			return true;
		}

        private bool ValidazioniCustom() {
            if (txtOutputFile.Text.Trim() == "") {
                MessageBox.Show("Inserire il nome del file che verrà generato", "Attenzione",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (File.Exists(txtOutputFile.Text.Trim())) {
                DialogResult res = MessageBox.Show("Il file esiste, sovrascriverlo?", "Attenzione",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (res != DialogResult.Yes) return false;
            }
            return true;
        }

	    string []getTables() {
	        if (txtSelMultiplaTabelle.Text=="") return new string[] {cboTable.Text};
	        return txtSelMultiplaTabelle.Text.Split(',');
	    }
		private void btnGenera_Click(object sender, System.EventArgs e) {
			if (!Validazioni()) return;
			Cursor.Current = Cursors.WaitCursor;
			string filter = null;
			if (txtFiltro.Text.Trim() != "") filter = txtFiltro.Text.Trim();
            int nTables = getTables().Length;
            int ntabella = 0;
            Conn.Reset(true);
		    foreach (string tableNameDirty in getTables()) {
                ntabella++;
		        string tableName = tableNameDirty.Trim();
								
				try {
					this.Conn.CallSP("clear_table_info",
						new object[] { tableName });
				} catch {
					MessageBox.Show("Errore eseguendo clear_table_info su '" + tableName + "'");
				}
				dbstructure DBS = (dbstructure)this.Conn.GetStructure(tableName);
		        Conn.SaveStructure(DBS);
				dbanalyzer.ReadColumnTypes(DBS.columntypes, tableName, this.Conn);

				DataTable t = new DataTable(tableName);
                string columns = "*";
                if (chkSoloDati.Checked && chkSoloDati.Enabled && (txtColonne.Text.Trim() != "")) columns = txtColonne.Text;
                t = Conn.CreateTableByName(tableName, columns, true);
                if (chkDati.Checked) {
                    DataAccess.RUN_SELECT_INTO_TABLE(Conn, t, null, filter, null, true);
                    if (t.Rows.Count == 0) {
                        MessageBox.Show("Nessuna riga trovata. Filtro:" + filter +
                            " Ultimo errore:" + Conn.LastError);
                        if (chkSoloDati.Enabled && chkSoloDati.Checked) {
                            return;
                        }
                    }
                }
                Conn.AddExtendedProperty(t);
                DataSet DS = new DataSet();
                DS.Tables.Add(t);
				object kind = Conn.DO_READ_VALUE("customobject", QHS.CmpEq("objectname", tableName), "isreal");
				bool IsTable = kind.ToString().ToLower()=="s";
				UpdateType updateType = UpdateType.insertAndUpdate;
                if (radioButtonOnlyInsert.Checked) {
                    updateType = UpdateType.onlyInsert;
                }
                if (radioButtonOnlyUpdate.Checked) {
                    updateType = UpdateType.onlyUpdate;
                }
                if (radioButBulkInsert.Checked) {
                    updateType = UpdateType.bulkinsert;
                }

                DataGenerationType generationType = chkDati.Checked
                    ? (chkSoloDati.Checked ? DataGenerationType.onlyData : DataGenerationType.structureAndData)
                    : DataGenerationType.onlyStructure;


                GeneraSQL.GeneraStrutturaEDati(/*true, */Conn, DS, txtOutputFile.Text.Trim(), chkAppend.Checked|| 
                                        (ntabella>1),
                    updateType, generationType, IsTable/*, chkCRLF.Checked*/);
                

            }

            MessageBox.Show("Script generato con successo.");
			Cursor.Current = Cursors.Default;
		}

		private void chkDati_CheckedChanged(object sender, System.EventArgs e) {
			groupBoxTipoAggiornamento.Enabled = chkDati.Checked;
			txtFiltro.Enabled = chkDati.Checked;
			chkSoloDati.Enabled = chkDati.Checked;
			chkCRLF.Enabled = chkDati.Checked;
		}

		private void cboTable_SelectedValueChanged(object sender, System.EventArgs e) {
		    if (chkAppend.Checked) return;
			txtOutputFile.Text = cboTable.Text.ToLower() + ".sql";
		    if (cboTable.Text.ToLower() == "audit") {
                radioButtonOnlyInsert.Checked = true;
                radioButtonInsertAndUpdate.Checked = false;
                radioButtonOnlyUpdate.Checked = false;
            }
        }

		private void radioTable_CheckedChanged(object sender, System.EventArgs e) {
			Impostazioni();
		}

		private void radioView_CheckedChanged(object sender, System.EventArgs e) {
			Impostazioni();
		}

		private void Impostazioni() {
			BindCombo();
			grpDati.Enabled=(radioTable.Checked==true);
		}

		private void chkSoloDati_CheckedChanged(object sender, System.EventArgs e) {
			txtColonne.ReadOnly= !chkSoloDati.Checked;
		}

		private void btnCambiaChiave_Click(object sender, System.EventArgs e) {
            openFileDialog1.Title = "Scegli il file che contiene i nomi delle tabelle";
            openFileDialog1.ShowDialog(this);
            saveFileDialog1.Title = "Scegli il nome dello script da creare";
            saveFileDialog1.ShowDialog(this);
			StreamReader sr = new StreamReader(openFileDialog1.OpenFile(), Encoding.Default);
			StreamWriter sw = new StreamWriter(saveFileDialog1.OpenFile(), Encoding.Default);
			GeneraSQL.GeneraStrutturaCambiandoChiave(Conn, sr, sw);
			sr.Close();
			sw.Close();
		}

		private void btnScriptSp_Click(object sender, System.EventArgs e) {
			DialogResult dr = folderBrowserDialog1.ShowDialog(this);
			if (dr == DialogResult.OK) {
				GeneraSQL.scriptSp(Conn, txtFiltro.Text, folderBrowserDialog1.SelectedPath);
				string messaggio = "Gli script delle stored procedure ";
				if (txtFiltro.Text != "") {
					messaggio += "i cui nomi cominciano per "+txtFiltro.Text;
				}
				MessageBox.Show(this, messaggio+"\nsono stati creati nella cartella "+folderBrowserDialog1.SelectedPath);
			} else {
				MessageBox.Show(this, "Non è stata specificata la cartella di destinazione");
			}
		}

        private void btnTaxRate_Click(object sender, EventArgs e) {
            if (!ValidazioniCustom()) return;
            Cursor.Current = Cursors.WaitCursor;
            string filter = null;
            if (txtFiltro.Text.Trim() != "") filter = txtFiltro.Text.Trim();

            if (!GeneraSQL.generaTaxRateCity(Conn, txtOutputFile.Text.Trim(), filter)) {
                MessageBox.Show(this, "Errore di generazione dello Script");
            }
            else {
                MessageBox.Show(this, "Script generato con successo!");
            }

            Cursor.Current = Cursors.Default;
        }

        private void btnClassificazioni_Click(object sender, EventArgs e) {
            if (!ValidazioniCustom()) return;
            Cursor.Current = Cursors.WaitCursor;
            string filter = null;
            if (txtFiltro.Text.Trim() != "") filter = txtFiltro.Text.Trim();

            if (!GeneraSQL.generaSortingKind(Conn, txtOutputFile.Text.Trim(), filter)) {
                MessageBox.Show(this, "Errore di generazione dello Script");
            }
            else {
                MessageBox.Show(this, "Script generato con successo!");
            }

            Cursor.Current = Cursors.Default;
        }

        private void btnInvTree_Click(object sender, EventArgs e) {
            if (!ValidazioniCustom()) return;
            Cursor.Current = Cursors.WaitCursor;
            string filter = null;
            if (txtFiltro.Text.Trim() != "") filter = txtFiltro.Text.Trim();

            if (!GeneraSQL.generaInventorytree(Conn, txtOutputFile.Text.Trim(), filter)) {
                MessageBox.Show(this, "Errore di generazione dello Script");
            }
            else {
                MessageBox.Show(this, "Script generato con successo!");
            }

            Cursor.Current = Cursors.Default;

        }

        private void btnAbiCab_Click(object sender, EventArgs e) {
            if (!ValidazioniCustom()) return;
            Cursor.Current = Cursors.WaitCursor;
            string filter = null;
            if (txtFiltro.Text.Trim() != "") filter = txtFiltro.Text.Trim();

            if (!GeneraSQL.generaABICAB(Conn, txtOutputFile.Text.Trim(), filter)) {
                MessageBox.Show(this, "Errore di generazione dello Script");
            }
            else {
                MessageBox.Show(this, "Script generato con successo!");
            }

            Cursor.Current = Cursors.Default;
        }

        private void btnPrestazioni_Click(object sender, EventArgs e) {
            if (!ValidazioniCustom()) return;
            Cursor.Current = Cursors.WaitCursor;
            string filter = null;
            if (txtFiltro.Text.Trim() != "") filter = txtFiltro.Text.Trim();

            if (!GeneraSQL.generaService(Conn, txtOutputFile.Text.Trim(), filter)) {
                MessageBox.Show(this, "Errore di generazione dello Script");
            }
            else {
                MessageBox.Show(this, "Script generato con successo!");
            }

            Cursor.Current = Cursors.Default;
        }

        private void btnTraduceClass_Click(object sender, EventArgs e){
            if (!ValidazioniCustom()) return;
            Cursor.Current = Cursors.WaitCursor;
            string filter = null;
            if (txtFiltro.Text.Trim() != "") filter = txtFiltro.Text.Trim();

            if (!GeneraSQL.generaSortingTranslation(Conn, txtOutputFile.Text.Trim(), filter)){
                MessageBox.Show(this, "Errore di generazione dello Script");
            }
            else{
                MessageBox.Show(this, "Script generato con successo!");
            }

            Cursor.Current = Cursors.Default;


        }

        private void btnCurrencyClick(object sender, EventArgs e) {
            if (!ValidazioniCustom()) return;
            Cursor.Current = Cursors.WaitCursor;
            string filter = null;
            if (txtFiltro.Text.Trim() != "") filter = txtFiltro.Text.Trim();

            if (!GeneraSQL.generaCurrency(Conn, txtOutputFile.Text.Trim(), filter)) {
                MessageBox.Show(this, "Errore di generazione dello Script");
            }
            else {
                MessageBox.Show(this, "Script generato con successo!");
            }

            Cursor.Current = Cursors.Default;
        }

        private void btnBilancio_Click(object sender, EventArgs e) {
            if (!ValidazioniCustom()) return;
            Cursor.Current = Cursors.WaitCursor;
            string filter = null;
            if (txtFiltro.Text.Trim() != "") filter = txtFiltro.Text.Trim();

            if (!GeneraSQL.generaBilancio(Conn, txtOutputFile.Text.Trim())) {
                MessageBox.Show(this, "Errore di generazione dello Script");
            }
            else {
                MessageBox.Show(this, "Script generato con successo!");
            }

            Cursor.Current = Cursors.Default;
        }

        private void btnAliqRegionali_Click(object sender, EventArgs e) {
            
            if (!ValidazioniCustom()) return;
            Cursor.Current = Cursors.WaitCursor;
            string filter = null;
            if (txtFiltro.Text.Trim() != "") filter = txtFiltro.Text.Trim();

            if (!GeneraSQL.generaTaxRateRegion(Conn, txtOutputFile.Text.Trim(), filter)) {
                MessageBox.Show(this, "Errore di generazione dello Script");
            }
            else {
                MessageBox.Show(this, "Script generato con successo!");
            }

            Cursor.Current = Cursors.Default;
        }

        private void btnClassificazioniBilancio_Click(object sender, EventArgs e){
            if (!ValidazioniCustom()) return;
            Cursor.Current = Cursors.WaitCursor;
            string filter = null;
            if (txtFiltro.Text.Trim() != "") filter = txtFiltro.Text.Trim();

            if (!GeneraSQL.generaClassificazioniBilancio(Conn, txtOutputFile.Text.Trim(), filter)){
                MessageBox.Show(this, "Errore di generazione dello Script");
            }
            else{
                MessageBox.Show(this, "Script generato con successo!");
            }

            Cursor.Current = Cursors.Default;
        }

        private void btnAliquotaRitenuta_Click(object sender, EventArgs e){
            if (!ValidazioniCustom()) return;
            Cursor.Current = Cursors.WaitCursor;
            string filter = null;
            if (txtFiltro.Text.Trim() != "") filter = txtFiltro.Text.Trim();

            if (!GeneraSQL.generaTaxRateStartBracket(Conn, txtOutputFile.Text.Trim(), filter))
            {
                MessageBox.Show(this, "Errore di generazione dello Script");
            }
            else
            {
                MessageBox.Show(this, "Script generato con successo!");
            }

            Cursor.Current = Cursors.Default;
        }

        private void btnAudit_Click(object sender, EventArgs e) {
            if (!ValidazioniCustom()) return;
            Cursor.Current = Cursors.WaitCursor;
            string filter = QHS.CmpEq("idaudit", txtOutputFile.Text.ToLower().Replace(".sql",""));
            DataSet DS = new DataSet();
            
            DataTable t = Conn.CreateTableByName("audit", "*", true);
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, t, null, filter, null, true);
                if (t.Rows.Count == 0) {
                    MessageBox.Show("Nessuna riga trovata nella tabella audit. Filtro:" + filter +
                        " Ultimo errore:" + Conn.LastError);
                }
            DataAccess.AddExtendedProperty(Conn, t);
            DS.Tables.Add(t);            
            GeneraSQL.GeneraStrutturaEDati(/*true, */Conn, DS, txtOutputFile.Text.Trim(), false,
                UpdateType.onlyInsert, DataGenerationType.onlyData, true);

            DS = new DataSet();

            t = Conn.CreateTableByName("auditcheck", "*", true);
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, t, null, filter, null, true);
            if (t.Rows.Count == 0) {
                MessageBox.Show("Nessuna riga trovata nella tabella auditcheck. Filtro:" + filter +
                    " Ultimo errore:" + Conn.LastError);
            }
            DataAccess.AddExtendedProperty(Conn, t);
            DS.Tables.Add(t);
            GeneraSQL.GeneraStrutturaEDati(/*true, */Conn, DS, txtOutputFile.Text.Trim(), true,
                UpdateType.insertAndUpdate, DataGenerationType.onlyData, true);

            MessageBox.Show("Script generato con successo.");
            Cursor.Current = Cursors.Default;
        }

        private void btnSelMultipla_Click(object sender, EventArgs e) {
            FrmSelezioneTabelle f = new FrmSelezioneTabelle(Conn,radioView.Checked);
            if (f.ShowDialog(this) != DialogResult.OK) return;
            foreach (ListViewItem x in f.TableList.Items) {
                if (!x.Checked) continue;
                if (txtSelMultiplaTabelle.Text != "") txtSelMultiplaTabelle.Text += ",";
                txtSelMultiplaTabelle.Text += x.Text;
            }
        }

        private void buttonbtnScegliFile_Click(object sender, EventArgs e) {
            saveFileDialog1.Title = "Scegli il nome dello script da creare";
            saveFileDialog1.OverwritePrompt = true;
            if (saveFileDialog1.ShowDialog(this) != DialogResult.OK) return; ;
            txtOutputFile.Text = saveFileDialog1.FileName;

        }

        private void btnDizionarioDati_Click(object sender, EventArgs e) {
            string[] tableLU = new string[] { "tabledescr", "coldescr", "colbit", "colvalue",
                                "relation", "relationcol"};
            string filter = QHC.CmpNe("lu", "lu");
            foreach (string tableNameDirty in tableLU) {
                string tableName = tableNameDirty.Trim();
                DataTable t = new DataTable(tableName);
                t = Conn.CreateTableByName(tableName, "*", true);
                DataAccess.RUN_SELECT_INTO_TABLE(Conn, t, null, filter, null, true);
                if (t.Rows.Count == 0) {
                    continue;
                }
                DataAccess.AddExtendedProperty(Conn, t);
                DataSet DS = new DataSet();
                DS.Tables.Add(t);
                bool IsTable = true;
                UpdateType updateType = UpdateType.insertAndUpdate;

                DataGenerationType generationType = DataGenerationType.onlyData;

                GeneraSQL.GeneraStrutturaEDati(/*true, */Conn, DS, txtOutputFile.Text.Trim(), true,
                    updateType, generationType, IsTable/*, chkCRLF.Checked*/);

                MessageBox.Show(@"Script generato in "+ txtOutputFile.Text.Trim(), @"Avviso");
            }
        }

        private void btnAnalizzaStruttura_Click(object sender, EventArgs e) {
            Conn.Reset(true);
            Conn.GenerateCustomObjects();
            Conn.SaveStructure();
            Impostazioni();
        }

	    /// <summary>
	    /// Add internal events to manage combobox
	    /// </summary>
	    /// <param name="c"></param>
	    public void addEvents(ComboBox c) {

	        if (c.DropDownStyle != ComboBoxStyle.DropDown)
	            c.DropDownStyle = ComboBoxStyle.DropDown;
	        c.MaxDropDownItems = 25;

	        c.KeyDown += keyDown;
	        c.KeyPress += keyPress;
	    }

	    /// <summary>
        /// Evento generato ad ogni pressione di tasto tale che "IsInputKey() = true"; 
        /// pertanto anche "ESC", "INVIO" e "BACKSPACE" ma non,
        /// ad esempio, "SINISTRA", "DESTRA", "HOME" e "CANC" che devono essere gestiti
        /// dall'evento "KeyDown".
        /// Precondizione: nel ComboBox DEVE ESSERE DropDownStyle = DropDown
        /// </summary>
        /// <param name="sender">il ComboBox che si vuole gestire</param>
        /// <param name="e">l'evento</param>
        private void keyPress(object sender, KeyPressEventArgs e) {

            //Se è stato premuto ESC o INVIO lascio la gestione dell'evento a .NET
            if (e.KeyChar == 27 || e.KeyChar == 13) {
                return;
            }

            var acComboBox = (ComboBox)sender;

            var selectionStart = acComboBox.SelectionStart;
            var comboLen = acComboBox.Text.Length;
            var comboText = acComboBox.Text;

            if (selectionStart > comboLen) selectionStart = comboLen;
            if (selectionStart < 0) selectionStart = 0;

            //Se il tasto premuto è BACKSPACE, faccio cominciare la selezione un carattere prima
            //dell'inizio della selezione corrente
            if (e.KeyChar == 8) {
                var lenSel = comboLen - (selectionStart - 1);
                if (selectionStart > 0 && lenSel >= 0) {
                    acComboBox.Select(selectionStart - 1, lenSel);
                }
                else {
                    acComboBox.SelectAll();
                }
            }
            else {
                //Se è un qualunque altro carattere (quindi tale che IsInputKey()=true
                //e diverso anche da ESC, INVIO, BACK) allora lo gestisco io.

                //Cerco una riga del ComboBox che cominci per i primi "selectionStart" caratteri
                //della riga corrente concatenati col tasto premuto
                var ricerca = comboText.Substring(0, selectionStart) + e.KeyChar;

                var index = acComboBox.FindString(ricerca);

                if (index != -1) {
                    //Se tale riga esiste, allora la seleziono
                    if (acComboBox.SelectedIndex != index) {
                        acComboBox.DroppedDown = false;
                        acComboBox.SelectedIndex = index;
                        comboLen = acComboBox.Text.Length;

                    }
                    acComboBox.DroppedDown = true;
                    if (selectionStart < comboLen) {
                        //e faccio cominciare la selezione da selectionstart + 1
                        acComboBox.Select(selectionStart + 1, comboLen - (selectionStart + 1));
                    }
                }
                else {
                    //MarkEvent("Ricerca riuscita");
                    //Se invece tale riga non esiste, allora seleziono la riga attuale
                    //dal carattere in posizione selectionStart fino alla fine
                    acComboBox.DroppedDown = true;
                    acComboBox.Select(selectionStart, comboLen - selectionStart);
                }
            }
            //Forzo l'apertura della tendina per facilitare l'utente nella scelta
            e.Handled = true;
        }

        /// <summary>
        /// Evento generato prima di KeyPress. Lo uso per gestire la pressione dei tasti 
        /// "SINISTRA", "DESTRA", "HOME" e "CANC"
        /// che altrimenti non riuscirei ad intercettare con KeyPress.
        /// Precondizione: nel ComboBox DEVE ESSERE DropDownStyle = DropDown
        /// </summary>
        /// <param name="sender">il ComboBox da gestire</param>
        /// <param name="e">l'evento</param>
        private void keyDown(object sender, KeyEventArgs e) {
            var acComboBox = (ComboBox)sender;
            var selectionStart = acComboBox.SelectionStart;

            switch (e.KeyCode) {
                //Se è stato premuta la freccia "SINISTRA" faccio cominciare la selezione
                //un carattere prima rispetto alla selezione attuale
                case Keys.Left:
                    if (selectionStart > 0) {
                        acComboBox.Select(selectionStart - 1, acComboBox.Text.Length - (selectionStart - 1));
                    }
                    else {
                        acComboBox.SelectAll();
                    }
                    break;

                //Se è stato premuto il tasto "CANC" seleziono la riga vuota del combobox
                case Keys.Delete:
                    var index = acComboBox.FindString("");
                    if (index != -1) {
                        acComboBox.DroppedDown = false;
                        acComboBox.SelectedIndex = index;
                        acComboBox.DroppedDown = true;
                    }
                    acComboBox.SelectAll();
                    break;

                //Se è stato premuta la freccia "DESTRA" faccio cominciare la selezione
                //un carattere dopo rispetto alla selezione attuale
                case Keys.Right:
                    if (acComboBox.Text.Length > selectionStart) {
                        acComboBox.Select(selectionStart + 1, acComboBox.Text.Length - (selectionStart + 1));
                    }
                    break;

                //Se è stato premuto il tasto "HOME" seleziono tutta la riga attuale.
                case Keys.Home:
                    acComboBox.SelectAll();
                    break;

                default:
                    //Altrimenti lascio la gestione di questo evento a .NET
                    return;
            }
            e.Handled = true;
        }

    }
}