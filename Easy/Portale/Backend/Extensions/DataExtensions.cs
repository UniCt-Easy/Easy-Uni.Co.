
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Backend.Extensions {

    /// <summary>
    /// Metodi di estensione per gli oggetti ADO.NET.
    /// </summary>
    public static class DataExtensions {

        private static readonly string StatePropertyName = "__state__";
        private static readonly string Statecurrent = "Current";
        private static readonly string Stateoriginal = "Original";
        private static readonly string SchemaPropertyName = "schema";
        private static readonly string KeyPropertyName = "key";
        private static readonly string DataPropertyName = "data";
        private static readonly string MessagesPropertyName = "messages";
        private static readonly string AuditPropertyName = "audit";
        private static readonly string SeverityPropertyName = "severity";
        private static readonly string DescriptionPropertyName = "description";
        private static readonly string TablePropertyName = "table";

        /// <summary>
        /// Restituisce la posizione della colonna nella lista.
        /// </summary>
        /// <param name="column">Colonna.</param>
        /// <returns>Posizione.</returns>
        public static int getListPosition(this DataColumn column) {
            if (!column.ExtendedProperties.Contains("ListColPos")) return -1;
            return (int) column.ExtendedProperties["ListColPos"];
        }

        /// <summary>
        /// Riempie il DataSet.
        /// </summary>
        /// <param name="ds">Il DataSet da riempire.</param>
        /// <param name="conn">La connessione da utilizzare per caricare i dati dal database.</param>
        /// <param name="tableName">Il nome della tabella primaria.</param>
        /// <param name="filter">Il filtro sulla chiave primaria.</param>
        /// <returns>Vero se l'operazione è stata eseguita senza problemi.</returns>
        public static void fill(this DataSet ds, IDataAccess conn, string tableName, string filter) {
            var getData = new GetData();
            getData.InitClass(ds, conn, tableName);
            getData.GET_PRIMARY_TABLE(filter);

            var dt = ds.Tables[tableName];
            if (dt.Rows.Count > 0) {
                var dr = dt.First();
                getData.DO_GET(false, dr);
            }

            getData.Destroy();
        }

        /// <summary>
        /// Crea un oggetto JSON rappresentante lo schema, la struttura della chiave primaria ed il contenuto del DataTable.
        /// </summary>
        /// <param name="dt">Il DataTable.</param>
        /// <returns>Un oggetto JSON.</returns>
        public static JObject backupData(this DataTable dt) {
            var table = new JObject();

            // Ordina le colonne per posizione
            var columnList = new SortedList<int, string>();
            foreach (DataColumn dc in dt.Columns) {
                var position = dc.getListPosition();
                if (position < 0) continue;
                if (string.IsNullOrEmpty(dc.Caption)) continue;

                var name = dc.ColumnName;

                columnList.Add(position, name);
            }

            // Genera la struttura contenente lo schema
            var schema = new JObject();
            foreach (var name in columnList.Values) {
                schema.Add(name, JToken.FromObject(dt.Columns[name].Caption));
            }

            table.Add(SchemaPropertyName, schema);

            // Genera l'elenco contenente i campi della chiave primaria
            var key = new JArray(dt.PrimaryKey.Select(column => column.ColumnName));
            table.Add(KeyPropertyName, key);

            // Genera la struttura contenente i dati
            var rows = new JArray();
            foreach (DataRow dr in dt.Rows) {
                var row = new JObject();
                foreach (DataColumn dc in dt.Columns) {
                    if (dt.PrimaryKey.Contains(dc) || columnList.ContainsValue(dc.ColumnName)) {
                        if (dr.IsNull(dc.ColumnName)) {
                            row.Add(dc.ColumnName, null);
                        }
                        else {
                            row.Add(dc.ColumnName, JToken.FromObject(dr[dc.ColumnName]));
                        }
                    }
                }

                rows.Add(row);
            }

            table.Add(DataPropertyName, rows);

            var root = new JObject();
            root.Add(dt.TableName, table);
            return root;
        }


        /// <summary>
        /// Crea un oggetto JSON contenente i dati del DataSet e gli eventuali messaggi d'errore ad esso legati.
        /// </summary>
        /// <param name="ds">Il DataSet.</param>
        /// <param name="pmc">La collezione di errori.</param>
        /// <returns>Un oggetto JSON.</returns>
        public static JObject backupData(this DataSet ds, ProcedureMessageCollection pmc = null) {
            var root = new JObject();

            // Genera la struttura contenente i dati
            var data = new JObject();
            foreach (DataTable dt in ds.Tables) {
                var table = new JArray();
                foreach (DataRow dr in dt.Rows) {
                    var row = new JObject();
                    //Stato Riga

                    if (dr.RowState == DataRowState.Modified) {
                        row.Add(StatePropertyName, "Mod");
                    }

                    if (dr.RowState == DataRowState.Deleted) {
                        row.Add(StatePropertyName, "Del");
                    }

                    if (dr.RowState == DataRowState.Added) {
                        row.Add(StatePropertyName, "Add");
                    }

                    if (dr.RowState == DataRowState.Detached) {
                        row.Add(StatePropertyName, "Det");
                    }

                    if (dr.RowState == DataRowState.Unchanged) {
                        row.Add(StatePropertyName, "Unch");
                    }

                    //row.Add(statePropertyName, JToken.FromObject(dr.RowState));

                    //Curr , campi correnti
                    row.Add(Statecurrent, "Values");
                    foreach (DataColumn dc in dt.Columns) {
                        if (dr.RowState != DataRowState.Deleted) {
                            if (dr.IsNull(dc)) {
                                row.Add(dc.ColumnName, null);
                            }
                            else {
                                row.Add(dc.ColumnName, JToken.FromObject(dr[dc, DataRowVersion.Current]));
                            }
                        }
                        else {
                            row.Add(dc.ColumnName, JToken.FromObject(dr[dc, DataRowVersion.Original]));
                        }
                    }

                    //creo una nuova riga per gestire la riga originale
                    var row1 = new JObject();
                    //Original , campi precedenti ove stato sia modified (anche state : deleted , unchanged ???)
                    if (dr.RowState == DataRowState.Modified) {

                        //Aggiungo lo stateoriginal alla riga originale e setto statePropertyName
                        row1.Add(Stateoriginal, "Values");

                        foreach (DataColumn dc1 in dt.Columns) {
                            if (dr.IsNull(dc1)) {
                                row1.Add(dc1.ColumnName, null);
                            }
                            else {
                                row1.Add(dc1.ColumnName, JToken.FromObject(dr[dc1, DataRowVersion.Original]));
                            }

                        }

                    }


                    table.Add(row);
                    //se la riga non è stata modificata
                    if (row1.GetValue(Stateoriginal) != null) {
                        table.Add(row1);
                    }

                }

                data.Add(dt.TableName, table);
            }

            root.Add(DataPropertyName, data);

            // Genera la struttura contenente i messaggi
            if (pmc != null) {
                var messages = new JArray();
                foreach (EasyProcedureMessage pm in pmc) {
                    var message = new JObject();
                    message.Add(DescriptionPropertyName, JToken.FromObject(pm.LongMess));
                    message.Add(AuditPropertyName, JToken.FromObject(pm.AuditID));
                    message.Add(SeverityPropertyName, JToken.FromObject(pm.ErrorType));
                    message.Add(TablePropertyName, JToken.FromObject(pm.TableName));
                    messages.Add(message);
                }

                root.Add(MessagesPropertyName, messages);
            }

            return root;
        }


        /// <summary>
        /// Trasforma in stringa un oggetto JSON
        /// </summary>       
        /// <param name="ds"></param>
        /// <param name="root">Un oggetto JSON.</param>
        /// <returns>Oggetto JSON Deserializzato.</returns>
        public static String deSerializeData(this DataSet ds, JObject root) {

            string result = "";
            var table1 = new JArray();
            var json = (JObject) root.Property(DataPropertyName).Value;
            int count = 0;
            foreach (JProperty table in json.Properties()) {
                var dt = ds.Tables[table.Name];
                foreach (JObject row in table.Value) {
                    //riga che costruisco
                    DataRow dr;

                    //caso in cui la riga è Original
                    if (row.Property(StatePropertyName) == null) {
                        continue;
                    }

                    var state = row.Property(StatePropertyName).Value.ToString();


                    if (state.Equals("Add")) {
                        dr = dt.NewRow();
                        dt.Rows.Add(dr);
                    }

                    else {
                        var key = dt.PrimaryKey
                            .Select(column => row.Property(column.ColumnName).ToObject(column.DataType)).ToArray();
                        dr = dt.Rows.Find(key);
                    }


                    if (state.Equals("Del")) {
                        dt.Rows[count].Delete();
                        continue;
                    }

                    var xx = new JObject();

                    foreach (JProperty field in row.Properties()) {
                        if (!dt.Columns.Contains(field.Name)) continue;
                        var dc = dt.Columns[field.Name];

                        if (field.Value.Type == JTokenType.Null) {
                            dr[dc] = DBNull.Value;
                        }
                        else {

                            dr[dc] = field.ToObject(dc.DataType);
                            xx.Add(dc.ColumnName, JToken.FromObject(dr[dc]));
                        }



                    }

                    table1.Add(xx);
                    count++;

                }

            }

            result = table1.ToString();
            return result;

        }


        /// <summary>
        /// Riempie il DataSet con i dati contenuti nell'oggetto JSON.
        /// </summary>
        /// <param name="ds">Il DataSet.</param>
        /// <param name="root">Un oggetto JSON.</param>
        /// <returns>L'elenco dei messaggi di errore legati al DataSet.</returns>
        public static ProcedureMessageCollection restoreData(this DataSet ds, JObject root) {
            // Ripristina il contenuto del DataSet
            var dataset = (JObject) root.Property(DataPropertyName).Value;
            foreach (JProperty table in dataset.Properties()) {
                var dt = ds.Tables[table.Name];
                foreach (JObject row in table.Value) {
                    DataRow dr;

                    //VA IN ECCEZIONE CON LA GESTIONE DEGLI STATI COME STRINGHE
                    var state = row.Property(StatePropertyName).ToObject<DataRowState>();
                    if (state == DataRowState.Added) {
                        dr = dt.NewRow();
                        dt.Rows.Add(dr);
                    }
                    else {
                        var key = dt.PrimaryKey
                            .Select(column => row.Property(column.ColumnName).ToObject(column.DataType)).ToArray();
                        dr = dt.Rows.Find(key);
                    }

                    if (state == DataRowState.Deleted) {
                        dr.Delete();
                        continue;
                    }

                    foreach (JProperty field in row.Properties()) {
                        if (!dt.Columns.Contains(field.Name)) continue;
                        var dc = dt.Columns[field.Name];

                        if (field.Value.Type == JTokenType.Null) {
                            dr[dc] = DBNull.Value;
                        }
                        else {
                            dr[dc] = field.ToObject(dc.DataType);
                        }
                    }
                }
            }

            // Rigenera l'elenco dei messaggi
            var pmc = new EasyProcedureMessageCollection();
            if (pmc != null) {
                var messages = root.Property(MessagesPropertyName);
                if (messages != null) {
                    foreach (JObject message in messages.Value) {
                        var pm = new EasyProcedureMessage();
                        var audit = message.Property(AuditPropertyName);
                        pm.AuditID = audit?.Value.ToObject<string>();
                        var errorType = message.Property(SeverityPropertyName);
                        pm.ErrorType = errorType?.Value.ToObject<string>();
                        var longMsg = message.Property(DescriptionPropertyName);
                        pm.LongMess = longMsg?.Value.ToObject<string>();
                        var tableName = message.Property(TablePropertyName);
                        pm.TableName = tableName?.Value.ToObject<string>();
                        pmc.Add(pm);
                    }
                }
            }

            return pmc;
        }

    }

}
