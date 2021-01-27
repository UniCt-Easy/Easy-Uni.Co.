
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;
using System.Collections;
using System.Data.OleDb;
using System.IO;
using System.Globalization;
using System.Threading;


namespace no_table_f24ep {
    
    public partial class Frmf24ep : Form {

        CQueryHelper QHC;
        QueryHelper QHS;
        MetaData Meta;
        DataAccess Conn;
        CultureInfo cultureInfo = CultureInfo.GetCultureInfo(0x0410);


        public Frmf24ep() {
            InitializeComponent();
            string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "f24ep/prog/temp");
            if (Directory.Exists(dir))
            {
                saveOutputFileDlg.InitialDirectory = dir;
            }
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            Conn = Meta.Conn;
            string filterEsercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.CacheTable(DS.license);
            GetData.CacheTable(DS.config, filterEsercizio, null, false);
            Meta.CanCancel = false;
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanSave = false;
            Meta.SearchEnabled = false;

            DataTable tConfig = Conn.CreateTableByName("config", "*");
            Conn.RUN_SELECT_INTO_TABLE(tConfig, null, filterEsercizio, null, true);

            DataTable tLicense = Conn.CreateTableByName("license", "*");
            Conn.RUN_SELECT_INTO_TABLE(tLicense, null, null, null, true);

            txtCodiceFiscale.Text = tLicense.Rows[0]["cf"].ToString();
            txtDenominazione.Text = tLicense.Rows[0]["agency"].ToString();
            object iban = tConfig.Rows[0]["iban_f24"];
            object email_f24 = tConfig.Rows[0]["email_f24"];
            txtContoDiAddebito.Text = CfgFn.normalizzaIBAN(iban.ToString().ToUpper());
            txtEmail.Text = email_f24.ToString();
            txtDataDiVersamento.Text = ((DateTime)Meta.GetSys("datacontabile")).ToShortDateString();
            addColumnDati(mData);
            fillTributi(tributi);
            btnFileInput.ContextMenu = CMenu;
        }


          private void addColumnDati (DataTable tExcel) {
            tExcel.Columns.Add("tiporiga", typeof(string));
            tExcel.Columns.Add("estremi", typeof(string));
            tExcel.Columns.Add("codicetributo", typeof(string));
            tExcel.Columns.Add("codice", typeof(string));
            tExcel.Columns.Add("riferimentoA", typeof(string));
            tExcel.Columns.Add("riferimentoB", typeof(string));
            tExcel.Columns.Add("importoadebito", typeof(decimal));
            tExcel.Columns.Add("importoacredito", typeof(decimal));
        }

