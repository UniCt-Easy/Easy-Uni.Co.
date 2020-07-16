/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

﻿using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Text;
using System.Globalization;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
using System.Diagnostics;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;


namespace funzioni_configurazione {
    public class ExcelImport {
        Dictionary<string, int> field_pos = new Dictionary<string, int>();

        public static string CsvConnString(string pathName,bool header) {
            string ConnectionString;
            string HDR = header ? "YES" : "NO";
            if (!AceOleDb12Present()) {
                ConnectionString = "Provider=" +
                "Microsoft.Jet.OLEDB.4.0" +
                ";Data Source=" + pathName +
                ";Extended Properties=\"text;HDR=" + HDR + ";FMT=CSVDelimited;\"";

            }
            else {
                ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathName +
                    ";Extended Properties=\"text;HDR=" + HDR + ";FMT=CSVDelimited;\"";
            }
            return ConnectionString;
        }

        public static string ExcelConnString(string fileName) {
            string ConnectionString;
            if (!AceOleDb12Present()) {
                ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName +
                   ";Extended Properties=\"Excel 8.0;HDR=YES\"";

            }
            else {
                if (fileName.EndsWith("xls")) {
                    ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName +
                                       ";Extended Properties=\"Excel 8.0;HDR=YES\"";
                }
                else {
                    // XLSX, Versione Excel 2007 e successive
                    ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName +
                                       ";Extended Properties=\"Excel 12.0 Xml;HDR=YES\"";
                }
            }
            return ConnectionString;
        }

        static bool AceOleDb12Present() {
            return true;
            //OleDbEnumerator enumerator = new OleDbEnumerator();
            //DataTable table = enumerator.GetElements();
            //bool bNameFound = false;
            ////bool bCLSIDFound = false;

            //foreach (DataRow row in table.Rows) {
            //    foreach (DataColumn col in table.Columns) {
            //        if ((col.ColumnName.Contains("SOURCES_NAME")) && (row[col].ToString().Contains("Microsoft.ACE.OLEDB.12.0")))
            //            bNameFound = true;
            //        //if ((col.ColumnName.Contains("SOURCES_CLSID")) && (row[col].ToString().Contains("{3BE786A0-0366-4F5C-9434-25CF162E475E}")))
            //        //    bCLSIDFound = true;
            //    }
            //}
            //if (bNameFound) // && bCLSIDFound)
            //    return true;
            //else
            //    return false;
        }

        public void ImportTable(string fileName, DataTable T) {
            ImportTable(fileName, T, true, 2);
        }

        delegate object columnParser(string value);
        
