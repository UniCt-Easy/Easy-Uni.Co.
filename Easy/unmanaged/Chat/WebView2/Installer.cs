/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Win32;

namespace Chat.WebView2 {
    
    //https://learn.microsoft.com/en-us/microsoft-edge/webview2/concepts/distribution
    
    /// <summary>
    /// Permette di installare WebView2 e di verificare se sia installato sul sistema.
    /// </summary>
    public static class Installer {

        private static readonly bool?[] regKeysExist = {
            Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\EdgeUpdate\Clients\{F3017226-FE2A-4295-8BDF-00C3A9A7E4C5}")?.GetValueNames().Contains("pv"),  // installazione a livello di macchina
            Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\EdgeUpdate\Clients\{F3017226-FE2A-4295-8BDF-00C3A9A7E4C5}")?.GetValueNames().Contains("pv"),   // installazione a livello di utente
        };

        /// <summary>
        /// Indica se WebView2 è installato sul sistema.
        /// </summary>
        public static bool IsWebView2Installed => regKeysExist.Any(keyExists => keyExists == true); // ci basta una qualsiasi delle chiavi

        /// <summary>
        /// Avvia l'eseguibile indicato se WebView2 non è installato e l'eseguibile esiste.
        /// </summary>
        /// <param name="executablePath">Percorso dell'eseguibile da avviare.</param>
        /// <param name="expectedHash">Hash previsto.</param>
        /// <param name="algorithm">Funzione da usare per il calcolo dell'hash.</param>
        public static void Install(string executablePath, byte[] expectedHash, Func<Stream, byte[]> hasher) {

            FileInfo executable = new FileInfo(executablePath);

            if (!IsWebView2Installed && executable.Exists) {

                FileStream fs;

                try {
                    fs = executable.OpenRead();
                }
                catch (Exception e) {
                    
                    throw new Exception($"Could not open stream for \"{executable.FullName}\": ", e);
                }

                var calculatedHash = hasher.Invoke(fs);

                if (!calculatedHash.SequenceEqual(expectedHash)) {

                    throw new Exception($"Invalid hash for \"{ executablePath }\"");
                }

                try {
                    Process.Start(new ProcessStartInfo(executable.FullName, "/silent /install") {
                        CreateNoWindow = true,
                        UseShellExecute = false,
                    });
                }
                catch (Exception e) {
                    throw new Exception($"Error executing \"{ executablePath }\": {e.Message}", e);
                }
            }
        }
    }
}
