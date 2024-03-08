
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
using metadatalibrary;
using System.Data;
using funzioni_configurazione;
using System.IO;
using System.Text;
using LiveUpdate;

namespace banktransaction_recuperadati {
	/// <summary>
	/// Summary description for FrmBankTransaction_RecuperaDati.
	/// </summary>
	public class FrmBankTransaction_RecuperaDati : MetaDataForm {
		MetaData Meta;
		public banktransaction_recuperadati.vistaForm DS;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbDB;
		private System.Windows.Forms.Button btnEstrai;
		private System.Windows.Forms.TextBox txtDBOrigine;
		private System.Windows.Forms.TextBox txtDBDestinazione;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblFaseCorrente;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.TextBox txtDipDestinazione;
		private System.Windows.Forms.Label label4;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmBankTransaction_RecuperaDati() {
			InitializeComponent();
			progressBar1.Minimum = 0;
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
			this.DS = new banktransaction_recuperadati.vistaForm();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbDB = new System.Windows.Forms.ComboBox();
			this.btnEstrai = new System.Windows.Forms.Button();
			this.txtDBOrigine = new System.Windows.Forms.TextBox();
			this.txtDBDestinazione = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lblFaseCorrente = new System.Windows.Forms.Label();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.txtDipDestinazione = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Elenco DB:";
			// 
			// cmbDB
			// 
			this.cmbDB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.cmbDB.Location = new System.Drawing.Point(8, 24);
			this.cmbDB.Name = "cmbDB";
			this.cmbDB.Size = new System.Drawing.Size(432, 21);
			this.cmbDB.TabIndex = 1;
			this.cmbDB.SelectedIndexChanged += new System.EventHandler(this.cmbDB_SelectedIndexChanged);
			// 
			// btnEstrai
			// 
			this.btnEstrai.Location = new System.Drawing.Point(152, 56);
			this.btnEstrai.Name = "btnEstrai";
			this.btnEstrai.Size = new System.Drawing.Size(144, 23);
			this.btnEstrai.TabIndex = 2;
			this.btnEstrai.Text = "Estrai i dati";
			this.btnEstrai.Click += new System.EventHandler(this.btnEstrai_Click);
			// 
			// txtDBOrigine
			// 
			this.txtDBOrigine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtDBOrigine.Location = new System.Drawing.Point(8, 112);
			this.txtDBOrigine.Name = "txtDBOrigine";
			this.txtDBOrigine.ReadOnly = true;
			this.txtDBOrigine.Size = new System.Drawing.Size(184, 20);
			this.txtDBOrigine.TabIndex = 3;
			this.txtDBOrigine.Text = "";
			// 
			// txtDBDestinazione
			// 
			this.txtDBDestinazione.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtDBDestinazione.Location = new System.Drawing.Point(8, 160);
			this.txtDBDestinazione.Name = "txtDBDestinazione";
			this.txtDBDestinazione.ReadOnly = true;
			this.txtDBDestinazione.Size = new System.Drawing.Size(184, 20);
			this.txtDBDestinazione.TabIndex = 4;
			this.txtDBDestinazione.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 96);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 5;
			this.label2.Text = "DB Origine:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 144);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 16);
			this.label3.TabIndex = 6;
			this.label3.Text = "DB Destinazione:";
			// 
			// lblFaseCorrente
			// 
			this.lblFaseCorrente.Location = new System.Drawing.Point(8, 192);
			this.lblFaseCorrente.Name = "lblFaseCorrente";
			this.lblFaseCorrente.Size = new System.Drawing.Size(432, 23);
			this.lblFaseCorrente.TabIndex = 7;
			// 
			// progressBar1
			// 
			this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar1.Location = new System.Drawing.Point(8, 224);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(432, 23);
			this.progressBar1.TabIndex = 8;
			// 
			// txtDipDestinazione
			// 
			this.txtDipDestinazione.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtDipDestinazione.Location = new System.Drawing.Point(208, 160);
			this.txtDipDestinazione.Name = "txtDipDestinazione";
			this.txtDipDestinazione.ReadOnly = true;
			this.txtDipDestinazione.Size = new System.Drawing.Size(184, 20);
			this.txtDipDestinazione.TabIndex = 9;
			this.txtDipDestinazione.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(208, 144);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(200, 16);
			this.label4.TabIndex = 10;
			this.label4.Text = "Dipartimento di Destionazione:";
			// 
			// FrmBankTransaction_RecuperaDati
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(448, 254);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtDipDestinazione);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.lblFaseCorrente);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtDBDestinazione);
			this.Controls.Add(this.txtDBOrigine);
			this.Controls.Add(this.btnEstrai);
			this.Controls.Add(this.cmbDB);
			this.Controls.Add(this.label1);
			this.Name = "FrmBankTransaction_RecuperaDati";
			this.Text = "FrmBankTransaction_RecuperaDati";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		string server = "";
		string db = "";
		//string user = "";
		//string pwd = "";
		DataAccess sourceConn;
		DataAccess destConn;
		DataTable tSysDB;
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
			destConn = Meta.Conn;
