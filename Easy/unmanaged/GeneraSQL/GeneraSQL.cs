
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
using System.Data;
using metadatalibrary;
using System.IO;
using System.Collections;
using System.Text;
using System.Windows.Forms;


namespace generaSQL {//GeneraSQL//
	public enum UpdateType: int {onlyInsert=1, onlyUpdate=2, insertAndUpdate=3, bulkinsert=4};
	public enum DataGenerationType: int {onlyStructure=1, onlyData=2, structureAndData=3};
	/// <summary>
	/// Summary description for /*Rana:GeneraSQL.*/
	/// </summary>
	public class GeneraSQL {
		/// <summary>
		/// Generazione codice Create Table
		/// </summary>
		/// <param name="TableName">nome tabella</param>
		/// <param name="Column">Collection colonne</param>
		/// <param name="PKey">Collection chiavi</param>
		private static string SQLCreateTable(bool isDbo,string TableName, string[,] Column, string[] PKey) {
			string prefisso = isDbo ? "[dbo]." : "";
			int i;
			string command;
			command = "CREATE TABLE "+prefisso+"[" + TableName + "] (\r\n";
			int ncol= Column.GetLength(0);
			for(i = 0; i < ncol; i++) {
				command += Column[i,0] + " " + Column[i,1] + " " +  Column[i,2];
				if ((i+1<ncol)||(PKey.Length>0))command += ",\r\n";
			}
			if (PKey.Length>0){
				command += " CONSTRAINT xpk" + TableName + " PRIMARY KEY (";
				for(i = 0; i < PKey.Length; i++) {
					command+= PKey[i];
					if (i+1<PKey.Length)command += ",";
					command +="\r\n";
				}
				command += ")\r\n";
			}
			command +=  ")\r\n";
			return command;
		}

		/// <summary>
		/// Generazione controllo esistenza tabella
		/// </summary>
		/// <param name="TableName">nome tabella</param>
		private static string SQLTableExists(bool isDbo, string TableName, bool IsTable) {
			string dbo = isDbo ? "[dbo]." : "";
			string s = ""; //isDbo? "--[DBO]--\r\n":"";
			if (IsTable) {
				s += "-- CREAZIONE TABELLA " + TableName + " --\r\n";
				s += "IF NOT EXISTS(select * from sysobjects where id = object_id(N'"+dbo+"[" 
					+ TableName + "]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)\r\n";
			}
			else {
				s += "-- CREAZIONE VISTA " + TableName + "\r\n";
				s += "IF EXISTS(select * from sysobjects where id = object_id(N'"+dbo+"[" 
					+ TableName + "]') and OBJECTPROPERTY(id, N'IsView') = 1)\r\n"+
					"DROP VIEW "+dbo+"["+TableName+"]\r\n";
			}
			return s;
		}

		/// <summary>
		/// Generazione codice customobject
		/// </summary>
		/// <param name="tablename">nome tabella</param>
		private static string SQLCustomObject(string tablename, string isreal) {
			return "-- VERIFICA DI " + tablename + " IN CUSTOMOBJECT --\r\n" +
				"IF EXISTS(select * from customobject where objectname = '"+tablename+"')\r\n" +
				"UPDATE customobject set isreal = "+isreal+" where objectname = '"+tablename+"'\r\n" +
				"ELSE\r\n" +
				"INSERT INTO customobject (objectname, isreal) values('"+tablename+"', "+isreal+")\r\n" +
				"GO\r\n";
		}

		private static string GetSQLCustomObject(DataTable T, bool IsTable) {
			if (IsTable)
				return SQLCustomObject(T.TableName, "'S'");
			else
				return SQLCustomObject(T.TableName, "'N'");
		}

		/// <summary>
		/// Metodo per la generazione controllo esistenza
		/// </summary>
		/// <param name="tablename">nome tabella</param>
		/// <param name="colname">nome colonna</param>
		/// <param name="sqldeclaration">tipo sql della colonna</param>
		/// <param name="allownull">NULL/NOT NULL</param>
		/// <param name="key">S o N se il campo è chiave</param>
		/// <param name="defaultValue">DEFAULT valore oppure ""</param>
		/// <returns></returns>
		private static void SQLColumnExists(TextWriter sw, bool isDbo, DataAccess dataAccess, string tablename, string colname,
			string sqldeclaration, string allownull, string iskey, string defaultValue, bool keyToo) {
			string dbo = "";//isDbo ? "[dbo]." : "";
			sw.WriteLine("IF NOT exists(select * from "+dbo+"[sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = '"+tablename+"' and C.name = '"+colname+"' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))");
			sw.WriteLine("BEGIN");
			sw.WriteLine("\tALTER TABLE "+dbo+"["+tablename+"] ADD "+colname+" " +sqldeclaration+ " " +allownull+" "+defaultValue);
			if (defaultValue != "") {
				sw.WriteLine("\tdeclare @vincolo varchar(100)");
				sw.WriteLine("\tselect @vincolo = object_name(const.constid)"
					+ " from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid"
					+ " where col.id = object_id("
					+ QueryCreator.quotedstrvalue(tablename, true)
					+ ") and col.name = "
					+ QueryCreator.quotedstrvalue(colname, true)
					+ " and objectproperty(const.constid, 'IsDefaultCnst')=1");
				sw.WriteLine("\texec ('ALTER TABLE "+dbo+"["+tablename+"] drop constraint '+@vincolo)");
			}
			sw.WriteLine("END");
			if (sqldeclaration.ToLower() != "text" && sqldeclaration.ToLower() != "image" &&
				sqldeclaration.ToLower() != "ntext" && sqldeclaration.ToLower() != "timestamp" &&
				(iskey != "S" || keyToo)) {
				sw.WriteLine("ELSE");
				sw.WriteLine("\tALTER TABLE "+dbo+"["+tablename+"] ALTER COLUMN "+colname+" "+sqldeclaration+" "+allownull);
			}
			sw.WriteLine("GO");
			sw.WriteLine();
		}

		/// <summary>
		/// Genera il codice SQL relativo alla tabella ColumnTypes
		/// </summary>
		/// <param name="tablename">Nome tabella</param>
		/// <param name="C">Colonna</param>
		private static string SQLColumnTypes(string tablename, DataColumn C) {
			string field = C.ExtendedProperties["field"].ToString();
			dbstructure myDB= new dbstructure();
			
			string s ;
            //= "IF exists(SELECT * FROM columntypes WHERE tablename = '"+tablename+"' AND field = '"+field+"')\r\n";
            //s += "UPDATE columntypes set ";
            //foreach (string key in C.ExtendedProperties.Keys) {
            //    if (key == "createtimestamp" || key == "lastmodtimestamp") continue;
            //    if (myDB.columntypes.Columns[key]==null) continue;
            //    s += key + " = " + QueryCreator.quotedstrvalue(C.ExtendedProperties[key], true) + ",";
            //}
            //s = s.Remove(s.Length - 1, 1);
            //s += " where tablename = '"+tablename+"' AND field = '"+field+"'\r\n";
            //s += "ELSE\r\n";
			s = "INSERT INTO columntypes (";
			foreach (string key in C.ExtendedProperties.Keys) {
				if (key == "createtimestamp" || key == "lastmodtimestamp") continue;
				if (myDB.columntypes.Columns[key]==null) continue;
				s += key + ",";
			}
			s = s.Remove(s.Length - 1, 1) + ")";
			s += " VALUES(";
			foreach (string key in C.ExtendedProperties.Keys) {
				if (key == "createtimestamp" || key == "lastmodtimestamp") continue;
				if (myDB.columntypes.Columns[key]==null) continue;
				s += QueryCreator.quotedstrvalue(C.ExtendedProperties[key], true) + ",";
			}
			s = s.Remove(s.Length - 1, 1) + ")\r\n";
			s += "GO\r\n\r\n";
			return s;
		}

		private static string GetDefaultValue(DataColumn C) {
			string allownull = C.ExtendedProperties["allownull"].ToString().ToUpper();
			string iskey = C.ExtendedProperties["iskey"].ToString().ToUpper();
			if ((allownull == "S")
				//	||(iskey == "S")
				) return "";

			string typename= C.DataType.Name;
			switch(typename) {
				case "String": return "DEFAULT "+QueryCreator.quotedstrvalue("", true);
				case "Char": return "DEFAULT "+QueryCreator.quotedstrvalue("", true);
				case "Double": return "DEFAULT "+QueryCreator.quotedstrvalue("", true);
				case "Single": return "DEFAULT 0";
				case "Decimal": return "DEFAULT 0";                
				case "DateTime": return "DEFAULT "+QueryCreator.EmptyDate().ToShortDateString();
				case "Int16": return "DEFAULT 0"; 
				case "Int32": return "DEFAULT 0";
				default: return "DEFAULT "+QueryCreator.quotedstrvalue("", true);
			}          
		}

		private static void GetSQLColumnExists(TextWriter sw, bool isDbo, DataAccess dataAccess, DataTable T, string[,] cols, bool keyToo) {
			int colcount = T.Columns.Count;
			sw.WriteLine("-- VERIFICA STRUTTURA " + T.TableName + " --");
			for (int i=0; i < colcount; i++){
				string iskey = T.Columns[i].ExtendedProperties["iskey"].ToString().ToUpper();
				string defaultValue = GetDefaultValue(T.Columns[i]);
				SQLColumnExists(sw, isDbo, dataAccess, T.TableName, cols[i,0], cols[i,1], cols[i,2], iskey, defaultValue, keyToo);
			}
		}


		private static string GetSQLColumnTypes(DataTable T, string[,] cols) {
			int colcount = T.Columns.Count;
			string sql = "-- VERIFICA DI " + T.TableName + " IN COLUMNTYPES --\r\n";
			sql += "DELETE FROM columntypes WHERE tablename = '" + T.TableName + "'\r\n";
			for (int i=0; i < colcount; i++){
				sql += SQLColumnTypes(T.TableName, T.Columns[i]);
			}
			return sql;
		}

		/// <summary>
		/// </summary>
		/// <param name="T">Datatable</param>
		public static string GetSQLTable(bool isDbo, DataAccess dataAccess, DataTable T, out string[,] cols, bool IsTable) {
			string[] key;
			cols = GetColumnsInfo(dataAccess, T, out key);	
			/*			DataTable tChiave = dataAccess.SQLRunner("sp_pkeys "+T.TableName);
						int colcount = T.Columns.Count;
						cols = new string[colcount,3];
						string[] key= new string[tChiave.Rows.Count];
						for (int i=0; i<tChiave.Rows.Count; i++){
							key[i] = tChiave.Rows[i]["COLUMN_NAME"].ToString();
							DataColumn c = T.Columns[key[i]];
							cols[i,0] = c.ExtendedProperties["field"].ToString();
							cols[i,1] = c.ExtendedProperties["sqldeclaration"].ToString();
							if (c.ExtendedProperties["allownull"].ToString().ToUpper()=="S")	
								cols[i,2]= "NULL";
							else
								cols[i,2]= "NOT NULL";		
						}
						int j=tChiave.Rows.Count;
						for (int i=0; i< colcount; i++){
							DataColumn c = T.Columns[i];
							if (tChiave.Select("COLUMN_NAME="+QueryCreator.quotedstrvalue(c.ColumnName, false)).Length == 0) {
								cols[j,0] = c.ExtendedProperties["field"].ToString();
								cols[j,1] = c.ExtendedProperties["sqldeclaration"].ToString();
								if (c.ExtendedProperties["allownull"].ToString().ToUpper()=="S")	
									cols[j,2]= "NULL";
								else
									cols[j,2]= "NOT NULL";		
								j++;
							}
						}*/
			//			string[] key= new string[T.PrimaryKey.Length];
			//			for (int i=0; i<key.Length; i++) key[i] = T.PrimaryKey[i].ColumnName;

			string command = SQLTableExists(isDbo, T.TableName, IsTable);
			if (IsTable) {
				command += "BEGIN\r\n";
				command += SQLCreateTable(isDbo, T.TableName, cols, key);
				command += "END\r\nGO\r\n\r\n";
				
                //string indexes=GetSQLIndexes(dataAccess, T);
                //if (indexes!=null) command += indexes;

			}
			else {
				string query = "select text from syscomments "
					+ " where (id = object_id("	+ QueryCreator.quotedstrvalue(T.TableName, true)
					+ "))";

				DataTable t = dataAccess.SQLRunner(query);

				command += "GO\r\n\r\n";

				foreach (DataRow rVista in t.Rows) {
					command += rVista["text"];
				}

				command += "\r\nGO\r\n\r\n";
			}
			return command;
		}

