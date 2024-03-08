(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_tassaiscrizioneconf() {
		MetaPage.apply(this, ['tassaiscrizioneconf', 'default', false]);
        this.name = 'Definizione delle tasse di iscrizione';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_tassaiscrizioneconf.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_tassaiscrizioneconf,
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
				
				if (!parentRow.corsisingoli)
					parentRow.corsisingoli = 'N';
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-tassaiscrizioneconf_default");
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

	window.appMeta.addMetaPage('tassaiscrizioneconf', 'default', metaPage_tassaiscrizioneconf);

}());
