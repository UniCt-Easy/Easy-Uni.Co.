
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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
using System.Data;

namespace contractlength_lista//orariorapportolista//
{
	/// <summary>
	/// Summary description for frmOrarioRapporto.
	/// </summary>
	public class Frm_duratarapportolista : MetaDataForm
	{
		
		private System.Windows.Forms.ImageList images;
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
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.Label lblDescrizione;
		public System.Windows.Forms.GroupBox MetaDataDetail;
		public vistaForm DS;
		private System.Windows.Forms.DataGrid dataGridDurataRapporto;
		private System.Windows.Forms.Label lblCodiceDurata;
		private System.Windows.Forms.TextBox txtCodiceDurata;

		private System.ComponentModel.IContainer components;

		public Frm_duratarapportolista()
		{
			InitializeComponent();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Frm_duratarapportolista));
			this.DS = new contractlength_lista.vistaForm();
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
			this.dataGridDurataRapporto = new System.Windows.Forms.DataGrid();
			this.txtDescrizione = new System.Windows.Forms.TextBox();
			this.lblDescrizione = new System.Windows.Forms.Label();
			this.txtCodiceDurata = new System.Windows.Forms.TextBox();
			this.lblCodiceDurata = new System.Windows.Forms.Label();
			this.MetaDataDetail = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridDurataRapporto)).BeginInit();
			this.MetaDataDetail.SuspendLayout();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// images
			// 
			this.images.ImageSize = new System.Drawing.Size(30, 30);
			this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
			this.images.TransparentColor = System.Drawing.Color.Transparent;
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
																							   this.aggiorna});
			this.MetaDataToolBar.ButtonSize = new System.Drawing.Size(56, 56);
			this.MetaDataToolBar.DropDownArrows = true;
			this.MetaDataToolBar.ImageList = this.images;
			this.MetaDataToolBar.Location = new System.Drawing.Point(0, 0);
			this.MetaDataToolBar.Name = "MetaDataToolBar";
			this.MetaDataToolBar.ShowToolTips = true;
			this.MetaDataToolBar.Size = new System.Drawing.Size(608, 106);
			this.MetaDataToolBar.TabIndex = 43;
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
			// dataGridDurataRapporto
			// 
			this.dataGridDurataRapporto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridDurataRapporto.DataMember = "";
			this.dataGridDurataRapporto.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridDurataRapporto.Location = new System.Drawing.Point(8, 56);
			this.dataGridDurataRapporto.Name = "dataGridDurataRapporto";
			this.dataGridDurataRapporto.Size = new System.Drawing.Size(592, 256);
			this.dataGridDurataRapporto.TabIndex = 44;
			this.dataGridDurataRapporto.Tag = "contractlength.default";
			// 
			// txtDescrizione
			// 
			this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrizione.Location = new System.Drawing.Point(80, 56);
			this.txtDescrizione.Name = "txtDescrizione";
			this.txtDescrizione.Size = new System.Drawing.Size(504, 20);
			this.txtDescrizione.TabIndex = 3;
			this.txtDescrizione.Tag = "contractlength.description";
			this.txtDescrizione.Text = "";
			// 
			// lblDescrizione
			// 
			this.lblDescrizione.Location = new System.Drawing.Point(8, 56);
			this.lblDescrizione.Name = "lblDescrizione";
			this.lblDescrizione.Size = new System.Drawing.Size(72, 23);
			this.lblDescrizione.TabIndex = 2;
			this.lblDescrizione.Text = "Descrizione";
			this.lblDescrizione.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtCodiceDurata
			// 
			this.txtCodiceDurata.Location = new System.Drawing.Point(80, 24);
			this.txtCodiceDurata.Name = "txtCodiceDurata";
			this.txtCodiceDurata.TabIndex = 1;
			this.txtCodiceDurata.Tag = "contractlength.idcontractlength";
			this.txtCodiceDurata.Text = "";
			// 
			// lblCodiceDurata
			// 
			this.lblCodiceDurata.Location = new System.Drawing.Point(8, 24);
			this.lblCodiceDurata.Name = "lblCodiceDurata";
			this.lblCodiceDurata.Size = new System.Drawing.Size(72, 23);
			this.lblCodiceDurata.TabIndex = 0;
			this.lblCodiceDurata.Text = "Codice";
			this.lblCodiceDurata.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// MetaDataDetail
			// 
			this.MetaDataDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.MetaDataDetail.Controls.Add(this.txtDescrizione);
			this.MetaDataDetail.Controls.Add(this.lblDescrizione);
			this.MetaDataDetail.Controls.Add(this.txtCodiceDurata);
			this.MetaDataDetail.Controls.Add(this.lblCodiceDurata);
			this.MetaDataDetail.Location = new System.Drawing.Point(8, 320);
			this.MetaDataDetail.Name = "MetaDataDetail";
			this.MetaDataDetail.Size = new System.Drawing.Size(592, 89);
			this.MetaDataDetail.TabIndex = 45;
			this.MetaDataDetail.TabStop = false;
			this.MetaDataDetail.Text = "Dettagli";
			// 
			// Frm_duratarapportolista
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(608, 413);
			this.Controls.Add(this.MetaDataDetail);
			this.Controls.Add(this.dataGridDurataRapporto);
			this.Controls.Add(this.MetaDataToolBar);
			this.Name = "Frm_duratarapportolista";
			this.Text = "frmDurataRapporto";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridDurataRapporto)).EndInit();
			this.MetaDataDetail.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public void MetaData_AfterLink()
		{
			MetaData Meta= MetaData.GetMetaData(this);
			bool IsAdmin=false;
			string filteresercizio;

			if (Meta.GetSys("manage_prestazioni")!=null) 
				IsAdmin=(Meta.GetSys("manage_prestazioni").ToString()=="S");
			Meta.CanSave=IsAdmin;
			Meta.CanInsert=IsAdmin;
			Meta.CanInsertCopy=IsAdmin;
			Meta.CanCancel=IsAdmin;
			filteresercizio = Meta.QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
			GetData.SetStaticFilter(DS.contractlength,filteresercizio);
		}
	}
}