        public void ImportTable(string fileName, DataTable T,bool header,int firstDataRow) {
            OleDbEnumerator enumerator = new OleDbEnumerator();
            //DataTable table = enumerator.GetElements();
            //if (table.Rows.Count==0) return;
            //string provname = table.Rows[0][0].ToString();
            //string ConnectionString =ExcelConnString(fileName);

            //GetSchemaTable(ConnectionString,T);

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(fileName, 0, true /* impostare a false se non è readonly */ ,
                    5,
                    "", "", true,
                    Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, //Microsoft.Office.Interop.XlPlatform.xlWindows,
                    "\t", //delimiter
                    false, //editable
                    false, //Notify
                    0, true, 1, 0);
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

      

            bool somedata = true;
        

            Dictionary<string, int> field_pos = new Dictionary<string, int>();
            int ncols = 1;

            if (header) {
                Microsoft.Office.Interop.Excel.Range headCell = null;
              
                while (true) {
                    int ntryh = 0;
                    while (true) {
                        ntryh++;
                        try {
                            headCell =
                                xlWorkSheet.Range[ExcelColumnFromNumber(ncols) + "1", ExcelColumnFromNumber(ncols) + "1"
                                    ];
                            break;
                        }
                        catch (Exception E) {
                            if (ntryh == 10) throw E;
                            Thread.Sleep(100*ntryh);

                        }
                    }
                    object colName = headCell.Value[Microsoft.Office.Interop.Excel.XlRangeValueDataType.xlRangeValueDefault];

                    if (colName == null || colName == DBNull.Value || colName.ToString() == "") {
                        break;
                    }
                    field_pos[colName.ToString()] = ncols;
                    ncols++;
                }
            }
            else {
                for (int i = 0; i < T.Columns.Count; i++) {
                    field_pos[T.Columns[i].ColumnName] = i + 1;
                }
                ncols = T.Columns.Count;
            }
            string pref1 = ExcelColumnFromNumber(1);
            string pref2 = ExcelColumnFromNumber(ncols);
            string decSeparator = CultureInfo.CurrentUICulture.NumberFormat.CurrencyDecimalSeparator;
            string GroupsSeparator = CultureInfo.CurrentUICulture.NumberFormat.CurrencyGroupSeparator;
            string numSeparator = CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator;
            string numGroupsSeparator = CultureInfo.CurrentUICulture.NumberFormat.NumberGroupSeparator;

            NumberFormatInfo MyNFI = new NumberFormatInfo();
            MyNFI.NegativeSign = "-";
            MyNFI.CurrencyDecimalSeparator = decSeparator;
            MyNFI.CurrencyGroupSeparator = GroupsSeparator;
            MyNFI.NumberDecimalSeparator = numSeparator;
            MyNFI.NumberGroupSeparator = numGroupsSeparator;


            int nrigacorrente = firstDataRow;
            while (true) {
                Microsoft.Office.Interop.Excel.Range testCell = null;
                int ntry = 0;
                while (true) {
                    ntry++;
                    try {
                        testCell = xlWorkSheet.Range[pref1 + nrigacorrente, pref2 + nrigacorrente];
                        break;
                    }
                    catch (Exception E) {
                        if (ntry == 10) throw E;
                        Thread.Sleep(100 * ntry);

                    }
                }
                object[,] Xcelle = (object[,])testCell.Value[Microsoft.Office.Interop.Excel.XlRangeValueDataType.xlRangeValueDefault];
                object[,] Xcelle2 = (object[,])testCell.Value2;
                somedata = false;
                for (int i = 1; i <= ncols; i++) {
                    if (Xcelle2[1, i] != null) {
                        somedata = true;
                        break;
                    }
                }
                if (!somedata) break;
                DataRow r = T.NewRow();

                foreach (DataColumn col in T.Columns) {
                    if (!field_pos.ContainsKey(col.ColumnName)) continue;
                    int icol = field_pos[col.ColumnName];
                    object val = Xcelle[1, icol];
                    object val2 = Xcelle2[1, icol];

                    if (val == null || val == DBNull.Value) {
                        r[col] = DBNull.Value;
                        continue;
                    }

                    if (val.ToString().Trim() == "") {
                        r[col] = DBNull.Value;
                        continue;
                    }

                    if (col.DataType == typeof(DateTime)) {
                        if (val2.GetType() == typeof(string)) {
	                        try {
		                        string[] gma = val2.ToString().Split('/');
		                        r[col] = new DateTime(Convert.ToInt32(gma[2]), Convert.ToInt32(gma[1]),
			                        Convert.ToInt32(gma[0]));
	                        }
	                        catch {
		                        throw new Exception(
			                        $"La stringa {val2} alla riga {nrigacorrente} colonna {col.ColumnName} non ha un formato di data valido");
	                        }
                        }
                        else {
                            r[col] = DateTime.FromOADate(Convert.ToDouble(val2));
                        }
                        continue;
                    }
                    if (col.DataType== typeof(Decimal) & val.GetType()==typeof(string)) {
                        var str = (string)val;
                        if ((str.IndexOf(GroupsSeparator)==str.Length-3) && (str.IndexOf(decSeparator) == -1)) {
                            str = str.Replace(GroupsSeparator, decSeparator);
                        }
                        r[col] = decimal.Parse(str,NumberStyles.Currency,MyNFI);
                        continue;
                    }
                    if (col.DataType == typeof(Double) & val.GetType() == typeof(string)) {
                        var str = (string)val;
                        if ((str.IndexOf(numGroupsSeparator) == str.Length - 3) && (str.IndexOf(numSeparator) == -1)) {
                            str = str.Replace(numGroupsSeparator, numSeparator);
                        }
                        r[col] = double.Parse(str, NumberStyles.Number, MyNFI);
                        continue;
                    }
                    r[col] = val;

                }
                T.Rows.Add(r);
                r.AcceptChanges();
                nrigacorrente++;

            }
            //object saveChanges = XlSaveAction.xlDoNotSaveChanges;
            //xlWorkBook.Close(saveChanges, null,null);
            xlApp.DisplayAlerts = false;

            xlApp.Quit();
            releaseObject(xlApp);
            releaseObject(xlWorkBook);
            releaseObject(xlWorkSheet);
            xlApp = null;
        }

