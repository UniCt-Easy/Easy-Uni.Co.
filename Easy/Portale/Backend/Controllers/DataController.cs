
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


using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Collections.Generic;
using metadatalibrary;
using Backend.Data;
using System.Web;
using System.Threading.Tasks;
using Backend.Components;
using Backend.CommonBackend;
using q = metadatalibrary.MetaExpression;
using metaeasylibrary;
using Backend.Extensions;
using System.Linq;
using funzioni_configurazione;
using Newtonsoft.Json;
using System.Reflection;
using Backend.Security;
using System.Web.Configuration;
using System.IO;
using System.Text;
using Backend.Models;
using System.Collections;
using static Backend.CommonBackend.DBLogger;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using System.Web.Http.Filters;

namespace Backend.Controllers {



	/// <inheritdoc />
	/// <summary>  Authorize or AllowAnonymous
	/// Controller per data
	/// </summary>
	[RoutePrefix("data"), Authorize, EnableCors("*", "*", "*")]
	public class DataController : ApiController {

		#region Get data

		/// <summary>
		/// DataSet data in json format. In origin it was a JsDataSet
		/// Contains the param "ds" 
		/// </summary>
		public sealed class JsDs {
			/// <summary>
			/// Rappresentazione json stringa del JsDataSet
			/// </summary>
			[Required]
			public JToken ds { get; set; }
		}


		/// <summary>
		/// Contains the post params for the method select
		/// </summary>
		public class getJsDataQueryParameters {
			/// <summary>
			/// Query
			/// </summary>
			public JToken dquery { get; set; }
		
		}

		/// <summary>
		/// Called by Client, build the MetaExpression from the json of the jsDataQuery
		/// </summary>
		/// <param name="dquery">JsDataQuery json string representation</param>
		/// <returns></returns>
		[HttpPost, Route("getJsDataQuery")]
		public IHttpActionResult getJsDataQuery([FromBody] getJsDataQueryParameters dquery) {
			// trasformo in JObject
			try {

                var filterEvaluatingError = evaluateFilter(dquery.dquery,"");
                if (!string.IsNullOrEmpty(filterEvaluatingError)) {
                    return Content(HttpStatusCode.BadRequest, LoginFailedStatus.FilterWithUndefined + "$__$" + filterEvaluatingError);
                }

                MetaExpression m = (MetaExpression)MetaExpressionSerializer.deserialize(dquery.dquery);
				var jsonRes = DataUtils.metaExpressionToJson(m);
				return Json(jsonRes);
				//return Content(HttpStatusCode.OK, jsonRes);
			}
			catch (Exception e) {
				return Content(HttpStatusCode.InternalServerError,
					"Executing getJsDataQuery(" + dquery + ") : " + e.ToString());
			}
		}

		/// <summary>
		/// Contains the post params for the method select
		/// </summary>
		public class selectCountQueryParameters {
			/// <summary>
			/// Table name
			/// </summary>
			public string tableName { get; set; }

			/// <summary>
			/// Filter to apply
			/// </summary>
			public JToken filter { get; set; }
		}

		/// <summary>
		/// Called by Client, returns the select count on tableName, with filter
		/// </summary>
		/// <param name="prms">tableName and filter to apply</param>
		/// <returns></returns>
		[HttpPost, Route("selectCount")]
		public IHttpActionResult selectCount([FromBody] selectCountQueryParameters prms) {
			var dispatcher = HttpContext.Current.getDataDispatcher();
			var conn = dispatcher.conn;

			string tableName = prms.tableName;
			var filter = prms.filter;

			string filterString = DataUtils.getfilterFromJsDataQuery(filter, dispatcher);

			int count = conn.RUN_SELECT_COUNT(tableName, filterString, false);

			string errorMessage = evaluateLastError("selectCount");
			if (errorMessage != null) {
				return Content(HttpStatusCode.InternalServerError,
					GetAndLogErrorMessage(null, dispatcher.conn, errorMessage, "selectCount",
						"tablename:" + tableName + ", filter:" + filter));
			}

			return Content(HttpStatusCode.OK, count);

		}

		/// <summary>
		/// Parameters for select Commmands
		/// </summary>
		public class selectQueryParameters {
			/// <summary>
			/// Table name
			/// </summary>
			[Required]
			public string tableName { get; set; }

			/// <summary>
			/// Columns to read
			/// </summary>
			public string columnList { get; set; }

			/// <summary>
			/// Optional max number of rows to retrieve
			/// </summary>
			public string top { get; set; }

			/// <summary>
			/// Filter to apply
			/// </summary>
			public JObject filter { get; set; }

			/// <summary>
			/// Request id
			/// </summary>
			public string idRequest { get; set; }
		}

		/// <summary>
		/// Called by Client, select data
		/// </summary>
		/// <param name="prms">parameters</param>
		/// <returns></returns>
		[HttpPost, Route("selectAsync")]
		public async Task<IHttpActionResult> selectAsync([FromBody] selectQueryParameters prms) {
			var dispatcher = HttpContext.Current.getDataDispatcher();
			var dataSender = new HttpDataSender(prms.idRequest, dispatcher);

			// trasformo in JObject per passare al metodo select di DataManager, comune con backend web socket 
			var prmsJobject = new JObject {
				{"tableName", prms.tableName},
				{"columnList", prms.columnList},
				{"top", prms.top},
				{"filter", prms.filter},
			};
			DataManager.selectAsync(prmsJobject, dataSender);

			var res = await dataSender.getResult();
			return Content(res.code, res.answer);
		}

