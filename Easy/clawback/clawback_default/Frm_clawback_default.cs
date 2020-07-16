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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;

namespace clawback_default//tiporecupero//
{
	/// <summary>
	/// Summary description for frmtiporecupero.
	/// </summary>
	public class Frm_clawback_default : System.Windows.Forms.Form
	{
		public System.Windows.Forms.Panel panel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGrid dataGrid1;
		public vistaForm DS;
		private System.Windows.Forms.TextBox txtCodice;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.ImageList images;
		public System.Windows.Forms.ToolBar MetaDataToolBar;
		private System.Windows.Forms.ToolBarButton seleziona;
		private System.Windows.Forms.ToolBarButton impostaricerca;
		private System.Windows.Forms.ToolBarButton effettuaricerca;
		private System.Windows.Forms.ToolBarButton inserisci;
		private System.Windows.Forms.ToolBarButton inseriscicopia;
		private System.Windows.Forms.ToolBarButton elimina;
		private System.Windows.Forms.ToolBarButton Salva;
		private System.Windows.Forms.ToolBarButton aggiorna;
        public TabControl MetaDataDetail;
        private System.Windows.Forms.TabPage tabMain;
		private System.Windows.Forms.TabPage tabClass;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button5;
        private CheckBox checkBox1;
        private TextBox textBox1;
        private Label label3;
        private CheckBox checkBox2;
        private GroupBox gboxRecupero;
        private TextBox txtCredDeb;
        private System.ComponentModel.IContainer components;

