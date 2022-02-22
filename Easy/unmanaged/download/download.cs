
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
using System.Text;
using System.Security;
using EnterpriseDT.Net.Ftp;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using metadatalibrary;

namespace download//download//
{
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
       
        public static bool IsNet45OrNewer() {
            var result =
                Environment.Version.Major.Equals(4) &&
                Environment.Version.Minor.Equals(0) &&
                Environment.Version.Build.Equals(30319) &&
                Environment.Version.Revision >= 34000;

            return result;
        }

        string getVersionFileName() {
            return (IsNet45OrNewer() ? Costanti.C_SWVERSIONFILENAME4 : Costanti.C_SWVERSIONFILENAME);
        }


		/// <summary>
		/// Classe per connettersi ad un sito web via http o a cartelle locali
		/// </summary>
		/// <param name="paths">Collection di siti o cartelle locali</param>
		/// <param name="cachepath">Percorso cartella temporanea</param>
		public Http(string[] addresses, string cachepath) {
			string msg="";
			if (!cachepath.EndsWith("\\")) cachepath+="\\";
			this.cachepath = cachepath;
		
			foreach (string address in addresses) {
				if ((address == null) || (address == string.Empty)) continue;
				string path = address.Trim();

				if (path.StartsWith("http")) {
					if (!path.EndsWith("/")) path+="/";
					client = new WebClient();
                    //client.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
                    //client.Headers.Add("Accept-Language", "it-IT,it;q=0.8,en-US;q=0.6,en;q=0.4,bg;q=0.2,es;q=0.2,vi;q=0.2");
                    client.Headers.Add("User-Agent", "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)");
                    client.BaseAddress = path;
					client.Credentials = CredentialCache.DefaultCredentials;
					//controllo accessibilità web site
					try {
						//System.Diagnostics.Debug.WriteLine("Tentativo di collegamento a ["+client.BaseAddress+ getVersionFileName() + "]\r");
						client.DownloadData(getVersionFileName());
						WebSite = eTipoSito.WEB;
						this.RemoteDir = path;
						return;
					}
					catch (WebException W) {
						msg="Tentativo di collegamento fallito"+
							"\rMessage ["+W.Message+"]"+
							"\rTargetSite ["+W.TargetSite+"]"+
							"\rStatus ["+W.Status+"]"+
							"\rSource ["+W.Source+"]"+
							"\rInnerException ["+W.InnerException+"]"+
							"\rHelpLink ["+W.HelpLink+"]"+
							"\rStackTrace ["+W.StackTrace+"]";
						if (W.Status==WebExceptionStatus.ProtocolError) {
							msg+="ResponseUri ["+W.Response.ResponseUri+"]\r";
						}
						System.Diagnostics.Debug.WriteLine(msg);
						m_LastError+="Collegamento al sito ["+path+"] fallito\r";
						WebSite = eTipoSito.UNKNOWN;
						continue; 
					}
					catch (Exception E) { 
						System.Diagnostics.Debug.WriteLine("Tentativo di collegamento fallito - Errore ["+
							E.Message+"] - Path ["+client.BaseAddress+ getVersionFileName() + "]\r");
						m_LastError+="Collegamento al sito ["+path+"] fallito\r";
						WebSite = eTipoSito.UNKNOWN;
						continue; 
					}
				}
				else {
					//controllo accessibilità folder
					try {
						if (!path.EndsWith(@"\")) path+=@"\";
						DirectoryInfo d = new DirectoryInfo(path);
						if (!d.Exists) throw new Exception();
						WebSite = eTipoSito.NETBIOS;
						this.RemoteDir = path;
						return;
					}
					catch { 
						m_LastError+="Cartella ["+path+"] inesistente o inaccessibile\r";
						WebSite = eTipoSito.UNKNOWN;
						continue; 
					}
				}
			}
		}

		public bool IsAvailable() {
			return WebSite != eTipoSito.UNKNOWN;
		}


	    public FtpFileNameRewriter rewriter= new FtpFileNameRewriter();

		/// <summary>
		/// Restituisce il contenuto in formato string di un file
		/// </summary>
		/// <param name="filename">File remoto da leggere</param>
		public string DownloadData(string filename) {
			try {
				string fullname = RemoteDir + filename;
			    string fullnameRewritten = rewriter.localToRemoteFileName(fullname);
				switch (WebSite) {
					case eTipoSito.WEB:
						byte[] bRemoteFile = client.DownloadData(fullnameRewritten);
						Encoding encode = Encoding.ASCII;
						string s=encode.GetString(bRemoteFile).TrimEnd();
						System.Diagnostics.Debug.WriteLine("Letto da ["+fullname+"] : "+s);
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
							sr.Close();

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
		/// <param name="webfilename">Path relativo del file da scaricare</param>
		/// <param name="localfilename">Nome del file con il quale verrà memorizzato</param>
		/// <returns>True se va a buon fine</returns>
		public bool DownloadFile(string webfilename, string filename) {
			string msg="";
			try {
				switch(WebSite) {
					case eTipoSito.WEB:
						client.DownloadFile(rewriter.localToRemoteFileName(RemoteDir + webfilename), cachepath + filename);
						break;

					case eTipoSito.NETBIOS:
                        //in locale nessun rewrite
						File.Copy(RemoteDir + webfilename, cachepath + filename, true);
						break;
					default:
						SetLastError("DownloadFile("+webfilename+") method failed - TipoSito unknown");
						return false;
				}
				return true;
			}
			catch (WebException W) {
				msg=GetExceptionMsg(W);
			}
			catch (SecurityException S) {
				msg=GetExceptionMsg(S);
			}
			catch (Exception E) {
				msg=GetExceptionMsg(E,true);
			}
			System.Diagnostics.Debug.WriteLine(msg);
			SetLastError(msg);
			return false;
		}

		/// <param name="W">tipo eccezione</param>
		private string GetExceptionMsg(WebException W) {
			string tipo="Tentativo di download fallito (WebException)";
			string msg=tipo+GetExceptionMsg(W,false)+
				"\rStatus ["+W.Status+"]"+
				"\rHelpLink ["+W.HelpLink+"]";
			if (W.Status==WebExceptionStatus.ProtocolError) {
				msg+="\rRichiesta ["+W.Response.ResponseUri+"]\r";
			}
			return msg;
		}
		/// <param name="S">tipo eccezione</param>
		private string GetExceptionMsg(SecurityException S) {
			string tipo="Tentativo di download fallito (SecurityException)";
			return tipo+GetExceptionMsg(S,false)+
				"\rPermissionState ["+S.PermissionState+"]"+
				"\rPermissionType ["+S.PermissionType+"]"+
				"\rGrantedSet ["+S.GrantedSet+"]"+
				"\rHelpLink ["+S.HelpLink+"]";
		}

		/// <param name="E">tipo eccezione</param>
		/// <param name="header">True se visibile "Tentativo..."</param>
		private string GetExceptionMsg(Exception E, bool header) {
			string tipo="Tentativo di download fallito (Exception)";
			return (header?tipo:"")+"\rMessage ["+E.Message+"]"+
				"\rTargetSite ["+E.TargetSite+"]"+
				"\rSource ["+E.Source+"]"+
				"\rInnerException ["+E.InnerException+"]"+
				"\rStackTrace ["+E.StackTrace+"]";
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

	public class Costanti {
		public const string C_SWVERSIONFILENAME = "versionesw.txt";
        public const string C_SWVERSIONFILENAME4 = "versionesw4.txt";
        public const string C_MENUVERSIONFILENAME = "versionemenu.txt";
		public const string C_SITENOAVAILABLE = "Indirizzi non raggiungibili";
		public const string C_REPORTVERSIONFILENAME = "versionereport.txt";
	}

    public  class FtpFileNameRewriter {
      
        public List<string> rewriteRules= new List<string>();
        private void addRewriteRule(string localFileName,string remoteFileName) {
            rewriteRules.Add(localFileName.Trim()+"|"+remoteFileName.Trim());
        }

        public void getRewriteList(string remoteSite) {
            WebClient w = new WebClient();
            var result = new List<string>();
            try {
                var s = w.DownloadString(remoteSite);
                foreach (string pair in s.Split('\n')) {
                    string[] pieces = pair.Split('|');
                    if (pieces.Length != 2) continue;
                    addRewriteRule(pieces[0],pieces[1]);
                }
            }
            catch (Exception e){

            }
        }
		/// <summary>
		/// Da normale a criptato
		/// </summary>
		/// <param name="fileName"></param>
		/// <returns></returns>
        public string localToRemoteFileName(string fileName) {
            string result = fileName;
            foreach (string rule in rewriteRules) {
                string[] pieces = rule.Split('|');
                if (pieces.Length!=2)continue;                   
                result = result.Replace(pieces[0].Trim(), pieces[1].Trim());
            }
            return result;
        }

    }
	/// <summary>
	/// Classe utilizzata per una sessione FTP
	/// </summary>
	public class Ftp {
		
	    public FtpFileNameRewriter rewriter= new FtpFileNameRewriter();

		#region Membri privati / pubblici

		public  FTPClient m_FtpClient=null;
		private string m_LastError=null;
		private string m_Host=null;
		private bool m_IsConnected;
        private FTPConnectMode connectMode = FTPConnectMode.PASV;
	    public string rootDirectory=null;
		#endregion
		
		#region Costruttori
		/// <summary>
		/// Use default port 21, no log
		/// </summary>
		/// <param name="host">remote host nenza prefisso</param>
		public Ftp(string host):this(host,21,null) {
		}
		/// <summary>
		/// No log
		/// </summary>
		/// <param name="host">remote host nenza prefisso</param>
		/// <param name="port">remote port</param>
		public Ftp(string host, int port):this(host,port,null) {
		}
		/// <param name="host">remote host nenza prefisso</param>
		/// <param name="port">remote port</param>
		/// <param name="log">StreamWriter per log (default output viewer)</param>
		public Ftp(string host, int port, StreamWriter log) {
			string msg="Ftp("+host+", "+port+")";
			try {
				m_IsConnected=true;
				m_Host=host;
                m_FtpClient = new FTPClient();
                m_FtpClient.ControlPort = port;
                //m_FtpClient.l
                m_FtpClient.RemoteHost = host;
                m_FtpClient.Timeout = 30000;
                //host, port, log, 5000);
				if (m_FtpClient!=null) return;

				m_IsConnected=false;
			}
			catch (Exception E) {
				SetLastError(msg,E);
				m_IsConnected=false;
			}
		}

		#endregion

		#region Funzioni

//		public string LastValidReplyCode {
//			get {
//				return m_FtpClient.LastValidReply.ReplyCode;
//			}
//		}

		public bool IsConnected {
			get {
				return m_IsConnected;
			}
		}

		/// <summary>
		/// Login with default: traceOn=True, TransfertType=BINARY, ConnectMode=ACTIVE
		/// </summary>
		/// <param name="user">user</param>
		/// <param name="pwd">password</param>
		public bool Login(string user, string pwd) {
			return this.Login(user,pwd,true);
		}

        public void SetActiveMode(bool active) {
            if (active) {
                connectMode = FTPConnectMode.ACTIVE;
            }
            else {
                connectMode = FTPConnectMode.PASV;
            }
        }
		/// <summary>
		/// Login with default: TransfertType=BINARY, ConnectMode=ACTIVE
		/// </summary>
		/// <param name="traceOn">Enable output trace</param>
		/// <param name="user">user</param>
		/// <param name="pwd">password</param>
		public bool Login(string user, string pwd, bool traceOn) {
			return this.Login(user,pwd,traceOn,FTPTransferType.BINARY,
                connectMode);
		}

      


		/// <summary>
		/// Login
		/// </summary>
		/// <param name="traceOn">Enable output trace</param>
		/// <param name="user">user</param>
		/// <param name="pwd">password</param>
		/// <param name="transfertype">Binary / Ascii</param>
		/// <param name="connectmode">ACTIVE / PASV</param>
		public bool Login(string user, string pwd, bool traceOn, FTPTransferType transfertype, FTPConnectMode connectmode) {
			string msg="Login("+user+", "+pwd+", "+traceOn.ToString()+", "+transfertype.ToString()+", "+connectmode.ToString()+")";
			try {
				m_FtpClient.DebugResponses(traceOn);
                m_FtpClient.Connect();
                Thread.Sleep(100);
                m_FtpClient.Login(user, pwd);
                m_FtpClient.TransferType=transfertype;
                m_FtpClient.ConnectMode = connectmode;
                return true;
			}
			catch (Exception E) {
				SetLastError(msg,E);
				return false;
			}
		}

		public string Host {
			get {
				return m_Host;
			}
		}

		/// <summary>
		/// Scarica il file dopo aver eliminato proprietà di sola lettura
		/// </summary>
		/// <param name="localPath">Nome completo del file di destinazione</param>
		/// <param name="remoteFile">nome del file da scaricare</param>
		/// <returns>True se va a buon fine</returns>
		public bool GetFile(string localPath, string remoteFile) {
			string msg="GetFile("+localPath+", "+remoteFile+")";
            bool retry = true;
            bool autoretry = true;
            while (retry) {
                try {
                    //elimina eventuali diritti di sola lettura
                    if (File.Exists(localPath)) {
                        File.SetAttributes(localPath, FileAttributes.Archive);
                        File.Delete(localPath);
                    }
                    //scarico il file
                    m_FtpClient.Get(localPath, rewriter.localToRemoteFileName(remoteFile));
                    return true;
                }
                catch (Exception E) {
                    SetLastError(msg, E);
                    if (autoretry) {
                        autoretry = false;
                    }
                    else {
                        if (MetaFactory.factory.getSingleton<IMessageShower>().Show("Errore leggendo il file " + remoteFile + " da remoto. Riprovo? Errore:" + E.ToString(), "Conferma",
                                        MessageBoxButtons.YesNo) != DialogResult.Yes) {
                                            retry = false;
                        };
                    }                   
                }
            }
            return false;
		}

	    string getDirectory(string remoteFileName) {
	        if (remoteFileName.EndsWith("/")) return remoteFileName;
            string[]pieces = remoteFileName.Split('/');
	        if (pieces.Length == 1) return null;
            var r =  pieces.ToList();
	        r.RemoveAt(pieces.Length - 1);
	        return string.Join(@"/", r);
	    }
	    string getFileName(string remoteFileName) {
	        string[]pieces = remoteFileName.Split('/');
	        return pieces[pieces.Length - 1];
	    }

		/// <summary>
		/// Carica un file sul server ftp
		/// </summary>
		/// <param name="sourceFileNameComplete">percorso relativo alla cartella corrente e nome file</param>
		/// <param name="remoteFile">percorso e nome destinazioine del file da inviare, relativo alla cartella ftp corrente </param>
		/// <returns>True se va a buon fine</returns>
		public bool PutFile(string sourceFileNameComplete, // "Y:\\services\\easyweb\\servicefileindex.xml.zip
		    string remoteFileOriginal) {    //errato: "D:\\Easy\\output\\sync/servicefileindex.xml.zip/servicefileindex.xml.zip
            //Application.DoEvents();
			string msg="PutFile("+sourceFileNameComplete+", "+remoteFileOriginal+")";
            bool retry = true;
            bool autoretry = true;
		    string rewrittenRemoteFile = remoteFileOriginal.Replace("\\", "/");

		    rewrittenRemoteFile = rewriter.localToRemoteFileName(rewrittenRemoteFile);

		    string rewrittenDrectory = getDirectory(rewrittenRemoteFile);
		    string rewrittenFileName = getFileName(rewrittenRemoteFile);		    


		    //if (rootDirectory !=null && !checkDirectoryFtpCompleta(directory,rootDirectory)) return false;
		    bool dirChecked = false;
		    
		    //if (rootDirectory == null) dirChecked = true;
            while (retry) {
                try {
                    //if (directoryEffetiva!=null) m_FtpClient.ChDir(directoryEffetiva);
                    m_FtpClient.Put(sourceFileNameComplete, rewrittenRemoteFile);//funziona anche se remoteFile contiene un file annidato in una cartella 
                    //if (true) {
                    //    try {
                    //        new WebClient().DownloadString(rewrittenFileName);
                    //    }
                    //    catch {
                    //        MetaFactory.factory.getSingleton<IMessageShower>().Show("Invio di " + rewrittenFileName + " fallito", "Errore");
                    //    }
                        
                    //}
                    return true;
                }
                catch (Exception E) {
                    if (!dirChecked) {
                        dirChecked = true;
                        if (rewrittenDrectory == null) return false;
                        if (!checkDirectoryFtpCompleta(rewrittenDrectory)) return false;
                        continue;
                    }
                    SetLastError(msg, E);
                    if (autoretry) {
                        autoretry = false;
                    }
                    else {
                        if (MetaFactory.factory.getSingleton<IMessageShower>().Show(null, "Riprovo? Errore:" + E.ToString(), "Conferma", MessageBoxButtons.YesNo) != DialogResult.Yes) retry = false;
                    }
                }
            }
            return false;
		}

	  
		/// <summary>
		/// A partire dalla directory di default (quella di connessione), verifica la presenza,
		/// ed eventualmente la crea, di una directory reimpostando come cartella corrente quella di partenza
		/// </summary>
		/// <param name="dir">cartella da verificare</param>
		/// <returns>True se va a buon fine il check</returns>
		public bool CheckDir(string dir) {  //errato D:\Easy\output\sync
			string msg="CheckDir("+dir+")";
			try {
				//se esite non faccio nulla
			    try {
			        if (ChangeDir(dir)) return ChangeDir("..");
			    }
			    catch {
			    }
				//altrimenti la creo
				return CreateDir(dir);
			}
			catch (Exception E) {
				SetLastError(msg, E);
				return false;
			}
		}



	    /// <summary>
	    /// Restituisce la dir con lo / finale
	    /// </summary>
	    public static string CheckReverseFinalSlash(string dir) {
	        if (dir.EndsWith(@"/")) return dir;
	        return dir+=@"/";
	    }
	    /// <summary>
	    /// Restituisce la dir con lo / finale
	    /// </summary>
	    public static string CheckReverseStartSlash(string dir) {
	        if (dir == null) return null;
	        if (dir.StartsWith(@"/")) return dir;
	        return @"/"+dir;
	    }
	    /// <summary>
	    /// Restituisce la dir con lo / finale
	    /// </summary>
	    public static string removeFinalReverseSlash(string dir) {
	        if (dir == null) return null;
	        if (!dir.EndsWith(@"/")) return dir;
	        return dir.Remove(dir.Length-1);
	    }

	    /// <summary>
	    /// Restituisce la dir con lo / finale
	    /// </summary>
	    public static string removeStartReverseSlash(string dir) {
	        if (dir == null) return null;
	        if (!dir.StartsWith(@"/")) return dir;
	        return dir.Substring(1);
	    }

	    public static string Combine(params string []dir) {
	        string result = dir[0];
	        for (int i = 1; i < dir.Length; i++) {
	            if (result == "") {
	                result = removeStartReverseSlash(dir[i]);
                    continue;	                
	            }
	            result = CheckReverseFinalSlash(result) + removeStartReverseSlash(dir[i]);
	        }

	        return result;
	    }
	    public static string CheckBothReverseSlash(string dir) {	        
	        return CheckReverseStartSlash(CheckReverseFinalSlash(dir));
	    }
	    /// <summary>
	    /// Concatena il path dir2 (relativo) a dir1 (relativo o assoluto)
	    /// </summary>
	    /// <param name="dir1">path relativo o assoluto</param>
	    /// <param name="dir2">path relativo</param>
	    public static string ConcatFtpDir(string dir1, string dir2) {
	        if (dir1 == "" || dir1==null) return CheckReverseFinalSlash(dir2);
	        if (dir2 == "" || dir2==null) return dir1;
	        return CheckReverseFinalSlash(dir1)+removeStartReverseSlash(CheckReverseFinalSlash(dir2));
	    }

        /// <summary>
        /// remotedir non deve contenere il sito radice ma solo la parte relativa dentro di esso es. se www.site.com/dir1/dir2/ deve contenere solo /dir1/dir2/  o dir1/dir2 o simili
        /// </summary>
        /// <param name="f"></param>
        /// <param name="remotedir"></param>
        /// <returns></returns>
	    public bool checkDirectoryFtpCompleta(string remotedir) {
            if (remotedir == "" || remotedir == @"/") return true;
	        List<string> segmenti = remotedir.Split('/').ToList();
	        if (segmenti.Count == 0) return true; //non può creare niente
            if (segmenti[segmenti.Count-1]=="")segmenti.RemoveAt(segmenti.Count-1);
            if (segmenti.Count == 1) return CheckDir(segmenti[0]);

            for (int i = 0; i < segmenti.Count; i++) {
                string currDir = segmenti[i];
                if (!CheckDir(currDir))return false;    //Errore, bisogna fare i-1 ChangeDir("..")
                if (i < segmenti.Count - 1) {
                    if (!ChangeDir(currDir)) return false; //Errore, bisogna fare i-1 ChangeDir("..")
                }
            }

            for (int i = 0; i < segmenti.Count-1; i++) {
                ChangeDir("..");
            }
            return true;
        }
	    /// <summary>
	    /// Si posiziona sotto la sotto cartella subDir rispetto alla root
	    /// </summary>
	    /// <param name="dir"></param>
	    /// <returns>True se OK</returns>
	    public bool ChangeToRelativeDir(string dir) {
	        string msg="ChangeRelativeDir("+dir+")";
	        string relativeDir = null;
	        if (dir == "") {
	            relativeDir = CheckBothReverseSlash(rootDirectory);
	        }
	        else {
	            relativeDir = rootDirectory == null ? dir : CheckBothReverseSlash(rootDirectory) + dir;
	        }
	         
	        try {
	            m_FtpClient.ChDir(relativeDir);
	            return true;
	        }
	        catch (Exception E) {
	            SetLastError(msg, E);
	            return false;
	        }
	    }


		/// <summary>
		/// Cambia directory corrente del server ftp
		/// </summary>
		/// <param name="dir"></param>
		/// <returns>True se OK</returns>
		public bool ChangeDir(string dir) {
			string msg="ChangeDir("+dir+")";
			try {
				m_FtpClient.ChDir(dir);
				return true;
			}
			catch (Exception E) {
				SetLastError(msg, E);
				return false;
			}
		}


		/// <summary>
		/// Crea directory
		/// </summary>
		/// <param name="dir">directory</param>
		/// <returns>True se OK</returns>
		public bool CreateDir(string dir) {
			string msg="CreateDir("+dir+")";
			try {
			    var pieces = dir.Split('/');
			    string curr = "";
			    for (int i = 0; i < pieces.Length; i++) {
			        if (i > 0) curr += "/";
			        curr = curr + pieces[i];
			        try {
			            if (ChangeDir(dir)) return ChangeDir("..");     
			        }
			        catch (Exception e) {
			            var s = e.ToString();
			           
			        }
			        m_FtpClient.MkDir(curr);
			    }
				
				return true;
			}
			catch (Exception E) {
				SetLastError(msg, E);
				return false;
			}
		}

		/// <summary>
		/// Elimina directory
		/// </summary>
		/// <param name="dir">directory</param>
		/// <returns>True se OK</returns>
		public bool RemoveDir(string dir) {
			string msg="RemoveDir("+dir+")";
			try {
				m_FtpClient.RmDir(dir);
				return true;
			}
			catch (Exception E) {
				SetLastError(msg, E);
				return false;
			}
		}

		/// <summary>
		/// Restituisce la lista dei file contenuti nella dir
		/// </summary>
		/// <param name="dir">remote dir</param>
		public string[] DirFull(string dir) {
			string msg="DirFull("+dir+")";
			try {
				return m_FtpClient.Dir(dir,false);
			}
			catch (Exception E) {
				SetLastError(msg, E);
				return null;
			}
		}

		/// <summary>
		/// Chiuse la sessione ftp
		/// </summary>
		/// <returns>True se OK</returns>
		public bool Close() {
			string msg="Close()";
			try {
                m_IsConnected = false;
				m_FtpClient.Quit();
				return true;
			}
			catch {
				SetLastError(msg);
				return false;
			}
		}

		#endregion

		#region Gestione errore
		/// <summary>
		/// Imposta l'ultimo msg di errore
		/// </summary>
		/// <param name="error">msg</param>
		private void SetLastError(string error) {
			SetLastError(error,null);
		}

		/// <summary>
		/// Imposta l'ultimo msg di errore + eccezione
		/// </summary>
		/// <param name="error">msg</param>
		/// <param name="E">Exception</param>
		private void SetLastError(string error, Exception E) {
			m_LastError="Ftp Class: "+error;
			if (E!=null) m_LastError+=" - Dettaglio: "+E.Message;
		}
		/// <summary>
		/// Restituisce l'ultimo msg di errore
		/// </summary>
		/// <returns></returns>
		public string GetLastError() {
			string s=m_LastError;
			m_LastError=null;
			return s;
		}

		#endregion

	}
}
