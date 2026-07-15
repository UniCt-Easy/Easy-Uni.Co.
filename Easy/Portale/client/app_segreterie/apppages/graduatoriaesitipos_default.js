(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_graduatoriaesitipos() {
		MetaPage.apply(this, ['graduatoriaesitipos', 'default', true]);
        this.name = 'Esiti';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_graduatoriaesitipos.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_graduatoriaesitipos,
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
					this.helpForm.filter($('#graduatoriaesitipos_default_idreg_studenti'), null); 
				} else {
					this.helpForm.filter($('#graduatoriaesitipos_default_idreg_studenti'), this.q.eq('registry_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-graduatoriaesitipos_default");
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
				this.helpForm.filter($('#graduatoriaesitipos_default_idreg_studenti'), null);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			//afterFill

			//afterLink

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//beforePost

			//buttons
        });

	window.appMeta.addMetaPage('graduatoriaesitipos', 'default', metaPage_graduatoriaesitipos);

}());
