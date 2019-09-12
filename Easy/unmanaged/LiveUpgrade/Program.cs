/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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

﻿using LiveUpgrade.Properties;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;

namespace LiveUpgrade {

    class Program {

        // Errori
        private const int ERROR_FRAMEWORK = -2;
        private const int ERROR_PACKAGE = -1;
        private const int ERROR_ARGUMENTS = 1;
        private const int ERROR_RUNTIME = 99;

        // Pre-requisiti
        private const string URL_NETFX = "http://go.microsoft.com/fwlink/?LinkId=397708";
        private const string URL_CR32 = "http://downloads.businessobjects.com/akdlm/cr4vs2010/CRforVS_redist_install_32bit_13_0_18.zip";
        private const string URL_CR64 = "http://downloads.businessobjects.com/akdlm/cr4vs2010/CRforVS_redist_install_64bit_13_0_18.zip";

        [STAThread]
        static int Main(string[] args) {
            Log.Info("Inizializzazione.");

            Xceed.FileSystem.Licenser.LicenseKey = Resources.LICENZA_XCEED;
            Xceed.Zip.Licenser.LicenseKey = Resources.LICENZA_XCEED;

            // Controlla che sia stato scaricato un pacchetto di upgrade
            var datafile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LiveUpgrade.dat");
            if (!File.Exists(datafile)) {
                Log.Warning("Il pacchetto dati non è disponibile.");
                return 0;
            }

            try {
                // Controlla se è stato passato l'ID del processo del loader
                int id;
                if (args.Length == 1 && int.TryParse(args[0], out id)) {
                    // Ottiene il processo del loader
                    var process = Process.GetProcessById(id);

                    Log.Info(string.Format("Attendo la chiusura del processo #{0}...", id.ToString()));

                    // Attende che il loader venga chiuso
                    process.WaitForExit();
                }

                Log.Info("Procedura di aggiornamento avviata.");

                // Procede all'aggiornamento
                var form = new FormProgress();
                form.Show();

                if (!CheckFramework()) {
                    string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dotnetfx.exe");

                    Log.Warning("Nel sistema non è installata una versione adeguata del .NET Framework.");

                    form.Download(".NET Framework", URL_NETFX, path);

                    var exitCode = form.Run(path, "/q /promptrestart /LCID 1040");

                    if (exitCode != 0) {
                        if (exitCode == 1641 || exitCode == 3010) {
                            Log.Info("Il programma d'installazione del .NET framework ha richiesto il riavvio.");

                            // TODO: impostare l'avvio automatico di LiveUpgrade dopo il riavvio?

                            Environment.Exit(3010);
                        }
                        else {
                            string message = string.Format("Il programma d'installazione del .NET framework ha restituito un errore (codice {0}).", exitCode);
                            throw new Exception(message);
                        }
                    }

                    Log.Info("Installazione del .NET framework completata con successo.");
                }

                if (!CheckCrystalReport()) {
                    string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "crruntime.zip");

                    Log.Warning("Nel sistema non è installata una versione adeguata delle librerie di runtime di Crystal Report.");

                    if (EnvironmentHelper.Is64BitOperatingSystem()) {
                        form.Download("Librerie Crystal Report", URL_CR64, path);
                    }
                    else {
                        form.Download("Librerie Crystal Report", URL_CR32, path);
                    }

                    form.Unpack(path, AppDomain.CurrentDomain.BaseDirectory);

                    path = EnvironmentHelper.Is64BitOperatingSystem() ?
                        @"CRforVS_redist_install_64bit_13_0_18\CRRuntime_64bit_13_0_18.msi" :
                        @"CRforVS_redist_install_32bit_13_0_18\CRRuntime_32bit_13_0_18.msi";

                    form.Install(path, null);

                    Log.Info("Installazione delle librerie di runtime di Crystal Report completata con successo.");
                }

                form.Clean(AppDomain.CurrentDomain.BaseDirectory);

                form.Unpack(datafile, AppDomain.CurrentDomain.BaseDirectory);

                Log.Info("Installazione dell'aggiornamento completato con successo.");

                form.Hide();
            }
            catch (Exception ex) {
                Log.Critical(ex);
            }

            return 0;
        }

        /// <summary>
        /// Controlla se nel sistema è installata la versione richiesta di .NET Framework.
        /// </summary>
        /// <returns>Vero se la versione installata è compatibile.</returns>
        static bool CheckFramework() {
            string regPath = @"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full";
            string name = "Release";

            var result = Win32Registry.GetValue("", RegistryHive.LocalMachine, regPath, name);

            if (result != null) {
                var release = (int)result;
                return release >= 379893; // v4.5.2
            }
            
            return false;
        }

        /// <summary>
        /// Controlla se nel sistema è installata la versione richiesta di Crystal Report.
        /// </summary>
        /// <returns>Vero se la versione installata è compatibile.</returns>
        static bool CheckCrystalReport() {
            string regPath = @"SOFTWARE\SAP BusinessObjects\Crystal Reports for .NET Framework 4.0\Crystal Reports";
            string name = EnvironmentHelper.Is64BitOperatingSystem() ? "CRRuntime64Version" : "CRRuntime32Version";

            var result = Win32Registry.GetValue("", RegistryHive.LocalMachine, regPath, name);

            if (result != null) {
                var version = new Version((string)result);

                return (version.Major == 13 && version.Minor >= 0 && version.Build >= 18); // v13.0.18
            }

            return false;
        }

    }

}
