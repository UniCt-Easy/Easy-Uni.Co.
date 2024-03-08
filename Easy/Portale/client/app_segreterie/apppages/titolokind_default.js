(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_titolokind() {
		MetaPage.apply(this, ['titolokind', 'default', false]);
        this.name = 'Tipologia del titolo di studio';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_titolokind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_titolokind,
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
					parentRow.active = Attivo;
				if (!parentRow.sortcode)
					parentRow.sortcode = Ordinamento;
				if (!parentRow.title)
					parentRow.title = Descrizione;
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-titolokind_default");
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

	window.appMeta.addMetaPage('titolokind', 'default', metaPage_titolokind);

}());
