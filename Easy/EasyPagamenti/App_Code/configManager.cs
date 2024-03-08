
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
using System.Collections.Generic;
using System.Web;
using System.Configuration;

public static class configManager {



    static System.Configuration.Configuration webConf = null;
    static string myPrivatePwd = "*******";

    public static string getCfg(string tag) {
        getConfig();
        System.Configuration.KeyValueConfigurationElement el = webConf.AppSettings.Settings[tag];
        if (el == null) return null;
        return el.Value;

    }
    public static void setCfg(string tag, string value) {
        getConfig();
        System.Configuration.KeyValueConfigurationElement el = webConf.AppSettings.Settings[tag];
        if (el == null) {
            webConf.AppSettings.Settings.Add(tag, value);
        }
        else {
            el.Value = value;
        }
        webConf.Save(ConfigurationSaveMode.Modified);
    }


   

   
    
    static System.Configuration.Configuration getConfig() {
        if (webConf == null) {
            webConf = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(System.Web.HttpRuntime.AppDomainAppVirtualPath);
        }
        return webConf;
    }

}
