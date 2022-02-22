
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
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Backend {

    /// <summary>
    /// Helper class per la partita iva
    /// </summary>
    public class PartitaIva {

        private static Dictionary<string, int[]> _h;

        private static string[] _errore = {
            "OK",
            "L'ultimo carattere non è coerente con gli altri caratteri",
            "La partita IVA deve essere composta da 11 caratteri numerici",
            "Si è verificata una eccezione generica",
			// "Il primo carattere della partita IVA deve essere diverso da 8 e 9",
			// "Il codice della provincia non è valido (caratteri in posizione 10, 11 e 12)"
		};

        static PartitaIva() {
            _h = new Dictionary<string, int[]> {
                { "AT", new int[] { 9 } },
                { "BE", new int[] { 10 } },
                { "BG", new int[] { 9 } },
                { "HR", new int[] { 11 } },
                { "DE", new int[] { 9 } },
                { "DK", new int[] { 8 } },
                { "EL", new int[] { 9 } },
                { "ES", new int[] { 9 } },
                { "FI", new int[] { 8 } },
                { "FR", new int[] { 11 } },
                { "GB", new int[] { 9, 12 } },
                { "IE", new int[] { 8, 9 } },
                { "IT", new int[] { 11 } },
                { "LU", new int[] { 8 } },
                { "NL", new int[] { 12 } },
                { "SE", new int[] { 12 } },
                { "CY", new int[] { 9 } },
                { "EE", new int[] { 9 } },
                { "LV", new int[] { 11 } },
                { "LT", new int[] { 9, 12 } },
                { "MT", new int[] { 8 } },
                { "PL", new int[] { 10 } },
                { "PT", new int[] { 9 } },
                { "CZ", new int[] { 8, 9, 10 } },
                { "SK", new int[] { 9, 10 } },
                { "SI", new int[] { 8 } },
                { "HU", new int[] { 8 } },
                { "RO", new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10 } }
            };
        }

        /// <summary>
        /// Controlla una partita iva italiana o estera
        /// </summary>
        /// <param name="piva"></param>
        /// <returns></returns>
        public static string controllaPartitaIva(string piva) {
            if (piva.Length < 3) {
                return "La partita IVA italiana è composta da 11 numeri; la partita IVA straniera deve cominciare con la sigla della nazione";
            }

            if ((piva[0] >= '0') && (piva[0] <= '9') && (piva[1] >= '0') && (piva[1] <= '9')) {
                int errorePIvaIt = controllaPartitaIvaItaliana(piva);
                if (errorePIvaIt != 0) {
                    return _errore[errorePIvaIt];
                }
                else {
                    return null;
                }
            }

            if (piva.Substring(0, 2).ToUpper() == "IT") {
                return _errore[2];
            }


            //int[] lens = (int[])h[piva.Substring(0, 2).ToUpper()];  //casta come int una stringa quindi è normale che vada in eccezione...
            int?[] lens = piva.Substring(0, 2).Split().Select(x => { int value; return int.TryParse(x, out value) ? value : (int?)null; }).ToArray();
            if (lens[0] == null) {
                return "I primi due caratteri della partita IVA non sono numerici o non identificano un Paese UE";
            }

            int lunghezzaInserita = piva.Length - 2;
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
                return string.Format("La partita IVA che comincia con {0} deve contenere una quantità di numeri pari a {1}",
                    piva.Substring(0, 2).ToUpper(), ll);
            }

            return null;
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
        /// 5: prov != 121 AND prov != 120 AND (1 > prov || prov > 100) AND prov != 999
        /// </returns>
        public static int controllaPartitaIvaItaliana(string piva, char controlType = 'F') {
            try {
                string str1 = null;
                int totale = 0;
                long somma = 0L;
                bool numerico = true;
                //				char[] vchar = new char[piva.Length];
                //				piva.getChars(0, piva.length(), vchar, 0);
                string vchar = piva;
                for (int i1 = 0; numerico && i1 < piva.Length; i1++)
                    if ((vchar[i1] < '0') || (vchar[i1] > '9'))
                        numerico = false;
                    else
                        somma += vchar[i1];

                if ((piva.Length != 11) || !numerico) {
                    return 2;
                }
                if (somma == 0L)
                    return 0;
                if (controlType == 'I') {
                    if ((piva[0] == '8') || (piva[0] == '9')) {
                        return 4;
                    }
                    int prov = Int32.Parse(piva.Substring(7, 3));
                    if ((prov != 121) && (prov != 120) && ((1 > prov) || (prov > 100)) && (prov != 999)) {
                        return 5;
                    }
                }
                for (int i = 1; i < 11; i += 2) {
                    int integer1 = Int32.Parse(piva.Substring(i, 1));
                    str1 = (integer1 * 2).ToString();
                    for (int j = 0; j < str1.Length; j++) {
                        int integer3 = Int32.Parse(str1.Substring(j, 1));
                        totale += integer3;
                    }
                }

                for (int k = 0; k < 9; k += 2) {
                    int integer4 = Int32.Parse(piva.Substring(k, 1));
                    totale += integer4;
                }

                int ultimocarattere = Int32.Parse(piva.Substring(10, 1));
                if (totale % 10 == 0) {
                    if (totale % 10 == ultimocarattere)
                        return 0;
                    else
                        return 1;
                }
                else
                    if (10 - totale % 10 == ultimocarattere)
                    return 0;
                else
                    return 1;
            }
            catch (Exception) {
                return 3;
            }
        }

    }

}
