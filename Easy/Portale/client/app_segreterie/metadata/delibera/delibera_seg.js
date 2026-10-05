(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_delibera() {
		MetaPage.apply(this, ['delibera', 'seg', false]);
        this.name = 'Delibere';
		this.defaultListType = 'seg';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_delibera.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_delibera,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			afterGetFormData: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				if (self.isNullOrMinDate(parentRow.data))
				parentRow.data = new Date();
				//afterGetFormDataFilter
				
				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-delibera_seg");
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
				
				var gridParentRelsdeliberapratica13 = self.state.DS.getParentChildRelation("delibera", "deliberapratica");
				var fatherfilterdeliberapratica13 = gridParentRelsdeliberapratica13[0].getChildFilter(parentRow);
				var filterGrididistanzakind13 = window.jsDataQuery.ne("idistanzakind", 9);
				var deliberapratica = this.getDataTable("deliberapratica");
				var finalfilterdeliberapratica13 = window.jsDataQuery.and([fatherfilterdeliberapratica13, filterGrididistanzakind13]);
				deliberapratica.rows =  _.filter(deliberapratica.rows, function(r) {return finalfilterdeliberapratica13(r)});
				$("#grid_deliberapratica_seg").data("customParentRelation", finalfilterdeliberapratica13);
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#delibera_seg_idstruttura'), null);
				} else {
					this.helpForm.filter($('#delibera_seg_idstruttura'), this.q.eq('struttura_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-delibera_seg");
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
				this.helpForm.filter($('#delibera_seg_idstruttura'), null);
				this.enableControl($('#delibera_seg_protnumero'), true);
				this.enableControl($('#delibera_seg_protanno'), true);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				this.enableControl($('#delibera_seg_protnumero'), false);
				this.enableControl($('#delibera_seg_protanno'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$("#btn_add_deliberaistanza_idistanza").on("click", _.partial(this.searchAndAssignistanza_alias14, self));
				$("#btn_add_deliberaistanza_idistanza").prop("disabled", true);
				$("#btn_add_deliberapratica_idpratica").on("click", _.partial(this.searchAndAssignpratica, self));
				$("#btn_add_deliberapratica_idpratica").prop("disabled", true);
				$("#GetApprove").on("click", _.partial(this.fireGetApprove, this));
				$("#GetApprove").prop("disabled", true);
				$("#btnProtocol").on("click", _.partial(this.firebtnProtocol, this));
				$("#btnProtocol").prop("disabled", true);
				this.state.DS.tables.statuskinddefaultview.staticFilter(window.jsDataQuery.eq("statuskind_delibera",'Si'));
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
				$("#btn_add_deliberaistanza_idistanza").prop("disabled", false);
				$("#btn_add_deliberapratica_idpratica").prop("disabled", false);
				$("#GetApprove").prop("disabled", false);
				$("#btnProtocol").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#btn_add_deliberaistanza_idistanza").prop("disabled", true);
					$("#btn_add_deliberapratica_idpratica").prop("disabled", true);
					$("#GetApprove").prop("disabled", true);
					$("#btnProtocol").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			//insertClick

			//beforePost

			searchAndAssignistanza_alias14: function (that) {
				return that.searchAndAssign({
					tableName: "istanza_alias14",
					listType: "segstuelenco",
					idControl: "txt_deliberaistanza_idistanza",
					tagSearch: "istanzasegstuelencoview.dropdown_title",
					columnNameText: "idistanzakind",
					columnSource: "idistanza",
					columnToFill: "idistanza",
					tableToFill: "deliberaistanza",
					filter: that.q.eq("istanza_idstatuskind", 5)
				});
			},

			searchAndAssignpratica: function (that) {
				return that.searchAndAssign({
					tableName: "pratica",
					listType: "segstuelenco",
					idControl: "txt_deliberapratica_idpratica",
					tagSearch: "praticasegstuelencoview.dropdown_title",
					columnNameText: "idreg",
					columnSource: "idpratica",
					columnToFill: "idpratica",
					tableToFill: "deliberapratica",
					filter: that.q.eq("pratica_idstatuskind", 5)
				});
			},

			fireGetApprove:function(that) {
				// se la delibera è relativa a convalide le rende definitive
				that.hasUnsavedChanges()
					.then(function (result) {
						if (result) {
							return that.showMessageOk("Prima devi salvare la pagina");
						} else {
							var waitingHandler = that.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);
							appMeta.getData.launchCustomServerMethod("callSP", {
								spname: "sp_setapproveddelibera",
								prm1: that.state.currentRow.iddelibera,
								prm2: appMeta.security.usrEnv.userweb
							}).then(function (res) {
								var msg = "OK. Le istanze e le pratiche sono state deliberate.";
								if (res.err) {
									msg = "KO " + res.err;
								}
								else {
									msg = res.ds.tables.Table.rows[0].curr.Column1;
								}
								var filter = window.jsDataQuery.eq("iddelibera", that.state.currentRow.iddelibera);
								var selBuilderArray = [];
								var tableToRefresh = ['deliberaistanza', 'deliberapratica'];
								_.forEach(tableToRefresh, function (tname) {
									selBuilderArray.push({ filter: filter, top: null, tableName: tname, table: that.state.DS.tables[tname] });
								});
								appMeta.getData.multiRunSelect(selBuilderArray)
									.then(function () {
										$('#delibera_seg_idstatuskind').val(6);
										that.state.currentRow.idstatuskind = 6;
										that.cmdMainSave()
										//that.freshForm(false, false)
											.then(function () {
												that.hideWaitingIndicator(waitingHandler);
												alert(msg);
											});
									});
							});
						}
					});

			},

			firebtnProtocol: function (that) {
				var idreg_origine =  that.idreg_istituto;
				var idreg_destinazione = that.idreg_istituto;
				var statuskind = that.getDataTable('statuskind');
				var rowsStatusKind = statuskind.select(that.q.eq('idstatuskind', that.state.currentRow.idstatuskind));
				var oggetto = 'Delibera del ' + that.stringFromDate_ddmmyyyy(that.state.currentRow.data)+ (rowsStatusKind.length ? ' ' + rowsStatusKind[0].title : '');
				var idprotocollodockind = 4;
				var arrayTablesToProtocol = ['delibera'];
				var codiceregistro = that.state.currentRow.getRow().table.name + that.state.currentRow.iddelibera;

				return that.assegnaProtocollo(idreg_origine, idreg_destinazione, idprotocollodockind, oggetto, codiceregistro, arrayTablesToProtocol);
			},

			//buttons
        });

	window.appMeta.addMetaPage('delibera', 'seg', metaPage_delibera);

}());
