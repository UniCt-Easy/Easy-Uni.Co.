(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_sessionekind() {
		MetaPage.apply(this, ['sessionekind', 'default', false]);
        this.name = 'Tipologie di sessione';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_sessionekind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_sessionekind,
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
					parentRow.active = 'S';
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-sessionekind_default");
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

	window.appMeta.addMetaPage('sessionekind', 'default', metaPage_sessionekind);

}());
