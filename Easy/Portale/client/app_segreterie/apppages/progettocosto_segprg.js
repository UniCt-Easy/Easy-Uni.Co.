(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_progettocosto() {
		MetaPage.apply(this, ['progettocosto', 'segprg', false]);
        this.name = 'Dettaglio dei costi';
		this.defaultListType = 'segprg';
		//pageHeaderDeclaration
    }

    metaPage_progettocosto.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_progettocosto,
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
				
				parentRow.idprogetto = this.state.callerState.currentRow.idprogetto;
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#progettocosto_segprg_idposition'), null);
				} else {
					this.helpForm.filter($('#progettocosto_segprg_idposition'), this.q.eq('position_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#progettocosto_segprg_idpettycash'), null);
				} else {
					this.helpForm.filter($('#progettocosto_segprg_idpettycash'), this.q.eq('pettycash_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-progettocosto_segprg");
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
				this.enableControl($('#progettocosto_segprg_idrelated'), true);
				this.helpForm.filter($('#progettocosto_segprg_idposition'), null);
				this.helpForm.filter($('#progettocosto_segprg_idpettycash'), null);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				this.enableControl($('#progettocosto_segprg_idrelated'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				this.setFilterProgettobudget_seg_idworkpackage_idprogettotipocosto();
				var f1 = window.jsDataQuery.eq("idprogetto", this.state.callerState.currentRow.idprogetto);
				self.firstSearchFilter  = f1;
					self.startFilter = self.firstSearchFilter;
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
				var filter = self.q.eq('idprogetto', this.state.callerState.currentRow.idprogetto);
				self.state.DS.tables.workpackagesegview.staticFilter(filter);
				self.state.DS.tables.progettotipocosto.staticFilter(filter);
				self.state.DS.tables.saldefaultview.staticFilter(filter);
				self.state.DS.tables.rendicontattivitaprogettosegview.staticFilter(filter);
			},

			//buttons
        });

	window.appMeta.addMetaPage('progettocosto', 'segprg', metaPage_progettocosto);

}());
