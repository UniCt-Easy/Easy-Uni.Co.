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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using metadatalibrary;

namespace admpay_splitcolumn {
	/// <summary>
	/// Descrizione di riepilogo per FrmAdmPay_SplitColumn.
	/// </summary>
	public class FrmAdmPay_SplitColumn : System.Windows.Forms.Form {
		System.Data.DataTable mData = new System.Data.DataTable();
        System.Data.DataTable tToExcel;
		MetaData Meta;
		string ConnectionString;
		public admpay_splitcolumn.vistaForm DS;
		private System.Windows.Forms.Button btnInputFile;
		private System.Windows.Forms.TextBox txtInputFile;
		private System.Windows.Forms.Button btnFileLordi;
		private System.Windows.Forms.OpenFileDialog openInputFileDlg;
		private System.Windows.Forms.SaveFileDialog saveOutputFileDlg;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label lblTask;
        private System.Windows.Forms.Button btnFileReversali;
        private System.Windows.Forms.Button btnFileContr;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
		/// <summary>
		/// Variabile di progettazione necessaria.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmAdmPay_SplitColumn() {
			InitializeComponent();
		}

		/// <summary>
		/// Pulire le risorse in uso.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if(components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Codice generato da Progettazione Windows Form
		/// <summary>
		/// Metodo necessario per il supporto della finestra di progettazione. Non modificare
		/// il contenuto del metodo con l'editor di codice.
		/// </summary>
		private void InitializeComponent() {
            this.DS = new admpay_splitcolumn.vistaForm();
            this.btnInputFile = new System.Windows.Forms.Button();
            this.txtInputFile = new System.Windows.Forms.TextBox();
            this.btnFileLordi = new System.Windows.Forms.Button();
            this.openInputFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.saveOutputFileDlg = new System.Windows.Forms.SaveFileDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblTask = new System.Windows.Forms.Label();
            this.btnFileReversali = new System.Windows.Forms.Button();
            this.btnFileContr = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnInputFile
            // 
            this.btnInputFile.Location = new System.Drawing.Point(8, 8);
            this.btnInputFile.Name = "btnInputFile";
            this.btnInputFile.Size = new System.Drawing.Size(80, 23);
            this.btnInputFile.TabIndex = 0;
            this.btnInputFile.Text = "File di Input";
            this.btnInputFile.Click += new System.EventHandler(this.btnInputFile_Click);
            // 
            // txtInputFile
            // 
            this.txtInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInputFile.Location = new System.Drawing.Point(96, 8);
            this.txtInputFile.Name = "txtInputFile";
            this.txtInputFile.ReadOnly = true;
            this.txtInputFile.Size = new System.Drawing.Size(393, 20);
            this.txtInputFile.TabIndex = 2;
            // 
            // btnFileLordi
            // 
            this.btnFileLordi.Location = new System.Drawing.Point(191, 19);
            this.btnFileLordi.Name = "btnFileLordi";
            this.btnFileLordi.Size = new System.Drawing.Size(104, 23);
            this.btnFileLordi.TabIndex = 4;
            this.btnFileLordi.Text = "Lordi";
            this.btnFileLordi.Click += new System.EventHandler(this.btnFileLordi_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(2, 185);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(481, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // lblTask
            // 
            this.lblTask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTask.Location = new System.Drawing.Point(2, 153);
            this.lblTask.Name = "lblTask";
            this.lblTask.Size = new System.Drawing.Size(481, 23);
            this.lblTask.TabIndex = 6;
            // 
            // btnFileReversali
            // 
            this.btnFileReversali.Location = new System.Drawing.Point(6, 19);
            this.btnFileReversali.Name = "btnFileReversali";
            this.btnFileReversali.Size = new System.Drawing.Size(121, 23);
            this.btnFileReversali.TabIndex = 7;
            this.btnFileReversali.Text = "Reversali";
            this.btnFileReversali.UseVisualStyleBackColor = true;
            this.btnFileReversali.Click += new System.EventHandler(this.btnFileReversali_Click);
            // 
            // btnFileContr
            // 
            this.btnFileContr.Location = new System.Drawing.Point(362, 19);
            this.btnFileContr.Name = "btnFileContr";
            this.btnFileContr.Size = new System.Drawing.Size(113, 23);
            this.btnFileContr.TabIndex = 8;
            this.btnFileContr.Text = "Versamenti";
            this.btnFileContr.UseVisualStyleBackColor = true;
            this.btnFileContr.Click += new System.EventHandler(this.btnFileContr_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFileReversali);
            this.groupBox1.Controls.Add(this.btnFileContr);
            this.groupBox1.Controls.Add(this.btnFileLordi);
            this.groupBox1.Location = new System.Drawing.Point(8, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(481, 54);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Formattazione dei file per";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(477, 44);
            this.label1.TabIndex = 10;
            this.label1.Text = "ATTENZIONE: Per generare Reversali e Lordi viene adoperato il file dei Riepiloghi" +
                ", per i versamenti il file dei Versamenti";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmAdmPay_SplitColumn
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(497, 220);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTask);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.txtInputFile);
            this.Controls.Add(this.btnInputFile);
            this.Name = "FrmAdmPay_SplitColumn";
            this.Text = "FrmAdmPay_SplitColumn";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        CQueryHelper QHC;
        QueryHelper QHS;
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
		}

		public void MetaData_AfterActivation() {
			this.Text = this.Text.Replace("(Ricerca)","");
		}
		
		public void MetaData_AfterClear() {
			this.Text = this.Text.Replace("(Ricerca)","");
		}

		private void btnInputFile_Click(object sender, System.EventArgs e) {
			DialogResult dr = openInputFileDlg.ShowDialog();
			if (dr != DialogResult.OK){
				MessageBox.Show("Non è stato scelto alcun file");
				txtInputFile.Text = "";
				return;
			}

			string fileName = openInputFileDlg.FileName;
			txtInputFile.Text = fileName;
		}
        /// <summary>
        /// Metodo, associato al Click del bottone btnFileLordi, che avvia la procedura di generazione
        /// di un file Excel contenente le informazioni sui lordi sulle quali generare movimenti di spesa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void btnFileLordi_Click(object sender, System.EventArgs e) {
            if (!interrogaFileExcel("L")) {
                return;
            }

            if (!effettuaSplit("L")) {
				MessageBox.Show("Errore nello split delle colonne");
				return;
			}

			apriFile(tToExcel, true);
		}

