/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
using System.Collections;
using System.Xml;

namespace colname_default//colname//
{
	/*
	public IEnumerator GetEnumerator() 
	public void Reset() 
	public bool MoveNext() 
	public Object Current 
	*/

	#region Progetto

/// <summary>
/// Classe contenente informazioni relative ad un progetto di una solution
/// </summary>
	public class Progetto 
	{
		public string csProj;
		public DirectoryInfo oldDir;
		DirectoryInfo newDirSln;
		public string idSolution, progetto, relPath, idProgetto;
		XmlDocument doc = new XmlDocument();

/// <summary>
///
/// </summary>
/// <param name="oldDirSln">Directory della vecchia solution</param>
/// <param name="newDirSln">Directory della nuova solution</param>
/// <param name="line">linea della vecchia solution contenente informazioni di questo progetto</param>
		public Progetto (DirectoryInfo oldDirSln, DirectoryInfo newDirSln, string line) 
		{
			int fine1 = line.IndexOf('"', 53);
			int inizio2 = fine1 + 4;
			int fine2 = line.IndexOf('"', inizio2);

			this.idSolution = line.Substring(9, 38);
			this.progetto = line.Substring(53, fine1 - 53);
			this.relPath = line.Substring(inizio2, fine2-inizio2);
			this.idProgetto = line.Substring(fine2 + 4, 38);

			this.newDirSln = newDirSln;

			this.csProj = Path.Combine(oldDirSln.FullName, relPath);
			this.oldDir = new DirectoryInfo(Path.GetDirectoryName(csProj));

			doc.Load(csProj);

			XmlElement settings = (XmlElement) doc.SelectSingleNode("VisualStudioProject/CSHARP/Build/Settings");
			if (settings.GetAttribute("StartupObject")=="CompEc.frmMain") 
			{
				settings.SetAttribute("StartupObject", "mainform.frmMain");
			}
		}

		public XmlNodeList config
		{
			get 
			{
				return doc.SelectNodes("VisualStudioProject/CSHARP/Build/Settings/Config");
			}
		}

/*		public XmlNodeList riferimentiAiProgetti 
		{
			get 
			{
				return doc.SelectNodes("VisualStudioProject/CSHARP/Build/References/Reference[@Project]");
			}
		}*/

		public XmlNodeList riferimenti
		{
			get 
			{
				return doc.SelectNodes("VisualStudioProject/CSHARP/Build/References/Reference");
			}
		}

		public void rimuoviRiferimento(string idRiferimento) 
		{
			XmlNode references = doc.SelectSingleNode("VisualStudioProject/CSHARP/Build/References");
			if (references==null){
				string SSS2="jKJK";
				Console.WriteLine(SSS2);
				System.Windows.Forms.MessageBox.Show("Non ho trovato il node references!");
				return ;
			}

			XmlNode rifDaCancellare = references.SelectSingleNode("Reference[@Project='" + 
				idRiferimento + "']");

			if (rifDaCancellare==null){
				string SSS="jKJK";
				Console.WriteLine(SSS);
				System.Windows.Forms.MessageBox.Show("Non ho trovato il node da cancellare!");
				return ;
			}
			references.RemoveChild(rifDaCancellare);
			return;
		}

		public XmlNode rimuoviFileIncluso(string relPath) {
			XmlNode include = doc.SelectSingleNode("VisualStudioProject/CSHARP/Files/Include");
			XmlNode file = include.SelectSingleNode("File[@RelPath='" + relPath + "']");
			return include.RemoveChild(file);
		}

		public XmlNodeList fileInclusi 
		{
			get
			{
				return doc.SelectNodes("VisualStudioProject/CSHARP/Files/Include/File");
			}
		}

/*		public XmlNodeList altriRiferimenti 
		{
			get 
			{
				return doc.SelectNodes("VisualStudioProject/CSHARP/Build/References/Reference[@HintPath]");
			}
		}*/

		private string assemblyName 
		{
			set 
			{
				XmlElement nodo = (XmlElement) doc.SelectSingleNode("VisualStudioProject/CSHARP/Build/Settings");
				nodo.SetAttribute("AssemblyName", value);
			}
		}

