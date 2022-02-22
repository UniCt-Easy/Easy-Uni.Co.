
/*
Easy
Copyright (C) 2022 UniversitÃƒÂ  degli Studi di Catania (www.unict.it)
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


using generaSQL;
using metadatalibrary;
using metaeasylibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Transactions;

namespace Segreterie.Generator {
	public class Program {
		//schema di come i path sono relativi uno all'altro
		//solutionfolder/metadataFolder (nella versione finale coincidono)
		//backendFolder/data
		//clientFolder/metapageFolder
		private static string solutionFolder = "../../../../Segreterie/VisualMDLW/VisualMDLW.Metadata/";  //cartella della solution dei metadati c#		
		private static string backendFolder = "../../../../../progetti/Portale/Backend/"; //cartella del bakend
		private static string clientFolder = "../../../../../progetti/Portale/client/VisualMDLW/"; //cartella del client
		private static string metapageFolder = "metadata/"; //destinazione delle pagine js
		private static string idmenu = "110"; //destinazione delle pagine js
		private static string dllCoreFolder = "../../../../../dll/";
		private static string dllOutputFolder = @"..\..\..\..\Progetti\portale\libraries";
		private static string scriptFolder = "../scripts/VisualMDLW/ScriptSQL/"; //cartella degli script
		private static string testFolder = "../../../../../progetti/Portale/client/test/spec_e2e_app_produzione/VisualMDLW/"; //cartella del client

		//per il generatore di script
		private static string dbipport = "10.10.11.14";//"185.56.8.51,5839";//
		private static string dbipportname = "unibas_easy";
		private static string dipartimento = "amministrazione";
		//per leggere i dati di visualmdlw
		private static string connectionString = "Data Source=" + dbipport + ";Initial Catalog=" + dbipportname + ";Persist Security Info=True;User ID=assistenza;Password=123***********";
		//per hdsgen
		private static string connectionStringAdmin = "data source=" + dbipport + ";initial catalog=" + dbipportname + ";User ID =" + dipartimento + ";Password=**********;Application Name=HDSGene(nino);WorkStation ID =PC-Caprilli;Pooling=false;Connection Timeout=300;";

		private static bool verbose = true;
		private static bool skipView = false; //true per non riscrivere la vista sul db		
		private static bool skipmetapage = false; //true saltare tutto il backend e metapage
		private static bool skipmetapageproject = false; //true per non scrivere sulla solution del backend
		private static bool skipmetapageDataset = false; //true per non scrivere sul dataset del backend		

		private static int applicationID = 2; //1 VisualMDLW, 2 Segreterie, 14 Coan
		private static string currentApp = "";
		private static string currentTitle = "";
		private static string pageId = "";
		private static string clientChildFolder = "";

		private static string queryTempFields =
			@"
					select * into #temp  from (
					SELECT a.idapplicazione,isc.TABLE_NAME, 1 as ord
										from information_schema.columns isc  
										left outer join apppages td on isc.TABLE_NAME = td.tablename 
										left outer join applicazione a on a.idapplicazione = td.idapplicazione
					where a.idapplicazione = {0}
					UNION
					SELECT  a.idapplicazione,isc.TABLE_NAME, 2 as ord
										from information_schema.columns isc  
										left outer join apppages td on isc.TABLE_NAME = td.tablename 
										left outer join applicazione a on a.idapplicazione = td.idapplicazione
					where a.idapplicazione <> {0} or a.idapplicazione is null
					) temp 
					order by ord";

		private static string queryFields =
			@"
					select
					CASE WHEN EXISTS(select TABLE_NAME from information_schema.columns where TABLE_NAME = 
						(
						CASE WHEN CHARINDEX('_', isc.TABLE_NAME) > 0 THEN
						-----------------esteso
						replace(isc.TABLE_NAME,'_','') + 'view'
						-----------------standard
						ELSE isc.TABLE_NAME + (CASE WHEN td.editlistingtype is null or ltrim(rtrim(td.editlistingtype)) = '' THEN 'default' ELSE td.editlistingtype END) + 'view' 
						END)
						)
					THEN 'S' ELSE 'N' 
					END as haveview,
					--VERIFICA VOCABOLARIO EASY
					CASE WHEN NOT EXISTS(select tablename, field, iskey from amministrazione.columntypes c 
										where c.tablename = isc.TABLE_NAME AND c.field = isc.COLUMN_NAME AND c.iskey = 
										CASE WHEN EXISTS(
											SELECT * FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE k
											WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + QUOTENAME(CONSTRAINT_NAME)), 'IsPrimaryKey') = 1
											AND k.TABLE_NAME = isc.TABLE_NAME AND  k.COLUMN_NAME = isc.COLUMN_NAME) 
											THEN 'S' ELSE 'N' END)
					THEN 'N' ELSE 'S' END as isInVoc,
					--TABELLA OGGETTO
					isc.TABLE_NAME as tablename, isnull(td.title, ttd.title) as title, isc.TABLE_SCHEMA as [schema],
					CASE WHEN td.principale = 'N' and not exists(select rl.idapprelation from apprelation rl where rl.idapppages = td.idapppages 
					and isnull(rl.type,'') <> 'unique' and (isnull(rl.type,'') <> 'cerca' or isnull(rl.buttonedit,'S') = 'S' ) ) --relazioni che NON comportano la presenza della subpage
					THEN 'N' ELSE 'S' END AS createmetapage, forcealias, beforefillsinc, istree,
					--CAMPO OGGETTO
					isc.COLUMN_NAME as field, cd.description,
					CASE WHEN EXISTS(
							SELECT * FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE k
							WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + QUOTENAME(CONSTRAINT_NAME)), 'IsPrimaryKey') = 1
							AND k.TABLE_NAME = isc.TABLE_NAME AND  k.COLUMN_NAME = isc.COLUMN_NAME
						) or fd.forcekey = 'S'
					THEN 'S' ELSE 'N' END as iskey,
					isc.DATA_TYPE as sqltype, isnull(isc.CHARACTER_MAXIMUM_LENGTH, isc.NUMERIC_SCALE) as col_len,  
					--TABELLA INTERFACCIA
					td.idapppages, td.principale, isnull(td.editlistingtype,'default') as editlistingtype, td.idmenuweb,
					td.customusing, td.customcode, td.customreference, td.header, td.footer, td.icon, td.vocabolario,
					td.customjavascript, td.staticfilter, td.autosearch, td.isvalid, td.anonimous, 
					CASE WHEN EXISTS (select a.idapppages from apppages a where a.tablename = td.tablename and a.idapplicazione <> td.idapplicazione) 
					THEN 'S' ELSE isnull(td.othersapp, 'N') END AS othersapp,
					td.caninsert, td.caninsertcopy, td.cancancel, td.cansearch, td.cancmdclose, td.cansave, td.canshowlast, 
					td.calendartitle, td.calendarstart, td.calendarstop, td.testcustom, td.additionaltables,
					--TAB 
					t.title as tab, t.position as tabposition, t.icon as tabicon, t.header as tabheader,
					--CAMPO ELENCO
					isnull(fl.position,
						ROW_NUMBER() OVER(PARTITION BY isc.TABLE_NAME,td.editlistingtype ORDER BY CASE 
						WHEN isc.COLUMN_NAME = 'id' + isc.TABLE_NAME THEN 'aaaa' + isc.COLUMN_NAME 
						WHEN isc.COLUMN_NAME = 'title' THEN 'aaa' + isc.COLUMN_NAME 
						WHEN isc.COLUMN_NAME = 'description' THEN 'aa' + isc.COLUMN_NAME 
						WHEN isc.COLUMN_NAME in  ('ct','cu', 'lt', 'lu') THEN 'zz' + isc.COLUMN_NAME 
						ELSE isc.COLUMN_NAME END)) as listposition, 
						CASE WHEN isc.COLUMN_NAME in ('ct','cu', 'lt', 'lu','extension') THEN 'N' ELSE isnull(fl.visible,'S') END as listvisible, 
					isnull(fl.getsorting, CASE WHEN isc.COLUMN_NAME = 'title' THEN 'desc' END)  as getsorting,
					isnull(fl.textfield, CASE 
						WHEN isc.COLUMN_NAME = 'title' THEN 1 
						WHEN isc.COLUMN_NAME = 'description' THEN 2 
						ELSE 0 END) as textfield,
					fl.filter, fl.filterjs,
					fl.summary, fl.textfieldprefix, fl.editable,
					--CAMPO DETTAGLIO
					isnull(fd.position,ROW_NUMBER() OVER(PARTITION BY isc.TABLE_NAME,td.editlistingtype ORDER BY CASE 
						WHEN isc.COLUMN_NAME = 'id' + isc.TABLE_NAME THEN 'aaaa' + isc.COLUMN_NAME 
						WHEN isc.COLUMN_NAME = 'title' THEN 'aaa' + isc.COLUMN_NAME 
						WHEN isc.COLUMN_NAME = 'description' THEN 'aa' + isc.COLUMN_NAME
						WHEN isc.COLUMN_NAME in  ('ct','cu', 'lt', 'lu') THEN 'zz' + isc.COLUMN_NAME 
						ELSE isc.COLUMN_NAME END)) as detailposition, 
						CASE WHEN isc.COLUMN_NAME in ('ct','cu', 'lt', 'lu','extension') THEN 'N' ELSE isnull(fd.visible,'S') END as detailvisible ,
					isnull(fd.isnullable, CASE WHEN isc.IS_NULLABLE = 'YES' THEN 'S' ELSE 'N' END) as allownull,
					CASE WHEN (isnull(fd.isnullable,'S') = 'N' and isc.IS_NULLABLE = 'YES') OR fd.forcekey = 'S' THEN 'S' ELSE 'N' END as denyNull,
					isnull( replace(replace(replace(CASE WHEN isc.DATA_TYPE = 'int' THEN isc.COLUMN_DEFAULT ELSE '""' + isc.COLUMN_DEFAULT + '""' END, '(',''),')',''),'''','')  ,fd.defaultvalue) as defaultvalue,
					fd.radiovalues, fd.islinkingobj, fd.title as alttitle, fd.hidden, fd.listtype, fd.textarea, fd.ischeckbox, 
					fd.text, fd.uniqueonrow, fd.readonlyfield, fd.master, fd.tablefilter, fd.calculatedfieldfunction, fd.testvalue, fd.charnumber, fd.forcedropdown, fd.idappfielddetail,
					fd.afteractivationprefill, fd.afterrowselectprefill, td.testcustomtext, fd.eventtext, fd.eventtype, fd.idappfielddetail_sortmember, fd.specialcontrol, fd.val1, fd.val2, fd.min, fd.max
					from information_schema.columns isc  
					left outer join tabledescr ttd on isc.TABLE_NAME = ttd.tablename 
					left outer join apppages td on isc.TABLE_NAME = td.tablename 
					left outer join applicazione a on a.idapplicazione = td.idapplicazione
					left outer join coldescr cd on isc.TABLE_NAME = cd.tablename and isc.COLUMN_NAME = cd.colname
					left outer join appfielddetail fd on fd.columnname = isc.COLUMN_NAME and fd.idapppages = td.idapppages
					left outer join apptab t on t.idapppages = td.idapppages and t.idapptab = fd.idapptab
					left outer join appfieldlist fl on fl.columnname = isc.COLUMN_NAME and fl.idapppages = td.idapppages ";

		private static string queryFields2 = @"select
					'N' as haveview,'S' as isInVoc,
					--TABELLA OGGETTO
					ttd.tablename, isnull(td.title, ttd.title) as title, 'dbo' as [schema],
					CASE WHEN td.principale = 'N' and not exists(select rl.idapprelation from apprelation rl where rl.idapppages = td.idapppages 
					and isnull(rl.type,'') <> 'unique' and isnull(rl.type,'') <> 'cerca') --relazioni che NON comportano la presenza della subpage
					THEN 'N' ELSE 'S' END AS createmetapage, forcealias, beforefillsinc, istree,
					--CAMPO OGGETTO
					fd.columnname as field, '' as description,
					'N' as iskey,
					isnull(fd.sqltype,'varchar') as sqltype, 
					CASE 
					WHEN fd.sqltype IS NULL OR fd.sqltype = 'varchar' THEN 255 
					WHEN fd.sqltype = 'int' THEN 0 
					WHEN fd.sqltype = 'datetime' THEN NULL 
					WHEN fd.sqltype = 'decimal' THEN 2
					WHEN fd.sqltype = 'char' THEN 1
					END as col_len,  
					--TABELLA INTERFACCIA
					td.idapppages, td.principale, isnull(td.editlistingtype,'default') as editlistingtype, td.idmenuweb,
					td.customusing, td.customcode, td.customreference, td.header, td.footer, td.icon, td.vocabolario,
					td.customjavascript, td.staticfilter, td.autosearch, td.isvalid, td.anonimous, 
					CASE WHEN EXISTS (select a.idapppages from apppages a where a.tablename = td.tablename and a.idapplicazione <> td.idapplicazione) 
					THEN 'S' ELSE isnull(td.othersapp, 'N') END AS othersapp,
					td.caninsert, td.caninsertcopy, td.cancancel, td.cansearch, td.cancmdclose, td.cansave, td.canshowlast, 
					td.calendartitle, td.calendarstart, td.calendarstop, td.testcustom, td.additionaltables,
					--TAB 
					t.title as tab, t.position as tabposition, t.icon as tabicon, t.header as tabheader,
					--CAMPO ELENCO
					fl.position as listposition,
					isnull(fl.visible,'S') as listvisible, 
					fl.getsorting,
					fl.textfield,
					fl.filter, fl.filterjs,
					fl.summary, fl.textfieldprefix, fl.editable,
					--CAMPO DETTAGLIO
					isnull(fd.position,30) as detailposition, 
					isnull(fd.visible,'S') as detailvisible ,
					isnull(fd.isnullable, 'S') as allownull,
					CASE WHEN (isnull(fd.isnullable,'S') = 'N') OR fd.forcekey = 'S' THEN 'S' ELSE 'N' END as denyNull,
					fd.defaultvalue,
					fd.radiovalues, fd.islinkingobj, fd.title as alttitle, fd.hidden, fd.listtype, fd.textarea, fd.ischeckbox, 
					fd.text, fd.uniqueonrow, fd.readonlyfield, fd.master, fd.tablefilter, fd.calculatedfieldfunction, fd.testvalue, fd.charnumber, fd.forcedropdown, fd.idappfielddetail,
					fd.afteractivationprefill, fd.afterrowselectprefill, td.testcustomtext, fd.eventtext, fd.eventtype, fd.idappfielddetail_sortmember, fd.specialcontrol, fd.val1, fd.val2, fd.min, fd.max
					from tabledescr ttd  
					left outer join apppages td on ttd.tablename = td.tablename 
					left outer join applicazione a on a.idapplicazione = td.idapplicazione
					left outer join appfielddetail fd on fd.idapppages = td.idapppages
					left outer join apptab t on t.idapppages = td.idapppages and t.idapptab = fd.idapptab
					left outer join appfieldlist fl on fl.columnname = fd.columnname  and fl.idapppages = td.idapppages ";

		//per marcare i metadati quando vengono utilizzati da piÃƒÂ¹ interfacce per non rigenerarli		
		private static List<string> jsalreadyCreated = new List<string>();
		private static List<string> scriptAlreadyCreated = new List<string>();
		private static TextFileCollection fileContainer = new TextFileCollection();
		private static List<DataRow> appTableRows = new List<DataRow>();

		private static bool partialGeneration = true;
		private static bool rebuildScript = true;
		private static bool rebuildHdsgene = true;
		public static List<Tuple<string, string, string, string, bool, bool>> exceptions = new List<Tuple<string, string, string, string, bool, bool>>();

		public static double executionTime;
		public static DateTime startTime = DateTime.Now;
		public static DateTime startExecTime = new DateTime();
		static void Main(string[] args) {
			Random _random = new Random();
			ConsoleWriter.id = _random.Next(0, int.MaxValue);
			ConsoleWriter.Info("Ora di inizio {0}", startTime.ToString("dd/MM/yyyy HH:mm:ss"));

			if (args.Any()) {
				applicationID = int.Parse(args[0]);
				try { pageId = args[1]; }
				catch (Exception ex) {
					partialGeneration = false;
				}
			}

			using (var connection = new SqlConnection(connectionString)) {

				connection.Open();
				ConsoleWriter.connection = connection;
				var HDSGen = new HDSGeneVSIX.HDSGene();
				HDSGen.extConn = new SqlConnection(connectionStringAdmin);
				HDSGen.extConn.Open();

				var queryApp = @"select * from applicazione where idapplicazione = " + applicationID;

				SqlCommand cmd = new SqlCommand(queryApp, connection);
				var appsDataReader = cmd.ExecuteReader();
				var apps = new DataTable();
				apps.Load(appsDataReader);

				foreach (DataRow r in apps.Rows) {
					solutionFolder = r["metadati"].ToString();
					backendFolder = r["backend"].ToString();
					clientFolder = r["client"].ToString();
					metapageFolder = r["metapagefolder"].ToString();
					dllCoreFolder = r["dllcorefolder"].ToString();
					idmenu = r["idmenuweb"].ToString();
					dllOutputFolder = r["dlloutputfolder"].ToString();

					scriptFolder = r["scriptFolder"].ToString();
					testFolder = r["testFolder"].ToString();
					currentTitle = r["title"].ToString();
					currentApp = Regex.Replace(currentTitle, @"\s", "");
				}

				// Generazione della applicazione se manca
				ApplicationManagement();

				//popolo le eccezioni
				LoadException(connection);

				ConsoleWriter.Info("Calcolo le pagine da eseguire");

				var oldPageList = pageId.Split(',').ToList();
				if (string.IsNullOrEmpty(oldPageList[0])) {
					oldPageList.RemoveAt(0);
					var queryAllPages = "select idapppages from apppages where idapplicazione = " + applicationID;
					var cmdPages = new SqlCommand(queryAllPages, connection);
					cmdPages.CommandTimeout = 1800;
					var dataReaderPages = cmdPages.ExecuteReader();
					var colonnePages = new DataTable();
					colonnePages.Load(dataReaderPages);

					foreach (DataRow r in colonnePages.Rows) {
						oldPageList.Add(r[0].ToString());
					}
				}


				var newPageList = GetNewPageList(oldPageList, connection);
				//filtro finale
				var queryWhere = @" a.idapplicazione = " + applicationID;
				if (!string.IsNullOrEmpty(pageId))
					queryWhere += @" and td.idapppages in (" + string.Join(", ", newPageList) + ")";

				var queryOrderby = "\r\n order by tablename, idapppages, field";

				var queryColonne = queryFields + "\r\n where " + queryWhere + "\r\n UNION \r\n" +
					queryFields2 + "\r\n where fd.columnname like '!%' and " + queryWhere.Replace("isc.TABLE_NAME", "ttd.tablename") + queryOrderby;

				startExecTime = DateTime.Now;
				cmd = new SqlCommand(queryColonne, connection);
				cmd.CommandTimeout = 1800;
				var dataReader = cmd.ExecuteReader();

				var colonne = new DataTable();
				colonne.Load(dataReader);

				executionTime = (DateTime.Now - startExecTime).TotalSeconds;

				ConsoleWriter.Info("Tempo Esecuzione query per il recupero delle pagine da eseguire in secondi {0}:", executionTime.ToString());

				//primo ciclo su tutto per individuare gli oggetti
				var objects = new List<obj>();

				foreach (DataRow r in colonne.Rows) {
					//faccio la distinct degli oggetti
					if (!objects.Any(o => o.Table == r["tablename"].ToString() &&
									 o.EditListingType == (string.IsNullOrEmpty(r["editlistingtype"].ToString()) ? "default" : r["editlistingtype"].ToString())))

						objects.Add(new obj
						{
							Table = r["tablename"].ToString(),
							Title = (r["title"] != null ? r["title"].ToString() : r["tablename"].ToString()),
							EditListingType = string.IsNullOrEmpty(r["editlistingtype"].ToString()) ? "default" : r["editlistingtype"].ToString(),
							PageId = r["idapppages"].ToString(),
							ParentMenuId = r["idmenuweb"].ToString(),
							Principale = r["principale"].ToString() != "N" ? "S" : "N", //di default ÃƒÂ¨ principale
							Using = r["customusing"].ToString(),
							Code = r["customcode"].ToString(),
							Reference = r["customreference"].ToString(),
							Header = r["header"].ToString(),
							Footer = r["footer"].ToString(),
							Icon = r["icon"].ToString(),
							CustomJavascript = r["customjavascript"].ToString(),
							Staticfilter = r["staticfilter"].ToString(),
							CanCancel = r["cancancel"].ToString() != "N" ? "S" : "N", //di default ÃƒÂ¨ si
							CanCmdClose = r["cancmdclose"].ToString() != "N" ? "S" : "N", //di default ÃƒÂ¨ si
							CanInsert = r["caninsert"].ToString() != "N" ? "S" : "N", //di default ÃƒÂ¨ si
							CanInsertCopy = r["caninsertcopy"].ToString() != "N" ? "S" : "N", //di default ÃƒÂ¨ si
							CanSave = r["cansave"].ToString() != "N" ? "S" : "N", //di default ÃƒÂ¨ si
							CanShowLast = r["canshowlast"].ToString() != "N" ? "S" : "N", //di default ÃƒÂ¨ si
							SearchEnabled = r["cansearch"].ToString() != "N" ? "S" : "N", //di default ÃƒÂ¨ si
							OthersApp = r["othersapp"].ToString() == "S", //di default ÃƒÂ¨ no
							IsValid = r["isvalid"].ToString(),
							Anonimous = r["anonimous"].ToString() == "S", //di default ÃƒÂ¨ no
							IsVoc = r["vocabolario"].ToString() == "S", //di default ÃƒÂ¨ no
							Autosearch = r["autosearch"].ToString() == "S", //di default ÃƒÂ¨ no
							Calendartitle = r["calendartitle"].ToString(),
							Calendarstart = r["calendarstart"].ToString(),
							Calendarstop = r["calendarstop"].ToString(),
							Testcustom = r["testcustom"].ToString() == "S", //di default ÃƒÂ¨ no
							TestcustomText = r["testcustomtext"].ToString(),
							AdditionalTables = !string.IsNullOrWhiteSpace(r["additionaltables"].ToString()) ? r["additionaltables"].ToString().Split(',').ToList() : new List<string>(),
							Createmetapage = r["createmetapage"].ToString() == "S",
							BeforeFillSinc = r["beforefillsinc"].ToString(),
							ForceAlias = int.Parse(string.IsNullOrEmpty(r["forcealias"].ToString()) ? "0" : r["forcealias"].ToString()),
							IsTree = r["istree"].ToString() == "S",
						});
				}

				var allfields = new List<field>();

				// --------------------------------TABELLE--------------------------------
				ConsoleWriter.Title("TABELLE");
				var tbls = new List<string>();
				foreach (var o in objects) {
					if (!tbls.Any(t => t == o.Table)) {
						Console.WriteLine(o.Table);
						tbls.Add(o.Table);
					}
				}

				Console.WriteLine("Creo lo script delle regole");

				cmd = new SqlCommand("select t.tablename, r.* from apptablerule r inner join apptable t on r.idapptable = t.idapptable where t.tablename in ('" + string.Join("','", tbls) + "')", connection);
				cmd.CommandTimeout = 1800;
				var drtbls = cmd.ExecuteReader();
				var regole = new DataTable();
				regole.Load(drtbls);

				foreach (DataRow r in regole.Rows) {
					Console.Write(".");
					ReplaceStringInFile(clientFolder + scriptFolder + "zz_GenerateRules.sql", "--rule",
						"exec GenerateRule @table = '" + r["tablename"].ToString() +
							"', @code = '" + r["code"].ToString() +
							"', @message = '" + r["message"].ToString().Replace("'", "''") +
							"', @post = '" + r["post"].ToString() +
							"', @warning = '" + r["warning"].ToString() +
							"', @ins = '" + r["ins"].ToString() +
							"', @upd = '" + r["upd"].ToString() +
							"', @del = '" + r["del"].ToString() +
							"', @sql = '" + r["sql"].ToString().Replace("'", "''") +
							"', @executor = 'rulesGenerator';\r\n--rule");
				}
				Console.WriteLine();

				Console.WriteLine("Carico le informazioni sulla tabelle");
				var queryProtocol = "SELECT * FROM apptable";
				var cmdTable = new SqlCommand(queryProtocol, connection);
				var dataReaderProtocol = cmdTable.ExecuteReader();
				var apptable = new DataTable();
				apptable.Load(dataReaderProtocol);
				appTableRows = apptable.Rows.Cast<DataRow>().ToList();
				Console.WriteLine();

				//-------------------------------------OGGETTI--------------------------------

				ConsoleWriter.Title("OGGETTI");
				foreach (var o in objects) Console.WriteLine(o.Table + " " + o.EditListingType + " " + o.Principale);

				var count = newPageList.Count();
				var curr = 1;
				//per ogni PageId ordinato a partire dalle foglie fino alle pagine principali:
				foreach (var pl in newPageList) {



					var o = objects.Where(ob => ob.PageId == pl).FirstOrDefault();
					if (o != null) {
						//setto la pagina per il logging su DB
						ConsoleWriter.apppages = Convert.ToInt32(pl);

						ConsoleWriter.Title("OGGETTO CORRENTE: " + o.PageId + " " + o.Table + " " + o.EditListingType + " " + curr + " di " + count);
						curr++;
						GetMissingFields(o.Table, null, ref allfields, connection, verbose);

						if (allfields.Any(f => !f.IsInVoc && f.Name != "idapppages_ext")) {
							var errorFields = string.Join(", ", allfields.Where(f => !f.IsInVoc).Select(e => e.Table + "." + e.Name).ToList());
							ConsoleWriter.ErrorDB("Il vocabolario dei dati non ÃƒÂ¨ aggiornato per le seguenti colonne:\r\n" + errorFields);
							continue;
						}

						//Reset di tutti i valori finalizzati ai calcoli del ciclo precedente 
						allfields.ForEach(af => af.MetadatoChild = null);
						allfields.ForEach(af => af.MetadatoExtendedChild = null);
						allfields.ForEach(af => af.ViewAlias = null);
						allfields.ForEach(af => af.IsUniqueField = false);

						var current = o.Table;
						var container = o.Table;

						var objectKey = GetIdByTable(o.Table, allfields, connection, false, o.EditListingType);
						var objectKeyFields = GetIdFieldsByTable(o.Table, allfields, connection, false, o.EditListingType);
						var buttonFields = new List<buttonField>();

						var isLinkingObj = IsLinkingObject(o.Table, ref allfields, connection);
						var isExtendedObjView = IsExtendingObject(current, ref allfields, connection);
						var isNormalObj = !isExtendedObjView && !isLinkingObj;

						var principalkey = isLinkingObj || allfields.Where(f => f.IsLinkingObj && f.ListVisible && f.Table == o.Table && f.EditListingType == o.EditListingType).Any() ?
							null : GetPrincipalKey(o.Table, o.EditListingType, allfields, connection, false);

						var currentTable = o.Table + (o.ForceAlias > 0 && isExtendedObjView ? "_alias" + o.ForceAlias.ToString() : "");
						var extendedObject = "";
						var extendedObjectKey = new List<string>();
						var extendedObjectKeyFields = new List<field>();
						var extendingObject = "";
						var editListingTypes = o.EditListingType;

						//preparo lo script sql-------------------------------------------------------
						if (!Directory.Exists(clientFolder + scriptFolder))
							Directory.CreateDirectory(clientFolder + scriptFolder);
						var scriptFullPath = clientFolder + scriptFolder + o.Table + ".sql";
						WriteSQLScript(scriptFullPath, o.Table, (o.IsVoc || IsEnum(o.Table, allfields)), ref allfields, connection);
						{
							//rieseguo lo script cosÃƒÂ¬ come ÃƒÂ¨ stato calcolato dalle funzioni di easy
							var enc = TextFile.GetEncoding(scriptFullPath);
							var cmdstring = File.ReadAllText(scriptFullPath, enc);
							var cmdiv = new SqlCommand(cmdstring, HDSGen.extConn);
							cmdiv.CommandTimeout = 1800;
							foreach (var cm in cmdstring.Split(new string[] { "GO\r\n" }, StringSplitOptions.RemoveEmptyEntries))
								try {
									var cm2 = cm;
									if (cm.Contains("SET WHERE ")) {
										var expr = Regex.Matches(cm, @"UPDATE(.*?)'\r\nELSE\r\n", RegexOptions.Singleline).Cast<Match>().Select(m => m.Value.Trim()).Distinct().ToList().First();
										cm2 = cm.Replace("IF exists", "IF NOT exists").Replace(expr, "");
										ReplaceStringInFile(scriptFullPath, cm, cm2);
									}

									cmdiv.CommandText = cm2;
									cmdiv.ExecuteNonQuery();
								}
								catch (SqlException e) {

									if (verbose)
										ConsoleWriter.ErrorDB("Errore nello script della vista {0}: {1}", o.PageId, scriptFullPath, e);
								}
						}
						//----------------------------------------------------------------------------

						//se ÃƒÂ¨ un edit type che serve a definire i campi di un oggetto da estendere non genero niente
						var possibleExtendingobj = current + "_" + editListingTypes.Split('_')[0];
						GetMissingFields(possibleExtendingobj, null, ref allfields, connection, false);
						if (!allfields.Any(af => af.Table == possibleExtendingobj)) {

							//caso in cui si tratta di un oggetto estendente
							if (isExtendedObjView) {
								extendedObject = current.Split('_')[0];
								//GetMissingFields(extendedObject, null, ref allfields, connection);
								container = extendedObject;
								extendingObject = current.Split('_')[1];
								current = extendedObject + extendingObject + (editListingTypes == "default" ? "" : "_" + editListingTypes) + "view";
								editListingTypes = GetEditListingTypeForExtended(o.Table, editListingTypes);
								extendedObjectKeyFields.AddRange(GetIdFieldsByTable(extendedObject, allfields, connection, false, editListingTypes));
								extendedObjectKey.AddRange(extendedObjectKeyFields.Select(ek => ek.Name).OrderBy(ek => ek));
								isLinkingObj = IsLinkingObject(extendedObject, ref allfields, connection);
							}

							var mainObject = isExtendedObjView ? extendedObject : o.Table;

							//mi preparo la collection dei campi che mi interessano
							var fields = allfields.Where(af => af.Table == (string.IsNullOrEmpty(extendedObject) ? o.Table : extendedObject) && af.EditListingType == editListingTypes).ToList();
							var subfields = new List<field>();

							//paracadute per quando sono nel caso di oggetto esteso e mi sono scordato di definire i campi con l'edit type  = all'oggetto estendente, allora uso i suoi campi di default
							if (!fields.Any())
								fields.AddRange(allfields.Where(af => af.Table == extendedObject && af.EditListingType == "default"));

							//nel caso di oggetto esteso aggiungo i suoi campi con l'eventuale edit type definito
							if (isExtendedObjView) {
								var editTypeEstendente = "default";

								if (editListingTypes.Split('_').Count() > 1) {
									editTypeEstendente = editListingTypes.Split('_')[1];
								}

								fields.AddRange(allfields.Where(af => af.Table == o.Table && af.EditListingType == editTypeEstendente));
							}

							//ENTITA' FIGLIE ------------------------------------------------------------------------------------------------------------------------------
							var one2one = "";
							var relationFields = GetChildentitiesFields(o.PageId, extendedObject, allfields, connection);
							foreach (var r in relationFields) {
								var metadatoChild = r.Name.Substring(2);
								//verifico che non habbia un alias forzato
								var metadatoChildKey = allfields.Where(af => af.Table == metadatoChild && af.EditListingType == (r.Listtype ?? "defaut") && af.IsKey).First();
								if (metadatoChildKey.ForceAlias > 0)
									metadatoChild += "_alias" + metadatoChildKey.ForceAlias.ToString();
								SetMetadatoChild(fields, r, metadatoChild, ref allfields, connection);

								//ricorsivo su se stesso
								if (fields.Any(f => f.Table == r.MetadatoChild)) {
									r.Name += "_alias1";
									r.MetadatoChild += "_alias1";
								}

								//aggiungo la relazione ai fields
								fields.Add(r);

								//se ÃƒÂ¨ una relazione 1 a 1 ...
								if (r.RelationType == "unique") {

									//... aggiungo i campi alla vista ...
									var uniquefields = new List<field>();
									uniquefields.AddRange(allfields.Where(af => af.Table == metadatoChild && af.EditListingType == (r.Listtype ?? "defaut")
																	 && (af.Detailvisible || !string.IsNullOrEmpty((af.SortData ?? "").Trim()))));

									//ricavo l'ordinamento degi oggetti per scegliere il primo da relazionare 1 a 1
									var sortSubQuery = string.Join(", ", uniquefields.Where(f => !string.IsNullOrEmpty((f.SortData ?? "").Trim()))
																.OrderBy(f => f.SortList).Select(f => f.Table + "." + (string.IsNullOrEmpty(f.ViewAlias) ? f.Name : f.ViewAlias) + " " + f.SortData));
									if (string.IsNullOrWhiteSpace(sortSubQuery))
										ConsoleWriter.ErrorDB("Ho una relazione entitÃƒÂ  (" + o.Table + ") / sub-entitÃƒÂ  (" + metadatoChild + ") uno a uno ma non ho definito un ordinamento per la sub-entitÃƒÂ ");

									//... se sono visibili nella scheda, in quanto mi servono nei search tag
									foreach (var fi in uniquefields.Where(f => f.Detailvisible && !f.Name.StartsWith("!"))) {
										var hadAlias = true;
										//tolgo gli alias ai campi su cui insisterÃƒÂ  una autochoose
										if (HaveKeyName(fi) && (!IsPrincipalKey(fi, o.Table) || isLinkingObj)) {
											var metadatoChild2 = GetTableById(fi.Name, allfields, connection);
											if (!string.IsNullOrEmpty(metadatoChild2)) {
												hadAlias = IsDropdown(fi, metadatoChild2);
											}
										}

										var fieldToSelect = fi.Name;

										if (fi.Type == "char" && fi.Len == 1) {
											var radiovalues = string.IsNullOrEmpty(fi.Radiovalues) ? "S;Si;N;No" : fi.Radiovalues;
											var v = radiovalues.Split(';').ToList();
											fieldToSelect = "CASE ";
											foreach (var rv in v) {
												if (v.IndexOf(rv) % 2 == 0) {
													fieldToSelect += "WHEN " + fi.Table + "." + fi.Name + " = '" + rv + "' ";
												}
												else {
													fieldToSelect += "THEN '" + rv + "' ";
												}
											}
											fieldToSelect += "END AS " + fi.Table + "_" + fi.Name;
										}

										var k = principalkey.Name;
										if ((r.LookupFor ?? "").Split(' ').Count() == 1)
											k = r.LookupFor;

										one2one += @"(select top 1 " + fieldToSelect + @" 
						from " + fi.Schema + "." + fi.Table + @" 
						where " + fi.Schema + "." + fi.Table + @"." + k + @" = " + o.Table + @"." + principalkey.Name + @"
						" + (string.IsNullOrWhiteSpace(sortSubQuery) ? "" : " order by " + sortSubQuery) + ") as " + (hadAlias ? fi.Table + "_" : "") + fi.Name + @",
						";
										//preparo l'alias da mettere nel searchtag
										fi.ViewAlias = fi.Table + "_" + fi.Name;
									}
								}

							}

							//VISTA ------------------------------------------------------------------------------------------------------------------------------

							//verifico se ha un campo testuale di un'altra tabella a cui si riferisce da mostrare negli elenchi (pagina principale) o nelle griglie (pagina figlia) o un campo radio
							// (N.B. Nelle griglie, per quelle si usano i campi calcolati nel dataset di pagina figlia NON si usa la vista quindi NON verrÃƒÂ  creata veramente sul DB) 
							var hasTxtFieldsToShow = fields.Any(f => f.ListVisible && ((HaveKeyName(f) && (!IsPrincipalKey(f, f.Table) || isLinkingObj)) || (f.Type == "char" && f.Len == 1)));

							//se ÃƒÂ¨ un oggetto estendete o non lo ÃƒÂ¨ ma deve mostrare un campo di un'altra tabella nel proprio list type di default
							//devo costruire una vista
							var viewFields = new List<field>();

							//se le griglie o elenchi per questo list type vanno filtrati allora creo una vista
							var hasfilter = fields.Any(f => !string.IsNullOrEmpty(f.Filter));

							//vedo se vi insiste una autochoose che quindi mostrerÃƒÂ  l'elenco
							var hasAutochoose = allfields.Any(af => af.Table != o.Table && af.Name == (principalkey ?? new field()).Name && af.Detailvisible);
							if (!hasAutochoose) {
								// se non emerge dai dati giÃƒÂ  presenti devo verificarlo con una query
								var autochoosequery = "select count(d.idappfielddetail) from appfielddetail d " +
									"							inner join apppages p  on p.idapppages = d.idapppages " +
									"							where d.visible = 'S' and p.tablename <> '" +
												  o.Table + "' and d.columnname = '" + (principalkey ?? new field()).Name + "' and p.idapplicazione = " + applicationID;
								var autochoosecmd = new SqlCommand(autochoosequery, connection);
								autochoosecmd.CommandTimeout = 180;
								var autochooseDataReader = autochoosecmd.ExecuteReader();
								var autochooseDt = new DataTable();
								autochooseDt.Load(autochooseDataReader);
								hasAutochoose = autochooseDt.Rows[0][0].ToString() != "0";
							}

							//verifico se l'autochoose/dropdowngrid mostreranno come valore scelto nel textbox piÃƒÂ¹ di una colonna
							var hasMultipleColumnsOnTextbox = fields.Count(f => f.Textfield > 0) > 1;

							//se si tratta solo di griglie non creo veramente la vista sul DB 
							//(la scrivo solo in caso di elenchi con campi di lookup, oggetti estendenti, filtri, autochoose che mostrano piÃƒÂ¹ colonne nella textbox)
							var createDbView = (hasTxtFieldsToShow && (o.Principale == "S" || hasAutochoose)) || isExtendedObjView || hasfilter || (hasMultipleColumnsOnTextbox && hasAutochoose);

							if (!createDbView && !isLinkingObj && principalkey != null) {
								//se ÃƒÂ¨ collegato da un oggetto di collegamento (non puÃƒÂ² essere a sua volta di collegamento) con il tasto cerca sarÃƒÂ  visualizzato in un elenco, 
								//quindi la vista va creata e siccome si tratta di un calcolo che richiede una query sul db lo faccio solo se sto per NON creare la vista qui
								var fkfields = allfields.Where(af => af.Table != o.Table && af.Name == principalkey.Name && af.ListVisible &&
														(string.IsNullOrEmpty(af.Listtype) ? "default" : af.Listtype) == editListingTypes);
								foreach (var linkingfields in fkfields.Where(af => IsLinkingObject(af.Table, ref allfields, connection))) {
									var relations = GetParentEntitiesFields(linkingfields.PageId, extendedObject, allfields, connection);
									if (relations.Any(r => r.RelationType == "cerca"))
										createDbView = true;
								}
							}

							var viewName = (!string.IsNullOrEmpty(extendedObject) ? extendedObject : current) + editListingTypes + "view";
							var viewFullPath = clientFolder + scriptFolder + "v_" + viewName + ".sql";
							if (createDbView || hasTxtFieldsToShow) {
								Console.WriteLine("0) CREO LA VISTA " + (createDbView ? "SU DB" : ""));
								viewFields = CreateView(
									isExtendedObjView ? extendedObject : current,
									isExtendedObjView ? o.Table : "",
									editListingTypes,
									fields.Where(fi => !fi.Name.StartsWith("XX")).ToList(),
									fields.Where(fi => fi.Name.StartsWith("XX") && fi.ShowInParentGrid > 0).ToList(),
									allfields,
									createDbView,
									isLinkingObj, one2one, o, HDSGen.extConn);

								//preparo lo script sql-------------------------------------------------------
								if (createDbView) {
									try {

										WriteSQLScript(viewFullPath, viewName, (o.IsVoc || IsEnum(o.Table, allfields)), ref allfields, connection);
										var enc = TextFile.GetEncoding(viewFullPath);
										var cmdstring = File.ReadAllText(viewFullPath, enc);

										var cmdiv = new SqlCommand(cmdstring, HDSGen.extConn);
										cmdiv.CommandTimeout = 1800;
										foreach (var cm in cmdstring.Split(new string[] { "GO" }, StringSplitOptions.RemoveEmptyEntries))
											try {
												cmdiv.CommandText = cm;
												cmdiv.ExecuteNonQuery();
											}
											catch (SqlException e) {

												if (verbose)
													ConsoleWriter.ErrorDB("Errore nello script della vista {0}: {1}", o.PageId, viewName, e);
											}
									}
									catch (Exception ex) {
										ConsoleWriter.ErrorDB(o.PageId + " " + ex.Message);

									}
								}

							}
							//SETTO Le primarykey, sortstring, staticfilter sul sql e l'inserimento in weblistredir per i metadati vista----------------------------------------------------------------------------------------
							var sortStringView = "";

							var insertWebListRedir = @"IF exists(SELECT * FROM [web_listredir] WHERE listtype = '" + editListingTypes + "' AND tablename = '" + (isExtendedObjView ? extendedObject : current) + @"')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = '" + editListingTypes + "', newtablename = '" + viewName + "' WHERE listtype = '" + editListingTypes + "' AND tablename = '" + (isExtendedObjView ? extendedObject : current) + @"'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])" +
									 "VALUES('" + (isExtendedObjView ? extendedObject : current) + "', '" + editListingTypes + "', '" + viewName + "', '" + editListingTypes + @"', NULL, NULL, NULL, NULL)
GO";

							var insertMetaDataTable = @"IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = '" + viewName + @"')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('" + viewName + @"')";

							var tableNameForView = (isExtendedObjView ? current : viewName);
							var insertPrimaryKey = @"IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = '" + tableNameForView + @"')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('" + tableNameForView + @"', '""" + string.Join("\",\"", isExtendedObjView ? extendedObjectKey : objectKey) + @"""')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '""" + string.Join("\",\"", isExtendedObjView ? extendedObjectKey : objectKey) + @"""' WHERE [tablename] = '" + tableNameForView + @"'";

							//se ÃƒÂ¨ un oggetto che negli ELENCHI (Principale) deve mostrare campi testuali di altre tabelle a cui si riferisce, devo creare il metadato relativo alla vista ...
							if (createDbView) {

								#region inserimento tabella

								cmd = new SqlCommand(insertMetaDataTable, connection);

								try {
									cmd.ExecuteNonQuery();
									ReplaceStringInFile(clientFolder + scriptFolder + "zz_GenerateMetaData.sql", " --insert metadatamanagedtable", insertMetaDataTable + "\r\nGO" + "\r\n --insert metadatamanagedtable");
								}
								catch (Exception e) {
									ConsoleWriter.ErrorDB(e.Message);
								}
								#endregion

								#region inserimento chiave primaria

								cmd = new SqlCommand(insertPrimaryKey, connection);
								try {
									cmd.ExecuteNonQuery();
									ReplaceStringInFile(clientFolder + scriptFolder + "zz_GenerateMetaData.sql", " --insert metadataprimarykey", insertPrimaryKey + "\r\nGO" + "\r\n --insert metadataprimarykey");
								}
								catch (Exception e) {
									ConsoleWriter.ErrorDB(e.Message);
								}
								#endregion

								#region inserimento sorting
								if (viewFields.Any(f => f.Name == "sortcode") && (!viewFields.Any(item => !string.IsNullOrEmpty(item.SortData) && item.Name != "sortcode"))) {
									var sf = viewFields.Where(f => f.Name == "sortcode").First();
									sortStringView = string.IsNullOrEmpty(sf.ViewAlias) ? sf.Name : sf.ViewAlias;
								}
								else
									sortStringView = string.Join(", ", viewFields.Where(f => f.ListVisible && (f.Table == o.Table || f.Table == extendedObject) && !string.IsNullOrEmpty((f.SortData ?? "").Trim()))
										.OrderBy(f => f.SortList).Select(f => (string.IsNullOrEmpty(f.ViewAlias) ? f.Name : f.ViewAlias) + " " + f.SortData));

								if (!string.IsNullOrEmpty(sortStringView)) {

									var insertSorting = @"IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = '" + viewName + @"' AND [listtype] = '" + editListingTypes + @"')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('" + viewName + @"', '" + editListingTypes + @"', '" + sortStringView + @"')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = '" + sortStringView + @"' WHERE [tablename] = '" + viewName + @"' AND [listtype] = '" + editListingTypes + @"'";

									cmd = new SqlCommand(insertSorting, connection);
									try {
										cmd.ExecuteNonQuery();
										ReplaceStringInFile(clientFolder + scriptFolder + "zz_GenerateMetaData.sql", " --insert metadatasorting", insertSorting + "\r\nGO" + "\r\n --insert metadatasorting");
									}
									catch (Exception e) {
										ConsoleWriter.ErrorDB(e.Message);
									}

								}
								#endregion

								#region inserimento staticfilter
								if (!string.IsNullOrEmpty(o.Staticfilter)) {
									var insertStaticFilter = @"IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = '" + viewName + @"')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('" + viewName + @"', '" + editListingTypes + @"', '" + o.Staticfilter.Replace("'", "''") + @"')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = '" + o.Staticfilter.Replace("'", "''") + @"' WHERE [tablename] = '" + viewName + @"' AND [listtype] = '" + editListingTypes + @"'";

									cmd = new SqlCommand(insertStaticFilter, connection);
									try {
										cmd.ExecuteNonQuery();
										ReplaceStringInFile(clientFolder + scriptFolder + "zz_GenerateMetaData.sql", " --insert metadatastaticfilter", insertStaticFilter + "\r\nGO" + "\r\n --insert metadatastaticfilter");
									}
									catch (Exception e) {
										ConsoleWriter.ErrorDB("Errore inserimento dello static filter. Comando: " + cmd.CommandText + " Errore: " + e.Message);
									}

								}
								#endregion inserimento staticfilter

								#region inserimento weblist_redir

								//-AGGIUNGO LA ENTRY IN web_listredir

								ReplaceStringInFile(clientFolder + scriptFolder + "zz_GenerateWebList_Redir.sql", "--insert", insertWebListRedir + "\r\n --insert");
								cmd = new SqlCommand(insertWebListRedir.EndsWith("GO") ? insertWebListRedir.Substring(0, insertWebListRedir.Length - 2) : insertWebListRedir, connection);
								try {
									cmd.ExecuteNonQuery();
								}
								catch (Exception e) {
									ConsoleWriter.ErrorDB("Errore inserimento in web_listredir. Comando: " + cmd.CommandText + " Errore: " + e.Message);
								}

								#endregion
							}
							else {

								//cancellazione del metadato vista javascript							
								var name = clientFolder + metapageFolder + container + "/meta_" + viewName + ".js";
								if (File.Exists(name)) {
									File.Delete(name);
									ConsoleWriter.InfoDB("Il file del metadato JS {0} non ÃƒÂ¨ piÃƒÂ¹ necessario, ÃƒÂ¨ stato cancellato", name);
								}

								#region cancellazione weblistredir
								//se successivamente vengono resi non visibili tutti i campi esterni, rigenerando la pagina, occorre eliminare la vista
								var delWebListDir = "DELETE web_listredir WHERE newtablename = '" + viewName + "' and listtype = '" + editListingTypes + "'";

								try {

									cmd = new SqlCommand(delWebListDir, connection);
									cmd.ExecuteNonQuery();
									var del = "IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[" + viewName + "]') and OBJECTPROPERTY(id, N'IsView') = 1)\r\n" +
											"DROP VIEW [dbo].[" + viewName + "]";
									cmd = new SqlCommand(del, connection);
									cmd.ExecuteNonQuery();
									del = "IF EXISTS(select * from sysobjects where id = object_id(N'[" + viewName + "]') and OBJECTPROPERTY(id, N'IsView') = 1)\r\n" +
										"DROP VIEW [" + viewName + "]";
									cmd = new SqlCommand(del, connection);
									cmd.ExecuteNonQuery();

								}
								catch (Exception ex) {
									ConsoleWriter.ErrorDB("Errore cancellazione della vista " + viewName + " o del suo record in web_listredir. Comando: " + cmd.CommandText + " Errore: " + ex.Message);
								}

								ConsoleWriter.InfoDB("La vista " + viewName + " non ÃƒÂ¨ necessaria in quanto non risultano chiavi esterne visibili in " + o.Table + " e non estende altri oggetti");

								//aggiorno il file zz_GenerateWebList_Redir.sql con le istruzioni per cancellare la vista

								var deleteScript = @"IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = '" + editListingTypes + @"' AND newtablename = '" + viewName + "')" + "\r\n" + delWebListDir;
								ReplaceStringInFile(clientFolder + scriptFolder + "zz_GenerateWebList_Redir.sql", " --delete", deleteScript + "\r\nGO" + "\r\n --delete");

								//cancello l'inserimento della vista nel file zz_GenerateWebList_Redir.sql
								ReplaceStringInFile(clientFolder + scriptFolder + "zz_GenerateWebList_Redir.sql", insertWebListRedir, string.Empty);

								//elimino il meta dal file indexdebug.html									
								ReplaceStringInFile(clientFolder + "indexdebug.html", "	<script src=\"" + metapageFolder + o.Table + "/meta_" + viewName + ".js\"></script>\r\n"
									, string.Empty);

								#endregion

								#region cancellazione "metadata" table
								var delete = @"IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = '" + viewName + @"')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = '" + viewName + @"'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = '" + viewName + @"'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = '" + viewName + @"'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = '" + viewName + @"'
END";
								cmd = new SqlCommand(delete, connection);
								try {
									cmd.ExecuteNonQuery();
									ReplaceStringInFile(clientFolder + scriptFolder + "zz_GenerateMetaData.sql", " --delete", delete + "\r\nGO" + "\r\n --delete");

									//cancello gli inserimenti delle viste cancellate nel file zz_GenerateMetaData.sql
									ReplaceStringInFile(clientFolder + scriptFolder + "zz_GenerateMetaData.sql", insertMetaDataTable, string.Empty);
									ReplaceStringInFile(clientFolder + scriptFolder + "zz_GenerateMetaData.sql", insertPrimaryKey, string.Empty);
									//	ReplaceStringInFile(clientFolder + scriptFolder + "zz_GenerateMetaData.sql", insertSorting, string.Empty); TODO:Sostituire insertSorting con una regex
									//  ReplaceStringInFile(clientFolder + scriptFolder + "zz_GenerateMetaData.sql", insertStaticFilter, string.Empty); TODO: Sostituire insertStaticFilter con una regex								

								}
								catch (Exception e) {
									ConsoleWriter.ErrorDB("Errore cancellazione tabelle dei metadati oer la vista " + viewName + " . Comando: " + cmd.CommandText + " Errore: " + e.Message);
								}
								#endregion

								#region aggiornamento dello script della vista (viene lasciato solo il drop view)
								if (File.Exists(viewFullPath)) {
									var viewText = File.ReadAllText(viewFullPath);
									if (viewText.IndexOf("\r\nCREATE VIEW") > 0) {
										viewText = viewText.Substring(viewText.IndexOf("\r\nCREATE VIEW"), viewText.Length - viewText.IndexOf("\r\nCREATE VIEW"));
										ReplaceStringInFile(viewFullPath, viewText, string.Empty);
									}
								}
								var fileDbo = viewFullPath.Replace("ScriptSQL", "ScriptLU").Replace(".sql", ".dbo.sql");
								var fileNdbo = viewFullPath.Replace("ScriptSQL", "ScriptLU").Replace(".sql", ".ndbo.sql");
								var fileVocdbo = viewFullPath.Replace("ScriptSQL", "ScriptLU").Replace(".sql", ".vocdbo.sql");
								var fileVocNdbo = viewFullPath.Replace("ScriptSQL", "ScriptLU").Replace(".sql", ".vocndbo.sql");

								if (File.Exists(fileDbo)) {
									var viewText = File.ReadAllText(fileDbo);
									if (viewText.IndexOf("\r\nCREATE VIEW") > 0) {
										viewText = viewText.Substring(viewText.IndexOf("\r\nCREATE VIEW"), viewText.Length - viewText.IndexOf("\r\nCREATE VIEW"));
										ReplaceStringInFile(fileDbo, viewText, string.Empty);
									}
								}
								if (File.Exists(fileNdbo)) {
									var viewText = File.ReadAllText(fileNdbo);
									if (viewText.IndexOf("\r\nCREATE VIEW") > 0) {
										viewText = viewText.Substring(viewText.IndexOf("\r\nCREATE VIEW"), viewText.Length - viewText.IndexOf("\r\nCREATE VIEW"));
										ReplaceStringInFile(fileNdbo, viewText, string.Empty);
									}
								}
								if (File.Exists(fileVocNdbo)) {
									var viewText = File.ReadAllText(fileVocNdbo);
									var newviewText = "DELETE columntypes WHERE tablename = '" + viewName + "'\r\nGO\r\n" +
										"DELETE customobject where objectname = '" + viewName + "'\r\nGO\r\n";
									ReplaceStringInFile(fileVocNdbo, viewText, newviewText);
								}
								//if (File.Exists(fileVocdbo))


								#endregion

								viewName = "";
							}


							//BOTTONI ------------------------------------------------------------------------------------------------------------------------------
							var queryButtons = @"	SELECT b.idapppagesbutton, b.name, b.title, b.code, b.parameter, b.idapppages, b.idapptab, b.icon, 
											t.title as tabtitle, b.refresh, b.javascript, b.position, b.storeprocedure
											FROM apppagesbutton b
											left outer join apptab t on b.idapptab = t.idapptab 
											where b.idapppages = " + o.PageId;
							var cmdButtons = new SqlCommand(queryButtons, connection);
							var dataReaderButtons = cmdButtons.ExecuteReader();
							var buttons = new DataTable();
							buttons.Load(dataReaderButtons);
							foreach (DataRow button in buttons.Rows) {
								var tabtitle = string.IsNullOrEmpty(button["tabtitle"].ToString()) ? "Principale" : button["tabtitle"].ToString();

								buttonFields.Add(new buttonField
								{
									Title = button["title"].ToString(),
									Name = string.IsNullOrEmpty(button["name"].ToString()) ? button["title"].ToString().Replace(" ", "") : button["name"].ToString(),
									Code = button["code"].ToString(),
									Parameter = button["parameter"].ToString(),
									Icon = button["icon"].ToString(),
									Refresh = button["refresh"].ToString(),
									Javascript = button["javascript"].ToString(),
									Tab = tabtitle,
									StoreProcedure = button["storeprocedure"].ToString(),
									Position = button["position"].ToString(),
								});

								if (!String.IsNullOrEmpty(button["storeprocedure"].ToString())) {
									ConsoleWriter.OK("Genero la store procedure associata al bottone {0} ", button["title"]);
									CreateSP(button["storeprocedure"].ToString(), HDSGen.extConn);
								}

							}

							//recupero i dati riguardanti la tabella
							var customGetNewRow = string.Empty;
							var currentAppTable = appTableRows.Where(r => r["tablename"].ToString() == currentTable.Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[0]).FirstOrDefault();
							if (currentAppTable != null) {
								customGetNewRow = currentAppTable["customgetnewrow"].ToString();
								//aggiungo il bottone per la protocollazione se serve
								if (fields.Any(f => f.Name == "protnumero") && fields.Any(f => f.Name == "protanno")) {
									//recupero gli script del protocollo
									var javascript = "firebtnProtocol: function (that) {\r\n";
									javascript += currentAppTable["protocol"].ToString().Replace(currentTable.Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[0], currentTable);
									javascript += "\r\n";
									javascript += "\t\t\t\treturn that.assegnaProtocollo(idreg_origine, idreg_destinazione, idprotocollodockind, oggetto, codiceregistro, arrayTablesToProtocol);\r\n\t\t\t}";

									buttonFields.Add(new buttonField
									{
										Title = "Protocolla",
										Name = "btnProtocol",
										Code = "",
										Parameter = "",
										Icon = "fa-stamp",
										Refresh = "",
										Javascript = javascript,
										Tab = "Principale",
										StoreProcedure = "",
										Position = "D"
									});

								}

							}

							//ENTITA' MADRI------------------------------------------------------------------------------------------------------------------------------

							var parentEntities = GetParentEntitiesFields(o.PageId, extendedObject, allfields, connection);

							//CAMPI DA MOSTRARE NEGLI ELENCHI (senza redir) O NELLE GRIGLIE -----------------------------------------------------------------------------

							//aggiungo campi normali

							var describeColumnsFileds = fields.Where(f => f.ListVisible && f.Table == o.Table).ToList();
							//aggiungo campi di lookup per ELENCHI (pagine principali) e GRIGLIE (pagine figlie)
							describeColumnsFileds.AddRange(viewFields.Where(vf => describeColumnsFileds.Select(dcf => dcf.Name).Contains(vf.LookupFor)));
							//rimuovo gli id che hanno un lookup
							foreach (var toRemove in describeColumnsFileds.Where(idf => idf.LookupFor == null && describeColumnsFileds.Select(dcf => dcf.LookupFor).Contains(idf.Name)).ToList())
								describeColumnsFileds.Remove(toRemove);

							var describeColumnsFiledsExt = new List<field>();
							if (isExtendedObjView) {
								//aggiungo campi normali
								describeColumnsFiledsExt = fields.Where(f => f.ListVisible && f.Table == extendedObject).ToList();
								//aggiungo campi di lookup per ELENCHI (pagine principali) e GRIGLIE (pagine figlie)
								describeColumnsFiledsExt.AddRange(viewFields.Where(vf => describeColumnsFiledsExt.Select(dcf => dcf.Name).Contains(vf.LookupFor)));
								//rimuovo gli id che hanno un lookup
								foreach (var toRemove in describeColumnsFiledsExt.Where(idf => idf.LookupFor == null && describeColumnsFiledsExt.Select(dcf => dcf.LookupFor).Contains(idf.Name)).ToList())
									describeColumnsFiledsExt.Remove(toRemove);
							}




							if (!skipmetapage) {
								#region BACKEND E CLIENT
								Console.WriteLine("2) --------------GENERAZIONE DELLA METAPAGE-------------------");

								if (!skipmetapageproject) {
									Console.WriteLine("2.1) MODIFICO IL PROJECT BACKEND");
									var BackendTxt = TextFile.ReadAllTextFile(backendFolder + "Backend.csproj");

									//-aggiungo i file del dataset al project beckend
									var datasetname = "dsmeta_" + (!string.IsNullOrEmpty(extendingObject) ? extendedObject : o.Table) + "_" + editListingTypes;

									if (o.Createmetapage)
										if (!BackendTxt.Contains(datasetname + ".xsc")) {
											var datasetstring =
										 "  <ItemGroup>\r\n" +
										 "    <Content Include=\"Data\\" + datasetname + ".xsc\">\r\n" +
										 "      <DependentUpon>" + datasetname + ".xsd</DependentUpon>\r\n" +
										 "    </Content> \r\n" +
										 "    <None Include=\"Data\\" + datasetname + ".xsd\">\r\n" +
										 "      <Generator>HDSGene</Generator>\r\n" +
										 "      <LastGenOutput>" + datasetname + ".cs</LastGenOutput>\r\n" +
										 "      <SubType>Designer</SubType>\r\n" +
										 "    </None>\r\n" +
										 "    <Content Include=\"Data\\" + datasetname + ".xss\">\r\n" +
										 "      <DependentUpon>" + datasetname + ".xsd</DependentUpon>\r\n" +
										 "    </Content>\r\n" +
										 "    <Content";
											ReplaceStringInFile(backendFolder + "Backend.csproj", "  <ItemGroup>\r\n    <Content", datasetstring);

											var datasetcompilestring =
										 "  <ItemGroup>\r\n" +
										 "    <Compile Include=\"Data\\" + datasetname + ".cs\">\r\n" +
										 "      <DependentUpon>" + datasetname + ".xsd</DependentUpon>\r\n" +
										 "      <AutoGen>True</AutoGen>\r\n" +
										 "      <DesignTime>True</DesignTime>\r\n" +
										 "    </Compile>\r\n" +
										 "    <Compile";
											ReplaceStringInFile(backendFolder + "Backend.csproj", "  <ItemGroup>\r\n    <Compile", datasetcompilestring);
										}
								}

								Console.WriteLine("2.2) PREPARO LA CARTELLA E LA VOCE DI MENU'");

								//-creo la cartella contenitore della pagina
								if (!Directory.Exists(clientFolder + metapageFolder + container))
									Directory.CreateDirectory(clientFolder + metapageFolder + container);

								//-creo la voce di menÃƒÂ¹ se ÃƒÂ¨ una pagina principale /*e che non derivi da un bottone*/
								if (o.Principale != "N" /*&& !parentEntities.Any(pe => pe.RelationType == "button")*/) {
									cmd = new SqlCommand("menuweb_addentry", connection);
									cmd.CommandType = CommandType.StoredProcedure;
									cmd.Parameters.AddWithValue("@idmenuwebparent", string.IsNullOrEmpty(o.ParentMenuId) ? idmenu : o.ParentMenuId);
									cmd.Parameters.AddWithValue("@idx", DBNull.Value);
									cmd.Parameters.AddWithValue("@tableName", !string.IsNullOrEmpty(extendingObject) ? extendedObject : o.Table);
									cmd.Parameters.AddWithValue("@editType", editListingTypes);
									cmd.Parameters.AddWithValue("@label", o.Title.Replace("'", "''"));
									var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
									returnParameter.Direction = ParameterDirection.ReturnValue;
									cmd.ExecuteNonQuery();

									ReplaceStringInFile(clientFolder + scriptFolder + "zz_GenerateMenu.sql", "--menu",
									   "exec menuweb_addentry @idmenuwebparent = " + (string.IsNullOrEmpty(o.ParentMenuId) ? idmenu : o.ParentMenuId) +
									   ", @idx = " + returnParameter.Value.ToString() +
									   ", @tableName = '" + (!string.IsNullOrEmpty(extendingObject) ? extendedObject : o.Table) +
									   "', @editType = '" + editListingTypes +
									   "', @label = '" + o.Title + "';\r\n--menu");
								}

								Console.WriteLine("2.3) CREO IL METADATO JS NORMALE O ESTENDENTE");
								var fullPathMetaDatoJS = clientFolder + metapageFolder + container + "/meta_" + o.Table + ".js";
								SetMetadatoJs(fullPathMetaDatoJS, container, o.Table, currentApp, objectKeyFields, isExtendedObjView, allfields, connection, customGetNewRow);

								//se ÃƒÂ¨ un oggetto che negli ELENCHI (Principale o autochoose) deve mostrare campi testuali di altre tabelle a cui si riferisce 
								//devo creare il metadato relativo alla vista solo se non ÃƒÂ¨ un oggetto esteso o di collegamento
								var viewObjectFileJS = "";
								if (createDbView && !isExtendedObjView) {
									viewObjectFileJS = clientFolder + metapageFolder + container + "/meta_" + viewName + ".js";
									SetMetadatoJs(viewObjectFileJS, container, viewName, currentApp, objectKeyFields, false, allfields, connection);
								}

								var fullPathMetaDatoExtendedJS = clientFolder + metapageFolder + container + "/meta_" + extendedObject + ".js";
								if (!string.IsNullOrEmpty(extendedObject)) {
									Console.WriteLine("2.4) CREO IL METADATO ESTESO");
									SetMetadatoJs(fullPathMetaDatoExtendedJS, container, extendedObject, currentApp, extendedObjectKeyFields, false, allfields, connection);

									viewObjectFileJS = clientFolder + metapageFolder + container + "/meta_" + viewName + ".js";
									SetMetadatoJs(viewObjectFileJS, container, viewName, currentApp, extendedObjectKeyFields, false, allfields, connection);

									//SETCAPIONS -------------------begin
									var setCaptionsExt = new List<string>();
									foreach (var f in fields.Where(fi => fi.Table == extendedObject && fi.IsAltTitle == "S")) {
										setCaptionsExt.Add("\t\t\t\t\t\ttable.columns[\"" + f.Name + "\"].caption = \"" + f.Title + "\";\r\n");
									}
									if (setCaptionsExt.Any())
										SetCaptionOnJS(fullPathMetaDatoExtendedJS, editListingTypes, setCaptionsExt);

								}

								var setCaptions = new List<string>();
								foreach (var f in fields.Where(fi => fi.Table == o.Table && fi.IsAltTitle == "S")) {
									setCaptions.Add("\t\t\t\t\t\ttable.columns[\"" + f.Name + "\"].caption = \"" + f.Title + "\";\r\n");
								}
								if (setCaptions.Any())
									SetCaptionOnJS(fullPathMetaDatoJS, editListingTypes, setCaptions);
								//SETCAPIONS -------------------begin

								//DESCRIBECOLUMNS -------------------begin

								//preparo prima il describecolumn STANDARD per il metaoggetto NORMALE
								var describeColumns = new List<string>();
								foreach (var f in describeColumnsFileds.Where(f => f.ListVisible).OrderBy(f => f.SortList)) {
									//devo controllare se il campo ÃƒÂ¨ di lookup ma a sua volta ÃƒÂ¨ ina foreign key per un'altra tabella
									//e non sia un enum (chiave e testo uguali)
									if (f.LookupFor != null && HaveKeyName(f) && !IsEnum(f, allfields, connection)) {
										//N.B. i campi calcolati li aggiunge la preparazione del dataset della pagina che li mostra in griglia, quindi MAI qui

										////devo valutare che questa foreign key che fa da lookup per un campo potrebbe produrre anche piÃƒÂ¹ di un campo testuale di lookup
										//var secondaryTableText = GetTableById(f.Name, allfields, connection);
										//var textFields = GetTextFieldByTable(secondaryTableText, allfields, connection, false);
										//foreach (var tf in textFields)
										//{
										//	var colName = (f.LookupFor == null ? f.Name : "!" + f.LookupFor + "_" + f.LookupTable + "_" + tf.Name);
										//	describeColumns.Add(GetFormatDescribeColumnJS(f, colName));

										//	ReplaceStringInFile(clientFolder + "assets/i18n/LocalResourceIt.js", "// colonne\r\n", "// colonne\r\n" + "		" +
										//		(colName.Contains("!") ? "\"" : "") + "grid_" + f.Table + "_" + f.EditListingType + "_" + colName + (colName.Contains("!") ? "\"" : "") +
										//		": \"" + f.Title.Replace("'", "\\'") + "\",\r\n");
										//}

									}
									else {
										//altrimenti se ÃƒÂ¨ un campo normale o un lookup semplice

										//N.B. i campi calcolati li aggiunge la preparazione del dataset della pagina che li mostra in griglia, quindi MAI qui
										if (f.LookupFor == null) {
											var colName = (f.LookupFor == null ? f.Name : "!" + f.LookupFor + "_" + f.LookupTable + "_" + f.Name);
											describeColumns.Add(GetFormatDescribeColumnJS(f, colName));

											ReplaceStringInLocalResourceFile(RegionMarker.LocalResource_colonne, (colName.Contains("!") ? "\"" : "") + "grid_" + f.Table + "_" + f.EditListingType, "_" + colName + (colName.Contains("!") ? "\"" : ""),
											f.Title.Replace("'", "\\'"));

										}
									}
								}

								//preparo il describecolumn derivato dalla vista da usare per gli oggetti derivati o quelli che negli ELENCHI (pagine principali) devono mostrare campi testuali di altre tabelle
								var describeColumnsView = new List<string>();
								if (viewFields.Any() && createDbView) {
									//aggiungo i campi testuali calcolati al momento della creazione della vista
									//N.B. non ordinare per tabella perchÃƒÂ¨ ci sono nel mezzo i campi di lookup
									foreach (var tf in viewFields.Where(f => f.ListVisible).OrderBy(f => f.SortList)) {
										var colName = string.IsNullOrEmpty(tf.ViewAlias) ? tf.Name : tf.ViewAlias;
										describeColumnsView.Add(GetFormatDescribeColumnJS(tf, colName));

										//aggiungo l'etichetta per la label delle colonne
										ReplaceStringInLocalResourceFile(RegionMarker.LocalResource_colonne, "grid_" + tf.Table + "_" + tf.EditListingType, "_" + colName,
										 tf.Title.Replace("'", "\\'"));

									}
								}

								if (isExtendedObjView) {

									//preparo prima il describecolumn da usare per il metadato esteso  (GRIGLIE su ESTESO con list type estendente)
									var describeColumnsExt = new List<string>();
									foreach (var f in describeColumnsFiledsExt.Where(f => f.ListVisible).OrderBy(f => f.SortList)) {
										//devo controllare se il campo ÃƒÂ¨ di lookup ma a sua volta ÃƒÂ¨ ina foreign key per un'altra tabella
										//e non sia un enum (chiave e testo uguali)
										if (f.LookupFor != null && HaveKeyName(f) && !IsEnum(f, allfields, connection)) {
											//N.B. i campi calcolati li aggiunge la preparazione del dataset della pagina che li mostra in griglia, quindi MAI qui
										}
										else {
											//altrimenti se ÃƒÂ¨ un campo normale o un lookup semplice

											//N.B. i campi calcolati li aggiunge la preparazione del dataset della pagina che li mostra in griglia, quindi MAI qui
											if (f.LookupFor == null) {
												var colName = (f.LookupFor == null ? f.Name : "!" + f.LookupFor + "_" + f.LookupTable + "_" + f.Name);
												describeColumnsExt.Add(GetFormatDescribeColumnJS(f, colName));

												ReplaceStringInLocalResourceFile(RegionMarker.LocalResource_colonne, (colName.Contains("!") ? "\"" : "") + "grid_" + f.Table + "_" + f.EditListingType, "_" + colName + (colName.Contains("!") ? "\"" : ""),
											 f.Title.Replace("'", "\\'"));
											}
										}
									}

									//aggiungo il describecolumn al metadato esteso  (GRIGLIE su ESTESO con list type estendente)
									if (describeColumnsExt.Any())
										SetDescribeColumnsOnJS(fullPathMetaDatoExtendedJS, editListingTypes, describeColumnsExt, true);
									else
										SetDescribeColumnsOnJS(fullPathMetaDatoExtendedJS, editListingTypes,
											new List<string>() { "\t\t\t\t\t\treturn this.superClass.describeColumns(table, listType);\r\n" }, true);

									//aggiungo il describecolumns al metadato meta_EstesoEstendenteListtypeView (ELENCHI o autochoose o "griglie cerca" su ESTESO con list type estendente)
									if (describeColumnsView.Any())
										SetDescribeColumnsOnJS(viewObjectFileJS, editListingTypes, describeColumnsView, true);

									//aggiungo il describecolumn al metadato estendente recuperando il listing type preso all'inizio (GRIGLIE su ESTENDENTE)
									//N.B. NON dovrei MAI fare griglie sull'estendete ma sull'esteso con edit type estendente
									if (describeColumnsFileds.Any())
										SetDescribeColumnsOnJS(fullPathMetaDatoJS, fields.Where(f => f.Table == extendedObject).First().EditListingType, describeColumns, true);
									else
										SetDescribeColumnsOnJS(fullPathMetaDatoJS, editListingTypes,
											new List<string>() { "\t\t\t\t\t\treturn this.superClass.describeColumns(table, listType);\r\n" }, true);
								}
								else {
									if (describeColumnsView.Any())
										//aggiungo il describe columns all'oggetto vista di un oggetto normale (ELENCHI o autochoose o "griglie cerca")
										SetDescribeColumnsOnJS(viewObjectFileJS, editListingTypes, describeColumnsView, true);

									if (describeColumnsFileds.Any())
										//aggiungo il describe columns all'oggetto normale con i campi di lookup calcolati per le griglie (GRIGLIE e ELENCHI in assenza di vista)
										SetDescribeColumnsOnJS(fullPathMetaDatoJS, editListingTypes, describeColumns, true);
									else
										SetDescribeColumnsOnJS(fullPathMetaDatoJS, editListingTypes,
											new List<string>() { "\t\t\t\t\t\treturn this.superClass.describeColumns(table, listType);\r\n" }, true);

								}
								//DESCRIBECOLUMNS -------------------end

								//GET SORTING -------------------begin

								//nel metadato, per oridinare le GRIGLIE genero il get sorting con i campi 
								var sortString = "";
								if (fields.Any(f => !string.IsNullOrEmpty((f.SortData ?? "").Trim()) || f.Name == "sortcode")) {
									if (fields.Any(f => f.Name == "sortcode") && (!viewFields.Any(item => !string.IsNullOrEmpty(item.SortData) && item.Name != "sortcode")))
										sortString = "sortcode";
									else
										sortString = string.Join(", ", fields.Where(f => (f.Table == o.Table || f.Table == extendedObject) && !string.IsNullOrEmpty((f.SortData ?? "").Trim()))
											.OrderBy(f => f.SortList).Select(f => f.Name + " " + f.SortData));
								}

								if (!string.IsNullOrEmpty(sortString)) {
									SetGetSorting(fullPathMetaDatoJS, editListingTypes, sortString);

									if (!string.IsNullOrEmpty(viewObjectFileJS))
										SetGetSorting(viewObjectFileJS, editListingTypes, sortStringView);
								}

								//GET SORTING -------------------end


								var fullPathMetaPageJS = clientFolder + metapageFolder + container + "/" +
									(!string.IsNullOrEmpty(extendedObject) ? extendedObject : o.Table) + "_" + editListingTypes + ".js";
								if (o.Createmetapage) {
									Console.WriteLine("2.5) CREO LA METAPAGE JS");
									//-copio e rinomino il template della metapage js nella cartella della metapage
									Copy("../../metapage_template/tabella_edittype.js", fullPathMetaPageJS, true);
									//-sostituzioni di nome
									ReplaceStringInFile(fullPathMetaPageJS, "tabella", (!string.IsNullOrEmpty(extendingObject) ? extendedObject : o.Table));
									ReplaceStringInFile(fullPathMetaPageJS, "'titolopagina'", "'" + o.Title.Replace("'", @"\'") + "'");
									ReplaceStringInFile(fullPathMetaPageJS, "tipoedit", editListingTypes, true);
									ReplaceStringInFile(fullPathMetaPageJS, "Principale", o.Principale == "N" ? "true" : "false");
									ReplaceStringInFile(fullPathMetaPageJS, "_APP_", currentApp, true);

									//-va aggiunto in indexdebug.html
									ReplaceStringInFile(clientFolder + "indexdebug.html", "<!-- meta page -->\r\n",
										"<!-- meta page -->\r\n	<script src=\"" + metapageFolder + container + "/" +
									(!string.IsNullOrEmpty(extendedObject) ? extendedObject : o.Table) + "_" + editListingTypes + ".js\"></script>\r\n");

									//albero
									if (o.IsTree) {
										if (o.Principale == "S") {
											ReplaceStringInFile(fullPathMetaPageJS, "//pageHeaderDeclaration\r\n", "this.isList = true;\r\n\t\tthis.isTree = true;\r\n" + "\t\t//pageHeaderDeclaration\r\n");

											//dichiaro i getTemporaryValues per le griglie dei noti dell'albero
											foreach (var f in fields.Where(ff => ff.Name.StartsWith("XX"))) {
												SetBeforeFill(fullPathMetaPageJS, "appMeta.metaModel.getTemporaryValues(this.getDataTable('" + f.Name.Substring(2) + "'));\r\n", o.Table, editListingTypes);
											}

											//senza questo evento scatta il messaggio che ci sono modifiche appena si apre la pagina
											SetBottomCode(fullPathMetaPageJS, "beforeSelectTreeManager: function () {\r\n" +
														"\t\t\t\tvar def = appMeta.Deferred('beforeSelectTreeManager');\r\n" +
														"\t\t\t\treturn def.resolve(true);\r\n" +
														"\t\t\t}");
										}
										var principalTextField = fields.Where(f => f.Textfield > 0 && f.ListVisible == true).OrderBy(i => i.Textfield).ToList();

										var fiParentKey = GetParentkey(principalTextField.First().Table, principalTextField.First().EditListingType, principalkey.Name, fields);
										var minumParentValue = GetTopTableValue(fiParentKey, connection);

										var describeTree = "describeTree: function (table, listType) {\r\n" +
"				var def = appMeta.Deferred(\"meta_describeTree\");\r\n" +
"				var nodedispatcher = new appMeta.SimpleUnLeveled_TreeNode_Dispatcher(" + String.Join(",", principalTextField.Select(item => "\"" + item.Name + "\"").ToList()) + ");\r\n" +
((minumParentValue != null || !string.IsNullOrEmpty(fiParentKey.Defaultvalue)) ?
"				var rootCondition = window.jsDataQuery.eq(\"" + fiParentKey.Name + "\", " + ((!string.IsNullOrEmpty(fiParentKey.Defaultvalue)) ? fiParentKey.Defaultvalue : ((!string.IsNullOrEmpty(minumParentValue.ToString())) ? minumParentValue.ToString() : fiParentKey.Testvalue)) + ");\r\n" :
"				var rootCondition = window.jsDataQuery.isNull(\"" + String.Join(",", fiParentKey.Name) + "\");\r\n") +
"				return def.resolve({\r\n" +
"					rootCondition: rootCondition,\r\n" +
"					nodeDispatcher: nodedispatcher\r\n" +
"				});\r\n" +
"			}";
										var allTextFile = File.ReadAllText(fullPathMetaDatoJS);
										var oldDescribeTree = Regex.Matches(allTextFile, @"describeTree: function(.*?)\}[\,]?\r\n", RegexOptions.Singleline).Cast<Match>().Select(m => m.Value.Trim()).Distinct().ToList();
										if (!allTextFile.Contains("//$describeTree$") && oldDescribeTree.Count() == 0) {
											//nel file non ÃƒÂ¨ presente nÃƒÂ¨ il markup nÃƒÂ¨ una vecchia funzione,accodo la funzione a //$getSorting$
											var getSortingPoint = Regex.Matches(allTextFile, @"//\$getSorting\$", RegexOptions.Singleline).Cast<Match>().Select(m => m.Value.Trim()).Distinct().ToList();
											if (getSortingPoint.Any())
												ReplaceStringInFile(fullPathMetaDatoJS, getSortingPoint[0], getSortingPoint[0] + "\r\n\r\n			" + describeTree + ",");
											else {
												getSortingPoint = Regex.Matches(allTextFile, @"getSorting:+\s*function+\s*\(+[\w\s\p{P}/$]*\}[\,]?\r\n", RegexOptions.Singleline).Cast<Match>().Select(m => m.Value.Trim()).Distinct().ToList();
												if (getSortingPoint.Any())
													ReplaceStringInFile(fullPathMetaDatoJS, getSortingPoint[0], getSortingPoint[0] + (getSortingPoint[0].EndsWith(",") ? string.Empty : ",\r\n") + "\n\r\n			" + describeTree);
												else ConsoleWriter.Error("Non ÃƒÂ¨ stata inserita nessuna funzione describeTree, rivedere il markup //$describeTree$ nel metadato.js");
											}

										}
										else if (oldDescribeTree.Count() > 0) {
											//proviamo a sotituire la eventuale describeTree giÃƒÂ  implementata in precedenza
											//NOTA BENE se non avvenisse la sostituzione in modo corretto verificare che dopo }, ci sia subito un accapo
											ReplaceStringInFile(fullPathMetaDatoJS, oldDescribeTree[0], describeTree);
										}
										else {
											//  ÃƒÂ¨ la prima volta che la funzione viene scritta
											var getSortingPoint = Regex.Matches(allTextFile, @"getSorting:+\s*function+\s*\(+[\w\s\p{P}/$]*\}[\,]?\r\n", RegexOptions.Singleline).Cast<Match>().Select(m => m.Value.Trim()).Distinct().ToList();
											if (getSortingPoint.Any() && !getSortingPoint[0].EndsWith(","))
												ReplaceStringInFile(fullPathMetaDatoJS, getSortingPoint[0], getSortingPoint[0] + ",", true);

											ReplaceStringInFile(fullPathMetaDatoJS, "//$describeTree$", describeTree);
										}

									}
									//bottoni
									if ((!string.IsNullOrEmpty(o.SearchEnabled) && o.SearchEnabled == "N" && !o.IsTree))
										ReplaceStringInFile(fullPathMetaPageJS, "//pageHeaderDeclaration\r\n", "this.searchEnabled = false;\r\n" + "\t\t//pageHeaderDeclaration\r\n");
									if (!string.IsNullOrEmpty(o.CanInsert) && o.CanInsert == "N")
										ReplaceStringInFile(fullPathMetaPageJS, "//pageHeaderDeclaration\r\n", "this.canInsert = false;\r\n" + "\t\t//pageHeaderDeclaration\r\n");
									if (!string.IsNullOrEmpty(o.CanInsertCopy) && o.CanInsertCopy == "N")
										ReplaceStringInFile(fullPathMetaPageJS, "//pageHeaderDeclaration\r\n", "this.canInsertCopy = false;\r\n" + "\t\t//pageHeaderDeclaration\r\n");
									if (!string.IsNullOrEmpty(o.CanSave) && o.CanSave == "N")
										ReplaceStringInFile(fullPathMetaPageJS, "//pageHeaderDeclaration\r\n", "this.canSave = false;\r\n" + "\t\t//pageHeaderDeclaration\r\n");
									if (!string.IsNullOrEmpty(o.CanCancel) && o.CanCancel == "N")
										ReplaceStringInFile(fullPathMetaPageJS, "//pageHeaderDeclaration\r\n", "this.canCancel = false;\r\n" + "\t\t//pageHeaderDeclaration\r\n");
									if (!string.IsNullOrEmpty(o.CanCmdClose) && o.CanCmdClose == "N")
										ReplaceStringInFile(fullPathMetaPageJS, "//pageHeaderDeclaration\r\n", "this.canCmdClose = false;\r\n" + "\t\t//pageHeaderDeclaration\r\n");
									if (!string.IsNullOrEmpty(o.CanShowLast) && o.CanShowLast == "N")
										ReplaceStringInFile(fullPathMetaPageJS, "//pageHeaderDeclaration\r\n", "this.canShowLast = false;\r\n" + "\t\t//pageHeaderDeclaration\r\n");
									//pagina anonima
									if (o.Anonimous)
										ReplaceStringInFile(fullPathMetaPageJS, "//pageHeaderDeclaration\r\n", "appMeta.connection.setAnonymous();\r\n" + "\t\t//pageHeaderDeclaration\r\n");
									//pagina a ricerca automatica
									if (o.Autosearch)
										ReplaceStringInFile(fullPathMetaPageJS, "//pageHeaderDeclaration\r\n", "this.firstSearchFilter = window.jsDataQuery.constant(true);\r\n" + "\t\t//pageHeaderDeclaration\r\n");

									//calendario nell'elenco
									if (!string.IsNullOrEmpty(o.Calendarstart) && !string.IsNullOrEmpty(o.Calendartitle)) {

										SetBottomCode(fullPathMetaPageJS, "createAndGetListManager: function (searchTableName, listingType, prefilter, isModal, rootElement, that, filterLocked, toMerge, isCommandSearch) {\r\n" +
										"                // isCommandSearch ÃƒÂ¨ true se lancio comando di ricerca, false se vengo da un autochoose, e qin quel caso implemnto comportamento di default\r\n" +
										"                var startColumnName = \"" + o.Calendarstart + "\";\r\n" +
										"                var titleColumnName = \"" + o.Calendartitle + "\";\r\n" +
										"                var stopColumnName = " + (!string.IsNullOrEmpty(o.Calendarstop) ? "\"" + o.Calendarstop + "\"" : "null") + ";\r\n" +
										"                if (isCommandSearch) return new window.appMeta.ListManagerCalendar(searchTableName, listingType, prefilter, isModal, rootElement, that, filterLocked, toMerge, startColumnName , titleColumnName, stopColumnName);\r\n" +
										"                // se non esco prima, significa autochoose e quindi esegue il sodiuce della superClass\r\n" +
										"                return this.superClass.createAndGetListManager(searchTableName, listingType, prefilter, isModal,rootElement, that, filterLocked, toMerge, isCommandSearch);\r\n" +
										"            }");
									}

									//aggiungo il codice personalizzato------------------------------------------------------
									if (!string.IsNullOrEmpty(o.CustomJavascript)) {

										//aggiungo tutto il codice subito perchÃƒÂ¨ potrei aver fatto l'override di qualche evento
										//nel campo del configuratore, il codice per gli override va messo prima delle funzioni personalizzate, in modo da eliminare PRIMA i marcatori per afterlink, beforefill e afterGetFormData 
										SetBottomCode(fullPathMetaPageJS, o.CustomJavascript);

										var funs = Regex.Matches(o.CustomJavascript, @"(\s|^)(\w*?):(\s+|)function(\s+|)[(](that, grid|dataRow|currMetaPage, cmd|)[)]", RegexOptions.Singleline).Cast<Match>().
											Select(m => Regex.Replace(m.Value, @":(\s+|)function(\s+|)[(](that, grid|dataRow|currMetaPage, cmd|)[)]", "").Trim()).Distinct().ToList();
										var funsBody = Regex.Matches(o.CustomJavascript.Trim() + ',', @":(\s+|)function(\s+|)[(](that, grid|dataRow|currMetaPage, cmd|)[)](.*?)\}\,", RegexOptions.Singleline).Cast<Match>()
											   .Select(m => Regex.Replace(m.Value, @":(\s+|)function(\s+|)[(](that, grid|dataRow|currMetaPage, cmd|)[)]", "").Trim()).Distinct().ToList();

										for (var i = 0; i < funs.Count(); i++) {
											var fun = funs[i];

											var pageEvents = new List<string>() { "//skipAfterlink:", "insertClick", "beforePost", "afterGetFormData", "afterRowSelect", "afterFill", "afterLink", "afterPost", "beforeSelectTreeManager", "rowSelected", "buttonClickEnd" };
											if (!pageEvents.Contains(fun)) {
												//se NON si tratta di ovverride di eventi devo aggiungere la chiamata al metodo inserito
												if (!o.BeforeFillSinc.Contains("this." + fun + "()"))
													//... ma solo se non ÃƒÂ¨ giÃƒÂ  stato richiamato nella beforeFill
													if (funsBody[i].Contains("this.getDataTable(") || funsBody[i].Contains("self.getDataTable(")) {
														//se usa il dataset va lanciata nell'afterGetFormData

														if (funsBody[i].Contains("appMeta.Deferred")) {
															SetBeforeFillAsinc(fullPathMetaPageJS, "arraydef.push(this." + fun + "());\r\n", o.Table, editListingTypes, false, true);
															SetAfterGetFormData(fullPathMetaPageJS, "this." + fun + "()", o.Table, editListingTypes, false, true);
														}
														else {
															SetBeforeFill(fullPathMetaPageJS, "this." + fun + "();\r\n", o.Table, editListingTypes, false);
															SetAfterGetFormData(fullPathMetaPageJS, "this." + fun + "()", o.Table, editListingTypes, true, true);
														}
													}
													else {
														//altrimenti nell'afterlink
														if (funsBody[i].Contains("appMeta.Deferred"))
															SetAfterlinkAsinc(fullPathMetaPageJS, "self." + fun + "()");
														else
															SetAfterlink(fullPathMetaPageJS, "this." + fun + "();\r\n");
													}
											}
											else {
												//se si tratta di ovverride di eventi non devo aggiungere la chiamata ma devo cancellare il tag per l'inserimento dell'evento
												ReplaceStringInFile(fullPathMetaPageJS, "//" + fun + "\r\n", "");
												// se si tratta di rowswlwcted devo aggiungere la dichiarazione nell'header
												if (fun == "rowSelected")
													ReplaceStringInFile(fullPathMetaPageJS, "//pageHeaderDeclaration\r\n", "this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);\r\n" +
														"\t\t//pageHeaderDeclaration\r\n");

											}
										}

									}

									//------------------------------------relazioni 1 a 1 ----------------------------------------------begin

									//-aggiungo i campi che vanno affogati nella pagina perchÃƒÂ¨ l'associazione ÃƒÂ¨ "unique" cioÃƒÂ¨ 1 a 1
									var relationFieldUnique = fields.Where(f => f.Name.StartsWith("XX") && f.RelationType == "unique").ToList();

									if (isExtendedObjView)
										SetBeforeFillAsinc(fullPathMetaPageJS, "var dt = this.state.DS.tables[\"" + currentTable + "\"];\r\n" +
											"\t\t\t\tif (dt.rows.length === 0) {\r\n" +
											"\t\t\t\t\tvar meta = appMeta.getMeta(\"" + o.Table + "\");\r\n" +
											"\t\t\t\t\tmeta.setDefaults(dt);\r\n" +
											"\t\t\t\t\tvar def" + o.Table + " = meta.getNewRow(parentRow.getRow(), dt, self.editType).then(\r\n" +
											"\t\t\t\t\t\tfunction (currentRow" + extendingObject + ") {\r\n" +
											"\t\t\t\t\t\t\t//defaultExtendingObject\r\n" +
											"\t\t\t\t\t\t\treturn true;\r\n" +
											"\t\t\t\t\t\t}\r\n" +
											"\t\t\t\t\t);\r\n" +
											"\t\t\t\t\tarraydef.push(def" + o.Table + ");\r\n" +
											"\t\t\t\t}\r\n" +
											"\r\n", o.Table, editListingTypes);

									var uniqueobjs = new List<string>();
									var nephewByUnique = new List<field>();
									foreach (var unique in relationFieldUnique) {
										var uniqueobj = unique.Name.Substring(2);
										var uniqueobjEditListingType = unique.Listtype;

										uniqueobjs.Add(uniqueobj);
										//aggiungo la riga se manca
										SetBeforeFillAsinc(fullPathMetaPageJS, "var dt" + uniqueobj + " = this.state.DS.tables[\"" + uniqueobj + "\"];\r\n" +
											"\t\t\t\tif (dt" + uniqueobj + ".rows.length === 0) {\r\n" +
											"\t\t\t\t\tvar meta" + uniqueobj + " = appMeta.getMeta(\"" + uniqueobj + "\");\r\n" +
											"\t\t\t\t\tmeta" + uniqueobj + ".setDefaults(dt" + uniqueobj + ");\r\n" +
											"\t\t\t\t\tvar def" + uniqueobj + " = meta" + uniqueobj + ".getNewRow(parentRow.getRow(), dt" + uniqueobj + ", self.editType).then(\r\n" +
											"\t\t\t\t\t\tfunction (currentRow" + uniqueobj + ") {\r\n" +
											"\t\t\t\t\t\t\t//default" + uniqueobj + "Object\r\n" +
											"\t\t\t\t\t\t\treturn true;\r\n" +
											"\t\t\t\t\t\t}\r\n" +
											"\t\t\t\t\t);\r\n" +
											"\t\t\t\t\tarraydef.push(def" + uniqueobj + ");\r\n" +
											"\t\t\t\t}\r\n" +
											"\r\n", o.Table, editListingTypes);

										//associo la funzione di calcolo delle colonne calcolate alla tabella figlia collegata 1 a 1 all'oggetto principale nel caso uno qualunque dei suoi figli 
										//sia rappresentato in una griglia ed abbia dei campi calcolati
										SetAfterlink(fullPathMetaPageJS, "appMeta.metaModel.computeRowsAs(this.state.DS.tables." + uniqueobj + ", \"" + uniqueobjEditListingType +
										"\", this.superClass.calculateFields);\r\n");

										//nel caso particolare in cui l'oggetto collegato 1 a 1 mostri solamente foreignkey in autochoose, l'oggetto non compare mai nei controlli 
										//e il framework non riesce ad aggiungerlo automaticamente alle entitÃƒÂ  extra, quindi lo forziamo adesso, tanto se giÃƒÂ  l'ha inserito lui 
										//non viene duplicato ma sovrascritto
										SetAfterlink(fullPathMetaPageJS, "this.helpForm.addExtraEntity(\"" + uniqueobj + "\");\r\n");

										//aggiungo i campi ai fields
										var uniquefields = allfields.Where(af => af.Table == uniqueobj && af.EditListingType == (uniqueobjEditListingType ?? "defaut") && af.Detailvisible);

										//potrei aver voluto fare una relazione 1 a 1 solo al fine di creare l'oggetto collegato ma senza voler far veder per forza i suoi campi
										if (uniquefields.Any()) {
											foreach (var uf in uniquefields) {
												uf.IsUniqueField = true;
												//se ho specificato per la relazione un tab particolare della pagina madre lo riassegno ai filds unici in questo momento
												uf.Tab = unique.Tab;
											}
											//per essere sicuro che il campo della relazione sia unico nel suo tab, in modo che poi venga skippato nella generazione dell'HTML
											//gli cambio il nome del tab con il nome di se stesso
											unique.Tab = unique.Name;
											fields.AddRange(uniquefields);
											//aggiungo anche i campi di relazione che a sua volta aveva l'oggetto collegato 1 a 1
											var uniqueRelations = GetChildentitiesFields(uniquefields.First().PageId, null, allfields, connection);
											if (uniqueRelations.Any()) {
												fields.AddRange(uniqueRelations);
												nephewByUnique.AddRange(uniqueRelations);
												foreach (var ur in uniqueRelations) {
													var metadatoChild = ur.Name.Substring(2);
													SetMetadatoChild(fields, ur, metadatoChild, ref allfields, connection);
												}
											}
										}
									}

									//------------------------------------relazioni 1 a 1 ----------------------------------------------end

									//------------------------------------filtri sulle griglie------------------------------------------begin
									var relationFieldfiltered = fields.Where(f => f.Name.StartsWith("XX")).ToList();
									foreach (var filteredrel in relationFieldfiltered) {
										SetFilterOnMetaPageJS(filteredrel, fullPathMetaPageJS, o.Table, (string.IsNullOrWhiteSpace(extendedObject) ? o.Table : extendedObject), editListingTypes, ref allfields, fields, connection);
									}

									//in ultimo devo eseguire il setting del valore nella beforefill della subpage per gli oggetti nuovi SOLO SE E' UGUALE
									var currentfilteredFields = fields.Where(af => af.Table == o.Table && af.EditListingType == editListingTypes && !string.IsNullOrEmpty(af.Filter));
									if (currentfilteredFields.Any()) {
										foreach (var filt in currentfilteredFields)
											//SetBeforeFill(fullPathMetaPageJS, "this.state.currentRow." + GetJsFilter(filt) + ";\r\n");
											if (filt.Filter.StartsWith(" ="))
												SetBeforeFill(fullPathMetaPageJS, "this.state.currentRow." + filt.Name + filt.Filter + ";\r\n", o.Table, editListingTypes);
									}

									//------------------------------------filtri sulle griglie------------------------------------------end

									//------------------------------------SET DEFAULT DI PAGINA------------------------------------------begin
									var fieldsWithDefault = fields.Where(fi => fi.Name != "ct" && fi.Name != "lt" && fi.Name != "cu" && fi.Name != "lu"
														 && (!string.IsNullOrEmpty(fi.Defaultvalue) || ((fi.Type == "datetime" || fi.Type == "date") && !fi.Allownull))
														 && (fi.Table == o.Table || fi.Table == extendedObject || uniqueobjs.Contains(fi.Table)));
									if (fieldsWithDefault.Any()) {

										var setPageDefault = "";
										foreach (var f in fieldsWithDefault) {
											var tableCol = f.Name.Contains("!") ? "['" + f.Name + "']" : "." + f.Name;

											if (f.Table == extendedObject + "_" + extendingObject) {
												//estendente
												var table = "currentRow" + extendingObject + ".current";
												if (!string.IsNullOrEmpty(f.Defaultvalue)) {
													setPageDefault = "\t\t\t\t\t\t\t" + table + tableCol + " = " + f.Defaultvalue + ";\r\n";
												}
												if ((f.Type == "datetime" || f.Type == "date") && !f.Allownull) {
													setPageDefault += "\t\t\t\t\t\t\t" + table + tableCol + " =  new Date();\r\n";
												}
												ReplaceStringInFile(fullPathMetaPageJS, "\t\t\t\t\t\t\t//defaultExtendingObject\r\n",
													setPageDefault + "\t\t\t\t\t\t\t//defaultExtendingObject\r\n");
											}
											else {
												if (uniqueobjs.Contains(f.Table)) {
													//1 a 1
													var table = "currentRow" + f.Table + ".current";
													if (!string.IsNullOrEmpty(f.Defaultvalue)) {
														setPageDefault = "\t\t\t\t\t\t\t" + table + tableCol + " = " + f.Defaultvalue + ";\r\n";
													}
													if ((f.Type == "datetime" || f.Type == "date") && !f.Allownull) {
														setPageDefault += "\t\t\t\t\t\t\t" + table + tableCol + " =  new Date();\r\n";
													}

													ReplaceStringInFile(fullPathMetaPageJS, "\t\t\t\t\t\t\t//default" + f.Table + "Object\r\n",
													setPageDefault + "\t\t\t\t\t\t\t//default" + f.Table + "Object\r\n");
												}
												else {
													//esteso o normale
													var table = "parentRow";
													var checkForKeys = "";
													if (f.IsKey && GetDatasetType(f.Type) == "int")
														checkForKeys = " || " + table + tableCol + " == 0";
													if (f.IsKey && GetDatasetType(f.Type) == "string")
														checkForKeys = " || " + table + tableCol + " == ''";
													if (!string.IsNullOrEmpty(f.Defaultvalue)) {
														setPageDefault = "\t\t\t\tif (!" + table + tableCol + checkForKeys + ")\r\n";
														setPageDefault += "\t\t\t\t\t" + table + tableCol + " = " + f.Defaultvalue + ";\r\n";
													}
													if ((f.Type == "datetime" || f.Type == "date") && !f.Allownull) {
														setPageDefault = "\t\t\t\tif (self.isNullOrMinDate(" + table + tableCol + "))\r\n";
														setPageDefault += "\t\t\t\t\t" + table + tableCol + " = new Date();\r\n";
													}
													SetBeforeFill(fullPathMetaPageJS, setPageDefault, o.Table, editListingTypes, true);
												}
											}
										}

										if (isExtendedObjView)
											SetBeforeFill(fullPathMetaPageJS, "parentRow.extension = \"" + extendingObject + "\";\r\n", o.Table, editListingTypes);

									}
									//------------------------------------SET DEFAULT DI PAGINA------------------------------------------end

									//------------------------------------OPERAZIONI DI PAGINA SUL DATASET-----------------------------begin

									if (!string.IsNullOrWhiteSpace(o.BeforeFillSinc))
										if (o.BeforeFillSinc.Contains("arraydef.push("))
											SetBeforeFillAsinc(fullPathMetaPageJS, o.BeforeFillSinc, o.Table, editListingTypes);
										else
											SetBeforeFill(fullPathMetaPageJS, o.BeforeFillSinc, o.Table, editListingTypes);


									//------------------------------------OPERAZIONI DI PAGINA SUL DATASET-------------------------------end

									//-aggiungo le ricerche per le relazioni con tabelle di collegamento--------------------------------begin
									var relationFieldCerca = fields.Where(f => f.Name.StartsWith("XX") && f.RelationType == "cerca").ToList();
									if (relationFieldCerca.Any()) {
										foreach (var fi in relationFieldCerca) {
											//if (IsLinkingObject(fi.Name.Substring(2), ref allfields, connection)) {
											var linktable = fi.Name.Substring(2); //tabella di collegamento
											var linkEditlistingType = fi.Listtype; //EditListingType della tabella di collegamento

											//campo visibile e chiave sulla tabella di collegamento che punta alla collegata
											var linkid = allfields.Where(f => f.IsKey && f.ListVisible && HaveKeyName(f)
																 && f.Table == linktable && f.EditListingType == linkEditlistingType).FirstOrDefault();

											if (linkid != null) {
												//il list type da mostrare nella ricerca sopra la griglia
												var linkedtableListType = string.IsNullOrEmpty(linkid.Listtype) ? "default" : linkid.Listtype;

												//tabella collegata con eventuali alias
												var linkedtable = GetLinkedTable(linkid, ref fields, subfields, ref allfields, connection);

												if (!string.IsNullOrEmpty(linkedtable)) {

													//assegno subito al metodo il nome della tabella collegata cosÃƒÂ¬ poi se ÃƒÂ¨ estendente e quindi la tabella collegata cambia 
													//il nome del metodo resta quello originale
													var methodName = linkedtable;

													var sourceFieldLink = GetIdByForeignKey(linkid.Name, linktable);
													//campo testuale principale della tabella collegata
													var linkedtableTextField = GetTextFieldByTable(linkedtable, allfields, connection).FirstOrDefault();
													if (linkedtable.Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[0] != linkedtableTextField.Table) {
														//aggiungo il filtro statico linkid.name in (select linkid.Name from linkedtable) 
														//dove linkedtable ÃƒÂ¨ ancora l'oggetto estendente

														//mi ÃƒÂ¨ stato restituito il campo testuale dell'oggetto da cui deriva quindi devo cercare lÃƒÂ¬
														linkedtable = linkedtableTextField.Table;
														var linkids = GetIdByTable(linkedtable, allfields, connection, false);
														if (linkids.Any())
															sourceFieldLink = linkids.First();
														//anche il list type cambia
														linkedtableListType = linkedtableTextField.EditListingType;
													}

													//inserisco solo l'associazione tra il bottone e l'evento all'interno dell'afterlink
													SetAfterlink(fullPathMetaPageJS, "$(\"#btn_add_" + linktable + "_" + linkid.Name + "\").on(\"click\", _.partial(this.searchAndAssign" + methodName + ", self));\r\n" +
														"\t\t\t\t$(\"#btn_add_" + linktable + "_" + linkid.Name + "\").prop(\"disabled\", true);\r\n");

													//inserisco solo l'associazione tra il bottone e l'evento all'interno del rowSelected
													SetRowSelected(fullPathMetaPageJS, "$(\"#btn_add_" + linktable + "_" + linkid.Name + "\").prop(\"disabled\", false);\r\n");

													//inserisco solo l'associazione tra il bottone e l'evento all'interno del buttonClickEnd
													SetButtonClickEnd(fullPathMetaPageJS, "$(\"#btn_add_" + linktable + "_" + linkid.Name + "\").prop(\"disabled\", true);\r\n");

													//se si tratta di una sub-entitÃƒÂ  di un oggetto collegato 1 a 1 in realtÃƒÂ  ÃƒÂ¨ un nipote ... 
													//quindi gli devo passare una parentrow differente
													var isNephew = nephewByUnique.Contains(fi);

													//aggiungo l'evento di chiamata alla funzione c#
													var btn = "searchAndAssign" + methodName + @": function (that) {
				return that.searchAndAssign({
					tableName: """ + linkedtable + @""",
					listType: """ + linkedtableListType + @""",
					idControl: ""txt_" + linktable + "_" + linkid.Name + @""",
					tagSearch: """ + (HaveView(linkedtable, linkedtableListType, ref allfields, connection) ?
						RemoveAlias(linkedtable) + linkedtableListType + "view.dropdown_title" :
						linkedtable + @"." + linkedtableTextField.Name) + @""",
					columnNameText: """ + linkedtableTextField.Name + @""",
					columnSource: """ + sourceFieldLink + @""",
					columnToFill: """ + linkid.Name + @""",
					tableToFill: """ + linktable + @"""" +
(isNephew ? ",\r\n\t\t\t\t\tparentRow: that.state.DS.tables." + fi.Table + ".rows[0]\r\n" : "\r\n")
+ @"				});
			}";
													SetBottomCode(fullPathMetaPageJS, btn);
												}
												else {
													ConsoleWriter.ErrorDB("in fase di generazione del tab con ricerca per la tabella di collegamento " + linktable + " ÃƒÂ¨ fallito il recupero della tabella collegata");
												}
											}
											else {
												ConsoleWriter.ErrorDB("in fase di generazione del tab con ricerca per la tabella di collegamento " + linktable + " ÃƒÂ¨ fallita l'individuazione della foreignkey di collegamento");
											}

										}
									}

									//evito il bug del calendar che se in un tab appare con celle piÃƒÂ¹ basse fino al primo evento------------------------------------------------------
									var relationFieldCalendar = fields.Where(f => f.Name.StartsWith("XX") && (f.RelationType == "calendario" || f.RelationType == "calendariow")).ToList();
									if (relationFieldCalendar.Any()) {
										foreach (var fi in relationFieldCalendar) {
											SetAfterlink(fullPathMetaPageJS,
												"$('.nav-tabs').on('shown.bs.tab', function (e) {\r\n" +
												"\t\t\t\t\t$('#calendar" + fields.IndexOf(fi) + "').fullCalendar('rerenderEvents');\r\n" +
												"\t\t\t\t});\r\n"
												);
										}
									}

									//------------------------------------relazioni a bottone ----------------------------------------------begin

									// prima parte se siamo nella maschera madre:

									//-gestisco il bottone per la pagina a bottone perchÃƒÂ¨ l'associazione ÃƒÂ¨ "button"
									var relationFieldButton = fields.Where(f => f.Name.StartsWith("XX") && f.RelationType == "button").ToList();
									if (relationFieldButton.Any()) {
										//ricavo la chiave principale dell'oggetto corrente
										//var callingParameters = "";
										//foreach (var k in objectKey)
										//	callingParameters += (objectKey.IndexOf(k) == 0 ? "" : "\t\t\t\t") + "this.state.callingParameters." + k + " = parentRow." + k + ";\r\n";

										foreach (var b in relationFieldButton) {

											//inserisco l'associazione tra il bottone e l'evento all'interno dell'afterlink
											SetAfterlink(fullPathMetaPageJS, "$(\"#" + b.Name + "\").prop(\"disabled\", true);\r\n");

											//setto a disabilitato il bottone e i callingParameters (separati perchÃƒÂ¨ in caso di piÃƒÂ¹ bottoni nella stessa pagina la seconda parte ÃƒÂ¨ uguale)
											SetBeforeFill(fullPathMetaPageJS, "$(\"#" + b.Name + "\").prop(\"disabled\", !this.state.isEditState());\r\n", o.Table, editListingTypes);
											//SetBeforeFill(fullPathMetaPageJS, callingParameters, o.Table, editListingTypes);

											//inserisco solo la disabilitazione tra il bottone e l'evento all'interno del buttonClickEnd
											SetButtonClickEnd(fullPathMetaPageJS, "if ($(\"#" + b.Name + "\").length) {\r\n" +
												"\t\t\t\t\t$(\"#" + b.Name + "\").prop(\"disabled\", !currMetaPage.state.isEditState());\r\n" +
												"\t\t\t\t}\r\n", true);
										}
									}

									//seconda parte se siamo nella maschera figlia

									if (parentEntities.Any(pe => pe.RelationType == "button")) {

										foreach (var r in parentEntities.Where(pe => pe.RelationType == "button")) {

											var parentkeys = GetIdByTable(r.Name.Substring(2), allfields, connection);

											if (parentkeys.Count == 1) {
												var k = parentkeys.First();
												SetBeforeFill(fullPathMetaPageJS, "parentRow." + k + " = this.state.callerState.currentRow." + k + ";\r\n", o.Table, editListingTypes);

												//aggiungo l'associazione tra il bottone e l'evento all'interno dell'afterlink
												SetAfterlink(fullPathMetaPageJS, "self.firstSearchFilter  = window.jsDataQuery.eq(\"" + k + "\", this.state.callerState.currentRow." + k + ");\r\n" +
													"\t\t\t\t\tself.startFilter = self.firstSearchFilter;\r\n");

											}
											else {

												var index = 1;
												var filter = "";
												foreach (var k in parentkeys) {

													SetBeforeFill(fullPathMetaPageJS, "parentRow." + k + " = this.state.callerState.currentRow." + k + ";\r\n", o.Table, editListingTypes);

													SetAfterlink(fullPathMetaPageJS, "var f" + index.ToString() + " = window.jsDataQuery.eq(\"" + k + "\", this.state.callerState.currentRow." + k + ");\r\n");
													filter += "f" + index.ToString() + (index == parentkeys.Count() ? "" : ", ");
													index++;
												}
												SetAfterlink(fullPathMetaPageJS, "self.firstSearchFilter  = window.jsDataQuery.and(" + filter + ");\r\n" +
													"\t\t\t\t\tself.startFilter = self.firstSearchFilter;\r\n");

											}
										}
									}

									//------------------------------------relazioni a bottone ----------------------------------------------end

									//-aggiungo i bottoni------------------------------------------------------
									if (buttonFields.Any()) {
										foreach (var b in buttonFields) {

											//aggiungo l'associazione tra il bottone e l'evento all'interno dell'afterlink
											SetAfterlink(fullPathMetaPageJS, "$(\"#" + b.Name + "\").on(\"click\", _.partial(this.fire" + b.Name + ", this));\r\n" +
												"\t\t\t\t$(\"#" + b.Name + "\").prop(\"disabled\", true);\r\n");

											//aggiungo l'associazione tra il bottone e l'evento all'interno del rowSelected
											SetRowSelected(fullPathMetaPageJS, "$(\"#" + b.Name + "\").prop(\"disabled\", false);\r\n");

											//aggiungo la disabilitazione tra il bottone e l'evento all'interno del buttonClickEnd
											SetButtonClickEnd(fullPathMetaPageJS, "$(\"#" + b.Name + "\").prop(\"disabled\", true);\r\n");

											if (string.IsNullOrEmpty(b.Javascript)) {
												//aggiungo l'evento di chiamata alla funzione c#
												//se sono state indicate griglie da aggiornare ...
												if (!string.IsNullOrEmpty(b.Refresh)) {
													//...occorre modificare l'handler in modo che le aggiorni alla fine
													var s = @"fire" + b.Name + @": function (that) {
				var waitingHandler = that.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);
				appMeta.getData.launchCustomServerMethod(""mdlwCustomEvent"", {
					tablename: '" + o.Table + @"',
					customevent: """ + b.Name + @""",
					" + b.Parameter + @"
				}).then(function (res) {
					var parentRow = that.state.currentRow;
					var filter = window.jsDataQuery.eq(""" + principalkey.Name + @""", parentRow." + principalkey.Name + @");
					var selBuilderArray = [];
					var tableToRefresh = [";
													foreach (var toRefresh in b.Refresh.Split(','))
														s += "'" + toRefresh + "',";
													//tolgo l'ultima virgola
													s = s.Substring(0, s.Length - 1);
													s += @"];
					_.forEach(tableToRefresh, function (tname) {
						selBuilderArray.push({ filter: filter, top: null, tableName: tname, table: that.state.DS.tables[tname] });
					});
					appMeta.getData.multiRunSelect(selBuilderArray)
						.then(function () {
							that.freshForm(false, false)
								.then(function () {
									that.hideWaitingIndicator(waitingHandler);
									alert(res);
								});
						});

				});
			}";
													SetBottomCode(fullPathMetaPageJS, s);

												}
												else {
													SetBottomCode(fullPathMetaPageJS, @"fire" + b.Name + @": function (that) {
				appMeta.getData.launchCustomServerMethod(""mdlwCustomEvent"", {
					tablename: '" + o.Table + @"',
					customevent: """ + b.Name + @""",
					" + b.Parameter + @"
				})

					.then(function (res) {
						alert(res);
					});
            }");
												}
											}
											else {
												//se il codice personalizzato contiene giÃƒÂ  una afterfill allora la faccio inserire da lui (ÃƒÂ¨ il primo)
												if (b.Javascript.Contains("afterFill: function ()"))
													ReplaceStringInFile(fullPathMetaPageJS, "//afterFill\r\n", "");
												SetBottomCode(fullPathMetaPageJS, b.Javascript);
											}

										}
									}

									//------------------------------------eventi custom----------------------------------------------

									var eventi = fields.Where(item => !String.IsNullOrEmpty(item.EventText) && !String.IsNullOrEmpty(item.EventType));
									if (eventi.Any()) {
										foreach (var evento in eventi) {
											var callevent = "$('#" + evento.Table + "_" + evento.EditListingType + "_" + evento.Name.Replace("!", "") + "').on(\"" + evento.EventType + "\", _.partial(this.manage" + evento.Name.Replace("!", "") + ", self));\r\n";
											if (evento.Type == "char" && evento.Len == 1 && !evento.IsCheckbox)
												callevent = "$('input[name=\"" + evento.Table + "_" + evento.EditListingType + "_" + evento.Name.Replace("!", "") + "\"]').on(\"" + evento.EventType + "\", _.partial(this.manage" + evento.Name.Replace("!", "") + ", self));\r\n";
											if (evento.EventType == "dropDownChoose") {
												//caso di eventi del framework non jQery 
												callevent = "this.eventManager.subscribe(\"" + evento.EventType + "\", _.partial(this.manage" + evento.Name.Replace("!", "") + ", self), this);\r\n";
											}

											SetAfterlink(fullPathMetaPageJS, callevent);

											ReplaceStringInFile(fullPathMetaPageJS, "//buttons", "manage" + evento.Name.Replace("!", "") + ": function(that" + (evento.EventType == "dropDownChoose" ? ", ctrl" : "") + ") { \r\n\t\t\t\t" + evento.EventText + "\r\n\t\t\t},\r\n\r\n\t\t\t//buttons");
										}
									}

									//CREAZIONE TEST -----------------------------------------------------------------------------------------------------begin 
									var fullPathTest = testFolder + (!string.IsNullOrWhiteSpace(extendedObject) ? extendedObject : o.Table) + "_" + editListingTypes +
									(o.Principale == "S" ? "_e2e_spec.js" : "_e2e_child.js");
									if (!Directory.Exists(testFolder))
										Directory.CreateDirectory(testFolder);
									Copy(o.Principale == "S" ? "../../test_template/tabella_edittype_e2e_spec.js" : "../../test_template/tabella_edittype_e2e_child.js", fullPathTest, true);
									//-sostituzioni di nome
									ReplaceStringInFile(fullPathTest, "tabella", (!string.IsNullOrWhiteSpace(extendedObject) ? extendedObject : o.Table));
									ReplaceStringInFile(fullPathTest, "tipoedit", editListingTypes, true);
									ReplaceStringInFile(fullPathTest, "app_applicaz", clientFolder.Replace("../../../../../progetti/Portale/client/", "").Replace("/", ""));
									var testCase = "";

									//test di pagine ad esempio come la registrazione
									if (o.CanInsert == "N" & o.CanCancel == "N")
										testCase = "testMetaPageCase0";

									//test specifico per la pagina
									if (o.Testcustom || !string.IsNullOrEmpty(o.TestcustomText))
										testCase = "testCasePage_" + (!string.IsNullOrWhiteSpace(extendedObject) ? extendedObject : o.Table) + "_" + editListingTypes + "_custom";

									var fullPathTestParams = "";

									//test per le pagine a bottone
									if (parentEntities.Any(pe => pe.RelationType == "button")) {

										//devo creare anche il file con l'array da cui attinge il test della pagina con il bottone che apre la pagina attuale ...
										fullPathTestParams = testFolder + (!string.IsNullOrWhiteSpace(extendedObject) ? extendedObject : o.Table) + "_" + editListingTypes + "_e2e_childparam.js";
										Copy("../../test_template/tabella_edittype_e2e_child.js", fullPathTestParams, true);
										ReplaceStringInFile(fullPathTestParams, "tabella", (!string.IsNullOrWhiteSpace(extendedObject) ? extendedObject : o.Table));
										ReplaceStringInFile(fullPathTestParams, "tipoedit", editListingTypes, true);
										ReplaceStringInFile(fullPathTestParams, "app_applicaz", clientFolder.Replace("../../../../../progetti/Portale/client/", "").Replace("/", ""));

										//... e scrivere nel file di test il richiemo ad esso
										ReplaceStringInFile(fullPathTest, "//arrayInput\r\n", @"					// recupero dal file del dettaglio opportuno gli input
					var detailTestPrototype = 'appMeta.' + tablename + '_' + edittype;
					var myinstance = eval(detailTestPrototype);
					arrayInput = myinstance.arrayInput;");



										var parentEntity = parentEntities.First();
										var table = parentEntity.Name.Substring(2);
										var parentkeys = GetIdByTable(table, allfields, connection);
										//se ÃƒÂ¨ un oggetto estendente devo prendere solo i valori che si trovano su entrambe le tabelle
										var joinstring = "";
										if (table.Contains("_")) {
											var metadatoExtended = table.Split('_')[0];
											var keys = GetIdByTable(table, allfields, connection);
											joinstring += " INNER JOIN " + metadatoExtended + " ON ";
											var addend = false;
											foreach (var key in keys) {
												joinstring += (addend ? " AND " : "") + table + "." + key + " = " + metadatoExtended + "." + key;
												addend = true;
											}
										}
										var schema = GetSchemaByTable(table, allfields, connection, false);
										var q = "select * from " + (!string.IsNullOrWhiteSpace(schema) ? schema + "." : "") + table + joinstring;
										if (allfields.Any(af => af.Name == "active" && af.Table == table))
											q += " where active = 'S'";
										SqlCommand cmdTest = new SqlCommand(q, HDSGen.extConn);
										cmdTest.CommandTimeout = 120;
										var dataReaderTest = cmdTest.ExecuteReader();
										var colonneTest = new DataTable();
										colonneTest.Load(dataReaderTest);
										if (colonneTest.Rows.Count > 0) {
											string val = "";
											foreach (var k in parentkeys) {
												var intout = 0;
												if (Int32.TryParse(colonneTest.Rows[0][k].ToString(), out intout))
													val += "\t\t\t\t\t\t\"" + k + "\": " + intout.ToString() + ",\r\n";
												else
													val += "\t\t\t\t\t\t\"" + k + "\": \"" + colonneTest.Rows[0][k].ToString() + "\",\r\n";
											}

											var parameters = "var callPrm = {\r\n" + val +
												  "\t\t\t\t\t\t\"parent_tableName\": \"" + parentEntity.Name.Substring(2) + "\",\r\n" +
												  "\t\t\t\t\t\t\"parent_editType\": \"" + parentEntity.EditListingType + "\"\r\n" +
												  "\t\t\t\t\t};\r\n" +
												  "\t\t\t\t\t// chiamo funzione parametrica\r\n" +
												  "\t\t\t\t\ttestCase.testMetaPage_pageCallerButton(tablename, edittype, arrayInput, callPrm)\r\n" +
												  "\t\t\t\t\t.then(function () {\r\n" +
												  "\t\t\t\t\t\tdone();\r\n" +
												  "\t\t\t\t\t});\r\n";
											ReplaceStringInFile(fullPathTest, "//parameterFunction", parameters, true);
										}
										else
											ConsoleWriter.ErrorDB("Impossibile costruire il test per la pagina generata dal bottone " +
												(!string.IsNullOrWhiteSpace(extendedObject) ? extendedObject : o.Table) + "_" + editListingTypes);
									}

									//replace finale del test corretto
									if (string.IsNullOrWhiteSpace(testCase))
										testCase = (o.IsTree && o.Principale == "S") ? "testMetaPageCaseTree1" : "testMetaPageCase1";

									// funzione parametrica
									var testFunction = "{0}// chiamo funzione parametrica\r\n\t\t\t\t\t{1}" + testCase + "(tablename, edittype, arrayInput)" +
														"\r\n\t\t\t\t\t\t.then(function () {{\r\n\t\t\t\t\t\t\tdone();\r\n\t\t\t\t\t\t}});";


									ReplaceStringInFile(fullPathTest, "//parameterFunction", !string.IsNullOrEmpty(o.TestcustomText) ? "var " + testCase + " = " + o.TestcustomText
										+ String.Format(testFunction, "\r\n\r\n\t\t\t\t\t", string.Empty) :
										  String.Format(testFunction, string.Empty, "testCase."), true);



									//CREAZIONE TEST -------------------------------------------------------------------------------------------------------end 

									//VALIDAZIONE DI PAGINA + GENERAZIONE METADATO------------------ begin

									//calcolo le stringhe di validazione di pagina
									var isValid = new List<string>();

									//li metto in ordine di visualizzazione nella pagina
									foreach (var f in fields.Where(fi => fi.Name != "ct" && fi.Name != "lt" && fi.Name != "cu" && fi.Name != "lu").OrderBy(fi => fi.Sort)) {
										//validazione campi nulli (anche NON visibili)
										if (!f.Allownull) {
											if (!f.Name.StartsWith("XX")) {
												if (f.DenyNull)
													SetAfterlink(fullPathMetaPageJS, "this.setDenyNull(\"" + f.Table + (f.ForceAlias > 0 && f.Table != mainObject ? //l'alias sulla tabella principale non ci sta
														"_alias" + f.ForceAlias.ToString() : "") + "\",\"" + f.Name + "\");\r\n");
											}
											else {
												//valido la presenza del numero di righe
												isValid.Add("\t\t\t\tif (rowToCheck.table.dataset.tables[\"" + f.Name.Substring(2) + "\"] && rowToCheck.table.dataset.tables[\"" +
																  f.Name.Substring(2) + "\"].rows.length < " + f.Numrowsmandatory + ") {\r\n" +
															"\t\t\t\t\tfirstErrorObj = { warningMsg: \"\", errMsg: loc.getMinNumRowRequired(\"" + f.Title + "\", " + f.Numrowsmandatory +
																  "), errField: \"" + f.Name + "\", row: rowToCheck };\r\n" +
															"\t\t\t\t\treturn def.resolve(firstErrorObj);\r\n" +
															"\t\t\t\t}\r\n" + "//$isValidArray$");
											}
										}
									}

									//aggiungo l'isvalid personalizzato javascript
									if (!string.IsNullOrEmpty(o.IsValid))
										isValid.Add(o.IsValid + "\r\n\t\t\t\t//$isValid$");

									if (isValid.Any()) {
										ReplaceStringInFile(fullPathMetaPageJS, "//isValidFunction\r\n", @"manageValidResult: function (rowToCheck) {
				var loc = appMeta.localResource;
				var def = appMeta.Deferred(""isValid-meta_" + o.Table + @""");
				var firstErrorObj;

//$isValid$
				
				return  MetaPage.prototype.manageValidResult.call(this, rowToCheck);
			},
");
									}

									foreach (var iv in isValid)
										ReplaceStringInFile(fullPathMetaPageJS, "//$isValid$", iv);

									//VALIDAZIONE DI PAGINA ------------------ end


									//CAMPI CALCOLATI-------------------------- begin

									//se ÃƒÂ¨ un campo calcolato aggiungo la funzione per calcolarlo e la sua chiamata nella afterGetFormData 
									//e nella before fill se visibile
									foreach (var fi in fields.OrderBy(f => f.Sort)) {
										var nametag = fi.Table + "_" + fi.EditListingType + "_" + fi.Name.Replace("!", "");
										if (!string.IsNullOrWhiteSpace(fi.Calculatedfieldfunction)) {
											SetAfterGetFormData(fullPathMetaPageJS, "this.manage" + nametag + "()", o.Table, editListingTypes, false);
											if (fi.Calculatedfieldfunction.Contains("appMeta.Deferred")) {
												SetBeforeFillAsinc(fullPathMetaPageJS, "arraydef.push(this.manage" + nametag + "());\r\n", o.Table, editListingTypes, false, true);
											}
											else {
												SetBeforeFill(fullPathMetaPageJS, "this.manage" + nametag + "();\r\n", o.Table, editListingTypes, false);
											}
											SetBottomCode(fullPathMetaPageJS, "manage" + nametag + ": function () {\r\n" + fi.Calculatedfieldfunction + "\r\n\t\t\t}");
										}
									}
									//CAMPI CALCOLATI-------------------------- end

									//---------------------------------------------------------------------HTML------------------------------------------------------------------------------------
									var childColumns = new List<childColumn>();
									var fullTables = new List<String>();

									Console.WriteLine("2.6) CREO LA METAPAGE HTML");

									//-copio e rinomino il template della metapage html nella cartella della metapage
									var fullPathMetaPageHtml = clientFolder + metapageFolder + container + "/" + (!string.IsNullOrEmpty(extendingObject) ? extendedObject : o.Table) + "_" + editListingTypes + ".html";
									Copy("../../metapage_template/tabella_edittype.html", fullPathMetaPageHtml, true);

									//-aggiungo tutti i campi su due colonne

									var tabs = new List<tab>();
									foreach (var fi in fields)
										if (!tabs.Any(t => t.Title == fi.Tab))
											tabs.Add(new tab { Title = fi.Tab, Sort = fi.Tabposition, Icon = fi.Icon, Tabheader = fi.Tabheader });
									var tabString = "";
									var formString = "<form>\r\n";

									if (o.IsTree && o.Principale == "S") {
										formString += "\t<div class=\"row\">\r\n" +
											"\t\t<div class=\"col-md-4\" style=\"background-color: white; align-self:flex-start\">\r\n" +
											"\t\t\t<div id=\"menuweb_upb\" data-tag=\"" + o.Table + "." + o.EditListingType + "\" data-custom-control=\"tree\"></div>\r\n" +
											"\t\t</div>\r\n" +
											"\t\t<div class=\"col-md-8\"  style=\"background-color: white; align-self:flex-start\">\r\n" +
											"\t\t<ul class=\"nav nav-tabs\">\r\n" +
											"\t\t\t<!--tabStringTree-->\r\n" +
											"\t\t</ul>\r\n";
									}

									formString += (tabs.Count == 1 ? "" : "<div class=\"tab-content mt-2\">\r\n");

									//per ogni tab in ordine ...
									foreach (var tab in tabs.OrderBy(t => t.Sort)) {

										Console.Write(".");

										var isgrid = false;
										var isunique = fields.Where(f => f.Tab == tab.Title).Count() == 1;

										//se ÃƒÂ¨ una relazione 1 a 1 con campi affogati nella pagina NON devo inserire la griglia e il suo tab
										var skipall = false;
										if (isunique) {
											var fi = fields.Where(f => f.Tab == tab.Title).First();
											if (fi.RelationType == "unique")
												skipall = true;

										}
										if (!skipall) {

											if (!(tabs.Count == 1)) {
												//...aggiungo i tab in testa
												tabString += "	<li class=\"nav-item\">\r\n		<a href=\"#tab" + o.Table + "_" + editListingTypes + "_" + tabs.IndexOf(tab).ToString() +
													"\" class=\"nav-link" + (tab.Title.Trim() == "Principale" ? " active show" : "") + "\" data-toggle=\"pill\" data-target=\"#tab" +
													o.Table + "_" + editListingTypes + "_" + tabs.IndexOf(tab).ToString() +
													"\"><i class=\"fa " + tab.Icon + " mr-1\"></i>" + tab.Title + "</a>\r\n	</li>\r\n";

												//...aggiungo l'etichetta del titolo del tab
												ReplaceStringInLocalResourceFile(RegionMarker.LocalResource_nomiTab, "\"#tab" + o.Table + "_" + editListingTypes, "_" + tabs.IndexOf(tab).ToString() + "\"", tab.Title.Replace("\r\n", "").Replace("'", "\\'"));
												//...apro il tab
												formString += "	<div class=\"tab-pane fade" + (tab.Title.Trim() == "Principale" ? " active show" : "") + "\" id=\"tab" + o.Table + "_" + editListingTypes + "_" + tabs.IndexOf(tab).ToString() + "\" role=\"tabpanel\">\r\n";

												if (!string.IsNullOrWhiteSpace(tab.Tabheader)) {
													//aggiungo il testo del tab
													formString += "\t<div class=\"custom_lng_div\" data-langkey=\"tablabel" + o.Table + "_" + editListingTypes + "_" + tabs.IndexOf(tab).ToString() + "\" >" + tab.Tabheader + "</div>\r\n";

													//...aggiungo l'etichetta del testo del tab
													ReplaceStringInLocalResourceFile(RegionMarker.LocalResource_labels, "tablabel" + o.Table + "_" + editListingTypes, "_" + tabs.IndexOf(tab).ToString(), tab.Tabheader.Replace("\"", "\\\"").Replace("\r", "").Replace("\n", "").Replace("'", "\\'"));
												}

											}

											//aggiungo i bottoni
											if (buttonFields.Any(bt => bt.Tab == tab.Title && bt.Position == "U")) {
												foreach (var b in buttonFields.Where(bt => bt.Tab == tab.Title && bt.Position == "U"))
													formString += " <button id=\"" + b.Name + "\" type=\"button\" class=\"btn btn-primary p-2 mt-2\" >\r\n        <i class=\"fa " + b.Icon + " mr-1\" ></i>" + b.Title + "\r\n    </button>\r\n";
											}

											//se ÃƒÂ¨ un unico campo nel tab per una entitÃƒÂ  figlia ...
											if (isunique) {
												var fi = fields.Where(f => f.Tab == tab.Title).First();
												if (fi.Name.StartsWith("XX")) {
													isgrid = true;

													formString += GetGrid(o, tab, fi, fields, subfields, allfields, fullPathMetaPageJS, string.IsNullOrWhiteSpace(fullPathTestParams) ? fullPathTest : fullPathTestParams,
														false, childColumns, objects, HDSGen.extConn);
												}
											}
											//altrimenti
											if (!isgrid) {
												var isInverted = false;
												var position = 1;
												//per ogni campo del tab
												foreach (var fi in fields.Where(f => f.Tab == tab.Title && f.Detailvisible).OrderBy(f => f.Sort)) {

													Console.Write(".");

													if (fi.RelationType != "button") {
														var classtag = fi.Table + "_" + fi.EditListingType;
														var valuetag = "_" + fi.Name.Replace("!", "");
														var nametag = fi.Table + "_" + fi.EditListingType + "_" + fi.Name.Replace("!", "");
														var datatag = fi.Table + (fi.ForceAlias > 0 && fi.Table != mainObject ? "_alias" + fi.ForceAlias.ToString() : "") + "." + fi.Name;

														//...aggiungo l'etichetta per la label
														var labelString = "		" + (nametag.Contains("!") ? "\"" + nametag + "\"" : nametag) + ": \"" +
														fi.Title.Replace("\r\n", "").Replace("'", "\\'") + "\",\r\n";

														ReplaceStringInLocalResourceFile(RegionMarker.LocalResource_labelSuHtml, (nametag.Contains("!") ? "\"" : "") + classtag, valuetag + (nametag.Contains("!") ? "\"" : ""),
														fi.Title.Replace("\r\n", "").Replace("'", "\\'"));

														if (fi.Hidden) {
															formString += "					<input hidden id=\"" + nametag + "\" type=\"text\" class=\"form-control\" " + "data-tag=\"" + datatag + "\" />\r\n";
														}
														else {

															var format = "";
															if (fi.Type == "datetime")
																format = ".g";

															//il tag di ricerca chiude anche le virgolette
															var searchtag = format + "\" ";
															//lo devo aggiungere ogniqualvolta io abbia creato una vista sul db per una pagina principale, 
															//perchÃƒÂ¨ le query di ricerca sono solo sulle pagine principali e subiscono il web_listredir e cercano sulla vista 
															if (viewFields.Any() && createDbView) {
																searchtag = format + "?" + viewName + "." + (string.IsNullOrEmpty(fi.ViewAlias) ? fi.Name : fi.ViewAlias) + format + "\" data-subentity ";
															}
															else {
																if (fi.Table != o.Table) {
																	searchtag = format + "\" data-subentity ";
																}
															}

															//se sono di sola lettura 
															//ma se sono chiavi giÃƒÂ  lo sono per definizione quindi non serve 
															//oppure se si tratta di radiobutton che vanno disabilitati singolarmente
															if ((fi.Readonlyfield && !fi.IsKey && !(fi.Type == "char" && fi.Len == 1)))
																SetReadonly(fi, nametag, fullPathMetaPageJS, o, editListingTypes);

															//se text, nvarchar(max) o forzato a textarea scrivo su una colonna sola:
															if (IsTextArea(fi)) {
																//-se destro:  
																if (!IsSinistro(position, isInverted)) {
																	//chiudo colonna e chiudo riga;
																	formString += "				</div>\r\n			</div>\r\n";
																}
																else {
																	//-altrimenti scambio sinistri con destri
																	isInverted = !isInverted;
																}
																//-apro riga, apro colonna 12, disegno textarea, chiudo colonna, chiudo riga

																formString += "			<div class=\"row\">\r\n				<div class=\"col-md-12\">\r\n";

																if (!string.IsNullOrWhiteSpace(fi.Text.Trim())) {
																	//aggiungo il testo per il campo 
																	formString += "\t\t\t\t\t<div class=\"custom_lng_div\" data-langkey=\"fieldlabel" + nametag + "\" >" + fi.Text + "</div>\r\n";

																	//...aggiungo l'etichetta del testo del campo
																	ReplaceStringInLocalResourceFile(RegionMarker.LocalResource_labels, "fieldlabel" + classtag, valuetag,
																		fi.Text.Replace("\"", "\\\"").Replace("\r", "").Replace("\n", "").Replace("'", "\\'"));

																}


																formString += "					<label class=\"col-form-label col-md-12\" for=\"" + nametag + "\">" + fi.Title + "</label>\r\n" +
																	  "					<textarea class=\"textarea form-control\" id=\"" + nametag + "\" type=\"text\" " + " rows=\"" + (isunique ? "20" : "4") + "\" " + "data-tag=\"" +
																	  datatag + searchtag + " " + (fi.Allownull ? "" : "data-mandatory ") + "></textarea>\r\n" +
																	  "				</div>\r\n			</div>\r\n";

																//test
																if (!fi.Name.StartsWith("!"))
																	ReplaceStringInFile(string.IsNullOrWhiteSpace(fullPathTestParams) ? fullPathTest : fullPathTestParams, "//arrayInput\r\n",
																		(o.Principale == "S" ? "" : "this.") + "arrayInput.push({ tag: '" +
																		datatag + searchtag.Replace("\" data-subentity ", "").Replace("\" ", "") + "', value: " + (string.IsNullOrWhiteSpace(fi.Testvalue) ? "testHelper.getRandomStringTest()" : fi.Testvalue) + ", type: controlTypeEnum.textarea" +
																		(!string.IsNullOrEmpty(fi.Defaultvalue) ? ", default: " + fi.Defaultvalue + " " : "") + " });\r\n" + (o.Principale == "S" ? "\t\t\t" : "") + "\t\t//arrayInput\r\n");


															}
															else {
																//------------------------------------------------------begin
																//altrimenti verifico che non sia richiesta l'unicitÃƒÂ  sulla riga
																if (fi.UniqueOnRow) {
																	//-se destro:  
																	if (!IsSinistro(position, isInverted)) {
																		//chiudo colonna e chiudo riga;
																		formString += "				</div>\r\n			</div>\r\n";
																	}
																	else {
																		//-altrimenti scambio sinistri con destri
																		isInverted = !isInverted;
																	}
																	//-apro riga, apro colonna 12, disegno textarea, chiudo colonna, chiudo riga

																	formString += "			<div class=\"row\">\r\n				<div class=\"col-md-12\">\r\n";
																}
																else {
																	//------------------------------------------------------end
																	//altrimenti scrivo su due colonne:

																	//apertura colonna
																	if (IsSinistro(position, isInverted)) {
																		//-se sinistro: apro riga, apro colonna
																		formString += "			<div class=\"row\">\r\n				<div class=\"col-md-6\">\r\n";
																	}
																	else {
																		//-altrimenti: chiudo colonna, apro colonna 6
																		formString += "				</div>\r\n";
																		formString += "				<div class=\"col-md-6\">\r\n";
																	}
																	//------------------------------------------------------begin
																}
																//------------------------------------------------------end

																if (!string.IsNullOrWhiteSpace(fi.Text.Trim())) {
																	//aggiungo il testo per il campo 
																	formString += "\t\t\t\t\t<div class=\"custom_lng_div\" data-langkey=\"fieldlabel" + nametag + "\" >" + fi.Text + "</div>\r\n";

																	//...aggiungo l'etichetta del testo del campo
																	var labelTextField = "		fieldlabel" + nametag + ": \"" + fi.Text.Replace("\"", "\\\"").Replace("\r", "").Replace("\n", "").Replace("'", "\\'") + "\",\r\n";

																	ReplaceStringInLocalResourceFile(RegionMarker.LocalResource_labels, "fieldlabel" + classtag, valuetag, fi.Text.Replace("\"", "\\\"").Replace("\r", "").Replace("\n", "").Replace("'", "\\'"));
																}

																//se ÃƒÂ¨ una griglia affogata nella pagina la disegno ora
																if (fi.Name.StartsWith("XX")) {
																	formString += GetGrid(o, tab, fi, fields, subfields, allfields, fullPathMetaPageJS, string.IsNullOrWhiteSpace(fullPathTestParams) ? fullPathTest : fullPathTestParams,
																		false, childColumns, objects, HDSGen.extConn);
																}
																else {
																	//-disegno il campo :
																	//se ÃƒÂ¨ una chiave in genere, 
																	//ma non ÃƒÂ¨ la chiave dell'oggetto (quella specifica per la tabella, le chiavi derivate dagli ancestor invece, se visibili, vengono prese) 
																	//oppure ÃƒÂ¨ chiave dell'oggetto ma ÃƒÂ¨ una tabella di collegamento
																	if (HaveKeyName(fi) && (!IsPrincipalKey(fi, o.Table) || isLinkingObj)) {

																		//Campo upload per gli allegati
																		if (fi.Name.StartsWith("idattach")) {
																			formString += "					<label class=\"col-form-label col-md-12\" for=\"" + nametag + "\">" + fi.Title + "</label>\r\n" +
																				 "					<div id=\"" + nametag + "\" " + "data-tag=\"" + datatag + searchtag + " data-custom-control=\"upload\" " +
																								(fi.Allownull ? "" : "data-mandatory ") + "></div>\r\n";

																			//test
																			SetArrayInputTest(string.IsNullOrWhiteSpace(fullPathTestParams) ? fullPathTest : fullPathTestParams,
																			"{ tag: '" + datatag + searchtag.Replace("\" data-subentity ", "").Replace("\" ", "") + "', type: controlTypeEnum.upload }", fi);
																		}
																		else {
																			var ex = GetException(null, null, fi.Table, fi.Name);

																			var metadatoChild = ex != null ? ex.Item1 : GetTableById(fi.Name, allfields, connection);

																			if (!string.IsNullOrEmpty(metadatoChild)) {

																				var listtype = !string.IsNullOrEmpty(fi.Listtype) ? fi.Listtype : "default";

																				//scorro i campi e scelgo title, se no description, se no il campo testuale piÃƒÂ¹ piccolo ma >1 da indicare come:
																				//1- campo testuale nelle tendine
																				//2- campo da considerare nelle viste nella ricerca per gli oggetti 
																				var txtField = GetTextFieldByTable(metadatoChild, allfields, connection, ex != null, (listtype != "default" ? listtype : null)).FirstOrDefault(); //il get missing non serve perchÃƒÂ© lo ha giÃƒÂ  fatto poco prima il GetTableById

																				SetMetadatoChild(fields, fi, metadatoChild, ref allfields, connection);

																				var metadatochildWithText = belongsToOtherTable(metadatoChild, txtField) ? fi.MetadatoExtendedChild : fi.MetadatoChild;

																				if (IsDropdown(fi, metadatochildWithText)) {

																					var sourcetable = metadatochildWithText;
																					var sourcetablekey = GetPrincipalKey(metadatochildWithText, "", allfields, connection, false);

																					//se l'oggetto ha piÃƒÂ¹ chiavi e non ho scelto quella principale
																					if (!fi.Name.Contains(sourcetablekey.Name)) {
																						sourcetablekey = GetIdFieldsByTable(metadatochildWithText, allfields, connection)
																							.FirstOrDefault(x => fi.Name.Split('_')[0] == x.Name) ?? sourcetablekey;
																					}

																					var sourceDisplayMember = txtField.Name;

																					//oggetto che userebbe una dropdowngrid ma usa una dropdown normale
																					if (HaveView(sourcetable, listtype, ref allfields, connection)) {
																						var metadatochildWithTextOriginal = RemoveAlias(metadatochildWithText);
																						var alias = GetAlias(metadatochildWithText);
																						sourcetable = metadatochildWithTextOriginal + listtype + "view" + (string.IsNullOrWhiteSpace(alias) ? "" : "_alias" + alias);
																						sourceDisplayMember = "dropdown_title";

																						//riassegno il metadato alla vista, in modo da corstruirci gli alias se necessario
																						fi.MetadatoChild = null;
																						fi.MetadatoExtendedChild = null;
																						SetMetadatoChild(fields, fi, sourcetable, ref allfields, connection);
																					}

																					var addMaster = true;
																					if (IsAddictedDropdown(fi, ref allfields, connection)) {
																						//se utilizza come master una dropdowngrid oppure anche se ÃƒÂ¨ una dropdown ma ho una relazione personalizzata...

																						//ricavo il campo master della scheda (oggetto principale)
																						var masterField = fields.FirstOrDefault(ff =>
																									ff.MetadatoChild == fi.Master && (!IsDropdown(ff) || !string.IsNullOrWhiteSpace(fi.AfterRowSelectPrefill)));

																						if (masterField != null) {
																							//ricavo il campo corrispondente al campo master sull'oggetto slave, che potrebbe essere una vista
																							//GetMissingFields(fi.MetadatoChild, null, ref allfields, connection);
																							//var slaveField = allfields.Where(af => af.Table == fi.MetadatoChild && af.Name.StartsWith(masterField.Name.Split('_')[0])).FirstOrDefault();
																							//if (slaveField == null)
																							//	slaveField = allfields.Where(af => af.Table == fi.MetadatoChild && af.Name.StartsWith(metadatochildWithText + "_" + masterField.Name.Split('_')[0])).FirstOrDefault();
																							//if (slaveField == null) {
																							//	ConsoleWriter.ErrorDB("Non trovo il corrispettivo del campo master " + masterField.Table + "." + masterField.Name + " sulla tabella slave " + fi.MetadatoChild + " per costruire le due dropdown a cascata");
																							//	slaveField = masterField;
																							//}
																							var slaveField = masterField;
																							var slaveField2 = GetChildKeysbyMaster(fi.Master, GetFields(fi.MetadatoChild, fi.Listtype, ref allfields, connection), allfields, connection, !string.IsNullOrWhiteSpace(fi.AfterRowSelectPrefill));
																							if (slaveField2.Count() == 2)
																								slaveField = slaveField2[1];
																							//...devo filtrare la dropdown detail quando scelgo il valore, o nelle pagine principali quando le apro
																							SetAfterRowSelect(fullPathMetaPageJS, null,
																							"if (t.name === \"" + fi.Master + "\" && r !== null) {\r\n" +
																							(string.IsNullOrWhiteSpace(fi.AfterRowSelectPrefill) ?
																							  "\t\t\t\t\tappMeta.metaModel.cachedTable(this.getDataTable(\"" + fi.MetadatoChild + "\"), false);\r\n" +
																							  "\t\t\t\t\tvar " + nametag + "Ctrl = $('#" + nametag + "').data(\"customController\");\r\n" +
																							  "\t\t\t\t\tarraydef.push(" + nametag + "Ctrl.filteredPreFillCombo(window.jsDataQuery.eq(\"" + slaveField.Name/*.Split('_')[0]*/ +
																							  "\", r ? r." + masterField.Name.Split('_')[0] + " : null), null, true)\r\n" +
																							  "\t\t\t\t\t\t.then(function (dt) {\r\n" +
																							  "\t\t\t\t\t\t\tif (self.state.currentRow && self.state.currentRow." + fi.Name + ")\r\n" +
																							  "\t\t\t\t\t\t\t\t" + nametag + "Ctrl.fillControl(null, self.state.currentRow." + fi.Name + ");\r\n" +
																							  "\t\t\t\t\t\t\treturn true;\r\n" +
																							  "\t\t\t\t\t\t})\r\n" +
																							  ");\r\n"
																							  : fi.AfterRowSelectPrefill + "\r\n") +
																							"\t\t\t\t}\r\n"
																							, o.Table, editListingTypes);

																							//1-appena apro avviso il dropdown di non riempirlo subito
																							SetAfterlink(fullPathMetaPageJS,
																								"appMeta.metaModel.cachedTable(this.getDataTable(\"" + fi.MetadatoChild + "\"), true);\r\n" +
																								"\t\t\t\tappMeta.metaModel.lockRead(this.getDataTable(\"" + fi.MetadatoChild + "\"));\r\n");

																							//... o nelle pagine secondarie quando le apro
																							if (o.Principale != "S") {
																								//2-dopo poco durante l'apertura applico il filtro impostato in base al master

																								SetAfterActivation(fullPathMetaPageJS, null,
																								"if (parentRow." + masterField.Name + ") {\r\n" +
																								(string.IsNullOrWhiteSpace(fi.AfterActivationPrefill) ?
																									"\t\t\t\t\tappMeta.metaModel.cachedTable(this.getDataTable(\"" + fi.MetadatoChild + "\"), false);\r\n" +
																									"\t\t\t\t\tvar " + nametag + "Ctrl = $('#" + nametag + "').data(\"customController\");\r\n" +
																									"\t\t\t\t\tarraydef.push(" + nametag + "Ctrl.filteredPreFillCombo(window.jsDataQuery.eq(\"" + slaveField.Name/*.Split('_')[0] NON SERVE PIU'*/ +
																									"\", parentRow." + masterField.Name + "), null, true));\r\n"
																								: fi.AfterActivationPrefill + "\r\n") +
																								"\t\t\t\t}\r\n"
																								, o.Table, editListingTypes);

																							}

																							addMaster = false;
																						}
																						else {
																							ConsoleWriter.Info("Caso di due dropdown a cascata oppure tabella " + fi.Master + " non trovata nel dataset per costruire la dropdown a cascata del campo " + fi.Name + ".");
																						}
																					}
																					else
																						addMaster = false;

																					//campo di ordinamento diverso dal display-member
																					var sortmember = "";
																					if (fi.IdAppFieldDetail_sortmember != null) {
																						var sortfield = allfields.Where(af => af.IdAppFieldDetail == fi.IdAppFieldDetail_sortmember);
																						if (sortfield.Any())
																							sortmember = "data-sort-member=\"" + sortfield.First().Name + "\" ";
																					}

																					formString += "					<label class=\"col-form-label col-md-12\" for=\"" + nametag + "\">" + fi.Title + "</label>\r\n" +
																					"					<select id=\"" + nametag + "\" class=\"custom-select d-block w-100\" " +
																					" data-source-name=\"" + fi.MetadatoChild + "\" data-value-member=\"" + sourcetablekey.Name + "\" data-display-member=\"" + sourceDisplayMember + "\" " + sortmember +
																					"data-custom-control=\"combo\" data-tag=\"" +
																					datatag + searchtag + " " + (fi.Allownull ? "" : "data-mandatory ") + " " + (addMaster ? "data-master=\"" + fi.Master + "\"" : "") + "> </select>\r\n";

																					//test
																					var testVal = string.IsNullOrWhiteSpace(fi.Testvalue) ? "null" : fi.Testvalue;
																					SetArrayInputTest(string.IsNullOrWhiteSpace(fullPathTestParams) ? fullPathTest : fullPathTestParams,
																						"{ tag: '" + datatag + searchtag.Replace("\" data-subentity ", "").Replace("\" ", "") + "', value: " + testVal + ", type: controlTypeEnum.select" +
																						(!string.IsNullOrEmpty(fi.Defaultvalue) ? ", default: " + fi.Defaultvalue + " " : "") + " }", fi);
																				}
																				else {
																					//Autochoose
																					//formString += WriteAutochoose(o, editListingTypes, tab, fi, fields, allfields, objects, nametag, metadatoChild,
																					//	listtype, metadatochildWithText, txtField, fullPathMetaPageJS, fullPathTest, fullPathTestParams, connection);


																					formString += WriteDropdowngrid(o, editListingTypes, tab, fi, fields, allfields, objects, nametag, metadatoChild,
																						listtype, metadatochildWithText, txtField, fullPathMetaPageJS, fullPathTest, fullPathTestParams, HDSGen.extConn);
																				}

																				if (!string.IsNullOrWhiteSpace(fi.TableFilter)) {
																					//inserisco il filtro sulla tabella all'interno dell'afterlink
																					SetAfterlink(fullPathMetaPageJS, "this.state.DS.tables." + fi.MetadatoChild +
																						".staticFilter(window.jsDataQuery." + fi.TableFilter + ");\r\n");
																				}

																				//se ÃƒÂ¨ un id della tabella ma anche di un parent ...
																				if (fi.IsKey && !fi.Readonlyfield) {
																					//...verrebbe disabilitato quindi lo riabilito in fase di inserimento finchÃƒÂ¨ non ha figli
																					SetAfterRowSelect(fullPathMetaPageJS, "$('#" + nametag + "').prop(\"disabled\", this.state.isEditState() || this.haveChildren());\r\n\t\t\t\t$('#" +
																						nametag + "').prop(\"readonly\", this.state.isEditState() || this.haveChildren());\r\n", null, o.Table, editListingTypes);

																					//...se dipende da un altro campo anche l'altro campo segue la stessa logica di abilitazione
																					if (!string.IsNullOrWhiteSpace(fi.Master)) {
																						var masterTable = fi.Master.Replace("defaultview", "");
																						var masterkeys = GetPrincipalKey(masterTable, null, allfields, connection, true);
																						var masterField = fields.Where(f => f.Name == masterkeys.Name && f.Detailvisible).FirstOrDefault();
																						if (masterField != null) {
																							var masterNametag = masterField.Table + "_" + masterField.EditListingType + "_" + masterField.Name;

																							SetAfterRowSelect(fullPathMetaPageJS, "$('#" + masterNametag + "').prop(\"disabled\", this.state.isEditState() || this.haveChildren());\r\n\t\t\t\t$('#" +
																								masterNametag + "').prop(\"readonly\", this.state.isEditState() || this.haveChildren());\r\n", null, o.Table, editListingTypes);
																						}

																					}


																					//...blocco l'inserimento di subentitÃƒÂ  finchÃƒÂ¨ non l'ho selezionato
																					SetInsertClick(fullPathMetaPageJS, "if (!$('#" + nametag + "').val() && this.children.includes(grid.dataSourceName)) {\r\n" +
																						"\t\t\t\t\treturn this.showMessageOk('Prima devi selezionare un valore per il campo " + fi.Title.Replace("'", "\\'") + "');\r\n" +
																						"\t\t\t\t}\r\n");

																					//...aggiungo il codice per gestione dei figli
																					SetBottomCode(fullPathMetaPageJS, "children: ['" + string.Join("', '",
																						fields.Where(f => f.Name.StartsWith("XX")).OrderBy(f => f.Name).Select(f =>
																						IsExtendingObject(f.Name.Substring(2), ref allfields, connection) ? f.MetadatoExtendedChild ?? f.Name.Substring(2).Split('_')[0] : f.MetadatoChild ?? f.Name.Substring(2)
																						)) + "'],\r\n" +
																						"			haveChildren: function () {\r\n" +
																						"				var self = this;\r\n" +
																						"				return _.some(this.children, function (child) {\r\n" +
																						"					if (child !== '')\r\n" +
																						"						return !!self.getDataTable(child).rows.length;\r\n" +
																						"					else\r\n" +
																						"						return false;\r\n" +
																						"				});\r\n" +
																						"			}");

																					//... se c'ÃƒÂ¨ un figlio 1 a 1 devo aggiungere la copia del valore anche nella sua chiave corrispondente
																					foreach (var child in fields.Where(f => f.Name.StartsWith("XX") && fi.RelationType == "unique")) {
																						var tablechild = child.MetadatoChild ?? child.Name.Substring(2);
																						SetAfterRowSelect(fullPathMetaPageJS, "if (t.name === '" + fi.MetadatoChild + "' && r !== null)\r\n" +
																						"					if (this.state.DS.tables['" + tablechild + "'].rows.length)\r\n" +
																						"						this.state.DS.tables['" + tablechild + "'].rows[0]." + fi.Name + " = r." + fi.Name + ";\r\n", null, o.Table, editListingTypes);
																					}

																					//... se c'ÃƒÂ¨ un estendente devo aggiungere la copia del valore anche nella sua chiave corrispondente
																					if (isExtendedObjView) {
																						var child = fields.Where(f => f.Table == o.Table && f.Name == fi.Name.Split('_')[0] && f.IsKey).FirstOrDefault();
																						if (child != null)
																							SetAfterRowSelect(fullPathMetaPageJS, "if (t.name === '" + fi.MetadatoChild + "' && r !== null)\r\n" +
																							"					if (this.state.DS.tables['" + currentTable + "'].rows.length)\r\n" +
																							"						this.state.DS.tables['" + currentTable + "'].rows[0]." + child.Name + " = r." + fi.Name.Split('_')[0] + ";\r\n", null, o.Table, editListingTypes);

																					}

																					//NON PIU' NECESSARIO
																					////in generale devo aggiungere al meta che di default ÃƒÂ¨ 0 o "" (a seconda del tipo) e non null altrimenti il serializzatore sdoppia le righe

																					//var getNewRowDefaultValue = string.Format("{0} : {1},\r\n\t\t\t\t\t//$getNewRowDefault$\r\n", fi.Name, !IsTextField(fi) ? "0" : "\"\"");

																					//ReplaceStringInFile(fullPathMetaDatoJS, "//$getNewRowDefault$\r\n", getNewRowDefaultValue);

																				}

																			}
																			else {
																				//il campo cominciava per id ma in realtÃƒÂ  non era l'indice di alcuna tabella, quindi lo tratto come un campo normale
																				//textbox
																				formString += "					<label class=\"col-form-label col-md-12\" for=\"" + nametag + "\">" + fi.Title + "</label>\r\n" +
																						 "					<input id=\"" + nametag + "\" type=\"text\" class=\"form-control\" " + "data-tag=\"" + datatag + searchtag + (fi.Allownull ? "" : " data-mandatory ") + "/>\r\n";
																			}
																		}

																	}
																	else {

																		if (fi.Type == "char" && fi.Len == 1) {
																			if (string.IsNullOrEmpty(fi.Radiovalues)) {
																				if (fi.IsCheckbox) {
																					//checkbox SI NO
																					formString += "					<label class=\"col-form-label col-md-12\" for=\"" + nametag + "\">" + fi.Title + "</label>\r\n" +
																							 "					<input id=\"" + nametag + "\" type=\"checkbox\" class=\"custom-control-input big-checkbox\" " +
																												"data-tag=\"" + datatag + ":S:N" + (searchtag == "\" " ? searchtag : searchtag.Replace("\" ", ":Si:No\" ")) +
																							 (fi.Allownull ? "" : " data-mandatory=\"S\" ") + "/>\r\n";

																					//test
																					SetArrayInputTest(string.IsNullOrWhiteSpace(fullPathTestParams) ? fullPathTest : fullPathTestParams,
																					"{ tag: '" + datatag + ":S:N" + (searchtag == "\" " ? "" : searchtag.Replace("\" ", ":Si:No\" ").Replace("\" data-subentity ", "").Replace("\" ", "")) +
																					"', value: true, type: controlTypeEnum.inputCheck" + (!string.IsNullOrEmpty(fi.Defaultvalue) ? ", default: " + fi.Defaultvalue + " " : "") + " }", fi);

																					SetReadonly(fi, nametag, fullPathMetaPageJS, o, editListingTypes);

																				}
																				else {
																					//radio SI NO
																					formString += "					<label class=\"col-form-label col-md-12\" for=\"" + nametag + "\">" + fi.Title + "</label>\r\n" +
																							 "					<div class=\"custom-control custom-radio\">\r\n" +
																							 "						<input id=\"" + nametag + "Si\" type=\"radio\" name=\"" + nametag + "\" class=\"custom-control-input\" " +
																												  "data-tag=\"" + datatag + ":S" + (searchtag == "\" " ? searchtag : searchtag.Replace("\" ", ":Si\" ")) + " " + (fi.Allownull ? "" : "data-mandatory ") +
																												  "><label for=\"" + nametag + "Si\"> Si</label>\r\n" +
																							 "						<input id=\"" + nametag + "No\" type=\"radio\" name=\"" + nametag + "\" class=\"custom-control-input\" " +
																												  "data-tag=\"" + datatag + ":N" + (searchtag == "\" " ? searchtag : searchtag.Replace("\" ", ":No\" ")) + " " + (fi.Allownull ? "" : "data-mandatory ") +
																												  "><label for=\"" + nametag + "No\"> No</label>\r\n" +
																							 "					</div>\r\n";

																					//...aggiungo l'etichetta per la label
																					ReplaceStringInLocalResourceFile(RegionMarker.LocalResource_labelSuHtml, (nametag.Contains("!") ? "\"" : "") + classtag, valuetag + "Si" + (nametag.Contains("!") ? "\"" : ""), "Si");
																					ReplaceStringInLocalResourceFile(RegionMarker.LocalResource_labelSuHtml, (nametag.Contains("!") ? "\"" : "") + classtag, valuetag + "No" + (nametag.Contains("!") ? "\"" : ""), "No");
																					//test
																					SetArrayInputTest(string.IsNullOrWhiteSpace(fullPathTestParams) ? fullPathTest : fullPathTestParams,
																					"{ tag: '" + datatag + ":S" + (searchtag == "\" " ? "" : searchtag.Replace("\" data-subentity ", "").Replace("\" ", "") + ":Si") +
																					"', value: true, type: controlTypeEnum.inputRadio" + (!string.IsNullOrEmpty(fi.Defaultvalue) ? ", default: " + fi.Defaultvalue + " " : "") + " }", fi);

																					SetReadonly(fi, nametag + "Si", fullPathMetaPageJS, o, editListingTypes);
																					SetReadonly(fi, nametag + "No", fullPathMetaPageJS, o, editListingTypes);

																				}
																			}
																			else {
																				//radio personalizzato
																				if (fi.Radiovalues.EndsWith(";"))
																					fi.Radiovalues = fi.Radiovalues.Substring(0, fi.Radiovalues.Length - 1);
																				var v = fi.Radiovalues.Split(';').ToList();
																				formString += "					<label class=\"col-form-label col-md-12\" for=\"" + nametag + "\">" + fi.Title + "</label>\r\n" +
																							"					<div class=\"custom-control custom-radio\">\r\n";
																				var testWritten = false;
																				foreach (var r in v)
																					if (v.IndexOf(r) % 2 == 0) {
																						formString += "						<input id=\"" + nametag + r + "\" type=\"radio\" name=\"" + nametag + "\" class=\"custom-control-input\" " + "data-tag=\"" +
																							datatag + ":" + r + (searchtag == "\" " ? searchtag : searchtag.Replace("\" ", ":" + v[v.IndexOf(r) + 1] + "\" ")) + " " +
																							(fi.Allownull ? "" : "data-mandatory ") + "><label for=\"" + nametag + r + "\"> " + v[v.IndexOf(r) + 1] + "</label>\r\n";

																						//...aggiungo l'etichetta per la label
																						var labelStringradio = "		" + (nametag.Contains("!") ? "\"" + nametag + r + "\"" : nametag + r) + ": \"" + v[v.IndexOf(r) + 1] + "\",\r\n";
																						//ReplaceStringInFile(clientFolder + "assets/i18n/LocalResourceIt.js", "// label su html\r\n", "// label su html\r\n" + labelStringradio);
																						ReplaceStringInLocalResourceFile(RegionMarker.LocalResource_labelSuHtml,
																						 (nametag.Contains("!") ? "\"" : "") + classtag, valuetag + r + (nametag.Contains("!") ? "\"" : ""), v[v.IndexOf(r) + 1]);

																						//test
																						if (!testWritten) {
																							testWritten = true;
																							SetArrayInputTest(string.IsNullOrWhiteSpace(fullPathTestParams) ? fullPathTest : fullPathTestParams,
																								"{ tag: '" + datatag + ":" + r + (searchtag == "\" " ? "" : searchtag.Replace("\" data-subentity ", "").Replace("\" ", "") + ":" + v[v.IndexOf(r) + 1]) +
																								"', value: true, type: controlTypeEnum.inputRadio" + (!string.IsNullOrEmpty(fi.Defaultvalue) ? ", default: " + fi.Defaultvalue + " " : "") + " }", fi);
																						}

																						SetReadonly(fi, nametag + r, fullPathMetaPageJS, o, editListingTypes);
																					}
																				formString += "					</div>\r\n";

																			}
																		}
																		else {
																			SetReadonly(fi, nametag, fullPathMetaPageJS, o, editListingTypes);

																			if (!string.IsNullOrWhiteSpace(fi.Specialcontrol)) {
																				switch (fi.Specialcontrol) {
																					//utilizzato con i campi ! per realizzare gli importer
																					case "T":
																						//tachimetro
																						formString += "					<label class=\"col-form-label col-md-12\" for=\"" + nametag + "\">" + fi.Title + "</label>\r\n" +
																								 "					<div id=\"" + nametag + "\" data-custom-control=\"tachimetro\" data-max=\"" + fi.Max + "\" data-th1=\"" + fi.Val1 + "\" data-th2=\"" + fi.Val2 +
																								 "\" data-tag=\"" + datatag +
																								 (fi.Type == "decimal" || fi.Type == "float" ?
																									 (fi.Name == "latitude" || fi.Name == "longitude" ?
																									 ".fixed.7" :
																										(fi.Len > 0 ?
																										".fixed." + fi.Len.ToString() :
																										".fixed.2"
																										)
																									 )
																								 : "")
																								 +
																								 searchtag + "></div>\r\n";
																						break;
																				}
																			}
																			else {
																				switch (fi.Type) {
																					//utilizzato con i campi ! per realizzare gli importer
																					case "file":
																						//datepicker
																						formString += "					<label class=\"col-form-label col-md-12\" for=\"" + nametag + "\">" + fi.Title + "</label>\r\n" +
																								 "					<input id=\"" + nametag + "\" type=\"file\" class=\"form-control\" " +
																								 " accept=\"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet\" />\r\n";
																						break;
																					case "date":
																						//datepicker
																						formString += "<script>\r\n  $( function () {\r\n    $(\"#" + nametag + "\").datepicker();\r\n  } );\r\n  </script>\r\n";
																						formString += "					<label class=\"col-form-label col-md-12\" for=\"" + nametag + "\">" + fi.Title + "</label>\r\n" +
																								 "					<input id=\"" + nametag + "\" type=\"text\" class=\"form-control\" " + "data-tag=\"" + datatag + searchtag + " " + (fi.Allownull ? "" : "data-mandatory ") + "/>\r\n";
																						//test
																						SetArrayInputTest(string.IsNullOrWhiteSpace(fullPathTestParams) ? fullPathTest : fullPathTestParams,
																						"{ tag: '" + datatag + searchtag.Replace("\" data-subentity ", "").Replace("\" ", "") + "', value: '01/01/2001', type: controlTypeEnum.inputText" +
																						(!string.IsNullOrEmpty(fi.Defaultvalue) ? ", default: " + fi.Defaultvalue + " " : "") + " }", fi);

																						break;
																					case "datetime": {
																						//datetimepicker
																						formString += "<script>\r\n  $( function () {\r\n    $(\"#" + nametag + "\").datetimepicker();\r\n  } );\r\n  </script>\r\n";
																						formString += "					<label class=\"col-form-label col-md-12\" for=\"" + nametag + "\">" + fi.Title + "</label>\r\n" +
																								 "					<input id=\"" + nametag + "\" type=\"text\" class=\"form-control\" " + "data-tag=\"" + datatag + searchtag + " " + (fi.Allownull ? "" : "data-mandatory ") + "/>\r\n";
																						//test
																						SetArrayInputTest(string.IsNullOrWhiteSpace(fullPathTestParams) ? fullPathTest : fullPathTestParams,
																						"{ tag: '" + datatag + searchtag.Replace("\" data-subentity ", "").Replace("\" ", "") + "', value: '01/01/2001 10.00', type: controlTypeEnum.inputText" +
																						(!string.IsNullOrEmpty(fi.Defaultvalue) ? ", default: " + fi.Defaultvalue + " " : "") + " }", fi);
																						break;
																					}
																					case "varbinary":
																					case "image": {
																						//upload
																						formString += "					<label class=\"col-form-label col-md-12\" for=\"" + nametag + "\">" + fi.Title + "</label>\r\n" +
																								 "					<input id=\"" + nametag + "\" type=\"file\" class=\"form-control\" " + /*"data-tag=\"" + datatag + searchtag + */ " " + (fi.Allownull ? "" : "data-mandatory ") + "/>\r\n";
																						break;
																					}
																					case "decimal":
																					case "float": {
																						//textbox
																						formString += "					<label class=\"col-form-label col-md-12\" for=\"" + nametag + "\">" + fi.Title + "</label>\r\n" +
																								 "					<input id=\"" + nametag + "\" type=\"text\" class=\"form-control\" " + "data-tag=\"" + datatag +
																								 (fi.Name == "latitude" || fi.Name == "longitude" ?
																								 ".fixed.7" :
																									(fi.Len > 0 ?
																									".fixed." + fi.Len.ToString() :
																									".fixed.2"
																									)
																								 ) + searchtag + " " + (fi.Allownull ? "" : "data-mandatory ") + "/>\r\n";
																						//test
																						SetArrayInputTest(string.IsNullOrWhiteSpace(fullPathTestParams) ? fullPathTest : fullPathTestParams,
																						"{ tag: '" + datatag + (fi.Name == "latitude" || fi.Name == "longitude" ?
																							  ".fixed.7" :
																								 (fi.Len > 0 ?
																								 ".fixed." + fi.Len.ToString() :
																								 ".fixed.2"
																								 )
																							  ) + searchtag.Replace("\" data-subentity ", "").Replace("\" ", "") + "', value: testHelper.getRandomDecimalTest(" +
																							(fi.Name == "latitude" || fi.Name == "longitude" ?
																							  "7" : (fi.Len > 0 ? fi.Len.ToString() : "2")) + "), type: controlTypeEnum.inputText" +
																							  (!string.IsNullOrEmpty(fi.Defaultvalue) ?
																									", default: " + (fi.Defaultvalue.Contains(",") ?
																														fi.Defaultvalue
																														:
																														(!fi.Defaultvalue.Contains("\"") ?
																															 "\"" + fi.Defaultvalue + ",00\"" + " "
																															 :
																															 fi.Defaultvalue.Substring(0, fi.Defaultvalue.Length - 1) + ",00\"" + " ")
																													)
																									: "") + " }", fi);
																						break;
																					}
																					default: {
																						//textbox
																						formString += "					<label class=\"col-form-label col-md-12\" for=\"" + nametag + "\">" + fi.Title + "</label>\r\n" +
																								 "					<input id=\"" + nametag + "\" type=\"text\" class=\"form-control\" " + "data-tag=\"" + datatag + searchtag + " " + (fi.Allownull ? "" : "data-mandatory ") + "/>\r\n";

																						//test
																						if (GetDatasetType(fi.Type) == "int") {
																							if (!fi.IsKey)
																								SetArrayInputTest(string.IsNullOrWhiteSpace(fullPathTestParams) ? fullPathTest : fullPathTestParams,
																								"{ tag: '" + datatag + searchtag.Replace("\" data-subentity ", "").Replace("\" ", "") + "', value: 1, type: controlTypeEnum.inputText" +
																								(!string.IsNullOrEmpty(fi.Defaultvalue) ? ", default: " + fi.Defaultvalue + " " : "") + " }", fi);
																						}
																						else {
																							SetArrayInputTest(string.IsNullOrWhiteSpace(fullPathTestParams) ? fullPathTest : fullPathTestParams,
																								"{ tag: '" + datatag + searchtag.Replace("\" data-subentity ", "").Replace("\" ", "") + "', value: " +
																								(string.IsNullOrWhiteSpace(fi.Testvalue) ? "testHelper.getRandomStringTest(" + fi.Len.ToString() + ")" : fi.Testvalue) +
																								", type: controlTypeEnum.inputText" + (!string.IsNullOrEmpty(fi.Defaultvalue) ? ", default: " + fi.Defaultvalue + " " : "") + " }", fi);
																						}
																						break;
																					}
																				}
																			}
																		}
																	}

																	//Abilitazione e disabilitazione condizionale del campo in base al master
																	var disablerFields = IsDisabledByOtherFild(fi, ref allfields, connection);
																	if (disablerFields.Any()) {
																		//se utilizza come master un campo vuol dire che si abilita/disabilita in base ad esso
																		var masterField = disablerFields.FirstOrDefault(ff => ff.Table == fi.Master);

																		if (masterField != null) {

																			fullTables.Add(masterField.Table);

																			var masterPrincipalKey = GetPrincipalKey(masterField.Table, masterField.EditListingType, allfields, connection);
																			//...devo filtrare la dropdown detail quando scelgo il valore, o nelle pagine principali quando le apro
																			SetAfterRowSelect(fullPathMetaPageJS, null,
																				"if (t.name === \"" + fi.Master + "\" && r !== null) {\r\n" +
																				(
																					string.IsNullOrWhiteSpace(fi.AfterRowSelectPrefill) ?
																						"\t\t\t\t\tif (r." + masterField.Name + " === '" + (IsView(fi.Master) ? "No" : "N") + "') {\r\n" +
																						//"\t\t\t\t\t\t$('#" + nametag + "').val('');\r\n" +
																						((fi.Type == "char" && fi.Len == 1) ?
																							"\t\t\t\t\t\tself.enableControl($('#" + nametag + "Si'), false);\r\n" +
																							"\t\t\t\t\t\tself.enableControl($('#" + nametag + "No'), false);\r\n"
																						:
																							"\t\t\t\t\t\tself.enableControl($('#" + nametag + "'), false);\r\n"
																						) +
																						"\t\t\t\t\t}\r\n" +
																						"\t\t\t\t\telse {\r\n" +
																						((fi.Type == "char" && fi.Len == 1) ?
																							"\t\t\t\t\t\tself.enableControl($('#" + nametag + "Si'), true);\r\n" +
																							"\t\t\t\t\t\tself.enableControl($('#" + nametag + "No'), true);\r\n"
																						:
																							"\t\t\t\t\t\tself.enableControl($('#" + nametag + "'), true);\r\n"
																						) +
																						"\t\t\t\t\t}\r\n"
																					:
																						fi.AfterRowSelectPrefill + "\r\n"
																				) +
																				"\t\t\t\t}\r\n"
																				, o.Table, editListingTypes);

																			//... o nelle pagine secondarie quando le apro
																			if (o.Principale != "S") {
																				//dopo poco durante l'apertura applico il filtro impostato in base al master
																				SetAfterActivation(fullPathMetaPageJS, null,
																				"if (parentRow." + masterField.Name + ") {\r\n" +
																				(
																					string.IsNullOrWhiteSpace(fi.AfterActivationPrefill) ?
																						"\t\t\t\t\tarraydef.push(appMeta.getData.runSelect('" + fi.Master + "', '" + fi.Name +
																							"', this.q.eq('" + masterPrincipalKey.Name + "', parentRow." + masterPrincipalKey.Name + "), null)\r\n" +
																						"\t\t\t\t\t\t.then(function (dt) {\r\n" +

																						"\t\t\t\t\t\t\tif (dt.rows[0]." + masterField.Name + " === '" + (IsView(fi.Master) ? "No" : "N") + "') {\r\n" +
																						((fi.Type == "char" && fi.Len == 1) ?
																							"\t\t\t\t\t\t\t\tself.enableControl($('#" + nametag + "Si'), false);\r\n" +
																							"\t\t\t\t\t\t\t\tself.enableControl($('#" + nametag + "No'), false);\r\n"
																						:
																							"\t\t\t\t\t\t\t\tself.enableControl($('#" + nametag + "'), false);\r\n") +
																						"\t\t\t\t\t\t\t}\r\n" +
																						"\t\t\t\t\t\t\telse {\r\n" +
																						((fi.Type == "char" && fi.Len == 1) ?
																							"\t\t\t\t\t\t\t\tself.enableControl($('#" + nametag + "Si'), true);\r\n" +
																							"\t\t\t\t\t\t\t\tself.enableControl($('#" + nametag + "No'), true);\r\n"
																						:
																							"\t\t\t\t\t\t\t\tself.enableControl($('#" + nametag + "'), true);\r\n") +
																						"\t\t\t\t\t\t\t}\r\n" +

																						"\t\t\t\t\t\t\treturn true;\r\n" +
																						"\t\t\t\t\t\t})\r\n" +
																						"\t\t\t\t\t);\r\n"
																					:
																						fi.AfterActivationPrefill + "\r\n"
																				) +
																				"\t\t\t\t}\r\n"
																				, o.Table, editListingTypes);
																			}
																		}
																	}
																}
																//chiusura colonna, solo se destro
																if (!IsSinistro(position, isInverted) || fi.UniqueOnRow) {
																	//chiudo colonna e chiudo riga;
																	formString += "				</div>\r\n			</div>\r\n";
																}
															}
															position++;
														}
													}
												}

												//se i field del tab o pagina sono dispari devo chiudere l'ultima riga/colonna in quanto manca l'elemento destro che lo faceva
												if (IsSinistro(position - 1, isInverted)) {
													formString += "				</div>\r\n			</div>\r\n";
												}
											}

											//aggiungo i bottoni
											if (buttonFields.Any(bt => bt.Tab == tab.Title && bt.Position == "D")) {
												foreach (var b in buttonFields.Where(bt => bt.Tab == tab.Title && bt.Position == "D"))
													formString += " <button id=\"" + b.Name + "\" type=\"button\" class=\"btn btn-primary p-2 mt-2\" >\r\n        <i class=\"fa " + b.Icon + " mr-1\" ></i>" + b.Title + "\r\n    </button>\r\n";
											}

											//aggiungo i bottoni relazione
											foreach (var b in relationFieldButton.Where(f => f.Tab == tab.Title)) {
												formString += " <button id=\"" + b.Name + "\" type=\"button\" class=\"btn btn-primary p-2 mt-2\" data-tag=\"manage." + b.Name.Substring(2) + "." + b.EditListingType + "\">\r\n        <i class=\"fa " + b.Icon + " mr-1\" ></i>" + b.Title + "\r\n    </button>\r\n";
												//tolgo il field dai fields cosÃƒÂ¬ non verrÃƒÂ  creato il ramo relativo nel dataset
												fields.Remove(b);
											}

											////aggiungo il placeholder del riepilogo
											//formString += "	<!--Summary-->\r\n";

											if (!(tabs.Count == 1)) {
												//chiudo il tab
												formString += "	</div>\r\n";
											}
										}
									}
									//chiudo il form
									formString += (tabs.Count == 1 ? "" : "</div>\r\n");

									if (o.IsTree && o.Principale == "S") {
										formString += "\t\t\t</div>\r\n\t\t</div>\r\n\t</div>\r\n";
									}

									formString += "</form>\r\n";

									//metto il form nella pagina
									ReplaceStringInFile(fullPathMetaPageHtml, "<!--formString-->", formString);
									//metto la losta dei tab nella pagina
									ReplaceStringInFile(fullPathMetaPageHtml, (o.IsTree && o.Principale == "S") ? "<!--tabStringTree-->" : "<!--tabString-->", tabString);

									if (!string.IsNullOrWhiteSpace(o.Header)) {
										//aggiungo il testo per l'intestazione
										var header = "<div class=\"p-2 custom_lng_div\" data-langkey=\"pageheader" + o.PageId + "\" >" + o.Header + "</div>\r\n";
										ReplaceStringInFile(fullPathMetaPageHtml, "<!--header-->", header);

										//...aggiungo l'etichetta per l'intestazione
										ReplaceStringInLocalResourceFile(RegionMarker.LocalResource_labels, "pageheader", o.PageId, o.Header.Replace("\"", "\\\"").Replace("\r", "").Replace("\n", "").Replace("'", "\\'"));
									}

									if (!string.IsNullOrWhiteSpace(o.Footer)) {
										//aggiungo il testo per il footer
										var footer = "<div class=\"p-2 custom_lng_div\" data-langkey=\"pagefooter" + o.PageId + "\" >" + o.Footer + "</div>\r\n";
										ReplaceStringInFile(fullPathMetaPageHtml, "<!--footer-->", footer);

										//...aggiungo l'etichetta per il footer									
										ReplaceStringInLocalResourceFile(RegionMarker.LocalResource_labels, "pagefooter", o.PageId, o.Footer.Replace("\"", "\\\"").Replace("\r", "").Replace("\r", "").Replace("'", "\\'"));
									}

									//aggiungo eventuali dipendenze di campi non visibili
									foreach (var fi in fields)
										if (!string.IsNullOrWhiteSpace(fi.Master) && !fi.Detailvisible) {
											var masterField = fields.FirstOrDefault(ff => ff.MetadatoChild == fi.Master);
											if (masterField != null) {
												var nametag = fi.Table + "__" + fi.EditListingType + "_" + fi.Name;
												var currentRow = isExtendedObjView && fi.Table == o.Table ?
															 "DS.tables." + fi.Table + (fi.ForceAlias > 0 ? "_alias" + fi.ForceAlias : "") + ".rows[0]"
															 : "currentRow";

												SetAfterGetFormData(fullPathMetaPageJS, "this.manage" + nametag + "()", o.Table, editListingTypes, false);
												SetBottomCode(fullPathMetaPageJS,
													"manage" + nametag + ": function () {\r\n" +
													"				var def = appMeta.Deferred(\"beforeFill-manage" + nametag + "\");\r\n" +
													"				var self = this;\r\n" +
													"				var masterRow = _.find(this.state.DS.tables." + fi.Master + ".rows, function (row) {\r\n" +
													"					if (self.state.currentRow." + masterField.Name + ")\r\n" +
													"						return row." + masterField.Name.Split('_')[0] + " === self.state.currentRow." + masterField.Name + ";\r\n" +
													"					else\r\n" +
													"						return null;\r\n" +
													"				});\r\n" +
													"				if (masterRow)\r\n" +
													"					this.state." + currentRow + "." + fi.Name + " = masterRow." + fi.Name + ";\r\n" +
													"				return def.resolve();\r\n" +
													"			}");
											}
										}

									//aggiungo la gestione delle colonne nipoti
									if (childColumns.Any()) {
										var childColString = "";
										foreach (var ctrl in childColumns.Select(c => c.ControlName).Distinct()) {
											childColString += (string.IsNullOrEmpty(childColString) ? "" : "\t\t\t\t") + "var " + ctrl + "ChildsTables = [\r\n";
											var nephews = childColumns.Where(c => c.ControlName == ctrl).Select(c => c.Nephew).ToList();
											foreach (var col in childColumns.Where(c => c.ControlName == ctrl)) {
												childColString += "\t\t\t\t\t{ tablename: '" + col.Tablechild + "', edittype: '" + col.EdittypeChild + "', columnlookup: '" + col.Columnlookup + "', columncalc: '" + col.Columncalc + "'},\r\n";
												SetFilterOnMetaPageJS(col.Nephew, fullPathMetaPageJS, o.Table, col.Tablename, editListingTypes, ref allfields, nephews, connection, false);
											}
											childColString += "\t\t\t\t];\r\n";
											childColString += "\t\t\t\t$('#" + ctrl + "').data('childtables', " + ctrl + "ChildsTables);\r\n";

											var nephew = childColumns.Where(c => c.ControlName == ctrl).First().Nephew;
											if (!nephew.Buttoninsert)
												childColString += "\t\t\t\t$('#" + ctrl + "').data('childtablesadd', false);\r\n";
											if (!nephew.Buttonedit)
												childColString += "\t\t\t\t$('#" + ctrl + "').data('childtablesedit', false);\r\n";
											if (!nephew.Buttondelete)
												childColString += "\t\t\t\t$('#" + ctrl + "').data('childtablesdelete', false);\r\n";

										}
										SetAfterlink(fullPathMetaPageJS, childColString);
									}

									Console.WriteLine("");

									if (!skipmetapageDataset) {
										Console.WriteLine("2.7) CREO IL DATASET DELLA PAGINA ");

										//-copio il dataset vuoto nel backend data
										var fullpathDatasetMetaData = "../../metapage_template/vista";
										var fullpathDatasetMetapage = backendFolder + "Data/dsmeta_" + (!string.IsNullOrEmpty(extendingObject) ? extendedObject : o.Table) + "_" + editListingTypes;
										Copy(fullpathDatasetMetaData + ".xsd", fullpathDatasetMetapage + ".xsd", true);
										Copy(fullpathDatasetMetaData + ".xsc", fullpathDatasetMetapage + ".xsc", true);
										Copy(fullpathDatasetMetaData + ".xss", fullpathDatasetMetapage + ".xss", true);
										if (rebuildHdsgene)
											Copy(fullpathDatasetMetaData + ".Designer.cs", fullpathDatasetMetapage + ".cs", true);

										//ci metto il metadato principale o estendente
										var dsMetadatoAndKey = GetDatasetTable(currentTable, null, false, allfields, connection, editListingTypes, fullPathMetaPageJS);
										var datasetMetadato = "<xs:choice minOccurs=\"0\" maxOccurs=\"unbounded\">\r\n";
										datasetMetadato += dsMetadatoAndKey.Split(';')[0];
										datasetMetadato += "      </xs:choice>";
										ReplaceStringInFile(fullpathDatasetMetapage + ".xsd", "<xs:choice minOccurs=\"0\" maxOccurs=\"unbounded\" />", datasetMetadato);
										ReplaceStringInFile(fullpathDatasetMetapage + ".xsd", "<xs:unique name=\"Constraint1\" msdata:PrimaryKey=\"true\" />\r\n", dsMetadatoAndKey.Split(';')[1]);

										//dsmeta_ come prefisso in System.Xml.Serialization.XmlRoot
										ReplaceStringInFile(fullpathDatasetMetapage + ".xsd", "id=\"vista\"", "id=\"dsmeta_" + (!string.IsNullOrEmpty(extendingObject) ? extendedObject : o.Table) + "_" + editListingTypes + "\"");
										ReplaceStringInFile(fullpathDatasetMetapage + ".xsd", "name=\"vista\"", "name=\"dsmeta_" + (!string.IsNullOrEmpty(extendingObject) ? extendedObject : o.Table) + "_" + editListingTypes + "\"");

										//preparo una lista dei campi per calcolare gli alias
										var datasetfields = new List<field>();
										datasetfields.AddRange(fields.Where(f => f.Detailvisible));

										//-popolo il datased della pagina nel project beckend
										if (!string.IsNullOrEmpty(extendingObject)) {
											//--se stiamo lavorando con un oggetto esteso, devo inserire la loro relazione e l'estendente
											var extendingKeys = GetChildKeysString(extendedObject, o.Table, editListingTypes, o.EditListingType, extendedObjectKey, allfields, connection);

											PreparePageDataset(fullpathDatasetMetapage + ".xsd", extendedObject, currentTable, String.Join(" ", extendedObjectKey), extendingKeys, current, false,
												datasetfields, allfields, o.EditListingType, editListingTypes, null, connection, false, 1, "", new List<string>(), fullPathMetaPageJS, 1, childColumns, null, true, null);
										}

										//se si tratta di una pagina ad albero devo inserire l'auto relazione sula tabella principale
										if (o.IsTree) {

											var parentKey = GetParentkey(o.Table, editListingTypes, principalkey.Name, fields);
											var datasetRelation = "     <msdata:Relationship name=\"FK_" + o.Table + "_" + o.Table + "_" + principalkey.Name + "\" msdata:parent=\"" +
																			o.Table + "\" msdata:child=\"" + o.Table + "\" msdata:parentkey=\"" + principalkey.Name + "\" msdata:childkey=\"" + parentKey.Name + "\" />\r\n";

											SetRelationInDataset(fullpathDatasetMetapage + ".xsd", datasetRelation);
										}

										//preparo una lista di tabelle che non vanno minificate PerchÃƒÂ© fanno parte di filtri o calcoli per campi calcolati
										if (o.Createmetapage) {
											var fileText = TextFile.ReadAllTextFile(fullPathMetaPageJS);
											fullTables.AddRange(Regex.Matches(fileText, @"\.state\.DS\.tables\.(.*?)\.", RegexOptions.Singleline).Cast<Match>()
											   .Select(m => m.Value.Replace(".state.DS.tables.", "").Replace(".", "").Replace(")\n\t\t\t\t\tif (", "")).Distinct().ToList());
											fullTables.AddRange(Regex.Matches(fileText, @"\.getDataTable\(\""(.*?)\""\)", RegexOptions.Singleline).Cast<Match>()
											   .Select(m => m.Value.Replace(".getDataTable(\"", "").Replace("\")", "")).Distinct().ToList());
											fullTables.AddRange(Regex.Matches(fileText, @"\.getDataTable\('(.*?)'\)", RegexOptions.Singleline).Cast<Match>()
											   .Select(m => m.Value.Replace(".getDataTable('", "").Replace("')", "")).Distinct().ToList());

											foreach (var dd in fields.Where(fi => fi.IdAppFieldDetail_sortmember != null)) {
												var sortfield = allfields.Where(af => af.IdAppFieldDetail == dd.IdAppFieldDetail_sortmember);
												if (sortfield.Any())
													fullTables.Add(sortfield.First().Table);
											}
										}

										//ciclo tra i campi visibili (o invisibili ma che servono a calcolare un campo calcolato) e le relazioni dell'oggetto principale  
										//o del suo esteso, perchÃƒÂ¨ potrebbero esserci campi aggiunti di subentitÃƒÂ  affogate nella pagina
										//l'ordinamento fa in modo che l'ordine delle eventuali assegnazioni degli alias resti lo stesso in generazioni successive
										foreach (var fi in fields.Where(f => (f.Detailvisible || fullTables.Any(ft => IsPrincipalKey(f, ft)))
																	&& (f.Table == o.Table || f.Table == extendedObject))
																	.OrderBy(f => f.Sort).ThenBy(f => f.Name)) {
											//--se trovo altre chiavi nei capi VISIBILI aggiungo le tabelle e le relazioni
											if (
												(!IsPrincipalKey(fi, o.Table) || isLinkingObj || fi.IsLinkingObj)
												&& (HaveKeyName(fi) || fi.Name.StartsWith("XX"))) {
												//se ÃƒÂ¨ un campo della tabella corrente considero che potrebbe avere giÃƒÂ  un alias
												var tableParent = fi.Table == o.Table ? currentTable : fi.Table;
												var editListingTypesParent = fi.Table == o.Table ? o.EditListingType : editListingTypes;
												var tablechild = "";
												var key = "";
												var childkey = "";
												var minimal = false;
												var pageid = "";
												var editListTypeField = GetEditTypeById(fi, allfields, connection);
												var extendedTableChild = "";
												var iteration = 1;
												int? sortList = null;
												var skipLookup = false;
												string master = "";

												//se ÃƒÂ¨ un dropdown con master e non ha relazione personalizzata ...
												if (!string.IsNullOrWhiteSpace(fi.Master) && string.IsNullOrWhiteSpace(fi.AfterRowSelectPrefill) && IsDropdown(fi)) {
													//...e il master ÃƒÂ¨ un dropdown...
													var cm = fields.Where(ff => ff.MetadatoChild == fi.Master).FirstOrDefault();
													if (cm != null && IsDropdown(cm))
														//...lo gestisce il framework: lo passo al metodo
														master = fi.Master;
												}

												//nel caso si tratta di un id vero e proprio
												if (HaveKeyName(fi)) {
													//se ÃƒÂ¨ un oggetto aggiunto perchÃƒÂ¨ utile nei calcoli non ha il metadatochild 
													if (!fi.Detailvisible && fi.MetadatoChild == null) {
														SetMetadatoChild(fields, fi, GetTableById(fi.Name, allfields, connection), ref allfields, connection);
													}

													tablechild = fi.MetadatoChild ?? GetTableById(fi.Name, allfields, connection);

													if (IsView(tablechild))
														skipLookup = true;

													key = fi.Name; //potrebbe avere suffissi o prefissi
													childkey = GetIdByForeignKey(fi);
													if (childkey.Split(' ').Count() > 1) {
														//l'oggetto puntato dalla chiave ha una chiave multipla quindi l'oggetto corrente deve avere una foreign key da piÃƒÂ¹ colonne
														key = string.Join(" ", fields.Where(af => childkey.Split(' ').Any(ck => ck == af.Name.Split('_')[0]) ||
																						(af.Name.Contains("_") && childkey.Split(' ').Any(ck => ck == af.Name.Split('_')[1]))
																					).Select(k => k.Name));
													}
													minimal = true;
													extendedTableChild = fi.MetadatoExtendedChild;
													sortList = fi.SortList;
												}

												//se ÃƒÂ¨ una tabella figlia prendo come chiave quella dell'oggetto
												if (fi.Name.StartsWith("XX")) {
													tablechild = fi.MetadatoChild ?? fi.Name.Substring(2);
													GetMissingFields(tablechild, null, ref allfields, connection);

													//key e childkey per le relazioni tra subentitÃƒÂ , sono sempre tutte le chiavi del padre
													key = string.Join(" ", (isExtendedObjView ? extendedObjectKey : objectKey).OrderBy(k => k));
													childkey = string.Join(" ", fi.LookupFor.Split(' ').OrderBy(k => k));
													if (string.IsNullOrWhiteSpace(childkey) || childkey.Split(' ').Any(k => k.StartsWith("parid")))
														childkey = GetChildKeysString(fi.Table, tablechild, editListingTypesParent, fi.EditListingType, key.Split(' ').ToList(), allfields, connection);

													if (fi.RelationType == "unique" || fi.RelationType == "checkbox") {
														iteration = 0;
													}

													pageid = fi.PageId;
													extendedTableChild = fi.MetadatoExtendedChild;

													//se sto costruendo una subpage su una vista come fosse una vera e propria tabella devo avvisare il framework di non salvarla/modificarla/eliminarla
													if (fi.IsView)
														SetBeforePost(fullPathMetaPageJS, "this.getDataTable('" + tablechild + "').acceptChanges();\r\n");

												}

												if (!string.IsNullOrEmpty(tablechild) && !string.IsNullOrEmpty(key) &&
													tablechild != extendedObject) //evito i riferimenti circolari quando, scandendo l'extending, trovo la chiave, che ÃƒÂ¨ come quella dell'extended, 
																				  //che viene scambiato come figlio
													PreparePageDataset(fullpathDatasetMetapage + ".xsd", tableParent, tablechild, key, childkey, o.Table, minimal, datasetfields, allfields,
														editListTypeField, editListingTypesParent, pageid, connection, fi.IsLinkingObj, iteration, extendedTableChild, fullTables, fullPathMetaPageJS,
														sortList, childColumns, master, skipLookup, fi.Title);
											}
										}

										////riepilogo -----------------------------------------------------------start

										//Console.WriteLine("");
										//Console.WriteLine("2.8) GENERO IL RIEPILOGO");

										//var fields_riepilogo = new List<field>(); //TODO li deve collezionare durante la costruzione del dataset
										//var view_riepilogo = ""; //TODO la deve costruire durante la costruzione del dataset

										//if (fields_riepilogo.Any()) {
										//	//aggiungo il riepilogo al dataset (tabella)
										//	var rstring = GetDatasetTable(o.Table + "_riepilogo", o.Table + "_riepilogo", false, fields_riepilogo);
										//	if (!string.IsNullOrEmpty(rstring)) {
										//		ReplaceStringInFile(fullpathDatasetMetapage + ".xsd", "<xs:choice minOccurs=\"0\" maxOccurs=\"unbounded\">\r\n", "<xs:choice minOccurs=\"0\" maxOccurs=\"unbounded\">\r\n" + 
										//			rstring.Split(';')[0]);
										//		ReplaceStringInFile(fullpathDatasetMetapage + ".xsd", "</xs:complexType>\r\n    <xs:unique", "</xs:complexType>\r\n    " + rstring.Split(';')[1] + "    <xs:unique");
										//	}

										//	//salvo la vista su db
										//	var cmd_r = new SqlCommand(view_riepilogo, connection);
										//	try {
										//		cmd_r.ExecuteNonQuery();
										//	} catch (Exception e) {
										//		if (verbose)
										//			Console.WriteLine("INFO: La vista di riepilogo esisteva giÃƒÂ  " + e.Message);
										//		var alterView = view_riepilogo.Replace("CREATE VIEW","ALTER VIEW");
										//		cmd_r = new SqlCommand(alterView, connection);
										//		try {
										//			cmd_r.ExecuteNonQuery();
										//		} catch (Exception ea) {
										//			//if (verbose)
										//			Console.WriteLine("ERROR: Fallito l'aggiornamento della vista di riepilogo " + ea.Message);
										//		}
										//	}

										//	//aggiungo la griglia all'html
										//	var grf = String.Join(";", fields_riepilogo.Where(r=>r.Summary == "R").Select(r=>r.Name).ToList());
										//	var gra = String.Join(";", fields_riepilogo.Where(r=>r.Summary == "A").Select(r=>r.Name).ToList());
										//	ReplaceStringInFile(fullPathMetaPageHtml, "<!--Summary-->", "		<div class=\"row\">\r\n" +
										//			"			<div class=\"col-md-12\">\r\n" +
										//			"				<label class=\"col-form-label col-md-12\" for=\"grid_" + o.Table + "_riepilogo\">Riepilogo</label>\r\n" +
										//			"				<div class=\"gridx\" id=\"grid_" + o.Table + "_riepilogo\" data-tag=\"" + o.Table + "_riepilogo.riepilogo.riepilogo\" data-custom-control=\"gridx\" " +
										//			(string.IsNullOrEmpty(grf) ? "" : "data-mdlgroupedcolumns=\"" + grf + "\" data-mdltotnotvisible ") +
										//			(string.IsNullOrEmpty(gra) ? "" : "data-mdlaggregatecolumns=\"" + gra + "\" ") +
										//			"></div>\r\n" +
										//			"			</div>\r\n" +
										//			"		</div>\r\n");

										//	//creo il metadato fittizzio
										//	var fullPathMetaDatoRiepilogoJS = clientFolder + metapageFolder + container + "/meta_" + o.Table + "_riepilogo.js";
										//	SetMetadatoJs(fullPathMetaDatoJS, container, o.Table + "_riepilogo", currentApp, fields_riepilogo.Where(r=>r.IsKey).Select(r=>r.Name).ToList(), false);

										//}

										////riepilogo -----------------------------------------------------------end

										if (o.AdditionalTables.Any()) {
											Console.WriteLine("");
											Console.WriteLine("Aggiungo le tabelle aggiuntive");

											var datasetFile = TextFile.ReadAllTextFile(fullpathDatasetMetapage + ".xsd");
											foreach (var tt in o.AdditionalTables) {
												var t = tt.Split('$')[0];
												if (!datasetFile.Contains("<xs:element name=\"" + t + "\">")) {
													GetMissingFields(t, null, ref allfields, connection);
													//se ho caricato una vista allora forzo tutti gli id come chiavi 
													if (!allfields.Where(af => af.Table == t).Any(fi => fi.IsKey)) {
														foreach (var f in allfields.Where(af => af.Table == t)) {
															if (HaveKeyName(f) && !f.Allownull)
																f.IsKey = true;
														}
													}
													var tstring = GetDatasetTable(t, null, false, allfields, connection, "", fullPathMetaPageJS);
													if (!string.IsNullOrEmpty(tstring)) {
														//la aggiungo al dataset
														ReplaceStringInFile(fullpathDatasetMetapage + ".xsd", "<xs:choice minOccurs=\"0\" maxOccurs=\"unbounded\">\r\n", "<xs:choice minOccurs=\"0\" maxOccurs=\"unbounded\">\r\n" + tstring.Split(';')[0]);
														ReplaceStringInFile(fullpathDatasetMetapage + ".xsd", "</xs:complexType>\r\n    <xs:unique", "</xs:complexType>\r\n    " + tstring.Split(';')[1] + "    <xs:unique");
														var toFill = true;
														if (tt.Split('$').Count() > 1)
															if (tt.Split('$')[1] == "V")
																toFill = false;
														if (toFill) {
															//faccio in modo che la pagina la riempia
															SetAfterlink(fullPathMetaPageJS, "//indico al framework che la tabella " + t + " ÃƒÂ¨ cached\r\n" +
																"\t\t\t\tvar " + t + "Table = this.getDataTable(\"" + t + "\");\r\n" +
																"\t\t\t\tappMeta.metaModel.cachedTable(" + t + "Table, true);\r\n");
															SetAfterlinkAsinc(fullPathMetaPageJS, "appMeta.getData.runSelectIntoTable(" + t + "Table, null, null)");
														}
													}
												}
											}
										}

										if (rebuildHdsgene) {
											//modifico il file cs del dataset
											Console.WriteLine("");
											Console.Write("Eseguo HDSGene: ");
											Stopwatch time10kOperations = Stopwatch.StartNew();
											time10kOperations.Start();
											HDSGen.FileNameSpace = "Backend.Data";
											File.WriteAllBytes(fullpathDatasetMetapage + ".cs", HDSGen.iGenerateCode(fullpathDatasetMetapage + ".xsd", TextFile.ReadAllTextFile(fullpathDatasetMetapage + ".xsd")));
											time10kOperations.Stop();
											Console.WriteLine("terminato in millisecondi:" + time10kOperations.ElapsedMilliseconds.ToString());
										}
									}
								}
								#endregion
							}
						}
						else {
							ConsoleWriter.WarningDB("Non genero l'interfaccia per la tabella " + o.Table + " con l'edit type " + o.EditListingType +
								" perchÃƒÂ¨ esiste l'oggetto " + o.Table + "_" + o.EditListingType + " che lo estende");
						}
					}
					else {

						ConsoleWriter.ErrorDB("Impossibile generare la metapage {0}", pl);

					}
				}


				ConsoleWriter.ViewErrors();

				Console.WriteLine("Fine della generazione del codice");

				ConsoleWriter.Title("Build, aggiornamento della varsione e copia per il LU delle dll e copia per il LU degli script SQL");

				Console.WriteLine("Genero il boundle javascript e lo aggiorno su index");
				var buildboundle = new Process()
				{
					StartInfo = new ProcessStartInfo
					{
						WindowStyle = ProcessWindowStyle.Normal,
						FileName = (clientFolder + "../webpack/").Replace("/", "\\") + "BUILD_BUNDLE_JS_" + currentApp + ".bat",
						//Arguments = "",
						UseShellExecute = false
					}
				};
				buildboundle.Start();
				buildboundle.WaitForExit();

				ReplaceRegExInFile(clientFolder + "index.html",
					"mdlw_bundle_" + currentApp + @"_(.*?).js",
					"mdlw_bundle_" + currentApp + "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + ".js");

				Console.WriteLine("Aggiorno la versione dei meta e le cartelle per il live update");

				var modifiedFiles = fileContainer.GetChangedFiles();

				string scriptDirectory = String.Format("{0}_script/{1}", solutionFolder, currentApp);
				//string newStructureDirectory = String.Format("{0}/F3_NuoveStrutture", scriptDirectory);
				if (!Directory.Exists(scriptDirectory)) {
					Directory.CreateDirectory(scriptDirectory);
				}
				//if (!Directory.Exists(newStructureDirectory)) {
				//	Directory.CreateDirectory(newStructureDirectory);
				//}

				foreach (var f in modifiedFiles) {
					try {
						var fi = new FileInfo(f);
						//file di script sql
						if (f.StartsWith(clientFolder + scriptFolder)) {
							//if (f.Contains("/v_"))
							//	//viste
							//	Copy(f, solutionFolder + "_view/" + fi.Name, true);
							//else if (f.Contains("/zy_"))
							//	//stored 
							//	Copy(f, solutionFolder + "_storedprocedure/" + fi.Name, true);
							//else if (f.Contains("/zz_"))
							//	//script
							//	Copy(f, String.Format("{0}/{1}", scriptDirectory, fi.Name), true);
							//else {   //tabelle							
							//	Copy(f, String.Format("{0}/{1}", newStructureDirectory, fi.Name), true);
							//}
						}
						//metapage 
						else if (f.StartsWith(clientFolder + metapageFolder) && (f.EndsWith(".js") || f.EndsWith(".html")) && !f.Contains("/meta_")) {
							Copy(f, clientFolder + "apppages/" + fi.Name, true);
						}
					}
					catch (Exception ex) {
						ConsoleWriter.ErrorDB("Errore nella copia di {0}: {1}", f, ex.Message);
					}

				}
				HDSGen.extConn.Close();

				connection.Close();

			}

			ConsoleWriter.Info("Ora di fine {0}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));

			ConsoleWriter.Info("Tempo di esecuzione {0} minuti", (DateTime.Now - startTime).TotalMinutes.ToString());

			if (!skipmetapage) {
				Console.WriteLine("Aprire la solution del Backend e premi start");
			}


		}

		#region generazione SQL Script

		/// <summary>
		/// Genera gli script sql per l'aggiornamento dei database
		/// </summary>
		/// <param name="file"></param>
		/// <param name="tableName"></param>
		/// <param name="isVoc"></param>
		/// <param name="connection"></param>
		public static void WriteSQLScript(string file, string tableName, bool isVoc, ref List<field> allfields, SqlConnection connection) {
			if (rebuildScript && !scriptAlreadyCreated.Contains(tableName)) {
				var fileDbo = file.Replace("ScriptSQL", "ScriptLU").Replace(".sql", ".dbo.sql");
				var fileNdbo = file.Replace("ScriptSQL", "ScriptLU").Replace(".sql", ".ndbo.sql");
				var fileVocdbo = file.Replace("ScriptSQL", "ScriptLU").Replace(".sql", ".vocdbo.sql");
				var fileVocNdbo = file.Replace("ScriptSQL", "ScriptLU").Replace(".sql", ".vocndbo.sql");

				if (File.Exists(file))
					fileContainer.Add(file);

				if (File.Exists(fileDbo))
					fileContainer.Add(fileDbo);
				if (File.Exists(fileNdbo))
					fileContainer.Add(fileNdbo);
				if (File.Exists(fileVocNdbo))
					fileContainer.Add(fileVocNdbo);
				if (File.Exists(fileVocdbo))
					fileContainer.Add(fileVocdbo);

				//aggiungo la tabella alla cache di quelle giÃƒÂ  elaborate
				scriptAlreadyCreated.Add(tableName);

				//bool isDbo = (GetSchemaByTable(tableName, allfields, connection) == "dbo");




				Console.WriteLine("");
				Console.Write("Genero lo script sql per " + tableName + " ");
				Stopwatch time10kOperations = Stopwatch.StartNew();
				time10kOperations.Start();

				string DNS = "EasyPay";
				string Server = dbipport;
				string Database = dbipportname;
				string User = "assistenza";
				string Password = "123***********";
				string DIPARTIMENTO = dipartimento;
				int Esercizio = DateTime.Now.Year;
				DateTime DataContabile = DateTime.Now; // TODO deve essere passata dal client

				//var Conn = Easy_DataAccess.getEasyDataAccess(DNS, Server, Database, User,
				//  Password, DIPARTIMENTO, Esercizio, DataContabile, out error, out detail);

				Easy_DataAccess Conn = new Easy_DataAccess(
				DNS,
				Server,
				Database,
				DIPARTIMENTO,
				"**********",
				User,
				Password,
				Esercizio,
				DataContabile);

				var QHS = Conn.GetQueryHelper();
				var QHC = new CQueryHelper();

				dbstructure DBS = (dbstructure)Conn.GetStructure(tableName);
				if (DBS.HasChanges()) {
					//struttura e , se vocabolario anche i dati ---------------------------------------------
					try {
						Conn.CallSP("clear_table_info",
							new object[] { tableName });
					}
					catch {
						ConsoleWriter.ErrorDB("Errore eseguendo clear_table_info su '" + tableName + "'");
					}
				}
				Conn.SaveStructure(DBS);
				dbanalyzer.ReadColumnTypes(DBS.columntypes, tableName, Conn);

				DataTable t = new DataTable(tableName);
				string columns = "*";
				//if (chkSoloDati.Checked && chkSoloDati.Enabled && (txtColonne.Text.Trim() != ""))
				//	columns = txtColonne.Text;
				t = Conn.CreateTableByName(tableName, columns, true);
				if (isVoc && !IsView(t.TableName)) {
					DataAccess.RUN_SELECT_INTO_TABLE(Conn, t, null, null, null, true);
					if (t.Rows.Count == 0) {
						ConsoleWriter.ErrorDB("Nessuna riga trovata nella tabella vocabolario.  Ultimo errore:" + Conn.LastError);
					}
				}
				Conn.AddExtendedProperty(t);
				DataSet DS = new DataSet();
				DS.Tables.Add(t);
				object kind = Conn.DO_READ_VALUE("customobject", QHS.CmpEq("objectname", tableName), "isreal");
				bool IsTable = kind.ToString().ToLower() == "s";



				UpdateType updateType = UpdateType.insertAndUpdate;
				DataGenerationType generationType = DataGenerationType.onlyStructure;
				if (isVoc)
					generationType = DataGenerationType.structureAndData;

				//scrivo il file script unico
				GeneraSQL.GeneraStrutturaEDati(Conn, DS, file, false, updateType, generationType, IsTable);

				bool isDbo = false;
				string query = "select user_name(objectproperty(object_id("
							   + QueryCreator.quotedstrvalue(tableName, true)
							   + "),'OwnerId'))";
				string dbo = Conn.SQLRunner(query).Rows[0][0].ToString();
				if (dbo == "dbo")
					isDbo = true;

				//scrivo il file con la sola struttura (puÃƒÂ² essere dbo o non dbo)
				StreamWriter writerDBO = new StreamWriter(isDbo ? fileDbo : fileNdbo, false, System.Text.Encoding.Default);
				GeneraSQL.GeneraStrutturaPura(isDbo, Conn, t, writerDBO, IsTable);
				if (isVoc)
					GeneraSQL.GetSQLData(/*false, */t, updateType, writerDBO/*, ConvertCRLFData*/);
				writerDBO.Close();

				//scrivo il file con columntypes e customobject
				StreamWriter writerNonDBO = new StreamWriter(fileVocNdbo, false, System.Text.Encoding.Default);
				GeneraSQL.GeneraColTypesStruttura(isDbo, Conn, t, writerNonDBO, IsTable);
				writerNonDBO.Close();

				//GeneraSQL.GeneraStrutturaEDatiSplitted(Conn, DS,  fileNdbo, fileDbo : false, updateType, generationType, IsTable);

				//descrittori dei dati-----------------------------------------------------------------
				if (IsTable) {
					string[] tableLU = new string[] { "tabledescr", "coldescr", "colbit", "colvalue", "relation", "relationcol" };
					int idrelation = 0;
					bool fileVocdboAppend = false;
					foreach (string tableNameDirty in tableLU) {
						string tableNameD = tableNameDirty.Trim();


						string filter = new string[] { "tabledescr", "coldescr", "colbit", "colvalue" }.Contains(tableNameD) ?
						QHC.CmpEq("tablename", tableName) :
						tableNameD == "relation" ? QHC.CmpEq("childtable", tableName) : QHC.CmpEq("idrelation", idrelation);

						DataTable td = new DataTable(tableNameD);
						td = Conn.CreateTableByName(tableNameD, "*", true);
						DataAccess.RUN_SELECT_INTO_TABLE(Conn, td, null, filter, null, true);
						if (td.Rows.Count == 0) {
							continue;
						}
						DataAccess.addExtendedProperty(Conn, td);

						if (tableNameD == "relation") {
							if (td.Rows[0]["idrelation"] != null)
								if (td.Rows[0]["idrelation"] != DBNull.Value)
									idrelation = (int)td.Rows[0]["idrelation"];
						}

						DataSet DSd = new DataSet();
						DSd.Tables.Add(td);
						IsTable = true;
						updateType = UpdateType.insertAndUpdate;
						generationType = DataGenerationType.onlyData;

						GeneraSQL.GeneraStrutturaEDati(Conn, DSd, file, true, updateType, generationType, IsTable);

						GeneraSQL.GeneraStrutturaEDati(Conn, DSd, fileVocdbo, fileVocdboAppend, updateType, generationType, IsTable);
						fileVocdboAppend = true;
					}

					fileContainer.Add(fileVocdbo);
				}

				fileContainer.Add(file);

				fileContainer.Add(isDbo ? fileDbo : fileNdbo);
				fileContainer.Add(fileVocNdbo);

				time10kOperations.Stop();
				Console.WriteLine("terminato in millisecondi:" + time10kOperations.ElapsedMilliseconds.ToString());
			}
		}

		#endregion

		#region generazione dei javascript

		private static void SetFilterOnMetaPageJS(field filteredrel, string fullPathMetaPageJS, string tableMetaPageJS, string parentTable, string listType, ref List<field> allfields, List<field> fields, SqlConnection connection, bool setOnGridControl = true) {
			var filteredobj = filteredrel.MetadatoChild ?? filteredrel.Name.Substring(2);
			var filteredListType = filteredrel.Listtype;
			var filteredFields = allfields.Where(af => af.Table == filteredrel.Name.Substring(2) && af.EditListingType == filteredListType
											 && !string.IsNullOrEmpty(af.FilterJs)).ToList();
			if (IsExtendingObject(filteredrel.Name.Substring(2), ref allfields, connection)) {

				var extending = filteredrel.Name.Substring(2);
				var extended = extending.Split('_')[0];
				var extendedListType = GetEditListingTypeForExtended(extending, filteredListType);
				filteredFields.AddRange(allfields.Where(af => af.Table == extended && af.EditListingType == extendedListType && !string.IsNullOrEmpty(af.FilterJs)));
				filteredobj = filteredrel.MetadatoExtendedChild ?? extended;
			}

			var gridId = "grid_" + filteredobj + "_" + filteredListType;

			if (filteredFields.Any()) {

				//poi inserisco le prime assegnazioni per recuperare il filtro principale
				var fatherfilterName = "fatherfilter" + filteredobj + fields.IndexOf(filteredrel);

				if (setOnGridControl)
					SetBeforeFill(fullPathMetaPageJS,
						"var gridParentRels" + filteredobj + fields.IndexOf(filteredrel) + " = self.state.DS.getParentChildRelation(\"" + parentTable + "\", \"" + filteredobj + "\");\r\n" +
						"\t\t\t\tvar " + fatherfilterName + " = gridParentRels" + filteredobj + fields.IndexOf(filteredrel) + "[0].getChildFilter(parentRow);\r\n"
						, tableMetaPageJS, listType);

				var filterFinalName = "finalfilter" + filteredobj + fields.IndexOf(filteredrel);
				var filterList = new List<string>();
				//infine per ogni campo filtrato aggiungo il filtro specifico
				foreach (var filt in filteredFields) {
					var filterGridName = "filterGrid" + filt.Name + fields.IndexOf(filteredrel);
					SetBeforeFill(fullPathMetaPageJS,
						"var " + filterGridName + " = window.jsDataQuery." + GetJsFilter(filt) + ";\r\n", tableMetaPageJS, listType);
					filterList.Add(filterGridName);
				}

				SetBeforeFill(fullPathMetaPageJS,
					"var " + filteredobj + " = this.getDataTable(\"" + filteredobj + "\");\r\n" +
					"\t\t\t\tvar " + filterFinalName + " = window.jsDataQuery.and([" + (setOnGridControl ? fatherfilterName + ", " : "") + string.Join(",", filterList) + "]);\r\n" +
					"\t\t\t\t" + filteredobj + ".rows =  _.filter(" + filteredobj + ".rows, function(r) {return " + filterFinalName + "(r)});\r\n" +
					(setOnGridControl ? "\t\t\t\t$(\"#" + gridId + "\").data(\"customParentRelation\", " + filterFinalName + ");\r\n" : "")
					, tableMetaPageJS, listType);


			}
		}

		private static string GetFullPathMetaDatoJS(string metadato, List<field> allfields, SqlConnection connection) {
			var currentObject = metadato.Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[0];
			var container = currentObject;
			var isExtendingObject = IsExtendingObject(metadato, ref allfields, connection);
			if (isExtendingObject)
				container = GetExtendedObject(metadato, ref allfields, connection, false);
			return clientFolder + metapageFolder + container + "/meta_" + currentObject + ".js";
		}

		/// <summary>
		/// Metodo per la generazione del file javascript del metadato.
		/// Qualora si stia effettuando una rigenerazione di tutta l'applicazione vengono distrutti e ricreati, altrimenti no
		/// </summary>
		/// <param name="path">persorso di destinazione</param>
		/// <param name="container"></param>
		/// <param name="obj"></param>
		/// <param name="app"></param>
		private static void SetMetadatoJs(string path, string container, string obj, string app, List<field> objectKey, bool isExtendingObject, List<field> allfields, SqlConnection connection, string customGetNewRow = null) {

			if (!File.Exists(path)) {

				if (!Directory.Exists(clientFolder + metapageFolder + container))
					Directory.CreateDirectory(clientFolder + metapageFolder + container);

				Copy("../../metapage_template/meta_tabella.js", path, true);
				ReplaceStringInFile(path, "tabella", obj);
				ReplaceStringInFile(path, "_APP_", app);
			}

			//-va aggiunto in index.html
			ReplaceStringInFile(clientFolder + "index.html", "<!-- meta dati -->\r\n",
				"<!-- meta dati -->\r\n	<script src=\"" + metapageFolder + container + "/meta_" + obj + ".js\"></script>\r\n");
			//-va aggiunto in indexdebug.html
			ReplaceStringInFile(clientFolder + "indexdebug.html", "<!-- meta dati -->\r\n",
				"<!-- meta dati -->\r\n	<script src=\"" + metapageFolder + container + "/meta_" + obj + ".js\"></script>\r\n");

			if (!jsalreadyCreated.Contains(path)) {
				jsalreadyCreated.Add(path);

				if (IsView(obj)) {

					//aggiungo le chiavi al metadato vista
					var keyview = "";
					foreach (var k in objectKey) {
						keyview += "\"" + k.Name + "\", ";
					}
					keyview = keyview.Substring(0, keyview.Length - 2);
					var getnewrow = "primaryKey: function () {\r\n" +
							 "\t\t\t\treturn [" + keyview + "];\r\n" +
							 "\t\t\t},\r\n";
					ReplaceStringInFile(path, "//$getNewRow$", getnewrow);

				}
				else {
					var getnewrow = "getNewRow: function (parentRow, dt, editType){\r\n" +
						"               //$getNewRowBody" +
						"			},\r\n";
					if (!string.IsNullOrEmpty(customGetNewRow)) {
						getnewrow = getnewrow.Replace("//$getNewRowBody", customGetNewRow);
					}
					else {
						var getNewRowBody = "var def = appMeta.Deferred(\"getNewRow-meta_" + obj + "\");\r\n" +
							//"				var realParentObjectRow = parentRow ? parentRow.current : undefined;\r\n" +
							"\r\n" +
							"				//$getNewRowInside$\r\n" +
							"\r\n" +
							"//$getNewRowAutoincrement$\r\n" +
							"\r\n" +
							"				// metto i default\r\n" +
							"\t\t\t\treturn this.superClass.getNewRow(parentRow, dt, editType)\r\n" +
							"\t\t\t\t\t.then(function (dtRow) {\r\n" +
							"\t\t\t\t\t\t//$getNewRowDefault$\r\n" +
							"\t\t\t\t\t\treturn def.resolve(dtRow);\r\n" +
							"\t\t\t\t\t});\r\n";
						//aggiungo l'autoincremento alla chiave nel metadato normale 
						var getNewRowAutoincrement = "";
						if (!isExtendingObject)
							foreach (var k in objectKey) {
								if (IsPrincipalKey(k, obj) && k.Type == "int")
									getNewRowAutoincrement += "\t\t\t\tdt.autoIncrement('" + k.Name + "', { minimum: 99990001 });\r\n";

							}
						getnewrow = getnewrow.Replace("//$getNewRowBody", getNewRowBody).Replace("//$getNewRowAutoincrement$\r\n", getNewRowAutoincrement);
					}
					//proviamo con il tag qualora fosse la prima volta che il meta.js viene scritto
					var txtdelfile = ReplaceStringInFile(path, "//$getNewRow$", getnewrow);

					//proviamo a sotituire la eventuale getNewRow giÃƒÂ  implementata in precedenza
					//NOTA BENE se non avvenisse la sostituzione in modo corretto verificare che dopo }, ci sia subito un accapo
					var oldGetnewrow = Regex.Matches(txtdelfile, @"getNewRow: function(.*?)\}\,\r\n", RegexOptions.Singleline).Cast<Match>().Select(m => m.Value.Trim()).Distinct().ToList();
					if (oldGetnewrow.Count() > 0)
						ReplaceStringInFile(path, oldGetnewrow[0], getnewrow);
				}
			}
		}

		/// <summary>
		/// Metodo che aggiunge il describecolumns al metadato JS, verificando la presenza del case per il list type
		/// </summary>
		/// <param name="fullPathMetaDatoJS"></param>
		/// <param name="editListingType"></param>
		/// <param name="describeAColumns"></param>
		private static void SetDescribeColumnsOnJS(string fullPathMetaDatoJS, string editListingType, List<string> describeAColumns, bool overwrite = false) {
			//aggiungo il describecolumns js:
			//prima la singola colonna se giÃƒÂ  esiste l'edit type nella switch
			string stringfilefullPathMetaDatoJS = TextFile.ReadAllTextFile(fullPathMetaDatoJS);
			var caseExist = false;
			var superclassAlreadyReplaced = false;
			foreach (var describeAColumn in describeAColumns) {
				if (stringfilefullPathMetaDatoJS.Contains("//$objCalcFieldConfig_" + editListingType + "$") || caseExist) {
					//esiste giÃƒÂ  il contenitore...

					//... se stavo aggiungendo nuovamente la chiamata alla superclasse non lo faccio perchÃƒÂ¨ giÃƒÂ  ci sono i describecolumns propri ...
					if (!describeAColumn.Contains("return this.superClass.describeColumns(table, listType);")) {

						//...altrimenti occorre verificare se c'ÃƒÂ¨ giÃƒÂ  il contenuto
						var KeyPattern = "case '" + editListingType + "':(.*?)objCalcFieldConfig_" + editListingType;
						var calculatedfields = Regex.Matches(stringfilefullPathMetaDatoJS, KeyPattern, RegexOptions.Singleline).Cast<Match>().Select(m => m.Value).ToList()
										.FirstOrDefault();
						if (calculatedfields != null) {
							//se devo sovrascrivere lo faccio adesso
							if (overwrite && !caseExist) {
								stringfilefullPathMetaDatoJS = ReplaceStringInFile(fullPathMetaDatoJS, calculatedfields,
									"case '" + editListingType + "':\r\n" + describeAColumn + "//$objCalcFieldConfig_" + editListingType, true);
							}
							else {
								if (!calculatedfields.Contains(describeAColumn)) {
									if (calculatedfields.Contains("return this.superClass.describeColumns(table, listType);") && !superclassAlreadyReplaced) {
										//se ÃƒÂ¨ il primo potrei aver giÃƒÂ  messo la chiamata alla superclasse
										ReplaceStringInFile(fullPathMetaDatoJS,
										"\t\t\t\t\t\treturn this.superClass.describeColumns(table, listType);\r\n//$objCalcFieldConfig_" + editListingType + "$", describeAColumn + "//$objCalcFieldConfig_" + editListingType + "$"
											, true);
										superclassAlreadyReplaced = true;
									}
									else
										ReplaceStringInFile(fullPathMetaDatoJS, "//$objCalcFieldConfig_" + editListingType + "$",
											describeAColumn + "//$objCalcFieldConfig_" + editListingType + "$", true);
								}
							}
							overwrite = false;//provo a farlo solo la prima volta 
						}
					}
				}
				else {
					//poi il case
					var describeAColumnCase = "					case '" + editListingType + "':\r\n" + describeAColumn
						+ "//$objCalcFieldConfig_" + editListingType + "$\r\n" + "						break;\r\n";

					ReplaceStringInFile(fullPathMetaDatoJS, "//$objCalcFieldConfig$", describeAColumnCase + "//$objCalcFieldConfig$");
					//poi tutto il metodo
					stringfilefullPathMetaDatoJS = ReplaceStringInFile(fullPathMetaDatoJS, "//$describeColumns$", "describeColumns: function (table, listType) {\r\n" +
											"				var nPos=1;\r\n" +
		/*(fullPathMetaDatoJS.EndsWith("view.js") ? "" :*/ "				var objCalcFieldConfig = {};\r\n" +//) +
											"				var self = this;\r\n" +
											"				_.forEach(table.columns, function (c) {\r\n" +
											"					self.describeAColumn(table, c.name, '', null, -1, null);\r\n" +
											"				});\r\n" +
											"				switch (listType) {\r\n" +
											"					default:\r\n" +
											"						return this.superClass.describeColumns(table, listType);\r\n" +
											 describeAColumnCase +
											"//$objCalcFieldConfig$\r\n" +
											"				}\r\n" +
		(fullPathMetaDatoJS.EndsWith("view.js") ? "" : "				table['customObjCalculateFields'] = objCalcFieldConfig;\r\n" +
											"				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);\r\n") +
											"				return appMeta.Deferred(\"describeColumns\").resolve();\r\n" +
											"			},\r\n");
					caseExist = true;
				}
			}
		}

		/// <summary>
		/// Metodo che aggiunge il describecolumns al metadato JS, verificando la presenza del case per il list type
		/// </summary>
		/// <param name="fullPathMetaDatoJS"></param>
		/// <param name="editListingType"></param>
		/// <param name="setCaptions"></param>
		private static void SetCaptionOnJS(string fullPathMetaDatoJS, string editListingType, List<string> setCaptions) {
			//aggiungo il setcaption :
			//prima la singola colonna se giÃƒÂ  esiste l'edit type nella switch
			string stringfilefullPathMetaDatoJS = TextFile.ReadAllTextFile(fullPathMetaDatoJS);
			var caseExist = false;
			foreach (var setCaption in setCaptions) {
				if (stringfilefullPathMetaDatoJS.Contains("//$innerSetCaptionConfig_" + editListingType + "$") || caseExist) {
					//esiste giÃƒÂ  il contenitore, occorre verificare se c'ÃƒÂ¨ giÃƒÂ  il contenuto
					var KeyPattern = "case '" + editListingType + "':(.*?)innerSetCaptionConfig_" + editListingType;
					var calculatedfields = Regex.Matches(stringfilefullPathMetaDatoJS, KeyPattern, RegexOptions.Singleline).Cast<Match>().Select(m => m.Value).ToList()
									.FirstOrDefault();
					if (calculatedfields != null)
						if (!calculatedfields.Contains(setCaption))
							ReplaceStringInFile(fullPathMetaDatoJS,
							"//$innerSetCaptionConfig_" + editListingType + "$", setCaption + "//$innerSetCaptionConfig_" + editListingType + "$"
							, true);//potrei averlo giÃƒÂ  messo per un altro edittype
				}
				else {
					//poi il case
					var setCaptionCase = "					case '" + editListingType + "':\r\n" + setCaption
						+ "//$innerSetCaptionConfig_" + editListingType + "$\r\n" + "						break;\r\n";

					ReplaceStringInFile(fullPathMetaDatoJS, "//$innerSetCaptionConfig$", setCaptionCase + "//$innerSetCaptionConfig$");
					//poi tutto il metodo
					stringfilefullPathMetaDatoJS = ReplaceStringInFile(fullPathMetaDatoJS, "//$setCaptions$", "setCaption: function (table, edittype) {\r\n" +
											"				switch (edittype) {\r\n" +
											 setCaptionCase +
											"//$innerSetCaptionConfig$\r\n" +
											"				}\r\n" +
											"			},\r\n");
					caseExist = true;
				}
			}
		}

		private static void LoadException(SqlConnection connection) {

			var query = @"select * from appexception";

			var cmdException = new SqlCommand(query, connection);
			var dataReaderException = cmdException.ExecuteReader();
			var exceptionTable = new DataTable();
			exceptionTable.Load(dataReaderException);

			exceptions = exceptionTable.Rows.Cast<DataRow>()
					.Select(row => Tuple.Create(row["item1"].ToString(), row["item2"].ToString(), row["item3"].ToString(), row["item4"].ToString(), row["item5"].ToString() == "S" ? true : false, row["item6"].ToString() == "S" ? true : false))
					.Distinct()
					.ToList();
		}

		/// <summary>
		/// restitusce una stringa contenete la chiamata al metodo DescribeAColumn correttamente valorizzata ed eventualmente anche formattata per il javascript
		/// </summary>
		/// <param name="fi">campo</param>
		/// <param name="colName">nome della colonna della tabella sul dataset (che potrebbe essere calcolato)</param>
		/// <param name="colpos">posizione nell'elenco della foreign key di cui si sta presentanto il campo calcolato</param>
		/// <param name="foreingKeyTitle">title della foreign key di cui si sta presentanto il campo calcolato</param>
		/// <returns></returns>
		private static string GetFormatDescribeColumnJS(field fi, string colName, int? colpos = null, string foreingKeyTitle = null, bool manyTextFields = false) {
			var format = GetFormat(fi);
			var len = (fi.Type == "varchar" || fi.Type == "nvarchar") ? fi.Len.ToString() : "null";

			var title = fi.Title.Replace("'", "\\'");
			if (!string.IsNullOrWhiteSpace(foreingKeyTitle)) {
				if (manyTextFields && fi.Title.Replace("'", "\\'") != foreingKeyTitle.Replace("'", "\\'"))
					title = fi.Title.Replace("'", "\\'") + " " + foreingKeyTitle.Replace("'", "\\'");
				else
					title = foreingKeyTitle.Replace("'", "\\'");
			}

			return "\t\t\t\t\t\tthis.describeAColumn(table, '" + colName + "', '" + title + "', " +
				(string.IsNullOrWhiteSpace(format) ? "null" : "'" + format + "'") + ", " +
				(colpos ?? (fi.SortList * 10)).ToString() + ", " + (colName.StartsWith("!") ? "null" : len) + ");\r\n"; ;
		}

		/// <summary>
		/// Metodo che aggiunge un comando alla afterlink
		/// </summary>
		/// <param name="fullPathMetaPageJS"></param>
		/// <param name="commands"></param>
		private static void SetBeforePost(string fullPathMetaPageJS, string commands) {
			//aggiungo tutto l'evento se manca
			ReplaceStringInFile(fullPathMetaPageJS, "//beforePost\r\n",
				"beforePost: function () {\r\n" +
				"\t\t\t\tvar self = this;\r\n" +
				"\t\t\t\t//innerBeforePost\r\n" +
				"\t\t\t},\r\n");
			//poi i comandi
			ReplaceStringInFile(fullPathMetaPageJS, "//innerBeforePost\r\n", commands + "\t\t\t\t//innerBeforePost\r\n");
		}

		/// <summary>
		/// Metodo che aggiunge un comando alla afterlink
		/// </summary>
		/// <param name="fullPathMetaPageJS"></param>
		/// <param name="commands"></param>
		private static void SetAfterlink(string fullPathMetaPageJS, string commands) {
			//aggiungo tutto l'evento se manca
			ReplaceStringInFile(fullPathMetaPageJS, "//afterLink\r\n",
				"afterLink: function () {\r\n" +
				"\t\t\t\tvar self = this;\r\n" +
				"\t\t\t\t//fireAfterLink\r\n" +
				"\t\t\t\treturn this.superClass.afterLink.call(this).then(function () {\r\n" +
				"\t\t\t\t\tvar arraydef = [];\r\n" +
				"\t\t\t\t\t//fireAfterLinkAsinc\r\n" +
				"\t\t\t\t\treturn $.when.apply($, arraydef);\r\n" +
				"\t\t\t\t});\r\n" +
				"\t\t\t},\r\n");
			//poi i comandi
			ReplaceStringInFile(fullPathMetaPageJS, "//fireAfterLink\r\n", commands + "\t\t\t\t//fireAfterLink\r\n");
		}

		/// <summary>
		/// Metodo che aggiunge un comando alla afterlink
		/// </summary>
		/// <param name="fullPathMetaPageJS"></param>
		/// <param name="commands"></param>
		private static void SetAfterlinkAsinc(string fullPathMetaPageJS, string commands) {
			//aggiungo tutto l'evento se manca
			ReplaceStringInFile(fullPathMetaPageJS, "//afterLink\r\n",
				"afterLink: function () {\r\n" +
				"\t\t\t\tvar self = this;\r\n" +
				"\t\t\t\t//fireAfterLink\r\n" +
				"\t\t\t\treturn this.superClass.afterLink.call(this).then(function () {\r\n" +
				"\t\t\t\t\tvar arraydef = [];\r\n" +
				"\t\t\t\t\t//fireAfterLinkAsinc\r\n" +
				"\t\t\t\t\treturn $.when.apply($, arraydef);\r\n" +
				"\t\t\t\t});\r\n" +
				"\t\t\t},\r\n");
			//poi i comandi
			ReplaceStringInFile(fullPathMetaPageJS, "//fireAfterLinkAsinc\r\n", "arraydef.push(" + commands + ");\r\n\t\t\t\t\t//fireAfterLinkAsinc\r\n");
		}

		/// <summary>
		/// Metodo che aggiunge un comando sincrono alla beforeFill
		/// </summary>
		/// <param name="fullPathMetaPageJS"></param>
		/// <param name="commands"></param>
		private static void SetBeforeFill(string fullPathMetaPageJS, string commands, string table, string edittype, bool removeTab = false) {
			//aggiungo tutto l'evento se manca
			ReplaceStringInFile(fullPathMetaPageJS, "//beforeFill\r\n", "beforeFill: function () {\r\n" +
							  "				//parte sincrona\r\n" +
							  "				var self = this;\r\n" +
							  "				var parentRow = self.state.currentRow;\r\n" +
							  "				\r\n" +
							  "				//beforeFillFilter\r\n" +
							  "				\r\n" +
							  "				//parte asincrona\r\n" +
							  "				var def = appMeta.Deferred(\"beforeFill-" + table + "_" + edittype + "\");\r\n" +
							  "				var arraydef = [];\r\n" +
							  "				\r\n" +
							  "				//beforeFillInside\r\n" +
							  "				\r\n" +
							  "				$.when.apply($, arraydef)\r\n" +
							  "					.then(function () {\r\n" +
							  "						return self.superClass.beforeFill.call(self)\r\n" +
							  "							.then(function () {\r\n" +
							  "								return def.resolve();\r\n" +
							  "							});\r\n" +
							  "					});\r\n" +
							  "				return def.promise();\r\n" +
							  "			},\r\n");
			//poi i comandi
			ReplaceStringInFile(fullPathMetaPageJS, (removeTab ? "\t\t\t\t" : "") + "//beforeFillFilter\r\n", commands + "\t\t\t\t//beforeFillFilter\r\n");
		}

		/// <summary>
		/// Metodo che aggiunge un comando asincrono alla beforeFill
		/// </summary>
		/// <param name="fullPathMetaPageJS"></param>
		/// <param name="commands"></param>
		private static void SetBeforeFillAsinc(string fullPathMetaPageJS, string commands, string table, string edittype, bool removeTab = false, bool skipCheckExistence = false) {
			//aggiungo tutto l'evento se manca
			ReplaceStringInFile(fullPathMetaPageJS, "//beforeFill\r\n", "beforeFill: function () {\r\n" +
							  "				//parte sincrona\r\n" +
							  "				var self = this;\r\n" +
							  "				var parentRow = self.state.currentRow;\r\n" +
							  "				\r\n" +
							  "				//beforeFillFilter\r\n" +
							  "				\r\n" +
							  "				//parte asincrona\r\n" +
							  "				var def = appMeta.Deferred(\"beforeFill-" + table + "_" + edittype + "\");\r\n" +
							  "				var arraydef = [];\r\n" +
							  "				\r\n" +
							  "				//beforeFillInside\r\n" +
							  "				\r\n" +
							  "				$.when.apply($, arraydef)\r\n" +
							  "					.then(function () {\r\n" +
							  "						return self.superClass.beforeFill.call(self)\r\n" +
							  "							.then(function () {\r\n" +
							  "								return def.resolve();\r\n" +
							  "							});\r\n" +
							  "					});\r\n" +
							  "				return def.promise();\r\n" +
							  "			},\r\n");
			//poi i comandi
			ReplaceStringInFile(fullPathMetaPageJS, (removeTab ? "\t\t\t\t" : "") + "//beforeFillInside\r\n", commands + "\t\t\t\t//beforeFillInside\r\n", skipCheckExistence);
		}

		private static void SetRowSelected(string fullPathMetaPageJS, string commands) {
			//se ÃƒÂ¨ il primo bottone di pagina aggiungo tutto il rowSelected event ...
			ReplaceStringInFile(fullPathMetaPageJS, "//pageHeaderDeclaration\r\n", "this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);\r\n" +
				"\t\t//pageHeaderDeclaration\r\n");
			ReplaceStringInFile(fullPathMetaPageJS, "//rowSelected",
				"rowSelected: function (dataRow) {\r\n" +
				"\t\t\t\t//firerowSelected\r\n" +
				"\t\t\t},\r\n");

			//poi i comandi
			ReplaceStringInFile(fullPathMetaPageJS, "//firerowSelected\r\n", commands + "\t\t\t\t//firerowSelected\r\n");
		}

		private static void SetButtonClickEnd(string fullPathMetaPageJS, string commands, bool isRel = false) {
			//se ÃƒÂ¨ il primo bottone di pagina aggiungo tutto il buttonClickEnd event ...
			ReplaceStringInFile(fullPathMetaPageJS, "//pageHeaderDeclaration\r\n", "appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);\r\n" +
				"\t\t//pageHeaderDeclaration\r\n");
			ReplaceStringInFile(fullPathMetaPageJS, "//buttonClickEnd", "buttonClickEnd: function (currMetaPage, cmd) {\r\n" +
				"\t\t\t\t//fireRelButtonClickEnd\r\n" +
				"\t\t\t\tcmd = cmd.toLowerCase();\r\n" +
				"\t\t\t\tif (cmd === \"mainsetsearch\") {\r\n" +
				"\t\t\t\t\t//firebuttonClickEnd\r\n" +
				"\t\t\t\t}\r\n" +
				"\t\t\t\treturn this.superClass.buttonClickEnd(currMetaPage, cmd);\r\n" +
				"\t\t\t},\r\n");
			//... altrimenti solo la disabilitazione tra il bottone e l'evento all'interno del buttonClickEnd
			ReplaceStringInFile(fullPathMetaPageJS, isRel ? "//fireRelButtonClickEnd" : "//firebuttonClickEnd",
				commands + "\t\t\t\t" + (isRel ? "//fireRelButtonClickEnd" : "\t//firebuttonClickEnd"), true);

		}

		/// <summary>
		/// Inserisce codice aggiuntivo javascript
		/// </summary>
		/// <param name="fullPathMetaPageJS"></param>
		/// <param name="code"></param>
		private static void SetBottomCode(string fullPathMetaPageJS, string code) {
			ReplaceStringInFile(fullPathMetaPageJS, "//buttons\r\n", code + ",\r\n\r\n\t\t\t//buttons\r\n");
		}

		/// <summary>
		/// Aggiunge l'afterfill alla metapage js
		/// </summary>
		/// <param name="fullPathMetaPageJS"></param>
		/// <param name="commands"></param>
		/// <param name="deferredName"></param>
		private static void SetAfterFill(string fullPathMetaPageJS, string commands) {
			ReplaceStringInFile(fullPathMetaPageJS, "//afterFill\r\n", "afterFill: function () {\r\n" +
				"\t\t\t\t//afterFillin\r\n" +
				"\t\t\t\treturn this.superClass.afterFill.call(this);\r\n" +
				"\t\t\t},\r\n");
			ReplaceRegExInFile(fullPathMetaPageJS, @"afterFill: function \(\) {(.*?)\/\/afterFillin", commands + "\t\t\t\t//afterFillin", true);
		}

		/// <summary>
		/// Aggiunge l'afterClear alla metapage js
		/// </summary>
		/// <param name="fullPathMetaPageJS"></param>
		/// <param name="commands"></param>
		/// <param name="deferredName"></param>
		private static void SetAfterClear(string fullPathMetaPageJS, string commands, bool skipCheckExistence = false/*, string deferredName*/) {
			ReplaceStringInFile(fullPathMetaPageJS, "//afterClear\r\n", "afterClear: function () {\r\n" +
				"\t\t\t\t//afterClearin\r\n" +
				"\t\t\t},\r\n");
			ReplaceStringInFile(fullPathMetaPageJS, "//afterClearin", commands + "\t\t\t\t//afterClearin", skipCheckExistence);
		}

		/// <summary>
		/// Aggiunge l'insertClick alla metapage js
		/// </summary>
		/// <param name="fullPathMetaPageJS"></param>
		/// <param name="commands"></param>
		/// <param name="deferredName"></param>
		private static void SetInsertClick(string fullPathMetaPageJS, string commands) {
			ReplaceStringInFile(fullPathMetaPageJS, "//insertClick\r\n", "insertClick: function (that, grid) {\r\n" +
				"\t\t\t\t//insertClickin\r\n" +
				"\t\t\t\treturn this.superClass.insertClick(that, grid);\r\n" +
				"\t\t\t},\r\n");
			var txt = ReplaceStringInFile(fullPathMetaPageJS, "//insertClickin\r\n", commands + "\t\t\t\t//insertClickin\r\n");
			if (!txt.Contains(commands))
				ReplaceStringInFile(fullPathMetaPageJS, "//insertClickin\n", commands + "\t\t\t\t//insertClickin\r\n");
		}

		/// <summary>
		/// Aggiunge l'afterRowSelect alla metapage js
		/// </summary>
		/// <param name="fullPathMetaPageJS"></param>
		/// <param name="commands"></param>
		/// <param name="asincCmmands"></param>
		/// <param name="table"></param>
		/// <param name="editListingTypes"></param>
		private static void SetAfterRowSelect(string fullPathMetaPageJS, string commands, string asincCmmands, string table, string editListingTypes) {
			//aggiungo tutto l'evento se manca
			ReplaceStringInFile(fullPathMetaPageJS, "//afterRowSelect\r\n", "afterRowSelect: function (t, r) {\r\n\t\t\t\tvar def = appMeta.Deferred(\"afterRowSelect-" +
				table + "_" + editListingTypes + "\");\r\n\t\t\t\t//afterRowSelectin\r\n\t\t\t\treturn def.resolve();\r\n\t\t\t},\r\n");

			//poi i comandi
			if (!string.IsNullOrWhiteSpace(commands))
				ReplaceStringInFile(fullPathMetaPageJS, "//afterRowSelectin\r\n", commands + "\t\t\t\t//afterRowSelectin\r\n");

			if (!string.IsNullOrWhiteSpace(asincCmmands)) {
				//successivi comandi asincroni
				ReplaceStringInFile(fullPathMetaPageJS, "//afterRowSelectAsincIn\r\n", asincCmmands + "\t\t\t\t//afterRowSelectAsincIn\r\n");

				//primo dei comandi asincroni
				ReplaceStringInFile(fullPathMetaPageJS, "\t\t\t\tvar def = appMeta.Deferred(\"afterRowSelect-" + table + "_" + editListingTypes + "\");\r\n", "");
				ReplaceStringInFile(fullPathMetaPageJS, "//afterRowSelectin\r\n\t\t\t\treturn def.resolve();\r\n",
					"//afterRowSelectin\r\n\t\t\t\tvar arraydef = [];\r\n\t\t\t\tvar self = this;\r\n\t\t\t\t" + asincCmmands +
					"\t\t\t\t//afterRowSelectAsincIn\r\n\t\t\t\treturn $.when.apply($, arraydef);\r\n");
			}
		}

		/// <summary>
		/// Aggiunge l'afterActivation alla metapage js
		/// </summary>
		/// <param name="fullPathMetaPageJS"></param>
		/// <param name="commands"></param>
		/// <param name="asincCmmands"></param>
		/// <param name="table"></param>
		/// <param name="editListingTypes"></param>
		private static void SetAfterActivation(string fullPathMetaPageJS, string commands, string asincCmmands, string table, string editListingTypes) {
			//aggiungo tutto l'evento se manca
			ReplaceStringInFile(fullPathMetaPageJS, "//afterActivation\r\n", "afterActivation: function () {\r\n\t\t\t\tvar def = appMeta.Deferred(\"afterActivation-" +
				table + "_" + editListingTypes + "\");\r\n\t\t\t\tvar parentRow = this.state.currentRow;\r\n\t\t\t\tvar self = this;\r\n\t\t\t\t//afterActivationin\r\n\t\t\t\treturn def.resolve();\r\n\t\t\t},\r\n");

			//poi i comandi
			if (!string.IsNullOrWhiteSpace(commands))
				ReplaceStringInFile(fullPathMetaPageJS, "//afterActivationin\r\n", commands + "\t\t\t\t//afterActivationin\r\n");

			if (!string.IsNullOrWhiteSpace(asincCmmands)) {
				//successivi comandi asincroni
				ReplaceStringInFile(fullPathMetaPageJS, "//afterActivationAsincIn\r\n", asincCmmands + "\t\t\t\t//afterActivationAsincIn\r\n");

				//primo dei comandi asincroni
				ReplaceStringInFile(fullPathMetaPageJS, "\t\t\t\tvar def = appMeta.Deferred(\"afterActivation-" + table + "_" + editListingTypes + "\");\r\n", "");
				ReplaceStringInFile(fullPathMetaPageJS, "//afterActivationin\r\n\t\t\t\treturn def.resolve();\r\n", "//afterActivationin\r\n\t\t\t\tvar arraydef = [];\r\n\t\t\t\t" + asincCmmands +
					"\t\t\t\t//afterActivationAsincIn\r\n\t\t\t\treturn $.when.apply($, arraydef);\r\n");

			}
		}
		private static List<string> middleList = new List<string>();
		private static List<string> rootChildList = new List<string>();

		/// <summary>
		/// metodo ricorsivo per trovare tutti i nodi del ramo della pagina modificata
		/// </summary>
		/// <param name="page"></param>
		/// <param name="connection"></param>
		private static void GetMiddleList(string page, SqlConnection connection) {
			Console.Write(".");
			//aggiungo la pagina corrente alla lista intermedia
			if (!(middleList.Any(item => item == page)))
				middleList.Add(page);

			//ricavo tutte le pagine parent
			var parentPageIdList = GetParentPagesId(page, connection);

			//se non ha pagina parent la aggiungo alla lista delle pagine principali
			if (!parentPageIdList.Any())
				rootChildList.Add(page);

			//per tutte le pagine parent ripeto quanto fatto per la pagina corrente (per la coerenza dei dataset)
			foreach (var parentPage in parentPageIdList.Except(middleList)) {
				GetMiddleList(parentPage, connection);
			}
		}

		/// <summary>
		/// metodo che calcola tutti i nodi potenzialmente coinvolti nella modifica e
		/// </summary>
		/// <param name="oldPageList"></param>
		/// <param name="connection"></param>
		/// <returns></returns>
		private static List<string> GetNewPageList(List<string> oldPageList, SqlConnection connection) {
			//per ogni pagina da rigenerare perchÃƒÂ¨ modificata
			foreach (var oldPage in oldPageList) {
				//ricavo ricorsivamente una lista intermedia contenente: 
				//tutte le pagine parent fino alla pagina principale perchÃƒÂ¨ tutti i dataset devono essere coerenti
				////tutte le pagine figlie perchÃƒÂ¨ distruggo e ricreo i describe columns al primo passaggio sul metadato 
				GetMiddleList(oldPage, connection);

				//devo aggiungere anche i figli
			}

			//visito in ampiezza l'albero che ne scaturisce per ordinare tutta la lista dalle radice alle foglie ordinate per livello
			//partendo dalla radice
			var newList = new List<string>();
			newList.AddRange(rootChildList);
			int i = 0;
			while (i < newList.Count) {
				Console.Write(".");
				//una volta che rigenero la pagina devo rigenerare anche i figli di 3 livelli (caso peggiore di oggetto collegato da oggetto di collegamento con figlio uno a uno)
				//per essere sicuro che loro aggiungano i describecolumns normali metre le pagine parent i campi calcolati
				var childPageList = GetChildPagesId(newList[i], connection).Intersect(middleList); ;
				foreach (var childpage in childPageList) {
					if (!newList.Any(item => item == childpage))
						newList.Add(childpage);
				}
				i++;
			}

			//inverto l'ordine perchÃƒÂ¨ devo rigenerare prima le foglie
			newList.Reverse();

			return newList;
		}

		/// <summary>
		/// Aggiunge un comando alla afterGetFormData della metapage js
		/// </summary>
		/// <param name="fullPathMetaPageJS"></param>
		/// <param name="commands"></param>
		/// <param name="table"></param>
		/// <param name="editListingTypes"></param>
		private static void SetAfterGetFormData(string fullPathMetaPageJS, string commands, string table, string editListingTypes, bool sync = false, bool skipCheckExistence = false) {
			ReplaceStringInFile(fullPathMetaPageJS, "//afterGetFormData\r\n", "afterGetFormData: function () {\r\n" +
		"				//parte sincrona\r\n" +
		"				var self = this;\r\n" +
		"				var parentRow = self.state.currentRow;\r\n" +
		"				\r\n" +
		"				//afterGetFormDataFilter\r\n" +
		"				\r\n" +
		"				//parte asincrona\r\n" +
		"				var def = appMeta.Deferred(\"afterGetFormData-" + table + "_" + editListingTypes + "\");\r\n" +
		"				var arraydef = [];\r\n" +
		"				\r\n" +
		"				//afterGetFormDataInside\r\n" +
		"				\r\n" +
		"				$.when.apply($, arraydef)\r\n" +
		"					.then(function () {\r\n" +
		"						return def.resolve();\r\n" +
		"					});\r\n" +
		"				return def.promise();\r\n" +
		"			},\r\n");
			ReplaceStringInFile(fullPathMetaPageJS, sync ? "//afterGetFormDataFilter\r\n" : "//afterGetFormDataInside\r\n",
				(sync ? "" : "arraydef.push(") + commands + (sync ? ";\r\n\t\t\t\t//afterGetFormDataFilter\r\n" : ");\r\n\t\t\t\t//afterGetFormDataInside\r\n"), skipCheckExistence);
		}

		/// <summary>
		/// Metodo che aggiunge lo static filter al metadato JS, verificando la presenza del case per il list type
		/// </summary>
		/// <param name="fullPathMetaDato"></param>
		/// <param name="editListingType"></param>
		/// <param name="describeAColumns"></param>
		private static void SetGetStaticFilterOnJS(string fullPathMetaDatoJS, string editListingType, string staticfilter) {
			//!!!ATTENZIONE!!!
			//i filtri statici su js andrebbero: 1) riscritti come jsdataquery che non ha le subquery 2) le variabili di sistema andrebbero richiamate in modo diverso 
			//quindi per ora lasciamo gli static filter solo su c# e quando il FW sara totalmente javascript andranno riscritti tutti

			//aggiungo il describecolumns js:
			//prima la singola colonna se giÃƒÂ  esiste l'edit type nella switch
			string stringfilefullPathMetaDato = TextFile.ReadAllTextFile(fullPathMetaDatoJS);
			if (!stringfilefullPathMetaDato.Contains("getStaticFilter: function (listType)")) {
				ReplaceStringInFile(fullPathMetaDatoJS, "//$GetStaticFilter$", @"getStaticFilter: function (listType) {
				switch (listType) {
					//$GetStaticFilter$
				}
				return this.superClass.getStaticFilter(listType);
			}");
			}

			var getStaticfilter = "				case \"" + editListingType + "\": {\r\n";
			getStaticfilter += "						return \"" + staticfilter + "\";\r\n";
			getStaticfilter += "						break;\r\n					}\r\n				//$GetStaticFilter$";
			ReplaceStringInFile(fullPathMetaDatoJS, "				//$GetStaticFilter$", getStaticfilter);

		}

		/// <summary>
		/// metodo che aggiunge il get sorting ad un metadato javascript
		/// </summary>
		/// <param name="fullPathMetaDatoJS"></param>
		/// <param name="editListingTypes"></param>
		/// <param name="sortString"></param>
		private static void SetGetSorting(string fullPathMetaDatoJS, string editListingTypes, string sortString) {
			ReplaceStringInFile(fullPathMetaDatoJS, "//$getSorting$", "getSorting: function (listType) {\r\n" +
				"\t\t\t\tswitch (listType) {\r\n" +
				"\t\t\t\t\t//$getSortingin$\r\n" +
				"\t\t\t\t}\r\n" +
				"\t\t\t\treturn this.superClass.getSorting(listType);\r\n" +
				"\t\t\t}");

			var getSorting = "case \"" + editListingTypes + "\": {\r\n" +
						"\t\t\t\t\t\treturn \"" + sortString + "\";\r\n" +
						"\t\t\t\t\t}\r\n" +
						"\t\t\t\t\t//$getSortingin$";
			ReplaceStringInFile(fullPathMetaDatoJS, "//$getSortingin$", getSorting);

		}

		/// <summary>
		/// scrive un elemento dell'array di test
		/// </summary>
		/// <param name="fullPathTest"></param>
		/// <param name="input"></param>
		private static void SetArrayInputTest(string fullPathTest, string input, field fi = null) {
			if (fi != null)
				// da vedere isparentkey
				if (fi.Name.StartsWith("!") || fi.Readonlyfield || IsParentkey(fi))
					return;
			ReplaceStringInFile(fullPathTest, "//arrayInput\r\n",
			(fullPathTest.EndsWith("spec.js") ? "" : "this.") + "arrayInput.push(" + input + ");\r\n" + (fullPathTest.EndsWith("spec.js") ? "\t\t\t" : "") + "\t\t//arrayInput\r\n");
		}

		/// <summary>
		/// restituisce il filtro JSDataQuery a partire da un field
		/// </summary>
		/// <param name="f"></param>
		/// <returns></returns>
		private static string GetJsFilter(field f) {
			var jsDQFun = f.FilterJs.Split('$')[0];
			var jsDQMem = f.FilterJs.Split('$')[1];
			return jsDQFun + "(\"" + f.Name + "\"" + (string.IsNullOrWhiteSpace(jsDQMem) ? "" : ", " + jsDQMem) + ")";
		}

		#endregion

		#region gestione dei fields
		private static bool IsSinistro(int index, bool isinverted) {
			bool dispari = (index % 2 != 0);
			return isinverted ? !dispari : dispari;
		}
		/// <summary>
		/// Recupera il valore minimo di una data colonna in un determinata tabella
		/// </summary>
		/// <param name="field"></param>
		/// <param name="connection"></param>
		/// <param name="returnNullString">restituisce valori null come stringa</param>
		/// <returns></returns>
		public static object GetTopTableValue(field field, SqlConnection connection, bool returnNullString = false) {
			if (field != null) {
				var sql = "SELECT TOP 1 " + field.Name + " FROM  " + field.Schema + "." + field.Table + " ORDER BY " + field.Name;
				SqlCommand cmdTopValue = new SqlCommand(sql, connection);
				cmdTopValue.CommandTimeout = 1200;
				try {
					//return cmdTopValue.ExecuteScalar();
					SqlDataReader dataReaderTopValue = cmdTopValue.ExecuteReader();
					var colonneobj = new DataTable();
					colonneobj.Load(dataReaderTopValue);
					if (colonneobj.Rows.Count > 0)
						return (colonneobj.Rows[0][field.Name] == DBNull.Value) ? (returnNullString ? "null" : null) : colonneobj.Rows[0][field.Name];
				}
				catch (Exception ex) {
				}
				return null;
			}
			return null;

		}
		/// <summary>
		/// Recupera dal DB le colonne della tabella o della chiave passata come parametro
		/// </summary>
		/// <param name="tablename">tabella</param>
		/// <param name="tablekey">chiave</param>
		/// <param name="allfields">campi da popolare</param>
		/// <param name="connection">connessione</param>
		private static void GetMissingFields(string tablename, string tablekey, ref List<field> allfields, SqlConnection connection, bool showmessage = true) {
			if (!string.IsNullOrEmpty(tablename)) {
				tablename = RemoveAlias(tablename);
				//se giÃƒÂ  c'ÃƒÂ¨ non faccio nulla
				if (allfields.Any(af => af.Table == tablename))
					return;
			}
			else {
				//ripulisco la chiave da prefissi e suffissi
				tablekey = GetIdByForeignKey(tablekey, null);
				//se giÃƒÂ  c'ÃƒÂ¨ non faccio nulla
				if (allfields.Any(af => af.Name == tablekey && af.IsKey && IsPrincipalKey(af, af.Table)))
					return;
			}

			//passate le verifiche precedenti me li prendo dal db
			var queryColonne = "";
			var queryWhere = "isnull(a.idapplicazione,0) = (select top 1 isnull(t.idapplicazione,0) from #temp t where t.TABLE_NAME = isc.TABLE_NAME order by ord) ";
			//				" (a.idapplicazione = " + applicationID + @" or a.idapplicazione is null or 
			//(not exists(select ap.idapppages from apppages ap where ap.idapplicazione = " + applicationID + @" and ap.tablename = td.tablename)
			//and exists(select ap.idapppages from apppages ap where ap.idapplicazione <> " + applicationID + @" and ap.tablename = td.tablename)
			//and a.idapplicazione = (select top(1) ap.idapplicazione from apppages ap where ap.idapplicazione <> " + applicationID + @" and ap.tablename = td.tablename order by ap.idapplicazione))) 
			//";

			if (string.IsNullOrEmpty(tablekey)) {
				queryWhere += "and isc.TABLE_NAME = '" + tablename + "'";

				queryColonne = string.Format(queryTempFields, applicationID) + "\r\n" + queryFields + "\r\n where " + queryWhere + "\r\n UNION \r\n" +
					queryFields2 + "\r\n where fd.columnname like '!%' and " + queryWhere.Replace("isc.TABLE_NAME", "ttd.tablename")
					+ "\r\n drop table #temp";
			}
			else {
				queryWhere +=
				@"and isc.TABLE_NAME in (SELECT cc.TABLE_NAME 
										 FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE cc 
										 WHERE cc.COLUMN_NAME = '" + tablekey + @"' AND 
										 OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + QUOTENAME(CONSTRAINT_NAME)), 'IsPrimaryKey') = 1
										 /*order by LEN(cc.TABLE_NAME)*/)";

				queryColonne = string.Format(queryTempFields, applicationID) + "\r\n" + queryFields + "\r\n where " + queryWhere + "\r\n UNION \r\n" +
					queryFields2 + "\r\n where fd.columnname like '!%' and " + queryWhere.Replace("isc.TABLE_NAME", "ttd.tablename")
					+ "\r\n drop table #temp";
			}

			SqlCommand comd = new SqlCommand(queryColonne, connection);
			comd.CommandTimeout = 1200;
			var dataReaderMiss = comd.ExecuteReader();
			var colonneMiss = new DataTable();
			colonneMiss.Load(dataReaderMiss);

			if (showmessage && verbose && colonneMiss.Rows.Count == 0) {
				if (!string.IsNullOrEmpty(tablename))
					ConsoleWriter.WarningDB("Per la tabella " + tablename + " non ÃƒÂ¨ stato trovato alcun campo.");
				if (!string.IsNullOrEmpty(tablekey))
					ConsoleWriter.WarningDB("Per la chiave " + tablekey + " non ÃƒÂ¨ stato trovata alcuna tabella e di conseguenza alcun campo.");
			}

			SetFieldsByRows(colonneMiss, ref allfields);
			if (allfields.Any(f => !f.IsInVoc && f.Name != "idapppages_ext" && !f.Name.StartsWith("XX"))) {
				var errorFields = string.Join(", ", allfields.Where(f => !f.IsInVoc).Select(e => e.Table + "." + e.Name).ToList());
				ConsoleWriter.ErrorDB("Il vocabolario dei dati non ÃƒÂ¨ aggiornato per le seguenti colonne:\r\n" + errorFields);
			}
		}

		/// <summary>
		/// Inserisce nei fields i campi presenti nelle rows
		/// </summary>
		/// <param name="colonne"></param>
		/// <param name="allfields"></param>
		public static void SetFieldsByRows(DataTable colonne, ref List<field> allfields) {
			foreach (DataRow r in colonne.Rows) {
				var tabname = string.IsNullOrEmpty(r["tab"].ToString()) ? "Principale" : r["tab"].ToString();
				var isLogField = r["field"].ToString() == "ct" || r["field"].ToString() == "cu" || r["field"].ToString() == "lt" || r["field"].ToString() == "lu";
				if (!(new List<string> { "idman", "idsor05", "idsor04", "idsor03", "idsor02", "idsor01" }).Contains(r["field"].ToString()) //gestione naming non standard
					) {
					var f = new field
					{
						Name = r["field"].ToString(),
						IsAltTitle = !string.IsNullOrEmpty(r["alttitle"].ToString()) && r["sqltype"].ToString() != "file" ? "S" : "N",
						Title = !string.IsNullOrEmpty(r["alttitle"].ToString()) ?
						  r["alttitle"].ToString().Replace("\"", "\\\"") :
						  (!string.IsNullOrEmpty(r["description"].ToString()) ?
							 r["description"].ToString().Replace("\"", "\\\"") :
							 (r["iskey"].ToString() == "S" ?
								"Identificativo" :
								r["field"].ToString().First().ToString().ToUpper() + r["field"].ToString().Substring(1))),
						Sort = int.Parse(string.IsNullOrEmpty(r["detailposition"].ToString()) ? "0" : r["detailposition"].ToString()),
						SortList = int.Parse(string.IsNullOrEmpty(r["listposition"].ToString()) ? "0" : r["listposition"].ToString()),
						Type = r["sqltype"].ToString(),
						Len = int.Parse(string.IsNullOrEmpty(r["col_len"].ToString()) ? "0" : r["col_len"].ToString()),
						Tab = tabname,
						Icon = string.IsNullOrEmpty(r["tabicon"].ToString()) ? r["icon"].ToString() : r["tabicon"].ToString(),
						Tabposition = int.Parse(string.IsNullOrEmpty(r["tabposition"].ToString()) ? "0" : r["tabposition"].ToString()),
						Table = r["tablename"].ToString(),
						Schema = r["schema"].ToString(),
						IsKey = r["iskey"].ToString() == "S", //se in bianco lo prendo per un NO
						Detailvisible = r["detailvisible"].ToString() != "N" && !isLogField, //se in bianco lo prendo per un SI
						ListVisible = r["listvisible"].ToString() != "N" && !isLogField, //se in bianco lo prendo per un SI
						Allownull = r["allownull"].ToString() != "N", //se in bianco lo prendo per un SI 
						DenyNull = r["denyNull"].ToString() == "S",
						SortData = r["getsorting"].ToString(),
						PageId = r["idapppages"].ToString(),
						Defaultvalue = r["defaultvalue"].ToString(),
						EditListingType = string.IsNullOrEmpty(r["editlistingtype"].ToString()) ? "default" : r["editlistingtype"].ToString(),
						//Textfield = r["textfield"].ToString() == "" ? 0 : int.Parse(r["textfield"].ToString()),
						Textfield = int.Parse(string.IsNullOrEmpty(r["textfield"].ToString()) ? "0" : r["textfield"].ToString()),
						Radiovalues = r["radiovalues"].ToString(),
						IsLinkingObj = r["islinkingobj"].ToString() == "S", //se in bianco lo prendo per un NO
						Hidden = r["hidden"].ToString() == "S", //se in bianco lo prendo per un NO
						Listtype = r["listtype"].ToString(),
						Filter = r["filter"].ToString(),
						FilterJs = r["filterjs"].ToString(),
						Textarea = r["textarea"].ToString() == "S",//se in bianco lo prendo per un NO
						IsCheckbox = r["ischeckbox"].ToString() == "S",//se in bianco lo prendo per un NO
						Text = r["text"].ToString(),
						UniqueOnRow = r["uniqueonrow"].ToString() == "S",//se in bianco lo prendo per un NO
						Tabheader = r["tabheader"].ToString(),
						Readonlyfield = r["readonlyfield"].ToString() == "S",//se in bianco lo prendo per un NO
						Master = r["master"].ToString(),
						TableFilter = r["tablefilter"].ToString(),
						Calculatedfieldfunction = r["calculatedfieldfunction"].ToString(),
						Testvalue = r["testvalue"].ToString(),
						Summary = r["summary"].ToString(),
						HaveView = r["haveview"].ToString() == "S",
						Prefix = r["textfieldprefix"].ToString(),
						Charnumber = int.Parse(string.IsNullOrEmpty(r["charnumber"].ToString()) ? "2" : r["charnumber"].ToString()),
						ForceAlias = int.Parse(string.IsNullOrEmpty(r["forcealias"].ToString()) ? "0" : r["forcealias"].ToString()),
						ForceDropDown = r["forcedropdown"].ToString() == "S",
						//MasterField = string.IsNullOrEmpty(r["idappfielddetail_parent"].ToString()) ? (int?)null : int.Parse(r["idappfielddetail_parent"].ToString()),
						IdAppFieldDetail = string.IsNullOrEmpty(r["idappfielddetail"].ToString()) ? (int?)null : int.Parse(r["idappfielddetail"].ToString()),
						AfterActivationPrefill = r["afteractivationprefill"].ToString(),
						AfterRowSelectPrefill = r["afterrowselectprefill"].ToString(),
						TableTitle = (r["title"] != null ? r["title"].ToString() : r["tablename"].ToString()),
						EventText = r["eventtext"].ToString(),
						EventType = r["eventtype"].ToString(),
						IsInVoc = r["isInVoc"].ToString() == "S",
						IdAppFieldDetail_sortmember = string.IsNullOrEmpty(r["idappfielddetail_sortmember"].ToString()) ? (int?)null : int.Parse(r["idappfielddetail_sortmember"].ToString()),
						Editable = r["editable"].ToString() == "S",
						Specialcontrol = r["specialcontrol"].ToString(),
						Val1 = string.IsNullOrEmpty(r["val1"].ToString()) ? (int?)null : int.Parse(r["val1"].ToString()),
						Val2 = string.IsNullOrEmpty(r["val2"].ToString()) ? (int?)null : int.Parse(r["val2"].ToString()),
						Min = string.IsNullOrEmpty(r["min"].ToString()) ? (int?)null : int.Parse(r["min"].ToString()),
						Max = string.IsNullOrEmpty(r["max"].ToString()) ? (int?)null : int.Parse(r["max"].ToString())
					};

					//se ÃƒÂ¨ un vocabolario configuro i fields in automatico
					if (f.Table.Contains("kind") || f.Table.Contains("status") || f.Table.Contains("stato")
						|| r["vocabolario"].ToString() == "S") {
						if (f.IsKey) { f.SortList = f.SortList == 0 ? 1 : f.SortList; f.Sort = f.Sort == 0 ? 1 : f.Sort; f.Title = String.IsNullOrEmpty(f.Title) ? "Codice" : f.Title; }
						if (f.Title == "Title") {
							f.Title = "Titolo";
							f.SortList = f.SortList == 0 ? 2 : f.SortList;
							f.Sort = f.Sort == 0 ? 2 : f.Sort;
							if (f.Table.Contains("kind")) f.Title = "Tipologia";
							if (f.Table.Contains("status") || f.Table.Contains("stato")) f.Title = "Stato";
						}
						if (f.Name == "description") { f.SortList = f.SortList == 0 ? 3 : f.SortList; f.Sort = f.Sort == 0 ? 3 : f.Sort; f.Title = "Descrizione"; }

						//item[45] listposition
						//item[1] tablename
						//item[7] fieldname
						if (f.Name == "sortcode" && (!colonne.Rows.Cast<DataRow>().ToList().Any(item => !string.IsNullOrEmpty(item[45].ToString()) && item[7].ToString() != "sortcode" && item[1].ToString() == f.Table))) { f.SortList = f.SortList == 0 ? 4 : f.SortList; f.Sort = f.Sort == 0 ? 4 : f.Sort; f.SortData = "desc"; f.Title = "Ordinamento"; }
						if (f.Name == "active") { f.SortList = f.SortList == 0 ? 5 : f.SortList; f.Sort = f.Sort == 0 ? 5 : f.Sort; f.Title = "Attivo"; }
					}

					if (!allfields.Any(af => af.Table == f.Table && af.EditListingType == f.EditListingType && af.Name == f.Name))
						allfields.Add(f);
				}

			}
		}

		/// <summary>
		/// Restituisce una lista di fields che contengono solamente i dati relativi alla tabella senza quelli delle interfacce che vi si riferiscono
		/// Serve a deduplicare i fileds quando sono presenti un piÃƒÂ¹ interfacce
		/// </summary>
		/// <param name="tablename"></param>
		/// <param name="allfields"></param>
		/// <returns></returns>
		private static List<field> GetDatasetFields(string tablename, List<field> allfields) {

			var output = new List<field>();

			//tolgo l'alias
			if (tablename.Contains("_alias"))
				tablename = tablename.Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[0];

			foreach (var f in allfields.Where(fi => fi.Table == tablename).OrderBy(fi => fi.EditListingType)) {
				if (!output.Any(fi =>
					f.Table == fi.Table &&
					f.Name == fi.Name)) {
					output.Add(new field
					{
						Schema = f.Schema,
						Table = f.Table,
						Name = f.Name,
						IsKey = f.IsKey,
						Type = f.Type,
						Len = f.Len,
						Allownull = f.Allownull,
						IsLinkingObj = f.IsLinkingObj,
						Textfield = f.Textfield,
						Listtype = f.Listtype,
						Radiovalues = f.Radiovalues,
						Title = f.Title,
						SortList = f.SortList,
						TableTitle = f.TableTitle
					});
				}
				else {
					if (f.Textfield != 0) {
						var precField = output.Where(fi => f.Table == fi.Table && f.Name == fi.Name).First();
						if (precField.Textfield == 0)
							precField.Textfield = f.Textfield;
					}
					if (!f.IsKey) {
						var precField = output.Where(fi => f.Table == fi.Table && f.Name == fi.Name).First();
						if (precField.IsKey)
							precField.IsKey = false;

					}
				}
			}

			if (IsView(tablename) && !output.Any(o => o.IsKey))
				foreach (var k in output.Where(af => IsPrincipalKey(af, tablename.Replace("defaultview", ""), true)))
					k.IsKey = true;

			return output;
		}

		/// <summary>
		/// Restituisce i campi corrispondenti di una tabella con un certo editlisttype
		/// </summary>
		/// <param name="tablename">tabella</param>
		/// <param name="editlisttype">editlisttype</param>
		/// <param name="allfields">tutti i campi</param>
		/// <returns>i campi corrispondenti a tablename e editlisttype</returns>
		private static List<field> GetFields(string tablename, string editlisttype, ref List<field> allfields, SqlConnection connection = null) {

			if (string.IsNullOrEmpty(editlisttype))
				editlisttype = "default";

			if (connection != null)
				GetMissingFields(tablename, null, ref allfields, connection);

			tablename = RemoveAlias(tablename);

			var res = allfields.Where(fi => fi.Table == tablename && fi.EditListingType == editlisttype).ToList();
			if (!res.Any() && tablename.EndsWith("view"))
				res = allfields.Where(fi => fi.Table == tablename && fi.EditListingType == "default").ToList();
			return res;
		}

		/// <summary>
		/// aggiunge la tabella figlia ad un field foreignkey, con l'eventuale alias.
		/// </summary>
		/// <param name="fields">campi della pagina attuale</param>
		/// <param name="fi">campo foreignkey che si sta valutando</param>
		/// <param name="metadatoChild">tabella a cui porta la foreignkey</param>
		private static void SetMetadatoChild(List<field> fields, field fi, string metadatoChild, ref List<field> allfields, SqlConnection connection) {
			//potrebbe accadere di ripassare sugli stessi field, ad esempio nei casi di campi affogati nella maschera, 
			//in quei casi occorre mantenere le tabelle con gli alias calcolati in precedenza
			//a meno che non c'ÃƒÂ¨ un altro campo che ha generato autochoose sulla stessa tabella
			if (string.IsNullOrWhiteSpace(fi.MetadatoChild)) {
				//verifico prima che no sia stato forzato un alias per la tabella/listtype che punta
				var firstMetadatoChildField = allfields.Where(af => af.Table == metadatoChild && af.EditListingType == fi.Listtype).FirstOrDefault();
				if (firstMetadatoChildField != null && firstMetadatoChildField.ForceAlias > 0)
					fi.MetadatoChild = metadatoChild + "_alias" + firstMetadatoChildField.ForceAlias.ToString();
				else {
					//verifico se non ci sono stati altri campi nella stessa pagina che puntano alla stessa tabella
					var otherForeignKeyInTable = fields.Where(f => !string.IsNullOrWhiteSpace(f.MetadatoChild)).Count(f =>
													(
													f.MetadatoChild == metadatoChild || //stesso meta figlio 
													f.MetadatoChild.StartsWith(metadatoChild + "_alias") || //o suo alias
													f.MetadatoExtendedChild == metadatoChild || //stesso meta figlio 
													(f.MetadatoExtendedChild ?? "").StartsWith(metadatoChild + "_alias") //o suo alias
													)
												//&& (f.Table != fi.Table || f.Name != fi.Name) //altro campo
												);
					//verifico che la foreign key non punti a tabelle dei campi stessi
					var otherFieldsInDataset = fields.Any(f =>
												  f.Table == metadatoChild && //padre = meta figlio
												  (f.Table != fi.Table || f.Name != fi.Name) //altro campo
												);
					var totalAliases = otherForeignKeyInTable + (otherFieldsInDataset ? 1 : 0);
					if (totalAliases > 0) {
						//devo inserire i riferimenti successivi al primo con degli alias, sia nel dataset che nell'html, indicando poi nel js quale ÃƒÂ¨ la vera tabella da interrogare nelle query
						fi.MetadatoChild = metadatoChild + "_alias" + totalAliases.ToString();
					}
					else
						fi.MetadatoChild = metadatoChild;
				}

				if (IsExtendingObject(metadatoChild, ref allfields, connection)) {
					var extended = metadatoChild.Split('_')[0];
					var extendedListType = GetEditListingTypeForExtended(metadatoChild, fi.EditListingType);
					var firstExtendedField = allfields.Where(af => af.Table == extended && af.EditListingType == extendedListType).FirstOrDefault();
					if (firstExtendedField != null && firstExtendedField.ForceAlias > 0)
						fi.MetadatoExtendedChild = extended + "_alias" + firstExtendedField.ForceAlias.ToString();
					else {
						//verifico se non ci sono stati altri campi nella stessa pagina che puntano alla stessa tabella
						var otherForeignKeyInTable = fields.Where(f => !string.IsNullOrWhiteSpace(f.MetadatoChild)).Count(f =>
												 (
												 f.MetadatoChild == extended || //stesso meta figlio 
												 f.MetadatoChild.StartsWith(extended + "_alias") || //o suo alias
												 f.MetadatoExtendedChild == extended || //stesso meta figlio 
												 (f.MetadatoExtendedChild ?? "").StartsWith(extended + "_alias") //o suo alias
												 )
											 //&& (f.Table != fi.Table || f.Name != fi.Name) //altro campo
											 );
						//verifico che la foreign key non punti a tabelle dei campi stessi
						var otherFieldsInDataset = fields.Any(f =>
													f.Table == extended && //padre = meta figlio
													(f.Table != fi.Table || f.Name != fi.Name) //altro campo
												);
						var totalAliases = otherForeignKeyInTable + (otherFieldsInDataset ? 1 : 0);
						if (totalAliases > 0) {
							//devo inserire i riferimenti successivi al primo con degli alias, sia nel dataset che nell'html, indicando poi nel js quale ÃƒÂ¨ la vera tabella da interrogare nelle query
							fi.MetadatoExtendedChild = extended + "_alias" + totalAliases.ToString();
						}
						else
							fi.MetadatoExtendedChild = extended;
					}
				}

			}
		}

		/// <summary>
		/// Metodo che restituisce l'id di pagina dalla tabella o edit type anche se gli viene passata la vista corrispondente
		/// </summary>
		/// <param name="tableOrView"></param>
		/// <param name="editListingTypes"></param>
		/// <param name="allfields"></param>
		/// <param name="connection"></param>
		/// <returns></returns>
		private static string GetPageIdByTableOrViewEditype(string tableOrView, string editListingTypes, List<field> allfields, SqlConnection connection) {
			//ricavo il pageid per decidere se ÃƒÂ¨ un elemento in modifica oppure no
			var pageId = (GetfiledsByTableEditType(tableOrView, editListingTypes, allfields, connection, true).FirstOrDefault() ?? new field { PageId = "0" }).PageId;
			if (string.IsNullOrEmpty(pageId)) {
				//ÃƒÂ¨ una vista
				var t = GetOriginalTableByView(tableOrView, editListingTypes, allfields);
				pageId = (GetfiledsByTableEditType(t, editListingTypes, allfields, connection, true).FirstOrDefault() ?? new field { PageId = "0" }).PageId;
				if (string.IsNullOrEmpty(pageId))
					ConsoleWriter.ErrorDB("Non trovo l'id di pagina per " + tableOrView + " " + editListingTypes);
			}
			return pageId;
		}

		/// <summary>
		/// Metodo che ricava gli id delle subpage
		/// </summary>
		/// <param name="pageId"></param>
		/// <param name="connection"></param>
		/// <returns></returns>
		private static List<string> GetChildPagesId(string pageId, SqlConnection connection) {
			List<string> lista = new List<string>();

			foreach (DataRow relation in GetChildEntities(pageId, connection).Rows) {
				lista.Add(relation["idapppages"].ToString());
			}
			return lista;
		}

		/// <summary>
		/// Metodo che esegue la query per reperire le subpage
		/// </summary>
		/// <param name="pageId"></param>
		/// <param name="connection"></param>
		/// <returns></returns>
		private static DataTable GetChildEntities(string pageId, SqlConnection connection) {
			var queryRelations = @"select pt.tablename as parenttable, 
									ct.tablename as childtable, 
									CASE	WHEN r.idapptab is null 
											THEN CASE	WHEN r.[description] IS NULL OR LTRIM(RTRIM(r.[description])) = '' 
														THEN CASE	WHEN r.type = 'unique' 
																	THEN 'Principale' 
																	ELSE ct.title END
														ELSE r.[description] END
											ELSE t.title END AS [description],
									--ribatto il nome nel text che in caso di tabella affogata nella pagina gli farÃƒÂ  da label
									isnull(r.[description],ct.title) as text,
									--se non specificato nella relazione uso l'edit type della pagina FIGLIA
									ct.editlistingtype, 
									ct.icon, ct.header, 
									CASE WHEN ct.istree = 'S' THEN 'tree' ELSE r.type END AS type, r.idapppages, 
									r.calendartitle, r.calendarstart, r.calendarstop, ct.calendarmaincolor, 
									r.numrowsmandatory,r.savebeforetest, r.buttoninsert, r.buttonedit ,r.buttondelete, r.position,
									CASE WHEN r.idapptab is null and r.position is not null THEN r.position ELSE null END AS tabposition,
									r.idappfielddetail_parent, r.showinparentgridpos
									,CASE WHEN EXISTS(select * from sysobjects where id = object_id(ct.tablename) and OBJECTPROPERTY(id, N'IsView') = 1) THEN 'S' ELSE 'N' END AS isview
									from apprelation r
									left outer join apppages pt on pt.idapppages = r.idapppages_parent
									left outer join apppages ct on ct.idapppages = r.idapppages
									left outer join apptab t on r.idapptab = t.idapptab
									where pt.idapppages = " + pageId;
			var cmdRelations = new SqlCommand(queryRelations, connection);
			var dataReaderRelations = cmdRelations.ExecuteReader();
			var relations = new DataTable();
			relations.Load(dataReaderRelations);

			return relations;
		}

		/// <summary>
		/// Aggiunge ai fields un field di riferimento per ogni pagina figlia
		/// </summary>
		/// <param name="pageId">pagina corrente</param>
		/// <param name="extendedObject">eventuale oggetto esteso da quello attuale</param>
		/// <param name="allfields">tutti i campi utilizzati</param>
		/// <param name="connection">connessione</param>
		/// <returns>i campi che descrivono la relazione con l'interfaccia figlia</returns>
		private static List<field> GetChildentitiesFields(string pageId, string extendedObject, List<field> allfields, SqlConnection connection) {
			List<field> fields = new List<field>();

			var relations = GetChildEntities(pageId, connection);
			var currentObjectKey = allfields.Where(k => k.IsKey && k.PageId == pageId).OrderBy(x => x.Name);
			if (currentObjectKey.Any()) {
				var currentObjectTable = currentObjectKey.First().Table;

				foreach (DataRow relation in relations.Rows) {
					var tablename = relation["childtable"].ToString().Trim();

					//scarico dal db i campi
					GetMissingFields(tablename, null, ref allfields, connection);

					//verifico che sia una vera entitÃƒÂ  figlia (deve avere un riferimento alla chiave dell'oggetto corrente)
					if (allfields.Any(af => af.Table == tablename && currentObjectKey.Any(k => k.Name == af.Name.Split('_')[0]))) {

						var tabtitle = string.IsNullOrEmpty(relation["description"].ToString()) ? tablename : relation["description"].ToString();
						var title = tabtitle;
						if (relation["type"].ToString() == "button")
							tabtitle = "Principale";
						var editListingType = string.IsNullOrEmpty(relation["editlistingtype"].ToString()) ?
						"default" : //se ÃƒÂ¨ vuoto vuol dire che nella relazione non ÃƒÂ¨ stato indicato e la tabella figlia ha il list type vuoto , quindi default
						relation["editlistingtype"].ToString();

						if (!allfields.Any(af => af.Table == tablename && af.EditListingType == editListingType))
							ConsoleWriter.ErrorDB("E' stata inserita una relazione con " + tablename + " con edit type " + editListingType + " ma questa combinazione non esiste." +
								"Controllare se ÃƒÂ¨ stato forzato un list type inesistente nella relazione.");

						var numrowsmandatory = string.IsNullOrEmpty(relation["numrowsmandatory"].ToString()) ? 0 : int.Parse(relation["numrowsmandatory"].ToString().Trim());

						var fi = new field
						{
							Tab = tabtitle,
							Icon = relation["icon"].ToString(),
							RelationType = relation["type"].ToString() ?? "",
							Tabposition = string.IsNullOrWhiteSpace(relation["tabposition"].ToString()) ? fields.Count + 1 : int.Parse(relation["tabposition"].ToString()),
							Title = title,
							Name = "XX" + tablename, //concateno XX al nome della tabella figlia
							Table = !string.IsNullOrEmpty(extendedObject) ? extendedObject : currentObjectTable, //se si tratta di un oggetto estendente riassocio le relazioni sempre all'oggetto esteso
							Detailvisible = true,
							EditListingType = editListingType,
							Listtype = editListingType,
							ListVisible = false, //faccio in modo che non vada nel describe columns
							Defaultvalue = null, //faccio in modo che non vada nel set default
							Allownull = (numrowsmandatory == 0), //finisce nella is valid se servono delle righe 
							Len = 0, //faccio in modo che non finisca nel is valid 
							PageId = relation["idapppages"].ToString(), //il page id del figlio
							PageIdParent = pageId,
							CalendarSettings = relation["calendartitle"].ToString() + ";" + relation["calendarstart"].ToString() + ";" + relation["calendarstop"].ToString() + ";" + relation["calendarmaincolor"].ToString(),
							Numrowsmandatory = numrowsmandatory,
							Savebeforetest = relation["savebeforetest"].ToString() == "S", //di default ÃƒÂ¨ no
							Tabheader = relation["header"].ToString(), //l'header del figlio va a riempire l'intestazione del tab
							UniqueOnRow = true,
							Text = relation["text"].ToString(),
							Buttoninsert = relation["buttoninsert"].ToString() != "N", //default ÃƒÂ¨ Si 
							Buttonedit = relation["buttonedit"].ToString() != "N", //default ÃƒÂ¨ Si 
							Buttondelete = relation["buttondelete"].ToString() != "N", //default ÃƒÂ¨ Si 
							Sort = string.IsNullOrWhiteSpace(relation["position"].ToString()) ? 100 : int.Parse(relation["position"].ToString()), //se non c'ÃƒÂ¨ ed ÃƒÂ¨ affogata la mette in fondo
							MasterField = string.IsNullOrEmpty(relation["idappfielddetail_parent"].ToString()) ? (int?)null : int.Parse(relation["idappfielddetail_parent"].ToString()),
							ShowInParentGrid = string.IsNullOrWhiteSpace(relation["showinparentgridpos"].ToString()) ? 0 : int.Parse(relation["showinparentgridpos"].ToString()),
							IsView = relation["isview"].ToString() != "N",
						};

						//se l'entitÃƒÂ  figlia ÃƒÂ  un oggetto esteso CASO PARTICOLARE DI ESTENDENTE RICORSIVO SU ESTENDENTE, SE FAI ESTENDENTE RICORSIVO SU ESTESO NON SERVE
						if (IsExtendingObject(tablename, ref allfields, connection)) {
							//ricavo l'estendente
							var extendedobjectChild = tablename.Split('_')[0];

							//se l'entitÃƒÂ  figlia ÃƒÂ¨ estesa e il suo esteso ÃƒÂ¨ ugauale all'esteso dell'oggetto corrente (estendente e ricorsivo)
							if (extendedobjectChild == extendedObject) {
								//... allora imposto la relazione sulla gerarchia ricorsiva id<->parid
								var parid = allfields.Where(af => af.Table == extendedObject && af.Name == "parid" + extendedObject).FirstOrDefault();
								if (parid != null)
									fi.LookupFor = parid.Name;
							}
						}

						//ENTITA' Ricorsiva
						if (fi.LookupFor == null) {
							if (tablename == relation["parenttable"].ToString()) {
								var parid = allfields.Where(af => af.Table == tablename && af.Name.StartsWith("parid") && af.IsKey).FirstOrDefault();
								if (parid != null)
									fi.LookupFor = parid.Name;
							}
						}

						//SUB-ENTITA' Standard
						if (fi.LookupFor == null) {
							//verifico che non si tratti di una subentitÃƒÂ  ovvero tutta la chiave del padre ÃƒÂ¨ contenuta nel figlio
							var childkey = allfields.Where(af => af.Table == tablename && af.EditListingType == editListingType && af.IsKey).Select(ck => ck.Name);

							//TODO le entitÃƒÂ  figlie devono avere lo stesso nome della chiave?
							//nel caso di subentitÃƒÂ  si parla di chiavi primarie e non di foreign key e in questo caso non esistono suffissi (si usano solo per le foreignkey)
							//a eccezione degli oggetti estesi
							//anzi nel caso ci fossero vuol dire che ÃƒÂ¨ una tabella di collegamento verso la stessa entitÃƒÂ  collegata, e quindi bisogna prendere solo le chiavi primarie (senza suffissi) e non le foreign key (con suffissi)

							if (currentObjectKey.All(cok => childkey.Any(ck => ck == cok.Name ||
																	(cok.Name.IndexOf('_') != -1 && ck == cok.Name.Split('_')[0] && GetException(null, cok.Name, null, null) != null))))
								fi.LookupFor = string.Join(" ", childkey.Where(ck => currentObjectKey.Any(cok => ck == cok.Name ||
																	(cok.Name.IndexOf('_') != -1 && ck == cok.Name.Split('_')[0] && GetException(null, cok.Name, null, null) != null))).ToList());
						}

						if (fi.LookupFor == null) {
							//tutti i campi sulla tabella figlia che sono FK per una PK della madre e non sono visibili 
							//nelle tebelle di collegamento e simili che si riferiscono piÃƒÂ¹ di una volta alla stessa tabella la relazione con la madre non ÃƒÂ¨ visibile
							fi.LookupFor = string.Join(" ", allfields.Where(af => af.Table == tablename && af.EditListingType == editListingType && !af.Detailvisible &&
										currentObjectKey.Any(cok => cok.Name == GetIdByForeignKey(af))).OrderBy(x => x.Name /*IsKey*/).Select(x => x.Name).ToList());

							if (string.IsNullOrEmpty(fi.LookupFor)) {
								//paracadute nel caso mi sia scordato visibile la fk
								fi.LookupFor = string.Join(" ", allfields.Where(af => af.Table == tablename && af.EditListingType == editListingType &&
											currentObjectKey.Any(cok => cok.Name == GetIdByForeignKey(af))).OrderBy(x => x.IsKey).Select(x => x.Name).ToList());
								if (verbose)
									ConsoleWriter.WarningDB("Per l'interfaccia " + tablename + " " + editListingType + " ÃƒÂ¨ visibile i campo di collegamento con l'interfaccia madre " + fi.LookupFor + " solitamente non necessario");
							}

						}

						fields.Add(fi);
					}
					else {
						ConsoleWriter.ErrorDB("E' stata inserita una relazione tra una pagina figlia " + tablename + " e la pagina padre " + relation["parenttable"].ToString() +
							" ma " + tablename + " non ÃƒÂ¨ un vero figlio di " + relation["parenttable"].ToString() +
							" e quindi non verrebbe comunque salvato e quindi non ÃƒÂ¨ stato preso in considerazione.");
					}
				}
			}
			else {
				Console.WriteLine("ERROR: non sono stati caricati i campi della pagina con id " + pageId);
			}
			return fields;
		}

		/// <summary>
		/// Metodo che restituisce gli id delle pagine parent
		/// </summary>
		/// <param name="pageId"></param>
		/// <param name="connection"></param>
		/// <returns></returns>
		private static List<string> GetParentPagesId(string pageId, SqlConnection connection) {

			List<string> lista = new List<string>();

			foreach (DataRow relation in GetParentPages(pageId, connection).Rows) {
				lista.Add(relation["idapppages_parent"].ToString());
			}
			return lista;
		}

		/// <summary>
		/// Metodo che esegue la query per ottenere le pagine parent
		/// </summary>
		/// <param name="pageId"></param>
		/// <param name="connection"></param>
		/// <returns></returns>
		private static DataTable GetParentPages(string pageId, SqlConnection connection) {

			var queryRelations = @"select pt.tablename as parenttable, 
									ct.tablename as childtable, 
									CASE	WHEN r.idapptab is null 
											THEN CASE	WHEN r.[description] IS NULL OR LTRIM(RTRIM(r.[description])) = '' 
														THEN CASE	WHEN r.type = 'unique' 
																	THEN 'Principale' 
																	ELSE ct.title END
														ELSE r.[description] END
											ELSE t.title END AS [description],
									--ribatto il nome nel text che in caso di tabella affogata nella pagina gli farÃƒÂ  da label
									isnull(r.[description],ct.title) as text,
									--se non specificato nella relazione uso l'edit type della pagina FIGLIA
									ct.editlistingtype, 
									ct.icon, r.type, r.idapppages, 
									r.calendartitle, r.calendarstart, r.calendarstop, ct.calendarmaincolor, 
									r.numrowsmandatory, r.savebeforetest, ct.header,r.idapppages_parent,pt.principale 
									from apprelation r
									left outer join apppages pt on pt.idapppages = r.idapppages_parent
									left outer join apppages ct on ct.idapppages = r.idapppages
									left outer join apptab t on r.idapptab = t.idapptab
									where ct.idapppages = '" + pageId + "' ";
			var cmdRelations = new SqlCommand(queryRelations, connection);
			var dataReaderRelations = cmdRelations.ExecuteReader();
			var relations = new DataTable();
			relations.Load(dataReaderRelations);

			return relations;

		}

		/// <summary>
		/// Aggiunge ai fields un field di riferimento per ogni pagina madre
		/// </summary>
		/// <param name="pageId">pagina corrente</param>
		/// <param name="extendedObject">eventuale oggetto esteso da quello attuale</param>
		/// <param name="allfields">tutti i campi utilizzati</param>
		/// <param name="connection">connessione</param>
		/// <returns>i campi che descrivono la relazione con l'interfaccia madre</returns>
		private static List<field> GetParentEntitiesFields(string pageId, string extendedObject, List<field> allfields, SqlConnection connection, bool onlyPage = false) {
			List<field> fields = new List<field>();


			var relations = GetParentPages(pageId, connection);


			var currentObjectfields = allfields.Where(k => k.PageId == pageId).OrderBy(x => x.Name);
			var currentObjectKey = currentObjectfields.Where(k => k.IsKey).OrderBy(x => x.Name);

			var currentObjectTable = currentObjectfields.First().Table;

			foreach (DataRow relation in relations.Rows) {
				var tablename = relation["parenttable"].ToString();

				//scarico dal db i campi
				GetMissingFields(tablename, null, ref allfields, connection);

				//verifico che sia una vera entitÃƒÂ  figlia (deve avere un riferimento alla chiave dell'oggetto corrente)
				if (allfields.Any(af => af.Table == tablename && currentObjectKey.Any(k => k.Name == af.Name.Split('_')[0]))) {

					var tabtitle = string.IsNullOrEmpty(relation["description"].ToString()) ? tablename : relation["description"].ToString();
					var editListingType = string.IsNullOrEmpty(relation["editlistingtype"].ToString()) ?
						"default" : //se ÃƒÂ¨ vuoto vuol dire che nella relazione non ÃƒÂ¨ stato indicato e la tabella figlia ha il list type vuoto , quindi default
						relation["editlistingtype"].ToString();

					var numrowsmandatory = string.IsNullOrEmpty(relation["numrowsmandatory"].ToString()) ? 0 : int.Parse(relation["numrowsmandatory"].ToString().Trim());

					var fi = new field
					{
						Tab = tabtitle,
						Icon = relation["icon"].ToString(),
						RelationType = relation["type"].ToString() ?? "",
						Tabposition = fields.Count + 1,
						Title = tabtitle,
						Name = "XX" + tablename, //concateno XX al nome della tabella figlia
						Table = !string.IsNullOrEmpty(extendedObject) ? extendedObject : currentObjectTable, //se si tratta di un oggetto estendente riassocio le relazioni sempre all'oggetto esteso
						Detailvisible = true,
						EditListingType = editListingType,
						ListVisible = false, //faccio in modo che non vada nel describe columns
						Defaultvalue = null, //faccio in modo che non vada nel set default
						Allownull = (numrowsmandatory == 0), //finisce nella is valid se servono delle righe 
						Len = 0, //faccio in modo che non finisca nel is valid 
						PageId = relation["idapppages"].ToString(), //il page id del figlio
						PageIdParent = pageId,
						CalendarSettings = relation["calendartitle"].ToString() + ";" + relation["calendarstart"].ToString() + ";" + relation["calendarstop"].ToString() + ";" + relation["calendarmaincolor"].ToString(),
						Numrowsmandatory = numrowsmandatory,
						Savebeforetest = relation["savebeforetest"].ToString() == "S", //di default ÃƒÂ¨ no
						Tabheader = relation["header"].ToString(), //l'header del figlio va a riempire l'intestazione del tab
						UniqueOnRow = true,
						Text = relation["text"].ToString(),
					};

					fields.Add(fi);
				}
			}

			return fields;
		}

		/// <summary>
		/// Restituisce un clone del field passato ma con le modifiche passate nei parametri
		/// </summary>
		/// <param name="f">field da clonare</param>
		/// <param name="sortList">ordine in lista</param>
		/// <param name="listVisible">visibile in lista</param>
		/// <param name="alias">alias del field nella vista</param>
		/// <param name="table">tabella</param>
		/// <returns>field clonato</returns>
		public static field RenewField(field f, field fid, int sortList, bool detailVisible, bool listVisible, string alias = null, string title = null) {
			return new field
			{
				Name = f.Name,
				Title = (string.IsNullOrEmpty(title) ? f.Title : title), //gli passo il title definito per la foreign key sul padre (es: idclassconsorsuale su docenti diventa "Classe Consorsuale")
				Sort = f.Sort,
				SortList = sortList,
				Type = f.Type,
				Len = f.Len,
				Tab = f.Tab,
				Tabposition = f.Tabposition,
				Table = fid.Table,
				LookupTable = f.Table,
				IsKey = f.IsKey,
				Detailvisible = detailVisible,
				ListVisible = listVisible,
				Allownull = f.Allownull,
				SortData = fid.SortData,
				ViewAlias = alias,
				LookupFor = f.Name != fid.Name ? fid.Name : null,
				EditListingType = fid.EditListingType
			};
		}

		/// <summary>
		/// Setta il controllo come readonly sulla metapage javascript 
		/// </summary>
		/// <param name="fi">campo</param>
		/// <param name="nametag">nome del campo</param>
		/// <param name="fullPathMetaPageJS">path del file della metapage js</param>
		/// <param name="o">oggetto</param>
		/// <param name="editListingTypes">edit/listing type</param>
		public static void SetReadonly(field fi, string nametag, string fullPathMetaPageJS, obj o, string editListingTypes, bool setReadonly = true) {
			if (fi.Readonlyfield) {
				SetAfterFill(fullPathMetaPageJS, "this.enableControl($('#" + nametag + "'), " + (!setReadonly).ToString().ToLower() + ");\r\n"/*, o.Table + "_" + editListingTypes*/);
			}
		}

		/// <summary>
		/// Calcola se il campo genererÃƒÂ  una dropdown
		/// </summary>
		/// <param name="fi">campo (foreign key)</param>
		/// <param name="table">tabella puntata dal campo</param>
		/// <returns>true/false</returns>
		public static bool IsDropdown(field fi, string table = null) {
			var original = "";
			if (string.IsNullOrWhiteSpace(table)) {
				original = GetOriginalTableByForeignKey(fi);
			}
			else {
				original = table.Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[0];
				original = original.Replace((string.IsNullOrWhiteSpace(fi.Listtype) ? "default" : fi.Listtype) + "view", "");
			}
			return original.EndsWith("kind") || original.EndsWith("status") || original.EndsWith("stato") || fi.Name.StartsWith("aa") || fi.ForceDropDown;
		}

		/// <summary>
		/// Indica se ÃƒÂ¨ abilitato o disabilitato in base al valore selezionato di un altro campo della stessa interfaccia
		/// </summary>
		/// <param name="fi"></param>
		/// <param name="allfields"></param>
		/// <param name="connection"></param>
		/// <returns></returns>
		public static List<field> IsDisabledByOtherFild(field fi, ref List<field> allfields, SqlConnection connection) {
			if (!string.IsNullOrWhiteSpace(fi.Master)) {
				if (!allfields.Any(af => af.Table == fi.Master))
					GetMissingFields(fi.Master, null, ref allfields, connection);
				//cerca nella tabella master un booleano con lo stesso nome del campo da abilitare/disabilitare
				return allfields.Where(af => af.Table == fi.Master && (
					(af.Name == fi.Name && af.Type == "char" && af.Len == 1) //S o N su tabella
					||
					(af.Name.EndsWith("_" + fi.Name)) && af.Type == "varchar" && af.Len == 2) //Si o No su vista
					).ToList();
			}
			return new List<field>();
		}

		/// <summary>
		/// Indica se il dropdown o dropdowngrid ÃƒÂ¨ a cascata rispetto ad un altro
		/// </summary>
		/// <param name="fi"></param>
		/// <param name="allfields"></param>
		/// <param name="connection"></param>
		/// <returns></returns>
		public static bool IsAddictedDropdown(field fi, ref List<field> allfields, SqlConnection connection) {
			if (!string.IsNullOrWhiteSpace(fi.Master)) {
				return !IsDisabledByOtherFild(fi, ref allfields, connection).Any();
			}
			return false;
		}

		public static string GetOriginalTableByForeignKey(field fi) {
			var original = (fi.MetadatoChild ?? fi.Name.Substring(2)).Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[0];
			return original.Replace((string.IsNullOrWhiteSpace(fi.Listtype) ? "default" : fi.Listtype) + "view", "");
		}

		public static string GetOriginalTableOrViewByForeignKey(field fi) {
			return (fi.MetadatoChild ?? fi.Name.Substring(2)).Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[0];
		}

		public static string GetOriginalExtendedTableByForeignKey(field fi) {
			if (!string.IsNullOrWhiteSpace(fi.MetadatoExtendedChild)) {
				var original = fi.MetadatoExtendedChild.Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[0];
				return original.Replace((string.IsNullOrWhiteSpace(fi.Listtype) ? "default" : fi.Listtype) + "view", "");
			}
			return null;
		}


		/// <summary>
		/// Indica se per quella tabella e listtype esiste una vista
		/// </summary>
		/// <param name="table"></param>
		/// <param name="listtype"></param>
		/// <param name="allfields"></param>
		/// <param name="connection"></param>
		/// <returns></returns>
		public static bool HaveView(string table, string listtype, ref List<field> allfields, SqlConnection connection) {
			GetMissingFields(table, null, ref allfields, connection);
			return allfields.Any(af => af.Table == RemoveAlias(table) && af.EditListingType == listtype && af.HaveView);
		}

		/// <summary>
		/// indica se il nome della tabella passta ÃƒÂ¨ di una vista seguendo la convenzione che se contiene view lo ÃƒÂ¨
		/// </summary>
		/// <param name="table"></param>
		/// <returns></returns>
		public static bool IsView(string table) {
			//if (table.EndsWith("view")) return true;
			if (table.Contains("view")) return true;
			return false;
		}

		/// <summary>
		/// Indica se il corrispondente oggetto ha la colonna "active"
		/// </summary>
		/// <param name="table"></param>
		/// <param name="listtype"></param>
		/// <param name="allfields"></param>
		/// <param name="connection"></param>
		/// <returns></returns>
		public static bool HaveActiveField(string table, string listtype, ref List<field> allfields, SqlConnection connection) {
			GetMissingFields(table, null, ref allfields, connection);
			return allfields.Any(af => af.Table == table && af.EditListingType == listtype && af.Name == "active");
		}


		/// <summary>
		/// restitusce una stringa contenete la chiamata al metodo DescribeAColumn correttamente valorizzata ed eventualmente anche formattata
		/// </summary>
		/// <param name="fi">campo</param>
		/// <param name="colName">nome della colonna della tabella sul dataset (che potrebbe essere calcolato)</param>
		/// <returns></returns>
		public static string GetFormatDescribeColumn(field fi, string colName) {
			var output = "\t\t\t\t\t\tDescribeAColumn(T, \"" + colName + "\", \"" + fi.Title + "\", nPos++);\r\n";
			if (fi.Type == "datetime" || fi.Type == "decimal" || fi.Type == "float")
				output += "\t\t\t\t\t\tif (T.Columns.Contains(\"" + colName + "\")) T.Columns[\"" + colName + "\"].ExtendedProperties[\"format\"] = \"" + GetFormat(fi) + "\";\r\n";
			return output;
		}

		/// <summary>
		/// Restituisce il formato da utilizzare per il campopassato come parametro
		/// </summary>
		/// <param name="fi"></param>
		/// <returns></returns>
		public static string GetFormat(field fi) {
			var output = "";
			if (fi.Type == "datetime")
				output = "g";
			if (fi.Type == "decimal" || fi.Type == "float")
				output = fi.Name == "latitude" || fi.Name == "longitude" ?
						 "fixed.7" :
						 (fi.Len > 0 ?
							"fixed." + fi.Len.ToString() :
							"fixed.2");

			return output;
		}

		/// <summary>
		/// Restituisce l'edit listing type di un oggetto esteso in base all'oggetto che lo estende e l'edit listing type dell'oggetto che lo estende
		/// </summary>
		/// <param name="extended_extendingObject"></param>
		/// <param name="extendingEditListingType"></param>
		/// <returns></returns>
		public static string GetEditListingTypeForExtended(string extended_extendingObject, string extendingEditListingType) {
			if (!extended_extendingObject.Contains('_'))
				return "";
			return extended_extendingObject.Split('_')[1] + (extendingEditListingType == "default" || string.IsNullOrWhiteSpace(extendingEditListingType) ?
												"" : "_" + extendingEditListingType);
		}

		public static bool belongsToOtherTable(string tableToTest, field f) {
			return tableToTest.Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[0] != f.Table;
		}

		/// <summary>
		/// Restituisce il nome della tabella collegata dalla foreign key della tabella di collegamento calconandone anche l'alias
		/// </summary>
		/// <param name="linkid"></param>
		/// <param name="fields"></param>
		/// <param name="allfields"></param>
		/// <param name="connection"></param>
		/// <returns></returns>
		public static string GetLinkedTable(field linkid, ref List<field> fields, List<field> subfields, ref List<field> allfields, SqlConnection connection) {
			//tabella collegata con eventuali alias
			var linkedtable = "";
			if (linkid.MetadatoChild != null) {
				linkedtable = linkid.MetadatoChild;
			}
			else {
				var ex = GetException(null, null, linkid.Table, linkid.Name);
				if (ex != null) {
					linkedtable = ex.Item1;
				}
				else {
					linkedtable = GetTableById(linkid.Name, allfields, connection);
				}
				subfields.Add(linkid);
				SetMetadatoChild(fields.Union(subfields).ToList(), linkid, linkedtable, ref allfields, connection);
				linkedtable = linkid.MetadatoChild;
			}
			return linkedtable;
		}

		#endregion

		#region generazione del dataset


		/// Genera tabelle e relazioni nel dataset di pagina
		/// </summary>
		/// <param name="pathMetaPage">percorso del file del dataset</param>
		/// <param name="metadatoParent">oggetto parent</param>
		/// <param name="metadatoChild">oggetto child</param>
		/// <param name="parentKey"></param>
		/// <param name="childkey"></param>
		/// <param name="current">oggetto di pagina</param>
		/// <param name="minimal">solo id e campo stestuale</param>
		/// <param name="fields">i campi del dataset</param>
		/// <param name="allfields">tutti i campi</param>
		/// <param name="editListingType">editListingType</param>
		/// <param name="pageid">id della interfaccia figlia</param>
		/// <param name="connection">connessione</param>
		/// <param name="isLinkingObjKey"></param>
		/// <param name="iteration"></param>
		/// <param name="extendedTableChild"></param>
		/// <param name="masterTable"></param>
		/// <param name="skiplookup">non genera le tabelle collegate per i lookup</param>
		private static void PreparePageDataset(string pathMetaPage, string metadatoParent, string metadatoChild, string parentKey, string childkey, string current, bool minimal,
			List<field> fields, List<field> allfields, string editListingType, string editListingTypeParent, string pageid, SqlConnection connection, bool isLinkingObjKey, int iteration,
			string extendedTableChild, List<string> fullTables, string fullPathMetaPageJS, int? colpos, List<childColumn> childColumns, string masterTable = null, bool skiplookup = false,
			string fkTitle = null) {

			Console.Write(".");

			var isSubentity = (!string.IsNullOrWhiteSpace(pageid));

			if (metadatoParent != metadatoChild) {

				var metadatoParentOriginal = metadatoParent;
				if (metadatoParent.Contains("_alias"))
					//se il parent ÃƒÂ¨ un alias lo uso e calcolo il valore originale
					metadatoParentOriginal = metadatoParent.Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[0];

				var datasetMetadatoParent = "";
				if (metadatoParent != current) {
					datasetMetadatoParent = GetDatasetTable(metadatoParent, null, false, allfields, connection, editListingTypeParent, fullPathMetaPageJS, iteration);
					addTableToDataset(pathMetaPage, metadatoParent, datasetMetadatoParent, false);
				}

				var datasetMetadatoChild = "";
				var parentIsLinkingObject = IsLinkingObject(metadatoParent, ref allfields, connection)
									|| isLinkingObjKey
									|| allfields.Any(af => af.Table == metadatoParent && af.EditListingType == editListingTypeParent && af.IsLinkingObj
										&& childkey.Split(' ').Contains(af.Name.Split('_')[0]));

				var metadatoChildOriginal = metadatoChild;
				if (metadatoChild.Contains("_alias"))
					//se il child ÃƒÂ¨ un alias lo uso e calcolo il valore originale
					metadatoChildOriginal = metadatoChild.Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[0];

				var editListingTypeExtended = GetEditListingTypeForExtended(metadatoChildOriginal, editListingType);

				//aggiungo la tabella figlia e la sua relazione con la tabella principale
				//se perÃƒÂ² ÃƒÂ¨ una figlia di una tabella di collegamento o ÃƒÂ¨ la tabella degli allegati, la figlia va inserita sempre con tutti i campi, 
				//quindi minimal va falsificato (potrebbe arrivare true o giÃƒÂ  false)
				if (parentIsLinkingObject || metadatoChildOriginal == "attach")
					minimal = false;

				var isSubEntityRelation = !minimal && !parentIsLinkingObject && !(metadatoChildOriginal == "attach");

				if (metadatoChild != current) {
					var forceFull = fullTables.Contains(metadatoChild);

					datasetMetadatoChild = GetDatasetTable(metadatoChild, metadatoParent, minimal && !forceFull, allfields, connection, editListingType, fullPathMetaPageJS, iteration,
						isSubEntityRelation ? parentKey : null, masterTable);

					if (!string.IsNullOrEmpty(datasetMetadatoChild)) {

						var relationChildField = fields.Where(item => item.Name == "XX" + metadatoChildOriginal).FirstOrDefault() ?? new field();
						var relationParentField = fields.Where(item => item.Name == "XX" + metadatoParentOriginal).FirstOrDefault() ?? new field();

						if (relationChildField != null)
							//preparo l'autorelazione per l'entitÃƒÂ  ad albero
							if (relationChildField.RelationType == "tree") {
								var fiPrincipalKey = GetPrincipalKey(metadatoChildOriginal, editListingType, fields, connection);
								var fiParentKey = GetParentkey(metadatoChildOriginal, editListingType, fiPrincipalKey.Name, fields);
								var datasetRelation = "     <msdata:Relationship name=\"FK_" + metadatoChildOriginal + "_" + metadatoChildOriginal + "_" + fiPrincipalKey.Name + "\" msdata:parent=\"" +
																metadatoChildOriginal + "\" msdata:child=\"" + metadatoChildOriginal + "\" msdata:parentkey=\"" + fiPrincipalKey.Name + "\" msdata:childkey=\"" + fiParentKey.Name + "\" />\r\n";

								SetRelationInDataset(pathMetaPage, datasetRelation);
							}
						var extendedTableChildOriginal = extendedTableChild;
						if ((extendedTableChild ?? "").Contains("_alias"))
							extendedTableChildOriginal = extendedTableChild.Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[0];

						var islinkingobject = IsLinkingObject(metadatoChildOriginal, ref allfields, connection);

						//Calcolo il metadato JS del metadatoParent (controllando se ÃƒÂ¨ esteso)
						var currentObject = metadatoParent.Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[0];
						var container = currentObject;
						var isExtendingObject = IsExtendingObject(metadatoParent, ref allfields, connection);
						if (isExtendingObject)
							container = GetExtendedObject(metadatoParent, ref allfields, connection, false);
						var fullPathMetaDatoJS = clientFolder + metapageFolder + container + "/meta_" + currentObject + ".js";

						//-----------------aggiungo al dataset l'entitÃƒÂ  figlia (minimal = false) oppure la tabella per i campi di lookup (minimal = true)--------------------------------------------------------------
						addTableToDataset(pathMetaPage, metadatoChild, datasetMetadatoChild, minimal);

						//aggiungo alla tabella parent il campo di lookup della relazione attuale solo per le griglie (per questo iteration = 2),
						//ma nel caso di oggetti estesi la tabella estendente si aggiunge in un secondo momento per due volte, come figlia e come padre, 
						//quindi al momento in cui viene aggiunta la prima volta come figlia, non vanno aggiunti i campi di lookup (skiplookup = true).
						//in ogni caso non elaboro campi di lookup per le tabelle di collegamento che non hanno campi testuali da mostrare
						//e in generale tutte le subentitÃƒÂ  (oggetti figli) non generano campi di lookup sulla entitÃƒÂ  principale (foreign key sull'entitÃƒÂ  principale verso vocabolari), 
						//a meno che non vadano mostrate in colonne nipoti, caso in cui aggiungo SUL DATASET le tabelle ma non i campi calcolati alla iterazione 2 e i campi calcolati nella iterazione 3 --------------------------
						if (!skiplookup && !islinkingobject && (
							(iteration == 2 && (!isSubentity || relationChildField.ShowInParentGrid > 0)) || //lookup che partono da griglie o colonne nipoti
							(iteration == 3 && (!isSubentity && relationParentField.ShowInParentGrid > 0))   //lookup di nipoti
							)) {

							var objCalcFieldConfig = new List<string>();
							var describeColumns = new List<string>();
							if (parentIsLinkingObject) {
								//se il parent ÃƒÂ¨ un oggetto di collegamento allora i campi ci vanno tutti quelli visibili in lista tranne la chiave principale
								var calculatedfields = new List<field>();
								calculatedfields.AddRange(GetLinkingObjectFields(metadatoParent, editListingTypeParent, ref allfields, connection)
									.Where(af => af.ListVisible && !IsPrincipalKey(af, af.Table)));
								//inserisco solo i campi collegati del padre relativi al metadatochild che sto valutando in questo momento
								var descColumnColl = calculatedfields.Where(f => f.Table == metadatoChildOriginal || f.Table == metadatoChildOriginal.Split('_')[0])
															.OrderBy(f => f.Table).ThenBy(f => f.SortList);
								if (descColumnColl.Any()) {
									foreach (var cf in descColumnColl) {
										var lookupTable = metadatoChild;
										var textField = new List<field>();
										var textFieldOfTextField = new List<field>();
										textField.Add(cf);
										var lookuplookupTables = new List<string>();
										//var lookuplookupTitle = "";
										var lookupFieldsCount = 0;
										if (HaveKeyName(cf)) {
											//devo mettere il campo di lookup al suo posto
											var lookupTableTemp = cf.MetadatoChild ?? GetTableById(cf.Name, allfields, connection);
											if (!string.IsNullOrWhiteSpace(lookupTableTemp)) {
												var lookupFields = GetTextFieldByTable(lookupTableTemp, allfields, connection, true);
												// ha trovato il capo testuale o ha una chiave testuale
												var firstlookup = true;
												foreach (var lookupField in lookupFields)
													if (lookupField.Name != cf.Name || IsTextField(lookupField)) {
														if (firstlookup) {
															//calcolando il primo campo stestuale tolgo il field di origine perchÃƒÂ¨ metterÃƒÂ² al suo posto i suoi campi testuali
															textField = new List<field>();
															firstlookup = false;
														}
														var tf = lookupField;
														//qui setto lookuptable e non lookupField.Table perchÃƒÂ¨ se si tratta di un oggetto esteso lookupField.Table potrebbe essere 
														//l'esteso e invece ci voglio mettere l'estendente che sta appunto in lookuptable. 
														//TODO verificare se in questi casi non occorre anche aggiungere il cf ai fields
														SetMetadatoChild(fields, cf, lookupTableTemp, ref allfields, connection);
														//se il campo testuale sta sulla tabella estesa allora la loookup table ÃƒÂ¨ lei altrimenti la sua estendente
														if (!string.IsNullOrWhiteSpace(cf.MetadatoExtendedChild))
															lookupTable = tf.Table == cf.MetadatoExtendedChild.Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[0] ?
																						cf.MetadatoExtendedChild : cf.MetadatoChild;
														else
															lookupTable = cf.MetadatoChild;

														if (!HaveKeyName(tf) || tf.Name == cf.Name)
															//se non ÃƒÂ¨ a sua volta una chiave (oppure lo ÃƒÂ¨ ma volevo mostrare prorio lei)
															//mostro il campo
															textField.Add(tf);
														else {
															//altrimenti il campo testuale ÃƒÂ¨ a sua volta una foreign key verso un altra tabella
															//quindi mostro i campi testuali della tabella/tabelle collegata/collegate
															var lookuplookupTable = tf.MetadatoChild ?? GetTableById(tf.Name, allfields, connection);
															lookupFields = GetTextFieldByTable(lookuplookupTable, allfields, connection, true);
															var addToDataset = false;
															if (lookupFields.Any()) {
																foreach (var lookupField2 in lookupFields)
																	if (lookupField2.Name != tf.Name || IsTextField(lookupField2)) {
																		addToDataset = true;
																		if (cf.Name.StartsWith("parid")) {
																			//TODO quando cf ÃƒÂ¨ una fk verso se stesso tf.metadatochild andrebbe forzato ad avere un alias+1 ma ha giÃƒÂ  l'alias impostato
																			//ne deriva che le tabelle di lookup dell'oggetto padre sono le stesse dell'oggetto figlio quindi poi la scantable le riempirÃƒÂ  solo per uno dei due
																			SetMetadatoChild(fields, tf, lookuplookupTable, ref allfields, connection);
																		}
																		else {
																			SetMetadatoChild(fields, tf, lookuplookupTable, ref allfields, connection);
																		}
																		if (!string.IsNullOrWhiteSpace(tf.MetadatoExtendedChild))
																			lookuplookupTable = lookupField2.Table == tf.MetadatoExtendedChild.Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[0] ?
																										tf.MetadatoExtendedChild : tf.MetadatoChild;
																		else
																			lookuplookupTable = tf.MetadatoChild;

																		lookuplookupTables.Add(lookuplookupTable);
																		//lookuplookupTitle = lookupField2.TableTitle;
																		textField.Add(lookupField2);
																		textFieldOfTextField.Add(lookupField2);
																	}
															}
															else
																lookuplookupTables.Add(lookuplookupTable);

															if (addToDataset) {
																//se sto facendo un altro salto la tabella del secondo salto non verrebbe aggiunta al dataset 
																//quindi devo aggiungerla forzatamente 
																PreparePageDataset(pathMetaPage, lookupTable /*tf.Table*/, lookuplookupTable, tf.Name,
																tf.Name.Split('_')[0], metadatoChild, true, fields, allfields, GetEditTypeById(tf, allfields, connection), editListingType, null, connection,
																false, //gli dico se l'id fa da collegamento imponendo come se fi.table fosse una tabella di collegamento
																iteration + 1, null, fullTables, fullPathMetaPageJS, colpos, childColumns, null, iteration > 2, fkTitle);
															}
														}

													}
												lookupFieldsCount = lookupFields.Count;
											}
										}
										else {
											//se ÃƒÂ¨ giÃƒÂ  un text field ma di un'altra tabella allora vuol dire che GetLinkingObjectFields ha restituito campi di tabelle diverse 
											//perchÃƒÂ¨ collega un estendente e di conseguenza il suo esteso, quindi la tabella di lookup potrebbe essere quella estesa
											if (belongsToOtherTable(metadatoChildOriginal, textField.First()))
												//se ÃƒÂ¨ l'oggetto esteso uso il parametro e non textField.Table perchÃƒÂ¨ mi serve l'eventuale alias calcolato
												lookupTable = extendedTableChild;
										}

										foreach (var tf in textField) {
											var isTextFieldOfTextField = textFieldOfTextField.Any(tfotf => tfotf.Name == tf.Name && tfotf.Table == tf.Table);
											//recupero le tabelle di lookup dei lookup con i loro rispettivi alias, che sono stati recuperati dai metadatochild dei lookup nel ciclo precedente
											var lookuplookupTable = isTextFieldOfTextField ? lookuplookupTables.Where(lut => lut.StartsWith(tf.Table)).FirstOrDefault() : null;

											var colName = parentKey.Replace(" ", "-") + "_" + lookupTable + "_" + (
												isTextFieldOfTextField ? (lookuplookupTable ?? tf.Table) + "_" : ""
												) + tf.Name.Replace("!", "_x0021_");
											//dataset
											ReplaceStringInFile(pathMetaPage, "<!--LookupFields " + metadatoParent + "-->",
												"<xs:element name=\"" + "_x0021_" + colName + "\" " + " msdata:ReadOnly=\"false\" msdata:AllowDBNull=\"true\" " +
												"type=\"xs:" + GetDatasetType(tf.Type) + "\" minOccurs=\"0\" />\r\n" + "              <!--LookupFields " + metadatoParent + "-->", false, true);

											//metadato javascript
											objCalcFieldConfig.Add("						objCalcFieldConfig['!" + colName + "'] = { tableNameLookup:'" +
												(isTextFieldOfTextField ? (lookuplookupTable ?? tf.Table) : lookupTable) +
											"', columnNameLookup:'" + tf.Name + "', columnNamekey:'" + parentKey.Replace(" ", "-") + "' };\r\n");

											describeColumns.Add(GetFormatDescribeColumnJS(tf, "!" + colName, (colpos * 10) + cf.SortList + tf.Textfield,
												textField.Count > 1 ?
													(isTextFieldOfTextField ?
														/*lookuplookupTitle*/ tf.TableTitle //ho fatto il lookup del lookup quindi concateno il nome dell'oggetto del primo lookup
														:
														cf.Title) //mostro campi collegati da una foreign key nell'oggetto collegato quindi concateno il nome della colonna dell'oggetto 
																  //collegato con i nome delle colonne della tabella dove punta la foreign key 
													:
													descColumnColl.Count() > 1 ?
															lookupFieldsCount > 1 ? null //campi collegati semplici (non fk): mostro solo il nome della colonna dell'oggetto collegato
															:
															cf.Title//campo collegato da fk ma unico: mostro il titolo dell'oggetto collegato
														:
														fkTitle, //mostro solo una colonna dell'oggetto collegato quindi uso il nome dell'oggetto
												textField.Count > 1));

											ReplaceStringInLocalResourceFile(RegionMarker.LocalResource_colonne, "\"" + "grid_" + tf.Table + "_" + tf.EditListingType, "_" + "!" + colName + "\"", tf.Title.Replace("'", "\\'"));



											//metadato c#
											//describeColumns.Add(GetFormatDescribeColumn(cf, "!" + colName));
										}

									}
									//								if (describeColumns.Any()) {

									//									//aggiungo il describecolunm c# all'oggetto di collegamento
									//									var describeColumnsEnd = "\t\t\t\t\t\tbreak;\r\n\t\t\t\t\t}\r\n\t\t\t\t\t//$DescribeAColumn$";
									//									var describeColumnsCase = "				case \"" + editListingTypeParent + "\": {\r\n";

									//									var fullPathMetaDatoCS = solutionFolder +metadataFolder + metadatoParent + "/meta_" + metadatoParent + "/meta_" + metadatoParent + ".cs";

									//									if (File.Exists(fullPathMetaDatoCS)) {
									//										var filetxt = ReadAllTextFile(fullPathMetaDatoCS);
									//										bool justinsered = false;
									//										if (filetxt.Contains(describeColumnsCase)) {
									//											//recupero quanto giÃƒÂ  inserito per l'oggetto per tutti i list type nel describe columns 
									//											string tablePatternDescribeColumn = @"public override void DescribeColumns(.*?)\$DescribeAColumn\$";
									//											var element = Regex.Matches(filetxt, tablePatternDescribeColumn, RegexOptions.Singleline).Cast<Match>().Select(m => m.Value).ToList().First();
									//											//recupero quanto giÃƒÂ  inserito per lo specifico describe columns 
									//											string tablePattern = @"case """ + editListingTypeParent + @""": {
									//(.*?)						break;";
									//											var elementspecoriginale = Regex.Matches(element, tablePattern, RegexOptions.Singleline).Cast<Match>().Select(m => m.Value).ToList().FirstOrDefault();
									//											if (elementspecoriginale != null) {
									//												foreach (var dc in describeColumns) {
									//													if (!elementspecoriginale.Contains(dc)) {
									//														var elementspecmodificato = elementspecoriginale.Replace("\t\t\t\t\t\tbreak;", dc + "\t\t\t\t\t\tbreak;");
									//														//inserisco nello switch
									//														ReplaceStringInFile(fullPathMetaDatoCS, elementspecoriginale, elementspecmodificato);
									//													}
									//												}
									//												justinsered = true;
									//											}
									//										}

									//										if (!justinsered) {
									//											var dcc = describeColumnsCase;
									//											foreach (var dc in describeColumns)
									//												dcc += dc;
									//											dcc += describeColumnsEnd;

									//											ReplaceStringInFile(fullPathMetaDatoCS, "\t\t\t\t\t//$DescribeAColumn$", dcc);
									//										}

									//										//blocco l'eventuale rigenerazione da zero del metadato
									//										alreadyCreated.Add(metadatoParent);
									//									} else {
									//										ConsoleWriter.ErrorDB("Non trovo il file c# del metadato per aggiungere le descrizioni delle colonne: " + fullPathMetaDatoCS);
									//									}

								}
								else {
									ConsoleWriter.ErrorDB("Non trovo campi da mostrare per la tabella di collegamento " + metadatoParent);
								}
							}
							else {
								//se il padre non ÃƒÂ¨ un oggetto di collegamento, gli aggiungo le colonne di lookup nella griglia
								//SOLO SE si tratta di una relazione da che parte da una foreign key e il suo campo di lookup e NON se ÃƒÂ¨ una relazione con una subentitÃƒÂ 

								//se sto disegnando una grigli acon nipoti devo prendere tutti i campi definiti per la griglia e non i campi testuali
								//getmissing non serve perchÃƒÂ© metadatoChildOriginal arriva da metadatoChild che arriva da GetTablebyId che giÃƒÂ  lo fa
								var textFields = (iteration == 2 && relationChildField.ShowInParentGrid > 0) ?
									GetGridFieldByTable(metadatoChildOriginal, allfields, connection, false, editListingType) //caso colonne nipoti
									:
									GetTextFieldByTable(metadatoChildOriginal, allfields, connection, false, editListingType); //caso lookup (di griglie o nipoti)

								//controllo che non si tratti di un oggetto di collegamento forzato, per il quale non devo aggiungere lookup alla tabella parent
								if (!textFields.Where(tf => tf.IsLinkingObj).Any()) {

									//se i textfield restituiti sono diversi dalla chiave
									var stringtxtfields = string.Join(" ", textFields.Select(af => af.Name).ToList().OrderBy(x => x));
									var stringKeys = string.Join(" ", GetIdByTable(metadatoChildOriginal, allfields, connection).OrderBy(x => x));
									//il text field ÃƒÂ¨ diverso dalla sua chiave
									if (stringtxtfields != stringKeys || stringtxtfields == "aa") {

										var lookups = new List<string>();

										if (textFields.Any(tf => belongsToOtherTable(metadatoChildOriginal, tf))) {
											//mi ÃƒÂ¨ stato restituito il campo testuale da un esteso e non dell'oggetto corrente quindi devo cercare lÃƒÂ¬
											//aggiungo all'elenco dei lookup l'id dell'esteso che ÃƒÂ¨ lo stesso dell'estendete che ÃƒÂ¨ il parent
											textFields.ForEach(ntf => lookups.Add(parentKey));
										}

										//var tableWithText = metadatoChild;
										//se sono arrivato qui vuol dire che la tabella ha almeno un text field (diverso dalla sua chiave) ... 
										//...ma se a sua volta ÃƒÂ¨ una foreign key (quindi ÃƒÂ¨ la principal key di un altra tabella)? devo fare un altro salto per trovare il campo testuale
										//a meno che non sia un enum (chiave e testo uguali)
										var toRemove = new List<field>();
										var toAdd = new List<field>();

										foreach (var tf in textFields)
											if (HaveKeyName(tf) && !IsEnum(tf, allfields, connection)) {
												var secondaryTableText = GetTableById(tf.Name, allfields, connection);
												//potrei aver inserito tra i text field una delle chiavi della tabella stessa quindi ora controllo di non stare referenziando di nuovo se stessa
												if (metadatoChildOriginal != secondaryTableText) {
													var primatyTableTextKey = tf.Name;
													var secondaryTableTextKey = primatyTableTextKey.Split('_')[0];
													var newTextfields = GetTextFieldByTable(secondaryTableText, allfields, connection, false).ToList();
													//se ha restituito ancora una chiave mi fermo
													if (newTextfields.Any(ntf => !HaveKeyName(ntf))) {
														//verifico se questo text field in particolare era sull'esteso o sull'estendente
														var tfIsExtended = tf.Table == extendedTableChildOriginal;
														//aggiungo all'elenco dei lookup l'id intermedio
														newTextfields.ForEach(ntf => lookups.Add(tf.Name));
														//aggiungo i nuovi textfields a quelli da aggiungere
														toAdd.AddRange(newTextfields);
														//tolgo la chiave dai campi testuali in quanto ormai ÃƒÂ¨ rappresentata dai propri campi 
														toRemove.Add(tf);
														//siamo nell'ambito di tabelle utilizzate per generatre i campi testuali in griglie quindi va SEMPRE aggiunto l'alias
														//altrimenti si rischia che se piÃƒÂ¹ di una fk punta alla stessa tabella per i campi testuali la scantable la riempie per la prima fk e non per la seconda
														fields.Add(tf);
														SetMetadatoChild(fields, tf, newTextfields.First().Table, ref allfields, connection);
														if (tf.MetadatoChild.Contains("_alias"))
															//lasciare anche in non verbose
															ConsoleWriter.WarningDB("E' stata aggiunta la tabella con alias (" + tf.MetadatoChild + ") collegata da chiave esterna di un oggetto nipote (" +
																(tfIsExtended ? extendedTableChild : metadatoChild) + "). Verificare che poi l'alias sia presente anche nella sotto-pagina e sotto-sotto-pagina.");
														//se sto facendo un altro salto la tabella del secondo salto non verrebbe aggiunta al dataset 
														//quindi devo aggiungerla forzatamente.
														//Qualora il text field di partenza (tf) appartenga giÃƒÂ  ad un'altra tabella significa che detta tabella ÃƒÂ¨ l'estesa di metadatoChild che ÃƒÂ¨ suo estendente 
														//e quindi la relazione la costruisco con lei e non con metadatochild
														PreparePageDataset(pathMetaPage, tfIsExtended ? extendedTableChild : metadatoChild, tf.MetadatoChild ?? newTextfields.First().Table, primatyTableTextKey,
														secondaryTableTextKey, tfIsExtended ? extendedTableChild : metadatoChild, true, fields, allfields, GetEditTypeById(tf, allfields, connection), editListingType, null, connection,
														false, //gli dico se l'id fa da collegamento imponendo come se fi.table fosse una tabella di collegamento
														iteration + 1, null, fullTables, fullPathMetaPageJS, tf.SortList, childColumns, null, iteration > 2, tf.Title);
													}
												}
											}

										foreach (var tr in toRemove)
											textFields.Remove(tr);
										foreach (var ta in toAdd)
											textFields.Add(ta);

										//solo se ÃƒÂ¨ NON una subentitÃƒÂ  aggiungo i campi calcolati alla tabella parent
										if (!isSubentity) {
											//devo verificare se non ÃƒÂ¨ giÃƒÂ  stato inserito in un ciclo precedente
											var stringfilecalculatedfields = TextFile.ReadAllTextFile(pathMetaPage);
											var KeyPattern = "<xs:element name=\"" + metadatoParent + "\"(.*?)<!--LookupFields " + metadatoParent + "-->";
											var calculatedfields = Regex.Matches(stringfilecalculatedfields, KeyPattern, RegexOptions.Singleline).Cast<Match>().Select(m => m.Value).ToList()
											.FirstOrDefault();
											if (calculatedfields != null) {
												var i = 0;
												foreach (var textField in textFields) {
													//verifico se questo text field in particolare era sull'esteso o sull'estendente
													var tfIsExtended = textField.Table == extendedTableChildOriginal;
													//verifico se il text filed non ÃƒÂ¨ il risultato di un doppio salto altrimento devo indicare anche la seconda chiave del salto che protrebbero 
													//essere piÃƒÂ¹ di una per la stessa tabella ma con suffisso differente 
													bool isDoubleJump = (textField.Table != metadatoChildOriginal) && !tfIsExtended;
													var colName = parentKey.Replace(" ", "-") + "_" + metadatoChildOriginal + "_" +
																(isDoubleJump ? lookups[i].Replace(" ", "-") + "_" : "") + textField.Name;
													if (isDoubleJump)
														i++;

													//aggiungo la colonna calcolata ...
													//... al dataset
													if (!calculatedfields.Contains("_x0021_" + colName))
														ReplaceStringInFile(pathMetaPage, "<!--LookupFields " + metadatoParent + "-->",
															"<xs:element name=\"" + "_x0021_" + colName + "\" " +
															" msdata:ReadOnly=\"false\" msdata:AllowDBNull=\"true\" " +
															"type=\"xs:" + GetDatasetType(textField.Type) + "\" minOccurs=\"0\" />\r\n" + "<!--LookupFields " + metadatoParent + "-->", true);

													//solo se ÃƒÂ¨ una grid normale oppure un nipote aggiungo anche
													if (iteration == 2 || (iteration == 3 && (relationParentField ?? new field()).ShowInParentGrid > 0)) {
														//... al metadato js al describecolumns
														describeColumns.Add(GetFormatDescribeColumnJS(textField, "!" + colName, (colpos * 10) + textField.Textfield, fkTitle, textFields.Count > 1));

														ReplaceStringInLocalResourceFile(RegionMarker.LocalResource_colonne, "\"" + "grid_" + textField.Table + "_" + textField.EditListingType, "_" + "!" + colName + "\""
																									, textField.Title.Replace("'", "\\'"));

														//... al metadato js al describecolumns come calcolo
														objCalcFieldConfig.Add("						objCalcFieldConfig['!" + colName + "'] = { tableNameLookup:'" +
															(isDoubleJump ? textField.Table : (tfIsExtended ? extendedTableChild : metadatoChild)) + "', columnNameLookup:'" + textField.Name +
															"', columnNamekey:'" + parentKey.Replace(" ", "-") + "' };\r\n");
													}
												}
											}
										}
									}
								}

							}

							// DESCRIBECOLUMNS JS
							if (objCalcFieldConfig.Any()) {
								//creo il metadato js se necessario (recuperando anche la get new row personalizzata)
								var customGetNewRow = string.Empty;
								var currentAppTable = appTableRows.Where(r => r["tablename"].ToString() == container.Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[0]).FirstOrDefault();
								if (currentAppTable != null) {
									customGetNewRow = currentAppTable["customgetnewrow"].ToString();
								}

								SetMetadatoJs(fullPathMetaDatoJS, container, currentObject, currentApp, GetIdFieldsByTable(currentObject, allfields, connection, false),
								isExtendingObject, allfields, connection, customGetNewRow);

								//metto il describe a colums (sovrascrivo la prima volta perchÃƒÂ¨ ormai genero prima le subpage e poi le parent page)
								if (describeColumns.Any())
									SetDescribeColumnsOnJS(fullPathMetaDatoJS, editListingTypeParent, describeColumns);

								//metto il calcolo delle colonne
								SetDescribeColumnsOnJS(fullPathMetaDatoJS, editListingTypeParent, objCalcFieldConfig);

							}
						}


						//aggiungo le tabelle per i lookup delle entitÃƒÂ  figlie (chiavi esterne), tranne la chiave esterna stessa che le collega alla tabella parent
						if (!skiplookup && !minimal) {
							//--se trovo altre chiavi nei capi VISIBILI aggiungo le tabelle e le relazioni (campi di lookup) 
							//solo per tabelle al primo livello (griglia standard) o di secondo se ÃƒÂ¨ una tabella collegata
							if (iteration <= 1 || (parentIsLinkingObject && iteration == 2))
								foreach (var fi in allfields.Where(f =>
									(
									  (f.Table == metadatoChildOriginal && f.EditListingType == editListingType) || //campo dell'oggetto oppure ...
									  (f.Table == extendedTableChildOriginal && f.EditListingType == editListingTypeExtended) //... del suo esteso
									)
									&& (f.ListVisible || (f.Detailvisible && f.IsUniqueField)) //o lo mostrerÃƒÂ² in elenco o se ÃƒÂ¨ in relazione 1 a 1 nella maschera
									&& HaveKeyName(f) /*&& !f.Name.StartsWith("parid") */&&
									(!IsPrincipalKey(f, f.Table) || islinkingobject || GetException(null, null, f.Table, f.Name) != null)
									//NON scriverÃƒÂ² nel describecolum di una sub-entitÃƒÂ  la chiave del padre che causerebbe una griglia con una colonna
									//con valori tutti uguali all'oggetto padre
									&& !childkey.Split(' ').Contains(f.Name)).ToList()
									) {

									var tablechild = GetTableById(fi.Name, allfields, connection);

									if (!string.IsNullOrEmpty(tablechild) && !string.IsNullOrEmpty(fi.Name)) {

										var listtype = GetEditTypeById(fi, allfields, connection);

										//if (
										//	//gli oggetti estesi vanno sempre con l'alias
										//	!string.IsNullOrWhiteSpace(fi.MetadatoExtendedChild) ||
										//	//se c'ÃƒÂ¨ un altro campo che ha generato autochoose sulla stessa tabella o vista devo aggiungere sempre l'alias
										//	fields.Any(f => (f.MetadatoChild ?? "").Split(new string[] { "_alias" }, StringSplitOptions.None)[0] == tablechild && !IsDropdown(f))
										//	)

										//siamo nell'ambito di tabelle utilizzate per generatre i campi testuali in griglie quindi va SEMPRE aggiunto l'alias
										//altrimenti si rischia che se piÃƒÂ¹ di una fk punta alla stessa tabella per i campi testuali la scantable la riempie per la prima fk e non per la seconda
										fields.Add(fi);
										SetMetadatoChild(fields, fi, tablechild, ref allfields, connection);

										var childobject = fi.MetadatoChild;
										var extendedchildobject = fi.MetadatoExtendedChild;
										var childIsExt = !string.IsNullOrWhiteSpace(extendedchildobject);

										if (childIsExt) {
											// se il cild ÃƒÂ¨ estendente il list type attuale ÃƒÂ¨ quello dell'esteso devo quindi correggerlo
											if (listtype.Contains("_")) {
												listtype = listtype.Substring(listtype.IndexOf("_"), listtype.Length - listtype.IndexOf("_"));
											}
											else listtype = "default";
										}

										var skipLookup = true;
										if (!IsView(fi.MetadatoChild))
											skipLookup = iteration > 2 || IsEnum(fi, allfields, connection);

										var isext = fi.Table == extendedTableChildOriginal;

										var key = fi.Name;
										var childobjectkey = GetIdByForeignKey(fi);
										if (childobjectkey.Split(' ').Count() > 1) {
											//l'oggetto puntato dalla chiave ha una chiave multipla quindi l'oggetto corrente deve avere una foreign key da piÃƒÂ¹ colonne
											//fields nei livelli della ricorsione contiene colonne di altre tabelle quindi filtro per la corrente
											key = string.Join(" ", allfields.Where(af => (af.Table == extendedTableChild && af.EditListingType == editListingTypeExtended ||
																			 af.Table == metadatoChild && af.EditListingType == editListingType)
																			 &&
																		  (childobjectkey.Split(' ').Any(ck => ck == af.Name.Split('_')[0]) ||
																		  (af.Name.Contains("_") && childobjectkey.Split(' ').Any(ck => ck == af.Name.Split('_')[1])))
																		).Select(k => k.Name));
										}

										PreparePageDataset(pathMetaPage, isext ? extendedTableChild : metadatoChild, childobject, key, childobjectkey,
											metadatoChild, true, fields, allfields, listtype, isext ? editListingTypeExtended : editListingType, null, connection,
											fi.IsLinkingObj, //gli dico se l'id fa da collegamento imponendo come se fi.table fosse una tabella di collegamento
											iteration + 1, isext ? null : extendedchildobject, fullTables, fullPathMetaPageJS, fi.SortList, childColumns, null, skipLookup, fi.Title);
									}
								}

							//--se trovo sottopagine le devo aggiungere al dataset altrimenti poi non funzionano i salvataggi
							if (!string.IsNullOrEmpty(pageid)) {
								//----ricavo le relazioni
								var relationFields = GetChildentitiesFields(pageid, "", allfields, connection);

								var mdck = string.Join(" ", GetIdByTable(metadatoChild, allfields, connection, true, editListingType));

								//----ricavo i campi del dataset (precedenti e calcolati adesso) calcolando gli alias per i nuovi campi relazione
								foreach (var r in relationFields) {
									var tc = r.Name.Substring(2);
									GetMissingFields(tc, null, ref allfields, connection);

									//per le relazioni i rami vanno tenuti sempre separati con gli alias a tutti i livelli:
									//caso 1 - potrebbero essere giÃƒÂ  stati calcolati perchÃƒÂ© convolti in una colonna nipote
									var nephewdAlreadyCalculated = childColumns.Where(cc => cc.PageId == pageid && cc.Nephew.Name == r.Name).FirstOrDefault();
									if (nephewdAlreadyCalculated != null) {
										r.MetadatoChild = nephewdAlreadyCalculated.Nephew.MetadatoChild;
										r.MetadatoExtendedChild = nephewdAlreadyCalculated.Nephew.MetadatoExtendedChild;

										//aggiungo le colonne nipoti calcolate
										var colName = nephewdAlreadyCalculated.Columncalc.Substring(1);
										ReplaceStringInFile(pathMetaPage, "<!--LookupFields " + nephewdAlreadyCalculated.Tablename + "-->",
											  "<xs:element name=\"" + "_x0021_" + colName + "\" " +
											  " msdata:ReadOnly=\"false\" msdata:AllowDBNull=\"true\" " +
											  "type=\"xs:string\" minOccurs=\"0\" />\r\n" + "<!--LookupFields " + nephewdAlreadyCalculated.Tablename + "-->", true);

										//... al metadato js al describecolumns
										var describeColumns = new List<string>() { GetFormatDescribeColumnJS(nephewdAlreadyCalculated.Nephew, "!" + colName, 10 * nephewdAlreadyCalculated.Nephew.ShowInParentGrid) };
										var fullPathMetaDatoJSTablename = GetFullPathMetaDatoJS(nephewdAlreadyCalculated.Tablename, allfields, connection);
										SetDescribeColumnsOnJS(fullPathMetaDatoJSTablename, nephewdAlreadyCalculated.Edittype, describeColumns);

										ReplaceStringInLocalResourceFile(RegionMarker.LocalResource_colonne, "\"" + nephewdAlreadyCalculated.ControlName, "_" + "!" + colName + "\"", nephewdAlreadyCalculated.Nephew.Title.Replace("'", "\\'"));

									}

									if (iteration > 0) {
										//caso 2 - casi normali in cui calcolo l'alias adesso
										SetMetadatoChild(fields, r, tc, ref allfields, connection);
										fields.Add(r);
									}
									else {
										//caso 3 - i figli di oggetti con una relazione 1 a 1 (iteration = 0) sono giÃƒÂ  stati considerati e hanno giÃƒÂ  l'alias calcolato
										var childAlreadyCalculated = fields.Where(ff => ff.Name == r.Name).FirstOrDefault();
										if (childAlreadyCalculated != null) {
											r.MetadatoChild = childAlreadyCalculated.MetadatoChild;
											r.MetadatoExtendedChild = childAlreadyCalculated.MetadatoExtendedChild;
										}
									}

									//di base le chiavi del figlio sono: foreign key anche con suffissi o prefissi ?? subentitÃƒÂ 
									var ckString = r.LookupFor ?? mdck;

									//verifico se ÃƒÂ¨ un figlio ricorsivo
									var kc = GetIdByTable(tc, allfields, connection, true, r.Listtype);
									if (kc.Any(k => k.StartsWith("parid"))) {
										ckString = GetChildKeysString(metadatoChild, tc, editListingType, r.Listtype, mdck.Split(' ').ToList(), allfields, connection);
									}

									//se ÃƒÂ¨ figlio di un oggetto con una relazione 1 a 1 (ma non di una griglia con ricerca perchÃƒÂ¨ gestisce la parentrow autonomamente) 
									//devo specificare al getNewRow che la parentrow in questo caso non ÃƒÂ¨ qella principale ma un'altra
									if (iteration == 0 && r.RelationType != "cerca") {
										var fullPathMetaDatoJStc = clientFolder + metapageFolder + tc/*.Split('_')[0]*/ + "/meta_" + tc + ".js"; //TODO se ÃƒÂ¨ estendente ÃƒÂ¨ sbagliato il container?

										//creo il metadato js se necessario (recuperando anche la get new row personalizzata)
										var customGetNewRow = string.Empty;
										var currentAppTable = appTableRows.Where(tr => tr["tablename"].ToString() == tc.Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[0]).FirstOrDefault();
										if (currentAppTable != null) {
											customGetNewRow = currentAppTable["customgetnewrow"].ToString();
										}

										SetMetadatoJs(fullPathMetaDatoJStc, tc, tc, currentApp, GetIdFieldsByTable(tc, allfields, connection, false),
											IsExtendingObject(tc, ref allfields, connection), allfields, connection, customGetNewRow);

										ReplaceStringInFile(fullPathMetaDatoJStc, "//$getNewRowInside$\r\n",
											"var realParentObjectRow = parentRow;\r\n" +
											"				//$getNewRowInside$\r\n");
										var getnewrowinside =

											"if (editType === \"" + r.Listtype + "\") {\r\n" +
											"					var realParentTableName = \"" + metadatoChild + "\";\r\n" +
											"					var realParentTable = dt.dataset.tables[\"" + metadatoChild + "\"];\r\n" +
											"					if (!realParentTable) {\r\n" +
											"						console.log(\"ERROR: la tabella \" + realParentTableName + \"  non esiste nel dataset\");\r\n" +
											"						return def.resolve(null);\r\n" +
											"					}\r\n" +
											"					if (!realParentTable.rows.length) {\r\n" +
											"						console.log(\"ERROR: la tabella \" + realParentTableName + \"  non ha righe\");\r\n" +
											"						return def.resolve(null);\r\n" +
											"					}\r\n" +
											"					realParentObjectRow = realParentTable.rows[0].getRow();\r\n" +
											"				}\r\n" +
											"				//$getNewRowInside$\r\n";

										ReplaceStringInFile(fullPathMetaDatoJStc, "//$getNewRowInside$\r\n", getnewrowinside);
										ReplaceStringInFile(fullPathMetaDatoJStc, "return this.superClass.getNewRow(parentRow, dt, editType)", "return this.superClass.getNewRow(realParentObjectRow, dt, editType)");
									}

									//se sto costruendo una subpage su una vista come fosse una vera e propria tabella devo avvisare il framework di non salvarla/modificarla/eliminarla
									if (IsView(r.MetadatoChild ?? tc))
										SetBeforePost(fullPathMetaPageJS, "this.getDataTable('" + (r.MetadatoChild ?? tc) + "').acceptChanges();\r\n");

									//non puÃƒÂ² essere minimal perchÃƒÂ¨ ci potrebbero essere campi di lookup in tabelle ulteriori
									PreparePageDataset(pathMetaPage, metadatoChild, r.MetadatoChild ?? tc, mdck, ckString.Trim(),
										metadatoChild, false, fields, allfields, r.Listtype, editListingType, r.PageId, connection,
										false, //metadatoChild verrÃƒÂ  comunque verificato se ÃƒÂ¨ di collegamento dal metodo stesso
										iteration + 1, r.MetadatoExtendedChild, fullTables, fullPathMetaPageJS, null, childColumns, null, skiplookup, r.Title);
								}
							}
						}

						//se ÃƒÂ¨ un oggetto estendente devo mettere anche l'oggetto che estende (esteso), ma solo se non ÃƒÂ¨ una vista dell'estendente che comprende giÃƒÂ  l'esteso!
						if (!string.IsNullOrEmpty(extendedTableChild) && !IsView(metadatoChild)) {
							//la chiave di esteso e estendente coincidono
							var keysExtended = GetIdByTable(extendedTableChild, allfields, connection, true, editListingTypeExtended);
							var keysExtendedString = String.Join(" ", keysExtended);
							//var keysString = GetChildKeysString(extendedTableChild, metadatoChild, editListingTypeExtended, editListingType, keysExtended, allfields, connection);

							//l'iteration non la incremento perchÃƒÂ¨ ÃƒÂ¨ allo stesso livello dell'estendete

							PreparePageDataset(pathMetaPage, extendedTableChild, metadatoChild, keysExtendedString.Trim(), keysExtendedString.Trim() /*keysString.Trim()*/, metadatoChild, false, fields, allfields, editListingType,
								editListingTypeExtended, null, connection, false, iteration + 1, "", fullTables, fullPathMetaPageJS, 1, childColumns, null, iteration > 2, fkTitle);
						}

					}
				}

				//inserisco la relazione solo per le tabelle trovate sul db (o se sono quella corrente)
				if ((!string.IsNullOrEmpty(datasetMetadatoParent) || metadatoParent == current) && (!string.IsNullOrEmpty(datasetMetadatoChild) || metadatoChild == current)) {

					var datasetRelation = "";

					//se ho cotruito il figlio per intero (!minimal) 
					//e il padre non ÃƒÂ¨ un oggetto di collegamento (!parentIsLinkingObject) 
					//e il figlio non ÃƒÂ¨ in realta un oggetto esteso e quindi il padre naturale (!isAnInvertedExtensionRelation) 
					//e il figlio non ÃƒÂ¨ la tabella degli allegati (metadatoChild != "attach"): 
					//allora la chiave esterna ÃƒÂ¨ del figlio e interna del padre (il child ÃƒÂ¨ una subentitÃƒÂ ), 
					//altrimenti li scambio (il child ÃƒÂ¨ un vocabolario o un oggetto esteso o un allegato)
					if (isSubEntityRelation) {
						//sub-entitÃƒÂ 

						//se si tratta di un oggetto estendente il suo esteso gli ruba la relazione nel caso di lookup
						if (!string.IsNullOrEmpty(extendedTableChild) && !skiplookup) {
							var childkeyExt = GetChildKeysString(metadatoParent, extendedTableChild, editListingType, editListingTypeExtended, parentKey.Split(' ').ToList(), allfields, connection);

							datasetRelation = "     <msdata:Relationship name=\"FK_" + extendedTableChild + "_" + metadatoParent + "_" + childkey.Replace(" ", "-") + "\" msdata:parent=\"" +
							metadatoParent + "\" msdata:child=\"" + extendedTableChild + "\" msdata:parentkey=\"" + parentKey + "\" msdata:childkey=\"" + childkeyExt + "\" />\r\n";
						}
						else {
							//nel caso sia una subpage per un oggetto che NON ÃƒÂ¨ subentitÃƒÂ  devo rivalutare la relazione perchÃƒÂ¨ potrebbe essere su foreign key e non su primary key
							if (parentKey.Split(' ').Count() != childkey.Split(' ').Count()) {
								var kk = GetChildForeignKeysString(metadatoParent, metadatoChild, editListingTypeParent, editListingType, parentKey.Split(' ').ToList(), allfields, connection);
								childkey = kk.Replace(" ;", ";").Split(';')[0].TrimEnd();
								parentKey = kk.Replace(" ;", ";").Split(';')[1].TrimEnd();
							}
							datasetRelation = "     <msdata:Relationship name=\"FK_" + metadatoChild + "_" + metadatoParent + "_" + childkey.Replace(" ", "-") + "\" msdata:parent=\"" +
							metadatoParent + "\" msdata:child=\"" + metadatoChild + "\" msdata:parentkey=\"" + parentKey + "\" msdata:childkey=\"" + childkey + "\" />\r\n";
						}
					}
					else {
						//vocabolario/esteso/allegato

						//se si tratta di un oggetto estendente il suo esteso gli ruba la relazione nel caso di lookup
						if (!string.IsNullOrEmpty(extendedTableChild) && !skiplookup)
							datasetRelation = "     <msdata:Relationship name=\"FK_" + metadatoParent + "_" + extendedTableChild + "_" + parentKey.Replace(" ", "-") + "\" msdata:parent=\"" +
								extendedTableChild + "\" msdata:child=\"" + metadatoParent + "\" msdata:parentkey=\"" + childkey + "\" msdata:childkey=\"" + parentKey + "\" />\r\n";
						else
							datasetRelation = "     <msdata:Relationship name=\"FK_" + metadatoParent + "_" + metadatoChild + "_" + parentKey.Replace(" ", "-") + "\" msdata:parent=\"" +
								metadatoChild + "\" msdata:child=\"" + metadatoParent + "\" msdata:parentkey=\"" + childkey + "\" msdata:childkey=\"" + parentKey + "\" />\r\n";
					}

					//Check che i tipi delle chiavi siano coerenti
					var childIndex = 0;
					foreach (var pk in parentKey.Split(' ')) {
						var truepk = allfields.Where(f => f.Table == metadatoParentOriginal && f.Name == pk).First();
						var trueck = allfields.Where(f => f.Table == metadatoChildOriginal && f.Name == childkey.Split(' ')[childIndex]).First();
						if (truepk.Type != trueck.Type) {
							var stringTypes = new List<string> { "varchar", "nvarchar" };
							if (stringTypes.Contains(truepk.Type) && stringTypes.Contains(trueck.Type))
								ConsoleWriter.WarningDB("Nella relazione tra " + metadatoChild + " e " + metadatoParent + " le chiavi " + pk + " e " + trueck.Name + " sono rispettivamente di tipo " + truepk.Type + " e " + trueck.Type + " mentre dovrebbero avere lo stesso tipo");
							else
								ConsoleWriter.ErrorDB("Nella relazione tra " + metadatoChild + " e " + metadatoParent + " le chiavi " + pk + " e " + trueck.Name + " sono rispettivamente di tipo " + truepk.Type + " e " + trueck.Type + " mentre dovrebbero avere lo stesso tipo");
						}
						childIndex++;
					}

					if (iteration == 1 && !string.IsNullOrWhiteSpace(masterTable)) {
						var childFields = allfields.Where(af => af.Table == RemoveAlias(metadatoChild) && (af.EditListingType == editListingType || RemoveAlias(metadatoChild).EndsWith(editListingType + "view"))).ToList();
						if (childFields.Any()) {
							var rel = GetChildKeysbyMaster(masterTable, childFields, allfields, connection);
							if (rel.Any())
								datasetRelation += "     <msdata:Relationship name=\"FK_" + metadatoChild + "_" + masterTable + "_" + rel[0].Name + "\" msdata:parent=\"" +
									masterTable + "\" msdata:child=\"" + metadatoChild + "\" msdata:parentkey=\"" + rel[0].Name + "\" msdata:childkey=\"" + rel[1].Name + "\" />\r\n";
						}
						else {
							ConsoleWriter.ErrorDB("non sono riuscito a trovare i campi di " + metadatoChild + " " + editListingType + " per la sua relazione con il campo master " + masterTable);
						}
					}

					SetRelationInDataset(pathMetaPage, datasetRelation);
					//if (TextFile.ReadAllTextFile(pathMetaPage).Contains("   <xs:appinfo>")) {
					//	ReplaceStringInFile(pathMetaPage, "<xs:appinfo>\r\n", "<xs:appinfo>\r\n" + datasetRelation);
					//}
					//else {
					//	ReplaceStringInFile(pathMetaPage, "</xs:schema>", "  <xs:annotation>\r\n    <xs:appinfo>\r\n" + datasetRelation + "    </xs:appinfo>\r\n  </xs:annotation>\r\n</xs:schema>");
					//}
				}
			}

		}

		/// <summary>
		/// Scrive la relazione sul file xml XSD del dataset
		/// </summary>
		/// <param name="datasetFullPath">file xml XSD del dataset</param>
		/// <param name="datasetRelation">relazione</param>
		private static void SetRelationInDataset(string datasetFullPath, string datasetRelation) {
			if (TextFile.ReadAllTextFile(datasetFullPath).Contains("   <xs:appinfo>")) {
				ReplaceStringInFile(datasetFullPath, "<xs:appinfo>\r\n", "<xs:appinfo>\r\n" + datasetRelation);
			}
			else {
				ReplaceStringInFile(datasetFullPath, "</xs:schema>", "  <xs:annotation>\r\n    <xs:appinfo>\r\n" + datasetRelation + "    </xs:appinfo>\r\n  </xs:annotation>\r\n</xs:schema>");
			}

		}

		/// <summary>
		/// Medodo che aggiunge la tabella di un metadato al dataset, verificandone la presenza minimale o normale e aggiungendola o sostituendola se necessario
		/// </summary>
		/// <param name="pathMetaPage"></param>
		/// <param name="metadatoChild"></param>
		/// <param name="datasetMetadatoChild"></param>
		/// <param name="minimal"></param>
		private static void addTableToDataset(string pathMetaPage, string metadatoChild, string datasetMetadatoChild, bool minimal) {
			var metadatoChildOriginal = metadatoChild.Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[0];
			var stringfile = TextFile.ReadAllTextFile(pathMetaPage);
			var fileContainsMinimal = stringfile.Contains("<xs:element name=\"" + metadatoChild + "\"" + (metadatoChild.Contains("_alias") ? " msprop:TableForReading=\"" + metadatoChildOriginal + "\"" : "") + "><!--m-->");
			var fileContainsNormal = stringfile.Contains("<xs:element name=\"" + metadatoChild + "\"" + (metadatoChild.Contains("_alias") ? " msprop:TableForReading=\"" + metadatoChildOriginal + "\"" : "") + "><!--n-->")
							  || stringfile.Contains("<xs:element name=\"" + metadatoChild + "\">\r\n");

			//se non c'ÃƒÂ¨ l'aggiungo
			if (!fileContainsMinimal && !fileContainsNormal) {
				ReplaceStringInFile(pathMetaPage, "<xs:choice minOccurs=\"0\" maxOccurs=\"unbounded\">\r\n", "<xs:choice minOccurs=\"0\" maxOccurs=\"unbounded\">\r\n" + datasetMetadatoChild.Split(';')[0]);
				ReplaceStringInFile(pathMetaPage, "</xs:complexType>\r\n    <xs:unique", "</xs:complexType>\r\n    " + datasetMetadatoChild.Split(';')[1] + "    <xs:unique");
			}
			else {
				//se c'ÃƒÂ¨ lo sostituisco solo nei seguenti casi:
				if (fileContainsMinimal && !minimal) {// se giÃƒÂ  c'ÃƒÂ¨ minimale e lo sto aggiungendo normale la sostituisco
					if (verbose)
						Console.WriteLine("INFO: Per " + metadatoChild + " il dataset contiene giÃƒÂ  una versione minimale e la sto aggiungendo normale, oppure normale e la sto aggiungendo normale ed ÃƒÂ¨ visibile in maschera, quindi la sostituisco");

					//sostituisco la tabella se era minimale ... la chiave invece ÃƒÂ¨ sempre uguale
					if (fileContainsMinimal) {
						string tablePattern = "<xs:element name=\\\"" + metadatoChild + "\\\"" + (metadatoChild.Contains("_alias") ? " msprop:TableForReading=\\\"" + metadatoChildOriginal + "\\\"" : "") + "><!--" + (fileContainsMinimal ? "m" : "n") + "-->(.*?)</xs:element>";
						var element = Regex.Matches(stringfile, tablePattern, RegexOptions.Singleline).Cast<Match>().Select(m => m.Value).ToList().First();
						ReplaceStringInFile(pathMetaPage, element, "");
						ReplaceStringInFile(pathMetaPage, "<xs:choice minOccurs=\"0\" maxOccurs=\"unbounded\">\r\n", "<xs:choice minOccurs=\"0\" maxOccurs=\"unbounded\">\r\n" + datasetMetadatoChild.Split(';')[0]);
					}

				}
				else {
					if (verbose)
						Console.WriteLine("INFO: Per " + metadatoChild + " il dataset contiene giÃƒÂ  una versione minimale e la sto aggiungendo mimimale, oppure normale e la sto aggiungendo normale quindi non la aggiungo");
				}
			}
		}

		/// <summary>
		/// Restituisce l'xml delle chiavi e della tabella a partire dai campi
		/// </summary>
		/// <param name="tablename">nome della tabella</param>
		/// <param name="minimal">indica se lo vogliamo ridotto al solo indice e campo testuale (per dropdown e autochoose)</param>
		/// <param name="allfields">campi</param>
		/// <param name="connection"></param>
		/// <returns></returns>
		private static string GetDatasetTable(string tablename, string tableAliasParent, bool minimal, List<field> allfields, SqlConnection connection, string editListingType, string fullPathMetaPageJS, int iteration = 0,
			string parentkey = null, string masterTable = null) {

			//verifico che non si tratti di un alias
			var tableAlias = tablename;
			if (tablename.Contains("_alias"))
				tablename = tableAlias.Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[0];

			//verifico che i campi siano giÃƒÂ  stati caricati dal db altrimento lo faccio ora
			GetMissingFields(tablename, null, ref allfields, connection);

			//estrapolo i dati dei campi della tabella senza le informazioni delle interfacce
			var tableFields = new List<field>();
			if (string.IsNullOrEmpty(editListingType) || (!string.IsNullOrEmpty(editListingType) && !allfields.Any(af => af.Table == tablename && af.EditListingType == editListingType)))
				//potrei stare aggingendo al dataset: 
				//1 - una tabella aggiuntiva (quindi senza un edit type specifico): 
				//2 - una tabella referenziata tramite fk (vocabolario) di cui proverÃƒÂ² sempre prima con l'edit type "default" ma potrebbe anche non esistere
				tableFields = GetDatasetFields(tablename, allfields);
			else
				tableFields = allfields.Where(af => af.Table == tablename && af.EditListingType == editListingType).ToList();

			var fields = new List<field>();

			//se ÃƒÂ¨ una vista devo settare delle chiavi, a prescindere se sia minimale o meno
			if (IsView(tablename)) {
				//verifico prima che non siano giÃƒÂ  state forzate nel configuratore...
				if (!tableFields.Any(tf => tf.IsKey)) {
					//...altrimenti cerco di desumerle
					var originalTable = GetOriginalTableByView(tablename, editListingType, allfields);

					if (!string.IsNullOrWhiteSpace(originalTable)) {
						var originalTableKeys = GetIdByTable(originalTable, allfields, connection, true, editListingType);
						foreach (var k in tableFields.Where(af => originalTableKeys.Contains(af.Name)))// IsPrincipalKey(af, originalTable, true)))
							k.IsKey = true;
						if (!tableFields.Any(tf => tf.IsKey))
							if (verbose)
								ConsoleWriter.ErrorDB("Per la vista " + tablename + " non ÃƒÂ¨ stato trovato il campo chiave");
					}
					else
						if (verbose)
						ConsoleWriter.ErrorDB("Per la vista " + tablename + " non ÃƒÂ¨ stato trovato il campo chiave perchÃƒÂ¨ non ÃƒÂ¨ stata trovata la tabella di partenza");
				}
			}

			//nella versione minimale ci devono essere:
			if (minimal) {
				if (!IsView(tablename)) {
					//1-le chiavi e chiavi eccezionali
					var keyfield = tableFields.Where(af => af.IsKey);
					fields.AddRange(keyfield);
					var ex = GetException(tablename, null, null, null);
					if (ex != null) {
						if (ex.Item2.Split(' ').Any(ek => !keyfield.Any(kf => kf.Name == ek))) {
							var exk = ex.Item2.Split(' ').Where(ek => !keyfield.Any(kf => kf.Name == ek));
							fields.AddRange(tableFields.Where(tf => exk.Any(ek => ek == tf.Name)));
						}
					}

					//2-i campi testuali
					foreach (var txt in GetTextFieldByTable(tablename, allfields, connection, false, editListingType)) //il get missing l'ho fatto poco prima
					{
						if (belongsToOtherTable(tablename, txt)) {
							//non posso realizzare la tabella minimale senza coinvolgere anche la tabella estesa, (che verrÃƒÂ  comunque aggiunta al dataset nei passaggi successivi)
							//quindi rinuncio e la metto per esteso
							minimal = false;
							fields = new List<field>();
							break;
						}

						if (!fields.Any(af => af.Name == txt.Name))
							fields.AddRange(tableFields.Where(af => af.Name == txt.Name));
					}

					//3-campo active
					foreach (var a in tableFields.Where(tf => tf.Name == "active"))
						if (!fields.Any(af => af.Name == a.Name))
							fields.AddRange(tableFields.Where(af => af.Name == a.Name));

				}
				else {
					//1-le chiavi
					var keyfield = tableFields.Where(af => HaveKeyName(af));
					fields.AddRange(keyfield);

					//2-i campi testuali
					var txtf = tableFields.Where(af => af.Name == "dropdown_title").FirstOrDefault();
					if (txtf != null)
						fields.Add(txtf);
					else
						ConsoleWriter.WarningDB("Per la vista " + tablename + " non ÃƒÂ¨ stato trovato il campo testuale");

					//3-campo active
					foreach (var a in tableFields.Where(tf => tf.Name.EndsWith("active")))
						if (!fields.Any(af => af.Name == a.Name))
							fields.AddRange(tableFields.Where(af => af.Name == a.Name));

				}

				//3-eventuali foreign key alla tabella master
				if (!string.IsNullOrWhiteSpace(masterTable)) {
					var rel = GetChildKeysbyMaster(masterTable, tableFields, allfields, connection);
					if (rel.Any())
						if (!fields.Any(f => f.Name == rel[1].Name))
							fields.Add(rel[1]);
				}
			}

			if (!minimal) {
				//se ÃƒÂ¨ una tabella completa ci vanno anche i suoi campi di lookup
				fields.AddRange(tableFields);
				//il contatore degli allegati e i campi file per gli importer non vanno mai aggiunti
				fields.RemoveAll(f => (f.Table == "attach" && f.Name == "counter") || f.Type == "file");
			}

			return GetDatasetTable(tablename, tableAlias, tableAliasParent, minimal, fields, fullPathMetaPageJS, iteration, parentkey);
		}

		/// <summary>
		/// Restituisce l'xml delle chiavi e della tabella a partire dai fields
		/// </summary>
		/// <param name="tablename">nome della tabella</param>
		/// <param name="tableAlias">alias della tabella</param>
		/// <param name="minimal">indica se lo vogliamo ridotto al solo indice e campo testuale (per dropdown e autochoose)</param>
		/// <param name="fields">campi</param>
		/// <param name="parentkey">chiavi del padre</param>
		/// <returns></returns>
		private static string GetDatasetTable(string tablename, string tableAlias, string tableAliasParent, bool minimal, List<field> fields, string fullPathMetaPageJS, int iteration, string parentkey = null) {

			var datasetmedatdatoKeys = "<xs:unique name=\"" + tableAlias + "_Constraint\" msdata:PrimaryKey=\"true\">\r\n      <xs:selector xpath=\".//mstns:" + tableAlias + "\" />\r\n";

			//Se sto costruento un elenco di oggetti che si riferiscono a quello corrente senza essere direttamente subentitÃƒÂ  (ad es le lezioni che si svolgono nell'aula)
			//oppure oggetti subentitÃƒÂ  ma relativi ad un'entitÃƒÂ  estesa (ad esempio sospensione relativa a location)
			//devo (per il dataset di questa interfaccia) forzare a chiave la chiave del padre, tranne se si tratta di oggetti esteso e estendente che giÃƒÂ  lo ÃƒÂ¨
			var isNotEntityChild = false;
			if (!string.IsNullOrEmpty(parentkey))
				if (!isSubentity(parentkey.Split(' ').ToList(), fields)) {
					isNotEntityChild = true;
					//mi trovo nel caso di sub-page riferite a oggetti che non sono sub-entitÃƒÂ  quindi lo devo indicare nella metapage
					SetAfterClear(fullPathMetaPageJS, "appMeta.metaModel.addNotEntityChild(this.getDataTable('" + tableAliasParent + "'), this.getDataTable('" + tableAlias + "'));\r\n");
					SetAfterFill(fullPathMetaPageJS, "appMeta.metaModel.addNotEntityChild(this.getDataTable('" + tableAliasParent + "'), this.getDataTable('" + tableAlias + "'));\r\n");

					if (fields.Count(f => f.IsKey) < iteration) {
						ConsoleWriter.ErrorDB("La tabella " + tableAlias + " non ha tra le sue chiavi tutte le chiavi di della tabella parent " + tableAliasParent + ", e si trova un una sottointerfaccia al " + iteration +
							" livello, quindi creando due nuovi record, su due rami partendo da padri di primo livello diversi, avrebbero la stessa chiave sul dataset della pagina principale, creando cosÃƒÂ¬ un errore a runtime. " +
							"Aggiungere la chiave dei suoi padri almeno fino al primo livello.");
					}
					else {
						ConsoleWriter.WarningDB("La tabella " + tableAlias + " non ha tra le sue chiavi tutte le chiavi di della tabella parent " + tableAliasParent + ", e si trova un una sottointerfaccia al " + iteration +
							" livello, quindi creando due nuovi record, su due rami partendo da padri di primo livello diversi, potrebbero avere la stessa chiave sul dataset della pagina principale, creando cosÃƒÂ¬ un errore a runtime. " +
							"Verificare se non sia necessario aggiungere la chiave dei suoi padri almeno fino al primo livello.");
					}

					////lo aggiungo anche se ha un suffisso
					//var fk = fields.FirstOrDefault(f => !f.IsKey && f.Name.Split('_')[0] == pk) ?? new field { Name = pk };
					////in ogni caso verifico di agguungere alla chiave una colonna esisitente
					//if (fields.Any(f => f.Name == fk.Name))
					//{
					//	datasetmedatdatoKeys += "      <xs:field xpath=\"mstns:" + fk.Name + "\" />\r\n";
					//	//devo fare in modo che la pagina ne imponga l'inserimento (a meno che non lo ÃƒÂ¨ giÃƒÂ )
					//	if (!fk.DenyNull)
					//	{
					//		SetAfterlink(fullPathMetaPageJS, "this.setDenyNull(\"" + fk.Table + (fk.ForceAlias > 0 ? "_alias" + fk.ForceAlias.ToString() : "") + "\",\"" + fk.Name + "\");\r\n");
					//		if (verbose)
					//			Console.WriteLine("INFO: " + fk.Table + "\",\"" + fk.Name + " ÃƒÂ¨ stato inserito con allowDBnull = false nella pagina " + fullPathMetaPageJS +
					//				" perchÃƒÂ¨ nella costruzione del dataset ÃƒÂ© risultato essere chiave del padre e non del figlio (" + tableAlias + ") ed ÃƒÂ¨ stato forzato a chiava anche nel figlio");
					//	}
					//}
				}

			var datasetMetadato = "        <xs:element name=\"" + tableAlias + "\"" + (tableAlias != tablename ? " msprop:TableForReading=\"" + tablename + "\"" : "") + (isNotEntityChild ? " msprop:NotEntityChild=\"true\" " : "") +
				">" + (minimal ? "<!--m-->" : "<!--n-->") + "\r\n          <xs:complexType>\r\n            <xs:sequence>\r\n";

			foreach (var fi in fields.Where(f => !f.Name.StartsWith("XX")).OrderBy(f => f.Name)) {

				if (fi.IsKey)
					datasetmedatdatoKeys += "      <xs:field xpath=\"mstns:" + fi.Name + "\" />\r\n";

				datasetMetadato += "              <xs:element name=\"" + fi.Name.Replace("!", "_x0021_") + "\" type=\"xs:" + GetDatasetType(fi.Type) + "\" ";

				if (fi.Allownull) {
					datasetMetadato += "minOccurs=\"0\" msdata:AllowDBNull=\"true\" />\r\n";
				}
				else {
					datasetMetadato += " msdata:AllowDBNull=\"false\" />\r\n";
				}

			}
			//i campi calcolati su tabelle minimali non servono
			datasetMetadato += minimal ? "" : "              <!--LookupFields " + tableAlias + "-->\r\n";

			datasetmedatdatoKeys += "    </xs:unique>\r\n";
			datasetMetadato += "            </xs:sequence>\r\n          </xs:complexType>\r\n        </xs:element>\r\n;" + (datasetmedatdatoKeys.Contains("field") ? datasetmedatdatoKeys : "");

			return datasetMetadato;

		}

		/// <summary>
		/// restitutisce il tipo da utilizzare nel dataset in base al tipo c# passato come parametro
		/// </summary>
		/// <param name="type">tipo c#</param>
		/// <returns>tipo da utilizzare nel dataset</returns>
		private static string GetDatasetType(string type) {
			var output = "string";

			switch (type) {
				case "uniqueidentifier":
				case "char":
				case "nchar":
				case "nvarchar":
				case "varchar":
				case "ntext":
				case "text": {
					output = "string";
					break;
				}
				case "date":
				case "datetime": {
					output = "dateTime";
					break;
				}
				case "int":
				case "smallint":
				case "bigint":
				case "tinyint": {
					output = "int";
					break;
				}
				case "image":
				case "varbinary": {
					output = "base64Binary";
					break;
				}
				case "float":
				case "decimal": {
					output = "decimal";
					break;
				}
				default: {
					ConsoleWriter.ErrorDB("Tipo sql non mappato nel dataset" + type);
					break;
				}
			}
			return output;

		}

		#endregion

		#region gestione degli oggetti/tabelle/viste/id

		private static field GetParentkey(string table, string listtype, string principalkey, List<field> allfields) {
			return allfields.Where(af => af.Table == table && af.EditListingType == listtype && (af.Name == "par" + principalkey || af.Name == principalkey + "parent")).FirstOrDefault();
		}
		private static bool IsParentkey(field f) {
			return f.Name.StartsWith("parid") || (f.Name.EndsWith("parent") && f.Name.StartsWith("id"));

		}
		private static List<field> GetChildKeysbyMaster(string masterTable, List<field> childFields, List<field> allfields, SqlConnection connection, bool onlyWarning = false) {
			var masterkey = GetPrincipalKey(masterTable, "", allfields, connection, true);

			if (masterkey != null) {
				//cerco la chiave interna o esterna, coincide o concide togliendo un prefisso (viste)
				var childForeignKey = childFields.Where(af => masterkey.Name == af.Name.Split('_')[0] || (af.Name.Contains("_") && masterkey.Name == af.Name.Split('_')[1])).FirstOrDefault();
				if (childForeignKey != null)
					return new List<field>() { masterkey, childForeignKey };
				else {
					var msg = "Non riesco a trovare nella tabella " + childFields.First().Table + " la chiave o chiave esterna corrispondente a " + masterkey.Name + " di " + masterTable;
					if (onlyWarning)
						ConsoleWriter.Warning(msg);
					else
						ConsoleWriter.ErrorDB(msg);
				}

			}
			else
				ConsoleWriter.ErrorDB(childFields.First().Table + " ÃƒÂ¨ in una tendina in cascata con " + masterTable + " ma " + masterTable + " non ha una chiave principale da condividere.");

			return new List<field>();
		}

		/// <summary>
		/// restituisce la foreign key sulla chiave di una subentitÃƒÂ  rispetto alla key del padre
		/// </summary>
		/// <param name="tableParent"></param>
		/// <param name="tableChild"></param>
		/// <param name="editListTypeParent"></param>
		/// <param name="editListTypeChild"></param>
		/// <param name="keysParent"></param>
		/// <param name="allfields"></param>
		/// <param name="connection"></param>
		/// <returns></returns>
		private static string GetChildKeysString(string tableParent, string tableChild, string editListTypeParent, string editListTypeChild, List<string> keysParent, List<field> allfields,
			SqlConnection connection, bool onlywarning = false) {
			var ckString = "";
			var keysChild = GetIdByTable(tableChild, allfields, connection, true, editListTypeChild);
			foreach (var kp in keysParent) {
				//prima cerco se ÃƒÂ¨ la chiave della relazione della paternitÃƒÂ 
				var keyRecoursive = keysChild.Where(k => "par" + kp.Split('_')[0] == k.Split('_')[0]).FirstOrDefault();
				if (keyRecoursive == null)
					//altrimenti se ÃƒÂ¨ parte della relazione e basta
					keyRecoursive = keysChild.Where(k => kp.Split('_')[0] == k.Split('_')[0]).FirstOrDefault();

				if (keyRecoursive != null) {
					ckString += keyRecoursive + " ";
				}
				else {
					var msg = "Non riesco a trovare nella tabella " + tableChild + " la chiave corrispondente a " + kp + " di " + tableParent;
					if (onlywarning) {
						if (verbose)
							ConsoleWriter.Info(msg);
					}
					else
						ConsoleWriter.ErrorDB(msg);

				}
			}
			return ckString;
		}

		/// <summary>
		/// restituisce la foreign key sulle colonne di una subentitÃƒÂ  rispetto alla key del padre
		/// </summary>
		/// <param name="tableParent"></param>
		/// <param name="tableChild"></param>
		/// <param name="editListTypeParent"></param>
		/// <param name="editListTypeChild"></param>
		/// <param name="keysParent"></param>
		/// <param name="allfields"></param>
		/// <param name="connection"></param>
		/// <returns></returns>
		private static string GetChildForeignKeysString(string tableParent, string tableChild, string editListTypeParent, string editListTypeChild, List<string> keysParent, List<field> allfields,
			SqlConnection connection, bool onlywarning = true) {
			var ckString = "";
			var pkString = "";
			var keysChild = GetfiledsByTableEditType(tableChild, editListTypeChild, allfields, connection, true);
			var allParentKeysAreNotInChildColumns = false;
			foreach (var kp in keysParent) {
				field keyRecoursive = null;
				var ex = GetException(tableParent, kp, tableChild, null);
				if (ex != null) {
					keyRecoursive = keysChild.Where(k => k.Name == ex.Item4).FirstOrDefault();
				}
				else {
					//prima cerco se ÃƒÂ¨ la chiave della relazione della paternitÃƒÂ 
					keyRecoursive = keysChild.Where(k => "par" + kp.Split('_')[0] == k.Name.Split('_')[0]).FirstOrDefault();
					if (keyRecoursive == null)
						//altrimenti se ÃƒÂ¨ parte della relazione e basta
						keyRecoursive = keysChild.Where(k => kp.Split('_')[0] == k.Name.Split('_')[0]).FirstOrDefault();
				}

				if (keyRecoursive != null) {
					ckString += keyRecoursive.Name + " ";
					pkString += kp + " ";
				}
				else {
					allParentKeysAreNotInChildColumns = true;
					var msg = "INFO: No riesco a trovare nella tabella " + tableChild + " la chiave corrispondente a " + kp + " di " + tableParent;
					if (onlywarning) {
						if (verbose)
							ConsoleWriter.Info(msg);
					}
					else
						ConsoleWriter.ErrorDB(msg);

				}
			}
			//se non ho trovato una corrispondenza per ogni campo chiave del padre nelle colonne del figlio (anche non chiavi)
			//verifico che non siano da relazionare colonne fk che non sono chiave
			if (allParentKeysAreNotInChildColumns) {
				foreach (var colParent in GetfiledsByTableEditType(tableParent, editListTypeParent, allfields, connection, true)
					.Where(cp => !cp.IsKey && HaveKeyName(cp))) {
					var colChild = keysChild.Where(k => colParent.Name.Split('_')[0] == k.Name.Split('_')[0] &&
												!ckString.Split(' ').ToList().Any(ck => ck == k.Name)).FirstOrDefault();
					if (colChild != null) {
						ckString += colChild.Name + " ";
						pkString += colParent.Name + " ";
						if (verbose)
							Console.WriteLine("INFO: aggiungo anche le colonne " + tableParent + "." + colParent.Name + "=" + tableChild + "." + colChild.Name +
								" alla relazione perchÃƒÂ© non tutte le chiavi del padre (" + tableParent + ") sono contenute nel figlio (" + tableChild + ")");

					}

				}
			}
			return ckString + ";" + pkString;
		}

		/// <summary>
		/// determina se una tabella ÃƒÂ¨ di collegamento
		/// deve essere composta esclusivamente dai campi di log e piÃƒÂ¹ di una chiave
		/// </summary>
		/// <param name="table"></param>
		/// <param name="allfields"></param>
		/// <param name="connection"></param>
		/// <returns></returns>
		private static bool IsLinkingObject(string table, ref List<field> allfields, SqlConnection connection) {

			if (table.Contains("_alias"))
				table = table.Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[0];

			GetMissingFields(table, null, ref allfields, connection);
			var ft = GetDatasetFields(table, allfields).Where(af => af.Table == table && af.Name != "ct" && af.Name != "cu" && af.Name != "lt" && af.Name != "lu").ToList();
			return ft.All(f => f.IsKey) && ft.Count() > 1;
		}

		/// <summary>
		/// Serve a reperire i campi della tabella collegata da una tabella di collegamento
		/// </summary>
		/// <param name="linkingtable">tabella di colegamento</param>
		/// <param name="linkingeditlisttype">editlisttype indicato</param>
		/// <param name="allfields">tutti i campi</param>
		/// <param name="connection">connessione</param>
		/// <returns>i campi della tabella collegata</returns>
		private static List<field> GetLinkingObjectFields(string linkingtable, string linkingeditlisttype, ref List<field> allfields, SqlConnection connection) {

			var linkingobjectfields = new List<field>();

			//tolgo l'eventuale alias
			if (linkingtable.Contains("_alias"))
				linkingtable = linkingtable.Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[0];

			//ricavo l'id che punta alla collegata (di solito cambia in base all'edit type)
			var linkingids = allfields.Where(af => af.Table == linkingtable && af.EditListingType == linkingeditlisttype && (af.IsKey || af.IsLinkingObj) && af.ListVisible).OrderByDescending(af => af.IsLinkingObj);

			if (linkingids.Any()) {
				foreach (var linkingid in linkingids) {
					//ricavo il nome della tabella collegata
					var linkedtable = "";
					var ex = GetException(null, null, linkingtable, linkingid.Name);
					if (ex != null) {
						linkedtable = ex.Item1;
					}
					else {
						linkedtable = GetTableById(linkingid.Name, allfields, connection);
					}
					GetMissingFields(linkedtable, null, ref allfields, connection);

					//controllo che non indichi un list type specifico, altrimenti uso quello del padre o quello di default
					var linkededitlisttype = linkingeditlisttype;
					if (!string.IsNullOrEmpty(linkingid.Listtype))
						linkededitlisttype = linkingid.Listtype;
					if (!allfields.Any(af => af.Table == linkedtable && af.EditListingType == linkededitlisttype))
						linkededitlisttype = "default";

					linkingobjectfields.AddRange(allfields.Where(af => af.Table == linkedtable && af.EditListingType == linkededitlisttype));
					if (linkedtable.Contains("_")) {
						var extendedobject = linkedtable.Split('_')[0];
						GetMissingFields(extendedobject, null, ref allfields, connection);
						var extendedlisttype = linkedtable.Split('_')[1] + (linkededitlisttype == "default" ? "" : "_" + linkededitlisttype);
						var extendedfields = allfields.Where(af => af.Table == extendedobject && af.EditListingType == extendedlisttype).ToList();
						ConsoleWriter.WarningDB("L'elemento collegato dall'oggetto di collegamento " + linkingtable + " " + linkingeditlisttype + " che ÃƒÂ¨ " + linkedtable + " " + linkededitlisttype +
							" ÃƒÂ¨ un oggetto estendente, quindi sono stati aggiunti ai campi calcolati anche i campi dell'oggetto " + linkedtable.Split('_')[0] + " " + linkedtable.Split('_')[1]);
						linkingobjectfields.AddRange(extendedfields);
					}
				}
			}
			else
				ConsoleWriter.ErrorDB("L'elemento collegato dall'oggetto di collegamento " + linkingtable + " " + linkingeditlisttype + " non ÃƒÂ¨ individuabile, verificare la visibilitÃƒÂ  nella lista di almeno uno dei campi");
			return linkingobjectfields;
		}

		/// <summary>
		/// Verifica se un oggetto ÃƒÂ¨ una tabella estendente oppure no
		/// </summary>
		/// <param name="table">oggetto</param>
		/// <param name="allfields">tutti i campi scaricati</param>
		/// <param name="connection">connessione</param>
		/// <returns>si/no</returns>
		private static bool IsExtendingObject(string table, ref List<field> allfields, SqlConnection connection) {
			var output = false;
			//prima tolgo l'alias
			table = table.Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[0];
			//poi controllo che sia rimasto un _
			if (table.Contains("_")) {
				var extendedObject = table.Split('_')[0];
				GetMissingFields(extendedObject, null, ref allfields, connection);
				//verifico che non si tratti in realtÃƒÂ  di una tabella di collegamento con un oggetto esteso:
				//se adesso che ho appena cercato di aggiungere i campi dell'oggetto esteso non li ho trovati sul db allora vuol dire che la tabella non esiste, 
				//perchÃƒÂ¨ ÃƒÂ¨ in realtÃƒÂ  una tabella di collegamneto (in cui la tabella estendente ÃƒÂ¨ sempre nella parte destra del nome)
				if (allfields.Any(af => af.Table == extendedObject)) {
					output = true;
				}
				else {
					extendedObject = "";
					if (verbose)
						Console.WriteLine("INFO: la tabella " + table + " contiene _ ma ÃƒÂ¨ solo una tabella di collegamento ad una estendente");
				}
			}
			return output;
		}

		/// <summary>
		/// Restituisce l'oggetto esteso se gli viene passato un oggetto estendente
		/// </summary>
		/// <param name="table">oggetto estendente</param>
		/// <param name="allfields">tutti i campi</param>
		/// <param name="connection">connessione</param>
		/// <param name="getmissing">verifica di aver caricato i campi dal db (default ÃƒÂ¨ true)</param>
		/// <param name=""></param>
		/// <returns></returns>
		private static string GetExtendedObject(string table, ref List<field> allfields, SqlConnection connection, bool getmissing = true) {
			string extendedObject = null;
			//prima tolgo l'alias
			table = table.Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[0];
			//poi controllo che sia rimasto un _
			if (table.Contains("_")) {
				extendedObject = table.Split('_')[0];
				if (getmissing)
					GetMissingFields(extendedObject, null, ref allfields, connection);
				//verifico che non si tratti in realtÃƒÂ  di una tabella di collegamento con un oggetto esteso:
				//se adesso che ho appena cercato di aggiungere i campi dell'oggetto esteso non li ho trovati sul db allora vuol dire che la tabella non esiste, 
				//perchÃƒÂ¨ ÃƒÂ¨ in realtÃƒÂ  una tabella di collegamneto (in cui la tabella estendente ÃƒÂ¨ sempre nella parte destra del nome)
				if (allfields.Any(af => af.Table == extendedObject)) {
				}
				else {
					extendedObject = null;
					if (verbose)
						Console.WriteLine("INFO: la tabella " + table + " contiene _ ma ÃƒÂ¨ solo una tabella di collegamento ad una estendente");
				}
			}
			return extendedObject;
		}

		/// <summary>
		/// Elenco delle eccezioni, si puÃƒÂ² passare la tabella, la chiave oppure la coppia tabella con foreign key e foreign key
		/// restituisce una tupla con le informazioni sulla tabella o sulle relazionioni
		/// </summary>
		/// <param name="table">tabella</param>
		/// <param name="key">chiave</param>
		/// <param name="linkedTable">tabella con foreign key</param>
		/// <param name="linkedcolumn">foreign key</param>
		/// <returns>tabella, chiave, tabella con foreign key,foreign key, ÃƒÂ¨ una vera chiave?, ÃƒÂ¨ un oggetto esteso?</returns>
		private static Tuple<string, string, string, string, bool, bool> GetException(string table, string key, string linkedTable, string linkedcolumn) {
			/* var exceptions = new List<Tuple<string, string, string, string, bool, bool>>();
			//GetIdByForeignKey
			exceptions.Add(Tuple.Create("residence", "idresidence", "registry", "residence", true, false));
			exceptions.Add(Tuple.Create("menuweb", "idmenuweb", "menuweb", "idmenuwebparent", true, false));
			exceptions.Add(Tuple.Create("geo_city", "idcity", "geo_city", "newcity", true, false));
			exceptions.Add(Tuple.Create("geo_city", "idcity", "geo_city", "oldcity", true, false));
			exceptions.Add(Tuple.Create("geo_country", "idcountry", "geo_country", "newcountry", true, false));
			exceptions.Add(Tuple.Create("geo_country", "idcountry", "geo_country", "oldcountry", true, false));
			exceptions.Add(Tuple.Create("geo_region", "idregion", "geo_region", "newregion", true, false));
			exceptions.Add(Tuple.Create("geo_region", "idregion", "geo_region", "oldregion", true, false));
			exceptions.Add(Tuple.Create("geo_nation", "idnation", "geo_nation", "newnation", true, false));
			exceptions.Add(Tuple.Create("geo_nation", "idnation", "geo_nation", "oldnation", true, false));
			exceptions.Add(Tuple.Create("address", "idaddress", "registryaddress", "idaddresskind", true, false));
			exceptions.Add(Tuple.Create("annoaccademico", "aa", "tassaiscrizioneconf", "aamax", true, false));
			exceptions.Add(Tuple.Create("annoaccademico", "aa", "tassaiscrizioneconf", "aamin", true, false));
			exceptions.Add(Tuple.Create("assetacquire", "nassetacquire", "asset", "nassetacquire", true, false));
			exceptions.Add(Tuple.Create("asset", "idasset idpiece", "progettoasset", "idpiece", true, false));
			exceptions.Add(Tuple.Create("asset", "idasset idpiece", "assetdiary", "idpiece", true, false));
			exceptions.Add(Tuple.Create("getregistrydocentiamministrativi", "idreg", "progettoudrmembro", "idreg", true, false));
			exceptions.Add(Tuple.Create("getregistrydocentiamministrativi", "idreg", "rendicontattivitaprogetto", "idreg", true, false));
			exceptions.Add(Tuple.Create("getregistrydocentiamministrativi", "idreg", "rendicontattivitaprogetto", "idreg", true, false));
			exceptions.Add(Tuple.Create("getregistrydocentiamministrativi", "idreg", "assetdiary", "idreg", true, false));
			exceptions.Add(Tuple.Create("getregistrydocentiamministrativi", "idreg", "progetto", "idreg", true, false));
			exceptions.Add(Tuple.Create("accmotive", "idaccmotive", "inventorytree", "idaccmotiveload", true, false));
			exceptions.Add(Tuple.Create("inventorykind", "idinventorykind", "assetacquire", "idinvkind", true, false));
			exceptions.Add(Tuple.Create("asset", "idasset idpiece", "progettoasset", "idpiece", true, false));
			//exceptions.Add(Tuple.Create("appages", "tablename editlistingtype", "apppagesdetail", "listtype", true, false));

			//falsi id
			exceptions.Add(Tuple.Create("", "idexternal", "", "", false, false));
			exceptions.Add(Tuple.Create("", "idsedemiur", "", "", false, false));
			exceptions.Add(Tuple.Create("", "idistitutoustat", "", "", false, false));
			exceptions.Add(Tuple.Create("", "idsor_economicbudget", "", "", false, false));
			exceptions.Add(Tuple.Create("", "idsor_investmentbudget", "", "", false, false));
			exceptions.Add(Tuple.Create("", "idaccmotivediscount", "", "", false, false));
			exceptions.Add(Tuple.Create("", "idaccmotivetransfer", "", "", false, false));
			exceptions.Add(Tuple.Create("", "idaccmotiveunload", "", "", false, false));
			exceptions.Add(Tuple.Create("", "idcurrlocation", "", "", false, false));
			exceptions.Add(Tuple.Create("", "idcurrman", "", "", false, false));
			exceptions.Add(Tuple.Create("", "idcurrsubman", "", "", false, false));
			exceptions.Add(Tuple.Create("", "idaccmotivedebit", "", "", false, false));
			exceptions.Add(Tuple.Create("", "idaccmotivedebit_crg", "", "", false, false));
			exceptions.Add(Tuple.Create("", "idaccmotivedebit_datacrg", "", "", false, false));
			exceptions.Add(Tuple.Create("", "iddalia_dipartimento", "", "", false, false));
			exceptions.Add(Tuple.Create("", "iddalia_funzionale", "", "", false, false));
			exceptions.Add(Tuple.Create("", "iddaliaposition", "", "", false, false));
			exceptions.Add(Tuple.Create("", "iddaliarecruitmentmotive", "", "", false, false));
			exceptions.Add(Tuple.Create("", "idser", "", "", false, false));
			exceptions.Add(Tuple.Create("", "idsor", "", "", false, false));
			exceptions.Add(Tuple.Create("", "idsor_siope", "", "", false, false));
			exceptions.Add(Tuple.Create("", "idsor1", "", "", false, false));
			exceptions.Add(Tuple.Create("", "idsor2", "", "", false, false));
			exceptions.Add(Tuple.Create("", "idsor3", "", "", false, false));
			exceptions.Add(Tuple.Create("", "idformerexpense", "", "", false, false));
			exceptions.Add(Tuple.Create("", "idinc", "", "", false, false));
			exceptions.Add(Tuple.Create("", "idpayment", "", "", false, false));
			exceptions.Add(Tuple.Create("", "idinc_linked", "", "", false, false));
			exceptions.Add(Tuple.Create("", "idmankind", "", "", false, false));
			exceptions.Add(Tuple.Create("", "idmot", "", "", false, false));

			//GetTableById
			exceptions.Add(Tuple.Create("annoaccademico", "aa", "", "", true, false));
			exceptions.Add(Tuple.Create("annoaccademico", "aa_start", "", "", true, false));
			exceptions.Add(Tuple.Create("annoaccademico", "aa_stop", "", "", true, false));
			exceptions.Add(Tuple.Create("annoaccademico", "aamax", "", "", true, false));
			exceptions.Add(Tuple.Create("annoaccademico", "aamin", "", "", true, false));
			exceptions.Add(Tuple.Create("residence", "residence", "", "", true, false));
			exceptions.Add(Tuple.Create("menuweb", "idmenuwebparent", "", "", true, false));
			exceptions.Add(Tuple.Create("registry_istituti", "idreg_istituti", "", "", true, true));
			exceptions.Add(Tuple.Create("registry_istitutiesteri", "idreg_istitutiesteri", "", "", true, true));
			exceptions.Add(Tuple.Create("registry_aziende", "idreg_aziende", "", "", true, true));
			exceptions.Add(Tuple.Create("registry_studenti", "idreg_studenti", "", "", true, true));
			exceptions.Add(Tuple.Create("registry_docenti", "idreg_docenti", "", "", true, true));
			exceptions.Add(Tuple.Create("registry_user", "idreg_user", "", "", true, true));
			exceptions.Add(Tuple.Create("registry_amministrativi", "idreg_amministrativi", "", "", true, true));
			exceptions.Add(Tuple.Create("registry_militari", "idreg_militari", "", "", true, true));
			exceptions.Add(Tuple.Create("registry", "idreg", "", "", true, false));
			exceptions.Add(Tuple.Create("geo_city", "idcity", "", "", true, false));
			exceptions.Add(Tuple.Create("geo_continent", "idcontinent", "", "", true, false));
			exceptions.Add(Tuple.Create("geo_country", "idcountry", "", "", true, false));
			exceptions.Add(Tuple.Create("geo_region", "idregion", "", "", true, false));
			exceptions.Add(Tuple.Create("geo_nation", "idnation", "", "", true, false));
			exceptions.Add(Tuple.Create("geo_city", "newcity", "", "", true, false));
			exceptions.Add(Tuple.Create("geo_city", "oldcity", "", "", true, false));
			exceptions.Add(Tuple.Create("geo_country", "newcountry", "", "", true, false));
			exceptions.Add(Tuple.Create("geo_country", "oldcountry", "", "", true, false));
			exceptions.Add(Tuple.Create("geo_region", "newregion", "", "", true, false));
			exceptions.Add(Tuple.Create("geo_region", "oldregion", "", "", true, false));
			exceptions.Add(Tuple.Create("geo_nation", "newnation", "", "", true, false));
			exceptions.Add(Tuple.Create("geo_nation", "oldnation", "", "", true, false));
			exceptions.Add(Tuple.Create("address", "idaddresskind", "", "", true, false));
			exceptions.Add(Tuple.Create("itinerationlap", "lapnumber", "", "", true, false));
			exceptions.Add(Tuple.Create("itinerationrefund", "nrefund", "", "", true, false));
			exceptions.Add(Tuple.Create("protocollo", "protnumero protanno", "", "", true, false));
			exceptions.Add(Tuple.Create("registryaddress", "idreg start" /*idaddresskind"*//*, "", "", true, false));
			exceptions.Add(Tuple.Create("account", "idacc", "", "", true, false));
			exceptions.Add(Tuple.Create("asset", "idasset idpiece", "", "", true, false));
			exceptions.Add(Tuple.Create("inventorytree", "idinv", "", "", true, false));
			exceptions.Add(Tuple.Create("tax", "taxcode", "", "", true, false));
			exceptions.Add(Tuple.Create("entrydetail", "idrelated", "", "", true, false));
			exceptions.Add(Tuple.Create("expense", "idexp", "", "", true, false));
			exceptions.Add(Tuple.Create("assetacquire", "nassetacquire", "", "", true, false));
			exceptions.Add(Tuple.Create("accmotive", "idaccmotiveload", "", "", true, false));
			exceptions.Add(Tuple.Create("sorting", "idsor", "", "", true, false));
			exceptions.Add(Tuple.Create("sortingkind", "idsorkind", "", "", true, false));
			exceptions.Add(Tuple.Create("getsorting", "getsorting", "", "", true, false));
			//exceptions.Add(Tuple.Create("diderog", "aa idcorsostudio idsede", "", "", true, false)); NON METTERE! */

			return exceptions.Where(ex =>
			//IsExtending o IsPrincipalKey
			(ex.Item1 == table && key == null && linkedTable == null && linkedcolumn == null) ||
			//isInternalAndExternalKey
			(ex.Item1 == table && ex.Item2 == key && linkedTable == null && linkedcolumn == null) ||
			//getTablebyId
			(ex.Item2 == key && table == null && linkedTable == null && ex.Item3 == "" && linkedcolumn == null && ex.Item4 == "") ||
			//ForeignKeyExceptions dalla fk ricavo tabella e id della tabella padre
			(ex.Item3 == linkedTable && ex.Item4 == linkedcolumn && table == null && key == null) ||
			//ForeignKeyExceptions dalla tabella padre, l'id e la tabella figlia ricavo la fk
			(ex.Item1 == table && ex.Item2 == key && ex.Item3 == linkedTable && table != null && key != null && linkedTable != null && linkedcolumn == null)
			).FirstOrDefault();
		}

		/// <summary>
		/// Restituisce la tabella della chiave passata come parametro
		/// </summary>
		/// <param name="id">l'indice</param>
		/// <param name="allfields">i campi del db</param>
		/// <returns>la tabella</returns>
		private static string GetTableById(string id, List<field> allfields, SqlConnection connection, string linkingObject = null) {

			//casi non standard
			//tolgo prima l'eventuale suffisso alle chiavi di oggetti estesi
			var ids = id.Split('_');
			if (ids.Count() > 2)
				id = ids[0] + "_" + ids[1];
			var ex = GetException(null, id, null, null);
			if (ex != null) {
				//controllo che non sia un falso id
				if (!ex.Item5) {
					ConsoleWriter.ErrorDB("E' stata cercata la tabella per la colonna che sembra una chiave " + id);
					return "";
				}
				GetMissingFields(ex.Item1, null, ref allfields, connection);
				return ex.Item1;
			}

			//casi di riferimento a se stesso come padre
			if (id.StartsWith("parid"))
				id = id.Substring(3, id.Length - 3);

			//il naming standard prevede che:
			if (id.IndexOf('_') != -1) {
				var output = id.Substring(2);
				if (!allfields.Any(af => af.Table == output))
					GetMissingFields(output, null, ref allfields, connection);

				//1- se io debba riferirmi ad una chiave di un oggetto estendente (quando ÃƒÂ¨ il collegamento con l'oggetto padre non serve)
				//devo averla inserita come se avesse la propria chiave (id+estendente) e non quella dell'esteso (id+esteso)
				if (allfields.Any(af => af.Table == output))
					return output;

				//2- se io debba riferirmi piÃƒÂ¹ volte alla stessa chiave nella stessa tabella, io possa accodare _xxx alla chiave
				id = id.Substring(0, id.IndexOf('_'));
				if (verbose)
					Console.WriteLine("INFO: Riprovo ripartendo dall'indice " + id + ".");
			}

			//verifico che i campi siano giÃƒÂ  stati caricati dal db altrimento lo faccio ora 
			//(se avessi avuto solo quella di collegamento adesso avrei anche la tabella collegata)
			GetMissingFields(null, id, ref allfields, connection);

			//prendo tutte le tabelle con quella chiave
			var allOutput = allfields.Where(af => af.IsKey && af.Name == id);//.Select(af => af.Table);

			if (allOutput.Any()) {
				var output = "";
				var outputs = new List<string>();

				foreach (var o in allOutput) {
					if (IsPrincipalKey(o, o.Table))
						outputs.Add(o.Table);
				}

				//se ho passato una tabella di collegamento ...
				if (linkingObject != null) {
					//... scelgo la tabella il cui nome ÃƒÂ¨ in quella di collegamento ed ÃƒÂ¨ piÃƒÂ¹ lungo (estendente)
					output = outputs.Where(o => linkingObject.Contains(o)).OrderBy(o => o.Length).LastOrDefault();
				}
				else
					//...altrimenti scelgo la tabella col nome piÃƒÂ¹ corto (esteso)
					output = outputs.OrderBy(o => o.Length).FirstOrDefault();

				if (!string.IsNullOrEmpty(output))
					return output;
				else {
					ConsoleWriter.ErrorDB("Tabella non trovata per la chiave " + id);
					return "";
				}

			}
			else {
				ConsoleWriter.ErrorDB("Tabella non trovata per la chiave " + id);
				return "";
			}
		}

		/// <summary>
		/// Restituisce il list type della interfaccia puntata dalla Foreign Key
		/// </summary>
		/// <param name="id"></param>
		/// <param name="allfields"></param>
		/// <param name="connection"></param>
		/// <returns></returns>
		private static string GetEditTypeById(field id, List<field> allfields, SqlConnection connection) {
			var editListTypeField = string.IsNullOrEmpty(id.Listtype) ? "default" : id.Listtype;
			if (editListTypeField == "default" && id.Name.Contains("_") && !id.Name.StartsWith("XX")) {
				//prendo la seconda stringa dopo _ se ÃƒÂ¨ una sola altrimenti prendo la terza ma provo comunque tutte e due
				var possibleListType = new List<string>();
				if (id.Name.Split('_').Count() > 2) {
					//possibleListType.Add(id.Name.Split('_')[1] + "_" + id.Name.Split('_')[2]);
					possibleListType.Add(id.Name.Split('_')[2]);
				}
				possibleListType.Add(id.Name.Split('_')[1]);

				var table = GetTableById(id.Name, allfields, connection);
				//se alla GetTableById viene passato un id di un estendente (idesteso_listtypeesteso) restituisce la tabella estendente, 
				//che non avrÃƒÂ  MAI il list type dell'esteso, quindi in quel caso devo recuperare la tabella dell'esteso
				if (IsExtendingObject(table, ref allfields, connection))
					table = table.Split('_')[0];

				foreach (var plt in possibleListType)
					if (allfields.Any(af => af.Table == table && af.EditListingType == plt))
						return plt;
			}
			return editListTypeField;
		}

		/// <summary>
		/// Restituisce i nomi degli indici della tabella passata come parametro
		/// </summary>
		/// <param name="table">tabella</param>
		/// <param name="allfields">campi del db</param>
		/// <returns>gli indici</returns>
		private static List<string> GetIdByTable(string table, List<field> allfields, SqlConnection connection, bool checkmissing = true, string edittype = null) {

			table = table.Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[0];

			//verifico che i campi siano giÃƒÂ  stati caricati dal db altrimento lo faccio ora
			if (checkmissing)
				GetMissingFields(table, null, ref allfields, connection);

			var tablefields = new List<field>();
			if (!string.IsNullOrWhiteSpace(edittype))
				tablefields = allfields.Where(af => af.Table == table && af.EditListingType == (IsView(table) ? "default" : edittype)).ToList();
			else
				tablefields = GetDatasetFields(table, allfields);

			var output = tablefields.Where(af => af.IsKey || (IsView(table) && HaveKeyName(af))).OrderBy(x => x.Name).Select(af => af.Name).ToList();
			if (output.Any())
				return output;
			else {
				var ex = GetException(table, null, null, null);
				if (ex != null) {
					//controllo che non sia un falso id
					if (!ex.Item5) {
						ConsoleWriter.ErrorDB("E' stata restituita la falsa chiave " + ex.Item2 + " per la tabella " + table);
						return new List<string>();
					}
					return ex.Item2.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
				}

				ConsoleWriter.ErrorDB("Chiave non trovata per la tabella " + table);
				return new List<string>();
			}

		}

		/// <summary>
		/// Restituisce i campi di una interfaccia
		/// </summary>
		/// <param name="table"></param>
		/// <param name="edittype"></param>
		/// <param name="allfields"></param>
		/// <param name="connection"></param>
		/// <param name="checkmissing"></param>
		/// <returns></returns>
		private static List<field> GetfiledsByTableEditType(string table, string edittype, List<field> allfields, SqlConnection connection = null, bool checkmissing = false) {
			table = table.Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[0];

			//verifico che i campi siano giÃƒÂ  stati caricati dal db altrimento lo faccio ora
			if (checkmissing)
				GetMissingFields(table, null, ref allfields, connection);

			var output = new List<field>();
			if (!string.IsNullOrWhiteSpace(edittype))
				output = allfields.Where(af => af.Table == table && af.EditListingType == (IsView(table) ? "default" : edittype)).ToList();
			else
				output = GetDatasetFields(table, allfields);

			if (!output.Any())
				ConsoleWriter.ErrorDB("Campi non trovati per l'interfaccia " + table + " " + edittype);

			return output;
		}

		private static string GetSchemaByTable(string table, List<field> allfields, SqlConnection connection, bool checkmissing = true) {

			//verifico che i campi siano giÃƒÂ  stati caricati dal db altrimento lo faccio ora
			if (checkmissing)
				GetMissingFields(table, null, ref allfields, connection);


			var output = allfields.Where(af => af.Table == table && af.IsKey).OrderBy(x => x.Name).Select(af => af.Schema).FirstOrDefault();
			if (output != null) {
				if (output != "dbo")
					return "";// output; NOTA BENE: per le tabelle/viste non DBO no si indica nulla nelle viste
				else
					return "dbo";
			}
			else {
				ConsoleWriter.ErrorDB("Schema non trovato per la tabella " + table);
				return "";
			}

		}

		/// <summary>
		/// Restituisce gli indici della tabella passata come parametro
		/// </summary>
		/// <param name="table">tabella</param>
		/// <param name="allfields">campi del db</param>
		/// <returns>gli indici</returns>
		private static List<field> GetIdFieldsByTable(string table, List<field> allfields, SqlConnection connection, bool checkmissing = true, string edittype = null) {

			table = table.Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[0];

			//verifico che i campi siano giÃƒÂ  stati caricati dal db altrimento lo faccio ora
			if (checkmissing)
				GetMissingFields(table, null, ref allfields, connection);

			var tablefields = new List<field>();
			if (!string.IsNullOrWhiteSpace(edittype)) {
				tablefields = allfields.Where(af => af.Table == table && af.EditListingType == edittype).ToList();
				if (!tablefields.Any())
					//paracadute nel caso che abbia sbagliato l'edit type
					tablefields = GetDatasetFields(table, allfields);
			}
			else
				tablefields = GetDatasetFields(table, allfields);

			var output = tablefields.Where(af => af.IsKey).OrderBy(x => x.Name.Length).ToList();
			if (output.Any())
				return output;
			else {
				var ex = GetException(table, null, null, null);
				if (ex != null) {
					//controllo che non sia un falso id
					if (!ex.Item5) {
						ConsoleWriter.ErrorDB("E' stata restituita la falsa chiave " + ex.Item2 + " per la tabella " + table);
						return new List<field>();
					}
					var exFields = ex.Item2.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
					return tablefields.Where(af => exFields.Contains(af.Name)).OrderBy(x => x.Name.Length).ToList();
				}

				ConsoleWriter.ErrorDB("Chiave non trovata per la tabella " + table);
				return new List<field>();
			}

		}

		/// <summary>
		/// Restituisce true se si tratta della chiave principale (non quelle derivati dalle entitÃƒÂ  padri) dell'oggetto
		/// </summary>
		/// <param name="f">Campo da esaminare</param>
		/// <param name="table">tabella di cui potrebbe essere chiave</param>
		/// <param name="isView">indica se la tabella in esame ÃƒÂ¨ una vista</param>
		/// <returns></returns>
		private static bool IsPrincipalKey(field f, string table, bool isView = false) {
			if ((f.IsKey || isView) && f.Name.Substring(2) == table.Split('_')[0])
				return true;
			var ex = GetException(table, null, null, null);
			if (ex != null)
				if ((f.IsKey || isView) && (f.Name == ex.Item2.Split('_')[0] || ex.Item2.Split(' ').Contains(f.Name)))
					return true;
			return false;
		}

		/// <summary>
		/// restituisce true se i campi passati sono relative a vere subentitÃƒÂ  ovvero tutta la chiave del padre ÃƒÂ¨ contenuta nella chiave del figlio
		/// </summary>
		/// <param name="parentKey"></param>
		/// <param name="childFieds"></param>
		/// <returns></returns>
		private static bool isSubentity(List<string> parentKey, List<field> childFieds) {
			foreach (var pk in parentKey) {
				if (!childFieds.Any(f => f.IsKey && (f.Name.Split('_')[0] == pk || f.Name == pk)))
					return false;
			}
			return true;
		}

		/// <summary>
		/// Restituisce il nome della tabella a partire dalla vista
		/// </summary>
		/// <param name="tablename"></param>
		/// <param name="editListingType"></param>
		/// <param name="allfields"></param>
		/// <param name=""></param>
		/// <returns></returns>
		private static string GetOriginalTableByView(string tablename, string editListingType, List<field> allfields) {
			var originalTable = "";
			var realeditListingType = string.IsNullOrWhiteSpace(editListingType) ? "default" : editListingType;
			if (allfields.Any(af => af.Table == tablename.Replace(realeditListingType + "view", "") && !IsView(af.Table)))
				originalTable = tablename.Replace(realeditListingType + "view", "");
			else
				if (allfields.Any(af => af.Table.Replace("_", "") == tablename.Replace("view", "") && !IsView(af.Table)))
				originalTable = allfields.Where(af => af.Table.Replace("_", "") == tablename.Replace("view", "")).Select(af => af.Table).FirstOrDefault();

			//se non l'ho ancora trovato provo al contrario a creare tutte le viste possibili e vedere se una corrisponde
			if (string.IsNullOrWhiteSpace(originalTable))
				if (allfields.Any(af => af.Table + (af.EditListingType == "default" ? "" : af.EditListingType) + "view" == tablename))
					originalTable = allfields.Where(af => af.Table + (af.EditListingType == "default" ? "" : af.EditListingType) + "view" == tablename).Select(af => af.Table).FirstOrDefault();

			if (string.IsNullOrWhiteSpace(originalTable) && verbose)
				Console.WriteLine("WARING: Non trovo la tabella originale per la vista " + tablename);
			return originalTable;
		}


		//restituisce true se si tratta di un enum ovvero chiave e title coincidono
		private static bool IsEnum(field f, List<field> allfields, SqlConnection connection) {
			if (f.Name.StartsWith("aa"))
				return true;

			if (HaveKeyName(f)) {
				var table = GetTableById(f.Name, allfields, connection);
				var title = allfields.Where(af => af.Table == table && af.Name == "title").FirstOrDefault();
				if (title != null) {
					if (f.Type == title.Type && f.Len == title.Len)
						return true;
				}
				else {
					var tableColumn = GetDatasetFields(table, allfields);
					//tabelle monocolonna
					if (tableColumn.Count() == 1)
						return true;
				}
			}

			return false;
		}

		//restituisce true se si tratta di un enum ovvero chiave e title coincidono
		private static bool IsEnum(string table, List<field> allfields) {//, SqlConnection connection) {

			//var title = allfields.Where(af => af.Table == table && af.Name == "title").FirstOrDefault();
			//if (title != null) {
			//	if (f.Type == title.Type && f.Len == title.Len)
			//		return true;
			//}
			//else {
			var tableColumn = GetDatasetFields(table, allfields);
			//tabelle monocolonna
			if (tableColumn.Count() == 1)
				return true;
			//}

			return false;
		}

		//restituisce true se il campo ÃƒÂ¨ una textarea
		private static bool IsTextArea(field f) {
			return (f.Type == "ntext" || f.Type == "text" || (f.Type == "nvarchar" && f.Len == -1) || (f.Type == "varchar" && f.Len == -1) || f.Textarea);
		}

		//restituisce true se il campo ÃƒÂ¨ una campo testo
		private static bool IsTextField(field f) {
			return (new List<string>() { "char", "nchar", "nvarchar", "varchar", "text", "ntext" }).Contains(f.Type);
		}

		/// <summary>
		/// Restituisce la chiave principale per una tabella e un edit type
		/// </summary>
		/// <param name="table"></param>
		/// <param name="edittype">se in bianco mi va bene una qualunque</param>
		/// <param name="allfields"></param>
		/// <param name="connection"></param>
		/// <param name="checkmissing"></param>
		/// <returns>la chiave principale</returns>
		private static field GetPrincipalKey(string table, string edittype, List<field> allfields, SqlConnection connection, bool checkmissing = true) {

			var realtable = RemoveAlias(table);
			string tableOfView = null;
			var isView = IsView(realtable);

			if (isView)
				tableOfView = GetOriginalTableByView(realtable, edittype, allfields);

			if (checkmissing)
				GetMissingFields(realtable, null, ref allfields, connection, true);

			var keys = string.IsNullOrWhiteSpace(edittype) ?
				allfields.Where(f => (f.IsKey || isView) && f.Table == realtable) :
				allfields.Where(f => (f.IsKey || isView) && f.Table == realtable && f.EditListingType == edittype);

			foreach (var key in keys)
				if (IsPrincipalKey(key, string.IsNullOrWhiteSpace(tableOfView) ? realtable : tableOfView, isView))
					return key;

			if (!IsLinkingObject(realtable, ref allfields, connection)) {
				var ex = GetException(table, null, null, null);
				if (ex != null) {
					return string.IsNullOrWhiteSpace(edittype) ?
						allfields.Where(f => ex.Item2.Split(' ').Any(ek => ek == f.Name) && f.Table == realtable).First() :
						allfields.Where(f => ex.Item2.Split(' ').Any(ek => ek == f.Name) && f.Table == realtable && f.EditListingType == edittype).First();
				}

				if (GetfiledsByTableEditType(realtable, edittype, allfields).Any(x => x.IsLinkingObj))
					ConsoleWriter.Info("Chiave principale non trovata per la tabella " + table + " e l'edit type " + edittype);
				else
					ConsoleWriter.ErrorDB("Chiave principale non trovata per la tabella " + table + " e l'edit type " + edittype);

			}

			if (keys.Any())
				return keys.First();
			else {
				ConsoleWriter.ErrorDB("Nessuna chiave trovata per la tabella " + table + " e l'edit type " + edittype);
				return null;
			}

		}

		private static string RemoveAlias(string tablealias) {
			return tablealias.Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[0];
		}

		private static string GetAlias(string tablealias) {
			return tablealias.Contains("_alias") ? tablealias.Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[1] : "";
		}

		/// <summary>
		/// Restituisce i campi che verranno mostrati nella griglia
		/// </summary>
		/// <param name="table"></param>
		/// <param name="allfields"></param>
		/// <param name="connection"></param>
		/// <param name="getmissing"></param>
		/// <param name="listtype"></param>
		/// <returns></returns>
		private static List<field> GetGridFieldByTable(string table, List<field> allfields, SqlConnection connection, bool getmissing = true, string listtype = "default") {

			if (string.IsNullOrEmpty(listtype))
				listtype = "default";

			if (getmissing)
				//verifico che i campi siano giÃƒÂ  stati caricati dal db altrimento lo faccio ora
				GetMissingFields(table, null, ref allfields, connection);

			return GetFields(table, listtype, ref allfields).Where(x => x.ListVisible).ToList();
		}

		/// <summary>
		/// Resituisce i campi testuali da mostrare nelle combo o nelle autochoose
		/// </summary>
		/// <param name="table">tabella</param>
		/// <param name="allfields">campi del db, se gli passo un subset non devo MAI mettere getmissing = false</param>
		/// <param name="getmissing">verifica che i dati siano stati caricati dal db</param>
		/// <returns></returns>
		private static List<field> GetTextFieldByTable(string table, List<field> allfields, SqlConnection connection, bool getmissing = true, string listtype = "default") {

			table = RemoveAlias(table);

			if (string.IsNullOrEmpty(listtype))
				listtype = "default";

			//il naming standard prevede che se c'ÃƒÂ¨ un _ allora table ÃƒÂ¨ un oggetto derivato, quindi il text field ÃƒÂ¨ sul padre
			var originaltable = table;
			if (table.IndexOf('_') != -1) {
				var isExtendingObject = true;
				var ex = GetException(table, null, null, null);
				if (ex != null)
					isExtendingObject = ex.Item6;
				if (isExtendingObject) {
					listtype = table.Split('_')[1] + ((listtype != "default" && listtype != null) ? "_" + listtype : "");
					//se si tratta di tabella estendente non ho piÃƒÂ¹ garanzia che il codice immediatamente precedente a 
					//questo metodo abbia giÃƒÂ  caricato la tabella estesa, quindi riattivo il caricamento incrementale da db
					getmissing = true;
				}
				table = table.Substring(0, table.IndexOf('_'));
			}

			if (getmissing)
				//verifico che i campi siano giÃƒÂ  stati caricati dal db altrimento lo faccio ora
				GetMissingFields(table, null, ref allfields, connection);

			//se non ho trovato la tabella riprovo con quella originale
			if (!allfields.Any(af => af.Table == table)) {
				table = originaltable;
				if (getmissing) {
					if (verbose)
						Console.WriteLine("INFO: Riprovo con " + table + ".");
					GetMissingFields(table, null, ref allfields, connection);
				}
			}

			var tablefields = allfields.Where(af => af.Table == table && af.EditListingType == listtype);
			if (!tablefields.Any() && listtype != "default")
				tablefields = allfields.Where(af => af.Table == table && af.EditListingType == "default");
			if (!tablefields.Any())
				tablefields = GetDatasetFields(table, allfields);

			//di base ÃƒÂ¨ l'id ...
			var txtField = GetIdFieldsByTable(table, allfields, connection, false, listtype);
			//...poi provo con il campo preposto
			var fiText = tablefields.Where(af => af.Textfield > 0).OrderBy(af => af.Textfield).ToList();
			if (fiText.Any()) {
				txtField = fiText;
			}
			else {
				//poi provo con title
				var fiTitle = tablefields.Where(af => af.Name.ToLower() == "title").ToList();
				if (fiTitle.Any()) {
					txtField = fiTitle;
				}
				else {
					//poi provo con description
					var fiDescription = tablefields.Where(af => af.Name.ToLower() == "description").ToList();
					if (fiDescription.Any()) {
						txtField = fiDescription;
					}
					else {
						//poi con il primo campo testuale 
						var fiTxt = tablefields.Where(af => IsTextField(af) && !IsTextArea(af) &&
						af.Name != "ct" && af.Name != "cu" && af.Name != "lt" && af.Name != "lu").ToList();
						if (fiTxt.Any()) {
							txtField = fiTxt;
						}
						else {
							ConsoleWriter.WarningDB("Per la tabella " + table + " non ÃƒÂ¨ stato trovato un campo testuale da mostrare nelle dropdown o autochoose");
						}

					}
				}
			}

			return txtField;
		}

		private static string GetSpecification(field f, string tableChild, string table, ref int loop, string joinView, string schemaJoin) {
			var specification = "";
			if (f.Name.Contains('_')) {
				specification = f.Name.Split('_')[1];
				if (f.Name.Split('_').Length == 3)
					specification += "_" + f.Name.Split('_')[2];
			}

			if (f.Name.StartsWith("parid") || f.Name == "idmenuwebparent")
				specification = "parent";

			if (string.IsNullOrEmpty(specification) && tableChild == table) {
				specification = "_" + loop.ToString();
				loop++;
			}

			if (joinView.Contains("LEFT OUTER JOIN " + "[" + schemaJoin + "]." + tableChild + specification + " WITH (NOLOCK) ON ")) {
				if (joinView.Contains("LEFT OUTER JOIN " + "[" + schemaJoin + "]." + tableChild + " AS " + tableChild + "_" + f.Table + ((loop > 0) ? "_" + loop.ToString() : string.Empty) + " WITH (NOLOCK) ON ")) {
					loop++;
					specification = "_" + f.Table + "_" + loop.ToString();

				}
				else specification = "_" + f.Table;

			}

			return specification;
		}

		/// <summary>
		/// Crea la view per il metadato esteso + il metadato estendente oppure 
		/// la view per il list type Default per gli oggetti che hanno un campo che referenzia un'altra tabella ed ÃƒÂ¨ indicato come visibile nell'elenco
		/// </summary>
		/// <param name="table">tabella o oggetto esteso</param>
		/// <param name="extendingObjectTable"></param>
		/// <param name="editType">edit type o oggetto estendente</param>
		/// <param name="fields"></param>
		/// <param name="allfields">campi sul db</param>
		/// <param name="toWrite"></param>
		/// <param name="isLinkingObj"></param>
		/// <param name="one2one">campi in subquery perchÃƒÂ¨ facenti parte di relazioni 1 a 1</param>
		/// <param name="connection">connessione giÃƒÂ  aperta che non viene chiusa</param>
		/// <returns></returns>
		private static List<field> CreateView(string table, string extendingObjectTable, string editType, List<field> fields, List<field> actualNephews, List<field> allfields, bool toWrite, bool isLinkingObj, string one2one,
		obj currentObj, SqlConnection connection) {

			var viewFields = new List<field>();

			var schema = GetSchemaByTable(table, allfields, connection, false);
			if (!string.IsNullOrEmpty(schema))
				schema = "[" + schema + "].";

			var isDbo = !String.IsNullOrEmpty(schema);

			var createView = "CREATE VIEW {0}[" + table + editType + "view] AS \r\nSELECT ";
			var joinView = "";
			var whereView = "";

			//caso di oggetto esteso
			if (!string.IsNullOrEmpty(extendingObjectTable)) {
				var keys = GetIdByTable(table, allfields, connection);
				var keysExtending = GetIdByTable(extendingObjectTable, allfields, connection);
				joinView += "\r\nINNER JOIN " + extendingObjectTable + " WITH (NOLOCK) ON ";
				var addend = false;
				foreach (var key in keys) {
					var keyExtending = keysExtending.Where(k => key.Split('_')[0] == k.Split('_')[0]).FirstOrDefault();
					joinView += (addend ? " AND " : "") + table + "." + key + " = " + extendingObjectTable + "." + keyExtending;
					addend = true;
				}
			}

			//campo da mostrare nelle dropdown
			var dropdown = "";
			var dropdowns = new List<textField>();

			//qui sicuramente: 
			//-il get missing non serve perchÃƒÂ¨ sono i campi principali 
			//-non devo controllare se il text field ÃƒÂ¨ di un estendente perchÃƒÂ¨ non glieli passo mai
			var textfield = GetTextFieldByTable(table, allfields, connection, false, editType != "default" ? editType : null).FirstOrDefault();
			if (textfield != null) {
				if (belongsToOtherTable(table, textfield)) {
					ConsoleWriter.ErrorDB("Sto costruendo la vista " + table + editType + "view in modo inconsistente");
				}

				var loop = 1;
				//var keys = GetIdByTable(table, allfields, connection);
				//prendo i campi della tabella corrente o di quella estendente
				foreach (var f in fields.Where(af => !af.Name.StartsWith("!")).OrderBy(af => af.Table).ThenBy(af => af.SortList)) {

					//tolgo l'alias all'id e al text field dell'oggetto corrente e agli enum
					var hadAlias = !(f.Table == table && (f.IsKey || f.Name == textfield.Name)) && !IsEnum(f, allfields, connection);
					if (hadAlias)
						f.ViewAlias = f.Table + "_" + f.Name;

					var isExternalKey = false;
					var ex = GetException(null, null, f.Table, f.Name);
					if (ex != null)
						isExternalKey = true;

					// se ÃƒÂ¨ una chiave esterna ed ÃƒÂ¨ visibile in lista o in dettaglio...
					if (HaveKeyName(f) && (f.ListVisible || (f.Detailvisible && !f.Hidden)) &&
						//...e se non sono incappato in una delle sue chiavi stesse ... (a meno che non sia un oggetto di collegamento)
						(!IsPrincipalKey(f, table) || isLinkingObj || isExternalKey)
						//...e non si tratta di un enum
						&& !IsEnum(f, allfields, connection)
						) {

						//...aggiungo il join 

						var tableChild = GetTableById(f.Name, allfields, connection);

						if (!string.IsNullOrEmpty(tableChild)) {
							createView += "\r\n";

							var schemaJoin = GetSchemaByTable(tableChild, allfields, connection, true);

							var specification = GetSpecification(f, tableChild, table, ref loop, joinView, schemaJoin);

							if (string.IsNullOrEmpty(schemaJoin))
								isDbo = false;
							else
								schemaJoin = "[" + schemaJoin + "].";

							var hasAlias = !string.IsNullOrEmpty(specification);

							//creo una variabile che conterrÃƒÂ  l'alias della tabella child oppure la tabella child con lo schema
							var tableChildAndSchema = schemaJoin + tableChild;
							var tableChildAlias = tableChild + specification;
							var tableChildInUse = hasAlias ? tableChildAlias : tableChildAndSchema;


							//ricavo la relazione, essendo una foreignkey il figlio ÃƒÂ¨ la tabella principale e il padre la key a cui la foreignkey punta
							var childkey = f.Name;
							var parentKey = GetIdByForeignKey(f);
							if (parentKey.Split(' ').ToList().Count > 1) {
								var kk = GetChildForeignKeysString(tableChild, table, null, editType, parentKey.Split(' ').ToList(), allfields, connection);
								childkey = kk.Split(';')[0].Trim();
								parentKey = kk.Split(';')[1].Trim();
							}
							var onString = "";
							var ik = 0;
							foreach (var ck in childkey.Split(' ')) {
								var pk = parentKey.Split(' ')[ik];
								onString += (ik > 0 ? " AND " : "") +
									f.Table + "." + ck + " = " + tableChildInUse + "." + pk;
								ik++;
							}
							//-----------------------------


							var idTableChild = GetPrincipalKey(tableChild, null, allfields, connection, true).Name;

							joinView += "\r\nLEFT OUTER JOIN " + tableChildAndSchema + (hasAlias ? " AS " + tableChildAlias : "") +
									 " WITH (NOLOCK) ON " + onString;

							//aggiungerÃƒÂ² la chiave esterna senza alias per poter usare il campo in ricerca in presenza di autochoose, 
							//perchÃƒÂ¨ non posso indicare il campo su cui cercare col searchtag
							//(siamo nel ramo delle autochoose o select quindi !select = autochoose ma comunque ribatto la regola che all'id e al text field dell'oggetto corrente 
							//non va messo l'alias)
							hadAlias = IsDropdown(f, tableChild) && !(f.Table == table && (f.IsKey || f.Name == textfield.Name));
							if (!hadAlias)
								f.ViewAlias = null;


							//se ÃƒÂ¨ una tabella di collegamento
							if (isLinkingObj || f.IsLinkingObj) {
								//aggiungo TUTTI i campi della tabella collegata visibili in griglia ...
								var joinfields = GetLinkingObjectFields(table, editType, ref allfields, connection);
								foreach (var txtField in joinfields.Where(jf => belongsToOtherTable(table, jf))) {
									var alias = txtField.Table + specification + "_" + txtField.Name;
									var column = (hasAlias ? "" : schemaJoin) + txtField.Table + (belongsToOtherTable(tableChild, txtField) ? "_" + tableChild : "") + specification + "." + txtField.Name;
									createView += " " + column + " AS " + alias + ",";

									AddDropDownField(txtField, ref dropdowns, column, f.Textfield, null, txtField, allfields, connection);

									//lo devo rinnovare con tabella e visibilitÃƒÂ  uguali a quello dell'ID che lo ha generato
									viewFields.Add(RenewField(txtField, f, (f.SortList * 100) + (txtField.SortList * 10)  /*txtField.SortList*/, txtField.Detailvisible, txtField.ListVisible, alias, txtField.Title));
									Console.Write(".");
								}
								if (joinfields.Any(jf => belongsToOtherTable(tableChild, jf))) {
									//mi mi sono stati restituiti alcuni text field dell'estendente, quindi devo aggiungerlo nel join (ci metto sempre l'alias non si sa mai)
									var extendedTableChild = joinfields.First(jf => belongsToOtherTable(tableChild, jf)).Table;
									var schemaJoin2 = GetSchemaByTable(extendedTableChild, allfields, connection, false);

									if (string.IsNullOrEmpty(schemaJoin2))
										isDbo = false;
									else
										schemaJoin2 = "[" + schemaJoin2 + "].";

									var tableAlias = extendedTableChild + "_" + tableChild;
									joinView += "\r\nLEFT OUTER JOIN " + schemaJoin2 + extendedTableChild + " AS " + tableAlias + specification +
											 " WITH (NOLOCK) ON " + tableChildInUse + "." + idTableChild + " = " + tableAlias + specification + "." + idTableChild;

								}
							}
							else {
								//...aggiungo ai campi tabella.campotestuale AS tabella_campotestuale
								var txtFields = GetTextFieldByTable(tableChild, allfields, connection, false, f.Listtype);
								if (tableChild == txtFields.First().Table) {

									foreach (var txtField in txtFields) {
										//se non ÃƒÂ¨ una foreignkey oppure se ÃƒÂ¨ una key per questo specifico oggetto lo aggiungo 
										if (!HaveKeyName(txtField) || txtField.IsKey || IsEnum(txtField, allfields, connection)) {
											var alias = tableChildAlias + "_" + txtField.Name;
											var column = tableChildInUse + "." + txtField.Name;
											createView += " " + column + " AS " + alias + ",";

											AddDropDownField(f, ref dropdowns, column, f.Textfield, null, txtField, allfields, connection);

											//lo devo rinnovare con sortList, tabella e visibilitÃƒÂ  uguali a quello dell'ID che lo ha generato
											viewFields.Add(RenewField(txtField, f, (f.SortList * 100) + (txtField.SortList * 10)  /*f.SortList*/, f.Detailvisible, f.ListVisible, alias, (txtFields.Count > 1 ? txtField.Title + " " : "") + f.Title));
											Console.Write(".");
										}
										else {

											//caso in cui il text field ÃƒÂ¨ a sua volta una foreign key quindi devo saltare su un'altra tabella ancora
											var tableChild2 = GetTableById(txtField.Name, allfields, connection);
											if (!string.IsNullOrEmpty(tableChild2)) {
												int loop2 = 0;
												var schemaJoin2 = GetSchemaByTable(tableChild2, allfields, connection, true);

												var specification2 = GetSpecification(txtField, tableChild2, table, ref loop2, joinView, schemaJoin2);

												if (string.IsNullOrEmpty(schemaJoin2))
													isDbo = false;
												else
													schemaJoin2 = "[" + schemaJoin2 + "].";

												var hasAlias2 = !string.IsNullOrEmpty(specification2);

												var idTableChild2 = GetPrincipalKey(tableChild2, null, allfields, connection, true).Name;

												var tableChildAndSchema2 = schemaJoin2 + tableChild2;
												var tableChildAslias2 = tableChild2 + specification2;
												var tableChildInUse2 = hasAlias2 ? tableChildAslias2 : tableChildAndSchema2;

												//var tableChildInUse2 = (hasAlias2 ? "" : schemaJoin2) + tableChild2 + specification2;

												joinView += "\r\nLEFT OUTER JOIN " + tableChildAndSchema2 + (hasAlias2 ? " AS " + tableChildAslias2 : "") +
														 " WITH (NOLOCK) ON " + tableChildInUse + "." + txtField.Name + " = " + tableChildInUse2 + "." + idTableChild2;

												var txtFields2 = GetTextFieldByTable(tableChild2, allfields, connection, false, txtField.Listtype);

												//potrebbe essere un estendente e i campi testuali essere sull'esteso quindi devo aggiungere anche l'esteso
												var extendedTable = "";
												var extendedTableAndSchema = "";
												var extendedTableAlias2 = "";
												var extendedTableInUse2 = "";
												if (txtFields2.Any(tf2 => tf2.Table != tableChild2)) {

													extendedTable = txtFields2.Where(tf2 => tf2.Table != tableChild2).Select(x => x.Table).First();
													extendedTableAndSchema = schemaJoin2 + extendedTable;
													extendedTableAlias2 = extendedTable + specification2;
													extendedTableInUse2 = hasAlias2 ? extendedTableAlias2 : extendedTable;

													joinView += "\r\nLEFT OUTER JOIN " + extendedTableAndSchema + (hasAlias2 ? " AS " + extendedTableAlias2 : "") +
															" WITH (NOLOCK) ON " + tableChildInUse + "." + txtField.Name + " = " + extendedTableInUse2 + "." + idTableChild2;
												}

												if (!txtFields2.Any(tf2 => tf2.Name == txtField.Name))
													txtFields2.Add(txtField);
												foreach (var txtField2 in txtFields2) {
													//di base ÃƒÂ¨ l'utima tabella del join ma ...
													var txtFieldTableInUse = tableChildInUse2;
													var txtFieldTableAlias = tableChildAslias2;

													//... se ÃƒÂ¨ il textfield originale rimetto la tabella di partenza
													var isOriginalTextField = false;
													if (txtField2.Table == txtField.Table && txtField2.Name == txtField.Name) {
														isOriginalTextField = true;
														txtFieldTableInUse = tableChildInUse;
														txtFieldTableAlias = tableChildAlias;
													}

													if (!HaveKeyName(txtField2) || txtField2.IsKey || IsEnum(txtField2, allfields, connection) || isOriginalTextField) {
														//... se ÃƒÂ¨ esteso metto l'esteso da quest'ultima
														if (txtField2.Table == extendedTable) {
															txtFieldTableInUse = extendedTableInUse2;
															txtFieldTableAlias = extendedTableAlias2;
														}

														var alias = txtFieldTableAlias + "_" + txtField2.Name;
														var column = txtFieldTableInUse + "." + txtField2.Name;
														createView += " " + column + " AS " + alias + ",";
														if (!isOriginalTextField && f.Textfield > 0)
															AddDropDownField(txtField, ref dropdowns, column, f.Textfield, txtField.Textfield, txtField2, allfields, connection, true);

														//lo devo rinnovare con sortList, tabella e visibilitÃƒÂ  uguali a quello dell'ID che lo ha generato
														viewFields.Add(RenewField(txtField2, txtField,
															(f.SortList * 100) + (txtField.SortList * 10) + txtField2.SortList /*txtField.SortList*/,
															f.Detailvisible ? !isOriginalTextField ? txtField.Detailvisible : false : false, // mostro solo se era visibile sia la fk che il lookup (ma non la fk intermedia eventualmente riaggiunta ai textfields)
															f.ListVisible ? !isOriginalTextField ? txtField.ListVisible : false : false, // mostro solo se era visibile sia la fk che il lookup (ma non la fk intermedia eventualmente riaggiunta ai textfields)
															alias, (txtFields2.Count > 1 ? txtField2.Title + " " : "") + txtField.Title + " " + f.Title));
														Console.Write(".");
													}
													else {
														ConsoleWriter.Warning("lookup di terzo livello non gestito: " + f.Title + " " + txtField.Title + " " + txtField2.Title);
													}
												}

											}
										}
									}
								}
								else {
									//mi ÃƒÂ¨ stato restituito il text field del padre, quindi devo aggiungerlo nel join (ci metto sempre l'alias non si sa mai)
									var extendedTable = txtFields.First().Table;
									var schemaJoin2 = GetSchemaByTable(extendedTable, allfields, connection, false);
									if (string.IsNullOrEmpty(schemaJoin2))
										isDbo = false;
									else
										schemaJoin2 = "[" + schemaJoin2 + "].";

									var extendedTableAndSchema = schemaJoin2 + extendedTable;
									var extendedTableAlias2 = extendedTable + specification;
									var extendedTableInUse2 = hasAlias ? extendedTableAlias2 : extendedTable;

									joinView += "\r\nLEFT OUTER JOIN " + extendedTableAndSchema + " AS " + extendedTableAlias2 +
											 " WITH (NOLOCK) ON " + tableChildInUse + "." + idTableChild + " = " + extendedTableAlias2 + "." + idTableChild;
									foreach (var txtField in txtFields) {

										var alias = extendedTableAlias2 + "_" + txtField.Name;
										var column = extendedTableInUse2 + "." + txtField.Name;
										createView += " " + column + " AS " + alias + ",";

										AddDropDownField(f, ref dropdowns, column, f.Textfield, null, txtField, allfields, connection);

										//lo devo rinnovare con sortList, tabella e visibilitÃƒÂ  uguali a quello dell'ID che lo ha generato
										viewFields.Add(RenewField(txtField, f, (f.SortList * 100) + (txtField.SortList * 10)  /*f.SortList*/, f.Detailvisible, f.ListVisible, alias, f.Title));
										Console.Write(".");
									}
								}
							}


							//aggiungo il campo id ai fields della vista
							viewFields.Add(RenewField(f, f, (f.SortList * 100) /* f.SortList*/, f.Detailvisible, false, f.ViewAlias));
							Console.Write(".");
						}
						else {
							//aggiungo il campo id ai fields della vista perchÃƒÂ¨ non porta a nulla 
							viewFields.Add(RenewField(f, f, (f.SortList * 100) /* f.SortList*/, f.Detailvisible, f.ListVisible, f.ViewAlias));
							Console.Write(".");
						}
					}
					else {
						//aggiungo il campo qualunque ai fields della vista
						viewFields.Add(RenewField(f, f, (f.SortList * 100) /* f.SortList*/, f.Detailvisible, f.ListVisible, f.ViewAlias));
						Console.Write(".");

						AddDropDownField(f, ref dropdowns, f.Table + "." + f.Name, f.Textfield, null, new field { Type = f.Type, Textfield = 0 }, allfields, connection);
					}

					//aggiungo il campo alla vista ...

					if (f.Type == "char" && f.Len == 1) {
						var radiovalues = string.IsNullOrEmpty(f.Radiovalues) ? "S;Si;N;No" : f.Radiovalues;
						var v = radiovalues.Split(';').ToList();
						createView += "CASE ";
						foreach (var r in v) {
							if (v.IndexOf(r) % 2 == 0) {
								createView += "WHEN " + f.Table + "." + f.Name + " = '" + r + "' ";
							}
							else {
								createView += "THEN '" + r + "' ";
							}
						}
						createView += "END AS " + f.Table + "_" + f.Name + ",";
					}
					else
						//...togliendo gli alias all'id e al text field dell'oggetto corrente
						createView += " " + f.Table + "." + f.Name + (hadAlias ? " AS " + f.Table + "_" + f.Name : "") + ",";

					//aggiungo il filtro statico per questa vista indicato nel campo e l'eventuale non nullabilitÃƒÂ  delle chiavi forzate
					if (!string.IsNullOrEmpty(f.Filter))
						whereView += " AND " + f.Table + "." + f.Name + " " + f.Filter;
					if (f.IsKey)
						whereView += " AND " + f.Table + "." + f.Name + " IS NOT NULL ";
				}
			}
			else {
				ConsoleWriter.ErrorDB("La tabella " + table + " con l'edit type " + editType + " non ha un campo testuale definito da mostrare");
			}
			//IL FILTRO STATICO NON VIENE APPLICATO QUI ma nel metadato vista (o normale) 
			//NON si puÃƒÂ² applicare qui perchÃƒÂ¨ :
			//1 - sono scritti tutti con gli alias della vista mentre qui andrebbero riferiti alle tabelle
			//2 - sono presenti elementi dinamici elaborati a runtime dal codice come l'id dell'utente loggato
			//if (!string.IsNullOrEmpty(currentObj.Staticfilter))
			//	whereView += " AND " + currentObj.Staticfilter;

			//aggiungo i campi in subquery -----------------------------------------------------------------
			createView += one2one.Trim();

			//campo per le dropdown ------------------------------------------------------------------------
			if (dropdowns.Any()) {
				foreach (var f in dropdowns.OrderBy(ddf => ddf.FirstIndex).ThenBy(ddf => ddf.SecondIndex).ThenBy(ddf => ddf.ThirdIndex)) {
					if (!string.IsNullOrWhiteSpace(dropdown))
						dropdown += " + ";
					dropdown += f.Column + " + ' '";
				}
				dropdown = "\r\n " + dropdown.Substring(0, dropdown.Length - 6) + " as dropdown_title";
				createView += dropdown;
			}
			else {
				ConsoleWriter.WarningDB("Non ho costruito il dropdown_title");
				createView = createView.Substring(0, createView.Length - 1);
			}
			//----------------------------------------------------------------------------------------------

			//calcolo delle colonne nipoti -----------------------------------------------------------------

			//var pageid = allfields.Where(af => af.Table == table && af.EditListingType == editType).Select(af => af.PageId).First();
			//var actualNephews = GetChildentitiesFields(pageid, extendingObjectTable, allfields, connection).Where(c => c.ShowInParentGrid > 0);
			foreach (var nep in actualNephews) {
				//per ogni nipote ricavo la tabella corrispondente
				var nepTable = nep.Name.Substring(2);
				var nepEditType = string.IsNullOrEmpty(nep.Listtype) ? "default" : nep.Listtype;
				var nepCols = new List<textField>();
				//ricavo i ampi testuali
				foreach (var tf in GetTextFieldByTable(nepTable, allfields, connection, true, nepEditType)) {
					AddDropDownField(tf, ref nepCols, tf.Table + "." + tf.Name, tf.Textfield, null, new field { Type = tf.Type, Textfield = 0 }, allfields, connection, false, true);
				}
				var calcCol = "";
				//scrivo il campo di select in JSON				
				var schemaJoin = GetSchemaByTable(nepTable, allfields, connection);

				if (nepCols.Any()) {
					foreach (var f in nepCols.OrderBy(ddf => ddf.FirstIndex).ThenBy(ddf => ddf.SecondIndex)) {
						var colName = "[" + f.ColumnName + "]";
						if (f.Column.EndsWith(colName + ","))
							calcCol += f.Column.Replace(colName, f.ColumnName.Replace(" ", "_"));
						else
							calcCol += f.Column.Replace("\"\" : ", "") + (string.IsNullOrWhiteSpace(f.ColumnName) ? "" : " AS " + f.ColumnName.Replace(" ", "_")) + ",";
					}
					var parentKey = GetIdByTable(table, allfields, connection, false, editType);

					var kk = GetChildForeignKeysString(table, nepTable, editType, nepEditType, parentKey, allfields, connection);
					var childkey = kk.Split(';')[0].Trim();

					//preparo la condizione di JOIN

					parentKey = kk.Split(';')[1].Trim().Split(' ').ToList();

					var whereString = "";
					var ik = 0;
					foreach (var ck in childkey.Split(' ')) {
						var pk = parentKey[ik];
						whereString += (ik > 0 ? " AND " : "") +
							nepTable + "." + ck + " = " +
							table + "." + pk;
						ik++;
					}
					//calcolo e aggiungo  la colonna nipote				
					calcCol = "\r\n , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT " + calcCol.Substring(0, calcCol.Length - 1) + " FROM  " + schemaJoin + "." + nepTable +
						"\r\n WHERE " + whereString + " FOR XML path, root)))) AS " + nep.Name + " ";

					createView += calcCol;
					nep.ListVisible = true;
					nep.SortList = nep.ShowInParentGrid * 100;
					nep.Title = nep.Text;
					viewFields.Add(nep);
				}
			}

			//----------------------------------------------------------------------------------------------

			createView += "\r\nFROM " + schema + "" + table + " WITH (NOLOCK) ";
			createView += joinView;
			if (!string.IsNullOrEmpty(whereView))
				createView += "\r\nWHERE " + whereView.Substring(4);

			//verifichiamo se si tratta di una vista non dbo 
			//in base al fatto se un qualunque join ÃƒÂ¨ non dbo
			if (!isDbo) {
				schema = "";
				//se per qualunque ragione la vista era stata generata precedentemente dbo la elimino
				var cmd = new SqlCommand("IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[" + table + editType + "view]') and OBJECTPROPERTY(id, N'IsView') = 1) DROP VIEW [dbo]." + table + editType + "view", connection);
				try { cmd.ExecuteNonQuery(); }
				catch (Exception e) {
					ConsoleWriter.ErrorDB("Fallita l'eliminazione della vista [dbo].[" + table + editType + "view] perchÃƒÂ¨ va ricreata NON dbo. " + e.Message);
				}
			}

			createView = createView.Replace("{0}", schema);

			if (!skipView && toWrite) {
				var cmd = new SqlCommand(createView, connection);
				var skip = false;
				try {
					cmd.ExecuteNonQuery();
				}
				catch (Exception e) {
					if (verbose)
						ConsoleWriter.InfoDB("La vista " + table + editType + "view esisteva giÃƒÂ  " + e.Message);
					var alterView = createView.Replace("CREATE VIEW", "ALTER VIEW");
					cmd = new SqlCommand(alterView, connection);
					try {
						cmd.ExecuteNonQuery();
					}
					catch (Exception ea) {
						ConsoleWriter.ErrorDB("Fallito l'aggiornamento della vista " + table + editType + "view" + ea.Message);
						skip = true;
					}
				}


			}
			Console.WriteLine("");
			return viewFields;
		}

		private static void AddDropDownField(field f, ref List<textField> dropdowns, string column, int firstIndex, int? secondIndex, field textField, List<field> allfields, SqlConnection connection, bool cocnatTitles = false, bool addQuot = false) {
			if (f.Textfield > 0) {
				var fieldType = f.Type;
				if (HaveKeyName(f))
					fieldType = textField.Type;

				// aggiungo uno spazio dopo il prefisso se presente
				var prefix = string.IsNullOrWhiteSpace(f.Prefix) ? "" : f.Prefix.Replace("'", "''").Replace(":", "") + " ";
				var title = cocnatTitles ? textField.Title.Replace("'", "''") + " " + f.Title.Replace("'", "''") : f.Title.Replace("'", "''");

				if (fieldType == "char" && f.Len == 1) {
					var ddfield = "";
					if (string.IsNullOrEmpty(f.Radiovalues)) {
						if (f.IsCheckbox)
							ddfield = "CASE WHEN " + f.Table + "." + f.Name + " = 'S' THEN '" + title + "' ELSE '' END";
						else
							ddfield = "CASE WHEN " + f.Table + "." + f.Name + " = 'S' THEN '" + title + "' ELSE 'non " + title + "' END";
					}
					else {
						var v = f.Radiovalues.Split(';').ToList();
						ddfield = "CASE ";
						foreach (var r in v) {
							if (v.IndexOf(r) % 2 == 0) {
								ddfield += "WHEN " + f.Table + "." + f.Name + " = '" + r + "' ";
							}
							else {
								ddfield += "THEN '" + r + "' ";
							}
						}
						ddfield += "END ";
					}
					dropdowns.Add(new textField()
					{
						Column = "isnull('" + /*(addQuot ? "\"" : "") +*/ prefix + /*(addQuot ? "\" : \"" : "") +*/ "' + " + ddfield + /*(addQuot ? "\"" : "") +*/ ",'')",
						ColumnName = (string.IsNullOrWhiteSpace(prefix) ? title : prefix),
						FirstIndex = firstIndex,
						SecondIndex = secondIndex != null ? (int)secondIndex : textField.Textfield,
						ThirdIndex = secondIndex != null ? textField.Textfield : 0
					});
				}
				else {
					if (fieldType == "date" || fieldType == "datetime") {
						if (string.IsNullOrWhiteSpace(prefix)) {
							if (f.Name.Contains("start")) prefix = "dal ";
							if (f.Name.Contains("stop")) prefix = "al ";
							if (!f.Name.Contains("start") && !f.Name.Contains("stop")) prefix = "del ";
						}
						dropdowns.Add(new textField()
						{
							Column = "isnull('" + (addQuot ? "\"" : "") + prefix + (addQuot ? "\" : \"" : "") + "' + CONVERT(VARCHAR, " + column + ", 103)" + (addQuot ? "+ '\"'" : "") + ",'')",
							ColumnName = (string.IsNullOrWhiteSpace(prefix) ? title : prefix),
							FirstIndex = firstIndex,
							SecondIndex = secondIndex != null ? (int)secondIndex : textField.Textfield,
							ThirdIndex = secondIndex != null ? textField.Textfield : 0
						});
					}
					else {
						if (fieldType == "int" || fieldType == "decimal" || fieldType == "float" || fieldType == "smallint" || fieldType == "bigint" || fieldType == "tinyint") {
							if (HaveKeyName(f)) {

								var fktable = GetTableById(f.Name, allfields, connection);
								var txtFields = GetTextFieldByTable(fktable, allfields, connection, true, f.Listtype);
								var selectString = "(Select top 1 ";

								foreach (var tf in txtFields.OrderBy(ttf => ttf.SortList)) {
									var tfStringSQLCol = tf.Name;
									if (tf.Type == "int" || tf.Type == "decimal" || tf.Type == "float" || tf.Type == "smallint" || tf.Type == "bigint" || tf.Type == "tinyint")
										tfStringSQLCol = "CAST( " + tf.Name + " AS NVARCHAR(64))";
									if (tf.Type == "date" || tf.Type == "datetime")
										tfStringSQLCol = "CONVERT(VARCHAR, " + tf.Name + ", 103)";
									if (tf.Type == "char" && f.Len == 1)
										tfStringSQLCol = tf.Name;
									selectString += "'" + tf.Title.Replace("'", "''") /*+ " " + title */+ ": ' +" + tfStringSQLCol + " + '; ' + ";
								}
								var keys = GetIdByForeignKey(f).Split(' ').ToList();
								if (keys.Count() == 1)
									selectString = selectString.Substring(0, selectString.Length - 10) + " from " + fktable + " x where x." + keys[0] + " = " + f.Table + "." + f.Name + ")";
								else {
									selectString = selectString.Substring(0, selectString.Length - 10) + " from " + fktable + " x where ";

									foreach (var k in keys) {
										selectString += "x." + k + " = " + f.Table + "." + k + " AND ";
									}
									selectString = selectString.Substring(0, selectString.Length - 4) + ")";
								}

								dropdowns.Add(new textField()
								{
									Column = /*"isnull('" + (string.IsNullOrWhiteSpace(prefix) ? title : prefix) + ": ' + CAST( "*/"isnull(" + selectString + " + '; ','')",
									ColumnName = (string.IsNullOrWhiteSpace(prefix) ? title : prefix),
									FirstIndex = firstIndex,
									SecondIndex = secondIndex != null ? (int)secondIndex : textField.Textfield,
									ThirdIndex = secondIndex != null ? textField.Textfield : 0
								});
							}
							else
								dropdowns.Add(new textField()
								{
									Column = !addQuot ?
									"isnull('" + (string.IsNullOrWhiteSpace(prefix) ? title : prefix) + ": ' + CAST( " + column + " AS NVARCHAR(64)) + '; ','')" :
									"isnull(CAST(" + column + " AS NVARCHAR(64))," + ((fieldType == "decimal") ? "'0.00'" : "'0'") + ") AS [" + (string.IsNullOrWhiteSpace(prefix) ? title : prefix) + "],",
									ColumnName = (string.IsNullOrWhiteSpace(prefix) ? title : prefix),
									FirstIndex = firstIndex,
									SecondIndex = secondIndex != null ? (int)secondIndex : textField.Textfield,
									ThirdIndex = secondIndex != null ? textField.Textfield : 0
								});
						}
						else
							//controllare se necessaria sostituzione isnull per altri addQuot sopra
							dropdowns.Add(new textField()
							{
								Column = !addQuot ?
								"isnull('" + (string.IsNullOrWhiteSpace(prefix) ? title : prefix) + ": ' + " + column + " + '; ','')" :
								column + " AS [" + (string.IsNullOrWhiteSpace(prefix) ? title : prefix) + "],",
								ColumnName = (string.IsNullOrWhiteSpace(prefix) ? title : prefix),
								FirstIndex = firstIndex,
								SecondIndex = secondIndex != null ? (int)secondIndex : textField.Textfield,
								ThirdIndex = secondIndex != null ? textField.Textfield : 0
							});
					}
				}
			}
		}

		/// <summary>
		/// Restituisce la chiave da una sua chiave esterna con prefissi e suffissi
		/// </summary>
		/// <param name="f"></param>
		/// <returns></returns>
		private static string GetIdByForeignKey(field f) {
			return GetIdByForeignKey(f.Name, f.Table);
		}

		/// <summary>
		/// Restituisce la chiave da una sua chiave esterna con prefissi e suffissi
		/// </summary>
		/// <param name="foreignkey">Chiave esterna</param>
		/// <param name="table">tabella contenente la chiave esterna</param>
		/// <returns></returns>
		private static string GetIdByForeignKey(string foreignkey, string table) {
			var ex = GetException(null, null, table, foreignkey);
			if (ex != null)
				return ex.Item2;
			else {
				var key = !foreignkey.Contains("_") ? foreignkey : foreignkey.Split('_')[0];
				if (key.StartsWith("parid"))
					key = key.Substring(3);
				return key;
			}
		}

		/// <summary>
		/// Indica che il name del campo ÃƒÂ¨ quello di una chiave
		/// </summary>
		/// <param name="fi">campo</param>
		/// <returns>true/false</returns>
		private static bool HaveKeyName(field fi) {
			var output = false;

			//casi non standard
			var ex = GetException(null, fi.Name, null, null);
			if (ex != null) {
				return ex.Item5;
			}
			else {
				ex = GetException(null, null, fi.Table, fi.Name);
				if (ex != null)
					return ex.Item5;
			}

			//se rispetta la convenzione ma non si tratta di un campo di abilitazione/disabilitazione (radiobutton)
			if ((fi.Name.StartsWith("parid") || fi.Name.StartsWith("id")) && !(fi.Type == "char" && fi.Len == 1))
				output = true;
			return output;
		}

		/// <summary>
		/// Restituisce i valori dei radiobutton da inserire nel tag della griglia
		/// </summary>
		/// <param name="gridtable">tabella della griglia</param>
		/// <param name="listtype">list type da considerare</param>
		/// <param name="allfields">tutti i campi</param>
		/// <param name="connection">connessione</param>
		/// <returns>stringa dei valori campo,valore,testo;campo,valore,testo;</returns>
		private static string GetRadioFieldsValues(string gridtable, string listtype, List<field> allfields, SqlConnection connection) {

			var gridfields = new List<field>();
			field gridkey = null;
			if (IsLinkingObject(gridtable, ref allfields, connection)) {
				gridfields = GetLinkingObjectFields(gridtable, listtype, ref allfields, connection);
				gridkey = gridfields.Where(gf => gf.IsKey).FirstOrDefault();
			}
			else
				gridfields = GetFields(gridtable, listtype, ref allfields);
			var radiotag = "";
			foreach (var gf in gridfields.Where(gf => gf.ListVisible)) {
				if (gf.Type == "char" && gf.Len == 1) {
					var radiovalues = string.IsNullOrEmpty(gf.Radiovalues) ? "S;Si;N;No" : gf.Radiovalues;
					var v = radiovalues.Split(';').ToList();
					foreach (var r in v) {
						if (v.IndexOf(r) % 2 == 0) {
							radiotag += (gridkey != null ? "!" + gridkey.Name + "_" + gf.Table + "_" + gf.Name : gf.Name) + "," + r + ",";
						}
						else {
							radiotag += r + ";";
						}
					}
				}
			}

			return radiotag;

		}

		#endregion

		#region metodi di manipolazione dei file

		/// <summary>
		/// Copia la cartella sourceDirectory nella posizione targetDirectory
		/// </summary>
		/// <param name="sourceDirectory"></param>
		/// <param name="targetDirectory"></param>
		public static void CopyDir(string sourceDirectory, string targetDirectory) {
			DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
			DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);

			CopyAll(diSource, diTarget);
		}

		/// <summary>
		/// Copia la cartella source nella posizione target
		/// </summary>
		/// <param name="source"></param>
		/// <param name="target"></param>
		public static void CopyAll(DirectoryInfo source, DirectoryInfo target) {
			Directory.CreateDirectory(target.FullName);

			// Copy each file into the new directory.
			foreach (FileInfo fi in source.GetFiles()) {
				//Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
				fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
			}

			// Copy each subdirectory using recursion.
			foreach (DirectoryInfo diSourceSubDir in source.GetDirectories()) {
				DirectoryInfo nextTargetSubDir =
				target.CreateSubdirectory(diSourceSubDir.Name);
				CopyAll(diSourceSubDir, nextTargetSubDir);
			}
		}

		/// <summary>
		/// Copia il file source nella posizione e nome target
		/// </summary>
		/// <param name="source"></param>
		/// <param name="target"></param>
		public static void Copy(string source, string target, bool overvrite = false) {
			FileInfo fiSource = new FileInfo(source);
			//var enc = GetEncoding(source);
			FileInfo fiTarget = new FileInfo(target);
			if (File.Exists(fiTarget.FullName)) {
				if (overvrite) {
					File.Delete(fiTarget.FullName);
					fiSource.CopyTo(fiTarget.FullName, true);
				}
			}
			else {
				fiSource.CopyTo(fiTarget.FullName, true);
			}
			//var enc2 = GetEncoding(target);
			//if (enc != enc2)
			//	ConsoleWriter.ErrorDB("Il file " + target + " ha una codifica sbagliata");

		}

		/// <summary>
		/// effettua il replace della parola "tabella" nel mome con quello che viene passato nel parametro "current"
		/// </summary>
		/// <param name="fullPath"></param>
		/// <param name="current"></param>
		/// <returns></returns>
		private static string RenameFile(string fullPath, string current) {
			var fileNameOnly = Path.GetFileNameWithoutExtension(fullPath);
			var extension = Path.GetExtension(fullPath);
			var path = Path.GetDirectoryName(fullPath);

			var newPath = Path.Combine(path, fileNameOnly.Replace("tabella", current) + extension);
			if (File.Exists(newPath))
				File.Delete(newPath);
			File.Move(fullPath, newPath);
			return newPath;
		}

		#region Replace in file LocalResourceFile

		/// <summary>
		/// Sostituisce/Aggiunge nel file fullPath il valore del campo toReplace, prima o dopo il mark, con il nuovo newValue, secondo il pattern indicato 
		/// </summary>
		/// <param name="fullPath"></param>
		/// <param name="mark"></param>
		/// <param name="valueToReplace"></param>
		/// <param name="newValue"></param>
		/// <param name="pattern"></param>
		/// <param name="previousLikeValueExist"></param>
		private static void ReplaceRegExInFile(string fullPath, string mark, string newValue, string patternToReplace, string valueToReplace = null, string previousLikeValueExist = null) {
			//creato nuovo metodo per non aprire due volte il file e non toccare il vecchio metodo ReplaceStringInFile
			string textFile = TextFile.ReadAllTextFile(fullPath);
			var enc = TextFile.GetEncoding(fullPath);

			bool replace = false;
			string initiallyText = textFile;
			string patternToControl;
			//se toReplace ÃƒÂ¨ null vuol dire che la sostituzione non sarÃƒÂ  mai in aggiunta, dovrÃƒÂ² sempre sostituire in caso il valore sia diverso
			if (String.IsNullOrEmpty(valueToReplace)) {
				//per la verifica elimino tutti gli spazi vuoti che potrebbero rendere non veritieri i controlli di stringhe equivalenti
				patternToControl = Regex.Escape(TextFile.RemoveUnquotedWhiteSpaces(newValue));
				replace = true;
				textFile = TextFile.RemoveUnquotedWhiteSpaces(textFile);
			}
			else {
				//se vado in aggiunta tengo conto di eventuali spazi e tabulazioni per i controlli di uguaglianza
				patternToControl = "(\"|\\s|\\t|\\t\\t|$)" + patternToReplace;
			}

			List<KeyValuePair<string, int>> lines = Regex.Matches(textFile, patternToControl, RegexOptions.Singleline).Cast<Match>()
																	.Select(m => new KeyValuePair<string, int>(m.Value, textFile.IndexOf(m.Value))).ToList();


			//verifico se la linea ÃƒÂ¨ giÃƒÂ  presente
			if (lines.Any() && !replace) {
				//se ci sono doppioni li elimino tutti tranne uno che eventualmente sostituirÃƒÂ² con il nuovo valore
				if (lines.Count > 1) {
					var delete = true;
					do {
						var deleteRow = Regex.Matches(textFile, patternToControl, RegexOptions.Singleline).Cast<Match>()
																	.Select(m => new KeyValuePair<string, int>(m.Value, textFile.IndexOf(m.Value))).OrderByDescending(item => item.Value).ToList();
						delete = deleteRow.Count > 1;
						if (delete)
							textFile = textFile.Remove(deleteRow[0].Value, deleteRow[0].Key.Length);
					}
					while (delete);

					File.WriteAllText(fullPath, textFile, enc);
				}


				var line = lines.First().Key;
				var newLine = Regex.Replace(line, patternToReplace, patternToReplace.Replace("(.*?)", newValue).Replace("\\r", "\r").Replace("\\n", "\n"));


				if (line != newLine) {
					textFile = textFile.Replace(line, newLine);
					File.WriteAllText(fullPath, textFile, enc);
				}


			}
			else {
				if (!replace) {
					//la linea non ÃƒÂ¨ presente la aggiungo
					int ultimaRiga;
					var newLine = String.Format("\t\t{0}", patternToReplace.Replace("(.*?)", newValue).Replace("\\r", "\r").Replace("\\n", "\n"));
					//solo se specificato verifico se ÃƒÂ¨ giÃƒÂ  esistente una riga dello stesso tipo per accodarla
					if (previousLikeValueExist != null) {
						string lastLine = Regex.Matches(textFile, "(\"|\\s|\\t|$)" + previousLikeValueExist + "(.*?)\r\n", RegexOptions.Singleline).Cast<Match>().Select(m => m.Value).ToList().LastOrDefault();
						if (lastLine != null) {
							ultimaRiga = textFile.LastIndexOf(lastLine) + lastLine.Count();
							textFile = textFile.Insert(ultimaRiga, newLine);
						}
						else {
							//se  la classe non ÃƒÂ¨ presente o non si ÃƒÂ¨ scelto di accodarla, la aggiungo in testa alla sezione
							ultimaRiga = textFile.LastIndexOf(mark) + mark.Length;
							textFile = textFile.Insert(ultimaRiga, newLine);
						}
					}
					else {
						//se  la classe non ÃƒÂ¨ presente o non si ÃƒÂ¨ scelto di accodarla, la aggiungo in testa alla sezione
						ultimaRiga = textFile.LastIndexOf(mark) + mark.Length;
						textFile = textFile.Insert(ultimaRiga, newLine);
					}
				}
				else {
					//effettuo la sostituzione partendo dal testo iniziale senza RemoveUnquotedWhiteSpaces

					var endPreviousRegion = "$\r\n\t\t";
					var position = initiallyText.LastIndexOf(endPreviousRegion) + endPreviousRegion.Length;
					initiallyText = initiallyText.Remove(position, initiallyText.IndexOf(mark) - position);
					initiallyText = initiallyText.Insert(position, newValue);
					textFile = initiallyText;
				}

				File.WriteAllText(fullPath, textFile, enc);
			}


		}


		/// <summary>
		///  Sostituisce/Aggiunge nel file LocalResourceFile il valore del campo classValue, toReplace, con il nuovo newValue 
		/// </summary>
		/// <param name="prefix"></param>
		/// <param name="classValue"></param>
		/// <param name="toReplace"></param>
		/// <param name="newValue"></param>
		private static void ReplaceStringInLocalResourceFile(string prefix, string classValue, string toReplace, string newValue) {

			var fullPathLocalResource = Path.Combine(clientFolder, "assets/i18n/LocalResourceIt.js");
			ReplaceRegExInFile(fullPathLocalResource, prefix, newValue, classValue + toReplace + @": ""(.*?)"",\r\n", classValue + toReplace, classValue);
		}



		#endregion

		/// <summary>
		/// Sostituisce nel file fullPath il valore del campo newValue, al posto delle stringhe che corrispondono al patternToReplace indicato 
		/// </summary>
		/// <param name="fullPath">percorso del file</param>
		/// <param name="newValue">stringa da scrivere</param>
		/// <param name="patternToReplace">pattern della riga da sostituire</param>
		/// <param name="patternToReplace">indica se il pattern va sostituito o gli va solamente aggiunto il valore indicato</param>
		private static string ReplaceRegExInFile(string fullPath, string patternToReplace, string toWrite, bool append = false) {
			//creato nuovo metodo per non aprire due volte il file e non toccare il vecchio metodo ReplaceStringInFile
			string textFile = TextFile.ReadAllTextFile(fullPath);
			var enc = TextFile.GetEncoding(fullPath);

			List<KeyValuePair<string, int>> lines = Regex.Matches(textFile, patternToReplace, RegexOptions.Singleline)
				.Cast<Match>().Select(m => new KeyValuePair<string, int>(m.Value, textFile.IndexOf(m.Value))).ToList();

			if (lines.Any()) {
				fileContainer.Add(new TextFile { FileName = fullPath, FileContent = textFile });
				var oldvalue = lines.First().Key;
				if (append) {
					var marker = "//" + oldvalue.Split(new string[] { "//" }, StringSplitOptions.RemoveEmptyEntries).ToList().Last();
					//lo aggiungo solo se non c'ÃƒÂ¨ giÃƒÂ 
					if (!oldvalue.Contains(toWrite.Replace(marker, ""))) {
						toWrite = oldvalue.Replace(marker, toWrite);
					}
					else
						//se giÃƒÂ  c'ÃƒÂ¨ esco subito
						return textFile;
				}
				textFile = textFile.Replace(oldvalue, toWrite);
				fileContainer.Add(new TextFile { FileName = fullPath, FileContent = textFile });
				File.WriteAllText(fullPath, textFile, enc);
			}
			return textFile;
		}

		/// <summary>
		/// Sostituisce nel file reperibile al percorso fullPath la stringa toReplace con quella toWrite
		/// </summary>
		/// <param name="fullPath">percorso del file</param>
		/// <param name="toReplace">stringa da sostituire</param>
		/// <param name="toWrite">stringa sostituta</param>
		/// <param name="skipCheckExistence">esclude il controllo dell'esistenza della stringa sul file</param>
		private static string ReplaceStringInFile(string fullPath, string toReplace, string toWrite, bool skipCheckExistence = false, bool CheckwithToReplace = false) {

			var enc = TextFile.GetEncoding(fullPath);
			string text = File.ReadAllText(fullPath, enc);
			if (text.Contains(toReplace) || text.Contains(toReplace.Replace("\r", ""))) //l'accapo inserito dal configuratore ÃƒÂ¨ solo \n e non \r\n
				if (
					   (!TextFile.RemoveUnquotedWhiteSpaces(text).Contains(TextFile.RemoveUnquotedWhiteSpaces(toWrite.Replace(toReplace, ""))) && !CheckwithToReplace)
					|| (!TextFile.RemoveUnquotedWhiteSpaces(text).Contains(TextFile.RemoveUnquotedWhiteSpaces(toWrite)) && CheckwithToReplace)
					|| toWrite == "default"
					|| toWrite == string.Empty
					|| skipCheckExistence
					) {
					fileContainer.Add(new TextFile { FileName = fullPath, FileContent = text });
					if (text.Contains(toReplace))
						text = text.Replace(toReplace, toWrite);
					else
						text = text.Replace(toReplace.Replace("\r", ""), toWrite);
					fileContainer.Add(new TextFile { FileName = fullPath, FileContent = text });
					File.WriteAllText(fullPath, text, enc);
				}
			return text;
		}

		private static void AppendStringInFile(string fullPath, string toWrite) {
			var enc = TextFile.GetEncoding(fullPath);
			string text = File.ReadAllText(fullPath, enc);
			if (!text.Contains(toWrite)) {
				text += "\r\n" + toWrite;
				File.WriteAllText(fullPath, text, enc);
			}
		}


		#endregion

		#region generazione html

		private static string GetGroupedColumns(List<field> fields, string summary, List<field> allfields, SqlConnection connection) {

			var output = new List<string>();

			foreach (var f in fields) {
				if (f.Summary == summary) {
					if (HaveKeyName(f) && !IsEnum(f, allfields, connection)) {
						//se sto raggruppando per un id (e NON un enum ovvero entitÃƒÂ  con chiave e testo uguali) probabilmente in realtÃƒÂ  voglio il text field della tabella di cui ÃƒÂ¨ chiave
						var secondaryTableText = GetTableById(f.Name, allfields, connection);
						var textFields = GetTextFieldByTable(secondaryTableText, allfields, connection, false);
						foreach (var tf in textFields) {
							if (HaveKeyName(tf) && !IsEnum(tf, allfields, connection)) {
								//ÃƒÂ¨ a sua volta un id quindi probabilmente in realtÃƒÂ  voglio il text field della tabella di cui ÃƒÂ¨ chiave
								var tertiaryTableText = GetTableById(tf.Name, allfields, connection);
								var tertiarytextFields = GetTextFieldByTable(tertiaryTableText, allfields, connection, false);
								foreach (var ttf in tertiarytextFields) {
									output.Add("!" + f.Name + "_" + secondaryTableText + "_" + tf.Name + "_" + ttf.Name);
								}
							}
							else {
								output.Add("!" + f.Name + "_" + secondaryTableText + "_" + tf.Name);
							}
						}
					}
					else {
						output.Add(f.Name);
					}
				}
			}

			return String.Join(";", output);
		}

		private static string GetGrid(obj o, tab tab, field fi, List<field> fields, List<field> subfields, List<field> allfields, string fullPathMetaPageJS, string fullPathTest, bool mdlexcludegroup,
			List<childColumn> childColumns, List<obj> objects, SqlConnection connection) {

			var formString = "";
			//tabella e edit type della griglia,calendario,checklist, ecc.
			var gridtable = fi.MetadatoChild ?? fi.Name.Substring(2);
			var edittype = fi.EditListingType;
			var gridId = "grid_" + gridtable + "_" + edittype;

			var radiotag = (fi.RelationType != "calendariow" & fi.RelationType != "calendario") ? GetRadioFieldsValues(gridtable, edittype, allfields, connection) : "";

			if (!string.IsNullOrWhiteSpace(radiotag))
				//aggiungo l'etichetta per la label dei lookup condizionali
				ReplaceStringInLocalResourceFile(RegionMarker.LocalResource_lookUpCondizionali, gridId, "conditionallookup", radiotag);


			//calcolo le colonne nipoti
			var originalTable = GetOriginalTableByForeignKey(fi);
			var originalextendedTable = GetOriginalExtendedTableByForeignKey(fi);
			var pageid = allfields.Where(af => af.Table == originalTable && af.EditListingType == edittype).Select(af => af.PageId).First();
			var actualNephews = GetChildentitiesFields(pageid, originalextendedTable, allfields, connection);
			foreach (var c in actualNephews) {
				var metadatoC = c.Name.Substring(2);
				SetMetadatoChild(fields.Union(actualNephews).Union(childColumns.Select(cc => cc.Nephew)).ToList(), c, metadatoC, ref allfields, connection);
			}
			var havechild = actualNephews.Any(c => c.ShowInParentGrid > 0);
			foreach (var c in actualNephews.Where(c => c.ShowInParentGrid > 0)) {
				childColumns.Add(new childColumn
				{
					ControlName = gridId,
					Tablename = gridtable,
					Tablechild = c.MetadatoChild,
					Columncalc = "!" + c.MetadatoChild,
					Columnlookup = GetTextFieldByTable(c.MetadatoChild, allfields, connection, true, c.Listtype).First().Name, //DEPRECATO
					EdittypeChild = c.Listtype,
					Edittype = edittype,
					Nephew = c,
					PageId = pageid
				});
			}

			switch (fi.RelationType) {
				default:
					//...disegno la grid
					//se ÃƒÂ¨ un oggetto estendente devo mettere l'oggetto esteso con edit type = estendente_edittype
					if (IsExtendingObject(gridtable, ref allfields, connection)) {
						edittype = gridtable.Split('_')[1] + "_" + edittype;
						gridtable = fi.MetadatoExtendedChild ?? fi.Name.Substring(2).Split('_')[0];
						if (fi.MetadatoExtendedChild == null)
							if (verbose)
								ConsoleWriter.WarningDB("La griglia " + gridtable + "." + edittype + "." + edittype + " ÃƒÂ© per un oggetto esteso ma non ho il valore dell'alias calcolato.");
					}

					var gridFields = allfields.Where(gf => gf.Table == gridtable && gf.EditListingType == edittype && gf.ListVisible).ToList();

					var grf = GetGroupedColumns(gridFields, "R", allfields, connection);
					var gra = GetGroupedColumns(gridFields, "A", allfields, connection);
					var gre = gridFields.Where(gf => gf.Editable);

					formString += "\t\t\t\t<div class=\"gridx\" id=\"" + gridId + "\" data-tag=\"" + gridtable + //qui ci va il nome della tabella
						"." + edittype + "." + edittype + "\" data-custom-control=\"" + (gre.Any() ? "gridxedit" : "gridx") + "" + (havechild ? "child" : "") + "\" " +
						(!gre.Any() ? "" : "data-mdleditinplacecolumns=\"" + string.Join(";", gre.Select(x => x.Name).ToList()) + "\" ") +
						(string.IsNullOrEmpty(grf) ? "" : "data-mdlgroupedcolumns=\"" + grf + "\" data-mdltotnotvisible ") +
						(string.IsNullOrEmpty(gra) ? "" : "data-mdlaggregatecolumns=\"" + gra + "\" ") +
						(fi.Buttoninsert ? " data-mdlbuttoninsert " : "") + (fi.Buttonedit ? "data-mdlbuttonedit " : "") + (fi.Buttondelete ? "data-mdlbuttondelete " : "") +
						(string.IsNullOrEmpty(radiotag) ? "" : "data-mdlconditionallookup=\"" + radiotag + "\"") + " " + (mdlexcludegroup ? "data-mdlexcludegroup" : "") + "></div>\r\n";

					//test

					if (fi.Savebeforetest) {
						SetArrayInputTest(fullPathTest, "{ tag: 'mainsave', type: controlTypeEnum.command }", fi);

					}

					SetArrayInputTest(fullPathTest, "{ tag: '" + gridtable + "." + edittype + "." + edittype + "', value:null, " +
						(fi.Numrowsmandatory > 1 ? "rows:" + fi.Numrowsmandatory + "," : "") + " columns:" + gridFields.Count.ToString() + "," +
						" type:controlTypeEnum.grid}", fi);
					break;
				case "tree":

					//...disegno la tree
					//se ÃƒÂ¨ un oggetto estendente devo mettere l'oggetto esteso con edit type = estendente_edittype
					if (IsExtendingObject(gridtable, ref allfields, connection)) {
						edittype = gridtable.Split('_')[1] + "_" + edittype;
						gridtable = fi.MetadatoExtendedChild ?? fi.Name.Substring(2).Split('_')[0];
						if (fi.MetadatoExtendedChild == null)
							if (verbose)
								ConsoleWriter.WarningDB("La griglia " + gridtable + "." + edittype + "." + edittype + " ÃƒÂ© per un oggetto esteso ma non ho il valore dell'alias calcolato.");
					}

					var treeFields = allfields.Where(gf => gf.Table == gridtable && gf.EditListingType == edittype && gf.ListVisible).ToList();

					//var trf = GetGroupedColumns(treeFields, "R", allfields, connection);
					//var tra = GetGroupedColumns(treeFields, "A", allfields, connection);
					//var tre = treeFields.Where(gf => gf.Editable);
					string treeId = gridtable + "_" + edittype + "_tree";
					formString += "\t\t\t\t<div id=\"" + treeId + "\" data-tag=\"" + gridtable + "." + edittype + "." + edittype + "\" data-custom-control=\"treecontrol\"" +
						" data-mdlbuttoninsert " + " data-mdlbuttonedit" + " data-mdlbuttondelete" + "></div>\r\n";

					if (fi.Savebeforetest) {
						SetArrayInputTest(fullPathTest, "{ tag: 'mainsave', type: controlTypeEnum.command }", fi);
					}

					SetArrayInputTest(fullPathTest, "{ tag: '" + gridtable + "." + edittype + "." + edittype + "', value:null, " +
						(fi.Numrowsmandatory > 1 ? "rows:" + fi.Numrowsmandatory + "," : "") + " columns:" + treeFields.Count.ToString() + "," +
						" type:controlTypeEnum.treecustom}", fi);
					var rootTextFields = GetTextFieldByTable(o.Table, allfields, connection, false, o.EditListingType);
					var treeTextFields = GetTextFieldByTable(gridtable, allfields, connection, false, edittype);
					string rootTitle = string.Empty;
					bool first = true;
					foreach (var textField in rootTextFields) {

						rootTitle += (first ? "" : "+") + "'" + textField.Title + ": '+  (this.state.currentRow." + textField.Name + "?  this.state.currentRow." + textField.Name + " +'; ' : '')";
						first = false;
					}
					SetBeforeFillAsinc(fullPathMetaPageJS, @"var ctrlTree =  $('#" + treeId + @"').data(""customController"");
					arraydef.push(ctrlTree.findAndSetRoot({
						rootTitle: " + rootTitle + @",
					   rootColumnNameTitle: '" + treeTextFields.First().Name + @"'
				}));
", o.Table, o.EditListingType);
					break;
				case "checkbox":
					//qui ci va il nome della tabella COLLEGATA (il vocabolario delle voci)
					var linkedtable = gridtable.Replace(o.Table, "");
					var linkedtablelisttype = "default";

					//ricavo il lyst type della tabella COLLEGATA (il vocabolario delle voci)
					var linkid = allfields.Where(f => f.IsLinkingObj && f.ListVisible && f.Table == gridtable && f.EditListingType == edittype).FirstOrDefault() ??
								allfields.Where(f => f.IsKey && f.ListVisible && f.Table == gridtable && f.EditListingType == edittype && HaveKeyName(f)).FirstOrDefault();
					if (linkid != null) {

						//tabella collegata con eventuali alias
						linkedtable = GetLinkedTable(linkid, ref fields, subfields, ref allfields, connection);

						if (!string.IsNullOrWhiteSpace(linkid.Listtype))
							linkedtablelisttype = linkid.Listtype;
					}

					//ricavo i campi da mostrare
					gridFields = GetfiledsByTableEditType(linkedtable, linkedtablelisttype, allfields).Where(gf => gf.ListVisible).ToList();

					//...disegno la grid
					formString += "		<div id=\"" + gridId + "\" data-tag=\"" + linkedtable + "." + linkedtablelisttype + "." + linkedtablelisttype + "\" data-custom-control=\"checklist\" " +
						(string.IsNullOrEmpty(radiotag) ? "" : "data-mdlconditionallookup=\"" + radiotag + "\"") + " ></div>\r\n";

					//test

					if (fi.Savebeforetest) {
						SetArrayInputTest(fullPathTest, "{ tag: 'mainsave', type: controlTypeEnum.command }", fi);

					}

					SetArrayInputTest(fullPathTest, "{ tag: '" + linkedtable + "." + linkedtablelisttype + "." + linkedtablelisttype + "', value:null, " +
						(fi.Numrowsmandatory > 1 ? "rows:" + fi.Numrowsmandatory + "," : "") + " columns:" + gridFields.Count.ToString() + "," +
						" type:controlTypeEnum.checklist}", fi);
					break;

				case "cerca": //per le tabelle di collegamento 

					var linkidManual = allfields.Where(f => f.IsLinkingObj && f.ListVisible && f.Table == gridtable && f.EditListingType == edittype).FirstOrDefault();

					if (IsLinkingObject(gridtable, ref allfields, connection) || linkidManual != null) {

						//tabella di collegamento
						var linktable = gridtable;
						//chiave sulla tabella di collegamento
						linkid = linkidManual ?? allfields.Where(f => f.IsKey && f.ListVisible && f.Table == linktable && f.EditListingType == edittype && HaveKeyName(f)).FirstOrDefault();

						if (linkid != null) {

							linkedtable = GetTableById(linkid.Name, allfields, connection);//tabella collegata

							gridFields = GetLinkingObjectFields(linktable, edittype, ref allfields, connection);
							grf = GetGroupedColumns(gridFields, "R", allfields, connection);
							gra = GetGroupedColumns(gridFields, "A", allfields, connection);
							gre = gridFields.Where(gf => gf.Editable);

							formString += "			<div class=\"row\">\r\n" +
									 "				<div class=\"col-md-9\">\r\n" +
									 "					<input id=\"txt_" + linktable + "_" + linkid.Name + "\" type=\"text\" class=\"form-control\" placeholder=\"...\" aria-label=\"Search\" />\r\n" +
									 "				</div>\r\n" +
									 "				<div class=\"col-md-3\">\r\n" +
									 "					<button id=\"btn_add_" + linktable + "_" + linkid.Name + "\" type=\"button\" class=\"btn btn-primary p-2 mt-1\">\r\n" +
									 "						<i class=\"fas fa-search-plus mr-1\"></i> Cerca e aggiungi " + fi.Text.Trim() + "\r\n" +
									 "					</button>\r\n" +
									 "				</div>\r\n" +
									 "			</div>\r\n" +
									 "			<hr>\r\n";

							formString += "\t\t\t\t<div class=\"gridx\" id=\"" + gridId + "\" data-tag=\"" + linktable +
								"." + edittype + "." + edittype + "\" data-custom-control=\"" + (gre.Any() ? "gridxedit" : "gridx") + "\" " +
								(!gre.Any() ? "" : "data-mdleditinplacecolumns=\"" + string.Join(";", gre.Select(x => x.Name).ToList()) + "\" ") +
								(string.IsNullOrEmpty(grf) ? "" : "data-mdlgroupedcolumns=\"" + grf + "\" data-mdltotnotvisible ") +
								(string.IsNullOrEmpty(gra) ? "" : "data-mdlaggregatecolumns=\"" + gra + "\" ") +
								(fi.Buttondelete ? "data-mdlbuttondelete " : "") + (fi.Buttonedit ? "data-mdlbuttonedit " : "") + (string.IsNullOrEmpty(radiotag) ? "" : "data-mdlconditionallookup=\"" + radiotag + "\"") + " " +
								(mdlexcludegroup ? "data-mdlexcludegroup" : "") + " ></div>\r\n";

							//test
							{
								var val = "";
								if (string.IsNullOrEmpty(linkid.Testvalue)) {

									var q = "";
									var table = linkedtable.Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[0];
									var listtype = string.IsNullOrWhiteSpace(linkid.Listtype) ? "default" : linkid.Listtype;
									var linkedtextfield = GetTextFieldByTable(linkedtable, allfields, connection, false, listtype).FirstOrDefault();
									var linkedtextfieldName = linkedtextfield.Name;



									if (HaveView(table, listtype, ref allfields, connection)) {
										linkedtextfieldName = "dropdown_title";
										//qualora ci fosse una vista per questo list type allora devo selezionare un elemento da li
										q = "select dropdown_title from " + (table.Contains("_") ? table.Replace("_", "") : table + listtype) + "view";

										//FILTRO WHERE
										//qualora ci fosse un filtro statico lo devo applicare io come farebbe il framework al metadato vista...
										//... o ce l'ho giÃƒÂ  in elenco
										var acObj = objects.Where(aco => aco.Table == table && aco.EditListingType == listtype).FirstOrDefault();
										//... o me lo devo caricare da db
										if (acObj == null && partialGeneration) {
											SqlCommand cmdobj = new SqlCommand("select staticfilter from apppages where tablename = '" + table + "' and  " +
												(listtype == "default" ? " (editlistingtype is null or editlistingtype = '')" : " editlistingtype = '" + listtype + "' "), connection);
											cmdobj.CommandTimeout = 120;
											SqlDataReader dataReaderobj = null;
											try {
												dataReaderobj = cmdobj.ExecuteReader();
												var colonneobj = new DataTable();
												colonneobj.Load(dataReaderobj);
												if (colonneobj.Rows.Count > 0)
													acObj = new obj { Staticfilter = colonneobj.Rows[0]["staticfilter"].ToString() };
											}
											catch {
											}
										}
										if (acObj != null)
											if (!string.IsNullOrWhiteSpace(acObj.Staticfilter))
												q += " where " + acObj.Staticfilter;

										//ORDINAMENTO
										q += " order by dropdown_title";

									}
									else {
										//se ÃƒÂ¨ un oggetto estendente devo prendere solo i valori che si trovano su entrambe le tabelle
										var joinstring = "";
										if (table != linkedtextfield.Table) {
											var keys = GetIdByTable(table, allfields, connection);
											var extendedlinktable = table.Split('_')[0];
											joinstring += " INNER JOIN " + extendedlinktable + " ON ";
											var addend = false;
											foreach (var key in keys) {
												joinstring += (addend ? " AND " : "") + table + "." + key + " = " + extendedlinktable + "." + key;
												addend = true;
											}
										}
										var schema = GetSchemaByTable(table, allfields, connection, false);
										q = "select " + (!string.IsNullOrWhiteSpace(schema) ? schema + "." : "") + linkedtextfield.Table + "." + linkedtextfieldName +
											" from " + (!string.IsNullOrWhiteSpace(schema) ? schema + "." : "") + table + joinstring;
										if (allfields.Any(af => af.Name == "active" && af.Table == table))
											q += " where active = 'S'";

									}

									SqlCommand cmdTest = new SqlCommand(q, connection);
									cmdTest.CommandTimeout = 120;
									try {
										var dataReaderTest = cmdTest.ExecuteReader();
										var colonneTest = new DataTable();
										colonneTest.Load(dataReaderTest);
										if (colonneTest.Rows.Count > 0) {
											val = colonneTest.Rows[0][linkedtextfieldName].ToString();
											if (string.IsNullOrWhiteSpace(val) && colonneTest.Rows.Count > 1)
												foreach (DataRow r in colonneTest.Rows)
													if (!string.IsNullOrWhiteSpace(r[linkedtextfieldName].ToString())) {
														val = r[linkedtextfieldName].ToString();
														break;
													}
											val = val.Replace("'", "\\'").Replace("\r", "").Replace("\n", "");

										}
										else
											ConsoleWriter.ErrorDB("Impossibile costruire il test per la grid con ricerca " + gridtable + "." + edittype + "." + edittype);
									}
									catch (Exception e) {
										ConsoleWriter.ErrorDB("Impossibile costruire il test per la grid con ricerca " + gridtable + "." + edittype + "." + edittype +
											" La query per recuperare il valore era:\r\n " + q + "\r\ne ha restituito il seguente errore: " + e.Message +
											"\r\nVerificare se era presente un filtro statico errato sul metadato " + linkedtable);
									}
								}
								else
									val = linkid.Testvalue.Substring(1, linkid.Testvalue.Length - 2);

								if (!string.IsNullOrEmpty(val)) {
									if (fi.Savebeforetest) {
										SetArrayInputTest(fullPathTest, "{ tag: 'mainsave', type: controlTypeEnum.command }", fi);

									}
									SetArrayInputTest(fullPathTest, "{ tag: '" + gridtable + "." + edittype + "." + edittype + "', value:'" + val + "', " +
										(fi.Numrowsmandatory > 1 ? "rows:" + fi.Numrowsmandatory + "," : "") + " columns:" + gridFields.Count.ToString() + "," +
										"txtId: 'txt_" + linktable + "_" + linkid.Name + "', functSearchAndAssign: 'searchAndAssign" + linkid.MetadatoChild + "', type:controlTypeEnum.gridsearch}", fi);
								}
							}
						}
					}

					break;
				case "calendariow":
				case "calendario":

					var title = fi.CalendarSettings.Split(';')[0];
					if (string.IsNullOrEmpty(title)) {
						var txtfield = GetTextFieldByTable(gridtable, allfields, connection).FirstOrDefault();
						title = txtfield.Name;
						if (belongsToOtherTable(gridtable, txtfield)) {
							//mi ÃƒÂ¨ stato restituito il campo testuale dell'oggetto da cui deriva quindi devo cercare lÃƒÂ¬
							gridtable = txtfield.Table;
						}
					}
					var start = fi.CalendarSettings.Split(';')[1];
					if (string.IsNullOrEmpty(start)) {
						var startfield = allfields.Where(af => af.Table == gridtable && af.EditListingType == edittype && af.Name.StartsWith("start")).FirstOrDefault();
						if (startfield != null)
							start = startfield.Name;
					}
					var stop = fi.CalendarSettings.Split(';')[2];
					if (string.IsNullOrEmpty(stop)) {
						var stopfield = allfields.Where(af => af.Table == gridtable && af.EditListingType == edittype && af.Name.StartsWith("stop")).FirstOrDefault();
						if (stopfield != null)
							stop = stopfield.Name;
					}
					var ded = !(start ?? "").Contains("!") && !(stop ?? "").Contains("!");
					var maincolor = fi.CalendarSettings.Split(';')[3];
					//...disegno la grid
					//formString += "		<div class=\"row\">\r\n			<div class=\"col-md-12\">\r\n		<div class=\"gridx\" id=\"grid" + fields.IndexOf(fi) +
					//	"\" data-tag=\"" + table + //qui ci va il nome della tabella
					//	"." + edittype + "." + edittype + "\" data-custom-control=\"gridx\" data-mdlbuttoninsert " +
					//	(IsLinkingObject(table, ref allfields, connection) ? "" : "data-mdlbuttonedit") + " data-mdlbuttondelete></div>\r\n			</div>\r\n		</div>\r\n";
					//...disegno il calendario
					formString += "\t<hr>\r\n\t\t<div class=\"row\">\r\n\t\t\t<div class=\"col-md-12\">\r\n" +
						"\t\t\t\t<div id=\"calendar" + fields.IndexOf(fi) +
					"\" data-tag=\"" + gridtable + "." + edittype + "." + edittype + "\" data-custom-control=\"calendar\"  data-mdltitlecolumnname=\"" + title + "\" " +
					(string.IsNullOrEmpty(start) ? "" : "  data-mdlstartcolumnname=\"" + start + "\" ") +
					(string.IsNullOrEmpty(stop) ? "" : "  data-mdlstopcolumnname=\"" + stop + "\" ") +
					(string.IsNullOrEmpty(maincolor) ? "" : "  data-mdlmaincolor=\"" + maincolor + "\" ") +
					(fi.Buttoninsert ? " data-mdlbuttoninsert " : "") + (fi.Buttonedit ? "data-mdlbuttonedit " : "") + (fi.Buttondelete ? "data-mdlbuttondelete " : "") +
					(ded ? "data-mdldragdrop " : "") + (fi.RelationType == "calendariow" ? "data-mdlweekend " : "") + "></div>\r\n			</div>\r\n		</div>\r\n";

					//test

					if (fi.Savebeforetest) {
						SetArrayInputTest(fullPathTest, "{ tag: 'mainsave', type: controlTypeEnum.command }", fi);

					}
					SetArrayInputTest(fullPathTest, "{ tag: '" + gridtable + "." + edittype + "." + edittype + "', value:null, " +
						(fi.Numrowsmandatory > 1 ? "rows:" + fi.Numrowsmandatory + "," : "") + " type:controlTypeEnum.calendar}", fi);
					break;


			}

			if (fi.MasterField != null) {
				var masterfield = allfields.Where(af => af.IdAppFieldDetail == fi.MasterField).FirstOrDefault();
				if (masterfield != null)
					SetInsertClick(fullPathMetaPageJS, "if (!$('#" + masterfield.Table + "_" + masterfield.EditListingType + "_" + masterfield.Name +
						"').val() && grid.dataSourceName === '" + gridtable + "') {\r\n" +
						"\t\t\t\t\treturn this.showMessageOk('Prima devi selezionare un valore per il campo " + masterfield.Title.Replace("'", "\\'") + "');\r\n" +
						"\t\t\t\t}\r\n");
			}

			return formString;

		}

		private static string WriteAutochoose(obj o, string editListingTypes, tab tab, field fi, List<field> fields, List<field> allfields, List<obj> objects, string nametag,
			string metadatoChild, string listtype, string metadatochildWithText, field txtField, string fullPathMetaPageJS, string fullPathTest, string fullPathTestParams, SqlConnection connection) {
			var formString = "";
			//Autochoose
			// punto direttamente la tabella con i valori tanto il MDLW fa tutto da solo collegando le chiavi

			//se ÃƒÂ¨ un oggetto ÃƒÂ¨ estendente allora devo usare il suo list type specifico
			if (fi.Name.Contains("_")) {
				var extended = fi.Name.Split('_')[0].Substring(2);
				var ex = GetException(null, fi.Name.Split('_')[0], null, null);
				if (ex != null) {
					extended = ex.Item1;
				}
				var extending = extended + "_" + fi.Name.Split('_')[1];
				GetMissingFields(extending, null, ref allfields, connection);

				if (allfields.Any(af => af.Table == extending))
					listtype = fi.Name.Split('_')[1];
				else {
					if (verbose)
						Console.WriteLine("INFO: " + fi.Name + " ÃƒÂ¨ un indice con suffisso e non di una tabella estendente.");
				}
			}

			formString +=
			"					<label class=\"col-form-label col-md-12\" for=\"" + nametag + "\">" + fi.Title + "</label>\r\n" +
			"					<div data-tag=\"AutoChoose." + nametag + "." + listtype + "\">\r\n" +
			"						<input id=\"" + nametag + "\" name=\"" + nametag + "\" type=\"text\" class=\"form-control\" data-tag=\"" +
							  metadatochildWithText + "." + txtField.Name + "\" data-subentity placeholder=\"...\" " + (fi.Allownull ? "" : "data-mandatory ") + "/>\r\n" +
			"					</div>\r\n";

			//se ÃƒÂ¨ un id della tabella ma anche di un parent verrebbe disabilitato quindi lo riabilito
			if (fi.IsKey)
				SetReadonly(fi, nametag, fullPathMetaPageJS, o, editListingTypes, false);

			//test
			{
				var table = metadatochildWithText.Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[0];

				//qualora ci fosse una vista per questo list type allora devo selezionare un eleento da li
				var qview = "select * from " + table + listtype + "view";
				//qualora ci fosse un filtro statico lo devo applicare io come farebbe il framework al metadato vista...
				//... o ce l'ho giÃƒÂ  in elenco
				var acObj = objects.Where(aco => aco.Table == table && aco.EditListingType == listtype).FirstOrDefault();
				//... o me lo devo caricare da db
				if (acObj == null && partialGeneration) {
					SqlCommand cmdobj = new SqlCommand("select staticfilter from apppages where tablename = '" + table + "' and  " +
						(listtype == "default" ? " (editlistingtype is null or editlistingtype = '')" : " editlistingtype = '" + listtype + "' "), connection);
					cmdobj.CommandTimeout = 120;
					SqlDataReader dataReaderobj = null;
					try {
						dataReaderobj = cmdobj.ExecuteReader();
						var colonneobj = new DataTable();
						colonneobj.Load(dataReaderobj);
						if (colonneobj.Rows.Count > 0)
							acObj = new obj { Staticfilter = colonneobj.Rows[0]["staticfilter"].ToString() };
					}
					catch {
					}
				}
				if (acObj != null)
					if (!string.IsNullOrWhiteSpace(acObj.Staticfilter))
						qview += " where " + acObj.Staticfilter;

				SqlCommand cmdTest = new SqlCommand(qview, connection);
				cmdTest.CommandTimeout = 120;
				SqlDataReader dataReaderTest = null;
				try {
					dataReaderTest = cmdTest.ExecuteReader();
				}
				catch {
					//se ÃƒÂ¨ un oggetto estendente devo prendere solo i valori che si trovano su entrambe le tabelle
					var joinstring = "";
					if (table != metadatoChild) {
						var keys = GetIdByTable(table, allfields, connection);
						joinstring += " INNER JOIN " + metadatoChild + " ON ";
						var addend = false;
						foreach (var key in keys) {
							joinstring += (addend ? " AND " : "") + table + "." + key + " = " + metadatoChild + "." + key;
							addend = true;
						}
					}
					var schema = GetSchemaByTable(table, allfields, connection, false);
					var q = "select " + (!string.IsNullOrWhiteSpace(schema) ? schema + "." : "") + table + "." + txtField.Name +
			" from " + (!string.IsNullOrWhiteSpace(schema) ? schema + "." : "") + table + joinstring;
					if (allfields.Any(af => af.Name == "active" && af.Table == table))
						q += " where active = 'S'";

					cmdTest.CommandText = q;
					dataReaderTest = cmdTest.ExecuteReader();
				}
				var colonneTest = new DataTable();
				colonneTest.Load(dataReaderTest);
				if (colonneTest.Rows.Count > 0) {
					string val = colonneTest.Rows[0][txtField.Name].ToString();
					if (string.IsNullOrWhiteSpace(val) && colonneTest.Rows.Count > 1)
						foreach (DataRow r in colonneTest.Rows)
							if (!string.IsNullOrWhiteSpace(r[txtField.Name].ToString())) {
								val = r[txtField.Name].ToString();
								break;
							}
					val = val.Replace("'", "\\'");
					//test
					SetArrayInputTest(string.IsNullOrWhiteSpace(fullPathTestParams) ? fullPathTest : fullPathTestParams,
						"{ tag: '" + metadatochildWithText + "." + txtField.Name +
					"', valueSearch: '" + val + "', value: '" + val + "', type: controlTypeEnum.inputAutoChoose" +
					(!string.IsNullOrEmpty(fi.Defaultvalue) ? ", default: " + fi.Defaultvalue + " " : "") + " }", fi);
				}
				else
					ConsoleWriter.ErrorDB("Impossibile costruire il test per l'atochoose " + metadatochildWithText + "." + txtField.Name);
			}

			return formString;
		}

		private static string WriteDropdowngrid(obj o, string editListingTypes, tab tab, field fi, List<field> fields, List<field> allfields, List<obj> objects, string nametag,
			string metadatoChild, string listtype, string metadatochildWithText, field txtField, string fullPathMetaPageJS, string fullPathTest, string fullPathTestParams, SqlConnection connection) {
			var formString = "";

			//se ÃƒÂ¨ un oggetto ÃƒÂ¨ estendente allora devo usare il suo list type specifico
			var extended = "";
			var isExtended = false;
			if (fi.Name.Contains("_")) {
				extended = fi.Name.Split('_')[0].Substring(2);
				var ex = GetException(null, fi.Name.Split('_')[0], null, null);
				if (ex != null) {
					extended = ex.Item1;
				}
				var extending = extended + "_" + fi.Name.Split('_')[1];

				GetMissingFields(extended, null, ref allfields, connection);
				GetMissingFields(extending, null, ref allfields, connection);

				if (allfields.Any(af => af.Table == extending)) {
					listtype = fi.Name.Split('_')[1];
					isExtended = true;
				}
				else {
					if (verbose)
						Console.WriteLine("INFO: " + fi.Name + " ÃƒÂ¨ un indice con suffisso e non di una tabella estendente.");
				}
			}

			var table = metadatochildWithText.Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[0];
			var viewName = table + listtype + "view";
			var isView = HaveView(table, listtype, ref allfields, connection);
			var haveActiveField = HaveActiveField(table, listtype, ref allfields, connection);

			//calcolo il datatag in base al fatto se ho trovato la vista oppure no
			var datatag = "";
			var textColName = "";
			if (isView) {
				textColName = "dropdown_title";
				//riassegno il metadato alla vista, in modo da corstruirci gli alias se necessario
				fi.MetadatoChild = null;
				fi.MetadatoExtendedChild = null;
				SetMetadatoChild(fields, fi, viewName, ref allfields, connection);
				datatag = fi.MetadatoChild + ".dropdown_title";
			}
			else {
				textColName = txtField.Name;
				datatag = metadatochildWithText + "." + textColName;
			}

			//se c'ÃƒÂ¨ un campo "active" deve essere filtrato in fase di inserimento
			if (allfields.Any(af => af.Name == "active"
									&& af.Table == (isExtended ? extended : metadatoChild)
									&& af.EditListingType == listtype)) {

				var field = "active";

				if (isView && !string.IsNullOrEmpty(extended)) {
					field = extended + "_active";
				}
				else if (isView) {
					field = metadatoChild + "_active";
				}

				SetBeforeFill(fullPathMetaPageJS,
					"if (this.state.isSearchState()) {\r\n" +
					"\t\t\t\t\tthis.helpForm.filter($('#" + nametag + "'), null);\r\n" +
					"\t\t\t\t} else {\r\n" +
					"\t\t\t\t\tthis.helpForm.filter($('#" + nametag + "'), this.q.eq('" + field + "', 'S" + (isView ? "i" : "") + "'));\r\n" +
					"\t\t\t\t}\r\n"
					, o.Table, editListingTypes);
				SetAfterClear(fullPathMetaPageJS, "this.helpForm.filter($('#" + nametag + "'), null);\r\n", true);
			}


			//test
			if (!fi.Readonlyfield)
				if (string.IsNullOrWhiteSpace(fi.Testvalue)) {
					SqlDataReader dataReaderTest = null;

					if (isView) {
						//qualora ci fosse una vista per questo list type allora devo selezionare un elemento da li
						var qview = "select dropdown_title from " + viewName + (haveActiveField ? " where " + table + "_active = 'Si'" : "");

						//FILTRO WHERE
						//qualora ci fosse un filtro statico lo devo applicare io come farebbe il framework al metadato vista...
						//... o ce l'ho giÃƒÂ  in elenco
						var acObj = objects.Where(aco => aco.Table == table && aco.EditListingType == listtype).FirstOrDefault();
						//... o me lo devo caricare da db
						if (acObj == null && partialGeneration) {
							SqlCommand cmdobj = new SqlCommand("select staticfilter from apppages where tablename = '" + table + "' and  " +
								(listtype == "default" ? " (editlistingtype is null or editlistingtype = '')" : " editlistingtype = '" + listtype + "' "), connection);
							cmdobj.CommandTimeout = 120;
							SqlDataReader dataReaderobj = null;
							try {
								dataReaderobj = cmdobj.ExecuteReader();
								var colonneobj = new DataTable();
								colonneobj.Load(dataReaderobj);
								if (colonneobj.Rows.Count > 0)
									acObj = new obj { Staticfilter = colonneobj.Rows[0]["staticfilter"].ToString() };
							}
							catch {
							}
						}
						if (acObj != null)
							if (!string.IsNullOrWhiteSpace(acObj.Staticfilter))
								if (!acObj.Staticfilter.Contains("{"))
									qview += (haveActiveField ? " and " : " where ") + acObj.Staticfilter;

						//ORDINAMENTO
						qview += " order by dropdown_title";

						SqlCommand cmdTest = new SqlCommand(qview, connection);
						cmdTest.CommandTimeout = 120;
						try {
							dataReaderTest = cmdTest.ExecuteReader();
						}
						catch {
							ConsoleWriter.ErrorDB("Il dropdowngrid " + metadatoChild + " risultava avere la vista ma non ÃƒÂ¨ stata trovata per costruire il test");
						}
					}
					else {
						if (verbose)
							Console.WriteLine("INFO: il dropdowngrid " + metadatoChild + " non usa la vista per costruire il test");
						//se ÃƒÂ¨ un oggetto estendente devo prendere solo i valori che si trovano su entrambe le tabelle
						var joinstring = "";
						if (table != metadatoChild) {
							var keys = GetIdByTable(table, allfields, connection);
							joinstring += " INNER JOIN " + metadatoChild + " ON ";
							var addend = false;
							foreach (var key in keys) {
								joinstring += (addend ? " AND " : "") + table + "." + key + " = " + metadatoChild + "." + key;
								addend = true;
							}
						}
						var schema = GetSchemaByTable(table, allfields, connection, false);
						var q = "select " + (!string.IsNullOrWhiteSpace(schema) ? schema + "." : "") + table + "." + txtField.Name +
							  " from " + (!string.IsNullOrWhiteSpace(schema) ? schema + "." : "") + table + joinstring;
						if (haveActiveField)
							q += " where active = 'S'";

						//ORDINAMENTO
						var txt = allfields.Where(af => af.Table == metadatoChild && af.EditListingType == listtype && af.ListVisible && af.Textfield == 1).FirstOrDefault();
						if (txt != null)
							q += " order by " + txt.Name;

						SqlCommand cmdTest = new SqlCommand(q, connection);
						cmdTest.CommandTimeout = 120;
						try {
							dataReaderTest = cmdTest.ExecuteReader();
						}
						catch {
							ConsoleWriter.ErrorDB("Il dropdowngrid " + metadatoChild + " risultava avere la vista ma non ÃƒÂ¨ stata trovata per costruire il test");
						}

					}

					if (dataReaderTest != null) {
						var colonneTest = new DataTable();
						colonneTest.Load(dataReaderTest);

						if (colonneTest.Rows.Count > 0) {
							var val = colonneTest.Rows[0][textColName].ToString();

							//se la prima riga ÃƒÂ¨ vuota vado avanti sulle successive
							if (string.IsNullOrWhiteSpace(val) && colonneTest.Rows.Count > 1)
								foreach (DataRow r in colonneTest.Rows)
									if (!string.IsNullOrWhiteSpace(r[textColName].ToString())) {
										val = r[textColName].ToString();
										break;
									}

							val = val.Replace("'", "\\'").Replace("\r", "").Replace("\n", "");
							//test
							SetArrayInputTest(string.IsNullOrWhiteSpace(fullPathTestParams) ? fullPathTest : fullPathTestParams,
								"{ tag: '" + datatag + "', valueSearch: '" + val + "', value: '" + val + "', type: controlTypeEnum.dropdowngrid " +
							(!string.IsNullOrEmpty(fi.Defaultvalue) ? ", default: " + fi.Defaultvalue + " " : "") + " }", fi);
						}
						else
							ConsoleWriter.ErrorDB("Impossibile costruire il test per il dropdowngrid " + metadatochildWithText + "." + txtField.Name);
					}
					else
						ConsoleWriter.ErrorDB("Impossibile costruire il test per il dropdowngrid " + metadatochildWithText + "." + txtField.Name);
				}
				else {
					SetArrayInputTest(string.IsNullOrWhiteSpace(fullPathTestParams) ? fullPathTest : fullPathTestParams,
						  "{ tag: '" + datatag + "', valueSearch: " + fi.Testvalue + ", value: " + fi.Testvalue + ", type: controlTypeEnum.dropdowngrid " +
						(!string.IsNullOrEmpty(fi.Defaultvalue) ? ", default: " + fi.Defaultvalue + " " : "") + " }", fi);
				}

			formString +=
			"					<label class=\"col-form-label col-md-12\" for=\"" + nametag + "\">" + fi.Title + "</label>\r\n" +
			"					<div>\r\n" +
			"						<input id=\"" + nametag + "\" name=\"" + nametag + "\" type=\"text\" data-listtype=\"" + listtype + "\"  class=\"form-control\" data-minchar=\"" + fi.Charnumber +
			"\" data-tag=\"" + datatag + "\" data-subentity data-custom-control=\"dropdowngrid\" autocomplete=\"off\" placeholder=\"...\" " + (fi.Allownull ? "" : "data-mandatory ") + "/>\r\n" +
			"					</div>\r\n";

			if (IsAddictedDropdown(fi, ref allfields, connection)) {
				var masterTable = fi.Master.Replace("defaultview", "");
				var masterkeys = GetPrincipalKey(masterTable, null, allfields, connection, true);
				//var childkey = GetChildKeysString(masterTable, fi.MetadatoChild, "default", fi.Listtype, new List<string>() { masterkeys.Name }, allfields, connection, true).Trim();
				//if (string.IsNullOrWhiteSpace(childkey))
				//	childkey = GetChildForeignKeysString(masterTable, fi.MetadatoChild, "default", fi.Listtype, new List<string>() { masterkeys.Name }, allfields, connection, false).Trim().Split(';')[0].Trim();
				var childkey = masterkeys.Name;
				var slaveField2 = GetChildKeysbyMaster(fi.Master, GetFields(fi.MetadatoChild, fi.Listtype, ref allfields, connection), allfields, connection, !string.IsNullOrWhiteSpace(fi.AfterRowSelectPrefill));
				if (slaveField2.Count() == 2)
					childkey = slaveField2[1].Name;

				SetAfterRowSelect(fullPathMetaPageJS,
					"if (t.name === \"" + fi.Master + "\" && r !== null) {\r\n" +
					(string.IsNullOrWhiteSpace(fi.AfterRowSelectPrefill) ?
					  "\t\t\t\t\tthis.state.DS.tables." + fi.MetadatoChild + ".staticFilter(window.jsDataQuery.eq(\"" + childkey + "\", r." + masterkeys.Name + "));\r\n" +
					  "\t\t\t\t\tif (this.state.DS.tables." + fi.MetadatoChild + ".rows.length)\r\n" +
					  "\t\t\t\t\t\tif (this.state.DS.tables." + fi.MetadatoChild + ".rows[0]." + childkey + " !== r." + masterkeys.Name + ") {\r\n" +
					  "\t\t\t\t\t\t\tthis.state.DS.tables." + fi.MetadatoChild + ".clear();\r\n" +
					  "\t\t\t\t\t\t\t$('#" + nametag + "').val('');\r\n" +
					  "\t\t\t\t\t\t}\r\n"
					  : fi.AfterRowSelectPrefill) +
					"\t\t\t\t}\r\n"
					, null, o.Table, editListingTypes);
			}
			return formString;
		}

		#endregion

		#region creazione/aggiornamento della struttura di un nuova applicazione


		private static void ApplicationManagement() {

			try {

				ConsoleWriter.Title("STRUTTURA APPLICAZIONE");
				ConsoleWriter.verbose = true;


				ConsoleWriter.Control("Controllo che esista la cartella del progetto client '{0}', se non esite la creo", clientFolder);

				DirectoryInfo clientFolderInfo = new DirectoryInfo(clientFolder);
				clientChildFolder = clientFolderInfo.Name;

				var createDatePackageRow = DateTime.Now.ToString("yyyy_MM_dd");

				string clientName = new System.IO.DirectoryInfo(clientFolder).Name;

				//controllo se esiste la cartella del progetto a cui stiamo facendo riferimento, se non esite la copio dal target
				if (!Directory.Exists(clientFolder)) {

					CopyDir("../../appclient_template", clientFolder);
					ConsoleWriter.OK("Cartella del progetto client creata, effettuo sostituzioni");

					//file metadata di applicazione
					string metaDataPagePath = Path.Combine(clientFolder, metapageFolder, String.Format("Meta{0}Data.js", currentApp));
					if (File.Exists(metaDataPagePath)) File.Delete(metaDataPagePath);
					File.Move(Path.Combine(clientFolder, metapageFolder, "Meta_template_Data.js"), metaDataPagePath);
					ReplaceStringInFile(metaDataPagePath, "$template$", currentApp);

					//file metapage di applicazione
					string metaPagePath = Path.Combine(clientFolder, metapageFolder, String.Format("Meta{0}Page.js", currentApp));
					if (File.Exists(metaPagePath)) File.Delete(metaPagePath);
					File.Move(Path.Combine(clientFolder, metapageFolder, "Meta_template_Page.js"), metaPagePath);
					ReplaceStringInFile(metaPagePath, "$template$", currentApp);

					string metaAppPath = Path.Combine(clientFolder, metapageFolder, String.Format("Meta{0}App.js", currentApp));
					if (File.Exists(metaAppPath)) File.Delete(metaAppPath);
					File.Move(Path.Combine(clientFolder, metapageFolder, "Meta_template_App.js"), metaAppPath);
					ReplaceStringInFile(metaAppPath, "$template$", currentApp);


					//file index di debug
					string indexDebugPagePath = Path.Combine(clientFolder, "indexDebug.html");
					ReplaceStringInFile(indexDebugPagePath, "$template$", currentApp);
					ReplaceStringInFile(indexDebugPagePath, "$title$", currentTitle, true);
					ReplaceStringInFile(indexDebugPagePath, "$appMainConfigPath$", "../config/" + clientName + "/appMainConfig.js", true);

					//file del menÃƒÂ¹
					string menuBuilderPath = Path.Combine(clientFolder, "menubuilder/", "menuBuilder.js");
					ReplaceStringInFile(menuBuilderPath, "$idMenu$", idmenu);

					ConsoleWriter.OK("Sostituzioni effettuate nei file della cartella client");
				}
				else ConsoleWriter.OK("Cartella client giÃƒÂ  presente");

				//ConsoleWriter.Info("Controllo che esista la cartella di configuarzione");

				//string distFolder = Path.Combine(Directory.GetParent(clientFolder).FullName, "config", clientName);

				ConsoleWriter.Control("Controllo che esista la cartella di test '{0}' a cui stiamo facendo riferimento, se non esite la creo", testFolder);
				//controllo esistenza cartella test se non esiste la creo a ggiorno il 
				if (!Directory.Exists(testFolder)) {
					DirectoryInfo testDirectory = Directory.CreateDirectory(testFolder);
					ConsoleWriter.OK("Cartella dei test creata");
					var stringfilefullPathMetaDato = Path.Combine(testDirectory.Parent.Parent.FullName, "karma_e2e_App_produzione.conf.js");
					var textFilekarma = TextFile.ReadAllTextFile(stringfilefullPathMetaDato);
					//aggiungo al file karma_e2e_App_produzione.conf.js il nuovo progetto              
					var appEnum = String.Format(@"{0}: ""{0}""", currentApp);
					if (!textFilekarma.Contains(appEnum)) {
						ReplaceStringInFile(stringfilefullPathMetaDato, "var appEnum = {", String.Format(@"var appEnum = {{
        {0},", appEnum));
						string caseAppEnum = String.Format(@"
        case appEnum.{0}:
            appTestDIR = '{1}';
            appDIR = '{1}';
            // classi derivate dal framework     
            files.push(appDIR + '/metadata/Meta{0}Page.js');
            files.push(appDIR + '/metadata/Meta{0}Data.js');
            files.push(appDIR + '/metadata/Toast.js');
			files.push(appDIR + '/cambioruolo.js');
            break;", currentApp, clientChildFolder);
						ReplaceStringInFile(stringfilefullPathMetaDato, "switch (appToTest){", String.Format(@"switch (appToTest){{ {0}", caseAppEnum));
					}
					ConsoleWriter.OK("Sostituzioni effettuate nei file della cartella test");
				}
				else ConsoleWriter.OK("Cartella test giÃƒÂ  presente");

				ConsoleWriter.Control("Controllo l'esistenza del file delle credenziali per il test");
				var testButtonFile = Path.Combine(testFolder, "AAA_loginConfigTest.js");
				if (!File.Exists(testButtonFile)) {
					//aggiungo il file per i test dei bottoni visibili, inizialmente con l'utenza riccardotest da sostituire con quella che si utilizzerÃƒÂ  per l'applicazione
					File.Copy(@"..\..\test_template\AAA_loginConfigTest.js", testButtonFile);

					ConsoleWriter.OK("File delle credenziali per il test creato");
				}
				else ConsoleWriter.OK("File delle credenziali per il test giÃƒÂ  esistente");

				var webpackPath = Path.Combine(clientFolderInfo.Parent.FullName, "webpack");
				string webpackIndexPath = Path.Combine(webpackPath, String.Format("index{0}.js", currentApp));
				ConsoleWriter.Control("Controllo che esista la cartella del webpack e che sia popolata con l'index '{0}' se non esite lo creo", webpackIndexPath);
				if (Directory.Exists(webpackPath)) {
					if (!File.Exists(webpackIndexPath)) {
						File.Copy("../../webpack_template/index_template.js", webpackIndexPath);
						ReplaceStringInFile(webpackIndexPath, "$template$", clientChildFolder, true);
						ReplaceStringInFile(webpackIndexPath, "$currentApp$", currentApp, true);
						ConsoleWriter.OK("File creato");
					}
					else ConsoleWriter.OK("Cartella e File giÃƒÂ  presenti");
				}
				else ConsoleWriter.ErrorDB("Cartella {0} non esistente, file {0} non creato", webpackPath, webpackIndexPath);

				ConsoleWriter.Control("Controllo che esista la riga del progetto nel file package.json");
				var packageJsonPath = Path.Combine(clientFolderInfo.Parent.FullName, "package.json");
				if (!File.Exists(packageJsonPath)) {
					ConsoleWriter.ErrorDB("Il file package.json non esiste, riga del progetto non aggiunta");
				}
				else {
					var textFilepackageJson = TextFile.ReadAllTextFile(packageJsonPath);
					var buildPackageRow = String.Format(@"""build_{0}"": ""webpack --config webpack.config.js --mode production --env={0}"",", currentApp);
					if (!textFilepackageJson.Contains(buildPackageRow)) {
						string packageJsonScript = @"""scripts"": {" + System.Environment.NewLine + "    " + buildPackageRow;
						ReplaceStringInFile(packageJsonPath, @"""scripts"": {", packageJsonScript);
						ConsoleWriter.OK("Riga del nuovo progetto crata nel file package.json");
					}
					else {
						//string packageline = File.ReadAllLines(packageJsonPath).ToList().Where(item => item.Contains(buildPackageRow)).First();
						//int startPosition = packageline.IndexOf(String.Format("--env={0},", currentApp)) + String.Format("--env={0},", currentApp).Length;
						//createDatePackageRow = packageline.Substring(startPosition, (packageline.LastIndexOf("\",") - startPosition));
						ConsoleWriter.OK("Riga del nuovo progetto giÃƒÂ  esistente nel file package.json");
					}
				}

				ConsoleWriter.Control("Controllo esistenza delle cartelle per gli script SQL");
				var ScriptFolder = clientFolder + scriptFolder;
				var ScriptLUFolder = ScriptFolder.Replace("/ScriptSQL", "/ScriptLU");

				//directorymove non funziona se non esiste la cartella clientName nella cartella client/scripts
				if (!Directory.Exists(ScriptFolder)) {
					Directory.CreateDirectory(ScriptFolder.Replace("/ScriptSQL", ""));// "../../../../../progetti/Portale/client/scripts/" + clientName);
					Directory.Move(Path.Combine(clientFolder, "ScriptSQL"), ScriptFolder);
				}
				else ConsoleWriter.OK("Cartella per gli script di installazione giÃƒÂ  presente");
				if (!Directory.Exists(ScriptLUFolder)) {
					Directory.CreateDirectory(ScriptLUFolder);
				}
				else ConsoleWriter.OK("Cartella per gli script di aggiornamento giÃƒÂ  presente");


				ConsoleWriter.Control("Controllo esistenza del file di configurazione");
				string configFolder = "../../../../../progetti/Portale/client/config/" + clientName;
				string indexPagePath = Path.Combine(clientFolder, "index.html");
				if (!Directory.Exists(configFolder)) {
					Directory.CreateDirectory(configFolder);
					CopyDir("../../appmainconfig_template", configFolder);
				}
				else ConsoleWriter.OK("Cartella di configurazione giÃƒÂ  presente");

				ConsoleWriter.Control("Controllo esistenza del file index.html e la corrispondenza della versione del bundle");
				if (!File.Exists(indexPagePath)) {
					ConsoleWriter.ErrorDB("Il file index.html non esiste");
				}
				else {
					ReplaceStringInFile(indexPagePath, "$template$", currentApp, true);
					ReplaceStringInFile(indexPagePath, "$title$", currentTitle, true);
					ReplaceStringInFile(indexPagePath, "$version$", createDatePackageRow, true);
					ReplaceStringInFile(indexPagePath, "$appMainConfigPath$", "../config/" + clientName + "/appmainconfig.js", true);
					var textFileIndex = TextFile.ReadAllTextFile(indexPagePath);
					string indexLine = File.ReadAllLines(indexPagePath).ToList().Where(item => item.Contains("<!--mdlw-bundle-file-->")).FirstOrDefault();
					if (indexLine != null) {
						string oldDatePackageRow = string.Join("_", indexLine.Split('.')[2].Split('_').Reverse().Take(3).Reverse());
						//sostituisco la data del nuovo bundle nel riferimento dello script
						if (oldDatePackageRow != createDatePackageRow) {
							var newProdLine = indexLine.Replace(oldDatePackageRow, createDatePackageRow);
							ReplaceStringInFile(indexPagePath, indexLine, newProdLine, true);
							ConsoleWriter.OK("Versione bundle sostituita");
						}
						ConsoleWriter.OK("File index.html OK");
					}
					else
						ConsoleWriter.ErrorDB("Il file index non contiene il marcatore <!--mdlw-bundle-file-->");
				}

				string buildBundleBATFilePath = Path.Combine(webpackPath, String.Format("BUILD_BUNDLE_JS_{0}.bat", currentApp));
				ConsoleWriter.Control("Controllo che esista la cartella BIND_BUNDLE e il file '{0}' se non esite lo creo", buildBundleBATFilePath);
				if (Directory.Exists(webpackPath)) {
					if (!File.Exists(buildBundleBATFilePath)) {
						File.Copy("../../build_bundle_js_template/BUILD_BUNDLE_JS_template.bat", buildBundleBATFilePath);
						ReplaceStringInFile(buildBundleBATFilePath, "$template$", currentApp);
						ConsoleWriter.OK("File BIND_BUNDLE creato");
					}
					else ConsoleWriter.OK("File BIND_BUNDLE giÃƒÂ  presente");
				}
				else ConsoleWriter.ErrorDB("Cartella BIND_BUNDLE non presente");
			}

			catch (Exception ex) {
				ConsoleWriter.ErrorDB("Errori durante la gestione del progetto: {0} ", ex.Message);
			}

			//ConsoleWriter.ViewErrors();
		}


		#endregion

		#region creazione store procedure
		public static void CreateSP(string text, SqlConnection connection) {

			string spName = string.Empty;
			string fileName;
			try {
				ConsoleWriter.Info("RECUPERO IL NOME DELLA STORED DAL TESTO INTRODOTTO ");

				var rx = new Regex(@"\s+", RegexOptions.Compiled);

				var data = rx.Split(text);

				//se c'ÃƒÂ¨ altro prima prendo la prima istanza di CREATE
				int first = data.ToList().IndexOf("CREATE");

				//Effettuo i controlli sul formato
				if (data[first].ToUpper() != "CREATE" || data[first + 1].ToUpper() != "PROCEDURE")
					throw new Exception("La stored non ÃƒÂ¨ nel formato corretto");

				if (data.Count() > 3)
					spName = data[first + 2];
				else throw new Exception("La stored non ÃƒÂ¨ nel formato corretto");

				//recupero il suo nome che poi verrÃƒÂ  dato al file

				fileName = spName.Replace("[", "").Replace("]", "").Replace("dbo.", "");

				ConsoleWriter.Info("CREO LA STORED {0} ", !String.IsNullOrEmpty(spName) ? spName + "SU DB" : "");

				//Inizio a costruire la stored, cancellandola se esiste

				if (!text.Contains("DROP PROCEDURE")) {

					var spText = String.Format(@"-- CREAZIONE PROCEDURE {0}
IF EXISTS (select * from sysobjects where id = object_id(N'{0}') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE {0}
GO
", spName);
					text = spText + text;
				}

				text = text.TrimEnd();

				if (!text.EndsWith("GO")) {
					text += "\r\nGO\r\n";
				}

				ConsoleWriter.Info("ESEGUO LA STORED {0} ", spName);


				using (TransactionScope scope = new TransactionScope()) {

					using (SqlCommand command = new SqlCommand()) {
						command.Connection = connection;

						var scripts = text.Split(new String[] { "GO\r\n", "GO ", "GO\t", "\r\nGO ", "\nGO\n" }, StringSplitOptions.None);
						foreach (var splitScript in scripts.Where(item => !string.IsNullOrEmpty(item.Trim()))) {
							//var quotedScript = splitScript.Replace("'", "''");
							var quotedScript = splitScript;
							command.CommandText = (quotedScript.LastIndexOf("GO") > 0) ? quotedScript.Remove(quotedScript.LastIndexOf("GO"), quotedScript.Length - quotedScript.LastIndexOf("GO")) : quotedScript;
							command.ExecuteNonQuery();
						}
					}



					//Salvo la stored nella cartella degli script e calcolo il suo nome
					fileName = String.Format("zy_{0}.sql", fileName);
					string fullPath = Path.Combine(clientFolder + scriptFolder, fileName);

					if (File.Exists(fullPath))
						File.Delete(fullPath);

					File.WriteAllText(fullPath, text);

					scope.Complete();

					ConsoleWriter.Info("SALVO LA STORED {0} NEL FILE {1} ", spName, fileName);

					ConsoleWriter.OK("La stored {0} ÃƒÂ¨ stata creata correttamente", spName);

				}

			}
			catch (Exception ex) {
				ConsoleWriter.ErrorDB("La creazione della stored non ÃƒÂ¨ andata a buon fine: {0}", ex.Message);

			}


		}



		#endregion

	}

	#region classi di appoggio

	public class obj {
		public string Table { get; set; }
		public string Title { get; set; }
		public string Principale { get; set; }
		public string EditListingType { get; set; }
		public string PageId { get; set; }
		public string ParentMenuId { get; set; }
		public string Using { get; set; }
		public string Code { get; set; }
		public string Reference { get; set; }
		public string Header { get; set; }
		public string Footer { get; set; }
		public string Icon { get; set; }
		public string CustomJavascript { get; set; }
		public string Staticfilter { get; set; }
		public string SearchEnabled { get; set; }
		public string CanInsert { get; set; }
		public string CanInsertCopy { get; set; }
		public string CanSave { get; set; }
		public string CanCancel { get; set; }
		public string CanCmdClose { get; set; }
		public string CanShowLast { get; set; }
		public bool OthersApp { get; set; }
		public string IsValid { get; set; }
		public bool Anonimous { get; set; }
		public bool IsVoc { get; set; }
		public bool Autosearch { get; set; }
		public string Calendartitle { get; set; }
		public string Calendarstart { get; set; }
		public string Calendarstop { get; set; }
		public bool Testcustom { get; set; }
		public List<string> AdditionalTables { get; set; }
		public bool Createmetapage { get; set; }
		public string BeforeFillSinc { get; set; }
		public int ForceAlias { get; set; }
		public string TestcustomText { get; set; }
		public bool IsTree { get; set; }
	}

	class tab {
		public string Title { get; set; }
		public int Sort { get; set; }
		public string PageId { get; set; }
		public string Icon { get; set; }
		public string Tabheader { get; set; }
	}

	public class field {
		public string Title { get; set; }
		public string Type { get; set; }
		public int Len { get; set; }
		public int Sort { get; set; }
		public string Tab { get; set; }
		public string Name { get; set; }
		public string Table { get; set; }
		public bool IsKey { get; set; }
		public bool Detailvisible { get; set; }
		public int SortList { get; set; }
		public int Tabposition { get; set; }
		public bool ListVisible { get; set; }
		public bool Allownull { get; set; }
		public string ViewAlias { get; set; }
		public string SortData { get; set; }
		public string MetadatoChild { get; set; }
		public string MetadatoExtendedChild { get; set; }
		public string EditListingType { get; set; }
		public string PageId { get; set; }
		public string Defaultvalue { get; set; }
		public string LookupFor { get; set; }
		public string Icon { get; set; }
		public string RelationType { get; set; }
		public int Textfield { get; set; }
		public string Radiovalues { get; set; }
		public string PageIdParent { get; set; }
		public string CalendarSettings { get; set; }
		public bool IsLinkingObj { get; set; }
		public bool Hidden { get; set; }
		public string Listtype { get; set; }
		public string Filter { get; set; }
		public string Schema { get; set; }
		public bool Textarea { get; set; }
		public bool IsCheckbox { get; set; }
		public string Text { get; set; }
		public bool UniqueOnRow { get; set; }
		public string Tabheader { get; set; }
		public int Numrowsmandatory { get; set; }
		public bool Savebeforetest { get; set; }
		public bool Readonlyfield { get; set; }
		public string Master { get; set; }
		public string TableFilter { get; set; }
		public bool Buttoninsert { get; set; }
		public bool Buttondelete { get; set; }
		public bool Buttonedit { get; set; }
		public string Calculatedfieldfunction { get; set; }
		public string LookupTable { get; set; }
		public string Testvalue { get; set; }
		public string Summary { get; set; }
		public string IsAltTitle { get; set; }
		public bool DenyNull { get; set; }
		public string FilterJs { get; set; }
		public bool HaveView { get; set; }
		public bool IsUniqueField { get; set; }
		public string Prefix { get; set; }
		public int Charnumber { get; set; }
		public int ForceAlias { get; set; }
		public bool ForceDropDown { get; set; }
		public int? MasterField { get; set; }
		public int? IdAppFieldDetail { get; set; }
		public int ShowInParentGrid { get; set; }
		public string AfterActivationPrefill { get; set; }
		public string AfterRowSelectPrefill { get; set; }
		public string TableTitle { get; set; }
		public string EventType { get; set; }
		public string EventText { get; set; }
		public bool IsInVoc { get; set; }
		public int? IdAppFieldDetail_sortmember { get; set; }
		public bool Editable { get; set; }
		public bool IsView { get; set; }
		public string Specialcontrol { get; set; }
		public int? Val1 { get; set; }
		public int? Min { get; set; }
		public int? Max { get; set; }
		public int? Val2 { get; set; }
	}

	class buttonField {
		public string Title { get; set; }
		public string Name { get; set; }
		public string Code { get; set; }
		public string Parameter { get; set; }
		public string Icon { get; set; }
		public string Tab { get; set; }
		public string Refresh { get; set; }
		public string Javascript { get; set; }
		public string StoreProcedure { get; set; }
		public string Position { get; set; }
	}

	class textField {
		public string Column { get; set; }
		public int FirstIndex { get; set; }
		public int SecondIndex { get; set; }
		public string ColumnName { get; set; }
		public int ThirdIndex { get; set; }
	}

	class childColumn {
		public string ControlName { get; set; }
		public string Tablename { get; set; }
		public string Tablechild { get; set; }
		public string Edittype { get; set; }
		public string EdittypeChild { get; set; }
		public string Columnlookup { get; set; }
		public string Columncalc { get; set; }
		public field Nephew { get; set; }
		public string PageId { get; set; }
	}

	public class TextFile {
		public string FileName { get; set; }
		public string FileContent { get; set; }

		public static bool operator ==(TextFile lf, TextFile rf) {
			if (lf == null || rf == null) {
				return false;
			}
			return lf.FileContent == rf.FileContent && lf.FileName == rf.FileName;
		}

		public static bool operator !=(TextFile lf, TextFile rf) {
			return !(lf == rf);
		}
		//problemi su copia file .voc.sql
		public static Encoding GetEncoding(string filename) {

			// Read the BOM
			var bom = new byte[4];
			using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read)) {
				file.Read(bom, 0, 4);

				// Analyze the BOM

				//UTF-8with and without BOM
				if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf)
					return Encoding.UTF8;
				else {
					BinaryReader r = new BinaryReader(file, System.Text.Encoding.Default);
					int i;
					int.TryParse(file.Length.ToString(), out i);
					byte[] ss = r.ReadBytes(i);
					if (IsUTF8Bytes(ss))
						return Encoding.UTF8;
				}
			}

			if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76) return Encoding.UTF7;
			if (bom[0] == 0xff && bom[1] == 0xfe) return Encoding.Unicode; //UTF-16LE
			if (bom[0] == 0xfe && bom[1] == 0xff) return Encoding.BigEndianUnicode; //UTF-16BE
			if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff) return Encoding.UTF32;

			////testing if is ANSI or UTF-8 without BOM
			//if (bom[0] == 0x28 && bom[1] == 0x66 && bom[2] == 0x75)
			//	enc = Encoding.UTF8;
			//if (bom[0] == 0x2f && bom[1] == 0x2a && bom[2] == 0x2a)
			//	enc = Encoding.UTF8;

			return Encoding.Default; //ANSI without BOM;
		}

		private static bool IsUTF8Bytes(byte[] data) {
			int charByteCounter = 1;
			byte curByte;
			for (int i = 0; i < data.Length; i++) {
				curByte = data[i];
				if (charByteCounter == 1) {
					if (curByte >= 0x80) {
						while (((curByte <<= 1) & 0x80) != 0) {
							charByteCounter++;
						}

						if (charByteCounter == 1 || charByteCounter > 6) {
							return false;
						}
					}
				}
				else {
					if ((curByte & 0xC0) != 0x80) {
						return false;
					}
					charByteCounter--;
				}
			}
			if (charByteCounter > 1) {
				ConsoleWriter.ErrorDB("Error byte format");
				throw new Exception("Error byte format");
			}
			return true;
		}

		/// <summary>
		/// Restituisce la string adel contenuto del file con il corretto encoding
		/// </summary>
		/// <param name="fullpath">full path del file</param>
		/// <returns></returns>
		public static string ReadAllTextFile(string fullpath) {
			return File.ReadAllText(fullpath, GetEncoding(fullpath));
		}

		//da suddividere " e ' a seconda di codice server  client 
		public static string RemoveUnquotedWhiteSpaces(string text) {
			string result = String.Empty;
			var parts = text.Split('"');
			for (int i = 0; i < parts.Length; i++) {
				if (i % 2 == 0) result += Regex.Replace(parts[i], " ", "");
				else result += String.Format("\"{0}\"", parts[i]);
			}

			return result.Replace("\r", "").Replace("\n", "").Replace("\t", "");

		}

	}

	public class TextFileCollection {
		public List<TextFile> originalList = new List<TextFile>();
		public List<TextFile> actualList = new List<TextFile>();

		/// <summary>
		/// aggiunge il file a due collection: la prima volta a quella dei file originali e successivamente a quelli modificati
		/// </summary>
		/// <param name="tfile"></param>
		public void Add(TextFile tfile) {
			if (actualList.Any(f => f.FileName == tfile.FileName)) {
				actualList.Where(f => f.FileName == tfile.FileName).First().FileContent = tfile.FileContent;
			}
			else {
				actualList.Add(tfile);
				originalList.Add(new TextFile { FileContent = tfile.FileContent, FileName = tfile.FileName });
			}
		}

		public void Add(string file) {
			var enc = TextFile.GetEncoding(file);
			string text = File.ReadAllText(file, enc);
			Add(new TextFile { FileName = file, FileContent = text });
		}

		public List<string> GetChangedFiles() {
			var output = new List<string>();
			foreach (var actual in actualList) {
				var original = originalList.Where(o => o.FileName == actual.FileName).First();
				if (TextFile.RemoveUnquotedWhiteSpaces(actual.FileContent) != TextFile.RemoveUnquotedWhiteSpaces(original.FileContent)) {
					output.Add(actual.FileName);
				}
			}
			return output;
		}
	}
	#endregion

	#region help class

	public static class ConsoleWriter {

		public static bool verbose = true;

		private static string title = string.Empty;

		private static StringBuilder ERRORS = new StringBuilder();

		public static SqlConnection connection;

		public static int apppages;

		public static int id;

		public static void ErrorDB(string message, params object[] args) {
			writeDB(Error(message, args));
		}

		/// <summary>
		/// Visualizza un errore
		/// </summary>
		/// <param name="message"></param>
		/// <param name="args"></param>
		public static string Error(string message, params object[] args) {

			Console.ForegroundColor = ConsoleColor.Red;
			if (!ERRORS.ToString().Contains(title))
				ERRORS.AppendLine(title);
			message = String.Format("  ERROR: " + message, args);
			ERRORS.AppendLine(message);
			Console.WriteLine(message);
			Console.ResetColor();
			return message;
		}

		/// <summary>
		/// Elenca tutti gli errori avvenuti durante il processo
		/// </summary>
		public static void ViewErrors() {
			if (verbose && ERRORS.Length > 0) {
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("\n\n GLI ERRORI PRESENTI SONO:");
				Console.WriteLine(ERRORS);
				Console.ResetColor();
			}
		}

		public static void InfoDB(string message, params object[] args) {
			if (verbose) {
				writeDB(Info(message, args));
			}

		}

		/// <summary>
		/// Visualizza un informazione/suggerimento
		/// </summary>
		/// <param name="message"></param>
		/// <param name="args"></param>
		public static string Info(string message, params object[] args) {
			if (verbose) {
				Console.ForegroundColor = ConsoleColor.Green;
				message = String.Format("  INFO: " + message, args);
				Console.WriteLine(message);
				Console.ResetColor();
			}
			return message;
		}

		public static void WarningDB(string message, params object[] args) {
			writeDB(Warning(message, args));
		}

		/// <summary>
		/// Visualizza un informazione/suggerimento
		/// </summary>
		/// <param name="message"></param>
		/// <param name="args"></param>
		public static string Warning(string message, params object[] args) {
			Console.ForegroundColor = ConsoleColor.Yellow;
			message = String.Format("  WARNING: " + message, args);
			Console.WriteLine(message);
			Console.ResetColor();
			return message;
		}

		/// <summary>
		/// Documenta un controllo/azione che viene effettuato
		/// </summary>
		/// <param name="message"></param>
		/// <param name="args"></param>
		public static void Control(string message, params object[] args) {
			if (verbose) {
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine("\n" + message, args);
				Console.ResetColor();
			}
		}

		public static void OKDB(string message, params object[] args) {
			if (verbose) {
				writeDB(OK(message, args));
			}
		}

		/// <summary>
		/// Notifica che un controllo/azione sono andati a buon fine 
		/// </summary>
		/// <param name="message"></param>
		/// <param name="args"></param>
		public static string OK(string message, params object[] args) {
			if (verbose) {
				Console.ForegroundColor = ConsoleColor.Green;
				message = String.Format(message, args);
				Console.WriteLine(message);
				Console.ResetColor();
			}
			return message;
		}

		/// <summary>
		/// Visualizza una nuova area di azioni 
		/// </summary>
		/// <param name="message"></param>
		public static void Title(string message) {
			if (verbose) {
				Console.ForegroundColor = ConsoleColor.Black;
				Console.BackgroundColor = ConsoleColor.White;
				title = String.Format("\n\n{0}{1}\n\n", "".PadRight(30, '-'), message.PadRight(60, '-'));
				Console.WriteLine(title);
				Console.ResetColor();
			}
		}

		private static void writeDB(string message) {
			string insert = String.Format(@"INSERT INTO [dbo].[applogging] ([id],[message],[date],[idapppages])  VALUES  ({0},'{1}',GETDATE(),{2})", id, message.Replace("'", "''"), apppages.ToString());
			var cmd = new SqlCommand(insert, connection);
			try { cmd.ExecuteNonQuery(); }
			catch (Exception e) {
				Console.WriteLine(e.Message);
			}
		}
	}

	public static class RegionMarker {

		public const string MetaData_customCode = "\r\n\t\t//$CustomCode$";
		public const string MetaData_getStaticFilte = "\r\n\t\t//$GetStaticFilter$";


		public const string LocalResource_colonne = "// colonne\r\n";
		public const string LocalResource_nomiTab = "// nomi tab\r\n";
		public const string LocalResource_labels = "// lables\r\n";
		public const string LocalResource_labelSuHtml = "// label su html\r\n";
		public const string LocalResource_lookUpCondizionali = "// lookup condizionali\r\n";

	}

	#endregion

}