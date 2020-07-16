/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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
using funzioni_configurazione;//funzioni_configurazione
using System.Globalization;
using System.Collections;
using System.Collections.Specialized;
using System.Windows.Forms;
using System.Collections.Generic;

namespace calcolocedolino {//calcolocedolino//
	public struct Cedolino {
		public int annoRiferimento, meseRiferimento;
		public DateTime dataInizio, dataFine;
		public decimal compenso;
		public bool flagErogato;
		public object idupb;
	}

	/// <summary>
	/// Summary description for CalcoliPerLaGenerazione.
	/// </summary>
	public class CalcoliPerLaGenerazione {

		#region calcolo dei cedolini a partire dalle date di inizio e fine

		/// <summary>
		/// Calcola gli stipendi (imponibili previdenziali lordi) dei cedolini basandosi sulle loro
		/// date di inizio e fine e sul compenso in input.
		/// Definiamo nMensili i cedolini che hanno durata multipla del mese.
		/// Definiamo giornalieri tutti gli altri cedolini.
		/// Definiamo nMesi la somma delle durate in mesi dei cedolini mensili.
		/// Definiamo nGiorni la somma delle durate in giorni dei cedolini giornalieri.
		/// Definiamo pagaGiornaliera = compenso / nGiorni
		/// Il compenso di ciascun cedolino giornaliero sar‡ posto uguale alla sua durata in giorni
		/// moltiplicato per la pagaGiornaliera.
		/// Definiamo sommaCedMens = compensoContratto - somma dei compensi dei cedolini giornalieri
		/// Definiamo pagaMensile = sommaCedMens / nmesi
		/// Il compenso di ciascun cedolino mensile sar‡ posto uguale alla sua durata in mesi
		/// moltiplicato per la pagaMensile
		/// </summary>
		/// <param name="dateInizioCedolini">date di inizio di tutti i cedolini</param>
		/// <param name="dateFineCedolini">date di fine di tutti i cedolini</param>
		/// <param name="compensoContratto">compenso da distribuire sui vari cedolini</param>
		/// <returns>array di imponibili di lunghezza pari al numero di mesi del contratto</returns>
		public static decimal[] calcolaStipendiPerTuttoIlContratto(
			DateTime[] dateInizioCedolini, DateTime[] dateFineCedolini, 
			decimal compensoContratto
			) {
            if (dateInizioCedolini == null) return new decimal[0];
            if (dateFineCedolini == null) return new decimal[0];
            int numeroCedolini = dateInizioCedolini.Length;
            if (numeroCedolini==0) return new decimal[0];
            int[] numeroInteroDiMesi = new int[numeroCedolini];
			decimal numMesiInteri = 0;
			int numGiorniSfusi = 0;
			for (int i=0; i<numeroCedolini; i++) {
				bool flagCalcoloARitroso;
				numeroInteroDiMesi[i] = CalcoliPerLaGenerazione.differenzaInMesi(dateInizioCedolini[i], 
					dateFineCedolini[i], out flagCalcoloARitroso);
				if (numeroInteroDiMesi[i]==0) {
					numGiorniSfusi += 1 + (dateFineCedolini[i] - dateInizioCedolini[i]).Days;
				} else {
					numMesiInteri += numeroInteroDiMesi[i];
				}
			}
			DateTime dataInizioContratto = dateInizioCedolini[0];
			DateTime dataFineContratto = dateFineCedolini[numeroCedolini-1];
			decimal numeroGiorniContratto = 1 + (dataFineContratto - dataInizioContratto).Days;
			
			decimal pagaGiornaliera = compensoContratto / numeroGiorniContratto;
			decimal pagaMensile = (numMesiInteri == 0) ? 0
				:(compensoContratto - numGiorniSfusi * pagaGiornaliera) / numMesiInteri;

			decimal[] compensiMensili = new decimal[numeroCedolini];

			for (int i=0; i<numeroCedolini; i++) {
				if (numeroInteroDiMesi[i] == 0) {
					int numGiorniCedolino = 1 + (dateFineCedolini[i] - dateInizioCedolini[i]).Days;
					compensiMensili[i] = pagaGiornaliera * numGiorniCedolino;
				} else {
					compensiMensili[i] = pagaMensile * numeroInteroDiMesi[i];
				}
			}
			return compensiMensili;
		}

