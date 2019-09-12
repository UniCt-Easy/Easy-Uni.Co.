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
using System.Data;
using metaeasylibrary;
using metadatalibrary;
using System.Data.SqlTypes;
using System.Collections;

namespace funzioni_configurazione//funzioni_configurazione//
{
	public class CalcolaPartitaIva {
		public static string controllaPartitaIva(string piva) {
			Hashtable h = new Hashtable();
            h.Add("AT", new int[] { 9 });
			h.Add("BE", new int[] { 10 });
            h.Add("BG", new int[] { 9 });
            h.Add("HR", new int[] { 11 }); 
			h.Add("DE", new int[] { 9 });
			h.Add("DK", new int[] { 8 });
			h.Add("EL", new int[] { 9 });
			h.Add("ES", new int[] { 9 });
			h.Add("FI", new int[] { 8 });
			h.Add("FR", new int[] { 11 });
			h.Add("GB", new int[] { 9, 12});
			h.Add("IE", new int[] { 8,9 });
			h.Add("IT", new int[] { 11 });
			h.Add("LU", new int[] { 8 });
			h.Add("NL", new int[] { 12 });
			h.Add("SE", new int[] { 12 });
			h.Add("CY", new int[] { 9 });
			h.Add("EE", new int[] { 9 });
			h.Add("LV", new int[] { 11 });
			h.Add("LT", new int[] { 9,12 });
			h.Add("MT", new int[] { 8 });
			h.Add("PL", new int[] { 10 });
            h.Add("PT", new int[] { 9 });
            h.Add("CZ", new int[] { 8, 9, 10 });
			h.Add("SK", new int[] { 9, 10});
			h.Add("SI", new int[] { 8 });
            h.Add("HU", new int[] { 8 });
            h.Add("RO", new int[] { 2, 3, 4, 5, 6, 7, 8 , 9, 10 });

			string[] errore = {"OK",
								  "L'ultimo carattere non è coerente con gli altri caratteri",
								  "La partita IVA deve essere composta da 11 caratteri numerici",
								  "Si è verificata una eccezione generica"
								  //						,"Il primo carattere della partita IVA deve essere diverso da 8 e 9",
								  //						"Il codice della provincia non è valido (caratteri in posizione 10, 11 e 12)"
							  };

			if (piva.Length<3) {
				return "La partita IVA italiana è composta da 11 numeri; la partita IVA straniera deve cominciare con la sigla della nazione";
			}
			
			if ((piva[0]>='0')&&(piva[0]<='9')&&(piva[1]>='0')&&(piva[1]<='9')) {
				int errorePIvaIt = controllaPartitaIvaItaliana(piva);
				if (errorePIvaIt != 0) {
					return errore[errorePIvaIt];
				} 
				else {
					return null;
				}
			}

			if (piva.Substring(0,2).ToUpper()=="IT") {
                return errore[2];
                //int errorePIvaIt = controllaPartitaIvaItaliana(piva.Substring(2));
                //if (errorePIvaIt != 0) {
                //    return errore[errorePIvaIt];
                //} 
                //else {
                //    return null;
                //}
			}

			int [] lens = (int []) h[piva.Substring(0,2).ToUpper()];

            if (lens == null) {
				return "I primi due caratteri della partita IVA non sono numerici o non identificano un Paese UE";
			}

    		int lunghezzaInserita = piva.Length-2;
            string ll = "";
            bool isok = false;
            for (int i = 0; i < lens.Length; i++) {
                if (lunghezzaInserita == lens[i]) {
                    isok = true;
                    break;
                }
                if (ll != "") ll += ",";
                ll += lens[i].ToString();
            }



			if (!isok) {
				string messaggio = "La partita IVA che comincia con "
					+ piva.Substring(0,2).ToUpper()
					+ " deve contenere una quantità di numeri pari a :"+ll;
				return messaggio;
			}

			return null;
		}