		public static string[,] GetColumnsInfo(DataAccess dataAccess, DataTable T, out string[] key) {
			DataTable tChiave = dataAccess.SQLRunner("sp_pkeys "+T.TableName);
			int colcount = T.Columns.Count;
			string[,] cols = new string[colcount,3];
			key= new string[tChiave.Rows.Count];
			for (int i=0; i<tChiave.Rows.Count; i++){
				key[i] = tChiave.Rows[i]["COLUMN_NAME"].ToString();
				DataColumn c = T.Columns[key[i]];
				cols[i,0] = c.ExtendedProperties["field"].ToString();
				cols[i,1] = c.ExtendedProperties["sqldeclaration"].ToString();
				if (c.ExtendedProperties["allownull"].ToString().ToUpper()=="S")	
					cols[i,2]= "NULL";
				else
					cols[i,2]= "NOT NULL";		
			}
			int j=tChiave.Rows.Count;
			for (int i=0; i< colcount; i++){
				DataColumn c = T.Columns[i];
				if (tChiave.Select("COLUMN_NAME="+QueryCreator.quotedstrvalue(c.ColumnName, false)).Length == 0) {
					cols[j,0] = c.ExtendedProperties["field"].ToString();
					cols[j,1] = c.ExtendedProperties["sqldeclaration"].ToString();
					if (c.ExtendedProperties["allownull"].ToString().ToUpper()=="S")	
						cols[j,2]= "NULL";
					else
						cols[j,2]= "NOT NULL";		
					j++;
				}
			}
			return cols;
		}

		static object GetProp(DataTable MSIndexes, string prop, string indexname){
			foreach (DataRow R in MSIndexes.Rows){
				if (R["name"].ToString()!=indexname) continue;
				if (R[prop]==DBNull.Value) return null;
				return R[prop];
			}
			return null;
		}
		public static string GetSQLIndexes(DataAccess dataAccess, DataTable T){
			DataTable Indexes= dataAccess.SQLRunner("sp_helpindex "+T.TableName);
			DataTable MSIndexes= dataAccess.SQLRunner("sp_MShelpindex "+T.TableName);
			if (Indexes==null) return null;
			string S="";
			foreach (DataRow R in Indexes.Rows){
				if (R["index_description"].ToString().ToUpper().IndexOf("AUTO CREATE")>=0) continue;
				string index_name=R["index_name"].ToString();

				string SS="";				
				//Creazione dell'indice relativo alla riga R
				//R = index_name,index_description,index_keys
				SS+="     CREATE ";
				if (R["index_description"].ToString().ToUpper().IndexOf("UNIQUE")>=0)SS+= "UNIQUE ";
				if (R["index_description"].ToString().ToUpper().IndexOf("NONCLUSTERED")>=0)
					SS+= "NONCLUSTERED ";
				else 
					continue; //!! è usato come chiave,non si può modificare!	SS+= "CLUSTERED " ;
				SS+="INDEX "+index_name+"\r\n";
				SS+="     ON "+T.TableName+ " ("+R["index_keys"].ToString()+" )\r\n";
				
                DataTable includeFields = dataAccess.SQLRunner(
                    " SELECT    IndexName = i.Name,  ColName = c.Name  " +
                    " FROM     sys.indexes i " +
                    " INNER JOIN     sys.index_columns ic ON ic.object_id = i.object_id AND ic.index_id = i.index_id " +
                    " INNER JOIN     sys.columns c ON c.object_id = ic.object_id AND c.column_id = ic.column_id " +
                    " WHERE    ic.is_included_column = 1 and i.Name = '" + index_name + "'", true);
                if (includeFields != null && includeFields.Rows.Count>0) {
                    string include= "     INCLUDE(";
                    bool first = true;
                    foreach(DataRow r in includeFields.Rows) {
                        if (!first) {
                            include += ",";
                        }
                        first = false;
                        include += r["ColName"];
                    }
                    include += ")\r\n";
                    SS += include;
                }
                string SS2 = SS;
                string WITH= "     WITH ";
				object pad= GetProp(MSIndexes,"OrigFillFactor",index_name);
				bool toadd=false;
				if (pad!=null){
					if (pad.ToString()!="0"){
						WITH+="PAD_INDEX, FILLFACTOR ="+pad.ToString()+" ";
						toadd=true;
					}
				}

				if (WITH!= "     WITH ") {
					SS2+=WITH;
					SS +=WITH;
					if (toadd) SS+=",";
					SS+=" DROP_EXISTING ";
				}
				else {
					SS+= WITH;
					SS+=" DROP_EXISTING ";
				}

				SS+="ON ["+ GetProp(MSIndexes,"SegName",index_name)+"]";
				SS2+="ON ["+ GetProp(MSIndexes,"SegName",index_name)+"]";
				SS+="\r\n";
				SS2+="\r\n";


				S+="IF EXISTS (SELECT * FROM sysindexes where name='"
					+ index_name
					+ "' and id=object_id('" + T.TableName
					+ "'))\r\n";
				S+= "BEGIN\r\n";
				S+= SS;
				S+= "END\r\n";
				S+= "ELSE\r\n";
				S+= "BEGIN\r\n";
				S+= SS2;
				S+= "END\r\n";
				S+="GO\r\n\r\n";
			}
			if (S=="")return null;
			return S;
		}

		/// <summary>
		///Restituisce il codice sql relativo all'inserimento/aggiornamento 
		///dati della tabella
		/// </summary>
		/// <param name="T">tabella</param>
		//		private static void GetSQLData(bool isDbo, DataTable T, TextWriter w) 
		//		{
		//			GetSQLData(isDbo, T, UpdateType.insertAndUpdate, w, true);
		//		}

		/// <summary>
		/// </summary>
		/// <param name="T">tabella</param>
		/// <param name="ExistCheck">True per controllo esistenza dati</param>
		/// <param name="w">Stream di output</param>
		/// <param name="ConvertCRLFData">True per convertire i CR LF presenti nei dati</param>
		//		private static void GetSQLData(bool isDbo, DataTable T, bool ExistCheck, StreamWriter w, bool ConvertCRLFData) 
		//		{
		//			UpdateType updateType = ExistCheck ? UpdateType.insertAndUpdate : UpdateType.onlyUpdate;
		//			GetSQLData(isDbo, T, updateType, w, ConvertCRLFData);
		//		}

		public static string GetSQLDataValues(DataRow row/*, bool ConvertCRLFData*/) {
			bool ConvertCRLFData = false;
			string s = "";
			int colcount = row.Table.Columns.Count;
			for (int i = 0; i < colcount; i++) {
				string valore = ConvertCRLFData
					? QueryCreator.GetPrintable(QueryCreator.quotedstrvalue(row[i], true))
					: QueryCreator.quotedstrvalue(row[i], true);
				s += valore + ",";
			}
			s = s.Remove(s.Length - 1, 1);
			return s + ")\r\n";
		}

		private static string GetSQLDataForUpdate(bool isDbo, string wherecond, bool ConvertCRLFData, DataRow row) {
			string dbo = isDbo ? "[dbo]." : "";
			DataTable T = row.Table;
			string s = "UPDATE "+dbo+"["+T.TableName+"] SET ";

			for (int i = 0; i < T.Columns.Count; i++) {
				if (T.Columns[i].ExtendedProperties["iskey"].ToString().ToUpper() == "S") continue;
				string valore = "";
				if (ConvertCRLFData)
					valore=QueryCreator.GetPrintable(QueryCreator.quotedstrvalue(row[i], true));
				else
					valore=QueryCreator.quotedstrvalue(row[i], true);
				s += T.Columns[i].ColumnName + " = " + valore + ",";
			}
			s = s.Remove(s.Length - 1, 1);
			s += " WHERE " + wherecond + "\r\n";
			return s;
		}

		public static void GetSQLData(DataTable T, UpdateType updateType, TextWriter writer/*, bool ConvertCRLFData*/) {
			GetSQLData(T, updateType, writer, 10);
		}

		/// <summary>
		/// Crea uno script di soli dati di una tabella
		/// </summary>
		/// <param name="T">Tabella di cui si vuole creare lo script</param>
		/// <param name="updateType">tipo di aggiornamento (onlyInsert, bulkInsert, InsertAndUpdate)</param>
		/// <param name="w">TextWriter su cui scrivere</param>
		/// <param name="rowsPerBlock">Se maggiore di 0, indica ogni quante righe nello script deve essere inserito un go;
		/// Se minore o uguale a 0 allora nello script non verranno inseriti i go</param>
		public static void GetSQLData(DataTable T, UpdateType updateType, TextWriter writer, int rowsPerBlock) {
			bool ConvertCRLFData = false;
			bool isDbo = false;
			string dbo = isDbo ? "[dbo]." : "";
			bool HasKey;
			string tablename = T.TableName;

			//--- è indipendente dalla riga  ----
			string insert = "INSERT INTO "+dbo+"["+tablename+"] (";
			foreach (DataColumn C in T.Columns) {
				insert += C.ColumnName + ",";
			}
			insert = insert.Remove(insert.Length - 1, 1);
			insert += ") VALUES (";
			// ----------------------------------

			int pkLenght = T.PrimaryKey.Length;
			int colcount = T.Columns.Count;

			writer.Write("\r\n-- GENERAZIONE DATI PER " + tablename + " --\r\n");
			int count=0;
			string s = "";

			foreach (DataRow row in T.Rows) {
				int i = 0;
				count++;
				string wherecond = "";
				HasKey = false;
				for (i = 0; i < pkLenght; i++) {
					HasKey = true;
					wherecond += T.PrimaryKey[i].ColumnName + " = " + 
						QueryCreator.quotedstrvalue(row[T.PrimaryKey[i].ColumnName], true) +
						" AND ";
				}
				if ((updateType!=UpdateType.bulkinsert) && (!HasKey)) continue;
				if (wherecond!="")	wherecond = wherecond.Remove(wherecond.Length - 5, 5);

				switch (updateType) {
					case UpdateType.insertAndUpdate: {
						string update = GetSQLDataForUpdate(isDbo, wherecond, ConvertCRLFData, row);
						string values = GetSQLDataValues(row/*, ConvertCRLFData*/);
						s += "IF exists(SELECT * FROM "+dbo+"["+tablename+"] WHERE "+wherecond+")\r\n"
							+ update
							+ "ELSE\r\n"
							+ insert
							+ values;
						break;
					}
					case UpdateType.onlyInsert: {
						string values = GetSQLDataValues(row/*, ConvertCRLFData*/);
						s += "IF not exists(SELECT * FROM "+dbo+"["+tablename+"] WHERE "+wherecond+")\r\n"
							+ insert
							+ values;
						break;
					}
					case UpdateType.bulkinsert: {
						string values = GetSQLDataValues(row/*, ConvertCRLFData*/);
						s += //"IF not exists(SELECT * FROM "+dbo+"["+tablename+"] WHERE "+wherecond+")\r\n"+
							insert
							+ values;
						break;
					}


					case UpdateType.onlyUpdate: {
						//s = "IF exists(SELECT * FROM "+dbo+"["+tablename+"] WHERE "+wherecond+")\r\n"
						s += GetSQLDataForUpdate(isDbo, wherecond, ConvertCRLFData, row);
						break;
					}
				}
				if ((updateType== UpdateType.bulkinsert)||(updateType==UpdateType.onlyInsert)){
					if (count == rowsPerBlock){
						s += "GO\r\n\r\n";
						writer.Write(s);
						writer.Flush();
						s = "";
						count=0;
					}
				} 
				else {
					s += "GO\r\n\r\n";
					writer.Write(s);
					writer.Flush();
					s="";
				}
			}
			if (s!="") {
				if (rowsPerBlock > 0) {
					s += "GO\r\n\r\n";
				}
				writer.Write(s);
				writer.Flush();
				s="";
			}
		}
		
