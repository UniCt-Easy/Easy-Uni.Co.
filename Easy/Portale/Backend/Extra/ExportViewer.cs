/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.UI.WebControls;

using metadatalibrary;

using Backend.CommonBackend;
using static Backend.Controllers.DataController;

using export_default;


namespace Backend.Extra {

    /// <summary>
    /// Enumerazione dei tipi di dato supportati.
    /// </summary>
    public enum DataType {
        /// <summary>
        /// Intero  lungo (32 bit)
        /// </summary>
        Int32,
        /// <summary>
        /// Intero corto (16 bit)
        /// </summary>
        Int16,
        /// <summary>
        /// Byte (8 bit)
        /// </summary>
        Byte,
        /// <summary>
        /// Data e ora (DateTime)
        /// </summary>
        DateTime,
        /// <summary>
        /// Stringa (testo)
        /// </summary>
        String,
    }

    /// <summary>
    /// Classe per la mappatura dei tipi di dato definiti nell'enumerazione <see cref="DataType"/> ai tipi .NET corrispondenti.
    /// </summary>
    public static class DataMappings {

        /// <summary>
        /// Associa i tipi di dato definiti nell'enumerazione <see cref="DataType"/> ai tipi .NET corrispondenti.
        /// </summary>
        public static Dictionary<DataType, Type> DataTypeMap = new Dictionary<DataType, Type> {
            {
                DataType.Int32,
                typeof(int)
            },
            {
                DataType.Int16,
                typeof(short)
            },
            {
                DataType.Byte,
                typeof(byte)
            },
            {
                DataType.DateTime,
                typeof(DateTime)
            },
            {
                DataType.String,
                typeof(string)
            }
        };

        /// <summary>
        /// Recupera il tipo .NET associato a un tipo di dato specificato come stringa.
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static Type GetType(string dataType) {

            if (Enum.TryParse(dataType, true, out DataType parsedDataType) && DataTypeMap.TryGetValue(parsedDataType, out var type)) {
                return type;
            }

            throw new ArgumentException($"Tipo di dato sconosciuto: '{dataType}'");
        }
    }

    /// <summary>
    /// Defines the configuration for export or report definitions.
    /// </summary>
    public interface IExportConfig {
        /// <summary>
        /// Gets the unique identifier for the entity.
        /// </summary>
        string Id { get; }
        /// <summary>
        /// Table containing the export or report definition.
        /// </summary>
        string DefinitionTablename { get; }
        /// <summary>
        /// Table containing the parameters for the export or report definition.
        /// </summary>
        string ParametersTablename { get; }
        /// <summary>
        /// Gets the default file extension for the export or report definition.
        /// </summary>
        string DefaultExtension { get; }
    }

    /// <summary>
    /// Defines the DataSet configuration for export definitions.
    /// </summary>
    public class ExportConfig : IExportConfig {
        /// <summary>
        /// Gets the unique identifier for the entity.
        /// </summary>
        public string Id { get; }
        /// <summary>
        /// Gets the name of the table used for export definitions.
        /// </summary>
        public string DefinitionTablename => "exportfunction";
        /// <summary>
        /// Gets the name of the table used to store export parameters definitions.
        /// </summary>
        public string ParametersTablename => "exportfunctionparam";
        /// <summary>
        /// Gets the default file extension for the export.
        /// </summary>
        public string DefaultExtension => "xlsx";
        /// <summary>
        /// Initializes a new instance of the <see cref="ExportConfig"/> class with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier for the export configuration. Must not be null or empty.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="id"/> is null or an empty string.</exception>
        public ExportConfig(string id) { Id = !string.IsNullOrEmpty(id) ? id : throw new ArgumentException("The identifier cannot be null or empty"); }
    }

    /// <summary>
    /// Defines the DataSet configuration for report definitions.
    /// </summary>
    public class ReportConfig : IExportConfig {
        /// <summary>
        /// Gets the unique identifier for the entity.
        /// </summary>
        public string Id { get; }
        /// <summary>
        /// Gets the name of the table used for report definitions.
        /// </summary>
        public string DefinitionTablename => "report";
        /// <summary>
        /// Gets the name of the database table used to store report parameters definitions.
        /// </summary>
        public string ParametersTablename => "reportparameter";
        /// <summary>
        /// Gets the default file extension for the report.
        /// </summary>
        public string DefaultExtension => "pdf";
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportConfig"/> class with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier for the report configuration. Must not be null or empty.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="id"/> is null or an empty string.</exception>
        public ReportConfig(string id) { Id = !string.IsNullOrEmpty(id) ? id : throw new ArgumentException("The identifier cannot be null or empty"); }
    }

