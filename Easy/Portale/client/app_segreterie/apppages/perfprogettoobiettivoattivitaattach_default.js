(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfprogettoobiettivoattivitaattach() {
		MetaPage.apply(this, ['perfprogettoobiettivoattivitaattach', 'default', true]);
        this.name = 'Allegati';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfprogettoobiettivoattivitaattach.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfprogettoobiettivoattivitaattach,
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
				
				if (this.isNull(parentRow.data))
					parentRow.data = new Date();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-perfprogettoobiettivoattivitaattach_default");
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

			afterFill: function () {
				this.enableControl($('#perfprogettoobiettivoattivitaattach_default_data'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			//afterLink

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//beforePost

			//buttons
        });

	window.appMeta.addMetaPage('perfprogettoobiettivoattivitaattach', 'default', metaPage_perfprogettoobiettivoattivitaattach);

}());
