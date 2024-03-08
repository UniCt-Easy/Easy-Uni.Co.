(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_sospensione() {
		MetaPage.apply(this, ['sospensione', 'sedi', true]);
        this.name = 'Sospensione delle attività';
		this.defaultListType = 'sedi';
		//pageHeaderDeclaration
    }

    metaPage_sospensione.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_sospensione,
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
				
				if (self.isNullOrMinDate(parentRow.start))
					parentRow.start = new Date();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-sospensione_sedi");
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

	window.appMeta.addMetaPage('sospensione', 'sedi', metaPage_sospensione);

}());
