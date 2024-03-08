(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_studdirittokind() {
		MetaPage.apply(this, ['studdirittokind', 'default', false]);
        this.name = 'Categoria dello studente per il diritto allo studio';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_studdirittokind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_studdirittokind,
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
					parentRow.active = "S";
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-studdirittokind_default");
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

			//buttons
        });

	window.appMeta.addMetaPage('studdirittokind', 'default', metaPage_studdirittokind);

}());
