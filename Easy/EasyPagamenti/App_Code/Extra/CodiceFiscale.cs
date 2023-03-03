
/*
Easy
Copyright (C) 2023 Universita' degli Studi di Catania (www.unict.it)
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
using EasyPagamenti.Extensions;
namespace EasyPagamenti.Extra {

    public class CodiceFiscale {

        // TABELLA [ A ] (caratteri in posizione pari)
        //  0=0  1=1  2=2  3=3  4=4  5=5  6=6  7=7  8=8  9=9
        //  A=0  B=1  C=2  D=3  E=4  F=5  G=6  H=7  I=8  J=9
        //  K=10 L=11 M=12 N=13 O=14 P=15 Q=16 R=17 S=18 T=19
        //  U=20 V=21 W=22 X=23 Y=24 Z=25
        private static Dictionary<char, int> tabellaA;

        // TABELLA [ B ] (caratteri in posizione dispari)
        //  0=1  1=0  2=5  3=7  4=9  5=13 6=15 7=17 8=19 9=21
        //  A=1  B=0  C=5  D=7  E=9  F=13 G=15 H=17 I=19 J=21
        //  K=2  L=4  M=18 N=20 O=11 P=3  Q=6  R=8  S=12 T=14
        //  U=16 V=10 W=22 X=25 Y=24 Z=23
        private static Dictionary<char, int> tabellaB;

        static CodiceFiscale() {
            tabellaA = new Dictionary<char, int>() {
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

            tabellaB = new Dictionary<char, int>() {
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

        private static int GetValueTabA(char C) {
            int value = 0;
            tabellaA.TryGetValue(C, out value);
            return value;
        }

        private static int GetValueTabB(char C) {
            int value = 0;
            tabellaB.TryGetValue(C, out value);
            return value;
        }

        // TABELLA [ C ] (conversione del carattere di controllo)
        //  0=A  1=B  2=C  3=D  4=E  5=F  6=G  7=H  8=I  9=J
        //  10=K 11=L 12=M 13=N 14=O 15=P 16=Q 17=R 18=S 19=T
        //  20=U 21=V 22=W 23=X 24=Y 25=Z 
        private static char GetValueTabC(int C, out bool IsValid) {
            IsValid = true;
            //			string VA = " errore nel carattere di controllo " ;
            string tabC = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if ((C < 0) || (C > 25)) {
                IsValid = false;
                AggiungiErrore("Errore nel carattere di controllo");
                return '?';
            }
            return tabC[C];
        }

        private static string SostituisciLetteraConNumero(string cf, int pos) {
            string sostituzioni = "LMNPQRSTUV";
            int numero = sostituzioni.IndexOf(cf[pos]);
            if (numero != -1) {
                cf = cf.Substring(0, pos) + numero + cf.Substring(pos + 1);
            }
            return cf;
        }

        public static string Normalizza(string codicefiscale) {
            codicefiscale = SostituisciLetteraConNumero(codicefiscale, 6);
            codicefiscale = SostituisciLetteraConNumero(codicefiscale, 7);
            codicefiscale = SostituisciLetteraConNumero(codicefiscale, 9);
            codicefiscale = SostituisciLetteraConNumero(codicefiscale, 10);
            codicefiscale = SostituisciLetteraConNumero(codicefiscale, 12);
            codicefiscale = SostituisciLetteraConNumero(codicefiscale, 13);
            return SostituisciLetteraConNumero(codicefiscale, 14);
        }

        private static string m_Errori = "";

        /// <summary>
        /// Restituisce True se il codicefiscale privato/azienda risulta valido
        /// </summary>
        /// <param name="Conn"></param>
        /// <param name="R"></param>
        /// <param name="errori"></param>
        /// <returns></returns>
        /// 
        public static string maiuscolo(string s) {
            string r = "";
            foreach (char c in s) {
                switch (c) {
                    case 'à':
                    case 'À':
                        r += 'A';
                        break;
                    case 'é':
                    case 'É':
                    case 'è':
                    case 'È':
                        r += 'E';
                        break;
                    case 'ì':
                    case 'Ì':
                        r += 'I';
                        break;
                    case 'ò':
                    case 'Ò':
                        r += 'O';
                        break;
                    case 'ù':
                    case 'Ù':
                        r += 'U';
                        break;
                    default:
                        r += Char.ToUpper(c);
                        break;
                }
            }
            return r;
        }

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
            string cfNormal = Normalizza(codicefiscale);
            string codicefiscalecalcolato =
               Make(Conn,
                    maiuscolo(R["forename"].ToString()),
                    maiuscolo(R["surname"].ToString()),
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
            object DataNascita, string CodiceComune, string Sesso,
            out bool IsValid, out string errori) {

            PulisciErrori();
            IsValid = true;
            errori = "";
            string R = "";

            bool valido;
            R += GetCodCognome(Cognome.StripDiacritics(), out valido);
            IsValid = (IsValid && valido);
            valido = true;
            R += GetCodNome(Nome.StripDiacritics(), out valido);
            IsValid = (IsValid && valido);
            valido = true;
            R += GetCodDataNascita(DataNascita, Sesso, out valido);
            IsValid = (IsValid && valido);
            valido = true;
            R += GetCodComuneNascita(CodiceComune, out valido);
            IsValid = (IsValid && valido);
            valido = true;
            R += GetLastChar(R, out valido);
            IsValid = (IsValid && valido);
            errori = LeggiErrori();
            return R;
        }

        public static string CheckCF(string codicefiscale) {
            codicefiscale = codicefiscale.ToUpper();

            string lastchar;
            string codice;
            // Controllo sulla lunghezza, se non rispettata è inutile effettuare altri controlli
            if (codicefiscale.Length != 16) {
                return "Lunghezza non corretta";
            }
            // Controllo sulla congruità del CF rispetto alle info date
            // Controllo sull'ultimo carattere
            bool IsValid;
            codice = codicefiscale.Substring(0, (codicefiscale.Length - 1));
            lastchar = GetLastChar(codice, out IsValid).ToString();
            if ((!IsValid) || (lastchar != codicefiscale[codicefiscale.Length - 1].ToString())) {
                return "Ultimo carattere non valido";
            }

            return null;
        }


        private static object FindAgencyCode(DataAccess Conn, string idgeo, string tipo) {
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
        /// <param name="Nome"></param>
        /// <param name="Cognome"></param>
        /// <param name="DataNascita"></param>
        /// <param name="idgeo">id della entità geo (geo_comune, geo_provincia, etc)...</param>
        /// <param name="Sesso"></param>
        /// <param name="TipoGeo">"C" = Comune (default), "P" = Provincia, "R" = Regione, "N" = Nazione</param>
        /// <param name="IsValid"></param>
        /// <param name="errori"></param>
        /// <returns></returns>
        public static string Make(DataAccess Conn, string Nome, string Cognome,
            object DataNascita, string idgeo, string Sesso, string TipoGeo,
            out bool IsValid, out string errori) {

            PulisciErrori();
            errori = "";
            IsValid = true;

            if (idgeo.Trim() == "") return Make(Nome, Cognome, DataNascita, "", Sesso, out IsValid, out errori);

            //default impostato su Comune
            if (TipoGeo == "") TipoGeo = "C";

            try {
                string CodiceComune = FindAgencyCode(Conn, idgeo, TipoGeo).ToString();
                return Make(Nome, Cognome, DataNascita, CodiceComune, Sesso, out IsValid, out errori);
            }
            catch {
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
        /// <param name="IsValid"></param>
        /// <returns></returns>
        private static string GetCodNome(string Nome, out bool IsValid) {
            IsValid = true;
            string R = "";
            Nome = Nome.Trim();
            if (Nome == "") {
                IsValid = false;
                AggiungiErrore("Nome mancante");
                return R;
            }
            foreach (Char C in Nome) {
                if (C.IsConsonant()) {
                    //Prende le prime quattro consonanti
                    if (R.Length < 4) R += C;
                }
            }

            if (R.Length >= 4) {
                R = R.Remove(1, 1); //rimuove la seconda consonante e conserva 1,3,4.
                return R;
            }
            if (R.Length == 3) return R;

            //Se le consonanti sono meno di tre
            foreach (Char C in Nome) {
                if ((R.Length < 3) && C.IsVowel()) R += C;

            }
            if (R.Length < 3) {
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
        /// <param name="IsValid"></param>
        /// <returns></returns>
        private static string GetCodCognome(string Cognome, out bool IsValid) {
            IsValid = true;
            string R = "";
            Cognome = Cognome.Trim();
            if (Cognome == "") {
                IsValid = false;
                AggiungiErrore("Cognome mancante");
                return R;
            }
            foreach (Char C in Cognome) {
                //Prende le prime tre consonanti
                if (C.IsConsonant() && (R.Length < 3)) R += C;
            }

            if (R.Length == 3) return R;

            //Se le consonanti sono meno di tre
            foreach (Char C in Cognome) {
                if ((R.Length < 3) && C.IsVowel()) R += C;
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
            out bool IsValid) {

            IsValid = true;

            if (!(objDataNascita is DateTime)) {
                IsValid = false;
                AggiungiErrore("Data mancante");
                return " Data mancante ";
            }

            DateTime dataDiNascita = (DateTime)objDataNascita;

            if (Sesso == "") {
                IsValid = false;
                AggiungiErrore("Sesso mancante");
                return " Sesso mancante ";
            }
            Sesso = Sesso.ToUpper();

            int anno = dataDiNascita.Year % 100;
            string Anno = (anno < 10) ? "0" + anno.ToString() : anno.ToString();

            char Mese = "ABCDEHLMPRST"[dataDiNascita.Month - 1];

            int giorno = (Sesso == "F") ? 40 + dataDiNascita.Day : dataDiNascita.Day;
            string Giorno = (giorno < 10) ? "0" + giorno.ToString() : giorno.ToString();

            return Anno + Mese + Giorno;
        }

        private static string GetCodComuneNascita(string CodComune, out bool IsValid) {
            IsValid = true;
            if (CodComune == "") {
                IsValid = false;
                AggiungiErrore("Comune mancante");
                return "-Codice Comune Mancante-";
            }
            return CodComune;
        }

        public static char GetLastChar(string Codice, out bool IsValid) {
            IsValid = true;
            int count = 0;
            bool IsPair = true;
            decimal Somma = 0;
            foreach (Char C in Codice) {
                count++;
                IsPair = !IsPair;
                if (IsPair) Somma += GetValueTabA(C);
                else Somma += GetValueTabB(C);
            }
            int Resto_int = Convert.ToInt32(Somma) % 26;
            return GetValueTabC(Resto_int, out IsValid);
        }

        private static string LeggiErrori() {
            return m_Errori;
        }

        private static void PulisciErrori() {
            m_Errori = "";
        }
        private static void AggiungiErrore(string msg) {
            m_Errori += "- " + msg + "\r";
        }
    }

    public class InfoDaCodiceFiscale {
        /// <summary>
        /// idgeo del comune, o null se codice errato
        /// </summary>
        public static string Comune(DataAccess Conn, string codicefiscale) {
            if (codicefiscale.Length != 16) return null;
            string codicecomune = codicefiscale.Substring(11, 4);
            string[] param = new string[] { "@codecity", "@idcity" };
            SqlDbType[] types = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.Int };
            int[] typelen = new int[] { 4, 0 };
            ParameterDirection[] dir = new ParameterDirection[] { ParameterDirection.Input, ParameterDirection.Output };
            object[] values = new object[2] { codicecomune, null };
            bool res = Conn.CallSPParameter("compute_idcity_from_cf", param, types, typelen, dir, ref values, true, -1);
            if (!res) return null;
            return values[1].ToString();
        }

        /// <summary>
        /// idgeo della nazione, o null se codice errato
        /// </summary>
        public static string Nazione(DataAccess Conn, string codicefiscale) {
            if (codicefiscale.Length != 16) return null;
            string codicenazione = codicefiscale.Substring(11, 4);
            string[] param = new string[] { "@codenation", "@idnation" };
            SqlDbType[] types = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.Int };
            int[] typelen = new int[] { 4, 0 };
            ParameterDirection[] dir = new ParameterDirection[] { ParameterDirection.Input, ParameterDirection.Output };
            object[] values = new object[2] { codicenazione, null };
            bool res = Conn.CallSPParameter("compute_idnation_from_cf", param, types, typelen, dir, ref values, true, -1);
            if (!res) return null;
            return values[1].ToString();
        }

        /// <summary>
        /// M/F o null se codice errato
        /// </summary>
        public static string Sesso(string codicefiscale) {
            if (codicefiscale.Length != 16) return null;
            try {
                int giorno = Convert.ToInt32(codicefiscale.Substring(9, 2));
                if (giorno > 40) return "F";
                return "M";
            }
            catch (Exception E) {
                QueryCreator.MarkEvent("InfoDaCodiceFiscale.Sesso() - " + E.Message);
                return null;
            }
        }

        /// <summary>
        /// data di nascita o null se codice errato
        /// </summary>
        public static object DataNascita(DataAccess Conn, string codicefiscale) {
            if (codicefiscale.Length != 16) return null;
            try {
                string esercizio = Conn.GetEsercizio().ToString();
                int corrente = Convert.ToInt32(esercizio.Substring(2, 2));
                int secolo = Convert.ToInt32(esercizio.Substring(0, 2)) * 100;
                int anno = Convert.ToInt32(codicefiscale.Substring(6, 2));
                if (anno > corrente) anno += (secolo - 100);
                else anno += secolo;
                int mese = NumeroMeseDaLettera(codicefiscale[8]);
                if (mese == 0) throw new Exception("Lettera relativa al mese di nascita non valida");
                int giorno = Convert.ToInt32(codicefiscale.Substring(9, 2));
                if (giorno > 40) giorno -= 40;
                return new DateTime(anno, mese, giorno);
            }
            catch (Exception E) {
                QueryCreator.MarkEvent("InfoDaCodiceFiscale.DataNascita() - " + E.Message);
                return null;
            }
        }

        /// <summary>
        /// Restituisce il numero relativo al mese, 0 se lettera non valida
        /// </summary>
        /// <param name="lettera"></param>
        /// <returns></returns>
        private static int NumeroMeseDaLettera(char lettera) {
            return "ABCDEHLMPRST".IndexOf(lettera) + 1;
        }
    }

}
