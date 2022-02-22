
/*
Easy
Copyright (C) 2022 UniversitÃ  degli Studi di Catania (www.unict.it)
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
using metadatalibrary;
using System.Web.SessionState;
using System.Data;
using metaeasylibrary;
using System.Security;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace EasyWebReport {

	/* Variabili di sessione:
	 * ModuleReportRow = Riga nella tabella modulereport del report scelto
	 * (DataTable) ParamData = DataTable di reportparameter del report scelto
	 * (DataTable) UserPar = DataTable dei parametri effettivi inseriti dall'utente
	 * 
	 * TipoUtente (fornitore/responsabile)
	 * Fornitore / LoginFornitore /CodiceFornitore=coddicecreddeb del contatto
	 * Responsabile / LoginResponsabile / CodiceResponsabile
	 * 
	 */

	/// <summary>
	/// Summary description for GetDataAccess.
	/// </summary>
    public class GetVars {

        public static DataAccess GetSystemDataAccess(System.Web.UI.Page P) {
            string s;
            return GetSystemDataAccess(P, out s);
        }

	    public static void clearSystemDataAccess(System.Web.UI.Page P) {
	        DataAccess conn = (DataAccess) P.Session["SessionSystemDataAccess"];
            if (conn == null ) return;
	        P.Session["SessionSystemDataAccess"] = null;
            conn.Close();
            conn.Destroy();
        }

	    /// <summary>
        /// Restituisce il DataAcces al db di sistema, prendendolo dal file sul server
        /// </summary>
        /// <param name="P"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public static DataAccess GetSystemDataAccess(System.Web.UI.Page P, out string error) {

            error = null;
            if (P.Session["SessionSystemDataAccess"] != null) {
                return ((DataAccess)P.Session["SessionSystemDataAccess"]);
            }
            DataSet DS = GetConfigDataSet(P);
            if (DS.Tables[0].Rows.Count == 0) {
                error = "Il file di config. Ã¨ errato";
                return null;
            }
            //////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////
            //Da ripristinare al termine dello sviluppo:
            //string _Server = "10.10.1.72";
            //string _Database = "webreport";
            //string _User = "sa";
            //string _Password = "**********";
            //string _Password = GetVars.CryptPassword("afrofite");

            DataAccess Conn = new DataAccess("myDsn",
                GetConfigVar(P, "Server").TrimEnd(), GetConfigVar(P, "Database").TrimEnd(),
                GetConfigVar(P, "User").TrimEnd(), GetConfigVar(P, "Password").TrimEnd(),
                DateTime.Now.Year, DateTime.Now);

            //Max
            //Max2004.DataManagerSql myDManager = new Max2004.DataManagerSql(_Server, _Database, _User, _Password);
            //bool ResultTest = myDManager.VerificaConnessione();

            ////Max
            //DataAccess Conn = new DataAccess("myDsn",_Server, _Database,_User,_Password,
            //    DateTime.Now.Year, DateTime.Now);

            Conn.persisting = false;
            if (!Conn.Open()) {
                error = "Collegamento fallito a #" +
                    GetConfigVar(P, "Server") + "#" + GetConfigVar(P, "Database") + "#" +
                    GetConfigVar(P, "User") + "#" + "Password"/*GetConfigVar(P, "Password")*/ + "#";
                return null;
            };
            P.Session["SessionSystemDataAccess"] = Conn;
            DataTable t = Conn.RUN_SELECT("config", "*", null, null, null, false);
            if (t!=null && t.Rows.Count>0) {
                var r = t.Rows[0];
                foreach (DataColumn c in t.Columns) {
                    P.Session["system_config_" + c.ColumnName] = r[c];
                }
            }
            /*
            QueryHelper QHS = Conn.GetQueryHelper();
            DateTime hh = DateTime.Now.AddHours(-2);
            string filter = QHS.CmpLe("timestamp", hh);
            DataTable DT = Conn.SQLRunner("delete from viewstates where " + filter, true);
            */
            return Conn;
        }

        public static DataSet GetConfigDataSet(System.Web.UI.Page P) {
            FileStream FileS = null;
            try {
                if (P.Session["SessionSystemConfig"] != null) {
                    return (DataSet)P.Session["SessionSystemConfig"];
                }
                DataSet DS = new DataSet();
                string path = P.MapPath("cfg");
                string filename = Path.Combine(path, "config.xml");
                FileS = new FileStream(filename, FileMode.Open);
                 CryptoStream CryptoS = new CryptoStream(FileS,
                    new TripleDESCryptoServiceProvider().CreateDecryptor(
                    new byte[] { 75, 12, 0, 215, 93, 89, 45, 11, 171, 96, 4, 64, 13, 158, 36, 190 },
                    new byte[] { 68, 13, 99, 43, 149, 192, 145, 43, 83, 19, 238, 57, 128, 38, 12, 4 }
                    ), CryptoStreamMode.Read);

                DS.ReadXml(CryptoS);
                
                //DS.ReadXml(FileS);
                CryptoS.Close();
                FileS.Close();

                P.Session["SessionSystemConfig"] = DS;
                return DS;
            }
            catch (Exception Ex) {
                if (FileS != null) {
                    try {
                        FileS.Close();
                        FileS.Dispose();
                    }
                    catch { }
                }
                DataSet DS = new DataSet();
                DataTable T = new DataTable();
                DS.Tables.Add(T);
                return DS;

            }
        }


        public static string DecryptPassword(byte[] pwd) {
            /*
             * char[] a= pwd.ToCharArray();
            byte []A = new byte[a.Length];
            for (int i=0; i<a.Length; i++) A[i]= Convert.ToByte(a[i]);
            */

            MemoryStream MS = new MemoryStream();
            CryptoStream CryptoS = new CryptoStream(MS,
                new TripleDESCryptoServiceProvider().CreateDecryptor(
                new byte[] { 75, 12, 0, 215, 93, 89, 45, 11, 171, 96, 4, 64, 13, 158, 36, 190 },
                new byte[] { 68, 13, 99, 43, 149, 192, 145, 43, 83, 19, 238, 57, 128, 38, 12, 4 }
                ), CryptoStreamMode.Write);
            CryptoS.Write(pwd, 0, pwd.Length);
            CryptoS.Flush();
            return Encoding.Default.GetString(MS.ToArray()).TrimEnd();
        }

        public static byte[] CryptPassword(string pwd) {
            while ((pwd.Length % 8) != 0) pwd += " ";
            char[] a = pwd.ToCharArray();
            byte[] A = new byte[a.Length];
            for (int i = 0; i < a.Length; i++) A[i] = Convert.ToByte(a[i]);

            MemoryStream MS = new MemoryStream(1000);
            CryptoStream CryptoS = new CryptoStream(MS,
                new TripleDESCryptoServiceProvider().CreateEncryptor(
                new byte[] { 75, 12, 0, 215, 93, 89, 45, 11, 171, 96, 4, 64, 13, 158, 36, 190 },
                new byte[] { 68, 13, 99, 43, 149, 192, 145, 43, 83, 19, 238, 57, 128, 38, 12, 4 }
                ), CryptoStreamMode.Write);
            CryptoS.Write(A, 0, A.Length);
            CryptoS.FlushFinalBlock();

            byte[] B = MS.ToArray();
            return B;
            /*
            char []b = new char[B.Length];
            for (int i=0; i<B.Length; i++) b[i]= Convert.ToChar(B[i]);
            return new string(b);
            */
        }


        public static string GetConfigVar(System.Web.UI.Page P, string varname) {
            DataSet DS = GetConfigDataSet(P);
            DataTable T = DS.Tables[0];
            if (T.Rows.Count == 0) return null;
            if (T.Columns[varname] == null) return null;
            DataRow R = T.Rows[0];
            return R[varname].ToString();
        }

        public static object GetUsrVar(System.Web.UI.Page P, string varname) {
            DataAccess Conn = GetSystemDataAccess(P);
            if (Conn == null) return null;
            return Conn.GetUsr(varname);
        }

        public static void SetUsrVar(System.Web.UI.Page P, string varname, object O) {
            DataAccess Conn = GetSystemDataAccess(P);
            if (Conn == null) return;
            Conn.SetUsr(varname,O);
        }
        public static byte decodechar(char A) {
            for (byte a = 0; a <= 255; a++) {
                Byte[] AA = new Byte[1];
                AA[0] = a;
                string S = Encoding.Default.GetString(AA);
                if (Convert.ToChar(S[0]) == A) return a;
            }
            return 0;
        }
        public static byte[] ConvBytes(object OS) {
            if (OS.GetType() == typeof(byte[])) return (byte[])OS;
            string S = OS.ToString();
            return Encoding.Default.GetBytes(S);
            //char[] a = S.ToCharArray();
            //byte[] A = new byte[a.Length];
            //for (int i = 0; i < a.Length; i++) A[i] = decodechar(a[i]);
            //return A;

        }

        public static void ClearUserConn(System.Web.UI.Page P) {
            DataAccess Conn = P.Session["SessionUserDataAccess"] as DataAccess;
            if (Conn != null) {
                Conn.Destroy();
            }
            P.Session["SessionUserDataAccess"] = null;
            SetUsrVar(P, "Dipartimento", null);
            SetUsrVar(P, "CodiceDipartimento", null);
        }
        /// <summary>
        /// Si collega ad un certo dipartimento usando una combinazione user/password. Se user e password
        ///  in ingresso sono nulle, prende quelle della riga RowDipartimento passate come parametro
        /// </summary>
        /// <param name="P"></param>
        /// <param name="RowDipartimento">Riga con dati del dipartimento a cui collegarsi</param>
        /// <param name="user">user login, opzionale</param>
        /// <param name="password">password, opzionale</param>
        /// <param name="DataCont"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public static DataAccess CreateUserConn(System.Web.UI.Page P, DataRow RowDipartimento,
                string user, string password, DateTime DataCont,
            out string err) {
            if (user != null && user != "") RowDipartimento["UserDB"] = CryptPassword(user);
            if (password != null && password != "") RowDipartimento["PassDB"] = CryptPassword(password);

           
            string msg;
            err = "";
            byte[] CodiceDip = CryptPassword(RowDipartimento["CodiceDipartimento"].ToString());
            Easy_DataAccess C = Easy_DataAccess.getEasyDataAccess("usrDSN",
                DecryptPassword(ConvBytes(RowDipartimento["IPserver"])),
                DecryptPassword(ConvBytes(RowDipartimento["NomeDB"])),
                DecryptPassword(ConvBytes(RowDipartimento["UserDB"])),
                DecryptPassword(ConvBytes(RowDipartimento["PassDB"])),
                "", //oldpwd
                RowDipartimento["CodiceDipartimento"].ToString(),
                DataCont.Year,
                DataCont, out err, out msg);

            err = "Tentata Connessione a " +
                DecryptPassword(ConvBytes(RowDipartimento["IPserver"])) +
                "#" +
                DecryptPassword(ConvBytes(RowDipartimento["NomeDB"])) +
                "#" +
                DecryptPassword(ConvBytes(RowDipartimento["UserDB"]));
            if (C == null) return null;
            if (!C.Open()) {
                err = err + C.LastError;
                return null;
            }
            C.persisting = false;
            P.Session["SessionUserDataAccess"] = C;
            SetUsrVar(P, "Dipartimento", RowDipartimento["Dipartimento"]);
            SetUsrVar(P, "CodiceDipartimento", RowDipartimento["CodiceDipartimento"]);
            C.SetUsr("localreportdir", GetConfigVar(P, "Report"));
            //Conn.sys["localreportdir"]= GetConfigVar(P,"Report");
            return C;
        }
        public static Easy_DataAccess GetUserConn(System.Web.UI.Page P) {
            if (P.Session["SessionUserDataAccess"] != null)
                return (Easy_DataAccess)P.Session["SessionUserDataAccess"];
            return null;
        }

        /// <summary>
        /// Restituisce il codice del dipartimento
        /// </summary>
        /// <param name="P"></param>
        /// <returns></returns>
        public static object GetCodDip(System.Web.UI.Page P) {
            return GetUsrVar(P, "CodiceDipartimento");
        }
        public static object GetDip(System.Web.UI.Page P) {
            return GetUsrVar(P, "Dipartimento");
        }

    }

	
	public class WebLog{
		static object NoNull(object O){
			if (O==null) return DBNull.Value;
			return O;
		}
	
		public static void Log(System.Web.UI.Page P,string Azione){
			DataSet DS = new DataSet("log");
			DS.CaseSensitive=false;
			DataAccess Conn= GetVars.GetSystemDataAccess(P);
			if (Conn==null) return;
		    Conn.Open();
            if (Conn.openError) return;
			DataTable T= Conn.CreateTableByName("logweb","*");
			DS.Tables.Add(T);
			DataRow R = T.NewRow();
			R["IDLog"]= Guid.NewGuid().ToString();
			R["IP"]= P.Request.UserHostAddress;
			R["Azione"]=Azione;
			R["Data"]= DateTime.Now;
			R["CodiceDipartimento"]= NoNull(GetVars.GetCodDip(P));
			R["Dipartimento"]= NoNull(GetVars.GetDip(P));
			R["DipServer"]= NoNull(Conn.GetSys("server"));				
			R["DipDatabase"]= NoNull(Conn.GetSys("database"));
			R["NomeReport"]= NoNull(P.Session["ReportName"]);
            T.Rows.Add(R);
			string tipoUtente = NoNull(P.Session["TipoUtente"]).ToString();
			if(tipoUtente.ToLower() == "fornitore") {
				R["Utente"] = NoNull(P.Session["Fornitore"]);
				R["LoginUtente"] = NoNull(P.Session["LoginFornitore"] );
			}
			if(tipoUtente.ToLower() == "responsabile") {
				R["Utente"] = NoNull(P.Session["Responsabile"] );
				R["LoginUtente"]= NoNull(P.Session["LoginResponsabile"] );
			}
            if (tipoUtente.ToLower() == "utente") {
                R["Utente"] = NoNull(P.Session["Utente"]);
                R["LoginUtente"] = NoNull(P.Session["Utente"]);
            }
            if (tipoUtente.ToLower() == "utente ldap") {
                R["Utente"] = NoNull(P.Session["Utente"]);
                R["LoginUtente"] = NoNull(P.Session["Utente"]);

            }


            PostData PD = new PostData();
			PD.initClass(DS,Conn);
            ProcedureMessageCollection MCOLL = PD.DO_POST_SERVICE();
            if (MCOLL.CanIgnore && MCOLL.Count>0) PD.DO_POST_SERVICE();
            Conn.Close();

		}
	}
}