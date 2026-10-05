(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_esonero() {
		MetaPage.apply(this, ['esonero', 'titolostudio', false]);
        this.name = 'Definizione degli esoneri per titoli di studio conseguiti';
		this.defaultListType = 'titolostudio';
		//pageHeaderDeclaration
    }

    metaPage_esonero.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_esonero,
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
				
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#esonero_titolostudio_default_idstruttura'), null);
				} else {
					this.helpForm.filter($('#esonero_titolostudio_default_idstruttura'), this.q.eq('struttura_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-esonero_titolostudio_titolostudio");
				var arraydef = [];
				
				var dt = this.state.DS.tables["esonero_titolostudio"];
				if (dt.rows.length === 0) {
					var meta = appMeta.getMeta("esonero_titolostudio");
					meta.setDefaults(dt);
					var defesonero_titolostudio = meta.getNewRow(parentRow.getRow(), dt, self.editType).then(
						function (currentRowtitolostudio) {
							//defaultExtendingObject
							return true;
						}
					);
					arraydef.push(defesonero_titolostudio);
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
				//parte sincrona
				this.helpForm.filter($('#esonero_titolostudio_default_idstruttura'), null);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			//afterFill

			afterLink: function () {
				var self = this;
				appMeta.metaModel.insertFilter(this.getDataTable("esoneroanskind"), this.q.eq('active', 'S'));
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

	window.appMeta.addMetaPage('esonero', 'titolostudio', metaPage_esonero);

}());
