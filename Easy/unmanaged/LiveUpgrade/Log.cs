
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
using System.IO;

namespace LiveUpgrade {

    public class Log {

        private static object Secure = new object();
        private static TextWriter Instance;

        private static void Write(string severity, string message) {
            lock (Secure) {
                if (Instance == null) {
                    try {
                        Instance = File.AppendText("LiveUpgrade.log");
                    }
                    catch (Exception ex) {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine(ex.StackTrace);
                    }
                }

                var line = string.Format("[{0}] {1} - {2}", DateTime.Now, severity, message);

                Instance.WriteLine(line);
                Instance.Flush();
            }
        }
        
        /// <summary>
        /// Scrive un messaggio informativo nel registro.
        /// </summary>
        /// <param name="message">Messaggio da registrare.</param>
        public static void Info(string message) {
            Write("INFO", message);
        }

        /// <summary>
        /// Scrive un messaggio di avviso nel registro.
        /// </summary>
        /// <param name="message">Messaggio da registrare.</param>
        public static void Warning(string message) {
            Write("WARN", message);
        }

        /// <summary>
        /// Scrive un messaggio di errore nel registro.
        /// </summary>
        /// <param name="message">Messaggio da registrare.</param>
        public static void Error(string message) {
            Write("ERROR", message);
        }

        /// <summary>
        /// Scrive i dettagli relativi ad un'eccezione nel registro e chiude l'applicazione.
        /// </summary>
        /// <param name="ex">Eccezione da registrare.</param>
        public static void Critical(Exception ex) {
            Write("EXCEPTION", ex.Message);
            Write("STACKTRACE", ex.StackTrace);

            Environment.Exit(-1);
        }

    }

}
