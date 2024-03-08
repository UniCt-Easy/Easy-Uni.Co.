(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_progettoricavo() {
		MetaPage.apply(this, ['progettoricavo', 'default', true]);
        this.name = 'Dettaglio dei ricavi';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_progettoricavo.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_progettoricavo,
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
					this.helpForm.filter($('#progettoricavo_default_idposition'), null);
				} else {
					this.helpForm.filter($('#progettoricavo_default_idposition'), this.q.eq('position_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-progettoricavo_default");
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
				this.helpForm.filter($('#progettoricavo_default_idposition'), null);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			//afterFill

			afterLink: function () {
				var self = this;
				this.setFilterProgettobudget_seg_idworkpackage_idprogettotipocosto();
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

			setFilterProgettobudget_seg_idworkpackage_idprogettotipocosto: function () {
				var self = this;
				var filter = self.q.eq('idprogetto', self.state.callerState.currentRow.idprogetto);
				self.state.DS.tables.workpackagesegview.staticFilter(filter);
				self.state.DS.tables.progettotipocosto.staticFilter(filter);
				self.state.DS.tables.saldefaultview.staticFilter(filter);
			},

			//buttons
        });

	window.appMeta.addMetaPage('progettoricavo', 'default', metaPage_progettoricavo);

}());
