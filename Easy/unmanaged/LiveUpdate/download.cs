
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


namespace LiveUpdate{//LiveUpdate//

	// TaskInfo contiene i dati che caratterizzano un'istanza WebClient
	internal class TaskInfo {
		//private
		public string m_Address=null;
		//private string m_CachePath=null;
		private Http m_Http=null;
		//public
		public WebClient webSite=null;
        public long timediff=long.MaxValue;

		public TaskInfo(string address,  Http http) {
			m_Address=address;
			m_Http=http;
		}

		/// <summary>
		/// metodo richiamato dal thread per la stima dei tempi
		/// </summary>
		public void Process() {
			try {
				if (m_Http==null) return;
                if (m_Address == null) return;
                crono C = new crono(m_Address);
				//DateTime adesso=DateTime.Now;
				//timebegin=new TimeSpan(0,0,adesso.Minute,adesso.Second,adesso.Millisecond);
				this.webSite=m_Http.GetWebInstance(m_Address);
                long save=  C.GetDuration();
                if (this.webSite == null) {
					m_Http.PrintLog("Process() - Indirizzo scartato ["+m_Address+"]", true);
					return;
				}
				this.timediff=save;
				//m_Http.PrintLog("Process() - Indirizzo accettato ["+m_Address+"]", false);
			}
			catch (Exception E) {
				m_Http.PrintLog("TaskInfo.Process() - Errore["+E.Message+"]");
			}
		}
	}

	/// <summary>
	/// classe che memorizza thread e timer necessaria per stoppare entrambi i processi
	/// </summary>
	internal class TaskTimer {
		public Thread threadHandle=null;
		public System.Threading.Timer timer=null;
	}

	/// <summary>
	/// Classe (Web client) utilizzata per il download dei file via http
	/// </summary>
	public class Http {
		WebClient client;
		public string cachepath;
		public string RemoteDir;
		private string m_LastError=null;

		enum eTipoSito {
			WEB,
			NETBIOS,
			UNKNOWN
		};
		eTipoSito WebSite = eTipoSito.UNKNOWN;

		
		/// <param name="W">tipo eccezione</param>
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
		/// <param name="E">tipo eccezione</param>
		/// <param name="header">True se visibile "Tentativo..."</param>
		private static string GetExceptionMsg(Exception E, bool header) {
			string tipo="Tentativo di download fallito (Exception)";
			return (header?tipo:"")+"\rMessage ["+E.Message+"]"+
				"\rTargetSite ["+E.TargetSite+"]"+
				"\rSource ["+E.Source+"]"+
				"\rInnerException ["+E.InnerException+"]"+
				"\rStackTrace ["+E.StackTrace+"]+"+"{"+E.ToString()+"}";
		}

		private string m_MaxVersion="";
		/// <summary>
		/// Memorizza/Restituisce la versione del sito di riferimento
		/// </summary>
		private string MaxVersion {
			get {
				return m_MaxVersion;
			}
			set {
				//previene la scrittura di eventuali versioni errate
				if (value.ToString().CompareTo(m_MaxVersion)>0) m_MaxVersion=value;
			}
		}

        public static bool IsNet45OrNewer() {
            var result =
                Environment.Version.Major.Equals(4) &&
                Environment.Version.Minor.Equals(0) &&
                Environment.Version.Build.Equals(30319) &&
                Environment.Version.Revision >= 34000;

            return result;
        }

        /// <summary>
        /// Restituisce True se per l'istanza WebClient il sito è accessibile e ha una versione
        /// non inferiore a quella Max
        /// </summary>
        /// <param name="web">istanza WebClient</param>
        private bool IsValid(WebClient web) {
            if (web == null) return false;
		    string swFileName = (IsNet45OrNewer() ? Costanti.C_SWVERSIONFILENAME4 : Costanti.C_SWVERSIONFILENAME);
            if (serviceName != null) swFileName = serviceName + "/" + swFileName;
            //web.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            //web.Headers.Add("Accept-Language", "it-IT,it;q=0.8,en-US;q=0.6,en;q=0.4,bg;q=0.2,es;q=0.2,vi;q=0.2");
            //web.Headers.Add("Upgrade-Insecure-Requests", "1");
            //web.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.99 Safari/537.36");
            web.Headers.Add("User-Agent", "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)");
            string msg ="Http.IsValid("+web.BaseAddress+ swFileName + ")";
            //MetaFactory.factory.getSingleton<IMessageShower>().Show("msg : " + msg.ToString()); // TODELETE
			try {
                
                int Ntry = 0;
                while (web.IsBusy && Ntry<20) {
                    Ntry++;
                    Thread.Sleep(50);
                    PrintLog("Web Busy - Sleeping");
                }
				byte[] bytes=web.DownloadData(swFileName);
				string download=Encoding.ASCII.GetString(bytes);
				//se la versione appena scaricata è inferiore a quella impostata dal sito di riferimento
				//l'indirizzo viene scartato a priori
				if (download.CompareTo(MaxVersion)<0) return false;
				MaxVersion=download;
				return true;
			}
			catch (WebException W) {
                //MetaFactory.factory.getSingleton<IMessageShower>().Show("Errore leggendo " + web.BaseAddress + swFileName, "WebException in IsValid(WebClient web)");
				PrintLog(msg+" ::-> "+GetExceptionMsg(W));
				return false;
			}
			catch (Exception E) {
                //MetaFactory.factory.getSingleton<IMessageShower>().Show("Errore leggendo " + web.BaseAddress + swFileName, "Exception in IsValid(WebClient web)");
                PrintLog(msg+" ::->> "+GetExceptionMsg(E,true));
				return false;
			}
		}

		/// <summary>
		/// Ottiene un'istanza valida (accessibile e con una versione aggiornata) WebClient
		/// </summary>
		/// <param name="remoteAddress">indirizzo web</param>
		internal WebClient GetWebInstance(string remoteAddress) {
			if (!remoteAddress.EndsWith("/")) remoteAddress+="/";
			WebClient web=new WebClient();
            //web.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            //web.Headers.Add("Accept-Language", "it-IT,it;q=0.8,en-US;q=0.6,en;q=0.4,bg;q=0.2,es;q=0.2,vi;q=0.2");
            web.Headers.Add("User-Agent", "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)");
            web.BaseAddress=remoteAddress;
            //web.UseDefaultCredentials = true;
			web.Credentials=CredentialCache.DefaultNetworkCredentials;

            if (IsValid(web)) return web;
			return null;
		}
		
		//Memorizza solo i siti validi e che hanno risposoto entro il limite del timeout
		//internal Hashtable hashSITI;

		/// <summary>
		/// Funzione di callback richiamata dalla classe Timer, invocata per chiudere un thread "vivo"
		/// </summary>
		/// <param name="state">Istanza della class TaskTimer</param>
		private void KillThread(object state) {
			if (state==null) return;
			try {
				TaskTimer s =(TaskTimer)state;
				//se il thread è ancora attivo lo fermo
				if (s.threadHandle.IsAlive) s.threadHandle.Abort();
				//rilascio risorse Timer
				if (s.timer!=null) s.timer.Dispose();
				PrintLog("       STOP  TIMER "+s.timer.GetHashCode().ToString()+ " <-----",false);
			}
			catch (Exception E) {
				PrintLog("KillThread() - Errore["+E.Message+"]");
			}
		}

		/// <summary>
		/// Funzione di log, il print avviene su OutPut
		/// </summary>
		/// <param name="msg">messaggio da stampare</param>
		internal void PrintLog(string msg) {
			PrintLog(msg,true);
		}
		/// <summary>
		/// Funzione di log, il print avviene su OutPut
		/// </summary>
		/// <param name="msg">messaggio da stampare</param>
		/// <param name="print">True per abilitare o meno il log (in fase di debug viene ignorato e vale sempre True)</param>
		internal void PrintLog(string msg, bool print) {
			//if (!print) print=Debugger.IsAttached;
			if (print) QueryCreator.MarkEvent(msg);
			//if (print) Debug.WriteLine("### Time["+DateTime.Now.TimeOfDay.ToString()+"] - "+msg);
		}

		/// <summary>
		/// Data una lista di indirizzi web avvia una serie di thread paralleli e restituisce quello che ha risponde
		/// più velocemente
		/// </summary>
		/// <param name="addresses">collection di indirizzi web</param>
		/// <param name="timeout">timeout (in millisecondi) scaduto il quale il server web viene scartato</param>
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
					//classe che incapsula tutte le info per la classe webClient
					TaskInfo ti=new TaskInfo(address,this);
                    AllTask[i] = ti;