        /// <summary>
        /// legge i dati dal foglio di Excel a mData
        /// </summary>
		private void ReadCurrentSheet() {
			try {
                lblTask.Text = "Apertura del file...ATTENDERE";
				// open the connection to the file
				using( OleDbConnection connection = 
						   new OleDbConnection(ConnectionString)) {
					connection.Open();
					System.Data.DataTable sheetData = connection.GetOleDbSchemaTable( OleDbSchemaGuid.Tables, null );
					string foglioLavoro = sheetData.Rows[0]["TABLE_NAME"].ToString();
					string sql = 
						string.Format("select * from [{0}]", foglioLavoro);
					// create an adapter
					using( OleDbDataAdapter adapter = 
							   new OleDbDataAdapter(sql, connection)) {
                        lblTask.Text = "Riempimento della tabella temporanea Fase 1 di 2 ...ATTENDERE";
						// clear the datatable to avoid old data persistance
						mData.Clear();
						mData.Columns.Clear();

						// fille the datatable
                        lblTask.Text = "Riempimento della tabella temporanea Fase 2 di 2 ...ATTENDERE";
						adapter.Fill(mData);
                        lblTask.Text = "";
					}
				}
			}
			catch(Exception ex) {
				MessageBox.Show(this, ex.Message);
			}
		}

