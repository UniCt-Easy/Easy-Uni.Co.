
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

namespace positionworkcontract_default//qualificarapportolista//
{
	/// <summary>
	/// Summary description for frmqualificarapportolista.
	/// </summary>
	public class Frm_positionworkcontract_default : System.Windows.Forms.Form
	{
		public vistaForm DS;
		private System.Windows.Forms.DataGrid dataGridOrarioRapporto;
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
		private System.Windows.Forms.ImageList images;
		public System.Windows.Forms.GroupBox MetaDataDetail;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.Label lblDescrizione;
		private System.Windows.Forms.TextBox txtCodiceOrario;
		private System.Windows.Forms.Label lblCodiceOrario;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.ComponentModel.IContainer components;

		public Frm_positionworkcontract_default()
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
			HelpForm.SetDenyNull(DS.positionworkcontract.Columns["flagforcedlength"],true);
			HelpForm.SetDenyNull(DS.positionworkcontract.Columns["flagforcedtime"],true);
		}

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
			GetData.SetStaticFilter(DS.positionworkcontract,filteresercizio);
			//GetData.SetSorting(DS.tipoimponibile,"ordinedivalutazione asc");
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Frm_positionworkcontract_default));
			this.DS = new vistaForm();
			this.dataGridOrarioRapporto = new System.Windows.Forms.DataGrid();
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
			this.images = new System.Windows.Forms.ImageList(this.components);
			this.MetaDataDetail = new System.Windows.Forms.GroupBox();
			this.txtDescrizione = new System.Windows.Forms.TextBox();
			this.lblDescrizione = new System.Windows.Forms.Label();
			this.txtCodiceOrario = new System.Windows.Forms.TextBox();
			this.lblCodiceOrario = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridOrarioRapporto)).BeginInit();
			this.MetaDataDetail.SuspendLayout();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dataGridOrarioRapporto
			// 
			this.dataGridOrarioRapporto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridOrarioRapporto.DataMember = "";
			this.dataGridOrarioRapporto.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridOrarioRapporto.Location = new System.Drawing.Point(8, 55);
			this.dataGridOrarioRapporto.Name = "dataGridOrarioRapporto";
			this.dataGridOrarioRapporto.Size = new System.Drawing.Size(584, 257);
			this.dataGridOrarioRapporto.TabIndex = 47;
			this.dataGridOrarioRapporto.Tag = "positionworkcontract.default";
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
			this.MetaDataToolBar.Size = new System.Drawing.Size(600, 106);
			this.MetaDataToolBar.TabIndex = 46;
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
			// images
			// 
			this.images.ImageSize = new System.Drawing.Size(30, 30);
			this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
			this.images.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// MetaDataDetail
			// 
			this.MetaDataDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.MetaDataDetail.Controls.Add(this.checkBox2);
			this.MetaDataDetail.Controls.Add(this.checkBox1);
			this.MetaDataDetail.Controls.Add(this.txtDescrizione);
			this.MetaDataDetail.Controls.Add(this.lblDescrizione);
			this.MetaDataDetail.Controls.Add(this.txtCodiceOrario);
			this.MetaDataDetail.Controls.Add(this.lblCodiceOrario);
			this.MetaDataDetail.Location = new System.Drawing.Point(8, 320);
			this.MetaDataDetail.Name = "MetaDataDetail";
			this.MetaDataDetail.Size = new System.Drawing.Size(584, 89);
			this.MetaDataDetail.TabIndex = 48;
			this.MetaDataDetail.TabStop = false;
			this.MetaDataDetail.Text = "Dettagli";
			// 
			// txtDescrizione
			// 
			this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrizione.Location = new System.Drawing.Point(80, 56);
			this.txtDescrizione.Name = "txtDescrizione";
			this.txtDescrizione.Size = new System.Drawing.Size(496, 20);
			this.txtDescrizione.TabIndex = 3;
			this.txtDescrizione.Tag = "positionworkcontract.description";
			this.txtDescrizione.Text = "";
			// 
			// lblDescrizione
			// 
			this.lblDescrizione.Location = new System.Drawing.Point(8, 56);
			this.lblDescrizione.Name = "lblDescrizione";
			this.lblDescrizione.Size = new System.Drawing.Size(72, 23);
			this.lblDescrizione.TabIndex = 2;
			this.lblDescrizione.Text = "Descrizione";
			this.lblDescrizione.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// txtCodiceOrario
			// 
			this.txtCodiceOrario.Location = new System.Drawing.Point(80, 24);
			this.txtCodiceOrario.Name = "txtCodiceOrario";
			this.txtCodiceOrario.TabIndex = 1;
			this.txtCodiceOrario.Tag = "positionworkcontract.idposition";
			this.txtCodiceOrario.Text = "";
			// 
			// lblCodiceOrario
			// 
			this.lblCodiceOrario.Location = new System.Drawing.Point(8, 24);
			this.lblCodiceOrario.Name = "lblCodiceOrario";
			this.lblCodiceOrario.Size = new System.Drawing.Size(72, 23);
			this.lblCodiceOrario.TabIndex = 0;
			this.lblCodiceOrario.Text = "Codice";
			this.lblCodiceOrario.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(312, 16);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(128, 24);
			this.checkBox1.TabIndex = 4;
			this.checkBox1.Tag = "positionworkcontract.flagforcedlength:S:N";
			this.checkBox1.Text = "Durata Obbligatoria";
			// 
			// checkBox2
			// 
			this.checkBox2.Location = new System.Drawing.Point(456, 16);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(120, 24);
			this.checkBox2.TabIndex = 5;
			this.checkBox2.Tag = "positionworkcontract.flagforcedtime:S:N";
			this.checkBox2.Text = "Orario Obbligatorio";
			// 
			// frmqualificarapportolista
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(600, 414);
			this.Controls.Add(this.dataGridOrarioRapporto);
			this.Controls.Add(this.MetaDataToolBar);
			this.Controls.Add(this.MetaDataDetail);
			this.Name = "frmqualificarapportolista";
			this.Text = "frmqualificarapportolista";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridOrarioRapporto)).EndInit();
			this.MetaDataDetail.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
