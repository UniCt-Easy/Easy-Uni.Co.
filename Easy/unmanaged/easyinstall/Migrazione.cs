
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
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
using System.IO;
using generaSQL;
using LiveUpdate;
using dbbridge;
using System.Text;
using System.Collections;
using funzioni_configurazione;


namespace EasyInstall
{
	/// <summary>
	/// Summary description for Migrazione.
	/// </summary>
	public class Migrazione {
		public static DataTable eseguiQuery(DataAccess sourceConn, string command, Form form) {
			string errMsg;
			DataTable t = sourceConn.SQLRunner(command, 0 , out errMsg);
			if (errMsg != null) {
				QueryCreator.ShowError(null,errMsg,command);
				MetaFactory.factory.getSingleton<IMessageShower>().Show(form, errMsg);
			}
			return t;
		}
		private static string GetSQLDataValues(DataRow row,DataTable Cols) {
			string s = "";
			int colcount = Cols.Rows.Count;
			for (int i = 0; i < colcount; i++) {
				string valore = "";
				string colname=Cols.Rows[i]["COLUMN_NAME"].ToString();
				if (row.Table.Columns.Contains(colname))
					valore=QueryCreator.quotedstrvalue(row[colname] , true);
				else
					valore="NULL";
				s += valore + ",";
			}
			s = s.Remove(s.Length - 1, 1);
			return s + ")\r\n";
		}

		static bool CopyTable(Form form, DataTable TT, DataAccess Dest, string title){
			try {
				DataTable Cols= Dest.SQLRunner("sp_columns "+TT.TableName);


				if (TT.Rows.Count==0) return true;
				string insert = "INSERT INTO "+TT.TableName+" VALUES(";//(
				//				foreach (DataColumn C in TT.Columns) {
				//					insert += C.ColumnName + ",";
				//				}
				//				insert = insert.Remove(insert.Length - 1, 1);
				//				insert += ") VALUES (";
				int count=0;
				string s = "";
				string err;
				FrmMeter FM= new FrmMeter(true);

				FM.StartPosition= FormStartPosition.CenterScreen;
				FM.Text=title; //"Copia della tabella "+TT.TableName;
				FM.pBar.Maximum= TT.Rows.Count;
				FM.Show();

				foreach (DataRow row in TT.Rows) {
					FM.pBar.Increment(1);
					count++;
					string values = GetSQLDataValues(row,Cols);
					s += 	insert		+ values;
					if (count ==10){
						Dest.SQLRunner(s,0, out err);
						Application.DoEvents();
						if (err!=null){
							QueryCreator.ShowError(form,"Errore",err);
							FM.Close();
							StreamWriter fsw = new StreamWriter("temp.sql", false, Encoding.Default);
							fsw.Write(s.ToString());
							fsw.Close();
							MetaFactory.factory.getSingleton<IMessageShower>().Show(form, "Errore durante la copia "+title+"\r\nLo script lanciato si trova nel file 'temp.sql'");

							return false;
						}
						s = "";
						count=0;
					}
				}
				if (s!=""){
					Dest.SQLRunner(s,0, out err);
					if (err!=null){
						QueryCreator.ShowError(form,"Errore",err);
						FM.Close();
						StreamWriter fsw = new StreamWriter("temp.sql", false, Encoding.Default);
						fsw.Write(s.ToString());
						fsw.Close();
						MetaFactory.factory.getSingleton<IMessageShower>().Show(form, "Errore durante la copia "+title+"\r\nLo script lanciato si trova nel file 'temp.sql'");

						return false;
					}

					s = "";
				}
				FM.Close();
				Application.DoEvents();
				return true;
			}
			catch{
				return false;
			}

		}


		
		public static bool lanciaScript(Form form, DataAccess destConn, DataSet ds, string nomeCopia) {
			if (ds.Tables.Count==1){
				if (!CopyTable(form, ds.Tables[0],destConn,nomeCopia)){
					MetaFactory.factory.getSingleton<IMessageShower>().Show(form, "Errore durante la copia: "+nomeCopia+"\r\n");
					return false;
				}
				return true;
			}
			StringWriter sw = new StringWriter();
			GeneraSQL.GeneraStrutturaEDati(/*false, */destConn, ds, sw, 
				UpdateType.bulkinsert, DataGenerationType.onlyData, true);
			bool ok = Download.RUN_SCRIPT(destConn, sw.GetStringBuilder(), nomeCopia);
			if (!ok) {
				StreamWriter fsw = new StreamWriter("temp.sql", false, Encoding.Default);
				fsw.Write(sw.ToString());
				fsw.Close();
				MetaFactory.factory.getSingleton<IMessageShower>().Show(form, "Errore durante la copia: "+nomeCopia+"\r\nLo script lanciato si trova nel file 'temp.sql'");
				return false;
			}
			return true;
		}

