/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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

using funzioni_configurazione;
using metadatalibrary;
using System;
using System.Data;
using System.Windows.Forms;
using BancaSondrioFlusso;
using q=metadatalibrary.MetaExpression;

namespace flussoincassi_default {
    /// <summary>
    /// Summary description for FrmAccMotive_default.
    /// </summary>
    public class Frmflussoincassi_default : System.Windows.Forms.Form {
        private System.Windows.Forms.ImageList icons;
        private System.Windows.Forms.Splitter splitter1;
        public System.Windows.Forms.TabControl MetaDataDetail;
        private System.Windows.Forms.TabPage tabPrincipale;
        private System.Windows.Forms.TextBox txtCausale;
        private System.Windows.Forms.Label lblCausale;
        private System.Windows.Forms.TextBox txtCodice;
        private System.Windows.Forms.Label lblCodiceFlusso;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox gboxBilancio;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.ComponentModel.IContainer components;
        public flussoincassi_default.vistaForm DS;
        private System.Windows.Forms.CheckBox chbAttivo;
        private ImageList imageList1;
        private TextBox textBox1;
        private Label label1;
        private CheckBox chbElaborato;
        private Label label7;
        private TextBox txtDataIncasso;
        private TextBox txtEsercizio;
        private Label label2;
        private TextBox txtImportoTotale;
        private Label labelImporto;
        private TabPage tabPage1;
        private Label label4;
        private TextBox txtNomeFileRisposta;
        public Button btnImportaFileEsito;
        private OpenFileDialog openFileDialog1;
        MetaData Meta;
        private GroupBox gboxBill;
        private Button btnBill;
        private TextBox txtBill;
        private TextBox textBox6;
        private Label label14;
        private Button btnEsitiSospesi;     

