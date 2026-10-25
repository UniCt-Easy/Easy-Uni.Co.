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
using System.IO;
using System.Reflection;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using metadatalibrary;

namespace LiveUpdate
{
	public class GenXML {

		static int DateToInt(DateTime t){
			return t.Year*10000+t.Month*100+t.Day;
		}
		static int TimeToInt(DateTime t){
			return t.Hour*10000+t.Minute*100+t.Second;
		}

		
        
        public static bool GeneraFileXML(			
			string TargetDir, 
			string XMLFileName, 
			string filter) {

			string errori = null;
			return GeneraFileXML(TargetDir, XMLFileName, filter, null, false, out errori);
		}

        public static bool GeneraFileXML(
           string TargetDir,
           string XMLFileName,
           string filter,bool filtraOggi) {

            string errori = null;
            return GeneraFileXML(TargetDir, XMLFileName, filter, null, filtraOggi, out errori);
        }


        public static bool GeneraFileXML(			
			string TargetDir, 
			string XMLFileName,
			string filter,
			Hashtable SkipList, bool filtraOggi,
			out string errori) {
            if (filter.ToLower()=="*.rpt") 
				return GeneraFileXMLReport(TargetDir, XMLFileName, SkipList, out errori);
			
			if (filter.ToLower()=="*.sql")
				return GeneraFileXMLSP(TargetDir,XMLFileName,SkipList, out  errori);
            if (filter.ToLower() == "*.rdl")
                return GeneraFileXMLRDL(TargetDir, XMLFileName, SkipList, out errori);

            return GeneraFileXMLDLL(TargetDir, XMLFileName, SkipList, filtraOggi, out errori);
		}
        public static void AzzeraIndicelocale() {
            ds = null;
        }
        public static DsDLLIndex GetIndicelocaleAggiornato() {
            return ds;
        }

        public static DsDLLIndex ds = null;

		private static bool GeneraFileXMLDLL(
			string DestDir, 
			string XMLFileName, 
			Hashtable SkipList, bool filtraOggi,
			out string ListaErrori) {

			if (!DestDir.EndsWith("\\")) DestDir += "\\";

			bool errori = false;
			ListaErrori = "";
            UpdateDLLThread.NMaxThread = 0;
            if (ds != null && SkipList == null) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Errore tipo 1 in GeneraFileXMLDLL");
                return false;  
            }
            if (ds == null && SkipList != null) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Errore tipo 2 in GeneraFileXMLDLL");
                return false;
            }

            if (ds != null && SkipList!=null) {
                ds.AcceptChanges();
                DataSet dsnew = ds.Copy();
                foreach (DataRow dr in dsnew.Tables["DLL"].Rows) {
                    string fname = dr["dllname"].ToString();
                    if (SkipList.Contains(fname) ) {
                        string[] oldversion = SkipList[fname].ToString().Split('.');
                        if (oldversion[0] == "NUOVO") {
                            dr.Delete();
                            continue;
                        }
                        dr["major"] = Convert.ToInt32(oldversion[0]);
                        dr["minor"] = Convert.ToInt32(oldversion[1]);
                        dr["build"] = Convert.ToInt32(oldversion[2]);
                    }
                }
                dsnew.Tables["DLL"].AcceptChanges();

                dsnew.WriteXml(DestDir + XMLFileName);
                XZip.AddFiles(DestDir + XMLFileName + ".zip", DestDir, XMLFileName, true, false);
                return true;
            }

            ds = new DsDLLIndex();
            DataTable dt = ds.DLL;
		    
		    List<string> ext = new List<string>(new string[] {".cer",".exe", ".dat", ".pdf", ".sql", ".mht", ".xml", ".xslt", ".xsd",".dll",".rdl",".pfx", ".p12"});
            DirectoryInfo d = new DirectoryInfo(DestDir);

