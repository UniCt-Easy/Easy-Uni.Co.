
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using System.Data.SqlClient;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;//funzioni_configurazione
using System.Collections.Generic;
using System.Text;
using siopeplus_functions;
using incassi = bankdispositionsetup_siopeplus_incassi;
using System.Linq;
using System.IO;

namespace proceeds_generazioneautomatica { //documentoincasso_gener_auto//

    /// <summary>
    /// Summary description for frmdocumentoincasso_gener_auto.
    /// revised By Nino 26/1/2003
    /// revised by NIno on 20/2/2003
    /// </summary>
    public class Frm_proceeds_generazioneautomatica : System.Windows.Forms.Form {
        QueryHelper QHS;
        CQueryHelper QHC;
        private System.Windows.Forms.ComboBox cmbCodiceIstituto;
        private System.Windows.Forms.Button btnIstitutoCassiere;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtImporto;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Button btnSiTutti;
        private System.Windows.Forms.Button btnSi;
        private System.Windows.Forms.Button btnChiudi;
        private System.Windows.Forms.Button btnSuccessivo;
        private System.Windows.Forms.Button btnInizia;
        private System.Windows.Forms.TextBox txtResponsabile;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDataContabile;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCreditoreDebitore;
        private System.Windows.Forms.TextBox txtDescrBilancio;
        private System.Windows.Forms.TextBox txtBilancio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNumeroDocumento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEsercizioDocumento;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTipoDocumento;
        public vistaForm DS;
        DataTable TempTable;
        int limiteOPIinByte = 184320;
        private System.Windows.Forms.GroupBox grpConto;
        private System.Windows.Forms.RadioButton rdbInfruttifero;
        private System.Windows.Forms.RadioButton rdbFruttifero;
        private System.Windows.Forms.GroupBox grpConferma;
        MetaData Meta;
        DataAccess Conn;
        object livbilancio = DBNull.Value; //livello bilancio di raggruppamento 
        private System.Windows.Forms.DataGrid DetailGrid;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private Button btnBollo;
        private ComboBox cmbBollo;
        private CheckBox chkCSA;
        private Label label10;
        private TextBox textBox1;
        private CheckBox chkCrediti;
        private System.ComponentModel.IContainer components;

