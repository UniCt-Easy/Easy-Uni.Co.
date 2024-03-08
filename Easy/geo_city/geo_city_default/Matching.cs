
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
using System.Collections;

namespace geo_city_default//geo_comune//
{
	/// <summary>
	/// Summary description for Matching.
	/// </summary>
	public class Matching
	{
		public const int MASSIMO_ACCETTABILE = 19;


		private static bool f3(string a, string b, bool sonoEntrambiNuoviOEntrambiVecchi, out int matchingValue) 
		{
			int partenza = (sonoEntrambiNuoviOEntrambiVecchi) ? 0 : 1;
			if (a==b) 
			{
				matchingValue = partenza;
				return true;
			}

			//reg_ignoraSpaziApostrofiTrattiniEAsterischi
			if (a.Replace(" ","").Replace("'","").Replace("-","").Replace("*","")
				==
				b.Replace(" ","").Replace("'","").Replace("-","").Replace("*","") ) 
			{
				matchingValue = partenza + 1;
				return true;
			}

			//reg_ultimaLetteraInMenoNelPrimo
			if ((a.Length==b.Length-1)&&(a==b.Substring(0,b.Length-1)))
			{
				matchingValue = partenza + 1;
				return true;
			}

			//reg_sostituisciDiConDApostrofo
			if (a.Replace(" DI "," D'")==b)			
			{
				matchingValue = partenza + 1;
				return true;
			}

			//reg_sostituisci ST. con SANKT
			if (a.Replace("ST.","SANKT")==b) 
			{
				matchingValue = partenza + 1;
				return true;
			}

			/*			//reg_sostituisci ST. con SANKTA
						if (a.Replace("ST.","SANKT")==b) 
						{
							matchingValue = 1;
							return true;
						}*/

			if (a.Length==b.Length)
			{
				int contaLettereDiverse = r2_contaLettereDiverse(a, b);
				matchingValue = partenza + 8 * contaLettereDiverse - 7;
				return contaLettereDiverse<=1;
			}

			int contaLettereInPiu = r2_contaLettereInPiu(a, b);
			if (contaLettereInPiu >= 0) 			
			{
				matchingValue = partenza + 8 * contaLettereInPiu - 7;
				return contaLettereInPiu<=1;
			}

			matchingValue = 20;
			return false;
		}

		private static int r2_contaLettereDiverse(string a, string b) 
		{
			int len = a.Length;
			if (len!=b.Length) return -1;
			int contaLettereDiverse = 0;
			for (int i=0; i<len; i++) 
			{
				if (a[i]!=b[i]) 
				{
					contaLettereDiverse ++;
				}
			}
			return contaLettereDiverse;
		}

		private static int primoCarattereDiverso(string a, string b) 
		{
			int min = a.Length;
			if (b.Length<min) min = b.Length;
			for (int i=0; i<min; i++) 
			{
				if (a[i]!=b[i]) return i;
			}
			return -1;
		}

		private static int r2_contaLettereInPiu(string a, string b) 
		{
			int pcd = primoCarattereDiverso(a, b);
			if (pcd<0) return -1;

			if (a.Length > b.Length) 
			{
				int diff = a.Length - b.Length;
				string ssA = a.Substring(pcd + diff);
				string ssB = b.Substring(pcd);
				if (ssA==ssB) 
				{
					return diff;
				}
			} 
			else 
			{
				int diff = b.Length - a.Length;
				string ssA = a.Substring(pcd);
				string ssB = b.Substring(pcd + diff);
				if (ssA==ssB) 
				{
					return diff;
				}
			}
			return -1;
		}

		private static int cercaParola(string[] paroleA, string[] paroleB) 
		{
			int risultato = paroleA.Length;
			if (paroleA.Length<paroleB.Length) risultato = paroleB.Length;
			risultato *= 2;

			for (int i=0; i<paroleA.Length; i++) 
			{
				int min;

				if (f3(paroleA[i], paroleB[0], true, out min)) 
				{
					risultato -= 2;
				} 
				else 
				{

					for (int j=1; j<paroleB.Length; j++) 
					{
						int r;
						if (f3(paroleA[i], paroleB[j], true, out r)) 
						{
							risultato -=2 ;
							min = r;
							break;
						}
						if (r<min) min = r;
					}
				}
				risultato += min; 
			}
			return risultato;
		}