        public Frmflussoincassi_default() {
            InitializeComponent();
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmflussoincassi_default));
			this.icons = new System.Windows.Forms.ImageList(this.components);
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.MetaDataDetail = new System.Windows.Forms.TabControl();
			this.tabPrincipale = new System.Windows.Forms.TabPage();
			this.btnEsitiSospesi = new System.Windows.Forms.Button();
			this.gboxBill = new System.Windows.Forms.GroupBox();
			this.btnBill = new System.Windows.Forms.Button();
			this.txtBill = new System.Windows.Forms.TextBox();
			this.txtImportoTotale = new System.Windows.Forms.TextBox();
			this.labelImporto = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtEsercizio = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtDataIncasso = new System.Windows.Forms.TextBox();
			this.chbElaborato = new System.Windows.Forms.CheckBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.chbAttivo = new System.Windows.Forms.CheckBox();
			this.gboxBilancio = new System.Windows.Forms.GroupBox();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.txtCausale = new System.Windows.Forms.TextBox();
			this.lblCausale = new System.Windows.Forms.Label();
			this.txtCodice = new System.Windows.Forms.TextBox();
			this.lblCodiceFlusso = new System.Windows.Forms.Label();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label4 = new System.Windows.Forms.Label();
			this.txtNomeFileRisposta = new System.Windows.Forms.TextBox();
			this.btnImportaFileEsito = new System.Windows.Forms.Button();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.DS = new flussoincassi_default.vistaForm();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.MetaDataDetail.SuspendLayout();
			this.tabPrincipale.SuspendLayout();
			this.gboxBill.SuspendLayout();
			this.gboxBilancio.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// icons
			// 
			this.icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icons.ImageStream")));
			this.icons.TransparentColor = System.Drawing.Color.Transparent;
			this.icons.Images.SetKeyName(0, "");
			this.icons.Images.SetKeyName(1, "");
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(0, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 700);
			this.splitter1.TabIndex = 4;
			this.splitter1.TabStop = false;
			// 
			// MetaDataDetail
			// 
			this.MetaDataDetail.Controls.Add(this.tabPrincipale);
			this.MetaDataDetail.Controls.Add(this.tabPage1);
			this.MetaDataDetail.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MetaDataDetail.ImageList = this.imageList1;
			this.MetaDataDetail.Location = new System.Drawing.Point(3, 0);
			this.MetaDataDetail.Name = "MetaDataDetail";
			this.MetaDataDetail.SelectedIndex = 0;
			this.MetaDataDetail.Size = new System.Drawing.Size(851, 700);
			this.MetaDataDetail.TabIndex = 5;
			// 
			// tabPrincipale
			// 
			this.tabPrincipale.Controls.Add(this.textBox6);
			this.tabPrincipale.Controls.Add(this.label14);
			this.tabPrincipale.Controls.Add(this.btnEsitiSospesi);
			this.tabPrincipale.Controls.Add(this.gboxBill);
			this.tabPrincipale.Controls.Add(this.txtImportoTotale);
			this.tabPrincipale.Controls.Add(this.labelImporto);
			this.tabPrincipale.Controls.Add(this.label2);
			this.tabPrincipale.Controls.Add(this.txtEsercizio);
			this.tabPrincipale.Controls.Add(this.label7);
			this.tabPrincipale.Controls.Add(this.txtDataIncasso);
			this.tabPrincipale.Controls.Add(this.chbElaborato);
			this.tabPrincipale.Controls.Add(this.textBox1);
			this.tabPrincipale.Controls.Add(this.label1);
			this.tabPrincipale.Controls.Add(this.chbAttivo);
			this.tabPrincipale.Controls.Add(this.gboxBilancio);
			this.tabPrincipale.Controls.Add(this.txtCausale);
			this.tabPrincipale.Controls.Add(this.lblCausale);
			this.tabPrincipale.Controls.Add(this.txtCodice);
			this.tabPrincipale.Controls.Add(this.lblCodiceFlusso);
			this.tabPrincipale.Location = new System.Drawing.Point(4, 23);
			this.tabPrincipale.Name = "tabPrincipale";
			this.tabPrincipale.Size = new System.Drawing.Size(843, 673);
			this.tabPrincipale.TabIndex = 0;
			this.tabPrincipale.Text = "Principale";
			this.tabPrincipale.UseVisualStyleBackColor = true;
			// 
			// btnEsitiSospesi
			// 
			this.btnEsitiSospesi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEsitiSospesi.Location = new System.Drawing.Point(667, 207);
			this.btnEsitiSospesi.Name = "btnEsitiSospesi";
			this.btnEsitiSospesi.Size = new System.Drawing.Size(160, 35);
			this.btnEsitiSospesi.TabIndex = 133;
			this.btnEsitiSospesi.Tag = "maindosearch.default.(to_complete=\'S\' and nbill is null)";
			this.btnEsitiSospesi.Text = "Esiti sospesi";
			this.btnEsitiSospesi.UseVisualStyleBackColor = true;
			// 
			// gboxBill
			// 
			this.gboxBill.Controls.Add(this.btnBill);
			this.gboxBill.Controls.Add(this.txtBill);
			this.gboxBill.Location = new System.Drawing.Point(16, 187);
			this.gboxBill.Name = "gboxBill";
			this.gboxBill.Size = new System.Drawing.Size(360, 55);
			this.gboxBill.TabIndex = 132;
			this.gboxBill.TabStop = false;
			this.gboxBill.Tag = "AutoChoose.txtBill.entrata.(active=\'S\')";
			// 
			// btnBill
			// 
			this.btnBill.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.btnBill.Location = new System.Drawing.Point(16, 18);
			this.btnBill.Name = "btnBill";
			this.btnBill.Size = new System.Drawing.Size(75, 23);
			this.btnBill.TabIndex = 1;
			this.btnBill.Tag = "choose.bill.entrata.(billkind=\'C\')and(active=\'S\')";
			this.btnBill.Text = "N∞ bolletta";
			this.btnBill.UseVisualStyleBackColor = true;
			// 
			// txtBill
			// 
			this.txtBill.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtBill.Location = new System.Drawing.Point(100, 20);
			this.txtBill.Name = "txtBill";
			this.txtBill.Size = new System.Drawing.Size(242, 20);
			this.txtBill.TabIndex = 0;
			this.txtBill.Tag = "bill.nbill?flussoincassi.nbill";
			// 
			// txtImportoTotale
			// 
			this.txtImportoTotale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtImportoTotale.Location = new System.Drawing.Point(288, 148);
			this.txtImportoTotale.Name = "txtImportoTotale";
			this.txtImportoTotale.Size = new System.Drawing.Size(88, 20);
			this.txtImportoTotale.TabIndex = 131;
			this.txtImportoTotale.Tag = "flussoincassi.importo";
			this.txtImportoTotale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// labelImporto
			// 
			this.labelImporto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelImporto.Location = new System.Drawing.Point(286, 130);
			this.labelImporto.Name = "labelImporto";
			this.labelImporto.Size = new System.Drawing.Size(87, 16);
			this.labelImporto.TabIndex = 130;
			this.labelImporto.Text = "Importo Totale";
			this.labelImporto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(113, 11);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 16);
			this.label2.TabIndex = 127;
			this.label2.Text = "Data Incasso";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtEsercizio
			// 
			this.txtEsercizio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtEsercizio.Location = new System.Drawing.Point(16, 31);
			this.txtEsercizio.Name = "txtEsercizio";
			this.txtEsercizio.Size = new System.Drawing.Size(87, 20);
			this.txtEsercizio.TabIndex = 126;
			this.txtEsercizio.Tag = "flussoincassi.ayear";
			this.txtEsercizio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(16, 11);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(56, 16);
			this.label7.TabIndex = 124;
			this.label7.Text = "Esercizio";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDataIncasso
			// 
			this.txtDataIncasso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDataIncasso.Location = new System.Drawing.Point(110, 31);
			this.txtDataIncasso.Name = "txtDataIncasso";
			this.txtDataIncasso.Size = new System.Drawing.Size(121, 20);
			this.txtDataIncasso.TabIndex = 125;
			this.txtDataIncasso.Tag = "flussoincassi.dataincasso";
			this.txtDataIncasso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// chbElaborato
			// 
			this.chbElaborato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chbElaborato.Location = new System.Drawing.Point(738, 147);
			this.chbElaborato.Name = "chbElaborato";
			this.chbElaborato.Size = new System.Drawing.Size(88, 25);
			this.chbElaborato.TabIndex = 26;
			this.chbElaborato.Tag = "flussoincassi.elaborato:S:N";
			this.chbElaborato.Text = "Elaborato";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(16, 149);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(267, 20);
			this.textBox1.TabIndex = 24;
			this.textBox1.Tag = "flussoincassi.trn";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 125);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 24);
			this.label1.TabIndex = 25;
			this.label1.Text = "TRN";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// chbAttivo
			// 
			this.chbAttivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chbAttivo.Location = new System.Drawing.Point(667, 147);
			this.chbAttivo.Name = "chbAttivo";
			this.chbAttivo.Size = new System.Drawing.Size(66, 25);
			this.chbAttivo.TabIndex = 23;
			this.chbAttivo.Tag = "flussoincassi.active:S:N";
			this.chbAttivo.Text = "Attivo";
			// 
			// gboxBilancio
			// 
			this.gboxBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxBilancio.Controls.Add(this.dataGrid1);
			this.gboxBilancio.Controls.Add(this.button2);
			this.gboxBilancio.Controls.Add(this.button3);
			this.gboxBilancio.Controls.Add(this.button1);
			this.gboxBilancio.Location = new System.Drawing.Point(16, 247);
			this.gboxBilancio.Name = "gboxBilancio";
			this.gboxBilancio.Size = new System.Drawing.Size(819, 414);
			this.gboxBilancio.TabIndex = 22;
			this.gboxBilancio.TabStop = false;
			this.gboxBilancio.Text = "Dettagli";
			// 
			// dataGrid1
			// 
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(104, 24);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(707, 382);
			this.dataGrid1.TabIndex = 22;
			this.dataGrid1.Tag = "flussoincassidetail.default.single";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(16, 56);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 20;
			this.button2.Tag = "edit.single";
			this.button2.Text = "Correggi";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(16, 88);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 21;
			this.button3.Tag = "delete";
			this.button3.Text = "Cancella";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(16, 24);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 19;
			this.button1.Tag = "insert.single";
			this.button1.Text = "Aggiungi";
			// 
			// txtCausale
			// 
			this.txtCausale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCausale.Location = new System.Drawing.Point(16, 80);
			this.txtCausale.Multiline = true;
			this.txtCausale.Name = "txtCausale";
			this.txtCausale.Size = new System.Drawing.Size(819, 42);
			this.txtCausale.TabIndex = 4;
			this.txtCausale.Tag = "flussoincassi.causale";
			// 
			// lblCausale
			// 
			this.lblCausale.Location = new System.Drawing.Point(15, 56);
			this.lblCausale.Name = "lblCausale";
			this.lblCausale.Size = new System.Drawing.Size(88, 24);
			this.lblCausale.TabIndex = 18;
			this.lblCausale.Text = "Causale";
			this.lblCausale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtCodice
			// 
			this.txtCodice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCodice.Location = new System.Drawing.Point(239, 31);
			this.txtCodice.Name = "txtCodice";
			this.txtCodice.Size = new System.Drawing.Size(441, 20);
			this.txtCodice.TabIndex = 1;
			this.txtCodice.Tag = "flussoincassi.codiceflusso";
			// 
			// lblCodiceFlusso
			// 
			this.lblCodiceFlusso.Location = new System.Drawing.Point(239, 7);
			this.lblCodiceFlusso.Name = "lblCodiceFlusso";
			this.lblCodiceFlusso.Size = new System.Drawing.Size(160, 24);
			this.lblCodiceFlusso.TabIndex = 15;
			this.lblCodiceFlusso.Text = "Codice Flusso";
			this.lblCodiceFlusso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.txtNomeFileRisposta);
			this.tabPage1.Controls.Add(this.btnImportaFileEsito);
			this.tabPage1.Location = new System.Drawing.Point(4, 23);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(715, 575);
			this.tabPage1.TabIndex = 1;
			this.tabPage1.Text = "Esito";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(18, 29);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(288, 16);
			this.label4.TabIndex = 55;
			this.label4.Text = "Importazione del file di rendicontazione";
			// 
			// txtNomeFileRisposta
			// 
			this.txtNomeFileRisposta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtNomeFileRisposta.Location = new System.Drawing.Point(21, 92);
			this.txtNomeFileRisposta.Name = "txtNomeFileRisposta";
			this.txtNomeFileRisposta.ReadOnly = true;
			this.txtNomeFileRisposta.Size = new System.Drawing.Size(567, 20);
			this.txtNomeFileRisposta.TabIndex = 54;
			// 
			// btnImportaFileEsito
			// 
			this.btnImportaFileEsito.Location = new System.Drawing.Point(21, 62);
			this.btnImportaFileEsito.Name = "btnImportaFileEsito";
			this.btnImportaFileEsito.Size = new System.Drawing.Size(196, 24);
			this.btnImportaFileEsito.TabIndex = 53;
			this.btnImportaFileEsito.Text = "Seleziona File";
			this.btnImportaFileEsito.Click += new System.EventHandler(this.btnImportaFileEsito_Click);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "");
			this.imageList1.Images.SetKeyName(1, "");
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// textBox6
			// 
			this.textBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox6.Location = new System.Drawing.Point(695, 31);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(87, 20);
			this.textBox6.TabIndex = 153;
			this.textBox6.Tag = "flussoincassi.idflusso";
			this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label14
			// 
			this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label14.Location = new System.Drawing.Point(695, 11);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(56, 16);
			this.label14.TabIndex = 152;
			this.label14.Text = "ID flusso";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Frmflussoincassi_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(854, 700);
			this.Controls.Add(this.MetaDataDetail);
			this.Controls.Add(this.splitter1);
			this.Name = "Frmflussoincassi_default";
			this.Text = "Frmflussoincassi_default";
			this.MetaDataDetail.ResumeLayout(false);
			this.tabPrincipale.ResumeLayout(false);
			this.tabPrincipale.PerformLayout();
			this.gboxBill.ResumeLayout(false);
			this.gboxBill.PerformLayout();
			this.gboxBilancio.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        CQueryHelper QHC;
        QueryHelper QHS;

        private DataAccess Conn;
        string partner;

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHS = Conn.GetQueryHelper();
            QHC = new CQueryHelper();

            int esercizio = Conn.GetEsercizio();

            string filterBill = QHS.AppAnd(
                QHS.CmpEq("ybill", esercizio),
                QHS.CmpEq("billkind", 'C')
            );
            GetData.SetStaticFilter(DS.bill, filterBill);
            GetData.SetStaticFilter(DS.billview, filterBill);

            string filterFlussoIncassi = QHS.CmpEq("ayear", esercizio);
            GetData.SetStaticFilter(DS.flussoincassi, filterFlussoIncassi);

            var obj = Conn.DO_READ_VALUE("partner_config", null, "code");
            if (obj != null) {
                partner = obj.ToString();
            }
        }

        private void AggiornaImportoTotale() {
            decimal totale = 0;

            foreach (DataRow R in DS.flussoincassidetail.Select(null, "iddetail")) {
                if (R.RowState == DataRowState.Deleted) continue;

                decimal importodetail = CfgFn.GetNoNullDecimal(R["importo"]);
                totale += importodetail;
            }

            txtImportoTotale.Text = totale.ToString("c");
        }

        public void MetaData_AfterClear() {
            btnImportaFileEsito.Enabled = !Meta.InsertMode && !Meta.EditMode;
            btnEsitiSospesi.Visible = Meta.IsEmpty;
        }

        public void MetaData_AfterFill() {
            AggiornaImportoTotale();

            btnImportaFileEsito.Enabled = !Meta.InsertMode && !Meta.EditMode;
            btnEsitiSospesi.Visible = Meta.IsEmpty;
        }

        /// <summary>
        /// Importa i dettagli flusso incassi prendendoli da un file, di solito fornito dalla banca
        /// Il collegamento con il credito Ë effettuato sempre e solo con lo IUV del credito
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImportaFileEsito_Click(object sender, EventArgs e) {
            DialogResult dr = openFileDialog1.ShowDialog(this);
            if (dr != DialogResult.OK)
                return;
            string fileName = openFileDialog1.FileName;
            txtNomeFileRisposta.Text = fileName;

            Application.DoEvents();

            // Crea le righe in Flussoincassi e Flussoincassidetail, valorizzando Num.Bolletta e IUV
            DS.flussoincassi.Clear();
            DS.flussoincassidetail.Clear();
            MetaData MetaFlussoIncassi = MetaData.GetMetaData(this, "flussoincassi");
            MetaFlussoIncassi.SetDefaults(DS.flussoincassi);
            MetaData.SetDefault(DS.flussoincassi, "ayear", Meta.GetSys("esercizio"));

            MetaData MetaFlussoIncassiDetail = MetaData.GetMetaData(this, "flussoincassidetail");
            MetaFlussoIncassiDetail.SetDefaults(DS.flussoincassidetail);

			switch (partner) {
                //Per ogni banca ci serve importare l'associazione tra IUV   e : 
                // o il n. di sospeso (che Ë l'ideale) oppure la causale che troveremo nel bollettino , che sarebbe
                //  "/PUR/LGPE-RIVERSAMENTO/URI/" + codiceFlusso  (che non Ë il TRN);
            
                case "valtellinese":

                    string err2= pagoPaService.PagoPaService.elaboraRendicontoPagoPA(Conn, null, fileName);
                    if (err2 != null) {
                        MessageBox.Show(this, err2);
                        return;
                    }
                    MessageBox.Show(this, "Elaborazione del file completata");
                    return;
                case "unicredit":
                case "ubibanca":
                    DataTable tFlussoBanca;
					bool Intestazione = false;
					if (partner == "unicredit") {
						Intestazione = Unicredit.FlussoIncassi.IntestazionePresenteUnicredit(fileName);
					}
					string err = Unicredit.FlussoIncassi.Elabora(fileName, Intestazione, out tFlussoBanca, partner);

					if (err!=null) {
                        MessageBox.Show(this, err);
                        return;
                    }

                    foreach (DataRow R in tFlussoBanca.Rows) {
                        DataRow rFlussoIncassi = MetaFlussoIncassi.Get_New_Row(null, DS.flussoincassi);

                        rFlussoIncassi["codiceflusso"] = DBNull.Value;
                        rFlussoIncassi["trn"] = DBNull.Value;
                        rFlussoIncassi["causale"] = R["ZCAU"];
                        rFlussoIncassi["dataincasso"] = (DateTime) R["DDATINC"];
                        rFlussoIncassi["nbill"] = R["NPRO"];
                        rFlussoIncassi["importo"] = R["IIMPVER"];
						//r["CESE"] //len:	4	NUMERICO 	int:	4	 dec:	0		Esercizio di riferimento del provvisorio di Tesoreria associato allíincasso

                        DataRow rFlussoIncassiDetail = MetaFlussoIncassiDetail.Get_New_Row(rFlussoIncassi, DS.flussoincassidetail);
                        rFlussoIncassiDetail["iuv"] = R["CIUV"];
                        rFlussoIncassiDetail["importo"] = R["IIMPVER"];

                        rFlussoIncassiDetail["dataesitopagamento"] = (DateTime)R["DDATPAG"];

                        string filterIUV = QHS.CmpEq("iuv", R["CIUV"]);
                        object idflusso = Meta.Conn.DO_READ_VALUE("flussocreditidetail", filterIUV, "idflusso");
                        if (idflusso != null) {
                            var credDet = Meta.Conn.readObject("flussocreditidetail",
                                q.eq("iuv", R["CIUV"]), "idupb,cf,iduniqueformcode,p_iva");

                            object idupb = credDet["idupb"];
                            object cf = credDet["cf"];
							object p_iva = credDet["p_iva"];
							//L'upb del dettaglio credito Ë usato per ottenere gli attributi di sicurezza
							DataRow attrs = GetAttributiUPB(idupb.ToString());
                            if (attrs != null) {
                                rFlussoIncassi["idsor01"] = attrs["idsor01"];
                                rFlussoIncassi["idsor02"] = attrs["idsor02"];
                                rFlussoIncassi["idsor03"] = attrs["idsor03"];
                                rFlussoIncassi["idsor04"] = attrs["idsor04"];
                                rFlussoIncassi["idsor05"] = attrs["idsor05"];
                            }
                            
                            //prende il codice bollettino dal credito                            
                            //per comodit‡ dell'utente valorizziamo il n. bollettino nel dettaglio incasso
                            rFlussoIncassiDetail["iduniqueformcode"] = credDet["iduniqueformcode"];
                            rFlussoIncassiDetail["cf"] = cf;
							rFlussoIncassiDetail["p_iva"] = p_iva;
                            
                        }
                        else {
	                        if (R["SIDNVER"].ToString().ToUpperInvariant() == "PI") {
    							rFlussoIncassiDetail["p_iva"] = R["CIDNVER"];
	                        }
	                        else {
		                        rFlussoIncassiDetail["cf"] = R["CIDNVER"];
	                        }
                        }
                    }

                    break;

                case "bsondrio":
                    FlussoIncassi flussoIncassi;
                    string errore = FlussoIncassi.Elabora(fileName, out flussoIncassi);
                    if (!string.IsNullOrEmpty(errore)) {
                        MessageBox.Show(this, errore, "Errore");
                        return;
                    }

                    foreach (var disposizione in flussoIncassi.Disposizioni.Values) {
                        DataRow rFlussoIncassi = MetaFlussoIncassi.Get_New_Row(null, DS.flussoincassi);

                        rFlussoIncassi["codiceflusso"] = DBNull.Value;
                        rFlussoIncassi["trn"] = DBNull.Value;
                        rFlussoIncassi["causale"] = disposizione.RiferimentoDebito;
                        rFlussoIncassi["dataincasso"] = disposizione.DataQuietanza;//era DataPagamento ma Ë la scadenza
                        rFlussoIncassi["nbill"] = disposizione.NumeroProvvisorio;
                        rFlussoIncassi["importo"] = disposizione.Importo;

                        DataRow rFlussoIncassiDetail = MetaFlussoIncassiDetail.Get_New_Row(rFlussoIncassi,
                            DS.flussoincassidetail);
                        rFlussoIncassiDetail["iuv"] = disposizione.IUV;
                        rFlussoIncassiDetail["importo"] = disposizione.Importo;

                        string filterIUV = QHS.CmpEq("iuv", disposizione.IUV);
                        object idflusso = Meta.Conn.DO_READ_VALUE("flussocreditidetail", filterIUV, "idflusso");
                        if (idflusso != null) {
                            var credDet = Meta.Conn.readObject("flussocreditidetail",
                                q.eq("iuv", disposizione.IUV), "idupb,cf,iduniqueformcode");

                            object idupb = credDet["idupb"];
                            object cf = credDet["cf"];
							object p_iva = credDet["p_iva"];
							//L'upb del dettaglio credito Ë usato per ottenere gli attributi di sicurezza
							DataRow attrs = GetAttributiUPB(idupb.ToString());
                            rFlussoIncassi["idsor01"] = attrs["idsor01"];
                            rFlussoIncassi["idsor02"] = attrs["idsor02"];
                            rFlussoIncassi["idsor03"] = attrs["idsor03"];
                            rFlussoIncassi["idsor04"] = attrs["idsor04"];
                            rFlussoIncassi["idsor05"] = attrs["idsor05"];
                            //prende il codice bollettino dal credito 
                            //per comodit‡ dell'utente valorizziamo il n. bollettino nel dettaglio incasso
                            rFlussoIncassiDetail["iduniqueformcode"] = credDet["iduniqueformcode"];
                            rFlussoIncassiDetail["cf"] = cf;
							rFlussoIncassiDetail["p_iva"] = p_iva;
                            rFlussoIncassiDetail["dataesitopagamento"] = disposizione.DataPagamento;
                            rFlussoIncassiDetail["codicepsp"] = disposizione.CodiceIdentificativoUnivoco;
                            rFlussoIncassiDetail["identificativounivocoriscossione"] = disposizione.IdentificativoTransazione;
                        }
                    }

                    break;
            }

            MessageBox.Show(this, "Elaborazione del file completata");

            Meta.DoMainCommand("mainsave");
        }

		private DataRow GetAttributiUPB(string idupb) {
            if (idupb == null || DBNull.Value.Equals(idupb)) {
                return null;
            }

            string filter = QHS.CmpEq("idupb", idupb);

            DataTable dt = Meta.Conn.RUN_SELECT("upb", "idsor01, idsor02, idsor03, idsor04, idsor05", null, filter, null, false);
            if (dt == null || dt.Rows.Count == 0) {
                return null;
            }

            return dt.Rows[0];
        }

    }

}
