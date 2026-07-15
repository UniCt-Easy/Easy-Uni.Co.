(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_protocollodoc() {
		MetaPage.apply(this, ['protocollodoc', 'seg', true]);
        this.name = 'Documento';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_protocollodoc.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_protocollodoc,
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
					this.helpForm.filter($('#protocollodoc_seg_idmimetype'), null);
				} else {
					this.helpForm.filter($('#protocollodoc_seg_idmimetype'), this.q.eq('mimetype_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-protocollodoc_seg");
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
				this.helpForm.filter($('#protocollodoc_seg_idmimetype'), null);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			//afterFill

			afterLink: function () {
				var self = this;
				appMeta.metaModel.insertFilter(this.getDataTable("fincaturapositiondefaultview"), this.q.eq('fincaturaposition_active', 'Si'));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//beforePost

			//afterPost

			//buttons
        });

	window.appMeta.addMetaPage('protocollodoc', 'seg', metaPage_protocollodoc);

}());
