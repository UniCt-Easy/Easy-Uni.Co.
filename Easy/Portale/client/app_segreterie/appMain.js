/*globals appMeta,$*/
(function() {

    var loc;
    function appMain() {
        if (appMeta.appMainConfig.setTheme &&
            appMeta.appMainConfig.cssTheme) {
            appMeta.appMainConfig.setTheme(appMeta.appMainConfig.cssTheme);
        }
    }

    appMain.prototype = {
        constructor: appMain,

        /**
         * Initializes the App that uses "MDWL" library
         */
        init: function () {

            // default è italiano, il file italiano avrà sicuramente tutte le stringhe, poiché parto sempre da quello
            // per inserire nuove costanti per le stringhe
            appMeta.localResource.setLanguage(appMeta.localResource.currLng);

            $("#redirectSSO").hide();
            this.initWhiteLabeling();
            // configurazione proprietà framework
            this.initAppMainVariables();
            this.checkshowSSOLogin();
            // bottoni esterni, per login etc
            $("#logoutButton").on("click", _.partial(this.doLogout, this ));
            $("#loginButton").on("click", _.partial(this.doLogin, this ) );
            $("#logoutButton").hide();
            $("#gotoLogin_id").hide();
            $("#gotoRegister_id").on("click", _.partial(this.goToRegister, this ) );
            $("#gotoLogin_id").on("click", _.partial(this.goToLogin, this, true ) );
            $("#redirectSSO").on("click", _.partial(this.redirectSSO, this, true ));
            $("#btnshowPassword0").on("click", _.partial(this.showHidePassword, this, 0 ));
            $("#btnshowPassword1").on("click", _.partial(this.showHidePassword, this, 1 ));
            $("#btnshowPassword2").on("click", _.partial(this.showHidePassword, this, 2 ));

            // ldap
            if (appMeta.appMainConfig.ldapEnabled) {
                $("#login").hide();
                $("#loginldap").show();
                $("#btnshowPassword4").on("click", _.partial(this.showHidePassword, this, 4 ));
                $("#loginButtonLDAP").on("click", _.partial(this.doLoginLDAP, this ) );
            }

            $("#resetPwdMailButton").on("click", _.partial(this.resetPwdSendMail, this ) );


            $("#resetPwdMailId").show();
            $("#resetPwdMailId").on("click", _.partial(this.resetPwdMailIdClick, this ) );

            $("#bewPwdButton").on("click", _.partial(this.newPwdButtonClick, this ) );

            this.fillAnniCombo();

            // gestisce localizzazione e cambio lingua
			this.localize();

			//TEST registrazone
			//appMeta.currApp.callPage('registrationuser', 'usr', false);
            this.tryAutomaticLogin();

        },
		
		fillAnniCombo: function() {
            $("#yearsComboId").empty();
            var curranno = new Date().getFullYear();
            var anni = [curranno, curranno-1, curranno-2];
            _.forEach(anni, function(anno) {
                var opt = document.createElement("option");
                opt.textContent = anno;
                opt.value = anno;
                $("#yearsComboId").append(opt);
            });
        },
		
		tryAutomaticLogin: function() {
            // se in get ho parametri speciali, devo fare altro tipo di logica, quindi non tento il login automatico
            let username = this.getUrlVars()["username"];
            let session = this.getUrlVars()["session"];
            let tokenresetpwd = this.getUrlVars()["tokenresetpwd"];

            if (username || session || tokenresetpwd) {
                appMeta.authManager.logout();
                return;
            }

            // se utente è gia loggato entro sulla app
            if (appMeta.authManager.recoverSession()) {
                this.doActionsAfterLoginSuccess();
                return;
            }
            appMeta.authManager.logout();
        },

        getUrlVars:function() {
            let vars = {};
            window.location.href.replace(/[?&]+([^=&]+)=([^&]*)/gi, function (m, key, value) {
                vars[key] = value;
            });
            return vars;
        },

        checkSSORedirect:function() {
            let username = this.getUrlVars()["username"];
            let session = this.getUrlVars()["session"];
            if (username && session) {
                this.loginSSO(username, session);
                return;
            }
            // se c'è redirect=N o n allora non redireziona verso sso
            let redirect = this.getUrlVars()["redirect"];
            if (redirect && redirect.toString().toUpperCase() === "N") {
                return;
            }
            if (appMeta.appMainConfig.ssoEnable) {
                this.redirectSSO();
            }
        },

         checkResetPwd:function() {
			let tokenresetpwd = this.getUrlVars()["tokenresetpwd"];
            if (!!tokenresetpwd) {
                $("#nuovaPasswordFormdId").show();
                $("#login").hide();
                $("#loginldap").hide();
            }
        },

        resetPwdMailIdClick:function() {
           $("#resetPasswordMailId").show();
        },

        newPwdButtonClick:function(that) {
            let password1 = $("#password1").val();
            let password2 = $("#password2").val();
            let token = that.getUrlVars()["tokenresetpwd"];

            if (!password1 || !password2) {
                that.showInfoMsg("Inserisci password");
                return;
            }
            if (password1 !== password2) {
                that.showInfoMsg("Le password sono diverse");
                return;
            }

            that.showWaitingIndicator('Salvataggio nuova password', document.body);
            appMeta.authManager.nuovaPassword(token, password1)
                .then(function (res) {
                    that.hideWaitingIndicator();
                    if (res) {
                        $("#login").show();
                        $("#resetPasswordMailId").hide();
                        $("#nuovaPasswordFormdId").hide();
                        that.showInfoMsg("Password salvata correttamente. Effettua nuovo login");
                    } else {
                        console.log("C'è stato qualche problema nel nuova pwd");
                    }
                });
        },

        showInfoMsg:function(msg) {
            return new appMeta.BootstrapModal(appMeta.localResource.alert,
                msg,
                [appMeta.localResource.ok],
                appMeta.localResource.cancel)
                .show(null);
        },
		
		validateEmail:function(email) {
            const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            return re.test(String(email).toLowerCase());
        },

        resetPwdSendMail:function(that) {
            var email = $("#emailId").val();

            if (!email) {
                that.showInfoMsg("Inserisci la mail");
                return;
            }

			if (!that.validateEmail(email)) {
                that.showInfoMsg("Inserisci una mail valida");
                return;
            }

            that.showWaitingIndicator('invio mail', document.body);
            appMeta.authManager.resetPassword(email)
                .then(function (res) {
                    that.hideWaitingIndicator();
                    if (res) {
                        that.showInfoMsg("Abbiamo inviato un link alla tua mail per il recupero password");
                    } else {
                        console.log("C'è stato qualche problema nel reset pwd");
                    }
                });

        },

        /**
         * show hide the password
         * @param {appMain} that
         * @param {number} elemNum
         */
        showHidePassword:function(that, elemNum) {
            that["isPwdToShow" + elemNum] = !that["isPwdToShow" + elemNum];
            var type = that["isPwdToShow" + elemNum] ? 'text' : 'password';
            var iconRemove = that["isPwdToShow" + elemNum] ? 'fa-eye' : 'fa-eye-slash';
            var iconAdd = that["isPwdToShow" + elemNum] ? 'fa-eye-slash' : 'fa-eye';
            $('#iconPwd'+elemNum).removeClass(iconRemove);
            $('#iconPwd'+elemNum).addClass(iconAdd);
            $('#password'+elemNum).attr('type', type);
        },

        checkshowSSOLogin:function(){
            if (appMeta.appMainConfig.ssoEnable) {
                $("#redirectSSO").show();
            }
        },
		
		hideLoginForm:function() {
            $("#login").hide();
            $("#loginldap").hide();
            $("#redirectSSO").hide();
            $("#logoutButton").hide();
            $("#gotoLogin_id").show();
            $("#gotoRegister_id").hide();
            $("#metaRoot").show();
        },

        showLoginForm: function (that) {
            if (appMeta.appMainConfig.ldapEnabled) {
                $("#loginldap").show();
            } else {
                $("#login").show();
            }
            $("#gotoLogin_id").hide();
            $("#gotoRegister_id").show();
            that.checkshowSSOLogin();
        },

        goToRegister:function (that) {
            // nasconde login
            that.hideLoginForm();

            // mostra form per la registrazione
            that.stringOriginal  = appMeta.localResource.modalLoader_wait_insert;
            appMeta.localResource.modalLoader_wait_insert = loc.retrieveDataForRegistration;

            appMeta.currApp.callPage(appMeta.appMainConfig.registrationUserTableName, appMeta.appMainConfig.registrationUserEditType, false)
                .then(function (p) {
                    // mostro login, quando la pag di registrazione viene chiusa

					if (appMeta.appMainConfig.ssoEnable) {
                        return;
                    }

                    // mostra il login
                    that.showLoginForm(that);
                });
        },
		
		 /**
         * invoca la pagina per la richiesta di registrazione, quando si proviene da un sso
         */
        ssoRegistration: function (that, method, ssoPrms) {
            this.hideLoginForm();
            // salvo info globali per sso, per popolare html della pag di registrazione
            appMeta.ssoPrms = ssoPrms;
            appMeta.currApp.callPage(appMeta.appMainConfig.registrationUserTableName, appMeta.appMainConfig.registrationUserEditType, false)
                .then(function () {
                    appMeta.connection.unsetToken();

                    // mostra il login
                    that.showLoginForm(that);
                })
        },

        /**
         * Localizes the app.
         * 1. gets the lang (from browser or user session lang)
         * 2. invokes the routine to set the new lang
         * 3. adds the handler to the menù language buttons
         */
        localize:function () {
            loc = appMeta.localization;
            // per ora assegna la lingua del browser
            var lang = loc.getBrowserLanguage();
            // metodo per cambiare lingua (app + mdlw fmw)
            loc.setLanguage(lang);
            // evento di selezione lingua sul menù
            $(".dropdown-menu a").on("click", _.partial(this.changeLang, this ) );
        },

        /**
         * Fired on menù lang item selection. Changes the icon and lang selected. call the new lang settings
         */
        changeLang:function () {
            // la drop dwon non effettua automaticamente la selezione dell'item come una select , quindi effettuo swap manuale dell'item selezionato
            let langSel= $("#langctrl_id");
            let htmlLangOld = langSel.html();
            let htmlLangNew = $(this).html();
            // recupero lingua selezionata dall'item
            let lang = $(this).find("span").data("lang");
            // swap dell'item
            langSel.html(htmlLangNew);
            $(this).html(htmlLangOld);
            // set della nuova lingua
            loc.setLanguage(lang);
           
        },

        /**
         * Gestisce il logout
         */
        doLogout:function (that) {

            var winModal = new appMeta.BootstrapModal("logout",  appMeta.localResource.logoutMsg,
                [appMeta.localResource.yes, appMeta.localResource.no], appMeta.localResource.no);
            return winModal.show(null)
                .then(function (res) {
                    if (res === appMeta.localResource.yes) {
                        appMeta.authManager.logout()
                            .then(function () {

                                // NON fa logout SSO. "se magari non funziona la url di logout"
                                if (appMeta.appMainConfig.ssoEnable && appMeta.appMainConfig.SSOSingleCheckLogout){
                                    that.goToLogin(that, true);
                                    return;
                                }

                                if (appMeta.appMainConfig.ssoEnable && appMeta.appMainConfig.SSODoubleCheckLogout) {
                                    var winModal = new appMeta.BootstrapModal("logout SSO", appMeta.localResource.logoutSSOMsg ,
                                        [appMeta.localResource.yes, appMeta.localResource.no], appMeta.localResource.no);
                                    return winModal.show(null)
                                        .then(function (res) {
                                            if (res === appMeta.localResource.yes) {
                                                appMeta.authManager.logoutSSO();
                                            } else {
                                                that.goToLogin(that, true);
                                            }
                                        });
                                } else if (appMeta.appMainConfig.ssoEnable && !appMeta.appMainConfig.SSODoubleCheckLogout){
                                    appMeta.authManager.logoutSSO();
                                } else {
                                    that.goToLogin(that, true);
                                }
                            });
                    }
                });
        },

        /**
         * Esegue operazioni dopo il successo della login
         */
        doActionsAfterLoginSuccess:function () {
            var self = this;
            // inizializza il menù da db
            this.initMenuWeb().then(function () {
			    appMeta.authManager.setSystemInfo();
                // nasconde login
                self.hideLoginForm();
                $("#logoutButton").show();
                $("#gotoLogin_id").hide();
                $("#resetPasswordMailId").hide();
                $("#toolbar").show();
                self.enableMenu();
                // nasconde indicatore di attesa
                self.hideWaitingIndicator(); 
				
				self.openPageByQueryUrl();

                appMeta.Toast.showNotification(loc.toast_login_success);

            })
        },
		
		openPageByQueryUrl:function () {
            var tableName = this.getUrlVars()["tablename"];
            var editType = this.getUrlVars()["edittype"];
            if (!!tableName && !!editType) {
                appMeta.currApp.callPage(tableName, editType, false)
            }
        },
		
		checkSearchOnOpening:function (metaPage) {
            var searchon = this.getUrlVars()["searchon"];
            if (!!searchon && searchon === "on") {
                metaPage.cmdMainDoSearch();
            }
        },

        doLoginLDAP:function(that) {
            var username = $("#emailldap").val();
            var password = $("#password4").val();
            var datacontabile = new Date(parseInt(new Date().getFullYear()),10,30);

            if (username && password) {
                that.showWaitingIndicator(loc.loginRunning, document.body);
                appMeta.authManager.loginLDAP(username, password, datacontabile)
                    .then(function (res) {
                        if (res) {
                            that.doActionsAfterLoginSuccess();
                        } else {
                            console.log("C'è stato qualche problema nel login");
                            that.hideWaitingIndicator();
                        }
                    })
            } else {
                that.showInfoMsg("Inserisci username e password");
            }
        },

        /**
         *
         * @param {appMain} that
         */
        doLogin:function (that) {
            var username = $("#username").val();
            var password = $("#password0").val();
            var anno = $("#yearsComboId").val();
            var datacontabile = new Date(parseInt(anno),10,30);

            if (username && password) {
                that.showWaitingIndicator(loc.loginRunning, document.body);
                appMeta.authManager.login(username, password, datacontabile)
                    .then(function (res) {
                        if (res) {
                            that.doActionsAfterLoginSuccess();
                        } else {
                            console.log("C'è stato qualche problema nel login");
                            that.hideWaitingIndicator();
                        }
                    })
            } else {
                that.showInfoMsg("Inserisci username e password");
            }
        },

        redirectSSO:function() {
            window.location.href = appMeta.appMainConfig.backendUrl + appMeta.appMainConfig.ssoPath;
        },

        loginSSO:function(username, session) {
            var that = this;
            var datacontabile = new Date(appMeta.appMainConfig.dataContabileYear,10,30);
            if (username === '' || session === '') {
                that.showInfoMsg("Impossibile effettuare login, parametri SSO non corretti");
            } else {
                that.showWaitingIndicator("Login SSO", document.body);
                appMeta.authManager.loginSSO(username, session, datacontabile)
                    .then(function (res) {
                        that.hideWaitingIndicator();
                        if (res === true) {
                            that.doActionsAfterLoginSuccess();
                        } else if (res === false) {
                            that.showInfoMsg("C'è stato qualche problema nella login per il Single  Sign On!");
                        }
                    })
            }
        },

        /**
         * callback su evento di credenziali scadute. mostro login
         */
        expiredCredential:function () {
            this.goToLogin(this, false);
        },

        /**
         *
         */
        goToLogin: function (that, closePage) {

            // mostra il login
            that.showLoginForm(that);

            $("#logoutButton").hide();
            $("#metaRoot").hide();
            $("#toolbar").hide();
            that.disableMenu();
            appMeta.currApp.forceClosePopupDialog();
            // chiudi pagina corrente
            if (appMeta.currApp.currentMetaPage && closePage){
                appMeta.currApp.currentMetaPage.cmdClose()
					.then(function () {
						that.hideWaitingIndicator(that);
					});
            } else{
                that.hideWaitingIndicator(that);
            }
        },

        /**
         * Initializes the menù items. Attaches the click events to the menù items
         * @returns {Deferred}
         */
        initMenuWeb:function () {
            var self = this;
            var def = $.Deferred();
            // singleton
            if(!this.menuBuilder) {
                // Effetua la query sulla tabella menu web per recuperare il menù e invoca la funz del menuBuilder
                this.menuBuilder  = new appMeta.menuBuilder();
            }
            this.menuBuilder.clearMenu();

            this.showWaitingIndicator(loc.menuLoading);
            return appMeta.getData.runSelect("menuweb" , "*" , null, null)
                .then(function (dtMenuWeb) {
                    // salvo in una variabile sotto security, perchè poi la utizzo nella gestione dei bottone nelle pagine base
                    appMeta.security.dtMenuWeb = dtMenuWeb;
                    loc.localizeMenu(dtMenuWeb);
                    self.menuBuilder.buildMenu(dtMenuWeb);
                    return def.resolve();
                })
                .fail(function () {
                    self.menuBuilder = null;
                });
        },

        /**
         * Initializes the appMeta variables
         */
        initAppMainVariables: function () {

            //--------------registrazione servizi

            //metodi generali dell'applicativo
            appMeta.routing.builderConnObj("downloadLogo", 'GET', 'file', false, true);
            appMeta.routing.builderConnObj("importExcel", 'POST', 'data', false, true);

            //metodi dei comandi di amministratore
            appMeta.routing.builderConnObj("adminregisteruser", 'POST', 'admin', false, true);
            appMeta.routing.builderConnObj("clearCache", 'GET', 'admin', false, true);
            appMeta.routing.builderConnObj("clearSessions", 'GET', 'admin', false, true);
            appMeta.routing.builderConnObj("cryptSystemConfig", 'POST', 'admin', false, true);

            //metodi custom per modulo segreterie
            appMeta.routing.builderConnObj("protocolla", 'POST', 'segreterie', false, true);

            //metodi custom per modulo progetti
            appMeta.routing.builderConnObj("calculateAmmortamento", 'POST', 'progetti', false, true);
            appMeta.routing.builderConnObj("calculateCostiProgetto", 'POST', 'progetti', false, true);

            // metodi custom per modulo performance
            appMeta.routing.builderConnObj("calcolaComportamenti", 'POST', 'performance', false, true);

            //web services dati per la didattica Be Smart
            appMeta.routing.builderConnObj("getCaricoDidattico", 'POST', 'admin', false, true);
            appMeta.routing.builderConnObj("getAllocations", 'POST', 'admin', false, true);

            appMeta.routing.builderConnObj("signFile", 'POST', 'signature', false, true);

            //web services delle presenze Zucchetti
            appMeta.routing.builderConnObj("getTimbrature", 'POST', 'admin', false, true); 

            //web services del costo orario del personale Wis-Per
            appMeta.routing.builderConnObj("getCostoOrario", 'POST', 'admin', false, true); 

            //----------------variabili di applicazione

            //path relativo dove si trovano i servizi
            if (appMeta.appMainConfig.serviceBasePath) {
                appMeta.serviceBasePath = appMeta.appMainConfig.serviceBasePath;
            } else {
                appMeta.serviceBasePath = "/";
            }
            appMeta.basePath = appMeta.appMainConfig.basePath;
            appMeta.basePathMetadata = appMeta.appMainConfig.basePathMetadata;
            appMeta.currApp.rootElement = appMeta.appMainConfig.rootElement;

            // copio i valori di configurazione utilizzati
            _.extend(appMeta.config, appMeta.appMainConfig);
            appMeta.routing.setUrlPrefix(appMeta.appMainConfig.backendUrl);
            appMeta.currApp.start();
            // reagisco all'evento di nuova pagina mostrata, così eventualmente posso fare delle azioni sul menu esterno
            appMeta.globalEventManager.subscribe(appMeta.EventEnum.showPage, this.showPage, this);
            appMeta.globalEventManager.subscribe(appMeta.EventEnum.expiredCredential, this.expiredCredential, this);
            appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
            appMeta.globalEventManager.subscribe(appMeta.EventEnum.ERROR_SERVER, this.serverError, this);
            appMeta.globalEventManager.subscribe(appMeta.EventEnum.SSORegistration, this.ssoRegistration, this);

        },

        initWhiteLabeling:function() {
            if (appMeta.appMainConfig.headerTitle !== undefined) {
                $('.portale_brand_name_id').text(appMeta.appMainConfig.headerTitle);
                $('head title').text(appMeta.appMainConfig.headerTitle);
            }
            if (appMeta.appMainConfig.logoHeaderBase64) {
                $('.portale_brand_logo_id').attr('src', appMeta.appMainConfig.logoHeaderBase64);
            } else {
                $('.portale_brand_logo_id').hide();
            }
            if (appMeta.appMainConfig.tempo_brand_logo_id) {
                $('.tempo_brand_logo_id').attr('src', appMeta.appMainConfig.tempo_brand_logo_id);
            } else {
                $('.tempo_brand_logo_id').hide();
            }

        },



        /**
         * Nasconde eventuale popup di errore
         */
        serverError:function () {
            this.hideWaitingIndicator();
        },

        /**
         * @method showPage
         * @private
         * @description SYNC
         * Invoked each time that a page is opened.
         * It checks if the page opening is a detail. In that case it disable the menu, otherwise it enable menu
         * @param {MetaPage} currPageShowing
         */
        showPage:function (currPageShowing) {
            loc.localizePage(currPageShowing);
            var self = this;
            // se è pag di registrazione invoco tasto "Nuovo"
            if (this.isRegistrationUserPageCondition(currPageShowing)) {
                $("#metaRoot").show();
                $("#toolbar").show();
                currPageShowing.doMainCommand("maininsert")
                    .then(function () {
                        appMeta.localResource.modalLoader_wait_insert = self.stringOriginal;
                    });
            } else {
                if (currPageShowing.detailPage) return this.disableMenu();
                this.enableMenu();
				this.checkSearchOnOpening(currPageShowing);
            }
        },

        /**
         *
         * @param {MetaPage} mp
         * @returns {boolean} return true if the MetaPage is that for the registration
         */
        isRegistrationUserPageCondition:function (mp) {
            var isRegUSR  = (mp.primaryTableName === appMeta.appMainConfig.registrationUserTableName && mp.editType ===  appMeta.appMainConfig.registrationUserEditType);
            // se è la pag corretta e già ho inserito una riga principale , (con tutti i sui figli sub entity)
            if (!isRegUSR) return false;
			if (mp.state && mp.state.DS && !mp.state.DS.tables[appMeta.appMainConfig.registrationUserTableName].rows.length) return true;
            return false
        },
        

        /**
         * @param {MetaPage} currMetaPage
         * @param {string} cmd
         */
        buttonClickEnd:function (currMetaPage, cmd) {
           if (cmd === "mainsetsearch") this.selectFirstTab();
        },

        /**
         * seleziona primo tab
         */
        selectFirstTab:function () {
            if ( $('.nav-tabs a:first').length > 0 ) $('.nav-tabs a:first').tab('show');
        },

        /**
         * @method enableMenu
         * @private
         * @description SYNC
         */
        enableMenu:function () {
            if (this.menuBuilder) this.menuBuilder.enableMenu();
            $("#logoutButton").show();
        },

        /**
         * @method disableMenu
         * @private
         * @description SYNC
         * Disables all the tabs
         */
        disableMenu:function () {
            if (this.menuBuilder) this.menuBuilder.disableMenu();
            $("#logoutButton").hide();
        },

        /**
         * @method showWaitingIndicator
         * @private
         * @description SYNC
         * Shows a modal loader indicator. It is not possible to close the modal by user
         * @param {string} msg. the message to show in the box
         */
        showWaitingIndicator:function (msg, rootElement) {
            return appMeta.modalLoaderControl.show(msg, false);
        },

        /**
         * @method hideWaitingIndicator
         * @private
         * @description SYNC
         * Hides a modal loader indicator. (Shown with funct. showWaitingIndicator())
         */
        hideWaitingIndicator:function () {
            appMeta.modalLoaderControl.hide();
        }

    };

    // appMain è singleton
    appMeta.appMain = new appMain();

}());