    /// <summary>
    /// Exception thrown when no data is found during an operation that requires data.
    /// </summary>
    [Serializable]
    public class NoDataException : Exception {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoDataException"/> class with a default message.
        /// </summary>
        public NoDataException()
            : base("No data was found.") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NoDataException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public NoDataException(string message)
            : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NoDataException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public NoDataException(string message, Exception innerException)
            : base(message, innerException) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NoDataException"/> class with serialized data.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected NoDataException(System.Runtime.Serialization.SerializationInfo info,
                                  System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }

    /// <summary>
    /// Manages the creation and initialization of a DataSet for export or report definitions.
    /// </summary>
    public class ExportViewerManager {

        /// <summary>
        /// Gets the export configuration used by this manager.
        /// </summary>
        public IExportConfig Config { get; }

        private readonly Dispatcher _dispatcher;
        private string _editType { get; }
        private Dictionary<(string, string),(string, string)[]> _webListredirCache { get; }

        /// <summary>
        /// 
        /// </summary>
        private static readonly Dictionary<string, int> defaultListingTypes = new[] { "default", "" }
           .Select((t, i) => new { Type = t, Index = i })
           .ToDictionary(x => x.Type, x => x.Index);

        /// <summary>
        /// The primary table name used for export viewers.
        /// </summary>
        public static string PrimaryTablename { get; } = "exportviewer";

        /// <summary>
        /// A dictionary that maps configurations to their corresponding rendering actions for file generation.
        /// </summary>
        private readonly Dictionary<Type, Action<DataSet, List<KeyValuePair<string, object>>, string>> renderers;

        /// <summary>
        /// Determines whether the specified table name matches the primary table name used for export viewers.
        /// </summary>
        /// <param name="tableName">The name of the table to check. Cannot be <see langword="null"/> or empty.</param>
        public static bool IsExportViewer(string tableName) => tableName == PrimaryTablename;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExportViewerManager"/> class with the specified dispatcher
        /// and edit type.
        /// </summary>
        /// <remarks>The constructor parses the <paramref name="editType"/> string to determine
        /// the export configuration type and ID.  Supported configuration types are "exportfunction" and "report".
        /// The configuration type is case-insensitive.</remarks>
        /// <param name="dispatcher">The <see cref="Dispatcher"/> instance used to manage thread-safe operations.</param>
        /// <param name="editType">A string representing the edit type in the format "exportConfigTablename_idExportConfig".
        /// The first part specifies the configuration type (e.g., "exportfunction" or "report"),
        /// and the second part specifies the ID of the export configuration.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="editType"/> is null, empty, or not in the expected format
        /// "exportConfigTablename_idExportConfig". Also thrown if the configuration type specified in <paramref
        /// name="editType"/> is not recognized.</exception>
        public ExportViewerManager(Dispatcher dispatcher, string editType = "default") {
            _dispatcher = dispatcher;
            _editType = editType;

            #region tounify
            //var web_listredir = _dispatcher.conn.CreateTableByName("web_listredir", "*");
            //_dispatcher.conn.RUN_SELECT_INTO_TABLE(web_listredir, null, null, null, false);

            //bool IsValid(DataRow row) =>
            //    row["tablename"] != DBNull.Value &&
            //    row["listtype"] != DBNull.Value &&
            //    row["newtablename"] != DBNull.Value &&
            //    row["newlisttype"] != DBNull.Value &&
            //    CacheMDLW.metaDataCache_primaryKey.ContainsKey(row["newtablename"].ToString()); // la nuova tabella deve avere una chiave primaria definita nella cache

            _webListredirCache = QueryRedirections(_dispatcher);

            #endregion

            if(string.IsNullOrEmpty(editType)) editType = "default";    

            var separatorIndex = editType.IndexOf('_');
            if (separatorIndex == -1 || separatorIndex == editType.Length - 1) {
                throw new ArgumentException($"Edit type '{editType}' is not valid for ExportViewerManager. Expected format: 'exportConfigTablename_idExportConfig'.");
            }

            var configTablename = editType.Substring(0, separatorIndex).ToLowerInvariant();
            var idExportConfig = editType.Substring(separatorIndex + 1);

            switch (configTablename) {
                case "exportfunction":
                    Config = new ExportConfig(idExportConfig);
                    break;

                case "report":
                    Config = new ReportConfig(idExportConfig);
                    break;

                default:
                    throw new ArgumentException($"Unknown export config type: '{configTablename}'. Expected 'export' or 'report'.");
            }

            // Inizializziamo il dizionario dei renderer per le esportazioni e report, lo facciamo nel costruttore perchè
            // gli handler utilizzano il dispatcher di istanza
            renderers = new Dictionary<Type, Action<DataSet, List<KeyValuePair<string, object>>, string>> {
                [typeof(ExportConfig)] = (ds, parameters, filename) => RenderExport(ds, parameters, filename),
                [typeof(ReportConfig)] = (ds, parameters, filename) => RenderReport(ds, parameters, filename)
            };
        }

