/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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

ï»¿using Microsoft.Win32;

namespace LiveUpgrade {

    public static class Win32Registry {

        /// <summary>
        /// Restituisce il valore di una chiave di registro
        /// </summary>
        /// <param name="machineName">Nome del computer</param>
        /// <param name="hive">Nome del registro</param>
        /// <param name="regPath"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static object GetValue(string machineName, RegistryHive hive, string regPath, string name) {
            object value = null;

            using (RegistryKey key = RegistryKey.OpenRemoteBaseKey(hive, machineName).OpenSubKey(regPath)) {
                if (key != null) {
                    value = key.GetValue(name);
                }
            }

            return value;
        }

    }

}
