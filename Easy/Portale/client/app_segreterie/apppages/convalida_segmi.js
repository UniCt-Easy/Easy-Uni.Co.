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

			//afterGetFormData
			
			beforeFill: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-convalida_segmi");
				var arraydef = [];
				
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
				appMeta.metaModel.computeRowsAs(this.state.DS.tables.convalidato, "segmi", this.superClass.calculateFields);
				this.helpForm.addExtraEntity("convalidato");
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

			//buttons
        });

	window.appMeta.addMetaPage('convalida', 'segmi', metaPage_convalida);

}());