		private static int reg_confrontaParole(string a, string b, bool sonoEntrambiNuoviOEntrambiVecchi) 
		{
			int costanteDellaRegola = (sonoEntrambiNuoviOEntrambiVecchi) ? 2 : 3;

			string[] paroleA = a.Split(new char[] {' ','-','*'});
			string[] paroleB = b.Split(new char[] {' ','-','*'});

			int matchingValue1 = cercaParola(paroleA, paroleB);
			int matchingValue2 = cercaParola(paroleB, paroleA);

			if (matchingValue1<matchingValue2) 
				return costanteDellaRegola + matchingValue1;
			return costanteDellaRegola + matchingValue2;

		}

		private static int match (
			string comuneDaCercare, 
			bool isComuneDaCercareNuovo,
			string geo_comune, 
			bool isGeoComuneNuovo
		) 
		{
			int matchingValue;

			if (f3(comuneDaCercare, geo_comune, isComuneDaCercareNuovo==isGeoComuneNuovo, out matchingValue))
			{
				return matchingValue;
			}

			int minMatchingValue = matchingValue;

			matchingValue = reg_confrontaParole(comuneDaCercare, geo_comune, isComuneDaCercareNuovo==isGeoComuneNuovo);

			if (matchingValue < minMatchingValue) 
			{
				minMatchingValue = matchingValue;
			}

			return minMatchingValue;
		}

		private static string eliminaAccenti(string comuneDaTabellaEsterna) 
		{
			string comuneConAccenti = comuneDaTabellaEsterna.Trim();
			comuneConAccenti = comuneConAccenti.Replace("à ","A' ");
			comuneConAccenti = comuneConAccenti.Replace("è ","E' ");
			comuneConAccenti = comuneConAccenti.Replace("é ","E' ");
			comuneConAccenti = comuneConAccenti.Replace("ì ","I' ");
			comuneConAccenti = comuneConAccenti.Replace("ò ","O' ");
			comuneConAccenti = comuneConAccenti.Replace("ù ","U' ");
			comuneConAccenti = comuneConAccenti.Replace("à-","A' ");
			comuneConAccenti = comuneConAccenti.Replace("è-","E' ");
			comuneConAccenti = comuneConAccenti.Replace("é-","E' ");
			comuneConAccenti = comuneConAccenti.Replace("ì-","I' ");
			comuneConAccenti = comuneConAccenti.Replace("ò-","O' ");
			comuneConAccenti = comuneConAccenti.Replace("ù-","U' ");
			char ultimoCarattere = comuneConAccenti[comuneConAccenti.Length-1];
			string comuneDaCercare = "";
			foreach (char c in comuneConAccenti.Remove(comuneConAccenti.Length-1,1))
			{
				switch(c) 
				{
					case 'à': comuneDaCercare += "A"; break;
					case 'è': comuneDaCercare += "E"; break;
					case 'é': comuneDaCercare += "E"; break;
					case 'ì': comuneDaCercare += "I"; break;
					case 'ò': comuneDaCercare += "O"; break;
					case 'ù': comuneDaCercare += "U"; break;
					default: comuneDaCercare += Char.ToUpper(c); break;
				}
			}
			switch (ultimoCarattere) 
			{
				case 'à': comuneDaCercare += "A'"; break;
				case 'è': comuneDaCercare += "E'"; break;
				case 'é': comuneDaCercare += "E'"; break;
				case 'ì': comuneDaCercare += "I'"; break;
				case 'ò': comuneDaCercare += "O'"; break;
				case 'ù': comuneDaCercare += "U'"; break;
				default: comuneDaCercare += Char.ToUpper(ultimoCarattere); break;
			}
			return comuneDaCercare;
		}

