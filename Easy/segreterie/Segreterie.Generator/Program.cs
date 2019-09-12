/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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

﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Segreterie.Generator
{
	class Program
	{
		//schema di come i path sono relativi uno all'altro
		//solutionfolder/metadataFolder (nella versione finale coincidono)
		//backendFolder/data
		//clientFolder/metapageFolder

		private static string solutionFolder = "../../../../Segreterie/VisualMDLW/VisualMDLW.Metadata/";  //cartella della solution dei metadati c#
		private static string solutionFile = "VisualMDLW.Metadata.sln";
		private static string backendFolder = "../../../../../progetti/Portale/Backend/"; //cartella del bakend
		private static string clientFolder = "../../../../../progetti/Portale/client/VisualMDLW/"; //cartella del client
		private static string metapageFolder = "metadata/"; //destinazione delle pagine js
		private static string idmenu = "110"; //destinazione delle pagine js
		private static string dllCoreFolder = "../../../../../dll/";
		private static string dllOutputFolder = @"..\..\..\..\Progetti\portale\libraries";

		//private static string solutionFolder = "../../../../";  //cartella della solution dei metadati c#
		//private static string solutionFile = "Segreterie_metadata.sln";
		//private static string backendFolder = "../../../../../progetti/Portale/Backend/"; //cartella del bakend
		//private static string clientFolder = "../../../../../progetti/Portale/client/app_segreterie/"; //cartella del client
		//private static string metapageFolder = "metadata/"; //destinazione delle pagine js
		//private static string idmenu = "29"; //destinazione delle pagine js
		//private static string dllCoreFolder = "../../dll/";
		//private static string dllOutputFolder = @"output";

		//nino
		//private static string connectionString="Data Source=DBSERVER;Initial Catalog=DATABASE;Persist Security Info=True;User ID=assistenza;Password=PASSWORD";
		//bari
		//private static string connectionString="Data Source=DBSERVER;Initial Catalog=DATABASE;Persist Security Info=True;User ID=assistenza;Password=PASSWORD";
		private static string connectionString="Data Source=DBSERVER;Initial Catalog=unibas_easy;Persist Security Info=True;User ID=assistenza;Password=PASSWORD";

		private static bool verbose = true;
		private static string metadataFolder = "";  //destinazione dei metadati c# rispetto alla solution

		private static bool skipView = false; //true per non riscrivere la vista sul db
		private static bool skipmetadato = false; //true saltare tutto il metadato
		private static bool skipmetapage = false; //true saltare tutto il backend e metapage
		private static bool skipmetapageproject  = false; //true per non scrivere sulla solution del backend
		private static bool skipmetapageDataset  = false; //true per non scrivere sul dataset del backend
		private static int verIncrement = 0;

		private static int applicationID = 1; //1 visualMDLW, 2 Segreterie, 3 INSTM utenti

		private static string queryFields =
			@"					select
					--TABELLA OGGETTO
					isc.TABLE_NAME as tablename, isnull(td.title, ttd.title) as title, isc.TABLE_SCHEMA as [schema],
					--CAMPO OGGETTO
					isc.COLUMN_NAME as field, cd.description,
					CASE WHEN EXISTS(
							SELECT * FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE k
							WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + QUOTENAME(CONSTRAINT_NAME)), 'IsPrimaryKey') = 1
							AND k.TABLE_NAME = isc.TABLE_NAME AND  k.COLUMN_NAME = isc.COLUMN_NAME
						) 
					THEN 'S' ELSE 'N' END as iskey,
					isc.DATA_TYPE as sqltype, isc.CHARACTER_MAXIMUM_LENGTH as col_len,  
					--TABELLA INTERFACCIA
					td.idapppages, td.principale, isnull(td.editlistingtype,'default') as editlistingtype, td.idmenuweb,
					td.customusing, td.customcode, td.customreference, td.header, td.footer, td.icon, td.vocabolario,
					td.customjavascript, td.staticfilter, td.autosearch, td.isvalid, td.anonimous, td.othersapp,
					td.caninsert, td.caninsertcopy, td.cancancel, td.cansearch, td.cancmdclose, td.cansave, td.canshowlast, 
					--TAB 
					t.title as tab, t.position as tabposition, t.icon as tabicon, t.header as tabheader,
					--CAMPO ELENCO
					fl.position,
					isnull(fl.position,
						ROW_NUMBER() OVER(PARTITION BY isc.TABLE_NAME,td.editlistingtype ORDER BY CASE 
						WHEN isc.COLUMN_NAME = 'id' + isc.TABLE_NAME THEN 'aaaa' + isc.COLUMN_NAME 
						WHEN isc.COLUMN_NAME = 'title' THEN 'aaa' + isc.COLUMN_NAME 
						WHEN isc.COLUMN_NAME = 'description' THEN 'aa' + isc.COLUMN_NAME 
						WHEN isc.COLUMN_NAME in  ('ct','cu', 'lt', 'lu') THEN 'zz' + isc.COLUMN_NAME 
						ELSE isc.COLUMN_NAME END)) as listposition, 
						CASE WHEN isc.COLUMN_NAME in ('ct','cu', 'lt', 'lu') THEN 'N' ELSE isnull(fl.visible,'S') END as listvisible, 
					isnull(fl.getsorting, CASE WHEN isc.COLUMN_NAME = 'title' THEN 'desc' END)  as getsorting,
					isnull(fl.textfield, CASE 
						WHEN isc.COLUMN_NAME = 'title' THEN 1 
						WHEN isc.COLUMN_NAME = 'description' THEN 2 
						ELSE 0 END) as textfield,
					fl.filter,
					--CAMPO DETTAGLIO
					isnull(fd.position,ROW_NUMBER() OVER(PARTITION BY isc.TABLE_NAME,td.editlistingtype ORDER BY CASE 
						WHEN isc.COLUMN_NAME = 'id' + isc.TABLE_NAME THEN 'aaaa' + isc.COLUMN_NAME 
						WHEN isc.COLUMN_NAME = 'title' THEN 'aaa' + isc.COLUMN_NAME 
						WHEN isc.COLUMN_NAME = 'description' THEN 'aa' + isc.COLUMN_NAME
						WHEN isc.COLUMN_NAME in  ('ct','cu', 'lt', 'lu') THEN 'zz' + isc.COLUMN_NAME 
						ELSE isc.COLUMN_NAME END)) as detailposition, 
						CASE WHEN isc.COLUMN_NAME in ('ct','cu', 'lt', 'lu') THEN 'N' ELSE isnull(fd.visible,'S') END as detailvisible ,
					isnull(fd.isnullable, CASE WHEN isc.IS_NULLABLE = 'YES' THEN 'S' ELSE 'N' END) as allownull,
					isnull(replace(replace(isc.COLUMN_DEFAULT,'(''',''),''')','') ,fd.defaultvalue) as defaultvalue,
					fd.radiovalues, fd.islinkingobj, fd.title as alttitle, fd.hidden, fd.listtype, fd.textarea, fd.ischeckbox, fd.text, fd.uniqueonrow
					from information_schema.columns isc  
					left outer join tabledescr ttd on isc.TABLE_NAME = ttd.tablename 
					left outer join apppages td on isc.TABLE_NAME = td.tablename 
					left outer join applicazione a on a.idapplicazione = td.idapplicazione
					left outer join coldescr cd on isc.TABLE_NAME = cd.tablename and isc.COLUMN_NAME = cd.colname
					left outer join appfielddetail fd on fd.columnname = isc.COLUMN_NAME and fd.idapppages = td.idapppages
					left outer join apptab t on t.idapppages = td.idapppages and t.idapptab = fd.idapptab
					left outer join appfieldlist fl on fl.columnname = isc.COLUMN_NAME and fl.idapppages = td.idapppages ";

		//per marcare i metadati quando vengono utilizzati da più interfacce per non rigenerarli
		private static List<string> alreadyCreated = new List<string>();

		static void Main(string[] args) {

			var HDSGen = new HDSGeneVSIX.HDSGene();

			using (var connection = new SqlConnection(connectionString)) {
				connection.Open();

				var queryApp = @"select * from applicazione where idapplicazione = " + applicationID;

				SqlCommand cmd = new SqlCommand(queryApp, connection);
				var appsDataReader = cmd.ExecuteReader();
				var apps = new DataTable();
				apps.Load(appsDataReader);

				foreach (DataRow r in apps.Rows) {
					solutionFolder = r["metadati"].ToString();
					solutionFile = r["solutionfile"].ToString();
					backendFolder = r["backend"].ToString();
					clientFolder = r["client"].ToString();
					metapageFolder = r["metapagefolder"].ToString();
					dllCoreFolder = r["dllcorefolder"].ToString();
					idmenu = r["idmenuweb"].ToString();
					dllOutputFolder = r["dlloutputfolder"].ToString();
				}

				//filtro finale
				var queryColonne = queryFields +  @" where a.idapplicazione = " + applicationID + @" --and (

				--	ANAGRAFICA BASE [N.B. FARE REVERT DI META_LOCATION E META_REGISTRY SUBITO DOPO !!!!]
				--	isc.TABLE_NAME = 'upb' 
				--  or isc.TABLE_NAME like 'geo_nation' 
				--	or isc.TABLE_NAME like 'registryaddress' 
				--	or isc.TABLE_NAME like 'location%' 

				--  isc.TABLE_NAME = 'titolostudio' 
				--  or isc.TABLE_NAME = 'aoo' 
				--	OR isc.TABLE_NAME like 'contratto%'
				--	OR isc.TABLE_NAME like 'publicaz'
				--  isc.TABLE_NAME like 'sasd%'
				--  or isc.TABLE_NAME like 'areadidattica'
				--  or isc.TABLE_NAME like 'istitutokind'
				--	OR isc.TABLE_NAME like 'sospensione%'
				--	OR isc.TABLE_NAME like 'rendicont%'

				--DIDATTICA
				-- isc.TABLE_NAME = 'lezione' 
				-- OR isc.TABLE_NAME like '%classconsorsuale%'
				-- OR isc.TABLE_NAME like 'prova%'
				-- or isc.TABLE_NAME like 'corsostudio%'
				-- or isc.TABLE_NAME like 'didprog%'
				-- or isc.TABLE_NAME like 'classescuola%'
				-- or isc.TABLE_NAME like 'insegn%'
				-- or isc.TABLE_NAME like 'attivform%'
				-- or isc.TABLE_NAME like 'mutuazione%'
				-- or isc.TABLE_NAME like 'affidamento%'

				--INSTM
				--	or isc.TABLE_NAME like 'registry_instmuser%' 
				--	OR isc.TABLE_NAME like 'publicaz%'
				--	OR isc.TABLE_NAME like 'itineration'
				--	OR isc.TABLE_NAME like 'address'
					 										--)
				order by ttd.tablename, cd.colname";

				cmd = new SqlCommand(queryColonne, connection);
				cmd.CommandTimeout = 60;
				var dataReader = cmd.ExecuteReader();
				var colonne = new DataTable();
				colonne.Load(dataReader);

				//primo ciclo su tutto per individuare gli oggetti
				var objects = new List<obj>();

				foreach (DataRow r in colonne.Rows) {
					//faccio la distinct degli oggetti
					if (!objects.Any(o => o.Table == r["tablename"].ToString() &&
										  o.EditListingType == (string.IsNullOrEmpty(r["editlistingtype"].ToString()) ? "default" : r["editlistingtype"].ToString())))

						////da non rifare!!!!!!!
						//if (r["tablename"].ToString() != "upb" &&
						//	r["tablename"].ToString() != "geo_city" && r["tablename"].ToString() != "geo_country" && r["tablename"].ToString() != "geo_region" &&
						//	r["tablename"].ToString() != "geo_nation" && r["tablename"].ToString() != "geo_continent"
						//	//&& !r["tablename"].ToString().StartsWith("registry")
						//	//&& !r["tablename"].ToString().StartsWith("location")
						//	)

						objects.Add(new obj {
							Table = r["tablename"].ToString(),
							Title = (r["title"] != null ? r["title"].ToString() : r["tablename"].ToString()),
							EditListingType = string.IsNullOrEmpty(r["editlistingtype"].ToString()) ? "default" : r["editlistingtype"].ToString(),
							PageId = r["idapppages"].ToString(),
							ParentMenuId = r["idmenuweb"].ToString(),
							Principale = r["principale"].ToString() != "N" ? "S" : "N", //di default è principale
							Using = r["customusing"].ToString(),
							Code = r["customcode"].ToString(),
							Reference = r["customreference"].ToString(),
							Header = r["header"].ToString(),
							Footer = r["footer"].ToString(),
							Icon = r["icon"].ToString(),
							CustomJavascript = r["customjavascript"].ToString(),
							Staticfilter = r["staticfilter"].ToString(),
							CanCancel = r["cancancel"].ToString() != "N" ? "S" : "N", //di default è si
							CanCmdClose = r["cancmdclose"].ToString() != "N" ? "S" : "N", //di default è si
							CanInsert = r["caninsert"].ToString() != "N" ? "S" : "N", //di default è si
							CanInsertCopy = r["caninsertcopy"].ToString() != "N" ? "S" : "N", //di default è si
							CanSave = r["cansave"].ToString() != "N" ? "S" : "N", //di default è si
							CanShowLast = r["canshowlast"].ToString() != "N" ? "S" : "N", //di default è si
							SearchEnabled = r["cansearch"].ToString() != "N" ? "S" : "N", //di default è si
							OthersApp = r["othersapp"].ToString() == "S", //di default è no
							IsValid = r["isvalid"].ToString(),
							Anonimous = r["anonimous"].ToString() == "S", //di default è no
						});
				}

				var allfields = new List<field>();

				SetFieldsByRows(colonne, ref allfields);

				Console.WriteLine("OGGETTI---------------------------------------");
				foreach (var o in objects) Console.WriteLine(o.Table + " " + o.EditListingType + " " + o.Principale);

				Console.WriteLine("CAMPI---------------------------------------");
				Console.WriteLine(allfields.Count());

				//per ogni oggetto:
				foreach (var o in objects) {
					Console.WriteLine("\r\n\r\nOGGETTO CORRENTE: " + o.Table + " " + o.EditListingType);
					var current = o.Table;
					var container = o.Table;
					var objectKey = GetIdByTable(o.Table, allfields, connection);
					var buttonFields = new List<buttonField>();

					var isLinkingObj = IsLinkingObject(o.Table, ref allfields, connection);
					var isExtendedObjView = IsExtendingObject(current, ref allfields, connection);
					var isNormalObj = !isExtendedObjView && !isLinkingObj;

					var extendedObject = "";
					var extendedObjectKey = new List<string>();
					var extendingObject = "";
					var editListingTypes = o.EditListingType;
					var setDefaultExtended = "";

					//se è un edit type che serve a definire i campi di un oggetto da estendere non genero niente
					GetMissingFields(current + "_" + editListingTypes, null, ref allfields, connection, false);
					if (!allfields.Any(af => af.Table == current + "_" + editListingTypes)) {

						//caso in cui si tratta di un oggetto estendente
						if (isExtendedObjView) {
							extendedObject = current.Substring(0, current.IndexOf("_"));
							container = extendedObject;
							extendingObject = current.Substring(current.IndexOf("_") + 1, current.Length - current.IndexOf("_") - 1);
							current = extendedObject + extendingObject + (editListingTypes == "default" ? "" : "_" + editListingTypes) + "view";
							editListingTypes = extendingObject + (editListingTypes == "default" ? "" : "_" + editListingTypes);
							extendedObjectKey.AddRange(GetIdByTable(extendedObject, allfields, connection));
						}

						//mi preparo la collection dei campi che mi interessano
						var fields = allfields.Where(af => af.Table == (string.IsNullOrEmpty(extendedObject) ? o.Table : extendedObject) && af.EditListingType == editListingTypes).ToList();

						//paracadute per quando sono nel caso di oggetto esteso e mi sono scordato di definire i campi con l'edit type  = all'oggetto estendente, allora uso i suoi campi di default
						if (!fields.Any())
							fields.AddRange(allfields.Where(af => af.Table == extendedObject && af.EditListingType == "default"));

						//nel caso di oggetto esteso aggiungo i suoi campi con l'eventuale edit type definito
						if (isExtendedObjView) {
							var editTypeEstendente = editListingTypes.Replace(extendingObject ,"");

							if (string.IsNullOrEmpty(editTypeEstendente))
								editTypeEstendente = "default";
							else
								editTypeEstendente = editTypeEstendente.Substring(1);

							fields.AddRange(allfields.Where(af => af.Table == o.Table && af.EditListingType == editTypeEstendente));
						}

						//annullo tutte le tabelle calcoate per gli oggetti precedenti
						foreach (var f in fields)
							f.MetadatoChild = null;

						//verifico se ha un campo testuale di un'altra tabella a cui si riferisce da mostrare negli elenchi (pagina principale) o nelle griglie (pagina figlia) o un campo radio
						// (N.B. Nelle griglie, per quelle si usano i campi calcolati nel dataset di pagina figlia NON si usa la vista quindi NON verrà creata veramente sul DB) 
						var hasTxtFieldsToShow = fields.Any(f => f.ListVisible && ( ( HaveKeyName(f) && (!f.IsKey || isLinkingObj)) || (f.Type == "char" && f.Len == 1)));

						//se è un oggetto estendete o non lo è ma deve mostrare un campo di un'altra tabella nel proprio list type di default
						//devo costruire una vista
						var viewFields = new List<field>();

						//sel elgriglie o elenchi per questo list type vanno filtrati allora creo una vista
						var hasfilter = fields.Any(f=> !string.IsNullOrEmpty(f.Filter));

						//se si tratta solo di griglie non creo veramente la vista sul DB (la scrivo solo in caso di elenchi, oggetti estendenti e filtri)
						var createDbView = (hasTxtFieldsToShow && o.Principale == "S") || isExtendedObjView /*|| isLinkingObj*/ || hasfilter ;

						var viewName="";
						if (createDbView || hasTxtFieldsToShow) {
							viewFields = CreateView(
								isExtendedObjView ? extendedObject : current,
								isExtendedObjView ? o.Table : "",
								editListingTypes, fields, allfields,
								createDbView,
								isLinkingObj, connection);
							viewName = (!string.IsNullOrEmpty(extendedObject) ? extendedObject : current) + editListingTypes + "view";
						}
						if (!createDbView) {
							//se successivamente vengono resi non visibili tutti icampi di esterni, rigenerando la pagina, occorre eliminare la vista
							try {
								viewName = (!string.IsNullOrEmpty(extendedObject) ? extendedObject : current) + editListingTypes + "view";
								var del = "DELETE web_listredir WHERE newtablename = '" + viewName + "' and listtype = '" + editListingTypes + "'";
								cmd = new SqlCommand(del, connection);
								cmd.ExecuteNonQuery();
								del = "DROP VIEW " + viewName;
								cmd = new SqlCommand(del, connection);
								cmd.ExecuteNonQuery();
							} catch (Exception e) {
								if (verbose)
									Console.WriteLine("INFO: La vista " + viewName + " non è necessaria in quanto non risultano chiavi esterne visibili in " + o.Table + " e non estende altri oggetti");
							}
							viewName = "";
						}

						//ENTITA' FIGLIE 
						var relationFields = GetChildentitiesFields(o.PageId, extendedObject, allfields, connection);
						foreach (var r in relationFields) {
							//servirebbe a gestire più figli dello stesso tipologia di oggetto, 
							//SetMetadatoChild(fields, r, r.Name.Substring(2)); 
							if (fields.Any(f => f.Table == r.Name.Substring(2))) //ricorsivo su se stesso
								r.Name += "_alias1";
							//se è un oggetto estendente ... per ora ci sto appoggiando la sua tabella estendente, dovesse servire occorrerà aggiungere un campo nuovo
							if (IsExtendingObject(r.Name.Substring(2), ref allfields, connection))
								//..salvo l'esteso nel campo fi.MetadatoChild con l'alias che mi serve
								SetMetadatoChild(fields, r, r.Name.Substring(2).Split('_')[0]);
							fields.Add(r);
						}

						//Bottoni 
						var queryButtons = @"	SELECT b.idapppagesbutton, b.name, b.title, b.code, b.parameter, b.idapppages, b.idapptab, b.icon, 
											t.title as tabtitle, b.refresh, b.javascript
											FROM apppagesbutton b
											left outer join apptab t on b.idapptab = t.idapptab 
											where b.idapppages = " + o.PageId;
						var cmdButtons = new SqlCommand(queryButtons, connection);
						var dataReaderButtons = cmdButtons.ExecuteReader();
						var buttons = new DataTable();
						buttons.Load(dataReaderButtons);
						foreach (DataRow button in buttons.Rows) {
							var tabtitle = string.IsNullOrEmpty(button["tabtitle"].ToString()) ? "Principale" : button["tabtitle"].ToString();

							buttonFields.Add(new buttonField {
								Title = button["title"].ToString(),
								Name = string.IsNullOrEmpty(button["name"].ToString()) ? button["title"].ToString().Replace(" ", "") : button["name"].ToString(),
								Code = button["code"].ToString(),
								Parameter = button["parameter"].ToString(),
								Icon = button["icon"].ToString(),
								Refresh = button["refresh"].ToString(),
								Javascript = button["javascript"].ToString(),
								Tab = tabtitle,
							});
						}

						if (!skipmetadato) {
							#region METADATO
							Console.WriteLine("1) --------------GENERAZIONE DEL METADATO-------------------");

							var extendedObjectFile = "";
							var extendingObjectFile = "";
							//var editTypesString = "";

							//se è un oggetto estendente devo creare il metadato estendente
							if (isExtendedObjView) {
								Console.WriteLine("1.1) " + o.Table + " ESTENDE L'OGGETTO " + extendedObject);
								//-AGGIUNGO L'EDIT TYPE NELL'OGGETTO ESTESO
								extendedObjectFile = solutionFolder + metadataFolder + container + "/meta_" + extendedObject + "/meta_" + extendedObject + ".cs";
								ReplaceStringInFile(extendedObjectFile, "//$EditTypes$", "EditTypes.Add(\"" + editListingTypes + "\");\r\n            ListingTypes.Add(\"" + editListingTypes + "\");\r\n            //$EditTypes$");

								//-CREO IL PROGETTO DEL METADATO ESTENDENTE
								extendingObjectFile = PrepareCsproj(o.Table, container, o.Title, editListingTypes, o.OthersApp);
							}

							//se è un oggetto che negli ELENCHI (Principale) deve mostrare campi testuali di altre tabelle a cui si riferisce, devo creare il metadato relativo alla vista ...
							//... solo se non è un oggetto esteso o di collegamento
							var viewObjectFile = "";
							if (createDbView && !isExtendedObjView) {
								//-CREO IL PROGETTO DEL METADATO VISTA
								viewObjectFile = PrepareCsproj(viewName, container, o.Title, editListingTypes, o.OthersApp, objectKey);
							}

							Console.WriteLine("1.2) CREO IL PROGETTO DELL'OGGETTO CORRENTE (metadato semplice o vista di un oggetto estendente + esteso o di collegamento e collegato)");

							var currentObjectFile = PrepareCsproj(current, container, o.Title, editListingTypes, o.OthersApp, isExtendedObjView ? extendedObjectKey : null );

							//-aggiungo il codice personalizzato
							if (!string.IsNullOrEmpty(o.Reference))
								SetGeneralReference(currentObjectFile + "proj", o.Reference);
							if (!string.IsNullOrEmpty(o.Using))
								ReplaceStringInFile(currentObjectFile, "//$CustomUsing$", o.Using + "\r\n//$CustomUsing$");
							if (!string.IsNullOrEmpty(o.Code))
								ReplaceStringInFile(currentObjectFile, "//$CustomCode$", o.Code + "\r\n//$CustomCode$");

							//-aggiungo il codice per i bottoni
							if (buttonFields.Any()) {
								SetGeneralReference(currentObjectFile + "proj", @"   <Reference Include=""Newtonsoft.Json, Version=6.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed, processorArchitecture=MSIL"">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>..\..\..\..\..\dll\Newtonsoft.Json.dll</HintPath>
    </Reference>");
								ReplaceStringInFile(currentObjectFile, "//$CustomUsing$", "using Newtonsoft.Json.Linq;\r\n//$CustomUsing$");
								foreach (var b in buttonFields)
									ReplaceStringInFile(currentObjectFile, "//$CustomCode$", b.Code + "\r\n//$CustomCode$");
							}

							Console.WriteLine("1.3) MODIFICO IL FILE CS: DESCRIBECOLUMNS, ISVALID, SETDEFAULT, GETSORTING");

							//GETNEWROW

							//aggiungo l'autoincremento alla chiave nel metadato normale 
							////non si mette negli oggetti collegati da tabella di collegamento
							if (isNormalObj) {
								var getNewRow = "";
								foreach (var k in objectKey) {
									if (k.Contains(o.Table))
										getNewRow += "RowChange.MarkAsAutoincrement(T.Columns[\"" + k + "\"], null, null, 0);\r\n" +
										 "			RowChange.setMinimumTempValue(T.Columns[\"" + k + "\"], 9990000);\r\n";
								}
								//lo metto negli oggetti normali, o nell'oggetto esteso o nell'oggetto di collegamento
								ReplaceStringInFile(currentObjectFile, "//$Get_New_Row$", getNewRow + "			//$Get_New_Row$");
							}

							//-DESCRIBECOLUMNS: se è un oggetto che ne estende un altro, il current è la vista che li unisce

							//preparo prima il describecolumn STANDARD per il metaoggetto NORMALE
							var describeColumnsCase = "				case \"" + editListingTypes + "\": {\r\n";
							var describeColumns = "";
							//aggiungo campi normali
							var describeColumnsFileds = fields.Where(f => f.ListVisible && f.Table == o.Table).ToList();
							//aggiungo campi di lookup per ELENCHI (pagine principali) e GRIGLIE (pagine figlie)
							describeColumnsFileds.AddRange(viewFields.Where(vf => describeColumnsFileds.Select(dcf => dcf.Name).Contains(vf.LookupFor)));
							//rimuovo gli id che hanno un lookup
							foreach (var toRemove in describeColumnsFileds.Where(idf => idf.LookupFor == null && describeColumnsFileds.Select(dcf => dcf.LookupFor).Contains(idf.Name)).ToList())
								describeColumnsFileds.Remove(toRemove);
							foreach (var f in describeColumnsFileds.Where(f => f.ListVisible).OrderBy(f => f.SortList)) {
								var colName= (f.LookupFor == null ? f.Name : "!" + f.LookupFor + "_" + GetTableById(f.LookupFor, allfields, connection) + "_" + f.Name);
								describeColumns += "\t\t\t\t\t\tDescribeAColumn(T, \"" + colName + "\", \"" + f.Title + "\", nPos++);\r\n";
								if (f.Type == "datetime")
									describeColumns += "\t\t\t\t\t\tif (T.Columns.Contains(\"" + colName + "\")) T.Columns[\"" + colName + "\"].ExtendedProperties[\"format\"] = \"g\";\r\n";
							}
							describeColumns += "\t\t\t\t\t\tbreak;\r\n\t\t\t\t\t}\r\n\t\t\t\t\t//$DescribeAColumn$";

							//preparo il describecolumn derivato dalla vista da usare per gli oggetti derivati o quelli che negli ELENCHI (pagine principali) devono mostrare campi testuali di altre tabelle
							var describeColumnsView = "";
							if (viewFields.Any() && createDbView) {
								//aggiungo i campi testuali calcolati al momento della creazione della vista
								foreach (var tf in viewFields.Where(f => f.ListVisible).OrderBy(f => f.Table).ThenBy(f => f.SortList)) {
									describeColumnsView += "\t\t\t\t\t\tDescribeAColumn(T, \"" + (string.IsNullOrEmpty(tf.ViewAlias) ? tf.Name : tf.ViewAlias) + "\", \"" + tf.Title + "\", nPos++);\r\n";
									if (tf.Type == "datetime")
										describeColumnsView += "\t\t\t\t\t\tT.Columns[\"" + (string.IsNullOrEmpty(tf.ViewAlias) ? tf.Name : tf.ViewAlias) + "\"].ExtendedProperties[\"format\"] = \"g\";\r\n";
								}
								describeColumnsView += "\t\t\t\t\t\tbreak;\r\n\t\t\t\t\t}\r\n\t\t\t\t\t//$DescribeAColumn$";
							}

							if (isExtendedObjView) {

								//preparo prima il describecolumn STANDARD per il metaoggetto ESTESO
								var describeColumnsExt = "";
								//aggiungo campi normali
								var describeColumnsFiledsExt = fields.Where(f => f.ListVisible && f.Table == extendedObject).ToList();
								//aggiungo campi di lookup per ELENCHI (pagine principali) e GRIGLIE (pagine figlie)
								describeColumnsFiledsExt.AddRange(viewFields.Where(vf => describeColumnsFiledsExt.Select(dcf => dcf.Name).Contains(vf.LookupFor)));
								//rimuovo gli id che hanno un lookup
								foreach (var toRemove in describeColumnsFiledsExt.Where(idf => idf.LookupFor == null && describeColumnsFiledsExt.Select(dcf => dcf.LookupFor).Contains(idf.Name)).ToList())
									describeColumnsFiledsExt.Remove(toRemove);
								foreach (var f in describeColumnsFiledsExt.Where(f => f.ListVisible).OrderBy(f => f.SortList)) {
									var colName= (f.LookupFor == null ? f.Name : "!" + f.LookupFor + "_" + GetTableById(f.LookupFor, allfields, connection) + "_" + f.Name);
									describeColumnsExt += "\t\t\t\t\t\tDescribeAColumn(T, \"" + colName + "\", \"" + f.Title + "\", nPos++);\r\n";
									if (f.Type == "datetime")
										describeColumnsExt += "\t\t\t\t\t\tif (T.Columns.Contains(\"" + colName + "\")) T.Columns[\"" + colName + "\"].ExtendedProperties[\"format\"] = \"g\";\r\n";
								}
								describeColumnsExt += "\t\t\t\t\t\tbreak;\r\n\t\t\t\t\t}\r\n\t\t\t\t\t//$DescribeAColumn$";

								if (describeColumnsFiledsExt.Any())
									//aggiungo il describecolumn al metadato esteso  (GRIGLIE su esteso)
									ReplaceStringInFile(extendedObjectFile, "\t\t\t\t\t//$DescribeAColumn$", describeColumnsCase + describeColumnsExt);


								if (viewFields.Any(f => f.ListVisible)) {
									//aggiungo il describecolumns al metadato meta_EstesoEstendenteListtypeView (ELENCHI)
									ReplaceStringInFile(currentObjectFile, "\t\t\t\t\t//$DescribeAColumn$", describeColumnsCase + describeColumnsView);
								}

								if (describeColumnsFileds.Any()) {
									//aggiungo il describecolumn al metadato estendente recuperando il listing type preso all'inizio (GRIGLIE su estendente)
									describeColumnsCase = "\t\t\t\tcase \"" + fields.Where(f => f.Table == extendedObject).First().EditListingType + "\": {\r\n";
									ReplaceStringInFile(extendingObjectFile, "\t\t\t\t\t//$DescribeAColumn$", describeColumnsCase + describeColumns);
								}

							} else {
								if (!string.IsNullOrEmpty(viewObjectFile)) {
									if (viewFields.Any(f => f.ListVisible))
										//aggiungo il describe columns all'oggetto vista di un oggetto normale (ELENCHI)
										ReplaceStringInFile(viewObjectFile, "\t\t\t\t\t//$DescribeAColumn$", describeColumnsCase + describeColumnsView);
								}
								if (describeColumnsFileds.Any())
									//il describecolumn degli oggetti di collegamento verrà inserito in seguito
									if (!isLinkingObj)
										//aggiungo il describe columns all'oggetto normale con i campi di lookup calcolati per le griglie (GRIGLIE e ELENCHI)
										ReplaceStringInFile(currentObjectFile, "\t\t\t\t\t//$DescribeAColumn$", describeColumnsCase + describeColumns);
							}

							////-ISVALID: solo se le obbligatorie ci stanno, se è un oggetto che ne estende un'altro va nell'oggetto esteso

							//var isValid = "";
							//var isValidExtended = "				case \"" + extendingObject + "\": {\r\n";

							//foreach (var f in fields.Where(fi => fi.Name != "ct" && fi.Name != "lt" && fi.Name != "cu" && fi.Name != "lu")) {
							//	//validazione campi nulli
							//	if (!f.Allownull) {
							//		var check = "						if (R.Table.Columns.Contains(\"" + f.Name + "\") && R[\"" + f.Name + "\"].ToString().Trim() == \"\") {\r\n" +
							//					"							errmess = \"Attenzione! Il campo '" + f.Title + "' è obbligatorio\";\r\n" +
							//					"							errfield = \"" + f.Name + "\";\r\n" +
							//					"							return false;\r\n" +
							//					"						}\r\n";
							//		if (!extendedObjectKey.Any(k => k == f.Name))
							//			isValid += check;
							//		if (!string.IsNullOrEmpty(extendedObject) && f.Table == extendedObject)
							//			isValidExtended += check;
							//	}
							//	//validazione lunghezza stringhe
							//	if (f.Len > 1 && f.Detailvisible) {
							//		var checkLen = "						if (R.Table.Columns.Contains(\"" + f.Name + "\") && R[\"" + f.Name + "\"].ToString().Trim().Length > " + f.Len + ") {\r\n" +
							//					"							errmess = \"Attenzione! Il campo '" + f.Title + "' può essere al massimo di " + f.Len + " caratteri\";\r\n" +
							//					"							errfield = \"" + f.Name + "\";\r\n" +
							//					"							return false;\r\n" +
							//					"						}\r\n";
							//		isValid += checkLen;
							//		if (!string.IsNullOrEmpty(extendedObject) && f.Table == extendedObject)
							//			isValidExtended += checkLen;
							//	}
							//}

							//isValid += "			//$IsValid$"; //"						break;\r\n					}\r\n				//$IsValid$";
							//isValidExtended += "						break;\r\n					}\r\n				//$IsValid$";

							////l'oggetto corrente ha tutti i campi correnti (normale o esteso e estendente 
							//ReplaceStringInFile(currentObjectFile, "//$IsValid$", isValid);

							////aggiungo all'esteso i propri ma per la sua estensione
							//if (!string.IsNullOrEmpty(extendedObjectFile)) {
							//	var swc = @"switch (extension)";
							//	var filetxt = File.ReadAllText(extendedObjectFile);
							//	if (!filetxt.Contains(swc)) {
							//		//recupero quanto già inserito per l'oggetto non esteso
							//		string tablePattern = @"if \(\!base.IsValid\(R, out errmess, out errfield\)\) return false;\r\n(.*?)return true;";
							//		var element = Regex.Matches(filetxt, tablePattern, RegexOptions.Singleline).Cast<Match>().Select(m => m.Value).ToList().First();
							//		element = element.Replace("if (!base.IsValid(R, out errmess, out errfield)) return false;\r\n\r\n\t\t\t", "").Replace("\r\n\t\t\t//$IsValid$\r\n\r\n\t\t\treturn true;", "");
							//		//inserisco la parte già esistente nello switch
							//		var caseDefault = "				case \"\": {\r\n" + element + "\r\n						break;\r\n					}\r\n";
							//		ReplaceStringInFile(extendedObjectFile, "\t\t\t//$IsValid$\r\n", "");
							//		ReplaceStringInFile(extendedObjectFile, element, "var extension = (R.Table.Columns.Contains(\"extension\") && R[\"extension\"] != null) ?  R[\"extension\"].ToString().Trim():\"\";\r\n			switch (extension) {" +
							//			caseDefault + "\r\n\t\t\t//$IsValid$\r\n			}\r\n");
							//	}
							//	ReplaceStringInFile(extendedObjectFile, "//$IsValid$", isValidExtended);
							//}

							//							//-SETDEFAULT: imposto i valori di default, se è un oggetto che ne estende un altro, esteso ed estendente hanno ogniuno i propri campi
							//							var setDefault = @"		public override void SetDefaults(DataTable PrimaryTable) {
							//			base.SetDefaults(PrimaryTable);
							//";

							//							foreach (var f in fields.Where(fi => fi.Name != "ct" && fi.Name != "lt" && fi.Name != "cu" && fi.Name != "lu")) {
							//								if (!string.IsNullOrEmpty(f.Defaultvalue)) {
							//									if (f.Table == o.Table)
							//										if (allfields.Where(af => af.Table == f.Table && af.Name == f.Name).All(cloni => cloni.Defaultvalue == f.Defaultvalue))
							//											// se in tutte le interfacce c'è lo stesso valore lo metto nel metadato ...
							//											setDefault += "						SetDefault(PrimaryTable, \"" + f.Name + "\", \"" + f.Defaultvalue.Replace("\"", "\\\"") + "\");\r\n";
							//										else {
							//											//...altrimenti nella pagina js ma lo faccio dopo
							//										}
							//									if (!string.IsNullOrEmpty(extendedObject) && f.Table == extendedObject)
							//										setDefaultExtended += "				parentRow.current[\"" + f.Name + "\"] = \"" + f.Defaultvalue.Replace("\"", "\\\"") + "\";\r\n";
							//								}
							//								if ((f.Type == "datetime" || f.Type == "date") && !f.Allownull) {
							//									if (f.Table == (!string.IsNullOrEmpty(extendingObject) ? extendingObject : current))
							//										setDefault += "						SetDefault(PrimaryTable, \"" + f.Name + "\", DateTime.Now);\r\n";
							//									if (!string.IsNullOrEmpty(extendedObject) && f.Table == extendedObject)
							//										setDefaultExtended += "				parentRow.current[\"" + f.Name + "\"] = new Date();\r\n";
							//								}
							//							}

							//							setDefault += "		}\r\n";

							//							//agguingo al corrente o estendente i propri 
							//							ReplaceStringInFile(!string.IsNullOrEmpty(extendingObject) ? extendingObjectFile : currentObjectFile, "//$SetDefault$", setDefault);

							//							////agguingo all'esteso anche la colonna extension
							//							if (isExtendedObjView) //{
							//								setDefaultExtended += "				parentRow.current[\"extension\"] = \"" + extendingObject + "\";\r\n";


							//-GETSORTING: se definito, va nel metadato oppure nella vista in caso di oggetti estesi 
							var sortString = "";
							if (viewFields.Any() && createDbView) {
								if (viewFields.Any(f => f.Name == "sortcode")) {
									var sf = viewFields.Where(f => f.Name == "sortcode").First();
									sortString = string.IsNullOrEmpty(sf.ViewAlias) ? sf.Name : sf.ViewAlias;
								} else
									sortString = string.Join(", ", viewFields.Where(f => f.ListVisible && f.Table == o.Table && !string.IsNullOrEmpty((f.SortData ?? "").Trim())).Select(f =>
										(string.IsNullOrEmpty(f.ViewAlias) ? f.Name : f.ViewAlias) + " " + f.SortData));
							} else {
								if (fields.Any(f => !string.IsNullOrEmpty((f.SortData ?? "").Trim()) || f.Name == "sortcode")) {
									if (fields.Any(f => f.Name == "sortcode"))
										sortString = "sortcode";
									else
										sortString = string.Join(", ", fields.Where(f => !string.IsNullOrEmpty((f.SortData ?? "").Trim())).Select(f => f.Name + " " + f.SortData));
								}
							}
							if (!string.IsNullOrEmpty(sortString)) {
								var getSorting = "				case \"" + editListingTypes + "\": {\r\n";
								getSorting += "						return \"" + sortString + "\";\r\n";
								getSorting += "					}\r\n				//$GetSorting$";
								ReplaceStringInFile(!string.IsNullOrEmpty(viewObjectFile) ? viewObjectFile : currentObjectFile, "				//$GetSorting$", getSorting);
							}

							//-GETSTATICFILTER
							if (!string.IsNullOrEmpty(o.Staticfilter)) {
								var getStaticfilter = "				case \"" + editListingTypes + "\": {\r\n";
								getStaticfilter += "						return \"" + o.Staticfilter + "\";\r\n";
								getStaticfilter += "						break;\r\n					}\r\n				//$GetStaticFilter$";
								ReplaceStringInFile(currentObjectFile, "				//$GetStaticFilter$", getStaticfilter);
							}

							Console.WriteLine("1.4) MODIFICO IL DATASET DEL METADATO NORMALE O ESTENDENTE");

							var datasetMetadatoFileName = solutionFolder + metadataFolder + container + "/meta_" + o.Table + "/vista.xsd";
							var dsMetadatoAndKey = GetDatasetTable(o.Table, false, allfields, connection);
							var datasetMetadato = "      <xs:choice minOccurs=\"0\" maxOccurs=\"unbounded\">\r\n";
							datasetMetadato += dsMetadatoAndKey.Split(';')[0];
							datasetMetadato += "      </xs:choice>";
							ReplaceStringInFile(datasetMetadatoFileName, "<xs:choice minOccurs=\"0\" maxOccurs=\"unbounded\" />", datasetMetadato);
							ReplaceStringInFile(datasetMetadatoFileName, "<xs:unique name=\"Constraint1\" msdata:PrimaryKey=\"true\" />", dsMetadatoAndKey.Split(';')[1]);
							//modifico il file cs del dataset
							HDSGen.FileNameSpace = "meta_" + o.Table;
							File.WriteAllBytes(datasetMetadatoFileName.Replace(".xsd", ".designer.cs"), HDSGen.iGenerateCode(datasetMetadatoFileName, File.ReadAllText(datasetMetadatoFileName, Encoding.Default)));
							#endregion
						}

						if (!skipmetapage) {
							#region BACKEND E CLIENT
							Console.WriteLine("2) --------------GENERAZIONE DELLA METAPAGE-------------------");

							if (!skipmetapageproject) {
								Console.WriteLine("2.1) MODIFICO IL PROJECT BACKEND");
								var BackendTxt = File.ReadAllText(backendFolder + "Backend.csproj", Encoding.Default);

								//-aggiungo la reference al metadato (o vista nel caso di oggetti estesi) nel project beckend (se non c'è)
								if (!BackendTxt.Contains("<Reference Include=\"meta_" + current))
									SetReference(backendFolder + "Backend.csproj", current);

								//-aggiungo la reference al metadato estendente nel project beckend (se non c'è)
								if (!string.IsNullOrEmpty(extendingObject) && !BackendTxt.Contains("<Reference Include=\"meta_" + o.Table)) {
									SetReference(backendFolder + "Backend.csproj", o.Table);
								}

								//-aggiungo la reference al metadato della vista nel project beckend (se non c'è) solo se l'o creata veramente sul db
								if (createDbView && !BackendTxt.Contains("<Reference Include=\"meta_" + viewName)) {
									SetReference(backendFolder + "Backend.csproj", viewName);
								}

								//-aggiungo i file del dataset al project beckend
								var datasetname = "dsmeta_" + (!string.IsNullOrEmpty(extendingObject) ? extendedObject : o.Table) + "_" + editListingTypes ;
								if (!BackendTxt.Contains(datasetname + ".xsc")) {
									var datasetstring =
									"  <ItemGroup>\r\n" +
									"    <Content Include=\"Data\\" + datasetname + ".xsc\">\r\n" +
									"      <DependentUpon>" + datasetname + ".xsd</DependentUpon>\r\n" +
									"    </Content> \r\n"+
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

							Console.WriteLine("2.2) PREPARO LA CARTELLA, LA VOCE DI MENU', E MODIFICO I FILE DELLA METAPAGE: pagina.js, pagina.html, oggetto estendente.js se necessario");

							//-creo la cartella contenitore della pagina
							if (!Directory.Exists(clientFolder + metapageFolder + container))
								Directory.CreateDirectory(clientFolder + metapageFolder + container);

							//-creo la voce di menù se è una pagina principale 
							if (o.Principale != "N") {
								cmd = new SqlCommand("menuweb_addentry", connection);
								cmd.CommandType = CommandType.StoredProcedure;
								cmd.Parameters.AddWithValue("@idmenuwebparent", string.IsNullOrEmpty(o.ParentMenuId) ? idmenu : o.ParentMenuId);
								cmd.Parameters.AddWithValue("@tableName", !string.IsNullOrEmpty(extendingObject) ? extendedObject : o.Table);
								cmd.Parameters.AddWithValue("@editType", editListingTypes);
								cmd.Parameters.AddWithValue("@label", o.Title);
								cmd.ExecuteNonQuery();
							}


							//PAGINA JS 
							//-copio e rinomino il template della metapage js nella cartella della metapage
							var fullPathMetaPageJS = clientFolder + metapageFolder + container + "/" + (!string.IsNullOrEmpty(extendingObject) ? extendedObject : o.Table) + "_" + editListingTypes + ".js";
							Copy("../../metapage_template/tabella_edittype.js", fullPathMetaPageJS, true);
							//-sostituzioni di nome
							ReplaceStringInFile(fullPathMetaPageJS, "'titolopagina'", "'" + o.Title.Replace("'", @"\'") + "'");
							ReplaceStringInFile(fullPathMetaPageJS, "'tabella'", "'" + (!string.IsNullOrEmpty(extendingObject) ? extendedObject : o.Table) + "'");
							ReplaceStringInFile(fullPathMetaPageJS, "'tipoedit'", "'" + editListingTypes + "'");
							ReplaceStringInFile(fullPathMetaPageJS, "Principale", o.Principale == "N" ? "true" : "false");

							//bottoni
							if (!string.IsNullOrEmpty(o.SearchEnabled) && o.SearchEnabled == "N")
								ReplaceStringInFile(fullPathMetaPageJS, "//rowSelectedEventManager", "this.searchEnabled = false;\r\n" + "//rowSelectedEventManager");
							if (!string.IsNullOrEmpty(o.CanInsert) && o.CanInsert == "N")
								ReplaceStringInFile(fullPathMetaPageJS, "//rowSelectedEventManager", "this.canInsert = false;\r\n" + "//rowSelectedEventManager");
							if (!string.IsNullOrEmpty(o.CanInsertCopy) && o.CanInsertCopy == "N")
								ReplaceStringInFile(fullPathMetaPageJS, "//rowSelectedEventManager", "this.canInsertCopy = false;\r\n" + "//rowSelectedEventManager");
							if (!string.IsNullOrEmpty(o.CanSave) && o.CanSave == "N")
								ReplaceStringInFile(fullPathMetaPageJS, "//rowSelectedEventManager", "this.canSave = false;\r\n" + "//rowSelectedEventManager");
							if (!string.IsNullOrEmpty(o.CanCancel) && o.CanCancel == "N")
								ReplaceStringInFile(fullPathMetaPageJS, "//rowSelectedEventManager", "this.canCancel = false;\r\n" + "//rowSelectedEventManager");
							if (!string.IsNullOrEmpty(o.CanCmdClose) && o.CanCmdClose == "N")
								ReplaceStringInFile(fullPathMetaPageJS, "//rowSelectedEventManager", "this.canCmdClose = false;\r\n" + "//rowSelectedEventManager");
							if (!string.IsNullOrEmpty(o.CanShowLast) && o.CanShowLast == "N")
								ReplaceStringInFile(fullPathMetaPageJS, "//rowSelectedEventManager", "this.canShowLast = false;\r\n" + "//rowSelectedEventManager");
							//pagina anonima
							if (o.Anonimous)
								ReplaceStringInFile(fullPathMetaPageJS, "//rowSelectedEventManager", "appMeta.connection.setAnonymous();\r\n" + "//rowSelectedEventManager");
							

							//-Se c'era un oggetto esteso 
							if (isExtendedObjView) {
								//esplicito la beforefill

								var beforeFillString = "beforeFill:function () {\r\n"+
									"				var def = appMeta.Deferred(\"beforeFill-" + extendedObject + "_" + editListingTypes + "\");\r\n"+
									"						var dt = this.state.DS.tables[\"" + o.Table + "\"];\r\n"+
									"						if (dt.rows.length > 0)\r\n"+
									"							return def.resolve(null);\r\n"+
									"						if (dt.rows.length === 0) {\r\n"+
									"							var meta = appMeta.getMeta(\"" + o.Table + "\");\r\n"+
									"							meta.setDefaults(dt);\r\n"+
									"							var parentRow = this.state.currentRow;\r\n"+
									"							return meta.getNewRow(parentRow.getRow(), dt, this.editType)\r\n"+
									"								.then(function(rowToInsert) {\r\n"+
									"									return def.resolve();\r\n"+
									"								});\r\n"+
									"						}\r\n"+
									"						return def.resolve();\r\n"+
									"			},\r\n";// +
														//"			//beforeFill";
								ReplaceStringInFile(fullPathMetaPageJS, "//beforeFill", beforeFillString);
							}

							//SetDefault di pagina
							var beforeFilldefaultString = "beforeFill:function () {\r\n";
							var setdef = false;
							foreach (var f in fields.Where(fi => fi.Name != "ct" && fi.Name != "lt" && fi.Name != "cu" && fi.Name != "lu")) {
								if (!string.IsNullOrEmpty(f.Defaultvalue)) {
									if (f.Table == o.Table)
										if (!allfields.Where(af => af.Table == f.Table && af.Name == f.Name).All(cloni => cloni.Defaultvalue == f.Defaultvalue) || f.Defaultvalue.Contains("appMeta.")) {
											// se NON in tutte le interfacce c'è lo stesso valore lo metto nella pagina js
											var defaultvalue = f.Defaultvalue.Contains("appMeta.") ? f.Defaultvalue : "\"" + f.Defaultvalue + "\"";
											beforeFilldefaultString += "				if (!this.state.currentRow[\"" + f.Name + "\"]) this.state.currentRow[\"" + f.Name + "\"] = " + defaultvalue + ";\r\n";
											setdef = true;
										}

								}
							}
							if (setdef)
								ReplaceStringInFile(fullPathMetaPageJS, "//beforeFill", beforeFilldefaultString + "			},\r\n");


							//-aggiungo le ricerche per le relazioni con tabelle di collegamento
							var relationFieldCerca = fields.Where (f=>f.Name.StartsWith("XX") && f.RelationType=="cerca").ToList();
							if (relationFieldCerca.Any()) {
								foreach (var fi in relationFieldCerca) {
									var linktable = fi.Name.Substring(2); //tabella di collegamento
									var linkid = allfields.Where(f=>f.IsKey && f.ListVisible && f.Table == linktable && f.EditListingType == fi.EditListingType && HaveKeyName(f)).FirstOrDefault(); //chiave sulla tabella di collegamento
									if (linkid != null) {
										var linkedtable = GetTableById(linkid.Name, allfields, connection);//tabella collegata
										if (!string.IsNullOrEmpty(linkedtable)) {
											var linkedtableTextField = GetTextFieldByTable(linkedtable, allfields, connection).FirstOrDefault();//campo testuale della tabella collegata
											if (linkedtable != linkedtableTextField.Table) {
												//TODO serve o è già stato messo sul dataset? aggiungo il filtro statico linkid.name in (select linkid.Name from linkedtable) dove linkedtable è ancora l'oggetto estendente

												//mi è stato restituito il campo testuale dell'oggetto da cui deriva quindi devo cercare lì
												linkedtable = linkedtableTextField.Table;
											}

											//se è il primo bottone di pagina aggiungo tutto l'afterlink event ...
											ReplaceStringInFile(fullPathMetaPageJS, "//afterLink",
											@"afterLink:function () {
               $(""#btn_add_" + linktable + "_" + linkid.Name + @""").on(""click"", _.partial(this.searchAndAssign" + linkedtable + @", this ));
               $(""#btn_add_" + linktable + "_" + linkid.Name + @""").prop(""disabled"", true);
			   //fireAfterLink
									}," + "\r\n");
											//... altrimenti solo l'associazione tra il bottone e l'evento all'interno dell'afterlink
											ReplaceStringInFile(fullPathMetaPageJS, "//fireAfterLink",
												@"$(""#btn_add_" + linktable + "_" + linkid.Name + @""").on(""click"", _.partial(this.searchAndAssign" + linkedtable + @", this ));
               $(""#btn_add_" + linktable + "_" + linkid.Name + @""").prop(""disabled"", true);
			   //fireAfterLink");

											//se è il primo bottone di pagina aggiungo tutto il rowSelected event ...
											ReplaceStringInFile(fullPathMetaPageJS, "//rowSelectedEventManager", "this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);");
											ReplaceStringInFile(fullPathMetaPageJS, "//rowSelected",
												@"rowSelected:function () {
               $(""#btn_add_" + linktable + "_" + linkid.Name + @""").prop(""disabled"", false);
			   //firerowSelected
									}," + "\r\n");
											//... altrimenti solo l'associazione tra il bottone e l'evento all'interno del rowSelected
											ReplaceStringInFile(fullPathMetaPageJS, "//firerowSelected",
												@"$(""#btn_add_" + linktable + "_" + linkid.Name + @""").prop(""disabled"", false);
			   //firerowSelected");

											//se è il primo bottone di pagina aggiungo tutto il buttonClickEnd event ...
											ReplaceStringInFile(fullPathMetaPageJS, "//buttonClickEndEventManager", "appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);");
											ReplaceStringInFile(fullPathMetaPageJS, "//buttonClickEnd", @"buttonClickEnd:function (currMetaPage, cmd) {
				cmd = cmd.toLowerCase();
				if (cmd === ""mainsetsearch"") {
					$(""#btn_add_" + linktable + "_" + linkid.Name + @""").prop(""disabled"", true);
			   //firebuttonClickEnd
				}
			}," + "\r\n");
											//... altrimenti solo l'associazione tra il bottone e l'evento all'interno del buttonClickEnd
											ReplaceStringInFile(fullPathMetaPageJS, "//firebuttonClickEnd", @"$(""#btn_add_" + linktable + "_" + linkid.Name + @""").prop(""disabled"", true);
			   //firebuttonClickEnd");


											//aggiungo l'evento di chiamata alla funzione c#
											var btn = "searchAndAssign" + linkedtable + @":function (that) {
				var dt" + linkedtable + @" = that.state.DS.tables." + linkedtable + @";
				// costrusico filtro a partire dalla stringa neltext
				var filter = that.helpForm.getSearchText($(""#txt_" + linktable + "_" + linkid.Name + "\"), dt" + linkedtable + @".columns[""" + linkedtableTextField.Name + @"""], """ + linkedtable +
				@"." + linkedtableTextField.Name + @""");
				// recupero riga principale corrente
				var parentRow = that.state.currentRow;
				var columnToFill = """ + linkid.Name + @""";
				var tableToFill = """ + linktable + @""";
				// effettuo la scelta su " + linkedtable + @"
				that.choose(""choose."" + dt" + linkedtable + @".name + "".default"", filter, that.rootElement)
					.then(function (rowToAdd) {
						var isToAdd = true;
						var dt" + linktable + @" = that.state.DS.tables[tableToFill];
						_.forEach(dt" + linktable + @".rows, function (rowp) {
							// se è la stessa chiave allora vedo se era deleted
							if (rowp[columnToFill] === rowToAdd.current[columnToFill]){
								if (rowp.getRow().state === jsDataSet.dataRowState.deleted){rowp.getRow().rejectChanges()}
								isToAdd = false;
								return false; // esco se trovo che è la stessa, non serve confrontare con altre
							}
						});
						// aggiungo se serve, altriementi eseguo solo refresh
						appMeta.utils._if(isToAdd)
							._then(function () {
								that.showWaitingIndicator(""Aggiungo riga"");
								var meta = appMeta.getMeta(tableToFill);
								meta.setDefaults(dt" + linktable + @");
								return meta.getNewRow(parentRow.getRow(), dt" + linktable + @", that.defaultListType)
									.then(function (rowToInsert) {
										// valorizzo il campo/i campi necessari presi dal controllo
										rowToInsert.current[columnToFill] = rowToAdd.current[columnToFill];
										return true; // lo manda nel ramo then()
									})
							})
							.then(function () {
								// rinfresco la pagina
								that.freshForm(true, true)
									.then(function () {
										// nascondo indicatore di attesa
										that.hideWaitingIndicator();
										return true;
									});
							});

				});
			},

			//buttons";
											ReplaceStringInFile(fullPathMetaPageJS, "//buttons", btn);
										} else {
											Console.WriteLine("ERROR: in fase di generazione del tab con ricerca per la tabella di collegamento " + linktable + " è fallito il recupero della tabella collegata");
										}
									}
								}
							}

							//evito il bug del calendar che se in un tab appare con celle più basse fino al primo evento
							var relationFieldCalendar = fields.Where (f=>f.Name.StartsWith("XX") && f.RelationType=="calendario").ToList();
							if (relationFieldCalendar.Any()) {
								foreach (var fi in relationFieldCalendar) {
									//se è il primo bottone di pagina aggiungo tutto l'afterlink event ...
									ReplaceStringInFile(fullPathMetaPageJS, "//afterLink",
										@"afterLink:function () {
				$('.nav-tabs').on('shown.bs.tab', function (e) {
					$('#calendar" + fields.IndexOf(fi) + @"').fullCalendar('rerenderEvents');
					//fireAfterLink
				});
			}," + "\r\n");
									//... altrimenti solo l'associazione tra il bottone e l'evento all'interno dell'afterlink
									ReplaceStringInFile(fullPathMetaPageJS, "//fireAfterLink",
										@"$('#calendar" + fields.IndexOf(fi) + @"').fullCalendar('rerenderEvents');
					//fireAfterLink");

								}
							}

							//-aggiungo i bottoni
							if (buttonFields.Any()) {
								foreach (var b in buttonFields) {
									//se è il primo bottone di pagina aggiungo tutto l'afterlink event ...
									ReplaceStringInFile(fullPathMetaPageJS, "//afterLink", @"afterLink:function () {
               $(""#" + b.Name + @""").on(""click"", _.partial(this.fire" + b.Name + @", this ));
               $(""#" + b.Name + @""").prop(""disabled"", true);
			   //fireAfterLink
            }," + "\r\n");
									//... altrimenti solo l'associazione tra il bottone e l'evento all'interno dell'afterlink
									ReplaceStringInFile(fullPathMetaPageJS, "//fireAfterLink", @"$(""#" + b.Name + @""").on(""click"", _.partial(this.fire" + b.Name + @", this ));
               $(""#" + b.Name + @""").prop(""disabled"", true);
			   //fireAfterLink");

									if (string.IsNullOrEmpty(b.Javascript)) {
										//se è il primo bottone di pagina aggiungo tutto il rowSelected event ...
										ReplaceStringInFile(fullPathMetaPageJS, "//rowSelectedEventManager", "this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);");
										ReplaceStringInFile(fullPathMetaPageJS, "//rowSelected",
											@"rowSelected:function () {
               $(""#" + b.Name + @""").prop(""disabled"", false);
			   //firerowSelected
									}," + "\r\n");
										//... altrimenti solo l'associazione tra il bottone e l'evento all'interno del rowSelected
										ReplaceStringInFile(fullPathMetaPageJS, "//firerowSelected",
											@"$(""#" + b.Name + @""").prop(""disabled"", false);
			   //firerowSelected");

										//se è il primo bottone di pagina aggiungo tutto il buttonClickEnd event ...
										ReplaceStringInFile(fullPathMetaPageJS, "//buttonClickEndEventManager", "appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);");
										ReplaceStringInFile(fullPathMetaPageJS, "//buttonClickEnd", @"buttonClickEnd:function (currMetaPage, cmd) {
				cmd = cmd.toLowerCase();
				if (cmd === ""mainsetsearch"") {
					$(""#" + b.Name + @""").prop(""disabled"", true);
			   //firebuttonClickEnd
				}
			}," + "\r\n");
										//... altrimenti solo l'associazione tra il bottone e l'evento all'interno del buttonClickEnd
										ReplaceStringInFile(fullPathMetaPageJS, "//firebuttonClickEnd", @"$(""#" + b.Name + @""").prop(""disabled"", true);
			   //firebuttonClickEnd");
									} else {
										ReplaceStringInFile(fullPathMetaPageJS, "//buttons", b.Javascript);
									}

									//aggiungo l'evento di chiamata alla funzione c#
									//se sono state indicate griglie da aggiornare ...
									if (!string.IsNullOrEmpty(b.Refresh)) {
										//...occorre modificare l'handler in modo che le aggiorni alla fine
										var s= @"fire" + b.Name + @":function (that) {
				that.showWaitingIndicator(""Attendere ..."");
				appMeta.getData.launchCustomServerMethod(""mdlwCustomEvent"", {
					tablename: '" + o.Table + @"',
					customevent: """ + b.Name + @""",
					" + b.Parameter + @"
				}).then(function (res) {
					var parentRow = that.state.currentRow;
					var filter = window.jsDataQuery.eq(""" + objectKey.First() + @""", parentRow." + objectKey.First() + @");
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
									that.hideWaitingIndicator();
									alert(res);
								});
						});

				});
			}
			//buttons";
										ReplaceStringInFile(fullPathMetaPageJS, "//buttons", s);
									} else {
										ReplaceStringInFile(fullPathMetaPageJS, "//buttons", @"fire" + b.Name + @":function (that) {
				appMeta.getData.launchCustomServerMethod(""mdlwCustomEvent"", {
					tablename: '" + o.Table + @"',
					customevent: """ + b.Name + @""",
					" + b.Parameter + @"
				})

					.then(function (res) {
						alert(res);
					});
            },

			//buttons");
									}
								}
							}

							//aggiungo il codice personalizzato
							if (!string.IsNullOrEmpty(o.CustomJavascript)) {
								var fun = o.CustomJavascript.Split(':')[0];
								//se è il primo bottone di pagina aggiungo tutto l'afterlink event ...
								ReplaceStringInFile(fullPathMetaPageJS, "//afterLink", @"afterLink:function () {
               this." + fun + @"();
			   //fireAfterLink
            }," + "\r\n");
								//... altrimenti solo l'associazione tra il bottone e l'evento all'interno dell'afterlink
								ReplaceStringInFile(fullPathMetaPageJS, "//fireAfterLink", "this." + fun + "();\r\n			   //fireAfterLink");

								//aggiungo l'evento di chiamata alla funzione javascript
								ReplaceStringInFile(fullPathMetaPageJS, "//buttons", o.CustomJavascript + "\r\n			//buttons");
							}

							//CREAZIONE METADATO JS normale o estendente --------------begin 
							var fullPathMetaDatoJS = clientFolder + metapageFolder + container + "/meta_" + o.Table + ".js";
							if (!File.Exists(fullPathMetaDatoJS)) {
								if (!Directory.Exists(clientFolder + metapageFolder + container))
									Directory.CreateDirectory(clientFolder + metapageFolder + container);
								Copy("../../metapage_template/meta_tabella.js", fullPathMetaDatoJS, true);
								//-sostituzioni di nome
								ReplaceStringInFile(fullPathMetaDatoJS, "tabella", o.Table);
								//-va aggiunto in index.html
								ReplaceStringInFile(clientFolder + "index.html", "<!-- meta dati -->\r\n", "<!-- meta dati -->\r\n	<script src=\"" + metapageFolder + container + "/meta_" + o.Table + ".js\"></script>\r\n");
							}
							//CREAZIONE METADATO JS normale o estendente --------------end 

							//VALIDAZIONE DI PAGINA ------------------ begin

							//calcolo le stringhe di validazione di pagina
							var isValid = "";
							var isValidExtended = "\t\t\t\tcase \"" + extendingObject + "\": \r\n";

							//li metto in ordine di visualizzazione nella pagina
							foreach (var f in fields.Where(fi => fi.Name != "ct" && fi.Name != "lt" && fi.Name != "cu" && fi.Name != "lu").OrderBy(fi => fi.Sort)) {
								//validazione campi nulli (anche NON visibili)
								if (!f.Allownull) {
									if (!f.Name.StartsWith("XX")) {
										var check = "\t\t\t\tif (r.table.columns." + f.Name + " && !objrow[\"" + f.Name + "\"]) {\r\n"+
												"\t\t\t\t\terrmess = loc.getIsValidFieldMandatory(\"" + f.Title + "\");\r\n"+
												"\t\t\t\t\terrfield = \"" + f.Name + "\";\r\n"+
												"\t\t\t\t\tobjres = { warningMsg: \"\", errMsg: errmess, errField: errfield, row: r };\r\n"+
												"\t\t\t\t\treturn def.resolve(objres);\r\n"+
												"\t\t\t\t}\r\n";
										if (!extendedObjectKey.Any(k => k == f.Name))
											isValid += check;
										if (!string.IsNullOrEmpty(extendedObject) && f.Table == extendedObject)
											isValidExtended += check;
									} else {
										//valido la presenza del numero di righe
										isValid += "if (r.table.dataset.tables." + f.Name.Substring(2) + " && r.table.dataset.tables." + f.Name.Substring(2) + ".rows.length < " + f.Numrowsmandatory + "){\r\n" +
"					errmess = loc.getMinNumRowRequired(\"" + f.Title + "\", " + f.Numrowsmandatory + " );\r\n" +
"					errfield = \"" + f.Name + "\";\r\n" +
"					objres = { warningMsg: \"\", errMsg: errmess, errField: errfield, row: r };\r\n" +
"					return def.resolve(objres);\r\n" +
"				}";
									}
								}
								//validazione lunghezza stringhe
								if (f.Len > 1 && f.Detailvisible) {
									var checkLen = "\t\t\t\tif (r.table.columns." + f.Name + " && objrow[\"" + f.Name + "\"] && objrow[\"" + f.Name + "\"].length > " + f.Len + ") {\r\n"+
													"\t\t\t\t\terrmess = loc.getIsValidFieldMaxLength(\"" + f.Title + "\", " + f.Len + ");\r\n"+
													"\t\t\t\t\terrfield = \"" + f.Name + "\";\r\n"+
													"\t\t\t\t\tobjres = { warningMsg: \"\", errMsg: errmess, errField: errfield, row: r };\r\n"+
													"\t\t\t\t\treturn def.resolve(objres);\r\n"+
													"\t\t\t\t}\r\n";
									isValid += checkLen;
									if (!string.IsNullOrEmpty(extendedObject) && f.Table == extendedObject)
										isValidExtended += checkLen;
								}
							}
							//aggiungo l'isvalid personalizzato javascript
							isValid += o.IsValid;
							isValid += "//$isValid$";
							isValidExtended += "\t\t\t\tbreak;\r\n//$isValid$";

							ReplaceStringInFile(fullPathMetaDatoJS, "//$isValid$", isValid);

							//VALIDAZIONE DI PAGINA ------------------ end

							//SET DEFAULT DI PAGINA -------------------begin

							//imposto i valori di default, se è un oggetto che ne estende un altro, esteso ed estendente hanno ogniuno i propri campi
							var setDefault = "";

							foreach (var f in fields.Where(fi => fi.Name != "ct" && fi.Name != "lt" && fi.Name != "cu" && fi.Name != "lu")) {
								if (!string.IsNullOrEmpty(f.Defaultvalue)) {
									if (f.Table == o.Table)
										setDefault += "						currentDataRow.current." + f.Name + " =  \"" + f.Defaultvalue.Replace("\"", "\\\"") + "\";\r\n";
									if (!string.IsNullOrEmpty(extendedObject) && f.Table == extendedObject)
										setDefaultExtended += "				parentRow.current[\"" + f.Name + "\"] = \"" + f.Defaultvalue.Replace("\"", "\\\"") + "\";\r\n";
								}
								if ((f.Type == "datetime" || f.Type == "date") && !f.Allownull) {
									if (f.Table == (!string.IsNullOrEmpty(extendingObject) ? extendingObject : current))
										setDefault += "						currentDataRow.current." + f.Name + " =  new Date();\r\n";
									if (!string.IsNullOrEmpty(extendedObject) && f.Table == extendedObject)
										setDefaultExtended += "				parentRow.current[\"" + f.Name + "\"] = new Date();\r\n";
								}
							}

							//agguingo al corrente o estendente i propri 
							ReplaceStringInFile(fullPathMetaDatoJS, "//$setDefault$", setDefault);

							////agguingo all'esteso anche la colonna extension
							if (isExtendedObjView) //{
								setDefaultExtended += "				parentRow.current[\"extension\"] = \"" + extendingObject + "\";\r\n";

							//-aggiungo i valori di default dell'esteso nel js dell'estendente
							var getnewrow = "getNewRow:function(parentRow, dt, editType){\r\n" +
									(isExtendedObjView ? setDefaultExtended : "") +
									"				var def = appMeta.Deferred(\"getNewRow-meta_" + o.Table + "\");\r\n" +
									"				this.superClass.getNewRow(parentRow, dt, editType)\r\n" +
									"					.then(function(currentDataRow) {\r\n" +
									setDefault +
									"						return def.resolve(currentDataRow);\r\n" +
									"					});\r\n" +
									"			},\r\n";

							ReplaceStringInFile(fullPathMetaDatoJS, "//$getNewRow$", getnewrow);
							//SET DEFAULT DI PAGINA -------------------end



							if (!string.IsNullOrEmpty(extendingObject)) {
								//------------------METADATO ESTESO JS
								if (!string.IsNullOrEmpty(extendedObject)) {
									var fullPathMetaDatoExtendedJS = clientFolder + metapageFolder + container + "/meta_" + extendedObject + ".js";
									if (!File.Exists(fullPathMetaDatoExtendedJS)) {

										Copy("../../metapage_template/meta_tabella.js", fullPathMetaDatoExtendedJS, true);
										//-sostituzioni di nome
										ReplaceStringInFile(fullPathMetaDatoExtendedJS, "tabella", extendedObject);
										//-va aggiunto in index.html
										ReplaceStringInFile(clientFolder + "index.html", "<!-- meta dati -->\r\n", "<!-- meta dati -->\r\n	<script src=\"" + metapageFolder + container + "/meta_" + extendingObject + ".js\"></script>\r\n");
									}

									var swc = @"switch (extension)";
									var filetxt = File.ReadAllText(fullPathMetaDatoExtendedJS, Encoding.Default);
									if (!filetxt.Contains(swc)) {
										//recupero quanto già inserito per l'oggetto non esteso
										string tablePattern = @"var errmess, errfield, objres;\r\n(.*?)return this.superClass.isValid";
										var element = Regex.Matches(filetxt, tablePattern, RegexOptions.Singleline).Cast<Match>().Select(m => m.Value).ToList().First();
										element = element.Replace("var errmess, errfield, objres;\r\n", "").Replace("return this.superClass.isValid", "");
										//inserisco la parte già esistente nello switch
										var caseDefault = "				case \"\": {\r\n" + element.Replace("//$isValid$\r\n", "") + "\r\n						break;\r\n					}\r\n";
										//ReplaceStringInFile(fullPathMetaDatoExtendedJS, "\t\t\t//$isValid$\r\n", "");
										ReplaceStringInFile(fullPathMetaDatoExtendedJS, "//$isValid$",
											"\t\t\t\tvar extension =  (r.table.columns.extension && r.current.extension) ? r.current.extension : \"\";\r\n			switch (extension) {" +
											caseDefault + "\r\n\t\t\t//$isValid$\r\n			}\r\n");
									}
									ReplaceStringInFile(fullPathMetaDatoExtendedJS, "//$isValid$", isValidExtended);
								}

							}

							//-------------------------------------------------------------------------------------------------

							//PAGINA HTML

							//-copio e rinomino il template della metapage html nella cartella della metapage
							var fullPathMetaPageHtml = clientFolder + metapageFolder + container + "/" + (!string.IsNullOrEmpty(extendingObject) ? extendedObject : o.Table) + "_" + editListingTypes + ".html";
							Copy("../../metapage_template/tabella_edittype.html", fullPathMetaPageHtml, true);

							//-aggiungo tutti i campi su due colonne

							var tabs = new List<tab>();
							foreach (var fi in fields)
								if (!tabs.Any(t => t.Title == fi.Tab))
									tabs.Add(new tab { Title = fi.Tab, Sort = fi.Tabposition, Icon = fi.Icon, Tabheader = fi.Tabheader });
							var tabString = "";
							var formString = "<form>\r\n" + (tabs.Count == 1 ? "" : "<div class=	\"tab-content mt-2\">\r\n");

							//per ogni tab in ordine ...
							foreach (var tab in tabs.OrderBy(t => t.Sort)) {
								if (!(tabs.Count == 1)) {
									//...aggiungo i tab in testa
									tabString += "	<li class=\"nav-item\">\r\n		<a href=\"#tab" + o.Table + "_" + editListingTypes + "_" + tabs.IndexOf(tab).ToString() +
										"\" class=\"nav-link" + (tabs.IndexOf(tab) == 0 ? " active show" : "") + "\" data-toggle=\"pill\" data-target=\"#tab" +
										o.Table + "_" + editListingTypes + "_" + tabs.IndexOf(tab).ToString() +
										"\"><i class=\"fa " + tab.Icon + " mr-1\"></i>" + tab.Title + "</a>\r\n	</li>\r\n";

									//...aggiungo l'etichetta del titolo del tab
									var labelTitleTab = "// nomi tab\r\n		tab" + o.Table + "_" + editListingTypes + "_" + tabs.IndexOf(tab).ToString() + ": \"" + tab.Title + "\",\r\n";
									ReplaceStringInFile(clientFolder + "assets/i18n/LocalResourceIt.js", "// nomi tab\r\n", labelTitleTab);

									//...apro il tab
									formString += "	<div class=\"tab-pane fade" + (tabs.IndexOf(tab) == 0 ? " active show" : "") + "\" id=\"tab" + o.Table + "_" + editListingTypes + "_" + tabs.IndexOf(tab).ToString() + "\" role=\"tabpanel\">\r\n";

									//aggiungo il testo del tab
									formString += "	<div class=\".custom_lng_div\" data-langkey=\"tablabel" + o.Table + "_" + editListingTypes + "_" + tabs.IndexOf(tab).ToString() + "\" >" + tab.Tabheader + "</div>";

									//...aggiungo l'etichetta del testo del tab
									if (!string.IsNullOrWhiteSpace(tab.Tabheader)) {
										var labelTextTab = "// lables\r\n		tablabel" + o.Table + "_" + editListingTypes + "_" + tabs.IndexOf(tab).ToString() + ": \"" + tab.Tabheader + "\",\r\n";
										ReplaceStringInFile(clientFolder + "assets/i18n/LocalResourceIt.js", "// lables\r\n", labelTextTab);
									}

								}
								//se è un unico campo nel tab per una entità figlia ...
								var isgrid = false;
								var isunique = fields.Where(f => f.Tab == tab.Title).Count() == 1;
								if (isunique) {
									var fi = fields.Where(f => f.Tab == tab.Title).First();
									if (fi.Name.StartsWith("XX")) {
										isgrid = true;
										switch (fi.RelationType) {
											case "cerca": //per le tabelle di collegamento

												var linktable = fi.Name.Substring(2); //tabella di collegamento
												var linkid = allfields.Where(f=>f.IsKey && f.ListVisible && f.Table == linktable && f.EditListingType == fi.EditListingType && HaveKeyName(f) ).FirstOrDefault(); //chiave sulla tabella di collegamento
												if (linkid != null) {


													var linkedtable = GetTableById(linkid.Name, allfields, connection);//tabella collegata
													formString += "			<div class=\"row\">\r\n" +
																"				<div class=\"col-md-9\">\r\n" +
																"					<input id=\"txt_" + linktable + "_" + linkid.Name + "\" type=\"text\" class=\"form-control\" placeholder=\"...\" aria-label=\"Search\" />\r\n" +
																"				</div>\r\n" +
																"				<div class=\"col-md-3\">\r\n" +
																"					<button id=\"btn_add_" + linktable + "_" + linkid.Name + "\" type=\"button\" class=\"btn btn-primary p-2 mt-1\">\r\n" +
																"						<i class=\"fas fa-search-plus mr-1\"></i> Cerca e aggiungi " + tab.Title + "\r\n" +
																"					</button>\r\n" +
																"				</div>\r\n" +
																"			</div>\r\n" +
																"			<hr>\r\n";

													var radiotagvalue = GetRadioFieldsValues(fi.Name.Substring(2), fi.EditListingType,  allfields,  connection);

													formString += "		<div id=\"grid" + fields.IndexOf(fi) + "\" data-tag=\"" + linktable +
														"." + fi.EditListingType + "." + fi.EditListingType + "\" data-custom-control=\"gridx\" data-mdlbuttondelete " +
													(string.IsNullOrEmpty(radiotagvalue) ? "" : "data-mdlconditionallookup=\"" + radiotagvalue + "\"") + " ></div>\r\n";
												}

												break;
											case "calendario":

												var table = fi.Name.Substring(2);
												var title = fi.CalendarSettings.Split(';')[0];
												if (string.IsNullOrEmpty(title)) {
													var txtfield = GetTextFieldByTable(table, allfields, connection).FirstOrDefault();
													title = txtfield.Name;
													if (table != txtfield.Table) {
														//mi è stato restituito il campo testuale dell'oggetto da cui deriva quindi devo cercare lì
														table = txtfield.Table;
													}
												}
												var start = fi.CalendarSettings.Split(';')[1];
												var stop = fi.CalendarSettings.Split(';')[2];
												var ded= !(start??"").Contains("!") && !(stop ?? "").Contains("!");

												//...disegno la grid
												//formString += "		<div class=\"row\">\r\n			<div class=\"col-md-12\">\r\n		<div id=\"grid" + fields.IndexOf(fi) +
												//	"\" data-tag=\"" + table + //qui ci va il nome della tabella
												//	"." + fi.EditListingType + "." + fi.EditListingType + "\" data-custom-control=\"gridx\" data-mdlbuttoninsert " +
												//	(IsLinkingObject(table, ref allfields, connection) ? "" : "data-mdlbuttonedit") + " data-mdlbuttondelete></div>\r\n			</div>\r\n		</div>\r\n";
												//...disegno il calendario
												formString += "		<hr>\r\n		<div class=\"row\">\r\n			<div class=\"col-md-12\">\r\n				<div id=\"calendar" + fields.IndexOf(fi) +
												"\" data-tag=\"" + table + ".default.default\" data-custom-control=\"calendar\"  data-mdltitlecolumnname=\"" + title + "\" " +
												(string.IsNullOrEmpty(start) ? "" : "  data-mdlstartcolumnname=\"" + start + "\" ") +
												(string.IsNullOrEmpty(stop) ? "" : "  data-mdlstopcolumnname=\"" + stop + "\" ") +
												" data-mdlbuttoninsert data-mdlbuttonedit data-mdlbuttondelete " + (ded ? "data-mdldragdrop" : "") + "></div>\r\n			</div>\r\n		</div>\r\n";

												break;

											case "checkbox":

												var radiotag = GetRadioFieldsValues(fi.Name.Substring(2), fi.EditListingType,  allfields,  connection);

												//...disegno la grid
												var gridtable = fi.Name.Substring(2);
												var edittype = fi.EditListingType;
												//se è un oggetto estendente devo mettere l'oggetto esteso con edit type = estendente_edittype
												if (IsExtendingObject(gridtable, ref allfields, connection)) {
													edittype = gridtable.Split('_')[1] + "_" + fi.EditListingType;
													gridtable = fi.MetadatoChild;
												}
												formString += "		<div id=\"grid" + fields.IndexOf(fi) + "\" data-tag=\"" + gridtable + //qui ci va il nome della tabella
													"." + edittype + "." + edittype + "\" data-custom-control=\"checklist\" " +
													(string.IsNullOrEmpty(radiotag) ? "" : "data-mdlconditionallookup=\"" + radiotag + "\"") + " ></div>\r\n";

												break;

											default:

												radiotag = GetRadioFieldsValues(fi.Name.Substring(2), fi.EditListingType,  allfields,  connection);

												//...disegno la grid
												gridtable = fi.Name.Substring(2);
												edittype = fi.EditListingType;
												//se è un oggetto estendente devo mettere l'oggetto esteso con edit type = estendente_edittype
												if (IsExtendingObject(gridtable, ref allfields, connection)) {
													edittype = gridtable.Split('_')[1] + "_" + fi.EditListingType;
													gridtable = fi.MetadatoChild;
												}
												formString += "		<div id=\"grid" + fields.IndexOf(fi) + "\" data-tag=\"" + gridtable + //qui ci va il nome della tabella
													"." + edittype + "." + edittype + "\" data-custom-control=\"gridx\" data-mdlbuttoninsert " +
													(IsLinkingObject(fi.Name.Substring(2), ref allfields, connection) ? "" : "data-mdlbuttonedit") + " data-mdlbuttondelete " +
													(string.IsNullOrEmpty(radiotag) ? "" : "data-mdlconditionallookup=\"" + radiotag + "\"") + " ></div>\r\n";

												break;
										}


									}
								}
								//altrimenti
								if (!isgrid) {
									var isInverted = false;
									var position = 1;
									//per ogni campo del tab
									foreach (var fi in fields.Where(f => f.Tab == tab.Title && f.Detailvisible).OrderBy(f => f.Table).ThenBy(f => f.Sort)) {

										var nametag= fi.Table + "_" + fi.Name;
										var datatag = fi.Table + "." + fi.Name;

										//...aggiungo l'etichetta per la label
										var labelString = "// label su html\r\n		" + nametag + ": \"" + fi.Title + "\",\r\n";
										ReplaceStringInFile(clientFolder + "assets/i18n/LocalResourceIt.js", "// label su html\r\n", labelString);


										if (fi.Hidden) {
											formString += "					<input hidden id=\"" + nametag + "\" type=\"text\" class=\"form-control\" " + "data-tag=\"" + datatag + "\" />\r\n";
										} else {

											var format = "";
											if (fi.Type == "datetime")
												format = ".g";

											//il tag di ricerca chiude anche le virgolette
											var searchtag = format + "\" ";
											//lo devo aggiungere ogniqualvolta io abbia creato una vista sul db per una pagina principale, 
											//perchè le query di ricerca sono solo sulle pagine principali e subiscono il web_listredir e cercano sulla vista 
											if (viewFields.Any() && createDbView) {
												searchtag = format + "?" + viewName + "." + (string.IsNullOrEmpty(fi.ViewAlias) ? fi.Name : fi.ViewAlias) + "\" data-subentity ";
											}

											//se text, nvarchar(max) o forzato a textarea scrivo su una colonna sola:
											if (fi.Type == "text" || (fi.Type == "nvarchar" && fi.Len == -1) || fi.Textarea) {
												//-se destro:  
												if (!IsSinistro(position, isInverted)) {
													//chiudo colonna e chiudo riga;
													formString += "				</div>\r\n			</div>\r\n";
												} else {
													//-altrimenti scambio sinistri con destri
													isInverted = !isInverted;
												}
												//-apro riga, apro colonna 12, disegno textarea, chiudo colonna, chiudo riga

												formString += "			<div class=\"row\">\r\n				<div class=\"col-md-12\">\r\n" +
														"					<label class=\"col-form-label col-md-12\" for=\"" + nametag + "\">" + fi.Title + "</label>\r\n" +
														"					<textarea class=\"textarea form-control\" id=\"" + nametag + "\" type=\"text\" " + " rows=\"" + (isunique ? "20" : "4") + "\" " + "data-tag=\"" +
														datatag + searchtag + " " + (fi.Allownull ? "" : "data-mandatory ") + "/>\r\n" +
														"				</div>\r\n			</div>\r\n";
											} else {
												//------------------------------------------------------begin
												//altrimenti verifico che non si arichiasta l'unicità sulla riga
												if (fi.UniqueOnRow) {
													//-se destro:  
													if (!IsSinistro(position, isInverted)) {
														//chiudo colonna e chiudo riga;
														formString += "				</div>\r\n			</div>\r\n";
													} else {
														//-altrimenti scambio sinistri con destri
														isInverted = !isInverted;
													}
													//-apro riga, apro colonna 12, disegno textarea, chiudo colonna, chiudo riga

													formString += "			<div class=\"row\">\r\n				<div class=\"col-md-12\">\r\n";
												} else {
													//------------------------------------------------------end
													//altrimenti scrivo su due colonne:

													//apertura colonna
													if (IsSinistro(position, isInverted)) {
														//-se sinistro: apro riga, apro colonna
														formString += "			<div class=\"row\">\r\n				<div class=\"col-md-6\">\r\n";
													} else {
														//-altrimenti: chiudo colonna, apro colonna 6
														formString += "				</div>\r\n"; ;
														formString += "				<div class=\"col-md-6\">\r\n";
													}
													//------------------------------------------------------begin
												}
												//------------------------------------------------------end

												//aggiungo il testo per il campo 
												formString += "	<div class=\".custom_lng_div\" data-langkey=\"fieldlabel" + nametag + "\" >" + fi.Text + "</div>";

												//...aggiungo l'etichetta del testo del campo
												if (!string.IsNullOrWhiteSpace(fi.Text.Trim())) {
													var labelTextField = "// lables\r\n		fieldlabel" + nametag + ": \"" + fi.Text + "\",\r\n";
													ReplaceStringInFile(clientFolder + "assets/i18n/LocalResourceIt.js", "// lables\r\n", labelTextField);
												}

												//-disegno il campo :
												if (HaveKeyName(fi) && (!fi.IsKey || isLinkingObj)) {

													if (fi.Name.StartsWith("idattach")) {
														formString += "					<label class=\"col-form-label col-md-12\" for=\"" + nametag + "\">" + fi.Title + "</label>\r\n" +
																	"					<div id=\"" + nametag + "\" " + "data-tag=\"" + datatag + searchtag + " data-custom-control=\"upload\" " +
																						(fi.Allownull ? "" : "data-mandatory ") + "></div>\r\n";
													} else {
														var metadatoChild = GetTableById(fi.Name, allfields, connection);

														if (!string.IsNullOrEmpty(metadatoChild)) {

															var listtype = !string.IsNullOrEmpty(fi.Listtype) ? fi.Listtype : "default";

															//scorro i campi e scelgo title, se no description, se no il campo testuale più piccolo ma >1 da indicare come:
															//1- campo testuale nelle tendine
															//2- campo da considerare nelle viste nella ricerca per gli oggetti 
															var txtField = GetTextFieldByTable(metadatoChild, allfields, connection, false, (listtype != "default"? listtype : null)).FirstOrDefault(); //il get missing non serve perché lo ha già fatto poco prima il GetTableById

															//potrebbe avermi restituito l'oggetto esteso partendo dall'estendente
															if (metadatoChild != txtField.Table)
																SetMetadatoChild(fields, fi, txtField.Table);
															else
																SetMetadatoChild(fields, fi, metadatoChild);

															if ((fi.MetadatoChild.Contains("kind") || fi.MetadatoChild.Contains("status") || fi.Name == "aa")) {

																var sourcetable = fi.MetadatoChild;
																//se per questo dropdown è stato specificato un list type allora utilizzo la sua vista
																if (!string.IsNullOrEmpty(fi.Listtype))
																	sourcetable += fi.Listtype + "view";

																formString += "					<label class=\"col-form-label col-md-12\" for=\"" + nametag + "\">" + fi.Title + "</label>\r\n" +
																"					<select id=\"" + nametag + "\" class=\"custom-select d-block w-100\" " +
																" data-source-name=\"" + sourcetable + "\" data-value-member=\"" + fi.Name + "\" data-display-member=\"" + txtField.Name + "\" data-custom-control=\"combo\" data-tag=\"" +
																datatag + searchtag + " " + (fi.Allownull ? "" : "data-mandatory ") + "> </select>\r\n";

															} else {
																//Autochoose
																// punto direttamente la tabella con i valori tanto il MDLW fa tutto da solo collegando le chiavi

																//se è un oggetto è estendente allora devo usare il suo list type specifico
																if (fi.Name.IndexOf("_") != -1) {
																	var extending = fi.MetadatoChild.Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[0] + "_" + fi.Name.Split('_')[1];
																	GetMissingFields(extending, null, ref allfields, connection);
																	if (allfields.Any(af => af.Table == extending))
																		listtype = fi.Name.Split('_')[1];
																	else
																		if (verbose)
																		Console.WriteLine("INFO: " + fi.Name + " è un indice con suffisso e non di una tabella estendente.");
																}

																formString +=
																"					<label class=\"col-form-label col-md-12\" for=\"" + nametag + "\">" + fi.Title + "</label>\r\n" +
																"					<div data-tag=\"AutoChoose." + nametag + "." + listtype + "\">\r\n" +
																"						<input id=\"" + nametag + "\" name=\"" + nametag + "\" type=\"text\" class=\"form-control\" data-tag=\"" +
																						fi.MetadatoChild + "." + txtField.Name + "\" data-subentity placeholder=\"...\" " + (fi.Allownull ? "" : "data-mandatory ") + "/>\r\n" +
																"					</div>\r\n";
															}
														} else {
															//il campo cominciava per id ma in realtà non era l'indice di alcuna tabella, quindi lo tratto come un campo normale
															//textbox
															formString += "					<label class=\"col-form-label col-md-12\" for=\"" + nametag + "\">" + fi.Title + "</label>\r\n" +
																		"					<input id=\"" + nametag + "\" type=\"text\" class=\"form-control\" " + "data-tag=\"" + datatag + searchtag + (fi.Allownull ? "" : " data-mandatory ") + "/>\r\n";
														}
													}

												} else {
													if (fi.Type == "char" && fi.Len == 1) {
														if (string.IsNullOrEmpty(fi.Radiovalues)) {
															if (fi.IsCheckbox) {
																//checkbox SI NO
																formString += "					<label class=\"col-form-label col-md-12\" for=\"" + fi.Name + "\">" + fi.Title + "</label>\r\n" +
																			"					<input id=\"" + nametag + "\" type=\"checkbox\" class=\"custom-control-input big-checkbox\" " + "data-tag=\"" + datatag + ":S:N" + searchtag +
																			(fi.Allownull ? "" : " data-mandatory=\"S\" ") + "/>\r\n";

															} else {
																//radio SI NO
																formString += "					<label class=\"col-form-label col-md-12\" for=\"" + fi.Name + "\">" + fi.Title + "</label>\r\n" +
																			"					<div class=\"custom-control custom-radio\">\r\n" +
																			"						<input type=\"radio\" name=\"" + fi.Name + "\" class=\"custom-control-input\" " + "data-tag=\"" + datatag + ":S" + searchtag + " " + (fi.Allownull ? "" : "data-mandatory ") + "> Si\r\n" +
																			"						<input type=\"radio\" name=\"" + fi.Name + "\" class=\"custom-control-input\" " + "data-tag=\"" + datatag + ":N" + searchtag + " " + (fi.Allownull ? "" : "data-mandatory ") + "> No\r\n" +
																			"					</div>\r\n";
															}
														} else {
															//radio personalizzato
															var v = fi.Radiovalues.Split(';').ToList();
															formString += "					<label class=\"col-form-label col-md-12\" for=\"" + fi.Name + "\">" + fi.Title + "</label>\r\n" +
																		  "					<div class=\"custom-control custom-radio\">\r\n";
															foreach (var r in v)
																if (v.IndexOf(r) % 2 == 0) {
																	formString += "						<input type=\"radio\" name=\"" + fi.Name + "\" class=\"custom-control-input\" " + "data-tag=\"" + datatag + ":" + r + searchtag + " " + (fi.Allownull ? "" : "data-mandatory ") + "> " + v[v.IndexOf(r) + 1] + "\r\n";
																}
															formString += "					</div>\r\n";
														}
													} else {
														switch (fi.Type) {
															case "date":
																//datepicker
																formString += "<script>\r\n  $( function() {\r\n    $(\"#" + nametag + "\").datepicker();\r\n  } );\r\n  </script>\r\n";
																formString += "					<label class=\"col-form-label col-md-12\" for=\"" + nametag + "\">" + fi.Title + "</label>\r\n" +
																			"					<input id=\"" + nametag + "\" type=\"text\" class=\"form-control\" " + "data-tag=\"" + datatag + searchtag + " " + (fi.Allownull ? "" : "data-mandatory ") + "/>\r\n";
																break;
															case "datetime": {
																	//datetimepicker
																	formString += "<script>\r\n  $( function() {\r\n    $(\"#" + nametag + "\").datetimepicker();\r\n  } );\r\n  </script>\r\n";
																	formString += "					<label class=\"col-form-label col-md-12\" for=\"" + nametag + "\">" + fi.Title + "</label>\r\n" +
																				"					<input id=\"" + nametag + "\" type=\"text\" class=\"form-control\" " + "data-tag=\"" + datatag + searchtag + " " + (fi.Allownull ? "" : "data-mandatory ") + "/>\r\n";
																	break;
																}
															case "varbinary":
															case "image": {
																	//upload
																	formString += "					<label class=\"col-form-label col-md-12\" for=\"" + nametag + "\">" + fi.Title + "</label>\r\n" +
																				"					<input id=\"" + nametag + "\" type=\"file\" class=\"form-control\" " + /*"data-tag=\"" + datatag + searchtag + */ " " + (fi.Allownull ? "" : "data-mandatory ") + "/>\r\n";
																	break;
																}
															case "float": {
																	//textbox
																	formString += "					<label class=\"col-form-label col-md-12\" for=\"" + nametag + "\">" + fi.Title + "</label>\r\n" +
																				"					<input id=\"" + nametag + "\" type=\"text\" class=\"form-control\" " + "data-tag=\"" + datatag +
																				(fi.Name == "latitude" || fi.Name == "longitude" ? ".fixed.7" : "") + searchtag + " " + (fi.Allownull ? "" : "data-mandatory ") + "/>\r\n";
																	break;
																}
															default: {
																	//textbox
																	formString += "					<label class=\"col-form-label col-md-12\" for=\"" + nametag + "\">" + fi.Title + "</label>\r\n" +
																				"					<input id=\"" + nametag + "\" type=\"text\" class=\"form-control\" " + "data-tag=\"" + datatag + searchtag + " " + (fi.Allownull ? "" : "data-mandatory ") + "/>\r\n";
																	break;
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
									//se i field del tab o pagina sono dispari devo chiudere l'ultima riga/colonna in quanto manca l'elemento destro che lo faceva
									if (IsSinistro(position - 1, isInverted)) {
										formString += "				</div>\r\n			</div>\r\n";
									}
								}

								//aggiungo i bottoni
								if (buttonFields.Any()) {
									foreach (var b in buttonFields.Where(bt => bt.Tab == tab.Title))
										formString += " <button id=\"" + b.Name + "\" type=\"button\" class=\"btn btn-primary p-2 mt-2\" >\r\n        <i class=\"fa " + b.Icon + " mr-1\" ></i>" + b.Title + "\r\n    </button>\r\n";
								}

								if (!(tabs.Count == 1)) {
									//chiudo il tab
									formString += "	</div>\r\n";
								}
							}
							//chiudo il form
							formString += (tabs.Count == 1 ? "" : "</div>\r\n") + "</form>\r\n";
							//metto la losta dei tab nella pagina
							ReplaceStringInFile(fullPathMetaPageHtml, "<!--tabString-->", tabString);
							//metto il form nella pagina
							ReplaceStringInFile(fullPathMetaPageHtml, "<!--formString-->", formString);

							//aggiungo il testo per l'intestazione
							var header = "	<div class=\".custom_lng_div\" data-langkey=\"pageheader" + o.PageId + "\" >" + o.Header + "</div>";
							ReplaceStringInFile(fullPathMetaPageHtml, "<!--header-->", header);

							//...aggiungo l'etichetta per l'intestazione
							if (!string.IsNullOrWhiteSpace(o.Header)) {
								var labelTextHeader = "// lables\r\n		pageheader" + o.PageId + ": \"" + o.Header + "\",\r\n";
								ReplaceStringInFile(clientFolder + "assets/i18n/LocalResourceIt.js", "// lables\r\n", labelTextHeader);
							}

							//aggiungo il testo per il footer
							var footer = "	<div class=\".custom_lng_div\" data-langkey=\"pagefooter" + o.PageId + "\" >" + o.Footer + "</div>";
							ReplaceStringInFile(fullPathMetaPageHtml, "<!--footer-->", footer);

							//...aggiungo l'etichetta per il footer
							if (!string.IsNullOrWhiteSpace(o.Footer)) {
								var labelTextFooter = "// lables\r\n		pagefooter" + o.PageId + ": \"" + o.Footer + "\",\r\n";
								ReplaceStringInFile(clientFolder + "assets/i18n/LocalResourceIt.js", "// lables\r\n", labelTextFooter);
							}

							if (!skipmetapageDataset) {
								Console.WriteLine("2.3) CREO IL DATASET DELLA PAGINA APARTIRE DA QUELLO DEL METADATO");

								//-copio il dataset vuoto nel backend data
								var fullpathDatasetMetaData = solutionFolder + metadataFolder + container + "/meta_" + (!string.IsNullOrEmpty(extendedObject)? extendedObject : o.Table) + "/vista";
								var fullpathDatasetMetapage = backendFolder + "Data/dsmeta_" + (!string.IsNullOrEmpty(extendingObject) ? extendedObject : o.Table) + "_" + editListingTypes ;
								Copy(fullpathDatasetMetaData + ".xsd", fullpathDatasetMetapage + ".xsd", true);
								Copy(fullpathDatasetMetaData + ".xsc", fullpathDatasetMetapage + ".xsc", true);
								Copy(fullpathDatasetMetaData + ".xss", fullpathDatasetMetapage + ".xss", true);
								Copy(fullpathDatasetMetaData + ".Designer.cs", fullpathDatasetMetapage + ".cs", true);
								//-dsmeta_ come prefisso in System.Xml.Serialization.XmlRoot
								ReplaceStringInFile(fullpathDatasetMetapage + ".xsd", "id=\"vista\"", "id=\"dsmeta_" + (!string.IsNullOrEmpty(extendingObject) ? extendedObject : o.Table) + "_" + editListingTypes + "\"");
								ReplaceStringInFile(fullpathDatasetMetapage + ".xsd", "name=\"vista\"", "name=\"dsmeta_" + (!string.IsNullOrEmpty(extendingObject) ? extendedObject : o.Table) + "_" + editListingTypes + "\"");

								//preparo una lista dei campi per calcolare gli alias
								var datasetfields = new List<field>();
								datasetfields.AddRange(fields.Where(f => f.Detailvisible));

								//-popolo il datased della pagina nel project beckend
								if (!string.IsNullOrEmpty(extendingObject)) {
									//--se stiamo lavorando con un oggetto esteso, devo inserire la loro relazione e l'estendente
									PreparePageDataset(fullpathDatasetMetapage + ".xsd", extendedObject,
										o.Table,
										objectKey.Where(k => k.Contains(extendedObjectKey.First())).First(), extendedObjectKey.First(), //chiavi
										current, false, datasetfields, allfields, editListingTypes, "", null,
										connection, false, 1, "", true);
								}

								foreach (var fi in fields.Where(f => f.Detailvisible)) {
									//--se trovo altre chiavi nei capi VISIBILI aggiungo le tabelle e le relazioni
									if ((!fi.IsKey || isLinkingObj || fi.IsLinkingObj) && (HaveKeyName(fi) || fi.Name.StartsWith("XX")) /* && !fi.Name.StartsWith("parid")*/) {
										var tablechild = "";
										var key = "";
										var childkey = "";
										var minimal = false;
										var pageid = "";
										var editListTypeField = editListingTypes;
										var extendedTableChild = "";

										//nel caso si tratta di un id vero e proprio
										if (HaveKeyName(fi)) {
											if (fi.Name.StartsWith("parid")) {
												//se punto a me stesso interrompo
												if ((string.IsNullOrEmpty(fi.Listtype) ? "default" : fi.Listtype) == editListingTypes)
													continue;
											}
											tablechild = fi.MetadatoChild ?? GetTableById(fi.Name, allfields, connection); //se sono passato per un autochoose l'ho già calcolato, con l'eventuale alias
																														   //se per questo dropdown è stato specificato un list type allora utilizzo la sua vista
											if ((fi.MetadatoChild.Contains("kind") || fi.MetadatoChild.Contains("status") || fi.Name == "aa") && !string.IsNullOrEmpty(fi.Listtype))
												tablechild += fi.Listtype + "view";
											key = fi.Name; //potrebbe avere suffissi o prefissi
											childkey = GetIdByForeignKey(fi.Name, fi.Table);
											minimal = true;
											editListTypeField = string.IsNullOrEmpty(fi.Listtype) ? "default" : fi.Listtype;
											extendedTableChild = "";
										}
										//se è una tabella figlia prendo come chiave quella dell'oggetto
										if (fi.Name.StartsWith("XX")) {
											tablechild = /*fi.MetadatoChild ??*/ fi.Name.Substring(2);
											//key e childkey per le relazioni tra subentità (TODO: e non?) sono sempre tutte le chiavi del padre
											key = string.Join(" ", objectKey); // GetIdByForeignKey(fi.LookupFor, tablechild);
											childkey = fi.LookupFor ?? string.Join(" ", objectKey); //foreign key anche con suffissi o prefissi ?? subentità
											pageid = fi.PageId;
											editListTypeField = fi.EditListingType;
											extendedTableChild = fi.MetadatoChild;
										}

										if (!string.IsNullOrEmpty(tablechild) && !string.IsNullOrEmpty(key) &&
											tablechild != extendedObject) //evito i riferimenti circolari quando, scandendo l'extending, trovo la chiave, che è come quella dell'extended, che viene scambiato come figlio
											PreparePageDataset(fullpathDatasetMetapage + ".xsd", fi.Table, tablechild, key, childkey, o.Table, minimal, datasetfields, allfields, editListTypeField, editListingTypes, pageid, connection, fi.IsLinkingObj, 1, extendedTableChild, false);
									}
								}

								//modifico il file cs del dataset
								HDSGen.FileNameSpace = "Backend.Data";
								File.WriteAllBytes(fullpathDatasetMetapage + ".cs", HDSGen.iGenerateCode(fullpathDatasetMetapage + ".xsd", File.ReadAllText(fullpathDatasetMetapage + ".xsd", Encoding.Default)));

							}

							#endregion
						}
					} else {
						Console.WriteLine("WARNING non genero l'interfaccia per la tabella " + o.Table + " con l'edit type " + o.EditListingType + " perchè esiste l'oggetto " + o.Table + "_" + o.EditListingType + " che lo estende");
					}
				}

				connection.Close();
			}

			Console.WriteLine("Fine della generazione del codice");

			if (!skipmetadato || true) {
				Console.WriteLine("Eseguo il build della solution dei metadati e copio le dll");


				string builder = @"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\msbuild.exe";
				var building = new Process(){
					StartInfo = new ProcessStartInfo {
						WindowStyle = ProcessWindowStyle.Maximized,
						FileName = builder,
						Arguments = solutionFolder + solutionFile + " /p:configuration=debug",
					}
				};

				//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
				//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!Quando arrivi qui fai il REVERT di Registry e Location!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
				building.Start();
				//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

				building.WaitForExit();

				string copyer = Path.GetFullPath(backendFolder + "../BUILD_COPY_dll.bat");
				var copinging = new Process(){
					StartInfo = new ProcessStartInfo {
						WindowStyle = ProcessWindowStyle.Normal,
						FileName = copyer
					}
				};
				copinging.Start();
				copinging.WaitForExit();

			}

			if (!skipmetapage) {
				Console.WriteLine("Aprire la solution del Backend e premi start");
				//Console.ReadLine();
			}
		}

		#region generazione dei progetti
		private static string PrepareCsproj(string current, string container, string title, string editListingTypes, bool othersAppObject, List<string> objectKey = null) {

			//creo la cartella contenitore
			if (!Directory.Exists(solutionFolder + metadataFolder + container))
				Directory.CreateDirectory(solutionFolder + metadataFolder + container);

			//recupero e aumento il numero della varsione se esisteva una versione orecedente
			var ver = "01.01.001";
			var verToReplace = "01.01.001";
			var fullPathAssemblyInfo = solutionFolder + metadataFolder + container + "/meta_" + current + "/AssemblyInfo.cs";
			if (Directory.Exists(solutionFolder + metadataFolder + container + "/meta_" + current)) {
				verToReplace = Regex.Match(File.ReadAllText(fullPathAssemblyInfo, Encoding.Default), @"\(""([^)]*)""\)", RegexOptions.Singleline).Groups[1].Value;
				if (verToReplace.Length == 9)
					ver = verToReplace.Substring(0, 2) + "." + (int.Parse(verToReplace.Substring(3, 2)) + verIncrement).ToString().PadLeft(2, '0') + "." + verToReplace.Substring(6, 3);
				else
					if (verbose)
					Console.WriteLine("WARNING: Impossibile aggiornare la versione " + verToReplace + " del progetto meta_" + current);
			}

			var fullPathcs = solutionFolder + metadataFolder + container + "/meta_" + current + "/meta_" + current + ".cs";
			if ((!File.Exists(fullPathcs) || !alreadyCreated.Contains(current)) && !othersAppObject) {
				alreadyCreated.Add(current);

				//copio il template nella cartella del metadato
				CopyDir("../../meta_template", solutionFolder + metadataFolder + container + "/meta_" + current);

				//scrivo il numero della versione corrente
				if (verToReplace != ver)
					ReplaceStringInFile(fullPathAssemblyInfo, verToReplace, ver);

				//-rinomino il file del project
				var fullPathcsproj = RenameFile(solutionFolder + metadataFolder  + container + "/meta_" + current + "/meta_tabella.csproj", current);

				//-modifico il file del project
				ReplaceStringInFile(fullPathcsproj, "$tableName$", current);
				ReplaceStringInFile(fullPathcsproj, "..\\..\\dll\\", dllCoreFolder);
				ReplaceStringInFile(fullPathcsproj, "xcopy \"$(TargetDir)$(TargetName).*\"  \"$(SolutionDir)output\" /Y", dllOutputFolder);

				//verifico che il progetto non sia già stato iserito in passato, altrimenti dovrei recuperare il GUID per il progetto
				string pattern = "meta_" + current + ".csproj\", \"{(.*?)}\"\r\nEndProject";
				var newGuid = Regex.Matches(File.ReadAllText(solutionFolder + solutionFile, Encoding.Default), pattern, RegexOptions.Singleline).Cast<Match>()
				.Select(m => m.Value.Replace("meta_" + current + ".csproj\", \"{", "").Replace("}\"\r\nEndProject", "")).FirstOrDefault();
				if (string.IsNullOrEmpty(newGuid)) {
					newGuid = Guid.NewGuid().ToString().ToUpper();
					//-lo aggiungo a questa solution
					var stringProjects = "\r\nProject(\"{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}\") = \"meta_" + current + "\", \"" + metadataFolder.Replace("/", "\\") + container + "\\meta_" + current + "\\meta_" +
				current + ".csproj\", \"{" + newGuid + "}\"\r\nEndProject\r\nGlobal\r\n";
					ReplaceStringInFile(solutionFolder + solutionFile, "\r\nGlobal\r\n", stringProjects);
				} else {
					if (verbose)
						Console.WriteLine("INFO: Il progetto meta_" + current + " è già presente sulla solution quindi non verrà aggiunto");
				}
				ReplaceStringInFile(fullPathcsproj, "$newGuid$", newGuid);

				//-rinomino il file cs
				fullPathcs = RenameFile(solutionFolder + metadataFolder + container + "/meta_" + current + "/meta_tabella.cs", current);

				//-faccio le sostituzioni nel file cs per il nome
				ReplaceStringInFile(fullPathcs, "$tableName$", current);
				ReplaceStringInFile(fullPathcs, "$title$", title);

				if (objectKey != null) {
					//aggiungo la chiave nel metadato della vista
					var pkstring = "private string[] mykey = new string[] {\"" + string.Join("\",\"", objectKey) +
								"\"};\r\n\r\n		public override string[] primaryKey() {\r\n			return mykey;\r\n		}";
					ReplaceStringInFile(fullPathcs, "//$PrymaryKey$", pkstring);
					//cancello il dataset perchè negli oggetti vista non serve
					var datasetMetadatoViewName = solutionFolder + metadataFolder + container + "/meta_" + current + "/vista";
					File.Delete(datasetMetadatoViewName + ".xsd");
					File.Delete(datasetMetadatoViewName + ".xsc");
					File.Delete(datasetMetadatoViewName + ".xss");
					File.Delete(datasetMetadatoViewName + ".Designer.cs");
					var fullPathCsproj =  fullPathcs + "proj";
					ReplaceStringInFile(fullPathCsproj,
					"    <Compile Include=\"vista.Designer.cs\">\r\n      <AutoGen>True</AutoGen>\r\n      <DesignTime>True</DesignTime>\r\n      <DependentUpon>vista.xsd</DependentUpon>\r\n    </Compile>\r\n", "");
					ReplaceStringInFile(fullPathCsproj,
					"    <None Include=\"vista.xsd\">\r\n      <SubType>Designer</SubType>\r\n      <Generator>HDSGene</Generator>\r\n      <LastGenOutput>vista.Designer.cs</LastGenOutput>\r\n    </None>\r\n    <None Include=\"vista.xss\">\r\n      <DependentUpon>vista.xsd</DependentUpon>\r\n    </None>\r\n    <None Include=\"vista.xsc\">\r\n      <DependentUpon>vista.xsd</DependentUpon>\r\n    </None>\r\n", "");

				}

			} else {
				//rinfresco comunque il dataset
				Copy("../../meta_template/vista.xsd", solutionFolder + metadataFolder + container + "/meta_" + current + "/vista.xsd", true);
			}

			//provo sempre ad aggiungere l'edit-listing type
			var editTypesString = "EditTypes.Add(\"" + editListingTypes + "\");\r\n\t\t\tListingTypes.Add(\"" + editListingTypes + "\");\r\n\t\t\t//$EditTypes$";
			ReplaceStringInFile(fullPathcs, "//$EditTypes$", editTypesString);

			//aggiungo la dll nel file bat
			ReplaceStringInFile(backendFolder + "../BUILD_COPY_dll.bat", "xcopy \"%pathSrc%metaeasylibrary.dll\" %pathDest% /Y\r\n\r\n",
				"xcopy \"%pathSrc%metaeasylibrary.dll\" %pathDest% /Y\r\n\r\n" + "xcopy \"%pathSrc%meta_" + current + ".dll\" %pathDest% /Y\r\n");

			return fullPathcs;

		}

		/// <summary>
		/// Inserisce la reference al metadato nel file project
		/// </summary>
		/// <param name="file">project file</param>
		/// <param name="metadato">metadato</param>
		private static void SetReference(string file, string metadato) {
			var referencestring = "  <ItemGroup>\r\n" +
						"    <Reference Include=\"meta_" + metadato + "\">\r\n" +
						"      <HintPath>..\\libraries\\meta_" + metadato + ".dll</HintPath>\r\n" +
						"    </Reference>\r\n" +
						"    <Reference";
			ReplaceStringInFile(file, "  <ItemGroup>\r\n    <Reference", referencestring);
		}

		/// <summary>
		/// Inserisce una reference ad un file project
		/// </summary>
		/// <param name="file">file project</param>
		/// <param name="reference">codice XML della reference</param>
		private static void SetGeneralReference(string file, string reference) {
			var referencestring = "  <ItemGroup>\r\n" + reference + "\r\n    <Reference";
			ReplaceStringInFile(file, "  <ItemGroup>\r\n    <Reference", referencestring);
		}

		#endregion

		#region gestione dei fields
		private static bool IsSinistro(int index, bool isinverted) {
			bool dispari = (index % 2 != 0);
			return isinverted ? !dispari : dispari;
		}

		/// <summary>
		/// Recupera dal DB le colonne della tabella o della chiave passata come parametro
		/// </summary>
		/// <param name="tablename">tabella</param>
		/// <param name="tablekey">chiave</param>
		/// <param name="allfields">campi da popolare</param>
		/// <param name="connection">connessione</param>
		private static void GetMissingFields(string tablename, string tablekey, ref List<field> allfields, SqlConnection connection, bool showmessage = true) {

			//se cerco una tabella ...
			if (!string.IsNullOrEmpty(tablename)) {

				//tolgo l'alias
				if (tablename.Contains("_alias"))
					tablename = tablename.Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[0];

				if (allfields.Any(af => af.Table == tablename)) {
					//...e già c'è non faccio nulla
					return;
				}

			} else {

				//ripulisco la chiave da prefissi e suffissi
				tablekey = GetIdByForeignKey(tablekey, null);
			}

			//passate le verifiche precedenti me li prendo dal db
			var queryColonne = "";
			if (string.IsNullOrEmpty(tablekey)) {
				queryColonne = queryFields + " where (a.idapplicazione = " + applicationID + " or a.idapplicazione is null) and isc.TABLE_NAME = '" + tablename + "'";
			} else {
				queryColonne = queryFields + " where (a.idapplicazione = " + applicationID + @" or a.idapplicazione is null) and isc.TABLE_NAME in (SELECT /*TOP 1*/ cc.TABLE_NAME 
										 FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE cc 
										 WHERE cc.COLUMN_NAME = '" + tablekey + @"' AND 
										 OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + QUOTENAME(CONSTRAINT_NAME)), 'IsPrimaryKey') = 1
										 /*order by LEN(cc.TABLE_NAME)*/)";
			}

			SqlCommand cmd = new SqlCommand(queryColonne, connection);
			cmd.CommandTimeout = 120;
			var dataReader = cmd.ExecuteReader();
			var colonne = new DataTable();
			colonne.Load(dataReader);

			if (showmessage && verbose && colonne.Rows.Count == 0) {
				if (!string.IsNullOrEmpty(tablename))
					Console.WriteLine("WARNING: Per la tabella " + tablename + " non sono è stato trovato alcun campo.");
				if (!string.IsNullOrEmpty(tablekey))
					Console.WriteLine("WARNING: Per la chiave " + tablekey + " non sono è stato trovata alcuna tabella e di conseguenza alcun campo.");
			}

			SetFieldsByRows(colonne, ref allfields);
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
				if (!(new List<string> { "idman", "idsor05", "idsor04", "idsor03", "idsor02", "idsor01", "idaccmotivecredit", "idaccmotivedebit" }).Contains(r["field"].ToString()) //gestione naming non standard
					) {
					var f = new field {
						Name = r["field"].ToString(),
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
						Allownull = r["allownull"].ToString() == "S", //se in bianco lo prendo per un NO
						SortData = r["getsorting"].ToString(),
						PageId = r["idapppages"].ToString(),
						Defaultvalue = r["defaultvalue"].ToString(),
						EditListingType = string.IsNullOrEmpty( r["editlistingtype"].ToString()) ? "default": r["editlistingtype"].ToString(),
						Textfield = r["textfield"].ToString() == "" ? 0 : int.Parse(r["textfield"].ToString()),
						Radiovalues = r["radiovalues"].ToString(),
						IsLinkingObj = r["islinkingobj"].ToString() == "S", //se in bianco lo prendo per un NO
						Hidden = r["hidden"].ToString() == "S", //se in bianco lo prendo per un NO
						Listtype = r["listtype"].ToString(),
						Filter = r["filter"].ToString(),
						Textarea = r["textarea"].ToString() == "S",//se in bianco lo prendo per un NO
						IsCheckbox = r["ischeckbox"].ToString() == "S",//se in bianco lo prendo per un NO
						Text = r["text"].ToString(),
						UniqueOnRow = r["uniqueonrow"].ToString() == "S",//se in bianco lo prendo per un NO
						Tabheader= r["tabheader"].ToString()
					};

					//se è un vocabolario configuro i fields in automatico
					if (r["tablename"].ToString().Contains("kind") || r["tablename"].ToString().Contains("status") || r["vocabolario"].ToString() == "S") {
						if (f.IsKey) { f.SortList = 1; f.Sort = 1; f.Title = "Codice"; }
						if (f.Name == "title") {
							f.SortList = 2;
							f.Sort = 2;
							if (r["tablename"].ToString().Contains("kind")) f.Title = "Tipologia";
							if (r["tablename"].ToString().Contains("status")) f.Title = "Stato";
						}
						if (f.Name == "description") { f.SortList = 3; f.Sort = 3; f.Title = "Descrizione"; }
						if (f.Name == "sortcode") { f.SortList = 4; f.Sort = 4; f.SortData = "desc"; f.Title = "Ordinamento"; }
						if (f.Name == "active") { f.SortList = 5; f.Sort = 5; f.Title = "Attivo"; }
					}

					if (!allfields.Any(af => af.Table == f.Table && af.EditListingType == f.EditListingType && af.Name == f.Name))
						allfields.Add(f);
				}

			}
		}

		/// <summary>
		/// Restituisce una lista di fields che contengono solamente i dati relativi alla tabella senza quelli delle interfacce che vi si riferiscono
		/// Serve a deduplicare i fileds quando sono presenti un più interfacce
		/// </summary>
		/// <param name="tablename"></param>
		/// <param name="allfields"></param>
		/// <returns></returns>
		private static List<field> GetDatasetFields(string tablename, List<field> allfields) {

			var output = new List<field>();

			//tolgo l'alias
			if (tablename.Contains("_alias"))
				tablename = tablename.Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[0];

			foreach (var f in allfields.Where(fi => fi.Table == tablename)) {
				if (!output.Any(fi =>
					 f.Table == fi.Table &&
					 f.Name == fi.Name /* &&
					 f.IsKey == fi.IsKey &&
					 f.Type == fi.Type &&
					 f.Len == fi.Len &&
					 f.Allownull == fi.Allownull*/)) {
					output.Add(new field {
						Table = f.Table,
						Name = f.Name,
						IsKey = f.IsKey,
						Type = f.Type,
						Len = f.Len,
						Allownull = f.Allownull,
						IsLinkingObj = f.IsLinkingObj,
						Textfield = f.Textfield,
						Listtype = f.Listtype,
						Radiovalues = f.Radiovalues
					});
				} else {
					if (f.Textfield != 0) {
						var precField = output.Where(fi => f.Table == fi.Table && f.Name == fi.Name).First();
						if (precField.Textfield == 0)
							precField.Textfield = f.Textfield;
					}
				}
			}

			return output;
		}

		/// <summary>
		/// Restituisce i campi corrispondenti di una tabella con un certo editlisttype
		/// </summary>
		/// <param name="tablename">tabella</param>
		/// <param name="editlisttype">editlisttype</param>
		/// <param name="allfields">tutti i campi</param>
		/// <returns>i campi corrispondenti a tablename e editlisttype</returns>
		private static List<field> GetFields(string tablename, string editlisttype, List<field> allfields) {

			//tolgo l'alias
			if (tablename.Contains("_alias"))
				tablename = tablename.Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[0];

			return allfields.Where(fi => fi.Table == tablename && fi.EditListingType == editlisttype).ToList();
		}

		/// <summary>
		/// aggiunge la tabella figlia ad un field foreignkey, con l'eventuale alias.
		/// </summary>
		/// <param name="fields">campi della pagina attuale</param>
		/// <param name="fi">campo foreignkey che si sta valutando</param>
		/// <param name="metadatoChild">tabella a cui porta la foreignkey</param>
		private static void SetMetadatoChild(List<field> fields, field fi, string metadatoChild) {

			//verfico se non ho già costruito la relazione per lo stesso campo
			var otherForeighKeyForSameFiled = fields.Where(f=> f.MetadatoChild != null && f.Table == fi.Table && f.Name == fi.Name).FirstOrDefault();
			if (otherForeighKeyForSameFiled != null)
				fi.MetadatoChild = otherForeighKeyForSameFiled.MetadatoChild;
			else {

				//verifico se non ci sono stati altri campi nella stessa pagina che puntano alla stessa tabella
				var otherForeignKeyInTable = fields.Where(f=> f.MetadatoChild != null).Count(f =>
														(f.MetadatoChild == metadatoChild || //stesso meta figlio 
														(f.MetadatoChild.StartsWith(metadatoChild) && f.MetadatoChild.Contains("_alias"))) && //o suo alias
														(f.Table != fi.Table || f.Name != fi.Name) //altro campo
													);
				//verifico che la foreign key non punti a tabelle dei campi stessi
				var otherFieldsInDataset = fields.Any(f =>
														f.Table == metadatoChild && //padre = meta figlio
														(f.Table != fi.Table || f.Name != fi.Name) //altro campo
													);
				var totalAliases = otherForeignKeyInTable  + (otherFieldsInDataset ? 1 : 0);
				if (totalAliases > 0) {
					//devo inserire i riferimenti successivi al primo con degli alias, sia nel dataset che nell'html, indicando poi nel js quale è la vera tabella da interrogare nelle query
					fi.MetadatoChild = metadatoChild + "_alias" + totalAliases.ToString();
				} else
					fi.MetadatoChild = metadatoChild;
			}
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
			var queryRelations = @" select pt.tablename as parenttable, ct.tablename as childtable, isnull(r.[description],ct.title) as [description], 
												   isnull(r.editlistingtype , ct.editlistingtype) as editlistingtype, --se non specificato nella relazione uso l'edit type della pagina
												   ct.icon, r.type, r.idapppages, r.calendartitle, r.calendarstart, r.calendarstop, r.numrowsmandatory
											from apprelation r
											left outer join apppages pt on pt.idapppages = r.idapppages_parent
											left outer join apppages ct on ct.idapppages = r.idapppages
											where pt.idapppages = '" + pageId + "' ";
			var cmdRelations = new SqlCommand(queryRelations, connection);
			var dataReaderRelations = cmdRelations.ExecuteReader();
			var relations = new DataTable();
			relations.Load(dataReaderRelations);

			var currentObjectKey = allfields.Where(k=> k.IsKey && k.PageId == pageId).OrderBy(x=>x.Name);

			foreach (DataRow relation in relations.Rows) {
				var tablename = relation["childtable"].ToString();

				//scarico dal db i campi
				GetMissingFields(tablename, null, ref allfields, connection);

				//verifico che sia una vera entità figlia (deve avere un riferimento alla chiave dell'oggetto corrente)
				if (allfields.Any(af => af.Table == tablename && currentObjectKey.Any(k => k.Name == af.Name.Split('_')[0]))) {

					var tabtitle = string.IsNullOrEmpty(relation["description"].ToString()) ? tablename : relation["description"].ToString();
					var editListingType = string.IsNullOrEmpty(relation["editlistingtype"].ToString()) ? "default" : relation["editlistingtype"].ToString();
					//string lookupFor = null;
					var numrowsmandatory = string.IsNullOrEmpty(relation["numrowsmandatory"].ToString()) ? 0 : int.Parse(relation["numrowsmandatory"].ToString().Trim());

					var fi = new field {
						Tab = tabtitle,
						Icon = relation["icon"].ToString(),
						RelationType = /*IsLinkingObject(tablename,ref allfields,connection) ? "cerca" :*/ relation["type"].ToString() ?? "", //forzo la griglia con la ricerca incorporata per tutte le tabelle di collegamnento
						Tabposition = fields.Count + 1,
						Title = tabtitle,
						Name = "XX" + tablename, //concateno XX al nome della tabella figlia
						Table = !string.IsNullOrEmpty(extendedObject) ? extendedObject : currentObjectKey.First().Table, //se si tratta di un oggetto estendente riassocio le relazioni sempre all'oggetto esteso
						Detailvisible = true,
						EditListingType = editListingType,
						ListVisible = false, //faccio in modo che non vada nel describe columns
						Defaultvalue = null, //faccio in modo che non vada nel set default
						Allownull = (numrowsmandatory == 0), //finisce nella is valid se servono delle righe 
						Len = 0, //faccio in modo che non finisca nel is valid 
						PageId = relation["idapppages"].ToString(), //il page id del figlio
						PageIdParent = pageId,
						CalendarSettings = relation["calendartitle"].ToString() + ";" + relation["calendarstart"].ToString() + ";" + relation["calendarstop"].ToString(),
						Numrowsmandatory = numrowsmandatory, 
					};

					//se l'entità figlia à un oggetto esteso
					if (IsExtendingObject(tablename, ref allfields, connection)) {
						//ricavo l'estendente
						var extendedobjectChild = tablename.Split('_')[0];

						//se l'entità figlia è estesa e il suo esteso è ugauale all'esteso dell'oggetto corrente
						if (extendedobjectChild == extendedObject) {
							//... allora imposto la relazione sulla gerarchia ricorsiva id<->parid
							var parid = allfields.Where(af => af.Table == extendedObject && af.Name == "parid" + extendedObject).FirstOrDefault();
							if (parid != null)
								fi.LookupFor = parid.Name;
						}
					}

					if (fi.LookupFor == null) {
						//verifico che non si tratti di una subentità ovvero tutta la chiave del padre è contenuta nel figlio
						var childkey = allfields.Where(af => af.Table == tablename && af.EditListingType == editListingType && af.IsKey).Select(ck=>ck.Name); //TODO le entità figlie devono avere lo stesso nome della chiave?
						if (currentObjectKey.All(cok => childkey.Contains(cok.Name)))
							fi.LookupFor = string.Join(" ", currentObjectKey.Select(x => x.Name).ToList());
					}

					if (fi.LookupFor == null) {
						//tutti i campi sulla tabella figlia che sono FK per una PK della madre e non sono visibili 
						//nelle tebelle di collegamento e simili che si riferiscono più di una volta alla stessa tabella la relazione con la madre non è visibile
						fi.LookupFor = string.Join(" ", allfields.Where(af => af.Table == tablename && af.EditListingType == editListingType && !af.Detailvisible &&
										currentObjectKey.Any(cok => cok.Name == GetIdByForeignKey(af.Name, af.Table))).OrderBy(x => x.IsKey).Select(x => x.Name).ToList());

						if (string.IsNullOrEmpty(fi.LookupFor)) {
							//paracadute nel caso mi sia scordato visibile la fk
							fi.LookupFor = string.Join(" ", allfields.Where(af => af.Table == tablename && af.EditListingType == editListingType &&
											currentObjectKey.Any(cok => cok.Name == GetIdByForeignKey(af.Name, af.Table))).OrderBy(x => x.IsKey).Select(x => x.Name).ToList());
							if (verbose)
								Console.WriteLine("WARNING: per l'interfaccia " + tablename + " " + editListingType + " è visibile i campo di collegamento con l'interfaccia madre " + fi.LookupFor + " solitamente non necessario");
						}

					}

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
		public static field RenewField(field f, int sortList, bool detailVisible, bool listVisible, string lookupFor = null, string alias = null, string table = null, string title = null) {
			return new field {
				Name = f.Name,
				Title = (string.IsNullOrEmpty(title) ? f.Title : title), //gli passo il title definito per la foreign key sul padre (es: idclassconsorsuale su docenti diventa "Classe Consorsuale")
				Sort = f.Sort,
				SortList = sortList,
				Type = f.Type,
				Len = f.Len,
				Tab = f.Tab,
				Tabposition = f.Tabposition,
				Table = (string.IsNullOrEmpty(table) ? f.Table : table),
				IsKey = f.IsKey,
				Detailvisible = detailVisible,
				ListVisible = listVisible,
				Allownull = f.Allownull,
				SortData = f.SortData,
				ViewAlias = alias,
				LookupFor = lookupFor
			};
		}

		#endregion

		#region generazione del dataset

		/// <summary>
		/// Genera tabelle e relazioni nel dataset di pagina
		/// </summary>
		/// <param name="pathMetaPage">percorso del file del dataset</param>
		/// <param name="metadatoParent">oggetto parent</param>
		/// <param name="metadatoChild">oggetto child</param>
		/// <param name="key">chiave su cui costruire la relazione</param>
		/// <param name="current">oggetto di pagina</param>
		/// <param name="minimal">solo id e campo stestuale</param>
		/// <param name="fields">i campi del dataset</param>
		/// <param name="allfields">tutti i campi</param>
		/// <param name="editListingType">editListingType</param>
		/// <param name="pageid">id della interfaccia figlia</param>
		/// <param name="connection">connessione</param>
		/// <param name="skiplookup">non genera le tabelle collegate per i lookup</param>
		private static void PreparePageDataset(string pathMetaPage, string metadatoParent, string metadatoChild, string parentKey, string childkey, string current, bool minimal, List<field> fields, List<field> allfields,
			string editListingType, string editListingTypeParent,
			string pageid, SqlConnection connection, bool isLinkingObjKey, int iteration, string extendedTableChild, bool skiplookup = false) {

			if (metadatoParent != metadatoChild) {

				var metadatoParentOriginal =  metadatoParent;
				if (metadatoParent.Contains("_alias"))
					//se il parent è un alias lo uso e calcolo il valore originale
					metadatoParentOriginal = metadatoParent.Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[0];

				var datasetMetadatoParent = "";
				if (metadatoParent != current) {

					datasetMetadatoParent = GetDatasetTable(metadatoParent, false, allfields, connection);
					if (!string.IsNullOrEmpty(datasetMetadatoParent))
						if (!File.ReadAllText(pathMetaPage, Encoding.Default).Contains("<xs:element name=\"" + metadatoParent + "\">")) {
							ReplaceStringInFile(pathMetaPage, "<xs:choice minOccurs=\"0\" maxOccurs=\"unbounded\">\r\n", "<xs:choice minOccurs=\"0\" maxOccurs=\"unbounded\">\r\n" + datasetMetadatoParent.Split(';')[0]);
							ReplaceStringInFile(pathMetaPage, "</xs:complexType>\r\n		<xs:unique", "</xs:complexType>\r\n		" + datasetMetadatoParent.Split(';')[1] + "		<xs:unique");
						}
				}

				var datasetMetadatoChild = "";
				var parentIsLinkingObject = IsLinkingObject(metadatoParent, ref allfields, connection) || isLinkingObjKey;

				var metadatoChildOriginal =  metadatoChild;
				if (metadatoChild.Contains("_alias"))
					//se il child è un alias lo uso e calcolo il valore originale
					metadatoChildOriginal = metadatoChild.Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[0];

				if (metadatoChild != current) {

					//aggiungo la tabella figlia e la sua relazione con la tabella principale
					//se è una figlia di una tabella di collegamento però la figlia va inserita sempre con tutti i campi
					if (parentIsLinkingObject || metadatoChildOriginal == "attach")
						minimal = false;
					datasetMetadatoChild = GetDatasetTable(metadatoChild, minimal, allfields, connection, !minimal && !parentIsLinkingObject ? parentKey : null);

					if (!string.IsNullOrEmpty(datasetMetadatoChild)) {

						var islinkingobject = IsLinkingObject(metadatoChildOriginal, ref allfields, connection);

						//aggiungo alla tabella principale il campo di lookup della relazione attuale 
						//nella entità padre (principale) della pagina in relatà i campi non ci andranno (ed è giusto che non ci vadano) 
						//perchè il segnaposto (commento) è già stato rimosso da HDSGene quando è stato fatto il metadato e questo file inizialmente ne è la copia
						//ma nel caso di oggetti estesi la tabella estendente si aggiunge in un secondo momento per due volte, come figlia e come padre, 
						//quindi al momento in cui viene aggiunta la prima volta come figlia, non vanno aggiunti i campi di lookup (skiplookup = true).
						//in ogni caso non elaboro campi di lookup per le tabelle di collegamento che non hanno campi testuali da mostrare
						if (!skiplookup && !islinkingobject && iteration == 2) {

							var objCalcFiledConfig = "";
							var describeColumns = "";
							if (parentIsLinkingObject) {
								//se il parent è un oggetto di collegamento allora i campi ci vanno tutti
								var calculatedfields = new List<field>();
								calculatedfields.AddRange(allfields.Where(af => af.Table == metadatoChildOriginal && af.EditListingType == editListingType && af.ListVisible && !af.IsKey));
								foreach (var cf in calculatedfields.OrderBy(f => f.SortList)) {
									var lookupTable = metadatoChild;
									var textField = cf;
									if (HaveKeyName(cf)) {
										//devo mettere il campo di lookup al suo posto
										lookupTable = cf.MetadatoChild ?? GetTableById(cf.Name, allfields, connection);
										var lookupField = GetTextFieldByTable(lookupTable,allfields,connection,true).FirstOrDefault();
										// ha trovato il capo testuale o ha una chiave testuale
										if (lookupField.Name != cf.Name ||
											(new List<string>() { "char", "nchar", "nvarchar", "varchar", "text" }).Contains(lookupField.Type)) {
											textField = lookupField;
											lookupTable = lookupField.Table;
										} else
											lookupTable = metadatoChild;
									}

									//dataset
									ReplaceStringInFile(pathMetaPage, "<!--LookupFields " + metadatoParent + "-->",
										"<xs:element name=\"" + "_x0021_" + parentKey.Replace(" ", "-") + "_" + metadatoChildOriginal + "_" + cf.Name + "\" " + " msdata:ReadOnly=\"false\" msdata:AllowDBNull=\"true\" " +
										"type=\"xs:" + GetDatasetType(textField.Type) + "\" minOccurs=\"0\" />\r\n" + "<!--LookupFields " + metadatoParent + "-->");

									//metadato javascript
									objCalcFiledConfig += "						objCalcFiledConfig['!" + parentKey.Replace(" ", "-") + "_" + metadatoChildOriginal + "_" + cf.Name + "'] = {tableNameLookup:'" + lookupTable +
									"', columnNameLookup:'" + textField.Name + "', columnNamekey:'" + parentKey.Replace(" ", "-") + "' };\r\n";

									//metadato c#
									var colName=  "!" + parentKey.Replace(" ", "-") + "_" + metadatoChildOriginal + "_" + cf.Name ;
									describeColumns += "\t\t\t\t\t\tDescribeAColumn(T, \"" + colName + "\", \"" + cf.Title + "\", nPos++);\r\n";
									if (cf.Type == "datetime")
										describeColumns += "\t\t\t\t\t\tif (T.Columns.Contains(\"" + colName + "\")) T.Columns[\"" + colName + "\"].ExtendedProperties[\"format\"] = \"g\";\r\n";


								}

								//aggiungo il describecolunm c# all'oggetto di collegamento
								describeColumns += "\t\t\t\t\t\tbreak;\r\n\t\t\t\t\t}\r\n\t\t\t\t\t//$DescribeAColumn$";
								var describeColumnsCase = "				case \"" + editListingTypeParent + "\": {\r\n";
								ReplaceStringInFile(solutionFolder + metadataFolder + metadatoParent + "/meta_" + metadatoParent + "/meta_" + metadatoParent + ".cs",
									"\t\t\t\t\t//$DescribeAColumn$", describeColumnsCase + describeColumns);

							} else {
								//getmissing non serve perché metadatoChildOriginal arriva da metadatoChild che arriva da GetTablebyId che già lo fa
								var textFields = GetTextFieldByTable(metadatoChildOriginal,allfields, connection, false);
								//se i textfield restituiti sono diversi dalla chiave
								var stringtxtfields = string.Join(" ", textFields.Select(af => af.Name).ToList());
								var stringKeys = string.Join(" ",GetIdByTable(metadatoChildOriginal, allfields, connection));
								if (stringtxtfields != stringKeys || stringtxtfields == "aa") {
									if (metadatoChildOriginal != textFields.First().Table) {
										//mi è stato restituito il campo testuale dell'oggetto da cui deriva quindi devo cercare lì
										//metadatoChild = textField.Table; N.B. non serve in quanto nell'HTML c'è una autochoose, quindi usa l'edittype e di conseguenza una vista che abbraccia tutti i campi di esteso e estendente
									}

									foreach (var textField in textFields) {
										ReplaceStringInFile(pathMetaPage, "<!--LookupFields " + metadatoParent + "-->",
											"<xs:element name=\"" + "_x0021_" + parentKey.Replace(" ", "-") + "_" + metadatoChildOriginal + "_" + textField.Name + "\" " + " msdata:ReadOnly=\"false\" msdata:AllowDBNull=\"true\" " +
											"type=\"xs:" + GetDatasetType(textField.Type) + "\" minOccurs=\"0\" />\r\n" + "<!--LookupFields " + metadatoParent + "-->");

										objCalcFiledConfig += "						objCalcFiledConfig['!" + parentKey.Replace(" ", "-") + "_" + metadatoChildOriginal + "_" + textField.Name + "'] = {tableNameLookup:'" + metadatoChild +
										"', columnNameLookup:'" + textField.Name + "', columnNamekey:'" + parentKey.Replace(" ", "-") + "' };\r\n";
									}
								}
							}

							// DESCRIBECOLUMNS JS
							//per far partire la funzione customizzata dei campi calcolati devo aggiungere l'oggetto padre javascript (e verifico se non si tratta di un oggetto estendente)
							var currentObject = metadatoParent.Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[0];
							var container = currentObject;
							if (IsExtendingObject(metadatoParent, ref allfields, connection)) {
								container = GetExtendedObject(metadatoParent, ref allfields, connection, false);
								currentObject = metadatoParent.Split('_')[1];
							}
							var fullPathMetaDatoJS = clientFolder + metapageFolder + container + "/meta_" + currentObject + ".js";
							if (!File.Exists(fullPathMetaDatoJS)) {
								if (!Directory.Exists(clientFolder + metapageFolder + container))
									Directory.CreateDirectory(clientFolder + metapageFolder + container);
								Copy("../../metapage_template/meta_tabella.js", fullPathMetaDatoJS, true);
								//-sostituzioni di nome
								ReplaceStringInFile(fullPathMetaDatoJS, "tabella", currentObject);
								//-va aggiunto in index.html
								ReplaceStringInFile(clientFolder + "index.html", "<!-- meta dati -->\r\n", "<!-- meta dati -->\r\n	<script src=\"" + metapageFolder + container + "/meta_" + currentObject + ".js\"></script>\r\n");
							}


							//aggiungo il describecolumns js:
							//prima la singola colonna se già esiste l'edit type nella switch
							if (File.ReadAllText(fullPathMetaDatoJS, Encoding.Default).Contains("//$objCalcFiledConfig_" + editListingTypeParent + "$")) {
								ReplaceStringInFile(fullPathMetaDatoJS, "//$objCalcFiledConfig_" + editListingTypeParent + "$", objCalcFiledConfig + "//$objCalcFiledConfig_" + editListingTypeParent + "$");
							} else {
								//poi il case
								objCalcFiledConfig = "					case '" + editListingTypeParent + "':\r\n" + objCalcFiledConfig
									+ "//$objCalcFiledConfig_" + editListingTypeParent + "$\r\n" + "						break;\r\n";

								ReplaceStringInFile(fullPathMetaDatoJS, "//$objCalcFiledConfig$", objCalcFiledConfig + "//$objCalcFiledConfig$");
								//poi tutto il metodo
								ReplaceStringInFile(fullPathMetaDatoJS, "//$describeColumns$", @"describeColumns: function (table, listType) {
				var objCalcFiledConfig = {};
				switch (listType) {
" + objCalcFiledConfig +
				@"//$objCalcFiledConfig$
				}
				table['customObjCalculateFields'] = objCalcFiledConfig;
				appMeta.metaModel.computeRowsAs(table, listType, appMeta.customUtils.calculateFields);
				return this.superClass.describeColumns(table, listType);
			},");
							}
						}

						//-----------------aggiungo al dataset l'entità figlia (minimal = false) oppure la tabella per i campi di lookup (minimal = true)--------------------------------------------------------------

						var stringfile = File.ReadAllText(pathMetaPage, Encoding.Default);
						var fileContainsMinimal = stringfile.Contains("<xs:element name=\"" + metadatoChild + "\"><!--m-->");
						var fileContainsNormal = stringfile.Contains("<xs:element name=\"" + metadatoChild + "\"><!--n-->") || stringfile.Contains("<xs:element name=\"" + metadatoChild + "\">\r\n");

						//se non c'è l'aggiungo
						if (!fileContainsMinimal && !fileContainsNormal) {
							ReplaceStringInFile(pathMetaPage, "<xs:choice minOccurs=\"0\" maxOccurs=\"unbounded\">\r\n", "<xs:choice minOccurs=\"0\" maxOccurs=\"unbounded\">\r\n" + datasetMetadatoChild.Split(';')[0]);
							ReplaceStringInFile(pathMetaPage, "</xs:complexType>\r\n    <xs:unique", "</xs:complexType>\r\n    " + datasetMetadatoChild.Split(';')[1] + "    <xs:unique");
						} else {
							//se c'è lo sostituisco solo nei seguenti casi:
							if (
								(fileContainsMinimal && !minimal) // se già c'è minimale e lo sto aggiungendo normale la sostituisco
								) {

								if (verbose)
									Console.WriteLine("INFO: Per " + metadatoChild + " il dataset contiene già una versione minimale e la sto aggiungendo normale, oppure normale e la sto aggiungendo normale ed è visibile in maschera, quindi la sostituisco");

								//sostituisco la tabella se era minimale ... la chiave invece è sempre uguale
								if (fileContainsMinimal) {
									string tablePattern = "<xs:element name=\\\"" + metadatoChild + "\\\"><!--" + (fileContainsMinimal ? "m" : "n") + "-->(.*?)</xs:element>";
									var element = Regex.Matches(stringfile, tablePattern, RegexOptions.Singleline).Cast<Match>().Select(m => m.Value).ToList().First();
									ReplaceStringInFile(pathMetaPage, element, "");
									ReplaceStringInFile(pathMetaPage, "<xs:choice minOccurs=\"0\" maxOccurs=\"unbounded\">\r\n", "<xs:choice minOccurs=\"0\" maxOccurs=\"unbounded\">\r\n" + datasetMetadatoChild.Split(';')[0]);
								}

								//paracadute nel caso non abbia messo al figlio tutte le chiavi del padre TODO:verificare se mi serve ancora
								//in ogni caso incremento la chiave con l'eventuale riferimento al padre
								var KeyPattern = "<xs:unique name=\\\"" + metadatoChild + "_Constraint\\\" msdata:PrimaryKey=\\\"true\\\">(.*?)</xs:unique>\r\n";
								var oldKeys = Regex.Matches(stringfile, KeyPattern, RegexOptions.Singleline).Cast<Match>().Select(m => m.Value).ToList().First();
								var newKeys = datasetMetadatoChild.Split(';')[1];
								if (oldKeys != newKeys) {
									//cancello la vecchia chiave
									ReplaceStringInFile(pathMetaPage, "    " + oldKeys, "");
									//aggiungo i vecchi pezzi alla nuova
									var oldSingleKeys = Regex.Matches(oldKeys, "<xs:field xpath=\\\"mstns:(.*?)\\\" />", RegexOptions.Singleline).Cast<Match>().Select(m => m.Value).ToList();
									foreach (var ok in oldSingleKeys)
										if (!newKeys.Contains(ok))
											newKeys.Replace("            </xs:sequence>\r\n          </xs:complexType>", ok + "            </xs:sequence>\r\n          </xs:complexType>");
									//aggiungo la nuova
									ReplaceStringInFile(pathMetaPage, "</xs:complexType>\r\n    <xs:unique", "</xs:complexType>\r\n    " + newKeys + "    <xs:unique");
								}

							} else {
								if (verbose)
									Console.WriteLine("INFO: Per " + metadatoChild + " il dataset contiene già una versione minimale e la sto aggiungendo mimimale, oppure normale e la sto aggiungendo normale quindi non la aggiungo");
							}
						}

						//aggiungo le tabelle per i lookup delle entità figlie (chiavi esterne), tranne la chiave esterna stessa che le collega alla tabella parent
						if (!skiplookup) {


							if (!minimal) {

								//--se trovo altre chiavi nei capi VISIBILI aggiungo le tabelle e le relazioni
								foreach (var fi in allfields.Where(f => f.Table == metadatoChildOriginal && f.EditListingType == editListingType && f.ListVisible && HaveKeyName(f) && !f.Name.StartsWith("parid") &&
									(!f.IsKey || islinkingobject) && !childkey.Split(' ').Contains(f.Name)).ToList()) {

									var tablechild = GetTableById(fi.Name, allfields, connection);

									if (!string.IsNullOrEmpty(tablechild) && !string.IsNullOrEmpty(fi.Name)) {

										var listtype = !string.IsNullOrEmpty(fi.Listtype) ? fi.Listtype : "default";
										var txtField = GetTextFieldByTable(tablechild, allfields, connection, false, (listtype != "default"? listtype : null)).FirstOrDefault();
										if (tablechild != txtField.Table) {
											SetMetadatoChild(fields, fi, txtField.Table);
											fields.Add(fi); //gli estesi ci vanno a tutti i livelli con l'alias
										} else
											SetMetadatoChild(fields, fi, tablechild);


										PreparePageDataset(pathMetaPage, metadatoChild, fi.MetadatoChild, fi.Name, GetIdByForeignKey(fi.Name, fi.Table), metadatoChild, true, fields, allfields,
											listtype, editListingType,
											null, connection,
											fi.IsLinkingObj, //gli dico se l'id fa da collegamento imponendo come se fi.table fosse una tabella di collegamento
											iteration + 1, "", skiplookup);
									}
								}

								if (!string.IsNullOrEmpty(pageid)) {
									//--se trovo sottopagine le devo aggiungere al dataset altrimenti poi non funzionano i salvataggi
									//----ricavo le relazioni
									var relationFields = GetChildentitiesFields(pageid, "", allfields, connection);
									//----ricavo i campi del dataset (precedenti e calcolati adesso) calcolando gli alias per i nuovi campi relazione
									foreach (var r in relationFields) {
										var  tc = r.Name.Substring(2);
										var mdck = string.Join(" ", GetIdByTable(metadatoChild, allfields, connection));

										//se è un oggetto estendente ...
										if (IsExtendingObject(r.Name.Substring(2), ref allfields, connection)) {
											//..salvo l'esteso nel campo fi.MetadatoChild con l'alias che mi serve
											SetMetadatoChild(fields, r, r.Name.Substring(2).Split('_')[0]);
											fields.Add(r);
										}

										PreparePageDataset(pathMetaPage, metadatoChild, tc, mdck,
											r.LookupFor ?? mdck, //foreign key anche con suffissi o prefissi ?? subentità
											metadatoChild, false, fields, allfields, r.EditListingType, editListingType, r.PageId, connection,
											false, //metadatoChild verrà comunque verificato se è di collegamento dal metodo stesso
											iteration + 1, r.MetadatoChild, skiplookup);
									}
								}
							}

							//se è un oggetto estendente devo mettere anche l'oggetto che lo estende (esteso)
							if (!string.IsNullOrEmpty(extendedTableChild)) {
								//ricavo l'edittype dell'estendente in base all'esteso
								var editListTypeExtended = metadatoChild.Split('_')[1];
								if (editListingType != "default")
									editListTypeExtended += "_" + editListingType;
								if (!allfields.Any(af => af.Table == extendedTableChild.Split('_')[0] && af.EditListingType == editListTypeExtended))
									editListTypeExtended = "default";

								var fi = GetIdFieldsByTable(extendedTableChild, allfields, connection).FirstOrDefault();
								//l'iteration non la incremento perchè è allo stesso livello dell'estendete
								PreparePageDataset(pathMetaPage, metadatoChild, extendedTableChild, fi.Name, fi.Name, metadatoChild, false, fields, allfields, editListTypeExtended, editListingType, null, connection, false, iteration, "", iteration > 1);

								if (childkey.StartsWith("parid")) {
									//se la relazione è ricorsiva allora non va fatta sul metadatochild corrente (estendente) ma sull'oggetto esteso ...
									metadatoChild = extendedTableChild;
									//...mettendo chiave il parid
									var KeyPattern = "<xs:unique name=\\\"" + metadatoChild + "_Constraint\\\" msdata:PrimaryKey=\\\"true\\\">(.*?)</xs:unique>\r\n";
									var oldKeys = Regex.Matches(File.ReadAllText(pathMetaPage, Encoding.Default), KeyPattern, RegexOptions.Singleline).Cast<Match>().Select(m => m.Value).ToList().First();
									var newkeys = oldKeys.Replace("    </xs:unique>", "      <xs:field xpath=\"mstns:" + childkey + "\" />\r\n" +"    </xs:unique>");
									ReplaceStringInFile(pathMetaPage, oldKeys, newkeys);
								}
							}
						}
					}
				}

				//inserisco la relazione solo per le tabelle trovate sul db (o se sono quella corrente)
				if ((!string.IsNullOrEmpty(datasetMetadatoParent) || metadatoParent == current) && (!string.IsNullOrEmpty(datasetMetadatoChild) || metadatoChild == current)) {

					var datasetRelation = "";

					var isAnInvertedExtensionRelation = metadatoParent.Contains(metadatoChildOriginal + "_");

					//se ho cotruito il figlio per intero e il padre non è un oggetto di collegamento: 
					//la chiave esterna è del figlio e interna del padre (il child è una subentità), altrimenti li scambio (il child è un vocabolario)
					if (!minimal && !parentIsLinkingObject && !isAnInvertedExtensionRelation) {
						datasetRelation = "     <msdata:Relationship name=\"FK_" + metadatoChild + "_" + metadatoParent + "_" + childkey.Replace(" ", "-") + "\" msdata:parent=\"" +
							metadatoParent + "\" msdata:child=\"" + metadatoChild + "\" msdata:parentkey=\"" + parentKey + "\" msdata:childkey=\"" + childkey + "\" />\r\n";
					} else {
						datasetRelation = "     <msdata:Relationship name=\"FK_" + metadatoParent + "_" + metadatoChild + "_" + parentKey.Replace(" ", "-") + "\" msdata:parent=\"" +
							metadatoChild + "\" msdata:child=\"" + metadatoParent + "\" msdata:parentkey=\"" + childkey + "\" msdata:childkey=\"" + parentKey + "\" />\r\n";
					}

					if (File.ReadAllText(pathMetaPage, Encoding.Default).Contains("   <xs:appinfo>")) {
						ReplaceStringInFile(pathMetaPage, "<xs:appinfo>\r\n", "<xs:appinfo>\r\n" + datasetRelation);
					} else {
						ReplaceStringInFile(pathMetaPage, "</xs:schema>", "  <xs:annotation>\r\n    <xs:appinfo>\r\n" + datasetRelation + "    </xs:appinfo>\r\n  </xs:annotation>\r\n</xs:schema>");
					}
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
		private static string GetDatasetTable(string tablename, bool minimal, List<field> allfields, SqlConnection connection, string parentkey = null) {

			//verifico che non si tratti di un alias
			var tableAlias = tablename;
			if (tablename.Contains("_alias"))
				tablename = tableAlias.Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[0];

			//verifico che i campi siano già stati caricati dal db altrimento lo faccio ora
			GetMissingFields(tablename, null, ref allfields, connection);

			//estrapolo i dati dei campi della tabella senza le informazioni delle interfacce
			var tableFields = GetDatasetFields(tablename,allfields);

			var fields = new List<field>();
			//nella versione minimale ci devono essere:
			if (minimal) {
				//1-le chiavi
				var keyfield = tableFields.Where(af => af.IsKey);
				fields.AddRange(keyfield);
				//2-i campi testuali
				foreach (var txt in GetTextFieldByTable(tablename, allfields, connection, false)) //il get missing l'ho fatto poco prima
				{
					if (tablename != txt.Table) {
						//TODO aggiungo il filtro statico keyfield.name in (select keyfield.Name from tablename) dove tablename è ancora l'oggetto estendente
						//mi è stato restituito il campo testuale dell'oggetto da cui deriva quindi devo cercare lì
						tablename = txt.Table;
					}

					if (!fields.Any(af => af.Name == txt.Name))
						fields.AddRange(tableFields.Where(af => af.Name == txt.Name));
				}
				////3-riferiment ricorsivi
				//var parid = tableFields.Where(af => af.Name.StartsWith("parid")).FirstOrDefault();
				//if (parid != null)
				//	fields.Add(parid);
			} else {
				//se è una tabella completa ci vanno anche i suoi campi di lookup
				fields.AddRange(tableFields);
				//il contatore degli allegati non va mai aggiunto
				fields.RemoveAll(f => f.Table == "attach" && f.Name == "counter");
			}

			var datasetmedatdatoKeys = "<xs:unique name=\"" + tableAlias + "_Constraint\" msdata:PrimaryKey=\"true\">\r\n	  <xs:selector xpath=\".//mstns:" + tableAlias + "\" />\r\n";

			//Se sto costruento un elenco di oggetti che si riferiscono a quello corrente senza essere direttamente subentità (ad es le lezioni che si svolgono nell'aula)
			//oppure oggetti subentità ma relativi ad un'entità estesa (ad esempio sospensione relativa a location)
			//devo (per il dataset di questa interfaccia) forzare a chiave la chiave del padre, tranne se si tratta di oggetti esteso e estendente che già lo è
			if (!string.IsNullOrEmpty(parentkey))
				foreach (var pk in parentkey.Split(' ')) {
					if (!fields.Any(f => f.IsKey && (f.Name.Split('_')[0] == pk || f.Name == pk))) {
						//controllo che non abbia un suffisso
						var fk = fields.FirstOrDefault(f => !f.IsKey && f.Name.Split('_')[0] == pk)?? new field{ Name = pk };
						datasetmedatdatoKeys += "      <xs:field xpath=\"mstns:" + fk.Name + "\" />\r\n";
					}
				}

			var datasetMetadato = "		        <xs:element name=\"" + tableAlias + "\"" + (tableAlias != tablename ? " msprop:TableForReading=\"" + tablename + "\"":"") +
				">"+(minimal?"<!--m-->":"<!--n-->")+"\r\n		          <xs:complexType>\r\n		            <xs:sequence>\r\n";
			foreach (var fi in fields.Where(f => !f.Name.StartsWith("XX"))) {

				if (fi.IsKey)
					datasetmedatdatoKeys += "      <xs:field xpath=\"mstns:" + fi.Name + "\" />\r\n";

				datasetMetadato += "		              <xs:element name=\"" + fi.Name + "\" type=\"xs:" + GetDatasetType(fi.Type) + "\" ";

				if (fi.Allownull) {
					datasetMetadato += "minOccurs=\"0\" msdata:AllowDBNull=\"true\" />\r\n";
				} else {
					datasetMetadato += " msdata:AllowDBNull=\"false\" />\r\n";
				}

			}
			//i campi calcolati su tabelle minimali non servono
			datasetMetadato += minimal ? "" : "		              <!--LookupFields " + tableAlias + "-->\r\n";

			datasetmedatdatoKeys += "    </xs:unique>\r\n";
			datasetMetadato += "		            </xs:sequence>\r\n		          </xs:complexType>\r\n		        </xs:element>\r\n;" + (datasetmedatdatoKeys.Contains("field") ? datasetmedatdatoKeys : "");

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
						Console.WriteLine("ERROR: Tipo sql non mappato nel dataset !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!" + type);
						break;
					}
			}
			return output;

		}

		#endregion

		#region gestione degli oggetti/tabelle/viste/id

		/// <summary>
		/// determina se una tabella è di collegamento
		/// deve essere composta esclusivamente dai campi di log e più di una chiave
		/// </summary>
		/// <param name="table"></param>
		/// <param name="allfields"></param>
		/// <param name="connection"></param>
		/// <returns></returns>
		private static bool IsLinkingObject(string table, ref List<field> allfields, SqlConnection connection) {

			if (table.Contains("_alias"))
				table = table.Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[0];

			if (table == "annoaccademico")
				return false;

			GetMissingFields(table, null, ref allfields, connection);
			var ft = GetDatasetFields(table,allfields).Where(af => af.Table == table && af.Name != "ct" && af.Name != "cu" && af.Name != "lt" && af.Name != "lu").ToList();
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
			var linkingid = allfields.Where(af => af.Table == linkingtable && af.EditListingType == linkingeditlisttype && (af.IsKey || af.IsLinkingObj) && af.ListVisible).OrderByDescending(af=>af.IsLinkingObj).FirstOrDefault();

			//ricavo il nome della tabella collegata
			var linkedtable = GetTableById(linkingid.Name,allfields,connection);
			GetMissingFields(linkedtable, null, ref allfields, connection);

			//controllo che non indichi un list type specifico, altrimenti uso quello del padre o quello di default
			var linkededitlisttype = linkingeditlisttype;
			if (!string.IsNullOrEmpty(linkingid.Listtype))
				linkededitlisttype = linkingid.Listtype;
			if (!allfields.Any(af => af.Table == linkedtable && af.EditListingType == linkededitlisttype))
				linkededitlisttype = "default";

			linkingobjectfields = allfields.Where(af => af.Table == linkedtable && af.EditListingType == linkededitlisttype).ToList();

			return linkingobjectfields;
		}


		/// <summary>
		/// Verifica se un oggetto è una tabella estendente oppure no
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
			if (table.IndexOf("_") != -1) {
				var extendedObject = table.Substring(0, table.IndexOf("_"));
				GetMissingFields(extendedObject, null, ref allfields, connection);
				//verifico che non si tratti in realtà di una tabella di collegamento con un oggetto esteso:
				//se adesso che ho appena cercato di aggiungere i campi dell'oggetto esteso non li ho trovati sul db allora vuol dire che la tabella non esiste, 
				//perchè è in realtà una tabella di collegamneto (in cui la tabella estendente è sempre nella parte destra del nome)
				if (allfields.Any(af => af.Table == extendedObject)) {
					output = true;
				} else {
					extendedObject = "";
					if (verbose)
						Console.WriteLine("INFO: la tabella " + table + " contiene _ ma è solo una tabella di collegamento ad una estendente");
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
		/// <param name="getmissing">verifica di aver caricato i campi dal db (default è true)</param>
		/// <param name=""></param>
		/// <returns></returns>
		private static string GetExtendedObject(string table, ref List<field> allfields, SqlConnection connection, bool getmissing = true) {
			string extendedObject = null;
			//prima tolgo l'alias
			table = table.Split(new string[] { "_alias" }, StringSplitOptions.RemoveEmptyEntries)[0];
			//poi controllo che sia rimasto un _
			if (table.IndexOf("_") != -1) {
				extendedObject = table.Substring(0, table.IndexOf("_"));
				if (getmissing)
					GetMissingFields(extendedObject, null, ref allfields, connection);
				//verifico che non si tratti in realtà di una tabella di collegamento con un oggetto esteso:
				//se adesso che ho appena cercato di aggiungere i campi dell'oggetto esteso non li ho trovati sul db allora vuol dire che la tabella non esiste, 
				//perchè è in realtà una tabella di collegamneto (in cui la tabella estendente è sempre nella parte destra del nome)
				if (allfields.Any(af => af.Table == extendedObject)) {
				} else {
					extendedObject = null;
					if (verbose)
						Console.WriteLine("INFO: la tabella " + table + " contiene _ ma è solo una tabella di collegamento ad una estendente");
				}
			}
			return extendedObject;
		}

		/// <summary>
		/// Elenco delle eccezioni, si può passare la tabella, la chiave oppure la coppia tabella con foreign key e foreign key
		/// restituisce una tupla con le informazioni sulla tabella o sulle relazionioni
		/// </summary>
		/// <param name="table">tabella</param>
		/// <param name="key">chiave</param>
		/// <param name="linkedTable">tabella con foreign key</param>
		/// <param name="linkedcolumn">foreign key</param>
		/// <returns>tabella, chiave, tabella con foreign key,foreign key, è una vera chiave?</returns>
		private static Tuple<string, string, string, string, bool, bool> GetException(string table, string key, string linkedTable, string linkedcolumn) {
			var exceptions = new List<Tuple<string,string,string, string, bool, bool>>();
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
			//falsi id
			exceptions.Add(Tuple.Create("", "idexternal", "", "", false, false));
			exceptions.Add(Tuple.Create("", "idsedemiur", "", "", false, false));
			exceptions.Add(Tuple.Create("", "idistitutoustat", "", "", false, false));
			//GetTableById
			exceptions.Add(Tuple.Create("residence", "residence", "", "", true, false));
			exceptions.Add(Tuple.Create("menuweb", "idmenuwebparent", "", "", true, false));
			exceptions.Add(Tuple.Create("annoaccademico", "aa", "", "", true, false));
			exceptions.Add(Tuple.Create("registry_istituti", "idreg_istituti", "", "", true, true));
			exceptions.Add(Tuple.Create("registry_istitutiesteri", "idreg_istitutiesteri", "", "", true, true));
			exceptions.Add(Tuple.Create("registry_aziende", "idreg_aziende", "", "", true, true));
			exceptions.Add(Tuple.Create("registry_studenti", "idreg_studenti", "", "", true, true));
			exceptions.Add(Tuple.Create("registry_docenti", "idreg_docenti", "", "", true, true));
			exceptions.Add(Tuple.Create("registry", "idreg", "", "", true, true));
			exceptions.Add(Tuple.Create("geo_city", "idcity", "", "", true, true));
			exceptions.Add(Tuple.Create("geo_country", "idcountry", "", "", true, true));
			exceptions.Add(Tuple.Create("geo_region", "idregion", "", "", true, true));
			exceptions.Add(Tuple.Create("geo_nation", "idnation", "", "", true, true));
			exceptions.Add(Tuple.Create("geo_city", "newcity", "", "", true, false));
			exceptions.Add(Tuple.Create("geo_city", "oldcity", "", "", true, false));
			exceptions.Add(Tuple.Create("geo_country", "newcountry", "", "", true, false));
			exceptions.Add(Tuple.Create("geo_country", "oldcountry", "", "", true, false));
			exceptions.Add(Tuple.Create("geo_region", "newregion", "", "", true, false));
			exceptions.Add(Tuple.Create("geo_region", "oldregion", "", "", true, false));
			exceptions.Add(Tuple.Create("geo_nation", "newnation", "", "", true, false));
			exceptions.Add(Tuple.Create("geo_nation", "oldnation", "", "", true, false));
			exceptions.Add(Tuple.Create("address", "idaddresskind", "", "", true, false));


			return exceptions.Where(ex =>
			ex.Item1 == table ||
			ex.Item2 == key || //getTablebyId
			(ex.Item3 == linkedTable && ex.Item4 == linkedcolumn) //ForeignKeyExceptions
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
			var ex = GetException(null,id,null,null);
			if (ex != null) {
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

				//1- se io debba riferirmi ad una chiave di un oggetto estendente (quando è il collegamento con l'oggetto padre non serve)
				//devo averla inserita come se avesse la propria chiave (id+estendente) e non quella dell'esteso (id+esteso)
				if (allfields.Any(af => af.Table == output))
					return output;

				//2- se io debba riferirmi più volte alla stessa chiave nella stessa tabella, io possa accodare _xxx alla chiave
				id = id.Substring(0, id.IndexOf('_'));
				Console.WriteLine("INFO: Riprovo ripartendo dall'indice " + id + ".");
			}

			//verifico che i campi siano già stati caricati dal db altrimento lo faccio ora 
			//(se avessi avuto solo quella di collegamento adesso avrei anche la tabella collegata)
			GetMissingFields(null, id, ref allfields, connection);

			//prendo tutte le tabelle con quella chiave
			var allOutput = allfields.Where(af => af.IsKey && af.Name == id).Select(af => af.Table);

			if (allOutput.Any()) {
				var output = "";
				var outputs = new List<string>();

				//prendo tutte quelle con la chiave più corta (esclude automaticamente le tabelle di collegamento)
				var minkeys = 20;
				foreach (var o in allOutput) {
					var keysnum = GetDatasetFields(o,allfields).Where(f=>f.IsKey).Count();
					if (keysnum == minkeys)
						outputs.Add(o);
					if (keysnum < minkeys) {
						minkeys = keysnum;
						outputs.Clear();
						outputs.Add(o);
					}
				}

				//var outputs = allOutput.Where(o=> !IsLinkingObject(o, ref allfields, connection)).OrderBy(o=>o.Length);

				//se ho passato una tabella di collegamento ...
				if (linkingObject != null) {
					//... scelgo la tabella il cui nome è in quella di collegamento ed è più lungo (estendente)
					output = outputs.Where(o => linkingObject.Contains(o)).OrderBy(o => o.Length).LastOrDefault();
				} else
					//...altrimenti scelgo la tabella col nome più corto (esteso)
					output = outputs.OrderBy(o => o.Length).FirstOrDefault();

				if (!string.IsNullOrEmpty(output))
					return output;
				else {
					//if (verbose)
					Console.WriteLine("ERROR: Tabella non trovata per la chiave " + id);
					return "";
				}

			} else {
				//if (verbose)
				Console.WriteLine("ERROR: Tabella non trovata per la chiave " + id);
				return "";
			}
		}

		/// <summary>
		/// Restituisce i nomi degli indici della tabella passata come parametro
		/// </summary>
		/// <param name="table">tabella</param>
		/// <param name="allfields">campi del db</param>
		/// <returns>gli indici</returns>
		private static List<string> GetIdByTable(string table, List<field> allfields, SqlConnection connection, bool checkmissing = true) {

			//verifico che i campi siano già stati caricati dal db altrimento lo faccio ora
			if (checkmissing)
				GetMissingFields(table, null, ref allfields, connection);

			var tablefields = GetDatasetFields(table,allfields);

			var output = tablefields.Where(af => af.IsKey).OrderBy(x=>x.Name).Select(af => af.Name).ToList();
			if (output.Any())
				return output;
			else {
				Console.WriteLine("ERROR: Chiave non trovata per la tabella " + table);
				return new List<string>();
			}

		}

		private static string GetSchemaByTable(string table, List<field> allfields, SqlConnection connection, bool checkmissing = true) {

			//verifico che i campi siano già stati caricati dal db altrimento lo faccio ora
			if (checkmissing)
				GetMissingFields(table, null, ref allfields, connection);


			var output = allfields.Where(af => af.Table == table && af.IsKey).OrderBy(x=>x.Name).Select(af => af.Schema).FirstOrDefault();
			if (output != null) {
				if (output != "dbo")
					return output;
				else
					return "";
			} else {
				Console.WriteLine("ERROR: Schema non trovato per la tabella " + table);
				return "";
			}

		}

		/// <summary>
		/// Restituisce gli indici della tabella passata come parametro
		/// </summary>
		/// <param name="table">tabella</param>
		/// <param name="allfields">campi del db</param>
		/// <returns>gli indici</returns>
		private static List<field> GetIdFieldsByTable(string table, List<field> allfields, SqlConnection connection, bool checkmissing = true) {

			//verifico che i campi siano già stati caricati dal db altrimento lo faccio ora
			if (checkmissing)
				GetMissingFields(table, null, ref allfields, connection);

			var tablefields = GetDatasetFields(table,allfields);

			var output = tablefields.Where(af => af.IsKey).OrderBy(x=>x.Name.Length).ToList();
			if (output.Any())
				return output;
			else {
				//if (verbose)
				Console.WriteLine("ERROR: Chiave non trovata per la tabella " + table);
				return new List<field>();
			}

		}

		/// <summary>
		/// Resituisce il campo testuale da mostrare nelle combo o nelle autochoose
		/// </summary>
		/// <param name="table">tabella</param>
		/// <param name="allfields">campi del db, se gli passo un subset non devo MAI mettere getmissing = false</param>
		/// <param name="getmissing">verifica che i dati siano stati caricati dal db</param>
		/// <returns></returns>
		private static List<field> GetTextFieldByTable(string table, List<field> allfields, SqlConnection connection, bool getmissing = true, string listtype = null) {

			listtype = "default";

			//il naming standard prevede che se c'è un _ allora table è un oggetto derivato, quindi il text field è sul padre
			var originaltable = table;
			if (table.IndexOf('_') != -1) {
				var isExtendingObject = true;
				var ex = GetException(table,null,null,null);
				if (ex != null)
					isExtendingObject = ex.Item6;
				if (isExtendingObject)
					listtype = table.Split('_')[1];
				table = table.Substring(0, table.IndexOf('_'));
			}

			if (getmissing)
				//verifico che i campi siano già stati caricati dal db altrimento lo faccio ora
				GetMissingFields(table, null, ref allfields, connection);

			//se non ho trovato la tabella riprovo con quella originale
			if (!allfields.Any(af => af.Table == table)) {
				table = originaltable;
				if (getmissing) {
					Console.WriteLine("INFO: Riprovo con " + table + ".");
					GetMissingFields(table, null, ref allfields, connection);
				}
			}

			var tablefields = allfields.Where(af => af.Table == table && af.EditListingType == listtype);
			if (!tablefields.Any() && listtype != "default")
				tablefields = allfields.Where(af => af.Table == table && af.EditListingType == "default");
			if (!tablefields.Any())
				tablefields = GetDatasetFields(table, allfields);

			//di base è l'id
			var txtField = GetIdFieldsByTable(table, allfields, connection, false);// tablefields.Where(af => af.IsKey).OrderBy(x=>x.Name.Length).ToList();
																				   //poi provo con il campo preposto
			var fiText = tablefields.Where(af => af.Textfield >0).OrderBy(af => af.Textfield).ToList();
			if (fiText.Any()) {
				txtField = fiText;
			} else {
				//poi provo con title
				var fiTitle = tablefields.Where(af => af.Name.ToLower() == "title").ToList();
				if (fiTitle.Any()) {
					txtField = fiTitle;
				} else {
					//poi provo con description
					var fiDescription = tablefields.Where(af => af.Name.ToLower() == "description").ToList();
					if (fiDescription.Any()) {
						txtField = fiDescription;
					} else {
						//poi con il primo campo testuale 
						var fiTxt = tablefields.Where(af => (new List<string>(){"char","nchar","nvarchar","varchar","text"}).Contains(af.Type) && af.Len > 1 &&
						af.Name != "ct" && af.Name != "cu" && af.Name != "lt" && af.Name != "lu").ToList();
						if (fiTxt.Any()) {
							txtField = fiTxt;
						} else {
							if (verbose)
								Console.WriteLine("WARNING: per la tabella " + table + " non è stato trovato un campo testuale da mostrare nelle dropdown o autochoose");
						}

					}
				}
			}

			return txtField;
		}

		/// <summary>
		/// Crea la view per il metadato esteso + il metadato estendente oppure 
		/// la view per il list type Default per gli oggetti che hanno un campo che referenzia un'altra tabella ed è indicato come visibile nell'elenco
		/// </summary>
		/// <param name="table">tabella o oggetto esteso</param>
		/// <param name="editType">edit type o oggetto estendente</param>
		/// <param name="allfields">campi sul db</param>
		/// <param name="connection">connessione già aperta che non viene chiusa</param>
		private static List<field> CreateView(string table, string extendingObjectTable, string editType, List<field> fields, List<field> allfields, bool toWrite, bool isLinkingObj,
			SqlConnection connection) {

			var viewFields = new List<field>();

			var schema = GetSchemaByTable(table, allfields, connection, false);
			if (!string.IsNullOrEmpty(schema)) schema = schema + ".";
			//if (table == "location") schema = "amm.";


			var createView = "CREATE VIEW [dbo].[" + table + editType + "view] AS SELECT ";
			var joinView = "";
			var whereView = "";

			//caso di oggetto esteso
			if (!string.IsNullOrEmpty(extendingObjectTable)) {
				var key = GetIdByTable(table,allfields, connection);
				joinView += " INNER JOIN " + extendingObjectTable + " ON " + table + "." + (key.FirstOrDefault() ?? "") + " = " + extendingObjectTable + "." + (key.FirstOrDefault() ?? "");
			}

			//qui sicuramente: 
			//-il get missing non serve perchè sono i campi principali 
			//-non devo controllare se il text field è di un estendente perchè non glieli passo mai
			var textfield = GetTextFieldByTable(table, allfields, connection, false, editType != "default"? editType : null).FirstOrDefault();
			if (table != textfield.Table) {
				Console.WriteLine("ERROR: sto cotruendo una vista inconsistente");
			}

			var loop = 1;
			//prendo i campi della tabella corrente o di quella estendente
			foreach (var f in fields.OrderBy(af => af.Table).ThenBy(af => af.Name)) {

				//tolgo l'alias all'id e al text field dell'oggetto corrente
				var hadAlias = !(f.Table == table && (f.IsKey || f.Name == textfield.Name));
				if (hadAlias)
					f.ViewAlias = f.Table + "_" + f.Name;

				// se è una chiave esterna ed è visibile in lista o in dettaglio...
				if (HaveKeyName(f) && (f.ListVisible || f.Detailvisible) &&
					//...e se non sono incappato in una dele sue chiavi stesse ... (a meno che non sia un oggetto di collegamento)
					(!GetIdByTable(table, allfields, connection).Contains(f.Name) || isLinkingObj)) {

					//...aggiungo il join 

					var tableChild = "";
					var ex = GetException(null,null,f.Table,f.Name); //foreignkey non standard
					if (ex != null)
						tableChild = ex.Item1;
					else
						tableChild = GetTableById(f.Name, allfields, connection);

					if (!string.IsNullOrEmpty(tableChild)) {
						var specification = "";
						if (f.Name.Contains('_'))
							specification = f.Name.Substring(f.Name.IndexOf("_"), f.Name.Length - f.Name.IndexOf("_"));

						if (f.Name.StartsWith("parid") || f.Name == "idmenuwebparent")
							specification = "parent";

						if (string.IsNullOrEmpty(specification) && tableChild == table) {
							specification = "_" + loop.ToString();
							loop++;
						}

						var schemaJoin = GetSchemaByTable(tableChild, allfields, connection, false);
						if (!string.IsNullOrEmpty(schemaJoin)) schemaJoin = schemaJoin + ".";

						//if (tableChild == "location" || tableChild == "upb")
						//	schemaJoin = "amm.";

						var hasAlias = !string.IsNullOrEmpty(specification);
						var idTableChild = GetIdByTable(tableChild, allfields, connection).First();
						joinView += " LEFT OUTER JOIN " + schemaJoin + tableChild + (hasAlias ? " AS " + tableChild + specification : "") +
									" ON " + f.Table + "." + f.Name + " = " + (hasAlias ? "" : schemaJoin) + tableChild + specification + "." + idTableChild;

						//aggiungerò la chiave esterna senza alias per poter usare il campo in ricerca in presenza di autochoose, perchè non posso indicare il campo su cui cercare col searchtag
						hadAlias = tableChild.Contains("kind") || tableChild.Contains("status");
						if (!hadAlias)
							f.ViewAlias = null;

						//se è una tabella di collegamento
						if (isLinkingObj || f.IsLinkingObj) {
							//aggiungo TUTTI i campi della tabella collegata visibili in griglia ...
							////...prima provo a vedere se è stata fatta una versione per il list type corrente (se nel campo id non è stato indicato un edit-listing tipe specifico )
							//var joinfields = allfields.Where(af => af.Table == tableChild && af.EditListingType == (string.IsNullOrEmpty(f.Listtype)? f.EditListingType : f.Listtype) && af.ListVisible);
							//if (!joinfields.Any())
							//	//...altrimenti prendo quella di default
							//	joinfields = allfields.Where(af => af.Table == tableChild && af.EditListingType == "default" && af.ListVisible);
							var joinfields = GetLinkingObjectFields(table, editType, ref allfields, connection);
							foreach (var txtField in joinfields) {
								var alias = tableChild + specification + "_" + txtField.Name;
								createView += " " + (hasAlias ? "" : schemaJoin) + tableChild + specification + "." + txtField.Name + " AS " + alias + ",";
								//lo devo rinnovare con tabella e visibilità uguali a quello dell'ID che lo ha generato
								viewFields.Add(RenewField(txtField, txtField.SortList, txtField.Detailvisible, txtField.ListVisible, f.Name, alias, f.Table, txtField.Title));
							}
						} else {
							//...aggiungo ai campi tabella.campotestuale AS tabella_campotestuale
							var txtFields = GetTextFieldByTable(tableChild, allfields, connection);
							if (tableChild == txtFields.First().Table) {

								foreach (var txtField in txtFields) {
									var alias = tableChild + specification + "_" + txtField.Name;
									createView += " " + (hasAlias ? "" : schemaJoin) + tableChild + specification + "." + txtField.Name + " AS " + alias + ",";

									//lo devo rinnovare con sortList, tabella e visibilità uguali a quello dell'ID che lo ha generato
									viewFields.Add(RenewField(txtField, f.SortList, f.Detailvisible, f.ListVisible, f.Name, alias, f.Table, f.Title));
								}
							} else {
								//mi è stato restituito il text field del padre, quindi devo aggiungerlo nel join (ci metto sempre l'alias non si sa mai)
								var schemaJoin2 = GetSchemaByTable(txtFields.First().Table, allfields, connection, false);
								if (!string.IsNullOrEmpty(schemaJoin2)) schemaJoin2 = schemaJoin2 + ".";
								//if (txtFields.First().Table == "location" || txtFields.First().Table == "upb")
								//	schemaJoin2 = "amm.";
								var tableAlias = txtFields.First().Table + "_" +tableChild;
								joinView += " LEFT OUTER JOIN " + schemaJoin2 + txtFields.First().Table + " AS " + tableAlias +
											" ON " + (hasAlias ? "" : schemaJoin) + tableChild + specification + "." + idTableChild + " = " + tableAlias + "." + idTableChild;
								foreach (var txtField in txtFields) {

									var alias = txtField.Table + specification + "_" + txtField.Name;
									createView += " " + tableAlias + "." + txtField.Name + " AS " + alias + ",";

									//lo devo rinnovare con sortList, tabella e visibilità uguali a quello dell'ID che lo ha generato
									viewFields.Add(RenewField(txtField, f.SortList, f.Detailvisible, f.ListVisible, f.Name, alias, f.Table, f.Title));
								}
							}
						}


						//aggiungo il campo id ai fields della vista
						//if (isLinkingObj && f.Table == extendingObjectTable)
						//f.LookupFor = fields.First(fs => fs.Table == table && fs.ListVisible).Name;
						viewFields.Add(RenewField(f, f.SortList, f.Detailvisible, false/*, f.LookupFor*/));
					} else {
						//aggiungo il campo id ai fields della vista perchè non porta a nulla 
						//if (isLinkingObj && f.Table == extendingObjectTable)
						//f.LookupFor = fields.First(fs => fs.Table == table && fs.ListVisible).Name;
						viewFields.Add(f);
					}
				} else {
					//aggiungo il campo qualunque ai fields della vista
					//if (isLinkingObj && f.Table == extendingObjectTable)
					//f.LookupFor = fields.First(fs => fs.Table == table && fs.ListVisible).Name;
					viewFields.Add(f);
				}

				//aggiungo il campo alla vista ...

				if (f.Type == "char" && f.Len == 1) {
					var radiovalues = string.IsNullOrEmpty(f.Radiovalues) ? "S;Si;N;No" : f.Radiovalues;
					var v = radiovalues.Split(';').ToList();
					createView += "CASE ";
					foreach (var r in v) {
						if (v.IndexOf(r) % 2 == 0) {
							createView += "WHEN " + f.Table + "." + f.Name + " = '" + r + "' ";
						} else {
							createView += "THEN '" + r + "' ";
						}
					}
					createView += "END AS " + f.Table + "_" + f.Name + ",";
				} else
					//...togliendo gli alias all'id e al text field dell'oggetto corrente
					createView += " " + f.Table + "." + f.Name + (hadAlias ? " AS " + f.Table + "_" + f.Name : "") + ",";

				//aggiungo il filtro statico per questa vista indicato nel campo
				if (!string.IsNullOrEmpty(f.Filter))
					whereView += " " + f.Table + "." + f.Name + f.Filter;
			}

			//tolgo l'ultima virgola
			createView = createView.Substring(0, createView.Length - 1);

			createView += " FROM " + schema + table;
			createView += joinView;
			if (!string.IsNullOrEmpty(whereView))
				createView += " WHERE " + whereView;

			if (!skipView && toWrite) {
				var cmd = new SqlCommand(createView, connection);
				var skip= false;
				try {
					cmd.ExecuteNonQuery();
				} catch (Exception e) {
					if (verbose)
						Console.WriteLine("INFO: La vista esisteva già " + e.Message);
					var alterView = createView.Replace("CREATE VIEW","ALTER VIEW");
					cmd = new SqlCommand(alterView, connection);
					try {
						cmd.ExecuteNonQuery();
					} catch (Exception ea) {
						//if (verbose)
						Console.WriteLine("ERROR: Fallito l'aggiornamento della vista " + ea.Message);
						skip = true;
					}
				}

				if (!skip) {
					//-AGGIUNGO LA ENTRY IN web_listredir
					var insert = "INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])"+
								"VALUES('" + table + "', '" + editType + "', '" + table + editType + "view', '" + editType + "', NULL, NULL, NULL, NULL)";
					cmd = new SqlCommand(insert, connection);
					try { cmd.ExecuteNonQuery(); } catch (Exception e) {
						if (verbose)
							Console.WriteLine("WARNING: " + e.Message);
					}
				}
			}
			return viewFields;
		}

		/// <summary>
		/// Restituisce la chiave da una sua chiave esterna con prefissi e suffissi
		/// </summary>
		/// <param name="foreignkey">Chiave esterna</param>
		/// <param name="table">tabella contenente la chiave esterna</param>
		/// <returns></returns>
		private static string GetIdByForeignKey(string foreignkey, string table) {

			var ex = GetException(null,null,table,foreignkey);
			if (ex != null)
				return ex.Item2;
			else {
				var key = foreignkey.IndexOf("_") == -1 ? foreignkey : foreignkey.Substring(0, foreignkey.IndexOf("_"));
				if (key.StartsWith("parid"))
					key = key.Substring(3);
				return key;
			}
		}

		/// <summary>
		/// Indica che il name del campo è quello di una chiave
		/// </summary>
		/// <param name="fi">campo</param>
		/// <returns>true/false</returns>
		private static bool HaveKeyName(field fi) {
			var output = false;

			//casi non standard
			var ex = GetException(null,fi.Name,fi.Table,fi.Name);
			if (ex != null) {
				return ex.Item5;
			}

			if ((fi.Name.StartsWith("parid") || fi.Name.StartsWith("id") /*|| fi.Name == "aa"*/))
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

			var gridfields = new List <field>();
			field gridkey = null;
			if (IsLinkingObject(gridtable, ref allfields, connection)) {
				gridfields = GetLinkingObjectFields(gridtable, listtype, ref allfields, connection);
				gridkey = gridfields.Where(gf => gf.IsKey).FirstOrDefault();
			} else
				gridfields = GetFields(gridtable, listtype, allfields);
			var radiotag = "";
			foreach (var gf in gridfields.Where(gf => gf.ListVisible)) {
				if (gf.Type == "char" && gf.Len == 1) {
					var radiovalues = string.IsNullOrEmpty(gf.Radiovalues) ? "S;Si;N;No" : gf.Radiovalues;
					var v = radiovalues.Split(';').ToList();
					foreach (var r in v) {
						if (v.IndexOf(r) % 2 == 0) {
							radiotag += (gridkey != null ? "!" + gridkey.Name + "_" + gf.Table + "_" + gf.Name : gf.Name) + "," + r + ",";
						} else {
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
			FileInfo fiTarget = new FileInfo(target);
			if (File.Exists(fiTarget.FullName)) {
				if (overvrite) {
					File.Delete(fiTarget.FullName);
					fiSource.CopyTo(fiTarget.FullName, true);
				}
			} else {
				fiSource.CopyTo(fiTarget.FullName, true);
			}
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

			var newPath = Path.Combine(path, fileNameOnly.Replace("tabella",current) + extension);
			if (File.Exists(newPath))
				File.Delete(newPath);
			File.Move(fullPath, newPath);
			return newPath;
		}

		/// <summary>
		/// Sostituisce nel file reperibile al percorso fullPath la stringa toReplace con quella toWrite
		/// </summary>
		/// <param name="fullPath">percorso del file</param>
		/// <param name="toReplace">stringa da sostituire</param>
		/// <param name="toWrite">stringa sostituta</param>
		private static void ReplaceStringInFile(string fullPath, string toReplace, string toWrite) {

			var enc = GetEncoding(fullPath);
			string text = File.ReadAllText(fullPath, enc);
			if (text.Contains(toReplace))
				if (!text.Contains(toWrite.Replace(toReplace, "")) || toWrite == "default" || toWrite == string.Empty) {
					text = text.Replace(toReplace, toWrite);
					File.WriteAllText(fullPath, text, enc);
				}
		}

		private static void AppendStringInFile(string fullPath, string toWrite) {
			string text = File.ReadAllText(fullPath, Encoding.Default);
			if (!text.Contains(toWrite)) {
				text += "\r\n" + toWrite;
				File.WriteAllText(fullPath, text, Encoding.Default);
			}
		}

		public static Encoding GetEncoding(string filename) {
			// Read the BOM
			var bom = new byte[4];
			using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read)) {
				file.Read(bom, 0, 4);
			}

			// Analyze the BOM
			if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76) return Encoding.UTF7;
			if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf) return Encoding.UTF8;
			if (bom[0] == 0x28 && bom[1] == 0x66 && bom[2] == 0x75)
				return Encoding.UTF8;
			if (bom[0] == 0x2f && bom[1] == 0x2a && bom[2] == 0x2a)
				return Encoding.UTF8;
			if (bom[0] == 0xff && bom[1] == 0xfe) return Encoding.Unicode; //UTF-16LE
			if (bom[0] == 0xfe && bom[1] == 0xff) return Encoding.BigEndianUnicode; //UTF-16BE
			if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff) return Encoding.UTF32;
			return Encoding.Default; //ANSI
		}

		#endregion

	}

	#region classi di appoggio

	class obj
	{
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
		public string SearchEnabled { get; internal set; }
		public string CanInsert { get; internal set; }
		public string CanInsertCopy { get; internal set; }
		public string CanSave { get; internal set; }
		public string CanCancel { get; internal set; }
		public string CanCmdClose { get; internal set; }
		public string CanShowLast { get; internal set; }
		public bool OthersApp { get; set; }
		public string IsValid { get; set; }
		public bool Anonimous { get; set; }
	}

	class tab
	{
		public string Title { get; set; }
		public int Sort { get; set; }
		public string PageId { get; set; }
		public string Icon { get; set; }
		public string Tabheader { get; set; }
	}

	class field
	{
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
		public string EditListingType { get; set; }
		public string PageId { get; set; }
		public string Defaultvalue { get; set; }
		public string LookupFor { get; set; }
		public string Icon { get; set; }
		public string RelationType { get; set; }
		public int Textfield { get; set; }
		public string Radiovalues { get; set; }
		public string PageIdParent { get; internal set; }
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
	}

	class buttonField
	{
		public string Title { get; set; }
		public string Name { get; set; }
		public string Code { get; set; }
		public string Parameter { get; set; }
		public string Icon { get; set; }
		public string Tab { get; set; }
		public string Refresh { get; set; }
		public string Javascript { get; set; }
	}
	#endregion

}
