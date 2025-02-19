
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

namespace stocklocationlevel_default{
	public class Frm_stocklocationlevel_default : MetaDataForm	{
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
		private System.Windows.Forms.DataGrid dgrLivelloUbicazione;
		public System.Windows.Forms.GroupBox MetaDataDetail;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rdbAlfanumerico;
		private System.Windows.Forms.RadioButton rdbNumerico;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtLungCodice;
		private System.Windows.Forms.CheckBox ckbFlagReset;
		private System.Windows.Forms.CheckBox ckbFlagOperativo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtCodiceLivello;
		private System.Windows.Forms.TextBox txtDescrizione;
		public vistaForm DS;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.ComponentModel.IContainer components;

		public Frm_stocklocationlevel_default(){
			InitializeComponent();
		}

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_stocklocationlevel_default));
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
            this.dgrLivelloUbicazione = new System.Windows.Forms.DataGrid();
            this.MetaDataDetail = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbAlfanumerico = new System.Windows.Forms.RadioButton();
            this.rdbNumerico = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLungCodice = new System.Windows.Forms.TextBox();
            this.ckbFlagReset = new System.Windows.Forms.CheckBox();
            this.ckbFlagOperativo = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodiceLivello = new System.Windows.Forms.TextBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.DS = new stocklocationlevel_default.vistaForm();
            ((System.ComponentModel.ISupportInitialize)(this.dgrLivelloUbicazione)).BeginInit();
            this.MetaDataDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
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
            this.MetaDataToolBar.Size = new System.Drawing.Size(504, 106);
            this.MetaDataToolBar.TabIndex = 42;
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
            // 
            // dgrLivelloUbicazione
            // 
            this.dgrLivelloUbicazione.DataMember = "";
            this.dgrLivelloUbicazione.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrLivelloUbicazione.Location = new System.Drawing.Point(16, 56);
            this.dgrLivelloUbicazione.Name = "dgrLivelloUbicazione";
            this.dgrLivelloUbicazione.Size = new System.Drawing.Size(472, 200);
            this.dgrLivelloUbicazione.TabIndex = 0;
            this.dgrLivelloUbicazione.Tag = "stocklocationlevel.default";
            // 
            // MetaDataDetail
            // 
            this.MetaDataDetail.Controls.Add(this.pictureBox1);
            this.MetaDataDetail.Controls.Add(this.groupBox1);
            this.MetaDataDetail.Controls.Add(this.label3);
            this.MetaDataDetail.Controls.Add(this.txtLungCodice);
            this.MetaDataDetail.Controls.Add(this.ckbFlagReset);
            this.MetaDataDetail.Controls.Add(this.ckbFlagOperativo);
            this.MetaDataDetail.Controls.Add(this.label2);
            this.MetaDataDetail.Controls.Add(this.label1);
            this.MetaDataDetail.Controls.Add(this.txtCodiceLivello);
            this.MetaDataDetail.Controls.Add(this.txtDescrizione);
            this.MetaDataDetail.Location = new System.Drawing.Point(16, 264);
            this.MetaDataDetail.Name = "MetaDataDetail";
            this.MetaDataDetail.Size = new System.Drawing.Size(472, 176);
            this.MetaDataDetail.TabIndex = 1;
            this.MetaDataDetail.TabStop = false;
            this.MetaDataDetail.Text = "Dettaglio";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(344, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 80);
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbAlfanumerico);
            this.groupBox1.Controls.Add(this.rdbNumerico);
            this.groupBox1.Location = new System.Drawing.Point(328, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(136, 64);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo codice";
            // 
            // rdbAlfanumerico
            // 
            this.rdbAlfanumerico.Location = new System.Drawing.Point(16, 40);
            this.rdbAlfanumerico.Name = "rdbAlfanumerico";
            this.rdbAlfanumerico.Size = new System.Drawing.Size(104, 16);
            this.rdbAlfanumerico.TabIndex = 1;
            this.rdbAlfanumerico.Tag = "stocklocationlevel.flag::0";
            this.rdbAlfanumerico.Text = "Alfanumerico";
            // 
            // rdbNumerico
            // 
            this.rdbNumerico.Location = new System.Drawing.Point(16, 16);
            this.rdbNumerico.Name = "rdbNumerico";
            this.rdbNumerico.Size = new System.Drawing.Size(104, 16);
            this.rdbNumerico.TabIndex = 0;
            this.rdbNumerico.Tag = "stocklocationlevel.flag::#0";
            this.rdbNumerico.Text = "Numerico";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(232, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 24);
            this.label3.TabIndex = 22;
            this.label3.Text = "Lunghezza";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLungCodice
            // 
            this.txtLungCodice.Location = new System.Drawing.Point(232, 40);
            this.txtLungCodice.Name = "txtLungCodice";
            this.txtLungCodice.Size = new System.Drawing.Size(72, 20);
            this.txtLungCodice.TabIndex = 2;
            this.txtLungCodice.Tag = "stocklocationlevel.codelen";
            // 
            // ckbFlagReset
            // 
            this.ckbFlagReset.Location = new System.Drawing.Point(8, 120);
            this.ckbFlagReset.Name = "ckbFlagReset";
            this.ckbFlagReset.Size = new System.Drawing.Size(296, 24);
            this.ckbFlagReset.TabIndex = 4;
            this.ckbFlagReset.Tag = "stocklocationlevel.flag:#2";
            this.ckbFlagReset.Text = "N. progressivo, non riparte sempre da uno";
            // 
            // ckbFlagOperativo
            // 
            this.ckbFlagOperativo.Location = new System.Drawing.Point(8, 144);
            this.ckbFlagOperativo.Name = "ckbFlagOperativo";
            this.ckbFlagOperativo.Size = new System.Drawing.Size(304, 24);
            this.ckbFlagOperativo.TabIndex = 3;
            this.ckbFlagOperativo.Tag = "stocklocationlevel.flag:1";
            this.ckbFlagOperativo.Text = "Le voci di questo livello sono selezionabili (operative)";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 24);
            this.label2.TabIndex = 17;
            this.label2.Text = "Denominazione";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 24);
            this.label1.TabIndex = 16;
            this.label1.Text = "Codice";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCodiceLivello
            // 
            this.txtCodiceLivello.Location = new System.Drawing.Point(8, 40);
            this.txtCodiceLivello.Name = "txtCodiceLivello";
            this.txtCodiceLivello.Size = new System.Drawing.Size(104, 20);
            this.txtCodiceLivello.TabIndex = 0;
            this.txtCodiceLivello.Tag = "stocklocationlevel.nlevel";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(8, 88);
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(304, 20);
            this.txtDescrizione.TabIndex = 1;
            this.txtDescrizione.Tag = "stocklocationlevel.description";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Frm_stocklocationlevel_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(504, 446);
            this.Controls.Add(this.MetaDataDetail);
            this.Controls.Add(this.dgrLivelloUbicazione);
            this.Controls.Add(this.MetaDataToolBar);
            this.Name = "Frm_stocklocationlevel_default";
            this.Text = "frmlivelloubicazione";
            ((System.ComponentModel.ISupportInitialize)(this.dgrLivelloUbicazione)).EndInit();
            this.MetaDataDetail.ResumeLayout(false);
            this.MetaDataDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
	}
}
