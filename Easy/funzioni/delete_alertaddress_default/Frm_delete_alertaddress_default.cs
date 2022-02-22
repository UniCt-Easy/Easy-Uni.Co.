
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
using System.Data;
using metadatalibrary;

namespace delete_alertaddress_default//alertaddress//
{
	/// <summary>
	/// Summary description for FormAlertAddress.
	/// </summary>
	public class Frm_delete_alertaddress_default : System.Windows.Forms.Form
	{
		private MetaData meta;
		public /*Rana:alertaddress.*/vistaForm DS;

		private System.Windows.Forms.Label labelNome;
		private System.Windows.Forms.Label label1;
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
		private System.Windows.Forms.ToolBarButton btnGotoPrev;
		private System.Windows.Forms.ToolBarButton btnGotoNext;
		private System.Windows.Forms.ToolBarButton btnAffianca;
		private System.Windows.Forms.ToolBarButton btnEditNotes;
		public System.Windows.Forms.Panel MetaDataDetail;
		private System.Windows.Forms.DataGrid dataGridDestinatari;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox textBoxCorpo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxOggetto;
		private System.Windows.Forms.Button buttonTest;
		private System.Windows.Forms.Label labelCorpo;
		private System.Windows.Forms.TextBox textBoxNome;
		private System.Windows.Forms.TextBox textBoxIndirizzo;
		private System.ComponentModel.IContainer components;

