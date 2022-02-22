
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


using Backend.CommonBackend;
using metadatalibrary;
using metaeasylibrary;
using System.Text.RegularExpressions;


namespace Backend.Components {
    /**
     * Rappresenta un metadato speciale in cui alcune funzioni core leggono i dati da delle tabelle notevoli 
     */
    public class Meta_Portale : Meta_easydata {
        private string tableName;

        public Meta_Portale(DataAccess Conn, MetaDataDispatcher Dispatcher, string table) : base(Conn, Dispatcher,
            table) {
            tableName = table;
        }

        public override string[] primaryKey() {
            string primarykey = "";
            if (CacheMDLW.metaDataCache_primaryKey.TryGetValue(tableName, out primarykey)) {
                // a db viene salvato nel seguente formato: "chiave1","chiave2",...
                primarykey = primarykey.Replace("\"", "");
                return primarykey.Split(',');
            }

            return new string[] { };
        }

        public override string GetSorting(string listingType) {
            string sorting = "";
            if (CacheMDLW.metaDataCache_sorting.TryGetValue((tableName, listingType), out sorting)) {
                sorting = sorting.Replace("\"", "");
                return sorting;
            }

            return base.GetSorting(listingType);
        }

        public override string GetStaticFilter(string listingType) {
            string staticFilter = "";
            if (CacheMDLW.metaDataCache_staticFilter.TryGetValue((tableName, listingType), out staticFilter)) {
                // in origine era "(idreg_docenti='" + security.GetUsr("idreg").ToString() + "')"
                // diventa staticFilter = "(idreg_docenti='{usr$idreg}')";
                string pattern = @"\{(?:.:)?(.*?)\}";
                var matches = Regex.Matches(staticFilter, pattern);
                foreach (Match m in matches) {
                    string replaced = "";
                    string[] elements = m.Groups[1].Value.Split('$');
                    if (elements[0] == "usr") {
                        replaced = security.GetUsr(elements[1]).ToString();
                    }

                    if (elements[0] == "sys") {
                        replaced = security.GetSys(elements[1]).ToString();
                    }

                    staticFilter = staticFilter.Replace(m.Value, replaced);
                }

                return staticFilter;
            }

            return base.GetStaticFilter(listingType);
        }

    }
}
