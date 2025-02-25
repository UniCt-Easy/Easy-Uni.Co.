
/*
Easy
Copyright (C) 2025 Università degli Studi di Catania (www.unict.it)
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


namespace Chat.Extensions {


    public static class Extensions {
        /// <summary>
        /// Restituisce la stringa s con il primo carattere maiuscolo.
        /// </summary>
        /// <param name="s">stringa di cui impostare il primo carattere maiuscolo</param>
        /// <returns>Stringa con il primo caratter maiuscolo</returns>
        public static string FirstCharToUpper(this string s) => s[0].ToString().ToUpper() + s.Substring(1);
    }
}
