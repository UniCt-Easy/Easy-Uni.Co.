
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
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
using movimentofunctions;
using System.Data.OleDb;
using System.IO;
using System.Globalization;
using System.Linq;
using ep_functions;
using System.Net.Mail;
using meta_estimate;
using meta_estimatedetail;
using meta_flussocreditidetail;
using meta_flussoincassi;
using meta_income;
using meta_incomeyear;
using meta_incomelast;
using meta_invoice;
using meta_invoicedetail;
using meta_ivaregister;
using q = metadatalibrary.MetaExpression;
using CrystalDecisions.CrystalReports.Engine;
using meta_registry;
using CrystalDecisions.Shared;
using meta_flussocrediti;
using meta_flussoincassidetail;
using gestioneclassificazioni;
using meta_registryreference;
using System.Text;

namespace no_table_flussostudenti {

	// ReSharper disable once UnusedMember.Global
	public partial class Frmflussostudenti : MetaDataForm {
		private CQueryHelper _qhc;

		private QueryHelper _qhs;

		//private object _idsorkindMiurE;
		private object _idsorkindSiopeE;
		private int _nphaseSiopeE;

		private enum TipoElaborazioneIncassi {
			imponibile,
			iva,
			totali
		}
		public IOpenFileDialog openInputFileDlg;
		public IFolderBrowserDialog folderBrowserDialog1;

		public Frmflussostudenti() {
			InitializeComponent();
			openInputFileDlg = createOpenFileDialog(_openInputFileDlg);			
			folderBrowserDialog1 = createFolderBrowserDialog(_folderBrowserDialog1);

			var dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
				"flussostudenti/prog/temp");
			if (Directory.Exists(dir)) {
				saveOutputFileDlg.InitialDirectory = dir;
			}			
		}

		private ISecurity _security;
		private IMetaDataDispatcher _dispatcher;
		private IMetaData _meta;
		MetaData Meta;
		private IDataAccess _conn;
		private IFormController _ctrl;

		// ReSharper disable once InconsistentNaming
		private int esercizio;
		private IMetaModel _model;
		private int faseentratamax;
		private EP_functions epMain;
		GestioneClassificazioni ManageClassificazioni;

		// ReSharper disable once UnusedMember.Global
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
			_meta = this.getInstance<IMetaData>();
			_conn = this.getInstance<IDataAccess>();
			_dispatcher = this.getInstance<IMetaDataDispatcher>();
			_security = this.getInstance<ISecurity>();
			_ctrl = this.getInstance<IFormController>();
			_model = MetaFactory.factory.getSingleton<IMetaModel>();
			_qhc = new CQueryHelper();
			_qhs = _conn.GetQueryHelper();
			esercizio = _security.GetEsercizio();
			faseentratamax = CfgFn.GetNoNullInt32(_security.GetSys("maxincomephase"));
			var filterEsercizio = _qhs.CmpEq("ayear", esercizio);
			GetData.CacheTable(DS.license);
			GetData.CacheTable(DS.config, filterEsercizio, null, false);
			GetData.CacheTable(DS.estimatekind, null, "description", true);
			GetData.CacheTable(DS.estimatekind, null, "description", true);

			GetData.CacheTable(DS.finmotive);
			GetData.CacheTable(DS.report);
			GetData.CacheTable(DS.finmotivedetail, filterEsercizio, null, false);
			GetData.CacheTable(DS.invoicekind, null, "idinvkind", true);
			GetData.CacheTable(DS.ivakind, null, null, false);
			GetData.CacheTable(DS.invoicekindregisterkind);
			DS.registry1.setTableForReading("registry");
			_ctrl.CanCancel = false;
			_ctrl.CanInsert = false;
			_ctrl.CanInsertCopy = false;
			_ctrl.CanSave = false;
			_ctrl.SearchEnabled = false;
			_idsorkindSiopeE =
				_conn.readValue("sortingkind", q.eq("codesorkind", "SIOPE_E_18"), "idsorkind"); //era 07E_SIOPE
			_nphaseSiopeE =
				CfgFn.GetNoNullInt32(
					_conn.readValue("sortingkind", q.eq("idsorkind", _idsorkindSiopeE), "nphaseincome"));


			btnElaboraContabilizzazioni.Enabled = false;
			btnCercaContrattiDaContabilizzare.Enabled = faseentratamax > 1;

			_allButton = new[] {
				new ImportButton(btnImportaFlussoCrediti, _tracciatoFlussostudentiFaseuno),
				new ImportButton(btnImportaFlussoIncassi, _tracciatoFlussostudentiFasedue),
			};

			foreach (var ib in _allButton) {
				ib.Btn.ContextMenu = CMenu;
			}

			GestisciEditType();
			
