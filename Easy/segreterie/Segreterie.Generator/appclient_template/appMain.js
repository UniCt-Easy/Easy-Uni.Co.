(function() {

    var loc;
    function appMain() {}

    appMain.prototype = {
        constructor: appMain,

        /**
         * Initializes the App that uses "MDWL" library
         */
        init:function () {
            $("#redirectSSO").hide();
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

            $("#resetPwdMailButton").on("click", _.partial(this.resetPwdSendMail, this ) );
            $("#resetPwdMailId").on("click", _.partial(this.resetPwdMailIdClick, this ) );
            $("#bewPwdButton").on("click", _.partial(this.newPwdButtonClick, this ) );
			
			this.fillAnniCombo();
			
           // gestisce localizzazione e cambio lingua
            this.localize();

            // se utente è gia loggato entro sulla app
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
            var username = this.getUrlVars()["username"];
            var session = this.getUrlVars()["session"];
            var tokenresetpwd = this.getUrlVars()["tokenresetpwd"];

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
            var vars = {};
            window.location.href.replace(/[?&]+([^=&]+)=([^&]*)/gi, function (m, key, value) {
                vars[key] = value;
            });
            return vars;
        },
		
		checkSSORedirect:function() {
            var username = this.getUrlVars()["username"];
            var session = this.getUrlVars()["session"];
            if (!!username && !!session) {
                this.loginSSO(username, session);
                return;
            }
            // se c'è redirect=N o n allora non redireziona verso sso
            var redirect = this.getUrlVars()["redirect"];
            if (redirect && redirect.toString().toUpperCase() === "N") {
                return;
            }
            if (appMeta.appMainConfig.ssoEnable) {
                this.redirectSSO();
            }
        },

         checkResetPwd:function() {
            var tokenresetpwd = this.getUrlVars()["tokenresetpwd"];
            if (!!tokenresetpwd) {
                $("#nuovaPasswordFormdId").show();
                $("#login").hide();
            }
        },

        resetPwdMailIdClick:function() {
           $("#resetPasswordMailId").show();
        },

        newPwdButtonClick:function(that) {
            var password1 = $("#password1").val();
            var password2 = $("#password2").val();
            var token = that.getUrlVars()["tokenresetpwd"];

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
                })
        },

        showInfoMsg:function(msg) {
            return new appMeta.BootstrapModal(appMeta.localResource.alert,
                msg,
                [appMeta.localResource.ok],
                appMeta.localResource.cancel)
                .show(null)
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
                })

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
            $("#redirectSSO").hide();
            $("#logoutButton").hide();
            $("#gotoLogin_id").show();
            $("#gotoRegister_id").hide();
            $("#metaRoot").show();
        },

        /**
         *
         */
        goToRegister:function (that) {
            // nasconde login
            that.hideLoginForm();

            // mostra form per la registrazione
            that.stringOriginal  = appMeta.localResource.modalLoader_wait_insert;
            appMeta.localResource.modalLoader_wait_insert = loc.retrieveDataForRegistration;

            appMeta.callPage(appMeta.appMainConfig.registrationUserTableName, appMeta.appMainConfig.registrationUserEditType, false)
                .then(function (p) {
                   
				    if (appMeta.appMainConfig.ssoEnable) {
                        return;
                    }
					
                    $("#login").show();
                    $("#gotoLogin_id").hide();
                    $("#gotoRegister_id").show();
                    that.checkshowSSOLogin();
                });
        },
		
		 /**
         * invoca la pagina per la richiesta di registrazione, quando si proviene da un sso
         */
        ssoRegistration: function (that, method, ssoPrms) {
            this.hideLoginForm();
            // salvo info globali per sso, per popolare html della pag di registrazione
            appMeta.ssoPrms = ssoPrms;
            appMeta.callPage(appMeta.appMainConfig.registrationUserTableName, appMeta.appMainConfig.registrationUserEditType, false)
                .then(function () {
                    appMeta.connection.unsetToken();
                    // mostro login, quando la pag di registrazione viene chiusa
                    $("#login").show();
                    $("#gotoLogin_id").hide();
                    that.checkshowSSOLogin();
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
            var htmlLangOld = $("#langctrl_id").html();
            var htmlLangNew = $(this).html();
            // recupero lingua selezionata dall'item
            var lang = $(this).find("span").data("lang");
            // swap dell'item
            $("#langctrl_id").html(htmlLangNew);
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
                                if (appMeta.appMainConfig.ssoEnable) {
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
                $("#login").hide();
                $("#redirectSSO").hide();
                $("#logoutButton").show();
                $("#gotoLogin_id").hide();
                $("#gotoRegister_id").hide();
				$("#resetPasswordMailId").hide();
                $("#metaRoot").show();
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
                appMeta.callPage(tableName, editType, false)
            }
        },
		
		checkSearchOnOpening:function (metaPage) {
            var searchon = this.getUrlVars()["searchon"];
            if (!!searchon && searchon === "on") {
                metaPage.cmdMainDoSearch();
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
                            that.showInfoMsg("C'è stato qualche problema nella login per il Single  Sign On, probabilmente il codice fiscale non è stato ricevuto!");
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
        goToLogin:function (that, closePage) {
            $(appMeta.appMainConfig.rootLogin).show();
            that.checkshowSSOLogin();
            $("#logoutButton").hide();
            $("#gotoLogin_id").hide();
            $("#gotoRegister_id").show();
            $("#metaRoot").hide();
            $("#toolbar").hide();
            that.disableMenu();
            appMeta.forceClosePopupDialog();
            // chiudi pagina corrente
            if (appMeta.currentMetaPage && closePage){
                appMeta.currentMetaPage.cmdClose()
                    .then(function () {
                        that.hideWaitingIndicator(that);
                    })
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
        initAppMainVariables:function () {
            appMeta.routing.builderConnObj("calculateAmmortamento", 'POST', 'progetti', false, true);
            appMeta.routing.builderConnObj("calculateCostiProgetto", 'POST', 'progetti', false, true);
            // registro chiamate per comandi di admin
            appMeta.routing.builderConnObj("adminregisteruser", 'POST', 'admin', false, true);
            appMeta.routing.builderConnObj("clearCache", 'GET', 'admin', false, true);
            appMeta.routing.builderConnObj("clearSessions", 'GET', 'admin', false, true);
			
			// servizio per import Excel
			appMeta.routing.builderConnObj("importExcel", 'POST', 'data', false, true);

            appMeta.basePath = appMeta.appMainConfig.basePath;
            appMeta.basePathMetadata = appMeta.appMainConfig.basePathMetadata;
            appMeta.rootElement = appMeta.appMainConfig.rootElement;
            // copio i valori di configurazione utilizzati
            _.extend(appMeta.config, appMeta.appMainConfig);
            appMeta.routing.changeUrlMethods(appMeta.appMainConfig.backendUrl);
            appMeta.start();
            // reagisco all'evento di nuova pagina mostrata, così eventualmente posso fare delle azioni sul menu esterno
            appMeta.globalEventManager.subscribe(appMeta.EventEnum.showPage, this.showPage, this);
            appMeta.globalEventManager.subscribe(appMeta.EventEnum.expiredCredential, this.expiredCredential, this);
            appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
            appMeta.globalEventManager.subscribe(appMeta.EventEnum.ERROR_SERVER, this.serverError, this);
			appMeta.globalEventManager.subscribe(appMeta.EventEnum.SSORegistration, this.ssoRegistration, this);
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
            if (mp.state && mp.state.DS && !mp.state.DS.tables.registry.rows.length) return true;
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
        },

        /**
         * @method disableMenu
         * @private
         * @description SYNC
         * Disables all the tabs
         */
        disableMenu:function () {
            if (this.menuBuilder) this.menuBuilder.disableMenu();
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