		public static bool lanciaScript(Form form, DataAccess destConn, DataTable t, string nomeCopia) {
			if (!CopyTable(form,t,destConn,nomeCopia)){
				MetaFactory.factory.getSingleton<IMessageShower>().Show(form, "Errore durante la copia: "+nomeCopia+"\r\n");
				return false;
			}
			return true;
			/*
			StringWriter sw = new StringWriter();
			GeneraSQL.GetSQLData(t, UpdateType.bulkinsert, sw);
			bool ok = Download.RUN_SCRIPT(destConn, sw.GetStringBuilder(), nomeCopia);
			if (!ok) {
				StreamWriter fsw = File.CreateText("temp.sql");
				fsw.Write(sw.ToString());
				fsw.Close();
				MetaFactory.factory.getSingleton<IMessageShower>().Show(form, "Errore durante la copia: "+nomeCopia+"\r\nLo script lanciato si trova nel file 'temp.sql'");
			}
			*/
		}

		/// <summary>
		/// Copia dettordinegenerico in mandatedetail ponendo idmankind='GENERALE'
		/// </summary>
		/// <param name="form"></param>
		/// <param name="sourceConn"></param>
		/// <param name="destConn"></param>
	
		public static DataTable leggiETraduciTabella(string oldTable, DataAccess sourceConn, 
			DataTable tColName, Form form) {
			return leggiETraduciTabella(oldTable, sourceConn, tColName, form, null, null, null);
		}

		public static DataTable leggiETraduciTabella(string oldTable, DataAccess sourceConn, 
			DataTable tColName, Form form, string colonneDaNonCopiare, string campiAggiuntivi) {				
			return leggiETraduciTabella(oldTable, sourceConn, tColName, form, 
				colonneDaNonCopiare, campiAggiuntivi, null);
		}