		/// <summary>
		/// Metodo che effettua lo split delle colonne in base al task da eseguire
		/// </summary>
		/// <param name="task"></param>
		/// <returns></returns>
		private bool effettuaSplit(string task) {
            // Parte comune a tutti i task
			if (!split_descrizione("CAPITOLO", "CAPITOLO_DESCR", " ")) return false;
			if (!split_descrizione("RUOLO", "RUOLO_DESCR", " ")) return false;
            //if (!split_compSiope()) return false;
            // Parte che varia per task
            switch (task) {
                    // Ramo Versamenti:
                case "V": {
                        // Si epurano le colonne ENTE e VOCE
                        if (!split_descrizione("ENTE", "", " ")) return false;
                        if (!split_descrizione("VOCE", "", " ")) return false;
                        // Si definiscono le colonne che devono far parte del file Excel di output
                        string[] elencoColonne = new string[] { "ENTE", "VOCE", "RUOLO", "CAPITOLO", "COMPETENZA", "MATRICOLA" };
                        // Si costruisce una tabella di output con le colonne indicate in elencoColonne
                        if (!copyTableWithLessColumn(elencoColonne, "IMP_TOT", out tToExcel)) return false;
                        break;
                    }
                    // Ramo Lordi:
                case "L": {
                        // Si definiscono le colonne che devono far parte del file Excel di output
                        string[] elencoColonne = new string[] { "RUOLO", "CAPITOLO", "COMPETENZA", "MATRICOLA" };
                        // Si costruisce una tabella di output con le colonne indicate in elencoColonne
                        if (!copyTableWithLessColumn(elencoColonne, "LORDO", out tToExcel)) return false;
                        break;
                    }
                    // Ramo Reversali:
                case "R": {
                        // Si procede alla trasformazione delle colonne della tabella originale in righe della tabella
                        // che diventerà un file di Excel di output
                        if (!transformColumnInRow(out tToExcel)) return false;
                        break;
                    }
            }
			return true;
		}

        /// <summary>
        /// Metodo che crea una tabella con le colonne specificate in elencoColonne più la colonna IMPORTO
        /// </summary>
        /// <param name="elencoColonne"></param>
        /// <param name="originalFieldAmount"></param>
        /// <param name="tNewLayout"></param>
        /// <returns></returns>
        private bool copyTableWithLessColumn(string [] elencoColonne, string originalFieldAmount, out System.Data.DataTable tNewLayout) {
            tNewLayout = null;
            tNewLayout = creaTabellaConNuovoLayout(elencoColonne);
            //Aggiunta della colonna importo
            tNewLayout.Columns.Add("IMPORTO");

            foreach(System.Data.DataRow rOrigine in mData.Rows) {
                System.Data.DataRow newRow = tNewLayout.NewRow();
                // Ciclo che ricopia nella nuova tabella i valori presenti nella tabella originale
                foreach (System.Data.DataColumn cOrigine in mData.Columns) {
                    if (cOrigine.ColumnName == originalFieldAmount) continue;
                    if (!tNewLayout.Columns.Contains(cOrigine.ColumnName)) continue;
                    newRow[cOrigine.ColumnName] = rOrigine[cOrigine.ColumnName];
                }
                // Valorizzazione della colonna importo
                newRow["IMPORTO"] = rOrigine[originalFieldAmount];

                tNewLayout.Rows.Add(newRow);
            }

            return true;
        }

        /// <summary>
        /// Divide un campo (per tutte le righe di mData) prendendo quello che viene prima del separatore
        /// </summary>
        /// <param name="fieldOriginal">Nome del campo originale</param>
        /// <param name="fieldDescr">Nome del campo dove finisce la descrizione - parametro ad oggi inutile</param>
        /// <param name="separatore">Carattere di separazione</param>
        /// <returns></returns>
		private bool split_descrizione(string fieldOriginal, string fieldDescr, string separatore) {
            string operazione = "";
            switch (fieldOriginal) {
                case "CAPITOLO": {
                        operazione = "Split descrizione del capitolo";
                        break;
                    }
                case "RUOLO": {
                        operazione = "Split descrizione del ruolo";
                        break;
                    }
                case "ENTE": {
                        operazione = "Split descrizione dell'ente";
                        break;
                    }
                case "VOCE": {
                        operazione = "Split descrizione della voce";
                        break;
                    }
            }
			 
			lblTask.Text = operazione;
			progressBar1.Value = 0;
			progressBar1.Maximum = mData.Rows.Count;
			foreach(System.Data.DataRow r in mData.Select()) {
				progressBar1.Value++;
				System.Windows.Forms.Application.DoEvents();
				if (r[fieldOriginal] == DBNull.Value) continue;
				string capitolo = r[fieldOriginal].ToString();
				int indice = capitolo.IndexOf(separatore);
				if (indice == -1) continue;
				string descrizione = capitolo.Remove(0, indice + 1);
				string codice = capitolo.Remove(indice, capitolo.Length - indice);
				r[fieldOriginal] = codice;
                //r[fieldDescr] = descrizione;
			}
			return true;
		}

