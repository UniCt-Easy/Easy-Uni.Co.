
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


using Backend.Components;
using metadatalibrary;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Backend.CommonBackend {
    /// <summary>
    /// Implements the common method  caled by http calls, and web socket calls
    /// </summary>
    public class DataManager {
        /// <summary>
        /// Execute a select. Single response.
        /// </summary>
        /// <param name="prms">{string tableName, string columnList, string top, string filter}</param>
        /// <param name="dataSender"></param>
        /// <returns></returns>
        public static void selectAsync(JObject prms, IDataSender dataSender) {
            var dispatcher = dataSender.dispatcher;
            var conn = dispatcher.conn;

            var filter = prms["filter"]?.ToString();
            var tableName = prms["tableName"].ToString();
            var columnList = prms["columnList"].ToString();
            var top = prms["top"]?.ToString();

            if (top == "") top = null;
            
            MetaExpression q = null;
            if (!string.IsNullOrEmpty(filter))
				try
				{
					q = MetaExpressionSerializer.deserialize(JObject.Parse(filter)) as MetaExpression;
				}
				catch (Exception e)
				{
					dataSender.reject(HttpStatusCode.InternalServerError, "Executing getJsDataQuery(" + filter + "):" + e.ToString());
				}

			var dt = conn.readTable(tableName, q, columnList, null, top);

            if (dt == null) {
                dataSender.reject(HttpStatusCode.InternalServerError, conn.LastError);
            } else {
                dataSender.resolve(DataUtils.dataTableToJSon(dt));
            }
        }


        /// <summary>
        /// Execute a select. Single response.
        /// </summary>
        /// <param name="selBuilderArr">SelectBuilder list serialized into a JArray</param>
        /// <param name="dataSender"></param>
        /// <returns></returns>
        public static void multiRunSelect(List<SelectBuilder> selList, IDataSender dataSender) {
                var dispatcher = dataSender.dispatcher;
                var conn = dispatcher.conn;

                if (selList.Count == 0) {
                    dataSender.reject(HttpStatusCode.BadRequest, "No table was requested");
                    return;
                }

            MultiRunSender mySender = new MultiRunSender(dataSender);
            conn.executeSelectBuilderCallback(selList, 100, mySender.updateTable, -1);
        }

        class MultiRunSender {
            private IDataSender sender;
            private DataTable partialDt;

            public MultiRunSender(IDataSender dataSender) {
                sender = dataSender;
            }

            /// <summary>
            /// All'atto dell'invocazione:
            /// ["resolve"] = 1 senza altri parametri se bisogna inviare un resolve
            /// ["table"]=table
            /// ["rows"] = localRows
            /// </summary>
            /// <param name="sel"></param>
            /// <param name="dict"></param>
            /// <returns></returns>
            public void updateTable(SelectBuilder sel, Dictionary<string, object> dict) {

                if (dict.ContainsKey("resolve")) {
                    sender.resolve(null);
                    return;
                }

             
                //se c'è il parametro rows >> deve fare la notify 
                // tenendo presente che rows è un List<DataRow>
                // potresti inviare o le rows da sole oppure un table con le rows (gliele aggiungi tu)
                if (dict.ContainsKey("rows")) {

                    if (dict.ContainsKey("table")) {
                        partialDt = (DataTable) dict["table"];
                    }
                    // rimuovo righe eventualmente aggiunte nella callback precedente
                    partialDt.Rows.Clear();
                    partialDt.BeginLoadData();
                    // aggiungo le righe al dataTable corrente
                    var rows = dict["rows"];
                    foreach (var r in (List<DataRow>) rows) {
                        partialDt.Rows.Add(r);
                    }

                    partialDt.AcceptChanges();
                    partialDt.EndLoadData();
                    // serializzo dataTable

                    var serCurrDt = DataUtils.dataTableToJSon(partialDt);
                    // eseguo notify con il dt parziale corrente
                    sender.notify(serCurrDt);
                    return;
                }

                if (dict.ContainsKey("table")) {
                    // non fa nulla se non contiene righe
                    partialDt = (DataTable) dict["table"];
                }

     

            }

        }


        #region test Methods

        /// <summary>
        /// TODO metodo di test
        /// </summary>
        /// <param name="prms"></param>
        /// <param name="dataSender"></param>
        public static void testNotify(JObject prms, IDataSender dataSender) {
            // Simula n notify e resolve finale
            var value = prms["p1"].ToString();
            var res = int.Parse(value);

            for (var i = 0; i < 5; i++) {
                dataSender.notify(i + res);
                Thread.Sleep(1000);
            }

            dataSender.resolve(null);

        }

        #endregion
    }
}
