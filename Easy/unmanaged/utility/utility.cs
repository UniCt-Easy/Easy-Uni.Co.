
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using Xceed.Zip;
using Xceed.Compression;
using Xceed.FileSystem;
using System.IO;
using System.Text;
using metadatalibrary;
using System.Collections;
using System.Data;

namespace utility//utility//
{
	/// <summary>
	/// Classe che gestisce operazioni su script SQL da eseguire
	/// </summary>
	public class XDatabase {

		private const int C_SQLCOMMANDTIMEOUT = 600;

		/// <summary>
		/// Divide l'intero script in una serie di comandi
		/// </summary>
		/// <param name="script">testo dello script</param>
		/// <returns>Array di comandi</returns>
		public static ArrayList DivideScript(StringBuilder script){
			ArrayList CmdList= new ArrayList();
			StringReader Sread= new StringReader(script.ToString());
			string currline;
			StringBuilder Cmd=null;
			while ((currline = Sread.ReadLine())!=null){
				if (currline.TrimEnd().ToUpper()=="GO"){
					if (Cmd!=null) CmdList.Add(Cmd);
					Cmd=null;
					continue;
				}
				if (Cmd==null)
					Cmd = new StringBuilder(currline);
				else
					Cmd.Append("\n"+currline);
			}
			if (Cmd!=null && Cmd.ToString()!="") CmdList.Add(Cmd);
			return CmdList;
		}

		/// <summary>
		/// Esegue il comando di uno script
		/// </summary>
		/// <param name="cmd">comando da eseguire</param>
		/// <param name="Conn">Connessione</param>
		/// <returns>True se va a buon fine</returns>
		public static bool RunScriptCmd(DataAccess Conn, string cmd) {
			DataTable T = Conn.SQLRunner(cmd,true,C_SQLCOMMANDTIMEOUT);
			return (T != null);
		}

		/// <summary>
		/// Esegue lo script sql
		/// </summary>
		/// <param name="Conn">Connessione</param>
		/// <param name="script">testo dello script</param>
		/// <returns>True se l'esecuzione va a buon fine</returns>
		public static bool RUN_SCRIPT(DataAccess Conn, StringBuilder script) {
			ArrayList CmdList = DivideScript(script);
			for (int i=0; i < CmdList.Count; i++) {
				if (!RunScriptCmd(Conn, CmdList[i].ToString())) return false;
			}
			return true;
		}
	}

	/// <summary>
	/// Classe che gestisce operazioni comuni su file
	/// </summary>
	public class XFile {
		/// <summary>
		/// Legge un file di testo e lo restituisce in una stringa
		/// </summary>
		/// <param name="filename">file da leggere</param>
		public static StringBuilder LeggiTestoScript(string filename) {
			StringBuilder text = new StringBuilder();
			string currline;
			StreamReader Sread = new StreamReader(filename,System.Text.Encoding.Default);
			while ((currline = Sread.ReadLine())!=null) {
				text.Append(currline + "\n");
			}
			Sread.Close();

			return text;
		}

		
		/// <summary>
		/// Copia un file. Restituisce null se ok, o msg di errore
		/// </summary>
		/// <param name="source">sorgente</param>
		/// <param name="dest">destinazione</param>
		/// <param name="overwrite">true per sovrascrivere anche se è read-only</param>
		/// <returns>null se va a buon fine altrimenti msg di errore</returns>
		public static string Copia(string source, string dest, bool overwrite) {
			string msg="XFile.Copia("+source+", "+dest+", "+overwrite.ToString()+")";
			try {
				if (overwrite) {
					if (File.Exists(dest)) File.SetAttributes(dest,FileAttributes.Archive);
				}
				File.Copy(source,dest,overwrite);
				return null;
			}
			catch (Exception E) {
				return msg+" - "+E.Message;
			}
		}


		/// <summary>
		/// Elimina la proprietà read-only di un file
		/// </summary>
		/// <param name="path">full path del file</param>
		/// <returns>null se va a buon fine altrimenti msg di errore</returns>
		public static string EliminaSolaLettura(string path) {
			string msg="XFile.EliminaSolaLettura("+path+")";
			try {
				if (File.Exists(path)) File.SetAttributes(path,FileAttributes.Archive);
				return null;
			}
			catch (Exception E) {
				return msg+" - "+E.Message;
			}
		}
	}

