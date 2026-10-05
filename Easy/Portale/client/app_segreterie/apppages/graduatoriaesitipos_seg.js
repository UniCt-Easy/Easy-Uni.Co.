(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_graduatoriaesitipos() {
		MetaPage.apply(this, ['graduatoriaesitipos', 'seg', true]);
        this.name = 'Esito';
		this.defaultListType = 'seg';
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
					this.helpForm.filter($('#graduatoriaesitipos_seg_idreg_studenti'), null);
				} else {
					this.helpForm.filter($('#graduatoriaesitipos_seg_idreg_studenti'), this.q.eq('registry_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-graduatoriaesitipos_seg");
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
				this.helpForm.filter($('#graduatoriaesitipos_seg_idreg_studenti'), null);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			//afterFill

			afterLink: function () {
				var self = this;
				this.setDenyNull("graduatoriaesitipos","idreg_studenti");
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

	window.appMeta.addMetaPage('graduatoriaesitipos', 'seg', metaPage_graduatoriaesitipos);

}());
