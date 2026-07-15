(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_workpackage() {
		MetaPage.apply(this, ['workpackage', 'seg', true]);
        this.name = 'Workpackage';
		this.defaultListType = 'seg';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_workpackage.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_workpackage,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			manageValidResult: function (rowToCheck) {
				var loc = appMeta.localResource;
				var def = appMeta.Deferred("isValid-workpackage_seg");
				var firstErrorObj;

				this.lastProroga = this.state.callerState.DS.tables.progettoproroga.rows.length ?
					_.orderBy(this.state.callerState.DS.tables.progettoproroga.rows, 'proroga', 'desc')[0] : null;
				this.setRealStartStop(null, null, null, null, this.lastProroga, this.state.callerState.currentRow.start, this.state.callerState.currentRow.stop);

				let tempStart = this.state.currentRow.start;
				let tempStop = this.state.currentRow.stop;

				if (this.start) {
					if (this.start > tempStart) {
						$("#workpackage_seg_start").val(this.stringFromDate_ddmmyyyy(this.start));
						firstErrorObj = {
							warningMsg: "",
							errMsg: 'La data di inizio dell\'attività deve essere successiva ' + this.startMessage,
							outCaption: 'Data di inizio',
							errField: 'datainizioprevista',
							row: rowToCheck
						};
						return def.resolve(firstErrorObj).then(MetaPage.prototype.manageValidResult.call(this, rowToCheck));
					}
				}

				if (this.stop) {
					if (this.stop < tempStart) {
						$("#workpackage_seg_start").val(this.stringFromDate_ddmmyyyy(this.stop));
						firstErrorObj = {
							warningMsg: "",
							errMsg: 'La data di inizio dell\'attività deve essere precedente ' + this.stopMessage,
							outCaption: 'Data di inizio',
							errField: 'datainizioprevista',
							row: rowToCheck
						};
						return def.resolve(firstErrorObj).then(MetaPage.prototype.manageValidResult.call(this, rowToCheck));
					}
				}

				if ($("#workpackage_seg_stop").val() && this.getDateTimeFromString($("#workpackage_seg_stop").val()) < tempStart) {
					$("#workpackage_seg_start").val($("#workpackage_seg_stop").val());
					firstErrorObj = {
						warningMsg: "",
						errMsg: 'La data di inizio dell\'attività deve essere precedente a quella finale',
						outCaption: 'Data di inizio',
						errField: 'datainizioprevista',
						row: rowToCheck
					};
					return def.resolve(firstErrorObj).then(MetaPage.prototype.manageValidResult.call(this, rowToCheck));

				}

				if (this.oraStart) {
					if (this.oraStart < tempStart) {
						$("#workpackage_seg_start").val(this.stringFromDate_ddmmyyyy(this.oraStart));

						firstErrorObj = {
							warningMsg: "",
							errMsg: 'La data di inizio della attività deve essere precedente ' + this.oraStartMessage,
							outCaption: 'Data di inizio',
							errField: 'datainizioprevista',
							row: rowToCheck
						};
						return def.resolve(firstErrorObj).then(MetaPage.prototype.manageValidResult.call(this, rowToCheck));

					}
				}

				if (this.start) {
					if (this.start > tempStop) {
						$("#workpackage_seg_stop").val(this.stringFromDate_ddmmyyyy(this.start));
						firstErrorObj = {
							warningMsg: "",
							errMsg: 'La data di fine dell\'attività deve essere successiva ' + this.startMessage,
							outCaption: 'Data di fine',
							errField: 'stop',
							row: rowToCheck
						};
						return def.resolve(firstErrorObj).then(MetaPage.prototype.manageValidResult.call(this, rowToCheck));
					}
				}

				if (this.stop) {
					if (this.stop < tempStop) {
						$("#workpackage_seg_stop").val(this.stringFromDate_ddmmyyyy(this.stop));
						firstErrorObj = {
							warningMsg: "",
							errMsg: 'La data di fine dell\'attività deve essere precedente ' + this.stopMessage,
							outCaption: 'Data di fine',
							errField: 'stop',
							row: rowToCheck
						};
						return def.resolve(firstErrorObj).then(MetaPage.prototype.manageValidResult.call(this, rowToCheck));
					}
				}

				if ($("#workpackage_seg_start").val() && this.getDateTimeFromString($("#workpackage_seg_start").val()) > tempStop) {
					$("#workpackage_seg_stop").val($("#workpackage_seg_start").val());
					firstErrorObj = {
						warningMsg: "",
						errMsg: 'La data finale dell\'attività deve essere successiva a quella iniziale',
						outCaption: 'Data di fine',
						errField: 'stop',
						row: rowToCheck
					};
					return def.resolve(firstErrorObj).then(MetaPage.prototype.manageValidResult.call(this, rowToCheck));
				}

				if (this.oraStop) {
					if (this.oraStop > tempStop) {
						$("#workpackage_seg_stop").val(this.stringFromDate_ddmmyyyy(this.oraStop));
						firstErrorObj = {
							warningMsg: "",
							errMsg: 'La data di fine della attività deve essere successiva ' + this.oraStopMessage,
							outCaption: 'Data di fine',
							errField: 'stop',
							row: rowToCheck
						};
						return def.resolve(firstErrorObj).then(MetaPage.prototype.manageValidResult.call(this, rowToCheck));
					}
				}


				def.resolve(true);
				//$isValid$
				
				return  MetaPage.prototype.manageValidResult.call(this, rowToCheck);
			},

			afterGetFormData: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				//afterGetFormDataFilter
				
				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-workpackage_seg");
				var arraydef = [];
				
				arraydef.push(this.manageworkpackage_seg_titolobreve());
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
				
				if (self.isNullOrMinDate(parentRow.start))
					parentRow.start = this.state.callerState.currentRow.start;
				if (self.isNullOrMinDate(parentRow.stop))
					parentRow.stop = this.state.callerState.currentRow.stop;
				this.manageworkpackage_seg_amount();				this.manageworkpackage_seg_titolobreve();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-workpackage_seg");
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
				this.enableControl($('#workpackage_seg_titolobreve'), true);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('workpackage'), this.getDataTable('assetdiary'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('rendicontattivitaprogetto_alias1'), this.getDataTable('rendicontattivitaprogettoyear'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('rendicontattivitaprogetto_alias1'), this.getDataTable('rendicontattivitaprogettoitineration'));
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				this.enableControl($('#workpackage_seg_titolobreve'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('workpackage'), this.getDataTable('assetdiary'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('rendicontattivitaprogetto_alias1'), this.getDataTable('rendicontattivitaprogettoyear'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('rendicontattivitaprogetto_alias1'), this.getDataTable('rendicontattivitaprogettoitineration'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$("#btn_add_workpackageupb_idupb").on("click", _.partial(this.searchAndAssignupbelenchiview, self));
				$("#btn_add_workpackageupb_idupb").prop("disabled", true);
				this.setDenyNull("workpackage","title");
				appMeta.metaModel.insertFilter(this.getDataTable("strutturadefaultview"), this.q.eq('struttura_active', 'Si'));
				$('#grid_rendicontattivitaprogetto_alias1_seg').data('mdlconditionallookup', 'rendicontatutto,S,Si;rendicontatutto,N,No;');
				$('#workpackage_seg_importattivita').on("change", _.partial(this.manageimportattivita, self));
				$('#workpackage_seg_start').on("change", _.partial(this.managestart, self));
				$('#workpackage_seg_stop').on("change", _.partial(this.managestop, self));
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
				$("#btn_add_workpackageupb_idupb").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#btn_add_workpackageupb_idupb").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			//insertClick

			//beforePost

			//afterPost

			manageworkpackage_seg_amount: function () {
				var assetdiary= this.getDataTable('assetdiary');
				var assetdiaryora = this.getDataTable('assetdiaryora');
				_.forEach(assetdiary.rows, function(rb) {
					rb["!amount"] = _.ceil( _.sumBy(
						_.filter(assetdiaryora.rows, function (r) {
							return r.idassetdiary === rb.idassetdiary  && !!r.amount;
						}),
						'amount'), 2);
				});
			},

			searchAndAssignupbelenchiview: function (that) {
				var q = window.jsDataQuery;
				var f = q.and(
					q.eq('active', 'Si'),
				);
				return that.searchAndAssign({
					tableName: "upbelenchiview",
					listType: "default",
					idControl: "txt_workpackageupb_idupb",
					tagSearch: "upbelenchiview.codeupb",
					columnNameText: "codeupb",
					columnSource: "idupb",
					columnToFill: "idupb",
					tableToFill: "workpackageupb",
					filter: f
				});
			},

			manageworkpackage_seg_titolobreve: function () {
				this.state.currentRow['!titolobreve'] = this.state.callerState.currentRow.titolobreve;
			},

			manageimportattivita: function(that) { 
				var files = event.target.files;
				var file = files[0];
				var colname = 'idworkpackage'; //chiave del padre
				var id = [that.state.currentRow[colname],that.state.currentRow.idprogetto]; //chiavi padre, nonno, ecc.
				//nome della procedura, array chiavi, riga dell'header del file di import, nome tabella in griglia da ricaricare, chiave del padre
				appMeta.ImportExcel.importFileIntoTable(that, file, 'sp_import_rendicontattivitaprogetto', id, 0, 'rendicontattivitaprogetto_alias1', colname, null )
					.then(function () {
						$('#workpackage_seg_importattivita').val('');
					});

			},

			managestart: function(that) { 
				if (!$("#workpackage_seg_start").val()) {
					return;
				}

				that.lastProroga = that.state.callerState.DS.tables.progettoproroga.rows.length ?
					_.orderBy(that.state.callerState.DS.tables.progettoproroga.rows, 'proroga', 'desc')[0] : null;
				that.setRealStartStop(null, null, null, null, that.lastProroga, that.state.callerState.currentRow.start, that.state.callerState.currentRow.stop);

				let tempDate = $("#workpackage_seg_start").val();
				let tempStart = that.getDateTimeFromString(tempDate);

				if (that.start) {
					if (that.start > tempStart) {
						$("#workpackage_seg_start").val(that.stringFromDate_ddmmyyyy(that.state.currentRow.start));
						return that.showMessageOk('La data di inizio del workpackage deve essere successiva a quella dell\'inizio del progetto (' + that.stringFromDate_ddmmyyyy(that.state.callerState.currentRow.start) + ')');
					}
				}

				if (that.stop) {
					if (that.stop < tempStart) {
						$("#workpackage_seg_start").val(that.stringFromDate_ddmmyyyy(that.state.currentRow.start));
						return that.showMessageOk('La data di inizio del workpackage deve essere precedente ' + that.stopMessage);
					}
				}

				if ($("#workpackage_seg_stop").val() && that.getDateTimeFromString($("#workpackage_seg_stop").val()) < that.getDateTimeFromString(tempDate)) {
					$("#workpackage_seg_start").val(that.stringFromDate_ddmmyyyy(that.state.currentRow.start));
					return that.showMessageOk('La data di inizio del workpackage deve essere precedente a quella finale');
				}

				if (that.oraStart) {
					if (that.oraStart < tempStart) {
						$("#workpackage_seg_start").val(that.stringFromDate_ddmmyyyy(that.oraStart));
						return that.showMessageOk('La data di inizio del workpackage deve essere precedente ' + that.oraStartMessage);
					}
				}
			},

			managestop: function(that) { 
				if (!$("#workpackage_seg_stop").val()) {
					return;
				}

				that.lastProroga = that.state.callerState.DS.tables.progettoproroga.rows.length ?
					_.orderBy(that.state.callerState.DS.tables.progettoproroga.rows, 'proroga', 'desc')[0] : null;
				that.setRealStartStop(null, null, null, null, that.lastProroga, that.state.callerState.currentRow.start, that.state.callerState.currentRow.stop);

				var tempDate = $("#workpackage_seg_stop").val();
				let tempStop = that.getDateTimeFromString(tempDate);

				if (that.start) {
					if (that.start > tempStop) {
						$("#workpackage_seg_stop").val(that.stringFromDate_ddmmyyyy(that.state.currentRow.stop));
						return that.showMessageOk('La data di finale del workpackage deve essere successiva a quella iniziale del progetto (' + that.stringFromDate_ddmmyyyy(that.state.callerState.currentRow.start) + ')');
					}
				}

				if (that.stop) {
					if (that.stop < tempStop) {
						$("#workpackage_seg_stop").val(that.stringFromDate_ddmmyyyy(that.state.currentRow.stop));
						return that.showMessageOk('La data finale del workpackage deve essere precedente ' + that.stopMessage);
					}
				}

				if ($("#workpackage_seg_start").val() && that.getDateTimeFromString($("#workpackage_seg_start").val()) > that.getDateTimeFromString(tempDate)) {
					$("#workpackage_seg_stop").val(that.stringFromDate_ddmmyyyy(that.state.currentRow.stop));
					return that.showMessageOk('La data finale del workpackage deve essere successiva a quella iniziale');
				}

				if (that.oraStop) {
					if (that.oraStop > tempStop) {
						$("#workpackage_seg_stop").val(that.stringFromDate_ddmmyyyy(that.oraStop));
						return that.showMessageOk('La data di fine del workpackage deve essere successiva ' + that.oraStopMessage);
					}
				}

			},

			//buttons
        });

	window.appMeta.addMetaPage('workpackage', 'seg', metaPage_workpackage);

}());