		public static int controllaPartitaIvaItaliana(string piva) {
			return controllaPartitaIvaItaliana(piva, 'F');
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="piva"></param>
		/// <param name="controlType"></param>
		/// <returns>
		/// 0: ok
		/// 1: ultimo carattere non coerente con gli altri caratteri
		/// 2: lunghezza diversa da 11 caratteri o contenenente almeno un carattere non numerico
		/// 3: eccezione generica
		/// 4: primo carattere uguale a 8 o a 9
		/// 5: prov != 121 && prov != 120 && (1 > prov || prov > 100) && prov != 999
		/// </returns>
		public static int controllaPartitaIvaItaliana(string piva, char controlType) {
			try {
				string str1 = null;
				int totale = 0;
				long somma = 0L;
				bool numerico = true;
				//				char[] vchar = new char[piva.Length];
				//				piva.getChars(0, piva.length(), vchar, 0);
				string vchar = piva;
				for(int i1 = 0; numerico && i1 < piva.Length; i1++)
					if((vchar[i1] < '0') || (vchar[i1] > '9'))
						numerico = false;
					else
						somma += vchar[i1];

				if((piva.Length != 11) || !numerico) {
					return 2;
				}
				if(somma == 0L)
					return 0;
				if(controlType == 'I') {
					if((piva[0] == '8') || (piva[0] == '9')) {
						return 4;
					}
					int prov = Int32.Parse(piva.Substring(7, 3));
					if((prov != 121) && (prov != 120) && ((1 > prov) || (prov > 100)) && (prov != 999)) {
						return 5;
					}
				}
				for(int i = 1; i < 11; i += 2) {
					int integer1 = Int32.Parse(piva.Substring(i, 1));
					str1 = (integer1 * 2).ToString();
					for(int j = 0; j < str1.Length; j++) {
						int integer3 = Int32.Parse(str1.Substring(j, 1));
						totale += integer3;
					}

				}

				for(int k = 0; k < 9; k += 2) {
					int integer4 = Int32.Parse(piva.Substring(k, 1));
					totale += integer4;
				}

				int ultimocarattere = Int32.Parse(piva.Substring(10, 1));
				if(totale % 10 == 0) {
					if(totale % 10 == ultimocarattere)
						return 0;
					else
						return 1;
				} 
				else
					if(10 - totale % 10 == ultimocarattere)
					return 0;
				else
					return 1;
			}
			catch(Exception) {
				return 3;
			}
		}

	}
	/// <summary>
	/// Summary description for CodiceFiscale.
	/// </summary>
	public class CalcolaCodiceFiscale
	{
		private static string sostituisciLetteraConNumero(string cf, int pos) 
		{
			string sostituzioni = "LMNPQRSTUV";
			int numero = sostituzioni.IndexOf(cf[pos]);
			if (numero != -1) 
			{
				cf = cf.Substring(0, pos) + numero + cf.Substring(pos+1);
			}
			return cf;
		}

		public static string normalizza(string codicefiscale) 
		{
			codicefiscale = sostituisciLetteraConNumero(codicefiscale, 6);
			codicefiscale = sostituisciLetteraConNumero(codicefiscale, 7);
			codicefiscale = sostituisciLetteraConNumero(codicefiscale, 9);
			codicefiscale = sostituisciLetteraConNumero(codicefiscale,10);
			codicefiscale = sostituisciLetteraConNumero(codicefiscale,12);
			codicefiscale = sostituisciLetteraConNumero(codicefiscale,13);
			return sostituisciLetteraConNumero(codicefiscale,14);
		}

		private static string m_Errori="";

		private static string maiuscolo(string s) 
		{
			string r = "";
			foreach (char c in s) 
			{
				switch (c) 
				{
					case 'à': 
						r += 'A'; 
						break;
					case 'é':
					case 'è': 
						r += 'E'; 
						break;
					case 'ì': 
						r += 'I'; 
						break;
					case 'ò': 
						r += 'O'; 
						break;
					case 'ù': 
						r += 'U'; 
						break;
					default: 
						r += Char.ToUpper(c);
						break;
				}
			}
			return r;
		}

	    /// <summary>
	    /// Restituisce True se il codicefiscale privato/azienda risulta valido
	    /// </summary>
	    /// <param name="R"></param>
	    /// <returns></returns>