		/// <summary>
		/// Genera script struttura SQL
		/// </summary>
		/// <param name="XMLInputFile">File XML da cui generare lo script</param>
		/// <param name="SQLOutputFile">Nome del file generato</param>
		//		public static void GeneraStruttura(bool dbo, DataAccess dataAccess, string XMLInputFile, string SQLOutputFile) {
		//			DataSet DS = new DataSet();
		//			DS.ReadXml(XMLInputFile);
		//			DO_GENERATE(dbo, dataAccess, DS, SQLOutputFile, UpdateType.insertAndUpdate, DataGenerationType.onlyStructure, true);
		//		}

		/// <summary>
		/// Genera script struttura e dati SQL
		/// </summary>
		/// <param name="XMLInputFile">File XML da cui generare lo script</param>
		/// <param name="SQLOutputFile">Nome del file generato</param>
		/// <param name="filter">Filtro da applicare alla generazione dei dati</param>
		/// <param name="DataExistCheck">se True genera codice per l'inserimento dati</param>
		public static void GeneraStrutturaEDati(/*bool dbo, */DataAccess dataAccess,
			string XMLInputFile, string SQLOutputFile, 
			UpdateType updateType, DataGenerationType dataGenerationType, bool isTable) {
			DataSet DS = new DataSet();
			DS.ReadXml(XMLInputFile);
			StreamWriter writer = new StreamWriter(SQLOutputFile, false, System.Text.Encoding.Default);
			DO_GENERATE(/*dbo, */dataAccess, DS, writer, updateType, dataGenerationType, isTable);
			writer.Close();
		}


		/// <summary>
		/// Genera script struttura
		/// </summary>
		/// <param name="DS">dataset</param>
		/// <param name="SQLOutputFile">output file name</param>
		//		public static void GeneraStruttura(bool dbo, DataAccess dataAccess, DataSet DS, string SQLOutputFile) 
		//		{
		//			DO_GENERATE(dbo, dataAccess, DS, SQLOutputFile, UpdateType.onlyUpdate, DataGenerationType.onlyStructure, true);
		//		}

		/// <summary>
		/// Genera script sql struttura e dati
		/// </summary>
		/// <param name="DS">dataset</param>
		/// <param name="SQLOutputFile">output file name</param>
		/// <param name="DataExistCheck">se True genera codice per l'inserimento dati</param>
		//		public static void GeneraStrutturaEDati2(bool dbo, DataAccess dataAccess, DataSet DS, string SQLOutputFile, 
		//			UpdateType updateType) {
		//			DO_GENERATE(dbo, dataAccess, DS, SQLOutputFile, updateType, DataGenerationType.structureAndData, true);
		//		}

		/// <summary>
		/// Genera script sql struttura e dati
		/// </summary>
		/// <param name="DS">dataset</param>
		/// <param name="SQLOutputFile">output file name</param>
		/// <param name="DataExistCheck">se True genera codice per l'inserimento dati</param>
		/// <param name="DataGeneration">True se bisogna generare i dati per la tabella</param>
		//		public static void GeneraStrutturaEDati3(bool dbo, DataAccess dataAccess, DataSet DS, string SQLOutputFile, 
		//			UpdateType updateType, DataGenerationType generationType) {
		//			DO_GENERATE(dbo, dataAccess, DS, SQLOutputFile, updateType, generationType, true);
		//		}

		/// <summary>
		/// Genera script sql struttura e dati
		/// </summary>
		/// <param name="DS">dataset</param>
		/// <param name="SQLOutputFile">output file name</param>
		/// <param name="DataExistCheck">se True genera codice per l'inserimento dati</param>
		/// <param name="DataGeneration">True se bisogna generare i dati per la tabella</param>
		/// <param name="IsTable">True se lo script riguarda una tabella, altrimenti lo 
		/// script è generato per una Vista</param>
		//		public static void GeneraStrutturaEDati(bool dbo, DataAccess dataAccess,
		//			DataSet DS, string SQLOutputFile, 
		//			UpdateType updateType, DataGenerationType generationType, bool IsTable) 
		//		{
		//			DO_GENERATE(dbo, dataAccess, DS, SQLOutputFile, updateType, generationType, IsTable);
		//		}

		/// <summary>
		/// Genera script sql struttura e dati
		/// </summary>
		/// <param name="DS">dataset</param>
		/// <param name="SQLOutputFile">output file name</param>
		/// <param name="DataExistCheck">se True genera codice per l'inserimento dati</param>
		/// <param name="DataGeneration">True se bisogna generare i dati per la tabella</param>
		/// <param name="IsTable">True se lo script riguarda una tabella, altrimenti lo 
		/// script è generato per una Vista</param>
		/// <param name="ConvertCRLFData">True per convertire i CR LF in caso di generazione dati</param>
		//		public static void GeneraStrutturaEDati5(bool dbo, DataAccess dataAccess, DataSet DS, string SQLOutputFile, 
		//			UpdateType updateType, DataGenerationType generationType, bool IsTable, bool ConvertCRLFData) 
		//		{
		//			DO_GENERATE(dbo, dataAccess, DS, SQLOutputFile, updateType, generationType, IsTable);
		//		}

		/// <summary>
		/// Genera script sql struttura e dati
		/// </summary>
		/// <param name="DS">dataset</param>
		/// <param name="SQLOutputFile">output file name</param>
		/// <param name="DataExistCheck">se True genera codice per l'inserimento dati</param>
		/// <param name="DataGeneration">True se bisogna generare i dati per la tabella</param>
		/// <param name="IsTable">True se lo script riguarda una tabella, altrimenti lo 
		/// script è generato per una Vista</param>
		/// <param name="ConvertCRLFData">True per convertire i CR LF in caso di generazione dati</param>
		/// <param name="DataOnly">La generazione riguarda solo i dati</param>
		//		public static void GeneraStrutturaEDati6(bool dbo, DataAccess dataAccess, DataSet DS, string SQLOutputFile, 
		//			UpdateType updateType, DataGenerationType generationType, bool IsTable, bool ConvertCRLFData) {
		//			DO_GENERATE(dbo, dataAccess, DS, SQLOutputFile, updateType, generationType, IsTable/*, ConvertCRLFData*/);
		//		}

		/// <summary>
		/// Genera script sql struttura e dati, attenzione qui le tabelle sono tutte dbo o non dbo
		/// </summary>
		/// <param name="DS">dataset</param>
		/// <param name="SQLOutputFile">output file name</param>
		/// <param name="updateType">tipo di modifica: solo update, solo insert, insert+update</param>
		/// <param name="DataGeneration">True se bisogna generare i dati per la tabella</param>
		/// <param name="IsTable">True se lo script riguarda una tabella, altrimenti lo 
		/// script è generato per una Vista</param>
		/// <param name="ConvertCRLFData">True per convertire i CR LF in caso di generazione dati</param>
		/// <param name="DataOnly">La generazione riguarda solo i dati</param>
		public static void GeneraStrutturaEDati(/*bool dbo, */DataAccess dataAccess, DataSet DS, string SQLOutputFile, 
			bool append,
			UpdateType updateType, DataGenerationType dataGenerationType, bool IsTable/*, bool ConvertCRLFData*/) {
			StreamWriter writer = new StreamWriter(SQLOutputFile, append, System.Text.Encoding.Default);        
           
            DO_GENERATE(/*dbo, */dataAccess, DS, writer, updateType, dataGenerationType, IsTable/*, ConvertCRLFData*/);
			writer.Close();
		}
        

		public static void GeneraStrutturaEDatiSplitted(/*bool dbo, */DataAccess dataAccess, DataSet DS, string SQLOutputFileNonDBO,  string SQLOutputFileDBO,
			bool append,
			UpdateType updateType, DataGenerationType dataGenerationType, bool IsTable/*, bool ConvertCRLFData*/) {
			
            StreamWriter writerNonDBO = null;
			bool someDBO = false;
			foreach (DataTable t in DS.Tables) {
				string query = "select user_name(objectproperty(object_id("
				               + QueryCreator.quotedstrvalue(t.TableName, true)
				               + "),'OwnerId'))";

				string dbo =  dataAccess.SQLRunner(query).Rows[0][0].ToString();
				if (dbo == "dbo") {
					someDBO = true;
				}
			}

			
			if (!someDBO) {
				writerNonDBO = new StreamWriter(SQLOutputFileNonDBO, append, System.Text.Encoding.Default);
				DO_GENERATE( dataAccess, DS, writerNonDBO, updateType, dataGenerationType,IsTable );
			}
			else {
                //La tabella è dbo
                if (dataGenerationType != DataGenerationType.onlyData) {
	                writerNonDBO = new StreamWriter(SQLOutputFileNonDBO, append, System.Text.Encoding.Default);
                }

				bool fileEmpty = true;
				if (File.Exists(SQLOutputFileDBO)) {
                    var fInfo = new FileInfo(SQLOutputFileDBO);
                    if (fInfo.Length > 0) fileEmpty = false;
				}     

				StreamWriter writerDBO = new StreamWriter(SQLOutputFileDBO, append, System.Text.Encoding.Default);
				if(fileEmpty) writerDBO.WriteLine("--[DBO]--");

				DO_GENERATE_SPLITTED( dataAccess, DS, writerNonDBO, writerDBO,  updateType, dataGenerationType,IsTable );
				writerDBO.Close();
			}

			writerNonDBO?.Close();
            
		}

		public static void GeneraStrutturaEDati(/*bool dbo, */DataAccess dataAccess, DataSet DS, TextWriter writer, 
			UpdateType updateType, DataGenerationType dataGenerationType, bool IsTable/*, bool ConvertCRLFData*/) {
			DO_GENERATE(/*dbo, */dataAccess, DS, writer, updateType, dataGenerationType, IsTable/*, ConvertCRLFData*/);
		}

		public static void DO_GENERATE_SPLITTED( /*bool isDbo, */ DataAccess dataAccess, DataSet DS,
			TextWriter writerNonDBO, TextWriter writerDBO,
			UpdateType updateType, DataGenerationType dataGenerationType, bool IsTable) {
			bool dboWritten = false;
			bool nonDboWritten = false;
			foreach (DataTable T in DS.Tables) {
				string query = "select user_name(objectproperty(object_id("
				               + QueryCreator.quotedstrvalue(T.TableName, true)
				               + "),'OwnerId'))";

				string dbo = dataAccess.SQLRunner(query).Rows[0][0].ToString();
				bool isDbo = dbo == "dbo";
				if (dataGenerationType != DataGenerationType.onlyData) {
					if (isDbo) {
						GeneraStrutturaPura(isDbo, dataAccess, T, writerDBO, IsTable);
						dboWritten = true;
						GeneraColTypesStruttura(isDbo, dataAccess, T, writerNonDBO, IsTable);
						nonDboWritten = true;
					}
					else {
						GeneraStruttura(isDbo, dataAccess, T, writerNonDBO, IsTable);
						nonDboWritten = true;
					}
				}

				//			bool ConvertCRLFData = false;
				if (dataGenerationType != DataGenerationType.onlyStructure) {
					if (isDbo) {
						GetSQLData(T, updateType, writerDBO);
						dboWritten = true;
					}
					else {
						GetSQLData(T, updateType, writerNonDBO);
						nonDboWritten = true;
					}
				}

				
			}

			if (dboWritten) {
				writerDBO.Write("-- FINE GENERAZIONE SCRIPT --\r\n\r\n");
				writerDBO.Flush();
			}
			if (nonDboWritten) {
				writerNonDBO.Write("-- FINE GENERAZIONE SCRIPT --\r\n\r\n");
				writerNonDBO.Flush();

			}

		}

		public  static void DO_GENERATE(/*bool isDbo, */DataAccess dataAccess, DataSet DS, TextWriter writer,
			UpdateType updateType, DataGenerationType dataGenerationType, bool IsTable) {            
               
			foreach (DataTable T in DS.Tables) {
				string query = "select user_name(objectproperty(object_id("
					+ QueryCreator.quotedstrvalue(T.TableName, true)
					+ "),'OwnerId'))";

				string dbo = dataAccess.SQLRunner(query).Rows[0][0].ToString();
				bool isDbo = dbo=="dbo";             
				if (dataGenerationType != DataGenerationType.onlyData) {
					GeneraStruttura(isDbo, dataAccess, T, writer, IsTable);
				}
			}
			//			bool ConvertCRLFData = false;
			if (dataGenerationType != DataGenerationType.onlyStructure) {
				foreach (DataTable T in DS.Tables) {
					GetSQLData(/*false, */T, updateType, writer/*, ConvertCRLFData*/);
				}
			}
			writer.Write("-- FINE GENERAZIONE SCRIPT --\r\n\r\n");
			writer.Flush();
		}

