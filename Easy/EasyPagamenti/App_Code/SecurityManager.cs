
/*
Easy
Copyright (C) 2023 Universita' degli Studi di Catania (www.unict.it)
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
using System.Reflection;
using System.Web;
using System.Web.SessionState;

namespace Security {

    public class SecurityManager {
        //Dati

        public enum LoginState {
            Denied,
            Delayed,
            Allowed
        }

        //tempi di disabilitazione degli account in secondi da aggiungere al timestamp dell'n-esimo tentativo errato di login
        //private int[] delays = { 1, 1 };
        //private int[] delays = { 30, 40, 50, 60, 70, 80, 90, 100, 110, 120 };
        private int[] delays = { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55 };

        private class AttemptStatus {

            public DateTime lastAttempt;
            public int numAttempts;
        }

        private Dictionary<string, AttemptStatus> attempts = new Dictionary<string, AttemptStatus>();

        private SessionIDManager sessionIDmanager = new SessionIDManager();


        //Metodi

        /// <summary>
        /// restituisce lo stato della username
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Denied, Delayed, Allowed</returns>
        public LoginState loginState(string username) {

            //prendo subito il timestamp perchè non so quanto ci impiegherà la ricerca
            //nel dictionary attempts
            DateTime reqTimestamp = DateTime.Now;

            if (attempts.ContainsKey(username)) {

                AttemptStatus myAttemptStatus = attempts[username];

                if (myAttemptStatus.numAttempts > delays.Length) return LoginState.Denied;

                DateTime loginAllowed = myAttemptStatus.lastAttempt + new TimeSpan(0, 0, delays[myAttemptStatus.numAttempts - 1]);

                if (reqTimestamp < loginAllowed) return LoginState.Delayed;
            }

            return LoginState.Allowed;
        }

        /// <summary>
        /// Segnala a SecurityManager l'immissione di credenziali corrette per username
        /// </summary>
        /// <param name="username"></param>
        public void loginSuccess(string username) {
            //elimino username elemento dal dictionary attempts
            if (attempts.ContainsKey(username)) attempts.Remove(username);
        }

        /// <summary>
        /// Segnala a SecurityManager l'immissione di credenziali errate per username
        /// </summary>
        /// <param name="username"></param>
        public void loginFailure(string username) {

            //prendo subito il timestamp perchè non so quanto ci impiegherà la ricerca
            //nel dictionary attempts
            DateTime warnTimestamp = DateTime.Now;

            //username in attempts, modifico lastAttempt
            if (attempts.ContainsKey(username)) {

                attempts[username].lastAttempt = warnTimestamp;
                attempts[username].numAttempts++;
            }
            //username non in attempts, aggiungo elemento al dictionary attempts
            else {

                attempts[username] = new AttemptStatus {
                    lastAttempt = DateTime.Now,
                    numAttempts = 1
                };
            }
        }

        public void regenSessionID() {

            string oldID = sessionIDmanager.GetSessionID(HttpContext.Current);
            string newID = sessionIDmanager.CreateSessionID(HttpContext.Current);

            bool isAdd = false, isRedir = false;

            sessionIDmanager.SaveSessionID(HttpContext.Current, newID, out isRedir, out isAdd);

            HttpApplication ctx = (HttpApplication)HttpContext.Current.ApplicationInstance;
            HttpModuleCollection mods = ctx.Modules;
            SessionStateModule ssm = (SessionStateModule)mods.Get("Session");
            System.Reflection.FieldInfo[] fields = ssm.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            SessionStateStoreProviderBase store = null;
            System.Reflection.FieldInfo rqIdField = null, rqLockIdField = null, rqStateNotFoundField = null;

            foreach (System.Reflection.FieldInfo field in fields) {
                if (field.Name.Equals("_store")) store = (SessionStateStoreProviderBase)field.GetValue(ssm);
                if (field.Name.Equals("_rqId")) rqIdField = field;
                if (field.Name.Equals("_rqLockId")) rqLockIdField = field;
                if (field.Name.Equals("_rqSessionStateNotFound")) rqStateNotFoundField = field;
            }

            object lockId = rqLockIdField.GetValue(ssm);
            if ((lockId != null) && (oldID != null)) store.ReleaseItemExclusive(HttpContext.Current, oldID, lockId);
            rqStateNotFoundField.SetValue(ssm, true);
            rqIdField.SetValue(ssm, newID);
        }
    }
}