	    public static bool CodiceFiscaleValido(DataAccess Conn, DataRow R, out string errori) {
	        errori = "";
	        string codicefiscale = R["cf"].ToString().ToUpper();
	        if (codicefiscale == "") return true;
	        //per entità che hanno codice fiscale numerico da 11
	        if (codicefiscale.Length == 11) {
	            foreach (char c in codicefiscale.ToCharArray()) {
	                if (!char.IsDigit(c)) return false;
	            }
	            return true;
	        }
	        errori = "(deve essere composto da 16 caratteri e non " + codicefiscale.Length + ")";
	        //ASSOLUTAMENTE NON VALIDO
	        if (codicefiscale.Length != 16) return false;
	        //persona fisica
	        string tipoGeo = "C";
	        string idgeo = R["idcity"].ToString();
	        if (R["idnation"].ToString() != "") {
	            tipoGeo = "N";
	            idgeo = R["idnation"].ToString();
	        }
	        bool isValid;
	        char carControllo = GetLastChar(codicefiscale.Substring(0, 15), out isValid);
	        string cfNormal = normalizza(codicefiscale);
	        string codicefiscalecalcolato =
	            Make(Conn,
	                R["forename"].ToString(),
	                R["surname"].ToString(),
	                R["birthdate"],
	                idgeo,
	                R["gender"].ToString(),
	                tipoGeo,
	                out isValid,
	                out errori);
	        if (!isValid) return false;
	        if ((cfNormal.Substring(0, 15) != codicefiscalecalcolato.Substring(0, 15))
	            || (cfNormal[15] != carControllo)) {
	            if (cfNormal.Substring(0, 3) != codicefiscalecalcolato.Substring(0, 3)) {
	                errori += "(non coerente con il cognome)\n";
	            }
	            if (cfNormal.Substring(3, 3) != codicefiscalecalcolato.Substring(3, 3)) {
	                errori += "(non coerente con il nome)\n";
	            }
	            if (cfNormal.Substring(6, 2) != codicefiscalecalcolato.Substring(6, 2)) {
	                errori += "(non coerente con l'anno di nascita)\n";
	            }
	            if (cfNormal.Substring(8, 1) != codicefiscalecalcolato.Substring(8, 1)) {
	                errori += "(non coerente con il mese di nascita)\n";
	            }
	            try {
	                int g1 = Convert.ToInt32(cfNormal.Substring(9, 2));
	                int g2 = Convert.ToInt32(codicefiscalecalcolato.Substring(9, 2));
	                string s1 = "M";
	                string s2 = "M";
	                if (g1 > 40) {
	                    s1 = "F";
	                    g1 -= 40;
	                }
	                if (g2 > 40) {
	                    s2 = "F";
	                    g2 -= 40;
	                }

	                if (g1 != g2) {
	                    errori += "(non coerente con il giorno di nascita)\n";
	                }
	                if (s1 != s2) {
	                    errori += "(non coerente con il sesso)\n";
	                }
	            }
	            catch (System.FormatException) {
	                errori += "(non coerente con il giorno di nascita e/o sesso)\n";
	            }
	            if (cfNormal.Substring(11, 4) != codicefiscalecalcolato.Substring(11, 4)) {
	                if (codicefiscalecalcolato[11] == 'Z') {
	                    errori += "(non coerente con lo stato estero di nascita)\n";
	                }
	                else {
	                    errori += "(non coerente con il comune di nascita)\n";
	                }

	            }
	            if ((cfNormal.Substring(0, 15) == codicefiscalecalcolato.Substring(0, 15))
	                && (cfNormal[15] != carControllo)) {
	                errori += "(ultimo carattere errato)\n";
	            }
	            return false;
	        }
	        return true;
	    }

	    /// <summary>
		/// Calcola il codice fiscale conoscendo già il codice fiscale del comune
		/// </summary>
		public static string Make(string Nome, string Cognome, 
			object DataNascita, string CodiceComune,string Sesso,
			out bool IsValid, out string errori) 
		{

			bool valido=true;
			PulisciErrori();
			IsValid=true;
			errori="";
			string R = "";
			R += GetCodCognome(maiuscolo(Cognome),out valido);
			IsValid=(IsValid && valido);
			valido=true;
			R += GetCodNome(maiuscolo(Nome),out valido);
			IsValid=(IsValid && valido);
			valido=true;
			R += GetCodDataNascita(DataNascita,Sesso,out valido);
			IsValid=(IsValid && valido);
			valido=true;
			R += GetCodComuneNascita(CodiceComune,out valido);
			IsValid=(IsValid && valido);
			valido=true;
			R += GetLastChar(R,out valido);
			IsValid=(IsValid && valido);
			errori=LeggiErrori();
			return R;
		}