        string ExcelColumnFromNumber(int column) {
            int hprof = metaprofiler.StartTimer("ExcelColumnFromNumber");
            string columnString = "";
            int columnNumber = column;
            while (columnNumber > 0) {
                int currentLetterNumber = (columnNumber - 1) % 26;
                char currentLetter = (char)(currentLetterNumber + 65);
                columnString = currentLetter + columnString;
                columnNumber = (columnNumber - (currentLetterNumber + 1)) / 26;
            }
            metaprofiler.StopTimer(hprof);
            return columnString;
        }

        private void releaseObject(object obj) {
            try {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex) {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally {
                GC.Collect();
            }
        }
        //int ncols = 0;

        //void GetSchemaTable(string ConnectionString,DataTable T) {
        //    using (OleDbConnection connection =
        //        new OleDbConnection(ConnectionString)) {
        //        connection.Open();
        //        System.Data.DataTable sheetData = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, null);
        //        ncols = sheetData.Rows.Count;
        //        foreach (DataRow r in sheetData.Rows) {
        //            string fname = r["COLUMN_NAME"].ToString().ToLower();
        //            if (!T.Columns.Contains(fname)) continue;
        //            int pos = CfgFn.GetNoNullInt32(r["ORDINAL_POSITION"]);
        //            field_pos[fname] = pos;
        //        }
        //    }

        //}

        public Type oleDbToNetTypeConverter(int oleDbTypeNumber) {
            switch (oleDbTypeNumber) {
                case 0: return typeof(Nullable);
                case 2: return typeof(Int16);
                case 3: return typeof(Int32);
                case 4: return typeof(Single);
                case 5: return typeof(Double);
                case 6: return typeof(Decimal);
                case 7: return typeof(DateTime);
                case 8: return typeof(String);
                case 9: return typeof(Object);
                case 10: return typeof(Exception);
                case 11: return typeof(Boolean);
                case 12: return typeof(Object);
                case 13: return typeof(Object);
                case 14: return typeof(Decimal);
                case 16: return typeof(SByte);
                case 17: return typeof(Byte);
                case 18: return typeof(UInt16);
                case 19: return typeof(UInt32);
                case 20: return typeof(Int64);
                case 21: return typeof(UInt64);
                case 64: return typeof(DateTime);
                case 72: return typeof(Guid);
                case 128: return typeof(Byte[]);
                case 129: return typeof(String);
                case 130: return typeof(String);
                case 131: return typeof(Decimal);
                case 133: return typeof(DateTime);
                case 134: return typeof(TimeSpan);
                case 135: return typeof(DateTime);
                case 138: return typeof(Object);
                case 139: return typeof(Decimal);
                case 200: return typeof(String);
                case 201: return typeof(String);
                case 202: return typeof(String);
                case 203: return typeof(String);
                case 204: return typeof(Byte[]);
                case 205: return typeof(Byte[]);
            }
            throw (new Exception("DataType Not Supported"));
        }

    }
    public class LeggiFile {
        string[] tracciato;
        FileStream FS;
        //StreamReader SR;
        BufferedStream BF;
        string currrecord;

        public int GetCurrRowNumber() {
            return nrigacorrente - 1;
        }

        int len = 0; //Lunghezza del tracciato

        public LeggiFile() {

        }

        bool excel = false;
        bool datatable = false;
        Microsoft.Office.Interop.Excel.Application xlApp = null;
        Microsoft.Office.Interop.Excel.Workbook xlWorkBook = null;
        Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = null;
        int nrigacorrente = 1;

