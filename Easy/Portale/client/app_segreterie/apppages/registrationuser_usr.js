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
				var def = appMeta.Deferred("isValid-registrationuser_usr");
				var firstErrorObj;

				if (rowToCheck.table.dataset.tables["registrationuserflowchart"] && rowToCheck.table.dataset.tables["registrationuserflowchart"].rows.length < 1) {
					firstErrorObj = { warningMsg: "", errMsg: loc.getMinNumRowRequired("Autorizzazioni richieste", 1), errField: "XXregistrationuserflowchart", row: rowToCheck };
					return def.resolve(firstErrorObj);
				}
//$isValidArray$
				if (rowToCheck.table.dataset.tables["registrationuser"] &&
					(!rowToCheck.current.surname ||
					 !rowToCheck.current.forename ||
					 !rowToCheck.current.cf
					)) {
					firstErrorObj = { warningMsg: "", errMsg: 'Inserisci i dati nome, cognome e codiceFiscale' , errField: "cf", row: rowToCheck };
					return def.resolve(firstErrorObj);
				}

				//$isValid$
				
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

			
			
			afterLink: function () {
				var self = this;
				this.setFilterRegistrationuser_usr_flowchart();
				this.state.DS.tables.registrationuser.defaults({ 'all_sorkind03': 'S' });
				this.state.DS.tables.registrationuser.defaults({ 'esercizio': (new Date()).getFullYear() });
				this.state.DS.tables.registrationuser.defaults({ 'flagdefault': 'N' });
				this.state.DS.tables.registrationuser.defaults({ 'idregistrationuserstatus': 1 });
				this.state.DS.tables.registrationuser.defaults({ 'requesttimestamp': new Date() });
				this.state.DS.tables.registrationuser.defaults({ 'start': new Date() });
				this.state.DS.tables.registrationuser.defaults({ 'userkind': appMeta.appMainConfig.ssoEnable ? 5 : (appMeta.appMainConfig.ldapEnabled ? 4 : 3) });
				$("#GiveAccess").on("click", _.partial(this.fireGiveAccess, this));
				$("#GiveAccess").prop("disabled", true);
				this.setDenyNull("registrationuser","cf");
				this.setDenyNull("registrationuser","idsor01");
				this.setDenyNull("registrationuser","idsor02");
				this.setDenyNull("registrationuser","idsor04");
				//indico al framework che la tabella uniconfig è cached
				var uniconfigTable = this.getDataTable("uniconfig");
				appMeta.metaModel.cachedTable(uniconfigTable, true);
				//indico al framework che la tabella sortingkind è cached
				var sortingkindTable = this.getDataTable("sortingkind");
				appMeta.metaModel.cachedTable(sortingkindTable, true);
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					arraydef.push(appMeta.getData.runSelectIntoTable(uniconfigTable, null, null));
					arraydef.push(appMeta.getData.runSelectIntoTable(sortingkindTable, null, null));
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

			//afterPost

			afterClear: function () {
				//parte sincrona
				this.setAttributes();
				this.enableControl($('#registrationuser_usr_email'), true);
				this.enableControl($('#registrationuser_usr_login'), true);
				this.enableControl($('#registrationuser_usr_idregistrationuserstatus'), true);
				this.enableControl($('#registrationuser_usr_requesttimestamp'), true);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			setFilterRegistrationuser_usr_flowchart: function () {
				var self = this;
				var filter = self.q.eq('ayear', (new Date()).getFullYear());
				self.state.DS.tables.flowchart.staticFilter(filter);
			},

			afterFill: function () {
				this.enableControl($('#registrationuser_usr_surname'), appMeta.appMainConfig.ldapEnabled);
				this.enableControl($('#registrationuser_usr_forename'), appMeta.appMainConfig.ldapEnabled);
				this.enableControl($('#registrationuser_usr_email'), false);
				this.enableControl($('#registrationuser_usr_login'), false);
				this.enableControl($('#registrationuser_usr_idregistrationuserstatus'), false);
				this.enableControl($('#registrationuser_usr_requesttimestamp'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			setAttributes: function () {
				var ds = this.state && this.state.DS;
				if (!ds || !ds.tables || !ds.tables.uniconfig || !ds.tables.sortingkind) return;

				var uniconfigRows = ds.tables.uniconfig.rows || [];
				var sortingkindRows = ds.tables.sortingkind.rows || [];

				if (!uniconfigRows.length) return;

				if (this.state.DS.tables.uniconfig.rows[0].idsorkind01)
					this.state.DS.tables.sortingusabledefaultview.staticFilter(window.jsDataQuery.and(this.q.eq("sortingusable_idsorkind", this.state.DS.tables.uniconfig.rows[0].idsorkind01), this.q.or(this.q.le("sortingusable_start", new Date().getFullYear()), this.q.isNull("sortingusable_start")), this.q.or(this.q.ge("sortingusable_stop", new Date().getFullYear()), this.q.isNull("sortingusable_stop"))));
				if (this.state.DS.tables.uniconfig.rows[0].idsorkind02)
					this.state.DS.tables.sortingusabledefaultview_alias1.staticFilter(window.jsDataQuery.and(this.q.eq("sortingusable_idsorkind", this.state.DS.tables.uniconfig.rows[0].idsorkind02), this.q.or(this.q.le("sortingusable_start", new Date().getFullYear()), this.q.isNull("sortingusable_start")), this.q.or(this.q.ge("sortingusable_stop", new Date().getFullYear()), this.q.isNull("sortingusable_stop"))));
				if (this.state.DS.tables.uniconfig.rows[0].idsorkind03)
					this.state.DS.tables.sortingusabledefaultview_alias2.staticFilter(window.jsDataQuery.and(this.q.eq("sortingusable_idsorkind", this.state.DS.tables.uniconfig.rows[0].idsorkind03), this.q.or(this.q.le("sortingusable_start", new Date().getFullYear()), this.q.isNull("sortingusable_start")), this.q.or(this.q.ge("sortingusable_stop", new Date().getFullYear()), this.q.isNull("sortingusable_stop"))));
				if (this.state.DS.tables.uniconfig.rows[0].idsorkind04)
					this.state.DS.tables.sortingusabledefaultview_alias3.staticFilter(window.jsDataQuery.and(this.q.eq("sortingusable_idsorkind", this.state.DS.tables.uniconfig.rows[0].idsorkind04), this.q.or(this.q.le("sortingusable_start", new Date().getFullYear()), this.q.isNull("sortingusable_start")), this.q.or(this.q.ge("sortingusable_stop", new Date().getFullYear()), this.q.isNull("sortingusable_stop"))));
				if (this.state.DS.tables.uniconfig.rows[0].idsorkind05)
					this.state.DS.tables.sortingusabledefaultview_alias4.staticFilter(window.jsDataQuery.and(this.q.eq("sortingusable_idsorkind", this.state.DS.tables.uniconfig.rows[0].idsorkind05), this.q.or(this.q.le("sortingusable_start", new Date().getFullYear()), this.q.isNull("sortingusable_start")), this.q.or(this.q.ge("sortingusable_stop", new Date().getFullYear()), this.q.isNull("sortingusable_stop"))));

				if (uniconfigRows[0].idsorkind01) {
					var riga = sortingkindRows.find(function (row) {
						return row.idsorkind == uniconfigRows[0].idsorkind01;
					});
					if (riga && riga.description) {
						appMeta.localization.registrationuser_usr_idsor01 = riga.description;
					}
				}
				else {
					var $primaRow = $('#registrationuser_usr_idsor01').closest('.row');
					$primaRow.hide();
				}

				if (uniconfigRows[0].idsorkind02) {
					var riga = sortingkindRows.find(function (row) {
						return row.idsorkind == uniconfigRows[0].idsorkind02;
					});
					if (riga && riga.description) {
						appMeta.localization.registrationuser_usr_idsor02 = riga.description;
					}
				}
				else {
					var $primaRow = $('#registrationuser_usr_idsor02').closest('.row');
					$primaRow.hide();
				}

				if (uniconfigRows[0].idsorkind03) {
					var riga = sortingkindRows.find(function (row) {
						return row.idsorkind == uniconfigRows[0].idsorkind03;
					});
					if (riga && riga.description) {
						appMeta.localization.registrationuser_usr_idsor03 = riga.description;
					}
				}
				else {
					var $primaRow = $('#registrationuser_usr_idsor03').closest('.row');
					$primaRow.hide();
				}

				if (uniconfigRows[0].idsorkind04) {
					var riga = sortingkindRows.find(function (row) {
						return row.idsorkind == uniconfigRows[0].idsorkind04;
					});
					if (riga && riga.description) {
						appMeta.localization.registrationuser_usr_idsor04 = riga.description;
					}
				}
				else {
					var $primaRow = $('#registrationuser_usr_idsor04').closest('.row');
					$primaRow.hide();
				}

				if (uniconfigRows[0].idsorkind05) {
					var riga = sortingkindRows.find(function (row) {
						return row.idsorkind == uniconfigRows[0].idsorkind05;
					});
					if (riga && riga.description) {
						appMeta.localization.registrationuser_usr_idsor05 = riga.description;
					}
				}
				else {
					var $primaRow = $('#registrationuser_usr_idsor05').closest('.row');
					$primaRow.hide();
				}

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
