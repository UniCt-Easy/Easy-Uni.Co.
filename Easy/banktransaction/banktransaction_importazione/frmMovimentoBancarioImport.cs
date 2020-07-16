/*
    Easy
    Copyright (C) 2020 UniversitÃ  degli Studi di Catania (www.unict.it)
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
using System.IO;
using metadatalibrary;
using System.Data;
using System.Threading;
using funzioni_configurazione;//funzioni_configurazione

namespace banktransaction_importazione//movimentobancario_import//
{
	/// <summary>
	/// Summary description for frmMovimentoBancarioImport.
	/// </summary>
	public class Frm_banktransaction_importazione : System.Windows.Forms.Form
	{
		private const int IMP_OK = 9;
		private const int IMP_ERRORE1 = 1;
		private const int IMP_WARNING2 = 2;
		private const int IMP_WARNING3 = 3;
		private const int IMP_WARNING4 = 4;
		private int[] risultatiImportazione = {IMP_ERRORE1, IMP_WARNING2, IMP_WARNING3, IMP_WARNING4, IMP_OK};

		private MetaData metaDMB;
		private MetaData metaLogDoc;
		private MetaData metaLogMov;
		private ArrayList elencoDocumenti;
		private bool interruzione;


		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		public vistaForm DS;
		private System.Windows.Forms.Button buttonOpenFile;
		private System.Windows.Forms.Label labelFileImportato;
		private System.Windows.Forms.DataGrid dataGridMovimentoBancario;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Button buttonInterrompi;
		private System.Windows.Forms.Button buttonScriviSulDB;
		private System.Windows.Forms.Button buttonLegenda;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_banktransaction_importazione()
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
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.DS = new vistaForm();
			this.buttonOpenFile = new System.Windows.Forms.Button();
			this.labelFileImportato = new System.Windows.Forms.Label();
			this.dataGridMovimentoBancario = new System.Windows.Forms.DataGrid();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.buttonInterrompi = new System.Windows.Forms.Button();
			this.buttonScriviSulDB = new System.Windows.Forms.Button();
			this.buttonLegenda = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridMovimentoBancario)).BeginInit();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// buttonOpenFile
			// 
			this.buttonOpenFile.Location = new System.Drawing.Point(8, 8);
			this.buttonOpenFile.Name = "buttonOpenFile";
			this.buttonOpenFile.Size = new System.Drawing.Size(152, 23);
			this.buttonOpenFile.TabIndex = 1;
			this.buttonOpenFile.Text = "Scegli il file da importare...";
			this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
			// 
			// labelFileImportato
			// 
			this.labelFileImportato.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.labelFileImportato.Location = new System.Drawing.Point(160, 0);
			this.labelFileImportato.Name = "labelFileImportato";
			this.labelFileImportato.Size = new System.Drawing.Size(248, 40);
			this.labelFileImportato.TabIndex = 4;
			this.labelFileImportato.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dataGridMovimentoBancario
			// 
			this.dataGridMovimentoBancario.AllowNavigation = false;
			this.dataGridMovimentoBancario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridMovimentoBancario.DataMember = "";
			this.dataGridMovimentoBancario.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridMovimentoBancario.Location = new System.Drawing.Point(8, 40);
			this.dataGridMovimentoBancario.Name = "dataGridMovimentoBancario";
			this.dataGridMovimentoBancario.Size = new System.Drawing.Size(480, 208);
			this.dataGridMovimentoBancario.TabIndex = 5;
			this.dataGridMovimentoBancario.Tag = "";
			// 
			// progressBar1
			// 
			this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar1.Location = new System.Drawing.Point(8, 256);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(400, 23);
			this.progressBar1.TabIndex = 10;
			this.progressBar1.Visible = false;
			// 
			// buttonInterrompi
			// 
			this.buttonInterrompi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonInterrompi.Location = new System.Drawing.Point(416, 256);
			this.buttonInterrompi.Name = "buttonInterrompi";
			this.buttonInterrompi.TabIndex = 11;
			this.buttonInterrompi.Text = "Interrompi";
			this.buttonInterrompi.Visible = false;
			this.buttonInterrompi.Click += new System.EventHandler(this.buttonInterrompi_Click);
			// 
			// buttonScriviSulDB
			// 
			this.buttonScriviSulDB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.buttonScriviSulDB.Enabled = false;
			this.buttonScriviSulDB.Location = new System.Drawing.Point(216, 256);
			this.buttonScriviSulDB.Name = "buttonScriviSulDB";
			this.buttonScriviSulDB.Size = new System.Drawing.Size(80, 23);
			this.buttonScriviSulDB.TabIndex = 12;
			this.buttonScriviSulDB.Text = "Scrivi sul DB";
			this.buttonScriviSulDB.Click += new System.EventHandler(this.buttonScriviSulDB_Click);
			// 
			// buttonLegenda
			// 
			this.buttonLegenda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonLegenda.Location = new System.Drawing.Point(408, 8);
			this.buttonLegenda.Name = "buttonLegenda";
			this.buttonLegenda.TabIndex = 13;
			this.buttonLegenda.Text = "Legenda";
			this.buttonLegenda.Click += new System.EventHandler(this.buttonLegenda_Click);
			// 
			// frmMovimentoBancarioImport
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(496, 286);
			this.Controls.Add(this.buttonLegenda);
			this.Controls.Add(this.buttonScriviSulDB);
			this.Controls.Add(this.buttonInterrompi);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.dataGridMovimentoBancario);
			this.Controls.Add(this.labelFileImportato);
			this.Controls.Add(this.buttonOpenFile);
			this.Name = "frmMovimentoBancarioImport";
			this.Text = "frmMovimentoBancarioImport";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridMovimentoBancario)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region MetaData

		public void MetaData_AfterLink()
		{
			metaDMB = MetaData.GetMetaData(this, "banktransactiondetail"); 
			metaLogDoc = MetaData.GetMetaData(this, "logimportazionedocumento"); 
			metaLogMov = MetaData.GetMetaData(this, "logimportazionemovimenti"); 
			DS.log.ExtendedProperties["ExcelSort"]="id";
			DS.log.idColumn.Caption = "Id.";
			DS.log.risultato_importazioneColumn.Caption = "";
			DS.log.messaggio_importazioneColumn.Caption = "Risultato importazione";
			DS.log.entitaColumn.Caption = "Entità";
			DS.log.identificativoColumn.Caption = "Identificativo";
			DS.log.importoColumn.Caption = "Importo";
			DS.log.importo_esitatoColumn.Caption = "Importo esitato";
			DS.log.importo_da_esitareColumn.Caption = "Importo da esitare";
			DS.log.importo_nel_fileColumn.Caption = "Importo nel file";
			DS.log.esitato_fileColumn.Caption = "Esitato file";
			DS.log.nuovo_importo_esitatoColumn.Caption = "Nuovo Importo Esitato";
			DS.log.data_operazioneColumn.Caption = "Data operazione";
			DS.log.data_valutaColumn.Caption = "Data valuta";
			DS.log.codice_cred_debColumn.Caption = "";
			DS.log.creditore_debitoreColumn.Caption = "Creditore/debitore";
			DS.log.descrizioneColumn.Caption = "Descrizione";
		}

		#endregion

		#region bottone "Apri file"

/// <summary>
/// Elabora un file proveniente dalla banca ed esita tutti i movimenti bancari relativi.
/// 
/// Nozioni tecniche:
/// Chiamiamo operazione (o bolletta) la singola riga contenuta nel file.
/// Ogni operazione ha un suo identificativo "rifbanca" ed un numero di documento.
/// Un documento è un raggruppamento di movimenti bancari, pertanto l'importo dell'operazione
/// è da esitare su uno o più movimenti bancari del documento indicato nella riga dell'operazione. 
// 
/// Dettagli:
/// Fa scegliere all'utente il file della banca con tutte le bollette da esitare.
/// Legge tutto il file e per ogni riga chiama il metodo "gestisciRiga" che
/// decifra la singola riga, riempie man mano con tali dati le tabelle DS.Tables["tabelladaimportare"] e
/// DS.Tables["storni"], e costruisce un vettore contenente un elenco di tutti i
/// documenti per i quali c'è almeno una riga che fa riferimento.
/// Esegue gli eventuali storni (ossia elimina le operazioni successivamente annullate).
/// Per ogni numero di documento trovato, chiama il metodo esitaUnDocumento 
/// che esita tutti gli importi delle operazioni che fanno riferimento a quel numero di documento.
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
		private void buttonOpenFile_Click(object sender, System.EventArgs e)
		{
			DialogResult dialogResult = openFileDialog1.ShowDialog(this);
			if (dialogResult==DialogResult.Cancel) return;
			buttonScriviSulDB.Visible = false;
			buttonInterrompi.Enabled = false;
			buttonInterrompi.Visible = true;
			progressBar1.Visible = true;
			Cursor = Cursors.WaitCursor;
			dataGridMovimentoBancario.DataSource = null;
			elencoDocumenti = new ArrayList();
			labelFileImportato.Text = "Importazione di "+openFileDialog1.FileName;
			this.Refresh();

			Stream stream = openFileDialog1.OpenFile();
			progressBar1.Maximum = (int) stream.Length;
			StreamReader sr = new StreamReader(stream); 
			String line;
			int contaLinee = 0;
			while ((line = sr.ReadLine()) != null) 
			{
				progressBar1.Value = (int) stream.Position;
				if (line!="") 
				{
					contaLinee ++;
					if (gestisciRiga(line) == DialogResult.Cancel) 
					{
						Cursor = null;
						buttonInterrompi.Visible = false;
						progressBar1.Visible = false;
						return;
					}
				} 
			}
			sr.Close();

			Cursor = null;

			DataTable tStorno = DS.Tables["storno"];
			if (tStorno!=null) 
			{
				foreach(DataRow rStorno in tStorno.Select()) 
				{
					string errore =	"Riga da stornare non trovata:\n'" + QueryCreator.WHERE_CLAUSE(rStorno,DataRowVersion.Current,false,false);
					dialogResult = MessageBox.Show(this, errore, "Errore 3 nello storno", MessageBoxButtons.OKCancel);
					if (dialogResult == DialogResult.Cancel) 
					{
						buttonInterrompi.Visible = false;
						progressBar1.Visible = false;
						return;
					}
				}
			}
			

			labelFileImportato.Text = contaLinee+" righe lette dal file "+openFileDialog1.FileName;
			progressBar1.Value = 0;
			progressBar1.Maximum = elencoDocumenti.Count;
			interruzione = false;
			buttonInterrompi.Enabled = true;
			int contatore = 0;
			while ((contatore<elencoDocumenti.Count) && ! interruzione) 
			{
				string filtroDocumentoSQL = elencoDocumenti[contatore].ToString();

				DataRow[] rDocumentoDaImportare = DS.Tables["documento_da_importare"].Select(filtroDocumentoSQL, "importo DESC");
				DS.banktransaction.Clear();
				DS.banktransactiondetail.Clear();
				DS.logimportazionedocumento.Clear();
				DS.logimportazionemovimenti.Clear();

				esitaUnDocumento(rDocumentoDaImportare);

				riempiLog(contatore);

				progressBar1.Value ++;
				contatore ++;
				Application.DoEvents();
			}
			buttonInterrompi.Visible = false;
			progressBar1.Visible = false;
			buttonScriviSulDB.Enabled = true;
			buttonScriviSulDB.Visible = true;
			mostraFogliExcel();
			associaGridConTable(dataGridMovimentoBancario, DS.log);
		}

		#endregion

		#region lettura del file della banca

		/// <summary>
		/// Analizza una riga del file della banca contenente i dettagli di una operazione (o bolletta).
		/// Nozioni tecniche:
		/// Ciascuna riga può essere un'operazione ad importo positivo oppure uno storno, ed in tal caso
		/// si dovrà rintracciare l'operazione equivalente ed annullarla. Se non la si trova, allora
		/// tale riga la si conserverà nella tabella degli storni per poi ricordarsi alla fine della
		/// lettura del file di ricercare ed annullare l'operazione indicata.
		/// Dettagli:
		/// Data una riga del file della banca, questo metodo decifra tale riga chiamando una opportuna stored procedure.
		/// Se è uno storno viene annullata l'operazione equivalente o (se questa non è stata letta ancora) 
		/// lo storno viene memorizzato nella tabella degli storni.
		/// Se è un'operazione allora viene memorizzata nella tabella da importare.
		/// Ogni operazione ha un riferimento ad un documento.
		/// Se il numero di documento indicato non esiste ancora nella tabella dei documenti allora questo viene aggiunto.
		/// </summary>
		/// <param name="line">riga del file della banca contenente una singola operazione od uno storno</param>
		/// <returns>OK se è andato tutto OK oppure l'utente ha ignorato un eventuale errore;
		/// CANCEL se c'è stato un errore e l'utente non lo ha ignorato.</returns>
		private DialogResult gestisciRiga(string line) 
		{
			MetaData meta = MetaData.GetMetaData(this);
			DataTable t = meta.Conn.SQLRunner("exec sp_importa_movimenti_bancari "+QueryCreator.Quote(line));
			if (t==null) 
			{
				string errore =
					"Impossibile effettuare il parsing della seguente riga:\n'"
					+ line
					+ "'\nIl messaggio di errore è il seguente: \n"
					+ meta.Conn.LastError;
				DialogResult dialogResult = MessageBox.Show(this, errore, "Errore nella chiamata a stored procedure", MessageBoxButtons.OKCancel);
				if (dialogResult == DialogResult.Cancel) return dialogResult;
			}
			DataRow r = t.Rows[0];
			bool storno;
			switch (r["transactionkind"].ToString()) 
			{
				case "MANDAT": 
				{
					r["transactionkind"] = "D";
					storno = false;
					break;
				}
				case "STOMAN":
				{
					r["transactionkind"] = "D";
					storno = true;
					break;
				}
				case "REVERS": 
				{
					r["transactionkind"] = "C";
					storno = false;
					break;
				}
				case "STOREV": 
				{
					r["transactionkind"] = "C";
					storno = true;
					break;
				}
				case "REGSOU":
				{
					r["transactionkind"] = "D";
					storno = false;
					break;
				}
				case "ANRESU":
				{
					r["transactionkind"] = "D";
					storno = true;
					break;
				}
				case "REGSOE":
				{
					r["transactionkind"] = "C";
					storno = false;
					break;
				}
				case "ANRESE":
				{
					r["transactionkind"] = "C";
					storno = true;
					break;
				}
				default: 
				{
					string errore =
						"Impossibile effettuare il parsing della seguente riga:\n'"
						+ line
						+ "'\nIl messaggio di errore è il seguente: \n"
						+ "IMPOSSIBILE RICONOSCERE IL TIPO DI MOVIMENTO";
					DialogResult dialogResult = MessageBox.Show(this, errore, "Errore nella chiamata a stored procedure", MessageBoxButtons.OKCancel);
					if (dialogResult == DialogResult.Cancel) return dialogResult;
					storno = false;
					break;
				}
			}

			string filtroDocumentoSQL, filtroDocumento; 
			getFiltri ( 
				r,	
				new string[] {"esercdocumento","numdocumento","tipomovbancario"}, 
				out filtroDocumentoSQL, 
				out filtroDocumento
				);

			string filtroBolletta = QueryCreator.WHERE_COLNAME_CLAUSE (
				r,
				new string[] {"rifbanca","esercdocumento","numdocumento","tipomovbancario"},
				DataRowVersion.Current,
				false
				);

			int indiceDocumento = elencoDocumenti.BinarySearch(filtroDocumentoSQL);
			if (storno)
			{
				//La riga letta dal file è uno storno;
				//Cerco l'operazione da stornare e la cancello. 
				DataTable tDocumentoDaImportare = DS.Tables["documento_da_importare"];
				DataRow[] rDaStornare = tDocumentoDaImportare.Select(filtroBolletta);
				if (rDaStornare.Length > 1) 
				{
					//Ho trovato più di una riga corrispondente allo storno. Errore!
					string errore =
						"Impossibile riconoscere dallo storno il movimento da cancellare:\n'"
						+ line
						+ "'\nIl messaggio di errore è il seguente: \n"
						+ rDaStornare.Length+" movimenti nel file col seguente filtro\n"
						+ filtroBolletta;
					DialogResult dialogResult = MessageBox.Show(this, errore, "Errore 1 nello storno", MessageBoxButtons.OKCancel);
					if (dialogResult == DialogResult.Cancel) return dialogResult;
				}
				if (rDaStornare.Length > 0) 
				{
					//Cancello l'operazione da stornare ed eventualmente
					//anche il documento dall'elenco dei documenti
					rDaStornare[0].Delete();
					DataRow[] rDocumento = tDocumentoDaImportare.Select(filtroDocumento);
					if (rDocumento.Length==0) 
					{
						elencoDocumenti.RemoveAt(indiceDocumento);
					}
				}
				if (rDaStornare.Length==0) 
				{
					//Non ho trovato l'operazione da stornare;
					//probabilmente sarà nelle righe successive del file.
					//Per il momento mi conservo questo storno nella tabella degli storni
					aggiungiRigaDaImportare("storno", t);
				}
			}
			else
			{
				//La riga appena letta dal file non è uno storno.
				//Controllo se è un'operazione da stornare.
				DataTable tStorno = DS.Tables["storno"];
				DataRow[] rStorno = (tStorno==null) ? null : tStorno.Select(filtroBolletta);
				if ((rStorno!=null)&&(rStorno.Length>0)) 
				{
					//Sì, è un'operazione da stornare.
					if (rStorno.Length > 1) 
					{
						//Errore! Ci sono troppi storni corrispondenti a questa operazione!
						string errore =
							"Impossibile riconoscere dal movimento l'eventuale storno associato:\n'"
							+ line
							+ "'\nIl messaggio di errore è il seguente: \n"
							+ rStorno.Length+" storni nel file col seguente filtro\n"
							+ filtroBolletta;
						DialogResult dialogResult = MessageBox.Show(this, errore, "Errore 2 nello storno", MessageBoxButtons.OKCancel);
						if (dialogResult == DialogResult.Cancel) return dialogResult;
					}
					if (rStorno.Length == 1) 
					{
						//OK, l'operazione appena letta era da stornare e quindi la ignoro.
						//Inoltre cancello lo storno corrispondente.
						rStorno[0].Delete();
					}
				}
				else 
				{
					//La riga letta non è uno storno e non è nemmeno un'operazione da stornare.
					//Quindi la aggiungo alla tabella da importare
					//ed eventualmente aggiungo il documento se non era già stato inserito.
					if (indiceDocumento<0) 
					{
						elencoDocumenti.Insert(-indiceDocumento-1, filtroDocumentoSQL); 
					}
					aggiungiRigaDaImportare("documento_da_importare", t);
				}

			}
			return DialogResult.OK;
		}

		/// <summary>
		/// Se nel dataset DS esiste una tabella con un dato nome, allora il contenuto di un'altra
		/// tabella viene travasato nella prima, altrimenti la seconda tabella viene aggiunta al dataset.
		/// </summary>
		/// <param name="tableName">nome della tabella che si vuole aggiornare</param>
		/// <param name="t">tabella contenente i dati da travasare</param>
		private void aggiungiRigaDaImportare(string tableName, DataTable t) 
		{
			DataTable tDocumentoDaImportare = DS.Tables[tableName];
			if (tDocumentoDaImportare==null) 
			{
				PostData.MarkAsTemporaryTable(t, false);
				t.TableName = tableName;
				tDocumentoDaImportare = t;
				DS.Tables.Add(t);
			} 
			else 
			{
				DataRow r = t.Rows[0];
				DataRow rDaImportare = tDocumentoDaImportare.NewRow();
				foreach (DataColumn c in tDocumentoDaImportare.Columns) 
				{
					rDaImportare[c] = r[c.ColumnName];
				}
				tDocumentoDaImportare.Rows.Add(rDaImportare);
			}
		}

		#endregion

		#region esita un documento

/// <summary>
/// Prerequisito:
/// Le righe passate come parametro devono essere tutte le righe del file della banca relative ad un documento dato.
/// 
/// Scopo:
/// Esitare un documento.
/// 
/// Dettagli:
/// Questo metodo seleziona dal db tutti i movimenti del documento.
/// Calcola poi le varie somme degli importi verificando la coerenza di tali somme con quelle indicate
/// nel file della banca. 
/// 
/// Diamo le seguenti definizioni:
/// sommaFile = somma degli importi delle operazioni del file della banca del documento dato.
/// importoEsitatoDB: somma degli importi esitati sul DB relativi al documento dato.
/// importoDaEsitareAncoraDalFileSulDB = sommaFile - importoEsitatoDB;
/// 
/// Questo metodo chiamerà aggiornaMovimentiBancari per esitare i vari importi delle operazioni fino
/// a quando l'importoDaEsitareAncoraDalFileSulDB verrà totalmente esitato
/// </summary>
/// <param name="rDocumentoDaImportare">Operazioni contenute nel file della banca relative ad un documento</param>
		private void esitaUnDocumento (DataRow[] rDocumentoDaImportare) 
		{
			DataRow primaRigaDaImportare = rDocumentoDaImportare[0];

			string filtroDocumentoSQL, filtroDocumento; 
			getFiltri ( 
				primaRigaDaImportare,	
				new string[] {"esercdocumento","numdocumento","tipomovbancario"}, 
				out filtroDocumentoSQL, 
				out filtroDocumento
				);

			decimal sommaFile = 0;
			foreach (DataRow rDaImportare in rDocumentoDaImportare) 
			{
				sommaFile += CfgFn.GetNoNullDecimal(rDaImportare["importo"]);
			}

			decimal importoDB, importoEsitatoDB;

			leggiDocumento(filtroDocumentoSQL, out importoDB, out importoEsitatoDB);

			decimal sommaDaEsitareSulDB = importoDB - importoEsitatoDB;
			int risultatoControllo;

			controllaDocumento (
				filtroDocumentoSQL, 
				rDocumentoDaImportare, 
				importoDB, 
				importoEsitatoDB, 
				sommaFile,
				out risultatoControllo
				);

			DataRow rLogDoc = logDocumento(primaRigaDaImportare, risultatoControllo, importoDB, importoEsitatoDB, sommaFile);

			decimal importoDaEsitareAncoraDalFileSulDB = sommaFile - importoEsitatoDB;

			foreach (DataRow rDaImportare in rDocumentoDaImportare) 
			{
				logFile(rLogDoc, rDaImportare);

				if (importoDaEsitareAncoraDalFileSulDB > 0) 
				{
					decimal importoDaEsitare = CfgFn.GetNoNullDecimal(rDaImportare["importo"]);
					if (importoDaEsitare > importoDaEsitareAncoraDalFileSulDB) 
					{
						importoDaEsitare = importoDaEsitareAncoraDalFileSulDB;
					}
					string filtroDocumentoEFlagEsito = filtroDocumento+ " and (performed<>" + QueryCreator.Quote("S") + ")";

					aggiornaMovimentiBancari(rLogDoc, rDaImportare, filtroDocumentoEFlagEsito, importoDaEsitare);

					importoDaEsitareAncoraDalFileSulDB -= importoDaEsitare;
				}
			}
		}


		/// <summary>
		/// Prerequisito:
		/// I movimenti e le operazioni passate come parametro si devono riferire ad un unico documento.
		/// 
		/// Scopo:
		/// Verifica tutti i movimenti dati. 
		/// 
		/// Definizioni: 
		/// sommaFile: la somma degli importi di tutte le operazioni del file della banca relativi al documento dato.
		/// importoEsitatoDB: la somma di tutti gli importi esitati nel db di movimenti relativi al documento dato.
		/// importoDB: la somma degli importi dei movimenti nel dB relativi al documento dato.
		/// importoDaEsitareDB: la differenza fra importoDB e importoEsitatoDB.
		/// 
		/// Condizioni di errore o warning segnalate:
		/// Errore1: sommaFile maggiore di importoDB  (impossibile che la banca abbia importi maggiori di quelli contenuti nel DB)
		/// Warning2: sommaFile minore di importoDaEsitareDB (probabile che nel file della banca manchino alcune operazioni non ancora esitate.)
		/// Warning3: sommaFile minore di importoEsitatoDB (probabile che nel file della banca manchino alcune operazioni già esitate.)
		/// Warning4: sommaFile uguale a importoEsitatoDB (tutti i movimenti di tale documenti erano già stati esitati in precedenza.)
		/// </summary>
		/// <param name="filtroDocumentoSQL">filtro che permette la selezione dei movimenti di un documento</param>
		/// <param name="rDocumentoDaImportare">Operazioni bancarie che fanno riferimento al documento</param>
		/// <param name="importoDB">la somma degli importi dei movimenti nel dB relativi al documento dato.</param>
		/// <param name="importoEsitatoDB">la somma di tutti gli importi esitati nel db di movimenti relativi al documento dato.</param>
		/// <param name="sommaFile">la somma degli importi di tutte le operazioni del file della banca relativi al documento dato.</param>
		/// <param name="risultatoControllo">codice di ritorno relativo alla eventuale condizione di OK, warning o errore rilevato.</param>
		private void controllaDocumento (
			string filtroDocumentoSQL, DataRow[] rDocumentoDaImportare,
			decimal importoDB, decimal importoEsitatoDB, decimal sommaFile,
			out int risultatoControllo
			) 
		{
			decimal importoDaEsitareDB = importoDB - importoEsitatoDB;

			risultatoControllo = IMP_OK;

			if (sommaFile < importoEsitatoDB) 
			{
				risultatoControllo = IMP_WARNING3;
			}

			if (sommaFile == importoEsitatoDB) 
			{
				risultatoControllo = IMP_WARNING4;
			}

			if (sommaFile < importoDaEsitareDB) 
			{
				risultatoControllo = IMP_WARNING2;

				string errore = "Per questo documento l'importo da esitare nel db è maggiore di quello contenuto nel file."
					+"\n"+filtroDocumentoSQL;

				string titolo = (sommaFile < importoDaEsitareDB)
					? "Warning 2: Nel file mancano altri importi da esitare per il documento"
					: "Errore: Impossibile esitare tutti gli importi per il documento";
				
			}

			if (sommaFile > importoDB) 
			{
				risultatoControllo = IMP_ERRORE1;

				string errore = "Per questo documento, la somma degli importi nel file è maggiore della somma degli importi nel DB."
					+"\n"+filtroDocumentoSQL;
				
			}
		}

		/// <summary>
/// Legge dal DB tutti i movimenti bancari (ed i relativi dettagli) che fanno parte di un documento.
/// </summary>
/// <param name="filtroDocumentoSQL">filtro che seleziona i movimenti che appartengono ad un documento</param>
/// <param name="importo">importo complessivo di tutti i movimenti di quel documento</param>
/// <param name="importoEsitato">importo esitato su tutti i movimenti di quel documento</param>
		private void leggiDocumento (
			string filtroDocumentoSQL, 
			out decimal importo,
			out decimal importoEsitato
			) 
		{
			MetaData meta = MetaData.GetMetaData(this);


			DS.Tables["banktransaction"].Clear();
			//Caricamento movimenti bancari filtrati per (esercdocumento, numdocumento, tipomovbancario)
			DataAccess.RUN_SELECT_INTO_TABLE(meta.Conn,
				DS.Tables["banktransaction"],
				null,
				filtroDocumentoSQL,
				null,
				true
				);

			importo = 0;
			importoEsitato = 0;
			foreach (DataRow rMovimentoBancario in DS.Tables["banktransaction"].Rows) 
			{
				importo += CfgFn.GetNoNullDecimal(rMovimentoBancario["amount"]);

				string filtroMovimentoBancarioSQL, filtroMovimentoBancario;
				getFiltri (
					rMovimentoBancario,
					new string[] {"yban","nban"},
					out filtroMovimentoBancarioSQL,
					out filtroMovimentoBancario
					);
							

				DataAccess.RUN_SELECT_INTO_TABLE(meta.Conn,
					DS.Tables["banktransactiondetail"],
					null,
					filtroMovimentoBancarioSQL, 
					null,
					true
					);

				if (rMovimentoBancario["performed"].ToString()=="S") {
					importoEsitato += CfgFn.GetNoNullDecimal(rMovimentoBancario["performedamount"]);
				} 
				else {
					foreach (DataRow rDettMovBancario in DS.Tables["banktransactiondetail"].Select(filtroMovimentoBancario)) {
						importoEsitato += CfgFn.GetNoNullDecimal(rDettMovBancario["amount"]);
					}
				}
			}		
		}

		#endregion

		#region esita i movimenti bancari a partire da una operazione

/// <summary>
/// Esita i movimenti bancari a partire da una bolletta rDaImportare della banca.
/// Dettagli:
/// Seleziona i movimenti bancari che hanno lo stesso numero di documento riportato nella bolletta e li ordina per importo decrescente.
/// Verifica se c'è tra questi un movimento bancario che ha la differenza importo-importoesitato pari all'importo della bolletta.
/// Se c'è, allora tale movimento viene esitato parzialmente o totalmente a seconda se era già stato esitato parzialmente o meno.
/// Se non c'è, allora l'importo della bolletta viene esitato un po' per ciascun movimento, fino ad estinguere possiilmente l'intero importo della bolletta.
/// </summary>
/// <param name="rLogDoc">riga di log da riempire</param>
/// <param name="rDaImportare">operazione bancaria riportata nel file</param>
/// <param name="filtroDocumentoEFlagEsito">filtro che permette la selezione dei movimenti di un documento</param>
/// <param name="sommaFile">importo del file che si dovrà esitare sul db</param>
		private void aggiornaMovimentiBancari(DataRow rLogDoc, DataRow rDaImportare, string filtroDocumentoEFlagEsito, decimal sommaFile) 
		{
			MetaData meta = MetaData.GetMetaData(this);

			DataRow[] rMovBanc = DS.Tables["banktransaction"].Select(filtroDocumentoEFlagEsito, "amount DESC");

			for (int i=0; i<rMovBanc.Length; i++) {
				decimal importoDB = CfgFn.GetNoNullDecimal(rMovBanc[i]["amount"]);
				decimal importoEsitatoDB = getImportoEsitato(rMovBanc[i]);
				decimal importoDaEsitareDB = importoDB-importoEsitatoDB;
				if (importoDaEsitareDB == sommaFile) {
					if (rMovBanc[i]["performed"].ToString()=="N") {
						esitaTotalmenteUnMovimento(rLogDoc, rMovBanc[i], rDaImportare);
					} 
					else 
					{
						esitaParzialmenteUnMovimento(rLogDoc, rMovBanc[i], rDaImportare, importoDaEsitareDB);
					}
					return;
				}
			}

			decimal totaleImportoProvenienteDalFile = sommaFile;
			int j=0;
			while ((j<rMovBanc.Length)&&(sommaFile>0)) 
			{
				decimal importoDB = CfgFn.GetNoNullDecimal(rMovBanc[j]["amount"]);
				decimal importoEsitatoDB = getImportoEsitato(rMovBanc[j]);
				decimal importoDaEsitareDB = importoDB-importoEsitatoDB;
				if (importoDaEsitareDB > 0) {
					if (sommaFile >= importoDaEsitareDB) {
						if (rMovBanc[j]["performed"].ToString()=="N") {
							esitaTotalmenteUnMovimento(rLogDoc, rMovBanc[j], rDaImportare);
						} 
						else 
						{
							esitaParzialmenteUnMovimento(rLogDoc, rMovBanc[j], rDaImportare, importoDaEsitareDB);
						}
						sommaFile -= importoDaEsitareDB;
					} 
					else 
					{
						esitaParzialmenteUnMovimento(rLogDoc, rMovBanc[j], rDaImportare, sommaFile);
						sommaFile = 0;
					}
				}
				j++;
			}

			if (sommaFile!=0) 
			{
				string errore ="Non è possibile esitare completamente il seguente record:"
					+ "\nEsercizio documento: "+rDaImportare["esercdocumento"]
					+ "\nNumero documento: "+rDaImportare["numdocumento"]
					+ "\nData operazione: "+rDaImportare["dataoperazione"]
					+ "\nData valuta: "+rDaImportare["datavaluta"]
					+ "\nImporto: "+rDaImportare["importo"]
					+ "\n\nFiltro usato:"+filtroDocumentoEFlagEsito
					+ "\n\nSi è riusciti ad esitare "+(totaleImportoProvenienteDalFile-sommaFile)+"€ invece che "+totaleImportoProvenienteDalFile+"€";
			}
		}
		#endregion

		#region esita un movimento

		/// <summary>
		/// Esita totalmente un movimento bancario, ovvero pone il "flagesito"="S" e
		/// "importoesitato"=importo contenuto nella riga rDaImportare
		/// </summary>
		/// <param name="rLogDoc">riga di log da riempire</param>
		/// <param name="rMovimentoBancario">movimento bancario da esitare totalmente</param>
		/// <param name="rDaImportare">bolletta della banca contenente l'importo da esitare</param>
		private void esitaTotalmenteUnMovimento(
			
			DataRow rLogDoc, DataRow rMovimentoBancario, DataRow rDaImportare) 
		{
			decimal importoDaEsitare = CfgFn.GetNoNullDecimal(rMovimentoBancario["amount"]) - CfgFn.GetNoNullDecimal(rMovimentoBancario["importoesitato"]);
			logMovimento(rLogDoc, rMovimentoBancario, importoDaEsitare, (decimal) rMovimentoBancario["amount"]); 
			rMovimentoBancario["bankreference"] = rDaImportare["rifbanca"];
			rMovimentoBancario["transactiondate"] = rDaImportare["dataoperazione"];
			rMovimentoBancario["valuedate"] = rDaImportare["datavaluta"];
			rMovimentoBancario["performedamount"] = rMovimentoBancario["importo"];
			rMovimentoBancario["performed"] = 'S';
		}

		/// <summary>
		/// Esita parzialmente un movimento, ovvero pone il "flagesito"="P" ed incrementa "importoesitato"
		/// dell'"importoProvenienteDalFile"
		/// </summary>
		/// <param name="rLogDoc">riga di log da riempire</param>
		/// <param name="rMovimentoBancario">movimento bancario da esitare</param>
		/// <param name="rDaImportare">bolletta della banca</param>
		/// <param name="importoProvenienteDalFile">importo che si vuole esitare derivante da una bolletta bancaria
		/// che ha lo stesso numero di documento del movimento</param>
		private void esitaParzialmenteUnMovimento( DataRow rLogDoc, DataRow rMovimentoBancario, DataRow rDaImportare, decimal importoProvenienteDalFile) 
		{
			decimal importoEsitatoDB = CfgFn.GetNoNullDecimal(rMovimentoBancario["performedamount"]);
			logMovimento(rLogDoc, rMovimentoBancario, importoProvenienteDalFile, importoEsitatoDB + importoProvenienteDalFile); 
			rMovimentoBancario["bankreference"] = rDaImportare["rifbanca"];
			rMovimentoBancario["performedamount"] = importoEsitatoDB + importoProvenienteDalFile;
			rMovimentoBancario["performed"] = 'P';

			metaDMB.SetDefaults(DS.Tables["banktransactiondetail"]);
			DataRow nuovoDettMovBanc =  metaDMB.Get_New_Row(rMovimentoBancario, DS.Tables["banktransactiondetail"]);

			nuovoDettMovBanc["bankreference"] = rDaImportare["rifbanca"];
			nuovoDettMovBanc["transactiondate"] = rDaImportare["dataoperazione"];
			nuovoDettMovBanc["valuedate"] = rDaImportare["datavaluta"];
			nuovoDettMovBanc["amount"] = importoProvenienteDalFile;
		}

		#endregion

		#region log

		/// <summary>
		/// Scrive una riga di log relativa ad un documento.
		/// In essa vengono indicate le somme degli importi di tutti i movimenti nel db relativi al documento dato
		/// e le somme degli importi delle operazioni bancarie relative sempre al documento dato.
		/// </summary>
		/// <param name="primaRigaDaImportare">riga di un'operazione bancaria</param>
		/// <param name="risultato">codice indicante il risultato dell'importazione del documento. Può essere un errore, uno dei tre warning o un OK</param>
		/// <param name="importoDB">somma degli importi dei movimenti nel db</param>
		/// <param name="importoEsitatoDB">somma degli importi esitati nei movimenti del db</param>
		/// <param name="sommaFile">somma degli importi delle operazioni nel file della banca.</param>
		/// <returns>riga di log riempita</returns>
		private DataRow logDocumento (DataRow primaRigaDaImportare, int risultato, decimal importoDB, decimal importoEsitatoDB, decimal sommaFile) 
		{
			metaLogDoc.SetDefaults(DS.Tables["logimportazionedocumento"]);
			MetaData.SetDefault(DS.Tables["logimportazionedocumento"], "risultatoimportazione", risultato);
			DataRow r = metaLogDoc.Get_New_Row(null, DS.Tables["logimportazionedocumento"]);
			switch (risultato) 
			{
				case IMP_OK: r["messaggioimportazione"] = "OK"; break;
				case IMP_WARNING2: r["messaggioimportazione"] = "WARNING 2: file < importoDaEsitareDB"; break;
				case IMP_WARNING3: r["messaggioimportazione"] = "WARNING 3: file < importoEsitatoDB"; break;
				case IMP_WARNING4: r["messaggioimportazione"] = "WARNING 4: file = importoEsitatoDB"; break;
				case IMP_ERRORE1: r["messaggioimportazione"] = "ERRORE: file > importoDB"; break;
			}
			r["esercdocumento"] = primaRigaDaImportare["esercdocumento"];
			r["numdocumento"] = primaRigaDaImportare["numdocumento"];
			r["tipomovbancario"] = primaRigaDaImportare["tipomovbancario"];
			r["risultatoimportazione"] = risultato;
			r["importo"] = importoDB;
			r["importoesitato"] = importoEsitatoDB;
			r["importodaesitare"] = importoDB - importoEsitatoDB;
			r["importonelfile"] = sommaFile;
			decimal importoDaEsitareDB = importoDB - importoEsitatoDB;
			decimal importoDaEsitareFile = (sommaFile >= importoEsitatoDB)
				? sommaFile - importoEsitatoDB
				: 0;
			r["esitatofile"] = (importoDaEsitareDB < importoDaEsitareFile)
				? importoDaEsitareDB
				: importoDaEsitareFile;
			return r;
		}

		/// <summary>
		/// Scrive una riga di log che contiene le informazioni di un'operazione bancaria.
		/// </summary>
		/// <param name="rLogDoc">Riga di log relativa all'importazione del documento, documento di cui fa parte l'operazione che si vuole loggare</param>
		/// <param name="rDaImportare">Riga del file della banca contenente le informazioni relative all'operazione che si vuole loggare</param>
		private void logFile (
			DataRow rLogDoc, DataRow rDaImportare) 
		{
			metaLogMov.SetDefaults(DS.Tables["logimportazionemovimenti"]);
			DataRow r = metaLogMov.Get_New_Row(rLogDoc, DS.Tables["logimportazionemovimenti"]);
			r["entita"] = "FILE";
			r["tipomovbancario"] = rDaImportare["tipomovbancario"];
			r["descrizione"] = rDaImportare["descrizione"];
			r["rifbanca"] = rDaImportare["rifbanca"];
			r["dataoperazione"] = rDaImportare["dataoperazione"];
			r["datavaluta"] = rDaImportare["datavaluta"];
			r["importonelfile"] = rDaImportare["importo"];
			r["esercdocumento"] = rDaImportare["esercdocumento"];
			r["numdocumento"] = rDaImportare["numdocumento"];
			r["creditoredebitore"] = rDaImportare["creditoredebitore"];
		}
		/// <summary>
		/// Scrive una riga di log relativa alle operazioni effettuate su di un movimento bancario.
		/// </summary>
		/// <param name="rLogDoc">Riga di log relativa all'importazione del documento di cui questo movimento fa parte</param>
		/// <param name="rMovimentoBancario">movimento bancario elaborato</param>
		/// <param name="importoProvenienteDalFile">importo esitato su tale movimento a seguito dell'operazione bancaria indicata</param>
		/// <param name="nuovoImportoEsitato">importo esitato del movimento bancario aggiornato</param>
		private void logMovimento (
			DataRow rLogDoc, DataRow rMovimentoBancario, decimal importoProvenienteDalFile, decimal nuovoImportoEsitato) 
		{
			decimal importo = CfgFn.GetNoNullDecimal(rMovimentoBancario["importo"]);
			decimal importoEsitato = CfgFn.GetNoNullDecimal(rMovimentoBancario["importoesitato"]);

			metaLogMov.SetDefaults(DS.Tables["logimportazionemovimenti"]);
			DataRow r = metaLogMov.Get_New_Row(rLogDoc, DS.Tables["logimportazionemovimenti"]);
			r["entita"] = "MOVIMENTO";
			r["esercmovbancario"] = rMovimentoBancario["esercmovbancario"];
			r["nummovbancario"] = rMovimentoBancario["nummovbancario"];
			r["tipomovbancario"] = rMovimentoBancario["tipomovbancario"];
			r["descrizione"] = rMovimentoBancario["descrizione"];
			r["rifbanca"] = rMovimentoBancario["rifbanca"];
			r["dataoperazione"] = rMovimentoBancario["dataoperazione"];
			r["datavaluta"] = rMovimentoBancario["datavaluta"];
			r["importo"] = importo;
			r["importoesitato"] = importoEsitato;
			r["importodaesitare"] = importo - importoEsitato;
			r["esitatofile"] = importoProvenienteDalFile;
			r["nuovoimportoesitato"] = nuovoImportoEsitato;
			r["flagesito"] = rMovimentoBancario["flagesito"];
			r["esercdocumento"] = rMovimentoBancario["esercdocumento"];
			r["numdocumento"] = rMovimentoBancario["numdocumento"];
			r["numoperazione"] = rMovimentoBancario["numoperazione"];
			r["codicecreddeb"] = rMovimentoBancario["codicecreddeb"];
			r["creditoredebitore"] = metaLogMov.Conn.DO_READ_VALUE("registry", QueryCreator.WHERE_COLNAME_CLAUSE ( 
				rMovimentoBancario,
				new string[] {"idreg"},
				DataRowVersion.Current,
				true
				), "title"
				);
		}

		/// <summary>
		/// Nozioni tecniche:
		/// Il log è organizzato a blocchi. Ciascun blocco è relativo all'importazione di un documento.
		/// La prima riga contiene l'esito dell'importazione e gli importi complessivi di tutti i movimenti 
		/// e operazioni di quel documento.
		/// All'interno del blocco segue poi una sequenza di una riga relativa ad un'operazione seguita da una
		/// o più righe relative ai movimenti sui quali sono stati esitati delle somme provenienti dall'importo
		/// dell'operazione indicata.
		/// 
		/// Scopo:
		/// A partire dalle tabelle precedentemente riempite "logimportazionedocumento" e "logimportazionemovimenti"
		/// riempie una nuova tabella "log" che servirà a riempire il foglio excel da mostrare all'utente
		/// prima di aggiornare il db.
		/// Questo metodo aggiunge alla tabella "log" le righe di log relative all'importazione di un documento.
		/// </summary>
		/// <param name="contatoreDocumenti">numero progressivo del documento che si intende loggare</param>
		private void riempiLog(int contatoreDocumenti) 
		{
			DataRow rDoc = DS.Tables["logimportazionedocumento"].Rows[0];
			DataRow[] rFigli = rDoc.GetChildRows("logimportazionedocumentologimportazionemovimenti");

			int contatoreRighe = Convert.ToInt32(rDoc["risultatoimportazione"])*100000000+contatoreDocumenti*1000;

			DataRow rLog = DS.log.NewRow();
			rLog["id"] = contatoreRighe;
			rLog["risultato_importazione"] = rDoc["risultatoimportazione"];
			rLog["messaggio_importazione"] = rDoc["messaggioimportazione"];
			rLog["entita"] = (rDoc["tipomovbancario"].ToString()=="D") ? "MANDATO" : "REVERSALE";
			string id = rLog["entita"].ToString().Substring(0,3);
			rLog["identificativo"] = rDoc["esercdocumento"]+"-"+id+"-"+rDoc["numdocumento"]+"-"+rDoc["tipomovbancario"];
			rLog["importo"] = rDoc["importo"];
			rLog["importo_esitato"] = rDoc["importoesitato"];
			rLog["importo_da_esitare"] = rDoc["importodaesitare"];
			rLog["importo_nel_file"] = rDoc["importonelfile"];
			rLog["esitato_file"] = rDoc["esitatofile"];
			rLog["nuovo_importo_esitato"] = (decimal)rDoc["importoesitato"] + (decimal)rDoc["esitatofile"];

			DS.log.Rows.Add(rLog);
			contatoreRighe ++;

			foreach (DataRow rMov in rFigli) 
			{
				rLog = DS.log.NewRow();

				rLog["id"] = contatoreRighe;
				contatoreRighe ++;
				string entita = rMov["entita"].ToString();
				rLog["entita"] = entita;
				rLog["identificativo"] = (entita=="MOVIMENTO") 
					? rMov["esercmovbancario"]+"-MOV-"+rMov["nummovbancario"]
					: rMov["esercdocumento"]+"-FILE-"+rMov["rifbanca"];
				rLog["importo"] = rMov["importo"];
				rLog["importo_esitato"] = rMov["importoesitato"];
				rLog["importo_da_esitare"] = rMov["importodaesitare"];
				rLog["importo_nel_file"] = rMov["importonelfile"];
				rLog["esitato_file"] = rMov["esitatofile"];
				rLog["nuovo_importo_esitato"] = rMov["nuovoimportoesitato"];
				rLog["creditore_debitore"] = rMov["creditoredebitore"];
				rLog["descrizione"] = rMov["descrizione"];
				rLog["data_operazione"] = rMov["dataoperazione"];
				rLog["data_valuta"] = rMov["datavaluta"];
				DS.log.Rows.Add(rLog);
			}
			rLog = DS.log.NewRow();
			rLog["id"] = contatoreRighe;
			DS.log.Rows.Add(rLog);
		}

		#endregion

		#region visualizzazione risultati

		/// <summary>
		/// Risolve una limitazione di excel che impedisce di costruire un foglio con più di 65536 righe.
		/// Pertanto i dati contenuti in DS.log vengono spezzati in più fogli facendo attenzione
		/// a non spezzare le righe che si riferiscono allo stesso documento.
		/// </summary>
		private void mostraFogliExcel() 
		{
			if (DS.log.Rows.Count<=65536) 
			{
				exportclass.DataTableToExcel(DS.log, true);
				return;
			}
			DataRow[] rLog = DS.log.Select(null, "id");
			int inizio = 0;
			while (inizio < rLog.Length)
			{
				DataTable tLog = new DataTable();
				foreach (DataColumn c in DS.log.Columns) 
				{
					DataColumn cNuova = tLog.Columns.Add(c.ColumnName, c.DataType, c.Expression);
					cNuova.Caption = c.Caption;
				}
				tLog.ExtendedProperties["ExcelSort"]="id";

				int fine = rLog.Length;

				if (rLog.Length - inizio > 65536) 
				{
					fine = inizio + 65536;
					while (Convert.ToInt32(rLog[fine]["id"]) % 1000 != 0) fine--;
				}

				for (int i=inizio; i<fine; i++) 
				{
					tLog.Rows.Add(rLog[i].ItemArray);
				}
				exportclass.DataTableToExcel(tLog, true);
				inizio = fine;
			}
		}

		#endregion

		#region bottoni "Scrivi sul DB" e "Interrompi"

		private void buttonInterrompi_Click(object sender, System.EventArgs e)
		{
			interruzione = true;
		}

		private void buttonScriviSulDB_Click(object sender, System.EventArgs e)
		{
			scriviSulDB();
		}

		#endregion

		#region Aggiornamento del DataBase
/// <summary>
/// Riesegue tutte le elaborazioni (esita nuovamente i movimenti a partire dagli importi delle operazioni
/// indicate nel file della banca),
/// stavolta però tutti gli aggiornamenti effettuati nel DataSet DS verranno effettuati anche nel DataBase.
/// </summary>
		private void scriviSulDB() 
		{
			labelFileImportato.Text = "Scrittura sul db di "+elencoDocumenti.Count+" documenti";
			DS.log.Clear();
			MetaData meta = MetaData.GetMetaData(this); 

			progressBar1.Value = 0;
			progressBar1.Maximum = elencoDocumenti.Count;
			buttonScriviSulDB.Visible = false;
			buttonInterrompi.Visible = true;
			progressBar1.Visible = true;
			interruzione = false;
			int contaDocumenti = 0;
			int contaScritture = 0;
			while ((contaDocumenti<elencoDocumenti.Count) && ! interruzione) 
			{
				string filtroDocumentoSQL = elencoDocumenti[contaDocumenti].ToString();

				DataRow[] rDocumentoDaImportare = DS.Tables["documento_da_importare"].Select(filtroDocumentoSQL);
				DS.banktransaction.Clear();
				DS.banktransactiondetail.Clear();
				DS.logimportazionedocumento.Clear();
				DS.logimportazionemovimenti.Clear();

				esitaUnDocumento(rDocumentoDaImportare);

				progressBar1.Value ++;
				contaDocumenti ++;
				Application.DoEvents();

				PostData postData = meta.Get_PostData();
				postData.InitClass(DS, meta.Conn);
				if (postData.DO_POST()) 
				{
					contaScritture ++;
				}
				else
				{
					string messaggio = "Errore durante la scrittura sul db\n"+filtroDocumentoSQL
						+ "\n\nPremere OK per ignorare questo documento e procedere col successivo."
						+ "\nPremere ANNULLA per annullare l'importazione dei dati.";
					if (MessageBox.Show(this, messaggio, "Errore!", MessageBoxButtons.OKCancel)
						== DialogResult.Cancel) 
					{
						buttonScriviSulDB.Enabled = false;
						buttonInterrompi.Visible = false;
						progressBar1.Visible = false;
						buttonScriviSulDB.Visible = true;
						return;
					}
				}
			}
			buttonScriviSulDB.Enabled = false;
			buttonInterrompi.Visible = false;
			progressBar1.Visible = false;
			buttonScriviSulDB.Visible = true;
			MessageBox.Show(this, contaScritture+" su "+contaDocumenti+" documenti aggiornati");
		}

		#endregion

		#region utilities

		/// <summary>
		/// Calcola l'importo esitato già sul DB di un movimento bancario andando a sommare gli importi nella
		/// tabella "dettmovimentobancario" (non ci fidiamo del valore contenuto in "importoesitato" 
		/// della tabella "movimentobancario")
		/// </summary>
		/// <param name="rMovimentoBancario">Movimento Bancario di cui si vuole conoscere l'importo esitato</param>
		/// <returns></returns>
		private decimal getImportoEsitato(DataRow rMovimentoBancario) 
		{
			decimal somma = 0;
			foreach (DataRow rDett in rMovimentoBancario.GetChildRows("banktransactionbanktransactiondetail")) 
			{
				somma += CfgFn.GetNoNullDecimal(rDett["amount"]);
			}
			return somma;
		}

		/// <summary>
		/// Data una riga, i nomi di alcune sue colonne, restituisce du filtri su tali colonne, 
		/// uno buono per essere usate nelle query sul db e l'altro per le query sul dataset.
		/// </summary>
		/// <param name="R"></param>
		/// <param name="Colnames"></param>
		/// <param name="filtroSQL"></param>
		/// <param name="filtro"></param>
		private void getFiltri (DataRow R, string []Colnames, out string filtroSQL, out string filtro) 
		{
			filtroSQL = QueryCreator.WHERE_COLNAME_CLAUSE(R, Colnames, DataRowVersion.Current, true);
			filtro = QueryCreator.WHERE_COLNAME_CLAUSE(R, Colnames, DataRowVersion.Current, false);
		}

		/// <summary>
		/// Riempie una griglia con i dati contenuti nella tabella
		/// </summary>
		/// <param name="grid">griglia da riempire</param>
		/// <param name="table">tabella contenente i dati</param>
		private void associaGridConTable(DataGrid grid, System.Data.DataTable table) 
		{
			grid.DataSource = null;
			/*			MetaData meta = MetaData.GetMetaData(this);
						meta.DescribeColumns(table, "default");*/
			HelpForm.SetDataGrid(grid, table);
			//			new formatgrids(grid).AutosizeColumnWidth();
		}

		#endregion

		#region bottone "Legenda"

