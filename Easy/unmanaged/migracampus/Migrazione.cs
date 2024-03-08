
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

        public static void Reset() {
        }

		public static DataTable eseguiQuery(DataAccess sourceConn, string command, Form form) {
			string errMsg;
			DataTable t = sourceConn.SQLRunner(command, 0 , out errMsg);
			if (errMsg != null) {
				QueryCreator.ShowError(null,errMsg,command);
				MessageBox.Show(form, errMsg);
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
            title = title + " (" + TT.Rows.Count + " righe)";
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
							MessageBox.Show(form, "Errore durante la copia "+title+"\r\nLo script lanciato si trova nel file 'temp.sql'");

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
						MessageBox.Show(form, "Errore durante la copia "+title+"\r\nLo script lanciato si trova nel file 'temp.sql'");

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
					MessageBox.Show(form, "Errore durante la copia: "+nomeCopia+"\r\n");
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
				MessageBox.Show(form, "Errore durante la copia: "+nomeCopia+"\r\nLo script lanciato si trova nel file 'temp.sql'");
				return false;
			}
			return true;
		}

		public static bool lanciaScript(Form form, DataAccess destConn, DataTable t, string nomeCopia) {
			if (!CopyTable(form,t,destConn,nomeCopia)){
				MessageBox.Show(form, "Errore durante la copia: "+nomeCopia+"\r\n");
				return false;
			}
			return true;
			
		}

        static object gethash (Hashtable A, string code) {
            if (code == "") return DBNull.Value;
            code = code.ToUpper();
            if (A[code] == null) {
                MessageBox.Show("Code " + code + " was not found in " + A.GetType().Name);
                return DBNull.Value;
            }
            return A[code];
        }

        public static string getExtAccess(DataAccess Conn, string table, bool dbo) {
            //DBNAME.owner"
            if (dbo)
                return Conn.GetSys("database").ToString() + ".dbo." + table;
            else
                return Conn.GetSys("database").ToString() + "." + Conn.GetSys("userdb").ToString() + "." + table;
        }

		/// <summary>
		/// Copia dettordinegenerico in mandatedetail ponendo idmankind='GENERALE'
		/// </summary>
		/// <param name="form"></param>
		/// <param name="sourceConn"></param>
		/// <param name="destConn"></param>
		public static bool migraDettOrdineGenerico(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("mandatedetail", null, false) > 0) return true;

            Patrimonio.EsportaClassInventario(form, sourceConn, destConn);
            creaMandateKind(form, sourceConn, destConn);

            string query = "select annotations = camponote, assetkind = 'O', "
				+ "ct = createtimestamp, cu = createuser, "
				+ "detaildescription = descrdettaglio, "
				+ "discount = sconto, "
				+ "idmankind = 'GENERALE', yman = esercordine, nman = numordine, rownum = numriga, "
				+ "idgroup = numriga, "
				+ "idinv = null, "
				+ "lt = lastmodtimestamp, lu = lastmoduser, "
				+ "number = quantita, taxable = imponibile, "
				+ "tax = ROUND(ROUND((ISNULL(imponibile,0)*quantita*(1-ISNULL(sconto,0))),2)*ISNULL(imposta,0),2), "
				+ "taxrate = CONVERT(DECIMAL(19,6),imposta),  "
				+ "toinvoice = 'N', flagmixed = 'N', unabatable = 0, ninvoiced = 0 "
				+ "from dettordinegenerico";

            string query2 = "select annotations = camponote, assetkind = case when tipobene='N' then 'P'  "
                + " when tipobene='I' then 'A' else 'O' end, "
                + "ct = dettordineinventario.createtimestamp, cu = dettordineinventario.createuser, "
                + "detaildescription = descrdettaglio, "
                + "discount = sconto, "
                + "idmankind = 'PATRIMONIO', yman = esercordine, nman = numordine, rownum = numriga, "
                + "idgroup = numriga, "
                + "INV.idinv , "
                + "lt = dettordineinventario.lastmodtimestamp, lu = dettordineinventario.lastmoduser, "
                + "number = quantita, taxable = imponibile, "
                + "tax = ROUND(ROUND((ISNULL(imponibile,0)*quantita*(1-ISNULL(sconto,0))),2)*ISNULL(imposta,0),2), "
                + "taxrate = CONVERT(DECIMAL(19,6),imposta),  "
                + "toinvoice = 'N', flagmixed = 'N', unabatable = 0, ninvoiced = 0 "
                + "from dettordineinventario left outer join "
                + " classinventario CI ON CI.idclass= dettordineinventario.idclass "
                + " LEFT OUTER JOIN " + getExtAccess(destConn, "inventorytree", true) + " INV "
                + "  ON INV.codeinv=CI.codiceclass ";
                


            DataTable tMandateDetail = Migrazione.eseguiQuery(sourceConn, query, form);
			if (tMandateDetail==null) return false;
			tMandateDetail.Columns.Add("idivakind",typeof(int));
			
			if (!impostaIdIvaKind(form, destConn, tMandateDetail)) return false;
			tMandateDetail.TableName = "mandatedetail";
			DataSet ds = new DataSet();
			ds.Tables.Add(tMandateDetail);

			bool res= Migrazione.lanciaScript(form, destConn, ds, "dettordinegenerico -> mandatedetail");
            if (!res) return false;


            tMandateDetail = Migrazione.eseguiQuery(sourceConn, query2, form);
            if (tMandateDetail == null) return false;
            tMandateDetail.Columns.Add("idivakind", typeof(string));

            if (!impostaIdIvaKind(form, destConn, tMandateDetail)) return false;
            tMandateDetail.TableName = "mandatedetail";
            ds = new DataSet();
            ds.Tables.Add(tMandateDetail);

             res = Migrazione.lanciaScript(form, destConn, ds, "dettordinegenerico -> mandatedetail");
            if (!res) return false;

            return true;
		}

		private static bool impostaIdIvaKind(Form form, DataAccess destConn, DataTable tMandateDetail) {
            DataTable tIvaKind = destConn.SQLRunner("SELECT * from ivakind");
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
            object idivakind = tIvaKind.Compute("MAX(idivakind)", null);
            idivakind = CfgFn.GetNoNullInt32(idivakind) + 1;
			DataRow rIvaKind = tIvaKind.NewRow();
			int nRow = tIvaKind.Rows.Count;
			rIvaKind["codeivakind"] = "SW_" + (nRow + 1);
			string description = (ivaPercentage != 0) ? "Aliquota al " + (ivaPercentage * 100) + " %" : "Esente IVA";
            rIvaKind["idivakind"] = idivakind;
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
        /// Crea la nuova tabella mandatekind riempendola con due sola righe (idmankind='GENERALE','PATRIMONIO')
        /// </summary>
        /// <param name="form"></param>
        /// <param name="sourceConn"></param>
        /// <param name="destConn"></param>
        /// <returns></returns>
        public static bool creaMandateKind(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("mandatekind", null, true) > 0) return true;

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

            r = tMandateKind.NewRow();
            r["idmankind"] = "Patrimonio";
            r["description"] = "Tipo ordine inventariale";
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
       
       
        /// <summary>
		/// Copia ordinegenerico in mandate ponendo idmankind='GENERALE'
		/// </summary>
		/// <param name="form"></param>
		/// <param name="sourceConn"></param>
		/// <param name="destConn"></param>
		public static bool migraOrdineGenerico(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("mandate", null, false)>0) return true;

            creaMandateKind(form, sourceConn, destConn);
            Anagrafica.migraValuta(form, sourceConn, destConn);
            Patrimonio.EsportaResponsabile(form, sourceConn, destConn);
            Anagrafica.migraCreditoreDebitore(form, sourceConn, destConn);
            Anagrafica.RiempiLookupIdexpiration();

            string query = "SELECT active=flagutilizzabile, "
                + "adate=datacontabile, "
                + "ct=ordinegenerico.createtimestamp, "
                + "cu=ordinegenerico.createuser, "
                + "deliveryaddress=indirizzoconsegna, "
                + "deliveryexpiration=termineconsegna, "
                + "description=ordinegenerico.descrizione, "
                + "doc=documento, "
                + "docdate=datadocumento, "
                + "exchangerate=tassocambio, "
                + "ordinegenerico.codicevaluta, "
                + "tiposcadenza,"
                + "codiceresponsabile, "
                + "idmankind='GENERALE', "
                + "REG.idreg, "
                + "lt=ordinegenerico.lastmodtimestamp, "
                + "lu=ordinegenerico.lastmoduser, "
                + "nman=numordine, "
                + "officiallyprinted=flagstampa, "
                + "paymentexpiring=scadpagamento, "
                + "registryreference=riferimentocreddeb, "
                + "rtf=ordinegenerico.olenotes, "
                + "txt=ordinegenerico.notes, "
                + "yman=esercordine "
                + "FROM ordinegenerico "
                + "LEFT OUTER JOIN creditoredebitore CR ON CR.codicecreddeb=ordinegenerico.codicecreddeb "
                + "LEFT OUTER JOIN " + getExtAccess(destConn, "registry", true) + " REG "
                + " ON REG.title=CR.denominazione";

            string query2 = "SELECT active=flagutilizzabile, "
                + "adate=datacontabile, "
                + "ct=ordineinventario.createtimestamp, "
                + "cu=ordineinventario.createuser, "
                + "deliveryaddress=indirizzoconsegna, "
                + "deliveryexpiration=termineconsegna, "
                + "description=ordineinventario.descrizione, "
                + "doc=documento, "
                + "docdate=datadocumento, "
                + "exchangerate=tassocambio, "
                + "ordineinventario.codicevaluta, "
				+ "tiposcadenza,"
                + "codiceresponsabile, "
                + "idmankind='GENERALE', "
                + "REG.idreg, "
                + "lt=ordineinventario.lastmodtimestamp, "
                + "lu=ordineinventario.lastmoduser, "
                + "nman=numordine, "
                + "officiallyprinted=flagstampa, "
                + "paymentexpiring=scadpagamento, "
                + "registryreference=riferimentocreddeb, "
                + "rtf=ordineinventario.olenotes, "
                + "txt=ordineinventario.notes, "
                + "yman=esercordine "
                + "FROM ordineinventario "
                + "LEFT OUTER JOIN creditoredebitore CR ON CR.codicecreddeb=ordineinventario.codicecreddeb "
                + "LEFT OUTER JOIN "+getExtAccess(destConn,"registry",true)+" REG "
                + " ON REG.title=CR.denominazione";


			DataTable tMandate = Migrazione.eseguiQuery(sourceConn, query, form);
            tMandate.Columns.Add("idcurrency",typeof(int));
            tMandate.Columns.Add("idman",typeof(int));
            tMandate.Columns.Add("idexpirationkind",typeof(int));
            foreach (DataRow R in tMandate.Rows) {
                if (R["codiceresponsabile"] != DBNull.Value)
                    R["idman"] = gethash(Patrimonio.lookupidman, R["codiceresponsabile"].ToString());
                if (R["codicevaluta"] != DBNull.Value)
                    R["idcurrency"] = gethash(Anagrafica.lookupidcurrency,R["codicevaluta"].ToString());
                if (R["tiposcadenza"] != DBNull.Value)
                    R["idexpirationkind"] = gethash(Anagrafica.lookupidexpiration, R["tiposcadenza"].ToString());
                    }
            tMandate.Columns.Remove("codicevaluta");
            tMandate.Columns.Remove("tiposcadenza");
            tMandate.Columns.Remove("codiceresponsabile");


			tMandate.TableName = "mandate";
			DataSet ds = new DataSet();
			ds.Tables.Add(tMandate);

			if (!Migrazione.lanciaScript(form, destConn, ds, "ordinegenerico -> mandate"))return false;


            tMandate = Migrazione.eseguiQuery(sourceConn, query2, form);
            tMandate.Columns.Add("idcurrency", typeof(int));
            tMandate.Columns.Add("idman", typeof(int));
            tMandate.Columns.Add("idexpirationkind", typeof(int));
            foreach (DataRow R in tMandate.Rows) {
                if (R["codiceresponsabile"] != DBNull.Value)
                    R["idman"] = gethash(Patrimonio.lookupidman, R["codiceresponsabile"].ToString());
                if (R["codicevaluta"] != DBNull.Value)
                    R["idcurrency"] = gethash(Anagrafica.lookupidcurrency, R["codicevaluta"].ToString());
                if (R["tiposcadenza"] != DBNull.Value)
                    R["idexpirationkind"] = gethash(Anagrafica.lookupidexpiration, R["tiposcadenza"].ToString());
            }
            tMandate.Columns.Remove("codicevaluta");
            tMandate.Columns.Remove("codiceresponsabile");
            tMandate.Columns.Remove("tiposcadenza");


            tMandate.TableName = "mandate";
            ds = new DataSet();
            ds.Tables.Add(tMandate);

            if (!Migrazione.lanciaScript(form, destConn, ds, "ordineinventario -> mandate")) return false;

            return true;
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
				DataAccess.AddExtendedProperty(conn,T);
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

			if (NDONE==NTAB)MessageBox.Show("Script "+filename+" creato correttamente");
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
					MessageBox.Show(form, "Non esiste la tabella "+
						T.TableName+"\npertanto non sarà generato lo script per tale tabella.", "ERRORE!");
					continue;
				} 
				DataColumn[] colonne = new DataColumn[T.Columns.Count];
				T.Columns.CopyTo(colonne, 0);
				foreach (DataColumn c in colonne) {
					if (c.ColumnName.ToUpper().StartsWith("DELETE")) {
						//MessageBox.Show("trovata colonna "+T.TableName+"."+c.ColumnName);
						T.Columns.Remove(c);
					}
				}
				DataAccess.AddExtendedProperty(Conn,T);
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
			if (NDONE==NTAB)MessageBox.Show("Script "+filename+" creato correttamente");


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
						MessageBox.Show("Impossibile compilare la vista "+viewname);
						continue;
					}
					All.Append(Tok.val);
					Tok= SPB.NextToken(out skipped);
					All.Append(skipped);
					if (Tok.val.ToLower()!="view") {
						MessageBox.Show("Impossibile compilare la vista "+viewname);
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
				MessageBox.Show("Script "+filenameNonDbo+" e "+filenameDbo+" creati correttamente");
			}
			else {
				MessageBox.Show(NDONE.ToString()+" di "+NSP.ToString()+" viste elaborate");
				foreach (DataRow EL in SysObjects.Rows){
					int id = (int) EL["id"];
					if (id<0) continue;
					MessageBox.Show("La vista "+EL["name"].ToString()+" non è stata elaborata.");

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
						MessageBox.Show("Impossibile compilare la sp "+spname);
						continue;
					}
					All.Append(Tok.val);
					Tok= SPB.NextToken(out skipped);
					All.Append(skipped);
					string tipo = Tok.val;
					if ((Tok.val.ToLower()!="procedure")&&(Tok.val.ToLower()!="trigger")&&
							(Tok.val.ToLower()!="function")){
						MessageBox.Show("Impossibile compilare la sp "+spname);
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
							MessageBox.Show("Impossibile compilare il trigger "+spname);
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
				MessageBox.Show("Script "+filenamedbo+" e "+filenamenondbo+" creati correttamente");
			}
			else {
				MessageBox.Show(NDONE.ToString()+" di "+NSP.ToString()+" s.p. elaborate");
				foreach (DataRow EL in SysObjects.Rows){
					int id = (int) EL["id"];
					if (id<0) continue;
					MessageBox.Show("La sp "+EL["name"].ToString()+" non è stata elaborata.");

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
				MessageBox.Show(form, errMsg);
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
						MessageBox.Show(form, xtype+" è un xtype non conosciuto");
						break;
				}
			}
			rView["dbo"] = isDbo ? "S" : "N";
			return isDbo;
		}

		private static string getFiltroVista(string id) {
			return "(objectproperty("+id+",'isview')=1) and (OBJECTPROPERTY("+id+", 'IsMSShipped')=0) and (object_name("+id+") not like 'delete%')";
		}


	

		public static bool creaMovBancari(Form form, DataAccess sourceConn, DataAccess destConn, string IoE, Hashtable H) {
            Upb.migraMandati(form, sourceConn, destConn);
            Upb.migraReversali(form, sourceConn, destConn);
            Anagrafica.migraCreditoreDebitore(form, sourceConn, destConn);
            
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
                    + "tipomovbancario, movimentobancario.codicecreddeb,REG.idreg, movimentobancario.descrizione, "
                    + "PT.kpay, "
                    + "importo, rifbanca, numoperazione= isnull(numoperazione,0) , "
                    + "movimentobancario.createuser,movimentobancario.createtimestamp,movimentobancario.lastmoduser,movimentobancario.lastmodtimestamp,"
                    + "dataoperazione, datavaluta "
                    + "FROM movimentobancario "
                    + " LEFT OUTER JOIN creditoredebitore CR ON CR.codicecreddeb=movimentobancario.codicecreddeb "
                    + " LEFT OUTER JOIN "+getExtAccess(destConn,"registry",true)+" REG "
                    + "   ON REG.title=CR.denominazione "
                    + " LEFT OUTER JOIN "+getExtAccess(destConn,"payment",false)+" PT "
                    + "  ON PT.ypay= movimentobancario.esercdocumento "
                    +"  AND PT.npay= movimentobancario.numdocumento " 
                    + "WHERE tipomovbancario = '" + kind + "' and esercdocumento is not null and numdocumento is not null "
                    + "AND EXISTS (SELECT idspesa from spesa WHERE spesa.esercmovbancario = movimentobancario.esercmovbancario AND "
                    + "spesa.nummovbancario = movimentobancario.nummovbancario ) " 
                    + " order by  esercdocumento,numdocumento,isnull(numoperazione,0)";
            }
            else
            {
                q1 = "SELECT "
                  + "nummovbancario, esercmovbancario, "
                  + "tipomovbancario, movimentobancario.codicecreddeb,REG.idreg,  movimentobancario.descrizione, "
                  + "PT.kpro, "
                  + "importo, rifbanca, numoperazione= isnull(numoperazione,0) , "
                  + "movimentobancario.createuser,movimentobancario.createtimestamp,movimentobancario.lastmoduser,movimentobancario.lastmodtimestamp,"
                  + "dataoperazione, datavaluta "
                  + "FROM movimentobancario "
                  + " LEFT OUTER JOIN creditoredebitore CR ON CR.codicecreddeb=movimentobancario.codicecreddeb "
                  + " LEFT OUTER JOIN " + getExtAccess(destConn, "registry", true) + " REG "
                  + "   ON REG.title = CR.denominazione "
                  + " LEFT OUTER JOIN " + getExtAccess(destConn, "proceeds", false) + " PT "
                  + "  ON PT.ypro= movimentobancario.esercdocumento " 
                  +"  AND PT.npro= movimentobancario.numdocumento " 
                  +"WHERE tipomovbancario = '" + kind + "' and esercdocumento is not null and numdocumento is not null "
                  + "AND EXISTS (SELECT identrata from entrata WHERE entrata.esercmovbancario = movimentobancario.esercmovbancario AND "
                  + "entrata.nummovbancario = movimentobancario.nummovbancario ) "
                  + " order by  esercdocumento,numdocumento,isnull(numoperazione,0)" ;

            }
			DataTable tMovBancario_src = eseguiQuery(sourceConn, q1, form);
			if (tMovBancario_src == null) return false;

            string kfield = (IoE == "I") ? "kpro" : "kpay";
            string idfield = (IoE == "I") ? "idpro" : "idpay";

            foreach(DataRow rmov in tMovBancario_src.Rows) {
                int oldnumop = CfgFn.GetNoNullInt32(rmov["numoperazione"]);
                int newop = CfgFn.GetNoNullInt32(GetNumOperazioneForNewMov(tPXXX_Bank, rmov,
                    kfield,  idfield));
                if(newop != oldnumop) SetNumOperazione(H,
                    rmov["esercmovbancario"], rmov["nummovbancario"], newop);
                DataRow rDest = tPXXX_Bank.NewRow();
                rDest[kfield] = rmov[kfield];
                rDest[idfield] =newop;
                rDest["idreg"] = rmov["idreg"];
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
        static object GetNumOperazioneForNewMov(DataTable TMov, DataRow R,string kfield, string idfield) {
            string filter= "("+kfield+"="+R[kfield].ToString()+")AND"+
                           "("+idfield+"="+R["numoperazione"].ToString()+")";
            if (TMov.Select(filter).Length==0) return R["numoperazione"];
            int N = CfgFn.GetNoNullInt32(R["numoperazione"])+1;
            while(true) {
                filter = "(" + kfield + "=" + R[kfield].ToString() + ")AND" +
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
            Upb.migraEntrata(form, sourceConn, destConn);
            Upb.migraSpesa(form, sourceConn, destConn);

			string kfield = (IoE == "I") ? "kpro" : "kpay";
			string idfield = (IoE == "I") ? "idpro" : "idpay";
			string kind = (IoE == "I") ? "C" : "D";
			string tabMovFin_dest = (IoE == "I") ? "income" : "expense";
			string idfieldmov_dest = (IoE == "I") ? "idinc" : "idexp";
			
            //object maxphase_dest = destConn.GetSys("max" + tabMovFin_dest + "phase");
            //string filterPhase = "(nphase = '" + maxphase_dest + "')";

			string query;
            if (IoE == "I") {
                query = "SELECT "
                + "nummovbancario, esercmovbancario, "
                + "tipomovbancario, "
                + "PT.kpro, "
                + "importo, rifbanca, numoperazione=isnull(numoperazione,0)  , "
                + "createuser,createtimestamp,lastmoduser,lastmodtimestamp,"
                + "dataoperazione, datavaluta "
                + "from movimentobancario "
                + " LEFT OUTER JOIN " + getExtAccess(destConn, "proceeds", false) + " PT "
                + "  ON PT.ypro= movimentobancario.esercdocumento "
                + "  AND PT.npro= movimentobancario.numdocumento "
            + "where tipomovbancario = '" + kind + "' "
                + "and flagesito = 'S' and esercdocumento is not null and numdocumento is not null";
            }
            else {
                query = "SELECT "
                + "nummovbancario, esercmovbancario, "
                + "tipomovbancario, "
                + "PT.kpay, "
                + "importo, rifbanca, numoperazione=isnull(numoperazione,0)  , "
                + "createuser,createtimestamp,lastmoduser,lastmodtimestamp,"
                + "dataoperazione, datavaluta "
                + "from movimentobancario "
                + " LEFT OUTER JOIN " + getExtAccess(destConn, "payment", false) + " PT "
                    + "  ON PT.ypay= movimentobancario.esercdocumento "
                    + "  AND PT.npay= movimentobancario.numdocumento "
                + "where tipomovbancario = '" + kind + "' "
                + "and flagesito = 'S' and esercdocumento is not null and numdocumento is not null";

            }

			// Tabelle di PARTENZA
			DataTable tMovBancario_src = eseguiQuery(sourceConn, query, form);
			if (tMovBancario_src == null) return false;

			// BANKTRANSACTION (Tabella degli esiti)
			DataTable bankTransaction = DataAccess.CreateTableByName(destConn, "banktransaction", "*");
			bankTransaction.Clear();

			string tabMovFin_src = (IoE == "I") ? "entrataview" : "spesaview";
			string idfieldmov_src = (IoE == "I") ? "idinc" : "idexp";

			string listaCampiMov_src = idfieldmov_src + ", importocorrente, esercmovbancario, nummovbancario ";

			DataTable tMovFin_src;
            if (IoE == "I") {
                string jj = "SELECT I.idinc,E.importocorrente,E.esercmovbancario, E.nummovbancario " +
                    " FROM ENTRATAVIEW E " +
                    " JOIN " + getExtAccess(destConn, "income", false) + " I " +
                    "  ON I.ymov= E.esercmovimento " +
                    "  AND I.nmov = E.nummovimento " +
                    "  AND I.nphase = convert(int,E.codicefase) " +
                    " WHERE (E.esercmovbancario IS NOT NULL)";
                tMovFin_src = sourceConn.SQLRunner(jj);

            }
            else {
                tMovFin_src = sourceConn.SQLRunner(
                      "SELECT E.idexp,S.importocorrente,S.esercmovbancario, S.nummovbancario " +
                      " FROM SPESAVIEW S " +
                      " JOIN " + getExtAccess(destConn, "expense", false) + " E " +
                      "  ON E.ymov= S.esercmovimento " +
                      "  AND E.nmov = S.nummovimento " +
                      "  AND E.nphase = convert(int,S.codicefase) " +
                        " WHERE (S.esercmovbancario IS NOT NULL)");
            }
           
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
			string kfield = (IoE == "I") ? "kpro" : "kpay";
			string idfield = (IoE == "I") ? "idpro" : "idpay";
			string kind = (IoE == "I") ? "C" : "D";
			string tabMovFin_dest = (IoE == "I") ? "income" : "expense";
			string idfieldmov_dest = (IoE == "I") ? "idinc" : "idexp";

			object maxphase_dest = destConn.GetSys("max" + tabMovFin_dest + "phase");
			string filterPhase = "(nphase = '" + maxphase_dest + "')";

			// BANKTRANSACTION (Tabella degli esiti)
			DataTable bankTransaction = DataAccess.CreateTableByName(destConn, "banktransaction", "*");
			bankTransaction.Clear();

			string q2;
            if (IoE == "I") {
                q2 = "SELECT "
                + "m.nummovbancario, m.esercmovbancario, "
                + "m.tipomovbancario, "
                + "pt.kpro, "
                + "d.importo, d.rifbanca, numoperazione= isnull(m.numoperazione,0) , "
                + "d.lastmoduser, d.lastmodtimestamp, d.createuser, d.createtimestamp, "
                + "d.dataoperazione, d.datavaluta "
                + "from movimentobancario m "
                + "join dettmovimentobancario d "
                + "on m.esercmovbancario = d.esercmovbancario "
                + "and m.nummovbancario = d.nummovbancario "
                + " LEFT OUTER JOIN " + getExtAccess(destConn, "proceeds", false) + " PT "
                + "  ON PT.ypro= M.esercdocumento "
                + "  AND PT.npro= M.numdocumento "
                + "where m.tipomovbancario = '" + kind + "' "
                + "and m.flagesito = 'P' and m.esercdocumento is not null and m.numdocumento is not null";
            }
            else {
                q2 = "SELECT "
                + "m.nummovbancario, m.esercmovbancario, "
                + "m.tipomovbancario, "
                + "pt.kpay, "
                + "d.importo, d.rifbanca, numoperazione= isnull(m.numoperazione,0) , "
                + "d.lastmoduser, d.lastmodtimestamp, d.createuser, d.createtimestamp, "
                + "d.dataoperazione, d.datavaluta "
                + "from movimentobancario m "
                + "join dettmovimentobancario d "
                + "on m.esercmovbancario = d.esercmovbancario "
                + " LEFT OUTER JOIN " + getExtAccess(destConn, "payment", false) + " PT "
                + "  ON PT.ypay= M.esercdocumento "
                + "  AND PT.npay= M.numdocumento "
                + "where m.tipomovbancario = '" + kind + "' "
                + "and m.flagesito = 'P' and m.esercdocumento is not null and m.numdocumento is not null";



            }

			string tabMovFin_src = (IoE == "I") ? "entrataview" : "spesaview";
			string idfieldmov_src = (IoE == "I") ? "idinc" : "idexp";

			// Dettagli mov. bancari
			DataTable tDettMovBanc = eseguiQuery(sourceConn, q2, form);
			if (tDettMovBanc == null) return false;

			string listaCampiMov_src = idfieldmov_src + ", importo, importocorrente, esercmovbancario, nummovbancario";
			if (IoE == "E") {
				listaCampiMov_src += ", importoritenute";
			}
            DataTable tMovFin_src;
            if (IoE == "I") {
                string sql = "SELECT I.idinc,E.importo, E.importocorrente,E.esercmovbancario, E.nummovbancario " +
                    " FROM ENTRATAVIEW E " +
                    " JOIN " + getExtAccess(destConn, "income", false) + " I " +
                    "  ON I.ymov= E.esercmovimento " +
                    "  AND I.nmov = E.nummovimento " +
                    "  AND I.nphase = convert(int,E.codicefase) " +
                    " WHERE (E.esercmovbancario IS NOT NULL)";
                tMovFin_src = sourceConn.SQLRunner(sql);

            }
            else {
                string sql =
                      "SELECT E.idexp,S.importo, S.importocorrente,S.esercmovbancario, S.nummovbancario,S.importoritenute " +
                      " FROM SPESAVIEW S " +
                      " JOIN " + getExtAccess(destConn, "expense", false) + " E " +
                      "  ON E.ymov= S.esercmovimento " +
                      "  AND E.nmov = S.nummovimento " +
                      "  AND E.nphase = convert(int,S.codicefase) " +
                        " WHERE (S.esercmovbancario IS NOT NULL)";
                tMovFin_src = sourceConn.SQLRunner(sql);
            }
           
			if (tMovFin_src == null) return false;

			// Tabella temporanea dei movimenti finanziari
			DataTable temp = new DataTable();
			temp.Columns.Add("idmov",typeof(int));
			temp.Columns.Add("curramount",typeof(decimal));
            temp.Columns.Add("performedamount", typeof(decimal));
            temp.Columns.Add("residual", typeof(decimal));

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
            //tMovFin_src ha gli idinc/idexp di destinazione

			string idfieldmov_src = (IoE == "I") ? "idinc" : "idexp";
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
                        MessageBox.Show("Il movimento bancario " + tipo + " " +
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
            //tMovFin_src ha gli idinc/idexp di destinazione

			string idfieldmov_src = (IoE == "I") ? "idinc" : "idexp";

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
            //tMovFin_src ha gli idinc/idexp di destinazione

			string idfieldmov_src = "idexp";

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
            //tMovFin_src ha gli idinc/idexp di destinazione

			string idfieldmov_src = "idexp";

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
            //tMovFin_src ha gli idinc/idexp di destinazione

			string idfieldmov_src = (IoE == "I") ? "idinc" : "idexp";
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
                    MessageBox.Show("Non sono riuscito ad esitare il movimento bancario " + tipo + " " +
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
                    MessageBox.Show("Non sono riuscito ad esitare il movimento bancario " + tipo + " " +
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
            Upb.migraEntrata(form, sourceConn, destConn);
            Upb.migraSpesa(form, sourceConn, destConn);

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
			string kfield = (IoE == "I") ? "kpro" : "kpay";
			string idfield = (IoE == "I") ? "idpro" : "idpay";
			string idmov = (IoE == "I") ? "idinc" : "idexp";

            object nban = ht[movBancarioSource["esercmovbancario"]];
			int nban_free = CfgFn.GetNoNullInt32(nban) + 1;
            ht[movBancarioSource["esercmovbancario"]] = nban_free;

			DataRow rBT = banktransaction.NewRow();
			rBT["yban"] = movBancarioSource["esercmovbancario"];
			rBT["nban"] = nban_free;
			rBT["amount"] = amount;
			rBT["bankreference"] = movBancarioSource["rifbanca"];
			rBT["kind"] = movBancarioSource["tipomovbancario"];
			rBT[kfield] = movBancarioSource[kfield];

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
			bool ok = Download.RUN_SCRIPT(destConn, sw.GetStringBuilder(), nomeCopia);
			if (!ok) {
				StreamWriter fsw = new StreamWriter("temp.sql", false, Encoding.Default);
				fsw.Write(sw.ToString());
				fsw.Close();
				MessageBox.Show(form, "Errore durante la copia: "+nomeCopia+"\r\nLo script lanciato si trova nel file 'temp.sql'");
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
            if (destConn.RUN_SELECT_COUNT("license", null, true) > 0) return true;

			string query = "select address1=indirizzo_1, address2=indirizzo_2, "
				+ "agency=nomeuniversita, agencycode=NULL, agencyname=nomeuniversita, "
				+ "annotations=NULL, cap = cap, cf=codicefiscale, "
				+ "checkbackup1 = NULL, checkbackup2 = NULL, checkflag = NULL, checklic = NULL, checkman = NULL, "
				+ "country=provincia, dbname=null, "
				+ "department=nomeente, departmentcode = NULL, departmentname=nomeente, "
				+ "dummykey = 1, email = NULL, expiringlic = NULL, expiringman = NULL, "
				+ "fax = NULL, iddb = NULL, idreg= NULL, "
				+ "lickind= NULL, licstatus= NULL, location=localita, "
				+ "lt=GETDATE(), lu='migrazione', "
				+ "mankind=NULL, manstatus=NULL, nmsgs = NULL, "
				+ "p_iva=partitaiva, phonenumber=NULL, referent=NULL, "
				+ "sent=NULL, serverbackup1 = NULL, serverbackup2 = NULL, servername = NULL, "
				+ "swmorecode = NULL, swmoreflag = NULL "
				+ "from licenzauso";
			DataTable t = Migrazione.eseguiQuery(sourceConn, query, form);
			if (t==null) return false;
			t.TableName = "license";
			return Migrazione.lanciaScript(form, destConn, t, "licenzauso -> license");
		}


        /// <summary>
        /// Metodo che migra i dati in CONFIG
        /// </summary>
        /// <param name="form"></param>
        /// <param name="sourceConn"></param>
        /// <param name="destConn"></param>
        /// <returns></returns>
        public static bool migraConfigurazione(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("config", null, true) > 0) return true;
            CQueryHelper QHC = new CQueryHelper();
            QueryHelper QHS = sourceConn.GetQueryHelper();

            Upb.migraBilancio(form, sourceConn, destConn);
            Iva.migraTipoPeriodLiqIva(form, sourceConn, destConn);
            Upb.migraTipoRecupero(form, sourceConn, destConn);
            Anagrafica.migraCreditoreDebitore(form, sourceConn, destConn);

            string qEsercizio = "SELECT * FROM esercizio";
            DataTable tEsercizio = sourceConn.SQLRunner(qEsercizio);
            if (tEsercizio == null) {
                string msg = "Errore nell'estrazione degli esercizi esistenti";
                MessageBox.Show(form, msg, "Errore");
                return false;
            }

            string qb = "SELECT * FROM persbilancio";
            DataTable tPersBilancio = sourceConn.SQLRunner(qb);
            if (tPersBilancio == null) {
                string msg = "Errore nell'estrazione della configurazione del bilancio";
                MessageBox.Show(form, msg, "Errore");
                return false;
            }

            string qs = "SELECT * FROM persspesa";
            DataTable tPersSpesa = sourceConn.SQLRunner(qs);
            if (tPersSpesa == null) {
                string msg = "Errore nell'estrazione della configurazione generale di spesa";
                MessageBox.Show(form, msg, "Errore");
                return false;
            }

            string qe = "SELECT * FROM persentrata";
            DataTable tPersEntrata = sourceConn.SQLRunner(qe);
            if (tPersEntrata == null) {
                string msg = "Errore nell'estrazione della configurazione generale di entrata";
                MessageBox.Show(form, msg, "Errore");
                return false;
            }

            string qm = "SELECT * FROM persmissione";
            DataTable tPersMissione = sourceConn.SQLRunner(qm);
            if (tPersMissione == null) {
                string msg = "Errore nell'estrazione della configurazione delle missioni";
                MessageBox.Show(form, msg, "Errore");
                return false;
            }

            string qi = "SELECT * FROM persiva";
            DataTable tPersIva = sourceConn.SQLRunner(qi);
            if (tPersIva == null) {
                string msg = "Errore nell'estrazione della configurazione dell'IVA";
                MessageBox.Show(form, msg, "Errore");
                return false;
            }

            string qc = "SELECT * FROM persgenautomovimenti";
            DataTable tPersCassiere = sourceConn.SQLRunner(qc);
            if (tPersCassiere == null) {
                string msg = "Errore nell'estrazione della configurazione del cassiere";
                MessageBox.Show(form, msg, "Errore");
                return false;
            }

            string qp = "SELECT * FROM perspatrimonio";
            DataTable tPersPatrimonio = sourceConn.SQLRunner(qp);
            if (tPersPatrimonio == null) {
                string msg = "Errore nell'estrazione della configurazione della gestione patrimoniale";
                MessageBox.Show(form, msg, "Errore");
                return false;
            }

            DataTable tConfig = destConn.CreateTableByName("config", "*");

            foreach (DataRow rEsercizio in tEsercizio.Rows) {
                DataRow rConfig = tConfig.NewRow();

                rConfig["ayear"] = CfgFn.GetNoNullInt32(rEsercizio["esercizio"]);
                string filter = QHC.CmpEq("esercizio", rEsercizio["esercizio"]);
                string filterSQL = QHS.CmpEq("esercizio", rEsercizio["esercizio"]);

                DataRow[] PersBilancio = tPersBilancio.Select(filter);
                if (PersBilancio.Length > 0) {
                    DataRow rPersBilancio = PersBilancio[0];
                    rConfig["assessmentphasecode"] = CfgFn.GetNoNullInt32(rPersBilancio["codfaseaccertamento"]);
                    rConfig["appropriationphasecode"] = CfgFn.GetNoNullInt32(rPersBilancio["codfaseimpegno"]);
                    int cashvaliditykind = 0;
                    string flagvaliditadocumenti = rPersBilancio["flagvaliditadocumenti"].ToString().ToUpper();
                    switch (flagvaliditadocumenti) {
                        case "E": {
                                cashvaliditykind = 1;
                                break;
                            }
                        case "S": {
                                cashvaliditykind = 2;
                                break;
                            }
                        case "T": {
                                cashvaliditykind = 3;
                                break;
                            }
                        default: {
                                cashvaliditykind = 0;
                                break;
                            }
                    }
                    rConfig["cashvaliditykind"] = cashvaliditykind;
                    int fin_kind = 0;
                    string pp = rPersBilancio["tipoprevprincipale"].ToString().ToUpper();
                    string ps = rPersBilancio["tipoprevsecondaria"].ToString().ToUpper();
                    if (pp == "C") {
                        if (ps == "S") {
                            fin_kind = 3;
                        }
                        else {
                            fin_kind = 1;
                        }
                    }
                    if (pp == "S") {
                        fin_kind = 2;
                    }
                    rConfig["fin_kind"] = fin_kind;
                }

                int flag_autodocnumbering = 0;

                DataRow[] PersSpesa = tPersSpesa.Select(filter);
                if (PersSpesa.Length > 0) {
                    DataRow rPersSpesa = PersSpesa[0];

                    rConfig["expensephase"] = CfgFn.GetNoNullInt32(rPersSpesa["fasespesa"]);
                    rConfig["expense_expiringdays"] = rPersSpesa["giornianticipo"];

                    int taxvaliditykind = 0;
                    string flagcompetenzariten = rPersSpesa["flagcompetenzariten"].ToString().ToUpper();
                    switch (flagcompetenzariten) {
                        case "N": {
                                taxvaliditykind = 1;
                                break;
                            }
                        case "U": {
                                taxvaliditykind = 2;
                                break;
                            }
                        case "M": {
                                taxvaliditykind = 3;
                                break;
                            }
                        case "S": {
                                taxvaliditykind = 4;
                                break;
                            }
                        case "T": {
                                taxvaliditykind = 5;
                                break;
                            }
                        case "E": {
                                taxvaliditykind = 6;
                                break;
                            }
                        default: {
                                taxvaliditykind = 0;
                                break;
                            }
                    }
                    rConfig["taxvaliditykind"] = taxvaliditykind;

                    int automanagekind = 0;
                    string tipocontributi = rPersSpesa["tipocontributi"].ToString().ToUpper();

                    switch (tipocontributi) {
                        case "0": {
                                automanagekind |= 0x01;
                                break;
                            }
                        case "1": {
                                automanagekind |= 0x02;
                                break;
                            }
                        case "2": {
                                automanagekind |= 0x04;
                                break;
                            }
                        case "3": {
                                automanagekind |= 0x08;
                                break;
                            }
                    }

                    string tiporecuperi = rPersSpesa["tiporecuperi"].ToString().ToUpper();

                    if (tiporecuperi != "0") {
                        automanagekind |= 0x10;
                    }

                    string tiporitenute = rPersSpesa["tiporitenute"].ToString().ToUpper();
                    switch (tiporitenute) {
                        case "0": {
                                automanagekind |= 0x100;
                                break;
                            }
                        case "1": {
                                automanagekind |= 0x200;
                                break;
                            }
                        case "2": {
                                automanagekind |= 0x400;
                                break;
                            }
                    }

                    rConfig["automanagekind"] = automanagekind;

                    int payment_flag = 0;

                    string flagtrasmresponsabile = rPersSpesa["flagtrasmresponsabile"].ToString().ToUpper();
                    if (flagtrasmresponsabile == "S") {
                        payment_flag += 1;
                    }

                    string flagbilancio = rPersSpesa["flagbilancio"].ToString().ToUpper();
                    if (flagbilancio == "S") {
                        payment_flag += 2;
                    }

                    string flagcreditoredebitore = rPersSpesa["flagcreditoredebitore"].ToString().ToUpper();
                    if (flagcreditoredebitore == "S") {
                        payment_flag += 4;
                    }

                    string flagresidui = rPersSpesa["flagresidui"].ToString().ToUpper();
                    if (flagresidui == "S") {
                        payment_flag += 8;
                    }

                    string flagresponsabile = rPersSpesa["flagresponsabile"].ToString().ToUpper();
                    if (flagresponsabile == "S") {
                        payment_flag += 16;
                    }

                    rConfig["payment_flag"] = payment_flag;

                    if (flagbilancio == "S") {
                        object maxLevel = sourceConn.DO_READ_VALUE("livellobilancio", filterSQL, "MAX(codicelivello)");
                        if ((maxLevel != null) && (maxLevel != DBNull.Value)) {
                            rConfig["payment_finlevel"] = CfgFn.GetNoNullInt32(maxLevel);
                        }
                    }

                    int flag_paymentamount = 0;

                    string flagrecuperi = rPersSpesa["flagrecuperi"].ToString().ToUpper();
                    if (flagrecuperi == "S") {
                        flag_paymentamount += 1;
                    }

                    string flagcontributi = rPersSpesa["flagcontributi"].ToString().ToUpper();
                    if (flagcontributi == "S") {
                        flag_paymentamount += 2;
                    }

                    string flagritenute = rPersSpesa["flagritenute"].ToString().ToUpper();
                    if (flagritenute == "S") {
                        flag_paymentamount += 4;
                    }

                    rConfig["flag_paymentamount"] = flag_paymentamount;
                    rConfig["payment_flagautoprintdate"] = "N";
                    rConfig["flagautopayment"] = "N";

                    string fSostImp = QHS.CmpEq("tiporesidenza", 'R');

                    string qCD = "SELECT idreg = MAX(R.idreg) FROM creditoredebitore C " +
                        " JOIN " + getExtAccess(destConn, "registry", true) + " R " +
                        " ON C.denominazione = R.title " +
                        " WHERE " + fSostImp;

                    DataTable tCD = sourceConn.SQLRunner(qCD);
                    if ((tCD != null) && (tCD.Rows.Count > 0)) {
                        DataRow rCD = tCD.Rows[0];
                        rConfig["idregauto"] = rCD["idreg"];
                    }

                    string tiponumerazione = rPersSpesa["tiponumerazione"].ToString().ToUpper();
                    if (tiponumerazione == "M") {
                        flag_autodocnumbering = flag_autodocnumbering + 2;
                    }
                }

                DataRow[] PersEntrata = tPersEntrata.Select(filter);
                if (PersEntrata.Length > 0) {
                    DataRow rPersEntrata = PersEntrata[0];

                    object faseRegistry = sourceConn.DO_READ_VALUE("faseentrata",
                        QHS.CmpEq("flagcreditoredebitore", 'S'), "MIN(codicefase)");
                    if ((faseRegistry != null) && (faseRegistry != DBNull.Value)) {
                        rConfig["incomephase"] = CfgFn.GetNoNullInt32(faseRegistry);
                    }

                    rConfig["income_expiringdays"] = rPersEntrata["giornianticipo"];

                    int proceeds_flag = 0;

                    string flagtrasmresponsabile = rPersEntrata["flagtrasmresponsabile"].ToString().ToUpper();
                    if (flagtrasmresponsabile == "S") {
                        proceeds_flag += 1;
                    }

                    string flagbilancio = rPersEntrata["flagbilancio"].ToString().ToUpper();
                    if (flagbilancio == "S") {
                        proceeds_flag += 2;
                    }

                    string flagcreditoredebitore = rPersEntrata["flagcreditoredebitore"].ToString().ToUpper();
                    if (flagcreditoredebitore == "S") {
                        proceeds_flag += 4;
                    }

                    string flagresidui = rPersEntrata["flagresidui"].ToString().ToUpper();
                    if (flagresidui == "S") {
                        proceeds_flag += 8;
                    }

                    string flagresponsabile = rPersEntrata["flagresponsabile"].ToString().ToUpper();
                    if (flagresponsabile == "S") {
                        proceeds_flag += 16;
                    }

                    rConfig["proceeds_flag"] = proceeds_flag;

                    if (flagbilancio == "S") {
                        object maxLevel = sourceConn.DO_READ_VALUE("livellobilancio", filterSQL, "MAX(codicelivello)");
                        if ((maxLevel != null) && (maxLevel != DBNull.Value)) {
                            rConfig["proceeds_finlevel"] = CfgFn.GetNoNullInt32(maxLevel);
                        }
                    }

                    rConfig["proceeds_flagautoprintdate"] = "N";
                    rConfig["flagautoproceeds"] = "N";
                }

                DataRow[] PersMissione = tPersMissione.Select(filter);
                if (PersMissione.Length > 0) {
                    DataRow rPersMissione = PersMissione[0];

                    DateTime dec31 = new DateTime(CfgFn.GetNoNullInt32(rEsercizio["esercizio"]), 12, 31);
                    string qGenMiss = "SELECT TOP 1 oreestero FROM generalitamissioni WHERE "
                    + QHS.CmpLe("datainizio", dec31) + " ORDER BY datainizio DESC";
                    DataTable tGenMiss = sourceConn.SQLRunner(qGenMiss);
                    if ((tGenMiss != null) && (tGenMiss.Rows.Count != 0)) {
                        DataRow rGenMiss = tGenMiss.Rows[0];
                        object foreignHours = CfgFn.GetNoNullInt32(rGenMiss["oreestero"]);
                        rConfig["foreignhours"] = foreignHours;
                    }

                    string qBilRec = "SELECT idfinexpense = F.idfin, idclawback = C.idclawback " +
                    " FROM persmissione M " +
                    " LEFT OUTER JOIN tiporecupero T " +
                    " ON T.codicerecupero = M.codicerecupero " +
                    " LEFT OUTER JOIN " + getExtAccess(destConn, "clawback", true) + " C " +
                    " ON C.clawbackref = T.codicerecupero " +
                    " LEFT OUTER JOIN bilancio B ON M.idbilspesa = B.idbilancio " +
                    " LEFT OUTER JOIN " + getExtAccess(destConn, "fin", false) + " F " +
                    "  ON F.codefin = B.codicebilancio " +
                    "  AND F.ayear= B.esercizio " +
                    "  AND ( ((F.flag & 1)<>0 AND (B.partebilancio='S')) )"
                    + " WHERE M.esercizio = " + QHS.quote(rEsercizio["esercizio"]);

                    DataTable tApp = sourceConn.SQLRunner(qBilRec);
                    if ((tApp != null) && (tApp.Rows.Count > 0)) {
                        DataRow rApp = tApp.Rows[0];
                        rConfig["idfinexpense"] = rApp["idfinexpense"];
                        rConfig["idclawback"] = rApp["idclawback"];
                    }
                }

                DataRow[] PersIva = tPersIva.Select(filter);
                if (PersIva.Length > 0) {
                    DataRow rPersIva = PersIva[0];

                    rConfig["deferredincomephase"] = "E";
                    rConfig["deferredexpensephase"] = "T";
                    rConfig["paymentagency"] = rPersIva["enteversamento"];
                    rConfig["flagpayment"] = rPersIva["movversamento"];
                    rConfig["minpayment"] = rPersIva["minversamento"];
                    rConfig["refundagency"] = rPersIva["enterimborso"];
                    rConfig["flagrefund"] = rPersIva["movrimborso"];
                    rConfig["minrefund"] = rPersIva["minrimborso"];

                    string qBilES = "SELECT idfinivapayment = FS.idfin, idfinivarefund = FE.idfin " +
                       " FROM persiva I " +
                       " LEFT OUTER JOIN bilancio BE ON I.bilanciorimborso = BE.idbilancio AND I.esercizio = BE.esercizio " +
                       " LEFT OUTER JOIN bilancio BS ON I.bilancioversamento = BS.idbilancio AND I.esercizio = BS.esercizio " +
                       " LEFT OUTER JOIN " + getExtAccess(destConn, "fin", false) + " FE " +
                       "  ON FE.codefin = BE.codicebilancio " +
                       "  AND FE.ayear= BE.esercizio " +
                       "  AND ( ((FE.flag & 1)=0 AND (BE.partebilancio='E')) )" +
                       " LEFT OUTER JOIN " + getExtAccess(destConn, "fin", false) + " FS " +
                       "  ON FS.codefin = BS.codicebilancio " +
                       "  AND FS.ayear = BS.esercizio " +
                       "  AND ( ((FS.flag & 1)<>0 AND (BS.partebilancio='S')) )" +
                       " WHERE I.esercizio = " + QHS.quote(rEsercizio["esercizio"]);

                    DataTable tBilES = sourceConn.SQLRunner(qBilES);
                    if ((tBilES != null) && (tBilES.Rows.Count > 0)) {
                        DataRow rBilES = tBilES.Rows[0];
                        rConfig["idfinivapayment"] = rBilES["idfinivapayment"];
                        rConfig["idfinivarefund"] = rBilES["idfinivarefund"];
                    }

                    string qPeriod = "SELECT idivapayperiodicity = PP.idivapayperiodicity " +
                       " FROM persiva I " +
                       " LEFT OUTER JOIN tipoperiodliquiva T ON T.codicetipoper = I.codicetipoper " +
                       " LEFT OUTER JOIN " + getExtAccess(destConn, "ivapayperiodicity", true) + " PP " +
                       "  ON PP.periodicity = T.periodicita " +
                       "  AND PP.periodicday = T.giornoper " +
                       "  AND PP.periodicmonth = T.meseper " +
                       " WHERE I.esercizio = " + QHS.quote(rEsercizio["esercizio"]);

                    DataTable tPeriod = sourceConn.SQLRunner(qPeriod);
                    if ((tPeriod != null) && (tPeriod.Rows.Count > 0)) {
                        DataRow rPeriod = tPeriod.Rows[0];
                        rConfig["idivapayperiodicity"] = rPeriod["idivapayperiodicity"];
                    }

                    string tiponumerazione = rPersIva["tiponumerazione"].ToString().ToUpper();
                    if (tiponumerazione == "M") {
                        flag_autodocnumbering = flag_autodocnumbering + 4;
                    }
                }

                DataRow[] PersCassiere = tPersCassiere.Select(filter);
                if (PersCassiere.Length > 0) {
                    DataRow rPersCassiere = PersCassiere[0];

                    rConfig["appname"] = rPersCassiere["programma"];
                    rConfig["electronictrasmission"] = rPersCassiere["trasmelettronica"];
                    rConfig["importappname"] = "S";
                    rConfig["motivelen"] = rPersCassiere["lunghcausale"];
                    rConfig["motiveprefix"] = rPersCassiere["prefissocausale"];
                    rConfig["motiveseparator"] = rPersCassiere["separatorecausale"];

                    int flagbank_grouping = 0;

                    string tiporaggruppagamenti = rPersCassiere["tiporaggruppagamenti"].ToString().ToUpper();
                    switch (tiporaggruppagamenti) {
                        case "N": {
                                flagbank_grouping |= 0x01;
                                break;
                            }
                        case "C": {
                                flagbank_grouping |= 0x02;
                                break;
                            }
                        case "P": {
                                flagbank_grouping |= 0x04;
                                break;
                            }
                    }

                    string tiporaggrupincassi = rPersCassiere["tiporaggrupincassi"].ToString().ToUpper();
                    switch (tiporaggruppagamenti) {
                        case "N": {
                                flagbank_grouping |= 0x10;
                                break;
                            }
                        case "C": {
                                flagbank_grouping |= 0x20;
                                break;
                            }
                        default: {
                                flagbank_grouping |= 0x10;
                                break;
                            }
                    }

                    rConfig["flagbank_grouping"] = flagbank_grouping;
                }

                DataRow[] PersPatrimonio = tPersPatrimonio.Select(filter);
                if (PersPatrimonio.Length > 0) {
                    DataRow rPersPatrimonio = PersPatrimonio[0];

                    string tiponumerazione = rPersPatrimonio["tiponumerazione"].ToString().ToUpper();
                    if (tiponumerazione == "M") {
                        flag_autodocnumbering = flag_autodocnumbering + 8;
                    }
                }

                rConfig["assetload_flag"] = 0;
                int nMixedRow = destConn.RUN_SELECT_COUNT("invoicekind", QHS.BitSet("flag", 1), true);
                rConfig["linktoinvoice"] = (nMixedRow > 0) ? "S" : "N";

                rConfig["asset_flagrestart"] = "S";
                rConfig["asset_flagnumbering"] = "U";
                rConfig["casualcontract_flagrestart"] = "S";
                rConfig["profservice_flagrestart"] = "S";
                rConfig["wageaddition_flagrestart"] = "S";
                rConfig["flagfruitful"] = "I";
                rConfig["flagepexp"] = "N";

                object existAssCred = sourceConn.DO_READ_VALUE("assegnazionecrediti",
                    QHS.CmpEq("esercassegnazione", rEsercizio["esercizio"]), "COUNT(*)");
                rConfig["flagcredit"] = (CfgFn.GetNoNullInt32(existAssCred) != 0) ? "S" : "N";

                object existAssInc = sourceConn.DO_READ_VALUE("assegnazioneincassi",
                    QHS.CmpEq("esercassegnazione", rEsercizio["esercizio"]), "COUNT(*)");
                rConfig["flagproceeds"] = (CfgFn.GetNoNullInt32(existAssInc) != 0) ? "S" : "N";

                string qBilExp = "SELECT idfinexpensesurplus = FS.idfin " +
                       " FROM bilancio I " +
                       " LEFT OUTER JOIN " + getExtAccess(destConn, "fin", false) + " FS " +
                       "  ON FS.codefin = I.codicebilancio " +
                       "  AND FS.ayear= I.esercizio " +
                       "  AND ( ((FS.flag & 1)<>0 AND (I.partebilancio='S')) )" +
                       " WHERE " + QHS.AppAnd(QHS.CmpEq("I.esercizio", rEsercizio["esercizio"]),
                       QHS.CmpEq("I.flagvincolato", 'S'));

                DataTable tBilExp = sourceConn.SQLRunner(qBilExp);
                if ((tBilExp != null) && (tBilExp.Rows.Count > 0)) {
                    DataRow rBilExp = tBilExp.Rows[0];
                    rConfig["idfinexpensesurplus"] = rBilExp["idfinexpensesurplus"];
                }

                string qBilInc = "SELECT idfinincomesurplus = FE.idfin " +
                       " FROM bilancio I " +
                       " LEFT OUTER JOIN " + getExtAccess(destConn, "fin", false) + " FE " +
                       "  ON FE.codefin = I.codicebilancio " +
                       "  AND FE.ayear= I.esercizio " +
                       "  AND ( ((FE.flag & 1)=0 AND (I.partebilancio='E')) )" +
                       " WHERE " + QHS.AppAnd(QHS.CmpEq("I.esercizio", rEsercizio["esercizio"]),
                       QHS.CmpEq("I.flagavanzo", 'S'));

                DataTable tBilInc = sourceConn.SQLRunner(qBilInc);
                if ((tBilInc != null) && (tBilInc.Rows.Count > 0)) {
                    DataRow rBilInc = tBilInc.Rows[0];
                    rConfig["idfinincomesurplus"] = rBilInc["idfinincomesurplus"];
                }

                rConfig["flag_autodocnumbering"] = flag_autodocnumbering;
                rConfig["cu"] = "migrazione";
                rConfig["ct"] = DateTime.Now;
                rConfig["lu"] = "migrazione";
                rConfig["lt"] = DateTime.Now;
                tConfig.Rows.Add(rConfig);
            }

            if (tConfig.Rows.Count == 0) return true;
            DataSet ds = new DataSet();
            ds.Tables.Add(tConfig);
            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento di config da tabelle di configurazione separate ");
        }

        public static bool migraEsercizio(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("accountingyear", null, true) > 0) return true;
            QueryHelper QHS = destConn.GetQueryHelper();

            string qEsercizio = "SELECT * FROM esercizio";
            DataTable tEsercizio = sourceConn.SQLRunner(qEsercizio);
            if (tEsercizio == null) {
                string msg = "Errore nell'estrazione degli esercizi esistenti";
                MessageBox.Show(form, msg, "Errore");
                return false;
            }

            DataTable tMainAccountingYear = destConn.CreateTableByName("mainaccountingyear", "*");
            DataTable tAccountingYear = destConn.CreateTableByName("accountingyear", "*");

            foreach (DataRow rEsercizio in tEsercizio.Rows) {
                DataRow rAccountingYear = tAccountingYear.NewRow();

                rAccountingYear["ayear"] = CfgFn.GetNoNullInt32(rEsercizio["esercizio"]);

                string statofinanza = rEsercizio["statofinanza"].ToString().ToUpper();
                string statopatrimonio = rEsercizio["statopatrimonio"].ToString().ToUpper();
                string flagcreazioneesercizio = rEsercizio["flagcreazioneesercizio"].ToString().ToUpper();
                string flagtrasfbilancio = rEsercizio["flagtrasfbilancio"].ToString().ToUpper();
                string flagtrasfconfigbilancio = rEsercizio["flagtrasfconfigbilancio"].ToString().ToUpper();
                string flagtrasfresiduientrata = rEsercizio["flagtrasfresiduientrata"].ToString().ToUpper();
                string flagtrasfresiduispesa = rEsercizio["flagtrasfresiduispesa"].ToString().ToUpper();

                int flag = 0;
                if (flagcreazioneesercizio == "S") flag++;
                if (flagtrasfbilancio == "S") flag++;
                if (flagtrasfconfigbilancio == "S") flag++;
                if (flagtrasfresiduientrata == "S") flag++;
                if (flagtrasfresiduispesa == "S") flag++;
                if (statofinanza == "CHIUSO") flag++;

                if (statopatrimonio == "CHIUSO") flag += 16;
                if (statofinanza == "CHIUSO") flag += 32;

                rAccountingYear["flag"] = flag;

                tAccountingYear.Rows.Add(rAccountingYear);

                DataRow rMainAccountingYear = tMainAccountingYear.NewRow();
                rMainAccountingYear["ayear"] = CfgFn.GetNoNullInt32(rEsercizio["esercizio"]);
                int nextAYear = CfgFn.GetNoNullInt32(rEsercizio["esercizio"]) + 1; 
                int nRow = destConn.RUN_SELECT_COUNT("fin", QHS.CmpEq("ayear", nextAYear), true);

                rMainAccountingYear["completed"] = (nRow > 0) ? "S" : "N";
                rMainAccountingYear["ct"] = DateTime.Now;
                rMainAccountingYear["cu"] = "migrazione";
                rMainAccountingYear["lt"] = DateTime.Now;
                rMainAccountingYear["lu"] = "migrazione";
                tMainAccountingYear.Rows.Add(rMainAccountingYear);
            }

            if ((tAccountingYear.Rows.Count == 0) && (tMainAccountingYear.Rows.Count == 0)) return true;
            DataSet ds = new DataSet();
            ds.Tables.Add(tAccountingYear);
            ds.Tables.Add(tMainAccountingYear);
            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento di mainaccountingyear / accountingyear ");
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
				if(MessageBox.Show(form,"Ci sono movimenti bancari senza numero operazione, che sarà quindi posto a zero. Procedo comunque? ","Avviso",
					MessageBoxButtons.YesNo)==DialogResult.No)
					return false;
			}
			query = "select * from dettmovimentobancario where numoperazione is null";
			int NDettPayNoNumOp=CfgFn.GetNoNullInt32( SourceConn.DO_SYS_CMD(query,true));			
			if (NDettPayNoNumOp>0) {
				if(MessageBox.Show(form,"Ci sono DETTAGLI di movimenti bancari senza numero operazione, che sarà quindi posto a zero. Procedo comunque? ","Avviso",
					MessageBoxButtons.YesNo)==DialogResult.No)
					return false;
			}
			query = "select * from movimentobancario where numdocumento is null or esercdocumento is null";
			int NPayNoDoc=CfgFn.GetNoNullInt32( SourceConn.DO_SYS_CMD(query,true));			
			if (NPayNoDoc>0) {
				if(MessageBox.Show(form,"Ci sono movimenti bancari senza mandato o reversale, che saranno quindi SALTATI. Procedo comunque? ","Avviso",
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
                if (MessageBox.Show(form, "Ci sono movimenti bancari non associati ad alcun movimento di entrata/spesa, che saranno quindi SALTATI. Procedo comunque? ", "Avviso",
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

        public static bool ImpostaExpenseSetup(Form form, DataAccess sourceConn, DataAccess destConn) {
            string sql = "update expensesetup set idregauto=";
            object idreg = sourceConn.DO_READ_VALUE("creditoredebitore", "(tiporesidenza = 'R')", "top 1 codicecreddeb");
            if(CfgFn.GetNoNullInt32(idreg) != 0) {
                sql += QueryCreator.quotedstrvalue(idreg, true) + " where idregauto is null";
                destConn.DO_SYS_CMD(sql, false);
            }
            sql = "update expensesetup set idsortingkind1=";
            if(Iva.idsorkindpiano!=DBNull.Value) {
                sql += QueryCreator.quotedstrvalue(Iva.idsorkindpiano, true) + " where idsortingkind1 is null";
                destConn.DO_SYS_CMD(sql, false);
            }
            return true;
        }


		public static bool migraVarie(Form form, DataAccess sourceConn, DataAccess destConn) {
            //mandatekind (nuova tabella)
            if (!creaMandateKind(form, sourceConn, destConn)) return false;

            //ordinegenerico -> mandate
            if (!Migrazione.migraOrdineGenerico(form, sourceConn, destConn)) return false;


			//dettordinegenerico -> mandatedetail
			if (!Migrazione.migraDettOrdineGenerico(form, sourceConn, destConn))return false;

            //deve precedere quello di generalreportparameter, presente in creaNuoveTabelle
            if (!migraLicenzaUso(form, sourceConn, destConn)) return false;

            if (!migraConfigurazione(form, sourceConn, destConn)) return false;

            if (!migraEsercizio(form, sourceConn, destConn)) return false;

            if (!creaTabBancarie(form, sourceConn, destConn)) return false;

			
			
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
			bool res=Download.RUN_SCRIPT(destConn,SB1,"Disabilitazione e rifinitura(ove sicuro) ordini di anni precedenti");				
			if (!res) return;
			SB1 = Download.LeggiTestoScript("migrazione_fatture.sql");
			res=Download.RUN_SCRIPT(destConn,SB1,"Rifinitura fatture di anni precedenti ove sicuro");				
			if (!res) return;
			SB1 = Download.LeggiTestoScript("disable_oldinvoice.sql");
			res=Download.RUN_SCRIPT(destConn,SB1,"Disabilitazione fatture di anni precedenti");						
		}




		public static bool creaTabBancarie(Form form, DataAccess sourceConn, DataAccess destConn ) {
			impostaHashTablePerNBAN(destConn);

			//movimentobancario, dettmovimentobancario -> proceeds_bank, banktransaction
            Hashtable H = new Hashtable(10000);
			if (!creaMovBancari(form, sourceConn, destConn, "I",H)) return false;
			if (!creaEsiti(form, sourceConn, destConn, "I",H)) return false;

            H = new Hashtable(10000);
			//movimentobancario, dettmovimentobancario -> payment_bank, banktransaction
			if (!creaMovBancari(form, sourceConn, destConn, "E",H)) return false;
			if (!creaEsiti(form, sourceConn, destConn, "E",H)) return false;

			//tipodocumentoiva (duplicati)-> invoicekindyear


            if (!creaGeneralReportParameter(form, sourceConn, destConn)) return false;

            
			return true;
		}
	}
}
