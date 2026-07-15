(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_convalida() {
		MetaPage.apply(this, ['convalida', 'segmi', true]);
        this.name = 'Convalide';
		this.defaultListType = 'segmi';
		//pageHeaderDeclaration
    }

    metaPage_convalida.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_convalida,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			afterGetFormData: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				if (this.isNull(parentRow.idconvalidakind))
					parentRow.idconvalidakind = 9;
;
				//afterGetFormDataFilter
				
				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-convalida_segmi");
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
				
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-convalida_segmi");
				var arraydef = [];
				
				var dtconvalidante = this.state.DS.tables["convalidante"];
				if (dtconvalidante.rows.length === 0) {
					var metaconvalidante = appMeta.getMeta("convalidante");
					metaconvalidante.setDefaults(dtconvalidante);
					var defconvalidante = metaconvalidante.getNewRow(parentRow.getRow(), dtconvalidante, self.editType).then(
						function (currentRowconvalidante) {
							//defaultconvalidanteObject
							return true;
						}
					);
					arraydef.push(defconvalidante);
				}

				var dtconvalidato = this.state.DS.tables["convalidato"];
				if (dtconvalidato.rows.length === 0) {
					var metaconvalidato = appMeta.getMeta("convalidato");
					metaconvalidato.setDefaults(dtconvalidato);
					var defconvalidato = metaconvalidato.getNewRow(parentRow.getRow(), dtconvalidato, self.editType).then(
						function (currentRowconvalidato) {
							//defaultconvalidatoObject
							return true;
						}
					);
					arraydef.push(defconvalidato);
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

			//afterClear

			//afterFill

			afterLink: function () {
				var self = this;
				appMeta.metaModel.computeRowsAs(this.state.DS.tables.convalidante, "segmi", this.superClass.calculateFields);
				this.helpForm.addExtraEntity("convalidante");
				appMeta.metaModel.computeRowsAs(this.state.DS.tables.convalidato, "segmi", this.superClass.calculateFields);
				this.helpForm.addExtraEntity("convalidato");
				appMeta.metaModel.insertFilter(this.getDataTable("changeskinddefaultview"), this.q.eq('changeskind_active', 'Si'));
				this.state.DS.tables.sostenimentodefaultview.staticFilter(window.jsDataQuery.eq("idreg", this.state.callerState.currentRow.idreg));
				this.state.DS.tables.attivformdefaultview.staticFilter(window.jsDataQuery.eq("iddidprog", this.state.callerState.currentRow.iddidprog));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//beforePost

			//buttons
        });

	window.appMeta.addMetaPage('convalida', 'segmi', metaPage_convalida);

}());