		/// <summary>
		/// Calcola i cedolini "standard" dell'anno.
		/// I cedolini gi‡ erogati rimangono inalterati.
		/// Le date di inizio e fine dei cedolini da erogare vengono calcolati 
		/// tramite la chiamata a calcolaDateInizioEFineDeiCedolini
		/// ed i compensi vengono ripartiti tramite la chiamata a calcolaStipendiDiQuestAnno
		/// </summary>
		/// <param name="esercizio">anno fiscale di cui si vuole calcolare i cedolini</param>
		/// <param name="dataInizioContratto">data di inizio del contratto</param>
		/// <param name="dataFineContratto">data di fine del contratto</param>
		/// <param name="rTuttiICedoliniErogati">cedolini gi‡ erogati</param>
		/// <param name="compensoContratto">compenso dell'intero contratto</param>
		/// <param name="sommaRateDiQuestAnno">somma dei compensi dei cedolini di quest'anno</param>
		/// <param name="sommaRateRimanentiContratto">somma dei compensi di cedolini di quest'anno e degli anni successivi</param>
		/// <returns>cedolini dell'anno fiscale dato</returns>
		public static Cedolino[] calcolaStipendiStandardDiQuestAnno(
			int esercizio, DateTime dataInizioContratto, 
			DateTime dataFineContratto,
			DataRow[] rTuttiICedoliniErogati, 
			decimal compensoContratto, 
			out decimal sommaRateDiQuestAnno, out decimal sommaRateRimanentiContratto) { 
			DateTime dataPrimoCedolinoDaErogare = (rTuttiICedoliniErogati.Length==0) 
				? dataInizioContratto
				: ((DateTime) rTuttiICedoliniErogati[rTuttiICedoliniErogati.Length-1]["stop"]).AddDays(1);

			DateTime[] dateInizioCedoliniDaErogare, dateFineCedoliniDaErogare;
			calcolaDateInizioEFineDeiCedolini(
				dataPrimoCedolinoDaErogare, 
				dataFineContratto, 1,
				out dateInizioCedoliniDaErogare, out dateFineCedoliniDaErogare);

			return calcolaStipendiDiQuestAnno(esercizio,
				rTuttiICedoliniErogati,
				compensoContratto, 
				dateInizioCedoliniDaErogare, dateFineCedoliniDaErogare,
				out sommaRateDiQuestAnno, out sommaRateRimanentiContratto);
		}


