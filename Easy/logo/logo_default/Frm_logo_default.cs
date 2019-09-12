/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
using System.IO;

namespace logo_default//logolista//
{
	/// <summary>
	/// Summary description for frmlogo.
	/// </summary>
	public class Frm_logo_default : System.Windows.Forms.Form
	{
		public /*Rana:logolista.*/vistaForm DS;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
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
		public System.Windows.Forms.Panel MetaDataDetail;
		private System.Windows.Forms.Button fileimmagine;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.DataGrid dglogo;
		private System.Windows.Forms.PictureBox pbox;
		private System.Windows.Forms.OpenFileDialog opendlg;
		private MetaData Meta;

		

		public Frm_logo_default()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Frm_logo_default));
			this.DS = new /*Rana:logolista.*/vistaForm();
			this.MetaDataDetail = new System.Windows.Forms.Panel();
			this.pbox = new System.Windows.Forms.PictureBox();
			this.fileimmagine = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
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
			this.opendlg = new System.Windows.Forms.OpenFileDialog();
			this.dglogo = new System.Windows.Forms.DataGrid();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.MetaDataDetail.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dglogo)).BeginInit();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// MetaDataDetail
			// 
			this.MetaDataDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.MetaDataDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.MetaDataDetail.Controls.Add(this.pbox);
			this.MetaDataDetail.Controls.Add(this.fileimmagine);
			this.MetaDataDetail.Controls.Add(this.label2);
			this.MetaDataDetail.Controls.Add(this.label1);
			this.MetaDataDetail.Controls.Add(this.textBox2);
			this.MetaDataDetail.Controls.Add(this.textBox1);
			this.MetaDataDetail.Location = new System.Drawing.Point(8, 168);
			this.MetaDataDetail.Name = "MetaDataDetail";
			this.MetaDataDetail.Size = new System.Drawing.Size(608, 320);
			this.MetaDataDetail.TabIndex = 1;
			// 
			// pbox
			// 
			this.pbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.pbox.Location = new System.Drawing.Point(280, 8);
			this.pbox.Name = "pbox";
			this.pbox.Size = new System.Drawing.Size(300, 300);
			this.pbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pbox.TabIndex = 6;
			this.pbox.TabStop = false;
			this.pbox.Tag = "logo.logo.logo";
			// 
			// fileimmagine
			// 
			this.fileimmagine.Location = new System.Drawing.Point(160, 40);
			this.fileimmagine.Name = "fileimmagine";
			this.fileimmagine.Size = new System.Drawing.Size(104, 23);
			this.fileimmagine.TabIndex = 4;
			this.fileimmagine.Text = "Carica il logo";
			this.fileimmagine.Click += new System.EventHandler(this.button1_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Descrizione";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "Codice logo";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(8, 88);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(264, 20);
			this.textBox2.TabIndex = 1;
			this.textBox2.Tag = "logo.description";
			this.textBox2.Text = "";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(8, 40);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(104, 20);
			this.textBox1.TabIndex = 0;
			this.textBox1.Tag = "logo.idlogo";
			this.textBox1.Text = "";
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
			this.MetaDataToolBar.Size = new System.Drawing.Size(632, 106);
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
			// opendlg
			// 
			this.opendlg.Title = "Scegli il file contenente il logo";
			// 
			// dglogo
			// 
			this.dglogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dglogo.DataMember = "";
			this.dglogo.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dglogo.Location = new System.Drawing.Point(0, 56);
			this.dglogo.Name = "dglogo";
			this.dglogo.ReadOnly = true;
			this.dglogo.Size = new System.Drawing.Size(616, 104);
			this.dglogo.TabIndex = 47;
			this.dglogo.Tag = "logo.default";
			// 
			// frmlogo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(632, 501);
			this.Controls.Add(this.dglogo);
			this.Controls.Add(this.MetaDataToolBar);
			this.Controls.Add(this.MetaDataDetail);
			this.Name = "frmlogo";
			this.Text = "frmlogo";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.MetaDataDetail.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dglogo)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public void MetaData_AfterClear()
		{//button disabilitato
			fileimmagine.Enabled = false;	

		}
		public void MetaData_AfterLink() 
		{
			Meta = MetaData.GetMetaData(this);
		}
		void FreshLogo(){
			//Meta = MetaData.GetMetaData(this);
			//pictureBox1.Image=(byte[])(DS.logo[0]["logo"]);
			DataRow Curr=HelpForm.GetLastSelected(DS.logo);
			if (Curr==null)return;

			try {
				if (Curr["logo"]!=DBNull.Value){
					MemoryStream MS = new MemoryStream((byte[])Curr["logo"]);
					Image IM = new Bitmap(MS,false);
					pbox.Image= IM;
				}
				else {
					pbox.Image=null;
				}
			}
			catch {
				pbox.Image=null;
			}
		}

		public void MetaData_AfterFill()
		{// button abilitato
			fileimmagine.Enabled = true;	
			FreshLogo();			
		}
		public void MetaData_AfterRowSelect(DataTable T, DataRow R){
			if (R==null) return;
			FreshLogo();
		}

		
		void SalvaLogo()
		{
			if (Meta.IsEmpty) return;
			if (!Meta.GetFormData(true))return;
			DialogResult dialogResult = opendlg.ShowDialog(this);
			if (dialogResult==DialogResult.Cancel) return;
			DataRow Curr=HelpForm.GetLastSelected(DS.logo);
			if (Curr==null)return;
			//txtNomeFile.Text = openFileDialog1.FileName;
			FileStream FS = new FileStream(opendlg.FileName,FileMode.Open,
				FileAccess.Read);
			
			if (FS==null) return;
			int n=(int)FS.Length; 
			if (n==0)return;
			try  {
				byte[] ByteArray = new byte[n];
				FS.Read(ByteArray,0,n);
				if (FS.Length==0){
					Curr["logo"] = DBNull.Value;
				}
				FS.Close();
				Curr["logo"] = ByteArray;
			}
			catch {}
			FreshLogo();
		//	pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);

		}


		private void button1_Click(object sender, System.EventArgs e)
		{
			// apri il open file dialog
			
			SalvaLogo();
		}
	}
}
