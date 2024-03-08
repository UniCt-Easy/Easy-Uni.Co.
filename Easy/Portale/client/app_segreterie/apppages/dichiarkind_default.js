(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_dichiarkind() {
		MetaPage.apply(this, ['dichiarkind', 'default', false]);
        this.name = 'Tipi di dichiarazione';
		this.defaultListType = 'default';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		//pageHeaderDeclaration
    }

    metaPage_dichiarkind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_dichiarkind,
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
				var def = appMeta.Deferred("beforeFill-dichiarkind_default");
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

	window.appMeta.addMetaPage('dichiarkind', 'default', metaPage_dichiarkind);

}());