        DataTable SPTable = null;

        public bool Init(DataAccess Conn, string[] tracciato, string sqltext) {
            this.tracciato = tracciato;
            len = 0;
            currrecord = "";
            SPTable = Conn.SQLRunner(sqltext, false, 0);
            datatable = true;
            if (SPTable == null) {
                MessageBox.Show("Il comando SQL " + sqltext + " non ha restituito una tabella.", "Avviso");
                return false;
            }
            return true;
        }

        public void Reset() {
            nrigacorrente = 1;
            currrecord = "";
            if (datatable) {
                return;
            }
            if (excel) {
                return;
            }
            FS.Seek(0, SeekOrigin.Begin);
        }

        public bool Init(string[] tracciato, string filename) {
            this.tracciato = tracciato;
            len = 0;
            currrecord = "";
            for (int i = 0; i < tracciato.Length; i++) {
                string[] par = tracciato[i].Split(';');
                len += Convert.ToInt32(par[3]);
            }
            if (filename.EndsWith("xls") || filename.EndsWith("xlsx")) {
                try {
                    xlApp = new Microsoft.Office.Interop.Excel.Application();
                    xlWorkBook = xlApp.Workbooks.Open(filename, 0, true /* impostare a false se non è readonly */,
                        5,
                        "", "", true,
                        Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, //Microsoft.Office.Interop.Excel.XlPlatform.xlWindows,
                        "\t", //delimiter
                        false, //editable
                        false, //Notify
                        0, true, 1, 0);
                    xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                    excel = true;
                }
                catch (Exception E) {
                    QueryCreator.ShowException(E);
                    return false;
                }

            }
            else {
                try {
                    FS = new FileStream(filename, FileMode.Open);
                    BF = new BufferedStream(FS, 10000000);
                }
                catch (Exception E) {
                    QueryCreator.ShowException(E);
                    return false;
                }
            }
            return true;
        }
        public bool Init(string[] tracciato) {
            this.tracciato = tracciato;
            len = 0;
            currrecord = "";
            for (int i = 0; i < tracciato.Length; i++) {
                string[] par = tracciato[i].Split(';');
                len += Convert.ToInt32(par[3]);
            }
            return true;
        }
        public void Close() {
            if (SPTable != null) {
                SPTable.Clear();
                SPTable = null;
            }
            if (excel && xlApp != null) {
                xlApp.Quit();
                releaseObject(xlApp);
                releaseObject(xlWorkBook);
                releaseObject(xlWorkSheet);
                xlApp = null;
                return;
            }
            if (BF != null) {
                BF.Close();
                BF.Dispose();
                BF = null;
            }
            if (FS != null) {
                FS.Close();
                FS.Dispose();
                FS = null;
            }

        }