/// <summary>
/// Visualizza una legenda del foglio excel che viene prodotto alla fine dell'importazione del file della banca
/// e prima dell'aggiornamento del db
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
		private void buttonLegenda_Click(object sender, System.EventArgs e)
		{
			StringWriter sw = new StringWriter();
			sw.WriteLine("Il foglio Excel elenca tutte le importazioni effettuate leggendo i dati dal file della banca e scrivendoli sul db nella tabella dei movimenti bancari");
			sw.WriteLine("Il foglio è diviso a blocchi di righe separati ciascuno da una riga vuota.");
			sw.WriteLine("Ogni blocco si riferisce ad un documento (mandato o reversale)");
			sw.WriteLine("La prima riga di ciascun blocco contiene il numero di tale documento e le sommatorie degli importi trovati sul db nella tabella movimenti bancari che si riferiscono a tale documento");
			sw.WriteLine("Di seguito si alternano una riga relativa ad una bolletta della banca con un insieme di righe relative ai movimenti bancari che verranno usati per esitare l'importo della bolletta della banca");
			sw.WriteLine();
			sw.WriteLine("Il significato dei vari campi è il seguente:");

			Frm_Legenda fLegenda = new Frm_Legenda(0);
			fLegenda.textBox1.Text = sw.ToString();

			if (DS.Tables["legenda"]==null) 
			{
				DataTable t = new DataTable("legenda");
				t.Columns.Add("colonna");
				t.Columns.Add("descrizione");
				t.Rows.Add(new string[] {"Id.", "Progressivo della riga; formato EDDDDDRRR dove E=esito operazione, DDDDD=progressivo documento, RRR=progressivo riga all'interno del documento."});
				t.Rows.Add(new string[] {"Risultato importazione", "Come si è conclusa l'importazione a cui quella riga fa riferimento."});
				t.Rows.Add(new string[] {"Identificativo", "Identificativo della riga; formato ANNO-DESCR-NUMERO, dove ANNO=esercizio, DESCR=indica se si tratta di un mandato, una reversale, un movimento o una riga del file da importare, e NUMERO=identificativo."});
				t.Rows.Add(new string[] {"Importo", "Se la riga è relativa ad un documento allora indica la somma degli importi di tutti i movimenti relativi a quel documento; se invece la riga è relativa ad un movimento allora indica il suo importo."});
				t.Rows.Add(new string[] {"Importo esitato", "Se la riga è relativa ad un documento allora indica la somma degli impoti esitati di tutti i movimenti relativi a quel documento; se invece la riga è relativa ad un movimento allora indica il suo importo esitato."});
				t.Rows.Add(new string[] {"Importo da esitare", "Differenza tra 'importo' ed 'importo esitato'"});
				t.Rows.Add(new string[] {"Importo nel file", "Se la riga è relativa ad un documento allora indica la somma degli importi indicati nella bolletta della banca relativi al documento corrente"});
				t.Rows.Add(new string[] {"", "Se invece la riga è relativa ad una bolletta della banca allora questo campo contiene l'importo indicato nella bolletta della banca"});
				t.Rows.Add(new string[] {"Esitato file", "Se la riga è relativa ad un documento allora indica la differenza tra la somma degli 'importo nel file' relativi al documento corrente e 'importo esitato' (se tale differenza è negativa; zero altrimenti)."}); 
				t.Rows.Add(new string[] {"", "Se invece la riga è relativa ad un movimento allora indica l'importo che verrà esitato"}); 
				t.Rows.Add(new string[] {"Nuovo Importo Esitato", "Somma tra 'importo esitato' e 'esitato file'"});
				t.Rows.Add(new string[] {"Entità", "Indica se la riga si riferisce ad un documento (mandato o reversale), ad una bolletta bancaria (file), o ad un movimento nel db (movimento)."});
				t.Rows.Add(new string[] {"Data operazione", "Data in cui è stata effettuata l'operazione"});
				t.Rows.Add(new string[] {"Data valuta", "Data della valuta con cui è stata effettuata l'operazione"});
				t.Rows.Add(new string[] {"Creditore/debitore", "Creditore o debitore a cui si riferisce l'operazione"});
				t.Rows.Add(new string[] {"Descrizione", "Descrizione dell'operazione"});
				t.AcceptChanges();
				DS.Tables.Add(t);
				PostData.MarkAsTemporaryTable(t, false);
			}
			HelpForm.SetDataGrid(fLegenda.dataGridLegenda, DS.Tables["legenda"]);
			fLegenda.Show();
		}

		#endregion

	}
}