		public Frm_clawback_default()
		{
			InitializeComponent();
            HelpForm.SetDenyNull(DS.clawback.Columns["active"], true);
            HelpForm.SetDenyNull(DS.clawback.Columns["flagf24ep"], true);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_clawback_default));
            this.panel = new System.Windows.Forms.Panel();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodice = new System.Windows.Forms.TextBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.DS = new clawback_default.vistaForm();
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.MetaDataToolBar = new System.Windows.Forms.ToolBar();
            this.seleziona = new System.Windows.Forms.ToolBarButton();
            this.impostaricerca = new System.Windows.Forms.ToolBarButton();
            this.effettuaricerca = new System.Windows.Forms.ToolBarButton();
            this.inserisci = new System.Windows.Forms.ToolBarButton();
            this.inseriscicopia = new System.Windows.Forms.ToolBarButton();
            this.elimina = new System.Windows.Forms.ToolBarButton();
            this.Salva = new System.Windows.Forms.ToolBarButton();
            this.aggiorna = new System.Windows.Forms.ToolBarButton();
            this.MetaDataDetail = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.tabClass = new System.Windows.Forms.TabPage();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.gboxRecupero = new System.Windows.Forms.GroupBox();
            this.txtCredDeb = new System.Windows.Forms.TextBox();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.MetaDataDetail.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabClass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.gboxRecupero.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel.Controls.Add(this.gboxRecupero);
            this.panel.Controls.Add(this.checkBox2);
            this.panel.Controls.Add(this.textBox1);
            this.panel.Controls.Add(this.label3);
            this.panel.Controls.Add(this.checkBox1);
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.txtCodice);
            this.panel.Controls.Add(this.txtDescrizione);
            this.panel.Controls.Add(this.label1);
            this.panel.Location = new System.Drawing.Point(8, 16);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(584, 196);
            this.panel.TabIndex = 15;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(364, 23);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(161, 17);
            this.checkBox2.TabIndex = 9;
            this.checkBox2.Tag = "clawback.flagf24ep:S:N";
            this.checkBox2.Text = "Intervento Sostitutivo F24EP";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(68, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(151, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Tag = "clawback.clawbackref";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(7, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Codice:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(10, 165);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(79, 24);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Tag = "clawback.active:S:N";
            this.checkBox1.Text = "Attivo";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Descrizione:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCodice
            // 
            this.txtCodice.Location = new System.Drawing.Point(68, 3);
            this.txtCodice.Name = "txtCodice";
            this.txtCodice.Size = new System.Drawing.Size(100, 20);
            this.txtCodice.TabIndex = 1;
            this.txtCodice.Tag = "clawback.idclawback";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(10, 77);
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(256, 20);
            this.txtDescrizione.TabIndex = 3;
            this.txtDescrizione.Tag = "clawback.description";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGrid1
            // 
            this.dataGrid1.AllowNavigation = false;
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(16, 56);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.Size = new System.Drawing.Size(600, 206);
            this.dataGrid1.TabIndex = 13;
            this.dataGrid1.Tag = "clawback.default";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
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
            // MetaDataToolBar
            // 
            this.MetaDataToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.MetaDataToolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.seleziona,
            this.impostaricerca,
            this.effettuaricerca,
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
            this.MetaDataToolBar.Size = new System.Drawing.Size(624, 106);
            this.MetaDataToolBar.TabIndex = 18;
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
            // MetaDataDetail
            // 
            this.MetaDataDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MetaDataDetail.Controls.Add(this.tabMain);
            this.MetaDataDetail.Controls.Add(this.tabClass);
            this.MetaDataDetail.ImageList = this.imageList1;
            this.MetaDataDetail.Location = new System.Drawing.Point(8, 279);
            this.MetaDataDetail.Name = "MetaDataDetail";
            this.MetaDataDetail.SelectedIndex = 0;
            this.MetaDataDetail.Size = new System.Drawing.Size(608, 244);
            this.MetaDataDetail.TabIndex = 19;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.panel);
            this.tabMain.Location = new System.Drawing.Point(4, 23);
            this.tabMain.Name = "tabMain";
            this.tabMain.Size = new System.Drawing.Size(600, 217);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Generale";
            // 
            // tabClass
            // 
            this.tabClass.Controls.Add(this.button7);
            this.tabClass.Controls.Add(this.button6);
            this.tabClass.Controls.Add(this.button5);
            this.tabClass.Controls.Add(this.dataGrid2);
            this.tabClass.ImageIndex = 0;
            this.tabClass.Location = new System.Drawing.Point(4, 23);
            this.tabClass.Name = "tabClass";
            this.tabClass.Size = new System.Drawing.Size(600, 217);
            this.tabClass.TabIndex = 1;
            this.tabClass.Text = "Classificazione";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(184, 8);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 5;
            this.button7.Tag = "delete";
            this.button7.Text = "Cancella";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(96, 8);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 4;
            this.button6.Tag = "edit.single";
            this.button6.Text = "Correggi";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(8, 8);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 3;
            this.button5.Tag = "insert.single";
            this.button5.Text = "Aggiungi";
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(8, 32);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(584, 180);
            this.dataGrid2.TabIndex = 0;
            this.dataGrid2.Tag = "clawbacksorting.single.default";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // gboxRecupero
            // 
            this.gboxRecupero.Controls.Add(this.txtCredDeb);
            this.gboxRecupero.Location = new System.Drawing.Point(10, 103);
            this.gboxRecupero.Name = "gboxRecupero";
            this.gboxRecupero.Size = new System.Drawing.Size(557, 48);
            this.gboxRecupero.TabIndex = 4;
            this.gboxRecupero.TabStop = false;
            this.gboxRecupero.Tag = "AutoChoose.txtCredDeb.lista";
            this.gboxRecupero.Text = "Anagrafica da usare per l\'apertura del debito (opzionale)";
            // 
            // txtCredDeb
            // 
            this.txtCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCredDeb.Location = new System.Drawing.Point(6, 19);
            this.txtCredDeb.Name = "txtCredDeb";
            this.txtCredDeb.Size = new System.Drawing.Size(545, 20);
            this.txtCredDeb.TabIndex = 1;
            this.txtCredDeb.Tag = "registry.title?clawbackview.registry";
            // 
            // Frm_clawback_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(624, 529);
            this.Controls.Add(this.MetaDataDetail);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.MetaDataToolBar);
            this.Name = "Frm_clawback_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmtiporecupero";
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.MetaDataDetail.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabClass.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.gboxRecupero.ResumeLayout(false);
            this.gboxRecupero.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
	}
}
