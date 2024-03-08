(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_canale() {
		MetaPage.apply(this, ['canale', 'default', true]);
        this.name = 'Canali';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_canale.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_canale,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			afterGetFormData: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				//afterGetFormDataFilter
				
				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-canale_default");
				var arraydef = [];
				
				arraydef.push(this.managecanale_default_idsede());
				//afterGetFormDataInside
				
				$.when.apply($, arraydef)
					.then(function () {
						return def.resolve();
					});
				return def.promise();
			},
			
			beforeFill: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				this.managecanale_default_idsede();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-canale_default");
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

			managecanale_default_idsede: function () {
this.state.currentRow.idsede= this.state.callerState.currentRow.idsede;
			},

			//buttons
        });

	window.appMeta.addMetaPage('canale', 'default', metaPage_canale);

}());
