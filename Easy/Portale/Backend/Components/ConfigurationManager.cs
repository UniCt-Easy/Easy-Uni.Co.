
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
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Backend.Components {
    public interface IConfigurationManager {
        string getAppSetting(string key);
        void setAppSetting(string key, string value);
    }


    public class ConfigurationManager : IConfigurationManager {
        Configuration config;

        /// <summary>
        /// Legge la configurazione ove già non sia stato fatto
        /// </summary>
        void assureConfig() {
            if (config == null) {
                config = WebConfigurationManager.OpenWebConfiguration("~");
            }
        }

        /// <summary>
        /// gets an application setting
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string getAppSetting(string key) {
            assureConfig();
            return config.AppSettings.Settings[key].Value;
        }

        /// <summary>
        /// sets an application setting
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void setAppSetting(string key, string value) {
            assureConfig();
            var settings = config.AppSettings.Settings;
            if (settings[key] == null) {
                settings.Add(key, value);
            }
            else {
                settings[key].Value = value;
                config.Save(ConfigurationSaveMode.Modified);
            }
        }
    }
}