		private string rootNamespace 
		{
			set
			{
				XmlElement nodo = (XmlElement) doc.SelectSingleNode("VisualStudioProject/CSHARP/Build/Settings");
				nodo.SetAttribute("RootNamespace", value);
			}
		}

/// <summary>
/// Salva questo progetto in un file csproj 
/// </summary>
/// <param name="cartella">nuova directory del progetto</param>
/// <param name="nome">nuovo nome del progetto (senza estensione .csproj)</param>
		public void salvaConNome(string cartella, string nome) 
		{
			assemblyName = nome;
			rootNamespace = nome;
			progetto = nome;
			relPath = Path.Combine(cartella, nome + ".csproj");
			doc.Save(Path.Combine(newDirSln.FullName, relPath));
		}
		
		public override string ToString() 
		{
			string line = "Project(\""
				+ idSolution
				+ "\") = \""
				+ progetto
				+ "\", \""
				+ relPath
				+ "\", \""
				+ idProgetto
				+ "\"";
			return line;
		}
	}

	#endregion

	#region Solution

	/// <summary>
	/// Classe che permette di scorrere una solution restituendo in maniera sequenziale
	/// i vari progetti e contemporaneamente crea una nuova solution con le eventuali
	/// modifiche apportate ai progetti restituiti.
	/// </summary>
	public class Solution : IEnumerable, IEnumerator
	{
		FileInfo oldSolution;
		FileInfo newSolution;
		StreamReader sr;
		StreamWriter sw;
		bool primo;
		string line;
		Progetto progettoCorrente;

/// <summary>
/// Costruisce un'oggetto solution che scorre una vecchia solution restituendo i vari progetti
/// in essa contenuta e crea una nuova solution con tali progetti eventualmente esternamente
/// modificati
/// </summary>
/// <param name="solution">file contenente la vecchia solution</param>
/// <param name="newDir">directory in cui verrà memorizzata la nuova solution</param>
		public Solution(FileInfo oldSolution, FileInfo newSolution) 
		{
			this.oldSolution = oldSolution;
			this.newSolution = newSolution;
			Reset();
		}

		public void Reset() 
		{
			primo = true;
		}

		public IEnumerator GetEnumerator() 
		{
			return this;
		}

/// <summary>
/// Memorizza nella nuova solution l'ultimo progetto restituito precedentemente 
/// da una chiamata a Current
/// e sposta l'enumeratore al successivo progetto presente nella vecchia solution
/// </summary>
/// <returns></returns>
		public bool MoveNext() 
		{
			if (primo) 
			{
				sr = oldSolution.OpenText();
				newSolution.Directory.Create();
				sw = newSolution.CreateText();
				sw.WriteLine(sr.ReadLine());
				line = sr.ReadLine();
				primo = false;
			}
			else 
			{
				sw.WriteLine(progettoCorrente.ToString());
				sw.WriteLine(sr.ReadLine());
				sw.WriteLine(sr.ReadLine());
				sw.WriteLine(sr.ReadLine());
				line = sr.ReadLine();
				if ((line.Length>=70)&&(line.Substring(53,17)=="SetupCrystalMerge")) 
				{
					sw.WriteLine(line);
					sw.WriteLine(sr.ReadLine());
					sw.WriteLine(sr.ReadLine());
					sw.WriteLine(sr.ReadLine());
					line = sr.ReadLine();
				}
			}
			bool ciSonoAltriProgetti = line.StartsWith("Project(\"{");
			if (!ciSonoAltriProgetti) 
			{
				sw.WriteLine(line);
				sw.Write(sr.ReadToEnd());
				sw.Close();
				sr.Close();
			}
			return ciSonoAltriProgetti;
		}
/// <summary>
/// Restituisce il progetto corrente
/// </summary>
		public Object Current 
		{
			get 
			{
				progettoCorrente = new Progetto(oldSolution.Directory, newSolution.Directory, line);
				return progettoCorrente;
			}
		}

		public static int contaProgetti(FileInfo solution) 
		{
			StreamReader sr = solution.OpenText();
			int progetti = 0;
			string line = sr.ReadLine();
			while ((line = sr.ReadLine()).StartsWith("Project(\"{")) 
			{
				progetti ++;
				line = sr.ReadLine();
				line = sr.ReadLine();
				line = sr.ReadLine();
			}
			return progetti;
		}

