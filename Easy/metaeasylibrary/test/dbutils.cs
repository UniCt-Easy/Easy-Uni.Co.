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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using metadatalibrary;
using metaeasylibrary;
using System.Collections.Generic;
using System.Configuration;

namespace test {
    public class dbutils {
          /// <summary>
        /// Function utilizzata per accedere al file di configurazione della DLL 
        /// </summary>
        /// <param name="config"></param>
        /// <param name="key"></param>
        /// <returns>Ritorna la chiave richiesta nel filie di configurazione</returns>
        static string getAppSetting(Configuration config, string key) {
            KeyValueConfigurationElement element = config.AppSettings.Settings[key];
            string value = element?.Value;
            if (!string.IsNullOrEmpty(value))
                return value;
            return string.Empty;
        }

            public static Dictionary<string, string> getDbParameters(string dsn) {


            string exeConfigPath =typeof(testWithDatabase).Assembly.Location; // Recupera il percorso del file di configurazione

            Configuration config = ConfigurationManager.OpenExeConfiguration(exeConfigPath);

            // Recupera chiave richiesta dal file config
            string tmpDsn = getAppSetting(config, dsn);

            // Verifica se la chiave esiste
            if (tmpDsn == string.Empty) {
                return null;
            }                         

            // Split della chiave su config
            string[] parametri = tmpDsn.Split(';');
            Dictionary<string, string> res = new Dictionary<string, string> {
                ["dsn"] = parametri[0],
                ["server"] = parametri[1],
                ["database"] = parametri[2],
                ["department"] = parametri[3],
                ["user"] = parametri[4],
                ["password"] = parametri[5]                
            };
            return res;
        }

         public static Easy_DataAccess getEasyDataAccess(string dsn) {
            var cfg = dbutils.getDbParameters(dsn);            
            DateTime T = DateTime.Now;
            string dettaglio=null;
            string msg= null;
            var    MyDataAccess = Easy_DataAccess.getEasyDataAccess(cfg["dsn"], cfg["server"], cfg["database"],
                    cfg["user"], cfg["password"], null,cfg["department"],                    
                    DateTime.Now.Year, DateTime.Now.Date, out msg, out dettaglio);
            return MyDataAccess;                                
        }
    }
}
