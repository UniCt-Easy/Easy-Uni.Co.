
/*
Easy
Copyright (C) 2024 Universit� degli Studi di Catania (www.unict.it)
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


using metadatalibrary;
using metaeasylibrary;
using System.Collections.Generic;
using System.Data;

namespace ServizioTimbratura
{
    public static class CacheMDLW {

        /// <summary>
        /// Object address for sys_user, cointains the securitycondition and the counter, of the user that have that sec cond.
        /// </summary>
        public class securityConditionResource {

            /// <summary>
            /// object with the info of calculated privileges (func  sec.ReadAllGroupOperations() in authcontroller)
            /// </summary>
            public SecurityConditions groupOperations { get; set; }

            /// <summary>
            /// array of idreg. idreg assocaited securityConditionResource 
            /// </summary>
            public List<string> utilizerGroupOperations { get; set; }

            /// <summary>
            /// constructor. init the counter to zero value of utilizer and the groupOperation
            /// </summary>
            /// <param name="mygroupOperations"></param> SecurityConditions
            public securityConditionResource(SecurityConditions mygroupOperations) {
                groupOperations = mygroupOperations;
                utilizerGroupOperations = new List<string>();
            }

            /// <summary>
            /// Remove the utilizer of this cond resource
            /// </summary>
            public void removeUtilizer(string idreg) {
                if (utilizerGroupOperations.Contains(idreg)) {
                    utilizerGroupOperations.Remove(idreg);
                }
            }

            /// <summary>
            /// Add an utilizer of this cond resource. if the idreg is not in the array of utilizer
            /// </summary>
            public void addUtilizer(string idreg) {
                if (!utilizerGroupOperations.Contains(idreg)) {
                    utilizerGroupOperations.Add(idreg);
                }
            }
        }

        /// <summary>
        /// Dictionary with the info of SecurityConditions addressed for sys_user on "virtualuser" table
        /// </summary>
        private static Dictionary<string, securityConditionResource> groupOperationsDictCache = new Dictionary<string, securityConditionResource>();

        /// <summary>
        /// dbStructureCache rappresenta la cache con la struttura delle tabelle.
        /// per ogni chiave nome tabella sar� associato un dataset con le tabelle di strututra
        /// </summary>
        public static Dictionary<string, dbstructure> dbStructureCache { get; set; }

        /// <summary>
        /// colDescrCache rappresenta la cache per la coldescr di ogni tabella.
        /// </summary>
        public static Dictionary<string, DataTable> colDescrCache  = new Dictionary<string, DataTable>();

        /// <summary>
        /// metaDataCache_primaryKey rappresenta la cache per le primary key
        /// </summary>
        public static Dictionary<string, string> metaDataCache_tablesManaged = new Dictionary<string, string>();

        /// <summary>
        /// metaDataCache_primaryKey rappresenta la cache per le primary key
        /// </summary>
        public static Dictionary<string, string> metaDataCache_primaryKey = new Dictionary<string, string>();


        /// <summary>
        /// metaDataCache_staticFilter rappresenta gli staticFilter configurabili a db per (tablename, listType)
        /// </summary>
        public static Dictionary<(string, string), string> metaDataCache_staticFilter = new Dictionary<(string, string), string>();

        /// <summary>
        /// metaDataCache_sorting rappresenta i tipi di sorting configurabili a db per una determinata select-paginata su (tablename, listType)
        /// </summary>
        public static Dictionary<(string, string), string> metaDataCache_sorting = new Dictionary<(string, string), string>();


        /// <summary>
        /// If the userkey alrady exist it add an utilizer for this resource
        /// </summary>
        /// <param name="sys_user"></param> string. the key of the dictionary. is the sys_user on virtual user table
        /// <param name="groupOperations"></param> SecurityConditions.
        public static void addUtilizer(string sys_user, string idreg, SecurityConditions groupOperations) {
            securityConditionResource secCondResource;
            sys_user = normalizeSysUser(sys_user);
            if (groupOperationsDictCache.ContainsKey(sys_user)) {
                // leggo dalla cache per aumentare il num di utilizzatori
                secCondResource = groupOperationsDictCache[sys_user];
            } else {
                // non � presente, aggiungo in cache
                secCondResource = new securityConditionResource(groupOperations);
                groupOperationsDictCache[sys_user] = secCondResource;
            }
            // aumento il contatore di utilizzatori
            secCondResource.addUtilizer(idreg);
        }

        /// <summary>
        /// username can be lowercase on some tables, and uppercase in others (customuser for example. We avoid to duplicate entries
        /// </summary>
        /// <param name="sys_user"></param>
        /// <returns></returns>
        private static string normalizeSysUser(string sys_user) {
            if (string.IsNullOrEmpty(sys_user)) {
                 return sys_user;
            }
            return sys_user.ToUpper();
        }

        /// <summary>
        /// Given a sys_user (sys_user on virtual user) return the groupOperations read from the cache. null if the key is not in the dictionary
        /// </summary>
        /// <param name="sys_user"></param>
        /// <returns></returns>
        public static SecurityConditions getGroupOperations(string sys_user) {
            sys_user = normalizeSysUser(sys_user);
            if (groupOperationsDictCache.ContainsKey(sys_user)) {
                securityConditionResource secCondResource = groupOperationsDictCache[sys_user];
                return secCondResource.groupOperations;
            }
            return null;
        }

        public static void removeUserFromGroupOperationsDictCache(string sys_user) {
            sys_user = normalizeSysUser(sys_user);
            groupOperationsDictCache.Remove(sys_user);
        }

            /// <summary>
            /// Remove an utilizer form the dict of the sec condition. if the counter go to zero then it remove
            /// te entry for that sys_user (sys_user on virtual user)
            /// </summary>
            /// <param name="sys_user"></param>
        public static void removeUtilizer(string sys_user, string idreg) {
            sys_user = normalizeSysUser(sys_user);
            if (groupOperationsDictCache.ContainsKey(sys_user)) {
                securityConditionResource res = groupOperationsDictCache[sys_user];
                res.removeUtilizer(idreg);
                // nessun utente afferisce a questo oggetto, quindi cancello dalla cache
                if (res.utilizerGroupOperations.Count <= 0) { groupOperationsDictCache.Remove(sys_user);}
            }
        }

    }
}
