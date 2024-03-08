(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_relatore() {
		MetaPage.apply(this, ['relatore', 'segistcons', true]);
        this.name = 'Relatori';
		this.defaultListType = 'segistcons';
		//pageHeaderDeclaration
    }

    metaPage_relatore.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_relatore,
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
					this.helpForm.filter($('#relatore_segistcons_idreg_docenti'), null);
				} else {
					this.helpForm.filter($('#relatore_segistcons_idreg_docenti'), this.q.eq('registry_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-relatore_segistcons");
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
				this.helpForm.filter($('#relatore_segistcons_idreg_docenti'), null);
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

	window.appMeta.addMetaPage('relatore', 'segistcons', metaPage_relatore);

}());
