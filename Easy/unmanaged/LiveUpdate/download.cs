/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
using System.Net;
using System.IO;
using System.Security.Permissions;
using System.Data;
using System.Windows.Forms;
using System.Text;
using System.Xml;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using metadatalibrary;
using Xceed.Zip;
using Xceed.Compression;
using Xceed.FileSystem;
using System.Threading;


namespace LiveUpdate{

	internal class TaskInfo {
		public string m_Address=null;
		private Http m_Http=null;
		public WebClient webSite=null;
        public long timediff=long.MaxValue;

		public TaskInfo(string address,  Http http) {
			m_Address=address;
			m_Http=http;
		}

		public void Process() {
			try {
				if (m_Http==null) return;
                if (m_Address == null) return;
                crono C = new crono(m_Address);
				this.webSite=m_Http.GetWebInstance(m_Address);
                long save=  C.GetDuration();
                if (this.webSite == null) {
					m_Http.PrintLog("Process() - Indirizzo scartato ["+m_Address+"]", true);
					return;
				}
				this.timediff=save;
			}
			catch (Exception E) {
				m_Http.PrintLog("TaskInfo.Process() - Errore["+E.Message+"]");
			}
		}
	}

	internal class TaskTimer {
		public Thread threadHandle=null;
		public System.Threading.Timer timer=null;
	}

	public class Http {
		WebClient client;
		public string cachepath;
		public string RemoteDir;
		private string m_LastError=null;

		public bool NonAutorizzato = false;

		enum eTipoSito {
			WEB,
			NETBIOS,
			UNKNOWN
		};
		eTipoSito WebSite = eTipoSito.UNKNOWN;

		
		private static string GetExceptionMsg(WebException W) {
			string tipo="Tentativo di download fallito (WebException)";
			string msg=tipo+GetExceptionMsg(W,false)+
				"\rStatus ["+W.Status+"]"+
				"\rHelpLink ["+W.HelpLink+"]";
			if (W.Status==WebExceptionStatus.ProtocolError) {
				msg+="\rRichiesta ["+W.Response.ResponseUri+"]\r";
			}
			return msg;
		}
		private static string GetExceptionMsg(Exception E, bool header) {
			string tipo="Tentativo di download fallito (Exception)";
			return (header?tipo:"")+"\rMessage ["+E.Message+"]"+
				"\rTargetSite ["+E.TargetSite+"]"+
				"\rSource ["+E.Source+"]"+
				"\rInnerException ["+E.InnerException+"]"+
				"\rStackTrace ["+E.StackTrace+"]+"+"{"+E.ToString()+"}";
		}

		private string m_MaxVersion="";
		private string MaxVersion {
			get {
				return m_MaxVersion;
			}
			set {
				if (value.ToString().CompareTo(m_MaxVersion)>0) m_MaxVersion=value;
			}
		}

        public static bool IsNet45OrNewer() {
            var result =
                Environment.Version.Major.Equals(4) &&
                Environment.Version.Minor.Equals(0) &&
                Environment.Version.Build.Equals(30319) &&
                Environment.Version.Revision >= 34000;

            return result || MetaDataForm.isBlazorApp();
        }

        private bool IsValid(WebClient web) {
            if (web == null) return false;
		    string swFileName = (IsNet45OrNewer() ? Costanti.C_SWVERSIONFILENAME4 : Costanti.C_SWVERSIONFILENAME);
            if (serviceName != null) swFileName = serviceName + "/" + swFileName;
            web.Headers.Add("User-Agent", "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)");
            string msg ="Http.IsValid("+web.BaseAddress+ swFileName + ")";
			try {
                
                int Ntry = 0;
                while (web.IsBusy && Ntry<20) {
                    Ntry++;
                    Thread.Sleep(50);
                    PrintLog("Web Busy - Sleeping");
                }
				byte[] bytes=web.DownloadData(swFileName);
				string download=Encoding.ASCII.GetString(bytes);
				if (download.CompareTo(MaxVersion)<0) return false;
				MaxVersion=download;
				return true;
			}
			catch (WebException W) {
				if (ChiaveLiveUpdate.NonAutorizzato(W)) NonAutorizzato = true;
				PrintLog(msg+" ::-> "+GetExceptionMsg(W));
                SetLastError("IsValid() method failed, Web Exception; serviceName:" + (serviceName ?? "null") + "; swFileName:" + (swFileName ?? "null") + "; web.BaseAddress:" + (web != null ? web.BaseAddress ?? "BaseAddress is null" : " web is null") + "", W);
                return false;
			}
			catch (Exception E) {
                PrintLog(msg+" ::->> "+GetExceptionMsg(E,true));
                SetLastError("IsValid() method failed, Exception; serviceName:" + (serviceName ?? "null") + "; swFileName:" + (swFileName ?? "null") + "; web.BaseAddress:" + (web != null ? web.BaseAddress ?? "BaseAddress is null" : " web is null") + "", E);
                return false;
			}
		}

		internal WebClient GetWebInstance(string remoteAddress) {
			if (!remoteAddress.EndsWith("/")) remoteAddress+="/";
			WebClient web=new WebClient();
            web.Headers.Add("User-Agent", "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)");
            web.BaseAddress=remoteAddress;
			web.Credentials=CredentialCache.DefaultNetworkCredentials;
			ChiaveLiveUpdate.Prepara(web, remoteAddress);

            if (IsValid(web)) return web;

            SetLastError("GetWebInstance(" + remoteAddress + ") method failed calling IsValid(" + remoteAddress + ") ", null);

            return null;
		}
		

		private void KillThread(object state) {
			if (state==null) return;
			try {
				TaskTimer s =(TaskTimer)state;
				if (s.threadHandle.IsAlive) s.threadHandle.Abort();
				if (s.timer!=null) s.timer.Dispose();
				PrintLog("       STOP  TIMER "+s.timer.GetHashCode().ToString()+ " <-----",false);
			}
			catch (Exception E) {
				PrintLog("KillThread() - Errore["+E.Message+"]");
			}
		}

		internal void PrintLog(string msg) {
			PrintLog(msg,true);
		}
		internal void PrintLog(string msg, bool print) {
			if (print) QueryCreator.MarkEvent(msg);
		}

		private WebClient GetMoreFastWeb(string[] addresses, int timeout) {
            if (addresses == null) return null;
            if (addresses.Length == 0) {
                PrintLog("Lista indirizzi accettati VUOTA");
                return null;
            }

            TaskInfo[] AllTask = new TaskInfo[addresses.Length];
            Thread[] AllThread= new Thread[addresses.Length];

			try {
				for (int i=0; i<addresses.Length;i++) {
                    string address = addresses[i];
					if (address=="") continue;
					TaskInfo ti=new TaskInfo(address,this);
                    AllTask[i] = ti;

					Thread T=new Thread(new ThreadStart(ti.Process));
				    T.Name = "LU";
                    AllThread[i] = T;

					T.Start();
                    PrintLog(" ping " + address, false);
				}
                Thread.Sleep(10);
                Thread.Sleep(timeout);
				long mindiff=long.MaxValue;
                WebClient fastwebsite = null;
                for (int j = 0; j < addresses.Length; j++) {
                    try {
                        TaskInfo info = AllTask[j];
                        if(info == null) continue;
                        PrintLog(" Indirizzo [" + info.m_Address + "] - Tempo di risposta [" + info.timediff + "]", false);
                        if(info.timediff < mindiff) {
                            fastwebsite = info.webSite;
                            mindiff = info.timediff;
                        }
                        Thread T = AllThread[j];
                    }
                    catch (Exception E){
                        SetLastError(" Indirizzo [" + AllTask[j].m_Address + "] failed", E);
                    }
                }
                if (fastwebsite == null) return null;

                return fastwebsite;
			}
			catch (Exception E) {
				PrintLog("GetMoreFastWeb() - Errore ["+E.Message+"]");
                SetLastError("GetMoreFastWeb() failed", E);
                return null;
			}
		}

