
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
using download;//download
using utility;//utility
using metadatalibrary;
using System.Data;
using System.IO;
using System.Text;

namespace ondemand_default//ondemand//
{
	/// <summary>
	/// Summary description for frmondemand.
	/// </summary>
	public class Frm_ondemand_default : MetaDataForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private string webdir="ondemand/";
		private Http http=null;
		private string[] siti = null;
		private const string C_REMOTEINDEX_XML="remoteondemandindex.xml";
		private const string C_REMOTEINDEX_ZIP="remoteondemandindex.zip";
		private const string C_LOCALINDEX_XML="localondemandindex.xml";
		private string dir_App="";
		private string dir_Zip="";
		private System.Windows.Forms.TabControl Tab;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.ListView listFull;
		//indice delle installazioni client
		private /*Rana:ondemand.*/vistaindex DSclient;
		//indice presente sul sito web
		private DataSet DSremote;
		//indice delle installazioni server
		public /*Rana:ondemand.*/vistaForm DS;
		private System.Windows.Forms.ListView listNew;
		private System.Windows.Forms.ListView listOld;
		private System.Windows.Forms.TextBox txtDescNew;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtDescOld;
		private System.Windows.Forms.TextBox txtDescFull;
		//indice, ricostruito (tra server e client), delle installazioni locali
		private vistaindex DSlocal;
		//hashtable per ordinamento colonne
		private Hashtable hashNew=new Hashtable();
		private Hashtable hashOld=new Hashtable();
		private System.Windows.Forms.Button btnUncheckAll;
		private System.Windows.Forms.Button btnCheckAll;
		private System.Windows.Forms.Button btnUncheckSelect;
		private System.Windows.Forms.Button btnCheckSelect;
		private Hashtable hashFull=new Hashtable();
		private System.Windows.Forms.Button btnEsegui;
		private string ReportDir;
		private MetaData Meta;
		private DataAccess ConnClone;