//			server = "serversw\\sql2000";
			server = "(local)";
			db = "master";
			//user = "mluisas";
			//pwd = "mluisas";
			//sourceConn = new DataAccess(db, server, db, user, pwd, (int)Meta.GetSys("esercizio"), DateTime.Now);
			try {
				sourceConn = new DataAccess("master", server, db, (int)Meta.GetSys("esercizio"), DateTime.Now);
			}
			catch(Exception ex) {
				show(this, "Errore nella prima connessione"+"\r\n"+ex.ToString());
			}

			string whereClause = "WHERE name NOT IN ('master','model','msdb','tempdb')"; 
			tSysDB = sourceConn.SQLRunner("SELECT name FROM sysdatabases " + whereClause);
			fillComboDB();
			txtDBDestinazione.Text = destConn.GetSys("database").ToString();
			txtDipDestinazione.Text = destConn.GetSys("userdb").ToString();
		}

		private void fillComboDB () {
			if (cmbDB.DataSource != null) cmbDB.DataSource = null;
			cmbDB.DataSource = tSysDB;
			cmbDB.DisplayMember = tSysDB.Columns["name"].ColumnName;
			cmbDB.ValueMember = tSysDB.Columns["name"].ColumnName;
		}

		private void btnEstrai_Click(object sender, System.EventArgs e) {
			if (cmbDB.SelectedValue == null) return;
			db = cmbDB.SelectedValue.ToString();
			if (db == "") return;
			txtDBOrigine.Text = db;

			sourceConn.Destroy();
			//sourceConn = new DataAccess(db, server, db, user, pwd, (int)Meta.GetSys("esercizio"), DateTime.Now);
			try {
				sourceConn = new DataAccess("master", server, db, (int)Meta.GetSys("esercizio"), DateTime.Now);
			}
			catch(Exception ex) {
				show(this, "Errore nella prima connessione\r\n"+ex.ToString());
			}
			

			if (!migraDati()) return;
		}

		DataTable tSpesa;
		DataTable tEntrata;
		DataTable tMovBan;
		DataTable tDettMovBan;
		DataSet dsSource = new DataSet();
		private bool riempiDataSetOrigine() {
			object faseMaxS = sourceConn.DO_READ_VALUE("fasespesa", null, "MAX(codicefase)");
			string q1 = "SELECT "
				+ "idspesa, importocorrente, esercdocpagamento, numdocpagamento, esercmovbancario, nummovbancario, "
				+ "importo, importoritenute, importocorrente, importonetto "
				+ "FROM spesaview WHERE (codicefase = '" + faseMaxS
				+ "') AND (esercizio <= 2005) AND (esercmovbancario IS NOT NULL)";

			tSpesa = sourceConn.SQLRunner(q1);
			if (tSpesa == null) return false;

			tSpesa.TableName = "spesaview";
			
			object faseMaxE = sourceConn.DO_READ_VALUE("faseentrata", null, "MAX(codicefase)");
			string q2 = "SELECT "
				+ "identrata, esercdocincasso, numdocincasso, esercmovbancario, nummovbancario, "
				+ "importo, importocorrente "
				+ "FROM entrataview WHERE codicefase = '" + faseMaxE
				+ "') AND (esercizio <= 2005) AND (esercmovbancario IS NOT NULL)";

			tEntrata = sourceConn.SQLRunner(q2);
			if (tEntrata == null) return false;

			tEntrata.TableName = "entrataview";

			string q3 = "SELECT * FROM movimentobancario WHERE esercmovbancario <= 2005";

			tMovBan = sourceConn.SQLRunner(q3);
			if (tMovBan == null) return false;

			tMovBan.TableName = "movimentobancario";

			string q4 = "SELECT * FROM dettmovimentobancario WHERE esercmovbancario <= 2005";

			tDettMovBan = sourceConn.SQLRunner(q4);
			if (tDettMovBan == null) return false;

			tDettMovBan.TableName = "dettmovbancario";

			dsSource.Tables.Add(tSpesa);
			dsSource.Tables.Add(tEntrata);
			dsSource.Tables.Add(tMovBan);
			dsSource.Tables.Add(tDettMovBan);
			return true;
		}

		public bool migraDati() {
			if (!migraMovimentiFinanziari("I")) return false;

			if (!migraMovimentiFinanziari("E")) return false;
			impostaHashTablePerNBAN();
			if (!creaMovBancari("I")) return false;

			if (!creaEsiti("I")) return false;

			if (!creaMovBancari("E")) return false;

			if (!creaEsiti("E")) return false;

			show(this, "Recupero dati effettuato con successo!", "Procedura Terminata", MessageBoxButtons.OK,
				MessageBoxIcon.Information);

			return true;
		}

		Hashtable ht = new Hashtable();
		private void impostaHashTablePerNBAN() {
			int min = CfgFn.GetNoNullInt32(destConn.DO_READ_VALUE("accountingyear", null, "MIN(ayear)"));
			int max = 2005;

			for(int curryear = min; curryear <= max; curryear++) {
				ht[curryear] = CfgFn.GetNoNullInt32(destConn.DO_READ_VALUE("banktransaction", "(yban = '" + curryear + "')", "MAX(nban)"));
			}
		}

		
		private void aggiornaForm(string fase) {
			progressBar1.Value = 0;
			lblFaseCorrente.Text = fase;
		}

		public bool migraMovimentiFinanziari(string IoE) {
			
			string tName_src = (IoE == "I") ? "entrata" : "spesa";
			string idfield = (IoE == "I") ? "identrata" : "idspesa";
			string tName_dest = (IoE == "I") ? "income" : "expense";
			string maxphase = Meta.GetSys("max" + tName_dest + "phase").ToString();

			string faseCorrente = "Caricamento dati movimenti di " + tName_src + " ...";
			aggiornaForm(faseCorrente);

			string addfield = (IoE == "I") ? "idpro" : "idpay";
			string addfieldQuery = addfield + " = null";

			string kind = (IoE == "I") ? "C" : "D";

			string listaCampiMovFin_src = idfield + ", esercmovbancario, nummovbancario";
			string query = "";
//			if (IoE == "I") {
//				query = "SELECT "
//					+ "identrata, esercmovbancario, nummovbancario "
//					+ "FROM entrataview WHERE (codicefase = '" + maxphase
//					+ "') AND (esercizio <= 2005) AND (esercmovbancario IS NOT NULL)";
//			}
//			else {
//				query = "SELECT "
//					+ "idspesa, esercmovbancario, nummovbancario "
//					+ "FROM spesaview WHERE (codicefase = '" + maxphase
//					+ "') AND (esercizio <= 2005) AND (esercmovbancario IS NOT NULL)";
//			}

			if (IoE == "I") {
				query = "SELECT "
					+ "idinc = identrata, idpro = numoperazione "
					+ "FROM entrata "
					+ "JOIN movimentobancario "
					+ "ON entrata.esercmovbancario = movimentobancario.esercmovbancario "
					+ "AND entrata.nummovbancario = movimentobancario.nummovbancario "
					+ "WHERE (entrata.esercmovbancario <= 2005)";
			}
			else {
				query = "SELECT "
					+ "idexp = SUBSTRING(idspesa,1,8) + idspesa, idpay = numoperazione "
					+ "FROM spesa "
					+ "JOIN movimentobancario "
					+ "ON spesa.esercmovbancario = movimentobancario.esercmovbancario "
					+ "AND spesa.nummovbancario = movimentobancario.nummovbancario "
					+ "WHERE (spesa.esercmovbancario <= 2005)";
			}

			DataTable tMovFin_src = sourceConn.SQLRunner(query);
			if (tMovFin_src == null) return false;
			tMovFin_src.TableName = tName_dest;

//			string q2 = "SELECT esercmovbancario, nummovbancario, numoperazione FROM movimentobancario "
//				+ " WHERE (esercmovbancario <= 2005) AND (tipomovbancario = '" + kind + "')";
//			DataTable tMovBan = sourceConn.SQLRunner(q2);
//
//			string idfieldmov_dest = (IoE == "I") ? "idinc" : "idexp";
//			string idfield_dest = (IoE == "I") ? "idpro" : "idpay";
//			string listaCampiMovFin_Dest = idfieldmov_dest + ", " + idfield_dest;
//
//			string filterMovDest = "(nphase = '" + maxphase + "') AND ((ycreation <= '2005') OR (ymov <= '2005'))";
//			DataTable tMovFin_dest = DataAccess.RUN_SELECT(destConn, tName_dest, listaCampiMovFin_Dest, null,
//					filterMovDest, null, null, true);
//
//			string idp_field = (IoE == "I") ? "idpro" : "idpay";
//			progressBar1.Maximum = tMovFin_src.Rows.Count;
//			foreach(DataRow rMovFin_src in tMovFin_src.Rows) {
//				DataRow [] MovFin_dest = tMovFin_dest.Select("("+idfieldmov_dest + " = " +
//					QueryCreator.quotedstrvalue(rMovFin_src[idfield], false) + ")");
//				if (MovFin_dest.Length == 0) continue;
//
//				DataRow rMovFin_dest = MovFin_dest[0];
//
//				string filtroMovBan = "(esercmovbancario = '" + rMovFin_src["esercmovbancario"]
//					+ "') AND (nummovbancario = '" + rMovFin_src["nummovbancario"] + "')";
//				DataRow [] rMovBan = tMovBan.Select(filtroMovBan);
//				if (rMovBan.Length == 0) continue;
//
//				rMovFin_dest[idp_field] = rMovBan[0]["numoperazione"];
//				progressBar1.Value++;
//				Application.DoEvents();
//			}
			string nomeCopia = tName_src + " -> " + tName_dest;
			return creaScriptAggiornaMovFin(tMovFin_src);
		}

		public bool creaMovBancari(string IoE) {
			// PAYMENT_BANK - PROCEEDS_BANK (Tabelle dei movimenti bancari)
			string p_bank = (IoE == "I") ? "proceeds_bank" : "payment_bank";
			DataTable tPXXX_Bank = DataAccess.CreateTableByName(destConn, p_bank, "*");
			tPXXX_Bank.Clear();

			string finpart = (IoE == "I") ? "entrata" : "spesa";
			aggiornaForm("Creazione dei movimenti bancari di " + finpart + " ...");
			string kind = (IoE == "I") ? "C" : "D";
			string q1 = "SELECT "
				+ "nummovbancario, esercmovbancario, "
				+ "tipomovbancario, codicecreddeb, descrizione, "
				+ "esercdocumento, numdocumento, "
				+ "importo, rifbanca, numoperazione, "
				+ "dataoperazione, datavaluta "
				+ "FROM movimentobancario "
				+ "WHERE tipomovbancario = '" + kind
				+ "' AND esercmovbancario <= 2005";
				

			DataTable tMovBancario_src = sourceConn.SQLRunner(q1);
			if (tMovBancario_src == null) return false;

			progressBar1.Maximum = tMovBancario_src.Rows.Count;
			foreach(DataRow rMovBancario in tMovBancario_src.Rows) {
				fillPBank(rMovBancario, tPXXX_Bank, IoE);
				progressBar1.Value++;
				Application.DoEvents();
			}

			string nomeCopia = "(movimentobancario -> " + p_bank + ")";
			return lanciaScript(this, destConn, tPXXX_Bank, nomeCopia);
		}

		private bool creaEsitiTotali(string IoE) {
			string yfield = (IoE == "I") ? "ypro" : "ypay";
			string nfield = (IoE == "I") ? "npro" : "npay";
			string idfield = (IoE == "I") ? "idpro" : "idpay";
			string kind = (IoE == "I") ? "C" : "D";
			string tabMovFin_dest = (IoE == "I") ? "income" : "expense";
			string idfieldmov_dest = (IoE == "I") ? "idinc" : "idexp";
			
			aggiornaForm("Generazione Esiti Totali ...");

			object maxphase_dest = destConn.GetSys("max" + tabMovFin_dest + "phase");
			string filterPhase = "(nphase = '" + maxphase_dest + "')";

			string query = "SELECT "
				+ "nummovbancario, esercmovbancario, "
				+ "tipomovbancario, "
				+ "esercdocumento, numdocumento, "
				+ "importo, rifbanca, numoperazione, "
				+ "dataoperazione, datavaluta "
				+ "from movimentobancario "
				+ "where tipomovbancario = '" + kind + "' "
				+ "and flagesito = 'S' "
				+ "AND esercmovbancario <= 2005";

			// Tabelle di PARTENZA
			DataTable tMovBancario_src = sourceConn.SQLRunner(query);
			if (tMovBancario_src == null) return false;

			// BANKTRANSACTION (Tabella degli esiti)
			DataTable bankTransaction = DataAccess.CreateTableByName(destConn, "banktransaction", "*");
			bankTransaction.Clear();

			string tabMovFin_src = (IoE == "I") ? "entrataview" : "spesaview";
			string idfieldmov_src = (IoE == "I") ? "identrata" : "idspesa";

			string listaCampiMov_src = idfieldmov_src + ", importocorrente, esercmovbancario, nummovbancario";

			DataTable tMovFin_src = DataAccess.RUN_SELECT(sourceConn, tabMovFin_src, listaCampiMov_src, null, "(esercmovbancario IS NOT NULL)"
				, null, null, true);
			if (tMovFin_src == null) return false;

			progressBar1.Maximum = tMovBancario_src.Rows.Count;
			foreach(DataRow rMovBancario in tMovBancario_src.Rows) {
				string filter = "(esercmovbancario = '" + rMovBancario["esercmovbancario"]
					+ "') AND (nummovbancario = '" + rMovBancario["nummovbancario"] + "')";
					
				DataRow [] MovFin = tMovFin_src.Select(filter);
				// Passo 2. Per ogni mov. finanziario aggiorno il campo IDPAY (IDPRO)
				foreach(DataRow rMov in MovFin) {
					decimal importo = CfgFn.GetNoNullDecimal(rMov["importocorrente"]); 
					fillBankTransaction(rMovBancario, rMov[idfieldmov_src], bankTransaction, IoE, importo);
				}
				progressBar1.Value++;
				Application.DoEvents();
			}
			
			return lanciaScript(this, destConn, bankTransaction, "movimentobancario -> banktransaction");
		}

		private bool creaEsitiParziali(string IoE) {
			string yfield = (IoE == "I") ? "ypro" : "ypay";
			string nfield = (IoE == "I") ? "npro" : "npay";
			string idfield = (IoE == "I") ? "idpro" : "idpay";
			string kind = (IoE == "I") ? "C" : "D";
			string tabMovFin_dest = (IoE == "I") ? "income" : "expense";
			string idfieldmov_dest = (IoE == "I") ? "idinc" : "idexp";

			object maxphase_dest = destConn.GetSys("max" + tabMovFin_dest + "phase");
			string filterPhase = "(nphase = '" + maxphase_dest + "')";

			// BANKTRANSACTION (Tabella degli esiti)
			DataTable bankTransaction = DataAccess.CreateTableByName(destConn, "banktransaction", "*");
			bankTransaction.Clear();

			string q2 = "SELECT "
				+ "m.nummovbancario, m.esercmovbancario, "
				+ "m.tipomovbancario, "
				+ "m.esercdocumento, m.numdocumento, "
				+ "d.importo, d.rifbanca, d.numoperazione, "
				+ "d.dataoperazione, d.datavaluta "
				+ "from movimentobancario m "
				+ "join dettmovimentobancario d "
				+ "on m.esercmovbancario = d.esercmovbancario "
				+ "and m.nummovbancario = d.nummovbancario "
				+ "where m.tipomovbancario = '" + kind + "' "
				+ "and m.flagesito = 'P' "
				+ "AND m.esercmovbancario <= 2005";	

			string tabMovFin_src = (IoE == "I") ? "entrataview" : "spesaview";
			string idfieldmov_src = (IoE == "I") ? "identrata" : "idspesa";

			// Tabelle di PARTENZA
			DataTable tDettMovBanc = sourceConn.SQLRunner(q2);
			if (tDettMovBanc == null) return false;

			string listaCampiMov_src = idfieldmov_src + ", importo, importocorrente, esercmovbancario, nummovbancario";
			if (IoE == "E") {
				listaCampiMov_src += ", importoritenute";
			}
			DataTable tMovFin_src = DataAccess.RUN_SELECT(sourceConn, tabMovFin_src, listaCampiMov_src, null, "(esercmovbancario IS NOT NULL)"
				, null, null, true);
			if (tMovFin_src == null) return false;

			// Tabella temporanea dei movimenti finanziari
			DataTable temp = new DataTable();
			temp.Columns.Add("idmov");
			temp.Columns.Add("curramount");
			temp.Columns.Add("performedamount");
			temp.Columns.Add("residual");

			if (!creaEsitiDoveUnMovimentoBancarioUnMovimentoFinanziario(tDettMovBanc, tMovFin_src, IoE)) {
				return false;
			}
			tDettMovBanc.AcceptChanges();

			if (!creaEsitiDoveImportoCorrMovFinIsImportoEsito(tDettMovBanc, tMovFin_src, temp, IoE)) {
				return false;
			}
			tDettMovBanc.AcceptChanges();

			if (IoE == "E") {
				if (!creaEsitiDoveImportoNettoMovSpesaIsImportoEsito(tDettMovBanc, tMovFin_src, temp)) {
					return false;
				}
				tDettMovBanc.AcceptChanges();

				if (!creaEsitiDoveImportoRitMovSpesaIsImportoEsito(tDettMovBanc, tMovFin_src, temp)) {
					return false;
				}
				tDettMovBanc.AcceptChanges();
			}
			return creaEsitiACoperturaProgressiva(tDettMovBanc, tMovFin_src, temp, IoE);
		}

		private bool creaEsitiDoveUnMovimentoBancarioUnMovimentoFinanziario(DataTable tDettMovBanc,
			DataTable tMovFin_src, string IoE) {
			aggiornaForm("Generazione Esiti Parziali - Passo 1 ...");
			string idfieldmov_src = (IoE == "I") ? "identrata" : "idspesa";

			// BANKTRANSACTION (Tabella degli esiti)
			DataTable bankTransaction = DataAccess.CreateTableByName(destConn, "banktransaction", "*");
			bankTransaction.Clear();

			progressBar1.Maximum = tDettMovBanc.Rows.Count;
			foreach(DataRow rEsito in tDettMovBanc.Select()) {
				string filter = "(esercmovbancario = '" + rEsito["esercmovbancario"]
					+ "') AND (nummovbancario = '" + rEsito["nummovbancario"] + "')";

				DataRow [] MovFin = tMovFin_src.Select(filter);
				if (MovFin.Length == 0) continue;

				// Caso 1. Esiste un unico movimento associato al movimento bancario -> gli esiti sono associati tutti allo stesso movimento
				if (MovFin.Length == 1) {
					DataRow rMov = MovFin[0];
					//decimal importo = CfgFn.GetNoNullDecimal(rMov["importocorrente"]);
					decimal importo = CfgFn.GetNoNullDecimal(rEsito["importo"]);
					// Creazione dell'esito (BANKTRANSACTION)
					fillBankTransaction(rEsito, rMov[idfieldmov_src], bankTransaction, IoE, importo);
					progressBar1.Value++;
					Application.DoEvents();
				}
				rEsito.Delete();
			}
			return lanciaScript(this, destConn, bankTransaction, "Generazione Esiti dove c'è un mov. fin. per ogni mov. bancario");
		}

		private bool creaEsitiDoveImportoCorrMovFinIsImportoEsito(DataTable tDettMovBanc, DataTable tMovFin_src,
			DataTable temp, string IoE) {
			aggiornaForm("Generazione Esiti Parziali - Passo 2 ...");
			string idfieldmov_src = (IoE == "I") ? "identrata" : "idspesa";

			// BANKTRANSACTION (Tabella degli esiti)
			DataTable bankTransaction = DataAccess.CreateTableByName(destConn, "banktransaction", "*");
			bankTransaction.Clear();

			progressBar1.Maximum = tDettMovBanc.Rows.Count;
			foreach(DataRow rEsito in tDettMovBanc.Select()) {
				decimal importoEsito = CfgFn.GetNoNullDecimal(rEsito["importo"]);
				string filter = "(esercmovbancario = '" + rEsito["esercmovbancario"]
					+ "') AND (nummovbancario = '" + rEsito["nummovbancario"] + "')";
				
				DataRow [] MovFin = tMovFin_src.Select(filter);
				if (MovFin.Length == 0) continue;

				if (MovFin.Length > 1) {
					bool found = false;
					// Sotto Caso 2.1. Esiste un movimento finanziario il cui importo è pari a quello dell'esito
					foreach(DataRow rMovFin in MovFin) {
						if (found) break;
						decimal importoCorrente = CfgFn.GetNoNullDecimal(rMovFin["importocorrente"]);
						if (importoCorrente != importoEsito) continue;

						// Se in TEMP è presente il movimento vuol dire che l'ho esitato completamente e quindi non vado avanti
						string filterTemp = "(idmov = " + QueryCreator.quotedstrvalue(rMovFin[idfieldmov_src], false)
							+ ")";
						DataRow [] rmovtemp = temp.Select(filterTemp);
						if ((rmovtemp.Length > 0) && (CfgFn.GetNoNullDecimal(rmovtemp[0]["residual"]) < importoEsito)) continue;

						fillBankTransaction(rEsito, rMovFin[idfieldmov_src], bankTransaction, IoE, importoEsito);

						DataRow rTemp = temp.NewRow();
						rTemp["idmov"] = rMovFin[idfieldmov_src];
						rTemp["curramount"] = importoEsito;
						rTemp["performedamount"] = importoEsito;
						rTemp["residual"] = 0;
						temp.Rows.Add(rTemp);

						found = true;
					}
				}
				progressBar1.Value++;
				Application.DoEvents();
				rEsito.Delete();
			}
			return lanciaScript(this, destConn, bankTransaction, "Generazione Esiti dove c'è un mov. fin. con importo pari all'esito");
		}

		private bool creaEsitiDoveImportoNettoMovSpesaIsImportoEsito (DataTable tDettMovBanc, DataTable tMovFin_src,
			DataTable temp) {
			aggiornaForm("Generazione Esiti Parziali - Passo 3 ...");
			string idfieldmov_src = "idspesa";

			// BANKTRANSACTION (Tabella degli esiti)
			DataTable bankTransaction = DataAccess.CreateTableByName(destConn, "banktransaction", "*");
			bankTransaction.Clear();
			
			progressBar1.Maximum = tDettMovBanc.Rows.Count;
			foreach(DataRow rEsito in tDettMovBanc.Select()) {
				decimal importoEsito = CfgFn.GetNoNullDecimal(rEsito["importo"]);
				string filter = "(esercmovbancario = '" + rEsito["esercmovbancario"]
					+ "') AND (nummovbancario = '" + rEsito["nummovbancario"] + "')";
				
				DataRow [] MovFin = tMovFin_src.Select(filter);
				if (MovFin.Length == 0) continue;

				if (MovFin.Length > 1) {
					bool found = false;
					// Sotto Caso 2.2. (Solo Spesa) Esiste un movimento di spesa il cui importo netto è pari a quello dell'esito
					// Attenzione si passa al Sotto Caso 2.2. solo se il Sotto Caso 2.1. è fallito
					foreach(DataRow rMovFin in MovFin) {
						if (found) break;
						decimal importoNetto = CfgFn.GetNoNullDecimal(rMovFin["importo"]) - CfgFn.GetNoNullDecimal(rMovFin["importoritenute"]);
						if (importoNetto != importoEsito) continue;

						// Se in TEMP è presente il movimento vuol dire che l'ho esitato completamente e quindi non vado avanti
						string filterTemp = "(idmov = " + QueryCreator.quotedstrvalue(rMovFin[idfieldmov_src], false)
							+ ")";
						DataRow [] rmovtemp = temp.Select(filterTemp);
						if ((rmovtemp.Length > 0) && (CfgFn.GetNoNullDecimal(rmovtemp[0]["residual"]) < importoEsito)) continue;

						fillBankTransaction(rEsito, rMovFin[idfieldmov_src], bankTransaction, "E", importoEsito);

						if (rmovtemp.Length > 0) {
							rmovtemp[0]["performedamount"] = CfgFn.GetNoNullDecimal(rmovtemp[0]["performedamount"])
								+ importoEsito;
							rmovtemp[0]["residual"] = CfgFn.GetNoNullDecimal(rmovtemp[0]["residual"]) - importoEsito;
						}
						else {
							DataRow rTemp = temp.NewRow();
							rTemp["idmov"] = rMovFin[idfieldmov_src];
							rTemp["curramount"] = rMovFin["importocorrente"];
							rTemp["performedamount"] = importoEsito;
							decimal residuo = CfgFn.GetNoNullDecimal(rTemp["curramount"]) - 
								importoEsito;
							rTemp["residual"] = residuo;
							temp.Rows.Add(rTemp);
						}

						found = true;
					}
				}
				progressBar1.Value++;
				Application.DoEvents();
				rEsito.Delete();
			}

			return lanciaScript(this, destConn, bankTransaction, "Generazione Esiti dove c'è un mov. di spesa con importo netto pari all'esito");
		}

		private bool creaEsitiDoveImportoRitMovSpesaIsImportoEsito (DataTable tDettMovBanc, DataTable tMovFin_src,
			DataTable temp) {

			aggiornaForm("Generazione Esiti Parziali - Passo 4 ...");
			string idfieldmov_src = "idspesa";

			// BANKTRANSACTION (Tabella degli esiti)
			DataTable bankTransaction = DataAccess.CreateTableByName(destConn, "banktransaction", "*");
			bankTransaction.Clear();

			progressBar1.Maximum = tDettMovBanc.Rows.Count;
			foreach(DataRow rEsito in tDettMovBanc.Select()) {
				decimal importoEsito = CfgFn.GetNoNullDecimal(rEsito["importo"]);
				string filter = "(esercmovbancario = '" + rEsito["esercmovbancario"]
					+ "') AND (nummovbancario = '" + rEsito["nummovbancario"] + "')";
				
				DataRow [] MovFin = tMovFin_src.Select(filter);
				if (MovFin.Length == 0) continue;

				if (MovFin.Length > 1) {
					// Sotto Caso 2.2. (Solo Spesa) Esiste un movimento di spesa il cui importo netto è pari a quello dell'esito
					// Attenzione si passa al Sotto Caso 2.2. solo se il Sotto Caso 2.1. è fallito
					bool found = false;
					foreach(DataRow rMovFin in MovFin) {
						if (found) break;
						decimal importoRitenute = CfgFn.GetNoNullDecimal(rMovFin["importoritenute"]);
						if (importoRitenute != importoEsito) continue;

						// Se in TEMP è presente il movimento vuol dire che l'ho esitato completamente e quindi non vado avanti
						string filterTemp = "(idmov = " + QueryCreator.quotedstrvalue(rMovFin[idfieldmov_src], false)
							+ ")";
						DataRow [] rmovtemp = temp.Select(filterTemp);
						if ((rmovtemp.Length > 0) && (CfgFn.GetNoNullDecimal(rmovtemp[0]["residual"]) < importoEsito)) continue;

						fillBankTransaction(rEsito, rMovFin[idfieldmov_src], bankTransaction, "E", importoEsito);

						if (rmovtemp.Length > 0) {
							rmovtemp[0]["performedamount"] = CfgFn.GetNoNullDecimal(rmovtemp[0]["performedamount"])
								+ importoEsito;
							rmovtemp[0]["residual"] = CfgFn.GetNoNullDecimal(rmovtemp[0]["residual"]) - importoEsito;
						}
						else {
							DataRow rTemp = temp.NewRow();
							rTemp["idmov"] = rMovFin[idfieldmov_src];
							rTemp["curramount"] = rMovFin["importocorrente"];
							rTemp["performedamount"] = importoEsito;
							decimal residuo = CfgFn.GetNoNullDecimal(rTemp["curramount"]) - 
								importoEsito;
							rTemp["residual"] = residuo;
							temp.Rows.Add(rTemp);
						}

						found = true;
					}
				}
				progressBar1.Value++;
				Application.DoEvents();
				rEsito.Delete();
			}

			return lanciaScript(this, destConn, bankTransaction, "Generazione Esiti dove c'è un mov. di spesa con importo ritenute pari all'esito");
		}

		private bool creaEsitiACoperturaProgressiva (DataTable tDettMovBanc, DataTable tMovFin_src,
			DataTable temp, string IoE) {
			aggiornaForm("Generazione Esiti Parziali - Passo 5 ...");
			string idfieldmov_src = (IoE == "I") ? "identrata" : "idspesa";

			// BANKTRANSACTION (Tabella degli esiti)
			DataTable bankTransaction = DataAccess.CreateTableByName(destConn, "banktransaction", "*");
			bankTransaction.Clear();

			progressBar1.Maximum = tDettMovBanc.Rows.Count;

			foreach(DataRow rEsito in tDettMovBanc.Select()) {
				decimal importoEsito = CfgFn.GetNoNullDecimal(rEsito["importo"]);
				string filter = "(esercmovbancario = '" + rEsito["esercmovbancario"]
					+ "') AND (nummovbancario = '" + rEsito["nummovbancario"] + "')";
				
				DataRow [] MovFin = tMovFin_src.Select(filter);
				if (MovFin.Length == 0) continue;

				decimal residuoEsito = importoEsito;
				foreach(DataRow rMovFin in MovFin) {
					if (residuoEsito == 0) break;

					// Se in TEMP è presente il movimento vuol dire che l'ho esitato completamente e quindi non vado avanti
					string filterTemp = "(idmov = " + QueryCreator.quotedstrvalue(rMovFin[idfieldmov_src], false)
						+ ")";
					DataRow [] rmovtemp = temp.Select(filterTemp);
					if ((rmovtemp.Length > 0) && (CfgFn.GetNoNullDecimal(rmovtemp[0]["residual"]) == 0)) continue;

					decimal importodaEsitare = (CfgFn.GetNoNullDecimal(rmovtemp[0]["residual"]) >= importoEsito)
						? importoEsito : CfgFn.GetNoNullDecimal(rmovtemp[0]["residual"]);

					fillBankTransaction(rEsito, rMovFin[idfieldmov_src], bankTransaction, IoE, importodaEsitare);

					if (rmovtemp.Length > 0) {
						rmovtemp[0]["performedamount"] = CfgFn.GetNoNullDecimal(rmovtemp[0]["performedamount"])
							+ importodaEsitare;
						rmovtemp[0]["residual"] = CfgFn.GetNoNullDecimal(rmovtemp[0]["residual"]) - importodaEsitare;
					}
					else {
						DataRow rTemp = temp.NewRow();
						rTemp["idmov"] = rMovFin[idfieldmov_src];
						rTemp["curramount"] = rMovFin["importocorrente"];
						rTemp["performedamount"] = importodaEsitare;
						decimal residuo = CfgFn.GetNoNullDecimal(rTemp["curramount"]) - 
							importodaEsitare;
						rTemp["residual"] = residuo;
						temp.Rows.Add(rTemp);
					}
					residuoEsito -= importodaEsitare;
				}
				progressBar1.Value++;
				Application.DoEvents();
				rEsito.Delete();
			}
			return lanciaScript(this, destConn, bankTransaction, "Generazione Esiti a copertura progressiva dei movimenti finanziari");
		}

		/// <summary>
		/// Metodo contenitore che chiama i metodi per la generazione delle esitazioni
		/// </summary>
		/// <param name="form"></param>
		/// <param name="sourceConn"></param>
		/// <param name="destConn"></param>
		/// <param name="IoE"></param>
		/// <returns></returns>
		public bool creaEsiti(string IoE) {
			if (!creaEsitiTotali(IoE)) {
				return false;
			}
			
			return creaEsitiParziali(IoE);
		}

		/// <summary>
		/// Metodo che aggiunge le righe nella tabelle dei movimenti bancari di EASY (PAYMENT_BANK, PROCEEDS_BANK)
		/// </summary>
		/// <param name="movBancarioSource"></param>
		/// <param name="movBancarioDest"></param>
		private void fillPBank(DataRow movBancarioSource, DataTable tMovBancarioDest, string IoE) {
			string yfield = (IoE == "I") ? "ypro" : "ypay";
			string nfield = (IoE == "I") ? "npro" : "npay";
			string idfield = (IoE == "I") ? "idpro" : "idpay";

			DataRow rDest = tMovBancarioDest.NewRow();

			rDest[yfield] = movBancarioSource["esercdocumento"];
			rDest[nfield] = movBancarioSource["numdocumento"];
			rDest[idfield] = movBancarioSource["numoperazione"];
			rDest["idreg"] = movBancarioSource["codicecreddeb"];
			rDest["description"] = movBancarioSource["descrizione"];
			rDest["amount"] = movBancarioSource["importo"];
			rDest["ct"] = DateTime.Now;
			rDest["cu"] = "-";
			rDest["lt"] = DateTime.Now;
			rDest["lu"] = "-";

			tMovBancarioDest.Rows.Add(rDest);
		}

		private void fillBankTransaction(DataRow movBancarioSource, object idMovFin, DataTable banktransaction,
			string IoE, decimal amount) {
			string yfield = (IoE == "I") ? "ypro" : "ypay";
			string nfield = (IoE == "I") ? "npro" : "npay";
			string idfield = (IoE == "I") ? "idpro" : "idpay";
			string idmov = (IoE == "I") ? "idinc" : "idexp";

			if (IoE == "E") {
				if ((idMovFin != null) && (idMovFin != DBNull.Value)) {
					idMovFin = idMovFin.ToString().Substring(0,8) + idMovFin.ToString();
				}
			}
			object nban = ht[movBancarioSource["esercdocumento"]];
			int nban_free = CfgFn.GetNoNullInt32(nban) + 1;
			ht[movBancarioSource["esercdocumento"]] = nban_free;

			DataRow rBT = banktransaction.NewRow();

			rBT["yban"] = movBancarioSource["esercmovbancario"];
			rBT["nban"] = nban_free;
			rBT["amount"] = amount;
			rBT["bankreference"] = movBancarioSource["rifbanca"];
			rBT["kind"] = movBancarioSource["tipomovbancario"];
			rBT[yfield] = movBancarioSource["esercdocumento"];
			rBT[nfield] = movBancarioSource["numdocumento"];
			rBT[idfield] = movBancarioSource["numoperazione"];
			rBT[idmov] = idMovFin;
			rBT["transactiondate"] = movBancarioSource["dataoperazione"];
			rBT["valuedate"] = movBancarioSource["datavaluta"];
			rBT["ct"] = DateTime.Now;
			rBT["cu"] = "-";
			rBT["lt"] = DateTime.Now;
			rBT["lu"] = "-";

			banktransaction.Rows.Add(rBT);
		}

		#region Gestione esecuzione Script
		/// <summary>
		/// Metodo che aggiorna la tabella dei movimenti finanziari (EXPENSE o INCOME)
		/// </summary>
		/// <param name="destConn">Connessione di destinazione</param>
		/// <param name="tMovFin">Tabella dei movimenti finanziari</param>
		private bool creaScriptAggiornaMovFin(DataTable tMovFin) {
			string idfield = (tMovFin.TableName == "expense") ? "idpay" : "idpro";
			string idmov = (tMovFin.TableName == "expense") ? "idexp" : "idinc";
			int STEP = 20;
			int currMov = 1;
			string updateCmd = "UPDATE " + tMovFin.TableName + " SET " + idfield + " = ";
			string whereClause = " WHERE " + idmov + " = ";
			
			StringWriter sw = new StringWriter();
			string sqlCmd = "";
			string aCapo = "\r\n";
			foreach(DataRow rMov in tMovFin.Rows) {
				sqlCmd += updateCmd + QueryCreator.quotedstrvalue(rMov[idfield],true)
					+ ", cu = 'JTR'"
					+ whereClause + QueryCreator.quotedstrvalue(rMov[idmov], true) + aCapo;

				if ((currMov % STEP == 0) || (currMov == tMovFin.Rows.Count)) {
					sqlCmd += "GO" + aCapo;
					sw.Write(sqlCmd);
					sw.Flush();
					sqlCmd = "";
				}
				currMov ++;
			}

			string nomeCopia = "Aggiorna " + tMovFin.TableName;
			bool ok = Download.RUN_SCRIPT(destConn, sw.GetStringBuilder(), nomeCopia);
			if (!ok) {
				StreamWriter fsw = new StreamWriter("temp.sql", false, Encoding.Default);
				fsw.Write(sw.ToString());
				fsw.Close();
				show(this, "Errore durante la copia: "+nomeCopia+"\r\nLo script lanciato si trova nel file 'temp.sql'");
			}
			sw.Close();
			return true;
		}

		public bool lanciaScript(Form form, DataAccess destConn, DataTable t, string nomeCopia) {
			if (!CopyTable(form,t,destConn,nomeCopia)){
				show(form, "Errore durante la copia: " + nomeCopia + "\r\n");
				return false;
			}
			return true;
		}

		static bool CopyTable(Form form, DataTable TT, DataAccess Dest, string title){
			try {
				DataTable Cols= Dest.SQLRunner("sp_columns "+TT.TableName);


				if (TT.Rows.Count==0) return true;
				string insert = "INSERT INTO "+TT.TableName+" VALUES(";//(
				//				foreach (DataColumn C in TT.Columns) {
				//					insert += C.ColumnName + ",";
				//				}
				//				insert = insert.Remove(insert.Length - 1, 1);
				//				insert += ") VALUES (";
				int count=0;
				string s = "";
				string err;
				FrmMeter FM= new FrmMeter(true);

				FM.StartPosition= FormStartPosition.CenterScreen;
				FM.Text=title; //"Copia della tabella "+TT.TableName;
				FM.pBar.Maximum= TT.Rows.Count;
                MetaFactory.factory.getSingleton<IFormCreationListener>().create(FM, null);
                FM.Show();

				foreach (DataRow row in TT.Rows) {
					FM.pBar.Increment(1);
					count++;

					string values = GetSQLDataValues(row,Cols);
					s += 	insert		+ values;
					if (count ==10){
						Dest.SQLRunner(s,-1, out err);
						Application.DoEvents();
						if (err!=null){
							QueryCreator.ShowError(form,"Errore",err);
							FM.Close();
							return false;
						}
						s = "";
						count=0;
					}
				}
				if (s!=""){
					Dest.SQLRunner(s,false,-1);
					s = "";
				}
				FM.Close();
				Application.DoEvents();
				return true;
			}
			catch{
				return false;
			}

		}

		private static string GetSQLDataValues(DataRow row,DataTable Cols) {
			string s = "";
			int colcount = Cols.Rows.Count;
			for (int i = 0; i < colcount; i++) {
				string valore = "";
				string colname=Cols.Rows[i]["COLUMN_NAME"].ToString();
				if (row.Table.Columns.Contains(colname))
					valore=QueryCreator.quotedstrvalue(row[colname] , true);
				else
					valore="NULL";
				s += valore + ",";
			}
			s = s.Remove(s.Length - 1, 1);
			return s + ")\r\n";
		}
		#endregion

		private void cmbDB_SelectedIndexChanged(object sender, System.EventArgs e) {
			if (!Meta.DrawStateIsDone) return;
			txtDBOrigine.Text = (cmbDB.SelectedValue == null) ? "" :  cmbDB.SelectedValue.ToString();
		}
	}
}
