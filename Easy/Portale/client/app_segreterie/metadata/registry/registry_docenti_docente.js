(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_registry() {
		MetaPage.apply(this, ['registry', 'docenti_docente', false]);
        this.name = 'Dati personali';
		this.defaultListType = 'docenti_docente';
		this.searchEnabled = false;
		this.canInsert = false;
		this.canInsertCopy = false;
		this.canCancel = false;
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_registry.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_registry,
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
				
				if (self.isNullOrMinDate(parentRow.birthdate))
					parentRow.birthdate = new Date();
								_.forEach(this.getDataTable("rendicontaltro").rows, function (r) {
					var title = r.ore + ' ore';
					if(r.idrendicontaltrokind) {
						var tipoRows = self.getDataTable("rendicontaltrokind").select(self.q.eq('idrendicontaltrokind', r.idrendicontaltrokind));
						title += ' per ' + tipoRows[0].title;
					}
					r['!title'] = title;
				});				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_docenti_docente_idtitle'), null);
				} else {
					this.helpForm.filter($('#registry_docenti_docente_idtitle'), this.q.eq('active', 'S'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_docenti_docente_idregistryclass'), null);
				} else {
					this.helpForm.filter($('#registry_docenti_docente_idregistryclass'), this.q.eq('registryclass_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_docenti_docente_idstruttura'), null);
				} else {
					this.helpForm.filter($('#registry_docenti_docente_idstruttura'), this.q.eq('struttura_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_docenti_docente_idclassconsorsuale'), null);
				} else {
					this.helpForm.filter($('#registry_docenti_docente_idclassconsorsuale'), this.q.eq('classconsorsuale_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_docenti_docente_idreg_istituti'), null);
				} else {
					this.helpForm.filter($('#registry_docenti_docente_idreg_istituti'), this.q.eq('registry_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-registry_docenti_docente");
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

			afterClear: function () {
				//parte sincrona
				this.enableControl($('#registry_docenti_docente_extmatricula'), true);
				this.enableControl($('#registry_docenti_docente_idtitle'), true);
				this.helpForm.filter($('#registry_docenti_docente_idtitle'), null);
				this.enableControl($('#registry_docenti_docente_surname'), true);
				this.enableControl($('#registry_docenti_docente_forename'), true);
				this.enableControl($('#registry_docenti_docente_genderM'), true);
				this.enableControl($('#registry_docenti_docente_genderF'), true);
				this.enableControl($('#registry_docenti_docente_birthdate'), true);
				this.enableControl($('#registry_docenti_docente_idcity'), true);
				this.enableControl($('#registry_docenti_docente_idnation'), true);
				this.enableControl($('#registry_docenti_docente_cf'), true);
				this.enableControl($('#registry_docenti_docente_idmaritalstatus'), true);
				this.enableControl($('#registry_docenti_docente_p_iva'), true);
				this.enableControl($('#registry_docenti_docente_idregistryclass'), true);
				this.helpForm.filter($('#registry_docenti_docente_idregistryclass'), null);
				this.enableControl($('#registry_docenti_docente_residence'), true);
				this.enableControl($('#registry_docenti_docente_location'), true);
				this.enableControl($('#registry_docenti_docente_foreigncf'), true);
				this.enableControl($('#registry_docenti_docente_maritalsurname'), true);
				this.enableControl($('#registry_docenti_docente_soggiorno'), true);
				this.enableControl($('#registry_docenti_docente_idstruttura'), true);
				this.helpForm.filter($('#registry_docenti_docente_idstruttura'), null);
				this.enableControl($('#registry_docenti_docente_idsasd'), true);
				this.enableControl($('#registry_docenti_docente_idclassconsorsuale'), true);
				this.helpForm.filter($('#registry_docenti_docente_idclassconsorsuale'), null);
				this.enableControl($('#registry_docenti_docente_idreg_istituti'), true);
				this.helpForm.filter($('#registry_docenti_docente_idreg_istituti'), null);
				this.enableControl($('#registry_docenti_docente_idfonteindicebibliometrico'), true);
				this.enableControl($('#registry_docenti_docente_indicebibliometrico'), true);
				this.enableControl($('#registry_docenti_docente_activeSi'), true);
				this.enableControl($('#registry_docenti_docente_activeNo'), true);
				this.enableControl($('#registry_docenti_docente_idreg'), true);
				this.enableControl($('#registry_docenti_docente_badgecode'), true);
				this.enableControl($('#registry_docenti_docente_annotation'), true);
				this.enableControl($('#registry_docenti_docente_multi_cfSi'), true);
				this.enableControl($('#registry_docenti_docente_multi_cfNo'), true);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			
			afterLink: function () {
				var self = this;
				this.configureDependencies();
				this.state.DS.tables.registry.defaults({ 'extension': 'docenti' });
				this.state.DS.tables.registry.defaults({ 'idregistrykind': 8 });
				this.state.DS.tables.registry.defaults({ 'residence': 1 });
				$('.nav-tabs').on('shown.bs.tab', function (e) {
					$('#calendar61').fullCalendar('rerenderEvents');
				});
				$('.nav-tabs').on('shown.bs.tab', function (e) {
					$('#calendar62').fullCalendar('rerenderEvents');
				});
				$("#OpenScheduleConfig").on("click", _.partial(this.fireOpenScheduleConfig, this));
				$("#OpenScheduleConfig").prop("disabled", true);
				this.setDenyNull("registry","surname");
				this.setDenyNull("registry","forename");
				this.setDenyNull("registry","gender");
				this.setDenyNull("registry","birthdate");
				this.setDenyNull("registry","idcity");
				appMeta.metaModel.insertFilter(this.getDataTable("maritalstatus"), this.q.eq('active', 'S'));
				appMeta.metaModel.insertFilter(this.getDataTable("residence"), this.q.eq('active', 'S'));
				$('#grid_registrylegalstatus_default').data('mdlconditionallookup', 'flagdefault,S,Si;flagdefault,N,No;tempdef,S,Si;tempdef,N,No;tempindet,S,Si;tempindet,N,No;');
				$('#grid_progettotimesheet_datipersonali').data('mdlconditionallookup', 'multilinetype,S,Si;multilinetype,N,No;output,P,PDF;output,F,PDF firmato;output,X,Excel;');
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
				$("#OpenScheduleConfig").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#OpenScheduleConfig").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			//insertClick

			//beforePost

			//QUESTO COMMENTO SERVE AD EVITARE CHE L'ANTIVIRUS SCAMBI IL FILE PER UN VIRUS
			configureDependencies:function () {
				var p1 = $("input[data-tag='registry.surname?registrydocentiview.registry_surname']");
				var p2 = $("input[data-tag='registry.forename?registrydocentiview.registry_forename']");
				var f1 = $("input[data-tag='registry.title']");
                // funz di trasformazione
                var modifiesDenominazione = function (row) {
                    if (!row) return;
                    var vSurname = (row['surname'] === null || row['surname'] === undefined)  ? "" : row['surname']  ;
                    var vForename = (row['forename'] === null || row['forename'] === undefined)  ? "" : row['forename'] ;
                    return vSurname + " " + vForename.substring(0,49);
                };
                this.registerFormula(f1, modifiesDenominazione);

                this.addDependencies(p1, f1); 
                this.addDependencies(p2, f1);
            },

			afterFill: function () {
				this.enableControl($('#registry_docenti_docente_extmatricula'), false);
				this.enableControl($('#registry_docenti_docente_idtitle'), false);
				this.enableControl($('#registry_docenti_docente_surname'), false);
				this.enableControl($('#registry_docenti_docente_forename'), false);
				this.enableControl($('#registry_docenti_docente_genderM'), false);
				this.enableControl($('#registry_docenti_docente_genderF'), false);
				this.enableControl($('#registry_docenti_docente_birthdate'), false);
				this.enableControl($('#registry_docenti_docente_idcity'), false);
				this.enableControl($('#registry_docenti_docente_idnation'), false);
				this.enableControl($('#registry_docenti_docente_cf'), false);
				this.enableControl($('#registry_docenti_docente_idmaritalstatus'), false);
				this.enableControl($('#registry_docenti_docente_p_iva'), false);
				this.enableControl($('#registry_docenti_docente_idregistryclass'), false);
				this.enableControl($('#registry_docenti_docente_residence'), false);
				this.enableControl($('#registry_docenti_docente_location'), false);
				this.enableControl($('#registry_docenti_docente_foreigncf'), false);
				this.enableControl($('#registry_docenti_docente_maritalsurname'), false);
				this.enableControl($('#registry_docenti_docente_soggiorno'), false);
				this.enableControl($('#registry_docenti_docente_idstruttura'), false);
				this.enableControl($('#registry_docenti_docente_idsasd'), false);
				this.enableControl($('#registry_docenti_docente_idclassconsorsuale'), false);
				this.enableControl($('#registry_docenti_docente_idreg_istituti'), false);
				this.enableControl($('#registry_docenti_docente_idfonteindicebibliometrico'), false);
				this.enableControl($('#registry_docenti_docente_indicebibliometrico'), false);
				this.enableControl($('#registry_docenti_docente_activeSi'), false);
				this.enableControl($('#registry_docenti_docente_activeNo'), false);
				this.enableControl($('#registry_docenti_docente_idreg'), false);
				this.enableControl($('#registry_docenti_docente_badgecode'), false);
				this.enableControl($('#registry_docenti_docente_annotation'), false);
				this.enableControl($('#registry_docenti_docente_multi_cfSi'), false);
				this.enableControl($('#registry_docenti_docente_multi_cfNo'), false);
				//afterFillin

				var self = this;
				if (!this.isEmpty()) {
					// carica tutte le attività dell'utente. seve per visualizzarle sul calendario
					var filter = self.q.and(
						self.q.eq("idreg", this.state.currentRow.idreg),
						self.q.eq("idsospensione",0)
					);
					return this.getExternalEventForCalendar(filter, $("[data-tag='sospensione.default.default']")).then( function(){
						// carica tutte le attività dell'utente. seve per visualizzarle sul calendario
						filter = self.q.and(
							self.q.eq("idreg", self.state.currentRow.idreg),
							self.q.eq("idrendicontaltro", 0)
						);
						return self.getExternalEventForCalendar(filter, $("[data-tag='rendicontaltro.docente.docente']")).then( function(){
							return MetaPage.prototype.afterFill.call(self);
						});
					});
				}
				return MetaPage.prototype.afterFill.call(this);
			},

			fireOpenScheduleConfig: function (that) {
				if (!that.state.currentRow.idreg)
					return that.showMessageOk('Occorre indicare chi svolge l\'attività e salvare');

				const today = new Date(); // Data corrente
				const start = new Date(today.getFullYear() - 1, today.getMonth(), today.getDate());
				const stop = new Date(today.getFullYear() + 1, today.getMonth(), today.getDate());

				let maxHoursPerDayTable = null;
				let idreg = that.state.currentRow.idreg;
				let filter = that.q.and([
					that.q.eq("idreg", idreg),
					that.q.or(that.q.isNull("start"), that.q.le("start", start)),
					that.q.or(that.q.isNull("stop"), that.q.ge("stop", stop))
				]);
				appMeta.getData.runSelect("getoremaxgg", "*", filter, null)
					.then(function (dt) {
						maxHoursPerDayTable = dt;
						return that.getFormData(true);
					}).then(function () {
						var scheduler = new appMeta.scheduleConfig(that,
							{
								endDate: stop,
								minDateValue: start,
								maxHours: 1500, //massimo ore lavorabili per docente per anno
								tableNameSchedule: 'rendicontaltro',
								columnDate: 'data',
								columnOre: 'ore',
								columnTitle: '!title',
								columnTitleValue: "schedulazione",
								calendarTag: "rendicontaltro.docente.docente",
								maxHoursPerDayTable: maxHoursPerDayTable,
								chooseKind: true
							});
						return scheduler.show();
					});
			},

			//buttons
        });

	window.appMeta.addMetaPage('registry', 'docenti_docente', metaPage_registry);

}());
