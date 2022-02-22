
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


using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Collections.Generic;
using metadatalibrary;
using metaeasylibrary;
using System.Linq;
using Backend.Extensions;
using Backend.CommonBackend;
using System.Web;
using q = metadatalibrary.MetaExpression;
using System.Text;

namespace Backend.Components {

    /// <summary>
    /// Manages conversion of a DataSet into JSon and viceversa
    /// </summary>
    public class DataSetSerializer {

        private static readonly string c_data_format = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'";

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
        private static readonly string CanIgnorePropertyName = "canIgnore";

        // field for autoincrement
        private static readonly string AutoIncrement = "IsAutoIncrement";
        private static readonly string PrefixField = "PrefixField";
        private static readonly string MiddleConst = "MiddleConst";
        private static readonly string IDLength = "IDLength";
        private static readonly string Selector = "Selector";
        private static readonly string SelectorMask = "SelectorMask";
        private static readonly string MySelector = "MySelector";
        private static readonly string MySelectorMask = "MySelectorMask";
        private static readonly string Minimum = "minimumTempValue";
        private static readonly string LinearField = "LinearField";

        /// <summary>
        /// Extended property that means that the column does not really belong to 
        ///   a real table. For example, expression-like column
        /// </summary>
        private static readonly string IsTempColumn = "IsTemporaryColumn";


        /// <summary>
        /// Reads objRow properties as row fields
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <param name="objRow">object</param>
        /// <returns>The DataRow</returns>
        private static void getRowData(DataRow row, object objRow) {
            var dataFieldCurr = objRow.ToString();
            var objCurrRowCurr = (JObject) JsonConvert.DeserializeObject(dataFieldCurr);
            var columns = row.Table.Columns;
            foreach (var dataRowValue in objCurrRowCurr) {
                var field = dataRowValue.Key;
                var rowValue = dataRowValue.Value;

                if (columns[field] == null) {
                    throw new Exception("DataSetSerializer.getRowData: Table " + row.Table.TableName +
                                        " doesn't contain the field: " + field);
                }

                if (columns[field].DataType.Name == "DateTime") {
                    if (rowValue == null || rowValue.ToString().Length == 0) {
                        row[field] = DBNull.Value;
                    }
                    else {
                        row[field] = (DateTime) rowValue; //Convert.ToDateTime(rowValue.ToString());
                    }
                }
                else if (columns[field].DataType.Name == "Byte[]") {
                    if (rowValue == null || rowValue.ToString().Length == 0) {
                        row[field] = DBNull.Value;
                    }
                    else {
                        byte[] bytes = AttachmentUtils.toByte(rowValue.ToString());
                        row[field] = bytes;
                    }
                }
                else {
                    // TODO capire meglio se stringa vuota va considerato null
                    //  if (rowValue == null || rowValue.ToString().Length == 0) {
                    if (rowValue == null) {
                        row[field] = DBNull.Value;
                    }
                    else {
                        row[field] = rowValue;
                    }
                }

            }
        }

