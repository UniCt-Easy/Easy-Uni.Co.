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

			//isValidFunction

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
				
				if (this.isNull(parentRow.start))
					parentRow.start = this.state.callerState.currentRow.start;
				if (this.isNull(parentRow.stop))
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
			}
,

			searchAndAssignupbelenchiview: function (that) {
				return that.searchAndAssign({
					tableName: "upbelenchiview",
					listType: "default",
					idControl: "txt_workpackageupb_idupb",
					tagSearch: "upbelenchiview.codeupb",
					columnNameText: "codeupb",
					columnSource: "idupb",
					columnToFill: "idupb",
					tableToFill: "workpackageupb"
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
				appMeta.ImportExcel.importFileIntoTable(that, file, 'sp_import_rendicontattivitaprogetto', id, 0, 'rendicontattivitaprogetto_alias1', colname, 'rendicontattivitaprogettoora')
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
				that.setRealStartStop(that.state.callerState.currentRow.start, that.state.callerState.currentRow.stop, null, null, that.lastProroga);

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
						return that.showMessageOk('La data di inizio del workpackage deve essere precedente a quella finale del progetto (' + that.stringFromDate_ddmmyyyy(that.state.callerState.currentRow.stop) + ')');
					}
				}

				if ($("#workpackage_seg_stop").val() && that.getDateTimeFromString($("#workpackage_seg_stop").val()) < that.getDateTimeFromString(tempDate)) {
					$("#workpackage_seg_start").val(that.stringFromDate_ddmmyyyy(that.state.currentRow.start));
					return that.showMessageOk('La data di inizio del workpackage deve essere precedente a quella finale');
				}
			},

			managestop: function(that) { 
								if (!$("#workpackage_seg_stop").val()) {
					return;
				}

				that.lastProroga = that.state.callerState.DS.tables.progettoproroga.rows.length ?
					_.orderBy(that.state.callerState.DS.tables.progettoproroga.rows, 'proroga', 'desc')[0] : null;
				that.setRealStartStop(that.state.callerState.currentRow.start, that.state.callerState.currentRow.stop, null, null, that.lastProroga);

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
						return that.showMessageOk('La data finale del workpackage deve essere precedente a quella della fine del progetto (' + that.stringFromDate_ddmmyyyy(that.state.callerState.currentRow.stop) + ')');
					}
				}

				if ($("#workpackage_seg_start").val() && that.getDateTimeFromString($("#workpackage_seg_start").val()) > that.getDateTimeFromString(tempDate)) {
					$("#workpackage_seg_stop").val(that.stringFromDate_ddmmyyyy(that.state.currentRow.stop));
					return that.showMessageOk('La data finale del workpackage deve essere successiva a quella iniziale');
				}
			},

			//buttons
        });

	window.appMeta.addMetaPage('workpackage', 'seg', metaPage_workpackage);

}());