		public static int confrontaUnSingle1ConUnSingle2 (
				Tabelle tabelle,
					tutti_i_single1Row rSingle1,
					tutti_i_single2Row rSingle2
		) {
			bool isComuneDaCercareNuovo = rSingle1.isnuovo; 

			DateTime dataInizio, dataFine;
			string valore1, valore2;

			tabelle.ricavaInfoDalComuneDaImportare (
				rSingle1.idcomune,
				out dataInizio,
				out dataFine,
				out valore1,
				out valore2
			);

			string comuneDaCercare = eliminaAccenti(rSingle1.nome);

			string geo_comune = eliminaAccenti(rSingle2.denominazione);
			bool isGeoComuneNuovo = rSingle2.isnuovo;

			int matchingValue = Matching.match (
				comuneDaCercare,
				isComuneDaCercareNuovo,
				geo_comune,
				isGeoComuneNuovo
			);
			if (!tabelle.confrontaConValoriGiaSulDB(dataInizio, dataFine, valore1, valore2, rSingle2.idcomune)) 
			{
				matchingValue += 10;
			}
			return matchingValue;
		}

		public static void confrontaUnSingle1ConGeoComuni (
			Tabelle tabelle,
			single1_della_provincia_correnteRow rSingle1,
			single2_della_provincia_correnteRow[] rSingle2,
			out int[] valoriDiMatching
			) 
		{
			bool isComuneDaCercareNuovo = rSingle1.isnuovo; 

			DateTime dataInizio, dataFine;
			string valore1, valore2;

			tabelle.ricavaInfoDalComuneDaImportare (
				rSingle1.idcomune,
				out dataInizio,
				out dataFine,
				out valore1,
				out valore2
			);

			string comuneDaCercare = eliminaAccenti(rSingle1.nome);
			valoriDiMatching = new int[rSingle2.Length];

			for (int i=0; i<rSingle2.Length; i++) 
			{
				string geo_comune = eliminaAccenti(rSingle2[i].denominazione);
				bool isGeoComuneNuovo = rSingle2[i].isnuovo;

				valoriDiMatching[i] = Matching.match (
					comuneDaCercare,
					isComuneDaCercareNuovo,
					geo_comune,
					isGeoComuneNuovo
				);

				if (!tabelle.confrontaConValoriGiaSulDB(dataInizio, dataFine, valore1, valore2, rSingle2[i].idcomune)) 
				{
					valoriDiMatching[i] += 10;
				}
			}
		}


		public static void confrontaComuneDaImportareConGeoComuni (
			Tabelle tabelle,
			VistaGeo_Comune.geo_comuni_da_importareRow rComuneDaImportare,
			VistaGeo_Comune.geo_comuneRow[] geoComuniDiUnaProvincia,
			out int[] valoriDiMatching
			) 
		{
			bool isComuneDaCercareNuovo = tabelle.isComuneDaImportareNuovo(rComuneDaImportare);

			DateTime dataInizio = Tabelle.leggiData(rComuneDaImportare["datainizio"]);
			DateTime dataFine = Tabelle.leggiData(rComuneDaImportare["datafine"]);
			string valore1 = rComuneDaImportare.valore1;
			string valore2 = (rComuneDaImportare["valore2"] is DBNull) ? null: rComuneDaImportare.valore2;

			string comuneDaCercare = eliminaAccenti(rComuneDaImportare.nome);
			valoriDiMatching = new int[geoComuniDiUnaProvincia.Length];
			for (int i=0; i<geoComuniDiUnaProvincia.Length; i++) 
			{
				string nomeGeoComune = eliminaAccenti(geoComuniDiUnaProvincia[i].denominazione);
				bool isGeoComuneNuovo = tabelle.isGeoComuneNuovo(geoComuniDiUnaProvincia[i]);

				valoriDiMatching[i] = Matching.match (
					comuneDaCercare,
					isComuneDaCercareNuovo,
					nomeGeoComune,
					isGeoComuneNuovo
				);

				if (!tabelle.confrontaConValoriGiaSulDB(dataInizio, dataFine, valore1, valore2, geoComuniDiUnaProvincia[i].idcomune)) 
				{
					valoriDiMatching[i]+=10; 
				}
			}
		}


