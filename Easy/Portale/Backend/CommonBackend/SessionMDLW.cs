
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


using metaeasylibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.CommonBackend {

    /// <summary>
    /// 
    /// </summary>
    public class SessionInfo {
        public Hashtable usr { get; set; }
        public Hashtable sys { get; set; }
        public string sys_user { get; set; }
        public string idreg { get; set; }
        public DateTime lastUsingDate;

        public SessionInfo(Hashtable myusr, Hashtable mysys, string mysys_user, string myidreg) {
            usr = myusr;
            sys = mysys;
            sys_user = mysys_user;
            idreg = myidreg;
            updateLastDateUsing();
        }

        /// <summary>
        /// Updates the "lastUsingDate". Used to update the date when a web service is called.
        /// Indocates that the session is running
        /// </summary>
        public void updateLastDateUsing() {
            lastUsingDate = DateTime.UtcNow;
        }
    }

    [Serializable]
    public class SessionInfoSSO
    {

        public string userName { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string cf { get; set; }
        public string matricola { get; set; }

        public DateTime createdAt;

        public SessionInfoSSO(string myUserName, string myName, string mySurname, string myEmail, string myCf, string mymatricola)
        {
            userName = myUserName;
            name = myName;
            surname = mySurname;
            email = myEmail;
            cf = myCf;
            matricola = mymatricola;
            createdAt = DateTime.UtcNow;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public static class SessionMDLW {

        /// <summary>
        /// Dictionary with the info of user session
        /// </summary>
        private static Dictionary<Guid, SessionInfo> sessionInfos = new Dictionary<Guid, SessionInfo>();

        /// <summary>
        /// Dictionary with the info of user session fro SSO login. it expires immediately after sso redirect
        /// </summary>
        private static Dictionary<String, SessionInfoSSO> sessionInfosSSO = new Dictionary<String, SessionInfoSSO>();
        

        /// <summary>
        /// Dictionary with the info of SecurityConditions addressed for sys_user on "virtualuser" table
        /// </summary>
        private static Dictionary<string, SecurityConditions> groupOperationsDict = new Dictionary<string, SecurityConditions>();

        /// <summary>
        /// Last date of cleaning sessionInfos.
        /// SessionMDLW is perstitne in all life cycle of the server app. So is necessary clean unused sessionInfo
        /// </summary>
        private static DateTime lastCleanDate = DateTime.UtcNow;

        /// <summary>
        /// Last date of cleaning sessionInfos.
        /// SessionMDLW is perstitne in all life cycle of the server app. So is necessary clean unused sessionInfo
        /// </summary>
        private static DateTime lastCleanCache = DateTime.UtcNow;

        /// <summary>
        /// Interval in minutes for clenaing sessionInfo based on "lastCleanDate" and "lastUsingDate" of each sessionInfo
        /// </summary>
        private static int intervalCleaningMinutes = 300;
        /// <summary>
        /// Interval in minutes that indicates the duration of the sessionInfo 
        /// </summary>
        private static int durationSessionLastDateMinutes = 180; // 1.30h 
        /// <summary>
        /// Interval in minutes that indicates the duration of the SSO token. it is very small interbvakl
        /// </summary>
        private static int durationSessionLoginSSO = 60;

        /// <summary>
        /// Returns the sessionInfo with the key "guid". Returns null if the sessionInfo is not found
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static SessionInfo getAndUseSessionFromGuid(Guid guid) {
            if (sessionInfos.ContainsKey(guid)) {
                SessionInfo si = sessionInfos[guid];
                // aggiorna la data di utilizzo
                si.updateLastDateUsing();
                return si;
            }
            return null;

        }

        public static void updateSessionInfoFromGuid(Guid guid, Hashtable usr, Hashtable sys)
        {
            if (sessionInfos.ContainsKey(guid))
            {
                SessionInfo si = sessionInfos[guid];
                si.usr = usr;
                si.sys = sys;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="usr"></param>
        /// <param name="sys"></param>
        /// <returns></returns>
        public static void createSession(Guid guid, Hashtable usr, Hashtable sys, string sys_user, string idreg) {
            sessionInfos[guid] = new SessionInfo(usr, sys, sys_user, idreg);
        }

        public static void createSessionSSO(String guid, string userName, string name, string surname, string email, string cf, string matricola)
        {
            sessionInfosSSO[guid] = new SessionInfoSSO(userName, name, surname, email, cf, matricola);
        }

        /// <summary>
        /// Ritorna true se è una sessione SSO valida, cioè il token è stato generato entro "durationSessionLoginSSO" minuti
        /// Ripulisce la sessione
        /// </summary>
        /// <param name="session"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static SessionInfoSSO validSessionSSO(String session, string userName)
        {
            if (sessionInfosSSO.ContainsKey(session))
            {
                // sessione ok
                if (sessionInfosSSO[session].createdAt.AddMinutes(durationSessionLoginSSO) > DateTime.UtcNow &&
                    sessionInfosSSO[session].userName == userName)
                {
                    SessionInfoSSO copy = AuthUtils.DeepClone<SessionInfoSSO>(sessionInfosSSO[session]);
                    // rimouvo la session SSO
                    sessionInfosSSO.Remove(session);
                    return copy;
                }
            }
            return null;
        }


        public static SecurityConditions getGroupConditions(string customuser) {
            if (groupOperationsDict.ContainsKey(customuser)) {
                return groupOperationsDict[customuser];
            }
            return null;
        }

        public static void setGroupConditions(string customuser, SecurityConditions groupConditions) {
            groupOperationsDict[customuser] = groupConditions;
        }

        /// <summary>
        /// Returns true if sessionInfo is expired, false otherwise
        /// </summary>
        /// <param name="guid"></param>
        public static bool isSessionExpired(Guid guid) {
            if (sessionInfos.ContainsKey(guid)) {
                // sessione scaduta
                if (sessionInfos[guid].lastUsingDate.AddMinutes(durationSessionLastDateMinutes) < DateTime.UtcNow) {
                    return true;
                }
                return false;
            }
            return true;
        }

        public static void cleanSession()
        {
            cleanSessionInfosSSO();
            cleanSessionInfos();
            // aggiorna la data dell'ultima pulizia dei sessionInfo
            lastCleanDate = DateTime.UtcNow;
        }

        /// <summary>
        /// Cleans the sessionInfo that are expired
        /// </summary>
        private static void cleanSessionInfos() {
            List<Guid> removals = new List<Guid>();
            // se è passato il tempo max, vado a ripulire tutte le sessioni  scadute
            if (lastCleanDate.AddMinutes(intervalCleaningMinutes) < DateTime.UtcNow) {
                // nel dict non posso rimuovere durante il ciclo
                foreach (KeyValuePair<Guid, SessionInfo> sessionInfo in sessionInfos) {
                    if (isSessionExpired(sessionInfo.Key)) {
                        removals.Add(sessionInfo.Key);
                    }
                }

                // loop sulla lista dei sessionInfo a rimovere perchè scaduti
                foreach (Guid skey in removals) {
                    var sys_user = sessionInfos[skey].sys_user;
                    var idreg = sessionInfos[skey].idreg;
                    sessionInfos.Remove(skey);
                    // rimuovo utilizzatore dalla cache
                    CacheMDLW.removeUtilizer(sys_user, idreg);
                }

            }
        }

        /// <summary>
        /// Cleans the sessionInfo that are expired
        /// </summary>
        private static void cleanSessionInfosSSO()
        {
            List<String> removals = new List<String>();
            // se è passato il tempo max, vado a ripulire tutte le sessioni  scadute
            if (lastCleanDate.AddMinutes(intervalCleaningMinutes) < DateTime.UtcNow)
            {
                // nel dict non posso rimuovere durante il ciclo
                foreach (KeyValuePair<String, SessionInfoSSO> sessionInfoSSO in sessionInfosSSO)
                {
                    if (validSessionSSO(sessionInfoSSO.Key, sessionInfoSSO.Value.userName) != null)
                    {
                        removals.Add(sessionInfoSSO.Key);
                    }
                }

                // loop sulla lista dei sessionInfoSSO da rimovere perchè scaduti
                foreach (String skey in removals)
                {
                    sessionInfosSSO.Remove(skey);
                }

            }
        }

        internal static void clearSessions() {
            sessionInfos = new Dictionary<Guid, SessionInfo>();
        }
    }
}
