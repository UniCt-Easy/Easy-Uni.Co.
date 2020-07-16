/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
using metaeasylibrary;
using System.Security;
using System.Security.Cryptography;
using System.Net;

namespace checkflags//checkflags//
{
	/// <summary>
	/// Summary description for CheckFlags.
	/// </summary>
	public class CheckFlags
	{
		public CheckFlags()
		{

		}

		public static string GetCheck(string S){
			const int mylen=20;
			while ((S.Length % 8)!=0) S+=" ";

			byte []B = DataAccess.CryptString(S);
			byte []Res= new Byte[mylen];
			for (int i=0;i<mylen;i++){
				Res[i]=0;
			}
			for (int j=0;j<B.Length;j++){
				int k= j % mylen;
				Res[k]=(byte)( Res[k] ^ B[j]);
			}
			return QueryCreator.ByteArrayToString(Res);
		}

		static string XPGetGetName(DataAccess Conn){
			object S= Conn.DO_SYS_CMD("master.dbo.xp_getnetname",true) as string;
			if (S==null) return null;
			if (S.ToString()=="") return null;
			return S.ToString().ToUpper();
		}
		public static string ServerName(DataAccess Conn){
			DataTable T= Conn.SQLRunner("sp_helpserver",true);
			if (T==null) return XPGetGetName(Conn);
			if (T.Rows.Count==1){
				object S= T.Compute("MAX(name)",null);
				if (S==null) return null;
				return S.ToString().Trim().ToUpper();
			}
			if (T.Rows.Count!=1) {
				string x= T.Compute("MIN(ID)",null).ToString();
				DataRow []RR=T.Select("(ID='"+x+"')");
				if (RR.Length==0)return XPGetGetName(Conn);
				return RR[0]["name"].ToString().ToUpper();
			}
			if (T.Select("network_name is not null").Length!=1) return XPGetGetName(Conn);
			object SS= T.Compute("MAX(name)","network_name is not null");
			if (SS==null) return null;
			return SS.ToString().Trim().ToUpper();
		}

		public static string DBName(DataAccess Conn){
			return Conn.GetSys("database").ToString().Trim().ToUpper();
		}

		public static bool GetFromInternet(DataRow R, DataAccess Conn){
			try {
				string XX = "iddbcliente="+QueryCreator.quotedstrvalue(R["iddb"],true);
				while ((XX.Length % 8)!=0) XX+=" ";
				byte [] B2 = DataAccess.CryptString(XX);
				string SS2 = QueryCreator.ByteArrayToString(B2);
				WebClient W = new WebClient();
                W.BaseAddress = "http://ticket.temposrl.it/LiveLog/";
                W.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
                W.Headers.Add("Accept-Language", "it-IT,it;q=0.8,en-US;q=0.6,en;q=0.4,bg;q=0.2,es;q=0.2,vi;q=0.2");
                byte[] B = W.DownloadData("http://ticket.temposrl.it/LiveLog/DoEasy.aspx?c=" + SS2);
				string resp="";
				for (int i=0; i<B.Length;i++) resp=resp+ (char)B[i];
				resp= resp.Trim();
				byte []BB= QueryCreator.StringToByteArray(resp);
				if (BB==null) return false;
				if (BB.Length==0) return false;
				DataSet D=null;
				try {
					D= DataAccess.UnpackDataSet(Conn, BB,true);
					if (D==null) return false;
					if (D.Tables.Count==0) return false;
					if (D.Tables[0].Rows.Count==0) return false;
				}
				catch {
					return false;
				}
				DataRow RR= D.Tables[0].Rows[0];
				foreach(string field in new string[]{	"servername","dbname",
														"licstatus","lickind","expiringlic",
														"manstatus","mankind","expiringman",
														"swmoreflag","swmorecode",
														"serverbackup1","checkbackup1","serverbackup2","checkbackup2","annotations"
													}){
					R[field]=RR[translateToOld(field)];
				}
				R["checklic"]=CalcolaCheckLic(R);
				R["checkflag"]=CalcolaCheckFlag(R);
				R["checkman"]=CalcolaCheckMan(R);
				return true;
			}
			catch {
				return false;
			}
		}

		static string translateToOld(string news){
			if (news=="address1") return "indirizzo_1";
			if (news=="address2") return "indirizzo_2";
			if (news=="agency") return "universita";
			if (news=="agencycode") return "codiceente";
			if (news=="annotations") return "note";
			if (news=="cf") return "codicefiscale";
			if (news=="country") return "provincia";
			if (news=="department") return "dipartimento";
			if (news=="departmentcode") return "codicedipartimento";
			if (news=="departmentname") return "nomeente";
			if (news=="expiringlic") return "scadenzalic";
			if (news=="expiringman") return "scadenzaman";
			if (news=="iddb") return "iddbcliente";
			if (news=="idreg") return "codicecreddeb";
			if (news=="lickind") return "tipolic";
			if (news=="licstatus") return "statolic";
			if (news=="mankind") return "tipoman";
			if (news=="manstatus") return "statoman";
			if (news=="location") return "localita";
			if (news=="lt") return "lastmodtimestamp";
			if (news=="lu") return "lastmoduser";
			if (news=="ct") return "createtimestamp";
			if (news=="cu") return "createuser";
			if (news=="swmorecode") return "codiceswmore";
			if (news=="swmoreflag") return "flagswmore";
			if (news=="p_iva") return "partitaiva";
			if (news=="phonenumber") return "telefono";
			if (news=="referent") return "rifcont";
			if (news=="sent") return "inviato";
			return news;
		}