		public static int setMainformFirst(FileInfo solution) 
		{
			StreamReader sr = solution.OpenText();
			StringWriter sw = new StringWriter();
			string mainform = "";
			int contaProgetti = 0;
			string intestazione = sr.ReadLine();
			string line = sr.ReadLine();
			while (line.StartsWith("Project(\"{")) 
			{
				if ((line.Length<70)||(line.Substring(53,17) != "SetupCrystalMerge")) 
				{
					contaProgetti ++;
				}
				if (line.Substring(53, 9) == "mainform\"") 
				{
					mainform = line + "\r\n" + sr.ReadLine() + "\r\n" + sr.ReadLine() + "\r\n" + sr.ReadLine();
				}
				else 
				{
					sw.WriteLine(line);
					sw.WriteLine(sr.ReadLine());
					sw.WriteLine(sr.ReadLine());
					sw.WriteLine(sr.ReadLine());
				}
				line = sr.ReadLine();
			}
			sw.WriteLine(line);
			sw.Write(sr.ReadToEnd());
			sr.Close();
			solution.Attributes = FileAttributes.Archive;
			StreamWriter fsw = solution.CreateText();
			fsw.WriteLine(intestazione);
			fsw.WriteLine(mainform);
			fsw.WriteLine(sw.ToString());
			fsw.Close();
			return contaProgetti;
		}
	}
	
	#endregion

	public class SkipComments {

		public static string GetNextIdentifier(string S, int start){
			int pos=start;
			while ((Char.IsLetterOrDigit(S[pos]) || (S[pos]=='_'))&& (pos<S.Length))pos++;
			return S.Substring(start,pos-start);
		}

		//Cerca la chiusura di una stringa tramite il carattere di stop non preceduto da uno slash
		public static int closedString(string S, int start,char stop){
			int index=start;
			while (index<S.Length){
				if (S[index]=='\\'){
					index++;
					index++;
					continue;
				}
				if (S[index]==stop){
					return index+1;
				}
				index++;
			}
			return -1;
		}

		/// <summary>
		/// Restitisce la posizione della fine di un blocco, saltando i blocchi annidati 
		///	 o -1 se il blocco non si chiude
		/// </summary>
		/// <param name="S"></param>
		/// <param name="start"></param>
		/// <param name="BEGIN"></param>
		/// <param name="END"></param>
		/// <returns></returns>
		public static int closeBlock(string S, int start, char BEGIN,char END){
			int index=start;
			int level=1;
			while ((index>=0)&&(index<S.Length)){
				index= nextNonComment(S,index);
				if (index<0) return -1;
				char C=S[index];
				if (C=='"'){
					index= closedString(S,index+1,'"');
					continue;
				}
				if (C=='\''){
					index= closedString(S,index+1,'\'');
					continue;
				}
				if (C==BEGIN){
					level++;
					index++;
					continue;
				}
				if (C==END){
					level--;
					index++;
					if(level==0) return index;
					continue;
				}							
				index++;
			}
			return -1;
		}
		public static int closedComment(string S,int start){
			if (S.IndexOf("*/",start)<0) return -1;
			return S.IndexOf("*/",start)+2;
		}


