
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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

namespace HDSGeneVSIX
{


    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("HDSGene", "Generate XML with line count", "1.0")]
    // ReSharper disable once InconsistentNaming
    [ComVisible(true)]
    [Guid("AB4DC117-93D2-4a29-B3B9-24DDB4F9AFAA")]
    [ProvideObject(typeof(HDSGene))]
    [CodeGeneratorRegistration(typeof(HDSGene), "HDSGene", "{FAE04EC1-301F-11D3-BF4B-00C04F79EFBC}", GeneratesDesignTimeSource = true)]
    public class HDSGene /*: BaseCodeGenerator*/
    {
		/**/
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

		/**/


		private bool _someSpecialAdded;

        protected /*override*/ byte[] GenerateCode(string inputFileName, string inputFileContent)
        {

            try
            {
                log("GenerateCode 1");
                return iGenerateCode(inputFileName, inputFileContent);
            }
            catch (Exception e)
            {
                var s = new StringBuilder();
                while (e != null)
                {
                    s.AppendLine("Exception type: " + e.GetType().FullName);
                    s.AppendLine("Message       : " + e.Message);
                    s.AppendLine("Stacktrace:");
                    s.AppendLine(e.StackTrace);
                    s.AppendLine();
                    e = e.InnerException;
                }

                return Encoding.UTF8.GetBytes(s.ToString());

            }
        }

        DataSet getDataSetFromString(string fileContent, string inputFileName)
        {
            log("getDataSetFromString 1");
            var sr = new StringReader(fileContent);
            var d = new DataSet();
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
        public byte[] iGenerateCode(string inputFileName, string inputFileContent) /*da private a public */
        {
            log("iGenerateCode 0");
            var d = getDataSetFromString(inputFileContent, inputFileName);

            _compilazioneConMetaData = false;
            _hdsGenePath = Path.GetDirectoryName(findHDSGeneIniFile(inputFileName));
            var meta = getMetaData(inputFileName);

            getMetaDataList(inputFileName);

            log("inputFileName");

            if (d.DataSetName.ToLower().StartsWith("dsmeta"))
            {
                _compilazioneConMetaData = true;
            }
            var clearDs = clearDataSet(inputFileName, d, (meta == null));

            if (meta == null || _hdsGenePath == null)
            {
                //Trattasi del DataSet di un form
                //Riscrive anche su db l'XSD in modo "pulito" ossia senza le ext.property di MS                
                //restituisce il .cs del dataset da inserire nel progetto del form
                var compiled = compileFormDataSet(clearDs);
                addAllReferences(inputFileName, clearDs);

                return compiled;
            }
            else
            {
                var currProj = getProject(inputFileName);
                if (currProj != null)
                {
                    if (isDataSetLinked(currProj, inputFileName))
                    {
                        var someChange = processProject(currProj, findCsProjFile(inputFileName), inputFileName);
                        //someChange |= fixCustomToolForDataSet(currProj, inputFileName);
                        if (someChange)
                        {
                            writeProject(currProj, inputFileName);
                        }
                    }
                }


                log("inputFileName 2");
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

        private DataSet getMetadataDescriptor(string tableName)
        {
            var meta = tableName;
            log("getMetadataDescriptor 2");
            if (_hdsGenePath == null) return null;
            var dbIniFile = Path.Combine(_hdsGenePath, "HDSGene.db");
            if (!File.Exists(dbIniFile)) return null;
			var connString = File.ReadAllText(dbIniFile);
			//var conn = new SqlConnection(connString);
			var d = new DataSet(meta);
            log("getMetadataDescriptor 3");

			var conn = extConn;

			//using (conn)
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
            log("getMetadataDescriptor 4");
            return d;
        }


        private byte[] compileMetaDataSet(string inputFileName, DataSet d)
        {
            log("compileMetaDataSet 0");
            var meta = getMetaData(inputFileName);
            if (!d.Tables.Contains(meta)) return null;

            var dsInfo = getMetadataDescriptor(meta);


            var T = d.Tables[meta];

            var sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Data;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Runtime.Serialization;");
            if (FileNameSpace != "metadatalibrary")
            {
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

        void getSummary(DataSet dsInfo, StringBuilder sb, string tab)
        {
            log("getSummary 0");
            if (dsInfo == null) return;
            if (dsInfo.Tables["tabledescr"].Rows.Count == 0) return;
            var tableDescrRow = dsInfo.Tables["tabledescr"].Rows[0];
            var descr = tableDescrRow["description"].ToString();
            if (descr == "") return;
            if (tab == null) tab = "";
            tab += "///";
            sb.AppendLine(tab + "<summary>");
            using (var sr = new StringReader(descr))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    sb.AppendLine(tab + line);
                }
            }

            sb.AppendLine(tab + "</summary>");

        }

        void getColumnDescription(string colName, DataSet dsInfo, StringBuilder sb, string tab)
        {
            log("getColumnDescription 0");
            if (dsInfo == null) return;
            if (dsInfo.Tables["coldescr"].Select($"colname='{colName}'").Length == 0) return;
            var rCol = dsInfo.Tables["coldescr"].Select($"colname='{colName}'")[0];
            var descr = rCol["description"].ToString();
            if (descr == "") return;
            if (tab == null) tab = "";
            tab += "///";
            sb.AppendLine(tab + "<summary>");
            using (var sr = new StringReader(descr))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    sb.AppendLine(tab + line);
                }
                var kind = rCol["kind"].ToString().ToUpper();
                if (kind == "C")
                {
                    //Codificato
                    foreach (var r in dsInfo.Tables["colvalue"].Select($"colname='{colName}'"))
                    {
                        sb.AppendLine(tab + $"\t {r["value"]}: {r["title"]}");
                    }
                }
                if (kind == "B")
                {
                    //Bit
                    foreach (var r in dsInfo.Tables["colvalue"].Select($"colname='{colName}'"))
                    {
                        sb.AppendLine(tab + $"\t bit {r["nbit"]}: {r["description"]}");
                    }
                }
            }

            sb.AppendLine(tab + "</summary>");
        }

        private void addTableDefinitionInMeta(DataTable t, StringBuilder sb, DataSet dsInfo)
        {
            log("addTableDefinitionInMeta 0");
            var tName = t.TableName;
            var tableType = getDataTableTypeName(tName);
            var rowType = getDataRowTypeName(tName);


            sb.AppendLine("public class " + rowType + ": MetaRow  {");
            //SB.AppendLine("public " + rowType + "(){}");
            sb.AppendLine("\tpublic " + rowType + "(DataRowBuilder rb) : base(rb) {} ");
            sb.AppendLine();
            sb.AppendLine("\t#region Field Definition");
            foreach (DataColumn c in t.Columns)
            {
                //if (C.ColumnName.StartsWith("!")) continue;
                var sType = c.DataType.ToString();
                if (sType.StartsWith("System.")) sType = sType.Substring(7);
                if (sType != "String" && sType != "Byte[]") sType = sType + "?";

                getColumnDescription(c.ColumnName, dsInfo, sb, "\t");
                sb.AppendLine("\tpublic " + sType + " " + c.ColumnName + "{ ");
                sb.AppendLine(
                    $"\t\tget {{if (this[\"{c.ColumnName}\"]==DBNull.Value)return null; return  ({sType})this[\"{c.ColumnName}\"];}}");
                sb.AppendLine(
                    $"\t\tset {{if (value==null) this[\"{c.ColumnName}\"]= DBNull.Value; else this[\"{c.ColumnName}\"]= value;}}");
                sb.AppendLine("\t}");

                sb.AppendLine($"\tpublic object {c.ColumnName}Value {{ ");
                sb.AppendLine($"\t\tget{{ return this[\"{c.ColumnName}\"];}}");
                sb.AppendLine(
                    $"\t\tset {{if (value==null|| value==DBNull.Value) this[\"{c.ColumnName}\"]= DBNull.Value; else this[\"{c.ColumnName}\"]= value;}}");
                sb.AppendLine("\t}");

                sb.AppendLine($"\tpublic {sType} {c.ColumnName}Original {{ ");
                sb.AppendLine(
                    $"\t\tget {{if (this[\"{c.ColumnName}\",DataRowVersion.Original]==DBNull.Value)return null; return  ({sType})this[\"{c.ColumnName}\",DataRowVersion.Original];}}");
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
            foreach (DataColumn c in t.Columns)
            {
                sb.AppendLine($"\t\t\t{{\"{c.ColumnName}\",createColumn(\"{c.ColumnName}\",typeof({typeName(c.DataType)}),{c.AllowDBNull.ToString().ToLower()},{c.ReadOnly.ToString().ToLower()})}},");
            }
            sb.AppendLine("\t\t};");
            sb.AppendLine("\t}");



            sb.AppendLine("}"); //class

        }

        private static string typeName(Type t)
        {
            if (t == typeof(int)) return "int";
            if (t == typeof(short)) return "short";
            if (t == typeof(string)) return "string";
            if (t == typeof(double)) return "double";
            if (t == typeof(byte)) return "byte";
            if (t == typeof(decimal)) return "decimal";
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (t == typeof(long)) return "long";
            return t.ToString().Substring(7);
        }

        /// <summary>
        /// Genera il codice delle classi necessarie a deserializzare 
        /// l'xml passato come argomento
        /// </summary>
        /// <returns>array di byte che contiene il codice generato</returns>
        private byte[] compileFormDataSet(DataSet d)
        {

            log("compileFormDataSet 0");

            var sb = new StringBuilder();

            sb.AppendLine("using System;");
            sb.AppendLine("using System.Data;");
            sb.AppendLine("using System.ComponentModel;");
            sb.AppendLine("using System.Diagnostics;");
            //SB.AppendLine("using System.Globalization;");
            sb.AppendLine("using System.Runtime.Serialization;");
            sb.AppendLine("#pragma warning disable 1591");
            if (_compilazioneConMetaData)
            {
                var linked = new Dictionary<string, bool>();
                foreach (DataTable t in d.Tables)
                {
                    var tableAlias = t.TableName;      //tableAlias è nome della tabella VERA, ossia del meta e del tipo
                    if (t.ExtendedProperties["TableForReading"] != null &&
                        t.ExtendedProperties["TableForReading"].ToString() != "") tableAlias = t.ExtendedProperties["TableForReading"].ToString();

                    if (_metaDataList.ContainsKey(tableAlias))
                    {
                        if (!linked.ContainsKey(tableAlias))
                        {
                            linked.Add(tableAlias, true);
                            sb.AppendLine("using meta_" + tableAlias + ";");
                            _someSpecialAdded = true;
                        }
                    }
                }
            }

            if (_compilazioneConMetaData)
            {    //
                if (FileNameSpace != "metadatalibrary")
                {
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

        private void beginDataSetDeclaration(DataSet d, StringBuilder sb)
        {
            //SB.AppendLine("[DefaultProperty(\"DataSetName\")]");                                                               
            sb.AppendLine("[Serializable,DesignerCategory(\"code\"),System.Xml.Serialization.XmlSchemaProvider(\"GetTypedDataSetSchema\")]");
            sb.AppendLine($"[System.Xml.Serialization.XmlRoot(\"{d.DataSetName}\"),System.ComponentModel.Design.HelpKeyword(\"vs.data.DataSet\")]");
            sb.AppendLine($"public class { d.DataSetName}: DataSet {{");
        }

        private void addPublicDataTables(DataSet d, StringBuilder sb)
        {
            log("addPublicDataTables 0");
            if (d.Tables.Count > 0)
            {
                sb.AppendLine();
                sb.AppendLine("\t#region Table members declaration");
            }
            foreach (DataTable T in d.Tables)
            {
                var tableAlias = T.TableName;      //tableAlias è nome della tabella VERA, ossia del meta e del tipo
                if (T.ExtendedProperties["TableForReading"] != null
                         && T.ExtendedProperties["TableForReading"].ToString() != ""
                    ) tableAlias = T.ExtendedProperties["TableForReading"].ToString();


                var dsInfo = getMetadataDescriptor(tableAlias);
                getSummary(dsInfo, sb, "\t");
                //SB.AppendLine("[System.CodeDom.Compiler.GeneratedCodeAttribute(\"System.Data.Design.TypedDataSetGenerator\", \"4.0.0.0\")]");
                sb.AppendLine("\t[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]");

                if (isSpecialTable(tableAlias) && _compilazioneConMetaData)
                {
                    var tableTypeName = getDataTableTypeName(tableAlias);
                    //SB.AppendLine($"\tpublic {tableTypeName} {T.TableName} \t\t{{get {{ return ({tableTypeName} )Tables[\"{T.TableName}\"];}}}}");
                    sb.AppendLine($"\tpublic {tableTypeName} {T.TableName} \t\t=> ({tableTypeName})Tables[\"{T.TableName}\"];");

                }
                else
                {
                    sb.AppendLine(_compilazioneConMetaData
                        ? $"\tpublic MetaTable {T.TableName} \t\t=> (MetaTable)Tables[\"{T.TableName}\"];"
                        : $"\tpublic DataTable {T.TableName} \t\t=> Tables[\"{T.TableName}\"];");
                }
                sb.AppendLine();
            }
            if (d.Tables.Count > 0)
            {
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

        private void closeMainDataSetDeclaration(StringBuilder sb)
        {
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
        string findHDSGeneIniFile(string fileName)
        {
            log("findHDSGeneIniFile 0");
            var f = new FileInfo(fileName);
            var dir = f.DirectoryName;
            if (dir == null) return null;
            while (true)
            {
                var found = Directory.GetFiles(dir, "HDSGene.ini"); //file csProj trovati
                if (found.Length > 0) return found[0];
                var d = new DirectoryInfo(dir);
                if (d.Parent == null) return null;
                if (d.Parent == d.Root) return null;
                dir = d.Parent.FullName;
            }


        }

        /// <summary>
        /// Reads metadata List from HDSGene.ini file
        /// </summary>
        /// <param name="someFileName"></param>
        void getMetaDataList(string someFileName)
        {

            log("getMetaDataList 0");
            //log("someFileName is " + someFileName);
            var hdsGeneFileName = findHDSGeneIniFile(someFileName);
            var hdsGenePath = Path.GetDirectoryName(hdsGeneFileName);
            if (hdsGenePath == null) return;
            //log("HDSGenePath is " + HDSGenePath);
            if (hdsGeneFileName == null) return;
            var rd = new StreamReader(hdsGeneFileName);
            var line = rd.ReadLine();
            while (line != null)
            {
                var pieces = line.Split(';');
                if (pieces.Length != 2) continue;
                var path = pieces[1];
                if (path != "*")
                {
                    if (!Directory.Exists(Path.Combine(hdsGenePath, path)))
                    {
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
        void setMetaDataList(string someFileName)
        {
            var hdsGeneFileName = findHDSGeneIniFile(someFileName);
            if (hdsGeneFileName == null) return;
            var wd = new StreamWriter(hdsGeneFileName, false);
            foreach (var tableName in _metaDataList.Keys)
            {
                wd.WriteLine(tableName + ";" + _metaDataList[tableName]);
            }
            wd.Flush();
            wd.Close();
            wd.Dispose();
        }



        void addAllReferences(string inputFileName, DataSet d)
        {
            var iniFilePath = _hdsGenePath;
            if (iniFilePath == null) return;
            var someChange = false;
            var currProj = getProject(inputFileName);
            if (currProj == null) return;
            log("addAllReferences 1");
            if (isDataSetLinked(currProj, inputFileName))
            {
                someChange |= processProject(currProj, findCsProjFile(inputFileName), inputFileName);

                var projFileName = findCsProjFile(inputFileName);
                if (projFileName == null)
                {
                    log("progetto " + inputFileName + " non trovato");
                    return;
                }

                if (_compilazioneConMetaData)
                {
                    var relativeProjFileName = getRelativePath(iniFilePath, Path.GetDirectoryName(projFileName));

                    foreach (DataTable t in d.Tables)
                    {
                        var tableAlias = t.TableName;      //tableAlias è nome della tabella VERA, ossia del meta e del tipo
                        if (t.ExtendedProperties["TableForReading"] != null &&
                            t.ExtendedProperties["TableForReading"].ToString() != "") tableAlias = t.ExtendedProperties["TableForReading"].ToString();
                        someChange |= addReferenceToMetaDataProject(currProj, relativeProjFileName, tableAlias);
                    }
                    someChange |= addSystemReferenceToProject(currProj, "System.Data.DataSetExtensions");
                }

                if (someChange)
                {
                    writeProject(currProj, inputFileName);
                }
            }

        }

        XmlDocument getProject(string someFileName)
        {
            var projFileName = findCsProjFile(someFileName);
            if (projFileName == null)
            {
                return null;
            }
            var projFile = new XmlDocument();
            projFile.Load(projFileName);
            return projFile;
        }

        void log(string s)
        {
            try
            {
                var sw = new StreamWriter("d:\\easy\\hdsgene_log_1.txt", true);
                sw.WriteLine(s);
                sw.Close();
            }
            catch
            {
                // ignored
            }

        }
        void writeProject(XmlDocument projFile, string someFileName)
        {
            var projFileName = findCsProjFile(someFileName);
            if (projFileName == null)
            {
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
        bool addReferenceToMetaDataProject(XmlDocument projFile, string relativeProjFilePath, string metaDataName)
        {
            if (!_metaDataList.ContainsKey(metaDataName)) return false;
            //if (metaDataList[metaDataName] == "*") return false;
            var metaDataProjFilePath = _metaDataList[metaDataName]; //si intende già relativo rispetto ad HDSGene.ini            
            var relativeMetaDataPath = getRelativePath(relativeProjFilePath, metaDataProjFilePath);
            if (metaDataProjFilePath == "*") relativeMetaDataPath = "dll\\";
            return addReferenceToProject(projFile, "meta_" + metaDataName, relativeMetaDataPath, metaDataName);
        }

        bool addSystemReferenceToProject(XmlDocument projFile, string refNameToAdd)
        {
            var project = projFile.DocumentElement;
            var itemGroups = project?.GetElementsByTagName("ItemGroup");
            if (itemGroups == null) return false;
            XmlElement firstGroup = null;
            foreach (XmlElement itemGroup in itemGroups)
            {
                if (firstGroup == null) firstGroup = itemGroup;
                var references = itemGroup.GetElementsByTagName("Reference");
                foreach (XmlElement refFound in references)
                {
                    var refName = getProp(refFound, "Name");
                    if (refName == refNameToAdd) return false;
                    var refInclude = getAttribute(refFound, "Include");
                    if (refInclude == refNameToAdd) return false;
                }
            }

            //Must Add the reference to refNameToAdd  (hintpath refpathToAdd) 
            var doc = firstGroup?.OwnerDocument;
            if (doc == null) return false;
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
            log($"{DateTime.Now.ToFileTime()} Adding {refNameToAdd}");
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
        bool addReferenceToProject(XmlDocument projFile, string refNameToAdd, string refpathToAdd, string meta)
        {
            var project = projFile.DocumentElement;

            //log("refNameToAdd is " + refNameToAdd + " refpathToAdd is " + refpathToAdd);
            var dllPath = _metaDataList[meta] != "*" ? Path.Combine(refpathToAdd, Path.Combine("bin", "Debug")) : refpathToAdd;
            var relativeDllFile = Path.Combine(dllPath, refNameToAdd + ".dll");
            //log("relativeDllFile is " + relativeDllFile);
            var relativeProjFile = Path.Combine(refpathToAdd, refNameToAdd + ".csproj");
            // Scansiona i riferimenti
            var itemGroups = project?.GetElementsByTagName("ItemGroup");
            if (itemGroups == null) return false;
            XmlElement firstGroup = null;
            foreach (XmlElement itemGroup in itemGroups)
            {
                if (firstGroup == null) firstGroup = itemGroup;
                /**
                 *  <ProjectReference Include = "..\..\unmanaged\SituazioneViewer\SituazioneViewer.csproj">
                 *  <Name > SituazioneViewer </Name>
                 *  <Project>{ 42D2BFEA - 1727 - 4039 - A978 - 5D366E5479D3}</ Project>
                    <Private> False </Private>            
                    </ProjectReference>
                 */
                var refProjs = itemGroup.GetElementsByTagName("ProjectReference");
                foreach (XmlElement refFound in refProjs)
                {
                    var refInclude = getAttribute(refFound, "Include");
                    //string refName = getProp(refFound, "Name");
                    if (refInclude == relativeProjFile) return false;
                }

                /**
                * <Reference Include="meta_expense">
                     <SpecificVersion>False</SpecificVersion>
                     <HintPath>..\meta_expense\meta_expense.dll</HintPath>
                     <Private>False</Private>
                   </Reference>
                */
                var references = itemGroup.GetElementsByTagName("Reference");
                foreach (XmlElement refFound in references)
                {
                    var refInclude = getAttribute(refFound, "Include");
                    var hintPath = getProp(refFound, "HintPath");

                    if (hintPath == relativeDllFile) return false;
                    if (refInclude == relativeDllFile) return false;

                    if (refInclude != refNameToAdd) continue;
                    if (refInclude != null)
                    {
                        setProp(refFound, "HintPath", relativeDllFile);
                        log($"Set HintPath to {relativeDllFile}");
                        return true;
                    }



                }
            }

            //Must Add the reference to refNameToAdd  (hintpath refpathToAdd) 
            var doc = firstGroup?.OwnerDocument;
            if (doc == null) return false;
            var uri = firstGroup.NamespaceURI;
            var projReference = doc.CreateElement("Reference", uri);
            projReference.SetAttribute("Include", refNameToAdd);

            log($"Adding Reference Include {refNameToAdd} Hint {relativeDllFile}");

            var hintPathElem = doc.CreateElement("HintPath", uri);
            hintPathElem.InnerText = relativeDllFile;
            projReference.AppendChild(hintPathElem);

            if (_metaDataList[meta] != "*")
            {
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

        private string getRelativePath(string fromPath, string toPath)
        {
            //log($"going from {fromPath} to {toPath}");           
            var fromComponents = fromPath.Split(Path.DirectorySeparatorChar);
            var fromLevel = fromComponents.Length;
            if (fromComponents[fromLevel - 1] == "") fromLevel = fromLevel - 1;
            var toComponents = toPath.Split(Path.DirectorySeparatorChar);
            var toLevel = toComponents.Length;
            if (toComponents[toLevel - 1] == "") toLevel = toLevel - 1;
            //Se la root è diversa, restituisci il path assoluto 
            //if (fromComponents[0].ToLowerInvariant() != toComponents[0].ToLowerInvariant()) return toPath;

            //vede a quale livello occorre risalire prima di ridiscendere
            var i = 0;
            while (i < toLevel && i < fromLevel)
            {
                if (fromComponents[i].ToLowerInvariant() == toComponents[i].ToLowerInvariant())
                {
                    i = i + 1;
                    continue;
                }
                break;
            }
            var commonLevel = i - 1; //il livello comune è i, che è -1 se non c'è livello comune
            var relativePath = "";
            //prima risale n volte da fromLevel a commonLevel
            var currLevel = fromLevel - 1;
            while (currLevel > commonLevel)
            {
                relativePath += "..\\";
                currLevel = currLevel - 1;
            }
            currLevel += 1;
            //poi riscende al path destinazione
            while (currLevel < toLevel)
            {
                relativePath += toComponents[currLevel] + "\\";
                currLevel += 1;
            }
            return relativePath;
        }

        private void addConstructor(DataSet d, StringBuilder sb)
        {
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


        private void addInit(DataSet d, StringBuilder sb)
        {

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


        private string snull(string s)
        {
            if (s == null) return "null";
            return "\"" + s + "\"";
        }

        static bool anySpecialColumn(DataSet d)
        {
            foreach (DataTable t in d.Tables)
            {
                foreach (DataColumn c in t.Columns)
                {
                    if (!c.AllowDBNull) return true;
                    if (c.ReadOnly) return true;
                }
            }
            return false;
        }

        string getDataRowTypeName(string tableName)
        {
            return tableName + "Row";
        }
        string getDataTableTypeName(string tableName)
        {
            return tableName + "Table";
        }





        bool isSpecialTable(string t)
        {
            return _metaDataList.ContainsKey(t);
        }

        private void addDataTables(DataSet d, StringBuilder sb)
        {
            var baseTableClass = _compilazioneConMetaData ? "MetaTable" : "DataTable";
            if (d.Tables.Count > 0)
            {
                sb.AppendLine();
                sb.AppendLine("\t#region create DataTables");
            }
            if (anySpecialColumn(d) && !_compilazioneConMetaData) sb.AppendLine("\tDataColumn C;");
            //if (AnyKey(D))SB.AppendLine("\tDataColumn [] key;");
            foreach (DataTable T in d.Tables)
            {
                var tableAlias = T.TableName;      //tableAlias è nome della tabella VERA, ossia del meta e del tipo
                if (T.ExtendedProperties["TableForReading"] != null
                     && T.ExtendedProperties["TableForReading"].ToString() != ""
                    ) tableAlias = T.ExtendedProperties["TableForReading"].ToString();


                sb.AppendLine("\t//////////////////// " + T.TableName.ToUpper() + " /////////////////////////////////");
                var isSpecial = isSpecialTable(tableAlias);
                string tName;
                if (isSpecial && _compilazioneConMetaData)
                {
                    tName = "t" + T.TableName;
                    sb.AppendLine($"\tvar {tName}= new {getDataTableTypeName(tableAlias)}();");
                    if (T.TableName != tableAlias)
                    {
                        sb.AppendLine($"\t{tName}.TableName = \"{ T.TableName}\";");
                    }
                    var definedCols = "";
                    foreach (DataColumn c in T.Columns)
                    {
                        if (c.ColumnName.StartsWith("!")) continue;
                        if (definedCols != "") definedCols += ",";
                        definedCols += "\"" + c.ColumnName + "\"";
                    }
                    if (definedCols != "")
                    {
                        //invoca il comando per aggiungere tutte le colonne desiderate
                        sb.AppendLine($"\t{tName}.addBaseColumns({definedCols});");
                    }
                }
                else
                {
                    tName = "t" + T.TableName;
                    sb.AppendLine($"\tvar {tName}= new " + baseTableClass + "(" + snull(T.TableName) + ");");
                }

                //SB.AppendLine("\tT.Namespace = this.Namespace;");

                foreach (DataColumn c in T.Columns)
                {
                    if (_compilazioneConMetaData && isSpecial && !c.ColumnName.StartsWith("!"))
                    {
                        //Alle tabelle speciali aggiunge solo le colonne custom
                        continue;
                    }

					bool isReadOnly = c.ReadOnly;
					if (c.ColumnName.StartsWith("!") && c.Expression != null && c.Expression.StartsWith("'") &&
						c.Expression.EndsWith("'")) {
						isReadOnly = false;
					}

					if (_compilazioneConMetaData)
                    {
                        sb.Append($"\t{tName}.defineColumn(\"{c.ColumnName}\", typeof({typeName(c.DataType)})");
                        if (!c.AllowDBNull)
                        {
                            sb.Append(",false");
                            if (c.ReadOnly)
                            {
                                sb.Append(",true");
                            }
                        }
                        else
                        {
                            if (isReadOnly)
                            {
                                sb.Append(",true,true");
                            }
                        }
                        sb.AppendLine(");");
                    }
                    else
                    {
                        if (c.AllowDBNull && !isReadOnly)
                        {
                            sb.AppendLine(
                                $"\t{tName}.Columns.Add( new DataColumn({snull(c.ColumnName)}, typeof({typeName(c.DataType)})));");
                            continue;
                        }
                        sb.AppendLine($"\tC= new DataColumn({snull(c.ColumnName)}, typeof({typeName(c.DataType)}));");
                        if (!c.AllowDBNull) sb.AppendLine("\tC.AllowDBNull=false;");
                        if (isReadOnly) sb.AppendLine("\tC.ReadOnly=true;");
                        sb.AppendLine("\t" + tName + ".Columns.Add(C);");
                    }
                }

				//SB.AppendLine("\tT.Namespace = this.Namespace;");
				foreach (DataColumn c in T.Columns) {
					if (c.ColumnName.StartsWith("!") && c.Expression != null && c.Expression.Trim() != "") {
						sb.AppendLine(
							$"\t{tName}.Columns[\"{c.ColumnName}\"].ExtendedProperties[\"IsTemporaryColumn\"]=\"{c.Expression.Replace("'", "")}\";");
					}
				}

				if (T.ExtendedProperties.Count > 0)
                {
                    foreach (string pName in T.ExtendedProperties.Keys)
                    {
                        var pVal = T.ExtendedProperties[pName];
                        if (pVal != null && pVal.ToString() != ""){
                            sb.AppendLine($"\t{tName}.ExtendedProperties[\"{pName}\"]=\"{pVal}\";");
                        }
                    }
                }
                sb.AppendLine("\tTables.Add(" + tName + ");");
                addKeyDeclaration(T, tName, sb);
                sb.AppendLine();


            }
            if (d.Tables.Count > 0)
            {
                sb.AppendLine("\t#endregion");
                sb.AppendLine();
            }

        }

        private void addKeyDeclaration(DataTable T, string varTableName, StringBuilder sb)
        {
            if (T.PrimaryKey.Length == 0) return;
            string keyCols;
            if (_compilazioneConMetaData)
            {           //isSpecialTable(T.TableName)||
                keyCols = varTableName + ".defineKey(";
                for (var k = 0; k < T.PrimaryKey.Length; k++)
                {
                    if (k > 0)
                    {
                        keyCols += ", ";
                    }
                    keyCols += "\"" + T.PrimaryKey[k].ColumnName + "\"";
                }
                keyCols += ");";
                sb.AppendLine("\t" + keyCols);
                return;
            }

            keyCols = " new DataColumn[]{";
            for (var k = 0; k < T.PrimaryKey.Length; k++)
            {
                if (k > 0)
                {
                    keyCols += ", ";
                }
                keyCols += varTableName + ".Columns[" + snull(T.PrimaryKey[k].ColumnName) + "]";
            }
            keyCols += "}";
            sb.AppendLine("\t" + varTableName + ".PrimaryKey = " + keyCols + ";");
            sb.AppendLine();
        }


        private void addDataRelations(DataSet d, StringBuilder sb)
        {
            if (d.Relations.Count == 0) return;
            sb.AppendLine();
            sb.AppendLine("\t#region DataRelation creation");
            var cParStart = "\tvar cPar";
            var cChildStart = "\tvar cChild";
            foreach (DataRelation r in d.Relations)
            {
                var sameColNames = true;
                for (var i = 0; i < r.ParentColumns.Length; i++)
                {
                    if (r.ParentColumns[i].ColumnName != r.ChildColumns[i].ColumnName) sameColNames = false;
                }
                if (sameColNames && (_someSpecialAdded && _compilazioneConMetaData))
                {
                    var reldef = "\tthis.defineRelation(\"" + r.RelationName + "\",\"" + r.ParentTable.TableName + "\",\"" +
                                r.ChildTable.TableName + "\"";
                    for (var i = 0; i < r.ParentColumns.Length; i++)
                    {
                        reldef += ",\"" + r.ParentColumns[i].ColumnName + "\"";
                    }
                    reldef += ");";
                    sb.AppendLine(reldef);
                    continue;
                }

                sb.Append(cParStart);
                cParStart = "\tcPar";
                sb.Append(" = new []{");
                for (var i = 0; i < r.ParentColumns.Length; i++)
                {
                    if (i > 0) sb.Append(", ");
                    sb.Append(r.ParentTable.TableName + ".Columns[\"" + r.ParentColumns[i].ColumnName + "\"]");
                }
                sb.AppendLine("};");
                sb.Append(cChildStart);
                cChildStart = "\tcChild";
                sb.Append(" = new []{");
                for (var j = 0; j < r.ChildColumns.Length; j++)
                {
                    if (j > 0) sb.Append(", ");
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
        string getMetaData(string dataSetFileName)
        {
            if (dataSetFileName == null) return null;
            var dataSetFile = new FileInfo(dataSetFileName);
            if (dataSetFile.Directory == null) return null;
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
        DataSet clearDataSet(string filename, DataSet d, bool form)
        { //string filename
            //DataSet D = new DataSet();
            //D.ReadXml(filename, XmlReadMode.ReadSchema);

            //Si costruisce un DataSet a partire dal suo xml schema
            var e = new DataSet(d.DataSetName)
            {
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
            foreach (DataTable T in d.Tables)
            {
                var tt = new DataTable(T.TableName);
                foreach (var k in T.ExtendedProperties.Keys)
                {
                    if (k.ToString().StartsWith("Generator_")) continue;       //salta le altre property microsoft
                    tt.ExtendedProperties[k] = T.ExtendedProperties[k];
                }

                e.Tables.Add(tt);
                foreach (DataColumn c in T.Columns)
                {
					//foreach (string cc in c.ExtendedProperties.Keys) log(c.ColumnName + ":" + cc);
					if (c.ExtendedProperties["Expression"] != null) {
						var cc = tt.Columns.Add(c.ColumnName, c.DataType, "'" + c.ExtendedProperties["IsTemporaryColumn"].ToString() + "'");
						cc.AllowDBNull = c.AllowDBNull;
						cc.ReadOnly = cc.ReadOnly;
						continue;
					}
					if (c.ExtendedProperties["IsTemporaryColumn"] != null) {
						var cc = tt.Columns.Add(c.ColumnName, c.DataType, "'" + c.ExtendedProperties["IsTemporaryColumn"].ToString() + "'");
						cc.AllowDBNull = c.AllowDBNull;
						cc.ReadOnly = true;
					} else {
						var cc = tt.Columns.Add(c.ColumnName, c.DataType, c.Expression);
						cc.AllowDBNull = c.AllowDBNull;
						cc.ReadOnly = c.ReadOnly;
					}
				}

                var key = new DataColumn[T.PrimaryKey.Length];
                for (var k = 0; k < key.Length; k++)
                {
                    key[k] = tt.Columns[T.PrimaryKey[k].ColumnName];
                }
                tt.PrimaryKey = key;

            }



            //Relazioni
            foreach (DataRelation r in d.Relations)
            {
                var parenttable = r.ParentTable.TableName;
                var childtable = r.ChildTable.TableName;
                var parent = e.Tables[parenttable];
                var child = e.Tables[childtable];
                var parCol = new DataColumn[r.ParentColumns.Length];
                var childCol = new DataColumn[r.ChildColumns.Length];
                for (var i = 0; i < r.ParentColumns.Length; i++)
                {
                    parCol[i] = parent.Columns[r.ParentColumns[i].ColumnName];
                    childCol[i] = child.Columns[r.ChildColumns[i].ColumnName];
                }
                var rel = new DataRelation(r.RelationName,
                    parCol, childCol, false);  //mettendo true da problemi con la generazione del codice, inizia ad aggiungere
                                               // degli addRange nel .cs del form e crea conflitti       
                foreach (var k in r.ExtendedProperties.Keys)
                {
                    if (k.ToString().StartsWith("Generator_")) continue;       //salta le altre property microsoft
                    rel.ExtendedProperties[k] = r.ExtendedProperties[k];
                }
                e.Relations.Add(rel);

            }




            if (d.GetXmlSchema() != e.GetXmlSchema())
            { //
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

                if (_compilazioneConMetaData && form && elChoice != null)
                {
                    foreach (DataTable t in e.Tables)
                    {
                        foreach (XmlNode elTable in elChoice.ChildNodes)
                        {
                            if (elTable.Attributes?.GetNamedItem("name").Value != t.TableName) continue;
                            foreach (var k in new[] { "TableForReading","TableForPosting",
                                "FilterForSearch","FilterForInsert","AddBlankRow","SkipSecurity"})
                            {
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
        string findCsProjFile(string filename)
        {
            var f = new FileInfo(filename);
            var dir = f.DirectoryName;
            if (dir == null) return null;
            string[] found; //file csProj trovati
            while (true)
            {
                found = Directory.GetFiles(dir, "*.csproj");
                if (found.Length > 0) break;
                var d = new DirectoryInfo(dir);
                if (d.Parent == null) break;
                if (d.Parent == d.Root) break;
                dir = d.Parent.FullName;
            }
            return found.Length == 0 ? null : found[0];
        }

        private static string getProp(XmlElement xEl, string prop)
        {
            if (xEl == null) return null;
            var nn = xEl.GetElementsByTagName(prop);
            return nn.Count == 0 ? null : nn[0].InnerText;
        }

        private static void setProp(XmlElement xEl, string prop, string value)
        {
            if (xEl == null) return;
            var nn = xEl.GetElementsByTagName(prop);
            if (nn.Count == 0)
            {
                var doc = xEl.OwnerDocument;
                var newProp = doc?.CreateElement(prop, xEl.NamespaceURI);
                if (newProp == null) return;
                newProp.InnerText = value;
                xEl.AppendChild(newProp);
                //Console.WriteLine("Created  " + prop + " to " + value);
                return;
            }

            if (nn[0].InnerText != value)
            {
                nn[0].InnerText = value;
            }
        }

        static string getAttribute(XmlElement xEl, string attrName)
        {
            if (xEl == null) return null;
            if (!xEl.HasAttribute(attrName)) return null;
            return xEl.GetAttribute(attrName);
        }

        // ReSharper disable once UnusedMember.Local
        static bool setAttribute(XmlElement xEl, string attrName, string value)
        {
            if (xEl == null) return false;

            if (xEl.HasAttribute(attrName))
            {
                var attr = xEl.GetAttribute(attrName);
                if (attr == value) return false;
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
        bool isDataSetLinked(XmlDocument proj, string datasetName)
        {
            var fds = new FileInfo(datasetName);
            var dsName = fds.Name;

            var ms = new MemoryStream();
            proj.Save(ms);
            ms.Seek(0, SeekOrigin.Begin);
            var sr = new StreamReader(ms);
            var prog = sr.ReadToEnd();
            sr.Close();
            var s1 = prog.IndexOf($"<Content Include=\"{dsName}\">", StringComparison.Ordinal);
            if (s1 >= 0)
            {
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
        private static bool processProject(XmlDocument proj, string projFileName, string datasetName)
        {
           
            var fds = new FileInfo(datasetName);
            var dsName = fds.Name;

            //Estrae la directory dal filename
            var f = new FileInfo(projFileName);
            var dir = f.DirectoryName;
            if (Directory.Exists(dir + "\\Properties"))
            {
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
            if (s1 >= 0)
            {
                var s2 = prog.IndexOf("</Compile>", s1, StringComparison.Ordinal);
                if (s2 > 0)
                {
                    prog = prog.Substring(0, s1) + prog.Substring(s2 + 12);
                    somedone = true;
                }
            }
            s1 = prog.IndexOf($"<Content Include=\"{dsName}\">", StringComparison.Ordinal);
            if (s1 >= 0)
            {
                var s2 = prog.IndexOf("</Content>", s1, StringComparison.Ordinal);
                if (s2 > 0)
                {

                    var tofind = "<Generator>MSDataSetGenerator</Generator>";
                    var s3 = prog.IndexOf(tofind, s1, StringComparison.Ordinal);
                    if (s3 > 0 && s3 < s2)
                    {
                        prog = prog.Substring(0, s3) + "<Generator>HDSGene</Generator>" +
                             prog.Substring(s3 + tofind.Length);
                        somedone = true;
                    }

                }
            }
            s1 = prog.IndexOf($"<None Include=\"{dsName}\">", StringComparison.Ordinal);
            if (s1 >= 0)
            {
                var s2 = prog.IndexOf("</None>", s1, StringComparison.Ordinal);
                if (s2 > 0)
                {

                    var tofind = "<Generator>MSDataSetGenerator</Generator>";
                    var s3 = prog.IndexOf(tofind, s1, StringComparison.Ordinal);
                    if (s3 > 0 && s3 < s2)
                    {
                        prog = prog.Substring(0, s3) + "<Generator>HDSGene</Generator>" +
                             prog.Substring(s3 + tofind.Length);
                        somedone = true;
                    }

                }
            }
            s1 = prog.IndexOf("<None Include=\"Properties\\Settings.settings\">", StringComparison.Ordinal);
            if (s1 >= 0)
            {
                var s2 = prog.IndexOf("</None>", s1, StringComparison.Ordinal);
                if (s2 > 0)
                {
                    prog = prog.Substring(0, s1) + prog.Substring(s2 + 9);
                    somedone = true;
                }
            }
            s1 = prog.IndexOf("<None Include=\"Properties\\Settings.settings\">", StringComparison.Ordinal);
            if (s1 >= 0)
            {
                var s2 = prog.IndexOf("</None>", s1, StringComparison.Ordinal);
                if (s2 > 0)
                {
                    prog = prog.Substring(0, s1) + prog.Substring(s2 + 9);
                    somedone = true;
                }
            }

            if (somedone)
            {
                ms = new MemoryStream();
                var sw = new StreamWriter(ms, Encoding.UTF8);
                sw.Write(prog);
                sw.WriteLine();
                sw.Flush();

                //File.WriteAllText(Path.Combine(FDS.DirectoryName, "tempxml.xml"), prog);
                //SW.Close();

                ms.Seek(0, SeekOrigin.Begin);

                try
                {
                    proj.Load(ms);
                }
                catch (Exception e)
                {
                    throw new Exception($"Errore {e} cercando di leggere l\'xml così formato:\r\n{prog}", e);
                }

            }
            return somedone;
        }


    }

}