		/// <summary>
		/// Calcola i compensi (ed altre informazioni accessorie) dei cedolini di un dato anno 
		/// a partire da tutte le date di inizio e fine dei cedolini del contratto.
		/// I cedolini gi‡ erogati rimangono inalterati.
		/// Viene chiamato il metodo calcolaStipendiPerTuttoIlContratto per calcolare tutti i cedolini del contratto.
		/// Sui primi cedolini da erogare viene effettuata una sorta di compensazione tra quanto
		/// gi‡ erogato e quanto si sarebbe dovuto erogare.
		/// </summary>
		/// <param name="esercizio">anno fiscale di cui si vogliono calcolare i cedolini</param>
		/// <param name="rCedoliniErogati">cedolini gi‡ erogati</param>
		/// <param name="compensoContratto">compenso del contratto</param>
		/// <param name="dateInizioCedoliniDaErogare">date di inizio di tutti i cedolini ancora da erogare</param>
		/// <param name="dateFineCedoliniDaErogare">date di fine di tutti i cedolini ancora da erogare</param>
		/// <param name="sommaRateDiQuestAnno">somma dei compensi erogati e non erogati di quest'anno fiscale</param>
		/// <param name="sommaRateRimanentiContratto">somma dei compensi erogati e non erogati di questo e dei successivi anni fiscali</param>
		/// <returns>cedolini di un dato anno fiscale</returns>
		public static Cedolino[] calcolaStipendiDiQuestAnno(
			int esercizio,
			DataRow[] rCedoliniErogati, 
			decimal compensoContratto, 
			DateTime[] dateInizioCedoliniDaErogare,
			DateTime[] dateFineCedoliniDaErogare,
			out decimal sommaRateDiQuestAnno, out decimal sommaRateRimanentiContratto
			) {
			int numCedolini = rCedoliniErogati.Length + dateInizioCedoliniDaErogare.Length;
			DateTime[] dateInizioTuttiICedolini = new DateTime[numCedolini];
			DateTime[] dateFineTuttiICedolini = new DateTime[numCedolini];

			decimal compensoGiaErogato = 0;
			for (int i = 0; i<rCedoliniErogati.Length; i++) {
				dateInizioTuttiICedolini[i] = (DateTime)rCedoliniErogati[i]["start"];
				dateFineTuttiICedolini[i] = (DateTime)rCedoliniErogati[i]["stop"];
				compensoGiaErogato += (decimal)rCedoliniErogati[i]["feegross"];
			}

			dateInizioCedoliniDaErogare.CopyTo(dateInizioTuttiICedolini, rCedoliniErogati.Length);
			dateFineCedoliniDaErogare.CopyTo(dateFineTuttiICedolini, rCedoliniErogati.Length);

			int primoCedolinoAnnoFiscale, ultimoCedolinoAnnoFiscale;
			getPrimoEUltimoCedolinoAnnoFiscale(
				esercizio, rCedoliniErogati, dateInizioTuttiICedolini, dateFineTuttiICedolini,
				out primoCedolinoAnnoFiscale, out ultimoCedolinoAnnoFiscale);

			//DateTime dataInizioCompetenza = dateInizioTuttiICedolini[primoCedolinoAnnoFiscale];

			int primoCedolinoDaErogare = rCedoliniErogati.Length;

			//Calcola gli stipendi per tutta la durata del contratto
			decimal[] compensiCedolini = calcolaStipendiPerTuttoIlContratto(
				dateInizioTuttiICedolini,
				dateFineTuttiICedolini,
				compensoContratto
				);
			
			int meseRif = 1;
			int annoRif = esercizio;
			if (primoCedolinoDaErogare > 0) {
                meseRif = 1 + (int)rCedoliniErogati[primoCedolinoDaErogare - 1]["npayroll"];
			}

			decimal compensoCheAvreiDovutoErogare = 0;
			for (int i=0; i<primoCedolinoDaErogare; i++) {
				compensoCheAvreiDovutoErogare += compensiCedolini[i];
			}
			sommaRateDiQuestAnno = 0;
			int numeroRate = 1 + ultimoCedolinoAnnoFiscale - primoCedolinoAnnoFiscale;
		    if (ultimoCedolinoAnnoFiscale == -1 || primoCedolinoAnnoFiscale == -1) {
		        numeroRate = 0;
		    }
            //La differenza tra il compenso erogato finora ed il compenso che avrei dovuto erogare
            //viene sottratto nei primi cedolini da erogare
            decimal differenza = compensoGiaErogato - compensoCheAvreiDovutoErogare;

            decimal compensoDaErogare = compensoContratto - compensoGiaErogato;
            if (compensoDaErogare == 0) { 
                numeroRate = 0;
            }
            Cedolino[] cedoliniDiQuestAnno = new Cedolino[numeroRate];


            for (int i=0; i<cedoliniDiQuestAnno.Length; i++) {
				if ((i+primoCedolinoAnnoFiscale < primoCedolinoDaErogare) && (i + primoCedolinoAnnoFiscale>=0)) {
					cedoliniDiQuestAnno[i].annoRiferimento = (int) rCedoliniErogati[i + primoCedolinoAnnoFiscale]["fiscalyear"];
					cedoliniDiQuestAnno[i].meseRiferimento = (int) rCedoliniErogati[i + primoCedolinoAnnoFiscale]["npayroll"];
					cedoliniDiQuestAnno[i].compenso = (decimal) rCedoliniErogati[i + primoCedolinoAnnoFiscale]["feegross"];
                    cedoliniDiQuestAnno[i].flagErogato = true;

                } else {
					cedoliniDiQuestAnno[i].annoRiferimento = annoRif;
					cedoliniDiQuestAnno[i].meseRiferimento = meseRif;
					meseRif++;
                    decimal compensoCorr = i + primoCedolinoAnnoFiscale>=0? compensiCedolini[i + primoCedolinoAnnoFiscale]:0;
					if (differenza != 0) {
						decimal conguaglio = (compensoCorr > differenza) ? differenza 	: compensoCorr;
                        compensoCorr -= conguaglio;
						differenza -= conguaglio;
					}
                    
                    cedoliniDiQuestAnno[i].compenso = (compensoCorr > compensoDaErogare)
                        ? compensoDaErogare : compensoCorr;
                    compensoDaErogare -= cedoliniDiQuestAnno[i].compenso;
                    cedoliniDiQuestAnno[i].flagErogato = false;
                }
				cedoliniDiQuestAnno[i].dataInizio = dateInizioTuttiICedolini[i + primoCedolinoAnnoFiscale];
				cedoliniDiQuestAnno[i].dataFine = dateFineTuttiICedolini[i + primoCedolinoAnnoFiscale];
				//cedoliniDiQuestAnno[i].flagErogato = (i < primoCedolinoDaErogare);
				sommaRateDiQuestAnno += cedoliniDiQuestAnno[i].compenso;
			}

            //Calcola le rate rimanenti del contratto come la somma di tutti i compensi dei cedolini a partire dal primo cedolino non erogato 
            // di quest'anno fino alla fine del contratto
			sommaRateRimanentiContratto = sommaRateDiQuestAnno;
			if (ultimoCedolinoAnnoFiscale != -1) {
				for (int i=ultimoCedolinoAnnoFiscale+1; i<compensiCedolini.Length; i++) {
					sommaRateRimanentiContratto += compensiCedolini[i];
				}
			}
			return cedoliniDiQuestAnno;
		}

