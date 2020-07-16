/*
    Easy
    Copyright (C) 2020 UniversitÃ  degli Studi di Catania (www.unict.it)
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


namespace ritenuta770//ritenuta770//
{
	/// <summary>
	/// Summary description for FrmRitenuta770.
	/// </summary>
	public class Frm_ritenuta770 : System.Windows.Forms.Form
	{
		public /*Rana:ritenuta770.*/vistaForm DS;
		private System.Windows.Forms.ImageList images;
		private System.Windows.Forms.Label labelNonDisponibili;
		public System.Windows.Forms.Panel MetaDataDetail;
		private System.Windows.Forms.Label labelDescrizione;
		private System.Windows.Forms.Label labelCodiceCausale;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBoxCodiceCausale;
		private System.Windows.Forms.Label labelEsercizio;
		private System.Windows.Forms.TextBox textBoxEsercizio;
		public System.Windows.Forms.ToolBar MetaDataToolBar;
		private System.Windows.Forms.ToolBarButton seleziona;
		private System.Windows.Forms.ToolBarButton impostaricerca;
		private System.Windows.Forms.ToolBarButton effettuaricerca;
		private System.Windows.Forms.ToolBarButton modifica;
		private System.Windows.Forms.ToolBarButton inserisci;
		private System.Windows.Forms.ToolBarButton inseriscicopia;
		private System.Windows.Forms.ToolBarButton elimina;
		private System.Windows.Forms.ToolBarButton Salva;
		private System.Windows.Forms.ToolBarButton aggiorna;
		private System.Windows.Forms.ToolBarButton btnGotoPrev;
		private System.Windows.Forms.ToolBarButton btnGotoNext;
		private System.Windows.Forms.ToolBarButton btnAffianca;
		private System.Windows.Forms.ToolBarButton btnEditNotes;
		private System.Windows.Forms.DataGrid dataGridRitenuta770;
		private System.ComponentModel.IContainer components;

		public Frm_ritenuta770()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FrmRitenuta770));
			this.DS = new /*Rana:ritenuta770.*/vistaForm();
			this.images = new System.Windows.Forms.ImageList(this.components);
			this.labelNonDisponibili = new System.Windows.Forms.Label();
			this.MetaDataDetail = new System.Windows.Forms.Panel();
			this.labelDescrizione = new System.Windows.Forms.Label();
			this.labelCodiceCausale = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBoxCodiceCausale = new System.Windows.Forms.TextBox();
			this.labelEsercizio = new System.Windows.Forms.Label();
			this.textBoxEsercizio = new System.Windows.Forms.TextBox();
			this.dataGridRitenuta770 = new System.Windows.Forms.DataGrid();
			this.MetaDataToolBar = new System.Windows.Forms.ToolBar();
			this.seleziona = new System.Windows.Forms.ToolBarButton();
			this.impostaricerca = new System.Windows.Forms.ToolBarButton();
			this.effettuaricerca = new System.Windows.Forms.ToolBarButton();
			this.modifica = new System.Windows.Forms.ToolBarButton();
			this.inserisci = new System.Windows.Forms.ToolBarButton();
			this.inseriscicopia = new System.Windows.Forms.ToolBarButton();
			this.elimina = new System.Windows.Forms.ToolBarButton();
			this.Salva = new System.Windows.Forms.ToolBarButton();
			this.aggiorna = new System.Windows.Forms.ToolBarButton();
			this.btnGotoPrev = new System.Windows.Forms.ToolBarButton();
			this.btnGotoNext = new System.Windows.Forms.ToolBarButton();
			this.btnAffianca = new System.Windows.Forms.ToolBarButton();
			this.btnEditNotes = new System.Windows.Forms.ToolBarButton();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.MetaDataDetail.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridRitenuta770)).BeginInit();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// images
			// 
			this.images.ImageSize = new System.Drawing.Size(32, 32);
			this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
			this.images.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// labelNonDisponibili
			// 
			this.labelNonDisponibili.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.labelNonDisponibili.Location = new System.Drawing.Point(8, 67);
			this.labelNonDisponibili.Name = "labelNonDisponibili";
			this.labelNonDisponibili.Size = new System.Drawing.Size(600, 16);
			this.labelNonDisponibili.TabIndex = 17;
			this.labelNonDisponibili.Text = "Le causali per il modello 770 non sono disponibili perchè non sono ancora state c" +
				"omunicate dal Ministero.";
			this.labelNonDisponibili.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// MetaDataDetail
			// 
			this.MetaDataDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.MetaDataDetail.Controls.Add(this.labelDescrizione);
			this.MetaDataDetail.Controls.Add(this.labelCodiceCausale);
			this.MetaDataDetail.Controls.Add(this.textBox1);
			this.MetaDataDetail.Controls.Add(this.textBoxCodiceCausale);
			this.MetaDataDetail.Controls.Add(this.labelEsercizio);
			this.MetaDataDetail.Controls.Add(this.textBoxEsercizio);
			this.MetaDataDetail.Location = new System.Drawing.Point(8, 299);
			this.MetaDataDetail.Name = "MetaDataDetail";
			this.MetaDataDetail.Size = new System.Drawing.Size(608, 104);
			this.MetaDataDetail.TabIndex = 16;
			// 
			// labelDescrizione
			// 
			this.labelDescrizione.Location = new System.Drawing.Point(8, 64);
			this.labelDescrizione.Name = "labelDescrizione";
			this.labelDescrizione.Size = new System.Drawing.Size(64, 23);
			this.labelDescrizione.TabIndex = 10;
			this.labelDescrizione.Text = "Descrizione";
			// 
			// labelCodiceCausale
			// 
			this.labelCodiceCausale.Location = new System.Drawing.Point(256, 8);
			this.labelCodiceCausale.Name = "labelCodiceCausale";
			this.labelCodiceCausale.Size = new System.Drawing.Size(88, 23);
			this.labelCodiceCausale.TabIndex = 8;
			this.labelCodiceCausale.Tag = "";
			this.labelCodiceCausale.Text = "Codice causale";
			this.labelCodiceCausale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(72, 40);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(528, 56);
			this.textBox1.TabIndex = 11;
			this.textBox1.Tag = "delete_tax770.delete_descrizione";
			this.textBox1.Text = "";
			// 
			// textBoxCodiceCausale
			// 
			this.textBoxCodiceCausale.Location = new System.Drawing.Point(344, 8);
			this.textBoxCodiceCausale.Name = "textBoxCodiceCausale";
			this.textBoxCodiceCausale.TabIndex = 9;
			this.textBoxCodiceCausale.Tag = "delete_tax770.delete_codiceritenuta770";
			this.textBoxCodiceCausale.Text = "";
			// 
			// labelEsercizio
			// 
			this.labelEsercizio.Location = new System.Drawing.Point(8, 8);
			this.labelEsercizio.Name = "labelEsercizio";
			this.labelEsercizio.Size = new System.Drawing.Size(56, 23);
			this.labelEsercizio.TabIndex = 4;
			this.labelEsercizio.Text = "Esercizio";
			this.labelEsercizio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxEsercizio
			// 
			this.textBoxEsercizio.Location = new System.Drawing.Point(72, 8);
			this.textBoxEsercizio.Name = "textBoxEsercizio";
			this.textBoxEsercizio.TabIndex = 5;
			this.textBoxEsercizio.Tag = "delete_tax770.delete_esercizio.year";
			this.textBoxEsercizio.Text = "";
			// 
			// dataGridRitenuta770
			// 
			this.dataGridRitenuta770.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridRitenuta770.DataMember = "";
			this.dataGridRitenuta770.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridRitenuta770.Location = new System.Drawing.Point(8, 91);
			this.dataGridRitenuta770.Name = "dataGridRitenuta770";
			this.dataGridRitenuta770.Size = new System.Drawing.Size(608, 208);
			this.dataGridRitenuta770.TabIndex = 15;
			this.dataGridRitenuta770.Tag = "delete_tax770";
			// 
			// MetaDataToolBar
			// 
			this.MetaDataToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.MetaDataToolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																							   this.seleziona,
																							   this.impostaricerca,
																							   this.effettuaricerca,
																							   this.modifica,
																							   this.inserisci,
																							   this.inseriscicopia,
																							   this.elimina,
																							   this.Salva,
																							   this.aggiorna,
																							   this.btnGotoPrev,
																							   this.btnGotoNext,
																							   this.btnAffianca,
																							   this.btnEditNotes});
			this.MetaDataToolBar.ButtonSize = new System.Drawing.Size(32, 32);
			this.MetaDataToolBar.DropDownArrows = true;
			this.MetaDataToolBar.ImageList = this.images;
			this.MetaDataToolBar.Location = new System.Drawing.Point(0, 0);
			this.MetaDataToolBar.Name = "MetaDataToolBar";
			this.MetaDataToolBar.ShowToolTips = true;
			this.MetaDataToolBar.Size = new System.Drawing.Size(624, 110);
			this.MetaDataToolBar.TabIndex = 14;
			this.MetaDataToolBar.Tag = "";
			// 
			// seleziona
			// 
			this.seleziona.ImageIndex = 1;
			this.seleziona.Tag = "mainselect";
			this.seleziona.Text = "Seleziona";
			this.seleziona.ToolTipText = "Seleziona l\'elemento desiderato";
			// 
			// impostaricerca
			// 
			this.impostaricerca.ImageIndex = 10;
			this.impostaricerca.Tag = "mainsetsearch";
			this.impostaricerca.Text = "Imposta Ricerca";
			this.impostaricerca.ToolTipText = "Imposta una nuova ricerca";
			// 
			// effettuaricerca
			// 
			this.effettuaricerca.ImageIndex = 12;
			this.effettuaricerca.Tag = "maindosearch";
			this.effettuaricerca.Text = "Effettua Ricerca";
			this.effettuaricerca.ToolTipText = "Cerca in base ai dati immessi";
			// 
			// modifica
			// 
			this.modifica.ImageIndex = 6;
			this.modifica.Tag = "mainedit";
			this.modifica.Text = "Modifica";
			this.modifica.ToolTipText = "Modifica l\'elemento selezionato";
			// 
			// inserisci
			// 
			this.inserisci.ImageIndex = 0;
			this.inserisci.Tag = "maininsert";
			this.inserisci.Text = "Inserisci";
			this.inserisci.ToolTipText = "Inserisci un nuovo elemento";
			// 
			// inseriscicopia
			// 
			this.inseriscicopia.ImageIndex = 9;
			this.inseriscicopia.Tag = "maininsertcopy";
			this.inseriscicopia.Text = "Inserisci copia";
			this.inseriscicopia.ToolTipText = "Inserisci un nuovo elemento copiando i dati da quello attuale";
			// 
			// elimina
			// 
			this.elimina.ImageIndex = 3;
			this.elimina.Tag = "maindelete";
			this.elimina.Text = "Elimina";
			this.elimina.ToolTipText = "Elimina l\'elemento selezionato";
			// 
			// Salva
			// 
			this.Salva.ImageIndex = 2;
			this.Salva.Tag = "mainsave";
			this.Salva.Text = "Salva";
			this.Salva.ToolTipText = "Salva le modifiche effettuate";
			// 
			// aggiorna
			// 
			this.aggiorna.ImageIndex = 13;
			this.aggiorna.Tag = "mainrefresh";
			this.aggiorna.Text = "Aggiorna";
			// 
			// btnGotoPrev
			// 
			this.btnGotoPrev.ImageIndex = 16;
			this.btnGotoPrev.Tag = "gotoprev";
			this.btnGotoPrev.Text = "Precedente";
			// 
			// btnGotoNext
			// 
			this.btnGotoNext.ImageIndex = 17;
			this.btnGotoNext.Tag = "gotonext";
			this.btnGotoNext.Text = "Successivo";
			// 
			// btnAffianca
			// 
			this.btnAffianca.ImageIndex = 37;
			this.btnAffianca.Tag = "horizwin";
			this.btnAffianca.Text = "Affianca";
			// 
			// btnEditNotes
			// 
			this.btnEditNotes.ImageIndex = 33;
			this.btnEditNotes.Tag = "editnotes";
			this.btnEditNotes.Text = "Appunti";
			this.btnEditNotes.ToolTipText = "Modifica gli appunti associati all\'oggetto selezionato";
			// 
			// FrmRitenuta770
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(624, 406);
			this.Controls.Add(this.labelNonDisponibili);
			this.Controls.Add(this.MetaDataDetail);
			this.Controls.Add(this.dataGridRitenuta770);
			this.Controls.Add(this.MetaDataToolBar);
			this.Name = "FrmRitenuta770";
			this.Text = "FrmRitenuta770";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.MetaDataDetail.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridRitenuta770)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public void MetaData_AfterLink() 
		{
			MetaData meta = MetaData.GetMetaData(this);
			meta.CanSave = false;
			meta.CanInsert = false;

			int numrighe = meta.Conn.RUN_SELECT_COUNT("delete_tax770",null, true);

			labelNonDisponibili.Visible = numrighe == 0;

			int esercizio = (int) meta.Conn.sys["esercizio"];
			GetData.SetStaticFilter(DS.delete_tax770, "(esercizio="
				+ QueryCreator.quotedstrvalue(esercizio-1, true)
				+ ")" 
				);
		}
	}
}