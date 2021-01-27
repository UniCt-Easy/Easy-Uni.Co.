
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
using metaeasylibrary;
using System.Text;
using System.Data;
using System.Security.Cryptography;

namespace dbdepartment_config
{
	/// <summary>
	/// Summary description for Frm_department_config.
	/// </summary>
	public class Frm_department_config : System.Windows.Forms.Form {
		private Easy_DataAccess mainConn;
		private MetaData Meta;
		private System.Windows.Forms.DataGrid gridDipartimenti;
		public System.Windows.Forms.GroupBox MetaDataDetail;
		private System.Windows.Forms.Label label1;
		public vistaForm DS;
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
		private System.Windows.Forms.TextBox txtNomeDipartimento;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.Button btnPassword;
		private System.Windows.Forms.TextBox textBox1;
		private System.ComponentModel.IContainer components;

		public Frm_department_config() {
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Frm_department_config));
			this.gridDipartimenti = new System.Windows.Forms.DataGrid();
			this.MetaDataDetail = new System.Windows.Forms.GroupBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.btnPassword = new System.Windows.Forms.Button();
			this.txtDescrizione = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtNomeDipartimento = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.DS = new dbdepartment_config.vistaForm();
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
			((System.ComponentModel.ISupportInitialize)(this.gridDipartimenti)).BeginInit();
			this.MetaDataDetail.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// gridDipartimenti
			// 
			this.gridDipartimenti.AllowNavigation = false;
			this.gridDipartimenti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gridDipartimenti.DataMember = "";
			this.gridDipartimenti.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridDipartimenti.Location = new System.Drawing.Point(8, 56);
			this.gridDipartimenti.Name = "gridDipartimenti";
			this.gridDipartimenti.Size = new System.Drawing.Size(744, 256);
			this.gridDipartimenti.TabIndex = 0;
			this.gridDipartimenti.Tag = "dbdepartment.default";
			// 
			// MetaDataDetail
			// 
			this.MetaDataDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.MetaDataDetail.Controls.Add(this.textBox1);
			this.MetaDataDetail.Controls.Add(this.btnPassword);
			this.MetaDataDetail.Controls.Add(this.txtDescrizione);
			this.MetaDataDetail.Controls.Add(this.label4);
			this.MetaDataDetail.Controls.Add(this.txtNomeDipartimento);
			this.MetaDataDetail.Controls.Add(this.label1);
			this.MetaDataDetail.Location = new System.Drawing.Point(8, 328);
			this.MetaDataDetail.Name = "MetaDataDetail";
			this.MetaDataDetail.Size = new System.Drawing.Size(744, 80);
			this.MetaDataDetail.TabIndex = 1;
			this.MetaDataDetail.TabStop = false;
			this.MetaDataDetail.Text = "Dettagli del dipartimento";
			// 
			// textBox1
			// 
			this.textBox1.Enabled = false;
			this.textBox1.Location = new System.Drawing.Point(488, 32);
			this.textBox1.Name = "textBox1";
			this.textBox1.TabIndex = 9;
			this.textBox1.Text = "textBox1";
			// 
			// btnPassword
			// 
			this.btnPassword.Location = new System.Drawing.Point(600, 32);
			this.btnPassword.Name = "btnPassword";
			this.btnPassword.Size = new System.Drawing.Size(120, 23);
			this.btnPassword.TabIndex = 8;
			this.btnPassword.Text = "Inserisci password";
			this.btnPassword.Click += new System.EventHandler(this.btnPassword_Click);
			// 
			// txtDescrizione
			// 
			this.txtDescrizione.Location = new System.Drawing.Point(72, 48);
			this.txtDescrizione.Name = "txtDescrizione";
			this.txtDescrizione.Size = new System.Drawing.Size(392, 20);
			this.txtDescrizione.TabIndex = 7;
			this.txtDescrizione.Tag = "dbdepartment.description";
			this.txtDescrizione.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 48);
			this.label4.Name = "label4";
			this.label4.TabIndex = 6;
			this.label4.Text = "Descrizione";
			// 
			// txtNomeDipartimento
			// 
			this.txtNomeDipartimento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtNomeDipartimento.Location = new System.Drawing.Point(72, 16);
			this.txtNomeDipartimento.Name = "txtNomeDipartimento";
			this.txtNomeDipartimento.Size = new System.Drawing.Size(392, 20);
			this.txtNomeDipartimento.TabIndex = 1;
			this.txtNomeDipartimento.Tag = "dbdepartment.iddbdepartment";
			this.txtNomeDipartimento.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Nome";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
			this.MetaDataToolBar.Size = new System.Drawing.Size(760, 56);
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
			// Frm_department_config
			// 
			this.AcceptButton = this.btnPassword;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(760, 414);
			this.Controls.Add(this.MetaDataToolBar);
			this.Controls.Add(this.MetaDataDetail);
			this.Controls.Add(this.gridDipartimenti);
			this.Name = "Frm_department_config";
			this.Text = "Frm_department_config";
			((System.ComponentModel.ISupportInitialize)(this.gridDipartimenti)).EndInit();
			this.MetaDataDetail.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
			mainConn = (Easy_DataAccess) Meta.Conn;
			invitaACorreggerePasswordDeiDipartimenti();
		}

		private void invitaACorreggerePasswordDeiDipartimenti() {
			string userAmmin = (string) Meta.Conn.GetSys("user");
			string filtroUtente = "(login=" + QueryCreator.quotedstrvalue(userAmmin, true) + ")";
			DataTable t = DataAccess.RUN_SELECT(mainConn, "dbaccess", null, null, filtroUtente, null, null, true);
			string dipErrati = "";
			foreach (DataRow r in t.Rows) {
				string iddbdepartment = (string) r["iddbdepartment"];
				string errore;
				Easy_DataAccess eda = mainConn.getDepartmentConnection(iddbdepartment, out errore);
				if (errore != null) {
					dipErrati += ", " + iddbdepartment;
				}
			}
			if (dipErrati != "") {
				Console.WriteLine("Password errate nei dipartimenti " + dipErrati.Substring(2));
			}
		}

		public void MetaData_AfterRowSelect(DataTable T, DataRow rDepartment) {
			if (rDepartment["!password"] is DBNull) {
				string userAmmin = (string) Meta.Conn.GetSys("user");
				byte[] alfa = mainConn.sha256UserPassword();
				string filtroAmmin = "(login=" 
					+ QueryCreator.quotedstrvalue(userAmmin, true)
					+ ") and (iddbdepartment="
					+ QueryCreator.quotedstrvalue(rDepartment["iddbdepartment"], true)
					+ ")";
				object o = Meta.Conn.DO_READ_VALUE("dbaccess", filtroAmmin, "alpha1");
				if (o != null) {
					byte[] alfa1 = QueryCreator.StringToByteArray((string)o);
					byte[] up = xor(alfa, alfa1);
					try {
						rDepartment["!password"] = DataAccess.DecryptString(up);
					} catch (CryptographicException) {
					}
				}
			}
			btnPassword.Text = (rDepartment["!password"] is DBNull)
				? "Inserisci password"
				: "Modifica password";
		}

		private byte[] xor(byte[] a, byte[] b) {
			BitArray orEsclusivo = new BitArray(a).Xor(new BitArray(b));
			byte[] result = new byte[32];
			orEsclusivo.CopyTo(result, 0);
			return result;
		}

		private void btnPassword_Click(object sender, System.EventArgs e) {
			DataRow rDep = HelpForm.GetLastSelected(DS.dbdepartment);
			string idDbDepartment = (string) rDep["iddbdepartment"];
			FrmPassword frmPassword = new FrmPassword(mainConn, idDbDepartment);
			DialogResult dr = frmPassword.ShowDialog(this);
			if (dr == DialogResult.OK) {
				DataRow rDepartment = HelpForm.GetLastSelected(DS.dbdepartment);
				rDepartment["!password"] = frmPassword.txtPassword.Text;
			}
		}