		private bool split_compSiope() {
			lblTask.Text = "Split descrizione COMPETENZA SIOPE";
			progressBar1.Value = 0;
			progressBar1.Maximum = mData.Rows.Count;
			foreach(System.Data.DataRow r in mData.Select()) {
				progressBar1.Value++;
				System.Windows.Forms.Application.DoEvents();
				if (r["COMPETENZA"] == DBNull.Value) continue;
                string compSiope = r["COMPETENZA"].ToString().ToUpper();
				compSiope = compSiope.Replace("ANNO CORRENTE", "A. C.");
				compSiope = compSiope.Replace("ANNI PRECEDENTI", "A. P.");
                int ayear = 0;
                try {
                    ayear = Int32.Parse(compSiope);
                }
                catch {
                }
                
                if (ayear != 0) {
                    int currAyear = (int)Meta.GetSys("esercizio");
                    if (ayear == currAyear) {
                        compSiope = compSiope.Replace(ayear.ToString(), "A. C.");
                    }
                    else {
                        compSiope = compSiope.Replace(ayear.ToString(), "A. P.");
                    }
                }

                r["COMPETENZA"] = compSiope;
			}
			return true;
		}

        /// <summary>
        /// METODO NON USATO.
        /// </summary>
        /// <param name="tSortingKind"></param>
        /// <param name="rSource"></param>
        /// <param name="tName"></param>
        /// <param name="field"></param>
        /// <param name="taxCodeMaster"></param>
        /// <returns></returns>
		private object individuaOggetto(System.Data.DataTable tSortingKind, System.Data.DataRow rSource,
			string tName, string field, out object taxCodeMaster) {
			taxCodeMaster = null;
			string sortField;
			
			string filter = costruisciFiltro(tSortingKind, tName, rSource, out sortField);
			if (filter == null) return null;
			string f2 = QHS.CmpEq("S.idsorkind", "SPLITCONTR");
			filter = GetData.MergeFilters(f2, filter);
			// In base al filtro ottenuto vengono estratte N righe dalla classificazione
			// della tabella tNameSORTING
			// Verrà presa la voce che avrà meno null associati.
			string tNameChild = tName + "sorting";
			// In listaCampi aggiungo tutti i campi derivanti dal metodo costruisci filtro e aggiungo la virgola davanti
			string listaCampi = (sortField != "") ? "," + sortField : "";
			listaCampi += ", defaults1";
			string query = "SELECT " + field + listaCampi + " FROM sorting S "
				+ " JOIN " + tNameChild + " C "
				+ " ON " + QHS.CmpEq("S.idsor", QHS.Field("C.idsor"))
				+ " WHERE " + filter;
			System.Data.DataTable tOut = DataAccess.SQLRunner(Meta.Conn, query, true);
			if ((tOut == null) || (tOut.Rows.Count == 0)) return null;
			int min = 100;
			object idobj = null;
			foreach(DataRow rOut in tOut.Rows) {
				int nNull = 0;
				foreach(DataColumn C in tOut.Columns) {
					if (C.ColumnName == field) continue;
					if (rOut[C] == DBNull.Value) nNull++;
				}
				if (nNull < min) {
					min = nNull;
					idobj = rOut[field];
					taxCodeMaster = rOut["defaults1"];
				}
			}
			return idobj;
		}

