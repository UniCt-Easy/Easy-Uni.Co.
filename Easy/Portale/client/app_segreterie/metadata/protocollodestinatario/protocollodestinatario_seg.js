(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_protocollodestinatario() {
		MetaPage.apply(this, ['protocollodestinatario', 'seg', true]);
        this.name = 'Destinatari';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_protocollodestinatario.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_protocollodestinatario,
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
				
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#protocollodestinatario_seg_idreg_dest'), null);
				} else {
					this.helpForm.filter($('#protocollodestinatario_seg_idreg_dest'), this.q.eq('registry_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-protocollodestinatario_seg");
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
				this.helpForm.filter($('#protocollodestinatario_seg_idreg_dest'), null);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			//afterFill

			//afterLink

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//beforePost

			//afterPost

			//buttons
        });

	window.appMeta.addMetaPage('protocollodestinatario', 'seg', metaPage_protocollodestinatario);

}());