		private WebClient GetFastWeb(string remoteAddress) {

			WebClient webPilota=GetWebInstance(remoteAddress);
			
            if (webPilota == null)
                SetLastError("GetFastWeb(" + remoteAddress + ") method failed calling GetWebInstance(" + remoteAddress + ") ", null);

            if (webPilota==null) return null;
			try {
                string filename = "";
                if (remoteAddress.Contains("easyservices")){
                    filename = Costanti.C_LISTASITIWEBSERVICES;
                }else{
					filename = Costanti.C_LISTASITIWEB;
				}
				webPilota.DownloadFile(filename,@"zip\"+filename);
                webPilota.Dispose();
                StreamReader read = new StreamReader( @"zip\" + filename, System.Text.Encoding.Default);
				string s=null;
				string testo=null;
				while ((s=read.ReadLine())!=null) {
					testo+=s+"|";
				}
                read.Close();


			

				string[] siti=testo.Split('|');
			    try {
                    
			        string fname = "updateconfig.xml";
			        DataSet DS = new DataSet();
			        DS.ReadXml(fname);
					DS.AcceptChanges();
			        DataRow R = DS.Tables["configtable"].Rows[0];




					CleanupUpdateConfig(R, CleanupUrlsArray(siti));
                    PostData.RemoveFalseUpdates(DS);

                    if (DS.HasChanges()) {
			            File.SetAttributes(fname, FileAttributes.Normal);
			            DS.WriteXml(fname);
			        }
			    }
			    catch (Exception E) {
			        PrintLog("Updating updateconfig.xml - Errore [" + QueryCreator.GetErrorString(E) + "]");
                    SetLastError("Updating updateconfig.xml failed", E);
                }

                WebClient fastWeb=GetMoreFastWeb(siti,3000);
				if (fastWeb!=null) return fastWeb;
				fastWeb=GetMoreFastWeb(siti,10000);
				if (fastWeb!=null) return fastWeb;
                return null;
			}
			catch (Exception E) {
                PrintLog("GetFastWeb(): Errore [" + QueryCreator.GetErrorString(E) + "]");
                SetLastError("GetFastWeb() method failed", E);
                return null;
			}

		}

		public static string[] CleanupUrlsArray(string[] presumedUrls) {





			return presumedUrls.ToList().FindAll(pu => {
				try {
					new Uri(pu);
				}
				catch (Exception e) {
					return false;
				}
				return true;
			}).ToArray();
		}

		public static void CleanupUpdateConfig(DataRow r, string[] liveUpdateEndpoints) {
			if (liveUpdateEndpoints.Length > 0) {
				r.Table.Columns
					._forEach(c => {
						if (c.ColumnName.StartsWith("httpupdatepath") && r[c].ToString().StartsWith("http"))
							r[c] = DBNull.Value;
					});

				var lista = liveUpdateEndpoints.ToList();

				r.Table.Columns._forEach(c => {
					if (lista.Count == 0) return;
					if (!c.ColumnName.StartsWith("httpupdatepath")) return;
					if (r[c].ToString() != "") return;

					r[c] = lista[0];
					lista.RemoveAt(0);
				});
			}
        }

        public string serviceName;
	    public Http(string[] addresses, string cachepath,string serviceName) {
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

			try {
	            this.serviceName = serviceName;
	            if (!cachepath.EndsWith("\\")) cachepath+="\\";
	            this.cachepath = cachepath;			
	            foreach (string address in addresses) {
	                if ((address == null) || (address == string.Empty)) continue;
	                string path = address.Trim();
                    
	                WebSite = eTipoSito.UNKNOWN;
	                if (path.StartsWith("http")) {
	                    client=GetFastWeb(path);
	                    if (client==null) continue;
	                    WebSite=eTipoSito.WEB;
	                    this.RemoteDir=client.BaseAddress;
	                    if (!path.EndsWith("/")) path+="/";
	                    return;
	                }
	                else {
	                    try {
	                        DirectoryInfo d = new DirectoryInfo(path);
	                        if (!d.Exists) continue;
	                        WebSite = eTipoSito.NETBIOS;
	                        this.RemoteDir = path;
	                        if (!path.EndsWith("\\")) path+="\\";

	                        return;
	                    }
	                    catch { 
	                        continue; 
	                    }
	                }
	            }
	        }
	        catch (Exception E){
	            QueryCreator.ShowException(E);
	            WebSite = eTipoSito.UNKNOWN;
	        }
	    }

		public Http(string[] addresses, string cachepath) {
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

			try {

			    if (!cachepath.EndsWith("\\")) cachepath+="\\";
				this.cachepath = cachepath;			
				foreach (string address in addresses) {
					if ((address == null) || (address == string.Empty)) continue;
					string path = address.Trim();
                    
					WebSite = eTipoSito.UNKNOWN;
					if (path.StartsWith("http")) {
						client=GetFastWeb(path);

                        if (client == null)
                            SetLastError("GetFastWeb(" + path + ") method failed", null);

                        if (client==null) continue;
						WebSite=eTipoSito.WEB;
						this.RemoteDir=client.BaseAddress;
					    if (!path.EndsWith("/")) path+="/";
						return;
					}
					else {
						try {
							DirectoryInfo d = new DirectoryInfo(path);
							if (!d.Exists) continue;
							WebSite = eTipoSito.NETBIOS;
							this.RemoteDir = path;
						    if (!path.EndsWith("\\")) path+="\\";

							return;
						}
						catch { 
							continue; 
						}
					}
				}
			}
			catch (Exception E){
				QueryCreator.ShowException(E);
				WebSite = eTipoSito.UNKNOWN;
                SetLastError("Http() constructor failed", E);
            }
        }

		public bool IsAvailable() {
			return WebSite != eTipoSito.UNKNOWN;
		}

		public void ImpostaChiave(string chiave) {
			if (WebSite != eTipoSito.WEB || client == null) return;
			ChiaveLiveUpdate.Imposta(client, client.BaseAddress, chiave);
		}

		public string DownloadData(string filename) {
			try {
				string fullname = RemoteDir + filename;
				switch (WebSite) {
					case eTipoSito.WEB:
						byte[] bRemoteFile = client.DownloadData(fullname);
						Encoding encode = Encoding.ASCII;
						string s=encode.GetString(bRemoteFile).TrimEnd();
                        PrintLog("Letto da [" + fullname + "] : [" + s.TrimEnd() + "]",false);
						if (s.CompareTo("0.0.0")<=0) {
							SetLastError("DownloadData("+filename+") method failed - encode.GetString() returns ["+s+"]");
							return null;
						}
						return s;

					case eTipoSito.NETBIOS:
						string testo = null;
						using (StreamReader sr = new StreamReader(fullname,System.Text.Encoding.Default)) {
							string line;
							while ((line = sr.ReadLine()) != null) {
								testo += line;
							}
						}
						return testo;

					default:
						SetLastError("DownloadData("+filename+") method failed - TipoSito unknown");
						return null;
				}
			}
			catch (Exception E) {
				if (ChiaveLiveUpdate.NonAutorizzato(E)) NonAutorizzato = true;
				SetLastError("DownloadData("+filename+") method failed",E);
				return null;
			}
		}

		public void DownloadFile(string webfilename, string localfilename) {
		    string destFileName = cachepath + localfilename;
		    string remoteFileName = RemoteDir + webfilename;
			if (File.Exists(destFileName) &&
				(File.GetAttributes(destFileName)!= System.IO.FileAttributes.Archive))
			{
				try
				{
					File.SetAttributes(destFileName,System.IO.FileAttributes.Archive);
				}
				catch(Exception e)
				{
					PrintLog("errore nell'estrazione di :" + localfilename + "\n"+e.Message);
				}
			}

			switch(WebSite) {
				case eTipoSito.WEB:
					client.DownloadFile(remoteFileName, destFileName);
					break;

				case eTipoSito.NETBIOS:
				{
					File.Copy(remoteFileName, destFileName, true);
					break;
				}
			}
			return;
		}
		private void SetLastError(string error) {
			SetLastError(error,null);
		}

		private void SetLastError(string error, Exception E) {
			m_LastError+= "\r\n" + error;
			if (E!=null) m_LastError+=$"\r\rDettaglio: {E.Message} - {E.InnerException?.Message}" ;
		}

		public string GetLastError() {
			string s=m_LastError;
			m_LastError=null;
			return s;
		}
	}

	public class Download {
        private Http http;
		private string localXMLFileName;
		private string remoteXMLFileName;
		private string currdir;
		private string status;
		private string statusDB;
		private string lasterrorDB;
		public bool is_alive;
		private const string C_DBVERSIONFILENAME = "versionedb.txt";
		private const string C_SCRIPTFILENAME = "scriptindex.xml";
		private const string C_CANTLIVEUPDATE = "Impossibile eseguire aggiornamento software";
		private const string C_LIVEUPDATEOK = "Aggiornamento software OK";
		private const string C_CANTDBUPDATE = "Impossibile eseguire aggiornamento DB";
		private const string C_CANTDBUPDATELOCAL = "DB non aggiornato";
		private const string C_DBUPDATEOK = "Aggiornamento DB OK";
		private const string C_FOLDERZIP = "zip";
		string C_FOLDERDLL = (IsNet45OrNewer() ? "zip4" : "zip");
		private const string C_FOLDERREPORT = "report";
		private const string C_TABVERSION = "updatedbversion";
		private const string C_TABSCRIPT = "updatedbscript";
		private const string C_TABMENU = "updatedbmenu";
		private const string C_SWDUMMYVERSION = "1.0.0";
		private const string C_DBDUMMYVERSION = "1.0.0";
		private const string C_REPORTDUMMYVERSION = "1.0.000";
		private bool signaled = false;
		private bool m_isAdmin = false;
		private DataAccess m_Conn;
		private static string m_ClientSWVersion = C_SWDUMMYVERSION;
		private static string m_ClientRPTVersion = C_SWDUMMYVERSION;
		private const int C_SQLCOMMANDTIMEOUT = 6000;

		private bool m_IsDBUpdated = false;
		private static string m_UpdateDBInCorso;
		private bool m_Connected = false;
		private string m_FolderWEB = null;
		private string m_ReportDir = null;
		
		EntityDispatcher E;

		public void StopThread() {
			signaled = true;
		}

		private void SetStatusSW(string S){
			status= S;
		}
		public string GetStatusSW(){
			return status;
		}
		string lasterrorsw="";
		string lasterrorrpt="";

		private void SetLastErrorSW(string S,bool DLL){
			if (DLL) 
				lasterrorsw= S;
			else 
				lasterrorrpt= S;
		}

		public string GetLastErrorSW(){
			string res="";
			if (lasterrorsw!=""){
				res+=lasterrorsw;
			}
			if (lasterrorrpt!=""){
				if (!res.EndsWith("\r"))res+="\r";
				res+=lasterrorrpt;
			}
			if ((res!="")&&(!res.EndsWith("\r")))res+="\r";
			res += GetSWVersionMessage();
			return res;
		}

		private void SetStatusDB(string S){
			statusDB= S;
		}
		public string GetStatusDB(){
			return statusDB;
		}
		private void SetLastErrorDB(string S){
			lasterrorDB = S;
		}
		public string GetLastErrorDB(){
			return lasterrorDB;
		}

        public static bool IsNet45OrNewer() {
            var result =
                Environment.Version.Major.Equals(4) &&
                Environment.Version.Minor.Equals(0) &&
                Environment.Version.Build.Equals(30319) &&
                Environment.Version.Revision >= 34000;

            return result || MetaDataForm.isBlazorApp();
        }

        private bool versione4 = false;
	    private string serviceName = "";
	    public Download(EntityDispatcher E,
	        string[] WebAddress,
	        string XMLFileName, 
	        string TargetDir,string serviceName) {
	        if (IsNet45OrNewer()) {
	            versione4=true;
	        }

	        this.serviceName = serviceName;
	        is_alive =true;
	        currdir = TargetDir;
	        localXMLFileName = XMLFileName;
	        remoteXMLFileName = XMLFileName;
	        this.E=E;
	        SetStatusSW("");

	        if (!currdir.EndsWith("\\")) currdir += "\\";
	        if (!Directory.Exists(currdir)) Directory.CreateDirectory(currdir);
	        if (!Directory.Exists(Path.Combine(currdir , "zip"))) Directory.CreateDirectory(Path.Combine(currdir , "zip"));
            

	        GetLocalVersions();

	        aggiornaChiaveDalDatabase();
	        http = new Http(WebAddress, currdir,serviceName);
	    }

	    
		public Download(EntityDispatcher E,
			string[] WebAddress, 
			string XMLFileName, 
			string TargetDir) {
            if (IsNet45OrNewer()) {
                versione4=true;
            }

            is_alive =true;
			currdir = TargetDir;
			localXMLFileName = XMLFileName;
			remoteXMLFileName = XMLFileName;
			this.E=E;
			SetStatusSW("");

			if (!currdir.EndsWith("\\")) currdir += "\\";
			if (!Directory.Exists(currdir)) Directory.CreateDirectory(currdir);
            if (!Directory.Exists(currdir + "zip\\")) Directory.CreateDirectory(currdir + "zip\\");
            

			ReportDir = GetReportDir(WebAddress);

			GetLocalVersions();

			aggiornaChiaveDalDatabase();
			http = new Http(WebAddress, currdir);

			if (http == null || !http.IsAvailable())
				SetLastErrorDB("Non sono riuscito a inizializzare il client http: " + (http != null ? http.GetLastError() : "") );

        }

		private void aggiornaChiaveDalDatabase() {
			if (E == null || E.Conn == null) return;
			DataAccess copia = null;
			try {
				copia = E.Conn.Duplicate();
				ChiaveLiveUpdate.AggiornaDalDatabase(copia);
			}
			catch (Exception e) {
				QueryCreator.MarkEvent("ChiaveLiveUpdate: app_config non si legge (" + e.Message + ")");
			}
			finally {
				copia?.Destroy();
			}
		}

		private string MotivoNonDisponibile() {
			return (http != null && http.NonAutorizzato) ? ChiaveLiveUpdate.C_NONAUTORIZZATO : Costanti.C_SITENOAVAILABLE;
		}

        void GetLocalVersions(){
			m_ClientSWVersion= GetLocalDLLVersion(currdir);
			if (serviceName=="")m_ClientRPTVersion = GetLocalReportVersion(ReportDir);
		}

		public bool Connected {
			get {
				return m_Connected;
			}
		}


		public void GenDLLDiff(string DiffFileName, string DiffDirFiles, string filter){
			Hashtable lista;
			GenDLLDiff(DiffFileName, DiffDirFiles, filter,  out lista);
		}

		public void GenDLLDiff(string unusedParameter, 
		    string DiffDirFolder,
		    string filter,
		    out Hashtable Lista){
			DsDLLIndex dsloc = new DsDLLIndex();
			DsDLLIndex dsrem = new DsDLLIndex();

			Lista = new Hashtable();

			try {
				if (http == null || !http.IsAvailable()) {
					MetaFactory.factory.getSingleton<IMessageShower>().Show("Impossibile effettuare elenco differenze, indirizzi non raggiungibili: "+ http.ToString(),
						"Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}

                m_Connected = true;
				
				DirectoryInfo d = new DirectoryInfo(DiffDirFolder);
			    if (!d.Exists) {
			        d.Create();
			    }
			    else {
			        SvuotaDir(DiffDirFolder); 
			    }
					
			    string tempZipFolder = Path.Combine(currdir,"zip");

				DirectoryInfo dzip = new DirectoryInfo(tempZipFolder);
				if (!dzip.Exists) dzip.Create();
			    
			    string currTempIndex = Path.Combine(tempZipFolder ,remoteXMLFileName);

                string relativeTempIndexName =  Path.Combine(C_FOLDERZIP ,remoteXMLFileName)+".zip";
			    string currTempIndexZip = currTempIndex+ ".zip";
			    string indexZipFileName = serviceName==""? remoteXMLFileName + ".zip" : serviceName+"/" + remoteXMLFileName +".zip";
			    

			    http.DownloadFile(indexZipFileName, relativeTempIndexName);

				XZip.ExtractFiles(currTempIndexZip, tempZipFolder, remoteXMLFileName, true, false);

			    dsrem.ReadXml(currTempIndex);

			    string localIndexFileName = currdir + localXMLFileName;
                


				XZip.ExtractFiles(localIndexFileName + ".zip", currdir, localXMLFileName, true, false);

				dsloc.ReadXml(Path.Combine( currdir + localXMLFileName));


				DataTable dtloc = dsloc.DLL;
                DataTable dtrem = dsrem.DLL;
                DsDLLIndex Ds3 = new DsDLLIndex();
                DataTable DiffTable = Ds3.DLL;
				bool diff=false;

			    Dictionary<string, DataRow> lookupLocal = new Dictionary<string, DataRow>();
                Dictionary<string, DataRow> lookupRemote = new Dictionary<string, DataRow>();
			    foreach (DataRow drloc in dtloc.Rows) {
			        lookupLocal[drloc["dllname"].ToString()] = drloc;
			    }
                foreach (DataRow drrem in dtrem.Rows) {
                    lookupRemote[drrem["dllname"].ToString()] = drrem;
                }
                foreach (DataRow drloc in dtloc.Rows) {
                    DataRow drrem = null;
                    string fName = drloc["dllname"].ToString();
                    if (lookupRemote.ContainsKey(fName)) drrem = lookupRemote[fName];                   
                    
					if (DLLAggiornata(drloc, drrem)) {
                        DataRow NewR = DiffTable.NewRow();
                        NewR["dllname"] = drloc["dllname"];
                        NewR["major"] = drloc["major"];
                        NewR["minor"] = drloc["minor"];
                        NewR["build"] = drloc["build"];

                        DiffTable.Rows.Add(NewR);
						string fname = NewR["dllname"].ToString();
						XZip.AddFiles(Path.Combine(DiffDirFolder , fname + ".zip"), currdir, fname, true, false);
						diff=true;
						if (drrem==null) {
							Lista.Add(fname, "NUOVO"+"\t"+
								drloc["major"].ToString()+"."+drloc["minor"].ToString()+"."+
                                        drloc["build"].ToString());
						}
						else {
                            Lista.Add(fname, drrem["major"].ToString() + "." + 
                                            drrem["minor"].ToString() + "." +
                                            drrem["build"].ToString() + "\t" +
                                drloc["major"].ToString() + "." + drloc["minor"].ToString() + "." +
                                        drloc["build"].ToString());
						}
					}
				}

                foreach (DataRow drrem in dtrem.Rows) {
                    string fName = drrem["dllname"].ToString();
                    DataRow drloc = null;
                    if (lookupLocal.ContainsKey(fName)) drloc = lookupLocal[fName];                    
                    if (drloc == null) {
                        Lista.Add(drrem["dllname"], "!MANCA\t\t" +
                            drrem["major"].ToString() + "." + drrem["minor"].ToString() + "." +
                                    drrem["build"].ToString());
                        continue;
                    }
                    if (DLLAggiornata(drrem, drloc)) {
                        DataRow NewR = DiffTable.NewRow();
                        NewR["dllname"] = drrem["dllname"];
                        NewR["major"] = drrem["major"];
                        NewR["minor"] = drrem["minor"];
                        NewR["build"] = drrem["build"];

                        DiffTable.Rows.Add(NewR);
                        string fname = NewR["dllname"].ToString();
                        Lista.Add(fname, "!VECCHIO\t" + drrem["major"].ToString() + "." +
                                        drrem["minor"].ToString() + "." +
                                        drrem["build"].ToString() + "\t" +
                            drloc["major"].ToString() + "." + drloc["minor"].ToString() + "." +
                                    drloc["build"].ToString());

                    }
                    
                }




				if (diff){
                    string fdifname2 = Path.Combine(DiffDirFolder , localXMLFileName);


                    XZip.AddFiles(fdifname2 + ".zip", currdir, localXMLFileName, true, false);

				}

			}
			catch (Exception E) {
				MetaFactory.factory.getSingleton<IMessageShower>().Show(E.Message , "Errore");
				return;
			}
		}

		
		private bool DLLAggiornata(DataRow dllNuova,
            DataRow dllVecchia) {
			if (dllVecchia == null) return true;
            int oldmajor = Getint(dllVecchia["major"]);
            int newmajor = Getint(dllNuova["major"]);
            if (newmajor > oldmajor) return true;
            if (newmajor < oldmajor) return false;

            int oldminor = Getint(dllVecchia["minor"]);
            int newminor = Getint(dllNuova["minor"]);
            if (newminor > oldminor) return true;
            if (newminor < oldminor) return false;

            int oldbuild = Getint(dllVecchia["build"]);
            int newbuild = Getint(dllNuova["build"]);
            if (newbuild > oldbuild) return true;




			return false;
		}
        int Getint(object O) {
            if (O == null) return 0;
            if (O == DBNull.Value) return 0;
            return Convert.ToInt32(O);
        }


        void DeleteSmallFile(string destFolder, string filename) {
            return;


        }
		private void CopyFromCache(string filename, string zipfolder, string destFolder,bool deleteoriginal){
			if (!destFolder.EndsWith(@"\")) destFolder+=@"\";
			string lasttempt = "Sposto "+filename;
			string destfile = destFolder+filename;
			string fullpathfilename = zipfolder + "\\" + filename;
			string fullpathzipfilename = fullpathfilename + ".zip";
			if (File.Exists(destfile)) {
				lasttempt = "Imposto gli attributi a "+filename;
				File.SetAttributes(destfile, FileAttributes.Normal);
				lasttempt = "Elimino "+filename;
				if (MetaDataForm.isBlazorApp())
				{
					try
					{
						File.Move(destfile, destfile + $".{guid}.blzdel");
					}
					catch (Exception ex)
					{
						logInfo($"Errore Move: {ex.Message}");
					}					
				}
				else
				{
					File.Delete(destfile);
				}
			}
			lasttempt = "Sposto "+fullpathfilename+ " in "+destfile;
			File.Move(fullpathfilename, destfile);
			lasttempt = "Elimino "+fullpathfilename;
			if (deleteoriginal) File.Delete(fullpathzipfilename);
		}

		private string guid = (Guid.NewGuid()).ToString();

		private void deleteTempBlazorFiles()
		{
			if (MetaDataForm.isBlazorApp())
			{
				try
				{
					string[] files = Directory.GetFiles(currdir, "*.blzdel");
					foreach (string file in files)
					{
						File.Delete(file);
					}
				}
				catch (Exception ex)
				{
					logInfo($"Errore Delete: {ex.Message}");
				}
			}
		}

		private void logInfo(string s)
		{
			try { System.IO.File.AppendAllText($"{AppDomain.CurrentDomain.BaseDirectory}__Log.txt", DateTime.Now.ToString("yy-MM-dd HH:mm:ss") + " - " + s + "\r\n"); } catch { }
		}

		private static void SvuotaDir(string folder) {
			try {
			    DirectoryInfo d = new DirectoryInfo(folder);
			    if (!d.Exists) d.Create();
			    foreach (FileInfo f in d.GetFiles()) {
			        File.Delete(f.FullName);
			    }
			    foreach (var dir in d.GetDirectories()) {
			        SvuotaDir(dir.FullName);
			        Directory.Delete(dir.FullName);
			    }

			}
			catch {
			}
		}



        static void MarkEvent(string e){			
			string msg = DateTime.Now.ToString("HH:mm:ss.fff");
			while ((e.EndsWith("\n")||(e.EndsWith("\r")))) {
				e = e.Substring(0, e.Length-1);
			}
			Debug.Write(msg+": "+e+"\n");
		}

		#region Live Update Software

		private static void SetClientSWVersion(string newVersion) {
			m_ClientSWVersion = newVersion;
		}

		public static string GetClientSWVersion() {
			return m_ClientSWVersion;
		}


	    string getVersionFileName() {
            return versione4 ? Costanti.C_SWVERSIONFILENAME4 : Costanti.C_SWVERSIONFILENAME;
        }
		public string GetLocalDLLVersion(string localdir) {		    
			try {
				FileInfo f = new FileInfo(localdir + getVersionFileName());
				string localVersion;
				if (!f.Exists) {
					localVersion = C_SWDUMMYVERSION;
					StreamWriter write = f.CreateText();
					write.WriteLine(localVersion);
					write.Close();
                    write.Dispose();
				}
				else {
					File.SetAttributes(f.FullName,FileAttributes.Normal);
					StreamReader read = f.OpenText();
					localVersion = read.ReadLine();
					read.Close();
                    read.Dispose();
				}
				return localVersion;
			}
			catch {
			}
			return "0.0.000";
		}

		string GetSWVersionMessage(){
			string mess = "Versione SW attuale :"+GetClientSWVersion()+"\r";
			mess+= "Versione Report attuale :"+m_ClientRPTVersion+"\r";
			return mess;
		}
		private bool ControllaVersioneSW(out string remoteVersion) {
			string lasttempt = "Controllo Versione SW";
			string localVersion;
			remoteVersion = null;

			try {
				lasttempt = "Leggo versione software remota";
				SetStatusSW(lasttempt);
				remoteVersion = http.DownloadData(getVersionFileName());
				if (remoteVersion==null) {
					SetStatusSW(C_CANTLIVEUPDATE);
					SetLastErrorSW("DLL: "+lasttempt + " - " + http.GetLastError(),true);
					return false;
				}
				lasttempt = "Leggo versione software locale";
				SetStatusSW(lasttempt);
				localVersion= GetLocalDLLVersion(currdir);
				SetClientSWVersion(localVersion);
				if (remoteVersion.CompareTo(localVersion) > 0) return true;
				SetStatusSW(C_LIVEUPDATEOK);
				SetLastErrorSW("DLL: Aggiornamento Ok",true);
			}
			catch (Exception e) {
				SetStatusSW(C_CANTLIVEUPDATE);
				SetLastErrorSW("DLL: "+lasttempt + " - " + e.Message,true);
			}
			return false;
		}


		public void GetNewSWVersion() {
			
			deleteTempBlazorFiles();

			m_FolderWEB = C_FOLDERDLL;

			if (http == null || !http.IsAvailable()) {
				SetStatusSW(C_CANTLIVEUPDATE);
				SetLastErrorSW("DLL :"+MotivoNonDisponibile(),true);
				is_alive=false;
				return;
			}

			m_Connected = true;

			string remoteVersion;
			if (!ControllaVersioneSW(out remoteVersion)) {
				is_alive=false;
				return;
			}

			if (!ScaricaFile(remoteVersion, true)) {
				is_alive=false;
				return;
			}
			AppDomain.CurrentDomain.SetData("doupdate","1");

			SetStatusSW(C_LIVEUPDATEOK);
			SetLastErrorSW("DLL: Aggiornamento Ok",true);
			is_alive=false;
		}


		private bool ScaricaFile(string remoteVersion, bool IsDLL) {
			string dbversion = http.DownloadData(C_DBVERSIONFILENAME);
			if (dbversion==null && http.NonAutorizzato) {
				SetStatusSW(C_CANTLIVEUPDATE);
				SetLastErrorSW((IsDLL ? "DLL: " : "Report: ") + ChiaveLiveUpdate.C_NONAUTORIZZATO, IsDLL);
				return false;
			}
			if (dbversion==null) return ScaricaFileNonZippati(remoteVersion, IsDLL);

			SetStatusSW("Scarico file aggiornati");
			DsDLLIndex dsloc = new DsDLLIndex();
			DsDLLIndex dsrem = new DsDLLIndex();
			string lasttempt="";

			string InitialStatus = GetStatusSW();

			try {
				lasttempt = "Svuoto directory " + currdir + C_FOLDERZIP;
				SvuotaDir(currdir + C_FOLDERZIP);

				SetStatusSW("Scarico il file indice remoto");
				lasttempt = "Scarico il file indice remoto";
				http.DownloadFile(remoteXMLFileName + ".zip", C_FOLDERZIP + "/" + remoteXMLFileName + ".zip");
				
				SetStatusSW("Estrazione del file indice remoto");
				lasttempt = "Estrazione del file indice remoto";
				XZip.ExtractFiles(currdir + C_FOLDERZIP + "/" + remoteXMLFileName + ".zip",
					currdir + C_FOLDERZIP, remoteXMLFileName, true, false);

				SetStatusSW("Lettura del file indice remoto");
				lasttempt = "Lettura del file indice remoto";
				dsrem.ReadXml(currdir + C_FOLDERZIP + "/" + remoteXMLFileName);

				if (IsDLL) {
					if (!File.Exists(currdir + localXMLFileName)) {
						SetStatusSW("Generazione del file indice locale");
						lasttempt = "Generazione del file indice locale";
						GenXML.GeneraFileXML(currdir, localXMLFileName, "*.dll");
					}
				}
				else {
					if (!File.Exists(ReportDir + localXMLFileName)) {
						SetStatusSW("Generazione del file indice locale");
						lasttempt = "Generazione del file indice locale";
						GenXML.GeneraFileXML(ReportDir, localXMLFileName, "*.rpt");
					}
				}

				SetStatusSW("Lettura del file indice locale");
				lasttempt = "Lettura del file indice locale";
				if (IsDLL)
					dsloc.ReadXml(currdir + localXMLFileName);
				else
					dsloc.ReadXml(ReportDir + localXMLFileName);

				DataTable dtloc = dsloc.DLL;
				DataTable dtrem = dsrem.DLL;

                if (!IsDLL) {
                    foreach (DataRow R in dsloc.Tables["DLL"].Select()) {
                        if (dsrem.Tables["DLL"].Select("dllname=" +
                            QueryCreator.quotedstrvalue(R["dllname"], false)).Length == 0) {
                            string fname = R["dllname"].ToString();
                            R.Delete();
                            DeleteSmallFile(ReportDir, fname);
                        }
                    }
                }
                dsloc.AcceptChanges();

			    Dictionary<string, DataRow> allLoc = new Dictionary<string, DataRow>();
			    foreach (DataRow r in dtloc.Rows) {
                    allLoc[r["dllname"].ToString()] = r;
			    }

				foreach (DataRow drrem in dtrem.Rows) {
					if (signaled) break;

				    DataRow drloc = null;
				    if (allLoc.ContainsKey(drrem["dllname"].ToString())) {
				        drloc = allLoc[drrem["dllname"].ToString()];
				    }
					SetStatusSW("Controllo "+drrem["dllname"].ToString());
                    lasttempt = "Controllo " + drrem["dllname"].ToString();
					if (DLLAggiornata(drrem, drloc)) {
						if (drloc==null) {
							drloc = dtloc.NewRow();
                            foreach (string field in new string[] { "dllname", "major", "minor", "build" }) {
                                drloc[field] = drrem[field];
                            }
							dtloc.Rows.Add(drloc);
                            allLoc[drrem["dllname"].ToString()] = drloc;
                        }
						else {
                            foreach (string field in new string[] { "major", "minor", "build" }) {
                                drloc[field] = drrem[field];
                            }
							
						}
						string fname = drrem["dllname"].ToString() + ".zip";
						SetStatusSW("Sto aggiornando " + fname);
						lasttempt="Sto aggiornando " + fname;
						http.DownloadFile(m_FolderWEB + "/" + fname, C_FOLDERZIP + "/" + fname);
						string sourceFolder = currdir + C_FOLDERZIP; 
						string zipname = sourceFolder + "\\" + fname;
						SetStatusSW("Estrazione del file " + zipname);
						lasttempt="Scarico " + fname;
						MarkEvent(lasttempt);
                        XZip.ExtractFiles(zipname, sourceFolder, drrem["dllname"].ToString(), true, false);
						
                        if (IsDLL)
                            CopyFromCache(drrem["dllname"].ToString(), sourceFolder, currdir, true);
                        else {
                            CopyFromCache(drrem["dllname"].ToString(), sourceFolder, ReportDir, true);
                            DeleteSmallFile(ReportDir, drrem["dllname"].ToString());
                        }


                    }
				}
                if (IsDLL)
                    dsloc.WriteXml(currdir + localXMLFileName);
                else
                    dsloc.WriteXml(ReportDir + localXMLFileName);

              

                if (!signaled) {
					lasttempt = "Scrittura della nuova versione";
					SetStatusSW(lasttempt);
					
					string filename;
					if (IsDLL)
						filename=currdir + getVersionFileName();
					else
						filename=ReportDir + Costanti.C_REPORTVERSIONFILENAME;

					FileInfo f = new FileInfo(filename);
					StreamWriter write = f.CreateText();
					write.WriteLine(remoteVersion);
					write.Close();
				}
			}
			catch (Exception E) {
				if (IsDLL) {
					SetStatusSW(C_CANTLIVEUPDATE);
					SetLastErrorSW("DLL: "+E.Message + " - " + lasttempt+"\r",true);
				}
				else {
					SetLastErrorSW(
						"Report: "+ E.Message + " - " + lasttempt+"\r",false);
				}
				is_alive=false;
				return false;
			}

			try {
				File.Delete(currdir + C_FOLDERZIP + "/" + remoteXMLFileName + ".zip");
				File.Delete(currdir + C_FOLDERZIP + "/" + remoteXMLFileName);
			}
			catch {}
			if (IsDLL) {
				SetStatusSW(C_LIVEUPDATEOK);
			}
			else {
				SetStatusSW(InitialStatus);
				m_ClientRPTVersion = remoteVersion;
			}
			return true;
		}
        DataRow FindOne(DataTable T, string field, object O) {
            CQueryHelper QHC = new CQueryHelper();
            DataRow[] f = T.Select(QHC.CmpEq(field, O));
            if (f.Length == 0) return null;
            return f[0];
        }

		private bool ScaricaFileNonZippati(string remoteVersion, bool IsDLL) {

			deleteTempBlazorFiles();

			SetStatusSW("Scarico file aggiornati");
			DsDLLIndex dsloc = new DsDLLIndex();
			DsDLLIndex dsrem = new DsDLLIndex();
			string lasttempt="";

			string InitialStatus = GetStatusSW();
			try {
				lasttempt = "Svuoto directory " + currdir + C_FOLDERZIP;
				SvuotaDir(currdir + C_FOLDERZIP);
				
				SetStatusSW("Scarico il file indice remoto");
				lasttempt = "Scarico il file indice remoto";
				http.DownloadFile(remoteXMLFileName , C_FOLDERZIP + "/" + remoteXMLFileName );
				

				SetStatusSW("Lettura del file indice remoto");
				lasttempt = "Lettura del file indice remoto";
				dsrem.ReadXml(currdir + C_FOLDERZIP + "/" + remoteXMLFileName);

				if (IsDLL) {
					if (!File.Exists(currdir + localXMLFileName)) {
						SetStatusSW("Generazione del file indice locale");
						lasttempt = "Generazione del file indice locale";
						GenXML.GeneraFileXML(currdir, localXMLFileName, "*.dll");
					}
				}
				else {
					if (!File.Exists(ReportDir + localXMLFileName)) {
						SetStatusSW("Generazione del file indice locale");
						lasttempt = "Generazione del file indice locale";
						GenXML.GeneraFileXML(ReportDir, localXMLFileName, "*.rpt");
					}
				}

				SetStatusSW("Lettura del file indice locale");
				lasttempt = "Lettura del file indice locale";
				if (IsDLL)
					dsloc.ReadXml(currdir + localXMLFileName);
				else
					dsloc.ReadXml(ReportDir + localXMLFileName);

				DataTable dtloc = dsloc.DLL;
				DataTable dtrem = dsrem.DLL;
	
				foreach (DataRow drrem in dtrem.Rows) {
					if (signaled) break;

					DataRow drloc = FindOne(dtloc,"dllname",drrem["dllname"]);
                    SetStatusSW("Controllo " + drrem["dllname"].ToString());
                    lasttempt = "Controllo " + drrem["dllname"].ToString();
					if (DLLAggiornata(drrem, drloc)) {
						if (drloc==null) {
                            drloc = dtloc.NewRow();
                            drloc["dllname"] = drrem["dllname"];
                            drloc["major"] = drrem["major"];
                            drloc["minor"] = drrem["minor"];
                            drloc["build"] = drrem["build"];                           
							dtloc.Rows.Add(drloc);
						}
						else {
                            drloc["major"] = drrem["major"];
                            drloc["minor"] = drrem["minor"];
                            drloc["build"] = drrem["build"];
                        }
                        string fname = drrem["dllname"].ToString();
						SetStatusSW("Sto aggiornando " + fname);
						lasttempt="Sto aggiornando " + fname;
						http.DownloadFile(fname, C_FOLDERZIP + "/" + fname);
						string sourceFolder = currdir + C_FOLDERZIP; 
						string zipname = sourceFolder + "\\" + fname;
						SetStatusSW("Estrazione del file " + zipname);
						lasttempt="Estrazione del file " + zipname;
						MarkEvent(lasttempt);

						
						if (IsDLL)
                            CopyFromCache(drrem["dllname"].ToString(), sourceFolder, currdir, true);
						else
                            CopyFromCache(drrem["dllname"].ToString(), sourceFolder, ReportDir, true);

						if (IsDLL)
							dsloc.WriteXml(currdir+localXMLFileName);
						else
							dsloc.WriteXml(ReportDir+localXMLFileName);


					}
				}

				if (!signaled) {
					lasttempt = "Scrittura della nuova versione";
					SetStatusSW(lasttempt);
					
					string filename;
					if (IsDLL)
						filename=currdir + getVersionFileName();
					else
						filename=ReportDir + Costanti.C_REPORTVERSIONFILENAME;

					FileInfo f = new FileInfo(filename);
					StreamWriter write = f.CreateText();
					write.WriteLine(remoteVersion);
					write.Close();
				}
			}
			catch (Exception E) {
				if (IsDLL) {
					SetStatusSW(C_CANTLIVEUPDATE);
					SetLastErrorSW("DLL : "+E.Message + " - " + lasttempt+"\r",true);
				}
				else {
					SetLastErrorSW(
						"Report :"+E.Message + " - " + lasttempt+"\r",false);
				}
				is_alive=false;
				return false;
			}

			try {
				File.Delete(currdir + C_FOLDERZIP + "/" + remoteXMLFileName);
			}
			catch {}
			if (IsDLL) {
				SetStatusSW(C_LIVEUPDATEOK);
			}
			else {
				SetStatusSW(InitialStatus);
				m_ClientRPTVersion = remoteVersion;
			}
			return true;
		}



		#endregion

		#region Live Update dei Report
		
		public string GetLocalReportVersion(string localdir){
			string localVersion= "0.0.000";
			FileInfo f = new FileInfo(localdir + Costanti.C_REPORTVERSIONFILENAME);
			try {
				if (!f.Exists) {
					localVersion = C_REPORTDUMMYVERSION;
					StreamWriter write = f.CreateText();
					write.WriteLine(localVersion);
					write.Close();
                    write.Dispose();
				}
				else {
					File.SetAttributes(f.FullName,FileAttributes.Normal);
					StreamReader read = f.OpenText();
					localVersion = read.ReadLine();
					read.Close();
                    read.Dispose();
				}
			}
			catch {
			}
			return localVersion;

		}

		private bool ControllaVersioneReport(out string remoteVersion) {
			string localVersion;
			remoteVersion = null;

			try {
				remoteVersion = http.DownloadData(Costanti.C_REPORTVERSIONFILENAME);
				if (remoteVersion==null){
					SetLastErrorSW(
						"Report : indice dei report non trovato.\r"+
						"Questo è normale se è stata impostata una directory locale per il live update.\r",false);
					return false;
				}
				localVersion = GetLocalReportVersion(ReportDir);
				var remoteVersion1 = ParseVersionSafe(remoteVersion);
				var localVersion1 =  ParseVersionSafe(localVersion);
				if (remoteVersion1 > localVersion1) return true;

					SetLastErrorSW("Report: Aggiornamento OK",false);
			}
			catch (Exception e) {
				SetLastErrorSW("Report: " + e.Message, false);
			}
			return false;
		}


		Version ParseVersionSafe(string v) {
			var parts = v.Split('.').ToList();

			while (parts.Count < 4)
				parts.Add("0");

			return new Version(string.Join(".", parts));
		}
		private string GetReportDir(string[] WebAddress) {
			try {
				DataSet DS = new DataSet();
                string dir = "";
				DS.ReadXml(AppDomain.CurrentDomain.BaseDirectory+"updateconfig.xml");
                if (WebAddress[0].Contains("service")) {
                    dir = DS.Tables["configtable"].Rows[0]["localreportservicedir"].ToString();
                }
                else {
                    dir = DS.Tables["configtable"].Rows[0]["localreportdir"].ToString();
                }
				if (!dir.EndsWith(@"\") && dir!="") dir+=@"\";
				return dir;
			}
			catch {
				return string.Empty;
			}
		}

		private bool CheckReportDir(string dir) {
			try {
				if (!Directory.Exists(dir)) return false;


			
				Directory.CreateDirectory(dir+@"\~t");
				Directory.Delete(dir+@"\~t");

				return true;
			}
			catch {
				return false;
			}
		}

		public void GetNewReportVersion(string newXMLFileName) {
			localXMLFileName = newXMLFileName;
			remoteXMLFileName = newXMLFileName;
			GetNewReportVersion();
		}

		private string ReportDir {
			get {
				return m_ReportDir;
			}
			set {
				m_ReportDir = value;
			}
		}

		public void GetNewReportVersion() {
			m_FolderWEB = C_FOLDERREPORT;
			string currStatus = GetStatusSW();

			if (http == null || !http.IsAvailable()) {
				SetLastErrorSW("Report: "+MotivoNonDisponibile() ,false);
				is_alive=false;
				SetStatusSW(currStatus);
				return;
			}
			m_Connected = true;


			if (!CheckReportDir(ReportDir)) {
				SetLastErrorSW("Report: cartella \""+ReportDir+"\"\rdi sola lettura o inesistente",false);
				is_alive=false;
				SetStatusSW(currStatus);
				return;
			}

			string remoteVersion;
			if (!ControllaVersioneReport(out remoteVersion)) {
				is_alive=false;
				SetStatusSW(currStatus);
				return;
			}

			if (!ScaricaFile(remoteVersion, false)) {
				is_alive=false;
				return;
			}

			SetStatusSW(currStatus);
			is_alive=false;
		}



		#endregion

		#region Live Update del DB

		private static string AggiungiRigaScript(
			DataAccess Conn, 
			string version, 
			string scriptname, 
			StringBuilder scripttext,
			string description) {            
			string[] columns = new string[] {"versionname", "scriptname", "sql", "result"};
		    string sname = scriptname;
		    if (sname.Length > 50) sname = sname.Substring(0, 50);
		    string script = scripttext.Length > 20000 ? scripttext.ToString().Substring(0, 20000) : scripttext.ToString();
			string[] values = new string[] {
											   QueryCreator.quotedstrvalue(version, true),
											   QueryCreator.quotedstrvalue(sname, true),
											   QueryCreator.quotedstrvalue(script, true),
											   QueryCreator.quotedstrvalue(description, true)};

			return Conn.DO_INSERT(C_TABSCRIPT, columns, values, columns.Length);
		}


		
		private static bool AggiungiRigaVersion(DataAccess Conn, DataRow row) {
			string errore;
			return AggiungiRigaVersion(Conn, row, out errore);
		}

		private static bool AggiungiRigaVersion(DataAccess Conn, DataRow row, out string errore) {
			string[] columns = new string[] {"versionname", "swversion", "scriptlist", 
												"description", "flagerror", "flagadmin"};
			row["flagerror"] = "0";
			string[] values = new string[] {
											   QueryCreator.quotedstrvalue(row["versionname"], true),
											   QueryCreator.quotedstrvalue(row["swversion"], true),
											   QueryCreator.quotedstrvalue(row["scriptlist"], true),
											   QueryCreator.quotedstrvalue(row["description"], true),
											   QueryCreator.quotedstrvalue(row["flagerror"], true),
											   QueryCreator.quotedstrvalue(row["flagadmin"], true)};

			errore = Conn.DO_INSERT(C_TABVERSION, columns, values, columns.Length);
			return errore == null;
		}

		
		private static bool AggiornaRigaVersion(DataAccess Conn, DataRow row) {
			string[] columns = new string[] {"flagerror"};
			string[] values = new string[] {"'1'"};
			string condition = "versionname = '" + row["versionname"].ToString() + "'";
            if (Conn.DO_UPDATE(C_TABVERSION, condition, columns, values, columns.Length) == null) return true ;
            return false;
		}


		public static StringBuilder LeggiTestoScript(string filename) {
			string txt = System.IO.File.ReadAllText(filename, System.Text.Encoding.Default);
            StringBuilder text = new StringBuilder(txt);		    
			return text;
		}


		public bool IsDBUpdated {
			get {
				return m_IsDBUpdated;
			}
		}

		private bool GetScriptSQL(
			EntityDispatcher E,			
			bool isadmin, 
			string remoteVersion,
			string localVersion) {
			DataAccess MainConn = E.Conn.Duplicate();

			string VersioneAggiornata = localVersion;

			SetStatusDB("Scarico script SQL. Versione attuale:"+localVersion);

			DSScriptSQL dsScript = new DSScriptSQL();
			string lasttempt="";
			DataAccess ScriptConn=null;
			try {
                
				string zipindexfile = C_FOLDERZIP + "/" + C_SCRIPTFILENAME + ".zip";
				SetStatusDB("Scarico file indice degli script");
				lasttempt = "Sto scaricando " + zipindexfile;
				http.DownloadFile("sql/" + C_SCRIPTFILENAME + ".zip", zipindexfile);
				SetStatusDB("Estrazione del file indice degli script");
				lasttempt = "Estrazione del file " + zipindexfile;
				XZip.ExtractFiles(currdir + zipindexfile, currdir + C_FOLDERZIP, C_SCRIPTFILENAME, true, false);
				SetStatusDB("Lettura del file indice degli script");
				dsScript.ReadXml(currdir + C_FOLDERZIP + "/" + C_SCRIPTFILENAME);

				DataTable indexVersion = dsScript.updatedbversion;

				if (!(indexVersion.Rows.Count > 0)) {
					SetStatusDB(C_CANTDBUPDATE);
					SetLastErrorDB("Il file " + C_SCRIPTFILENAME + " non contiene righe"+
						"La versione del DB attuale è "+localVersion);
					MainConn.Destroy();
					return false;
				}
                QueryHelper QHS = MainConn.GetQueryHelper();

                ScriptConn = MainConn.Duplicate();
                object dboTabVer =MainConn.DO_READ_VALUE("sysobjects",
                        QHS.AppAnd(QHS.CmpEq("name","dbodbversion"),QHS.CmpEq("xtype","U")),"name", null);

			    object DBOversion = "0.0.000";
			    bool esisteTabellaDBODBVersion = false;
			    if (dboTabVer != null && dboTabVer != DBNull.Value) {
                    DBOversion=MainConn.DO_READ_VALUE("dbodbversion", null, "max(versionname)");
                    esisteTabellaDBODBVersion = true;
                }

                if (DBOversion == null || DBOversion == DBNull.Value) DBOversion = "0.0.000";
                string clearError = MainConn.LastError;
				foreach (DataRow versionRow in indexVersion.Rows) {
					if (signaled) break;
				    
					if (!((versionRow["versionname"].ToString().CompareTo(localVersion) > 0) &&
                        (versionRow["versionname"].ToString().CompareTo(remoteVersion) <= 0))) continue;

                    string versioneInElaborazione = versionRow["versionname"].ToString();
                    bool skipDBO = versionRow["versionname"].ToString().CompareTo(DBOversion) <= 0;
                    if (versionRow["flagadmin"].ToString() == "1" && !isadmin) {
						AdminMsg(localVersion);
						ScriptConn.Destroy();
						MainConn.Destroy();
						return false;
					}
					string[] scripts = versionRow["scriptlist"].ToString().Split(';');
					E.SetSys("dbliveupdatedescription", versionRow["description"].ToString());

					SetUpdateDbInCorso("1");
					try {
						MainConn.BeginTransaction(IsolationLevel.ReadCommitted);					    
                        lasttempt = "Scrittura della versione " + versioneInElaborazione;
                        
                        string erroreVersione;
                        if (AggiungiRigaVersion(MainConn, versionRow, out erroreVersione)) {
                            try {
                                ScriptConn.BeginTransaction(IsolationLevel.ReadCommitted);
                                foreach (string script in scripts) {
                                    string realname = script.Trim();
                                    string szip = realname.Remove(realname.Length - 3, 3) + "zip";
                                    SetStatusDB("Sto scaricando " + szip+ " della versione "+ versioneInElaborazione);
                                    lasttempt = "Sto scaricando " + szip;
                                    string scriptlocalname = currdir + C_FOLDERZIP + "/" + realname;
                                    http.DownloadFile("sql/" + versioneInElaborazione + "/" + szip, C_FOLDERZIP + "/" + szip);
                                    SetStatusDB("Estrazione del file " + szip + " della versione " + versioneInElaborazione);
                                    lasttempt = "Estrazione del file " + szip;
                                    string sourceFolder = currdir + C_FOLDERZIP;
                                    XZip.ExtractFiles(sourceFolder + "\\" + szip, sourceFolder, realname, true, false);
                                    SetStatusDB("Esecuzione dello script " + realname + " della versione " + versioneInElaborazione);
                                    lasttempt = "Esecuzione dello script " + realname;
                                    StringBuilder scripttext = LeggiTestoScript(scriptlocalname);
                                    string resultAddScript = null;
                                    if (RUN_SCRIPT(ScriptConn, scripttext,skipDBO,out resultAddScript)) {                                        
                                        try {
                                            resultAddScript= AggiungiRigaScript(MainConn, versioneInElaborazione, szip,
                                                scripttext, "SCRIPT ESEGUITO CORRETTAMENTE");
                                        }
                                        catch (Exception e) {
                                            resultAddScript = e.Message;
                                           
                                        }
                                        if (resultAddScript != null) {
                                            lasttempt += " - " + resultAddScript;
                                            ScriptConn.RollBack();
                                            MainConn.RollBack();
                                            SetStatusDB(C_CANTDBUPDATE+" alla versione "+versioneInElaborazione);
                                            SetLastErrorDB(lasttempt + "\r" + "La versione del DB attuale è " + localVersion);
                                            ScriptConn.Destroy();
                                            MainConn.Destroy();
                                            return false;
                                        }

                                    }
                                    else {
                                        string error = QueryCreator.GetPrintable(ScriptConn.LastError)+"-"+
                                                QueryCreator.GetPrintable(resultAddScript);
                                        if (error.Length > 1000) {
                                            scripttext.Insert(0,error+"\r\n");
                                            scripttext.Insert(0,"Errore:\r\n");
                                            error = "Errore accodato al testo dello script";
                                        }
                                        ScriptConn.RollBack();
                                        
                                        try {
                                            resultAddScript = AggiungiRigaScript(MainConn, versioneInElaborazione, realname, scripttext, error);
                                        }
                                        catch (Exception e) {
                                            resultAddScript = e.Message;
                                        }
                                        if (resultAddScript == null) {
                                            try {
                                                if (!AggiornaRigaVersion(MainConn, versionRow)) {
                                                    resultAddScript = "Errore aggiornando la riga di updatedbversion";
                                                }
                                            }
                                            catch (Exception e) {
                                                resultAddScript = "Errore aggiornando la riga di updatedbversion:"+ e.Message;
                                            }
                                        }
                                        if (resultAddScript == null) {
                                            try {

                                                MainConn.Commit();
                                            }
                                            catch (Exception e) {
                                                MainConn.RollBack();
                                                lasttempt += " - " + e.Message;
                                            }
                                        }
                                        else {
                                            MainConn.RollBack();
                                        }
                                        SetStatusDB(C_CANTDBUPDATE + " alla versione " + versioneInElaborazione);
                                        SetLastErrorDB(lasttempt + "\r" +"La versione del DB attuale è " + localVersion);
                                        ScriptConn.Destroy();
                                        MainConn.Destroy();
                                        return false;
                                    }
                                }
                                m_IsDBUpdated = true;
                            }
                            catch (Exception e) {
                                MainConn.RollBack();
                                ScriptConn.RollBack();
                                SetStatusDB(C_CANTDBUPDATE + " alla versione " + versioneInElaborazione);
                                SetLastErrorDB(lasttempt + " - " + e.Message + "\n" +"La versione del DB attuale è " + localVersion);
                                ScriptConn.Destroy();
                                MainConn.Destroy();
                                return false;
                            }
                            string errorCommit =ScriptConn.Commit();
                            
                            MainConn.Commit();

                            localVersion = versioneInElaborazione;
                            if (esisteTabellaDBODBVersion && !skipDBO) {
                                MainConn.DO_UPDATE("dbodbversion", QHS.CmpLt("versionname", versioneInElaborazione),
                                    new string[] {"versionname"}, new string[] {QHS.quote(versioneInElaborazione)}, 1);
                                    

                            }
                        }
                        else {
                            string errore = QueryCreator.GetPrintable(erroreVersione ?? MainConn.LastError);
                            MainConn.RollBack();
                            SetStatusDB(C_CANTDBUPDATE + " alla versione " + versioneInElaborazione);
                            SetLastErrorDB("La versione " + versioneInElaborazione + " non si registra in " + C_TABVERSION +
                                           ": " + errore + "\r" + "La versione del DB attuale è " + localVersion);
                            ScriptConn.Destroy();
                            MainConn.Destroy();
                            return false;
                        }
					}
					catch (Exception e) {
						SetStatusDB(C_CANTDBUPDATE + " alla versione " + versioneInElaborazione);
                        SetLastErrorDB(e.Message + " - " + lasttempt+"\n"+
							"La versione del DB attuale è "+localVersion);
						MainConn.RollBack();
						ScriptConn.Destroy();
						MainConn.Destroy();
						return false;
					}
                    VersioneAggiornata = versionRow["versionname"].ToString();
				}

				ScriptConn.Destroy();
				MainConn.Destroy();

			}
			catch (Exception e) {
				if (MainConn!=null){
					try {
						MainConn.Destroy();					
					}
					catch{
					}
				}
				if (ScriptConn!=null){
					try {
						ScriptConn.Destroy();					
					}
					catch{
					}
				}
				SetStatusDB(C_CANTDBUPDATE);
				SetLastErrorDB(e.Message+"\n"+"La versione del DB attuale è "+localVersion);
				return false;
			}
			SetStatusDB(C_DBUPDATEOK);
			SetLastErrorDB("Versione " + VersioneAggiornata);
			return true;
		}


		private void AdminMsg(string localversion) {
			SetStatusDB(C_CANTDBUPDATE);
			SetLastErrorDB("Connettersi come utente amministratore\n"+
				"La versione del DB attuale è "+localversion
				);
			MetaFactory.factory.getSingleton<IMessageShower>().Show("Connettersi come utente amministratore per poter " +
				"effettuare l'aggiornamento del Database", "Attenzione",
				MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		
		private static bool SaveStructureObject(DataAccess Conn, dbstructure DBS) {
			PostData post = new PostData();
			post.InitClass(DBS, Conn);
			return post.DO_POST();
		}


		private static void GenerateCustomObject(DataAccess Conn, 
			dbstructure DBS, 
			string objectname) {

			if (DBS.customobject.Rows.Count==0){
				DataRow newobj = DBS.customobject.NewRow();
				newobj["objectname"]= objectname;
				newobj["isreal"]="S";
				DBS.customobject.Rows.Add(newobj);
			}
			dbanalyzer.ReadColumnTypes(DBS.columntypes, objectname, Conn);
		}

		public bool IsSoftwareSupported() {
			DataTable Ver=GetVersionTable(Connessione);
			if (Ver==null) return false;
			string minVersionSupported = GetMinVerSupported(Ver);
			string localVersionSW = GetClientSWVersion();
			if (localVersionSW.CompareTo(minVersionSupported) >= 0) 
				return true;
			else
				return false;
		}

		private bool VersioneValida(string versione) {
			string zipindexfile = C_SCRIPTFILENAME + ".zip";
			http.DownloadFile("sql/" + C_SCRIPTFILENAME + ".zip", zipindexfile);
			
			XZip.ExtractFiles(currdir + zipindexfile, currdir, C_SCRIPTFILENAME, true, false);

			DSScriptSQL dsScript = new DSScriptSQL();
			dsScript.ReadXml(currdir + C_SCRIPTFILENAME);

			foreach (DataRow row in dsScript.updatedbversion.Rows) {
				if (row["versionname"].ToString()==versione) return true;
			}

			return false;
		}

		private bool ControllaVersioneDB(
			DataAccess Conn, 
			bool isadmin, 
			DataTable tabVersion,
			out string remoteVersion, 
			string localVersion) {

			remoteVersion = "";
			
			try {
				SetStatusDB("Lettura versione remota DB");
				remoteVersion = http.DownloadData(C_DBVERSIONFILENAME);
				if (remoteVersion==null){
					SetStatusDB(C_CANTDBUPDATELOCAL);
					SetLastErrorDB("Nella modalità di aggiornamento locale, il DB è aggiornato dalla macchina connessa ad internet.\n"+
						"La macchina attualmente impostata è quella ove risiede la cartella (impostata in 'configurazione locale') "+http.RemoteDir+
						"\nLa versione del DB attuale è "+localVersion+"\n"+http.GetLastError());
					return false;
				}

				if (tabVersion.Rows.Count > 0) {
					if (tabVersion.Rows[0]["flagerror"].ToString() == "1") {
						SetStatusDB("Controllo validità versione errata");
						if (VersioneValida(localVersion)) {
							SetStatusDB(C_CANTDBUPDATE);
							SetLastErrorDB("Impossibile eseguire l'aggiornamento " + 
								"relativo alla versione " + localVersion);
							return false;
						}
					}
				}
				else {
					try {
						SetStatusDB("Creazione tabelle customobject, columntypes, customtablestructure");
					    string error;
						if (!RUN_SCRIPT(Conn, GetCustomTablesScriptSQL(),false,out error)) {
							SetStatusDB(C_CANTDBUPDATE);
							SetLastErrorDB("Errore nell'esecuzione dello script di creazione tabelle custom.\n"+
								"La versione del DB attuale è "+localVersion
								);
							return false;
						}

						SetStatusDB("Creazione della tabella updatedbversion");
						Conn.BeginTransaction(IsolationLevel.ReadCommitted);
						if (!RUN_SCRIPT(Conn, GetVersionScriptSQL(), false, out error)) {
							SetStatusDB(C_CANTDBUPDATE);
							SetLastErrorDB("Errore nell'esecuzione dello script SQL di sistema"+
								"La versione del DB attuale è "+localVersion);
							Conn.RollBack();
							return false;
						}
						SetStatusDB("Inserimento riga versione predefinita");
						
						DSScriptSQL dsScript = new DSScriptSQL();
						DataRow row = dsScript.updatedbversion.NewRow();
						row["versionname"] = C_DBDUMMYVERSION;
						row["swversion"] = C_SWDUMMYVERSION;
						row["flagadmin"] = "0";
                        row["flagerror"] = "0";
						AggiungiRigaVersion(Conn, row);

						Conn.Commit();
						dbstructure DBS= (dbstructure) Conn.GetStructure(C_TABVERSION);
						GenerateCustomObject(Conn, DBS, C_TABVERSION);
						if (!SaveStructureObject(Conn, DBS)) {
							SetStatusDB(C_CANTDBUPDATE);
							SetLastErrorDB("Errore metodo SaveStructureObject("+C_TABVERSION+") failed"+
								"La versione del DB attuale è "+localVersion);
							return false;
						}
						DBS = (dbstructure) Conn.GetStructure(C_TABSCRIPT);
						GenerateCustomObject(Conn, DBS, C_TABSCRIPT);
						if (!SaveStructureObject(Conn, DBS)) {
							SetStatusDB(C_CANTDBUPDATE);
							SetLastErrorDB("Errore metodo SaveStructureObject("+C_TABSCRIPT+") failed"+
								"La versione del DB attuale è "+localVersion);
							return false;
						}
						DBS = (dbstructure) Conn.GetStructure(C_TABMENU);
						GenerateCustomObject(Conn, DBS, C_TABMENU);
						if (!SaveStructureObject(Conn, DBS)) {
							SetStatusDB(C_CANTDBUPDATE);
							SetLastErrorDB("Errore metodo SaveStructureObject("+C_TABMENU+") failed"+
								"La versione del DB attuale è "+localVersion);
							return false;
						}
					}
					catch (Exception e) {
						SetStatusDB(C_CANTDBUPDATE);
						SetLastErrorDB("Errore nell'esecuzione dello script SQL di sistema - " + e.Message +
							"La versione del DB attuale è "+localVersion);
						return false;
					}
				}
				if (remoteVersion.CompareTo(localVersion) > 0) return true;
				SetStatusDB(C_DBUPDATEOK);
				SetLastErrorDB("Versione " + localVersion);
			}
			catch (Exception E) {
				SetStatusDB(C_CANTDBUPDATE);
				SetLastErrorDB(E.Message);
			}
			return false;
		}



		public bool IsAdmin {
			get {
				return m_isAdmin;
			}
			set {
				m_isAdmin = value;
			}
		}
		
		public DataAccess Connessione {
			get {
				return m_Conn;
			}
			set {
				m_Conn = value;
			}
		}

		private DataTable GetVersionTable(DataAccess Conn) {
			string columnlist = "versionname,swversion,scriptlist,description,flagadmin,flagerror";
			
			DataTable Ver =  Conn.RUN_SELECT(C_TABVERSION, columnlist,
				"versionname DESC", null, "1", false);
			string err=Conn.LastError;
			if ((Ver==null) || 
					((err!=null)&&(err.ToLower().IndexOf("timeout")>=0)
						&&(Ver.Rows.Count==0))) return null;
			return Ver;
		}

		private string GetMinVerSupported(DataTable tabVersion) {
			if (tabVersion.Rows.Count > 0)
				return tabVersion.Rows[0]["swversion"].ToString();
			else
				return C_DBDUMMYVERSION;
		}

		public static string UpdateDbInCorso {
			get {
				return m_UpdateDBInCorso;
			}
		}

		private static void SetUpdateDbInCorso(string newvalue) {
			m_UpdateDBInCorso = newvalue;
		}

		private string GetDBLocalVersion(DataTable tabVersion) {
			if (tabVersion.Rows.Count > 0)
				return tabVersion.Rows[0]["versionname"].ToString();
			else
				return C_DBDUMMYVERSION;
		}

		public void GetNewDBVersion() {
			DataTable tabVersion = GetVersionTable(Connessione);
			if (tabVersion==null){
				SetStatusDB(C_CANTDBUPDATE);
				SetLastErrorDB("Non ho potuto leggere la versione dalla tabella updatedbversion");
				is_alive=false;
				return ;
			}

			string localVersion = GetDBLocalVersion(tabVersion);

			if (http == null || !http.IsAvailable()) {
				SetStatusDB(C_CANTDBUPDATE);
				SetLastErrorDB(MotivoNonDisponibile()+"\r"+
					"Versione attuale: "+localVersion);
				is_alive=false;
				return;
			}

			m_Connected = true;

			http.ImpostaChiave(ChiaveLiveUpdate.DalDatabase(Connessione));

			string remoteVersion;

			bool isadmin = this.IsAdmin;


			SetStatusDB(C_DBUPDATEOK);
			SetLastErrorDB("Versione " + localVersion);

			SetUpdateDbInCorso("0");
			if (ControllaVersioneDB(Connessione, isadmin, tabVersion, out remoteVersion, localVersion)) {
				GetScriptSQL(E, isadmin, remoteVersion, localVersion);
			}
			SetUpdateDbInCorso("2");
			E.SetUsr("mustchecksptocompile","1");
		    E.SetSys("dbversion", localVersion);
			is_alive=false;
		}

		#endregion

		#region Esegue script sql

		private static ArrayList DivideScript(StringBuilder script){
			return DivideScript(script.ToString());
		}

		public static bool readLine(string s, ref int posizione, out string riga, out string ritornoACapo) {
			if ((posizione<0)||(posizione>=s.Length)) {
				riga = null;
				ritornoACapo = null;
				return false;
			}

			int pos = s.IndexOfAny(new char[] {'\r','\n'}, posizione);

			if (pos == -1) {
				ritornoACapo = null;
                riga = s.Substring(posizione);
                posizione = s.Length;
				return true;
			}

			if (s[pos]=='\n') {
				ritornoACapo = "\n";
				riga = s.Substring(posizione, pos-posizione);
				posizione = pos+1;
				return true;
			}

			if((pos+1<s.Length)&&(s[pos+1]=='\n')) {
				ritornoACapo = "\r\n";
				riga = s.Substring(posizione, pos-posizione);
				posizione = pos+2;
				return true;
			} 

			ritornoACapo = "\r";
			riga = s.Substring(posizione, pos-posizione);
			posizione = pos+1;
			return true;
		}

		private static ArrayList DivideScript(string script){
			ArrayList CmdList= new ArrayList();
			string currline;
			string Cmd = "";
			int posizione = 0;
			string aCapo;
			while (readLine(script, ref posizione, out currline, out aCapo)) {
				if (currline.Trim().TrimStart().ToUpper() == "GO") {
					if (Cmd.Trim() != "") {
						CmdList.Add(Cmd);
					}
					Cmd = "";
				} else {
					Cmd += currline + aCapo;
				}
			}
			if (Cmd.TrimEnd() != "") {
				CmdList.Add(Cmd);
			}
			return CmdList;
		}

		private static bool RunScriptCmd(DataAccess Conn, string cmd, out string error) {
            error = null;
			DataTable T = Conn.SQLRunner(cmd,C_SQLCOMMANDTIMEOUT, out error);
			return (T != null);
		}

	    public static bool RUN_SCRIPT(DataAccess Conn, StringBuilder script, out string error) {
	        return RUN_SCRIPT(Conn, script, false, out error);
	    }

        public static bool RUN_SCRIPT(DataAccess Conn, StringBuilder script, bool skipDBO, out string error) {
            error = null;          
			ArrayList CmdList = DivideScript(script);
			for (int i=0; i < CmdList.Count; i++) {
			    string sql = CmdList[i].ToString();
                if (i==0 && sql.StartsWith("--[DBO]--") && skipDBO) return true;
				if (!RunScriptCmd(Conn, sql, out error)) return false;
			}
			return true;
		}


	    public static bool RUN_SCRIPT(DataAccess Conn, StringBuilder script, string title) {
	        string errore;
	        return RUN_SCRIPT(Conn, script, title, false, out errore);
	    }

	    public static bool RUN_SCRIPT(DataAccess Conn, StringBuilder script, string title,bool skipDBO, out string error) {
			ArrayList CmdList = DivideScript(script);
			FrmMeter FM= new FrmMeter();
			FM.labInfo.Text=title;
			FM.pBar.Maximum=CmdList.Count;
			MetaFactory.factory.getSingleton<IFormCreationListener>().create(FM, null);
			FM.Show();
            error = null;
	        for (int i = 0; i < CmdList.Count; i++) {
	            string sql = CmdList[i].ToString();
	            if (i == 0 && sql.StartsWith("--[DBO]--") && skipDBO) {
                    FM.Close();
                    return true;
                }

	            if (!RunScriptCmd(Conn, sql, out error)) {
	                FM.Close();
	                QueryCreator.ShowError(null, "Errore eseguendo lo script " +
	                                             sql,
	                    Conn.LastError, "");
	                return false;
	            }

	            FM.pBar.Increment(1);
	        }
	        FM.Close();
			return true;
		}

	    public static bool RUN_SCRIPT_NONSTOP(DataAccess Conn, StringBuilder script, string title) {
	        string error;
	        return RUN_SCRIPT_NONSTOP(Conn, script, title, false,out error);
	    }

	    public static bool RUN_SCRIPT_NONSTOP(DataAccess Conn, StringBuilder script, string title,bool skipDBO, out string error) {
			bool ok = true;
			ArrayList CmdList = DivideScript(script);
            error = null;
			FrmMeter FM= new FrmMeter();
			FM.labInfo.Text=title;
			FM.pBar.Maximum=CmdList.Count;
			MetaFactory.factory.getSingleton<IFormCreationListener>().create(FM, null);
			FM.Show();
	        for (int i = 0; i < CmdList.Count; i++) {
	            string sql = CmdList[i].ToString();
	            if (i == 0 && sql.StartsWith("--[DBO]--") && skipDBO) {
                    FM.Close();
                    return ok;
                }
	            if (!RunScriptCmd(Conn, sql, out error)) {
	                ok = false;
					FrmError f = new FrmError(title, Conn.LastError);
					MetaFactory.factory.getSingleton<IFormCreationListener>().create(f, FM);
					DialogResult dr = f.ShowDialog(FM);
	                if (dr != DialogResult.Yes) {
	                    FM.Close();
	                    return false;
	                }
	            }

	            FM.pBar.Increment(1);
	        }
	        FM.Close();
			return ok;
		}
		private static bool RUN_SCRIPT(DataAccess Conn, string script, bool skipDBO, out string error) {
			ArrayList CmdList = DivideScript(script);
            error = null;
			for (int i=0; i < CmdList.Count; i++) {
                string sql = CmdList[i].ToString();
			    if (i==0 && sql.StartsWith("--[DBO]--") && skipDBO) {
                    return true;
			    }
                if (!RunScriptCmd(Conn, sql, out error)) return false;
            }
			return true;
		}

		#endregion

		#region Script per alcune tabelle di sistema particolari

		private static string GetVersionScriptSQL() {
			return "IF NOT EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'["+C_TABVERSION+"]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)\n"+
				"BEGIN\n"+
				"CREATE TABLE [DBO]."+C_TABVERSION+" (\n"+
				"versionname varchar(10) NOT NULL,\n"+
				"description varchar(1000) NULL,\n"+
				"flagadmin char(1) NULL,\n"+
				"flagerror char(1) NULL,\n"+
				"scriptlist varchar(1000) NULL,\n"+
				"swversion varchar(10) NULL,\n"+
				"CONSTRAINT xpk"+C_TABVERSION+" PRIMARY KEY (versionname)\n"+
				")\n"+
				"END\n"+
				"GO\n"+
				"IF NOT EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'["+C_TABSCRIPT+"]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)\n"+
				"BEGIN\n"+
				"CREATE TABLE [DBO]."+C_TABSCRIPT+" (\n"+
				"scriptname varchar(50) NOT NULL,\n"+
				"versionname varchar(10) NOT NULL,\n"+
				"result varchar(1000) NULL,\n"+
				"sql text NULL,\n"+
				"CONSTRAINT xpk"+C_TABSCRIPT+" PRIMARY KEY (scriptname,versionname)\n"+
				")\n"+
				"END\n"+
				"GO\n"+
				"IF NOT EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'["+C_TABMENU+"]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)\n"+
				"BEGIN\n"+
				"CREATE TABLE [DBO]."+C_TABMENU+" (\n"+
				"versionname varchar(10) NOT NULL,\n"+
				"CONSTRAINT xpk"+C_TABMENU+" PRIMARY KEY (versionname)\n"+
				")\n"+
				"END\n"+
				"GO\n";
		}

		private static string GetCustomTablesScriptSQL() {
			string s = "IF NOT EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'[columntypes]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)\n"+
			"BEGIN\n"+
			"CREATE TABLE [DBO].columntypes (\n"+
			"tablename varchar(80) NOT NULL,\n"+
			"field varchar(80) NOT NULL,\n"+
			"iskey char(1) NOT NULL,\n"+
			"sqltype varchar(60) NOT NULL,\n"+
			"col_len int NULL,\n"+
			"col_precision int NULL,\n"+
			"col_scale int NULL,\n"+
			"systemtype varchar(80) NULL,\n"+
			"sqldeclaration varchar(80) NOT NULL,\n"+
			"allownull char(1) NOT NULL,\n"+
			"defaultvalue varchar(80) NULL,\n"+
			"format varchar(80) NULL,\n"+
			"denynull char(1) NOT NULL,\n"+
			"lastmodtimestamp datetime NULL,\n"+
			"lastmoduser varchar(30) NULL,\n"+
			"createuser varchar(30) NULL,\n"+
			"createtimestamp datetime NULL,\n"+
			"CONSTRAINT xpkcolumntypes PRIMARY KEY (tablename,\n"+
			"field\n"+
			")\n"+
			")\n"+
			"END\n"+
			"GO\n";

			s += "IF NOT EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'[customobject]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)\n"+
			"BEGIN\n"+
			"CREATE TABLE [DBO].customobject (\n"+
			"objectname varchar(50) NOT NULL,\n"+
			"description varchar(80) NULL,\n"+
			"isreal char(1) NOT NULL,\n"+
			"realtable varchar(50) NULL,\n"+
			"lastmodtimestamp datetime NULL,\n"+
			"lastmoduser varchar(30) NULL,\n"+
			"CONSTRAINT xpkcustomobject PRIMARY KEY (objectname\n"+
			")\n"+
			")\n"+
			"END\n"+
			"GO\n";

			s += "IF NOT exists(select * from sysobjects as T inner join syscolumns C on T.ID = C.ID where t.name like 'columntypes' and C.name = 'tablename')\n"+
			"ALTER TABLE columntypes ADD tablename varchar(80) NOT NULL\n"+
			"GO\n"+
			"IF exists(SELECT * FROM columntypes WHERE tablename = 'columntypes' AND field = 'tablename')\n"+
			"UPDATE columntypes set sqldeclaration = 'varchar(80)',denynull = 'S',systemtype = 'System.String',defaultvalue = '',format = '',lastmoduser = 'swmaster',col_precision = '',sqltype = 'varchar',allownull = 'N',createuser = '',col_scale = '',iskey = 'S',tablename = 'columntypes',field = 'tablename',col_len = '80' where tablename = 'columntypes' AND field = 'tablename'\n"+
			"ELSE\n"+
			"INSERT INTO columntypes (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('varchar(80)','S','System.String','','','swmaster','','varchar','N','','','S','columntypes','tablename','80')\n"+
			"GO\n"+
			"IF NOT exists(select * from sysobjects as T inner join syscolumns C on T.ID = C.ID where t.name like 'columntypes' and C.name = 'field')\n"+
			"ALTER TABLE columntypes ADD field varchar(80) NOT NULL\n"+
			"GO\n"+
			"IF exists(SELECT * FROM columntypes WHERE tablename = 'columntypes' AND field = 'field')\n"+
			"UPDATE columntypes set sqldeclaration = 'varchar(80)',denynull = 'S',systemtype = 'System.String',defaultvalue = '',format = '',lastmoduser = 'swmaster',col_precision = '',sqltype = 'varchar',allownull = 'N',createuser = '',col_scale = '',iskey = 'S',tablename = 'columntypes',field = 'field',col_len = '80' where tablename = 'columntypes' AND field = 'field'\n"+
			"ELSE\n"+
			"INSERT INTO columntypes (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('varchar(80)','S','System.String','','','swmaster','','varchar','N','','','S','columntypes','field','80')\n"+
			"GO\n"+
			"IF NOT exists(select * from sysobjects as T inner join syscolumns C on T.ID = C.ID where t.name like 'columntypes' and C.name = 'iskey')\n"+
			"ALTER TABLE columntypes ADD iskey char(1) NOT NULL\n"+
			"ELSE\n"+
			"ALTER TABLE columntypes ALTER COLUMN iskey char(1) NOT NULL\n"+
			"GO\n"+
			"IF exists(SELECT * FROM columntypes WHERE tablename = 'columntypes' AND field = 'iskey')\n"+
			"UPDATE columntypes set sqldeclaration = 'char(1)',denynull = 'S',systemtype = 'System.String',defaultvalue = '',format = '',lastmoduser = 'swmaster',col_precision = '',sqltype = 'char',allownull = 'N',createuser = '',col_scale = '',iskey = 'N',tablename = 'columntypes',field = 'iskey',col_len = '1' where tablename = 'columntypes' AND field = 'iskey'\n"+
			"ELSE\n"+
			"INSERT INTO columntypes (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('char(1)','S','System.String','','','swmaster','','char','N','','','N','columntypes','iskey','1')\n"+
			"GO\n"+
			"IF NOT exists(select * from sysobjects as T inner join syscolumns C on T.ID = C.ID where t.name like 'columntypes' and C.name = 'sqltype')\n"+
			"ALTER TABLE columntypes ADD sqltype varchar(60) NOT NULL\n"+
			"ELSE\n"+
			"ALTER TABLE columntypes ALTER COLUMN sqltype varchar(60) NOT NULL\n"+
			"GO\n"+
			"IF exists(SELECT * FROM columntypes WHERE tablename = 'columntypes' AND field = 'sqltype')\n"+
			"UPDATE columntypes set sqldeclaration = 'varchar(60)',denynull = 'S',systemtype = 'System.String',defaultvalue = '',format = '',lastmoduser = 'swmaster',col_precision = '',sqltype = 'varchar',allownull = 'N',createuser = '',col_scale = '',iskey = 'N',tablename = 'columntypes',field = 'sqltype',col_len = '60' where tablename = 'columntypes' AND field = 'sqltype'\n"+
			"ELSE\n"+
			"INSERT INTO columntypes (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('varchar(60)','S','System.String','','','swmaster','','varchar','N','','','N','columntypes','sqltype','60')\n"+
			"GO\n"+
			"IF NOT exists(select * from sysobjects as T inner join syscolumns C on T.ID = C.ID where t.name like 'columntypes' and C.name = 'col_len')\n"+
			"ALTER TABLE columntypes ADD col_len int NULL\n"+
			"ELSE\n"+
			"ALTER TABLE columntypes ALTER COLUMN col_len int NULL\n"+
			"GO\n"+
			"IF exists(SELECT * FROM columntypes WHERE tablename = 'columntypes' AND field = 'col_len')\n"+
			"UPDATE columntypes set sqldeclaration = 'int',denynull = 'N',systemtype = 'System.Int32',defaultvalue = '',format = '',lastmoduser = 'swmaster',col_precision = '',sqltype = 'int',allownull = 'S',createuser = '',col_scale = '',iskey = 'N',tablename = 'columntypes',field = 'col_len',col_len = '4' where tablename = 'columntypes' AND field = 'col_len'\n"+
			"ELSE\n"+
			"INSERT INTO columntypes (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('int','N','System.Int32','','','swmaster','','int','S','','','N','columntypes','col_len','4')\n"+
			"GO\n"+
			"IF NOT exists(select * from sysobjects as T inner join syscolumns C on T.ID = C.ID where t.name like 'columntypes' and C.name = 'col_precision')\n"+
			"ALTER TABLE columntypes ADD col_precision int NULL\n"+
			"ELSE\n"+
			"ALTER TABLE columntypes ALTER COLUMN col_precision int NULL\n"+
			"GO\n"+
			"IF exists(SELECT * FROM columntypes WHERE tablename = 'columntypes' AND field = 'col_precision')\n"+
			"UPDATE columntypes set sqldeclaration = 'int',denynull = 'N',systemtype = 'System.Int32',defaultvalue = '',format = '',lastmoduser = 'swmaster',col_precision = '',sqltype = 'int',allownull = 'S',createuser = '',col_scale = '',iskey = 'N',tablename = 'columntypes',field = 'col_precision',col_len = '4' where tablename = 'columntypes' AND field = 'col_precision'\n"+
			"ELSE\n"+
			"INSERT INTO columntypes (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('int','N','System.Int32','','','swmaster','','int','S','','','N','columntypes','col_precision','4')\n"+
			"GO\n"+
			"IF NOT exists(select * from sysobjects as T inner join syscolumns C on T.ID = C.ID where t.name like 'columntypes' and C.name = 'col_scale')\n"+
			"ALTER TABLE columntypes ADD col_scale int NULL\n"+
			"ELSE\n"+
			"ALTER TABLE columntypes ALTER COLUMN col_scale int NULL\n"+
			"GO\n"+
			"IF exists(SELECT * FROM columntypes WHERE tablename = 'columntypes' AND field = 'col_scale')\n"+
			"UPDATE columntypes set sqldeclaration = 'int',denynull = 'N',systemtype = 'System.Int32',defaultvalue = '',format = '',lastmoduser = 'swmaster',col_precision = '',sqltype = 'int',allownull = 'S',createuser = '',col_scale = '',iskey = 'N',tablename = 'columntypes',field = 'col_scale',col_len = '4' where tablename = 'columntypes' AND field = 'col_scale'\n"+
			"ELSE\n"+
			"INSERT INTO columntypes (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('int','N','System.Int32','','','swmaster','','int','S','','','N','columntypes','col_scale','4')\n"+
			"GO\n"+
			"IF NOT exists(select * from sysobjects as T inner join syscolumns C on T.ID = C.ID where t.name like 'columntypes' and C.name = 'systemtype')\n"+
			"ALTER TABLE columntypes ADD systemtype varchar(80) NULL\n"+
			"ELSE\n"+
			"ALTER TABLE columntypes ALTER COLUMN systemtype varchar(80) NULL\n"+
			"GO\n"+
			"IF exists(SELECT * FROM columntypes WHERE tablename = 'columntypes' AND field = 'systemtype')\n"+
			"UPDATE columntypes set sqldeclaration = 'varchar(80)',denynull = 'N',systemtype = 'System.String',defaultvalue = '',format = '',lastmoduser = 'swmaster',col_precision = '',sqltype = 'varchar',allownull = 'S',createuser = '',col_scale = '',iskey = 'N',tablename = 'columntypes',field = 'systemtype',col_len = '80' where tablename = 'columntypes' AND field = 'systemtype'\n"+
			"ELSE\n"+
			"INSERT INTO columntypes (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('varchar(80)','N','System.String','','','swmaster','','varchar','S','','','N','columntypes','systemtype','80')\n"+
			"GO\n"+
			"IF NOT exists(select * from sysobjects as T inner join syscolumns C on T.ID = C.ID where t.name like 'columntypes' and C.name = 'sqldeclaration')\n"+
			"ALTER TABLE columntypes ADD sqldeclaration varchar(80) NOT NULL\n"+
			"ELSE\n"+
			"ALTER TABLE columntypes ALTER COLUMN sqldeclaration varchar(80) NOT NULL\n"+
			"GO\n"+
			"IF exists(SELECT * FROM columntypes WHERE tablename = 'columntypes' AND field = 'sqldeclaration')\n"+
			"UPDATE columntypes set sqldeclaration = 'varchar(80)',denynull = 'S',systemtype = 'System.String',defaultvalue = '',format = '',lastmoduser = 'swmaster',col_precision = '',sqltype = 'varchar',allownull = 'N',createuser = '',col_scale = '',iskey = 'N',tablename = 'columntypes',field = 'sqldeclaration',col_len = '80' where tablename = 'columntypes' AND field = 'sqldeclaration'\n"+
			"ELSE\n"+
			"INSERT INTO columntypes (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('varchar(80)','S','System.String','','','swmaster','','varchar','N','','','N','columntypes','sqldeclaration','80')\n"+
			"GO\n"+
			"IF NOT exists(select * from sysobjects as T inner join syscolumns C on T.ID = C.ID where t.name like 'columntypes' and C.name = 'allownull')\n"+
			"ALTER TABLE columntypes ADD allownull char(1) NOT NULL\n"+
			"ELSE\n"+
			"ALTER TABLE columntypes ALTER COLUMN allownull char(1) NOT NULL\n"+
			"GO\n"+
			"IF exists(SELECT * FROM columntypes WHERE tablename = 'columntypes' AND field = 'allownull')\n"+
			"UPDATE columntypes set sqldeclaration = 'char(1)',denynull = 'S',systemtype = 'System.String',defaultvalue = '',format = '',lastmoduser = 'swmaster',col_precision = '',sqltype = 'char',allownull = 'N',createuser = '',col_scale = '',iskey = 'N',tablename = 'columntypes',field = 'allownull',col_len = '1' where tablename = 'columntypes' AND field = 'allownull'\n"+
			"ELSE\n"+
			"INSERT INTO columntypes (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('char(1)','S','System.String','','','swmaster','','char','N','','','N','columntypes','allownull','1')\n"+
			"GO\n"+
			"IF NOT exists(select * from sysobjects as T inner join syscolumns C on T.ID = C.ID where t.name like 'columntypes' and C.name = 'defaultvalue')\n"+
			"ALTER TABLE columntypes ADD defaultvalue varchar(80) NULL\n"+
			"ELSE\n"+
			"ALTER TABLE columntypes ALTER COLUMN defaultvalue varchar(80) NULL\n"+
			"GO\n"+
			"IF exists(SELECT * FROM columntypes WHERE tablename = 'columntypes' AND field = 'defaultvalue')\n"+
			"UPDATE columntypes set sqldeclaration = 'varchar(80)',denynull = 'N',systemtype = 'System.String',defaultvalue = '',format = '',lastmoduser = 'swmaster',col_precision = '',sqltype = 'varchar',allownull = 'S',createuser = '',col_scale = '',iskey = 'N',tablename = 'columntypes',field = 'defaultvalue',col_len = '80' where tablename = 'columntypes' AND field = 'defaultvalue'\n"+
			"ELSE\n"+
			"INSERT INTO columntypes (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('varchar(80)','N','System.String','','','swmaster','','varchar','S','','','N','columntypes','defaultvalue','80')\n"+
			"GO\n"+
			"IF NOT exists(select * from sysobjects as T inner join syscolumns C on T.ID = C.ID where t.name like 'columntypes' and C.name = 'format')\n"+
			"ALTER TABLE columntypes ADD format varchar(80) NULL\n"+
			"ELSE\n"+
			"ALTER TABLE columntypes ALTER COLUMN format varchar(80) NULL\n"+
			"GO\n"+
			"IF exists(SELECT * FROM columntypes WHERE tablename = 'columntypes' AND field = 'format')\n"+
			"UPDATE columntypes set sqldeclaration = 'varchar(80)',denynull = 'N',systemtype = 'System.String',defaultvalue = '',format = '',lastmoduser = 'swmaster',col_precision = '',sqltype = 'varchar',allownull = 'S',createuser = '',col_scale = '',iskey = 'N',tablename = 'columntypes',field = 'format',col_len = '80' where tablename = 'columntypes' AND field = 'format'\n"+
			"ELSE\n"+
			"INSERT INTO columntypes (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('varchar(80)','N','System.String','','','swmaster','','varchar','S','','','N','columntypes','format','80')\n"+
			"GO\n"+
			"IF NOT exists(select * from sysobjects as T inner join syscolumns C on T.ID = C.ID where t.name like 'columntypes' and C.name = 'denynull')\n"+
			"ALTER TABLE columntypes ADD denynull char(1) NOT NULL\n"+
			"ELSE\n"+
			"ALTER TABLE columntypes ALTER COLUMN denynull char(1) NOT NULL\n"+
			"GO\n"+
			"IF exists(SELECT * FROM columntypes WHERE tablename = 'columntypes' AND field = 'denynull')\n"+
			"UPDATE columntypes set sqldeclaration = 'char(1)',denynull = 'S',systemtype = 'System.String',defaultvalue = '',format = '',lastmoduser = 'swmaster',col_precision = '',sqltype = 'char',allownull = 'N',createuser = '',col_scale = '',iskey = 'N',tablename = 'columntypes',field = 'denynull',col_len = '1' where tablename = 'columntypes' AND field = 'denynull'\n"+
			"ELSE\n"+
			"INSERT INTO columntypes (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('char(1)','S','System.String','','','swmaster','','char','N','','','N','columntypes','denynull','1')\n"+
			"GO\n"+
			"IF NOT exists(select * from sysobjects as T inner join syscolumns C on T.ID = C.ID where t.name like 'columntypes' and C.name = 'lastmodtimestamp')\n"+
			"ALTER TABLE columntypes ADD lastmodtimestamp datetime NULL\n"+
			"ELSE\n"+
			"ALTER TABLE columntypes ALTER COLUMN lastmodtimestamp datetime NULL\n"+
			"GO\n"+
			"IF exists(SELECT * FROM columntypes WHERE tablename = 'columntypes' AND field = 'lastmodtimestamp')\n"+
			"UPDATE columntypes set sqldeclaration = 'datetime',denynull = 'N',systemtype = 'System.DateTime',defaultvalue = '',format = '',lastmoduser = 'swmaster',col_precision = '',sqltype = 'datetime',allownull = 'S',createuser = '',col_scale = '',iskey = 'N',tablename = 'columntypes',field = 'lastmodtimestamp',col_len = '8' where tablename = 'columntypes' AND field = 'lastmodtimestamp'\n"+
			"ELSE\n"+
			"INSERT INTO columntypes (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('datetime','N','System.DateTime','','','swmaster','','datetime','S','','','N','columntypes','lastmodtimestamp','8')\n"+
			"GO\n"+
			"IF NOT exists(select * from sysobjects as T inner join syscolumns C on T.ID = C.ID where t.name like 'columntypes' and C.name = 'lastmoduser')\n"+
			"ALTER TABLE columntypes ADD lastmoduser varchar(30) NULL\n"+
			"ELSE\n"+
			"ALTER TABLE columntypes ALTER COLUMN lastmoduser varchar(30) NULL\n"+
			"GO\n"+
			"IF exists(SELECT * FROM columntypes WHERE tablename = 'columntypes' AND field = 'lastmoduser')\n"+
			"UPDATE columntypes set sqldeclaration = 'varchar(30)',denynull = 'N',systemtype = 'System.String',defaultvalue = '',format = '',lastmoduser = 'swmaster',col_precision = '',sqltype = 'varchar',allownull = 'S',createuser = '',col_scale = '',iskey = 'N',tablename = 'columntypes',field = 'lastmoduser',col_len = '30' where tablename = 'columntypes' AND field = 'lastmoduser'\n"+
			"ELSE\n"+
			"INSERT INTO columntypes (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('varchar(30)','N','System.String','','','swmaster','','varchar','S','','','N','columntypes','lastmoduser','30')\n"+
			"GO\n"+
			"IF NOT exists(select * from sysobjects as T inner join syscolumns C on T.ID = C.ID where t.name like 'columntypes' and C.name = 'createuser')\n"+
			"ALTER TABLE columntypes ADD createuser varchar(30) NULL\n"+
			"ELSE\n"+
			"ALTER TABLE columntypes ALTER COLUMN createuser varchar(30) NULL\n"+
			"GO\n"+
			"IF exists(SELECT * FROM columntypes WHERE tablename = 'columntypes' AND field = 'createuser')\n"+
			"UPDATE columntypes set sqldeclaration = 'varchar(30)',denynull = 'N',systemtype = 'System.String',defaultvalue = '',format = '',lastmoduser = 'swmaster',col_precision = '',sqltype = 'varchar',allownull = 'S',createuser = '',col_scale = '',iskey = 'N',tablename = 'columntypes',field = 'createuser',col_len = '30' where tablename = 'columntypes' AND field = 'createuser'\n"+
			"ELSE\n"+
			"INSERT INTO columntypes (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('varchar(30)','N','System.String','','','swmaster','','varchar','S','','','N','columntypes','createuser','30')\n"+
			"GO\n"+
			"IF NOT exists(select * from sysobjects as T inner join syscolumns C on T.ID = C.ID where t.name like 'columntypes' and C.name = 'createtimestamp')\n"+
			"ALTER TABLE columntypes ADD createtimestamp datetime NULL\n"+
			"ELSE\n"+
			"ALTER TABLE columntypes ALTER COLUMN createtimestamp datetime NULL\n"+
			"GO\n"+
			"IF exists(SELECT * FROM columntypes WHERE tablename = 'columntypes' AND field = 'createtimestamp')\n"+
			"UPDATE columntypes set sqldeclaration = 'datetime',denynull = 'N',systemtype = 'System.DateTime',defaultvalue = '',format = '',lastmoduser = 'swmaster',col_precision = '',sqltype = 'datetime',allownull = 'S',createuser = '',col_scale = '',iskey = 'N',tablename = 'columntypes',field = 'createtimestamp',col_len = '8' where tablename = 'columntypes' AND field = 'createtimestamp'\n"+
			"ELSE\n"+
			"INSERT INTO columntypes (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('datetime','N','System.DateTime','','','swmaster','','datetime','S','','','N','columntypes','createtimestamp','8')\n"+
			"GO\n"+
			"if exists(select * from customobject where objectname = 'columntypes')\n"+
			"update customobject set isreal = 'S' where objectname = 'columntypes'\n"+
			"else\n"+
			"insert into customobject (objectname, isreal) values('columntypes', 'S')\n"+
			"GO\n";

			s += "IF NOT exists(select * from sysobjects as T inner join syscolumns C on T.ID = C.ID where t.name like 'customobject' and C.name = 'objectname')\n"+
			"ALTER TABLE customobject ADD objectname varchar(50) NOT NULL\n"+
			"GO\n"+
			"IF exists(SELECT * FROM columntypes WHERE tablename = 'customobject' AND field = 'objectname')\n"+
			"UPDATE columntypes set sqldeclaration = 'varchar(50)',denynull = 'S',systemtype = 'System.String',defaultvalue = '',format = '',lastmoduser = 'swmaster',col_precision = '',sqltype = 'varchar',allownull = 'N',createuser = '',col_scale = '',iskey = 'S',tablename = 'customobject',field = 'objectname',col_len = '50' where tablename = 'customobject' AND field = 'objectname'\n"+
			"ELSE\n"+
			"INSERT INTO columntypes (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('varchar(50)','S','System.String','','','swmaster','','varchar','N','','','S','customobject','objectname','50')\n"+
			"GO\n"+
			"IF NOT exists(select * from sysobjects as T inner join syscolumns C on T.ID = C.ID where t.name like 'customobject' and C.name = 'description')\n"+
			"ALTER TABLE customobject ADD description varchar(80) NULL\n"+
			"ELSE\n"+
			"ALTER TABLE customobject ALTER COLUMN description varchar(80) NULL\n"+
			"GO\n"+
			"IF exists(SELECT * FROM columntypes WHERE tablename = 'customobject' AND field = 'description')\n"+
			"UPDATE columntypes set sqldeclaration = 'varchar(80)',denynull = 'N',systemtype = 'System.String',defaultvalue = '',format = '',lastmoduser = 'swmaster',col_precision = '',sqltype = 'varchar',allownull = 'S',createuser = '',col_scale = '',iskey = 'N',tablename = 'customobject',field = 'description',col_len = '80' where tablename = 'customobject' AND field = 'description'\n"+
			"ELSE\n"+
			"INSERT INTO columntypes (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('varchar(80)','N','System.String','','','swmaster','','varchar','S','','','N','customobject','description','80')\n"+
			"GO\n"+
			"IF NOT exists(select * from sysobjects as T inner join syscolumns C on T.ID = C.ID where t.name like 'customobject' and C.name = 'isreal')\n"+
			"ALTER TABLE customobject ADD isreal char(1) NOT NULL\n"+
			"ELSE\n"+
			"ALTER TABLE customobject ALTER COLUMN isreal char(1) NOT NULL\n"+
			"GO\n"+
			"IF exists(SELECT * FROM columntypes WHERE tablename = 'customobject' AND field = 'isreal')\n"+
			"UPDATE columntypes set sqldeclaration = 'char(1)',denynull = 'S',systemtype = 'System.String',defaultvalue = '',format = '',lastmoduser = 'swmaster',col_precision = '',sqltype = 'char',allownull = 'N',createuser = '',col_scale = '',iskey = 'N',tablename = 'customobject',field = 'isreal',col_len = '1' where tablename = 'customobject' AND field = 'isreal'\n"+
			"ELSE\n"+
			"INSERT INTO columntypes (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('char(1)','S','System.String','','','swmaster','','char','N','','','N','customobject','isreal','1')\n"+
			"GO\n"+
			"IF NOT exists(select * from sysobjects as T inner join syscolumns C on T.ID = C.ID where t.name like 'customobject' and C.name = 'realtable')\n"+
			"ALTER TABLE customobject ADD realtable varchar(50) NULL\n"+
			"ELSE\n"+
			"ALTER TABLE customobject ALTER COLUMN realtable varchar(50) NULL\n"+
			"GO\n"+
			"IF exists(SELECT * FROM columntypes WHERE tablename = 'customobject' AND field = 'realtable')\n"+
			"UPDATE columntypes set sqldeclaration = 'varchar(50)',denynull = 'N',systemtype = 'System.String',defaultvalue = '',format = '',lastmoduser = 'swmaster',col_precision = '',sqltype = 'varchar',allownull = 'S',createuser = '',col_scale = '',iskey = 'N',tablename = 'customobject',field = 'realtable',col_len = '50' where tablename = 'customobject' AND field = 'realtable'\n"+
			"ELSE\n"+
			"INSERT INTO columntypes (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('varchar(50)','N','System.String','','','swmaster','','varchar','S','','','N','customobject','realtable','50')\n"+
			"GO\n"+
			"IF NOT exists(select * from sysobjects as T inner join syscolumns C on T.ID = C.ID where t.name like 'customobject' and C.name = 'lastmodtimestamp')\n"+
			"ALTER TABLE customobject ADD lastmodtimestamp datetime NULL\n"+
			"ELSE\n"+
			"ALTER TABLE customobject ALTER COLUMN lastmodtimestamp datetime NULL\n"+
			"GO\n"+
			"IF exists(SELECT * FROM columntypes WHERE tablename = 'customobject' AND field = 'lastmodtimestamp')\n"+
			"UPDATE columntypes set sqldeclaration = 'datetime',denynull = 'N',systemtype = 'System.DateTime',defaultvalue = '',format = '',lastmoduser = 'swmaster',col_precision = '',sqltype = 'datetime',allownull = 'S',createuser = '',col_scale = '',iskey = 'N',tablename = 'customobject',field = 'lastmodtimestamp',col_len = '8' where tablename = 'customobject' AND field = 'lastmodtimestamp'\n"+
			"ELSE\n"+
			"INSERT INTO columntypes (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('datetime','N','System.DateTime','','','swmaster','','datetime','S','','','N','customobject','lastmodtimestamp','8')\n"+
			"GO\n"+
			"IF NOT exists(select * from sysobjects as T inner join syscolumns C on T.ID = C.ID where t.name like 'customobject' and C.name = 'lastmoduser')\n"+
			"ALTER TABLE customobject ADD lastmoduser varchar(30) NULL\n"+
			"ELSE\n"+
			"ALTER TABLE customobject ALTER COLUMN lastmoduser varchar(30) NULL\n"+
			"GO\n"+
			"IF exists(SELECT * FROM columntypes WHERE tablename = 'customobject' AND field = 'lastmoduser')\n"+
			"UPDATE columntypes set sqldeclaration = 'varchar(30)',denynull = 'N',systemtype = 'System.String',defaultvalue = '',format = '',lastmoduser = 'swmaster',col_precision = '',sqltype = 'varchar',allownull = 'S',createuser = '',col_scale = '',iskey = 'N',tablename = 'customobject',field = 'lastmoduser',col_len = '30' where tablename = 'customobject' AND field = 'lastmoduser'\n"+
			"ELSE\n"+
			"INSERT INTO columntypes (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('varchar(30)','N','System.String','','','swmaster','','varchar','S','','','N','customobject','lastmoduser','30')\n"+
			"GO\n"+
			"if exists(select * from customobject where objectname = 'customobject')\n"+
			"update customobject set isreal = 'S' where objectname = 'customobject'\n"+
			"else\n"+
			"insert into customobject (objectname, isreal) values('customobject', 'S')\n"+
			"GO\n\n";

			s += "IF NOT EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'[customtablestructure]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)\n"+
			"BEGIN\n"+
			"CREATE TABLE [DBO].customtablestructure (\n"+
			"objectname varchar(50) NOT NULL,\n"+
			"colname varchar(50) NOT NULL,\n"+
			"autoincrement char(1) NOT NULL,\n"+
			"step int NULL,\n"+
			"prefixfieldname varchar(50) NULL,\n"+
			"middleconst varchar(50) NULL,\n"+
			"length int NOT NULL,\n"+
			"linear char(1) NOT NULL,\n"+
			"selector char(1) NOT NULL,\n"+
			"lastmodtimestamp datetime NULL,\n"+
			"lastmoduser varchar(30) NULL,\n"+
			"CONSTRAINT xpkcustomtablestructure PRIMARY KEY (objectname,\n"+
			"colname\n"+
			")\n"+
			")\n"+
			"END\n"+
			"GO\n"+
			"IF NOT exists(select * from sysobjects as T inner join syscolumns C on T.ID = C.ID where t.name like 'customtablestructure' and C.name = 'objectname')\n"+
			"ALTER TABLE customtablestructure ADD objectname varchar(50) NOT NULL\n"+
			"GO\n"+
			"IF exists(SELECT * FROM columntypes WHERE tablename = 'customtablestructure' AND field = 'objectname')\n"+
			"UPDATE columntypes set sqldeclaration = 'varchar(50)',denynull = 'S',systemtype = 'System.String',defaultvalue = '',format = '',lastmoduser = 'swmaster',col_precision = '',sqltype = 'varchar',allownull = 'N',createuser = '',col_scale = '',iskey = 'S',tablename = 'customtablestructure',field = 'objectname',col_len = '50' where tablename = 'customtablestructure' AND field = 'objectname'\n"+
			"ELSE\n"+
			"INSERT INTO columntypes (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('varchar(50)','S','System.String','','','swmaster','','varchar','N','','','S','customtablestructure','objectname','50')\n"+
			"GO\n"+
			"IF NOT exists(select * from sysobjects as T inner join syscolumns C on T.ID = C.ID where t.name like 'customtablestructure' and C.name = 'colname')\n"+
			"ALTER TABLE customtablestructure ADD colname varchar(50) NOT NULL\n"+
			"GO\n"+
			"IF exists(SELECT * FROM columntypes WHERE tablename = 'customtablestructure' AND field = 'colname')\n"+
			"UPDATE columntypes set sqldeclaration = 'varchar(50)',denynull = 'S',systemtype = 'System.String',defaultvalue = '',format = '',lastmoduser = 'swmaster',col_precision = '',sqltype = 'varchar',allownull = 'N',createuser = '',col_scale = '',iskey = 'S',tablename = 'customtablestructure',field = 'colname',col_len = '50' where tablename = 'customtablestructure' AND field = 'colname'\n"+
			"ELSE\n"+
			"INSERT INTO columntypes (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('varchar(50)','S','System.String','','','swmaster','','varchar','N','','','S','customtablestructure','colname','50')\n"+
			"GO\n"+
			"IF NOT exists(select * from sysobjects as T inner join syscolumns C on T.ID = C.ID where t.name like 'customtablestructure' and C.name = 'autoincrement')\n"+
			"ALTER TABLE customtablestructure ADD autoincrement char(1) NOT NULL\n"+
			"ELSE\n"+
			"ALTER TABLE customtablestructure ALTER COLUMN autoincrement char(1) NOT NULL\n"+
			"GO\n"+
			"IF exists(SELECT * FROM columntypes WHERE tablename = 'customtablestructure' AND field = 'autoincrement')\n"+
			"UPDATE columntypes set sqldeclaration = 'char(1)',denynull = 'S',systemtype = 'System.String',defaultvalue = '',format = '',lastmoduser = 'swmaster',col_precision = '',sqltype = 'char',allownull = 'N',createuser = '',col_scale = '',iskey = 'N',tablename = 'customtablestructure',field = 'autoincrement',col_len = '1' where tablename = 'customtablestructure' AND field = 'autoincrement'\n"+
			"ELSE\n"+
			"INSERT INTO columntypes (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('char(1)','S','System.String','','','swmaster','','char','N','','','N','customtablestructure','autoincrement','1')\n"+
			"GO\n"+
			"IF NOT exists(select * from sysobjects as T inner join syscolumns C on T.ID = C.ID where t.name like 'customtablestructure' and C.name = 'step')\n"+
			"ALTER TABLE customtablestructure ADD step int NULL\n"+
			"ELSE\n"+
			"ALTER TABLE customtablestructure ALTER COLUMN step int NULL\n"+
			"GO\n"+
			"IF exists(SELECT * FROM columntypes WHERE tablename = 'customtablestructure' AND field = 'step')\n"+
			"UPDATE columntypes set sqldeclaration = 'int',denynull = 'N',systemtype = 'System.Int32',defaultvalue = '',format = '',lastmoduser = 'swmaster',col_precision = '',sqltype = 'int',allownull = 'S',createuser = '',col_scale = '',iskey = 'N',tablename = 'customtablestructure',field = 'step',col_len = '4' where tablename = 'customtablestructure' AND field = 'step'\n"+
			"ELSE\n"+
			"INSERT INTO columntypes (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('int','N','System.Int32','','','swmaster','','int','S','','','N','customtablestructure','step','4')\n"+
			"GO\n"+
			"IF NOT exists(select * from sysobjects as T inner join syscolumns C on T.ID = C.ID where t.name like 'customtablestructure' and C.name = 'prefixfieldname')\n"+
			"ALTER TABLE customtablestructure ADD prefixfieldname varchar(50) NULL\n"+
			"ELSE\n"+
			"ALTER TABLE customtablestructure ALTER COLUMN prefixfieldname varchar(50) NULL\n"+
			"GO\n"+
			"IF exists(SELECT * FROM columntypes WHERE tablename = 'customtablestructure' AND field = 'prefixfieldname')\n"+
			"UPDATE columntypes set sqldeclaration = 'varchar(50)',denynull = 'N',systemtype = 'System.String',defaultvalue = '',format = '',lastmoduser = 'swmaster',col_precision = '',sqltype = 'varchar',allownull = 'S',createuser = '',col_scale = '',iskey = 'N',tablename = 'customtablestructure',field = 'prefixfieldname',col_len = '50' where tablename = 'customtablestructure' AND field = 'prefixfieldname'\n"+
			"ELSE\n"+
			"INSERT INTO columntypes (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('varchar(50)','N','System.String','','','swmaster','','varchar','S','','','N','customtablestructure','prefixfieldname','50')\n"+
			"GO\n"+
			"IF NOT exists(select * from sysobjects as T inner join syscolumns C on T.ID = C.ID where t.name like 'customtablestructure' and C.name = 'middleconst')\n"+
			"ALTER TABLE customtablestructure ADD middleconst varchar(50) NULL\n"+
			"ELSE\n"+
			"ALTER TABLE customtablestructure ALTER COLUMN middleconst varchar(50) NULL\n"+
			"GO\n"+
			"IF exists(SELECT * FROM columntypes WHERE tablename = 'customtablestructure' AND field = 'middleconst')\n"+
			"UPDATE columntypes set sqldeclaration = 'varchar(50)',denynull = 'N',systemtype = 'System.String',defaultvalue = '',format = '',lastmoduser = 'swmaster',col_precision = '',sqltype = 'varchar',allownull = 'S',createuser = '',col_scale = '',iskey = 'N',tablename = 'customtablestructure',field = 'middleconst',col_len = '50' where tablename = 'customtablestructure' AND field = 'middleconst'\n"+
			"ELSE\n"+
			"INSERT INTO columntypes (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('varchar(50)','N','System.String','','','swmaster','','varchar','S','','','N','customtablestructure','middleconst','50')\n"+
			"GO\n"+
			"IF NOT exists(select * from sysobjects as T inner join syscolumns C on T.ID = C.ID where t.name like 'customtablestructure' and C.name = 'length')\n"+
			"ALTER TABLE customtablestructure ADD length int NOT NULL\n"+
			"ELSE\n"+
			"ALTER TABLE customtablestructure ALTER COLUMN length int NOT NULL\n"+
			"GO\n"+
			"IF exists(SELECT * FROM columntypes WHERE tablename = 'customtablestructure' AND field = 'length')\n"+
			"UPDATE columntypes set sqldeclaration = 'int',denynull = 'S',systemtype = 'System.Int32',defaultvalue = '7',format = '',lastmoduser = 'swmaster',col_precision = '',sqltype = 'int',allownull = 'N',createuser = '',col_scale = '',iskey = 'N',tablename = 'customtablestructure',field = 'length',col_len = '4' where tablename = 'customtablestructure' AND field = 'length'\n"+
			"ELSE\n"+
			"INSERT INTO columntypes (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('int','S','System.Int32','7','','swmaster','','int','N','','','N','customtablestructure','length','4')\n"+
			"GO\n"+
			"IF NOT exists(select * from sysobjects as T inner join syscolumns C on T.ID = C.ID where t.name like 'customtablestructure' and C.name = 'linear')\n"+
			"ALTER TABLE customtablestructure ADD linear char(1) NOT NULL\n"+
			"ELSE\n"+
			"ALTER TABLE customtablestructure ALTER COLUMN linear char(1) NOT NULL\n"+
			"GO\n"+
			"IF exists(SELECT * FROM columntypes WHERE tablename = 'customtablestructure' AND field = 'linear')\n"+
			"UPDATE columntypes set sqldeclaration = 'char(1)',denynull = 'S',systemtype = 'System.String',defaultvalue = '',format = '',lastmoduser = 'swmaster',col_precision = '',sqltype = 'char',allownull = 'N',createuser = '',col_scale = '',iskey = 'N',tablename = 'customtablestructure',field = 'linear',col_len = '1' where tablename = 'customtablestructure' AND field = 'linear'\n"+
			"ELSE\n"+
			"INSERT INTO columntypes (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('char(1)','S','System.String','','','swmaster','','char','N','','','N','customtablestructure','linear','1')\n"+
			"GO\n"+
			"IF NOT exists(select * from sysobjects as T inner join syscolumns C on T.ID = C.ID where t.name like 'customtablestructure' and C.name = 'selector')\n"+
			"ALTER TABLE customtablestructure ADD selector char(1) NOT NULL\n"+
			"ELSE\n"+
			"ALTER TABLE customtablestructure ALTER COLUMN selector char(1) NOT NULL\n"+
			"GO\n"+
			"IF exists(SELECT * FROM columntypes WHERE tablename = 'customtablestructure' AND field = 'selector')\n"+
			"UPDATE columntypes set sqldeclaration = 'char(1)',denynull = 'S',systemtype = 'System.String',defaultvalue = '',format = '',lastmoduser = 'swmaster',col_precision = '',sqltype = 'char',allownull = 'N',createuser = '',col_scale = '',iskey = 'N',tablename = 'customtablestructure',field = 'selector',col_len = '1' where tablename = 'customtablestructure' AND field = 'selector'\n"+
			"ELSE\n"+
			"INSERT INTO columntypes (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('char(1)','S','System.String','','','swmaster','','char','N','','','N','customtablestructure','selector','1')\n"+
			"GO\n"+
			"IF NOT exists(select * from sysobjects as T inner join syscolumns C on T.ID = C.ID where t.name like 'customtablestructure' and C.name = 'lastmodtimestamp')\n"+
			"ALTER TABLE customtablestructure ADD lastmodtimestamp datetime NULL\n"+
			"ELSE\n"+
			"ALTER TABLE customtablestructure ALTER COLUMN lastmodtimestamp datetime NULL\n"+
			"GO\n"+
			"IF exists(SELECT * FROM columntypes WHERE tablename = 'customtablestructure' AND field = 'lastmodtimestamp')\n"+
			"UPDATE columntypes set sqldeclaration = 'datetime',denynull = 'N',systemtype = 'System.DateTime',defaultvalue = '',format = '',lastmoduser = 'swmaster',col_precision = '',sqltype = 'datetime',allownull = 'S',createuser = '',col_scale = '',iskey = 'N',tablename = 'customtablestructure',field = 'lastmodtimestamp',col_len = '8' where tablename = 'customtablestructure' AND field = 'lastmodtimestamp'\n"+
			"ELSE\n"+
			"INSERT INTO columntypes (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('datetime','N','System.DateTime','','','swmaster','','datetime','S','','','N','customtablestructure','lastmodtimestamp','8')\n"+
			"GO\n"+
			"IF NOT exists(select * from sysobjects as T inner join syscolumns C on T.ID = C.ID where t.name like 'customtablestructure' and C.name = 'lastmoduser')\n"+
			"ALTER TABLE customtablestructure ADD lastmoduser varchar(30) NULL\n"+
			"ELSE\n"+
			"ALTER TABLE customtablestructure ALTER COLUMN lastmoduser varchar(30) NULL\n"+
			"GO\n"+
			"IF exists(SELECT * FROM columntypes WHERE tablename = 'customtablestructure' AND field = 'lastmoduser')\n"+
			"UPDATE columntypes set sqldeclaration = 'varchar(30)',denynull = 'N',systemtype = 'System.String',defaultvalue = '',format = '',lastmoduser = 'swmaster',col_precision = '',sqltype = 'varchar',allownull = 'S',createuser = '',col_scale = '',iskey = 'N',tablename = 'customtablestructure',field = 'lastmoduser',col_len = '30' where tablename = 'customtablestructure' AND field = 'lastmoduser'\n"+
			"ELSE\n"+
			"INSERT INTO columntypes (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('varchar(30)','N','System.String','','','swmaster','','varchar','S','','','N','customtablestructure','lastmoduser','30')\n"+
			"GO\n"+
			"if exists(select * from customobject where objectname = 'customtablestructure')\n"+
			"update customobject set isreal = 'S' where objectname = 'customtablestructure'\n"+
			"else\n"+
			"insert into customobject (objectname, isreal) values('customtablestructure', 'S')\n"+
			"GO\n";
		
			return s;
		}

		#endregion


	}

	public class XZip {

      

		#region Add files method

		public static void AddFiles(string zipFilename, 
			string sourceFolder, 
			string fileMask, 
			bool replaceFiles,
			bool recursive) {
		    if (sourceFolder.Length == 0) sourceFolder = AppDomain.CurrentDomain.BaseDirectory;

		    string originalFileMask = fileMask;
		    if (fileMask.Contains("\\")) {
		        sourceFolder=Path.Combine(sourceFolder, fileMask.Substring(0, fileMask.LastIndexOf("\\")));
		        fileMask = fileMask.Substring(fileMask.LastIndexOf("\\")+1);

		    }
		
			File.SetAttributes(Path.Combine(sourceFolder , fileMask), FileAttributes.Normal);
			DiskFile zipFile = new DiskFile(zipFilename);
			if (!zipFile.Exists) zipFile.Create();
			ZipArchive zip = new ZipArchive(zipFile);
			zip.DefaultCompressionMethod = CompressionMethod.Deflated;
			DiskFolder source = new DiskFolder(sourceFolder);
			source.CopyFilesTo(zip, recursive, replaceFiles, fileMask );      
		}

		#endregion

		#region Extract files method

		public static void ExtractFiles(string zipFilename,
			string destFolder, 
			string fileMask,
			bool replaceFiles,
			bool recursive) {

			DiskFile zipFile = new DiskFile(zipFilename);
			ZipArchive zip = new ZipArchive(zipFile);
			DiskFolder destinationFolder = new DiskFolder(destFolder);

			string destination = destFolder + "\\" + fileMask;
			if (File.Exists(destination) &&
				(File.GetAttributes(destination)!= System.IO.FileAttributes.Archive))
			{
				try
				{
					File.SetAttributes(destination,System.IO.FileAttributes.Archive);
				}
				catch(Exception e)
				{
					Console.WriteLine("Errore sul file locale: " + destination + "\n" + e.Message);
				}
			}
			zip.CopyFilesTo(destinationFolder, recursive, replaceFiles, fileMask);
		}

		#endregion
	}

	public class Costanti {
		public const string C_SWVERSIONFILENAME = "versionesw.txt";
        public const string C_SWVERSIONFILENAME4 = "versionesw4.txt";
        public const string C_MENUVERSIONFILENAME = "versionemenu.txt";
		public const string C_SITENOAVAILABLE = "Indirizzi non raggiungibili";
		public const string C_REPORTVERSIONFILENAME = "versionereport.txt";
        public const string C_LISTASITIWEB = "easy2siti.txt";
        public const string C_LISTASITIWEBSERVICES = "easyservicessiti.txt";
    }
}
