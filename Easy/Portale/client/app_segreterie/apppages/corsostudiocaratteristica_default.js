(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_corsostudiocaratteristica() {
		MetaPage.apply(this, ['corsostudiocaratteristica', 'default', true]);
        this.name = 'Caratteristiche del corso di studio';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_corsostudiocaratteristica.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_corsostudiocaratteristica,
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
				
				if (!parentRow.obblig)
					parentRow.obblig = "N";
				if (!parentRow.profess)
					parentRow.profess = "N";
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-corsostudiocaratteristica_default");
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

	window.appMeta.addMetaPage('corsostudiocaratteristica', 'default', metaPage_corsostudiocaratteristica);

}());