        private void fillTributi(DataTable T)
        {
           
            T.Columns.Add("tiporiga", typeof(string));
            T.Columns.Add("cod_tributo", typeof(string));
            T.Columns.Add("tipoente", typeof(string));
            T.Columns.Add("rifA", typeof(string));
            T.Columns.Add("rifB", typeof(string));
           
            DataRow dr;

            dr = T.NewRow();
            dr["tiporiga"] = "S";
            dr["cod_tributo"] = "384E";
            dr["tipoente"] = "CCCC";
            dr["rifA"] = "00MM";
            dr["rifB"] = "AAAA";
            T.Rows.Add(dr);

            dr = T.NewRow();
            dr["tiporiga"] = "S";
            dr["cod_tributo"] = "127E";
            dr["tipoente"] = "CCCC";
            dr["rifA"] = "00MM";
            dr["rifB"] = "AAAA";
            T.Rows.Add(dr);

            dr = T.NewRow();
            dr["tiporiga"] = "S";
            dr["cod_tributo"] = "128E";
            dr["tipoente"] = "CCCC";
            dr["rifA"] = "00MM";
            dr["rifB"] = "AAAA";
            T.Rows.Add(dr);

            dr = T.NewRow();
            dr["tiporiga"] = "S";
            dr["cod_tributo"] = "385E";
            dr["tipoente"] = "CCCC";
            dr["rifA"] = "00MM";
            dr["rifB"] = "AAAA";
            T.Rows.Add(dr);

            dr = T.NewRow();
            dr["tiporiga"] = "R";
            dr["cod_tributo"] = "381E";
            dr["tipoente"] = "RR";
            dr["rifA"] = "00MM";
            dr["rifB"] = "AAAA";
			T.Rows.Add(dr);

			////////////////////////////////////////////////////////////////

			dr = T.NewRow(); // SOMME A TITOLO DI  ADDIZIONALE REGIONALE  ALL'IRPEF RIMBORSATE DAL SOSTITUTO D'IMPOSTA A SEGUITO DI ASSISTENZA FISCALE
			dr["tiporiga"] = "R";
			dr["cod_tributo"] = "153E";
			dr["tipoente"] = "RR";
			dr["rifA"] = DBNull.Value;
			dr["rifB"] = "AAAA";
			T.Rows.Add(dr);

			dr = T.NewRow(); // ECCEDENZA DI  VERSAMENTI DI  ADDIZIONALE REGIONALE  ALL'IRPEF TRATTENUTA  DAL SOSTITUTO D'IMPOSTA
			dr["tiporiga"] = "R";
			dr["cod_tributo"] = "160E";
			dr["tipoente"] = "RR";
			dr["rifA"] = DBNull.Value;
			dr["rifB"] = "AAAA";
			T.Rows.Add(dr);

			dr = T.NewRow(); // ADDIZIONALE REGIONALE   ALL'IRPEF TRATTENUTA   DAL SOSTITUTO D'IMPOSTA   A SEGUITO DI ASSISTENZA   FISCALE
			dr["tiporiga"] = "R";
			dr["cod_tributo"] = "126E";
			dr["tipoente"] = "RR";
			dr["rifA"] = "00MM";
			dr["rifB"] = "AAAA";
			T.Rows.Add(dr);

			dr = T.NewRow(); // SOMME A TITOLO DI    ADDIZIONALE COMUNALE  ALL'IRPEF RIMBORSATE  DAL SOSTITUTO D'IMPOSTA   A SEGUITO DI ASSISTENZA FISCALE
			dr["tiporiga"] = "S";
			dr["cod_tributo"] = "154E";
			dr["tipoente"] = "CCCC";
			dr["rifA"] = DBNull.Value;
			dr["rifB"] = "AAAA";
			T.Rows.Add(dr);

			dr = T.NewRow();  // ECCEDENZA DI  VERSAMENTI DI   ADDIZIONALE COMUNALE  ALL'IRPEF TRATTENUTA  DAL SOSTITUTO D'IMPOSTA
			dr["tiporiga"] = "S";
			dr["cod_tributo"] = "161E";
			dr["tipoente"] = "CCCC";
			dr["rifA"] = DBNull.Value;
			dr["rifB"] = "AAAA";
			T.Rows.Add(dr);
			
			dr = T.NewRow();  //VERSAMENTO IVA MENSILE GENNAIO
			dr["tiporiga"] = "F";
			dr["cod_tributo"] = "601E";
			dr["tipoente"] = DBNull.Value;
			dr["rifA"] = DBNull.Value;
			dr["rifB"] = "AAAA";
			T.Rows.Add(dr);

			dr = T.NewRow(); //VERSAMENTO IVA MENSILE FEBBRAIO
			dr["tiporiga"] = "F";
			dr["cod_tributo"] = "602E";
			dr["tipoente"] = DBNull.Value;
			dr["rifA"] = DBNull.Value;
			dr["rifB"] = "AAAA";
			T.Rows.Add(dr);

			dr = T.NewRow(); //VERSAMENTO IVA MENSILE MARZO
			dr["tiporiga"] = "F";
			dr["cod_tributo"] = "603E";
			dr["tipoente"] = DBNull.Value;
			dr["rifA"] = DBNull.Value;
			dr["rifB"] = "AAAA";
			T.Rows.Add(dr);

			dr = T.NewRow(); //VERSAMENTO IVA MENSILE APRILE
			dr["tiporiga"] = "F";
			dr["cod_tributo"] = "604E";
			dr["tipoente"] = DBNull.Value;
			dr["rifA"] = DBNull.Value;
			dr["rifB"] = "AAAA";
			T.Rows.Add(dr);

			dr = T.NewRow(); //VERSAMENTO IVA MENSILE MAGGIO
			dr["tiporiga"] = "F";
			dr["cod_tributo"] = "605E";
			dr["tipoente"] = DBNull.Value;
			dr["rifA"] = DBNull.Value;
			dr["rifB"] = "AAAA";
			T.Rows.Add(dr);

			dr = T.NewRow(); //VERSAMENTO IVA MENSILE GIUGNO
			dr["tiporiga"] = "F";
			dr["cod_tributo"] = "606E";
			dr["tipoente"] = DBNull.Value;
			dr["rifA"] = DBNull.Value;
			dr["rifB"] = "AAAA";
			T.Rows.Add(dr);

			dr = T.NewRow(); //VERSAMENTO IVA MENSILE LUGLIO
			dr["tiporiga"] = "F";
			dr["cod_tributo"] = "607E";
			dr["tipoente"] = DBNull.Value;
			dr["rifA"] = DBNull.Value;
			dr["rifB"] = "AAAA";
			T.Rows.Add(dr);

			dr = T.NewRow(); //VERSAMENTO IVA MENSILE AGOSTO
			dr["tiporiga"] = "F";
			dr["cod_tributo"] = "608E";
			dr["tipoente"] = DBNull.Value;
			dr["rifA"] = DBNull.Value;
			dr["rifB"] = "AAAA";
			T.Rows.Add(dr);

			dr = T.NewRow(); //VERSAMENTO IVA MENSILE SETTEMBRE
			dr["tiporiga"] = "F";
			dr["cod_tributo"] = "609E";
			dr["tipoente"] = DBNull.Value;
			dr["rifA"] = DBNull.Value;
			dr["rifB"] = "AAAA";
			T.Rows.Add(dr);

			dr = T.NewRow(); //VERSAMENTO IVA MENSILE OTTOBRE
			dr["tiporiga"] = "F";
			dr["cod_tributo"] = "610E";
			dr["tipoente"] = DBNull.Value;
			dr["rifA"] = DBNull.Value;
			dr["rifB"] = "AAAA";
			T.Rows.Add(dr);

			dr = T.NewRow(); //VERSAMENTO IVA MENSILE NOVEMBRE
			dr["tiporiga"] = "F";
			dr["cod_tributo"] = "611E";
			dr["tipoente"] = DBNull.Value;
			dr["rifA"] = DBNull.Value;
			dr["rifB"] = "AAAA";
			T.Rows.Add(dr);

			dr = T.NewRow(); //VERSAMENTO IVA MENSILE DICEMBRE
			dr["tiporiga"] = "F";
			dr["cod_tributo"] = "612E";
			dr["tipoente"] = DBNull.Value;
			dr["rifA"] = DBNull.Value;
			dr["rifB"] = "AAAA";
			T.Rows.Add(dr);

			dr = T.NewRow();   // VERSAMENTO ACCONTO PER IVA MENSILE
			dr["tiporiga"] = "F";
			dr["cod_tributo"] = "613E";
			dr["tipoente"] = DBNull.Value;
			dr["rifA"] = DBNull.Value;
			dr["rifB"] = "AAAA";
			T.Rows.Add(dr);

			dr = T.NewRow();  // VERSAMENTO IVA TRIMESTRALE 1 TRIMESTRE
			dr["tiporiga"] = "F";
			dr["cod_tributo"] = "614E";
			dr["tipoente"] = DBNull.Value;
			dr["rifA"] = DBNull.Value;
			dr["rifB"] = "AAAA";
			T.Rows.Add(dr);

			dr = T.NewRow(); // VERSAMENTO IVA TRIMESTRALE 2 TRIMESTRE
			dr["tiporiga"] = "F";
			dr["cod_tributo"] = "615E";
			dr["tipoente"] = DBNull.Value;
			dr["rifA"] = DBNull.Value;
			dr["rifB"] = "AAAA";
			T.Rows.Add(dr);

			dr = T.NewRow(); // VERSAMENTO IVA TRIMESTRALE 3 TRIMESTRE
			dr["tiporiga"] = "F";
			dr["cod_tributo"] = "616E";
			dr["tipoente"] = DBNull.Value;
			dr["rifA"] = DBNull.Value;
			dr["rifB"] = "AAAA";
			T.Rows.Add(dr);

			dr = T.NewRow(); // VERSAMENTO IVA TRIMESTRALE 4 TRIMESTRE
			dr["tiporiga"] = "F";
			dr["cod_tributo"] = "617E";
			dr["tipoente"] = DBNull.Value;
			dr["rifA"] = DBNull.Value;
			dr["rifB"] = "AAAA";
			T.Rows.Add(dr);

			dr = T.NewRow(); // VERSAMENTO IVA ACCONTO  
			dr["tiporiga"] = "F";
			dr["cod_tributo"] = "618E";
			dr["tipoente"] = DBNull.Value;
			dr["rifA"] = DBNull.Value;
			dr["rifB"] = "AAAA";
			T.Rows.Add(dr);

			dr = T.NewRow(); // VERSAMENTO IVA SULLA BASE DELLA DICHIARAZIONE ANNUALE
			dr["tiporiga"] = "F";
			dr["cod_tributo"] = "619E";
			dr["tipoente"] = DBNull.Value;
			dr["rifA"] = DBNull.Value;
			dr["rifB"] = "AAAA";
			T.Rows.Add(dr);

			dr = T.NewRow(); // SPLIT ISTITUZIONALE
			dr["tiporiga"] = "F";
			dr["cod_tributo"] = "620E";
			dr["tipoente"] = DBNull.Value;
			dr["rifA"] = "00MM";
			dr["rifB"] = "AAAA";
			T.Rows.Add(dr);

			dr = T.NewRow(); // SPLIT COMMERCIALE
			dr["tiporiga"] = "F";
			dr["cod_tributo"] = "621E";
			dr["tipoente"] = DBNull.Value;
			dr["rifA"] = "00MM";
			dr["rifB"] = "AAAA";
			T.Rows.Add(dr);

			dr = T.NewRow(); // INTRA 12
			dr["tiporiga"] = "F";
			dr["cod_tributo"] = "622E";
			dr["tipoente"] = DBNull.Value;
			dr["rifA"] = "00MM";
			dr["rifB"] = "AAAA";
			T.Rows.Add(dr);

			dr = T.NewRow(); // SANZIONE PECUNIARIA IVA
			dr["tiporiga"] = "F";
			dr["cod_tributo"] = "801E";
			dr["tipoente"] = DBNull.Value;
			dr["rifA"] = "00MM";
			dr["rifB"] = "AAAA";
			T.Rows.Add(dr);

			dr = T.NewRow(); //	REGOLARIZZAZIONE OPERAZIONI SOGGETTE AD IVA IN CASO DI MANCATA/ IRREGOLARE FATTURAZ.
			dr["tiporiga"] = "F";
			dr["cod_tributo"] = "901E";
			dr["tipoente"] = DBNull.Value;
			dr["rifA"] = "00MM";
			dr["rifB"] = "AAAA";
			T.Rows.Add(dr);
		}