		public Frm_delete_alertaddress_default()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormAlertAddress));
			this.dataGridDestinatari = new System.Windows.Forms.DataGrid();
			this.DS = new /*Rana:alertaddress.*/vistaForm();
			this.labelNome = new System.Windows.Forms.Label();
			this.textBoxNome = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxIndirizzo = new System.Windows.Forms.TextBox();
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
			this.MetaDataDetail = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.labelCorpo = new System.Windows.Forms.Label();
			this.textBoxCorpo = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxOggetto = new System.Windows.Forms.TextBox();
			this.buttonTest = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridDestinatari)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.MetaDataDetail.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataGridDestinatari
			// 
			this.dataGridDestinatari.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridDestinatari.DataMember = "";
			this.dataGridDestinatari.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridDestinatari.Location = new System.Drawing.Point(8, 56);
			this.dataGridDestinatari.Name = "dataGridDestinatari";
			this.dataGridDestinatari.Size = new System.Drawing.Size(584, 184);
			this.dataGridDestinatari.TabIndex = 0;
			this.dataGridDestinatari.Tag = "delete_alertaddress.default";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// labelNome
			// 
			this.labelNome.Location = new System.Drawing.Point(8, 8);
			this.labelNome.Name = "labelNome";
			this.labelNome.Size = new System.Drawing.Size(99, 23);
			this.labelNome.TabIndex = 1;
			this.labelNome.Text = "Nome destinatario:";
			this.labelNome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxNome
			// 
			this.textBoxNome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxNome.Location = new System.Drawing.Point(96, 8);
			this.textBoxNome.Name = "textBoxNome";
			this.textBoxNome.Size = new System.Drawing.Size(472, 20);
			this.textBoxNome.TabIndex = 2;
			this.textBoxNome.Tag = "delete_alertaddress.delete_name";
			this.textBoxNome.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(84, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "Indirizzo e-mail:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxIndirizzo
			// 
			this.textBoxIndirizzo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxIndirizzo.Location = new System.Drawing.Point(96, 32);
			this.textBoxIndirizzo.Name = "textBoxIndirizzo";
			this.textBoxIndirizzo.Size = new System.Drawing.Size(472, 20);
			this.textBoxIndirizzo.TabIndex = 4;
			this.textBoxIndirizzo.Tag = "delete_alertaddress.delete_mapiaddress";
			this.textBoxIndirizzo.Text = "";
			// 
			// images
			// 
			this.images.ImageSize = new System.Drawing.Size(32, 32);
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
			this.MetaDataToolBar.Size = new System.Drawing.Size(600, 110);
			this.MetaDataToolBar.TabIndex = 5;
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
			// MetaDataDetail
			// 
			this.MetaDataDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.MetaDataDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.MetaDataDetail.Controls.Add(this.textBoxNome);
			this.MetaDataDetail.Controls.Add(this.labelNome);
			this.MetaDataDetail.Controls.Add(this.textBoxIndirizzo);
			this.MetaDataDetail.Controls.Add(this.label1);
			this.MetaDataDetail.Location = new System.Drawing.Point(8, 248);
			this.MetaDataDetail.Name = "MetaDataDetail";
			this.MetaDataDetail.Size = new System.Drawing.Size(584, 64);
			this.MetaDataDetail.TabIndex = 6;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.labelCorpo);
			this.panel1.Controls.Add(this.textBoxCorpo);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.textBoxOggetto);
			this.panel1.Controls.Add(this.buttonTest);
			this.panel1.Location = new System.Drawing.Point(8, 320);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(584, 112);
			this.panel1.TabIndex = 7;
			// 
			// labelCorpo
			// 
			this.labelCorpo.Location = new System.Drawing.Point(8, 48);
			this.labelCorpo.Name = "labelCorpo";
			this.labelCorpo.Size = new System.Drawing.Size(40, 23);
			this.labelCorpo.TabIndex = 8;
			this.labelCorpo.Text = "Corpo:";
			// 
			// textBoxCorpo
			// 
			this.textBoxCorpo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxCorpo.Location = new System.Drawing.Point(56, 36);
			this.textBoxCorpo.Multiline = true;
			this.textBoxCorpo.Name = "textBoxCorpo";
			this.textBoxCorpo.Size = new System.Drawing.Size(388, 64);
			this.textBoxCorpo.TabIndex = 7;
			this.textBoxCorpo.Text = "Questa e-mail fa parte di un test di invio della nostra posta elettronica; si pre" +
				"ga di ignorarla.";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 23);
			this.label2.TabIndex = 6;
			this.label2.Text = "Oggetto:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxOggetto
			// 
			this.textBoxOggetto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxOggetto.Location = new System.Drawing.Point(56, 8);
			this.textBoxOggetto.Name = "textBoxOggetto";
			this.textBoxOggetto.Size = new System.Drawing.Size(516, 20);
			this.textBoxOggetto.TabIndex = 5;
			this.textBoxOggetto.Text = "E-mail di prova";
			// 
			// buttonTest
			// 
			this.buttonTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonTest.Location = new System.Drawing.Point(452, 56);
			this.buttonTest.Name = "buttonTest";
			this.buttonTest.Size = new System.Drawing.Size(123, 23);
			this.buttonTest.TabIndex = 4;
			this.buttonTest.Text = "Invio e-mail di prova...";
			this.buttonTest.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
			// 
			// FormAlertAddress
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(600, 438);
			this.Controls.Add(this.dataGridDestinatari);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.MetaDataDetail);
			this.Controls.Add(this.MetaDataToolBar);
			this.Name = "FormAlertAddress";
			this.Text = "FormAlertAddress";
			((System.ComponentModel.ISupportInitialize)(this.dataGridDestinatari)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.MetaDataDetail.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public void MetaData_AfterLink() 
		{
			meta = MetaData.GetMetaData(this);
		}

		private string getIndirizzoCompleto(string nome, string email) 
		{
			string indirizzo;
			if (nome != "") 
			{
				indirizzo = '"' + nome + "\" ";
				if (email != "") 
				{
					indirizzo += "<" + email + ">";
				}
			} 
			else 
			{
				indirizzo = email;
			}
			return indirizzo;
		}

		private void buttonTest_Click(object sender, System.EventArgs e)
		{
			DataAccess.RUN_SELECT_INTO_TABLE(meta.Conn,DS.mailsetup, null, null, null, true);
			string lastError = meta.Conn.LastError;
			if (lastError != "")
			{
				MessageBox.Show(this, lastError, "Errore di configurazione nell'account del mittente");
				return;
			}
			if (DS.mailsetup.Rows.Count < 1) 
			{
				MessageBox.Show(this, "Account di posta elettronica inesistente. E' necessario impostare il server smtp e l'indirizzo del mittente." ,
					"Errore di configurazione nell'account del mittente");
				return;
			}
			string smtp = DS.mailsetup.Rows[0]["smtp"].ToString();
			string mittente = getIndirizzoCompleto(DS.mailsetup.Rows[0]["title"].ToString(),DS.mailsetup.Rows[0]["email"].ToString());
			string destinatario = getIndirizzoCompleto(textBoxNome.Text, textBoxIndirizzo.Text);

			object[] parametri = new object[] {smtp, mittente, destinatario, textBoxOggetto.Text, textBoxCorpo.Text};
			string errore;
			DataSet result = meta.Conn.CallSP("send_cdosysmail", parametri, 0, out errore);
			if ((result != null) && (result.Tables.Count > 0) && (result.Tables[0].Rows.Count > 0))
			{
				errore += "\n" + result.Tables[0].Rows[0]["description"];
			}
			if (errore != null) 
			{
				MessageBox.Show(this, errore, "Invio e-mail fallito");
			} 
			else 
			{
				MessageBox.Show(this, "Prova riuscita!", "E-mail inviata correttamente");
			}
		}
	}
}