		/// <summary>
		/// Metodo che restituisce il filtro che interrogherà la tabella di classificazione associata alla tabella tName
		/// </summary>
		/// <param name="tName">Nome della tabella principale</param>
		/// <param name="rSource">DataRow del foglio Excel</param>
		/// <returns></returns>
		private string costruisciFiltro(System.Data.DataTable tSortingKind, string tName, System.Data.DataRow rSource,
			out string sortField) {
			sortField = "";
			// Dati del tipo di Classificazione impostata in WAGEIMPORTSETUP per la tabella tName
			if ((tSortingKind == null) || (tSortingKind.Rows.Count == 0)) {
				return null;
			}

			DataRow rSorKind = tSortingKind.Rows[0];

			// Costruzione del filtro
			// Attenzione: Nella tabella SORTINGKIND possono essere valorizzati i campi da labels1 a labels5
			// Per ogni labels valorizzata il filtro sarà costruito sull'uguaglianza altrimenti sul NULL
			// Nella classificazione SPLITCONTR sono valorizzati i campi labels1..labels4
			// Il primo campo indica il codice della ritenuta e quindi viene saltato dal ciclo
			// Gli altri 3 campi (labels2..labels4) contengono le coordinate presenti sul foglio Excel
			int MAXLABEL = 4;
			string fS = "";
			for(int i = 2; i <= MAXLABEL; i++) {
				
				if (rSource.Table.Columns.Contains(rSorKind["labels" + i].ToString())) {
					sortField += "defaults" + i + ",";
					string colName = rSorKind["labels" + i].ToString();
					if (colName != "") {
                        fS = QHS.AppAnd(fS,QHS.NullOrEq("defaults" + i, rSource[colName]));
					}
					else {
						fS = QHS.AppAnd(QHS.IsNull("defaults" + i));
					}
				}
			}
			if (sortField != "") sortField = sortField.Substring(0,sortField.Length-1);

			// Il filtro prodotto sarà del tipo
			// (IDSORKIND = 'TIPOCLASSIFICAZIONE') AND ((DEFAULTS2 = 'AAA') OR (DEFAULTS2 IS NULL))
			// AND ((DEFAULTS3 = 'BBB') OR (DEFAULTS3 IS NULL)) AND (DEFAULTS4 IS NULL) etc.
			return fS;
		}
		/// <summary>
		/// Export all data in a datatable into an Excel sheet
		/// </summary>
		/// <param name="DT">DataTable to export</param>
		/// <param name="Header">true if headers have to be shown in Excel</param>
		public static void apriFile(System.Data.DataTable DT,bool Header) { 
			if(DT.Rows.Count==0)return;
            Microsoft.Office.Interop.Excel.Application m_objExcel;
			try {
				m_objExcel = new Microsoft.Office.Interop.Excel.Application();    
				m_objExcel.Visible = true;    
			}
			catch {
				MessageBox.Show( "Non è possibile eseguire l'esportazione in Excel. "+
					"Excel non è installato su questo computer o è presente una versione "+
					"non compatibile con l'oggetto COM: Microsoft Excel 9.0 Object Library",
					"Esportazione non riuscita");
				return;
			}
            Microsoft.Office.Interop.Excel.Workbook MyWorkbook = m_objExcel.Workbooks.Add(-4167); //Numero magico by Nino
            //Microsoft.Office.Interop.Excel.WorksheetClass Myworksheet = new Microsoft.Office.Interop.Excel.WorksheetClass();
            Microsoft.Office.Interop.Excel.Worksheet Myworksheet = (Microsoft.Office.Interop.Excel.Worksheet)MyWorkbook.Worksheets.get_Item(1);
			int RowCount = DT.Rows.Count; //Numero Righe del datatable
			int ColumnCount = DT.Columns.Count; //Numero Colonne del datatable
			int Step = 0;
			//Attento: Il Worksheet ha come base per le righe e colonne 1 (prima cella [1,1])
			//   Il Datatable ha come base 0. (prima cella [0,0])
			//Aggiungo i titoli delle colonne
			if(Header){
                Microsoft.Office.Interop.Excel.Range Head = (Microsoft.Office.Interop.Excel.Range)Myworksheet.Range[
					Myworksheet.Cells[1 ,1],
					Myworksheet.Cells[1,ColumnCount+1]];    
				Head.EntireRow.HorizontalAlignment= Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
				Head.EntireRow.Font.Bold = true;
				Step=1;

			}
			DataRow []Rows = DT.Select(null,
				(string) DT.ExtendedProperties["ExcelSort"]);
			//per ogni colonna del datatable:
			int Excel_Col_Index=0;
			for(int Colonna = 0; Colonna<ColumnCount; Colonna++) { 
				DataColumn Col= DT.Columns[Colonna];
				string caption = (string) Col.ExtendedProperties["ExcelTitle"];
				if (caption==null) caption= DT.Columns[Colonna].Caption;
				if (caption=="") continue;
				if ((Col.ExtendedProperties["ListColPos"]==null)&&
					(caption.StartsWith(".")))continue;

				int ColonnaExcel=Excel_Col_Index+1;
				if (Col.ExtendedProperties["ListColPos"]!=null) 
					ColonnaExcel= Convert.ToInt32(Col.ExtendedProperties["ListColPos"]);    
      
				if (ColonnaExcel==-1) continue;

				if (caption.StartsWith(".")) caption = caption.Remove(0,1);
				Excel_Col_Index++;

				if (Col.ExtendedProperties["ExcelFormat"]!=null){
					try {
                        Microsoft.Office.Interop.Excel.Range ExcCol = (Microsoft.Office.Interop.Excel.Range)Myworksheet.Range[
							Myworksheet.Cells[1+Step ,ColonnaExcel],
							Myworksheet.Cells[RowCount + Step,ColonnaExcel]];
						ExcCol.NumberFormat =  Col.ExtendedProperties["ExcelFormat"].ToString();
					}
					catch (Exception E) {
						MessageBox.Show(E.Message,"Errore");
					}
				}
				Object [,]arr;
				if (Header) {
					arr = new Object[RowCount+1,1];
					arr[0,0]= caption;
				}
				else 
					arr = new Object[RowCount,1];
				string Tag = "";
				Tag= HelpForm.CompleteTag(Tag,Col);
				for(int Riga = 0;Riga<RowCount;Riga++) {
					if (Rows[Riga][Colonna]==DBNull.Value){
						arr[Riga + Step,0]="";
						continue;
					}
					if (DT.Columns[Colonna].DataType==typeof(String)){
						arr[Riga + Step,0] =  "'"+HelpForm.StringValue(Rows[Riga][Colonna],Tag);
					}
					else {
						arr[Riga + Step,0] =  HelpForm.StringValue(Rows[Riga][Colonna],Tag);
					}
				}

				//Formatta le colonne del Worksheet e le giustifica:
				try{
                    Microsoft.Office.Interop.Excel.Range X = (Microsoft.Office.Interop.Excel.Range)Myworksheet.Range[
						Myworksheet.Cells[1 ,ColonnaExcel],
						Myworksheet.Cells[RowCount + Step,ColonnaExcel]];    
					X.Value2= arr;
					X.EntireColumn.AutoFit(); //Giustifica la colonna
				}
				catch (Exception E){
					MessageBox.Show(E.Message,"Errore");
				}
			}
   		}

