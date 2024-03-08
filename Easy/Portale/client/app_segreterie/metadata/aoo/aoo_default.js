(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_aoo() {
		MetaPage.apply(this, ['aoo', 'default', false]);
        this.name = 'Aree organizzative omogenee';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_aoo.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_aoo,
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
				
				if (!parentRow.idreg)
					parentRow.idreg = this.idreg_istituto;
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-aoo_default");
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

	window.appMeta.addMetaPage('aoo', 'default', metaPage_aoo);

}());
