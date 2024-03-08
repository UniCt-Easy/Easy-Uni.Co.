(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_didprogporzannokind() {
		MetaPage.apply(this, ['didprogporzannokind', 'default', false]);
        this.name = 'Suddivisione temporale della didattica';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_didprogporzannokind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_didprogporzannokind,
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
				
				if (!parentRow.title)
					parentRow.title = Suddivisione;
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-didprogporzannokind_default");
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

	window.appMeta.addMetaPage('didprogporzannokind', 'default', metaPage_didprogporzannokind);

}());