		private void btnFileInput_Click(object sender, EventArgs e)
        {
            if (!LeggiFile())
            {
                return;
            }
        }

       
        private bool LeggiFile()
        {
            DialogResult dr = openInputFileDlg.ShowDialog();
            if (dr != DialogResult.OK)
            {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Non è stato scelto alcun file");
                txtInputFile.Text = "";
                return false;
            }
            fileName = openInputFileDlg.FileName;

            if (fileName.EndsWith("xls") || fileName.EndsWith("xlsx"))
            {

                try
                {
                    mData.Clear();
                    //ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName +
                    //    ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";
                    ReadCurrentSheet();
                    txtInputFile.Text = fileName;
                }
                catch (Exception ex)
                {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Errore nell'apertura del file! Processo Terminato\n" + ex.Message);
                    return false;
                }
            }

            Meta.FreshForm();
            return true;
        }


        
        
        
        object misValue = System.Reflection.Missing.Value;

        private void ReadCurrentSheet()
        {
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            //m_objExcel.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            try {
                xlWorkBook = xlApp.Workbooks.Open(fileName, 0,
                    false /* impostare a false se non è readonly */ ,
                    5, 
                    "", "", true, 
                    Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, 
                    "\t", //delimiter
                    false, //editable
                    false,  //Notify
                    0, true, 1, 0);
            }
            catch (Exception E) {
                QueryCreator.ShowException(this, "Errore nell'apertura del file " + fileName, E);
                return;
            }
            try {
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            }
            catch (Exception E) {
                QueryCreator.ShowException(this, "Errore nella lettura del primo elemento del file excel " , E);
                return;
            }

          
            bool ok=true;
            try {
                ok = ExcelGetSheet(xlWorkSheet);  // bisogna salvare i dati
            }
            catch (Exception E) {
                QueryCreator.ShowException(this, "Errore nella elaborazione del file excel ", E);
                return;
            }

            try {
                xlWorkBook.Close(true, misValue, misValue);
            }
            catch (Exception E) {
                QueryCreator.ShowException(this, "Errore nel salvataggio del file excel ", E);
                return;
            }

            try {
                xlApp.Quit();
            }
            catch (Exception E) {
                QueryCreator.ShowException(this, "Errore nell'uscita dall'applicazioneexcel ", E);
                return;
            }

            try {
                releaseObject(xlApp);
                releaseObject(xlWorkBook);
                releaseObject(xlWorkSheet);
            }
            catch (Exception E) {
                QueryCreator.ShowException(this, "Errore nel rilascio delle risorse excel ", E);
                return;
            }





