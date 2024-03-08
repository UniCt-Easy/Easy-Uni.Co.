(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_sasd() {
		MetaPage.apply(this, ['sasd', 'default', false]);
        this.name = 'Settori artistico-scientifico disciplinari';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_sasd.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_sasd,
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
					this.helpForm.filter($('#sasd_default_idareadidattica'), null);
				} else {
					this.helpForm.filter($('#sasd_default_idareadidattica'), this.q.eq('areadidattica_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-sasd_default");
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
				this.helpForm.filter($('#sasd_default_idareadidattica'), null);
				//afterClearin
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

	window.appMeta.addMetaPage('sasd', 'default', metaPage_sasd);

}());
