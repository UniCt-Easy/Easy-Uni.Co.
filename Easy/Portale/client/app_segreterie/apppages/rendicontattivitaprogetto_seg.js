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

			manageValidResult: function (rowToCheck) {
				var loc = appMeta.localResource;
				var def = appMeta.Deferred("isValid-meta_rendicontattivitaprogetto");
				var firstErrorObj;

				let wpStop = this.state.callerState.currentRow.stop;
				let wpStart = this.state.callerState.currentRow.start;

				let progettoStop = this.state.callerState.callerState.currentRow.stop;
				let progettoStart = this.state.callerState.callerState.currentRow.start;

				let membroStart = null;
				let membroStop = null;
				if (this.Membro) {
					membroStart = this.Membro.start;
					membroStop = this.Membro.stop;
				}
				this.setRealStartStop(wpStart, wpStop, membroStart, membroStop, this.lastProroga, progettoStart, progettoStop);

				let tempStart = this.state.currentRow.datainizioprevista;
				let tempStop = this.state.currentRow.stop;

				if (this.start) {
					if (this.start > tempStart) {
						$("#rendicontattivitaprogetto_seg_datainizioprevista").val(this.stringFromDate_ddmmyyyy(this.start));
						firstErrorObj = {
							warningMsg: "",
							errMsg: 'La data di inizio dell\'attività deve essere successiva ' + this.startMessage,
							outCaption: 'Data inizio prevista',
							errField: 'datainizioprevista',
							row: rowToCheck
						};
						return def.resolve(firstErrorObj).then(MetaPage.prototype.manageValidResult.call(this, rowToCheck));
					}
				}

				if (this.stop) {
					if (this.stop < tempStart) {
						$("#rendicontattivitaprogetto_seg_datainizioprevista").val(this.stringFromDate_ddmmyyyy(this.stop));
						firstErrorObj = {
							warningMsg: "",
							errMsg: 'La data di inizio dell\'attività deve essere precedente ' + this.stopMessage,
							outCaption: 'Data inizio prevista',
							errField: 'datainizioprevista',
							row: rowToCheck
						};
						return def.resolve(firstErrorObj).then(MetaPage.prototype.manageValidResult.call(this, rowToCheck));
					}
				}

				if ($("#rendicontattivitaprogetto_seg_stop").val() && this.getDateTimeFromString($("#rendicontattivitaprogetto_seg_stop").val()) < tempStart) {
					$("#rendicontattivitaprogetto_seg_datainizioprevista").val($("#rendicontattivitaprogetto_seg_stop").val());
					firstErrorObj = {
						warningMsg: "",
						errMsg: 'La data di inizio dell\'attività deve essere precedente a quella finale',
						outCaption: 'Data inizio prevista',
						errField: 'datainizioprevista',
						row: rowToCheck
					};
					return def.resolve(firstErrorObj).then(MetaPage.prototype.manageValidResult.call(this, rowToCheck));

				}

				if (this.oraStart) {
					if (this.oraStart < tempStart) {
						$("#rendicontattivitaprogetto_seg_datainizioprevista").val(this.stringFromDate_ddmmyyyy(this.oraStart));

						firstErrorObj = {
							warningMsg: "",
							errMsg: 'La data di inizio della attività deve essere precedente ' + this.oraStartMessage,
							outCaption: 'Data inizio prevista',
							errField: 'datainizioprevista',
							row: rowToCheck
						};
						return def.resolve(firstErrorObj).then(MetaPage.prototype.manageValidResult.call(this, rowToCheck));

					}
				}

				if (this.start) {
					if (this.start > tempStop) {
						$("#rendicontattivitaprogetto_seg_stop").val(this.stringFromDate_ddmmyyyy(this.start));
						firstErrorObj = {
							warningMsg: "",
							errMsg: 'La data di fine dell\'attività deve essere successiva ' + this.startMessage,
							outCaption: 'Data fine prevista',
							errField: 'stop',
							row: rowToCheck
						};
						return def.resolve(firstErrorObj).then(MetaPage.prototype.manageValidResult.call(this, rowToCheck));
					}
				}

				if (this.stop) {
					if (this.stop < tempStop) {
						$("#rendicontattivitaprogetto_seg_stop").val(this.stringFromDate_ddmmyyyy(this.stop));
						firstErrorObj = {
							warningMsg: "",
							errMsg: 'La data di fine dell\'attività deve essere precedente ' + this.stopMessage,
							outCaption: 'Data fine prevista',
							errField: 'stop',
							row: rowToCheck
						};
						return def.resolve(firstErrorObj).then(MetaPage.prototype.manageValidResult.call(this, rowToCheck));
					}
				}

				if ($("#rendicontattivitaprogetto_seg_datainizioprevista").val() && this.getDateTimeFromString($("#rendicontattivitaprogetto_seg_datainizioprevista").val()) > tempStop) {
					$("#rendicontattivitaprogetto_seg_stop").val($("#rendicontattivitaprogetto_seg_datainizioprevista").val());
					firstErrorObj = {
						warningMsg: "",
						errMsg: 'La data finale dell\'attività deve essere successiva a quella iniziale',
						outCaption: 'Data fine prevista',
						errField: 'stop',
						row: rowToCheck
					};
					return def.resolve(firstErrorObj).then(MetaPage.prototype.manageValidResult.call(this, rowToCheck));
				}

				if (this.oraStop) {
					if (this.oraStop > tempStop) {
						$("#rendicontattivitaprogetto_seg_stop").val(this.stringFromDate_ddmmyyyy(this.oraStop));
						firstErrorObj = {
							warningMsg: "",
							errMsg: 'La data di fine della attività deve essere successiva ' + this.oraStopMessage,
							outCaption: 'Data fine prevista',
							errField: 'stop',
							row: rowToCheck
						};
						return def.resolve(firstErrorObj).then(MetaPage.prototype.manageValidResult.call(this, rowToCheck));
					}
				}


				def.resolve(true);
				//$isValid$

				return MetaPage.prototype.manageValidResult.call(this, rowToCheck);
			},

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
				
				if (this.isNullOrMinDate(parentRow.datainizioprevista))
					parentRow.datainizioprevista = this.state.callerState.currentRow.start;
				if (self.isNullOrMinDate(parentRow.datainizioprevista))
					parentRow.datainizioprevista = new Date();
				if (this.isNull(parentRow.idrendicontattivitaprogettokind))
					parentRow.idrendicontattivitaprogettokind = 1;
				if (this.isNullOrMinDate(parentRow.stop))
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
					$('#calendar17').fullCalendar('rerenderEvents');
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
									maxHoursPerDayTable : maxHoursPerDayTable,
									maxHoursPerYearTable: that.state.DS.tables.rendicontattivitaprogettowpview,
									maxHoursPerYearTableMaxHourCol: 'oremaxanno',
									maxHoursPerYearTableWorkedHourCol: 'oreanno'
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
				that.setRealStartStop(wpStart, wpStop, membroStart, membroStop, that.lastProroga, that.state.callerState.callerState.currentRow.start, that.state.callerState.callerState.currentRow.stop);

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

				if (that.oraStart) {
					if (that.oraStart < tempStart) {
						$("#rendicontattivitaprogetto_seg_datainizioprevista").val(that.stringFromDate_ddmmyyyy(that.oraStart));
						return that.showMessageOk('La data di inizio della attività deve essere precedente ' + that.oraStartMessage);
					}
				}
				//fine controllo intervallo date

				//mini getFormData
				that.state.currentRow.datainizioprevista = tempStart;
				return that.setFilterRendicontattivitaprogettoItineration();
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

				// carica tutte le attività dell'utente. seve per visualizzarle sul calendario
				var filter = that.q.and(
					that.q.eq("idreg", that.state.currentRow.idreg),
					that.q.ne("idrendicontattivitaprogetto", that.state.currentRow.idrendicontattivitaprogetto)
				);
				return that.getExternalEventForCalendar(filter, $("[data-tag='rendicontattivitaprogettoora.seg.seg']"))
					.then(function () {
						return that.setFilterRendicontattivitaprogettoItineration();
					});
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
				that.setRealStartStop(wpStart, wpStop, membroStart, membroStop, that.lastProroga, that.state.callerState.callerState.currentRow.start, that.state.callerState.callerState.currentRow.stop);

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

				if (that.oraStop) {
					if (that.oraStop > tempStop) {
						$("#rendicontattivitaprogetto_seg_stop").val(that.stringFromDate_ddmmyyyy(that.oraStop));
						return that.showMessageOk('La data di fine della attività deve essere successiva ' + that.oraStopMessage);
					}
				}

				//fine controllo intervallo date

				//mini getFormData
				that.state.currentRow.stop = tempStop;
				that.setFilterRendicontattivitaprogettoItineration();
			},

			//buttons
        });

	window.appMeta.addMetaPage('rendicontattivitaprogetto', 'seg', metaPage_rendicontattivitaprogetto);

}());
