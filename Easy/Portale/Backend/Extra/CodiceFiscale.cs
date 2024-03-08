
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


using metadatalibrary;
using System;
using System.Collections.Generic;
using System.Data;
using Backend.Extensions;

namespace Backend {

    /// <summary>
    /// Helper class for codice fiscale
    /// </summary>
    public class CodiceFiscale {

        // TABELLA [ A ] (caratteri in posizione pari)
        //  0=0  1=1  2=2  3=3  4=4  5=5  6=6  7=7  8=8  9=9
        //  A=0  B=1  C=2  D=3  E=4  F=5  G=6  H=7  I=8  J=9
        //  K=10 L=11 M=12 N=13 O=14 P=15 Q=16 R=17 S=18 T=19
        //  U=20 V=21 W=22 X=23 Y=24 Z=25
        private static Dictionary<char, int> _tabellaA;

        // TABELLA [ B ] (caratteri in posizione dispari)
        //  0=1  1=0  2=5  3=7  4=9  5=13 6=15 7=17 8=19 9=21
        //  A=1  B=0  C=5  D=7  E=9  F=13 G=15 H=17 I=19 J=21
        //  K=2  L=4  M=18 N=20 O=11 P=3  Q=6  R=8  S=12 T=14
        //  U=16 V=10 W=22 X=25 Y=24 Z=23
        private static Dictionary<char, int> _tabellaB;

        static CodiceFiscale() {
            _tabellaA = new Dictionary<char, int>() {
                { '0', 0 },
                { '1', 1 },
                { '2', 2 },
                { '3', 3 },
                { '4', 4 },
                { '5', 5 },
                { '6', 6 },
                { '7', 7 },
                { '8', 8 },
                { '9', 9 },
                { 'A', 0 },
                { 'B', 1 },
                { 'C', 2 },
                { 'D', 3 },
                { 'E', 4 },
                { 'F', 5 },
                { 'G', 6 },
                { 'H', 7 },
                { 'I', 8 },
                { 'J', 9 },
                { 'K', 10 },
                { 'L', 11 },
                { 'M', 12 },
                { 'N', 13 },
                { 'O', 14 },
                { 'P', 15 },
                { 'Q', 16 },
                { 'R', 17 },
                { 'S', 18 },
                { 'T', 19 },
                { 'U', 20 },
                { 'V', 21 },
                { 'W', 22 },
                { 'X', 23 },
                { 'Y', 24 },
                { 'Z', 25 }
            };

            _tabellaB = new Dictionary<char, int>() {
                { '0', 1 },
                { '1', 0 },
                { '2', 5 },
                { '3', 7 },
                { '4', 9 },
                { '5', 13 },
                { '6', 15 },
                { '7', 17 },
                { '8', 19 },
                { '9', 21 },
                { 'A', 1 },
                { 'B', 0 },
                { 'C', 5 },
                { 'D', 7 },
                { 'E', 9 },
                { 'F', 13 },
                { 'G', 15 },
                { 'H', 17 },
                { 'I', 19 },
                { 'J', 21 },
                { 'K', 2 },
                { 'L', 4 },
                { 'M', 18 },
                { 'N', 20 },
                { 'O', 11 },
                { 'P', 3 },
                { 'Q', 6 },
                { 'R', 8 },
                { 'S', 12 },
                { 'T', 14 },
                { 'U', 16 },
                { 'V', 10 },
                { 'W', 22 },
                { 'X', 25 },
                { 'Y', 24 },
                { 'Z', 23 }
            };
        }

        private static int getValueTabA(char c) {
            int value = 0;
            _tabellaA.TryGetValue(c, out value);
            return value;
        }

        private static int getValueTabB(char c) {
            int value = 0;
            _tabellaB.TryGetValue(c, out value);
            return value;
        }

        // TABELLA [ C ] (conversione del carattere di controllo)
        //  0=A  1=B  2=C  3=D  4=E  5=F  6=G  7=H  8=I  9=J
        //  10=K 11=L 12=M 13=N 14=O 15=P 16=Q 17=R 18=S 19=T
        //  20=U 21=V 22=W 23=X 24=Y 25=Z 
        private static char getValueTabC(int c, out bool isValid) {
            isValid = true;
            //			string VA = " errore nel carattere di controllo " ;
            string tabC = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if ((c < 0) || (c > 25)) {
                isValid = false;
                aggiungiErrore("Errore nel carattere di controllo");
                return '?';
            }
            return tabC[c];
        }