		public static void CheckCF(string codicefiscale, out string errori)
		{
			codicefiscale = codicefiscale.ToUpper();
			PulisciErrori();
			errori = "";
			string lastchar;
			string codice;
			bool IsValid;
			// Controllo sulla lunghezza, se non rispettata è inutile effettuare altri controlli
			if (codicefiscale.Length!=16)
			{
				AggiungiErrore("Lunghezza non corretta");
				errori = LeggiErrori();
				return;
			}
			// Controllo sulla congruità del CF rispetto alle info date
			// Controllo sull'ultimo carattere
			codice = codicefiscale.Substring(0,(codicefiscale.Length-1));
			lastchar = GetLastChar(codice,out IsValid).ToString();
			if ((!IsValid)||(lastchar!=codicefiscale[codicefiscale.Length-1].ToString()))
				AggiungiErrore("Ultimo carattere non valido");
			errori = LeggiErrori();
		}


		private static object find_agencycode(DataAccess Conn, string idgeo, string tipo) {
			tipo = tipo.ToUpper();
			string geoTabella = "geo_city_agency";
			string geoCampo = "idcity";
			switch (tipo) {
				case "P":
					geoTabella = "geo_country_agency";
					geoCampo = "idcountry";
					break;
				case "R":
					geoTabella = "geo_region_agency";
					geoCampo = "idregion";
					break;
				case "N":
					geoTabella = "geo_nation_agency";
					geoCampo = "idnation";
					break;
			}
			return Conn.DO_READ_VALUE(geoTabella, "(" + geoCampo
				+ "=" + QueryCreator.quotedstrvalue(idgeo, true)
				+ ") AND (idagency=1) and (idcode=1)", "value");
		}

		/// <summary>
		/// Restituisce il valore di un codice ente conoscendo il codice id della entità geo 
		/// </summary>
		/// <param name="Conn">Connessione</param>
		/// <param name="idgeo">id della entità geo (geo_comune, geo_provincia, etc)...</param>
		/// <param name="TipoGeo">"C" = Comune (default), "P" = Provincia, "R" = Regione, "N" = Nazione</param>
		public static string Make(DataAccess Conn, string Nome, string Cognome, 
			object DataNascita, string idgeo, string Sesso, string TipoGeo,
			out bool IsValid, out string errori) 
		{

			PulisciErrori();
			errori="";
			IsValid=true;

			if (idgeo.Trim()=="") return Make(Nome, Cognome, DataNascita, "", Sesso,out IsValid,out errori);

			//default impostato su Comune
			if (TipoGeo=="") TipoGeo="C";

			try 
			{
				string CodiceComune = find_agencycode(Conn, idgeo, TipoGeo).ToString();
				return Make(Nome, Cognome, DataNascita, CodiceComune, Sesso, out IsValid, out errori);
			}
			catch 
			{
				IsValid = false;
				errori += "Dati mancanti o errati\r";
				return "Dati mancanti o errati";
			}
		}

		/// <summary>
		///		Tre caratteri alfabetici maiuscoli della prima, terza e quarta (1',3',4') consonante del Nome.
		///		Se le consonanti per il Nome fossero solo tre, le si prendono nell'ordine in cui si presentano.
		///		Se le consonanti fossero meno di tre, aggiungere le vocali nello stesso ordine in cui si presentano.
		///		Se l'intero Nome fosse piu' corto di tre caratteri, aggiungere una X per ogni carattere mancante.
		///		Nei Nomi composti da piu' parti, gli spazi intermedi non vanno considerati
		///		( es. Antonia Maria Luisa sara' ANTONIAMARIALUISA )
		///		
		/// </summary>
		/// <param name="Nome"></param>
		/// <returns></returns>
		private static string GetCodNome(string Nome,out bool IsValid)
		{
			IsValid=true;
			string R = "";
			Nome = Nome.Trim();
			if (Nome=="") 
			{
				IsValid=false;
				AggiungiErrore("Nome mancante");
				return R;
			}
			foreach(Char C in Nome)
			{	
				if(IsConsonant(C))
				{
					//Prende le prime quattro consonanti
					if(R.Length <4) R += C;
				}
			}
			
			if (R.Length >= 4)
			{
				R = R.Remove(1,1);	//rimuove la seconda consonante e conserva 1,3,4.
				return R;
			}
			if (R.Length == 3) return R;
	
			//Se le consonanti sono meno di tre
			foreach(Char C in Nome)
			{
				if ((R.Length < 3) && IsVocal(C)) R += C;
				
			}
			if (R.Length < 3)
			{
				//Aggiunge una X per ogni carattere mancante
				while (R.Length < 3) R += "X";	
			}
			return R;
		}


