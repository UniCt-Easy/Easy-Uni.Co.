(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_cefrlanglevel() {
		MetaPage.apply(this, ['cefrlanglevel', 'accordoscambiomidettlang', true]);
        this.name = 'Livello richiesto per le lingue';
		this.defaultListType = 'accordoscambiomidettlang';
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
				var def = appMeta.Deferred("beforeFill-cefrlanglevel_accordoscambiomidettlang");
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

			afterLink: function () {
				var self = this;
				this.setDenyNull("cefrlanglevel","idaccordoscambiomi");
				this.setDenyNull("cefrlanglevel","idaccordoscambiomidett");
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//beforePost

			//buttons
        });

	window.appMeta.addMetaPage('cefrlanglevel', 'accordoscambiomidettlang', metaPage_cefrlanglevel);

}());
