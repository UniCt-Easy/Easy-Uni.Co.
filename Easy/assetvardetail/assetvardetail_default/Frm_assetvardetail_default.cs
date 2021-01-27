
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;

namespace assetvardetail_default {//dettvarpatrimonio//
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Frm_assetvardetail_default : System.Windows.Forms.Form {
		private System.Windows.Forms.Label labelEsercizio;
		public vistaForm DS;
		private System.Windows.Forms.Label labelNumero;
		private System.Windows.Forms.TextBox textBoxNumeroVariazione;
		private System.Windows.Forms.TextBox textBoxEsercizio;
		private System.Windows.Forms.GroupBox groupBoxDatiVariazione;
		private System.Windows.Forms.Button buttonVariazione;
		private System.Windows.Forms.GroupBox groupBoxTipoVariazione;
		private System.Windows.Forms.RadioButton radioButtonAltraVariazione;
		private System.Windows.Forms.RadioButton radioButtonSituazioneIniziale;
		private System.Windows.Forms.Label labelDescrizione2;
		private System.Windows.Forms.RadioButton radioButtonAumento;
		private System.Windows.Forms.RadioButton radioButtonDiminuzione;
		private System.Windows.Forms.TextBox textBoxImporto;
		private System.Windows.Forms.GroupBox groupBoxImporto;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBoxDescrizioneDettvarpatrimonio;
		private System.Windows.Forms.GroupBox groupBoxClassificazione;
		private System.Windows.Forms.TextBox textBoxClassInventario;
		private System.Windows.Forms.TextBox textBoxCodiceClass;
		private System.Windows.Forms.Button buttonClassificazione;
		private System.Windows.Forms.TextBox textBoxNumProvv;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxDataProvv;
		private System.Windows.Forms.TextBox textBoxDataContabile;
		private System.Windows.Forms.Label labelDataContabile;
		private System.Windows.Forms.Label labelDataProvv;
		private System.Windows.Forms.TextBox textBoxProvvedimento;
		private System.Windows.Forms.TextBox textBoxDescrizioneVariazionepatrimonio;
		private System.Windows.Forms.Label labelDescrizione;
		private System.Windows.Forms.ComboBox comboBoxEnteInventario;
		private System.Windows.Forms.Label labelEnteInventariale;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox grpInventario;
		private System.Windows.Forms.ComboBox comboBox1;
        private GroupBox groupBox2;
        private ComboBox cboCausale;
		private MetaData Meta;

		public Frm_assetvardetail_default() {
			InitializeComponent();
		}

        QueryHelper QHS;
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
            QHS = Meta.Conn.GetQueryHelper();
            //string filteresercvar = QHS.CmpEq("yvar", Meta.GetSys("esercizio"));
            //GetData.SetStaticFilter(DS.assetvardetailview, filteresercvar);
            //GetData.SetStaticFilter(DS.assetvarview,filteresercvar);
		}

