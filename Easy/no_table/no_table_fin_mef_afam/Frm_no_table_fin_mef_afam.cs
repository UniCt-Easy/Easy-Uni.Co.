/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

using metadatalibrary;
using metaeasylibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace no_table_fin_mef_afam {
    public partial class Frm_no_table_fin_mef_afam : MetaDataForm {

        MetaData Meta;
        DataAccess Conn;
        QueryHelper QHS;
        CQueryHelper QHC;

        private Excel.Application xlApp;
        private Excel.Workbook wb;

        public Frm_no_table_fin_mef_afam() {
            InitializeComponent();
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            DataAccess.SetTableForReading(DS.sortingkind_c, "sortingkind");
            DataAccess.SetTableForReading(DS.sortingkind_p, "sortingkind");            
        }

        public void MetaData_AfterActivation()
        {
            object idsorMef = Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", "ENTI_MEF"), "idsorkind");

            txtEsercizio_c.Text = Meta.GetSys("esercizio").ToString();
            txtEsercizio_p.Text = Meta.GetSys("esercizio").ToString();

            if (idsorMef != null)
                BeginInvoke(new Action(() => {
                    cmbClassificazione_c.SelectedValue = idsorMef;
                    cmbClassificazione_p.SelectedValue = idsorMef;
                }));
        }

		private void btnElabora_c_Click(object sender, EventArgs e)
		{
            string esercizio = txtEsercizio_c.Text.ToString().Trim();
            string classificazione = cmbClassificazione_c.SelectedValue?.ToString().Trim();

            if (string.IsNullOrWhiteSpace(esercizio))
			{
                show("Il campo esercizio non può essere vuoto. Indicare l'esercizio di riferimento", "Errore");
                return;
			}

            if (string.IsNullOrWhiteSpace(classificazione))
            {
                show("Il campo classificazione non può essere vuoto. Indicare la classificazione di riferimento", "Errore");
                return;
            }

            string fileName = importaFileExcel();

            if (string.IsNullOrWhiteSpace(fileName)) return;

            fillExcel(fileName,
                "TOTALE GENERALE ENTRATE", 
                "TOTALE GENERALE USCITE", 
                "consuntivo_mef_afam", 
                new object[] {
                    esercizio,
                    classificazione
                });

            salvaFile(fileName);
        }

        private string importaFileExcel()
		{
            try
            {
                using (OpenFileDialog _openFileDialog = new OpenFileDialog())
                {
                    IOpenFileDialog openFileDialog = createOpenFileDialog(_openFileDialog);
                    openFileDialog.Filter = "File Excel|*.xlsx;*.xls";
                    openFileDialog.Title = "Seleziona file Excel";

                    if (openFileDialog.ShowDialog() != DialogResult.OK)
                    {
                        show("Non è stato scelto alcun file", "Errore");
                        return null;
                    }

                    string selectedFileName = openFileDialog.FileName;

                    // Validazione estensione file
                    string extension = Path.GetExtension(selectedFileName)?.ToLower();
                    if (string.IsNullOrEmpty(extension) ||
                        !(extension.Equals(".xlsx") || extension.Equals(".xls")))
                    {
                        show("File non valido! Selezionare un file excel (*.xlsx, *.xls)", "Errore");
                        return null;
                    }

                    return selectedFileName;
                }
            }
            catch (Exception ex)
            {
                show($"Errore durante l'importazione: {ex.Message}", "Errore");
                return null;
            }
        }

        private void fillExcel(string fileName, string startEntrate, string startUscite, string spName, object[] paramSp)
		{
            if (string.IsNullOrEmpty(fileName))
                return;

            Cursor.Current = Cursors.WaitCursor;

            xlApp = new Excel.Application();
            xlApp.DisplayAlerts = false;

            try
            {
                wb = xlApp.Workbooks.Open(fileName);
                wb.CheckCompatibility = false;

                Excel.Worksheet ws = null;

                // Recupero i dati dalla stored
                DataSet ds = conn.CallSP(spName, paramSp, 0, out string error);

                if (!string.IsNullOrEmpty(error))
                {
                    show(error, "Errore");
                    return;
                }

                if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                {
                    show("Non ci sono dati da poter inserire nel file", "Errore");
                    return;
                }

                DataTable dt = ds.Tables[0];

                var fogli = dt.AsEnumerable().GroupBy(row => row.Field<string>("foglio"));

                foreach (var foglio in fogli)
				{
                    string nomeFoglio = foglio.Key;

                    ws = wb.Sheets[nomeFoglio];

                    if (ws == null)
                    {
                        show($"Foglio {nomeFoglio} non trovato.", "Errore");
                        return;
                    }

                    if (nomeFoglio == "Bilancio finanziario")
                        compilaFoglio(ws, foglio, startEntrate, startUscite);
                    else
                        compilaFoglio(ws, foglio);

                }
            }
            catch (Exception)
            {
                wb.Close();
                xlApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wb);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
            }
            finally
			{
                Cursor.Current = Cursors.Default;
            }
        }

        private void compilaFoglio(Excel.Worksheet ws, IGrouping<string, DataRow> datiFoglio, string startEntrate = null, string startUscite = null)
		{
            string campo = "";
            string movkind = "";
            List<Excel.Range> trovati = null;

            string nonTrovati = "";

            var hashSet = new HashSet<string>();

            // Cella che indica l'inizio della sezione delle entrate
            Excel.Range entrateCell = null;

            if (startEntrate != null)
                entrateCell = ws.Cells.Find(
                    What: startEntrate,
                    LookAt: Excel.XlLookAt.xlPart,
                    LookIn: Excel.XlFindLookIn.xlValues,
                    MatchCase: false
                );

            // Cella che indica l'inizio della sezione delle uscite
            Excel.Range usciteCell = null;

            if (startUscite != null)
                usciteCell = ws.Cells.Find(
                    What: startUscite,
                    LookAt: Excel.XlLookAt.xlPart,
                    LookIn: Excel.XlFindLookIn.xlValues,
                    MatchCase: false
                );

            foreach (DataRow row in datiFoglio)
            {
                // colonna vale B, C, D, ecc.
                string colonna = row["colonna"].ToString();
                decimal valore = Convert.ToDecimal(row["valore"]);
                // movkind vale E o S
                string tempmovkind = row["movkind"].ToString();

                string tempCampo = row["classificazione"].ToString();

                // Se la classificazione e il tipo di movimento sono gli stessi non deve fare di nuovo la ricerca nel file,
                // ma deve inserire gli altri valori nella stessa riga in una diversa colonna
                if (tempCampo != campo || tempmovkind != movkind)
                {
                    campo = tempCampo;
                    movkind = tempmovkind;

                    trovati = trovaTutteOccorrenze(ws, campo, entrateCell, usciteCell, movkind == "S");
                }

                if (trovati != null)
                {
                    foreach (Excel.Range cell in trovati)
                    {
                        int riga = cell.Row;

                        Excel.Range editCell = ws.Range[$"{colonna}{riga}"];

                        if (!editCell.Locked)
                            editCell.Value = valore;
                    }
                }
            }

            nonTrovati = string.Join(Environment.NewLine, hashSet);

            if (!string.IsNullOrEmpty(nonTrovati))
                show(nonTrovati);
        }

        /// <summary>
        /// Metodo per trovare tutte le occorenze di una classificazione all'interno della sezione di riferimento (entrate/uscite).
        /// Il metodo di ricerca è xlPart, ovvero trova tutte le celle che contengono il testo cercato, questo perché
        /// ci sono celle che contengono spazi alla fine, e una ricerca con xlWhole non le troverebbe.
        /// Inoltre ci possono essere più righe con lo stesso nome della classificazione, di cui una contenente formule e l'altra editabile.
        /// </summary>
        /// <param name="ws"></param>
        /// <param name="classificazione"></param>
        /// <param name="entrateCell"></param>
        /// <param name="usciteCell"></param>
        /// <param name="uscite"></param>
        /// <returns></returns>
        public List<Excel.Range> trovaTutteOccorrenze(Excel.Worksheet ws, string classificazione, Excel.Range entrateCell, Excel.Range usciteCell, bool uscite)
        {
            var risultati = new List<Excel.Range>();

            if (entrateCell == null && usciteCell == null)
            {
                Excel.Range trovato = ws.Cells.Find(
                    What: classificazione,
                    LookAt: Excel.XlLookAt.xlPart,
                    LookIn: Excel.XlFindLookIn.xlValues,
                    MatchCase: false
                );

                if (trovato != null)
                    risultati.Add(trovato);
            }
            else
            {
                // Prima ricerca
                Excel.Range trovato = ws.Cells.Find(
                    What: classificazione,
                    After: uscite ? usciteCell : entrateCell,
                    LookAt: Excel.XlLookAt.xlPart,
                    LookIn: Excel.XlFindLookIn.xlValues,
                    MatchCase: false
                );

                if (trovato != null)
                {
                    string primaIndirizzo = trovato.Address;
                    risultati.Add(trovato);

                    // Continua a cercare fino a tornare alla prima cella
                    while (true)
                    {
                        trovato = ws.Cells.FindNext(trovato);
                        if (trovato != null && trovato.Address != primaIndirizzo)
                        {
                            // Verifica che la cella trovata sia nella sezione corretta (entrate/uscite) e che il contenuto della cella corrisponda alla classificazione
                            if (((uscite && trovato.Row > usciteCell.Row) || (!uscite && trovato.Row < usciteCell.Row))
                                && trovato.Value.ToString().Trim().ToLower().Equals(classificazione.Trim().ToLower()))
                            {
                                risultati.Add(trovato);
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            return risultati;
        }

		private void salvaFile(string fileName)
		{
            if (string.IsNullOrWhiteSpace(fileName) || wb == null)
                return;

            // Salva con un nuovo nome
            string directory = Path.GetDirectoryName(fileName);
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
            string extension = Path.GetExtension(fileName);
            string newFileName = Path.Combine(directory, fileNameWithoutExtension + extension);
            try
            {
                if (extension == ".xls")
                {
                    wb.SaveAs(newFileName, FileFormat: Excel.XlFileFormat.xlExcel8,
                       ConflictResolution: Excel.XlSaveConflictResolution.xlLocalSessionChanges);
                }
                else
                {
                    wb.SaveAs(newFileName);
                }
                
                // Salva il file attuale
                //wb.Save();                             
            }
            catch { }
            finally {
                wb.Close();
                xlApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wb);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
            }

            runProcess(newFileName, true);

            show("File salvato con successo!", "Operazione completata");
        }

        private void btnElabora_p_Click(object sender, EventArgs e)
        {
            string esercizio = txtEsercizio_p.Text.ToString().Trim();
            string classificazione = cmbClassificazione_p.SelectedValue?.ToString().Trim();

            if (string.IsNullOrWhiteSpace(esercizio))
            {
                show("Il campo esercizio non può essere vuoto. Indicare l'esercizio di riferimento", "Errore");
                return;
            }

            if (string.IsNullOrWhiteSpace(classificazione))
            {
                show("Il campo classificazione non può essere vuoto. Indicare la classificazione di riferimento", "Errore");
                return;
            }

            string fileName = importaFileExcel();

            if (string.IsNullOrWhiteSpace(fileName)) return;

            fillExcel(fileName,
                "TOTALE GENERALE ENTRATE",
                "TOTALE GENERALE USCITE",
                "preventivo_mef_afam",
                new object[] {
                    esercizio,
                    classificazione
                });

            salvaFile(fileName);
        }
    }
}
