
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
using System.Linq;
using System.Text;

namespace EasyPagamenti.Extensions {

    /// <summary>
    /// Metodi di estensione per le stringhe.
    /// </summary>
    public static class StringExtensions {

        /// <summary>
        /// Rimuove i segni diacritici della stringa.
        /// </summary>
        /// <param name="text">Stringa originale.</param>
        /// <returns>Stringa senza segni diacritici.</returns>
        public static string StripDiacritics(this string text) {
            var a = Encoding.GetEncoding(1251).GetBytes(text);
            var b = Encoding.ASCII.GetString(a);

            return b.ToUpper();
        }

        /// <summary>
        /// Restituisce la rappresentazione esadecimale del vettore di byte fornito.
        /// </summary>
        /// <param name="array">Vettore di byte.</param>
        /// <returns>Rappresentazione esadecimale del vettore.</returns>
        public static string ToHexString(this byte[] array) {
            var builder = new StringBuilder();
            foreach (byte b in array) {
                builder.AppendFormat("{0:X2}", b);
            }

            return builder.ToString();
        }

        /// <summary>
        /// Restituisce un vettore di byte dalla sua rappresentazione esadecimale.
        /// </summary>
        /// <param name="text">Rappresentazione esadecimale del vettore.</param>
        /// <returns>Vettore di byte.</returns>
        public static byte[] ToBytes(this string text) {
            if (text == null) return null;
            var array = new byte[text.Length / 2];
            for (var i = 0; i < text.Length; i += 2) {
                array[i / 2] = Convert.ToByte(text.Substring(i, 2), 16);
            }

            return array;
        }

        /// <summary>
        /// Restituisce vero se il carattere è una consonante.
        /// </summary>
        /// <param name="c">Carattere.</param>
        /// <returns>Vero se il carattere è una consonante.</returns>
        public static bool IsConsonant(this char c) {
            c = Char.ToUpper(c);
            return "BCDFGHLJKMNPQRSTVWXYZ".Contains(c);
        }

        /// <summary>
        /// Restituisce vero se il carattere è una vocale.
        /// </summary>
        /// <param name="c">Carattere.</param>
        /// <returns>Vero se il carattere è una vocale.</returns>
        public static bool IsVowel(this char c) {
            c = Char.ToUpper(c);
            return "AEIOU".Contains(c);
        }

    }

}
