(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_rendicontattivitaprogetto() {
		MetaPage.apply(this, ['rendicontattivitaprogetto', 'seg', true]);
        this.name = 'Attività';
		this.defaultListType = 'seg';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_rendicontattivitaprogetto.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_rendicontattivitaprogetto,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			afterGetFormData: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				//afterGetFormDataFilter
				
				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-rendicontattivitaprogetto_seg");
				var arraydef = [];
				
				arraydef.push(this.managerendicontattivitaprogetto_seg_titolobreve());
				arraydef.push(this.managerendicontattivitaprogetto_seg_raggruppamento());
				arraydef.push(this.managerendicontattivitaprogetto_seg_wp());
				arraydef.push(this.managerendicontattivitaprogetto_seg_orerendicont());
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
				
				if (this.isNull(parentRow.datainizioprevista))
					parentRow.datainizioprevista = this.state.callerState.currentRow.start;
				if (self.isNullOrMinDate(parentRow.datainizioprevista))
					parentRow.datainizioprevista = new Date();
				if (this.isNull(parentRow.idrendicontattivitaprogettokind))
					parentRow.idrendicontattivitaprogettokind = 1;
				if (this.isNull(parentRow.stop))
					parentRow.stop = this.state.callerState.currentRow.stop;
				if (self.isNullOrMinDate(parentRow.stop))
					parentRow.stop = new Date();
								var that = this;
				_.forEach(this.getDataTable("rendicontattivitaprogettoora").rows, function (r) {
					var progettoTitle = that.state.callerState.callerState.currentRow.title;
					var workpageTitle = that.state.callerState.currentRow.title;
					var rendicontattivitaprogettoTitle = that.state.currentRow.description;

					var p = [];
					p.push([r.ore, null, 'Ore']);
					p.push([progettoTitle, null, 'Progetto']);
					p.push([workpageTitle, null, 'Workpackage']);
					p.push([rendicontattivitaprogettoTitle, null, 'Attività']);
					r['!titleancestor'] = that.stringify(p, 'string');
				});
				this.managerendicontattivitaprogetto_seg_titolobreve();
				this.managerendicontattivitaprogetto_seg_raggruppamento();
				this.managerendicontattivitaprogetto_seg_wp();
				this.managerendicontattivitaprogetto_seg_orerendicont();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-rendicontattivitaprogetto_seg");
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
				this.enableControl($('#rendicontattivitaprogetto_seg_titolobreve'), true);
				this.enableControl($('#rendicontattivitaprogetto_seg_raggruppamento'), true);
				this.enableControl($('#rendicontattivitaprogetto_seg_wp'), true);
				this.enableControl($('#rendicontattivitaprogetto_seg_orerendicont'), true);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('rendicontattivitaprogetto'), this.getDataTable('rendicontattivitaprogettoitineration'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('rendicontattivitaprogetto'), this.getDataTable('rendicontattivitaprogettoyear'));
				//afterClearin
				
				//afterClearInAsyncBase
			},

			
			
			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-rendicontattivitaprogetto_seg");
				$('#rendicontattivitaprogetto_seg_idreg').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idreg);
				$('#rendicontattivitaprogetto_seg_idreg').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idreg);
				if (t.name === "getregistrydocentiamministratividefaultview" && r !== null) {
					return this.manageidreg(this).then(function () {
						return def.resolve();
					});
				}
				//afterRowSelectin
				return def.resolve();
			},

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


			insertClick: function (that, grid) {
				if (!$('#rendicontattivitaprogetto_seg_idreg').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Partecipante');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			beforePost: function () {
				var self = this;
				this.getDataTable('rendicontattivitaprogettowpview').acceptChanges();
				//innerBeforePost
			},

			afterLink: function () {
				var self = this;
				this.setFilterRendicontattivitaprogettoItineration();
				this.setFilterRendicontattivitaprogetto_seg_idreg();
				$('.nav-tabs').on('shown.bs.tab', function (e) {
					$('#calendar18').fullCalendar('rerenderEvents');
				});
				$("#OpenScheduleConfig").on("click", _.partial(this.fireOpenScheduleConfig, this));
				$("#OpenScheduleConfig").prop("disabled", true);
				this.setDenyNull("rendicontattivitaprogetto","orepreventivate");
				this.setDenyNull("rendicontattivitaprogetto","datainizioprevista");
				this.setDenyNull("rendicontattivitaprogetto","stop");
				appMeta.metaModel.insertFilter(this.getDataTable("rendicontattivitaprogettokinddefaultview"), this.q.eq('rendicontattivitaprogettokind_active', 'Si'));
				$('#rendicontattivitaprogetto_seg_datainizioprevista').on("change", _.partial(this.managedatainizioprevista, self));
				$('#rendicontattivitaprogetto_seg_stop').on("change", _.partial(this.managestop, self));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			setFilterRendicontattivitaprogetto_seg_idreg: function () {
				var self = this;
				var filter = self.q.isIn('idreg',
					_.map(self.state.callerState.callerPage.getDataTable("progettoudrmembro").rows, function (r) { return r.idreg; })
				);
				self.state.DS.tables.getregistrydocentiamministratividefaultview.staticFilter(filter);
			},

			afterFill: function () {
				this.enableControl($('#rendicontattivitaprogetto_seg_titolobreve'), false);
				this.enableControl($('#rendicontattivitaprogetto_seg_raggruppamento'), false);
				this.enableControl($('#rendicontattivitaprogetto_seg_wp'), false);
				this.enableControl($('#rendicontattivitaprogetto_seg_orerendicont'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('rendicontattivitaprogetto'), this.getDataTable('rendicontattivitaprogettoitineration'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('rendicontattivitaprogetto'), this.getDataTable('rendicontattivitaprogettoyear'));
				//afterFillin

				var self = this;
				if (!this.isEmpty()) {
					if (this.state.currentRow.idreg && this.state.currentRow.idrendicontattivitaprogetto) {
						// carica tutte le attività dell'utente. seve per visualizzarle sul calendario
						var filter = self.q.and(
							self.q.eq("idreg", this.state.currentRow.idreg),
							self.q.ne("idrendicontattivitaprogetto", this.state.currentRow.idrendicontattivitaprogetto)
						);
						return this.getExternalEventForCalendar(filter, $("[data-tag='rendicontattivitaprogettoora.seg.seg']")).then(function () {
							return MetaPage.prototype.afterFill.call(self);
						});
					}
					return MetaPage.prototype.afterFill.call(this);
				}
				return MetaPage.prototype.afterFill.call(this);
			},

			fireOpenScheduleConfig: function (that) {
				if (!that.state.currentRow.idreg)
					return that.showMessageOk('Occorre indicare chi svolge l\'attività e salvare');
				let datafine = that.getRealStopForSchedulingResearchActivity();
				if (!datafine)
					return that.showMessageOk('Occorre indicare la data di fine attività e salvare');
				let datainizio = that.getRealStartForSchedulingResearchActivity();
				if (!datainizio)
					return that.showMessageOk('Occorre indicare la data di inizio attività e salvare');
				let maxHoursPerDayTable = null;
				let idreg = that.state.currentRow.idreg;
				let filter = that.q.and([
					that.q.eq("idreg", idreg),
					that.q.or(that.q.isNull("start"), that.q.le("start", datafine)),
					that.q.or(that.q.isNull("stop"), that.q.ge("stop", datainizio))
				]);
				appMeta.getData.runSelect("getoremaxgg" , "*" , filter, null)
					.then(function (dt) {
						maxHoursPerDayTable = dt;
						return that.getFormData(true);
					}).then(function () {
							var progettoTitle = that.state.callerState.callerState.currentRow.title;
							var workpageTitle = that.state.callerState.currentRow.title;
							var rendicontattivitaprogettoTitle = that.state.currentRow.description;

						if (!that.state.currentRow.description) {
							if (that.state.currentRow.idrendicontattivitaprogettokind)
								that.state.currentRow.description = that.state.DS.tables.rendicontattivitaprogettokinddefaultview.select(that.q.eq("idrendicontattivitaprogettokind", that.state.currentRow.idrendicontattivitaprogettokind))[0].title;
							else
								that.state.currentRow.description = '-';
						}
							if (!that.state.currentRow.orepreventivate
								|| !that.state.currentRow.idprogetto
								|| !progettoTitle
								|| !workpageTitle
								|| !that.state.currentRow.idworkpackage) return that.showMessageOk(that.localResource.scheduler_fields_mandatory_msg1);

							var p = [];
							p.push([progettoTitle, null, 'Progetto']);
							p.push([workpageTitle, null, 'Workpackage']);
							p.push([rendicontattivitaprogettoTitle, null, 'Attività']);
							var columnTitleValue = that.stringify(p, 'string');
							var scheduler = new appMeta.scheduleConfig(that,
								{
									endDate: datafine,
									minDateValue: datainizio,
									maxHours: that.state.currentRow.orepreventivate,
									tableNameSchedule: 'rendicontattivitaprogettoora',
									columnDate: 'data',
									columnOre: 'ore',
									columnTitle : '!titleancestor',
									columnTitleValue : columnTitleValue,
									calendarTag : "rendicontattivitaprogettoora.seg.seg",
									maxHoursPerDayTable : maxHoursPerDayTable
								});
							return scheduler.show();
						});
			},

			managerendicontattivitaprogetto_seg_titolobreve: function () {
				this.state.currentRow['!titolobreve'] = this.state.callerState.callerState.currentRow.titolobreve;
			},

			managerendicontattivitaprogetto_seg_raggruppamento: function () {
				this.state.currentRow['!raggruppamento'] = this.state.callerState.currentRow.raggruppamento;
			},

			managerendicontattivitaprogetto_seg_wp: function () {
				this.state.currentRow['!wp'] = this.state.callerState.currentRow.title;
			},

			managerendicontattivitaprogetto_seg_orerendicont: function () {
				this.state.currentRow['!orerendicont'] = _.sumBy(this.getDataTable('rendicontattivitaprogettoora').rows, function (r) {
					return r.ore;
				});
			},

			children: ['rendicontattivitaprogettoitineration', 'rendicontattivitaprogettoora', 'rendicontattivitaprogettowpview', 'rendicontattivitaprogettoyear'],
			haveChildren: function () {
				var self = this;
				return _.some(this.children, function (child) {
					if (child !== '')
						return !!self.getDataTable(child).rows.length;
					else
						return false;
				});
			},

			managedatainizioprevista: function(that) { 
				//inizio controllo intervallo date

				if (!$("#rendicontattivitaprogetto_seg_datainizioprevista").val()) {
					return;
				}
				
				var tempDate = $("#rendicontattivitaprogetto_seg_datainizioprevista").val();
				let tempStart = that.getDateTimeFromString(tempDate);

				let wpStop = that.state.callerState.currentRow.stop;
				let wpStart = that.state.callerState.currentRow.start;
				let membroStart = null;
				let membroStop = null;
				if (that.Membro) {
					membroStart = that.Membro.start;
					membroStop = that.Membro.stop;
				}
				that.setRealStartStop(wpStart, wpStop, membroStart, membroStop, that.lastProroga);

				if (that.start) {
					if (that.start > tempStart) {
						$("#rendicontattivitaprogetto_seg_datainizioprevista").val(that.stringFromDate_ddmmyyyy(that.start));
						return that.showMessageOk('La data di inizio dell\'attività deve essere successiva ' + that.startMessage);
					}
				}

				if (that.stop) {
					if (that.stop < tempStart) {
						$("#rendicontattivitaprogetto_seg_datainizioprevista").val(that.stringFromDate_ddmmyyyy(that.stop));
						return that.showMessageOk('La data di inizio dell\'attività deve essere precedente ' + that.stopMessage);
					}
				}

				if ($("#rendicontattivitaprogetto_seg_stop").val() && that.getDateTimeFromString($("#rendicontattivitaprogetto_seg_stop").val()) < tempStart) {
					$("#rendicontattivitaprogetto_seg_datainizioprevista").val($("#rendicontattivitaprogetto_seg_stop").val());
					return that.showMessageOk('La data di inizio dell\'attività deve essere precedente a quella finale');
				}
				//fine controllo intervallo date

				that.setFilterRendicontattivitaprogettoItineration();
			},

			manageidreg: function(that) { 
				//mini getformdata necessario
				that.state.currentRow.idreg = parseInt($("#rendicontattivitaprogetto_seg_idreg").val())

				that.lastProroga = that.state.callerState.callerState.DS.tables.progettoproroga.rows.length ?
					_.orderBy(that.state.callerState.callerState.DS.tables.progettoproroga.rows, 'proroga', 'desc')[0] : null;
				that.Membro = that.state.callerState.callerState.DS.tables.progettoudrmembro.rows.length ?
					_.orderBy(that.state.callerState.callerState.DS.tables.progettoudrmembro
						.select(that.q.and(that.q.eq("idprogetto", that.state.currentRow.idprogetto), that.q.eq("idreg", that.state.currentRow.idreg))
						), 'stop', 'desc')[0] : null;

				return that.setFilterRendicontattivitaprogettoItineration();
			},

			managestop: function(that) { 
				//inizio controllo intervallo date
				if (!$("#rendicontattivitaprogetto_seg_stop").val()) {
					return;
				}				
				var tempDate = $("#rendicontattivitaprogetto_seg_stop").val();
				let tempStop = that.getDateTimeFromString(tempDate);

				let wpStop = that.state.callerState.currentRow.stop;
				let wpStart = that.state.callerState.currentRow.start;
				let membroStart = null;
				let membroStop = null;
				if (that.Membro) {
					membroStart = that.Membro.start;
					membroStop = that.Membro.stop;
				}
				that.setRealStartStop(wpStart, wpStop, membroStart, membroStop, that.lastProroga);

				if (that.start) {
					if (that.start > tempStop) {
						$("#rendicontattivitaprogetto_seg_stop").val(that.stringFromDate_ddmmyyyy(that.start));
						return that.showMessageOk('La data di fine dell\'attività deve essere successiva ' + that.startMessage);
					}
				}

				if (that.stop) {
					if (that.stop < tempStop) {
						$("#rendicontattivitaprogetto_seg_stop").val(that.stringFromDate_ddmmyyyy(that.stop));
						return that.showMessageOk('La data di fine dell\'attività deve essere precedente ' + that.stopMessage);
					}
				}

				if ($("#rendicontattivitaprogetto_seg_datainizioprevista").val() && that.getDateTimeFromString($("#rendicontattivitaprogetto_seg_datainizioprevista").val()) > tempStop) {
					$("#rendicontattivitaprogetto_seg_stop").val($("#rendicontattivitaprogetto_seg_datainizioprevista").val());
					return that.showMessageOk('La data finale dell\'attività deve essere successiva a quella iniziale');
				}
				//fine controllo intervallo date
                               
				that.setFilterRendicontattivitaprogettoItineration();
			},

			//buttons
        });

	window.appMeta.addMetaPage('rendicontattivitaprogetto', 'seg', metaPage_rendicontattivitaprogetto);

}());
