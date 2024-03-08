
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
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
using System.IO;
using System.Text;
using funzioni_configurazione;
using System.Xml;
using System.Collections;
using System.Globalization;
using iText.Kernel.Pdf;
using iText.Forms;
using System.Linq;
using SituazioneViewer;
using System.Runtime.Serialization.Formatters.Binary;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using LM=metadatalibrary.LanguageManager;
using iText.Forms.Fields;

namespace cu_details_default {
    /// <summary>
    /// Summary description for Frmcu_details_default.
    /// </summary>
    public class FrmCu_details_default : MetaDataForm {
        NumberFormatInfo numberFormat = CultureInfo.GetCultureInfo(0x410).NumberFormat;

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox txtPercorso;
        private System.Windows.Forms.Button btnSalvaIn;
        public cu_details_default.vistaForm DS;
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
        private FolderBrowserDialog _folderBrowserDialog1;
        private IFolderBrowserDialog folderBrowserDialog1;
        private GroupBox groupBox5;
        private DataGrid dataGrid;
        private CheckBox chkConIndirizzo;
        private GroupBox groupBox6;
        private TextBox txtCF;
        private Label label2;
        private TextBox txtInputFile;
        private Button btnInputFile;
        private OpenFileDialog _MyOpenFile;
        private IOpenFileDialog MyOpenFile;
        private CheckBox chkDonazione;
        private GroupBox groupBox7;
        private RadioButton radH;
        private RadioButton radG;
        private GroupBox groupBox8;
        private RadioButton radMail;
        private RadioButton radPrint;
        private RadioButton radSave;
        private Button btnGenera;
        private Label labelAvanzamento;
        private ProgressBar pBarAvanzamento;
        string EsercStr = null;
        private TextBox txtInputFileSetCF;
        private Button btnCUperSetdiCF;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public FrmCu_details_default() {
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
        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCu_details_default));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnDatiB = new System.Windows.Forms.Button();
            this.btnLegendaB = new System.Windows.Forms.Button();
            this.btnDatiA = new System.Windows.Forms.Button();
            this.btnLegendaA = new System.Windows.Forms.Button();
            this._folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dataGrid = new System.Windows.Forms.DataGrid();
            this.chkConIndirizzo = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.chkDonazione = new System.Windows.Forms.CheckBox();
            this.DS = new cu_details_default.vistaForm();
            this.txtCF = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInputFile = new System.Windows.Forms.TextBox();
            this.btnInputFile = new System.Windows.Forms.Button();
            this._MyOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.MyOpenFile = createOpenFileDialog(this._MyOpenFile);
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.radH = new System.Windows.Forms.RadioButton();
            this.radG = new System.Windows.Forms.RadioButton();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.radMail = new System.Windows.Forms.RadioButton();
            this.radPrint = new System.Windows.Forms.RadioButton();
            this.radSave = new System.Windows.Forms.RadioButton();
            this.btnGenera = new System.Windows.Forms.Button();
            this.labelAvanzamento = new System.Windows.Forms.Label();
            this.pBarAvanzamento = new System.Windows.Forms.ProgressBar();
            this.txtInputFileSetCF = new System.Windows.Forms.TextBox();
            this.btnCUperSetdiCF = new System.Windows.Forms.Button();
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
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(10, 172);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(892, 72);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            this.richTextBox1.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox1_LinkClicked);
            // 
            // txtPercorso
            // 
            this.txtPercorso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPercorso.Location = new System.Drawing.Point(142, 145);
            this.txtPercorso.Name = "txtPercorso";
            this.txtPercorso.ReadOnly = true;
            this.txtPercorso.Size = new System.Drawing.Size(762, 20);
            this.txtPercorso.TabIndex = 6;
            // 
            // btnSalvaIn
            // 
            this.btnSalvaIn.AutoSize = true;
            this.btnSalvaIn.Location = new System.Drawing.Point(9, 143);
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
            this.buttonRecordG.Location = new System.Drawing.Point(315, 32);
            this.buttonRecordG.Name = "buttonRecordG";
            this.buttonRecordG.Size = new System.Drawing.Size(84, 23);
            this.buttonRecordG.TabIndex = 9;
            this.buttonRecordG.Text = "Dati \"G\"";
            this.buttonRecordG.UseVisualStyleBackColor = true;
            this.buttonRecordG.Click += new System.EventHandler(this.buttonRecordG_Click);
            // 
            // buttonRecordH
            // 
            this.buttonRecordH.Location = new System.Drawing.Point(316, 32);
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
            this.groupBox1.Location = new System.Drawing.Point(13, 376);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 74);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RECORD DI TIPO \"G\": Dati relativi alla comunicazione dati certificazioni lavoro d" +
    "ipendente, assimilati ed assistenza fiscale";
            // 
            // btnLegendaDG
            // 
            this.btnLegendaDG.Location = new System.Drawing.Point(6, 32);
            this.btnLegendaDG.Name = "btnLegendaDG";
            this.btnLegendaDG.Size = new System.Drawing.Size(84, 23);
            this.btnLegendaDG.TabIndex = 20;
            this.btnLegendaDG.Text = "Legenda \"D\"";
            this.btnLegendaDG.UseVisualStyleBackColor = true;
            this.btnLegendaDG.Click += new System.EventHandler(this.btnLegendaDG_Click);
            // 
            // btnDatiDG
            // 
            this.btnDatiDG.Location = new System.Drawing.Point(96, 32);
            this.btnDatiDG.Name = "btnDatiDG";
            this.btnDatiDG.Size = new System.Drawing.Size(84, 23);
            this.btnDatiDG.TabIndex = 19;
            this.btnDatiDG.Text = "Dati \"D\"";
            this.btnDatiDG.UseVisualStyleBackColor = true;
            this.btnDatiDG.Click += new System.EventHandler(this.btnDatiDG_Click);
            // 
            // buttonLegendaG
            // 
            this.buttonLegendaG.Location = new System.Drawing.Point(225, 32);
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
            this.groupBox2.Location = new System.Drawing.Point(480, 373);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(418, 74);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "RECORD DI TIPO \"H\": Dati relativi alla comunicazione dati certificazioni lavoro a" +
    "utonomo, provvigioni e redditi diversi";
            // 
            // btnLegendaDH
            // 
            this.btnLegendaDH.Location = new System.Drawing.Point(6, 32);
            this.btnLegendaDH.Name = "btnLegendaDH";
            this.btnLegendaDH.Size = new System.Drawing.Size(84, 23);
            this.btnLegendaDH.TabIndex = 19;
            this.btnLegendaDH.Text = "Legenda \"D\"";
            this.btnLegendaDH.UseVisualStyleBackColor = true;
            this.btnLegendaDH.Click += new System.EventHandler(this.btnLegendaDH_Click);
            // 
            // btnDatiDH
            // 
            this.btnDatiDH.Location = new System.Drawing.Point(96, 32);
            this.btnDatiDH.Name = "btnDatiDH";
            this.btnDatiDH.Size = new System.Drawing.Size(84, 23);
            this.btnDatiDH.TabIndex = 18;
            this.btnDatiDH.Text = "Dati \"D\"";
            this.btnDatiDH.UseVisualStyleBackColor = true;
            this.btnDatiDH.Click += new System.EventHandler(this.btnDatiDH_Click);
            // 
            // buttonLegendaH
            // 
            this.buttonLegendaH.Location = new System.Drawing.Point(226, 32);
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
            this.groupBox3.Location = new System.Drawing.Point(522, 7);
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
            this.buttonProblemiH.Text = "Problemi record H";
            this.buttonProblemiH.UseVisualStyleBackColor = true;
            this.buttonProblemiH.Click += new System.EventHandler(this.buttonProblemiH_Click);
            // 
            // buttonIncoerenze
            // 
            this.buttonIncoerenze.Location = new System.Drawing.Point(21, 43);
            this.buttonIncoerenze.Name = "buttonIncoerenze";
            this.buttonIncoerenze.Size = new System.Drawing.Size(172, 23);
            this.buttonIncoerenze.TabIndex = 14;
            this.buttonIncoerenze.Text = "Problemi record G e H";
            this.buttonIncoerenze.UseVisualStyleBackColor = true;
            this.buttonIncoerenze.Visible = false;
            this.buttonIncoerenze.Click += new System.EventHandler(this.buttonIncoerenze_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnDatiB);
            this.groupBox4.Controls.Add(this.btnLegendaB);
            this.groupBox4.Controls.Add(this.btnDatiA);
            this.groupBox4.Controls.Add(this.btnLegendaA);
            this.groupBox4.Location = new System.Drawing.Point(9, 327);
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
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.dataGrid);
            this.groupBox5.Location = new System.Drawing.Point(12, 455);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(892, 279);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
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
            this.dataGrid.Size = new System.Drawing.Size(880, 254);
            this.dataGrid.TabIndex = 3;
            this.dataGrid.Tag = " ";
            // 
            // chkConIndirizzo
            // 
            this.chkConIndirizzo.AutoSize = true;
            this.chkConIndirizzo.Location = new System.Drawing.Point(6, 12);
            this.chkConIndirizzo.Name = "chkConIndirizzo";
            this.chkConIndirizzo.Size = new System.Drawing.Size(268, 17);
            this.chkConIndirizzo.TabIndex = 20;
            this.chkConIndirizzo.Text = "Stampa l\'indirizzo del percipiente sulla prima pagina.";
            this.chkConIndirizzo.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.chkDonazione);
            this.groupBox6.Controls.Add(this.chkConIndirizzo);
            this.groupBox6.Location = new System.Drawing.Point(199, 7);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(317, 70);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            // 
            // chkDonazione
            // 
            this.chkDonazione.AutoSize = true;
            this.chkDonazione.Location = new System.Drawing.Point(5, 35);
            this.chkDonazione.Name = "chkDonazione";
            this.chkDonazione.Size = new System.Drawing.Size(280, 30);
            this.chkDonazione.TabIndex = 21;
            this.chkDonazione.Text = "Stampa Scheda per la scelta della destinazione dell’8 \r\nper mille, del 5 per mill" +
    "e e del 2 per mille dell\'IRPEF.";
            this.chkDonazione.UseVisualStyleBackColor = true;
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // txtCF
            // 
            this.txtCF.Location = new System.Drawing.Point(13, 304);
            this.txtCF.Name = "txtCF";
            this.txtCF.Size = new System.Drawing.Size(253, 20);
            this.txtCF.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 288);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Codice fiscale per generazione singola";
            // 
            // txtInputFile
            // 
            this.txtInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInputFile.Location = new System.Drawing.Point(231, 251);
            this.txtInputFile.Multiline = true;
            this.txtInputFile.Name = "txtInputFile";
            this.txtInputFile.ReadOnly = true;
            this.txtInputFile.Size = new System.Drawing.Size(670, 22);
            this.txtInputFile.TabIndex = 25;
            // 
            // btnInputFile
            // 
            this.btnInputFile.Location = new System.Drawing.Point(9, 250);
            this.btnInputFile.Name = "btnInputFile";
            this.btnInputFile.Size = new System.Drawing.Size(222, 23);
            this.btnInputFile.TabIndex = 24;
            this.btnInputFile.Text = "Importa CF da Excel per CU correttive";
            this.btnInputFile.Click += new System.EventHandler(this.btnInputFile_Click);
            // 
            // MyOpenFile
            // 
            //this.MyOpenFile.FileName = "openFileDialog";
            //this.MyOpenFile.Title = "Selezionare il file Excel da importare";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.radH);
            this.groupBox7.Controls.Add(this.radG);
            this.groupBox7.Location = new System.Drawing.Point(8, 7);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(185, 70);
            this.groupBox7.TabIndex = 26;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Tipo record da generare";
            // 
            // radH
            // 
            this.radH.AutoSize = true;
            this.radH.Location = new System.Drawing.Point(13, 42);
            this.radH.Name = "radH";
            this.radH.Size = new System.Drawing.Size(66, 17);
            this.radH.TabIndex = 1;
            this.radH.Text = "record H";
            this.radH.UseVisualStyleBackColor = true;
            // 
            // radG
            // 
            this.radG.AutoSize = true;
            this.radG.Checked = true;
            this.radG.Location = new System.Drawing.Point(13, 19);
            this.radG.Name = "radG";
            this.radG.Size = new System.Drawing.Size(66, 17);
            this.radG.TabIndex = 0;
            this.radG.TabStop = true;
            this.radG.Text = "record G";
            this.radG.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.radMail);
            this.groupBox8.Controls.Add(this.radPrint);
            this.groupBox8.Controls.Add(this.radSave);
            this.groupBox8.Location = new System.Drawing.Point(9, 83);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(351, 54);
            this.groupBox8.TabIndex = 27;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Tipo generazione";
            // 
            // radMail
            // 
            this.radMail.AutoSize = true;
            this.radMail.Location = new System.Drawing.Point(232, 19);
            this.radMail.Name = "radMail";
            this.radMail.Size = new System.Drawing.Size(69, 17);
            this.radMail.TabIndex = 3;
            this.radMail.Text = "Invio mail";
            this.radMail.UseVisualStyleBackColor = true;
            // 
            // radPrint
            // 
            this.radPrint.AutoSize = true;
            this.radPrint.Location = new System.Drawing.Point(141, 19);
            this.radPrint.Name = "radPrint";
            this.radPrint.Size = new System.Drawing.Size(61, 17);
            this.radPrint.TabIndex = 2;
            this.radPrint.Text = "Stampa";
            this.radPrint.UseVisualStyleBackColor = true;
            // 
            // radSave
            // 
            this.radSave.AutoSize = true;
            this.radSave.Checked = true;
            this.radSave.Location = new System.Drawing.Point(9, 19);
            this.radSave.Name = "radSave";
            this.radSave.Size = new System.Drawing.Size(97, 17);
            this.radSave.TabIndex = 1;
            this.radSave.TabStop = true;
            this.radSave.Text = "Salvataggio file";
            this.radSave.UseVisualStyleBackColor = true;
            // 
            // btnGenera
            // 
            this.btnGenera.Location = new System.Drawing.Point(366, 102);
            this.btnGenera.Name = "btnGenera";
            this.btnGenera.Size = new System.Drawing.Size(118, 23);
            this.btnGenera.TabIndex = 28;
            this.btnGenera.Text = "Genera";
            this.btnGenera.UseVisualStyleBackColor = true;
            this.btnGenera.Click += new System.EventHandler(this.btnGenera_Click);
            // 
            // labelAvanzamento
            // 
            this.labelAvanzamento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelAvanzamento.AutoSize = true;
            this.labelAvanzamento.Location = new System.Drawing.Point(15, 742);
            this.labelAvanzamento.Name = "labelAvanzamento";
            this.labelAvanzamento.Size = new System.Drawing.Size(124, 13);
            this.labelAvanzamento.TabIndex = 30;
            this.labelAvanzamento.Text = "Stato avanzamento invio";
            // 
            // pBarAvanzamento
            // 
            this.pBarAvanzamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pBarAvanzamento.Location = new System.Drawing.Point(18, 758);
            this.pBarAvanzamento.Name = "pBarAvanzamento";
            this.pBarAvanzamento.Size = new System.Drawing.Size(886, 23);
            this.pBarAvanzamento.TabIndex = 29;
            // 
            // txtInputFileSetCF
            // 
            this.txtInputFileSetCF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInputFileSetCF.Location = new System.Drawing.Point(442, 303);
            this.txtInputFileSetCF.Multiline = true;
            this.txtInputFileSetCF.Name = "txtInputFileSetCF";
            this.txtInputFileSetCF.ReadOnly = true;
            this.txtInputFileSetCF.Size = new System.Drawing.Size(456, 22);
            this.txtInputFileSetCF.TabIndex = 32;
            // 
            // btnCUperSetdiCF
            // 
            this.btnCUperSetdiCF.Location = new System.Drawing.Point(269, 302);
            this.btnCUperSetdiCF.Name = "btnCUperSetdiCF";
            this.btnCUperSetdiCF.Size = new System.Drawing.Size(167, 23);
            this.btnCUperSetdiCF.TabIndex = 31;
            this.btnCUperSetdiCF.Text = "Importa CF da Excel per CU";
            this.btnCUperSetdiCF.Click += new System.EventHandler(this.btnCUperSetdiCF_Click);
            // 
            // FrmCu_details_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(916, 793);
            this.Controls.Add(this.txtInputFileSetCF);
            this.Controls.Add(this.btnCUperSetdiCF);
            this.Controls.Add(this.labelAvanzamento);
            this.Controls.Add(this.pBarAvanzamento);
            this.Controls.Add(this.btnGenera);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.txtInputFile);
            this.Controls.Add(this.btnInputFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCF);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.txtPercorso);
            this.Controls.Add(this.btnSalvaIn);
            this.Name = "FrmCu_details_default";
            this.Text = "Frmcu_details_default";
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
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        IDictionary campiPresiDallaLicenza = new Hashtable();

        QueryHelper QHS;
        CQueryHelper QHC;
        string ConnectionString;
        System.Data.DataTable mData = new System.Data.DataTable();
        private DataAccess conn;

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHS = Meta.Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            int esercizio = (int)Meta.GetSys("esercizio");
            EsercStr = esercizio.ToString();
            GetData.CacheTable(DS.cu_details, "ayear=" + esercizio, "colorder", false);
            this.conn = Meta.Conn;
            Meta.CanSave = false;
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.SearchEnabled = false;

            string link = "http://www.agenziaentrate.it/ilwwcm/connect/Nsi/Strumenti/Software/Dichiarazioni/";
            switch (esercizio) {
                case 2015:
                    link =
                        "http://www.agenziaentrate.gov.it/wps/content/Nsilib/Nsi/Home/CosaDeviFare/Dichiarare/DichiarazioniSostitutiImposta/Certificazione+Unica+2015/SW+Compilazione+CU+2015/";
                    break;
                case 2016:
                    link =
                        "http://www.agenziaentrate.gov.it/wps/content/nsilib/nsi/strumenti/dichiarazioni+2016+modelli+e+istruzioni";
                    break;
                case 2017:
                    link =
                        "http://www.agenziaentrate.gov.it/wps/content/Nsilib/Nsi/Home/CosaDeviFare/Dichiarare/DichiarazioniSostitutiImposta/Certificazione+Unica+2017/InfoGen+CU2017/";
                    break;
            }

            this.richTextBox1.Text = "";
            //this.richTextBox1.Text = "La certificazione unica generata può essere inviata telematicamente tramite il \"Software di compilazione Certificazione Unica  "
            //                         + esercizio
            //                         +
            //                         "\" dell'Agenzia delle Entrate.\nTale software si può scaricare gratuitamente a questo indirizzo:\n"
            //                         + link
            //                         + "";
            ;
            //groupBox5.Visible = false;
            chkConIndirizzo.Checked = false;


            string filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));

            DataTable tConfig = Meta.Conn.RUN_SELECT("config", null, null, filteresercizio, null, true);
            DataRow rConfig = tConfig.Rows[0];
            campiPresiDallaLicenza["TextField10"] = rConfig["cudactivitycode"];
            campiPresiDallaLicenza["anno"] = esercizio - 1;

            //chkConpaginavuota.Visible = false;
        }

        private string vuoto(string formato, int lunghezza) {
            switch (formato) {
                case "AN": //P-N
                case "CF": //P-N
                case "PR": //P-N
                case "VP": // P
                case "VN": //P-N
                    return "".PadLeft(lunghezza);
                case "DA":
                case "DT": //P-N
                case "CN": //P-N
                case "PI": //P-N
                case "NU": //P-N
                case "N5": //P-N
                case "N1"://P-N
                case "NP"://P-N
                case "CB": //P-N
                    return "".PadLeft(lunghezza, '0');
            }
            show(this, "Impossibile creare la stringa vuota per il formato '" + formato + "'");
            return "".PadLeft(lunghezza);
        }

        private string formattaCampoPosizionale(DataRow r, int lunghezza) {
            string filtro = "(frame='" + r["quadro"] + "') and (colnumber='" + r["colonna"] + "')";
            DataRow rFormato = DS.cu_details.Select(filtro)[0];
            Object valore;
            switch (rFormato["format"].ToString()) {
                case "AN": //P-N
                case "CF": //P-N
                case "CN": //P-N
                case "PR": //P-N
                    string s = getString(r, out valore).ToUpper();
                    if (s.Length >= lunghezza) {
                        return s.Substring(0, lunghezza);
                    }
                    return s.PadRight(lunghezza);
                case "DT": //P-N
                    DateTime dt = getDateTime(r, out valore);
                    return dt.ToString("ddMMyyyy");
                case "PI": //P-N
                case "NU": //P-N
                case "CB": //P-N
                    string t = getInt(r, out valore).ToString();
                    return t.PadLeft(lunghezza, '0');
                case "N1":
                    return getInt(r, out valore).ToString().PadLeft(1, '0');
                case "NP": //P-N

                case "N5":
                    return getInt(r, out valore).ToString().PadLeft(5, '0');
            }
            show(this,
                "Formato Errato " + rFormato["format"] + " nella Colonna" + r["colonna"] + " del quadro " + r["quadro"]);
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
            if (s.Length <= 16) return new string[] { campoCodice + s.PadRight(16) };
            string[] result = new string[(s.Length + 13) / 15];
            result[0] = campoCodice + s.Substring(0, 16);
            for (int i = 1; i < result.Length - 1; i++) {
                result[i] = campoCodice + "+" + s.Substring(1 + i * 15, 15);
            }
            result[result.Length - 1] = campoCodice + "+" + s.Substring(15 * result.Length - 14).PadRight(15);
            return result;
        }

        private Type getTipo(DataRow rFormato) {
            switch (rFormato["format"].ToString()) {
                case "AN": //P-N
                case "CF": //P-N
                case "CN": //P-N
                case "PR": //P-N
                case "N10": //N
                case "CB12": //N
                    return typeof(string);
                case "PI": //P-N
                case "DA": //N
                case "NP": //N
                case "NU": //P-N
                case "PC": //N
                case "QU": //N
                case "CB": //P-N
                case "N1": //N
                case "N2": //N
                case "N3": //N
                case "N4": //N
                case "N5": //N
                    return typeof(int);
                case "DT": //P-N
                case "DN": //N
                case "D4": //N
                case "D6": //N
                    return typeof(DateTime);
                case "VP": //P
                case "VN": //P-N
                    return typeof(decimal);
            }
            show("Formato sconosciuto nel quadro " + rFormato["frame"] + " colonna " + rFormato["colnumber"]);
            return null;
        }

        private string getString(DataRow r, out object valore) {
            if (r["intero"] != DBNull.Value) {
                show(this, "Intero e non stringa nel quadro " + r["quadro"] + " colonna " + r["colonna"]);
            }
            if (r["data"] != DBNull.Value) {
                show(this, "Data e non stringa nel quadro " + r["quadro"] + " colonna " + r["colonna"]);
            }
            if (r["decimale"] != DBNull.Value) {
                show(this, "Decimale e non stringa nel quadro " + r["quadro"] + " colonna " + r["colonna"]);
            }
            return (string)(valore = r["stringa"]);
        }

        private int getInt(DataRow r, out object valore) {
            if (r["stringa"] != DBNull.Value) {
                show(this, "Stringa e non intero nel quadro " + r["quadro"] + " colonna " + r["colonna"]);
            }
            if (r["data"] != DBNull.Value) {
                show(this, "Data e non intero nel quadro " + r["quadro"] + " colonna " + r["colonna"]);
            }
            if (r["decimale"] != DBNull.Value) {
                show(this, "Decimale e non intero nel quadro " + r["quadro"] + " colonna " + r["colonna"]);
            }
            return (int)(valore = r["intero"]);
        }

        private decimal getDecimal(DataRow r, out object valore) {
            if (r["stringa"] != DBNull.Value) {
                show(this, "Stringa e non decimal nel quadro " + r["quadro"] + " colonna " + r["colonna"]);
            }
            if (r["data"] != DBNull.Value) {
                show(this, "Data e non decimal nel quadro " + r["quadro"] + " colonna " + r["colonna"]);
            }
            if (r["intero"] != DBNull.Value) {
                show(this, "Intero e non decimal nel quadro " + r["quadro"] + " colonna " + r["colonna"]);
            }
            return (decimal)(valore = r["decimale"]);
        }

        private DateTime getDateTime(DataRow r, out object valore) {
            if (r["stringa"] != DBNull.Value) {
                show(this, "Stringa e non data nel quadro " + r["quadro"] + " colonna " + r["colonna"]);
            }
            if (r["intero"] != DBNull.Value) {
                show(this, "Intero e non data nel quadro " + r["quadro"] + " colonna " + r["colonna"]);
            }
            if (r["decimale"] != DBNull.Value) {
                show(this, "Decimale e non data nel quadro " + r["quadro"] + " colonna " + r["colonna"]);
            }
            return (DateTime)(valore = r["data"]);
        }

        private string[] formattaCampoNonPosizionale(DataRow r, out object valore, bool perStampa) {
            string campoCodice = r["quadro"] + r["riga"].ToString().PadLeft(3, '0') + r["colonna"];
            if (r["quadro"].ToString().Substring(0, 2) == "DA")
                campoCodice = r["quadro"].ToString() + r["colonna"].ToString();
            if ((r["quadro"].ToString().Substring(0, 2) == "DB") || (r["quadro"].ToString().Substring(0, 2) == "DC")
                || (r["quadro"].ToString().Substring(0, 2) == "DN"))
                campoCodice = r["quadro"].ToString() + r["colonna"].ToString();
            if (r["quadro"].ToString() == "SS")
                return new string[] { campoCodice + getInt(r, out valore).ToString().PadLeft(16) };
            if (r["quadro"].ToString() == "DC001" && r["colonna"].ToString() == "092") { 
                valore = r["stringa"].ToString();
                string patcode = "DC001092" + (valore.ToString()).PadLeft(16); 
                return new string[] { patcode };
            }
            string filtro = "(frame='" + r["quadro"] + "') and (colnumber='" + r["colonna"] + "')";
            DataRow[] rFormato = DS.cu_details.Select(filtro);
            switch (rFormato[0]["format"].ToString()) {
                case "AN": //P-N
                case "CF": //P-N
                case "PR": //P-N
                    return stringaASinistra(campoCodice, getString(r, out valore));
                case "PN": //P-N
                    return stringaASinistra(campoCodice, getString(r, out valore));
                case "PE": //P-N
                    return stringaASinistra(campoCodice, getString(r, out valore));
                case "CN": //P-N
                    return stringaASinistra(campoCodice, getString(r, out valore));
                case "PI": //P-N
                    return stringaASinistra(campoCodice, getInt(r, out valore).ToString());
                case "DA": //N
                case "NP": //N
                case "NU": //P-N
                case "PC": //N
                case "QU": //N
                    return new string[] { campoCodice + getInt(r, out valore).ToString().PadLeft(16) };
                case "CB": //P-N
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
                case "N1": //N
                    return new string[] { campoCodice + getInt(r, out valore).ToString().PadLeft(1, '0').PadLeft(16) };
                case "N2": //N
                    return new string[] { campoCodice + getInt(r, out valore).ToString().PadLeft(2, '0').PadLeft(16) };
                case "N3": //N
                    return new string[] { campoCodice + getInt(r, out valore).ToString().PadLeft(3, '0').PadLeft(16) };
                case "N5": //N
                    return new string[] { campoCodice + getInt(r, out valore).ToString().PadLeft(5, '0').PadLeft(16) };
                case "N10": //N
                    return new string[] { campoCodice + getString(r, out valore).PadLeft(10, '0').PadLeft(16) };
                case "CB12": //N
                    return new string[] { campoCodice + getString(r, out valore).PadLeft(12, '0').PadLeft(16) };
                case "DT": //P-N
                case "DN": //N
                    return new string[] { campoCodice + getDateTime(r, out valore).ToString("ddMMyyyy").PadLeft(16) };
                case "D4": //N
                    return new string[] { campoCodice + getDateTime(r, out valore).ToString("ddMM").PadLeft(16) };
                case "D6": //N
                    return new string[] { campoCodice + getDateTime(r, out valore).ToString("MMyyyy").PadLeft(16) };
                case "VP": //N
                case "VN": //P-N
                    return new string[] { campoCodice + getDecimal(r, out valore).ToString().PadLeft(16) };
                default:
                    show("FCNP: Formato sconosciuto nel quadro " + r["quadro"] + " colonna " + r["colonna"]);
                    valore = null;
                    return null;
            }
        }



        private string getHeader(DataTable t, string quadro, int progressivoComunicazione, int progressivoModulo) {
            StringBuilder sb = new StringBuilder();
            string filtro = "(frame='" + quadro + "')";
            DataRow[] record = DS.cu_details.Select(filtro);
            foreach (DataRow r in record) {
                string formato = (string)r["format"];
                int lunghezza = (int)r["fieldlen"];


                string filtro2 = QHC.AppAnd(QHC.CmpEq("quadro", quadro), QHC.CmpEq("progr", progressivoComunicazione),
                    QHC.CmpEq("colonna", r["colnumber"]),
                    QHC.CmpEq("modulo", progressivoModulo));

                DataRow[] r770 = t.Select(filtro2);
                if (r770.Length > 1) {
                    show(this,
                        "Errore interno: trovate " + r770.Length + " righe con questo filtro\n" + filtro2);
                }
                if (r770.Length == 0) {
                    if (
                        r["frame"].ToString() ==
                        "HRD" & (r["colnumber"].ToString() == "06" || r["colnumber"].ToString() == "07")) {
                        sb.Append("".PadLeft(lunghezza, '0'));
                    }
                    else
                        sb.Append(vuoto(formato, lunghezza));
                }
                else {

                    sb.Append(formattaCampoPosizionale(r770[0], lunghezza));

                }

            }
            return sb.ToString();
        }



        private int scriviRecord(TextWriter tw, string header, DataTable t, string quadri, int progressivoComunicazione,
            int progressivoModulo) {
            int numeroRecord = 1;
            //string pc = header.Substring(17, 8);
            //int progressivoComunicazione = Int32.Parse(pc);
            string filtro = "(progr=" + progressivoComunicazione + ") and (quadro IN(" + quadri + ") and (modulo = " +
                            progressivoModulo + "))";
            DataRow[] record = t.Select(filtro, "quadro, riga, colonna");
            tw.Write(header);
            int aDisposizione = 1809; //1898 - 89 (posizioni per i campi posizionali) = 1809
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
                if (saveFileDialog1.ShowDialog(this) != DialogResult.OK) return null;
                string fileName = saveFileDialog1.FileName;
                txtPercorso.Text = Path.GetDirectoryName(fileName);
                try {
                    return new StreamWriter(fileName, false, Encoding.Default);
                }
                catch (Exception e) {
                    QueryCreator.ShowException(this,
                        "Inserire il percorso del file dove salvare la Certificazione Unica", e);
                }
            }
            return null;
        }

        /// <summary>
        /// Genera file da inviare all'agenzia delle entrate
        /// </summary>
        /// <param name="tw"></param>
        /// <param name="ds"></param>
        /// <param name="recordH"></param>
        private void salvaCertificazioneUnica(TextWriter tw, DataSet ds, bool recordH) {

            tw.WriteLine(getHeader(ds.Tables[0], "HRA", 1, 1) + "A");

            tw.WriteLine(getHeader(ds.Tables[0], "HRB", 1, 1) + "A");

            int nRecordD = 0;
            int nRecordH = 0;
            int nRecordG = 0;
            int nRecordL = 0;
            // HRD colonna 05 contiene il progressivo della comunicazione, troviamo un progressivo diverso per ogni percipiente
            DataRow[] rD = ds.Tables[0].Select("(quadro='HRD')and(colonna='05')");
            if (recordH) {
                foreach (DataRow rpd in rD) {
                    int progressivoComunicazione = Convert.ToInt32(rpd["intero"]);

                    string headerD = getHeader(ds.Tables[0], "HRD", progressivoComunicazione, 1);
                    nRecordD += scriviRecord(tw, headerD, ds.Tables[0], "'DA001','DA002','DA003'",
                        progressivoComunicazione, 1);

                    DataRow[] rH =
                        ds.Tables[0].Select("(quadro='HRH')and(colonna='05') and (progr = " + progressivoComunicazione +
                                            ")");
                    foreach (DataRow rph in rH) {
                        int progressivoModulo = Convert.ToInt32(rph["modulo"]);
                        string headerH = getHeader(ds.Tables[0], "HRH", progressivoComunicazione, progressivoModulo);
                        //string filterModuliH = QHC.AppAnd ( QHC.CmpEq("progr", progressivoComunicazione), QHC.CmpEq("quadro", "AU"));
                        //string progressiviModuloRecH = QHC.DistinctVal(ds.Tables[0].Select(filterModuliH), "modulo");



                        nRecordH += scriviRecord(tw, headerH, ds.Tables[0], "'AU'", progressivoComunicazione,
                            progressivoModulo);
                    }
                }
            }
            else {
                foreach (DataRow rpd in rD) {
                    int progressivoComunicazione = Convert.ToInt32(rpd["intero"]);

                    string headerD = getHeader(ds.Tables[0], "HRD", progressivoComunicazione, 1);
                    nRecordD += scriviRecord(tw, headerD, ds.Tables[0], "'DA001','DA002','DA003'",
                        progressivoComunicazione, 1);

                    DataRow[] rG =
                        ds.Tables[0].Select("(quadro='HRG')and(colonna='05') and (progr = " + progressivoComunicazione +
                                            ")");
                    foreach (DataRow rph in rG) {
                        int progressivoModulo = Convert.ToInt32(rph["modulo"]);
                        string headerG = getHeader(ds.Tables[0], "HRG", progressivoComunicazione, progressivoModulo);
                        nRecordG += scriviRecord(tw, headerG, ds.Tables[0],
                            "'DB001','DB100','DB601','DB602','DB603','DB604','DB605','DB606','DB607','DB608','DB609','DB610','DC001','DN001'",
                            progressivoComunicazione, progressivoModulo);
                    }
                }
            }

            string recordZ = "Z".PadRight(15) //Tipo record + Filler 
                             + "1".PadLeft(9, '0') //Numero record di tipo ‘B’ 
                             + "0".PadLeft(9, '0') //Numero record di tipo ‘C’ 
                             + nRecordD.ToString().PadLeft(9, '0') //Numero record di tipo ‘D’ 
                             + nRecordG.ToString().PadLeft(9, '0') //Numero record di tipo ‘G’ 
                             + nRecordH.ToString().PadLeft(9, '0') //Numero record di tipo ‘H’ 
                             + nRecordL.ToString().PadLeft(9, '0') //Numero record di tipo ‘L' 
                             + "".PadRight(18)
                             + "A".PadLeft(1811); //1898-15-9*8 = 1811

            tw.WriteLine(recordZ);

            tw.Close();

            if (recordH)
                show(this, "Modello Certificazione Unica salvato nel file: " + saveFileDialog1.FileName
                                      + "\nComunicazioni Lavoro Autonomo:   " + rD.Length + "  (" + nRecordH +
                                      " record di tipo \"H\")" +
                                      "Creazione dichiarazione terminata");
            else
                show(this, "Modello Certificazione Unica salvato nel file: " + saveFileDialog1.FileName
                                      + "\n\nComunicazioni Lavoro Dipendente: " + rD.Length + "  (" + nRecordG +
                                      " record di tipo \"G\")" +
                                      "Creazione dichiarazione terminata");
        }

        //Questo metodo va chiamato prima di generare il mod770, è presenta anche nel modello CUD
        private bool verificaContrattiNonPagati() {
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
            if (t.Rows.Count > 0) {
                string errore =
                    "Esistono dei cedolini nei seguenti contratti i cui pagamenti non sono ancora stati trasmessi in banca:";
                foreach (DataRow r in t.Rows) {
                    errore += "\nn° " + r["ncon"] + " del " + r["ycon"] + ";";
                    if (r["idexhibitedcud"] != DBNull.Value) {
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


        private bool verificaContrattiRecordG() {

            int esercizio = (int)Meta.GetSys("esercizio");
            string errMsg;
            DataSet ds = Meta.Conn.CallSP("exp_certificazioneunica_contratti_g",
                new object[] { esercizio }, 60 * 60,
                out errMsg);

            if (ds == null) {
                return true;
            }

            DataTable T = ds.Tables[0];
            if (T.Rows.Count > 0) {
                frmErrori fErr = new frmErrori(T);
                createForm(fErr, null);
                DialogResult drErr = fErr.ShowDialog();
                return false;
            }
            return true;
        }



        //Questo metodo va chiamato prima di generare il mod770, è presenta anche nel modello CUD
        private bool verificaPrestazioniCertificazioniCUD() {
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
                           +
                           "WHERE EXISTS (select * from payroll JOIN expensepayroll ON payroll.idpayroll = expensepayroll.idpayroll "
                           + "JOIN expenselink ON expenselink.idparent = expensepayroll.idexp "
                           + "JOIN expenselast on expenselast.idexp = expenselink.idchild "
                           + "WHERE payroll.idcon = parasubcontract.idcon  AND payroll.fiscalyear =  " + (esercizio - 1) +
                           ") "
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

        private bool verificaPrestazioniCertificazioniNonCUD() {
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
                string errore =
                    "Esistono dei percipienti con contratti non esibiti come CUD in altri contratti, le cui prestazioni " +
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

        private bool verificaPresenzaProvvigioni() {
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
                           " WHERE   " + QHS.CmpEq("year(paymenttransmission.transmissiondate)", (esercizio - 1)) +
                           " AND service.rec770kind = 'H' " +
                           " AND  M.idmot is null " +
                           " AND " + QHS.FieldInList("service.codeser", "'07_PROVVIGIONI','07_PROVVIGIONI_OCC'");

            DataTable t = Meta.Conn.SQLRunner(query);

            if (t == null || t.Rows.Count == 0) return true;
            else {
                string errore =
                    "Sono state pagate delle provvigioni. Controllare le causali delle dichiarazioni nelle quali sono state usate.\r\n" +
                    "Controllare le dichiarazioni dei seguenti percipienti\r\n";
                foreach (DataRow r in t.Rows) {
                    errore += "\nNominativo: " + r["title"] + " - Codice Fiscale " + " - " + r["cf"];
                }
                show(this, errore);
                return false;
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
        private bool verificaPrestazioniCertificazioniInNonCUD() {
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
                           +
                           "WHERE EXISTS (select * from payroll JOIN expensepayroll ON payroll.idpayroll = expensepayroll.idpayroll "
                           + "JOIN expenselink ON expenselink.idparent = expensepayroll.idexp "
                           + "JOIN expenselast on expenselast.idexp = expenselink.idchild "
                           + "WHERE payroll.idcon = parasubcontract.idcon  AND payroll.fiscalyear =  " + (esercizio - 1) +
                           ") "
                           + "AND   exhibitedcud.fiscalyear = " + (esercizio - 1) + " "
                           + "AND   ISNULL(service.certificatekind,'')<> 'U' ";

            DataTable t = Meta.Conn.SQLRunner(query);
            if (t.Rows.Count > 0) {
                string errore =
                    "Ci sono CUD allegati a contratti che a loro volta non generano CUD (es. assegnisti di ricerca)";
                foreach (DataRow r in t.Rows) {
                    errore += "\nn° " + r["ncon"] + " del " + r["ycon"] + "-" + r["description"];
                }
                errore += "\nL'operazione è stata annullata.";
                show(this, errore);
                return false;
            }
            return true;
        }



        private void btnSalva_Click(object sender, System.EventArgs e) {
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK) {
                txtPercorso.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void richTextBox1_LinkClicked(object sender, System.Windows.Forms.LinkClickedEventArgs e) {
            runProcess(e.LinkText, true);
        }

        class Colonna : IComparable {
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
                if (c.riga == riga) {
                    return colorder - c.colorder;
                }
                return riga - c.riga;
            }
        }

        private string getNomeColonnaExcel(List<Colonna> list, object quadro, object riga, object colonna) {
            foreach (Colonna c in list) {
                if (c.quadro.Equals(quadro) && c.colonna.Equals(colonna) && !c.riga.Equals(riga)) {
                    return quadro + "-col" + colonna + "-" + c.riga;
                }
            }
            return quadro + "-col" + colonna;
        }

        private void visualizzaQuadroInExcel(string record) {
            string filtroQuadro = "";
            if (record == "A") filtroQuadro = "quadro in ('HRA')";
            if (record == "B") filtroQuadro = "quadro in ('HRB')";
            if ((record == "DG") || (record == "DH")) filtroQuadro = "quadro in ('HRD','DA001','DA002','DA003','IND')";
            if (record == "H") filtroQuadro = "quadro in ('HRH','AU')";
            if (record == "G")
                filtroQuadro =
                    "quadro in ('HRG', 'DB001','DB100','DB601','DB602','DB603','DB604','DB605','DB606','DB607','DB608','DB609','DB610','DC001','DN001')";
            Cursor = Cursors.WaitCursor;

            DataTable tMod770 = calcolaCertificazioneUnica(((record == "H") || (record == "DH") || (record == "B")), false);
            // simuliamo la generazione del record H
            if (tMod770 == null) {
                show(this, "Errore nella letture dei dati per il record " + record);
                return;
            }

            DataRow[] righe770 = tMod770.Select(filtroQuadro, "progr,modulo");
            if (righe770.Length == 0) {
                show(this, "Non ci sono dati per il record " + record);
                return;
            }
            Object valore;
            List<Colonna> lColonne = new List<Colonna>();
            foreach (DataRow r in righe770) {
                string filtro = "frame='" + r["quadro"] + "' and colnumber='" + r["colonna"] + "'";
                if ((r["quadro"].ToString() == "IND") || (r["quadro"].ToString() == "NN") ||
                    (r["quadro"].ToString() == "FIR")) continue;
                DataRow[] rr = DS.cu_details.Select(filtro);
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
            if ((record == "DG") || (record == "DH")) {
                // quadro + "-col" + colonna;
                // Le colonne di seguito elencate non appartengono al tracciato ma sono valide ai fini della stampa
                // e contengono l'indirizzo , l'email del percipiente e il campo idreg
                t.Columns.Add("IND-col001", typeof(string)); // cognome e  nome
                t.Columns.Add("IND-col002", typeof(string)); // indirizzo
                t.Columns.Add("IND-col003", typeof(string)); // nazione
                t.Columns.Add("IND-col004", typeof(string)); // idreg
                t.Columns.Add("IND-col005", typeof(string)); // email
            }


            t.Columns.Add("progr", typeof(int));
            t.Columns.Add("modulo", typeof(int));

            int progr = -1;
            int modulo = -1;
            DataRow riga = null;
            foreach (DataRow r in righe770) {
                if (progr != (int)r["progr"] || modulo != (int)r["modulo"]) {
                    progr = (int)r["progr"];
                    modulo = (int)r["modulo"];
                    riga = t.NewRow();
                    riga["progr"] = progr;
                    riga["modulo"] = modulo;
                    t.Rows.Add(riga);
                }
                string campoCodice = getNomeColonnaExcel(lColonne, r["quadro"], r["riga"], r["colonna"]);

                if (riga[campoCodice] != DBNull.Value) {
                    show(this, "Il campo " + campoCodice +
                        " è stato assegnato due volte (modulo:" + modulo +
                                          ", progr." + progr + "riga[campoCodice] " + riga[campoCodice].ToString());
                }

                if ((r["quadro"].ToString() != "IND") && (r["quadro"].ToString() != "NN") &&
                    (r["quadro"].ToString() != "FIR")) {
                    formattaCampoNonPosizionale(r, out valore, false);
                    riga[campoCodice] = valore;
                }
                else {
                    if (campoCodice == "IND-col004") {
                        riga[campoCodice] = "#idreg: " + r["intero"]; // idreg
                    }
                    else {
                        riga[campoCodice] = r["stringa"]; // altri campi indirizzo
                    }
                }
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
            visualizzaLegenda(
                "frame in ('HRG', 'HRG', 'DB001','DB100','DB601','DB602','DB603','DB604','DB605','DB606','DB607','DB608','DB609','DB610','DC001','DN001')");
        }

        private void buttonLegendaH_Click(object sender, EventArgs e) {
            visualizzaLegenda("frame in ('HRH','AU')");
        }

        private void visualizzaLegenda(string filtroQuadro) {
            Cursor = Cursors.WaitCursor;
            DataRow[] legenda = DS.cu_details.Select(filtroQuadro, "colorder");
            DataTable t = new DataTable();
            t.Columns.Add("Quadro", typeof(System.String));
            t.Columns.Add("Colonna", typeof(System.String));
            t.Columns.Add("Descrizione", typeof(System.String));
            t.Columns.Add("Formato", typeof(System.String));
            t.Columns.Add("Posizione", typeof(System.Int32));
            t.Columns.Add("Lunghezza campo", typeof(System.Int32));
            t.Columns.Add("Sezione", typeof(System.String));
            t.Columns.Add("Valori ammessi", typeof(System.String));
            foreach (DataRow r in legenda) {
                t.Rows.Add(r["frame"], r["colnumber"], r["description"], r["format"], r["position"], r["fieldlen"],
                    r["section"], r["admittedvalues"]);
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
                if (tPrestAttive.Select("idser='" + rp["idser"] + "'").Length > 0) {
                    switch (rp["rec770kind"].ToString().ToUpper()) {
                        case "G":
                            lg.Add(rp["idser"] + " - " + rp["description"]);
                            break;
                        case "H":
                            lh.Add(rp["idser"] + " - " + rp["description"]);
                            break;
                        default:
                            ll.Add(rp["idser"] + " - " + rp["description"]);
                            break;
                    }
                }
                else {
                    switch (rp["rec770kind"].ToString().ToUpper()) {
                        case "G":
                            ln.Add("G - " + rp["idser"] + " - " + rp["description"]);
                            break;
                        case "H":
                            ln.Add("H - " + rp["idser"] + " - " + rp["description"]);
                            break;
                        default:
                            ln.Add("* - " + rp["idser"] + " - " + rp["description"]);
                            break;
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
                       + esercizio
                       +
                       @" left outer join certificationmodel on service.certificatekind=certificationmodel.idcertificationmodel
                        where " + filtroPrestazioni;
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
                           "exhibitedcud.fiscalyear = " + (esercizio - 1) + ") " +
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
            DateTime TrediciGennAnnoRedditi = new DateTime(esercizio - 1, 1, 13);
            DateTime DodiciGennAnnoDichiar = new DateTime(esercizio, 1, 12);
            QueryHelper QHS = Meta.Conn.GetQueryHelper();
            string query = " SELECT " +
                           "expense.idreg, " +
                           "registry.title, " +
                           "service.codeser, " +
                           "service.description, " +
                           "expense.idexp, " +
                           (esercizio - 1) + "as ymov," +
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
                           "JOIN paymenttransmission  " +
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
                           "AND expensevar.yvar <= " + (esercizio - 1) +
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
                           (esercizio - 1) + "as ymov," +
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
                           "AND YEAR(paymenttransmission.transmissiondate)= " + (esercizio - 1) +
                           "AND service.rec770kind = 'H' " +
                           "AND ((SELECT expenseyear.amount from expenseyear  " +
                           "where expenseyear.idexp = expenselast.idexp) " +
                           "+ ISNULL( " +
                           "(SELECT SUM(amount) FROM expensevar " +
                           "WHERE expensevar.idexp = expense.idexp " +
                           "AND expensevar.yvar <= " + (esercizio - 1) +
                           "AND ISNULL(autokind,0) <> 4) " +
                           ",0)) > 0 " +
                           "AND (SELECT count(*) from expensetax " +
                           "WHERE expensetax.idexp=expense.idexp) > 0";

            DataTable t = DataAccess.SQLRunner(Meta.Conn, query);

            return t;
        }

        private bool verificaDomFiscaleNonResidenti(int idreg, DateTime date) {
            // Se il percipiente è non residente si verifica che alla 
            // data di riferimento esista almeno un domicilio fiscale in Italia
            if (date == QueryCreator.EmptyDate()) return false;
            QueryHelper QHS = Meta.Conn.GetQueryHelper();
            // Verifico esistenza di una residenza all'estero alla data di riferimento
            object idDomFiscale = Meta.Conn.DO_READ_VALUE("address",
                QHS.CmpEq("codeaddress", "07_SW_DOM"), "idaddress");
            object idResidenza = Meta.Conn.DO_READ_VALUE("address",
                QHS.CmpEq("codeaddress", "07_SW_DEF"), "idaddress");

            string filter = QHS.AppAnd(QHS.CmpEq("idreg", idreg),
                QHS.CmpEq("idaddresskind", idResidenza),
                QHS.CmpEq("ISNULL(flagforeign, 'N')", 'S'),
                "(" + QHS.quote(date) + " BETWEEN start AND ISNULL(stop," +
                QHS.quote(date) + "))");

            object idNation = Meta.Conn.DO_READ_VALUE("registryaddress", filter, "idnation");
            if ((idNation != DBNull.Value) && (idNation != null)) {
                // In presenza di un indirizzo di residenza estero verifico l''esistenza  
                // di un domicilio fiscale in Italia alla data di riferimento
                filter = QHS.AppAnd(QHS.CmpEq("idreg", idreg),
                    QHS.CmpEq("idaddresskind", idDomFiscale),
                    QHS.CmpEq("ISNULL(flagforeign, 'N')", 'N'),
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
            DateTime PrimoGennAnnoRedditi = new DateTime(esercizio - 1, 1, 1);
            DateTime TrentunoDicAnnoRedditi = new DateTime(esercizio - 1, 12, 31);
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
                if (!verificaDomFiscaleNonResidenti(idreg, PrimoGennAnnoRedditi)) {
                    z.Rows.Add("Altri Pagamenti record G", r["idreg"], r["title"],
                        r["ymov"], r["nmov"], r["codeser"], r["description"],
                        "Non ha un domicilio fiscale in Italia valido alla data",
                        PrimoGennAnnoRedditi);
                }

                if (!verificaDomFiscaleNonResidenti(idreg, TrentunoDicAnnoRedditi)) {
                    z.Rows.Add("Altri Pagamenti record G", r["idreg"], r["title"],
                        r["ymov"], r["nmov"], r["codeser"], r["description"],
                        "Non ha un domicilio fiscale in Italia valido alla data",
                        TrentunoDicAnnoRedditi);
                }

                if (!verificaDomFiscaleNonResidenti(idreg, PrimoGennAnnoDichiar)) {
                    z.Rows.Add("Altri Pagamenti record G", r["idreg"], r["title"],
                        r["ymov"], r["nmov"], r["codeser"], r["description"],
                        "Non ha un domicilio fiscale in Italia  valido alla data",
                        PrimoGennAnnoDichiar);
                }
            }
            return z;
        }

        private DataTable controllaNonResidentiRecordH() {
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
                if (!verificaDomFiscaleNonResidenti(idreg, PrimoGennAnnoDichiarazione)) {
                    z.Rows.Add("Pagamenti record H", r["idreg"], r["title"],
                        r["ymov"], r["nmov"], r["codeser"], r["description"],
                        "Non ha un domicilio fiscale in Italia valido alla data",
                        PrimoGennAnnoDichiarazione);
                }
            }
            return z;
        }

        private DataTable controllaRecordH() {
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
                                            (idmot != "A") && (idmot != "M") && (idmot != "B") ||
                                            (certificatekind == "U"))) {
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
                                                                               (idmot != "A") ||
                                                                               (certificatekind == "U"))) {
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
                                            (idmot != "A") && (idmot != "M") && (idmot != "B") ||
                                            (certificatekind == "U"))) {
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
                                                                               (idmot != "A") ||
                                                                               (certificatekind == "U"))) {
                    z.Rows.Add(r["active"], r["idser"], r["description"], r["rec770kind"],
                        r["idmot"], r["module"], r["certificate"], r["cisonoritfiscali"],
                        "Se il modulo è PROFESSIONALE e non si tratta di  'Diritti d'autore per titolari part. IVA' " +
                        "allora il record770 deve essere H, " +
                        "la causale deve essere A e non si deve usare il modello CUD");
                }

                if ((module == "OCCASIONALE") && ((rec770kind != "H") ||
                                                  (idmot != "M") && (idmot != "B") ||
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
                        "Se si usa il modello CUD allora il record770 deve essere G, " +
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
            DataTable z = controllaRecordH();
            if (z.Rows.Count == 0) {
                show(this,
                    @"Non ci sono problemi di configurazione delle prestazioni per quanto riguarda il record H");
            }
            exportclass.DataTableToExcel(z, true);
        }

        private void generaCertificazioneUnica(bool recordH, TipoGenerazione generazioneSelezionata) {
            DataTable tMod770 = calcolaCertificazioneUnica(recordH, generazioneSelezionata == TipoGenerazione.stampa ||
                                                                  generazioneSelezionata == TipoGenerazione.mail);
            if (tMod770 == null) return;

            if (generazioneSelezionata == TipoGenerazione.salvataggio) {
                TextWriter tw = getStreamWriter();
                if (tw == null) return;

                salvaCertificazioneUnica(tw, tMod770.DataSet, recordH);
                return;
            }

            if (generazioneSelezionata == TipoGenerazione.stampa) {
                generaStampa(recordH, tMod770);
            }

            if (generazioneSelezionata == TipoGenerazione.mail) {
                inviaMailCollaboratori(recordH, tMod770);
                Thread.Sleep(5000);
            }
        }

        private DataTable calcolaCertificazioneUnica(bool recordH, bool forPrint) {
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
            object[] parametriA = new object[] { };
            DataSet ds_RecordA = Meta.Conn.CallSP("exp_certificazioneunica_a_" + esercizio, parametriA, 60 * 60,
                out errMsg);
            if (ds_RecordA == null) {
                show(this,
                    "Si è verificato il seguente errore nel calcolo del Record A della  certificazione unica:"
                    + "\n" + errMsg + "\nRiprovare o chiamare l'ASSISTENZA");
                Cursor = null;
                return null;
            }
            string print = forPrint
                ? "S"
                : "N";

            DataSet ds = new DataSet();
            DataTable tRecordA = ds_RecordA.Tables[0];

            ds.Merge(tRecordA);

            int nRecordH = 0;
            int nRecordG = 0;
            object[] parametriH = new object[] { CF };
            if (recordH) {
                DataTable tPercipientiRecordH = new DataTable();
                tPercipientiRecordH.Columns.Add("idreg", typeof(System.Int32));
                tPercipientiRecordH.Columns.Add("progrCom", typeof(System.Int32));
                int progrComCorrettive = 0;
                int progrComCF = 0;
                //Esportazione normale
                if ((ListaCF.Count == 0) && (progressiviHRD06.Count == 0)) {
                    DataSet ds1 = Meta.Conn.CallSP("exp_certificazioneunica_percipienti_h_" + esercizio, parametriH,
                        60 * 60,
                        out errMsg);
                    if (ds1 == null) {
                        show(this,
                            "Si è verificato il seguente errore nel calcolo dei percipienti della  certificazione unica record H:"
                            + "\n" + errMsg + "\nRiprovare o chiamare l'ASSISTENZA");
                        Cursor = null;
                        return null;
                    }

                    tPercipientiRecordH = ds1.Tables[0];
                }

                //Esportazione del set di CF importato
                if (ListaCF.Count > 0 && (progressiviHRD06.Count == 0)) {
                    pBarAvanzamento.Maximum = ListaCF.Count;
                    pBarAvanzamento.Value = 0;
                    foreach (object s in ListaCF) {
                        progrComCF += 1;
                        pBarAvanzamento.Increment(1);
                        DataSet ds1 = Meta.Conn.CallSP("exp_certificazioneunica_percipienti_h_" + esercizio,
                            new object[] { s }, 60 * 60,
                            out errMsg);
                        if (ds1 == null) {
                            show(this,
                                "Si è verificato il seguente errore nel calcolo del percipiente CF: " + s + "  della  certificazione unica record H:"
                                + "\n" + errMsg + "\nRiprovare o chiamare l'ASSISTENZA");
                            Cursor = null;
                            return null;
                        }
                        if (ds1.Tables[0].Rows.Count == 0) {
                            show(this,
                                "Si è verificato il seguente errore nel calcolo del percipiente CF: " + s + " della  certificazione unica record H:"
                                + "\n" + " non sono estratti dati " + "\nRiprovare o chiamare l'ASSISTENZA");
                            Cursor = null;
                            return null;
                        }
                        DataRow row1 = tPercipientiRecordH.NewRow();
                        row1["idreg"] = ds1.Tables[0].Rows[0]["idreg"];
                        row1["progrCom"] = progrComCF;
                        tPercipientiRecordH.Rows.Add(row1);

                    }
                    pBarAvanzamento.Value = 0;
                }

                // solo comunicazioni correttive o di annullamento, non possono essere mischiate con le altre 
                if (progressiviHRD06.Count > 0) {
                    pBarAvanzamento.Maximum = progressiviHRD06.Keys.Count;
                    pBarAvanzamento.Value = 0;
                    foreach (object s in progressiviHRD06.Keys) {
                        progrComCorrettive += 1;
                        pBarAvanzamento.Increment(1);
                        DataSet ds1 = Meta.Conn.CallSP("exp_certificazioneunica_percipienti_h_" + esercizio,
                            new object[] { s }, 60 * 60,
                            out errMsg);
                        if (ds1 == null) {
                            show(this,
                                "Si è verificato il seguente errore nel calcolo del percipiente CF: " + s + "  della  certificazione unica sostitutiva record H:"
                                + "\n" + errMsg + "\nRiprovare o chiamare l'ASSISTENZA");
                            Cursor = null;
                            return null;
                        }
                        if (ds1.Tables[0].Rows.Count == 0) {
                            show(this,
                                "Si è verificato il seguente errore nel calcolo del percipiente CF: " + s + " della  certificazione unica sostitutiva record H:"
                                + "\n" + " non sono estratti dati " + "\nRiprovare o chiamare l'ASSISTENZA");
                            Cursor = null;
                            return null;
                        }
                        DataRow row = tPercipientiRecordH.NewRow();
                        row["idreg"] = ds1.Tables[0].Rows[0]["idreg"];
                        row["progrCom"] = progrComCorrettive;
                        tPercipientiRecordH.Rows.Add(row);

                    }
                    pBarAvanzamento.Value = 0;
                }


                int newProgrCom = 1;
                int progrCom;
                pBarAvanzamento.Maximum = tPercipientiRecordH.Rows.Count;
                pBarAvanzamento.Value = 0;
                foreach (DataRow r in tPercipientiRecordH.Select()) {
                    progrCom = newProgrCom;
                    pBarAvanzamento.Increment(1);
                    // CallSPParameterDataSet(string sp_name, string[] ParamName, SqlDbType[] ParamType, 
                    //int[] ParamTypeLength, ParameterDirection[] ParamDirection, ref object[] ParamValues,
                    //int timeout, out string ErrMsg){

                    string[] param = new string[] { "@idreg", "@progrCom", "@print", "@newprogrCom" };
                    SqlDbType[] types = new SqlDbType[]
                    {SqlDbType.Int, SqlDbType.Int, SqlDbType.VarChar, SqlDbType.Int,};
                    int[] typelen = new int[] { 4, 4, 4, 4 };
                    ParameterDirection[] dir = new ParameterDirection[] {
                        ParameterDirection.Input, ParameterDirection.Input, ParameterDirection.Input,
                        ParameterDirection.Output
                    };

                    object[] paramvalues = new object[] { r["idreg"], progrCom, print, newProgrCom };
                    //DataSet ds2 = Meta.Conn.CallSP("exp_certificazioneunica_h_" + esercizio, parametri, 60 * 60, out errMsg);
                    DataSet ds2 = Meta.Conn.CallSPParameterDataSet("exp_certificazioneunica_h_" + esercizio, param,
                        types,
                        typelen, dir, ref paramvalues, 60 * 60, out errMsg);
                    newProgrCom = CfgFn.GetNoNullInt32(paramvalues[3]);

                    if (ds2 == null) {
                        show(this,
                            "Si è verificato il seguente errore nel calcolo del Record D-H della  certificazione unica:"
                            + "\n" + errMsg + "\nRiprovare o chiamare l'ASSISTENZA");
                        Cursor = null;
                        return null;
                    }

                    DataTable tPercipienteRecordH = ds2.Tables[0];
                    DataRow[] ccf =
                        tPercipienteRecordH.Select(QHC.AppAnd(QHC.CmpEq("quadro", "HRH"), QHC.CmpEq("colonna", "04")));
                    if (ccf.Length == 0) {
                        show("Il creditore di codice " + r["idreg"] + " non ha codice fiscale.", "Errore");
                        continue;
                    }

                    DataRow rCf = ccf[0];
                    string currentCF = rCf["stringa"].ToString();
                    if (progressiviHRD06.ContainsKey(currentCF)) {
                        if (progressiviHRD09[currentCF].ToString().ToUpper() == "A") {
                            // la comunicazione va annullata pertanto di quel beneficiario trasmettiamo solo i dati anagrafici 
                            // e non quelli fiscali (ovvero il solo record D)
                            object[] paramvaluesD = new object[] { r["idreg"], r["progrCom"], "H", null, print };
                            DataSet dsD = Meta.Conn.CallSP("exp_certificazioneunica_d_" + esercizio, paramvaluesD, 60 * 60,
                                out errMsg);
                            if (dsD == null) {
                                show(this,
                                    "Si è verificato il seguente errore nel calcolo della  certificazione sostitutiva unica Record D-H:"
                                    + "\n" + errMsg + "\nRiprovare o chiamare l'ASSISTENZA");
                                Cursor = null;
                                return null;
                            }
                            tPercipienteRecordH = dsD.Tables[0];
                        }
                        gestisciSostituzionioAnnullamenti(tPercipienteRecordH, currentCF, r["progrCom"]);
                    }

                    //ds.Merge(tPercipienteRecordD);
                    ds.Merge(tPercipienteRecordH);
                }
                pBarAvanzamento.Value = 0;
            }

            else {
                DataTable tPercipientiRecordG = new DataTable();
                tPercipientiRecordG.Columns.Add("idreg", typeof(System.Int32));
                tPercipientiRecordG.Columns.Add("progrCom", typeof(System.Int32));
                int progrComCorrettive = 0;
                int progrComCF = 0;
                //Esportazione normale
                if ((ListaCF.Count == 0) && (progressiviHRD06.Count == 0)) {
                    object[] parametriG = new object[] { CF };
                    DataSet ds3 = Meta.Conn.CallSP("exp_certificazioneunica_percipienti_g_" + esercizio, parametriG,
                        60 * 60,
                        out errMsg);
                    if (ds3 == null) {
                        show(this,
                            "Si è verificato il seguente errore nel calcolo dei percipienti della  certificazione unica Record G:"
                            + "\n" + errMsg + "\nRiprovare o chiamare l'ASSISTENZA");
                        Cursor = null;
                        return null;
                    }

                    tPercipientiRecordG = ds3.Tables[0];
                }

                //Esportazione del set di CF importato
                if (ListaCF.Count > 0) {
                    pBarAvanzamento.Maximum = ListaCF.Count;
                    pBarAvanzamento.Value = 0;
                    foreach (object s in ListaCF) {
                        pBarAvanzamento.Increment(1);
                        progrComCF += 1;
                        DataSet ds3 = Meta.Conn.CallSP("exp_certificazioneunica_percipienti_g_" + esercizio,
                            new object[] { s }, 60 * 60,
                            out errMsg);
                        if (ds3 == null) {
                            show(this,
                                "Si è verificato il seguente errore nel calcolo del percipiente CF: " + s + "  della certificazione unica sostitutiva record G:"
                                + "\n" + errMsg + "\nRiprovare o chiamare l'ASSISTENZA");
                            Cursor = null;
                            return null;
                        }

                        if (ds3.Tables[0].Rows.Count == 0) {
                            show(this,
                                "Si è verificato il seguente errore nel calcolo del percipiente CF: " + s + " della  certificazione unica sostitutiva record G:"
                                + "\n" + " non sono stati estratti dati " + "\nRiprovare o chiamare l'ASSISTENZA");
                            Cursor = null;
                            return null;
                        }
                        DataRow row1 = tPercipientiRecordG.NewRow();
                        row1["idreg"] = ds3.Tables[0].Rows[0]["idreg"];
                        row1["progrCom"] = progrComCF;
                        tPercipientiRecordG.Rows.Add(row1);
                    }
                    pBarAvanzamento.Value = 0;
                }
                // solo comunicazioni correttive o di annullamento, non possono essere mischiate con le altre 
                if (progressiviHRD06.Count > 0) {
                    pBarAvanzamento.Maximum = progressiviHRD06.Keys.Count;
                    pBarAvanzamento.Value = 0;
                    foreach (object s in progressiviHRD06.Keys) {
                        pBarAvanzamento.Increment(1);
                        progrComCorrettive += 1;
                        DataSet ds3 = Meta.Conn.CallSP("exp_certificazioneunica_percipienti_g_" + esercizio,
                            new object[] { s }, 60 * 60,
                            out errMsg);
                        if (ds3 == null) {
                            show(this,
                                "Si è verificato il seguente errore nel calcolo del percipiente CF: " + s + "  della certificazione unica sostitutiva record G:"
                                + "\n" + errMsg + "\nRiprovare o chiamare l'ASSISTENZA");
                            Cursor = null;
                            return null;
                        }

                        if (ds3.Tables[0].Rows.Count == 0) {
                            show(this,
                                "Si è verificato il seguente errore nel calcolo del percipiente CF: " + s + " della  certificazione unica sostitutiva record G:"
                                + "\n" + " non sono stati estratti dati " + "\nRiprovare o chiamare l'ASSISTENZA");
                            Cursor = null;
                            return null;
                        }

                        DataRow row1 = tPercipientiRecordG.NewRow();
                        row1["idreg"] = ds3.Tables[0].Rows[0]["idreg"];
                        row1["progrCom"] = progrComCorrettive;
                        tPercipientiRecordG.Rows.Add(row1);
                    }
                    pBarAvanzamento.Value = 0;
                }

                pBarAvanzamento.Maximum = tPercipientiRecordG.Rows.Count;
                pBarAvanzamento.Value = 0;
                foreach (DataRow r in tPercipientiRecordG.Select()) {
                    pBarAvanzamento.Increment(1);
                    object[] paramvalues = new object[] { r["idreg"], r["progrCom"], print };
                    DataSet ds2 = Meta.Conn.CallSP("exp_certificazioneunica_g_" + esercizio, paramvalues, 60 * 60,
                        out errMsg);
                    if (ds2 == null) {
                        show(this,
                            "Si è verificato il seguente errore nel calcolo della  certificazione unica Record D-G:"
                            + "\n" + errMsg + "\nRiprovare o chiamare l'ASSISTENZA");
                        Cursor = null;
                        return null;
                    }
                    DataTable tPercipienteRecordG = ds2.Tables[0];
                    DataRow rCf =
                        tPercipienteRecordG.Select(QHC.AppAnd(QHC.CmpEq("quadro", "HRG"), QHC.CmpEq("colonna", "04")))[0
                            ];
                    string currentCF = rCf["stringa"].ToString();

                    if (progressiviHRD06.ContainsKey(currentCF)) {
                        if (progressiviHRD09[currentCF].ToString().ToUpper() == "A") {
                            // la comunicazione va annullata pertanto di quel beneficiario trasmettiamo solo i dati anagrafici 
                            // e non quelli fiscali (ovvero il solo record D)
                            object[] paramvaluesD = new object[] { r["idreg"], r["progrCom"], "G", null, print };
                            DataSet dsD = Meta.Conn.CallSP("exp_certificazioneunica_d_" + esercizio, paramvaluesD, 60 * 60,
                                out errMsg);
                            if (dsD == null) {
                                show(this,
                                    "Si è verificato il seguente errore nel calcolo della  certificazione unica sostitutiva Record D-G:"
                                    + "\n" + errMsg + "\nRiprovare o chiamare l'ASSISTENZA");
                                Cursor = null;
                                return null;
                            }
                            tPercipienteRecordG = dsD.Tables[0];
                        }
                        gestisciSostituzionioAnnullamenti(tPercipienteRecordG, currentCF, r["progrCom"]);
                    }

                    //ds.Merge(tPercipienteRecordD);
                    ds.Merge(tPercipienteRecordG);
                }
                pBarAvanzamento.Value = 0;
            }

            // Calcolo il numero delle comunicaizoni G o H inviate da inserire in record B
            DataRow[] rD = ds.Tables[0].Select("(quadro='HRD')and(colonna='05')");
            if (recordH) {
                nRecordG = 0;
                nRecordH = rD.Length;
            }
            else {
                nRecordH = 0;
                nRecordG = rD.Length;
            }


            object[] parametriGH = new object[] { nRecordG, nRecordH, print };
            DataSet ds_RecordB = Meta.Conn.CallSP("exp_certificazioneunica_b_" + esercizio, parametriGH, 60 * 60,
                out errMsg);
            if (ds_RecordB == null) {
                show(this,
                    "Si è verificato il seguente errore nel calcolo del Record B della  certificazione unica:"
                    + "\n" + errMsg + "\nRiprovare o chiamare l'ASSISTENZA");
                Cursor = null;
                return null;
            }


            DataTable tRecordB = ds_RecordB.Tables[0];

            if (progressiviHRD06.Count > 0) {
                // INSERT INTO #recordb (progr, modulo, quadro, riga, colonna, intero) VALUES(1, 1,'HRB', 1, '010',0)
                // 10 Fornitura relativa all'invio di  certificazioni da annullare
                // Inserisce nel Record B le righe HRB 010 e HRB 011
                DataRow row = tRecordB.NewRow();
                row["progr"] = 1;
                row["modulo"] = 1;
                row["quadro"] = "HRB";
                row["riga"] = 1;
                row["colonna"] = "010";
                if (progressiviHRD09.ContainsValue("A"))
                    row["intero"] = 1;
                else
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
                if (progressiviHRD09.ContainsValue("S"))
                    row1["intero"] = 1;
                else
                    row1["intero"] = 0;

                tRecordB.Rows.Add(row1);
            }

            ds.Merge(tRecordB);
            DataTable tMod770 = ds.Tables[0];
            dataGrid.DataBindings.Clear();
            dataGrid.DataSource = null;
            dataGrid.TableStyles.Clear();
            HelpForm.SetDataGrid(dataGrid, tMod770);
            formatgrids fg = new formatgrids(dataGrid);
            fg.AutosizeColumnWidth();

            foreach (DataRow r in ds.Tables[0].Select()) {
                string filtro = "frame='" + r["quadro"] + "' and colnumber='" + r["colonna"] + "'";
                if (r["quadro"].ToString() == "IND") {
                    // IND sono le righe dell'indirizzo per la stampa con pagina bianca
                    continue;
                }

                if (r["quadro"].ToString() == "FIR") {
                    // FIR Dicitura con la firma del rappresentante firmatario, si può personalizzare nel caso non sia il Rettore
                    continue;
                }
                if (r["quadro"].ToString() == "NN") {
                    // NN sono le note, aggiunte solo per la stampa
                    continue;
                }

                DataRow[] rFormato = DS.cu_details.Select(filtro);
                if (rFormato.Length != 1) {
                    show(this, "Formato sconosciuto: " + filtro);
                    Cursor = null;
                    return null;
                }
                // Per la Stampa se il formato è casella barrata, barra con X il relativo campo 
                // se il valore è 1
                if (forPrint && rFormato[0]["format"].ToString() == "CB") {
                    if (r["stringa"].ToString() == "" && r["intero"].ToString() != "") {
                        string old = r["intero"].ToString();
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


            return tMod770;
        }

        void gestisciSostituzionioAnnullamenti(DataTable T, string currentCF, object progrCom) {

            if (progressiviHRD06.ContainsKey(currentCF)) {
                DataRow rr = T.NewRow();
                rr["progr"] = progrCom;
                rr["modulo"] = 1;
                rr["quadro"] = "HRD";
                rr["riga"] = 1;
                rr["colonna"] = "06";
                rr["stringa"] = progressiviHRD06[currentCF].ToString().PadLeft(17, '0');
                T.Rows.Add(rr);

                rr = T.NewRow();
                rr["progr"] = progrCom;
                rr["modulo"] = 1;
                rr["quadro"] = "HRD";
                rr["riga"] = 1;
                rr["colonna"] = "07";
                rr["stringa"] = progressiviHRD07[currentCF].ToString().PadLeft(6, '0');
                T.Rows.Add(rr);

                rr = T.NewRow();
                rr["progr"] = progrCom;
                rr["modulo"] = 1;
                rr["quadro"] = "HRD";
                rr["riga"] = 1;
                rr["colonna"] = "09";
                rr["stringa"] = progressiviHRD09[currentCF].ToString(); // sostituisci_o_annulla
                T.Rows.Add(rr);
            }
            else {
                if (progressiviHRD06.Count > 0) {
                    show(
                        "Il codice fiscale " + currentCF + " non è stato trovato nello schema importato",
                        "Errore");
                }
            }

        }

        bool controlliGenerazioneG(bool RecordH) {
            if (RecordH) return true;
            if (!verificaContrattiNonPagati()) return false; // G
            if (!verificaPrestazioniCertificazioniCUD()) return false; // G
            if (!verificaPrestazioniCertificazioniInNonCUD()) return false; // G
            if (!verificaContrattiRecordG()) return false;
            return true;
        }

        bool controlliGenerazioneH(bool RecordH) {
            if (!RecordH) return true;
            if (!verificaPrestazioniSenzaCausale()) return false; // H
            if (!verificaPresenzaProvvigioni()) return false; // H
            return true;
        }

        private void btnNonResidG_Click(object sender, EventArgs e) {
            DataTable z = controllaNonResidentiRecordG();
            if (z.Rows.Count == 0) {
                show(this, "Non ci sono non residenti con domicilio fiscale non valido (G)");
            }
            exportclass.DataTableToExcel(z, true);
        }

        private void btnNonResidH_Click(object sender, EventArgs e) {
            DataTable z = controllaNonResidentiRecordH();
            if (z.Rows.Count == 0) {
                show(this, "Non ci sono non residenti con domicilio fiscale non valido (H)");
            }
            exportclass.DataTableToExcel(z, true);
        }

        private void buttonLegendaI_Click(object sender, EventArgs e) {
            visualizzaLegenda("frame in ('SY001','SY002','SY003','SY004','SY005','SY006')");
        }

        private void buttonRecordI_Click(object sender, EventArgs e) {
            visualizzaQuadroInExcel("I");
        }

        private void btnLegendaA_Click(object sender, EventArgs e) {
            visualizzaLegenda("frame = 'HRA'");
        }

        private void btnLegendaB_Click(object sender, EventArgs e) {
            visualizzaLegenda("frame = 'HRB'");
        }

        private void btnLegendaD_Click(object sender, EventArgs e) {
            visualizzaLegenda("frame IN ('HRD', 'DA001','DA002','DA003')");
        }

        private void btnDatiA_Click(object sender, EventArgs e) {
            visualizzaQuadroInExcel("A");
        }

        private void btnDatiB_Click(object sender, EventArgs e) {
            visualizzaQuadroInExcel("B");
        }



        private void btnLegendaDG_Click(object sender, EventArgs e) {
            visualizzaLegenda("frame IN ('HRD', 'DA001','DA002','DA003')");
        }

        private void btnDatiDH_Click(object sender, EventArgs e) {
            visualizzaQuadroInExcel("DH");

        }

        private void btnDatiDG_Click(object sender, EventArgs e) {
            visualizzaQuadroInExcel("DG");
        }

        private void btnLegendaDH_Click(object sender, EventArgs e) {
            visualizzaLegenda("frame IN ('HRD', 'DA001','DA002','DA003')");
        }



        private void getFolder() {
            DialogResult dr = folderBrowserDialog1.ShowDialog(this);
            if (dr == DialogResult.OK) {
                txtPercorso.Text = folderBrowserDialog1.SelectedPath;
            }
        }



        class Collaboratore : IComparable {
            public string cf;
            public string progr;
            public int modulo = 0;
            public string commento = "";
            public object idreg;
            public object email;
            public string name;
            public string surname;

            public Collaboratore(string cf, string progr, int modulo) {
                this.cf = cf;
                this.progr = progr;
                this.modulo = modulo;
            }

            public void addComment(string s) {
                if (s == "") return;
                if (commento == "") commento += " - ";
                commento += s;
            }

            public int CompareTo(Object obj) {
                Collaboratore c = (Collaboratore)obj;
                if (cf.CompareTo(c.cf) != 0) {
                    return cf.CompareTo(c.cf);
                }
                if (progr.CompareTo(c.progr) != 0) {
                    return progr.CompareTo(c.progr);
                }
                return modulo.CompareTo(c.modulo);
            }
        }

        void fillSortedList(DataTable tMod770, SortedList ht, Collaboratore co, int modulo, out string nome, out string cognome) {
            nome = "";
            cognome = "";

            if (tMod770 == null) return;
            if (ht == null) return;
            if (co == null) return;
            Meta.closeDisabled = true;
            string cf = co.cf;
            string progr = co.progr;


            string filtroProgr = QHC.CmpEq("progr", progr);

            string filtroModulo = QHC.CmpEq("modulo", modulo);
            string filterDatiResp = QHC.CmpEq("quadro", "HRB"); //consente di esportare anche l'header B
            string filterAll = QHC.DoPar(QHC.AppOr(QHC.AppAnd(filtroProgr, filtroModulo), filterDatiResp));

            string filtroCognomeODenominazione = QHC.AppAnd(QHC.CmpEq("quadro", "DA002"), QHC.CmpEq("colonna", "002"), filtroProgr);
            string filtroNome = QHC.AppAnd(QHC.CmpEq("quadro", "DA002"), QHC.CmpEq("colonna", "003"), filtroProgr);

            DataRow[] arrCognome = tMod770.Select(filtroCognomeODenominazione);
            DataRow[] arrNome = tMod770.Select(filtroNome);

            if (arrCognome.Length > 0) cognome = arrCognome[0]["stringa"].ToString();  //cognome o denominazione
            if (arrNome.Length > 0) nome = arrNome[0]["stringa"].ToString();  //nome se presente
            if (nome == "") nome = null;
            //show(filterAll + cf  + progr);
            foreach (DataRow rRecordG in tMod770.Select(filterAll)) {
                string campo = rRecordG["quadro"].ToString() + rRecordG["colonna"];


                //if (campo == "DA002002") {
                //    cognome = rRecordG["stringa"].ToString(); //cognome o denominazione
                //}
                //if ((campo == "DA002003") && (rRecordG["stringa"].ToString() != "")) {
                //    nome = rRecordG["stringa"].ToString();
                //}
                if (CfgFn.GetNoNullInt32(rRecordG["modulo"]) != modulo) continue;
                ht["num_modello"] = modulo.ToString().PadLeft(2, '0'); //salva il progressivo per valorizzare Mod.N.
                //show(ht["num_modello"] + " " + cognome + " " + nome);
                switch (campo) {
                    case "DC001038": {
                            salvaColonnaMultiCasellaMesi(ht, campo, rRecordG["stringa"].ToString());
                            break;
                        }
                    case "DC001037": {
                            salvaColonnaCasellaBarrataSingola(ht, campo, rRecordG["stringa"].ToString());
                            break;
                        }
                    case "DC001040": {
                            salvaColonnaMultiCasellaMesi(ht, campo, rRecordG["stringa"].ToString());
                            break;
                        }
                    case "DC001050": {
                            salvaColonnaMultiCasellaMesi(ht, campo, rRecordG["stringa"].ToString());
                            break;
                        }
                    case "DC001049": {
                            salvaColonnaCasellaBarrataSingola(ht, campo, rRecordG["stringa"].ToString());
                            break;
                        }

                    case "DB001006": {
                            // numero dei giorni per i quali spettano le detrazioni
                            salvaColonnaNumeroGiorniDetrazioni(ht, "DB001006", CfgFn.GetNoNullInt32(rRecordG["intero"]));
                            break;
                        }
                    case "DB602001": {
                            salvaColonnaDB60xxx(ht, "DB602", rRecordG["stringa"].ToString());
                            break;
                        }
                    case "DB603001": {
                            salvaColonnaDB60xxx(ht, "DB603", rRecordG["stringa"].ToString());
                            break;
                        }
                    case "DB604001": {
                            salvaColonnaDB60xxx(ht, "DB604", rRecordG["stringa"].ToString());
                            break;
                        }
                    case "DB605001": {
                            salvaColonnaDB60xxx(ht, "DB605", rRecordG["stringa"].ToString());
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
                    case "NN011": {
                            // Note NN
                            riempiNote(ht, rRecordG["stringa"].ToString());
                            break;
                        }
                    default:
                        salvaNormaleCampo(ht, campo, rRecordG);
                        break;
                }
            }
            if (modulo == 1) {
                object esercizio = Meta.GetSys("esercizio");
                ht["printdate_a"] = esercizio.ToString();
                ht["printdate_g"] = "28";
                ht["printdate_m"] = "02";
            }
            Meta.closeDisabled = false;
        }

        List<Collaboratore> getListaCollaboratoriDaMod770(DataTable tMod770, bool recordH) {
            List<Collaboratore> collaboratori = new List<Collaboratore>();

            //DataTable tComunicazioni = new DataTable("comunicazioni");
            //tComunicazioni.Columns.Add("progr", typeof (int));
            //tComunicazioni.Columns.Add("cf", typeof (string));
            string quadroHR = recordH ? "HRH" : "HRG";
            int modulo = 1;
            //Prende tutte le righe HRH 04 ossia una riga per ogni modulo salvato
            foreach (
                DataRow recCf in tMod770.Select(QHC.AppAnd(QHC.CmpEq("quadro", quadroHR), QHC.CmpEq("colonna", "04"), QHC.CmpEq("modulo", modulo)))) {
                Collaboratore co = new Collaboratore(recCf["stringa"].ToString(), recCf["progr"].ToString(),
                    CfgFn.GetNoNullInt32(recCf["modulo"]));

                DataRow[] emails = tMod770.Select(QHC.AppAnd(QHC.CmpEq("progr", co.progr), QHC.CmpEq("quadro", "IND"),
                    QHC.CmpEq("colonna", "005")));
                if (emails.Length > 0) co.email = emails[0]["stringa"];

                DataRow[] idregs = tMod770.Select(QHC.AppAnd(QHC.CmpEq("progr", co.progr), QHC.CmpEq("quadro", "IND"),
                    QHC.CmpEq("colonna", "004")));
                if (idregs.Length > 0) co.idreg = idregs[0]["intero"];

                DataRow[] names = tMod770.Select(QHC.AppAnd(QHC.CmpEq("progr", co.progr), QHC.CmpEq("quadro", "DA002"),
                    QHC.CmpEq("colonna", "003")));
                if (names.Length > 0) co.name = names[0]["stringa"].ToString();

                DataRow[] surnames = tMod770.Select(QHC.AppAnd(QHC.CmpEq("progr", co.progr), QHC.CmpEq("quadro", "DA002"),
                    QHC.CmpEq("colonna", "002")));
                 if (surnames.Length > 0) co.surname = surnames[0]["stringa"].ToString();

                //tComunicazioni.Rows.Add(recCf["progr"], recCf["stringa"]);
                int pos = collaboratori.BinarySearch(co);
                if (pos < 0) {
                    collaboratori.Insert(~pos, co);
                }
            }
            //Collaboratore prev = null;
            //int n = 0;
            foreach (Collaboratore curr in collaboratori) {
                DataRow[] rHrg04 = tMod770.Select(QHC.AppAnd(QHC.CmpEq("progr", curr.progr),
                    QHC.CmpEq("quadro", quadroHR), QHC.CmpEq("colonna", "04")));
                curr.addComment(rHrg04[0]["stringa"].ToString());
            }


            return collaboratori;
        }


        private bool generaStampa(bool recordH, DataTable tMod770) {
            QHS = Meta.Conn.GetQueryHelper();
            //Rimosso perchè consentiamo la generazione in tutti gli esercizi consentiti, ossia dal 2015 ad oggi
            //if (!Meta.GetSys("esercizio").Equals(2019)) {
            //    show(this, "Questa procedura produce solo modelli cud per l'anno 2019", "Errore");
            //    return false;
            //}
            if (CfgFn.GetNoNullInt32(Meta.GetSys("esercizio")) < 2015) {
                show(this, "Procedura non eseguibile nell'esercizio corrente.", "Errore");
                return false;
            }
            if (txtPercorso.Text == "") {
                getFolder();
                if (txtPercorso.Text == "") {
                    show(this,
                        "Occorre specificare la cartella in cui creare i modelli Certificazione Unica " + EsercStr + "", "errore");
                    return false;
                }
            }
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;
            string nomeModello = getNomeFileModello(recordH);

            string[] fnames = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, nomeModello);
            if (fnames.Length == 0) {
                show(
                    "File " + nomeModello + " non trovato nella cartella " + AppDomain.CurrentDomain.BaseDirectory,
                    "Errore");
                return false;
            }
            string fileDaCopiare = fnames[0];

            string fOrigin = fileDaCopiare;


            List<Collaboratore> collaboratori = getListaCollaboratoriDaMod770(tMod770, recordH);

            pBarAvanzamento.Minimum = 0;
            pBarAvanzamento.Maximum = collaboratori.Count;
            pBarAvanzamento.Value = 0;
            foreach (Collaboratore co in collaboratori) {
                Application.DoEvents();
                SortedList ht = new SortedList(campiPresiDallaLicenza);
                string nome, cognome;

                fillSortedList(tMod770, ht, co, 1, out nome, out cognome);


                string denominazione = cognome + "-";
                if (nome != "") {
                    denominazione = denominazione + nome + "-";
                }

                string pathCompleto = Path.Combine(txtPercorso.Text, getNomeCompleto(co.cf, co.progr.PadLeft(3, '0'), co.modulo, denominazione));

                PdfReader templateReader = new PdfReader(fOrigin);
                PdfWriter writer = new PdfWriter(pathCompleto);

                writer.SetCompressionLevel(5);
                writer.SetSmartMode(true);

                PdfDocument document = new PdfDocument(templateReader, writer);

                if (!chkConIndirizzo.Checked) {
                    // Voglio rimuovere la prima pagina
                    document.RemovePage(document.GetFirstPage());
                }
                if (!chkDonazione.Checked) {
                    // Voglio rimuovere la penultima e l'ultima pagina
                    document.RemovePage(document.GetLastPage());
                    document.RemovePage(document.GetLastPage());
                }

                PdfAcroForm form = PdfAcroForm.GetAcroForm(document, false);

                if (form != null) {
                    form.SetGenerateAppearance(true);
                    form.SetNeedAppearances(true);

                    var fields = form.GetFormFields();

                    foreach (DictionaryEntry entry in ht) {
                        string fieldID = entry.Key.ToString();
                        string fieldValue = entry.Value.ToString();

                        List<string> fieldIDvariants = new List<string>();
                        //variante nomecampo
                        fieldIDvariants.Add(fieldID);
                        //variante nomecampo_8x1000
                        fieldIDvariants.Add(fieldID + "_8x1000");
                        //varianti nomecampo_pX dove X è il numero pagina
                        for (int i = 0; i < document.GetNumberOfPages(); i++) {
                            fieldIDvariants.Add(fieldID + "_p" + i.ToString());
                        }

                        var matchedFields = fields.Where(field => fieldIDvariants.Contains(field.Key));
                        matchedFields._forEach(matchedField => { 
                            matchedField.Value.SetValue(fieldValue);
                            matchedField.Value.SetReadOnly(true);
                        });
                    }

                    // Suffissi per identificare i campi dei moduli aggiuntivi
                    string[] suffissi = new string[] { "_bis", "_ter", "_quater", "_quin", "_sext", "_sept", "_oct", "_nov" };

                    int indicemodulo = 1;
                    int modulistampati = 0;
                    foreach (string suffisso in suffissi) {
                        indicemodulo++;
                        SortedList ht_moduloaggiuntivo = new SortedList();
                        fillSortedList(tMod770, ht_moduloaggiuntivo, co, indicemodulo, out nome, out cognome);
                        if (ht_moduloaggiuntivo.Count > 0) {
                            modulistampati++;
                            foreach (DictionaryEntry entry in ht_moduloaggiuntivo) {
                                // valorizzazione di un modulo supplementare
                                string fieldID = entry.Key.ToString() + suffisso;

                                if (fields.ContainsKey(fieldID)) {
                                    fields[fieldID].SetValue(entry.Value.ToString());
                                    fields[fieldID].SetReadOnly(true);
                                }
                            }
                        }
                    }

                    foreach (KeyValuePair<string, PdfFormField> entry in fields) {
                        entry.Value.SetReadOnly(true);
					}
                    form.FlattenFields();
                    //indici delle pagine del template
                    int indexFromRemove = (recordH) ? 3 : 7;
                    int indexToRemove = (recordH) ? 10 : 10;

                    if (chkConIndirizzo.Checked) {
                        indexFromRemove++;
                        indexToRemove++;
                    }
                    indexFromRemove += modulistampati;

                    //pagine inutilizzate da cancellare 
                    int nPages = indexToRemove - indexFromRemove + 1;
                    for (int i = 0; i < nPages; i++) {
                        document.RemovePage(indexFromRemove);
                    }

                    try {
                        writer.Flush();
                        document.Close();
                        writer.Close();
                    }
                    catch (Exception e) {
                        QueryCreator.ShowError(this, "Errore salvando il file, probabilmente il percorso non esiste o il file è già aperto.", e.ToString());
                    }

                }

                pBarAvanzamento.Value += 1;
            }
            Cursor.Current = Cursors.Default;
            pBarAvanzamento.Value = 0;
            show(this,
                "Sono stati generati " + collaboratori.Count + " modelli Certificazione Unica (.pdf) nella cartella:\n"
                + txtPercorso.Text,
                "Salvataggio effettuato");
            return true;
        }

        string getNomeCompleto(string cf, string progr, int iModulo, string denominazione) {
            string modulo = iModulo.ToString().PadLeft(2, '0');
            string invalid = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            string nomeFile = denominazione + cf;
            foreach (char c in invalid) {
                nomeFile = nomeFile.Replace(c.ToString(), "");
            }

            return nomeFile + "-" + progr + "-" + modulo + ".pdf";
        }


        private bool inviaMailCollaboratori(bool recordH, DataTable tMod770) {
            QHS = Meta.Conn.GetQueryHelper(); QHS = Meta.Conn.GetQueryHelper();
            //if (!Meta.GetSys("esercizio").Equals(2019)) {
            //    show(this, "Questa procedura produce solo modelli cud per l'anno 2019", "Errore");
            //    // return;
            //}

            if (CfgFn.GetNoNullInt32(Meta.GetSys("esercizio")) < 2015) {
                show(this, "Procedura non eseguibile nell'esercizio corrente.", "Errore");
            }

            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;
            string nomeModello = getNomeFileModello(recordH);

            string[] fnames = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, nomeModello);
            if (fnames.Length == 0) {
                show(
                    "File " + nomeModello + " non trovato nella cartella " + AppDomain.CurrentDomain.BaseDirectory,
                    "Errore");
                return false;
            }
            string fileDaCopiare = fnames[0];
            string fOrigin = fileDaCopiare;

            List<Collaboratore> collaboratori = getListaCollaboratoriDaMod770(tMod770, recordH);
            List<Collaboratore> listaProblemi = new List<Collaboratore>();
            
            // commento momentaneamente l'assenza dell'email come errore bloccante
            // dovremo creare una gestione per memorizzare gli invii non effettuati  
            //foreach (Collaboratore co in collaboratori) {
            //    if (co.email == null || co.email.ToString() == "") {
            //        listaProblemi.Add(co);
            //    }
            //}
            if (listaProblemi.Count > 0) {
                string s = "";
                foreach (Collaboratore co in listaProblemi) {
                    string title = conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg", co.idreg), "title").ToString();
                    s += title + " (id " + co.idreg + ")\n";
                }
                frmListaProblemi f = new frmListaProblemi(0);
                f.txtProblemi.Text = s;
                createForm(f, null);
                f.Show();
                return false;
            }

            frmAskMailData fM = new frmAskMailData(1);
            createForm(fM, null);
            DialogResult r = fM.ShowDialog(this);
            if (r != DialogResult.OK) return false;

            pBarAvanzamento.Minimum = 0;
            pBarAvanzamento.Maximum = collaboratori.Count;
            pBarAvanzamento.Value = 0;
            foreach (Collaboratore co in collaboratori) {
                Application.DoEvents();
                Application.DoEvents();
                SendMail sm = new SendMail();
                sm.Conn = Meta.Conn;
                sm.useCuMail();
                SortedList ht = new SortedList(campiPresiDallaLicenza);
                string nome, cognome;

                fillSortedList(tMod770, ht, co, 1, out nome, out cognome);


                string denominazione = cognome + "-";
                if (nome != "") {
                    denominazione = denominazione + nome + "-";
                }

                MemoryStream ms = new MemoryStream();

                PdfReader templateReader = new PdfReader(fOrigin);
                PdfWriter writer = new PdfWriter(ms);

                writer.SetCompressionLevel(5);
                writer.SetSmartMode(true);

                PdfDocument document = new PdfDocument(templateReader, writer);

                if (!chkConIndirizzo.Checked) {
                    // Voglio rimuovere la prima pagina
                    document.RemovePage(document.GetFirstPage());
                }
                if (!chkDonazione.Checked) {
                    // Voglio rimuovere la penultima e l'ultima pagina
                    document.RemovePage(document.GetLastPage());
                    document.RemovePage(document.GetLastPage());
                }

                PdfAcroForm form = PdfAcroForm.GetAcroForm(document, false);

                if (form != null) {
                    form.SetGenerateAppearance(true);

                    var fields = form.GetFormFields();

                    foreach (DictionaryEntry entry in ht) {
                        string fieldID = entry.Key.ToString();
                        string fieldValue = entry.Value.ToString();

                        List<string> fieldIDvariants = new List<string>();
                        //variante nomecampo
                        fieldIDvariants.Add(fieldID);
                        //variante nomecampo_8x1000
                        fieldIDvariants.Add(fieldID + "_8x1000");
                        //varianti nomecampo_pX dove X è il numero pagina
                        for (int i = 0; i < document.GetNumberOfPages(); i++) {
                            fieldIDvariants.Add(fieldID + "_p" + i.ToString());
                        }

                        var matchedFields = fields.Where(field => fieldIDvariants.Contains(field.Key));
                        matchedFields._forEach(matchedField => {
                            matchedField.Value.SetValue(fieldValue);
                            matchedField.Value.SetReadOnly(true);
                        });
                    }
                    // Suffissi per identificare i campi dei moduli aggiuntivi
                    string[] suffissi = new string[] { "_bis", "_ter", "_quater", "_quin", "_sext", "_sept", "_oct", "_nov" };

                    int indicemodulo = 1;
                    int modulistampati = 0;
                    foreach (string suffisso in suffissi) {
                        indicemodulo++;
                        SortedList ht_moduloaggiuntivo = new SortedList();
                        fillSortedList(tMod770, ht_moduloaggiuntivo, co, indicemodulo, out nome, out cognome);
                        if (ht_moduloaggiuntivo.Count > 0) {
                            modulistampati++;
                            foreach (DictionaryEntry entry in ht_moduloaggiuntivo) {
                                // valorizzazione di un modulo supplementare
                                string fieldID = entry.Key.ToString() + suffisso;

                                if (fields.ContainsKey(fieldID)) {
                                    fields[fieldID].SetValue(entry.Value.ToString());
                                    fields[fieldID].SetReadOnly(true);
                                }

                            }
                        }

                    }

                    //indici delle pagine del template
                    int indexFromRemove = (recordH) ? 3 : 7;
                    int indexToRemove = (recordH) ? 10 : 10;

                    if (chkConIndirizzo.Checked) {
                        indexFromRemove++;
                        indexToRemove++;
                    }
                    indexFromRemove += modulistampati;

                    //pagine inutilizzate da cancellare 
                    int nPages = indexToRemove - indexFromRemove + 1;
                    for (int i = 0; i < nPages; i++) {
                        document.RemovePage(indexFromRemove);
                    }

                    string nomeFile = getNomeCompleto(co.cf, co.progr.PadLeft(3, '0'), co.modulo, denominazione);

                    writer.Flush();
                    ms.Flush();
                    document.Close();

                    try {
                        sm.addAttachment(ms.ToArray(), nomeFile);
                        if (fM.chkInvioProva.Checked) {
                            sm.To = fM.txtCopiaConoscenza.Text;
                        }
                        else {
                            if (fM.txtCopiaConoscenza.Text.Trim() != "") {
                                sm.Cc = fM.txtCopiaConoscenza.Text;
                            }
                            sm.To = co.email.ToString();
                        }
                        sm.Subject = fM.txtOggetto.Text;
                        sm.MessageBody = fM.txtContenuto.Text;
                        sm.UseSMTPLoginAsFromField = true;
                  
                        //sm.Send();
                        if (!sm.Send()) {
                            if (sm.ErrorMessage.Trim() != "")
                                show(sm.ErrorMessage.Trim());
                        }
                        Thread.Sleep(5000);
                    }
                    catch {
                        listaProblemi.Add(co);
                    }

                }

                pBarAvanzamento.Value += 1;
            }             

            if (listaProblemi.Count > 0) {
                string s = "";
                foreach (Collaboratore co in listaProblemi) {
                    string title = conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg", co.idreg), "title").ToString();
                    s += title + " (id " + co.idreg + "), email:" + co.email + "\n";
                }
                frmListaProblemi f = new frmListaProblemi(0);
                f.txtProblemi.Text = s;
                f.labelMsg.Text = "Invio email fallito per i seguenti collaboratori:";
                //f.Show();
            }
            else {
                show(this,
               "Sono stati generati " + collaboratori.Count + " modelli Certificazione Unica",
               "Invio effettuato");
            }
            Cursor.Current = Cursors.Default;
            pBarAvanzamento.Value = 0;

            DataTable emailNonInviate = new DataTable();            
            emailNonInviate.Columns.Add("idreg", typeof(System.Int32));
            emailNonInviate.Columns.Add("cf", typeof(System.String));
            emailNonInviate.Columns.Add("email", typeof(System.String));
            emailNonInviate.Columns.Add("commento", typeof(System.String));
            emailNonInviate.Columns.Add("progr", typeof(System.String));
            emailNonInviate.Columns.Add("modulo", typeof(System.Int16));
            emailNonInviate.Columns.Add("nome", typeof(System.String));
            emailNonInviate.Columns.Add("cognome", typeof(System.String));

            DataTable emailInviate = new DataTable();
            emailInviate.Columns.Add("idreg", typeof(System.Int32));
            emailInviate.Columns.Add("cf", typeof(System.String));
            emailInviate.Columns.Add("email", typeof(System.String));
            emailInviate.Columns.Add("commento", typeof(System.String));
            emailInviate.Columns.Add("progr", typeof(System.String));
            emailInviate.Columns.Add("modulo", typeof(System.Int16));
            emailInviate.Columns.Add("nome", typeof(System.String));
            emailInviate.Columns.Add("cognome", typeof(System.String));

            foreach (Collaboratore c in collaboratori) {
                if (c.email == null || c.email.ToString() == "") {
                    DataRow dr = emailNonInviate.NewRow();
                    dr["idreg"] = c.idreg;
                    dr["cf"] = c.cf;
                    dr["email"] = c.email;
                    dr["commento"] = c.commento;
                    dr["progr"] = c.progr;
                    dr["modulo"] = c.modulo;
                    dr["nome"] = c.name;
                    dr["cognome"] = c.surname;
                    emailNonInviate.Rows.Add(dr);
				}
                else {
                    DataRow dr = emailInviate.NewRow();
                    dr["idreg"] = c.idreg;
                    dr["cf"] = c.cf;
                    dr["email"] = c.email;
                    dr["commento"] = c.commento;
                    dr["progr"] = c.progr;
                    dr["modulo"] = c.modulo;
                    dr["nome"] = c.name;
                    dr["cognome"] = c.surname;
                    emailInviate.Rows.Add(dr);
				}
			}

            string[] intestazione = nomeModello.Split('.');
            //creazione tabella da passare a SituazioneViewer
            DataTable dt = new DataTable();
            dt.Columns.Add("value", typeof(String));
            dt.Columns.Add("amount", typeof(Decimal));
            dt.Columns.Add("kind", typeof(Char));
            /*-----------------------------------------------------*/
            //intestazione
            DataRow head = dt.NewRow();            
            head["value"] = "Verifica delle Email inviate";
            head["amount"] = DBNull.Value;
            head["kind"] = "H";
            dt.Rows.Add(head);

            DataRow head2 = dt.NewRow();            
            head2["value"] = intestazione[0];
            head2["amount"] = DBNull.Value;
            head2["kind"] = "H";
            dt.Rows.Add(head2);
            /*-----------------------------------------------------*/
            //lista delle email inviate e non
            DataRow brh = dt.NewRow();
            brh["value"] = "";
            brh["amount"] = DBNull.Value;
            brh["kind"] = "N";
            dt.Rows.Add(brh);

            DataRow notsend = dt.NewRow();
            notsend["value"] = "EMAIL  NON  INVIATE";
            notsend["amount"] = DBNull.Value;
            notsend["kind"] = "N";
            dt.Rows.Add(notsend);

            foreach (DataRow row in emailNonInviate.Rows) {
                DataRow body = dt.NewRow();            
                body["value"] = $"CF: {row["cf"]} " + $"  Nome: {row["nome"]} " + $"  Cognome: {row["cognome"]} " + "  Email: mancante " + $"  Data: {DateTime.Now}";  
                body["amount"] = DBNull.Value;
                body["kind"] = "N";
                dt.Rows.Add(body);
 			}

            DataRow brn = dt.NewRow();
            brn["value"] = "";
            brn["amount"] = DBNull.Value;
            brn["kind"] = "N";
            dt.Rows.Add(brn);

            DataRow send = dt.NewRow();
            send["value"] = "EMAIL  INVIATE";
            send["amount"] = DBNull.Value;
            send["kind"] = "N";
            dt.Rows.Add(send);

            foreach (DataRow row in emailInviate.Rows) {
                DataRow body = dt.NewRow();
                body["value"] = $"CF: {row["cf"]} " + $"  Nome: {row["nome"]} " + $"  Cognome: {row["cognome"]} " + $"  Email: {row["email"]} " + $"  Data: {DateTime.Now}";
                body["amount"] = DBNull.Value;
                body["kind"] = "N";
                dt.Rows.Add(body);
 			}

            DataSet inviati = new DataSet();
            inviati.Tables.Add(dt);
            inviati.Tables[0].TableName = "Situazione";
            
            

            //string fileName = Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + ".xlsx";
            string fileName = Path.ChangeExtension(Path.GetTempFileName(), "xlsx");
            byte[] datatableBytes = dataTableToOfficeXML(inviati.Tables[0],/* false,*/ fileName);
            if (datatableBytes.Length == 0 || datatableBytes == null) return false;
        
            frmSituazioneViewer View = new frmSituazioneViewer(inviati);
            createForm(View, null);
            View.Show();

            SendMail responsabile = new SendMail();
            responsabile.Conn = Meta.Conn;
            DataTable T = conn.RUN_SELECT("configsmtp", "responsabile_cu", null, null, null, false);
            if (T != null && T.Rows.Count != 0 && T.Rows[0]["responsabile_cu"] != DBNull.Value) {
                responsabile.To = T.Rows[0]["responsabile_cu"].ToString();
                responsabile.UseSMTPLoginAsFromField = true;
                responsabile.Subject = "Resoconto Email Inviate/Non Inviate";
                responsabile.MessageBody = "CU " + Meta.GetSys("esercizio");
                responsabile.addAttachment(datatableBytes, fileName);
                if (!responsabile.Send()) {
                    if (responsabile.ErrorMessage.Trim() != "")
                        show(responsabile.ErrorMessage.Trim());
                }
            }
           

            return true;
        }

        private static byte[] dataTableToOfficeXML(System.Data.DataTable DT, /*bool Header,*/ string filename) {
            
            ExcelPackage xlPackage = new ExcelPackage();
            byte[] data = new byte[0];
            // Controlli formali sulla presenza dei dati in input
            if (DT == null) return null;
            if (DT.Columns.Count == 0) return null;
            
            if (filename.Length != 0) {
                var fi = new FileInfo(filename);
                xlPackage = new ExcelPackage(fi);
            }

            using (xlPackage) {
                ExcelWorksheet worksheet = CreateSheet(xlPackage, DT.TableName); // Creazione del foglio dati con impostazione delle sue proprietà
                int RowCount = DT.Select().Length; // Numero Righe del datatable
                int ColumnCount = 1;//DT.Columns.Count; -> Numero Colonne del datatable, metto 1 perchè mi serve solo la colonna value
                int Step = 0;

                // Formattazione dell'Header del foglio Excel
                //if (Header) {
                //    SetHeader(worksheet, DT);
                //    Step = 1;
                //}

                int mincol = 99999;
                for (int Colonna = 0; Colonna < ColumnCount; Colonna++) {
                    DataColumn Col = DT.Columns[Colonna];
                    int ColonnaExcel = Colonna + 1;
                    if (Col.ExtendedProperties["ListColPos"] != null)
                        ColonnaExcel = Convert.ToInt32(Col.ExtendedProperties["ListColPos"]);
                    if (ColonnaExcel == -1) continue;
                    if (mincol > ColonnaExcel) mincol = ColonnaExcel;
                }

                int disp = 0;
                if (mincol == 0) disp = 1;
                DataRow[] Rows = DT.Select(null, (string) DT.ExtendedProperties["ExcelSort"]);
                if (Rows.Length == 0) return null;

                //per ogni colonna del datatable:
                int Excel_Col_Index = 0;

                Dictionary<int, int> colLookup = new Dictionary<int, int>();
                Dictionary<int, string> tagLookup = new Dictionary<int, string>();
                Dictionary<int, int> inverseLookup = new Dictionary<int, int>();
                Dictionary<int, string> colFormat = new Dictionary<int, string>();

                //Inserisce le eventuali intestazioni e stabilisce la corrispondenza delle colonne
                for (int Colonna = 0; Colonna < ColumnCount; Colonna++) {
                    DataColumn Col = DT.Columns[Colonna];
                    string caption = (string) Col.ExtendedProperties["ExcelTitle"];
                    if (caption == null) caption = DT.Columns[Colonna].Caption;
                    if (caption == "") continue;

                    if ((Col.ExtendedProperties["ListColPos"] == null) && (caption.StartsWith("."))) continue;

                    int ColonnaExcel = Excel_Col_Index + 1;
                    if (Col.ExtendedProperties["ListColPos"] != null)
                        ColonnaExcel = Convert.ToInt32(Col.ExtendedProperties["ListColPos"]);

                    if (ColonnaExcel == -1) continue;

                    if (caption.StartsWith(".")) caption = caption.Remove(0, 1);
                    Excel_Col_Index++;

                    string Tag = "x.y";
                    Tag = HelpForm.CompleteTag(Tag, Col);
                    colLookup[Colonna] = ColonnaExcel + disp;
                    tagLookup[Colonna] = Tag;

                    if (Col.ExtendedProperties["ExcelFormat"] != null) {
                        colFormat[Colonna] = Col.ExtendedProperties["ExcelFormat"].ToString();
                    }
                    //else {
                    //    switch (HelpForm.GetFieldLower(Tag, 2)) {
                    //        case "n":
                    //            colFormat[Colonna] = "0.00";
                    //            break;

                    //        case "c":
                    //            colFormat[Colonna] = "€#,##0.00_);[Red](€#,##0.00)";
                    //            break;

                    //        case "d":
                    //            colFormat[Colonna] = "dd/mm/yyyy";
                    //            break;
                    //    }
                    //}

                    //if (Header) {
                    //    var cell = worksheet.Cells[1, ColonnaExcel + disp];
                    //    cell.Value = caption;
                    //}
                }

                //for (int i = 0; i < ColumnCount; i++) {
                //    if (colLookup.ContainsKey(i)) {
                //        inverseLookup[colLookup[i]] = i;
                //    }
                //}
                //Posizione prima riga dati
                var startRow = 1; //Header ? 2 : 1;
                int rigaExcel = startRow; //Riga Excel in cui andrà la prossima riga di dati o totali                    
                for (int Riga = 0; Riga < RowCount; Riga++) {
                    DataRow Curr = Rows[Riga];
                        
                    //Mette i dati nelle opportune colonne
                    foreach (int Colonna in colLookup.Keys) {
                        var cell = worksheet.Cells[rigaExcel, colLookup[Colonna]];
                        if (Rows[Riga][Colonna] == DBNull.Value) {
                            cell.Value = "";
                            continue;
                        }

                        string Tag = tagLookup[Colonna];
                        if (DT.Columns[Colonna].DataType == typeof(String)) {
                            cell.Value = HelpForm.StringValue(Rows[Riga][Colonna], Tag);
                            continue;
                        }

                        //if (DT.Columns[Colonna].DataType == typeof(Int32)) {
                        //    cell.Value = Rows[Riga][Colonna];
                        //    continue;
                        //}

                        //if (DT.Columns[Colonna].DataType == typeof(Int16)) {
                        //    cell.Value = Rows[Riga][Colonna];
                        //    continue;
                        //}

                        //switch (HelpForm.GetFieldLower(Tag, 2)) {
                        //    case "n":
                        //    case "c":
                        //        cell.Value = Rows[Riga][Colonna] == DBNull.Value
                        //            ? 0
                        //            : Convert.ToDecimal(Rows[Riga][Colonna]);
                        //        break;
                        //    case "d":
                        //        DateTime value;
                        //        if (DateTime.TryParse(Rows[Riga][Colonna].ToString(), out value)) {
                        //            cell.Value = value;
                        //        }

                        //        break;

                        //    default:
                        //        cell.Value = HelpForm.StringValue(Rows[Riga][Colonna], Tag);
                        //        break;
                        //}
                    }
                    rigaExcel++;
                }

                //Per ogni colonna:  imposta il formato e la dimensiona
                for (int Colonna = 0; Colonna < ColumnCount; Colonna++) {
                    if (!colLookup.ContainsKey(Colonna)) continue;
                    int ColonnaExcel = colLookup[Colonna];
                    ExcelRange ExcCol = worksheet.Cells[1 + Step, ColonnaExcel, rigaExcel, ColonnaExcel];
                    if (colFormat.ContainsKey(Colonna)) {
                        ExcCol.Style.Numberformat.Format = colFormat[Colonna];
                    }
                    ExcCol.AutoFitColumns();
                }
                // Save file id filename is set
                if (filename.Length != 0) {
                    byte[] tmpData = xlPackage.GetAsByteArray();
                    if (File.Exists(filename)) File.Delete(filename); // Se esiste il file lo cancello
                    //File.WriteAllBytes(filename, data);
                    data = tmpData;
                }
            }
            return data;
        }

         /// <summary>
         /// Create an excel work sheet and set font type, font dimension and sheet name
         /// </summary>
         /// <param name="p">Excel Package</param>
         /// <param name="sheetName">Sheet Name</param>
         /// <returns></returns>
        private static ExcelWorksheet CreateSheet(ExcelPackage p, string sheetName) {
            try {
                if (sheetName == "") sheetName = LM.translate("dataFolder", false);
                p.Workbook.Worksheets.Add(sheetName);
                ExcelWorksheet ws = p.Workbook.Worksheets[1];
                ws.Name = sheetName; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 11; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri"; //Default Font name for whole sheet

                return ws;

            }
            catch (Exception E) {
                QueryCreator.ShowException(E);
                return null;
            }
        }

        //private static void SetHeader(ExcelWorksheet ws, System.Data.DataTable dt) {

        //    // Formattazione di Header 
        //    for (int i = 1; i <= dt.Columns.Count; i++) {

        //        var cell = ws.Cells[1, i];
        //        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        //        cell.Style.Font.Bold = true;
        //    }

        //}

        private XmlText createTextNode(XmlDocument doc, object valore) {
            if (valore is decimal) {
                decimal dec = (decimal)valore;
                return doc.CreateTextNode(((decimal)valore).ToString("n", numberFormat));
            }
            return doc.CreateTextNode(valore.ToString());
        }

        XmlDocument getXml(SortedList ht, string commento, bool recordH) {
            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", "UTF-8", ""));
            doc.AppendChild(doc.CreateComment(commento));
            doc.AppendChild(doc.CreateProcessingInstruction("xfa", "generator=\"XFA2_4\" APIVersion=\"2.6.7120.0\""));
            XmlNode xdp = doc.AppendChild(doc.CreateElement("xdp", "xdp", "http://ns.adobe.com/xdp/"));
            XmlNode datasets =
                xdp.AppendChild(doc.CreateElement("xfa", "datasets", "http://www.xfa.org/schema/xfa-data/1.0/"));
            XmlNode data =
                datasets.AppendChild(doc.CreateElement("xfa", "data", "http://www.xfa.org/schema/xfa-data/1.0/"));
            XmlNode topmostSubform = data.AppendChild(doc.CreateElement("topmostSubform"));
            foreach (DictionaryEntry de in ht) {
                XmlNode campo = topmostSubform.AppendChild(doc.CreateElement(de.Key.ToString()));
                campo.AppendChild(createTextNode(doc, de.Value));
            }
            foreach (
                string campo in
                    new string[] {
                        "DA002001", "cf", "DA002003", "DA002002", "DA002005g", "DA002005m", "DA002005a", "DA002007",
                        "DA002006", "DA002004", "anno"
                    }) {
                if (ht.Contains(campo)) {
                    topmostSubform.AppendChild(doc.CreateElement(campo + "bis"))
                        .AppendChild(createTextNode(doc, ht[campo]));
                }
            }
            foreach (string campo in new string[] { "DA002001" }) {
                if (ht.Contains(campo)) {
                    topmostSubform.AppendChild(doc.CreateElement(campo + "ter"))
                        .AppendChild(createTextNode(doc, ht[campo]));
                }
            }
            XmlElement pdf = doc.CreateElement("pdf", "http://ns.adobe.com/xdp/pdf/");
            pdf.SetAttribute("href", getNomeFileModello(recordH));
            xdp.AppendChild(pdf);
            return doc;
        }

        string getNomeFileModello(bool recordH) {
            // Template completo con indirizzo e scheda donazione, poi rimuoveremo pagine a run time


            return recordH ? "CU_" + EsercStr + "_h_completo.pdf" : "CU_" + EsercStr + "_g_completo.pdf";
        }

        private void stampaXml(XmlDocument doc, string cf, string progr, string modulo, string denominazione) {
            string invalid = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            string nomeFile = denominazione + cf;

            foreach (char c in invalid) {
                nomeFile = nomeFile.Replace(c.ToString(), "");
            }
            string pathCompleto = Path.Combine(txtPercorso.Text, nomeFile + "-" + progr + "-" + modulo + ".xdp");
            try {
                doc.Save(pathCompleto);
            }
            catch (Exception e) {
                QueryCreator.ShowError(this, "Errore salvando il file, probabilmente il percorso non esiste.", e.ToString());
            }
        }

        private void riempiNote(SortedList ht, string nota) {
            //Encoding code8859_15 = Encoding.GetEncoding("ISO-8859-15");
            //Encoding unicode = Encoding.Unicode;
            ////Encoding iso = Encoding.Unicode; Encoding.
            //Encoding code8859_1 = Encoding.GetEncoding("ISO-8859-1");
            //byte[] utfBytes = code8859_15.GetBytes(nota);
            //byte[] isoBytes = Encoding.Convert(code8859_15, unicode, utfBytes);
            //string msg = unicode.GetString(isoBytes);

            if (ht["Annotazioni"] != null) {
                ht["Annotazioni"] += "\r\n";
            }
            ht["Annotazioni"] = ht["Annotazioni"] + nota;
        }
        private void salvaColonnaMultiCasellaMesi(SortedList ht, string nomeCampo, string valore) {
            char c = 'a';
            for (int i = 0; i < 12; i++) {
                if ((valore[i] == '1') && (ht[nomeCampo + c] == null)) {
                    ht[nomeCampo + c] = 'X';
                }
                c++;
            }
        }

        private void salvaColonnaCasellaBarrataSingola(SortedList ht, string nomeCampo, object valore) {
            if (valore == DBNull.Value) return;
            if (valore.ToString() == "1") {
                ht[nomeCampo] = 'X';
            }
        }

        private void salvaColonnaDB60xxx(SortedList ht, string colname, string DB60xxx) {
            // Metodo che consente di barrare con una X le caselle relative ai familiari a carico elencati: Coniuge, primo figlio, ecc.
            // alla stessa riga restituita dalla sp corrispondono tre caselle barrate nel modello: una per ogni valore (F,A,D)
            // le etichettiamo con XXX001, se il valore è F , XXX002 se il valore è A,  XXX003 se il valore è D
            if (DB60xxx == "F1") {
                ht[colname + "001"] = 'X';
            }
            if (DB60xxx == "F") {
                ht[colname + "001"] = 'X';
            }
            if (DB60xxx == "D") {
                ht[colname + "003"] = 'X';
            }
            if (DB60xxx == "A") {
                ht[colname + "002"] = 'X';
            }
        }


        private void salvaColonnaNumeroGiorniDetrazioni(SortedList ht, string nomeCampo, int valore) {
            // Gestione del campo numero dei giorni per i quali spettano le detrazioni
            object old = ht[nomeCampo];
            if (old == null) {
                ht[nomeCampo] = valore;
            }
            else {
                int numGiorni = ((int)old) + valore;
                if (numGiorni > 365) {
                    numGiorni = 365;
                }
                ht[nomeCampo] = numGiorni;
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
                else if (old is decimal) {
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



        ///// <summary>
        ///// legge i dati dal foglio di Excel a mData
        ///// </summary>
        //private void ReadCurrentSheet() {
        //    try {
        //        // open the connection to the file
        //        using (OleDbConnection connection =
        //            new OleDbConnection(ConnectionString)) {
        //            connection.Open();
        //            DataTable sheetData = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        //            string foglioLavoro = sheetData.Rows[0]["TABLE_NAME"].ToString();
        //            string sql =
        //                string.Format("select * from [{0}]", foglioLavoro);
        //            // create an adapter
        //            using (OleDbDataAdapter adapter =
        //                new OleDbDataAdapter(sql, connection)) {
        //                // clear the datatable to avoid old data persistance
        //                mData.Clear();
        //                // fille the datatable
        //                adapter.Fill(mData);
        //            }
        //            connection.Close();
        //        }
        //    }
        //    catch (Exception ex) {
        //        show(this, ex.Message);
        //    }
        //    // pulizia nomi colonne da eventuali spazi
        //    foreach (DataColumn C in mData.Columns) {
        //        C.ColumnName = C.ColumnName.Trim();
        //    }
        //}


        /// <summary>
        /// Legge un foglio excel in MData
        /// </summary>
        /// <returns></returns>
        private bool LeggiFile() {
            DialogResult dr = MyOpenFile.ShowDialog(this);

            if (dr != DialogResult.OK)
                return false;
            try {
                string fileName = MyOpenFile.FileName;
                var Xcel = new ExcelImport();
                Xcel.ImportTable(fileName, mData, true, 2);
                //ConnectionString = ExcelImport.ExcelConnString(fileName);
                //"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName +
                //";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";
                //ReadCurrentSheet();
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

            fillTable();

            Meta.FreshForm();
            return true;
        }

        Dictionary<string, string> progressiviHRD06 = new Dictionary<string, string>();
        Dictionary<string, string> progressiviHRD07 = new Dictionary<string, string>();
        Dictionary<string, string> progressiviHRD09 = new Dictionary<string, string>();

        private bool fillTable() {
            string CF;
            string identificativo;
            string progressivo;
            string sostituisci_o_annulla;
            progressiviHRD06.Clear();
            progressiviHRD07.Clear();
            progressiviHRD09.Clear();
            if (mData.Select().Length == 0) {
                show(this, "Il file selezionato non è stato importato, controllare che siano presenti le intestazioni delle colonne e che contenga dati", "Errore");
                return false;
            }
            foreach (DataRow rFile in mData.Select()) {
                CF = rFile["cf"].ToString().Trim();
                identificativo = rFile["identificativo"].ToString().Trim();
                progressivo = rFile["progressivo"].ToString().Trim();
                sostituisci_o_annulla = rFile["sostituisci_o_annulla"].ToString().Trim().ToUpper();

                if ((CF == "") || (identificativo == "") || (progressivo == "") || (sostituisci_o_annulla == "")) {
                    show(this, "Il file selezionato contiene dati non validi, controllare che siano presenti le intestazioni delle colonne.", "Errore");
                    return false;
                }
                progressiviHRD06[CF] = rFile["identificativo"].ToString().Trim();
                progressiviHRD07[CF] = rFile["progressivo"].ToString().Trim();
                progressiviHRD09[CF] = rFile["sostituisci_o_annulla"].ToString().Trim().ToUpper();
            }
            show(this, "Il file selezionato è stato importato. Si può procedere con la generazione della dichiarazione.", "Avviso");
            return true;
        }

        List<string> ListaCF = new List<string>();
        private bool fillTableCF(DataTable mDataCF) {
            string CF;
            if (mDataCF.Select().Length == 0) {
                show(this, "Il file selezionato non è stato importato, controllare che siano presenti le intestazioni delle colonne e che contenga dati", "Errore");
                return false;
            }
            foreach (DataRow rFile in mDataCF.Select()) {
                CF = rFile["cf"].ToString().Trim();

                if (CF == "") {
                    show(this, "Il file selezionato contiene dati non validi, controllare che siano presenti le intestazioni delle colonne.", "Errore");
                    return false;
                }
                ListaCF.Add(CF);
            }
            show(this, "Il file selezionato è stato importato. Si può procedere con la generazione della dichiarazione.", "Avviso");
            return true;
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
            elencoColonne.Add("sostituisci_o_annulla");
            foreach (string col in elencoColonne) {
                if (!mData.Columns.Contains(col)) {
                    show(this, "Nel file " + MyOpenFile.FileName + " non esiste la colonna " + col, "Errore");
                    return false;
                }
            }
            return true;
        }

        private bool verificaValiditaFileExcel_soloCF() {
            bool ok = true;
            DataSet Out = new DataSet();
            DataTable T = new DataTable();
            T.Columns.Add("errors", typeof(System.String), "");
            for (int i = 0; i < tracciato_setcf.Length; i++) {
                string fmt = tracciato_setcf[i];
                bool datiValidi = verificaCampo(mData, fmt, T);
                if (!datiValidi) ok = false;
            }

            Out.Tables.Add(T);

            if (!ok) {
                frmErrori View = new frmErrori(Out.Tables[0]);
                createForm(View, null);
                View.Show();
            }

            return ok;
            //ArrayList elencoColonne = new ArrayList();
            //// La verifica di validità si basa sulla presenza di alcune colonne all'interno del file Excel.
            //elencoColonne.Add("cf");
            //foreach (string col in elencoColonne) {
            //    if (!mDataCF.Columns.Contains(col)) {
            //        show(this, "Nel file " + MyOpenFile.FileName + " non esiste la colonna " + col, "Errore");
            //        return false;
            //    }
            //}
            //return true;
        }

        bool verificaCampo(DataTable mData, string tracciato_field, DataTable T) {

            bool ok = true;
            string[] ff = tracciato_field.Split(';');
            string fieldname = ff[0];
            if (((fieldname == "codicepagamento") ||
                (fieldname == "codicemodpagamento") ||
                (fieldname == "rimborsotasse") ||
                (fieldname == "annoaccademico") ||
                (fieldname == "annosolare") ||
                (fieldname == "tipologiacorso") ||
                (fieldname == "codicecorsouniversitario")
                ) &&
                (!mData.Columns.Contains(fieldname))) {
                return ok;
            }
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

                switch (fieldname) {
                    case "cf":
                        // controllo del codice fiscale
                        if (val != "") {
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
                        break;
                }
            }

            return ok;
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
                    string err = "Lunghezza non prevista nella decodifica del campo " + fieldname + " di tipo " + ftype +
                                 " e di valore " +
                                 val.Trim().TrimStart('0') + " alla riga " + rownum;
                    DataRow row = T.NewRow();
                    row["errors"] = err;
                    T.Rows.Add(row);
                    ok = false;
                }
                if ((fieldname == "cf") && (val != "")) {
                    string errori = null;
                    CalcolaCodiceFiscale.CheckCF(val.Trim(), out errori);
                    if (errori != "") {
                        string err = " Nel codice fiscale " + " alla riga " + rownum + ": " + val +
                                     " compaiono i seguenti errori: " + errori;
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
                new string[] {
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
            if (!tExcel.Columns.Contains("cf"))
                tExcel.Columns.Add("cf", typeof(string));
            if (!tExcel.Columns.Contains("identificativo"))
                tExcel.Columns.Add("identificativo", typeof(string));
            if (!tExcel.Columns.Contains("progressivo"))
                tExcel.Columns.Add("progressivo", typeof(string));
            if (!tExcel.Columns.Contains("sostituisci_o_annulla"))
                tExcel.Columns.Add("sostituisci_o_annulla", typeof(string));
        }

        private void addColumnExcel_CF(DataTable tExcel) {
            if (!tExcel.Columns.Contains("cf"))
                tExcel.Columns.Add("cf", typeof(string));
        }
        private void btnInputFile_Click(object sender, EventArgs e) {
            //Riempie il datatable MData leggendo dal foglio Excel
            mData.Clear();
            addColumnExcel(mData);

            if (!LeggiFile()) {
                return;
            }
            ListaCF.Clear();
            txtInputFileSetCF.Text = "";
        }



        enum TipoGenerazione {
            salvataggio,
            stampa,
            mail,
            none
        };

        TipoGenerazione getTipoGenerazioneSelezionato() {
            if (radSave.Checked) return TipoGenerazione.salvataggio;
            if (radPrint.Checked) return TipoGenerazione.stampa;
            if (radMail.Checked) return TipoGenerazione.mail;
            return TipoGenerazione.none;
        }

        private void btnGenera_Click(object sender, EventArgs e) {
            bool errore = false;
            errore = !controlliGenerazioneG(radH.Checked);
            if (errore) {
                if (show(" Si desidera proseguire l''elaborazione del record G nonostante  gli errori?", "Errore",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) 
                    return;
            }
            errore = false;
            errore = !controlliGenerazioneH(radH.Checked);
            if (errore) {
                if (show(" Si desidera proseguire l''elaborazione del record H nonostante  gli errori?", "Errore",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) 
                    return;
            }
            generaCertificazioneUnica(radH.Checked, getTipoGenerazioneSelezionato());
        }

        string[] tracciato_setcf = new string[]{"cf;C.F.;Stringa;16"};

        //private DataTable ReadCurrentSheet(string filename) {
        //    LeggiFile Reader = new LeggiFile();
        //    if (!Reader.Init(tracciato_setcf, filename)) return null;

        //    DataTable t = new DataTable();
        //    addColumnExcel_CF(t);
        //    Reader.Skip();
        //    Reader.GetNext();
        //    while (Reader.DataPresent()) {
        //        DataRow r = t.NewRow();
        //        foreach (DataColumn c in t.Columns) {
        //            object o = Reader.getCurrField(c.ColumnName);
        //            r[c.ColumnName] = o;
        //        }
        //        t.Rows.Add(r);
        //        Reader.GetNext();
        //    }
        //    t.AcceptChanges();
        //    Reader.Close();
        //    return t;
        //}

        /// <summary>
        /// Legge un foglio excel in ListaCF
        /// </summary>
        /// <returns></returns>
        private bool LeggiFileCF() {
            DialogResult dr = MyOpenFile.ShowDialog(this);
            if (dr != DialogResult.OK) return false;
            DataTable t = new DataTable();
            addColumnExcel_CF(t);

            try {
                string fileName = MyOpenFile.FileName;
                //ConnectionString = ExcelImport.ExcelConnString(fileName);
                new ExcelImport().ImportTable(fileName, t, true, 2);
                //t = ReadCurrentSheet(fileName);
                txtInputFileSetCF.Text = fileName;
            }
            catch (Exception ex) {
                show(this, "Errore nell'apertura del file! Processo Terminato\n" + ex.Message);
                return false;
            }
            if (t == null) return false;

            if (!verificaValiditaFileExcel_soloCF()) {
                show(this, "Il file selezionato non è valido", "Errore");
                return false;
            }
            fillTableCF(t);

            return true;
        }

        private void btnCUperSetdiCF_Click(object sender, EventArgs e) {
            //Riempie il datatable MData leggendo dal foglio Excel

            if (!LeggiFileCF()) {
                return;
            }

            txtInputFile.Text = "";
            mData.Clear();
        }
    }
}