		public static void GeneraStrutturaPura(bool isDbo, DataAccess dataAccess, DataTable T, TextWriter writer, 
			bool IsTable/*, bool ConvertCRLFData*/) {
			string[,] cols;
			string[] key;
			string sqltable = GetSQLTable(isDbo, dataAccess, T, out cols, IsTable);
			writer.Write(sqltable);
			if (IsTable) {
				GetSQLColumnExists(writer, isDbo, dataAccess, T, cols, false);
			}
			string indexes = null;
			if (IsTable) indexes = GetSQLIndexes(dataAccess, T);
			if (indexes != null) writer.Write(indexes);
			writer.Flush();
		}

		public static void GeneraColTypesStruttura(bool isDbo, DataAccess dataAccess, DataTable T, TextWriter writer,
			bool IsTable /*, bool ConvertCRLFData*/) {
			string[] key;
			string[,] cols = GetColumnsInfo(dataAccess, T, out key);
			string sqlcolumntypes = GetSQLColumnTypes(T, cols);
			string sqlcustomobject = GetSQLCustomObject(T, IsTable);
			writer.Write(sqlcolumntypes); 
            writer.Write(sqlcustomobject);
			writer.Flush();
		}

		public static void GeneraStruttura(bool isDbo, DataAccess dataAccess, DataTable T, TextWriter writer, 
			bool IsTable/*, bool ConvertCRLFData*/) {
			GeneraStrutturaPura(isDbo, dataAccess, T, writer, IsTable);
			GeneraColTypesStruttura(isDbo, dataAccess, T, writer, IsTable);
		}

		public static void GeneraStrutturaCambiandoChiave(DataAccess dataAccess, TextReader sr, TextWriter writer) {
			for (string tabella = sr.ReadLine(); tabella != null; tabella = sr.ReadLine()) {
				DataTable T = dataAccess.CreateTableByName(tabella, "*", true);
				string indexes = GeneraSQL.GetSQLIndexes(dataAccess, T);
				string qUserName = "select user_name(uid) from sysobjects where "+
					"id=object_id('"+tabella+"')";
				DataTable tUserName = dataAccess.SQLRunner(qUserName);
				string userName = tUserName.Rows[0][0].ToString();
				bool isDbo = userName == "dbo";
				string qSysIndexes = "select * from sysindexes where id = object_id('"
					+ tabella
					+ "') and indid > 0 and indid < 255 and (status & 64)=0";
				DataTable tHelpIndex = dataAccess.SQLRunner(qSysIndexes);
				writer.WriteLine("--Cancellazione della chiave e degli indici di "+tabella);
				writer.WriteLine("IF EXISTS (SELECT * FROM sysindexes where name='PK_"
					+ tabella
					+ "' and id=object_id('" + tabella
					+ "'))");
				writer.WriteLine("\talter table "+tabella+" drop constraint PK_"+tabella+"");
				writer.WriteLine("go");

				foreach (DataRow r in tHelpIndex.Rows) {
					writer.WriteLine("IF EXISTS (SELECT * FROM sysindexes where name='"
						+ r["name"]
						+ "' and id=object_id('" + T.TableName
						+ "'))");
					int status = (int)r["status"];
					if ((status & 0x800) == 0x800) {
						writer.WriteLine("\talter table "+tabella+" drop constraint "+r["name"]);
					} else {
						writer.WriteLine("\tdrop index " + tabella + "." +r["name"]);
					}
					writer.WriteLine("go");
				}
				string[] PKey;
				string[,] cols  = GeneraSQL.GetColumnsInfo(dataAccess, T, out PKey);
				GeneraSQL.GetSQLColumnExists(writer, isDbo, dataAccess, T, cols, true);
				string sqlcolumntypes = GeneraSQL.GetSQLColumnTypes(T, cols);
				writer.Write(sqlcolumntypes);
				string sqlcustomobject = GeneraSQL.GetSQLCustomObject(T, true);
				writer.Write(sqlcustomobject);
				writer.WriteLine("--Reinserimento della chiave di "+tabella);
				if (PKey.Length>0){
					writer.Write("alter table "+tabella+" ADD CONSTRAINT xpk" + tabella + " PRIMARY KEY (");
					for (int i = 0; i < PKey.Length; i++) {
						writer.Write(PKey[i]);
						if (i+1<PKey.Length)
							writer.Write(", ");
					}
					writer.WriteLine(")");
					writer.WriteLine("go");
				}
				writer.WriteLine("--Reinserimento degli indici "+tabella);
				writer.Write(indexes);
				writer.Flush();
			}
		}

	    public static string scriptOneSP(DataAccess conn, string spName) {            
            string query = "select object_name(id), id, text from syscomments "
                 + "where objectproperty(id,'isprocedure')=1 and objectproperty(id,'IsMSShipped')=0";
            query += " and object_name(id) = '" + spName + "'";
            
            DataTable t = conn.SQLRunner(query);
            StringBuilder sb = new StringBuilder();
            ArrayList list = new ArrayList();
            foreach (DataRow r in t.Rows) {
                if (!list.Contains(r["id"])) {
                    list.Add(r["id"]);
                }
            }
            foreach (int id in list) {
                DataRow[] rSysComments = t.Select("id=" + id);
                IEnumerator enumerator = rSysComments.GetEnumerator();
                enumerator.MoveNext();
                DataRow r = (DataRow)enumerator.Current;
                sb.AppendLine("if OBJECTPROPERTY(object_id('" + r[0] + "'), 'IsProcedure') = 1");
                sb.AppendLine("\tdrop procedure " + r[0]);
                sb.AppendLine("go");
                sb.Append(r["text"].ToString());
                while (enumerator.MoveNext()) {
                    r = (DataRow)enumerator.Current;
                    sb.Append(r["text"].ToString());
                }

                sb.AppendLine();
            }
	        return sb.ToString();
	    }

		public static void scriptSp(DataAccess conn, string filtro, string cartella) {
			string query = "select object_name(id), id, text from syscomments "
				+ "where objectproperty(id,'isprocedure')=1 and objectproperty(id,'IsMSShipped')=0";
			if ((filtro != null)&&(filtro!="")) {
				query += " and object_name(id) like '"+filtro+"'";
			}
			DataTable t = conn.SQLRunner(query);
			ArrayList list = new ArrayList();
			foreach (DataRow r in t.Rows) {
				if (!list.Contains(r["id"])) {
					list.Add(r["id"]);
				}
			}
			foreach (int id in list) {
				DataRow[] rSysComments = t.Select("id="+id);
				IEnumerator enumerator = rSysComments.GetEnumerator();
				enumerator.MoveNext();
				DataRow r = (DataRow)enumerator.Current;
				TextWriter tw = new StreamWriter(Path.Combine(cartella, r[0]+".sql"), false, Encoding.Default);
				tw.WriteLine("if OBJECTPROPERTY(object_id('"+r[0]+"'), 'IsProcedure') = 1");
				tw.WriteLine("\tdrop procedure "+r[0]);
				tw.WriteLine("go");
				tw.Write(r["text"]);
				while (enumerator.MoveNext()) {
					r = (DataRow)enumerator.Current;
					tw.Write(r["text"]);
				}
				tw.Close();
			}
        }

        #region Script Specifici
        public static bool generaSortingKind(DataAccess Conn, string SqlOutputFile, string filter) {
            CQueryHelper QHC = new CQueryHelper();
            QueryHelper QHS = Conn.GetQueryHelper();
            DataTable TSorKind = Conn.CreateTableByName( "sortingkind", "*");

            Conn.RUN_SELECT_INTO_TABLE(TSorKind, null, filter, null, true);
            if ((TSorKind == null) || (TSorKind.Rows.Count == 0)) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Nessuna riga trovata con il filtro " + filter);
                return false;
            }
            StreamWriter writer = new StreamWriter(SqlOutputFile, false, System.Text.Encoding.Default);

            //Ciclo su sortingkind
            foreach (DataRow SorKind in TSorKind.Rows) {
                StringBuilder sql = new StringBuilder();
                string filterkind = QHS.CmpEq("idsorkind", SorKind["idsorkind"]);
                //
                DataTable TSorApp = Conn.RUN_SELECT("sortingapplicability", "*", null, filterkind, null, false);
                DataTable TSorLev = Conn.RUN_SELECT("sortinglevel", "*", null, filterkind, null, false);
                DataTable TSor = Conn.RUN_SELECT("sorting", "*", null, filterkind, null, false);     
            
                //Mette la riga in sortingkind
                sql.Append("DECLARE @idsorkind int\r\n");
                sql.Append("SET @idsorkind = isnull((SELECT MAX(idsorkind) from sortingkind),0)+1 \r\n");
                
                string insert = "INSERT INTO  sortingkind (";
                bool first = true;
                foreach (DataColumn C in TSorKind.Columns) {
                    if (!first) insert += ",";
                    first = false;
                    insert += C.ColumnName;
                }
                insert += ") VALUES (";
                first=true;
                string values = "";

                foreach (DataColumn C in TSorKind.Columns) {
                    string colName = C.ColumnName;
                    if (!first) values += ",";
                    first=false;
                    if (colName == "idsorkind") {
                        values += "@idsorkind";
                    }
                    else {
                        values += QueryCreator.GetPrintable(QHS.quote(SorKind[colName]));
                    }
                }
                values += ")\r\n";
                sql.Append(insert + values);

                //Mette le righe in sortingapplicability
                if (TSorApp.Rows.Count > 0) {
                    sql.AppendLine();
                    sql.AppendLine("-- GENERAZIONE DATI PER sortingapplicability");
                }
                insert = "INSERT INTO  sortingapplicability (";
                first = true;
                foreach (DataColumn C in TSorApp.Columns) {
                    if (!first) insert += ",";
                    first = false;
                    insert += C.ColumnName;
                }
                insert += ") VALUES (";
                foreach (DataRow RSA in TSorApp.Rows) {
                    first = true;
                    values = "";
                    foreach (DataColumn C in TSorApp.Columns) {
                        string colName = C.ColumnName;
                        if (!first) values += ",";
                        first = false;
                        if (colName == "idsorkind") {
                            values += "@idsorkind";
                        }
                        else {
                            values += QueryCreator.GetPrintable(QHS.quote(RSA[colName]));
                        }
                    }
                    values += ")\r\n";
                    sql.Append(insert + values);

                }

                //Mette le righe in sortinglevel
                if (TSorLev.Rows.Count > 0) {
                    sql.AppendLine();
                    sql.AppendLine("-- GENERAZIONE DATI PER sortinglevel");
                }
                insert = "INSERT INTO  sortinglevel (";
                first = true;
                foreach (DataColumn C in TSorLev.Columns) {
                    if (!first) insert += ",";
                    first = false;
                    insert += C.ColumnName;
                }
                insert += ") VALUES (";

                foreach (DataRow RSL in TSorLev.Rows) {
                    first = true;
                    values = "";
                    foreach (DataColumn C in TSorLev.Columns) {
                        string colName = C.ColumnName;
                        if (!first) values += ",";
                        first = false;
                        if (colName == "idsorkind") {
                            values += "@idsorkind";
                        }
                        else {
                            values += QueryCreator.GetPrintable(QHS.quote(RSL[colName]));
                        }
                    }
                    values += ")\r\n";
                    sql.Append(insert + values);

                }
                writer.WriteLine(sql);
                writer.WriteLine("GO");
                writer.Flush();

                //Mette le righe in sorting
                if (TSor.Rows.Count > 0) {
                    sql.AppendLine();
                    sql.AppendLine("-- GENERAZIONE DATI PER sorting");
                }
                sql = new StringBuilder();
                sql.Append("DECLARE @idsorkind int\r\n");
                sql.Append("SELECT  @idsorkind = idsorkind from sortingkind where "+
                    QHS.CmpEq("codesorkind",SorKind["codesorkind"])
                    +" \r\n");


                sql.Append("DECLARE @idsor int\r\n");
                sql.Append("SET @idsor = isnull((SELECT MAX(idsor) from sorting),0) \r\n");
                Hashtable ParID = new Hashtable();
                insert = "INSERT INTO  sorting (";
                first = true;
                foreach (DataColumn C in TSor.Columns) {
                    if (!first) insert += ",";
                    first = false;
                    insert += C.ColumnName;
                }
                insert += ") VALUES (";
                int NUM = 0;
                foreach (DataRow Sor in TSor.Select(null, "nlevel asc")) {
                    NUM++;
                    int nlevel = Convert.ToInt32(Sor["nlevel"]);
                    first = true;
                    values = "";
                    foreach (DataColumn C in TSor.Columns) {
                        string colName = C.ColumnName;
                        if (!first) values += ",";
                        first = false;
                        if (colName == "idsorkind") {
                            values += "@idsorkind";
                            continue;
                        }
                        if (colName == "idsor") {
                            values += "@idsor+" + NUM.ToString();
                            ParID[Sor["idsor"].ToString()] = NUM;
                            continue;
                        }
                        if (colName == "paridsor") {
                            if (Sor["paridsor"] == DBNull.Value) {
                                values += "null";
                            }
                            else {
                                if (ParID[Sor["paridsor"].ToString()]==null){
                                    MetaFactory.factory.getSingleton<IMessageShower>().Show("Riga parent di " + Sor["idsor"].ToString() +
                                        " non trovata in sorting.");
                                    writer.Close();
                                    return false;
                                }
                                else {
                                    values += "@idsor+" + ParID[Sor["paridsor"].ToString()].ToString();
                                }
                            }
                            continue;
                        }
                        values += QueryCreator.GetPrintable(QHS.quote(Sor[colName]));
                        
                    }
                    values += ")\r\n";
                    sql.Append(insert + values);

                }
                if (sql.Length != 0) {
                    writer.WriteLine(sql);
                    writer.WriteLine("GO");
                    writer.Flush();
                }


            }
 
