(function () {

	var MetaPage = window.appMeta.MetaSegreteriePage;

	function metaPage_perfprogettoobiettivoattivita() {
		MetaPage.apply(this, ['perfprogettoobiettivoattivita', 'default', true]);
		this.name = 'Attività';
		this.defaultListType = 'default';
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
	}

	metaPage_perfprogettoobiettivoattivita.prototype = _.extend(
		new MetaPage(),
		{
			constructor: metaPage_perfprogettoobiettivoattivita,
			superClass: MetaPage.prototype,

			getName: function () {
				return this.name;
			},

			manageValidResult: function (rowToCheck) {
				var loc = appMeta.localResource;
				var def = appMeta.Deferred("isValid-meta_perfprogettoobiettivoattivita");
				var firstErrorObj;

				if (this.getChildren("perfprogettoobiettivoattivita", rowToCheck.current.idperfprogettoobiettivoattivita, "paridperfprogettoobiettivoattivita", true).length == 0) {
					if (!rowToCheck.current.datainizioprevista)
						firstErrorObj = { warningMsg: "", errMsg: "Prima devi inserire una data inizio prevista", errField: "datainizioprevista", row: rowToCheck };
					else if (!rowToCheck.current.datafineprevista)
						firstErrorObj = { warningMsg: "", errMsg: "Prima devi inserire una data  fine prevista", errField: "datafineprevista", row: rowToCheck };
				}


				if (!firstErrorObj) {
					if (rowToCheck.current.datainizioprevista && rowToCheck.current.datafineprevista && rowToCheck.current.datainizioprevista > rowToCheck.current.datafineprevista)
						firstErrorObj = { warningMsg: "", errMsg: "La data fine prevista deve essere successiva alla data inizio prevista", errField: "datafineprevista", row: rowToCheck };

					if (rowToCheck.current.datainizioeffettiva && rowToCheck.current.datafineeffettiva && rowToCheck.current.datainizioeffettiva > rowToCheck.current.datafineeffettiva)
						firstErrorObj = { warningMsg: "", errMsg: "La data fine effettiva deve essere successiva alla data inizio effettiva", errField: "datafineeffettiva", row: rowToCheck };
				}
				return def.resolve(firstErrorObj);
				//$isValid$

				return MetaPage.prototype.manageValidResult.call(this, rowToCheck);
			},

			afterGetFormData: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;

				//afterGetFormDataFilter

				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-perfprogettoobiettivoattivita_default");
				var arraydef = [];

				arraydef.push(this.manageperfprogettoobiettivoattivita_default_completamento());
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

				this.manageperfprogettoobiettivoattivita_default_completamento();
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#perfprogettoobiettivoattivita_default_idupb'), null);
				} else {
					this.helpForm.filter($('#perfprogettoobiettivoattivita_default_idupb'), this.q.eq('upb_active', 'Si'));
				}
				//beforeFillFilter

				//parte asincrona
				var def = appMeta.Deferred("beforeFill-perfprogettoobiettivoattivita_default");
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
				this.helpForm.filter($('#perfprogettoobiettivoattivita_default_idupb'), null);
				//afterClearin

				//afterClearInAsyncBase
			},

			afterFill: function () {
				this.enableControl($("#XXperfprogettoattivitainterazione"), this.state.isEditState());
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;

				$("#XXperfprogettoattivitainterazione").prop("disabled", true);
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					arraydef.push(self.setFilterPerfprogettoobiettivoattivita_default_idreg());
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			//afterRowSelect

			//afterActivation

			//rowSelected

			buttonClickEnd: function (currMetaPage, cmd) {
				if ($("#XXperfprogettoattivitainterazione").length) {
					$("#XXperfprogettoattivitainterazione").prop("disabled", !currMetaPage.state.isEditState());
				}
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			//insertClick

			//beforePost

			setFilterPerfprogettoobiettivoattivita_default_idreg: function () {
				var def = appMeta.Deferred('setFilterPerfprogettoobiettivoattivita_default_idreg');
				var self = this;
				if (self.state.callerState.callerPage) {
					var filter = self.q.isIn('idreg',
						_.map(self.state.callerState.callerPage.getDataTable("perfprogettouomembro").rows, function (r) { return r.idreg; })
					);
					self.state.DS.tables.getregistrydocentiamministratividefaultview.staticFilter(filter);
					return def.resolve();
				} else {
					var filterMembro = this.q.eq("idperfprogetto", self.state.currentRow.idperfprogetto);
					return appMeta.getData.runSelect("perfprogettouomembro", "idreg", filterMembro)
						.then(function (dtMembro) {
							var filter = self.q.isIn('idreg',
								_.map(dtMembro.rows, function (r) { return r.idreg; })
							);
							self.state.DS.tables.getregistrydocentiamministratividefaultview.staticFilter(filter);
							return def.resolve();
						});
				}
			},

			manageperfprogettoobiettivoattivita_default_completamento: function () {
				//campo calcolato
				this.enableControl($('#perfprogettoobiettivoattivita_default_completamento'), false);
				if (this.state.formState === "insert" || this.getChildren("perfprogettoobiettivoattivita", this.state.currentRow.idperfprogettoobiettivoattivita, "paridperfprogettoobiettivoattivita", true).length == 0) {
					this.enableControl($('#perfprogettoobiettivoattivita_default_completamento'), true);
				}
			},

			//buttons
		});

	window.appMeta.addMetaPage('perfprogettoobiettivoattivita', 'default', metaPage_perfprogettoobiettivoattivita);

}());
