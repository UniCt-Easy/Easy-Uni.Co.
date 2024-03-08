(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_insegnintegcaratteristica() {
		MetaPage.apply(this, ['insegnintegcaratteristica', 'default', true]);
        this.name = 'Caratteristiche degli insegnamenti integrandi';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_insegnintegcaratteristica.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_insegnintegcaratteristica,
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
				var def = appMeta.Deferred("beforeFill-insegnintegcaratteristica_default");
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

	window.appMeta.addMetaPage('insegnintegcaratteristica', 'default', metaPage_insegnintegcaratteristica);

}());