        #endregion

        #region ripartizione temporale dei cedolini

        /// <summary>
        /// Calcola le date di inizio e fine di tutti i cedolini basandosi
        /// sulla data di inizio del primo cedolino, sulla data di fine dell'ultimo cedolino
        /// e sulla periodicit‡ desiderata dei cedolini.
        /// </summary>
        /// <param name="dataInizio">data di inizio del primo cedolino</param>
        /// <param name="dataFine">data di fine dell'ultimo cedolino</param>
        /// <param name="periodicita">desiderata durata in mesi dei cedolini</param>
        /// <param name="dateInizioCedolini">date di inizio di tutti i cedolini</param>
        /// <param name="dateFineCedolini">date di fine di tutti i cedolini</param>
        public static void calcolaDateInizioEFineDeiCedolini(
            DateTime dataInizio, DateTime dataFine,
            int periodicita,
            out DateTime[] dateInizioCedolini, out DateTime[] dateFineCedolini) {
            if (dataInizio > dataFine) {
                dateInizioCedolini = new DateTime[0];
                dateFineCedolini = new DateTime[0];
                return;
            }
            dataInizio = dataInizio.Date;
            dataFine = dataFine.Date;

            bool flagCalcoloARitroso = false;
            int diffMesi = differenzaInMesi(dataInizio, dataFine, out flagCalcoloARitroso);
            if (((periodicita == 1) && (diffMesi == 0)) || (dataFine.Year - dataInizio.Year) > 0) {
                //Se non Ë un n. di mesi esatto oppure Ë a cavallo d'annno
                //int numCedolini = 1 + 12 * (dataFine.Year - dataInizio.Year) + dataFine.Month - dataInizio.Month;

                List<DateTime> listaDateInizio = new List<DateTime>();
                List<DateTime> listaDateFine = new List<DateTime>();
 
                DateTime dataInizioCedolino = dataInizio;

                while (dataInizioCedolino.CompareTo(dataFine) <= 0) {
                    var dataFineCedolino = dataInizioCedolino.AddMonths(periodicita).AddDays(-1);
                    if (dataFineCedolino.CompareTo(dataFine) > 0) {
                        dataFineCedolino = dataFine;
                    }

                    if (dataFineCedolino.Year > dataInizioCedolino.Year) {
                        listaDateInizio.Add(dataInizioCedolino);
                        listaDateFine.Add(new DateTime(dataInizio.Year, 12, 31));
                        dataInizioCedolino = new DateTime(dataInizio.Year + 1, 1, 1);
                        dataFineCedolino = dataInizioCedolino.AddMonths(periodicita).AddDays(-1);
                        if (dataFineCedolino.CompareTo(dataFine) > 0) dataFineCedolino = dataFine;
                    }
                    listaDateInizio.Add(dataInizioCedolino);
                    listaDateFine.Add(dataFineCedolino);


                    dataInizioCedolino = dataFineCedolino.AddDays(1);
                }

                dateInizioCedolini = listaDateInizio.ToArray();
                dateFineCedolini = listaDateFine.ToArray();
                return;
            }
        
			int numCedoliniNMensili = (diffMesi<periodicita) ? 1 : diffMesi / periodicita;

			if (numCedoliniNMensili*periodicita != diffMesi) {
				int numCedolini = 1;
				while (dataInizio.AddMonths(periodicita*(numCedolini+1)) <= dataFine) {
					numCedolini ++;
				}
				dateInizioCedolini = new DateTime[numCedolini];
				dateFineCedolini = new DateTime[numCedolini];
				for (int i=0; i<numCedolini; i++) {
					dateInizioCedolini[i] = dataInizio.AddMonths(i*periodicita);
					dateFineCedolini[i] = dataInizio.AddMonths((i+1)*periodicita).AddDays(-1);
				}
				dateFineCedolini[numCedolini-1] = dataFine;
				return;
			}

			dateInizioCedolini = new DateTime[numCedoliniNMensili];
			dateFineCedolini = new DateTime[numCedoliniNMensili];
			if (flagCalcoloARitroso) {
				DateTime d = dataFine.AddDays(1);
				for (int i=0; i<numCedoliniNMensili; i++) {
					dateInizioCedolini[i] = d.AddMonths(i*periodicita-diffMesi);
					dateFineCedolini[i] = d.AddMonths((i+1)*periodicita-diffMesi).AddDays(-1);
				}
			} else {
				for (int i=0; i<numCedoliniNMensili; i++) {
					dateInizioCedolini[i] = dataInizio.AddMonths(i*periodicita);
					dateFineCedolini[i] = dataInizio.AddMonths((i+1)*periodicita).AddDays(-1);
				}
			}
		}

