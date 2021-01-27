
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using metadatalibrary;
using metaeasylibrary;


namespace DBConn {
    public class DbConn {
        public static string[] getParams(string DSN) {
            string exeConfigPath = typeof(DbConn).Assembly.Location; // Recupera il percorso del file di configurazione

            Configuration config = ConfigurationManager.OpenExeConfiguration(exeConfigPath);

            // Recupera chiave richiesta dal file config
            string tmpDSN = GetAppSetting(config, DSN);

            // Verifica se la chiave esiste
            if (tmpDSN == string.Empty) {
                return null;
            }

            // Split della chiave su config
            string[] parametri = tmpDSN.Split(';');
            return parametri;
        }

        public static Easy_DataAccess getEasyAccess(int Esercizio, DateTime DataContabile, string DSN) {
            string exeConfigPath = typeof(DbConn).Assembly.Location; // Recupera il percorso del file di configurazione

            Configuration config = ConfigurationManager.OpenExeConfiguration(exeConfigPath);

            // Recupera chiave richiesta dal file config
            string tmpDSN = GetAppSetting(config, DSN);

            // Verifica se la chiave esiste
            if (tmpDSN == string.Empty) {
                return null;
            }

            // Split della chiave su config
            string[] parametri = tmpDSN.Split(';');

            // Istanzia i parametri della classe
            string HostName = parametri[1];
            string DbName = parametri[2];
            string Dipartimento = parametri[3];
            string DbUser = parametri[4];
            string DbPass = parametri[5];
            string error, dettaglio;
            var conn =  Easy_DataAccess.getEasyDataAccess(DSN,HostName,DbName,DbUser,DbPass,Dipartimento,Esercizio,DataContabile,out error, out dettaglio);
            return conn;
        }

        /// <summary>
        /// Ritorna un DataAcces istanziato secondo i parametri contenuti nel file DBConn.dll.config
        /// </summary>
        /// <returns>Il DataAccess istanziato</returns>
        public static DataAccess getDataAccess(int Esercizio, DateTime DataContabile, string DSN) {
            string exeConfigPath = typeof(DbConn).Assembly.Location; // Recupera il percorso del file di configurazione

            Configuration config = ConfigurationManager.OpenExeConfiguration(exeConfigPath);

            // Recupera chiave richiesta dal file config
            string tmpDSN = GetAppSetting(config, DSN);

            // Verifica se la chiave esiste
            if (tmpDSN == string.Empty) {
                return null;
            }

            // Split della chiave su config
            string[] parametri = tmpDSN.Split(';');

            // Istanzia i parametri della classe
            string HostName = parametri[1];
            string DbName = parametri[2];
            string DbUser = parametri[3];
            string DbPass = parametri[4];

            DataAccess conn =  new AllLocal_DataAccess(DSN, HostName, DbName, DbUser, DbPass, Esercizio, DataContabile);
            return conn;
        }

        /// <summary>
        /// Function utilizzata per accedere al file di configurazione della DLL 
        /// </summary>
        /// <param name="config"></param>
        /// <param name="key"></param>
        /// <returns>Ritorna la chiave richiesta nel filie di configurazione</returns>
        static private string GetAppSetting(Configuration config, string key) {
            KeyValueConfigurationElement element = config.AppSettings.Settings[key];
            if (element != null) {
                string value = element.Value;
                if (!string.IsNullOrEmpty(value))
                    return value;
            }
            return string.Empty;
        }
    }
}
