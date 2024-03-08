(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_progettotimesheet() {
		MetaPage.apply(this, ['progettotimesheet', 'default', true]);
        this.name = 'Timesheets';
		this.defaultListType = 'default';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_progettotimesheet.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_progettotimesheet,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			beforeFill: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				if (this.isNull(parentRow.collapseteachingother) || parentRow.collapseteachingother == '')
					parentRow.collapseteachingother = "S";
				if (this.isNull(parentRow.intestazioneallsheet) || parentRow.intestazioneallsheet == '')
					parentRow.intestazioneallsheet = 'N';
				if (this.isNull(parentRow.multilinetype) || parentRow.multilinetype == '')
					parentRow.multilinetype = 'N';
				if (this.isNull(parentRow.output) || parentRow.output == '')
					parentRow.output = 'P';
				if (this.isNull(parentRow.riepilogoanno) || parentRow.riepilogoanno == '')
					parentRow.riepilogoanno = 'S';
				if (this.isNull(parentRow.showactivitiesrow) || parentRow.showactivitiesrow == '')
					parentRow.showactivitiesrow = 'S';
				if (this.isNull(parentRow.showotheractivitiesrow) || parentRow.showotheractivitiesrow == '')
					parentRow.showotheractivitiesrow = 'N';
				if (this.isNull(parentRow.withworkpackage) || parentRow.withworkpackage == '')
					parentRow.withworkpackage = 'S';
				if (this.isNull(parentRow.year))
					parentRow.year = new Date().getFullYear();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-progettotimesheet_default");
				var arraydef = [];
				
				arraydef.push(this.projectGridfilter());				//beforeFillInside
				
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

			//afterFill

			
			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-progettotimesheet_default");
				if (t.name === "year" && r !== null) {
					return this.manageyear(this).then(function () {
						return def.resolve();
					});
				}
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			rowSelected: function (dataRow) {
				$("#timesheetReport").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#timesheetReport").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			//insertClick

			//beforePost

			projectGridfilter: function () {
				this.currentYearSearch = this.state.currentRow.year;
				var self = this;
				var def = appMeta.Deferred("projectGridfilter");
				if (this.lastYearSearch != this.currentYearSearch) {
					this.lastYearSearch = this.currentYearSearch
					//costruzione filtro per determinare i progetti coinvolti
					var filter = self.q.eq("idreg", self.state.currentRow.idreg);
					if (self.state.currentRow.year) {
						filter = self.q.and(self.q.eq("anno", self.state.currentRow.year), filter);
					}
					//query su timesheetview con il filtro calcolato
					appMeta.getData.runSelect("timesheetview", "idprogetto", filter)
						.then(function (dt) {
							//id dei progetti dell'utente e dell'anno selezionato
							var progettiRows = _.filter(dt.rows, function (r) { return !!r.idprogetto });
							var filterProgetti = self.q.isIn('idprogetto',
								_.map(progettiRows, function (r) {
									return r.idprogetto;
								}));
							self.getDataTable('progetto').clear();
							var selBuilderArray = [];
							//faccio la query su sql e aggiorno contemporaneamente il dataset
							selBuilderArray.push({ filter: filterProgetti, top: null, tableName: 'progetto', table: self.getDataTable('progetto') });
							return appMeta.getData.multiRunSelect(selBuilderArray);
						})
						.then(function () {
							return def.resolve();
						});
					return def.promise();
				}
				else {
					return def.resolve();
				}
			},
			
			afterLink: function () {
				var self = this;
				//indico al framework che la tabella progetto non va caricata tutta ma per ora con solo i progetti già selezionati
				this.getDataTable("progetto").staticFilter(this.q.isIn('idprogetto',
					_.map(this.state.callerState.DS.tables.progettotimesheetprogetto.rows, function (r) {
						return r.idprogetto;
					})));
				$("#timesheetReport").on("click", _.partial(this.firetimesheetReport, this));
				$("#timesheetReport").prop("disabled", true);
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					arraydef.push(self.filterProgettiIniziale());
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			filterProgettiIniziale: function () {
				var self = this;
				var def = appMeta.Deferred("filterMembri");
				//recupero tutti i progetti  dove...
				var filter = 
					//...sono membro
					this.q.eq('idreg_membro', self.state.callerState.currentRow.idreg);

				appMeta.getData.runSelect("progettoresponsabiliview", "idreg, idreg_membro, idprogetto", filter)
					.then(function (dt) {

						//filtro i progetti ...
						self.state.DS.tables.progettoelenchiview.staticFilter(
							self.q.isIn('idprogetto', _.map(dt.rows, function (r) {
								//...vanno bene tutti perchè potrei fare timesheet per me (righe in cui sono membro) oppure per quelli di cui sono responsabile (righe in cui sono responsabile)
								return r.idprogetto;
							}))
						);
						return def.resolve();
					});
			},

			firetimesheetReport: function (that) {
				return that.getFormData(true)
					.then(function () {
						var row = that.state.currentRow;
						if (!row) {
							return that.showMessageOk("Seleziona un docente!");
						}
						// tabella di collegamento dove ci sono i progetti selezionati che devono finire nel timesheet
						var dt = that.getDataTable('progettotimesheetprogetto');
						var rows = dt.rows.filter(function (r) {
							return r.getRow && r.getRow().state !== jsDataSet.dataRowState.deleted
						});
						if (!rows.length) {
							return that.showMessageOk("Seleziona almeno un progetto!");
						}
						var filterProgetti = that.q.isIn('idprogetto', _.map(rows, function (r) {
							return r.idprogetto;
						}));
						var showactivitiesrow = (row.showactivitiesrow === 'S');
						var showotheractivitiesrow = (row.showotheractivitiesrow=== 'S');
						var riepilogoanno = (row.riepilogoanno === 'S');
						var intestazioneallsheet = (row.intestazioneallsheet === 'S');
						var withWorkpackage = (row.withworkpackage === 'S');
						var multilineType = (row.multilinetype === 'S');
						var collapseteachingother = (row.collapseteachingother === 'S');
						return that.buildAndGetTimesheet({
							filterProgetti: filterProgetti,
							idreg: row.idreg,
							year: row.year,
							showactivitiesrow: showactivitiesrow,
							showOtherActivitiesrow: showotheractivitiesrow ,
							riepilogoanno: riepilogoanno,
							intestazioneallsheet: intestazioneallsheet,
							idtimesheettemplate: row.idtimesheettemplate,
							withWorkpackage: withWorkpackage,
							idprogetto: progettoPrincipale,
							output: row.output,
							mese: row.idmese,
							idsal: row.idsal,
							metaPage: that,
							multilineType: multilineType,
							collapseteachingother: collapseteachingother
						});
					});
			},

			manageyear: function(that) { 
				var def = appMeta.Deferred("manageYearfilter");
				var waitingHandler = that.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);
				var grid_progettotimesheetprogetto_defaultCtrl = $('#grid_progettotimesheetprogetto_default').data("customController");

				//faccio una sorta di getFormData puntuale perchè facendo quello vero cancellerei i record da progettotimesheetprogetto
				that.state.currentRow.year = parseInt($('#progettotimesheet_default_year').val());

				return that.projectGridfilter()
					.then(function () {
						//ripulisco la checkbox dei progetti
						return grid_progettotimesheetprogetto_defaultCtrl.clearControl();
					})
					.then(function () {
						//faccio il fill control della checkbox dei progetti
						return grid_progettotimesheetprogetto_defaultCtrl.fillControl($('#grid_progettotimesheetprogetto_default'));
					})

					.then(function () {
						that.hideWaitingIndicator(waitingHandler);
						return def.resolve();
					});
				return def.promise();

			},

			//buttons
        });

	window.appMeta.addMetaPage('progettotimesheet', 'default', metaPage_progettotimesheet);

}());