//		private string getNuovoAlfa1(string passwordDipart) {
//			byte[] alfa = mainConn.sha256UserPassword();
//			byte[] g1 = DataAccess.CryptString(passwordDipart.PadRight(31));
//			byte[] alfa1 = xor(alfa, g1);
//			return QueryCreator.ByteArrayToString(alfa1);
//		}

		public void MetaData_BeforePost() {
			DataRow rDepartment = HelpForm.GetLastSelected(DS.dbdepartment);
			if (rDepartment == null) {
				return;
			}
			string passwordDipart = rDepartment["!password"] as string;
			textBox1.Text = passwordDipart;

			string userAmmin = (string) Meta.Conn.GetSys("user");
			MetaData metaDBAccess = MetaData.GetMetaData(this, "dbaccess");
			MetaData metaDBUser = MetaData.GetMetaData(this, "dbuser");
			UTF8Encoding encoding = new UTF8Encoding();

			string filtroUtente = "(login=" + QueryCreator.quotedstrvalue(userAmmin, true) + ")";
			DataTable tUtenti = DataAccess.RUN_SELECT(mainConn,"dbuser", null, null, filtroUtente, null, null, true);
			DataRow[] rUtenti = tUtenti.Select(filtroUtente);
			if (rUtenti.Length == 0) {
				MetaData.SetDefault(DS.dbuser, "login", userAmmin);
				metaDBUser.Get_New_Row(null, DS.dbuser);
			}

			string filtroAccesso = filtroUtente + " and (iddbdepartment="
				+ QueryCreator.quotedstrvalue(rDepartment["iddbdepartment"], true) + ")";
			DataAccess.RUN_SELECT_INTO_TABLE(mainConn, DS.dbaccess, null, filtroAccesso, null, true);
			MetaData.SetDefault(DS.dbaccess, "login", userAmmin);

			string iddbdepartment = (string) rDepartment["iddbdepartment"];
			string errore;
			byte[] g1 = mainConn.getDepartmentPassword(iddbdepartment, out errore);
			if (g1==null) {
				metaDBAccess.Get_New_Row(rDepartment, DS.dbaccess);
				g1 = Easy_DataAccess.CryptString(passwordDipart.PadRight(31));
			}
			DataRow[] righeAccesso = rDepartment.GetChildRows("dbdepartmentdbaccess");
			foreach (DataRow rAccess in righeAccesso) {
				byte[] alfa = mainConn.sha256UserPassword();
				byte[] alfa1 = xor(alfa, g1);
				rAccess["alpha1"] = QueryCreator.ByteArrayToString(alfa1);
			}
		}
	}
}
