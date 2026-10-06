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
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace LiveUpgrade {

    /// <summary>
    /// Installazione di un pacchetto con Windows Installer (msi.dll), senza librerie esterne.
    /// </summary>
    public static class WindowsInstaller {

        private const uint INSTALLUILEVEL_NONE = 2;
        private const uint ERROR_SUCCESS = 0;
        private const uint ERROR_SUCCESS_REBOOT_INITIATED = 1641;
        private const uint ERROR_SUCCESS_REBOOT_REQUIRED = 3010;

        [DllImport("msi.dll", CharSet = CharSet.Unicode)]
        private static extern uint MsiSetInternalUI(uint dwUILevel, IntPtr phWnd);

        [DllImport("msi.dll", CharSet = CharSet.Unicode)]
        private static extern uint MsiInstallProduct(string szPackagePath, string szCommandLine);

        /// <summary>
        /// Installa il pacchetto senza interfaccia utente. Il successo, anche con riavvio richiesto o avviato,
        /// non solleva eccezioni; ogni altro esito solleva una Win32Exception con il codice di Windows Installer,
        /// come faceva Installer.InstallProduct della libreria WiX DTF.
        /// </summary>
        /// <param name="path">Percorso del pacchetto .msi</param>
        /// <param name="args">Proprietà da passare all'installazione</param>
        public static void InstallSilent(string path, string args) {
            MsiSetInternalUI(INSTALLUILEVEL_NONE, IntPtr.Zero);

            uint result = MsiInstallProduct(path, args);
            if (result != ERROR_SUCCESS && result != ERROR_SUCCESS_REBOOT_INITIATED && result != ERROR_SUCCESS_REBOOT_REQUIRED) {
                throw new Win32Exception((int)result);
            }
        }

    }

}
