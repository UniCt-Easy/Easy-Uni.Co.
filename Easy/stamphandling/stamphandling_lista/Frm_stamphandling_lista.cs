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
using metaeasylibrary;
using metadatalibrary;

namespace stamphandling_lista//trattamentobollo//
{
	/// <summary>
	/// Summary description for frmtrattamentobollo.
	/// </summary>
	//Modified by Leo, 5/2/2003
	public class Frm_stamphandling_lista : System.Windows.Forms.Form
	{
		public System.Windows.Forms.Panel MetaDataDetail;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.CheckBox checkBox1;
		public vistaForm DS;
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
		private System.Windows.Forms.CheckBox chkAttivo;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox3;
        private CheckBox chkEsente;
		private CheckBox checkBox3;
		private CheckBox chkMandati;
		private System.ComponentModel.IContainer components;

		public Frm_stamphandling_lista()
		{
			InitializeComponent();
			HelpForm.SetDenyNull(DS.stamphandling.flagdefaultColumn,true);
            HelpForm.SetDenyNull(DS.stamphandling.Columns["flag"], true);
		    HelpForm.SetDenyNull(DS.stamphandling.Columns["active"], true);
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
		public void MetaData_BeforePost() {

		}
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_stamphandling_lista));
			this.MetaDataDetail = new System.Windows.Forms.Panel();
			this.chkEsente = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.chkAttivo = new System.Windows.Forms.CheckBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
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
			this.DS = new stamphandling_lista.vistaForm();
			this.chkMandati = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.MetaDataDetail.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// MetaDataDetail
			// 
			this.MetaDataDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.MetaDataDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.MetaDataDetail.Controls.Add(this.checkBox3);
			this.MetaDataDetail.Controls.Add(this.chkMandati);
			this.MetaDataDetail.Controls.Add(this.chkEsente);
			this.MetaDataDetail.Controls.Add(this.label3);
			this.MetaDataDetail.Controls.Add(this.textBox3);
			this.MetaDataDetail.Controls.Add(this.chkAttivo);
			this.MetaDataDetail.Controls.Add(this.checkBox1);
			this.MetaDataDetail.Controls.Add(this.label2);
			this.MetaDataDetail.Controls.Add(this.textBox1);
			this.MetaDataDetail.Controls.Add(this.textBox2);
			this.MetaDataDetail.Controls.Add(this.label1);
			this.MetaDataDetail.Location = new System.Drawing.Point(292, 56);
			this.MetaDataDetail.Name = "MetaDataDetail";
			this.MetaDataDetail.Size = new System.Drawing.Size(348, 287);
			this.MetaDataDetail.TabIndex = 20;
			// 
			// chkEsente
			// 
			this.chkEsente.Location = new System.Drawing.Point(8, 121);
			this.chkEsente.Name = "chkEsente";
			this.chkEsente.Size = new System.Drawing.Size(113, 16);
			this.chkEsente.TabIndex = 10;
			this.chkEsente.Tag = "stamphandling.flag:0";
			this.chkEsente.Text = "Esente";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(1, 228);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(333, 16);
			this.label3.TabIndex = 9;
			this.label3.Text = "Codice Trattamento Banca";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(3, 248);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(233, 20);
			this.textBox3.TabIndex = 5;
			this.textBox3.Tag = "stamphandling.handlingbankcode";
			// 
			// chkAttivo
			// 
			this.chkAttivo.Location = new System.Drawing.Point(8, 99);
			this.chkAttivo.Name = "chkAttivo";
			this.chkAttivo.Size = new System.Drawing.Size(55, 16);
			this.chkAttivo.TabIndex = 4;
			this.chkAttivo.Tag = "stamphandling.active:S:N";
			this.chkAttivo.Text = "Attivo";
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(8, 80);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(192, 16);
			this.checkBox1.TabIndex = 3;
			this.checkBox1.Tag = "stamphandling.flagdefault:S:N";
			this.checkBox1.Text = "Trattamento del Bollo Predefinito";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 5;
			this.label2.Text = "Descrizione:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(88, 16);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(100, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.Tag = "stamphandling.idstamphandling";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(88, 48);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(229, 20);
			this.textBox2.TabIndex = 2;
			this.textBox2.Tag = "stamphandling.description";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "Codice:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// dataGrid1
			// 
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(17, 56);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.Size = new System.Drawing.Size(269, 291);
			this.dataGrid1.TabIndex = 14;
			this.dataGrid1.Tag = "stamphandling.default";
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
			this.MetaDataToolBar.Size = new System.Drawing.Size(650, 106);
			this.MetaDataToolBar.TabIndex = 70;
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
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// chkMandati
			// 
			this.chkMandati.Location = new System.Drawing.Point(8, 143);
			this.chkMandati.Name = "chkMandati";
			this.chkMandati.Size = new System.Drawing.Size(113, 16);
			this.chkMandati.TabIndex = 11;
			this.chkMandati.Tag = "stamphandling.flag:1";
			this.chkMandati.Text = "Mandati";
			// 
			// checkBox3
			// 
			this.checkBox3.Location = new System.Drawing.Point(8, 165);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(113, 16);
			this.checkBox3.TabIndex = 12;
			this.checkBox3.Tag = "stamphandling.flag:2";
			this.checkBox3.Text = "Reversali";
			// 
			// Frm_stamphandling_lista
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(650, 355);
			this.Controls.Add(this.MetaDataDetail);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.MetaDataToolBar);
			this.Name = "Frm_stamphandling_lista";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.MetaDataDetail.ResumeLayout(false);
			this.MetaDataDetail.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}
