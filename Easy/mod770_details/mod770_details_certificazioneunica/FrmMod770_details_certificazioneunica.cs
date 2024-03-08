
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
using System.IO;
using System.Text;
using funzioni_configurazione;
using System.Xml;
using System.Collections;
using System.Globalization;
using System.Data.OleDb;

namespace mod770_details_certificazioneunica
{
	/// <summary>
	/// Summary description for Frmmod770_details_certificazioneunica.
	/// </summary>
	public class Frmmod770_details_certificazioneunica : MetaDataForm
	{
        NumberFormatInfo numberFormat = CultureInfo.GetCultureInfo(0x410).NumberFormat;
        DataTable tMod770;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.Button btnGenera770;
		private System.Windows.Forms.TextBox txtPercorso;
		private System.Windows.Forms.Button btnSalvaIn;
		public mod770_details_certificazioneunica.vistaForm DS;
		private MetaData Meta;
		private System.Windows.Forms.SaveFileDialog _saveFileDialog1;
		private ISaveFileDialog saveFileDialog1;
        private Button buttonRecordG;
        private Button buttonRecordH;
        private GroupBox groupBox1;
        private Label label1;
        private GroupBox groupBox2;
        private Button buttonLegendaG;
        private Button buttonLegendaH;
        private Button buttonPrestazioni;
        private GroupBox groupBox3;
        private Button buttonIncoerenze;
        private Button buttonGenera770recordH;
        private Button buttonProblemiH;
        private Button btnNonResidH;
        private Button btnNonResidG;
        private GroupBox groupBox4;
        private Button btnDatiB;
        private Button btnLegendaB;
        private Button btnDatiA;
        private Button btnLegendaA;
        private Button btnDatiDG;
        private Button btnDatiDH;
        private Button btnLegendaDG;
        private Button btnLegendaDH;
        private Button btnStampaH;
        private Button btnStampaG;
        private FolderBrowserDialog _folderBrowserDialog1;
        private IFolderBrowserDialog folderBrowserDialog1;
        private GroupBox groupBox5;
        private DataGrid dataGrid;
        private CheckBox chkConpaginavuota;
        private GroupBox groupBox6;
        private TextBox txtCF;
        private Label label2;
        private TextBox txtInputFile;
        private Button btnInputFile;
        private OpenFileDialog _MyOpenFile;
        private IOpenFileDialog MyOpenFile;
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frmmod770_details_certificazioneunica()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            MyOpenFile.FileName = "openFileDialog";
            MyOpenFile.Title = "Selezionare il file Excel da importare";
            saveFileDialog1.DefaultExt = "cur";
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmmod770_details_certificazioneunica));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnGenera770 = new System.Windows.Forms.Button();
            this.txtPercorso = new System.Windows.Forms.TextBox();
            this.btnSalvaIn = new System.Windows.Forms.Button();
            this._saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.buttonRecordG = new System.Windows.Forms.Button();
            this.buttonRecordH = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLegendaDG = new System.Windows.Forms.Button();
            this.btnDatiDG = new System.Windows.Forms.Button();
            this.buttonLegendaG = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLegendaDH = new System.Windows.Forms.Button();
            this.btnDatiDH = new System.Windows.Forms.Button();
            this.buttonLegendaH = new System.Windows.Forms.Button();
            this.buttonPrestazioni = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnNonResidH = new System.Windows.Forms.Button();
            this.btnNonResidG = new System.Windows.Forms.Button();
            this.buttonProblemiH = new System.Windows.Forms.Button();
            this.buttonIncoerenze = new System.Windows.Forms.Button();
            this.btnStampaH = new System.Windows.Forms.Button();
            this.btnStampaG = new System.Windows.Forms.Button();
            this.buttonGenera770recordH = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnDatiB = new System.Windows.Forms.Button();
            this.btnLegendaB = new System.Windows.Forms.Button();
            this.btnDatiA = new System.Windows.Forms.Button();
            this.btnLegendaA = new System.Windows.Forms.Button();
            this._folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dataGrid = new System.Windows.Forms.DataGrid();
            this.chkConpaginavuota = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.DS = new mod770_details_certificazioneunica.vistaForm();
            this.txtCF = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInputFile = new System.Windows.Forms.TextBox();
            this.btnInputFile = new System.Windows.Forms.Button();
            this._MyOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.MyOpenFile = createOpenFileDialog(this._MyOpenFile);
            this.saveFileDialog1 = createSaveFileDialog(_saveFileDialog1);
            this.folderBrowserDialog1 = createFolderBrowserDialog(_folderBrowserDialog1);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(9, 169);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(839, 72);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            this.richTextBox1.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox1_LinkClicked);
            // 
            // btnGenera770
            // 
            this.btnGenera770.Location = new System.Drawing.Point(18, 12);
            this.btnGenera770.Name = "btnGenera770";
            this.btnGenera770.Size = new System.Drawing.Size(222, 38);
            this.btnGenera770.TabIndex = 1;
            this.btnGenera770.Text = "Genera Certificazione Unica (Record G)";
            this.btnGenera770.Click += new System.EventHandler(this.btnGenera770_Click);
            // 
            // txtPercorso
            // 
            this.txtPercorso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPercorso.Location = new System.Drawing.Point(142, 143);
            this.txtPercorso.Name = "txtPercorso";
            this.txtPercorso.ReadOnly = true;
            this.txtPercorso.Size = new System.Drawing.Size(709, 20);
            this.txtPercorso.TabIndex = 6;
            // 
            // btnSalvaIn
            // 
            this.btnSalvaIn.AutoSize = true;
            this.btnSalvaIn.Location = new System.Drawing.Point(9, 141);
            this.btnSalvaIn.Name = "btnSalvaIn";
            this.btnSalvaIn.Size = new System.Drawing.Size(124, 23);
            this.btnSalvaIn.TabIndex = 5;
            this.btnSalvaIn.Text = "Percorso in cui salvare";
            this.btnSalvaIn.Click += new System.EventHandler(this.btnSalva_Click);
            // 
            // saveFileDialog1
            // 
            //this.saveFileDialog1.DefaultExt = "cur";
            // 
            // buttonRecordG
            // 
            this.buttonRecordG.Location = new System.Drawing.Point(147, 75);
            this.buttonRecordG.Name = "buttonRecordG";
            this.buttonRecordG.Size = new System.Drawing.Size(84, 23);
            this.buttonRecordG.TabIndex = 9;
            this.buttonRecordG.Text = "Dati \"G\"";
            this.buttonRecordG.UseVisualStyleBackColor = true;
            this.buttonRecordG.Click += new System.EventHandler(this.buttonRecordG_Click);
            // 
            // buttonRecordH
            // 
            this.buttonRecordH.Location = new System.Drawing.Point(131, 75);
            this.buttonRecordH.Name = "buttonRecordH";
            this.buttonRecordH.Size = new System.Drawing.Size(84, 23);
            this.buttonRecordH.TabIndex = 10;
            this.buttonRecordH.Text = "Dati \"H\"";
            this.buttonRecordH.UseVisualStyleBackColor = true;
            this.buttonRecordH.Click += new System.EventHandler(this.buttonRecordH_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLegendaDG);
            this.groupBox1.Controls.Add(this.btnDatiDG);
            this.groupBox1.Controls.Add(this.buttonLegendaG);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonRecordG);
            this.groupBox1.Location = new System.Drawing.Point(12, 336);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(329, 114);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RECORD DI TIPO \"G\": Dati relativi alla comunicazione dati certificazioni lavoro d" +
    "ipendente, assimilati ed assistenza fiscale";
            // 
            // btnLegendaDG
            // 
            this.btnLegendaDG.Location = new System.Drawing.Point(57, 46);
            this.btnLegendaDG.Name = "btnLegendaDG";
            this.btnLegendaDG.Size = new System.Drawing.Size(84, 23);
            this.btnLegendaDG.TabIndex = 20;
            this.btnLegendaDG.Text = "Legenda \"D\"";
            this.btnLegendaDG.UseVisualStyleBackColor = true;
            this.btnLegendaDG.Click += new System.EventHandler(this.btnLegendaDG_Click);
            // 
            // btnDatiDG
            // 
            this.btnDatiDG.Location = new System.Drawing.Point(147, 46);
            this.btnDatiDG.Name = "btnDatiDG";
            this.btnDatiDG.Size = new System.Drawing.Size(84, 23);
            this.btnDatiDG.TabIndex = 19;
            this.btnDatiDG.Text = "Dati \"D\"";
            this.btnDatiDG.UseVisualStyleBackColor = true;
            this.btnDatiDG.Click += new System.EventHandler(this.btnDatiDG_Click);
            // 
            // buttonLegendaG
            // 
            this.buttonLegendaG.Location = new System.Drawing.Point(55, 75);
            this.buttonLegendaG.Name = "buttonLegendaG";
            this.buttonLegendaG.Size = new System.Drawing.Size(84, 23);
            this.buttonLegendaG.TabIndex = 11;
            this.buttonLegendaG.Text = "Legenda \"G\"";
            this.buttonLegendaG.UseVisualStyleBackColor = true;
            this.buttonLegendaG.Click += new System.EventHandler(this.buttonLegendaG_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnLegendaDH);
            this.groupBox2.Controls.Add(this.btnDatiDH);
            this.groupBox2.Controls.Add(this.buttonLegendaH);
            this.groupBox2.Controls.Add(this.buttonRecordH);
            this.groupBox2.Location = new System.Drawing.Point(362, 336);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(285, 114);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "RECORD DI TIPO \"H\": Dati relativi alla comunicazione dati certificazioni lavoro a" +
    "utonomo, provvigioni e redditi diversi";
            // 
            // btnLegendaDH
            // 
            this.btnLegendaDH.Location = new System.Drawing.Point(41, 46);
            this.btnLegendaDH.Name = "btnLegendaDH";
            this.btnLegendaDH.Size = new System.Drawing.Size(84, 23);
            this.btnLegendaDH.TabIndex = 19;
            this.btnLegendaDH.Text = "Legenda \"D\"";
            this.btnLegendaDH.UseVisualStyleBackColor = true;
            this.btnLegendaDH.Click += new System.EventHandler(this.btnLegendaDH_Click);
            // 
            // btnDatiDH
            // 
            this.btnDatiDH.Location = new System.Drawing.Point(131, 46);
            this.btnDatiDH.Name = "btnDatiDH";
            this.btnDatiDH.Size = new System.Drawing.Size(84, 23);
            this.btnDatiDH.TabIndex = 18;
            this.btnDatiDH.Text = "Dati \"D\"";
            this.btnDatiDH.UseVisualStyleBackColor = true;
            this.btnDatiDH.Click += new System.EventHandler(this.btnDatiDH_Click);
            // 
            // buttonLegendaH
            // 
            this.buttonLegendaH.Location = new System.Drawing.Point(41, 75);
            this.buttonLegendaH.Name = "buttonLegendaH";
            this.buttonLegendaH.Size = new System.Drawing.Size(84, 23);
            this.buttonLegendaH.TabIndex = 11;
            this.buttonLegendaH.Text = "Legenda \"H\"";
            this.buttonLegendaH.UseVisualStyleBackColor = true;
            this.buttonLegendaH.Click += new System.EventHandler(this.buttonLegendaH_Click);
            // 
            // buttonPrestazioni
            // 
            this.buttonPrestazioni.Location = new System.Drawing.Point(199, 72);
            this.buttonPrestazioni.Name = "buttonPrestazioni";
            this.buttonPrestazioni.Size = new System.Drawing.Size(173, 23);
            this.buttonPrestazioni.TabIndex = 13;
            this.buttonPrestazioni.Text = "Prestazioni Certificazione Unica";
            this.buttonPrestazioni.UseVisualStyleBackColor = true;
            this.buttonPrestazioni.Click += new System.EventHandler(this.buttonPrestazioni_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnNonResidH);
            this.groupBox3.Controls.Add(this.btnNonResidG);
            this.groupBox3.Controls.Add(this.buttonProblemiH);
            this.groupBox3.Controls.Add(this.buttonIncoerenze);
            this.groupBox3.Controls.Add(this.buttonPrestazioni);
            this.groupBox3.Location = new System.Drawing.Point(466, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(382, 126);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Per cambiare le prestazioni da inserire nei record G e H della Certificazione Uni" +
    "ca andare in \"Configurazione / Compensi / Imposte / Tipo prestazione\"";
            // 
            // btnNonResidH
            // 
            this.btnNonResidH.Location = new System.Drawing.Point(199, 97);
            this.btnNonResidH.Name = "btnNonResidH";
            this.btnNonResidH.Size = new System.Drawing.Size(173, 23);
            this.btnNonResidH.TabIndex = 17;
            this.btnNonResidH.Text = "Dom. Fiscale non Residenti H";
            this.btnNonResidH.UseVisualStyleBackColor = true;
            this.btnNonResidH.Click += new System.EventHandler(this.btnNonResidH_Click);
            // 
            // btnNonResidG
            // 
            this.btnNonResidG.Location = new System.Drawing.Point(20, 97);
            this.btnNonResidG.Name = "btnNonResidG";
            this.btnNonResidG.Size = new System.Drawing.Size(173, 23);
            this.btnNonResidG.TabIndex = 16;
            this.btnNonResidG.Text = "Dom. Fiscale non Residenti G";
            this.btnNonResidG.UseVisualStyleBackColor = true;
            this.btnNonResidG.Visible = false;
            this.btnNonResidG.Click += new System.EventHandler(this.btnNonResidG_Click);
            // 
            // buttonProblemiH
            // 
            this.buttonProblemiH.Location = new System.Drawing.Point(21, 72);
            this.buttonProblemiH.Name = "buttonProblemiH";
            this.buttonProblemiH.Size = new System.Drawing.Size(172, 23);
            this.buttonProblemiH.TabIndex = 15;
            this.buttonProblemiH.Text = "Problemi (solo record H)";
            this.buttonProblemiH.UseVisualStyleBackColor = true;
            this.buttonProblemiH.Click += new System.EventHandler(this.buttonProblemiH_Click);
            // 
            // buttonIncoerenze
            // 
            this.buttonIncoerenze.Location = new System.Drawing.Point(21, 43);
            this.buttonIncoerenze.Name = "buttonIncoerenze";
            this.buttonIncoerenze.Size = new System.Drawing.Size(148, 23);
            this.buttonIncoerenze.TabIndex = 14;
            this.buttonIncoerenze.Text = "Problemi";
            this.buttonIncoerenze.UseVisualStyleBackColor = true;
            this.buttonIncoerenze.Visible = false;
            this.buttonIncoerenze.Click += new System.EventHandler(this.buttonIncoerenze_Click);
            // 
            // btnStampaH
            // 
            this.btnStampaH.Location = new System.Drawing.Point(116, 53);
            this.btnStampaH.Name = "btnStampaH";
            this.btnStampaH.Size = new System.Drawing.Size(76, 38);
            this.btnStampaH.TabIndex = 19;
            this.btnStampaH.Text = "Stampa (Record H)";
            this.btnStampaH.UseVisualStyleBackColor = true;
            this.btnStampaH.Click += new System.EventHandler(this.btnStampaH_Click);
            // 
            // btnStampaG
            // 
            this.btnStampaG.Location = new System.Drawing.Point(32, 53);
            this.btnStampaG.Name = "btnStampaG";
            this.btnStampaG.Size = new System.Drawing.Size(76, 38);
            this.btnStampaG.TabIndex = 18;
            this.btnStampaG.Text = "Stampa (Record G)";
            this.btnStampaG.UseVisualStyleBackColor = true;
            this.btnStampaG.Click += new System.EventHandler(this.btnStampaG_Click);
            // 
            // buttonGenera770recordH
            // 
            this.buttonGenera770recordH.Location = new System.Drawing.Point(18, 60);
            this.buttonGenera770recordH.Name = "buttonGenera770recordH";
            this.buttonGenera770recordH.Size = new System.Drawing.Size(222, 38);
            this.buttonGenera770recordH.TabIndex = 2;
            this.buttonGenera770recordH.Text = "Genera Certificazione Unica (Record H)";
            this.buttonGenera770recordH.UseVisualStyleBackColor = true;
            this.buttonGenera770recordH.Click += new System.EventHandler(this.buttonGenera770recordH_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnDatiB);
            this.groupBox4.Controls.Add(this.btnLegendaB);
            this.groupBox4.Controls.Add(this.btnDatiA);
            this.groupBox4.Controls.Add(this.btnLegendaA);
            this.groupBox4.Location = new System.Drawing.Point(12, 275);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(420, 43);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = " ";
            // 
            // btnDatiB
            // 
            this.btnDatiB.Location = new System.Drawing.Point(319, 14);
            this.btnDatiB.Name = "btnDatiB";
            this.btnDatiB.Size = new System.Drawing.Size(84, 23);
            this.btnDatiB.TabIndex = 15;
            this.btnDatiB.Text = "Dati \"B\"";
            this.btnDatiB.UseVisualStyleBackColor = true;
            this.btnDatiB.Click += new System.EventHandler(this.btnDatiB_Click);
            // 
            // btnLegendaB
            // 
            this.btnLegendaB.Location = new System.Drawing.Point(229, 14);
            this.btnLegendaB.Name = "btnLegendaB";
            this.btnLegendaB.Size = new System.Drawing.Size(84, 23);
            this.btnLegendaB.TabIndex = 14;
            this.btnLegendaB.Text = "Legenda \"B\"";
            this.btnLegendaB.UseVisualStyleBackColor = true;
            this.btnLegendaB.Click += new System.EventHandler(this.btnLegendaB_Click);
            // 
            // btnDatiA
            // 
            this.btnDatiA.Location = new System.Drawing.Point(96, 14);
            this.btnDatiA.Name = "btnDatiA";
            this.btnDatiA.Size = new System.Drawing.Size(84, 23);
            this.btnDatiA.TabIndex = 13;
            this.btnDatiA.Text = "Dati \"A\"";
            this.btnDatiA.UseVisualStyleBackColor = true;
            this.btnDatiA.Click += new System.EventHandler(this.btnDatiA_Click);
            // 
            // btnLegendaA
            // 
            this.btnLegendaA.Location = new System.Drawing.Point(6, 14);
            this.btnLegendaA.Name = "btnLegendaA";
            this.btnLegendaA.Size = new System.Drawing.Size(84, 23);
            this.btnLegendaA.TabIndex = 12;
            this.btnLegendaA.Text = "Legenda \"A\"";
            this.btnLegendaA.UseVisualStyleBackColor = true;
            this.btnLegendaA.Click += new System.EventHandler(this.btnLegendaA_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dataGrid);
            this.groupBox5.Location = new System.Drawing.Point(12, 456);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(702, 109);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "groupBox5";
            // 
            // dataGrid
            // 
            this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid.DataMember = "";
            this.dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid.Location = new System.Drawing.Point(6, 19);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(690, 84);
            this.dataGrid.TabIndex = 3;
            this.dataGrid.Tag = " ";
            // 
            // chkConpaginavuota
            // 
            this.chkConpaginavuota.AutoSize = true;
            this.chkConpaginavuota.Location = new System.Drawing.Point(6, 12);
            this.chkConpaginavuota.Name = "chkConpaginavuota";
            this.chkConpaginavuota.Size = new System.Drawing.Size(202, 30);
            this.chkConpaginavuota.TabIndex = 20;
            this.chkConpaginavuota.Text = "Stampa l\'indirizzo del percipiente sulla\r\nprima pagina.";
            this.chkConpaginavuota.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnStampaG);
            this.groupBox6.Controls.Add(this.chkConpaginavuota);
            this.groupBox6.Controls.Add(this.btnStampaH);
            this.groupBox6.Location = new System.Drawing.Point(243, 7);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(222, 100);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtCF
            // 
            this.txtCF.Location = new System.Drawing.Point(455, 298);
            this.txtCF.Name = "txtCF";
            this.txtCF.Size = new System.Drawing.Size(253, 20);
            this.txtCF.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(452, 282);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Codice fiscale per generazione singola";
            // 
            // txtInputFile
            // 
            this.txtInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInputFile.Location = new System.Drawing.Point(214, 247);
            this.txtInputFile.Multiline = true;
            this.txtInputFile.Name = "txtInputFile";
            this.txtInputFile.ReadOnly = true;
            this.txtInputFile.Size = new System.Drawing.Size(634, 22);
            this.txtInputFile.TabIndex = 25;
            // 
            // btnInputFile
            // 
            this.btnInputFile.Location = new System.Drawing.Point(9, 246);
            this.btnInputFile.Name = "btnInputFile";
            this.btnInputFile.Size = new System.Drawing.Size(183, 23);
            this.btnInputFile.TabIndex = 24;
            this.btnInputFile.Text = "Importa CF da Excel";
            this.btnInputFile.Click += new System.EventHandler(this.btnInputFile_Click);
            // 
            // MyOpenFile
            // 
            //this.MyOpenFile.FileName = "openFileDialog";
            //this.MyOpenFile.Title = "Selezionare il file Excel da importare";
            // 
            // Frmmod770_details_certificazioneunica
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(863, 571);
            this.Controls.Add(this.txtInputFile);
            this.Controls.Add(this.btnInputFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCF);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.buttonGenera770recordH);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnGenera770);
            this.Controls.Add(this.txtPercorso);
            this.Controls.Add(this.btnSalvaIn);
            this.Name = "Frmmod770_details_certificazioneunica";
            this.Text = "Frmmod770_details_certificazioneunica";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


        QueryHelper QHS;
        CQueryHelper QHC;
        string ConnectionString;
        System.Data.DataTable mData = new System.Data.DataTable();
        public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
            QHS = Meta.Conn.GetQueryHelper();
            QHC = new CQueryHelper();
			int esercizio = (int)Meta.GetSys("esercizio");
			GetData.CacheTable(DS.mod770_details, "ayear="+esercizio, "colorder", false);

			Meta.CanSave = false;
			Meta.CanInsert = false;
			Meta.CanInsertCopy = false;
			Meta.SearchEnabled = false;

            string link = "http://www.agenziaentrate.it/ilwwcm/connect/Nsi/Strumenti/Software/Dichiarazioni/";
			switch (esercizio) {
                case 2015: link = "http://www.agenziaentrate.gov.it/wps/content/Nsilib/Nsi/Home/CosaDeviFare/Dichiarare/DichiarazioniSostitutiImposta/Certificazione+Unica+2015/SW+Compilazione+CU+2015/"; break;        
			}

            this.richTextBox1.Text = "La certificazione unica generata può essere inviata telematicamente tramite il \"Software di compilazione Certificazione Unica  "
				+ esercizio
				+ "\" dell'Agenzia delle Entrate.\nTale software si può scaricare gratuitamente a questo indirizzo:\n"
				+ link
				+ "\nUna volta installato ed avviato tale software, usare la voce di menù: 'File / Importa "
				+ esercizio
				+ "'";;
            groupBox5.Visible = false;
            chkConpaginavuota.Checked = false;
            //chkConpaginavuota.Visible = false;
		}
		
		private string vuoto(string formato, int lunghezza) {
			switch (formato) {
                case "AN"://P-N
				case "CF"://P-N
				case "PR"://P-N
                case "VP":// P
                case "VN"://P-N
					return "".PadLeft(lunghezza);
                case "DA":
                case "DT"://P-N
				case "CN"://P-N
				case "PI"://P-N
				case "NU"://P-N
				case "N5"://P-N
				case "CB"://P-N
					return "".PadLeft(lunghezza, '0');
			}
            show(this, "Impossibile creare la stringa vuota per il formato '" + formato+"'");
			return "".PadLeft(lunghezza);
		}

		private string formattaCampoPosizionale(DataRow r, int lunghezza) {
            string filtro = "(frame='" + r["quadro"] + "') and (colnumber='" + r["colonna"] + "')";
            DataRow rFormato = DS.mod770_details.Select(filtro)[0];
            Object valore;
			switch (rFormato["format"].ToString()) {
				case "AN"://P-N
				case "CF"://P-N
                case "CN"://P-N
				case "PR"://P-N
					string s = getString(r, out valore).ToUpper();
					if (s.Length>=lunghezza) {
						return s.Substring(0, lunghezza);
					}
					return s.PadRight(lunghezza);
				case "DT"://P-N
					DateTime dt = getDateTime(r, out valore);
					return dt.ToString("ddMMyyyy");
				case "PI"://P-N
				case "NU"://P-N
				case "CB"://P-N
					string t = getInt(r, out valore).ToString();
					return t.PadLeft(lunghezza, '0');
				case "N5":
					return getInt(r, out valore).ToString().PadLeft(5,'0');
			}
			show(this, "Formato Errato " + rFormato["format"] + " nella Colonna" + r["colonna"]+" del quadro "+r["quadro"]);
			return null;
		}

		/// <summary>
		/// Con riferimento ai campi non posizionali, nel caso in cui la lunghezza del dato da inserire
		///	dovesse eccedere i 16 caratteri disponibili, dovrà essere inserito un ulteriore elemento con un
		/// identico campo-codice e con un campo-valore il cui primo carattere dovrà essere impostato
		/// con il simbolo “+”, mentre i successivi quindici potranno essere utilizzati per la
		/// continuazione del dato da inserire.
		/// </summary>
		/// <param name="campoCodice"></param>
		/// <param name="s"></param>
		/// <returns></returns>
		private string[] stringaASinistra(string campoCodice, string s) {
			s = s.ToUpper().Trim();
			if (s.Length <= 16) return new string[] {campoCodice + s.PadRight(16)};
			string[] result = new string[(s.Length + 13) / 15];
			result[0] = campoCodice + s.Substring(0, 16);
			for (int i=1; i<result.Length-1; i++) {
				result[i] = campoCodice + "+" + s.Substring(1 + i*15, 15);
			}
			result[result.Length-1] = campoCodice + "+" + s.Substring(15*result.Length - 14).PadRight(15);
			return result;
		}

        private Type getTipo(DataRow rFormato) {
            switch (rFormato["format"].ToString()) {
                case "AN"://P-N
                case "CF"://P-N
                case "CN"://P-N
                case "PR"://P-N
                case "N10"://N
                case "CB12"://N
                    return typeof(string);
                case "PI"://P-N
                case "DA"://N
                case "NP"://N
                case "NU"://P-N
                case "PC"://N
                case "QU"://N
                case "CB"://P-N
                case "N1"://N
                case "N2"://N
                case "N3"://N
                case "N4"://N
                case "N5"://N
                    return typeof(int);
                case "DT"://P-N
                case "DN"://N
                case "D4"://N
                case "D6"://N
                    return typeof(DateTime);
                case "VP"://P
                case "VN"://P-N
                    return typeof(decimal);
            }
            show("Formato sconosciuto nel quadro " + rFormato["frame"] + " colonna " + rFormato["colnumber"]);
            return null;
        }

		private string getString(DataRow r, out object valore) {
            if (r["intero"] != DBNull.Value) {
                show(this,"Intero e non stringa nel quadro " + r["quadro"] + " colonna " + r["colonna"]);
            }
            if (r["data"] != DBNull.Value) {
                show(this,"Data e non stringa nel quadro " + r["quadro"] + " colonna " + r["colonna"]);
            }
            if (r["decimale"] != DBNull.Value)
            {
                show(this, "Decimale e non stringa nel quadro " + r["quadro"] + " colonna " + r["colonna"]);
            }
            return (string) (valore = r["stringa"]);
        }

        private int getInt(DataRow r, out object valore) {
            if (r["stringa"] != DBNull.Value) {
                show(this,"Stringa e non intero nel quadro " + r["quadro"] + " colonna " + r["colonna"]);
            }
            if (r["data"] != DBNull.Value) {
                show(this,"Data e non intero nel quadro " + r["quadro"] + " colonna " + r["colonna"]);
            }
            if (r["decimale"] != DBNull.Value)
            {
                show(this, "Decimale e non intero nel quadro " + r["quadro"] + " colonna " + r["colonna"]);
            }
            return (int) (valore = r["intero"]);
        }

        private decimal getDecimal(DataRow r, out object valore)
        {
            if (r["stringa"] != DBNull.Value)
            {
                show(this, "Stringa e non decimal nel quadro " + r["quadro"] + " colonna " + r["colonna"]);
            }
            if (r["data"] != DBNull.Value)
            {
                show(this, "Data e non decimal nel quadro " + r["quadro"] + " colonna " + r["colonna"]);
            }
            if (r["intero"] != DBNull.Value)
            {
                show(this, "Intero e non decimal nel quadro " + r["quadro"] + " colonna " + r["colonna"]);
            }
            return (decimal)(valore = r["decimale"]);
        }

        private DateTime getDateTime(DataRow r, out object valore) {
            if (r["stringa"] != DBNull.Value) {
                show(this,"Stringa e non data nel quadro " + r["quadro"] + " colonna " + r["colonna"]);
            }
            if (r["intero"] != DBNull.Value) {
                show(this,"Intero e non data nel quadro " + r["quadro"] + " colonna " + r["colonna"]);
            }
            if (r["decimale"] != DBNull.Value)
            {
                show(this, "Decimale e non data nel quadro " + r["quadro"] + " colonna " + r["colonna"]);
            }
            return (DateTime) (valore = r["data"]);
		}

		private string[] formattaCampoNonPosizionale(DataRow r, out object valore, bool perStampa) {
            string campoCodice = r["quadro"] + r["riga"].ToString().PadLeft(3, '0') + r["colonna"];
            if (r["quadro"].ToString().Substring(0,2) == "DA") campoCodice = r["quadro"].ToString() + r["colonna"].ToString();
            if ((r["quadro"].ToString().Substring(0, 2) == "DB") || (r["quadro"].ToString().Substring(0, 2) == "DC")) 
                campoCodice = r["quadro"].ToString() + r["colonna"].ToString();
            if (r["quadro"].ToString() == "SS")
                return new string[] { campoCodice + getInt(r, out valore).ToString().PadLeft(16) };
            string filtro = "(frame='" + r["quadro"] + "') and (colnumber='" + r["colonna"] + "')";
            DataRow[] rFormato = DS.mod770_details.Select(filtro);
			switch (rFormato[0]["format"].ToString()) {
				case "AN"://P-N
				case "CF"://P-N
				case "PR"://P-N
					return stringaASinistra(campoCodice, getString(r, out valore));
                case "PN"://P-N
                    return stringaASinistra(campoCodice, getString(r, out valore));
                case "PE"://P-N
                    return stringaASinistra(campoCodice, getString(r, out valore));
				case "CN"://P-N
                    return stringaASinistra(campoCodice, getString(r, out valore));
				case "PI"://P-N
					return stringaASinistra(campoCodice, getInt(r, out valore).ToString());
				case "DA"://N
				case "NP"://N
				case "NU"://P-N
				case "PC"://N
				case "QU"://N
					return new string[] {campoCodice + getInt(r, out valore).ToString().PadLeft(16)};
				case "CB"://P-N
                    if (!perStampa) {
                        return new string[] { campoCodice + getInt(r, out valore).ToString().PadLeft(1, '0').PadLeft(16) };
                    }
                    else {
                        object o = null;
                        getInt(r, out o);
                        valore = " ";
                        
                        if (o.ToString() == "1")
                            valore = "X";
                        return new string[] { campoCodice + valore.ToString().PadLeft(1, '0').PadLeft(16) };
                        
                    }
				case "N1"://N
					return new string[] {campoCodice + getInt(r, out valore).ToString().PadLeft(1,'0').PadLeft(16)};
				case "N2"://N
					return new string[] {campoCodice + getInt(r, out valore).ToString().PadLeft(2,'0').PadLeft(16)};
				case "N3"://N
                    return new string[] {campoCodice + getInt(r, out valore).ToString().PadLeft(3, '0').PadLeft(16) };
				case "N5"://N
                    return new string[] {campoCodice + getInt(r, out valore).ToString().PadLeft(5, '0').PadLeft(16) };
				case "N10"://N
                    return new string[] {campoCodice + getString(r, out valore).PadLeft(10, '0').PadLeft(16) };
				case "CB12"://N
                    return new string[] {campoCodice + getString(r, out valore).PadLeft(12, '0').PadLeft(16) };
				case "DT"://P-N
				case "DN"://N
					return new string[] {campoCodice + getDateTime(r, out valore).ToString("ddMMyyyy").PadLeft(16)};
				case "D4"://N
                    return new string[] {campoCodice + getDateTime(r, out valore).ToString("ddMM").PadLeft(16) };
				case "D6"://N
                    return new string[] {campoCodice + getDateTime(r, out valore).ToString("MMyyyy").PadLeft(16) };
                case "VP"://N
                case "VN"://P-N
                    return new string[] { campoCodice + getDecimal(r, out valore).ToString().PadLeft(16) };
                default: show("FCNP: Formato sconosciuto nel quadro " + r["quadro"] + " colonna " + r["colonna"]);
                    valore = null;
                    return null;
			}
		}

       

		private string getHeader(DataTable t, string quadro, int progressivoComunicazione, int progressivoModulo) {
			StringBuilder sb = new StringBuilder();
			string filtro = "(frame='"+quadro+"')";
			DataRow[] record = DS.mod770_details.Select(filtro);
			foreach (DataRow r in record) {
				string formato = (string) r["format"];
				int lunghezza = (int) r["fieldlen"];
          
                string filtro2 = QHC.AppAnd(QHC.CmpEq("quadro",quadro), QHC.CmpEq("progr",progressivoComunicazione), QHC.CmpEq("colonna", r["colnumber"]), 
                    QHC.CmpEq("modulo",progressivoModulo));

				DataRow[] r770 = t.Select(filtro2);
                if (r770.Length > 1) {
                    show(this, "Errore interno: trovate " + r770.Length + " righe con questo filtro\n" + filtro2);
                }
				if (r770.Length==0) {
					sb.Append(vuoto(formato, lunghezza));
				} 
				else {
					sb.Append(formattaCampoPosizionale(r770[0], lunghezza));
				}
			}
			return sb.ToString();
		}


     
        private int scriviRecord(TextWriter tw, string header, DataTable t, string quadri, int progressivoComunicazione, int progressivoModulo)
        {
			int numeroRecord = 1;
            //string pc = header.Substring(17, 8);
            //int progressivoComunicazione = Int32.Parse(pc);
			string filtro = "(progr="+progressivoComunicazione+") and (quadro IN("+quadri+") and (modulo = " + progressivoModulo + "))";
			DataRow[] record = t.Select(filtro, "quadro, riga, colonna");
			tw.Write(header);
			int aDisposizione = 1809;//1898 - 89 (posizioni per i campi posizionali) = 1809
            Object valore;
			foreach (DataRow r in record) {
				foreach (string s in formattaCampoNonPosizionale(r, out valore, false)) {
					if (s.Length > aDisposizione) {
						tw.WriteLine("A".PadLeft(aDisposizione));
						numeroRecord++;
						tw.Write(header);
						aDisposizione = 1809;
					}
					tw.Write(s);
					aDisposizione -= s.Length;
				}
			}
			tw.WriteLine("A".PadLeft(aDisposizione));
			return numeroRecord;
		}

		private TextWriter getStreamWriter() {
			try {
				return new StreamWriter(txtPercorso.Text, false, Encoding.Default);
			} 
			catch (Exception) {
				if (saveFileDialog1.ShowDialog(this)!=DialogResult.OK) return null;
                string fileName = saveFileDialog1.FileName;
                txtPercorso.Text = Path.GetDirectoryName(fileName);
				try {
                    return new StreamWriter(fileName, false, Encoding.Default);
				} 
				catch (Exception e) {
					QueryCreator.ShowException(this, "Inserire il percorso del file dove salvare la Certificazione Unica", e);
				}
			}
			return null;
		}

		private void salvaCertificazioneUnica(TextWriter tw, DataSet ds, bool soloRecordH) {

			tw.WriteLine(getHeader(ds.Tables[0], "HRA", 1,1) + "A");

			tw.WriteLine(getHeader(ds.Tables[0], "HRB", 1,1) + "A");

            int nRecordD = 0;
			int nRecordH = 0;
            int nRecordG = 0;
            DataRow[] rD = ds.Tables[0].Select("(quadro='HRD')and(colonna='05')");
            if (soloRecordH)
            {
                foreach (DataRow rpd in rD)
                {
                    int progressivoComunicazione = Convert.ToInt32(rpd["intero"]);

                    string headerD = getHeader(ds.Tables[0], "HRD", progressivoComunicazione, 1);
                    nRecordD+=scriviRecord(tw, headerD, ds.Tables[0], "'DA001','DA002','DA003'", progressivoComunicazione, 1);

                    DataRow[] rH = ds.Tables[0].Select("(quadro='HRH')and(colonna='05') and (progr = " + progressivoComunicazione + ")");
                    foreach (DataRow rph in rH)
                    {
                        int progressivoModulo = Convert.ToInt32(rph["modulo"]);
                        string headerH = getHeader(ds.Tables[0], "HRH", progressivoComunicazione, progressivoModulo);
                        nRecordH += scriviRecord(tw, headerH, ds.Tables[0], "'AU'", progressivoComunicazione, progressivoModulo);
                    }
                }
            }
            else
            {
                foreach (DataRow rpd in rD)
                {
                    int progressivoComunicazione = Convert.ToInt32(rpd["intero"]);

                    string headerD = getHeader(ds.Tables[0], "HRD", progressivoComunicazione, 1);
                    nRecordD+=scriviRecord(tw, headerD, ds.Tables[0], "'DA001','DA002','DA003'", progressivoComunicazione, 1);

                    DataRow[] rG = ds.Tables[0].Select("(quadro='HRG')and(colonna='05') and (progr = " + progressivoComunicazione + ")");
                    foreach (DataRow rph in rG)
                    {
                        int progressivoModulo = Convert.ToInt32(rph["modulo"]);
                        string headerG = getHeader(ds.Tables[0], "HRG", progressivoComunicazione, progressivoModulo);
                        nRecordG += scriviRecord(tw, headerG, ds.Tables[0], "'DB001','DB801','DB802','DB803','DB804','DB805','DB806','DB807','DB808','DB809','DB810','DC001'", progressivoComunicazione, progressivoModulo);
                    }
                }
            }

          
            string recordZ = "Z".PadRight(15)//Tipo record + Filler 
            + "1".PadLeft(9, '0')//Numero record di tipo ‘B’ 
            + "0".PadLeft(9, '0')//Numero record di tipo ‘C’ 
            + nRecordD.ToString().PadLeft(9, '0')//Numero record di tipo ‘D’ 
            + nRecordG.ToString().PadLeft(9, '0')//Numero record di tipo ‘G’ 
			+ nRecordH.ToString().PadLeft(9, '0')//Numero record di tipo ‘H’ 
            + "".PadRight(27)
            + "A".PadLeft(1811);//1898-15-9*8 = 1811

			tw.WriteLine(recordZ);

			tw.Close();

            if (soloRecordH)
			show(this, "Modello Certificazione Unica salvato nel file: " + saveFileDialog1.FileName
				+ "\nComunicazioni Lavoro Autonomo:   "+rD.Length+"  ("+nRecordH+" record di tipo \"H\")" + 
				"Creazione dichiarazione terminata");
            else
                show(this, "Modello Certificazione Unica salvato nel file: " + saveFileDialog1.FileName
                + "\n\nComunicazioni Lavoro Dipendente: " + rD.Length + "  (" + nRecordG + " record di tipo \"G\")" +
                "Creazione dichiarazione terminata");
		}

        //Questo metodo va chiamato prima di generare il mod770, è presenta anche nel modello CUD
        private bool verificaContrattiNonPagati()
        {
            int esercizio = (int)Meta.GetSys("esercizio");
            string query = "select distinct parasubcontract.ycon, parasubcontract.ncon, exhibitedcud.idexhibitedcud "
                + "FROM parasubcontract "
                + "join payroll on payroll.idcon = parasubcontract.idcon "
                + "left outer join exhibitedcud on exhibitedcud.idcon = parasubcontract.idcon "
                + "where not exists (select * from expensepayroll "
                + "join expenselink ON expenselink.idparent = expensepayroll.idexp "
                + "join expenselast on expenselast.idexp = expenselink.idchild "
                + "join payment on payment.kpay = expenselast.kpay "
                + "where payment.kpaymenttransmission is not null "
                + "and payroll.idpayroll = expensepayroll.idpayroll)"
                + "and isnull(payroll.flagbalance,'N')='N' "
                + "and payroll.fiscalyear = " + (esercizio - 1)
                + " and exhibitedcud.fiscalyear = " + (esercizio - 1);
            DataTable t = Meta.Conn.SQLRunner(query);
            if (t.Rows.Count > 0)
            {
                string errore = "Esistono dei cedolini nei seguenti contratti i cui pagamenti non sono ancora stati trasmessi in banca:";
                foreach (DataRow r in t.Rows)
                {
                    errore += "\nn° " + r["ncon"] + " del " + r["ycon"] + ";";
                    if (r["idexhibitedcud"] != DBNull.Value)
                    {
                        errore += " (in tale contratto è presente anche il cud n° " + r["idexhibitedcud"] + ")";
                    }
                }
                errore += "\n\npoichè in tali contratti ci sono cedolini non pagati,"
                    + "tali cedolini vanno trasferiti nella competenza dell'esercizio attuale."
                    + "\nL'operazione è stata annullata.";
                show(this, errore);
                return false;
            }
            return true;
        }

        //Questo metodo va chiamato prima di generare il mod770, è presenta anche nel modello CUD
        private bool verificaPrestazioniCertificazioniCUD () {
           int esercizio = (int)Meta.GetSys("esercizio");
           string query = "SELECT DISTINCT service.description, parasubcontract.ycon, " 
                   + "parasubcontract.ncon "
                   + "FROM parasubcontract "
                   + "JOIN parasubcontractyear "
                   + "ON  parasubcontractyear.idcon =  parasubcontract.idcon "
                   + "AND  parasubcontractyear.ayear = " + (esercizio - 1) + " " 
                   + "JOIN registry ON parasubcontract.idreg = registry.idreg "
                   + "JOIN exhibitedcud on exhibitedcud.idlinkedcon = parasubcontract.idcon "
                   + "JOIN service ON service.idser = parasubcontract.idser "
                   + "WHERE EXISTS (select * from payroll JOIN expensepayroll ON payroll.idpayroll = expensepayroll.idpayroll "
                   + "JOIN expenselink ON expenselink.idparent = expensepayroll.idexp "
                   + "JOIN expenselast on expenselast.idexp = expenselink.idchild "
                   + "WHERE payroll.idcon = parasubcontract.idcon  AND payroll.fiscalyear =  " + (esercizio - 1) + ") "
                   + "AND   exhibitedcud.fiscalyear = " + (esercizio - 1) + " "
                   + "AND   ISNULL(service.certificatekind,'')<> 'U' ";

            DataTable t = Meta.Conn.SQLRunner(query);
            if (t.Rows.Count > 0) {
                string errore = "Esistono dei contratti esibiti come CUD in altri contratti, le cui prestazioni " +
                                "però non sono associate al modello di certificazione fiscale CUD "; 
                foreach (DataRow r in t.Rows) {
                    errore += "\nn° " + r["ncon"] + " del " + r["ycon"] + "-" + r["description"];
                }
                errore += "\nL'operazione è stata annullata.";
                show(this, errore);
                return false;
            }
            return true;
        }

        private bool verificaPrestazioniCertificazioniNonCUD () {
            int esercizio = (int)Meta.GetSys("esercizio");

            string query = "SELECT COUNT(parasubcontract.idcon) as numero, registry.title "
                    + "FROM parasubcontract "
                    + "JOIN parasubcontractyear "
                    + "ON  parasubcontractyear.idcon =  parasubcontract.idcon "
                    + "AND  parasubcontractyear.ayear = " + (esercizio - 1) + " "
                    + "JOIN registry ON parasubcontract.idreg = registry.idreg "
                    + "JOIN service ON service.idser = parasubcontract.idser "
                    + "WHERE EXISTS (select * from payroll JOIN expensepayroll "
                    + "ON payroll.idpayroll = expensepayroll.idpayroll "
                    + "JOIN expenselink ON expenselink.idparent = expensepayroll.idexp "
                    + "JOIN expenselast on expenselast.idexp = expenselink.idchild "
                    + "WHERE payroll.idcon = parasubcontract.idcon "
                    + "and payroll.fiscalyear = " + (esercizio - 1) + " )"
                    + "AND NOT EXISTS "
                    + "(select * from exhibitedcud "
                    + "where idlinkedcon = parasubcontract.idcon "
                    + "and exhibitedcud.fiscalyear = " + (esercizio - 1) + " )"
                    + "AND ISNULL(service.certificatekind,'') = 'U' "
                    + "GROUP BY registry.title " 
                    + "HAVING COUNT(parasubcontract.idcon) > 1 "; 

            DataTable t = Meta.Conn.SQLRunner(query);
            if (t.Rows.Count > 0) {
                string errore = "Esistono dei percipienti con contratti non esibiti come CUD in altri contratti, le cui prestazioni " + 
                                "però sono associate al modello di certificazione fiscale CUD ";
                foreach (DataRow r in t.Rows) {
                    errore += "\nPercipiente" + r["title"]; 
                }
                errore += "\nL'operazione è stata annullata.";
                show(this, errore);
                return false;
            }
            return true;
        }

        private void verificaPresenzaProvvigioni() {
            int esercizio = (int)Meta.GetSys("esercizio");

            string query = "SELECT DISTINCT registry.title AS title, ISNULL(registry.cf, registry.foreigncf) AS cf " +
            " FROM expense " +
            " JOIN expenselast on expense.idexp = expenselast.idexp " +
            " JOIN payment " +
            " ON payment.kpay = expenselast.kpay " +
            " JOIN paymenttransmission " +
            " ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission " +
            " JOIN service on service.idser=expenselast.idser " +
            " LEFT OUTER JOIN motive770service M " +
            " ON M.idser = service.idser " +
            " AND " + QHS.CmpEq("M.ayear", (esercizio - 1)) +
            " JOIN registry ON expense.idreg = registry.idreg " +
            " WHERE registry.idregistryclass <> '10' " +
            " AND NOT EXISTS(SELECT * FROM registryrole WHERE idrole = '16' AND registryrole.idreg = expense.idreg) " +
            " AND " + QHS.CmpEq("year(paymenttransmission.transmissiondate)", (esercizio - 1)) +
            " AND service.rec770kind = 'H' " +
            " AND ((select expenseyear.amount from expenseyear where expenseyear.idexp = expenselast.idexp) " +
            " + ISNULL( " +
            " (SELECT SUM(amount) FROM expensevar " +
            " WHERE expensevar.idexp = expense.idexp " +
            " AND " + QHS.CmpLe("expensevar.yvar", (esercizio - 1)) +
            " AND ISNULL(autokind,0) <> 4) " +
            " ,0)) > 0 " +
            " and (select count(*) from expensetax where expensetax.idexp=expense.idexp) > 0 " +
            "AND " + QHS.CmpEq("service.codeser", "07_PROVVIGIONI");
            
            DataTable t = Meta.Conn.SQLRunner(query);
            if (t.Rows.Count > 0) {
                string errore = "Sono state pagate delle provvigioni. Controllare le causali delle dichiarazioni nelle quali sono state usate.\r\n" +
                    "Controllare le dichiarazioni dei seguenti percipienti\r\n";
                foreach (DataRow r in t.Rows) {
                    errore += "\nNominativo: " + r["title"] + " - Codice Fiscale " + " - " + r["cf"];
                }
                show(this, errore);
            }
        }

        private bool verificaPrestazioniSenzaCausale() {
            int esercizio = (int)Meta.GetSys("esercizio");

            string query = "SELECT DISTINCT service.codeser as codeser, service.description as description " +
		    " FROM expense " + 
		    " JOIN expenselast on expense.idexp = expenselast.idexp " +
		    " JOIN payment " +
		    " ON payment.kpay = expenselast.kpay " +
		    " JOIN paymenttransmission " +
		    " ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission " +
		    " JOIN service on service.idser=expenselast.idser " +
		    " LEFT OUTER JOIN motive770service M " +
		    " ON M.idser = service.idser " +
	        " AND " + QHS.CmpEq("M.ayear", (esercizio - 1)) +
	        " JOIN registry ON expense.idreg = registry.idreg " +
	        " WHERE registry.idregistryclass <> '10' " +
	        " AND NOT EXISTS(SELECT * FROM registryrole WHERE idrole = '16' AND registryrole.idreg = expense.idreg) " +
	        " AND " + QHS.CmpEq("year(paymenttransmission.transmissiondate)" , (esercizio - 1)) +
	        " AND service.rec770kind = 'H' " +
	        " AND ((select expenseyear.amount from expenseyear where expenseyear.idexp = expenselast.idexp) " +
	        " + ISNULL( " +
	        " (SELECT SUM(amount) FROM expensevar " +
	        " WHERE expensevar.idexp = expense.idexp " +
            " AND " + QHS.CmpLe("expensevar.yvar", (esercizio-1)) +
	        " AND ISNULL(autokind,0) <> 4) " +
	        " ,0)) > 0 " +
	        " and (select count(*) from expensetax where expensetax.idexp=expense.idexp) > 0 " +
	        " and m.idmot is null";

            DataTable t = Meta.Conn.SQLRunner(query);
            if (t.Rows.Count > 0) {
                string errore = "Ci sono prestazioni adoperate che confluiranno nel record H senza causale. " +
                    "\r\nImpostare la causale delle prestazioni sprovviste della stessa";
                foreach (DataRow r in t.Rows) {
                    errore += "\nCodice: " + r["codeser"] + " - descrizione " + " - " + r["description"];
                }
                errore += "\nL'operazione è stata annullata.";
                show(this, errore);
                return false;
            }
            return true;
        }

        //Questo metodo va chiamato prima di generare il mod770, è presenta anche nel modello CUD
        private bool verificaPrestazioniCertificazioniInNonCUD () {
            int esercizio = (int)Meta.GetSys("esercizio");
            string query = "SELECT DISTINCT service.description, parasubcontract.ycon, "
                   + "parasubcontract.ncon "
                   + "FROM parasubcontract "
                   + "JOIN parasubcontractyear "
                   + "ON  parasubcontractyear.idcon =  parasubcontract.idcon "
                   + "AND  parasubcontractyear.ayear = " + (esercizio - 1) + " "
                   + "JOIN registry ON parasubcontract.idreg = registry.idreg "
                   + "JOIN exhibitedcud on exhibitedcud.idcon = parasubcontract.idcon "
                   + "JOIN service ON service.idser = parasubcontract.idser "
                   + "WHERE EXISTS (select * from payroll JOIN expensepayroll ON payroll.idpayroll = expensepayroll.idpayroll "
                   + "JOIN expenselink ON expenselink.idparent = expensepayroll.idexp "
                   + "JOIN expenselast on expenselast.idexp = expenselink.idchild "
                   + "WHERE payroll.idcon = parasubcontract.idcon  AND payroll.fiscalyear =  " + (esercizio - 1) + ") "
                   + "AND   exhibitedcud.fiscalyear = " + (esercizio - 1) + " "
                   + "AND   ISNULL(service.certificatekind,'')<> 'U' ";

            DataTable t = Meta.Conn.SQLRunner(query);
            if (t.Rows.Count > 0) {
                string errore = "Ci sono CUD allegati a contratti che a loro volta non generano CUD (es. assegnisti di ricerca)";
                foreach (DataRow r in t.Rows) {
                    errore += "\nn° " + r["ncon"] + " del " + r["ycon"] + "-" + r["description"];
                }
                errore += "\nL'operazione è stata annullata.";
                show(this, errore);
                return false;
            }
            return true;
        }


		private void btnGenera770_Click(object sender, System.EventArgs e) {
            //if (!verificaContrattiNonPagati()) return;
            //if (!verificaPrestazioniCertificazioniCUD()) return;
            //if (!verificaPrestazioniCertificazioniInNonCUD()) return;
            //if (!verificaPrestazioniCertificazioniNonCUD()) return;
            //if (!verificaPrestazioniSenzaCausale()) return;
            //verificaPresenzaProvvigioni();
            generaIlModello770(false, true, false);
        }

		private void btnSalva_Click(object sender, System.EventArgs e) {
			if (folderBrowserDialog1.ShowDialog(this)==DialogResult.OK) {
                txtPercorso.Text = folderBrowserDialog1.SelectedPath;
			}
		}

		private void richTextBox1_LinkClicked(object sender, System.Windows.Forms.LinkClickedEventArgs e) {
			runProcess(e.LinkText, true);
		}

        class Colonna:IComparable {
            public string quadro;
            public int riga;
            int colorder;
            public string colonna;
            public Type type;

            public Colonna(DataRow rFormato, int riga, Type tipo) {
                this.quadro = (string)rFormato["frame"];
                this.riga = riga;
                this.colorder = (int)rFormato["colorder"];
                this.colonna = (string)rFormato["colnumber"];
                this.type = tipo;
            }

            public int CompareTo(Object obj) {
                Colonna c = (Colonna)obj;

                if (quadro.StartsWith("HR") && !c.quadro.StartsWith("HR")) {
                    return -1;
                }
                if (!quadro.StartsWith("HR") && c.quadro.StartsWith("HR")) {
                    return 1;
                }

                if (quadro.CompareTo(c.quadro) != 0) {
                    return quadro.CompareTo(c.quadro);
                }
                if (c.riga==riga) {
                    return colorder - c.colorder;
                }
                return riga-c.riga;
            }
        }

        private string getNomeColonnaExcel(List<Colonna> list, object quadro, object riga, object colonna) {
            foreach (Colonna c in list) {
                if (c.quadro.Equals(quadro) && c.colonna.Equals(colonna) && !c.riga.Equals(riga))
                {
                    return quadro + "-rig" + riga + "-col" + colonna;
                }
            }
            return quadro + "-col" + colonna;
        }

        private void visualizzaQuadroInExcel(string record) {
            string filtroQuadro = "";
            if (record == "A") filtroQuadro = "quadro in ('HRA')";
            if (record == "B") filtroQuadro = "quadro in ('HRB')";
            if ((record == "DG")||(record == "DH")) filtroQuadro = "quadro in ('HRD','DA001','DA002','DA003')";
            if (record == "H") filtroQuadro = "quadro in ('HRH','AU')";
            if (record == "G") filtroQuadro = "quadro in ('HRG','DB001','DB801','DB802','DB803','DB804','DB805','DB806','DB807','DB808','DB809','DB810','DC001')";
            Cursor = Cursors.WaitCursor;

            generaIlModello770(((record == "H") || (record == "DH") || (record == "B")), false, false); // simuliamo la generazione del record H
           
            if (tMod770== null) return;
            DataRow[] righe770 = tMod770.Select(filtroQuadro, "progr");
            if (righe770.Length == 0) {
                show(this, "Non ci sono dati per il record " + record);
                return;
            }
            Object valore;
            List<Colonna> lColonne = new List<Colonna>();
            foreach (DataRow r in righe770) {
                string filtro = "frame='" + r["quadro"] + "' and colnumber='" + r["colonna"]+"'";
                DataRow[] rr = DS.mod770_details.Select(filtro);
                if (rr.Length != 1) {
                    show(this, "Ho trovato " + rr.Length + " righe con questo filtro:\n" + filtro);
                }
                formattaCampoNonPosizionale(r, out valore, false);
                Colonna c = new Colonna(rr[0], (int)r["riga"], valore.GetType());
                int pos = lColonne.BinarySearch(c);
                if (pos < 0) {
                    lColonne.Insert(-pos - 1, c);
                }
            }
            DataTable t = new DataTable();
            foreach (Colonna c in lColonne) {
                string campoCodice = getNomeColonnaExcel(lColonne, c.quadro, c.riga, c.colonna);
                t.Columns.Add(campoCodice, c.type);
            }
            DataRow riga = t.NewRow();
            t.Rows.Add(riga);
            int progr = (int)righe770[0]["progr"];
            foreach (DataRow r in righe770) {
                if (progr != (int)r["progr"]) {
                    progr = (int)r["progr"];
                    riga = t.NewRow();
                    t.Rows.Add(riga);
                }
                string campoCodice = getNomeColonnaExcel(lColonne, r["quadro"], r["riga"], r["colonna"]);
                if (!t.Columns.Contains(campoCodice))
                    continue;
                if (riga[campoCodice] != DBNull.Value) {
                    show(this, "Il campo " + campoCodice + " è stato assegnato due volte");
                }
                formattaCampoNonPosizionale(r, out valore, false);
                riga[campoCodice] = valore;
            }
            exportclass.DataTableToExcel(t, true);
            Cursor = null;
        }

        private void buttonRecordG_Click(object sender, EventArgs e) {
            visualizzaQuadroInExcel("G");
        }

        private void buttonRecordH_Click(object sender, EventArgs e) {
            visualizzaQuadroInExcel("H");
        }

        private void buttonLegendaG_Click(object sender, EventArgs e) {
            visualizzaLegenda("frame in ('HRG', 'DB001','DB801','DB802','DB803','DB804','DB805','DB806','DB807','DB808','DB809','DB810','DC001')");
        }

        private void buttonLegendaH_Click(object sender, EventArgs e) {
            visualizzaLegenda("frame in ('HRH','AU')");
        }

        private void visualizzaLegenda(string filtroQuadro) {
            Cursor = Cursors.WaitCursor;
            DataRow[] legenda = DS.mod770_details.Select(filtroQuadro, "colorder");
            DataTable t = new DataTable();
            t.Columns.Add("Quadro", typeof(System.String));
            t.Columns.Add("Colonna", typeof(System.String));
            t.Columns.Add("Descrizione", typeof(System.String));
            t.Columns.Add("Formato", typeof(System.String));
            t.Columns.Add("Posizione",typeof(System.Int32));
            t.Columns.Add("Lunghezza campo", typeof(System.Int32));
            t.Columns.Add("Sezione", typeof(System.String));
            t.Columns.Add("Valori ammessi", typeof(System.String));
            foreach (DataRow r in legenda) {
                t.Rows.Add(r["frame"], r["colnumber"], r["description"], r["format"], r["position"], r["fieldlen"], r["section"], r["admittedvalues"]);
            }
            exportclass.DataTableToExcel(t, true);
            Cursor = null;
        }

        private void buttonPrestazioni_Click(object sender, EventArgs e) {
            int esercizio = (int)Meta.GetSys("esercizio");
            string query = @"select distinct expenselast.idser 
                            from expenselast
                            join expenselink on expenselink.idchild = expenselast.idexp
                            join expensetax on expensetax.idexp = expenselink.idparent
                            join expense on expense.idexp=expensetax.idexp 
                            where ymov>=" + (esercizio - 1) + " and idser is not null";
                            DataTable tPrestAttive = DataAccess.SQLRunner(Meta.Conn, query);
            DataTable tPrestazioni = DataAccess.RUN_SELECT(Meta.Conn, "service", null, null, null, null, null, true);
            DataTable t = new DataTable();
            t.Columns.Add("Prestazioni del record 'G'");
            t.Columns.Add("Prestazioni del record 'H'");
            t.Columns.Add("Prestazioni non inserite nella certificazione unica");
            t.Columns.Add("Prestazioni non usate nel " + (esercizio - 1));
            List<string> lg = new List<string>();
            List<string> lh = new List<string>();
            List<string> ll = new List<string>();
            List<string> ln = new List<string>();
            foreach (DataRow rp in tPrestazioni.Rows) {
                if (tPrestAttive.Select("idser='" + rp["idser"]+"'").Length > 0) {
                    switch (rp["rec770kind"].ToString().ToUpper()) {
                        case "G": lg.Add(rp["idser"] + " - " + rp["description"]); break;
                        case "H": lh.Add(rp["idser"] + " - " + rp["description"]); break;
                        default: ll.Add(rp["idser"] + " - " + rp["description"]); break;
                    }
                }
                else {
                    switch (rp["rec770kind"].ToString().ToUpper()) {
                        case "G": ln.Add("G - "+rp["idser"] + " - " + rp["description"]); break;
                        case "H": ln.Add("H - "+rp["idser"] + " - " + rp["description"]); break;
                        default: ln.Add("* - "+rp["idser"] + " - " + rp["description"]); break;
                    }
                }
            }
            int max = lg.Count;
            if (lh.Count > max) max = lh.Count;
            if (ll.Count > max) max = ll.Count;
            if (ln.Count > max) max = ln.Count;
            for (int i = 0; i < max; i++) {
                DataRow r = t.NewRow();
                if (lg.Count > i) r[0] = lg[i];
                if (lh.Count > i) r[1] = lh[i];
                if (ll.Count > i) r[2] = ll[i];
                if (ln.Count > i) r[3] = ln[i];
                t.Rows.Add(r);
            }
            exportclass.DataTableToExcel(t, true);
        }

        private DataTable getConfigurazionePrestazioni() {
            int esercizio = (int)Meta.GetSys("esercizio");
            string query = "select distinct idser from expensetax "
                + "join expenselast on expenselast.idexp=expensetax.idexp "
                + "join expense on expense.idexp = expenselast.idexp "
                + "where ymov>=" + (esercizio - 1)
                + " and idser is not null";
            DataTable t = DataAccess.SQLRunner(Meta.Conn, query);
            string prestazioni = QueryCreator.ColumnValues(t, null, "idser", true);
            string filtroPrestazioni = prestazioni == "" ? "0=1" : "service.idser in (" + prestazioni + ")";
            string s = @"select service.active, service.idser,service.codeser, service.description, service.rec770kind, motive770service.idmot, 
                        service.module, service.certificatekind, certificate=certificationmodel.description,
                        cisonoritfiscali=case when exists (select * from servicetax join tax on service.idser=servicetax.idser and servicetax.taxcode=tax.taxcode and taxkind=1) then 'S' else 'N' end
                        from service
                        left outer join motive770service on service.idser=motive770service.idser and motive770service.ayear="
                        +esercizio
                        +@" left outer join certificationmodel on service.certificatekind=certificationmodel.idcertificationmodel
                        where "+filtroPrestazioni;
            return DataAccess.SQLRunner(Meta.Conn, s);
        }

        private DataTable getPercipientiParasubordinatiRecG() {
            int esercizio = (int)Meta.GetSys("esercizio");
	        string query = "SELECT " +			
		    "co.idreg, " +
		    "registry.title, " + 
		    "co.ycon, " +
		    "co.ncon, " +
		    "service.codeser, " +
		    "service.description, " +
		    "im.stopcompetency " + 
	        "FROM  payroll ce " +
	        "JOIN parasubcontract co ON co.idcon = ce.idcon " +
                "JOIN parasubcontractyear im ON co.idcon = im.idcon " + 
                "AND im.ayear =  " + (esercizio - 1) +
	        "JOIN service on service.idser = co.idser " +
	        "JOIN registry ON co.idreg = registry.idreg " +
	        "WHERE ce.flagbalance = 'S' " +
	        "AND ce.fiscalyear= " + (esercizio - 1) + 
	        "AND NOT EXISTS (SELECT idlinkedcon FROM exhibitedcud " +
			        "WHERE idlinkedcon = ce.idcon and " +
                    "exhibitedcud.fiscalyear = " +  (esercizio - 1) + ") " +
	        "AND EXISTS (SELECT payroll.idpayroll FROM payroll " +
			        "JOIN expensepayroll ON payroll.idpayroll = expensepayroll.idpayroll " +
			        "JOIN expenselink ON expenselink.idparent = expensepayroll.idexp " +
			        "JOIN expenselast ON expenselast.idexp = expenselink.idchild " +
			        "JOIN payment ON payment.kpay=expenselast.kpay " +
			        "WHERE payroll.idcon =  " + 
			        "co.idcon and payment.kpaymenttransmission IS NOT NULL) " +
	        "AND service.rec770kind='G' ";

            DataTable t = DataAccess.SQLRunner(Meta.Conn, query);
            return t;
        }

         private DataTable getAltriPercipientiRecG() {
            int esercizio = (int)Meta.GetSys("esercizio");
            DateTime TrediciGennAnnoRedditi = new DateTime(esercizio -1, 1, 13);
            DateTime DodiciGennAnnoDichiar = new DateTime(esercizio, 1, 12);
            QueryHelper QHS = Meta.Conn.GetQueryHelper();
	        string query = " SELECT " +
	                "expense.idreg, " +
	                "registry.title, " +
	                "service.codeser, " +
	                "service.description, " +
	                "expense.idexp, " + 
	                (esercizio -1) + "as ymov," + 
	                "expense.nmov " +
	                "FROM expense " +
	                "JOIN expenseyear " +
		                "ON expenseyear.idexp = expense.idexp " +
	                "JOIN expenselast " +
		                "ON expense.idexp = expenselast.idexp " +
	                "JOIN service " +
		                "ON service.idser=expenselast.idser " +
	                "JOIN registry " +
		                "ON expense.idreg = registry.idreg " +
	                "JOIN payment " +
		                "ON payment.kpay=expenselast.kpay " +
	                "JOIN paymenttransmission  "+
		                "ON paymenttransmission.kpaymenttransmission= " +
		                "payment.kpaymenttransmission " +
                    "WHERE transmissiondate BETWEEN  " + QHS.quote(TrediciGennAnnoRedditi) + 
                        " AND " + QHS.quote(DodiciGennAnnoDichiar) +
			            "AND registry.idregistryclass <> '10' " +
			            "AND NOT EXISTS(SELECT * FROM registryrole " +
				                   "WHERE idrole = '16' AND registryrole.idreg = expense.idreg) " +
			            "AND service.rec770kind='G' " +
			            "AND (expenseyear.amount " +
				            "+ ISNULL( " + 
					            "(SELECT SUM(amount) FROM expensevar " +
					            "WHERE expensevar.idexp = expense.idexp " +
					            "AND expensevar.yvar <= " + (esercizio -1) +
					            "AND ISNULL(autokind,0) <> 4)" +
				            ",0)) > 0 " +
			            "AND NOT EXISTS (select * from expensepayroll " +
			            "JOIN expenselink " +
				            "ON expenselink.idparent = expensepayroll.idexp " +
				            "JOIN expensetax " +
				            "ON expense.idexp = expensetax.idexp " +
			            "WHERE expensetax.idexp = expenselink.idchild) ";

                    DataTable t = DataAccess.SQLRunner(Meta.Conn, query);
                
                    return t;
        }

        private DataTable getPercipientiRecH() {
            int esercizio = (int)Meta.GetSys("esercizio");
            string query = "SELECT " +
		        "expense.idreg, " +
		        "registry.title, " +
		        "service.codeser, " +
		        "service.description, " +
		        "expense.idexp, " +
		        (esercizio -1) + "as ymov," +
		        "expense.nmov " +
		        "FROM expense " +
		        "JOIN expenselast on expense.idexp = expenselast.idexp " +
		        "JOIN payment " +
			        "ON payment.kpay = expenselast.kpay " +
		        "JOIN paymenttransmission " +
			        "ON paymenttransmission.kpaymenttransmission = " +
			        "payment.kpaymenttransmission " +
		        "JOIN service on service.idser=expenselast.idser " +
		        "JOIN registry ON expense.idreg = registry.idreg " +
		        "WHERE registry.idregistryclass <> '10' " +
			        "AND NOT EXISTS(SELECT * FROM registryrole " +
			        "WHERE idrole = '16' AND registryrole.idreg = expense.idreg) " +
			        "AND YEAR(paymenttransmission.transmissiondate)= " + (esercizio -1) +
			        "AND service.rec770kind = 'H' " +
			        "AND ((SELECT expenseyear.amount from expenseyear  " +
			        "where expenseyear.idexp = expenselast.idexp) " +
			        "+ ISNULL( " +
				        "(SELECT SUM(amount) FROM expensevar " +
				        "WHERE expensevar.idexp = expense.idexp " +
				        "AND expensevar.yvar <= " + (esercizio -1) +
				        "AND ISNULL(autokind,0) <> 4) " + 
			        ",0)) > 0 " +
			        "AND (SELECT count(*) from expensetax " +
			              "WHERE expensetax.idexp=expense.idexp) > 0";

            DataTable t = DataAccess.SQLRunner(Meta.Conn, query);

            return t;
        }

        private bool verificaDomFiscaleNonResidenti (int idreg, DateTime date) {
        // Se il percipiente è non residente si verifica che alla 
	    // data di riferimento esista almeno un domicilio fiscale in Italia
            if (date == QueryCreator.EmptyDate()) return false;
	        QueryHelper QHS = Meta.Conn.GetQueryHelper();
            // Verifico esistenza di una residenza all'estero alla data di riferimento
            object idDomFiscale = Meta.Conn.DO_READ_VALUE("address", 
                                  QHS.CmpEq("codeaddress", "07_SW_DOM"), "idaddress");
            object idResidenza  = Meta.Conn.DO_READ_VALUE("address", 
                                  QHS.CmpEq("codeaddress", "07_SW_DEF"), "idaddress");

            string filter = QHS.AppAnd(QHS.CmpEq("idreg", idreg), 
				       QHS.CmpEq("idaddresskind", idResidenza), 
				       QHS.CmpEq("ISNULL(flagforeign, 'N')",'S'),
                       "(" + QHS.quote(date) + " BETWEEN start AND ISNULL(stop," + 
				       QHS.quote(date) + "))");
            
	        object idNation = Meta.Conn.DO_READ_VALUE("registryaddress", filter, "idnation");
            if ((idNation != DBNull.Value) && (idNation != null)) {
                // In presenza di un indirizzo di residenza estero verifico l''esistenza  
		        // di un domicilio fiscale in Italia alla data di riferimento
                    filter = QHS.AppAnd(QHS.CmpEq("idreg", idreg), 
				        QHS.CmpEq("idaddresskind", idDomFiscale),
				        QHS.CmpEq("ISNULL(flagforeign, 'N')",'N'),
                        "(" + QHS.quote(date) + " BETWEEN start AND ISNULL(stop," + 
				        QHS.quote(date) + "))");
		        object idCity = Meta.Conn.DO_READ_VALUE("registryaddress", filter, "idcity");
                if ((idCity == DBNull.Value) || (idCity == null)) {
            	        return false;
        	    }
            }
	        return true;
        }

        private DataTable controllaNonResidentiRecordG() {
	        int esercizio = (int)Meta.GetSys("esercizio");
            DateTime PrimoGennAnnoRedditi = new DateTime(esercizio -1, 1, 1);
            DateTime TrentunoDicAnnoRedditi = new DateTime(esercizio -1, 12, 31);
            DateTime PrimoGennAnnoDichiar = new DateTime(esercizio, 1, 1);
        
	        DataTable t = getPercipientiParasubordinatiRecG();
            DataTable z = new DataTable();
            // ATTENZIONE. Rivedere i tipi del datatable z e controllare se t contiene righe
	        z.Columns.Add("Tipo Contratto");
            z.Columns.Add("Cod. Percipiente", typeof(System.Int32));
            z.Columns.Add("Percipiente", typeof(System.String));
            z.Columns.Add("Eserc. Contratto / Pagamento", typeof(System.Int32));
            z.Columns.Add("Num. Contratto / Pagamento", typeof(System.Int32));
            z.Columns.Add("Cod. Prestazione", typeof(System.String));
            z.Columns.Add("Prestazione", typeof(System.String));
            z.Columns.Add("Problema");
            z.Columns.Add("Data Riferimento", typeof(System.DateTime));
            if (t != null) {
                // Controllo sui percipienti dei contratti parasubordinati
                foreach (DataRow r in t.Rows) {
                    int idreg = CfgFn.GetNoNullInt32(r["idreg"]);
                    if (!verificaDomFiscaleNonResidenti(idreg, PrimoGennAnnoRedditi)) {
                        z.Rows.Add("Parasubordinati", r["idreg"], r["title"],
                                   r["ycon"], r["ncon"], r["codeser"], r["description"],
                                   "Non ha un domicilio fiscale in Italia valido alla data",
                                   PrimoGennAnnoRedditi);
                    }

                    DateTime fineContratto = (DateTime)r["stopcompetency"];

                    if (!verificaDomFiscaleNonResidenti(idreg, fineContratto)) {
                        z.Rows.Add("Parasubordinati", r["idreg"], r["title"],
                                   r["ycon"], r["ncon"], r["codeser"], r["description"],
                                   "Non ha un domicilio fiscale in Italia valido a fine contratto/fine anno",
                                   r["stopcompetency"]);
                    }

                    if (!verificaDomFiscaleNonResidenti(idreg, PrimoGennAnnoDichiar)) {
                        z.Rows.Add("Parasubordinati", r["idreg"], r["title"],
                                   r["ycon"], r["ncon"], r["codeser"], r["description"],
                                   "Non ha un domicilio fiscale in Italia valido alla data",
                                   PrimoGennAnnoDichiar);
                    }
                }
            }
	        // Controllo sui percipienti di contratti diversi da parasubordinati 
	        // da includere nel RECORD G
            DataTable t1 = getAltriPercipientiRecG();
            if (t1 == null) return z;
            foreach (DataRow r in t1.Rows) {
                int idreg = CfgFn.GetNoNullInt32(r["idreg"]);
		        if  (!verificaDomFiscaleNonResidenti(idreg,PrimoGennAnnoRedditi)){
			        z.Rows.Add("Altri Pagamenti record G", r["idreg"], r["title"], 
	                           r["ymov"], r["nmov"],r["codeser"], r["description"],
                               "Non ha un domicilio fiscale in Italia valido alla data", 
				               PrimoGennAnnoRedditi);
	            }
		
		        if  (!verificaDomFiscaleNonResidenti(idreg,TrentunoDicAnnoRedditi)){
			        z.Rows.Add("Altri Pagamenti record G", r["idreg"], r["title"], 
	                           r["ymov"], r["nmov"],r["codeser"], r["description"],
                               "Non ha un domicilio fiscale in Italia valido alla data", 
				               TrentunoDicAnnoRedditi);
	            }
                
                if  (!verificaDomFiscaleNonResidenti(idreg, PrimoGennAnnoDichiar)){
			        z.Rows.Add("Altri Pagamenti record G", r["idreg"], r["title"], 
	                           r["ymov"], r["nmov"],r["codeser"], r["description"],
                               "Non ha un domicilio fiscale in Italia  valido alla data", 
				               PrimoGennAnnoDichiar);
	            }    
            }
            return z;
	    }

        private DataTable controllaNonResidentiRecordH () {
            // Ricontrollare in base ai dati estratti dalla query
            int esercizio = (int)Meta.GetSys("esercizio");
            DateTime PrimoGennAnnoDichiarazione = new DateTime(esercizio, 1, 1);

            DataTable t = getPercipientiRecH();
            DataTable z = new DataTable();
            // ATTENZIONE. Rivedere i tipi del datatable z e controllare se t contiene righe
            z.Columns.Add("Tipo Contratto");
            z.Columns.Add("Cod. Percipiente", typeof(System.Int32));
            z.Columns.Add("Percipiente", typeof(System.String));
            z.Columns.Add("Eserc. Pagamento", typeof(System.Int32));
            z.Columns.Add("Num. Pagamento", typeof(System.Int32));
            z.Columns.Add("Cod. Prestazione", typeof(System.String));
            z.Columns.Add("Prestazione", typeof(System.String));
            z.Columns.Add("Problema");
            z.Columns.Add("Data Riferimento", typeof(System.DateTime));

            if (t == null) return z;
            foreach (DataRow r in t.Rows) {
                int idreg = CfgFn.GetNoNullInt32(r["idreg"]);
                if (!verificaDomFiscaleNonResidenti(idreg, PrimoGennAnnoDichiarazione))
                {
                    z.Rows.Add("Pagamenti record H", r["idreg"], r["title"],
                               r["ymov"], r["nmov"], r["codeser"], r["description"],
                               "Non ha un domicilio fiscale in Italia valido alla data",
                               PrimoGennAnnoDichiarazione);
                }
            }
            return z;
        }

        private DataTable controllaConsiderandoSoloRecordH() {
            //DataTable tPrestUff = getPrestazioniUfficiali();
            DataTable t = getConfigurazionePrestazioni();
            DataTable z = new DataTable();
            z.Columns.Add("Attiva", t.Columns["active"].DataType);
            z.Columns.Add("Codice prestazione", t.Columns["idser"].DataType);
            z.Columns.Add("Prestazione", t.Columns["description"].DataType);
            z.Columns.Add("Record 770", t.Columns["rec770kind"].DataType);
            z.Columns.Add("Causale", t.Columns["idmot"].DataType);
            z.Columns.Add("Modulo", t.Columns["module"].DataType);
            z.Columns.Add("Certificazione", t.Columns["certificate"].DataType);
            z.Columns.Add("Ritenute fiscali", typeof(string));
            z.Columns.Add("Problema");
            foreach (DataRow r in t.Rows) {
                string rec770kind = r["rec770kind"].ToString().ToUpper();
                string idmot = r["idmot"].ToString().ToUpper();
                string module = r["module"].ToString().ToUpper();
                string certificatekind = r["certificatekind"].ToString().ToUpper();
                string ciSonoRitFiscali = (string)r["cisonoritfiscali"];
                string codeser = r["codeser"].ToString();

                //if (rec770kind == "G") {
                //    z.Rows.Add(r["active"], r["idser"], r["description"], r["rec770kind"], r["idmot"], r["module"], r["certificate"], r["cisonoritfiscali"],
                //    "Se si vuole generare solo il record H allora il record770 non può essere G");
                //}

                    if ((rec770kind == "H") && ((module != "OCCASIONALE") && (module != "PROFESSIONALE") ||
                    (idmot != "A") && (idmot != "M") && (idmot != "B") || (certificatekind == "U"))) {
                    z.Rows.Add(r["active"], r["idser"], r["description"], r["rec770kind"], 
                                r["idmot"], r["module"], r["certificate"], r["cisonoritfiscali"],
                    "Se il record770 è H allora il modulo deve essere occasionale o professionale, " +
                    "la causale deve essere A o M o B e non si deve usare il modello CUD");
                }
                if ((idmot == "A") && ((module != "PROFESSIONALE") || (rec770kind != "H") || (certificatekind == "U"))) {
                    z.Rows.Add(r["active"], r["idser"], r["description"], r["rec770kind"], 
                                r["idmot"], r["module"], r["certificate"], r["cisonoritfiscali"],
                    "Se la causale è A allora il record770 deve essere H, il modulo  " +
                    "deve essere PROFESSIONALE e non si deve usare il modello CUD");
                }

                if ((codeser == "07_DAT_I") && ((module != "PROFESSIONALE") || 
                    (rec770kind != "H") || (certificatekind == "U"))) {
                    z.Rows.Add(r["active"], r["idser"], r["description"], r["rec770kind"], 
                                r["idmot"], r["module"], r["certificate"], r["cisonoritfiscali"],
                    "Per i 'Diritti d'autore per titolari di part. IVA' il record770 deve essere H, " +
                    "il modulo deve essere PROFESSIONALE e non si deve usare il modello CUD");
                }

                if ((idmot == "B") && (codeser != "07_DAT_I") && ((module != "OCCASIONALE") || 
                    (rec770kind != "H") || (certificatekind == "U"))) {
                    z.Rows.Add(r["active"], r["idser"], r["description"], r["rec770kind"], 
                                r["idmot"], r["module"], r["certificate"], r["cisonoritfiscali"],
                    "Per i 'Diritti d'autore senza part. IVA' il record770 deve essere H, " +
                    "il modulo deve essere OCCASIONALE e non si deve usare il modello CUD");
                }
                if ((idmot == "M") && ((module != "OCCASIONALE") || (
                        rec770kind != "H") || (certificatekind == "U"))) {
                    z.Rows.Add(r["active"], r["idser"], r["description"], r["rec770kind"], 
                                r["idmot"], r["module"], r["certificate"], r["cisonoritfiscali"],
                    "Se la causale è M allora il record770 deve essere H, " + 
                    "il modulo deve essere OCCASIONALE e non si deve usare il modello CUD");
                }
                if ((module == "PROFESSIONALE") && (codeser != "07_DAT_I") && ((rec770kind != "H") ||
                        (idmot != "A") || (certificatekind == "U"))) {
                    z.Rows.Add(r["active"], r["idser"], r["description"], r["rec770kind"], 
                                r["idmot"], r["module"], r["certificate"], r["cisonoritfiscali"],
                    "Se il modulo è PROFESSIONALE (e non si tratta di Diritti d'Autore per titolari di partita IVA) " +
                    "allora il record770 deve essere H, la causale deve essere A e non si deve usare il modello CUD");
                }
                if ((module == "OCCASIONALE") && ((rec770kind != "H") || (idmot != "M") && (idmot != "B") ||
                    (certificatekind == "U"))) {
                    z.Rows.Add(r["active"], r["idser"], r["description"], r["rec770kind"],
                                r["idmot"], r["module"], r["certificate"], r["cisonoritfiscali"],
                    "Se il modulo è OCCASIONALE allora il record770 deve essere H, " +
                    "la causale deve essere M o B e non si deve usare il modello CUD");
                }
                   
                if ((certificatekind == "U") && ((rec770kind == "H") ||
                    (module != "COCOCO") && (module != "DIPENDENTE") || (idmot != ""))) {
                    z.Rows.Add(r["active"], r["idser"], r["description"], r["rec770kind"], 
                                r["idmot"], r["module"], r["certificate"], r["cisonoritfiscali"],
                    "Se si usa il modello CUD allora il record770 deve essere G e " +
                    "il modulo deve essere COCOCO o DIPENDENTE e la causale deve essere vuota");
                }
            }
            return z;
        }
        private bool stessoRecord(object rec1, object rec2) {
            string r1 = rec1.ToString();
            string r2 = rec1.ToString();
            if ((r1 == "G") && (r2 == "G")) return true;
            if ((r1 == "H") && (r2 == "H")) return true;
            if ((r1 != "G") && (r1 != "H") && ((r2 == "G") || (r2 == "H"))) return false;
            if (((r1 == "G") || (r1 == "H")) && (r2 != "G") && (r2 != "H")) return false;
            return false;
        }

        private DataTable controlloCompleto() {
            //DataTable tPrestUff = getPrestazioniUfficiali();
            DataTable t = getConfigurazionePrestazioni();
            DataTable z = new DataTable();
            z.Columns.Add("Attiva", t.Columns["active"].DataType);
            z.Columns.Add("Codice prestazione", t.Columns["idser"].DataType);
            z.Columns.Add("Prestazione", t.Columns["description"].DataType);
            z.Columns.Add("Record 770", t.Columns["rec770kind"].DataType);
            z.Columns.Add("Causale", t.Columns["idmot"].DataType);
            z.Columns.Add("Modulo", t.Columns["module"].DataType);
            z.Columns.Add("Certificazione", t.Columns["certificate"].DataType);
            z.Columns.Add("Ritenute fiscali", typeof(string));
            z.Columns.Add("Problema");
            foreach (DataRow r in t.Rows) {
                string rec770kind = r["rec770kind"].ToString().ToUpper();
                string idmot = r["idmot"].ToString().ToUpper();
              
                    string module = r["module"].ToString().ToUpper();
                    string certificatekind = r["certificatekind"].ToString().ToUpper();
                    string ciSonoRitFiscali = (string)r["cisonoritfiscali"];
                    string codeser = r["codeser"].ToString();

                    if ((rec770kind == "G") && (((module != "COCOCO") && (module != "DIPENDENTE")) || (idmot != ""))) {
                        z.Rows.Add(r["active"], r["idser"], r["description"],
                                   r["rec770kind"], r["idmot"], r["module"], r["certificate"],
                                   r["cisonoritfiscali"],
                        "Se il record770 è G allora il modulo deve essere COCOCO o DIPENDENTE e " +
                        "non ci deve essere la causale ");
                    }

                    if ((rec770kind == "H") && ((module != "OCCASIONALE") && (module != "PROFESSIONALE") ||
                        (idmot != "A") && (idmot != "M") && (idmot != "B") || (certificatekind == "U"))) {
                        z.Rows.Add(r["active"], r["idser"], r["description"], r["rec770kind"], 
                                   r["idmot"], r["module"], r["certificate"], r["cisonoritfiscali"],
                        "Se il record770 è H allora il modulo deve essere OCCASIONALE o PROFESSIONALE, " +
                        "la causale deve essere A, M o B e non si deve usare il modello CUD");
                    }
                    if ((idmot == "A") && ((module != "PROFESSIONALE") || (rec770kind != "H") ||
                        (certificatekind == "U"))) {
                        z.Rows.Add(r["active"], r["idser"], r["description"], r["rec770kind"],
                                   r["idmot"], r["module"], r["certificate"], r["cisonoritfiscali"],
                        "Se la causale è A allora il record770 deve essere H,  " +
                        "il modulo deve essere PROFESSIONALE e non si deve usare il modello CUD");
                    }
                    if ((codeser == "07_DAT_I") && ((module != "PROFESSIONALE") || (idmot != "B") ||
                        (rec770kind != "H") || (certificatekind == "U"))) {
                        z.Rows.Add(r["active"], r["idser"], r["description"], r["rec770kind"], 
                                   r["idmot"], r["module"], r["certificate"], r["cisonoritfiscali"],
                        "Per i 'Diritti d'autore per titolari part. IVA' il record770 deve essere H, " +
                        "il modulo deve essere PROFESSIONALE e non si deve usare il modello CUD");
                    }
                    if ((idmot == "B") && (codeser != "07_DAT_I") && ((module != "OCCASIONALE") || 
                        (rec770kind != "H") || (certificatekind == "U"))) {
                        z.Rows.Add(r["active"], r["idser"], r["description"], r["rec770kind"], 
                                   r["idmot"], r["module"], r["certificate"], r["cisonoritfiscali"],
                        "Per i 'Diritti d'autore senza part. IVA' il record770 deve essere H, " +
                        "il modulo deve essere  OCCASIONALE e non si deve usare il modello CUD");
                    }
                    if ((idmot == "M") && ((module != "OCCASIONALE") || (rec770kind != "H") || 
                        (certificatekind == "U"))) {
                        z.Rows.Add(r["active"], r["idser"], r["description"], r["rec770kind"], 
                                   r["idmot"], r["module"], r["certificate"], r["cisonoritfiscali"],
                        "Se la causale è M allora il record770 deve essere H, il modulo deve essere " +
                        "OCCASIONALE e non si deve usare il modello CUD");
                    }
                    if ((module == "PROFESSIONALE") && (codeser != "07_DAT_I") && ((rec770kind != "H") ||
                        (idmot != "A")  || (certificatekind == "U"))) {
                        z.Rows.Add(r["active"], r["idser"], r["description"], r["rec770kind"], 
                                   r["idmot"], r["module"], r["certificate"], r["cisonoritfiscali"],
                        "Se il modulo è PROFESSIONALE e non si tratta di  'Diritti d'autore per titolari part. IVA' " +
                        "allora il record770 deve essere H, " +
                        "la causale deve essere A e non si deve usare il modello CUD");
                    }

                    if ((module == "OCCASIONALE") && ((rec770kind != "H") || 
                        (idmot != "M") && (idmot!="B") || 
                        (certificatekind == "U"))) {
                        z.Rows.Add(r["active"], r["idser"], r["description"], r["rec770kind"], 
                                   r["idmot"], r["module"], r["certificate"], r["cisonoritfiscali"],
                        "Se il modulo è OCCASIONALE allora il record770 deve essere H, " +
                        "la causale deve essere M oppure B " +
                        "e non si deve usare il modello CUD");
                    }
                  
                    if ((certificatekind == "U") && ((rec770kind != "G") || 
                        (module != "COCOCO") && (module != "DIPENDENTE") || (idmot != ""))) {
                        z.Rows.Add(r["active"], r["idser"], r["description"], r["rec770kind"], 
                                   r["idmot"], r["module"], r["certificate"], r["cisonoritfiscali"],
                        "Se si usa il modello CUD allora il record770 deve essere G, "+
                        "il modulo deve essere COCOCO o DIPENDENTE e la causale deve essere vuota ");
                    }

                    if ((module == "DIPENDENTE") && (codeser == "08_PREMI")) {
                        z.Rows.Add(r["active"], r["idser"], r["description"], r["rec770kind"],
                                   r["idmot"], r["module"], r["certificate"], r["cisonoritfiscali"],
                        "Per 'Premi di studio e altri premi (art. 69 del TUIR)' " +
                        "non deve essere presentato il modello 770 SEMPLIFICATO, ma quello ORDINARIO");
                    }
            }
            return z;
        }

        private void buttonIncoerenze_Click(object sender, EventArgs e) {
            DataTable z = controlloCompleto();
            if (z.Rows.Count == 0) {
                show(this, "Non ci sono problemi di configurazione delle prestazioni");
            }
            exportclass.DataTableToExcel(z, true);
        }

        private void buttonProblemiH_Click(object sender, EventArgs e) {
            DataTable z = controllaConsiderandoSoloRecordH();
            if (z.Rows.Count == 0) {
                show(this, "Non ci sono problemi di configurazione delle prestazioni per quanto riguarda il record H");
            }
            exportclass.DataTableToExcel(z, true);
        }

        private void generaIlModello770(bool soloRecordH, bool salvaSuFile, bool stampa) {
            object CF = DBNull.Value;
            if (txtCF.Text.Trim() != "") {
                CF = txtCF.Text.Trim();
            }
            Cursor = Cursors.WaitCursor;
            string esercizio = ((int)Meta.GetSys("esercizio") % 100).ToString();
            if (esercizio.Length < 2) {
                esercizio = "0" + esercizio;
            }
            string errMsg;
            object[] parametriA = new object[] {};
            DataSet ds_RecordA = Meta.Conn.CallSP("exp_certificazioneunica_a_" + esercizio, parametriA, 60 * 60, out errMsg);
            if (ds_RecordA == null)
            {
                show(this, "Si è verificato il seguente errore nel calcolo del Record A della  certificazione unica:"
                    + "\n" + errMsg + "\nRiprovare o chiamare l'ASSISTENZA");
                Cursor = null;
                return;
            }

            DataSet ds = new DataSet();
            DataTable tRecordA = ds_RecordA.Tables[0];
        
            ds.Merge(tRecordA);

            int nRecordH = 0;
            int nRecordG = 0;
            object[] parametriH = new object[] {CF }; 
            if (soloRecordH)
            {
                DataSet ds1 = Meta.Conn.CallSP("exp_certificazioneunica_percipienti_h_" + esercizio, parametriH, 60 * 60, out errMsg);
                if (ds1 == null)
                {
                    show(this, "Si è verificato il seguente errore nel calcolo dei percipienti della  certificazione unica record H:"
                        + "\n" + errMsg + "\nRiprovare o chiamare l'ASSISTENZA");
                    Cursor = null;
                    return;
                }

                DataTable tPercipientiRecordH = ds1.Tables[0];

                int newProgrCom;
                newProgrCom = 0;
                int progrCom;
                progrCom = 1;
                foreach (DataRow r in tPercipientiRecordH.Select())
                {
                    progrCom = progrCom + newProgrCom;

                    // CallSPParameterDataSet(string sp_name, string[] ParamName, SqlDbType[] ParamType, 
                    //int[] ParamTypeLength, ParameterDirection[] ParamDirection, ref object[] ParamValues,
                    //int timeout, out string ErrMsg){

                    string print = "N";
                    if (stampa) {
                        print = "S";
                    }
                    string[] param = new string[] { "@idreg", "@progrCom","@print", "@newprogrCom" };
                    SqlDbType[] types = new SqlDbType[] { SqlDbType.Int, SqlDbType.Int, SqlDbType.VarChar, SqlDbType.Int, };
                    int[] typelen = new int[] { 4, 4, 4, 4 };
                    ParameterDirection[] dir = new ParameterDirection[] { ParameterDirection.Input, ParameterDirection.Input, ParameterDirection.Input, ParameterDirection.Output };

                    object[] paramvalues = new object[] { r["idreg"], progrCom, print, newProgrCom };
                    //DataSet ds2 = Meta.Conn.CallSP("exp_certificazioneunica_h_" + esercizio, parametri, 60 * 60, out errMsg);
                    DataSet ds2 = Meta.Conn.CallSPParameterDataSet("exp_certificazioneunica_h_" + esercizio, param, types,
                    typelen, dir, ref paramvalues, 60 * 60, out errMsg);
                    newProgrCom = CfgFn.GetNoNullInt32(paramvalues[3]);

                    if (ds2 == null)
                    {
                        show(this, "Si è verificato il seguente errore nel calcolo del Record D-H della  certificazione unica:"
                            + "\n" + errMsg + "\nRiprovare o chiamare l'ASSISTENZA");
                        Cursor = null;
                        return;
                    }

                    DataTable tPercipienteRecordH = ds2.Tables[0];
                    //ds.Merge(tPercipienteRecordD);
                    ds.Merge(tPercipienteRecordH);
                }
            }

            else
            {
                object[] parametriG = new object[] { CF };
                DataSet ds3 = Meta.Conn.CallSP("exp_certificazioneunica_percipienti_g_" + esercizio, parametriG, 60 * 60, out errMsg);
                if (ds3 == null)
                {
                    show(this, "Si è verificato il seguente errore nel calcolo dei percipienti della  certificazione unica Record G:"
                        + "\n" + errMsg + "\nRiprovare o chiamare l'ASSISTENZA");
                    Cursor = null;
                    return;
                }

                string print = "N";
                if (stampa) {
                    print = "S";
                }
                DataTable tPercipientiRecordG = ds3.Tables[0];
                foreach (DataRow r in tPercipientiRecordG.Select())
                {
                    object[] paramvalues = new object[] { r["idreg"], r["progrCom"], print};
                    DataSet ds2 = Meta.Conn.CallSP("exp_certificazioneunica_g_" + esercizio, paramvalues, 60 * 60, out errMsg);
                    if (ds2 == null)
                    {
                        show(this, "Si è verificato il seguente errore nel calcolo della  certificazione unica Record D-G:"
                            + "\n" + errMsg + "\nRiprovare o chiamare l'ASSISTENZA");
                        Cursor = null;
                        return;
                    }
                    DataTable tPercipienteRecordG = ds2.Tables[0];
                    DataRow rCf = tPercipienteRecordG.Select(QHC.AppAnd(QHC.CmpEq("quadro","HRG"),QHC.CmpEq("colonna","04")))[0];
                    string currentCF = rCf["stringa"].ToString();
                    if (progressiviHRD06.ContainsKey(currentCF)) {
                        DataRow rr = tPercipienteRecordG.NewRow();
                        rr["progr"] = r["progrCom"];
                        rr["modulo"] = 1;
                        rr["quadro"] = "HRD";
                        rr["riga"] = 1;
                        rr["colonna"] = "06";
                        rr["stringa"] = progressiviHRD06[currentCF].ToString().PadLeft(17, '0');
                        tPercipienteRecordG.Rows.Add(rr);

                        rr = tPercipienteRecordG.NewRow();
                        rr["progr"] = r["progrCom"];
                        rr["modulo"] = 1;
                        rr["quadro"] = "HRD";
                        rr["riga"] = 1;
                        rr["colonna"] = "07";
                        rr["stringa"] = progressiviHRD07[currentCF].ToString().PadLeft(6, '0');
                        tPercipienteRecordG.Rows.Add(rr);

                        rr = tPercipienteRecordG.NewRow();
                        rr["progr"] = r["progrCom"];
                        rr["modulo"] = 1;
                        rr["quadro"] = "HRD";
                        rr["riga"] = 1;
                        rr["colonna"] = "09";
                        rr["stringa"] = "S";
                        tPercipienteRecordG.Rows.Add(rr);
                    }
                    else {
                        if (progressiviHRD06.Count > 0) {
                            show("Il codice fiscale " + currentCF + " non è stato trovato nello schema importato", "Errore");
                        }
                    }

                    //ds.Merge(tPercipienteRecordD);
                    ds.Merge(tPercipienteRecordG);                
                }
            }
           
            // Calcolo il numero delle comunicaizoni G o H inviate da inserire in record B
            DataRow[] rD = ds.Tables[0].Select("(quadro='HRD')and(colonna='05')");
            if (soloRecordH)
            {
                nRecordG = 0;
                nRecordH = rD.Length;
            }
            else
            {
                nRecordH = 0;
                nRecordG = rD.Length;
            }

            
            object [] parametriGH = new object[] { nRecordG, nRecordH };
            DataSet ds_RecordB = Meta.Conn.CallSP("exp_certificazioneunica_b_" + esercizio, parametriGH, 60 * 60, out errMsg);
            if (ds_RecordB == null)
            {
                show(this, "Si è verificato il seguente errore nel calcolo del Record B della  certificazione unica:"
                    + "\n" + errMsg + "\nRiprovare o chiamare l'ASSISTENZA");
                Cursor = null;
                return;
            }

 
            DataTable tRecordB = ds_RecordB.Tables[0];

            if (progressiviHRD06.Count> 0) 
            {
                // INSERT INTO #recordb (progr, modulo, quadro, riga, colonna, intero) VALUES(1, 1,'HRB', 1, '010',0)
                // 10 Fornitura relativa all'invio di  certificazioni da annullare
               
                DataRow   row = tRecordB.NewRow();
                row["progr"] = 1;
                row["modulo"] = 1;
                row["quadro"] = "HRB";
                row["riga"] = 1;
                row["colonna"] = "010";
                row["intero"] = 0;
                tRecordB.Rows.Add(row);

                // INSERT INTO #recordb (progr, modulo, quadro, riga, colonna, intero) VALUES(1, 1,'HRB', 1, '011',1)
                // 11 Fornitura relativa all'invio di certificazioni da sostituire
 
                DataRow row1 = tRecordB.NewRow();
                row1["progr"] = 1;
                row1["modulo"] = 1;
                row1["quadro"] = "HRB";
                row1["riga"] = 1;
                row1["colonna"] = "011";
                row1["intero"] = 1;

                tRecordB.Rows.Add(row1);
            }

            ds.Merge(tRecordB);
            tMod770 = ds.Tables[0];
            HelpForm.SetDataGrid(dataGrid, tMod770);

            foreach (DataRow r in ds.Tables[0].Select())
            {
                string filtro = "frame='" + r["quadro"] + "' and colnumber='" + r["colonna"] + "'";
                if (r["quadro"].ToString() == "IND") {
                    // IND sono le righe dell'indirizzo per la stampa con pagina bianca
                    continue;
                }
                
                
                if (r["quadro"].ToString() == "NN") {
                    // NN sono le note, aggiunte solo per la stampa
                    continue;
                }

                DataRow[] rFormato = DS.mod770_details.Select(filtro);
                if (rFormato.Length != 1)
                {
                    show(this, "Formato sconosciuto: " + filtro);
                    Cursor = null;
                    return;
                }

                if (stampa && rFormato[0]["format"].ToString() == "CB") {
                    if (r["stringa"].ToString() == "" && r["intero"].ToString() != "") {
                        string old = r["stringa"].ToString();
                        r["stringa"] = DBNull.Value;
                        r["intero"] = DBNull.Value;
                        if (old == "1") {
                            r["stringa"] = "X";
                        }
                        else {
                            r["stringa"] = " ";
                        }
                    }
                }
            }

            Cursor = null;

            if (salvaSuFile) {
                TextWriter tw = getStreamWriter();
                if (tw == null) {
                    return;
                }
                salvaCertificazioneUnica(tw, ds, soloRecordH);
            }
            if (stampa) {
                if (soloRecordH) {
                    GeneraXMLPerStampa("H");
                }
                else {
                    GeneraXMLPerStampa("G");
                }
            }
        }

        private void buttonGenera770recordH_Click(object sender, EventArgs e) {
            //if (!verificaContrattiNonPagati()) return;
            //if (!verificaPrestazioniCertificazioniCUD()) return;
            //if (!verificaPrestazioniCertificazioniInNonCUD()) return;
            //if (!verificaPrestazioniCertificazioniNonCUD()) return;
            if (!verificaPrestazioniSenzaCausale()) return;
            verificaPresenzaProvvigioni();
            generaIlModello770(true, true,false);
        }

        private void btnNonResidG_Click (object sender, EventArgs e) {
            DataTable z = controllaNonResidentiRecordG();
            if (z.Rows.Count == 0) {
                show(this, "Non ci sono non residenti con domicilio fiscale non valido (G)");
            }
            exportclass.DataTableToExcel(z, true);
        }

        private void btnNonResidH_Click (object sender, EventArgs e) {
            DataTable z = controllaNonResidentiRecordH();
            if (z.Rows.Count == 0) {
                show(this, "Non ci sono non residenti con domicilio fiscale non valido (H)");
            }
            exportclass.DataTableToExcel(z, true);
        }

        private void buttonLegendaI_Click(object sender, EventArgs e)
        {
            visualizzaLegenda("frame in ('SY001','SY002','SY003','SY004','SY005','SY006')");
        }

        private void buttonRecordI_Click(object sender, EventArgs e)
        {
            visualizzaQuadroInExcel("I");
        }

        private void btnLegendaA_Click(object sender, EventArgs e)
        {
            visualizzaLegenda("frame = 'HRA'");
        }

        private void btnLegendaB_Click(object sender, EventArgs e)
        {
            visualizzaLegenda("frame = 'HRB'");
        }

        private void btnLegendaD_Click(object sender, EventArgs e)
        {
            visualizzaLegenda("frame IN ('HRD', 'DA001','DA002','DA003')");
        }

        private void btnDatiA_Click(object sender, EventArgs e)
        {
            visualizzaQuadroInExcel("A");
        }

        private void btnDatiB_Click(object sender, EventArgs e)
        {
            visualizzaQuadroInExcel("B");
        }

      

        private void btnLegendaDG_Click(object sender, EventArgs e)
        {
            visualizzaLegenda("frame IN ('HRD', 'DA001','DA002','DA003')");
        }

        private void btnDatiDH_Click(object sender, EventArgs e)
        {
            visualizzaQuadroInExcel("DH");

        }

        private void btnDatiDG_Click(object sender, EventArgs e)
        {
            visualizzaQuadroInExcel("DG");
        }

        private void btnLegendaDH_Click(object sender, EventArgs e)
        {
            visualizzaLegenda("frame IN ('HRD', 'DA001','DA002','DA003')");
        }

        private void btnStampaH_Click(object sender, EventArgs e) {
            if (!verificaPrestazioniSenzaCausale())
                return;
            verificaPresenzaProvvigioni();
            generaIlModello770(true, false, true);
        }

        private void faiScegliereCartella() {
            DialogResult dr = folderBrowserDialog1.ShowDialog(this);
            if (dr == DialogResult.OK) {
                txtPercorso.Text = folderBrowserDialog1.SelectedPath;
            }
        }



        class Collaboratore : IComparable {
            public string cf;
            public string progr;
            public int num=0;
            public Collaboratore(string cf, string progr) {
                this.cf = cf;
                this.progr = progr;
            }

            public int CompareTo(Object obj) {
                Collaboratore c = (Collaboratore)obj;
                if (cf.CompareTo(c.cf) != 0) {
                    return cf.CompareTo(c.cf);
                }
                return progr.CompareTo(c.progr);
            }
        }



        private void GeneraXMLPerStampa(string kind) {
            QHS = Meta.Conn.GetQueryHelper();
            if (!Meta.GetSys("esercizio").Equals(2015)) {
                show(this, "Questa procedura produce solo modelli cud per l'anno 2015", "Errore");
                return;
            }
            if (txtPercorso.Text == "") {
                faiScegliereCartella();
                if (txtPercorso.Text == "") {
                    show(this, "Occorre specificare la cartella in cui creare i modelli Cerficiazione Unica 2015", "errore");
                    return;
                }
            }
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;

            string []fname = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory,"CU_2015_mod*.pdf");
            foreach (string fileDaCopiare in fname) {
                string simpleFile = Path.GetFileName(fileDaCopiare);
                string fOrigin = fileDaCopiare;
                string fDest = Path.Combine(txtPercorso.Text, simpleFile);
                if (fOrigin != fDest) {
                    try {
                        File.Copy(fOrigin, fDest, true);
                    }
                    catch (Exception ex) {
                        show(this, ex.Message, "Errore nella copia di "+fDest);                        
                    }
                }
            }
