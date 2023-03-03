
/*
Easy
Copyright (C) 2023 Universita' degli Studi di Catania (www.unict.it)
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

namespace EasyPagamenti.Extensions {

    /// <summary>
    /// Metodi di estensione per gli oggetti ADO.NET.
    /// </summary>
    public static class DataExtensions {

        private static readonly string statePropertyName = "__state__";
        private static readonly string schemaPropertyName = "schema";
        private static readonly string keyPropertyName = "key";
        private static readonly string dataPropertyName = "data";
        private static readonly string messagesPropertyName = "messages";
        private static readonly string auditPropertyName = "audit";
        private static readonly string severityPropertyName = "severity";
        private static readonly string descriptionPropertyName = "description";
        private static readonly string tablePropertyName = "table";

        /// <summary>
        /// Restituisce la posizione della colonna nella lista.
        /// </summary>
        /// <param name="column">Colonna.</param>
        /// <returns>Posizione.</returns>
        public static int GetListPosition(this DataColumn column) {
            if (!column.ExtendedProperties.Contains("ListColPos")) return -1;
            return (int)column.ExtendedProperties["ListColPos"];
        }

        /// <summary>
        /// Riempie il DataSet.
        /// </summary>
        /// <param name="ds">Il DataSet da riempire.</param>
        /// <param name="conn">La connessione da utilizzare per caricare i dati dal database.</param>
        /// <param name="tableName">Il nome della tabella primaria.</param>
        /// <param name="filter">Il filtro sulla chiave primaria.</param>
        /// <returns>Vero se l'operazione è stata eseguita senza problemi.</returns>
        public static void Fill(this DataSet ds, DataAccess conn, string tableName, string filter) {
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
        public static JObject BackupData(this DataTable dt) {
            var table = new JObject();

            // Ordina le colonne per posizione
            var columnList = new SortedList<int, string>();
            foreach (DataColumn dc in dt.Columns) {
                var position = dc.GetListPosition();
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
            table.Add(schemaPropertyName, schema);

            // Genera l'elenco contenente i campi della chiave primaria
            var key = new JArray(dt.PrimaryKey.Select(column => column.ColumnName));
            table.Add(keyPropertyName, key);

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
            table.Add(dataPropertyName, rows);

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
        public static JObject BackupData(this DataSet ds, ProcedureMessageCollection pmc = null) {
            var root = new JObject();

            // Genera la struttura contenente i dati
            var data = new JObject();
            foreach (DataTable dt in ds.Tables) {
                var table = new JArray();
                foreach (DataRow dr in dt.Rows) {
                    var row = new JObject();
                    row.Add(statePropertyName, JToken.FromObject(dr.RowState));
                    foreach (DataColumn dc in dt.Columns) {
                        if (dr.IsNull(dc)) {
                            row.Add(dc.ColumnName, null);
                        }
                        else {
                            row.Add(dc.ColumnName, JToken.FromObject(dr[dc]));
                        }
                    }
                    table.Add(row);
                }
                data.Add(dt.TableName, table);
            }
            root.Add(dataPropertyName, data);

            // Genera la struttura contenente i messaggi
            if (pmc != null) {
                var messages = new JArray();
                foreach (EasyProcedureMessage pm in pmc) {
                    var message = new JObject();
                    message.Add(descriptionPropertyName, JToken.FromObject(pm.LongMess));
                    message.Add(auditPropertyName, JToken.FromObject(pm.AuditID));
                    message.Add(severityPropertyName, JToken.FromObject(pm.ErrorType));
                    message.Add(tablePropertyName, JToken.FromObject(pm.TableName));
                    messages.Add(message);
                }
                root.Add(messagesPropertyName, messages);
            }

            return root;
        }

        /// <summary>
        /// Riempie il DataSet con i dati contenuti nell'oggetto JSON.
        /// </summary>
        /// <param name="ds">Il DataSet.</param>
        /// <param name="root">Un oggetto JSON.</param>
        /// <returns>L'elenco dei messaggi di errore legati al DataSet.</returns>
        public static ProcedureMessageCollection RestoreData(this DataSet ds, JObject root) {
            // Ripristina il contenuto del DataSet
            var dataset = (JObject)root.Property(dataPropertyName).Value;
            foreach (JProperty table in dataset.Properties()) {
                var dt = ds.Tables[table.Name];
                foreach (JObject row in table.Value) {
                    DataRow dr;

                    var state = row.Property(statePropertyName).ToObject<DataRowState>();
                    if (state == DataRowState.Added) {
                        dr = dt.NewRow();
                        dt.Rows.Add(dr);
                    }
                    else {
                        var key = dt.PrimaryKey.Select(column => row.Property(column.ColumnName).ToObject(column.DataType)).ToArray();
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
                var messages = root.Property(messagesPropertyName);
                if (messages != null) {
                    foreach (JObject message in messages.Value) {
                        var pm = new EasyProcedureMessage();
                        var audit = message.Property(auditPropertyName);
                        pm.AuditID = audit?.Value.ToObject<string>();
                        var errorType = message.Property(severityPropertyName);
                        pm.ErrorType = errorType?.Value.ToObject<string>();
                        var longMsg = message.Property(descriptionPropertyName);
                        pm.LongMess = longMsg?.Value.ToObject<string>();
                        var tableName = message.Property(tablePropertyName);
                        pm.TableName = tableName?.Value.ToObject<string>();
                        pmc.Add(pm);
                    }
                }
            }

            return pmc;
        }

    }
}