		public static bool IsInsideComment(string S, int start, int pos){
			int index=start;
			while ((index<S.Length)&&(index>=0)){
				char C=S[index];
				//Salta i commenti normali
				if (C=='/'){
					try {
						//vede se è un commento normale ossia /* asas */
						if (S[index+1]=='*'){
							index= closedComment(S,index+2);
							if (pos<index) return true;
							continue;
						}
						if (S[index+1]=='/'){
							int next1 = S.IndexOf("\n",index);
							int next2 = S.IndexOf("\r",index);
							if ((next1==-1)&&(next2==-1)) return true;
							if (next1==-1){
								index=next2+1;
								if (pos<index) return true;
								continue;
							}
							if (next2==-1){
								index=next1+1;
								if (pos<index) return true;
								continue;
							}
							if (next1<next2) 
								index=next1+1;
							else
								index=next2+1;
							if (pos<index) return true;
							continue;

						}
					}
					catch {
						return true;
					}
				}
				if ((C==' ')||(C=='\n')||(C=='\r')||(C=='\t')){
					index++;
					if (index>pos) return false;
					continue;
				}
				index++;
				if (index>pos) return false;
				continue;
			}
			
			return false;
		}
		/// <summary>
		/// Restituisce l'indice del prossimo non-commento e non-blank, o -1 se non ce ne sono. 
		/// </summary>
		/// <param name="S"></param>
		/// <param name="start"></param>
		/// <returns></returns>
		public static int nextNonComment(string S, int start){
			int index=start;
			while ((index<S.Length)&&(index>=0)){
				char C=S[index];

				//Salta i commenti normali
				if (C=='/'){
					try {
						//vede se è un commento normale ossia /* asas */
						if (S[index+1]=='*'){
							index= closedComment(S,index+2);
							continue;
						}
						if (S[index+1]=='/'){
							int next1 = S.IndexOf("\n",index);
							int next2 = S.IndexOf("\r",index);
							if ((next1==-1)&&(next2==-1)) return S.Length;
							if (next1==-1){
								index=next2+1;
								continue;
							}
							if (next2==-1){
								index=next1+1;
								continue;
							}
							if (next1<next2) 
								index=next1+1;
							else
								index=next2+1;
							continue;

						}
					}
					catch {
						return -1;
					}
				}
				if ((C==' ')||(C=='\n')||(C=='\r')||(C=='\t')){
					index++;
					continue;
				}
				return index;
			}
			
			return -1;
		}


		public static string getFunctionCode(string methodname, string S, out string before, out string after,int ENTER_COUNT){

			int N=0;
			int start=0;
			while ((N<ENTER_COUNT) && (start<S.Length)){
				start=S.IndexOf("{",start)+1;
				N++;
			}

			before="";
			after="";
			int limit=S.IndexOf("{",start);
			while ((limit>=0)&&(IsInsideComment(S,start,limit))){
				limit=S.IndexOf("{",limit+1);
			}
			if (limit<0) limit=S.Length;
			string pattern=" "+methodname;
			string SS=S.Substring(start);
			int next = S.IndexOf(pattern,start,limit-start);
			while ((next>=0) && (IsInsideComment(S,start,next)) && (next<limit)){
				next = S.IndexOf(pattern,next+1,limit-next-1); 
			}
			SS=S.Substring(start,limit-start);
			while ((next<0)&&(limit<S.Length)){
				SS=S.Substring(limit);
				start= SkipComments.closeBlock(S,limit+1,'{','}');
				if (start<0){
					string sss=methodname;
				}
				limit = S.IndexOf("{",start);
				while ((limit>=0)&&(IsInsideComment(S,start,limit))){
					limit=S.IndexOf("{",limit+1);
				}
				if (limit<0) limit=S.Length;
				next = S.IndexOf(pattern,start,limit-start);
				while ((next>=0) && (IsInsideComment(S,start,next)) && (next<limit)){
					next = S.IndexOf(pattern,next+1,limit-next-1);
				}
			}
			if (next<0) {
				before=S;
				after="";
				return "";
			}
			int NNNNNNN= S.Length;
			int startblock= S.LastIndexOf('\n',next,next);
			int idx=S.IndexOf('{',startblock);
			int stop= SkipComments.closeBlock(S,idx+1,'{','}');
			if (stop<0) stop=S.Length;
			before=S.Substring(0,startblock);
			after= S.Substring(stop);
			return S.Substring(startblock,stop-startblock);
		}
			

	}


	#region String Tokenizer


		


	public class StringTokenizer : IEnumerator, IEnumerable
	{
		string stringa;
		string[] pattern;
		int posizione, inizio, fine;
		public Hashtable parametri;

		public StringTokenizer(string stringa, string[] pattern) 
		{
			this.stringa = stringa;
			this.pattern = pattern;
			Reset();
		}

		
		public void setPattern(string[] pattern) 
		{
			this.pattern = pattern;
		}

		public string getParteRimanente() 
		{
			return stringa.Substring(inizio);
		}

		private bool isSpazio(char c) 
		{
			return " \t\r\n".IndexOf(c) != -1;
		}

		private bool isParentesi(char c) 
		{
			return "();:".IndexOf(c) != -1;
		}

