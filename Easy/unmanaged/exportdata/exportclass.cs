/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using metadatalibrary;
using System.Text;





namespace exportdata//exportdata//
{
	/// <summary>
	/// Classe per l'esportazione di Dati.
	/// Reference: Microsoft Excel 9.0 Object Library
	/// Metodo da utilizzare per l'esportazione in Excel:
	/// public static void DataTableToExcel(System.Data.DataTable DT,bool Header)
	/// Codice di chiamata: /*Rana:exportdata.*/exportclass.DataTableToExcel(MyDS.Tables[0],true);
	/// Max 08 ottobre 2002
	/// </summary>
	public class exportclass
	{
		public exportclass()
		{}

/// <summary>
/// Esporta tutti i dati del Datatable in un "File a lunghezza fissa"
/// </summary>
/// <param name="dt"></param>
/// <param name="header"></param>

        public static void dataTableToFixedLengthFile (System.Data.DataTable dt, bool header) {
           dataTableToFixedLengthFile(dt, null, header);
        }

		public static void dataTableToFixedLengthFile(System.Data.DataTable dt, object fileExtension, bool header) 
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
            if ((fileExtension != DBNull.Value)&&(fileExtension!= null)) {
                string ext = fileExtension.ToString().Trim();
                if (ext.Substring(0,1) == ".") ext = ext.Substring(1);
                // Default file extension
                saveFileDialog.DefaultExt = ext;

                // Available file extensions
                saveFileDialog.Filter = "File di testo (*." + ext + ")|*." + ext;
            }

 			if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

			string fileName  = saveFileDialog.FileName;
			if (fileName == "") return;

			StreamWriter sw = new StreamWriter(fileName, false, Encoding.Default);

			int[] lunghezza = new int[dt.Columns.Count];
			if (header) 
			{
				for (int i=0; i<dt.Columns.Count; i++) 
				{
					lunghezza[i] = dt.Columns[i].ColumnName.Length;
				}
			}
			foreach (DataRow r in dt.Rows) 
			{
				for (int i=0; i<dt.Columns.Count; i++) 
				{
					int length = r[i].ToString().Length;
					if (length > lunghezza[i]) lunghezza[i] = length;
				}
			}
			if (header) 
			{
				for (int i=0; i<dt.Columns.Count-1; i++) 
				{
					sw.Write(dt.Columns[i].ColumnName + ' ');
				}
				sw.WriteLine(dt.Columns[dt.Columns.Count-1].ColumnName);
			}
			foreach (DataRow r in dt.Rows) 
			{
				for (int i=0; i<dt.Columns.Count; i++) 
				{
					HorizontalAlignment align = HelpForm.GetAlignForColumn(dt.Columns[i]);
					string campo = (align == HorizontalAlignment.Right)
						? r[i].ToString().PadLeft(lunghezza[i], ' ')
						: r[i].ToString().PadRight(lunghezza[i], ' ');
					if (i < dt.Columns.Count-1) 
					{
						sw.Write(campo + ' ');
					} 
					else 
					{
						sw.WriteLine(campo);
					}
				}
			}
			sw.Close();
		}

/// <summary>
/// Esporta tutti i dati del Datatable in un file di testo con i valori delle colonne separati da un carattere specificato.
/// </summary>
/// <param name="dt">DataTable da importare</param>
/// <param name="header">true se si vuole importare anche l'intestazione delle colonne</param>
/// <param name="separator">carattere separatore delle colonne</param>
		private static void dataTableToSeparatedValues(System.Data.DataTable dt, bool header, char separator) 
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

			string fileName  = saveFileDialog.FileName;
			if (fileName == "") return;

			StreamWriter sw = new StreamWriter(fileName, false, Encoding.Default);

			if (header) 
			{
				for (int i=0; i<dt.Columns.Count-1; i++) 
				{
					sw.Write(dt.Columns[i].ColumnName + separator);
				}
				sw.WriteLine(dt.Columns[dt.Columns.Count-1].ColumnName);
			}

			foreach (DataRow r in dt.Rows) 
			{
				for (int i=0; i<dt.Columns.Count-1; i++) 
				{
					sw.Write(r[i].ToString() + separator);
				}
				sw.WriteLine(r[dt.Columns.Count-1]);
			}
			sw.Close();
		}

/// <summary>
/// Esporta tutti i dati del DataTable in un "File con campi separati da tabulatori"
/// </summary>
/// <param name="dt">Datatable da importare</param>
/// <param name="header">true se si vuole importare anche l'intestazione delle colonne</param>
		public static void dataTableToTabulationSeparatedValues(System.Data.DataTable dt, bool header) 
		{
			dataTableToSeparatedValues(dt, header, '\t');
		}
		
/// <summary>
/// Esporta tutti i dati del Datatable in un "File con campi separati da punto e virgola"
/// </summary>
/// <param name="dt">DataTable da importare</param>
/// <param name="header">true se si vuole importare anche l'intestazione delle colonne</param>
		public static void dataTableToCommaSeparatedValues(System.Data.DataTable dt, bool header) 
		{
			dataTableToSeparatedValues(dt, header, ';');
		}

