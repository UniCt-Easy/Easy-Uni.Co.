/*
Easy
Copyright (C) 2026 Universit‡ degli Studi di Catania (www.unict.it)
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
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Windows.Forms;
using metadatalibrary;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Collections;
using System.Text;
using System.IO;
using System.Xml;
using System.Security;
using System.Security.Cryptography;
using  System.Net;
using System.Threading;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Linq;


namespace metaeasylibrary {

//	[Serializable]
//	public class ListaConnessioni:MarshalByRefObject {
//		public byte []lista;
//		public ListaConnessioni(byte []L){
//			lista=L;
//		}
//	}

	
    public struct allowdeny {
        public string allow;
        public string deny;
        public bool defaultisdeny;
        public allowdeny(string allow, string deny, bool defaultisdeny) {
            this.allow = allow;
            this.deny = deny;
            this.defaultisdeny = defaultisdeny;
        }
    }

    public interface IEasyDataAccess : IDataAccess {
         bool readOnly { get; set; }

         bool Is_Member(string group);
    }

	[Serializable]
	public class Easy_DataAccess: DataAccess,IEasyDataAccess {
		
        [Obsolete]
	    public bool ReadOnly;

        public void RecalcUserEnvironment(object idflowchart, object ndetail) {
	         easySec.RecalcUserEnvironment(idflowchart, ndetail);
	    }

        public void RecalcUserEnvironment() {
	        easySec.RecalcUserEnvironment();
	    }

	    public void ReadAllGroupOperations() {
	        easySec.ReadAllGroupOperations();
	    }

        public bool readOnly {
#pragma warning disable 612
	        get { return ReadOnly; }
	        set { ReadOnly = value; }
#pragma warning restore 612
	    }

        public static string getOV() {
            string outputview = "";
            foreach (TraceListener tl in Debug.Listeners) {
                //Vede se ha propriet‡ StringBuilder Errors
                Type myType = tl.GetType();
                FieldInfo mprop = myType.GetField("Errors");
                if (mprop != null) {
                    StringBuilder ssb = (StringBuilder)mprop.GetValue(tl);
                    outputview = "Output View:\n\r" + ssb.ToString() + "\n\r";
                    break;
                }
            }
            if (outputview.Length > 4000) {
                outputview = outputview.Substring(outputview.Length - 4000);
            }
            return outputview;
        }


        public override  void LogError(string errmsg, Exception e) {
            errorLogger.logException(errmsg,exception:e,dataAccess:this);
            
        }

        internal void MySetUsr(string key, object O){
			SetUsr(key,O);
		}

		private static byte [] GetArr1(){
			byte []arr=	new byte[]{75,12,0,215+13,   93,89-19,45,11,   171,96+65,4,64,  13+8,158,36,190};
			arr[3]-= 13;
			arr[5]+=19;
			arr[9]-=65;
			arr[12]-=8;
			return arr;
		}

		public static string DecryptPassword(byte []pwd){
			/*
			 * char[] a= pwd.ToCharArray();
			byte []A = new byte[a.Length];
			for (int i=0; i<a.Length; i++) A[i]= Convert.ToByte(a[i]);
			*/

			MemoryStream MS = new MemoryStream();
			CryptoStream CryptoS = new CryptoStream(MS,
				new TripleDESCryptoServiceProvider().CreateDecryptor(
				GetArr1(),
				new byte[]{68,13,99,43, 149,192,145,43, 83,19,238,57, 128,38,12,4}
				), CryptoStreamMode.Write);
			CryptoS.Write(pwd,0,pwd.Length);
			CryptoS.Flush();
			return Encoding.Default.GetString(MS.ToArray()).TrimEnd();
		}

		public static byte [] CryptPassword(string pwd){
			while ((pwd.Length % 8)!=0) pwd+=" ";
			char[] a= pwd.ToCharArray();
			byte []A = new byte[a.Length];
			for (int i=0; i<a.Length; i++) A[i]= Convert.ToByte(a[i]);

			MemoryStream MS = new MemoryStream(1000);
			CryptoStream CryptoS = new CryptoStream(MS,
				new TripleDESCryptoServiceProvider().CreateEncryptor(
				GetArr1(),
				new byte[]{68,13,99,43, 149,192,145,43, 83,19,238,57, 128,38,12,4}
				), CryptoStreamMode.Write);
			CryptoS.Write(A,0,A.Length);
			CryptoS.FlushFinalBlock();

			byte  [] B = MS.ToArray();
			return B;
			/*
			char []b = new char[B.Length];
			for (int i=0; i<B.Length; i++) b[i]= Convert.ToChar(B[i]);
			return new string(b);
			*/
		}
	    /// <summary>
	    /// Descripts a byte array with 3-des
	    /// </summary>
	    /// <param name="B"></param>
	    /// <returns></returns>
	    internal static string DecryptKey(byte[] B) {
	        if (B == null) return null;
	        MemoryStream MS = new MemoryStream();
	        CryptoStream CryptoS = new CryptoStream(MS,
	            new TripleDESCryptoServiceProvider().CreateDecryptor(
	                new byte[] { 75, 12, 0, 215, 93, 89, 45, 11, 171, 96, 4, 64, 13, 158, 36, 190 },
	                new byte[] { 61, 13, 99, 42, 149, 123, 145, 48, 83, 20, 238, 57, 128, 38, 12, 4 }
	            ), CryptoStreamMode.Write);
	        CryptoS.Write(B, 0, B.Length);
	        CryptoS.FlushFinalBlock();
	        string key = Encoding.Default.GetString(MS.ToArray()).TrimEnd();
	        return key;
	    }

        public  byte[] sha256Password() {
			string passwordDB = DecryptKey((byte[]) GetSys("password"));
			SHA256 shaM = new SHA256Managed(); 
			UTF8Encoding encoding = new UTF8Encoding();
			byte[] alfa = shaM.ComputeHash(encoding.GetBytes(passwordDB));
			return alfa;
		}

		internal void MyClose(){
			SureClosing();
		}

        #region Costruttori

	    internal EasySecurity easySec = null;
	    protected override ISecurity createSecurity() {
	        easySec  = new EasySecurity(this);
	        return easySec;
	      
	    }
        


        static string[] tableToPrescan = new string[] {
            "customuser","config","uniconfig","userenvironment","customgroupoperation","generalreportparameter",
                "accountingyear","adminoperation","sortingkind","sortingapplicabilityview",
                "menu","menuvisibility","incomephase","expensephase","report","exportfunction","sptocompile",
                "dbuseralert","alert","flowchartmodulegroup","flowchartexportmodule"
        };

        protected Easy_DataAccess(bool MainConn,string DSN, string Server, 
			string Database, 
			string UserDB,
			string PasswordDB,
			string User, 
			string Password,
			int esercizio_sessione, 
			DateTime DataContabile):
			base(MainConn, DSN,Server,Database,
			UserDB, PasswordDB,
			User,Password,
			esercizio_sessione,DataContabile) {
			if (openError) return;            
            if (DSN == "skipsecurity") return;
            preScanStructures(tableToPrescan);
            easySec?.CalculateGroupList();
            easySec?.RecalcUserEnvironment();
            easySec?.ReadAllGroupOperations();           
		}

	    [Obsolete]
	    public void CalculateGroupList() {
	        easySec?.CalculateGroupList();
        }
        /// <summary>
        /// Constructuctor for SQL Based Security
        /// </summary>
        /// <param name="DSN"></param>
        /// <param name="Server"></param>
        /// <param name="Database"></param>
        /// <param name="User"></param>
        /// <param name="Password"></param>
        /// <param name="esercizio_sessione"></param>
        /// <param name="DataContabile"></param>
        public Easy_DataAccess(string DSN, string Server,
	        string Database,
	        string UserDB,
	        string PasswordDB,
	        string User,
	        string Password,
	        int esercizio_sessione,
	        DateTime DataContabile) :
	        base(DSN, Server, Database,
	            UserDB, PasswordDB,
	            User, Password,
	            esercizio_sessione, DataContabile) {
	        if (openError) return;
	        preScanStructures(tableToPrescan);
	        easySec?.CalculateGroupList();
	        easySec?.RecalcUserEnvironment();
	        easySec?.ReadAllGroupOperations();

	        if (Password == INITIAL_PASSWORD) {
	            SetSys("initial_password_set", "S");
	        }
	        else {
	            SetSys("initial_password_set", "N");
	        }

	    }

	    public static Easy_DataAccess getEasyDataAccess (
			string DSN, 
			string Server, 
			string Database, 
			string User, 
			string Password,
			string idDbDepartment,
			int esercizio_sessione, 
			DateTime DataContabile,
			out string error,
			out string dettaglio) {
			return getEasyDataAccess (
						DSN, Server, Database, User, 
						Password,INITIAL_PASSWORD,idDbDepartment,esercizio_sessione, 
						DataContabile,out error,out dettaglio);
		}

		public static Easy_DataAccess getEasyDataAccess (
			string DSN, 
			string Server, 
			string Database, 
			string User, 
			string Password,
			string OldPassword,
			string idDbDepartment,
			int esercizio_sessione, 
			DateTime DataContabile,
			out string error,
			out string dettaglio) {
			DataAccess dataAccess = new AllLocal_DataAccess(DSN, Server, Database, 
				User, Password, User, Password, 
				esercizio_sessione, DataContabile);

			if (!dataAccess.Open()) {
				error = "Non Ë stato possibile effettuare il collegamento al database.";
				dettaglio = dataAccess.LastError;
				return null;
			}
			if (string.IsNullOrEmpty(OldPassword) || OldPassword.Trim()=="") OldPassword=INITIAL_PASSWORD;
			string passwordDB = getRealDepartmentPassword(dataAccess, User, Password, OldPassword,
				idDbDepartment, out error);
			if (error != null) {
				dettaglio = null;
				return null;
			}

			Easy_DataAccess eda = new Easy_DataAccess(				
				DSN,
				Server,
				Database,
				idDbDepartment,
				passwordDB,
				User,
				Password,
				esercizio_sessione,
				DataContabile);

			error = eda.LastError;
			if (error == "") error = null;
			dettaglio = null;
			return eda;
		}

		public override bool TableIsCentralized(string tablename) {
			return false;
		}
		public override bool ProcedureIsCentralized(string procname) {
			return false;
		}


       


		/// <summary>
		/// Restituisce la password dell'utente criptata con SHA
		/// </summary>
		/// <returns></returns>
		public byte[] sha256UserPassword() {
			byte[] baPassword = (byte[]) GetSys("password");
			string password = DecryptKey(baPassword);
			return getAlfaFromPassword(password);
		}

		public static byte[] getAlfaFromPassword(string userPassword) {
			return SHA256.Create().ComputeHash(Encoding.Default.GetBytes(userPassword));
		}

		
		/// <summary>
		/// Esegue lo XOR tra due array di byte
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		private static byte[] xor(byte[] a, byte[] b) {
			BitArray orEsclusivo = new BitArray(a).Xor(new BitArray(b));
			byte[] result = new byte[32];
			orEsclusivo.CopyTo(result, 0);
			return result;
		}

		/// <summary>
		/// Restituisce la password del dipartimento a partire da alfa (password criptata dell'utente)
		/// e alfa'
		/// </summary>
		/// <param name="alfa"></param>
		/// <param name="alfa1"></param>
		/// <returns></returns>
		private static string getDepPassword(byte[] alfa, byte[] alfa1) {
			if ((alfa == null) || (alfa1 == null) || (alfa.Length != 32) || (alfa1.Length != 32)) {
				return null;
			}
			byte[] inputDiG = xor(alfa, alfa1);
			try {
				string obfuscated = DecryptString(inputDiG).ToUpper();
				return unObfuscatePassword(obfuscated);
			} catch (CryptographicException) {
				return null;
			}
		}

		public const string INITIAL_PASSWORD = "YOUR_PASSWORD";

		/// <summary>
		/// Cambia la password del'utente in automatico 
		/// </summary>
		/// <param name="rAccess">Riga che NON deve appartenere ad un DataSet</param>
		/// <param name="departmentPassword"></param>
		/// <returns></returns>
		private static bool fixDepartmentAccessPassword(string Server,string Database, string password,
				string departmentPassword, string iddbdepartment,  string user) {
			if ((departmentPassword == null) || (departmentPassword.Length > 31)) {
				return false;
			}

			DataAccess conn = new AllLocal_DataAccess("temp", Server, Database, 
							iddbdepartment, departmentPassword, 
							iddbdepartment, departmentPassword, 
							DateTime.Now.Year, DateTime.Now);
			if (conn==null) return false;
			conn.Open();
			if (conn.openError) {
				conn.Destroy();
				return false;
			}

			string filtro = "(login=" + QueryCreator.quotedstrvalue(user, true)
				+ ") and (iddbdepartment=" + QueryCreator.quotedstrvalue(iddbdepartment, true)
				+ ")";

			DataTable tAccess = conn.RUN_SELECT("dbaccess", null, null, filtro, null, null, false);
			//			DataTable tAccess = SQLRunner("select * from dbaccess");
			if (tAccess.Rows.Count == 0) return false;
			DataRow rAccess = tAccess.Rows[0];


			byte[] alfa = getAlfaFromPassword(password);//sha256UserPassword();
			byte[] g1 = DataAccess.CryptString(departmentPassword.PadRight(31));
			byte[] alfa1 = xor(alfa, g1);
			rAccess["alpha1"] = QueryCreator.ByteArrayToString(alfa1);

//			Conn.DO_UPDATE("dbaccess",filtro,new string []{"alpha1"}, 
//							new string []{QueryCreator.ByteArrayToString(alfa1)},1);
			DataSet ds = new DataSet();
			ds.Tables.Add(rAccess.Table);
			PostData epd = new PostData();			
		    epd.initClass(ds, conn);
			bool res = epd.DO_POST();

			conn.Close();
			conn.Destroy();
			return res;
		}


		public static string VALID_PWD_CHARS = "¿»…Ã“ŸABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789;,:.-_'?!";

		/// <summary>
		/// Cambia casualmente il bit 7 di ciascun carattere della password
		/// </summary>
		/// <param name="password"></param>
		/// <returns></returns>
		private string obfuscatePassword(string password) {
			ArrayList list = new ArrayList();
			foreach (char c in VALID_PWD_CHARS) {
				byte b = Convert.ToByte(c);
				if (b>127) {
					list.Add(b);
				}
			}
			Random random = new Random();
			string result = "";
			foreach (char c in password) {
				int bit7 = random.Next(2) << 7;
				char c2 = (char)((int)c | bit7);
				if (list.IndexOf(c2)==-1) {
					result += c2;
				} else {
					result += c;
				}
			}
			return result;
		}


		/// <summary>
		/// A partire dalla password offuscata (con il bit 7 di ciascun carattere variato casualmente)
		/// restituisce la password iniziale
		/// </summary>
		/// <param name="obfuscated"></param>
		/// <returns></returns>
		private static string unObfuscatePassword(string obfuscated) {
			ArrayList list = new ArrayList();
			foreach (char c in VALID_PWD_CHARS) {
				byte b = (byte)c;
				if (b>127) {
					list.Add(b);
				}
			}
			string password = "";
			foreach (char c in obfuscated) {
				if (c > byte.MaxValue) {
					return null;
				}
				byte b = (byte) c;
				if ((b > 127) && (list.IndexOf(b) == -1)) {
					b -= 128;
				}
				char c2 = (char) b;
				if (VALID_PWD_CHARS.IndexOf(c2) == -1) {
					return null;
				}
				password += c2;
			}
			return password;
		}

		
		public static DataAccess GetAllLocalDataAccess(			
			string DSN, 
			string Server, 
			string Database, 
			string User, 
			string Password,
			string idDbDepartment,
			int esercizio_sessione, 
			DateTime DataContabile,
			out string error,
			out string dettaglio){
			return GetAllLocalDataAccess(			
						DSN, Server, Database, User, Password,
						INITIAL_PASSWORD,
						idDbDepartment,esercizio_sessione, DataContabile, out error,out dettaglio);
		}

		public static DataAccess GetAllLocalDataAccess(			
			string DSN, 
			string Server, 
			string Database, 
			string User, 
			string Password,
			string OldPassword,
			string idDbDepartment,
			int esercizio_sessione, 
			DateTime DataContabile,
			out string error,
			out string dettaglio){
			DataAccess dataAccess = new AllLocal_DataAccess(DSN, Server, Database, User, Password, User, Password,
				esercizio_sessione, DataContabile);
			if (!dataAccess.Open()) {
				error = "Non Ë stato possibile effettuare il collegamento al database.";
				dettaglio = dataAccess.LastError;
				return null;
			}
			string passwordDB = getRealDepartmentPassword(dataAccess, User, Password, OldPassword,
				idDbDepartment, out error);
			if (error != null) {
				dettaglio = null;
				return null;
			}
			DataAccess eda = new AllLocal_DataAccess(				
				DSN,
				Server,
				Database,
				idDbDepartment,
				passwordDB,
				User,
				Password,
				esercizio_sessione,
				DataContabile);
			error = eda.LastError;
			if (error=="") error=null;
			dettaglio = null;
			return eda;
		}

		/// <summary>
		/// Restituisce la password del dipartimento
		/// </summary>
		/// <param name="iddbdepartment"></param>
		/// <param name="error"></param>
		/// <returns></returns>
		private static string getRealDepartmentPassword(DataAccess dataAccess, string user, string password, 
			string oldpassword, 
			string iddbdepartment, out string error) {
			error = null;
            if (user == iddbdepartment)
                return password;
            QueryHelper QHS= dataAccess.GetQueryHelper();
            string filtro = QHS.AppAnd(QHS.CmpEq("login", user), QHS.CmpEq("iddbdepartment", iddbdepartment));
			object SAlfa1 = dataAccess.DO_READ_VALUE("dbaccess",filtro,"alpha1");
			if (SAlfa1 == DBNull.Value || SAlfa1==null) {
				error = "L'utente non Ë abilitato a connettersi al dipartimento selezionato";
				return null;
			}
			string sAlfa1 = SAlfa1.ToString();
			if (sAlfa1 == "") {
				error = "Errore interno: E' nulla la password di aggancio tra l'utente "+user+" ed il dipartimento "+iddbdepartment;
				return null;
			}
			byte[] alfa1 = QueryCreator.StringToByteArray((string)sAlfa1);

			byte[] currAlfa = getAlfaFromPassword(password);//sha256UserPassword();
			string passwordDB = getDepPassword(currAlfa, alfa1);
			if (passwordDB == null) {								
				byte[] initAlfa = getAlfaFromPassword(oldpassword);
				passwordDB = getDepPassword(initAlfa, alfa1);
				if (!fixDepartmentAccessPassword(dataAccess.GetSys("server").ToString(),
								dataAccess.GetSys("database").ToString(), 
								password,  passwordDB, iddbdepartment, user)) {
					error = "La password inserita permette all'utente "+user
						+" di accedere al server ma non al dipartimento "+iddbdepartment;
					return null;
				}
			}
			return passwordDB;
		}

		/// <summary>
		/// Cambia la password dell'utente
		/// </summary>
		/// <param name="alfa2"></param>
		/// <returns></returns>
		public bool changeUserPassword(byte[] oldalfa, byte []newalfa) {

            string filtro = QHS.CmpEq("login", GetSys("user"));

			DataTable tAccess = this.RUN_SELECT("dbaccess", null, null, filtro, null, null, true);
			byte[] costante = xor(oldalfa, newalfa);
			foreach (DataRow rAccess in tAccess.Rows) {
				string sAlfa1 = (string) rAccess["alpha1"];
				byte[] alfa1 = QueryCreator.StringToByteArray(sAlfa1);
				byte[] nuovoAlfa1 = xor(costante, alfa1);
				rAccess["alpha1"] = QueryCreator.ByteArrayToString(nuovoAlfa1);
				rAccess["pwdlastmod"] = DateTime.Now.Date;
			}

			DataSet ds = new DataSet();
			ds.Tables.Add(tAccess);
			Easy_PostData epd = new Easy_PostData();
			epd.initClass(ds, this);
			bool res= epd.DO_POST();
			return res;
		}

		public bool changeDepartmentPassword(byte[] oldPwd, byte[] newPwd) {
			string typedPwd = DecryptString(oldPwd);
			string PWDOLD = DecryptKey((byte[])GetSys("passworddb"));
			if (typedPwd != PWDOLD) {
				return false;
			}
			string PWDNEW = DecryptString(newPwd);
			byte[] oldg = CryptString(PWDOLD.PadRight(31));
			byte[] newg = CryptString(PWDNEW.PadRight(31));
			byte[] costante = xor(oldg, newg);

			string iddbdepartment = (string) GetSys("userdb");
            string filtro = QHS.CmpEq("iddbdepartment", iddbdepartment);
			DataTable tAccess = RUN_SELECT("dbaccess", null, null, filtro, null, null, false);
			foreach (DataRow rAccess in tAccess.Rows) {
				string sAlfa1 = (string) rAccess["alpha1"];
				byte[] alfa1 = QueryCreator.StringToByteArray(sAlfa1);
				byte[] nuovoAlfa1 = xor(costante, alfa1);
				rAccess["alpha1"] = QueryCreator.ByteArrayToString(nuovoAlfa1);
			}

			DataSet ds = new DataSet();
			ds.Tables.Add(tAccess);
			Easy_PostData epd = new Easy_PostData();
			epd.initClass(ds, this);
			bool res = epd.DO_POST();
			return res;
		}


		/// <summary>
		/// Abilita un utente ad accedere ad un dipartimento. Restituisce la connessione a tale dipartimento.
		/// DETTAGLI:
		/// Prova a connettersi al dipartimento con user=iddbdepartment e password=depPasswordToTry
		/// Se ci riesce allora aggiorna le tabelle dbdepartment, dbaccess e duser affinchË
		/// da ora in poi l'utente potr‡ accedere a tale dipartimento con la sua user e password.
		/// </summary>
		/// <param name="Conn"></param>
		/// <param name="userPwd"></param>
		/// <param name="idDbDepartment"></param>
		/// <param name="depPasswordToTry"></param>
		/// <param name="readConfiguration">true se deve eseguire 			
		/// CalculateGroupList(), RecalcUserEnvironment() e	ReadAllGroupOperations();</param>
		/// <param name="error"></param>
		/// <returns></returns>
		public static void linkUserToDepartment(DataAccess Conn, string username, string userPwd,
			string idDbDepartment, string depPassword, out string error) {
			byte[] alfa = getAlfaFromPassword(userPwd);
			byte[] g = CryptString(depPassword.PadRight(31));

			error = null;
			byte[] alfa1 = xor(alfa, g);
            QueryHelper QHS= Conn.GetQueryHelper();
			string utente = username;
            string filtroUser = QHS.CmpEq("login", utente);
            string filtroDep = QHS.CmpEq("iddbdepartment", idDbDepartment);
            string filtroAccess = QHS.AppAnd(filtroUser, filtroDep);

			int utenti = Conn.RUN_SELECT_COUNT("dbuser", filtroUser, false);
			int dipartimenti = Conn.RUN_SELECT_COUNT("dbdepartment", filtroDep, false);
			int accessi = Conn.RUN_SELECT_COUNT("dbaccess", filtroAccess, false);

			if (utenti == 0) {
				error = Conn.DO_INSERT("dbuser", 
					new string[] {"login"}, 
					new string[] {QHS.quote(utente)}, 1);
				if (error != null) {
					return;
				}
			}
			if (dipartimenti == 0) {
				error = Conn.DO_INSERT("dbdepartment", 
					new string[] {"iddbdepartment"},
					new string[] {QHS.quote(idDbDepartment)}, 1);
				if (error != null) {
					return;
				}
			}
			if (accessi == 0) {
				string sAlfa1 = QueryCreator.ByteArrayToString(alfa1);
				error = Conn.DO_INSERT("dbaccess", 
					new string[] {"login", "iddbdepartment", "alpha1"},
					new string[] {	 QHS.quote(utente), 
									 QHS.quote(idDbDepartment), 
									 QHS.quote(sAlfa1)
								 }, 3);
				if (error != null) {
					return;
				}
			}
			else {
				string sAlfa2 = QueryCreator.ByteArrayToString(alfa1);
				error = Conn.DO_UPDATE("dbaccess", filtroAccess,
					new string[] {"alpha1"},
					new string[] {QHS.quote(sAlfa2)
								 }, 1);
				if (error != null) {
					return;
				}
			}
			//			return eda;
		}

        /// <summary>
        /// Azzera la password di un utente oppure lo aggiunge al dipartimento corrente
        /// </summary>
        /// <param name="username"></param>
        /// <param name="error"></param>
		public void linkUserToDepartment(string username, out string error) {
			string iddepartment= GetSys("userdb").ToString();
			string deppassword= DecryptKey( (byte[])GetSys( "passworddb"));


			byte[] alfa = getAlfaFromPassword(INITIAL_PASSWORD);
			byte[] g = CryptString(deppassword.PadRight(31));

			error = null;
			byte[] alfa1 = xor(alfa, g);

			string utente = username;
            string filtroUser = QHS.CmpEq("login", username);
            string filtroDep = QHS.CmpEq("iddbdepartment", iddepartment);
            string filtroAccess = QHS.AppAnd(filtroUser, filtroDep);

			int utenti = RUN_SELECT_COUNT("dbuser", filtroUser, false);
			int dipartimenti = RUN_SELECT_COUNT("dbdepartment", filtroDep, false);
			int accessi = RUN_SELECT_COUNT("dbaccess", filtroAccess, false);

			if (utenti == 0) {
				error = DO_INSERT("dbuser", 
					new string[] {"login"}, 
					new string[] {QHS.quote(username)}, 1);
				if (error != null) {
					return;
				}
			}
			if (dipartimenti == 0) {
				error = DO_INSERT("dbdepartment", 
					new string[] {"iddbdepartment"},
					new string[] {QHS.quote(iddepartment)}, 1);
				if (error != null) {
					return;
				}
			}
			if (accessi == 0) {
				string sAlfa1 = QueryCreator.ByteArrayToString(alfa1);
				error = DO_INSERT("dbaccess", 
					new string[] {"login", "iddbdepartment", "alpha1"},
					new string[] {	 QHS.quote(username), 
									 QHS.quote(iddepartment), 
									 QHS.quote(sAlfa1)
								 }, 3);
				if (error != null) {
					return;
				}
			}
			else {
				string sAlfa2 = QueryCreator.ByteArrayToString(alfa1);
				error = DO_UPDATE("dbaccess", filtroAccess,
					new string[] {"alpha1"},
                    new string[] {QHS.quote(sAlfa2)
								 }, 1);
				if (error != null) {
					return;
				}

			}

			//			return eda;
		}





		/// <summary>
		/// Crea un duplicato di un DataAccess, con una nuova connessione allo stesso DB. 
		/// Utile se la connessione deve essere usata in un nuovo thread.
		/// </summary>
		/// <returns></returns>
		override public DataAccess Duplicate(){
			var D= new Easy_DataAccess(
				false,
				"skipsecurity",
				GetSys("server").ToString(),
				GetSys("database").ToString(),
				GetSys("userdb").ToString(),
				DecryptKey((byte[])GetSys("passworddb")),
				    GetSys("user").ToString(),
				DecryptKey((byte[])GetSys("password")),
				Security.GetEsercizio(),
				Security.GetDataContabile());
            D.externalUser = this.externalUser;
            foreach (object tableName in DBstructures.Keys) {
                D.DBstructures[tableName] = DBstructures[tableName];
            }
            D.customName = customName;
            return D;			
		}

		#endregion




		
		#region CALL SP varie redirette tramite customprocedure
        Dictionary<string, string> customName = null;
        string  GetCustomName(string sp_name) {
            if (customName == null) {
                customName = readSimpleDictionary<string, string>("customprocedure", "officialname", "customname", null);                                
            }
            if (customName == null) return sp_name;
            if (customName.ContainsKey(sp_name)) return customName[sp_name];
            return sp_name;
        }

		public override DataSet CallSP(string procname, object[] list, int timeout, out string ErrMess)
		{
			return base.CallSP(GetCustomName(procname), list, timeout, out ErrMess);
		}


		public override bool CallSPParameter(string sp_name, string[] ParamName, SqlDbType[] ParamType, int[] ParamTypeLength, ParameterDirection[] ParamDirection, ref object[] ParamValues, int timeout, out string ErrMsg) {
            //object customname = DO_READ_VALUE("customprocedure",
            //    QHS.CmpEq("officialname", sp_name),
            //    "customname");
            //if ((customname!=null)&&(customname!=DBNull.Value)){
            //    if (customname.ToString().Trim()!="") sp_name= customname.ToString().Trim();
            //}
            return base.CallSPParameter(GetCustomName(sp_name), ParamName, ParamType, ParamTypeLength, ParamDirection, ref ParamValues, timeout, out ErrMsg);
		}


		public override DataSet CallSPParameterDataSet(string sp_name, string[] ParamName, SqlDbType[] ParamType, int[] ParamTypeLength, ParameterDirection[] ParamDirection, ref object[] ParamValues, int timeout, out string ErrMsg) {
            //object customname;
            //if (sp_name.ToLower().StartsWith("check_")){
            //    customname=sp_name;
            //}
            //else {
            //    customname= DO_READ_VALUE("customprocedure",
            //        QHS.CmpEq("officialname",sp_name),
            //          "customname");
            //    if ((customname!=null)&&(customname!=DBNull.Value)){
            //        if (customname.ToString().Trim()!="") sp_name= customname.ToString().Trim();
            //    }
            //}

            return base.CallSPParameterDataSet(GetCustomName(sp_name), ParamName, ParamType, ParamTypeLength, ParamDirection, ref ParamValues, timeout, out ErrMsg);
		}

		#endregion



		#region Gestione Sicurezza


	

	

	
        //static string AppendOrCondition(string s1, string s2){
        //    if (s1=="") return s2;
        //    if (s2=="") return s1;
        //    return s1+"OR"+s2;
        //}




	


		#endregion

		#region Gestione Variabili d'ambiente

		internal string MyDecryptKey(byte []B){
			return DecryptKey(B);
		}

	

       


        Hashtable sys2 = new Hashtable();
        Hashtable usr2 = new Hashtable();
      



		#endregion

		#region Creazione Report

		public static ReportDocument GetReport(Easy_DataAccess Conn,
			DataRow ModuleReport,
			DataRow ParamsRow,
			out string ErrMess  
			){
			ErrMess=null;


			if (Conn.LocalToDB){
				try {
					ReportDocument R = Conn.MyGetReport(
						ModuleReport,
						ParamsRow,out ErrMess);
					return R;
				}
				catch (Exception E){                    
					ErrMess = E.Message;
					QueryCreator.MarkEvent("GetReport() "+E.Message);

                    return null;
				}
			}
			else {
				try {
					//ModuleReport va convertita in DataSet non tipizzato
					DataTable MyTableModuleReport = SingleTableClone(ModuleReport.Table,false);
					MyTableModuleReport.TableName= GetTableForReading(ModuleReport.Table);
					DataSet MyDSModuleReport = new DataSet("dummy");
					MyDSModuleReport.Tables.Add(MyTableModuleReport);
					DataRow MyRowModuleReport = MyTableModuleReport.NewRow();
					MyRowModuleReport.BeginEdit();
					foreach (DataColumn C in MyTableModuleReport.Columns) {
						MyRowModuleReport[C.ColumnName]= ModuleReport[C.ColumnName];
					}
					MyRowModuleReport.EndEdit();
					MyTableModuleReport.Rows.Add(MyRowModuleReport);


					//ParamsRow va convertita in DataSet non tipizzato
					DataTable MyTableParamsRow = SingleTableClone(ParamsRow.Table,true);
					MyTableParamsRow.TableName= GetTableForReading(ParamsRow.Table);
					DataSet MyDSParams = new DataSet("dummy");
					MyDSParams.Tables.Add(MyTableParamsRow);
					DataRow MyRowParamsRow = MyTableParamsRow.NewRow();
					MyRowParamsRow.BeginEdit();
					foreach (DataColumn C in MyTableParamsRow.Columns) {
						MyRowParamsRow[C.ColumnName]= ParamsRow[C.ColumnName];
					}
					MyRowParamsRow.EndEdit();
					MyTableParamsRow.Rows.Add(MyRowParamsRow);

					StringBuilder SBModuleReport = new StringBuilder(1000);
					StringWriter SWModuleReport = new StringWriter(SBModuleReport);
					MyDSModuleReport.WriteXml(SWModuleReport,XmlWriteMode.WriteSchema);

					StringBuilder SBParams = new StringBuilder(1000);
					StringWriter SWParams = new StringWriter(SBParams);
					MyDSParams.WriteXml(SWParams,XmlWriteMode.WriteSchema);

					byte [] A = Conn.byteMyGetReport(
						DataAccess.PackDataSet(Conn,MyDSModuleReport),
						DataAccess.PackDataSet(Conn,MyDSParams),out ErrMess);
					if (A==null) return null;
					string tempdir= System.IO.Path.GetTempPath();
					if (!tempdir.EndsWith("\\")) tempdir+="\\";
					string tempfilename= tempdir+System.Guid.NewGuid().ToString()+".rpt";
					FileStream F = new FileStream(tempfilename,FileMode.Create);
					F.Write(A,0,A.Length);
					F.Close();
					ReportDocument R = new ReportDocument();
					R.Load(tempfilename);
					File.Delete(tempfilename);
					return R;
				}
				catch (Exception E){
					ErrMess = E.Message;
					QueryCreator.MarkEvent(E.Message);
					return null;
				}
			}
		}

		public byte [] byteMyGetReport(byte []ModuleReport,
			byte [] Params,
			out string ErrMess){
			try {
				DataSet  ModuleReportDataSet = DataAccess.UnpackDataSet(this,ModuleReport);
				DataSet ParamsDataSet = DataAccess.UnpackDataSet(this, Params);

				DataRow ModuleReportRow = ModuleReportDataSet.Tables[0].Rows[0];
				DataRow ParamsRow = ParamsDataSet.Tables[0].Rows[0];

				ReportDocument R = MyGetReport(ModuleReportRow, ParamsRow, out ErrMess);
				if (R==null) return null;
				R.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
				R.ExportOptions.ExportFormatType = ExportFormatType.CrystalReport;
				string tempdir= System.IO.Path.GetTempPath();
				if (!tempdir.EndsWith("\\")) tempdir+="\\";
				string tempfilename= tempdir+System.Guid.NewGuid().ToString()+".rpt";

				DiskFileDestinationOptions diskOpts = new DiskFileDestinationOptions();
				diskOpts.DiskFileName = tempfilename;
				R.ExportOptions.DestinationOptions = diskOpts;

				R.Export();
				FileStream F = new FileStream(tempfilename,FileMode.Open);
				byte []A= new byte[F.Length];
				F.Read(A,0,Convert.ToInt32(F.Length));
				F.Close();
				File.Delete(tempfilename);
				return A;
			}
			catch (Exception E){
				ErrMess= "Creazione del report nel 3-tier fallita. Dettaglio: "+E.ToString();
				return null;
			}
		}

        bool responsabile_presente(DataRow Params) {
            if (Params.Table.Columns.Contains("idman")) {
                if ((Params["idman"].ToString() == "") || (Params["idman"].ToString() == "%")) {
                    //MetaFactory.factory.getSingleton<IMessageShower>().Show("E' necessario scegliere un responsabile (regola di sicurezza)");
                    return false;
                }
            }
            else {
                return false;
            }
            return true;
        }

        public ReportDocument MyGetReport(DataRow ModuleReportRow,
   DataRow ParamsRow,
   out string ErrMess
   ) {

            if (!Security.CanPrint(ParamsRow)) {
                ErrMess = "La stampa con questi parametri non Ë consentita dalle regole di sicurezza";
                return null;
            }
            //Controlla la selezione null di bilancio/responsabile/upb
            object all_fin = GetUsr("all_fin");
            if ((all_fin != null) && (all_fin.ToString().ToLower().Equals("'n'"))) {
                if (ParamsRow.Table.Columns.Contains("idfin")) {
                    if ((ParamsRow["idfin"].ToString() == "") || (ParamsRow["idfin"].ToString() == "%")) {
                        if (!responsabile_presente(ParamsRow)) {
                            ErrMess = "E' necessario scegliere una voce di bilancio (regola di sicurezza)";
                            return null;
                        }
                    }
                    else {
                        DataTable TableFin = new DataTable();
                        TableFin.Columns.Add("idfin", typeof(int));
                        DataRow RFin = TableFin.NewRow();
                        RFin["idfin"] = ParamsRow["idfin"];
                        TableFin.Rows.Add(RFin);
                        if (!Security.CanSelect(RFin)) {
                            ErrMess = "La voce di bilancio non poteva essere scelta  (regola di sicurezza)";
                            return null;
                        }
                    }
                }
                if (ParamsRow.Table.Columns.Contains("codefin")) {
                    if ((ParamsRow["codefin"].ToString() == "") || (ParamsRow["codefin"].ToString() == "%")) {
                        if (!responsabile_presente(ParamsRow)) {
                            ErrMess = "E' necessario scegliere una voce di bilancio (regola di sicurezza)";
                            return null;
                        }
                    }
                }
            }
            object all_upb = GetUsr("all_upb");
            if ((all_upb != null) && (all_upb.ToString().ToLower().Equals("'n'"))) {
                if (ParamsRow.Table.Columns.Contains("idupb")) {
                    if ((ParamsRow["idupb"].ToString() == "") || (ParamsRow["idupb"].ToString() == "%")) {
                        if (!responsabile_presente(ParamsRow)) {
                            ErrMess = "E' necessario scegliere un UPB (regola di sicurezza)";
                            return null;
                        }
                    }
                    else {
                        DataTable TableUpb = new DataTable();
                        TableUpb.Columns.Add("idupb", typeof(string));
                        DataRow RUpb = TableUpb.NewRow();
                        RUpb["idupb"] = ParamsRow["idupb"];
                        TableUpb.Rows.Add(RUpb);
                        if (!Security.CanSelect(RUpb)) {
                            ErrMess = "L'upb non poteva essere scelto (regola di sicurezza)";
                            return null;
                        }
                    }
                }
                if (ParamsRow.Table.Columns.Contains("codeupb")) {
                    if ((ParamsRow["codeupb"].ToString() == "") || (ParamsRow["codeupb"].ToString() == "%")) {
                        if (!responsabile_presente(ParamsRow)) {
                            ErrMess = "E' necessario scegliere un UPB (regola di sicurezza)";
                            return null;
                        }
                    }
                }
            }

            object allMan = GetUsr("all_man");
            if ((allMan != null) && (allMan.ToString().ToLower() == "'n'")) {
                if (ParamsRow.Table.Columns.Contains("idman")) {
                    if ((ParamsRow["idman"].ToString() == "") || (ParamsRow["idman"].ToString() == "%")) {
                        ErrMess = "E' necessario scegliere un responsabile (regola di sicurezza)";
                        return null;
                    }
                }
            }

            object allEstimatekind = GetUsr("all_estimatekind");
            if ((allEstimatekind != null) && (allEstimatekind.ToString().ToLower() == "'n'")) {
                if (ParamsRow.Table.Columns.Contains("idestimkind")) {
                    if ((ParamsRow["idestimkind"].ToString() == "") || (ParamsRow["idestimkind"].ToString() == "%")) {
                        ErrMess = "E' necessario scegliere un tipo contratto attivo (regola di sicurezza)";
                        return null;
                    }
                }
            }

            object all_mandatekind = GetUsr("all_mandatekind");
            if ((all_mandatekind != null) && (all_mandatekind.ToString().ToLower() == "'n'")) {
                if (ParamsRow.Table.Columns.Contains("idmankind")) {
                    if ((ParamsRow["idmankind"].ToString() == "") || (ParamsRow["idmankind"].ToString() == "%")) {
                        ErrMess = "E' necessario scegliere un tipo contratto passivo (regola di sicurezza)";
                        return null;
                    }
                }
            }

            object all_pettycash = GetUsr("all_pettycash");
            if ((all_pettycash != null) && (all_pettycash.ToString().ToLower() == "'n'")) {
                if (ParamsRow.Table.Columns.Contains("idpettycash")) {
                    if ((ParamsRow["idpettycash"].ToString() == "") || (ParamsRow["idpettycash"].ToString() == "%")) {
                        ErrMess = "E' necessario scegliere un tipo fondo economale (regola di sicurezza)";
                        return null;
                    }
                }
            }

            object all_invoicekind = GetUsr("all_invoicekind");
            if ((all_invoicekind != null) && (all_invoicekind.ToString().ToLower() == "'n'")) {
                if (ParamsRow.Table.Columns.Contains("idinvkind")) {
                    if ((ParamsRow["idinvkind"].ToString() == "") || (ParamsRow["idinvkind"].ToString() == "%")) {
                        ErrMess = "E' necessario scegliere un tipo documento IVA (regola di sicurezza)";
                        return null;
                    }
                }
            }


            Hashtable ReportParams = new Hashtable();
            foreach (DataColumn C in ParamsRow.Table.Columns) {
                if (QueryCreator.IsPrimaryKey(ParamsRow.Table, C.ColumnName)) continue;
                ReportParams[C.ColumnName] = ParamsRow[C];
            }
            return ReportDispatcherClass.GetReport(this, ModuleReportRow, ReportParams, out ErrMess);
        }


		#endregion

        public bool ChangeFlowChart(){
            if (this.ConnectionHasBeenClosedBySystem) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Si Ë verificato un errore irrecuperabile con il database, Ë necessario scollegarsi e ricollegarsi.", "Errore");
                return false;
            }

            if (this.openError) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("La connessione con il db Ë andata persa, Ë necessario ricollegarsi.", "Errore");
                return false;
            }
            frmCambioFlowChart F = new frmCambioFlowChart(this);
			MetaFactory.factory.getSingleton<IFormCreationListener>().create(F, null);
			if (F.ShowDialog() != DialogResult.OK) return false;
            if (F.cmbFlowChart.SelectedIndex < 0) return false;
            if (F.cmbFlowChart.SelectedValue == null) return false;
            string idflowchart = F.cmbFlowChart.SelectedValue.ToString();
            return ChangeFlowChart(F.idflowchart,F.ndetail);
        }
        
        public bool ChangeFlowChart(object idflowchart,object ndetail) {
            string idcustomuser = GetSys("idcustomuser") as string;

            if (idflowchart != null && idflowchart != DBNull.Value) {
                object currdate = GetSys("datacontabile");
                string f1 = QHS.AppAnd(QHS.CmpEq("FU.idcustomuser", idcustomuser),
                    QHS.NullOrLe("FU.start", currdate), QHS.NullOrGe("FU.stop", currdate));
                f1 = QHS.AppAnd(f1, QHS.CmpEq("F.ayear", GetSys("esercizio")));
                f1 = QHS.AppAnd(f1, QHS.CmpEq("F.idflowchart", idflowchart));


                DataTable TT = SQLRunner(
                    "SELECT F.idflowchart  from " +
                    "flowchart F join flowchartuser FU ON F.idflowchart=FU.idflowchart " +
                    "WHERE " + f1 ); //+ " ORDER BY FU.flagdefault DESC"
                if (TT==null) return false;
                if (TT.Rows.Count == 0) return false;
            }
                      
            easySec.RecalcUserEnvironment(idflowchart,ndetail);
            if (openError) return false;
            easySec.ReadAllGroupOperations();
            return true;
        }

		public bool Is_Member(string group) {
			if (group==null)return false;
			try {
                string cmd = "IS_ROLEMEMBER"; 
                group = group.ToLower();
                //if (group == "sysadmin" || group == "dbcreator" || group == "diskadmin" || group == "processadmin" ||
                //            group == "serveradmin" || group == "setupadmin" ||
                //            group == "securityadmin"){
                //                cmd = "SELECT count(*) as q FROM sys.server_role_members m  " +
                //                        " inner join sys.server_principals r on m.role_principal_id = r.principal_id  " +
                //                        "	inner join sys.server_principals l on m.member_principal_id = l.principal_id  " +
                //                        " where r.name = " + QHS.quote(group) + " AND l.name= " + QHS.quote(sys["user"]);
                //}
                //else {
                //    cmd = "SELECT count(*) as q  FROM sys.database_role_members m  " +
                //            " inner join sys.database_principals r on m.role_principal_id = r.principal_id  "+
                //            "	inner join sys.database_principals l on m.member_principal_id = l.principal_id  "+
                //            " where r.name = "+QHS.quote(group)+" AND l.name= "+ QHS.quote(sys["user"]);
                //}

                //object O = DO_SYS_CMD(cmd);

                if (group == "sysadmin" || group == "dbcreator" || group == "diskadmin" || group == "processadmin" ||
                            group == "serveradmin" || group == "setupadmin" ||
                            group == "securityadmin")
                    cmd = "IS_SRVROLEMEMBER";
                
                object O = DO_SYS_CMD("select " + cmd + " (" +QHS.quote(group) + ","+QHS.quote(GetSys("user"))+") AS Q");                

                if ((O != null) && (O.ToString() == "1")) {
                    return true;
                }
                else {
                    return false;
                }

             
			}
			catch (Exception E){
				MarkException("IS_Member",E);
				return false;
			}
		}
        public override QueryHelper GetQueryHelper() {
            return new SqlServerQueryHelper();
        }

	}



	public class Meta_EasyDispatcher: EntityDispatcher {
        [Obsolete]
		public Meta_EasyDispatcher(DataAccess Conn):base(Conn){}

	    public Meta_EasyDispatcher(IDataAccess Conn) : base(Conn) { }

        [Obsolete]
		override public MetaData DefaultMetaData(DataAccess Conn, string table){
			return new Meta_easydata(Conn, this, table);
		}

	    public override MetaData defaultMetaData(string table) {
	        return new Meta_easydata(dbConn, this, security, table);
	    }
	}

    /// <summary>
    /// Base class for all easy MetaData http://your-server/LiveLog/DoLog.aspx  
    /// </summary>
    public class Meta_easydata: MetaData {
	    
	     initIndexes iii = new initIndexes();

        [Obsolete]
		public Meta_easydata(DataAccess Conn, MetaDataDispatcher Dispatcher, string table):
			base(Conn,Dispatcher,table) {
			ManagedByDB=false;
			ErrorLogUrl= "https://your-server/LiveLog/DoEasy.aspx";
			MetaData.errorLogUrl = ErrorLogUrl;
			NotesFieldName="txt";
			OleNotesFieldName="rtf";
            helpdeskEnabled = true;
            var oo = iii;
		}
        public Meta_easydata(IDataAccess conn, IMetaDataDispatcher dispatcher, ISecurity security, string table) :
            base(conn, dispatcher, security,table) {
            ManagedByDB = false;
            ErrorLogUrl = "https://your-server/LiveLog/DoEasy.aspx";
            MetaData.errorLogUrl = ErrorLogUrl;
            NotesFieldName = "txt";
            OleNotesFieldName = "rtf";
            helpdeskEnabled = true;
        }
        public override void doHelpDesk() {
            frmCreaTicket f = new frmCreaTicket(this,dbConn);
			MetaFactory.factory.getSingleton<IFormCreationListener>().create(f, linkedForm);
			f.Show(linkedForm);
            linkedForm.AddOwnedForm(f);
            var oo = iii;
        }

        


		override public void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T,ListingType);
			foreach(DataColumn C in T.Columns){
				if (C.Caption.Equals("lu")) C.Caption="";
				if (C.Caption.Equals("lt")) C.Caption="";
				if (C.Caption.Equals("cu")) C.Caption="";
				if (C.Caption.Equals("ct")) C.Caption="";
				if (C.Caption.Equals("rtf"))C.Caption="";
				if (C.Caption.Equals("txt"))C.Caption="";
//				if (C.Caption.Equals("denyu"))C.Caption="";
//				if (C.Caption.Equals("denyd"))C.Caption="";
			}
		}

		override public void SetDefaults(DataTable T){
			base.SetDefaults(T);
			SetDefault(T,"lu","-");
			SetDefault(T,"cu","-");
			SetDefault(T,"lt", DateTime.Now);
			SetDefault(T,"ct", DateTime.Now);
            foreach (string ss in new string[] { "idsor01", "idsor02", "idsor03", "idsor04", "idsor05" }) {
                object O = dbConn.Security.GetSys(ss);
                if (O==null )  continue;
                if (O == DBNull.Value) continue;
                if (Convert.ToInt32(O) == 0) continue;
                if (!T.Columns.Contains(ss))continue;
                SetDefault(T, ss, O);
            }
            
//			try {
//				if (!T.Columns["denyu"].AllowDBNull) SetDefault(T,"denyu","0");
//				if (!T.Columns["denyd"].AllowDBNull) SetDefault(T,"denyd","0");
//			}
//			catch {
//			}
		}

		public override string GetFilterForInsert(DataTable T) {
			if (T==null) return base.GetFilterForInsert (T);
			if (T.Columns["active"]!=null){
				return "((active is null)or(active='')or(active='S'))";
			}
			return null;
		}
        public override string GetFilterForSearch(DataTable T) {
            if (T == null) return base.GetFilterForSearch(T);
            if (T.Columns["active"] != null) {
                return "((active is null)or(active='')or(active='S'))";
            }
            return null;
        }

    
        protected override void InsertCopyColumn(DataColumn C, DataRow Source, DataRow Dest) {
			if (C.ColumnName=="adate")return;
			base.InsertCopyColumn (C, Source, Dest);
		}

		override public PostData Get_PostData(){
            return MetaFactory.create<Easy_PostData>();			
		}

		public override bool CanSelect(DataRow R) {
			if (R.Table.Columns.Contains("ayear")){
                if (R["ayear"] != DBNull.Value) {
                    if (Convert.ToInt32(R["ayear"]) != Convert.ToInt32(dbConn.Security.GetEsercizio())) {
                        ShowClientMsg("La riga scelta non appartiene all'esercizio corrente e non puÚ essere selezionata.",
                                            "Errore", MessageBoxButtons.OK);                        
                        return false;
                    }
                }
			}
			return base.CanSelect (R);
		}

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            foreach (DataColumn C in R.Table.Columns) {
                if (R[C.ColumnName] == DBNull.Value) continue;
                if (C.ColumnName == "xml" || C.ColumnName == "signedxml") continue;

                if (C.DataType == typeof(DateTime)) {
                    bool tocheck = C.ColumnName.IndexOf("start", StringComparison.Ordinal) >= 0;
                    tocheck = tocheck | C.ColumnName.IndexOf("stop", StringComparison.Ordinal) >= 0;
                    tocheck = tocheck | C.ColumnName=="adate";
                    if (!tocheck) continue;
                    if (R[C.ColumnName] == DBNull.Value) continue;
                    if (R[C].ToString() == QueryCreator.EmptyDate().ToString()) continue;
                    DateTime T = (DateTime) R[C.ColumnName];
                    if (T.Year < 1900 || T.Year > 2078) {
                        errmess = $"Data {T.ToShortDateString()} non valida";
                        errfield = C.ColumnName;
                        // string message =   "Si sta inserendo una data che precede il 1900 o segue il 2050. Si Ë certi dell'operazione ?";
                        //if (!this.ShowClientMsg(message, "Attenzione!", MessageBoxButtons.OKCancel)) {
                        //    errfield = C.ColumnName;
                        //    errmess = null; // "Data non valida.";
                        //    return false;
                        //}
                        return false;
                    }
                }
                if (C.DataType == typeof(string) && !C.ExtendedProperties.Contains("skipSizeCheck")) {
                    string s = (string)R[C];
                    if (s.Length > 1024 * 1024) {
                        errfield = C.ColumnName;
                        errmess = "Un campo testo non puÚ superare la dimensione di 1M";
                        return false;
                    }
                }

                if (C.DataType.IsArray && C.DataType.GetElementType() == typeof(Byte) && !C.ExtendedProperties.Contains("skipSizeCheck")) {
                    Byte[] a = (Byte[]) R[C];
					int attMaxSizeMB = Convert.ToInt32(dbConn.Security.GetSys("attachment_max_size_mb"));
					attMaxSizeMB = attMaxSizeMB < 1 ? 1 : attMaxSizeMB;
					if (a.Length > attMaxSizeMB * 1024 * 1024) {
                        errfield = C.ColumnName;
						errmess = $"Un campo note o un allegato non possono superare la dimensione di {attMaxSizeMB} MB";
                        return false;
                    }
                }

            }
            return base.IsValid(R, out errmess, out errfield);
		}
	}


	public class easy_node_dispatcher : node_dispatcher{
		string level_table;
		string level_field;
		string descr_level_field;
		string selectable_level_field;
		string descr_field;
		string code_string;

		/// <summary>
		/// Node builder
		/// </summary>
		/// <param name="level_table">Table with tree-level description</param>
		/// <param name="level_field">level field of tree_table rows</param>
		/// <param name="descr_level_field">level description, field of level_table </param>
		/// <param name="selectable_level_field">field that contains "flagoperativo" in level table</param>
		/// <param name="descr_field">field to put in tooltip</param>
		/// <param name="code_string">field to display in tree view near level description</param>
		public easy_node_dispatcher(
			string level_table, 
			string level_field,
			string descr_level_field,
			string selectable_level_field,
			string descr_field,
			string code_string
			) {
			this.level_table= level_table;
			this.level_field= level_field;
			this.descr_field= descr_field;
			this.selectable_level_field=selectable_level_field;
			this.descr_level_field= descr_level_field;
			this.code_string=code_string;
		}
		override public tree_node GetNode(DataRow Parent, DataRow Child){
			return new easy_tree_node(level_table, level_field, descr_level_field, selectable_level_field,
				descr_field, code_string, Child);
		}
	}

	public class easy_tree_node: tree_node {
		string level_field;
		string descr_level_field;
		string selectable_level_field;
		string descr_field;
		string level_table;
		string code_string;
        

		public easy_tree_node(string level_table, 
			string level_field,
			string descr_level_field,
			string selectable_level_field,
			string descr_field,
			string code_string,
			DataRow R):base(R){
			this.level_table = level_table;
			this.level_field= level_field;
			this.descr_level_field=descr_level_field;
			this.selectable_level_field= selectable_level_field;
			this.descr_field= descr_field;
			this.code_string=code_string;
		}

		public int level(){
			return Convert.ToInt32(Row[level_field].ToString());
		}

		/// <summary>
		/// Label that appears in treeview for each node
		/// </summary>
		/// <returns></returns>
		override public string Text(){
            string S = DescrLevel();
            if (!row_exists()) return S;
            if (descr_field!= null && Row.Table.Columns.Contains(descr_field)) {
                S = "";
                if (code_string != null) {
                    if (S != "") S = S + " ";
                    S = S + Row[code_string];
                }
                if (Row[descr_field].ToString() != "") {
                    if (S != "") S = S + " ";
                    S = S + Row[descr_field];
                }
            }
            else {
                if (code_string != null) {
                    if (S != "") S = S + " ";
                    S = S + Row[code_string];
                }

            }
			return S;
		}
                
		bool row_exists(){
			if (Row==null) return false;
			if (Row.RowState== DataRowState.Deleted) return false;
			if (Row.RowState== DataRowState.Detached) return false;
			return true;
		}
		/// <summary>
		/// String that should appear in tooltip
		/// </summary>
		/// <returns></returns>
		override public string ToolTip(){
			if (!row_exists()) return "";
			if (descr_field!=null) return Row[descr_field].ToString();
			if (code_string!=null) return Row[code_string].ToString();
			return "";
		}

		/// <summary>
		/// True if "selectable" and with "no chidren"
		/// </summary>
		/// <returns></returns>
		override public bool CanSelect(){
			if (!row_exists()) return false;
			if (selectable_level_field==null) return true;
			DataRow Lev = LevelRow();
			if (Lev[selectable_level_field].ToString().ToLower()=="n") return false;
			if (HasAutoChildren()) return false;
			return true;           
		}
        
		public DataRow LevelRow(){
			if (!row_exists()) return null;
			foreach (DataRelation R in Row.Table.ParentRelations){
				if (R.ParentTable.TableName==level_table){
					return Row.GetParentRow(R);
				}
			}
			return null;
		}
		public bool HasAutoChildren(){
			DataRelation Rfound=null;
			foreach (DataRelation R in Row.Table.ParentRelations){
				if (R.ParentTable.TableName== Row.Table.TableName){
					Rfound = R;
				}
			}
			if (Rfound==null) return false;
			return (Row.GetChildRows(Rfound).Length>0);
		}

		public string DescrLevel(){
			if (!row_exists()) return "";
			DataRow Lev = LevelRow();
			if (Lev==null)return "";
			return Lev[descr_level_field].ToString();
		}

	}

    public class SendMessage {
        public byte[]Result;
        public string message;
        public string type;
        public SendMessage(string message, string type) {
            this.message = message;
            this.type = type;
        }
        public void Send() {
            try {
                WebClient W = new WebClient();
                W.BaseAddress = "http://your-server/LiveLog/";
                Result = W.DownloadData("http://your-server/LiveLog/DoEasy.aspx?" + type + "=" + message);

                if (Result == null || Result.Length == 0) {
                    QueryCreator.MarkEvent("No response");
                }
                else {
                    QueryCreator.MarkEvent(Encoding.ASCII.GetString(Result));
                }
            }
            catch (Exception e) {
                QueryCreator.MarkEvent(QueryCreator.GetErrorString(e));
            }

        }
    }




}