		#endregion

		#region elaborazioni varie sulle date dei cedolini

		/// <summary>
		/// Dato l'array delle date di inizio e fine di tutti i cedolini del contratto
		/// e l'array dei cedolini gi‡ erogati, restituisce gli indici del primo e dell'ultimo
		/// cedolino dell'anno fiscale specicato
		/// </summary>
		/// <param name="esercizio">anno fiscale di cui si vuole cercare il primo e l'ultimo cedolino</param>
		/// <param name="rCedoliniErogati">cedolini gi‡ erogati ordinati per datainizio</param>
		/// <param name="dateInizioTuttiICedolini">date di inizio di tutti i cedolini (ordinate)</param>
		/// <param name="dateFineTuttiICedolini">date di fine di tutti i cedolini (ordinate)</param>
		/// <param name="primoCedolinoAnnoFiscale">indice del primo cedolino del dato anno fiscale</param>
		/// <param name="ultimoCedolinoAnnoFiscale">indice dell'ultimo cedolino del dato anno fiscale</param>
		public static void getPrimoEUltimoCedolinoAnnoFiscale(
			int esercizio, DataRow[] rCedoliniErogati,
			DateTime[] dateInizioTuttiICedolini, DateTime[]dateFineTuttiICedolini,
			out int primoCedolinoAnnoFiscale, out int ultimoCedolinoAnnoFiscale) {
            if (dateInizioTuttiICedolini.Length == 0) {
                primoCedolinoAnnoFiscale = -1;
                ultimoCedolinoAnnoFiscale = -1;
                return;
            }
			primoCedolinoAnnoFiscale=0;
			while ((primoCedolinoAnnoFiscale < rCedoliniErogati.Length) &&
				((int)rCedoliniErogati[primoCedolinoAnnoFiscale]["fiscalyear"] < esercizio)) {
				primoCedolinoAnnoFiscale ++;
			}
            if (primoCedolinoAnnoFiscale == dateInizioTuttiICedolini.Length) {
                primoCedolinoAnnoFiscale=-1;
                ultimoCedolinoAnnoFiscale = -1;
                return;
             }
            if ((dateInizioTuttiICedolini.Length == 0) || (dateInizioTuttiICedolini[0].Year>esercizio)) {
                primoCedolinoAnnoFiscale = -1;
                ultimoCedolinoAnnoFiscale = -1; //non dovrebbe passare mai di qua
            }
            else {
                ultimoCedolinoAnnoFiscale = dateInizioTuttiICedolini.Length - 1;
                while(dateInizioTuttiICedolini[ultimoCedolinoAnnoFiscale].Year > esercizio) {
                    ultimoCedolinoAnnoFiscale--;
                }
                if(dateFineTuttiICedolini[ultimoCedolinoAnnoFiscale] > new DateTime(esercizio + 1, 1, 12)) {
                    ultimoCedolinoAnnoFiscale--;
                }
            }
           if (ultimoCedolinoAnnoFiscale == -1 || ultimoCedolinoAnnoFiscale < primoCedolinoAnnoFiscale) {
               primoCedolinoAnnoFiscale = -1;
               ultimoCedolinoAnnoFiscale = -1;
           }
		}

