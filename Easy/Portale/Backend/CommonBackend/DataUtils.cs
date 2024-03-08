
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


using Backend.Components;
using Backend.Data;
using Backend.Extensions;
using metadatalibrary;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace Backend.CommonBackend
{
    /// <summary>
    /// Contains the common util methods used by connection interface for serialize/deserialize objects
    /// </summary>
    public static class DataUtils
    {
        /// <summary>
        /// Return the json to send to client, from JObject
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static string jObjectToJSon(JToken obj)
        {
            return obj.ToString(Formatting.None);            
        }

        /// <summary>
        /// Builds the standard JObject to serializeon json string and send to the client
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="type"></param>
        /// <param name="data"></param>
        /// <param name="code"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        private static JObject buildJObjectAnswer(string requestId, string type, object data, string code, string error)
        {
            return new JObject {
                {"requestId", requestId},
                {"type", type},
                {"data", JArray.FromObject(data)},
                {"code", code},
                {"error", error}
            };
        }

        /// <summary>
        /// Build a json with the prm to send to client, for save dataset action
        /// </summary>
        /// <param name="dsSerialized"></param>
        /// <param name="messages"></param>
        /// <param name="canIgnore"></param>
        /// <returns></returns>
        private static JObject buildJObjectSaveDataSetAnswer(JObject dsSerialized, object messages, Boolean success, Boolean canIgnore)
        {
            return new JObject {
                {"dataset", dsSerialized},
                {"messages", JArray.FromObject(messages)},
                {"success", success },
                {"canIgnore", canIgnore }
            };
        }

        /// <summary>
        /// Given the standard parameters build an JObject and serialize it into json string
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="type"></param>
        /// <param name="data"></param>
        /// <param name="code"></param> default 200
        /// <param name="error"></param> default ""
        /// <returns></returns>
        public static string getJsonAnswer(string requestId, string type, object data, string code = "200", string error = "")
        {
            var jobj = buildJObjectAnswer(requestId, type, data, code, error);
            return jObjectToJSon(jobj);            
        }

        /// <summary>
        /// Given the standard parameters build an JObject for saveDataSet action and serialize it into json string
        /// </summary>
        /// <param name="dsSerialized">string</param>
        /// <param name="messages"></param>
        /// <returns></returns>
        public static JObject getJsonSaveDataSetAnswer(JObject dsSerialized, object messages, Boolean success, Boolean canIgnore)
        {
            var jobj = buildJObjectSaveDataSetAnswer(dsSerialized, messages, success, canIgnore);
            return jobj; //jObjectToJSon(jobj);
        }


        /// <summary>
        /// Returns a json string (JsDataSet) serialized of a DataSet
        /// </summary>
        /// <param name="ds">DataSet to serialize in json string</param>
        /// <returns>the json string serialized of a DataSet</returns>
        public static JObject dataSetToJSon(DataSet ds, bool serializeStructure)
        {
            return DataSetSerializer.serialize(ds, serializeStructure); //.ToString(Newtonsoft.Json.Formatting.None);

            //var serializer = new JavaScriptSerializer {MaxJsonLength = int.MaxValue};
            //return serializer.Serialize(DataSetSerializer.serialize(ds));
        }


        /// <summary>
        /// Serialize a DataTable into a json string (JsDataTable) 
        /// </summary>
        /// <param name="dt">DataTable to serialize in json string</param>
        /// <param name="serializeStructure"></param>
        /// <param name="withName"></param>
        /// <returns>the json string serialized of a DataTable</returns>
        public static JObject dataTableToJSon(DataTable dt,bool serializeStructure,bool withName)
        {
            return DataSetSerializer.serializeDataTable(dt, serializeStructure,withName); //.ToString(Newtonsoft.Json.Formatting.None);

            // var serializer = new JavaScriptSerializer {MaxJsonLength = int.MaxValue};
            // return serializer.Serialize(DataSetSerializer.serializeDataTable(dt));
        }

        /// <summary>
        /// Given an array json of js obj such as { filter: $q.eq("cu", "sa"), top: 300, tableName: "registry", table: ds.tables['registry']}
        /// returns a list of SelectBuilder
        /// </summary>
        /// <param name="selBuilderArr">json of array selBuilderArr serilized from js</param>
        /// <param name="dispatcher"></param>
        /// <returns></returns>
        public static List<SelectBuilder> getSelList(JToken selBuilderArr, Dispatcher dispatcher)
        {
            var sel = (JObject) selBuilderArr; //JObject.Parse(selBuilderArr);
            var arr = JArray.FromObject(sel["arr"]);

            var ds = new DataSet();

            var selList = new List<SelectBuilder>();

            foreach (var objSelBuild in arr)
            {
                var expr = objSelBuild["filter"];
                var tableName = objSelBuild["tableName"].ToString();
                var table = DataSetSerializer.jTokenToTable(objSelBuild["table"],false, dispatcher,tableName);
                string top = null;
                if (!String.IsNullOrEmpty(objSelBuild["top"].ToString()))
                {
                    top = objSelBuild["top"].ToString();
                }

                string filterString = getfilterFromJsDataQuery(expr, dispatcher);
 
                ds.Tables.Add(table);
                var sb = new SelectBuilder().From(tableName).IntoTable(table).Where(filterString).Top(top);
                selList.Add(sb);
            }

            return selList;
        }

        /// <summary>
        /// Given the jtoken of the representation of jsDataQuery return a filter string sql style.
        /// </summary>
        /// <param name="filter">Jtoken </param>
        /// <param name="dispatcher">Dispatcher</param>
        /// <returns>string that represents a where clausole sql</returns>
        public static string getfilterFromJsDataQuery(JToken filter, Dispatcher dispatcher)
        {
            MetaExpression q = null;
            if (JObject.Parse(filter.ToString()).Count != 0)
            {
                q = MetaExpressionSerializer.deserialize(filter) as MetaExpression;
            }

            var sFilter = q?.toSql(dispatcher.conn.GetQueryHelper(), dispatcher.conn);

            return sFilter;
        }

        /// <summary>
        /// Given the jtoken of the representation of jsDataQuery return a metaExpression.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="dispatcher"></param>
        /// <returns></returns>
        public static MetaExpression metaExpressionFromJsDataQueryJson(JToken filter, Dispatcher dispatcher)
        {
            MetaExpression q = null;
            if (JObject.Parse(filter.ToString()).Count != 0)
            {
                q = MetaExpressionSerializer.deserialize(filter) as MetaExpression;
            }

            return q;
        }


        /// <summary>
        /// Given the json of the representation of jsDataQuery return a metaExpression
        /// </summary>
        /// <param name="filter">Jtoken </param>
        /// <param name="dispatcher">Dispatcher</param>
        /// <returns>MetaExpression</returns>
        public static MetaExpression getMetaExpressionFromJsonDataQuery(JToken filter)
        {
            MetaExpression q = null;
            if (JObject.Parse(filter.ToString()).Count != 0) {
                q = MetaExpressionSerializer.deserialize(filter) as MetaExpression;
            }
 
            return q;
        }

        /// <summary>
        /// Given a metaExpression, serializes it and get the json string
        /// </summary>
        /// <param name="me">MetaExpression</param>
        /// <returns>json string of metaExpression</returns>
        public static JObject metaExpressionToJson(MetaExpression m)
        {
            var filterOutObj = MetaExpressionSerializer.serialize(m);
            return filterOutObj; //.ToString(Newtonsoft.Json.Formatting.None);
            //var filterOutObjJson = filterOutObj.ToString(Newtonsoft.Json.Formatting.None);
            //return filterOutObjJson;
            //var serializer = new JavaScriptSerializer { MaxJsonLength = int.MaxValue };
            //return serializer.Serialize(filterOutObj);
        }

        public static string GetReverseOrderByClause(string OrderByListField)
        {
            if (OrderByListField == null || OrderByListField.Length == 0) return "";

            // Replace Multiple spaces with one single space
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex(@"[ ]{2,}", options);
            OrderByListField = regex.Replace(OrderByListField, @" ");

            string[] OrderByFieldArray = OrderByListField.Trim().Split(',');
            string OutputClause = "";
            for (int Index = 0; Index < OrderByFieldArray.Length; Index++)
            {


                string[] ActualField = OrderByFieldArray[Index].Trim().Split(' ');


                if (ActualField.Length > 1)
                {
                    if (ActualField[1].ToLower() == "asc")
                        OutputClause += ActualField[0].Trim() + " " + "desc,";
                    else
                        OutputClause += ActualField[0].Trim() + " " + "asc,";
                }
                else
                {
                    OutputClause += OrderByFieldArray[Index].Trim() + " " + "desc,";
                }
            }

            return OutputClause.Substring(0, OutputClause.Length - 1);
        }

        /// <summary>
        /// Creates and returns a DataSet called with then name convention $"Backend.Data.dsmeta_{tableName}_{editType}";
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="editType"></param>
        /// <returns></returns>
        public static DataSet createEmptyDataSet(string tableName, string editType) {
            var outDs = createDataSet(tableName, editType);
            if (outDs == null)  return null;
           
            DataTable primaryTable = outDs.Tables[tableName];
            var dispatcher = HttpContext.Current.getDataDispatcher();
            dispatcher.conn.AddExtendedProperty(primaryTable);
            MetaData meta = dispatcher.GetMeta(tableName);
            meta.DescribeColumns(primaryTable);
            manageColDescr(primaryTable);
            addSubEntityExtProperties(primaryTable, editType);
            return outDs;
        }

        /// <summary>
        /// Gestisce la valorizzazione delle proprietà lette da colDescr.
        /// In particolare legge dalla cache se già è stata letta e per ogni caption valorizza la rispettiva proprietà caption della colonna
        /// </summary>
        /// <param name="dtToDescribe">DataTable</param>
        public static void manageColDescr(DataTable dtToDescribe) {
            var dispatcher = HttpContext.Current.getDataDispatcher();
            var conn = dispatcher.conn;
            var qh = dispatcher.QueryHelper;

            // 1. recupero dalla cache
            string tableName = dtToDescribe.tableForReading();
            DataTable colDescr = null;
            CacheMDLW.colDescrCache.TryGetValue(tableName, out colDescr);
            // 2. popolo se non c'è ed inserisco sulla cache
            if (colDescr == null) {
                var filter = (qh.CmpEq("tablename", tableName));
                colDescr = conn.RUN_SELECT("coldescr", "*", null, filter, null, false);
                CacheMDLW.colDescrCache[tableName] = colDescr;
            }

            // 3. eseguo loop per popolare la caption della tabella del dataset
            foreach (DataColumn c in dtToDescribe.Columns) {
                // seleziono la riga di coldescr per questo column e seleziono il valore della caption
                string expr = "colname ='" + c.ColumnName + "'"; 
                DataRow[] rows = colDescr.Select(expr);
                if (rows.Length > 0) {
                    var caption = rows[0]["caption"];
                    if (caption != DBNull.Value) {
                        c.Caption = caption.ToString();
                    }
                }
            }
        }

        /// <summary>
        /// Init a DataSet defined at design-time.
        /// </summary>
        /// <param name="tableName">Table name</param>
        /// <param name="editType">Edit type</param>
        /// <returns>Empty DataSet with schema</returns>
        public static DataSet createDataSet(string tableName, string editType) {
                // Il nome del meta e l'edit-type fanno parte del namespace.
                // Il DataSet deve avere nome "Vista".
                var dsName = $"Backend.Data.dsmeta_{tableName}_{editType}";
                var type = Type.GetType(dsName, false, true);
                if (type == null) return null;

                var ds = Activator.CreateInstance(type) as DataSet;

                if (ds == null) return null;
                ds.DataSetName = $"{tableName}_{editType}";

                // imposto proprietà specifiche per il dataset, invocando il metodo "initCustom"
                var dispatcher = HttpContext.Current.getDataDispatcher();
                if (ds is IDataSetInit ids)  ids.initCustom(dispatcher);

                return ds;
        }

        /// <summary>
        /// Reads defaults from MetaData and set they on t
        /// </summary>
        /// <param name="t">DataTable</param>
        /// <param name="editType">string</param>
        private static void setDefaults(DataTable t, string editType) {
            var dispatcher = HttpContext.Current.getDataDispatcher();
            string tName = DataAccess.GetTableForReading(t);
            var meta = dispatcher.GetMeta(tName);
            meta.edit_type = editType;
            meta.SetDefaults(t);
        }

        public static bool isSubEntityOrNotEntityChild(DataRelation rel, DataTable child, DataTable parent) {
            var model = MetaFactory.factory.getSingleton<IMetaModel>();
            bool isSubentity;
            if (rel == null) {
                isSubentity = QueryCreator.IsSubEntity(child, parent);
            } else {
                isSubentity = QueryCreator.IsSubEntity(rel, child, parent);
            }
            return isSubentity || model.isNotEntityChild(child);
        }

        /// <summary>
        /// Extends primary table and all subentities with extended properties
        /// </summary>
        /// <param name="parent">DataTable</param>
        /// <param name="editType">string</param>
        /// <param name="scannedTable"></param>
        public static void addSubEntityExtProperties(DataTable parent, string editType, Dictionary<string, bool> scannedTable = null) {
            var dispatcher = HttpContext.Current.getDataDispatcher();
            if (scannedTable == null) {
                scannedTable = new Dictionary<string, bool> { [parent.tableForReading()] = true };//creates a congruent start condition
            }
            setDefaults(parent, editType);
            // propaga sulle tabelle child. Quindi conseidero le ChilRelation, cioè quelle in cui parent è tabella parent
            foreach (DataRelation r in parent.ChildRelations)
            {
                DataTable child = r.ChildTable;
                if (scannedTable.ContainsKey(child.tableForReading())) continue; //skip this if it has already been scanned
                scannedTable[child.tableForReading()] = true; //avoids loops by design
                if (!isSubEntityOrNotEntityChild(r, child, parent)) continue;
                MetaData meta = dispatcher.GetMeta(child.tableForReading());
                meta.DescribeColumns(child);
                manageColDescr(child);
                dispatcher.conn.AddExtendedProperty(child);
                // vado in ricorsione
                addSubEntityExtProperties(child, editType, scannedTable);
            }
        }

        /// <summary>
        /// Returns a list of object. They Represent the parameters passed by the client to the server. calling a web service
        /// </summary>
        /// <param name="parameters"></param> the serialized client object with paris key:value
        /// <returns></returns>
        public static List<Object> getclientParameters(string parameters) {
            var myjsonprm = new JObject();
            if (parameters != null) {
                // lo converto in JObject per manipolare come voglio
                myjsonprm = (JObject)JsonConvert.DeserializeObject(parameters);
            }

            var myprms = new List<Object>();

            // costruisco array di parametri custom
            myjsonprm.Properties()._forEach(p => {
                myprms.Add(p.Value);
            });

            return myprms;

        }


    }

    public class RowStateCount {
        public int countAdded;
        public int countModified;
        public int countDeleted;
    }
}
