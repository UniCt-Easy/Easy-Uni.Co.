(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_didprog() {
		MetaPage.apply(this, ['didprog', 'default', false]);
        this.name = 'Didattiche programmate';
		this.defaultListType = 'default';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_didprog.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_didprog,
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
				var def = appMeta.Deferred("afterGetFormData-didprog_default");
				var arraydef = [];
				
				arraydef.push(this.manageCouses());
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
				
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#didprog_default_idareadidattica'), null);
				} else {
					this.helpForm.filter($('#didprog_default_idareadidattica'), this.q.eq('areadidattica_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#didprog_default_idreg_docenti'), null);
				} else {
					this.helpForm.filter($('#didprog_default_idreg_docenti'), this.q.eq('registry_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-didprog_default");
				var arraydef = [];
				
				arraydef.push(this.manageCouses());
				arraydef.push(appMeta.getData.runSelectIntoTable(self.getDataTable("didproggrupp"), window.jsDataQuery.eq("iddidprog", self.state.currentRow.iddidprog), null));
				arraydef.push(appMeta.getData.runSelectIntoTable(self.getDataTable("didprogcurr"), window.jsDataQuery.eq("iddidprog", self.state.currentRow.iddidprog), null));
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
				this.enableControl($("#XXdidproggrupp"), this.state.isEditState());
				this.enableControl($("#XXdidprogcurr"), this.state.isEditState());
				this.enableControl($('#didprog_default_idcorsostudiokind'), false);
				this.enableControl($('#didprog_default_idcorsostudiolivello'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('attivform'), this.getDataTable('canale'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('canale'), this.getDataTable('canaleregistry'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('attivform'), this.getDataTable('attivformcaratteristica'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('attivform'), this.getDataTable('attivformproped'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('iscrizioneanno'), this.getDataTable('parttimeinfo'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			
			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-didprog_default");
				$('#didprog_default_idcorsostudio').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idcorsostudio);
				$('#didprog_default_idcorsostudio').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idcorsostudio);
				if (t.name === "annoaccademico" && r !== null) {
					return this.manageaa(this).then(function () {
						return def.resolve();
					});
				}
				if (t.name === "corsostudiokinddefaultview" && r !== null) {
					return this.manageidcorsostudiokind(this).then(function () {
						return def.resolve();
					});
				}
				if (t.name === "corsostudiolivellodefaultview" && r !== null) {
					return this.manageidcorsostudiolivello(this).then(function () {
						return def.resolve();
					});
				}
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			rowSelected: function (dataRow) {
				$("#btn_add_didprogclassconsorsuale_idclassconsorsuale").prop("disabled", false);
				$("#btn_add_didprograppstud_idreg_studenti").prop("disabled", false);
				$("#GenerateDidProgCurricula").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				if ($("#XXdidproggrupp").length) {
					$("#XXdidproggrupp").prop("disabled", !currMetaPage.state.isEditState());
				}
				if ($("#XXdidprogcurr").length) {
					$("#XXdidprogcurr").prop("disabled", !currMetaPage.state.isEditState());
				}
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#btn_add_didprogclassconsorsuale_idclassconsorsuale").prop("disabled", true);
					$("#btn_add_didprograppstud_idreg_studenti").prop("disabled", true);
					$("#GenerateDidProgCurricula").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			
			
			//afterPost

			insertClick: function (that, grid) {
				if (this.state.isInsertState() && grid.dataSourceName === "attivform") {
					return this.showMessageOk("Devi prima salvare la didattica, e creare gli oggetti: curriculum etc...");
				} 
				if (!$('#didprog_default_idcorsostudio').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Corso di studi');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			beforePost: function () {
				var def = appMeta.Deferred("afterRowSelect-didprog_default");

				var r = this.state.currentRow;
				if (!r) return def.resolve();
				if (!r.getRow) return def.resolve();
				if (r.getRow().state !== jsDataSet.dataRowState.deleted) return def.resolve();

				// siamo nello stato deleted della riga principiale, forzo la cancellazione delle entità non subentità,che diepndono da questa didprog
				var self = this;
				var selBuilderArray = [];
				var tableArray = ["didprogcurr", "didprogori", "didproganno", "didprogporzanno", "didproggrupp", "didprograppstud", "didprogclassconsorsuale",
					"didprogcurrcaratteristica", "affidamento", "affidamentocaratteristica", "affidamentocaratteristicaora","affidamentoattach"];

				var idDidProgKey = "iddidprog";

				var iddidprog = this.state.currentRow[idDidProgKey];
				var filter = window.jsDataQuery.eq(idDidProgKey, iddidprog);

				// costruisco query
				_.forEach(tableArray, function (tname) {
					selBuilderArray.push({ filter: filter, top: null, tableName: tname, table: self.state.DS.tables[tname] });
				});

				appMeta.getData.multiRunSelect(selBuilderArray)
					.then(function () {
						_.forEach(tableArray, function (tname) {
							var currTab = self.state.DS.tables[tname];
							_.forEach(currTab.rows, function (r) {
								// cancello solo le righe referenziate da questa didprog
								if (r[idDidProgKey] === iddidprog) r.getRow().del();
							});
						});

						def.resolve();
					});

				return def.promise();
			},

			searchAndAssignregistry: function (that) {
				return that.searchAndAssign({
					tableName: "registry",
					listType: "studenti",
					idControl: "txt_didprograppstud_idreg_studenti",
					tagSearch: "registrystudentiview.dropdown_title",
					columnNameText: "title",
					columnSource: "idreg",
					columnToFill: "idreg_studenti",
					tableToFill: "didprograppstud",
					filter: that.q.and(that.q.eq('registry_active', 'Si'), that.q.eq('registry_extension', 'studenti'))
				});
			},

			afterClear: function () {
				//parte sincrona
				const annoCorrente = this.getAAByDate(new Date());
				$('#didprog_default_aa').val(annoCorrente).trigger('change');

				this.enableControl($('#didprog_default_idcorsostudiokind'), true);
				this.enableControl($('#didprog_default_idcorsostudiolivello'), true);
				this.helpForm.filter($('#didprog_default_idareadidattica'), null);
				this.enableControl($('#didprog_default_idcorsostudio'), true);
				this.helpForm.filter($('#didprog_default_idreg_docenti'), null);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('attivform'), this.getDataTable('canale'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('canale'), this.getDataTable('canaleregistry'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('attivform'), this.getDataTable('attivformcaratteristica'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('attivform'), this.getDataTable('attivformproped'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('iscrizioneanno'), this.getDataTable('parttimeinfo'));
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterLink: function () {
				var self = this;
				this.getDataTable("corsostudioelenchiprogerogview").staticFilter(this.q.eq('idcorsostudio', 0));

				this.state.DS.tables.didprog.defaults({ 'freqobbl': "S" });
				this.state.DS.tables.didprog.defaults({ 'iddidprognumchiusokind': 1 });
				this.state.DS.tables.didprog.defaults({ 'iddidprogsuddannokind': 5 });
				this.state.DS.tables.didprog.defaults({ 'iderogazkind': 1 });
				this.state.DS.tables.didprog.defaults({ 'idnation_lang': 1 });
				this.state.DS.tables.didprog.defaults({ 'idnation_langvis': 1 });
				this.state.DS.tables.didprog.defaults({ 'idtitolokind': 1 });
				this.state.DS.tables.didprog.defaults({ 'immatoltreauth': "S" });
				this.state.DS.tables.didprog.defaults({ 'preimmatoltreauth': "S" });
				$("#btn_add_didprogclassconsorsuale_idclassconsorsuale").on("click", _.partial(this.searchAndAssignclassconsorsuale, self));
				$("#btn_add_didprogclassconsorsuale_idclassconsorsuale").prop("disabled", true);
				$("#btn_add_didprograppstud_idreg_studenti").on("click", _.partial(this.searchAndAssignregistry, self));
				$("#btn_add_didprograppstud_idreg_studenti").prop("disabled", true);
				$("#XXdidproggrupp").prop("disabled", true);
				appMeta.metaModel.cachedTable(this.getDataTable("didproggrupp"), true);
				appMeta.metaModel.lockRead(this.getDataTable("didproggrupp"));
				$("#XXdidprogcurr").prop("disabled", true);
				appMeta.metaModel.cachedTable(this.getDataTable("didprogcurr"), true);
				appMeta.metaModel.lockRead(this.getDataTable("didprogcurr"));
				$("#GenerateDidProgCurricula").on("click", _.partial(this.fireGenerateDidProgCurricula, this));
				$("#GenerateDidProgCurricula").prop("disabled", true);
				this.setDenyNull("didprog","aa");
				this.setDenyNull("didprog","iddidprogsuddannokind");
				this.setDenyNull("didprog","idsede");
				appMeta.metaModel.insertFilter(this.getDataTable("corsostudiokinddefaultview"), this.q.eq('corsostudiokind_active', 'Si'));
				appMeta.metaModel.insertFilter(this.getDataTable("didprognumchiusokind"), this.q.eq('active', 'S'));
				appMeta.metaModel.insertFilter(this.getDataTable("didprogsuddannokinddefaultview"), this.q.eq('didprogsuddannokind_active', 'Si'));
				appMeta.metaModel.insertFilter(this.getDataTable("erogazkinddefaultview"), this.q.eq('erogazkind_active', 'Si'));
				appMeta.metaModel.insertFilter(this.getDataTable("titolokinddefaultview"), this.q.eq('titolokind_active', 'Si'));
				$('#grid_attivform_default').data('mdlconditionallookup', 'tipovalutaz,P,Profitto;tipovalutaz,I,Idoneità;');
				$('#grid_didprogclassconsorsuale_didprog').data('mdlconditionallookup', '!idclassconsorsuale_classconsorsuale_active,S,Si;!idclassconsorsuale_classconsorsuale_active,N,No;!idclassconsorsuale_classconsorsuale_tipoente,U,Università;!idclassconsorsuale_classconsorsuale_tipoente,A,AFAM;');
				$('#grid_didprograppstud_default').data('mdlconditionallookup', '!idreg_registry_active,S,Si;!idreg_registry_active,N,No;');
				var grid_attivform_defaultChildsTables = [
					{ tablename: 'canale', edittype: 'default', columnlookup: 'title', columncalc: '!canale'},
					{ tablename: 'attivformcaratteristica', edittype: 'default', columnlookup: 'cf', columncalc: '!attivformcaratteristica'},
				];
				$('#grid_attivform_default').data('childtables', grid_attivform_defaultChildsTables);
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			manageCouses: function(){
				if (!this.state.isSearchState()) {
					let def = appMeta.Deferred("manageCouses");
					return def.resolve();
				}

				let aa = $('#didprog_default_aa').val();
				let idcorsostudiokind = $('#didprog_default_idcorsostudiokind').val();
				let idcorsostudiolivello = $('#didprog_default_idcorsostudiolivello').val();
				let filterDidProg = this.q.and(
					...(aa ? [this.q.eq("aa", aa)] : []),
					...(idcorsostudiokind ? [this.q.eq("idcorsostudiokind", idcorsostudiokind)] : []),
					...(idcorsostudiolivello ? [this.q.eq("idcorsostudiolivello", idcorsostudiolivello)] : [])
				);

				//query su progettoresponsabiliview con il filtro calcolato
				let self = this;
				return appMeta.getData.runSelect("didprog", "iddidprog,idcorsostudio", filterDidProg)
					.then(function (dt) {
						let filterCorsi = self.q.isIn('idcorsostudio',
							_.map(dt.rows, function (r) {
								return r.idcorsostudio;
							}));
						self.getDataTable('corsostudioelenchiprogerogview').clear();
						var selBuilderArray = [];
						//faccio la query su sql e aggiorno contemporaneamente il dataset
						selBuilderArray.push({ filter: filterCorsi, top: null, tableName: 'corsostudioelenchiprogerogview', table: self.getDataTable('corsostudioelenchiprogerogview') });

						return appMeta.getData.multiRunSelect(selBuilderArray)
							.then(function () {
								var csCtrl = $('#didprog_default_idcorsostudio').data("customController");
								return csCtrl.clearControl();
							})
							.then(function () {
								var csCtrl = $('#didprog_default_idcorsostudio').data("customController");
								return csCtrl.fillControl($('#didprog_default_idcorsostudio'));
							});
					});
			},

			searchAndAssignclassconsorsuale: function (that) {
				return that.searchAndAssign({
					tableName: "classconsorsuale",
					listType: "default",
					idControl: "txt_didprogclassconsorsuale_idclassconsorsuale",
					tagSearch: "classconsorsualedefaultview.dropdown_title",
					columnNameText: "title",
					columnSource: "idclassconsorsuale",
					columnToFill: "idclassconsorsuale",
					tableToFill: "didprogclassconsorsuale"
,
					filter: that.q.eq('classconsorsuale_active', 'Si')
				});
			},

			searchAndAssignregistry: function (that) {
				return that.searchAndAssign({
					tableName: "registry",
					listType: "studenti",
					idControl: "txt_didprograppstud_idreg_studenti",
					tagSearch: "registrystudentiview.dropdown_title",
					columnNameText: "title",
					columnSource: "idreg",
					columnToFill: "idreg_studenti",
					tableToFill: "didprograppstud"
,
					filter: that.q.eq('registry_active', 'Si')
				});
			},

						fireGenerateDidProgCurricula: function (that) {
				var waitingHandler = that.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);
				appMeta.getData.launchCustomServerMethod("callSP", {
					spname: "GenerateDidProgCurricula",
					prm1: that.state.currentRow.iddidprog,
					prm2: appMeta.security.usr('userweb')
				}).then(function (res) {
					var msg = "OK. Sono stati generati i curriculum e le suddivisioni temporali.";
					if (res.err) {
						msg = "KO " + res.err;
					}
					var parentRow = that.state.currentRow;
					var filter = window.jsDataQuery.eq("iddidprog", parentRow.iddidprog);
					var selBuilderArray = [];
					var tableToRefresh = ['attivform'];
					_.forEach(tableToRefresh, function (tname) {
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

			children: ['attivform', 'didprogclassconsorsuale', 'didprogdatepiano', 'didprograppstud', 'iscrizione'],
			haveChildren: function () {
				var self = this;
				return _.some(this.children, function (child) {
					if (child !== '')
						return !!self.getDataTable(child).rows.length;
					else
						return false;
				});
			},

			manageaa: function(that) { 
				var def = appMeta.Deferred("manageYearfilter");
				this.manageCouses().then(function(){ 
					return def.resolve();
				});
				return def.promise();
			},

			manageidcorsostudiokind: function(that) { 
				var def = appMeta.Deferred("managetypefilter");
				this.manageCouses().then(function(){ 
					return def.resolve();
				});
				return def.promise();
			},

			manageidcorsostudiolivello: function(that) { 
				var def = appMeta.Deferred("manageLevelfilter");
				this.manageCouses().then(function(){ 
					return def.resolve();
				});
				return def.promise();

			},

			//buttons
        });

	window.appMeta.addMetaPage('didprog', 'default', metaPage_didprog);

}());
