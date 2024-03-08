(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_prova() {
		MetaPage.apply(this, ['prova', 'default', true]);
        this.name = 'Prove';
		this.defaultListType = 'default';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_prova.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_prova,
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
				
				if (self.isNullOrMinDate(parentRow.start))
					parentRow.start = new Date();
				if (self.isNullOrMinDate(parentRow.stop))
					parentRow.stop = new Date();
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#commiss_default_idreg_docenti'), null);
				} else {
					this.helpForm.filter($('#commiss_default_idreg_docenti'), this.q.eq('registry_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-prova_default");
				var arraydef = [];
				
				var dtcommiss = this.state.DS.tables["commiss"];
				if (dtcommiss.rows.length === 0) {
					var metacommiss = appMeta.getMeta("commiss");
					metacommiss.setDefaults(dtcommiss);
					var defcommiss = metacommiss.getNewRow(parentRow.getRow(), dtcommiss, self.editType).then(
						function (currentRowcommiss) {
							//defaultcommissObject
							return true;
						}
					);
					arraydef.push(defcommiss);
				}

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
				this.helpForm.filter($('#commiss_default_idreg_docenti'), null);
				//afterClearin
			},

			//afterFill

			afterLink: function () {
				var self = this;
				appMeta.metaModel.computeRowsAs(this.state.DS.tables.commiss, "default", this.superClass.calculateFields);
				this.helpForm.addExtraEntity("commiss");
				$("#btn_add_provaaula_idaula").on("click", _.partial(this.searchAndAssignaula, self));
				$("#btn_add_provaaula_idaula").prop("disabled", true);
				$("#btn_add_commissregistry_docenti_idreg_docenti").on("click", _.partial(this.searchAndAssignregistry_docenti, self));
				$("#btn_add_commissregistry_docenti_idreg_docenti").prop("disabled", true);
				this.setDenyNull("prova","title");
				this.setDenyNull("prova","start");
				this.setDenyNull("prova","stop");
				$('#grid_sostenimento_default').data('mdlconditionallookup', 'livello,A,A ;livello,B,B ;livello,C,C ;livello,D,D ;votolode,S,Si;votolode,N,No;');
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
				$("#btn_add_provaaula_idaula").prop("disabled", false);
				$("#btn_add_commissregistry_docenti_idreg_docenti").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#btn_add_provaaula_idaula").prop("disabled", true);
					$("#btn_add_commissregistry_docenti_idreg_docenti").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			//insertClick

			//beforePost

			searchAndAssignaula: function (that) {
				return that.searchAndAssign({
					tableName: "aula",
					listType: "default",
					idControl: "txt_provaaula_idaula",
					tagSearch: "auladefaultview.dropdown_title",
					columnNameText: "title",
					columnSource: "idaula",
					columnToFill: "idaula",
					tableToFill: "provaaula"
				});
			},

			searchAndAssignregistry_docenti: function (that) {
				return that.searchAndAssign({
					tableName: "registry",
					listType: "docenti",
					idControl: "txt_commissregistry_docenti_idreg_docenti",
					tagSearch: "registrydocentiview.dropdown_title",
					columnNameText: "title",
					columnSource: "idreg",
					columnToFill: "idreg_docenti",
					tableToFill: "commissregistry_docenti",
					parentRow: that.state.DS.tables.commiss.rows[0]
				});
			},

			//buttons
        });

	window.appMeta.addMetaPage('prova', 'default', metaPage_prova);

}());
