
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
using System.Linq;
using System.Text;
using System.Web;
using Backend.Extensions;
using Backend.Controllers;
using System.IO;

namespace Backend.Components {
    /// <summary>
    /// 
    /// </summary>
    public static class AttachmentUtils {

        /// <summary>
        /// id che rimpiazza l'attachment reale. Il client se trova -1 sà che c'è un attachment.
        /// </summary>
        private static int attachReplaced = -1;

        /// <summary>
        /// I campi che hanno allegati vengono bonfificati, inserendo un id notevole "-1" al posto del contenuto binario
        /// nella rispettiva colonna calcolata, che quindi sarà !nomecolonna
        /// </summary>
        /// <param name="ds"></param>
        public static void sanitizeDsForAttach(DataSet ds) {
            // VISUALIZZAZIONE
            // 1) in lettura sostituisco il contenuto del campo attachment con un "farlocco zero" se è "0x"(c'è l'attachment) altrimenti rimane il null la cui semantica è che non c'è un attachment per quella riga.																									
            // 2) è necessario fare l'acceptChange perchè lo stato deve rimanere unchanged (e svuota la collection della riga modificata)																									
            var conn = HttpContext.Current.getDataDispatcher().conn;
            Dictionary<int, ColumnRowAttach> dataRowsModified = new Dictionary<int, ColumnRowAttach>();
            foreach (DataTable table in ds.Tables) {
                foreach (DataRow r in table.Rows) {
                    foreach (DataColumn c in table.Columns) {
                        if (c.DataType == System.Type.GetType("System.Byte[]")) {
                            var attach = r[c.ColumnName];
                            // bonifico i byte[]. non li invio al clinet. ma informo al client tramite -1 che c'è un attach
                            if (attach != null && attach != DBNull.Value) {
                                r[c.ColumnName] = IntToByte(attachReplaced);
                                if (r.Table.Columns[getAttachColumn(c.ColumnName)] != null) r[getAttachColumn(c.ColumnName)] = attachReplaced;
                                // importante fare AcceptChanges()
                                r.AcceptChanges();
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Per ogni riga che era stata modificata con il contenuto in byte array del file salvato
        /// bonifico il campo
        /// </summary>
        /// <param name="dataRowAttachModified"></param>
        public static void sanatizeDsForAttachUnsuccess(Dictionary<int, ColumnRowAttach> dataRowAttachModified) {
            foreach (KeyValuePair< int, ColumnRowAttach > entry in dataRowAttachModified) {
                string cname = entry.Value.columnName;
                DataRow row = entry.Value.dataRow;
                row[cname] = IntToByte(attachReplaced);
            }
        }

        /// <summary>
        /// Per ogni riga che era stata modificata con il contenuto in byte array del file salvato, elimino
        /// il corrispondente file sul file system, poichè ora è reso persitente sul db
        /// </summary>
        /// <param name="dataRowAttachModified"></param>
        public static void removeAttachmentAfterSuccess(Dictionary<int, ColumnRowAttach> dataRowAttachModified) {
            var conn = HttpContext.Current.getDataDispatcher().conn;
            foreach (KeyValuePair<int, ColumnRowAttach> entry in dataRowAttachModified) {
                string cname = entry.Value.columnName;
                DataRow row = entry.Value.dataRow;
                // recupero l'id che era stato memorizzato sulla colonna temporanea
                var calculateAttachColumnName = getAttachColumn(cname);
                if (row.Table.Columns[calculateAttachColumnName] == null) continue;
                var idattach = row[calculateAttachColumnName];
                var query = "select filename from attach where idattach=" + idattach;
                DataTable dtAttach = conn.SQLRunner(query);
                if (dtAttach.Rows.Count == 1) {
                    // recupero file precedentemente salvato e lo elimino dal file system.
                    var pathFile = AppDomain.CurrentDomain.BaseDirectory + FileController.UploadPath + dtAttach.Rows[0]["filename"];
                    File.Delete(pathFile); 
                }
            }
        }

        /// <summary>
        /// Recupera i campi byte[] e osserva se c'è un idattach nella relativa colonna calcolata diverso dal default "attachReplaced"
        /// In quel caso va sulla tabella attach e recupera il nome del file sul fileSystem. quello caricato via web
        /// </summary>
        /// <param name="outDs"></param>
        /// <returns></returns>
        public static  Dictionary<int, ColumnRowAttach> manageAttachWindowsCompliant(DataSet outDs) {
            var conn = HttpContext.Current.getDataDispatcher().conn;
            Dictionary<int, ColumnRowAttach> dataRowsModified = new Dictionary<int, ColumnRowAttach>();
            foreach (DataTable table in outDs.Tables) {
                foreach (DataRow r in table.Rows) {
                    // solo quelle added e modificate
                    if (r.RowState == DataRowState.Added || r.RowState == DataRowState.Modified) {
                        foreach (DataColumn c in table.Columns) {
                            if (c.DataType == System.Type.GetType("System.Byte[]")) {
                                // recupero eventuale id dalla colonna calcolata
                                if (table.Columns[getAttachColumn(c.ColumnName)] != null) { 
                                var myidAttach = r[getAttachColumn(c.ColumnName)];
                                // recupero l'id formattato nel formato che indica allegato aggiunto o modificato
                                // se diverso da "attachReplaced". se andrà tutto ok, eseguirò la sanatizeDsForAttach()
                                if (myidAttach == null || myidAttach == DBNull.Value) {
                                    // caso il client abbia premuto rimuovi allegato. mette null, e quindi qui devo ripulire il bytearray
                                    r[c.ColumnName] = DBNull.Value;

                                    // nell'else if siamo nel caso in cui ho un idattach reale, e devo quindi recuperare e salvare il file
                                } else if (Int32.Parse(myidAttach.ToString()) != attachReplaced) {
                                    // recupero nome file dalla tabella attach il file , così lo inserisco nel campo binario
                                    var query = "select filename from attach where idattach=" + myidAttach;
                                    DataTable dtAttach = conn.SQLRunner(query);
                                    if (dtAttach.Rows.Count == 1) {

                                        // recupero il nome file reale e lo concateno allo stream di byte, così poii recupero nome file ed estensione nel "downloadwin"
                                        String[] separator = { "$__$" };
                                        var fname = dtAttach.Rows[0]["filename"].ToString();
                                        var fnameArr = fname.Split(separator, StringSplitOptions.None);
                                        var realFileName = fnameArr[1];
                                        int namelen = LengthForFileName(realFileName);

                                        // aggiungo alla lista delle righe il cui campo image è stato modificato
                                        dataRowsModified.Add((int)myidAttach, new ColumnRowAttach(c.ColumnName, r));

                                        // recupero file e salvo sul campo il byteArray
                                        var pathFile = AppDomain.CurrentDomain.BaseDirectory + FileController.UploadPath + dtAttach.Rows[0]["filename"];

                                        FileStream FS = new FileStream(pathFile, FileMode.Open, FileAccess.Read);
                                        int n = (int)FS.Length;
                                        if (n == 0) {
                                            r[c.ColumnName] = DBNull.Value;
                                            continue;
                                        }
                                        byte[] ByteArray = new byte[n+namelen];
                                        FS.Read(ByteArray, namelen, n);
                                        if (FS.Length == 0) {
                                            r[c.ColumnName] = DBNull.Value;
                                        }
                                        FS.Close();
                                        SetBytesForFileName(realFileName, ByteArray);
                                        // assegno il campo byte array alla colonna
                                        r[c.ColumnName] = ByteArray;

                                    }
                                }
                              }
                            }
                        }
                    }
                }
            }

            return dataRowsModified;
        }

        public static int LengthForFileName(string S) {
            string fname = Path.GetFileName(S);
            return fname.Length + 1;
        }

        public static void SetBytesForFileName(string S, byte[] B) {
            string fname = Path.GetFileName(S);
            byte[] b = Encoding.Default.GetBytes(fname);
            for (int i = 0; i < b.Length; i++) B[i] = b[i];
            B[b.Length] = 0;
        }

        public static int GetOffsetForData(Byte[] B) {
            int i = 0;
            while (i < B.Length && B[i] != 0) i++;
            return i + 1;
        }

        public static string GetFileName(Byte[] B) {
            int len = 0;
            for (int i = 0; i < B.Length; i++) {
                len++;
                if (B[i] == 0) break;
            }
            byte[] b = new byte[len - 1];
            for (int i = 0; i < len - 1; i++) {
                b[i] = B[i];
            }
            return Encoding.Default.GetString(b);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="b1"></param>
        /// <param name="b2"></param>
        /// <returns></returns>
        public static bool CompareByteArray(byte[] b1, byte[] b2) {
            return Encoding.ASCII.GetString(b1) == Encoding.ASCII.GetString(b2);
        }

        /// <summary>
        /// Torna il nome della colonna calcolata che deve essere sul dataset
        /// </summary>
        /// <param name="cname"></param>
        /// <returns></returns>
        public static string getAttachColumn(string cname) {
            return "!" + cname;
        }

        public static byte[] IntToByte(int intValue) {
            byte[] intBytes = BitConverter.GetBytes(intValue);
            Array.Reverse(intBytes);
            byte[] result = intBytes;
            return result;
        }

        public static byte[] toByte(string value) {
            return Encoding.ASCII.GetBytes(value);
        }
    }
}

public class ColumnRowAttach {

    public ColumnRowAttach(string columnName, DataRow dataRow) {
        this.columnName = columnName;
        this.dataRow = dataRow;
    }

    public string columnName { get; set; }
    public DataRow dataRow { get; set; }
}