            if (ok)
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Il File " + fileName + " è stato importato. Si può procedere con la generazione del modello F24EP");
            else
            {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "L'esame del file " + fileName + " ha fatto rilevare degli errori");
                mData.Clear();
            }
        }

        string[] tracciato_f24 =
               new string[]{
                        "cod_tributo;Codice Tributo;Stringa",
                        "comune_regione;Denominazione comune;Stringa",
                        "sigla_prov;Sigla Provincia;Stringa",
                        "cod_catastale;Codice catastale comune;Stringa",
			            "anno_rif; Anno di riferimento;Numero",
			            "mese_rif; Mese di Riferimento;Numero",
                        "importoadebito;Importo a Debito;Numero",
                        "importoacredito;Importo a Credito;Numero",
                        "errore;Messaggio di errore;Stringa" };


        public string GetTracciato(string[] tracciato) {
                string res = "";
                int pos = 0;
                foreach (string t in tracciato) {
                string[] ss = t.Split(';');
                string field = ss[0].PadLeft(30) + ": Pos." + pos.ToString().PadLeft(5) + " lunghezza " +
                               ss[3].PadLeft(4) +
                               " Tipo: " + ss[2].PadLeft(15);
                if (ss[2].ToLower() == "codificato") {
                field += " Codifica:" + ss[4];
                }
                field += " Descrizione: " + ss[1];
                field += "\r\n";
                pos += CfgFn.GetNoNullInt32(ss[3]);
                res += field;
                }
                return res;
        }

        public DataTable GetTableTracciato(string[] tracciato) {
            int pos = 0;
            DataTable T = new DataTable("t");
            T.Columns.Add("nome", typeof(string));
                        T.Columns.Add("Descrizione", typeof(string));
            //T.Columns.Add("posizione", typeof(int));
            //T.Columns.Add("lunghezza", typeof(string));
            T.Columns.Add("tipo", typeof(string));
            //T.Columns.Add("codifica", typeof(string));


            foreach (string t in tracciato) {
                DataRow r = T.NewRow();
                string[] ss = t.Split(';');
                r["nome"] = ss[0];
                r["tipo"] = ss[2];
     
                r["Descrizione"] = ss[1];
                T.Rows.Add(r);
            }
            return T;
        }
      

       private void MenuEnterPwd_Click(object sender, EventArgs e) {
			if (sender == null) return;
			if (!(typeof(MenuItem).IsAssignableFrom(sender.GetType()))) return;
			object mysender = ((MenuItem) sender).Parent.GetContextMenu().SourceControl;
			string[] tracciato = tracciato_f24;
			DataTable TableTracciato = null;
 
			TableTracciato = GetTableTracciato(tracciato_f24);
		
			FrmShowTracciato FT = new FrmShowTracciato("tracciato_f24", TableTracciato, "struttura");
			FT.ShowDialog();

		}

	 

        string ExcelColumnFromNumber(int column)
        {
            try {
                string columnString = "";
                int columnNumber = column;
                while (columnNumber > 0) {
                    int currentLetterNumber = (columnNumber - 1) % 26;
                    char currentLetter = (char)(currentLetterNumber + 65);
                    columnString = currentLetter + columnString;
                    columnNumber = (columnNumber - (currentLetterNumber + 1)) / 26;
                }
                return columnString;
            }
            catch (Exception E) {
                QueryCreator.ShowException(this, "Errore convertendo in riferimento a colonna un numero",E);
                return "Z";
            }
        }

        int NumberFromExcelColumn(string column)
        {
            try {
                int retVal = 0;
                string col = column.ToUpper();
                for (int iChar = col.Length - 1; iChar >= 0; iChar--) {
                    char colPiece = col[iChar];
                    int colNum = colPiece - 64;
                    retVal = retVal + colNum * (int)Math.Pow(26, col.Length - (iChar + 1));
                }
                return retVal;
            }
            catch (Exception E) {
                QueryCreator.ShowException(this, "Errore convertendo numero un riferimento a colonna",E);
                return 20;
            }

        }


        object ExcelGetField(Microsoft.Office.Interop.Excel.Range Cell, string tracciato_field, out string errore) {
            errore = "";
            object val= Cell.get_Value(Microsoft.Office.Interop.Excel.XlRangeValueDataType.xlRangeValueDefault);
            object val2= Cell.Value2;

            string[] ff = tracciato_field.Split(';');
            string fieldname = ff[0];
            string ftype = ff[2].ToLower().Trim(); //(intero/numero/stringa/codificato/data)

            errore = "";
            //int len = Convert.ToInt32(ff[3]);
            if (val == null) return DBNull.Value;
            if (val == DBNull.Value) return val;
            if (val.ToString() == "") return DBNull.Value;
            decimal numero;
            try {
                switch (ftype) {
                    case "intero": {
                            string X = val.ToString().Trim().TrimStart('0');
                            if (X == "") return 0;
                            return Convert.ToInt32(X);
                        }
                    case "stringa":
                        return val.ToString().TrimEnd(new char[] { ' ' });
                    case "numero":
                        if (isNumeric(val, out numero))
                            return Convert.ToDecimal(numero);
                        else {
                            errore = " Errore interno nel tracciato per tipo numerico " + fieldname + " di tipo " + ftype + " e di valore " +
                                val.ToString().Trim().TrimStart('0');
                            return null;
                        }
                    case "data":  // DateTime.FromOADate and DateTime.ToOADate
                        return DateTime.FromOADate(Convert.ToDouble(val2));
                    case "codificato": {
                            string[] codici = ff[4].Split('|');
                            for (int i = 0; i < codici.Length; i++) {
                                if (val.ToString().ToLower() == codici[i].ToLower()) return val;
                            }
                            errore = " Errore interno nel tracciato per tipo codificato " + fieldname + " di tipo " + ftype + " e di valore " +
                               val.ToString().Trim().TrimStart('0');
                            return null;
                        }
                    default: {
                            errore = " Errore interno nel tracciato per tipo " + ftype + " e valore " + val.ToString().Trim().TrimStart('0');
                            return null;
                        }
                }
            }
            catch {
                errore = " Errore nella decodifica del campo " + fieldname + " di tipo " + ftype + " e di valore " + val.ToString().Trim().TrimStart('0');
                return null;
            }

        }




        /// <summary>
        /// Prende un valore dal foglio di excel, le riga partono da 1 e le colonne partono da 1
        /// </summary>
        /// <param name="riga"></param>
        /// <param name="colonna"></param>
        /// <returns></returns>
        object GetVal(Microsoft.Office.Interop.Excel.Worksheet xl, int riga, int colonna, out string errore) {
            int ntryh = 0;
            Microsoft.Office.Interop.Excel.Range Cell;
            while (true) {
                ntryh++;
                try {
                    Cell = xl.Range[ExcelColumnFromNumber(colonna) + riga,
                        ExcelColumnFromNumber(colonna) + riga];
                    break;
                }
                catch (Exception E) {
                    if (ntryh == 10) throw E;
                    Thread.Sleep(100 * ntryh);

                }
            }

             
            string fmt = tracciato_f24[colonna-1];
            return ExcelGetField(Cell, fmt,  out errore);
        }


        bool ExcelGetSheet(Microsoft.Office.Interop.Excel.Worksheet w) {
            bool ok = true;
            int ColumnCount = 0;
            int RowCount = 0;

            try {
                ColumnCount = w.UsedRange.Columns.Count;
                RowCount = w.UsedRange.Rows.Count;
            }
            catch (Exception E) {
                QueryCreator.ShowException(this, "Errore nella rilevazione dell'area usata", E);
                return false;
            }
            int nrigacorrente = 2;
            while (true) { // escludo l'intestazione
                string lastcol = ExcelColumnFromNumber(tracciato_f24.Length);
                string row = nrigacorrente.ToString();
                string errore = "";
                string err = "";
                object o_cod_tributo = null, o_sigla_prov = null, o_cod_catastale = null, o_anno_rif = null, o_mese_rif = null,
                            o_importoadebito = null, o_importoacredito = null, o_codice_regione = null, denom = null;
                o_cod_tributo = GetVal(w,nrigacorrente, 1, out errore); if (errore != "") err = err + " " + errore;
                if (o_cod_tributo == DBNull.Value) break;

                denom = GetVal(w, nrigacorrente, 2, out errore); if (errore != "") err = err + " " + errore;
                o_sigla_prov = GetVal(w, nrigacorrente, 3, out errore); if (errore != "") err = err + " " + errore;
                o_cod_catastale = GetVal(w, nrigacorrente, 4, out errore); if (errore != "") err = err + " " + errore;
                o_anno_rif = GetVal(w, nrigacorrente, 5, out errore); if (errore != "") err = err + " " + errore;
                o_mese_rif = GetVal(w, nrigacorrente, 6, out errore); if (errore != "") err = err + " " + errore;
                o_importoadebito = GetVal(w, nrigacorrente, 7, out errore); if (errore != "") err = err + " " + errore;
                o_importoacredito = GetVal(w, nrigacorrente, 8, out errore); if (errore != "") err = err + " " + errore;
                o_codice_regione = "";

                string cod_tributo = ""; if (o_cod_tributo != null) cod_tributo = o_cod_tributo.ToString();
                string sigla_prov = ""; if (o_sigla_prov != null) sigla_prov = o_sigla_prov.ToString();
                string cod_catastale = ""; if (o_cod_catastale != null) cod_catastale = o_cod_catastale.ToString();

                Microsoft.Office.Interop.Excel.Range ErrCell;
                int ntryh = 0;
                while (true) {
                    ntryh++;
                    try {
                        ErrCell = w.Range[ExcelColumnFromNumber(8) + nrigacorrente.ToString(),
                            ExcelColumnFromNumber(8) + nrigacorrente.ToString()];
                        break;
                    }
                    catch (Exception E) {
                        if (ntryh == 10) throw E;
                        Thread.Sleep(100 * ntryh);

                    }
                }

                ntryh = 0;
                while (true) {
                    ntryh++;
                    try {
                        ErrCell.Font.Color = 255;
                        break;
                    }
                    catch (Exception E) {
                        if (ntryh == 10) throw E;
                        Thread.Sleep(100 * ntryh);

                    }
                }

               
                ErrCell.Value2 = ""; //Azzera eventuale vecchio contenuto

				 

                cod_tributo = cod_tributo.ToUpper();
				if ( (cod_tributo!= "127E")  && (cod_tributo!= "128E")
				  && (cod_tributo!= "384E") &&  (cod_tributo!= "385E") &&  (cod_tributo!= "381E")
				  && (cod_tributo!= "126E") &&  (cod_tributo!= "154E") && (cod_tributo!= "161E")
				  && (cod_tributo!= "601E") &&  (cod_tributo!= "602E") && (cod_tributo!= "603E")
				  && (cod_tributo!= "604E") &&  (cod_tributo!= "605E") && (cod_tributo!= "606E")
				  && (cod_tributo!= "607E") &&  (cod_tributo!= "608E") && (cod_tributo!= "609E")
				  && (cod_tributo!= "610E") &&  (cod_tributo!= "611E") && (cod_tributo!= "612E")
				  && (cod_tributo!= "613E") &&  (cod_tributo!= "614E") && (cod_tributo!= "615E")
				  && (cod_tributo!= "616E") &&  (cod_tributo!= "617E") && (cod_tributo!= "618E")
				  && (cod_tributo!= "619E") &&  (cod_tributo!= "620E") && (cod_tributo!= "621E")
				  && (cod_tributo!= "622E") &&  (cod_tributo!= "801E") && (cod_tributo!= "901E")
				  ) {
					err += " Valore non previsto nella decodifica del campo codice tributo";
					ErrCell.Value2 = err;
					nrigacorrente++;
					ok = false;
					continue;
				}

				cod_tributo = cod_tributo.ToUpper();
				if ((cod_tributo == "384E") || (cod_tributo == "385E") || (cod_tributo.ToUpper() == "127E") || (cod_tributo.ToUpper() == "128E")||
					(cod_tributo == "154E") || (cod_tributo == "161E")) {
					string errori = null;
					bool found = CheckProvincia(sigla_prov.Trim(), out errori);

					if ((!found) && (errori != "")) {
						err += " " + errori;
						ErrCell.Value2 = err;
						nrigacorrente++;
						ok = false;
						continue;
					}
				}
				if ((cod_tributo == "384E") || (cod_tributo == "385E") || (cod_tributo.ToUpper() == "127E") || (cod_tributo.ToUpper() == "128E")||
					(cod_tributo == "154E") || (cod_tributo == "161E")) {
					bool found = CheckComune(denom.ToString().Trim(), sigla_prov, cod_catastale, out errore, out o_cod_catastale);
					if ((!found) && (errore != "")) {
						err += " " + errore;
						ErrCell.Value2 = err;
						nrigacorrente++;
						ok = false;
						continue;
					}
				}

				if ((cod_tributo == "381E") || (cod_tributo == "153E") || (cod_tributo == "381E") || (cod_tributo == "160E") || (cod_tributo == "126E")) {
					if (denom == DBNull.Value || denom == null || denom.ToString() == "") {
						err += " Regione fiscale non valorizzata ma obbligatoria"; ;
						ErrCell.Value2 = err;
						nrigacorrente++;
						ok = false;
					} else {
						bool found = CheckRegione(denom.ToString().Trim(), out errore, cod_catastale, out o_codice_regione);

						if ((!found) && (errore != "")) {
							err += " " + errore;
							ErrCell.Value2 = err;
							nrigacorrente++;
							ok = false;
							continue;
						}
					}
				}
				if ((CfgFn.GetNoNullInt32(o_anno_rif) <= CfgFn.GetNoNullInt32(Meta.GetSys("esercizio")) - 10) ||
                            (CfgFn.GetNoNullInt32(o_anno_rif) > CfgFn.GetNoNullInt32(Meta.GetSys("esercizio")))) {
                    err += " Anno di riferimento errato";
                    ErrCell.Value2 = err;
                    nrigacorrente++;
                    ok = false;
                    continue;
                }
            
                if ((CfgFn.GetNoNullInt32(o_mese_rif) <= 0) || (CfgFn.GetNoNullInt32(o_mese_rif) > 12)) {
                    err += " Mese di riferimento errato";
                    ErrCell.Value2 = err;
                    nrigacorrente++;
                    ok = false;
                    continue;
                }
                if (CfgFn.GetNoNullDecimal(o_importoadebito) < 0) {
                    errore = " Valore non previsto per il campo importo a debito" + " di valore " +
                                  o_importoadebito.ToString().Trim() + " : inserire un importo maggiore di zero";
                    err += " " + errore;
                    ErrCell.Value2 = err;
                    nrigacorrente++;
                    ok = false;
                    continue;
                }
                if (CfgFn.GetNoNullDecimal(o_importoadebito) < 0) {
                errore = " Valore non previsto per il campo importo a credito" + " di valore " +
                              o_importoadebito.ToString().Trim() + " : inserire un importo maggiore di zero";
                err += " " + errore;
                ErrCell.Value2 = err;
                nrigacorrente++;
                ok = false;
                continue;
                }


                if (!ok) {//shouldn't happen
                    ErrCell.Value2 = err;
                    nrigacorrente++;
                    continue;
                }

                if (ok) {
                    DataRow[] tributo = tributi.Select(QHC.CmpEq("cod_tributo", cod_tributo));
                    if (tributo.Length == 1) {
                        // ricerca in mData se c'è già una riga 

                        string filterRow = QHC.AppAnd(QHC.CmpEq("codicetributo", cod_tributo),
                                                      QHC.CmpEq("riferimentoB", getStringaDiLunghezzaN(o_anno_rif, 4)));

                        if ((cod_tributo == "384E") || (cod_tributo == "385E") || (cod_tributo.ToUpper() == "127E") || (cod_tributo.ToUpper() == "128E"))
                            filterRow = QHC.AppAnd(filterRow, QHC.CmpEq("codice", o_cod_catastale));
                        else
                            filterRow = QHC.AppAnd(filterRow, QHC.CmpEq("codice", o_codice_regione)); ; // 381E

                        if (CfgFn.GetNoNullInt32(o_mese_rif) > 9)
                            filterRow = QHC.AppAnd(filterRow, QHC.CmpEq("riferimentoA", "00" + getStringaDiLunghezzaN(o_mese_rif, 2)));
                        else
                            filterRow = QHC.AppAnd(filterRow, QHC.CmpEq("riferimentoA", "000" + getStringaDiLunghezzaN(o_mese_rif, 2))); ; // 381E

                        DataRow[] mDataRow = mData.Select(filterRow);
                        if (mDataRow.Length > 0) {
                            DataRow dr = mDataRow[0];
                            dr["importoadebito"] = CfgFn.GetNoNullDecimal(dr["importoadebito"]) + CfgFn.GetNoNullDecimal(o_importoadebito);
                            dr["importoacredito"] = CfgFn.GetNoNullDecimal(dr["importoacredito"]) + CfgFn.GetNoNullDecimal(o_importoacredito);
                        }
                        else {
                            DataRow dr;
                            dr = mData.NewRow();
                            dr["tiporiga"] = tributo[0]["tiporiga"];
                            dr["estremi"] = DBNull.Value;
                            dr["codicetributo"] = cod_tributo;

							if ((cod_tributo == "384E") || (cod_tributo == "385E") || (cod_tributo.ToUpper() == "127E") || (cod_tributo.ToUpper() == "128E") ||
								(cod_tributo == "154E") || (cod_tributo == "161E"))
								dr["codice"] = o_cod_catastale;
							if ((cod_tributo == "381E") || (cod_tributo == "153E") || (cod_tributo == "381E") || (cod_tributo == "160E") || (cod_tributo == "126E")) {
									dr["codice"] = o_codice_regione;  
							}

							if (CfgFn.GetNoNullInt32(o_mese_rif) > 9)
                                dr["riferimentoA"] = "00" + getStringaDiLunghezzaN(o_mese_rif, 2);
                            else
                                dr["riferimentoA"] = "000" + getStringaDiLunghezzaN(o_mese_rif, 2);

                            dr["riferimentoB"] = getStringaDiLunghezzaN(o_anno_rif, 4);

                            dr["importoadebito"] = o_importoadebito;
                            dr["importoacredito"] = CfgFn.GetNoNullDecimal(o_importoacredito);
                            mData.Rows.Add(dr);
                        }
                    }
                }
                nrigacorrente++;
            }
            if (ok) MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Elaborate " + nrigacorrente.ToString() + " righe.");
            return ok;
        }

        private bool isNumeric(object str, out decimal valore)
        {
            valore = 0;
            try
            {
                valore = Convert.ToDecimal(str);
                return true;
            }
            catch {
                return false;
            }
        }

       private bool CheckRegione(string regione, out string errori, string codice_regione, out object codice)
        {
            regione = regione.ToUpper();
            int count = 0;
            errori = ""; codice = "";

            //innanzitutto effettua una ricerca con il codice regione letto dal file

            if (codice_regione != "")
            {
                count = Conn.RUN_SELECT_COUNT("fiscaltaxregion",
                 QHS.CmpEq("idfiscaltaxregion", codice_regione.PadLeft(2,'0'))
               
                    , false);
            }

            if (count == 1)
            {
                codice = codice_regione.PadLeft(2, '0');
                return true;
            }

            if ((count != 1) && (regione != ""))
            {
                
                count = Conn.RUN_SELECT_COUNT("fiscaltaxregion",
                    QHS.Like("title", "%" + regione + "%")
                      , false);
            }
          
            if (count == 1)
            {
                codice = Conn.DO_READ_VALUE("fiscaltaxregion",
                   QHS.Like("title", "%" + regione + "%")
                      , "idfiscaltaxregion");
            }
            if (count == 0) errori = "Regione non trovata";
            if (count >1) errori = "Trovata più di una regione";
            return false;
        }
        private bool CheckProvincia(string sigla, out string errori)
        {
            // la provincia non deve essere obbligatoria, il metodo non deve essere chiamato
            sigla = sigla.ToUpper();
           
            int count = 0;
            errori = "";
            if (sigla == "") return true;
            if (sigla != "")
            {
                count = Conn.RUN_SELECT_COUNT("geo_country",
                   QHS.CmpEq("province", sigla)
                      , false);
            }
           
            if (count == 1) return true;
            if (count == 0) errori = "Provincia non trovata";
            if (count > 1) errori = "Trovata più di una provincia";
            return false;
        }

        private bool CheckComune(string comune, string sigla, string codice, out string errori, out object cod_catastale)
        {
            comune = comune.ToUpper();
            int count = 0;
            cod_catastale = DBNull.Value;
            string filter = "";
            if (codice != "")
            {
                filter =   QHS.AppAnd(QHS.CmpEq("codename", "fiscale"),
                        QHS.CmpEq("value", codice), QHS.IsNull("stop"), QHS.IsNull("newcity"));
                count = Conn.RUN_SELECT_COUNT("geo_city_agencyview", filter, false);
            }
            
            // la provincia non deve essere obbligatoria
            if (count != 1)
            {
                filter =  QHS.AppAnd(QHS.CmpEq("codename", "fiscale"),
                        QHS.CmpEq("title", comune),QHS.IsNull("stop"));
                count = Conn.RUN_SELECT_COUNT("geo_city_agencyview", filter, false);

                if ((count!=1)&&(sigla != "")) {
                    filter = QHS.AppAnd(filter, QHS.CmpEq("provincecode", sigla));
                    count = Conn.RUN_SELECT_COUNT("geo_city_agencyview", filter, false);
                }
            }
            errori = "";
            if (count == 1)
            {
                cod_catastale = Conn.DO_READ_VALUE("geo_city_agencyview", filter, "value");
                return true;
            }
            if (count == 0) errori = "Comune non trovato";
            if (count >1) errori = "Trovato più di un comune";
            return false;
        }

     
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void btnElabora_Click(object sender, EventArgs e)
        {
            if (mData.Rows.Count == 0)
            {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Non ci sono dati da elaborare");
                return;
            }

            DateTime dataDiVersamento = (DateTime)HelpForm.GetObjectFromString(
                typeof(DateTime), txtDataDiVersamento.Text, txtDataDiVersamento.Tag.ToString());
            if (dataDiVersamento < DateTime.Now.Date)
            {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Data di addebito: il valore immesso non può essere inferiore alla data corrente");
                HelpForm.FocusControl(txtDataDiVersamento);
                return;
            }

            DataTable t = mData;

            DialogResult dr = saveOutputFileDlg.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                txtPercorso.Text = saveOutputFileDlg.FileName;
            }
            else
            {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Non è stato selezionato il percorso in cui memorizzare il file dell'F24");
                return;
            }
           
            Stream stream = saveOutputFileDlg.OpenFile();
            StreamWriter sw = new StreamWriter(stream, Encoding.Default);
            int numeroDiRecordV = (t.Rows.Count + 21) / 22;
            generaRecordA(sw);
            generaRecordM(sw, t);
            for (int numRecV = 1; numRecV <= numeroDiRecordV; numRecV++)
            {
                generaRecordV(sw, t, numRecV);
            }
            generaRecordZ(sw, numeroDiRecordV);
            sw.Close();

            txtDataGenerazione.Text = HelpForm.StringValue(Meta.GetSys("datacontabile"),
                txtDataGenerazione.Tag.ToString());
            MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Elaborazione completata");
        }

        private void txtDataDiVersamento_Leave(object sender, EventArgs e)
        {
            HelpForm.ExtLeaveDateTimeTextBox(txtDataDiVersamento, null);
        }

        private string getStringaDiLunghezzaN(object o, int n)
        {
            string stringa = o.ToString();
            return stringa.Length > n
                ? stringa.Substring(0, n)
                : stringa.PadRight(n);
        }

        private string getPadLeftDiLunghezzaN(object o, int n)
        {
            string stringa = o.ToString();
            return stringa.Length > n
                ? stringa.Substring(0, n)
                : stringa.PadRight(n);
        }

        private string formattaImporto(object importo)
        {
            int centesimi = (int)((decimal)importo * 100);
            return centesimi.ToString().PadLeft(15, '0');
        }

        private void generaRecordA(TextWriter tw)
        {
            tw.Write("A".PadRight(1 + 14));//Tipo record
            tw.Write("F24EP");//Codice fornitura
            tw.Write("14");//Codice fornitura (persona non fisica)
            string cf = getStringaDiLunghezzaN(txtCodiceFiscale.Text, 16);
            tw.Write(cf.PadRight(16 + 177));//Codice fiscale del fornitore
            string denominazione = getStringaDiLunghezzaN(txtDenominazione.Text, 60);
            tw.Write(denominazione.PadRight(60 + 164) + " ".PadRight(1 + 14 + 67));//Denominazione
            tw.Write("001");//Progressivo dell'invio telematico
            tw.Write("001".PadRight(3 + 100));//Numero totale degli invii telematici (numero dei record di tipo M presenti nel Flusso)
            tw.Write("1".PadRight(1 + 1269));//Flag di Accettazione
            tw.Write("A\r\n");
        }

        private void generaRecordM(TextWriter tw, DataTable t)
        {
            tw.Write("M");//Tipo record
            string cf = getStringaDiLunghezzaN(txtCodiceFiscale.Text, 11);
            tw.Write(cf.PadRight(11 + 5));//Codice fiscale contribuente
            tw.Write("1".PadLeft(8, '0').PadRight(8 + 3 + 25 + 20 + 16));//Progressivo invio all'interno del flusso, non superiore a 999
            tw.Write("E".PadLeft(1 + 1).PadRight(1 + 1 + 426));
            string denominazione = getStringaDiLunghezzaN(txtDenominazione.Text, 55);
            tw.Write(denominazione.PadRight(55 + 1195));//Denominazione
            tw.Write("14");//Tipo titolare del conto
            tw.Write(cf);//Codice fiscale contribuente
            string iban = txtContoDiAddebito.Text;
            //15 Codice Paese 1781 2 AN Assume sempre il valore IT
            //16 Codice di Controllo 1783 2 NU Obbligatorio e coerente con le specifiche IBAN.
            //17 CIN 1785 1 AN Obbligatorio, deve essere una lettera maiuscola.
            //18 ABI 1786 5 NU Assume sempre il valore 01000 (Banca d'Italia)
            //19 CAB 1791 5 NU Assume sempre il valore 03245
            //20 Numero di conto 1796 12 AN Obbligatorio. Numero di conto definito in modo da individuare anche la tesoreria destinataria. Si veda la circolare n. 20 del 8/5/2007 della R.G.S.
            tw.Write(iban.PadRight(27));//Conto di addebito
            //string email = getStringaDiLunghezzaN(DS.license.Rows[0]["email"].ToString(), 60); ; //email del contribuente, da mettere
            string email = txtEmail.Text;
            tw.Write(" ");//filler
            tw.Write(email.PadRight(60));
            tw.Write("EURO");//Valuta
            decimal _SaldoTotaleADebito = (decimal)t.Compute("sum(importoadebito)", null);
            string saldoTotaleADebito = _SaldoTotaleADebito.ToString("n", cultureInfo.NumberFormat);
            if (saldoTotaleADebito.Length > 15) saldoTotaleADebito = saldoTotaleADebito.Replace(".", "");
            tw.Write(saldoTotaleADebito.PadRight(15));//Saldo totale a debito
            DateTime _DataDiVersamento = (DateTime)HelpForm.GetObjectFromString(
                typeof(DateTime), txtDataDiVersamento.Text, txtDataDiVersamento.Tag.ToString());
            string dataDiVersamento = _DataDiVersamento.ToString("dd-MM-yyyy", cultureInfo);
            tw.Write(dataDiVersamento);//Data di versamento
            tw.Write("A\r\n");
        }

        private void generaRecordV(TextWriter tw, DataTable t, int numRecV)
        {
            decimal importoADebito = 0;
            decimal importoaCredito = 0;
            tw.Write("V");
            string cf = getStringaDiLunghezzaN(txtCodiceFiscale.Text, 16);//Codice fiscale contribuente
            tw.Write(cf);
            tw.Write("1".PadLeft(8, '0').PadRight(8 + 3 + 25 + 20 + 16));//Progressivo invio all'interno del flusso, non superiore a 999
            tw.Write("D");//TIPO MODELLO  (modello Enti Pubblici v. 2016)
            tw.Write("   ".PadRight(3)); //Codice ufficio finanziario 3 caratteri
            tw.Write("0".PadRight(11, '0')); //Codice Atto, se presente deve essere formalmente corretto
            tw.Write(" ".PadRight(18)); //Identificativo operazione 
            int max = t.Rows.Count < numRecV * 22 ? t.Rows.Count : numRecV * 22;

            for (int i = (numRecV - 1) * 22; i < max; i++)
            {
                DataRow r = t.Rows[i];
                tw.Write(r["tiporiga"].ToString());
                tw.Write(getStringaDiLunghezzaN(r["codicetributo"], 6));//Codice tributo/ Causale
                tw.Write(getStringaDiLunghezzaN(r["codice"], 5));//Significato dipendete da tipo riga
                tw.Write(getStringaDiLunghezzaN(r["estremi"], 17));//vedere specifiche
                tw.Write(getStringaDiLunghezzaN(r["riferimentoA"], 6));
                tw.Write(getStringaDiLunghezzaN(r["riferimentoB"], 6));

                tw.Write(formattaImporto(r["importoadebito"]));//Importo a debito
                importoADebito += (decimal)r["importoadebito"];

                tw.Write(formattaImporto(r["importoacredito"]));//Importo a credito
                importoaCredito += (decimal)r["importoacredito"];

            }
            for (int i = max; i < numRecV * 22; i++)
            {
                tw.Write(' ');//tipo riga
                tw.Write("".PadRight(6));
                tw.Write("".PadRight(5));
                tw.Write("".PadRight(17));
                tw.Write("".PadRight(6));
                tw.Write("".PadRight(6));
                tw.Write("0".PadRight(15, '0'));
                tw.Write("0".PadRight(15, '0'));
            }
            tw.Write(" ".PadRight(58));
            tw.Write(formattaImporto(importoADebito).PadRight(15, '0'));//Importo a debito
            tw.Write(formattaImporto(importoaCredito).PadRight(15, '0'));//Importo a credito
            tw.Write("P");//Segno saldo
            tw.Write(formattaImporto(importoADebito - importoaCredito).ToString().PadLeft(15, '0').PadRight(15 + 4));//Saldo di Sezione
            tw.Write(formattaImporto(importoADebito - importoaCredito));//Saldo finale modello F24 EP
            DateTime _DataDiVersamento = (DateTime)HelpForm.GetObjectFromString(
                typeof(DateTime), txtDataDiVersamento.Text, txtDataDiVersamento.Tag.ToString());
            string dataDiVersamento = _DataDiVersamento.ToString("ddMMyyyy", cultureInfo);
            tw.Write(dataDiVersamento.PadRight(8 + 82));//Data di versamento
            tw.Write("A\r\n");
        }

        private void generaRecordZ(TextWriter tw, int numeroDiRecordV)
        {
            tw.Write("Z".PadRight(1 + 14));//Tipo record
            tw.Write(numeroDiRecordV.ToString().PadLeft(9, '0'));//Numero record di tipo 'V'
            tw.Write("1".PadLeft(9, '0'));//Numero record di tipo 'M'
            tw.Write("A\r\n".PadLeft(1864 + 1 + 2));
        }
    }
}