		/// <summary>
		/// Se la data di fine del contratto appartiene all'anno dato allora viene restituita tale date.
		/// Altrimenti se esiste un numero n di mesi multiplo della periodicit‡ che, sommato alla data di inizio
		/// mi d‡ un giorno compreso tra l'1 ed il 12 gennaio dell'anno successivo all'esercizio,
		/// allora viene restituito tale giorno.
		/// Altrimenti viene restituito il 31 dicembre dell'anno dell'esercizio.
		/// </summary>
		/// <param name="esercizio">anno fiscale di cui si vuole calcolare la data fine competenza.</param>
		/// <param name="dataInizio">data di inizio del primo cedolino da erogare</param>
		/// <param name="dataFineContratto">data di fine del contratto</param>
		/// <param name="periodicita">durata in mesi dei cedolini</param>
		/// <returns></returns>
		public static DateTime calcolaFineCompetenzaAnnoFiscale(int esercizio,
			DateTime dataInizio,
			DateTime dataFineContratto, 
			int periodicita
			) {
			DateTime dataFineCompetenza = dataFineContratto;

			if (dataFineContratto.Year > esercizio) {
				DateTime gennaio12 = new DateTime(esercizio+1, 1, 12);
				dataFineCompetenza = dataInizio.AddDays(-1);
				int numMesi = periodicita;
				while (dataInizio.AddMonths(numMesi).AddDays(-1) <= gennaio12) {
					dataFineCompetenza = dataInizio.AddMonths(numMesi).AddDays(-1);
					numMesi += periodicita;
				}
				if (dataFineCompetenza.Year <= esercizio) {
					dataFineCompetenza = new DateTime(esercizio, 12, 31);
				}
			}
			return dataFineCompetenza;
		}