            writer.Write("-- FINE GENERAZIONE SCRIPT --\r\n\r\n");
            writer.WriteLine("GO");
            writer.Close();

            return true;
        }


        public static bool generaTaxRateCity(DataAccess Conn, string SQLOutputFile,
            string filter) {
            CQueryHelper QHC = new CQueryHelper();
            QueryHelper QHS = Conn.GetQueryHelper();

            DataTable tStart = Conn.CreateTableByName("taxratecitystart", "*");
            DataTable tBracket = Conn.CreateTableByName( "taxratecitybracket", "*");

            Conn.RUN_SELECT_INTO_TABLE(tStart, null, filter, null, true);
            if ((tStart == null) || (tStart.Rows.Count == 0)) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Nessuna riga trovata con il filtro " + filter);
                return false;
            }

            foreach (DataRow r in tStart.Rows) {
                string filterSon = QHS.MCmp(r, new string[] { "idcity", "taxcode", "idtaxratecitystart" });
                Conn.RUN_SELECT_INTO_TABLE( tBracket, null, filterSon, null, true);
            }


            DataSet DS = new DataSet();
            DS.Tables.Add(tStart);
            DS.Tables.Add(tBracket);

            StreamWriter writer = new StreamWriter(SQLOutputFile, false, System.Text.Encoding.Default);

            DataTable tTax = Conn.CreateTableByName("tax", "taxcode,taxref");

            string DistVal = QHC.DistinctVal(DS.Tables["taxratecitystart"].Select(), "taxcode");
            string filterTax = QHC.FieldInList("taxcode", DistVal);

            Conn.RUN_SELECT_INTO_TABLE(tTax, "taxcode", filterTax, null, true);

            Hashtable hTax = new Hashtable();
            StringBuilder dichiarazione = new StringBuilder();
            
            foreach (DataRow r in tTax.Rows) {
                string variabile = "@taxcode" + r["taxcode"].ToString();
                dichiarazione.Append("DECLARE " + variabile + " int\r\n");
                dichiarazione.Append("SELECT " + variabile + " = taxcode FROM tax WHERE "
                    + QHS.CmpEq("taxref", r["taxref"]) + "\r\n");
                hTax[r["taxcode"]] = variabile;
            }

            writer.WriteLine("--[DBO]--");
            foreach (DataTable T in DS.Tables) {

                writer.WriteLine(dichiarazione);

                string dbo = "[dbo].";
                string tablename = T.TableName;


                //--- è indipendente dalla riga  ----
                string insert = "INSERT INTO " + dbo + "[" + tablename + "] (";
                foreach (DataColumn C in T.Columns) {
                    string colName = C.ColumnName;
                    insert += colName + ",";
                }
                insert = insert.Remove(insert.Length - 1, 1);
                insert += ") VALUES \r\n";
                // ----------------------------------

                writer.Write("\r\n-- GENERAZIONE DATI PER " + tablename + " --\r\n");

                int i = 1;
                StringBuilder s = new StringBuilder();
                string values = "";
                foreach (DataRow row in T.Rows) {
                    //string cmpkey = "";
                    //if (T.TableName == "taxratecitystart")
                    //    cmpkey = QHS.AppAnd(QHS.CmpEq("idcity", row["idcity"]),
                    //                        QHS.CmpEq("idtaxratecitystart", row["idtaxratecitystart"]),
                    //                        QHS.CmpEq("taxcode", QHS.Field(hTax[row["taxcode"]].ToString())));
                    //else
                    //    cmpkey = QHS.AppAnd(QHS.CmpEq("idcity", row["idcity"]),
                    //                        QHS.CmpEq("idtaxratecitystart", row["idtaxratecitystart"]),
                    //                        QHS.CmpEq("nbracket", row["nbracket"]),
                    //                        QHS.CmpEq("taxcode", QHS.Field(hTax[row["taxcode"]].ToString())));


                    //string ifnotexists = ""; // "IF NOT EXISTS(SELECT * FROM " + tablename + " WHERE " +cmpkey + " ) ";                 

                   if (values == "") {
                        values = "(";
                    }
                   else {
                        values += ",\r\n(";
                    }
                    string piece = "";
                    foreach (DataColumn C in T.Columns) {
                        string colName = C.ColumnName;
                        if (colName == "taxcode") {
                            piece += hTax[row["taxcode"]];
                        }
                        else {
                            piece += QueryCreator.GetPrintable(QueryCreator.quotedstrvalue(row[colName], true));
                        }
                        piece += ",";
                    }
                    piece = piece.Remove(piece.Length - 1, 1);
                    values += piece+ ")";
                    
                    
                    if (i % 30 == 0) {
                        s.Append( insert + values);
                        writer.WriteLine(s);
                        writer.WriteLine("GO");
                        writer.WriteLine(dichiarazione);
                        writer.Flush();
                        s = new StringBuilder();
                        i = 1;
                        values = "";
                    }
                    i++;
                }
                if (values != "") {
                    s.Append(insert + values);
                }               
                if (s.Length != 0) {
                    writer.WriteLine(s);
                    writer.WriteLine("GO");
                    writer.Flush();
                }
            }

