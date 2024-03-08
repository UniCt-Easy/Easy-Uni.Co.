(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_cefrlanglevel() {
		MetaPage.apply(this, ['cefrlanglevel', 'default', true]);
        this.name = 'Livello richiesto per le lingue';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_cefrlanglevel.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_cefrlanglevel,
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
				
				if (!parentRow.idaccordoscambiomidettlangkind)
					parentRow.idaccordoscambiomidettlangkind = 1;
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-cefrlanglevel_default");
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

	window.appMeta.addMetaPage('cefrlanglevel', 'default', metaPage_cefrlanglevel);

}());