		class ConfrontaCoppie:IComparer
		{
			public int Compare(object x, object y) 
			{
				int[] coppia1 = (int[])x;
				int[] coppia2 = (int[])y;
				return coppia1[0]-coppia2[0];
			}
		}

		public static void getCoppie (
			Tabelle tabelle,
			string siglaProvincia,
			ArrayList coppie,
			DataRow[] comuniDaImportare,
			DataRow[] geoComuni,
			out int[] partnerDiTabInGeo,
			out int[] partnerDiGeoInTab
		) {
			partnerDiTabInGeo = new int[comuniDaImportare.Length];
			partnerDiGeoInTab = new int[geoComuni.Length];
			for (int i=0; i<partnerDiTabInGeo.Length; i++)
				partnerDiTabInGeo[i] = -1;
			for (int i=0; i<partnerDiGeoInTab.Length; i++)
				partnerDiGeoInTab[i] = -1;
				coppie.Sort(new ConfrontaCoppie());
			for (int i=0; i<coppie.Count; i++) 
			{
				int matching = ((int[])coppie[i])[0];
				int tab = ((int[])coppie[i])[1];
				int geo = ((int[])coppie[i])[2];
				if ((partnerDiGeoInTab[geo]==-1)&&(partnerDiTabInGeo[tab]==-1)) 
				{
					partnerDiTabInGeo[tab]=geo;
					partnerDiGeoInTab[geo]=tab;
					VistaGeo_Comune.geo_comuni_da_importareRow rComuneDaImportare = (VistaGeo_Comune.geo_comuni_da_importareRow) comuniDaImportare[tab];
					VistaGeo_Comune.geo_comuneRow rGeoComune = (VistaGeo_Comune.geo_comuneRow) geoComuni[geo];
					tabelle.inserisciNuovaRigaInTabellaTutteLeCoppie (
						comuniDaImportare[tab],
						geoComuni[geo],
						siglaProvincia, siglaProvincia,
						tabelle.isComuneDaImportareNuovo(rComuneDaImportare),
						tabelle.isGeoComuneNuovo(rGeoComune),
						matching
					);
				}
			}
			for (int i=0; i<partnerDiTabInGeo.Length; i++) 
			{
				if (partnerDiTabInGeo[i]==-1) 
				{
					tabelle.inserisciNuovaRigaInTabellaTuttiISingle1 (
						comuniDaImportare[i], siglaProvincia
					);
				}
			}
			for (int i=0; i<partnerDiGeoInTab.Length; i++) 
			{
				if (partnerDiGeoInTab[i]==-1) 
				{
					tabelle.inserisciNuovaRigaInTabellaTuttiISingle2 ( 
						geoComuni[i],
						siglaProvincia
					);
				}
			}
		}

		public static void cercaIPrimiDueComuniSomiglianti (
			Tabelle tabelle,
			DataRow[] righeDiGeoComune, int[] valoriDiMatching,
			out string primoComuneTrovato, out string secondoComuneTrovato) 
		{
			primoComuneTrovato = null;
			secondoComuneTrovato = null;
			int matchingValue1 = 1000;
			int matchingValue2 = 1000;
			int indiceMin1 = -1;
			int indiceMin2 = -1;
			for (int i=0; i<valoriDiMatching.Length; i++) 
			{
				if (valoriDiMatching[i] < matchingValue1) 
				{
					matchingValue2 = matchingValue1;
					matchingValue1 = valoriDiMatching[i];
					indiceMin2 = indiceMin1;
					indiceMin1 = i;
				} 
				else 
				{
					if (valoriDiMatching[i] < matchingValue2) 
					  {
						  matchingValue2 = valoriDiMatching[i];
						  indiceMin2 = i;
					  }
				}
			}

			if (matchingValue1 <= Matching.MASSIMO_ACCETTABILE) 
			{
				primoComuneTrovato = tabelle.getNomeDaGeoComuneOSingle2(righeDiGeoComune[indiceMin1]);
			}
			if (matchingValue2 <= Matching.MASSIMO_ACCETTABILE) 
			{
				secondoComuneTrovato = tabelle.getNomeDaGeoComuneOSingle2(righeDiGeoComune[indiceMin2]);
			}

		}
	}
}

