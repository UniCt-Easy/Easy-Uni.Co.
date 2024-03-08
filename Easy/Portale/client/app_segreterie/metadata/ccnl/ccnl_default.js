(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_ccnl() {
		MetaPage.apply(this, ['ccnl', 'default', false]);
        this.name = 'Contratti Collettivi Nazionali del Lavoro';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_ccnl.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_ccnl,
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
				
				if (self.isNullOrMinDate(parentRow.stipula))
					parentRow.stipula = new Date();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-ccnl_default");
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

	window.appMeta.addMetaPage('ccnl', 'default', metaPage_ccnl);

}());