//            tMod770 = ds.Tables[0];
            DataTable tRecordG = tMod770;

            DataTable tComunicazioni = new DataTable("comunicazioni");
            tComunicazioni.Columns.Add("progr", typeof(int));
            tComunicazioni.Columns.Add("cf", typeof(string));

            List<Collaboratore> collaboratori = new List<Collaboratore>();
            foreach (DataRow rRecordG in tRecordG.Select("quadro='DA002' and colonna='001'")) {
                DataRow rCom = tComunicazioni.Rows.Add(new object[] {rRecordG["progr"], rRecordG["stringa"]});
                Collaboratore co = new Collaboratore(rRecordG["stringa"].ToString(), rRecordG["progr"].ToString());
                int pos = collaboratori.BinarySearch(co);
                if (pos < 0) {
                    collaboratori.Insert(-pos - 1, co);
                }
            }
            Collaboratore prev = null;
            int n = 0;
            foreach (Collaboratore curr in collaboratori) {
                if (prev != null) {
                    if (prev.cf == curr.cf) {
                        curr.num = n;
                        n = n + 1;
                    }
                    else {
                        curr.num = 0;
                        n = 1;
                        prev = curr;
                    }
                }
                else {
                    curr.num = 0;
                    n=0;
                    prev = curr;
                }
            }

            IDictionary campiPresiDallaLicenza = new Hashtable();
            string filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));

            DataTable tConfig = Meta.Conn.RUN_SELECT("config", null, null, filteresercizio, null, true);
            DataRow rConfig = tConfig.Rows[0];
            campiPresiDallaLicenza["TextField10"] = rConfig["cudactivitycode"];
            campiPresiDallaLicenza["anno"] = 2014;
            
            foreach (Collaboratore co in collaboratori) {
                string cf = co.cf;
                string progr = co.progr;
                DataRow[] rCom = tComunicazioni.Select(QHC.AppAnd(QHC.CmpEq("cf", cf),QHC.CmpEq("progr",progr)));
                string commento = "";
                foreach (DataRow r in rCom) {
                    string quadroHR="";
                    if (kind == "H") {
                        quadroHR = "HRH";
                    }
                    else {
                        quadroHR = "HRG";
                    }
                    DataRow[] rHrg04 = tRecordG.Select(QHC.AppAnd(QHC.CmpEq("progr", progr),
                        QHC.CmpEq("quadro", quadroHR), QHC.CmpEq("colonna", "04")));
                    if (commento != "") {
                        commento += " - ";
                    }
                    commento += rHrg04[0]["stringa"];
                }// Fine foreach (DataRow r in rCom)

                string filtroProgr = QHC.FieldIn("progr", rCom);
                string filterDatiResp = QHC.CmpEq("quadro", "HRB");//consente di esportare anche l'header B
                string filterAll = QHC.DoPar(QHC.AppOr(filtroProgr, filterDatiResp));
                SortedList ht = new SortedList(campiPresiDallaLicenza);
                string nome = "";
                string cognome = "";
                foreach (DataRow rRecordG in tRecordG.Select(filterAll)) {
                    string campo = rRecordG["quadro"].ToString() + rRecordG["colonna"];
                    if(campo=="DA002002"){
                        cognome = rRecordG["stringa"].ToString();//cognome o denominazione
                    }
                    if ((campo == "DA002003")&&(rRecordG["stringa"].ToString()!="")) {
                        nome = rRecordG["stringa"].ToString();
                    }
                    switch (campo) {
                        case "DC001014": {
                                salvaColonnaDC001014(ht, rRecordG["stringa"].ToString());
                                break;
                            }
                        case "DC001013": {
                                salvaColonnaDC001013(ht, rRecordG["stringa"].ToString());
                                break;
                            }
                        case "DB001006": {
                                salvaColonnaDB001006(ht, (int)rRecordG["intero"]);
                                break;
                            }
                        case "NN001": {
                                // Note NN
                                riempiNote(ht, rRecordG["stringa"].ToString());
                                break;
                            }
                        case "NN002": {
                                // Note NN
                                riempiNote(ht, rRecordG["stringa"].ToString());
                                break;
                            }
                        case "NN003": {
                                // Note NN
                                riempiNote(ht, rRecordG["stringa"].ToString());
                                break;
                            }
                        case "NN004": {
                                // Note NN
                                riempiNote(ht, rRecordG["stringa"].ToString());
                                break;
                            }
                        case "NN005": {
                                // Note NN
                                riempiNote(ht, rRecordG["stringa"].ToString());
                                break;
                            }
                        case "NN006": {
                                // Note NN
                                riempiNote(ht, rRecordG["stringa"].ToString());
                                break;
                            }
                        case "NN007": {
                                // Note NN
                                riempiNote(ht, rRecordG["stringa"].ToString());
                                break;
                            }
                        case "NN008": {
                                // Note NN
                                riempiNote(ht, rRecordG["stringa"].ToString());
                                break;
                            }
                        case "NN009": {
                                // Note NN
                                riempiNote(ht, rRecordG["stringa"].ToString());
                                break;
                            }
                        case "NN010": {
                                // Note NN
                                riempiNote(ht, rRecordG["stringa"].ToString());
                                break;
                            }
                        default: salvaNormaleCampo(ht, campo, rRecordG); break;
                    }
                }
                ht["num_modello"] = (co.num + 1);//salva il progressivo per valorizzare Mod.N.
                ht["printdate_a"] = "2015";
                ht["printdate_g"] = "28";
                ht["printdate_m"] = "02";
                string denominazione = cognome + "-";
                if (nome != "") {
                    denominazione = denominazione + nome + "-";
                }
                stampaXml(ht, commento, cf, (co.num + 1).ToString().PadLeft(3, '0'), kind, denominazione);
                nome = "";
                cognome = "";
            }
            Cursor = null;
            show(this, "Sono stati generati " + collaboratori.Count + " modelli Certificazione Unica (.xdp) nella cartella:\n" 
                + txtPercorso.Text
                + "\nI file CU_2015_mod*.pdf vanno ignorati perchè contengono solo dei modelli vuoti.", "Salvataggio effettuato");
       
        }

        private XmlText createTextNode(XmlDocument doc, object valore) {
            if (valore is decimal) {
                decimal dec = (decimal)valore;
                return doc.CreateTextNode(((decimal)valore).ToString("n", numberFormat));
            }
            return doc.CreateTextNode(valore.ToString());
        }

        private void stampaXml(SortedList ht, string commento, string cf, string progr, string kind, string denominazione) {
            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", "UTF-8", ""));
            doc.AppendChild(doc.CreateComment(commento));
            doc.AppendChild(doc.CreateProcessingInstruction("xfa", "generator=\"XFA2_4\" APIVersion=\"2.6.7120.0\""));
            XmlNode xdp = doc.AppendChild(doc.CreateElement("xdp", "xdp", "http://ns.adobe.com/xdp/"));
            XmlNode datasets = xdp.AppendChild(doc.CreateElement("xfa", "datasets", "http://www.xfa.org/schema/xfa-data/1.0/"));
            XmlNode data = datasets.AppendChild(doc.CreateElement("xfa", "data", "http://www.xfa.org/schema/xfa-data/1.0/"));
            XmlNode topmostSubform = data.AppendChild(doc.CreateElement("topmostSubform"));
            foreach (DictionaryEntry de in ht) {
                XmlNode campo = topmostSubform.AppendChild(doc.CreateElement(de.Key.ToString()));
                campo.AppendChild(createTextNode(doc, de.Value));
            }
            foreach (string campo in new string[] { "DA002001", "cf", "DA002003", "DA002002", "DA002005g", "DA002005m", "DA002005a", "DA002007", "DA002006", "DA002004", "anno" }) {
                if (ht.Contains(campo)) {
                    topmostSubform.AppendChild(doc.CreateElement(campo + "bis")).AppendChild(createTextNode(doc, ht[campo]));
                }
            }
            foreach (string campo in new string[] { "DA002001" }) {
                if (ht.Contains(campo)) {
                    topmostSubform.AppendChild(doc.CreateElement(campo + "ter")).AppendChild(createTextNode(doc, ht[campo]));
                }
            }
            XmlElement pdf = doc.CreateElement("pdf", "http://ns.adobe.com/xdp/pdf/");
            //Scegli con che .pdf aprire il file generato
            if (chkConpaginavuota.Checked) {
                if (kind == "G") {
                    pdf.SetAttribute("href", "CU_2015_mod_gaddress.pdf");
                }
                if (kind == "H") {
                    pdf.SetAttribute("href", "CU_2015_mod_haddress.pdf");
                }
            }
            else {
                if (kind == "G") {
                    pdf.SetAttribute("href", "CU_2015_mod_gnoaddress.pdf");
                }
                if (kind == "H") {
                    pdf.SetAttribute("href", "CU_2015_mod_hnoaddress.pdf");
                }
            }

            //pdf.SetAttribute("href", "CU_2015_mod.pdf");
            xdp.AppendChild(pdf);
            string nomeFile = Path.Combine(txtPercorso.Text, denominazione+cf + "-" + progr + ".xdp");
            doc.Save(nomeFile);
        }
        private void riempiNote(SortedList ht, string nota) {
            if (ht["Annotazioni"] != null) {
                ht["Annotazioni"] += "\r\n";
            }
            ht["Annotazioni"] = ht["Annotazioni"] + nota;
        }
        private void salvaColonnaDC001014(SortedList ht, string dc001014) {
            char c = 'a';
            for (int i = 0; i < 12; i++) {
                if ((dc001014[i] == '1') && (ht["DC001014" + c] == null)) {
                    ht["DC001014" + c] = 'X';
                }
                c++;
            }
        }

        private void salvaColonnaDC001013(SortedList ht, string dc001013) {
            if (dc001013 == "1") {
                ht["DC001013"] = 'X';
            }
        }

        private void salvaColonnaDB001006(SortedList ht, int db001006) {
            object old = ht["DB001006"];
            if (old == null) {
                ht["DB001006"] = db001006;
            }
            else {
                int numGiorni = ((int)old) + db001006;
                if (numGiorni > 365) {
                    numGiorni = 365;
                }
                ht["DB001006"] = numGiorni;
            }
        }

        private object getValore(DataRow r) {
            if (r["stringa"] != DBNull.Value)
                return r["stringa"];
            if (r["intero"] != DBNull.Value)
                return r["intero"];
            if (r["data"] != DBNull.Value)
                return r["data"];
            if (r["decimale"] != DBNull.Value)
                return r["decimale"];
            return null;
        }

        //Usato solo in stampa
        private void salvaNormaleCampo(SortedList ht, string campo, DataRow rRecordG) {
            if (rRecordG["data"] != DBNull.Value) {
                DateTime data = (DateTime)rRecordG["data"];
                char[] c = new char[] { 'g', 'm', 'a' };
                int[] parte = new int[] { data.Day, data.Month, data.Year };
                for (int i = 0; i < 3; i++) {
                    string tag = campo + c[i];
                    object vecchio = ht[tag];
                    if (vecchio == null) {
                        ht[tag] = parte[i];
                    }
                    else {
                        if (!vecchio.Equals(parte[i])) {
                            ht.Remove(tag);
                            //show(this, "Campo: " + tag + "\r\n" + vecchio + "\r\n" + getValore(rRecordG), "ERRORE");
                        }
                    }
                }
                return;
            }
            object old = ht[campo];
            if (old == null) {
                ht[campo] = getValore(rRecordG);
            }
            else {
                if (old is int) {
                    ht[campo] = ((int)old) + ((int)rRecordG["intero"]);
                }
                else
                    if (old is decimal) {
                        ht[campo] = ((decimal)old) + ((decimal)rRecordG["decimale"]);
                    }
                    else {
                        if (!old.Equals(getValore(rRecordG))) {
                            ht.Remove(campo);
                            //show(this, "Campo: " + campo + "\r\n" + old + "\r\n" + getValore(rRecordG), "ERRORE");
                        }
                    }
            }
        }

        private void btnStampaG_Click(object sender, EventArgs e){
            if (!verificaPrestazioniSenzaCausale())
                return;
            verificaPresenzaProvvigioni();
            generaIlModello770(false, false, true);
        }

        /// <summary>
        /// legge i dati dal foglio di Excel a mData
        /// </summary>
        private void ReadCurrentSheet() {
            try {
                // open the connection to the file
                using (OleDbConnection connection =
                           new OleDbConnection(ConnectionString)) {
                    connection.Open();
                    DataTable sheetData = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    string foglioLavoro = sheetData.Rows[0]["TABLE_NAME"].ToString();
                    string sql =
                        string.Format("select * from [{0}]", foglioLavoro);
                    // create an adapter
                    using (OleDbDataAdapter adapter =
                               new OleDbDataAdapter(sql, connection)) {
                        // clear the datatable to avoid old data persistance
                        mData.Clear();
                        // fille the datatable
                        adapter.Fill(mData);
                    }
                    connection.Close();
                }
            }
            catch (Exception ex) {
                show(this, ex.Message);
            }
            // pulizia nomi colonne da eventuali spazi
            foreach (DataColumn C in mData.Columns) {
                C.ColumnName = C.ColumnName.Trim();
            }
        }

        private bool LeggiFile() {
            DialogResult dr = MyOpenFile.ShowDialog(this);
            
            if (dr != DialogResult.OK)
                return false;
            try {
                string fileName = MyOpenFile.FileName;
                ConnectionString = ExcelImport.ExcelConnString( fileName);
                    //"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName +
                    //";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";
                ReadCurrentSheet();
                txtInputFile.Text = fileName;
            }
            catch (Exception ex) {
                show(this, "Errore nell'apertura del file! Processo Terminato\n" + ex.Message);
                return false;
            }

            if (!verificaValiditaFileExcel()) {
                show(this, "Il file selezionato non è valido", "Errore");
                return false;

            }
            //if (!verificaValiditaCampiExcel()) {
            //    return false;
            //}

            fillTableCF();
            Meta.FreshForm();
            return true;
        }
        Dictionary<string, string> progressiviHRD06 = new Dictionary<string, string>();
        Dictionary<string, string> progressiviHRD07 = new Dictionary<string, string>();

        private void fillTableCF() {
            string  CF;
            progressiviHRD06.Clear();
            progressiviHRD07.Clear();
            
            foreach (DataRow rFile in mData.Select()) {
                CF = rFile["cf"].ToString().Trim();
                progressiviHRD06[CF] = rFile["identificativo"].ToString().Trim();
                progressiviHRD07[CF] = rFile["progressivo"].ToString().Trim();
            }
        }

        private object TrimString(object value, bool toglichiocciola) {
            if (value != null) {
                string strValue = value.ToString();
                if (strValue == "")
                    return DBNull.Value;
                else
                    return strValue.Trim();
            }
            else
                return DBNull.Value;
        }

        /// <summary>
        /// Metodo che verifica la validità del file Excel ricevuto in input
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        private bool verificaValiditaFileExcel() {
            ArrayList elencoColonne = new ArrayList();
            // La verifica di validità si basa sulla presenza di alcune colonne all'interno del file Excel.
            elencoColonne.Add("cf");
            elencoColonne.Add("identificativo");
            elencoColonne.Add("progressivo");
            foreach (string col in elencoColonne) {
                if (!mData.Columns.Contains(col))  {
                    show(this, "Nel file " + MyOpenFile.FileName + " non esiste la colonna " + col, "Errore");
                    return false;
                }
            }
            return true;
        }

        bool GetField(string tracciato, DataTable T) {
            bool ok = true;
            string[] ff = tracciato.Split(';');
            string fieldname = ff[0];
            int len = Convert.ToInt32(ff[3]);
            string ftype = ff[2].ToLower().Trim(); //(intero/numero/stringa/codificato/data)
            int rownum = 0;
            foreach (DataRow riga in mData.Select()) {
                string val = riga[fieldname].ToString().Trim();
                rownum++;
                if ((val.Length > len) && (ftype == "stringa")) {
                    string err = "Lunghezza non prevista nella decodifica del campo " + fieldname + " di tipo " + ftype + " e di valore " +
                     val.Trim().TrimStart('0') + " alla riga " + rownum;
                    DataRow row = T.NewRow();
                    row["errors"] = err;
                    T.Rows.Add(row);
                    ok = false;
                }
               if((fieldname=="cf") &&(val != "")) {
                    string errori = null;
                    CalcolaCodiceFiscale.CheckCF(val.Trim(), out errori);
                    if (errori != "") {
                        string err = " Nel codice fiscale " + " alla riga " + rownum + ": " + val + " compaiono i seguenti errori: " + errori;
                        DataRow row = T.NewRow();
                        row["errors"] = err;
                        T.Rows.Add(row);
                        ok = false;
                    }
                }
             }
           return ok;
        }


        private bool verificaValiditaCampiExcel() {
            string[] tracciato =
                new string[]{
                        "cf;C.F.;Stringa;16",
                        "campo1;Indirizzo;Stringa;1"
                };
            bool ok = true;
            DataSet Out = new DataSet();
            DataTable T = new DataTable();
            T.Columns.Add("errors", typeof(System.String), "");
            for (int i = 0; i < tracciato.Length; i++) {
                string fmt = tracciato[i];
                bool datiValidi = GetField(fmt, T);
                if (!datiValidi)
                    ok = false;
            }
            Out.Tables.Add(T);
            //if (!ok) {
            //    FrmViewError View = new FrmViewError(Out);
            //    View.Show();
            //}
            return ok;
        }
        private void addColumnExcel(DataTable tExcel) {
            tExcel.Columns.Add("cf", typeof(string));
            tExcel.Columns.Add("identificativo", typeof(string));
            tExcel.Columns.Add("progressivo", typeof(string));
        }

        private void btnInputFile_Click(object sender, EventArgs e) {
            //Riempie il datatable MData leggendo dal foglio Excel
            addColumnExcel(mData);
            if (!LeggiFile()) {
                return;
            }
        }





	}
}
