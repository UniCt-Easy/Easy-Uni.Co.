
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
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;//funzioni_configurazione


namespace proceeds_default{//documentoincasso//
	/// <summary>
	/// Summary description for frmdocumentoincasso.
	/// Revised By Nino on 26/1/2003
	/// Revised By Nino on 7/2/2003 (errori in ricerca movimenti)
	/// Revised By Nino on 20/2/2003 (importo->importocorrente)
	/// Revised By Nino on 27/2/2003 (Insert->Edit->Insert invece di Insert->Insert)
	/// </summary>
	public class Frm_proceeds_default : MetaDataForm {
        QueryHelper QHS;
        CQueryHelper QHC;
        private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtResponsabile;
		private System.Windows.Forms.TextBox txtDescrBilancio;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtBilancio;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtCreditoreDebitore;
		private System.Windows.Forms.ComboBox cmbCodiceIstituto;
		private System.Windows.Forms.Button btnIstitutoCassiere;
		private System.Windows.Forms.Button btnScollega;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtNumeroRiga;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtEsercizioRiga;
		private System.Windows.Forms.Button btnRigaMandato;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtNumeroDocumento;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtEsercizioDocumento;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.RadioButton rdbFruttifero;
		private System.Windows.Forms.RadioButton rdbInfruttifero;
		private System.ComponentModel.IContainer components;
		MetaData Meta;
		bool flagcreddeb;
		bool flagbilancio;
		bool flagrespons;
		public vistaForm DS;
        private System.Windows.Forms.GroupBox gboxRigaMandato;
		private System.Windows.Forms.TextBox txtTipoIncasso;
		bool flagresidui;
		bool CanGoInsert;
		string comandochoose;
		private System.Windows.Forms.TextBox txtImporto;
		public System.Windows.Forms.ToolBar MetaDataToolBar;
		private System.Windows.Forms.ToolBarButton inserisci;
		private System.Windows.Forms.ToolBarButton elimina;
		private System.Windows.Forms.ToolBarButton Salva;
		private System.Windows.Forms.ToolBarButton aggiorna;
		private System.Windows.Forms.ToolBarButton btnEditNotes;
		private System.Windows.Forms.ImageList images;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.GroupBox groupBox3;
        private Button btnBollo;
        private ComboBox cmbBollo;
        private Label label10;
        private TextBox textBox1;
		bool InChiusura;