		/// <summary>
		///	Tre caratteri alfabetici maiuscoli della prima, seconda e terza (1',2',3') consonante del Cognome.
		///	Se le consonanti per il Cognome fossero meno di tre, aggiungere le vocali nello stesso ordine in cui si presentano.
		///	Se l'intero Cognome fosse piu' corto di tre caratteri, aggiungere una X per ogni carattere mancante.
		///	Per le donne coniugate considerare solo il Cognome da nubile.
		///	Nei Cognomi composti da piu' parti, gli spazi intermedi non vanno considerati
		///	( es. De Rossi D'Aquino sara' DEROSSIDAQUINO ).
		/// </summary>
		/// <param name="Cognome"></param>
		/// <returns></returns>
		private static string GetCodCognome(string Cognome,out bool IsValid)
		{
			IsValid=true;
			string R = "";
			Cognome = Cognome.Trim();
			if (Cognome=="") 
			{
				IsValid=false;
				AggiungiErrore("Cognome mancante");
				return R;
			}
			foreach(Char C in Cognome)
			{	
				//Prende le prime tre consonanti
				if (IsConsonant(C) && (R.Length <3)) R += C;
			}
			
			if(R.Length == 3) return R;
	
			//Se le consonanti sono meno di tre
			foreach (Char C in Cognome)
			{
				if ((R.Length < 3)&& IsVocal(C)) R += C;
			}
			//Aggiunge una X per ogni carattere mancante
			while (R.Length < 3) R += "X";	
			return R;
		}

		/// <summary>
		///	Due caratteri numerici per l'anno di nascita, solo le unita' e le decine (le ultime due cifre)
		///	(es. 1968 diventa 68).
		///	Un carattere alfabetico indicante il Mese della Data di Nascita Considerando questa tabella:
		///	A= Gennaio;   B= Febbraio; C= Marzo;    D= Aprile;
		///	E= Maggio;    H= Giugno;   L= Luglio;   M= Agosto;
		///	P= Settembre; R= Ottobre;  S= Novembre; T= Dicembre
		///
		///Due caratteri numerici per il giorno di nascita. Per le donne, occore sommare al giorno di nascita 40. 
		///es. uomo nati il 7/8/1968 = 07 
		///donna nata il 7/8/1968 = 47
		/// </summary>
		private static string GetCodDataNascita(object objDataNascita, string Sesso,
			out bool IsValid) 
		{

			IsValid=true;

			if (!(objDataNascita is DateTime)) 
			{
				IsValid=false;
				AggiungiErrore("Data mancante");
				return " Data mancante ";
			}

			DateTime dataDiNascita = (DateTime) objDataNascita;

			if (Sesso=="") 
			{
				IsValid=false;
				AggiungiErrore("Sesso mancante");
				return " Sesso mancante ";
			}
			Sesso = Sesso.ToUpper();

			int anno = dataDiNascita.Year % 100;
			string Anno = (anno<10) ? "0"+anno.ToString() : anno.ToString();

			char Mese = "ABCDEHLMPRST"[dataDiNascita.Month-1];

			int giorno = (Sesso == "F") ? 40 + dataDiNascita.Day : dataDiNascita.Day;
			string Giorno = (giorno < 10) ? "0"+giorno.ToString() : giorno.ToString();

			return Anno+Mese+Giorno;
		}
	
		private static string GetCodComuneNascita(string CodComune,out bool IsValid)
		{
			IsValid=true;
			if(CodComune == "") 
			{
				IsValid=false;
				AggiungiErrore("Comune mancante");
				return "-Codice Comune Mancante-"; 
			}
			return CodComune;
		}