        /// <summary>
        /// Adds the Rows read from the json to the table
        /// </summary>
        /// <param name="rows">JToken with the data of the rows</param>
        /// <param name="table">DataTable where add the rows</param>
        private static void addRows(JToken rows, DataTable table) {
            // TODO vedere se è stato considerato tutto.
            var sRows = rows.ToString();

            try {

                // array di righe provenienti dal json 
                JArray obj = JArray.Parse(sRows);
                foreach (var r in obj.Children()) {
                    var objRow = (JObject) JsonConvert.DeserializeObject(r.ToString());

                    // creo nuova riga
                    var currRow = table.NewRow();

                    // var che memorizza lo stato della riga riportato dal client
                    var currRowState = (string) objRow["state"];

                    if (currRowState == "added") {
                        getRowData(currRow, objRow["curr"]);
                        table.Rows.Add(currRow);
                        continue;
                    }

                    getRowData(currRow, objRow["old"]);


                    table.Rows.Add(currRow);


                    currRow.AcceptChanges(); // mette i valori originali, quindi è nello stato Unchanged

                    if (currRowState == "deleted") {
                        currRow.Delete();
                        continue;
                    }

                    if (currRowState == "modified") {
                        getRowData(currRow, objRow["curr"]);
                        // i null non viaggiano da client a server.consiedero null quelli che erano in old e non sono in curr 
                        checkNullInModifiedRow(currRow, objRow["old"], objRow["curr"]);
                    }
                }
            }
            catch (Exception e) {
                throw new Exception("DataSetSerializer.addRows: Table " + table.TableName + " has errors: " +
                                    e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row">row to check, it must be in modified state</param>
        /// <param name="objRowOld">obj of old field with value</param>
        /// <param name="objRowCurr">obj of curr field with value</param>
        private static void checkNullInModifiedRow(DataRow row, object objRowOld, object objRowCurr) {

            // tutti i campi che erano in old e non sono in curr e se lo stato è modified allora passano  a null
            var dataFieldOLD = objRowOld.ToString();
            var objOLDRow = (JObject) JsonConvert.DeserializeObject(dataFieldOLD);
            var columns = row.Table.Columns;

            var dataFieldCurr = objRowCurr.ToString();
            var objCurrRow = (JObject) JsonConvert.DeserializeObject(dataFieldCurr);

            // scorro old. se non trovo il field in curr allora metto  a null
            foreach (var dataRowValue in objOLDRow) {
                var field = dataRowValue.Key;
                var rowValue = dataRowValue.Value;
                // sulla collection dei curr non trovo più quel campo, allora lo metto a null
                if (objCurrRow[field] == null) row[field] = DBNull.Value;
            }
        }

        /// <summary>
        /// get the Datacolumn
        /// </summary>
        /// <param name="type">JToken with colum type data</param>
        /// <returns>The Type of the column</returns>
        private static Type getColumnType(JToken type) {
            var sType = type.ToString();
            return Type.GetType("System." + sType);
        }

        /// <summary>
        /// Sets the primary key on DataTable t.
        /// Keys is a string of columnName separated by comma: "Column1, column2,..."
        /// </summary>
        /// <param name="keys">JToken the string "Column1, column2,..."</param>
        /// <param name="t">DataTable</param>
        /// <returns>The List of DataColumn</returns>
        private static void addKeys(JToken keys, DataTable t) {
            string[] stringSeparators = {","};
            var keysArray = keys.ToString().Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            // costrusico array di stringhe che poi traformerò in array di DataColumn
            if (keysArray.Length > 0) {
                // trasfromo in DataColumn[]
                t.PrimaryKey = keysArray._Map(c => t.Columns[c]);
            }
        }

        /// <summary>
        /// get the Datacolumn
        /// </summary>
        /// <param name="name">string the name of the column</param>
        /// <param name="column">JToken with colum data</param>
        /// <returns>The DataColumn</returns>
        private static DataColumn getColumn(string name, JToken column) {
            var sColumn = column.ToString();
            var obj = (JObject) JsonConvert.DeserializeObject(sColumn);

            var c = new DataColumn(name);

            foreach (var p in obj) {
                var key = p.Key;
                var value = p.Value;
                switch (key) {
                    case "ctype":
                        Type cType = getColumnType(value);
                        c.DataType = cType;
                        break;
                    case "name":
                        break;
                    case "allowDbNull":
                        c.AllowDBNull = (bool) value;
                        break;
                    case "isDenyNull":
                        HelpForm.SetDenyNull(c, (bool) value);
                        //c.ExtendedProperties.Add("DenyNull", (Boolean)value);
                        break;
                    case "isDenyZero":
                        HelpForm.SetDenyZero(c, (bool) value);
                        //c.ExtendedProperties.Add("DenyZero", (Boolean)value);
                        break;
                    case "allowZero":
                        c.ExtendedProperties.Add("allowZero", (Boolean) value);
                        break;
                    case "caption":
                        c.Caption = (string) value;
                        break;
                    case "expression":
                        // TODO Modificare se sarà implementato un  QueryCreator.SetMetaExpression();
                        if (value is JValue) {
                            c.ExtendedProperties.Add(IsTempColumn, value.ToString());
                        }
                        else {
                            var dispatcher = HttpContext.Current.getDataDispatcher();
                            c.ExtendedProperties.Add(IsTempColumn,
                                DataUtils.metaExpressionFromJsDataQueryJson(value.ToString(), dispatcher));
                        }

                        break;
                    case "listColPos":
                        c.ExtendedProperties.Add("ListColPos", (int) value);
                        break;
                    case "maxstringlen":
                        c.ExtendedProperties.Add("maxstringlen", (int) value);
                        break;
                    case "length":
                        c.ExtendedProperties.Add("length", (int) value);
                        break;
                    case "sqltype":
                        c.ExtendedProperties.Add("sqltype", (string) value);
                        break;
                    case "forPosting":
                        QueryCreator.SetColumnNameForPosting(c, (string) value);
                        break;
                    case "format":
                        HelpForm.SetFormatForColumn(c, (string) value);
                        //c.ExtendedProperties.Add("format", (string)value);
                        break;
                    case "isTemporaryColumn":
                        c.ExtendedProperties.Add("IsTemporaryColumn", (string) value);
                        break;

                    case "viewSource":
                        c.ExtendedProperties.Add("ViewSource", (string) value);
                        break;
                }

            }

            return c;

        }

        /// <summary>
        /// Takes the autoincrements JToken. Loops on each columnname as key and set for each column the 
        /// properties for the autoincrement
        /// </summary>
        /// <param name="autoincrements"></param>
        /// <param name="table"></param>
        private static void addAutoIncrementProperties(JToken autoincrements, DataTable table) {
            // N.B autoincrements lato js viene sempre ser. Quindi c'è di solito un un jtoken autoincrement ma sarà senza valori,
            // cioè senza colonne autoincremento
            if (autoincrements.HasValues) {
                var obj = (JObject) JsonConvert.DeserializeObject(autoincrements.ToString());
                // Per ogni colonna autoIncremento presente nel JToken invoco la funz che ne setta le proproetà
                obj.Properties()._forEach(col =>
                    setAutoIncrementColumnProperties(table, table.Columns[col.Name], col.Value));
            }

        }

        /// <summary>
        /// Given the Jtoken column gets the properties of AutoIncrement for the column dc by the client and sets
        /// these properties on the dc DataColumn
        /// </summary>
        /// <param name="table">DataTable</param>
        /// <param name="dc">DataColumn</param>
        /// <param name="column">JToken</param>
        private static void setAutoIncrementColumnProperties(DataTable table, DataColumn dc, JToken column) {
            var sColumn = column.ToString();
            var obj = (JObject) JsonConvert.DeserializeObject(sColumn);


            // ovviamente se sto qui seignifica che è un autoincrement 
            dc.ExtendedProperties[AutoIncrement] = "s";

            // Dichiaro array di selettori e selcetorMask da popolare e succesivamente farne il loop
            var selectors = new List<string>();
            var selectorsMask = new List<UInt64>();

            // N.B per ora utilizzo le prop ExtProp , non il metodo  RowChange.MarkAsAutoincrement(..),
            // poichè delle porp potrebbero non esserci e mandare in errore il successivo codice. Ad
            // esempio middleConst nel caso isNumber non c'è di proposito perchè lato js è grstito in questo
            // modo e se passo nulla a MarkAsAutoincrement poi ottengo errore. allora faccio il set una per una
            foreach (var p in obj) {
                var key = p.Key;
                var value = p.Value;
                switch (key) {
                    case "middleConst":
                        dc.ExtendedProperties[MiddleConst] = value.ToString() != "" ? value.ToString() : null;
                        break;
                    case "idLen":
                        dc.ExtendedProperties[IDLength] = (int) value;
                        break;
                    case "prefixField":
                        dc.ExtendedProperties[PrefixField] = value.ToString() != "" ? value.ToString() : null;
                        break;
                    case "linearField":
                        var linear = (bool) value;
                        if (linear) dc.ExtendedProperties[LinearField] = "1";
                        break;
                    case "minimum":
                        RowChange.setMinimumTempValue(dc, (int) value);
                        break;
                    case "selector":

                        // popolo una lista di appoggio , poichè poi devo settare insieme al mask
                        foreach (var cname in value.Children()) {
                            //var cnameString = (JObject)JsonConvert.DeserializeObject(cname.ToString());
                            var cnameString = cname.ToString();
                            selectors.Add(cnameString);
                        }

                        break;

                    case "selectorMask":

                        // popolo una lista di appoggio , poichè poi devo settare insieme ai selectors
                        foreach (var mask in value.Children()) {
                            var maskUInt64 = (UInt64) mask;
                            selectorsMask.Add(maskUInt64);
                        }

                        break;

                }
            }

            // Ciclo sulla lista dei selettori e invoco metodo opportuno per settare selettore e 
            // mask specifico di colonna. Selettori e mask sono ordinati in maniera posizionale.
            // Non ci sarà più distinzione tra selettori generici e specifici, diventano dopo la ser c# -> js tutti
            // specifici e quindi in questo caso js->c# ritrovo tutti specifici, ma tutto continua a funzionare nel backend
            /*if (selectors.Count != selectorsMask.Count)
            {
                throw new ArgumentException("Error in autoincrement selectors config for column " + dc.ColumnName);
            }*/

            // TODO capire meglio lato client come serializzare l'ordine
            // dei selettorie  dei selector mask
            for (var i = 0; i < selectors.Count; i++) {
                ulong mask = 1;
                if (selectorsMask.Count > 0 && i < selectorsMask.Count) {
                    mask = (ulong) selectorsMask[i];
                }

                RowChange.SetSelector(table, selectors[i], mask);
            }

        }

        /// <summary>
        /// Sets the DefaultValue based on defaults property values.
        /// default is on object with pairs name,value
        /// </summary>
        /// <param name="defaults"></param>
        /// <param name="table"></param>
        private static void addColumnDefaults(JToken defaults, DataTable table) {
            var obj = (JObject) JsonConvert.DeserializeObject(defaults.ToString());
            obj.Properties()._forEach(col => {
                if (col.Value.Type != JTokenType.Null) {
					if (table.Columns[col.Name] == null)
						throw new Exception("Colonna " + col.Name + 
							" non trovata durante il set dei valori di default. Contorollare i set default.");
                    table.Columns[col.Name].DefaultValue = col.Value;
                }
            });
        }

        /// <summary>
        /// Deserializes a DataTable
        /// </summary>
        /// <param name="dataTable">JToken with table data</param>
        /// <returns>The DataTable</returns>
        public static MetaTable jTokenToTable(JToken dataTable, Dispatcher dispatcher) {
            var name = dataTable["name"].ToString();
            var table = new MetaTable(name);
			try {
				var jObj = (JObject)JsonConvert.DeserializeObject(dataTable.ToString());

				// deserializzo gli oggetti colonna, ogni oggetto colonna  a sua volta (il col.Value) è un oggetto con varie proprietà
				if (jObj["columns"] != null) {
					var obj = (JObject)JsonConvert.DeserializeObject(jObj["columns"].ToString());
					obj.Properties()._forEach(col => table.Columns.Add(getColumn(col.Name, col.Value)));
				}

				// deserializzo gli oggetti autoIncrementColumns per ogni colonna
				if (jObj["autoIncrementColumns"] != null) addAutoIncrementProperties(jObj["autoIncrementColumns"], table);

				//  Deserializza la proprietà di default.
				//  Per ogni DataColumn del DataTable, nella proprietà DefaultValue, mette il valore della proprietà 
				//  di pari nome nell'oggetto default del jsDataTable, saltando quelle null 
				if (jObj["defaults"] != null) addColumnDefaults(jObj["defaults"], table);

				// Aggiungo key dopo le columns
				if (jObj["key"] != null) addKeys(jObj["key"], table);

				// aggiungo righe
				if (jObj["rows"] != null) addRows(jObj["rows"], table);


				// staticFilter
				if (jObj["staticFilter"] != null) {
					// recupero stringa
					var staticFilter = jObj["staticFilter"]?.ToString();
					// torno la metaexpression
					var meFilter = DataUtils.metaExpressionFromJsDataQueryJson(staticFilter, dispatcher);
					//DataUtils.getfilterFromJsDataQuery(staticFilter, dispatcher);
					// trasformo sempre in stringa. 
					table.ExtendedProperties["filter"] = meFilter?.toSql(dispatcher.conn.GetQueryHelper(), dispatcher.conn);
					table.ExtendedProperties["filterMetaExpression"] = meFilter;
					//table.ExtendedProperties["filterMetaExpr"] = jObj["staticFilter"];
				}

				// tableForReading
				var tableName = name;
				if (jObj["tableForReading"] != null) tableName = jObj["tableForReading"]?.ToString();
				DataAccess.SetTableForReading(table, tableName);

				// tableForWriting
				tableName = null;
				if (jObj["tableForWriting"] != null) tableName = jObj["tableForWriting"]?.ToString();
				QueryCreator.SetTableForPosting(table, tableName);


				// isCached. inizializzo proprietà tabella
				GetData.UnCacheTable(table);
				if (jObj["isCached"] != null) {
					if (jObj["isCached"].ToString() == "0") GetData.CacheTable(table);

					if (jObj["isCached"].ToString() == "1") GetData.LockRead(table);
				}

				// isTemporaryTable
				PostData.MarkAsRealTable(table);
				if (jObj["isTemporaryTable"] != null) {
					if ((Boolean)jObj["isTemporaryTable"]) {
						PostData.MarkAsTemporaryTable(table, false);
					}
					else {
						PostData.MarkAsRealTable(table);
					}
				}

				// skypSecurity è settato/ritornato dalle funz in setSkipSecurity/isSkipSecurity su metaModel
				// va bene anche così, ma capire se si possono utilizzare i emtodi in MetaModel
				if (jObj["skipSecurity"] != null) {
					if ((Boolean)jObj["skipSecurity"]) {
						table.ExtendedProperties["SkipSecurity"] = true;
					}
					else {
						table.ExtendedProperties["SkipSecurity"] = (object)null;
					}
				}

				// skipInsertCopy
				if (jObj["skipInsertCopy"] != null) {
					if ((Boolean)jObj["skipInsertCopy"]) {
						QueryCreator.setSkipInsertCopy(table, true);
					}
					else {
						QueryCreator.setSkipInsertCopy(table, false);
					}
				}

				// realTable. utilizzo delle ext prop RealTableName perchè poi quelleutili realTable e viewTable saranno tabelle vere e proprie prese dal dataset
				if (jObj["realTable"] != null) {
					table.ExtendedProperties["RealTableName"] = (string)jObj["realTable"];
				}

				// viewTable
				if (jObj["viewTable"] != null) {
					table.ExtendedProperties["ViewTableName"] = (string)jObj["viewTable"];
				}

				// denyClear
				if (jObj["denyClear"] != null) {
					if ((String)jObj["denyClear"] == "y") {
						table.setDenyClear();
					}
					else {
						table.setAllowClear();
					}
				}
				else {
					table.setAllowClear();
				}


				// orderBy 
				if (jObj["orderBy"] != null) table.setSorting((string)jObj["orderBy"]);

				return table;
			}
			catch (Exception e) {
				throw new Exception("Errore nella serializzazione della taella: " + table.TableName + "; " + e.Message);
			}
        }


        /// <summary>
        /// Returns a RelationObj, with the info of the relation
        /// </summary>
        /// <param name="name">string</param>
        /// <param name="relation">JToken</param>
        /// <param name="dataSet">DataSet</param>
        /// <returns>a RelationObj</returns>
        public static void createRelationFromJToken(string name, JToken relation, DataSet dataSet) {

            var stringSeparators = new[] {","};

            var obj = (JObject) JsonConvert.DeserializeObject(relation.ToString());
            var parentCols = obj["parentCols"].ToString()
                .Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            var childCols = obj["childCols"].ToString().Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            var parentTable = dataSet.Tables[obj["parentTable"].ToString()];
            var childTable = dataSet.Tables[obj["childTable"].ToString()];

            //trasformo array di stringhe di colonne in array di DataColumn
            var parentColumns = parentCols._Map(colName => parentTable.Columns[colName]);
            var childColumns = childCols._Map(colName => childTable.Columns[colName]);

            dataSet.Relations.Add(name, parentColumns, childColumns, false);
        }

        /// <summary>
        /// Create a DataSet from a JSON string
        /// </summary>
        /// <param name="jObj"></param>
        /// <returns></returns>
        public static DataSet deserialize(JObject jObj, Dispatcher dispatcher) {


            // trasformo in JObject
            var dataSet = new DataSet();

            if (jObj["name"] != null) dataSet.DataSetName = (string) jObj["name"];

            // Recupero tabelle con colonne e righe
            if (jObj["tables"] != null) {
                var obj = (JObject) JsonConvert.DeserializeObject(jObj["tables"].ToString());
                obj.Properties()._forEach(t => dataSet.Tables.Add(jTokenToTable(t.Value, dispatcher)));
            }

            // Recupero relazioni
            if (jObj["relations"] != null) {
                var obj = (JObject) JsonConvert.DeserializeObject(jObj["relations"].ToString());
                obj.Properties()._forEach(r => createRelationFromJToken(r.Name, r.Value, dataSet));
            }

            // alla fine della deserializzazione popola realTable and viewTable, che sono oggetti di tipo DataTable
            populatesViewAndRealTableProperties(dataSet);

            return dataSet;
        }

        /// <summary>
        /// Reads RealTableName and ViewTableName properties and assign the realTable and viewTable proeprties
        /// </summary>
        /// <param name="dataSet"></param>
        private static void populatesViewAndRealTableProperties(DataSet dataSet) {
            foreach (DataTable table in dataSet.Tables) {
                string realTableName = (string) table.ExtendedProperties["RealTableName"];
                string viewTableName = (string) table.ExtendedProperties["ViewTableName"];
                if (!String.IsNullOrEmpty(realTableName)) {
                    DataTable dtReal = dataSet.Tables[realTableName];
                    if (dtReal != null) {
                        table.ExtendedProperties["RealTable"] = dtReal;
                    }
                }

                if (!String.IsNullOrEmpty(viewTableName)) {
                    DataTable dtView = dataSet.Tables[viewTableName];
                    if (dtView != null) {
                        table.ExtendedProperties["ViewTable"] = dtView;
                    }
                }
            }
        }



        /// <summary>
        /// Takes a DataColumn array and returns a string with the concatenation of the columnName separated with ","
        /// </summary>
        /// <param name="colsArray">DataColumn[]</param>
        /// <returns>a string, for example "columnName1,columnName2,columnName3" </returns>
        private static string getColumnNamesJoinString(IEnumerable<DataColumn> colsArray) {
            return string.Join(",", colsArray._Map(c => c.ColumnName));
        }

        /// <summary>
        /// Takes a DataColumn and returns a Dictionary with useful properties and ExtendedProperties
        /// </summary>
        /// <param name="dc">DataColumn</param>
        /// <returns>The Dictionary with useful properties and ExtendedProperties of DataColumn</returns>
        private static JObject getColumnProperties(DataColumn dc) {
            var dictcolProp = new JObject();

            if (dc.Caption != null) dictcolProp.Add("caption", dc.Caption);

            if (dc.ColumnName != null) dictcolProp.Add("name", dc.ColumnName);

            if (dc.DataType != null) dictcolProp.Add("ctype", dc.DataType.ToString().Replace("System.", ""));

            dictcolProp.Add("allowDbNull", dc.AllowDBNull);

            dictcolProp.Add("isDenyNull", HelpForm.IsDenyNull(dc));

            dictcolProp.Add("isDenyZero", HelpForm.IsDenyZero(dc));

            if (dc.ExtendedProperties["allowZero"] != null)
                dictcolProp.Add("allowZero", getJTokenFromObject(dc.ExtendedProperties["allowZero"]));

            if (dc.ExtendedProperties["ListColPos"] != null)
                dictcolProp.Add("listColPos", getJTokenFromObject(dc.ExtendedProperties["ListColPos"]));

            if (dc.ExtendedProperties["maxstringlen"] != null)
                dictcolProp.Add("maxstringlen", getJTokenFromObject(dc.ExtendedProperties["maxstringlen"]));

            if (dc.ExtendedProperties["length"] != null)
                dictcolProp.Add("length", getJTokenFromObject(dc.ExtendedProperties["length"]));

            // potrei fare dictcolProp.Add("format", HelpForm.GetFormatForColumn(dc)); ma controllo solo la ext prop
            // altrimenti vado in conflitto con la logica implementata dal client per i default.
            if (dc.ExtendedProperties["format"] != null)
                dictcolProp.Add("format", getJTokenFromObject(dc.ExtendedProperties["format"]));

            // expression potrebbe essere o una stringa del tipo 1. table.columnName, o 2. una MetaExpression.
            // Serve per calcolare il valore di un campo, secpondo il campo di un altra tabella come nel caso 1 oppure
            // tramite il calcolo di una funz come nel caso 2.
            var expr = dc.ExtendedProperties[IsTempColumn];
            if (expr != null) {
                if (expr is MetaExpression) dictcolProp.Add("expression", MetaExpressionSerializer.serialize(expr));

                if (expr is string) dictcolProp.Add("expression", getJTokenFromObject(expr));

            }

            if (dc.ExtendedProperties["sqltype"] != null)
                dictcolProp.Add("sqltype", getJTokenFromObject(dc.ExtendedProperties["sqltype"]));


            dictcolProp.Add("forPosting", QueryCreator.PostingColumnName(dc));

            if (dc.ExtendedProperties["ViewSource"] != null)
                dictcolProp.Add("viewSource", getJTokenFromObject(dc.ExtendedProperties["ViewSource"]));


            return dictcolProp;
        }

        /// <summary>
        /// creates a dictionary where the keys are the AutoIncrement propertties for the Datacolumn dc
        /// </summary>
        /// <param name="dc">DataColumn</param>
        /// <param name="genericSelectors">List<string></param>
        /// <param name="genericSelectorsMask">List<string></param>
        /// <returns></returns>
        private static JObject getColumnDictAutoincrementProperties(DataColumn dc, List<string> genericSelectors,
            List<string> genericSelectorsMask) {
            var dictcolAutoincrProp = new JObject();

            if (dc.ColumnName != null) dictcolAutoincrProp.Add("columnName", dc.ColumnName);


            // N.B:
            // AutoIncrement già insita nel fatto sia un autoIncrement, quindi IsAutoIncrement della funz chiamante
            // CustomAutoIncrement non è serailizzabile, dovrebbe esser gestita come autoincremento generico
            // PrefixField, MiddleConst, IDLength : li prendo da ext prop
            // Selector, SelectorMask : costruisco array prendendo i MySelector + MySelectorMask + quelly generici selector + selectorMask


            // Dichiaro array di selettori e selettori Mask da popolare e succesivamente serializzare
            var selectors = new List<string>();
            var selectorsMask = new List<string>();

            // 1.aggiungo prima i selector generici, passati come parametri e precalcolati in un ciclo sulle colonne precedente
            foreach (var genericSel in genericSelectors) {
                selectors.Add(genericSel);
            }

            foreach (var genericSelMask in genericSelectorsMask) {
                selectorsMask.Add(genericSelMask);
            }

            // 2. recupero le proprietà specifiche dei selettori di colonna
            string mySelector = dc.ExtendedProperties[MySelector] != null
                ? dc.ExtendedProperties[MySelector].ToString()
                : null;
            string mySelectorMask = dc.ExtendedProperties[MySelectorMask] != null
                ? dc.ExtendedProperties[MySelectorMask].ToString()
                : null;

            // 3. ora aggiungo i mySelector, che sono una stringa separata da ","
            if (mySelector != null && mySelectorMask != null) {

                var arrayOfMySelectors = mySelector.Split(',');
                var arrayOfMySelectorsMask = mySelectorMask.Split(',');

                // ciclo sulle posizioni dei selector e aggiungo nell'array finale solo se già non esiste
                // TODO, capire per quelle che esistono già nei genrici il quale mask va considerato
                for (int i = 0; i < arrayOfMySelectors.Length; i++) {
                    var mySel = arrayOfMySelectors[i];
                    if (!selectors.Contains(mySel)) {
                        selectors.Add(mySel);
                        selectorsMask.Add(arrayOfMySelectorsMask[i]);
                    }

                }
            }

            // Modifico valori di "idLen", "middleConst", "prefixField" nel caso si tratti di una colonna
            // numerica. In quanto lato js questo AutoIncrement deve essere trattato come isNumber

            if (dc.DataType == System.Type.GetType("System.Decimal") ||
                dc.DataType == System.Type.GetType("System.Double") ||
                dc.DataType == System.Type.GetType("System.Int64") ||
                dc.DataType == System.Type.GetType("System.Int32") ||
                dc.DataType == System.Type.GetType("System.Int16") ||
                dc.DataType == System.Type.GetType("System.Single")
            ) {
                dictcolAutoincrProp.Add("idLen", getJTokenFromObject(0));
            }
            else {
                dictcolAutoincrProp.Add("prefixField", getJTokenFromObject(dc.ExtendedProperties[PrefixField]));
                dictcolAutoincrProp.Add("middleConst", getJTokenFromObject(dc.ExtendedProperties[MiddleConst]));
                dictcolAutoincrProp.Add("idLen", getJTokenFromObject(dc.ExtendedProperties[IDLength]));
            }

            dictcolAutoincrProp.Add("selector", getJTokenFromObject(selectors)); // array
            dictcolAutoincrProp.Add("selectorMask", getJTokenFromObject(selectorsMask)); // array
            dictcolAutoincrProp.Add("minimum", getJTokenFromObject(dc.ExtendedProperties[Minimum]));
            dictcolAutoincrProp.Add("linearField", getJTokenFromObject(dc.ExtendedProperties[LinearField]));

            return dictcolAutoincrProp;
        }

        /// <summary>
        /// Returns a Jtoken form object. if the object is null it returns a null Jtoken
        /// </summary>
        /// <param name="o">object</param>
        /// <returns>JToken</returns>
        private static JToken getJTokenFromObject(object o) {
            JToken res = (o != null) ? JToken.FromObject(o) : null;
            return res;
        }

        /// <summary>
        /// Executes some check on the rowValue and returns an object that represents the value
        /// </summary>
        /// <param name="rowValue">object that contains the value</param>
        /// <returns>an object that represents the value</returns>
        private static object getRowColumnValue(object rowValue) {
            // se è data applico la formattazione
            if (rowValue is DateTime) return ((DateTime) rowValue).ToString(c_data_format);

            return rowValue;
        }

        /// <summary>
        /// Take a DataSet and return a json string serialized with jsDataSet convention
        /// </summary>
        /// <param name="ds">Dataset to serialize in json format</param>
        /// <returns>The json string, representation of the ds DataSet with jsDataSet convention</returns>
        public static JObject serialize(DataSet ds) {

            var myTables = new JObject();

            // eseguo loop sulle tabelle
            foreach (DataTable t in ds.Tables) {
                var tCurr = serializeDataTable(t);
                myTables.Add(t.TableName, tCurr);

            }
            // Fine loop sulle Tabelle


            // *********************************** Popolo struttura per Relazioni **********************************************
            var myRelations = ds.Relations.Cast<DataRelation>()._Reduce(
                (dict, rel) => {
                    dict.Add(rel.RelationName, new JObject {
                        {"parentTable", rel.ParentTable.TableName},
                        {"parentCols", getColumnNamesJoinString(rel.ParentColumns)},
                        {"childTable", rel.ChildTable.TableName},
                        {"childCols", getColumnNamesJoinString(rel.ChildColumns)}
                    });
                    return dict;
                },
                new JObject()
            );

            // ********************************** Costruisco oggetto finale da farne il json **************************************
            // inserisco gli oggetti costruiti in maniera opportuna, per poter serializzare il json nel formato aspettato dal client
            var root = new JObject {
                {"name", ds.DataSetName},
                {"relations", myRelations},
                {"tables", myTables}
            };
            // ********************************************************************************************************************

            return root;
        }

        public static JArray serializeRows(IEnumerable<DataRow> rows) {
            var jRow = rows.Cast<DataRow>()._Map(r => {
                var rDic = new JObject {["state"] = r.RowState.ToString().ToLowerInvariant()};
                if (r.RowState == DataRowState.Deleted || r.RowState == DataRowState.Modified
                                                       || r.RowState == DataRowState.Unchanged
                ) {
                    rDic["old"] = r.Table.Columns.Cast<DataColumn>()._Reduce((dict, col) => {
                        var value = getRowColumnValue(r[col.ColumnName, DataRowVersion.Original]);
                        if (value != DBNull.Value) dict[col.ColumnName] = getJTokenFromObject(value);
                        return dict;
                    }, new JObject());
                }

                if (r.RowState == DataRowState.Added || r.RowState == DataRowState.Modified
                    //   ||r.RowState == DataRowState.Unchanged
                ) {
                    rDic["curr"] = r.Table.Columns.Cast<DataColumn>()._Reduce((dict, col) => {
                        var value = getRowColumnValue(r[col.ColumnName]);
                        if (value != DBNull.Value) dict[col.ColumnName] = getJTokenFromObject(value);
                        return dict;
                    }, new JObject());
                }

                return rDic;
            });

            /* var tCurr = new Dictionary<string, object> {
                 {"rows", jRow}
             };*/
            var res = new JArray();
            foreach (var r in jRow) res.Add(r);
            return res;
        }

        /// <summary>
        /// Take a DataTable and return a json string serialized with js DataTable convention
        /// </summary>
        /// <param name="dt">DataTable to serialize in json format</param>
        /// <returns>The json string, representation of the ds DataTable with js DataTable convention</returns>
        public static JObject serializeDataTable(DataTable dt) {
            // dictionary di colonne, chiave nome colonna + dict di properties (fisse  + eventuali extendedProperties)
            var myColumns = new JObject();
            var myAutoIncrementColumns = new JObject();
            var myDefaults = new JObject();

            // *********************************** Popolo struttura per colonne ****************************************

            // Primo ciclo per calcolare array di selector generici, cioè vede se la colonna è un selector generico
            // e l'aggiunge nella lista. poichè poi sarà aggiunta nell'array pecifico per colonna nella getColumnDictAutoincrementProperties()
            List<string> listOfSelector = new List<string>();
            List<string> listOfSelectorMask = new List<string>();

            foreach (DataColumn c in dt.Columns) {
                // TODO l'if è == "y" o basta sia !=null ??????
                if (c.ExtendedProperties[Selector] != null) {
                    listOfSelector.Add(c.ColumnName);

                    // Default è 0
                    var selectorMask = "0";
                    if (c.ExtendedProperties[SelectorMask] != null) {
                        selectorMask = c.ExtendedProperties[SelectorMask].ToString();
                    }

                    listOfSelectorMask.Add(selectorMask);

                }
            }

            foreach (DataColumn c in dt.Columns) {
                myColumns.Add(c.ColumnName, getColumnProperties(c));

                // ******************************* proprietà autoincremento *********************************************
                if (RowChange.IsAutoIncrement(c)) {
                    myAutoIncrementColumns.Add(c.ColumnName,
                        getColumnDictAutoincrementProperties(c, listOfSelector, listOfSelectorMask));
                }

                // ************** Aggiunge la serializzazione del set di default per le colonne del datatable ***********
                // distunguo caso sia una data, in quel caso formatto nel formato aspettato
                object defValue = c.DefaultValue;
                if (defValue is DateTime) {
                    defValue = ((DateTime) defValue).ToString(c_data_format);
                }

                myDefaults.Add(c.ColumnName, getJTokenFromObject(defValue));
            }

            // ******************************************************* Popolo righe *******************************************
            var rows = serializeRows(dt.Rows.Cast<DataRow>());


            // ***************************************** Serializzo lo staticFilter come jsDataQuery **************************
            JObject staticFilter = null;
            if (dt.ExtendedProperties["filterMetaExpression"] != null) {
                staticFilter = MetaExpressionSerializer.serialize(dt.ExtendedProperties["filterMetaExpression"]);
            }  

            //********************************* Costrusice entry per la tabella attuale ***************************************

            var tCurr = new JObject {
                {"name", dt.TableName},
                {"key", string.Join(",", dt.PrimaryKey.Select(dc => dc.ColumnName).ToArray())},
                {"columns", myColumns},
                {"rows", rows},
                {"tableForReading", DataAccess.GetTableForReading(dt)},
                {"tableForWriting", QueryCreator.PostingTableName(dt)},
                {"isCached", getJTokenFromObject(dt.ExtendedProperties["cached"])},
                {"isTemporaryTable", PostData.IsTemporaryTable(dt)},
                {"autoIncrementColumns", myAutoIncrementColumns},
                {"staticFilter", staticFilter},
                {"skipSecurity", (dt.ExtendedProperties["SkipSecurity"] != null)},
                {"skipInsertCopy", QueryCreator.SkipInsertCopy(dt)}, {
                    "realTable",
                    (dt.ExtendedProperties["RealTable"] != null
                        ? ((DataTable) dt.ExtendedProperties["RealTable"]).TableName
                        : "")
                }, {
                    "viewTable",
                    (dt.ExtendedProperties["ViewTable"] != null
                        ? ((DataTable) dt.ExtendedProperties["ViewTable"]).TableName
                        : "")
                }, {
                    "denyClear",
                    (dt.ExtendedProperties["DenyClear"] != null ? (String) dt.ExtendedProperties["DenyClear"] : null)
                },
                {"defaults", myDefaults},
                {"orderBy", dt.getSorting()}
            };

            return tCurr;

        }


        /// <summary>
        /// Returns a ProcedureMessageCollection
        /// </summary>
        /// <param name="jArr">Aaay of messages sent by client</param>
        /// <returns></returns>
        public static ProcedureMessageCollection deserializeMessages(JArray jArr) {
            // Rigenera l'elenco dei messaggi
            var pmc = new ProcedureMessageCollection();
            if (pmc != null) {

                foreach (var mo in jArr.Children()) {
                    var m = (JObject) JsonConvert.DeserializeObject(mo.ToString());

                    var pm = new EasyProcedureMessage();
                    var audit = m[AuditPropertyName];
                    pm.AuditID = audit?.ToObject<string>();
                    var errorType = m[SeverityPropertyName];
                    pm.ErrorType = errorType?.ToObject<string>();
                    var longMsg = m[DescriptionPropertyName];
                    pm.LongMess = longMsg?.ToObject<string>();
                    var tableName = m[TablePropertyName];
                    pm.TableName = tableName?.ToObject<string>();
                    var canIgnore = m[CanIgnorePropertyName];
                    pm.CanIgnore = canIgnore.ToObject<bool>();

                    pmc.Add(pm);

                }

            }

            return pmc;
        }

        /// <summary>
        /// Given a ProcedureMessageCollection return an object to serialize
        /// </summary>
        /// <param name="pmc"></param>
        /// <returns></returns>
        public static object serializeMessages(ProcedureMessageCollection pmc) {
            var messages = new JArray();
            // Genera la struttura contenente i messaggi
            if (pmc != null) {

                foreach (EasyProcedureMessage pm in pmc) {
                    var message = new JObject();
                    if (pm.LongMess != null) {
                        message.Add(DescriptionPropertyName, getJTokenFromObject(pm.LongMess));
                    }

                    if (pm.AuditID != null) {
                        message.Add(AuditPropertyName, getJTokenFromObject(pm.AuditID));
                    }

                    if (pm.ErrorType != null) {
                        message.Add(SeverityPropertyName, getJTokenFromObject(pm.ErrorType));
                    }

                    if (pm.TableName != null) {
                        message.Add(TablePropertyName, getJTokenFromObject(pm.TableName));
                    }

                    // booleano è sempre diverso da null
                    message.Add(CanIgnorePropertyName, getJTokenFromObject(pm.CanIgnore));

                    // serializzo informazione che lato client identifico con id. Non servirà deserializzare
                    var id = "";
                    string pre_post = pm.PostMsgs ? "post" : "pre";
                    if (pm.TableName == null || pm.Operation == null || pm.EnforcementNumber == null) {
                        id = "dberror";
                    }
                    else {
                        id = pre_post + "/" + pm.TableName + "/" + pm.Operation.Substring(0, 1) + "/" +
                             pm.EnforcementNumber.ToString();
                    }

                    message.Add("id", getJTokenFromObject(id));

                    // aggiungo sinoglo messaggio costruito all'array
                    messages.Add(message);
                }
            }

            return messages;
        }

    }
}
