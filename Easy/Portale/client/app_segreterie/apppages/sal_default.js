(function () {

	var MetaPage = window.appMeta.MetaSegreteriePage;

	function metaPage_sal() {
		MetaPage.apply(this, ['sal', 'default', false]);
		this.name = 'Stato avanzamento lavori';
		this.defaultListType = 'default';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
	}

	metaPage_sal.prototype = _.extend(
		new MetaPage(),
		{
			constructor: metaPage_sal,
			superClass: MetaPage.prototype,

			getName: function () {
				return this.name;
			},

			//isValidFunction

			afterGetFormData: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;

				this.setFilters();
				//afterGetFormDataFilter

				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-sal_default");
				var arraydef = [];

				arraydef.push(this.managesal_default_budgetcalcolato());
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

				this.setFilters();
				parentRow.idprogetto = this.state.callerState.currentRow.idprogetto;
				this.managesal_default_budgetcalcolato();
				//beforeFillFilter

				//parte asincrona
				var def = appMeta.Deferred("beforeFill-sal_default");
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
				this.enableControl($('#sal_default_budgetcalcolato'), true);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('salprogettoassetworkpackage'), this.getDataTable('salprogettoassetworkpackagemese'));
				//afterClearin

				//afterClearInAsyncBase
			},

			afterFill: function () {
				this.enableControl($('#sal_default_budgetcalcolato'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('salprogettoassetworkpackage'), this.getDataTable('salprogettoassetworkpackagemese'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$("#btn_add_salassetdiaryora_idassetdiaryora").on("click", _.partial(this.searchAndAssignassetdiaryora, self));
				$("#btn_add_salassetdiaryora_idassetdiaryora").prop("disabled", true);
				$("#btn_add_salrendicontattivitaprogettoora_idrendicontattivitaprogettoora").on("click", _.partial(this.searchAndAssignrendicontattivitaprogettoora, self));
				$("#btn_add_salrendicontattivitaprogettoora_idrendicontattivitaprogettoora").prop("disabled", true);
				$("#btn_add_salprogettocosto_idprogettocosto").on("click", _.partial(this.searchAndAssignprogettocosto, self));
				$("#btn_add_salprogettocosto_idprogettocosto").prop("disabled", true);
				var f1 = window.jsDataQuery.eq("idprogetto", this.state.callerState.currentRow.idprogetto);
				self.firstSearchFilter = f1;
				self.startFilter = self.firstSearchFilter;
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
				$("#btn_add_salassetdiaryora_idassetdiaryora").prop("disabled", false);
				$("#btn_add_salrendicontattivitaprogettoora_idrendicontattivitaprogettoora").prop("disabled", false);
				$("#btn_add_salprogettocosto_idprogettocosto").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#btn_add_salassetdiaryora_idassetdiaryora").prop("disabled", true);
					$("#btn_add_salrendicontattivitaprogettoora_idrendicontattivitaprogettoora").prop("disabled", true);
					$("#btn_add_salprogettocosto_idprogettocosto").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			//insertClick


			beforePost: function () {
				var self = this;

				//per ogni riga collegata ...
				this.state.DS.tables['progettocosto']
					//....dalle righe della tabella di collegamento...
					.select(window.jsDataQuery.isIn('idprogettocosto', _.map(self.getDataTable('salprogettocosto').rows, function (row) {
						return row['idprogettocosto'];
					}))).forEach(function (row) {
						//...associo il sal corrente se non cel'ha
						if (!row.idsal)
							row.idsal = self.state.currentRow.idsal;
					});

				//per ogni riga collegata ...
				this.state.DS.tables['rendicontattivitaprogettoora']
					//....dalle righe della tabella di collegamento...
					.select(window.jsDataQuery.isIn('idrendicontattivitaprogettoora', _.map(self.getDataTable('salrendicontattivitaprogettoora').rows, function (row) {
						return row['idrendicontattivitaprogettoora'];
					}))).forEach(function (row) {
						//...associo il sal corrente se non cel'ha
						if (!row.idsal)
							row.idsal = self.state.currentRow.idsal;
					});

				//per ogni riga collegata ...
				this.state.DS.tables['assetdiaryora']
					//....dalle righe della tabella di collegamento...
					.select(window.jsDataQuery.isIn('idassetdiaryora', _.map(self.getDataTable('salassetdiaryora').rows, function (row) {
						return row['idassetdiaryora'];
					}))).forEach(function (row) {
						//...associo il sal corrente se non cel'ha
						if (!row.idsal)
							row.idsal = self.state.currentRow.idsal;
					});

			},

			setFilters: function () {
				var metaPage = window.appMeta.currApp.currentMetaPage;
				var q = window.jsDataQuery;
				var self = this;

				if (metaPage.state.callerState.DS.tables.length) {
					metaPage.state.DS.tables.assetdiaryora.staticFilter(q.isIn('idassetdiary',
						_.map(metaPage.state.callerState.DS.tables.assetdiary.rows, function (row) {
							return row['idassetdiary'];
						})));
					metaPage.state.DS.tables.rendicontattivitaprogettoora.staticFilter(q.and[q.isIn('idrendicontattivitaprogetto',
						_.map(self.getDataTable('rendicontattivitaprogetto').rows, function (row) {
							return row['idrendicontattivitaprogetto'];
						})), q.le('data', this.state.currentRow.stop ? this.state.currentRow.stop : new Date()), q.ge('data', this.state.currentRow.start ? this.state.currentRow.start : new Date())]);
				}
				metaPage.state.DS.tables.progettocosto.staticFilter(q.eq("idprogetto", metaPage.state.callerState.currentRow.idprogetto));
			},

			searchAndAssignassetdiaryora: function (that) {
				var q = window.jsDataQuery;

				return appMeta.getData.runSelect("assetdiary", "idassetdiary", q.eq("idprogetto", that.state.currentRow.idprogetto), null)
					.then(function (dtAttivita) {
						var attivita = _.map(dtAttivita.rows, function (row) {
							return row['idassetdiary'];
						});
						var f = q.and(
							q.isIn('idassetdiary', attivita),
							q.le('assetdiaryora_start', that.state.currentRow.stop ? that.state.currentRow.stop : new Date()),
							q.ge('assetdiaryora_stop', that.state.currentRow.start ? that.state.currentRow.start : new Date())
						);
						return that.searchAndAssign({
							tableName: "assetdiaryora",
							listType: "segsal",
							idControl: "txt_salassetdiaryora_idassetdiaryora",
							tagSearch: "assetdiaryorasegsalview.dropdown_title",
							columnNameText: "idassetdiary",
							columnSource: "idassetdiaryora",
							columnToFill: "idassetdiaryora",
							tableToFill: "salassetdiaryora",
							filter: f
						});
					});
			},

			searchAndAssignrendicontattivitaprogettoora: function (that) {
				var q = window.jsDataQuery;

				return appMeta.getData.runSelect("rendicontattivitaprogetto", "idrendicontattivitaprogetto", q.eq("idprogetto", that.state.currentRow.idprogetto), null)
					.then(function (dtAttivita) {
						var attivita = _.map(dtAttivita.rows, function (row) {
							return row['idrendicontattivitaprogetto'];
						});
						var f = q.and(
							q.isIn('idrendicontattivitaprogetto', attivita),
							q.le('rendicontattivitaprogettoora_data', that.state.currentRow.stop ? that.state.currentRow.stop : new Date()),
							q.ge('rendicontattivitaprogettoora_data', that.state.currentRow.start ? that.state.currentRow.start : new Date())
						);
						return that.searchAndAssign({
							tableName: "rendicontattivitaprogettoora",
							listType: "segsal",
							idControl: "txt_salrendicontattivitaprogettoora_idrendicontattivitaprogettoora",
							tagSearch: "rendicontattivitaprogettoorasegsalview.dropdown_title",
							columnNameText: "!titleancestor",
							columnSource: "idrendicontattivitaprogettoora",
							columnToFill: "idrendicontattivitaprogettoora",
							tableToFill: "salrendicontattivitaprogettoora",
							filter: f
						});
					});
			},

			searchAndAssignprogettocosto: function (that) {
				var q = window.jsDataQuery;
				var f = q.and(
					q.eq('idprogetto', that.state.currentRow.idprogetto),
					q.le('progettocosto_docdate', that.state.currentRow.stop ? that.state.currentRow.stop : new Date()),
					q.ge('progettocosto_docdate', that.state.currentRow.start ? that.state.currentRow.start : new Date())
				);
				return that.searchAndAssign({
					tableName: "progettocosto",
					listType: "segsal",
					idControl: "txt_salprogettocosto_idprogettocosto",
					tagSearch: "progettocostosegsalview.dropdown_title",
					columnNameText: "idprogettotipocosto",
					columnSource: "idprogettocosto",
					columnToFill: "idprogettocosto",
					tableToFill: "salprogettocosto",
					filter: f
				});
			},

			managesal_default_budgetcalcolato: function () {
				var self = window.appMeta.currApp.currentMetaPage;
				var progettocostoRows = self.getDataTable("progettocosto").select(
					self.q.eq('idsal', self.state.currentRow.idsal)
				);

				self.state.currentRow['!budgetcalcolato'] = _.sumBy(progettocostoRows, function (r) {
					return r.amount;
				});
			},

			//buttons
		});

	window.appMeta.addMetaPage('sal', 'default', metaPage_sal);

}());