        /// <summary>
        /// Metodo, associato al Click del bottone btnFileReversali, che avvia la procedura di generazione
        /// di un file Excel contenente le informazioni sulle trattenute sulle quali generare movimenti di entrata
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFileReversali_Click(object sender, EventArgs e) {
            if (!interrogaFileExcel("R")) {
                return;
            }

            if (!effettuaSplit("R")) {
                MessageBox.Show("Errore nello split delle colonne");
                return;
            }

            apriFile(tToExcel, true);
        }

        /// <summary>
        /// Metodo che, ricevuta in input una tabella di K colonne, di cui
        /// M sono definite fisse, N variabili ed S da scartare (quindi K = M + N + S), riempie una nuova tabella 
        /// dove per ogni riga della tabella di input verranno generate N righe nella tabella di output
        /// dove le colonne della tabella di output saranno M + 2
        /// dove le M sono le colonne fisse della tabella di input e le altre due colonne
        /// conterranno la prima il valore di ognuna delle N colonne della tabella di input
        /// e la seconda il nome di ognuna delle N colonne della tabella di input.
        /// Le due colonne si chiameranno IMPORTO e TIPORIT
        /// Esempio: Se ho la seguente riga in input
        /// PERCIPIENTE         LORDO RITFISC   RITPREV
        /// RUSCIANO GIUSEPPE   1000    30          40
        /// K = 4 di cui M = 1 (percipiente), N = 2 (ritfisc, ritprev), S = 1 (lordo)
        /// L'output sarà
        /// PERCIPIENTE         IMPORTO TIPORIT
        /// RUSCIANO GIUSEPPE       30  RITFISC
        /// RUSCIANO GIUSEPPE       40  RITPREV
        /// L'input del metodo è la tabella mData (che contiene i dati del file Excel)
        /// 
        /// Le colonne che dovranno essere presenti nella tabella di output devono essere:
        /// "RUOLO", "CAPITOLO", "COMPETENZA", "IMPORTO", "TIPORIT", "MATRICOLA"
        /// di cui "RUOLO", "CAPITOLO", "COMPETENZA", "MATRICOLA" devono anche essere presenti nella tabella di input
        /// e saranno le colonne fisse.
        /// </summary>
        /// <param name="tNewLayout">Par. di output - Tabella che verrà associata al file Excel</param>
        /// <returns></returns>
        private bool transformColumnInRow(out System.Data.DataTable tNewLayout) {
            tNewLayout = null;
            // Si seleziona il tipo di classificazione definito per il task corrente sulle ritenute
            string idsorkind = ottieniSortingKindPerTax();
            if (idsorkind == "") {
                MessageBox.Show(this, "Non è stata impostata la classificazione delle ritenute nella tabella di configurazione dell'importazione stipendi", "Errore");
                return false;
            }

            // Si definisce la query per estrarre i valori di defaults1 e defaults2 della classifazione sulle ritenute
            string q = "SELECT DISTINCT defaults1, defaults2 FROM sorting WHERE " + QHS.CmpEq("idsorkind", idsorkind);
            System.Data.DataTable tColCaption = Meta.Conn.SQLRunner(q);

            if (tColCaption == null) {
                MessageBox.Show(this, "Errore nella query per ricavare i nomi delle colonne delle ritenute");
                return false;
            }

            // Si definisce l'elenco delle colonne che devono essere presenti nella tabella che popolerà il file di Excel
            string[] elencoColonne = new string[] {"RUOLO", "CAPITOLO", "COMPETENZA", "IMPORTO", "TIPORIT", "MATRICOLA"};
            tNewLayout = creaTabellaConNuovoLayout(elencoColonne);

            // Si determinano quali sono le colonne "fisse", ossia quelle, data una riga della tabella iniziale,
            // che vengono ricopiate in tutte le righe della tabella di destinazione generate dalla medesima riga.
            string[] elencoColonneFisse = new string[] {"RUOLO", "CAPITOLO", "COMPETENZA", "MATRICOLA"};

            // Si cicla su tutte le ritenute trovate nella tabella della classificazione
            // in defaults1 deve essere presente il nome della colonna del file di input
            foreach (System.Data.DataRow rRiten in tColCaption.Rows) {
                foreach (System.Data.DataRow rData in mData.Rows) {
                    // Contenuto del campo defaults1
                    string nomeColonna = rRiten[0].ToString().ToUpper();
                    // Se la colonna non è presente nel file di input si passa al ciclo successivo
                    if ((rData[nomeColonna] == null) || (rData[nomeColonna] == DBNull.Value)) continue;
                    // Se presente si crea una nuova riga nelta tabella di output
                    System.Data.DataRow newRow = tNewLayout.NewRow();
                    // Tutte le colonne "fisse" sono ricopiate
                    foreach (string nCol in elencoColonneFisse) {
                        newRow[nCol] = rData[nCol];
                    }
                    // Si assegnano i valori nelle colonne IMPORTO e TIPORIT dove TIPORIT è il nome della colonna del
                    // file di input, importo è il valore presente in quella colonna per la riga corrente
                    newRow["IMPORTO"] = rData[nomeColonna];
                    newRow["TIPORIT"] = nomeColonna;
                    tNewLayout.Rows.Add(newRow);
                }
            }
            return true;
        }

