(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_attivformproped() {
		MetaPage.apply(this, ['attivformproped', 'default', true]);
        this.name = 'Propedeuticità';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_attivformproped.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_attivformproped,
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
				
				if (!parentRow.alternativa)
					parentRow.alternativa = 1;
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-attivformproped_default");
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

	window.appMeta.addMetaPage('attivformproped', 'default', metaPage_attivformproped);

}());
