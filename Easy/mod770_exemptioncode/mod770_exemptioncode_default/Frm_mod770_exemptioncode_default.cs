
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

namespace mod770_exemptioncode_default//cdcausale770//
{
	/// <summary>
	/// Summary description for FormCdCausale770.
	/// </summary>
	public class Frm_mod770_exemptioncode_default : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ImageList images;
		public System.Windows.Forms.ToolBar MetaDataToolBar;
		private MetaData meta;
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
		public  vistaForm DS;
		private System.Windows.Forms.Label labelEsercizio;
		private System.Windows.Forms.TextBox textBoxEsercizio;
		private System.Windows.Forms.Label labelCodiceCausale;
		private System.Windows.Forms.TextBox textBoxCodiceCausale;
		private System.Windows.Forms.Label labelDescrizione;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.DataGrid dataGridCdCausale770;
        public System.Windows.Forms.Panel MetaDataDetail;
		private System.ComponentModel.IContainer components;

		public Frm_mod770_exemptioncode_default()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_mod770_exemptioncode_default));
            this.images = new System.Windows.Forms.ImageList(this.components);
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
            this.DS = new mod770_exemptioncode_default.vistaForm();
            this.dataGridCdCausale770 = new System.Windows.Forms.DataGrid();
            this.labelEsercizio = new System.Windows.Forms.Label();
            this.textBoxEsercizio = new System.Windows.Forms.TextBox();
            this.labelCodiceCausale = new System.Windows.Forms.Label();
            this.textBoxCodiceCausale = new System.Windows.Forms.TextBox();
            this.labelDescrizione = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.MetaDataDetail = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCdCausale770)).BeginInit();
            this.MetaDataDetail.SuspendLayout();
            this.SuspendLayout();
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
            this.images.Images.SetKeyName(6, "");
            this.images.Images.SetKeyName(7, "");
            this.images.Images.SetKeyName(8, "");
            this.images.Images.SetKeyName(9, "");
            this.images.Images.SetKeyName(10, "");
            this.images.Images.SetKeyName(11, "");
            this.images.Images.SetKeyName(12, "");
            this.images.Images.SetKeyName(13, "");
            this.images.Images.SetKeyName(14, "");
            this.images.Images.SetKeyName(15, "");
            this.images.Images.SetKeyName(16, "");
            this.images.Images.SetKeyName(17, "");
            this.images.Images.SetKeyName(18, "");
            this.images.Images.SetKeyName(19, "");
            this.images.Images.SetKeyName(20, "");
            this.images.Images.SetKeyName(21, "");
            this.images.Images.SetKeyName(22, "");
            this.images.Images.SetKeyName(23, "");
            this.images.Images.SetKeyName(24, "");
            this.images.Images.SetKeyName(25, "");
            this.images.Images.SetKeyName(26, "");
            this.images.Images.SetKeyName(27, "");
            this.images.Images.SetKeyName(28, "");
            this.images.Images.SetKeyName(29, "");
            this.images.Images.SetKeyName(30, "");
            this.images.Images.SetKeyName(31, "");
            this.images.Images.SetKeyName(32, "");
            this.images.Images.SetKeyName(33, "");
            this.images.Images.SetKeyName(34, "");
            this.images.Images.SetKeyName(35, "");
            this.images.Images.SetKeyName(36, "");
            this.images.Images.SetKeyName(37, "");
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
            this.MetaDataToolBar.TabIndex = 2;
            this.MetaDataToolBar.Tag = "";
            // 
            // seleziona
            // 
            this.seleziona.ImageIndex = 1;
            this.seleziona.Name = "seleziona";
            this.seleziona.Tag = "mainselect";
            this.seleziona.Text = "Seleziona";
            this.seleziona.ToolTipText = "Seleziona l\'elemento desiderato";
            // 
            // impostaricerca
            // 
            this.impostaricerca.ImageIndex = 10;
            this.impostaricerca.Name = "impostaricerca";
            this.impostaricerca.Tag = "mainsetsearch";
            this.impostaricerca.Text = "Imposta Ricerca";
            this.impostaricerca.ToolTipText = "Imposta una nuova ricerca";
            // 
            // effettuaricerca
            // 
            this.effettuaricerca.ImageIndex = 12;
            this.effettuaricerca.Name = "effettuaricerca";
            this.effettuaricerca.Tag = "maindosearch";
            this.effettuaricerca.Text = "Effettua Ricerca";
            this.effettuaricerca.ToolTipText = "Cerca in base ai dati immessi";
            // 
            // modifica
            // 
            this.modifica.ImageIndex = 6;
            this.modifica.Name = "modifica";
            this.modifica.Tag = "mainedit";
            this.modifica.Text = "Modifica";
            this.modifica.ToolTipText = "Modifica l\'elemento selezionato";
            // 
            // inserisci
            // 
            this.inserisci.ImageIndex = 0;
            this.inserisci.Name = "inserisci";
            this.inserisci.Tag = "maininsert";
            this.inserisci.Text = "Inserisci";
            this.inserisci.ToolTipText = "Inserisci un nuovo elemento";
            // 
            // inseriscicopia
            // 
            this.inseriscicopia.ImageIndex = 9;
            this.inseriscicopia.Name = "inseriscicopia";
            this.inseriscicopia.Tag = "maininsertcopy";
            this.inseriscicopia.Text = "Inserisci copia";
            this.inseriscicopia.ToolTipText = "Inserisci un nuovo elemento copiando i dati da quello attuale";
            // 
            // elimina
            // 
            this.elimina.ImageIndex = 3;
            this.elimina.Name = "elimina";
            this.elimina.Tag = "maindelete";
            this.elimina.Text = "Elimina";
            this.elimina.ToolTipText = "Elimina l\'elemento selezionato";
            // 
            // Salva
            // 
            this.Salva.ImageIndex = 2;
            this.Salva.Name = "Salva";
            this.Salva.Tag = "mainsave";
            this.Salva.Text = "Salva";
            this.Salva.ToolTipText = "Salva le modifiche effettuate";
            // 
            // aggiorna
            // 
            this.aggiorna.ImageIndex = 13;
            this.aggiorna.Name = "aggiorna";
            this.aggiorna.Tag = "mainrefresh";
            this.aggiorna.Text = "Aggiorna";
            // 
            // btnGotoPrev
            // 
            this.btnGotoPrev.ImageIndex = 16;
            this.btnGotoPrev.Name = "btnGotoPrev";
            this.btnGotoPrev.Tag = "gotoprev";
            this.btnGotoPrev.Text = "Precedente";
            // 
            // btnGotoNext
            // 
            this.btnGotoNext.ImageIndex = 17;
            this.btnGotoNext.Name = "btnGotoNext";
            this.btnGotoNext.Tag = "gotonext";
            this.btnGotoNext.Text = "Successivo";
            // 
            // btnAffianca
            // 
            this.btnAffianca.ImageIndex = 37;
            this.btnAffianca.Name = "btnAffianca";
            this.btnAffianca.Tag = "horizwin";
            this.btnAffianca.Text = "Affianca";
            // 
            // btnEditNotes
            // 
            this.btnEditNotes.ImageIndex = 33;
            this.btnEditNotes.Name = "btnEditNotes";
            this.btnEditNotes.Tag = "editnotes";
            this.btnEditNotes.Text = "Appunti";
            this.btnEditNotes.ToolTipText = "Modifica gli appunti associati all\'oggetto selezionato";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridCdCausale770
            // 
            this.dataGridCdCausale770.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridCdCausale770.DataMember = "";
            this.dataGridCdCausale770.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridCdCausale770.Location = new System.Drawing.Point(8, 88);
            this.dataGridCdCausale770.Name = "dataGridCdCausale770";
            this.dataGridCdCausale770.Size = new System.Drawing.Size(608, 208);
            this.dataGridCdCausale770.TabIndex = 3;
            this.dataGridCdCausale770.Tag = "mod770_exemptioncode";
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
            this.textBoxEsercizio.Size = new System.Drawing.Size(100, 20);
            this.textBoxEsercizio.TabIndex = 5;
            this.textBoxEsercizio.Tag = "mod770_exemptioncode.ayear.year";
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
            // textBoxCodiceCausale
            // 
            this.textBoxCodiceCausale.Location = new System.Drawing.Point(344, 8);
            this.textBoxCodiceCausale.Name = "textBoxCodiceCausale";
            this.textBoxCodiceCausale.Size = new System.Drawing.Size(100, 20);
            this.textBoxCodiceCausale.TabIndex = 9;
            this.textBoxCodiceCausale.Tag = "mod770_exemptioncode.exemptioncode";
            // 
            // labelDescrizione
            // 
            this.labelDescrizione.Location = new System.Drawing.Point(8, 64);
            this.labelDescrizione.Name = "labelDescrizione";
            this.labelDescrizione.Size = new System.Drawing.Size(64, 23);
            this.labelDescrizione.TabIndex = 10;
            this.labelDescrizione.Text = "Descrizione";
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
            this.textBox1.Tag = "mod770_exemptioncode.description";
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
            this.MetaDataDetail.Location = new System.Drawing.Point(8, 296);
            this.MetaDataDetail.Name = "MetaDataDetail";
            this.MetaDataDetail.Size = new System.Drawing.Size(608, 104);
            this.MetaDataDetail.TabIndex = 12;
            // 
            // Frm_mod770_exemptioncode_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(624, 406);
            this.Controls.Add(this.MetaDataDetail);
            this.Controls.Add(this.dataGridCdCausale770);
            this.Controls.Add(this.MetaDataToolBar);
            this.Name = "Frm_mod770_exemptioncode_default";
            this.Text = "FormCdCausale770";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCdCausale770)).EndInit();
            this.MetaDataDetail.ResumeLayout(false);
            this.MetaDataDetail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public void MetaData_AfterLink() 
		{
			meta = MetaData.GetMetaData(this);
			meta.CanSave = false;
			meta.CanInsert = false;

			int numrighe = meta.Conn.RUN_SELECT_COUNT("mod770_exemptioncode",null, true);


			int esercizio = (int) meta.Conn.GetEsercizio();
			GetData.SetStaticFilter(DS.mod770_exemptioncode, "(ayear=" + esercizio + ")");
		}
	}
}