//Esporta tutti i dati del Datatable in un foglio Excel
		public static void DataTableToExcel(System.Data.DataTable DT,bool Header)
		{	
			if(DT.Rows.Count==0)return;
            Microsoft.Office.Interop.Excel.Application m_objExcel;
			try
			{
				m_objExcel = new Microsoft.Office.Interop.Excel.Application();
				m_objExcel.Visible = true;
			}
			catch
			{
				MessageBox.Show(	"Non Ë possibile eseguire l'esportazione in Excel. "+
					"Excel non Ë installato su questo computer o Ë presente una versione "+
					"non compatibile con l'oggetto COM: Microsoft Excel 9.0 Object Library",
					"Esportazione non riuscita");
				return;
			}
            Microsoft.Office.Interop.Excel.Workbook MyWorkbook = m_objExcel.Workbooks.Add(-4167);   //Numero magico by Nino
            Microsoft.Office.Interop.Excel.Worksheet Myworksheet = (Microsoft.Office.Interop.Excel.Worksheet)MyWorkbook.Worksheets.get_Item(1);
			int RowCount = DT.Rows.Count; //Numero Righe del datatable
			int ColumnCount = DT.Columns.Count;	//Numero Colonne del datatable
			int Step = 0;
			//Attento:	Il Worrksheet ha come base per le righe e colonne 1	(prima cella [1,1])
			//			Il Datatable ha come base 0.	(prima cella [0,0])
			//Aggiungo i titoli delle colonne
			if(Header)Step = 1;	//Mi server per incrementare i contatori quando inserisco anche i titoli di colonna
			//per ogni colonna del datatable:
			for(int Colonna = 1;Colonna<=ColumnCount;Colonna++)
			{	
				//Aggiunge il nome della colonna:
				if(Header)Myworksheet.Cells[1,Colonna] = DT.Columns[Colonna-1].ColumnName.ToString();

				string MyFormat = GetNumberFormat(DT.Rows[0][Colonna-1].GetType().ToString());
				
				//per ogni riga del datatable:
				for(int Riga = 1;Riga<=RowCount;Riga++)
				{
					Myworksheet.Cells[Riga + Step,Colonna] = DT.Rows[Riga-1][Colonna-1].ToString();
					
				}
                //Formatta le colonne del Worksheet e le giustifica:
                Microsoft.Office.Interop.Excel.Range X;
				try {
					X = (Microsoft.Office.Interop.Excel.Range)Myworksheet.Range[Myworksheet.Cells[1 + Step,Colonna],Myworksheet.Cells[RowCount + Step +1,Colonna]];
					X.NumberFormat = MyFormat;	//Imposta il formato del Range
					X.EntireColumn.AutoFit();	//Giustifica la colonna
				}
				catch (Exception E) {
					MessageBox.Show(E.Message,"Errore");
				}
				
			}
            m_objExcel.DisplayAlerts = false;

		}

        public static string DataTableToExcel(System.Data.DataTable DT, bool Header, string filename) {
            if (DT.Rows.Count == 0) return "Esportazione vuota";
            Microsoft.Office.Interop.Excel.Application m_objExcel;
            try {
                m_objExcel = new Microsoft.Office.Interop.Excel.Application();
                m_objExcel.Visible = false;
            }
            catch {
                return "Non Ë possibile eseguire l'esportazione in Excel. " +
                    "Excel non Ë installato su questo computer o Ë presente una versione " +
                    "non compatibile con l'oggetto COM: Microsoft Excel 9.0 Object Library";
            }
            Microsoft.Office.Interop.Excel.Workbook MyWorkbook = m_objExcel.Workbooks.Add(-4167);	//Numero magico by Nino
            Microsoft.Office.Interop.Excel.Worksheet Myworksheet = (Microsoft.Office.Interop.Excel.Worksheet)MyWorkbook.Worksheets.get_Item(1);
            int RowCount = DT.Rows.Count; //Numero Righe del datatable
            int ColumnCount = DT.Columns.Count;	//Numero Colonne del datatable
            int Step = 0;
            //Attento:	Il Worrksheet ha come base per le righe e colonne 1	(prima cella [1,1])
            //			Il Datatable ha come base 0.	(prima cella [0,0])
            //Aggiungo i titoli delle colonne
            if (Header) Step = 1;	//Mi server per incrementare i contatori quando inserisco anche i titoli di colonna
            //per ogni colonna del datatable:
            for (int Colonna = 1; Colonna <= ColumnCount; Colonna++) {
                //Aggiunge il nome della colonna:
                if (Header) Myworksheet.Cells[1, Colonna] = DT.Columns[Colonna - 1].ColumnName.ToString();

                string MyFormat = GetNumberFormat(DT.Rows[0][Colonna - 1].GetType().ToString());

                //per ogni riga del datatable:
                for (int Riga = 1; Riga <= RowCount; Riga++) {
                    Myworksheet.Cells[Riga + Step, Colonna] = DT.Rows[Riga - 1][Colonna - 1].ToString();

                }
                //Formatta le colonne del Worksheet e le giustifica:
                Microsoft.Office.Interop.Excel.Range X;
                try {
                    X = (Microsoft.Office.Interop.Excel.Range)Myworksheet.Range[Myworksheet.Cells[1 + Step, Colonna], Myworksheet.Cells[RowCount + Step + 1, Colonna]];
                    X.NumberFormat = MyFormat;	//Imposta il formato del Range
                    X.EntireColumn.AutoFit();	//Giustifica la colonna
                }
                catch (Exception E) {
                    return E.ToString();
                }

            }
            Myworksheet.SaveAs(filename, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);     
            m_objExcel.DisplayAlerts=false;
            m_objExcel.Quit();
            return null;
        }


		/// <summary>
		/// Restituisce una stringa contenente il tipo di formattazione da assegnare a Range.NumberFormat di Excel
		/// </summary>
		/// <param name="MyType"></param>
		/// <returns></returns>
		public static string GetNumberFormat(string MyType)
		{
			string MyFormat = "Standard";
			return MyFormat;
			// Formatta le colonne del foglio Excel
			//switch(MyType)
			//{
			//	case "System.String":
			//		MyFormat="Standard";
			//		break;
			//	case "System.Decimal":
			//		MyFormat="#.###,##";
			//		break;
			//	case "System.Double":
			//		MyFormat="#.##0,00";
			//		break;
			//	case "System.DateTime":
			//		MyFormat="GgMmAa";
			//		break;
			//	case "System.Int32":
			//		MyFormat="#.###";
			//		break;
			//	case "System.Int16":
			//		MyFormat="#.###";
			//		break;
			//	case "System.Int64":
			//		MyFormat="#.###";
			//		break;
					
			//}
			//return MyFormat;
		
		}


		/// <summary>
		/// Esegue il Fill del ListView passato, leggendo i dati dal datatable avente tre colonne
		/// Descrizione
		/// Importo
		/// Formato
		/// </summary>
		/// <param name="LV"></param>
		/// <param name="DT"></param>
		/// <returns></returns>
		public static ListView SituazioneToListView(ListView LV, System.Data.DataTable DT)
		{
			LV.View = View.Details;	//necessario per la visualizzazione del GridLines
			LV.GridLines = true;
			LV.Columns.Add("Descrizione",450,HorizontalAlignment.Left);
			LV.Columns.Add("Importo",150,HorizontalAlignment.Right);
			
			ListViewItem MyItemFirst = new ListViewItem("");
			MyItemFirst.Font = new System.Drawing.Font("Arial",14,FontStyle.Bold);
			LV.Items.Add(MyItemFirst);
			foreach(DataRow DR in DT.Rows)
			{
				string MyFormat = DR["Formato"].ToString();
				switch(MyFormat)
				{	
					case "H":		//Riga di intestazione
						ListViewItem MyItemH = new ListViewItem(NN(DR["Descrizione"].ToString()));
						LV.Items.Add(MyItemH);
						break;
					case " ":		//Normale
						ListViewItem MyItemN = new ListViewItem(NN(DR["Descrizione"].ToString()));
						MyItemN.SubItems.Add(DR["Importo"].ToString());
						LV.Items.Add(MyItemN);
						break;
					case "N":		//Riga Vuota
						LV.Items.Add(new ListViewItem(""));
						break;
					case "S":		//Riga in grassetto
						ListViewItem MyItemS = new ListViewItem(NN(DR["Descrizione"].ToString()));
						MyItemS.Font = new System.Drawing.Font("Arial",14,FontStyle.Bold);
						MyItemS.EnsureVisible();
						MyItemS.BackColor = Color.LightYellow;
						ListViewItem.ListViewSubItem MysubItem = new ListViewItem.ListViewSubItem(MyItemS,(DR["Importo"].ToString()));
						MysubItem.ResetStyle();
						MyItemS.SubItems.Add(MysubItem);
						//MyItemS.SubItems.Add(DR["Importo"].ToString());
						//MyItemS.Font = new System.Drawing.Font("Arial",15,FontStyle.Underline);
						System.Drawing.FontFamily FF = new FontFamily(System.Drawing.FontFamily.GenericSerif.Name);
						LV.Items.Add(MyItemS);
						//LV.AutoArrange = true;
						//LV.PerformLayout();
						LV.Refresh();
						//LV.ResumeLayout();
						
						break;
					
				}	//Fine switch
				
			} //Fine foreach
			return LV;
		}//Fine SituazioneToListView


		/// <summary>
		/// Restituisce una stringa vuota se Ë NULL la stringa passata
		/// Altrimenti restituisce la stringa originale
		/// </summary>
		/// <param name="Mystring"></param>
		/// <returns></returns>
		public static string NN(string MyString)
		{
			if(MyString.ToString()=="NULL")return "";
			return MyString;
		}

	}
}
