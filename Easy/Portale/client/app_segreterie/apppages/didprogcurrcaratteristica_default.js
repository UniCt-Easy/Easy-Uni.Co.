(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_didprogcurrcaratteristica() {
		MetaPage.apply(this, ['didprogcurrcaratteristica', 'default', true]);
        this.name = 'Caratteristiche del curriculum';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_didprogcurrcaratteristica.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_didprogcurrcaratteristica,
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
				var def = appMeta.Deferred("beforeFill-didprogcurrcaratteristica_default");
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

	window.appMeta.addMetaPage('didprogcurrcaratteristica', 'default', metaPage_didprogcurrcaratteristica);

}());
