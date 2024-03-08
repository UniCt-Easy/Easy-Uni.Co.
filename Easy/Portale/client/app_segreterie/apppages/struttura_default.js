(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_struttura() {
		MetaPage.apply(this, ['struttura', 'default', false]);
        this.name = 'Struttura / Unità organizzativa';
		this.defaultListType = 'default';
		this.isList = true;
		this.isTree = true;
		//pageHeaderDeclaration
    }

    metaPage_struttura.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_struttura,
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
				
				appMeta.metaModel.getTemporaryValues(this.getDataTable('afferenza'));
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#struttura_default_idupb'), null);
				} else {
					this.helpForm.filter($('#struttura_default_idupb'), this.q.eq('upb_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-struttura_default");
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
				this.helpForm.filter($('#struttura_default_idupb'), null);
				//afterClearin
			},

			//afterFill

			afterLink: function () {
				var self = this;
				this.state.DS.tables.struttura.defaults({ 'active': 'S' });
				this.state.DS.tables.struttura.defaults({ 'idreg': this.idreg_istituto });
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

			beforeSelectTreeManager: function () {
				var def = appMeta.Deferred('beforeSelectTreeManager');
				return def.resolve(true);
			},

			//buttons
        });

	window.appMeta.addMetaPage('struttura', 'default', metaPage_struttura);

}());