		public static DataTable leggiETraduciTabella(string oldTable, DataAccess sourceConn, 
			DataTable tColName, Form form, 
			string colonneDaNonCopiare, string campiAggiuntivi, string filtroWhere) {				
			string q = "oldtable='"+oldTable+"' and newcol not like 'delete%'";
			if (colonneDaNonCopiare != null) {
				q += " and newcol not in ("+colonneDaNonCopiare+")";
			}
			DataRow[] rCol = tColName.Select(q);
			if (rCol.Length > 0) {
				string query = "select ";
				foreach (DataRow r in rCol) {
					string oldCol = r["oldcol"].ToString();
					string newCol = r["newcol"].ToString();
					if (oldCol == newCol) {
						query += oldCol + ", ";
					} else {
						query += newCol + "=" + oldCol + ", ";
					}
				}
				if (campiAggiuntivi == null) {
					query = query.Remove(query.Length-2, 2);
				} else {
					query += campiAggiuntivi;
				}

				query += " from " + rCol[0]["oldtable"];

				if (filtroWhere != null) {
					query += " where " + filtroWhere;
				}

				return eseguiQuery(sourceConn, query, form);
			} else {
				MetaFactory.factory.getSingleton<IMessageShower>().Show(form, "La tabella "+oldTable+" non esiste più");
				return null;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="oldTable"></param>
		/// <param name="sourceConn"></param>
		/// <param name="tColName"></param>
		/// <param name="form"></param>
		/// <param name="colonneDaNonCopiare"></param>
		/// <param name="campiAggiuntivi"></param>
		/// <returns></returns>
		public static DataTable leggiTabella(string oldTable, string newTable, DataAccess sourceConn, 
			DataTable tColName, Form form, string colonneDaNonCopiare, string campiAggiuntivi) {				
			string q = "oldtable='"+oldTable+"' and newcol not like 'delete%'";
			if (colonneDaNonCopiare != null) {
				q += " and newcol not in ("+colonneDaNonCopiare+")";
			}
			DataRow[] rCol = tColName.Select(q);
			if (rCol.Length > 0) {
				string query = "select ";
				foreach (DataRow r in rCol) {
					query += r["newcol"] + ", ";
				}
				if (campiAggiuntivi == null) {
					query = query.Remove(query.Length-2, 2);
				} else {
					query += campiAggiuntivi;
				}

				query += " from " + newTable;

				return eseguiQuery(sourceConn, query, form);
			} else {
				MetaFactory.factory.getSingleton<IMessageShower>().Show(form, "La tabella "+oldTable+" non esiste più");
				return null;
			}
		}

		public static void CreaScriptStrutturaPerTabDiSistema(bool isDbo, string filename, 
			DataAccess conn,  Form form) {
			StreamWriter sw = new StreamWriter(filename, false, Encoding.Default);

            //DataRow[] ListaTabs = isDbo
            //    ? tTableSetup.Select("oldtable in ('dbdepartment','dbuser','dbaccess')")
            //    : tTableSetup.Select("oldtable in ('customobject','columntypes')");
            string[] ListaTabs;
            if (isDbo) {
                ListaTabs = new string[] { "dbdepartment", "dbuser", "dbaccess" };
            }
            else {
                ListaTabs = new string[] { "customobject", "columntypes" };
            }
			int NDONE=0;
			int NTAB= ListaTabs.Length;

			foreach (string tabname in ListaTabs) {
				//Crea lo script per la tabella T
				DataTable T = conn.CreateTableByName(tabname, "*", true);
                conn.AddExtendedProperty(T);
				try {
					string[,] cols;
					sw.Write(GeneraSQL.GetSQLTable(isDbo, conn, T, out cols, true));
					NDONE++;
				}
				catch (Exception e){
					QueryCreator.ShowException(form, "Errore creando lo script per la tabella "+T.TableName, e);
					continue;
				}
			}

			sw.Close();

			if (NDONE==NTAB)MetaFactory.factory.getSingleton<IMessageShower>().Show("Script "+filename+" creato correttamente");
		}


		public static void CreaScriptStrutturaPerTabelle(Form form, bool isDbo, string filename, DataAccess Conn) {
			StreamWriter sw = new StreamWriter(filename, false, Encoding.Default);

			DataTable ListaTabs = Conn.RUN_SELECT("customobject","objectname",null,"(isreal='S')",null,null,false);
            metadatalibrary.dbstructure DBS = new dbstructure();
            foreach (DataTable TDBS in DBS.Tables) {
                if (ListaTabs.Select("objectname=" + QueryCreator.quotedstrvalue(
                    TDBS.TableName, false)).Length == 0) {
                    DataRow XL = ListaTabs.NewRow();
                    XL["objectname"] = TDBS.TableName;
                    ListaTabs.Rows.Add(XL);
                }
            }
			
            //string dbo = isDbo ? "S" : "N";
			//string filtro = "dbo='"+dbo+"' and xtype='U' and newtable not like 'delete%'";
			//DataRow[] ListaTabs = tTableSetup.Select(filtro);
            string filtro;
            if (isDbo) 
                filtro=" and (uid=user_id('dbo'))";
            else
                filtro=" and (uid<>user_id('dbo'))";

			int NDONE=0;
			int NTAB= ListaTabs.Rows.Count;

			foreach (DataRow TabRow in ListaTabs.Select()) {
                if (TabRow["objectname"].ToString() == "colname") continue;
                if (TabRow["objectname"].ToString() == "tablename") continue;

                object SS= Conn.DO_SYS_CMD("select count(*) from sysobjects where "+
                        "name="+QueryCreator.quotedstrvalue(TabRow["objectname"].ToString(),true)+
                        filtro,false);
                int NSS=CfgFn.GetNoNullInt32(SS);
                if (NSS==0)continue;
                
				//Crea lo script per la tabella T
                DataTable T = Conn.CreateTableByName(TabRow["objectname"].ToString(), "*", true); //ex newtable
				if (T.Columns.Count==0) {
					MetaFactory.factory.getSingleton<IMessageShower>().Show(form, "Non esiste la tabella "+
						T.TableName+"\npertanto non sarà generato lo script per tale tabella.", "ERRORE!");
					continue;
				} 
				DataColumn[] colonne = new DataColumn[T.Columns.Count];
				T.Columns.CopyTo(colonne, 0);
				foreach (DataColumn c in colonne) {
					if (c.ColumnName.ToUpper().StartsWith("DELETE")) {
						//MetaFactory.factory.getSingleton<IMessageShower>().Show("trovata colonna "+T.TableName+"."+c.ColumnName);
						T.Columns.Remove(c);
					}
				}
                Conn.AddExtendedProperty(T);
				string[,] cols;
				string script="";
				try {
					script= GeneraSQL.GetSQLTable(isDbo, Conn,
						T, 
						out cols, true);
					sw.Write(script);
					sw.Flush();
					//GeneraSQL.GeneraStruttura(isDbo, Conn, T, sw, true);
					NDONE++;
				}
				catch (Exception e){
					QueryCreator.ShowException(form, "Errore creando lo script per la tabella "+T.TableName, e);
					continue;
				}
			}
            sw.Close();

			//			StringBuilder All = sw.GetStringBuilder();
			//			All = All.Replace("\r","\n");
			//			All = All.Replace("\n\n","\n");
			//			All = All.Replace("\n","\r\n");

			//			FileInfo ff = new FileInfo(filename);
			//			StreamWriter write = ff.CreateText();
			//			write.Write(All.ToString());
			//			write.Close();
			if (NDONE==NTAB)MetaFactory.factory.getSingleton<IMessageShower>().Show("Script "+filename+" creato correttamente");


		}

		
		public static void CreaScriptPerViste(string filenameNonDbo, string filenameDbo, DataAccess Conn,
			Form form) {
			//Testi delle SP (in campo text)
			DataTable SysComments = Conn.RUN_SELECT("syscomments","id,colid,text,encrypted","id,colid",getFiltroVista("id"),
				null,false);
			//Nomi delle sp
			DataTable SysObjects = Conn.RUN_SELECT("sysobjects","id,name,parent_obj,xtype,uid","id",getFiltroVista("id"),
				null,false);
			DataTable SysDepends = Conn.RUN_SELECT("sysdepends","id,depid","id",getFiltroVista("id")+" and "+getFiltroVista("depid"),
				null,null,false);

			SysObjects.Columns.Add("dbo");

			StringBuilder sptDbo= new StringBuilder(100000);
			StringBuilder nonDbo= new StringBuilder(100000);
			bool SomethingDone=true;
			int NDONE=0;
			int NSP= SysObjects.Rows.Count;

			while (SomethingDone) {
				SomethingDone=false;

				
				//Ora per ogni sp estrae il testo
				foreach (DataRow SPObj in SysObjects.Rows) {
					int id= (int) SPObj["id"];
					string viewname= SPObj["name"].ToString();

					if (id<0) continue; //Già messa!

					//Vede se la sp dipende da qualche altra 
					DataRow[] rDepend = SysDepends.Select("id="+id+" and depid<>"+id);
					if (rDepend.Length>0){
						//PostPone!
						continue;
					}

                    bool isDbo = (SPObj["uid"].ToString() == "1");
                            //fillDboField(SPObj, form, Conn, tTableSetup);

					StringBuilder All = new StringBuilder();
					string dbo = isDbo ? "[DBO]." : "";


					SPObj["id"]=-id;
					SomethingDone=true;

					

					//SPObj è la riga in sysobject, che contiene il nome nel campo name
					DataRow []SPBodys= SysComments.Select("id="+id.ToString(),"colid");
					if (SPBodys[0]["encrypted"].ToString().ToUpper()=="TRUE") {
						NSP--;
						continue;
					}
					string spbody="";
					foreach (DataRow RR in SPBodys) {
						spbody+=RR["text"].ToString();
					}
					spbody = spbody.Replace("dbo.","");

					//Prende il testo della vista e si accerta che sia una vista DBO
					SPBridge SPB = new SPBridge(spbody);
					string skipped;
					dbbridge.SPToken Tok;
					Tok = SPB.NextToken(out skipped);
					All.Append(skipped);
					if (Tok.val.ToLower()!="create") {
						MetaFactory.factory.getSingleton<IMessageShower>().Show("Impossibile compilare la vista "+viewname);
						continue;
					}
					All.Append(Tok.val);
					Tok= SPB.NextToken(out skipped);
					All.Append(skipped);
					if (Tok.val.ToLower()!="view") {
						MetaFactory.factory.getSingleton<IMessageShower>().Show("Impossibile compilare la vista "+viewname);
						continue;
					}
					All.Append(Tok.val);
					Tok = SPB.NextToken(out skipped);
					All.Append(skipped);
					string foundname= Tok.val;
					string []parts = foundname.Split(new char[]{'.'});
					string newname= dbo+parts[parts.Length-1];
					All.Append(newname);
					int mark = SPB.GetMark();
					All.Append(spbody.Substring(mark));				
					All.Append("\r\nGO\r\n");
					All.Append("\r\nprint '"+newname+" OK'\r\n");
					All.Append("\r\nGO\r\n");

					StringBuilder sb = isDbo ? sptDbo : nonDbo;

					string s = parts[parts.Length-1];
					if (s.StartsWith("[")) {
						s = s.Substring(1);
					}
					if (s.EndsWith("]")) {
						s = s.Substring(0, s.Length-1);
					}
					sb.Append("IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'"+s+"') and OBJECTPROPERTY(id, N'IsView') = 1)\r\n"
						+ "DROP VIEW "+s+"\r\nGO\r\n");
					//					if (s != viewname) {
					//						Console.WriteLine(newname+" "+viewname);
					//					}

					sb.Append(All);


					//Elimina le dipendenze con altre sp esistenti
					DataRow []Dependent= SysDepends.Select("depid="+id.ToString());
					foreach (DataRow D in Dependent){
						D.Delete();
					}
					SysDepends.AcceptChanges();
					NDONE++;
				}
			}


			sptDbo = sptDbo.Replace("\r","\n");
			sptDbo = sptDbo.Replace("\n\n","\n");
			sptDbo = sptDbo.Replace("\n","\r\n");

			nonDbo = nonDbo.Replace("\r","\n");
			nonDbo = nonDbo.Replace("\n\n","\n");
			nonDbo = nonDbo.Replace("\n","\r\n");

			//			FileInfo ff = new FileInfo(filenameNonDbo);//ff.CreateText();
			StreamWriter write = new StreamWriter(filenameNonDbo, false, Encoding.Default);
			write.Write(nonDbo.ToString());
			//write.WriteLine(newversion);
			write.Close();
			//			ff = new FileInfo(filenameDbo);//ff.CreateText();
			write = new StreamWriter(filenameDbo, false, Encoding.Default);
			write.Write(sptDbo.ToString());
			//write.WriteLine(newversion);
			write.Close();

			if (NDONE==NSP){
				MetaFactory.factory.getSingleton<IMessageShower>().Show("Script "+filenameNonDbo+" e "+filenameDbo+" creati correttamente");
			}
			else {
				MetaFactory.factory.getSingleton<IMessageShower>().Show(NDONE.ToString()+" di "+NSP.ToString()+" viste elaborate");
				foreach (DataRow EL in SysObjects.Rows){
					int id = (int) EL["id"];
					if (id<0) continue;
					MetaFactory.factory.getSingleton<IMessageShower>().Show("La vista "+EL["name"].ToString()+" non è stata elaborata.");

				}
			}
		}

		//		private static string getFiltroSP(string id) {
		//			return "(objectproperty("+id+",'isprocedure')=1 or objectproperty("+id+",'istrigger')=1) and (OBJECTPROPERTY("+id+", 'IsMSShipped')=0) and (object_name("+id+") not like 'delete%')";
		//		}

		public static void CreaScriptPerSP(string filenamedbo, string filenamenondbo,DataAccess Conn) {
			//			//Testi delle SP (in campo text)
			//			DataTable SysComments = Conn.RUN_SELECT("syscomments","id,colid,text,encrypted","id,colid",
			//				getFiltroSP("id"),
			//				null,false);
			//			//Nomi delle sp
			//			DataTable SysObjects = Conn.RUN_SELECT("sysobjects","id,name,parent_obj,xtype,uid",null,
			//				getFiltroSP("id"),
			//				null,false);
			//
			//			DataTable SysDepends = Conn.RUN_SELECT("sysdepends","id,depid","id",
			//				getFiltroSP("id")+" and "+getFiltroSP("depid"),
			//				null,null,false);

			//Testi delle SP (in campo text)
			DataTable SysComments = Conn.SQLRunner("select syscomments.id,colid,text,encrypted from syscomments "
				+ "join sysobjects on syscomments.id=sysobjects.id "
				+ "where (xtype in ('P','TR','FN')) and (OBJECTPROPERTY(syscomments.id, 'IsMSShipped')=0) and (name not like 'delete%') and (uid=user_id()or uid=user_id('dbo')) "
				+ "order by syscomments.id,colid");

			//Nomi delle sp
			DataTable SysObjects = Conn.SQLRunner("select id,name,parent_obj,xtype,uid from sysobjects "
				+ "where (xtype in ('P','TR','FN')) and (OBJECTPROPERTY(id, 'IsMSShipped')=0) and (name not like 'delete%') and (uid=user_id()or uid=user_id('dbo'))");

			DataTable SysDepends = Conn.SQLRunner("select sysdepends.id,depid from sysdepends "
				+ "join sysobjects obj on sysdepends.id=obj.id "
				+ "join sysobjects dep on sysdepends.depid=dep.id "
				+ "where (obj.xtype in ('P','TR','FN')) and (OBJECTPROPERTY(obj.id, 'IsMSShipped')=0) and (obj.name not like 'delete%') and (obj.uid=user_id()or dep.uid=user_id('dbo')) "
				+ "and (dep.xtype in ('P','TR','FN')) and (OBJECTPROPERTY(depid, 'IsMSShipped')=0) and (dep.name not like 'delete%') and (dep.uid=user_id()or dep.uid=user_id('dbo'))"
				+ "order by sysdepends.id");

			StringBuilder tuttenondbo= new StringBuilder(100000);
			StringBuilder tuttedbo= new StringBuilder(100000);
			bool SomethingDone=true;
			int NDONE=0;
			int NSP= SysObjects.Rows.Count;

			while (SomethingDone){
				SomethingDone=false;
				
				//Ora per ogni sp estrae il testo
				foreach (DataRow SPObj in SysObjects.Rows){
					int id= (int) SPObj["id"];
					if (id<0) continue; //Già messa!
					//Vede se la sp dipende da qualche altra 
					//depid= l'oggetto che crea la dipendenza id=l'oggetto DIPENDENTE
					if (SysDepends.Select("id="+id.ToString()+" and depid<>"+id.ToString()).Length>0){
						//PostPone!
						continue;
					}

					SPObj["id"]=-id;
					SomethingDone=true;


					string spname= SPObj["name"].ToString();
					if (spname.StartsWith("check_")&&
						((spname.EndsWith("_pre")||spname.EndsWith("_post")))){
						NSP--;
						continue;
					}

					//SPObj è la riga in sysobject, che contiene il nome nel campo name
					DataRow []SPBodys= SysComments.Select("id="+id.ToString(),"colid");
					if (SPBodys[0]["encrypted"].ToString().ToUpper()=="TRUE") {
						NSP--;
						continue;
					}
					string spbody="";
					foreach (DataRow RR in SPBodys) {
						spbody+=RR["text"].ToString();
					}

					//Prende il testo della sp e si accerta che sia una SP DBO
					SPBridge SPB = new SPBridge(spbody);
					string skipped;
					dbbridge.SPToken Tok;
					Tok = SPB.NextToken(out skipped);
					StringBuilder All = new StringBuilder();
					All.Append(skipped);
					if (Tok.val.ToLower()!="create"){
						MetaFactory.factory.getSingleton<IMessageShower>().Show("Impossibile compilare la sp "+spname);
						continue;
					}
					All.Append(Tok.val);
					Tok= SPB.NextToken(out skipped);
					All.Append(skipped);
					string tipo = Tok.val;
					if ((Tok.val.ToLower()!="procedure")&&(Tok.val.ToLower()!="trigger")&&
							(Tok.val.ToLower()!="function")){
						MetaFactory.factory.getSingleton<IMessageShower>().Show("Impossibile compilare la sp "+spname);
						continue;
					}
					bool dbo=false;
					All.Append(Tok.val);
					Tok = SPB.NextToken(out skipped);
					All.Append(skipped);
					string foundname= Tok.val;
					string []parts = foundname.Split(new char[]{'.'});
					string newname= /*"[DBO]."+*/parts[parts.Length-1];
					if (parts[0].ToUpper().Trim()=="DBO"||
						parts[0].ToUpper().Trim()=="[DBO]") {
						dbo=true;
						newname="[DBO]."+newname;
					}
					All.Append(newname);

					if (tipo.ToLower()=="trigger") {
						Tok = SPB.NextToken(out skipped);
						All.Append(skipped);
						if (Tok.val != "ON") {
							MetaFactory.factory.getSingleton<IMessageShower>().Show("Impossibile compilare il trigger "+spname);
							continue;
						}
						All.Append(Tok.val);

						Tok = SPB.NextToken(out skipped);
						All.Append(skipped);
						string foundTable= Tok.val;
						string[] tableParts = foundTable.Split(new char[]{'.'});
						string newTable= tableParts[tableParts.Length-1];
						All.Append(newTable);
					}
																	
					int mark = SPB.GetMark();
					All.Append(spbody.Substring(mark));				
					All.Append("\r\nGO\r\n");

					All.Append("\r\nprint '"+newname+" OK'\r\n");
					All.Append("\r\nGO\r\n");


					string s = parts[parts.Length-1];
					if (dbo){
						tuttedbo.Append("if object_id('"+s+"') is not null\r\n\tdrop "+tipo+" "+s+"\r\ngo\r\n");
						tuttedbo.Append(All);
					}
					else {
						tuttenondbo.Append("if object_id('"+s+"') is not null\r\n\tdrop "+tipo+" "+s+"\r\ngo\r\n");
						tuttenondbo.Append(All);
					}

					
					//Elimina le dipendenze con altre sp esistenti
					DataRow []Dependent= SysDepends.Select("depid="+id.ToString());
					foreach (DataRow D in Dependent){
						D.Delete();
					}
					SysDepends.AcceptChanges();
					NDONE++;
						
				}
			}
			if (NDONE==NSP){
				MetaFactory.factory.getSingleton<IMessageShower>().Show("Script "+filenamedbo+" e "+filenamenondbo+" creati correttamente");
			}
			else {
				MetaFactory.factory.getSingleton<IMessageShower>().Show(NDONE.ToString()+" di "+NSP.ToString()+" s.p. elaborate");
				foreach (DataRow EL in SysObjects.Rows){
					int id = (int) EL["id"];
					if (id<0) continue;
					MetaFactory.factory.getSingleton<IMessageShower>().Show("La sp "+EL["name"].ToString()+" non è stata elaborata.");

				}
			}

			tuttedbo = tuttedbo.Replace("\r","\n");
			tuttedbo = tuttedbo.Replace("\n\n","\n");
			tuttedbo = tuttedbo.Replace("\n","\r\n");

			tuttenondbo = tuttenondbo.Replace("\r","\n");
			tuttenondbo = tuttenondbo.Replace("\n\n","\n");
			tuttenondbo = tuttenondbo.Replace("\n","\r\n");

			StreamWriter writedbo = new StreamWriter(filenamedbo, false, Encoding.Default);
			//			FileInfo ff = new FileInfo(filename);
			//			StreamWriter write = ff.CreateText();
			writedbo.Write(tuttedbo);
			//write.WriteLine(newversion);
			writedbo.Close();

			StreamWriter writenondbo = new StreamWriter(filenamenondbo, false, Encoding.Default);
			//			FileInfo ff = new FileInfo(filename);
			//			StreamWriter write = ff.CreateText();
			writenondbo.Write(tuttenondbo);
			//write.WriteLine(newversion);
			writenondbo.Close();

		}


		public static bool isDboTable(DataTable tTableSetup, string tabella) {
			DataRow[] rTabelle = tTableSetup.Select("newtable="+QueryCreator.quotedstrvalue(tabella, false));
			if (rTabelle.Length == 0) {
				return false;
			}
			string dbo = rTabelle[0]["dbo"] as string;
			return (dbo!=null) && (dbo.Trim()=="S");
		}

		private static bool fillDboField(DataRow rView, Form form, DataAccess Conn, DataTable tTableSetup) {
			string dbo = rView["dbo"] as string;
			if (dbo == "S") {
				return true;
			}
			if (dbo == "N") {
				return false;
			}
			string filtro = "select distinct s2.name, s2.xtype from sysdepends "
				+ "join sysobjects s2 on sysdepends.depid=s2.id and sysdepends.id="+rView["id"];
			string errMsg;
			DataTable tDepend = Conn.SQLRunner(filtro, 0, out errMsg);
			if (errMsg != null) {
				MetaFactory.factory.getSingleton<IMessageShower>().Show(form, errMsg);
			}
			bool isDbo = true;
			foreach (DataRow rDepend in tDepend.Rows) {
				string xtype = (string) rDepend["xtype"];
				switch (xtype) {
					case "U ":
						if (!isDboTable(tTableSetup, (string)rDepend["name"])) {
							rView["dbo"] = "N";
							return false;
						}
						break;
					case "V ":
						DataTable sysObjects = rView.Table;
						DataRow[] rView2 = sysObjects.Select("name="+QueryCreator.quotedstrvalue(rDepend["name"], false));
						if (!fillDboField(rView2[0], form, Conn, tTableSetup)) {
							return false;
						}
						break;
					default:
						MetaFactory.factory.getSingleton<IMessageShower>().Show(form, xtype+" è un xtype non conosciuto");
						break;
				}
			}
			rView["dbo"] = isDbo ? "S" : "N";
			return isDbo;
		}

		private static string getFiltroVista(string id) {
			return "(objectproperty("+id+",'isview')=1) and (OBJECTPROPERTY("+id+", 'IsMSShipped')=0) and (object_name("+id+") not like 'delete%')";
		}


		/// <summary>
		/// Traduce licenzauso ponendo a null i seguenti campi:
		/// iddb, servername, dbname, swmorecode, swmoreflag
		/// </summary>
		/// <param name="form"></param>
		/// <param name="sourceConn"></param>
		/// <param name="destConn"></param>
		public static bool migraLicenzaUso(Form form, DataAccess sourceConn, DataAccess destConn) {
			string query = "select address1=indirizzo_1, address2=indirizzo_2, "
				+ "agency=universita, agencycode=codiceente, agencyname=nomeuniversita, "
				+ "annotations=note, cap, cf=codicefiscale, "
				+ "checkbackup1, checkbackup2, checkflag, checklic, checkman, "
				+ "country=provincia, dbname=null, "
				+ "department=dipartimento, departmentcode=codicedipartimento, departmentname=nomeente, "
				+ "dummykey, email, expiringlic=scadenzalic, expiringman=scadenzaman, "
				+ "fax, iddb=null, idreg=codicecreddeb, "
				+ "lickind=tipolic, licstatus=statolic, location=localita, "
				+ "lt=lastmodtimestamp, lu=lastmoduser, "
				+ "mankind=tipoman, manstatus=statoman, nmsgs, "
				+ "p_iva=partitaiva, phonenumber=telefono, referent=rifcont, "
				+ "sent=inviato, serverbackup1, serverbackup2, servername=null, "
				+ "swmorecode=null, swmoreflag=null "
				+ "from licenzauso";
			DataTable t = Migrazione.eseguiQuery(sourceConn, query, form);
			if (t==null) return false;
			t.TableName = "license";
			return Migrazione.lanciaScript(form, destConn, t, "licenzauso -> license");
		}


        static bool VerifyOneTable(Form form, DataAccess sourceConn, DataAccess destConn, 
                    string tname,string idfield, string codefield) {
            DataTable S = sourceConn.RUN_SELECT(tname, "*", null, null, null, false);
            if (S.Rows.Count == 0) return true;
            DataTable T = destConn.RUN_SELECT(tname, "*", null, null, null, false);
            if (S.Rows.Count > T.Rows.Count) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(form, "La tabella " + tname + " del db di origine non è vuota e non è " +
                    "inclusa in quella del db di destinazione.", "Errore fatale");
                return false;
            }
            CQueryHelper QHC= new CQueryHelper();
            foreach (DataRow SR in S.Rows) {
                string filterkey;
                if (idfield == null)
                    filterkey = QHC.CmpKey(SR);
                else {
                    filterkey = QHC.CmpEq(codefield, SR[codefield]);//FA IL CONFRONTO SUL CODE E NON SULL'ID
                    if (S.Columns.Contains("ayear"))
                        filterkey = QHC.AppAnd(filterkey, QHC.CmpEq("ayear", SR["ayear"]));
                }

                if (T.Select(filterkey).Length == 0) {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show(form,"La riga con chiave "+filterkey+" della tabella "+tname+
                        " del db di origine non è presente nel db di destinazione.", "Errore fatale");
                    return false;
                }
                DataRow TR= T.Select(filterkey)[0];
                foreach (DataColumn C in S.Columns) {
                    if (C.ColumnName == "lt") continue;
                    if (C.ColumnName == "lu") continue;
                    if (C.ColumnName == "ct") continue;
                    if (C.ColumnName == "cu") continue;
                    if (C.ColumnName == idfield) continue; //SALTA l'ID
                    if (!T.Columns.Contains(C.ColumnName)) {
                        MetaFactory.factory.getSingleton<IMessageShower>().Show(form, "La colonna "+C.ColumnName+" della tabella "+tname+
                            " non è presente nel db di destinazione.", "Errore fatale");
                        return false;
                    }
                    if (SR[C.ColumnName].ToString().ToUpper().Trim() != TR[C.ColumnName].ToString().ToUpper().Trim()) {
                        MetaFactory.factory.getSingleton<IMessageShower>().Show(form, "La riga con chiave " + filterkey + " della tabella " + tname +
                            " del db di origine è diversa da quella del db di destinazione.", "Errore fatale");
                        return false;
                    }
                }
            }

            return true;
        }
	
        
        /// <summary>
        /// Verifica che alcune tabelle DBO siano vuote nel db di origine o incluse nel db di destinazione
        /// </summary>
        /// <returns></returns>
        public static bool VerificaTabelleDBO(Form form, DataAccess sourceConn, DataAccess destConn) {
            //Verifica che le seg. tabelle siano uguali o quella in source sia vuota
            string[] tname = new string[]{"account","accountkind","accountlevel", 
                            "inventorysortinglevel","inventorytree",
                            "patrimony","patrimonylevel","placcount","placcountlevel"};
            string[] idfield = new string[]{"idacc","idaccountkind",null, 
                            null,"idinv",
                            "idpatrimony",null,"idplaccount",null};
            string[] codefield = new string[]{"codeacc","description",null, 
                            null,"codeinv",
                            "codepatrimony",null,"codeplaccount",null};
            for (int i = 0; i < tname.Length; i++ ) {
                if (!VerifyOneTable(form, sourceConn, destConn, tname[i],idfield[i],codefield[i])) return false;
            }
            return true;
        }

        /// <summary>
        /// Dato che alcuni campi saranno considerati alla stregua di chiavi alternative, si accerta della loro unicità
        /// </summary>
        /// <param name="form"></param>
        /// <param name="sourceConn"></param>
        /// <param name="destConn"></param>
        /// <returns></returns>
        public static bool VerificaValoriUnici(Form form, DataAccess sourceConn) {
            string[] tname = new string[]{"category","centralizedcategory"};
            string[] fieldname = new string[] { "description", "description" };
            for (int i = 0; i < tname.Length; i++) {
                int total = sourceConn.RUN_SELECT_COUNT(tname[i], null, true);
                int dist = CfgFn.GetNoNullInt32(sourceConn.DO_READ_VALUE(tname[i], null, "COUNT(DISTINCT " + fieldname[i] + "))"));
                if (dist < total) {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show(form, "Il campo " + fieldname[i] + " della tabella " + tname[i] +
                        " contiene valori non tutti diversi.", "Errore fatale");
                    return false;

                }
            }            
            return true;
        }


        public static bool VerificaCorrispondenza(Form form, DataAccess sourceConn, DataAccess destConn) {
            string []tname = new string[] { "registrykind" };
            string []codefield = new string[] { "sortcode" };
            string []descrfield = new string[] { "description" };
            CQueryHelper QHC = new CQueryHelper();
            for (int i = 0; i < tname.Length; i++) {
                DataTable S = sourceConn.RUN_SELECT(tname[i], "*", null, null, null, false);
                DataTable T = destConn.RUN_SELECT(tname[i], "*", null, null, null, false);
                bool ok=true;
                foreach (DataRow RS in S.Rows) {
                    DataRow []RT= T.Select(QHC.CmpEq(codefield[i],RS[codefield[i]]));
                    ok=false;
                    if (RT.Length!=1) break;
                    if (RT[0][descrfield[i]].ToString() != RS[descrfield[i]].ToString()) break;
                    ok = true;
                }
                if (!ok) {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show(form, "La tabella "+tname+" del db di origine contiene dei valori incoerenti "+
                        "con quella del db du destinazione", "Errore fatale");
                    return false;

                }
            }
            return true;
        }
	}
}