	/// <summary>
	/// Classe che gestisce operazioni comuni su Directory
	/// </summary>
	public class XDir {
		
		/// <summary>
		/// Copia una cartella
		/// </summary>
		/// <param name="source">path sorgente</param>
		/// <param name="dest">path destinazione (può anche non esistere)</param>
		/// <returns>null se va a buon fine altrimenti msg di errore</returns>
		public static string Copia(string source, string dest) {
			string msg="XDir.Copia("+source+", "+dest+")";
			try {
				DirectoryInfo DI=new DirectoryInfo(source);
				CheckCreate(source);
				foreach (FileInfo F in DI.GetFiles()) {
					XFile.Copia(F.FullName, dest+@"\"+F.Name,true);
				}
				return null;
			}
			catch (Exception E) {
				return msg+" - "+E.Message;
			}
		}


		/// <summary>
		/// Copia una cartella
		/// </summary>
		/// <param name="source">path sorgente</param>
		/// <param name="dest">path destinazione (può anche non esistere)</param>
		/// <returns>null se va a buon fine altrimenti msg di errore</returns>
		public static string Copia(string source, string dest, string pattern) {
			string msg="XDir.Copia("+source+", "+dest+", "+pattern+")";
			try {
				DirectoryInfo DI=new DirectoryInfo(source);
				CheckCreate(source);
				foreach (FileInfo F in DI.GetFiles()) {
					XFile.Copia(F.FullName, dest+@"\"+F.Name,true);
				}
				return null;
			}
			catch (Exception E) {
				return msg+" - "+E.Message;
			}
		}


		/// <summary>
		/// Controlla se la directory è di sola lettura (se non esiste viene restituito True)
		/// </summary>
		/// <param name="dir">path della cartella</param>
		/// <returns>True se readonly o inesistente</returns>
		public static bool IsReadOnly(string dir) {
			try {
				//esistenza
				if (!Directory.Exists(dir)) return true;
				Directory.CreateDirectory(dir+@"\~t");
				Directory.Delete(dir+@"\~t");
				return false;
			}
			catch {
				//directory di sola lettura o inesistente
				return true;
			}
		}

		/// <summary>
		/// Elimina solo i file nella directory (anche se ci sono file read-only)
		/// </summary>
		/// <param name="dir">full path</param>
		/// <returns>True se OK</returns>
		public static bool Svuota(string dir) {
			return Svuota(dir, false);
		}

		/// <summary>
		/// Elimina il contenuto della directory (anche se ci sono file read-only)
		/// </summary>
		/// <param name="dir">full path</param>
		/// <param name="recursive">se True elimina anche le sottocartelle</param>
		/// <returns>True se OK</returns>
		public static bool Svuota(string dir, bool recursive) {
			try {
				if (!CheckCreate(dir)) return false;
				DirectoryInfo D = new DirectoryInfo(dir);
				if (recursive) {
					foreach (DirectoryInfo Dsub in D.GetDirectories()) {
						if (!Svuota(Dsub.FullName, true)) return false;
						Dsub.Attributes=FileAttributes.Normal;
						Dsub.Delete(false);
					}
				}
				foreach (FileInfo F in D.GetFiles()) {
					File.SetAttributes(F.FullName,FileAttributes.Archive);
					File.Delete(F.FullName);
				}
				return true;
			}
			catch (Exception E) {
				System.Diagnostics.Debug.WriteLine("XDir.Svuota("+dir+", "+recursive.ToString()+") - Errore: "+E.Message);
				return false;
			}
		}

		/// <summary>
		/// Se non esiste crea la directory. Funziona anche con directory annidate
		/// </summary>
		/// <param name="dir">full path</param>
		/// <returns>True se OK</returns>
		public static bool CheckCreate(string dir) {
			try {
				if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
				return true;
			}
			catch (Exception E) {
				System.Diagnostics.Debug.WriteLine("XDir.CheckCreate("+dir+") - Errore: "+E.Message);
				return false;
			}
		}

		/// <summary>
		/// Restituisce la dir con lo \ finale
		/// </summary>
		public static string CheckFinalSlash(string dir) {
			if (dir.EndsWith(@"\")) return dir;
			return dir+=@"\";
		}

		/// <summary>
		/// Concatena il path dir2 (relativo) a dir1 (relativo o assoluto)
		/// </summary>
		/// <param name="dir1">path relativo o assoluto</param>
		/// <param name="dir2">path relativo</param>
		public static string Concat(string dir1, string dir2) {
			return CheckFinalSlash(dir1)+CheckFinalSlash(dir2);
		}
	}

	/// <summary>
	/// Classe che gestisce operazioni su date
	/// </summary>
	public class XDateTime {
		/// <summary>
		/// Data in formato intero, necessario per i confronti di versione
		/// </summary>
		public static int DateToInt(DateTime t){
			return t.Year*10000+t.Month*100+t.Day;
		}
		/// <summary>
		/// Time in formato intero, necessario per i confronti di versione
		/// </summary>
		public static int TimeToInt(DateTime t){
			return t.Hour*10000+t.Minute*100+t.Second;
		}
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

			//controllo cartella sorgente
			if (sourceFolder.Length == 0)
				sourceFolder = AppDomain.CurrentDomain.BaseDirectory;
			//Set attribute file to normal
			File.SetAttributes(sourceFolder + "\\" + fileMask, FileAttributes.Normal);
			// Create a DiskFile object for the specified zip filename
			DiskFile zipFile = new DiskFile(zipFilename);
			// Check if the file exists
			if (!zipFile.Exists) zipFile.Create();
			// Create a ZipArchive object to access the zipfile.
			ZipArchive zip = new ZipArchive(zipFile);
            zip.DefaultCompressionMethod = CompressionMethod.Deflated64;
			// Create a DiskFolder object for the source folder
			DiskFolder source = new DiskFolder(sourceFolder);
			// Copy the contents of the zip to the destination folder.
			source.CopyFilesTo(zip, recursive, replaceFiles, fileMask );      
		}

		/// <summary>
		/// Archivia tutti i file presenti in sourcedir in destdir
		/// </summary>
		/// <param name="sourcedir">cartella dei file da zippare</param>
		/// <param name="destdir">cartella destinazione</param>
		/// <param name="fileMask">filtro (*.sql, *.exe, *.* = null)</param>
		/// <param name="replaceFiles">True per sostituire file esistenti</param>
		/// <param name="recursive">Specifies if the files in the sub-folders of <paramref name="sourceFolder"/> should also be added.</param>
		public static void AddAllFiles(string sourcedir, string destdir, string fileMask, bool replaceFiles, bool recursive) {
			if (fileMask==null || fileMask.Trim()=="") fileMask="*,*";
			XDir.CheckCreate(destdir);
			DirectoryInfo D=new DirectoryInfo(sourcedir);
			foreach (FileInfo F in D.GetFiles(fileMask)) {
				AddFiles(destdir+F.Name+".zip",sourcedir,F.Name,true,true);
			}
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
			zip.CopyFilesTo(destinationFolder, recursive, replaceFiles, fileMask);
		}

		/// <summary>
		/// Estrae tutti i file presenti in sourcedir in destdir
		/// </summary>
		/// <param name="sourcedir">cartella dei file da zippare</param>
		/// <param name="destdir">cartella destinazione</param>
		/// <param name="fileMask">filtro (*.sql, *.exe, *.* = null)</param>
		/// <param name="replaceFiles">True per sostituire file esistenti</param>
		/// <param name="recursive">Specifies if the files in the sub-folders of <paramref name="sourceFolder"/> should also be added.</param>
//		public static void ExtractAllFiles(string sourcedir, string destdir, string fileMask, bool replaceFiles, bool recursive) {
//			if (fileMask==null || fileMask.Trim()=="") fileMask="*.*";
//			XDir.CheckCreate(destdir);
//			DirectoryInfo D=new DirectoryInfo(sourcedir);
//			foreach (FileInfo F in D.GetFiles(fileMask)) {
//				ExtractFiles(F.FullName,destdir,fileMask,true,true);
//			}
//		}

		#endregion
	}
}