        private static string sostituisciLetteraConNumero(string cf, int pos) {
            string sostituzioni = "LMNPQRSTUV";
            int numero = sostituzioni.IndexOf(cf[pos]);
            if (numero != -1) {
                cf = cf.Substring(0, pos) + numero + cf.Substring(pos + 1);
            }
            return cf;
        }
        /// <summary>
        /// Sostituisce le lettere in certe posizioni con numeri
        /// </summary>
        /// <param name="codicefiscale"></param>
        /// <returns></returns>
        public static string normalizza(string codicefiscale) {
            codicefiscale = sostituisciLetteraConNumero(codicefiscale, 6);
            codicefiscale = sostituisciLetteraConNumero(codicefiscale, 7);
            codicefiscale = sostituisciLetteraConNumero(codicefiscale, 9);
            codicefiscale = sostituisciLetteraConNumero(codicefiscale, 10);
            codicefiscale = sostituisciLetteraConNumero(codicefiscale, 12);
            codicefiscale = sostituisciLetteraConNumero(codicefiscale, 13);
            return sostituisciLetteraConNumero(codicefiscale, 14);
        }

        private static string _mErrori = "";

        /// <summary>
        /// Restituisce True se il codicefiscale privato/azienda risulta valido
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="r"></param>
        /// <param name="errori"></param>
        /// <returns></returns>
        public static bool codiceFiscaleValido(DataAccess conn, DataRow r, out string errori) {
            errori = "";
            string codicefiscale = r["cf"].ToString().ToUpper();
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
            string idgeo = r["idcity"].ToString();
            if (r["idnation"].ToString() != "") {
                tipoGeo = "N";
                idgeo = r["idnation"].ToString();
            }
            bool isValid;
            char carControllo = getLastChar(codicefiscale.Substring(0, 15), out isValid);
            string cfNormal = normalizza(codicefiscale);
            string codicefiscalecalcolato =
               make(conn,
                    r["forename"].ToString(),
                    r["surname"].ToString(),
                    r["birthdate"],
                    idgeo,
                    r["gender"].ToString(),
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
        public static string make(string nome, string cognome,
            object dataNascita, string codiceComune, string sesso,
            out bool isValid, out string errori) {

            pulisciErrori();
            isValid = true;
            errori = "";
            string r = "";

            bool valido;
            r += getCodCognome(cognome.stripDiacritics(), out valido);
            isValid = (isValid && valido);
            valido = true;
            r += getCodNome(nome.stripDiacritics(), out valido);
            isValid = (isValid && valido);
            valido = true;
            r += getCodDataNascita(dataNascita, sesso, out valido);
            isValid = (isValid && valido);
            valido = true;
            r += getCodComuneNascita(codiceComune, out valido);
            isValid = (isValid && valido);
            valido = true;
            r += getLastChar(r, out valido);
            isValid = (isValid && valido);
            errori = leggiErrori();
            return r;
        }

        /// <summary>
        /// Verifica un codice fiscale
        /// </summary>
        /// <param name="codicefiscale"></param>
        /// <returns></returns>
        public static string checkCf(string codicefiscale) {
            codicefiscale = codicefiscale.ToUpper();

            string lastchar;
            string codice;
            // Controllo sulla lunghezza, se non rispettata è inutile effettuare altri controlli
            if (codicefiscale.Length != 16) {
                return "Lunghezza non corretta";
            }
            // Controllo sulla congruità del CF rispetto alle info date
            // Controllo sull'ultimo carattere
            bool isValid;
            codice = codicefiscale.Substring(0, (codicefiscale.Length - 1));
            lastchar = getLastChar(codice, out isValid).ToString();
            if ((!isValid) || (lastchar != codicefiscale[codicefiscale.Length - 1].ToString())) {
                return "Ultimo carattere non valido";
            }

            return null;
        }


        private static object findAgencyCode(DataAccess conn, string idgeo, string tipo) {
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
            return conn.DO_READ_VALUE(geoTabella, "(" + geoCampo
                + "=" + QueryCreator.quotedstrvalue(idgeo, true)
                + ") AND (idagency=1) and (idcode=1)", "value");
        }

        /// <summary>
        /// Restituisce il valore di un codice ente conoscendo il codice id della entità geo 
        /// </summary>
        /// <param name="conn">Connessione</param>
        /// <param name="nome"></param>
        /// <param name="cognome"></param>
        /// <param name="dataNascita"></param>
        /// <param name="idgeo">id della entità geo (geo_comune, geo_provincia, etc)...</param>
        /// <param name="sesso"></param>
        /// <param name="tipoGeo">"C" = Comune (default), "P" = Provincia, "R" = Regione, "N" = Nazione</param>
        /// <param name="isValid"></param>
        /// <param name="errori"></param>
        /// <returns></returns>
        public static string make(DataAccess conn, string nome, string cognome,
            object dataNascita, string idgeo, string sesso, string tipoGeo,
            out bool isValid, out string errori) {

            pulisciErrori();
            errori = "";
            isValid = true;

            if (idgeo.Trim() == "") return make(nome, cognome, dataNascita, "", sesso, out isValid, out errori);

            //default impostato su Comune
            if (tipoGeo == "") tipoGeo = "C";

            try {
                string codiceComune = findAgencyCode(conn, idgeo, tipoGeo).ToString();
                return make(nome, cognome, dataNascita, codiceComune, sesso, out isValid, out errori);
            }
            catch {
                isValid = false;
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
        /// <param name="nome"></param>
        /// <param name="isValid"></param>
        /// <returns></returns>
        private static string getCodNome(string nome, out bool isValid) {
            isValid = true;
            string r = "";
            nome = nome.Trim();
            if (nome == "") {
                isValid = false;
                aggiungiErrore("Nome mancante");
                return r;
            }
            foreach (Char c in nome) {
                if (c.isConsonant()) {
                    //Prende le prime quattro consonanti
                    if (r.Length < 4) r += c;
                }
            }

            if (r.Length >= 4) {
                r = r.Remove(1, 1); //rimuove la seconda consonante e conserva 1,3,4.
                return r;
            }
            if (r.Length == 3) return r;

            //Se le consonanti sono meno di tre
            foreach (Char c in nome) {
                if ((r.Length < 3) && c.isVowel()) r += c;

            }
            if (r.Length < 3) {
                //Aggiunge una X per ogni carattere mancante
                while (r.Length < 3) r += "X";
            }
            return r;
        }


        /// <summary>
        ///	Tre caratteri alfabetici maiuscoli della prima, seconda e terza (1',2',3') consonante del Cognome.
        ///	Se le consonanti per il Cognome fossero meno di tre, aggiungere le vocali nello stesso ordine in cui si presentano.
        ///	Se l'intero Cognome fosse piu' corto di tre caratteri, aggiungere una X per ogni carattere mancante.
        ///	Per le donne coniugate considerare solo il Cognome da nubile.
        ///	Nei Cognomi composti da piu' parti, gli spazi intermedi non vanno considerati
        ///	( es. De Rossi D'Aquino sara' DEROSSIDAQUINO ).
        /// </summary>
        /// <param name="cognome"></param>
        /// <param name="isValid"></param>
        /// <returns></returns>
        private static string getCodCognome(string cognome, out bool isValid) {
            isValid = true;
            string r = "";
            cognome = cognome.Trim();
            if (cognome == "") {
                isValid = false;
                aggiungiErrore("Cognome mancante");
                return r;
            }
            foreach (Char c in cognome) {
                //Prende le prime tre consonanti
                if (c.isConsonant() && (r.Length < 3)) r += c;
            }

            if (r.Length == 3) return r;

            //Se le consonanti sono meno di tre
            foreach (Char c in cognome) {
                if ((r.Length < 3) && c.isVowel()) r += c;
            }
            //Aggiunge una X per ogni carattere mancante
            while (r.Length < 3) r += "X";
            return r;
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
        private static string getCodDataNascita(object objDataNascita, string sesso,
            out bool isValid) {

            isValid = true;

            if (!(objDataNascita is DateTime)) {
                isValid = false;
                aggiungiErrore("Data mancante");
                return " Data mancante ";
            }

            DateTime dataDiNascita = (DateTime)objDataNascita;

            if (sesso == "") {
                isValid = false;
                aggiungiErrore("Sesso mancante");
                return " Sesso mancante ";
            }
            sesso = sesso.ToUpper();

            int anno = dataDiNascita.Year % 100;
            string Anno = (anno < 10) ? "0" + anno.ToString() : anno.ToString();

            char mese = "ABCDEHLMPRST"[dataDiNascita.Month - 1];

            int giorno = (sesso == "F") ? 40 + dataDiNascita.Day : dataDiNascita.Day;
            string Giorno = (giorno < 10) ? "0" + giorno.ToString() : giorno.ToString();

            return Anno + mese + Giorno;
        }

        private static string getCodComuneNascita(string codComune, out bool isValid) {
            isValid = true;
            if (codComune == "") {
                isValid = false;
                aggiungiErrore("Comune mancante");
                return "-Codice Comune Mancante-";
            }
            return codComune;
        }

        /// <summary>
        /// Calcola il carattere di controllo del codice fiscale
        /// </summary>
        /// <param name="codice"></param>
        /// <param name="isValid"></param>
        /// <returns></returns>
        public static char getLastChar(string codice, out bool isValid) {
            isValid = true;
            int count = 0;
            bool isPair = true;
            decimal somma = 0;
            foreach (Char c in codice) {
                count++;
                isPair = !isPair;
                if (isPair) somma += getValueTabA(c);
                else somma += getValueTabB(c);
            }
            int restoInt = Convert.ToInt32(somma) % 26;
            return getValueTabC(restoInt, out isValid);
        }

        private static string leggiErrori() {
            return _mErrori;
        }

        private static void pulisciErrori() {
            _mErrori = "";
        }
        private static void aggiungiErrore(string msg) {
            _mErrori += "- " + msg + "\r";
        }
    }

    /// <summary>
    /// Decodifica alcune informazioni del codice fiscale
    /// </summary>
    public class InfoDaCodiceFiscale {
        /// <summary>
        /// idgeo del comune, o null se codice errato
        /// </summary>
        public static string comune(DataAccess conn, string codicefiscale) {
            if (codicefiscale.Length != 16) return null;
            string codicecomune = codicefiscale.Substring(11, 4);
            string[] param = new string[] { "@codecity", "@idcity" };
            SqlDbType[] types = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.Int };
            int[] typelen = new int[] { 4, 0 };
            ParameterDirection[] dir = new ParameterDirection[] { ParameterDirection.Input, ParameterDirection.Output };
            object[] values = new object[2] { codicecomune, null };
            bool res = conn.CallSPParameter("compute_idcity_from_cf", param, types, typelen, dir, ref values, true, -1);
            if (!res) return null;
            return values[1].ToString();
        }

        /// <summary>
        /// idgeo della nazione, o null se codice errato
        /// </summary>
        public static string nazione(DataAccess conn, string codicefiscale) {
            if (codicefiscale.Length != 16) return null;
            string codicenazione = codicefiscale.Substring(11, 4);
            string[] param = new string[] { "@codenation", "@idnation" };
            SqlDbType[] types = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.Int };
            int[] typelen = new int[] { 4, 0 };
            ParameterDirection[] dir = new ParameterDirection[] { ParameterDirection.Input, ParameterDirection.Output };
            object[] values = new object[2] { codicenazione, null };
            bool res = conn.CallSPParameter("compute_idnation_from_cf", param, types, typelen, dir, ref values, true, -1);
            if (!res) return null;
            return values[1].ToString();
        }

        /// <summary>
        /// M/F o null se codice errato
        /// </summary>
        public static string sesso(string codicefiscale) {
            if (codicefiscale.Length != 16) return null;
            try {
                int giorno = Convert.ToInt32(codicefiscale.Substring(9, 2));
                if (giorno > 40) return "F";
                return "M";
            }
            catch (Exception e) {
                QueryCreator.MarkEvent("InfoDaCodiceFiscale.Sesso() - " + e.Message);
                return null;
            }
        }

        /// <summary>
        /// data di nascita o null se codice errato
        /// </summary>
        public static object dataNascita(DataAccess conn, string codicefiscale) {
            if (codicefiscale.Length != 16) return null;
            try {
                string esercizio = conn.Security.GetEsercizio().ToString();
                int corrente = Convert.ToInt32(esercizio.Substring(2, 2));
                int secolo = Convert.ToInt32(esercizio.Substring(0, 2)) * 100;
                int anno = Convert.ToInt32(codicefiscale.Substring(6, 2));
                if (anno > corrente) anno += (secolo - 100);
                else anno += secolo;
                int mese = numeroMeseDaLettera(codicefiscale[8]);
                if (mese == 0) throw new Exception("Lettera relativa al mese di nascita non valida");
                int giorno = Convert.ToInt32(codicefiscale.Substring(9, 2));
                if (giorno > 40) giorno -= 40;
                return new DateTime(anno, mese, giorno);
            }
            catch (Exception e) {
                QueryCreator.MarkEvent("InfoDaCodiceFiscale.DataNascita() - " + e.Message);
                return null;
            }
        }

        /// <summary>
        /// Restituisce il numero relativo al mese, 0 se lettera non valida
        /// </summary>
        /// <param name="lettera"></param>
        /// <returns></returns>
        private static int numeroMeseDaLettera(char lettera) {
            return "ABCDEHLMPRST".IndexOf(lettera) + 1;
        }
    }

}