					//creo thread                    
					Thread T=new Thread(new ThreadStart(ti.Process));
				    T.Name = "LU";
                    AllThread[i] = T;

					//lancio il thread
					T.Start();
                    //Thread.Sleep(100);
                    PrintLog(" ping " + address, false);
				}
                Thread.Sleep(10);
                //attendo l'esecuzione dei thread
                //QueryCreator.MarkEvent("SLEEPING" + timeout.ToString() + "....");
                Thread.Sleep(timeout);
				//QueryCreator.MarkEvent("START QUERYING THREADS");
				//scelgo il sito che ha risposto più velocemente
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
                        //if(T.IsAlive) T.Abort();
                    }
                    catch { }
				}
				//non accade mai, giusto per evitare eventuale eccezzione
                if (fastwebsite == null) return null;

                //PrintLog("Indirizzo scelto [" + fastwebsite.BaseAddress + "]");
                return fastwebsite;
			}
			catch (Exception E) {
				PrintLog("GetMoreFastWeb() - Errore ["+E.Message+"]");
				return null;
			}
		}

		/// <summary>
		/// Dato il sito 'remoteAddress' scarica la lista dei siti disponibili
		/// e restituisce quello che risponde + velocemente
		/// </summary>
		private WebClient GetFastWeb(string remoteAddress) {
            //MetaFactory.factory.getSingleton<IMessageShower>().Show("remoteAddress:" + remoteAddress + " cachePath:" + cachePath);

           WebClient webPilota=GetWebInstance(remoteAddress);   //http://www.temposrl.it/easy2/
			if (webPilota==null) return null;
			//scarico il file che contiene gli indirizzi dei siti
			try {
                string filename = "";
                if (remoteAddress.Contains("easyservices")){
                    filename = Costanti.C_LISTASITIWEBSERVICES;
                }else{
					filename = Costanti.C_LISTASITIWEB;
					//filename = "easy2sititest.txt";
				}
                //MetaFactory.factory.getSingleton<IMessageShower>().Show("filename: "+filename.ToString() + " remoteAddress:  " + remoteAddress.ToString()); // TODELETE. NON PASSA DI QUA
				webPilota.DownloadFile(filename,@"zip\"+filename);
                webPilota.Dispose();
                //string mypath = cachePath;
                StreamReader read = new StreamReader( @"zip\" + filename, System.Text.Encoding.Default);
				string s=null;
				string testo=null;
				while ((s=read.ReadLine())!=null) {
					testo+=s+"|";
				}
                read.Close();


                // Aggiorna l'elenco dei siti di liveupdate (updateconfig.xml) ponendo l'indirizzo da cui il file siti.txt
                //   è stato scaricato uguale al primo della lista siti.txt stessa!
			

				string[] siti=testo.Split('|');
			    try {
                    
			        string fname = "updateconfig.xml";
			        DataSet DS = new DataSet();
			        DS.ReadXml(fname);
					DS.AcceptChanges();
			        DataRow R = DS.Tables["configtable"].Rows[0];
			        //if ((siti.Length > 0) && (siti[0] != remoteAddress) && (!siti[0].StartsWith("<"))) {
			        //    if ((R["httpupdatepath"].ToString() == remoteAddress) || 
			        //        (R["httpupdatepath"].ToString() + "/" == remoteAddress)) R["httpupdatepath"] = siti[0];
			        //    if ((R["httpupdatepath2"].ToString() == remoteAddress) ||
			        //        (R["httpupdatepath2"].ToString() + "/" == remoteAddress)) R["httpupdatepath2"] = siti[0];
			        //    if ((R["httpupdatepath3"].ToString() == remoteAddress) ||
			        //        (R["httpupdatepath3"].ToString() + "/" == remoteAddress)) R["httpupdatepath3"] = siti[0];
			        //}

			        //Imposta tutti i siti negli spazi vuoti che trova
			        //for (int i = 0; i < siti.Length; i++) {
			        //    string siteToSet = siti[i];
			        //    if (!siteToSet.StartsWith("http")) continue;
			        //    bool found = false;
			        //    int firstFree = -1;
			        //    for (int j = 1; j < 4; j++) {
			        //        string fieldToCheck = j == 1 ? "httpupdatepath" : "httpupdatepath" + j.ToString();
			        //        if (R[fieldToCheck].ToString().Trim() == "" && firstFree==-1) {
			        //            firstFree = j;
			        //            continue;
			        //        }

			        //        if (R[fieldToCheck].ToString().ToLower().Contains(siteToSet.ToLower())) {
			        //            found = true;
			        //            break;
			        //        }
			        //    }

			        //    if ((!found) && firstFree >= 1) {
			        //        string fieldToSet = firstFree == 1 ? "httpupdatepath" : "httpupdatepath" + firstFree.ToString();
			        //        R[fieldToSet] = siteToSet;
			        //    }
			        //}

					CleanupUpdateConfig(R, CleanupUrlsArray(siti));
                    PostData.RemoveFalseUpdates(DS);

                    if (DS.HasChanges()) {
			            File.SetAttributes(fname, FileAttributes.Normal);
			            DS.WriteXml(fname);
			        }
			    }
			    catch (Exception E) {
			        PrintLog("Updating updateconfig.xml - Errore [" +
			                 QueryCreator.GetErrorString(E) + "]");
			    }

			    WebClient fastWeb=GetMoreFastWeb(siti,3000);
				if (fastWeb!=null) return fastWeb;
				fastWeb=GetMoreFastWeb(siti,10000);
				if (fastWeb!=null) return fastWeb;
                return null; // webPilota;
			}
			catch (Exception E) {
				//se c'è un errore durante il download o il file non esiste
				//viene restituito il sito pilota
                PrintLog("GetFastWeb(): Errore [" + QueryCreator.GetErrorString(E) + "]");
                return null; // webPilota;
			}

		}

		public static string[] CleanupUrlsArray(string[] presumedUrls) {
			List<Uri> urls = new List<Uri>();
			for (int i = 0; i < presumedUrls.Length; i++) {
				Uri tmpUrl;

				try {
					tmpUrl = new Uri(presumedUrls[i]);
				}
				catch (Exception e) {
					continue;
				}

				if (tmpUrl.Scheme == Uri.UriSchemeHttp || tmpUrl.Scheme == Uri.UriSchemeHttps)
					urls.Add(tmpUrl);
			}

			string[] realUrls = new string[urls.Count];
			urls._forEach((url, index) => { realUrls[index] = url.ToString(); });

			return realUrls;
		}

		public static void CleanupUpdateConfig(DataRow r, string[] liveUpdateEndpoints) {
			//proseguiamo solo se abbiamo degli url validi in liveUpdateEndpoints
			if (liveUpdateEndpoints.Length > 0) {
				//svuota gli elementi che iniziano con  http dai campi che iniziano con  httpupdatepath
				r.Table.Columns
					._forEach(c => {
						if (c.ColumnName.StartsWith("httpupdatepath") && r[c].ToString().StartsWith("http"))
							r[c] = DBNull.Value;
					});

				var lista = liveUpdateEndpoints.ToList();

				r.Table.Columns._forEach(c => {
					if (lista.Count == 0) return; //gli endpoints sono finiti
					if (r[c].ToString() != "") return; //non è vuota

					//prende un elemento dalla lista degli endpoints
					r[c] = lista[0];
					lista.RemoveAt(0);
				});
			}
        }

        public string serviceName;
	    public Http(string[] addresses, string cachepath,string serviceName) {
	        try {
	            this.serviceName = serviceName;
	            if (!cachepath.EndsWith("\\")) cachepath+="\\";				//D:\\easy\\output\\
	            this.cachepath = cachepath;			
	            foreach (string address in addresses) { //[]http://www.temposrl.it/easy2/
	                if ((address == null) || (address == string.Empty)) continue;
	                string path = address.Trim();
                    
	                WebSite = eTipoSito.UNKNOWN;
	                //MetaFactory.factory.getSingleton<IMessageShower>().Show("path:" + path.ToString());//TODELETE
	                if (path.StartsWith("http")) {
	                    //Metodo che restituisce il sito più veloce
	                    client=GetFastWeb(path);
	                    if (client==null) continue;
	                    WebSite=eTipoSito.WEB;
	                    this.RemoteDir=client.BaseAddress;      //http://www.temposrl.it/easy2/     http://www.temposrl.it/easyservices/
	                    if (!path.EndsWith("/")) path+="/"; //http://www.temposrl.it/easy2/
	                    return;
	                }
	                else {
	                    //controllo accessibilità folder
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

	    /// <summary>
		/// Classe per connettersi ad un sito web via http o a cartelle locali
		/// </summary>
		/// <param name="paths">Collection di siti o cartelle locali</param>
		/// <param name="cachepath">Percorso cartella di destinazione locale</param>
		public Http(string[] addresses, string cachepath) {
			try {

			    if (!cachepath.EndsWith("\\")) cachepath+="\\";				//D:\\easy\\output\\
				this.cachepath = cachepath;			
				foreach (string address in addresses) { //[]http://www.temposrl.it/easy2/
					if ((address == null) || (address == string.Empty)) continue;
					string path = address.Trim();
                    
					WebSite = eTipoSito.UNKNOWN;
                    //MetaFactory.factory.getSingleton<IMessageShower>().Show("path:" + path.ToString());//TODELETE
					if (path.StartsWith("http")) {
								  //Metodo che restituisce il sito più veloce
						client=GetFastWeb(path);
                        if (client==null) continue;
						WebSite=eTipoSito.WEB;
						this.RemoteDir=client.BaseAddress;      //http://www.temposrl.it/easy2/
					    if (!path.EndsWith("/")) path+="/"; //http://www.temposrl.it/easy2/
						return;
					}
					else {
						//controllo accessibilità folder
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

		public bool IsAvailable() {
			return WebSite != eTipoSito.UNKNOWN;
		}

		/// <summary>
		/// Restituisce il contenuto in formato string di un file
		/// </summary>
		/// <param name="filename">File remoto da leggere</param>
		public string DownloadData(string filename) {
			try {
				string fullname = RemoteDir + filename;
				switch (WebSite) {
					case eTipoSito.WEB:
						byte[] bRemoteFile = client.DownloadData(fullname);
						Encoding encode = Encoding.ASCII;
						string s=encode.GetString(bRemoteFile).TrimEnd();
                        //System.Diagnostics.Debug.WriteLine("Letto da [" + fullname + "] : " + s + "\r");
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
				SetLastError("DownloadData("+filename+") method failed",E);
				return null;
			}
		}

		/// <summary>
		/// Esegue il download del file webfilename e lo memorizza in localfilename
		/// </summary>
		/// <param name="webfilename">Nome file con percorso relativo del file da scaricare es sdi/servicefileindex.xml.zip</param>
		/// <param name="localfilename">Nome file con percorso relativo dove verrà memorizzato il file da scaricare es. zip\\servicefileindex.xml.zip</param>
		public void DownloadFile(string webfilename, string localfilename) {
			//volutamente non viene implementato il try-catch, la gestione è fatta
			//nei chiamanti del metodo
            //cachepath  = D:\\progetti\\sdiftp\\ 
		    string destFileName = cachepath + localfilename;    //      zip\\servicefileindex.xml.zip
		    string remoteFileName = RemoteDir + webfilename; //RemoteDir Y:\\services\\/   // sdi/servicefileindex.xml.zip
			// Controllo preventivo: Nel caso esista un file nella directory di destinazione
			// ed esso ha impostato l'attributo ReadOnly allora lo rendo solo in Archive
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
			m_LastError=error;
			if (E!=null) m_LastError+="\r\rDettaglio: "+E.Message;
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
		private const string C_FOLDERZIP = "zip";  //cartella ZIP locale, usata per scompattare un po' di tutto
		string C_FOLDERDLL = (IsNet45OrNewer() ? "zip4" : "zip");     //cartella DLL remota
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
		//di default è quella delle dll
		private string m_FolderWEB = null;
		//utilizzata solo per i report
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

            return result;
        }

        private bool versione4 = false;
	    private string serviceName = "";
	    /// <summary>
	    /// Costruttore
	    /// </summary>
	    /// <param name="WebAddress">indirizzi web dal quale scaricare i file</param>
	    /// <param name="XMLFileName">nome del file xml</param>
	    /// <param name="TargetDir">directory di destinazione dei file</param>
	    /// <param name="E">Dispatcher, usato solo in caso di live update del db per segnalare la necessità di ricompilare le regole!</param>
	    public Download(EntityDispatcher E,
	        string[] WebAddress,    //è sbagliato che sia Y:\\services\\, deve essere indirizzo web, es.  http://www.temposrl.it/services/sdi
	        string XMLFileName, 
	        string TargetDir,string serviceName) {
	        // Controlla che il .NET Framework 4.5.2 o successivi sia installato
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

	        //controllo se è stato passato un path con \ finale
	        if (!currdir.EndsWith("\\")) currdir += "\\";
	        if (!Directory.Exists(currdir)) Directory.CreateDirectory(currdir);
	        if (!Directory.Exists(Path.Combine(currdir , "zip"))) Directory.CreateDirectory(Path.Combine(currdir , "zip"));
            

	        GetLocalVersions();

	        http = new Http(WebAddress, currdir,serviceName);
	        //MetaFactory.factory.getSingleton<IMessageShower>().Show(WebAddress.Length.ToString() + "  WebAddress : " + WebAddress[0].ToString() , " currdir : " + currdir.ToString() + " http : " + http.ToString());
	    }

	    
	    /// <summary>
		/// Costruttore
		/// </summary>
		/// <param name="WebAddress">indirizzi web dal quale scaricare i file</param>
		/// <param name="XMLFileName">nome del file xml</param>
		/// <param name="TargetDir">directory di destinazione dei file</param>
		/// <param name="E">Dispatcher, usato solo in caso di live update del db per segnalare la necessità di ricompilare le regole!</param>
		public Download(EntityDispatcher E,
			string[] WebAddress, 
			string XMLFileName, 
			string TargetDir) {
            // Controlla che il .NET Framework 4.5.2 o successivi sia installato
            if (IsNet45OrNewer()) {
                versione4=true;
            }

            is_alive =true;
			currdir = TargetDir;
			localXMLFileName = XMLFileName;
			remoteXMLFileName = XMLFileName;
			this.E=E;
			SetStatusSW("");

			//controllo se è stato passato un path con \ finale
			if (!currdir.EndsWith("\\")) currdir += "\\";
			if (!Directory.Exists(currdir)) Directory.CreateDirectory(currdir);
            if (!Directory.Exists(currdir + "zip\\")) Directory.CreateDirectory(currdir + "zip\\");
            

			ReportDir = GetReportDir(WebAddress);

			GetLocalVersions();

            //WebAddress = http://www.temposrl.it/easy2/,  currdir= D:\\easy\\output\\
			http = new Http(WebAddress, currdir);
            //MetaFactory.factory.getSingleton<IMessageShower>().Show(WebAddress.Length.ToString() + "  WebAddress : " + WebAddress[0].ToString() , " currdir : " + currdir.ToString() + " http : " + http.ToString());
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


		/// <summary>
		/// Genera il file delle differenze e copia in diff i nuovi componenti zippati
		/// </summary>
		/// <param name="DiffFileName">xml file delle differenze</param>
		/// <param name="DiffDirFiles">cartella dove copiare i nuovi file</param>
		public void GenDLLDiff(string DiffFileName, string DiffDirFiles, string filter){
			Hashtable lista;
			GenDLLDiff(DiffFileName, DiffDirFiles, filter,  out lista);
		}

		/// <summary>
		/// Genera il file delle differenze e copia in DiffDirFolder i file più recenti zippati e l'indice aggiornato
		/// restituisce la lista dei file aggiornati
		/// </summary>
		/// <param name="unusedParameter">parametro inutilizzato</param>
		/// <param name="DiffDirFolder">cartella dove copiare i nuovi file</param>
		/// <param name="Lista">[out]Lista dei file aggiornati (token=|)</param>
		public void GenDLLDiff(string unusedParameter, 
		    string DiffDirFolder, //D:\\software\\tempLuServices\\zip\\
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
				
				//se non esiste crea la cartella di destinazione (es. D:\\software\\tempLuServices\\zip\\    D:\\software\\tempLU\\zip4\\)
				DirectoryInfo d = new DirectoryInfo(DiffDirFolder);
			    if (!d.Exists) {
			        d.Create();
			    }
			    else {
			        SvuotaDir(DiffDirFolder); 
			    }
					
                //cartella temporanea per le differenze viene creata come "zip" sotto quella di produzione
			    string tempZipFolder = Path.Combine(currdir,"zip");//D:\\progetti\\sdiftp\\zip   o  D:\\easy\\output\\zip

				DirectoryInfo dzip = new DirectoryInfo(tempZipFolder);
				if (!dzip.Exists) dzip.Create();
			    
			    //    "D:\\progetti\\sdiftp\\zip\\servicefileindex.xml" o "D:\\easy\\output\\zip\\fileindex4.xml"
			    string currTempIndex = Path.Combine(tempZipFolder ,remoteXMLFileName);

                string relativeTempIndexName =  Path.Combine(C_FOLDERZIP ,remoteXMLFileName)+".zip"; //"zip\\servicefileindex.xml"  "zip\\fileindex4.xml.zip"
			    string currTempIndexZip = currTempIndex+ ".zip";    //  D:\\progetti\\sdiftp\\zip\\servicefileindex.xml.zip  D:\\easy\\output\\zip\\fileindex4.xml.zip
			    string indexZipFileName = serviceName==""? remoteXMLFileName + ".zip" : serviceName+"/" + remoteXMLFileName +".zip";
                                                                //sdi/servicefileindex.xml.zip    o (Easy)    fileindex4.xml.zip
			    

                //Si intende che la cartella corrente del sito web sia quella di liveupdate
                //leggo il file xml zippato dal server http, nella cartella zip sotto quella di produzione 
			    //http.DownloadFile(remoteXMLFileName + ".zip", ZIP + "/" + remoteXMLFileName + ".zip");
                // http.DownloadFile("reportingservices/servicefileindex.xml.zip","zip\\servicefileindex.xml.zip)
                //in produzione\zip mette l'indice cosi come scaricato dal sito remoto   (es. zip\\fileindex4.xml.zip)
			    http.DownloadFile(indexZipFileName, relativeTempIndexName); //Dowload già di suo accoda il path relativo a quello di destinazione (d:\easy\output\

			    //XZip.ExtractFiles("D:\\progetti\\EasyWebReport_2009\\zip\\servicefileindex.xml.zip"
			            //,     "D:\progetti\EasyWebReport_2009\zip" ,  "servicefileindex.xml", true, false);            
				XZip.ExtractFiles(currTempIndexZip, tempZipFolder, remoteXMLFileName, true, false);//estrae l'indice xml unzippandolo, sempre nella cartella zip

                //  dsrem.ReadXml("D:\\progetti\\EasyWebReport_2009\\zip\\servicefileindex.xml")
			    dsrem.ReadXml(currTempIndex);//legge l'indice appena estratto dalla cartella zip sotto quella di produzione

                //indice locale in  D:\\progetti\\EasyWebReport_2009\\zip\\servicefileindex.xml   o   D:\\easy\\output\\fileindex4.xml
			    string localIndexFileName = currdir + localXMLFileName;
                
			    //se non esiste l'indice locale lo genera
			    //if (!File.Exists(currdir + localXMLFileName))GenXML.GeneraFileXML(currdir, localXMLFileName, filter);

			    //if (!File.Exists(localIndexFileName)) GenXML.GeneraFileXML(currdir, localXMLFileName, filter);

			    //leggo il file xml locale dopo averlo estratto in D:\\progetti\\EasyWebReport_2009\\
                // D:\\progetti\\EasyWebReport_2009\\zip\\servicefileindex.xml.zip, D:\\progetti\\EasyWebReport_2009\\ , servicefileindex.xml
                //easy: localIndexFileName= "D:\\easy\\output\\fileindex4.xml  currdir=D:\\easy\\output\\  localXmlFileName= fileindex4.xml
				XZip.ExtractFiles(localIndexFileName + ".zip", currdir, localXMLFileName, true, false);

			    //D:\\progetti\\EasyWebReport_2009\\ + servicefileindex.xml
                //easy: D:\\easy\\output\\ + fileindex4.xml
				dsloc.ReadXml(Path.Combine( currdir + localXMLFileName));


				DataTable dtloc = dsloc.DLL; //indice locale
                DataTable dtrem = dsrem.DLL; //indice remoto
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
                //controllo e scarico le nuove DLL
                foreach (DataRow drloc in dtloc.Rows) {
                    DataRow drrem = null;
                    string fName = drloc["dllname"].ToString();
                    if (lookupRemote.ContainsKey(fName)) drrem = lookupRemote[fName];                   
                    
					//se la dll locale è + aggiornata la copio in diff
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
						//memorizzo filename / vecchia versione \t nuova versione
						if (drrem==null) {
							//il file è nuovo, non esiste una vecchia versione
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

                //vede se in remoto ci sono righe PIU' aggiornate di quelle locali
                foreach (DataRow drrem in dtrem.Rows) {
                    string fName = drrem["dllname"].ToString();
                    DataRow drloc = null;
                    if (lookupLocal.ContainsKey(fName)) drloc = lookupLocal[fName];                    
                    if (drloc == null) {
                        //il file c'è in remoto ma non in locale, strano
                        Lista.Add(drrem["dllname"], "!MANCA\t\t" +
                            drrem["major"].ToString() + "." + drrem["minor"].ToString() + "." +
                                    drrem["build"].ToString());
                        continue;
                    }
                    //se la dll locale è + aggiornata la copio in diff
                    if (DLLAggiornata(drrem, drloc)) {
                        DataRow NewR = DiffTable.NewRow();
                        NewR["dllname"] = drrem["dllname"];
                        NewR["major"] = drrem["major"];
                        NewR["minor"] = drrem["minor"];
                        NewR["build"] = drrem["build"];

                        DiffTable.Rows.Add(NewR);
                        string fname = NewR["dllname"].ToString();
                        //memorizzo filename / vecchia versione \t nuova versione                        
                        Lista.Add(fname, "!VECCHIO\t" + drrem["major"].ToString() + "." +
                                        drrem["minor"].ToString() + "." +
                                        drrem["build"].ToString() + "\t" +
                            drloc["major"].ToString() + "." + drloc["minor"].ToString() + "." +
                                    drloc["build"].ToString());

                    }
                    
                }




				if (diff){
                    //Easy: DestDiffFolder= D:\\software\\tempLU\\zip4\\        localXmlFileName=fileindex4.xml
                    string fdifname2 = Path.Combine(DiffDirFolder , localXMLFileName);// "D:\\software\\tempLuServices\\zip\\ +  servicefileindex.xml"

                    //copia l'indice locale nella cartella delle differenze
                    //File.Copy(flocname2, fdifname2, true); ERA INUTILE visto che il file lo preleva da currdirr (boh è da verificare)

                    //zippa l'indice locale nella cartella delle differenze
                    //Easy: fdifname2= D:\\software\\tempLU\\zip4\\fileindex4.xml, currdir=D:\\easy\\output\\
                    XZip.AddFiles(fdifname2 + ".zip", currdir, localXMLFileName, true, false); //currdir "E:\\easy\\mainform\\bin\\debug\\" o "D:\\progetti\\EasyWebReport_2009\\"

					//elimino il file "fileindex.xml" dalla cartella diff --> ma che minchia ce l'ha copiato a fare allora?
                    //File.Delete(fdifname2);
				}

//Il file xml delle differenze non viene + creato in quanto visualizzato
//				DataSet DS= new DataSet("Differenze");
//				DS.Tables.Add(DiffTable);
//				DS.WriteXml(DiffDirFiles+"\\"+DiffFileName);
			}
			catch (Exception E) {
				MetaFactory.factory.getSingleton<IMessageShower>().Show(E.Message , "Errore");
				return;
			}
		}

		
		/// <summary>
		/// Restituisce true se la dllNuova risulta aggiornata rispetto a dllVecchia
		/// Il criterio è per major, minor e build number
		/// </summary>
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

            //try {
            //    if (!destFolder.EndsWith(@"\")) destFolder += @"\";
            //    string destfile = destFolder + filename;
            //    if (File.Exists(destfile)) {
            //        FileInfo II= new FileInfo(destfile);
            //        if (II.Length >100) return;
            //        File.SetAttributes(destfile, FileAttributes.Normal);
            //        File.Delete(destfile);
            //    }
            //}
            //catch { }

        }
		/// <summary>
		/// Muove il file dalla cache (zipfolder) alla cartella dell'applicazione
		/// </summary>
		/// <param name="filename">file da spostare</param>
		/// <param name="zipfolder">cartella in cui vengono scaricati i file</param>
		private void CopyFromCache(string filename, string zipfolder, string destFolder,bool deleteoriginal){
			if (!destFolder.EndsWith(@"\")) destFolder+=@"\";
			string lasttempt = "Sposto "+filename;
			string destfile = destFolder+filename;
			string fullpathfilename = zipfolder + "\\" + filename;
			string fullpathzipfilename = fullpathfilename + ".zip";
			//MarkEvent(lasttempt);
			//SetStatusSW(lasttempt);
			if (File.Exists(destfile)) {
				lasttempt = "Imposto gli attributi a "+filename;
				File.SetAttributes(destfile, FileAttributes.Normal);
				lasttempt = "Elimino "+filename;
				File.Delete(destfile);
			}
			lasttempt = "Sposto "+fullpathfilename+ " in "+destfile;
			File.Move(fullpathfilename, destfile);
			lasttempt = "Elimino "+fullpathfilename;
			if (deleteoriginal) File.Delete(fullpathzipfilename);
		}


		/// <summary>
		/// svuota la cartella nella quale vengono scaricati i file dal sito web
		/// </summary>
		/// <param name="folder">path completo della cartella da svuotare</param>
		private static void SvuotaDir(string folder) {
			try {
			    DirectoryInfo d = new DirectoryInfo(folder);  //D:\\software\\tempLuServices\\zip\\tmp\\
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
				//eventuali problemi di ACCESSO NEGATO			
			}
		}


		//private void AggiornaVersioneMenu() {
		//	string filemenu = currdir+"system_menu.xml"; 
		//	if (!File.Exists(filemenu)) return;
		//	DataSet d = new DataSet();
		//	d.ReadXml(filemenu, XmlReadMode.ReadSchema);
		//	string versionemenu = "1.0.000";
		//	if (d.ExtendedProperties["menuversion"]!=null)
		//		versionemenu=d.ExtendedProperties["menuversion"].ToString();
		//	string lasttempt = "Scrittura della nuova versione menu sul file ";
		//	SetStatusSW(lasttempt);
		//	FileInfo f = new FileInfo(currdir + Costanti.C_MENUVERSIONFILENAME);
		//	StreamWriter write = f.CreateText();
		//	write.WriteLine(versionemenu);
		//	write.Close();
		//}

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

		/// <summary>
		/// Restituisce la versione del software prima che sia avvenuto un eventuale
		/// aggiornamento, ovvero la versione presente all'avvio del programma.
		/// </summary>
		public static string GetClientSWVersion() {
			return m_ClientSWVersion;
		}


	    string getVersionFileName() {
            return versione4 ? Costanti.C_SWVERSIONFILENAME4 : Costanti.C_SWVERSIONFILENAME;
        }
		public string GetLocalDLLVersion(string localdir) {		    
			try {
				FileInfo f = new FileInfo(localdir + getVersionFileName()); //D:\easy\output\versionesw4.txt
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
		/// <summary>
		/// Restituisce True se il sw locale è da aggiornare
		/// </summary>
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


		/// <summary>
		/// Scarica le dll la cui versione risulta aggiornata rispetto a quella locale
		/// </summary>
		public void GetNewSWVersion() {
			
			m_FolderWEB = C_FOLDERDLL;

			if (http == null || !http.IsAvailable()) {
				SetStatusSW(C_CANTLIVEUPDATE);
				SetLastErrorSW("DLL :"+Costanti.C_SITENOAVAILABLE,true);
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


		/// <summary>
		/// Funzione che scarica i file zippati e dopo averli estratti in appdir\zip
		/// li copia nella cartella di destinazione
		/// </summary>
		/// <param name="remoteVersion">Versione presente sul sito</param>
		/// <param name="IsDLL">True se è download di DLL</param>
		/// <returns></returns>
		private bool ScaricaFile(string remoteVersion, bool IsDLL) {

			string dbversion = http.DownloadData(C_DBVERSIONFILENAME);
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

                //Elimina i rpt che non ci devono essere
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

				//controllo e scarico le nuove DLL
				foreach (DataRow drrem in dtrem.Rows) {
					//segnale di stop thread ricevuto dal mainform
					if (signaled) break;

				    DataRow drloc = null;
				    if (allLoc.ContainsKey(drrem["dllname"].ToString())) {
				        drloc = allLoc[drrem["dllname"].ToString()];
				    }
                    //FindOne(dtloc, "dllname", drrem["dllname"]);                     
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
						//filename.ext.zip
						string fname = drrem["dllname"].ToString() + ".zip";
						SetStatusSW("Sto aggiornando " + fname);
						lasttempt="Sto aggiornando " + fname;
						//http://.../zip/filename.zip --> AppDir/zip/filename.zip
						http.DownloadFile(m_FolderWEB + "/" + fname, C_FOLDERZIP + "/" + fname);
						string sourceFolder = currdir + C_FOLDERZIP; 
						string zipname = sourceFolder + "\\" + fname;
						SetStatusSW("Estrazione del file " + zipname);
						lasttempt="Scarico " + fname;
						MarkEvent(lasttempt);
                        XZip.ExtractFiles(zipname, sourceFolder, drrem["dllname"].ToString(), true, false);
						
						//updates local directory
                        if (IsDLL)
                            CopyFromCache(drrem["dllname"].ToString(), sourceFolder, currdir, true);
                        else {
                            CopyFromCache(drrem["dllname"].ToString(), sourceFolder, ReportDir, true);
                            DeleteSmallFile(ReportDir, drrem["dllname"].ToString());
                        }

                        //MarkEvent("Aggiorno " + drrem["dllname"].ToString() + " nel file indice locale");
                        //se ho scaricato il menu devo aggiornare il file versionemenu.txt
                        //if (drrem["dllname"].ToString().ToLower() == "system_menu.xml")
                        //    AggiornaVersioneMenu();

                    }	//if DLLAggiornata
				}	//fine foreach (DsDLLIndex.DLLRow drrem in dtrem.Rows)
                if (IsDLL)
                    dsloc.WriteXml(currdir + localXMLFileName);
                else
                    dsloc.WriteXml(ReportDir + localXMLFileName);

              

                //La scrittura della nuova versione solo a processo ultimato e
                //se non è stato interrotto
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
					SetLastErrorSW(//"Versione " +GetClientSWVersion()+"\r\r"+
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

		/// <summary>
		/// Funzione che scarica i file non zippati e li copia nella cartella di destinazione
		/// </summary>
		/// <param name="remoteVersion">Versione presente sul sito</param>
		/// <param name="IsDLL">True se è download di DLL</param>
		/// <returns></returns>
		private bool ScaricaFileNonZippati(string remoteVersion, bool IsDLL) {
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
	
				//controllo e scarico le nuove DLL
				foreach (DataRow drrem in dtrem.Rows) {
					//segnale di stop thread ricevuto dal mainform
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
						//filename.ext
                        string fname = drrem["dllname"].ToString();
						SetStatusSW("Sto aggiornando " + fname);
						lasttempt="Sto aggiornando " + fname;
						//http://.../zip/filename.zip --> AppDir/zip/filename.zip
						//Copia il file da remoto nella cache
						http.DownloadFile(fname, C_FOLDERZIP + "/" + fname);
						string sourceFolder = currdir + C_FOLDERZIP; 
						string zipname = sourceFolder + "\\" + fname;
						SetStatusSW("Estrazione del file " + zipname);
						lasttempt="Estrazione del file " + zipname;
						MarkEvent(lasttempt);

						//Estrae il file dalla cache alla cache
						//XZip.ExtractFiles(zipname, sourceFolder, drrem.dllname, true, false);
						
						//updates local directory
						if (IsDLL)
                            CopyFromCache(drrem["dllname"].ToString(), sourceFolder, currdir, true);
						else
                            CopyFromCache(drrem["dllname"].ToString(), sourceFolder, ReportDir, true);

                        //MarkEvent("Aggiorno " + drrem["dllname"].ToString() + " nel file indice locale");
						if (IsDLL)
							dsloc.WriteXml(currdir+localXMLFileName);
						else
							dsloc.WriteXml(ReportDir+localXMLFileName);

						//se ho scaricato il menu devo aggiornare il file versionemenu.txt
       //                 if (drrem["dllname"].ToString().ToLower() == "system_menu.xml")
							//AggiornaVersioneMenu();

					}	//if DLLAggiornata
				}	//fine foreach (DsDLLIndex.DLLRow drrem in dtrem.Rows)

				//La scrittura della nuova versione solo a processo ultimato e
				//se non è stato interrotto
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
					//SetStatusSW(C_LIVEUPDATEOK);
					SetLastErrorSW(//"Versione " +GetClientSWVersion()+"\r\r"+
						"Report :"+E.Message + " - " + lasttempt+"\r",false);
				}
				is_alive=false;
				return false;
			}

			try {
				//File.Delete(currdir + C_FOLDERZIP + "/" + remoteXMLFileName + ".zip");
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
					SetLastErrorSW(//GetLastErrorSW() + "\r\r"+
						"Report : indice dei report non trovato.\r"+
						"Questo è normale se è stata impostata una directory locale per il live update.\r",false);
					return false;
				}
				localVersion = GetLocalReportVersion(ReportDir);

				if (remoteVersion.CompareTo(localVersion) > 0) return true;
				SetLastErrorSW("Report: Aggiornamento OK",false);
			}
			catch (Exception e) {
				SetLastErrorSW("Report: " + e.Message, false);
			}
			return false;
		}


		/// <summary>
		/// Restituisce la cartella in cui risiedono i report
		/// </summary>
		/// <returns></returns>
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
				//esistenza
				if (!Directory.Exists(dir)) return false;


				//				FileIOPermission p = new FileIOPermission(FileIOPermissionAccess.Write, dir);
				//				string[] list = p.GetPathList(FileIOPermissionAccess.Write);
			
				//dato che FileIOPermission non funzia...
				Directory.CreateDirectory(dir+@"\~t");
				Directory.Delete(dir+@"\~t");

				return true;
			}
			catch {
				//directory di sola lettura o inesistente
				return false;
			}
		}

		/// <summary>
		/// Imposta la variabila d'istanza XMLFileName in modo da richiamare
		/// il metodo senza creare una nuova istanza della classe (per evitare 
		/// un altro thread e/o un'altra istanza nel mainform).
		/// </summary>
		/// <param name="newXMLFileName"></param>
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

		/// <summary>
		/// Scarica i report la cui versione risulta aggiornata rispetto a quella locale
		/// </summary>
		public void GetNewReportVersion() {
			m_FolderWEB = C_FOLDERREPORT;
			string currStatus = GetStatusSW();

			if (http == null || !http.IsAvailable()) {
				SetLastErrorSW("Report: "+Costanti.C_SITENOAVAILABLE ,false);
				is_alive=false;
				SetStatusSW(currStatus);
				return;
			}
			m_Connected = true;


			//Controllo se la cartella dei report è in scrittura x l'utente
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

			//SetLastErrorSW("Versione: " +GetClientSWVersion()+ "\r\r" +
			//	"Report ver.: " + remoteVersion+"\r");
			SetStatusSW(currStatus);
			is_alive=false;
		}



		#endregion

		#region Live Update del DB

		/// <summary>
		/// Aggiunge una riga nella tabella script
		/// </summary>
		/// <param name="Conn">Connessione</param>
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


		
		/// <summary>
		/// Aggiunge una riga nella tabella version
		/// </summary>
		/// <param name="row"></param>
		private static bool AggiungiRigaVersion(DataAccess Conn, DataRow row) {
			string[] columns = new string[] {"versionname", "swversion", "scriptlist", 
												"description", "flagerror", "flagadmin"};
			//default a 0 per il campo flagerror
			row["flagerror"] = "0";
			string[] values = new string[] {
											   QueryCreator.quotedstrvalue(row["versionname"], true),
											   QueryCreator.quotedstrvalue(row["swversion"], true),
											   QueryCreator.quotedstrvalue(row["scriptlist"], true),
											   QueryCreator.quotedstrvalue(row["description"], true),
											   QueryCreator.quotedstrvalue(row["flagerror"], true),
											   QueryCreator.quotedstrvalue(row["flagadmin"], true)};

			if (Conn.DO_INSERT(C_TABVERSION, columns, values, columns.Length)==null) return true;
            return false;
		}

		
		/// <summary>
		/// Pone a '1' il campo flagerror della tabella version
		/// </summary>
		/// <param name="Conn">Connessione</param>
		/// <param name="row">riga della tabella version</param>
		private static bool AggiornaRigaVersion(DataAccess Conn, DataRow row) {
			string[] columns = new string[] {"flagerror"};
			string[] values = new string[] {"'1'"};
			string condition = "versionname = '" + row["versionname"].ToString() + "'";
            if (Conn.DO_UPDATE(C_TABVERSION, condition, columns, values, columns.Length) == null) return true ;
            return false;
		}


		/// <summary>
		/// Restituisce il testo del file
		/// </summary>
		/// <param name="filename">file da leggere</param>
		public static StringBuilder LeggiTestoScript(string filename) {
			//StringBuilder text = new StringBuilder();
			string txt = System.IO.File.ReadAllText(filename, System.Text.Encoding.Default);
            StringBuilder text = new StringBuilder(txt);		    
			return text;
		}

		//		/// <summary>
		//		/// Restituisce il testo del file
		//		/// </summary>
		//		/// <param name="filename">file da leggere</param>
		//		private static string LeggiTestoScript(string filename) {
		//			string text = null;
		//			string currline;
		//			StreamReader Sread = new StreamReader(filename,System.Text.Encoding.Default);
		//			while ((currline = Sread.ReadLine())!=null) {
		//				text += currline + "\n";
		//			}
		//			return text;
		//		}

		public bool IsDBUpdated {
			get {
				return m_IsDBUpdated;
			}
		}

		/// <summary>
		/// Scarica eventuali script sql da eseguire sul DB, restituisce false
		/// se l'utente non ha i diritti per eseguire l'aggiornamento o in caso di errore
		/// </summary>
		/// <param name="Conn">Connessione</param>
		/// <param name="isadmin">True se utente amministratore</param>
		/// <param name="remoteVersion">versione presente sul server http</param>
		/// <param name="localVersion">versione nel db client</param>
		private bool GetScriptSQL(
			EntityDispatcher E,			
			bool isadmin, 
			string remoteVersion,
			string localVersion) {
			DataAccess MainConn = E.Conn.Duplicate();

			//Contiene la versione aggiornata del DB
			string VersioneAggiornata = localVersion;

			SetStatusDB("Scarico script SQL. Versione attuale:"+localVersion);

			//Leggo il file degli script sql che si trova in /liveupdate/sql/
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
					//il file xml degli script non ha righe
					SetStatusDB(C_CANTDBUPDATE);
					SetLastErrorDB("Il file " + C_SCRIPTFILENAME + " non contiene righe"+
						"La versione del DB attuale è "+localVersion);
					MainConn.Destroy();
					return false;
				}
                QueryHelper QHS = MainConn.GetQueryHelper();

                //Connessione che gestisce la transazione utilizzata per l'esecuzione degli script
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
				//per ogni riga del file indice la cui versione < versione generale, eseguo gli script
				foreach (DataRow versionRow in indexVersion.Rows) {
					//segnale di stop thread ricevuto dal mainform
					if (signaled) break;
				    
					//Eseguo gli script solo se la versione letta dal file xml è
					//maggiore della versione locale e minore o uguale di quella
					//generale presente sul sito http
					if (!((versionRow["versionname"].ToString().CompareTo(localVersion) > 0) &&
                        (versionRow["versionname"].ToString().CompareTo(remoteVersion) <= 0))) continue;

                    string versioneInElaborazione = versionRow["versionname"].ToString();
                    //Se la versione letta è inferiore a quella DBO, non esegue gli script DBO
                    bool skipDBO = versionRow["versionname"].ToString().CompareTo(DBOversion) <= 0;
					//controllo grant
                    if (versionRow["flagadmin"].ToString() == "1" && !isadmin) {
						AdminMsg(localVersion);
						ScriptConn.Destroy();
						MainConn.Destroy();
						return false;
					}
					//scarico ed eseguo gli script della versione da aggiornare
					string[] scripts = versionRow["scriptlist"].ToString().Split(';');
					E.SetSys("dbliveupdatedescription", versionRow["description"].ToString());

					//aggiornamento in corso
					SetUpdateDbInCorso("1");
					try {
						//Transazione per la scrittura della versione e degli script
						MainConn.BeginTransaction(IsolationLevel.ReadCommitted);					    
                        lasttempt = "Scrittura della versione " + versioneInElaborazione;
                        
						//scrivo riga nella tabella version
                        if (AggiungiRigaVersion(MainConn, versionRow)) {
                            try {
                                //Transazione per l'esecuzione degli script
                                ScriptConn.BeginTransaction(IsolationLevel.ReadCommitted);
                                foreach (string script in scripts) {
                                    //accidentalmente nel file xml possono essere stati inseriti degli spazi
                                    string realname = script.Trim();
                                    //zip name (es. sqlcreate.sql -> sqlcreate.zip)
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
                                    //								string scripttext = LeggiTestoScript(scriptlocalname);
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
                                            return false; //ESCE 
                                        }

                                    }
                                    else {	//errore nell'esecuzione dello script  >>è qui che ha avuto problemi
                                        string error = QueryCreator.GetPrintable(ScriptConn.LastError)+"-"+
                                                QueryCreator.GetPrintable(resultAddScript);
                                        if (error.Length > 1000) {
                                            scripttext.Insert(0,error+"\r\n");
                                            scripttext.Insert(0,"Errore:\r\n");
                                            error = "Errore accodato al testo dello script";
                                        }
                                        ScriptConn.RollBack(); //Inutile in realtà lavorando con SET XACT_ABORTH
                                        
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
                                                MainConn.RollBack(); //Inutile in realtà lavorando con SET XACT_ABORTH
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
                            catch (Exception e) {	//try-catch per il ciclo degli script
                                //Rollback di entrambe perché qui l'errore può dipendere da 
                                //eventi come il download, in generale non legati all'esecuzione 
                                //del particolare script
                                MainConn.RollBack();
                                ScriptConn.RollBack();
                                SetStatusDB(C_CANTDBUPDATE + " alla versione " + versioneInElaborazione);
                                SetLastErrorDB(lasttempt + " - " + e.Message + "\n" +"La versione del DB attuale è " + localVersion);
                                ScriptConn.Destroy();
                                MainConn.Destroy();
                                return false;
                            }
                            //Commit per l'esecuzione degli script
                            string errorCommit =ScriptConn.Commit();
                            //Commit per la scrittura log
                            
                            MainConn.Commit();

                            localVersion = versioneInElaborazione;
                            //Fuori dal meccanismo di commit/rollback perchè potrebbe non esistere la tabella
                            if (esisteTabellaDBODBVersion && !skipDBO) {
                                MainConn.DO_UPDATE("dbodbversion", QHS.CmpLt("versionname", versioneInElaborazione),
                                    new string[] {"versionname"}, new string[] {QHS.quote(versioneInElaborazione)}, 1);
                                    

                            }
                        }
                        else {
                            MainConn.RollBack();
                        }
					}
					catch (Exception e) {
						//try-catch per il foreach delle version (scrittura in version)
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
			catch (Exception e) {	//try-catch del metodo
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

		
		/// <summary>
		/// Commit per la generazione di custom object
		/// </summary>
		/// <param name="Conn">Connessione</param>
		/// <param name="DBS"></param>
		/// <returns>True se va a buon fine</returns>
		/// <remarks>Da spostare in DataAccess (eliminare il parametro Conn)</remarks>
		private static bool SaveStructureObject(DataAccess Conn, dbstructure DBS) {
			PostData post = new PostData();
			post.InitClass(DBS, Conn);
			return post.DO_POST();
		}


		/// <summary>
		/// Genera custom object
		/// </summary>
		/// <param name="Conn">Connessione</param>
		/// <param name="DBS">Struttura dell'oggetto</param>
		/// <param name="objectname">nome tabella</param>
		/// <param name="force">True per forzare la generazione (in caso di oggetti già presenti)</param>
		/// <remarks>Da spostare in DataAccess e adattarla</remarks>
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

		/// <summary>
		/// True se il software è allineato con la versione del database
		/// </summary>
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

		/// <summary>
		/// Restituisce True se la versione flaggata come errata è ancora valida, cioè è
		/// presente nel file indice degli script sql da eseguire. False se la versione
		/// deve essere ignorata (non è più utilizzata, presente nel file indice).
		/// </summary>
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

		/// <summary>
		/// Confronta la versione dell'applicativo presente sul sito rispetto
		/// a quella locale, restituisce true se sul sito è aggiornata
		/// </summary>
		/// <param name="localfile">Nome completo...</param>
		/// <param name="Conn">Connessione</param>
		/// <param name="isadmin">True se amministratore</param>
		/// <param name="remoteVersion">[out] versione presente sul server http</param>
		/// <param name="localVersion">versione presente nel db client</param>
		/// <returns>True se la versione locale risulta da aggiornare</returns>
		private bool ControllaVersioneDB(
			DataAccess Conn, 
			bool isadmin, 
			DataTable tabVersion,
			out string remoteVersion, 
			string localVersion) {

			remoteVersion = "";
			
			try {
				//leggo la versione presente sul sito
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
					/*
					if (!isadmin) {
						AdminMsg(localVersion);
						return false;
					}
					*/
					try {
						//eseguo script di creazione (se non esistono) delle tabelle 
						//customobject, columntypes, customtablestructure
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
							//Conn.RollBack();
							return false;
						}
						DBS = (dbstructure) Conn.GetStructure(C_TABSCRIPT);
						GenerateCustomObject(Conn, DBS, C_TABSCRIPT);
						if (!SaveStructureObject(Conn, DBS)) {
							SetStatusDB(C_CANTDBUPDATE);
							SetLastErrorDB("Errore metodo SaveStructureObject("+C_TABSCRIPT+") failed"+
								"La versione del DB attuale è "+localVersion);
							//Conn.RollBack();
							return false;
						}
						DBS = (dbstructure) Conn.GetStructure(C_TABMENU);
						GenerateCustomObject(Conn, DBS, C_TABMENU);
						if (!SaveStructureObject(Conn, DBS)) {
							SetStatusDB(C_CANTDBUPDATE);
							SetLastErrorDB("Errore metodo SaveStructureObject("+C_TABMENU+") failed"+
								"La versione del DB attuale è "+localVersion);
							//Conn.RollBack();
							return false;
						}
					}
					catch (Exception e) {
						SetStatusDB(C_CANTDBUPDATE);
						SetLastErrorDB("Errore nell'esecuzione dello script SQL di sistema - " + e.Message +
							"La versione del DB attuale è "+localVersion);
						//Conn.RollBack();
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


		//Create due property per poter invocare il metodo GetNewDBVersion
		//in un thread separato dal mainform

		/// <summary>
		/// Get or sets the admin grant
		/// </summary>
		public bool IsAdmin {
			get {
				return m_isAdmin;
			}
			set {
				m_isAdmin = value;
			}
		}
		
		/// <summary>
		/// Get or sets the DataAccess
		/// </summary>
		public DataAccess Connessione {
			get {
				return m_Conn;
			}
			set {
				m_Conn = value;
			}
		}

		/// <summary>
		/// Ottieni il contenuto della tabella updatedbversion
		/// </summary>
		/// <param name="Conn">Connessione</param>
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

		/// <summary>
		/// Ricavo la versione del sw associata alla versione corrente del DB
		/// </summary>
		/// <param name="tabVersion">tabella version</param>
		private string GetMinVerSupported(DataTable tabVersion) {
			if (tabVersion.Rows.Count > 0)
				return tabVersion.Rows[0]["swversion"].ToString();
			else
				return C_DBDUMMYVERSION;
		}

		/// <summary>
		/// "0" = stato iniziale, "1" = processo in corso, "2" = Terminato
		/// </summary>
		public static string UpdateDbInCorso {
			get {
				return m_UpdateDBInCorso;
			}
		}

		/// <summary>
		/// "0" = stato iniziale, "1" = processo in corso, "2" = Terminato
		/// </summary>
		private static void SetUpdateDbInCorso(string newvalue) {
			m_UpdateDBInCorso = newvalue;
		}

		/// <summary>
		/// Restituisce la versione corrente del DB (prima riga del DataTable in input)
		/// </summary>
		/// <param name="tabVersion">tabella delle versioni</param>
		private string GetDBLocalVersion(DataTable tabVersion) {
			if (tabVersion.Rows.Count > 0)
				return tabVersion.Rows[0]["versionname"].ToString();
			else
				return C_DBDUMMYVERSION;
		}

		/// <summary>
		/// Scarica ed esegue eventuali script sql se la versione è da aggiornare
		/// </summary>
		/// <param name="Conn">Parametro per la connessione al DB</param>
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
				SetLastErrorDB(Costanti.C_SITENOAVAILABLE+"\r"+
					"Versione attuale: "+localVersion);
				is_alive=false;
				return;
			}

			m_Connected = true;

			string remoteVersion;

			bool isadmin = this.IsAdmin;


			SetStatusDB(C_DBUPDATEOK);
			SetLastErrorDB("Versione " + localVersion);

			SetUpdateDbInCorso("0");
			//Se non è da aggiornare non faccio nulla
			if (ControllaVersioneDB(Connessione, isadmin, tabVersion, out remoteVersion, localVersion)) {
				//Eseguo eventuali script sql
				GetScriptSQL(E, isadmin, remoteVersion, localVersion);
			}
			SetUpdateDbInCorso("2");
			E.SetUsr("mustchecksptocompile","1");
		    E.SetSys("dbversion", localVersion);
			is_alive=false;
		}

		#endregion

		#region Esegue script sql

		/// <summary>
		/// Divide l'intero script in una serie di comandi
		/// </summary>
		/// <param name="script">testo dello script</param>
		/// <returns>Array di comandi</returns>
		private static ArrayList DivideScript(StringBuilder script){
//			ArrayList CmdList= new ArrayList();
//			StringReader Sread= new StringReader(script.ToString());
//			string currline;
//			StringBuilder Cmd=null;
//			while ((currline = Sread.ReadLine())!=null){
//				if (currline.TrimEnd().ToUpper()=="GO"){
//					if (Cmd!=null) CmdList.Add(Cmd);
//					Cmd=null;
//					continue;
//				}
//				if (Cmd==null)
//					Cmd = new StringBuilder(currline);
//				else
//					Cmd.Append("\n"+currline);
//			}
//			if (Cmd!=null && Cmd.ToString()!="") CmdList.Add(Cmd);
//			return CmdList;
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

		/// <summary>
		/// Divide l'intero script in una serie di comandi
		/// </summary>
		/// <param name="script">testo dello script</param>
		/// <returns>Array di comandi</returns>
//		private static ArrayList DivideScript(string script){
//			ArrayList CmdList= new ArrayList();
//			StringReader Sread= new StringReader(script);
//			string currline;
//			string Cmd=null;
//			while ((currline = Sread.ReadLine())!=null){
//				if (currline.TrimEnd().ToUpper()=="GO"){
//					if (Cmd!=null) CmdList.Add(Cmd);
//					Cmd=null;
//					continue;
//				}
//				if (Cmd==null)
//					Cmd=currline;
//				else
//					Cmd=Cmd+"\n"+currline;
//			}
//			if (Cmd!=null && Cmd!="") CmdList.Add(Cmd);
//			return CmdList;
//		}
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

		/// <summary>
		/// Esegue il comando di uno script
		/// </summary>
		/// <param name="cmd">comando da eseguire</param>
		/// <param name="Conn">Connessione</param>
		/// <param name="error">errore se non null</param>
		/// <returns>True se va a buon fine</returns>
		private static bool RunScriptCmd(DataAccess Conn, string cmd, out string error) {
            //			cmd= QueryCreator.GetPrintable(cmd);
            error = null;
			DataTable T = Conn.SQLRunner(cmd,C_SQLCOMMANDTIMEOUT, out error);
			return (T != null);
		}

	    public static bool RUN_SCRIPT(DataAccess Conn, StringBuilder script, out string error) {
	        return RUN_SCRIPT(Conn, script, false, out error);
	    }

	    /// <summary>
        /// Esegue lo script sql
        /// </summary>
        /// <param name="Conn">Connessione</param>
        /// <param name="script">testo dello script</param>
        /// <returns>True se l'esecuzione va a buon fine</returns>
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
	        return RUN_SCRIPT(Conn, script, title);
	    }

	    public static bool RUN_SCRIPT(DataAccess Conn, StringBuilder script, string title,bool skipDBO, out string error) {
			ArrayList CmdList = DivideScript(script);
			FrmMeter FM= new FrmMeter();
			FM.labInfo.Text=title;
			FM.pBar.Maximum=CmdList.Count;
			FM.Show();
            error = null;
			//System.Windows.Forms.Application.DoEvents();
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
	            //if (i%10 == 0) System.Windows.Forms.Application.DoEvents();
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
			FM.Show();
			//System.Windows.Forms.Application.DoEvents();
	        for (int i = 0; i < CmdList.Count; i++) {
	            string sql = CmdList[i].ToString();
	            if (i == 0 && sql.StartsWith("--[DBO]--") && skipDBO) {
                    FM.Close();
                    return ok;
                }
	            if (!RunScriptCmd(Conn, sql, out error)) {
	                ok = false;
	                DialogResult dr = new FrmError(title, Conn.LastError).ShowDialog(FM);
	                if (dr != DialogResult.Yes) {
	                    FM.Close();
	                    return false;
	                }
	            }

	            FM.pBar.Increment(1);
	            //if (i%10 == 0) System.Windows.Forms.Application.DoEvents();
	        }
	        FM.Close();
			return ok;
		}
		/// <summary>
		/// Esegue lo script sql
		/// </summary>
		/// <param name="Conn">Connessione</param>
		/// <param name="script">testo dello script</param>
		/// <returns>True se l'esecuzione va a buon fine</returns>
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

		/// <summary>
		/// Restituisce lo script sql per la creazione delle tabelle version e script
		/// </summary>
		/// <returns></returns>
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

		/// <summary>
		/// Restituisce lo script sql per customobejct, columntypes e customtablestructure
		/// </summary>
		private static string GetCustomTablesScriptSQL() {
			//create columntypes
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

			//create customobject
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

			//columntypes per columntypes
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

			//columntypes per customobject
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

			//customtablestructure
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

	/// <summary>
	/// Classe utilizzata per aggiungere/estrarre file(s) a/da file compressi
	/// </summary>
	public class XZip {

      

		#region Add files method

		/// <summary>
		/// Adds files to a zip file.
		/// </summary>
		/// <param name="zipFilename">Name of the zip file. If it does not exist, it will be created. If it exists, it will be updated.</param>
		/// <param name="sourceFolder">Name of the folder from which to add files.</param>
		/// <param name="fileMask">Name of the file to add to the zip file. Can include wildcards.</param>
		/// <param name="replaceFiles">True per sostituire file esistenti</param>
		/// <param name="recursive">Specifies if the files in the sub-folders of <paramref name="sourceFolder"/> should also be added.</param>
		/// <remarks>Volutamente non sono gestite le eccezioni</remarks>
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
			//controllo cartella sorgente
		
			//Set attribute file to normal
			File.SetAttributes(Path.Combine(sourceFolder , fileMask), FileAttributes.Normal);
			// Create a DiskFile object for the specified zip filename
			DiskFile zipFile = new DiskFile(zipFilename);
			// Check if the file exists
			if (!zipFile.Exists) zipFile.Create();
			// Create a ZipArchive object to access the zipfile.
			ZipArchive zip = new ZipArchive(zipFile);
			zip.DefaultCompressionMethod = CompressionMethod.Deflated;
			// Create a DiskFolder object for the source folder
			DiskFolder source = new DiskFolder(sourceFolder);
			// Copy the contents of the zip to the destination folder.
			source.CopyFilesTo(zip, recursive, replaceFiles, fileMask );      
		}

		#endregion

		#region Extract files method

		/// <summary>
		/// Extracts the contents of a zip file to a specified folder, based on a file mask (wildcard).
		/// </summary>
		/// <param name="zipFilename">Name of the zip file. The file must exist.</param>
		/// <param name="destFolder">Folder into which the files should be extracted.</param>
		/// <param name="fileMask">Wildcard for filtering the files to be extracted.</param>
		/// <param name="replaceFiles">True per sostituire i file già presenti</param>
		/// <param name="recursive">true per abilitare la ricorsione di sottocartelle</param>
		/// <remarks>Volutamente non sono gestite le eccezioni</remarks>
		public static void ExtractFiles(string zipFilename,
			string destFolder, 
			string fileMask,
			bool replaceFiles,
			bool recursive) {

			// Create a DiskFile object for the specified zip filename
			DiskFile zipFile = new DiskFile(zipFilename);
			// Create a ZipArchive object to access the zipfile.
			ZipArchive zip = new ZipArchive(zipFile);
			// Create a DiskFolder object for the destination folder
			DiskFolder destinationFolder = new DiskFolder(destFolder);
			// Copy the contents of the zip to the destination folder.

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
