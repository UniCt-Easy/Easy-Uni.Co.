(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_registrationuser() {
		MetaPage.apply(this, ['registrationuser', 'auth', false]);
        this.name = 'Richiesta di accesso';
		this.defaultListType = 'auth';
		this.canInsert = false;
		this.canInsertCopy = false;
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
				var def = appMeta.Deferred("isValid-registrationuser_auth");
				var firstErrorObj;

				if (rowToCheck.table.dataset.tables["registrationuserflowchart"] && rowToCheck.table.dataset.tables["registrationuserflowchart"].rows.length < 1) {
					firstErrorObj = { warningMsg: "", errMsg: loc.getMinNumRowRequired("Autorizzazioni richieste", 1), errField: "XXregistrationuserflowchart", row: rowToCheck };
					return def.resolve(firstErrorObj);
				}
//$isValidArray$
				//$isValid$
				
				return  MetaPage.prototype.manageValidResult.call(this, rowToCheck);
			},

			afterGetFormData: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				this.getCodesFlowChart();
				//afterGetFormDataFilter
				
				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-registrationuser_auth");
				var arraydef = [];
				
				//afterGetFormDataInside
				
				$.when.apply($, arraydef)
					.then(function () {
						return def.resolve();
					});
				return def.promise();
			},

			beforeFill: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				this.getCodesFlowChart();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-registrationuser_auth");
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

			
			afterFill: function () {
				this.enableControl($('#registrationuser_auth_surname'), false);
				this.enableControl($('#registrationuser_auth_forename'), false);
				this.enableControl($('#registrationuser_auth_cf'), false);
				this.enableControl($('#registrationuser_auth_email'), false);
				this.enableControl($('#registrationuser_auth_requesttimestamp'), false);
				this.enableControl($('#registrationuser_auth_idregistrationuserstatus'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				this.setFilterRegistrationuser_usr_flowchart();
				this.state.DS.tables.registrationuser.defaults({ 'esercizio': (new Date()).getFullYear() });
				this.state.DS.tables.registrationuser.defaults({ 'idregistrationuserstatus': 1 });
				this.state.DS.tables.registrationuser.defaults({ 'requesttimestamp': new Date() });
				this.state.DS.tables.registrationuser.defaults({ 'userkind': 5 });
				$("#GiveAccess").on("click", _.partial(this.fireGiveAccess, this));
				$("#GiveAccess").prop("disabled", true);
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
				this.enableControl($('#registrationuser_auth_surname'), true);
				this.enableControl($('#registrationuser_auth_forename'), true);
				this.enableControl($('#registrationuser_auth_cf'), true);
				this.enableControl($('#registrationuser_auth_email'), true);
				this.enableControl($('#registrationuser_auth_requesttimestamp'), true);
				this.enableControl($('#registrationuser_auth_idregistrationuserstatus'), true);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			setFilterRegistrationuser_usr_flowchart: function () {
				var self = this;
				var filter = self.q.eq('ayear', (new Date()).getFullYear());
				self.state.DS.tables.flowchart.staticFilter(filter);
			},

			getCodesFlowChart: function() {
				var registrationuserflowchart = this.getDataTable('registrationuserflowchart');
				var flowchart = this.getDataTable('flowchart');
				var codesFlowChart = [];
				if (registrationuserflowchart.rows && registrationuserflowchart.rows.length) {

					var notDeletedRows = _.filter(registrationuserflowchart.rows, function(r) {
						return r.getRow().state !== jsDataSet.dataRowState.deleted
					});

					if (notDeletedRows && notDeletedRows.length){
						_.forEach(notDeletedRows, function (r) {

							var idflowchart = r.idflowchart;
							var rowsFlowChart = _.filter(flowchart.rows, function(rflowChart) {
								return rflowChart.idflowchart === idflowchart;
							});
							if (rowsFlowChart.length) {
								codesFlowChart.push(rowsFlowChart[0].codeflowchart);
							}
						});
					}
				}
				return _.join(codesFlowChart, ';');
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
						appMeta.localization.registrationuser_auth_idsor01 = riga.description;
					}
				}
				else {
					var $primaRow = $('#registrationuser_auth_idsor01').closest('.row');
					var $secondaRow = $primaRow.next('.row');
					$primaRow.hide();
					$secondaRow.hide();
				}

				if (uniconfigRows[0].idsorkind02) {
					var riga = sortingkindRows.find(function (row) {
						return row.idsorkind == uniconfigRows[0].idsorkind02;
					});
					if (riga && riga.description) {
						appMeta.localization.registrationuser_auth_idsor02 = riga.description;
					}
				}
				else {
					var $primaRow = $('#registrationuser_auth_idsor02').closest('.row');
					var $secondaRow = $primaRow.next('.row');
					$primaRow.hide();
					$secondaRow.hide();
				}

				if (uniconfigRows[0].idsorkind03) {
					var riga = sortingkindRows.find(function (row) {
						return row.idsorkind == uniconfigRows[0].idsorkind03;
					});
					if (riga && riga.description) {
						appMeta.localization.registrationuser_auth_idsor03 = riga.description;
					}
				}
				else {
					var $primaRow = $('#registrationuser_auth_idsor03').closest('.row');
					var $secondaRow = $primaRow.next('.row');
					$primaRow.hide();
					$secondaRow.hide();
				}

				if (uniconfigRows[0].idsorkind04) {
					var riga = sortingkindRows.find(function (row) {
						return row.idsorkind == uniconfigRows[0].idsorkind04;
					});
					if (riga && riga.description) {
						appMeta.localization.registrationuser_auth_idsor04 = riga.description;
					}
				}
				else {
					var $primaRow = $('#registrationuser_auth_idsor04').closest('.row');
					var $secondaRow = $primaRow.next('.row');
					$primaRow.hide();
					$secondaRow.hide();
				}

				if (uniconfigRows[0].idsorkind05) {
					var riga = sortingkindRows.find(function (row) {
						return row.idsorkind == uniconfigRows[0].idsorkind05;
					});
					if (riga && riga.description) {
						appMeta.localization.registrationuser_auth_idsor05 = riga.description;
					}
				}
				else {
					var $primaRow = $('#registrationuser_auth_idsor05').closest('.row');
					var $secondaRow = $primaRow.next('.row');
					$primaRow.hide();
					$secondaRow.hide();
				}

			},

						fireGiveAccess: function (that) {
				var def = appMeta.Deferred("registerUser");
				// chiama la getFormData() per rinfrescare il Dataset con i dati inseriti sulla form.

				var waitingHandler = that.showWaitingIndicator(appMeta.localResource.modalLoader_wait_for_registration);

				that.getFormData(false)
					.then(function (res) {
						// salvo i dati se la getForm datata è ok
						var codeflowchart = that.getCodesFlowChart();
						if (!codeflowchart) {
							return that.showMessageOk('Seleziona almeno un profilo da associare all\'utente')
								.then(function () {
									that.hideWaitingIndicator(waitingHandler);
									return def.resolve();
								});
						}

						var msg = "";
						if (res) {
							return appMeta.callWebService("adminregisteruser",
								{
									login: $("#registrationuser_auth_login").val(),
									password: '',
									passwordweb: '',
									surname: $("#registrationuser_auth_surname").val(),
									forename: $("#registrationuser_auth_forename").val(),
									cf: $("#registrationuser_auth_cf").val(),
                                    email: $("#registrationuser_auth_email").val(),
									codeflowchart: codeflowchart,
									esercizio: (new Date()).getFullYear(),
									usertype: $("#registrationuser_auth_usertype option:selected").text(),
									matricola: $("#registrationuser_auth_matricola").val(),
									userkind : 5,
									idregistrationuser: that.state.currentRow.idregistrationuser,
									start: that.state.currentRow.start,
									stop: that.state.currentRow.stop,
									title: that.state.currentRow.title,
									flagdefault: that.state.currentRow.flagdefault,
									all_sorkind01: that.state.currentRow.all_sorkind01,
									all_sorkind02: that.state.currentRow.all_sorkind02,
									all_sorkind03: that.state.currentRow.all_sorkind03,
									all_sorkind04: that.state.currentRow.all_sorkind04,
									all_sorkind05: that.state.currentRow.all_sorkind05,
									idsor01: that.state.currentRow.idsor01,
									idsor02: that.state.currentRow.idsor02,
									idsor03: that.state.currentRow.idsor03,
									idsor04: that.state.currentRow.idsor04,
									idsor05: that.state.currentRow.idsor05,
									sorkind01_withchilds: that.state.currentRow.sorkind01_withchilds,
									sorkind02_withchilds: that.state.currentRow.sorkind02_withchilds,
									sorkind03_withchilds: that.state.currentRow.sorkind03_withchilds,
									sorkind04_withchilds: that.state.currentRow.sorkind04_withchilds,
									sorkind05_withchilds: that.state.currentRow.sorkind05_withchilds
								})
								.then(function (res) {
									var err  = res.err;
									msg = res.msg;
									// è andata a buon fine
									if (err === 0) {
										that.state.currentRow.idregistrationuserstatus = 2;
										that.state.currentRow.getRow().acceptChanges();
										msg = "Registrazione eseguita con successo. Utente autorizzato. <br><br>" + msg;
										return that.freshForm(true, false)
									}
									return true;
								}).then(function(){
									that.hideWaitingIndicator(waitingHandler);
									return that.showMessageOk(msg)
								}).then(function () {
									return def.resolve();
								});
						}
						that.hideWaitingIndicator(waitingHandler);
						return def.resolve();
					});

				return def.promise();
			},

			//buttons
        });

	window.appMeta.addMetaPage('registrationuser', 'auth', metaPage_registrationuser);

}());
