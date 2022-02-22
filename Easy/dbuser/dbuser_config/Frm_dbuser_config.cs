
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
using metadatalibrary;
using System.Data;
using metaeasylibrary;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace dbuser_config {
	/// <summary>
	/// Summary description for Frm_administrator.
	/// </summary>
	public class Frm_dbuser_config : System.Windows.Forms.Form {
		private MetaData Meta;
		private Easy_DataAccess dataAccess;
		private System.Windows.Forms.DataGrid gridUtenti;
		private System.Windows.Forms.ListView listDipartimenti;
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
		private System.Windows.Forms.TextBox txtLogin;
		private System.Windows.Forms.Label label1;
		public dbuser_config.vistaForm DS;
		public System.Windows.Forms.GroupBox MetaDataDetail;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
		private System.ComponentModel.IContainer components;

		public Frm_dbuser_config() {
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
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if(components != null) {
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
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Frm_dbuser_config));
			this.gridUtenti = new System.Windows.Forms.DataGrid();
			this.listDipartimenti = new System.Windows.Forms.ListView();
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
			this.txtLogin = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.DS = new dbuser_config.vistaForm();
			this.MetaDataDetail = new System.Windows.Forms.GroupBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.gridUtenti)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.MetaDataDetail.SuspendLayout();
			this.SuspendLayout();
			// 
			// gridUtenti
			// 
			this.gridUtenti.AllowNavigation = false;
			this.gridUtenti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gridUtenti.DataMember = "";
			this.gridUtenti.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridUtenti.Location = new System.Drawing.Point(8, 56);
			this.gridUtenti.Name = "gridUtenti";
			this.gridUtenti.Size = new System.Drawing.Size(376, 304);
			this.gridUtenti.TabIndex = 0;
			this.gridUtenti.Tag = "dbuser";
			// 
			// listDipartimenti
			// 
			this.listDipartimenti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.listDipartimenti.Location = new System.Drawing.Point(392, 56);
			this.listDipartimenti.Name = "listDipartimenti";
			this.listDipartimenti.Size = new System.Drawing.Size(376, 248);
			this.listDipartimenti.TabIndex = 1;
			this.listDipartimenti.Tag = "dbdepartment";
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
			this.MetaDataToolBar.Size = new System.Drawing.Size(776, 56);
			this.MetaDataToolBar.TabIndex = 74;
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
			// txtLogin
			// 
			this.txtLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtLogin.Location = new System.Drawing.Point(80, 16);
			this.txtLogin.Name = "txtLogin";
			this.txtLogin.Size = new System.Drawing.Size(224, 20);
			this.txtLogin.TabIndex = 75;
			this.txtLogin.Tag = "dbuser.login";
			this.txtLogin.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 20);
			this.label1.TabIndex = 76;
			this.label1.Text = "Login utente";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// MetaDataDetail
			// 
			this.MetaDataDetail.Controls.Add(this.txtLogin);
			this.MetaDataDetail.Controls.Add(this.label1);
			this.MetaDataDetail.Location = new System.Drawing.Point(8, 368);
			this.MetaDataDetail.Name = "MetaDataDetail";
			this.MetaDataDetail.Size = new System.Drawing.Size(312, 48);
			this.MetaDataDetail.TabIndex = 84;
			this.MetaDataDetail.TabStop = false;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(392, 304);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(376, 104);
			this.textBox1.TabIndex = 85;
			this.textBox1.Text = "textBox1";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(328, 376);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(56, 40);
			this.button1.TabIndex = 86;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Frm_dbuser_config
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(776, 422);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.MetaDataDetail);
			this.Controls.Add(this.MetaDataToolBar);
			this.Controls.Add(this.listDipartimenti);
			this.Controls.Add(this.gridUtenti);
			this.Name = "Frm_dbuser_config";
			this.Text = "Configurazione utenti del DB";
			((System.ComponentModel.ISupportInitialize)(this.gridUtenti)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.MetaDataDetail.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
			string login = (string) Meta.Conn.GetSys("user");

//			GetData.SetStaticFilter(DS.dbaccess, "(login="+QueryCreator.quotedstrvalue(login, true)+")");
//			GetData.CacheTable(DS.dbdepartment, null, "description", false);

			dataAccess = (Easy_DataAccess) Meta.Conn;
			bool isAdmin = (bool) Meta.GetSys("IsSystemAdmin");

//						getPasswordDeiDipartimenti();
			//			Meta.CanSave=IsAdmin;
			//			Meta.CanInsert=IsAdmin;
			//			Meta.CanInsertCopy=IsAdmin;
			//			Meta.CanCancel=IsAdmin;			
		}

		public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
			if (R != null) {
				string user = (string) Meta.Conn.GetSys("user");
				string login = (string) R["login"];
				bool abilita = user != login;
				listDipartimenti.Enabled = abilita;
			}
		}

		public void MetaData_AfterGetFormData() { 
			string filtroAmmin = "(login=" + QueryCreator.quotedstrvalue(Meta.Conn.GetSys("user"), false) + ")";
			DataTable tDipAmmin = DataAccess.RUN_SELECT(Meta.Conn, "dbaccess", null, null, filtroAmmin, null, null, true);
			DataRow[] righeAggiunte = DS.dbaccess.Select(null, null, DataViewRowState.Added);
			foreach (DataRow r in righeAggiunte) {
				string filtroDip = "(iddbdepartment=" + QueryCreator.quotedstrvalue(r["iddbdepartment"], false) + ")";
				DataRow[] rAmm = tDipAmmin.Select(filtroDip);
				if (rAmm.Length == 0) {
					MessageBox.Show(this, "Non si dispone dei diritti di amministratore sul dipartimento '" + r["iddbdepartment"] + "'");
					r.RejectChanges();
				}
			}
			UTF8Encoding encoding = new UTF8Encoding();
			SHA256 shaM = new SHA256Managed();
			righeAggiunte = DS.dbaccess.Select(null, null, DataViewRowState.Added);
			foreach (DataRow rAccess in righeAggiunte) {
//				DataRow rDepartment = rAccess.GetParentRow("dbdepartmentdbaccess");
//				DataRow rUser = rAccess.GetParentRow("dbuserdbaccess");
//				string passwordDip = leggiPasswordDelDipCambiata(tDipAmmin, rDepartment["iddbdepartment"]);
//				if (!Easy_DataAccess.checkPasswordSyntax(passwordDip)) {
//					passwordDip = leggiPasswordDelDipIniziale(tDipAmmin, rDepartment["iddbdepartment"]);
//				}
//				byte[] g1 = DataAccess.CryptString(passwordDip.PadRight(31));
				byte[] initialPassword = encoding.GetBytes(Easy_DataAccess.INITIAL_PASSWORD);
				byte[] alfa = shaM.ComputeHash(initialPassword);
				string errore;
				byte[] g1 = dataAccess.getDepartmentPassword((string)rAccess["iddbdepartment"], out errore);
				byte[] nuovoAlfa1 = xor(alfa, g1);
				rAccess["alpha1"] = QueryCreator.ByteArrayToString(nuovoAlfa1);
			}
		}


		private byte[] xor(byte[] a, byte[] b) {
			BitArray orEsclusivo = new BitArray(a).Xor(new BitArray(b));
			byte[] result = new byte[32];
			orEsclusivo.CopyTo(result, 0);
			return result;
		}