		public static char GetLastChar(string Codice,out bool IsValid)
		{
			IsValid=true;
			int count = 0;
			bool IsPair = true;
			decimal Somma = 0;
			foreach(Char C in Codice)
			{
				count++;
				IsPair = !IsPair;
				if(IsPair) Somma += GetValueTabA(C);
				else Somma += GetValueTabB(C);
			}
			int Resto_int = Convert.ToInt32(Somma) % 26;
			return GetValueTabC(Resto_int,out IsValid);
		}

		private static bool IsConsonant(char MyLetter)
		{
			bool R = true;
			switch (Char.ToUpper(MyLetter))
			{
				case 'B':break;
				case 'C':break;
				case 'D':break;
				case 'F':break;
				case 'G':break;
				case 'H':break;
				case 'L':break;
				case 'J':break;
				case 'K':break;
				case 'M':break;
				case 'N':break;
				case 'P':break;
				case 'Q':break;
				case 'R':break;
				case 'S':break;
				case 'T':break;
				case 'V':break;
				case 'Z':break;
				case 'X':break;
				case 'W':break;
				case 'Y':break;
				default:
					R = false;
					break;

			}
			return R;
		}

		private static bool IsVocal(char MyLetter)
		{
			bool Res = true;
			switch(Char.ToUpper(MyLetter))
			{
				case 'A':break;
				case 'E':break;
				case 'I':break;
				case 'O':break;
				case 'U':break;
				default:
					Res = false;
					break;
			}
			return Res;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="C"></param>
		/// <returns></returns>
		//		TABELLA [ A ] (caratteri in posizione pari)
		//		0=0  1=1  2=2  3=3  4=4  5=5  6=6  7=7  8=8  9=9
		//		A=0  B=1  C=2  D=3  E=4  F=5  G=6  H=7  I=8  J=9
		//		K=10 L=11 M=12 N=13 O=14 P=15 Q=16 R=17 S=18 T=19
		//		U=20 V=21 W=22 X=23 Y=24 Z=25
		private static int GetValueTabA(Char C)
		{
			int VA = 0;

			switch (C)
			{
				case '0':
					VA = 0;
					break;
				case '1':
					VA = 1;
					break;
				case '2':
					VA = 2;
					break;
				case '3':
					VA = 3;
					break;
				case '4':
					VA = 4;
					break;
				case '5':
					VA = 5;
					break;
				case '6':
					VA = 6;
					break;
				case '7':
					VA = 7;
					break;
				case '8':
					VA = 8;
					break;
				case '9':
					VA = 9;
					break;
				case 'A':
					VA = 0;
					break;
				case 'B':
					VA = 1;
					break;
				case 'C':
					VA = 2;
					break;
				case 'D':
					VA = 3;
					break;
				case 'E':
					VA = 4;
					break;
				case 'F':
					VA = 5;
					break;
				case 'G':
					VA = 6;
					break;
				case 'H':
					VA = 7;
					break;
				case 'I':
					VA = 8;
					break;
				case 'J':
					VA = 9;
					break;
				case 'K':
					VA = 10;
					break;
				case 'L':
					VA = 11;
					break;
				case 'M':
					VA = 12;
					break;
				case 'N':
					VA = 13;
					break;
				case 'O':
					VA = 14;
					break;
				case 'P':
					VA = 15;
					break;
				case 'Q':
					VA = 16;
					break;
				case 'R':
					VA = 17;
					break;
				case 'S':
					VA = 18;
					break;
				case 'T':
					VA = 19;
					break;
				case 'U':
					VA = 20;
					break;
				case 'V':
					VA = 21;
					break;
				case 'W':
					VA = 22;
					break;
				case 'X':
					VA = 23;
					break;
				case 'Y':
					VA = 24;
					break;
				case 'Z':
					VA = 25;
					break;
					//				default:
					//					VA = 0;
					//					break;
			}
			return VA;
		}


		//		TABELLA [ B ] (caratteri in posizione dispari)
		//		0=1  1=0  2=5  3=7  4=9  5=13 6=15 7=17 8=19 9=21
		//		A=1  B=0  C=5  D=7  E=9  F=13 G=15 H=17 I=19 J=21
		//		K=2  L=4  M=18 N=20 O=11 P=3  Q=6  R=8  S=12 T=14
		//		U=16 V=10 W=22 X=25 Y=24 Z=23
		private static int GetValueTabB(Char C)
		{
			int VA = 0;
			switch (C)
			{
				case '0':
					VA = 1;
					break;
				case '1':
					VA = 0;
					break;
				case '2':
					VA = 5;
					break;
				case '3':
					VA = 7;
					break;
				case '4':
					VA = 9;
					break;
				case '5':
					VA = 13;
					break;
				case '6':
					VA = 15;
					break;
				case '7':
					VA = 17;
					break;
				case '8':
					VA = 19;
					break;
				case '9':
					VA = 21;
					break;
				case 'A':
					VA = 1;
					break;
				case 'B':
					VA = 0;
					break;
				case 'C':
					VA = 5;
					break;
				case 'D':
					VA = 7;
					break;
				case 'E':
					VA = 9;
					break;
				case 'F':
					VA = 13;
					break;
				case 'G':
					VA = 15;
					break;
				case 'H':
					VA = 17;
					break;
				case 'I':
					VA = 19;
					break;
				case 'J':
					VA = 21;
					break;
				case 'K':
					VA = 2;
					break;
				case 'L':
					VA = 4;
					break;
				case 'M':
					VA = 18;
					break;
				case 'N':
					VA = 20;
					break;
				case 'O':
					VA = 11;
					break;
				case 'P':
					VA = 3;
					break;
				case 'Q':
					VA = 6;
					break;
				case 'R':
					VA = 8;
					break;
				case 'S':
					VA = 12;
					break;
				case 'T':
					VA = 14;
					break;
				case 'U':
					VA = 16;
					break;
				case 'V':
					VA = 10;
					break;
				case 'W':
					VA = 22;
					break;
				case 'X':
					VA = 25;
					break;
				case 'Y':
					VA = 24;
					break;
				case 'Z':
					VA = 23;
					break;
					
			}
			return VA;

		}


		//		TABELLA [ C ] (conversione del carattere di controllo)
		//		0=A  1=B  2=C  3=D  4=E  5=F  6=G  7=H  8=I  9=J
		//		10=K 11=L 12=M 13=N 14=O 15=P 16=Q 17=R 18=S 19=T
		//		20=U 21=V 22=W 23=X 24=Y 25=Z 
		private static char GetValueTabC(int C,out bool IsValid)
		{
			IsValid=true;
			//			string VA = " errore nel carattere di controllo " ;
			string tabC ="ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			if ((C < 0)||(C>25)) 
			{
				IsValid=false;
				AggiungiErrore("Errore nel carattere di controllo");
				return '?';
			}
			return tabC[C];
		}

		private static string LeggiErrori() 
		{
			return m_Errori;
		}

		private static void PulisciErrori() 
		{
			m_Errori="";
		}
		private static void AggiungiErrore(string msg) 
		{
			m_Errori+="- "+msg+"\r";
		}
	}

