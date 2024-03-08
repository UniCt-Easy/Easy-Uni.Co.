
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
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using System.Xml;
using Microsoft.CSharp;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualStudio.Shell;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using mdl;
using System.Linq;
using q= mdl.MetaExpression;

namespace HDSGeneVSIX {


    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("HDSGene", "Generate XML with line count", "1.0")]
    // ReSharper disable once InconsistentNaming
    [ComVisible(true)]
    [Guid("AB4DC117-93D2-4a29-B3B9-24DDB4F9AFAA")]
    [ProvideObject(typeof(HDSGene))]
    [CodeGeneratorRegistration(typeof(HDSGene), "HDSGene", "{FAE04EC1-301F-11D3-BF4B-00C04F79EFBC}", GeneratesDesignTimeSource = true)]
    public class HDSGene /*: BaseCodeGenerator tolto l'interfaccia*/ {
        private bool _someSpecialAdded;

        void appendLog(string text) {
            if(_hdsGenePath == null)
                return;
            var dbIniFile = Path.Combine(_hdsGenePath, "HDSGeneLog.txt");
            if(!File.Exists(dbIniFile)) {
                // Create a file to write to.
                using(StreamWriter sw = File.CreateText(dbIniFile)) {
                    sw.WriteLine("HDSGene Log file");
                }
            }

            using(StreamWriter sw = File.AppendText(dbIniFile)) {
                sw.WriteLine(text);
            }
        }

		/* aggiunto - inizio*/
		private string codeFileNameSpace = String.Empty;
		private string codeFilePath = String.Empty;
		public SqlConnection extConn = null;

		/// <summary>
		/// namespace for the file.
		/// </summary>
		public string FileNameSpace /*da protected a public e aggiunto il set*/
		{
			get
			{
				return codeFileNameSpace;
			}
			set
			{
				codeFileNameSpace = value;
			}
		}

		/* aggiunto - fine*/

        public void ProcessFile(string inputFileName) {
	        string fContent = File.ReadAllText(inputFileName);
	        var result = GenerateCode(inputFileName, fContent);
	        var fRes = Path.ChangeExtension(inputFileName, "Designer.cs");
            if (result != null) File.WriteAllBytes(fRes, result);
        }

        protected /*override tolto*/ byte[] GenerateCode(string inputFileName, string inputFileContent) {
            _hdsGenePath = Path.GetDirectoryName(findHDSGeneIniFile(inputFileName));
            DateTime start = DateTime.Now;
            appendLog($"run start on {inputFileName} at {start.ToString("g")}");
            try {
                return iGenerateCode(inputFileName, inputFileContent);
            }
            catch(Exception e) {
                var s = new StringBuilder();
                while(e != null) {
                    s.AppendLine("Exception type: " + e.GetType().FullName);
                    s.AppendLine("Message       : " + e.Message);
                    s.AppendLine("Stacktrace:");
                    s.AppendLine(e.StackTrace);
                    s.AppendLine();
                    e = e.InnerException;
                }

                appendLog($"exception {e} on {inputFileName} at {DateTime.Now}");
                return Encoding.UTF8.GetBytes(s.ToString());
            }
            finally {
                appendLog($"run stop on {inputFileName} at {DateTime.Now} duration was {DateTime.Now.Subtract(start).TotalMilliseconds} ms");
            }
        }

        DataSet getDataSetFromString(string fileContent, string inputFileName)/*aggiunto inputFileName */{
            var sr = new StringReader(fileContent);
            var d = new DataSet();
            /* Aggiunto il try catch*/
			try {
				d.ReadXmlSchema(sr);
			} catch (Exception e ){
				Console.WriteLine("ERROR: Impossibile costruire file di codice per il dataset  " + inputFileName + ". " + e.Message);
			}
			sr.Close();
            return d;
        }

        private bool _compilazioneConMetaData;
        private string _hdsGenePath;
        /// <summary>
        /// Genera un file contenente il codice
        /// </summary>
        /// <param name="inputFileName">path del file</param>
        /// <param name="inputFileContent">contenuto del file</param>
        /// <returns>file generato</returns>
        public byte[] iGenerateCode(string inputFileName, string inputFileContent) /*da private a public */ {
            var d = getDataSetFromString(inputFileContent, inputFileName); /*aggiunto inputFileName */

            _compilazioneConMetaData = false;
            _hdsGenePath = Path.GetDirectoryName(findHDSGeneIniFile(inputFileName));
            var meta = getMetaData(inputFileName);

            getInitFile(inputFileName);

            if(d.DataSetName.ToLower().StartsWith("dsmeta")) {
                _compilazioneConMetaData = true;
            }
            var clearDs = clearDataSet(inputFileName, d, (meta == null));

            if(_JsonAdd) {
                string json = DataSetSerializer.dataSetToJSon(clearDs);
                File.WriteAllText(
                    Path.ChangeExtension(inputFileName, "json"), json);
            }

            if(meta == null || _hdsGenePath == null) {
                //Trattasi del DataSet di un form
                //Riscrive anche su db l'XSD in modo "pulito" ossia senza le ext.property di MS                
                //restituisce il .cs del dataset da inserire nel progetto del form
                var compiled = compileFormDataSet(clearDs);
                addAllReferences(inputFileName, clearDs);

                return compiled;
            }
            else {
                var currProj = getProject(inputFileName);
                if(currProj != null) {
                    if(isDataSetLinked(currProj, inputFileName)) {
                        var someChange = processProject(currProj, findCsProjFile(inputFileName), inputFileName);
                        //someChange |= fixCustomToolForDataSet(currProj, inputFileName);
                        if(someChange) {
                            writeProject(currProj, inputFileName);
                        }
                    }
                }

                //Trattasi del DataSet di un metadato
                //Riscrive anche su db l'XSD in modo "pulito" ossia senza le ext.property di MS                
                //restituisce il .cs del dataset da inserire nel progetto del metadato
                var compiled = compileMetaDataSet(inputFileName, clearDs);
                _metaDataList[meta] = getRelativePath(_hdsGenePath, Path.GetDirectoryName(findCsProjFile(inputFileName)));

                //aggiorna l'elenco dei metadati 
                setMetaDataList(inputFileName);

                return compiled;
            }

        }

        private DataSet getMetadataDescriptor(string tableName) {
            var meta = tableName;

            if(_hdsGenePath == null)
                return null;
            var dbIniFile = Path.Combine(_hdsGenePath, "HDSGene.db");
            if(!File.Exists(dbIniFile))
                return null;
            //var connString = File.ReadAllText(dbIniFile);
            var d = new DataSet(meta);
            //using(var conn = new SqlConnection(connString)) 
            var conn = extConn;
            {
                //conn.Open();
                var cmd1 = $"SELECT * from columntypes where tablename ='{meta}'";
                var colTypes = new SqlDataAdapter(cmd1, conn);
                colTypes.Fill(d, "columntypes");

                var cmd2 = $"SELECT * from customobject where objectname ='{meta}'";
                var customobject = new SqlDataAdapter(cmd2, conn);
                customobject.Fill(d, "customobject");

                cmd1 = $"SELECT * from tabledescr where tablename ='{meta}'";
                var tabledescr = new SqlDataAdapter(cmd1, conn);
                tabledescr.Fill(d, "tabledescr");

                var cmd3 = $"SELECT * from coldescr where tablename ='{meta}'";
                var coldescr = new SqlDataAdapter(cmd3, conn);
                coldescr.Fill(d, "coldescr");

                var cmd4 = $"SELECT * from colbit where tablename ='{meta}'";
                var colbit = new SqlDataAdapter(cmd4, conn);
                colbit.Fill(d, "colbit");

                var cmd5 = $"SELECT * from colvalue where tablename ='{meta}'";
                var colvalue = new SqlDataAdapter(cmd5, conn);
                colvalue.Fill(d, "colvalue");
            }

            return d;
        }


        private byte[] compileMetaDataSet(string inputFileName, DataSet d) {

            var meta = getMetaData(inputFileName);
            if(!d.Tables.Contains(meta))
                return null;

            var dsInfo = getMetadataDescriptor(meta);


            var T = d.Tables[meta];

            var sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Data;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Runtime.Serialization;");
            if(FileNameSpace != "metadatalibrary") {
                sb.AppendLine("using metadatalibrary;");
            }
            sb.AppendLine("#pragma warning disable 1591");
            sb.AppendLine("// ReSharper disable InconsistentNaming");
            sb.AppendLine("// ReSharper disable UnusedMember.Global");
            sb.AppendLine("namespace " + FileNameSpace + " {");


            addTableDefinitionInMeta(T, sb, dsInfo);

            sb.AppendLine("}"); //namespace

            return Encoding.UTF8.GetBytes(sb.ToString());
        }

        void getSummary(DataSet dsInfo, StringBuilder sb, string tab) {
            log("getSummary 0");
            if(dsInfo == null)
                return;
            if(dsInfo.Tables["tabledescr"].Rows.Count == 0)
                return;
            var tableDescrRow = dsInfo.Tables["tabledescr"].Rows[0];
            var descr = tableDescrRow["description"].ToString();
            if(descr == "")
                return;
            if(tab == null)
                tab = "";
            tab += "///";
            sb.AppendLine(tab + "<summary>");
            using(var sr = new StringReader(descr)) {
                string line;
                while((line = sr.ReadLine()) != null) {
                    sb.AppendLine(tab + line);
                }
            }

            sb.AppendLine(tab + "</summary>");

        }

        void getColumnDescription(string colName, DataSet dsInfo, StringBuilder sb, string tab) {
            if(dsInfo == null)
                return;
            if(dsInfo.Tables["coldescr"].Select($"colname='{colName}'").Length == 0)
                return;
            var rCol = dsInfo.Tables["coldescr"].Select($"colname='{colName}'")[0];
            var descr = rCol["description"].ToString();
            if(descr == "")
                return;
            if(tab == null)
                tab = "";
            tab += "///";
            sb.AppendLine(tab + "<summary>");
            using(var sr = new StringReader(descr)) {
                string line;
                while((line = sr.ReadLine()) != null) {
                    sb.AppendLine(tab + line);
                }
                var kind = rCol["kind"].ToString().ToUpper();
                if(kind == "C") {
                    //Codificato
                    foreach(var r in dsInfo.Tables["colvalue"].Select($"colname='{colName}'")) {
                        sb.AppendLine(tab + $"\t {r["value"]}: {r["title"]}");
                    }
                }
                if(kind == "B") {
                    //Bit
                    foreach(var r in dsInfo.Tables["colvalue"].Select($"colname='{colName}'")) {
                        sb.AppendLine(tab + $"\t bit {r["nbit"]}: {r["description"]}");
                    }
                }
            }

            sb.AppendLine(tab + "</summary>");
        }

        private void addTableDefinitionInMeta(DataTable t, StringBuilder sb, DataSet dsInfo) {
            var tName = t.TableName;
            var tableType = getDataTableTypeName(tName);
            var rowType = getDataRowTypeName(tName);


            sb.AppendLine("public class " + rowType + ": MetaRow  {");
            //SB.AppendLine("public " + rowType + "(){}");
            sb.AppendLine("\tpublic " + rowType + "(DataRowBuilder rb) : base(rb) {} ");
            sb.AppendLine();
            sb.AppendLine("\t#region Field Definition");
            foreach(DataColumn c in t.Columns) {
                //if (C.ColumnName.StartsWith("!")) continue;
                var sType = c.DataType.ToString();
                if(sType.StartsWith("System."))
                    sType = sType.Substring(7);
                bool appendNullManagement = c.AllowDBNull;
                if(sType != "String" && sType != "Byte[]" && c.AllowDBNull) {
                    sType = sType + "?";
                }

                getColumnDescription(c.ColumnName, dsInfo, sb, "\t");
                sb.AppendLine("\tpublic " + sType + " " + c.ColumnName + "{ ");
                if(appendNullManagement) {
                    sb.AppendLine(
                        $"\t\tget {{if (this[\"{c.ColumnName}\"]==DBNull.Value)return null; return  ({sType})this[\"{c.ColumnName}\"];}}");
                }
                else {
                    sb.AppendLine(
                        $"\t\tget {{return  ({sType})this[\"{c.ColumnName}\"];}}");
                }

                if(appendNullManagement) {
                    sb.AppendLine(
                        $"\t\tset {{if (value==null) this[\"{c.ColumnName}\"]= DBNull.Value; else this[\"{c.ColumnName}\"]= value;}}");
                }
                else {
                    sb.AppendLine(
                        $"\t\tset {{this[\"{c.ColumnName}\"]= value;}}");
                }

                sb.AppendLine("\t}");

                sb.AppendLine($"\tpublic object {c.ColumnName}Value {{ ");
                sb.AppendLine($"\t\tget{{ return this[\"{c.ColumnName}\"];}}");
                if(appendNullManagement) {
                    sb.AppendLine(
                        $"\t\tset {{if (value==null|| value==DBNull.Value) this[\"{c.ColumnName}\"]= DBNull.Value; else this[\"{c.ColumnName}\"]= value;}}");
                }
                else {
                    sb.AppendLine(
                        $"\t\tset {{this[\"{c.ColumnName}\"]= value;}}");
                }

                sb.AppendLine("\t}");

                sb.AppendLine($"\tpublic {sType} {c.ColumnName}Original {{ ");
                if(appendNullManagement) {
                    sb.AppendLine(
                        $"\t\tget {{if (this[\"{c.ColumnName}\",DataRowVersion.Original]==DBNull.Value)return null; return  ({sType})this[\"{c.ColumnName}\",DataRowVersion.Original];}}");
                }
                else {
                    sb.AppendLine(
                        $"\t\tget {{return  ({sType})this[\"{c.ColumnName}\",DataRowVersion.Original];}}");
                }

                sb.AppendLine("\t}");


            }
            sb.AppendLine("\t#endregion");
            sb.AppendLine();
            //SB.AppendLine("public static implicit operator "+ rowType + " (DataRow v) {");
            //SB.AppendLine("return new "+ D.DataSetName+"."+rowType+"((DataRow)v);");
            //SB.AppendLine("}");

            sb.AppendLine("}");//class

            getSummary(dsInfo, sb, null);
            sb.AppendLine("public class " + tableType + " : MetaTableBase<" + rowType + "> {");

            //costruttore
            sb.AppendLine("\tpublic " + tableType + "() : base(\"" + tName + "\"){");

            sb.AppendLine("\t\tbaseColumns = new Dictionary<string, DataColumn>(){");
            foreach(DataColumn c in t.Columns) {
                sb.AppendLine($"\t\t\t{{\"{c.ColumnName}\",createColumn(\"{c.ColumnName}\",typeof({typeName(c.DataType)}),{c.AllowDBNull.ToString().ToLower()},{c.ReadOnly.ToString().ToLower()})}},");
            }
            sb.AppendLine("\t\t};");
            sb.AppendLine("\t}");



            sb.AppendLine("}"); //class

        }

        private static string typeName(Type t) {
            if(t == typeof(int))
                return "int";
            if(t == typeof(short))
                return "short";
            if(t == typeof(string))
                return "string";
            if(t == typeof(double))
                return "double";
            if(t == typeof(byte))
                return "byte";
            if(t == typeof(decimal))
                return "decimal";
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if(t == typeof(long))
                return "long";
            return t.ToString().Substring(7);
        }

        /// <summary>
        /// Genera il codice delle classi necessarie a deserializzare 
        /// l'xml passato come argomento
        /// </summary>
        /// <returns>array di byte che contiene il codice generato</returns>
        private byte[] compileFormDataSet(DataSet d) {


            var sb = new StringBuilder();

            sb.AppendLine("using System;");
            sb.AppendLine("using System.Data;");
            sb.AppendLine("using System.ComponentModel;");
            sb.AppendLine("using System.Diagnostics;");
            //SB.AppendLine("using System.Globalization;");
            sb.AppendLine("using System.Runtime.Serialization;");
            sb.AppendLine("#pragma warning disable 1591");
            if(_compilazioneConMetaData) {
                var linked = new Dictionary<string, bool>();
                foreach(DataTable t in d.Tables) {
                    var tableAlias = t.TableName;      //tableAlias è nome della tabella VERA, ossia del meta e del tipo
                    if(t.ExtendedProperties["TableForReading"] != null &&
                        t.ExtendedProperties["TableForReading"].ToString() != "")
                        tableAlias = t.ExtendedProperties["TableForReading"].ToString();

                    if(_metaDataList.ContainsKey(tableAlias)) {
                        if(!linked.ContainsKey(tableAlias)) {
                            linked.Add(tableAlias, true);
                            sb.AppendLine("using meta_" + tableAlias + ";");
                            _someSpecialAdded = true;
                        }
                    }
                }
            }

            if(_compilazioneConMetaData) {    //
                if(FileNameSpace != "metadatalibrary") {
                    sb.AppendLine("using metadatalibrary;");
                }
            }
            sb.AppendLine("// ReSharper disable InconsistentNaming");
            sb.AppendLine("// ReSharper disable UnusedMember.Global");
            sb.AppendLine("namespace " + FileNameSpace + " {");



            beginDataSetDeclaration(d, sb);
            addPublicDataTables(d, sb);
            addConstructor(d, sb);
            addInit(d, sb);
            closeMainDataSetDeclaration(sb);


            sb.AppendLine("}"); //namespace
            return Encoding.UTF8.GetBytes(sb.ToString());
        }

        private void beginDataSetDeclaration(DataSet d, StringBuilder sb) {
            //SB.AppendLine("[DefaultProperty(\"DataSetName\")]");                                                               
            sb.AppendLine("[Serializable,DesignerCategory(\"code\"),System.Xml.Serialization.XmlSchemaProvider(\"GetTypedDataSetSchema\")]");
            sb.AppendLine($"[System.Xml.Serialization.XmlRoot(\"{d.DataSetName}\"),System.ComponentModel.Design.HelpKeyword(\"vs.data.DataSet\")]");
            sb.AppendLine($"public partial class { d.DataSetName}: DataSet {{");
        }

        private void addPublicDataTables(DataSet d, StringBuilder sb) {
            if(d.Tables.Count > 0) {
                sb.AppendLine();
                sb.AppendLine("\t#region Table members declaration");
            }
            foreach(DataTable T in d.Tables) {
                var tableAlias = T.TableName;      //tableAlias è nome della tabella VERA, ossia del meta e del tipo
                if(T.ExtendedProperties["TableForReading"] != null
                         && T.ExtendedProperties["TableForReading"].ToString() != ""
                    )
                    tableAlias = T.ExtendedProperties["TableForReading"].ToString();


                var dsInfo = getMetadataDescriptor(tableAlias);
                getSummary(dsInfo, sb, "\t");
                //SB.AppendLine("[System.CodeDom.Compiler.GeneratedCodeAttribute(\"System.Data.Design.TypedDataSetGenerator\", \"4.0.0.0\")]");
                sb.AppendLine("\t[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]");

                if(isSpecialTable(tableAlias) && _compilazioneConMetaData) {
                    var tableTypeName = getDataTableTypeName(tableAlias);
                    //SB.AppendLine($"\tpublic {tableTypeName} {T.TableName} \t\t{{get {{ return ({tableTypeName} )Tables[\"{T.TableName}\"];}}}}");
                    sb.AppendLine($"\tpublic {tableTypeName} {T.TableName} \t\t=> ({tableTypeName})Tables[\"{T.TableName}\"];");

                }
                else {
                    sb.AppendLine(_compilazioneConMetaData
                        ? $"\tpublic MetaTable {T.TableName} \t\t=> (MetaTable)Tables[\"{T.TableName}\"];"
                        : $"\tpublic DataTable {T.TableName} \t\t=> Tables[\"{T.TableName}\"];");
                }
                sb.AppendLine();
            }
            if(d.Tables.Count > 0) {
                sb.AppendLine("\t#endregion");
                sb.AppendLine();
            }

            sb.AppendLine();

            sb.AppendLine("\t[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]");
            sb.AppendLine("\tpublic new DataTableCollection Tables => base.Tables;");
            sb.AppendLine();

            sb.AppendLine("\t[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]");
            sb.AppendLine("// ReSharper disable once MemberCanBePrivate.Global");
            sb.AppendLine("\tpublic new DataRelationCollection Relations => base.Relations;");
            sb.AppendLine();


        }

        private void closeMainDataSetDeclaration(StringBuilder sb) {
            sb.AppendLine("}");
        }


        public /*override*/ string GetDefaultExtension()
        {
            return ".cs";
        }

        /// <summary>
        /// metaDataList[tableName]= path to  meta_tableName's project file
        /// Produced when HDSGene processes dataset in meta_ and used when it processes dataset in form
        /// </summary>
        readonly Dictionary<string, string> _metaDataList = new Dictionary<string, string>();

        /// <summary>
        /// Cerca il nome del file HDSGene.ini nell'ambito della solution corrente
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        string findHDSGeneIniFile(string fileName) {
            var f = new FileInfo(fileName);
            var dir = f.DirectoryName;
            if(dir == null)
                return null;
            while(true) {
                var found = Directory.GetFiles(dir, "HDSGene.ini"); //file csProj trovati
                if(found.Length > 0)
                    return found[0];
                var d = new DirectoryInfo(dir);
                if(d.Parent == null)
                    return null;
                if(d.Parent == d.Root)
                    return null;
                dir = d.Parent.FullName;
            }


        }

        private bool _JsonAdd;
        /// <summary>
        /// Reads metadata List from HDSGene.ini file
        /// </summary>
        /// <param name="someFileName"></param>
        void getInitFile(string someFileName) {
            //log("someFileName is " + someFileName);
            var hdsGeneFileName = findHDSGeneIniFile(someFileName);
            var hdsGenePath = Path.GetDirectoryName(hdsGeneFileName);
            if(hdsGenePath == null)
                return;
            //log("HDSGenePath is " + HDSGenePath);
            if(hdsGeneFileName == null)
                return;
            var rd = new StreamReader(hdsGeneFileName);
            var line = rd.ReadLine();
            while(line != null && line.StartsWith("[")) {
                if(line != null && line.ToUpper() == "[JSON]") {
                    _JsonAdd = true;
                }
                line = rd.ReadLine();
            }
            while(line != null) {
                var pieces = line.Split(';');
                if(pieces.Length != 2)
                    continue;
                var path = pieces[1];
                if(path != "*") {
                    if(!Directory.Exists(Path.Combine(hdsGenePath, path))) {
                        //log("Path not found:" + Path.Combine(HDSGenePath, path));
                        path = "*";
                    }
                }
                _metaDataList[pieces[0]] = path;
                line = rd.ReadLine();
            }
            rd.Close();
            rd.Dispose();
        }

        /// <summary>
        /// Writes metadata List to HDSGene.ini file
        /// </summary>
        /// <param name="someFileName"></param>
        void setMetaDataList(string someFileName) {
            var hdsGeneFileName = findHDSGeneIniFile(someFileName);
            if(hdsGeneFileName == null)
                return;
            var wd = new StreamWriter(hdsGeneFileName, false);
            foreach(var tableName in _metaDataList.Keys) {
                wd.WriteLine(tableName + ";" + _metaDataList[tableName]);
            }
            wd.Flush();
            wd.Close();
            wd.Dispose();
        }



        void addAllReferences(string inputFileName, DataSet d) {
            var iniFilePath = _hdsGenePath;
            if(iniFilePath == null)
                return;
            var someChange = false;
            var currProj = getProject(inputFileName);
            if(currProj == null)
                return;

            if(isDataSetLinked(currProj, inputFileName)) {
                someChange |= processProject(currProj, findCsProjFile(inputFileName), inputFileName);

                var projFileName = findCsProjFile(inputFileName);
                if(projFileName == null) {
                    appendLog("progetto " + inputFileName + " non trovato");
                    return;
                }

                if(_compilazioneConMetaData) {
                    var relativeProjFileName = getRelativePath(iniFilePath, Path.GetDirectoryName(projFileName));

                    foreach(DataTable t in d.Tables) {
                        var tableAlias = t.TableName;      //tableAlias è nome della tabella VERA, ossia del meta e del tipo
                        if(t.ExtendedProperties["TableForReading"] != null &&
                            t.ExtendedProperties["TableForReading"].ToString() != "") {
                            tableAlias = t.ExtendedProperties["TableForReading"].ToString();
                        }
                        someChange |= addReferenceToMetaDataProject(currProj, relativeProjFileName, tableAlias);
                    }
                    someChange |= addSystemReferenceToProject(currProj, "System.Data.DataSetExtensions");
                }

                if(someChange) {
                    writeProject(currProj, inputFileName);
                }
            }

        }

        XmlDocument getProject(string someFileName) {
            var projFileName = findCsProjFile(someFileName);
            if(projFileName == null) {
                return null;
            }
            var projFile = new XmlDocument();
            projFile.Load(projFileName);
            return projFile;
        }

        void log(string s) {
            try {
                var sw = new StreamWriter("d:\\easy\\hdsgene_log_1.txt", true);
                sw.WriteLine(s);
                sw.Close();
            }
            catch {
                // ignored
            }

        }
        void writeProject(XmlDocument projFile, string someFileName) {
            var projFileName = findCsProjFile(someFileName);
            if(projFileName == null) {
                return;
            }
            log($"{DateTime.Now.ToFileTime()} saved project2 {projFileName}");
            projFile.Save(projFileName);

        }


        /// <summary>
        /// Aggiunge al document projFile il riferimento al progetto del metadato, che si trova nella cartella relativeProjFilePath
        ///  (path relativo a partire dal file HDSGene.ini
        /// </summary>
        /// <param name="projFile">Documento a cui aggiungere il reference ad un metadato</param>
        /// <param name="relativeProjFilePath">Path relativo del progetto CORRENTE</param>
        /// <param name="metaDataName">nome del metadato (nome tabella "pulito")</param>
        /// <returns></returns>
        bool addReferenceToMetaDataProject(XmlDocument projFile, string relativeProjFilePath, string metaDataName) {
            if(!_metaDataList.ContainsKey(metaDataName))
                return false;
            //if (metaDataList[metaDataName] == "*") return false;
            var metaDataProjFilePath = _metaDataList[metaDataName]; //si intende già relativo rispetto ad HDSGene.ini            
            var relativeMetaDataPath = getRelativePath(relativeProjFilePath, metaDataProjFilePath);
            if(metaDataProjFilePath == "*")
                relativeMetaDataPath = "dll\\";
            return addReferenceToProject(projFile, "meta_" + metaDataName, relativeMetaDataPath, metaDataName);
        }

        bool addSystemReferenceToProject(XmlDocument projFile, string refNameToAdd) {
            var project = projFile.DocumentElement;
            var itemGroups = project?.GetElementsByTagName("ItemGroup");
            if(itemGroups == null)
                return false;
            XmlElement firstGroup = null;
            foreach(XmlElement itemGroup in itemGroups) {
                if(firstGroup == null)
                    firstGroup = itemGroup;
                var references = itemGroup.GetElementsByTagName("Reference");
                foreach(XmlElement refFound in references) {
                    var refName = getProp(refFound, "Name");
                    if(refName == refNameToAdd)
                        return false;
                    var refInclude = getAttribute(refFound, "Include");
                    if(refInclude == refNameToAdd)
                        return false;
                }
            }

            //Must Add the reference to refNameToAdd  (hintpath refpathToAdd) 
            var doc = firstGroup?.OwnerDocument;
            if(doc == null)
                return false;
            var uri = firstGroup.NamespaceURI;
            var projReference = doc.CreateElement("Reference", uri);
            projReference.SetAttribute("Include", refNameToAdd);

            var specificVersionElem = doc.CreateElement("SpecificVersion", uri);
            specificVersionElem.InnerText = "False";
            projReference.AppendChild(specificVersionElem);
            var nameElem = doc.CreateElement("Name", uri);
            nameElem.InnerText = refNameToAdd;
            projReference.AppendChild(nameElem);

            projReference.AppendChild(nameElem);

            firstGroup.AppendChild(projReference);
            appendLog($"{DateTime.Now.ToFileTime()} Adding {refNameToAdd}");
            return true;

        }

        /// <summary>
        /// Assure that projFile has link to refNameToAdd (located at refpathToAdd) assuming projFile is located at projFilePath
        /// </summary>
        /// <param name="projFile">XmlDocument del progetto corrente</param>
        /// <param name="refNameToAdd">nome del riferimento da aggiungere</param>
        /// <param name="refpathToAdd">Path del riferimento da aggiungere relativo al percorso del progetto corrente</param>
        /// <param name="meta"></param>
        /// <returns></returns>
        bool addReferenceToProject(XmlDocument projFile, string refNameToAdd, string refpathToAdd, string meta) {
            var project = projFile.DocumentElement;

            //log("refNameToAdd is " + refNameToAdd + " refpathToAdd is " + refpathToAdd);
            var dllPath = _metaDataList[meta] != "*" ? Path.Combine(refpathToAdd, Path.Combine("bin", "Debug")) : refpathToAdd;
            var relativeDllFile = Path.Combine(dllPath, refNameToAdd + ".dll");
            //log("relativeDllFile is " + relativeDllFile);
            var relativeProjFile = Path.Combine(refpathToAdd, refNameToAdd + ".csproj");
            // Scansiona i riferimenti
            var itemGroups = project?.GetElementsByTagName("ItemGroup");
            if(itemGroups == null)
                return false;
            XmlElement firstGroup = null;
            foreach(XmlElement itemGroup in itemGroups) {
                if(firstGroup == null)
                    firstGroup = itemGroup;
                /**
                 *  <ProjectReference Include = "..\..\unmanaged\SituazioneViewer\SituazioneViewer.csproj">
                 *  <Name > SituazioneViewer </Name>
                 *  <Project>{ 42D2BFEA - 1727 - 4039 - A978 - 5D366E5479D3}</ Project>
                    <Private> False </Private>            
                    </ProjectReference>
                 */
                var refProjs = itemGroup.GetElementsByTagName("ProjectReference");
                foreach(XmlElement refFound in refProjs) {
                    var refInclude = getAttribute(refFound, "Include");
                    //string refName = getProp(refFound, "Name");
                    if(refInclude == relativeProjFile)
                        return false;
                }

                /**
                * <Reference Include="meta_expense">
                     <SpecificVersion>False</SpecificVersion>
                     <HintPath>..\meta_expense\meta_expense.dll</HintPath>
                     <Private>False</Private>
                   </Reference>
                */
                var references = itemGroup.GetElementsByTagName("Reference");
                foreach(XmlElement refFound in references) {
                    var refInclude = getAttribute(refFound, "Include");
                    var hintPath = getProp(refFound, "HintPath");

                    if(hintPath == relativeDllFile)
                        return false;
                    if(refInclude == relativeDllFile)
                        return false;

                    if(refInclude != refNameToAdd)
                        continue;
                    if(refInclude != null) {
                        setProp(refFound, "HintPath", relativeDllFile);
                        appendLog($"Set HintPath to {relativeDllFile}");
                        return true;
                    }



                }
            }

            //Must Add the reference to refNameToAdd  (hintpath refpathToAdd) 
            var doc = firstGroup?.OwnerDocument;
            if(doc == null)
                return false;
            var uri = firstGroup.NamespaceURI;
            var projReference = doc.CreateElement("Reference", uri);
            projReference.SetAttribute("Include", refNameToAdd);

            appendLog($"Adding Reference Include {refNameToAdd} Hint {relativeDllFile}");

            var hintPathElem = doc.CreateElement("HintPath", uri);
            hintPathElem.InnerText = relativeDllFile;
            projReference.AppendChild(hintPathElem);

            if(_metaDataList[meta] != "*") {
                var specificVersionElem = doc.CreateElement("SpecificVersion", uri);
                specificVersionElem.InnerText = "False";
                projReference.AppendChild(specificVersionElem);

                var nameElem = doc.CreateElement("Name", uri);
                nameElem.InnerText = refNameToAdd;
                projReference.AppendChild(nameElem);


                var privateElem = doc.CreateElement("Private", uri);
                privateElem.InnerText = "False";
                projReference.AppendChild(privateElem);
            }

            firstGroup.AppendChild(projReference);

            return true;
        }

        private string getRelativePath(string fromPath, string toPath) {
            //log($"going from {fromPath} to {toPath}");           
            var fromComponents = fromPath.Split(Path.DirectorySeparatorChar);
            var fromLevel = fromComponents.Length;
            if(fromComponents[fromLevel - 1] == "")
                fromLevel = fromLevel - 1;
            var toComponents = toPath.Split(Path.DirectorySeparatorChar);
            var toLevel = toComponents.Length;
            if(toComponents[toLevel - 1] == "")
                toLevel -= 1;
            //Se la root è diversa, restituisci il path assoluto 
            //if (fromComponents[0].ToLowerInvariant() != toComponents[0].ToLowerInvariant()) return toPath;

            //vede a quale livello occorre risalire prima di ridiscendere
            var i = 0;
            while(i < toLevel && i < fromLevel) {
                if(fromComponents[i].ToLowerInvariant() == toComponents[i].ToLowerInvariant()) {
                    i += 1;
                    continue;
                }
                break;
            }
            var commonLevel = i - 1; //il livello comune è i, che è -1 se non c'è livello comune
            var relativePath = "";
            //prima risale n volte da fromLevel a commonLevel
            var currLevel = fromLevel - 1;
            while(currLevel > commonLevel) {
                relativePath += "..\\";
                currLevel = currLevel - 1;
            }
            currLevel += 1;
            //poi riscende al path destinazione
            while(currLevel < toLevel) {
                relativePath += toComponents[currLevel] + "\\";
                currLevel += 1;
            }
            return relativePath;
        }

        private void addConstructor(DataSet d, StringBuilder sb) {
            //SB.AppendLine("[System.CodeDom.Compiler.GeneratedCodeAttribute(\"System.Data.Design.TypedDataSetGenerator\", \"4.0.0.0\")]");
            sb.AppendLine("[DebuggerNonUserCode]");
            sb.AppendLine("public " + d.DataSetName + "(){");
            sb.AppendLine("\tBeginInit();");
            sb.AppendLine("\tinitClass();");
            //SB.AppendLine("System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);");
            //SB.AppendLine("base.Tables.CollectionChanged += schemaChangedHandler;");
            //SB.AppendLine("base.Relations.CollectionChanged += schemaChangedHandler;");
            sb.AppendLine("\tEndInit();");
            sb.AppendLine("}");
        }


        private void addInit(DataSet d, StringBuilder sb) {

            sb.AppendLine("[DebuggerNonUserCode]");
            sb.AppendLine($"protected {d.DataSetName} (SerializationInfo info,StreamingContext ctx):base(info,ctx) {{}}");
            sb.AppendLine("[DebuggerNonUserCode]");
            sb.AppendLine("private void initClass() {");
            sb.AppendLine("\tDataSetName = \"" + d.DataSetName + "\";");
            sb.AppendLine("\tPrefix = \"" + d.Prefix + "\";");
            sb.AppendLine("\tNamespace = \"http://tempuri.org/" + d.DataSetName + ".xsd\";");
            //SB.AppendLine("this.Namespace = \"" + D.Namespace + "\";");
            //SB.AppendLine("\tSchemaSerializationMode = SchemaSerializationMode.IncludeSchema;"); it's the default
            //sb.AppendLine("\tEnforceConstraints = false;");

            addDataTables(d, sb);
            addDataRelations(d, sb);

            sb.AppendLine("}");




        }


        private string snull(string s) {
            if(s == null)
                return "null";
            return "\"" + s + "\"";
        }

        static bool anySpecialColumn(DataSet d) {
            foreach(DataTable t in d.Tables) {
                foreach(DataColumn c in t.Columns) {
                    if(!c.AllowDBNull)
                        return true;
                    if(c.ReadOnly)
                        return true;
                }
            }
            return false;
        }

        string getDataRowTypeName(string tableName) {
            return tableName + "Row";
        }
        string getDataTableTypeName(string tableName) {
            return tableName + "Table";
        }





        bool isSpecialTable(string t) {
            return _metaDataList.ContainsKey(t);
        }

        private void addDataTables(DataSet d, StringBuilder sb) {
            var baseTableClass = _compilazioneConMetaData ? "MetaTable" : "DataTable";
            if(d.Tables.Count > 0) {
                sb.AppendLine();
                sb.AppendLine("\t#region create DataTables");
            }
            if(anySpecialColumn(d) && !_compilazioneConMetaData)
                sb.AppendLine("\tDataColumn C;");
            //if (AnyKey(D))SB.AppendLine("\tDataColumn [] key;");
            foreach(DataTable T in d.Tables) {
                var tableAlias = T.TableName;      //tableAlias è nome della tabella VERA, ossia del meta e del tipo
                if(T.ExtendedProperties["TableForReading"] != null
                     && T.ExtendedProperties["TableForReading"].ToString() != ""
                    )
                    tableAlias = T.ExtendedProperties["TableForReading"].ToString();


                sb.AppendLine("\t//////////////////// " + T.TableName.ToUpper() + " /////////////////////////////////");
                var isSpecial = isSpecialTable(tableAlias);
                string tName;
                if(isSpecial && _compilazioneConMetaData) {
                    tName = "t" + T.TableName;
                    sb.AppendLine($"\tvar {tName}= new {getDataTableTypeName(tableAlias)}();");
                    if(T.TableName != tableAlias) {
                        sb.AppendLine($"\t{tName}.TableName = \"{ T.TableName}\";");
                    }
                    var definedCols = "";
                    foreach(DataColumn c in T.Columns) {
                        if(c.ColumnName.StartsWith("!"))
                            continue;
                        if(definedCols != "")
                            definedCols += ",";
                        definedCols += "\"" + c.ColumnName + "\"";
                    }
                    if(definedCols != "") {
                        //invoca il comando per aggiungere tutte le colonne desiderate
                        sb.AppendLine($"\t{tName}.addBaseColumns({definedCols});");
                    }
                }
                else {
                    tName = "t" + T.TableName;
                    sb.AppendLine($"\tvar {tName}= new " + baseTableClass + "(" + snull(T.TableName) + ");");
                }

                //SB.AppendLine("\tT.Namespace = this.Namespace;");

                foreach(DataColumn c in T.Columns) {
                    if(_compilazioneConMetaData && isSpecial && !c.ColumnName.StartsWith("!")) {
                        //Alle tabelle speciali aggiunge solo le colonne custom
                        continue;
                    }

                    bool isReadOnly = c.ReadOnly;
                    if(c.ColumnName.StartsWith("!") && c.Expression != null && c.Expression.StartsWith("'") &&
                        c.Expression.EndsWith("'")) {
                        isReadOnly = false;
                    }

                    if(_compilazioneConMetaData) {
                        sb.Append($"\t{tName}.defineColumn(\"{c.ColumnName}\", typeof({typeName(c.DataType)})");
                        if(!c.AllowDBNull) {
                            sb.Append(",false");
                            if(c.ReadOnly) {
                                sb.Append(",true");
                            }
                        }
                        else {
                            if(isReadOnly) {
                                sb.Append(",true,true");
                            }
                        }
                        sb.AppendLine(");");
                    }
                    else {
                        if(c.AllowDBNull && !isReadOnly) {
                            sb.AppendLine(
                                $"\t{tName}.Columns.Add( new DataColumn({snull(c.ColumnName)}, typeof({typeName(c.DataType)})));");
                            continue;
                        }
                        sb.AppendLine($"\tC= new DataColumn({snull(c.ColumnName)}, typeof({typeName(c.DataType)}));");
                        if(!c.AllowDBNull)
                            sb.AppendLine("\tC.AllowDBNull=false;");
                        if(isReadOnly)
                            sb.AppendLine("\tC.ReadOnly=true;");
                        sb.AppendLine("\t" + tName + ".Columns.Add(C);");
                    }
                }

                //SB.AppendLine("\tT.Namespace = this.Namespace;");
                foreach(DataColumn c in T.Columns) {
                    if(c.ColumnName.StartsWith("!") && c.Expression != null && c.Expression.Trim() != "") {
                        sb.AppendLine(
                            $"\t{tName}.Columns[\"{c.ColumnName}\"].ExtendedProperties[\"IsTemporaryColumn\"]=\"{c.Expression.Replace("'", "")}\";");
                    }
                }

                if(T.ExtendedProperties.Count > 0) {
                    foreach(string pName in T.ExtendedProperties.Keys) {
                        var pVal = T.ExtendedProperties[pName];
                        if(pVal != null && pVal.ToString() != "") {
                            sb.AppendLine($"\t{tName}.ExtendedProperties[\"{pName}\"]=\"{pVal}\";");
                        }
                    }
                }
                sb.AppendLine("\tTables.Add(" + tName + ");");
                addKeyDeclaration(T, tName, sb);
                sb.AppendLine();


            }
            if(d.Tables.Count > 0) {
                sb.AppendLine("\t#endregion");
                sb.AppendLine();
            }

        }

        private void addKeyDeclaration(DataTable T, string varTableName, StringBuilder sb) {
            if(T.PrimaryKey.Length == 0)
                return;
            string keyCols;
            if(_compilazioneConMetaData) {           //isSpecialTable(T.TableName)||
                keyCols = varTableName + ".defineKey(";
                for(var k = 0; k < T.PrimaryKey.Length; k++) {
                    if(k > 0) {
                        keyCols += ", ";
                    }
                    keyCols += "\"" + T.PrimaryKey[k].ColumnName + "\"";
                }
                keyCols += ");";
                sb.AppendLine("\t" + keyCols);
                return;
            }

            keyCols = " new DataColumn[]{";
            for(var k = 0; k < T.PrimaryKey.Length; k++) {
                if(k > 0) {
                    keyCols += ", ";
                }
                keyCols += varTableName + ".Columns[" + snull(T.PrimaryKey[k].ColumnName) + "]";
            }
            keyCols += "}";
            sb.AppendLine("\t" + varTableName + ".PrimaryKey = " + keyCols + ";");
            sb.AppendLine();
        }


        private void addDataRelations(DataSet d, StringBuilder sb) {
            if(d.Relations.Count == 0)
                return;
            sb.AppendLine();
            sb.AppendLine("\t#region DataRelation creation");
            var cParStart = "\tvar cPar";
            var cChildStart = "\tvar cChild";
            foreach(DataRelation r in d.Relations) {
                var sameColNames = true;
                for(var i = 0; i < r.ParentColumns.Length; i++) {
                    if(r.ParentColumns[i].ColumnName != r.ChildColumns[i].ColumnName)
                        sameColNames = false;
                }
                if(sameColNames && (_someSpecialAdded && _compilazioneConMetaData)) {
                    var reldef = "\tthis.defineRelation(\"" + r.RelationName + "\",\"" + r.ParentTable.TableName + "\",\"" +
                                r.ChildTable.TableName + "\"";
                    for(var i = 0; i < r.ParentColumns.Length; i++) {
                        reldef += ",\"" + r.ParentColumns[i].ColumnName + "\"";
                    }
                    reldef += ");";
                    sb.AppendLine(reldef);
                    continue;
                }

                sb.Append(cParStart);
                cParStart = "\tcPar";
                sb.Append(" = new []{");
                for(var i = 0; i < r.ParentColumns.Length; i++) {
                    if(i > 0)
                        sb.Append(", ");
                    sb.Append(r.ParentTable.TableName + ".Columns[\"" + r.ParentColumns[i].ColumnName + "\"]");
                }
                sb.AppendLine("};");
                sb.Append(cChildStart);
                cChildStart = "\tcChild";
                sb.Append(" = new []{");
                for(var j = 0; j < r.ChildColumns.Length; j++) {
                    if(j > 0)
                        sb.Append(", ");
                    sb.Append(r.ChildTable.TableName + ".Columns[\"" + r.ChildColumns[j].ColumnName + "\"]");
                }
                sb.AppendLine("};");
                sb.AppendLine("\tRelations.Add(new DataRelation(\"" + r.RelationName + "\",cPar,cChild,false));");
                sb.AppendLine();
            }
            sb.AppendLine("\t#endregion");
            sb.AppendLine();


        }

        /// <summary>
        /// Restituisce il nome del metadato a partire dalla cartella in cui si trova  il DataSet oggetto dell'elaborazione
        /// Assume che il dataset da processare, nel caso di metadato, si trovi in una cartella il cui nome inizia con meta_
        /// Se per esempio il DataSet si trova in una cartella meta_expense, è restituita la stringa "expense"
        /// </summary>
        /// <param name="dataSetFileName"></param>
        /// <returns></returns>
        string getMetaData(string dataSetFileName) {
            if(dataSetFileName == null)
                return null;
            var dataSetFile = new FileInfo(dataSetFileName);
            if(dataSetFile.Directory == null)
                return null;
            var lastPath = dataSetFile.Directory.Name;
            return !lastPath.ToLowerInvariant().StartsWith("meta_") ? null : lastPath.Substring(5).ToLowerInvariant();
        }


        /// <summary>
        /// Calcola un nuovo DataSet  (file XSD) senza i miliardi di proprietà che aggiunge MS
        /// Eventualmente, se diverso dall'originario, lo scrive anche sul disco
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="d"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        DataSet clearDataSet(string filename, DataSet d, bool form) { //string filename
            //DataSet D = new DataSet();
            //D.ReadXml(filename, XmlReadMode.ReadSchema);

            //Si costruisce un DataSet a partire dal suo xml schema
            var e = new DataSet(d.DataSetName) {
                SchemaSerializationMode = d.SchemaSerializationMode,
                DataSetName = d.DataSetName,
                EnforceConstraints = d.EnforceConstraints,
                Locale = d.Locale,
                Namespace = d.Namespace,
                Prefix = d.Prefix,
                RemotingFormat = d.RemotingFormat,
                Site = d.Site
            };



            //Tabelle e chiavi
            foreach(DataTable T in d.Tables) {
                var tt = new DataTable(T.TableName);
                foreach(var k in T.ExtendedProperties.Keys) {
                    if(k.ToString().StartsWith("Generator_"))
                        continue;       //salta le altre property microsoft
                    tt.ExtendedProperties[k] = T.ExtendedProperties[k];
                }

                e.Tables.Add(tt);
                foreach(DataColumn c in T.Columns) {
                    //foreach (string cc in c.ExtendedProperties.Keys) log(c.ColumnName + ":" + cc);
                    if(c.ExtendedProperties["Expression"] != null) {
                        var cc = tt.Columns.Add(c.ColumnName, c.DataType, "'" + c.ExtendedProperties["IsTemporaryColumn"].ToString() + "'");
                        cc.AllowDBNull = c.AllowDBNull;
                        cc.ReadOnly = cc.ReadOnly;
                        continue;
                    }
                    if(c.ExtendedProperties["IsTemporaryColumn"] != null) {
                        var cc = tt.Columns.Add(c.ColumnName, c.DataType, "'" + c.ExtendedProperties["IsTemporaryColumn"].ToString() + "'");
                        cc.AllowDBNull = c.AllowDBNull;
                        cc.ReadOnly = true;
                    }
                    else {
                        var cc = tt.Columns.Add(c.ColumnName, c.DataType, c.Expression);
                        cc.AllowDBNull = c.AllowDBNull;
                        cc.ReadOnly = c.ReadOnly;
                    }

                }

                var key = new DataColumn[T.PrimaryKey.Length];
                for(var k = 0; k < key.Length; k++) {
                    key[k] = tt.Columns[T.PrimaryKey[k].ColumnName];
                }
                tt.PrimaryKey = key;

            }



            //Relazioni
            foreach(DataRelation r in d.Relations) {
                var parenttable = r.ParentTable.TableName;
                var childtable = r.ChildTable.TableName;
                var parent = e.Tables[parenttable];
                var child = e.Tables[childtable];
                var parCol = new DataColumn[r.ParentColumns.Length];
                var childCol = new DataColumn[r.ChildColumns.Length];
                for(var i = 0; i < r.ParentColumns.Length; i++) {
                    parCol[i] = parent.Columns[r.ParentColumns[i].ColumnName];
                    childCol[i] = child.Columns[r.ChildColumns[i].ColumnName];
                }
                var rel = new DataRelation(r.RelationName,
                    parCol, childCol, false);  //mettendo true da problemi con la generazione del codice, inizia ad aggiungere
                                               // degli addRange nel .cs del form e crea conflitti       
                foreach(var k in r.ExtendedProperties.Keys) {
                    if(k.ToString().StartsWith("Generator_"))
                        continue;       //salta le altre property microsoft
                    rel.ExtendedProperties[k] = r.ExtendedProperties[k];
                }
                e.Relations.Add(rel);

            }




            if(d.GetXmlSchema() != e.GetXmlSchema()) { //
                var ms = new MemoryStream();
                e.WriteXmlSchema(ms);
                ms.Position = 0;
                var x = new XmlDocument();
                x.Load(ms);
                var xmldecl = x.CreateXmlDeclaration("1.0", "utf - 8", "yes");
                x.ReplaceChild(xmldecl, x.FirstChild);

                var attr = x.CreateAttribute("xmlns", "msprop", XmlnsNs);
                attr.Value = XmlnsProp;
                x.DocumentElement?.SetAttributeNode(attr);

                var elVista = x.DocumentElement?.ChildNodes[0];

                //XmlAttribute attrVista = x.CreateAttribute("EnforceConstraints", xmlnsDATA);
                //attrVista.Value = "true";
                //elVista.Attributes.RemoveNamedItem("EnforceConstraints", xmlnsDATA);
                //elVista.Attributes.Append(attrVista);


                //msdata:EnforceConstraints="False"
                var elComplexType = elVista?.ChildNodes[0];
                var elChoice = elComplexType?.ChildNodes[0];
                //XmlAttribute attrComplex = x.CreateAttribute("alias", "msprop");
                //attrComplex.Value = "elComplexType";
                //elComplexType.Attributes.Append(attrComplex);

                if(_compilazioneConMetaData && form && elChoice != null) {
                    foreach(DataTable t in e.Tables) {
                        foreach(XmlNode elTable in elChoice.ChildNodes) {
                            if(elTable.Attributes?.GetNamedItem("name").Value != t.TableName)
                                continue;
                            foreach(var k in new[] { "TableForReading","TableForPosting",
                                "FilterForSearch","FilterForInsert","AddBlankRow","SkipSecurity"}) {
                                var attrEl = x.CreateAttribute(k, XmlnsProp);
                                var val = t.ExtendedProperties[k] ?? "";
                                attrEl.Value = val.ToString();
                                elTable.Attributes?.Append(attrEl);
                            }

                        }

                    }
                }

                //Elimina i warning ma il dataset non è più leggibile da visual studio
                //if (x.DocumentElement.ChildNodes.Count > 1) {
                //    XmlNode elAnnotation = x.DocumentElement.ChildNodes[1];
                //    XmlNode elAppInfo = elAnnotation.ChildNodes[0];

                //    //Migliora la scrittura delle relazioni
                //    //XmlNodeList allRel = x.SelectNodes("//Relationship");                //msData:
                //    foreach (XmlNode xRel in elAppInfo.ChildNodes) {
                //        XmlAttribute oldName = xRel.Attributes["name"];
                //        if (oldName != null) {
                //            string name = oldName.InnerText;
                //            xRel.Attributes.Remove(oldName);
                //            XmlAttribute newName = x.CreateAttribute("RelationName", xmlnsDATA); //msdata:
                //            newName.InnerText = name;
                //            xRel.Attributes.InsertBefore(newName,xRel.Attributes["msdata:parent"]);
                //        }

                //        XmlAttribute oldParent = xRel.Attributes["msdata:parentkey"];
                //        if (oldParent != null) {
                //            string parent = oldParent.InnerText;
                //            xRel.Attributes.Remove(oldParent);
                //            XmlAttribute newParent = x.CreateAttribute("parentKey", xmlnsDATA);
                //            newParent.InnerText = parent;
                //            xRel.Attributes.InsertAfter(newParent,xRel.Attributes["msdata:child"]);
                //        }

                //        XmlAttribute oldChild = xRel.Attributes["msdata:childkey"];
                //        if (oldChild != null) {
                //            string child = oldChild.InnerText;
                //            xRel.Attributes.Remove(oldChild);
                //            XmlAttribute newChild = x.CreateAttribute("childKey", xmlnsDATA);
                //            newChild.InnerText = child;
                //            xRel.Attributes.InsertAfter(newChild,xRel.Attributes["msdata:parentKey"]);
                //        }
                //    }
                //}

                var sw = new StreamWriter(filename, false, Encoding.UTF8);
                x.Save(sw);
                sw.Close();
                //x.Save("d:\\NEWDATASET.XSD");
            }
            return e;
        }
        /// <summary>
        /// parametro obbligatorio quando si crea un attribute con prefix="xmlns"
        /// </summary>
        const string XmlnsNs = "http://www.w3.org/2000/xmlns/";
        const string XmlnsProp = "urn:schemas-microsoft-com:xml-msprop";

        /// <summary>
        /// Cerca il nome del file CsProj a partire dal nome del dataset da elaborare. Se non lo trova
        ///  nella stessa cartella risale sino alla root
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        string findCsProjFile(string filename) {
            var f = new FileInfo(filename);
            var dir = f.DirectoryName;
            if(dir == null)
                return null;
            string[] found; //file csProj trovati
            while(true) {
                found = Directory.GetFiles(dir, "*.csproj");
                if(found.Length > 0)
                    break;
                var d = new DirectoryInfo(dir);
                if(d.Parent == null)
                    break;
                if(d.Parent == d.Root)
                    break;
                dir = d.Parent.FullName;
            }
            return found.Length == 0 ? null : found[0];
        }

        private static string getProp(XmlElement xEl, string prop) {
            if(xEl == null)
                return null;
            var nn = xEl.GetElementsByTagName(prop);
            return nn.Count == 0 ? null : nn[0].InnerText;
        }

        private static void setProp(XmlElement xEl, string prop, string value) {
            if(xEl == null)
                return;
            var nn = xEl.GetElementsByTagName(prop);
            if(nn.Count == 0) {
                var doc = xEl.OwnerDocument;
                var newProp = doc?.CreateElement(prop, xEl.NamespaceURI);
                if(newProp == null)
                    return;
                newProp.InnerText = value;
                xEl.AppendChild(newProp);
                //Console.WriteLine("Created  " + prop + " to " + value);
                return;
            }

            if(nn[0].InnerText != value) {
                nn[0].InnerText = value;
            }
        }

        static string getAttribute(XmlElement xEl, string attrName) {
            if(xEl == null)
                return null;
            if(!xEl.HasAttribute(attrName))
                return null;
            return xEl.GetAttribute(attrName);
        }

        // ReSharper disable once UnusedMember.Local
        static bool setAttribute(XmlElement xEl, string attrName, string value) {
            if(xEl == null)
                return false;

            if(xEl.HasAttribute(attrName)) {
                var attr = xEl.GetAttribute(attrName);
                if(attr == value)
                    return false;
                xEl.SetAttribute(attrName, value);
                //Console.WriteLine("Setted attribute " + attrName + " to " + value);
                return true;
            }
            xEl.SetAttribute(attrName, value);
            //Console.WriteLine("Created attribute " + attrName + " to " + value);
            return true;
        }



        /// <summary>
        /// Controlla se il progetto ha un dataset collegato
        /// </summary>
        /// <param name="proj"></param>
        /// <param name="datasetName"></param>
        /// <returns></returns>
        bool isDataSetLinked(XmlDocument proj, string datasetName) {
            var fds = new FileInfo(datasetName);
            var dsName = fds.Name;

            var ms = new MemoryStream();
            proj.Save(ms);
            ms.Seek(0, SeekOrigin.Begin);
            var sr = new StreamReader(ms);
            var prog = sr.ReadToEnd();
            sr.Close();
            var s1 = prog.IndexOf($"<Content Include=\"{dsName}\">", StringComparison.Ordinal);
            if(s1 >= 0) {
                return true;
            }
            s1 = prog.IndexOf($"<None Include=\"{dsName}\">", StringComparison.Ordinal);
            return s1 >= 0;
        }

        /// <summary>
        /// Cancella app.config, Properties, Settings.Designer.cs , Settings.settings
        /// </summary>
        /// <param name="proj"></param>
        /// <param name="projFileName"></param>
        /// <param name="datasetName"></param>
        private static bool processProject(XmlDocument proj, string projFileName, string datasetName) {

            var fds = new FileInfo(datasetName);
            var dsName = fds.Name;

            //Estrae la directory dal filename
            var f = new FileInfo(projFileName);
            var dir = f.DirectoryName;
            if(Directory.Exists(dir + "\\Properties")) {
                Directory.Delete(dir + "\\Properties", true);
            }
            //if (File.Exists(dir + "\\app.config")) {
            //    File.Delete(dir + "\\app.config");
            //}
            var ms = new MemoryStream();
            proj.Save(ms);
            ms.Seek(0, SeekOrigin.Begin);

            var sr = new StreamReader(ms);
            var prog = sr.ReadToEnd();
            sr.Close();
            var somedone = false;
            //Cerca <None Include="app.config" />
            //int p1 = prog.IndexOf("<None Include=\"app.config\" />");
            //if (p1 >= 0) {
            //    int p2 = prog.IndexOf("</None>", p1);
            //    if (p2 > 0) {
            //        prog = prog.Substring(0, p1) + prog.Substring(p2 + 9);
            //        somedone = true;
            //    }
            //}
            var s1 = prog.IndexOf("<Compile Include=\"Properties\\Settings.Designer.cs\">", StringComparison.Ordinal);
            if(s1 >= 0) {
                var s2 = prog.IndexOf("</Compile>", s1, StringComparison.Ordinal);
                if(s2 > 0) {
                    prog = prog.Substring(0, s1) + prog.Substring(s2 + 12);
                    somedone = true;
                }
            }
            s1 = prog.IndexOf($"<Content Include=\"{dsName}\">", StringComparison.Ordinal);
            if(s1 >= 0) {
                var s2 = prog.IndexOf("</Content>", s1, StringComparison.Ordinal);
                if(s2 > 0) {

                    var tofind = "<Generator>MSDataSetGenerator</Generator>";
                    var s3 = prog.IndexOf(tofind, s1, StringComparison.Ordinal);
                    if(s3 > 0 && s3 < s2) {
                        prog = prog.Substring(0, s3) + "<Generator>HDSGene</Generator>" +
                             prog.Substring(s3 + tofind.Length);
                        somedone = true;
                    }

                }
            }
            s1 = prog.IndexOf($"<None Include=\"{dsName}\">", StringComparison.Ordinal);
            if(s1 >= 0) {
                var s2 = prog.IndexOf("</None>", s1, StringComparison.Ordinal);
                if(s2 > 0) {

                    var tofind = "<Generator>MSDataSetGenerator</Generator>";
                    var s3 = prog.IndexOf(tofind, s1, StringComparison.Ordinal);
                    if(s3 > 0 && s3 < s2) {
                        prog = prog.Substring(0, s3) + "<Generator>HDSGene</Generator>" +
                             prog.Substring(s3 + tofind.Length);
                        somedone = true;
                    }

                }
            }
            s1 = prog.IndexOf("<None Include=\"Properties\\Settings.settings\">", StringComparison.Ordinal);
            if(s1 >= 0) {
                var s2 = prog.IndexOf("</None>", s1, StringComparison.Ordinal);
                if(s2 > 0) {
                    prog = prog.Substring(0, s1) + prog.Substring(s2 + 9);
                    somedone = true;
                }
            }
            s1 = prog.IndexOf("<None Include=\"Properties\\Settings.settings\">", StringComparison.Ordinal);
            if(s1 >= 0) {
                var s2 = prog.IndexOf("</None>", s1, StringComparison.Ordinal);
                if(s2 > 0) {
                    prog = prog.Substring(0, s1) + prog.Substring(s2 + 9);
                    somedone = true;
                }
            }

            if(somedone) {
                ms = new MemoryStream();
                var sw = new StreamWriter(ms, Encoding.UTF8);
                sw.Write(prog);
                sw.WriteLine();
                sw.Flush();

                //File.WriteAllText(Path.Combine(FDS.DirectoryName, "tempxml.xml"), prog);
                //SW.Close();

                ms.Seek(0, SeekOrigin.Begin);

                try {
                    proj.Load(ms);
                }
                catch(Exception e) {
                    throw new Exception($"Errore {e} cercando di leggere l\'xml così formato:\r\n{prog}", e);
                }

            }
            return somedone;
        }


    }

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
            var objCurrRowCurr = (JObject)JsonConvert.DeserializeObject(dataFieldCurr);
            var columns = row.Table.Columns;
            foreach(var dataRowValue in objCurrRowCurr) {
                var field = dataRowValue.Key;
                var rowValue = dataRowValue.Value;

                if(columns[field] == null) {
                    throw new Exception("DataSetSerializer.getRowData: Table " + row.Table.TableName +
                                        " doesn't contain the field: " + field);
                }

                if(columns[field].DataType.Name == "DateTime") {
                    if(rowValue == null || rowValue.ToString().Length == 0) {
                        row[field] = DBNull.Value;
                    }
                    else {
                        row[field] = (DateTime)rowValue; //Convert.ToDateTime(rowValue.ToString());
                    }
                }
                else if(columns[field].DataType.Name == "Byte[]") {
                    if(rowValue == null || rowValue.ToString().Length == 0) {
                        row[field] = DBNull.Value;
                    }
                    else {
                        byte[] bytes = Encoding.ASCII.GetBytes(rowValue.ToString());
                        row[field] = bytes;
                    }
                }
                else {
                    // TODO capire meglio se stringa vuota va considerato null
                    //  if (rowValue == null || rowValue.ToString().Length == 0) {
                    if(rowValue == null) {
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
                foreach(var r in obj.Children()) {
                    var objRow = (JObject)JsonConvert.DeserializeObject(r.ToString());

                    // creo nuova riga
                    var currRow = table.NewRow();

                    // var che memorizza lo stato della riga riportato dal client
                    var currRowState = (string)objRow["state"];

                    if(currRowState == "added") {
                        getRowData(currRow, objRow["curr"]);
                        table.Rows.Add(currRow);
                        continue;
                    }

                    getRowData(currRow, objRow["old"]);


                    table.Rows.Add(currRow);


                    currRow.AcceptChanges(); // mette i valori originali, quindi è nello stato Unchanged

                    if(currRowState == "deleted") {
                        currRow.Delete();
                        continue;
                    }

                    if(currRowState == "modified") {
                        getRowData(currRow, objRow["curr"]);
                        // i null non viaggiano da client a server.consiedero null quelli che erano in old e non sono in curr 
                        checkNullInModifiedRow(currRow, objRow["old"], objRow["curr"]);
                    }
                }
            }
            catch(Exception e) {
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
            var objOLDRow = (JObject)JsonConvert.DeserializeObject(dataFieldOLD);
            var columns = row.Table.Columns;

            var dataFieldCurr = objRowCurr.ToString();
            var objCurrRow = (JObject)JsonConvert.DeserializeObject(dataFieldCurr);

            // scorro old. se non trovo il field in curr allora metto  a null
            foreach(var dataRowValue in objOLDRow) {
                var field = dataRowValue.Key;
                var rowValue = dataRowValue.Value;
                // sulla collection dei curr non trovo più quel campo, allora lo metto a null
                if(objCurrRow[field] == null)
                    row[field] = DBNull.Value;
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
            string[] stringSeparators = { "," };
            var keysArray = keys.ToString().Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            // costrusico array di stringhe che poi traformerò in array di DataColumn
            if(keysArray.Length > 0) {
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
            var obj = (JObject)JsonConvert.DeserializeObject(sColumn);

            var c = new DataColumn(name);

            foreach(var p in obj) {
                var key = p.Key;
                var value = p.Value;
                switch(key) {
                    case "ctype":
                    Type cType = getColumnType(value);
                    c.DataType = cType;
                    break;
                    case "name":
                    break;
                    case "allowDbNull":
                    c.AllowDBNull = (bool)value;
                    break;
                    case "isDenyNull":
                    c.SetDenyNull((bool)value);
                    //c.ExtendedProperties.Add("DenyNull", (Boolean)value);
                    break;
                    case "isDenyZero":
                    c.SetDenyZero((bool)value);
                    //c.ExtendedProperties.Add("DenyZero", (Boolean)value);
                    break;
                    case "allowZero":
                    c.ExtendedProperties.Add("allowZero", (Boolean)value);
                    break;
                    case "caption":
                    c.Caption = (string)value;
                    break;
                    case "expression":
                    // TODO Modificare se sarà implementato un  QueryCreator.SetMetaExpression();
                    if(value is JValue) {
                        c.ExtendedProperties.Add(IsTempColumn, value.ToString());
                    }
                    else {
                        c.ExtendedProperties.Add(IsTempColumn,
                            metaExpressionFromJsDataQueryJson(value.ToString()));
                    }

                    break;
                    case "listColPos":
                    c.ExtendedProperties.Add("ListColPos", (int)value);
                    break;
                    case "maxstringlen":
                    c.ExtendedProperties.Add("maxstringlen", (int)value);
                    break;
                    case "length":
                    c.ExtendedProperties.Add("length", (int)value);
                    break;
                    case "sqltype":
                    c.ExtendedProperties.Add("sqltype", (string)value);
                    break;
                    case "forPosting":
                    QueryCreator.SetColumnNameForPosting(c, (string)value);
                    break;
                    case "format":
                    mdl_utils.HelpUi.SetFormatForColumn(c, (string)value);
                    //c.ExtendedProperties.Add("format", (string)value);
                    break;
                    case "isTemporaryColumn":
                    c.ExtendedProperties.Add("IsTemporaryColumn", (string)value);
                    break;

                    case "viewSource":
                    c.ExtendedProperties.Add("ViewSource", (string)value);
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
            if(autoincrements.HasValues) {
                var obj = (JObject)JsonConvert.DeserializeObject(autoincrements.ToString());
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
            var obj = (JObject)JsonConvert.DeserializeObject(sColumn);


            // ovviamente se sto qui seignifica che è un autoincrement 
            dc.ExtendedProperties[AutoIncrement] = "s";

            // Dichiaro array di selettori e selcetorMask da popolare e succesivamente farne il loop
            var selectors = new List<string>();
            var selectorsMask = new List<UInt64>();

            // N.B per ora utilizzo le prop ExtProp , non il metodo  RowChange.MarkAsAutoincrement(..),
            // poichè delle porp potrebbero non esserci e mandare in errore il successivo codice. Ad
            // esempio middleConst nel caso isNumber non c'è di proposito perchè lato js è grstito in questo
            // modo e se passo nulla a MarkAsAutoincrement poi ottengo errore. allora faccio il set una per una
            foreach(var p in obj) {
                var key = p.Key;
                var value = p.Value;
                switch(key) {
                    case "middleConst":
                    dc.ExtendedProperties[MiddleConst] = value.ToString() != "" ? value.ToString() : null;
                    break;
                    case "idLen":
                    dc.ExtendedProperties[IDLength] = (int)value;
                    break;
                    case "prefixField":
                    dc.ExtendedProperties[PrefixField] = value.ToString() != "" ? value.ToString() : null;
                    break;
                    case "linearField":
                    var linear = (bool)value;
                    if(linear)
                        dc.ExtendedProperties[LinearField] = "1";
                    break;
                    case "minimum":
                    RowChange.setMinimumTempValue(dc, (int)value);
                    break;
                    case "selector":

                    // popolo una lista di appoggio , poichè poi devo settare insieme al mask
                    foreach(var cname in value.Children()) {
                        //var cnameString = (JObject)JsonConvert.DeserializeObject(cname.ToString());
                        var cnameString = cname.ToString();
                        selectors.Add(cnameString);
                    }

                    break;

                    case "selectorMask":

                    // popolo una lista di appoggio , poichè poi devo settare insieme ai selectors
                    foreach(var mask in value.Children()) {
                        var maskUInt64 = (UInt64)mask;
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
            for(var i = 0; i < selectors.Count; i++) {
                ulong mask = 1;
                if(selectorsMask.Count > 0 && i < selectorsMask.Count) {
                    mask = (ulong)selectorsMask[i];
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
            var obj = (JObject)JsonConvert.DeserializeObject(defaults.ToString());
            obj.Properties()._forEach(col => {
                if(col.Value.Type != JTokenType.Null) {
                    if(table.Columns[col.Name] == null)
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
        public static DataTable jTokenToTable(JToken dataTable) {
            var name = dataTable["name"].ToString();
            var table = new MetaTable(name);
            try {
                var jObj = (JObject)JsonConvert.DeserializeObject(dataTable.ToString());

                // deserializzo gli oggetti colonna, ogni oggetto colonna  a sua volta (il col.Value) è un oggetto con varie proprietà
                if(jObj["columns"] != null) {
                    var obj = (JObject)JsonConvert.DeserializeObject(jObj["columns"].ToString());
                    obj.Properties()._forEach(col => table.Columns.Add(getColumn(col.Name, col.Value)));
                }

                // deserializzo gli oggetti autoIncrementColumns per ogni colonna
                if(jObj["autoIncrementColumns"] != null)
                    addAutoIncrementProperties(jObj["autoIncrementColumns"], table);

                //  Deserializza la proprietà di default.
                //  Per ogni DataColumn del DataTable, nella proprietà DefaultValue, mette il valore della proprietà 
                //  di pari nome nell'oggetto default del jsDataTable, saltando quelle null 
                if(jObj["defaults"] != null)
                    addColumnDefaults(jObj["defaults"], table);

                // Aggiungo key dopo le columns
                if(jObj["key"] != null)
                    addKeys(jObj["key"], table);

                // aggiungo righe
                if(jObj["rows"] != null)
                    addRows(jObj["rows"], table);


                // staticFilter
                if(jObj["staticFilter"] != null) {
                    // recupero stringa
                    var staticFilter = jObj["staticFilter"]?.ToString();
                    // torno la metaexpression
                    var meFilter = metaExpressionFromJsDataQueryJson(staticFilter);
                    //DataUtils.getfilterFromJsDataQuery(staticFilter, dispatcher);
                    // trasformo sempre in stringa. 
                    //table.ExtendedProperties["filter"] = meFilter?.toSql(dispatcher.conn.GetQueryHelper(), dispatcher.conn);
                    table.ExtendedProperties["filterMetaExpression"] = meFilter;
                    //table.ExtendedProperties["filterMetaExpr"] = jObj["staticFilter"];
                }

                // tableForReading
                var tableName = name;
                if(jObj["tableForReading"] != null)
                    tableName = jObj["tableForReading"]?.ToString();
                DataAccess.SetTableForReading(table, tableName);

                // tableForWriting
                tableName = null;
                if(jObj["tableForWriting"] != null)
                    tableName = jObj["tableForWriting"]?.ToString();
                QueryCreator.SetTableForPosting(table, tableName);


                // isCached. inizializzo proprietà tabella
                GetData.UnCacheTable(table);
                if(jObj["isCached"] != null) {
                    if(jObj["isCached"].ToString() == "0")
                        GetData.CacheTable(table);

                    if(jObj["isCached"].ToString() == "1")
                        table.setLockRead();
                }

                // isTemporaryTable
                PostData.MarkAsRealTable(table);
                if(jObj["isTemporaryTable"] != null) {
                    if((Boolean)jObj["isTemporaryTable"]) {
                        PostData.MarkAsTemporaryTable(table, false);
                    }
                    else {
                        PostData.MarkAsRealTable(table);
                    }
                }

                // skypSecurity è settato/ritornato dalle funz in setSkipSecurity/isSkipSecurity su metaModel
                // va bene anche così, ma capire se si possono utilizzare i emtodi in MetaModel
                if(jObj["skipSecurity"] != null) {
                    if((Boolean)jObj["skipSecurity"]) {
                        table.ExtendedProperties["SkipSecurity"] = true;
                    }
                    else {
                        table.ExtendedProperties["SkipSecurity"] = (object)null;
                    }
                }

                // skipInsertCopy
                if(jObj["skipInsertCopy"] != null) {
                    if((Boolean)jObj["skipInsertCopy"]) {
                        QueryCreator.setSkipInsertCopy(table, true);
                    }
                    else {
                        QueryCreator.setSkipInsertCopy(table, false);
                    }
                }

                // realTable. utilizzo delle ext prop RealTableName perchè poi quelleutili realTable e viewTable saranno tabelle vere e proprie prese dal dataset
                if(jObj["realTable"] != null) {
                    table.ExtendedProperties["RealTableName"] = (string)jObj["realTable"];
                }

                // viewTable
                if(jObj["viewTable"] != null) {
                    table.ExtendedProperties["ViewTableName"] = (string)jObj["viewTable"];
                }

                // denyClear
                if(jObj["denyClear"] != null) {
                    if((String)jObj["denyClear"] == "y") {
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
                if(jObj["orderBy"] != null)
                    table.setSorting((string)jObj["orderBy"]);

                return table;
            }
            catch(Exception e) {
                throw new Exception("Errore nella serializzazione della taella: " + table.TableName + "; " + e.Message);
            }
        }


        public static MetaExpression metaExpressionFromJsDataQueryJson(JToken filter) {
            MetaExpression q = null;
            if(JObject.Parse(filter.ToString()).Count != 0) {
                q = MetaExpressionSerializer.deserialize(JObject.Parse(filter.ToString())) as MetaExpression;
            }

            return q;
        }

        /// <summary>
        /// Returns a RelationObj, with the info of the relation
        /// </summary>
        /// <param name="name">string</param>
        /// <param name="relation">JToken</param>
        /// <param name="dataSet">DataSet</param>
        /// <returns>a RelationObj</returns>
        public static void createRelationFromJToken(string name, JToken relation, DataSet dataSet) {

            var stringSeparators = new[] { "," };

            var obj = (JObject)JsonConvert.DeserializeObject(relation.ToString());
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
        public static DataSet deserialize(JObject jObj) {


            // trasformo in JObject
            var dataSet = new DataSet();

            if(jObj["name"] != null)
                dataSet.DataSetName = (string)jObj["name"];

            // Recupero tabelle con colonne e righe
            if(jObj["tables"] != null) {
                var obj = (JObject)JsonConvert.DeserializeObject(jObj["tables"].ToString());
                obj.Properties()._forEach(t => dataSet.Tables.Add(jTokenToTable(t.Value)));
            }

            // Recupero relazioni
            if(jObj["relations"] != null) {
                var obj = (JObject)JsonConvert.DeserializeObject(jObj["relations"].ToString());
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
            foreach(DataTable table in dataSet.Tables) {
                string realTableName = (string)table.ExtendedProperties["RealTableName"];
                string viewTableName = (string)table.ExtendedProperties["ViewTableName"];
                if(!String.IsNullOrEmpty(realTableName)) {
                    DataTable dtReal = dataSet.Tables[realTableName];
                    if(dtReal != null) {
                        table.ExtendedProperties["RealTable"] = dtReal;
                    }
                }

                if(!String.IsNullOrEmpty(viewTableName)) {
                    DataTable dtView = dataSet.Tables[viewTableName];
                    if(dtView != null) {
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

            if(dc.Caption != null)
                dictcolProp.Add("caption", dc.Caption);

            if(dc.ColumnName != null)
                dictcolProp.Add("name", dc.ColumnName);

            if(dc.DataType != null)
                dictcolProp.Add("ctype", dc.DataType.ToString().Replace("System.", ""));

            dictcolProp.Add("allowDbNull", dc.AllowDBNull);

            dictcolProp.Add("isDenyNull", dc.IsDenyNull());

            dictcolProp.Add("isDenyZero", dc.IsDenyZero());

            if(dc.ExtendedProperties["allowZero"] != null)
                dictcolProp.Add("allowZero", getJTokenFromObject(dc.ExtendedProperties["allowZero"]));

            if(dc.ExtendedProperties["ListColPos"] != null)
                dictcolProp.Add("listColPos", getJTokenFromObject(dc.ExtendedProperties["ListColPos"]));

            if(dc.ExtendedProperties["maxstringlen"] != null)
                dictcolProp.Add("maxstringlen", getJTokenFromObject(dc.ExtendedProperties["maxstringlen"]));

            if(dc.ExtendedProperties["length"] != null)
                dictcolProp.Add("length", getJTokenFromObject(dc.ExtendedProperties["length"]));

            // potrei fare dictcolProp.Add("format", HelpForm.GetFormatForColumn(dc)); ma controllo solo la ext prop
            // altrimenti vado in conflitto con la logica implementata dal client per i default.
            if(dc.ExtendedProperties["format"] != null)
                dictcolProp.Add("format", getJTokenFromObject(dc.ExtendedProperties["format"]));

            // expression potrebbe essere o una stringa del tipo 1. table.columnName, o 2. una MetaExpression.
            // Serve per calcolare il valore di un campo, secpondo il campo di un altra tabella come nel caso 1 oppure
            // tramite il calcolo di una funz come nel caso 2.
            var expr = dc.ExtendedProperties[IsTempColumn];
            if(expr != null) {
                if(expr is MetaExpression)
                    dictcolProp.Add("expression", MetaExpressionSerializer.serialize(expr));

                if(expr is string)
                    dictcolProp.Add("expression", getJTokenFromObject(expr));

            }

            if(dc.ExtendedProperties["sqltype"] != null)
                dictcolProp.Add("sqltype", getJTokenFromObject(dc.ExtendedProperties["sqltype"]));


            dictcolProp.Add("forPosting", QueryCreator.PostingColumnName(dc));

            if(dc.ExtendedProperties["ViewSource"] != null)
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

            if(dc.ColumnName != null)
                dictcolAutoincrProp.Add("columnName", dc.ColumnName);


            // N.B:
            // AutoIncrement già insita nel fatto sia un autoIncrement, quindi IsAutoIncrement della funz chiamante
            // CustomAutoIncrement non è serailizzabile, dovrebbe esser gestita come autoincremento generico
            // PrefixField, MiddleConst, IDLength : li prendo da ext prop
            // Selector, SelectorMask : costruisco array prendendo i MySelector + MySelectorMask + quelly generici selector + selectorMask


            // Dichiaro array di selettori e selettori Mask da popolare e succesivamente serializzare
            var selectors = new List<string>();
            var selectorsMask = new List<string>();

            // 1.aggiungo prima i selector generici, passati come parametri e precalcolati in un ciclo sulle colonne precedente
            foreach(var genericSel in genericSelectors) {
                selectors.Add(genericSel);
            }

            foreach(var genericSelMask in genericSelectorsMask) {
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
            if(mySelector != null && mySelectorMask != null) {

                var arrayOfMySelectors = mySelector.Split(',');
                var arrayOfMySelectorsMask = mySelectorMask.Split(',');

                // ciclo sulle posizioni dei selector e aggiungo nell'array finale solo se già non esiste
                // TODO, capire per quelle che esistono già nei genrici il quale mask va considerato
                for(int i = 0; i < arrayOfMySelectors.Length; i++) {
                    var mySel = arrayOfMySelectors[i];
                    if(!selectors.Contains(mySel)) {
                        selectors.Add(mySel);
                        selectorsMask.Add(arrayOfMySelectorsMask[i]);
                    }

                }
            }

            // Modifico valori di "idLen", "middleConst", "prefixField" nel caso si tratti di una colonna
            // numerica. In quanto lato js questo AutoIncrement deve essere trattato come isNumber

            if(dc.DataType == System.Type.GetType("System.Decimal") ||
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
            if(rowValue is DateTime)
                return ((DateTime)rowValue).ToString(c_data_format);

            return rowValue;
        }

        /// <summary>
        /// Returns a json string (JsDataSet) serialized of a DataSet
        /// </summary>
        /// <param name="ds">DataSet to serialize in json string</param>
        /// <returns>the json string serialized of a DataSet</returns>
        public static string dataSetToJSon(DataSet ds) {
            return serialize(ds).ToString(Newtonsoft.Json.Formatting.None);

            //var serializer = new JavaScriptSerializer {MaxJsonLength = int.MaxValue};
            //return serializer.Serialize(DataSetSerializer.serialize(ds));
        }

        /// <summary>
        /// Take a DataSet and return a json string serialized with jsDataSet convention
        /// </summary>
        /// <param name="ds">Dataset to serialize in json format</param>
        /// <returns>The json string, representation of the ds DataSet with jsDataSet convention</returns>
        public static JObject serialize(DataSet ds) {

            var myTables = new JObject();

            // eseguo loop sulle tabelle
            foreach(DataTable t in ds.Tables) {
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
                var rDic = new JObject { ["state"] = r.RowState.ToString().ToLowerInvariant() };
                if(r.RowState == DataRowState.Deleted || r.RowState == DataRowState.Modified
                                                       || r.RowState == DataRowState.Unchanged
                ) {
                    rDic["old"] = r.Table.Columns.Cast<DataColumn>()._Reduce((dict, col) => {
                        var value = getRowColumnValue(r[col.ColumnName, DataRowVersion.Original]);
                        if(value != DBNull.Value)
                            dict[col.ColumnName] = getJTokenFromObject(value);
                        return dict;
                    }, new JObject());
                }

                if(r.RowState == DataRowState.Added || r.RowState == DataRowState.Modified
                //   ||r.RowState == DataRowState.Unchanged
                ) {
                    rDic["curr"] = r.Table.Columns.Cast<DataColumn>()._Reduce((dict, col) => {
                        var value = getRowColumnValue(r[col.ColumnName]);
                        if(value != DBNull.Value)
                            dict[col.ColumnName] = getJTokenFromObject(value);
                        return dict;
                    }, new JObject());
                }

                return rDic;
            });

            /* var tCurr = new Dictionary<string, object> {
                 {"rows", jRow}
             };*/
            var res = new JArray();
            foreach(var r in jRow)
                res.Add(r);
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

            foreach(DataColumn c in dt.Columns) {
                // TODO l'if è == "y" o basta sia !=null ??????
                if(c.ExtendedProperties[Selector] != null) {
                    listOfSelector.Add(c.ColumnName);

                    // Default è 0
                    var selectorMask = "0";
                    if(c.ExtendedProperties[SelectorMask] != null) {
                        selectorMask = c.ExtendedProperties[SelectorMask].ToString();
                    }

                    listOfSelectorMask.Add(selectorMask);

                }
            }

            foreach(DataColumn c in dt.Columns) {
                myColumns.Add(c.ColumnName, getColumnProperties(c));

                // ******************************* proprietà autoincremento *********************************************
                if(RowChange.IsAutoIncrement(c)) {
                    myAutoIncrementColumns.Add(c.ColumnName,
                        getColumnDictAutoincrementProperties(c, listOfSelector, listOfSelectorMask));
                }

                // ************** Aggiunge la serializzazione del set di default per le colonne del datatable ***********
                // distunguo caso sia una data, in quel caso formatto nel formato aspettato
                object defValue = c.DefaultValue;
                if(defValue is DateTime) {
                    defValue = ((DateTime)defValue).ToString(c_data_format);
                }

                myDefaults.Add(c.ColumnName, getJTokenFromObject(defValue));
            }

            // ******************************************************* Popolo righe *******************************************
            var rows = serializeRows(dt.Rows.Cast<DataRow>());


            // ***************************************** Serializzo lo staticFilter come jsDataQuery **************************
            JObject staticFilter = null;
            if(dt.ExtendedProperties["filterMetaExpression"] != null) {
                staticFilter = MetaExpressionSerializer.serialize(dt.ExtendedProperties["filterMetaExpression"]);
            }

            //********************************* Costrusice entry per la tabella attuale ***************************************

            var tCurr = new JObject {
                {"name", dt.TableName},
                {"key", string.Join(",", dt.PrimaryKey.Select(dc => dc.ColumnName).ToArray())},
                {"columns", myColumns},
                {"rows", rows},
                {"tableForReading", DataAccess.GetTableForReading(dt)},
                {"tableForWriting", dt.tableForPosting()},
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







    }

    public class MetaExpressionSerializer {

        private static readonly string c_data_format = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'";


        private static JObject serializeConstant(object o) {
            if(o == null) {
                return new JObject { { "value", null } };
            }

            var res = new JObject { { "value", JToken.FromObject(o) } };

            // gestisco il caso l'oggetto sia una data, lo formatto nel formato deciso
            if(o is DateTime) {
                var objDate = ((DateTime)o).ToString(c_data_format);
                res = new JObject { { "value", JToken.FromObject(objDate) } };
            }

            return res;
        }

        /// <summary>
        /// Create a MetaExpression / value / array from a serialized version
        /// </summary>
        /// <param name="jObj"></param>
        /// <returns></returns>
        public static object deserialize(JToken jObj) {
            if(jObj == null)
                return null;

            // se arrivo al value torno il value
            if(jObj["value"] != null) {
                if(jObj["value"].GetType() == typeof(JValue)) {
                    return ((JValue)jObj["value"]).Value; //Nino: perchè non semplicemente jObj.value?
                }

                // caso mcmp, in cui il 2o prm è un JObject altrimenti andrebbe in errore
                if(jObj["value"].GetType() == typeof(JObject)) {
                    Dictionary<string, object> dictFromJObject = new Dictionary<string, object>();
                    // costrusice la dict con le chiavi valori del JObject
                    var obj = (JObject)JsonConvert.DeserializeObject(jObj["value"].ToString());
                    obj.Properties()._forEach(cond => dictFromJObject.Add(cond.Name, ((JValue)cond.Value).Value));
                    // torno la dictionary ben popolata
                    return dictFromJObject;
                }
            }

            //Manca gestione array di costanti
            // va gestito semplicemente come un array di metaexpressions
            if(jObj["array"] != null) {
                return jObj["array"].Select(deserialize).ToArray();
            }

            // altrimenti  itero sulla nuova MetaExpression
            if(jObj["args"] != null && jObj["name"] != null) {
                q m = deserialize((string)jObj["name"], jObj["args"]);
                if(jObj["alias"] != null) {
                    m.Alias = (string)jObj["alias"];
                }

                return m;
            }

            if(jObj.Root != null) {
                throw new ArgumentException("Bad expression: " + jObj.Root.ToString());
            }
            else {
                throw new ArgumentException("Bad expression, unable to deserialize MetaExpression");
            }

        }

        /// <summary>
        /// Delegate used to transform an array of parameters
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public delegate q DeserializeExpression(JArray args);

        private static readonly Dictionary<string, DeserializeExpression> LookupDeserialize =
            new Dictionary<string, DeserializeExpression>() {
                {"constant", getMetaExpressionConst},
                {"eq", getMetaExpressionEq},
                {"field", getMetaExpressionField},
                {"like", getMetaExpressionLike},
                {"add", getMetaExpressionAdd},
                {"sub", getMetaExpressionSub},
                {"div", getMetaExpressionDiv},
                {"mul", getMetaExpressionMul},
                {"not", getMetaExpressionNot},
                {"minus", getMetaExpressionMinus},
                {"bitSet", getMetaExpressionbitSet},
                {"bitClear", getMetaExpressionbitClear},
                {"or", getMetaExpressionOr},
                {"and", getMetaExpressionAnd},
                {"bitwiseAnd", getMetaExpressionbitAnd},
                {"bitwiseOr", getMetaExpressionbitOr},
                {"bitwiseXor", getMetaExpressionbitXor},
                {"ne", getMetaExpressionNe},
                {"gt", getMetaExpressionGt},
                {"ge", getMetaExpressionGe},
                {"lt", getMetaExpressionLt},
                {"le", getMetaExpressionLe},
                {"cmpAs", getMetaExpressioncmpAs},
                {"mcmp", getMetaExpressionmCmp},
                {"isNull", getMetaExpressionisNull},
                {"isNotNull", getMetaExpressionisNotNull},
                {"isNullFn", getMetaExpressionisNullFn},
                {"doPar", getMetaExpressiondoPar},
                {"isIn", getMetaExpressionfieldIn},
                {"isNotIn", getMetaExpressionfieldNotIn},
                {"context", getMetaExpressionContext},
                {"context.sys", getMetaExpressionSys},
                {"context.usr", getMetaExpressionUsr},
            };

        /// <summary>
        /// Deserialize a function- MetaExpression from name and args. 
        /// </summary>
        /// <param name="name">string  name of MetaExpression</param>
        /// <param name="args">JToken with the parameters of the MetaExpression to build</param>
        /// <returns>MetaExpression</returns>
        static q deserialize(string name, JToken args) {
            if(LookupDeserialize.ContainsKey(name))
                return LookupDeserialize[name]((JArray)args);
            return null;
        }

        /// <summary>
        /// Build the "Eq" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for Eq MetaExpresion</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionEq(JArray args) {
            var obj = getNParams("eq", args, 2);
            return q.eq(obj[0], obj[1]);
        }

        /// <summary>
        /// Deserialize parameters for a function
        /// </summary>
        /// <param name="name">Name of the function to which the parameters are applid</param>
        /// <param name="par">Array of parameters</param>
        /// <param name="expected">Expected number of parameters in the array</param>
        /// <returns></returns>
        static object[] getNParams(string name, JArray par, int expected) {
            if(par.Count != expected) {
                throw new ArgumentException($"Function {name} must have {expected} parameters");
            }

            return par.Select(deserialize).ToArray();
        }


        /// <summary>
        /// Deserialize parameters for a function
        /// </summary>
        /// <param name="name">Name of the function to which the parameters are applid</param>
        /// <param name="par">Array of parameters</param>
        /// <param name="expected">Expected minimum number of parameters in the array</param>
        /// <returns></returns>
        static object[] getAtLeastNParams(string name, JArray par, int expected) {
            if(par.Count < expected) {
                throw new ArgumentException($"Function {name} must have at least {expected} parameters");
            }

            return par.Select(deserialize).ToArray();
        }


        /// <summary>
        /// Build the "Like" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for Like MetaExpresion</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionLike(JArray args) {
            var obj = getNParams("like", args, 2);
            return q.like(obj[0], obj[1]);
        }

        /// <summary>
        /// Build the "Field" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for Filed MetaExpresion</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionField(JArray args) {
            var obj = getNParams("field", args, 1);
            return q.field(obj[0].ToString());
        }

        /// <summary>
        /// Build the "Field" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for Filed MetaExpresion</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionConst(JArray args) {
            var obj = getNParams("constant", args, 1);
            return q.constant(obj[0]);
        }


        /// <summary>
        /// Build the "Add" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for Add MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionAdd(JArray args) {
            var pars = getAtLeastNParams("add", args, 2);
            return q.add(pars);
        }

        /// <summary>
        /// Build the "sub" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for sub MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionSub(JArray args) {
            var pars = getNParams("sub", args, 2);
            return q.sub(pars[0], pars[1]);
        }

        /// <summary>
        /// Build the "div" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for div MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionDiv(JArray args) {
            var pars = getNParams("div", args, 2);
            return q.div(pars[0], pars[1]);
        }

        /// <summary>
        /// Build the "mul" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for mul MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionMul(JArray args) {
            var pars = getAtLeastNParams("mul", args, 2);
            return q.mul(pars);
        }

        /// <summary>
        /// Build the "not" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for not MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionNot(JArray args) {
            var pars = getNParams("not", args, 1);
            return q.not(pars[0]);
        }

        /// <summary>
        /// Build the "minus" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for not MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionMinus(JArray args) {
            var pars = getNParams("minus", args, 1);
            return q.minus(pars[0]);
        }

        /// <summary>
        /// Build the "isNull" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for isNull MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionisNull(JArray args) {
            var pars = getNParams("isnull", args, 1);
            return q.isNull(pars[0]);
        }

        /// <summary>
        /// Build the "isNotNull" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for isNotNull MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionisNotNull(JArray args) {
            var pars = getNParams("isNotNull", args, 1);
            return q.isNotNull(pars[0]);
        }

        /// <summary>
        /// Build the "bitSet" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for bitSet MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionbitSet(JArray args) {
            var pars = getNParams("bitSet", args, 2);
            object v = pars[1];
            if(pars[1].GetType().Name == "MetaExpressionConst") {
                q m = (q)pars[1];
                v = m.apply();
                if(v.GetType() != typeof(long) && v.GetType() != typeof(int)) {
                    throw new ArgumentException("Func bitClear() second parameter must be an int");
                }
            }
            else if(pars[1].GetType() != typeof(long) && pars[1].GetType() != typeof(int)) {
                throw new ArgumentException("Func bitSet() second parameter must be an int");
            }

            return q.bitSet(pars[0], Convert.ToInt32(v));
        }

        /// <summary>
        /// Build the "bitClear" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for bitClear MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionbitClear(JArray args) {
            var pars = getNParams("bitClear", args, 2);
            object v = pars[1];
            if(pars[1].GetType().Name == "MetaExpressionConst") {
                q m = (q)pars[1];
                v = m.apply();
                if(v.GetType() != typeof(long) && v.GetType() != typeof(int)) {
                    throw new ArgumentException("Func bitClear() second parameter must be an int");
                }
            }
            else if(pars[1].GetType() != typeof(long) && pars[1].GetType() != typeof(int)) {
                throw new ArgumentException("Func bitClear() second parameter must be an int");
            }

            return q.bitClear(pars[0], Convert.ToInt32(v));
        }

        /// <summary>
        /// Build the "Or" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for Or MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionOr(JArray args) {
            var pars = getAtLeastNParams("or", args, 1);
            if(pars.Length == 1) {
                if(pars[0] is Array) {
                    var arrClause = (object[])pars[0];
                    return q.or(arrClause);
                }
            }

            return q.or(pars);
        }

        /// <summary>
        /// Build the "And" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for And MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionAnd(JArray args) {

            var pars = getAtLeastNParams("and", args, 1);
            if(pars.Length == 1) {

                if(pars[0] is Array) {
                    var arrClause = (object[])pars[0];
                    return q.and(arrClause);
                }

            }

            return q.and(pars);
        }

        /// <summary>
        /// Build the "bitAnd" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for bitAnd MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionbitAnd(JArray args) {
            var pars = getAtLeastNParams("bitAnd", args, 2);
            return q.bitAnd(pars);
        }

        /// <summary>
        /// Build the "bitOr" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for bitOr MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionbitOr(JArray args) {
            var pars = getAtLeastNParams("bitOr", args, 2);
            return q.bitOr(pars);
        }

        /// <summary>
        /// Build the "bitXor" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for bitOr MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionbitXor(JArray args) {
            var pars = getAtLeastNParams("bitXor", args, 2);
            return q.bitXor(pars);
        }

        /// <summary>
        /// Build the "ne" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for ne MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionNe(JArray args) {
            var pars = getNParams("ne", args, 2);
            return q.ne(pars[0], pars[1]);
        }

        /// <summary>
        /// Build the "gt" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for gt MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionGt(JArray args) {
            var pars = getNParams("gt", args, 2);
            return q.gt(pars[0], pars[1]);
        }

        /// <summary>
        /// Build the "ge" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for ge MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionGe(JArray args) {
            var pars = getNParams("ge", args, 2);
            return q.ge(pars[0], pars[1]);
        }

        /// <summary>
        /// Build the "lt" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for lt MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionLt(JArray args) {
            var pars = getNParams("lt", args, 2);
            return q.lt(pars[0], pars[1]);
        }

        /// <summary>
        /// Build the "le" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for le MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionLe(JArray args) {
            var pars = getNParams("le", args, 2);
            return q.le(pars[0], pars[1]);
        }



        /// <summary>
        /// Build the "cmpAs" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for cmpAs MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressioncmpAs(JArray args) {
            var pars = getNParams("cmpAs", args, 3);

            if(pars[1].GetType().Name != "String") {
                throw new ArgumentException("Func cmpAs() second parameter must be a string");
            }

            if(pars[2].GetType().Name != "String") {
                throw new ArgumentException("Func cmpAs() third parameter must be a string");
            }

            return q.cmpAs(pars[0], (string)pars[1], (string)pars[2]);
        }

        /// <summary>
        /// Build the "mCmp" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for mCmp MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionmCmp(JArray args) {
            var pars = getAtLeastNParams("mCmp", args, 2);
            var dict = new Dictionary<string, object>();
            var keys = pars[0] as object[];
            if(keys == null) {
                throw new ArgumentException("Func mCmp() first parameter must be an array");
            }

            // è il caso lato js passi un plain object con coppie "key:val" --> la des mi trasforma quel jObject in un dict
            if(pars[1] is Dictionary<string, object>) {
                dict = (Dictionary<string, object>)pars[1];
            }
            else {
                // altrimenti array di object
                var values = pars[1] as object[];

                if(values == null) {
                    throw new ArgumentException("Func mCmp() second parameter must be an array");
                }

                var valuesDict = new Dictionary<string, object>();
                for(int i = 0; i < keys.Length; i++) {
                    dict[keys[i].ToString()] = values[i];
                }
            }

            var res = q.mCmp(dict, (from k in keys select k.ToString()).ToArray());
            if(pars.Length == 3)
                res.Alias = pars[2].ToString();
            return res;
        }

        /// <summary>
        /// Build the "isNullFn" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for isNullFn MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionisNullFn(JArray args) {
            object[] pars = getNParams("isNullFn", args, 2);
            return q.isNullFn(pars[0], pars[1]);
        }

        /// <summary>
        /// Build the "fieldIn" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for fieldIn MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionfieldIn(JArray args) {
            object[] pars = getAtLeastNParams("fieldIn", args, 2);
            return q.fieldIn(pars[0].ToString(), (Object[])pars[1]);

        }

        /// <summary>
        /// Build the "fieldNotIn" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for fieldNotIn MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionfieldNotIn(JArray args) {
            object[] pars = getAtLeastNParams("fieldNotIn", args, 2);
            return q.fieldNotIn(pars[0].ToString(), (Object[])pars[1]);

        }

        /// <summary>
        /// Build the "doPar" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for doPar MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressiondoPar(JArray args) {
            var obj = getNParams("doPar", args, 1)[0] as q;
            return q.doPar(obj);
        }

        /// <summary>
        /// Build the "sys" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for lt MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionSys(JArray args) {
            var pars = getNParams("sys", args, 1);
            return q.sys(pars[0].ToString());
        }

        /// <summary>
        /// Build the "usr" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for lt MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionUsr(JArray args) {
            var pars = getNParams("usr", args, 1);
            return q.usr(pars[0].ToString());
        }

        /// <summary>
        /// Build the "lt" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for lt MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionContext(JArray args) {
            var pars = getNParams("context", args, 1);
            return q.context(pars[0].ToString());
        }

        /// <summary>
        /// Serializes a MetaExpression
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static JObject serialize(object o) {
            JObject root = new JObject();

            if(o is q) {
                q m = o as q;
                switch(m.Name) {
                    case "field":
                    root.Add("name", m.Name);
                    addAlias(m, root);
                    var fieldArgArray = new JArray(serializeConstant(m.FieldName));
                    root.Add("args", fieldArgArray);
                    break;
                    case "like":
                    root.Add("name", m.Name);
                    addAlias(m, root);
                    root.Add("args", getArgs(m));
                    break;
                    case "const":
                    root.Add("name", "constant");
                    addAlias(m, root);
                    root.Add("args", new JArray(serializeConstant(m.apply())));
                    break;
                    case "mcmp":
                    string[] fields = (string[])q.getField("fields", m);
                    object sample = q.getField("sample", m);
                    var cmpArray = (from field in fields select (object)q.eq(field, q.getField(field, sample)))
                        .ToArray();
                    return serialize(q.and(cmpArray));
                    case "cmpAs":
                    object sourceVal = q.getField("sourceVal", m);
                    string dest = (string)q.getField("dest", m);
                    return serialize(q.eq(dest, sourceVal));
                    case "fieldIn":
                    root.Add("name", "isIn");
                    addAlias(m, root);
                    root.Add("args", getArgsfieldIn(m));
                    break;
                    case "fieldNotIn":
                    root.Add("name", "isNotIn");
                    addAlias(m, root);
                    root.Add("args", getArgsfieldIn(m));
                    break;
                    case "context.sys":
                    root.Add("name", m.Name);
                    addAlias(m, root);
                    root.Add("args", getArgsByEnvName(m));
                    break;
                    case "context.usr":
                    root.Add("name", m.Name);
                    addAlias(m, root);
                    root.Add("args", getArgsByEnvName(m));
                    break;
                    case "context":
                    root.Add("name", m.Name);
                    addAlias(m, root);
                    root.Add("args", getArgsByEnvName(m));
                    break;
                    case "&":
                    root.Add("name", "bitwiseAnd");
                    addAlias(m, root);
                    root.Add("args", getArgs(m));
                    break;
                    case "|":
                    root.Add("name", "bitwiseOr");
                    addAlias(m, root);
                    root.Add("args", getArgs(m));
                    break;
                    case "^":
                    root.Add("name", "bitwiseXor");
                    addAlias(m, root);
                    root.Add("args", getArgs(m));
                    break;
                    case "eq":
                    case "add":
                    case "sub":
                    case "div":
                    case "mul":
                    case "not":
                    case "minus":
                    case "bitSet":
                    case "bitClear":
                    case "or":
                    case "and":
                    case "ne":
                    case "gt":
                    case "ge":
                    case "lt":
                    case "le":
                    case "fromObject":
                    case "isNull":
                    case "isNotNull":
                    case "isNullFn":
                    case "doPar":
                    root.Add("name", m.Name);
                    addAlias(m, root);
                    root.Add("args", getArgs(m));
                    break;
                    case "null":
                    root.Add("value", null);
                    addAlias(m, root);
                    break;
                }

                return root;
            }

            var a = o as Array;
            if(a != null) {
                var arr = new JArray(from object item in a select serialize(item));
                root.Add("array", arr);
                return root;
            }

            root.Add("value", JObject.FromObject(o));
            return root;
        }

        private static void addAlias(q m, JObject root) {
            if(m.Alias != null)
                root.Add("alias", m.Alias);
        }

        private static JArray getArgs(q mExp) {
            var arrayArgs = new JArray();
            foreach(q m in mExp.Parameters) {
                arrayArgs.Add(serialize(m));
            }

            return arrayArgs;
        }

        private static JArray getArgsByEnvName(q mExp) {
            var arrayArgs = new JArray { serializeConstant(q.getField("EnvName", mExp)) };

            return arrayArgs;
        }

        private static JArray getArgsfieldIn(q mExp) {
            var arrayArgs = new JArray { serializeConstant(q.getField("sourceColumn", mExp)) };
            object[] parObject = (object[])q.getField("parObject", mExp);
            foreach(var el in parObject) {
                arrayArgs.Add(serializeConstant(el));
            }

            return arrayArgs;
        }

    }

}