		public static string CalcolaCheckLic(DataRow R){
			//Deve controllare:
			// iddbcliente,servername,dbname,flagswmore,codiceswmore
			string S= "L"+QueryCreator.quotedstrvalue(R["iddb"],true)+
				QueryCreator.quotedstrvalue(R["lickind"],true)+
				QueryCreator.quotedstrvalue(R["expiringlic"],true)+
				QueryCreator.quotedstrvalue(R["licstatus"],true);
			string Check = CheckFlags.GetCheck(S);
			return Check;
		}

		public static string CalcolaCheckMan(DataRow R){
			//Deve controllare:
			// iddbcliente,servername,dbname,flagswmore,codiceswmore
			string S= "M"+QueryCreator.quotedstrvalue(R["iddb"],true)+
				QueryCreator.quotedstrvalue(R["mankind"],true)+
				QueryCreator.quotedstrvalue(R["expiringman"],true)+
				QueryCreator.quotedstrvalue(R["manstatus"],true);
			string Check = CheckFlags.GetCheck(S);
			return Check;
		}

		public static string CalcolaCheckFlag(DataRow R){
			//Deve controllare:
			// iddbcliente,servername,dbname,flagswmore,codiceswmore
			string S= "F"+QueryCreator.quotedstrvalue(R["iddb"],true)+
				QueryCreator.quotedstrvalue(R["servername"],true)+
				QueryCreator.quotedstrvalue(R["dbname"],true)+
				QueryCreator.quotedstrvalue(R["swmoreflag"],true)+
				QueryCreator.quotedstrvalue(R["swmorecode"],true);
			string Check = CheckFlags.GetCheck(S);
			return Check;
		}

		public static void SendToInternet(DataAccess Conn, DataSet DS){
			try {
				byte []BB=DataAccess.PackDataSet(Conn,DS,true);
				string SS= QueryCreator.ByteArrayToString(BB);

				WebClient W = new WebClient();
                W.BaseAddress = "http://ticket.temposrl.it/LiveLog/";
                W.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
                byte[] B = W.DownloadData("http://ticket.temposrl.it/LiveLog/DoEasy.aspx?d=" + SS);
				string resp="";
				for (int i=0; i<B.Length;i++) resp=resp+ (char)B[i];
				resp= resp.Trim();
			}
			catch {
			}
		}
/*
		/// <summary>
		/// Controlla coerenza del flag con il db, ed il checkflag.
		/// </summary>
		/// <param name="Conn"></param>
		/// <param name="R"></param>
		/// <returns></returns>
		public static bool ControllaCheckFlag(DataAccess Conn, DataRow R){
			try {
				string myservername=ServerName(Conn);
				if (myservername!= R["servername"].ToString()) return false;
				string mydb= DBName(Conn);
				if (mydb!= R["dbname"].ToString()) return false; 
				string RealCheck = CalcolaCheckFlag(R);
				if (R["checkflag"].ToString()!=RealCheck) return false;
				return true;
			}
			catch {
				return false;
			}
		}
		*/
		public static bool ControllaAllChecks(DataAccess Conn, DataRow R){
			try {
				string mydb= DBName(Conn);
				if (mydb!= R["dbname"].ToString()) return false; 
				string RealCheck = CalcolaCheckFlag(R);
				if (R["checkflag"].ToString()!=RealCheck) return false;
				RealCheck = CalcolaCheckLic(R);
				if (R["checklic"].ToString()!=RealCheck) return false;
				RealCheck = CalcolaCheckMan(R);
				if (R["checkman"].ToString()!=RealCheck) return false;

				//rimane solo da testare il servername
				string myservername=ServerName(Conn);
				if (myservername== R["servername"].ToString()) return true;

				if (R.Table.Columns["serverbackup1"]==null) return false;

				if (myservername.ToUpper()==R["serverbackup1"].ToString().ToUpper()){
					if (CalcolaCheckBackup1(R).ToUpper()==R["checkbackup1"].ToString().ToUpper()) return true;
				}
				if (myservername.ToUpper()==R["serverbackup2"].ToString().ToUpper()){
					if (CalcolaCheckBackup2(R).ToUpper()==R["checkbackup2"].ToString().ToUpper()) return true;
				}


				return false;
			}
			catch {
				return false;
			}
		}

		public static string CalcolaCheckBackup1(DataRow R){
			string S= "1"+QueryCreator.quotedstrvalue(R["iddb"],true)+
				QueryCreator.quotedstrvalue(R["serverbackup1"].ToString().ToUpper(),true)+
				QueryCreator.quotedstrvalue(R["dbname"],true)+
				QueryCreator.quotedstrvalue(R["swmoreflag"],true)+
				QueryCreator.quotedstrvalue(R["swmorecode"],true);
			string Check = CheckFlags.GetCheck(S);
			return Check;
		}
		public static string CalcolaCheckBackup2(DataRow R){
			string S= "2"+QueryCreator.quotedstrvalue(R["iddb"],true)+
				QueryCreator.quotedstrvalue(R["serverbackup2"].ToString().ToUpper(),true)+
				QueryCreator.quotedstrvalue(R["dbname"],true)+
				QueryCreator.quotedstrvalue(R["swmoreflag"],true)+
				QueryCreator.quotedstrvalue(R["swmorecode"],true);
			string Check = CheckFlags.GetCheck(S);
			return Check;
		}

		public static DateTime GetTime(DataAccess Conn){
			if (Conn==null) return DateTime.Now;
			object Data= Conn.DO_SYS_CMD("SELECT getdate()",true);
			if (Data==null) return DateTime.Now;
			if (Data==DBNull.Value) return DateTime.Now;
			if (Data.GetType()!= typeof(DateTime))return DateTime.Now;
			return (DateTime) Data;
		}
	}
}
