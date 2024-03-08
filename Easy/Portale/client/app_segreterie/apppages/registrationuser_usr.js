(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_registrationuser() {
		MetaPage.apply(this, ['registrationuser', 'usr', false]);
        this.name = 'Richiesta di accesso';
		this.defaultListType = 'usr';
		this.searchEnabled = false;
		this.canInsert = false;
		this.canInsertCopy = false;
		this.canCancel = false;
		this.canShowLast = false;
		appMeta.connection.setAnonymous();
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_registrationuser.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_registrationuser,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			manageValidResult: function (rowToCheck) {
				var loc = appMeta.localResource;
				var def = appMeta.Deferred("isValid-meta_registrationuser");
				var firstErrorObj;

				if (rowToCheck.table.dataset.tables["registrationuserflowchart"] && rowToCheck.table.dataset.tables["registrationuserflowchart"].rows.length < 1) {
					firstErrorObj = { warningMsg: "", errMsg: loc.getMinNumRowRequired("Autorizzazioni richieste", 1), errField: "XXregistrationuserflowchart", row: rowToCheck };
					return def.resolve(firstErrorObj);
				}

				if (rowToCheck.table.dataset.tables["registrationuser"] &&
					(!rowToCheck.current.surname ||
					 !rowToCheck.current.forename ||
					 !rowToCheck.current.cf
					)) {
					firstErrorObj = { warningMsg: "", errMsg: 'Inserisci i dati nome, cognome e codiceFiscale' , errField: "cf", row: rowToCheck };
					return def.resolve(firstErrorObj);
				}
//$isValidArray$
				
				return  MetaPage.prototype.manageValidResult.call(this, rowToCheck);
			},

			//afterGetFormData
			
			beforeFill: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;

				if (appMeta.ssoPrms) {
					_.extend(parentRow, appMeta.ssoPrms);
					if (!parentRow.userkind) {
						// 5 sso, 4 ldap, 3 user + passweb
						parentRow.userkind =  appMeta.appMainConfig.ssoEnable ? 5 : (appMeta.appMainConfig.ldapEnabled ? 4 : 3);
					}
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-registrationuser_usr");
				var arraydef = [];
				
				//beforeFillInside
				
				$.when.apply($, arraydef)
					.then(function () {
						return self.superClass.beforeFill.call(self)
							.then(function () {
								return def.resolve();
							});
					});
				return def.promise();
			},

			//afterClear

			afterFill: function () {
				this.enableControl($('#registrationuser_usr_surname'), appMeta.appMainConfig.ldapEnabled);
				this.enableControl($('#registrationuser_usr_forename'), appMeta.appMainConfig.ldapEnabled);
				this.enableControl($('#registrationuser_usr_email'), false);
				this.enableControl($('#registrationuser_usr_login'), false);
				this.enableControl($('#registrationuser_usr_idregistrationuserstatus'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				var registrationuser = this.getDataTable("registrationuser");
				registrationuser.defaults(
					{
						'esercizio': (new Date()).getFullYear(),
						'idregistrationuserstatus' : 1,
						// TORNATO DAL SERVER negli ssoPrameters ---> 'userkind': appMeta.appMainConfig.ssoEnable ? 5 : (appMeta.appMainConfig.ldapEnabled ? 4 : 3)
					});

				this.setFilterRegistrationuser_usr_flowchart();
				$("#GiveAccess").on("click", _.partial(this.fireGiveAccess, this));
				$("#GiveAccess").prop("disabled", true);
				this.setDenyNull("registrationuser","cf");
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			//afterRowSelect

			//afterActivation

			rowSelected: function (dataRow) {
				$("#GiveAccess").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#GiveAccess").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			//insertClick

			//beforePost

			setFilterRegistrationuser_usr_flowchart: function () {
				var self = this;
				var filter = self.q.eq('ayear', (new Date()).getFullYear());
				self.state.DS.tables.flowchart.staticFilter(filter);
			},

			fireGiveAccess: function (that) {
				appMeta.ssoPrms = null;
				that.cmdMainSave()
					.then(function (res) {
						if (res) {
							return that.showMessageOk("Richiesta di registrazione inviata con successo! Attendi l'autorizzazione da parte di un amministratore e quindi riprova login sso");
						}
						return res;
					})
					.then(function (res) {
						if (res) {
							return that.cmdClose();
						}
					});
			},

			//buttons
        });

	window.appMeta.addMetaPage('registrationuser', 'usr', metaPage_registrationuser);

}());
