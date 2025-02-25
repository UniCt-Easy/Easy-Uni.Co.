(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_decadenza() {
		MetaPage.apply(this, ['decadenza', 'seganagstu', true]);
        this.name = 'Decadenza';
		this.defaultListType = 'seganagstu';
		//pageHeaderDeclaration
    }

    metaPage_decadenza.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_decadenza,
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
				var def = appMeta.Deferred("beforeFill-decadenza_seganagstu");
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

			afterClear: function () {
				//parte sincrona
				this.enableControl($('#decadenza_seganagstu_protnumero'), true);
				this.enableControl($('#decadenza_seganagstu_protanno'), true);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				this.enableControl($('#decadenza_seganagstu_protnumero'), false);
				this.enableControl($('#decadenza_seganagstu_protanno'), false);
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

	window.appMeta.addMetaPage('decadenza', 'seganagstu', metaPage_decadenza);

}());