			epMain = new EP_functions(_dispatcher as MetaDataDispatcher);
			var QHS = _conn.GetQueryHelper();
			newcomputesorting = _conn.DO_READ_VALUE("siopekind",
				QHS.AppAnd( QHS.CmpEq("codesorkind_siopeentrate", _conn.GetSys("codesorkind_siopeentrate")),
					QHS.CmpEq("ayear",CfgFn.GetNoNullInt32(_conn.GetSys("esercizio")))
				), 
				"newcomputesorting")?.ToString();
		}

		private string newcomputesorting;
		void mostraTab(TabControl Tab, TabPage TPage, TabPage TPage2, TabPage TPag3) {
			//  Mostra solo i TabPage indicati
			foreach (TabPage page in Tab.TabPages) {
				if (!((page == TPage) || (page == TPage2) || (page == TPag3))) Tab.TabPages.Remove(page);
			}

			if (Tab.TabPages.Count == 0) Tab.Visible = false;
			// ho impostato la proprietà autosize a true sul form, per permettere il ridimensionamento automatico
		}

		void GestisciEditType() {
			switch (_meta.editType) {
				case "importaflussi": {
					mostraTab(tabFunzioni, tabPageImportaFlussi, null, null);
					mostraTab(tabGrid, tabPageCreditiImportati, tabPageIncassiImportati, null);
					break;
				}

				case "elaboracrediti": {
					mostraTab(tabFunzioni, tabPageElaboraCrediti, null, null);
					mostraTab(tabGrid, tabPageDettContratti, null, null);
					break;
				}

				case "elaboraincassiconsospesi": {
					chkAncheSenzaSospesi.Checked = false;
					mostraTab(tabFunzioni, tabPageElaboraIncassi, null, null);
					mostraTab(tabGrid, tabPageFattureCreate, null, null);
					break;
				}

				case "elaboraincassisenzasospesi": {
					chkAncheSenzaSospesi.Checked = true;
					mostraTab(tabFunzioni, tabPageElaboraIncassi, null, null);
					mostraTab(tabGrid, tabPageFattureCreate, null, null);
					break;
				}

				case "annullacrediti": {
					mostraTab(tabFunzioni, tabPageAnnullaCrediti, null, null);
					mostraTab(tabGrid, tabPageCreditiAnnullati, null, null);
					break;
				}
			}

		}



		private void addColumnDati(DataTable tExcel, string fase) {
			switch (fase) {
				case "faseuno": {
					tExcel.Columns.Add("iuv", typeof(string));
					tExcel.Columns.Add("codice_fiscale_studente", typeof(string));
					tExcel.Columns.Add("causale", typeof(string));
					tExcel.Columns.Add("codice_bollettino_univoco", typeof(string));
					tExcel.Columns.Add("operazione", typeof(string));
					tExcel.Columns.Add("data_inizio_competenza", typeof(DateTime));
					tExcel.Columns.Add("data_fine_competenza", typeof(DateTime));
					tExcel.Columns.Add("codice_causale_ep_ricavo", typeof(string));
					tExcel.Columns.Add("codice_causale_ep_credito", typeof(string));
					tExcel.Columns.Add("codice_causale_finanziaria", typeof(string));
					tExcel.Columns.Add("codice_upb", typeof(string));
					tExcel.Columns.Add("importo", typeof(decimal));
					tExcel.Columns.Add("iva", typeof(decimal));
					tExcel.Columns.Add("codice_tipo_contratto", typeof(string));
					tExcel.Columns.Add("data_contabile", typeof(DateTime));
					tExcel.Columns.Add("nome_studente", typeof(string));
					tExcel.Columns.Add("cognome_studente", typeof(string));
					tExcel.Columns.Add("memorizza_causale_anagrafica", typeof(string));
					tExcel.Columns.Add("codice_causale_finanziaria_iva", typeof(string));
					tExcel.Columns.Add("codice_listino", typeof(string));

						break;
				}

				//Non usato al momento
				case "faseuno_essetre": {
					tExcel.Columns.Add("codice_tassa", typeof(string));
					tExcel.Columns.Add("codice_voce", typeof(string));
					tExcel.Columns.Add("codice_corso_laurea", typeof(string));
					tExcel.Columns.Add("codice_fiscale_studente", typeof(string));
					tExcel.Columns.Add("causale", typeof(string));
					tExcel.Columns.Add("codice_bollettino_univoco", typeof(string));
					tExcel.Columns.Add("numero_bollettino", typeof(string));
					tExcel.Columns.Add("operazione", typeof(string));
					tExcel.Columns.Add("data_inizio_competenza", typeof(DateTime));
					tExcel.Columns.Add("data_fine_competenza", typeof(DateTime));
					tExcel.Columns.Add("importo", typeof(decimal));
					tExcel.Columns.Add("codice_tipo_contratto", typeof(string));
					tExcel.Columns.Add("data_contabile", typeof(DateTime));
					tExcel.Columns.Add("data_scadenza", typeof(DateTime));
					tExcel.Columns.Add("nome_studente", typeof(string));
					tExcel.Columns.Add("cognome_studente", typeof(string));
					break;
				}

				default: {
					tExcel.Columns.Add("codice_fiscale_studente", typeof(string));
					tExcel.Columns.Add("numero_sospeso_attivo", typeof(string));
					tExcel.Columns.Add("data_incasso", typeof(DateTime));
					tExcel.Columns.Add("codice_bollettino_univoco", typeof(string));
					tExcel.Columns.Add("importo", typeof(decimal));
					tExcel.Columns.Add("iuv", typeof(string));
						break;
				}
			}

		}


		/// <summary>
		/// Importa flusso studenti da file Excel
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnFileInput_Click(object sender, EventArgs e) {

			var crediti = leggiFile(true);
			if (crediti == null) {
				return;
			}

			importaFlussoCrediti(crediti);
		}



		private struct ImportButton {
			public readonly Button Btn;
			public readonly string[] Tracciato;

			public ImportButton(Button btn, string[] tracciato) {
				Btn = btn;
				Tracciato = tracciato;
			}
		}

		private ImportButton[] _allButton;

		private void menuEnterPwd_Click(object sender, EventArgs e) {
			if (!(sender is MenuItem)) return;
			object mysender = ((MenuItem) sender).Parent.GetContextMenu()?.SourceControl;
			foreach (var ib in _allButton) {
				if (ib.Btn != mysender) continue;

                FrmShowTracciato F = new FrmShowTracciato(getTracciato(ib.Tracciato), getTableTracciato(ib.Tracciato), "struttura");
                createForm(F, null);
                F.ShowDialog();

                return;
			}
		}

		LeggiFile getReader(string[] tracciato) {
			var reader = new LeggiFile();
			var dr = openInputFileDlg.ShowDialog();
			if (dr != DialogResult.OK) {
				show("Non è stato scelto alcun file");
				txtInputFile.Text = "";
				return null;
			}

			fileName = openInputFileDlg.FileName;

			if (reader.Init(tracciato, fileName)) return reader;
			show("Non è stato importato alcun dato", "Avviso");
			return null;
		}

		private void menuItem1_Click(object sender, EventArgs e) {
			if (!(sender is MenuItem)) return;
			object mysender = ((MenuItem) sender).Parent.GetContextMenu()?.SourceControl;
			string[] tracciato = null;
			DataTable tableTracciato = null;
			foreach (var ib in _allButton) {
				if (ib.Btn != mysender) continue;
				tracciato = ib.Tracciato;
				tableTracciato = getTableTracciato(ib.Tracciato);
				break;
			}

			var reader = getReader(tracciato);
			if (reader == null) return;

			reader.GetNext();
			var rec = reader.GetCurrRecord();

			reader.Close();

            FrmShowTracciato F = new FrmShowTracciato(rec, tableTracciato, "primo record");
            createForm(F, null);
            F.ShowDialog();
        }




		/// <summary>
		/// Legge un foglio excel crediti o incassi 
		/// </summary>
		/// <param name="faseCrediti"></param>
		/// <returns></returns>
		private DataTable leggiFile(bool faseCrediti) {
			var dr = openInputFileDlg.ShowDialog();
			if (dr != DialogResult.OK) {
				show("Non è stato scelto alcun file");
				txtInputFile.Text = "";
				return null;
			}

			fileName = openInputFileDlg.FileName;
			DataTable t = null;
			if (fileName.EndsWith("xls") || fileName.EndsWith("xlsx") || fileName.EndsWith("csv")) {
				try {
					t = readCurrentSheet(faseCrediti);
					if (t == null) return null;
					txtInputFile.Text = fileName;
				}
				catch (Exception ex) {
					show(this, $"Errore nell\'apertura del file! Processo Terminato\n{ex.Message}");
					return null;
				}
			}
			else {
				show("Il file deve avere formato xls, xlsx o csv", "Errore");
			}

			_ctrl.FreshForm(true, false);
			return t;
		}

		static string getExcelType(DataColumn c) {
			if (c.DataType == typeof(int)) return "Integer";
			if (c.DataType == typeof(string)) return "Text";
			if (c.DataType == typeof(decimal)) return "Currency";
			if (c.DataType == typeof(DateTime)) return "DateTime";
			(new MetaDataForm()).show("Tipo " + c.DataType + " non trovato");
			return "Text";
		}

		/// <summary>
		/// Legge i dati dal foglio excel
		/// </summary>
		/// <param name="faseCrediti"></param>
		/// <returns></returns>
		private DataTable readCurrentSheet(bool faseCrediti) {
			var dtToImport = new DataTable();

			if (faseCrediti) {
				addColumnDati(dtToImport, "faseuno");
				impostaCaption(dtToImport, "faseuno");
			}
			else {
				addColumnDati(dtToImport, "fasedue");
				impostaCaption(dtToImport, "fasedue");
			}

			// Lettura file excel
			if (fileName.EndsWith("xls") || fileName.EndsWith("xlsx")) {
				dtToImport.Clear();
				var c = new ExcelImport();
				c.ImportTable(fileName, dtToImport, false, 2);
			}
			else {
				// Lettura file .CSV
				var pathOnly = Path.GetDirectoryName(fileName);
				if (pathOnly == null) return null;
				var connectionString = ExcelImport.CsvConnString(pathOnly, false);
				var onlyfileName = Path.GetFileName(fileName);
				var inicontent = "[" + onlyfileName + "]\r\n" +
				                 "Format = Delimited(;)\r\n" +
				                 "MaxScanRows=0\r\n" +
				                 "DecimalSymbol=,\r\n" +
				                 "CurrencyThousandSymbol=.\r\n" +
				                 "CurrencyDigits=2\r\n" +
				                 "ColNameHeader = False";
				for (var i = 0; i < dtToImport.Columns.Count; i++) {
					var nCol = i + 1;
					var c = dtToImport.Columns[i];
					var colDef = "Col" + nCol + "=" + c.ColumnName + " " + getExcelType(c);
					inicontent += "\r\n" + colDef;
				}

				var fNameIni = Path.Combine(pathOnly, "schema.ini");
				File.WriteAllText(fNameIni, inicontent);

				try {
					// open the connection to the file
					using (var connection = new OleDbConnection(connectionString)) {
						connection.Open();
						var sql = $"SELECT * FROM [{onlyfileName}]";

						// create an adapter
						using (var adapter = new OleDbDataAdapter(sql, connection)) {
							// clear the datatable to avoid old data persistant
							dtToImport.Locale = CultureInfo.CurrentCulture;
							dtToImport.Clear();
							adapter.Fill(dtToImport);
						}

						connection.Close();
					}
				}
				catch (Exception ex) {
					show(this, ex.Message);
					return null;
				}

				const int rowsToSkip = 0;
				// pulizia nomi colonne da eventuali spazi
				foreach (DataColumn c in dtToImport.Columns) {
					c.ColumnName = c.ColumnName.Trim();
				}

				for (var i = 0; i <= rowsToSkip; i++) {
					dtToImport.Rows[i].Delete();
				}

				dtToImport.AcceptChanges();
				File.Delete(fNameIni);

			}

			bool ok;
			try {
				if (faseCrediti) {
					ok = verificaCrediti(dtToImport);
					tabGrid.SelectedIndex = 0;
				}

				else {
					ok = verificaIncassi(dtToImport);
					tabGrid.SelectedIndex = 1;
				}
			}
			catch (Exception e) {
				QueryCreator.ShowException(this, "Errore nella elaborazione del file excel ", e);
				return null;
			}

			if (!ok) {
				show(this, $@"L'esame del file {fileName} ha fatto rilevare degli errori");
				return null;
			}

			return dtToImport;
		}

		///// <summary>
		///// Al momento inutilizzato perchè forse  è troppo oneroso memorizzare tutti i flussi sul db
		///// </summary>
		///// <param name="flussocrediti"></param>
		///// <param name="nomeCompletoFile"></param>
		//private void scriviFileInRigaFlusso(DataRow flussocrediti, string nomeCompletoFile) {

		//    var fs = new FileStream(nomeCompletoFile, FileMode.Open, FileAccess.Read);
		//    var n = (int)fs.Length;
		//    if (n == 0) {
		//        return;
		//    }
		//    var byteArray = new byte[n];
		//    fs.Read(byteArray, 0, n);

		//    fs.Close();
		//    flussocrediti["flusso"] = byteArray;

		//    //Meta.SaveFormData();
		//}

		void impostaCaption(DataTable dt, string fase) {
			switch (fase) {
				case "faseuno": {
					dt.Columns["iuv"].Caption = "Identificativo Univoco di Versamento";
					dt.Columns["codice_fiscale_studente"].Caption = "Cod. Fiscale Studente";
					dt.Columns["causale"].Caption = "Causale";
					dt.Columns["codice_bollettino_univoco"].Caption = "Cod. Bollettino Univoco";
					dt.Columns["operazione"].Caption = "Operazione";
					dt.Columns["data_inizio_competenza"].Caption = "Data Inizio Competenza";
					dt.Columns["data_fine_competenza"].Caption = "Data Fine Competenza";
					dt.Columns["codice_causale_ep_ricavo"].Caption = "Causale EP Ricavo o di Annullamento";
					dt.Columns["codice_causale_ep_credito"].Caption = "Causale EP Credito";
					dt.Columns["codice_causale_finanziaria"].Caption = "Causale finanziaria";
					dt.Columns["codice_upb"].Caption = "Codice UPB";
					dt.Columns["importo"].Caption = "Importo";
					dt.Columns["iva"].Caption = "Iva";
					dt.Columns["codice_tipo_contratto"].Caption = "Codice Tipo Contratto";
					dt.Columns["data_contabile"].Caption = "Data Contabile";
					dt.Columns["nome_studente"].Caption = "Nome studente";
					dt.Columns["cognome_studente"].Caption = "Cognome studente";
					dt.Columns["memorizza_causale_anagrafica"].Caption = "Memorizza causale anagrafica";
					dt.Columns["codice_causale_finanziaria_iva"].Caption = "Causale finanziaria IVA";
					dt.Columns["codice_listino"].Caption = "Codice Listino";
						break;
				}

				case "faseuno_essetre": {
					dt.Columns["codice_tassa"].Caption = "Cod. Tassa";
					dt.Columns["codice_voce"].Caption = "Cod. Voce";
					dt.Columns["codice_corso_laurea"].Caption = "Cod. Corso Laurea";
					dt.Columns["causale"].Caption = "Causale";
					dt.Columns["codice_bollettino_univoco"].Caption = "Cod. Bollettino Univoco";
					dt.Columns["operazione"].Caption = "Operazione";
					dt.Columns["data_inizio_competenza"].Caption = "Data Inizio Competenza";
					dt.Columns["data_fine_competenza"].Caption = "Data Fine Competenza";
					dt.Columns["importo"].Caption = "Importo";
					dt.Columns["codice_tipo_contratto"].Caption = "Codice Tipo Contratto";
					dt.Columns["data_contabile"].Caption = "Data Contabile";
					dt.Columns["nome_studente"].Caption = "Nome studente";
					dt.Columns["cognome_studente"].Caption = "Cognome studente";
					break;
				}

				default: {
					dt.Columns["codice_fiscale_studente"].Caption = "Cod. Fiscale Studente";
					dt.Columns["numero_sospeso_attivo"].Caption = " Numero Sospeso Attivo";
					dt.Columns["data_incasso"].Caption = "Data Contabile";
					dt.Columns["codice_bollettino_univoco"].Caption = "Cod. Bollettino Univoco";
					dt.Columns["iuv"].Caption = "Identificativo Univoco di Versamento";
						break;
				}
			}
		}

		private readonly string[] _tracciatoFlussostudentiFaseuno = {
			"iuv;Identificativo Univoco di Versamento;Stringa;100",
			"codice_fiscale_studente;Codice Fiscale Studente;Stringa;16",
			"causale;Causale (da inserire nel descrizione del dettaglio contratto);Stringa;150",
			"codice_bollettino_univoco;Codice Bollettino Univoco;Stringa;50",
			"operazione;Inserimento/Annullamento;Codificato;1;I|A",
			"data_inizio_competenza; Data Inizio Competenza;Data;10",
			"data_fine_competenza; Data Fine Competenza;Data;10",
			"codice_causale_ep_ricavo;Codice Causale EP Ricavo;Stringa;50",
			"codice_causale_ep_credito;Codice Causale EP Credito (opzionale);Stringa;50",
			"codice_causale_finanziaria;Codice Causale Finanziaria;Stringa;50",
			"codice_upb;Codice UPB;Stringa;50",
			"importo;Importo;Numero;22",
			"iva;Iva;Numero;22",
			"codice_tipo_contratto;Codice Tipo Contratto (già esistente);Stringa;50",
			"data_contabile; Data Contabile;Data;10",
			"nome_studente;Nome Studente (ai fini di creare un'anagrafica specifica);Stringa;50",
			"cognome_studente;Cognome Studente (ai fini di creare un'anagrafica specifica);Stringa;50",
			"memorizza_causale_anagrafica;Memorizza la causale di credito dell'anagrafica;Codificato;1;S|N",
			"codice_causale_finanziaria_iva;Codice Causale Finanziaria per IVA;Stringa;50",
			"codice_listino;Codice Listino;Stringa;50"
		};

		//string[] _tracciatoFlussostudentiFaseunoEssetre =
		//   {
		//        "codice_tassa;Codice Tassa;Stringa;50",
		//        "codice_voce;Codice Voce;Stringa;50",
		//        "codice_corso_laurea;Codice Corso di Laurea;Stringa;50",
		//        "codice_fiscale_studente;Codice Fiscale Studente;Stringa;16",
		//        "causale;Causale (da inserire nel descrizione del dettaglio contratto);Stringa;150",
		//        "codice_bollettino_univoco;Codice Bollettino Univoco;Stringa;50",
		//        "numero_bollettino; Numero Bollettino; Intero;10",
		//        "operazione;Inserimento/Annullamento;Codificato;1;I|A",
		//        "data_inizio_competenza; Data Inizio Competenza;Data;10",
		//        "data_fine_competenza; Data Fine Competenza;Data;10",
		//        "importo;Importo;Numero;22",
		//        "codice_tipo_contratto;Codice Tipo Contratto (già esistente);Stringa;50",
		//        "data_contabile; Data Contabile;Data;10",
		//        "nome_studente;Nome Studente (ai fini di creare un'anagrafica specifica);Stringa;50",
		//        "cognome_studente;Cognome Studente (ai fini di creare un'anagrafica specifica);Stringa;50"
		//   };

		private readonly string[] _tracciatoFlussostudentiFasedue = {
			"codice_fiscale_studente;Codice Fiscale Studente;Stringa;16",
			"numero_sospeso_attivo; Numero Sospeso Attivo; Intero;10",
			"data_incasso; Data Incasso;Data;10",
			"codice_bollettino_univoco;Codice Bollettino Univoco;Stringa;50",
			"importo;Importo Totale;Numero;22",
			"iuv;Identificativo Univoco di Versamento;Stringa;100"
		};


		private readonly Dictionary<string, int> _registry = new Dictionary<string, int>();

		private object creaAnagraficaSeNonEsiste(object oCf, object oNome, object oCognome, object causaleCredito,
			object oEmail, object oMemorizzaCausale, out string errori) {
			errori = "";
			if ((oCf == null) || (oCf == DBNull.Value)) {
				errori = "Codice fiscale studente non valorizzato";
				return DBNull.Value;
			}

			var codicefiscale = oCf.ToString().ToUpper();
			if (_registry.ContainsKey(codicefiscale)) return _registry[codicefiscale];


			var anagr = DS.registry.Select(_qhs.AppAnd(_qhs.CmpEq("cf", codicefiscale), _qhs.CmpEq("active", "S")));
			if (anagr.Length > 0) return anagr[0]["idreg"];
			var filterreg = _qhs.AppAnd(_qhs.CmpEq("cf", codicefiscale), _qhs.CmpEq("active", "S"));

			var idreg = _conn.DO_READ_VALUE("registry", filterreg, "idreg");

			if ((idreg != DBNull.Value) && (idreg != null)) {
				_registry[codicefiscale] = CfgFn.GetNoNullInt32(idreg);
				return _registry[codicefiscale];
			}

			var metaRegistry = _dispatcher.Get("registry");
			metaRegistry.SetDefaults(DS.Tables["registry"]);
			var newReg = metaRegistry.Get_New_Row(null, DS.Tables["registry"]);

			_registry[codicefiscale] = CfgFn.GetNoNullInt32(newReg["idreg"]);

			newReg["idregistryclass"] = 22; // persona fisica;
			newReg["title"] = $"{oCognome} {oNome}";
			newReg["surname"] = oCognome;
			newReg["forename"] = oNome;
			newReg["cf"] = codicefiscale;
			newReg["active"] = "S";
			newReg["residence"] = 1;
			newReg["authorization_free"] = "N";
			if (oMemorizzaCausale.ToString().ToUpper() == "S" || oMemorizzaCausale == DBNull.Value) {
				newReg["idaccmotivecredit"] = causaleCredito;
			}

			if (oEmail != DBNull.Value) {
				try {
					var emailAddress = new MailAddress(oEmail.ToString());
					var metaRegistryReference = _dispatcher.Get("registryreference");
					metaRegistryReference.SetDefaults(DS.Tables["registryreference"]);

					MetaData.SetDefault(DS.Tables["registryreference"], "idreg", newReg["idreg"]);
					var rp = metaRegistryReference.Get_New_Row(null, DS.Tables["registryreference"]);

					rp["referencename"] = "predefinito";
					rp["email"] = emailAddress;
					newReg["email_fe"] = emailAddress;
					rp["flagdefault"] = "S";
				}
				catch {
					errori = $"Indirizzo e-mail {oEmail} non valido.";
					return DBNull.Value;
				}

			}

			// Ci chiedono di non considerare più errore bloccante l'avere un codice fiscale errato
			// perchè i dati arrivano così dalla banca

			// Ricava alcune informazioni dal codice fiscale

			if (codicefiscale.Length != 16) {
				errori = $"Il codice fiscale {codicefiscale} deve essere composto da 16 caratteri!";
				//return DBNull.Value;
				return newReg["idreg"];
			}

			bool isValid;
			var lastChar = CalcolaCodiceFiscale.GetLastChar(codicefiscale.Substring(0, 15), out isValid);
			if ((!isValid) || (codicefiscale[15] != lastChar)) {
				errori = "Il codice fiscale risulta errato alla verifica dell'ultimo carattere  '" + lastChar + "'";
				return newReg["idreg"];
			}

			codicefiscale = CalcolaCodiceFiscale.normalizza(codicefiscale);
			var italiano = (codicefiscale[11] != 'Z');
			var sesso = InfoDaCodiceFiscale.Sesso(codicefiscale);
			var datanascita = InfoDaCodiceFiscale.dataNascita(_security, codicefiscale);
			if (sesso == null) errori = "Errore nella decodifica del sesso";
			if (datanascita == null) errori = "Errore nella decodifica della data di nascita";


			object idcomune = DBNull.Value;
			object idnazione = DBNull.Value;

			if (italiano) {
				idcomune = InfoDaCodiceFiscale.comune(_conn, codicefiscale);
				if (idcomune == null || idcomune.ToString() == "") {
					errori = $@"Impossibile ricavare il comune di nascita dal codice '{
							codicefiscale.Substring(11, 4)
						}'";
					return newReg["idreg"];
				}
			}
			else {
				idnazione = InfoDaCodiceFiscale.nazione(_conn, codicefiscale);
				if (idnazione == null || idnazione.ToString() == "") {
					errori = $@"Impossibile ricavare lo stato estero di nascita dal codice '{
							codicefiscale.Substring(11, 4)
						}'";
					return newReg["idreg"];
				}
			}

			if (sesso != null) newReg["gender"] = sesso;
			if (datanascita != null) newReg["birthdate"] = datanascita;
			if (idcomune != null) newReg["idcity"] = idcomune;
			if (idnazione != null) newReg["idnation"] = idnazione;

			return newReg["idreg"];
		}


		private string getTracciato(string[] tracciato) {
			var res = "";
			var pos = 0;
			foreach (var t in tracciato) {
				var ss = t.Split(';');
				var field =
					$"{ss[0].PadLeft(30)}: Pos.{pos.ToString().PadLeft(5)} lunghezza {ss[3].PadLeft(4)} Tipo: {ss[2].PadLeft(15)}";
				if (ss[2].ToLower() == "codificato") {
					field += $" Codifica:{ss[4]}";
				}

				field += $" Descrizione: {ss[1]}";
				field += "\r\n";
				pos += CfgFn.GetNoNullInt32(ss[3]);
				res += field;
			}

			return res;
		}

		private DataTable getTableTracciato(IEnumerable<string> tracciato) {
			var pos = 0;
			var T = new DataTable("t");
			T.Columns.Add("nome", typeof(string));
			T.Columns.Add("posizione", typeof(int));
			T.Columns.Add("lunghezza", typeof(string));
			T.Columns.Add("tipo", typeof(string));
			T.Columns.Add("codifica", typeof(string));
			T.Columns.Add("Descrizione", typeof(string));

			foreach (var t in tracciato) {
				var r = T.NewRow();
				var ss = t.Split(';');
				r["nome"] = ss[0];
				r["posizione"] = pos;
				r["lunghezza"] = CfgFn.GetNoNullInt32(ss[3]);
				r["tipo"] = ss[2];
				if (ss.Length == 5) r["codifica"] = ss[4];
				r["Descrizione"] = ss[1];
				pos += CfgFn.GetNoNullInt32(ss[3]);
				T.Rows.Add(r);
			}

			return T;
		}


		private object excelGetField(string tracciatoField, object val, out string errore) {
			errore = "";

			var ff = tracciatoField.Split(';');
			var fieldname = ff[0].ToLower().Trim();
			var ftype = ff[2].ToLower().Trim(); //(intero/numero/stringa/codificato/data)

			errore = "";
			//int len = Convert.ToInt32(ff[3]);
			if (val == null) return DBNull.Value;
			if (val == DBNull.Value) return val;
			if (val.ToString() == "") return DBNull.Value;
			try {
				switch (ftype) {
					case "intero": {
						var x = val.ToString().Trim().TrimStart('0');
						return x == "" ? 0 : Convert.ToInt32(x);
					}

					case "stringa":
						return val.ToString().TrimEnd(' ');
					case "numero":
						decimal numero;
						if (isNumeric(val, out numero))
							return Convert.ToDecimal(numero);
						//return decimal.Parse(val.ToString().Replace(",","."), CultureInfo.InvariantCulture);
						else {
							errore =
								$" Errore interno nel tracciato per tipo numerico {fieldname} di tipo {ftype} e di valore {val.ToString().Trim().TrimStart('0')}";
							return DBNull.Value;
						}

					case "data": // DateTime.FromOADate and DateTime.ToOADate
						//return DateTime.FromOADate(Convert.ToDouble(val));
						return ToDatetime(val);
					case "codificato": {
						var codici = ff[4].Split('|');
						if (codici.Any(t => val.ToString().ToLower() == t.ToLower())) {
							return val;
						}

						errore =
							$" Errore interno nel tracciato per tipo codificato {fieldname} di tipo {ftype} e di valore {val.ToString().Trim().TrimStart('0')}";
						return DBNull.Value;
					}

					default: {
						errore =
							$" Errore interno nel tracciato per tipo {ftype} e valore {val.ToString().Trim().TrimStart('0')}";
						return DBNull.Value;
					}
				}
			}
			catch {
				errore =
					$" Errore nella decodifica del campo {fieldname} di tipo {ftype} e di valore {val.ToString().Trim().TrimStart('0')}";
				return DBNull.Value;
			}

		}

		private static class ToCc {
			public static object getDate(object o) {
				if (o == null) return null;
				if (o == DBNull.Value) return null;
				if (o.GetType().ToString() == "DateTme") return o;

				DateTime d;
				var res = DateTime.TryParse(o.ToString(), out d);
				if (res) return d;
				return o;
			}

		}

		private object ToDatetime(object data) {
			if (data == DBNull.Value)
				return data;
			data = ToCc.getDate(data);
			var d = (DateTime) data;
			var minValue = new DateTime(1753, 1, 1);
			if (d < minValue)
				return minValue;
			var maxValue = new DateTime(9999, 12, 31);
			if (d > maxValue)
				return maxValue;

			return data;

		}


		/// <summary>
		/// Prende un valore dal foglio di excel, le riga partono da 1 e le colonne partono da 1
		/// </summary>
		/// <param name="colnumber"></param>
		/// <param name="fieldname"></param>
		/// <param name="r"></param>
		/// <param name="fase"></param>
		/// <param name="errore"></param>
		/// <returns></returns>
		object getVal(int colnumber, string fieldname, DataRow r, string fase, out string errore) {
			var fmt = fase == "faseuno"
				? _tracciatoFlussostudentiFaseuno[colnumber - 1]
				: _tracciatoFlussostudentiFasedue[colnumber - 1];

			return excelGetField(fmt, r[fieldname], out errore);
		}
		bool SiopeE_obbligatorio(){
			int flag = CfgFn.GetNoNullInt32(conn.DO_READ_VALUE("sortingkind",_qhs.CmpEq("codesorkind", "SIOPE_E_18"), "flag"));
			if ((flag & 1) == 0) return false;// SIOPE non obbligatorio
			return true;// SIOPE obbligatorio
		}
		bool verificaCrediti(DataTable dt) {
			clearAllDict();
			foreach (DataColumn c in dt.Columns) {
				if (!dt.Columns.Contains(c.ColumnName)) {
					show(this, "File non compatibile con il Tracciato del Flusso Studenti");
					return false;
				}
			}


			if (!dt.Columns.Contains("riga")) {
				dt.Columns.Add("riga");
				dt.Columns["riga"].DataType = typeof(string);
				dt.Columns["riga"].Caption = "Riga";
			}

			if (!dt.Columns.Contains("errori")) {
				dt.Columns.Add("errori");
				dt.Columns["errori"].DataType = typeof(string);
				dt.Columns["errori"].Caption = "Errori";
			}

			DataSet ds1;
			if (dt.DataSet == null) {
				ds1 = new DataSet();
				ds1.Tables.Add(dt);
			}
			else {
				ds1 = dt.DataSet;
			}

			dgrCrediti.SetDataBinding(ds1, dt.TableName);

			HelpForm.SetDataGrid(dgrCrediti, dt);
			HelpForm.SetGridStyle(dgrCrediti, dt);

			var ok = dt.Rows.Count != 0;

			var nrigacorrente = 1;

			var errCf = false;
			foreach (DataRow r in dt.Rows) {
				// Ciclare su DataTable
				// string lastcol = ExcelColumnFromNumber(tracciato_flussostudenti_faseuno.Length);
				//string row = nrigacorrente.ToString();
				string errore;
				var err = "";
				object oDataContabileOld = DBNull.Value;				
				var oIdentificativoUnivocoVersamenti = getVal(1, "iuv", r, "faseuno", out errore);
				if (errore != "") err = err + " " + errore;

				var oCodiceFiscaleStudente = getVal(2, "codice_fiscale_studente", r, "faseuno", out errore);
				if (errore != "") err = err + " " + errore;
				if (oCodiceFiscaleStudente == DBNull.Value) break;

				getVal(3, "causale", r, "faseuno", out errore);
				if (errore != "") err = err + " " + errore;
				getVal(4, "codice_bollettino_univoco", r, "faseuno", out errore);
				if (errore != "") err = err + " " + errore;
				getVal(5, "operazione", r, "faseuno", out errore);
				if (errore != "") err = err + " " + errore;
				getVal(6, "data_inizio_competenza", r, "faseuno", out errore);
				if (errore != "") err = err + " " + errore;
				getVal(7, "data_fine_competenza", r, "faseuno", out errore);
				if (errore != "") err = err + " " + errore;
				var oCodiceCausaleEpRicavo = getVal(8, "codice_causale_ep_ricavo", r, "faseuno", out errore);
				if (errore != "") err = err + " " + errore;
				var oCodiceCausaleEpCredito = getVal(9, "codice_causale_ep_credito", r, "faseuno", out errore);
				if (errore != "") err = err + " " + errore;
				var oCodiceCausaleFinanziaria = getVal(10, "codice_causale_finanziaria", r, "faseuno", out errore);
				if (errore != "") err = err + " " + errore;
				var oCodiceUpb = getVal(11, "codice_upb", r, "faseuno", out errore);
				if (errore != "") err = err + " " + errore;
				var oImporto = getVal(12, "importo", r, "faseuno", out errore);
				if (errore != "") err = err + " " + errore;
				var oIva = getVal(13, "iva", r, "faseuno", out errore);
				if (errore != "") err = err + " " + errore;
				var oCodiceTipoContratto = getVal(14, "codice_tipo_contratto", r, "faseuno", out errore);
				if (errore != "") err = err + " " + errore;
				var oDataContabile = getVal(15, "data_contabile", r, "faseuno", out errore);
				if (errore != "") err = err + " " + errore;
				getVal(16, "nome_studente", r, "faseuno", out errore);
				if (errore != "") err = err + " " + errore;
				getVal(17, "cognome_studente", r, "faseuno", out errore);
				if (errore != "") err = err + " " + errore;
				getVal(18, "memorizza_causale_anagrafica", r, "faseuno", out errore);
				if (errore != "") err = err + " " + errore;

				var oCodiceCausaleFinanziariaIVA = getVal(19, "codice_causale_finanziaria_iva", r, "faseuno", out errore);
				//La presenza di errore o assenza campo non deve bloccare l'elaborazione dei dati, perchè il campo non è obbligatorio
				//if (errore != "") err = err + " " + errore;

				if (err != "") ok = false;

				if (CfgFn.GetNoNullDecimal(oImporto) <= 0) {
					errore = " Valore non previsto per il campo importo" + " di valore " +
					         oImporto.ToString().Trim() + " : inserire un importo maggiore di zero";
					err += " " + errore;
					ok = false;

				}

				CalcolaCodiceFiscale.CheckCF(oCodiceFiscaleStudente.ToString(), out errore);

				if (errore != "") {
					errore = $" Nel codice fiscale {oCodiceFiscaleStudente} compaiono i seguenti errori: {errore}";
					err += " " + errore;
					errCf = true;
					// ok = false;
				}

				var oCodiceListino = getVal(20, "codice_listino", r, "faseuno", out errore);
				if (errore != "") err = err + " " + errore; // non bloccante

				var idupb = getIdUpb(oCodiceUpb, out errore);
				if (idupb == DBNull.Value && errore != "") {
					err += " " + errore;
					ok = false;
				}

				var idcausaleEpRicavo = getCausaleEp(oCodiceCausaleEpRicavo, out errore);
				if ((idcausaleEpRicavo == DBNull.Value) && (errore != "")) {
					err += " " + errore;
					ok = false;
				}

				var idcausaleEpCredito = getCausaleEp(oCodiceCausaleEpCredito, out errore);
				if ((idcausaleEpCredito == DBNull.Value) && (errore != "")) {
					err += " " + errore;
					ok = false;
				}

				var idcodiceTipoContratto = checkTipoContrattoAttivo(oCodiceTipoContratto, out errore);
				if ((idcodiceTipoContratto == null) && (errore != "")) {
					err += " " + errore;
					ok = false;
				}

				var idCodiceCausaleFinanziaria = getFinMotive(oCodiceCausaleFinanziaria, out errore);
				if ((idCodiceCausaleFinanziaria == DBNull.Value) && (errore != "")) {
					err += " " + errore;
					ok = false;
				}

				var idCodiceCausaleFinanziariaIVA = getFinMotiveIVA(oCodiceCausaleFinanziariaIVA, out errore);
				//if ((idCodiceCausaleFinanziaria == DBNull.Value) && (errore != "")) {
				//	err += " " + errore;
				//	ok = false;
				//}


				var idfin = getBilancioFromCausaleFin(idCodiceCausaleFinanziaria, out errore);
				if ((idfin == DBNull.Value) && (errore != "")) {
					err += " " + errore;
					ok = false;
				}
				string erroreiva;
				var idfin_iva = getBilancioFromCausaleFin(idCodiceCausaleFinanziaria, out erroreiva);
				//if ((idfin == DBNull.Value) && (errore != "")) {
				//	err += " " + errore;
				//	ok = false;
				//}
				var idsorSiope = getSiopeForAccMotive(idcausaleEpRicavo, out errore);
					if ((idsorSiope == null) && (errore != ""))
					{
						err += " " + errore;
						ok = false;
					}
				if (oDataContabile == DBNull.Value) {
					errore = "La data contabile è obbligatoria";
					err += " " + errore;
					ok = false;
				}

				if ((oDataContabileOld != DBNull.Value) && (oDataContabileOld != oDataContabile)) {
					errore = "Le righe del file devono avere tutte la stessa data contabile";
					err += " " + errore;
					ok = false;
				}

				var idList = GetIdListForCodelist(oCodiceListino, out errore);
				if ((idList == null) && (errore != "")) {
					err += " " + errore;
					ok = false;
				}

				r["riga"] = nrigacorrente;
				//R["codice_fiscale_studente"] = o_codice_fiscale_studente;
				//R["causale"] = o_causale;
				//R["codice_bollettino_univoco"] = o_codice_bollettino_univoco;
				//R["operazione"] = o_operazione;
				//R["data_inizio_competenza"] = o_data_inizio_competenza;
				//R["data_fine_competenza"] = o_data_fine_competenza;
				//R["codice_causale_ep_ricavo"] = o_codice_causale_ep_ricavo;
				//R["codice_causale_ep_credito"] = o_codice_causale_ep_credito;
				//R["codice_causale_finanziaria"] = o_codice_causale_finanziaria;
				//R["codice_upb"] = o_codice_upb;
				//R["importo"] = o_importo;
				//R["codice_tipo_contratto"] = o_codice_tipo_contratto;
				//R["data_contabile"] = o_data_contabile;
				//R["nome_studente"] = o_nome_studente;
				//R["cognome_studente"] = o_cognome_studente;
				r["errori"] = err;

				nrigacorrente++;
			}

			if (errCf && ok) {
				show(this,
					"Si sono verificati errori nella convalida di alcuni codici fiscali, potrebbero essere generate anagrafiche incomplete");
			}

			if (ok) {
				show(this, "Saranno importate " + (nrigacorrente - 1) + " righe.");
				//btnelaboraFlussoCrediti.Enabled = true;
			}


			return ok;
		}

		/// <summary>
		/// Genera le  scritture e movimenti di budget per tutti i contratti attivi nel dataset DS
		/// Effettua letture in estimatedetail per ogni riga di estimate
		/// </summary>
		/// <returns></returns>
		bool generaScrittureContrattiAttivi() {
			var estimateSkipped = new List<string>();
			foreach (var rEstim in DS.estimate) {
				DS.estimatedetail.Clear();
				DS.estimatedetail.safeMergeFromDb(_conn, q.mCmp(rEstim, "idestimkind", "yestim", "nestim"));
				var epm = new EP_Manager(_meta as MetaData, null, null, null, null, null, null, null, null, "estimate");
				epm.disableIntegratedPosting();
				epm.silent = true;
				epm.autoIgnore = true;
				epm.setForcedCurrentRow(rEstim);
				epm.beforePost();
				epm.afterPost(true);
				if (epm.ultimaGenerazioneRiuscita == false) {
					estimateSkipped.Add(descrContrattoAttivo(rEstim));
				}
			}

			if (estimateSkipped.Count > 0) {
                wndDisplay w = new wndDisplay("Contratti attivi da rivedere",
					"Per i seguenti contratti attivi non sono state generati movimenti di budget e/o scritture E/P",
					estimateSkipped);

                createForm(w, this);
                w.Show(this);
				return true;
			}

			if (DS.estimate.Rows.Count > 0) {
				show("Le scritture sui contratti attivi sono state generate.", "Avviso");
			}

			return true;
		}

		string descrContrattoAttivo(DataRow r) {
			return $"{r["idestimkind"]}/{r["yestim"]}/{r["nestim"]}";
		}

		string descrFattura(invoiceRow r) {
			string invCode = DS.invoicekind.get(_conn, q.eq("idinvkind", r.idinvkind))[0].codeinvkind;
			return $"{invCode}/{r.yinv}/{r.ninv}";
		}

		/// <summary>
		/// Effettua letture in invoicedetail per ogni riga di DS.invoice
		/// </summary>
		/// <returns></returns>
		void generoScrittureFatture() {
			var invoiceSkipped = new List<string>();
			foreach (var rInvoice in DS.invoice) {
				DS.invoicedetail.Clear();
				DS.invoicedetail.safeMergeFromDb(_conn, q.mCmp(rInvoice, "idinvkind", "yinv", "ninv"));
				var epm = new EP_Manager(_meta as MetaData, null, null, null, null, null, null, null, null, "invoice");
				epm.disableIntegratedPosting();
				epm.silent = true;
				epm.autoIgnore = true;
				epm.setForcedCurrentRow(rInvoice);
				epm.beforePost();
				epm.afterPost(true);
				if (epm.ultimaGenerazioneRiuscita == false) {
					invoiceSkipped.Add(descrFattura(rInvoice));
				}
			}

			if (invoiceSkipped.Count > 0) {
                wndDisplay w = new wndDisplay("Fatture da rivedere",
					"Per le seguenti fatture non sono state generati movimenti di budget e/o scritture E/P",
					invoiceSkipped);

                createForm(w, this);
                w.Show(this);
				return;
			}

			if (DS.invoice.Rows.Count > 0) show("Le scritture sulle fatture sono state generate.", "Avviso");
		}



		void fillMovimento(DataRow eS, object idman, object idreg, string description) {
			if (idreg == null) idreg = DBNull.Value;
			if (idman == null) idman = DBNull.Value;

			var dataCont = _security.GetDataContabile();
			eS.BeginEdit();
			eS["ymov"] = esercizio;
			eS["adate"] = dataCont;
			eS["idman"] = idman;
			//E_S["idunderwriting"] = idunderwriting;
			eS["idreg"] = idreg;
			eS["description"] = description;
			//E_S["amount"]=CfgFn.RoundValuta(amount);
			eS.EndEdit();
		}


		void fillImputazioneMovimento(DataRow impMov, decimal amount, object idfin, object idupb) {
			impMov["amount"] = amount;
			impMov["idfin"] = idfin;
			impMov["idupb"] = idupb;
		}


		private readonly Dictionary<string, int> _accMotiveSiope = new Dictionary<string, int>();

		int? getSiopeForAccMotive(object idaccmotive, out string errori) {
			errori = "";

			if (idaccmotive == DBNull.Value || idaccmotive == null) {
				errori = " La causale di Ricavo non è stata specificata";
				return null;
			}

			var sIdAccMotive = idaccmotive.ToString();
			if (_accMotiveSiope.ContainsKey(idaccmotive.ToString())) return _accMotiveSiope[sIdAccMotive];
			if (!SiopeE_obbligatorio()) return null;

			var idsor = _conn.readValue("accmotivesortingview",
				q.eq("idaccmotive", sIdAccMotive) & q.eq("idsorkind", _idsorkindSiopeE), "idsor");
			if (idsor == null || idsor == DBNull.Value) {
				string codeMotive = _conn.readValue("accmotive", q.eq("idaccmotive", idaccmotive), "codemotive")
					?.ToString();
				errori = " La causale di Ricavo " + (codeMotive ?? "") +
				         " deve essere associata a un codice SIOPE. E' necessario completare la configurazione.";
				return null;
			}

			_accMotiveSiope[sIdAccMotive] = CfgFn.GetNoNullInt32(idsor);
			return _accMotiveSiope[sIdAccMotive];

		}
 


		private readonly Dictionary<int, object> _sospesiAttivi = new Dictionary<int, object>();
		private readonly Dictionary<int, object> _causaliSospesiAttivi = new Dictionary<int, object>();
		//private readonly Dictionary<string, int> _sospesiAttiviByCausali = new Dictionary<string, int>();

		object getSospesiAttivi(object numeroSospesoAttivo, out string errori) {
			errori = "";
			if (numeroSospesoAttivo == DBNull.Value || numeroSospesoAttivo == null) return DBNull.Value;
			var numeroSospesoAttivoI = CfgFn.GetNoNullInt32(numeroSospesoAttivo);
			if (numeroSospesoAttivoI == 0) return DBNull.Value;
			if (_sospesiAttivi.ContainsKey(numeroSospesoAttivoI)) return _sospesiAttivi[numeroSospesoAttivoI];
			var filter = _qhs.AppAnd(_qhs.CmpEq("ybill", esercizio), _qhs.CmpEq("billkind", "C"),
				_qhs.CmpEq("nbill", numeroSospesoAttivoI));
			var t = _conn.SQLRunner($"select nbill  from bill   where {filter}", false);
			if (t == null) {
				errori = "Errore nell'accesso al db" + _conn.SecureGetLastError();
				return DBNull.Value;
			}

			if (t.Rows.Count == 0) {
				errori = "Il sospeso attivo n°" + numeroSospesoAttivo +
				         " non è ancora presente su DB. E' necessario eseguire prima l'importazione del giornale di Cassa. ";
				_sospesiAttivi[numeroSospesoAttivoI] = DBNull.Value;
				return DBNull.Value;
			}
			else {
				_sospesiAttivi[numeroSospesoAttivoI] = t.Rows[0]["nbill"];
				return _sospesiAttivi[numeroSospesoAttivoI];
			}

		}

		void addEstimateDateToDict(DataRow estim) {
			string estimKey = QueryCreator.hashColumns(estim, new[] {"idestimkind", "yestim", "nestim"});
			_dateContrattoAttivo[estimKey] = estim["adate"];

		}

		private readonly Dictionary<string, object> _dateContrattoAttivo = new Dictionary<string, object>();

		/// <summary>
		/// Stabilisce se idestimkind è un tipo contratto a gestione differita
		/// </summary>
		/// <param name="idestimkind"></param>
		/// <param name="errori"></param>
		/// <returns></returns>
		object getDateContrattoAttivo(DataRow estimDetail, out string errori) {
			errori = "";
			string estimKey = QueryCreator.hashColumns(estimDetail, new[] {"idestimkind", "yestim", "nestim"});
			if (_dateContrattoAttivo.ContainsKey(estimKey)) return _dateContrattoAttivo[estimKey];

			var oDate = _conn.readValue("estimate", q.mCmp(estimDetail, "idestimkind", "yestim", "nestim"), "adate");
			if (oDate == null || oDate == DBNull.Value) {
				errori = $"Il  contratto attivo  {estimKey} non è stato trovato o non ha la data contabile";
				return null;
			}

			_dateContrattoAttivo[estimKey] = oDate;
			return oDate;
		}


		private readonly Dictionary<string, string> _tipoContrattoAttivoGestioneDifferita =
			new Dictionary<string, string>();


		/// <summary>
		/// Stabilisce se idestimkind è un tipo contratto a gestione differita
		/// </summary>
		/// <param name="idestimkind"></param>
		/// <param name="errori"></param>
		/// <returns></returns>
		string getGestioneDifferita(object idestimkind, out string errori) {
			errori = "";
			//if (faseentratamax == 1)
			//	return "S"; //assumiamo che se monofase allora si contabilizza sempre solo in fase di incasso
			if (idestimkind == DBNull.Value || idestimkind == null) return "S";
			string sIdEstimKind = idestimkind.ToString();
			if (_tipoContrattoAttivoGestioneDifferita.ContainsKey(sIdEstimKind))
				return _tipoContrattoAttivoGestioneDifferita[sIdEstimKind];

			var oFlag = _conn.readValue("estimatekind", q.eq("idestimkind", idestimkind), "flag");
			if (oFlag == null || oFlag == DBNull.Value) {
				errori = $"Il tipo contratto attivo  {idestimkind} non è stato trovato";
				return "N";
			}

			var flag = CfgFn.GetNoNullInt32(oFlag);
			var differita = CfgFn.DecodeToString(flag, 1);
			_tipoContrattoAttivoGestioneDifferita[sIdEstimKind] = differita;
			return differita;
		}

		private readonly Dictionary<string, string> _tipoContrattoAttivoCollegabileAFattura =
			new Dictionary<string, string>();

		bool getCollegabileAFattura(object idestimkind) {
			if (idestimkind == DBNull.Value || idestimkind == null) return true;
			var sIdEstimKind = idestimkind.ToString();

			if (_tipoContrattoAttivoCollegabileAFattura.ContainsKey(sIdEstimKind))
				return _tipoContrattoAttivoCollegabileAFattura[sIdEstimKind].ToString() == "S";

			var linktoinvoice = _conn.readValue("estimatekind", q.eq("idestimkind", idestimkind), "linktoinvoice");
			if (linktoinvoice == null || linktoinvoice == DBNull.Value) {
				show($"Il tipo contratto attivo  {sIdEstimKind} non è stato trovato", "Errore");
				return false;
			}

			_tipoContrattoAttivoCollegabileAFattura[sIdEstimKind] = linktoinvoice.ToString().ToUpper();
			return _tipoContrattoAttivoCollegabileAFattura[sIdEstimKind].ToString() == "S";
		}

		private readonly Dictionary<string, DataRow> _attrsContrattoAttivo = new Dictionary<string, DataRow>();

		private DataRow getAttributiTipoContrattoAttivo(object idestimkind, out string errore) {
			errore = "";

			if (idestimkind == null || DBNull.Value.Equals(idestimkind)) {
				errore = "Il tipo di contratto attivo dev'essere specificato.";
				return null;
			}

			var sIdEstimKind = idestimkind.ToString();
			if (_attrsContrattoAttivo.ContainsKey(sIdEstimKind)) {
				return _attrsContrattoAttivo[sIdEstimKind];
			}

			var dt = _conn.readTable("estimatekind", q.eq("idestimkind", idestimkind),
				"idsor01, idsor02, idsor03, idsor04, idsor05");

			if (dt == null || dt.Rows.Count == 0) {
				errore = $"Il tipo contratto attivo '{idestimkind}' non è stato trovato.";
				return null;
			}

			_attrsContrattoAttivo[sIdEstimKind] = dt.Rows[0];
			return dt.Rows[0];
		}

		private readonly Dictionary<string, DataRow> _attrsUpb = new Dictionary<string, DataRow>();

		private DataRow getAttributiUpb(object idupb, out string errore) {
			errore = "";
			if (idupb == null || DBNull.Value.Equals(idupb)) {
				//errore = "L'identificativo dell'UPB dev'essere specificato.";
				return null;
			}

			var sIdUpb = idupb.ToString();

			if (_attrsUpb.ContainsKey(sIdUpb)) {
				return _attrsUpb[sIdUpb];
			}

			var dt = _conn.readTable("upb", q.eq("idupb", idupb), "idsor01, idsor02, idsor03, idsor04, idsor05");
			if (dt == null || dt.Rows.Count == 0) {
				errore = $@"L'UPB con identificativo '{sIdUpb}' non è stato trovato.";
				return null;
			}

			_attrsUpb[sIdUpb] = dt.Rows[0];
			return dt.Rows[0];
		}

		object getCausaliSospesiAttivi(object numeroSospesoAttivo, out string errori) {
			errori = "";
			if (numeroSospesoAttivo == DBNull.Value || numeroSospesoAttivo == null) return null;
			var numeroSospesoAttivoI = CfgFn.GetNoNullInt32(numeroSospesoAttivo);
			if (numeroSospesoAttivoI == 0) return null;
			if (_causaliSospesiAttivi.ContainsKey(numeroSospesoAttivoI))
				return _causaliSospesiAttivi[numeroSospesoAttivoI];

			var causaleSospeso = _conn.readValue("bill",
				q.eq("ybill", esercizio) & q.eq("billkind", "C") & q.eq("nbill", numeroSospesoAttivoI), "motive");

			if (causaleSospeso == null || causaleSospeso == DBNull.Value) {
				errori =
					$@"Il sospeso attivo n°{
							numeroSospesoAttivo
						} non è ancora presente su DB. E' necessario eseguire prima l'importazione del giornale di Cassa. ";
				return DBNull.Value;
			}

			_causaliSospesiAttivi[numeroSospesoAttivoI] = causaleSospeso;
			return causaleSospeso;

		}



		///// <summary>
		///// Ottiene il numero di sospeso ricercando mediante il campo  causale (motive), esercizio e tipo (Credito)
		///// </summary>
		///// <param name="causale"></param>
		///// <returns></returns>
		//int? getSospesiAttiviFromCausali(string causale) {
		//	if (string.IsNullOrEmpty(causale)) return null;

		//	if (_sospesiAttiviByCausali.ContainsKey(causale)) return (_sospesiAttiviByCausali[causale]==-1) ? null:(int?)_sospesiAttiviByCausali[causale];

		//	// non ha trovato la coppia causale / numero sospeso
		//	var causalePerConfronto = causale;
		//	if (!causalePerConfronto.StartsWith("/PUR/LGPE-RIVERSAMENTO/URI/")) {
		//		causalePerConfronto = $"/PUR/LGPE-RIVERSAMENTO/URI/{causale}";
		//	}

		//	var filter = q.eq("ybill", esercizio) & q.eq("billkind", "C") &
		//	             q.like("motive", "%" + causalePerConfronto + "%");
		//	var nbill = _conn.readValue("bill", filter, "nbill");

		//	if ((nbill == null || nbill == DBNull.Value) && causale != causalePerConfronto) {
		//		filter = q.eq("ybill", esercizio) & q.eq("billkind", "C") & q.like("motive", causalePerConfronto + "%");
		//		nbill = _conn.readValue("bill", filter, "nbill");
		//	}

		//	if (nbill == null || nbill == DBNull.Value) {
		//		//errori = "Il sospeso attivo avente causale " + causale +
		//		//         " non è ancora presente su DB. E' necessario eseguire prima l'importazione del giornale di Cassa. ";
		//		_sospesiAttiviByCausali[causale] = -1;
		//		return null;
		//	}

		//	_sospesiAttiviByCausali[causale] = CfgFn.GetNoNullInt32(nbill);
		//	return _sospesiAttiviByCausali[causale];
		//}


		/// <summary>
		/// Verifica che i dettagli contratto attivo aventi un dato codiceBollettinoUnivoco sia pari ad un valore dato
		/// </summary>
		/// <param name="codiceBollettinoUnivoco"></param>
		/// <param name="importo"></param>
		/// <param name="errMess"></param>
		/// <returns></returns>
		bool verifyImportoTotaleIncasso(object codiceBollettinoUnivoco, decimal importo, out string errMess) {
			// Questo metodo verifica che ogni incasso della fase "due" abbia un importo che copra completamente
			// la somma dei dettagli contratto attivo non annullati (stop = null) a parità di codice bollettino univoco 
			errMess = "";
			var rows = DS.estimatedetail._getFromDb(_conn,
				q.eq("iduniqueformcode", codiceBollettinoUnivoco) & q.isNull("stop"));

			var sumAmountDettagli = rows.Sum(r1 => CfgFn.GetNoNullDecimal(r1["taxable"]));

			if (sumAmountDettagli == importo) return true;
			errMess += "Il bollettino n° " + codiceBollettinoUnivoco + " non può essere incassato." +
			           " Il suo importo " + importo +
			           " non è uguale alla somma dei dettagli dei contratti attivi" +
			           " non annullati che è pari a :" + sumAmountDettagli;

			return false;
		}

		void fillIncomeSorted(DataRow newMovRow, object idsor, decimal amount) {
			if (idsor == DBNull.Value || idsor == null) return;

			var metaSortedMov = _dispatcher.Get("incomesorted");
			metaSortedMov.SetDefaults(DS.incomesorted);
			DS.Tables["incomesorted"].Columns["idsor"].DefaultValue = idsor;
			var sortedMovRow = metaSortedMov.Get_New_Row(newMovRow, DS.incomesorted);
			sortedMovRow["idsor"] = idsor;
			sortedMovRow["amount"] = amount;
			sortedMovRow["idinc"] = newMovRow["idinc"];
			sortedMovRow["ayear"] = esercizio;
			sortedMovRow["cu"] = "import";
			sortedMovRow["ct"] = DateTime.Now;
			sortedMovRow["lu"] = "import";
			sortedMovRow["lt"] = DateTime.Now;
		}

		/// <summary>
		/// Metodo che importa una tabella con un formato concordato con l'università di Roma Tor Vergata
		/// In particolare la tabella contiene il codice bollettino univoco (per noi iduniqueformcode) ed il numero di sospeso attivo.
		/// </summary>
		/// <param name="dt"></param>
		/// <returns></returns>
		void importaTabellaFlussoIncassi(DataTable dt) {
			var dtToImport = dt;

			DS.flussoincassi.Clear();
			DS.flussoincassidetail.Clear();
			RowChange.SetOptimized(DS.flussoincassi, true);
			RowChange.ClearMaxCache(DS.flussoincassi);
			RowChange.SetOptimized(DS.flussoincassidetail, true);
			RowChange.ClearMaxCache(DS.flussoincassidetail);

			// riempie il Dataset con le righe degli incassi e dei dettagli
			// a partire dalla tabella temporanea mData1

			var metaFlussoIncassi = _dispatcher.Get("flussoincassi");
			metaFlussoIncassi.SetDefaults(DS.flussoincassi);
			MetaData.SetDefault(DS.flussoincassi, "ayear", _security.GetEsercizio());

			var metaFlussoIncassiDetail = _dispatcher.Get("flussoincassidetail");
			metaFlussoIncassiDetail.SetDefaults(DS.flussoincassi);

			if (dtToImport.Select().Length > 0) {
				var view = new DataView(dtToImport) {Sort = "data_incasso,numero_sospeso_attivo"};

				var newTable = view.ToTable(true, "data_incasso", "numero_sospeso_attivo","iuv");
				// Ciclo per la creazione di una riga in Flusso Incassi
				
				foreach (var rFlusso in newTable.Select()) {
					var oNumeroSospesoAttivo = rFlusso["numero_sospeso_attivo"];
					var oDataIncasso = rFlusso["data_incasso"];
					object iuv = DBNull.Value;
					string errore;
					var causale = getCausaliSospesiAttivi(oNumeroSospesoAttivo, out errore);
					if (causale == null) {
						DS.flussoincassi.Clear();
						DS.flussoincassidetail.Clear();
						show(
							"Ci sono righe senza numero di sospeso attivo, l'importazione non può essere effettuata.",
							"Errore");
						return;
					}

					var rNewFlussoIncassi = metaFlussoIncassi.Get_New_Row(null, DS.flussoincassi);
					rNewFlussoIncassi["codiceflusso"] = Path.GetFileName(fileName);
					rNewFlussoIncassi["trn"] = DBNull.Value;
					rNewFlussoIncassi["causale"] = causale;

					//iuv letto da decodifica della causale della banca
					if (causale.ToString().ToUpper().Contains("/RFS/") ||
					    causale.ToString().ToUpper().Contains("/RFB/")) {
						string[] parts = causale.ToString().ToUpper().Split('/');
						iuv = parts[2];
					}
					
					rNewFlussoIncassi["dataincasso"] = oDataIncasso;
					rNewFlussoIncassi["nbill"] = oNumeroSospesoAttivo;

					rNewFlussoIncassi["ct"] = DateTime.Now;
					rNewFlussoIncassi["cu"] = "import_flussostudenti";
					rNewFlussoIncassi["lt"] = DateTime.Now;
					rNewFlussoIncassi["lu"] = "import_flussostudenti";


					// Ciclo per creare le righe corrispondenti in flussoincassiDetail
					object idupb = null;
					decimal importoTotaleFlusso = 0;
					bool containsIUV = false;
					if (dtToImport.Columns.Contains("iuv"))
					{
						containsIUV = true;
						 
					}

					foreach (var rFlussoDetail in dtToImport._Filter(
						q.eq("data_incasso", oDataIncasso) & q.eq("numero_sospeso_attivo", oNumeroSospesoAttivo))) {							
						object oIdentificativoUnivocoVersamento = DBNull.Value;
						if (containsIUV && (iuv == DBNull.Value)) {
							oIdentificativoUnivocoVersamento = rFlussoDetail["iuv"];
							iuv = oIdentificativoUnivocoVersamento;
						}						
						var oCodiceBollettinoUnivoco = rFlussoDetail["codice_bollettino_univoco"];						
						var oImporto = rFlussoDetail["importo"];
						var oCodiceFiscaleStudente = rFlussoDetail["codice_fiscale_studente"];

						var rNewFlussoIncassiDetail =
							metaFlussoIncassiDetail.Get_New_Row(rNewFlussoIncassi, DS.flussoincassidetail);
						rNewFlussoIncassiDetail["importo"] = oImporto;
						rNewFlussoIncassiDetail["iuv"] = iuv;
						rNewFlussoIncassiDetail["iduniqueformcode"] = oCodiceBollettinoUnivoco;
						rNewFlussoIncassiDetail["cf"] = oCodiceFiscaleStudente;
						rNewFlussoIncassiDetail["cu"] = "import_flussostudenti";
						rNewFlussoIncassiDetail["lu"] = "import_flussostudenti";
						//Ad un flusso incassi potrebbero essere collegati crediti aventi più upb, che potrebbero avere attributi di sicurezza discordi
						if (idupb == null || idupb == DBNull.Value) {
							if (idupb == DBNull.Value) {
								idupb = _conn.readValue("flussocreditidetail",
									q.eq("iduniqueformcode", oCodiceBollettinoUnivoco) & q.isNotNull("idupb"),
									"min(idupb)");
							}
						}

						importoTotaleFlusso += CfgFn.GetNoNullDecimal(oImporto);
					}

					if (idupb != null && idupb != DBNull.Value) {
						var attrs = getAttributiUpb(idupb, out errore);
						if (attrs != null) {
							rNewFlussoIncassi["idsor01"] = attrs["idsor01"];
							rNewFlussoIncassi["idsor02"] = attrs["idsor02"];
							rNewFlussoIncassi["idsor03"] = attrs["idsor03"];
							rNewFlussoIncassi["idsor04"] = attrs["idsor04"];
							rNewFlussoIncassi["idsor05"] = attrs["idsor05"];
						}
					}

					rNewFlussoIncassi["importo"] = importoTotaleFlusso;
				}
			}

			var myPostData = new Easy_PostData();
			myPostData.initClass(DS, _conn);
			var res = myPostData.DO_POST();

			if (!res) {
				show(this, "Errore nel salvataggio");
				return;
			}

			show(this, "Elaborazione  completata");
		}

		/// <summary>
		/// Riempie la tabella flusso crediti in base al tracciato excel concordato con Roma Tor Vergata
		/// </summary>
		/// <param name="dtToImport"></param>
		/// <returns></returns>
		void importaFlussoCrediti(DataTable dtToImport) {
			// Riempie le tabelle flussocrediti e flussocreditidetail
			_registry.Clear();
			DS.flussocrediti.Clear();
			DS.flussocreditidetail.Clear();
			DS.estimate.Clear();
			DS.estimatedetail.Clear();
			DS.invoice.Clear();
			DS.invoicedetail.Clear();
			DS.ivaregister.Clear();
			DS.registry.Clear();
			DS.list.Clear();
			// riempie il Dataset con le righe de i crediti e dei dettagli
			// a partire dalla tabella temporanea mData 

			var metaFlussoCrediti = _dispatcher.Get("flussocrediti");
			metaFlussoCrediti.SetDefaults(DS.flussocrediti);

			var metaFlussoCreditiDetail = _dispatcher.Get("flussocreditidetail");
			metaFlussoCreditiDetail.SetDefaults(DS.flussocreditidetail);

			if (dtToImport.Rows.Count > 0) {
				//Salvataggio preventivo anagrafiche
				string errore;
				foreach (DataRow rr in dtToImport.Rows) {
					var oCodiceFiscaleStudente = rr["codice_fiscale_studente"];
			
					if ((oCodiceFiscaleStudente == null) || (oCodiceFiscaleStudente == DBNull.Value)) {
						DS.registry.Clear();
						show(this, "Codice fiscale studente non valorizzato", "Errore");
						return;
					}

					var oNomeStudente = rr["nome_studente"];
					var oCognomeStudente = rr["cognome_studente"];

					// Aggiunta dell'eventuale anagrafica                    
					var idcausaleEpCredito = getCausaleEp(rr["codice_causale_ep_credito"], out errore);
					if ((idcausaleEpCredito == DBNull.Value) && (errore != "")) {
						DS.registry.Clear();
						show(errore, "Errore");
						return;
					}
					var oMemorizzaCausale = rr["memorizza_causale_anagrafica"];
					var oIdreg = creaAnagraficaSeNonEsiste(oCodiceFiscaleStudente, oNomeStudente, oCognomeStudente,
						idcausaleEpCredito, DBNull.Value, oMemorizzaCausale, out errore);
					if (oIdreg == DBNull.Value) {
						DS.registry.Clear();
						show(errore, "Errore in creazione nuova anagrafica");
						return;
					}


					var oCodiceListino = rr["codice_listino"];
					var idList = GetIdListForCodelist(oCodiceListino, out errore);
					if ((idList == null) && (errore != "")) {
						DS.list.Clear();
						show(errore, "Errore");
						//return;
					}
				}

				var myPostD = new Easy_PostData();
				myPostD.initClass(DS, _conn);
				var resPost = myPostD.DO_POST();
				if (!resPost) return;


				if (!resPost) return;

				_registry.Clear();
				foreach (DataRow r in DS.registry.Rows) {
					_registry[r["cf"].ToString().ToUpper()] = CfgFn.GetNoNullInt32(r["idreg"]);
				}

				// leggo la prima riga in quanto dovrò creare un solo contratto con tanti dettagli 
				// quante sono le anagrafiche pertanto data contabile, tipo contratto e causale ricavo saranno uguali
				var rFirst = dtToImport.Rows[0];
				var idestimkind = checkTipoContrattoAttivo(rFirst["codice_tipo_contratto"], out errore);
				if (idestimkind == null) {
					show(errore, "");
					return;
				}

				var oDataContabile = rFirst["data_contabile"];
				var rNewFlussoCrediti = metaFlussoCrediti.Get_New_Row(null, DS.flussocrediti);

				// Nota: aggiungere la gestione degli errori
				var attrs = getAttributiTipoContrattoAttivo(idestimkind, out errore);
				if (attrs == null) {
					show(errore, "");
					return;
				}



				rNewFlussoCrediti["datacreazioneflusso"] = _security.GetSys("datacontabile");
				rNewFlussoCrediti["flusso"] = DBNull.Value;
				rNewFlussoCrediti["istransmitted"] =
					"S"; //il flusso che importiamo si intenda già trasmesso da un programma esterno
				rNewFlussoCrediti["filename"] = fileName;
				rNewFlussoCrediti["docdate"] = oDataContabile;
				rNewFlussoCrediti["idestimkind"] = idestimkind;
				rNewFlussoCrediti["idsor01"] = attrs["idsor01"];
				rNewFlussoCrediti["idsor02"] = attrs["idsor02"];
				rNewFlussoCrediti["idsor03"] = attrs["idsor03"];
				rNewFlussoCrediti["idsor04"] = attrs["idsor04"];
				rNewFlussoCrediti["idsor05"] = attrs["idsor05"];
				rNewFlussoCrediti["ct"] = DateTime.Now;
				rNewFlussoCrediti["cu"] = "importaFlussoCrediti_" + _conn.externalUser;
				rNewFlussoCrediti["lt"] = DateTime.Now;
				rNewFlussoCrediti["lu"] = "importaFlussoCrediti_" + _conn.externalUser;
				var rFlussoCrediti = rNewFlussoCrediti;
				var bollettiniAnnullati = new List<string>();

				// Ciclo per la creazione di una riga in Flusso CreditiDetail
				foreach (DataRow rigaTracciatoCrediti in dtToImport.Rows) {
					var oCodiceBollettinoUnivoco = rigaTracciatoCrediti["codice_bollettino_univoco"];
					var oImporto = rigaTracciatoCrediti["importo"];
					var oOperazione = rigaTracciatoCrediti["operazione"];
					oDataContabile = rigaTracciatoCrediti["data_contabile"];
					var idupb = getIdUpb(rigaTracciatoCrediti["codice_upb"], out errore);

					//object stop = rFlussoDetail["data_scadenza"];
					var competencystart = rigaTracciatoCrediti["data_inizio_competenza"];
					var competencystop = rigaTracciatoCrediti["data_fine_competenza"];
					var description = rigaTracciatoCrediti["causale"];

					if ((idupb == DBNull.Value) && (errore != "")) {
						show(errore, "");
						return;
					}

					var idCodiceCausaleFinanziaria = getFinMotive(rigaTracciatoCrediti["codice_causale_finanziaria"],
						out errore);
					if ((idCodiceCausaleFinanziaria == DBNull.Value) && (errore != "")) {
						show(errore, "");
						return;
					}
					var idCodiceCausaleFinanziaria_IVA = getFinMotiveIVA(rigaTracciatoCrediti["codice_causale_finanziaria_iva"],
						out errore); ;
					//La presenza di errore o assenza campo non deve bloccare l'elaborazione dei dati, perchè il campo non è obbligatorio
					//if ((idCodiceCausaleFinanziaria_IVA == DBNull.Value) && (errore != "")) {
					//	show(errore, "");
					//	return;
					//}
					var idcausaleEpRicavo = getCausaleEp(rigaTracciatoCrediti["codice_causale_ep_ricavo"], out errore);
					if ((idcausaleEpRicavo == DBNull.Value) && (errore != "")) {
						show(errore, "");
						return;
					}

					var idcausaleEpCredito =
						getCausaleEp(rigaTracciatoCrediti["codice_causale_ep_credito"], out errore);
					if ((idcausaleEpCredito == DBNull.Value) && (errore != "")) {
						show(errore, "");
						return;
					}

					var oCodiceFiscaleStudente = rigaTracciatoCrediti["codice_fiscale_studente"];
					var oNomeStudente = rigaTracciatoCrediti["nome_studente"];
					var oCognomeStudente = rigaTracciatoCrediti["cognome_studente"];

					// Aggiunta dell'eventuale anagrafica
					var oMemorizzaCausale = rigaTracciatoCrediti["memorizza_causale_anagrafica"];
					var oIdreg = creaAnagraficaSeNonEsiste(oCodiceFiscaleStudente, oNomeStudente, oCognomeStudente,
						idcausaleEpCredito, null, oMemorizzaCausale, out errore);
					if (oIdreg == DBNull.Value) {
						show(errore, "Errore in creazione nuova anagrafica");
						continue;
					}

					var oCodiceListino = rigaTracciatoCrediti["codice_listino"];
					var idList = GetIdListForCodelist(oCodiceListino, out errore);
					//La presenza di errore o assenza campo listino non deve bloccare l'elaborazione dei dati, perchè il campo non è obbligatorio
					 
					//if ((idList == null) && (errore != "")) {
					//	show(errore, "Errore");
					//	return;
					//}

					if (oOperazione.ToString() == "I") {
						#region inserimento nuovo dettaglio credito in base alla riga del tracciato

						var rNewFlussocreditiDetail =
							metaFlussoCreditiDetail.Get_New_Row(rFlussoCrediti, DS.flussocreditidetail) as
								flussocreditidetailRow;
						// NON compiliamo lo IUV 
						//rNewFlussocreditiDetail["idflusso"] =  ;
						//rNewFlussocreditiDetail["iddetail"] =  ;
						// ReSharper disable once PossibleNullReferenceException
						rNewFlussocreditiDetail["iuv"] = rigaTracciatoCrediti["iuv"];
						rNewFlussocreditiDetail["importoversamento"] = oImporto;
						rNewFlussocreditiDetail["tax"] = CfgFn.GetNoNullDecimal(rigaTracciatoCrediti["iva"]);
						rNewFlussocreditiDetail["idestimkind"] = DBNull.Value;
						rNewFlussocreditiDetail["yestim"] = DBNull.Value;
						rNewFlussocreditiDetail["nestim"] = DBNull.Value;
						rNewFlussocreditiDetail["rownum"] = DBNull.Value;
						rNewFlussocreditiDetail["idinvkind"] = DBNull.Value;
						rNewFlussocreditiDetail["yinv"] = DBNull.Value;
						rNewFlussocreditiDetail["ninv"] = DBNull.Value;
						rNewFlussocreditiDetail["invrownum"] = DBNull.Value;
						rNewFlussocreditiDetail["idfinmotive"] = idCodiceCausaleFinanziaria;
						rNewFlussocreditiDetail["idfinmotive_iva"] = idCodiceCausaleFinanziaria_IVA;
						rNewFlussocreditiDetail["iduniqueformcode"] = oCodiceBollettinoUnivoco;
						rNewFlussocreditiDetail["idaccmotiverevenue"] = idcausaleEpRicavo;
						rNewFlussocreditiDetail["idaccmotivecredit"] = idcausaleEpCredito;
						rNewFlussocreditiDetail["idaccmotiveundotax"] = DBNull.Value;
						rNewFlussocreditiDetail["idaccmotiveundotaxpost"] = DBNull.Value;
						//rNewFlussocreditiDetail["start"] = DBNull.Value;
						rNewFlussocreditiDetail["stop"] = DBNull.Value;
						rNewFlussocreditiDetail["competencystart"] = competencystart;
						rNewFlussocreditiDetail["competencystop"] = competencystop;
						rNewFlussocreditiDetail["description"] = description;
						rNewFlussocreditiDetail["cf"] = oCodiceFiscaleStudente.ToString().ToUpper();
						rNewFlussocreditiDetail["idlist"] = idList; 
						rNewFlussocreditiDetail["idreg"] = oIdreg;
						rNewFlussocreditiDetail["idupb"] = idupb;
						rNewFlussocreditiDetail["ct"] = DateTime.Now;
						rNewFlussocreditiDetail["cu"] = "importaFlussoCrediti_" + _conn.externalUser;
						rNewFlussocreditiDetail["lt"] = DateTime.Now;
						rNewFlussocreditiDetail["lu"] = "importaFlussoCrediti_" + _conn.externalUser;

						#endregion
					}
					else {
						#region annullamento credito 

						if (bollettiniAnnullati.Contains(oCodiceBollettinoUnivoco.ToString())) {
							show(
								$"E' presente due o più volte l'annullamento del bollettino {oCodiceBollettinoUnivoco}. ","Avviso");
							continue;
						}

						var existentRowsToAnnull = DS.flussocreditidetail.getFromDb(_conn,
							q.eq("iduniqueformcode", oCodiceBollettinoUnivoco) & q.isNull("stop") &
							q.isNull("annulment"));

						if (existentRowsToAnnull.Length == 0) {
							errore =
								$"Bollettino numero {oCodiceBollettinoUnivoco} non trovato (o già annullato) nei crediti esistenti. L'annullo di tale bollettino non sarà considerato.";
							show(errore, "Avviso");
							continue;
						}

						bollettiniAnnullati.Add(oCodiceBollettinoUnivoco.ToString());

						//Crea una riga di annullamento per ogni riga esistente da annullare e ne imposta il campo annullato
						foreach (var rToAnnull in existentRowsToAnnull) {
							rToAnnull.annulmentValue =
								oDataContabile; //Imposta il campo ANNULLATO nel dettaglio credito esistente

							var rNewFlussocreditiDetail =
								metaFlussoCreditiDetail.Get_New_Row(rFlussoCrediti, DS.flussocreditidetail) as
									flussocreditidetailRow;

							//copia alcuni campi dalla riga originale da annullare
							foreach (var field in new[] {
								"importoversamento", "idestimkind", "yestim", "nestim", "rownum", "idinvkind", "yinv",
								"ninv", "invrownum","tax","idlist"
							}) {
								// ReSharper disable once PossibleNullReferenceException
								rNewFlussocreditiDetail[field] = rToAnnull[field];
							}

							// ReSharper disable once PossibleNullReferenceException
							rNewFlussocreditiDetail.flag = 0;
							rNewFlussocreditiDetail["idfinmotive"] = idCodiceCausaleFinanziaria;
							rNewFlussocreditiDetail["idfinmotive_iva"] = idCodiceCausaleFinanziaria_IVA;
							rNewFlussocreditiDetail["iduniqueformcode"] = oCodiceBollettinoUnivoco;
							rNewFlussocreditiDetail["idaccmotiverevenue"] = idcausaleEpRicavo;
							rNewFlussocreditiDetail["idaccmotivecredit"] = idcausaleEpCredito;

							rNewFlussocreditiDetail["idaccmotiveundotax"] = idcausaleEpRicavo;
							rNewFlussocreditiDetail["idaccmotiveundotaxpost"] = idcausaleEpRicavo;
							rNewFlussocreditiDetail["stop"] = oDataContabile;

							rNewFlussocreditiDetail["competencystart"] = competencystart;
							rNewFlussocreditiDetail["competencystop"] = competencystop;
							rNewFlussocreditiDetail["description"] = description;
							rNewFlussocreditiDetail["cf"] = oCodiceFiscaleStudente.ToString().ToUpper();

							rNewFlussocreditiDetail["idreg"] = oIdreg;
							rNewFlussocreditiDetail["idupb"] = idupb;
							rNewFlussocreditiDetail["ct"] = DateTime.Now;
							rNewFlussocreditiDetail["cu"] = "import_flussostudenti";
							rNewFlussocreditiDetail["lt"] = DateTime.Now;
							rNewFlussocreditiDetail["lu"] = "import_flussostudenti";

						}

						#endregion
					}


				}
			}



			var myPostData = new Easy_PostData();
			myPostData.initClass(DS, _conn);
			var res = myPostData.DO_POST();

			if (!res) {
				show(this, "Errore nel salvataggio del flusso");
			}
			else {
				show(this, "Elaborazione del file completata");
			}
		}


		private void viewAutomatismi(DataSet ds) {
			string filterEntrata = null;
			if (ds.Tables["income"] != null) {
				var var = ds.Tables["income"];
				var rr = ds.Tables["income"].Select();
				if (rr.Length == 0) return;
				if (rr.Length > 100) return;
				filterEntrata = _qhs.FieldIn("idinc", rr, "idinc");
			}

			Form F = ShowAutomatismi.Show(_meta as MetaData, null, filterEntrata, null, null);
            if (F != null)
            {
                createForm(F, null);
                F.ShowDialog();
            }
        }

		void copyRelation(DataSet dest, DataRelation sourceRel) {
			if (dest.Relations.Contains(sourceRel.RelationName)) return;
			if (!dest.Tables.Contains(sourceRel.ParentTable.TableName)) {
				dest.Merge(sourceRel.ParentTable, false, MissingSchemaAction.Add);
			}

			if (!dest.Tables.Contains(sourceRel.ChildTable.TableName)) {
				dest.Merge(sourceRel.ChildTable, false, MissingSchemaAction.Add);
			}

			DataTable parentDest = dest.Tables[sourceRel.ParentTable.TableName];
			DataTable childDest = dest.Tables[sourceRel.ChildTable.TableName];

			var destParentColumns = sourceRel.ParentColumns.Select(c => parentDest.Columns[c.ColumnName]).ToArray();
			var childParentColumns = sourceRel.ChildColumns.Select(c => childDest.Columns[c.ColumnName]).ToArray();
			var destRel = new DataRelation(sourceRel.RelationName, destParentColumns, childParentColumns);
			dest.Relations.Add(destRel);
		}

		bool doSave(out DataSet dSupdated) {
			dSupdated = null;

			if (!DS.HasChanges()) {
				show("Nessun movimento da generare", "Avviso");
				return false;
			}

			var dsp = DS.Copy();
			var faseincasso = CfgFn.GetNoNullInt32(_security.GetSys("maxincomephase"));

			var ga = new GestioneAutomatismi(this, _conn as DataAccess, _dispatcher as MetaDataDispatcher,
				dsp, 1, faseincasso, "income", true);
			ga.integraCopiaDatiDaDatasetPrincipaleASecondario();
			copyRelation(ga.DSP, dsp.Relations["FK_estimatedetail_estimate"]);
			copyRelation(ga.DSP, dsp.Relations["FK_flussoincassi_flussoincassidetail"]);
			copyRelation(ga.DSP, dsp.Relations["flussocrediti_flussocreditidetail"]);

			copyRelation(ga.DSP, dsp.Relations["estimatedetail_flussocreditidetail"]);
			copyRelation(ga.DSP, dsp.Relations["invoicedetail_flussocreditidetail"]);
			copyRelation(ga.DSP, dsp.Relations["invoice_incomeinvoice"]);

			//copyRelation(ga.DSP, dsp.Relations["income_incomevar"]); già ci dovrebbe essere

			copyRelation(ga.DSP, dsp.Relations["invoice_invoicedetail"]);

			copyRelation(ga.DSP, dsp.Relations["ivaregisterinvoice"]);
			copyRelation(ga.DSP, dsp.Relations["flussocrediti_webpayment"]);

			copyRelation(ga.DSP, dsp.Relations["income_incomeinvoice"]);
			copyRelation(ga.DSP, dsp.Relations["income_invoicedetail"]);
			copyRelation(ga.DSP, dsp.Relations["income_invoicedetail1"]);

			copyRelation(ga.DSP, dsp.Relations["income_incomeestimate"]);
			copyRelation(ga.DSP, dsp.Relations["estimate_incomeestimate"]);
			copyRelation(ga.DSP, dsp.Relations["income_estimatedetail"]);
			copyRelation(ga.DSP, dsp.Relations["income_estimatedetail1"]);
			copyRelation(ga.DSP, dsp.Relations["income_incomelastestimatedetail"]);


			bool res;
			if (DS.income.Rows.Count > 0) {
				ga.GeneraClassificazioniAutomatiche(ga.DSP, true);
				res = ga.GeneraAutomatismiAfterPost(true);
				if (!res) {
					show(this,
						"Si è verificato un errore o si è deciso di non salvare! L'operazione sarà terminata");
					return false;
				}
			}


			res = ga.doPost(_dispatcher as MetaDataDispatcher);


			//if (!res) {
			//    show(this,
			//        "Operazione annullata dall'utente","Avviso");             
			//"flussocrediti", "flussocreditidetail", "flussoincassi", "flussoincassidetail",
			// "invoice", "invoicedetail", "ivaregister", "estimate", "estimatedetail"
			//}
			DS.AcceptChanges();
			DS.incomeestimate.Clear();
			DS.incomeinvoice.Clear();
			DS.incomelastestimatedetail.Clear();
			//DS.estimatedetail.Clear();
			DS.incomelast.Clear();
			DS.income.Clear();
			DS.incomeyear.Clear();

			dSupdated = ga.DSP;

			aggiornaChiaviDs(dSupdated); //travasa i dati da DSP a DS

			ricalcolaFlagElaborato();

			if (res) {
				show("Salvataggio dati effettuato.", "Avviso");
				viewAutomatismi(ga.DSP);
			}

			return res;
		}
		

		void ricalcolaFlagElaborato() {
			initPBar("Ricalcolo flag elaborato flusso incassi", DS.flussoincassi.Rows.Count);
			//var someThingDone = false;
			StringBuilder sb = new StringBuilder();
			foreach (var flusso in DS.flussoincassi) {
				incPBar();
				sb.AppendLine($"exec compute_flussoincassiflagelaborato {esercizio},{flusso.idflusso}");
				if (sb.Length > 10000) {
					_conn.SQLRunner(sb.ToString());
					sb.Clear();
				}
			}

			if (sb.Length > 0) {
				_conn.SQLRunner(sb.ToString());
			}
			closePBar();
		}


		private bool creaAccertamentiDettagliContratti(estimatedetailRow[] estimatedetailRow) {
			//RowChange.SetOptimized(DS.income,true);
			//RowChange.ClearMaxCache(DS.income);

			bool res = creaAccertamentiDaDettagliContrattiAttivi(estimatedetailRow, TipoElaborazioneIncassi.imponibile,
				false);
			if (res)
				res = creaAccertamentiDaDettagliContrattiAttivi(estimatedetailRow, TipoElaborazioneIncassi.iva, false);
			if (res)
				res = creaAccertamentiDaDettagliContrattiAttivi(estimatedetailRow, TipoElaborazioneIncassi.totali,
					false);
			return res;
		}

		/// <summary>
		/// Crea gli accertamenti relativi ai dettagli contratti attivi. Non opera sui contratti attivi a gestione differita se non in fase incassi
		/// Non cancella nulla dal ds
		/// </summary>
		/// <param name="estimatedetailRows"></param>
		/// <param name="tipoElaborazione"></param>
		/// <param name="faseIncassi"></param>
		/// <returns></returns>
		bool creaAccertamentiDaDettagliContrattiAttivi(estimatedetailRow[] estimatedetailRows,
			TipoElaborazioneIncassi tipoElaborazione, bool faseIncassi) {
			//QueryCreator.MarkEvent("creaAccertamentiDaDettagliContrattiAttivi");
			// To Do: modificare l'interfaccia uniformando le chiamate
			var fasecontratto = CfgFn.GetNoNullInt32(_security.GetSys("estimatephase"));
			var fasecred = CfgFn.GetNoNullInt32(_security.GetSys("incomeregphase"));
			var fasebilancio = CfgFn.GetNoNullInt32(_security.GetSys("incomefinphase"));

			var faseinizio = 1;
			var fasefine = fasecontratto;

			var metaIncome = _dispatcher.Get("income");
			var metaIncomeYear = _dispatcher.Get("incomeyear");
			var metaIncomeLast = _dispatcher.Get("incomelast");
			var metaIncomeEstimate = _dispatcher.Get("incomeestimate");
			var metaEstimateDetail = _dispatcher.Get("estimatedetail");
			metaIncome.SetDefaults(DS.income);
			metaIncomeYear.SetDefaults(DS.incomeyear);
			metaIncomeLast.SetDefaults(DS.incomelast);
			metaIncomeEstimate.SetDefaults(DS.incomeestimate);
			metaEstimateDetail.SetDefaults(DS.estimatedetail);
			MetaData.SetDefault(DS.income, "parentidinc", DBNull.Value);
			//estimatedetailRow[] selectedRows;
			//if (estimatedetailRow != null) {
			//    selectedRows = new estimatedetailRow[1];
			//    selectedRows[0] = estimatedetailRow;
			//}
			//else {
			//    selectedRows = DS.estimatedetail.allCurrent().ToArray();
			//}

			//if (selectedRows.Length == 0) {
			//    show("Righe di Dettaglio Assenti", "Errore");
			//    return false;
			//}

			var currcausale = 1; // contabilizzazione totale

			var mov = DS.income;
			var impMov = DS.incomeyear;


			MetaData.SetDefault(DS.incomeyear, "ayear", esercizio);


			DataRow incomeToLink = null;
			// Crea Contabilizzazioni dei dettagli contratto attivo elencati
			foreach (var rDet in estimatedetailRows) {
				if (rDet["stop"] != DBNull.Value) continue;

				var currUpb = rDet.idupb;
				var currUpbIva = rDet.idupb_iva;
				//Se è valorizzata la Causale finanziaria IVA ma non è valorizzato l'UPB iva,
				// valorizzo l'upb iva al fine di generare un incasso separato per l'IVA [16307]
				if ((rDet.idfinmotive_iva != null) && (currUpb != null) && (currUpbIva == null)) {
					currUpbIva = currUpb;
				}
				switch (tipoElaborazione) {
					case TipoElaborazioneIncassi.totali:
						//Elaborazione pre modifica split fasi - esegue solo con upb_iva == null
						if (currUpb == null || currUpbIva != null) continue; //i totali devono avere un upb_iva NON impostato per essere elaborati
						break;
					case TipoElaborazioneIncassi.imponibile:
						if (currUpb == null || currUpbIva == null) continue; // imponibile  o iva è ammesso solo se c'è currUPB
						break;
					case TipoElaborazioneIncassi.iva:
						if (currUpb == null || currUpbIva == null) continue; // imponibile  o iva è ammesso solo se c'è currUPB
						break;
				}

				// possono essere dettagli contratto attivo non collegati a  fattura
				// Prima di tutto vedo se la contabilizzazione è differita
				string errore;
				var gestionedifferita = getGestioneDifferita(rDet.idestimkind, out errore);
				if (gestionedifferita == "S" && !faseIncassi) continue; //salta questo dettaglio
				var aDate = getDateContrattoAttivo(rDet, out errore); //_conn.readValue("estimate", q.mCmp(rDet, "idestimkind", "yestim", "nestim"), "adate");

				DataRow parentR = null;
				//spostato sotto
				//var amount = rDet.taxable;
				if (tipoElaborazione == TipoElaborazioneIncassi.iva) {
					if (rDet.idinc_ivaValue != DBNull.Value) continue;
				}
				else {
					if (rDet.idinc_taxableValue != DBNull.Value) continue;
				}

				decimal imponibile = CfgFn.GetNoNullDecimal(rDet.taxable);
				decimal sconto = CfgFn.GetNoNullDecimal(rDet.discount);
				decimal quantita = CfgFn.GetNoNullDecimal(rDet.number);
				decimal imponibiletot = CfgFn.GetNoNullDecimal(CfgFn.RoundValuta((imponibile * quantita * (1 - sconto))));
				var iva = CfgFn.GetNoNullDecimal(rDet.tax);

				object idUpbSelected = DBNull.Value;
				decimal amount = 0;
				// Determinazione del capitolo di bilancio in base alla causale finanziaria 
				object idfinSelected = DBNull.Value;
				var Curridfin = getBilancioFromCausaleFin(rDet.idfinmotive, out errore);
				string erroreiva;
				var Curridfin_iva = getBilancioFromCausaleFin(rDet.idfinmotive_iva, out erroreiva);
				switch (tipoElaborazione) {
					case TipoElaborazioneIncassi.totali:
						//Elaborazione pre modifica split fasi - esegue solo con upb_iva == null
						currcausale = 1;
						amount = imponibiletot + iva;
						idUpbSelected = currUpb;
						idfinSelected = Curridfin;
						break;
					case TipoElaborazioneIncassi.imponibile:
						// currUpb è sicuramente non null
						currcausale = 3;
						amount = imponibiletot;
						idUpbSelected = currUpb;
						idfinSelected = Curridfin;
						break;
					case TipoElaborazioneIncassi.iva:
						// curUpbIva è sicuramente non null
						currcausale = 2;
						amount = iva;
						idUpbSelected = currUpbIva;
						idfinSelected = (Curridfin_iva == DBNull.Value) ? Curridfin : Curridfin_iva;
						break;
				}


				if (amount == 0) continue; // non dovrebbe essere mai zero 
				for (var faseCorrente = faseinizio; faseCorrente <= fasefine; faseCorrente++) {
					mov.Columns["nphase"].DefaultValue = faseCorrente;

					var newEntrataRow = metaIncome.Get_New_Row(parentR, mov);
					if (faseCorrente == fasecontratto) incomeToLink = newEntrataRow;
					parentR = newEntrataRow;
					// Selezione UPB e Voce di Bilancio in modo completamente automatico
					var idmanagerSelected = getUpbManager(idUpbSelected, out errore); //_conn.readValue("upb", q.eq("idupb", idUpbSelected), "idman");
					if (errore != "") {
						show(
							$"{errore} nel dettaglio {rDet.detaildescription} codice bollettino {rDet.iduniqueformcode}",
							"Errore");
						return false;
					}

					if (errore != "") {
						show(
							$"{errore} nel dettaglio {rDet.detaildescription} codice bollettino {rDet.iduniqueformcode}",
							"Errore");
						return false;
					}

					fillMovimento(newEntrataRow, idmanagerSelected, rDet["idreg"], rDet["detaildescription"].ToString());

					newEntrataRow["doc"] = $"C.A.{rDet["idestimkind"]}/{rDet["yestim"].ToString().Substring(2, 2)}/{rDet["nestim"].ToString().PadLeft(6, '0')}";

					newEntrataRow["docdate"] = aDate ?? DBNull.Value;

					newEntrataRow["nphase"] = faseCorrente;
					newEntrataRow["idreg"] = faseCorrente < fasecred ? DBNull.Value : rDet["idreg"];

					var newImpMov = impMov.NewRow();

					fillImputazioneMovimento(newImpMov, CfgFn.GetNoNullDecimal(amount), idfinSelected, idUpbSelected);

					newImpMov["idinc"] = newEntrataRow["idinc"];
					newImpMov["ayear"] = esercizio;

					if (faseCorrente < fasebilancio) {
						newImpMov["idfin"] = DBNull.Value;
						newImpMov["idupb"] = DBNull.Value;
					}

					impMov.Rows.Add(newImpMov);
					// nel monofase mi accerto anche di calcolare le class. Siope da documento
					if (faseCorrente == _nphaseSiopeE && newcomputesorting == "S" && faseentratamax == 1 /*monofase*/) {
						// Classificazione SIOPE impostata su documento
						string errori;
						var idsor = rDet.idsor_siope ;
						//Altrimenti leggo class SIOPE impostata sulla causale di ricavo
						if (idsor == null) 
								idsor = getSiopeForAccMotive(rDet.idaccmotive, out errori); 
						fillIncomeSorted(newEntrataRow, idsor, CfgFn.GetNoNullDecimal(amount));
					}


				}

				//Aggiunge la riga in IncomeEstimate
				var incEstimRow = metaIncomeEstimate.Get_New_Row(incomeToLink, DS.incomeestimate);
				incEstimRow["movkind"] = currcausale;
				incEstimRow["idestimkind"] = rDet["idestimkind"];
				incEstimRow["yestim"] = rDet["yestim"];
				incEstimRow["nestim"] = rDet["nestim"];

				//Effettua i collegamenti con il dettaglio
				if (incomeToLink != null) {
					if ((tipoElaborazione != TipoElaborazioneIncassi.iva)) rDet["idinc_taxable"] = incomeToLink["idinc"];
					if ((tipoElaborazione == TipoElaborazioneIncassi.iva)) rDet["idinc_iva"] = incomeToLink["idinc"];
				}

			}

			return true;

		}

		//void editRelatedEstimate(DataRow r) {
		//    if (r == null) return;
		//    var toMeta = _dispatcher.Get("estimate");
		//    if (toMeta == null) return;

		//    toMeta.Edit(this, "default", false);
		//    var listtype = toMeta.DefaultListType;
		//    toMeta.SelectRow(r, listtype);
		//}

		private void visualizzaRigaSelezionata(DataRow Riga, string table, string view, string listType,
			string editType) {
			if (Riga == null) return;
			string filter = QueryCreator.WHERE_KEY_CLAUSE(Riga, DataRowVersion.Default, true);
			if (editType == null) editType = "default";
			var MElenco = _dispatcher.Get(table);
			if (MElenco == null) return;

			bool result = MElenco.Edit(this, editType, false);
			//DataRow R = MElenco.SelectOne(listType, filter, null, null);
			MElenco.SelectRow(Riga, listType);
		}

		bool verificaIncassi(DataTable dt) {
			clearAllDict();
			foreach (DataColumn c in dt.Columns) {
				if (!dt.Columns.Contains(c.ColumnName)) {
					show(this, "File non compatibile con il Tracciato del Flusso Incassi");
					return false;
				}
			}

			if (!dt.Columns.Contains("riga")) {
				dt.Columns.Add("riga");
				dt.Columns["riga"].DataType = typeof(string);
				dt.Columns["riga"].Caption = "Riga";
			}

			if (!dt.Columns.Contains("errori")) {
				dt.Columns.Add("errori");
				dt.Columns["errori"].DataType = typeof(string);
				dt.Columns["errori"].Caption = "Errori";
			}

			var ds1 = new DataSet();

			ds1.Tables.Add(dt);
			dgrIncassi.SetDataBinding(ds1, dt.TableName);

			HelpForm.SetDataGrid(dgrIncassi, dt);
			HelpForm.SetGridStyle(dgrIncassi, dt);

			/*
			 *  "codice_fiscale_studente;Codice Fiscale Studente;Stringa;16",
			            "numero_sospeso_attivo; Numero Sospeso Attivo; Intero;10",
			            "data_incasso; Data Incasso;Data;8",
			            "codice_bollettino_univoco;Codice Bollettino Univoco;Stringa;50",
			            "importo;Importo Totale;Numero;22",
						"iuv;Identificativo Univoco di Versamento;Stringa;100"
			 * */

			var ok = true;

			var errCf = false;
			var nrigacorrente = 1;
			foreach (DataRow r in dt.Rows) {
				string errore;
				var err = "";
				var oCodiceFiscaleStudente = getVal(1, "codice_fiscale_studente", r, "fasedue", out errore);
				if (errore != "") err = err + " " + errore;
				if (oCodiceFiscaleStudente == DBNull.Value) break;
				var oNumeroSospesoAttivo = getVal(2, "numero_sospeso_attivo", r, "fasedue", out errore);
				if (errore != "") err = err + " " + errore;
				var oDataIncasso = getVal(3, "data_incasso", r, "fasedue", out errore);
				if (errore != "") err = err + " " + errore;
				var oCodiceBollettinoUnivoco = getVal(4, "codice_bollettino_univoco", r, "fasedue", out errore);
				if (errore != "") err = err + " " + errore;
				var oImporto = getVal(5, "importo", r, "fasedue", out errore);
				if (errore != "") err = err + " " + errore;
				var oIdentificativoUnivocoVersamenti = getVal(6, "iuv", r, "fasedue", out errore);
				if (errore != "") err = err + " " + errore;


				if (err != "") ok = false;

				if (CfgFn.GetNoNullDecimal(oImporto) <= 0) {
					errore =
						$" Valore non previsto per il campo importo di valore {oImporto.ToString().Trim()} : inserire un importo maggiore di zero";
					err += " " + errore;
					ok = false;
				}

				CalcolaCodiceFiscale.CheckCF(oCodiceFiscaleStudente.ToString(), out errore);

				if (errore != "") {
					errore = $" Nel codice fiscale {oCodiceFiscaleStudente} compaiono i seguenti errori: {errore}";
					err += " " + errore;
					errCf = true;
					// ok = false;
				}

				var nbill = getSospesiAttivi(oNumeroSospesoAttivo, out errore);
				if (nbill == DBNull.Value && errore != "") {
					err += " " + errore;
					ok = false;
				}

				if (oDataIncasso == DBNull.Value) {
					errore = "La data incasso è obbligatoria";
					err += " " + errore;
					ok = false;
				}

				var okImporto = verifyImportoTotaleIncasso(oCodiceBollettinoUnivoco, CfgFn.GetNoNullDecimal(oImporto),
					out errore);
				if (errore != "" && !okImporto) {
					err += " " + errore;
					ok = false;
				}

				r["riga"] = nrigacorrente;
				r["errori"] = err;

				nrigacorrente++;
			}


			if (errCf && ok) {
				show(this, "Si sono verificati errori nella convalida di alcuni codici fiscali.");
			}

			//if (ok) {
			//    show(this, "Importate " + (nrigacorrente - 1).ToString() + " righe.");
			//    btnElaboraIncassi.Enabled = true;

			//}
			//else {
			//    btnElaboraIncassi.Enabled = false;

			//}


			return ok;
		}


		private bool isNumeric(object str, out decimal valore) {
			valore = 0;
			try {
				valore = Convert.ToDecimal(str);
				//valore = decimal.Parse(str.ToString().Replace(",", "."), CultureInfo.InvariantCulture);
				return true;
			}
			catch (Exception) {
				return false;
			}
		}


		private readonly Dictionary<string, int> _vociBilancioEntrata = new Dictionary<string, int>();
		private readonly Dictionary<string, int> _vociBilancioEntrata_iva = new Dictionary<string, int>();
		object getBilancioFromCausaleFin(object idfinmotive, out string errori) {
			errori = "";
			if (idfinmotive == DBNull.Value || idfinmotive == null) {
				errori = " Causale finanziaria non trovata";
				return DBNull.Value;
			}

			var idfinmotiveS = idfinmotive.ToString();
			if (_vociBilancioEntrata.ContainsKey(idfinmotiveS)) return _vociBilancioEntrata[idfinmotiveS];
			var idfin = _conn.readValue("finmotivedetail",
				q.eq("ayear", esercizio) & q.eq("idfinmotive", idfinmotiveS), "idfin");
			if (idfin == null || idfin == DBNull.Value) {
				errori = "Voce di bilancio associata alla causale finanziaria non trovata";
				return DBNull.Value;
			}

			_vociBilancioEntrata[idfinmotiveS] = CfgFn.GetNoNullInt32(idfin);
			return _vociBilancioEntrata[idfinmotiveS];

		}

		private readonly Dictionary<string, object> _upbManager = new Dictionary<string, object>();

		private object getUpbManager(object idUpb, out string errori) {
			errori = "";
			if (idUpb == DBNull.Value || idUpb == null) {
				errori = "UPB non trovato";
				return DBNull.Value;
			}


			if (_upbManager.ContainsKey(idUpb.ToString())) return _upbManager[idUpb.ToString()];

			var idMan = _conn.readValue("upb", q.eq("idupb", idUpb), "idman");
			if (idMan == null) {
				errori = $"UPB avente id {idUpb} non trovato";
				return DBNull.Value;
			}

			_upbManager[idUpb.ToString()] = idMan;
			return _upbManager[idUpb.ToString()];
		}


		private readonly Dictionary<string, string> _upb = new Dictionary<string, string>();

		private object getIdUpb(object oCodiceUpb, out string errori) {
			errori = "";
			if (oCodiceUpb == DBNull.Value || oCodiceUpb == null) {
				errori = "UPB non trovato";
				return DBNull.Value;
			}

			var sCodiceUpb = oCodiceUpb.ToString();

			if (_upb.ContainsKey(sCodiceUpb)) return _upb[sCodiceUpb];
			var idupb = _conn.readValue("upb", q.eq("codeupb", sCodiceUpb), "idupb");
			if (idupb == DBNull.Value || idupb == null) {
				errori = $"UPB avente codice {oCodiceUpb} non trovato";
				return DBNull.Value;
			}

			_upb[sCodiceUpb] = idupb.ToString();
			return _upb[sCodiceUpb];
		}


		private string checkTipoContrattoAttivo(object oCodiceTipoContratto, out string errori) {
			errori = "";
			if (oCodiceTipoContratto == DBNull.Value) return null;
			string idestimkind = null;

			var rEstimKind = DS.estimatekind.Filter(q.eq("idestimkind", oCodiceTipoContratto));
			if (rEstimKind.Length == 0) {
				errori = $"Tipo Contratto Attivo avente codice {oCodiceTipoContratto} non trovato";
			}
			else {
				idestimkind = rEstimKind[0].idestimkind;
			}

			return idestimkind;
		}

		private int? impostaDefaultIvaKind(object oCodiceTipoContratto, out string errori) {
			errori = "";
			var rEstimKind = DS.estimatekind.Filter(q.eq("idestimkind", oCodiceTipoContratto));
			if (rEstimKind.Length == 0) {
				errori = $"Tipo Contratto Attivo avente codice {oCodiceTipoContratto} non trovato";
				return null;
			}

			var rKind = rEstimKind[0];
			var idivakindForced = rKind.idivakind_forced;
			MetaData.SetDefault(DS.estimatedetail, "idivakind", idivakindForced);

			if (idivakindForced != null) {
				var taxrate = DS.ivakind.Filter(q.eq("idivakind", idivakindForced))[0].rateValue;
				//_conn.readValue("ivakind", q.eq("idivakind", idivakindForced), "rate");
				MetaData.SetDefault(DS.estimatedetail, "taxrate", taxrate);
				return idivakindForced;
			}

			MetaData.SetDefault(DS.estimatedetail, "idivakind", DBNull.Value);
			MetaData.SetDefault(DS.estimatedetail, "taxrate", DBNull.Value);
			//errori = "Tipo Iva Esente non configurato in Contratto Attivo avente codice " +oCodiceTipoContratto.ToString();
			return null;
		}


		private readonly Dictionary<object, object> _accmotive = new Dictionary<object, object>();

		object getCausaleEp(object codiceCausale, out string errori) {
			errori = "";
			if (codiceCausale == DBNull.Value || codiceCausale == null) {
				errori = "Causale EP non trovata";
				return DBNull.Value;
			}

			if (_accmotive.ContainsKey(codiceCausale)) return _accmotive[codiceCausale];

			var idaccmotive = _conn.readValue("accmotive", q.eq("codemotive", codiceCausale), "idaccmotive");
			if (idaccmotive == null || idaccmotive == DBNull.Value) {
				errori = $"Causale EP avente codice {codiceCausale} non trovata";
				return DBNull.Value;
			}

			_accmotive[codiceCausale] = idaccmotive;
			return _accmotive[codiceCausale];
		}

		void clearAllDict() {
			_upb.Clear();
			_accmotive.Clear();
			_vociBilancioEntrata.Clear();
			_finmotive.Clear();
			//accMotiveMiur.Clear();
			_accMotiveSiope.Clear();
			_sospesiAttivi.Clear();
			//_sospesiAttiviByCausali.Clear();
			_causaliSospesiAttivi.Clear();
			_tipoContrattoAttivoGestioneDifferita.Clear();
			_tipoContrattoAttivoCollegabileAFattura.Clear();
		}

		private readonly Dictionary<string, string> _finmotive = new Dictionary<string, string>();

		private object getFinMotive(object oCodiceCausaleFinanziaria, out string errori) {
			errori = "";

			if (oCodiceCausaleFinanziaria == DBNull.Value || oCodiceCausaleFinanziaria == null) {
				errori = " La causale finanziaria non è stata specificata";
				return DBNull.Value;
			}

			var sCodeMotive = oCodiceCausaleFinanziaria.ToString();
			if (_finmotive.ContainsKey(sCodeMotive)) return _finmotive[sCodeMotive];
			var idfinmotive = _conn.readValue("finmotive", q.eq("codemotive", sCodeMotive), "idfinmotive");

			if ((idfinmotive == DBNull.Value) || (idfinmotive == null)) {
				errori = $"Causale finanziaria avente codice {sCodeMotive} non trovata";
				return DBNull.Value;
			}

			_finmotive[sCodeMotive] = idfinmotive.ToString();
			return idfinmotive.ToString();
		}

		private readonly Dictionary<string, string> _finmotiveIVA = new Dictionary<string, string>();

		private object getFinMotiveIVA(object oCodiceCausaleFinanziariaIVA, out string errori) {
			errori = "";

			if (oCodiceCausaleFinanziariaIVA == DBNull.Value || oCodiceCausaleFinanziariaIVA == null) {
				errori = " La causale finanziaria non è stata specificata";
				return DBNull.Value;
			}

			var sCodeMotive = oCodiceCausaleFinanziariaIVA.ToString();
			if (_finmotiveIVA.ContainsKey(sCodeMotive)) return _finmotiveIVA[sCodeMotive];
			var idfinmotiveIVA = _conn.readValue("finmotive", q.eq("codemotive", sCodeMotive), "idfinmotive");

			if ((idfinmotiveIVA == DBNull.Value) || (idfinmotiveIVA == null)) {
				errori = $"Causale finanziaria avente codice {sCodeMotive} non trovata";
				return DBNull.Value;
			}

			_finmotiveIVA[sCodeMotive] = idfinmotiveIVA.ToString();
			return idfinmotiveIVA.ToString();
		}

		Dictionary<string, estimateRow> contrattoAttivoByKey = new Dictionary<string, estimateRow>();

		estimateRow getEstimateByKey(object idestimkind, object yestim, object nestim) {
			string h = $"{idestimkind}§{yestim}§{nestim}";
			if (contrattoAttivoByKey.Count == 0) {
				foreach (var rr in DS.estimate) {
					string hh = $"{rr["idestimkind"]}§{rr["yestim"]}§{rr["nestim"]}";
					contrattoAttivoByKey[hh] = rr;
				}
			}

			estimateRow r;
			if (contrattoAttivoByKey.TryGetValue(h, out r)) {
				return r;
			}
			else {
				var rr = DS.estimate.get(_conn, q.eq("idestimkind", idestimkind) &
				                                q.eq("yestim", yestim) &
				                                q.eq("nestim", nestim));
				if (rr != null && rr.Length == 1) {
					contrattoAttivoByKey[h] = rr[0];
					return rr[0];
				}

				return null;
			}

		}

		Dictionary<string, List<estimateRow>> righeContrattoAttivo = new Dictionary<string, List<estimateRow>>();

		estimateRow[] getEstimateRow(object idcodiceTipoContratto, object idaccmotivecredit, object docdate) {
			if (docdate == null) docdate = DBNull.Value;

			string h =
				$"{idcodiceTipoContratto}§{idaccmotivecredit}§{_security.GetDataContabile()}§{docdate}§{esercizio}";
			if (righeContrattoAttivo.Count == 0) {
				foreach (var r in DS.estimate) {
					addEstimateRow(r);
				}
			}

			List<estimateRow> l;
			if (righeContrattoAttivo.TryGetValue(h, out l)) {
				return l.ToArray();
			}
			else {
				var ll = DS.estimate.get(_conn, q.eq("idestimkind", idcodiceTipoContratto) &
				                                q.eq("idaccmotivecredit", idaccmotivecredit) &
				                                q.eq("adate", _security.GetDataContabile()) &
				                                q.eq("docdate", docdate) &
				                                q.eq("yestim", esercizio));
				righeContrattoAttivo[h] = ll.ToList();
				return ll;
			}

		}

		void addEstimateRow(estimateRow r) {
			string hh = $"{r["idestimkind"]}§{r["idaccmotivecredit"]}§{r["adate"]}§{r["docdate"]}§{r["yestim"]}";
			List<estimateRow> ll;
			if (!righeContrattoAttivo.TryGetValue(hh, out ll)) {
				ll = new List<estimateRow>();
				righeContrattoAttivo[hh] = ll;
			}

			ll.Add(r);

		}



		/// <summary>
		/// Crea i contratti attivi dalle righe di dettaglio flusso crediti non ancora elaborate e non annullate (stop null)
		/// Le righe considerate sono quelle senza tipo contratto attivo  e senza tipo fattura, oppure con tipo contratto ma senza n. contratto
		/// Svuota e riempie estimate, estimatedetail, flussocrediti*
		/// </summary>
		/// <returns></returns>
		private bool fillEstimate(object _from, object _to) {
			QueryCreator.MarkEvent("Inizio fillEstimate");
			DS.estimate.Clear();
			DS.estimatedetail.Clear();
			DS.invoice.Clear();
			DS.invoicedetail.Clear();
			DS.ivaregister.Clear();
			DS.registry.Clear();
			DS.flussocrediti.Clear();
			DS.flussocreditidetail.Clear();
			DS.income.Clear();
			DS.incomeestimate.Clear();
			DS.incomeinvoice.Clear();
			DS.incomelastestimatedetail.Clear();
			righeContrattoAttivo.Clear();
			initPBar("Inizializzazione creazione contratti da flusso screditi",5);

			var metaEstimate = MetaData.GetMetaData(this, "estimate");
			metaEstimate.SetDefaults(DS.estimate);
			var metaEstimateDetail = MetaData.GetMetaData(this, "estimatedetail");
			metaEstimateDetail.SetDefaults(DS.estimatedetail);

			var ivaKind = _conn.RUN_SELECT("ivakind", "idivakind,rate", null, null, null, false);
			incPBar();
			var ivaTaxRate = new Dictionary<int, object>();
			foreach (var r in ivaKind.Select()) {
				ivaTaxRate[CfgFn.GetNoNullInt32(r["idivakind"])] = r["rate"];
			}
			// Conn.readSimpleDictionary<int, object>("ivakind", "idivakind", "taxrate");


			RowChange.MarkAsAutoincrement(DS.estimate.Columns["nestim"], null, null, 0);
			MetaData.SetDefault(DS.estimate, "nestim", -100000);

			var errore = "";
			var tempNestim = 0;
			MetaData.SetDefault(DS.incomeyear, "ayear", esercizio);
			// elabora tutto il pregresso
			var upbSecurity = _conn.Security.SelectCondition("upb", false);
			var filterUpbSec = MetaExpressionParser.From(upbSecurity);
			filterUpbSec?.cascadeSetTable("upb");

			var condizioneSuDettCrediti = q.doPar(
				q.doPar(q.isNull("idestimkind") & q.isNull("idinvkind") & q.isNull("stop") & q.isNull("annulment"))
				|
				q.doPar(q.isNotNull("idestimkind") & q.isNull("nestim") & q.isNull("stop") & q.isNull("annulment"))
			);
			if (_from != DBNull.Value) {
				condizioneSuDettCrediti &= q.ge("idflusso", _from);
			}

			if (_to != DBNull.Value) {
				condizioneSuDettCrediti &= q.le("idflusso", _to);
			}

			var allRows =
				DS.flussocreditidetail.readTableJoined(_conn, "upb", condizioneSuDettCrediti, filterUpbSec, "idupb");
			incPBar();
			//attenzione: sfrutta il comportamento interno della readTableJoined, che ha già modificato gli alias delle condizioni in input

			var overallCondition =
				(filterUpbSec == null ? condizioneSuDettCrediti : condizioneSuDettCrediti & filterUpbSec).toSql(_qhs);

			//Legge i flussi collegati, ci vuole una doppia join però
			string colonneFlussoCrediti = string.Join(",",
				(from c in DS.flussocrediti.Columns._names()
					where QueryCreator.IsReal(DS.flussocrediti.Columns[c])
					select "flussocrediti." + c).ToArray());
			condizioneSuDettCrediti.cascadeSetTable("flussocreditidetail"); //superfluo ma non fa male
			var getFlussiSql = $"SELECT {colonneFlussoCrediti} FROM flussocrediti " +
			                   $" WHERE idflusso in (select idflusso from flussocreditidetail " +
			                   " JOIN UPB on UPB.idupb=flussocreditidetail.idupb " +
			                   $" WHERE {overallCondition} )";
			DS.flussocrediti._sqlGetFromDb(_conn, getFlussiSql);
			QueryCreator.MarkEvent($"fillEstimate - 1 : in DS.flussocrediti {DS.flussocrediti.Rows.Count} righe");

			incPBar();
			var flussoCreditiDict = new Dictionary<int?, flussocreditiRow>();
			foreach (var r in DS.flussocrediti) flussoCreditiDict[r.idflusso] = r;

			string colonneContratti = string.Join(",",
				(from c in DS.estimate.Columns._names()
					where QueryCreator.IsReal(DS.estimate.Columns[c]) & c!="txt"
					select "estimate." + c).ToArray());

			// WHERE ((((idestimkind='CA_ESSE3')AND(idaccmotivecredit='000600140008'))AND(adate={d '2019-12-31'}))AND(docdate={d '2019-12-29'}))AND(yestim=2019)
			//docdate  = rCrediti.docdate;
			//idcodiceTipoContratto = rCreditiDetail.idestimkind ?? rCrediti.idestimkind 
			//idaccmotivecredit  = rCreditiDetail.idaccmotivecredit


			//Estrae i contratti associati ai crediti in considerazione
			string sqlGetContratti =
				$" SELECT distinct {colonneContratti}  " +
				$" FROM flussocreditidetail " +
				$" JOIN flussocrediti on flussocrediti.idflusso=flussocreditidetail.idflusso "+
				$" JOIN estimate ON estimate.idestimkind=isnull(flussocreditidetail.idestimkind,flussocrediti.idestimkind) AND "+
				$"    estimate.idaccmotivecredit = flussocreditidetail.idaccmotivecredit AND"+
				$"    estimate.docdate = flussocrediti.docdate AND "+
				$"    estimate.yestim = {esercizio} "+
				" JOIN UPB on UPB.idupb=flussocreditidetail.idupb " +
				$" WHERE {overallCondition} ";

			DS.estimate._sqlSafeMergeFromDb(_conn, sqlGetContratti, 0);
			QueryCreator.MarkEvent(sqlGetContratti);
			QueryCreator.MarkEvent($"fillEstimate - 2 : in DS.estimate {DS.estimate.Rows.Count} righe");

			foreach (var r in DS.estimate) addEstimateRow(r);
			incPBar();

			
			string colonneDettContratti = string.Join(",",
				(from c in DS.estimatedetail.Columns._names()
					where QueryCreator.IsReal(DS.estimatedetail.Columns[c])
					select "estimatedetail." + c).ToArray());

			string sqlGetDetContratti =
				$" SELECT distinct {colonneDettContratti}  " +
				$" FROM estimatedetail " +
				$" JOIN ( {sqlGetContratti} ) AS A "+
				$" on A.idestimkind=estimatedetail.idestimkind and A.yestim=estimatedetail.yestim and A.nestim=estimatedetail.nestim ";
			QueryCreator.MarkEvent(sqlGetDetContratti);
			DS.estimatedetail._sqlSafeMergeFromDb(_conn, sqlGetDetContratti, 0);

			QueryCreator.MarkEvent($"fillEstimate - 3 : in DS.estimatedetail {DS.estimatedetail.Rows.Count} righe");

			QueryCreator.MarkEvent("Inizio foreach (var rCreditiDetail");
			initPBar("Creazione contratti da flusso crediti",allRows.Length);
			foreach (var rCreditiDetail in allRows) {
				incPBar();
				//Application.DoEvents();
				// Dovrò creare un solo contratto con tanti dettagli 
				// quante sono le anagrafiche pertanto data contabile, tipo contratto e causale ricavo saranno uguali

				var importo = rCreditiDetail.importoversamento;
				var idfinmotive = rCreditiDetail.idfinmotive;
				var idfinmotive_iva = rCreditiDetail.idfinmotive_iva;
				var iduniqueformcode = rCreditiDetail.iduniqueformcode;
				var idaccmotiverevenue = rCreditiDetail.idaccmotiverevenue;
				var idaccmotivecredit = rCreditiDetail.idaccmotivecredit;
				var idupb = rCreditiDetail.idupb;
				var idreg = rCreditiDetail.idreg;
				var competencystart = rCreditiDetail.competencystart;
				var competencystop = rCreditiDetail.competencystop;
				var description = rCreditiDetail.description;
				var nform = rCreditiDetail.nform;
				var idlist = rCreditiDetail.idlist;

				var number = CfgFn.GetNoNullDecimal(rCreditiDetail["number"]);
				if (number == 0) number = 1;
				var taxable = CfgFn.GetNoNullDecimal(importo) / number;

				flussocreditiRow rCrediti = null;
				if (flussoCreditiDict.ContainsKey(rCreditiDetail.idflusso)) {
					rCrediti = flussoCreditiDict[rCreditiDetail.idflusso];
				}

				var idcodiceTipoContratto = rCreditiDetail.idestimkind ?? rCrediti.idestimkind;
				//attualmente sempre NULL, NO! i crediti provenienti da portale ce l'hanno o possono avercelo

				if (rCrediti["docdate"] == DBNull.Value) continue;

				var docdate = (DateTime) rCrediti["docdate"];
				if (docdate.Year != esercizio) continue;
				idcodiceTipoContratto = checkTipoContrattoAttivo(idcodiceTipoContratto, out errore);
				if (errore != "") {
					show("Tipo contratto assente nei crediti", "Errore");
					continue;
				}

				if (idcodiceTipoContratto == null || idcodiceTipoContratto == "") {
					show("Tipo contratto assente", "Errore");
					continue;
				}

				//var docdate = rCrediti.docdate;
				var idsor01 = rCrediti.idsor01;
				var idsor02 = rCrediti.idsor02;
				var idsor03 = rCrediti.idsor03;
				var idsor04 = rCrediti.idsor04;
				var idsor05 = rCrediti.idsor05;

				if (idaccmotivecredit == null) {
					show("Causale di Credito assente", "Errore");
					return false;
				}


				var rEstimateArr = getEstimateRow(idcodiceTipoContratto, idaccmotivecredit, docdate);
				//DS.estimate.get(_conn, q.eq("idestimkind", idcodiceTipoContratto) &q.eq("idaccmotivecredit", idaccmotivecredit) & 
				//                       q.eq("adate", _security.GetDataContabile()) & q.eq("docdate",  (((object)docdate)?? DBNull.Value)) & q.eq("yestim", esercizio));
				int? idivakindDefault;
				estimateRow rEstimate;
				//prende la riga di contratto esistente o ne crea una nuova
				if (rEstimateArr != null && rEstimateArr.Length > 0) {
					rEstimate = rEstimateArr[0];
					idivakindDefault = impostaDefaultIvaKind(idcodiceTipoContratto, out errore);
					//DS.estimatedetail.get(_conn,q.mCmp(rEstimate, "idestimkind", "yestim", "nestim")); //non credo serva
				}
				else {
					tempNestim++;
					MetaData.SetDefault(DS.estimate, "idestimkind", idcodiceTipoContratto);
					MetaData.SetDefault(DS.estimate, "yestim", esercizio);

					idivakindDefault = impostaDefaultIvaKind(idcodiceTipoContratto, out errore);
					if (errore != "") {
						show(errore, "Errore");
						return false;
					}

					var rNewEstimate = metaEstimate.Get_New_Row(null, DS.estimate) as estimateRow;
					rNewEstimate.nestim = tempNestim;
					rNewEstimate.adate = _security.GetDataContabile();
					rNewEstimate.docdate = docdate;
					rNewEstimate.description = "Import.Flusso Studenti";

					rNewEstimate.idsor01 = idsor01;
					rNewEstimate.idsor02 = idsor02;
					rNewEstimate.idsor03 = idsor03;
					rNewEstimate.idsor04 = idsor04;
					rNewEstimate.idsor05 = idsor05;

					rNewEstimate.idaccmotivecredit = idaccmotivecredit;
					rEstimate = rNewEstimate;
					addEstimateRow(rEstimate);

				}

				var idivakind = idivakindDefault;
				object taxrate = DBNull.Value;
				if (rCreditiDetail["idivakind"] != DBNull.Value) {
					idivakind = rCreditiDetail.idivakind;
				}

				if (idivakind != null) {
					var iIdIVakind = CfgFn.GetNoNullInt32(idivakind);
					taxrate = ivaTaxRate[iIdIVakind];
				}

				var rNewDetail = metaEstimateDetail.Get_New_Row(rEstimate, DS.estimatedetail) as estimatedetailRow;
				var gestionedifferita = getGestioneDifferita(rNewDetail.idestimkind, out errore);
				if (gestionedifferita == "S") {
					//task 14606  non riportare le date di competenza sui Contratti attivi configurati come "Accertamenti differiti...".
					rNewDetail.flag = (rNewDetail.flag ?? 0) | 1; //scritture differite alla data contabile del dettaglio
				}
				else {
					rNewDetail.competencystart = competencystart;
					rNewDetail.competencystop = competencystop;
				}

				rNewDetail.idreg = idreg;
				rNewDetail.detaildescription = description;
				rNewDetail.iduniqueformcode = iduniqueformcode;
				rNewDetail.taxable = taxable;
				rNewDetail.tax = rCreditiDetail.tax;
				rNewDetail.idivakind = idivakind;
				rNewDetail.taxrateValue = taxrate;

				rNewDetail.number = number;
				rNewDetail.toinvoice = "N"; // sono di tipo non fatturabile 
				rNewDetail.nform = nform; // numero bollettino solo a titolo informativo
				rNewDetail.idlist = idlist;

				if (idaccmotiverevenue == null) {
					errore =
						$"Manca la causale di ricavo nel dettaglio crediti del bollettino n.{nform ?? iduniqueformcode}";
					show(errore, "Errore");
					return false;
				}

				rNewDetail["idaccmotive"] = idaccmotiverevenue;
				string erroreSiope;
				var idSiope = getSiopeForAccMotive(idaccmotiverevenue, out erroreSiope);
					if (erroreSiope != ""){
						show(erroreSiope, "Errore");
						return false;
					}
				if (idSiope != null) {
					rNewDetail.idsor_siope = idSiope;
				}

				if (idupb == null) {
					errore = $"Manca l'UPB nel dettaglio crediti del bollettino n.{nform}";
					show(errore, "Errore");
					return false;
				}

				rNewDetail.idupb = idupb;

				if (idfinmotive == null) {
					errore =
						$"Manca la causale finanziaria nel dettaglio crediti del bollettino n.{nform ?? iduniqueformcode}";
					show(errore, "Errore");
					return false;
				}

				rNewDetail.idfinmotive = idfinmotive;
				if (idfinmotive_iva != null) {
					rNewDetail.idfinmotive_iva = idfinmotive_iva;
				}
				//collega il dettaglio credito al dettaglio flusso crediti
				rCreditiDetail.idestimkind = rEstimate.idestimkind;
				rCreditiDetail.yestim = rEstimate.yestim;
				rCreditiDetail.nestim = rEstimate.nestim;
				rCreditiDetail.rownum = rNewDetail.rownum;
				rCreditiDetail.lt = DateTime.Now;
				rCreditiDetail.lu = "fillEstimate_" + _conn.externalUser;

				rNewDetail.idsor1 = rCreditiDetail.idsor1;
				rNewDetail.idsor2 = rCreditiDetail.idsor2;
				rNewDetail.idsor3 = rCreditiDetail.idsor3;

			}
			closePBar();

			return true;
		}

		/// <summary>
		/// Elabora gli annullamenti, ossia le righe dettaglio flusso crediti con stop NOT null e flag & 1 =0
		/// Riempie flussocreditidetail e anche incomevar e incomesorted (per annullare gli accertamenti)
		/// Preventivamente svuota income, incomevar, incomesorted
		/// </summary>
		/// <returns></returns>
		private bool fillAnnulment(object _from, object _to) {
		 
			QueryCreator.MarkEvent("Inizio fillAnnulment");
			initPBar("Inizializzazione Elaborazione annullamento crediti",1);
			// Ciclo per l'annullamento dei dettagli
			bool result = true;
			var iduniqueformcodeToAnnul = new List<string>();

			DS.income.Clear();
			DS.incomevar.Clear();
			DS.incomesorted.Clear();
			var metaIncomeVar = _dispatcher.Get("incomevar");
			contrattoAttivoByKey.Clear();

			MetaData.SetDefault(DS.incomeyear, "ayear", esercizio);
			//var filterNonElaborati = _qhs.AppAnd(_qhs.IsNotNull("stop"), _qhs.BitClear("isnull(flag,0)",0));

			q filtroCreditiAnnullati =
				q.eq(q.year("flussocreditidetail.stop"), esercizio) & q.doPar(q.isNull("flussocreditidetail.flag") | q.bitClear("flussocreditidetail.flag", 0));

			if (_from != DBNull.Value) {
				filtroCreditiAnnullati &= q.ge("flussocreditidetail.idflusso", _from);
			}

			if (_to != DBNull.Value) {
				filtroCreditiAnnullati &= q.le("flussocreditidetail.idflusso", _to);
			}

			DS.flussocreditidetail.safeReadTableJoined(_conn, "upb", filtroCreditiAnnullati,
				_conn.Security.SelectCondition("upb", false)?.toMetaExpression(), "idupb");
			QueryCreator.MarkEvent($"fillAnnulment - 1 : in DS.flussocreditidetail {DS.flussocreditidetail.Rows.Count} righe");

			string secUpb = _conn.Security.SelectCondition("upb", true);
			string joinUPB = ""; //join che sarà fatto tra flussocreditidetail e upb
			string whereUPB = ""; //filtro sulla sicurezza
			if (secUpb != null & secUpb!="") {
				var qSec = MetaExpressionParser.From(secUpb);
				if (qSec!=null) {
					qSec.cascadeSetTable("upb");
	
					joinUPB = " JOIN UPB ON flussocreditidetail.idupb=UPB.idupb ";
					whereUPB = " AND " + qSec.toSql(_qhs, _conn);
				}
			}

			string joinFlussoCreditidetail = ""; //join che sarà fatto tra flussocreditidetail e Estimatedetail 
			joinFlussoCreditidetail = " JOIN flussocreditidetail ON flussocreditidetail.idestimkind=estimatedetail.idestimkind " +
				" and flussocreditidetail.yestim=estimatedetail.yestim and flussocreditidetail.nestim=estimatedetail.nestim " +
				" and flussocreditidetail.rownum=estimatedetail.rownum " +
				" and flussocreditidetail.iduniqueformcode=estimatedetail.iduniqueformcode ";
			
			string[] columnNames = QueryCreator.ColumnNameList(DS.estimatedetail).Split(',');
			string owner = "estimatedetail";
			string columns = owner + '.'+columnNames[0];
			for (int i = 1; i < columnNames.Length; i++)  
			{
				columns += ',' + owner + '.' + columnNames[i];
			}
			//Legge i dett.c.attivi da annullare 
			string sqlEstimDet = $" SELECT { columns} " +
								 $" FROM estimatedetail " +
								 $" {joinFlussoCreditidetail} " +
								 $" {joinUPB} " +
			                     $" WHERE " +
				                     filtroCreditiAnnullati.toSql(_qhs)+
			                     $"	{whereUPB} " +
			                     $"	AND estimatedetail.stop is null ";
			                    
			DS.estimatedetail._sqlSafeMergeFromDb(_conn, sqlEstimDet);

			QueryCreator.MarkEvent($"fillAnnulment - 2 : in DS.estimatedetail {DS.estimatedetail.Rows.Count} righe");
			string sq = $@"SELECT  idinc, available
			from incometotal
				join estimatedetail on incometotal.idinc = estimatedetail.idinc_taxable or incometotal.idinc = estimatedetail.idinc_iva " +
							$" { joinFlussoCreditidetail}" +
								 $" {joinUPB} " +
								 $" WHERE " +
									 filtroCreditiAnnullati.toSql(_qhs) +
								 $"	{whereUPB} " +
							" AND incometotal.ayear=  " + $"{esercizio}  " + 
							" AND flussocreditidetail.idestimkind is not null AND flussocreditidetail.idinvkind is null " +
							" AND estimatedetail.stop is null ";

			var Incassi = _conn.SQLRunner($@"
				SELECT  idinc, available
						from incometotal 
							join estimatedetail on incometotal.idinc= estimatedetail.idinc_taxable or incometotal.idinc= estimatedetail.idinc_iva " +
							$" { joinFlussoCreditidetail}" +
								 $" {joinUPB} " +
								 $" WHERE " +
									 filtroCreditiAnnullati.toSql(_qhs) +
								 $"	{whereUPB} " +
							" AND incometotal.ayear=  " + $"{esercizio}  " +
							" AND flussocreditidetail.idestimkind is not null AND flussocreditidetail.idinvkind is null " +
							" AND estimatedetail.stop is null ");

			QueryCreator.MarkEvent($"fillAnnulment - 3 : in Incassi {Incassi.Rows.Count} righe");
			Dictionary<int, decimal> availablePerIdinc = new Dictionary<int, decimal>();
			foreach (DataRow r in Incassi.Rows) {
				availablePerIdinc[CfgFn.GetNoNullInt32(r["idinc"])] = CfgFn.GetNoNullDecimal(r["available"]);
			}

			incPBar();
			//DS.flussocreditidetail.mergeFromDb(_conn, filtroCreditiAnnullati);
			//DataAccess.RUN_SELECT_INTO_TABLE(_conn, DS.flussocreditidetail, "idflusso", filterNonElaborati, null, true);
			iduniqueformcodeToAnnul.Clear();
			var annulli = DS.flussocreditidetail.Filter(filtroCreditiAnnullati);

			QueryCreator.MarkEvent("Inizio foreach (var rCreditoAnnullo");
			// Richiede che le righe in flussocrediti da annullare siano già corredate della chiave del dettaglio contratto attivo
			initPBar(" Elaborazione annulli",annulli.Length);

			foreach (var rCreditoAnnullo in annulli) {
				incPBar();
				var iduniqueformcode = rCreditoAnnullo.iduniqueformcode;
				if (iduniqueformcode == null) continue;
				if (iduniqueformcodeToAnnul.Contains(iduniqueformcode)) continue;
				iduniqueformcodeToAnnul.Add(iduniqueformcode);

				// inserimenti
				// Leggo i dettagli contratto attivo da annullare facendo una ricerca per codice bollettino univoco
				// potrebbero essere anche in memoria se creo un contratto e contestualmente annullo certi dettagli
				//   oppure se ci sono più crediti annullati riferiti allo stesso contratto attivo
				var stop = rCreditoAnnullo.stop;

				//vanno prese dal flussocreditidetail collegate al dettaglio contratto attivo che stiamo annullando
				var idaccmotiveundotax = rCreditoAnnullo.idaccmotiveundotax;
				var idaccmotiveundotaxpost = rCreditoAnnullo.idaccmotiveundotaxpost;
				var idestimkind = rCreditoAnnullo.idestimkind;
				var yestim = rCreditoAnnullo.yestim;
				var nestim = rCreditoAnnullo.nestim;
				var rownum = rCreditoAnnullo.rownum;
				var filter = q.eq("iduniqueformcode", iduniqueformcode) & q.isNull("stop")
					 // mettere la condizione su dettaglio contratto attivo 
					 & q.eq("idestimkind", idestimkind) & q.eq("yestim", yestim)
					 & q.eq("nestim", nestim) & q.eq("rownum", rownum)
					; 

				 //if (rCreditiDetail["idestimkind"] == DBNull.Value) {
				 //    //show(this, "La riga di annullo numero " + rCreditiDetail["iddetail"] + " non è associata ad un contratto attivo", "Errore");
				 //    continue;
				 //}

				 // ora mi leggo i dettagli contratto attivo che provengono da salvataggi precedenti 
				 //DS.estimatedetail.safeMergeFromDb(_conn, filter); //questo restituisce solo le righe eventualmente aggiunte

				 //E' necessario il doppio passaggio perchè alcune righe potrebbero essere già in memoria, ossia presenti nella stessa elaborazione                
				 var estimateDetailRows = DS.estimatedetail.Filter(filter);

				//annulla i dettagli aventi quello iduniqueformcode
				foreach (var estimateDetailRow in estimateDetailRows) {
					Application.DoEvents();
					//Non deve compilare i campi della riga di annullo, non è richiesto
					//rCreditoAnnullo["idestimkind"] = estimateDetailRow["idestimkind"];
					//rCreditoAnnullo["yestim"] = estimateDetailRow["yestim"];
					//rCreditoAnnullo["nestim"] = estimateDetailRow["nestim"];
					//rCreditoAnnullo["rownum"] = estimateDetailRow["rownum"];
					bool annoPrecedente = CfgFn.GetNoNullInt32(estimateDetailRow["yestim"]) < esercizio;
					object idcausaleEpAnnullamento = annoPrecedente ? idaccmotiveundotaxpost : idaccmotiveundotax;



					//legge il contratto attivo in memoria ove non già presente
					// MA E' davvero necessario?? non credo (2020)
					getEstimateByKey(estimateDetailRow.idestimkind, estimateDetailRow.yestim, estimateDetailRow.nestim);

					//DS.estimate.get(_conn, q.mCmp(estimateDetailRow, "idestimkind", "yestim", "nestim"));

					// Crea una variazione dell'accertamento che contabilizza il dettaglio di importo pari a -importo
					var idincTaxable = estimateDetailRow["idinc_taxable"];
					var fltmovI = _qhs.CmpEq("idinc", idincTaxable);
					if (idincTaxable == DBNull.Value) {
						estimateDetailRow["stop"] = stop;
						estimateDetailRow["idaccmotiveannulment"] = idcausaleEpAnnullamento;
						continue;
					}

					var amount = CfgFn.GetNoNullDecimal(estimateDetailRow["taxable"]) +
					             CfgFn.GetNoNullDecimal(estimateDetailRow["tax"]);

					decimal available = 0;
					availablePerIdinc.TryGetValue(CfgFn.GetNoNullInt32(idincTaxable), out available);
					//CfgFn.GetNoNullDecimal(_conn.readValue("incometotal", q.eq("idinc", idincTaxable) & q.eq("ayear", esercizio), "available"));

					if (available < amount) {
						show(
							$"Il dettaglio {estimateDetailRow.idestimkind} {estimateDetailRow.yestim} {estimateDetailRow.nestim} riga {estimateDetailRow.rownum}" +
							$" {estimateDetailRow.detaildescription} non può essere annullato perchè già incassato",
							"Errore");
						 continue;
					}

					estimateDetailRow["stop"] = stop;
					estimateDetailRow["idaccmotiveannulment"] = idcausaleEpAnnullamento;

					//var nvar = 1;
					//if (_conn.RUN_SELECT_COUNT("incomevar", fltmovI, false) > 0) {
					//    var maxNvar = _conn.DO_READ_VALUE("incomevar", fltmovI, "max(nvar)");
					//    nvar = CfgFn.GetNoNullInt32(maxNvar) + 1;
					//}
					// Ciclo per creare le variazioni 

					var fltmovIParent = _qhs.CmpEq("idchild", idincTaxable);
					DataTable IncomeLink = _conn.RUN_SELECT("incomelink", "idparent", null,
						fltmovIParent, null, true);

					string lista = _qhs.DistinctVal(IncomeLink.Select(), "idparent");
					var movimentifin = IncomeLink.Select();
				 
					if (IncomeLink.Rows.Count >0)
						_conn.RUN_SELECT_INTO_TABLE(DS.income, null, _qhs.FieldInList("idinc", lista), null, false);
						_conn.RUN_SELECT_INTO_TABLE(DS.incomesorted, null, _qhs.FieldInList("idinc", lista), null, false);

						foreach (object idinc in movimentifin._Pick("idparent").ToArray()) {
							var fltmovIdinc = _qhs.CmpEq("idinc", idinc);
							MetaData.SetDefault(DS.incomevar, "idinc", idinc);
							var var = metaIncomeVar.Get_New_Row(null, DS.incomevar);
							metaIncomeVar.SetDefaults(DS.incomevar);
							var["yvar"] = esercizio;
							//var["nvar"] = nvar;
							var["adate"] = _security.GetDataContabile();
							var["idinc"] = idinc;
							if (idinc == idincTaxable)  var["autokind"] = 11; // annullamento totale
							var["amount"] = -amount;
							var["description"] = $"Annul. bollettino univoco numero {iduniqueformcode}";

							// Vario anche le classificazioni impostate allineandole con l'importo corrente
							_conn.RUN_SELECT_INTO_TABLE(DS.incomesorted, null, fltmovIdinc, null, true);
							var rSorted = DS.incomesorted.Select(_qhc.CmpEq("idinc", idinc));
							foreach (var rSor in rSorted) {
								rSor["amount"] = CfgFn.GetNoNullDecimal(rSor["amount"]) - amount;
							}
						}
				}

				rCreditoAnnullo["flag"] = CfgFn.GetNoNullInt32(rCreditoAnnullo["flag"]) | 1;

			}
			closePBar();

			//Salva i dati
			//var myPostData = new Easy_PostData();
			//myPostData.initClass(DS, _conn);
			//var res = myPostData.DO_POST();
			//return res;
			return result;
		}


		#region generazione fatture da crediti da web

		// riempe la struttura dati GroupedInvoice da utilizzare per la successiva
		// eventuale generazione delle fatture raggruppate x idreg e per idinvkind

		private Dictionary<int, DataRow> registryByIdReg = new Dictionary<int, DataRow>();

		DataRow getRegistry(int idReg) {
			if (registryByIdReg.ContainsKey(idReg)) return registryByIdReg[idReg];
			DataTable t = _conn.readTable("registry", q.eq("idreg", idReg), "idreg,email_fe,pec_fe,flag_pa,title");
			if (t.Rows.Count == 0) return null;
			registryByIdReg[idReg] = t.Rows[0];
			return registryByIdReg[idReg];
		}

		/// <summary>
		/// Estrae le anagrafiche distinte dei dettagli crediti filtrati con il filtroCrediti e per ognuna crea una lista di tipi fattura da creare
		/// </summary>
		/// <param name="filtroCrediti"></param>
		/// <returns></returns>
		private  Dictionary<int, List<int>> fillGroupedInvoice() {
			var groupedInvoice = new Dictionary<int, List<int>>();

			var righe = DS.flussocreditidetail.allCurrent();
			//var righe = DS.flussocreditidetail.getDetachedRowsFromDb(_conn, filtroComune); //Da fatturare
			if (righe == null) return groupedInvoice; //nulla da fatturare
			//var righeAnagr = DS.flussocreditidetail.readDetachedJoin(_conn, "registry", filtroCrediti, null, "idreg");

			foreach (var rCreditiDetail in righe) {
				var idreg = CfgFn.GetNoNullInt32(rCreditiDetail.idreg);
				if (idreg != 0 && !groupedInvoice.ContainsKey(CfgFn.GetNoNullInt32(idreg))) {
					groupedInvoice.Add(idreg, new List<int>());
				}
				var idinvkind = CfgFn.GetNoNullInt32(rCreditiDetail.idinvkind);
				if (idinvkind != 0 && groupedInvoice[idreg].IndexOf(idinvkind) == -1) {
					groupedInvoice[idreg].Add(idinvkind);
				}
			}

			return groupedInvoice;
		}


		private object calcolaDocumento(DataRow r, DataColumn c, IDataAccess conn) {
			var codiceDoc = r["idinvkind"];
			var formatString = DS.invoicekind.Filter(q.eq("idinvkind", codiceDoc))[0].formatstring ?? "{0:yy}/{1:d6}";
			var aa = new DateTime(CfgFn.GetNoNullInt32(r["yinv"]), 1, 1);
			var doc = string.Format(formatString, aa, r["ninv"]);
			//System.Diagnostics.Debug.WriteLine($"documento [{doc}]");
			return doc;
		}

		/// <summary>
		/// Prende i codiciBollettini di crediti incassati di flussi incasso non elaborati, saltando i crediti associati a contratti collegabili a fattura
		/// </summary>
		/// <param name="soloConSospesi"></param>
		/// <param name="errori"></param>
		/// <returns></returns>
		private List<string> getBollettiniFatturaDaConsiderare(bool soloConSospesi, out string errori) {
			initPBar("Inizializzazione calcolo bollettini da considerare",3);
			var bollettiniDaConsiderare = new HashSet<string>();
			//foreach(string b in bollettiniDaConsiderare)QueryCreator.MarkEvent("Bollettino da considerare: "+b);
			errori = "";
			// ciclo incassi non elaborati
			var filterNonElaborati = q.eq("ayear", esercizio) & q.eq("elaborato", "N");
			if (soloConSospesi) filterNonElaborati &= q.isNotNull("nbill");

			if (txtDaNumFlussoIncassi.Text == "" && txtANumFlussoIncassi.Text != "")
			{
				show("Il campo 'da n. flusso' non può essere vuoto", "Errore");
				return new List<string>();
			}
			else if (txtDaNumFlussoIncassi.Text != "" && txtANumFlussoIncassi.Text == "")
			{
				show("Il campo 'a n. flusso' non può essere vuoto", "Errore");
				return new List<string>();
			}

			if ((txtDaNumFlussoIncassi.Text != "") && (txtANumFlussoIncassi.Text != "")) {
				int daNFlussoDato;
				int aNFlussoDato;
				if (int.TryParse(txtDaNumFlussoIncassi.Text, out daNFlussoDato) &&
				    int.TryParse(txtANumFlussoIncassi.Text, out aNFlussoDato))  {
					filterNonElaborati &= q.between("idflusso", daNFlussoDato, aNFlussoDato);
				}
			}

			if ((txtDaNumFlussoIncassi.Text != "") &&(txtANumFlussoIncassi.Text == "")) {
				int nFlussoDato;
				if (int.TryParse(txtDaNumFlussoIncassi.Text, out nFlussoDato)) {
					filterNonElaborati &= q.eq("idflusso", nFlussoDato);
				}
			}			

			//Legge tutti i flussi aventi elaborato=N ed eventualmente solo con n.sospeso valorizzato
			var righeFlussoIncassi = DS.flussoincassi.mergeFromDb(_conn, filterNonElaborati);

			//legge tutti i dettaglio flusso incassi in un colpo solo
			DS.flussoincassidetail.safeReadTableJoined(_conn, "flussoincassi", null, filterNonElaborati, "idflusso");
			incPBar();
			//cond. di sicurezza per l'upb
			string secUpb = _conn.Security.SelectCondition("upb", true);
			string joinUPB = ""; //join che sarà fatto tra flussocreditidetail e upb
			string whereUPB = ""; //filtro sulla sicurezza
			if (secUpb != null & secUpb!="") {
				var qSec = MetaExpressionParser.From(secUpb);
				qSec.cascadeSetTable("upb");
				joinUPB = " JOIN UPB ON flussocreditidetail.idupb=UPB.idupb ";
				whereUPB = " AND " + qSec.toSql(_qhs, _conn);
			}

			//legge i dettagli flusso crediti in un colpo solo
			filterNonElaborati.cascadeSetTable("flussoincassidetailview",
				"flussoincassi"); //imposta la tabella per il filtro su flussoincassidetailview

			string colonneFlussoCreditiDetail = string.Join(",",
				(from c in DS.flussocreditidetail.Columns._names()
					where QueryCreator.IsReal(DS.flussocreditidetail.Columns[c])
					select "flussocreditidetail." + c).ToArray());

			string sqlCredDet = $"SELECT {colonneFlussoCreditiDetail} " +	//QueryCreator.ColumnNameList(DS.flussocreditidetail)
			                    $"FROM flussocreditidetail {joinUPB} WHERE " +
								"    idinvkind is not null and idestimkind is null  and ninv is null and yinv is null and "+
			                    $"	 ((iuv in (select iuv from flussoincassidetailview where {filterNonElaborati.toSql(_qhs)}) ) " +
			                    $"     OR (iduniqueformcode in (select iduniqueformcode from flussoincassidetailview where {filterNonElaborati.toSql(_qhs)})) " +
			                    $"	  ) " +
			                    $"		AND (flussocreditidetail.stop is null) AND (flussocreditidetail.annulment is null)  " +
			                    $" {whereUPB}";

			
			//unisce a  flussocreditidetail i crediti associati agli incassi non elaborati
			DS.flussocreditidetail._sqlSafeMergeFromDb(_conn, sqlCredDet);
			incPBar();

			var dettCreditiByIuv = new Dictionary<string, List<flussocreditidetailRow>>();
			foreach (var r in DS.flussocreditidetail) {
				if (r.stop != null) continue;
				if (r.annulment != null) continue;
				if (string.IsNullOrEmpty(r.iuv)) continue;
				if (!dettCreditiByIuv.TryGetValue(r.iuv, out var l)) {
					l= new List<flussocreditidetailRow>();
					dettCreditiByIuv[r.iuv] = l;
				}
				l.Add(r);
			}

			//Questa parte non credo serva, perchè qui stiamo cercando i bollettini per le fatture da creare
			//string sqlEstimDet = $"SELECT {QueryCreator.ColumnNameList(DS.estimatedetail)} "+
			//					 $" FROM estimatedetail WHERE iduniqueformcode in ("+
			//					 $" SELECT iduniqueformcode from flussocreditidetail "+
			//					 $" {joinUPB} "+
			//					 $" WHERE "+
			//					 $"	 ((iuv in (select iuv from flussoincassidetailview where {filterNonElaborati.toSql(_qhs)}) ) " +
			//					 $"     OR (iduniqueformcode in (select iduniqueformcode from flussoincassidetailview where {filterNonElaborati.toSql(_qhs)})) " +
			//					 $"	  ) " +
			//					 $"		AND (flussocreditidetail.stop is null) AND (flussocreditidetail.annulment is null)  " +
			//					 $"     )"+
			//					 $" {whereUPB}"+
			//					 $" AND estimatedetail.stop is null";

			

			//legge tutti i dett. contratti collegati a tali crediti
			//DS.estimatedetail._sqlSafeMergeFromDb(_conn, sqlEstimDet);
			incPBar();

			initPBar("Estrazione dati bollettini ",righeFlussoIncassi.Length);
			//var estimDetByIuv = new Dictionary<string, List<estimatedetailRow>>();
			//foreach (var r in DS.estimatedetail) {
			//	if (r.stop != null) continue;
			//	if (string.IsNullOrEmpty(r.iduniqueformcode)) continue;
			//	if (!estimDetByIuv.TryGetValue(r.iduniqueformcode, out var l)) {
			//		l= new List<estimatedetailRow>();
			//	}
			//	l.Add(r);
			//}
			

			var dettCreditiByCodiceBollettino = new Dictionary<string, List<flussocreditidetailRow>>();
			foreach (var r in DS.flussocreditidetail) {
				if (r.stop != null) continue;
				if (r.annulment != null) continue;
				if (r.iduniqueformcode == null) continue;
				if (!dettCreditiByCodiceBollettino.TryGetValue(r.iduniqueformcode, out var l)) {
					l= new List<flussocreditidetailRow>();
					dettCreditiByCodiceBollettino[r.iduniqueformcode] = l;
				}
				l.Add(r);
			}
			QueryCreator.MarkEvent($"Trovati {righeFlussoIncassi.Length} righe flusso incassi");
			initPBar("Estrazione dati bollettini ",righeFlussoIncassi.Length);

			//per tutti gli incassi da elaborare
			foreach (var rFlussoIncassi in righeFlussoIncassi) { //DS.flussoincassi.Select()
				
				incPBar();
				var idflusso = rFlussoIncassi["idflusso"];
				//QueryCreator.MarkEvent($"Considero flusso {idflusso}");
				var dettincassi = DS.flussoincassidetail.get(_conn, q.eq("idflusso", idflusso));

				//per ogni dettaglio del flusso incassi
				foreach (var rFileDet in dettincassi) {
					
					var iuv = rFileDet.iuv;
					//if (iuv == null) continue;
					//QueryCreator.MarkEvent($"Considero iuv {iuv}");

					flussocreditidetailRow[] dettCrediti = new flussocreditidetailRow[0];
					//Se c'è lo iuv, prende tutti i dettagli crediti associati a quello iuv
					if (!string.IsNullOrEmpty(iuv)&&dettCreditiByIuv.ContainsKey(iuv)) {
						//q filterCrediti = (q.eq("iuv", iuv) & q.isNull("stop")) & q.isNull("annulment");
						//dettCrediti = DS.flussocreditidetail.Filter(filterCrediti);
						dettCrediti = dettCreditiByIuv[iuv].ToArray();
						////QueryCreator.MarkEvent($"Trovati {dettCrediti.Length} in base a iuv {iuv}");
					}

					//Se c'è un codice bollettino, prende tutti i dettagli crediti associati a quel bollettino
					if ((dettCrediti == null || dettCrediti.Length == 0) &&
					    !string.IsNullOrEmpty(rFileDet.iduniqueformcode) && dettCreditiByCodiceBollettino.ContainsKey(rFileDet.iduniqueformcode)) {
						//q filterCrediti = (q.eq("iduniqueformcode", rFileDet.iduniqueformcode) & q.isNull("stop")) &
						//                  q.isNull("annulment");
						//dettCrediti = DS.flussocreditidetail.Filter(filterCrediti);
						dettCrediti = dettCreditiByCodiceBollettino[rFileDet.iduniqueformcode].ToArray(); 
						//QueryCreator.MarkEvent($"Trovati {dettCrediti.Length} in base a iduniqueformcode {rFileDet.iduniqueformcode}");
					}

					//Per ogni credito cosi individuato avente un codice bollettino
					foreach (var rCredito in dettCrediti) {
						var codiceBollettino = rCredito.iduniqueformcode;
						if (string.IsNullOrEmpty(codiceBollettino)) continue;
						if (bollettiniDaConsiderare.Contains(codiceBollettino)) {
							continue;
						}
						//QueryCreator.MarkEvent($"Considero credito {codiceBollettino}");

						//Non considera i bollettini associati a contratti attivi collegabili a fattura
						//bool contrattoCollegabileAFattura = false;

						//prende i dettagli contratto associati mediante codice bollettino, eventualmente anche leggendoli da db
						//if (!estimDetByIuv.TryGetValue(codiceBollettino, out var rows)) {
						//	rows = new List<estimatedetailRow>();
						//}

						//Abbiamo filtrato a priori solo i crediti da collegare a fattura e con idestimkind null, quindi la gestione che c'era qui di seguito non serve
						bollettiniDaConsiderare.Add(codiceBollettino);

						//foreach (var rEstimDet in rows) {
						//	// Se il contratto attivo è di tipo collegabile a fattura lo salto
						//	var collegabileafattura = getCollegabileAFattura(rEstimDet.idestimkind);
						//	// Non consideriamo dettagli contratti attivi di tipo collegabile a fattura perchè di quelli la fattura sarà generata diversamente
						//	if (collegabileafattura) {
						//		contrattoCollegabileAFattura = true;
						//		//QueryCreator.MarkEvent($"salto credito {codiceBollettino} per tipo contratto {rEstimDet.idestimkind}");
						//		break;
						//	}
						//}

						////aggiunge a fattureDaCreare solo per i bollettini di dettagli contratti attivi non associatibili a fatture
						//if (!contrattoCollegabileAFattura) {
						//	bollettiniDaConsiderare.Add(codiceBollettino);
						//	//QueryCreator.MarkEvent($"aggiungo bollettino {codiceBollettino}");
						//}
					}
				}
			}
			closePBar();
			return bollettiniDaConsiderare.ToList();
		}

		private bool GetDettFatturaSenzaScritture(DataRow InvDet) {
			string idrelated = EP_functions.GetIdForDocument(InvDet);

			if (_conn.RUN_SELECT_COUNT("entrydetail", _qhs.CmpEq("idrelated", idrelated), false) > 0)
				return false;
			else return true;
		}



		/// <summary>
		/// 
		/// </summary>
		/// <param name="bollettiniDaConsiderare"></param>
		/// <param name="elencoIdFlussiCreditiCollegati">idflusso delle fatture generate</param>
		/// <returns>-1 per errore siope, -2 per errore salvataggio saldi</returns>
		private int generaFatture(List<string> bollettiniDaConsiderare, out List<int> elencoIdFlussiCreditiCollegati) {
			// la verifica sul campo istransmitted='S' di flussocrediti è superfluea in quanto fattureDaCreare
			// contiene i iduniqueformcode (sul quale filtra fillGroupedInvoice) che sono stati presi dagli incassi e quindi è ovvio supporre che essendoci
			// già l'incasso il flusso debba necessariamente essere stato preventivamente trasmessso

			elencoIdFlussiCreditiCollegati = new List<int>();
			DS.ivaregister.Clear();

			//Prende i bollettini non collegati a fattura ma con tipo fattura impostato, e non collegati a tipo contratto attivo
			var filtroComune = q.isNull("ninv") & q.isNotNull("idinvkind") & q.isNull("yinv") &
			                   q.isNull("idestimkind") & q.isNull("stop") & q.isNull("annulment") &
			                   q.fieldIn("iduniqueformcode", bollettiniDaConsiderare.Cast<object>().ToArray());

			//Calcola un elenco in cui ad ogni idreg è associato un elenco di idinvkind 
			var groupedInvoice = fillGroupedInvoice();
			if (groupedInvoice.Count == 0) {
				//show("Nessuna fattura da generare dagli incassi.", "Avviso");
				return 0; //nulla da generare
			}

			var metaInvoiceDetail = MetaData.GetMetaData(this, "invoicedetail");
			metaInvoiceDetail.SetDefaults(DS.invoicedetail);
			var metaInvoice = MetaData.GetMetaData(this, "invoice");
			metaInvoice.SetDefaults(DS.invoice);
			var metaIvaRegister = MetaData.GetMetaData(this, "ivaregister");
			metaIvaRegister.SetDefaults(DS.ivaregister);

			//string invoiceFlagregister = DS.config[0].invoice_flagregister?.ToUpper() ?? "N";

			var idcurrencyEuro =
				CfgFn.GetNoNullInt32(_conn.readValue("currency", q.eq("codecurrency", "EUR"), "idcurrency"));

			var doc = DS.invoice.Columns["doc"];
			DS.invoice.ExtendedProperties["docautomatico"] = "S";
			DS.invoice.setAutoincrement(doc.ColumnName, null, null, 6);
			DS.invoice.setCustomAutoincrement(doc.ColumnName, calcolaDocumento);
			int maxInvoice = 9990000;
			var totFatGenerate = 0;
			//if (invoiceFlagregister == "S") {
			//    DS.ivaregister.setAutoincrement("ninv", null, null, 6);
			//    DS.ivaregister.setMySelector("ninv", "idinvkind", 0);
			//    DS.ivaregister.setMySelector("ninv", "yinv", 0);
			//    DS.ivaregister.setMySelector("ninv", "idivaregisterkind", 0);
			//    MetaData.SetDefault(DS.ivaregister, "yinv", esercizio); 

			//    DS.Relations.Remove("ivaregisterinvoice");
			//    DS.defineRelation("ivaregisterinvoice", "ivaregister", "invoice", "idinvkind", "yinv", "ninv");

			//    DS.invoice.clearAutoIncrement("ninv");                
			//}
			object flagiva_immediate_or_deferred =
				_conn.readValue("config", q.eq("ayear", esercizio), "flagiva_immediate_or_deferred");

			


			foreach (var invoicesByIdreg in groupedInvoice) { //tutti gli studenti/utenti web
				Application.DoEvents();
				var idreg = invoicesByIdreg.Key;
				//QueryCreator.MarkEvent($"FASE 1 Analizzo anagrafica {idreg}");

				bool anagraficaPubblicaAmministrazione = isPARegistry(idreg);

				//idinvkind >> invoiceRow
				var groupedInvoiceByidinvkindRow = new Dictionary<int, invoiceRow>();
				DS.flussocreditidetail.safeReadTableJoined(_conn, "upb", q.eq("idreg", idreg) & filtroComune,
					_security.SelectCondition("upb", true).toMetaExpression(), "idupb");
				//DS.flussocreditidetail.safeMergeFromDb(_conn, q.eq("idreg", idreg) & filtroComune);
				var righeCreditiDetail = DS.flussocreditidetail.Filter(q.eq("idreg", idreg) & filtroComune);
				// Da fatturare per idreg, idinvkind corrente e collegate ad incassi per iduniqueformcode

				flussocreditidetailRow rigaCreditoDetail;
				if (righeCreditiDetail == null || !righeCreditiDetail._HasRows()) {
					//non dovrebbe mai succedere, per costruzione
					continue;
				}

				rigaCreditoDetail = righeCreditiDetail.First();


				var rigaCredito = DS.flussocrediti.get(_conn, q.eq("idflusso", rigaCreditoDetail.idflusso)).First();

				//per ogni raggruppamento crea una riga in invoice e la mette in groupedInvoiceByidinvkindRow
				foreach (var idinvkind in invoicesByIdreg.Value) { //tutti i tipi di fatture associati allo studente
					QueryCreator.MarkEvent($"FASE 1 Trovato tipo fattura {idinvkind} per anagrafica {idreg}");
					DataRow regRow = getRegistry(idreg);

					#region testata invoice 

					if (groupedInvoiceByidinvkindRow.ContainsKey(idinvkind)) continue; //Nino: per costruzione lo ritengo superfluo

					var registerToLink = DS.invoicekindregisterkind.get(_conn, q.eq("idinvkind", idinvkind));
					var rInvKind = DS.invoicekind.get(_conn, q.eq("idinvkind", idinvkind))[0];
					

					DS.invoice.setDefault("yinv",  esercizio);
					DS.invoice.setDefault("idinvkind", idinvkind);
					var rInvoice = metaInvoice.Get_New_Row(null, DS.invoice) as invoiceRow;
					//Senza queste due istruzioni in caso di generazione multipla di fatture, ninv è sempre uguale e una riga si prende tutti i dettagli fattura
					// è un fatto, non un'ipotesi. E' da correggere ma in debug, capendo il perchè succede. (*)
					if (maxInvoice >= rInvoice.ninv) rInvoice.ninv = maxInvoice + 1;
					if (rInvoice.ninv > maxInvoice) maxInvoice = rInvoice.ninv;
					QueryCreator.MarkEvent($"Generato fattura n. {rInvoice.ninv} {rInvoice.yinv} {rInvoice.idinvkind}");
					QueryCreator.MarkEvent($"In invoice ci sono {DS.invoice.Rows.Count} righe");
					QueryCreator.MarkEvent($"Il massimo è {MetaData.MaxFromColumn(DS.invoice,"ninv")}");
					totFatGenerate++;


					if (rInvKind.ipa_fe != null) {
						rInvoice.ipa_ven_emittente = rInvKind.ipa_fe;
					}


					// ReSharper disable once PossibleNullReferenceException
					//rInvoice.idinvkind = idinvkind;

					//rInvoice.yinvValue = adesso.Year; era questa che causava il problema (*) di sopra
					rInvoice.active = "S";
					//rInvoice.adate = DateTime.Today;
					rInvoice.docdate = dataContabile;
					rInvoice.description = "Fattura da Portale Web";
					//rInvoice["doc"] = "";


					//task 14005 si richiede la valorizzazione dei campi per la f.e.
					rInvoice.idfepaymethod = "MP05"; //Bonifico
					rInvoice.idfepaymethodcondition = "TP02"; //Pagamento completo
					rInvoice.email_ven_clienteValue = regRow["email_fe"];
					rInvoice.pec_ven_clienteValue = regRow["pec_fe"];

					rInvoice.exchangerate = 1;
					//rInvoice.flagdeferred = "N"; //TODO nota doc - IN QUESTA VERSIONE SOLO PRIVATI OK
					rInvoice.idreg = idreg;
					rInvoice.officiallyprinted = "N";

					rInvoice.idcurrency = idcurrencyEuro;

					rInvoice.idexpirationkind = null;
					//rInvoice["idtreasurer"] = idtreasurer; //pre da upb quindi DEVO impostare da creditidetail e quindi nel dettaglio

					rInvoice["flagintracom"] =
						"N"; //TODO da verificare su doc - PER ORA OK fatture estere seguirà analisi
					rInvoice.flag_ddt = "N";
					rInvoice.flag = 2;
					rInvoice.idaccmotivedebit = rigaCreditoDetail.idaccmotivecredit;

					rInvoice.autoinvoice = "N";
					rInvoice.idsor01 = rigaCredito.idsor01; //TODO nota Doc - Risolto dovrebbe andar bene così
					rInvoice.idsor02 = rigaCredito.idsor02;
					rInvoice.idsor03 = rigaCredito.idsor03;
					rInvoice.idsor04 = rigaCredito.idsor04;
					rInvoice.idsor05 = rigaCredito.idsor05;

					rInvoice.toincludeinpaymentindicator = "N";
					rInvoice.resendingpcc = "N";
					rInvoice.touniqueregister =
						"N"; //TODO  PER IL MOMENTO SOLO PRIVATI RES IN ITALIA OK - Per persona giuridica potrebbe essere 'S' ?? - e Se vale 'S' va calcolato un n° di registro Nota Nino su doc
					rInvoice.idstampkind = "NO";
					rInvoice.flag_auto_split_payment = "N"; //TODO Nota su doc
					rInvoice.flag_enable_split_payment =
						"N"; //TODO  default 'N' ma bisogna a questo punto analizzare la logica di valorizzazione. IN Questa versione SOLO privati dovrebbe andar bene 
					rInvoice.flag_reverse_charge = "N";
					rInvoice["flagbit"] = 0;
					rInvoice["requested_doc"] = 0;

					if (anagraficaPubblicaAmministrazione) {
						rInvoice.flag_enable_split_payment = "S";
						rInvoice.flagdeferred = "N";
					}
					else {
						rInvoice.flag_enable_split_payment = "N";
						rInvoice.flagdeferred = "S";
					}

					


					//if (invoiceFlagregister == "N") { //in questo caso crea prima le fatture poi i registri
					foreach (var reg in registerToLink) {
						MetaData.SetDefault(DS.ivaregister, "idivaregisterkind", reg["idivaregisterkind"]);
						var rIvaRegister = metaIvaRegister.Get_New_Row(rInvoice, DS.ivaregister);
					}
					//}

					groupedInvoiceByidinvkindRow.Add(idinvkind, rInvoice);

					if (elencoIdFlussiCreditiCollegati.IndexOf((int) rigaCreditoDetail.idflusso) < 0) {
						elencoIdFlussiCreditiCollegati.Add((int) rigaCreditoDetail.idflusso);
					}

					#endregion

				} // 2° foreach su idinvkind (tipo di fattura) di ogni idreg 

				#region invoicedetail


				foreach (var rCreditiDetail in righeCreditiDetail) {
					QueryCreator.MarkEvent($"FASE 2 Trovato tipo fattura {rCreditiDetail.idinvkind} per anagrafica {idreg}");
					Application.DoEvents();
					string erroreSiope;
					var rigaList = DS.list.get(_conn, q.eq("idlist", rCreditiDetail["idlist"]))._First();
					if ((rCreditiDetail["idlist"]!=DBNull.Value)&&(rigaList == null))
					{
						show("Voce di listino inesistente in dett. flusso crediti n° " + rCreditiDetail["idflusso"] + "/ dett. " + rCreditiDetail["iddetail"], @"Errore"); //?? mostrare errore e interrompere  
						return -1;
					}

					var idinvkind = CfgFn.GetNoNullInt32(rCreditiDetail["idinvkind"]);
					var invoiceRow = groupedInvoiceByidinvkindRow[idinvkind];
					QueryCreator.MarkEvent($"Ripreso fattura n. {invoiceRow.ninv} {invoiceRow.yinv} {invoiceRow.idreg}");
					var rInvoiceDetail = metaInvoiceDetail.Get_New_Row(invoiceRow, DS.invoicedetail) as invoicedetailRow; //associata a testata per idinvkind corretto!
					rInvoiceDetail.ninv = invoiceRow.ninv;
					//rCreditiDetail["stop"] = DBNull.Value;  
					if (rInvoiceDetail.rownum < 1000) rInvoiceDetail.rownum = 1000;
					rCreditiDetail.idinvkind = rInvoiceDetail.idinvkind;
					rCreditiDetail.yinv = rInvoiceDetail.yinv;
					rCreditiDetail.ninv = rInvoiceDetail.ninv;
					rCreditiDetail.invrownum = rInvoiceDetail.rownum;

					rInvoiceDetail.annotations = rCreditiDetail.annotations;
					// ReSharper disable once PossibleNullReferenceException
					//rInvoiceDetail.annotations = null;
					rInvoiceDetail.competencystart = rCreditiDetail.competencystart;
					//rInvoiceDetail.paymentcompetency = null;
					rInvoiceDetail.competencystop = rCreditiDetail.competencystop;
					rInvoiceDetail.detaildescription = rCreditiDetail.description; //rigaList.description;
					//rInvoiceDetail.discount = null;
					rInvoiceDetail.idaccmotive = rCreditiDetail.idaccmotiverevenue;
					//rInvoiceDetail.idmankind = null;
					rInvoiceDetail["idupb"] = rCreditiDetail["idupb"];

					rInvoiceDetail["idupb_iva"] = rCreditiDetail.idupb_iva; // ["idupb_iva"];

					if (invoiceRow["idtreasurer"] == DBNull.Value
					) {
						object idtreasurer = DBNull.Value;
						if (rCreditiDetail["idupb"] != null) {
							var rupb = DS.upb.get(_conn, q.eq("idupb", rCreditiDetail["idupb"]));
							if (rupb != null) {
								idtreasurer = rupb._First()["idtreasurer"];
							}
						}

						//TODO - prendo il primo tesoriere esistente tra tutti i dettaglicrediti
						invoiceRow["idtreasurer"] =
							idtreasurer; //per prenderlo da upb mi serve idupb creditidetail e quindi lo si deve impostare qui !
					}

					decimal number = CfgFn.GetNoNullDecimal(rCreditiDetail["number"]);
					if (rCreditiDetail["number"] == DBNull.Value) number = 1;
					rInvoiceDetail["number"] =number;
					rInvoiceDetail["tax"] = CfgFn.GetNoNullDecimal(rCreditiDetail["tax"]);
					rInvoiceDetail["taxable"] = CfgFn.GetNoNullDecimal(rCreditiDetail["importoversamento"]) /number; //TODO: Così è Prezzo unitario !!
					rInvoiceDetail["unabatable"] = 0;
					rInvoiceDetail["idestimkind"] = rCreditiDetail["idestimkind"];
					rInvoiceDetail["nestim"] = rCreditiDetail["nestim"];
					rInvoiceDetail["yestim"] = rCreditiDetail["yestim"];
					rInvoiceDetail["idivakind"] = CfgFn.GetNoNullInt32(rCreditiDetail["idivakind"]);
					rInvoiceDetail["idinvkind"] = CfgFn.GetNoNullInt32(rCreditiDetail["idinvkind"]);
					rInvoiceDetail.idsor1 = rCreditiDetail.idsor1;
					rInvoiceDetail.idsor2 = rCreditiDetail.idsor2;
					rInvoiceDetail.idsor3 = rCreditiDetail.idsor3;

					rInvoiceDetail["idlist"] = rCreditiDetail.idlist;

					rInvoiceDetail.idunit = rigaList.idunit;
					rInvoiceDetail.idpackage = rigaList.idpackage;
					rInvoiceDetail.unitsforpackage = CfgFn.GetNoNullInt32(rigaList.unitsforpackage);
					rInvoiceDetail.unitsforpackage =
						rInvoiceDetail.unitsforpackage == 0 ? 1 : rInvoiceDetail.unitsforpackage;

					var npackage = number / (int) rInvoiceDetail.unitsforpackage;

					rInvoiceDetail["npackage"] = npackage;
					rInvoiceDetail.flag = rCreditiDetail.flag;
					rInvoiceDetail["flagbit"] = 0;
					rInvoiceDetail.idfinmotive = rCreditiDetail.idfinmotive;
					rInvoiceDetail.idfinmotive_iva = rCreditiDetail.idfinmotive_iva;
					rInvoiceDetail.iduniqueformcode = rCreditiDetail.iduniqueformcode;
					var idSiope = getSiopeForAccMotive(rCreditiDetail.idaccmotiverevenue, out erroreSiope);
					if (!string.IsNullOrEmpty(erroreSiope)) {
						show(erroreSiope, @"Errore"); //?? mostrare errore e interrompere ?
						return -1;
					}

					if (idSiope != null) {
						rInvoiceDetail["idsor_siope"] = idSiope;
					}

					calcolaIvaIvaindetraibile(rInvoiceDetail, invoiceRow);
				}


				#endregion


			} // 1° foreach su idreg (studenti)

			

			//DataSet d = DS.Copy();
			//foreach (DataTable t in d.Tables) {
			//	if (t.HasChanges()) continue;
			//	t.Clear();
			//}

			//d.WriteXml("flussoIncassiDataSet.xml");

			//Salva i dati per assegnare i numeri alle fatture
			var myPostData = new Easy_PostData();
			myPostData.initClass(DS, _conn);
			bool res = myPostData.DO_POST();
			if (res) show("Le fatture sono state generate", "Avviso");
			if (!res) return -2;

			return totFatGenerate;
		}

		bool isPARegistry(int idreg) {
			DataRow reg = getRegistry(idreg);
			object flag_pa = reg["flag_pa"];
			//object flag_pa = _conn.readValue("registry", q.eq("idreg", idreg), "flag_pa");
			if (flag_pa?.ToString().ToUpperInvariant() == "S") return true;
			return false;
		}

		private bool GetGeneralFlagSplitPayment() {
			if (DS.config.Rows.Count > 0) {
				DataRow rSetup = DS.config.Rows[0];
				if (rSetup["flagsplitpayment"] == DBNull.Value)
					return false;
				return (rSetup["flagsplitpayment"].ToString() == "S");
			}
			else
				return false;
		}

		private bool GetGestisceImpegniBudget() {
			if (DS.config.Rows.Count > 0) {
				DataRow rSetup = DS.config.Rows[0];
				if (rSetup["flagepexp"] == DBNull.Value)
					return false;
				return (rSetup["flagepexp"].ToString() == "S");
			}
			else
				return false;
		}
		private bool GestisceScritture() {
			 
	    	if (epMain.attivo)
					return true;
			else
				return false;
		}
		#endregion


		#region stampa fattura

		DataTable createPrimaryTable() {
			//if (DS.Tables["export"] != null) {
			//	myPrymaryTable = DS.Tables["export"];
			//	return myPrymaryTable;
			//}

			var myPrimaryTable = new DataTable("export");
			//var dataContabile = _security.GetDataContabile();

			//Create a dummy primary key
			var dcpk = new DataColumn("DummyPrimaryKeyField", typeof(int)) {DefaultValue = 1};
			myPrimaryTable.Columns.Add(dcpk);
			myPrimaryTable.PrimaryKey = new[] {dcpk};

			myPrimaryTable.Columns.Add(new DataColumn("reportname", typeof(string)));
			myPrimaryTable.Columns.Add(new DataColumn("ayear", typeof(int)) {DefaultValue = esercizio});
			myPrimaryTable.Columns.Add(new DataColumn("printkind", typeof(string)) {DefaultValue = "I"});
			myPrimaryTable.Columns.Add(new DataColumn("idinvkind", typeof(int)));
			myPrimaryTable.Columns.Add(new DataColumn("ninv_start", typeof(int)));
			myPrimaryTable.Columns.Add(new DataColumn("ninv_stop", typeof(int)));
			myPrimaryTable.Columns.Add(new DataColumn("official", typeof(string)) {DefaultValue = "N"});
			myPrimaryTable.Columns.Add(new DataColumn("showcfpiva", typeof(string)) {DefaultValue = "C"});
			myPrimaryTable.Columns.Add(new DataColumn("autoinvoice", typeof(string)) {DefaultValue = "N"});

			var r = myPrimaryTable.NewRow();
			myPrimaryTable.Rows.Add(r);
			//DS.Tables.Add(myPrymaryTable);
			return myPrimaryTable;
		}

		private bool stampaInviaMailFatture(invoiceRow fattura) {
			string errmess;
			string pdfFileName;
			registryRow registryrow;
			var msgprefix = "Si è verificato un errore ";

			bool res = stampaFattura(fattura, out errmess, out pdfFileName, out registryrow);
			if (res) {
				Application.DoEvents();
				var sm = new SendMail {Conn = _conn as DataAccess};
				var idreg = registryrow.idreg;
				var registryreferencerow = DS.registryreference
					.get(_conn, q.eq("idreg", idreg) & q.eq("activeweb", "S"))._First();
				if (registryreferencerow == null) return false;

				try {
					var metaUniversitaRow = DS.generalreportparameter.get(_conn,
						q.eq("idparam", "DenominazioneUniversita") & q.isNull("stop"));
					string universita = "";
					if (metaUniversitaRow != null) {
						universita = metaUniversitaRow._First()["paramvalue"].ToString();
					}

					sm.addAttachment(pdfFileName);
					sm.To = registryreferencerow.email;
					sm.Subject = "Invio fattura per articoli acquistati sul portale dell'Università " + universita;
					sm.MessageBody =
						"In allegato alla presente si invia la fattura per quanto acquistato sul nostro sito web";

					sm.UseSMTPLoginAsFromField = true;
					if (!sm.Send()) {
						if (sm.ErrorMessage.Trim() != "") {
							show(
								$"{msgprefix}nell\'invio della fattura a mezzo e-mail: ({fattura.ninv}/{fattura.yinv} - {fattura.idinvkind}) - {sm.ErrorMessage.Trim()}");
							return false;
						}
					}

					//System.Threading.Thread.Sleep(5000);
				}
				catch (Exception e) {
					show(
						$"{msgprefix}nell\'invio della fattura a mezzo e-mail: ({fattura.ninv}/{fattura.yinv} - {fattura.idinvkind}) - {e.Message}");
					return false;
				}

			}
			else {
				show(
					$"{msgprefix}nella stampa della fattura: ({fattura.ninv}/{fattura.yinv} - {fattura.idinvkind}) - {errmess}");
				return false;
			}

			return true;
		}


		private bool stampaFattura(invoiceRow invoice, out string errmess, out string pdfFileName,
			out registryRow registryrow) {
			pdfFileName = "";
			registryrow = null;
			var nomeReport = "fatturavendita";
			var drReg = DS.registry.getDetachedRowsFromDb(_conn, q.eq("idreg", invoice.idreg) & q.eq("active", "S"));
			if (drReg == null) {
				errmess = $"Registry non trovato: \'{invoice.idreg}\'";
				return false;
			}

			registryrow = drReg._First();

			DataTable myPrymaryTable = createPrimaryTable();
			myPrymaryTable.Rows[0]["printkind"] = "I";
			myPrymaryTable.Rows[0]["reportname"] = nomeReport;
			myPrymaryTable.Rows[0]["idinvkind"] = invoice.idinvkind;
			myPrymaryTable.Rows[0]["ninv_start"] = invoice.ninv; //Significa che DEVONO essere state salvate !
			myPrymaryTable.Rows[0]["ninv_stop"] = invoice.ninv; //Significa che DEVONO essere state salvate !
			if (registryrow.p_iva == null)
				myPrymaryTable.Rows[0]["showcfpiva"] = "C";
			else
				myPrymaryTable.Rows[0]["showcfpiva"] = "P";

			var modulereport = DS.report.getDetachedRowsFromDb(_conn, q.eq("reportname", nomeReport));

			if (modulereport == null) {
				errmess = "Report: '" + nomeReport + "' non trovato.";
				return false;
			}

			;
			var rep = modulereport._First();
			var par = myPrymaryTable.Rows[0];

			var myRptDoc = Easy_DataAccess.GetReport(_conn as Easy_DataAccess, rep, par, out errmess);
			if (myRptDoc == null) {
				return false;
			}

			string tempdir = Path.GetTempPath();
			if (!tempdir.EndsWith("\\")) tempdir += "\\";
			var tempfilename = Guid.NewGuid() + ".pdf";
			pdfFileName = tempdir + tempfilename;
			return exportToPdf(myRptDoc, tempfilename, tempdir);
		}

		/// <summary>
		/// Restituisce il percorso del report in formato PDF a cui puntare con Response.Redirect
		/// </summary>
		/// <param name="rd"></param>
		/// <param name="fileName"></param>
		/// <param name="relativePath"></param>
		/// <returns></returns>
		private bool exportToPdf(ReportDocument rd, string fileName, string relativePath) {
			var tempfilename = relativePath + fileName;
			// Declare variables and get the export options.
			//ExportOptions exportOpts = new ExportOptions();
			//PdfRtfWordFormatOptions pdfRtfWordOpts = new PdfRtfWordFormatOptions ();

			// Set the export format.
			//pdfRtfWordOpts.FirstPageNumber = 1;
			//pdfRtfWordOpts.LastPageNumber = 2;
			//pdfRtfWordOpts.UsePageRange = true;
			//RD.ExportOptions.FormatOptions = pdfRtfWordOpts;
			rd.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
			rd.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;

			DiskFileDestinationOptions diskOpts = new DiskFileDestinationOptions {DiskFileName = tempfilename};
			rd.ExportOptions.DestinationOptions = diskOpts;

			// Export the report
			try {
				rd.Export();
				return File.Exists(tempfilename);
			}
			catch (Exception e) {
				if (!e.ToString().Contains("0x8000030E")) return false;
				show(this,
					"E' necessario disinstallare l'aggiornamento di windows KB3102429 per poter effettuare la stampa.\nSeguono istruzioni su come procedere.",
					"Avviso");
				runProcess("disinstalla_kb3102429.pdf", true);
				return false;
			}
		}

		#endregion

		///// <summary>
		///// Ricalcola iva e ivaindetraibile in base a imponibile, quantità, tasso cambio e sconto
		///// </summary>
		///// <param name="rInvoicedetail"></param>
		private void calcolaIvaIvaindetraibile(DataRow rInvoicedetail, invoiceRow rInvoice) {
			double newnpackage = CfgFn.GetNoNullDouble(rInvoicedetail["npackage"]);
			double tassocambio = CfgFn.GetNoNullDouble(CfgFn.GetNoNullDouble(rInvoice["exchangerate"]));
			var rIvaKind = DS.ivakind.f_Eq("idivakind", rInvoicedetail["idivakind"]).FirstOrDefault();
			double aliquota = CfgFn.GetNoNullDouble(rIvaKind?.rateValue);

			//_conn.readValue("ivakind", q.eq("idivakind", rInvoicedetail["idivakind"]), "rate"));
			double percindeduc = CfgFn.GetNoNullDouble(rIvaKind?.unabatabilitypercentageValue);
			//q.eq("idivakind", rInvoicedetail["idivakind"]), "unabatabilitypercentage");
			double imponibile = CfgFn.GetNoNullDouble(rInvoicedetail["taxable"]);
			double quantitaConfezioni = newnpackage;
			double sconto = CfgFn.GetNoNullDouble(rInvoicedetail["discount"]);
			double imponibiletot = CfgFn.RoundValuta((imponibile * quantitaConfezioni * (1 - sconto)));
			double imponibiletotEur = CfgFn.RoundValuta(imponibiletot * tassocambio);
			double ivaEur = CfgFn.RoundValuta(imponibiletotEur * aliquota);
			double impindeducEur = CfgFn.RoundValuta(ivaEur * percindeduc);

			rInvoicedetail["tax"] = ivaEur;
			rInvoicedetail["unabatable"] = impindeducEur;
		}

		///// <summary>
		///// Imposta un flag su tutte le righe di flussocrediti ancora non elaborate ma annullate  avente 
		/////     iduniqueformcode presente in iduniqueformcodeToAnnul
		///// </summary>
		///// <param name="D"></param>
		///// <param name="ErrMsg"></param>
		///// <returns></returns>
		//bool myAnnulmentUpdater(DataSet D, out string ErrMsg) {
		//    ErrMsg = null;
		//    object annulDate = Meta.Conn.GetSys("datacontabile");
		//    foreach(object iduniqueformcode in iduniqueformcodeToAnnul) {
		//        Meta.Conn.DO_SYS_CMD("update flussocreditidetail set flag=isnull(flag,0) | 1 where " +
		//               QHS.AppAnd(QHS.CmpEq("iduniqueformcode", iduniqueformcode), QHS.IsNotNull("annulment"), QHS.BitClear("flag", 0)),
		//               out ErrMsg);                
		//        if (ErrMsg != null) return false;
		//    }
		//    return true;
		//}

		void azzeraMovimentiFinanziariEntrata() {
			DS.income.Clear();
			DS.incomelast.Clear();
			DS.income.Clear();
			DS.incomeyear.Clear();
			DS.incomesorted.Clear();
			DS.incomeinvoice.Clear();
			DS.incomelastestimatedetail.Clear();
		}

		bool creaFatture(bool soloConSospesi) {
			string error = "";
			var bollettiniDaConsiderare = getBollettiniFatturaDaConsiderare(soloConSospesi, out error);
			List<int> fattureGenerateByIdFlusso;
			if (bollettiniDaConsiderare.Count == 0) {
				show("Non sono stati trovati bollettini da elaborare.", "Avviso");
				return true;
			}
			int fattureCreate = generaFatture(bollettiniDaConsiderare, out fattureGenerateByIdFlusso);

			if (fattureCreate == 0) {
				show("Non sono state trovate fatture da generare.", "Avviso");
				return true;
			}

			VisualizzaFatture();

			if (fattureCreate < 0) {
				if (fattureCreate == -1)
					show("Errore nella generazione fatture - probabile errore siope", "Errore");
				if (fattureCreate == -2)
					show("Errore nella generazione fatture - errore salvando i dati", "Errore");
				return false; //-1 errore siope
			}

			if (!doStampaInviaMailFatture()) {
				show("Errore nell'invio delle mail per le fatture", "Errore");
			}

			generoScrittureFatture();


			return true;
		}


		bool generaIncassiFatture(bool soloConSospesi, out string error) {
			error = "";
			DataSet dSupdated;

			azzeraMovimentiFinanziariEntrata();

			
			bool res = creaIncassiFatture(soloConSospesi);
			if (!res) {
				error = " (Crea Incassi Fatture)";
				return false;
			}
			PostData.RemoveFalseUpdates(DS);

			if (res && !DS.HasChanges()) {
				show("Nessun incasso da generare");
			}

			if (res && DS.HasChanges()) {
				if (doSave(out dSupdated)) {//da qui esce fuori il messaggio  Dati Salvati
					show("Gli incassi per le fatture sono stati generati");
				}
			}

			azzeraTutto();

			return res;

		}

		/// <summary>
		/// In ds i dati aggiornati su flussocrediti flussoincassi invoice estimate ivaregister
		/// </summary>
		/// <param name="dSupdated"></param>
		/// <returns></returns>
		private bool aggiornaChiaviDs(DataSet sourceDataSet) {
			QueryCreator.MarkEvent("aggiornaChiaviDs()");
			try {
				DS.AcceptChanges();
				foreach (string tableName in new string[] {
					"flussocrediti", "flussocreditidetail", "flussoincassi", "flussoincassidetail",
					"invoice", "invoicedetail", "ivaregister", "estimate", "estimatedetail"
				}) {
					DS.Tables[tableName].Clear();
					if (sourceDataSet.Tables.Contains(tableName)) {
						DS.Tables[tableName].Merge(sourceDataSet.Tables[tableName], false);
						QueryCreator.MarkEvent($"Merge(sourceDataSet.Tables[{tableName}])");
						DS.Tables[tableName].AcceptChanges();
					}
				}

			}
			catch (Exception ex) {
				show(this,
					$"Errore nell\'aggiornamento delle chiavi del db! Processo Terminato\n{ex.Message}");
				return false;
			}

			return true;
		}

		private void VisualizzaFatture() {
			__regTitles.Clear();
			for (int i = 0; i < DS.invoice.Rows.Count; i++) {
				AddVoceCreditore(DS.invoice.Rows[i]);
			}

			HelpForm.SetDataGrid(dgrFattureElaborate, DS.invoice);
		}


		/// <summary>
		/// Invia le mail per le fatture presenti in DS.invoice
		/// stampe fatture pdf e invio mail - DEVONO ESSERE già salvate per poter generare i pdf perchè viene richiesto il n° di fattura iniziale/finale
		/// </summary>
		/// <returns></returns>
		private bool doStampaInviaMailFatture() {
			//
			//TODO rivedere perchè in caso di errore le fatture NON vengono inviate al cliente web ed occorrerebbe 'contrassegnarle' per re-inviarle  ??

			foreach (var invoicerow in DS.invoice) {
				var res = stampaInviaMailFatture(invoicerow);
				if (!res) return false;
			}




			return true;
		}

		void initPBar(string op, int nOperations) {
			labPBar.Text = "Operazione in corso: " + op;
			pBar.Maximum = nOperations;
			pBar.Value = 0;
			pBar.Visible = true;
			Application.DoEvents();
		}

		void incPBar() {
			pBar.Increment(1);
			Application.DoEvents();
		}

		void closePBar() {
			labPBar.Text = "";
			pBar.Maximum = 0;
			pBar.Value = 0;
			pBar.Visible = false;
			Application.DoEvents();
		}

		/// <summary>
		/// Crea gli incassi per i contratti attivi, ed eventualmente anche gli accertamenti.
		/// Valorizza la data inizio per i dettagli contratto a generazione differita, imposta flagelaborato di flussoincassi ove necessario
		/// Non salva fisicamente i dati.
		/// </summary>
		/// <param name="soloConSospesi"></param>
		/// <returns></returns>
		private bool creaIncassiContrattiAttivi(bool soloConSospesi) {
			//Dictionary<int, decimal> flussoIncassiAmounts = new Dictionary<int, decimal>();

			initPBar("Inizializzazione calcolo incassi",5);
			var filterNonElaborati = q.eq("ayear", esercizio) & q.eq("elaborato", "N") & q.isNotNull("dataincasso");
			if (soloConSospesi) filterNonElaborati &= q.isNotNull("nbill");
			if ((txtDaNumFlussoIncassi.Text != "") && (txtANumFlussoIncassi.Text != "")) {
				int daNFlussoDato;
				int aNFlussoDato;
				if (int.TryParse(txtDaNumFlussoIncassi.Text, out daNFlussoDato) &&
					int.TryParse(txtANumFlussoIncassi.Text, out aNFlussoDato)) {
					filterNonElaborati &= q.between("idflusso", daNFlussoDato, aNFlussoDato);
				}
			}

			if ((txtDaNumFlussoIncassi.Text != "") && (txtANumFlussoIncassi.Text == "")) {
				int nFlussoDato;
				if (int.TryParse(txtDaNumFlussoIncassi.Text, out nFlussoDato)) {
					filterNonElaborati &= q.eq("idflusso", nFlussoDato);
				}
			}

			DS.flussoincassi._getFromDb(_conn, filterNonElaborati.toSql(_qhs,_conn) + 
			                                   $" AND (nbill is null or nbill in (select nbill from bill where billkind='C' AND ybill={esercizio}) )");
			DS.flussoincassidetail.readTableJoined(_conn, "flussoincassi", null, filterNonElaborati, "idflusso");
			//In flussoincassidetail tutti i dett. incassi non elaborati
			incPBar();

			//var filterCrediti = q.or(
			//	                    q.eq(q.field("iuv", "flussoincassidetail"), q.field("iuv", "flussocreditidetail")),
			//	                    q.eq(q.field("iduniqueformcode", "flussoincassidetail"),
			//		                    q.field("iduniqueformcode", "flussocreditidetail"))
			//                    )

			//                    & q.isNull("stop") & q.isNull("annulment");

			string colonneDettCrediti = string.Join(",",
				(from c in DS.flussocreditidetail.Columns._names()
					where QueryCreator.IsReal(DS.flussocreditidetail
						.Columns[c]) //& c!="barcodeimage" & c!="qrcodeimage"
					select "flussocreditidetail." + c).ToArray());
			var condUpb = _security.SelectCondition("upb", true).toMetaExpression();

			var joinUpbSql = "";
			var condUpbSql = "";
			if (condUpb != null) {
				condUpb.cascadeSetTable("upb");
				joinUpbSql = " join upb on flussocreditidetail.idupb = upb.idupb ";
				condUpbSql = " AND " + condUpb.toSql(_qhs);
			}

			//Estrai i dettagli crediti  corrispondenti ai dett.incassi, o per iuv o per iduniqueformcode - escludendo i crediti annullati e gli annullamenti
			string sqlGetCrediti = $@"SELECT {colonneDettCrediti}
										FROM flussocreditidetail
										{joinUpbSql}
										WHERE (
											EXISTS (
												SELECT *
												FROM flussoincassidetail
												JOIN flussoincassi ON flussoincassi.idflusso=flussoincassidetail.idflusso
												WHERE (flussoincassidetail.iuv = flussocreditidetail.iuv)
												AND {filterNonElaborati.toSql(_qhs)}
											)
											OR
											EXISTS (
												SELECT *
												FROM flussoincassidetail
												JOIN flussoincassi ON flussoincassi.idflusso=flussoincassidetail.idflusso
												WHERE (flussoincassidetail.iduniqueformcode = flussocreditidetail.iduniqueformcode)
												AND {filterNonElaborati.toSql(_qhs)}
											)
										)
										AND flussocreditidetail.stop is null AND flussocreditidetail.annulment is null
										{condUpbSql}";



			DS.flussocreditidetail._sqlGetFromDb(_conn, sqlGetCrediti, 0);
			incPBar();

			string colonneDettContratti = string.Join(",",
				(from c in DS.estimatedetail.Columns._names()
					where QueryCreator.IsReal(DS.estimatedetail.Columns[c])
					select "estimatedetail." + c).ToArray());

			//Estrae i dettagli contratti associati ai crediti in considerazione, prendendo tutti quelli aventi gli stessi iduniqueformcode esclusi i dett. annullati
			string sqlGetDetContratti = $@"SELECT {colonneDettContratti}
											FROM estimatedetail
											WHERE iduniqueformcode in (
												SELECT flussocreditidetail.iduniqueformcode
												FROM flussocreditidetail
												{joinUpbSql}
												WHERE (
													EXISTS (
														SELECT *
														FROM  flussoincassidetail
														JOIN flussoincassi ON flussoincassi.idflusso=flussoincassidetail.idflusso
														WHERE (flussoincassidetail.iuv = flussocreditidetail.iuv)
														AND {filterNonElaborati.toSql(_qhs)}
													)
													OR
													EXISTS (
														SELECT *
														FROM  flussoincassidetail
														JOIN flussoincassi ON flussoincassi.idflusso=flussoincassidetail.idflusso
														WHERE (flussoincassidetail.iduniqueformcode = flussocreditidetail.iduniqueformcode)
														AND {filterNonElaborati.toSql(_qhs)}
													)
												)
												AND flussocreditidetail.idestimkind is not null AND flussocreditidetail.idinvkind is null
												AND flussocreditidetail.stop is null AND flussocreditidetail.annulment is null
												{condUpbSql}
											)
											and stop is null";

			//La sicurezza l'abbiamo già filtrata sui crediti, non c'è bisogno di filtrarla anche sul dettaglio contratto
			DS.estimatedetail._sqlGetFromDb(_conn, sqlGetDetContratti, 0);
			incPBar();


			string colonneContratti = string.Join(",",
				(from c in DS.estimate.Columns._names()
					where QueryCreator.IsReal(DS.estimate.Columns[c]) & c!="txt"
					select "estimate." + c).ToArray());

			//Estrae i dettagli contratti associati ai crediti in considerazione, prendendo tutti quelli aventi gli stessi iduniqueformcode esclusi i dett. annullati
			string sqlGetContratti = $@"SELECT {colonneContratti}
									FROM estimate
									WHERE
										EXISTS (
											SELECT * FROM estimatedetail
											WHERE estimate.idestimkind=estimatedetail.idestimkind
											AND estimate.yestim = estimatedetail.yestim
											AND estimate.nestim = estimatedetail.nestim
											AND iduniqueformcode IN (
												SELECT flussocreditidetail.iduniqueformcode
												FROM flussocreditidetail
												{joinUpbSql}
												WHERE (
													EXISTS (
														SELECT *
														FROM flussoincassidetail
														JOIN flussoincassi ON flussoincassi.idflusso = flussoincassidetail.idflusso
														WHERE (flussoincassidetail.iuv = flussocreditidetail.iuv)
														AND {filterNonElaborati.toSql(_qhs)}
													)
													OR
													EXISTS (
														SELECT *
														FROM flussoincassidetail
														JOIN flussoincassi ON flussoincassi.idflusso = flussoincassidetail.idflusso
														WHERE (flussoincassidetail.iduniqueformcode = flussocreditidetail.iduniqueformcode)
														AND {filterNonElaborati.toSql(_qhs)}
													)
												)
												AND flussocreditidetail.idestimkind is not null AND flussocreditidetail.idinvkind is null
												AND flussocreditidetail.stop is null AND flussocreditidetail.annulment is null
												{condUpbSql}
											)
											AND estimatedetail.stop is null
										)";
			//La sicurezza l'abbiamo già filtrata sui crediti, non c'è bisogno di filtrarla anche sul dettaglio contratto
			DS.estimate._sqlSafeMergeFromDb(_conn, sqlGetContratti, 0);
			incPBar();


			string sqlIncassi = $@"SELECT idinc, available
							FROM incometotal 
							JOIN estimatedetail ON incometotal.idinc= estimatedetail.idinc_taxable OR incometotal.idinc= estimatedetail.idinc_iva
							WHERE incometotal.ayear = {esercizio} 
							AND iduniqueformcode IN (
								SELECT flussocreditidetail.iduniqueformcode
								FROM flussocreditidetail {joinUpbSql}
								WHERE (
									EXISTS (
										SELECT *
										FROM flussoincassidetail
										JOIN flussoincassi ON flussoincassi.idflusso = flussoincassidetail.idflusso
										WHERE (flussoincassidetail.iuv = flussocreditidetail.iuv)
										AND {filterNonElaborati.toSql(_qhs)} 
									)
									OR
									EXISTS (
										SELECT *
										FROM flussoincassidetail
										JOIN flussoincassi ON flussoincassi.idflusso=flussoincassidetail.idflusso
										WHERE (flussoincassidetail.iduniqueformcode = flussocreditidetail.iduniqueformcode)
										AND {filterNonElaborati.toSql(_qhs)} 
									)
								)
								AND flussocreditidetail.idestimkind is not null AND flussocreditidetail.idinvkind is null
								AND flussocreditidetail.stop is null AND flussocreditidetail.annulment is null
								{condUpbSql}
							)
							AND stop is null";

			var Incassi = _conn.SQLRunner(sqlIncassi, false,0);
			incPBar();

			

			string sqlGetDateContratti = $@"SELECT estimate.adate, estimate.idestimkind, estimate.yestim,estimate.nestim
										FROM estimate
										JOIN estimatedetail ON estimate.idestimkind = estimatedetail.idestimkind AND estimate.yestim = estimatedetail.yestim AND estimate.nestim = estimatedetail.nestim
										WHERE estimatedetail.iduniqueformcode in (
											SELECT flussocreditidetail.iduniqueformcode
											FROM flussocreditidetail
											{joinUpbSql}
											WHERE (
												EXISTS (
													SELECT *
													FROM  flussoincassidetail
													JOIN flussoincassi ON flussoincassi.idflusso=flussoincassidetail.idflusso
													WHERE (flussoincassidetail.iuv = flussocreditidetail.iuv)
													AND {filterNonElaborati.toSql(_qhs)}
												)
												OR
												EXISTS (
													SELECT *
													FROM  flussoincassidetail
													JOIN flussoincassi ON flussoincassi.idflusso=flussoincassidetail.idflusso
													WHERE (flussoincassidetail.iduniqueformcode = flussocreditidetail.iduniqueformcode)
													AND {filterNonElaborati.toSql(_qhs)}
												)
											)
											AND flussocreditidetail.idestimkind is not null AND flussocreditidetail.idinvkind is null
											AND flussocreditidetail.stop is null and flussocreditidetail.annulment is null
											{condUpbSql}
										)
										AND estimatedetail.stop is null";

			//La sicurezza l'abbiamo già filtrata sui crediti, non c'è bisogno di filtrarla anche sul dettaglio contratto
			DataTable dateContratti = _conn.SQLRunner(sqlGetDateContratti,false,0);
			incPBar();
			foreach(DataRow r in dateContratti.Rows)addEstimateDateToDict(r);


			var info = new infoCreaIncassi();
			foreach (DataRow  r in Incassi.Rows) {
				info.availableByIdInc[CfgFn.GetNoNullInt32(r["idinc"])] = CfgFn.GetNoNullDecimal(r["available"]);
			}
			foreach (var r in DS.flussocreditidetail) {
				info.addDettFlussoCrediti(r);
			}

			foreach (var r in DS.flussoincassidetail) {
				info.addDettFlussoIncassi(r);
			}

			foreach (var r in DS.estimatedetail) {
				info.addDettContratto(r);
			}

			RowChange.SetOptimized(DS.income, true);
			RowChange.ClearMaxCache(DS.income);
			var msg = new List<messaggio>();
			bool res = creaIncassiContrattiAttivi(soloConSospesi, TipoElaborazioneIncassi.imponibile, info, msg);//non modifica la tabella flussoincassi
			if (res) res = creaIncassiContrattiAttivi(soloConSospesi, TipoElaborazioneIncassi.iva, info, msg);
			if (res) res = creaIncassiContrattiAttivi(soloConSospesi, TipoElaborazioneIncassi.totali, info, msg);

			foreach (var rFlusso in DS.flussoincassi.all()) {
				var infoFlusso = info.flussoIncassiAmounts[rFlusso.idflusso];
				if (infoFlusso.importoFlusso == infoFlusso.sommaIncassi) rFlusso.elaborato = "S";//imposta elaborato=S di flussoincassi
			}

			if (res && msg.Count > 0) {
				List<string> txtMsg = new List<string>();
				foreach (var m in msg) {
					txtMsg.Add(m.error ? "Errore:" + m.msg : "Avviso:" + m.msg);
				}

                wndDisplay disp = new wndDisplay("Messaggi ottenuti nella creazione degli incassi", "", txtMsg);
                createForm(disp, this);
                disp.ShowDialog(this);
			}

			return res;
		}

		public class infoIncasso {
			public decimal importoFlusso;
			public decimal sommaCrediti;
			public decimal sommaIncassi;

			public infoIncasso() {
				importoFlusso = 0;
				sommaCrediti = 0;
				sommaIncassi = 0;
			}
		}

		public class infoCreaIncassi {
			public Dictionary<string, List<flussocreditidetailRow>> creditiPerIuv =
				new Dictionary<string, List<flussocreditidetailRow>>();

			public Dictionary<string, List<flussocreditidetailRow>> creditiPerUniqueFormCode =
				new Dictionary<string, List<flussocreditidetailRow>>();

			public Dictionary<string, List<estimatedetailRow>> dettContrattoPerUniqueFormCode =
				new Dictionary<string, List<estimatedetailRow>>();

			public Dictionary<string, List<invoicedetailRow>> dettFatturaPerUniqueFormCode =
				new Dictionary<string, List<invoicedetailRow>>();

			public Dictionary<string, bool> messaggioBollettinoMancante = new Dictionary<string, bool>();


			/// <summary>
			/// Informazioni per ogni flusso incassi, indicizzata su idflusso
			/// </summary>
			public Dictionary<int, infoIncasso> flussoIncassiAmounts = new Dictionary<int, infoIncasso>();

			public Dictionary<int, decimal> availableByIdInc = new Dictionary<int, decimal>();
			public Dictionary<int, incomeRow> incomeByIdInc = new Dictionary<int, incomeRow>();
			public Dictionary<int, incomeyearRow> incomeYearByIdInc = new Dictionary<int, incomeyearRow>();

			public Dictionary<int, List<flussoincassidetailRow>> dettFlussoIncassiPerIdFlusso =
				new Dictionary<int, List<flussoincassidetailRow>>();

			/// <summary>
			/// Indicizza un dett.incassi per idflusso
			/// </summary>
			/// <param name="r"></param>
			public void addDettFlussoIncassi(flussoincassidetailRow r) {
				if (!dettFlussoIncassiPerIdFlusso.ContainsKey(r.idflusso)) {
					dettFlussoIncassiPerIdFlusso[r.idflusso] = new List<flussoincassidetailRow>();
				}

				dettFlussoIncassiPerIdFlusso[r.idflusso].Add(r);
			}

			/// <summary>
			/// Indicizza un dett.c.attivo per iduniqueformcode
			/// </summary>
			/// <param name="r"></param>
			public void addDettContratto(estimatedetailRow r) {
				if (r.iduniqueformcode != null) {
					if (!dettContrattoPerUniqueFormCode.ContainsKey(r.iduniqueformcode)) {
						dettContrattoPerUniqueFormCode[r.iduniqueformcode] = new List<estimatedetailRow>();
					}

					dettContrattoPerUniqueFormCode[r.iduniqueformcode].Add(r);
				}
			}

			/// <summary>
			/// Indicizza un dett. fattura per codice iduniqueformcode
			/// </summary>
			/// <param name="r"></param>
			public void addDettFattura(invoicedetailRow r) {
				if (r.iduniqueformcode != null) {
					if (!dettFatturaPerUniqueFormCode.ContainsKey(r.iduniqueformcode)) {
						dettFatturaPerUniqueFormCode[r.iduniqueformcode] = new List<invoicedetailRow>();
					}

					dettFatturaPerUniqueFormCode[r.iduniqueformcode].Add(r);
				}
			}

			/// <summary>
			/// Indicizza un dettaglio credito per iuv
			/// </summary>
			/// <param name="r"></param>
			public void addDettFlussoCrediti(flussocreditidetailRow r) {
				if (r.iuv != null) {
					if (!creditiPerIuv.ContainsKey(r.iuv)) creditiPerIuv[r.iuv] = new List<flussocreditidetailRow>();
					creditiPerIuv[r.iuv].Add(r);
				}

				if (r.iduniqueformcode != null) {
					if (!creditiPerUniqueFormCode.ContainsKey(r.iduniqueformcode))
						creditiPerUniqueFormCode[r.iduniqueformcode] = new List<flussocreditidetailRow>();
					creditiPerUniqueFormCode[r.iduniqueformcode].Add(r);
				}
			}
		}

		/// <summary>
		///  Genera gli incassi di contratti attivi solo se non sono collegabili a fattura (in base alla configurazione del tipo contratto attivo).
		///  Infatti per quelli collegabili dovremo incassare le fatture. Non salva fisicamente i dati.
		/// </summary>
		/// <param name="conSospesi"></param>
		/// <param name="tipoElaborazione"></param>
		/// <param name="info"></param>
		/// <param name="messages"></param>
		/// <returns></returns>
		private bool creaIncassiContrattiAttivi(bool soloConSospesi, TipoElaborazioneIncassi tipoElaborazione,
			infoCreaIncassi info, List<messaggio> messages) {
			var incInvoice = _dispatcher.Get("incomeinvoice"); //Contabilizzazione fattura
			incInvoice.SetDefaults(DS.incomeinvoice);

			// Questa funzione viene modificata allo scopo di leggere i dati da db includendo anche il pregresso

			var mov = DS.income;
			var impMov = DS.incomeyear;
			var impLast = DS.incomelast;

			var fasecontratto = CfgFn.GetNoNullInt32(_security.GetSys("estimatephase"));
			var fasemassima = CfgFn.GetNoNullInt32(_security.GetSys("maxincomephase"));
			var fasebilancio = CfgFn.GetNoNullInt32(_security.GetSys("incomefinphase"));
			var faseinizio = fasecontratto + 1; //potrebbe essere maggiore di fase massima, attenzione!!
			var fasefine = fasemassima;

			var inc = _dispatcher.Get("income");
			var incY = _dispatcher.Get("incomeyear");
			var incL = _dispatcher.Get("incomelast");
			var incLD  = _dispatcher.Get("incomelastestimatedetail");

			bool monofase = (fasemassima == 1);

			inc.SetDefaults(DS.income);
			incY.SetDefaults(DS.incomeyear);
			incL.SetDefaults(DS.incomelast);

			MetaData.SetDefault(DS.incomeyear, "ayear", esercizio);

			var bollettiniElaborati = new Dictionary<string, bool>();
			var iuvElaborati = new Dictionary<string, bool>();
			var allRows = DS.flussoincassi.all();

			initPBar("Creazione contratti attivi - "+tipoElaborazione.ToString(),allRows.Count);
			
			//fattureDaCreare = new List<string>();
			foreach (var rFlussoIncassi in allRows ) { //DS.flussoincassi.Select()
				incPBar();
				Application.DoEvents();
				decimal sumIncassiContrattiAttivi = 0;
				if (!info.flussoIncassiAmounts.ContainsKey((int) rFlussoIncassi.idflusso)) {
					info.flussoIncassiAmounts.Add((int) rFlussoIncassi.idflusso,
						new infoIncasso() {
							importoFlusso = CfgFn.GetNoNullDecimal(rFlussoIncassi.importo)
						});
				}

				// Verifica esistenza della bolletta su DB
				var nbill = rFlussoIncassi["nbill"];
				string errore;

				////Questo controllo ora è fatto a monte
				//if (soloConSospesi || nbill != DBNull.Value) {
				//	nbill = getSospesiAttivi(nbill, out errore);
				//	if (nbill == DBNull.Value) {
				//		// Non è stato creato ancora sul db mediante l'importazione del giornale di cassa
				//		continue;
				//	}
				//}

				var idflusso = rFlussoIncassi.idflusso;
				if (!info.dettFlussoIncassiPerIdFlusso.ContainsKey(idflusso)) continue;

				foreach (var rFileDet in info.dettFlussoIncassiPerIdFlusso[idflusso]) {
					var iuv = rFileDet.iuv;
					if ((!string.IsNullOrEmpty(iuv))  && info.messaggioBollettinoMancante.ContainsKey(iuv)) {
						continue;
					}
					//if (iuv == null) continue;
					// Prende i dettagli contratto attivo da incassare facendo una ricerca per codice bollettino univoco saltando i dettagli annullati
					List<flussocreditidetailRow> dettCrediti = null;
					if ((!string.IsNullOrEmpty(iuv)) && info.creditiPerIuv.ContainsKey(iuv)) {
						dettCrediti = info.creditiPerIuv[iuv];
					}

					if ((!string.IsNullOrEmpty(rFileDet.iduniqueformcode))  && 
									info.messaggioBollettinoMancante.ContainsKey(rFileDet.iduniqueformcode)) {
						continue;
					}

					if ((dettCrediti == null) &&
					    (!string.IsNullOrEmpty(rFileDet.iduniqueformcode)) &&
					    info.creditiPerUniqueFormCode.ContainsKey(rFileDet.iduniqueformcode)
					) {
						dettCrediti = info.creditiPerUniqueFormCode[rFileDet.iduniqueformcode];
					}

					if (dettCrediti == null) {
						//Questo messaggio ora va bene perchè non scatta se il credito c'è ma è collegato a fattura, e scatta se il credito non c'è proprio
						//aggiungere controllo per assicurare unicità messagggio
						messages.Add(new messaggio() {
							error = false,
							msg =
								$"Non è stato trovato un credito per il bollettino di codice {rFileDet.iduniqueformcode} o iuv {iuv}"
						});
						if (!string.IsNullOrEmpty(iuv))info.messaggioBollettinoMancante[iuv]=true;
						if (!string.IsNullOrEmpty(rFileDet.iduniqueformcode))info.messaggioBollettinoMancante[rFileDet.iduniqueformcode]=true;

						continue;
					}

					// Ciclo sui dettagli crediti a parità di codice bollettino
					foreach (var rCredito in dettCrediti) {
						//Salta tutti i crediti non associati a tipi c.attivi
						if (rCredito.idestimkind == null) continue;

						var codiceBollettino = rCredito.iduniqueformcode;
						if (string.IsNullOrEmpty(codiceBollettino)) continue;


						if (bollettiniElaborati.ContainsKey(codiceBollettino)) {
							continue;
						}

						bollettiniElaborati.Add(codiceBollettino, true);

						// Leggo i dettagli contratto attivo da incassare facendo una ricerca per codice bollettino univoco
						//  salta i dettagli annullati
						List<estimatedetailRow> rows = null;
						if (info.dettContrattoPerUniqueFormCode.ContainsKey(codiceBollettino)) {
							rows = info.dettContrattoPerUniqueFormCode[codiceBollettino];
						}


						if (rows == null) continue;
						//int faseInizioPerQuestoContratto = faseinizio;
						foreach (var rEstimDet in rows) {
							// Se il contratto attivo è di tipo collegabile a fattura lo salto
							string errori;

							var currUpb = rEstimDet.idupb;
							var currUpbIva = rEstimDet.idupb_iva;
							var idinc_Taxable = rEstimDet.idinc_taxable;
							var idinc_Iva = rEstimDet.idinc_iva;
							//Se è valorizzata la Causale finanziaria IVA ma non è valorizzato l'UPB iva,
							// valorizzo l'upb iva al fine di generare un incasso separato per l'IVA [16307]
							if ((rEstimDet.idfinmotive_iva !=null) && (currUpb!=null)&&(currUpbIva == null)){
								currUpbIva = currUpb;
							}
							 
							switch (tipoElaborazione) {
								case TipoElaborazioneIncassi.totali:
									//Elaborazione pre modifica split fasi - esegue solo con upb_iva == null
									if (currUpb == null || currUpbIva != null)
										continue; //i totali devono avere un upb_iva NON impostato per essere elaborati
									break;
								case TipoElaborazioneIncassi.imponibile:
									if (currUpb == null || currUpbIva == null)
										continue; //upb e upb_iva devono essere entrambi  valorizzati
									break;
								case TipoElaborazioneIncassi.iva:
									if (currUpb == null || currUpbIva == null)
										continue; //upb e upb_iva devono essere entrambi  valorizzati
									break;
							}

							

							decimal imponibile = CfgFn.GetNoNullDecimal(rEstimDet.taxable);
							decimal sconto = CfgFn.GetNoNullDecimal(rEstimDet.discount);
							decimal quantita = CfgFn.GetNoNullDecimal(rEstimDet.number);
							decimal imponibiletot =
								CfgFn.GetNoNullDecimal(CfgFn.RoundValuta((imponibile * quantita * (1 - sconto))));
							var iva = CfgFn.GetNoNullDecimal(rEstimDet.tax);

							decimal amountBase = 0;
							switch (tipoElaborazione) {
								case TipoElaborazioneIncassi.totali:
									//Elaborazione pre modifica split fasi - esegue solo con upb_iva == null
									amountBase = imponibiletot + iva;
									break;
								case TipoElaborazioneIncassi.imponibile:
									// curUpbIva è sicuramente != null
									amountBase = imponibiletot;
									break;
								case TipoElaborazioneIncassi.iva:
									// curUpbIva è sicuramente != null
									amountBase = iva;
									break;
							}

							if (amountBase == 0) continue;

							// per i db monofase i dettagli contratto attivo incassati in una tornata precedente
							// devono essere dati per incassati 
							// per evitare di incassarli due volte
							if (monofase) {
								switch (tipoElaborazione) {
									case TipoElaborazioneIncassi.totali:
										if (idinc_Taxable != null) { 
											sumIncassiContrattiAttivi += amountBase;
											continue; //
										}
										break;
									case TipoElaborazioneIncassi.imponibile:
										if (idinc_Taxable != null) {
											sumIncassiContrattiAttivi += amountBase;
										continue;
										}
										break;
									case TipoElaborazioneIncassi.iva:
										if (idinc_Iva != null) {
											sumIncassiContrattiAttivi += amountBase;
										continue;
										}
										break;
								}

							}

							var collegabileafattura = getCollegabileAFattura(rEstimDet.idestimkind);
							// Non dobbiamo incassare dettagli contratti attivi di tipo collegabile a fattura
							// perchè in tal caso dobbiamo incassare la fattura
							if (collegabileafattura) {
								continue;
							}

							var gestionedifferita = getGestioneDifferita(rEstimDet.idestimkind, out errori);
							var filterEstimate = q.mCmp(rEstimDet, "idestimkind", "yestim", "nestim");

							if (gestionedifferita == "S" || faseentratamax == 1) {
								//var estimateRows = DS.estimate.get(_conn, filterEstimate);	//INACCETTABILE, deve leggerli prima
								//foreach (var estimateRow in estimateRows) {
								//	addEstimateDateToDict(estimateRow);
								//}

								// Dobbiamo generare dalla prima fase di entrata
								var resFin =
									creaAccertamentiDaDettagliContrattiAttivi(new estimatedetailRow[] {rEstimDet},
										tipoElaborazione, true);
								if (!resFin) {
									messages.Add(new messaggio() {
										error = true,
										msg =
											$"Errore nell'elaborazione della generazione dell'accertamento per il bollettino di codice {rFileDet.iduniqueformcode} o iuv {iuv}"
									});
									show(this,
										$"Errore nell'elaborazione della generazione dell'accertamento per il bollettino di codice {rFileDet.iduniqueformcode} o iuv {iuv}");
									closePBar();
									return false;
								}
								// Dato che entra in questo if anche quando gestionedifferita == "N" se monofase, allora verifico se devo aggiornare la data inizio
								// altrimenti mi duplica le scritture sul contratto attivo
								if (gestionedifferita == "S" ) rEstimDet["start"] = rFlussoIncassi["dataincasso"];
							}


							// Dettaglio contratto                        
							// Accertamento che contabilizza il dettaglio di importo pari a -importo
							var idincToAttach = tipoElaborazione == TipoElaborazioneIncassi.iva
								? rEstimDet["idinc_iva"]
								: rEstimDet["idinc_taxable"];
							if (idincToAttach == DBNull.Value) {
								messages.Add(new messaggio() {
										error = true,
										msg =
											$"Accertamento non trovato per il bollettino di codice {rFileDet.iduniqueformcode} o iuv {iuv}"
									}
								);
								//show(
								//    $"Accertamento non trovato per il bollettino di codice {rFileDet.iduniqueformcode} o iuv {iuv}",
								//    "Errore");
								continue;
							}

							//if (idincToAttach == DBNull.Value && gestionedifferita=="S") {
							//    faseInizioPerQuestoContratto = 1;
							//}
							int idincInt = CfgFn.GetNoNullInt32(idincToAttach);

							var fltmovI = q.eq("idinc", idincToAttach); //QHS.CmpEq("idinc", idincTaxable);
							incomeRow parentR = null;
							incomeyearRow parentYearR = null;
							if (info.incomeByIdInc.ContainsKey(idincInt)) {		
								parentR = info.incomeByIdInc[idincInt];
								if (!info.incomeYearByIdInc.ContainsKey(idincInt)) {
									messages.Add(new messaggio() {
											error = true,
											msg =
												$"Nell'anno corrente non esiste l'imputazione del movimento {parentR["ymov"]}/{parentR["nmov"]} collegato al  bollettino di codice {rFileDet.iduniqueformcode} o iuv {iuv}"
										}
									);
									continue;
								}
								parentYearR = info.incomeYearByIdInc[idincInt];
							}
							else {
								if (CfgFn.GetNoNullInt32(idincToAttach) < 900000000) {
									object available = DBNull.Value;
									if (info.availableByIdInc.ContainsKey(CfgFn.GetNoNullInt32(idincToAttach))) {
										available = info.availableByIdInc[CfgFn.GetNoNullInt32(idincToAttach)];
									}
									else {
										available = _conn.readValue("incometotal", fltmovI & q.eq("ayear", esercizio),
											"available");
										info.availableByIdInc[CfgFn.GetNoNullInt32(idincToAttach)] = CfgFn.GetNoNullDecimal(available);
									}
									if (available != DBNull.Value && available != null) {
										if (CfgFn.GetNoNullDecimal(available) < amountBase) {
											//messages.Add(new messaggio() {
											//		error = false,
											//		msg =
											//			$"Il bollettino {codiceBollettino} risulta collegato ad un accertamento già incassato. Disponibile: {available} incasso: {amountBase}"
											//	}
											//);

											//show($"Il bollettino {codiceBollettino} risulta collegato ad un accertamento già incassato. Disponibile: {available} incasso: {amountBase}", "Avviso");
											continue;
										}
									}

								}

								// Cerco la riga di accertamento
								var movs = DS.income.get(_conn, fltmovI); //DS.income.mergeFromDb(_conn, fltmovI));
								//DataAccess.RUN_SELECT_INTO_TABLE(_conn, DS.income, null, fltmovI, null, true);
								var movYears =
									DS.incomeyear.get(_conn, fltmovI & q.eq("ayear", esercizio)); //mergeFromDb(_conn, fltmovI & q.eq("ayear", esercizio)); 
								//DataAccess.RUN_SELECT_INTO_TABLE(_conn, DS.incomeyear, null,QHS.AppAnd(fltmovI, QHS.CmpEq("ayear", _security.GetEsercizio())), null, true);

								//DS.income.Filter(fltmovI);
								//DS.incomeyear.Filter(fltmovI);
								if (movs.Length == 0) continue;
								if (movYears.Length == 0) continue;
								parentR = movs[0];
								info.incomeByIdInc[idincInt] = parentR;
								parentYearR = movYears[0];
								info.incomeYearByIdInc[idincInt] = parentYearR;
							}

							//per un monofase non entra mai qui dentro, genera le fasi dalla successiva all'accertamento all'ultima
							for (var faseCorrente = faseinizio; faseCorrente <= fasefine; faseCorrente++) {
								mov.Columns["nphase"].DefaultValue = faseCorrente;
								//spostato sotto
								//var amount = CfgFn.GetNoNullDecimal(parentYearR.amount);

								// Selezione UPB e Voce di Bilancio in modo completamente automatico
								object idUpbSelected;
								object idmanagerSelected;

								// Determinazione del capitolo di bilancio in base alla causale finanziaria impostata sul dettaglio
								object idfinSelected = DBNull.Value;
								if (fasebilancio < faseinizio) {
									idUpbSelected = parentYearR.idupb;
									idfinSelected = parentYearR.idfin;
									idmanagerSelected = (object) parentR.idman ?? DBNull.Value;
								}
								else {
									idUpbSelected = (tipoElaborazione == TipoElaborazioneIncassi.iva)
										? rEstimDet.idupb_iva
										: rEstimDet.idupb;
									idmanagerSelected =
										getUpbManager(idUpbSelected,
											out errore); //_conn.readValue("upb", q.eq("idupb", idUpbSelected), "idman");

									var idfinCurr = getBilancioFromCausaleFin(rEstimDet.idfinmotive, out errore);
									string erroreiva;
									var idfinCurr_iva = getBilancioFromCausaleFin(rEstimDet.idfinmotive_iva, out erroreiva);
									idfinSelected = idfinCurr;
									if (rEstimDet.idfinmotive_iva != null && tipoElaborazione == TipoElaborazioneIncassi.iva && idfinCurr_iva != null) {
										idfinSelected = idfinCurr_iva;
									}


									if (errore != "") {
										messages.Add(new messaggio() {
												error = true,
												msg = errore
											}
										);
										show(errore, "Errore");
										return false;
									}
								}

								var newEntrataRow = inc.Get_New_Row(parentR, mov) as incomeRow;

								fillMovimento(newEntrataRow, idmanagerSelected, (object) parentR.idreg ?? DBNull.Value,
									parentR.description);

								newEntrataRow.doc =
									$"C.A.{rEstimDet.idestimkind}/{rEstimDet.yestim.ToString().Substring(2, 2)}/{rEstimDet.nestim.ToString().PadLeft(6, '0')}";

								newEntrataRow.docdate = rFlussoIncassi.dataincasso;

								newEntrataRow.nphase = Convert.ToByte(faseCorrente);

								var newImpMov = impMov.NewRow() as incomeyearRow;

								fillImputazioneMovimento(newImpMov, amountBase, idfinSelected, idUpbSelected);

								newImpMov.idinc = newEntrataRow.idinc;
								newImpMov.ayear = Convert.ToInt16(esercizio);

								impMov.Rows.Add(newImpMov);

								object idsor_siopeivavendita = null;
								DataTable Tconfig = Meta.Conn.RUN_SELECT("config", "*", null, qhs.CmpEq("ayear", Meta.GetSys("esercizio")), null, true);
								if (Tconfig.Rows.Count > 0) {
									idsor_siopeivavendita = Tconfig.Rows[0]["idsor_siopeivavendita"];
								}

								if (faseCorrente == _nphaseSiopeE && newcomputesorting == "S") {
									object idsor = null;
									if ((tipoElaborazione == TipoElaborazioneIncassi.iva) && (idsor_siopeivavendita != null)) {
										//Legge il siope da config
										idsor = idsor_siopeivavendita;
									}
									// Classificazione SIOPE impostata su documento
									if (idsor == DBNull.Value || idsor == null) {
										idsor = rEstimDet["idsor_siope"];
									}
									//Altrumenti leggo class SIOPE impostata sulla causale di ricavo
									if (idsor == DBNull.Value || idsor == null)
										idsor = getSiopeForAccMotive(rEstimDet["idaccmotive"], out errori);
									fillIncomeSorted(newEntrataRow, idsor, amountBase);
								}

								parentR = newEntrataRow;
							} // Fasi

				
							//Aggiunge le informazioni di ultima fase
							var newLastMov = incL.Get_New_Row(parentR, impLast) as incomelastRow;
							// aggiunge le informazioni sul numero bolletta se sono state specificate nel flusso 
							if (nbill != DBNull.Value) {
								newLastMov.nbill = (int) nbill;
								var flag = CfgFn.GetNoNullInt32(newLastMov.flag);
								flag |= 1;
								newLastMov.flag = Convert.ToByte(flag);
							}

							newLastMov.idinc = parentR.idinc;

							if (tipoElaborazione != TipoElaborazioneIncassi.iva) {
								//Aggiunge la riga di incasso per i contratti attivi
								foreach (DataColumn c in DS.estimatedetail.PrimaryKey)
									DS.incomelastestimatedetail.Columns[c.ColumnName].DefaultValue =
										rEstimDet[c.ColumnName];
								var incassoDet = incLD.Get_New_Row(parentR, DS.incomelastestimatedetail);
								incassoDet["amount"] = amountBase;
							}

							object idacc = DBNull.Value;

							if (epMain.attivo) {
								//Deve farle prima queste letture
								var estimateRows = DS.estimate.get(_conn, filterEstimate);
								if (estimateRows.Length > 0) {
									var idaccmotive = estimateRows[0].idaccmotivecredit;
									idacc = epMain.GetCustomerAccountForRegistry(idaccmotive, parentR.idreg);
									if (idacc != DBNull.Value) {
										newLastMov.idacccredit = (string) idacc;
									}
								}

							}

							sumIncassiContrattiAttivi += amountBase;
						} //dettagli contratto attivo
					} //Dettaglio crediti

				} //dettaglio incassi

				//test effettuato alla conclusione delle tre chiamate
				//if (rFlussoIncassi.importo == sumAmountContrattiAttivi) {
				//    rFlussoIncassi.elaborato = "S";
				//}
				info.flussoIncassiAmounts[(int) rFlussoIncassi.idflusso].sommaIncassi += sumIncassiContrattiAttivi;
			} //flusso incassi
			closePBar();
			return true;
		}

		string invoiceDescription(DataRow r) {
			return "Fattura " +
			       r["idinvkind"] + "/" +
			       r["yinv"].ToString().Substring(2, 2) + "/" +
			       r["ninv"].ToString().PadLeft(6, '0');
		}

		private bool creaIncassiFatture(bool soloConSospesi) {
			initPBar("Inizializzazione creazione incassi per fatture",2);
			azzeraTutto();

			var filterNonElaborati = q.eq("ayear", esercizio) & q.eq("elaborato", "N");
			if (soloConSospesi) filterNonElaborati &= q.isNotNull("nbill");
			if ((txtDaNumFlussoIncassi.Text != "") && (txtANumFlussoIncassi.Text != "")) {
				int daNFlussoDato;
				int aNFlussoDato;
				if (int.TryParse(txtDaNumFlussoIncassi.Text, out daNFlussoDato) &&
					int.TryParse(txtANumFlussoIncassi.Text, out aNFlussoDato)) {
					filterNonElaborati &= q.between("idflusso", daNFlussoDato, aNFlussoDato);
				}
			}

			if ((txtDaNumFlussoIncassi.Text != "") && (txtANumFlussoIncassi.Text == "")) {
				int nFlussoDato;
				if (int.TryParse(txtDaNumFlussoIncassi.Text, out nFlussoDato)) {
					filterNonElaborati &= q.eq("idflusso", nFlussoDato);
				}
			}

			DS.flussoincassi.mergeFromDb(_conn, filterNonElaborati);
			DS.flussoincassidetail.readTableJoined(_conn, "flussoincassi", null, filterNonElaborati, "idflusso");

			var info = new infoCreaIncassi();
			foreach (var r in DS.flussoincassidetail) {
				info.addDettFlussoIncassi(r);
			}

			var condUpb = _security.SelectCondition("upb", true).toMetaExpression();
			var joinUpbSql = "";
			var condUpbSql = "";
			if (condUpb != null) {
				joinUpbSql = " join upb on flussocreditidetail.idupb = upb.idupb ";
				condUpbSql = " AND " + condUpb.toSql(_qhs);
			}

			string colonneDettFature = string.Join(",",
				(from c in DS.invoicedetail.Columns._names()
					where QueryCreator.IsReal(DS.invoicedetail.Columns[c])
					select "invoicedetail." + c).ToArray());

			// 15259 Impossibile associare l'identificatore in più parti "flussocrediti.idupb".
			string sqlGetFatture =
				$" SELECT  {colonneDettFature} from invoicedetail where iduniqueformcode in (" +
				$"SELECT flussocreditidetail.iduniqueformcode from flussocreditidetail " +
				joinUpbSql +
				" WHERE EXISTS(SELECT * from flussoincassidetail  " +
				" JOIN flussoincassi ON flussoincassi.idflusso=flussoincassidetail.idflusso " +
				" WHERE (flussoincassidetail.iuv = flussocreditidetail.iuv OR flussoincassidetail.iduniqueformcode = flussocreditidetail.iduniqueformcode) " +
				" AND " + filterNonElaborati.toSql(_qhs) +
				")" +
				" AND flussocreditidetail.idestimkind is null AND flussocreditidetail.idinvkind is not null " +
				" AND flussocreditidetail.stop is null and flussocreditidetail.annulment is null " +

				condUpbSql +
				$") AND (yinv <= {esercizio}) ";
			//La sicurezza l'abbiamo già filtrata sui crediti, non c'è bisogno di filtrarla anche sul dettaglio contratto
			DS.invoicedetail._sqlGetFromDb(_conn, sqlGetFatture);
			incPBar();
			foreach (var r in DS.invoicedetail) {
				info.addDettFattura(r);

				var filterInvoice = q.mCmp(r, "idinvkind", "yinv", "ninv");
				DS.invoice.get(_conn, filterInvoice);
			}
			closePBar();

			if (DS.invoicedetail.Rows.Count == 0) {
				show(
					"Non sono stati trovati dettagli fattura da incassare di questo anno o anni precedenti.", "Avviso");
				return true;
			}

			bool error;
			bool res = creaIncassiFatture(soloConSospesi, TipoElaborazioneIncassi.imponibile, info, out error);
			if (error) return false;
			if (res) res = creaIncassiFatture(soloConSospesi, TipoElaborazioneIncassi.iva, info, out error);
			if (error) return false;
			if (res) res = creaIncassiFatture(soloConSospesi, TipoElaborazioneIncassi.totali, info, out error);
			if (error) return false;

			foreach (var rFlusso in DS.flussoincassi.all()) {
				var infoFlusso = info.flussoIncassiAmounts[rFlusso.idflusso];
				if (infoFlusso.importoFlusso == infoFlusso.sommaIncassi) rFlusso.elaborato = "S";
			}

			VisualizzaFatture();
			if (DS.invoice.Rows.Count == 0) {
				show("Non sono state trovate fatture collegate ai crediti incassati.", "Avviso");
			}

			return res;
		}

		/// <summary>
		/// Elabora un flusso incassi 
		/// </summary>
		/// <returns></returns>
		private bool creaIncassiFatture(bool soloConSospesi, TipoElaborazioneIncassi tipoElaborazione,infoCreaIncassi info, out bool error) {
			error = false;
			var incInvoice = _dispatcher.Get("incomeinvoice");
			incInvoice.SetDefaults(DS.incomeinvoice);
			var fasebilancio = CfgFn.GetNoNullInt32(_security.GetSys("incomefinphase"));

			var metaIncome = MetaData.GetMetaData(this, "income");
			var metaIncomeYear = MetaData.GetMetaData(this, "incomeyear");
			var metaIncomeLast = MetaData.GetMetaData(this, "incomelast");

			metaIncome.SetDefaults(DS.income);
			metaIncomeYear.SetDefaults(DS.incomeyear);
			metaIncomeLast.SetDefaults(DS.incomelast);

			// Partendo da una riga di flussoincassi / flussoincassidetail
			// ciclo sui dettagli fattura filtrati solo sullo IUV e non contabilizzati
			// Mi leggo ilmovimento finanziario padre (l'accertamento che contabilizza eventuale dettaglio contratto attivo) 
			// 1) leggo il dettaglio contratto attivo associato alla fattura  vedendo prima se sta in memoria , 
			// perchè l'ho esaminato nella fase precedente e mi prendo l'accertamento che sta in memoria construendo le nuove fasi successive
			// 2) Se invece non trovo il dettaglio contratto attivo in memoria perchè privo di IUV, 
			// deve rileggere da db eventuale contabilizzazione e prendere quella come riga padre. 
			// Se invece il dettaglio contratto attivo non è contabilizzato, saltare la riga. 
			// Assumiamo che il dettaglio contratto attivo deve essere già stato contabilizzato,
			// 3) Se il dettaglio Fattura non è collegato ad alun dettaglio contratto attivo, generiamo tutte le fasi
			// finanziarie, dalla prima fino all'ultima

			//DS.incomeinvoice.Clear(); comune a tutte e tre le fasi - svuoto prima

			var bollettiniElaborati = new Dictionary<string, bool>();

			// ciclo flusso incassi
			initPBar("creaIncassiFatture - "+tipoElaborazione.ToString(),DS.flussoincassi.Rows.Count);
			foreach (var rFlussoIncassi in DS.flussoincassi) {
				incPBar();
				decimal sumAmount = 0;
				if (!info.flussoIncassiAmounts.ContainsKey((int) rFlussoIncassi.idflusso)) {
					info.flussoIncassiAmounts.Add((int) rFlussoIncassi.idflusso, new infoIncasso() {
						importoFlusso = CfgFn.GetNoNullDecimal(rFlussoIncassi.importo)
					});
				}

				var mov = DS.income;
				var impMov = DS.incomeyear;
				var impLast = DS.incomelast;
				var fasecontratto = CfgFn.GetNoNullInt32(_security.GetSys("estimatephase"));
				var fasemassima = CfgFn.GetNoNullInt32(_security.GetSys("maxincomephase"));

				var fasefine = fasemassima;

				MetaData.SetDefault(DS.incomeyear, "ayear", esercizio);

				var idflusso = rFlussoIncassi.idflusso;
				var nbill = rFlussoIncassi.nbillValue;

				// Verifica esistenza della bolletta su DB

				string errore;
				if (soloConSospesi || nbill != DBNull.Value) {
					nbill = getSospesiAttivi(nbill, out errore);
					if (nbill == DBNull.Value) {
						// Non è stato creato ancora sul db mediante l'importazione del giornale di cassa
						continue;
					}
				}

				// ciclo flusso incassidetail
				//legge i dettagli flusso incassi se non sono presenti
				if (!info.dettFlussoIncassiPerIdFlusso.ContainsKey(idflusso)) continue;

				foreach (var rFileDet in info.dettFlussoIncassiPerIdFlusso[idflusso]) {

					//Anche qui deve ciclare tra i crediti per ottenere un codiceBollettino

					// Leggo i dettagli fattura da incassare facendo una ricerca per codice bollettino univoco 
					var codiceBollettino = rFileDet.iduniqueformcode;
					if (string.IsNullOrEmpty(codiceBollettino)) continue;

					//var iuv = rFileDet.iuv;

					//Elabora una volta sola ogni codice bollettino, incassando TUTTI i crediti con pari  iduniqueformcode
					//Non fa niente se il ramo c.attivi ha già considerato questo bollettino, questo ramo lo elaborerà per la quota "fatture"
					// che è disgiunta da quella dei c.attivi
					var key = codiceBollettino;
					if (bollettiniElaborati.ContainsKey(key)) continue;
					//// bollettini non incassabili per mancata generazione scritture
					//if (bollettiniNonIncassabili.Contains(codiceBollettino)) {
					//    continue;
					//}
					bollettiniElaborati.Add(key, true);

					// Dettagli non contabilizzati con iduniqueformcode=  codiceBollettino
					if (!info.dettFatturaPerUniqueFormCode.ContainsKey(codiceBollettino)) continue;
					var rowsInvoicedetPerBollettino = info.dettFatturaPerUniqueFormCode[codiceBollettino];

					//Filtra le righe non contabilizzate della fattura
					q filterDetFattura = null;
					switch (tipoElaborazione) {
						case TipoElaborazioneIncassi.totali:
							filterDetFattura = q.isNull("idinc_iva") & q.isNull("idinc_taxable");
							break;
						case TipoElaborazioneIncassi.imponibile:
							filterDetFattura = q.isNull("idinc_taxable");
							break;
						case TipoElaborazioneIncassi.iva:
							filterDetFattura = q.isNull("idinc_iva");
							break;
					}

					var rowsInvoicedet = rowsInvoicedetPerBollettino._Filter(filterDetFattura).ToArray();

					// Si possono verificare i seguenti quattro casi:
					// 1) Dettaglio fattura collegato a dettaglio contratto attivo contabilizzato ma non ancora salvato (accertamento in memoria),
					//    sarà portato a incasso partendo dall'accertamento
					// 2) Dettaglio fattura collegato a dettaglio contratto attivo contabilizzato e con accertamento salvato su DB, 
					//    sarà portato a incasso partendo dall'accertamento
					// 3) Dettaglio fattura collegato a dettaglio contratto attivo non contabilizzato con questa procedura perchè privo di IUV, 
					//    sarà scartato e dovrà essere prima contabilizzato il dett. c.a. secondo una delle altre consuete modalità
					// 4) Dettaglio fattura non collegato a dettaglio, 
					//    saranno generate tutte le fasi finanziarie  

					// ciclo flusso invoicedetai
				
						foreach (var rInvoiceDet in rowsInvoicedet) {
							if (GestisceScritture()) {
								string idrelated = BudgetFunction.ComposeObjects(
									new[] {
										"inv",
										rInvoiceDet["idinvkind"],
										rInvoiceDet["yinv"],
										rInvoiceDet["ninv"]
									});
								if (_conn.count("entry", q.eq("idrelated", idrelated)) == 0) {
									continue;
								}
							}
					 
						decimal imponibile = CfgFn.GetNoNullDecimal(rInvoiceDet.taxable);
						decimal quantitaConfezioni = CfgFn.GetNoNullDecimal(rInvoiceDet.npackage);
						decimal sconto = CfgFn.GetNoNullDecimal(rInvoiceDet.discount);
						decimal imponibiletot =
							CfgFn.GetNoNullDecimal(CfgFn.RoundValuta((imponibile * quantitaConfezioni * (1 - sconto))));
						//double imponibiletotEUR = CfgFn.RoundValuta(imponibiletot*tassocambio);
						var iva = CfgFn.GetNoNullDecimal(rInvoiceDet.tax);
						decimal amountBase = 0;



						var filterInvoice = q.mCmp(rInvoiceDet, "idinvkind", "yinv", "ninv");

						var invoice = DS.invoice.get(_conn, filterInvoice);
						if (invoice.Length == 0) continue;
						var invoiceRow = invoice[0];

						bool splitPayment=false;
						if (invoiceRow.flag_enable_split_payment == "S") {
							if (tipoElaborazione != TipoElaborazioneIncassi.imponibile) continue;
							splitPayment = true; //in questo caso la contabilizzazione deve essere per forza "imponibile"
							iva = 0;
						}

						var idincTaxable = rInvoiceDet.idinc_taxable;
						var idinciva = rInvoiceDet.idinc_iva;

						if (idincTaxable != null && tipoElaborazione == TipoElaborazioneIncassi.imponibile)continue; // già contabilizzato
						if (idinciva != null && tipoElaborazione == TipoElaborazioneIncassi.iva)continue; // già contabilizzato
						if ((idincTaxable != null || idinciva != null) && tipoElaborazione == TipoElaborazioneIncassi.totali) continue; // già contabilizzato
					
						var currUpb = rInvoiceDet.idupb;
						var currUpbIva = rInvoiceDet.idupb_iva;

						//Se è valorizzata la Causale finanziaria IVA ma non è valorizzato l'UPB iva,
						// valorizzo l'upb iva al fine di generare un incasso separato per l'IVA [16307]
						if ((rInvoiceDet.idfinmotive_iva != null) && (currUpb != null) && (currUpbIva == null)) {
							currUpbIva = currUpb;
						}

						// Cerca la contabilizzazione del dettaglio contratto attivo collegato per agganciarsi ad essa                        
						estimatedetailRow estimDet = null;
						if (rInvoiceDet.idestimkind != null) {
							var estimateDetails = DS.estimatedetail.get(_conn,
								q.mCmp(rInvoiceDet, "idestimkind", "yestim", "nestim") &
								q.eq("rownum", rInvoiceDet.estimrownum)
							);
							estimDet = estimateDetails[0];
						}
						
 
						if (estimDet == null || faseentratamax == 1) {
							//Se non c'è un contratto collegato o siamo nel monofase controlliamo la coerenza degli upb impostati sul dettaglio fattura
							switch (tipoElaborazione) {
								case TipoElaborazioneIncassi.totali:
									//Elaborazione pre modifica split fasi - esegue solo con upb_iva == null
									if (currUpb == null || currUpbIva != null)
										continue; //i totali devono avere un upb_iva NON impostato per essere elaborati
									break;
								case TipoElaborazioneIncassi.imponibile:
										if (currUpb == null || (iva>0 && currUpbIva == null)){
										continue; // imponibile  o iva è ammesso solo se c'è currUPB
										}
									break;
								case TipoElaborazioneIncassi.iva:
										if (currUpb == null || (iva>0 && currUpbIva == null)){
		 								continue; // imponibile  o iva è ammesso solo se c'è currUPB

										}
									break;
							}
						}
						else {
							//conta la cont. del  dett.contratto non gli upb
							switch (tipoElaborazione) {
								case TipoElaborazioneIncassi.totali:
									//Elaborazione per modifica split fasi - esegue solo con upb_iva == null
									if (currUpb == null || currUpbIva != null) continue; //i totali devono avere un upb_iva NON impostato per essere elaborati
									if (estimDet.idinc_iva != estimDet.idinc_taxable) {
										show(
											$"{$" Nel dettaglio fattura{rInvoiceDet.detaildescription} codice bollettino "}{rInvoiceDet.iduniqueformcode} " +
											$" bisogna specificare l'upb dell'iva per coerenza con il contratto attivo collegato",
											"Errore"); // imponibile  o iva è ammesso solo se c'è currUPB
										continue;
									}
									break;
								case TipoElaborazioneIncassi.imponibile:
									if (currUpb == null || (iva>0 && currUpbIva == null)) {
										continue; // imponibile  o iva è ammesso solo se c'è currUPB e anche upbIva o causale finanziaria iva
									}
									if (estimDet.idinc_taxable != null && estimDet.idinc_taxable==estimDet.idinc_iva) {
										show(
											$" Nel dettaglio fattura{rInvoiceDet.detaildescription} codice bollettino {rInvoiceDet.iduniqueformcode} " +
											$" la causale di contabilizzazione del Contratto Attivo, " +
											$" non è coerente con la valorizzazione della Causale Finanziaria IVA. " +
											$" Si deve cancellare la Causale finanziaria IVA dal dettaglio Fattura.",
											"Errore"); // imponibile  o iva è ammesso solo se c'è currUPB e anche upbIva o causale finanziaria iva
										continue;
									}
									
									if (estimDet.idinc_taxable == null) {
										show(
											$"L'imponibile del dettaglio contratto attivo collegato al dettaglio " + 
											$"fattura{rInvoiceDet.detaildescription} codice bollettino {rInvoiceDet.iduniqueformcode} " +
											$" va contabilizzato prima di elaborare l'incasso della fattura collegata",
											"Errore"); // imponibile  o iva è ammesso solo se c'è currUPB
										continue;
									}

									break;
								case TipoElaborazioneIncassi.iva:
									if (iva == 0) continue;
									if (currUpb == null || currUpbIva == null){
										continue; // imponibile  o iva è ammesso solo se c'è currUPB e anche upbIva
									}
									
									if (estimDet.idinc_iva == null) {
										show(
											$"L'iva del dettaglio contratto attivo collegato al dettaglio " + 
											$"fattura{rInvoiceDet.detaildescription} codice bollettino {rInvoiceDet.iduniqueformcode} " +
											$" va contabilizzata prima di elaborare l'incasso della fattura collegata",
											"Errore"); // imponibile  o iva è ammesso solo se c'è currUPB
										error = true;
										return false;
									}
									break;
							}
						}

						

						switch (tipoElaborazione) {
							case TipoElaborazioneIncassi.totali:
								amountBase = imponibiletot + iva;
								//Elaborazione pre modifica split fasi - esegue solo con upb_iva == null
								break;
							case TipoElaborazioneIncassi.imponibile:
								amountBase = imponibiletot;
								break;
							case TipoElaborazioneIncassi.iva:
								amountBase = iva;
								break;
						}

						if (amountBase == 0) continue;

						
						// Cerco eventuale accertamento che contabilizza il dettaglio contratto attivo associato

						incomeRow parentR = null;
						incomeyearRow parentYearR = null;

						int faseinizio;
						if (rInvoiceDet.idestimkind == null || faseentratamax == 1) {
							//Se il contratto attivo manca o è monofase, genera tutte le fasi
							faseinizio = 1;
						}
						else {
							if (estimDet == null) continue; // C'è un errore

							//Nel caso di monofase potrebbe essere idestimkind not null ma il contratto potrebbe non essere contabilizzato                           
							var idincCa = estimDet.idinc_taxable;
							if (tipoElaborazione == TipoElaborazioneIncassi.iva) {
								idincCa = estimDet.idinc_iva;
							}

							// Se idinc_taxable è nullo, il dettaglio del contratto attivo deve essere contabilizzato per altra via, 
							// si tratta di un dettaglio senza IUV e la presente procedura non lo elabora
							if (idincCa == null) continue;

							// Prima cerca l'accertamento in memoria perchè potrebbe non essere stato ancora salvato
							var movs = DS.income.Filter(q.eq("idinc", idincCa));
							var movYears = DS.incomeyear.Filter(q.eq("idinc", idincCa));

							// Se non lo trova in memoria legge l'accertamento precedentemente salvato su DB 
							if (movs.Length == 0) {
								movs = DS.income.getFromDb(_conn, q.eq("idinc", idincCa));
								movYears = DS.incomeyear.getFromDb(_conn,
									q.eq("idinc", idincCa) & q.eq("ayear", esercizio));
							}

							if (movs.Length == 0) continue; // Non trova la contabilizzazione, si tratta di un errore
							faseinizio = fasecontratto + 1; // deve generare le fasi finanziarie successive

							parentR = movs[0];
							parentYearR = movYears[0];
						}


						//string filterInvoice = QHS.AppAnd(QHS.CmpEq("idinvkind", rInvoiceDet["idinvkind"]),
						//            QHS.CmpEq("yinv", rInvoiceDet["yinv"]), QHS.CmpEq("ninv", rInvoiceDet["ninv"]));
					

						object idacc = DBNull.Value;

						var idaccmotive = invoiceRow.idaccmotivedebit_crg ?? invoiceRow.idaccmotivedebit;

						// Anagrafica dalla Fattura
						var idreg = invoiceRow.idreg;
						// Incasso che contabilizza il dettaglio di importo pari a -importo
				

						MetaData.SetDefault(DS.incomeyear, "ayear", esercizio);
						//DataRow IncomeToLink = null; 

						// ciclo fasi
						for (var faseCorrente = faseinizio; faseCorrente <= fasefine; faseCorrente++) {
							mov.Columns["nphase"].DefaultValue = faseCorrente;

							//var amount = //imponibiletot + iva;
							//    CfgFn.GetNoNullDecimal(parentYearR == null ? imponibiletot+iva : parentYearR.amount); //moltiplicata per la quantità rInvoiceDet.number al fine di ottenere l'imponibile
							decimal
								amount =
									amountBase; //CfgFn.GetNoNullDecimal(parentYearR == null ? amountBase: parentYearR.amount); //moltiplicata per la quantità rInvoiceDet.number al fine di ottenere l'imponibile
							if (amount == 0) break;

							var newEntrataRow = metaIncome.Get_New_Row(parentR, mov) as incomeRow;

							var description = parentR?["description"].ToString() ?? invoiceDescription(rInvoiceDet);

						

							// Selezione UPB e Voce di Bilancio in modo completamente automatico
							var idUpbSelected = rInvoiceDet.idupb;
							if (rInvoiceDet.idupb_iva != null && tipoElaborazione == TipoElaborazioneIncassi.iva) {
								idUpbSelected = rInvoiceDet.idupb_iva;
							}

							var idmanagerSelected =
								getUpbManager(idUpbSelected,
									out errore); // _conn.readValue("upb", q.eq("idupb", idUpbSelected), "idman");
							//_conn.DO_READ_VALUE("upb", QHS.CmpEq("idupb", idUpbSelected),"idman");

							// Determinazione del capitolo di bilancio in base alla causale finanziaria impostata sul dettaglio
							/// questo in analogia a quanto fa sul contratto attivo deve essere fatto solo se fase inizio è uguale a fase bilancio 
							var idfinCurr = getBilancioFromCausaleFin(rInvoiceDet.idfinmotiveValue, out errore);
							string erroreiva;
							var idfinCurr_iva = getBilancioFromCausaleFin(rInvoiceDet.idfinmotive_ivaValue, out erroreiva);
							var idfinSelected = idfinCurr;
							if (rInvoiceDet.idfinmotive_iva != null && tipoElaborazione == TipoElaborazioneIncassi.iva && idfinCurr_iva!=null) {
								idfinSelected = idfinCurr_iva;
							}


							// Ma se sta generando sulla base di accertamenti già creati non va bene, se no ottiene imputazioni
							// incoerenti nella gerarchia dei movimenti di entrata
							if (fasebilancio < faseinizio) {
								idUpbSelected = parentYearR.idupb;
								idfinSelected = parentYearR.idfin;
								idmanagerSelected = (object)parentR.idman ?? DBNull.Value;
							}





							if (errore != "") {
								show(
									errore + " nel dettaglio " + rInvoiceDet.detaildescription + " codice bollettino " +
									rInvoiceDet.iduniqueformcode,
									"Errore");
								return false;
							}

							fillMovimento(newEntrataRow, idmanagerSelected, idreg, description);

							newEntrataRow.doc = invoiceRow.doc; //invoiceDescription(rInvoiceDet);
							newEntrataRow.docdate = invoiceRow.docdate; //rFlussoIncassi.dataincasso;
							newEntrataRow.nphaseValue = faseCorrente;

							var newImpMov = impMov.NewRow();
							fillImputazioneMovimento(newImpMov, amount, idfinSelected, idUpbSelected);

							newImpMov["idinc"] = newEntrataRow["idinc"];
							newImpMov["ayear"] = esercizio;

							impMov.Rows.Add(newImpMov);

							object idsor_siopeivavendita = null;
							DataTable Tconfig = Meta.Conn.RUN_SELECT("config", "*", null, qhs.CmpEq("ayear", Meta.GetSys("esercizio")), null, true);
							if (Tconfig.Rows.Count > 0) {
								idsor_siopeivavendita = Tconfig.Rows[0]["idsor_siopeivavendita"];
							}

							if (faseCorrente == _nphaseSiopeE && newcomputesorting == "S") {
								string errori;
								object idsor = null;
								if ((tipoElaborazione == TipoElaborazioneIncassi.iva) &&(idsor_siopeivavendita!=null)){
									//Legge il siope da config
									idsor = idsor_siopeivavendita;
								}
								// Classificazione SIOPE impostata su documento
								if (idsor == DBNull.Value || idsor == null) {
									idsor = rInvoiceDet.idsor_siope;
								}
								//Altrumenti leggo class SIOPE impostata sulla causale di ricavo
								if ((idsor == DBNull.Value || idsor == null) && SiopeE_obbligatorio()){
									idsor = getSiopeForAccMotive(rInvoiceDet.idaccmotive, out errori);
								}
								fillIncomeSorted(newEntrataRow, idsor, amount);
							}

							if (faseCorrente == fasemassima) {
								var newLastMov = metaIncomeLast.Get_New_Row(newEntrataRow, impLast) as incomelastRow;
								// aggiunge le informazioni sul numero bolletta se sono state specificate nel flusso e

								if (nbill != DBNull.Value) {
									newLastMov.nbill = (int) nbill;
									var flag = CfgFn.GetNoNullInt32(newLastMov["flag"]);
									flag |= 1;
									newLastMov["flag"] = flag;
								}

								newLastMov["idinc"] = newEntrataRow["idinc"];

								if (epMain.attivo) {
									idacc = epMain.GetCustomerAccountForRegistry(idaccmotive, newEntrataRow["idreg"]);
								}

								if (idacc != DBNull.Value) {
									newLastMov["idacccredit"] = idacc;
								}

								//Aggiunge la riga in IncomeInvoice e lo contabilizza
								//const int currcausale = 1; // contabilizzazione totale

								int currcausale = 1;
								switch (tipoElaborazione) {
									case TipoElaborazioneIncassi.totali:
										currcausale = 1;
										break;
									case TipoElaborazioneIncassi.imponibile:
										currcausale = 3;
										break;
									case TipoElaborazioneIncassi.iva:
										currcausale = 2;
										break;
								}

								var incInvoiceRow = incInvoice.Get_New_Row(newEntrataRow, DS.incomeinvoice);
								incInvoiceRow["movkind"] = currcausale;
								incInvoiceRow["idinvkind"] = rInvoiceDet.idinvkind;
								incInvoiceRow["yinv"] = rInvoiceDet.yinv;
								incInvoiceRow["ninv"] = rInvoiceDet.ninv;

								//Effettua i collegamenti con il dettaglio della fattura
								if (tipoElaborazione == TipoElaborazioneIncassi.imponibile) {
									rInvoiceDet.idinc_taxable = newEntrataRow.idinc;
								}

								if (tipoElaborazione == TipoElaborazioneIncassi.iva) {
									rInvoiceDet.idinc_iva = newEntrataRow.idinc;
								}

								if (tipoElaborazione == TipoElaborazioneIncassi.totali) {
									rInvoiceDet.idinc_iva = newEntrataRow.idinc;
									rInvoiceDet.idinc_taxable = newEntrataRow.idinc;
								}


								sumAmount += amount; // incrementa l'importo incassato
							}

							parentR = newEntrataRow;
						}

						// fine ciclo fasi
					}

					// fine ciclo flusso invoicedetai

					//va fatto al termine delle fasi imponibile,iva e totali
					//if (rFlussoIncassi.importo == sumAmount) {
					//      rFlussoIncassi.elaborato = "S";
					//}
				}

				// fine ciclo flusso incassidetail

				info.flussoIncassiAmounts[(int) rFlussoIncassi.idflusso].sommaIncassi += sumAmount;
			}
			closePBar();
			//fine ciclo flusso incassi

			return true;
		}


		private static DataRow getGridCurrentRow(DataGrid g) {
			var dsv = (DataSet) g.DataSource;
			var tv = dsv?.Tables[g.DataMember];
			if (tv == null) return null;

			if (tv.Rows.Count == 0) return null;
			DataRowView dv;
			try {
				dv = (DataRowView) g.BindingContext[dsv, tv.TableName].Current;
			}
			catch {
				dv = null;
			}

			return dv?.Row;
		}


		/// <summary>
		/// Importa flussi incassi da foglio Excel (tracciato concordato con Roma Tor Vergata)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnIncassi_Click(object sender, EventArgs e) {
			btnElaboraContabilizzazioni.Enabled = false;
			//btnelaboraFlussoCrediti.Enabled = false;
			//btnElaboraIncassi.Enabled = false;
			var t = leggiFile(false);
			if (t == null) {
				return;
			}

			importaTabellaFlussoIncassi(t);

		}

		private bool ResiduiAttiviTrasferiti() {
			int PrevYear = esercizio - 1;
			string filtroPrev = qhs.CmpEq("ayear", PrevYear);

			DataTable EsercizioPrev = conn.RUN_SELECT("accountingyear", "*", null, filtroPrev, null, false);
			if (EsercizioPrev.Rows.Count == 0) return true;// vuol dire che non c'è un esercizio precedente. Siamo in un db nuovo
			DataRow Prev = EsercizioPrev.Rows[0];
			bool ra_trasferiti = ((CfgFn.GetNoNullInt32(Prev["flag"]) & 0x0F) >= 4);
			return ra_trasferiti;
		}
		private void elaboraFlussoCrediti(object _from, object _to) {
			//riempie estimate, estimate
			QueryCreator.MarkEvent("Inizio elaboraFlussoCrediti");
			var res = fillEstimate(_from, _to); //non salva i dati
			if (!res) {
				show(this, @"Errore nella creazione dei contratti attivi");
				return;
			}
			if (ResiduiAttiviTrasferiti()) {
				var resA = fillAnnulment(_from, _to);
				if (!resA) {
					show(this, @"Errore nell'elaborazione degli annullamenti");
					return;
				}
			}else {
				show("Per elaborare gli annullamenti è necessario aver trasferito i Residui Attivi.");
			}

			if (!DS.HasChanges()) {
				show("Nessun credito da elaborare");
				return;
			}

			var myPostData = new Easy_PostData();
			myPostData.initClass(DS, _conn);
			var resSave = myPostData.DO_POST();

			if (!resSave) {
				show(this, "Errore nel salvataggio");
				return;
			}

			if (generaScrittureContrattiAttivi()) {
				show(this, "Elaborazione crediti completata");
			}
		}

		DataRow GetGridRow(DataGrid G, int index) {
			/*
			 * LISTING TYPE DEFAULT
			 *   DescribeAColumn(T, "idestimkind", ".idestimkind", nPos++);
			    DescribeAColumn(T, "yestim", ".yestim", nPos++);
			    DescribeAColumn(T, "nestim", ".nestim", nPos++);
			    DescribeAColumn(T, "rownum", ".rownum", nPos++);
			    D
			 * */
			string TableName = G.DataMember.ToString();
			var MyDS = (DataSet) G.DataSource;
			var MyTable = MyDS.Tables[TableName];
			string h = $"{G[index, 0]}§{G[index, 1]}§{G[index, 2]}§{G[index, 3]}";
			DataRow r;
			if (dictEstimDetail.TryGetValue(h, out r)) return r;
			
			//In posizione 1 c'è il tipo contratto

			var filter = _qhc.AppAnd(_qhc.CmpEq("idestimkind", G[index, 0]),
				_qhc.CmpEq("yestim", G[index, 2]),
				_qhc.CmpEq("nestim", G[index, 3]),
				_qhc.CmpEq("rownum", G[index, 4]));
			DataRow[] selectresult = MyTable.Select(filter);
			return (selectresult.Length > 0) ? selectresult[0] : null;
		}

		string hashEstimDet(DataRow r) {
			return $"{r["idestimkind"]}§{r["yestim"]}§{r["nestim"]}§{r["rownum"]}";
		}

		void evaluateHasEstimDet() {
			dictEstimDetail.Clear();
			foreach (DataRow r in DS.estimatedetail) dictEstimDetail[hashEstimDet(r)] = r;
		}

		Dictionary<string, DataRow> dictEstimDetail = new Dictionary<string, DataRow>();

		private DataRow[] GetGridSelectedRows(DataGrid G) {
			evaluateHasEstimDet();
			if (G.DataMember == null) return null;
			if (G.DataSource == null) return null;
			string TableName = G.DataMember.ToString();
			DataSet MyDS = (DataSet) G.DataSource;
			DataTable MyTable = MyDS.Tables[TableName];
			int numrighetemp = MyTable.Rows.Count;
			int numrighe = 0;
			int i;
			var result = new List<DataRow>();
			for (i = 0; i < numrighetemp; i++) {
				if (G.IsSelected(i)) {
					DataRow R = GetGridRow(G, i);
					result.Add(R);
				}
			}

			return result.ToArray();
		}

		private void datagrid_DoubleClick(object sender, EventArgs e) {
			// permette la selezione di una riga per visualizzarla richiamando edit type specifico per ciascun grid
			//
			//dgrCrediti
			//dgrIncassi
			//dgrDettContrattiAttivi
			//dgrFattureCreate
			DataGrid dataGrid = (DataGrid) sender;
			DataRow RigaSelezionata = getGridCurrentRow(dataGrid);
			string tableName = "";
			string viewName = "";
			string listType = "";
			string editType = "";
			if (dataGrid.Name == "dgrCrediti") {
				tableName = "flussocreditidetail";
				// listing type e d edit type da valorizzare, per ora metto default
				listType = "default";
				editType = "default";
			}

			if (dataGrid.Name == "dgrIncassi") {
				tableName = "flussoincassidetail";
				listType = "default";
				editType = "default";
			}

			if (dataGrid.Name == "dgrDettContrattiAttivi") {
				tableName = "estimatedetail";
				listType = "default";
				editType = "default";
			}

			if (dataGrid.Name == "dgrContratti") {
				tableName = "estimate";
				listType = null;
				editType = null;
			}

			if (dataGrid.Name == "dgrFattureCreate") {
				tableName = "invoice";
				listType = "default";
				editType = "default";
			}

			
			if (dataGrid.Name == "dgrCreditiAnnullati") {
				tableName = "flussocreditidetail";
				listType = "default_annullati";
				editType = "default";
			}

			if (RigaSelezionata == null)
				return;
			visualizzaRigaSelezionata(RigaSelezionata, tableName, viewName, listType, editType);
		}






		/// <summary>
		/// Elabora contratto da flusso studenti
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnElaboraFlussoCrediti_Click(object sender, EventArgs e) {
			QueryCreator.MarkEvent("Inizio btnElaboraFlussoCrediti_Click");
			btnelaboraFlussoCrediti.Visible = false;
			Application.DoEvents();
			object startFlusso = DBNull.Value;
			object stopFlusso = DBNull.Value;
			if (txtStartFlusso.Text != "") {
				object i = HelpForm.GetObjectFromString(typeof(int), txtStartFlusso.Text, "x.y.g");
				if (i == null) {
					show("Numero non valido in n.flusso iniziale", "Errore");
					return;
				}

				startFlusso = i;
			}

			if (txtStopFlusso.Text != "") {
				object i = HelpForm.GetObjectFromString(typeof(int), txtStopFlusso.Text, "x.y.g");
				if (i == null) {
					show("Numero non valido in n.flusso finale", "Errore");
					return;
				}

				stopFlusso = i;
			}

			if (startFlusso == DBNull.Value && stopFlusso != DBNull.Value)
            {
				btnelaboraFlussoCrediti.Visible = true;
				show("Il campo 'da n. flusso' non può essere vuoto", "Errore");				
				return;
            }
			else if (startFlusso != DBNull.Value && stopFlusso == DBNull.Value)
            {
				btnelaboraFlussoCrediti.Visible = true;
				show("Il campo 'a n. flusso' non può essere vuoto", "Errore");
				return;
			}

			elaboraFlussoCrediti(startFlusso, stopFlusso);
			azzeraTutto();
			if (faseentratamax != 1)
				btnCercaContrattiDaContabilizzare_Click(sender, e);
			btnelaboraFlussoCrediti.Visible = true;
		}

		void azzeraTutto() {
			DS.income.Clear();
			DS.incomelast.Clear();
			DS.income.Clear();
			DS.incomeyear.Clear();
			DS.incomesorted.Clear();
			DS.flussoincassi.Clear();
			DS.flussoincassidetail.Clear();

			DS.invoice.Clear();
			DS.invoicedetail.Clear();

			DS.estimate.Clear();
			DS.estimatedetail.Clear();
			DS.incomelastestimatedetail.Clear();
			DS.ivaregister.Clear();

			DS.incomeinvoice.Clear();
			DS.incomeestimate.Clear();

			DS.flussocrediti.Clear();
			DS.flussocreditidetail.Clear();

		}

		/// <summary>
		/// Crea accertamenti contratti attivi
		/// Questa funzione non dovrebbe essere attiva nel caso di db monofase, che in quel caso saranno creati in fase di incasso
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnElaboraContabilizzazioni_Click(object sender, EventArgs e) {
			btnElaboraContabilizzazioni.Enabled = false;
			//necessita di DS.estimatedetail non vuoto
			DS.income.Clear();
			DS.incomelast.Clear();
			DS.income.Clear();
			DS.incomeyear.Clear();
			DS.incomesorted.Clear();
			DS.flussoincassi.Clear();
			DS.flussoincassidetail.Clear();
			DS.incomelastestimatedetail.Clear();
			DataRow[] SelectedRows = GetGridSelectedRows(dgrDettContrattiAttivi);
			var resFin = true;

			foreach (var estimateRow in DS.estimate) {
				addEstimateDateToDict(estimateRow);
			}

			for (int i = 0; i < SelectedRows.Length; i++) {
				resFin = creaAccertamentiDettagliContratti(
					new estimatedetailRow[] {(estimatedetailRow) SelectedRows[i]});
				if (!resFin) break;
			}

			DataSet dSupdated;
			if (resFin) resFin = doSave(out dSupdated);

			azzeraTutto();

			if (resFin) btnCercaContrattiDaContabilizzare_Click(sender, e);
			//la doSave mostra già messaggi più specifici nel caso in cui fallisca. 
			// Questo messaggio può essere fuorviante perchè potrebbe non esserci nessun movimento e quindi NON essere un errore
			//if (!resFin) {
			//    show(this, @"Errore nell'elaborazione della generazione dei movimenti finanziari");
			//}
		}

		/// <summary>
		/// Elabora flusso incassi, ossia crea gli incassi per tutte le righe di flussoincassi non ancora elaborate e che però abbiano
		///  il numero di sospeso attivo impostato ed il cui sospeso esista nel programma. Inoltre nulla è creato per quanto riguarda
		///  i contratti attivi collegabili a fattura. Se il tipo contratto è a gestione differita, crea anche gli accertamenti.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnElaboraFattureDaIncassi_Click(object sender, EventArgs e) {
			bool saved = btnElaboraIncassi.Visible;
			btnElaboraIncassi.Visible = false;
			Application.DoEvents();

			azzeraTutto();
			btnAssociaEventualiBollette_Click(sender, e);
			//btnElaboraIncassi.Enabled = false;
			creaFatture(!chkAncheSenzaSospesi.Checked);
			azzeraTutto();
			//btnElaboraIncassi.Enabled = true;
			btnElaboraIncassi.Visible = saved;
		}



		/// <summary>
		/// Per tutte le righe di flussoincassi associa il n. di sospeso attivo (nbill) se il sospeso ha la stessa causale della riga di 
		///  flussoincassi. Una riga di flusso incassi può essere associata ad un solo sospeso attivo, mentre un sospeso attivo
		///  può essere agganciato a più righe di flusso incassi
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAssociaEventualiBollette_Click(object sender, EventArgs e) {
			DS.flussoincassi.Clear();
			
			var sqlBill = $"select bill.nbill, bill.ybill, bill.adate, flussoincassi.causale from bill " +
			              $" join flussoincassi on " +
						  $" (bill.motive like '%'+flussoincassi.causale+'%' " +
						  $"AND flussoincassi.causale like '%/PUR/LGPE-RIVERSAMENTO/URI/%' ) OR "+
						  $" (bill.motive like '%/PUR/LGPE-RIVERSAMENTO/URI/' + flussoincassi.causale+'%') OR " +
						  $" (bill.motive like '%/PUR/LGPE-RIVERSAMENTO/_/URI/' + flussoincassi.causale+'%') OR " +
						  $" (bill.motive like '%'+flussoincassi.codiceflusso+'%')" +
			              $" WHERE flussoincassi.ayear= {esercizio} and flussoincassi.nbill is null " +
			              $" AND bill.billkind='C' and bill.ybill={esercizio} " +
			              $" AND (bill.motive like '%/PUR/LGPE-RIVERSAMENTO/URI/%'  " +
						  $" OR bill.motive like '%/PUR/LGPE-RIVERSAMENTO/_/URI/%' " +
						  $" OR bill.motive like '%/PUR/LGPE-RIVERSAMENTO/TXT/0/URI/%')"+
						  $" UNION " +	
						  $"select bill.nbill, bill.ybill, bill.adate, flussoincassi.causale from bill " +
						  $" join flussoincassi on " +
						  $" (bill.motive like '%'+flussoincassi.causale+'%' " +
						  $"AND flussoincassi.causale like '%/PUR/LGPE-RIVERSAMENTO/URI/%' ) OR " +
						  $" (bill.motive like '%/PUR/LGPE-RIVERSAMENTO/URI/' + flussoincassi.causale+'%') OR " +
						  $" (bill.motive like '%/PUR/LGPE-RIVERSAMENTO/_/URI/' + flussoincassi.causale+'%') OR" +
						  $" (bill.motive like '%'+flussoincassi.codiceflusso+'%')" +
						  $" WHERE flussoincassi.ayear= {esercizio} " +
						  $" AND bill.billkind='C' and bill.ybill={esercizio} + 1 " +
						  $" and MONTH(bill.adate) = 1 and DAY(bill.adate) <= 5 " +
	  					  $" and MONTH(flussoincassi.dataincasso)= 12 and DAY(flussoincassi.dataincasso) >= 25 " +
						  $" AND (bill.motive like '%/PUR/LGPE-RIVERSAMENTO/URI/%'  " +
						  $" OR bill.motive like '%/PUR/LGPE-RIVERSAMENTO/_/URI/%' " +
						  $" OR bill.motive like '%/PUR/LGPE-RIVERSAMENTO/TXT/0/URI/%')";

			DataTable billFromCausali = _conn.SQLRunner(sqlBill,false,0);
			if (billFromCausali.Rows.Count == 0)
				return;
			var rows = DS.flussoincassi.getFromDb(_conn, q.eq("ayear", esercizio)/* & q.isNull("nbill")*/);
			Dictionary<string,int> nBillPerCausale = new Dictionary<string, int>();
			Dictionary<string,object> dataIncassoPerCausale = new Dictionary<string, object>();
			Dictionary<string, int> annoBillPerCausale = new Dictionary<string, int>();
			foreach (DataRow r in billFromCausali.Rows) {
				string causale = r["causale"].ToString();
				int nbill = CfgFn.GetNoNullInt32(r["nbill"]);
				if (!nBillPerCausale.ContainsKey(causale)) {
					nBillPerCausale[causale] = nbill;
				}
				if (!dataIncassoPerCausale.ContainsKey(causale)) {
					dataIncassoPerCausale[causale] = r["adate"];
				}
				int ybill = CfgFn.GetNoNullInt32(r["ybill"]);
				if (!annoBillPerCausale.ContainsKey(causale)) {
					annoBillPerCausale[causale] = ybill;
                }
			}
			


			//var noChange = true;
			foreach (var r1 in rows) {
				// cerca di assegnare un sospeso attivo sulla base della causale
				var causale = r1.causale;
				if (string.IsNullOrEmpty(causale)) continue;
				if (nBillPerCausale.TryGetValue(causale, out int nBill)) {
					r1.nbill = nBill;
				}
				if (dataIncassoPerCausale.TryGetValue(causale, out object adate)) {
					if (adate!=DBNull.Value) r1.dataincassoValue = adate;
				}
				if (annoBillPerCausale.TryGetValue(causale, out int yBill)) {
					r1.ayear = (short)yBill;
                }
			}


			var myPostData = new Easy_PostData();
			myPostData.initClass(DS, _conn);
			var res = myPostData.DO_POST();
			DS.flussoincassi.Clear();
			if (!res) {
				show(this,
					"Errore nel salvataggio dell'associazione degli incassi alle bollette mediante causale bolletta");
				return;
			}

			// show(this, "Le bollette presenti sono state collegate.");
		}




		void AddVoceCreditore(DataRow R) {
			if (R["idreg"] == DBNull.Value) return;
			R["!registry"] = GetTitleForIdReg(R["idreg"]);
		}

		void AddVoceUPB(DataRow R) {
			if (R["idupb"] == DBNull.Value) return;
			R["!codeupb"] = GetTitleForIdUPB(R["idupb"]);
		}

		void AddVoceUPBIva(DataRow R) {
			if (R["idupb_iva"] == DBNull.Value) return;
			R["!codeupb_iva"] = GetTitleForIdUPB(R["idupb_iva"]);
		}
		//13720
		void AddVoceEstimkind(DataRow R) {
			if(R["idestimkind"]==DBNull.Value) return;
			R["!estimkind"] = GetTitleForEstimateKind(R["idestimkind"]);
		}

		void preScanVociCollegateDettagliContrattoAttivo(q filter) {
			DataTable tDettView = _conn.CreateTableByName("estimatedetailview",
				"idestimkind,yestim,nestim,idupb,upb,idupb_iva,upb_iva,idreg,registry,adate");
			_conn.readTableJoined(tDettView, "estimate", filter,
				q.eq("active", "S"),
				(from k in DS.estimate.PrimaryKey select k.ColumnName).ToArray());
			foreach (DataRow r in tDettView.Rows) {
				if (r["idreg"] != DBNull.Value) {
					__regTitles[CfgFn.GetNoNullInt32(r["idreg"])] = r["registry"].ToString();
				}

				;
				if (r["idupb"] != DBNull.Value) {
					__UpbTitles[r["idupb"].ToString()] = r["upb"].ToString();
				}

				if (r["idupb_iva"] != DBNull.Value) {
					__UpbTitles[r["idupb_iva"].ToString()] = r["upb_iva"].ToString();
				}

				addEstimateDateToDict(r);
			}

		}

		void AddVociCollegate(DataRow Row) {

			if (Row.Table.TableName == "estimatedetail") {
				AddVoceEstimkind(Row); //13720
				AddVoceCreditore(Row);
				AddVoceUPB(Row);
				AddVoceUPBIva(Row);
			}
		}

		Dictionary<int, string> __regTitles = new Dictionary<int, string>();

		string GetTitleForIdReg(object idreg) {
			if (idreg == DBNull.Value) return "";
			int n = Convert.ToInt32(idreg);
			DataRow reg = getRegistry(n);

			//if (__regTitles.ContainsKey(n)) return __regTitles[n];

			object title = reg?["title"]; //_conn.DO_READ_VALUE("registry", _qhs.CmpEq("idreg", idreg), "title");
			if (title == null) {
				title = "[anagrafica di codice " + idreg + "]";
			}

			__regTitles[n] = title.ToString();
			return title.ToString();
		}

		Dictionary<string, string> __UpbTitles = new Dictionary<string, string>();

		string GetTitleForIdUPB(object idupb) {

			if (idupb == DBNull.Value)
				return "";
			string str_idupb = idupb.ToString();
			if (__UpbTitles.ContainsKey(str_idupb))
				return __UpbTitles[str_idupb];
			object title = _conn.DO_READ_VALUE("upb", _qhs.CmpEq("idupb", idupb), "title");
			if (title == null) {
				title = "[upb di codice " + idupb + "]";
			}

			__UpbTitles[str_idupb] = title.ToString();
			return title.ToString();
		}


		Dictionary<string, object> __List = new Dictionary<string, object>();
		object GetIdListForCodelist(object codelist, out string errori) {
			errori = "";
			if (codelist == DBNull.Value) {

				return DBNull.Value;
			}
	 
			string str_codelist = codelist.ToString();
			if (__List.ContainsKey(str_codelist))
				return __List[str_codelist];
			object idlist = _conn.DO_READ_VALUE("list", _qhs.CmpEq("intcode", codelist), "idlist");
			if (idlist == null) {
				errori = " Codice Listino " + codelist.ToString() + " non trovato";
				return DBNull.Value;
			}

			__List[str_codelist] = idlist ;
			return idlist;
		}


		//13720
		Dictionary<string, string> __EstimatekindTitles = new Dictionary<string, string>();
		string GetTitleForEstimateKind(object estimatekind) {
			if (estimatekind == DBNull.Value)
				return "";
			string str_estimatekind = estimatekind.ToString();
			if (__EstimatekindTitles.ContainsKey(str_estimatekind))
				return __EstimatekindTitles[str_estimatekind];
			object title = _conn.DO_READ_VALUE("estimatekind", _qhs.CmpEq("idestimkind", estimatekind), "description");
			if (title == null) {
				title = "[estimkind di codice " + estimatekind + "]";
			}

			__EstimatekindTitles[str_estimatekind] = title.ToString();
			return title.ToString();
		}




		/// <summary>
		/// Legge in memoria i dettaglio contratti attivi con IUV ma senza contabilizzazione
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnCercaContrattiDaContabilizzare_Click(object sender, EventArgs e) {
			bool saved = btnCercaContrattiDaContabilizzare.Visible;
			btnCercaContrattiDaContabilizzare.Visible = false;
			Application.DoEvents();

			DS.estimatedetail.Clear();
			__UpbTitles.Clear();
			__regTitles.Clear();

			btnElaboraContabilizzazioni.Enabled = false;
			// filtra le righe contratti attivi associate a flusso crediti (iduniqueformcode non nullo) non ancora contabilizzate
			var filterDett = ((q.isNull("idinc_taxable")) | (q.isNull("idinc_iva") & q.gt("tax", 0))) &
			                 q.isNotNull("iduniqueformcode") &
			                 q.isNull("stop");
			var filterEstimate = q.eq("active", "S");
			var secEstimate = MetaExpressionParser.From(_conn.Security.SelectCondition("estimate", true));
			var enabledIdEstimkind =
				(from r in DS.estimatekind where ((r.flag ?? 0) & 1) == 0 select r.idestimkind).ToArray();
			filterEstimate &= q.fieldIn("idestimkind", enabledIdEstimkind);
			if (secEstimate != null) filterEstimate &= secEstimate;
			_conn.readTableJoined(DS.estimatedetail, "estimate",
				filterDett,
				filterEstimate, (from k in DS.estimate.PrimaryKey select k.ColumnName).ToArray()
			);
			preScanVociCollegateDettagliContrattoAttivo(
				((q.isNull("idinc_taxable")) | (q.isNull("idinc_iva") & q.gt("tax", 0))) &
				q.isNotNull("iduniqueformcode") &
				q.isNull("stop"));
			//DS.estimatedetail.getFromDb(_conn,
			//    ((q.isNull("idinc_taxable")) | (q.isNull("idinc_iva"))) & q.isNotNull("iduniqueformcode")  & q.isNull("stop"));
			var mDettaglio = _dispatcher.Get("estimatedetail");
			if (DS.estimatedetail.Rows.Count > 0) {
				for (int i = 0; i < DS.estimatedetail.Rows.Count; i++) {
					AddVociCollegate(DS.estimatedetail
						.Rows[i]); //si può ottimizzare passando il filtro originario usato per estimatedetail per fare un join
					mDettaglio.CalculateFields(DS.estimatedetail.Rows[i], "contabilizza");
				}
			}

			HelpForm.SetAllowMultiSelection(DS.estimatedetail, true);
			HelpForm.SetDataGrid(dgrDettContrattiAttivi, DS.estimatedetail);

			if (DS.estimatedetail.Rows.Count > 0) {
				for (int i = 0; i < DS.estimatedetail.Rows.Count; i++) {

					dgrDettContrattiAttivi.Select(i); // seleziona tutto
				}
			}

			if (DS.estimatedetail.Rows.Count == 0) {
				show("Nessun dettaglio contratto trovato", "Avviso");
			}

			btnElaboraContabilizzazioni.Enabled = DS.estimatedetail.Rows.Count > 0 && faseentratamax > 1;

			btnCercaContrattiDaContabilizzare.Visible = saved;
		}

		private void btnCreaFattureVendita_Click(object sender, EventArgs e) {

		}

		string hashActiveContract(DataRow r) {
			return $"{r["idestimkind"]}§{r["yestim"]}§{r["nestim"]}";
		}

		/// <summary>
		/// Genera le scritture sui contratti attivi di cui nel dataset in memoria è stata impostata la data inizio di qualche dettaglio
		/// </summary>
		public void generaScrittureContrattiAttiviEsterno() {
			var ext = DS.Clone();
			foreach (string table in new[] {"estimate", "estimatedetail"}) {
				ext.Tables[table].Merge(DS.Tables[table]);//preserva i cambiamenti delle righe modificate
			}

			var contractToGenerate = new Dictionary<string, bool>();
			foreach (var rEstim in DS.estimate) {
				contractToGenerate[hashActiveContract(rEstim)] = false;
			}


			foreach (DataRow r in ext.Tables["estimatedetail"].Select()) {
				if (r.RowState == DataRowState.Added) {
					continue;//non dovrebbe passare da qui no??
				}

				if (r.RowState != DataRowState.Modified) {
					//Questi li lascio stare perchè servono ai fini delle scritture eventuali
					//ext.Tables["estimatedetail"].Rows.Remove(r);
					if (r.RowState != DataRowState.Unchanged) {
						r.RejectChanges();
					}
					continue;
				}

				//Questi li lascio stare perchè servono ai fini delle scritture eventuali
				//if (r["start", DataRowVersion.Original] != DBNull.Value) { //era già stato generato
				//	ext.Tables["estimatedetail"].Rows.Remove(r);
				//	continue;
				//}

				if (r["start", DataRowVersion.Current] == DBNull.Value) {
					r.RejectChanges();	//non imposta ancora il movimento collegato ma lascia newStart a null
					//ext.Tables["estimatedetail"].Rows.Remove(r); saltiamo quelle con start null
					continue;
				}

				//prende solo le righe di cui è stato ora impostato lo start

				object newStart = r["start"];
				r.RejectChanges();	//non imposta ancora il movimento collegato ma lascia newStart
				r["start"] = newStart;
				contractToGenerate[hashActiveContract(r)] = true;
			}

			ext.Tables["estimate"].RejectChanges();
		
			//ext.Tables["flussoincassi"].RejectChanges();//non salva ancora flussoincassi, non serve tanto la tabella non è stata riportata in ext

			var metaEstimate = _dispatcher.Get("estimate");
			metaEstimate.DS = ext;

			var estimateSkipped = new List<string>();
			if (ext.Tables["estimate"].Rows.Count > 0) {
				var post = new Easy_PostData_NoBLNoTimeStamp();
				post.initClass(ext, _conn);
				if (!post.DO_POST()) return;

				foreach (DataRow rEstim in ext.Tables["estimate"].Rows) {
					ext.Tables["estimatedetail"]._safeMergeFromDb(_conn, q.keyCmp(rEstim));
					if (!contractToGenerate[hashActiveContract(rEstim)]) continue;
					var epm = new EP_Manager(metaEstimate, null, null, null, null, null, null, null, null, "estimate");
					epm.disableIntegratedPosting();
					epm.silent = true;
					epm.autoIgnore = true;
					epm.setForcedCurrentRow(rEstim);
					epm.afterPost(true); //potrebbe modificare estimatedetail (idepacc..) ma al momento abbiamo verificato che non tocca lt/lu

					if (epm.ultimaGenerazioneRiuscita == false) {
						estimateSkipped.Add(descrContrattoAttivo(rEstim));
						//Sarebbe il caso di non salvare questo contratto ma non è semplice
					}

					epm.Dispose();

					//Sistema il valore della riga originale
					//non credo sia necessario -->in realtà lo sarebbe ma usando la nuova classe Easy_PostData_NoBLNoTimeStamp non lo è più

				}
			}

			if (estimateSkipped.Count > 0) {
                wndDisplay w = new wndDisplay("Contratti attivi da rivedere",
					"Per i seguenti contratti attivi non sono state generati movimenti di budget e/o scritture E/P",
					estimateSkipped);

                createForm(w, this);
                w.Show(this);
			}




		}

		/// <summary>
		/// Crea gli incassi per i contratti attivi, di cui possono esistere o meno gli accertamenti
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnIncassiContrattiAttivi_Click(object sender, EventArgs e) {
			btnIncassiContrattiAttivi.Visible = false;
			Application.DoEvents();
			azzeraTutto();

			btnAssociaEventualiBollette_Click(sender, e);

			DataSet dSupdated;


			bool res = creaIncassiContrattiAttivi(!chkAncheSenzaSospesi.Checked);
			if (!DS.HasChanges()) {
				ricalcolaFlagElaborato();
				azzeraTutto();
				show("Nessun incasso da creare", "Avviso");
				btnIncassiContrattiAttivi.Visible = true;
				return;
			}

			//Ci sono movimenti da salvare
			if (res) {
				//Genera le scritture sui contratti attivi di cui nel dataset in memoria è stata impostata la data inizio di qualche dettaglio
				generaScrittureContrattiAttiviEsterno();

				//Il salvataggio azzera anche i movimenti finanziari
				if (doSave(out dSupdated)) {
					show("Gli incassi per i contratti attivi sono stati salvati.", "Avviso");
				}
				else {
					show("Errore nel salvataggio degli incassi per i contratti attivi", "Errore");
					btnIncassiContrattiAttivi.Visible = true;
					return;
				}
			}

			azzeraTutto();
			btnIncassiContrattiAttivi.Visible = true;
		}

		private void btnCreaIncassiFatture_Click(object sender, EventArgs e) {
			string error;
			if (!generaIncassiFatture(!chkAncheSenzaSospesi.Checked, out error)) {
				show("Errore nel salvataggio incassi per le fatture" + "\r\n" + error, "Errore");
			}

			;
			azzeraTutto();
		}

		private void btnSospesiRFSRFB_Click(object sender, EventArgs e) {
			var t = _conn.SQLRunner(
				$@"select null as codice_fiscale_studente, nbill as numero_sospeso_attivo,           
                 bill.motive as causale,      
                 adate as data_incasso,
                 (select min(iduniqueformcode) from flussocreditidetail fd where 
                          bill.motive like '%/RFS/'+fd.iuv+'/%' or bill.motive like '%/RFB/'+fd.iuv+'/%') as codice_bollettino_univoco,
                 total as importo 
                 from bill where (bill.motive like '%/RFS/%' or bill.motive like '%/RFB/%') and ybill = {esercizio} and billkind='C'  
                 and exists( select * from flussocreditidetail fd where bill.motive like  '%/RFS/'+fd.iuv+'/%' or bill.motive like '%/RFB/'+fd.iuv+'/%')
                 and not exists(select * from flussoincassi f2 where f2.nbill=bill.nbill and f2.ayear={esercizio})");
			if (t == null) return;
			if (t.Rows.Count == 0) {
				show("Nessun sospeso RFB o RFS trovato da collegare.", "Avviso");
				return;
			}

			importaTabellaFlussoIncassi(t);
		}

		public class Easy_PostData_NoBLNoTimeStamp : PostData {
			override public string GetOptimisticClause(DataRow R) {
				if (R.Table.PrimaryKey != null) {
					if ((R.Table.Columns["lu"] != null) &&
					    (R.Table.Columns["lt"] != null) &&
					    R.Table.PrimaryKey.Length > 0) {
						int keylen = R.Table.PrimaryKey.Length;
						DataColumn[] Cs = new DataColumn[keylen + 2];
						for (int i = 0; i < keylen; i++) Cs[i] = R.Table.PrimaryKey[i];
						Cs[keylen] = R.Table.Columns["lu"];
						Cs[keylen + 1] = R.Table.Columns["lt"];
						return QueryCreator.WHERE_REL_CLAUSE(R, Cs, Cs, DataRowVersion.Original, true);
					}
				}

				return base.GetOptimisticClause(R);
			}

		}

		public struct messaggio {
			public string msg;
			public bool error;
		}

		private void btnAnnullaCrediti_Click(object sender, EventArgs e)
		{
			DS.Clear();
			dgrCreditiAnnullati.DataBindings.Clear();
			dgrCreditiAnnullati.DataSource = null;
			dgrCreditiAnnullati.TableStyles.Clear();
			QueryCreator.MarkEvent("Inizio btnAnnullaCrediti_Click");
			btnAnnullaCrediti.Visible = false;


			var metaFlussoCrediti = _dispatcher.Get("flussocrediti");
			metaFlussoCrediti.SetDefaults(DS.flussocrediti);

			var metaFlussoCreditiDetail = _dispatcher.Get("flussocreditidetail");
			metaFlussoCreditiDetail.SetDefaults(DS.flussocreditidetail);
			 //MetaUnder.DS = new DataSet();
            //MetaUnder.linkedForm = this;

			object CodiceBollettino = txtCodiceBollettinoUnivoco.Text;
			
		
            metaFlussoCreditiDetail.FilterLocked = true;
			string filter =   _qhs.AppAnd(_qhs.IsNotNull("iduniqueformcode"), _qhs.IsNull("stop"),
				_qhs.IsNull("annulment") );

			if(CodiceBollettino!= DBNull.Value) {
				filter = _qhs.AppAnd(filter, _qhs.Like("iduniqueformcode",(string)CodiceBollettino + "%"));
			}

            DataRow Row = metaFlussoCreditiDetail.SelectOne("default_da_annullare", filter, "flussocreditidetail", null);
            if (Row == null) 
			{
				btnAnnullaCrediti.Visible = true;
				return;
			}
			txtCodiceBollettinoUnivoco.Text = Row["iduniqueformcode"].ToString();

			Application.DoEvents();
			object startFlusso = DBNull.Value;
			object stopFlusso = DBNull.Value;
			object oCodiceBollettinoUnivoco = DBNull.Value;
			object oNewCodiceBollettinoUnivoco = DBNull.Value;
			object oDataContabile = _security.GetSys("datacontabile");
			//string filterCreditidetail = "";
			q filterCreditidetail= q.constant(true);
			//if (txtStartFlussoAnn.Text != "")
			//{
			//	object startf = HelpForm.GetObjectFromString(typeof(int), txtStartFlussoAnn.Text, "x.y.g");
			//	if (startf == null)
			//	{
			//		show("Numero non valido in n.flusso iniziale", "Errore");
			//		btnAnnullaCrediti.Visible = true;
			//		return;
			//	}

			//	startFlusso = startf;

			//}


			//if (txtStopFlussoAnn.Text != "")
			//{
			//	object stopf = HelpForm.GetObjectFromString(typeof(int), txtStopFlussoAnn.Text, "x.y.g");
			//	if (stopf == null)
			//	{
			//		show("Numero non valido in n.flusso finale", "Errore");
			//		btnAnnullaCrediti.Visible = true;
			//		return;
			//	}
			//	stopFlusso = stopf;
			//}
			//else
			//{
			//	stopFlusso = startFlusso;

			//}

			//if ((startFlusso != DBNull.Value) && (stopFlusso != DBNull.Value))
			//	filterCreditidetail = q.between("idflusso", startFlusso, stopFlusso);
			//else
			//	if (startFlusso != DBNull.Value)
			//	filterCreditidetail = q.eq("idflusso", startFlusso);

			if (txtCodiceBollettinoUnivoco.Text != "")
			{
				object i = HelpForm.GetObjectFromString(typeof(string), txtCodiceBollettinoUnivoco.Text, "x.y.g");
				if (i == null)
				{
					show("Codice Bollettino Univoco non valido ", "Errore");
					btnAnnullaCrediti.Visible = true;
					return;
				}
				oCodiceBollettinoUnivoco = i;
			}



			if ((oCodiceBollettinoUnivoco==DBNull.Value)&&(startFlusso==DBNull.Value))
					{
					show("E' necessario inserire almeno il codice bollettino ", "Errore");
					btnAnnullaCrediti.Visible = true;
					return;
				}


			#region annullamento credito 
			string errore = "";

			var existentRowsToAnnull = DS.flussocreditidetail.get(_conn,
				q.eq("iduniqueformcode", oCodiceBollettinoUnivoco) & q.isNull("stop") &
				q.isNull("annulment") & filterCreditidetail);

			if (existentRowsToAnnull.Length == 0)
			{
				errore =
					$"Bollettino numero {oCodiceBollettinoUnivoco} non trovato (o già annullato) nei crediti esistenti. L'annullo di tale bollettino non sarà considerato.";
				show(errore, "Avviso");
				return;
			}


			DataRow[] rFlussoCreditiRows = DS.flussocrediti.get(_conn,
				q.eq("idflusso", existentRowsToAnnull[0]["idflusso"]));
			if (rFlussoCreditiRows.Length == 0)
			{
				errore =
					$"Flusso numero {existentRowsToAnnull[0]["idflusso"]} non trovato. L'annullo di tale bollettino non sarà considerato.";
				show(errore, "Avviso");
				return;
			}
			DataRow rFlussoCrediti = rFlussoCreditiRows[0];
			var rNewFlussoCrediti = metaFlussoCrediti.Get_New_Row(null, DS.flussocrediti);

			//copia alcuni campi dalla riga originale da annullare
			foreach (var field in new[] {
				"idestimkind",
				"idsor01", "idsor02","idsor03", "idsor04", "idsor05"

			})
			{
				rNewFlussoCrediti[field] = rFlussoCrediti[field];
			}

			rNewFlussoCrediti["datacreazioneflusso"] = _security.GetSys("datacontabile");
			rNewFlussoCrediti["flusso"] = DBNull.Value;
			rNewFlussoCrediti["istransmitted"] = "S"; //il flusso che creiamo si intenda già trasmesso da un programma esterno
			rNewFlussoCrediti["filename"] = DBNull.Value; ;
			rNewFlussoCrediti["docdate"] = oDataContabile;
			rNewFlussoCrediti["ct"] = DateTime.Now;
			rNewFlussoCrediti["cu"] = "importaFlussoCrediti_" + _conn.externalUser;
			rNewFlussoCrediti["lt"] = DateTime.Now;
			rNewFlussoCrediti["lu"] = "importaFlussoCrediti_" + _conn.externalUser;

			//Crea una riga di annullamento per ogni riga esistente da annullare e ne imposta il campo annullato
			foreach (var rToAnnull in existentRowsToAnnull)
			{
				//  nuova riga di annullo che creiamo, deve avere la data fine validità stop
				//  la vecchia riga del credito esistente deve avere la data di annullo 
				rToAnnull.annulmentValue = oDataContabile; //Imposta il campo ANNULLATO nel dettaglio credito esistente  

				var InvoicedetailsToUnlink = DS.invoicedetail.get(_conn,
				q.eq("iduniqueformcode", oCodiceBollettinoUnivoco) & 
				q.eq("idinvkind", rToAnnull.idinvkind) &
				q.eq("yinv", rToAnnull.yinv) &
				q.eq("ninv", rToAnnull.ninv) &
				q.eq("rownum", rToAnnull.invrownum));


				// task 17307 azzero sulla riga da annullare e sulla copia i riferimenti alla fattura
				rToAnnull.idinvkind = null; //Imposta il campo a null nel dettaglio credito esistente 
				rToAnnull.yinv = null; //Imposta il campo null nel dettaglio credito esistente 
				rToAnnull.ninv = null; //Imposta il campo null nel dettaglio credito esistente 
				rToAnnull.invrownum = null; //Imposta il campo null nel dettaglio credito esistente 
				
				var rNewFlussocreditiDetail =
					metaFlussoCreditiDetail.Get_New_Row(rNewFlussoCrediti, DS.flussocreditidetail) as
						flussocreditidetailRow;

				//copia alcuni campi dalla riga originale da annullare
				foreach (var field in new[] {
					"importoversamento", "idestimkind", "yestim", "nestim", "rownum", "idinvkind", "yinv",
					"ninv", "invrownum","tax","number","idlist","annotations",
					"idsor1","idsor2","idsor3","iuv",
					"nform",
					"expirationdate",
					"barcodevalue",
					"barcodeimage",
					"qrcodevalue",
					"qrcodeimage",
					"idfinmotive",//idCodiceCausaleFinanziaria;
					"idfinmotive_iva",//idCodiceCausaleFinanziaria per IVA;
					"iduniqueformcode",//oCodiceBollettinoUnivoco;
					"idaccmotiverevenue",//idcausaleEpRicavo;
					"idaccmotivecredit",//idcausaleEpCredito;

					"idaccmotiveundotax",//idcausaleEpRicavo;
					"idaccmotiveundotaxpost",//idcausaleEpRicavo;
					"stop",//oDataContabile;

					"competencystart",//competencystart;
					"competencystop",//competencystop;
					"description",//description;
					"cf",//oCodiceFiscaleStudente.ToString().ToUpper();
					"p_iva", 
					"idreg",//oIdreg;
					"idupb",//idupb;
					"idupb_iva",
					"codicetassonomia"
				})
				{
					rNewFlussocreditiDetail[field] = rToAnnull[field];
				}
 
				rNewFlussocreditiDetail.stopValue = oDataContabile; //Imposta il campo DATA FINE VALIDITA' nel dettaglio credito nuovo
				rNewFlussocreditiDetail.flag = 0;
				rNewFlussocreditiDetail["ct"] = DateTime.Now;
				rNewFlussocreditiDetail["cu"] = "import_flussostudenti";
				rNewFlussocreditiDetail["lt"] = DateTime.Now;
				rNewFlussocreditiDetail["lu"] = "import_flussostudenti";

				foreach (var rInvDetail in InvoicedetailsToUnlink) {
					rInvDetail.iduniqueformcode = null;
				}
					
			}

			#endregion

			var myPostData = new Easy_PostData();
			myPostData.initClass(DS, _conn);
			var resSave = myPostData.DO_POST();

			if (!resSave)
			{
				show(this, "Errore nel salvataggio");
				btnAnnullaCrediti.Visible = true;
				return;
			}
				else
			{
				show(this, "Elaborazione effettuata");
				btnAnnullaCrediti.Visible = true;
			}
			DataSet ds = new DataSet();
			ds.Merge(DS.flussocreditidetail);
			DataTable t = ds.Tables[0];
	
			HelpForm.SetDataGrid(dgrCreditiAnnullati, t);
			dgrCreditiAnnullati.Tag = "flussocreditidetail.default_annullati";
			formatgrids fg = new formatgrids(dgrCreditiAnnullati);
			fg.AutosizeColumnWidth();
			btnAnnullaCrediti.Visible = true;
			//dgrCreditiAnnullati.SetDataBinding(ds1, dt.TableName);

			//HelpForm.SetDataGrid(dgrCrediti, dt);
			//HelpForm.SetGridStyle(dgrCrediti, dt);

		}

		private void dgrCrediti_DoubleClick(object sender, EventArgs e)
		{

		}
	}

}
