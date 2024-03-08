(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_insegncaratteristica() {
		MetaPage.apply(this, ['insegncaratteristica', 'default', true]);
        this.name = 'Caratteristiche dell\'insegnamento';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_insegncaratteristica.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_insegncaratteristica,
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
				
				if (!parentRow.profess)
					parentRow.profess = "N";
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-insegncaratteristica_default");
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

			//afterClear

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

	window.appMeta.addMetaPage('insegncaratteristica', 'default', metaPage_insegncaratteristica);

}());
