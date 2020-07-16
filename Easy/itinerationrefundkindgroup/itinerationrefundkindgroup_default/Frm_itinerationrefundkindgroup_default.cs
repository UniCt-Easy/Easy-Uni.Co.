/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
using metadatalibrary;

namespace itinerationrefundkindgroup_default//Gruppoestero//
{
	/// <summary>
	/// Summary description for frmGruppoEstero.
	/// </summary>
    public class Frm_itinerationrefundkindgroup_default : System.Windows.Forms.Form {
		public vistaForm DS;
		private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listView1;
        public GroupBox MetaDataDetail;
        private ImageList images;
        private ImageList imageList1;
        public ToolBar MetaDataToolBar;
        private ToolBarButton seleziona;
        private ToolBarButton impostaricerca;
        private ToolBarButton effettuaricerca;
        private ToolBarButton modifica;
        private ToolBarButton inserisci;
        private ToolBarButton inseriscicopia;
        private ToolBarButton elimina;
        private ToolBarButton Salva;
        private ToolBarButton aggiorna;
        private CheckBox checkBox6;
        private Label label2;
        private TextBox txtDescrizione;
        private TextBox txtCodice;
        private Label label1;
        private DataGrid GridRiduzioni;
        private IContainer components;

		public Frm_itinerationrefundkindgroup_default()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_itinerationrefundkindgroup_default));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.MetaDataDetail = new System.Windows.Forms.GroupBox();
            this.txtCodice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
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
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GridRiduzioni = new System.Windows.Forms.DataGrid();
            this.DS = new itinerationrefundkindgroup_default.vistaForm();
            this.groupBox1.SuspendLayout();
            this.MetaDataDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridRiduzioni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Location = new System.Drawing.Point(351, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 332);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Riduzioni che danno diritto a questo rimborso";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Location = new System.Drawing.Point(15, 24);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(364, 294);
            this.listView1.TabIndex = 0;
            this.listView1.Tag = "reduction.solodescrizione";
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // MetaDataDetail
            // 
            this.MetaDataDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.MetaDataDetail.Controls.Add(this.txtCodice);
            this.MetaDataDetail.Controls.Add(this.txtDescrizione);
            this.MetaDataDetail.Controls.Add(this.label1);
            this.MetaDataDetail.Controls.Add(this.label2);
            this.MetaDataDetail.Location = new System.Drawing.Point(12, 256);
            this.MetaDataDetail.Name = "MetaDataDetail";
            this.MetaDataDetail.Size = new System.Drawing.Size(331, 137);
            this.MetaDataDetail.TabIndex = 0;
            this.MetaDataDetail.TabStop = false;
            // 
            // txtCodice
            // 
            this.txtCodice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodice.Location = new System.Drawing.Point(10, 27);
            this.txtCodice.Name = "txtCodice";
            this.txtCodice.Size = new System.Drawing.Size(104, 20);
            this.txtCodice.TabIndex = 1;
            this.txtCodice.Tag = "itinerationrefundkindgroup.iditinerationrefundkindgroup";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Descrizione";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
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
            this.MetaDataToolBar.Size = new System.Drawing.Size(761, 56);
            this.MetaDataToolBar.TabIndex = 1;
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
            // checkBox6
            // 
            this.checkBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox6.Location = new System.Drawing.Point(22, 350);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(216, 36);
            this.checkBox6.TabIndex = 3;
            this.checkBox6.Tag = "itinerationrefundkindgroup.allowalways:S:N";
            this.checkBox6.Text = "Consenti sempre la riduzione";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDescrizione.Location = new System.Drawing.Point(11, 67);
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(293, 20);
            this.txtDescrizione.TabIndex = 2;
            this.txtDescrizione.Tag = "itinerationrefundkindgroup.description";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codice";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // GridRiduzioni
            // 
            this.GridRiduzioni.DataMember = "";
            this.GridRiduzioni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.GridRiduzioni.Location = new System.Drawing.Point(12, 64);
            this.GridRiduzioni.Name = "GridRiduzioni";
            this.GridRiduzioni.Size = new System.Drawing.Size(331, 186);
            this.GridRiduzioni.TabIndex = 2;
            this.GridRiduzioni.Tag = "itinerationrefundkindgroup.default";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // Frm_itinerationrefundkindgroup_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(761, 406);
            this.Controls.Add(this.GridRiduzioni);
            this.Controls.Add(this.checkBox6);
            this.Controls.Add(this.MetaDataToolBar);
            this.Controls.Add(this.MetaDataDetail);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_itinerationrefundkindgroup_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTipiRimborsi";
            this.groupBox1.ResumeLayout(false);
            this.MetaDataDetail.ResumeLayout(false);
            this.MetaDataDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridRiduzioni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        public void MetaData_AfterLink ()
		{
			MetaData Meta = MetaData.GetMetaData(this);
            Meta = MetaData.GetMetaData(this);
            QueryHelper QHS = Meta.Conn.GetQueryHelper();
            bool IsAdmin = false;

            if (Meta.GetSys("manage_prestazioni") != null) {
                IsAdmin = (Meta.GetSys("manage_prestazioni").ToString().ToUpper() == "S");
            }
            Meta.CanSave = IsAdmin;
            Meta.CanInsert = IsAdmin;
            Meta.CanInsertCopy = IsAdmin;
            Meta.CanCancel = IsAdmin;
            HelpForm.SetDenyNull(DS.itinerationrefundkindgroup.Columns["allowalways"], true);

		}	
	}
}

		

	