		public Frm_proceeds_default()
		{
			InitializeComponent();		
			CanGoInsert=true;
			InChiusura=false;
			QueryCreator.SetTableForPosting(DS.incomelastview, "incomelast");
			QueryCreator.SetTableForPosting(DS.proceeds_bankview, "proceeds_bank");
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			InChiusura=true;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_proceeds_default));
            this.label9 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtResponsabile = new System.Windows.Forms.TextBox();
            this.txtDescrBilancio = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtBilancio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCreditoreDebitore = new System.Windows.Forms.TextBox();
            this.cmbCodiceIstituto = new System.Windows.Forms.ComboBox();
            this.DS = new proceeds_default.vistaForm();
            this.btnIstitutoCassiere = new System.Windows.Forms.Button();
            this.gboxRigaMandato = new System.Windows.Forms.GroupBox();
            this.btnScollega = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumeroRiga = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEsercizioRiga = new System.Windows.Forms.TextBox();
            this.btnRigaMandato = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumeroDocumento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEsercizioDocumento = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTipoIncasso = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdbFruttifero = new System.Windows.Forms.RadioButton();
            this.rdbInfruttifero = new System.Windows.Forms.RadioButton();
            this.MetaDataToolBar = new System.Windows.Forms.ToolBar();
            this.inserisci = new System.Windows.Forms.ToolBarButton();
            this.elimina = new System.Windows.Forms.ToolBarButton();
            this.Salva = new System.Windows.Forms.ToolBarButton();
            this.aggiorna = new System.Windows.Forms.ToolBarButton();
            this.btnEditNotes = new System.Windows.Forms.ToolBarButton();
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnBollo = new System.Windows.Forms.Button();
            this.cmbBollo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.gboxRigaMandato.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(224, 252);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 16);
            this.label9.TabIndex = 44;
            this.label9.Text = "Data contabile:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(232, 276);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(96, 20);
            this.textBox5.TabIndex = 2;
            this.textBox5.Tag = "proceeds.adate";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 252);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 16);
            this.label8.TabIndex = 42;
            this.label8.Text = "Importo:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtImporto
            // 
            this.txtImporto.Location = new System.Drawing.Point(8, 276);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.ReadOnly = true;
            this.txtImporto.Size = new System.Drawing.Size(96, 20);
            this.txtImporto.TabIndex = 41;
            this.txtImporto.TabStop = false;
            this.txtImporto.Tag = "";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 204);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 40;
            this.label7.Text = "Responsabile:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtResponsabile
            // 
            this.txtResponsabile.Location = new System.Drawing.Point(8, 228);
            this.txtResponsabile.Name = "txtResponsabile";
            this.txtResponsabile.ReadOnly = true;
            this.txtResponsabile.Size = new System.Drawing.Size(320, 20);
            this.txtResponsabile.TabIndex = 39;
            this.txtResponsabile.TabStop = false;
            this.txtResponsabile.Tag = "";
            // 
            // txtDescrBilancio
            // 
            this.txtDescrBilancio.Location = new System.Drawing.Point(112, 156);
            this.txtDescrBilancio.Multiline = true;
            this.txtDescrBilancio.Name = "txtDescrBilancio";
            this.txtDescrBilancio.ReadOnly = true;
            this.txtDescrBilancio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrBilancio.Size = new System.Drawing.Size(216, 48);
            this.txtDescrBilancio.TabIndex = 38;
            this.txtDescrBilancio.TabStop = false;
            this.txtDescrBilancio.Tag = "";
            // 
            // label6
            // 
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.ImageIndex = 0;
            this.label6.ImageList = this.imageList1;
            this.label6.Location = new System.Drawing.Point(8, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 37;
            this.label6.Text = "Bilancio:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // txtBilancio
            // 
            this.txtBilancio.Location = new System.Drawing.Point(8, 180);
            this.txtBilancio.Name = "txtBilancio";
            this.txtBilancio.ReadOnly = true;
            this.txtBilancio.Size = new System.Drawing.Size(96, 20);
            this.txtBilancio.TabIndex = 36;
            this.txtBilancio.TabStop = false;
            this.txtBilancio.Tag = "";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 35;
            this.label5.Text = "Versante:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCreditoreDebitore
            // 
            this.txtCreditoreDebitore.Location = new System.Drawing.Point(8, 132);
            this.txtCreditoreDebitore.Name = "txtCreditoreDebitore";
            this.txtCreditoreDebitore.ReadOnly = true;
            this.txtCreditoreDebitore.Size = new System.Drawing.Size(320, 20);
            this.txtCreditoreDebitore.TabIndex = 34;
            this.txtCreditoreDebitore.TabStop = false;
            this.txtCreditoreDebitore.Tag = "";
            // 
            // cmbCodiceIstituto
            // 
            this.cmbCodiceIstituto.DataSource = this.DS.treasurer;
            this.cmbCodiceIstituto.DisplayMember = "description";
            this.cmbCodiceIstituto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCodiceIstituto.Location = new System.Drawing.Point(96, 16);
            this.cmbCodiceIstituto.Name = "cmbCodiceIstituto";
            this.cmbCodiceIstituto.Size = new System.Drawing.Size(232, 21);
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
            this.btnIstitutoCassiere.Size = new System.Drawing.Size(80, 24);
            this.btnIstitutoCassiere.TabIndex = 29;
            this.btnIstitutoCassiere.TabStop = false;
            this.btnIstitutoCassiere.Tag = "choose.treasurer.lista.(active=\'S\')";
            this.btnIstitutoCassiere.Text = "Cassiere:";
            this.btnIstitutoCassiere.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gboxRigaMandato
            // 
            this.gboxRigaMandato.Controls.Add(this.btnScollega);
            this.gboxRigaMandato.Controls.Add(this.label3);
            this.gboxRigaMandato.Controls.Add(this.txtNumeroRiga);
            this.gboxRigaMandato.Controls.Add(this.label4);
            this.gboxRigaMandato.Controls.Add(this.txtEsercizioRiga);
            this.gboxRigaMandato.Controls.Add(this.btnRigaMandato);
            this.gboxRigaMandato.Location = new System.Drawing.Point(8, 146);
            this.gboxRigaMandato.Name = "gboxRigaMandato";
            this.gboxRigaMandato.Size = new System.Drawing.Size(336, 88);
            this.gboxRigaMandato.TabIndex = 4;
            this.gboxRigaMandato.TabStop = false;
            this.gboxRigaMandato.Text = "Riga reversale";
            // 
            // btnScollega
            // 
            this.btnScollega.Location = new System.Drawing.Point(48, 56);
            this.btnScollega.Name = "btnScollega";
            this.btnScollega.Size = new System.Drawing.Size(104, 24);
            this.btnScollega.TabIndex = 8;
            this.btnScollega.TabStop = false;
            this.btnScollega.Tag = "";
            this.btnScollega.Text = "Rimuovi riga";
            this.btnScollega.Click += new System.EventHandler(this.btnScollega_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(168, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Numero:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumeroRiga
            // 
            this.txtNumeroRiga.Location = new System.Drawing.Point(232, 56);
            this.txtNumeroRiga.Name = "txtNumeroRiga";
            this.txtNumeroRiga.Size = new System.Drawing.Size(72, 20);
            this.txtNumeroRiga.TabIndex = 1;
            this.txtNumeroRiga.Tag = "incomelastview.nmov?x";
            this.txtNumeroRiga.Leave += new System.EventHandler(this.txtNumeroRiga_Leave);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(168, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Esercizio:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercizioRiga
            // 
            this.txtEsercizioRiga.Location = new System.Drawing.Point(232, 24);
            this.txtEsercizioRiga.Name = "txtEsercizioRiga";
            this.txtEsercizioRiga.ReadOnly = true;
            this.txtEsercizioRiga.Size = new System.Drawing.Size(56, 20);
            this.txtEsercizioRiga.TabIndex = 0;
            this.txtEsercizioRiga.TabStop = false;
            this.txtEsercizioRiga.Tag = "incomelastview.ymov?x";
            // 
            // btnRigaMandato
            // 
            this.btnRigaMandato.Location = new System.Drawing.Point(48, 20);
            this.btnRigaMandato.Name = "btnRigaMandato";
            this.btnRigaMandato.Size = new System.Drawing.Size(104, 24);
            this.btnRigaMandato.TabIndex = 6;
            this.btnRigaMandato.TabStop = false;
            this.btnRigaMandato.Tag = "";
            this.btnRigaMandato.Text = "Riga reversale:";
            this.btnRigaMandato.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNumeroDocumento);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtEsercizioDocumento);
            this.groupBox1.Location = new System.Drawing.Point(8, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(152, 80);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Documento";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Numero:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Location = new System.Drawing.Point(72, 56);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.ReadOnly = true;
            this.txtNumeroDocumento.Size = new System.Drawing.Size(72, 20);
            this.txtNumeroDocumento.TabIndex = 2;
            this.txtNumeroDocumento.TabStop = false;
            this.txtNumeroDocumento.Tag = "proceeds.npro";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Esercizio:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercizioDocumento
            // 
            this.txtEsercizioDocumento.Location = new System.Drawing.Point(72, 16);
            this.txtEsercizioDocumento.Name = "txtEsercizioDocumento";
            this.txtEsercizioDocumento.ReadOnly = true;
            this.txtEsercizioDocumento.Size = new System.Drawing.Size(56, 20);
            this.txtEsercizioDocumento.TabIndex = 0;
            this.txtEsercizioDocumento.TabStop = false;
            this.txtEsercizioDocumento.Tag = "proceeds.ypro";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTipoIncasso);
            this.groupBox2.Location = new System.Drawing.Point(168, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(176, 40);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo";
            // 
            // txtTipoIncasso
            // 
            this.txtTipoIncasso.Location = new System.Drawing.Point(8, 16);
            this.txtTipoIncasso.Name = "txtTipoIncasso";
            this.txtTipoIncasso.ReadOnly = true;
            this.txtTipoIncasso.Size = new System.Drawing.Size(112, 20);
            this.txtTipoIncasso.TabIndex = 2;
            this.txtTipoIncasso.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rdbFruttifero);
            this.groupBox4.Controls.Add(this.rdbInfruttifero);
            this.groupBox4.Location = new System.Drawing.Point(168, 104);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(176, 40);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Conto";
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
            // rdbInfruttifero
            // 
            this.rdbInfruttifero.Location = new System.Drawing.Point(88, 16);
            this.rdbInfruttifero.Name = "rdbInfruttifero";
            this.rdbInfruttifero.Size = new System.Drawing.Size(80, 16);
            this.rdbInfruttifero.TabIndex = 1;
            this.rdbInfruttifero.Tag = "proceeds.flag::#3";
            this.rdbInfruttifero.Text = "Infruttifero";
            // 
            // MetaDataToolBar
            // 
            this.MetaDataToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.MetaDataToolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.inserisci,
            this.elimina,
            this.Salva,
            this.aggiorna,
            this.btnEditNotes});
            this.MetaDataToolBar.ButtonSize = new System.Drawing.Size(32, 32);
            this.MetaDataToolBar.DropDownArrows = true;
            this.MetaDataToolBar.ImageList = this.images;
            this.MetaDataToolBar.Location = new System.Drawing.Point(0, 0);
            this.MetaDataToolBar.Name = "MetaDataToolBar";
            this.MetaDataToolBar.ShowToolTips = true;
            this.MetaDataToolBar.Size = new System.Drawing.Size(346, 58);
            this.MetaDataToolBar.TabIndex = 47;
            this.MetaDataToolBar.Tag = "";
            // 
            // inserisci
            // 
            this.inserisci.ImageIndex = 0;
            this.inserisci.Name = "inserisci";
            this.inserisci.Tag = "maininsert";
            this.inserisci.Text = "Inserisci";
            this.inserisci.ToolTipText = "Inserisci un nuovo elemento";
            // 
            // elimina
            // 
            this.elimina.ImageIndex = 2;
            this.elimina.Name = "elimina";
            this.elimina.Tag = "maindelete";
            this.elimina.Text = "Elimina";
            this.elimina.ToolTipText = "Elimina l\'elemento selezionato";
            // 
            // Salva
            // 
            this.Salva.ImageIndex = 1;
            this.Salva.Name = "Salva";
            this.Salva.Tag = "mainsave";
            this.Salva.Text = "Salva";
            this.Salva.ToolTipText = "Salva le modifiche effettuate";
            // 
            // aggiorna
            // 
            this.aggiorna.ImageIndex = 4;
            this.aggiorna.Name = "aggiorna";
            this.aggiorna.Tag = "mainrefresh";
            this.aggiorna.Text = "Aggiorna";
            // 
            // btnEditNotes
            // 
            this.btnEditNotes.ImageIndex = 5;
            this.btnEditNotes.Name = "btnEditNotes";
            this.btnEditNotes.Tag = "editnotes";
            this.btnEditNotes.Text = "Appunti";
            this.btnEditNotes.ToolTipText = "Modifica gli appunti associati all\'oggetto selezionato";
            // 
            // images
            // 
            this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
            this.images.TransparentColor = System.Drawing.Color.Transparent;
            this.images.Images.SetKeyName(0, "");
            this.images.Images.SetKeyName(1, "");
            this.images.Images.SetKeyName(2, "");
            this.images.Images.SetKeyName(3, "");
            this.images.Images.SetKeyName(4, "");
            this.images.Images.SetKeyName(5, "");
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.btnBollo);
            this.groupBox3.Controls.Add(this.cmbBollo);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtCreditoreDebitore);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtBilancio);
            this.groupBox3.Controls.Add(this.txtDescrBilancio);
            this.groupBox3.Controls.Add(this.txtResponsabile);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtImporto);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.textBox5);
            this.groupBox3.Controls.Add(this.btnIstitutoCassiere);
            this.groupBox3.Controls.Add(this.cmbCodiceIstituto);
            this.groupBox3.Location = new System.Drawing.Point(8, 240);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(336, 309);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dati riepilogativi";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(140, 79);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 32);
            this.label10.TabIndex = 51;
            this.label10.Text = "Numero Progr. Cassiere:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(254, 88);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(72, 20);
            this.textBox1.TabIndex = 50;
            this.textBox1.TabStop = false;
            this.textBox1.Tag = "proceeds.npro_treasurer";
            // 
            // btnBollo
            // 
            this.btnBollo.Location = new System.Drawing.Point(8, 46);
            this.btnBollo.Name = "btnBollo";
            this.btnBollo.Size = new System.Drawing.Size(80, 24);
            this.btnBollo.TabIndex = 46;
            this.btnBollo.TabStop = false;
            this.btnBollo.Tag = "manage.stamphandling.lista";
            this.btnBollo.Text = "Bollo:";
            this.btnBollo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbBollo
            // 
            this.cmbBollo.DataSource = this.DS.stamphandling;
            this.cmbBollo.DisplayMember = "description";
            this.cmbBollo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBollo.Location = new System.Drawing.Point(96, 46);
            this.cmbBollo.Name = "cmbBollo";
            this.cmbBollo.Size = new System.Drawing.Size(232, 21);
            this.cmbBollo.TabIndex = 45;
            this.cmbBollo.Tag = "proceeds.idstamphandling";
            this.cmbBollo.ValueMember = "idstamphandling";
            // 
            // Frm_proceeds_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(346, 557);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.gboxRigaMandato);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.MetaDataToolBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Frm_proceeds_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmdocumentoincasso";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.gboxRigaMandato.ResumeLayout(false);
            this.gboxRigaMandato.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		public void MetaData_AfterClear(){
			DS.incomelastview.Clear();
			FillDettagliMovSpesa();
			txtNumeroDocumento.Text="";
            btnIstitutoCassiere.Enabled = true;
            cmbCodiceIstituto.Enabled = true;
			if (!CanGoInsert)return;
			CanGoInsert=false;
			MetaData.MainAdd(this);
		}

		DataRow GetLinkedRow(){
			if (Meta.IsEmpty) return null;
			if (DS.proceeds.Rows.Count==0) return null;
			DataRow CurrRow = DS.proceeds.Rows[0];
			foreach (DataRow MyRow in DS.incomelastview.Rows){
				if (MyRow.RowState== DataRowState.Deleted) continue;
                if (MyRow["kpro"].Equals(CurrRow["kpro"])){
                    return MyRow;
				}
			}
			return null;
		}

		void ScollegaRiga(){
			DataRow linked= GetLinkedRow();
			if (linked!=null) {
				DataRow DocIncasso = DS.proceeds.Rows[0];
				DocIncasso["idreg"]=DBNull.Value;
				DocIncasso["idfin"]=DBNull.Value;
				DocIncasso["idman"]=DBNull.Value;
				Meta.unlink(linked);
			}
			txtNumeroRiga.Text="";
			FillDettagliMovSpesa();
		}

		void FillDettagliMovSpesa(){
			DataRow linked= GetLinkedRow();
			if (linked==null){
				txtCreditoreDebitore.Text="";
				txtBilancio.Text="";
				txtDescrBilancio.Text="";
				txtResponsabile.Text="";
				txtImporto.Text="";
                txtNumeroRiga.Text = "";
			}
			else {
				txtCreditoreDebitore.Text= linked["registry"].ToString();
                object newidfin = calcolaBilancioPerReversale(linked["idfin"]);

                DataTable tFin = Meta.Conn.RUN_SELECT("fin", null, null, QHS.CmpEq("idfin", newidfin), null, true);

                if (tFin.Rows.Count > 0)
                {
                    txtBilancio.Text = tFin.Rows[0]["codefin"].ToString();
                    txtDescrBilancio.Text = tFin.Rows[0]["title"].ToString();
                }
				txtResponsabile.Text=linked["manager"].ToString();
				txtImporto.Text= CfgFn.GetNoNullDecimal(linked["curramount"]).ToString("c");
                txtNumeroRiga.Text = linked["nmov"].ToString();
			}
		}
		
		private void SetButtonsCollegaScollega(){
			bool res= (GetLinkedRow()!=null);
			btnScollega.Enabled=res;
			btnRigaMandato.Enabled=!res;
			txtNumeroRiga.ReadOnly=res;
		}

		public void MetaData_AfterActivation() {
//			chbEuro.Visible=(Convert.ToInt16(Meta.GetSys("esercizio")) < 2002);
            int UltimaFase = CfgFn.GetNoNullInt32(Meta.GetSys("maxincomephase"));
			string DescrFase = DS.incomephase.Rows[UltimaFase-1]["description"].ToString();
			gboxRigaMandato.Text=DescrFase;
			btnRigaMandato.Text=DescrFase;
			DataRow rPersEntrata= DS.Tables["config"].Rows[0];
            byte proceeds_flag = (byte)rPersEntrata["proceeds_flag"];
            flagcreddeb = (proceeds_flag & 4) == 4;
            flagbilancio = (proceeds_flag & 2) == 2;
            flagrespons = (proceeds_flag & 16) == 16;
            flagresidui = (proceeds_flag & 8) == 8;
            
            int flag = CfgFn.GetNoNullInt32(DS.proceeds.Columns["flag"].DefaultValue);
            if (!flagresidui) {
                flag = flag & 0xF8;
                flag = flag + 4;
               
            }
            else {
                flag = flag & 0xF8;
                flag = flag + 1;
                
            }
            flag = flag & 0xF7;
            flag = flag | 0x08;

			DS.proceeds.Columns["flag"].DefaultValue=flag;

            DataRow[] bollo = DS.stamphandling.Select(QHC.CmpEq("flagdefault", "S"));
            if (bollo.Length == 1) MetaData.SetDefault(DS.proceeds, "idstamphandling", bollo[0]["idstamphandling"]);

			DataRow[] cassiere = DS.treasurer.Select("flagdefault='S'");
			if (cassiere.Length==1) MetaData.SetDefault(DS.proceeds, "idtreasurer", cassiere[0]["idtreasurer"]);

            if (DS.treasurer.Select(QHC.CmpNe("idtreasurer", 0)).Length == 1) {
                object codiceistituto = DS.treasurer.Select(QHC.CmpNe("idtreasurer", 0))[0]["idtreasurer"];
                MetaData.SetDefault(DS.proceeds, "idtreasurer", codiceistituto);
            }
	
            int codicefase = CfgFn.GetNoNullInt32(Meta.GetSys("maxincomephase"));
            object esercizio = Meta.GetSys("esercizio");

            string MyFilter = QHS.AppAnd(QHS.CmpEq("nphase",codicefase),QHS.IsNull("kpro"),
                QHS.CmpEq("ayear",esercizio));

			comandochoose = "choose.incomelastview.movimentiaperti." + MyFilter;
			btnRigaMandato.Tag= comandochoose;

			//MetaData.MainAdd(this);
		}

		void AfterLinkBody(){
            QHS = Meta.Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            Meta.DontWarnOnInsertCancel = true;
			string filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
			GetData.CacheTable(DS.config,filteresercizio,null,false);
			DS.Tables["incomephase"].ExtendedProperties["sort_by"]="nphase";
			GetData.CacheTable(DS.incomephase);
            GetData.SetStaticFilter(DS.incomelastview, QHS.CmpEq("ymov", Meta.GetSys("esercizio")));
            HelpForm.SetDenyNull(DS.proceeds.Columns["idtreasurer"], true);

		}
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
			AfterLinkBody();
            GetData.SetStaticFilter(DS.proceeds, QHS.CmpEq("ypro", Meta.GetSys("esercizio")));
        }

		void FillTxtTipoIncasso(){
			//string codetipo = DS.proceeds.Rows[0]["kind"].ToString().ToUpper();
            byte flag = CfgFn.GetNoNullByte(DS.proceeds.Rows[0]["flag"]);     
            if ((flag & 4) != 0) txtTipoIncasso.Text = "Misto";
            if ((flag & 1) != 0) txtTipoIncasso.Text = "Competenza";
            if ((flag & 2) != 0) txtTipoIncasso.Text = "Residui";
		}

		public void MetaData_AfterFill() {
			txtEsercizioRiga.Text=Meta.GetSys("esercizio").ToString();
			FillTxtTipoIncasso();
			SetButtonsCollegaScollega();
			FillDettagliMovSpesa();
            if (Meta.EditMode)
            {
                btnIstitutoCassiere.Enabled = false;
                cmbCodiceIstituto.Enabled = false;
            }
		}

		public void MetaData_BeforePost() {
			azzeraMovBancarioInEntrata();
            object flagautostampa = Meta.Conn.DO_READ_VALUE("config",
                   "(ayear='" + Meta.GetSys("esercizio").ToString() + "')", "proceeds_flagautoprintdate");
            if (Meta.InsertMode && (DS.proceeds.Rows.Count != 0) && 
                (flagautostampa != null) && (flagautostampa.ToString().ToUpper() == "S")) {
                DS.proceeds.Rows[0]["printdate"] = DS.proceeds.Rows[0]["adate"];
            }
		}

		
		public void MetaData_AfterPost() {
			DataRow R = GetLinkedRow();
			if (R==null) DS.incomelastview.Clear();
			if (DS.proceeds.Rows.Count == 0) return;
			fillProceedsBank();
			DS.proceeds_bankview.Clear();
			DataRow Curr = DS.proceeds.Rows[0];
			string filter = QHS.CmpKey(Curr);
			DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.proceeds_bankview, "idpro", filter, null, true);
		}

		public void MetaData_AfterRowSelect(DataTable T, DataRow R){
			if (Meta.IsEmpty) return;
			if (T.TableName == "incomelastview") {
				if (R==null) return;
                Meta.GetFormData(true);
                foreach (DataRow DD in DS.incomelastview.Select()) {
                    if (DD["nmov"].ToString() == R["nmov"].ToString()) continue;
                    if (DD["kpro",DataRowVersion.Original]==DBNull.Value) {
                        DD.Delete();
                        DD.AcceptChanges();
                        continue;
                    }
                    if (DD["nmov"].ToString() != R["nmov"].ToString()) {
                        DD["kpro"] = DBNull.Value;
                    }

                }
                DataRow DocIncasso = DS.proceeds.Rows[0];
				//if (flagresidui) DocIncasso["kind"]=R["flagarrear"].ToString();
                if (flagresidui) {
                    string flagarrear = R["flagarrear"].ToString().ToUpper();
                    int flag = CfgFn.GetNoNullInt32(DocIncasso["flag"]);
                    flag = flag & 0xF8;
                    if (flagarrear == "C") {
                        flag = flag + 1;
                        DocIncasso["flag"] = flag; //C
                    }
                    else {
                        flag = flag + 2;
                        DocIncasso["flag"] = flag; //R
                    }
                }
				if (flagcreddeb) DocIncasso["idreg"]=R["idreg"];
                if (flagbilancio) DocIncasso["idfin"] = calcolaBilancioPerReversale(R["idfin"]);
				if (flagrespons) DocIncasso["idman"]=R["idman"];
                Meta.FreshForm(false);
			}
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

        int GetPaymentLevelForFin(int idfin, int level) {
            if (level == 0)
                return idfin;
            int newidfin = idfin;
            object O = Meta.Conn.DO_READ_VALUE(
                "finlink", QHS.AppAnd(
                        QHS.CmpEq("idchild", idfin),
                        QHS.CmpEq("nlevel", level)),
                "idparent");
            if (O != DBNull.Value)
                newidfin = CfgFn.GetNoNullInt32(O);

            return newidfin;

        }

        object calcolaBilancioPerReversale(object idfin) {
            int idbilancioreversale = CfgFn.GetNoNullInt32(idfin);
            byte proceeds_flag = (byte)DS.Tables["config"].Rows[0]["proceeds_flag"];
            bool flagbilancio = (proceeds_flag & 2) == 2;
            object payment_finlevel = DS.Tables["config"].Rows[0]["proceeds_finlevel"];
            object maxlivbilancio = Meta.Conn.DO_READ_VALUE("finlevel",
                            QHS.CmpEq("ayear", Meta.Conn.GetEsercizio()), "max(nlevel)");

            if (flagbilancio &&
                (payment_finlevel != DBNull.Value) &&
                (!payment_finlevel.Equals(maxlivbilancio))
                ) {
                int liv = CfgFn.GetNoNullInt32(payment_finlevel);
                idbilancioreversale = GetPaymentLevelForFin(idbilancioreversale, liv);
            }
            return idbilancioreversale;
        }



		private void azzeraMovBancarioInEntrata() {
			if (DS.proceeds.Rows.Count == 0) return;
			string filtro = QHS.AppAnd(QHS.IsNull("ypro"), QHS.IsNotNull("idpro"));
			foreach(DataRow R in DS.incomelastview.Select(filtro)) {
				R["idpro"] = DBNull.Value;
			}
		}

		private void btnScollega_Click(object sender, System.EventArgs e) {
			ScollegaRiga();
		}

		private void txtNumeroRiga_Leave(object sender, System.EventArgs e) {
			if (InChiusura) return;
            if (!Meta.DrawStateIsDone) return;
            if (txtNumeroRiga.ReadOnly == true) return;
			if (txtNumeroRiga.Enabled==false) return;
			if (Meta.IsEmpty) return;
			string nummov= txtNumeroRiga.Text.Trim();
            if (nummov == "" && DS.incomelastview.Rows.Count > 0) {
                ScollegaRiga();
				return;
			}
            if (nummov == "") return;
            if (DS.incomelastview.Rows.Count == 1) {
                DataRow Curr = DS.incomelastview.Rows[0];
                if (Curr["nmov"].ToString() == nummov) return;
            }
            ScollegaRiga();

            //if (!MetaData.Choose(this, QHS.AppAnd(comandochoose, QHS.CmpEq("nmov",nummov)))) {
            if (!MetaData.Choose(this, comandochoose + "AND" + QHS.CmpEq("nmov", nummov))) {
                txtNumeroRiga.Focus();
			}
		}

		private void fillProceedsBank() {
			DataRow Curr = DS.proceeds.Rows[0];
			DataSet Out = Meta.Conn.CallSP("compute_proceeds_bank",
				new object[] {Curr["kpro"]},false,0);
		}

	}
}