        /// <summary>
        /// Retrieves the redirections for the given table names.
        /// Returns all redirections if no table names are specified.
        /// </summary>
        /// <param name="d">Dispatcher, if null it will be taken from the current HttpContext.</param>
        /// <param name="tableNamesListtypes">Table names with list types.</param>
        /// <returns>Mappings between table names and listing types before and after the redirection.</returns>
        /// <exception cref="Exception"></exception>
        public static Dictionary<(string, string), (string, string)[]> QueryRedirections(Dispatcher d, params string[] tableNamesListtypes) {

            // se non sono specificate le tabelle, il filtro è una tautologia
            //Func<DataRow, bool> tableNamesFilter =
            //    (tableNames == null || tableNames.Length == 0)
            //    ? new Func<DataRow, bool>(redir => true)
            //    : new Func<DataRow, bool>(redir => tableNames.Contains(redir["tablename"].ToString()));

            // spostiamo l'onere di filtrare dal server dei db al server che esegue l'applicazione
            // dato che web_listredir è una tabella di configurazione
            var web_listredir = d.conn.CreateTableByName("web_listredir", "*");
            d.conn.RUN_SELECT_INTO_TABLE(web_listredir, null, tableNamesListtypes.Length > 0 ? 
                d.QueryHelper.AppAnd(d.QueryHelper.FieldIn("listtype", tableNamesListtypes.Select(x => x.Split('$')[1]).ToArray()),d.QueryHelper.FieldIn("tablename", tableNamesListtypes.Select(x => x.Split('$')[0]).ToArray())) 
                : null, null, false);

            bool IsValid(DataRow row) =>
                row["tablename"] != DBNull.Value &&
                row["listtype"] != DBNull.Value &&
                row["newtablename"] != DBNull.Value &&
                row["newlisttype"] != DBNull.Value; //&&

            bool InKeyCache(DataRow row)  => CacheMDLW.metaDataCache_primaryKey.ContainsKey(row["newtablename"].ToString());

            Dictionary<(string, string), (string, string)[]> redirs;

            // le tuple andrebbero sostituite, poco leggibili
            try {
                redirs = web_listredir.AsEnumerable()
                    .Where(IsValid)
                    .Where(InKeyCache) 
                    //.Where(tableNamesFilter)
                    .GroupBy(redir => (redir["tablename"].ToString(), redir["listtype"].ToString()))
                    .ToDictionary(
                        tableRedirs => tableRedirs.Key,
                        tableRedirs => tableRedirs.Select(redir => (redir["newtablename"].ToString(), redir["newlisttype"].ToString())).ToArray());
            }
            catch (Exception e) {

                throw new Exception("Wrong or incomplete redirections configuration.", e);
            }

            return redirs;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        /// <param name="tableNamesListtypes"></param>
        /// <returns></returns>
        public static Dictionary<string, string> DefaultRedirections(Dispatcher d, params string[] tableNamesListtypes)
        {

            var allRedirs = QueryRedirections(d, tableNamesListtypes);

            return allRedirs
                //.Where(redir => defaultListingTypes.ContainsKey(redir.Key.Item2))
                .GroupBy(redir => redir.Key.Item1)
                .ToDictionary(
                    redirsByTablename => redirsByTablename.Key,
                    redirsByTablename => redirsByTablename.First().Value.First().Item1  // da rivedere
                );
        }

        /// <summary>
        /// Creates a mutator function that modifies parameter values based on their definitions in the provided DataSet.
        /// </summary>
        /// <param name="definitions"></param>
        /// <returns>Mutator function.</returns>
        private Func<KeyValuePair<string, object>, KeyValuePair<string, object>> CreateValuesMutator(DataSet definitions) {

            return parameter => {
                var parameterDefinition = definitions.Tables[Config.ParametersTablename]
                    .AsEnumerable()
                    .FirstOrDefault(row => row.Field<string>(row.Table.PrimaryKey[0]) == parameter.Key);

                bool gestito = parameterDefinition["iscombobox"].ToString().ToUpper() == "S" || parameterDefinition["selectioncode"].ToString() != "";
                bool convertNullToPerc = gestito && parameterDefinition["noselectionforall"].ToString().ToUpper() == "S";
                bool isString = definitions.Tables[PrimaryTablename].Columns[parameter.Key].DataType == typeof(string);

                if (gestito && convertNullToPerc && isString && string.IsNullOrWhiteSpace(parameter.Value.ToString())) {
                    return new KeyValuePair<string, object>(parameter.Key, "%");
                }

                return parameter;
            };
        }

        /// <summary>
        /// Executes the rendering process for exporting or generating reports based on the provided parameters.
        /// </summary>
        /// <remarks>This method supports two configurations: export and report generation. Depending on
        /// the configuration, it either: <list type="bullet"> <item>Generates an export 
        /// and writes the output to the provided filename.</item> <item>Generates a report and writes the output to
        /// the provided filename.</item> </list> The method handles parameter validation, invokes the appropriate logic
        /// for export or report generation, and ensures the output is saved correctly.</remarks>
        /// <param name="prms">The parameters used to configure the export or report generation process.</param>
        /// <param name="filename">The name of the file where the rendered output will be saved.</param>
        /// <exception cref="Exception"></exception>
        public void Generate(generateExportQueryParameters prms, string filename) {

            var definitions = DataUtils.createDataSet("exportviewer", _editType);

            var parameterValuesMutator = CreateValuesMutator(definitions);  // dato che il mutator dipende dalle definizioni usiamo una "factory" per crearlo una volta sola

            // Dobbiamo matchare i valori dei parametri con le definizioni per recuperarne i tipi e impostare i wildcard (%) dove serve,
            // questo servirà anche per la validazione.
            // Lo facciamo all'esterno su ParameterMutator, prima di passare i parametri al renderer, anche se per gli export viene fatto nuovamente.
            // Non è il massimo dell'efficienza ma almeno estraiamo quanta più logica possibile dal renderer delle esportazioni
            // (che al suo interno utilizza i metodi e lo stato del form).
            // Unifichiamo qui i comportamenti delle esportazioni e delle stampe.

            var parameters = prms.generateExportParams
                .Properties()
                .OrderBy(p => p.Value["number"])
                .Select(p => new KeyValuePair<string, object>(p.Name, p.Value["value"]))
                .Select(p => parameterValuesMutator.Invoke(p))  // qui potremo anche concatenare un parameterValidator in futuro
                .ToList();

            // qua potremmo loggare le eccezioni
            renderers[Config.GetType()].Invoke(definitions, parameters, filename);
        }

        /// <summary>
        /// Intializes a DataSet with the necessary tables and relations based on the export configuration.
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <exception cref="Exception"></exception>
        public void InitDataset(DataSet ds) {

            if (!ds.Tables.Contains(PrimaryTablename)) {
                ds.Tables.Add(new DataTable(PrimaryTablename)); // Aggiungo la tabella primaria se non esiste
            }

            var definitionTables = new string[] { Config.DefinitionTablename, Config.ParametersTablename }
                .Select(definitionTablename => _dispatcher.conn.CreateTableByName(definitionTablename.ToString(), "*"))
                .ToList();

            ds.Tables.AddRange(definitionTables.ToArray());

            var primaryTable = ds.Tables[PrimaryTablename];
            foreach (var col in primaryTable.PrimaryKey) {
                col.DefaultValue = col.DataType.IsValueType ? Activator.CreateInstance(col.DataType) : null;
            }

            var exportdefinitionTable = ds.Tables[Config.DefinitionTablename];
            var exportdefinitionparameterTable = ds.Tables[Config.ParametersTablename];

            var relations = exportdefinitionTable.PrimaryKey
                .Select(col => new DataRelation($"FK_{exportdefinitionTable.TableName}_{col.ColumnName}", exportdefinitionparameterTable.Columns[col.ColumnName], col));

            foreach (var relation in relations) {
                ds.Relations.Add(relation); // relazione tra definizione e parametri
            }

            var definitionSelects = definitionTables
                .Select(t => new SelectBuilder()
                .From(t.TableName)
                .IntoTable(t)
                .Where($"{exportdefinitionTable.PrimaryKey[0].ColumnName} = '{Config.Id}'"));

            try {
                _dispatcher.conn.MULTI_RUN_SELECT(definitionSelects.ToList());
            }
            catch (Exception e) {
                throw new Exception($"Errore durante la lettura della definizione dell'esportazione '{Config.Id}'", e);
            }

            //se qualche parametro ha la selezione personalizzata ...
            var customSelectionTable = new DataTable();
            if (exportdefinitionparameterTable.Rows.Cast<DataRow>().Any(paramDef => paramDef["selectioncode"].ToString().StartsWith("custom.")))
            {
                //...recupero la tabella delle selezioni personalizzate
                customSelectionTable = _dispatcher.conn.CreateTableByName("customselection", "*");
                _dispatcher.conn.RUN_SELECT_INTO_TABLE(customSelectionTable, null, null, null, false);
            }

            var parameterDatasourceMap = exportdefinitionparameterTable.AsEnumerable()
                .Where(paramDef => paramDef["datasource"] != DBNull.Value)
                .ToDictionary(
                    paramDef => paramDef, // DataRow
                    paramDef => {

                        //controllo se il datasource del parametro non va sostiuto dal weblistredir
                        var dataSourceName = paramDef["datasource"].ToString();
                        var staticfilter = "";
                        if (paramDef["selectioncode"].ToString().StartsWith("custom.")) {
                            var customSelection = customSelectionTable.Rows.Cast<DataRow>().FirstOrDefault(row => row["selectioncode"].ToString() == paramDef["selectioncode"].ToString().Replace("custom.", ""));
                            if (customSelection != null)
                            {
                                //paramDef["listtype"] = customSelection["editlisttype"];
                                dataSourceName = customSelection["tablename"].ToString();
                                staticfilter = customSelection["filter"].ToString();
                            }
                        }

                        var t = _dispatcher.conn.CreateTableByName(dataSourceName, "*");

                        //aggiungo il filtro statico
                        if (staticfilter != "")
                            t.setStaticFilter(staticfilter);

                        //controllo che la tabella on vada riempita immediatamente (solo tendine e solo se non dipendenti da altre)
                        var paramNeedsToFill = (paramDef["iscombobox"].ToString().ToUpper() == "S"
                                            && paramDef["selectioncode"] == DBNull.Value
                                            && paramDef["master"] == DBNull.Value);
                        if (paramNeedsToFill)
                        {
                            _dispatcher.conn.RUN_SELECT_INTO_TABLE(t, null, null, null, false);
                            t.CacheTable();
                        }
                        return t;
                    } // DataTable
                );

            List<DataTable> parameterDatasourceTables = parameterDatasourceMap.Values.ToList(); // lista di datatable da aggiungere al dataset

            Dictionary<string, int> tablesCounts = new Dictionary<string, int>();

            for (int i = 0; i < parameterDatasourceTables.Count; i++) {

                DataTable table = parameterDatasourceTables[i];

                string originalName = table.TableName;

                if (tablesCounts.ContainsKey(originalName)) {

                    tablesCounts[originalName]++;
                    int index = tablesCounts[originalName] - 1;
                    table.TableName = $"{originalName}_alias{index}";
                }
                else {

                    tablesCounts[originalName] = 1;
                }

                DataAccess.SetTableForReading(table, originalName); // settiamo il nome originale della tabella per la lettura
            }

            ds.Tables.AddRange(parameterDatasourceTables.ToArray());    // aggiungiamo le tabelle modificate con alias

            var primaryForeignKeyColumnName = exportdefinitionTable.PrimaryKey[0].ColumnName; // chiave primaria della tabella exportdefinition
            ds.Relations.Add(new DataRelation(
                $"FK_{primaryTable.TableName}_{exportdefinitionTable.PrimaryKey[0]}",
                exportdefinitionTable.Columns[primaryForeignKeyColumnName], // chiave primaria della tabella exportdefinition
                exportdefinitionparameterTable.Columns[primaryForeignKeyColumnName],
                false
            ));

            // questo ciclo va sistemato meglio soprattutto per il caso di chiavi esterne composte da più di una colonna
            foreach (DataRow parameterDefinition in exportdefinitionparameterTable.AsEnumerable()) {

                var isParamConstrained = parameterDatasourceMap.TryGetValue(parameterDefinition, out DataTable parameterDatasourceTable);

                //var valueMemberColumnName = parameterDefinition["valuemember"].ToString();

                var linkingColumnName = parameterDefinition["paramname"].ToString();

                Type parameterType = DataMappings.GetType(parameterDefinition["systype"].ToString()); // isParamConstrained
                    //? parameterDatasourceTable.PrimaryKey[0].DataType // dato che ora dobbiamo anche usare la mappatura sulle viste questo non possiamo più usarlo..
                    //: DataMappings.GetType(parameterDefinition["systype"].ToString());

                var addedColumn = primaryTable.Columns.Add(linkingColumnName, parameterType);

                if (isParamConstrained) {

                    if (parameterDefinition["filter"] != DBNull.Value) {
                        parameterDatasourceTable.setStaticFilter(parameterDefinition["filter"].ToString());
                    }

                    // questa CacheMDLW.metaDataCache_primaryKey va sistemata, non ci sono tutte le viste => commento
                    var keyColums = parameterDatasourceTable.PrimaryKey.Any()                                                           // se ha una chiave primaria definita
                        ? parameterDatasourceTable.PrimaryKey                                                                           // la utilizziamo
                        : CacheMDLW.metaDataCache_primaryKey[parameterDatasourceTable.ExtendedProperties["TableForReading"].ToString()] // altrimenti la leggiamo dalla cache (generalmente per le viste)
                            .Split(',')
                            .Select(quotedString => quotedString.Trim('"')) // facciamo 2 proiezioni per leggibilità
                            .Select(keyColname => parameterDatasourceTable.Columns[keyColname]);

                    var dataSourceColumn = keyColums.First(); // il nome della colonna che fa da chiave primaria nella tabella del datasource

                    try {

                        ds.Relations.Add(new DataRelation(
                            $"FK_{primaryTable.TableName}_{linkingColumnName}",
                            dataSourceColumn,
                            addedColumn,
                            false
                        ));
                    }
                    catch (Exception e) {
                        // non so come logghiamo gli errori sul backend, ma in caso di errore lancio un'eccezione più dettagliata
                        
                        throw new Exception($"Could not add relation between '{dataSourceColumn.Table.TableName}.{dataSourceColumn.ColumnName}' " +
                            $"and '{addedColumn.Table.TableName}.{addedColumn.ColumnName}' via '{linkingColumnName}'." +
                            $" Check the configuration of {Config.Id}", e);
                    }

                    if (parameterDefinition["master"] != DBNull.Value)
                    {
                        var masterTable = parameterDatasourceMap.Values.FirstOrDefault(p => p.TableName == parameterDefinition["master"].ToString());
                        if (masterTable != null)
                        {
                            var masterKeys = masterTable.PrimaryKey.Any()                                                           // se ha una chiave primaria definita
                                ? masterTable.PrimaryKey                                                                           // la utilizziamo
                                : CacheMDLW.metaDataCache_primaryKey[masterTable.ExtendedProperties["TableForReading"].ToString()] // altrimenti la leggiamo dalla cache (generalmente per le viste)
                                    .Split(',')
                                    .Select(quotedString => quotedString.Trim('"')) // facciamo 2 proiezioni per leggibilità
                                    .Select(keyColname => masterTable.Columns[keyColname]);
                            var masterKey = masterKeys.First(); // il nome della colonna che fa da chiave primaria nella tabella del datasource

                            var childTable = ds.Tables[parameterDatasourceTable.TableName];
                            var childAddictedColumn = childTable.Columns.Cast<DataColumn>().Where(c=> c.ColumnName == masterKey.ColumnName).FirstOrDefault();
                            if (childAddictedColumn != null)
                            {
                                ds.Relations.Add(new DataRelation(
                                    $"FK_{masterTable.TableName}_{linkingColumnName}",
                                    masterKey,
                                    childAddictedColumn,
                                    false
                                ));
                            }
                            else
                            {
                                throw new Exception($"Errore durante la lettura della definizione dell'esportazione '{Config.Id}', per il campo '{linkingColumnName}'. Non riesco a trovare la colonna con cui fare la relazione con la tabella master '{parameterDefinition["master"]}'");
                            }
                        }
                        else
                        {
                            throw new Exception($"Errore durante la lettura della definizione dell'esportazione '{Config.Id}', per il campo '{linkingColumnName}'. Non riesco a trovare la tabella master '{parameterDefinition["master"]}'");
                        }

                    }

                }

                object value = parameterDefinition["hint"];
                try {
                    addedColumn.DefaultValue = value != DBNull.Value
                        ? Convert.ChangeType(value, parameterType)
                        : DBNull.Value;
                }
                catch (Exception e) {
                    // non so come logghiamo gli errori sul backend, ma in caso di errore nella conversione del valore di default, lo setto a DBNull.Value
                    addedColumn.DefaultValue = DBNull.Value;
                }
            }
        }

        /// <summary>
        /// Dynamically loads an assembly and retrieves a method info for the specified class and method name.
        /// </summary>
        /// <param name="o"></param>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <param name="className">Name of the class.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="flags">Binding flags for the method.</param>
        /// <param name="argTypes">Types of the arguments.</param>
        /// <returns>Method metadata.</returns>
        /// <exception cref="Exception"></exception>
        private MethodInfo GetAssemblyMethodInfo(out object o, string assemblyName, string className, string methodName, BindingFlags flags, params Type[] argTypes) {

            // Carichiamo dinamicamente il metodo

            Assembly a = Assembly.Load(assemblyName) ?? throw new Exception($"Missing logic assembly '{assemblyName}'");

            Type t = a.GetType("metadatalibrary.exportclass", false, true)
                ?? throw new Exception($"Missing logic class '{className}' in assembly '{assemblyName}'");

            MethodInfo mi = t.GetMethod(methodName, flags, default, argTypes, default)
                ?? throw new Exception($"Missing method '{methodName}' in class '{className}' and assembly '{assemblyName}'" +
                    $"with provided binding flags and parameter types");

            o = Activator.CreateInstance(t) // questo non è necessario per metodi statici, dovremmo condizionarlo ai flags ma lo lasciamo così per ora
                ?? throw new Exception($"Failed to create instance of class '{className}'");

            return mi;
        }

        /// <summary>
        /// Renders the export data set and saves it to a file.
        /// </summary>
        /// <param name="DS">Configuration data.</param>
        /// <param name="parameters">Parameter identifier and values.</param>
        /// <param name="filename">Output file name.</param>
        /// <exception cref="NoDataException">Thrown if the evaluation yields no results.</exception>
        /// <exception cref="Exception"></exception>
        private void RenderExport(DataSet DS, List<KeyValuePair<string, object>> parameters, string filename) {

            var f = new frmExport();
            var Meta = _dispatcher.GetMeta("export");

            // codice riciclato da frmExport
            #region frmExport_recycled
            f.BuildForm(Config.Id, Meta);

            var ExportName = HelpForm.GetField(Config.Id, 0);
            var ExportVista = DS;
            var ExportDescription = ExportVista.Tables["exportfunction"].Rows[0]["description"].ToString();

            //object[] ReportParams = new object[myPrymaryTable.Columns.Count - 2];	// -2, perchè c'è DummyPrimaryKey e	DummyField
            //Hashtable HashParams = new Hashtable();
            //foreach (DataColumn C in myPrymaryTable.Columns) {
            //    string colname = C.ColumnName;
            //    if (colname == DummyPrimaryKey) continue;
            //    if (colname == DummyField) continue;
            //    bool Convert = (bool)C.ExtendedProperties["ConvertNullToPerc"];
            //    Type tipo = Params.Table.Columns[colname].DataType;
            //    if (Convert && (tipo == typeof(string)) && (Params[colname].ToString() == "")) {
            //        Params[colname] = "%";
            //    }
            //    ReportParams[count++] = Params[colname];
            //    HashParams[colname] = Params[colname];
            //}

            var ReportParams = parameters.Select(p => p.Value).ToArray();
            var HashParams = new Hashtable(parameters.ToDictionary(p => p.Key));

            int timeout = 300;
            try {
                if (ExportVista.Tables["exportfunction"].Rows[0]["timeout"] != DBNull.Value) {
                    timeout = Convert.ToInt32(
                        ExportVista.Tables["exportfunction"].Rows[0]["timeout"]) * 60;
                    if (timeout == 0) timeout = 300;
                }
            }
            catch {
            }
            DataSet Out = null;
            if (ExportName.StartsWith("#")) {
                string[] s = ExportName.Substring(1).Split('#');
                string assemblyName = s[0];
                string className = s[1];

                //Assembly a = Assembly.Load(assemblyName);
                //if (a == null) {
                //    //show("Dll " + assemblyName + " non trovata");
                //    throw new Exception("Missing logic assembly: " + assemblyName);
                //}
                //System.Type T = a.GetType(assemblyName + "." + className, false, true);
                //if (T == null) {
                //    //show("Classe " + className + " non trovata nella DLL " + assemblyName);
                //    throw new Exception("Missing logic class: " + className + " in assembly: " + assemblyName);
                //}
                //object O = Activator.CreateInstance(T);
                //MethodInfo M = T.GetMethod("Execute");
                //if (M == null) {
                //    //show("Metodo Execute non trovato nella classe " + className + " della DLL " + assemblyName);
                //    throw new Exception("Missing method Execute in class: " + className + " in assembly: " + assemblyName);
                //}

                var M = GetAssemblyMethodInfo(out object configuredObj, assemblyName, className, "Execute",
                    BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static,
                    typeof(string), typeof(Hashtable));

                DataTable TT = M.Invoke(configuredObj, new object[] { Meta.Conn, HashParams }) as DataTable;
                if (TT != null) {
                    Out = new DataSet("D");
                    Out.Tables.Add(TT);
                }
                else {
                    throw new NoDataException($"L'elaborazione di '{className}' non ha restituito risultati");
                }
            }
            else {
                //if (myExcelTables.Count > 0)
                //    Out = callSP(ReportParams, timeout);
                //else
                //    Out = Meta.Conn.CallSP(ExportName, ReportParams, false, timeout);

                Out = f.callSP(ReportParams, timeout);
                //Out = Meta.Conn.CallSP(ExportName, ReportParams, false, timeout);
            }
            if ((Out == null) || (Out.Tables.Count == 0)) {
                throw new NoDataException($"L'elaborazione della procedura '{ExportName}' non ha restituito risultati");
            }
            if (Out.Tables[0].Rows.Count == 0) {
                throw new NoDataException($"L'elaborazione della procedura '{ExportName}' ha restituito zero risultati");
            }

            DataTable OutTable = Out.Tables[0];
            OutTable.TableName = ExportDescription.Replace("#", "");

            //string fileFormat = ExportVista.Tables["exportfunction"].Rows[0]["fileformat"].ToString();
            //object fileExtension = ExportVista.Tables["exportfunction"].Rows[0]["fileextension"];
            //           switch (fileFormat) {
            //               //case "F": exportdata.exportclass.dataTableToFixedLengthFile(OutTable, fileExtension, false); break;
            //               //case "T": exportdata.exportclass.dataTableToTabulationSeparatedValues(OutTable, false); break;
            //               //case "C": exportdata.exportclass.dataTableToCommaSeparatedValues(OutTable, false); break;
            //               //case "E": metadatalibrary.exportclass.DataTableToExcel(Out.Tables[0], true); break;
            //default: exportclass.DataTableToExcel(Out.Tables[0], true); break;
            //           }
            #endregion

            // individuamo il metodo privato di metadatalibrary che si occupa di esportare in Excel
            var renderingMethod = GetAssemblyMethodInfo(out object o, "metadatalibrary", "exportclass", "iDataTableToOfficeXML",
                BindingFlags.NonPublic | BindingFlags.Static,
                typeof(DataTable), typeof(bool), typeof(int[]), typeof(object[]), typeof(string));

            // e lo invochiamo con i parametri corretti
            try {
                renderingMethod.Invoke(o, new object[] { OutTable, true, null, null, filename });
            }
            catch (Exception e) {
                throw new Exception($"Could not write rendered file '{filename}'", e);
            }
        }

        /// <summary>
        /// Renders the report data set and saves it to a file using the ReportGenClient service.
        /// </summary>
        /// <param name="DS">Configuration data.</param>
        /// <param name="parameters">Parameter identifiers and values.</param>
        /// <param name="filename">Output file name.</param>
        /// <exception cref="Exception"></exception>
        private void RenderReport(DataSet DS, List<KeyValuePair<string, object>> parameters, string filename) {

            // la lettura della configurazione va sistemata (task 20413) per le tabelle usate
            // potremmo anche pensare ad un default localhost se non c'è configurazione sul database
            // il servizio inoltre andrebbe adeguato "sistemisticamente" per il protocollo (https, dominio)
            // e "di sviluppo" per l'autenticazione se non ci sta bene che sia bindato solamente su localhost per rispondere al backend

            var Meta = _dispatcher.GetMeta("export");

            DataTable dt = _dispatcher.conn.SQLRunner("SELECT TOP 1 url, params FROM reportgenclient where name = 'webclient'");

            if (dt == null || dt.Rows.Count == 0) {
                throw new Exception("No report generation client configuration found in the database");
            }

            string endpointUrl = dt.Rows[0][0].ToString();
            int timeout = int.TryParse(dt.Rows[0][1].ToString(), out int parsedTimeout) ? parsedTimeout : 30;   // default 30

            var client = new ReportGenClient.WebClient(endpointUrl, timeout);
            var reportParameters = parameters.ToDictionary(p => p.Key, p => p.Value);
            			
            string db = Meta.Conn.GetSys("database").ToString();

            try {
                var bytes = client.Generate(db, DS.Tables[Config.DefinitionTablename].Rows[0], reportParameters);
                File.WriteAllBytes(filename, bytes);
            }
            catch (Exception e) {

                throw new Exception($"Could not write rendered file '{filename}'", e);
            }
        }
    }
}