            writer.Write("-- FINE GENERAZIONE SCRIPT --\r\n\r\n");
            writer.WriteLine("GO");
            writer.Close();
            return true;
        }

        public static bool generaTaxRateRegion(DataAccess Conn, string SQLOutputFile,
            string filter) {
            CQueryHelper QHC = new CQueryHelper();
            QueryHelper QHS = Conn.GetQueryHelper();

            DataTable tStart = Conn.CreateTableByName("taxrateregionstart", "*");
            DataTable tBracket = Conn.CreateTableByName("taxrateregionbracket", "*");

            Conn.RUN_SELECT_INTO_TABLE(tStart, null, filter, null, true);
            if ((tStart == null) || (tStart.Rows.Count == 0)) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Nessuna riga trovata con il filtro " + filter);
                return false;
            }

            foreach (DataRow r in tStart.Rows) {
                string filterSon = QHS.MCmp(r, new string[] { "idregion", "taxcode", "idtaxrateregionstart" });
                Conn.RUN_SELECT_INTO_TABLE(tBracket, null, filterSon, null, true);
            }


            DataSet DS = new DataSet();
            DS.Tables.Add(tStart);
            DS.Tables.Add(tBracket);

            StreamWriter writer = new StreamWriter(SQLOutputFile, false, System.Text.Encoding.Default);

            DataTable tTax = Conn.CreateTableByName("tax", "taxcode,taxref");

            string DistVal = QHC.DistinctVal(DS.Tables["taxrateregionstart"].Select(), "taxcode");
            string filterTax = QHC.FieldInList("taxcode", DistVal);

            Conn.RUN_SELECT_INTO_TABLE(tTax, "taxcode", filterTax, null, true);

            Hashtable hTax = new Hashtable();
            StringBuilder dichiarazione = new StringBuilder();

            foreach (DataRow r in tTax.Rows) {
                string variabile = "@taxcode" + r["taxcode"].ToString();
                dichiarazione.Append("DECLARE " + variabile + " int\r\n");
                dichiarazione.Append("SELECT " + variabile + " = taxcode FROM tax WHERE "
                    + QHS.CmpEq("taxref", r["taxref"]) + "\r\n");
                hTax[r["taxcode"]] = variabile;
            }

            writer.WriteLine("--[DBO]--");

            foreach (DataTable T in DS.Tables) {

                writer.WriteLine(dichiarazione);

                string dbo = "[dbo].";
                string tablename = T.TableName;


                //--- è indipendente dalla riga  ----
                string insert = "INSERT INTO " + dbo + "[" + tablename + "] (";
                foreach (DataColumn C in T.Columns) {
                    string colName = C.ColumnName;
                    insert += colName + ",";
                }
                insert = insert.Remove(insert.Length - 1, 1);
                insert += ") VALUES (";
                // ----------------------------------

                writer.Write("\r\n-- GENERAZIONE DATI PER " + tablename + " --\r\n");

                int i = 1;
                StringBuilder s = new StringBuilder();
                foreach (DataRow row in T.Rows) {
                    string cmpkey = "";
                    if (T.TableName == "taxrateregionstart")
                        cmpkey = QHS.AppAnd(QHS.CmpEq("idregion", row["idregion"]),
                                            QHS.CmpEq("idtaxrateregionstart", row["idtaxrateregionstart"]),
                                            QHS.CmpEq("taxcode", QHS.Field(hTax[row["taxcode"]].ToString())));
                    else
                        cmpkey = QHS.AppAnd(QHS.CmpEq("idregion", row["idregion"]),
                                            QHS.CmpEq("idtaxrateregionstart", row["idtaxrateregionstart"]),
                                            QHS.CmpEq("nbracket", row["nbracket"]),
                                            QHS.CmpEq("taxcode", QHS.Field(hTax[row["taxcode"]].ToString())));


                    string ifnotexists = "IF NOT EXISTS(SELECT * FROM " + tablename + " WHERE " + cmpkey + " ) ";

                    string values = "";

                    foreach (DataColumn C in T.Columns) {
                        string colName = C.ColumnName;
                        if (colName == "taxcode") {
                            values += hTax[row["taxcode"]];
                        }
                        else {
                            values += QueryCreator.GetPrintable(QueryCreator.quotedstrvalue(row[colName], true));
                        }
                        values += ",";
                    }
                    values = values.Remove(values.Length - 1, 1);
                    values += ")\r\n";

                    s.Append(ifnotexists + insert + values);

                    if (i % 30 == 0) {
                        writer.WriteLine(s);
                        writer.WriteLine("GO");
                        writer.WriteLine(dichiarazione);
                        writer.Flush();
                        s = new StringBuilder();
                        i = 1;
                    }
                    i++;
                }

                if (s.Length != 0) {
                    writer.WriteLine(s);
                    writer.WriteLine("GO");
                    writer.Flush();
                }
            }

            writer.Write("-- FINE GENERAZIONE SCRIPT --\r\n\r\n");
            writer.WriteLine("GO");
            writer.Close();
            return true;
        }




        public static bool generaInventorytree(DataAccess Conn, string SqlOutputFile, string filter) {
            CQueryHelper QHC = new CQueryHelper();
            QueryHelper QHS = Conn.GetQueryHelper();
            DataTable TInvTree = DataAccess.CreateTableByName(Conn, "inventorytree", "*");
            DataTable TInvSorLev = DataAccess.CreateTableByName(Conn, "inventorysortinglevel", "*");

            DataAccess.RUN_SELECT_INTO_TABLE(Conn, TInvTree, null, filter, null, true);
            if ((TInvTree == null) || (TInvTree.Rows.Count == 0)) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Nessuna riga trovata con il filtro " + filter);
                return false;
            }
            StreamWriter writer = new StreamWriter(SqlOutputFile, false, System.Text.Encoding.Default);
            StringBuilder sql = new StringBuilder();
            writer.WriteLine("--[DBO]--");

            if (filter == null || filter == "") {
                DataAccess.RUN_SELECT_INTO_TABLE(Conn, TInvSorLev, null, null, null, true);
            }

            //Ciclo su inventorysortinglevel
            if (TInvSorLev.Rows.Count > 0) {
                sql.AppendLine();
                sql.AppendLine("-- GENERAZIONE DATI PER inventorysortinglevel");
            }
            sql = new StringBuilder();
            string insert = "INSERT INTO  inventorysortinglevel (";
            bool first = true;
            foreach (DataColumn C in TInvSorLev.Columns) {
                if (!first) insert += ",";
                first = false;
                insert += C.ColumnName;
            }
            insert += ") VALUES (";
            foreach (DataRow SorLev in TInvSorLev.Select(null, "nlevel asc")) {
                int nlevel = Convert.ToInt32(SorLev["nlevel"]);
                first = true;
                string values = "";
                foreach (DataColumn C in TInvSorLev.Columns) {
                    string colName = C.ColumnName;
                    if (!first) values += ",";
                    first = false;
                    values += QueryCreator.GetPrintable(QHS.quote(SorLev[colName]));

                }
                values += ")\r\n";
                sql.Append(insert + values);

            }
            if (sql.Length != 0) {
                writer.WriteLine(sql);
                writer.WriteLine("GO");
                writer.Flush();
            }

            sql = new StringBuilder();
            //Ciclo su inv.tree
            if (TInvTree.Rows.Count > 0) {
                sql.AppendLine();
                sql.AppendLine("-- GENERAZIONE DATI PER inventorytree");
            }

            insert = "INSERT INTO  inventorytree (";
            first = true;
            foreach (DataColumn C in TInvTree.Columns) {
                if (!first) insert += ",";
                first = false;
                insert += C.ColumnName;
            }
            insert += ") VALUES (";
            foreach (DataRow Sor in TInvTree.Select(null, "nlevel asc")) {
                int nlevel = Convert.ToInt32(Sor["nlevel"]);
                first = true;
                string values = "";
                foreach (DataColumn C in TInvTree.Columns) {
                    string colName = C.ColumnName;
                    if (!first) values += ",";
                    first = false;
                    values += QueryCreator.GetPrintable(QHS.quote(Sor[colName]));

                }
                values += ")\r\n";
                sql.Append(insert + values);

            }
            if (sql.Length != 0) {
                writer.WriteLine(sql);
                writer.WriteLine("GO");
                writer.Flush();
            }



            writer.Write("-- FINE GENERAZIONE SCRIPT --\r\n\r\n");
            writer.WriteLine("GO");
            writer.Close();

            return true;
        }

        public static bool generaABICAB(DataAccess Conn, string SqlOutputFile, string filter) {
            CQueryHelper QHC = new CQueryHelper();
            QueryHelper QHS = Conn.GetQueryHelper();
            DataTable TABI = DataAccess.CreateTableByName(Conn, "bank", "*");
            DataTable TCAB = DataAccess.CreateTableByName(Conn, "cab", "*");
            TABI.CaseSensitive = false;
            TCAB.CaseSensitive = false;

            DataAccess.RUN_SELECT_INTO_TABLE(Conn, TABI, null, filter, null, true);
            if ((TABI == null) || (TABI.Rows.Count == 0)) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Nessuna banca trovata con il filtro " + filter);
                return false;
            }
            StreamWriter writer = new StreamWriter(SqlOutputFile, false, System.Text.Encoding.Default);
            StringBuilder sql = new StringBuilder();
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, TCAB, null, filter, null, true);
            writer.WriteLine("--[DBO]--");

            //Ciclo su bank
            if (TABI.Rows.Count > 0) {
                sql.AppendLine();
                sql.AppendLine("-- GENERAZIONE DATI PER BANK");
            }
            sql = new StringBuilder();
            int N = 0;
            foreach (DataRow RB in TABI.Select()) {
                string insert = "IF NOT EXISTS(SELECT * FROM BANK WHERE " +
//                    QHS.AppOr(QHS.CmpEq("idbank", RB["idbank"]), QHS.CmpEq("description", RB["description"])) + ") " +
                    QHS.CmpEq("idbank", RB["idbank"]) +" ) "+
                    "INSERT INTO  BANK (";
                bool first = true;
                foreach (DataColumn C in TABI.Columns) {
                    if (!first) insert += ",";
                    first = false;
                    insert += C.ColumnName;
                }
                insert += ") VALUES (";

                first = true;
                string values = "";
                foreach (DataColumn C in TABI.Columns) {
                    string colName = C.ColumnName;
                    if (!first) values += ",";
                    first = false;
                    values += QueryCreator.GetPrintable(QHS.quote(RB[colName]));

                }
                values += ")";
                string update = " ELSE UPDATE BANK SET flagusable='"+RB["flagusable"].ToString()+"' WHERE " + QHS.CmpEq("idbank", RB["idbank"]);

                sql.Append(insert + values + update + "\r\n");
                N++;
                if (N == 30) {
                    N = 0;
                    writer.WriteLine(sql);
                    writer.WriteLine("GO");
                    writer.Flush();
                    sql = new StringBuilder();
                }

            }
            if (sql.Length != 0) {
                writer.WriteLine(sql);
                writer.WriteLine("GO");
                writer.Flush();
            }


            sql = new StringBuilder();
            //Ciclo su inv.tree
            if (TCAB.Rows.Count > 0) {
                sql.AppendLine();
                sql.AppendLine("-- GENERAZIONE DATI PER cab");
            }


            N = 0;
            foreach (DataRow RC in TCAB.Select()) {
                string insert = "IF NOT EXISTS(SELECT * FROM CAB WHERE " +
                        QHS.AppAnd(QHS.CmpEq("idbank", RC["idbank"]), QHS.CmpEq("idcab", RC["idcab"])) + ") " +
                            "INSERT INTO  CAB (";
                bool first = true;
                foreach (DataColumn C in TCAB.Columns) {
                    if (!first) insert += ",";
                    first = false;
                    insert += C.ColumnName;
                }
                insert += ") VALUES (";


                first = true;
                string values = "";
                foreach (DataColumn C in TCAB.Columns) {
                    string colName = C.ColumnName;
                    if (!first) values += ",";
                    first = false;
                    values += QueryCreator.GetPrintable(QHS.quote(RC[colName]));
                }
                values += ")";
                string update = " ELSE UPDATE CAB SET flagusable='"+RC["flagusable"].ToString()+"' WHERE " + 
                        QHS.AppAnd(QHS.CmpEq("idbank", RC["idbank"]), QHS.CmpEq("idcab", RC["idcab"]));

                sql.Append(insert + values + update + "\r\n");

                N++;
                if (N == 30) {
                    N = 0;
                    writer.WriteLine(sql);
                    writer.WriteLine("GO");
                    writer.Flush();
                    sql = new StringBuilder();
                }

            }
            if (sql.Length != 0) {
                writer.WriteLine(sql);
                writer.WriteLine("GO");
                writer.Flush();
            }

            writer.Write("-- FINE GENERAZIONE SCRIPT --\r\n\r\n");
            writer.WriteLine("GO");
            writer.Close();

            return true;
        }

        public static bool generaCurrency(DataAccess Conn, string SQLOutputFile, string filter) {
            string dbo = "[DBO].";
            CQueryHelper QHC = new CQueryHelper();
            QueryHelper QHS = Conn.GetQueryHelper();

            DataTable tcurrency = DataAccess.CreateTableByName(Conn, "currency", "*");
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, tcurrency, null, filter, null, true);
            if ((tcurrency == null) || (tcurrency.Rows.Count == 0)) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Nessuna riga trovata con il filtro " + filter);
                return false;
            }
            DataSet DS = new DataSet();
            DS.Tables.Add(tcurrency);
            StreamWriter writer = new StreamWriter(SQLOutputFile, false, System.Text.Encoding.Default);
            StringBuilder curr_block = new StringBuilder();
            writer.WriteLine("--[DBO]--");

            string variable = "@idcurrency"; // +r["idcurrency"].ToString();
            curr_block.Append("DECLARE " + variable + " int\r\n");

            foreach (DataRow r in tcurrency.Rows) {
                curr_block.Append("if not exists (select * from currency where " +
                                QHS.CmpEq("codecurrency", r["codecurrency"]) + ") " +
                                " and not exists(  select * from currency where " +
                                QHS.CmpEq("description", r["description"]) + ") " +

                        "\r\nbegin \r\n" +
                            " SET " + variable + " = ISNULL((SELECT MAX(idcurrency) from currency),0)+1 \r\n");

                string insert = " INSERT INTO " + dbo + "[" + tcurrency.TableName + "] (";
                string values = "";
                foreach (DataColumn C in tcurrency.Columns) {
                    string colName = C.ColumnName;
                    insert += colName + ",";
                }
                insert = insert.Remove(insert.Length - 1, 1);
                insert += ") VALUES (";
                foreach (DataColumn C in tcurrency.Columns) {
                    string colName = C.ColumnName;
                    if (colName == "idcurrency") {
                        values += variable;
                    }
                    else {
                        values += QueryCreator.GetPrintable(QueryCreator.quotedstrvalue(r[colName], true));
                    }
                    values += ",";
                }
                values = values.Remove(values.Length - 1, 1);
                values += ")\r\n";
                curr_block.Append(insert + values);
                curr_block.Append("end \r\n\r\n");

            }
            writer.Write("--Inserimento valori in CURRENCY\r\n");
            writer.Write(curr_block.ToString());

            writer.Write("-- FINE GENERAZIONE SCRIPT --\r\n\r\n");
            writer.WriteLine("GO");
            writer.Close();
            return true;

        }

        public static bool generaService(DataAccess Conn, string SQLOutputFile,
            string filter) {
            string dbo = "[DBO].";
            CQueryHelper QHC = new CQueryHelper();
            QueryHelper QHS = Conn.GetQueryHelper();

            DataTable tservice = DataAccess.CreateTableByName(Conn, "service", "*");
            DataTable ttax = DataAccess.CreateTableByName(Conn, "tax", "*");
            DataTable tservicetax = DataAccess.CreateTableByName(Conn, "servicetax", "*");

            DataAccess.RUN_SELECT_INTO_TABLE(Conn, tservice, null, filter, null, true);
            if ((tservice == null) || (tservice.Rows.Count == 0)) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Nessuna riga trovata con il filtro " + filter);
                return false;
            }

            foreach (DataRow r in tservice.Rows) {
                string filterSon = QHS.MCmp(r, new string[] { "idser" });
                DataAccess.RUN_SELECT_INTO_TABLE(Conn, tservicetax, null, filterSon, null, true);
            }

            foreach (DataRow r in tservicetax.Rows) {
                string filterSon = QHS.MCmp(r, new string[] { "taxcode" });
                DataAccess.RUN_SELECT_INTO_TABLE(Conn, ttax, null, filterSon, null, true);
            }



            DataSet DS = new DataSet();
            DS.Tables.Add(tservice);
            DS.Tables.Add(tservicetax);
            DS.Tables.Add(ttax);

            StreamWriter writer = new StreamWriter(SQLOutputFile, false, System.Text.Encoding.Default);
            writer.WriteLine("--[DBO]--");

            Hashtable hService = new Hashtable();
            Hashtable hTax = new Hashtable();
            StringBuilder tax_block = new StringBuilder();

            //Mette tutte le ritenute
            foreach (DataRow r in ttax.Rows) {
                string variable = "@taxcode" + r["taxcode"].ToString();
                tax_block.Append("DECLARE " + variable + " int\r\n");
                tax_block.Append("if exists (select * from tax where " + QHS.CmpEq("taxref", r["taxref"]) + ") " +
                        "\r\nbegin \r\n" +
                        " SELECT " + variable + " = taxcode from tax where " + QHS.CmpEq("taxref", r["taxref"]) + "\r\n" +
                        "end \r\n" +
                        "else \r\n" +
                        "begin \r\n" +
                        " SET " + variable + " = ISNULL((SELECT MAX(taxcode) from tax),0)+1 \r\n");

                string insert = " INSERT INTO " + dbo + "[" + ttax.TableName + "] (";
                string values = "";
                foreach (DataColumn C in ttax.Columns) {
                    string colName = C.ColumnName;
                    insert += colName + ",";
                }
                insert = insert.Remove(insert.Length - 1, 1);
                insert += ") VALUES (";
                foreach (DataColumn C in ttax.Columns) {
                    string colName = C.ColumnName;
                    if (colName == "taxcode") {
                        values += variable;
                    }
                    else {
                        values += QueryCreator.GetPrintable(QueryCreator.quotedstrvalue(r[colName], true));
                    }
                    values += ",";
                }
                values = values.Remove(values.Length - 1, 1);
                values += ")\r\n";
                tax_block.Append(insert + values);
                tax_block.Append("end \r\n\r\n");

                hTax[r["taxcode"]] = variable;
            }

            StringBuilder ser_block = new StringBuilder();
            //Mette tutte le prestazioni - DA FARE
            foreach (DataRow r in tservice.Rows) {
                string variabile = "@idser" + r["idser"].ToString();
                ser_block.Append("DECLARE " + variabile + " int\r\n");
                ser_block.Append("if exists (select * from service where " + QHS.CmpEq("codeser", r["codeser"]) + ") " +
                        "\r\nbegin \r\n" +
                        " SELECT " + variabile + " = idser from service where " + QHS.CmpEq("codeser", r["codeser"]) + "\r\n" +
                        "end \r\n" +
                        "else \r\n" +
                        "begin \r\n" +
                        " SET " + variabile + " = ISNULL((SELECT MAX(idser) from service),0)+1 \r\n");

                string insert = " INSERT INTO " + dbo + "[" + tservice.TableName + "] (";
                foreach (DataColumn C in tservice.Columns) {
                    string colName = C.ColumnName;
                    insert += colName + ",";
                }
                insert = insert.Remove(insert.Length - 1, 1);
                insert += ") VALUES (";
                string values = "";
                foreach (DataColumn C in tservice.Columns) {
                    string colName = C.ColumnName;
                    if (colName == "idser") {
                        values += variabile;
                    }
                    else {
                        values += QueryCreator.GetPrintable(QueryCreator.quotedstrvalue(r[colName], true));
                    }
                    values += ",";
                }
                values = values.Remove(values.Length - 1, 1);
                values += ")\r\n";
                ser_block.Append(insert + values);

                ser_block.Append("end \r\n\r\n");

                hService[r["idser"]] = variabile;
            }

            //Mette le associazioni tax - service
            StringBuilder sertax_block = new StringBuilder();

            //Codice che pulisce le associazioni attuali
            foreach (DataRow R in tservice.Select()) {
                sertax_block.Append("--Cancella associazioni di prestazione " + R["codeser"].ToString() + "\r\n");
                sertax_block.Append("DELETE from servicetax where " + QHS.CmpEq("idser", QHS.Field(hService[R["idser"]].ToString())) + "\r\n");
                sertax_block.Append("\r\n");


                foreach (DataRow RR in tservicetax.Select()) {
                    sertax_block.Append("delete from servicetax where "+
                        QHS.AppAnd(QHS.CmpEq("idser", QHS.Field(hService[RR["idser"]].ToString())),
                                        QHS.CmpEq("taxcode",QHS.Field(hTax[RR["taxcode"]].ToString())))+"\r\n");

                    string insert = "INSERT INTO " + dbo + "[" + tservicetax.TableName + "] (";
                    foreach (DataColumn C in tservicetax.Columns) {
                        string colName = C.ColumnName;
                        insert += colName + ",";
                    }
                    insert = insert.Remove(insert.Length - 1, 1);
                    insert += ") VALUES (";
                    string values = "";
                    foreach (DataColumn C in tservicetax.Columns) {
                        string colName = C.ColumnName;
                        if (colName == "idser") {
                            values += hService[RR["idser"]].ToString() + ",";
                            continue;
                        }
                        if (colName == "taxcode") {
                            values += hTax[RR["taxcode"]].ToString() + ",";
                            continue;
                        }
                        
                        values += QueryCreator.GetPrintable(QueryCreator.quotedstrvalue(RR[colName], true));                        
                        values += ",";
                    }
                    values = values.Remove(values.Length - 1, 1);
                    values += ")\r\n";
                    sertax_block.Append(insert + values+"\r\n");                
                
                }
            }


            writer.Write("--Inserimento valori in TAX\r\n");
            writer.Write(tax_block.ToString());
            writer.Write("--Inserimento valori in SERVICE\r\n");
            writer.Write(ser_block.ToString());
            writer.Write("--Inserimento valori in SERVICETAX\r\n");
            writer.Write(sertax_block.ToString());

            writer.Write("-- FINE GENERAZIONE SCRIPT --\r\n\r\n");
            writer.WriteLine("GO");
            writer.Close();
            return true;
        }

        public static bool generaSortingTranslation(DataAccess Conn, string SqlOutputFile, string filter) {
            //Il filtro in input basta che dia una qualsiasi riga della traduzione da installare
            CQueryHelper QHC = new CQueryHelper();
            QueryHelper QHS = Conn.GetQueryHelper();

            DataTable Sample = Conn.RUN_SELECT("sortingtranslation", "*", null, filter, null, false);
            if (Sample.Rows.Count==0){
                MetaFactory.factory.getSingleton<IMessageShower>().Show("La query non ha restituito alcuna riga");
                return false;
            }
            DataRow RSample=Sample.Rows[0];            

            object idsorkindmaster;
            object idsorkindchild;
            object codesorkindmaster;
            object codesorkindchild;

 
            idsorkindmaster= Conn.DO_READ_VALUE("sorting",QHS.CmpEq("idsor",RSample["idsortingmaster"]),"idsorkind");
            idsorkindchild = Conn.DO_READ_VALUE("sorting", QHS.CmpEq("idsor", RSample["idsortingchild"]), "idsorkind");

            codesorkindmaster = Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("idsorkind", idsorkindmaster), "codesorkind");
            codesorkindchild = Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("idsorkind", idsorkindchild), "codesorkind");

            DataTable All = Conn.SQLRunner(
                " SELECT * from sortingtranslation S " +
                " join sorting SM on S.idsortingmaster=SM.idsor " +
                " join sorting SC on S.idsortingchild=SC.idsor " +
                " WHERE " +
                QHS.AppAnd(QHS.CmpEq("SM.idsorkind", idsorkindmaster), QHS.CmpEq("SC.idsorkind", idsorkindchild))
                );

            StreamWriter writer = new StreamWriter(SqlOutputFile, false, System.Text.Encoding.Default);
            StringBuilder sql = new StringBuilder();

            sql.Append("DECLARE @idsormaster int \r\n");
            sql.Append("DECLARE @idsorchild int \r\n");

            object sortcodemaster;
            object sortcodechild;
            object numerator;
            object denominator;
            DataTable Sorting = Conn.RUN_SELECT("sorting", "*", null,
                QHS.AppOr(QHS.CmpEq("idsorkind", idsorkindchild), QHS.CmpEq("idsorkind", idsorkindmaster)), null, false);

            foreach (DataRow R in All.Rows) {
                   sortcodemaster= Sorting.Select(QHC.CmpEq("idsor",R["idsortingmaster"]))[0]["sortcode"];
                   sortcodechild = Sorting.Select(QHC.CmpEq("idsor", R["idsortingchild"]))[0]["sortcode"];
                   numerator = R["numerator"];
                   denominator = R["denominator"];
                   sql.Append("select @idsormaster= S.idsor from sorting S\r\n " +
                              " join sortingkind SK on S.idsorkind=SK.idsorkind \r\n" +
                              " where " + QHS.AppAnd(
                                    QHS.CmpEq("SK.codesorkind", codesorkindmaster),
                                    QHS.CmpEq("S.sortcode", sortcodemaster)
                                ) + "\r\n");
                   sql.Append("select @idsorchild= S.idsor from sorting S\r\n " +
                              " join sortingkind SK on S.idsorkind=SK.idsorkind \r\n" +
                              " where " + QHS.AppAnd(
                                    QHS.CmpEq("SK.codesorkind", codesorkindchild),
                                    QHS.CmpEq("S.sortcode", sortcodechild)
                            ) + "\r\n");
                    sql.Append("insert into sortingtranslation (idsortingchild,idsortingmaster,numerator,denominator,"+
                                    "percentage,flagnodate,ct,cu,lt,lu) VALUES(\r\n"+
                                    " @idsorchild, @idsormaster, "+numerator + ","+ denominator+
                                    ", NULL,NULL, getdate(),'ASSISTENZA',"+
                                    " getdate(),'ASSISTENZA' " + ") \r\n"); 
                
            }
            writer.Write("--Inserimento valori in sortingtranslation \r\n");
            writer.Write(sql.ToString());

            writer.Write("-- FINE GENERAZIONE SCRIPT --\r\n\r\n");
            writer.WriteLine("GO");
            writer.Close();

            return true;
        }

        public static bool generaBilancio(DataAccess Conn, string SQLOutputFile) {
            string dbo = "";
            CQueryHelper QHC = new CQueryHelper();
            QueryHelper QHS = Conn.GetQueryHelper();
            int esercizio = Convert.ToInt32(Conn.GetSys("esercizio"));
            string filtereserc= QHS.CmpEq("ayear",esercizio);
            DataTable tfin = DataAccess.RUN_SELECT(Conn, "fin", "*", "nlevel asc, paridfin asc", filtereserc, false);
            DataTable tfinlast = DataAccess.RUN_SELECT(Conn, "finlast", "*", null,
                "(idfin in (select idfin from fin where " + filtereserc + "))", false);

            StreamWriter writer = new StreamWriter(SQLOutputFile, false, System.Text.Encoding.Default);
            StringBuilder fin_block = new StringBuilder();
            fin_block.Append("CREATE     PROCEDURE create_fin AS BEGIN\r\n");


            fin_block.Append("DECLARE @flag int\r\n");
            fin_block.Append("SELECT @flag = flag from accountingyear where " + QHS.CmpEq("ayear", esercizio-1) + "\r\n");
            fin_block.Append("if ((isnull(@flag,0)&0x0F) <> 0x02) begin \r\n");
            fin_block.Append("    print 'Fase di chiusura non corretta'\r\n");
            fin_block.Append("    return\r\n");
            fin_block.Append(" END\r\n");


            fin_block.Append("declare @nomeutente varchar(100)\r\n");
            fin_block.Append("set @nomeutente= user\r\n");
            fin_block.Append("exec enable_disable_triggers @nomeutente,'D'\r\n");


            fin_block.Append("--Cancellazioni righe relative a bilancio " + esercizio.ToString() + "\r\n");
            fin_block.Append("delete from finlookup where newidfin in (select idfin from fin where "
                                + filtereserc + ")\r\n");
            fin_block.Append("delete from finlink where idchild in (select idfin from fin where "
                    + filtereserc + ")\r\n");
            fin_block.Append("delete from finlast where idfin in (select idfin from fin where "
                                + filtereserc + ")\r\n");

            fin_block.Append("delete from fin where "+ filtereserc + "\r\n");
            //fin_block.Append("go\r\n");
            Hashtable finlookup = new Hashtable(); //associazione old idfin originario - nuovo idfin
            fin_block.Append("declare @idfin int\r\n");
            fin_block.Append("select @idfin= max(idfin) from fin\r\n");
            fin_block.Append("set @idfin= isnull(@idfin,0)\r\n");

            int idfin = 0;
            fin_block.Append("--- inserimenti in fin\r\n");
            foreach (DataRow R in tfin.Select(null, "nlevel,paridfin")) {
                idfin = idfin + 1;
                finlookup[R["idfin"].ToString()] = idfin;
                string idfin_value = "@idfin+" + idfin.ToString();

                object paridfin=DBNull.Value;
                string paridfin_value = "null";
                if (R["paridfin"] != DBNull.Value) {
                    paridfin = finlookup[R["paridfin"].ToString()];
                    paridfin_value = "@idfin+" + paridfin.ToString();
                }

                string insert = " INSERT INTO " + dbo + "[" + tfin.TableName + "] (";

                foreach (DataColumn C in tfin.Columns) {
                    string colName = C.ColumnName;
                    insert += colName + ",";
                }

                insert = insert.Remove(insert.Length - 1, 1);
                insert += ") VALUES (";
                string values = "";
                foreach (DataColumn C in tfin.Columns) {
                    string colName = C.ColumnName;
                    if (colName == "idfin") {
                        values += idfin_value+",";
                        continue;
                    }
                    if (colName == "paridfin") {
                        values += paridfin_value + ",";
                        continue;
                    }

                    values += QueryCreator.GetPrintable(QueryCreator.quotedstrvalue(R[colName], true));
                    values += ",";
                }
                values = values.Remove(values.Length - 1, 1);
                values += ")\r\n";
                fin_block.Append(insert + values);
            }
            fin_block.Append("--- inserimenti in finlast\r\n");
            foreach (DataRow r  in tfinlast.Select()) {
                string idfin_value = "@idfin+" + finlookup[r["idfin"].ToString()];
                string insert = " INSERT INTO " + dbo + "[" + tfinlast.TableName + "] (";

                foreach (DataColumn C in tfinlast.Columns) {
                    string colName = C.ColumnName;
                    insert += colName + ",";
                }

                insert = insert.Remove(insert.Length - 1, 1);
                insert += ") VALUES (";
                string values = "";
                foreach (DataColumn C in tfinlast.Columns) {
                    string colName = C.ColumnName;
                    if (colName == "idfin") {
                        values += idfin_value + ",";
                        continue;
                    }
                    if (colName == "idman") {
                        values += "null,";
                        continue;
                    }

                    values += QueryCreator.GetPrintable(QueryCreator.quotedstrvalue(r[colName], true));
                    values += ",";
                }
                values = values.Remove(values.Length - 1, 1);
                values += ")\r\n";
                fin_block.Append(insert + values);


            }


            fin_block.Append("-- riempimento finlookup\r\n");

            fin_block.Append(
                "insert into finlookup (oldidfin,newidfin,lt,lu,ct,cu)  \r\n" +
                " select f1.idfin,f2.idfin,getdate(),'script',getdate(),'script' \r\n" +
                "  from fin f1 join fin f2 on \r\n" +
                "   f2.codefin=f1.codefin and \r\n" +
                "   f2.ayear=f1.ayear+1 and \r\n" +
                "   (f2.flag & 1) = (f1.flag & 1) \r\n" +
                " where " + QHS.CmpEq("f1.ayear", esercizio - 1) + "\r\n");


            fin_block.Append("exec enable_disable_triggers @nomeutente,'E'\r\n");
                    
            fin_block.Append("-- ricalcolo di finlink e totalizzatori vari (non fa male)\r\n");
            fin_block.Append("exec rebuild_all " + esercizio.ToString() + "\r\n");

            fin_block.Append("END\r\n");
            fin_block.Append("GO\r\n");
           

            fin_block.Append("exec create_fin\r\n");
            fin_block.Append("go\r\n");
            fin_block.Append("drop procedure create_fin\r\n");
            fin_block.Append("GO\r\n");



            writer.Write(fin_block.ToString());
            writer.Close();
            return true;
        }

        public static bool generaClassificazioniBilancio(DataAccess Conn, string SqlOutputFile, string filterKind) {
            CQueryHelper QHC = new CQueryHelper();
            QueryHelper QHS = Conn.GetQueryHelper();
            DataTable TSorKind = DataAccess.CreateTableByName(Conn, "sortingkind", "*");

            DataAccess.RUN_SELECT_INTO_TABLE(Conn, TSorKind, null, filterKind, null, true);
            if ((TSorKind == null) || (TSorKind.Rows.Count == 0)){
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Nessuna riga trovata con il filtro " + filterKind);
                return false;
            }
            StreamWriter writer = new StreamWriter(SqlOutputFile, false, System.Text.Encoding.Default);
            StringBuilder sql = new StringBuilder();

            object idsorkind = TSorKind.Rows[0]["idsorkind"];
            string filterIdkind = QHS.CmpEq("idsorkind", idsorkind);
            DataTable TSor = Conn.RUN_SELECT("sorting", "*", null, filterIdkind, null, false);

            sql.AppendLine("-- GENERAZIONE DATI PER finsorting");

            sql.Append("DECLARE @idsorkind int\r\n");
            sql.Append("SELECT @idsorkind = idsorkind FROM sortingkind WHERE " + filterKind + " \r\n");
            sql.Append("DECLARE @idfin int\r\n");
            sql.Append("DECLARE @idsor int\r\n");

            //Ciclo su sorting
            foreach (DataRow Sor in TSor.Rows) {
                string filterCode = QHS.CmpEq("sortcode", Sor["sortcode"]);

                string filterFinSor = QHS.CmpEq("idsor",Sor["idsor"]);

                DataTable TfinSorting = Conn.RUN_SELECT("finsorting", "*", null, filterFinSor, null, false);
                if (TfinSorting.Rows.Count > 0){
                    sql.AppendLine();
                    sql.Append("SET @idsor=null\r\n");
                    sql.Append("SELECT @idsor = idsor FROM sorting WHERE idsorkind = @idsorkind and " + filterCode + " \r\n");
                }
                foreach (DataRow Rfinsorting in TfinSorting.Rows){
                    // Per ogni riga di bilancio classificata con la classificazione Corrente, si legge i campi Codice/Anno/ParteBilancio
                    // da usare per identificare l'idfin sul DB di destinazione.
                    object codefin = Conn.DO_READ_VALUE("fin", QHS.CmpEq("idfin", Rfinsorting["idfin"]), "codefin");
                    object ayear =  Conn.DO_READ_VALUE("fin", QHS.CmpEq("idfin", Rfinsorting["idfin"]), "ayear");
                    object flagObj = Conn.DO_READ_VALUE("fin", QHS.CmpEq("idfin", Rfinsorting["idfin"]), "flag&1");
                    byte flag = Convert.ToByte(flagObj);
                    sql.Append("SET @idfin=null\r\n");
                    sql.Append("SELECT @idfin = idfin FROM fin WHERE codefin = " + QueryCreator.quotedstrvalue(codefin,true)
                        + " AND ayear = " + ayear
                        + " AND (flag&1) = " + flag
                        + " \r\n");

                    string insert = "IF (@idfin IS NOT NULL) AND (@idsor is not null) AND NOT EXISTS(SELECT * FROM finsorting WHERE " 
                                    + " idfin = @idfin AND idsor = @idsor )" + " \r\n" 
                                    + "INSERT INTO finsorting (idfin, idsor, ct, cu, lt, lu, quota) "
                                    + " VALUES (@idfin, @idsor, getdate(), 'generasql', getdate(), 'generasql', NULL) ";
                    sql.Append(insert + " \r\n");
                    
                }
            }
            if (sql.Length != 0){
                writer.WriteLine(sql);
                writer.WriteLine("GO");
                writer.Flush();
            }

            writer.Write("-- FINE GENERAZIONE SCRIPT --\r\n\r\n");
            writer.WriteLine("GO");
            writer.Close();

            return true;
        }

        public static bool generaTaxRateStartBracket(DataAccess Conn, string SQLOutputFile, string filter){
            CQueryHelper QHC = new CQueryHelper();
            QueryHelper QHS = Conn.GetQueryHelper();

            DataTable tStart = Conn.CreateTableByName( "taxratestart", "*");
            DataTable tBracket = Conn.CreateTableByName( "taxratebracket", "*");

            Conn.RUN_SELECT_INTO_TABLE(tStart, null, filter, null, true);
            if ((tStart == null) || (tStart.Rows.Count == 0))
            {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Nessuna riga trovata con il filtro " + filter);
                return false;
            }

            foreach (DataRow r in tStart.Rows)
            {
                string filterSon = QHS.MCmp(r, new string[] { "taxcode", "idtaxratestart" });
                Conn.RUN_SELECT_INTO_TABLE(tBracket, null, filterSon, null, true);
            }


            DataSet DS = new DataSet();
            DS.Tables.Add(tStart);
            DS.Tables.Add(tBracket);

            StreamWriter writer = new StreamWriter(SQLOutputFile, false, System.Text.Encoding.Default);
            writer.WriteLine("--[DBO]--");

            DataTable tTax = Conn.CreateTableByName("tax", "taxcode,taxref");

            string DistVal = QHC.DistinctVal(DS.Tables["taxratestart"].Select(), "taxcode");
            string filterTax = QHC.FieldInList("taxcode", DistVal);

            Conn.RUN_SELECT_INTO_TABLE(tTax, "taxcode", filterTax, null, true);

            Hashtable hTax = new Hashtable();
            StringBuilder dichiarazione = new StringBuilder();

            foreach (DataRow r in tTax.Rows)
            {
                string variabile = "@taxcode" + r["taxcode"].ToString();
                dichiarazione.Append("DECLARE " + variabile + " int\r\n");
                dichiarazione.Append("SELECT " + variabile + " = taxcode FROM tax WHERE "
                    + QHS.CmpEq("taxref", r["taxref"]) + "\r\n");
                hTax[r["taxcode"]] = variabile;
            }


            foreach (DataTable T in DS.Tables)
            {

                writer.WriteLine(dichiarazione);

                string dbo = "[dbo].";
                string tablename = T.TableName;


                //--- è indipendente dalla riga  ----
                string insert = "INSERT INTO " + dbo + "[" + tablename + "] (";
                foreach (DataColumn C in T.Columns)
                {
                    string colName = C.ColumnName;
                    insert += colName + ",";
                }
                insert = insert.Remove(insert.Length - 1, 1);
                insert += ") VALUES (";
                // ----------------------------------

                writer.Write("\r\n-- GENERAZIONE DATI PER " + tablename + " --\r\n");

                int i = 1;
                StringBuilder s = new StringBuilder();
                foreach (DataRow row in T.Rows)
                {
                    string cmpkey = "";
                    if (T.TableName == "taxratestart")
                        cmpkey = QHS.AppAnd(QHS.CmpEq("idtaxratestart", row["idtaxratestart"]),
                                            QHS.CmpEq("taxcode", QHS.Field(hTax[row["taxcode"]].ToString())));
                    else
                        cmpkey = QHS.AppAnd(QHS.CmpEq("idtaxratestart", row["idtaxratestart"]),
                                            QHS.CmpEq("nbracket", row["nbracket"]),
                                            QHS.CmpEq("taxcode", QHS.Field(hTax[row["taxcode"]].ToString())));


                    string ifnotexists = "IF NOT EXISTS(SELECT * FROM " + tablename + " WHERE " + cmpkey + " ) ";

                    string values = "";

                    foreach (DataColumn C in T.Columns)
                    {
                        string colName = C.ColumnName;
                        if (colName == "taxcode")
                        {
                            values += hTax[row["taxcode"]];
                        }
                        else
                        {
                            values += QueryCreator.GetPrintable(QueryCreator.quotedstrvalue(row[colName], true));
                        }
                        values += ",";
                    }
                    values = values.Remove(values.Length - 1, 1);
                    values += ")\r\n";

                    s.Append(ifnotexists + insert + values);

                    if (i % 30 == 0)
                    {
                        writer.WriteLine(s);
                        writer.WriteLine("GO");
                        writer.WriteLine(dichiarazione);
                        writer.Flush();
                        s = new StringBuilder();
                        i = 1;
                    }
                    i++;
                }

                if (s.Length != 0)
                {
                    writer.WriteLine(s);
                    writer.WriteLine("GO");
                    writer.Flush();
                }
            }

            writer.Write("-- FINE GENERAZIONE SCRIPT --\r\n\r\n");
            writer.WriteLine("GO");
            writer.Close();
            return true;
        }

        #endregion
    }
}