        /// <summary>
        /// Metodo che ottiene l'id del tipo di classificazione associato alle ritenute nel task REVERSALI
        /// </summary>
        /// <returns></returns>
        private string ottieniSortingKindPerTax() {
            object idsorkind = Meta.Conn.DO_READ_VALUE("wageimportsetup", QHS.CmpEq("kind", 'R'), "idsorkind_tax");
            return ((idsorkind == null) || (idsorkind == DBNull.Value)) ? "" : idsorkind.ToString().ToUpper();
        }

        /// <summary>
        /// Metodo che per ogni nome colonna aggiunge una colonna alla tabella
        /// </summary>
        /// <param name="elencoColonne"></param>
        /// <returns></returns>
        private System.Data.DataTable creaTabellaConNuovoLayout(string[] elencoColonne) {
            System.Data.DataTable t = new System.Data.DataTable();
            foreach (string col in elencoColonne) {
                t.Columns.Add(col);
            }
            return t;
        }

        /// <summary>
        /// Metodo, associato al Click del bottone btnFileLordi, che avvia la procedura di generazione
        /// di un file Excel contenente le informazioni sui versamenti sulle quali generare movimenti di spesa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFileContr_Click(object sender, EventArgs e) {
            if (!interrogaFileExcel("V")) {
                return;
            }