//		private string leggiPasswordDelDipIniziale(DataTable tDipAmmin, object iddbdepartment) {
//			string filtroDip = "(iddbdepartment=" + QueryCreator.quotedstrvalue(iddbdepartment, false) + ")";
//			DataRow rAccess = tDipAmmin.Select(filtroDip)[0];
//			byte[] alfa1 = QueryCreator.StringToByteArray((string)rAccess["alpha1"]);
//
//			UTF8Encoding encoding = new UTF8Encoding();
//			SHA256 shaM = new SHA256Managed();
//			byte[] initialPassword = encoding.GetBytes(Easy_DataAccess.INITIAL_PASSWORD);
//			byte[] alfa = shaM.ComputeHash(initialPassword);
//			byte[] up = xor(alfa, alfa1);
//			return DataAccess.DecryptString(up);
//		}
//
//		private string leggiPasswordDelDipCambiata(DataTable tDipAmmin, object iddbdepartment) {
//			string filtroDip = "(iddbdepartment=" + QueryCreator.quotedstrvalue(iddbdepartment, false) + ")";
//			DataRow rAccess = tDipAmmin.Select(filtroDip)[0];
//			string sAlfa1 = (string) rAccess["alpha1"];
//			byte[] alfa1 = QueryCreator.StringToByteArray(sAlfa1);
//
//			byte[] alfa = dataAccess.sha256UserPassword();
//			byte[] up = xor(alfa, alfa1);
//			try {
//				return DataAccess.DecryptString(up);
//			} catch (CryptographicException) {
//				return null;
//			}
//		}
//
		private void button1_Click(object sender, System.EventArgs e) {
			DataTable t = Meta.Conn.RUN_SELECT("tabelle", null, null, null, null, null, false);
			DataSet ds = new DataSet();
			ds.Tables.Add(t);
			ds.WriteXml("c:/tabelle.xml");
			string filtroAmmin = "(login=" + QueryCreator.quotedstrvalue(Meta.Conn.GetSys("user"), false) + ")";
			DataTable tDipAmmin = DataAccess.RUN_SELECT(Meta.Conn, "dbaccess", null, null, filtroAmmin, null, null, true);
			textBox1.Text = null;
			foreach (DataRow rDepartment in tDipAmmin.Rows) {
				string iddbdepartment = (string) rDepartment["iddbdepartment"];
				string errore;
				string passwordDip = Easy_DataAccess.DecryptString(dataAccess.getDepartmentPassword(iddbdepartment, out errore));
				textBox1.Text += rDepartment["iddbdepartment"] + ": " + passwordDip + "\r\n";
			}
		}
	}
}