	public class InfoDaCodiceFiscale 
	{
		/// <summary>
		/// idgeo del comune, o null se codice errato
		/// </summary>
		public static string Comune(DataAccess Conn, string codicefiscale) {
		    return comune(Conn, codicefiscale);
		}

	    /// <summary>
	    /// idgeo del comune, o null se codice errato
	    /// </summary>
	    public static string comune(IDataAccess conn, string codicefiscale) 
	    {
	        if (codicefiscale.Length!=16) return null;
	        string codicecomune=codicefiscale.Substring(11,4);
	        string[] param=new string[] {"@codecity","@idcity"};
	        SqlDbType[] types=new SqlDbType[] {SqlDbType.VarChar,SqlDbType.Int};
	        int[] typelen=new int[] {4,0};
	        ParameterDirection[] dir=new ParameterDirection[]{ParameterDirection.Input,ParameterDirection.Output};
	        object[] values=new object[2]{codicecomune,null};
	        bool res=conn.CallSPParameter("compute_idcity_from_cf",param,types,typelen,dir,ref values,true,-1);
	        if (!res) return null;
	        return values[1].ToString();
	    }

	    /// <summary>
	    /// idgeo della nazione, o null se codice errato
	    /// </summary>
	    public static string nazione(IDataAccess Conn, string codicefiscale) 
	    {
	        if (codicefiscale.Length!=16) return null;
	        string codicenazione=codicefiscale.Substring(11,4);
	        string[] param=new string[] {"@codenation","@idnation"};
	        SqlDbType[] types=new SqlDbType[] {SqlDbType.VarChar,SqlDbType.Int};
	        int[] typelen=new int[] {4,0};
	        ParameterDirection[] dir=new ParameterDirection[]{ParameterDirection.Input,ParameterDirection.Output};
	        object[] values=new object[2]{codicenazione,null};
	        bool res=Conn.CallSPParameter("compute_idnation_from_cf",param,types,typelen,dir,ref values,true,-1);
	        if (!res) return null;
	        return values[1].ToString();
	    }