            if (!effettuaSplit("V")) {
                MessageBox.Show("Errore nello split delle colonne");
                return;
            }

            apriFile(tToExcel, true);
        }

        /// <summary>
        /// Metodo che legge il file Excel ricevuto in input e ne valuta la validità in base al task scelto
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        private bool interrogaFileExcel(string task) {

            progressBar1.Minimum = 0;
            progressBar1.Value = 0;
            progressBar1.Maximum = 100;

            if (txtInputFile.Text == "") {
                MessageBox.Show("Non è stato scelto alcun file!");
                return false;
            }

            try {
                string fileName = openInputFileDlg.FileName;
                ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName +
                    ";Extended Properties=\"Excel 8.0;HDR=YES;\"";
                ReadCurrentSheet();
            }
            catch (Exception ex) {
                MessageBox.Show(this, "Errore nell'apertura del file! Processo Terminato\n" + ex.Message);
                return false;
            }

            if (!verificaValiditaFileExcel(task)) {
                MessageBox.Show(this, "Il file selezionato non è valido per il compito selezionato", "Errore");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Metodo che verifica la validità del file Excel ricevuto in input
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        private bool verificaValiditaFileExcel(string task) {
            ArrayList elencoColonne = new ArrayList();
            // La verifica di validità si basa sulla presenza di alcune colonne all'interno del file Excel.
            // L'insieme delle colonne varia a seconda del task che si vuol portare a termine
            switch (task) {
                case "L": {
                        elencoColonne.Add("RUOLO");
                        elencoColonne.Add("CAPITOLO");
                        elencoColonne.Add("COMPETENZA");
                        elencoColonne.Add("LORDO");
                        break;
                    }
                case "R": {
                        elencoColonne.Add("RUOLO");
                        elencoColonne.Add("CAPITOLO");
                        elencoColonne.Add("COMPETENZA");
                        break;
                    }
                case "V": {
                        elencoColonne.Add("ENTE");
                        elencoColonne.Add("VOCE");
                        elencoColonne.Add("RUOLO");
                        elencoColonne.Add("CAPITOLO");
                        elencoColonne.Add("COMPETENZA");
                        elencoColonne.Add("IMP_TOT");
                        break;
                    }
            }

            foreach (string col in elencoColonne) {
                if (!mData.Columns.Contains(col)) {
                    MessageBox.Show(this, "Nel file " + openInputFileDlg.FileName + " non esiste la colonna " + col, "Errore");
                    return false;
                }
            }
            return true;
        }
	}
}