        private void releaseObject(object obj) {
            try {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex) {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally {
                GC.Collect();
            }
        }


        Hashtable H = new Hashtable();

        public bool DataPresent() {
            if (H == null) return false;
            return true;

        }

        /// <summary>
        /// Estrae un campo, restituisce null su errori
        /// </summary>
        /// <param name="S"></param>
        /// <param name="tracciato_field"></param>
        /// <returns></returns>
        object CSVGetField(string S, string tracciato_field, out string fieldname,out string errmsg) {
            errmsg = null;
            string[] ff = tracciato_field.Split(';');
            fieldname = ff[0];
            string ftype = ff[2].ToLower().Trim(); //(intero/numero/stringa/codificato/data)
            string val = S.Trim();
            if (val == "") return DBNull.Value;
            try {
                switch (ftype) {
                    case "intero": {
                            string X = val.Trim().TrimStart('0');
                            if (X == "") return 0;
                            return Convert.ToInt32(X);
                        }
                    case "stringa":
                        return val.TrimEnd(new char[] { ' ' });
                    case "numero":
                        return Convert.ToDecimal(val);
                    case "data":
                        string[] gma = val.ToString().Split('/');
                        return
                            ToDatetime(new DateTime(Convert.ToInt32(gma[2]), Convert.ToInt32(gma[1]),
                                Convert.ToInt32(gma[0])));
                    case "codificato": {
                            string[] codici = ff[4].Split('|');
                            for (int i = 0; i < codici.Length; i++) {
                                if (val.ToLower() == codici[i].ToLower()) return val;
                            }
                            errmsg = "Valore non previsto nella decodifica del campo " + fieldname +
                                                " di tipo " + ftype + " e di valore " +
                                                val.Trim().TrimStart('0') + " nella riga " + S;
                            return null;
                        }
                    default: {
                            errmsg="Errore nella decodifica del campo " + fieldname + " di tipo " + ftype +
                                                " e di valore " +
                                                val.Trim().TrimStart('0') + " nella riga " + S;
                            return null;
                        }
                }
            }
            catch {
                errmsg = "Errore nella decodifica del campo " + fieldname + " di tipo " + ftype +
                                    " e di valore " +
                                    val.Trim().TrimStart('0') + " nella riga " + S;
                return null;
            }
        }

        /// <summary>
        /// Estrae un campo, restituisce null su errori
        /// </summary>
        /// <param name="S"></param>
        /// <param name="tracciato_field"></param>
        /// <returns></returns>
        object GetField(string S, int start, string tracciato_field, out string fieldname, out int toskip, out string errmsg) {
            errmsg = null;
            string[] ff = tracciato_field.Split(';');
            fieldname = ff[0];
            int len = Convert.ToInt32(ff[3]);
            string ftype = ff[2].ToLower().Trim(); //(intero/numero/stringa/codificato/data)
            toskip = len;
            string val = S.Substring(start, len).Trim();
            if (val == "") return DBNull.Value;
            try {
                switch (ftype) {
                    case "intero": {
                            string X = val.Trim().TrimStart('0');
                            if (X == "") return 0;
                            return Convert.ToInt32(X);
                        }
                    case "stringa":
                        return val.TrimEnd(new char[] { ' ' });
                    case "numero":
                        return Convert.ToDecimal(val);
                    case "data":
                        return ToDatetime(new DateTime(Convert.ToInt32(val.Substring(4)),
                            Convert.ToInt32(val.Substring(2, 2).TrimStart('0')),
                            Convert.ToInt32(val.Substring(0, 2).TrimStart('0'))));
                    case "codificato": {
                            string[] codici = ff[4].Split('|');
                            for (int i = 0; i < codici.Length; i++) {
                                if (val.ToLower() == codici[i].ToLower()) return val;
                            }
                            errmsg = "Valore non previsto nella decodifica del campo " + fieldname +
                                                " di tipo " + ftype + " e di valore " +
                                                val.Trim().TrimStart('0') + " nella riga " + S;
                            return null;
                        }
                    default: {
                            errmsg = "Errore nella decodifica del campo " + fieldname + " di tipo " + ftype +
                                                " e di valore " +
                                                val.Trim().TrimStart('0') + " nella riga " + S;
                            return null;
                        }
                }
            }
            catch {
                errmsg = "Errore nella decodifica del campo " + fieldname + " di tipo " + ftype +
                                    " e di valore " +
                                    val.Trim().TrimStart('0') + " nella riga " + S;
                return null;
            }
        }

        object ExcelGetField(object val, object val2, string tracciato_field,  out string fieldname, out string errmsg) {
            errmsg = null;
            string[] ff = tracciato_field.Split(';');
            fieldname = ff[0];
            int len = Convert.ToInt32(ff[3]);
            string ftype = ff[2].ToLower().Trim(); //(intero/numero/stringa/codificato/data)
            if (val == null) return DBNull.Value;
            if (val == DBNull.Value) return val;
            if (val.ToString().Trim() == "") return DBNull.Value;
            try {
                switch (ftype) {
                    case "intero": {
                            string X = val.ToString().Trim().TrimStart('0');
                            if (X == "") return 0;
                            return Convert.ToInt32(X);
                        }
                    case "stringa": {
                            string Y = val.ToString().TrimEnd(new char[] { ' ' });
                            if (Y.Length > len) {
                                return Y.Substring(0, len);
                            }
                            else {
                                return Y;
                            }
                        }
                    case "numero":
                        return Convert.ToDecimal(val);
                    case "data": // DateTime.FromOADate and DateTime.ToOADate
                        if (val2.GetType() == typeof(string)) {
                            string[] gma = val2.ToString().Split('/');
                            return
                                ToDatetime(new DateTime(Convert.ToInt32(gma[2]), Convert.ToInt32(gma[1]),
                                    Convert.ToInt32(gma[0])));
                        }
                        else {
                            return ToDatetime(DateTime.FromOADate(Convert.ToDouble(val2)));
                        }
                    //return new DateTime(Convert.ToInt32(val.Substring(4)),
                    //                            Convert.ToInt32(val.Substring(2, 2).TrimStart('0')),
                    //                            Convert.ToInt32(val.Substring(0, 2).TrimStart('0')));
                    case "codificato": {
                            string[] codici = ff[4].Split('|');
                            for (int i = 0; i < codici.Length; i++) {
                                if (val.ToString().ToLower() == codici[i].ToLower()) return val;
                            }
                            errmsg="Valore non previsto nella decodifica del campo " + fieldname +
                                                " di tipo " + ftype + " e di valore " +
                                                val.ToString().Trim().TrimStart('0') + " nella riga " +
                                                nrigacorrente.ToString();
                            return null;
                        }
                    default: {
                            errmsg="Errore nella decodifica del campo " + fieldname + " di tipo " + ftype +
                                                " e di valore " +
                                                val.ToString().Trim().TrimStart('0') + " nella riga " +
                                                nrigacorrente.ToString();
                            //SpeedSaver.AddError("Errore interno nel tracciato per tipo " + ftype);
                            return null;
                        }
                }
            }
            catch {
                errmsg ="Errore nella decodifica del campo " + fieldname + " di tipo " + ftype +
                                    " e di valore " +
                                    val.ToString().Trim().TrimStart('0') + " nella riga " + nrigacorrente.ToString();
                return null;
            }
        }

        bool DataTableSkip() {
            nrigacorrente++;
            if (nrigacorrente >= SPTable.Rows.Count) {
                H = null;
                return false;
            }
            return true;
        }

        bool DataTableGetNext() {
            int myrow = nrigacorrente - 1;
            if (myrow >= SPTable.Rows.Count) {
                H = null;
                return false;
            }
            if (H == null) H = new Hashtable();
            DataRow R = SPTable.Rows[myrow];
            currrecord = "";
            string fieldname = "";
            object O = "";
            string ftype = "";
            for (int i = 0; i < tracciato.Length; i++) {
                try {
                    string fmt = tracciato[i];
                    string[] ff = fmt.Split(';');
                    fieldname = ff[0];
                    ftype = ff[2].ToLower().Trim(); //(intero/numero/stringa/codificato/data)
                    int len = Convert.ToInt32(ff[3]);

                    if (SPTable.Columns.Contains(fieldname)) {
                        O = R[fieldname];
                        if (O.ToString().Trim() == "")
                            O = DBNull.Value;


                        if (ftype == "stringa" && O != DBNull.Value) {
                            string Y = O.ToString().TrimEnd();
                            if (Y.Length > len) {
                                O = Y.Substring(0, len);
                            }
                            else {
                                O = Y;
                            }
                        }
                        if (O.GetType() == typeof(DateTime))
                            O = ToDatetime(O);
                        H[fieldname] = O;
                        if (O != DBNull.Value)
                            currrecord += "[" + fieldname + "=" + O.ToString() + "] ";
                    }
                    else {
                        H[fieldname] = DBNull.Value;
                    }
                }
                catch (Exception e) {
                    throw new Exception("Errore alla riga:" + nrigacorrente.ToString() +
                                        " nell'interpretazione del campo " +
                                        fieldname + " il cui tipo dovrebbe essere " + ftype +
                                        " ed il cui valore è " + O.ToString() + "\r\nMessaggio:\r\n" + e.Message +
                                        "\r\n" + e.StackTrace);
                }
            }
            nrigacorrente++;
            return true;

        }

        private object ToDatetime(object data) {
            if (data == DBNull.Value)
                return data;

            DateTime d = (DateTime)data;
            DateTime minValue = new DateTime(1753, 1, 1);
            if (d < minValue)
                return minValue;
            DateTime maxValue = new DateTime(9999, 12, 31);
            if (d > maxValue)
                return maxValue;

            return data;

        }

        bool ExcelSkip() {
            nrigacorrente++;
            return true;
        }
        /// <summary>
        /// Returns false if no more data
        /// </summary>
        /// <returns></returns>
        bool ExcelGetNext() {
            string lastcol = ExcelColumnFromNumber(tracciato.Length);
            string row = nrigacorrente.ToString();
            bool somedata = false;
            object[] celle = new object[tracciato.Length];
            object[] celle2 = new object[tracciato.Length];

            int HTestHash = metaprofiler.StartTimer("Test HashTable");
            int ncol = tracciato.Length;
            Microsoft.Office.Interop.Excel.Range testCell = null;
            int ntry = 0;
            while (true) {
                ntry++;
                try {
                    testCell = xlWorkSheet.Range[ExcelColumnFromNumber(1) + nrigacorrente.ToString(),
                        ExcelColumnFromNumber(ncol) + nrigacorrente.ToString()];
                    break;
                }
                catch (Exception E) {
                    if (ntry == 10) throw E;
                    Thread.Sleep(100 * ntry);

                }
            }
            if (testCell.Count > 1) { 
                object[,] Xcelle = (object[,])testCell.get_Value(Microsoft.Office.Interop.Excel.XlRangeValueDataType.xlRangeValueDefault);
                object[,] Xcelle2 = (object[,])testCell.Value2;
                for (int i = 0; i < tracciato.Length; i++) {
                    object getvalue = Xcelle[1, i + 1];
                    celle[i] = getvalue;
                    celle2[i] = Xcelle2[1, i + 1];
                    if (getvalue == null) {
                        continue;
                    }
                    if (getvalue.ToString() != "") {
                        somedata = true;
                        //break;
                    }
                }
            }
            /*
            * (object[,])range.get_Value(XL.XlRangeValueDataType.xlRangeValueDefault)
            * produce questo errore  :Cannot convert type 'string' to 'object[*,*]'
            * quando range.Count == 1.
            * perchè restituirà una stringa quando range.Count == 1, che significa che non può essere convertito in object[,]
            * Questo si verifica quando l'intervallo si riferisce a una cella specifica e get_Value restituisce il valore di tale cella.
            */
            if (testCell.Count == 1) {
                object singleStrValue = testCell.get_Value(Microsoft.Office.Interop.Excel.XlRangeValueDataType.xlRangeValueDefault);
                object singleStrValue2 = testCell.Value2;
                int iRow, iCol;
                iRow = testCell.Row;
                iCol = testCell.Column;
                for (int i = 0; i < tracciato.Length; i++) {
                    object getvalue = singleStrValue;
                    celle[i] = getvalue;
                    celle2[i] = singleStrValue2;
                    if (getvalue == null) {
                        continue;
                    }
                    if (getvalue.ToString() != "") {
                        somedata = true;
                        //break;
                    }
                }
            }
            metaprofiler.StopTimer(HTestHash);
            if (!somedata) {
                H = null;
                return false;
            }
            //Excel.Range R = xlWorkSheet.Range["A"+row , lastcol+row];

            int HFillHash = metaprofiler.StartTimer("Fill HashTable");
            if (H == null) H = new Hashtable();
            currrecord = "";
            string error;
            for (int i = 0; i < tracciato.Length; i++) {
                string fieldname;
                string fmt = tracciato[i];
                object O = null;

                int hprof = metaprofiler.StartTimer("ExcelGetField");
                O = ExcelGetField(celle[i], celle2[i], fmt, out fieldname, out error);
                if (error != null) {
                    MessageBox.Show(error, "Errore");
                    continue;
                }
                metaprofiler.StopTimer(hprof);

                if (O == null) {
                    metaprofiler.StopTimer(HFillHash);
                    H = null;
                    return false;
                }
                currrecord += "[" + fieldname + "=" + O.ToString() + "] ";
                H[fieldname] = O; //HH
            }
            nrigacorrente++;
            metaprofiler.StopTimer(HFillHash);
            //Application.DoEvents();
            return true;
        }

        string ExcelColumnFromNumber(int column) {
            int hprof = metaprofiler.StartTimer("ExcelColumnFromNumber");
            string columnString = "";
            int columnNumber = column;
            while (columnNumber > 0) {
                int currentLetterNumber = (columnNumber - 1) % 26;
                char currentLetter = (char)(currentLetterNumber + 65);
                columnString = currentLetter + columnString;
                columnNumber = (columnNumber - (currentLetterNumber + 1)) / 26;
            }
            metaprofiler.StopTimer(hprof);
            return columnString;
        }

        int NumberFromExcelColumn(string column) {
            int retVal = 0;
            string col = column.ToUpper();
            for (int iChar = col.Length - 1; iChar >= 0; iChar--) {
                char colPiece = col[iChar];
                int colNum = colPiece - 64;
                retVal = retVal + colNum * (int)Math.Pow(26, col.Length - (iChar + 1));
            }
            return retVal;
        }

        public bool Skip() {
            if (datatable) return DataTableSkip();
            if (excel) return ExcelSkip();
            return false;
        }
        /// <summary>
        /// Returns false if no more data
        /// </summary>
        /// <returns></returns>
        public bool GetNextCSV(string[] SS) {
            //Legge una riga dal file
            currrecord = "";
            int HFillHash = metaprofiler.StartTimer("Fill HashTable");
            if (H == null) H = new Hashtable();
            string error;
            int nMax = SS.Length;
            int iCol = 0;
            for (int i = 0; i < tracciato.Length; i++) {
                string fieldname;
                string fmt = tracciato[i];
                object O = CSVGetField(SS[iCol], fmt, out fieldname, out error);
                if (error != null) {
                    MessageBox.Show(error, "Errore");
                    continue;
                }
                if (O == null) {
                    metaprofiler.StopTimer(HFillHash);
                    H = null;
                    return false;
                }
                currrecord += "[" + fieldname + "=" + O.ToString() + "] ";
                H[fieldname] = O; //HH
                if (iCol + 1 < nMax) {
                    iCol++;
                }
                else return true;
            }
               metaprofiler.StopTimer(HFillHash);
            return true;

        }

        public bool GetNext() {
            if (datatable) return DataTableGetNext();
            if (excel) return ExcelGetNext();

            if (BF == null) {
                H = null;
                return false;
            }
            if (BF.Position >= BF.Length) {
                H = null;
                return false;
            }
            byte[] buffer = new byte[len + 2];
            //Legge una riga dal file
            int HBFRead = metaprofiler.StartTimer("BF.Read(buffer)");
            int count = BF.Read(buffer, 0, len + 2);
            metaprofiler.StopTimer(HBFRead);
            if (count < len) {
                H = null;
                return false;
            }
            int currpos = 0;
            string S = Encoding.Default.GetString(buffer);
            currrecord = "";
            int HFillHash = metaprofiler.StartTimer("Fill HashTable");
            if (H == null) H = new Hashtable();
            //Hashtable HH = new Hashtable();
            string error;
            for (int i = 0; i < tracciato.Length; i++) {
                int toskip = 0;
                string fieldname;
                string fmt = tracciato[i];
                object O = GetField(S, currpos, fmt, out fieldname, out toskip, out error);
                if (error != null) {
                    MessageBox.Show(error, "Errore");
                    continue;
                }
                if (O == null) {
                    metaprofiler.StopTimer(HFillHash);
                    H = null;
                    return false;
                }
                currrecord += "[" + fieldname + "=" + O.ToString() + "] ";
                H[fieldname] = O; //HH
                currpos += toskip;
            }
            metaprofiler.StopTimer(HFillHash);
            //Application.DoEvents();
            //H = HH;
            return true;

        }


        public string GetCurrRecord() {
            return currrecord;
        }

        public object getCurrField(string fieldname) {
            if (H == null) return DBNull.Value;
            if (H[fieldname] == null) {
                //SpeedSaver.AddError("Campo " + fieldname + " non trovato nel tracciato");
                return DBNull.Value;
            }
            return H[fieldname];
        }

    }
}