            try {
                foreach (FileInfo f5 in d.GetFiles("*.*")) {
		            string thisExt = f5.Extension.ToLowerInvariant();
		            if (!ext.Contains(thisExt)) continue;
                    if (filtraOggi) {
                        if (f5.LastWriteTime.ToShortDateString() != DateTime.Now.ToShortDateString()) continue;
                    }
		            if (thisExt == ".xml" && !(f5.Name.ToLower().StartsWith("system_"))) continue;

		            if (f5.Name.ToLower().EndsWith(".vshost.exe") ) continue;
                    if (f5.Name.ToLower() == "loaderstampe.exe") continue;
                    if (f5.Name.ToLower() == "loaderconsole.exe") continue;
                    if (f5.Name.ToLower() == "loader.exe") continue;
                    if (f5.Name.ToLower() == "liveupdatesync.exe") continue;
                    if (f5.Name.ToLower() == "liveupdatesyncservice.exe") continue;

                    try {
		                DataRow dr = dt.NewRow();
		                if (SkipList != null && SkipList[f5.Name] != null) {
                            string[] oldversion = SkipList[f5.Name].ToString().Split('.');
		                    if (oldversion[0] == "NUOVO") continue;

		                    dr["dllname"] = f5.Name;
		                    dr["major"] = Convert.ToInt32(oldversion[0]);
		                    dr["minor"] = Convert.ToInt32(oldversion[1]);
		                    dr["build"] = Convert.ToInt32(oldversion[2]);
		                }
		                else {
		                    if (thisExt == ".dll") {
                                int h = metaprofiler.StartTimer("GetAssemblyName("+ f5.Name+")");
                                FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(f5.FullName);
                                metaprofiler.StopTimer(h);
		                        
                                



                                dr["dllname"] = f5.Name;
                                dr["major"] = myFileVersionInfo.ProductMajorPart;
                                dr["minor"] = myFileVersionInfo.ProductMinorPart;
                                int N = myFileVersionInfo.ProductBuildPart;
                                if (N > 999) N = 0;
                                dr["build"] = N;
                            }
		                    else {
                                DateTime upd = f5.LastWriteTime.ToUniversalTime();
		                        dr["dllname"] = f5.Name;
		                        dr["major"] = DateToInt(upd);
		                        dr["minor"] = TimeToInt(upd);
		                        dr["build"] = 0;
		                    }
		                }
		                dt.Rows.Add(dr);
		            }
		            catch (Exception e) {
		                if (ListaErrori.Length < 1000)
		                    ListaErrori += "\r Nome file: " + f5.Name + " - Msg: " + e.Message;
		                errori = true;
		                continue;
		            }
		        }




		        ds.AcceptChanges();

		        ds.WriteXml(DestDir + XMLFileName);
		        XZip.AddFiles(DestDir + XMLFileName + ".zip", DestDir, XMLFileName, true, false);
		        return (!errori);
		    }
		    catch (Exception e) {
		        ListaErrori += "\r" + e.Message;
		        return false;
		    }


		}
        private static bool GeneraFileXMLRDL(
            string DestDir,
            string XMLFileName,
            Hashtable SkipList,
            out string ListaErrori) {

            if (!DestDir.EndsWith("\\")) DestDir += "\\";

            bool errori = false;
            ListaErrori = "";
            try {
                DsDLLIndex ds = new DsDLLIndex();
                DataTable dt = ds.DLL;
                DirectoryInfo d = new DirectoryInfo(DestDir);
                foreach (FileInfo f4 in d.GetFiles("*.rdl")) {
                    try {
                        DataRow dr = dt.NewRow();
                        if (SkipList != null && SkipList[f4.Name] != null) {
                            string[] oldversion = SkipList[f4.Name].ToString().Split('.');
                            if (oldversion[0] == "NUOVO") continue;

                            dr["dllname"] = f4.Name;
                            dr["major"] = oldversion[0];
                            dr["minor"] = oldversion[1];
                            dr["build"] = oldversion[2];
                        }
                        else {
                            DateTime upd = f4.LastWriteTime.ToUniversalTime();
                            dr["dllname"] = f4.Name;
                            dr["major"] = DateToInt(upd);
                            dr["minor"] = TimeToInt(upd);
                            dr["build"] = 0;
                        }
                        dt.Rows.Add(dr);
                    }
                    catch (Exception e) {
                        ListaErrori += "\r" + e.Message;
                        errori = true;
                        continue;
                    }
                }
                ds.WriteXml(DestDir + XMLFileName);
                XZip.AddFiles(DestDir + XMLFileName + ".zip", DestDir, XMLFileName, true, false);
                return (!errori);
            }
            catch (Exception e) {
                ListaErrori += "\r" + e.Message;
                return false;
            }
        }

	    public static void getVersion(DataRow r, FileInfo f,string relativeName) {
	        string ext = f.Extension?.ToLowerInvariant();
	        
	        if (ext == ".dll") {
	            FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(f.FullName);
	            r["dllname"] = relativeName;
	            r["major"] = myFileVersionInfo.ProductMajorPart;
	            r["minor"] = myFileVersionInfo.ProductMinorPart;
	            int N = myFileVersionInfo.ProductBuildPart;
	            if (N > 999) N = 0;
	            r["build"] = N;
	            return;
	        }
	    
	        DateTime upd = f.LastWriteTime.ToUniversalTime();
	        r["dllname"] = relativeName;
	        r["major"] = DateToInt(upd);
	        r["minor"] = TimeToInt(upd);
	        r["build"] = 0;
	        return;
	    }

	    public static bool GeneraFileIndiceGenerico(
	        string DirectoryToScan,
	        string xmlIndexFileName,
	        IEnumerable<string> folders,
	        Hashtable filesToSkip,
	        IEnumerable<string> filters,
	        List<string> allowedExtensions,
            bool filtraOggi,
	        out string ListaErrori
	    ) {

	        if (!DirectoryToScan.EndsWith("\\")) DirectoryToScan += "\\";
	        ListaErrori = "";

            List<string> elencoDir = new List<string>();
            if (folders!=null) elencoDir= (from fileName in folders select Path.Combine(DirectoryToScan, fileName)).ToList();
	        elencoDir.Insert(0, "");
	        try {
	            DsDLLIndex ds = new DsDLLIndex();
	            DataTable dt = ds.DLL;
	            foreach (string destFolder in elencoDir) {

	                string combinedFolder = DirectoryToScan;

	                if (destFolder != "") combinedFolder = destFolder;

	               
	                DirectoryInfo d = new DirectoryInfo(combinedFolder);
	                if (!Directory.Exists(combinedFolder)) continue;

	                foreach (string filter in filters) {
	                    foreach (FileInfo f3 in d.GetFiles(filter)) {
	                        var RelativeName = f3.Name;
	                        if (destFolder != "") {
	                            RelativeName=f3.FullName.Substring(DirectoryToScan.Length);
	                        }                            
	                        string thisExt = f3.Extension.ToLowerInvariant();
	                        if (!allowedExtensions.Contains(thisExt)) continue;
	                        if (filtraOggi) {
	                            if (f3.LastWriteTime.ToShortDateString() != DateTime.Now.ToShortDateString()) continue;
	                        }

	                        try {
	                            DataRow dr = dt.NewRow();
	                            if (filesToSkip != null && filesToSkip[RelativeName] != null) {
	                                string[] oldversion = filesToSkip[RelativeName].ToString().Split('.');
	                                if (oldversion[0] == "NUOVO") continue;
									dr["dllname"] = destFolder==""? f3.Name:RelativeName;
	                                dr["major"] = oldversion[0];
	                                dr["minor"] = oldversion[1];
	                                dr["build"] = oldversion[2];
	                            }
	                            else {
	                                getVersion(dr, f3,RelativeName);
	                            }

	                            dt.Rows.Add(dr);
	                        }
	                        catch (Exception e) {
	                            ListaErrori += "\r" + e.Message;
	                            continue;
	                        }
	                    }
	                }
	            }
	            string indexName = Path.Combine(DirectoryToScan, xmlIndexFileName);
	            ds.WriteXml(indexName);
	            XZip.AddFiles(indexName + ".zip", DirectoryToScan, xmlIndexFileName, true, false);
	            return (ListaErrori.Length == 0);
	        }
	        catch (Exception e) {
	            ListaErrori += "\r" + e.Message;
	            return false;
	        }
	    }

	    private static bool GeneraFileXMLReport(
			string DestDir, 
			string XMLFileName, 
			Hashtable SkipList,
			out string ListaErrori) {

			if (!DestDir.EndsWith("\\")) DestDir += "\\";

			bool errori = false;
			ListaErrori = "";
			try {
				DsDLLIndex ds = new DsDLLIndex();
				DataTable dt = ds.DLL;
				DirectoryInfo d = new DirectoryInfo(DestDir);
				foreach (FileInfo f3 in d.GetFiles("*.rpt")) {
					try {
                        DataRow dr = dt.NewRow();
						if (SkipList!=null && SkipList[f3.Name]!=null) {
							string[] oldversion = SkipList[f3.Name].ToString().Split('.');
							if (oldversion[0]=="NUOVO") continue;

                            dr["dllname"] = f3.Name;
							dr["major"] = oldversion[0];
							dr["minor"]  = oldversion[1];
							dr["build"]  = oldversion[2];
						}
						else {
							DateTime upd = f3.LastWriteTime.ToUniversalTime();
							dr["dllname"]  = f3.Name;
							dr["major"]  = DateToInt(upd);
							dr["minor"]  = TimeToInt(upd);
							dr["build"]  = 0;
						}
						dt.Rows.Add(dr);
					}
					catch (Exception e) {
						ListaErrori += "\r" + e.Message;
						errori = true;
						continue;
					}
				}
				ds.WriteXml(DestDir + XMLFileName);
				XZip.AddFiles(DestDir + XMLFileName + ".zip", DestDir, XMLFileName, true, false);
				return (!errori);
			}
			catch  (Exception e) {
				ListaErrori += "\r" + e.Message;
				return false;
			}
		}
         
		private static bool GeneraFileXMLSP(
			string DestDir, 
			string XMLFileName, 
			Hashtable SkipList,
			out string ListaErrori) {

			if (!DestDir.EndsWith("\\")) DestDir += "\\";

			bool errori = false;
			ListaErrori = "";
			try {
				DsDLLIndex ds = new DsDLLIndex();
				DataTable dt = ds.DLL;
				DirectoryInfo d = new DirectoryInfo(DestDir);
				foreach (FileInfo f2 in d.GetFiles("*.sql")) {
					try {
                        DataRow dr = dt.NewRow();
						if (SkipList!=null && SkipList[f2.Name]!=null) {
							string[] oldversion = SkipList[f2.Name].ToString().Split('.');
							if (oldversion[0]=="NUOVO") continue;

							dr["dllname"] = f2.Name;
							dr["major"] = oldversion[0];
							dr["minor"] = oldversion[1];
							dr["build"] = oldversion[2];
						}
						else {
							DateTime upd = f2.LastWriteTime;
							dr["dllname"]= f2.Name;
							dr["major"] = DateToInt(upd);
							dr["minor"] = TimeToInt(upd);
							dr["build"] = 0;
						}
						dt.Rows.Add(dr);
					}
					catch (Exception e) {
						ListaErrori += "\r Nome file: " + f2.Name + " - Msg: " + e.Message;
						errori = true;
						continue;
					}
				}
				ds.WriteXml(DestDir + XMLFileName);
				XZip.AddFiles(DestDir + XMLFileName + ".zip", DestDir, XMLFileName, true, false);
				return (!errori);
			}
			catch  (Exception e) {
				ListaErrori += "\r" + e.Message;
				return false;
			}
		}
	}
    public class UpdateDLLThread {
        static object mm = new object();
        public static EventHandler EH = null;
        public static int GetNthread(){
            int N;
                N = NThread;
            return N;
        }
        public static int NThread = 0;
        public static int NMaxThread = 0;
        string DestDir;
        string fName;
        DataTable dt;
        public UpdateDLLThread(string DestDir,string fName,DataTable dt) {
            this.DestDir = DestDir;
            this.fName = fName;
            this.dt = dt;
            NMaxThread++;
            int N = 0;
            lock (mm) {
                N=NThread++;
            }
            if (EH!=null) EH.Invoke(new NThreadsDLL(N), null);

        }

        public class NThreadsDLL {
            public int N;
            public int NMax;
            public NThreadsDLL(int N) {
                this.N = N;
            }
        }
        public void Run() {
            
            Assembly a = Assembly.ReflectionOnlyLoadFrom(DestDir + fName);
            AssemblyName an = a.GetName();
            Version ver = an.Version;
            int N=0;
            lock (mm) {
                DataRow dr = dt.NewRow();

                dr["dllname"] = fName;
                dr["major"] = ver.Major;
                dr["minor"] = ver.Minor;
                if (ver.Build > 999)
                    dr["build"] = 0;
                else
                    dr["build"] = ver.Build;
                
                    N=NThread--;
                    dt.Rows.Add(dr);
                }
            
            if (EH!=null) EH.Invoke(new NThreadsDLL(N), null);
        }
    }
}
