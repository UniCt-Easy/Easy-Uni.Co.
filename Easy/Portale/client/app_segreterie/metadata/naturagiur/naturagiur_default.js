(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_naturagiur() {
		MetaPage.apply(this, ['naturagiur', 'default', false]);
        this.name = 'Natura giuridica';
		this.defaultListType = 'default';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		//pageHeaderDeclaration
    }

    metaPage_naturagiur.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_naturagiur,
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
				
				if (!parentRow.flagforeign)
					parentRow.flagforeign = 'N';
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-naturagiur_default");
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

	window.appMeta.addMetaPage('naturagiur', 'default', metaPage_naturagiur);

}());
