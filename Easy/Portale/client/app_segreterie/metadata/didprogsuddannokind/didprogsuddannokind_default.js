(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_didprogsuddannokind() {
		MetaPage.apply(this, ['didprogsuddannokind', 'default', false]);
        this.name = 'Suddivisione dell\'anno';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_didprogsuddannokind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_didprogsuddannokind,
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
				
				if (!parentRow.active)
					parentRow.active = Attiva;
				if (!parentRow.sortcode)
					parentRow.sortcode = Ordinamento;
				if (!parentRow.title)
					parentRow.title = Tipo;
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-didprogsuddannokind_default");
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

	window.appMeta.addMetaPage('didprogsuddannokind', 'default', metaPage_didprogsuddannokind);

}());