		/// <summary>
		/// idgeo della nazione, o null se codice errato
		/// </summary>
		public static string Nazione(DataAccess Conn, string codicefiscale) {
		    return nazione(Conn, codicefiscale);			
		}


		/// <summary>
		/// M/F o null se codice errato
		/// </summary>
		public static string Sesso(string codicefiscale) 
		{
			if (codicefiscale.Length!=16) return null;
			try 
			{
				int giorno=Convert.ToInt32(codicefiscale.Substring(9,2));
				if (giorno > 40) return "F";
				return "M";
			}
			catch (Exception E) 
			{
				QueryCreator.MarkEvent("InfoDaCodiceFiscale.Sesso() - "+E.Message);
				return null;
			}
		}

		/// <summary>
		/// data di nascita o null se codice errato
		/// </summary>
		public static object DataNascita(DataAccess Conn, string codicefiscale) 
		{
			if (codicefiscale.Length!=16) return null;
			try 
			{
				string esercizio=Conn.GetEsercizio().ToString();
				int corrente=Convert.ToInt32(esercizio.Substring(2,2));
				int secolo=Convert.ToInt32(esercizio.Substring(0,2))*100;
				int anno=Convert.ToInt32(codicefiscale.Substring(6,2));
				if (anno > corrente) anno+=(secolo-100);
				else anno+=secolo;
				int mese=NumeroMeseDaLettera(codicefiscale[8]);
				if (mese==0) throw new Exception("Lettera relativa al mese di nascita non valida");
				int giorno=Convert.ToInt32(codicefiscale.Substring(9,2));
				if (giorno > 40) giorno-=40;
				return new DateTime(anno,mese,giorno);
			}
			catch (Exception E) 
			{
				QueryCreator.MarkEvent("InfoDaCodiceFiscale.DataNascita() - "+E.Message);
				return null;
			}
		}

	    /// <summary>
	    /// data di nascita o null se codice errato
	    /// </summary>
	    public static object dataNascita(ISecurity sec, string codicefiscale) 
	    {
	        if (codicefiscale.Length!=16) return null;
	        try 
	        {
	            string esercizio=sec.GetEsercizio().ToString();
	            int corrente=Convert.ToInt32(esercizio.Substring(2,2));
	            int secolo=Convert.ToInt32(esercizio.Substring(0,2))*100;
	            int anno=Convert.ToInt32(codicefiscale.Substring(6,2));
	            if (anno > corrente) anno+=(secolo-100);
	            else anno+=secolo;
	            int mese=NumeroMeseDaLettera(codicefiscale[8]);
	            if (mese==0) throw new Exception("Lettera relativa al mese di nascita non valida");
	            int giorno=Convert.ToInt32(codicefiscale.Substring(9,2));
	            if (giorno > 40) giorno-=40;
	            return new DateTime(anno,mese,giorno);
	        }
	        catch (Exception E) 
	        {
	            QueryCreator.MarkEvent("InfoDaCodiceFiscale.DataNascita() - "+E.Message);
	            return null;
	        }
	    }


		/// <summary>
		/// Restituisce il numero relativo al mese, 0 se lettera non valida
		/// </summary>
		/// <param name="lettera"></param>
		/// <returns></returns>
		public static int NumeroMeseDaLettera(char lettera) 
		{
			return "ABCDEHLMPRST".IndexOf(lettera)+1;
		}
	}
}