		/// <summary>
		/// Restituisce la differenza in mesi tra due date, estremi compresi
		/// se tale differenza Ë un numero intero; altrimenti restituisce 0.
		/// Nel caso di restituzione di un numero intero num varr‡ la seguente equazione:
		/// inizio.AddMonths(num) = fine.AddDays(1)
		/// In altri termini: 
		/// (1) se il inizio.Day=1 allora fine.Day Ë l'ultimo giorno del mese;
		/// (2) se invece inizio.Day Ë compreso tra 2 ed il penultimo giorno del mese di fine, 
		///			allora deve valere inizio.Day-1 = fine.Day;
		/// (3) se invece inizio.Day Ë uguale o maggiore dell'ultimo giorno del mese di fine 
		///			allora fine.Day deve essere il penultimo giorno del mese di fine.
		/// Esempi: (supponiamo di essere in un anno non bisestile)
		/// caso (1):
		///		(1gen-31gen)->1; (1gen-28feb)->2
		/// caso (2):
		///		(12gen-11feb)->1; (27gen-26feb)->1; (30 apr-29lug)->3
		///	caso (3)
		///		(28gen-27feb)->1; (29gen-27feb)->1 (30gen-27feb)->1
		///	Verr‡ restituito 0 ad esempio in questi casi:
		///	(28gen-28feb) infatti 28gen.AddMonths(1)=28feb <> 28feb.AddDays(1)=1mar
		///	(31gen-28feb) infatti 31gen.AddMonths(1)=28feb <> 28feb.AddDays(1)=1mar
		///	
		///	Il flagCalcoloARitroso sar‡ posto a true se valgono le seguenti condizioni:
		///		il mese di inizio ha meno giorni del mese di fine;
		///		il giorno di inizio Ë l'ultimo del mese di inizio;
		///		il giorno di fine Ë compreso tra il penultimo giorno del mese di inizio ed il penultimo giorno del mese di fine
		///	
		///	Se numMesi Ë il valore restituito da questa funzione, allora:
		///	Se flagCalcoloARitroso Ë false allora le date di inizio vanno calcolate con la formula
		///		for (int i=0; i<numMesi; i++) dateInizio[i] = inizio.AddMonths(i);
		///	Se invece Ë true allora:
		///		for (int i=0; i<numMesi; i++) dateInizio[i] = fine.AddDays(1).AddMonths(i+1-diff);
		/// </summary>
		/// <param name="inizio"></param>
		/// <param name="fine"></param>
		/// <param name="flagCalcoloARitroso"></param>
		/// <returns></returns>
		public static int differenzaInMesi(DateTime inizio, DateTime fine, out bool flagCalcoloARitroso) {
			flagCalcoloARitroso = false;
			int diff = 12 * (fine.Year - inizio.Year) + fine.Month - inizio.Month;
			int ultimoGiornoUltimoMese = DateTime.DaysInMonth(fine.Year, fine.Month);

			if ((inizio.Day == 1) && (fine.Day == ultimoGiornoUltimoMese)) {
				return 1 + diff;
			}
			int giorniPrimoMese = DateTime.DaysInMonth(inizio.Year, inizio.Month);
			int giorniUltimoMese = DateTime.DaysInMonth(fine.Year, fine.Month);

			if ((giorniPrimoMese < giorniUltimoMese) && (inizio.Day == giorniPrimoMese) 
				&& (giorniPrimoMese-1 <= fine.Day) && (fine.Day<=giorniUltimoMese-1)) {
				flagCalcoloARitroso = true;
				return diff;
			}
			if (inizio.AddMonths(diff).AddDays(-1) == fine) {
				return diff;
			}
			return 0;
		}
		#endregion
	}
}