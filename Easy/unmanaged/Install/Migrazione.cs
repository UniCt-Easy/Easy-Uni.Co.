
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


namespace Install
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
				DataTable Cols= Dest.SQLRunner("sp_columns "+TT.TableName+",'"+Dest.GetSys("userdb").ToString()+"'");
                if (Cols.Rows.Count==0)
                    Cols = Dest.SQLRunner("sp_columns " + TT.TableName + ",'dbo'");

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
                MetaFactory.factory.getSingleton<IFormCreationListener>().create(FM, null);
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
			bool ok = Download.RUN_SCRIPT_NONSTOP(destConn, sw.GetStringBuilder(), nomeCopia);
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
		public static bool migraDettOrdineGenerico(Form form, DataAccess sourceConn, DataAccess destConn) {
			string query = "select annotations = camponote, assetkind = tipobene, "
				+ "ct = createtimestamp, cu = createuser, "
				+ "detaildescription = descrdettaglio, "
				+ "discount = sconto, "
				+ "idmankind = 'GENERALE', yman = esercordine, nman = numordine, rownum = numriga, "
				+ "idgroup = numriga, "
				+ "idinv = idclass, "
				+ "lt = lastmodtimestamp, lu = lastmoduser, "
				+ "number = quantita, taxable = imponibile, "
				+ "tax = ROUND(ROUND((ISNULL(imponibile,0)*quantita*(1-ISNULL(sconto,0))),2)*ISNULL(imposta,0),2), "
				+ "taxrate = CONVERT(DECIMAL(19,6),imposta),  "
				+ "toinvoice = 'N', flagmixed = 'N', unabatable = 0, ninvoiced = 0 "
				+ "from dettordinegenerico";

			DataTable tMandateDetail = Migrazione.eseguiQuery(sourceConn, query, form);
			if (tMandateDetail==null) return false;
			tMandateDetail.Columns.Add("idivakind",typeof(string));
			
			if (!impostaIdIvaKind(form, destConn, tMandateDetail)) return false;
			tMandateDetail.TableName = "mandatedetail";
			DataSet ds = new DataSet();
			ds.Tables.Add(tMandateDetail);

			return Migrazione.lanciaScript(form, destConn, ds, "dettordinegenerico -> mandatedetail");
		}

		private static bool impostaIdIvaKind(Form form, DataAccess destConn, DataTable tMandateDetail) {
			DataTable tIvaKind = DataAccess.CreateTableByName(destConn, "ivakind", "*");
			tIvaKind = DataAccess.RUN_SELECT(destConn, "ivakind", "*", null, null, null, null, true);
			foreach(DataRow rMandateDetail in tMandateDetail.Rows) {
				decimal ivaPercentage =  CfgFn.Round( CfgFn.GetNoNullDecimal(rMandateDetail["taxrate"]),6);
				string filter = "(rate = " + QueryCreator.quotedstrvalue(ivaPercentage, false) + ")";
				string filterSQL = "(rate = " + QueryCreator.quotedstrvalue(ivaPercentage, true) + ")";
				DataRow [] rIvaKind = tIvaKind.Select(filter);
				if (rIvaKind.Length > 0) {
					rMandateDetail["idivakind"] = rIvaKind[0]["idivakind"];
				}
				else {
					rMandateDetail["idivakind"] = creaRigaInIvaKind(destConn, tIvaKind, ivaPercentage)["idivakind"];
				}
			}
			tIvaKind.TableName = "ivakind";
			foreach(DataRow r in tIvaKind.Select()) {
				if (r.RowState != DataRowState.Unchanged) continue;
				r.Delete();
				r.AcceptChanges();
			}

			return Migrazione.lanciaScript(form, destConn, tIvaKind, "Aggiungi righe in IVAKIND");
		}

		private static DataRow creaRigaInIvaKind(DataAccess destConn, DataTable tIvaKind, decimal ivaPercentage) {
			DataRow rIvaKind = tIvaKind.NewRow();
			int nRow = tIvaKind.Rows.Count;
			rIvaKind["idivakind"] = "SW_" + (nRow + 1);
			string description = (ivaPercentage != 0) ? "Aliquota al " + (ivaPercentage * 100) + " %" : "Esente IVA";
			rIvaKind["description"] = description;
			rIvaKind["rate"] = ivaPercentage;
			rIvaKind["unabatabilitypercentage"] = 0;
			rIvaKind["active"] = "S";
			rIvaKind["ct"] = DateTime.Now;
			rIvaKind["lt"] = DateTime.Now;
			rIvaKind["cu"] = "Software And More";
			rIvaKind["lu"] = "Software And More";
			tIvaKind.Rows.Add(rIvaKind);
			return rIvaKind;
		}

		/// <summary>
		/// Copia ordinegenerico in mandate ponendo idmankind='GENERALE'
		/// </summary>
		/// <param name="form"></param>
		/// <param name="sourceConn"></param>
		/// <param name="destConn"></param>
		public static bool migraOrdineGenerico(Form form, DataAccess sourceConn, DataAccess destConn) {
			string query = "SELECT active=flagutilizzabile, "
				+ "adate=datacontabile, "
				+ "ct=createtimestamp, "
				+ "cu=createuser, "
				+ "deliveryaddress=indirizzoconsegna, "
				+ "deliveryexpiration=termineconsegna, "
				+ "description=descrizione, "
				+ "doc=documento, "
				+ "docdate=datadocumento, "
				+ "exchangerate=tassocambio, "
				+ "idcurrency=codicevaluta, "
				+ "idexpirationkind=tiposcadenza,"
				+ "idman=codiceresponsabile, "
				+ "idmankind='GENERALE', "
				+ "idreg=codicecreddeb, "
				+ "lt=lastmodtimestamp, "
				+ "lu=lastmoduser, "
				+ "nman=numordine, "
				+ "officiallyprinted=flagstampa, "
				+ "paymentexpiring=scadpagamento, "
				+ "registryreference=riferimentocreddeb, "
				+ "rtf=olenotes, "
				+ "txt=notes, "
				+ "yman=esercordine "
				+ "FROM ordinegenerico";
	
			DataTable tMandate = Migrazione.eseguiQuery(sourceConn, query, form);

			tMandate.TableName = "mandate";
			DataSet ds = new DataSet();
			ds.Tables.Add(tMandate);

			return Migrazione.lanciaScript(form, destConn, ds, "ordinegenerico -> mandate");
		}

		/// <summary>
		/// Copia ordinegenericomovspesa in expensemandate ponendo idmankind='GENERALE'
		/// </summary>
		/// <param name="form"></param>
		/// <param name="sourceConn"></param>
		/// <param name="destConn"></param>
		public static bool migraOrdineGenericoMovSpesa(Form form, DataAccess sourceConn, DataAccess destConn) {
			string query = "select ct=createtimestamp, "
				+ "cu=createuser, "
				+ "idexp=idspesa, "
				+ "idmankind='GENERALE', "
				+ "lt=lastmodtimestamp, "
				+ "lu=lastmoduser, "
				+ "movkind=isnull(tipomovimento,'ORDIN'), "
				+ "nman=numordine, "
				+ "yman=esercordine "
				+ "from ordinegenericomovspesa";

			DataTable tExpenseMandate = Migrazione.eseguiQuery(sourceConn, query, form);
			if (tExpenseMandate==null) return false;

			tExpenseMandate.TableName = "expensemandate";
			DataSet ds = new DataSet();
			ds.Tables.Add(tExpenseMandate);

			return Migrazione.lanciaScript(form, destConn, ds, "ordinegenericomovspesa -> expensemandate");
		}

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
            if (NDONE == NTAB) MetaFactory.factory.getSingleton<IMessageShower>().Show("Script " + filename + " creato correttamente ("
                             + NDONE.ToString() + " tabelle)");


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

            int N_DBO = 0;
            int N_NODBO = 0;
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

                    if (isDbo) {
                        N_DBO++;
                    }
                    else {
                        N_NODBO++;
                    }
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
				MetaFactory.factory.getSingleton<IMessageShower>().Show("Script "+filenameNonDbo+"("+N_NODBO+" SP) e "+filenameDbo+"("+N_DBO+" SP) creati correttamente, per un totale di "
                            + NDONE.ToString()+" viste ");
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
            int N_DBO = 0;
            int N_NODBO = 0;

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
                        N_DBO++;
					}
					else {
						tuttenondbo.Append("if object_id('"+s+"') is not null\r\n\tdrop "+tipo+" "+s+"\r\ngo\r\n");
						tuttenondbo.Append(All);
                        N_NODBO++;
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
				MetaFactory.factory.getSingleton<IMessageShower>().Show("Script "+filenamedbo+"("+N_DBO+" SP) e "+filenamenondbo+
                            "("+N_NODBO+" SP) creati correttamente, per un totale di "
                    + NDONE.ToString()+" SP"
                    );
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
		/// Traduce dettaglioritenute e aggiunge la colonna nbracket=1
		/// </summary>
		/// <param name="form"></param>
		/// <param name="tColName"></param>
		/// <param name="sourceConn"></param>
		/// <param name="destConn"></param>
		public static bool migraDettaglioRitenute(Form form, DataTable tColName, DataAccess sourceConn, DataAccess destConn) {
            DataSet ds = sourceConn.CallSP("calcola_dettaglioritenute", new object[] { },false,0);
            if((ds == null) || (ds.Tables.Count == 0)) return false;
            ds.Tables[0].TableName = "expensetax";
            ds.Tables[0].Columns.Add("nbracket", typeof(int));

            foreach(DataColumn C in ds.Tables[0].Columns) {
                if(C.ColumnName == "imponibilenetto") {
                    C.ColumnName = "taxablenet";
                    continue;
                }

                string filtro = "(oldtable = 'dettaglioritenute') AND (oldcol = "
                    + QueryCreator.quotedstrvalue(C.ColumnName, false) + ")";
                DataRow[] COL = tColName.Select(filtro);
                if(COL.Length == 0) continue;
                string newCol = COL[0]["newcol"].ToString();
                if(newCol.StartsWith("delete")) {
                    ds.Tables[0].Columns.Remove(C.ColumnName);
                }
                else {
                    C.ColumnName = COL[0]["newcol"].ToString();
                }
            }

            foreach(DataRow rExpenseTax in ds.Tables[0].Rows) {
                rExpenseTax["nbracket"] = 1;
            }
            return lanciaScript(form, destConn, ds, "dettaglioritenute -> expensetax");
		}

		public static bool migraContrattoOcc(Form form, DataTable tColName, DataAccess sourceConn, DataAccess destConn) {
			DataTable tCasualContract = leggiETraduciTabella("contrattoocc", sourceConn, tColName, form,  
				null, "completed='S'");
			if (tCasualContract==null) return false;
			tCasualContract.TableName = "casualcontract";
			return lanciaScript(form, destConn, tCasualContract, "contrattoocc -> casualcontract");
		}

		public static bool migraDettBilancioPrevisione(Form form, DataTable tColName, DataAccess sourceConn, DataAccess destConn) {
			DataTable tCasualContract = leggiETraduciTabella("dettbilancioprevisione", sourceConn, tColName, form,  
				null, "idupb='0001'");
			if (tCasualContract==null) return false;
			tCasualContract.TableName = "prevfindetail";
			return lanciaScript(form, destConn, tCasualContract, "dettbilancioprevisione -> prevfindetail");
		}
		public static bool migraDettBilancioAssestamento(Form form, DataTable tColName, DataAccess sourceConn, DataAccess destConn) {
			DataTable tCasualContract = leggiETraduciTabella("dettbilancioassestamento", sourceConn, tColName, form,  
				null, "idupb='0001'");
			if (tCasualContract==null) return false;
			tCasualContract.TableName = "finbalancedetail";
			return lanciaScript(form, destConn, tCasualContract, "dettbilancioassestamento -> finbalancedetail");
		}
		public static bool migraTabMissione(Form form, DataTable tColName, DataAccess sourceConn, DataAccess destConn) {
			DataTable tItineration = leggiETraduciTabella("missione", sourceConn, tColName, form, 
				null, "completed='S'");
			if (tItineration==null) return false;
			tItineration.TableName = "itineration";
			return lanciaScript(form, destConn, tItineration, "missione -> itineration");
		}

		public static bool migraContrattoDip(Form form, DataTable tColName, DataAccess sourceConn, DataAccess destConn) {
			DataTable tWageAddition = leggiETraduciTabella("contrattodip", sourceConn, tColName, form,
				null, "completed='S'");
			if (tWageAddition==null) return false;
			tWageAddition.TableName = "wageaddition";
			return lanciaScript(form, destConn, tWageAddition, "contrattodip -> wageaddition");
		}

        public static bool migraVariazioni(Form form, DataAccess sourceConn, DataAccess destConn, string IoE) {
            string tName_src = (IoE == "I") ? "variazioneentrata" : "variazionespesa";
            string tMiddle_src = (IoE == "I") ? "ivavarentrata" : "ivavarspesa";
            string idfield_src = (IoE == "I") ? "identrata" : "idspesa";
            string tName_dest = (IoE == "I") ? "incomevar" : "expensevar";
            string idfield_dest = (IoE == "I") ? "idinc" : "idexp";

            string campoInPiu = (IoE == "I") ? "" : " ,idpayment = M.idpagamento, autocode = null ";

            string query = "SELECT " + idfield_dest + " = M." + idfield_src +
            ", nvar = M.numvariazione, adate = M.datacontabile, amount = M.importo, " +
            " autokind = M.tipoautomatismo, ct = M.createtimestamp, cu = M.createuser, lt = M.lastmodtimestamp, " +
            " lu = M.lastmoduser, description = M.descrizione, doc = M.documento, docdate = M.datadocumento, " +
            " rtf = M.olenotes, txt = M.notes, trasferkind = M.tipotrasferimento, " +
            " yvar = M.esercvariazione, idinvkind = D.codicetipodoc, yinv = D.esercdocumento, ninv = D.numdocumento, " +
            " movkind = D.tipomovimento " + campoInPiu +
            " FROM " + tName_src + " M " +
            " LEFT OUTER JOIN " + tMiddle_src + " D " +
            " ON M." + idfield_src + " = D." + idfield_src +
            " AND M.numvariazione = D.numvariazione ";

            DataTable tVar = DataAccess.SQLRunner(sourceConn, query);

            if (tVar == null) {
                string msg = "Errore nella migrazione delle variazioni di " + tName_src;
                MetaFactory.factory.getSingleton<IMessageShower>().Show(form, msg, "Errore");
                return false;
            }

            tVar.TableName = tName_dest;
            string nomeCopia = "(" + tName_src + "," + tMiddle_src + " -> " + tName_dest + ")";
            return lanciaScript(form, destConn, tVar, nomeCopia);
        }

		public static bool migraMovimentiFinanziari(Form form, DataAccess sourceConn, DataAccess destConn,
			string IoE) {
			string tName_src = (IoE == "I") ? "entrata" : "spesa";
			string idfield = (IoE == "I") ? "identrata" : "idspesa";
			string tName_dest = (IoE == "I") ? "income" : "expense";		
			string maxphase = destConn.DO_READ_VALUE(tName_dest+"phase",null,"max(nphase)").ToString();				

			string addfield = (IoE == "I") ? "idpro" : "idpay";
			string addfieldQuery = addfield + " = null";

			string kind = (IoE == "I") ? "C" : "D";

			string listaCampiMovFin_src = idfield + ", esercmovbancario, nummovbancario";
			string query = "";
			if (IoE == "I") {
				query = "SELECT "
					+ "idinc = identrata, nphase = codicefase, parentidinc = livsupidentrata, idreg = e.codicecreddeb, "
					+ "ycreation = eserccreazione, ymov = esercmovimento, nmov = nummovimento, description = e.descrizione, "
					+ "doc = documento, docdate = datadocumento, expiration = datascadenza, adate = e.datacontabile, "
					+ "idman = codiceresponsabile, "
					+ "ypro = esercdocincasso, npro = numdocincasso, idpro = m.numoperazione, "
					+ "amount = e.importo, nbill = e.numbolletta, "
					+ "autocode = codiceautomatismo, autokind = tipoautomatismo, "
					+ "fulfilled = flagcopertura, idproceeds = idincasso, idpayment = idpagamento, "
					+ "lt=e.lastmodtimestamp, lu=e.lastmoduser, cu=e.createuser,ct=e.createtimestamp, "
					+ "txt = e.notes, rtf = e.olenotes "
					+ "FROM entrata e "
					+ "LEFT OUTER JOIN movimentobancario m "
					+ "ON e.esercmovbancario = m.esercmovbancario "
					+ "AND e.nummovbancario = m.nummovbancario";
			}
			else {
				query = "SELECT "
					+ "idexp = idspesa, idformerexpense = idparent, nphase = codicefase, parentidexp = livsupidspesa, "
					+ "idreg = s.codicecreddeb, ycreation = eserccreazione, ymov = esercmovimento, nmov = nummovimento, "
					+ "description = s.descrizione,	regmodcode = tipomodalita, idpaymethod = codicemodalita, "
					+ "cin = cin, idbank = codicebanca, idcab = codicesportello, cc = numeroconto, "
					+ "iddeputy = codicedelegato, refexternaldoc = rifdocumentoesterno, "
					+ "doc = documento, docdate = datadocumento, expiration = datascadenza, adate = s.datacontabile, "
					+ "paymentdescr = descpagamento, idman = codiceresponsabile, "
					+ "idser = codiceprestazione, servicestop = datafineprestazione, servicestart = datainizioprestazione, "
					+ "ypay = esercdocpagamento, npay = numdocpagamento, idpay = m.numoperazione, "
					+ "amount = s.importo, admintaxamount = importocontributi, ivaamount = importoprestazione1, "
					+ "clawbackamount = importorecuperi, employtaxamount = importoritenute, "
					+ "autocode = codiceautomatismo, autokind = tipoautomatismo, nbill = s.numbolletta, "
					+ "autoclawbackflag = flagautorecuperi, autotaxflag = flagautoritenute, "
					+ "fulfilled = flagcopertura, idproceeds = idincasso, idpayment = idpagamento, "
					+ "lt=s.lastmodtimestamp, lu=s.lastmoduser, cu=s.createuser,ct=s.createtimestamp, "
					+ "txt = s.notes, rtf = s.olenotes "
					+ "FROM spesa s "
					+ "LEFT OUTER JOIN movimentobancario m "
					+ "ON s.esercmovbancario = m.esercmovbancario "
					+ "AND s.nummovbancario = m.nummovbancario";
			}

			string errMess;
			DataTable tMovFin_src = sourceConn.SQLRunner(query, 0, out errMess);
			if (errMess != null) {
				MetaFactory.factory.getSingleton<IMessageShower>().Show(form, errMess);
				return false;
			}
			tMovFin_src.TableName = tName_dest;

			string nomeCopia = tName_src + " -> " + tName_dest;
			return lanciaScript(form, destConn, tMovFin_src, nomeCopia);
		}

		/// <summary>
		/// Copia dettdocumentoiva in invoicedetail
		/// </summary>
		/// <param name="form"></param>
		/// <param name="sourceConn"></param>
		/// <param name="destConn"></param>
		public static bool migraDettDocumentoIva(Form form, DataAccess sourceConn, DataAccess destConn) {
			string query = "select annotations=DETT.camponote, ct=DETT.createtimestamp, "
				+ "cu=DETT.createuser, detaildescription=DETT.descrdettaglio, idinvkind=DETT.codicetipodoc, "
				+ "idivakind=DETT.codicetipoiva, number = 1,  "
				+ "lt=DETT.lastmodtimestamp, lu=DETT.lastmoduser, idconto = DETT.idconto, "
				+ "ninv=DETT.numdocumento, rownum=DETT.numriga, idgroup=DETT.numriga, "
				+ "taxable=DETT.imponibile, tax=DETT.imposta, "
				+ "unabatable=DETT.indetraibile, yinv=DETT.esercdocumento, idcen = DOC.idcentrospesa "
				+ "from dettdocumentoiva DETT "
				+ "join documentoiva DOC "
				+ "on DOC.codicetipodoc = DETT.codicetipodoc "
				+ "and DOC.esercdocumento = DETT.esercdocumento "
				+ "and DOC.numdocumento = DETT.numdocumento ";

			DataTable tInvoiceDetail = Migrazione.eseguiQuery(sourceConn, query, form);
			if (tInvoiceDetail==null) return false;
			tInvoiceDetail.Columns.Add("idupb",typeof(string));
			tInvoiceDetail.Columns.Add("idsor1",typeof(string));
			tInvoiceDetail.TableName = "invoicedetail";

			foreach(DataRow rDetail in tInvoiceDetail.Rows) {
				if (Upb.tCdsUpb == null) break;
				if (rDetail["idcen"] == DBNull.Value) continue;
                DataRow[] rUpb = Upb.tCdsUpb.Select("(idcen = " + 
                        QueryCreator.quotedstrvalue(rDetail["idcen"].ToString().Remove(0,2), false) + ")");
				if (rUpb.Length == 0) continue;
				rDetail["idupb"] = rUpb[0]["idupb"];
			}

			foreach(DataRow rDetail in tInvoiceDetail.Rows) {
				if (tPianoSorting == null) break;
				if (rDetail["idconto"] == DBNull.Value) continue;
				DataRow [] rPiano = tPianoSorting.Select("(idsor = " 
                    + QueryCreator.quotedstrvalue(rDetail["idconto"], false) + ")");
				if (rPiano.Length == 0) continue;
				rDetail["idsor1"] = rPiano[0]["idsor"];
			}

			tInvoiceDetail.Columns.Remove("idcen");
			tInvoiceDetail.Columns.Remove("idconto");

			DataSet ds = new DataSet();
			ds.Tables.Add(tInvoiceDetail);

			return Migrazione.lanciaScript(form, destConn, ds, "dettdocumentoiva -> invoicedetail");
		}

		/// <summary>
		/// Per ogni riga di tipodocumentoiva crea n righe di invoicekindyear dove n è il numero di esercizi
		/// </summary>
		/// <param name="form"></param>
		/// <param name="sourceConn"></param>
		/// <param name="destConn"></param>
		public static bool creaInvoicekindyear(Form form, DataAccess sourceConn, DataAccess destConn) {
			string q1 = "select min(esercizio), max(esercizio) from esercizio";
			DataTable tAccountingYear = Migrazione.eseguiQuery(sourceConn, q1, form);
			if (tAccountingYear==null) return false;
			short min = (short) tAccountingYear.Rows[0][0];
			short max = (short) tAccountingYear.Rows[0][1];
			string q2 = "select idinvkind=codicetipodoc, ayear="+min
				+ ", cu=createuser, ct=createtimestamp, lu=lastmoduser, lt=lastmodtimestamp "
				+ "from tipodocumentoiva";
			DataTable tInvoiceKindYear = Migrazione.eseguiQuery(sourceConn, q2, form);
			if (tInvoiceKindYear==null) return false;
			tInvoiceKindYear.TableName = "invoicekindyear";
			DataRow[] rIKY = tInvoiceKindYear.Select();
			for (int i=min+1; i<=max; i++) {
				foreach (DataRow rOld in rIKY) {
					DataRow rNew = tInvoiceKindYear.NewRow();
					foreach (DataColumn c in tInvoiceKindYear.Columns) {
						if (c.ColumnName == "ayear") {
							rNew[c] = i;
						} else {
							rNew[c] = rOld[c];
						}
					}
					tInvoiceKindYear.Rows.Add(rNew);
				}
			}
			return Migrazione.lanciaScript(form, destConn, tInvoiceKindYear, "tipodocumentoiva -> invoicekindyear"); 
		}

		public static bool creaMovBancari(Form form, DataAccess sourceConn, DataAccess destConn, string IoE, Hashtable H) {
			// PAYMENT_BANK - PROCEEDS_BANK (Tabelle dei movimenti bancari)
			string p_bank = (IoE == "I") ? "proceeds_bank" : "payment_bank";
			DataTable tPXXX_Bank = DataAccess.CreateTableByName(destConn, p_bank, "*");
			tPXXX_Bank.Clear();

			string kind = (IoE == "I") ? "C" : "D";
            string q1 = "";
            if (kind == "D")
            {
                q1 = "SELECT "
                    + "nummovbancario, esercmovbancario, "
                    + "tipomovbancario, codicecreddeb, descrizione, "
                    + "esercdocumento, numdocumento, "
                    + "importo, rifbanca, numoperazione= isnull(numoperazione,0) , "
                    + "createuser,createtimestamp,lastmoduser,lastmodtimestamp,"
                    + "dataoperazione, datavaluta "
                    + "FROM movimentobancario "
                    + "WHERE tipomovbancario = '" + kind + "' and esercdocumento is not null and numdocumento is not null "
                    + "AND EXISTS (SELECT idspesa from spesa WHERE spesa.esercmovbancario = movimentobancario.esercmovbancario AND "
                    + "spesa.nummovbancario = movimentobancario.nummovbancario ) " 
                    + " order by  esercdocumento,numdocumento,isnull(numoperazione,0)";
            }
            else
            {
                q1 = "SELECT "
                  + "nummovbancario, esercmovbancario, "
                  + "tipomovbancario, codicecreddeb, descrizione, "
                  + "esercdocumento, numdocumento, "
                  + "importo, rifbanca, numoperazione= isnull(numoperazione,0) , "
                  + "createuser,createtimestamp,lastmoduser,lastmodtimestamp,"
                  + "dataoperazione, datavaluta "
                  + "FROM movimentobancario "
                  + "WHERE tipomovbancario = '" + kind + "' and esercdocumento is not null and numdocumento is not null "
                  + "AND EXISTS (SELECT identrata from entrata WHERE entrata.esercmovbancario = movimentobancario.esercmovbancario AND "
                  + "entrata.nummovbancario = movimentobancario.nummovbancario ) "
                  + " order by  esercdocumento,numdocumento,isnull(numoperazione,0)" ;

            }
			DataTable tMovBancario_src = eseguiQuery(sourceConn, q1, form);
			if (tMovBancario_src == null) return false;

            string yfield = (IoE == "I") ? "ypro" : "ypay";
            string nfield = (IoE == "I") ? "npro" : "npay";
            string idfield = (IoE == "I") ? "idpro" : "idpay";

            foreach(DataRow rmov in tMovBancario_src.Rows) {
                int oldnumop = CfgFn.GetNoNullInt32(rmov["numoperazione"]);
                int newop = CfgFn.GetNoNullInt32(GetNumOperazioneForNewMov(tPXXX_Bank, rmov,
                    yfield, nfield, idfield));
                if(newop != oldnumop) SetNumOperazione(H,
                    rmov["esercmovbancario"], rmov["nummovbancario"], newop);
                DataRow rDest = tPXXX_Bank.NewRow();
                rDest[yfield] = rmov["esercdocumento"];
                rDest[nfield] = rmov["numdocumento"];
                rDest[idfield] =newop;
                rDest["idreg"] = rmov["codicecreddeb"];
                rDest["description"] = rmov["descrizione"];
                rDest["amount"] = rmov["importo"];
                rDest["ct"] = rmov["createtimestamp"];
                rDest["cu"] = rmov["createuser"];
                rDest["lt"] = rmov["lastmodtimestamp"];
                rDest["lu"] = rmov["lastmoduser"];

                tPXXX_Bank.Rows.Add(rDest);

            }

            //fillPBank(tMovBancario_src, tPXXX_Bank, IoE);

            /*
			foreach(DataRow rMovBancario in tMovBancario_src.Rows) {
				fillPBank(rMovBancario, tPXXX_Bank, IoE);
			}
            */

			string nomeCopia = "(movimentobancario -> " + p_bank;
			return lanciaScript(form, destConn, tPXXX_Bank, nomeCopia);
		}
        static object GetNumOperazioneForNewMov(DataTable TMov, DataRow R,string yfield, string nfield,string idfield) {
            string filter= "("+yfield+"="+R["esercdocumento"].ToString()+")AND"+
                           "("+nfield+"="+R["numdocumento"].ToString()+")AND"+
                           "("+idfield+"="+R["numoperazione"].ToString()+")";
            if (TMov.Select(filter).Length==0) return R["numoperazione"];
            int N = CfgFn.GetNoNullInt32(R["numoperazione"])+1;
            while(true) {
                filter = "(" + yfield + "=" + R["esercdocumento"].ToString() + ")AND" +
                           "(" + nfield + "=" + R["numdocumento"].ToString() + ")AND" +
                           "(" + idfield + "=" +N.ToString() + ")";
                if(TMov.Select(filter).Length == 0) return N;
                N++;
            }



        }
        static int GetNumOperazione(Hashtable H, object yban, object nban, object numop) {
            if(H[yban.ToString() + "|" + nban.ToString()] == null)
                return CfgFn.GetNoNullInt32(numop);
            return CfgFn.GetNoNullInt32(H[yban.ToString() + "|" + nban.ToString()]);
        }
        static void SetNumOperazione(Hashtable H, object yban, object nban, object numop) {
            H[yban.ToString() + "|" + nban.ToString()] = CfgFn.GetNoNullInt32(numop);
        }

		private static bool creaEsitiTotali(Form form, DataAccess sourceConn, DataAccess destConn, string IoE, Hashtable H) {
			string yfield = (IoE == "I") ? "ypro" : "ypay";
			string nfield = (IoE == "I") ? "npro" : "npay";
			string idfield = (IoE == "I") ? "idpro" : "idpay";
			string kind = (IoE == "I") ? "C" : "D";
			string tabMovFin_dest = (IoE == "I") ? "income" : "expense";
			string idfieldmov_dest = (IoE == "I") ? "idinc" : "idexp";
			
			object maxphase_dest = destConn.GetSys("max" + tabMovFin_dest + "phase");
			string filterPhase = "(nphase = '" + maxphase_dest + "')";

			string query = "SELECT "
				+ "nummovbancario, esercmovbancario, "
				+ "tipomovbancario, "
				+ "esercdocumento, numdocumento, "
				+ "importo, rifbanca, numoperazione=isnull(numoperazione,0)  , "
				+ "createuser,createtimestamp,lastmoduser,lastmodtimestamp,"
				+ "dataoperazione, datavaluta "
				+ "from movimentobancario "
				+ "where tipomovbancario = '" + kind + "' "
				+ "and flagesito = 'S' and esercdocumento is not null and numdocumento is not null";

			// Tabelle di PARTENZA
			DataTable tMovBancario_src = eseguiQuery(sourceConn, query, form);
			if (tMovBancario_src == null) return false;

			// BANKTRANSACTION (Tabella degli esiti)
			DataTable bankTransaction = DataAccess.CreateTableByName(destConn, "banktransaction", "*");
			bankTransaction.Clear();

			string tabMovFin_src = (IoE == "I") ? "entrataview" : "spesaview";
			string idfieldmov_src = (IoE == "I") ? "identrata" : "idspesa";

			string listaCampiMov_src = idfieldmov_src + ", importocorrente, esercmovbancario, nummovbancario ";

			DataTable tMovFin_src = DataAccess.RUN_SELECT(sourceConn, tabMovFin_src, listaCampiMov_src, null, "(esercmovbancario IS NOT NULL)"
				, null, null, true);
			if (tMovFin_src == null) return false;

			foreach(DataRow rMovBancario in tMovBancario_src.Rows) {
				string filter = "(esercmovbancario = '" + rMovBancario["esercmovbancario"]
					+ "') AND (nummovbancario = '" + rMovBancario["nummovbancario"] + "')";
 				
				DataRow [] MovFin = tMovFin_src.Select(filter);
				// Passo 2. Per ogni mov. finanziario aggiorno il campo IDPAY (IDPRO)
				foreach(DataRow rMov in MovFin) {
					decimal importo = CfgFn.GetNoNullDecimal(rMov["importocorrente"]); 
					fillBankTransaction(destConn, rMovBancario, rMov[idfieldmov_src], bankTransaction, IoE, importo,H);
				}
			}
			
			return lanciaScript(form, destConn, bankTransaction, "movimentobancario -> banktransaction");
		}

		private static bool creaEsitiParziali(Form form, DataAccess sourceConn, DataAccess destConn, string IoE,Hashtable H) {
			string yfield = (IoE == "I") ? "ypro" : "ypay";
			string nfield = (IoE == "I") ? "npro" : "npay";
			string idfield = (IoE == "I") ? "idpro" : "idpay";
			string kind = (IoE == "I") ? "C" : "D";
			string tabMovFin_dest = (IoE == "I") ? "income" : "expense";
			string idfieldmov_dest = (IoE == "I") ? "idinc" : "idexp";

			object maxphase_dest = destConn.GetSys("max" + tabMovFin_dest + "phase");
			string filterPhase = "(nphase = '" + maxphase_dest + "')";

			// BANKTRANSACTION (Tabella degli esiti)
			DataTable bankTransaction = DataAccess.CreateTableByName(destConn, "banktransaction", "*");
			bankTransaction.Clear();

			string q2 = "SELECT "
				+ "m.nummovbancario, m.esercmovbancario, "
				+ "m.tipomovbancario, "
				+ "m.esercdocumento, m.numdocumento, "
				+ "d.importo, d.rifbanca, numoperazione= isnull(m.numoperazione,0) , "
				+ "d.lastmoduser, d.lastmodtimestamp, d.createuser, d.createtimestamp, "
				+ "d.dataoperazione, d.datavaluta "
				+ "from movimentobancario m "
				+ "join dettmovimentobancario d "
				+ "on m.esercmovbancario = d.esercmovbancario "
				+ "and m.nummovbancario = d.nummovbancario "
				+ "where m.tipomovbancario = '" + kind + "' "
				+ "and m.flagesito = 'P' and m.esercdocumento is not null and m.numdocumento is not null";

			string tabMovFin_src = (IoE == "I") ? "entrataview" : "spesaview";
			string idfieldmov_src = (IoE == "I") ? "identrata" : "idspesa";

			// Dettagli mov. bancari
			DataTable tDettMovBanc = eseguiQuery(sourceConn, q2, form);
			if (tDettMovBanc == null) return false;

			string listaCampiMov_src = idfieldmov_src + ", importo, importocorrente, esercmovbancario, nummovbancario";
			if (IoE == "E") {
				listaCampiMov_src += ", importoritenute";
			}
            // Movimenti finanziari in db origine 
			DataTable tMovFin_src = DataAccess.RUN_SELECT(sourceConn, tabMovFin_src, 
                    listaCampiMov_src, null, "(esercmovbancario IS NOT NULL)"
				, null, null, true);
			if (tMovFin_src == null) return false;

			// Tabella temporanea dei movimenti finanziari
			DataTable temp = new DataTable();
			temp.Columns.Add("idmov");
			temp.Columns.Add("curramount");
			temp.Columns.Add("performedamount");
			temp.Columns.Add("residual");

            //Man mano che le righe di dettmovbancario sono esitate sono cancellate da dettmovbancario
			if (!creaEsitiDoveUnMovimentoBancarioUnMovimentoFinanziario(form, destConn, tDettMovBanc, tMovFin_src, IoE,H)) {
				return false;
			}
			tDettMovBanc.AcceptChanges();

			if (!creaEsitiDoveImportoCorrMovFinIsImportoEsito(form, destConn, tDettMovBanc, tMovFin_src, temp, IoE,H)) {
				return false;
			}
			tDettMovBanc.AcceptChanges();

			if (IoE == "E") {
				if (!creaEsitiDoveImportoNettoMovSpesaIsImportoEsito(form, destConn, tDettMovBanc, tMovFin_src, temp,H)) {
					return false;
				}
				tDettMovBanc.AcceptChanges();

				if (!creaEsitiDoveImportoRitMovSpesaIsImportoEsito(form, destConn, tDettMovBanc, tMovFin_src, temp,H)) {
					return false;
				}
				tDettMovBanc.AcceptChanges();
			}
			return creaEsitiACoperturaProgressiva(form, destConn, tDettMovBanc, tMovFin_src, temp, IoE,H);
		}

		private static bool creaEsitiDoveUnMovimentoBancarioUnMovimentoFinanziario(Form form, DataAccess destConn, 
			DataTable tDettMovBanc, DataTable tMovFin_src, string IoE,Hashtable H) {

			string idfieldmov_src = (IoE == "I") ? "identrata" : "idspesa";
            string tipo = "a debito";
            if(IoE == "I") tipo = "a credito";
            
			// BANKTRANSACTION (Tabella degli esiti)
			DataTable bankTransaction = DataAccess.CreateTableByName(destConn, "banktransaction", "*");
			bankTransaction.Clear();

            //Per ogni dettmovbancario del db di origine:
			foreach(DataRow rEsito in tDettMovBanc.Select()) {
				string filter = "(esercmovbancario = '" + rEsito["esercmovbancario"]
					+ "') AND (nummovbancario = '" + rEsito["nummovbancario"] + "')";

				DataRow [] MovFin = tMovFin_src.Select(filter);
				if (MovFin.Length == 0) continue;

				// Caso 1. Esiste un unico movimento finanziario associato al movimento bancario -> gli esiti sono associati tutti allo stesso movimento
				if (MovFin.Length == 1) {
					DataRow rMov = MovFin[0];
					//decimal importo = CfgFn.GetNoNullDecimal(rMov["importocorrente"]);
					decimal importo = CfgFn.GetNoNullDecimal(rEsito["importo"]);
                    decimal importomovfin = CfgFn.GetNoNullDecimal(rMov["importocorrente"]);
                    if(importo > importomovfin) {
                        MetaFactory.factory.getSingleton<IMessageShower>().Show("Il movimento bancario " + tipo + " " +
                            rEsito["esercmovbancario"].ToString() + "/" + rEsito["nummovbancario"].ToString() +
                            " ha un importo pari a " + importo.ToString("c")+
                            " ma IL mov.finanziario associato ha importo "+importomovfin.ToString("c")+
                            " pertanto non sarà possibile esitarlo totalmente");
                        importo = importomovfin;

                    }
					// Creazione dell'esito (BANKTRANSACTION)
					fillBankTransaction(destConn, rEsito, rMov[idfieldmov_src], bankTransaction, IoE, importo,H);
                    rEsito.Delete();
                }
			}
			return lanciaScript(form, destConn, bankTransaction, "Generazione Esiti dove c'è un mov. fin. per ogni mov. bancario");
		}

		private static bool creaEsitiDoveImportoCorrMovFinIsImportoEsito(Form form, DataAccess destConn,
			DataTable tDettMovBanc, DataTable tMovFin_src, DataTable temp, string IoE,Hashtable H) {

			string idfieldmov_src = (IoE == "I") ? "identrata" : "idspesa";

			// BANKTRANSACTION (Tabella degli esiti)
			DataTable bankTransaction = DataAccess.CreateTableByName(destConn, "banktransaction", "*");
			bankTransaction.Clear();

			foreach(DataRow rEsito in tDettMovBanc.Select()) {
				decimal importoEsito = CfgFn.GetNoNullDecimal(rEsito["importo"]);
				string filter = "(esercmovbancario = '" + rEsito["esercmovbancario"]
					+ "') AND (nummovbancario = '" + rEsito["nummovbancario"] + "')";
				
				DataRow [] MovFin = tMovFin_src.Select(filter);
				if (MovFin.Length == 0) continue;

				if (MovFin.Length > 0) {
					// Sotto Caso 2.1. Esiste un movimento finanziario il cui importo è pari a quello dell'esito
                    foreach(DataRow rMovFin in MovFin) {
                        decimal importoCorrente = CfgFn.GetNoNullDecimal(rMovFin["importocorrente"]);
                        if(importoCorrente != importoEsito) continue;

                        //Ha trovato un mov. finanziario con importo uguale a quello dell'esito
                        //Verifica di non averlo già utilizzato per un altro esito

                        string filterTemp = "(idmov = " + QueryCreator.quotedstrvalue(rMovFin[idfieldmov_src], false)
                            + ")";
                        DataRow[] rmovtemp = temp.Select(filterTemp);
                        if((rmovtemp.Length > 0) && (CfgFn.GetNoNullDecimal(rmovtemp[0]["residual"]) < importoEsito)) continue;

                        fillBankTransaction(destConn, rEsito, rMovFin[idfieldmov_src], bankTransaction, IoE, importoEsito,H);

                        if(rmovtemp.Length == 0) {
                            DataRow rTemp = temp.NewRow();
                            rTemp["idmov"] = rMovFin[idfieldmov_src];
                            rTemp["curramount"] = importoEsito;
                            rTemp["performedamount"] = importoEsito;
                            rTemp["residual"] = 0;
                            temp.Rows.Add(rTemp);
                        }
                        else {
                            rmovtemp[0]["performedamount"] = CfgFn.GetNoNullDecimal(rmovtemp[0]["performedamount"]) + importoEsito;
                            rmovtemp[0]["residual"] = CfgFn.GetNoNullDecimal(rmovtemp[0]["residual"]) - importoEsito;

                        }
                        rEsito.Delete();

                        break;
                    }

				}
			}
			return lanciaScript(form, destConn, bankTransaction, "Generazione Esiti dove c'è un mov. fin. con importo pari all'esito");
		}

		private static bool creaEsitiDoveImportoNettoMovSpesaIsImportoEsito	(Form form, DataAccess destConn,
			DataTable tDettMovBanc, DataTable tMovFin_src, DataTable temp,Hashtable H) {

			string idfieldmov_src = "idspesa";

			// BANKTRANSACTION (Tabella degli esiti)
			DataTable bankTransaction = DataAccess.CreateTableByName(destConn, "banktransaction", "*");
			bankTransaction.Clear();
			
			foreach(DataRow rEsito in tDettMovBanc.Select()) {
				decimal importoEsito = CfgFn.GetNoNullDecimal(rEsito["importo"]);
				string filter = "(esercmovbancario = '" + rEsito["esercmovbancario"]
					+ "') AND (nummovbancario = '" + rEsito["nummovbancario"] + "')";
				
				DataRow [] MovFin = tMovFin_src.Select(filter);
				if (MovFin.Length == 0) continue;

				if (MovFin.Length > 0) {
					// Sotto Caso 2.2. (Solo Spesa) Esiste un movimento di spesa il cui importo netto è pari a quello dell'esito
					// Attenzione si passa al Sotto Caso 2.2. solo se il Sotto Caso 2.1. è fallito
					foreach(DataRow rMovFin in MovFin) {
						decimal importoNetto = CfgFn.GetNoNullDecimal(rMovFin["importo"]) - CfgFn.GetNoNullDecimal(rMovFin["importoritenute"]);
						if (importoNetto != importoEsito) continue;

						// Se in TEMP è presente il movimento vuol dire che l'ho esitato completamente e quindi non vado avanti
						string filterTemp = "(idmov = " + QueryCreator.quotedstrvalue(rMovFin[idfieldmov_src], false)
							+ ")";
						DataRow [] rmovtemp = temp.Select(filterTemp);
						if ((rmovtemp.Length > 0) && (CfgFn.GetNoNullDecimal(rmovtemp[0]["residual"]) < importoEsito)) continue;

						fillBankTransaction(destConn, rEsito, rMovFin[idfieldmov_src], bankTransaction, "E", importoEsito,H);

						if (rmovtemp.Length > 0) {
							rmovtemp[0]["performedamount"] = CfgFn.GetNoNullDecimal(rmovtemp[0]["performedamount"])
								+ importoEsito;
							rmovtemp[0]["residual"] = CfgFn.GetNoNullDecimal(rmovtemp[0]["residual"]) - importoEsito;
						}
						else {
							DataRow rTemp = temp.NewRow();
							rTemp["idmov"] = rMovFin[idfieldmov_src];
							rTemp["curramount"] = rMovFin["importocorrente"];
							rTemp["performedamount"] = importoEsito;
							decimal residuo = CfgFn.GetNoNullDecimal(rTemp["curramount"]) - importoEsito;
							rTemp["residual"] = residuo;
							temp.Rows.Add(rTemp);

                        }
                        rEsito.Delete();

						break;
					}
				}
			}

			return lanciaScript(form, destConn, bankTransaction, "Generazione Esiti dove c'è un mov. di spesa con importo netto pari all'esito");
		}

		private static bool creaEsitiDoveImportoRitMovSpesaIsImportoEsito (Form form, DataAccess destConn,
			DataTable tDettMovBanc, DataTable tMovFin_src, DataTable temp,Hashtable H) {

			string idfieldmov_src = "idspesa";

			// BANKTRANSACTION (Tabella degli esiti)
			DataTable bankTransaction = DataAccess.CreateTableByName(destConn, "banktransaction", "*");
			bankTransaction.Clear();

			foreach(DataRow rEsito in tDettMovBanc.Select()) {
				decimal importoEsito = CfgFn.GetNoNullDecimal(rEsito["importo"]);
				string filter = "(esercmovbancario = '" + rEsito["esercmovbancario"]
					+ "') AND (nummovbancario = '" + rEsito["nummovbancario"] + "')";
				
				DataRow [] MovFin = tMovFin_src.Select(filter);
				if (MovFin.Length == 0) continue;

				if (MovFin.Length > 0) {
					// Sotto Caso 2.2. (Solo Spesa) Esiste un movimento di spesa il cui importo netto è pari a quello dell'esito
					// Attenzione si passa al Sotto Caso 2.2. solo se il Sotto Caso 2.1. è fallito
					foreach(DataRow rMovFin in MovFin) {
						decimal importoRitenute = CfgFn.GetNoNullDecimal(rMovFin["importoritenute"]);
						if (importoRitenute != importoEsito) continue;

						// Se in TEMP è presente il movimento vuol dire che l'ho esitato completamente e quindi non vado avanti
						string filterTemp = "(idmov = " + QueryCreator.quotedstrvalue(rMovFin[idfieldmov_src], false)
							+ ")";
						DataRow [] rmovtemp = temp.Select(filterTemp);
						if ((rmovtemp.Length > 0) && (CfgFn.GetNoNullDecimal(rmovtemp[0]["residual"]) < importoEsito)) continue;

						fillBankTransaction(destConn, rEsito, rMovFin[idfieldmov_src], bankTransaction, "E", importoEsito,H);

						if (rmovtemp.Length > 0) {
							rmovtemp[0]["performedamount"] = CfgFn.GetNoNullDecimal(rmovtemp[0]["performedamount"])
								+ importoEsito;
							rmovtemp[0]["residual"] = CfgFn.GetNoNullDecimal(rmovtemp[0]["residual"]) - importoEsito;
						}
						else {
							DataRow rTemp = temp.NewRow();
							rTemp["idmov"] = rMovFin[idfieldmov_src];
							rTemp["curramount"] = rMovFin["importocorrente"];
							rTemp["performedamount"] = importoEsito;
							decimal residuo = CfgFn.GetNoNullDecimal(rTemp["curramount"]) - importoEsito;
							rTemp["residual"] = residuo;
							temp.Rows.Add(rTemp);
						}
                        rEsito.Delete();
						break;
					}
				}
			}

			return lanciaScript(form, destConn, bankTransaction, "Generazione Esiti dove c'è un mov. di spesa con importo ritenute pari all'esito");
		}

		private static bool creaEsitiACoperturaProgressiva (Form form, DataAccess destConn,
			DataTable tDettMovBanc, DataTable tMovFin_src, DataTable temp, string IoE,Hashtable H) {
			
			string idfieldmov_src = (IoE == "I") ? "identrata" : "idspesa";
            string tipo = "a debito";
            if(IoE == "I") tipo = "a credito";

			// BANKTRANSACTION (Tabella degli esiti)
			DataTable bankTransaction = DataAccess.CreateTableByName(destConn, "banktransaction", "*");
			bankTransaction.Clear();

			foreach(DataRow rEsito in tDettMovBanc.Select()) {
				decimal importoEsito = CfgFn.GetNoNullDecimal(rEsito["importo"]);
				string filter = "(esercmovbancario = '" + rEsito["esercmovbancario"]
					+ "') AND (nummovbancario = '" + rEsito["nummovbancario"] + "')";
                decimal residuoEsito = importoEsito;
				
				DataRow [] MovFin = tMovFin_src.Select(filter);
                if(MovFin.Length == 0) {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show("Non sono riuscito ad esitare il movimento bancario " + tipo + " " +
                        rEsito["esercmovbancario"].ToString() + "/" + rEsito["nummovbancario"].ToString() +
                        " per un importo pari a " + residuoEsito.ToString("c"));
                    continue;
                }

				foreach(DataRow rMovFin in MovFin) {
					if (residuoEsito <= 0) break;

					string filterTemp = "(idmov = " + QueryCreator.quotedstrvalue(rMovFin[idfieldmov_src], false)
						+ ")";
					DataRow [] rmovtemp = temp.Select(filterTemp);
					if ((rmovtemp.Length > 0) && (CfgFn.GetNoNullDecimal(rmovtemp[0]["residual"]) == 0)) continue;

                    decimal importodaEsitare = CfgFn.GetNoNullDecimal(rMovFin["importocorrente"]);
                    if (rmovtemp.Length>0) importodaEsitare= CfgFn.GetNoNullDecimal(rmovtemp[0]["residual"]);
                    if (importodaEsitare> importoEsito) importodaEsitare= importoEsito;

					fillBankTransaction(destConn, rEsito, rMovFin[idfieldmov_src], bankTransaction, IoE, importodaEsitare,H);

					if (rmovtemp.Length > 0) {
						rmovtemp[0]["performedamount"] = CfgFn.GetNoNullDecimal(rmovtemp[0]["performedamount"])
							+ importodaEsitare;
						rmovtemp[0]["residual"] = CfgFn.GetNoNullDecimal(rmovtemp[0]["residual"]) - importodaEsitare;
					}
					else {
						DataRow rTemp = temp.NewRow();
						rTemp["idmov"] = rMovFin[idfieldmov_src];
						rTemp["curramount"] = rMovFin["importocorrente"];
						rTemp["performedamount"] = importodaEsitare;
						decimal residuo = CfgFn.GetNoNullDecimal(rTemp["curramount"]) - importodaEsitare;
						rTemp["residual"] = residuo;
						temp.Rows.Add(rTemp);
					}
					residuoEsito -= importodaEsitare;
				}
                if(residuoEsito > 0) {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show("Non sono riuscito ad esitare il movimento bancario " + tipo + " " +
                        rEsito["esercmovbancario"].ToString() + "/" + rEsito["nummovbancario"].ToString()+
                        " per un importo pari a "+residuoEsito.ToString("c"));                        
                }
				rEsito.Delete();
			}
			return lanciaScript(form, destConn, bankTransaction, "Generazione Esiti a copertura progressiva dei movimenti finanziari");
		}

		/// <summary>
		/// Metodo contenitore che chiama i metodi per la generazione delle esitazioni
		/// </summary>
		/// <param name="form"></param>
		/// <param name="sourceConn"></param>
		/// <param name="destConn"></param>
		/// <param name="IoE"></param>
		/// <returns></returns>
		public static bool creaEsiti(Form form, DataAccess sourceConn, DataAccess destConn, string IoE,Hashtable H) {
			if (!creaEsitiTotali(form, sourceConn, destConn, IoE,H)) {
				return false;
			}
			
			return creaEsitiParziali(form, sourceConn, destConn, IoE,H);
		}

		/// <summary>
		/// Metodo che aggiunge le righe nella tabelle dei movimenti bancari di EASY (PAYMENT_BANK, PROCEEDS_BANK)
		/// </summary>
		/// <param name="movBancarioSource"></param>
		/// <param name="movBancarioDest"></param>


		private static void fillBankTransaction(DataAccess destConn, DataRow movBancarioSource, 
            object idMovFin, DataTable banktransaction,
			string IoE, decimal amount, Hashtable H) {
			string yfield = (IoE == "I") ? "ypro" : "ypay";
			string nfield = (IoE == "I") ? "npro" : "npay";
			string idfield = (IoE == "I") ? "idpro" : "idpay";
			string idmov = (IoE == "I") ? "idinc" : "idexp";

			object nban = ht[movBancarioSource["esercdocumento"]];
			int nban_free = CfgFn.GetNoNullInt32(nban) + 1;
			ht[movBancarioSource["esercdocumento"]] = nban_free;

			DataRow rBT = banktransaction.NewRow();
			rBT["yban"] = movBancarioSource["esercmovbancario"];
			rBT["nban"] = nban_free;
			rBT["amount"] = amount;
			rBT["bankreference"] = movBancarioSource["rifbanca"];
			rBT["kind"] = movBancarioSource["tipomovbancario"];
			rBT[yfield] = movBancarioSource["esercdocumento"];
			rBT[nfield] = movBancarioSource["numdocumento"];

            int numop = GetNumOperazione(H, movBancarioSource["esercmovbancario"],
                        movBancarioSource["nummovbancario"], movBancarioSource["numoperazione"]);

			rBT[idfield] = numop;
			rBT[idmov] = idMovFin;
			rBT["transactiondate"] = movBancarioSource["dataoperazione"];
			rBT["valuedate"] = movBancarioSource["datavaluta"];
			rBT["ct"] = movBancarioSource["createtimestamp"];
            rBT["cu"] = movBancarioSource["createuser"];
			rBT["lt"] = movBancarioSource["lastmodtimestamp"];
			rBT["lu"] = movBancarioSource["lastmoduser"];

			banktransaction.Rows.Add(rBT);

		}

		/// <summary>
		/// Metodo che aggiorna la tabella dei movimenti finanziari (EXPENSE o INCOME)
		/// </summary>
		/// <param name="destConn">Connessione di destinazione</param>
		/// <param name="tMovFin">Tabella dei movimenti finanziari</param>
		private static void creaScriptAggiornaMovFin(Form form, DataAccess destConn, DataTable tMovFin) {
			string idfield = (tMovFin.TableName == "expense") ? "idpay" : "idpro";
			string idmov = (tMovFin.TableName == "expense") ? "idexp" : "idinc";
			int STEP = 20;
			int currMov = 1;
			string updateCmd = "UPDATE " + tMovFin.TableName + " SET " + idfield + " = ";
			string whereClause = idmov + " = ";
			
			StringWriter sw = new StringWriter();
			string sqlCmd = "";
			string aCapo = "\r\n";
			foreach(DataRow rMov in tMovFin.Rows) {
				sqlCmd += updateCmd + QueryCreator.quotedstrvalue(rMov[idfield],true)
					+ whereClause + QueryCreator.quotedstrvalue(rMov[idmov], true) + aCapo;

				if ((currMov % STEP == 0) || (currMov == tMovFin.Rows.Count)) {
					sw.Write(sqlCmd);
					sw.Flush();
					sqlCmd = "";
				}
				currMov ++;
			}

			string nomeCopia = "Aggiorna " + tMovFin.TableName;
			bool ok = Download.RUN_SCRIPT_NONSTOP(destConn, sw.GetStringBuilder(), nomeCopia);
			if (!ok) {
				StreamWriter fsw = new StreamWriter("temp.sql", false, Encoding.Default);
				fsw.Write(sw.ToString());
				fsw.Close();
				MetaFactory.factory.getSingleton<IMessageShower>().Show(form, "Errore durante la copia: "+nomeCopia+"\r\nLo script lanciato si trova nel file 'temp.sql'");
			}
			sw.Close();
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


		/// <summary>
		/// Crea la nuova tabella mandatekind riempendola con una sola riga (idmankind='GENERALE')
		/// </summary>
		/// <param name="form"></param>
		/// <param name="sourceConn"></param>
		/// <param name="destConn"></param>
		/// <returns></returns>
		public static bool creaMandateKind(Form form, DataAccess sourceConn, DataAccess destConn) {
			DataTable tMandateKind = new DataTable("mandatekind");
			tMandateKind.Columns.Add("idmankind", typeof(string));
			tMandateKind.Columns.Add("description", typeof(string));
			tMandateKind.Columns.Add("active", typeof(string));
			tMandateKind.Columns.Add("multireg", typeof(string));
			tMandateKind.Columns.Add("linktoasset", typeof(string));
			tMandateKind.Columns.Add("linktoinvoice", typeof(string));
			tMandateKind.Columns.Add("cu", typeof(string));
			tMandateKind.Columns.Add("ct", typeof(DateTime));
			tMandateKind.Columns.Add("lu", typeof(string));
			tMandateKind.Columns.Add("lt", typeof(DateTime));
			
			DataRow r = tMandateKind.NewRow();
			r["idmankind"] = "GENERALE";
			r["description"] = "Tipo ordine generale";
			r["active"] = "S";
			r["linktoasset"] = "S";
			r["linktoinvoice"] = "S";
			r["multireg"] = "N";
			r["cu"] = "migrazione";
			r["ct"] = DateTime.Now;
			r["lu"] = "migrazione";
			r["lt"] = DateTime.Now;
			tMandateKind.Rows.Add(r);
			return Migrazione.lanciaScript(form, destConn, tMandateKind, "mandatekind");
		}
       
		public static bool migraPersIva(Form form, DataAccess sourceConn, DataAccess destConn, DataTable tColName) {
			DataTable tInvoiceSetup = leggiETraduciTabella("persiva", sourceConn, tColName, form, null, 
				"deferredincomephase='E', deferredexpensephase='T'");
			if (tInvoiceSetup == null) return false;
			tInvoiceSetup.TableName="invoicesetup";
			return lanciaScript(form, destConn, tInvoiceSetup, "persiva -> invoicesetup");
		}

		public static DataTable tPianoSorting;
		public static bool migraPianoDeiConti(Form form, DataAccess sourceConn, DataAccess destConn, out object idsorpiano) {
            idsorpiano = DBNull.Value;
			tPianoSorting= new DataTable("pianosorting");
			tPianoSorting.Columns.Add("idsor", typeof(string));

			DialogResult dr = MetaFactory.factory.getSingleton<IMessageShower>().Show(form, "Vuoi migrare il piano dei conti come classificazione supplementare?",
				"Domanda", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(dr != DialogResult.OK) {
                return true;
            }
			DataTable tPianoLivello = DataAccess.RUN_SELECT(sourceConn, "livellopianoconti", "*",
				null, null, null, null, true);
			if (tPianoLivello == null) return false;

			DataTable tPiano = DataAccess.RUN_SELECT(sourceConn, "pianoconti", "*",
				null, null, null, null, true);
			if (tPiano == null) return false;
			
			DataTable sortingkind = DataAccess.CreateTableByName(destConn, "sortingkind", "*");
			sortingkind.Clear();
			string idsorkind = "PIANOCONTI";
            idsorpiano = idsorkind;
			DataRow rSortingKind = sortingkind.NewRow();
			rSortingKind["idsorkind"] = idsorkind;
			rSortingKind["active"] = "S";
			rSortingKind["description"] = "Piano dei Conti";
			rSortingKind["flagcheckavailability"] = "N";
			rSortingKind["flagforced"] = "N";
			rSortingKind["flagmultiple"] = "N";
			rSortingKind["ct"] = DateTime.Now;
			rSortingKind["cu"] = "-";
			rSortingKind["lt"] = DateTime.Now;
			rSortingKind["lu"] = "-";
			sortingkind.Rows.Add(rSortingKind);

			DataTable sortinglevel = DataAccess.CreateTableByName(destConn, "sortinglevel", "*");
			sortinglevel.Clear();
			foreach(DataRow rPianoLiv in tPianoLivello.Select(null, "codicelivello")) {
				DataRow rSortingLev = sortinglevel.NewRow();
				rSortingLev["idsorkind"] = idsorkind;
				rSortingLev["nlevel"] = rPianoLiv["codicelivello"];
				rSortingLev["codekind"] = rPianoLiv["tipocodice"];
				rSortingLev["codelen"] = rPianoLiv["lunghcodice"];
				rSortingLev["description"] = rPianoLiv["descrizione"];
				rSortingLev["flagrestart"] = rPianoLiv["flagreset"];
				rSortingLev["flagusable"] = rPianoLiv["flagoperativo"];
				rSortingLev["ct"] = DateTime.Now;
				rSortingLev["cu"] = "-";
				rSortingLev["lt"] = DateTime.Now;
				rSortingLev["lu"] = "-";
				
				sortinglevel.Rows.Add(rSortingLev);
			}

			DataTable sorting = DataAccess.CreateTableByName(destConn, "sorting", "*");
			sorting.Clear();

			foreach(DataRow rPiano in tPiano.Select(null, "idconto")) {
				DataRow rSorting = sorting.NewRow();
				rSorting["idsorkind"] = idsorkind;
				rSorting["idsor"] = rPiano["idconto"];
				rSorting["description"] = rPiano["descrizione"];
				rSorting["sortcode"] = rPiano["codiceconto"];
				rSorting["paridsor"] = rPiano["livsupidconto"];
				rSorting["nlevel"] = rPiano["codicelivello"];
				rSorting["printingorder"] = rPiano["idconto"];
				rSorting["ct"] = DateTime.Now;
				rSorting["cu"] = "-";
				rSorting["lt"] = DateTime.Now;
				rSorting["lu"] = "-";
				rSorting["rtf"] = rPiano["olenotes"]; 
				rSorting["txt"] = rPiano["notes"];

				sorting.Rows.Add(rSorting);

				DataRow rPianoSorting = tPianoSorting.NewRow();
				rPianoSorting["idsor"] = rPiano["idconto"];
				tPianoSorting.Rows.Add(rPianoSorting);

			}
            DataSet dsClass = new DataSet("a");
			dsClass.Tables.Add(sortingkind);
			dsClass.Tables.Add(sorting);
			dsClass.Tables.Add(sortinglevel);

			return lanciaScript(form, destConn, dsClass, "pianoconti, livellopianoconti -> sortingkind, sortinglevel, sorting, expensesetup");
		}
		

		/// <summary>
		/// Metodo che migra i dati da documentoiva a invoice (La gestione dell'idcentrospesa è demandata alla migrazione
		/// dei dettdocumentoiva in invoicedetail)
		/// </summary>
		/// <param name="form"></param>
		/// <param name="sourceConn"></param>
		/// <param name="destConn"></param>
		/// <param name="tColName"></param>
		/// <returns></returns>
		public static bool migraDocumentoIva(Form form, DataAccess sourceConn, DataAccess destConn, DataTable tColName) {
			string query = "select distinct codicetipodoc, flag=flagimmediata+flagdifferita "
				+ "from tipodocoperiva "
				+ "join tipooperregiva on tipodocoperiva.codicetipoop=tipooperregiva.codicetipoop "
				+ "join tiporegistroiva on tipooperregiva.codicetiporeg=tiporegistroiva.codicetiporeg "
				+ "where classregistro <> 'P' ";
			DataTable t1 = Migrazione.eseguiQuery(sourceConn, query, form);
			if (t1==null) return false;

			string filtroImmed = QueryCreator.ColumnValues(t1, "flag in('AI','DI')", "codicetipodoc", false);
			string filtroDiffer = QueryCreator.ColumnValues(t1, "flag in('IA','ID')", "codicetipodoc", false);

			DataTable t = Migrazione.leggiETraduciTabella("documentoiva", sourceConn, tColName, form, null, "active='S'");
			if (t==null) return false;
			t.Columns.Add("flagdeferred", typeof(string));
			if (filtroImmed != "") {
				DataRow[] rImm = t.Select("idinvkind in ("+filtroImmed+")");
				foreach (DataRow r in rImm) {
					r["flagdeferred"] = "N";
				}
			}
			if (filtroDiffer != "") {
				DataRow[] rDiff = t.Select("idinvkind in ("+filtroDiffer+")");
				foreach (DataRow r in rDiff) {
					if (r["flagdeferred"] is DBNull) {
						r["flagdeferred"] = "S";
					} else {
						r["flagdeferred"] = DBNull.Value;
					}
				}
			}
			t.TableName = "invoice";
			return Migrazione.lanciaScript(form,destConn, t, "documentoiva, tipooperregiva -> invoice");
		}

		public static bool creaGeneralReportParameter(Form form,DataAccess sourceConn, DataAccess destConn) {
			DataTable tLicense = DataAccess.RUN_SELECT(destConn, "license", "*", null, null, null, null, true);
			if (tLicense == null) return false;
			if (tLicense.Rows.Count == 0) return true;

			DataTable tGRP = DataAccess.CreateTableByName(destConn, "generalreportparameter", "*");
			if (tGRP == null) return false;

			tGRP.Clear();
			DataRow rLicense = tLicense.Rows[0];
			string idparam = "";
			string paramvalue = "";
			string description = "";

			string [] listaCampi = {"departmentname", "agencyname", "address1", "address2", "cap", "location", "country",
									   "cf", "p_iva"};
			foreach(string C in listaCampi) {
				switch(C) {
					case "departmentname":
						idparam = "DenominazioneDipartimento";
						paramvalue = rLicense[C].ToString();
						description = "Nome Dipartimento";
						break;
					case "agencyname":
						idparam = "DenominazioneUniversita";
                        paramvalue = rLicense[C].ToString();
						description = "Nome Università";
						break;
					case "address1":
						idparam = "License_Address1";
                        paramvalue = rLicense[C].ToString();
						description = "Indirizzo 1";
						break;
					case "address2":
						idparam = "License_Address2";
                        paramvalue = rLicense[C].ToString();
						description = "Indirizzo 1";
						break;
					case "cap":
						idparam = "License_Cap";
                        paramvalue = rLicense[C].ToString();
						description = "CAP";
						break;
					case "location":
						idparam = "License_Location";
                        paramvalue = rLicense[C].ToString();
						description = "Località";
						break;
					case "country":
						idparam = "License_Country";
                        paramvalue = rLicense[C].ToString();
						description = "Provincia";
						break;
					case "cf":
						idparam = "License_f";
                        paramvalue = rLicense[C].ToString();
						description = "Codice Fiscale Università";
						break;
					case "p_iva":
						idparam = "License_P_Iva";
                        paramvalue = rLicense[C].ToString();
						description = "Partita Iva Università";
						break;
				}

				DataRow rGRP = tGRP.NewRow();

				rGRP["idparam"] = idparam;
				rGRP["paramvalue"] = paramvalue;
				rGRP["description"] = description;

				tGRP.Rows.Add(rGRP);
			}
            DataTable tCustomReportParameter = DataAccess.RUN_SELECT(sourceConn, "customreportparameter", 
                "parametervalue", null, "(parametername = 'FInfoAvanzo' )", null, null, true);
            if (tCustomReportParameter != null)
            {
                if(tCustomReportParameter.Rows.Count > 0) {
                    DataRow rParam = tCustomReportParameter.Rows[0];
                    paramvalue = rParam["parametervalue"].ToString();
                }
                else
                    paramvalue = "N";

            }
            else
            {
                paramvalue = "N";
            }

            idparam     = "MostraAvanzo";
            description = "Parametro che gestisce la visualizzazione delle informazioni " +
                          "inerenti l'avanzo di amministrazione (S = Visualizzato e totalizzato, " +
                          "N = Non visualizzato e non totalizzato, B= Visualizzato e non totalizzato)";
       
            DataRow rGRP1 = tGRP.NewRow();

            rGRP1["idparam"] = idparam;
            rGRP1["paramvalue"] = paramvalue;
            rGRP1["description"] = description;

            tGRP.Rows.Add(rGRP1);

			return lanciaScript(form, destConn, tGRP, "license -> generalreportparameter");
		}


		public static bool EffettuaControlli(Form form, DataAccess SourceConn){            
			string query = "select * from movimentobancario where numoperazione is null";
			int NPayNoNumOp=CfgFn.GetNoNullInt32( SourceConn.DO_SYS_CMD(query,true));			
			if (NPayNoNumOp>0) {
				if(MetaFactory.factory.getSingleton<IMessageShower>().Show(form,"Ci sono movimenti bancari senza numero operazione, che sarà quindi posto a zero. Procedo comunque? ","Avviso",
					MessageBoxButtons.YesNo)==DialogResult.No)
					return false;
			}
			query = "select * from dettmovimentobancario where numoperazione is null";
			int NDettPayNoNumOp=CfgFn.GetNoNullInt32( SourceConn.DO_SYS_CMD(query,true));			
			if (NDettPayNoNumOp>0) {
				if(MetaFactory.factory.getSingleton<IMessageShower>().Show(form,"Ci sono DETTAGLI di movimenti bancari senza numero operazione, che sarà quindi posto a zero. Procedo comunque? ","Avviso",
					MessageBoxButtons.YesNo)==DialogResult.No)
					return false;
			}
			query = "select * from movimentobancario where numdocumento is null or esercdocumento is null";
			int NPayNoDoc=CfgFn.GetNoNullInt32( SourceConn.DO_SYS_CMD(query,true));			
			if (NPayNoDoc>0) {
				if(MetaFactory.factory.getSingleton<IMessageShower>().Show(form,"Ci sono movimenti bancari senza mandato o reversale, che saranno quindi SALTATI. Procedo comunque? ","Avviso",
					MessageBoxButtons.YesNo)==DialogResult.No)
					return false;
			}

            query = "select * from movimentobancario where ((tipomovbancario = 'C' AND "
                + "NOT EXISTS (SELECT identrata from entrata WHERE  entrata.esercmovbancario = movimentobancario.esercmovbancario "
                + "AND entrata.nummovbancario = movimentobancario.nummovbancario) "
                + ") OR "
                + "(tipomovbancario = 'D' AND  NOT EXISTS  "
                + "(SELECT idspesa from spesa WHERE  spesa.esercmovbancario = movimentobancario.esercmovbancario "
                + " AND spesa.nummovbancario = movimentobancario.nummovbancario)) )";
            int NPayNoMov = CfgFn.GetNoNullInt32(SourceConn.DO_SYS_CMD(query, true));
            if (NPayNoMov > 0)
            {
                if (MetaFactory.factory.getSingleton<IMessageShower>().Show(form, "Ci sono movimenti bancari non associati ad alcun movimento di entrata/spesa, che saranno quindi SALTATI. Procedo comunque? ", "Avviso",
                    MessageBoxButtons.YesNo) == DialogResult.No)
                    return false;
            }

            query = "select * from movimentobancario where flagesito ='P' AND "
                + " 0 = (select count(*)  from dettmovimentobancario "
                + " where movimentobancario.esercmovbancario = dettmovimentobancario.esercmovbancario "
                + " and movimentobancario.nummovbancario = dettmovimentobancario.nummovbancario)";
            DataTable tMovBancariconflagP = SourceConn.SQLRunner(query,false,0);
            if (tMovBancariconflagP.Rows.Count > 0)
            {
                DialogResult dr = new FrmErrore(tMovBancariconflagP, "I seguenti movimenti bancari sono esitati come Parziali ma NON esiste il dettaglio", "Si vuole proseguire?").ShowDialog(form);
                if (dr != DialogResult.Yes) return false;
            }

            query = "select * from movimentobancario where isnull(flagesito,'N') <>'P' AND "
                + " (select count(*)  from dettmovimentobancario "
                + " where movimentobancario.esercmovbancario = dettmovimentobancario.esercmovbancario "
                + " and movimentobancario.nummovbancario = dettmovimentobancario.nummovbancario) >0";
            DataTable tMovBancarisenzaflagP = SourceConn.SQLRunner(query, false, 0);
            if(tMovBancarisenzaflagP.Rows.Count > 0) {
                DialogResult dr = new FrmErrore(tMovBancarisenzaflagP, "I seguenti movimenti bancari sono esitati come Parziali ma con un flag errato e NON saranno migrati!", "Si vuole proseguire?").ShowDialog(form);
                if(dr != DialogResult.Yes) return false;
            }

            query = "select  distinct M.esercdocumento, M.numdocumento, M.tipomovbancario " +
                    " from    movimentobancario M " +
                    " join  movimentobancario M1 ON M.esercdocumento = M1.esercdocumento " +
                    " and M.numdocumento = M1.numdocumento and M.tipomovbancario = M1.tipomovbancario " +
                    " and  M.numoperazione = M1.numoperazione" +
                    " where M.nummovbancario <> M1.nummovbancario ";
            DataTable tMovBancariNumOp = SourceConn.SQLRunner(query,false,0);
            if(tMovBancariNumOp.Rows.Count > 0) {
                DialogResult dr = new FrmErrore(tMovBancariNumOp, 
                    "I seguenti movimenti bancari hanno conflitti di numoperazione", "Si vuole procedere e correggere la situazione?").ShowDialog(form);
                if(dr != DialogResult.Yes) return false;
            }

            query = "select  distinct M.esercdocumento, M.numdocumento, M.tipomovbancario " +
                    " from    movimentobancario M " +
                    " JOIN  movimentobancario M4 " +
                    " ON  M.tipomovbancario  =  M4.tipomovbancario " +
                    " AND M.esercdocumento    =  M4.esercdocumento " +
                    " AND M.numdocumento      =  M4.numdocumento " +
                    " JOIN dettmovimentobancario M2 " +
                    "   ON M4.nummovbancario = M2.nummovbancario " +
                    "   AND M4.esercmovbancario = M2.esercmovbancario " +
                    " WHERE   M.numoperazione = M2.numoperazione "+
                    "   AND M.flagesito='S' " +
                    "   AND M4.flagesito='P'";
            tMovBancariNumOp = SourceConn.SQLRunner(query, false, 0);
            if(tMovBancariNumOp.Rows.Count > 0) {
                DialogResult dr = new FrmErrore(tMovBancariNumOp,
                    "I seguenti movimenti bancari hanno conflitti di numoperazione", "Si vuole procedere e correggere la situazione?").ShowDialog(form);
                if(dr != DialogResult.Yes) return false;
            }




            query = "SELECT  distinct M.esercdocumento, M.numdocumento,M.tipomovbancario " +
                    " FROM    dettmovimentobancario D " +
                    " JOIN    movimentobancario M " +
                    " ON D.esercmovbancario = M.esercmovbancario " +
                    " AND     D.nummovbancario   = M.nummovbancario " +
                    " JOIN  movimentobancario M2 " +
                    " ON M.tipomovbancario   =  M2.tipomovbancario " +
                    " AND M.esercdocumento    =  M2.esercdocumento " +
                    " AND M.numdocumento      =  M2.numdocumento " +
                    " JOIN  dettmovimentobancario D2 " +
                    " ON M2.esercmovbancario = D2.esercmovbancario " +
                    " AND M2.nummovbancario = D2.nummovbancario " +
                    " WHERE M.nummovbancario    <> M2.nummovbancario " +
                    "    AND   D.numoperazione = D2.numoperazione  " +
                    "   AND M2.flagesito='P' ";
            DataTable tMovBancariNumOp2 = SourceConn.SQLRunner(query,false,0);
            if(tMovBancariNumOp2.Rows.Count > 0) {
                DialogResult dr = new FrmErrore(tMovBancariNumOp2,
                    "I seguenti dettagli di mov. bancari hanno conflitti di numoperazione", "Si vuole procedere e correggere la situazione?").ShowDialog(form);
                if(dr != DialogResult.Yes) return false;
            }

			return true;
		}
        public static bool ImpostaExpenseSetup(Form form, DataAccess sourceConn, DataAccess destConn, object idsor) {
            string sql = "update expensesetup set idregauto=";
            object idreg = sourceConn.DO_READ_VALUE("creditoredebitore", "(tiporesidenza = 'R')", "top 1 codicecreddeb");
            if(CfgFn.GetNoNullInt32(idreg) != 0) {
                sql += QueryCreator.quotedstrvalue(idreg, true) + " where idregauto is null";
                destConn.DO_SYS_CMD(sql, false);
            }
            sql = "update expensesetup set idsortingkind1=";
            if(idsor.ToString() != "") {
                sql += QueryCreator.quotedstrvalue(idsor, true) + " where idsortingkind1 is null";
                destConn.DO_SYS_CMD(sql, false);
            }
            return true;
        }


		public static bool migraTabelleElaborate(Form form, DataTable tColName, 
            DataAccess sourceConn, DataAccess destConn, out object idpiano) {
            idpiano = DBNull.Value;
            // variazioneentrata -> incomevar
            if (!migraVariazioni(form, sourceConn, destConn, "I")) return false;

            // variazionespesa -> expensevar
            if (!migraVariazioni(form, sourceConn, destConn, "E")) return false;

			//entrata -> income
			if (!migraMovimentiFinanziari(form, sourceConn, destConn, "I")) return false;

			//spesa -> expense
			if (!migraMovimentiFinanziari(form, sourceConn, destConn, "E")) return false;

            //pianoconti -> sortingkind / sortinglevel / sorting / expensesetup
			if (!migraPianoDeiConti(form, sourceConn, destConn,out idpiano)) return false;

			//documentoiva -> invoice
			if (!migraDocumentoIva(form, sourceConn, destConn, tColName)) return false;

			//persiva -> invoicesetup
			if (!Migrazione.migraPersIva(form, sourceConn, destConn, tColName)) return false;

			//dettordinegenerico -> mandatedetail
			if (!Migrazione.migraDettOrdineGenerico(form, sourceConn, destConn))return false;

			//ordinegenerico -> mandate
			if (!Migrazione.migraOrdineGenerico(form, sourceConn, destConn)) return false;

			//ordinegenericomovspesa -> expensemandate
			if (!Migrazione.migraOrdineGenericoMovSpesa(form, sourceConn, destConn))return false;

			//dettaglioritenute -> expensetax
			if (!Migrazione.migraDettaglioRitenute(form, tColName, sourceConn, destConn))return false;
			
			//dettdocumentoiva -> invoicedetail
			if (!Migrazione.migraDettDocumentoIva(form, sourceConn, destConn)) return false;

			//contrattoocc -> casualcontract
			if (!Migrazione.migraContrattoOcc(form, tColName, sourceConn, destConn)) return false;

			//missione -> itineration
			if (!Migrazione.migraTabMissione(form, tColName, sourceConn, destConn)) return false;

			//contrattodip -> wageaddition
			if (!Migrazione.migraContrattoDip(form, tColName, sourceConn, destConn)) return false;

			if (!Migrazione.migraDettBilancioPrevisione(form, tColName, sourceConn, destConn)) return false;
			
			if (!Migrazione.migraDettBilancioAssestamento(form, tColName, sourceConn, destConn)) return false;

			// Migra i dati di addizionalidacaf in cafdocument
//			if (!Migrazione.migraAddizDaCafInCafDocument(form, tColName, sourceConn, destConn)) return false;


			return true;

		}

		public static Hashtable ht = new Hashtable();
		private static void impostaHashTablePerNBAN(DataAccess destConn) {
			int min = CfgFn.GetNoNullInt32(destConn.DO_READ_VALUE("accountingyear", null, "MIN(ayear)"));
			int max = CfgFn.GetNoNullInt32(destConn.DO_READ_VALUE("accountingyear", null, "MAX(ayear)"));

			for(int curryear = min; curryear <= max; curryear++) {
				ht[curryear] = CfgFn.GetNoNullInt32(destConn.DO_READ_VALUE("banktransaction", "(yban = '" + curryear + "')", "MAX(nban)"));
			}
		}

		public static void DisabilitaVecchiOrdiniEFatture(Form form, DataAccess destConn){
			StringBuilder SB1 = Download.LeggiTestoScript("migrazione_ordini.sql");
			bool res=Download.RUN_SCRIPT_NONSTOP(destConn,SB1,"Disabilitazione e rifinitura(ove sicuro) ordini di anni precedenti");				
			if (!res) return;
			SB1 = Download.LeggiTestoScript("migrazione_fatture.sql");
			res=Download.RUN_SCRIPT_NONSTOP(destConn,SB1,"Rifinitura fatture di anni precedenti ove sicuro");				
			if (!res) return;
			SB1 = Download.LeggiTestoScript("disable_oldinvoice.sql");
			res=Download.RUN_SCRIPT_NONSTOP(destConn,SB1,"Disabilitazione fatture di anni precedenti");						
		}

        public static string ConvertReportName(string oldname) {
            switch(oldname) {
                case "anapre": return "anagrafeprestazioni";
                case "avanzopresunto": return "avanzoamministrazionepresunto";
                case "avvisinc": return "avviso_incasso";
                case "avvispag": return "avviso_pagamento";
                case "avvispag_ele": return "avviso_pagamento_elenco";
                case "buoncari": return "buono_carico";
                case "buonscar": return "buono_scarico";
                case "cassapresunta": return "avanzocassapresunto";
                case "ccspentr": return null;
                case "ccspusc": return null;
                case "cedolino": return "cedolino";
                case "certifisa": return null;
                case "certifisb": return null;
                case "certifisc": return null;
                case "certifisd": return null;
                case "conccass": return "verificasaldocc";
                case "consentr": return "bilancioconsuntivo_E";
                case "consentrcc": return "bilancioconsuntivo_E";
                case "consentrcc1": return "bilancioconsuntivocompetenza_E";
                case "consentrcc2": return "bilancioconsuntivoresidui_E";
                case "consentrcc3": return "bilancioconsuntivocassa_E";
                case "consentrcc4": return "sit_residui_attivi_per_anno";
                case "consopee": return "sitbilancio_E";
                case "consopre": return "sitbilancioresidui_E";
                case "consusc": return "bilancioconsuntivo_S";
                case "consusccc": return "bilancioconsuntivo_S";
                case "consusccc1": return "bilancioconsuntivocompetenza_S";
                case "consusccc2": return "bilancioconsuntivoresidui_S";
                case "consusccc3": return "bilancioconsuntivocassa_E";
                case "consusccc4": return "sit_residui_passivi_per_anno";
                case "cspecent": return null;
                case "cspecusc": return null;
                case "cspeentcs": return null;
                case "csperent": return null;
                case "csperusc": return null;
                case "dipendentecalc": return "contrattodipendenti";
                case "docincas": return "reversale_incasso";
                case "docpagam": return "mandato_pagamento";
                case "docuvend": return "fatturavendita";
                case "elenncla": return "classificazioniincomplete";
                case "giorcass": return "giornale_cassa";
                case "giorcasscs": return "giornale_cassa_gestcassa";
                case "librinv": return "libro_inventario";
                case "liquiva": return "liquidazioneiva";
                case "missant": return "anticipo_missione";
                case "misscont": return "missione_prospetto_calcolo";
                case "occasionalecalc": return "contrattooccasionale";
                case "ordigene": return "buono_ordine";
                case "ordipatr": return null;
                case "partass": return "assegnazionibilanciospesa";
                case "partcent": return "partitariobilcompetenza_E";
                case "partcmov": return "partitarioclassificazioni";
                case "partcred": return "partitarioanagrafica";
                case "partcusc": return "partitariobilcompetenza_S";
                case "partentcs": return "partitariocassa_E";
                case "partfent": return null;
                case "partfspe": return null;
                case "partfusc": return null;
                case "partitario_entrate_intestazione": return "";
                case "partitario_spese_intestazione": return "";
                case "partment": return null;
                case "partmspe": return null;
                case "partrent": return "partitariobilresidui_E";
                case "partrusc": return "partitariobilresidui_S";
                case "partusccs": return "partitariocassa_S";
                case "preventr": return "bilancioprevisione_E";
                case "preventrcc": return "bilancioprevisione_E";
                case "prevusc": return "bilancioprevisione_S";
                case "prevusccc": return "bilancioprevisione_S";
                case "professionalecalc": return "contrattoprofessionale";
                case "regiaiva": return "registroacquisti";
                case "regipgen": return "registroivagenerale";
                case "regiviva": return "registrovendite";
                case "regpispe": return "fondopsp_registro";
                case "rendclas": return "rendicontoclassificazione";
                case "rendcred": return "rendicontoanagrafica";
                case "rendfann": return null;
                case "rendfond": return null;
                case "respopee": return "sitbilancioresponsabile_E";
                case "respopre": return "sitbilancioresponsabileresidui_E";
                case "riepaiva": return "riepilogoregistroacquisti";
                case "rieprite": return "riepilogoritenute";
                case "riepviva": return "riepilogoregistrovendite";
                case "sitbilspe": return "sitbilancio_S";
                case "sitbilsperesp": return "sitbilancioresponsabile_S";
                case "situ_class": return "situazionepatrim_classificazione";
                case "situ_resp": return "situazionepatrim_responsabile";
                case "situ_ubic": return "situazionepatrim_ubicazione";
                case "situammi": return null;
                case "situente": return "situazionepatrim_ente";
                case "situfina": return null;
                case "situpatr": return "situazionepatrim_totale";
                case "trasinc": return "trasm_reversale_incasso";
                case "traspag": return "trasm_mandato_pagamento";
                case "variprev": return "previsione_variazioni";
                default:
                    return null;
            }
        }
        public static string ConvertParameterName(string oldname) {
            switch(oldname) {
                case "FAliquota1": return "Aliquota1";
                case "FAliquota2": return "Aliquota2";
                case "FAliquota3": return "Aliquota3";
                case "FAvanzo": return "Avanzo";
                case "FBancaCompatto": return "BancaCompatto";
                case "FClassSup": return "ClassSup";
                case "FCodiceEnteDaBanca": return "CodiceEnteDaBanca";
                case "FCodiceLogo": return "CodiceLogo";
                case "FContoFruttifero": return "TextContoFruttifero";
                case "FContoInfruttifero": return "ImportoRitenuteDiverse";
                case "FDescrDocVendita": return "DescrDocVendita";
                case "FDimensioneCarattere": return "DimensioneCarattere";
                case "FFirmaCentro": return "FirmaTitoloCentro";
                case "FFirmaCentro2": return "FirmaNomeCentro";
                case "FFirmaDestra": return "FirmaTitoloDx";
                case "FFirmaDestra2": return "FirmaNomeDx";
                case "FFirmaSinistra": return "FirmaTitoloSx";
                case "FFirmaSinistra2": return "FirmaNomeSx";
                case "FIndirizzo": return "Indirizzo";
                case "FInfoAvanzoCassa": return "MostraAvanzoCassa";
                case "FInfoBilancio": return "MostraBilancio";
                case "FInfoCategoria": return "MostraCategoria";
                case "FInfoCFePI": return "MostraCFePI";
                case "FInfoCodFisPIVACreditore": return "MostraCodFisPIVABeneficiario";
                case "FInfoCodFisPIVAVersante": return "MostraCodFisPIVAVersante";
                case "FInfoCodiceEnte": return "MostraCodiceEnte";
                case "FInfoCodiceEnteDaBanca": return "MostraCodiceEnteDaBanca";
                case "FInfoCodiceFiscale": return "MostraCodiceFiscale";
                case "FInfoContatto": return "MostraContatto";
                case "FInfoCrediti": return "MostraCrediti";
                case "FInFoDataannullamento": return "MostraDataannullamento";
                case "FInfoDataemissione": return "MostraDataemissione";
                case "FInfoDataesito": return "MostraDataesito";
                case "FInfoDataNascita": return "MostraDataNascita";
                case "FInfoDataStampa": return "MostraDataStampa";
                case "FInfoDatatrasmissione": return "MostraDatatrasmissione";
                case "FInfoDescrDocumento": return "MostraDescrDocumento";
                case "FInfoDescrizioneBuono": return "MostraDescrizioneBuono";
                case "FInfoDescrizionePagamento": return "MostraDescrizionePagamento";
                case "FInfoDocumento": return "MostraDocumento";
                case "FInfoFirmaBeneficiario": return "MostraFirmaBeneficiario";
                case "FInfoImpegni": return "MostraImpegni";
                case "FInfoIncassi": return "MostraIncassi";
                case "FInfoIndirizzo": return "MostraIndirizzo";
                case "FInfoIndirizzoCreditore": return "MostraIndirizzoBeneficiario";
                case "FInfoIndirizzoVersante": return "MostraIndirizzoVersante";
                case "FInfoLogo": return "MostraLogo";
                case "FInfoLogoINAIL": return "MostraLogoINAIL";
                case "FInfoModalitaPagamento": return "MostraModalitaPagamento";
                case "FInfoMovGiaTrasmessi": return "MostraMovGiaTrasmessi";
                case "FInfoMovimenti": return "MostraMovimenti";
                case "FInfoNomeEnte": return "MostraNomeDipartimento";
                case "FInfoNomeUniversita": return "MostraDenominazioneUniversita";
                case "FInfoPartitaIva": return "MostraPartitaIva";
                case "FInfoPartitaIvaFornitore": return "MostraPartitaIvaFornitore";
                case "FInfoPiePaginaAvvisoPag": return "MostraPiePaginaAvvisoPag";
                case "FInfoPrevisioneCassa": return "MostraPrevisioneCassa";
                case "FInfoPrevisioneCompetenza": return "MostraPrevisioneCompetenza";
                case "FInfoProgressivo": return "MostraProgressivo";
                case "FInfoProvvedimento": return "MostraProvvedimento";
                case "FInfoResidui": return "MostraResidui";
                case "FInfoResponsabile": return "MostraResponsabile";
                case "FInfoScambioCol85": return "MostraScambioCol8Con5";
                case "FInfoSconto": return "MostraSconto";
                case "FInfoTotaleNetto": return "MostraTotaleNetto";
                case "FInfoTotali": return "MostraTotali";
                case "FInfoTotaliPagina": return "MostraTotaliPagina";
                case "FInfoTotaliUPB": return "MostraTotaliUPB";
                case "FInfoTrattamentoBollo": return "MostraTrattamentoBollo";
                case "FInfoUbicazione": return "MostraUbicazione";
                case "FInfoUfficioEmittente": return "MostraUfficioEmittente";
                case "FInfoUltimaFase": return "MostraUltimaFase";
                case "FInfoUPB": return "MostraUPB";
                case "FInfoValuta": return "MostraValuta";
                case "FNomeLungoClass": return "NomeLungoClass";
                case "FNomeLungoUbic": return "NomeLungoUbic";
                case "FNomePatrimonio": return "NomePatrimonio";
                case "FNote": return "Note";
                case "FNote2": return "Note2";
                case "FNote3": return "Note3";
                case "FPrimaFase": return "PrimaFase";
                case "FSecondaFase": return "SecondaFase";
                case "FTitoloProspetto": return "IntestazioneReport";
                case "FInfoDettaglio": return null;
                default: return null;
            }
        }

        public static bool MigraParametriReport(Form form, DataAccess sourceConn, DataAccess destConn) {
            DataTable OldParam = sourceConn.RUN_SELECT("customreportparameter", "*", null, null, null, false);
            int Nline = 0;
            StringBuilder SB1 = new StringBuilder(10000);
            foreach(DataRow R in OldParam.Rows) {
                string newreport= ConvertReportName(R["officialname"].ToString().ToLower());
                if (newreport==null) continue;
                string newparam = ConvertParameterName(R["parametername"].ToString());
                if (newparam==null) continue;
                SB1.Append("UPDATE reportadditionalparam SET paramvalue ="+
                    QueryCreator.quotedstrvalue(R["parametervalue"],true)+
                    " WHERE reportname= "+QueryCreator.quotedstrvalue(newreport,true)+
                    " AND paramname= "+QueryCreator.quotedstrvalue(newparam,true));

                Nline++;
                if(Nline == 10) {
                    SB1.Append("\r\nGO\r\n");
                    Nline = 0;
                }
            }
            bool res = Download.RUN_SCRIPT_NONSTOP(destConn, SB1, "Migrazione parametri custom report");
            return res;

        }


        public static bool MigraTipoSpesaProf(Form form, DataAccess sourceConn, DataAccess destConn) {
            DataTable Test = sourceConn.CreateTableByName("tipospesaprof", "*");
            string sql= "select idlinkedrefund = codicespesa, "+
                        "description = descrizione, "+
                        "ct= createtimestamp, "+
                        "cu= createuser," +
                        "lt= lastmodtimestamp, "+
                        "lu=lastmoduser";

            if (Test.Columns.Contains("flagfiscaldeduction")) {
                sql += ", flagfiscaldeduction= ded_fiscale, flagivadeduction=ded_iva, flagsecuritydeduction=ded_previdenziale";
            }
            else {
                sql += ", flagfiscaldeduction= 'S', flagivadeduction='S', flagsecuritydeduction='S'";
            }
            sql += " from tipospesaprof ";
            string errMsg;
            DataTable tProfRefund = sourceConn.SQLRunner(sql, 0, out errMsg);
            if (errMsg != null) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(form, errMsg);
                return false;
            }
            tProfRefund.TableName = "profrefund";

            DataSet ds = new DataSet();
            ds.Tables.Add(tProfRefund);

            return Migrazione.lanciaScript(form, destConn, ds, "tipospesaprof -> profrefund");

        }

		public static bool creaNuoveTabelle(Form form, DataAccess sourceConn, DataAccess destConn ) {
			impostaHashTablePerNBAN(destConn);

			//movimentobancario, dettmovimentobancario -> proceeds_bank, banktransaction
            Hashtable H = new Hashtable(10000);
			if (!Migrazione.creaMovBancari(form, sourceConn, destConn, "I",H)) return false;
			if (!Migrazione.creaEsiti(form, sourceConn, destConn, "I",H)) return false;

            H = new Hashtable(10000);
			//movimentobancario, dettmovimentobancario -> payment_bank, banktransaction
			if (!Migrazione.creaMovBancari(form, sourceConn, destConn, "E",H)) return false;
			if (!Migrazione.creaEsiti(form, sourceConn, destConn, "E",H)) return false;

			//tipodocumentoiva (duplicati)-> invoicekindyear
			if (!Migrazione.creaInvoicekindyear(form, sourceConn, destConn))return false;

			//mandatekind (nuova tabella)
			if (!creaMandateKind(form, sourceConn, destConn)) return false;

            if (!creaGeneralReportParameter(form, sourceConn, destConn)) return false;

            if (!MigraTipoSpesaProf(form, sourceConn, destConn)) return false;

            
			return true;
		}
	}
}