        public Frm_proceeds_generazioneautomatica() {
            InitializeComponent();
            TempTable = new DataTable("temptable");
            QueryCreator.SetTableForPosting(DS.incomelastview, "incomelast");
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_proceeds_generazioneautomatica));
			this.cmbCodiceIstituto = new System.Windows.Forms.ComboBox();
			this.DS = new proceeds_generazioneautomatica.vistaForm();
			this.btnIstitutoCassiere = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.DetailGrid = new System.Windows.Forms.DataGrid();
			this.label5 = new System.Windows.Forms.Label();
			this.txtImporto = new System.Windows.Forms.TextBox();
			this.grpConferma = new System.Windows.Forms.GroupBox();
			this.btnNo = new System.Windows.Forms.Button();
			this.btnSiTutti = new System.Windows.Forms.Button();
			this.btnSi = new System.Windows.Forms.Button();
			this.btnChiudi = new System.Windows.Forms.Button();
			this.btnSuccessivo = new System.Windows.Forms.Button();
			this.btnInizia = new System.Windows.Forms.Button();
			this.txtResponsabile = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.txtDataContabile = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtCreditoreDebitore = new System.Windows.Forms.TextBox();
			this.txtDescrBilancio = new System.Windows.Forms.TextBox();
			this.txtBilancio = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtNumeroDocumento = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtEsercizioDocumento = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtTipoDocumento = new System.Windows.Forms.TextBox();
			this.grpConto = new System.Windows.Forms.GroupBox();
			this.rdbInfruttifero = new System.Windows.Forms.RadioButton();
			this.rdbFruttifero = new System.Windows.Forms.RadioButton();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.label10 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.btnBollo = new System.Windows.Forms.Button();
			this.cmbBollo = new System.Windows.Forms.ComboBox();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.chkCSA = new System.Windows.Forms.CheckBox();
			this.chkCrediti = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DetailGrid)).BeginInit();
			this.grpConferma.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.grpConto.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmbCodiceIstituto
			// 
			this.cmbCodiceIstituto.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.cmbCodiceIstituto.DataSource = this.DS.treasurer;
			this.cmbCodiceIstituto.DisplayMember = "description";
			this.cmbCodiceIstituto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCodiceIstituto.Location = new System.Drawing.Point(78, 16);
			this.cmbCodiceIstituto.Name = "cmbCodiceIstituto";
			this.cmbCodiceIstituto.Size = new System.Drawing.Size(210, 21);
			this.cmbCodiceIstituto.TabIndex = 1;
			this.cmbCodiceIstituto.Tag = "proceeds.idtreasurer";
			this.cmbCodiceIstituto.ValueMember = "idtreasurer";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// btnIstitutoCassiere
			// 
			this.btnIstitutoCassiere.Location = new System.Drawing.Point(8, 16);
			this.btnIstitutoCassiere.Name = "btnIstitutoCassiere";
			this.btnIstitutoCassiere.Size = new System.Drawing.Size(64, 24);
			this.btnIstitutoCassiere.TabIndex = 52;
			this.btnIstitutoCassiere.TabStop = false;
			this.btnIstitutoCassiere.Tag = "choose.treasurer.lista";
			this.btnIstitutoCassiere.Text = "Cassiere:";
			this.btnIstitutoCassiere.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox4.Controls.Add(this.DetailGrid);
			this.groupBox4.Location = new System.Drawing.Point(8, 120);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(800, 160);
			this.groupBox4.TabIndex = 7;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Elenco dei movimenti di entrata associati alla reversale";
			// 
			// DetailGrid
			// 
			this.DetailGrid.AllowNavigation = false;
			this.DetailGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.DetailGrid.DataMember = "";
			this.DetailGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.DetailGrid.Location = new System.Drawing.Point(8, 16);
			this.DetailGrid.Name = "DetailGrid";
			this.DetailGrid.Size = new System.Drawing.Size(785, 136);
			this.DetailGrid.TabIndex = 66;
			this.DetailGrid.Tag = "incomelastview.reversaleautomatica";
			this.DetailGrid.Paint += new System.Windows.Forms.PaintEventHandler(this.DetailGrid_Paint);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 24);
			this.label5.TabIndex = 65;
			this.label5.Text = "Importo totale della reversale:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtImporto
			// 
			this.txtImporto.Location = new System.Drawing.Point(96, 16);
			this.txtImporto.Name = "txtImporto";
			this.txtImporto.ReadOnly = true;
			this.txtImporto.Size = new System.Drawing.Size(96, 20);
			this.txtImporto.TabIndex = 63;
			this.txtImporto.TabStop = false;
			this.txtImporto.Tag = "";
			this.txtImporto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// grpConferma
			// 
			this.grpConferma.Controls.Add(this.btnNo);
			this.grpConferma.Controls.Add(this.btnSiTutti);
			this.grpConferma.Controls.Add(this.btnSi);
			this.grpConferma.Enabled = false;
			this.grpConferma.Location = new System.Drawing.Point(432, 0);
			this.grpConferma.Name = "grpConferma";
			this.grpConferma.Size = new System.Drawing.Size(256, 48);
			this.grpConferma.TabIndex = 2;
			this.grpConferma.TabStop = false;
			this.grpConferma.Text = "Genera Reversale";
			// 
			// btnNo
			// 
			this.btnNo.Location = new System.Drawing.Point(96, 16);
			this.btnNo.Name = "btnNo";
			this.btnNo.Size = new System.Drawing.Size(64, 23);
			this.btnNo.TabIndex = 74;
			this.btnNo.TabStop = false;
			this.btnNo.Tag = "unlink";
			this.btnNo.Text = "No";
			this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
			// 
			// btnSiTutti
			// 
			this.btnSiTutti.Location = new System.Drawing.Point(184, 16);
			this.btnSiTutti.Name = "btnSiTutti";
			this.btnSiTutti.Size = new System.Drawing.Size(64, 23);
			this.btnSiTutti.TabIndex = 73;
			this.btnSiTutti.TabStop = false;
			this.btnSiTutti.Text = "Sì tutte";
			this.btnSiTutti.Click += new System.EventHandler(this.btnSiTutti_Click);
			// 
			// btnSi
			// 
			this.btnSi.Location = new System.Drawing.Point(8, 16);
			this.btnSi.Name = "btnSi";
			this.btnSi.Size = new System.Drawing.Size(64, 23);
			this.btnSi.TabIndex = 72;
			this.btnSi.TabStop = false;
			this.btnSi.Text = "Sì";
			this.btnSi.Click += new System.EventHandler(this.btnSi_Click);
			// 
			// btnChiudi
			// 
			this.btnChiudi.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnChiudi.Location = new System.Drawing.Point(208, 16);
			this.btnChiudi.Name = "btnChiudi";
			this.btnChiudi.Size = new System.Drawing.Size(80, 23);
			this.btnChiudi.TabIndex = 88;
			this.btnChiudi.TabStop = false;
			this.btnChiudi.Text = "Termina";
			// 
			// btnSuccessivo
			// 
			this.btnSuccessivo.Enabled = false;
			this.btnSuccessivo.Location = new System.Drawing.Point(112, 16);
			this.btnSuccessivo.Name = "btnSuccessivo";
			this.btnSuccessivo.Size = new System.Drawing.Size(80, 23);
			this.btnSuccessivo.TabIndex = 87;
			this.btnSuccessivo.TabStop = false;
			this.btnSuccessivo.Text = "Prossimo >>";
			this.btnSuccessivo.Click += new System.EventHandler(this.btnSuccessivo_Click);
			// 
			// btnInizia
			// 
			this.btnInizia.Location = new System.Drawing.Point(16, 16);
			this.btnInizia.Name = "btnInizia";
			this.btnInizia.Size = new System.Drawing.Size(80, 23);
			this.btnInizia.TabIndex = 86;
			this.btnInizia.TabStop = false;
			this.btnInizia.Text = "Inizia Ricerca";
			this.btnInizia.Click += new System.EventHandler(this.btnInizia_Click);
			// 
			// txtResponsabile
			// 
			this.txtResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtResponsabile.Location = new System.Drawing.Point(296, 80);
			this.txtResponsabile.Name = "txtResponsabile";
			this.txtResponsabile.ReadOnly = true;
			this.txtResponsabile.Size = new System.Drawing.Size(480, 20);
			this.txtResponsabile.TabIndex = 85;
			this.txtResponsabile.TabStop = false;
			this.txtResponsabile.Tag = "manager.title";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(296, 64);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(88, 16);
			this.label7.TabIndex = 84;
			this.label7.Text = "Responsabile:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// label4
			// 
			this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label4.ImageIndex = 0;
			this.label4.ImageList = this.imageList1;
			this.label4.Location = new System.Drawing.Point(8, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 16);
			this.label4.TabIndex = 83;
			this.label4.Text = "Bilancio:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "");
			// 
			// txtDataContabile
			// 
			this.txtDataContabile.Location = new System.Drawing.Point(96, 48);
			this.txtDataContabile.Name = "txtDataContabile";
			this.txtDataContabile.Size = new System.Drawing.Size(96, 20);
			this.txtDataContabile.TabIndex = 2;
			this.txtDataContabile.Tag = "proceeds.adate";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(8, 48);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(80, 16);
			this.label9.TabIndex = 82;
			this.label9.Text = "Data contabile:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 16);
			this.label3.TabIndex = 80;
			this.label3.Text = "Versante:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtCreditoreDebitore
			// 
			this.txtCreditoreDebitore.Location = new System.Drawing.Point(8, 80);
			this.txtCreditoreDebitore.Name = "txtCreditoreDebitore";
			this.txtCreditoreDebitore.ReadOnly = true;
			this.txtCreditoreDebitore.Size = new System.Drawing.Size(280, 20);
			this.txtCreditoreDebitore.TabIndex = 79;
			this.txtCreditoreDebitore.TabStop = false;
			this.txtCreditoreDebitore.Tag = "registry.title?proceedsview.registry";
			// 
			// txtDescrBilancio
			// 
			this.txtDescrBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrBilancio.Location = new System.Drawing.Point(112, 16);
			this.txtDescrBilancio.Multiline = true;
			this.txtDescrBilancio.Name = "txtDescrBilancio";
			this.txtDescrBilancio.ReadOnly = true;
			this.txtDescrBilancio.Size = new System.Drawing.Size(448, 48);
			this.txtDescrBilancio.TabIndex = 78;
			this.txtDescrBilancio.TabStop = false;
			this.txtDescrBilancio.Tag = "fin.title";
			// 
			// txtBilancio
			// 
			this.txtBilancio.Location = new System.Drawing.Point(8, 40);
			this.txtBilancio.Name = "txtBilancio";
			this.txtBilancio.ReadOnly = true;
			this.txtBilancio.Size = new System.Drawing.Size(96, 20);
			this.txtBilancio.TabIndex = 77;
			this.txtBilancio.TabStop = false;
			this.txtBilancio.Tag = "fin.codefin?proceedsview.codefin";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtNumeroDocumento);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtEsercizioDocumento);
			this.groupBox1.Location = new System.Drawing.Point(8, 48);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(144, 72);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Documento";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Numero:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtNumeroDocumento
			// 
			this.txtNumeroDocumento.Location = new System.Drawing.Point(80, 40);
			this.txtNumeroDocumento.Name = "txtNumeroDocumento";
			this.txtNumeroDocumento.ReadOnly = true;
			this.txtNumeroDocumento.Size = new System.Drawing.Size(56, 20);
			this.txtNumeroDocumento.TabIndex = 2;
			this.txtNumeroDocumento.TabStop = false;
			this.txtNumeroDocumento.Tag = "proceeds.npro";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Esercizio:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtEsercizioDocumento
			// 
			this.txtEsercizioDocumento.Location = new System.Drawing.Point(80, 16);
			this.txtEsercizioDocumento.Name = "txtEsercizioDocumento";
			this.txtEsercizioDocumento.ReadOnly = true;
			this.txtEsercizioDocumento.Size = new System.Drawing.Size(56, 20);
			this.txtEsercizioDocumento.TabIndex = 0;
			this.txtEsercizioDocumento.TabStop = false;
			this.txtEsercizioDocumento.Tag = "proceeds.ypro";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.txtTipoDocumento);
			this.groupBox2.Location = new System.Drawing.Point(160, 48);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(120, 72);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Tipo";
			// 
			// txtTipoDocumento
			// 
			this.txtTipoDocumento.Location = new System.Drawing.Point(8, 24);
			this.txtTipoDocumento.Name = "txtTipoDocumento";
			this.txtTipoDocumento.ReadOnly = true;
			this.txtTipoDocumento.Size = new System.Drawing.Size(104, 20);
			this.txtTipoDocumento.TabIndex = 3;
			this.txtTipoDocumento.TabStop = false;
			this.txtTipoDocumento.Tag = "";
			// 
			// grpConto
			// 
			this.grpConto.Controls.Add(this.rdbInfruttifero);
			this.grpConto.Controls.Add(this.rdbFruttifero);
			this.grpConto.Location = new System.Drawing.Point(288, 48);
			this.grpConto.Name = "grpConto";
			this.grpConto.Size = new System.Drawing.Size(96, 72);
			this.grpConto.TabIndex = 5;
			this.grpConto.TabStop = false;
			this.grpConto.Text = "Conto";
			// 
			// rdbInfruttifero
			// 
			this.rdbInfruttifero.Location = new System.Drawing.Point(8, 40);
			this.rdbInfruttifero.Name = "rdbInfruttifero";
			this.rdbInfruttifero.Size = new System.Drawing.Size(80, 16);
			this.rdbInfruttifero.TabIndex = 1;
			this.rdbInfruttifero.Tag = "proceeds.flag::#3";
			this.rdbInfruttifero.Text = "Infruttifero";
			// 
			// rdbFruttifero
			// 
			this.rdbFruttifero.Location = new System.Drawing.Point(8, 16);
			this.rdbFruttifero.Name = "rdbFruttifero";
			this.rdbFruttifero.Size = new System.Drawing.Size(80, 16);
			this.rdbFruttifero.TabIndex = 0;
			this.rdbFruttifero.Tag = "proceeds.flag::3";
			this.rdbFruttifero.Text = "Fruttifero";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.btnChiudi);
			this.groupBox3.Controls.Add(this.btnSuccessivo);
			this.groupBox3.Controls.Add(this.btnInizia);
			this.groupBox3.Location = new System.Drawing.Point(129, 0);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(296, 48);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Operazioni";
			// 
			// groupBox5
			// 
			this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox5.Controls.Add(this.groupBox8);
			this.groupBox5.Controls.Add(this.groupBox7);
			this.groupBox5.Location = new System.Drawing.Point(8, 288);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(800, 192);
			this.groupBox5.TabIndex = 8;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Dati riepilogativi";
			// 
			// groupBox8
			// 
			this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox8.Controls.Add(this.label10);
			this.groupBox8.Controls.Add(this.textBox1);
			this.groupBox8.Controls.Add(this.btnBollo);
			this.groupBox8.Controls.Add(this.cmbBollo);
			this.groupBox8.Controls.Add(this.btnIstitutoCassiere);
			this.groupBox8.Controls.Add(this.cmbCodiceIstituto);
			this.groupBox8.Location = new System.Drawing.Point(8, 136);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(784, 48);
			this.groupBox8.TabIndex = 2;
			this.groupBox8.TabStop = false;
			// 
			// label10
			// 
			this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label10.Location = new System.Drawing.Point(599, 7);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(101, 38);
			this.label10.TabIndex = 58;
			this.label10.Text = "Numero Progr. Cassiere:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox1
			// 
			this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.textBox1.Location = new System.Drawing.Point(706, 16);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(72, 20);
			this.textBox1.TabIndex = 57;
			this.textBox1.TabStop = false;
			this.textBox1.Tag = "proceeds.npro_treasurer";
			// 
			// btnBollo
			// 
			this.btnBollo.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnBollo.Location = new System.Drawing.Point(294, 14);
			this.btnBollo.Name = "btnBollo";
			this.btnBollo.Size = new System.Drawing.Size(48, 24);
			this.btnBollo.TabIndex = 56;
			this.btnBollo.TabStop = false;
			this.btnBollo.Tag = "choose.stamphandling.lista";
			this.btnBollo.Text = "Bollo:";
			this.btnBollo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbBollo
			// 
			this.cmbBollo.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.cmbBollo.DataSource = this.DS.stamphandling;
			this.cmbBollo.DisplayMember = "description";
			this.cmbBollo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbBollo.Location = new System.Drawing.Point(347, 16);
			this.cmbBollo.Name = "cmbBollo";
			this.cmbBollo.Size = new System.Drawing.Size(246, 21);
			this.cmbBollo.TabIndex = 55;
			this.cmbBollo.Tag = "proceeds.idstamphandling";
			this.cmbBollo.ValueMember = "idstamphandling";
			// 
			// groupBox7
			// 
			this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox7.Controls.Add(this.label4);
			this.groupBox7.Controls.Add(this.txtBilancio);
			this.groupBox7.Controls.Add(this.txtDescrBilancio);
			this.groupBox7.Controls.Add(this.label3);
			this.groupBox7.Controls.Add(this.txtCreditoreDebitore);
			this.groupBox7.Controls.Add(this.txtResponsabile);
			this.groupBox7.Controls.Add(this.label7);
			this.groupBox7.Location = new System.Drawing.Point(8, 16);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(784, 114);
			this.groupBox7.TabIndex = 1;
			this.groupBox7.TabStop = false;
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.txtDataContabile);
			this.groupBox6.Controls.Add(this.label9);
			this.groupBox6.Controls.Add(this.label5);
			this.groupBox6.Controls.Add(this.txtImporto);
			this.groupBox6.Location = new System.Drawing.Point(391, 48);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(200, 72);
			this.groupBox6.TabIndex = 6;
			this.groupBox6.TabStop = false;
			// 
			// chkCSA
			// 
			this.chkCSA.AutoSize = true;
			this.chkCSA.Location = new System.Drawing.Point(16, 12);
			this.chkCSA.Name = "chkCSA";
			this.chkCSA.Size = new System.Drawing.Size(94, 17);
			this.chkCSA.TabIndex = 9;
			this.chkCSA.Text = "Reversali CSA";
			this.chkCSA.UseVisualStyleBackColor = true;
			this.chkCSA.CheckedChanged += new System.EventHandler(this.chkCSA_CheckedChanged);
			// 
			// chkCrediti
			// 
			this.chkCrediti.AutoSize = true;
			this.chkCrediti.Location = new System.Drawing.Point(16, 31);
			this.chkCrediti.Name = "chkCrediti";
			this.chkCrediti.Size = new System.Drawing.Size(88, 17);
			this.chkCrediti.TabIndex = 10;
			this.chkCrediti.Text = "Flusso Crediti";
			this.chkCrediti.UseVisualStyleBackColor = true;
			this.chkCrediti.CheckStateChanged += new System.EventHandler(this.chkCrediti_CheckStateChanged);
			// 
			// Frm_proceeds_generazioneautomatica
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(818, 486);
			this.Controls.Add(this.chkCrediti);
			this.Controls.Add(this.chkCSA);
			this.Controls.Add(this.groupBox6);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.grpConferma);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.grpConto);
			this.Name = "Frm_proceeds_generazioneautomatica";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DetailGrid)).EndInit();
			this.grpConferma.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.grpConto.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			this.groupBox8.PerformLayout();
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private void CalcolaImporto() {
            DataRow[] selectedrows = GetGridSelectedRows();
            decimal somma = 0;
            for (int i = 0; i < selectedrows.Length; i++) {
                somma += CfgFn.GetNoNullDecimal((selectedrows[i]["curramount"]));
            }
            txtImporto.Text = somma.ToString("c");
        }

        public void AfterLinkBody() {
            Conn = Meta.Conn;
            QHS = Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            string filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.CacheTable(DS.incomephase);
            GetData.CacheTable(DS.config, filter, null, false);
            GetData.SetStaticFilter(DS.incomelastview, QHS.CmpEq("ymov", Meta.GetSys("esercizio")));
            //GetData.SetStaticFilter(DS.bilancio, filter);
        }

        bool UsoSiope = false;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);

            AfterLinkBody();
            HelpForm.SetAllowMultiSelection(DS.incomelastview, true);
            GetData.SetStaticFilter(DS.proceeds, QHS.CmpEq("ypro", Meta.GetSys("esercizio")));
            UsoSiope = Verifica_Uso_SiopePlus();
        }

        //controlla che si debba usare la trasmissione Siope+ 
        public bool Verifica_Uso_SiopePlus() {
            object usesiopeplus = Conn.DO_READ_VALUE("opisiopeplus_config", QHS.CmpEq("code", "opi_siopeplus"), "usesiopeplus", null);
            if (usesiopeplus == null || usesiopeplus == DBNull.Value) return false;
            if (usesiopeplus.ToString()=="S") return true; 
            return false;
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (Meta.IsEmpty) return;
            if (T.TableName == "treasurer" && R != null) {
                DataRow RInc = DS.proceeds.Rows[0];
                int flag = CfgFn.GetNoNullInt32(RInc["flag"]);

                if (R["flagfruitful"].ToString().ToUpper() == "F") {
                    rdbInfruttifero.Checked = false;
                    rdbFruttifero.Checked = true;
                    flag = flag | 8;
                }
                else {
                    rdbFruttifero.Checked = false;
                    rdbInfruttifero.Checked = true;
                    flag = flag & 0xF7;
                }
                RInc["flag"] = flag;
            }
        }

        public void MetaData_AfterActivation() {
            grpConferma.Enabled = false;
            btnSuccessivo.Enabled = false;
            //R//
            rdbFruttifero.Enabled = false;
            rdbInfruttifero.Enabled = false;
            btnIstitutoCassiere.Enabled = false;
            cmbCodiceIstituto.Enabled = false;
            txtDataContabile.ReadOnly = true;
            //
            impostaColoreBottoni();
        }

        private void impostaColoreBottoni() {
            btnInizia.BackColor = formcolors.GridButtonBackColor();
            btnInizia.ForeColor = formcolors.GridButtonForeColor();
            btnSuccessivo.BackColor = formcolors.GridButtonBackColor();
            btnSuccessivo.ForeColor = formcolors.GridButtonForeColor();
            btnChiudi.BackColor = formcolors.GridButtonBackColor();
            btnChiudi.ForeColor = formcolors.GridButtonForeColor();
            btnSi.BackColor = formcolors.GridButtonBackColor();
            btnSi.ForeColor = formcolors.GridButtonForeColor();
            btnSiTutti.BackColor = formcolors.GridButtonBackColor();
            btnSiTutti.ForeColor = formcolors.GridButtonForeColor();
        }

        public void MetaData_AfterClear() {
            if (Meta.GointToInsertMode) return;
            //R//
            rdbFruttifero.Enabled = false;
            rdbInfruttifero.Enabled = false;
            btnIstitutoCassiere.Enabled = false;
            cmbCodiceIstituto.Enabled = false;
            txtDataContabile.ReadOnly = true;
            try {
                if (cmbCodiceIstituto.Items.Count > 1) cmbCodiceIstituto.SelectedIndex = 1;
            }
            catch {
            }
            //
//			if (Convert.ToInt16(Meta.GetSys("esercizio")) > 2001)
//				chbEuro.Visible=false;
        }

        string MyAppend(string source, string toappend) {
            if (source.Trim() == "") return toappend;
            return source + ", " + toappend + " ";
        }

        private Dictionary<int, bool> incassiCrediti = null;
        private void FillTempTable() {
            string ParteSelect, ParteFrom, ParteWhere, ParteGroupBy, ParteOrderBy, ParteHaving;
            string SelectClause, FromClause, WhereClause, GroupByClause, OrderByClause, HavingClause;

            int codicefase = CfgFn.GetNoNullInt32(Meta.GetSys("maxincomephase"));
            int giornianticipo = CfgFn.GetNoNullInt32(DS.Tables["config"].Rows[0]["income_expiringdays"]);
            int eserccorrente = (int) Meta.GetSys("esercizio");

            byte proceeds_flag = (byte) DS.Tables["config"].Rows[0]["proceeds_flag"];
            bool flagcreddeb = (proceeds_flag & 4) == 4;
            bool flagbilancio = (proceeds_flag & 2) == 2;

            if (chkCrediti.Checked) {
                flagcreddeb = false;
                //flagbilancio = false;
            }

            livbilancio = DS.Tables["config"].Rows[0]["proceeds_finlevel"];
            object maxlivbilancio = Meta.Conn.DO_READ_VALUE("finlevel", QHS.CmpEq("ayear", eserccorrente), "max(nlevel)");
            if ((livbilancio.Equals(maxlivbilancio)) || !flagbilancio) {
                livbilancio = DBNull.Value;
            }
            bool flagrespons = (proceeds_flag & 16) == 16;
            bool flagresidui = (proceeds_flag & 8) == 8;

            //DateTime scadenza = (DateTime) Meta.GetSys("datacontabile");
            //scadenza.AddDays( giornianticipo);

            ParteWhere = QHS.AppAnd(QHS.IsNull("kpro"),
                QHS.CmpEq("ayear", eserccorrente),
                QHS.CmpEq("nphase", codicefase) //,QHS.NullOrLe("expiration", scadenza)
                );
            if (chkCSA.Checked)
                ParteWhere = QHS.AppAnd(ParteWhere, QHS.FieldInList("autokind", "20,21,30,31"));

            if (Conn.GetSys("idflowchart") != null && Conn.GetSys("idflowchart").ToString() != "") {
                string security = Conn.SelectCondition("incomelastview", true);
                ParteWhere = QHS.AppAnd(ParteWhere, security);
            }

            incassiCrediti = null;
            if (true) {

                var incassi = Conn.SQLRunner($@"
                    select I.idinc from incomelastview I
                        join incomelink IL on IL.idchild=I.idinc and {QHS.CmpEq("nlevel", Conn.GetSys("incomephase"))} 
                        join incomeestimate IE on IE.idinc=IL.idparent
                        join estimatekind EK on IE.idestimkind=EK.idestimkind
                    where {QHS.AppAnd(QHS.IsNull("I.kpro"), QHS.CmpEq("ayear", Conn.GetEsercizio()), QHS.BitSet("EK.flag", 2)),0}
                ",false,120);
                if (incassi != null) {
                    incassiCrediti= new Dictionary<int, bool>();
                    foreach (DataRow r in incassi.Rows) {
                        incassiCrediti[CfgFn.GetNoNullInt32(r["idinc"])] = true;
                    }
                }
            }
            string MainTable = "incomelastview";
            if (chkCrediti.Checked) {
                flagcreddeb = false;
                //flagbilancio = false;
            }

            ParteFrom = "incomelastview";
            SelectClause = "SELECT ";
            FromClause = " FROM ";
            WhereClause = " WHERE ";
            GroupByClause = " GROUP BY ";
            OrderByClause = " ORDER BY ";
            HavingClause = " HAVING ";
            ParteSelect = "idtreasurer_main"; //"flageuro";
            ParteGroupBy = "idtreasurer_main"; //"flageuro";
            ParteOrderBy = "idtreasurer_main ASC"; //"flageuro ASC";
            //togliere flageuro da tutte le parti
            if (flagcreddeb) {
                ParteSelect = MyAppend(ParteSelect, MainTable + "." + "idreg");
                ParteSelect = MyAppend(ParteSelect, MainTable + "." + "registry");
                ParteGroupBy = MyAppend(ParteGroupBy, MainTable + "." + "idreg");
                ParteGroupBy = MyAppend(ParteGroupBy, MainTable + "." + "registry");
                ParteOrderBy = MyAppend(ParteOrderBy, MainTable + "." + "registry ASC");
                ParteOrderBy = MyAppend(ParteOrderBy, MainTable + "." + "idreg ASC");
            }

            if (flagbilancio) {
                if (livbilancio == DBNull.Value) {
                    ParteSelect = MyAppend(ParteSelect, MainTable + "." + "idfin");
                    ParteSelect = MyAppend(ParteSelect, MainTable + "." + "codefin");
                    ParteGroupBy = MyAppend(ParteGroupBy, MainTable + "." + "idfin");
                    ParteGroupBy = MyAppend(ParteGroupBy, MainTable + "." + "codefin");
                    ParteOrderBy = MyAppend(ParteOrderBy, MainTable + "." + "codefin ASC");
                }
                else {
                    ParteFrom = ParteFrom + " JOIN finlink ON finlink.idchild = " + MainTable
                                + ".idfin AND finlink.nlevel = " + QHS.quote(livbilancio);
                    //string fnbilancio = "(select idparent from finlink where finlink.idchild="
                    //    + ParteFrom + ".idfin and nlevel=" + QHS.quote(livbilancio) + ")";
                    //ParteSelect = MyAppend(ParteSelect, fnbilancio + "AS idfin");
                    ParteSelect = MyAppend(ParteSelect, "idparent");
                    //ParteGroupBy = MyAppend(ParteGroupBy, "idparent,codefin");
                    ParteGroupBy = MyAppend(ParteGroupBy, "idparent");
                    //ParteOrderBy = MyAppend(ParteOrderBy, "codefin ASC");
                    ParteOrderBy = MyAppend(ParteOrderBy, "idparent ASC");
                }
            }

            // è necessario raggruppare per tesoriere del mandato principale se esiste
            //ParteSelect = MyAppend(ParteSelect,   "payment" + "." + "idtreasurer");
            //ParteGroupBy = MyAppend(ParteGroupBy, "payment" + "." + "idtreasurer");
            //ParteOrderBy = MyAppend(ParteOrderBy, "payment" + "." + "idtreasurer ASC");


            //ParteFrom = ParteFrom + " LEFT OUTER JOIN expenselast ON expenselast.idexp = " + MainTable
            //            + ".idpayment " +
            //            "LEFT OUTER JOIN payment ON payment.kpay = expenselast.kpay ";


            if (flagrespons) {
                ParteSelect = MyAppend(ParteSelect, MainTable + "." + "idman,manager");
                ParteGroupBy = MyAppend(ParteGroupBy, MainTable + "." + "idman,manager");
                ParteOrderBy = MyAppend(ParteOrderBy, MainTable + "." + "manager ASC");
            }
            if (flagresidui) {
                ParteSelect = MyAppend(ParteSelect, "  flagarrear AS kind ");
                ParteGroupBy = MyAppend(ParteGroupBy, "flagarrear");
                ParteOrderBy = MyAppend(ParteOrderBy, "flagarrear ASC");
            }

            ParteHaving = "SUM(curramount) > 0";

            if (ParteGroupBy == "") GroupByClause = "";
            if (ParteOrderBy == "") OrderByClause = "";

            string MyQuery = "";
            if (ParteSelect != "") {
                MyQuery = SelectClause + ParteSelect + FromClause + ParteFrom +
                          WhereClause + ParteWhere + GroupByClause + ParteGroupBy +
                          HavingClause + ParteHaving + OrderByClause + ParteOrderBy;
            }

            if (MyQuery != "") {
                TempTable = Meta.Conn.SQLRunner(MyQuery, false, 300);
                if (TempTable == null) return;
            }
            else {
                TempTable.Columns.Add("UnicaReversale");
                TempTable.Rows.Add(new object[] {""});
            }
            if (TempTable.Columns.Contains("idparent")) {
                TempTable.Columns["idparent"].ColumnName = "idfin";
            }
        }

        private DataRow[] GetGridSelectedRows() {
            string TableName = DetailGrid.DataMember.ToString();
            DataSet MyDS = (DataSet) DetailGrid.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            int numrighetemp = MyTable.Rows.Count;
            int numrighe = 0;
            int i;
            for (i = 0; i < numrighetemp; i++) {
                if (DetailGrid.IsSelected(i)) {
                    numrighe++;
                }
            }
            Dictionary<int,DataRow> rowsByIdInc= new Dictionary<int, DataRow>();
            foreach (DataRow r in MyTable.Rows) rowsByIdInc[(int) r["idinc"]] = r;
            DataRow[] Res = new DataRow[numrighe];
            int count = 0;
            for (i = 0; i < numrighetemp; i++) {
                if (DetailGrid.IsSelected(i)) {
                    Res[count++] = rowsByIdInc[(int)DetailGrid[i,0]];
                }
            }
            return Res;
        }

        //DataRow GetDetailRow(int index) {
        //    string TableName = DetailGrid.DataMember.ToString();
        //    DataSet MyDS = (DataSet) DetailGrid.DataSource;
        //    DataTable MyTable = MyDS.Tables[TableName];
        //    string filter = QHC.CmpEq("idinc", DetailGrid[index, 0]);
        //    DataRow[] selectresult = MyTable.Select(filter);
        //    return selectresult[0];
        //}

        /// <summary>
        /// Crea una nuova riga e legge le righe del raggruppamento corrente in spesaview
        /// </summary>
        private DataRow PredisponiNuovoDocumento(/*bool quiet*/) {
            string MainTable = "incomelastview";
            DataRow rPersEntrata = DS.Tables["config"].Rows[0];
            byte proceeds_flag = (byte)rPersEntrata["proceeds_flag"];
            bool flagcreddeb = (proceeds_flag & 4) == 4;
            bool flagbilancio = (proceeds_flag & 2) == 2;
            bool flagrespons = (proceeds_flag & 16) == 16;
            bool flagresidui = (proceeds_flag & 8) == 8;
            if (chkCrediti.Checked) {
                flagcreddeb = false;
                //flagbilancio = false;
            }

            //int giornianticipo = CfgFn.GetNoNullInt32(rPersEntrata["income_expiringdays"]);
            int codicefase = CfgFn.GetNoNullInt32(Meta.GetSys("maxincomephase"));
            int eserccorrente = (int)Meta.GetSys("esercizio");
            //string esercsuffix=eserccorrente.Substring(2,2);
            string condizioniaggiuntive = QHS.CmpEq("ayear", eserccorrente);
            DataRow CurrRow = TempTable.Rows[0];
            //			object flageuro= "N";//CurrRow["flageuro"];
            //			MetaData.SetDefault(DS.proceeds, "flageuro", flageuro);
            //			if (flageuro==DBNull.Value){
            //				condizioniaggiuntive+= "AND(flageuro IS null)";
            //			}
            //			else {
            //				condizioniaggiuntive+= "AND(flageuro = '"+flageuro.ToString().ToUpper()+"')";
            //			}

            if (flagcreddeb) {
                object codicecreddeb = CurrRow["idreg"];
                MetaData.SetDefault(DS.proceeds, "idreg", codicecreddeb);
                condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive, QHS.CmpEq("idreg", codicecreddeb));
            }
            if (flagbilancio) {
                object idbilancio = CurrRow["idfin"];
                MetaData.SetDefault(DS.proceeds, "idfin", idbilancio);
                if (idbilancio != DBNull.Value) {
                    if (livbilancio == DBNull.Value)
                        condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive, QHS.CmpEq("idfin", idbilancio));
                    else
                        //condizioniaggiuntive+=" AND (idfin LIKE "+
                        //    QueryCreator.quotedstrvalue(idbilancio+"%",true)+")";
                        condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive,
                            QHS.FieldInList("idfin", "select idchild from finlink where "
                                                     + QHS.CmpEq("idparent", idbilancio)));
                    ;
                }
                else {
                    condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive, QHS.IsNull("idfin"));
                }
            }
            if (flagrespons) {
                object codiceresponsabile = CurrRow["idman"];
                MetaData.SetDefault(DS.proceeds, "idman", codiceresponsabile);
                condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive,
                    QHS.CmpEq("idman", codiceresponsabile));
            }
            int flag = 0;
            flag = flag & 0xF8;
            if (flagresidui) {
                object tipoincasso = CurrRow["kind"];
                if (tipoincasso.ToString().ToUpper() == "C") {
                    //def. C/Competenza
                    flag = flag + 1;
                    txtTipoDocumento.Text = "Competenza";
                }
                if (tipoincasso.ToString().ToUpper() == "R") {
                    //def. C/Residui
                    flag = flag + 2;
                    txtTipoDocumento.Text = "Residui";
                }
                if (rdbFruttifero.Checked) {
                    flag = flag + 8;
                }
                MetaData.SetDefault(DS.proceeds, "flag", flag);
                condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive,
                    QHS.CmpEq(MainTable + "." + "flagarrear", tipoincasso));
            }
            else {
                //def. Misto
                flag = flag + 4;
                txtTipoDocumento.Text = "Misto";
                if (rdbFruttifero.Checked) {
                    flag = flag + 8;
                }
                MetaData.SetDefault(DS.proceeds, "flag", flag);
            }

            //Cassiere predefinito o altro cassiere selezionato 

            object codiceistituto = DBNull.Value;
            DataRow[] IstCassierePredef = DS.treasurer.Select(QHC.CmpEq("flagdefault", "S"));
            if (IstCassierePredef.Length == 1) {
                codiceistituto = IstCassierePredef[0]["idtreasurer"];
            }
            if (DS.treasurer.Select(QHC.CmpNe("idtreasurer", 0)).Length == 1) {
                codiceistituto = DS.treasurer.Select(QHC.CmpNe("idtreasurer", 0))[0]["idtreasurer"];
            }



            object cassiereSelezionato = cmbCodiceIstituto.SelectedValue;
            object cassiereMandatoPrincipale = CurrRow["idtreasurer_main"];

            if (cassiereMandatoPrincipale != DBNull.Value) {
                condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive,
                    QHS.CmpEq("idtreasurer_main", cassiereMandatoPrincipale));
                MetaData.SetDefault(DS.proceeds, "idtreasurer", cassiereMandatoPrincipale);
                //Settare il combo dell'istituto cassiere con il valore selezionato
                HelpForm.SetComboBoxValue(cmbCodiceIstituto, cassiereMandatoPrincipale);
                cmbCodiceIstituto.Enabled = false;
            }
            else {
                condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive,
                    QHS.IsNull("idtreasurer_main"));
                MetaData.SetDefault(DS.proceeds, "idtreasurer", codiceistituto);
                //Settare il combo dell'istituto cassiere con il valore predefinito e abilitarlo
                HelpForm.SetComboBoxValue(cmbCodiceIstituto, codiceistituto);
                cmbCodiceIstituto.Enabled = true;
            }

            //Trattamento bollo predefinito
            DataRow[] TrattBolloPredef = DS.stamphandling.Select(QHC.CmpEq("flagdefault", "S"));
            if (TrattBolloPredef.Length == 1) {
                object codicetrattamento = TrattBolloPredef[0]["idstamphandling"];
                MetaData.SetDefault(DS.proceeds, "idstamphandling", codicetrattamento);
            }


            //Tipo conto (default)
            //MetaData.SetDefault(DS.documentoincasso, "tipoconto", "F");

            //DS.incomelastview.Clear();
            //string dataContabile = txtDataContabile.Text;
            //Meta.EditNew();
            DataRow NewProceeds = Meta.Get_New_Row(null, DS.proceeds);
            return NewProceeds;
            //DateTime scadenza = (DateTime) Meta.GetSys("datacontabile");
            //scadenza = scadenza.AddDays( giornianticipo);

            //string filtro = QHS.AppAnd(QHS.IsNull("kpro"),
            //    QHS.CmpEq("nphase", codicefase),
            //    //QHS.NullOrLe( "expiration", scadenza),
            //    condizioniaggiuntive);


            //if (chkCSA.Checked) filtro = QHS.AppAnd(filtro, QHS.FieldInList("autokind", "20,21,30,31"));


            //// Eseguo la select in una tabella intermedia perchè necessita 
            //// del left outer join con payment,eventuale mandato principale
            //// successivamente il filtro per la run_select in incomelastview sarà 
            //// costruito sulla base delle chiavi

            //string parteSelect = "SELECT " + MainTable + "." + "* ";
            //string parteFrom = " FROM " + MainTable + " ";
            ////parteFrom = parteFrom + " LEFT OUTER JOIN expenselast ON expenselast.idexp = " + MainTable
            ////           + ".idpayment " +
            ////           "LEFT OUTER JOIN payment ON payment.kpay = expenselast.kpay ";
            ////string whereClause = " WHERE "; 
            ////string MyQuery = parteSelect + parteFrom + whereClause + filtro;
            ////DataTable Temp = Meta.Conn.SQLRunner(MyQuery);



            ////string filtroKey = QHS.FieldIn("idinc",Temp.Select(), "idinc");
            //string filtroIncome = filtro;


            //if (Conn.GetSys("idflowchart") != null && Conn.GetSys("idflowchart").ToString() != "") {
            //    string security = Conn.SelectCondition("incomelastview", true);
            //    filtroIncome = QHS.AppAnd(filtroIncome, security);
            //}


            //DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.incomelastview,
            //    "ymov  ASC, nmov  ASC",
            //    filtroIncome,
            //    null, false);

            //MetaData.FreshForm(this, false);
            //if (quiet) {
            //    txtDataContabile.Text = dataContabile;
            //}
            //int max = DS.incomelastview.Rows.Count;
            //for (int i = 0; i < max; i++) {
            //    DetailGrid.Select(i);
            //}
            //CalcolaImporto();

        }

        private void CollegaRigheADocumento(bool quiet) {
            string dataContabile = txtDataContabile.Text;
            while (true) {
                if (TempTable == null || TempTable.Rows.Count == 0) {
                    if (!quiet) MetaFactory.factory.getSingleton<IMessageShower>().Show("Non ci sono movimenti di entrata da elaborare");
                    btnSuccessivo.Enabled = false;
                    grpConferma.Enabled = false;
                    return;
                }

                //MetaData.GetFormData(this,true);
                string MainTable = "incomelastview";
                DataRow rPersEntrata = DS.Tables["config"].Rows[0];
                byte proceeds_flag = (byte) rPersEntrata["proceeds_flag"];
                bool flagcreddeb = (proceeds_flag & 4) == 4;
                bool flagbilancio = (proceeds_flag & 2) == 2;
                bool flagrespons = (proceeds_flag & 16) == 16;
                bool flagresidui = (proceeds_flag & 8) == 8;
                if (chkCrediti.Checked) {
                    flagcreddeb = false;
                    //flagbilancio = false;
                }

                //int giornianticipo = CfgFn.GetNoNullInt32(rPersEntrata["income_expiringdays"]);
                int codicefase = CfgFn.GetNoNullInt32(Meta.GetSys("maxincomephase"));
                int eserccorrente = (int) Meta.GetSys("esercizio");
                //string esercsuffix=eserccorrente.Substring(2,2);
                string condizioniaggiuntive = QHS.CmpEq("ayear", eserccorrente);
                DataRow CurrRow = TempTable.Rows[0];
//			object flageuro= "N";//CurrRow["flageuro"];
//			MetaData.SetDefault(DS.proceeds, "flageuro", flageuro);
//			if (flageuro==DBNull.Value){
//				condizioniaggiuntive+= "AND(flageuro IS null)";
//			}
//			else {
//				condizioniaggiuntive+= "AND(flageuro = '"+flageuro.ToString().ToUpper()+"')";
//			}

                if (flagcreddeb) {
                    object codicecreddeb = CurrRow["idreg"];
                    MetaData.SetDefault(DS.proceeds, "idreg", codicecreddeb);
                    condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive, QHS.CmpEq("idreg", codicecreddeb));
                }

                if (flagbilancio) {
                    object idbilancio = CurrRow["idfin"];
                    MetaData.SetDefault(DS.proceeds, "idfin", idbilancio);
                    if (idbilancio != DBNull.Value) {
                        if (livbilancio == DBNull.Value)
                            condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive, QHS.CmpEq("idfin", idbilancio));
                        else
                            //condizioniaggiuntive+=" AND (idfin LIKE "+
                            //    QueryCreator.quotedstrvalue(idbilancio+"%",true)+")";
                            condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive,
                                QHS.FieldInList("idfin", "select idchild from finlink where "
                                                         + QHS.CmpEq("idparent", idbilancio)));
                        ;
                    }
                    else {
                        condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive, QHS.IsNull("idfin"));
                    }
                }

                if (flagrespons) {
                    object codiceresponsabile = CurrRow["idman"];
                    MetaData.SetDefault(DS.proceeds, "idman", codiceresponsabile);
                    condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive,
                        QHS.CmpEq("idman", codiceresponsabile));
                }

                int flag = 0;
                flag = flag & 0xF8;
                if (flagresidui) {
                    object tipoincasso = CurrRow["kind"];
                    if (tipoincasso.ToString().ToUpper() == "C") {
                        //def. C/Competenza
                        flag = flag + 1;
                        txtTipoDocumento.Text = "Competenza";
                    }

                    if (tipoincasso.ToString().ToUpper() == "R") {
                        //def. C/Residui
                        flag = flag + 2;
                        txtTipoDocumento.Text = "Residui";
                    }

                    MetaData.SetDefault(DS.proceeds, "flag", flag);
                    condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive,
                        QHS.CmpEq(MainTable + "." + "flagarrear", tipoincasso));
                }
                else {
                    //def. Misto
                    flag = flag + 4;
                    txtTipoDocumento.Text = "Misto";
                    MetaData.SetDefault(DS.proceeds, "flag", flag);
                }

                //Cassiere predefinito o altro cassiere selezionato 

                object codiceistituto = DBNull.Value;
                DataRow[] IstCassierePredef = DS.treasurer.Select(QHC.CmpEq("flagdefault", "S"));
                if (IstCassierePredef.Length == 1) {
                    codiceistituto = IstCassierePredef[0]["idtreasurer"];
                }

                if (DS.treasurer.Select(QHC.CmpNe("idtreasurer", 0)).Length == 1) {
                    codiceistituto = DS.treasurer.Select(QHC.CmpNe("idtreasurer", 0))[0]["idtreasurer"];
                }



                object cassiereSelezionato = cmbCodiceIstituto.SelectedValue;
                object cassiereMandatoPrincipale = CurrRow["idtreasurer_main"];

                if (cassiereMandatoPrincipale != DBNull.Value) {
                    condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive,
                        QHS.CmpEq("idtreasurer_main", cassiereMandatoPrincipale));
                    MetaData.SetDefault(DS.proceeds, "idtreasurer", cassiereMandatoPrincipale);
                    //Settare il combo dell'istituto cassiere con il valore selezionato
                    HelpForm.SetComboBoxValue(cmbCodiceIstituto, cassiereMandatoPrincipale);
                    cmbCodiceIstituto.Enabled = false;
                }
                else {
                    condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive,
                        QHS.IsNull("idtreasurer_main"));
                    MetaData.SetDefault(DS.proceeds, "idtreasurer", codiceistituto);
                    //Settare il combo dell'istituto cassiere con il valore predefinito e abilitarlo
                    HelpForm.SetComboBoxValue(cmbCodiceIstituto, codiceistituto);
                    cmbCodiceIstituto.Enabled = true;
                }

                //Trattamento bollo predefinito
                DataRow[] TrattBolloPredef = DS.stamphandling.Select(QHC.CmpEq("flagdefault", "S"));
                if (TrattBolloPredef.Length == 1) {
                    object codicetrattamento = TrattBolloPredef[0]["idstamphandling"];
                    MetaData.SetDefault(DS.proceeds, "idstamphandling", codicetrattamento);
                }


                //Tipo conto (default)
                //MetaData.SetDefault(DS.documentoincasso, "tipoconto", "F");

                DS.incomelastview.Clear();


                //DateTime scadenza = (DateTime) Meta.GetSys("datacontabile");
                //scadenza = scadenza.AddDays( giornianticipo);

                string filtro = QHS.AppAnd(QHS.IsNull("kpro"),
                    QHS.CmpEq("nphase", codicefase),
                    //QHS.NullOrLe( "expiration", scadenza),
                    condizioniaggiuntive);


                if (chkCSA.Checked) filtro = QHS.AppAnd(filtro, QHS.FieldInList("autokind", "20,21,30,31"));

                // Eseguo la select in una tabella intermedia perchè necessita 
                // del left outer join con payment,eventuale mandato principale
                // successivamente il filtro per la run_select in incomelastview sarà 
                // costruito sulla base delle chiavi

                string parteSelect = "SELECT " + MainTable + "." + "* ";
                string parteFrom = " FROM " + MainTable + " ";
                //parteFrom = parteFrom + " LEFT OUTER JOIN expenselast ON expenselast.idexp = " + MainTable
                //           + ".idpayment " +
                //           "LEFT OUTER JOIN payment ON payment.kpay = expenselast.kpay ";
                //string whereClause = " WHERE "; 
                //string MyQuery = parteSelect + parteFrom + whereClause + filtro;
                //DataTable Temp = Meta.Conn.SQLRunner(MyQuery);



                //string filtroKey = QHS.FieldIn("idinc",Temp.Select(), "idinc");
                string filtroIncome = filtro;


                if (Conn.GetSys("idflowchart") != null && Conn.GetSys("idflowchart").ToString() != "") {
                    string security = Conn.SelectCondition("incomelastview", true);
                    filtroIncome = QHS.AppAnd(filtroIncome, security);
                }

                DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.incomelastview,
                    "ymov  ASC, nmov  ASC",
                    filtroIncome,
                    null, false);

                //Se impostato flusso crediti prende solo le righe associate all'elenco "incassiCrediti" e che siano collegate a tipi contratti col flag
                //   non raggruppare per anagrafica in fase di reversale
                if (chkCrediti.Checked && (incassiCrediti != null)) { //&&(incassiCrediti.Count>0)
                    foreach (DataRow r in DS.incomelastview.Rows) {
                        if (!incassiCrediti.ContainsKey(CfgFn.GetNoNullInt32(r["idinc"]))) {
                            r.Delete();
                        }
                    }
                    DS.incomelastview.AcceptChanges();
                }

                if (DS.incomelastview.Rows.Count > 0) break; //continua come prima della modifica dei crediti

                //passa avanti, questo si è rivelato un raggruppamento vuoto, riprova col prossimo
                TempTable.Rows.RemoveAt(0);  
                TempTable.AcceptChanges();
            }

            PostData.MarkAsTemporaryTable(DS.incomelastview,false);
            GetData.DenyClear(DS.incomelastview);
            Meta.EditNew();
            GetData.AllowClear(DS.incomelastview);
            PostData.MarkAsRealTable(DS.incomelastview);

            MetaData.FreshForm(this, false);
            if (quiet) {
                txtDataContabile.Text = dataContabile;
            }
            int max = DS.incomelastview.Rows.Count;
            for (int i = 0; i < max; i++) {
                DetailGrid.Select(i);
            }
            CalcolaImporto();
        }


        private void btnSi_Click(object sender, System.EventArgs e) {
            bool res = AccettaDocumentoConDimensione(false); //<-
            if (res) {
                //selezionaRighe();
                DS.incomelastview.Clear();
                Meta.GetFormData(true);
            }
        }

        /*private void dataGrid1_Click(object sender, System.EventArgs e) {
			CalcolaImporto();
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e) {
			CalcolaImporto();
		}*/

        private void btnSuccessivo_Click(object sender, System.EventArgs e) {

            CollegaRigheADocumento(false);
            btnSuccessivo.Enabled = false;
            grpConferma.Enabled = TempTable.Rows.Count > 0;
            if (TempTable.Rows.Count == 0) Meta.DontWarnOnInsertCancel = true;
        }

        private void btnNo_Click(object sender, System.EventArgs e) {
            if (TempTable.Rows.Count > 0) {
                DS.incomelastview.AcceptChanges();
                TempTable.Rows.RemoveAt(0);
                TempTable.AcceptChanges();
            }
            grpConferma.Enabled = false;
            btnSuccessivo.Enabled = true;
        }

        private void btnInizia_Click(object sender, System.EventArgs e) {
            //R//
            rdbFruttifero.Enabled = true;
            rdbInfruttifero.Enabled = true;
            btnIstitutoCassiere.Enabled = true;
            cmbCodiceIstituto.Enabled = true;
            txtDataContabile.ReadOnly = false;
            //
            FillTempTable();
            CollegaRigheADocumento(false);
            btnInizia.Enabled = false;
            chkCSA.Enabled = false;
            chkCrediti.Enabled = false;
            grpConferma.Enabled = TempTable.Rows.Count > 0;
        }

        DataTable callSp(List<int> idincList) {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("DECLARE @lista AS int_list;");
            int currblockLen = 0;
            foreach(int id in idincList) {
                if (currblockLen == 0) {
                    sb.Append($"insert into @lista values ({id})");
                }
                else {
                    sb.Append($",({id})");
                }

                currblockLen++;
                if (currblockLen == 20) {
                    sb.AppendLine(";");
                    currblockLen = 0;
                }
            }
            if (currblockLen>0) sb.AppendLine(";");
            sb.AppendLine($"exec  trasmele_income_opisiopeplus_ins {Conn.GetEsercizio()},null,'N',@lista");
            return Conn.SQLRunner(sb.ToString(),false,300);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="all">Vale TRUE se è stato premuto il bottone "Si Tutti", altrimenti vale FALSE</param>
        private bool AccettaDocumentoConDimensione(bool all) {
            object spexport = "trasmele_income_opisiopeplus_ins";
            object ypro = Conn.GetSys("esercizio");
            int dimensioneTotale = 0;
            int dimensioneMovCorrente = 0;

            int dimensioneReversaleVuota = 0;
            string Dsingolo = null;
            string DocReversaleVuota = null;
            siopeplus_export SS = new siopeplus_export(Conn);
            var infoVersante = new incassi.reversaleInformazioni_versante();

            bool success = true; 
            int gridrowsnumber = DS.incomelastview.Rows.Count;
            int i;
            DataRow Curr = DS.proceeds.Rows[0];
            int keydocincasso = CfgFn.GetNoNullInt32(Curr["kpro"]);
            object flagautostampa = Meta.Conn.DO_READ_VALUE("config", 
                "(ayear='" + Meta.GetSys("esercizio").ToString() + "')", "proceeds_flagautoprintdate");
            List<DataRow> Lincassi = new List<DataRow>();

            Dictionary<int,DataRow> rowsByIdInc= new Dictionary<int, DataRow>();
            foreach (DataRow r in DS.incomelastview.Rows) rowsByIdInc[(int) r["idinc"]] = r;

            for (i = 0; i < gridrowsnumber; i++) {
                if (DetailGrid.IsSelected(i)) {
                    DataRow CurrEntrata = rowsByIdInc[(int) DetailGrid[i, 0]];
                    Lincassi.Add(CurrEntrata);
                }
            }

            DataTable T = callSp((from r in Lincassi select (int)r["idinc"]).ToList());
            if (T == null || !T.Columns.Contains("kind")) return false;

            DataRow[] MM = T.Select("(kind='REVERSALE')");
            if (MM.Length == 0) {
                return false;
            }
            var reversaleVuota = SS.creaReversale(MM[0]);

            reversaleVuota.dati_a_disposizione_ente_reversale = new incassi.ctDati_a_disposizione_ente_reversale();
            reversaleVuota.dati_a_disposizione_ente_reversale.struttura = MM[0]["dati_codice_struttura"].ToString();
            reversaleVuota.dati_a_disposizione_ente_reversale.codice_struttura = MM[0]["dati_codice_struttura"].ToString();
            reversaleVuota.dati_a_disposizione_ente_reversale.codice_ipa_struttura =MM[0]["dati_codice_ipa_struttura"].ToString();

            DocReversaleVuota = reversaleVuota.toXml(Encoding.GetEncoding("ISO-8859-1"));
            dimensioneReversaleVuota = DocReversaleVuota.Length+50;//include header xml 
            dimensioneTotale = dimensioneReversaleVuota;

            var infoVersanti = SS.get_listaVersanti(T);

            foreach (DataRow CurrEntrata in Lincassi) {
                object idinc = CurrEntrata["idinc"];
                infoVersante = infoVersanti[(int) idinc];

                Dsingolo = infoVersante.toXml(Encoding.GetEncoding("ISO-8859-1"));
                dimensioneMovCorrente = Dsingolo.Length;

                if ((dimensioneTotale + dimensioneMovCorrente > limiteOPIinByte) && UsoSiope) {
                    //Salva l'i-esima reversale
                   // DocReversaleVuota = null;
                    if ((flagautostampa != null) && (flagautostampa.ToString().ToUpper() == "S")) {
                        Curr["printdate"] = Curr["adate"];
                    }
                    //fillProceedsBank();
                    // Crea una nuova riga e legge le righe del raggruppamento corrente in spesaview
					QueryCreator.MarkEvent($"Dimensione calcolata:{dimensioneTotale}");
                    Curr = PredisponiNuovoDocumento();
                    dimensioneTotale = dimensioneReversaleVuota;
                    keydocincasso = CfgFn.GetNoNullInt32(Curr["kpro"]);
                }
                dimensioneTotale = dimensioneTotale + dimensioneMovCorrente;
                CurrEntrata["kpro"] = keydocincasso;
            }
            QueryCreator.MarkEvent($"Ultima dimensione calcolata:{dimensioneTotale}");

            Meta.GetFormData(true);
            // Imposta la data sull'ultima reversale
            if ((flagautostampa != null) && (flagautostampa.ToString().ToUpper() == "S")) {
                Curr["printdate"] = Curr["adate"];
            }
            MetaData.DoMainCommand(this, "mainsave");
            if (all || !DS.HasChanges()) {
                success = true;
                TempTable.Rows.RemoveAt(0);
                TempTable.AcceptChanges();
                fillProceedsBank();
            }
            else {
                success = false;
                return success;
            }
            grpConferma.Enabled = false;
            btnSuccessivo.Enabled = true;
            return success;
        }

        private void fillProceedsBank() {
            foreach (DataRow Curr in DS.proceeds.Select()) {
	            if (Curr.RowState == DataRowState.Added) continue;
                DataSet Out = Meta.Conn.CallSP("compute_proceeds_bank",
                    new object[] { Curr["kpro"] }, false, 0);
            }
        }

        private void selezionaRighe() {
            string dataMember = DetailGrid.DataMember;
            CurrencyManager cm = DetailGrid.BindingContext[DS, dataMember] as CurrencyManager;
            if (cm == null) return;
            DataView view = cm.List as DataView;
            if (view == null) return;

            for (int i = 0; i < view.Count; i++) {
                if (!DetailGrid.IsSelected(i)) {
                    DetailGrid.Select(i);
                }
            }
        }

        private void btnSiTutti_Click(object sender, System.EventArgs e) {
            while (TempTable.Rows.Count > 0) {
                bool esito = AccettaDocumentoConDimensione(true);
                if (!esito) break;
                CollegaRigheADocumento(true);
                //MetaData.FreshForm(this, false);
            }
            grpConferma.Enabled = false;
            Meta.DontWarnOnInsertCancel = true;
            selezionaRighe();
        }

        private void DetailGrid_Paint(object sender, System.Windows.Forms.PaintEventArgs e) {
            if (DetailGrid.DataSource == null) return;
            CalcolaImporto();
        }

        private void chkCSA_CheckedChanged(object sender, EventArgs e) {
            if (chkCSA.Checked) chkCrediti.Checked = false;
        }

        private void chkCrediti_CheckStateChanged(object sender, EventArgs e) {
            if (chkCrediti.Checked) chkCSA.Checked = false;
        }
    }
}
