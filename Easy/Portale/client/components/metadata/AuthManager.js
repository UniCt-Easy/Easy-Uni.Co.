
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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


/**
 * @module AuthManager
 * @description
 * Manages the public methods for the user authentication
 */
(function () {

    var Deferred = appMeta.Deferred;
    var methodEnum = appMeta.routing.methodEnum;
    var sec = appMeta.security;

    var EnumLoginType = {
        userPassword: 0,
        sso: 1
    };
    /**
     * @method AuthManager
     * @constructor
     */
    function AuthManager() {
        "use strict";
    }

    AuthManager.prototype = {
        
        constructor: AuthManager,

        /**
         * @method login
         * @public
         * @description ASYNC
         * Calls the web service for the login
         * @param {string} userName
         * @param {string} password
         * @returns {Deferred} true if login is ok, false otherwise
         */
        login: function(userName, password, datacontabile) {
           return this.loginCore(EnumLoginType.userPassword, userName, password, datacontabile);
        },

        /**
         * @method login
         * @public
         * @description ASYNC
         * Calls the web service for the login
         * @param {string} userName
         * @param {string} session. generated backend side
         * @returns {Deferred} true if login is ok, false otherwise
         */
        loginSSO: function(userName, session, datacontabile) {
            return this.loginCore(EnumLoginType.sso, userName, session, datacontabile)
        },

        /**
         *
         * @param type
         * @param userName
         * @param {string} password can be password or session in ssso login.
         * @param datacontabile
         * @returns {*}
         */
        loginCore: function(type, userName, password, datacontabile) {
            var self = this;
            var def  = Deferred("login");
            var objConn;

            // distinguo 2 tipi differenti. 1. con password, 2. con session, cioè il caso di SSO
            if (type === EnumLoginType.userPassword) {
                objConn = {
                    method: methodEnum.login,
                    prm: {
                        userName: userName,
                        password: password,
                        datacontabile: datacontabile.toJSON()
                    }
                };
            }

            if (type === EnumLoginType.sso) {
                objConn = {
                    method: methodEnum.loginSSO,
                    prm: {
                        userName: userName,
                        session: password,
                        datacontabile: datacontabile.toJSON()
                    }
                };
            }

            appMeta.connection.call(objConn)
                .then(function(data) {
                        if (data.token) {
                            return def.from(self.callBackLoginWithToken(data))
                        }
                        // se non arriva token devo valutare sia login sso con registrazione abilitata
                        return def.from(self.callBackLoginWithoutToken(data))
                    },
                    function() {
                        return def.resolve(false);
                    });

            return def.promise();
        },

        callBackLoginWithToken: function (data) {
            var self = this;
            var def  = Deferred("callBackLoginWithToken");
            // memorizzo token di autenticazione. verrà passato ad ogni chiamata
            appMeta.connection.setToken(data.token, data.expiresOn);
            // salvo var ambiente di sicurezza tornate dal server sulla classe security
            self.setEnv(data.sys, data.usr);

            // intercetto i ruoli, se sono più di 1 allora lo faccio scegliere,
            // altrimenti entro con quello
            var dtRolesJson = data.dtRoles;
            var dtRoles = appMeta.getDataUtils.getJsDataTableFromJson(dtRolesJson);
            if (dtRoles.rows &&
                dtRoles.rows.length > 1) {
                return def.from(self.cambioRuolo(dtRoles));
            }
            return def.resolve(true);
        },

        callBackLoginWithoutToken: function (data) {
            var self = this;
            var def = Deferred("callBackLoginWithoutToken");
            if (this.isValidSsoRequest(data)) {
                // in ogni caso devo riportare al login
                appMeta.globalEventManager.trigger(appMeta.EventEnum.SSORegistration, self, 'SSORegistration', data);
                return def.resolve();
            }
            return def.resolve(false);
        },

        isValidSsoRequest:function(json) {
            // considero sempre valido il json, sso potrebbe non tornare cf
            // sarà obbligatorio nella richiesta registrazione
            return true;

            if (json && !!json.cf) {
                return true
            }
            return false;
        },

        setSystemInfo:function() {
            var calcFeVer = function () {
                var currhtml = document.documentElement.outerHTML;
                var firstvariable = '<script src="../dist/mdlw_bundle_';
                var secondvariable = '.js"></script>';
                var matches = currhtml.match(new RegExp(firstvariable + "(.*)" + secondvariable));
                if (matches && matches.length > 1){
                    var match = matches[1];
                    return match.substring(match.indexOf('_') + 1)
                }
                return 'Debug';
            };
            var dbver = sec.sys('dbversion');
            var bever = sec.sys('backendversion');
            var fever = calcFeVer();
            var systemInfo = 'DB ver: ' + dbver + ' - server version: ' + bever + ' - client ver: ' + fever;
            var footer = $('.footer p');
            var footerText = appMeta.appMainConfig.copyright;
            footer.text(footerText + ' - ' + systemInfo);
        },

        /**
         *
         * @param {DataTable} dtRoles
         * @returns {Deferred} true is logged ok, false otherwise
         */
        cambioRuolo:function(dtRoles) {
          var def  = Deferred("cambioRuolo");
          var self = this;
          // apre modale per la scelta del ruolo, quindi si mette in attesa
          var cambioRuolo = new appMeta.CambioRuolo();
          cambioRuolo.show(dtRoles)
            .then(function(data) {
                if (data) {
                    // imposta nuovo environment
                    self.setEnv(data.sys, data.usr);
                    return def.resolve(true);
                }
                return def.resolve(false);
            });
          return def.promise();
        },

        /**
         * @method setEnv
         * @public
         * @description SYNC
         * @param {object} sys
         * @param {object} usr
         */
        setEnv:function(sys, usr){
            _.forOwn(sys, function (value, key) {
                sec.sys(key, value);
            });
            _.forOwn(usr, function (value, key) {
                sec.internalSetUsr(key, value);
            });

           sec.saveSession();
        },

        /**
         * @method unsetEnv
         * @public
         * @description SYNC
         * resets the environment
         */
        unsetEnv:function () {
            sec.clear();
        },

        /**
         * @method logout
         * @public
         * @description ASYNC
         * Does the logout
         * @returns {Deferred}
         */
        logout:function () {
            var def  = Deferred("login");
            this.unsetEnv();
            appMeta.connection.currentBackendManager.unsetToken();
			return def.resolve();
        },

        logoutSSO:function() {
            window.location.href = appMeta.appMainConfig.ssoLogoutUrl;
        },

         /**
         * @method recoverSession
         * @public
         * @description SYNC
         * Tries to recover session if it is not expired and it is stored in cookies
         * @returns {boolean} true if session is recovered
         */
        recoverSession:function () {
            if (!this.isLogged()) {
                return false;
            }
            sec.loadSession();
            return sec.isEnvironmentSet();
        },

        /**
         * @method isLogged
         * @public
         * @description SYNC
         * Verifies if user is already logged. Return true if user is already logged, false otherwise
         * @returns {boolean} true if user is already logged
         */
        isLogged:function () {
            // leggo su storage locale
            var token = appMeta.connection.getAuthToken();
			var expiresOn = appMeta.connection.getTokenExpiresOn();
            if (token && expiresOn){
                try {
                    // verifico che il token non sia scaduto, in base alla data attuale e quella ricevuta dal server
                    // del tipo "new Date(xxxxxxx)"
                    var milliseconds = eval(expiresOn).getTime() - (new Date()).getTime();
                    // se ancora non è scaduta setto header chiamata ajax 
                    if (milliseconds > 0) {
                        return true;                      
                    }
                } catch (e) {                   
                    return false;
                }
            }
            return false;
        },

        /**
         * @method register
         * @public
         * @description ASYNC
         * Calls the web service for the signup
         * @param {string} username
         * @param {string} password
         * @param {string} email
         * @param {string} codiceFiscale
         * @param {string} partitaIva
         * @param {string} cognome
         * @param {string} nome
         * @param {string} dataNascita
         * @param {string} role
         * @returns {Deferred} true if register is ok, false otherwise
         */
        register:function (username, password, email, codiceFiscale, partitaIva, cognome, nome, dataNascita, role){

            var def  = Deferred("register");

            var objConn = {
                method: methodEnum.register,
                prm: {
                    userName: username,
                    password: password,
                    email: email,
                    codiceFiscale : codiceFiscale ,
                    partitaIva : partitaIva,
                    cognome : cognome,
                    nome: nome ,
                    dataNascita: dataNascita,
                    role : role}
            };

            appMeta.connection.call(objConn)
                .then(function() {
                        return def.resolve(true);
                    },
                    function() {
                        return def.resolve(false);
                    });

            return def.promise();
        },

        /**
         * @method resetPassword
         * @public
         * @description ASYNC
         * Calls the web service for reset the password of current user
         * If succeded it sends an email to the specified address. otherwise it returns a string error,
         * for example: "E-mail not registered" or "Account not actived"
         * @param {string} email
         * @returns {Deferred}
         */
        resetPassword:function (email) {
            var def  = Deferred("resetPassword");

            var objConn = {
                method: methodEnum.resetPassword,
                prm: {
                    email: email
                }
            };

            appMeta.connection.call(objConn)
                .then(function() {
                        return def.resolve(true);
                    },
                    function() {
                        return def.resolve(false);
                    });

            return def.promise();
        },

        nuovaPassword:function (token, password) {
            var def  = Deferred("nuovaPassword");

            var objConn = {
                method: methodEnum.nuovaPassword,
                prm: {
                    token: token,
                    password:password
                }
            };

            appMeta.connection.call(objConn)
                .then(function() {
                        return def.resolve(true);
                    },
                    function() {
                        return def.resolve(false);
                    });

            return def.promise();
        },

        sendMail:function (emailDest, subject, htmlBody) {
            var def  = Deferred("sendMail");

            var objConn = {
                method: methodEnum.sendMail,
                prm: {
                    emailDest: emailDest,
                    subject: subject,
                    htmlBody: htmlBody,
                }
            };

            appMeta.connection.call(objConn)
                .then(function() {
                        return def.resolve(true);
                    },
                    function() {
                        return def.resolve(false);
                    });

            return def.promise();
        },

    };

    appMeta.authManager = new AuthManager();

}());