		public Frm_ondemand_default() {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			dir_App=AppDomain.CurrentDomain.BaseDirectory+@"\";
			dir_Zip=dir_App+@"zip\";
			//Carico il file presente sul client
			if (!File.Exists(dir_App+C_LOCALINDEX_XML)) DSclient.WriteXml(dir_App+C_LOCALINDEX_XML);
			DSclient.ReadXml(dir_App+C_LOCALINDEX_XML);
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
			this.DS = new ondemand_default.vistaForm();
			this.DSclient = new ondemand_default.vistaindex();
			this.Tab = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.btnUncheckSelect = new System.Windows.Forms.Button();
			this.btnCheckSelect = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtDescNew = new System.Windows.Forms.TextBox();
			this.btnEsegui = new System.Windows.Forms.Button();
			this.btnUncheckAll = new System.Windows.Forms.Button();
			this.btnCheckAll = new System.Windows.Forms.Button();
			this.listNew = new System.Windows.Forms.ListView();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.label2 = new System.Windows.Forms.Label();
			this.txtDescOld = new System.Windows.Forms.TextBox();
			this.listOld = new System.Windows.Forms.ListView();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.label3 = new System.Windows.Forms.Label();
			this.txtDescFull = new System.Windows.Forms.TextBox();
			this.listFull = new System.Windows.Forms.ListView();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DSclient)).BeginInit();
			this.Tab.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// DSclient
			// 
			this.DSclient.DataSetName = "vistaindex1";
			this.DSclient.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// Tab
			// 
			this.Tab.Controls.Add(this.tabPage1);
			this.Tab.Controls.Add(this.tabPage2);
			this.Tab.Controls.Add(this.tabPage3);
			this.Tab.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Tab.Location = new System.Drawing.Point(0, 0);
			this.Tab.Name = "Tab";
			this.Tab.SelectedIndex = 0;
			this.Tab.Size = new System.Drawing.Size(688, 454);
			this.Tab.TabIndex = 1;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.btnUncheckSelect);
			this.tabPage1.Controls.Add(this.btnCheckSelect);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.txtDescNew);
			this.tabPage1.Controls.Add(this.btnEsegui);
			this.tabPage1.Controls.Add(this.btnUncheckAll);
			this.tabPage1.Controls.Add(this.btnCheckAll);
			this.tabPage1.Controls.Add(this.listNew);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(680, 428);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Nuovi aggiornamenti";
			// 
			// btnUncheckSelect
			// 
			this.btnUncheckSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnUncheckSelect.Location = new System.Drawing.Point(552, 152);
			this.btnUncheckSelect.Name = "btnUncheckSelect";
			this.btnUncheckSelect.Size = new System.Drawing.Size(112, 23);
			this.btnUncheckSelect.TabIndex = 9;
			this.btnUncheckSelect.Text = "Disattiva selezione";
			this.btnUncheckSelect.Click += new System.EventHandler(this.btnUncheckSelect_Click);
			// 
			// btnCheckSelect
			// 
			this.btnCheckSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCheckSelect.Location = new System.Drawing.Point(552, 120);
			this.btnCheckSelect.Name = "btnCheckSelect";
			this.btnCheckSelect.Size = new System.Drawing.Size(112, 23);
			this.btnCheckSelect.TabIndex = 8;
			this.btnCheckSelect.Text = "Attiva selezione";
			this.btnCheckSelect.Click += new System.EventHandler(this.btnCheckSelect_Click);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.Location = new System.Drawing.Point(8, 304);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 16);
			this.label1.TabIndex = 7;
			this.label1.Text = "Descrizione aggiornamento";
			// 
			// txtDescNew
			// 
			this.txtDescNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescNew.Location = new System.Drawing.Point(8, 328);
			this.txtDescNew.Multiline = true;
			this.txtDescNew.Name = "txtDescNew";
			this.txtDescNew.ReadOnly = true;
			this.txtDescNew.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDescNew.Size = new System.Drawing.Size(528, 88);
			this.txtDescNew.TabIndex = 6;
			// 
			// btnEsegui
			// 
			this.btnEsegui.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEsegui.Location = new System.Drawing.Point(552, 224);
			this.btnEsegui.Name = "btnEsegui";
			this.btnEsegui.Size = new System.Drawing.Size(112, 40);
			this.btnEsegui.TabIndex = 5;
			this.btnEsegui.Text = "Installa aggiornamenti";
			this.btnEsegui.Click += new System.EventHandler(this.btnEsegui_Click);
			// 
			// btnUncheckAll
			// 
			this.btnUncheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnUncheckAll.Location = new System.Drawing.Point(552, 64);
			this.btnUncheckAll.Name = "btnUncheckAll";
			this.btnUncheckAll.Size = new System.Drawing.Size(112, 23);
			this.btnUncheckAll.TabIndex = 4;
			this.btnUncheckAll.Text = "Disattiva tutto";
			this.btnUncheckAll.Click += new System.EventHandler(this.btnUncheckAll_Click);
			// 
			// btnCheckAll
			// 
			this.btnCheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCheckAll.Location = new System.Drawing.Point(552, 32);
			this.btnCheckAll.Name = "btnCheckAll";
			this.btnCheckAll.Size = new System.Drawing.Size(112, 23);
			this.btnCheckAll.TabIndex = 3;
			this.btnCheckAll.Text = "Attiva tutto";
			this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
			// 
			// listNew
			// 
			this.listNew.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listNew.HideSelection = false;
			this.listNew.Location = new System.Drawing.Point(8, 8);
			this.listNew.Name = "listNew";
			this.listNew.Size = new System.Drawing.Size(528, 288);
			this.listNew.TabIndex = 2;
			this.listNew.UseCompatibleStateImageBehavior = false;
			this.listNew.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ColumnClick);
			this.listNew.Click += new System.EventHandler(this.VisualizzaDescrizione);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.label2);
			this.tabPage2.Controls.Add(this.txtDescOld);
			this.tabPage2.Controls.Add(this.listOld);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(680, 428);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Aggiornamenti installati";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.Location = new System.Drawing.Point(8, 304);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(144, 16);
			this.label2.TabIndex = 8;
			this.label2.Text = "Descrizione aggiornamento";
			// 
			// txtDescOld
			// 
			this.txtDescOld.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescOld.Location = new System.Drawing.Point(8, 328);
			this.txtDescOld.Multiline = true;
			this.txtDescOld.Name = "txtDescOld";
			this.txtDescOld.ReadOnly = true;
			this.txtDescOld.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDescOld.Size = new System.Drawing.Size(664, 88);
			this.txtDescOld.TabIndex = 7;
			// 
			// listOld
			// 
			this.listOld.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listOld.HideSelection = false;
			this.listOld.Location = new System.Drawing.Point(8, 8);
			this.listOld.Name = "listOld";
			this.listOld.Size = new System.Drawing.Size(664, 288);
			this.listOld.TabIndex = 2;
			this.listOld.UseCompatibleStateImageBehavior = false;
			this.listOld.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ColumnClick);
			this.listOld.Click += new System.EventHandler(this.VisualizzaDescrizione);
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.label3);
			this.tabPage3.Controls.Add(this.txtDescFull);
			this.tabPage3.Controls.Add(this.listFull);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(680, 428);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Elenco completo";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label3.Location = new System.Drawing.Point(8, 304);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(144, 16);
			this.label3.TabIndex = 9;
			this.label3.Text = "Descrizione aggiornamento";
			// 
			// txtDescFull
			// 
			this.txtDescFull.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescFull.Location = new System.Drawing.Point(8, 328);
			this.txtDescFull.Multiline = true;
			this.txtDescFull.Name = "txtDescFull";
			this.txtDescFull.ReadOnly = true;
			this.txtDescFull.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDescFull.Size = new System.Drawing.Size(664, 88);
			this.txtDescFull.TabIndex = 8;
			// 
			// listFull
			// 
			this.listFull.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listFull.HideSelection = false;
			this.listFull.Location = new System.Drawing.Point(8, 8);
			this.listFull.Name = "listFull";
			this.listFull.Size = new System.Drawing.Size(664, 288);
			this.listFull.TabIndex = 1;
			this.listFull.UseCompatibleStateImageBehavior = false;
			this.listFull.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ColumnClick);
			this.listFull.Click += new System.EventHandler(this.VisualizzaDescrizione);
			// 
			// Frm_ondemand_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(688, 454);
			this.Controls.Add(this.Tab);
			this.Name = "Frm_ondemand_default";
			this.Text = "frmondemand";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DSclient)).EndInit();
			this.Tab.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion

		public void MetaData_AfterLink() {
			Meta=MetaData.GetMetaData(this);
			ConnClone=Meta.Conn.Duplicate();
		}

		public void MetaData_AfterActivation() {
			Init(true);
		}

		public void MetaData_BeforeFill() {
			Text="Aggiornamenti a richiesta";
		}

		/// <summary>
		/// Imposta datatable e carica gli archivi
		/// </summary>
		/// <param name="Startup">True per scaricare il file dal web</param>
		private void Init(bool Startup) {
			txtDescNew.Text="";
			if (!LeggiConfigurazioneWeb()) return;
			if (!LetturaIndiceRemoto(Startup)) return;
			if (!CreazioneIndiceLocale()) return;
			FillListNew();
			FillListOld();
			FillListFull();
		}

		private void DisabilitaBottoni() {
			btnCheckAll.Enabled=false;
			btnUncheckAll.Enabled=false;
			btnCheckSelect.Enabled=false;
			btnUncheckSelect.Enabled=false;
			btnEsegui.Enabled=false;
		}

		private void ShowMsg(string msg) {
			show(msg, "Attenzione",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
		}

		private void ShowMsg(string msg,string detail) {
			QueryCreator.ShowError(this,msg,QueryCreator.GetPrintable(detail));
		}

		private bool LeggiConfigurazioneWeb() {
			siti = new string[4];
			try {
				string fileconfig=Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"updateconfig.xml");
				DataSet DSconfig = new DataSet();
				DSconfig.ReadXml(fileconfig);
				ReportDir = DSconfig.Tables["configtable"].Rows[0]["localreportdir"].ToString();
				if (!ReportDir.EndsWith(@"\")) ReportDir+=@"\";
				siti[0] = DSconfig.Tables["configtable"].Rows[0]["httpupdatepath"].ToString();
				siti[1] = DSconfig.Tables["configtable"].Rows[0]["httpupdatepath2"].ToString();
				//siti[2] = DSconfig.Tables["configtable"].Rows[0]["httpupdatepath3"].ToString();
				siti[2] = "http://www.temposrl.com/easy2/";
				return true;
			}
			catch (Exception E) {
				ShowMsg("Impossibile leggere dal file di configurazione.\r"+
					"Chiudere e riaprire la finestra.",E.Message);
				return false;
			}
		}

		private bool LetturaIndiceRemoto(bool DownloadArchive) {
			if (DownloadArchive) {
				http=new Http(siti,dir_Zip);
				if (!http.IsAvailable()) {
					ShowMsg("Collegamento Internet non disponibile",http.GetLastError());
					return false;
				}
				//scarico il file indice dal sito web
				if (!http.DownloadFile(webdir+C_REMOTEINDEX_ZIP,C_REMOTEINDEX_ZIP)) {
					ShowMsg("Impossibile proseguire. Errore durante il download della lista degli aggiornamenti",
						http.GetLastError());
					return false;
				}
				//estrazione
				XZip.ExtractFiles(dir_Zip+C_REMOTEINDEX_ZIP,dir_Zip,C_REMOTEINDEX_XML,true,true);
				if (!File.Exists(dir_Zip+C_REMOTEINDEX_XML)) {
					ShowMsg("Impossibile proseguire. Errore durante l'estrazione della lista degli aggiornamenti");					
					return false;
				}
			}
			//carico l'indice generale (presente sul sito web)
			DSremote=new DataSet();
			DSremote.ReadXml(dir_Zip+C_REMOTEINDEX_XML);
			if (DSremote.Tables.Count==0 || DSremote.Tables["update"].Rows.Count==0) {
				ShowMsg("Nessun aggiornamento disponibile");
				return false;
			}
			DSremote.Tables["update"].Columns.Add("installato",typeof(string));
			//questa coonna temporanea vale solo per ordinamento
			DSremote.Tables["update"].Columns.Add("data_sort",typeof(string));
			foreach (DataRow R in DSremote.Tables["update"].Rows) {
				R["data_sort"]=R["publishingdate"];
				R["publishingdate"]=DateTime.Parse(R["publishingdate"].ToString()).ToShortDateString();
				R["installato"]=IsInstalled(R,R["flagkind"].ToString());
			}
			DSremote.AcceptChanges();
			return true;
		}

		/// <summary>
		/// Viene ricostruito un file indice in base alle installazioni eseguite dal cliente,
		/// un'aggiornamento di tipo misto è installato se risulta installata la parte server e
		/// client.
		/// </summary>
		private bool CreazioneIndiceLocale() {
			try {
				//scorro tutte gli aggiornamenti presenti sul sito web
                DataRow[] rowsWeb = DSremote.Tables["update"].Select("flagannullato='N'", "code ASC, publishingdate DESC");
				DSlocal=new vistaindex();
				DSlocal.update.Columns.Add("installato",typeof(string));
				foreach (DataRow R in rowsWeb) {
					DataRow Rindex=DSlocal.update.NewRow();
					string tipoupdate=R["flagkind"].ToString();
					Rindex["code"]=R["code"];
					Rindex["shortdescription"]=R["shortdescription"];
					Rindex["description"]=R["description"];
					Rindex["publishingdate"]=R["publishingdate"];
					Rindex["installato"]=IsInstalled(R, tipoupdate);
					Rindex["downloaddate"]=GetInstallDate(R, tipoupdate);
					DSlocal.update.Rows.Add(Rindex);
				}
				DSlocal.AcceptChanges();
				return true;
			}
			catch (Exception E) {
				ShowMsg("Impossibile proseguire. Errore nella ricostruzione lista "+
					"degli aggiornamenti già installati",E.Message);
				return false;
			}
		}

		private object GetInstallDate(DataRow R, string tipoupdate) {
			try {
				string filter="code="+QueryCreator.quotedstrvalue(R["code"],false);
				switch (tipoupdate.ToUpper()) {
					case "S":
						return DS.ondemand.Select(filter)[0]["downloaddate"];
					case "C":
						return DSclient.update.Select(filter)[0]["downloaddate"];
					case "M":
						DateTime objServer=(DateTime)DS.ondemand.Select(filter)[0]["downloaddate"];
						DateTime objClient=(DateTime)DSclient.update.Select(filter)[0]["downloaddate"];
						if (objServer.CompareTo(objClient)>0) return objServer;
						return objClient;
				}
			}
			catch {
			}
			return DBNull.Value;
		}		

		/// <summary>
		/// "Si" se il codice presente nella riga si trova nel DataTable, altrimenti "No"
		/// </summary>
		/// <param name="T"></param>
		/// <param name="ToFind"></param>
		/// <returns></returns>
		private string IsInstalled(DataRow R, string tipoupdate) {
			try {
				string filter="code="+QueryCreator.quotedstrvalue(R["code"],false);
				switch (tipoupdate.ToUpper()) {
					case "S":
						if (DS.ondemand.Select(filter).Length==1) return "Si";
						return "No";
					case "C":
						if (DSclient.update.Select(filter).Length==1) return "Si";
						return "No";
					case "M":
						if ((DS.ondemand.Select(filter).Length==1) && 
							(DSclient.update.Select(filter).Length==1)) return "Si";
						return "No";
				}
			}
			catch {}
			return "No";
		}

		/// <summary>
		/// Filtra tutti i nuovi aggiornamenti dall'elenco web
		/// </summary>
		private void FillListNew() {
			DataTable T=DSremote.Tables["update"];
			if (T==null) return;
			foreach (DataColumn C in T.Columns) C.Caption="";
			T.Columns["code"].Caption="Codice";
			T.Columns["shortdescription"].Caption="Descrizione";
			T.Columns["publishingdate"].Caption="Pubblicato";
			T.Columns["installato"].Caption="Installato";
			DataRow[] rows=T.Select("installato='No' AND flagannullato='N'","data_sort DESC");
			SetListView(listNew, T, rows, true);
		}

		/// <summary>
		/// Filtra tutti gli aggiornamenti installati dall'elenco locale
		/// </summary>
		private void FillListOld() {
			DataTable T=DSlocal.Tables["update"];
			if (T==null) return;
			foreach (DataColumn C in T.Columns) C.Caption="";
			T.Columns["code"].Caption="Codice";
			T.Columns["shortdescription"].Caption="Descrizione";
			T.Columns["publishingdate"].Caption="Pubblicato";
			T.Columns["downloaddate"].Caption="Data di installazione";
			T.Columns["installato"].Caption="Installato";
            DataRow[] rows = T.Select("installato='Si'", "downloaddate DESC");
			foreach (DataRow R in rows) {
				R["downloaddate"]=DateTime.Parse(R["downloaddate"].ToString()).ToShortDateString();
				R["publishingdate"]=DateTime.Parse(R["publishingdate"].ToString()).ToShortDateString();
			}
			SetListView(listOld, T, rows, false);
		}

		/// <summary>
		/// Visualizza la lista completa degli aggiornamenti escludendo quelli annullati
		/// </summary>
		private void FillListFull() {
			DataTable T=DSremote.Tables["update"];
			if (T==null) return;
			foreach (DataColumn C in T.Columns) C.Caption="";
			T.Columns["code"].Caption="Codice";
			T.Columns["shortdescription"].Caption="Descrizione";
			T.Columns["publishingdate"].Caption="Pubblicato";
			T.Columns["installato"].Caption="Installato";
			DataRow[] rows=T.Select("flagannullato='N'","data_sort DESC");
			SetListView(listFull, T, rows, false);
		}

		private void SetListView(ListView L,DataTable T,DataRow[] rows,bool IsCheckList){

			L.BeginUpdate();
			L.Clear();
			string []colnames = new string[T.Columns.Count];
			int ncols=0;
			Graphics GG = Graphics.FromHwnd(L.FindForm().Handle);
			int []sizes = new int[T.Columns.Count];
			foreach (DataColumn C in T.Columns){
				if (C.Caption=="")continue;
				colnames[ncols]= C.ColumnName;
				sizes[ncols]= Convert.ToInt32(GG.MeasureString(C.ColumnName, L.Font).Width)+5;
				ncols++;
			}

			string []items= new string[ncols];
			//Fills ListBox
			foreach(DataRow R in rows){
				for (int i=0; i<ncols; i++){
					string colname= colnames[i];
					items[i]= HelpForm.StringValue(R[colname],
						"", 
						T.Columns[colname]);
					int ss = Convert.ToInt32(GG.MeasureString(items[i], L.Font).Width)+10;
					if (sizes[i]<ss) sizes[i]=ss;
				}
				ListViewItem LVII = new ListViewItem(items[0]);
				LVII.Tag=R;
				for (int j=1; j<ncols; j++) LVII.SubItems.Add(items[j]);
				L.Items.Add(LVII);
				//Dato che la lista checked ha senso solo per i nuovi aggiornamenti
				if (IsCheckList) LVII.Checked=false;
				if (R["installato"].ToString().ToLower()=="si")
					LVII.ForeColor=Color.Green;
				else
					LVII.ForeColor=Color.Blue;
			}

			int ii=0;
			foreach (DataColumn C in T.Columns){
				if (C.Caption=="") continue;
				L.Columns.Add(C.Caption, sizes[ii], HelpForm.GetAlignForColumn(C));
				ii++;
			}
			
			if (IsCheckList) L.CheckBoxes= true;
			L.FullRowSelect=true;
			L.View = View.Details;
			L.GridLines=true;
			L.EndUpdate();
			L.Refresh();
		}

		private void VisualizzaDescrizione(object sender, System.EventArgs e) {
			ListView LV=(ListView)sender;
			TextBox txt=GetTextBox(LV);
			if (txt==null) return;
			txt.Text="";
			//Su selezione multipla non visualizzo nessun dettaglio
			if (LV.SelectedItems.Count>1) return;
			foreach (ListViewItem LVI in LV.SelectedItems) {
				if (LVI.Tag==null) continue;
				DataRow R=(DataRow)LVI.Tag;
				if (R==null) continue;
                txt.Text = R["description"].ToString();
			}
		}

		private TextBox GetTextBox(ListView list) {
			switch (list.Name.Substring(4).ToLower()) {
				case "new": return txtDescNew;
				case "old": return txtDescOld;
				case "full": return txtDescFull;
			}
			return null;
		}

		private Hashtable GetHashtable(ListView list) {
			switch (list.Name.Substring(4).ToLower()) {
				case "new": return hashNew;
				case "old": return hashOld;
				case "full": return hashFull;
			}
			return null;
		}

		private void ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e) {
			ListView LV=(ListView)sender;
			Hashtable ht=GetHashtable(LV);
			bool sort=false;;
			if (ht[e.Column]==null) ht[e.Column]=sort;
			ht[e.Column]=!(bool)ht[e.Column];
			sort=(bool)ht[e.Column];
			LV.ListViewItemSorter = new ListViewItemComparer(e.Column,sort);
			LV.Sort();
		}

		private void btnCheckAll_Click(object sender, System.EventArgs e) {
			foreach (ListViewItem LVI in listNew.Items) LVI.Checked=true;
		}

		private void btnUncheckAll_Click(object sender, System.EventArgs e) {
			foreach (ListViewItem LVI in listNew.Items) LVI.Checked=false;
		}

		private void btnCheckSelect_Click(object sender, System.EventArgs e) {
			foreach (ListViewItem LVI in listNew.SelectedItems) LVI.Checked=true;
		}

		private void btnUncheckSelect_Click(object sender, System.EventArgs e) {
			foreach (ListViewItem LVI in listNew.SelectedItems) LVI.Checked=false;
		}

		private void btnEsegui_Click(object sender, System.EventArgs e) {
			if (listNew.CheckedItems.Count==0) {
				ShowMsg("Non è stato selezionato nessun aggiornamento");
				return;
			}
			Cursor.Current=Cursors.WaitCursor;
			DataRow[] rowsToInstall=new DataRow[listNew.CheckedItems.Count];
			for (int i=0; i<listNew.CheckedItems.Count; i++) {
				rowsToInstall[i]=(DataRow)listNew.CheckedItems[i].Tag;
			}
			if (EseguiAggiornamento(rowsToInstall)) Init(false);
			Cursor.Current=Cursors.Default;
		}

		/// <summary>
		/// Se viene installato un solo aggiornamento anche in presenza di errori
		/// viene effettuato l'aggiornamento.
		/// </summary>
		/// <param name="rows">Lista di aggiornamenti da eseguire</param>
		private bool EseguiAggiornamento(DataRow[] rows) {
			int count=0;
			string versioneDB=GetDBVersion();
			foreach (DataRow R in rows) {
				if (!ControlloVersione(R,versioneDB)) continue;
				if (!Installa(R)) break;
				++count;
			}
			return (count>0);
		}

		/// <summary>
		/// Restituisce la versione corrente del DB
		/// </summary>
		private string GetDBVersion() {
			try {
				string cmd="SELECT TOP 1 versionname FROM updatedbversion ORDER BY versionname DESC";
				DataTable T=Meta.Conn.SQLRunner(cmd,true);
				if (T==null || T.Rows.Count==0) return "";
				return T.Rows[0][0].ToString();
			}
			catch {
				return "";
			}
		}

		/// <summary>
		/// Controllo versione minima dell'aggiornamento
		/// </summary>
		/// <param name="R">riga aggiornamento</param>
		/// <param name="versioneDB">Versione corrente del Database</param>
		/// <returns>True se la versione è minore o uguale di quella del db</returns>
		private bool ControlloVersione(DataRow R, string versioneDB) {
			string codice=R["code"].ToString();
			string versione_update=R["dbversion"].ToString();
			//nessun vincolo
			if (versione_update=="") return true;
			//la versione corrente del DB è maggiore o uguale
			if (versioneDB.CompareTo(versione_update)>=0) return true;
			//Il database non è aggiornato, non è possibile installare l'aggiornamento
			ShowMsg("Impossibile installare l'aggiornamento "+codice+" in quanto "+
				"l'aggiornamento richiede una versione Database pari a "+versione_update);
			return false;
		}

		/// <summary>
		/// Installa un aggiornamento
		/// </summary>
		/// <param name="R">riga aggiornamento</param>
		/// <returns>True se va a buon fine</returns>
		private bool Installa(DataRow R) {
			string codice=R["code"].ToString();
			string filter="code="+QueryCreator.quotedstrvalue(codice,false);
			try {
				DataRow[] rowsFile=DSremote.Tables["fileupdate"].Select(filter);
				foreach (DataRow Rfile in rowsFile) {
					if (!InstallaFile(Rfile)) return false;
				}
				return AggiornaIndiceLocale(R);
			}
			catch (Exception E) {
				ShowMsg("Impossibile installare l'aggiornamento '"+codice+"'",E.Message);
				return false;
			}
		}

		/// <summary>
		/// Installa un elemento dell'aggiornamento che puo' essere un report,
		/// uno script sql, etc...
		/// </summary>
		/// <param name="R">Riga che identifica un elemnto dell'aggiornamento</param>
		/// <returns>True se va a buon fine</returns>
		private bool InstallaFile(DataRow R) {
			string dir=R["code"].ToString()+"/";
			string filename=R["filename"].ToString();
			try {
				string tipofile=R["filekind"].ToString().ToUpper();
				string filezip=filename.Remove(filename.Length-3,3)+"zip";
				if (!http.DownloadFile(webdir+dir+filezip,filezip)) {
					ShowMsg("Impossibile scaricare il file "+filezip,http.GetLastError());
					return false;
				}
				XZip.ExtractFiles(dir_Zip+filezip,dir_Zip,filename,true,true);
				switch (tipofile) {
					case "R":	//report, copiato nella cartella ReportDir
						return CopiaFile(dir_Zip,ReportDir,filename,true);
					case "S":	//script sql, eseguito
						return EseguiScript(dir_Zip+filename);
					default:	//comprende Xml, e altro...
						return CopiaFile(dir_Zip,dir_App,filename,false);
				}
			}
			catch (Exception E) {
				ShowMsg("Errore aggiornamento file "+filename,E.Message);
				return false;
			}
		}

		private bool CopiaFile(string source, string dest, string filename, bool IsREport) {
			try {
				File.Copy(source+filename,dest+filename,true);
				return true;
			}
			catch (Exception E) {
				string msg="Impossibile copiare il file "+filename+" nella cartella "+dest;
				if (IsREport) 
					msg+="\r\nLa cartella è inesistente o di sola lettura. In quest'ultimo "+
						"caso l'aggiornamento deve essere eseguito dal server o da un utente "+
						"che ha i diritti in scrittura sulla cartella "+dest;
				ShowMsg(msg,E.Message);
				return false;
			}
		}

		/// <summary>
		/// Per gli script viene utilizzato un Clone del DataAccess
		/// perché l'esecuzione  di comandi come quoted ansi on/off causa
		/// l'unprepare implicito di comandi precedentemente preparati.
		/// </summary>
		private bool EseguiScript(string script) {
			try {
				StringBuilder sb=XFile.LeggiTestoScript(script);
				if (!XDatabase.RUN_SCRIPT(ConnClone,sb)) {
					ShowMsg("Errore nell'esecuzione dello script "+script,ConnClone.LastError);
					return false;
				}
				return true;
			}
			catch (Exception E) {
				ShowMsg("Errore nell'esecuzione dello script "+script,E.Message);
				return false;
			}
		}

		/// <summary>
		/// Aggiorna l'indice locale ad aggiornamento avvenuto, il file client se di tipo
		/// client, la tabella se di tipo server, entrambi se di tipo misto
		/// </summary>
		/// <param name="R">Riga che identifica l'aggiornamento</param>
		/// <returns>True se va abuon fine</returns>
		private bool AggiornaIndiceLocale(DataRow R) {
			string codice=R["code"].ToString();
			string filter="code="+QueryCreator.quotedstrvalue(codice,false);
			string tipo=R["flagkind"].ToString();
			DataRow[] Rfiles=DSremote.Tables["fileupdate"].Select(filter);
			string lista="";
			foreach (DataRow Rfile in Rfiles) lista+=Rfile["filename"].ToString()+"|";
			try {
				switch (tipo.ToUpper()) {
					case "C":
						if (!RowExists(DSclient.update,R["code"])) 
							ScriviRigaClient(R,lista);
						break;
					case "S":
						if (!RowExists(DS.ondemand,R["code"])) 
							ScriviRigaServer(R,lista);
						break;
					default:
						if (!RowExists(DSclient.update,R["code"])) 
							ScriviRigaClient(R,lista);
						if (!RowExists(DS.ondemand,R["code"])) 
							ScriviRigaServer(R,lista);
						break;
				}
				return true;
			}
			catch (Exception E) {
				ShowMsg("Errore nell'aggiornamento indice locale relativo al codice "+codice,E.Message);
				return false;
			}
		}

		/// <summary>
		/// Resituisce True se il codice aggiornamento esiste nel Datatable che
		/// rappresenta l'indice client o server
		/// </summary>
		private bool RowExists(DataTable T, object codice) {
			if (T==null) return false;
			string filter="code="+QueryCreator.quotedstrvalue(codice,false);
			return (T.Select(filter).Length>0);
		}

		/// <summary>
		/// Un'eventuale eccezione viene gestita dal chiamante
		/// </summary>
		private void ScriviRigaClient(DataRow R, string listafile) {
            DataRow newR=DSclient.update.NewRow();
			newR["code"]=R["code"];
			newR["shortdescription"]=R["shortdescription"];
			newR["description"]=R["description"];
			newR["publishingdate"]=R["publishingdate"];
			newR["downloaddate"]=Meta.GetSys("datacontabile");
			newR["flagkind"]=R["flagkind"];
			newR["filelist"]=listafile;
			DSclient.update.Rows.Add(newR);
			DSclient.WriteXml(dir_App+C_LOCALINDEX_XML);
		}
		/// <summary>
		/// Un'eventuale eccezione viene gestita dal chiamante
		/// </summary>
		private void ScriviRigaServer(DataRow R, string listafile) {
			MetaData.SetDefault(DS.ondemand,"code",R["code"]);
			MetaData.SetDefault(DS.ondemand,"shortdescription",R["shortdescription"]);
			MetaData.SetDefault(DS.ondemand,"description",R["description"]);
			MetaData.SetDefault(DS.ondemand,"publishingdate",R["publishingdate"]);
			MetaData.SetDefault(DS.ondemand,"flagtipo",R["flagkind"]);
			MetaData.SetDefault(DS.ondemand,"filelist",listafile);
			MetaData.SetDefault(DS.ondemand,"dbversion",R["dbversion"]);
			Meta.EditNew();
			Meta.CanSave=true;
			Meta.DoMainCommand("mainsave");
			Meta.CanSave=false;
		}
	}

	// Implements the manual sorting of items by columns.
	class ListViewItemComparer : IComparer {
		private int col;
		private bool asc;
		public ListViewItemComparer() {
			col=0;
			asc=true;
		}
		public ListViewItemComparer(int column, bool sorting) {
			col=column;
			asc=sorting;
		}
		public int Compare(object x, object y) {
			try {
				ListViewItem xitem=(ListViewItem)x;
				ListViewItem yitem=(ListViewItem)y;
				string xvalue=xitem.SubItems[col].Text;
				string yvalue=yitem.SubItems[col].Text;
				if (xitem.ListView.Columns[col].Text.ToLower().StartsWith("publish") ||
					xitem.ListView.Columns[col].Text.ToLower().EndsWith("date")) {
					DateTime dtx=DateTime.Parse(xvalue);
					DateTime dty=DateTime.Parse(yvalue);
					xvalue=dtx.Year.ToString()+dtx.Month.ToString().PadLeft(2,'0')+dtx.Day.ToString().PadLeft(2,'0');
					yvalue=dty.Year.ToString()+dty.Month.ToString().PadLeft(2,'0')+dty.Day.ToString().PadLeft(2,'0');
				}
				if (asc)
					return String.Compare(xvalue, yvalue);
				else
					return String.Compare(yvalue, xvalue);
			}
			catch {
				return 0;
			}
		}
	}
}
