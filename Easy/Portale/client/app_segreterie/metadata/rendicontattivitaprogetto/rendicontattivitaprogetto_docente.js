(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_rendicontattivitaprogetto() {
		MetaPage.apply(this, ['rendicontattivitaprogetto', 'docente', false]);
        this.name = 'Attività di ricerca';
		this.defaultListType = 'docente';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
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
				var def = appMeta.Deferred("afterGetFormData-rendicontattivitaprogetto_docente");
				var arraydef = [];
				
				arraydef.push(this.managerendicontattivitaprogetto_docente_orerendicont());
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
				
				if (self.isNullOrMinDate(parentRow.datainizioprevista))
					parentRow.datainizioprevista = new Date();
				if (self.isNullOrMinDate(parentRow.stop))
					parentRow.stop = new Date();
				this.managerendicontattivitaprogetto_docente_orerendicont();
				this.setFilterRendicontattivitaprogettoItineration();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-rendicontattivitaprogetto_docente");
				var arraydef = [];
				
				arraydef.push(this.buildRendicontattivitaprogettooraTitle());
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
				this.enableControl($('#rendicontattivitaprogetto_docente_orerendicont'), true);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('rendicontattivitaprogetto'), this.getDataTable('rendicontattivitaprogettoitineration'));
				//afterClearin
				
				//afterClearInAsyncBase
			},

			
			
			
			//afterActivation

			rowSelected: function (dataRow) {
				$("#OpenScheduleConfig").prop("disabled", false);
				$("#MassiveCancellation").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#OpenScheduleConfig").prop("disabled", true);
					$("#MassiveCancellation").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			
			beforePost: function () {
				var self = this;
				this.getDataTable('rendicontattivitaprogettowpview').acceptChanges();
				//innerBeforePost
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-rendicontattivitaprogetto_docente");
				if (t.name === "progettoelenchiview" && r !== null) {
					let self = this;
					if (this.state.isEditState())
						return this.getProroghe()
							.then(function () {
								return self.getMembro();
							})
							.then(function () {
								return def.resolve();
							});
				}

				$('#rendicontattivitaprogetto_docente_idprogetto').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idprogetto);
				$('#rendicontattivitaprogetto_docente_idprogetto').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idprogetto);
				$('#rendicontattivitaprogetto_docente_idworkpackage').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idworkpackage);
				$('#rendicontattivitaprogetto_docente_idworkpackage').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idworkpackage);
				$('#rendicontattivitaprogetto_docente_idprogetto').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idworkpackage);
				$('#rendicontattivitaprogetto_docente_idprogetto').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idworkpackage);
				//afterRowSelectin
				return def.resolve();
			},

			afterLink: function () {
				var self = this;
				this.setFilterRendicontattivitaprogettoItineration();
				this.state.DS.tables.rendicontattivitaprogetto.defaults({ 'idreg': parseInt(this.sec.usr('idreg')) });
				this.state.DS.tables.rendicontattivitaprogetto.defaults({ 'idrendicontattivitaprogettokind': 1 });
				$('.nav-tabs').on('shown.bs.tab', function (e) {
					$('#calendar18').fullCalendar('rerenderEvents');
				});
				$("#OpenScheduleConfig").on("click", _.partial(this.fireOpenScheduleConfig, this));
				$("#OpenScheduleConfig").prop("disabled", true);
				$("#MassiveCancellation").on("click", _.partial(this.fireMassiveCancellation, this));
				$("#MassiveCancellation").prop("disabled", true);
				this.setDenyNull("rendicontattivitaprogetto","orepreventivate");
				this.setDenyNull("rendicontattivitaprogetto","datainizioprevista");
				this.setDenyNull("rendicontattivitaprogetto","stop");
				appMeta.metaModel.insertFilter(this.getDataTable("rendicontattivitaprogettokinddefaultview"), this.q.eq('rendicontattivitaprogettokind_active', 'Si'));
				$('#rendicontattivitaprogetto_docente_importattivita').on("change", _.partial(this.manageimportattivita, self));
				$('#rendicontattivitaprogetto_docente_datainizioprevista').on("change", _.partial(this.managedatainizioprevista, self));
				$('#rendicontattivitaprogetto_docente_stop').on("change", _.partial(this.managestop, self));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];

					var utente = appMeta.security.usr("idreg");
					var arrayOr = [];
					var def =
						appMeta.getData.runSelect('progettoudrmembro', 'idprogetto, idprogettoudr, idprogettoudrmembro', self.q.eq('idreg', utente))
							.then(function (dt) {

								_.forEach(dt.rows, function (r) {
									arrayOr.push(self.q.eq('idprogetto', r.idprogetto));
								});

								appMeta.getData.runSelect('progettoregistry_docenti', 'idprogetto', self.q.eq('idreg_docenti', utente))
									.then(function (dtDocenti) {

										_.forEach(dtDocenti.rows, function (r) {
											arrayOr.push(self.q.eq('idprogetto', r.idprogetto));
										});

										appMeta.getData.runSelect('progettoregistry_amministrativi', 'idprogetto', self.q.eq('idreg_amministrativi', utente))
											.then(function (dtAmministrativi) {

												_.forEach(dtAmministrativi.rows, function (r) {
													arrayOr.push(self.q.eq('idprogetto', r.idprogetto));
												});

												if (arrayOr.length > 0) {
													if (arrayOr.length > 1)
														self.getDataTable('progettoelenchiview').staticFilter(self.q.or(arrayOr));
													else
														self.getDataTable('progettoelenchiview').staticFilter(arrayOr[0]);
												}

												return true;
											});
									});
							});
					arraydef.push(def);

					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			insertClick: function (that, grid) {
				if (!$('#rendicontattivitaprogetto_docente_idworkpackage').val() && grid.dataSourceName === 'rendicontattivitaprogettoora') {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Workpackage');
				}
				if (!$('#rendicontattivitaprogetto_docente_idprogetto').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Progetto');
				}
				if (!$('#rendicontattivitaprogetto_docente_idworkpackage').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Workpackage');
				}
				if (!$('#rendicontattivitaprogetto_docente_idprogetto').val() && grid.dataSourceName === 'rendicontattivitaprogettoora') {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Progetto');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			afterFill: function () {
				this.enableControl($('#rendicontattivitaprogetto_docente_orerendicont'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('rendicontattivitaprogetto'), this.getDataTable('rendicontattivitaprogettoitineration'));
				//afterFillin

				var self = this;
				if (!this.isEmpty()) {
					// carica tutte le attività dell'utente. seve per visualizzarle sul calendario
					var filter = self.q.and(
						self.q.eq("idreg", this.state.currentRow.idreg),
						self.q.ne("idrendicontattivitaprogetto", self.state.currentRow.idrendicontattivitaprogetto)
					);
					return this.getExternalEventForCalendar(filter, $("[data-tag='rendicontattivitaprogettoora.seg.seg']")).then( function(){
						return MetaPage.prototype.afterFill.call(self);
					});
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

						if (!that.state.currentRow.description) {
							if (that.state.currentRow.idrendicontattivitaprogettokind)
								that.state.currentRow.description = that.state.DS.tables.rendicontattivitaprogettokinddefaultview.select(that.q.eq("idrendicontattivitaprogettokind", that.state.currentRow.idrendicontattivitaprogettokind))[0].title;
							else
								that.state.currentRow.description = '-';
						}

						if (!that.state.currentRow.orepreventivate
							|| !that.state.currentRow.idprogetto
							|| !that.state.currentRow.idworkpackage) return that.showMessageOk(that.localResource.scheduler_fields_mandatory_msg1);

						var p = [];
						appMeta.getData.runSelect('progetto', 'title', that.q.eq('idprogetto', that.state.currentRow.idprogetto), null)
							.then(function (dt) {
								p.push([dt.rows[0].title, null, 'Progetto']);
								return appMeta.getData.runSelect('workpackage', 'title', that.q.eq('idworkpackage', that.state.currentRow.idworkpackage), null);
							}).then(function (dt) {
								if (dt.rows.length) p.push([dt.rows[0].title, null, 'Workpackage']);
								p.push([that.state.currentRow.description, null, 'Attività']);
								var columnTitleValue = that.stringify(p, 'string');
								var scheduler = new appMeta.scheduleConfig(that,
									{
										endDate: datafine,										
										minDateValue: datainizio,
										maxHours: that.state.currentRow.orepreventivate,
										tableNameSchedule: 'rendicontattivitaprogettoora',
										columnDate: 'data',
										columnOre: 'ore',
										columnTitle: '!titleancestor',
										columnTitleValue: columnTitleValue,
										calendarTag: 'rendicontattivitaprogettoora.seg.seg',
										maxHoursPerDayTable : maxHoursPerDayTable
									});

								return scheduler.show();
							});
					});
			},

			fireMassiveCancellation: function (that) {
				//mini getformdata di quello che mi serve
				;
				that.state.currentRow['!datainizio'] = that.getDateTimeFromString( $('#rendicontattivitaprogetto_docente_datainizio').val());
				that.state.currentRow['!datafine'] = that.getDateTimeFromString($('#rendicontattivitaprogetto_docente_datafine').val());
				var waitingHandler = that.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);
				appMeta.getData.launchCustomServerMethod("callSP", {
					spname: "sp_delete_rendicontattivitaprogettoora",
					prm1: that.state.currentRow.idrendicontattivitaprogetto, 
					prm2: that.state.currentRow.idprogetto,
					prm3: that.state.currentRow.idreg,
					prm4: that.stringForDbFromDate_yyyymmdd(that.state.currentRow['!datainizio']), 
					prm5: that.stringForDbFromDate_yyyymmdd(that.state.currentRow['!datafine'])
				}).then(function (res) {
				   var msg = "OK. rendicontazioni eliminate";
				   if (res.err) {
				      msg = "KO " + res.err;
					} else {
						if (res.ds.tables.Table.rows[0].curr.Column1)
							msg = "OK. " + res.ds.tables.Table.rows[0].curr.Column1;
					}
				   var parentRow = that.state.currentRow;
				   var filter = window.jsDataQuery.eq("idprogetto ", parentRow.idprogetto );
				   var selBuilderArray = [];
				   var tableToRefresh = ['rendicontattivitaprogettoora'];
					_.forEach(tableToRefresh, function (tname) {
						that.state.DS.tables[tname].clear();
						selBuilderArray.push({ filter: filter, top: null, tableName: tname, table: that.state.DS.tables[tname] });
				   });
				   appMeta.getData.multiRunSelect(selBuilderArray)
				      .then(function () {
				         that.freshForm(false, false)
				            .then(function () {
				               that.hideWaitingIndicator(waitingHandler);
				               alert(msg);
				            });
				      });
				});
			},

			managerendicontattivitaprogetto_docente_orerendicont: function () {
				this.state.currentRow['!orerendicont'] = _.sumBy(this.getDataTable('rendicontattivitaprogettoora').rows, function (r) {
					return r.ore;
				});
			},

			children: ['rendicontattivitaprogettoitineration', 'rendicontattivitaprogettoora', 'rendicontattivitaprogettowpview'],
			haveChildren: function () {
				var self = this;
				return _.some(this.children, function (child) {
					if (child !== '')
						return !!self.getDataTable(child).rows.length;
					else
						return false;
				});
			},

			manageimportattivita: function(that) { 
				var files = event.target.files;
				var file = files[0];
				var colname = 'idrendicontattivitaprogetto'; //chiave del padre
				var id = [that.state.currentRow[colname],that.state.currentRow.idworkpackage,that.state.currentRow.idprogetto]; //chiavi padre, nonno, ecc.
				//nome della procedura, array chiavi, riga dell'header del file di import, nome tabella in griglia da ricaricare, chiave del padre
				appMeta.ImportExcel.importFileIntoTable(that, file, 'sp_import_rendicontattivitaprogettoora', id, 0, 'rendicontattivitaprogettoora', colname)
					.then(function () {
						$('#rendicontattivitaprogetto_docente_importattivita').val('');
					});

			},

			managedatainizioprevista: function(that) { 
				if (that.state.isEditState()) {
					//inizio controllo intervallo date

					if (!$("#rendicontattivitaprogetto_docente_datainizioprevista").val()) {
						return;
					}

					//mini getFormData necessario
					that.state.currentRow.idworkpackage = parseInt($("#rendicontattivitaprogetto_docente_idworkpackage").val());

					var tempDate = $("#rendicontattivitaprogetto_docente_datainizioprevista").val();
					let tempStart = that.getDateTimeFromString(tempDate);

					let wpStop = that.state.DS.tables.workpackageelenchiview.select(that.q.eq('idworkpackage', that.state.currentRow.idworkpackage))[0].workpackage_stop;
					let wpStart = that.state.DS.tables.workpackageelenchiview.select(that.q.eq('idworkpackage', that.state.currentRow.idworkpackage))[0].workpackage_start;

					let membroStart = null;
					let membroStop = null;
					if (that.Membro) {
						membroStart = that.Membro.start;
						membroStop = that.Membro.stop;
					}
					that.setRealStartStop(wpStart, wpStop, membroStart, membroStop, that.lastProroga);

					if (that.start) {
						if (that.start > tempStart) {
							$("#rendicontattivitaprogetto_docente_datainizioprevista").val(that.stringFromDate_ddmmyyyy(that.start));
							return that.showMessageOk('La data di inizio dell\'attività deve essere successiva ' + that.startMessage);
						}
					}

					if (that.stop) {
						if (that.stop < tempStart) {
							$("#rendicontattivitaprogetto_docente_datainizioprevista").val(that.stringFromDate_ddmmyyyy(that.stop));
							return that.showMessageOk('La data di inizio dell\'attività deve essere precedente ' + that.stopMessage);
						}
					}

					if ($("#rendicontattivitaprogetto_docente_stop").val() && that.getDateTimeFromString($("#rendicontattivitaprogetto_docente_stop").val()) < tempStart) {
						$("#rendicontattivitaprogetto_docente_datainizioprevista").val($("#rendicontattivitaprogetto_docente_stop").val());
						return that.showMessageOk('La data di inizio dell\'attività deve essere precedente a quella finale');
					}
					//fine controllo intervallo date

					that.setFilterRendicontattivitaprogettoItineration();
				}
			},

			managestop: function(that) { 
				if (that.state.isEditState()) {

					//inizio controllo intervallo date
					if (!$("#rendicontattivitaprogetto_docente_stop").val()) {
						return;
					}
					if (!$("#rendicontattivitaprogetto_docente_idworkpackage").val()) {
						return;
					}
					//mini getFormData necessario
					that.state.currentRow.idworkpackage = parseInt($("#rendicontattivitaprogetto_docente_idworkpackage").val());

					var tempDate = $("#rendicontattivitaprogetto_docente_stop").val();
					let tempStop = that.getDateTimeFromString(tempDate);

					let wpStop = that.state.DS.tables.workpackageelenchiview.select(that.q.eq('idworkpackage', that.state.currentRow.idworkpackage))[0].workpackage_stop;
					let wpStart = that.state.DS.tables.workpackageelenchiview.select(that.q.eq('idworkpackage', that.state.currentRow.idworkpackage))[0].workpackage_start;
					let membroStart = null;
					let membroStop = null;
					if (that.Membro) {
						membroStart = that.Membro.start;
						membroStop = that.Membro.stop;
					}
					that.setRealStartStop(wpStart, wpStop, membroStart, membroStop, that.lastProroga);

					if (that.start) {
						if (that.start > tempStop) {
							$("#rendicontattivitaprogetto_docente_stop").val(that.stringFromDate_ddmmyyyy(that.start));
							return that.showMessageOk('La data di fine dell\'attività deve essere successiva ' + that.startMessage);
						}
					}

					if (that.stop) {
						if (that.stop < tempStop) {
							$("#rendicontattivitaprogetto_docente_stop").val(that.stringFromDate_ddmmyyyy(that.stop));
							return that.showMessageOk('La data di fine dell\'attività deve essere precedente ' + that.stopMessage);
						}
					}

					if ($("#rendicontattivitaprogetto_docente_datainizioprevista").val() && that.getDateTimeFromString($("#rendicontattivitaprogetto_docente_datainizioprevista").val()) > tempStop) {
						$("#rendicontattivitaprogetto_docente_stop").val($("#rendicontattivitaprogetto_docente_datainizioprevista").val());
						return that.showMessageOk('La data finale dell\'attività deve essere successiva a quella iniziale');
					}
					//fine controllo intervallo date

					that.setFilterRendicontattivitaprogettoItineration();
				}
			},

			//buttons
        });

	window.appMeta.addMetaPage('rendicontattivitaprogetto', 'docente', metaPage_rendicontattivitaprogetto);

}());
