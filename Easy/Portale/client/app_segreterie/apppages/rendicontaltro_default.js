(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_rendicontaltro() {
		MetaPage.apply(this, ['rendicontaltro', 'default', true]);
        this.name = 'Registro delle attività oltre le lezioni della scheda di rendicontazione / registro elettronico';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_rendicontaltro.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_rendicontaltro,
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
				
				if (self.isNullOrMinDate(parentRow.data))
					parentRow.data = new Date();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-rendicontaltro_default");
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

	window.appMeta.addMetaPage('rendicontaltro', 'default', metaPage_rendicontaltro);

}());