        public void MetaData_AfterClear() {
            textBoxEsercizio.Text = Meta.GetSys("esercizio").ToString();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_assetvardetail_default));
            this.labelEsercizio = new System.Windows.Forms.Label();
            this.DS = new assetvardetail_default.vistaForm();
            this.textBoxEsercizio = new System.Windows.Forms.TextBox();
            this.labelNumero = new System.Windows.Forms.Label();
            this.textBoxNumeroVariazione = new System.Windows.Forms.TextBox();
            this.buttonVariazione = new System.Windows.Forms.Button();
            this.labelDescrizione2 = new System.Windows.Forms.Label();
            this.groupBoxDatiVariazione = new System.Windows.Forms.GroupBox();
            this.textBoxDataContabile = new System.Windows.Forms.TextBox();
            this.labelDataContabile = new System.Windows.Forms.Label();
            this.textBoxDescrizioneVariazionepatrimonio = new System.Windows.Forms.TextBox();
            this.labelDescrizione = new System.Windows.Forms.Label();
            this.comboBoxEnteInventario = new System.Windows.Forms.ComboBox();
            this.labelEnteInventariale = new System.Windows.Forms.Label();
            this.groupBoxTipoVariazione = new System.Windows.Forms.GroupBox();
            this.radioButtonAltraVariazione = new System.Windows.Forms.RadioButton();
            this.radioButtonSituazioneIniziale = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxProvvedimento = new System.Windows.Forms.TextBox();
            this.labelDataProvv = new System.Windows.Forms.Label();
            this.textBoxDataProvv = new System.Windows.Forms.TextBox();
            this.textBoxNumProvv = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonAumento = new System.Windows.Forms.RadioButton();
            this.radioButtonDiminuzione = new System.Windows.Forms.RadioButton();
            this.textBoxImporto = new System.Windows.Forms.TextBox();
            this.groupBoxImporto = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDescrizioneDettvarpatrimonio = new System.Windows.Forms.TextBox();
            this.groupBoxClassificazione = new System.Windows.Forms.GroupBox();
            this.textBoxClassInventario = new System.Windows.Forms.TextBox();
            this.textBoxCodiceClass = new System.Windows.Forms.TextBox();
            this.buttonClassificazione = new System.Windows.Forms.Button();
            this.grpInventario = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboCausale = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBoxDatiVariazione.SuspendLayout();
            this.groupBoxTipoVariazione.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxImporto.SuspendLayout();
            this.groupBoxClassificazione.SuspendLayout();
            this.grpInventario.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelEsercizio
            // 
            this.labelEsercizio.Location = new System.Drawing.Point(8, 48);
            this.labelEsercizio.Name = "labelEsercizio";
            this.labelEsercizio.Size = new System.Drawing.Size(56, 23);
            this.labelEsercizio.TabIndex = 1;
            this.labelEsercizio.Text = "Esercizio";
            this.labelEsercizio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DS
            // 
            this.DS.DataSetName = "VistaVariazionePatrimonio";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // textBoxEsercizio
            // 
            this.textBoxEsercizio.Location = new System.Drawing.Point(64, 48);
            this.textBoxEsercizio.Name = "textBoxEsercizio";
            this.textBoxEsercizio.Size = new System.Drawing.Size(56, 20);
            this.textBoxEsercizio.TabIndex = 1;
            this.textBoxEsercizio.TabStop = false;
            this.textBoxEsercizio.Tag = "assetvar.yvar.year?assetvardetailview.yvar";
            // 
            // labelNumero
            // 
            this.labelNumero.Location = new System.Drawing.Point(8, 72);
            this.labelNumero.Name = "labelNumero";
            this.labelNumero.Size = new System.Drawing.Size(48, 23);
            this.labelNumero.TabIndex = 3;
            this.labelNumero.Text = "Numero";
            // 
            // textBoxNumeroVariazione
            // 
            this.textBoxNumeroVariazione.Location = new System.Drawing.Point(64, 72);
            this.textBoxNumeroVariazione.Name = "textBoxNumeroVariazione";
            this.textBoxNumeroVariazione.Size = new System.Drawing.Size(56, 20);
            this.textBoxNumeroVariazione.TabIndex = 1;
            this.textBoxNumeroVariazione.Tag = "assetvar.nvar?assetvardetailview.nvar";
            // 
            // buttonVariazione
            // 
            this.buttonVariazione.Location = new System.Drawing.Point(8, 16);
            this.buttonVariazione.Name = "buttonVariazione";
            this.buttonVariazione.Size = new System.Drawing.Size(75, 23);
            this.buttonVariazione.TabIndex = 0;
            this.buttonVariazione.TabStop = false;
            this.buttonVariazione.Tag = "choose.assetvar.dettaglio";
            this.buttonVariazione.Text = "Variazione";
            // 
            // labelDescrizione2
            // 
            this.labelDescrizione2.Location = new System.Drawing.Point(0, 0);
            this.labelDescrizione2.Name = "labelDescrizione2";
            this.labelDescrizione2.Size = new System.Drawing.Size(100, 23);
            this.labelDescrizione2.TabIndex = 0;
            // 
            // groupBoxDatiVariazione
            // 
            this.groupBoxDatiVariazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDatiVariazione.Controls.Add(this.textBoxDataContabile);
            this.groupBoxDatiVariazione.Controls.Add(this.labelDataContabile);
            this.groupBoxDatiVariazione.Controls.Add(this.textBoxDescrizioneVariazionepatrimonio);
            this.groupBoxDatiVariazione.Controls.Add(this.labelDescrizione);
            this.groupBoxDatiVariazione.Controls.Add(this.comboBoxEnteInventario);
            this.groupBoxDatiVariazione.Controls.Add(this.labelEnteInventariale);
            this.groupBoxDatiVariazione.Controls.Add(this.labelEsercizio);
            this.groupBoxDatiVariazione.Controls.Add(this.buttonVariazione);
            this.groupBoxDatiVariazione.Controls.Add(this.textBoxEsercizio);
            this.groupBoxDatiVariazione.Controls.Add(this.labelNumero);
            this.groupBoxDatiVariazione.Controls.Add(this.textBoxNumeroVariazione);
            this.groupBoxDatiVariazione.Controls.Add(this.groupBoxTipoVariazione);
            this.groupBoxDatiVariazione.Controls.Add(this.groupBox1);
            this.groupBoxDatiVariazione.Location = new System.Drawing.Point(8, 8);
            this.groupBoxDatiVariazione.Name = "groupBoxDatiVariazione";
            this.groupBoxDatiVariazione.Size = new System.Drawing.Size(496, 208);
            this.groupBoxDatiVariazione.TabIndex = 0;
            this.groupBoxDatiVariazione.TabStop = false;
            this.groupBoxDatiVariazione.Tag = "AutoChoose.textBoxNumeroVariazione.default";
            this.groupBoxDatiVariazione.Text = "Dati variazione";
            // 
            // textBoxDataContabile
            // 
            this.textBoxDataContabile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDataContabile.Location = new System.Drawing.Point(424, 184);
            this.textBoxDataContabile.Name = "textBoxDataContabile";
            this.textBoxDataContabile.ReadOnly = true;
            this.textBoxDataContabile.Size = new System.Drawing.Size(64, 20);
            this.textBoxDataContabile.TabIndex = 9;
            this.textBoxDataContabile.TabStop = false;
            this.textBoxDataContabile.Tag = "assetvar.adate";
            // 
            // labelDataContabile
            // 
            this.labelDataContabile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDataContabile.Location = new System.Drawing.Point(336, 184);
            this.labelDataContabile.Name = "labelDataContabile";
            this.labelDataContabile.Size = new System.Drawing.Size(80, 16);
            this.labelDataContabile.TabIndex = 28;
            this.labelDataContabile.Text = "Data contabile";
            this.labelDataContabile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxDescrizioneVariazionepatrimonio
            // 
            this.textBoxDescrizioneVariazionepatrimonio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDescrizioneVariazionepatrimonio.Location = new System.Drawing.Point(232, 42);
            this.textBoxDescrizioneVariazionepatrimonio.Multiline = true;
            this.textBoxDescrizioneVariazionepatrimonio.Name = "textBoxDescrizioneVariazionepatrimonio";
            this.textBoxDescrizioneVariazionepatrimonio.ReadOnly = true;
            this.textBoxDescrizioneVariazionepatrimonio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDescrizioneVariazionepatrimonio.Size = new System.Drawing.Size(248, 48);
            this.textBoxDescrizioneVariazionepatrimonio.TabIndex = 5;
            this.textBoxDescrizioneVariazionepatrimonio.TabStop = false;
            this.textBoxDescrizioneVariazionepatrimonio.Tag = "assetvar.description";
            // 
            // labelDescrizione
            // 
            this.labelDescrizione.Location = new System.Drawing.Point(152, 42);
            this.labelDescrizione.Name = "labelDescrizione";
            this.labelDescrizione.Size = new System.Drawing.Size(72, 23);
            this.labelDescrizione.TabIndex = 20;
            this.labelDescrizione.Text = "Descrizione";
            this.labelDescrizione.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboBoxEnteInventario
            // 
            this.comboBoxEnteInventario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxEnteInventario.DataSource = this.DS.inventoryagency;
            this.comboBoxEnteInventario.DisplayMember = "description";
            this.comboBoxEnteInventario.Enabled = false;
            this.comboBoxEnteInventario.Location = new System.Drawing.Point(232, 10);
            this.comboBoxEnteInventario.Name = "comboBoxEnteInventario";
            this.comboBoxEnteInventario.Size = new System.Drawing.Size(248, 21);
            this.comboBoxEnteInventario.TabIndex = 2;
            this.comboBoxEnteInventario.Tag = "assetvar.idinventoryagency.(active=\'S\')";
            this.comboBoxEnteInventario.ValueMember = "idinventoryagency";
            // 
            // labelEnteInventariale
            // 
            this.labelEnteInventariale.Location = new System.Drawing.Point(152, 12);
            this.labelEnteInventariale.Name = "labelEnteInventariale";
            this.labelEnteInventariale.Size = new System.Drawing.Size(72, 17);
            this.labelEnteInventariale.TabIndex = 18;
            this.labelEnteInventariale.Text = "Ente";
            this.labelEnteInventariale.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBoxTipoVariazione
            // 
            this.groupBoxTipoVariazione.Controls.Add(this.radioButtonAltraVariazione);
            this.groupBoxTipoVariazione.Controls.Add(this.radioButtonSituazioneIniziale);
            this.groupBoxTipoVariazione.Location = new System.Drawing.Point(8, 96);
            this.groupBoxTipoVariazione.Name = "groupBoxTipoVariazione";
            this.groupBoxTipoVariazione.Size = new System.Drawing.Size(128, 80);
            this.groupBoxTipoVariazione.TabIndex = 3;
            this.groupBoxTipoVariazione.TabStop = false;
            this.groupBoxTipoVariazione.Text = "Tipo";
            // 
            // radioButtonAltraVariazione
            // 
            this.radioButtonAltraVariazione.Enabled = false;
            this.radioButtonAltraVariazione.Location = new System.Drawing.Point(8, 48);
            this.radioButtonAltraVariazione.Name = "radioButtonAltraVariazione";
            this.radioButtonAltraVariazione.Size = new System.Drawing.Size(104, 24);
            this.radioButtonAltraVariazione.TabIndex = 1;
            this.radioButtonAltraVariazione.Tag = "assetvar.flag::0?dettvariazionepatrimonioview.variationkind:N";
            this.radioButtonAltraVariazione.Text = "Altra variazione";
            // 
            // radioButtonSituazioneIniziale
            // 
            this.radioButtonSituazioneIniziale.Enabled = false;
            this.radioButtonSituazioneIniziale.Location = new System.Drawing.Point(8, 16);
            this.radioButtonSituazioneIniziale.Name = "radioButtonSituazioneIniziale";
            this.radioButtonSituazioneIniziale.Size = new System.Drawing.Size(113, 24);
            this.radioButtonSituazioneIniziale.TabIndex = 0;
            this.radioButtonSituazioneIniziale.Tag = "assetvar.flag::#0?assetvardetailview.variationkind:I";
            this.radioButtonSituazioneIniziale.Text = "Situazione iniziale";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxProvvedimento);
            this.groupBox1.Controls.Add(this.labelDataProvv);
            this.groupBox1.Controls.Add(this.textBoxDataProvv);
            this.groupBox1.Controls.Add(this.textBoxNumProvv);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(136, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 80);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Provvedimento";
            // 
            // textBoxProvvedimento
            // 
            this.textBoxProvvedimento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxProvvedimento.Location = new System.Drawing.Point(16, 24);
            this.textBoxProvvedimento.Name = "textBoxProvvedimento";
            this.textBoxProvvedimento.ReadOnly = true;
            this.textBoxProvvedimento.Size = new System.Drawing.Size(328, 20);
            this.textBoxProvvedimento.TabIndex = 6;
            this.textBoxProvvedimento.TabStop = false;
            this.textBoxProvvedimento.Tag = "assetvar.enactment";
            // 
            // labelDataProvv
            // 
            this.labelDataProvv.Location = new System.Drawing.Point(16, 48);
            this.labelDataProvv.Name = "labelDataProvv";
            this.labelDataProvv.Size = new System.Drawing.Size(32, 17);
            this.labelDataProvv.TabIndex = 24;
            this.labelDataProvv.Text = "Data:";
            this.labelDataProvv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxDataProvv
            // 
            this.textBoxDataProvv.Location = new System.Drawing.Point(64, 48);
            this.textBoxDataProvv.Name = "textBoxDataProvv";
            this.textBoxDataProvv.ReadOnly = true;
            this.textBoxDataProvv.Size = new System.Drawing.Size(64, 20);
            this.textBoxDataProvv.TabIndex = 7;
            this.textBoxDataProvv.TabStop = false;
            this.textBoxDataProvv.Tag = "assetvar.enactmentdate";
            // 
            // textBoxNumProvv
            // 
            this.textBoxNumProvv.Location = new System.Drawing.Point(208, 48);
            this.textBoxNumProvv.Name = "textBoxNumProvv";
            this.textBoxNumProvv.ReadOnly = true;
            this.textBoxNumProvv.Size = new System.Drawing.Size(80, 20);
            this.textBoxNumProvv.TabIndex = 8;
            this.textBoxNumProvv.TabStop = false;
            this.textBoxNumProvv.Tag = "assetvar.nenactment";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(144, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 26;
            this.label1.Text = "Numero:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // radioButtonAumento
            // 
            this.radioButtonAumento.Checked = true;
            this.radioButtonAumento.Location = new System.Drawing.Point(128, 16);
            this.radioButtonAumento.Name = "radioButtonAumento";
            this.radioButtonAumento.Size = new System.Drawing.Size(72, 24);
            this.radioButtonAumento.TabIndex = 1;
            this.radioButtonAumento.TabStop = true;
            this.radioButtonAumento.Tag = "+";
            this.radioButtonAumento.Text = "Aumento";
            // 
            // radioButtonDiminuzione
            // 
            this.radioButtonDiminuzione.Location = new System.Drawing.Point(128, 40);
            this.radioButtonDiminuzione.Name = "radioButtonDiminuzione";
            this.radioButtonDiminuzione.Size = new System.Drawing.Size(86, 24);
            this.radioButtonDiminuzione.TabIndex = 2;
            this.radioButtonDiminuzione.Tag = "-";
            this.radioButtonDiminuzione.Text = "Diminuzione";
            // 
            // textBoxImporto
            // 
            this.textBoxImporto.Location = new System.Drawing.Point(16, 32);
            this.textBoxImporto.Name = "textBoxImporto";
            this.textBoxImporto.Size = new System.Drawing.Size(88, 20);
            this.textBoxImporto.TabIndex = 0;
            this.textBoxImporto.Tag = "assetvardetail.amount";
            // 
            // groupBoxImporto
            // 
            this.groupBoxImporto.Controls.Add(this.radioButtonAumento);
            this.groupBoxImporto.Controls.Add(this.radioButtonDiminuzione);
            this.groupBoxImporto.Controls.Add(this.textBoxImporto);
            this.groupBoxImporto.Location = new System.Drawing.Point(272, 404);
            this.groupBoxImporto.Name = "groupBoxImporto";
            this.groupBoxImporto.Size = new System.Drawing.Size(232, 72);
            this.groupBoxImporto.TabIndex = 4;
            this.groupBoxImporto.TabStop = false;
            this.groupBoxImporto.Tag = "assetvardetail.amount.valuesigned";
            this.groupBoxImporto.Text = "Importo";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 404);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "Descrizione";
            // 
            // textBoxDescrizioneDettvarpatrimonio
            // 
            this.textBoxDescrizioneDettvarpatrimonio.Location = new System.Drawing.Point(16, 420);
            this.textBoxDescrizioneDettvarpatrimonio.Multiline = true;
            this.textBoxDescrizioneDettvarpatrimonio.Name = "textBoxDescrizioneDettvarpatrimonio";
            this.textBoxDescrizioneDettvarpatrimonio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDescrizioneDettvarpatrimonio.Size = new System.Drawing.Size(248, 56);
            this.textBoxDescrizioneDettvarpatrimonio.TabIndex = 3;
            this.textBoxDescrizioneDettvarpatrimonio.Tag = "assetvardetail.description";
            // 
            // groupBoxClassificazione
            // 
            this.groupBoxClassificazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxClassificazione.Controls.Add(this.textBoxClassInventario);
            this.groupBoxClassificazione.Controls.Add(this.textBoxCodiceClass);
            this.groupBoxClassificazione.Controls.Add(this.buttonClassificazione);
            this.groupBoxClassificazione.Location = new System.Drawing.Point(8, 316);
            this.groupBoxClassificazione.Name = "groupBoxClassificazione";
            this.groupBoxClassificazione.Size = new System.Drawing.Size(496, 80);
            this.groupBoxClassificazione.TabIndex = 2;
            this.groupBoxClassificazione.TabStop = false;
            this.groupBoxClassificazione.Tag = "AutoManage.textBoxCodiceClass.tree";
            this.groupBoxClassificazione.Text = "Classificazione";
            // 
            // textBoxClassInventario
            // 
            this.textBoxClassInventario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxClassInventario.Location = new System.Drawing.Point(136, 16);
            this.textBoxClassInventario.Multiline = true;
            this.textBoxClassInventario.Name = "textBoxClassInventario";
            this.textBoxClassInventario.ReadOnly = true;
            this.textBoxClassInventario.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxClassInventario.Size = new System.Drawing.Size(344, 56);
            this.textBoxClassInventario.TabIndex = 2;
            this.textBoxClassInventario.TabStop = false;
            this.textBoxClassInventario.Tag = "inventorytreeview.description";
            // 
            // textBoxCodiceClass
            // 
            this.textBoxCodiceClass.Location = new System.Drawing.Point(8, 48);
            this.textBoxCodiceClass.Name = "textBoxCodiceClass";
            this.textBoxCodiceClass.Size = new System.Drawing.Size(120, 20);
            this.textBoxCodiceClass.TabIndex = 1;
            this.textBoxCodiceClass.Tag = "inventorytreeview.codeinv?assetvardetailview.sortcode";
            // 
            // buttonClassificazione
            // 
            this.buttonClassificazione.Image = ((System.Drawing.Image)(resources.GetObject("buttonClassificazione.Image")));
            this.buttonClassificazione.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonClassificazione.Location = new System.Drawing.Point(8, 16);
            this.buttonClassificazione.Name = "buttonClassificazione";
            this.buttonClassificazione.Size = new System.Drawing.Size(120, 23);
            this.buttonClassificazione.TabIndex = 0;
            this.buttonClassificazione.TabStop = false;
            this.buttonClassificazione.Tag = "manage.inventorytreeview.tree";
            this.buttonClassificazione.Text = "Classificazione";
            // 
            // grpInventario
            // 
            this.grpInventario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpInventario.Controls.Add(this.comboBox1);
            this.grpInventario.Location = new System.Drawing.Point(8, 216);
            this.grpInventario.Name = "grpInventario";
            this.grpInventario.Size = new System.Drawing.Size(496, 48);
            this.grpInventario.TabIndex = 1;
            this.grpInventario.TabStop = false;
            this.grpInventario.Text = "Inventario";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DataSource = this.DS.inventory;
            this.comboBox1.DisplayMember = "description";
            this.comboBox1.Location = new System.Drawing.Point(8, 16);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(480, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Tag = "assetvardetail.idinventory.(active=\'S\')";
            this.comboBox1.ValueMember = "idinventory";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboCausale);
            this.groupBox2.Location = new System.Drawing.Point(8, 268);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(294, 40);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Causale di Carico";
            // 
            // cboCausale
            // 
            this.cboCausale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCausale.DataSource = this.DS.assetloadmotive;
            this.cboCausale.DisplayMember = "description";
            this.cboCausale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCausale.Location = new System.Drawing.Point(8, 16);
            this.cboCausale.Name = "cboCausale";
            this.cboCausale.Size = new System.Drawing.Size(278, 21);
            this.cboCausale.TabIndex = 14;
            this.cboCausale.Tag = "assetvardetail.idmot";
            this.cboCausale.ValueMember = "idmot";
            // 
            // Frm_assetvardetail_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(520, 506);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpInventario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxDescrizioneDettvarpatrimonio);
            this.Controls.Add(this.groupBoxClassificazione);
            this.Controls.Add(this.groupBoxDatiVariazione);
            this.Controls.Add(this.groupBoxImporto);
            this.Name = "Frm_assetvardetail_default";
            this.Text = "Dettaglio variazione patrimoniale";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBoxDatiVariazione.ResumeLayout(false);
            this.groupBoxDatiVariazione.PerformLayout();
            this.groupBoxTipoVariazione.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxImporto.ResumeLayout(false);
            this.groupBoxImporto.PerformLayout();
            this.groupBoxClassificazione.ResumeLayout(false);
            this.groupBoxClassificazione.PerformLayout();
            this.grpInventario.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
	}
}