		private char carattereSuccessivo() 
		{
			if (stringa.Substring(posizione, 2) == "/*") 
			{
				posizione = stringa.IndexOf("*/", posizione) + 2;
			} 
			if (stringa.Substring(posizione, 2) =="//")
			{
				posizione = stringa.IndexOf("\r\n", posizione) + 2;
			} 
			return stringa[posizione++];
		}

		
		public static string GetKeywordOrIdentifier(string S,int currpos){
			string id=S[currpos].ToString();
			currpos++;
			while (currpos<S.Length){
				if (Char.IsLetterOrDigit(S,currpos)
					||(S[currpos]=='_')){
					id+=S[currpos];
					currpos++;
					continue;
				}
				break;
			}
			return id;
		}



		public static string  GetNumber(string S,int currpos){
			string num= S[currpos].ToString();
			currpos++;
			bool dotwasfound=false;
			while (currpos<S.Length){
				if (Char.IsDigit(S,currpos)){
					num+=S[currpos];
					currpos++;
					continue;
				}
				if (dotwasfound) break;
				if (S[currpos]!='.') break;
				num+=S[currpos];
				currpos++;
				dotwasfound=true;
			}
			

			return num;
		}

		public static string  GetStringConstant(string S,int currpos){

			char STOP=S[currpos];
			string str=STOP.ToString();

			int index=currpos+1;
			while (index<S.Length){
				str+=S[index];
				if (S[index]=='\\'){
					str+=S[index+1];
					index++;
					index++;
					continue;
				}
				if (S[index]==STOP){
					return str;
				}
				index++;
			}
			return str;
		}



		public static int cercaParola(string stringa, string parola, int posizioneIniziale)
		{
			int posizione = stringa.IndexOf(parola, posizioneIniziale);
			while (posizione!= -1) 
			{
				int posSS = stringa.LastIndexOf("//", posizione);
				int posCRLF = stringa.LastIndexOf("\r\n", posizione);
				int posSA = stringa.LastIndexOf("/*", posizione);
				int posAS = stringa.LastIndexOf("*/", posizione);
				if ((posSS <= posCRLF) && (posSA <= posAS)) 
				{
					return posizione;
				}
				string prova = stringa.Substring(posCRLF);
				posizione = stringa.IndexOf(parola, posizione+1);
			}
			return posizione;
		}




		private string getNextToken() {
			int start=posizione;
			posizione = SkipComments.nextNonComment(stringa,posizione);
			if (posizione<0) {
				posizione=stringa.Length;
				return stringa.Substring(start);
			}
			char C = stringa[posizione];
			posizione++;

			if (Char.IsLetter(C)||(C=='_')) {
				string res= GetKeywordOrIdentifier(stringa,posizione-1);
				posizione+=res.Length-1;
				return res;
			}

			if (Char.IsDigit(C)){
				string res= GetNumber(stringa,posizione-1);
				posizione+=res.Length-1;
				return res;
			}			
			if ((C=='\'')||(C=='"')){
				string res= GetStringConstant(stringa,posizione-1);
				posizione+=res.Length-1;
				return res;
			}
			return C.ToString();
		}


		public IEnumerator GetEnumerator() 
		{
			return this;
		}

		public void Reset() 
		{
			inizio = 0;
			fine = -1;
		}

		public bool MoveNext() 
		{
			parametri = new Hashtable();
			do
			{
				posizione = cercaParola(stringa, pattern[0], fine + 1);
				if (posizione == -1) 
				{
					return false;
				}
				fine = posizione;
				posizione += pattern[0].Length;

			} while (!verificaPattern(pattern, 1));

			return true;
		}
		
		public Object Current 
		{
			get 
			{
				string token = stringa.Substring(inizio, fine-inizio);
				inizio = posizione;
				return token;
			}
		}

		private bool verificaPattern(string[] pattern, int aPartireDa) {
			for (int i=aPartireDa; i<pattern.Length; i++) {
				string token = getNextToken();
									
				if (pattern[i].StartsWith("%")) 
				{
					parametri[pattern[i]] = token;
				}
				else 
				{
					if ((pattern[i] != "*") && (pattern[i] != token)) 
					{
						return false;
					}
				}
			}
			return true;
		}
	}
	#endregion
}