        private string evaluateFilter(JToken filterObj, string tableName) {
			string filter = filterObj.ToString(Formatting.None);
            var filterEvaluatingErrorArray = new List<string>();
            var matches = Regex.Matches(filter, @"\[\{""name"":""field"",""args"":\[\{""value"":""(.*?)""\}\]\},\{\}\]", RegexOptions.Singleline).Cast<Match>().Select(m => m.Value.Trim()).Distinct().ToList();
            if (matches.Count() > 0) {
                foreach (var m in matches) {
                    var cName = m.Replace("[{\"name\":\"field\",\"args\":[{\"value\":\"", "").Replace("\"}]},{}]", "");
                    filterEvaluatingErrorArray.Add("Tabella " + tableName +  " la colonna " + cName + " ha un valore indefinito nella condizione di filtro.");
                }
                return String.Join(" - ", filterEvaluatingErrorArray);
            }


            matches = Regex.Matches(filter, @"""args"":\[\{""value"":""(.*?)""},\{\}\]\}", RegexOptions.Singleline).Cast<Match>().Select(m => m.Value.Trim()).Distinct().ToList();
            if (matches.Count() > 0) {
                foreach (var m in matches) {
                    var cName = m.Replace("\"args\":[{\"value\":\"", "").Replace("\"},{}]}", "");
                    filterEvaluatingErrorArray.Add("Tabella " + tableName + " la colonna " + cName + " ha un valore indefinito nella condizione di filtro.");
                }
                return String.Join(" - ", filterEvaluatingErrorArray);
            }

            
            return "";
        }

		/// <summary>
		/// Reads data from a table
		/// </summary>
		/// <param name="prms">parameters</param>
		/// <returns></returns>
		[HttpPost, Route("select")]
		public IHttpActionResult select([FromBody] selectQueryParameters prms) {
			var dispatcher = HttpContext.Current.getDataDispatcher();

			var conn = dispatcher.conn;

			var filter = prms.filter;
			var tableName = prms.tableName;
			var columnList = prms.columnList;
			var top = prms.top;

			if (top == "") top = null;

			q metaExpr = null;

			if (filter != null) {
               
                try {
                    metaExpr = MetaExpressionSerializer.deserialize(filter) as q;
                }
                catch (Exception e) {

                    var filterEvaluatingError = evaluateFilter(filter, tableName);
                    if (!string.IsNullOrEmpty(filterEvaluatingError)) {
                        GetAndLogErrorMessage(null, dispatcher.conn, e.ToString(), "select", "tablename:" + tableName + ", column list: " + columnList + " filter: " + filter);
                        return Content(HttpStatusCode.BadRequest, LoginFailedStatus.FilterWithUndefined + "$__$" + filterEvaluatingError);
                    }

                    return Content(HttpStatusCode.InternalServerError, GetAndLogErrorMessage(null, dispatcher.conn, e.ToString(), "select",
                        "tablename:" + tableName + ", column list: " + columnList + " filter: " + filter));
                }

            }

            var dt = conn.readTable(tableName, metaExpr, columnList, null, top);
			string errorMessage = evaluateLastError("select");
			if (errorMessage != null) {
				return Content(HttpStatusCode.InternalServerError,
					GetAndLogErrorMessage(null, dispatcher.conn, errorMessage, "select",
						"tablename:" + tableName + ", column list: " + columnList + " filter: " + filter));
			}

			return Content(HttpStatusCode.OK, DataUtils.dataTableToJSon(dt,true, true));

		}



		/// <summary>
		/// Contains the post params for the method multiRunSelect
		/// </summary>
		public class multiRunSelectQueryParameters {
			/// <summary>
			/// Json Serialization of a SelectBuilder[] 
			/// </summary>
			[Required]
			public JToken selBuilderArr { get; set; }

			/// <summary>
			/// id of request
			/// </summary>
			[Required]
			public string idRequest { get; set; }
		}

		/// <summary>
		/// Called by Client, returns datatable asyncronously
		/// </summary>
		/// <param name="prms">multiRunSelectQueryParameters</param>
		/// <returns></returns>
		[HttpPost, Route("multiRunSelectAsync")]
		public async Task<IHttpActionResult> multiRunSelectAsync([FromBody] multiRunSelectQueryParameters prms) {
			var dispatcher = HttpContext.Current.getDataDispatcher();
			var conn = dispatcher.conn;

			var selBuilderArr = prms.selBuilderArr;
			var idRequest = prms.idRequest;

			var dataSender = new HttpDataSender(idRequest, dispatcher);

			//parametro input MULTI_RUN_SELECT_SIMPLIFIED
			var selList = DataUtils.getSelList(selBuilderArr, dispatcher);

			if (selList.Count > 0) {
				DataManager.multiRunSelect(selList, dataSender);
			}

			string errorMessage = evaluateLastError("multiRunSelectAsync");
			if (errorMessage != null) {
				return Content(HttpStatusCode.InternalServerError,
					GetAndLogErrorMessage(null, dispatcher.conn, errorMessage, "multiRunSelectAsync",
						"Query: " + string.Join(" ",selList)));
			}

			var res = await dataSender.getResult();
			return Content(res.code, res.answer);

		}

		/// <summary>
		/// Verifica conn.LastError. se c'è un errore logga e ritorna l'errore.
		/// il chiamante se trova errore popolato tornerà errore 500.
		/// </summary>
		/// <returns></returns>
		private string evaluateLastError(string methodInfo) {
			var dispatcher = HttpContext.Current.getDataDispatcher();
			var conn = dispatcher.conn;
			string errMsg = null;
			string lastError = conn.LastError;
			if (!String.IsNullOrEmpty(lastError)) {
				return GetAndLogErrorMessage(null, conn, lastError, methodInfo, "DB");
			}
			return errMsg;
		}

		/// <summary>
		/// Called by Client, returns datatable asyncronously
		/// </summary>
		/// <param name="prms">multiRunSelectQueryParameters</param>
		/// <returns></returns>
		[HttpPost, Route("multiRunSelect")]
		public IHttpActionResult multiRunSelect([FromBody] multiRunSelectQueryParameters prms) {
			var dispatcher = HttpContext.Current.getDataDispatcher();
			var conn = dispatcher.conn;
			var selBuilderArr = prms.selBuilderArr;
			var idRequest = prms.idRequest;

			var sel = selBuilderArr; //JObject.Parse(selBuilderArr);
			var arr = JArray.FromObject(sel["arr"]);

			var outDs = new DataSet();

			var selList = new List<SelectBuilder>();
			var selListStringArray = new List<string>();

            var filterEvaluatingErrorArray = new List<string>();
            foreach (var objSelBuild in arr) {
				var expr = objSelBuild["filter"];
                var tableName = objSelBuild["tableName"].ToString();

                var filterEvaluatingError = evaluateFilter(expr, tableName);
                if (!string.IsNullOrEmpty(filterEvaluatingError)) {
                    filterEvaluatingErrorArray.Add(filterEvaluatingError);
                    continue;
                }


                var table = DataSetSerializer.jTokenToTable(objSelBuild["table"],true, dispatcher, tableName);
				string top = null;
				if (!String.IsNullOrEmpty(objSelBuild["top"].ToString())) top = objSelBuild["top"].ToString();

				string filterString = DataUtils.getfilterFromJsDataQuery(expr, dispatcher);

				outDs.Tables.Add(table);
				SelectBuilder sb = new SelectBuilder().From(tableName).IntoTable(table).Where(filterString).Top(top);
				string[] columnNames = table.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
				string where = String.IsNullOrEmpty(filterString) ? "" : " where" + filterString;
				selListStringArray.Add("select " + String.Join(",", columnNames) + " from " + tableName + where);
				selList.Add(sb);
			}

            if (filterEvaluatingErrorArray.Count() > 0 ) {
                return Content(HttpStatusCode.BadRequest, LoginFailedStatus.FilterWithUndefined + "$__$" + String.Join(" - ", filterEvaluatingErrorArray));
            }

            string lastError = "";
			if (selList.Count > 0) 
				try
				{
					conn.MULTI_RUN_SELECT(selList);
				}
				catch (Exception e)
				{
					lastError = e.Message;
				}
			if(string.IsNullOrEmpty(lastError))
				lastError = conn.LastError;
			if (!String.IsNullOrEmpty(lastError)) {
				return Content(HttpStatusCode.InternalServerError,
					GetAndLogErrorMessage(outDs, conn, lastError, "multiRunSelect",
						String.Join(";", selListStringArray)));
			}

			// 3. torno il ds popolato solo con i dati che mi aspetto
			var jsonResDataSet = DataUtils.dataSetToJSon(outDs,false);
			return Content(HttpStatusCode.OK, jsonResDataSet);

		}

        public string GetAndLogErrorMessage(DataSet ds, IEasyDataAccess conn, string error, string methodInfo, string metadata)
        {
            BEError bEError = new BEError();
            bEError.conn = conn;
            bEError.error = error + " " + GetDSErrors(ds);
            bEError.methodInfo = methodInfo;
            bEError.metadata = metadata;
            DBLogger.log(bEError);
            return bEError.error;
        }

        public void LogOperationAndData(DataSet ds, IEasyDataAccess conn, string operation, string methodInfo, string metadata)
        {
            BEError bEError = new BEError();
            bEError.conn = conn;
            bEError.error = operation;
            bEError.methodInfo = methodInfo;
            bEError.metadata = metadata;
            DBLogger.log(bEError);
        }


        /// <summary>
        /// Parameters for method getDataSet
        /// </summary>
        public class getDataSetQueryParameters {
			/// <summary>
			/// Name of main dataset table 
			/// </summary>
			[Required]
			public string tableName { get; set; }

			/// <summary>
			/// identifies a dataset, used in conjunction with tableName
			/// </summary>
			[Required]
			public string editType { get; set; }
		}

		/// <summary>
		/// Called by Client, returns a DataSet .net serialized into a JsDataSet json string
		/// </summary>
		/// <param name="prms">tableName / edtiType</param>
		/// <returns></returns>
		[HttpPost, Route("getDataSet")]
		public IHttpActionResult getDataSet([FromBody] getDataSetQueryParameters prms) {
			var tableName = prms.tableName;
			var editType = prms.editType;

			// controllo se utilizza connessione anonima . blocco le operazioni non permesse
			if (!isAnonymousPermitted(tableName, editType, null)) {
				return Content(HttpStatusCode.BadRequest,
					GetAndLogErrorMessage(null, HttpContext.Current.getDataDispatcher().conn,
						LoginFailedStatus.AnonymousNotPermitted, "getDataSet", tableName + " " + editType));
			}

			try {
				var outDs = DataUtils.createEmptyDataSet(tableName, editType);
				if (outDs == null) {
					return Content(HttpStatusCode.BadRequest, $"DataSet non esistente ({tableName}-{editType}).");
				}

				// trasforma il ds costruito in una struttura da serializzare e rinviare al client.
				var jsonResDataSet = DataUtils.dataSetToJSon(outDs,true);

				return Json(jsonResDataSet); //Content(HttpStatusCode.OK, jsonResDataSet);
			}
			catch (Exception ex) {
				var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
				return Content(HttpStatusCode.BadRequest, msg);
			}


		}

		/// <summary>
		/// Parameters for method  fillDataSet
		/// </summary>
		public class fillDataSetQueryParameters {
			/// <summary>
			/// Name of main dataset table 
			/// </summary>
			[Required]
			public string tableName { get; set; }

			/// <summary>
			/// identifies a dataset, used in conjunction with tableName
			/// </summary>
			[Required]
			public string editType { get; set; }

			/// <summary>
			/// json string  serialization of a jsDataQuery
			/// </summary>
			public JToken filter { get; set; } // json string of serialized jsDataQuery
		}

		/// <summary>
		/// Called by Client, returns a DataSet .net serialized into a JsDataSet json string
		/// </summary>
		/// <param name="prms">fillDataSetQueryParameters</param>
		/// <returns></returns>
		[HttpPost, Route("fillDataSet")]
		public IHttpActionResult fillDataSet( fillDataSetQueryParameters prms) {

			var dispatcher = HttpContext.Current.getDataDispatcher();
			var tableName = prms.tableName;
			var editType = prms.editType;
			var filter = prms.filter;

			var sFilter = DataUtils.getfilterFromJsDataQuery(filter, dispatcher);

			// controllo se utilizza connessione anonima . blocco le operazioni non permesse
			if (!isAnonymousPermitted(tableName, editType, null)) {
				return Content(HttpStatusCode.BadRequest,
					GetAndLogErrorMessage(null, HttpContext.Current.getDataDispatcher().conn,
						LoginFailedStatus.AnonymousNotPermitted, "getDataSet", tableName + " " + editType));
			}

			var outDs = DataUtils.createEmptyDataSet(tableName, editType);

			var getData = new GetData();
			getData.InitClass(outDs, dispatcher.Connection, tableName);
			getData.GET_PRIMARY_TABLE(sFilter);

			var dt = outDs.Tables[tableName];
			if (dt.Rows.Count > 0) {
				var dr = dt.First();
				getData.DO_GET(false, dr);
			}


			string errorMessage = evaluateLastError("fillDataSet");
			getData.Destroy();
			if (errorMessage != null) {
				return Content(HttpStatusCode.InternalServerError,
					GetAndLogErrorMessage(outDs, dispatcher.conn, errorMessage, "fillDataSet",
						"tablename:" + tableName + ", editType:" + editType));
			}

			return Content(HttpStatusCode.OK, DataUtils.dataSetToJSon(outDs,false));

		}

		/// <summary>
		/// Contains the post params for the method prefillDataSet
		/// </summary>
		public class PreFillDataSetQueryParameters {
			/// <summary>
			/// Primary table of DataSet
			/// </summary>
			[Required]
			public string tableName { get; set; }

			/// <summary>
			/// Edit type of DataSet
			/// </summary>
			[Required]
			public string editType { get; set; }

			/// <summary>
			/// array of key/value pairs. key:tableName, value:filter jsDataQuery serialized in json
			/// </summary>
			[Required]
			public JObject pairTablefilter { get; set; }
		}


		/// <summary>
		/// Called by Client, returns a DataSet .net serialized into a JsDataSet json string. Fills only the table in the pairTablefilter parameter
		/// </summary>
		/// <param name="prms">Table name</param>
		/// <returns></returns>
		[HttpPost, Route("prefillDataSet")]
		public IHttpActionResult prefillDataSet([FromBody] PreFillDataSetQueryParameters prms) {

			var dispatcher = HttpContext.Current.getDataDispatcher();
			var conn = dispatcher.conn;
			var tableName = prms.tableName;
			var editType = prms.editType;
			var pairTablefilter = prms.pairTablefilter;

			// controllo se utilizza connessione anonima . blocco le operazioni non permesse
			if (!isAnonymousPermitted(tableName, editType, null)) {
				return Content(HttpStatusCode.BadRequest,
					GetAndLogErrorMessage(null, HttpContext.Current.getDataDispatcher().conn,
						LoginFailedStatus.AnonymousNotPermitted, "getDataSet", tableName + " " + editType));
			}

			// 1. ottengo Ds
			var outDs = DataUtils.createEmptyDataSet(tableName, editType);
			if (outDs == null) return Content(HttpStatusCode.BadRequest, "DataSet non esistente.");

			var selList = new List<SelectBuilder>();

			// 2. popolo solo le tabelle passate nel parametro pairTablefilter, insieme al proprio filtro
			var jobj = pairTablefilter;
			foreach (var x in jobj) {
				var tName = x.Key;
				var filter = x.Value;

				if (outDs.Tables[tName] == null)
					return Content(HttpStatusCode.BadRequest, $"Tabella {tName} non esistente.");

				var sFilter = DataUtils.getfilterFromJsDataQuery(filter, dispatcher);

				selList.Add(new SelectBuilder().From(tName).IntoTable(outDs.Tables[tName]).Where(sFilter));
			}

			if (selList.Count > 0) conn.MULTI_RUN_SELECT(selList);

			string errorMessage = evaluateLastError("prefillDataSet");
			if (errorMessage != null) {
				return Content(HttpStatusCode.InternalServerError,
					GetAndLogErrorMessage(outDs, dispatcher.conn, errorMessage, "prefillDataSet",
						"tablename:" + tableName + ", editType:" + editType));
			}

			// 3. torno il ds popolato solo con i dati che mi aspetto
			var jsonResDataSet = DataUtils.dataSetToJSon(outDs,false);
			return Content(HttpStatusCode.OK, jsonResDataSet);

		}

		/// <summary>
		/// Contains the post params for the method getNewRow
		/// </summary>
		public class getNewRowQueryParameters {

			public JToken
				dtChild {
				get;
				set;
			} // N.B il ds in input al metodo va solo in post, altrimenti in get sarebbe troppo grande

			public JToken
				dtParent { get; set; } // contiene una riga ed una sola, nel caso in cui devo creare una riga child

			public string rel { get; set; } // relazione padre figlio

		}

		/// <summary>
		/// Find the same row on table, and return it, null otherwise
		/// </summary>
		/// <param name="table">DataTable</param>
		/// <param name="row">DataRow</param>
		/// <returns></returns>
		private DataRow getSameRowOnTable(DataTable table, DataRow row) {
			foreach (DataRow currRow in table.Rows) {
				if (Enumerable.SequenceEqual(currRow.ItemArray, row.ItemArray))
					return currRow;
			}

			return null;
		}

		/// <returns></returns>
		[HttpPost, Route("getNewRow")]
		public IHttpActionResult getNewRow([FromBody] getNewRowQueryParameters prms) {

			var dispatcher = HttpContext.Current.getDataDispatcher();

			// leggo i prm dal client
			var dtChild = prms.dtChild;
			var dtParent = prms.dtParent;
			var rel = prms.rel;
			DataRow drParent = null;
			// deserializzo il dtChild e dtParent di input
			//var parsedChild = JObject.Parse(dtChild);
			MetaTable myDtChild = DataSetSerializer.jTokenToTable(dtChild, false, dispatcher,null);
			MetaTable myDtParent = null;
			if (dtParent != null) {
				myDtParent = DataSetSerializer.jTokenToTable(dtParent, false, dispatcher,null);
				// recupero la riga tramite la tabella. son sicuro che è la 1a riga. poichè il client passa la padre con una riga
				drParent = myDtParent.Rows[0];
			}

			if (dtParent != null) {
				// NUOVA GESTIONE TRAMITE RELAZIONE 
				// creo ds ex novo, con 2 tabelle e la relazione. Se la tabella è la stessa aggiungo solo child 
				// e mi accerto che ci sai la riga parent, con la riga parent
				var dsTemp = new DataSet();

				// metto figlio solamente se non è uguale al padre, altrimenti metto le righe della child sulla padre
				if (myDtParent.TableName == myDtChild.TableName) {
					// recupero stessa riga, che diventa la nuova drParent da passare alla getNewRow. se per qualche motivo non appartiene all child la inserisco
					DataRow drParentOnChild = getSameRowOnTable(myDtChild, drParent);
					if (drParentOnChild != null) {
						drParent = drParentOnChild;
					}
					else {
						myDtChild.ImportRow(drParent);
						drParent = getSameRowOnTable(myDtChild, drParent);
					}
				}
				else {
					// aggiungo tabella padre
					dsTemp.Tables.Add(myDtParent);
				}

				// aggiungo la figlia
				dsTemp.Tables.Add(myDtChild);
				// deserializzo relazione e linko al ds
				var objrel = (JObject)JsonConvert.DeserializeObject(rel.ToString());
				DataSetSerializer.createRelationFromJToken("tempRel", objrel, dsTemp);
			}


			// recupero metaDato, per invocare il metodo Get_New_Row()
			// Devono esserci i default impostati lato client sulla tabella myDtChild
			var mainMeta = dispatcher.GetMeta(myDtChild.TableForReading);

			// invoco il metodo lato server, passando il row parent e il dt corrente dove inserire la riga
			// TODO: questo non andrebbe fatto, i default devono essere inviati dal client

			mainMeta.SetDefaults(myDtChild);
			var rOut = mainMeta.Get_New_Row(drParent, myDtChild);
			// questo imposta implicitamente i vari selettori, campi ad autoincremento e via dicendo


			// ******** Inizio operazioni per mandare l'output ***************

			// Costruisco filter in output per permettere l'individuazione della riga lato js
			var filterOut = MetaExpression.keyCmp(rOut);

			// serializzo filtro
			var filterOutObjJson = DataUtils.metaExpressionToJson(filterOut);
			// serializzo DataTable di output
			var myDtChildOutJson = DataUtils.dataTableToJSon(myDtChild,true, true);
			// qui se tutto funziona i campi selettori e via dicendo dovrebbero essere serializzati
			// attenzione bisogna capire se c'è da fare ulteriore lavoro per i campi customautoincrement la cui proprietà non è 
			//  serializzabile e quindi credo che bisogna artificialmente imporre un autoincremento generico 

			// invio al client un json obj formato da dt con la nuova riga, che dovrò unire sul frontend + il filtro per individuare la riga
			var result = new JObject {
				{"dt", myDtChildOutJson},
				{"filter", filterOutObjJson}
			};

			return Content(HttpStatusCode.OK, result);

		}

		/// <summary>
		/// Contains the post params for the method doGet
		/// </summary>
		public class doGetQueryParameters {
			[Required]
			public JToken
				ds {
				get;
				set;
			} // N.B il ds in input al metodo va solo in post, altrimenti in get sarebbe troppo grande

			[Required]
			public string primaryTableName { get; set; }

			public JToken filter { get; set; }

			[Required]
			public bool onlyPeripherals { get; set; }
		}

		/// <summary>
		/// Given a row returns the dataset populated with eventually pheripheral tables
		/// </summary>
		/// <param name="prms"></param>
		/// <returns></returns>
		[HttpPost, Route("doGet")]
		public IHttpActionResult doGet([FromBody] doGetQueryParameters prms) {

			// Inizializzo GetData
			var dispatcher = HttpContext.Current.getDataDispatcher();
			var ds = prms.ds;
			var primaryTableName = prms.primaryTableName;
			var filter = prms.filter;
			var onlyPeripherals = prms.onlyPeripherals;
			DataSet myds = null;
			try {

				myds = DataSetSerializer.deserialize(ds,true, dispatcher); //JObject.Parse(ds)

				var getData = new GetData();
				getData.InitClass(myds, dispatcher.Connection, primaryTableName);

				// trasformo il json dataquery in metaExpression 
				MetaExpression metaExprDeserialized = DataUtils.getMetaExpressionFromJsonDataQuery(filter);

				MetaTable dt = (MetaTable)myds.Tables[primaryTableName];
				// recupero la riga tramite la tabella e il filtro su di essa, passato dal client
				DataRow dr = getDataRowFromTableFiltered(dt, metaExprDeserialized);

				getData.DO_GET(onlyPeripherals, dr);
				string errorMessage = evaluateLastError("doGet");
				if (errorMessage != null) {
					return Content(HttpStatusCode.InternalServerError,
					GetAndLogErrorMessage(myds, dispatcher.conn, errorMessage, "doGet",
						"primary tablename:" + primaryTableName + ", filter:" + filter));
				}

                // la risposta non torna le righe delle tab principale  e subentità perchè nel caso di onlyPeripherals non serve
                // serve in input al backend per il calcolo esatto delle righe nelle tabelle perificheriche , ma al ritorno evito di serializzarle
                // poichè il client già le ha.
                Hashtable Visited = new Hashtable();
                Hashtable ToVisit = new Hashtable();
                if (onlyPeripherals) {
                    getVisited(myds, Visited, ToVisit, dt);
                    foreach (DictionaryEntry s in Visited) {
                         myds.Tables[(String)s.Key].Clear();
                    }
                }
               
                // Torno il ds popolato solo con i dati che mi aspetto
                var jsonResDataSet = DataUtils.dataSetToJSon(myds,false);

				getData.Destroy();

				return Content(HttpStatusCode.OK, jsonResDataSet);
			}
			catch (Exception e) {
				return Content(HttpStatusCode.InternalServerError,
					GetAndLogErrorMessage(myds, dispatcher.conn, e.Message, "doGet", 
						"primary tablename " + primaryTableName + ", filter:" + filter));
			}

		}

        /// <summary>
        /// Get Visited hashtable with the tables that will not affected to refresh if only pheripheral are read
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <param name="Visited"></param>
        /// <param name="ToVisit"></param>
        /// <param name="PrimaryDataTable"></param>
        private void getVisited(DataSet ds, Hashtable Visited, Hashtable ToVisit, DataTable PrimaryDataTable) {
          
                //Marks child tables as ToVisit+Visited
                recursivelyMarkSubEntityAsVisited(PrimaryDataTable, Visited, ToVisit);
            
                foreach (DataTable T in ds.Tables) {
                    string childtable = T.TableName;
                    if (!canClear(T)) {
                        Visited[childtable] = T;
                        ToVisit[childtable] = T;
                    }
                }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mainTable"></param>
        /// <param name="Visited"></param>
        /// <param name="ToVisit"></param>
        private void recursivelyMarkSubEntityAsVisited(DataTable mainTable, Hashtable Visited, Hashtable ToVisit) {
            var model = MetaFactory.factory.getSingleton<IMetaModel>();
            foreach (DataRelation Rel in mainTable.ChildRelations) {
                string childtable = Rel.ChildTable.TableName;
                string parentTable = Rel.ParentTable.TableName;
                if ((!DataUtils.isSubEntityOrNotEntityChild(Rel, Rel.ChildTable, mainTable) &&  model.canClear(Rel.ChildTable)) 
                    || Visited.ContainsKey(childtable)) continue; //if continue--> it will be cleared
                //Those tables will not be cleared
                Visited[childtable] = Rel.ChildTable;
                ToVisit[childtable] = Rel.ChildTable;
                recursivelyMarkSubEntityAsVisited(Rel.ChildTable, Visited, ToVisit);                
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="T"></param>
        /// <returns></returns>
        private bool canClear(DataTable T) {
            if (T.ExtendedProperties["DenyClear"] == null) return true;
            return false;

        }

        /// <summary>
        /// Returns the first DataRow of the Table dt, filtered on  filter
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        private DataRow getDataRowFromTableFiltered(MetaTable dt, MetaExpression filter) {
			DataRow dr = null;
			if ((filter != null) && (dt != null)) {
				var rows = dt.Filter(filter);
				if (rows.Length > 0) {
					dr = rows[0];
				}
			}

			return dr;
		}


		public class getDsByRowKeyParameters {

			public string tableName { get; set; }

			public string editType { get; set; }

			public JToken filter { get; set; }
		}

		/// <summary>
		/// Gets Dataset "tableName"_"editType" filling all the tables with the rows linked to the row found on tableNmae with clause "filter"
		/// </summary>
		/// <param name="tableName"></param>
		/// <param name="editType"></param>
		/// <param name="filter"></param>
		/// <returns></returns>
		[HttpPost, Route("getDsByRowKey")]
		public IHttpActionResult getDsByRowKey([FromBody] getDsByRowKeyParameters prms) {

			string tableName = prms.tableName;
			string editType = prms.editType;
			var filter = prms.filter;

			Dispatcher dispatcher = HttpContext.Current.getDataDispatcher();
			DataSet outDs = DataUtils.createEmptyDataSet(tableName, editType);
            DataTable dt = null;

            try {
				// controllo se utilizza connessione anonima . blocco le operazioni non permesse
				if (!isAnonymousPermitted(tableName, editType, null)) {
					return Content(HttpStatusCode.BadRequest, LoginFailedStatus.AnonymousNotPermitted);
				}

				// recupero DS 
				if (outDs == null) return Content(HttpStatusCode.BadRequest, "DataSet non esistente.");

				// Inizializzo GetData

				var getData = new GetData();
				getData.InitClass(outDs, dispatcher.Connection, tableName);

				// 1. Eseguo la SEARCH_BY_KEY, rivista, poichè dal client mi arriva già il filtro. Capire con Nino se va bene!!
				var sFilter = DataUtils.getfilterFromJsDataQuery(filter, dispatcher);
				getData.ReadCached();
				dt = outDs.Tables[tableName];
				dispatcher.conn.RUN_SELECT_INTO_TABLE(dt, dt.getSorting(), sFilter, null, false);
                string errorMessage = dispatcher.conn.LastError;
                if (!String.IsNullOrEmpty(errorMessage)) {
                    return Content(HttpStatusCode.InternalServerError,
                    GetAndLogErrorMessage(outDs, dispatcher.conn, GetDTErrors(dt) + errorMessage, "getDsByRowKey",
                        "tablename:" + tableName + ", editType:" + editType));
                }

                // 2. Eseguo DO_GET
                getData.DO_GET(false, null);

				errorMessage = evaluateLastError("getDsByRowKey");
				if (errorMessage != null) {
					return Content(HttpStatusCode.InternalServerError,
						GetAndLogErrorMessage(outDs, dispatcher.conn, errorMessage, "getDsByRowKey",
							"tablename:" + tableName + ", editType:" + editType));
				}

				// bonifico dataset per i campi byte[]
				AttachmentUtils.sanitizeDsForAttach(outDs);
				List<DataRelation> relsToRemove = new List<DataRelation>();
				List<DataTable> tablesToRemove =	new List<DataTable>();
				foreach (DataTable t in outDs.Tables) {
					if (t.Rows.Count == 0) {
						foreach(DataRelation r in outDs.Relations) {
							if (r.ParentTable==t || r.ChildTable==t) {
								relsToRemove.Add(r);
							}
						}
						tablesToRemove.Add(t);
					}
				}
				relsToRemove.ForEach(r => { if (outDs.Relations.Contains(r.RelationName)) { outDs.Relations.Remove(r);} });
				tablesToRemove.ForEach(t=> { outDs.Tables.Remove(t); });
				
				// Torno il ds popolato solo con i dati che mi aspetto
				var jsonResDataSet = DataUtils.dataSetToJSon(outDs,false);

				getData.Destroy();

                LogOperationAndData(outDs, dispatcher.conn, tableName + "," + editType, "getDsByRowKey", sFilter);

                return Content(HttpStatusCode.OK, jsonResDataSet);

			}
			catch (Exception e) {
				return Content(HttpStatusCode.InternalServerError,
					GetAndLogErrorMessage(outDs, dispatcher.conn, e.Message, "getDsByRowKey",
						"tablename:" + tableName + ", editType:" + editType));
			}
		}


		public string GetDSErrors(DataSet ds) {
			if (ds == null) return "";

			var errors = "";
			foreach (DataTable table in ds.Tables) {
                errors += GetDTErrors(table) + " - ";
			}

			return errors;
		}

        private string GetDTErrors(DataTable table) {
            var errors = "";
            if (table == null) return "";
            foreach (DataRow dtrow in table.Rows) {
                // concateno errori presenti sulle righe
                String tErrors = "";
                if (dtrow.RowError != null && dtrow.RowError.Length > 0 && !errors.Contains(dtrow.RowError)) {
                    tErrors = " - " + dtrow.RowError;
                }

                if (tErrors.Length > 0) {
                    errors = errors + " Table " + table.TableName + ": " + tErrors;
                }
            }
            return errors;
        }


		/// <summary>
		/// Returns a DataTable, with expected structure, based on the name of the table passed as parameter
		/// </summary>
		/// <param name="tableName"></param>
		/// <param name="columnList"></param>
		/// <returns></returns>
		[HttpGet, Route("createTableByName")]
		public IHttpActionResult createTableByName(string tableName, string columnList) {
			// Inizializzo GetData
			var dispatcher = HttpContext.Current.getDataDispatcher();
			var dt = dispatcher.conn.CreateTableByName(tableName, columnList);

			// Torno il ds popolato solo con i dati che mi aspetto
			var jsonResDataTable = DataUtils.dataTableToJSon(dt,true, true);

			return Content(HttpStatusCode.OK, jsonResDataTable);
		}


		/// <summary>
		/// Executes the mapping of tableName and listType on "web_listredir" table taking a new tableName (usually a custom view) and a new listType
		/// </summary>
		/// <param name="tableName">string</param>
		/// <param name="listType">string</param>
		/// <returns>string[]</returns> an array of 2 strings. At the first position the new tableName, at the second the new listType 
		private string[] getMappingWebListRedir(string tableName, string listType) {
			var dispatcher = HttpContext.Current.getDataDispatcher();
			var conn = dispatcher.conn;

			string[] arrayMapped = new string[2];

			// prendo newtablename, newlisttype
			var qh = dispatcher.QueryHelper;
			string FilterForListRedir;
			string newtablename = "";
			string newlisttype = "";
			// eseguo query
			FilterForListRedir = qh.AppAnd(qh.CmpEq("tablename", tableName), qh.CmpEq("listtype", listType));
			DataTable DT = conn.RUN_SELECT("web_listredir", "*", null, FilterForListRedir, null, false);
			if (DT.Rows.Count > 0) {
				DataRow DR = DT.Rows[0];
				newtablename = DR["newtablename"].ToString();
				newlisttype = DR["newlisttype"].ToString();
			}

			// se esiste mapping prendo nuovi valori, altrimenti confermo i vecchi
			newtablename = (newtablename.Length != 0) ? newtablename : tableName;
			newlisttype = (newlisttype.Length != 0) ? newlisttype : listType;

			arrayMapped[0] = newtablename;
			arrayMapped[1] = newlisttype;
			return arrayMapped;
		}

		/// <summary>
		/// Contains the post params for the method getPagedTable
		/// </summary>
		public class getPagedTableQueryParameters {
			[Required]
			public string
				tableName {
				get;
				set;
			} // N.B il ds in input al metodo va solo in post, altrimenti in get sarebbe troppo grande

			[Required]
			public int nPage { get; set; }

			[Required]
			public int nRowPerPage { get; set; }

			public JToken filter { get; set; }
			public string listType { get; set; }
			public string sortby { get; set; }
		}


		/// <summary>
		/// Returns data from table "tableName" paged based on the parameters
		/// </summary>
		/// <param name="tableName"></param>
		/// <param name="totPages"></param>
		/// <param name="nRowPerPage"></param>
		/// <param name="nPage"></param>
		/// <param name="sortby"></param>
		/// <param name="filter"></param>
		/// <returns></returns>
		[HttpPost, Route("getPagedTable")]
		public IHttpActionResult getPagedTable([FromBody] getPagedTableQueryParameters prms) {
			var dispatcher = HttpContext.Current.getDataDispatcher();
			var conn = dispatcher.conn;

			string OrderByClause = "";
			//string ReverseOrderByClause = "";
			string WhereClause = "";

			// recupero parametri
			string tableName = prms.tableName;
			int nPage = prms.nPage;
			int nRowPerPage = prms.nRowPerPage;
			var filter = prms.filter;
			string listType = prms.listType;
			string sort = prms.sortby;


			string filterString = DataUtils.getfilterFromJsDataQuery(filter, dispatcher);

			// 1. Mappatura con tabella web_listredir
			string[] arrayMapped = getMappingWebListRedir(tableName, listType);
			string newtablename = arrayMapped[0];
			string newlisttype = arrayMapped[1];

			var dtOriginal = dispatcher.conn.CreateTableByName(newtablename, "*");

			// Prendo il meta
			var meta = dispatcher.GetMeta(newtablename);

			// calcolo il sort_by
			var sortMeta = meta.GetSorting(newlisttype);

			if (dtOriginal.Columns.Count == 0) {

                return Content(HttpStatusCode.BadRequest,
                    GetAndLogErrorMessage(null, dispatcher.conn, "La tabella/vista " + newtablename + " non è censita sulle tabelle di configurazione opportune", "getPagedTable",
                        "tablename:" + newtablename));

			}

			// La paginazione richiede il sort, quindi:
			// sorting dal client (esiste un metadato javascript col metodo getsorting)
			// oppure perchè dal client, negli elenchi viene fatto un ordinamento su colonn
			// prendiamo il Sorting dal metadato backend,
			// altrimenti se esiste la colonna "title",
			// altrimenti come fallback la prima colonna
			string sort_by = sort != null
				? sort
				: (sortMeta != null
					? sortMeta
					: (dtOriginal.Columns["title"] != null ? "title" : dtOriginal.Columns[0].ColumnName));

			// INIZIO COSTRUZIONE QUERY PAGINATA *****************
			// Calcolo WHERE
			if (filterString != null && filterString.Length > 0) {
				WhereClause = " WHERE " + filterString;
			}

			// Prendo lo staticFilter. in mdl ce l'avevo già sul filter
			// preso dal GetStaticFilter() dell metadato. Ma in mdlw lo leggo in questa fase
			string staticfilter = meta.GetStaticFilter(newlisttype);
			// concateno lo staticFilter del metadato
			if (staticfilter != null && staticfilter.Length > 0) {
				if (WhereClause.Length > 0) {
					WhereClause = WhereClause + " AND " + "(" + staticfilter + ")";
				}
				else {
					WhereClause = " WHERE " + staticfilter;
				}
			}

			// filtro di sicurezza
			string securityFilter = conn.Security.SelectCondition(newtablename, true);
			if (securityFilter != null && securityFilter.Length > 0) {
				if (WhereClause.Length > 0) {
					WhereClause = WhereClause + " AND " + "(" + securityFilter + ")";
				}
				else {
					WhereClause = " WHERE " + securityFilter;
				}
			}
			// FINE CALCOLO WHERE *******

			// calcolo totPage 
			Double totPages = 0;
			// il filtro da passare alla run_select_count è senza where, solo con le clausole
			int totrows = conn.RUN_SELECT_COUNT(newtablename, WhereClause.Replace("WHERE", ""), false);
			if (totrows % nRowPerPage == 0) {
				totPages = totrows / nRowPerPage;
			}
			else {
				totPages = Math.Round((Double)(totrows / nRowPerPage)) + 1;
			}


			if (sort_by != null && sort_by != "") {
				OrderByClause = " ORDER BY " + sort_by + " ";
				//ReverseOrderByClause = " ORDER BY " + DataUtils.GetReverseOrderByClause(sort_by);
			}

			string query = "";
			if (totPages < 2 || sort_by == null) {
				query = "SELECT " + " * " + "  from " + newtablename + WhereClause + OrderByClause;
			}
			else {

				int firstrow = (nPage - 1) * nRowPerPage + 1;
				//int lastrow = nPage * nRowPerPage;
				// se il numero di righe è maggiore delle totali allora il delta lo calcolo in base al nuovo massimo
				//lastrow = (lastrow > totrows) ? totrows : lastrow;
				// calcolo il num di righe da torare su, oppure quelle rimaste nell'ultimo pacchetto
				//int delta = lastrow - firstrow + 1;
				// select * from <tabella>  order by <colonna> offset 1000 rows fetch next 100 rows only
				//query += "SELECT * from (";
				//query += "SELECT TOP " + delta.ToString() + " * FROM (";
				//query += "SELECT TOP " + lastrow.ToString() + " * " +
				//         " FROM " + newtablename +
				//            WhereClause +
				//            OrderByClause + ") AS Q1 ";
				//query += ReverseOrderByClause + ") AS " + newtablename + OrderByClause;

				//sort_by = "title";
				query = @"select top " + nRowPerPage + " * from ( SELECT ROW_NUMBER() OVER (ORDER BY " + sort_by +
						") row_num, * FROM " + newtablename + WhereClause + " ) x where row_num >= " +
						firstrow.ToString();
			}

			// FINE COSTRUZIONE QUERY ********************
			DataTable dtPaged = conn.SQLRunner(query);

			if (dtPaged == null) return Content(HttpStatusCode.BadRequest, "Query error: " + query);

			dtPaged.TableName = newtablename;
			// Assegno chiave, prendendo dalla primaryKey() sul meta. (prox istruzione dovrebe esser sempre vera)
			if (dtPaged.PrimaryKey.Length == 0) {

				if (dtOriginal.PrimaryKey.Length > 0) {
					DataColumn[] arrayKey = dtOriginal.PrimaryKey;
					if (arrayKey != null) {
						DataColumn[] newPrimaryKey = arrayKey.Select(col => dtPaged.Columns[col.ColumnName]).ToArray();
						dtPaged.PrimaryKey = newPrimaryKey;
					}
				}
				else {
					string[] arrayKey = meta.primaryKey();
					if (arrayKey == null) {
                        return Content(HttpStatusCode.BadRequest, GetAndLogErrorMessage(null, dispatcher.conn, "Definire sul metadato di " + newtablename + " una primaryKey()", "getPagedTable",
                       "tablename:" + newtablename));
					}

					try {
					    // assegna al dt di output la chiave letta sul meta dato. in questo caso configurata su db    
                        DataColumn[] newPrimaryKey = new DataColumn[arrayKey.Length];
                        for (var i = 0; i < arrayKey.Length; i++) {
                            if (dtPaged.Columns[arrayKey[i]] == null) {
                                return Content(HttpStatusCode.BadRequest, GetAndLogErrorMessage(null, dispatcher.conn, "Error assigning dtPaged.PrimaryKey = newPrimaryKey. Column " + arrayKey[i] + " IN meta.primaryKey, NOT IN " + dtPaged.TableName, "getPagedTable",
                    "tablename:" + newtablename));
                            }
                            newPrimaryKey[i] = dtPaged.Columns[arrayKey[i]];
                        }
                        dtPaged.PrimaryKey = newPrimaryKey;
					}
					catch (Exception e) {
                        return Content(HttpStatusCode.BadRequest, GetAndLogErrorMessage(null, dispatcher.conn, "Error assigning dtPaged.PrimaryKey = newPrimaryKey " + e.Message, "getPagedTable",
                      "tablename:" + newtablename));
                     
					}

				}
			}

			// Assegno il sorting
			dtPaged.ExtendedProperties["sort_by"] = sort_by;

			//Prendo lo staticFilter->trasformo in ME->serializzo in jsDQuery
			// assegno alla proprietò filter che poi serializzerò
			if (staticfilter != null && staticfilter.Length > 0) {
				dtPaged.ExtendedProperties["filter"] = q.fromString(staticfilter);
			}

			// 7. invoco describeColumns su nuovo meta con nuovi prm 
			meta.DescribeColumns(dtPaged, newlisttype);

			// 8. preparo i risultati
			// il totPage serve al client per capire quante pagine ci sono
			var jsonResDataTable = DataUtils.dataTableToJSon(dtPaged,true,	true);
			var result = new JObject {
				{"dt", jsonResDataTable},
				{"totpage", totPages},
                {"totrows", totrows}
            };

			// 9. loggo l'operazione
            LogOperationAndData(null, dispatcher.conn, tableName + "," + newlisttype, "getPagedTable", query);

            // 10. Torno il result popolato solo con i dati che mi aspetto.
            return Json(result);
			//return Content(HttpStatusCode.OK, result);

		}

		/// <summary>
		/// Contains the post params for the method GetSpecificChild
		/// </summary>
		public class getSpecificChildQueryParameters {
			[Required]
			public JToken
				dt {
				get;
				set;
			} // N.B il ds in input al metodo va solo in post, altrimenti in get sarebbe troppo grande

			public JToken startconditionfilter { get; set; }

			public string startval { get; set; }

			public string startfield { get; set; }

		}

        /// <summary>
        /// Gets a row from a table T taking the first row by the filter
        ///  StartCondition AND (startfield like startval%)
        /// If more than oe row is found, the one with the smallest startfield is
        ///  returned. Used for AutoManage functions.
        /// </summary>
		[HttpPost, Route("GetSpecificChild")]
		public IHttpActionResult GetSpecificChild([FromBody] getSpecificChildQueryParameters prm) {
			var dispatcher = HttpContext.Current.getDataDispatcher();
			var conn = dispatcher.conn;
			var qh = dispatcher.QueryHelper;

			var startfield = prm.startfield;
			var startval = prm.startval;
			var startConditionFilter = prm.startconditionfilter;
			var dtSerialized = prm.dt;
			var dt = DataSetSerializer.jTokenToTable(dtSerialized, true, dispatcher,null);//JObject.Parse(dtSerialized)

			string startcondition = DataUtils.getfilterFromJsDataQuery(startConditionFilter, dispatcher);
			string filter = qh.AppAnd(startcondition, qh.Like(startfield, startval));

			conn.RUN_SELECT_INTO_TABLE(dt, "len(" + startfield + ")", filter, null, true);

			string errorMessage = evaluateLastError("GetSpecificChild");
			if (errorMessage != null) {
				return Content(HttpStatusCode.InternalServerError,
					GetAndLogErrorMessage(dt.DataSet, dispatcher.conn, errorMessage, "getSpecificChild",
						"tablename:" + dt.TableName + ", len:" + startfield + ", filter: " + filter));
			}

			DataRow drOut = null;
			if (dt.Rows.Count != 0) {
				drOut = dt.Rows[0];
			}

			JObject filterOutObjJson = null;
			if (drOut != null) {
				// Costruisco filter in output per permettere l'individuazione della riga lato js
				var filterOut = MetaExpression.keyCmp(drOut);

				// serializzo filtro
				filterOutObjJson = DataUtils.metaExpressionToJson(filterOut);
			}

			// serializzo DataTable di output
			var dtOutJson = DataUtils.dataTableToJSon(dt,true, true);

			// invio al client un json obj formato da dt con la riga cercata, +  il filtro per individuare la riga
			var result = new JObject {
				{"dt", dtOutJson},
				{"filter", filterOutObjJson}
			};

			return Content(HttpStatusCode.OK, result);
		}


		/// <summary>
		/// Contains the post params for the method describeColumns
		/// </summary>
		public class desrColQueryParameters {
			[Required]
			public JToken dt { get; set; }

			[Required]
			public string listType { get; set; }

		}

		/// <summary>
		/// Called by Client, calls a specific DescribeColumns of the metadata
		/// </summary>
		/// <param name="prm">desrColQueryParameters</param>
		/// <returns></returns>
		[HttpPost, Route("describeColumns")]
		public IHttpActionResult describeColumns([FromBody] desrColQueryParameters prm) {
			var dispatcher = HttpContext.Current.getDataDispatcher();
			var conn = dispatcher.conn;

			var listType = prm.listType;
			var dtSerialized = prm.dt;
			var dt = DataSetSerializer.jTokenToTable(dtSerialized, true, dispatcher,null);

			// recupero il meta della tabella
			string tName = DataAccess.GetTableForReading(dt);
			var meta = dispatcher.GetMeta(tName);

			// 3. prendo il sorting
			string sort_by = meta.GetSorting(listType);
			dt.ExtendedProperties["sort_by"] = sort_by;

			// 4. prendo la staticFilter -> trasformo in ME -> serializzo in jsDQuery
			string statfilter = meta.GetStaticFilter(listType);
			// assegno alla proprietò filter che poi serializzerò
			if (statfilter != null && statfilter.Length > 0) {
				dt.ExtendedProperties["filter"] = q.fromString(statfilter);
			}

			// invoco la describe column del metadato specifico della tabella
			meta.DescribeColumns(dt, listType);

			// Torno il dt popolato solo con i dati che mi aspetto
			var jsonResDataTable = DataUtils.dataTableToJSon(dt,false, true);
			return Content(HttpStatusCode.OK, jsonResDataTable);
		}

		/// <summary>
		/// Contains the post params for the method describeColumns
		/// </summary>
		public class desrcTreeParameters {
			[Required]
			public JToken dt { get; set; }

			[Required]
			public string listType { get; set; }

		}

		/// <summary>
		/// Called by Client, call a specific describeTree of the columns
		/// </summary>
		/// <param name="tableName"></param>
		/// <param name="listType"></param>
		/// <returns></returns>
		[HttpPost, Route("describeTree")]
		public IHttpActionResult describeTree([FromBody] desrcTreeParameters prms) {
			var dispatcher = HttpContext.Current.getDataDispatcher();
			var conn = dispatcher.conn;

			var listType = prms.listType;
			var dtSerialized = prms.dt;
			var dt = DataSetSerializer.jTokenToTable(dtSerialized, false, dispatcher, null);

			// recupero il meta della tabella
			string tableName = DataAccess.GetTableForReading(dt);
			// TODO per ora è cablato l'esempio upb tree, vedere poi come integrare con mdl già esistente
			// Bisogna estrapolare in funz pubbliche richiamabili la parte del describe tree dei emtaDati prima
			// di effettuare la new del treeViewManager


			var qh = dispatcher.QueryHelper;

			// Vale per ora per questa coppia die sempio
			if (tableName == "upb" && listType == "tree") {
				var maxDepth = 9;
				// recupero il meta della tabella
				var meta = dispatcher.GetMeta(tableName);
				var filterc = q.isNull("paridupb");
				var rootCondition = DataUtils.metaExpressionToJson(filterc);

				bool withdescr = false;

				// Torno il dt popolato solo con i dati che mi aspetto
				var result = new JObject {
					{"withdescr", withdescr},
					{"rootCondition", rootCondition},
					{"maxDepth", maxDepth}
				};

				return Content(HttpStatusCode.OK, result);
			}

			if (tableName == "menuweb" && listType == "tree") {

				var filterc = q.eq("idmenuweb", 1);

				var rootCondition = DataUtils.metaExpressionToJson(filterc);
				int maxlevel = 3;
				// Torno il dt popolato solo con i dati che mi aspetto
				var result = new JObject {
					{"rootCondition", rootCondition},
					{"maxlevel", maxlevel},
				};

				return Content(HttpStatusCode.OK, result);
			}

			if (tableName == "finview" && listType == "tree") {
				int esercizio = Convert.ToInt32(conn.GetSys("esercizio"));
				int esercizionew = esercizio + 1;
				var filterc = q.eq("nlevel", 1);
				var rootCondition = DataUtils.metaExpressionToJson(filterc);
				string kind = "ES";
				bool all = false;

				var filteresercizio = q.eq("ayear", esercizio);

				if (listType == "tree") {
					kind = "ES";
				}

				int maxlevel = 0;
				object o = conn.DO_READ_VALUE("finlevel", qh.CmpEq("ayear", esercizio), "max(nlevel)");
				if ((o != null) && (o != DBNull.Value)) maxlevel = Convert.ToInt32(o);

				// Torno il dt popolato solo con i dati che mi aspetto
				var result = new JObject {
					{"maxlevel", maxlevel},
					{"all", all},
					{"kind", kind},
					{"rootCondition", rootCondition}, {
						"levelop", (int) conn.GetSys("finusablelevel")
                    }

				};

				return Content(HttpStatusCode.OK, result);


			}


			return Content(HttpStatusCode.OK, "tree not managed");

		}

		/// <summary>
		/// Contains the post params for the method getPagedTable
		/// </summary>
		public class getCopyChildsQueryParameters {
			[Required]
			public JToken dsIn { get; set; } // ds di input con le righe da copiare 

			public JToken dtPrimary { get; set; } // Ds che verrà emrgiato sul client con le nuove righe calcolate

			public JToken filterPrimary { get; set; }

			public JToken filterInsertRow { get; set; }

			public string editType { get; set; }

		}

		/// <summary>
		/// Called to copy all the childs of a parenten Row (just calculated as new row of primary table).
		/// </summary>
		/// <param name="prm"></param>
		/// <returns></returns>
		[HttpPost, Route("getNewRowCopyChilds")]
		public IHttpActionResult getNewRowCopyChilds([FromBody] getCopyChildsQueryParameters prm) {
			var dispatcher = HttpContext.Current.getDataDispatcher();
			var conn = dispatcher.conn;
			var qh = dispatcher.QueryHelper;

			var dsInPrm = prm.dsIn;
			var dtPrimary = prm.dtPrimary;
			var filterPrimary = prm.filterPrimary;
			var filterInsertRow = prm.filterInsertRow;
			var editType = prm.editType;
			var tableName = "";

			/****************** Costrusci dt principale e ds di output ************************/
			MetaTable myDtParent = DataSetSerializer.jTokenToTable(dtPrimary, false, dispatcher,null);
			// deserializzo riga nuova padre inserita
			MetaExpression metaExprFilterInsertRow = DataUtils.getMetaExpressionFromJsonDataQuery(filterInsertRow);
			DataRow rowToInsert = getDataRowFromTableFiltered(myDtParent, metaExprFilterInsertRow);
            // Recupero il dataset in questione poichè la getnewRow ha bisogno della relazione. 
            // il tableBName del ds è quello della tabella parent passata
            tableName = myDtParent.TableName;
			DataSet outDs = DataUtils.createEmptyDataSet(tableName, editType);
			// evito check di coerenza effettuati dal framework .net
			ClearDataSet.RemoveConstraints(outDs);
			// travaso i miei dati su questo dataset, poi invocherò la Get_New_Row su questi nuovi oggetti, che sono però linkati al giusto DataSet
			// travaso la riga parent
			DataTable newParentDataTable = outDs.Tables[tableName];
            // inizializzo prm da passare alla get_new_row di mdl. 
            // ---> Se esiste la riga parent,
            // allora devo calcolare il ds giusto poicè servono le relazioni etc..
            DataRow newRowParent = newParentDataTable.NewRow();
            newRowParent.ItemArray = rowToInsert.ItemArray;
			newParentDataTable.Rows.Add(newRowParent);
			// FINE calcolo ds outDs nuovo con i dati del client
			//********************************************************************************

			/********** DS e riga principaledi input da copiare ******************************/
			// 1. deserializzo strutture dati
			var DSin = DataSetSerializer.deserialize(dsInPrm, false,dispatcher);
			// deserializzo riga padre
			MetaTable myDtParentIn = (MetaTable)DSin.Tables[tableName];
			// recupero la riga Parent tramite il nome tabella e il filtro su di essa, passato dal client
			MetaExpression metaExprFilter = DataUtils.getMetaExpressionFromJsonDataQuery(filterPrimary);
			// recupero la riga tramite la tabella e il filtro su di essa, passato dal client
			DataRow primaryRowCopy = getDataRowFromTableFiltered(myDtParentIn, metaExprFilter);
			//*******************************************************************************

			// DEEP cop effettivo. copia i figli dei figli ricorsivamente
			recursiveNewCopyChilds(newRowParent, primaryRowCopy, outDs);

			// trasforma il ds costruito in una struttura da serializzare e rinviare al client.
			var jsonResDataSet = DataUtils.dataSetToJSon(outDs,false);

			return Json(jsonResDataSet); // Content(HttpStatusCode.OK, jsonResDataSet);

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="destRow"></param>
		/// <param name="sourceRow"></param>
		/// <param name="outDs"></param>
		void recursiveNewCopyChilds(DataRow parentRow, DataRow sourceRow, DataSet outDs) {
			var dispatcher = HttpContext.Current.getDataDispatcher();
			// Ciclo sulle relazioni e poi sulle righe child.  Vedi parte centrale del metodo EditNewCopy mdl su MetaData.cs
			DataRelationCollection relC = sourceRow.Table.ChildRelations;
			foreach (DataRelation rel in relC) {
				if (QueryCreator.SkipInsertCopy(rel.ChildTable))
					continue; //salta la tabella se è di tipo SkipInsertCopy
				var childTableName = rel.ChildTable.TableName;
				if (!DataUtils.isSubEntityOrNotEntityChild(null, outDs.Tables[childTableName], parentRow.Table)) continue;
				if (childTableName == sourceRow.Table.TableName) continue;
				var childsRowCopy = sourceRow.GetChildRows(rel);
				foreach (var childRow in childsRowCopy) {
					MetaData metaChild = dispatcher.GetMeta(childTableName);

					metaChild.SetDefaults(outDs.Tables[childTableName]);
					var newChildRow = metaChild.Get_New_Row(parentRow, outDs.Tables[childTableName]);
					newChildRow.BeginEdit();
					foreach (DataColumn childCol in outDs.Tables[childTableName].Columns) {

						var skipthis = false;
						//testa se ChildCol fa parte della relazione padre-figlio
						foreach (var cc in rel.ChildColumns) {
							if (cc.ColumnName == childCol.ColumnName) skipthis = true;
						}

						// Effettua la copia vera e propria dei valori. (la funz. InserCopyColumn di emtadata non è accessibile.capire un attimo!)
						//Nino: esiste la ExtCopyColumn poiché la InsertCopyColumn è protected
						if (skipthis) continue;
						metaChild.ExtCopyColumn(childCol,childRow,newChildRow);
						//if (childCol.ColumnName == "adate") continue;
						//newChildRow[childCol.ColumnName] = childRow[childCol.ColumnName];
					}

					newChildRow.EndEdit();

					// vado in ricorsione per copiare i figli dei figli
					recursiveNewCopyChilds(newChildRow, childRow, outDs);
				}
			}
		}

		#endregion

		#region save data Methods

		/// <summary>
		/// Contains the post params for the method multiRunSelect
		/// </summary>
		public class saveDataQueryParameters {
			/// <summary>
			/// jsDataSet serialization
			/// </summary>
			[Required]
			public JToken
				ds {
				get;
				set;
			} // N.B il ds in input al metodo va solo in post, altrimenti in get sarebbe troppo grande

			/// <summary>
			/// main table name
			/// </summary>
			[Required]
			public string tableName { get; set; }

			/// <summary>
			/// Edit type to identify the DataSet
			/// </summary>
			[Required]
			public string editType { get; set; }

			/// <summary>
			/// Previous messages ignored, is the jSon Serialization of a EasyProcedureMessage (s) array
			/// </summary>
			public JArray messages { get; set; }
		}

		/// <summary>
		/// Check if user using anonymous connection. Permits actions only on specific datsets 
		/// </summary>
		/// <returns></returns>
		private bool isAnonymousPermitted(string tablename, string edittype, DataSet ds) {
			var dispatcher = HttpContext.Current.getDataDispatcher();
			var conn = dispatcher.conn;

			// valuto la variabile di ambiente "anonymous" configurata su WebApiConfig nella valutazione
			// del token.
			if (!(bool)conn.Security.GetUsr("anonymous")) {
				return true; // se non è anonimo è sempre permesso
			}

			// la stringa è fatta così:
			// tablename1%edittype,tablename2%edittype,... quindi ogni coppia di tablename ed edittype separati da virgola, e % all'interno della copia
			string anonymousPermissions = WebConfigurationManager.AppSettings["AnonymousPermissions"].ToString();
			string[] anonymousPermissionsArr = anonymousPermissions.Split(',');
			foreach (string pair in anonymousPermissionsArr) {
				string[] pairsPermitted = pair.Split('%');
				if (pairsPermitted.Length == 2) {
					string currTablename = pairsPermitted[0];
					string currEdittype = pairsPermitted[1];
					// se trovo una coppia presente nella configurazione allora torno true
					if (tablename == currTablename && edittype == currEdittype) {
						return anonymousCustomCheck(tablename, edittype, ds);
					}
				}
			}

			return false;
		}

        private RowStateCount countRowState(DataTable dt) {
            RowStateCount rowStateCount = new RowStateCount();
            foreach (DataRow dataRow in dt.Rows) {
                if (dataRow.RowState == DataRowState.Added) {
                    rowStateCount.countAdded++;
                }
                if (dataRow.RowState == DataRowState.Modified) {
                    rowStateCount.countModified++;
                }
                if (dataRow.RowState == DataRowState.Deleted) {
                    rowStateCount.countDeleted++;
                }
            }

            return rowStateCount;
        }

        private bool anonymousCustomCheck(string tablename, string edittype, DataSet ds) {

            if (ds == null) {
                return true;
            }
            // check di sicurezza
            if (tablename == "registrationuser" && edittype == "usr") {
                foreach (DataTable dt in ds.Tables) {
                    RowStateCount rowStateCount = countRowState(dt);
                    if (rowStateCount.countDeleted > 0) {
                        return false;
                    }
                    if (rowStateCount.countModified > 0) {
                        return false;
                    }
                    if (dt.TableName != "registrationuser" && dt.TableName != "registrationuserflowchart" && rowStateCount.countAdded > 0) {
                        return false;
                    }
                    if (dt.TableName == "registrationuser" && rowStateCount.countAdded > 1) {
                        return false;     
                    }
                    // impossibile richiedere più di 10 profili
                    if (dt.TableName != "registrationuserflowchart" && rowStateCount.countAdded > 10) {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Save dataset changes to the DB. If it is not possible, generates and sends messages to the client
        /// </summary>
        /// <param name="prms"></param>
        /// <returns></returns>
        [HttpPost, Route("saveDataSet")]
		public IHttpActionResult saveDataSet([FromBody] saveDataQueryParameters prms) {
			// 0. Inizializzo variabili
			var dispatcher = HttpContext.Current.getDataDispatcher();

			var ds = prms.ds;
			var tableName = prms.tableName;
			var editType = prms.editType;
			var messages = prms.messages;
            DataSet myds = null;
           


            try {
				// 3. prende ds originale dal Server, per questioni di sicurezza utilizzo questo per il post dei dati, dopo averlo 'mergiato'
					// (vedi punto successivo num 4)
				var outDs = DataUtils.createEmptyDataSet(tableName, editType);
				if (outDs == null)
					return Content(HttpStatusCode.BadRequest, $"DataSet {tableName}-{editType} non esistente.");

				// 1. deserializzo strutture dati
				DataSetSerializer.deserializeIntoDataSet(ds, outDs);

				// controllo se utilizza connessione anonima . blocco le operazioni non permesse
				if (!isAnonymousPermitted(tableName, editType, myds)) {
					return Content(HttpStatusCode.BadRequest, LoginFailedStatus.AnonymousNotPermitted);
				}
				
                var myMessages = new ProcedureMessageCollection();
			    if (messages != null) myMessages = DataSetSerializer.deserializeMessages(messages);

			    // sul meta della tab principale invocherò la post
			    var meta = dispatcher.GetMeta(tableName);
			    if (meta == null) return Content(HttpStatusCode.BadRequest, "Entità non valida " + tableName);
			    meta.edit_type = editType;

			    // 2. Passo prima isValid()
			    // Chiamata alla isValid del metaDato lato backend, per ogni riga della tabella principale e subentità 
			    // N.B bisogna controllare che tutti i controlli sulla isValid dei metaDati attuali non tornino msgBox
			    // in questo caso bisogna far diventare tali check delle business rules, e rientrano cosi nei casi di errori non ignorabili
			    // tornati dalla DO_POST_SERVICE()
			    var isValid = true; // inizializzo a true, e metterò a false non appena isValid torna un false
			    string errMsg = "";
			    string errfield = "";

			    //ciclo su tutte le tabelle del dataset
			    foreach (DataTable table in outDs.Tables) {
				    // se è tab principale oppure subentity, 
				    if (table.TableName == tableName || DataUtils.isSubEntityOrNotEntityChild(null, table, outDs.Tables[tableName])) {
					    // devo invocare la specifica isValid, quindi recupero il meta
					    string tName = DataAccess.GetTableForReading(table);
					    var currMeta = dispatcher.GetMeta(tName);
					    currMeta.edit_type = editType;
					    currMeta.ds = outDs;
					    if (currMeta == null) return Content(HttpStatusCode.BadRequest, "Entità non valida " + tName);
					    // ciclo sulle righe. e controllerò quelle in cui ci sono CRUD
					    foreach (DataRow row in table.Rows) {
						    // valuto solo le diverse da unchanged
						    if (row.RowState == DataRowState.Unchanged || row.RowState == DataRowState.Deleted) continue;

						    try {
							    if (!currMeta.IsValid(row, out errMsg, out errfield)) {
								    // la isValid non è passata, invio messaggio non ignorabile
								    EasyProcedureMessage msg = new EasyProcedureMessage();
								    msg.CanIgnore = false;
								    msg.TableName = tName;
								    msg.Operation = (row.RowState == DataRowState.Added)
									    ? "A"
									    : ((row.RowState == DataRowState.Modified) ? "U" : "D");
								    msg.LongMess = $"Tabella: {currMeta.Name} campo: {errfield}  err: {errMsg}";
								    msg.PostMsgs = false; // considero come pre
													      // TODO rivedere eventualmente le stringhe cablate di seguito
								    msg.EnforcementNumber = "Validazione";
								    msg.ErrorType = "Errore";
								    msg.ShortMess = errMsg;

								    myMessages.Add(msg);
								    myMessages.CanIgnore = false;

								    // setto isValid, var locale della funzione, così non eseguo post,ma invio messaggio all'utente
								    isValid = false;
							    } // fine isValid()
						    }
						    catch (Exception e) {

							    // la isValid non è passata, invio messaggio non ignorabile
							    EasyProcedureMessage msg = new EasyProcedureMessage();
							    msg.CanIgnore = false;
							    msg.TableName = tName;
							    msg.Operation = (row.RowState == DataRowState.Added)
								    ? "A"
								    : ((row.RowState == DataRowState.Modified) ? "U" : "D");
							    msg.LongMess = $"table:{tName} field: {errfield}  err: {e.Message}";
							    msg.PostMsgs = false; // considero come pre
												      // TODO rivedere eventualmente le stringhe cablate di seguito
							    msg.EnforcementNumber = "Err MetaDato C#";
							    msg.ErrorType = "Errore";
							    msg.ShortMess =
								    $"Bisogna ristrutturare metodo isValid() del metadato {tName} c#. contiene probabilmente MessageBox";

							    myMessages.Add(msg);
							    myMessages.CanIgnore = false;

							    // setto isValid, var locale della funzione, così non eseguo post,ma amndo emssaggio all'utente
							    isValid = false;
						    }

					    } // fine for sulle righe
				    } // fine if check su tab da controllare
			    } // fine for sulle tabelle del ds




			    // lista delle righe il cui campo byte[] sarà modificato, e che in caso
			    // di errore della save , dovrò bonificare.
			    Dictionary<int, ColumnRowAttach> dataRowAttachModified = new Dictionary<int, ColumnRowAttach>();

			    // 5. se dal controllo della isValid esce con true provo ad effettuare la post, altrimenti mando messaggio all'utente
			    if (isValid) {
				    // 6. Esegue la post del ds costruito, dove ci sono le righe con lo stato aspettato
				    var postData = meta.Get_PostData();
				    postData.initClass(outDs, dispatcher.Connection);

				    // 7. valuto se ci sono tabelle con allegati, cioè colonna idattach per convenzione
				    // se ci sono costrusico un dsattach nuovo dove inserisco la logica dei contatori
				    // che serve per gestire l'algoritmo di persistenza degli allegati, in base all'operazione
				    // creo ds attach in cui inserirò la nuova riga sulla tabella attach. Questa operazione
				    // va fatta in questo punto perchè il save del dell'allegato è fatto in un altra chiamata, e devo tenere persistenti e sincronizzate 
				    // le 2 sorgenti, filesystem e db. quindi gestisco con i contatori su una tabella del db
				    var dsattach = getDsAttachWithCounterUpdated(outDs);
				    // vedo se devo aggiungere sulla transazione il salvataggio del ds con i contatori aggiornati
				    if (dsattach != null) postData.initClass(dsattach, dispatcher.Connection);

				    // Gestione attachmanet per essere compliant con client windows
				    dataRowAttachModified = AttachmentUtils.manageAttachWindowsCompliant(outDs);

				    // 8. gestisco registrazione
				    manageRegistration(outDs);

					// 9. salvo una copia del dataset
					var parentRowState = "ModifiedChildren";
					if(postData.DS.Tables[tableName].Rows.Count>0)
                        parentRowState = postData.DS.Tables[tableName].Rows[0].RowState.ToString();
					LogOperationAndData(myds, dispatcher.conn, tableName + "," + editType, "saveDatSet," + parentRowState, ds.ToString()); ;


                    // segnalo i messaggi già ignorati 
                    if (myMessages.Count > 0) postData.IgnoreMessages(myMessages);

				    //salva i dati ed ottiene un eventuale elenco di messaggi
				    myMessages = postData.DO_POST_SERVICE();
			    }


			    // 8. Effettua operazioni sull'output prima di inviarlo al client

			    // invio una struttura con 4 prm:
			    //  1. il ds serializzato
			    //  2. i messaggi serializzati
			    //  3. valore che indica se il save è andato con successo
			    //  4. valore che indica se tutti i messaggi sono ignorabili

			    // inizializzo valori di default per i booleani di ritorno.
			    var success = true; // indica se la transazione è avvenuta, quindi non ci sono messaggi di warning/errore
			    var canIgnore =
				    true; // sarà true se tutti i messaggi sono ignorabili, false se almeno 1 messaggio  non è ignorabile
					      // se ci sono messaggi , significa che la transazione non è stata eseguita, e devo amndare messaggi opportuni al client.
			    if (myMessages.Count > 0) {
				    // dati non salvati a DB, mando lista dei messaggi, con relativo booleani che indicano se salvataggio avvenuto e se posso ignorare tutti i mess oppure no!
				    success = false;
				    canIgnore = myMessages.CanIgnore;
				    AttachmentUtils.sanatizeDsForAttachUnsuccess(dataRowAttachModified);
			    }
			    else {
				    // Rieseguo la sanitazzione del ds, non inviando i campi di tipo byte[]
				    // Se li trovo rimpiazzo con -1
				    AttachmentUtils.removeAttachmentAfterSuccess(dataRowAttachModified);
				    AttachmentUtils.sanitizeDsForAttach(outDs);
			    }

			    var dsSerialized = DataUtils.dataSetToJSon(outDs,false);

			    var messagesSerialized = DataSetSerializer.serializeMessages(myMessages);
			    // costruisco risposta da mandare al client con il ds e i messaggi eventuali più altre info utili
			    var result = DataUtils.getJsonSaveDataSetAnswer(dsSerialized, messagesSerialized, success, canIgnore);

			    // 9. invio risposta al client
			    return Json(result); //Content(HttpStatusCode.OK, result);
            } catch (Exception e) {
                return Content(HttpStatusCode.InternalServerError,
                    GetAndLogErrorMessage(myds, dispatcher.conn, e.Message, "saveDatSet",
                        "tablename:" + tableName + ", editType:" + editType + " DATASET " + ds));
            }

        }

		/// <summary>
		/// Checks if the dataset is used for the registration. (Must contain table virtualuser and registryreference)
		/// It calculates the crypted password
		/// </summary>
		/// <param name="ds"></param>
		/// <returns></returns>
		private void manageRegistration(DataSet ds) {
			// se nel dataset c'è la tabella virtualuser allora significa che sto facendo una registrazione
			if (ds.Tables["virtualuser"] != null && ds.Tables["registryreference"] != null) {

				var registryRefRow = ds.Tables["registryreference"].First();
				// verifico condizione di registrazione
				if (registryRefRow != null && (registryRefRow.RowState == DataRowState.Added
											   || registryRefRow.RowState == DataRowState.Modified)) {


					if (!String.IsNullOrEmpty((string)registryRefRow["!clientpassword"]) &&
						!String.IsNullOrEmpty((string)registryRefRow["userweb"])) {

						// recupera la password in chiaro e la codifica
						string passclient = (string)registryRefRow["!clientpassword"];
						string userweb = (string)registryRefRow["userweb"];

						// codifico password
						Random rnd = new Random();
						var iterations = rnd.Next(20, 100);
						var salt = KeyChain.generateSalt();
						var hash = Password.generateHash(passclient, salt, iterations);

						registryRefRow["iterweb"] = iterations;
						registryRefRow["saltweb"] = salt.toHexString();
						registryRefRow["passwordweb"] = hash.toHexString();


					}
				}
			}
		}

		/// <summary>
		/// per convenzione la colonna deve iniziare per "idattach"
		/// </summary>
		/// <param name="col"></param>
		/// <returns></returns>
		private bool isAColumnForAttachment(DataColumn col) {
			return col.ColumnName.StartsWith("idattach");
		}

		bool addDeltaToAttachment(IDataAccess conn, DataTable attachment, object idattach, int delta) {
			if (idattach == DBNull.Value) return false;
			if (((int)idattach) == 0) return false;
			var rowOnDtAttach = attachment._get(conn, q.eq(idattachColumnName, (int)idattach)).FirstOrDefault();
			if (rowOnDtAttach == null) return false;
			if (rowOnDtAttach[counterColumnName] == DBNull.Value) {
				rowOnDtAttach[counterColumnName] = delta;
			}
			else {
				rowOnDtAttach[counterColumnName] = (int)rowOnDtAttach[counterColumnName] + delta;
			}

			return true;
		}

		const string idattachColumnName = "idattach";
		const string counterColumnName = "counter";

		/// <summary>string idattachColumnName = "idattach";
		/// Get the dsattach dataSet with the counter of the rows attahced to an attachement on outDs belonging the state of the row on outDs
		/// </summary>
		/// <param name="outDs"></param>
		/// <returns></returns>
		private DataSet getDsAttachWithCounterUpdated(DataSet outDs) {
			var dispatcher = HttpContext.Current.getDataDispatcher();


			string attachTableName = "attach";
			var conn = dispatcher.conn;
			DataSet dsattach = DataUtils.createEmptyDataSet(attachTableName, "counter");
			DataTable dtattach = dsattach.Tables[attachTableName];
			bool attachModified = false;

			// SARA' FATTA L'ASSUNZIONE CHE LE COLONNE CHE PERMETTONO DI INSERIRE UN RIFERIMENTO ALL'ALLEGATO INIZINO PER "idattach"

			// loop su tutte le tabelle del ds da controllare
			foreach (DataTable table in outDs.Tables) {
				if (DataAccess.GetTableForReading(table) == attachTableName) continue;
				foreach (DataRow r in table.Rows) {
					// loop sulle colonne per individuare quella che possiede idttach
					foreach (DataColumn c in table.Columns) {
						if (!isAColumnForAttachment(c)) continue;
						var attachField = c.ColumnName;
						// SINCRONIZZO LA TABELLA DEGLI ATTACHMENT 

						// inizializzo idattach presente sulla colonna in esame
						if (r.RowState == DataRowState.Added) {
							attachModified |= addDeltaToAttachment(conn, dtattach, r[attachField], 1);
						}

						if (r.RowState == DataRowState.Deleted) {
							attachModified |= addDeltaToAttachment(conn, dtattach,
								r[attachField, DataRowVersion.Original], -1);
						}

						// sullo stato modified devo decrementare il counter del vecchio record, mentre devo aumentare quello attuale
						if (r.RowState == DataRowState.Modified) {
							// recupero valore old, che andrò a recuperare sul db e decremento contatore
							var originalIdAttach = r[attachField, DataRowVersion.Original];
							var currentIdAttach = r[attachField];
							// solamente se è cambiato effettivamente l'id attach cioè ho un nuovo file
							if (originalIdAttach.ToString() != currentIdAttach.ToString()) {
								attachModified |= addDeltaToAttachment(conn, dtattach, originalIdAttach, -1);
								attachModified |= addDeltaToAttachment(conn, dtattach, currentIdAttach, +1);
							}
						}
					} // foreach (DataColumn c in table.Columns) {
				} // foreach (DataRow r in table.Rows) {
			}

			if (attachModified) return dsattach;
			return null;
		}

		public class setUsrEnvParameters {
			[Required]
			public string key { get; set; }

			[Required]
			public string value { get; set; }

		}

		[HttpPost, Route("setUsrEnv")]
		public IHttpActionResult setUsrEnv([FromBody] setUsrEnvParameters prms) {
			var dispatcher = HttpContext.Current.getDataDispatcher();

			var key = prms.key;
			var value = prms.value;

			// recupero il sessionInfo
			SessionInfo sessionInfo = (SessionInfo)HttpContext.Current.Items["SessionInfo"];
			// setUsr  sulla cache del backend e poi anche sulla classe security
			sessionInfo.usr[key] = value;

			EasySecurity sec = dispatcher.conn.Security as EasySecurity;
			sec.SetUsr(key, value);
			return Content(HttpStatusCode.OK, "ok");
		}

		[HttpPost, Route("changeRole")]
		public IHttpActionResult cambiaRuolo([FromBody] CambioRuoloFormData data) {

			var dispatcher = HttpContext.Current.getDataDispatcher();
			var conn = dispatcher.conn;
			var qh = dispatcher.QueryHelper;

			Identity identity = (Identity)HttpContext.Current.Items["Identity"];


			string idcustomuser = conn.Security.GetSys("idcustomuser") as string;
			object idflowchart = data.idflowchart;
			object ndetail = data.ndetail;
			object idreg = conn.GetUsr("idreg");


			EasySecurity sec = conn.Security as EasySecurity;

            sec.SetSys("idcustomuser", idcustomuser);

			// eseguo le stesse istruzioni di EasyWebReport
			sec.RecalcUserEnvironment(idflowchart, ndetail);
			// se non trovo nella cache lo calcolo, altrimeni lo ricavo dalla cache
			sec.ReadAllGroupOperations();

			// rimuovo da eventaule cache
			CacheMDLW.removeUserFromGroupOperationsDictCache(idcustomuser);

			// aggiungo utente con groupOperations nella cache appena ripulita per questo idcustomuser
			CacheMDLW.addUtilizer(idcustomuser, idreg.ToString(), sec.groupOperations);

			// calcolo le hashtable con l'environment
			Hashtable usr = AuthUtils.getUsr(sec);
			Hashtable sys = AuthUtils.getSys(sec);

			// aggiorno i dati nella sessione
			// aggiorno la sessione
			Guid guidsession = identity.guidsession;
			SessionMDLW.updateSessionInfoFromGuid(guidsession, usr, sys);

            Hashtable sysClient = new Hashtable();
            sysClient.Add("dbversion", dispatcher.conn.DO_READ_VALUE("updatedbversion", null, "max(versionname)"));
            sysClient.Add("backendversion", Assembly.GetExecutingAssembly().GetName().Version.ToString());
            sysClient.Add("idcustomuser", sec.GetSys("idcustomuser"));

            var result = new JObject {
				{"usr", JToken.FromObject(usr)},
				{"sys", JToken.FromObject(sysClient)}
			};

            //eseguo il LOG degli accessi
            BEError logOK = new BEError();
            logOK.conn = conn;
            logOK.error = "Cambio ruolo avvenuto con successo";
            logOK.methodInfo = "cambiaRuolo";
            logOK.metadata =
                "esercizio: " + conn.Security.GetSys("esercizio") +
                ", idreg: " + idreg +
                ", idcustomuser: " + conn.Security.GetSys("idcustomuser") +
                ", userName: " + conn +
                ", dbversion: " + conn.ToString() +
                ", backendversion: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() +
                ", idflowchart: " + idflowchart
                ;
            DBLogger.log(logOK);

            // 13. torno risposta al client con nuovo environment
            return Content(HttpStatusCode.OK, result);
		}


		public class doReadValueParameters {
			/// <summary>
			/// Table to read
			/// </summary>
			public string table { get; set; }

			/// <summary>
			/// Filter to apply
			/// </summary>
			public JToken filter { get; set; }

			/// <summary>
			/// Expression to read
			/// </summary>
			public string expr { get; set; }

			/// <summary>
			/// sorting to apply
			/// </summary>
			public string orderby { get; set; }

		}

		[HttpPost, Route("doReadValue")]
		public IHttpActionResult doReadValue([FromBody] doReadValueParameters prms) {
			var dispatcher = HttpContext.Current.getDataDispatcher();
			//  string table, string condition, string expr, string orderby
			var table = prms.table;
			var filter = prms.filter;
			var expr = prms.expr;
			var orderby = prms.orderby;

			var filterString = DataUtils.getfilterFromJsDataQuery(filter, dispatcher);

			var conn = dispatcher.conn;

			Object val = conn.DO_READ_VALUE(table, filterString, expr, orderby);
			string errorMessage = evaluateLastError("doReadValue");
			if (errorMessage != null) {
				return Content(HttpStatusCode.InternalServerError,
					GetAndLogErrorMessage(null, dispatcher.conn, errorMessage, "doReadValue",
						"tablename:" + table + ", filter:" + filterString + " Expr: " + expr + " order by: " + orderby));
			}

			return Content(HttpStatusCode.OK, val);
		}

        #endregion

        #region Send mail

        public class sendMailParameters {
            /// <summary>
            /// EMails splitted by ;. For ex: mail1@m.it;mail2@m.it
            /// </summary>
            public string emailDest { get; set; }

            /// <summary>
            /// body of the mail
            /// </summary>
            public string htmlBody { get; set; }

            /// <summary>
            /// subject of the mail
            /// </summary>
            public string subject { get; set; }

        }

        [HttpPost, Route("sendMail")]
        public IHttpActionResult sendMail([FromBody] sendMailParameters prms) {
            var emailDest = prms.emailDest;
            var body = prms.htmlBody;
            var subject = prms.subject;
			try {
				string smtpserver = WebConfigurationManager.AppSettings["smtpserver"];
				int smtpport = Convert.ToInt32(WebConfigurationManager.AppSettings["smtpport"]);
				string smtpuser = WebConfigurationManager.AppSettings["smtpuser"];
				string smtppwd = WebConfigurationManager.AppSettings["smtppwd"];
				if (!string.IsNullOrWhiteSpace(smtppwd)) {
					SystemConfig systemConfig = Security.Token.decodeSystemConfig(smtppwd);
					smtppwd = systemConfig.password;
				}

				BodyBuilder builder = new BodyBuilder();
				MimeMessage mail = new MimeMessage();
				mail.From.Add(new MailboxAddress("", smtpuser));

				List<string> listStrLineElements = emailDest.Split(';').ToList();
				foreach (String email in listStrLineElements) {
					mail.To.Add(new MailboxAddress("", email));
				}
				mail.Subject = subject;
				builder.HtmlBody = body;
				mail.Body = builder.ToMessageBody();

				using (var client = new SmtpClient()) {
					SecureSocketOptions useSsl = SecureSocketOptions.Auto;
					if (smtpport == 25) {
						useSsl = SecureSocketOptions.None;
					}
					client.Connect(smtpserver, smtpport, useSsl);
					client.AuthenticationMechanisms.Remove("XOAUTH2");
					if (!string.IsNullOrWhiteSpace(smtppwd)) 
						client.Authenticate(smtpuser, smtppwd);
					client.Send(mail);
					client.Disconnect(true);
				}

				return Content(HttpStatusCode.OK, "");
			}
			catch (Exception e) {
				var error = "Errore: " + e.Message;
					if(string.IsNullOrWhiteSpace(prms.emailDest))
					error = "Errore: non sono presenti indirizzi mail a cui inviare la mail";
				return Content(HttpStatusCode.OK, error);
			}
		}

        #endregion

        #region ImportExcel
        public class importExcelParameters {
            /// <summary>
            /// Stored procedure
            /// </summary>
            public string spName { get; set; }

            /// <summary>
            /// dataset
            /// </summary>
            public JToken ds { get; set; }

            /// <summary>
            /// ids Parent
            /// </summary>
            public string[] idsParent { get; set; }

            /// <summary>
            /// additionalparam
            /// </summary>
            public string[] additionalparam { get; set; }

        }

        [HttpPost, Route("importExcel")]
        public IHttpActionResult importExcel([FromBody] importExcelParameters prms) {

            // -----------> deserializza prm
            var ds = prms.ds;
            var spName = prms.spName;
            var idsParent = prms.idsParent;
            var additionalparam = prms.additionalparam;
			if (additionalparam == null)
				additionalparam = new string[0];
            var dispatcher = HttpContext.Current.getDataDispatcher();

            DataSet dataSet = DataSetSerializer.deserialize(ds, true, dispatcher);
            DataTable dt = dataSet.Tables[0];

            // ----------->   1. Crea tabella
            int i;
            string command;
            Guid g = Guid.NewGuid();
            string tableName = dt.TableName;
            // leggo colonne
            string[] columns = dt.Columns.Cast<DataColumn>()
                                 .Select(x => x.ColumnName)
                                 .ToArray();

            // costruisco comando
            command = "CREATE TABLE " + tableName + " (\r";
            int ncol = columns.GetLength(0);
            for (i = 0; i < ncol; i++) {
                command += "[" + columns[i] + "] varchar(1000) NULL ";
                if ((i + 1 < ncol)) command += ",\r";
            }
            command += ")";
            dispatcher.conn.DO_SYS_CMD(command);


            // ----------->   2. salva dati in tabella appena creata su db
            MetaData meta = new MetaData();
            var postData = meta.Get_PostData();
            postData.initClass(dataSet, dispatcher.Connection);
            var myMessages = new ProcedureMessageCollection();
            myMessages = postData.DO_POST_SERVICE();
            if (myMessages.Count > 0) {
				ProcedureMessage msg1 = (ProcedureMessage)myMessages[0];
                string err = msg1.LongMess;
                return Content(HttpStatusCode.OK, "Errore durante il salvataggio della tabella iniziale " + err);

            }
            object userweb = dispatcher.conn.GetUsr("userweb");

            // -----------> 3. chiama sp
            object[] list = new object[] {
                String.Join(",", idsParent),
                tableName,
                userweb,
                String.Join(",", additionalparam)
            };
        
            DataSet DSout = dispatcher.conn.CallSP(spName, list, true, -1);

            // ----------->  4. risponde al client
            string lastError = dispatcher.conn.LastError;
            if (!String.IsNullOrEmpty(lastError)) {
                return Content(HttpStatusCode.OK, "Errore nella sp: " + lastError);
            }

            if (DSout == null) {
                return Content(HttpStatusCode.OK, "Ok");
            } else {
                // recupero stringa di messaggio calcolata dalla SP.
                DataTable dtErr = DSout.Tables[0];
                string msg = "";
                if (dtErr != null && dtErr.Rows.Count > 0) {
                    DataRow dtrow = dtErr.Rows[0];
                    msg = (String)dtrow[0];
                }
                return Content(HttpStatusCode.OK, "La procedura ha restituito: " + msg);
            }

        }
        #endregion

        #region test Methods

        /// <summary>
        /// Create Dataset from Json object. Json is the jsDataSet deserialized
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost, Route("fromJsDataSetToDataset")]
		public IHttpActionResult fromJsDataSetToDataset([FromBody] JsDs data) {
			// SENZA STRUTTURA  "{\"tables\":{\"table1\":{\"rows\":[{\"state\":\"added\",\"curr\":{\"c_name\":\"nome1\",\"c_dec\":11,\"c_double\":1001}},{\"state\":\"added\",\"curr\":{\"c_name\":\"nome2\",\"c_dec\":22,\"c_double\":2002}}]},\"table2\":{\"rows\":[{\"state\":\"added\",\"curr\":{\"c_name\":\"nome1\",\"c_citta\":\"roma\"}},{\"state\":\"added\",\"curr\":{\"c_name\":\"nome2\",\"c_citta\":\"bari\"}}]},\"table3\":{\"rows\":[{\"state\":\"added\",\"curr\":{\"c_alt\":1.5,\"c_sex\":\"maschio\",\"c_date\":\"1980-10-02T00:00:00.000Z\",\"c_int16\":2018}},{\"state\":\"added\",\"curr\":{\"c_alt\":1.6,\"c_sex\":\"femmina\",\"c_date\":\"1981-10-02T00:00:00.000Z\",\"c_int16\":2019}},{\"state\":\"added\",\"curr\":{\"c_alt\":1.7,\"c_sex\":null,\"c_date\":\"1981-10-02T00:00:00.000Z\",\"c_int16\":2020}}]}}}"

			// --> CON STRUTTURA {"name":"temp","relations":{"r1":{"parentTable":"table1","parentCols":"c_name","childTable":"table2","childCols":"c_name"}},"tables":{"table1":{"key":"","tableForReading":"table1","tableForWriting":"table1","skipSecurity":false,"defaults":{},"autoIncrementColumns":{},"columns":{"c_name":{"name":"c_name","ctype":"String"},"c_dec":{"name":"c_dec","ctype":"Decimal"},"c_double":{"name":"c_double","ctype":"Double"}},"rows":[{"state":"added","curr":{"c_name":"nome1","c_dec":11,"c_double":1001}},{"state":"added","curr":{"c_name":"nome2","c_dec":22,"c_double":2002}}]},"table2":{"key":"","tableForReading":"table2","tableForWriting":"table2","skipSecurity":false,"defaults":{},"autoIncrementColumns":{},"columns":{"c_name":{"name":"c_name","ctype":"String"},"c_citta":{"name":"c_citta","ctype":"String"}},"rows":[{"state":"added","curr":{"c_name":"nome1","c_citta":"roma"}},{"state":"added","curr":{"c_name":"nome2","c_citta":"bari"}}]},"table3":{"key":"","tableForReading":"table3","tableForWriting":"table3","skipSecurity":false,"defaults":{},"autoIncrementColumns":{},"columns":{"c_alt":{"name":"c_alt","ctype":"Decimal"},"c_sex":{"name":"c_sex","ctype":"String"},"c_date":{"name":"c_date","ctype":"DateTime"},"c_int16":{"name":"c_int16","ctype":"Int16"}},"rows":[{"state":"added","curr":{"c_alt":1.5,"c_sex":"maschio","c_date":"1980-10-02T00:00:00.000Z","c_int16":2018}},{"state":"added","curr":{"c_alt":1.6,"c_sex":"femmina","c_date":"1981-10-02T00:00:00.000Z","c_int16":2019}},{"state":"added","curr":{"c_alt":1.7,"c_sex":null,"c_date":"1981-10-02T00:00:00.000Z","c_int16":2020}}]}}}

			// Inizializzo GetData
			var dispatcher = HttpContext.Current.getDataDispatcher();

			if (data.ds == null) {
				return Content(HttpStatusCode.BadRequest, "Specificare un json di un dataset");
			}

			try {
				var dataSet = DataSetSerializer.deserialize(data.ds,true, dispatcher);

				// trasforma il ds costruito in una struttura da serializzare e rinviare al client.
				var jsonResDataSet = DataUtils.dataSetToJSon(dataSet,true);

				return Json(jsonResDataSet); //Content(HttpStatusCode.OK, jsonResDataSet);
			}
			catch (Exception e) {
				return Content(HttpStatusCode.InternalServerError,
					GetAndLogErrorMessage(null, dispatcher.conn, e.ToString(), "fromJsDatasetToDataset",
						"Dataset JSON :" + data.ds));
			}
		}

		/// <summary>
		/// Create sql expression from json object. Json is the JsDataQuery deserialized
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		[HttpPost, Route("fromJsDataQueryToSql")]
		public IHttpActionResult fromJsDataQueryToSql(JObject data) {
			var dispatcher = HttpContext.Current.getDataDispatcher();
			var conn = dispatcher.conn;
			var filterString = DataUtils.getfilterFromJsDataQuery(data.GetValue("filter"), dispatcher);
			return Content(HttpStatusCode.OK, filterString);
		}

		/// <summary>
		/// Called by Client for e2e test with typed DataSet
		/// </summary>
		/// <param name="testClientCode">string of the type of the test</param>
		/// <returns></returns>
		[HttpGet, Route("getDataSetTest")]
		public IHttpActionResult getDataSetTest(string testClientCode) {
			if (testClientCode == "test1") {
				var registryDs = new dsmeta_registry_anagrafica();
				// trasforma il ds costruito in una struttura da serializzare e rinviare al client.
				var jsonResDataSet = DataUtils.dataSetToJSon(registryDs,true);
				return Json(jsonResDataSet); //Content(HttpStatusCode.OK, jsonResDataSet);
			}

			if (testClientCode == "test2") {
				var dispatcher = HttpContext.Current.getDataDispatcher();
				DataSet ds1 = new dsmeta_registry_anagrafica();
				var getData = new GetData();
				getData.InitClass(ds1, dispatcher.Connection, "registryreference");
				var qh = dispatcher.QueryHelper;
				var filterByEmail = qh.AppAnd(qh.Like("referencename", "riccardo%"));
				getData.GET_PRIMARY_TABLE(filterByEmail);

				// Aggiungo proprietà AutoIncrement per test ser c# -> js 
				// Ricorda che lato js i selettori generici e quelli specifici sarrano uniti. (uniti in fase di serializzazione c#)
				// Un selettore generico è quello per cui per una data esiste una ExtendedProperties "Selector" e "SelectorMask". 
				// Invece i selettori specifici sono stringhe concatenate da virgola contenute nelle ExtendedProperties "MySelector" e "MySelectorMask"

				ds1.Tables["registryreference"].Columns["referencename"].ExtendedProperties["Selector"] = "s";
				ds1.Tables["registryreference"].Columns["referencename"].ExtendedProperties["SelectorMask"] = "123";

				ds1.Tables["registryreference"].Columns["idreg"].ExtendedProperties["IsAutoIncrement"] = "s";
				ds1.Tables["registryreference"].Columns["idreg"].ExtendedProperties["PrefixField"] = "PrefixField";
				ds1.Tables["registryreference"].Columns["idreg"].ExtendedProperties["MiddleConst"] = "MiddleConst";
				ds1.Tables["registryreference"].Columns["idreg"].ExtendedProperties["MySelector"] = "cu,lt";
				ds1.Tables["registryreference"].Columns["idreg"].ExtendedProperties["MySelectorMask"] = "456,789";
				ds1.Tables["registryreference"].Columns["idreg"].ExtendedProperties["minimumTempValue"] = 1;
				ds1.Tables["registryreference"].Columns["idreg"].ExtendedProperties["IDLength"] = 12;

				ds1.Tables["registryreference"].Columns["email"].ExtendedProperties["IsAutoIncrement"] = "s";
				ds1.Tables["registryreference"].Columns["email"].ExtendedProperties["PrefixField"] = "PrefixField";
				ds1.Tables["registryreference"].Columns["email"].ExtendedProperties["MiddleConst"] = "MiddleConst";
				ds1.Tables["registryreference"].Columns["email"].ExtendedProperties["MySelector"] = "cu,lt";
				ds1.Tables["registryreference"].Columns["email"].ExtendedProperties["MySelectorMask"] = "456,789";
				ds1.Tables["registryreference"].Columns["email"].ExtendedProperties["minimumTempValue"] = 1;
				ds1.Tables["registryreference"].Columns["email"].ExtendedProperties["IDLength"] = 12;

				// campo expression stringa
				ds1.Tables["registryreference"].Columns["txt"].ExtendedProperties["IsTemporaryColumn"] =
					"registryreference.lu";
				// campo expression MetaExpression
				var f1 = q.field("iterweb");
				var c1 = q.constant(2);
				ds1.Tables["registryreference"].Columns["faxnumber"].ExtendedProperties["IsTemporaryColumn"] =
					q.eq(f1, c1);

				var datat = ds1.Tables["registryreference"];
				var r = datat.Rows[0];
				r["flagdefault"] = "N";
				r["referencename"] = "Luigi";
				//Ci sono 6 righe ove referencename like riccardo%. La prima riga è modified (flagdefault,referencename) , la 3a è deleted, l'ultima è added
				//AGGIUNGO UNA NUOVA RIGA ALLA TABELLA 

				var row = datat.NewRow();

				row["referencename"] = "Riccardo";
				row["idreg"] = 10000;
				row["idregistryreference"] = 100;
				row["cu"] = "assistenza";
				row["lt"] = DateTime.Today;
				row["lu"] = "assistenza";
				row["ct"] = DateTime.Today;
				datat.Rows.Add(row);

				//RIMUOVO UNA RIGA DALLA TABELLA
				datat.Rows[2].Delete();

				var jsonResDataSet = DataUtils.dataSetToJSon(ds1,true);

				return Content(HttpStatusCode.OK, jsonResDataSet);
			}

			return Content(HttpStatusCode.OK, "no test");

		}


		// metodo per testare nuova struttura backend
		[HttpGet, Route("testNotify")]
		public async Task<IHttpActionResult> testNotify(int p1, string idRequest) {

			var dispatcher = HttpContext.Current.getDataDispatcher();
			var IDataSender = new HttpDataSender(idRequest, dispatcher);

			JObject prms = new JObject() {
				{"p1", p1}
			};
			DataManager.testNotify(prms, IDataSender);

			var res = await IDataSender.getResult();

			string answer = res.answer;
			HttpStatusCode code = res.code;
			return Content(code, answer);

		}

		#endregion

		#region CustomEvent

		/// <summary>
		/// Contains the post params for the method customServerMethod.
		/// eventName: the name of the emthod to call.
		/// parameters: a json string with the cusotm parameters.
		/// </summary>
		public class customServerMethodQueryParameters {
			[Required]
			public string eventName { get; set; }

			public string parameters { get; set; }
		}


		/// <summary>
		/// Called by Client, calls a generic custom method for a specific business logic. Implement the switch case!
		/// </summary>
		/// <param name="prms">customEventQueryParameters</param>
		/// <returns></returns>
		[HttpPost, Route("customServerMethod")]
		public IHttpActionResult customServerMethod([FromBody] customServerMethodQueryParameters prms) {
			var eventName = prms.eventName;
			var parameters = prms.parameters;

			var myjsonprm = new JObject();
			if (parameters != null) {
				// lo converto in JObject per manipolare come voglio
				myjsonprm = (JObject)JsonConvert.DeserializeObject(parameters);
			}

			// a seconda del "nome evento" passato svolgo routine custom
			switch (eventName) {
				case "myCustomEvent":
					return myCustomEvent();

				case "mdlwCustomEvent":
					// richiama metodo standar per chiamare un metodo del metadato
					return mdlwCustomEvent(myjsonprm);

				case "callSP":
					return callSP(myjsonprm);

				default:
					return Content(HttpStatusCode.MethodNotAllowed, eventName);
			}

		}

		/// <summary>
		/// Richiamata un qualsaisi custom event descritto sui metadati in maniera standard
		/// Si aspetta che nei prm ci siano almeno  "tablename"  e  "customevent" ed eventualmente dei parametri  aggiuntivi che poi passerò al metodo custom sul metadato
		/// </summary>
		/// <returns></returns>
		private IHttpActionResult callSP(JObject parameters) {
			var spname = "";
			var prms = new List<Object>();

			// recupero prm obbligatorio spname, serve per capire quale store procedure richiamare
			if (parameters["spname"] != null) {
				spname = (string)parameters["spname"];
			}
			else {
				return Content(HttpStatusCode.BadRequest, "callSP : MISSING spname");
			}

			// costrusico array di parametri custom, tolgo tablename, e customevent dal ciclo
			parameters.Properties()._forEach(p => {
				if (p.Name.ToString() != "spname") {
					prms.Add(p.Value);
				}
			});
			var dispatcher = HttpContext.Current.getDataDispatcher();
			var conn = dispatcher.conn;
            var errmsg = "";


            DataSet ds = conn.CallSP(spname, prms.ToArray(), -1, out errmsg);
			if (string.IsNullOrEmpty(errmsg)) {

				var msg = "";
				if (ds.Tables.Count > 0)
					if (ds.Tables[0].Rows.Count > 0)
						if (ds.Tables[0].Rows[0].ItemArray.Count() > 0)
							msg = ds.Tables[0].Rows[0].ItemArray[0].ToString();
				
				LogOperationAndData(null, dispatcher.conn, msg, "callSP", "Procedure: " + spname + " Parameters: " + JsonConvert.SerializeObject(prms, Formatting.Indented));

                var jsonResDataSet = DataUtils.dataSetToJSon(ds,false);
                var result = new JObject {
                    {"ds", jsonResDataSet},
                    {"err", null}
                 };

                return Content(HttpStatusCode.OK, result);
			}

            GetAndLogErrorMessage(null, dispatcher.conn, errmsg, "callSP", "Procedure: " + spname + " Parameters: " + JsonConvert.SerializeObject(prms, Formatting.Indented));

            return Content(HttpStatusCode.OK, new JObject {
                    {"ds", null},
                    {"err", errmsg}
                 });

		}

		/// <summary>
		/// Richiamata un qualsaisi custom event descritto sui metadati in maniera standard
		/// Si aspetta che nei prm ci siano almeno  "tablename"  e  "customevent" ed eventualmente dei parametri  aggiuntivi che poi passerò al metodo custom sul metadato
		/// </summary>
		/// <returns></returns>
		private IHttpActionResult mdlwCustomEvent(JObject parameters) {
			var tableName = "";
			var customEvent = "";
			var prms = new List<Object>();

			// recupero prm obbligatorio tablename, serve per capire quale meta devo richiamare
			if (parameters["tablename"] != null) {
				tableName = (string)parameters["tablename"];
			}
			else {
				return Content(HttpStatusCode.OK, "mdlwCustomEvent : MISSING tablename");
			}

			// recupero prm obbligatorio customevent, serve per capire quale metodo del meta devo richiamare
			if (parameters["customevent"] != null) {
				customEvent = (string)parameters["customevent"];
			}
			else {
				return Content(HttpStatusCode.OK, "mdlwCustomEvent : MISSING customevent");
			}

			// costrusico array di parametri custom, tolgo tablename, e customevent dal ciclo
			parameters.Properties()._forEach(p => {
				if (p.Name.ToString() != "tablename" && p.Name.ToString() != "customevent") {
					prms.Add(p.Value);
				}

			});

			// recupero emta
			var dispatcher = HttpContext.Current.getDataDispatcher();
			var meta = dispatcher.GetMeta(tableName);
			// inovco metodo
			Type thisType = meta.GetType();
			MethodInfo theMethod = thisType.GetMethod(customEvent);

			try {
				// Invoco il emtod del emtadato. il emtodo sia spetta una lista di prm  metodo(prm1, prm2...prmn)
				var res = theMethod.Invoke(meta, prms.ToArray());
				// Esempio di metodo privato
				return Content(HttpStatusCode.OK, res);

			}
			catch (Exception e) {

				return Content(HttpStatusCode.OK, e.Message);
			}


		}

		/// <summary>
		/// Metodo template per richiamare un evento qualsoasi richeisto dal clint.
		/// </summary>
		/// <returns></returns>
		private IHttpActionResult myCustomEvent() {
			// Esempio di metodo privato
			return Content(HttpStatusCode.OK, "ok myCustomEvent");
		}

		#endregion


	}
}
